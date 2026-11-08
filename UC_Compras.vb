Imports System.Data.OleDb

Public Class UC_Compras

    '========================================
    ' INICIALIZAR FORMULARIO
    '========================================
    Private Sub UC_Compras_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ActualizarNumeroCompra()
        CargarProveedor()
        CalcularTotal()
    End Sub

    '========================================
    ' FUNCIONES AUXILIARES DE COLUMNAS (ROBUSTO)
    '========================================
    Private Function ObtenerIndiceColumna(dgv As DataGridView, ParamArray posiblesNombres() As String) As Integer
        For Each nombre In posiblesNombres
            If dgv.Columns.Contains(nombre) Then
                Return dgv.Columns(nombre).Index
            End If
        Next
        If dgv.Columns.Count > 0 Then
            Return Math.Min(posiblesNombres.Length - 1, dgv.Columns.Count - 1)
        End If
        Return -1
    End Function

    '========================================
    ' 1. MOSTRAR SIGUIENTE NÚMERO DE COMPRA
    '========================================
    Private Sub ActualizarNumeroCompra()
        Try
            Using con As OleDbConnection = ObtenerConexion()
                Dim query As String = "SELECT MAX(ID_com) FROM Compras"
                Using cmd As New OleDbCommand(query, con)
                    Dim result = cmd.ExecuteScalar()
                    If result IsNot DBNull.Value AndAlso result IsNot Nothing Then
                        lblNumeroCompra.Text = (Convert.ToInt32(result) + 1).ToString()
                    Else
                        lblNumeroCompra.Text = "1"
                    End If
                End Using
            End Using
        Catch ex As Exception
            lblNumeroCompra.Text = "1"
        End Try
    End Sub

    '========================================
    ' 2. CARGAR PROVEEDORES
    '========================================
    Private Sub CargarProveedor()
        Try
            Using con As OleDbConnection = ObtenerConexion()
                Dim query As String = "SELECT ID_prov, Nombre_prov FROM Proveedor ORDER BY Nombre_prov"
                Using adapter As New OleDbDataAdapter(query, con)
                    Dim dt As New DataTable()
                    adapter.Fill(dt)
                    cboProveedor.DataSource = dt
                    cboProveedor.DisplayMember = "Nombre_prov"
                    cboProveedor.ValueMember = "ID_prov"

                    If dt.Rows.Count > 0 Then
                        cboProveedor.SelectedIndex = 0
                    Else
                        cboProveedor.SelectedIndex = -1
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al cargar proveedores: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cboProveedor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboProveedor.SelectedIndexChanged
        If btnBuscarProducto IsNot Nothing Then
            btnBuscarProducto.Enabled = cboProveedor.SelectedIndex <> -1 AndAlso cboProveedor.SelectedValue IsNot Nothing
        End If
    End Sub

    '========================================
    ' 3. BUSCAR Y AGREGAR PRODUCTO
    '========================================
    Private Sub btnBuscarProducto_Click(sender As Object, e As EventArgs) Handles btnBuscarProducto.Click
        ConexionBusqueda()
    End Sub

    Private Sub ConexionBusqueda()
        If cboProveedor.SelectedIndex = -1 Then
            MessageBox.Show("Selecciona un proveedor primero.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Using buscador As New Busqueda_Venta()
            buscador.TipoBusqueda = "PRODUCTO"
            buscador.Tag = "COMPRA"

            If buscador.ShowDialog() = DialogResult.OK Then
                Dim codigo As String = buscador.CodigoSeleccionado
                Dim descripcion As String = buscador.DescripcionSeleccionada
                Dim costo As Decimal = buscador.PrecioSeleccionado

                Dim idProdInt As Integer = 0
                Integer.TryParse(codigo, idProdInt)

                Dim idxCodigo As Integer = ObtenerIndiceColumna(dgvCompra, "Codigo", "Col_Código")
                Dim idxCant As Integer = ObtenerIndiceColumna(dgvCompra, "Cantidad", "Col_Cantidad")
                Dim idxDesc As Integer = ObtenerIndiceColumna(dgvCompra, "Descuento", "Col_Descuento")
                Dim idxSubtotal As Integer = ObtenerIndiceColumna(dgvCompra, "Subtotal", "Col_Importe")

                Dim yaExiste As Boolean = False
                If idxCodigo >= 0 Then
                    For Each row As DataGridViewRow In dgvCompra.Rows
                        If row.Cells(idxCodigo).Value IsNot Nothing AndAlso row.Cells(idxCodigo).Value.ToString() = codigo Then
                            Dim cantActual As Decimal = Convert.ToDecimal(row.Cells(idxCant).Value)
                            Dim pctDescuento As Decimal = Convert.ToDecimal(row.Cells(idxDesc).Value)

                            Dim nuevaCant As Decimal = cantActual + 1D
                            Dim bruto As Decimal = nuevaCant * costo
                            Dim descCalculado As Decimal = bruto * (pctDescuento / 100D)

                            row.Cells(idxCant).Value = nuevaCant
                            If idxSubtotal >= 0 Then
                                row.Cells(idxSubtotal).Value = bruto - descCalculado
                            End If
                            yaExiste = True
                            Exit For
                        End If
                    Next
                End If

                If Not yaExiste Then
                    If dgvCompra.Columns.Count >= 7 Then
                        dgvCompra.Rows.Add(idProdInt, 1D, codigo, descripcion, costo, 0.00D, costo)
                    Else
                        dgvCompra.Rows.Add(1D, codigo, descripcion, costo, 0.00D, costo)
                    End If
                End If

                If btnCobrar IsNot Nothing Then btnCobrar.Enabled = True
                If btnEliminar IsNot Nothing Then btnEliminar.Enabled = True

                CalcularTotal()
            End If
        End Using
    End Sub

    '========================================
    ' 4. RECALCULAR SUBTOTAL EN EDICIÓN
    '========================================
    Private Sub dgvCompra_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCompra.CellValueChanged
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = dgvCompra.Rows(e.RowIndex)
            Dim cantidad As Decimal = 0D
            Dim precio As Decimal = 0D
            Dim pctDescuento As Decimal = 0D

            Dim idxCant As Integer = ObtenerIndiceColumna(dgvCompra, "Cantidad", "Col_Cantidad")
            Dim idxPrecio As Integer = ObtenerIndiceColumna(dgvCompra, "Precio", "Col_Precio")
            Dim idxDesc As Integer = ObtenerIndiceColumna(dgvCompra, "Descuento", "Col_Descuento")
            Dim idxSubtotal As Integer = ObtenerIndiceColumna(dgvCompra, "Subtotal", "Col_Importe")

            If idxCant >= 0 Then Decimal.TryParse(Convert.ToString(row.Cells(idxCant).Value), cantidad)
            If idxPrecio >= 0 Then Decimal.TryParse(Convert.ToString(row.Cells(idxPrecio).Value), precio)
            If idxDesc >= 0 Then Decimal.TryParse(Convert.ToString(row.Cells(idxDesc).Value), pctDescuento)

            Dim bruto As Decimal = cantidad * precio
            Dim descuentoCalculado As Decimal = bruto * (pctDescuento / 100D)

            If idxSubtotal >= 0 Then
                row.Cells(idxSubtotal).Value = bruto - descuentoCalculado
            End If

            CalcularTotal()
        End If
    End Sub

    '========================================
    ' 5. CALCULAR TOTAL ACUMULADO
    '========================================
    Private Sub CalcularTotal()
        Dim total As Decimal = 0D
        Dim idxSubtotal As Integer = ObtenerIndiceColumna(dgvCompra, "Subtotal", "Col_Importe")

        If idxSubtotal < 0 OrElse (dgvCompra.Columns.Count > 0 AndAlso idxSubtotal >= dgvCompra.Columns.Count) Then
            idxSubtotal = dgvCompra.Columns.Count - 1
        End If

        If idxSubtotal >= 0 Then
            For Each row As DataGridViewRow In dgvCompra.Rows
                If row.Cells(idxSubtotal).Value IsNot Nothing AndAlso Not IsDBNull(row.Cells(idxSubtotal).Value) Then
                    Dim valCell As Decimal = 0D
                    If Decimal.TryParse(row.Cells(idxSubtotal).Value.ToString(), valCell) Then
                        total += valCell
                    End If
                End If
            Next
        End If

        lblTotal.Text = total.ToString("C2")
        lblTotal.Tag = total
    End Sub

    '========================================
    ' 6. ELIMINAR PRODUCTO SELECCIONADO
    '========================================
    Private Sub EliminarProductoSeleccionado()
        If dgvCompra.SelectedRows.Count > 0 Then
            Dim respuesta As DialogResult = MessageBox.Show("¿Desea eliminar el producto seleccionado?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If respuesta = DialogResult.Yes Then
                For Each row As DataGridViewRow In dgvCompra.SelectedRows
                    If Not row.IsNewRow Then
                        dgvCompra.Rows.Remove(row)
                    End If
                Next
                CalcularTotal()

                If dgvCompra.Rows.Count = 0 Then
                    If btnCobrar IsNot Nothing Then btnCobrar.Enabled = False
                    If btnEliminar IsNot Nothing Then btnEliminar.Enabled = False
                End If
            End If
        Else
            MessageBox.Show("Seleccione una fila para borrar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        EliminarProductoSeleccionado()
    End Sub

    Private Sub dgvCompra_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvCompra.KeyDown
        If e.KeyCode = Keys.Delete Then
            EliminarProductoSeleccionado()
        End If
    End Sub

    '========================================
    ' 7. BOTÓN COBRAR / ABRIR VENTANA DE COBRO
    '========================================
    Private Sub btnCobrar_Click(sender As Object, e As EventArgs) Handles btnCobrar.Click
        If dgvCompra.Rows.Count = 0 Then
            MessageBox.Show("No hay productos agregados a la compra.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If cboProveedor.SelectedIndex = -1 OrElse cboProveedor.SelectedValue Is Nothing OrElse String.IsNullOrWhiteSpace(cboProveedor.Text) Then
            MessageBox.Show("No hay un proveedor seleccionado. Por favor, seleccione un proveedor antes de continuar.", "Proveedor Requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboProveedor.Focus()
            Exit Sub
        End If

        Dim totalCompra As Decimal = If(lblTotal.Tag IsNot Nothing, Convert.ToDecimal(lblTotal.Tag), 0D)

        ' Configurar e iniciar la ventana de Cobro compartida para Compras (EsVenta = False)
        Dim frmCobro As New Cobro()
        frmCobro.EsVenta = False
        frmCobro.TotalTransaccion = totalCompra
        frmCobro.IdClienteProveedor = Convert.ToInt32(cboProveedor.SelectedValue)
        frmCobro.IdEmpleado = If(InicioSesion.IdUsuarioActual > 0, InicioSesion.IdUsuarioActual, 1)
        frmCobro.FolioVenta = Convert.ToInt32(lblNumeroCompra.Text)
        frmCobro.NombreCliente = cboProveedor.Text
        frmCobro.ListaProductos = dgvCompra.Rows

        ' Como Cobro.vb ya realiza el guardado completo en la BD, aquí solo limpiamos la pantalla al recibir DialogResult.OK
        If frmCobro.ShowDialog() = DialogResult.OK Then
            dgvCompra.Rows.Clear()
            CalcularTotal()
            ActualizarNumeroCompra()
            CargarProveedor()

            If btnCobrar IsNot Nothing Then btnCobrar.Enabled = False
            If btnEliminar IsNot Nothing Then btnEliminar.Enabled = False
        End If
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
    End Sub

End Class