Public Class UC_Empleado

    ' Función genérica para limpiar el panel de contenido y cargar la nueva sub-vista
    Private Sub MostrarSubVista(uc As UserControl)
        ' Asegúrate de que el panel grande donde se muestra la info se llame "Panel_de_contenido"
        Panel_de_contenido.Controls.Clear()

        ' El UserControl ocupará todo el espacio del panel de contenido
        uc.Dock = DockStyle.Fill

        Panel_de_contenido.Controls.Add(uc)
        uc.BringToFront()
    End Sub

    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub BTN_MOD_Click(sender As Object, e As EventArgs) Handles BTN_MOD.Click
        MostrarSubVista(New UC_E_Modificar())
    End Sub

    Private Sub BTN_NEW_Click(sender As Object, e As EventArgs) Handles BTN_NEW.Click
        MostrarSubVista(New UC_E_Nuevo())
    End Sub

    Private Sub BTN_DEL_Click(sender As Object, e As EventArgs) Handles BTN_DEL.Click
        MostrarSubVista(New UC_E_Eliminar())
    End Sub
End Class
