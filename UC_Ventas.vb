Imports System.Data.OleDb

Public Class UC_Ventas

    Private Sub UC_Ventas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ObtenerSiguienteIDVenta()
        CargarClientes()
        CalcularTotal()
    End Sub

    ' 1. Obtener el número preview de venta (MAX(Id_v) + 1)
    Private Sub ObtenerSiguienteIDVenta()
        Try
            Using con As OleDbConnection = ObtenerConexion()
                Dim query As String = "SELECT MAX(Id_v) FROM Venta"
                Using cmd As New OleDbCommand(query, con)
                    Dim result = cmd.ExecuteScalar()
                    If result IsNot DBNull.Value AndAlso result IsNot Nothing Then
                        LBL_IDCOMPRA.Text = (Convert.ToInt32(result) + 1).ToString()
                    Else
                        LBL_IDCOMPRA.Text = "1"
                    End If
                End Using
            End Using
        Catch ex As Exception
            LBL_IDCOMPRA.Text = "1"
        End Try
    End Sub

    ' 2. Cargar lista de clientes desde la tabla Cliente y seleccionar el primero
    Private Sub CargarClientes()
        Try
            Using con As OleDbConnection = ObtenerConexion()
                Dim query As String = "SELECT Id_cli, Nombre_cli FROM Cliente"
                Using adapter As New OleDbDataAdapter(query, con)
                    Dim dt As New DataTable()
                    adapter.Fill(dt)
                    CB_Cliente.DataSource = dt
                    CB_Cliente.DisplayMember = "Nombre_cli"
                    CB_Cliente.ValueMember = "Id_cli"

                    ' Seleccionar el primer registro si existe
                    If dt.Rows.Count > 0 Then
                        CB_Cliente.SelectedIndex = 0
                    Else
                        CB_Cliente.SelectedIndex = -1
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al cargar los clientes: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' 3. Botón "Buscar producto"
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim buscador As New Busqueda_Venta()
        buscador.TipoBusqueda = "PRODUCTO"

        If buscador.ShowDialog() = DialogResult.OK Then
            Dim codigo As String = buscador.CodigoSeleccionado
            Dim descripcion As String = buscador.DescripcionSeleccionada
            Dim precio As Decimal = buscador.PrecioSeleccionado

            ' Verificar si ya está en la lista para incrementar la cantidad
            Dim yaExiste As Boolean = False
            For Each row As DataGridViewRow In DataGridView1.Rows
                If row.Cells("Col_Código").Value IsNot Nothing AndAlso row.Cells("Col_Código").Value.ToString() = codigo Then
                    Dim cantActual As Decimal = Convert.ToDecimal(row.Cells("Col_Cantidad").Value)
                    row.Cells("Col_Cantidad").Value = cantActual + 1
                    row.Cells("Col_Importe").Value = (cantActual + 1) * precio
                    yaExiste = True
                    Exit For
                End If
            Next

            ' Si no existe, agregarlo como nuevo renglón (Cantidad por defecto = 1)
            If Not yaExiste Then
                DataGridView1.Rows.Add(1, codigo, descripcion, precio, precio)
            End If

            CalcularTotal()
        End If
    End Sub

    ' 4. Recalcular subtotal al editar directamente la cantidad en la celda
    Private Sub DataGridView1_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellValueChanged
        If e.RowIndex >= 0 AndAlso e.ColumnIndex = DataGridView1.Columns("Col_Cantidad").Index Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim cantidad As Decimal = 0
            Dim precio As Decimal = 0

            Decimal.TryParse(Convert.ToString(row.Cells("Col_Cantidad").Value), cantidad)
            Decimal.TryParse(Convert.ToString(row.Cells("Col_Precio").Value), precio)

            row.Cells("Col_Importe").Value = cantidad * precio
            CalcularTotal()
        End If
    End Sub

    ' 5. Recalcular el total acumulado
    Private Sub CalcularTotal()
        Dim total As Decimal = 0
        For Each row As DataGridViewRow In DataGridView1.Rows
            If row.Cells("Col_Importe").Value IsNot Nothing Then
                total += Convert.ToDecimal(row.Cells("Col_Importe").Value)
            End If
        Next
        Label4.Text = total.ToString("C2")
        Label4.Tag = total ' Guardar valor numérico real
    End Sub

    ' Método auxiliar para confirmar y eliminar productos seleccionados
    Private Sub EliminarProductoSeleccionado()
        If DataGridView1.SelectedRows.Count > 0 Then
            Dim respuesta As DialogResult = MessageBox.Show("¿Desea eliminar el producto seleccionado?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If respuesta = DialogResult.Yes Then
                For Each row As DataGridViewRow In DataGridView1.SelectedRows
                    If Not row.IsNewRow Then
                        DataGridView1.Rows.Remove(row)
                    End If
                Next
                CalcularTotal()
            End If
        Else
            MessageBox.Show("Seleccione una fila para borrar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    ' 6. Botón "Borrar producto seleccionado" (Button3 o BTN_BORRAR)
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click, BTN_BORRAR.Click
        EliminarProductoSeleccionado()
    End Sub

    ' 6.1 Evento para eliminar al presionar la tecla Suprimir (Delete) en el DataGridView
    Private Sub DataGridView1_KeyDown(sender As Object, e As KeyEventArgs) Handles DataGridView1.KeyDown
        If e.KeyCode = Keys.Delete Then
            EliminarProductoSeleccionado()
        End If
    End Sub

    ' 7. Botón "Cobrar" (Button4)
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click, Button1.Click
        ' Validar que existan productos en el DataGridView
        If DataGridView1.Rows.Count = 0 Then
            MessageBox.Show("No hay productos agregados a la venta.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' Validar estrictamente que un cliente esté seleccionado en el ComboBox
        If CB_Cliente.Items.Count = 0 OrElse
           CB_Cliente.SelectedIndex = -1 OrElse
           CB_Cliente.SelectedValue Is Nothing OrElse
           String.IsNullOrWhiteSpace(CB_Cliente.Text) Then

            MessageBox.Show("No hay un cliente seleccionado. Por favor, seleccione o registre un cliente antes de continuar con la venta.", "Cliente Requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            CB_Cliente.Focus()
            Exit Sub
        End If

        Dim totalVenta As Decimal = If(Label4.Tag IsNot Nothing, Convert.ToDecimal(Label4.Tag), 0)

        ' Abrir el formulario unificado de Cobro enviando datos para el Ticket
        Dim frmCobro As New Cobro()
        frmCobro.EsVenta = True
        frmCobro.TotalTransaccion = totalVenta
        frmCobro.FolioVenta = LBL_IDCOMPRA.Text
        frmCobro.NombreCliente = CB_Cliente.Text
        frmCobro.ListaProductos = DataGridView1.Rows

        If frmCobro.ShowDialog() = DialogResult.OK Then
            ProcesarVentaEnBD(totalVenta)
        End If
    End Sub

    ' 8. Guardar Venta, Detalle_VP y actualizar Existencias del inventario
    Private Sub ProcesarVentaEnBD(totalVenta As Decimal)
        Try
            Using con As OleDbConnection = ObtenerConexion()

                ' a) Obtener el Id_cor activo (Corte de caja sin cerrar)
                Dim idCorteActivo As Object = Nothing
                Dim queryCorte As String = "SELECT TOP 1 Id_cor FROM Corte WHERE FechaCierre_cor IS NULL ORDER BY Id_cor DESC"
                Using cmdCorte As New OleDbCommand(queryCorte, con)
                    idCorteActivo = cmdCorte.ExecuteScalar()
                End Using

                If idCorteActivo Is Nothing OrElse idCorteActivo Is DBNull.Value Then
                    MessageBox.Show("No hay ninguna caja abierta actualmente. Por favor, realice la Apertura de Caja primero.", "Caja Cerrada", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If

                ' b) Insertar la cabecera en la tabla Venta
                Dim idVentaGenerado As Integer = 0
                Dim queryVenta As String = "INSERT INTO Venta (fecha_v, Id_cli, Id_emp, Id_cor, total_v) VALUES (?, ?, ?, ?, ?)"
                Using cmdVenta As New OleDbCommand(queryVenta, con)
                    cmdVenta.Parameters.AddWithValue("?", DateTime.Now)
                    cmdVenta.Parameters.AddWithValue("?", Convert.ToInt32(CB_Cliente.SelectedValue))
                    cmdVenta.Parameters.AddWithValue("?", 1) ' Reemplazar 1 por el ID del Empleado activo en sesión
                    cmdVenta.Parameters.AddWithValue("?", Convert.ToInt32(idCorteActivo))
                    cmdVenta.Parameters.AddWithValue("?", totalVenta)
                    cmdVenta.ExecuteNonQuery()

                    ' Recuperar el ID de la venta creada
                    cmdVenta.CommandText = "SELECT @@IDENTITY"
                    idVentaGenerado = Convert.ToInt32(cmdVenta.ExecuteScalar())
                End Using

                ' c) Insertar detalles en Detalle_VP y descontar existencias en Producto
                For Each row As DataGridViewRow In DataGridView1.Rows
                    If row.IsNewRow Then Continue For

                    Dim idProd As Integer = Convert.ToInt32(row.Cells("Col_Código").Value)
                    Dim cantidad As Decimal = Convert.ToDecimal(row.Cells("Col_Cantidad").Value)
                    Dim precio As Decimal = Convert.ToDecimal(row.Cells("Col_Precio").Value)
                    Dim subtotal As Decimal = Convert.ToDecimal(row.Cells("Col_Importe").Value)

                    ' Insertar en Detalle_VP
                    Dim queryDetalle As String = "INSERT INTO Detalle_VP (Id_v, Id_prod, Cantidad_VP, Precio_VP, Descuento_VP, Subtotal_VP) VALUES (?, ?, ?, ?, ?, ?)"
                    Using cmdDet As New OleDbCommand(queryDetalle, con)
                        cmdDet.Parameters.AddWithValue("?", idVentaGenerado)
                        cmdDet.Parameters.AddWithValue("?", idProd)
                        cmdDet.Parameters.AddWithValue("?", cantidad)
                        cmdDet.Parameters.AddWithValue("?", precio)
                        cmdDet.Parameters.AddWithValue("?", 0) ' Descuento
                        cmdDet.Parameters.AddWithValue("?", subtotal)
                        cmdDet.ExecuteNonQuery()
                    End Using

                    ' Actualizar (restar) Inventario en Producto
                    Dim queryStock As String = "UPDATE Producto SET Existencias = Existencias - ? WHERE Id_prod = ?"
                    Using cmdStock As New OleDbCommand(queryStock, con)
                        cmdStock.Parameters.AddWithValue("?", cantidad)
                        cmdStock.Parameters.AddWithValue("?", idProd)
                        cmdStock.ExecuteNonQuery()
                    End Using
                Next

                MessageBox.Show("¡Venta completada exitosamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)

                ' Limpiar pantalla, restablecer cliente al primero e incrementar el Folio de Venta
                DataGridView1.Rows.Clear()
                CalcularTotal()
                ObtenerSiguienteIDVenta()
                CargarClientes()

            End Using
        Catch ex As Exception
            MessageBox.Show("Error al guardar la venta: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
    End Sub

End Class