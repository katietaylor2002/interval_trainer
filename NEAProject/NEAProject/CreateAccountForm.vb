Public Class CreateAccountForm
    Private Sub btnStudentAccount_Click(sender As Object, e As EventArgs) Handles btnStudentAccount.Click
        ' goes to student create account page
        Me.Close()
        CreateStudentAccout.Show()
    End Sub

    Private Sub btnTeacherAccount_Click(sender As Object, e As EventArgs) Handles btnTeacherAccount.Click
        ' goes to teacher create account page
        Me.Close()
        CreateTeacherAccount.Show()
    End Sub
End Class