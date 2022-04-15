Public Class DisplayTestResultsForm

    Private Sub pbBackToMenu_Click(sender As Object, e As EventArgs) Handles pbBackToMenu.Click
        ' goes back to student menu
        Me.Close()
        StudentMenu.Show()
    End Sub

    Private Sub DisplayTestResultsForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' puts the percentage score from the test as a label on the form
        lblPercentageScore.Text = DisplayTestForm.GetThisTestAverageScore & "%"
    End Sub
End Class