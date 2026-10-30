Public Class UC_Inventario

    ' Función genérica para limpiar el panel de contenido y cargar la nueva sub-vista
    Private Sub MostrarSubVista(uc As UserControl)
        ' Asegúrate de que el panel grande donde se muestra la info se llame "Panel_de_contenido"
        Panel_de_contenido.Controls.Clear()

        ' El UserControl ocupará todo el espacio del panel de contenido
        uc.Dock = DockStyle.Fill

        Panel_de_contenido.Controls.Add(uc)
        uc.BringToFront()
    End Sub

    ' Botón Nuevo / Agregar producto
    Private Sub BTN_NEW_Click(sender As Object, e As EventArgs) Handles BTN_NEW.Click
        MostrarSubVista(New UC_I_Nuevo())
    End Sub

    ' Botón Modificar producto
    Private Sub BTN_MOD_Click(sender As Object, e As EventArgs) Handles BTN_MOD.Click
        MostrarSubVista(New UC_I_Modificar())
    End Sub

    ' Botón Eliminar producto
    Private Sub BTN_DEL_Click(sender As Object, e As EventArgs) Handles BTN_DEL.Click
        MostrarSubVista(New UC_I_Eliminar())
    End Sub

    ' Botón de Categorías (para administrar la tabla Categoria desde VB.NET)
    Private Sub BTN_CAT_Click(sender As Object, e As EventArgs) Handles BTN_CAT.Click
        MostrarSubVista(New UC_I_Categoria())
    End Sub

End Class