Public Class UC_Cliente

    Private Sub MostrarSubVista(uc As UserControl)
        ' Asegúrate de que el panel grande donde se muestra la info se llame "Panel_de_contenido"
        Panel_de_contenido.Controls.Clear()

        ' El UserControl ocupará todo el espacio del panel de contenido
        uc.Dock = DockStyle.Fill

        Panel_de_contenido.Controls.Add(uc)
        uc.BringToFront()
    End Sub


    Private Sub BTN_NEW_Click(sender As Object, e As EventArgs)
        MostrarSubVista(New UC_C_Nuevo)
    End Sub

    Private Sub BTN_MOD_Click(sender As Object, e As EventArgs)
        MostrarSubVista(New UC_C_Modificar)
    End Sub

    Private Sub BTN_DEL_Click(sender As Object, e As EventArgs)
        MostrarSubVista(New UC_C_Eliminar)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles BTN_NEW.Click
        MostrarSubVista(New UC_C_Nuevo)
    End Sub

    Private Sub BTN_MOD_Click_1(sender As Object, e As EventArgs) Handles BTN_MOD.Click
        MostrarSubVista(New UC_C_Modificar)
    End Sub

    Private Sub BTN_DEL_Click_1(sender As Object, e As EventArgs) Handles BTN_DEL.Click
        MostrarSubVista(New UC_C_Eliminar)
    End Sub
End Class
