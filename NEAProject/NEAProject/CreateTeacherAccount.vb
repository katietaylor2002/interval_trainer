Public Class CreateTeacherAccount
    ' ---------------------------HARD CODED FOR TESTING -----------------------------------------
    Private ListOfConfirmedTeacherIDs() As String = {"AAA", "ABC", "JAD", "PSC"}
    ' List is hard coded for testing but in the actual implementation of the program it would be stored in and read from a file
    '--------------------------------------------------------------------------------------------
    Private TeacherID As String
    Private FirstName As String
    Private Surname As String
    Private Password As String
    Private ConfirmPassword As String
    Private EmptyBox As Boolean
    Private CorrectID As Boolean
    Private PasswordMatch As Boolean
    Private ConfirmedTeacher As Boolean
    Private UniqueAccount As Boolean

    Private Sub btnConfirmCreateTeacherAccount_Click(sender As Object, e As EventArgs) Handles btnConfirmCreateTeacherAccount.Click
        EmptyBox = False
        UniqueAccount = False
        PasswordMatch = True
        ConfirmedTeacher = False
        CorrectID = False
        ' resets colour to white so red error boxes are accurate to this round of data 
        For Each c In Me.Controls
            If TypeName(c) = "TextBox" Then
                c.BackColor = Color.White
            End If
        Next

        ' assigns information from textboxes to variables
        TeacherID = txbTeacherIDCreateTeacherAccount.Text.ToUpper
        Try
            FirstName = txbFirstNameCreateTeacherAccount.Text.Substring(0, 1).ToUpper + txbFirstNameCreateTeacherAccount.Text.Substring(1)
            Surname = txbSurnameCreateTeacherAccount.Text.Substring(0, 1).ToUpper + txbSurnameCreateTeacherAccount.Text.Substring(1)
        Catch
            EmptyBox = True
        End Try
        Password = txbPasswordCreateTeacherAccount.Text
        ConfirmPassword = txbConfirmPasswordCreateTeacherAccount.Text

        ' validates inputs
        Validation()

        ' checks to see if account has been previously created
        CheckAgainstDatabase()

        ' prints error messages
        PrintMessages()

        ' closes form if all inputs are correct
        If EmptyBox = False And CorrectID = True And PasswordMatch = True And UniqueAccount = True Then
            SaveTeacherDetailsToDatabase()
            Me.Close()
            LogInForm.Show()
        End If
    End Sub

    Private Sub SaveTeacherDetailsToDatabase()
        ' saves the new account to the database
        Dim SQLString As String
        SQLString = "INSERT INTO tblTeacher VALUES (@ID, @FirstName ,@Surname, @Password)"
        Dim SaveTeacherDB As New DatabaseConnection(SQLString)
        SaveTeacherDB.SaveUser(TeacherID, FirstName, Surname, Password)
        MsgBox("Account created - You many now log in.")
    End Sub

    Private Sub CheckAgainstDatabase()
        ' checks to see if the account is already in the database
        Dim SQLString As String
        SQLString = "SELECT COUNT(TeacherID) FROM tblTeacher
                  WHERE TeacherID = @ID"
        Dim TeacherIDCheckDB As New DatabaseConnection(SQLString)
        If TeacherIDCheckDB.SelectStringID(TeacherID) = "0" Then
            ' if it is not in database then unique account set to true
            UniqueAccount = True
        Else
            ' if the account has already been created then textbox is made red
            txbTeacherIDCreateTeacherAccount.BackColor = Color.MistyRose
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
        ' checks to see if teacherID is the correct format
        If TeacherID.Length <> 3 Then
            CorrectID = False
            txbTeacherIDCreateTeacherAccount.BackColor = Color.MistyRose
        End If
        Try
            TeacherID = CInt(TeacherID)
        Catch ex As Exception
            CorrectID = True
        End Try
        ' checks to see if teacherId is of a confirmed teacher (to prevent students creating teacher accounts)
        For x = 0 To ListOfConfirmedTeacherIDs.Length - 1
            If TeacherID = ListOfConfirmedTeacherIDs(x) Then
                ConfirmedTeacher = True
            End If
        Next
        ' checks to see if passwords match
        If Password <> ConfirmPassword Then
            PasswordMatch = False
            txbConfirmPasswordCreateTeacherAccount.BackColor = Color.MistyRose
        End If
    End Sub

    Private Sub PrintMessages()
        ' prints the messages based on what is wrong with the data entered
        If EmptyBox = True Then
            MsgBox("Please fill in all boxes.")
        End If
        If CorrectID = False Then
            MsgBox("Your TeacherID is in the wrong format, it must be 3 letters.")
        End If
        If PasswordMatch = False Then
            MsgBox("Your passwords do not match.")
        End If
        If ConfirmedTeacher = False Then
            MsgBox("This is not a known Teacher ID.")
        End If
        If UniqueAccount = False Then
            MsgBox("There is already an account associated with this Teacher ID.")
        End If
    End Sub

    Private Sub pbBackToMenu_Click(sender As Object, e As EventArgs) Handles pbBackToMenu.Click
        ' goes back to launch page
        Me.Close()
        LaunchPage.Show()
    End Sub

End Class