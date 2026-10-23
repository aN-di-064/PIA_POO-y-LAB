Public Class UC_Ventas
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Using frmBusqueda As New Busqueda_Venta()
            If frmBusqueda.ShowDialog() = DialogResult.OK Then
                Dim codigo As String = frmBusqueda.CodigoSeleccionado
                Dim descripcion As String = frmBusqueda.DescripcionSeleccionada
                Dim precio As Decimal = frmBusqueda.PrecioSeleccionado
                Dim cantidad As Integer = 1
                Dim importe As Decimal = cantidad * precio

                ' Insertar directamente una nueva fila en el DataGridView de Ventas
                DataGridView1.Rows.Add(codigo, descripcion, cantidad, precio, importe)
            End If
        End Using
    End Sub
End Class
