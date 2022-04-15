Public Class IntervalData

    Private Sub pbBackToMenu_Click(sender As Object, e As EventArgs) Handles pbBackToMenu.Click
        ' goes back to student menu
        Me.Close()
        StudentMenu.Show()
    End Sub
End Class