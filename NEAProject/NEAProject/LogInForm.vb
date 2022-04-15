Public Class LogInForm
    Private Shared CurrentID As String
    Private StudentAccount As Boolean
    Private Password As String
    Private AccountInDatabase As Boolean
    Private EmptyBoxes As Boolean
    Private CorrectID As Boolean

    Private Sub btnSubmitLoginDetails_Click(sender As Object, e As EventArgs) Handles btnSubmitLoginDetails.Click
        AccountInDatabase = False
        EmptyBoxes = False
        CorrectID = True
        ' assign varaiables from textbox input
        CurrentID = txbUsernameLogin.Text
        Password = txbPasswordLogin.Text
        ' validate inputs
        Validation()
        ' check database to see if log in matches database
        If EmptyBoxes = False And CorrectID = True Then
            CheckDatabaseForLogin()
        End If
        ' display error messages
        DisplayMessages()
        If EmptyBoxes = False And CorrectID = True And AccountInDatabase = True Then
            If StudentAccount = True Then
                Me.Close()
                StudentMenu.Show()
            Else
                Me.Close()
                TeacherMenu.Show()
            End If
        End If
    End Sub

    Private Sub Validation()
        ' presence check
        If CurrentID = "" Or Password = "" Then
            EmptyBoxes = True
        End If
        ' decides if currentID is student or teacher
        If CurrentID.Length = 6 Then
            StudentAccount = True
        ElseIf CurrentID.Length = 3 Then
            StudentAccount = False
        Else
            CorrectID = False
        End If
        ' type check for studentID and teacherID
        If StudentAccount = True Then
            If Not IsNumeric(CurrentID) Then
                CorrectID = False
            End If
        Else
            Try
                CurrentID = CInt(CurrentID)
            Catch ex As Exception
                CorrectID = True
                CurrentID = CurrentID.ToUpper
            End Try
        End If
    End Sub

    Private Sub CheckDatabaseForLogin()
        Dim SQLString As String
        ' use string length to determine if it's a student or teacher logging in
        If CurrentID.Length = 6 Then
            StudentAccount = True
            SQLString = "SELECT COUNT(StudentID) FROM tblStudent
                  WHERE StudentID = @Username AND Password = @Password"
        Else
            StudentAccount = False
            SQLString = "SELECT COUNT(TeacherID) FROM tblTeacher
                  WHERE TeacherID = @Username AND Password = @Password"
        End If
        ' search database for login info
        Dim SearchUserDB As New DatabaseConnection(SQLString)
        If SearchUserDB.SearchUser(CurrentID, Password) = 1 Then
            AccountInDatabase = True
        End If
    End Sub

    Private Sub DisplayMessages()
        ' displays error messages based on validation
        If EmptyBoxes = True Then
            MsgBox("Please fill in all boxes.")
        End If
        If AccountInDatabase = False And EmptyBoxes = False Then
            MsgBox("This information does not match an account. Please try again.")
        End If
        If CorrectID = False Then
            MsgBox("Your ID is in the wrong format.")
        End If
    End Sub

    Private Sub pbBackToMenu_Click(sender As Object, e As EventArgs) Handles pbBackToMenu.Click
        ' goes back to launch page
        Me.Close()
        LaunchPage.Show()
    End Sub

    Public Function GetStudentAccount()
        If StudentAccount = True Then
            Return "Student"
        Else
            Return "Teacher"
        End If
    End Function

    Public Function GetCurrentID()
        Return CurrentID
    End Function

End Class