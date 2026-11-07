Public Class UC_Categoria

    ' Función genérica para limpiar el panel de contenido y cargar la nueva sub-vista
    Private Sub MostrarSubVista(uc As UserControl)
        ' Asegúrate de que el panel grande donde se muestra la info se llame "Panel_de_contenido"
        Panel_de_contenido.Controls.Clear()

        ' El UserControl ocupará todo el espacio del panel de contenido
        uc.Dock = DockStyle.Fill

        Panel_de_contenido.Controls.Add(uc)
        uc.BringToFront()
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        MostrarSubVista(New UC_CAT_Nuevo())
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        MostrarSubVista(New UC_CAT_Modificar())
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        MostrarSubVista(New UC_CAT_Eliminar())
    End Sub
End Class
