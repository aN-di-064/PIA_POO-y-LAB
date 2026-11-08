Imports System.Data.OleDb

Public Class UC_Ventas

    Private Sub UC_Ventas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ObtenerSiguienteIDVenta()
        CargarClientes()
        CalcularTotal()
    End Sub

    ' ========================================
    ' FUNCIONES AUXILIARES DE COLUMNAS (ROBUSTO)
    ' ========================================
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
        ConexionBusqueda()
    End Sub

    Private Sub ConexionBusqueda()
        Dim buscador As New Busqueda_Venta()
        buscador.TipoBusqueda = "PRODUCTO"
        buscador.Tag = "VENTA"

        If buscador.ShowDialog() = DialogResult.OK Then
            Dim codigo As String = buscador.CodigoSeleccionado
            Dim descripcion As String = buscador.DescripcionSeleccionada
            Dim precio As Decimal = buscador.PrecioSeleccionado

            Dim idProdInt As Integer = 0
            Integer.TryParse(codigo, idProdInt)

            Dim idxCodigo As Integer = ObtenerIndiceColumna(DataGridView1, "Col_Código", "Codigo", "ID_prod")
            Dim idxCant As Integer = ObtenerIndiceColumna(DataGridView1, "Col_Cantidad", "Cantidad")
            Dim idxDesc As Integer = ObtenerIndiceColumna(DataGridView1, "Col_Descuento", "Descuento")
            Dim idxImporte As Integer = ObtenerIndiceColumna(DataGridView1, "Col_Importe", "Subtotal")

            ' Verificar si ya está en la lista para incrementar la cantidad
            Dim yaExiste As Boolean = False
            If idxCodigo >= 0 Then
                For Each row As DataGridViewRow In DataGridView1.Rows
                    If row.Cells(idxCodigo).Value IsNot Nothing AndAlso row.Cells(idxCodigo).Value.ToString() = codigo Then
                        Dim cantActual As Decimal = Convert.ToDecimal(row.Cells(idxCant).Value)
                        Dim pctDescuento As Decimal = Convert.ToDecimal(row.Cells(idxDesc).Value)

                        Dim nuevaCant As Decimal = cantActual + 1D
                        Dim importeBruto As Decimal = nuevaCant * precio
                        Dim montoDescuento As Decimal = importeBruto * (pctDescuento / 100D)

                        row.Cells(idxCant).Value = nuevaCant
                        If idxImporte >= 0 Then
                            row.Cells(idxImporte).Value = importeBruto - montoDescuento
                        End If
                        yaExiste = True
                        Exit For
                    End If
                Next
            End If

            ' Si no existe, agregarlo como nuevo renglón
            If Not yaExiste Then
                If DataGridView1.Columns.Count >= 6 Then
                    DataGridView1.Rows.Add(idProdInt, codigo, descripcion, precio, 0.00D, precio)
                Else
                    DataGridView1.Rows.Add(1D, codigo, descripcion, precio, 0.00D, precio)
                End If
            End If

            CalcularTotal()
        End If
    End Sub

    ' 4. Recalcular subtotal al editar la cantidad o el % de descuento
    Private Sub DataGridView1_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellValueChanged
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim cantidad As Decimal = 0D
            Dim precio As Decimal = 0D
            Dim pctDescuento As Decimal = 0D

            Dim idxCant As Integer = ObtenerIndiceColumna(DataGridView1, "Col_Cantidad", "Cantidad")
            Dim idxPrecio As Integer = ObtenerIndiceColumna(DataGridView1, "Col_Precio", "Precio")
            Dim idxDesc As Integer = ObtenerIndiceColumna(DataGridView1, "Col_Descuento", "Descuento")
            Dim idxImporte As Integer = ObtenerIndiceColumna(DataGridView1, "Col_Importe", "Subtotal")

            If idxCant >= 0 Then Decimal.TryParse(Convert.ToString(row.Cells(idxCant).Value), cantidad)
            If idxPrecio >= 0 Then Decimal.TryParse(Convert.ToString(row.Cells(idxPrecio).Value), precio)
            If idxDesc >= 0 Then Decimal.TryParse(Convert.ToString(row.Cells(idxDesc).Value), pctDescuento)

            Dim bruto As Decimal = cantidad * precio
            Dim descuentoCalculado As Decimal = bruto * (pctDescuento / 100D)

            If idxImporte >= 0 Then
                row.Cells(idxImporte).Value = bruto - descuentoCalculado
            End If

            CalcularTotal()
        End If
    End Sub

    ' 5. Recalcular el total acumulado
    Private Sub CalcularTotal()
        Dim total As Decimal = 0D
        Dim idxImporte As Integer = ObtenerIndiceColumna(DataGridView1, "Col_Importe", "Subtotal")

        If idxImporte < 0 OrElse (DataGridView1.Columns.Count > 0 AndAlso idxImporte >= DataGridView1.Columns.Count) Then
            idxImporte = DataGridView1.Columns.Count - 1
        End If

        If idxImporte >= 0 Then
            For Each row As DataGridViewRow In DataGridView1.Rows
                If row.Cells(idxImporte).Value IsNot Nothing AndAlso Not IsDBNull(row.Cells(idxImporte).Value) Then
                    Dim valCell As Decimal = 0D
                    If Decimal.TryParse(row.Cells(idxImporte).Value.ToString(), valCell) Then
                        total += valCell
                    End If
                End If
            Next
        End If

        Label4.Text = total.ToString("C2")
        Label4.Tag = total
    End Sub

    ' Método auxiliar para eliminar producto seleccionado
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

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click, BTN_BORRAR.Click
        EliminarProductoSeleccionado()
    End Sub

    Private Sub DataGridView1_KeyDown(sender As Object, e As KeyEventArgs) Handles DataGridView1.KeyDown
        If e.KeyCode = Keys.Delete Then
            EliminarProductoSeleccionado()
        End If
    End Sub

    ' 7. Botón "Cobrar" (Valida caja y abre Cobro.vb, el cual realiza el guardado atómico)
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click, Button1.Click
        If DataGridView1.Rows.Count = 0 Then
            MessageBox.Show("No hay productos agregados a la venta.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If CB_Cliente.Items.Count = 0 OrElse
           CB_Cliente.SelectedIndex = -1 OrElse
           CB_Cliente.SelectedValue Is Nothing OrElse
           String.IsNullOrWhiteSpace(CB_Cliente.Text) Then

            MessageBox.Show("No hay un cliente seleccionado. Por favor, seleccione o registre un cliente antes de continuar con la venta.", "Cliente Requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            CB_Cliente.Focus()
            Exit Sub
        End If

        ' --- VALIDACIÓN PREVIA DE CAJA ABIERTA ---
        Dim idCorteInt As Integer = 1
        Try
            Using con As OleDbConnection = ObtenerConexion()
                Dim queryCorte As String = "SELECT TOP 1 Id_cor FROM Corte WHERE FechaCierre_cor IS NULL ORDER BY Id_cor DESC"
                Using cmdCorte As New OleDbCommand(queryCorte, con)
                    Dim idCorteActivo = cmdCorte.ExecuteScalar()
                    If idCorteActivo Is Nothing OrElse idCorteActivo Is DBNull.Value Then
                        MessageBox.Show("No hay ninguna caja abierta actualmente. Por favor, realice la Apertura de Caja primero en el módulo de Corte.", "Caja Cerrada", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Sub
                    End If
                    idCorteInt = Convert.ToInt32(idCorteActivo)
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al comprobar el estado de la caja: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

        Dim totalVenta As Decimal = If(Label4.Tag IsNot Nothing, Convert.ToDecimal(Label4.Tag), 0D)

        ' Configurar e iniciar la ventana de Cobro compartida
        Dim frmCobro As New Cobro()
        frmCobro.EsVenta = True
        frmCobro.TotalTransaccion = totalVenta
        frmCobro.IdClienteProveedor = Convert.ToInt32(CB_Cliente.SelectedValue)
        frmCobro.IdEmpleado = If(InicioSesion.IdUsuarioActual > 0, InicioSesion.IdUsuarioActual, 1)
        frmCobro.IdCorte = idCorteInt
        frmCobro.FolioVenta = Convert.ToInt32(LBL_IDCOMPRA.Text)
        frmCobro.NombreCliente = CB_Cliente.Text
        frmCobro.ListaProductos = DataGridView1.Rows

        ' Como Cobro.vb guarda la venta, aquí solo limpiamos la pantalla tras el OK
        If frmCobro.ShowDialog() = DialogResult.OK Then
            DataGridView1.Rows.Clear()
            CalcularTotal()
            ObtenerSiguienteIDVenta()
            CargarClientes()
        End If
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
    End Sub

End Class