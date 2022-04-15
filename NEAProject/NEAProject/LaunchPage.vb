Imports MySql.Data.MySqlClient
Imports System.Threading

Public Class LaunchPage

    Private Sub btnLogIn_Click(sender As Object, e As EventArgs) Handles btnLogIn.Click
        'opens log in form
        Me.Hide()
        LogInForm.Show()
    End Sub

    Private Sub btnCreateAccount_Click(sender As Object, e As EventArgs) Handles btnCreateAccount.Click
        ' opens create account form
        Me.Hide()
        CreateAccountForm.Show()
    End Sub

End Class

Class Question
    ' 10 new objects created for each test: each have these properties
    Property TestID As String
    Property IntervalIndex As Integer
    Property QuestionNumber As Integer
    Property StartingNote As Integer
    Property Direction As String

    Sub New(ByVal ID As String, ByVal Index As Integer, ByVal Question As Integer, ByVal Starting As Integer, ByVal AscOrDesc As String)
        TestID = ID
        IntervalIndex = Index
        QuestionNumber = Question
        StartingNote = Starting
        Direction = AscOrDesc
    End Sub

End Class

Class Test
    ' parent class to leveltest and personaltest
    Protected studentUser As Boolean
    Private ThisTest As New List(Of Question)
    Private TestID As String
    Protected Level As Integer
    Protected Intervals(9) As Integer

    Sub New(ByVal TestLevel As Integer, ByVal StudentOrTeacher As Boolean)
        Level = TestLevel
        studentUser = StudentOrTeacher
        GenerateTestID()
        GenerateIntervals()
        GenerateStartingNoteAndDirection()
        SaveToDatabase()
    End Sub

    Private Sub GenerateStartingNoteAndDirection()
        Dim SQLString As String
        Dim semitones As Integer
        Dim intervalIndex As Integer
        Dim startingNote As Integer
        Dim Direction As String
        ' loops for each of the 10 intervals in the test
        For n = 0 To 9
            intervalIndex = Intervals(n)
            ' makes call to database to find the number of semitones in the interval for the current question
            SQLString = "SELECT Semitones FROM tblInterval WHERE IntervalID = @IntervalID"
            Dim SemitonesDB As New DatabaseConnection(SQLString)
            semitones = SemitonesDB.SelectIntegerID(intervalIndex)
            ' uses semitones in the interval to determine which starting notes are possible 
            ' (as if it was entirely random it might not be possible to play the ending note as there is not an infinite number of notes)
            If semitones > 18 Then
                ' there are 36 notes available and therefore if the number of semitones is above 18 the starting note cannot be in the middle of the range of notes
                ' randomly generates a starting note between 0 and 11 or 23 and 35
                If GenerateRandomNumber(0, 100) Mod 2 = 0 Then
                    startingNote = GenerateRandomNumber(0, 11)
                Else
                    startingNote = GenerateRandomNumber(23, 35)
                End If
            Else
                ' if semitones is less that 18 then the starting note can be any of the 36
                startingNote = GenerateRandomNumber(0, 35)
            End If
            ' determines the direction by ensuring the ending note isn't out of the range of notes
            If startingNote + semitones > 35 Then
                Direction = "Desc"
            ElseIf startingNote - semitones < 0 Then
                Direction = "Asc"
            Else
                ' if the direction will not cause the note to go out of range it is randomised
                If GenerateRandomNumber(0, 100) Mod 2 = 0 Then
                    Direction = "Asc"
                Else
                    Direction = "Desc"
                End If
            End If
            ' adds all the information for this question to a new question in the list for this test
            ThisTest.Add(New Question(TestID, intervalIndex, n + 1, startingNote, Direction))
        Next
    End Sub

    Private Sub GenerateTestID()
        ' generates a unique string to be used as testID
        TestID = Guid.NewGuid.ToString("N")
    End Sub

    Protected Function GenerateRandomNumber(ByVal min As Integer, ByVal max As Integer)
        ' generates a random number between two given values
        Randomize()
        Return Int((max - min + 1) * Rnd()) + min
    End Function

    Private Sub SaveToDatabase()
        Dim ClassID As String = TeacherMenu.GetClassID
        Dim DueDate As Date = TeacherMenu.GetDateDue
        Dim SQLString As String
        ' saves the information for each question in the test to the Question table
        For Each Question In ThisTest
            SQLString = "INSERT INTO tblQuestion VALUES (@TestID, @QuestionNumber ,@IntervalID, @StartingNote, @Direction)"
            Dim SaveQuestionsDB As New DatabaseConnection(SQLString)
            SaveQuestionsDB.SaveQuestions(Question.TestID, Question.QuestionNumber, Question.IntervalIndex, Question.StartingNote, Question.Direction)
        Next
        ' if it is a teacher then the class it is assigned to and the due date for the test are saved to the Test table
        If studentUser = False Then
            SQLString = "INSERT INTO tblAssignment VALUES (@TestID, @TestName, @ClassID, @DueDate)"
            Dim SaveTestDB As New DatabaseConnection(SQLString)
            SaveTestDB.SaveAssignment(TeacherMenu.GetTestName, TestID, ClassID, DueDate)
        End If
    End Sub

    Public Function GetTestID()
        Return TestID
    End Function

    Overridable Sub GenerateIntervals()
        ' assigns the interval indexes of the checked boxes to the interval array
        For n = 0 To 9
            Intervals(n) = TeacherMenu.GetIntervals(n)
        Next
    End Sub

End Class

Class LevelTest
    Inherits Test
    Sub New(ByVal TestLevel As Integer, ByVal StudentUser As Boolean)
        ' runs when a new level test is created
        MyBase.New(TestLevel, StudentUser)
    End Sub

    Overrides Sub GenerateIntervals()
        Dim randomNumber As Integer
        'loops 10 times - an interval for each question. 
        'Random Number Is indicative of the interval index: the interval indexes that can be used Is dependent on the level selected by the user
        For n = 0 To 9
            ' easiest intervals (2nds, 3rds, perfect 4ths, 5ths and 8ths)
            If Level = 1 Then
                Dim Random As Integer = GenerateRandomNumber(0, 6)
                If Random < 5 Then
                    Intervals(n) = GenerateRandomNumber(0, 4)
                ElseIf Random = 5 Then
                    Intervals(n) = 6
                ElseIf Random = 6 Then
                    Intervals(n) = 11
                End If
            End If
            ' intervals that are NOT compound or augmented
            If Level = 2 Then
                Do
                    randomNumber = GenerateRandomNumber(0, 11)
                Loop Until randomNumber <> 5
                Intervals(n) = randomNumber
            End If
            ' intervals that are NOT compound
            If Level = 3 Then
                Intervals(n) = GenerateRandomNumber(0, 11)
            End If
            ' any interval
            If Level = 4 Then
                Intervals(n) = GenerateRandomNumber(0, 23)
            End If
        Next
    End Sub

End Class

Class PersonalTest
    Inherits Test
    Private CurrentStudentID As String

    Sub New()
        MyBase.New(0, True)
    End Sub

    Overrides Sub GenerateIntervals()
        ' generates 10 intervals based on the average performance this student has had on each interval: the ones performed the most poor on will be tested
        Dim SQLString As String
        Dim CorrectCount(23) As Integer
        Dim TimesAttempted(23) As Integer
        Dim AverageSuccess As New List(Of Decimal)
        CurrentStudentID = LogInForm.GetCurrentID
        ' loops for all 24 intervals
        For interval = 0 To 23
            ' makes call to database and finds the number of times this interval has been identified correctly by this student
            SQLString = "SELECT COUNT(Correct) FROM tblResult 
                  INNER JOIN tblQuestion
                  ON tblResult.TestID = tblQuestion.TestID 
                  AND tblResult.QuestionNumber = tblQuestion.QuestionNumber
                  WHERE StudentID = @StudentID
                  AND IntervalID = @IntervalID
                  AND Correct = 1"
            Dim CorrectCountDB As New DatabaseConnection(SQLString)
            CorrectCount(interval) = CorrectCountDB.SelectTwoIDs(CurrentStudentID, interval)

            'makes call to database and finds the number of times this student has been tested on this interval
            SQLString = "SELECT COUNT(Correct) FROM tblResult 
                  INNER JOIN tblQuestion
                  ON tblResult.TestID = tblQuestion.TestID 
                  AND tblResult.QuestionNumber = tblQuestion.QuestionNumber
                  WHERE StudentID = @StudentID
                  AND IntervalID = @IntervalID"
            Dim TimesAttemptedDB As New DatabaseConnection(SQLString)
            TimesAttempted(interval) = TimesAttemptedDB.SelectTwoIDs(CurrentStudentID, interval)

            ' creates an average score based on number of times answered correctly and number of times tested total (worst being 0, best being 1)
            If TimesAttempted(interval) = 0 Then
                ' if the interval has never been tested it is assigned success of 0
                AverageSuccess.Add(0)
                ' new item is added for each interval containing success value
            Else AverageSuccess.Add(CorrectCount(interval) / TimesAttempted(interval))
            End If
        Next
        ' saves the index (which represents the interval ID) to the list
        Dim AverageSuccessWithIndex = AverageSuccess.Select(Function(n, i) New With {.Num = n, .Idx = i})
        ' sorts the average success in ascending order
        Dim sortedSuccesses = AverageSuccessWithIndex.OrderBy(Function(nwi) nwi.Num)
        ' saves the indexes (interval IDs) of the 10 intervals with the lowest success and saves them to the Intervals array used in GenerateStartingNoteAndDirection()
        Intervals = sortedSuccesses.Take(10).Select(Function(x) x.Idx).ToArray()
        ' randomises the order of the intervals to avoid the intervals being in order (therefore making them easier to randomly guess)
        Dim randomIndex As Integer
        Dim tempvalue1 As Integer
        Dim tempvalue2 As Integer
        For x As Integer = 0 To Intervals.Length - 1
            Randomize()
            randomIndex = CInt(Int((Intervals.Length) * Rnd()))
            tempvalue1 = Intervals(x)
            tempvalue2 = Intervals(randomIndex)
            Intervals(x) = tempvalue2
            Intervals(randomIndex) = tempvalue1
        Next
    End Sub

End Class

Class TakeTest
    Private TestID As String
    Private StudentID As String
    Private thisTest As New List(Of Question)

    Sub New(ByVal IDTest As String, ByVal IDStudent As String)
        TestID = IDTest
        StudentID = IDStudent
        GetQuestionsFromDatabase()
    End Sub

    Private Sub GetQuestionsFromDatabase()
        Dim intervalIndex As Integer
        Dim StartingNote As Integer
        Dim Direction As String
        Dim SQLString As String
        ' loops through each question number and gets the intervalID, starting note and direction associated with that question and TestID
        For questionNumber = 1 To 10
            SQLString = "SELECT IntervalID FROM tblQuestion WHERE QuestionNumber = " & questionNumber & " AND TestID = @ID"
            Dim IntervalIDDB As New DatabaseConnection(SQLString)
            intervalIndex = IntervalIDDB.SelectStringID(TestID)

            SQLString = "SELECT StartingNote FROM tblQuestion WHERE QuestionNumber = " & questionNumber & " AND TestID = @ID"
            Dim StartingNoteDB As New DatabaseConnection(SQLString)
            StartingNote = StartingNoteDB.SelectStringID(TestID)

            SQLString = "SELECT Direction FROM tblQuestion WHERE QuestionNumber = " & questionNumber & " AND TestID = @ID"
            Dim DirectionDB As New DatabaseConnection(SQLString)
            Direction = DirectionDB.SelectStringID(TestID)

            ' this information is added as a new item in the list of the questions in this test
            thisTest.Add(New Question(TestID, intervalIndex, questionNumber, StartingNote, Direction))
        Next
    End Sub

    Public Sub PlayInterval(ByVal QuestionNumber As Integer)
        Dim semitones As Integer
        ' intervalIndex, startingnote and direction are retrieved for the question passed in, from the list created in GetQuestionsFromDatabase
        Dim intervalIndex As Integer = thisTest(QuestionNumber - 1).IntervalIndex
        Dim startingNote As Integer = thisTest(QuestionNumber - 1).StartingNote
        Dim Direction As String = thisTest(QuestionNumber - 1).Direction
        Dim SQLString As String
        SQLString = "SELECT Semitones FROM tblInterval WHERE IntervalID = @IntervalID"
        Dim SemitonesDB As New DatabaseConnection(SQLString)
        semitones = SemitonesDB.SelectIntegerID(intervalIndex)
        ' interval to be tested is played passing in starting note and finsishing note (which is based on direction and semitones)
        If Direction = "Asc" Then
            Interval.PlayInterval(startingNote, startingNote + semitones)
        Else
            Interval.PlayInterval(startingNote, startingNote - semitones)
        End If
    End Sub

    Public Function GetTestID()
        Return TestID
    End Function

End Class
Class DatabaseConnection
    Dim MyCommand As MySqlCommand
    Dim MyConnection As MySqlConnection
    Dim MyReader As MySqlDataReader
    Dim DDLstr As String
    Dim SQLstr As String
    ' ---------------------------------HARD CODED FOR TESTING------------------------------------------------
    Dim ConnStr As String = "server=localhost;user=testuser;Database=neatesting;port=3306;password=testing123;"
    ' The connection string has been hard coded for testing purposes - however in the actual implementation of the program it would be stored in and read from a file
    ' --------------------------------------------------------------------------------------------------------

    Sub New(ByVal sqlString As String)
        ' saves SQLString and opens database for every connection instantiated
        SQLstr = sqlString
        OpenDatabase()
    End Sub

    Private Sub OpenDatabase()
        Try
            ' opens connection to database
            MyConnection = New MySqlConnection(ConnStr)
            MyConnection.Open()
        Catch
            MsgBox("Could not connect to the specified database.")
        End Try
    End Sub

    Private Function ExecuteCommand()
        ' reads the results of the query and returns them
        Dim result As String = ""
        Try
            MyReader = MyCommand.ExecuteReader()
            While MyReader.Read()
                result = (MyReader.GetString(0))
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        MyReader.Close()
        MyConnection.Close()
        Return result
    End Function

    ' database queries with one paramater: int / str / str (returns list)

    Public Function SelectIntegerID(ByVal IntervalID As Integer)
        ' creates command for query that needs a variable
        MyCommand = New MySqlCommand(SQLstr, MyConnection)
        MyCommand.Parameters.AddWithValue("@IntervalID", IntervalID)
        ' returns the value returned from the query
        Return ExecuteCommand()
    End Function

    Public Function SelectStringID(ByVal ID As String)
        ' creates command for query that needs TestID as a variable
        MyCommand = New MySqlCommand(SQLstr, MyConnection)
        MyCommand.Parameters.AddWithValue("@ID", ID)
        ' returns the value returned from the query
        Return ExecuteCommand()
    End Function

    Public Function GetClassList(ByVal TeacherID As String)
        ' returns a list using TeacherID as variable
        Dim result As New List(Of String)
        MyCommand = New MySqlCommand(SQLstr, MyConnection)
        MyCommand.Parameters.AddWithValue("@ID", TeacherID)
        Try
            MyReader = MyCommand.ExecuteReader()
            While MyReader.Read()
                result.Add(MyReader.GetString(0))
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        MyReader.Close()
        MyConnection.Close()
        Return result
    End Function

    ' database queries with two parameters: str & int / str & str

    Public Function SelectTwoIDs(ByVal StudentID As String, ByVal IntervalID As Integer)
        ' creates command for query that needs IntervalID and StudentID as variables
        MyCommand = New MySqlCommand(SQLstr, MyConnection)
        MyCommand.Parameters.AddWithValue("@IntervalID", IntervalID)
        MyCommand.Parameters.AddWithValue("@StudentID", StudentID)
        ' returns the value returned from the query
        Return ExecuteCommand()
    End Function

    Public Function SearchUser(ByVal username As String, ByVal password As String)
        ' select using a username and password as variables
        MyCommand = New MySqlCommand(SQLstr, MyConnection)
        MyCommand.Parameters.AddWithValue("@Username", username)
        MyCommand.Parameters.AddWithValue("@Password", password)
        Return ExecuteCommand()
    End Function

    ' database query with three parameters: str & date & str

    Public Function SelectThreeStrings(ByVal TestName As String, ByVal DueDate As Date, ByVal ClassID As String)
        MyCommand = New MySqlCommand(SQLstr, MyConnection)
        MyCommand.Parameters.AddWithValue("@TestName", TestName)
        MyCommand.Parameters.AddWithValue("@ClassID", ClassID)
        MyCommand.Parameters.AddWithValue("@DueDate", DueDate)
        ' returns the value returned from the query
        Return ExecuteCommand()
    End Function

    ' non queries (delete/update)

    Public Sub DeleteFromStudent(ByVal StudentID As String)
        ' executes non query with StudentID as variable
        Try
            MyCommand = New MySqlCommand(SQLstr, MyConnection)
            MyCommand.Parameters.AddWithValue("@ID", StudentID)
            MyCommand.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        MyConnection.Close()
    End Sub

    Public Sub UpdateStudent(ByVal ClassID As String, ByVal StudentID As String)
        ' executes non query with StudentID and ClassID as variables
        Try
            MyCommand = New MySqlCommand(SQLstr, MyConnection)
            MyCommand.Parameters.AddWithValue("@ClassID", ClassID)
            MyCommand.Parameters.AddWithValue("@StudentID", StudentID)
            MyCommand.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        MyConnection.Close()
    End Sub

    ' save all values to tables

    Public Sub SaveQuestions(ByVal TestID As String, ByVal QuestionNumber As Integer, ByVal IntervalID As Integer, ByVal StartingNote As Integer, ByVal Direction As String)
        ' creates command for query to save to the question table that requires all of the question table data as variables
        Try
            MyCommand = New MySqlCommand(SQLstr, MyConnection)
            MyCommand.Parameters.AddWithValue("@TestID", TestID)
            MyCommand.Parameters.AddWithValue("@QuestionNumber", QuestionNumber)
            MyCommand.Parameters.AddWithValue("@IntervalID", IntervalID)
            MyCommand.Parameters.AddWithValue("@StartingNote", StartingNote)
            MyCommand.Parameters.AddWithValue("@Direction", Direction)
            MyCommand.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        MyConnection.Close()
    End Sub

    Public Sub SaveAssignment(ByVal TestName As String, ByVal TestID As String, ByVal ClassID As String, ByVal DueDate As Date)
        ' creates command for query to save to the test table that requires all the test table data as variables
        Try
            MyCommand = New MySqlCommand(SQLstr, MyConnection)
            MyCommand.Parameters.AddWithValue("@TestName", TestName)
            MyCommand.Parameters.AddWithValue("@TestID", TestID)
            MyCommand.Parameters.AddWithValue("@ClassID", ClassID)
            MyCommand.Parameters.AddWithValue("@DueDate", DueDate)
            MyCommand.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        MyConnection.Close()
    End Sub

    Public Sub SaveUser(ByVal ID As String, ByVal FirstName As String, ByVal Surname As String, ByVal Password As String)
        ' saves all information into a user account (student or teacher)
        Try
            MyCommand = New MySqlCommand(SQLstr, MyConnection)
            MyCommand.Parameters.AddWithValue("@ID", ID)
            MyCommand.Parameters.AddWithValue("@FirstName", FirstName)
            MyCommand.Parameters.AddWithValue("@Surname", Surname)
            MyCommand.Parameters.AddWithValue("@Password", Password)
            MyCommand.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        MyConnection.Close()
    End Sub

    Public Sub SaveClass(ByVal ClassID As String, ByVal ClassName As String, ByVal TeacherID As String)
        ' save to class table
        Try
            MyCommand = New MySqlCommand(SQLstr, MyConnection)
            MyCommand.Parameters.AddWithValue("@ClassID", ClassID)
            MyCommand.Parameters.AddWithValue("@ClassName", ClassName)
            MyCommand.Parameters.AddWithValue("@TeacherID", TeacherID)
            MyCommand.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        MyConnection.Close()
    End Sub

    Public Sub SaveResults(ByVal TestID As String, ByVal StudentID As String, ByVal QuestionNumber As Integer, ByVal Correct As Boolean)
        ' save to results table
        Try
            MyCommand = New MySqlCommand(SQLstr, MyConnection)
            MyCommand.Parameters.AddWithValue("@TestID", TestID)
            MyCommand.Parameters.AddWithValue("@StudentID", StudentID)
            MyCommand.Parameters.AddWithValue("@QuestionNumber", QuestionNumber)
            MyCommand.Parameters.AddWithValue("@Correct", Correct)
            MyCommand.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        MyConnection.Close()
    End Sub

    Public Sub SaveSummary(ByVal StudentID As String, ByVal TotalQuestions As Integer, ByVal TotalCorrect As Integer, ByVal AverageScore As Integer)
        ' save to summary table
        Try
            MyCommand = New MySqlCommand(SQLstr, MyConnection)
            MyCommand.Parameters.AddWithValue("@StudentID", StudentID)
            MyCommand.Parameters.AddWithValue("@TotalQuestions", TotalQuestions)
            MyCommand.Parameters.AddWithValue("@TotalCorrect", TotalCorrect)
            MyCommand.Parameters.AddWithValue("@AverageScore", AverageScore)
            MyCommand.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        MyConnection.Close()
    End Sub

    Public Sub SaveFinishedTest(ByVal TestID As String, ByVal StudentID As String, ByVal Percentage As Integer, ByVal DateDone As DateTime)
        ' save to finished test table
        Try
            MyCommand = New MySqlCommand(SQLstr, MyConnection)
            MyCommand.Parameters.AddWithValue("@TestID", TestID)
            MyCommand.Parameters.AddWithValue("@StudentID", StudentID)
            MyCommand.Parameters.AddWithValue("@PercentageScore", Percentage)
            MyCommand.Parameters.AddWithValue("@DateCompleted", DateDone)
            MyCommand.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        MyConnection.Close()
    End Sub

    ' output data from database to table

    Public Sub ClassTable(ByVal TeacherID As String)
        Try
            ' binds SQLtable to datagrid
            MyCommand = New MySqlCommand(SQLstr, MyConnection)
            MyCommand.Parameters.AddWithValue("@ID", TeacherID)
            MyCommand.CommandType = CommandType.Text
            Using sda As New MySqlDataAdapter(MyCommand)
                Using dt As New DataTable()
                    sda.Fill(dt)
                    TeacherMenu.DataGridView1.DataSource = dt
                End Using
            End Using
        Catch
            MsgBox("Could not add data to table.")
        End Try
    End Sub

    Public Sub ResultsTable(ByVal TestID As String, ByVal StudentID As String)
        Try
            ' binds SQLtable to datagrid
            MyCommand = New MySqlCommand(SQLstr, MyConnection)
            MyCommand.Parameters.AddWithValue("@TestID", TestID)
            MyCommand.Parameters.AddWithValue("@StudentID", StudentID)
            MyCommand.CommandType = CommandType.Text
            Using sda As New MySqlDataAdapter(MyCommand)
                Using dt As New DataTable()
                    sda.Fill(dt)
                    DisplayTestResultsForm.DataGridView1.DataSource = dt
                End Using
            End Using
        Catch
            MsgBox("Could not add data to table.")
        End Try
    End Sub

    Public Sub AssignmentsTable(ByVal ClassID As String, ByVal StudentID As String)
        Try
            ' binds SQLtable to datagrid
            MyCommand = New MySqlCommand(SQLstr, MyConnection)
            MyCommand.Parameters.AddWithValue("@ClassID", ClassID)
            MyCommand.Parameters.AddWithValue("@StudentID", StudentID)
            MyCommand.CommandType = CommandType.Text
            Using sda As New MySqlDataAdapter(MyCommand)
                Using dt As New DataTable()
                    sda.Fill(dt)
                    StudentMenu.dgvCurrentAssignments.DataSource = dt
                End Using
            End Using
        Catch
            MsgBox("Could not add data to table.")
        End Try
    End Sub

    Public Sub CompleteAssignmentsTable(ByVal ClassID As String, ByVal StudentID As String)
        Try
            ' binds SQLtable to datagrid
            MyCommand = New MySqlCommand(SQLstr, MyConnection)
            MyCommand.Parameters.AddWithValue("@ClassID", ClassID)
            MyCommand.Parameters.AddWithValue("@StudentID", StudentID)
            MyCommand.CommandType = CommandType.Text
            Using sda As New MySqlDataAdapter(MyCommand)
                Using dt As New DataTable()
                    sda.Fill(dt)
                    StudentMenu.dgvCompleteAssignments.DataSource = dt
                End Using
            End Using
        Catch
            MsgBox("Could not add data to table.")
        End Try
    End Sub

    Public Sub SummaryTable(ByVal StudentID As String)
        Try
            ' binds SQLtable to datagrid
            MyCommand = New MySqlCommand(SQLstr, MyConnection)
            MyCommand.Parameters.AddWithValue("@StudentID", StudentID)
            MyCommand.CommandType = CommandType.Text
            Using sda As New MySqlDataAdapter(MyCommand)
                Using dt As New DataTable()
                    sda.Fill(dt)
                    StudentMenu.dgvTestSummaries.DataSource = dt
                End Using
            End Using
        Catch
            MsgBox("Could not add data to table.")
        End Try
    End Sub

    Public Sub IntervalTable(ByVal StudentID As String)
        Try
            ' binds SQLtable to datagrid
            MyCommand = New MySqlCommand(SQLstr, MyConnection)
            MyCommand.Parameters.AddWithValue("@StudentID", StudentID)
            MyCommand.CommandType = CommandType.Text
            Using sda As New MySqlDataAdapter(MyCommand)
                Using dt As New DataTable()
                    sda.Fill(dt)
                    IntervalData.dgvIntervalData.DataSource = dt
                End Using
            End Using
        Catch
            MsgBox("Could not add data to table.")
        End Try
    End Sub

    Public Sub StudentTable(ByVal TeacherID As String)
        Try
            ' binds SQLtable to datagrid
            MyCommand = New MySqlCommand(SQLstr, MyConnection)
            MyCommand.Parameters.AddWithValue("@TeacherID", TeacherID)
            MyCommand.CommandType = CommandType.Text
            Using sda As New MySqlDataAdapter(MyCommand)
                Using dt As New DataTable()
                    sda.Fill(dt)
                    TeacherMenu.dgvStudentResults.DataSource = dt
                End Using
            End Using
        Catch
            MsgBox("Could not add data to table.")
        End Try
    End Sub

    ' output data from database to chart

    Public Sub SummaryChart(ByVal StudentID As String)
        Try
            ' adds data to the summary chart from the database
            StudentMenu.crtSummaryData.Series("% Score").Points.Clear()
            MyCommand = New MySqlCommand(SQLstr, MyConnection)
            MyCommand.Parameters.AddWithValue("@StudentID", StudentID)
            MyReader = MyCommand.ExecuteReader
            While MyReader.Read
                StudentMenu.crtSummaryData.Series("% Score").Points.AddXY(MyReader.GetDateTime("DateCompleted"), MyReader.GetInt32("PercentageScore"))
            End While
        Catch
            MsgBox("Could not add data to chart.")
        End Try
    End Sub

    Public Sub StudentChart(ByVal StudentID As String)
        ' adds data to the summary chart from the database
        Try
            StudentMenu.crtSummaryData.Series("% Score").Points.Clear()
            MyCommand = New MySqlCommand(SQLstr, MyConnection)
            MyCommand.Parameters.AddWithValue("@StudentID", StudentID)
            MyReader = MyCommand.ExecuteReader
            While MyReader.Read
                StudentGraph.crtStudentData.Series("% Score").Points.AddXY(MyReader.GetDateTime("DateCompleted"), MyReader.GetInt32("PercentageScore"))
            End While
        Catch
            MsgBox("Could not add data to chart.")
        End Try
    End Sub

End Class

Class Interval

    Protected Shared Sub Play(interval() As Note)
        ' this plays the interval
        Dim n As Note
        For Each n In interval
            If n.NoteTone = Tone.REST Then
                Thread.Sleep(CInt(n.NoteDuration))
            Else
                Console.Beep(CInt(n.NoteTone), CInt(n.NoteDuration))
            End If
        Next n
    End Sub

    Public Shared Sub PlayInterval(ByRef StartingNote As Integer, ByRef EndingNote As Integer)
        ' each note is in the array notes
        Dim Notes() As String = {Tone.C3, Tone.Cs3, Tone.D3, Tone.Ds3, Tone.E3, Tone.F3, Tone.Fs3, Tone.G3, Tone.Gs3, Tone.A3, Tone.As3, Tone.B3, Tone.C4, Tone.Cs4, Tone.D4, Tone.Ds4, Tone.E4, Tone.F4, Tone.Fs4, Tone.G4, Tone.Gs4, Tone.A4, Tone.As4, Tone.B4, Tone.C5, Tone.Cs5, Tone.D5, Tone.Ds5, Tone.E5, Tone.F5, Tone.Fs5, Tone.G5, Tone.Gs5, Tone.A5, Tone.As5, Tone.B5, Tone.C6}
        ' a new interval is created with the starting note and ending note
        Dim PlayInterval As Note() = {
            New Note(Notes(StartingNote), Duration.HALF), New Note(Notes(EndingNote), Duration.HALF)}
        ' the interval is played
        Play(PlayInterval)
    End Sub

    Protected Enum Tone
        ' list of note names and their respective frequencies
        REST = 0
        C3 = 130.81
        Cs3 = 138.59
        D3 = 146.83
        Ds3 = 155.56
        E3 = 164.81
        F3 = 174.61
        Fs3 = 185
        G3 = 196
        Gs3 = 207.65
        A3 = 220
        As3 = 233.08
        B3 = 246.94
        C4 = 261.63
        Cs4 = 277.18
        D4 = 293.66
        Ds4 = 311.13
        E4 = 329.63
        F4 = 349.23
        Fs4 = 369.99
        G4 = 392
        Gs4 = 415.3
        A4 = 440
        As4 = 466.16
        B4 = 493.88
        C5 = 523.25
        Cs5 = 554.37
        D5 = 587.33
        Ds5 = 622.25
        E5 = 659.25
        F5 = 698.46
        Fs5 = 739.99
        G5 = 783.99
        Gs5 = 830.61
        A5 = 880
        As5 = 932.33
        B5 = 987.77
        C6 = 1046.5
    End Enum

    Protected Enum Duration
        ' list of note durations so that the length of the notes being played can be changed
        WHOLE = 1600
        HALF = WHOLE / 2
        QUARTER = HALF / 2
        EIGHTH = QUARTER / 2
        SIXTEENTH = EIGHTH / 2
    End Enum

    Protected Structure Note
        ' when a new note is created it is assigned a pitch and a duration
        Private Tonevalue As Tone
        Private Durationvalue As Duration

        Public Sub New(frequency As Tone, time As Duration)
            Tonevalue = frequency
            Durationvalue = time
        End Sub

        Public ReadOnly Property NoteTone() As Tone
            Get
                Return Tonevalue
            End Get
        End Property

        Public ReadOnly Property NoteDuration() As Duration
            Get
                Return Durationvalue
            End Get
        End Property
    End Structure
End Class
