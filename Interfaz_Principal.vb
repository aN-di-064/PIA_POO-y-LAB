Public Class Interfaz_Principal
    'Cambiar la ventana
    Private Sub MostrarVista(ByVal vista As UserControl)
        panelContenido.Controls.Clear()

        vista.Dock = DockStyle.Fill

        panelContenido.Controls.Add(vista)
        vista.BringToFront()
    End Sub
    Private Sub Interfaz_Principal_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub VentasToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        MostrarVista(New UC_Ventas())
    End Sub

    Private Sub ToolStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ToolStrip1.ItemClicked
        ' 1. Obtener el botón exacto que fue presionado usando e.ClickedItem
        Dim botonActual As ToolStripButton = TryCast(e.ClickedItem, ToolStripButton)

        If botonActual IsNot Nothing Then
            ' 2. Recorrer todos los elementos de la barra (ToolStrip)
            For Each item As ToolStripItem In ToolStrip1.Items
                Dim btn As ToolStripButton = TryCast(item, ToolStripButton)

                If btn IsNot Nothing Then
                    If btn Is botonActual Then
                        ' Si es el botón al que se le dio clic, se queda marcado
                        btn.Checked = True
                    Else
                        ' A todos los demás se les quita la marca
                        btn.Checked = False
                    End If
                End If
            Next
        End If
    End Sub

    Private Sub ToolStripLabel1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        ' Verificar si el usuario no tiene permisos de Administrador (Rol <> 1)
        If InicioSesion.IdRolActual <> 1 Then
            MessageBox.Show("No tienes acceso a esta pestaña. Se requieren permisos de administrador.",
                        "Acceso Denegado",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' Si el rol es 1, permite mostrar la vista de Inventario
        MostrarVista(New UC_Inventario())
    End Sub

    Private Sub panelContenido_Paint(sender As Object, e As PaintEventArgs) Handles panelContenido.Paint

    End Sub

    Private Sub ToolStripSplitButton1_ButtonClick(sender As Object, e As EventArgs) Handles ToolStripSplitButton1.ButtonClick
        ' Limpiar las variables del usuario activo en el módulo
        InicioSesion.CerrarSesion()

        ' Mostrar de nuevo la pantalla de Login (Form1)
        Form1.Show()

        ' Cerrar la interfaz principal
        Me.Close()
    End Sub

    Private Sub ToolStripComboBox1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        ' Se permite el acceso a todos los usuarios sin validar el rol

        ' Instanciar el formulario RangoFechas
        Using frmRango As New RangoFechas()
            ' Abrir la ventana de manera modal
            If frmRango.ShowDialog() = DialogResult.OK Then
                ' Capturar las fechas definidas en la ventana modal
                Dim fInicio As DateTime = frmRango.FechaInicio
                Dim fFin As DateTime = frmRango.FechaFin

                ' Cargar la vista pasándole el rango de fechas
                MostrarVista(New UC_ReporteDia(fInicio, fFin))
            End If
        End Using
    End Sub

    Private Sub ToolStripSplitButton2_ButtonClick(sender As Object, e As EventArgs) Handles ToolStripSplitButton2.ButtonClick
        ' Verificar si el usuario no tiene permisos de Administrador (Rol <> 1)
        If InicioSesion.IdRolActual <> 1 Then
            MessageBox.Show("No tienes acceso a esta pestaña. Se requieren permisos de administrador.",
                        "Acceso Denegado",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' Si el rol es 1, permite mostrar la vista de Inventario
        MostrarVista(New UC_Cliente())
    End Sub

    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles ToolStripButton5.Click
        ' Verificar si el usuario no tiene permisos de Administrador (Rol <> 1)
        If InicioSesion.IdRolActual <> 1 Then
            MessageBox.Show("No tienes acceso a esta pestaña. Se requieren permisos de administrador.",
                        "Acceso Denegado",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' Si el rol es 1, permite mostrar la vista de Inventario
        MostrarVista(New UC_Empleado())
    End Sub

    Private Sub ToolStripButton7_Click(sender As Object, e As EventArgs) Handles ToolStripButton7.Click
        MostrarVista(New UC_Compras())
    End Sub
End Class