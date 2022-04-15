Public Class NewClass
    Private SQLStr As String
    Private ClassName As String
    Private ClassID As String

    Private Sub btnCreateNewClass_Click(sender As Object, e As EventArgs) Handles btnCreateNewClass.Click
        Dim validName As Boolean = False
        Dim validClassID As Boolean = False
        Dim randomNumber As String
        ' checks to see if a value has been added to the class name textbox
        If tbxCreateNewClassName.Text.Length < 1 Then
            MsgBox("Please enter a class name")
        Else
            ' checks to see if the teacher has another class with the same name 
            SQLStr = "SELECT COUNT(ClassName) FROM tblClass WHERE ClassName = @ID"
            Dim GetClassNameDB As New DatabaseConnection(SQLStr)
            If GetClassNameDB.SelectStringID(tbxCreateNewClassName.Text) = 0 Then
                ClassName = tbxCreateNewClassName.Text
                validName = True
            Else
                MsgBox("Please enter a unique class name")
            End If
        End If
        ' generates a random 6 digit number to be the class code and then checks to see if it is already a class code
        If validName = True Then
            SQLStr = "SELECT COUNT(ClassID) FROM tblClass WHERE ClassID = @ID"
            Dim GetClassIDDB As New DatabaseConnection(SQLStr)
            Do
                randomNumber = RandomSixDigitNumber()
                If GetClassIDDB.SelectStringID(randomNumber) = "0" And randomNumber.Length = 6 Then
                    validClassID = True
                End If
            Loop Until validClassID
            ' sets class ID
            ClassID = randomNumber
            ' saves new class to database
            SQLStr = "INSERT INTO tblClass VALUES (@ClassID, @ClassName, @TeacherID)"
            Dim SaveClassDB As New DatabaseConnection(SQLStr)
            SaveClassDB.SaveClass(ClassID, ClassName, LogInForm.GetCurrentID)
            MsgBox("Class created :)")
            ' goes back to teacher menu and reloads class list to show new class
            Me.Hide()
            Dim ReDisplay As New TeacherMenu
            TeacherMenu.Show()
            ReDisplay.DisplayClasses()
        End If
    End Sub

    Private Function RandomSixDigitNumber()
        Randomize()
        Return Int((1000000 * Rnd()) + 1)
    End Function
End Class