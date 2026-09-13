Public Class Interfaz_Principal

    ' Subrutina para cambiar dinámicamente la vista en el panel
    Private Sub MostrarVista(ByVal vista As UserControl)
        ' 1. Limpia los controles anteriores dentro del panel
        panelContenido.Controls.Clear()

        ' 2. Ajusta la nueva vista para que ocupe todo el espacio (Dock = Fill)
        vista.Dock = DockStyle.Fill

        ' 3. Agrega la vista al panel y la trae al frente
        panelContenido.Controls.Add(vista)
        vista.BringToFront()
    End Sub
    Private Sub Interfaz_Principal_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub VentasToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click

    End Sub

    Private Sub ToolStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ToolStrip1.ItemClicked

    End Sub

    Private Sub ToolStripLabel1_Click(sender As Object, e As EventArgs) Handles ToolStripLabel1.Click

    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click

    End Sub

    Private Sub panelContenido_Paint(sender As Object, e As PaintEventArgs) Handles panelContenido.Paint

    End Sub
End Class