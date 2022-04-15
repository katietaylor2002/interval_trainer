Public Class CreateStudentAccout
    Private StudentID As String
    Private FirstName As String
    Private Surname As String
    Private Password As String
    Private ConfirmPassword As String
    Private EmptyBox As Boolean
    Private CorrectID As Boolean
    Private PasswordMatch As Boolean
    Private UniqueAccount As Boolean

    Private Sub btnConfirmCreateStudentAccount_Click(sender As Object, e As EventArgs) Handles btnConfirmCreateStudentAccount.Click
        EmptyBox = False
        UniqueAccount = False
        PasswordMatch = True
        CorrectID = True
        ' resets colour to white so red error boxes are accurate to this round of data 
        For Each c In Me.Controls
            If TypeName(c) = "TextBox" Then
                c.BackColor = Color.White
            End If
        Next
        ' assigns information from textboxes to variables
        StudentID = txbStudentNumberCreateStudentAccount.Text
        Try
            FirstName = txbFirstNameCreateStudentAccount.Text.Substring(0, 1).ToUpper + txbFirstNameCreateStudentAccount.Text.Substring(1)
            Surname = txbSurnameCreateStudentAccount.Text.Substring(0, 1).ToUpper + txbSurnameCreateStudentAccount.Text.Substring(1)
        Catch
            EmptyBox = True
        End Try
        Password = txbPasswordCreateStudentAccount.Text
        ConfirmPassword = txbConfirmPasswordCreateStudentAccount.Text
        ' validate textbox inputs
        Validation()
        ' check to see if the account already exists
        CheckAgainstDatabase()
        ' print error messages
        PrintMessages()
        ' closes form if all data is entered correctly
        If EmptyBox = False And CorrectID = True And PasswordMatch = True Then
            SaveStudentDetailsToDatabase()
            Me.Close()
            LogInForm.Show()
        End If
    End Sub

    Private Sub Validation()
        ' checks to see if all textboxes have information in them and turns the incorrect textboxes red
        For Each c In Me.Controls
            If TypeName(c) = "TextBox" Then
                If c.Text = "" Then
                    EmptyBox = True
                    c.BackColor = Color.MistyRose
                End If
            End If
        Next
        ' checks to see if studentID is the correct format
        If StudentID.Length <> 6 Then
            CorrectID = False
            txbStudentNumberCreateStudentAccount.BackColor = Color.MistyRose
        End If
        If Not IsNumeric(StudentID) Then
            CorrectID = False
            txbStudentNumberCreateStudentAccount.BackColor = Color.MistyRose
        End If
        ' checks to see if passwords match
        If Password <> ConfirmPassword Then
            PasswordMatch = False
            txbConfirmPasswordCreateStudentAccount.BackColor = Color.MistyRose
        End If
    End Sub

    Private Sub PrintMessages()
        ' print messages based on what is wrong with the inputs
        If EmptyBox = True Then
            MsgBox("Please fill in all boxes.")
        End If
        If CorrectID = False Then
            MsgBox("Your StudentID is in the wrong format, it must be 6 numbers.")
        End If
        If PasswordMatch = False Then
            MsgBox("Your passwords do not match.")
        End If
        If UniqueAccount = False Then
            MsgBox("There is already an account associated with this Student ID")
        End If
    End Sub

    Private Sub CheckAgainstDatabase()
        ' checks to see if the student account is already in the database
        Dim SQLString As String
        SQLString = "SELECT COUNT(StudentID) FROM tblStudent
                  WHERE StudentID = @ID"
        Dim TeacherIDCheckDB As New DatabaseConnection(SQLString)
        If TeacherIDCheckDB.SelectStringID(StudentID) = "0" Then
            ' if it is not in database unique account is set to true
            UniqueAccount = True
        Else
            ' if it is in the database the textbox is set to red and unique account remains false
            txbStudentNumberCreateStudentAccount.BackColor = Color.MistyRose
        End If
    End Sub

    Private Sub SaveStudentDetailsToDatabase()
        ' saves the details of the student account to the database
        Dim SQLString As String
        SQLString = "INSERT INTO tblStudent (StudentID, FirstName, Surname, Password) 
VALUES (@ID, @FirstName ,@Surname, @Password)"
        Dim SaveStudentDB As New DatabaseConnection(SQLString)
        SaveStudentDB.SaveUser(StudentID, FirstName, Surname, Password)
        MsgBox("Account created - You many now log in.")
    End Sub

    Private Sub pbBackToMenu_Click(sender As Object, e As EventArgs) Handles pbBackToMenu.Click
        ' back to launch page
        Me.Close()
        LaunchPage.Show()
    End Sub
End Class