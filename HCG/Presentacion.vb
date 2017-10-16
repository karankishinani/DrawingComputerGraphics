Public Class frmPresentacion

    Private Sub btnContinuar_Click(sender As Object, e As EventArgs) Handles btnContinuar.Click
        Me.Hide()
        frmPrincipal.Show()
    End Sub
End Class