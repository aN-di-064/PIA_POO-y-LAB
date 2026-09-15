Public Class UC_I_Modificar
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        MessageBox.Show("¿Está seguro de realizar los cambios?", "Confirmar cambios",
                     MessageBoxButtons.YesNo, MessageBoxIcon.Question)
    End Sub
End Class
