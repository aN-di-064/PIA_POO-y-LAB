Public Class UC_Ventas
    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        Using frmBusqueda As New Busqueda_Venta
            If frmBusqueda.ShowDialog = DialogResult.OK Then
                Dim codigo = frmBusqueda.CodigoSeleccionado
                Dim descripcion = frmBusqueda.DescripcionSeleccionada
                Dim precio = frmBusqueda.PrecioSeleccionado
                Dim cantidad = 1
                Dim importe = cantidad * precio

                ' Insertar directamente una nueva fila en el DataGridView de Ventas
                DataGridView1.Rows.Add(codigo, descripcion, cantidad, precio, importe)
            End If
        End Using
    End Sub
End Class
