Public Class UC_Empleado

    Private Sub MostrarSubVista(uc As UserControl)
        PANEL_DERECHO.Controls.Clear()

        ' El UserControl ocupará todo el panel derecho, 
        ' y él solito se encargará de centrar sus elementos internos
        uc.Dock = DockStyle.Fill

        PANEL_DERECHO.Controls.Add(uc)
        uc.BringToFront()
    End Sub

    Private Sub BTN_NEW_Click(sender As Object, e As EventArgs) Handles BTN_NEW.Click
        MostrarSubVista(New UC_E_Nuevo)
    End Sub

    Private Sub BTN_MOD_Click(sender As Object, e As EventArgs) Handles BTN_MOD.Click
        MostrarSubVista(New UC_E_Modificar())
    End Sub

    Private Sub BTN_DEL_Click(sender As Object, e As EventArgs) Handles BTN_DEL.Click
        MostrarSubVista(New UC_E_Eliminar())
    End Sub
End Class
