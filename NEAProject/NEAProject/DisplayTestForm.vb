Public Class DisplayTestForm
    Private QuestionCounter As Integer
    Private CurrentTest As TakeTest = StudentMenu.GetThisTest()
    Private TestID As String = CurrentTest.GetTestID
    Private TimesPlayed As Integer
    Private SQLStr As String
    Private Results(9) As Boolean
    ' ---------------- HARD CODED FOR TESTING -------------------------------
    Private MaxTimesPlayed As Integer = 2
    ' Number of times an interval can be played is hard coded for testing purposes but it actual implementation would be read from a file
    '------------------------------------------------------------------------
    Private Shared ThisTestAverageScore As Integer

    Private Sub DisplayTestForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' initialises the test counter and writes the question number label
        QuestionCounter = 1
        lblQuestion.Text = "Question Number " & QuestionCounter
    End Sub

    Private Sub btnPlayInterval_Click(sender As Object, e As EventArgs) Handles btnPlayInterval.Click
        ' plays interval when button is clicked - only allowed to play interval twice per question
        If TimesPlayed < MaxTimesPlayed Then
            CurrentTest.PlayInterval(QuestionCounter)
            TimesPlayed += 1
            If TimesPlayed = MaxTimesPlayed Then
                btnPlayInterval.Enabled = False
                btnPlayInterval.BackColor = Color.DarkGray
            End If
        End If
    End Sub

    Private Sub btnConfirmAnswer_Click(sender As Object, e As EventArgs) Handles btnConfirmAnswer.Click
        ' checks to see if one quality and one number have been selected as the answer, if not gives error message 
        If CheckedListBox1.CheckedIndices.Count = 1 And CheckedListBox2.CheckedIndices.Count = 1 Then
            MarkAnswer()
        Else
            MsgBox("Please select one quality and one number")
        End If
    End Sub

    Private Sub MarkAnswer()
        Dim Quality As String
        Dim Number As String
        ' calls database and finds the quality from the question number and testID
        SQLStr = "SELECT Quality FROM tblInterval INNER JOIN tblQuestion ON tblInterval.IntervalID = tblQuestion.IntervalID WHERE QuestionNumber = " & QuestionCounter & " AND TestID = @ID"
        Dim SelectQuality As New DatabaseConnection(SQLStr)
        Quality = SelectQuality.SelectStringID(TestID)
        ' calls database and finds the number from the question number and testID
        SQLStr = "SELECT Number FROM tblInterval INNER JOIN tblQuestion ON tblInterval.IntervalID = tblQuestion.IntervalID WHERE QuestionNumber = " & QuestionCounter & " AND TestID = @ID"
        Dim SelectNumber As New DatabaseConnection(SQLStr)
        Number = SelectNumber.SelectStringID(TestID)
        ' checks to see if the data in the checked boxes matches the correct answer
        If CheckedListBox1.CheckedItems(0) = Quality And CheckedListBox2.CheckedItems(0) = Number Then
            MsgBox("Correct")
            ' adds boolean to results array
            Results(QuestionCounter - 1) = True
        Else
            MsgBox("Incorrect: The correct answer was " & Quality & " " & Number)
            ' adds boolean to results array
            Results(QuestionCounter - 1) = False
        End If
        ' goes to the next question if question counter is under 10
        If QuestionCounter < 10 Then
            NextQuestion()
        Else
            ' saves results to database and displays them after the 10th question
            SaveAndDisplayResults()
        End If
    End Sub

    Private Sub NextQuestion()
        ' advances to the next question - increments question counter and resets timesplayed and resets buttons and checkboxes
        QuestionCounter += 1
        lblQuestion.Text = "Question Number " & QuestionCounter
        TimesPlayed = 0
        btnPlayInterval.Enabled = True
        btnPlayInterval.BackColor = SystemColors.Control
        For i As Integer = 0 To CheckedListBox1.Items.Count - 1
            CheckedListBox1.SetItemChecked(i, False)
            CheckedListBox1.SetSelected(i, False)
        Next
        For i As Integer = 0 To CheckedListBox2.Items.Count - 1
            CheckedListBox2.SetItemChecked(i, False)
            CheckedListBox2.SetSelected(i, False)
        Next
    End Sub

    Private Sub SaveAndDisplayResults()
        ' save results to database
        For x = 1 To 10
            SQLStr = "INSERT INTO tblResult VALUES (@TestID, @StudentID, @QuestionNumber, @Correct)"
            Dim SaveToResultsDB As New DatabaseConnection(SQLStr)
            SaveToResultsDB.SaveResults(TestID, LogInForm.GetCurrentID, x, Results(x - 1))
        Next
        ' saves results to summary database
        Dim TotalCorrect As Integer
        Dim TotalQuestions As Integer = 10
        Dim AverageScore As Integer
        ' counts the total answers correct

        For x = 0 To 9
            If Results(x) = True Then
                TotalCorrect += 1
            End If
        Next
        ThisTestAverageScore = TotalCorrect / TotalQuestions * 100


        ' saves to finishedtest table
        SQLStr = "INSERT INTO tblFinishedTest VALUES (@TestID, @StudentID, @PercentageScore, @DateCompleted)"
        Dim SaveToFinishedTestDB As New DatabaseConnection(SQLStr)
        SaveToFinishedTestDB.SaveFinishedTest(TestID, LogInForm.GetCurrentID, ThisTestAverageScore, DateTime.Now)


        ' creates new summary record if the student doesn't have one, if not it adds to the existing one
        SQLStr = "SELECT COUNT(StudentID) FROM tblSummary WHERE StudentID = @ID"
        Dim FindStudentDB As New DatabaseConnection(SQLStr)
        If FindStudentDB.SelectStringID(LogInForm.GetCurrentID) = "0" Then
            ' saves to summary table
            SQLStr = "INSERT INTO tblSummary VALUES (@StudentID, @TotalQuestions, @TotalCorrect, @AverageScore)"
            Dim SaveToSummaryDB As New DatabaseConnection(SQLStr)
            SaveToSummaryDB.SaveSummary(LogInForm.GetCurrentID, TotalQuestions, TotalCorrect, ThisTestAverageScore)
        Else
            ' gets the old total questions and correct from the database and adds them to the ones from this test and saves new values to database
            SQLStr = "SELECT TotalQuestions FROM tblSummary WHERE StudentID = @ID"
            Dim SelectTotalQs As New DatabaseConnection(SQLStr)
            TotalQuestions += SelectTotalQs.SelectStringID(LogInForm.GetCurrentID)
            SQLStr = "SELECT TotalCorrect FROM tblSummary WHERE StudentID = @ID"
            Dim SelectTotalCorrect As New DatabaseConnection(SQLStr)
            TotalCorrect += SelectTotalCorrect.SelectStringID(LogInForm.GetCurrentID)
            AverageScore = TotalCorrect / TotalQuestions * 100
            SQLStr = "UPDATE tblSummary SET TotalQuestions = @TotalQuestions, TotalCorrect = @TotalCorrect, AverageScore = @AverageScore WHERE StudentID = @StudentID"
            Dim UpdateSummaryDB As New DatabaseConnection(SQLStr)
            UpdateSummaryDB.SaveSummary(LogInForm.GetCurrentID, TotalQuestions, TotalCorrect, AverageScore)
        End If


        ' display results
        SQLStr = "SELECT tblResult.QuestionNumber, Quality, Number, Correct FROM tblResult
        INNER JOIN tblQuestion ON tblResult.TestID = tblQuestion.TestID 
        AND tblresult.QuestionNumber = tblquestion.QuestionNumber
        INNER JOIN tblInterval ON tblquestion.IntervalID = tblinterval.IntervalID
        WHERE tblResult.TestID = @TestID AND StudentID = @StudentID"
        Dim DisplayResultsDB As New DatabaseConnection(SQLStr)
        DisplayResultsDB.ResultsTable(TestID, LogInForm.GetCurrentID)
        Me.Close()
        DisplayTestResultsForm.Show()
    End Sub

    Public Function GetThisTestAverageScore() As Integer
        Return ThisTestAverageScore
    End Function

End Class