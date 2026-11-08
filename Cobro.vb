Imports System.ComponentModel
Imports System.Data.OleDb
Imports System.Drawing.Printing

Public Class Cobro

    ' --- PROPIEDADES PRINCIPALES ---
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property TotalPagar As Decimal = 0D

    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property IdClienteProveedor As Integer = 1

    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property IdEmpleado As Integer = 1

    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property IdCorte As Integer = 1

    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property TipoTransaccion As String = "Venta" ' Puede ser "Venta" o "Compra"

    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property DetalleTransaccion As Object ' Acepta DataTable, DataGridViewRowCollection o DataGridView

    ' --- PROPIEDADES DE COMPATIBILIDAD CON UC_Ventas Y UC_Compras ---
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property EsVenta As Boolean
        Get
            Return TipoTransaccion.Equals("Venta", StringComparison.OrdinalIgnoreCase)
        End Get
        Set(value As Boolean)
            TipoTransaccion = If(value, "Venta", "Compra")
        End Set
    End Property

    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property TotalTransaccion As Decimal
        Get
            Return TotalPagar
        End Get
        Set(value As Decimal)
            TotalPagar = value
        End Set
    End Property

    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property FolioVenta As Integer = 0

    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property NombreCliente As String = ""

    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property ListaProductos As Object
        Get
            Return DetalleTransaccion
        End Get
        Set(value As Object)
            DetalleTransaccion = value
        End Set
    End Property
    ' ------------------------------------------------------------------------------------

    Private Sub Cobro_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TXT_TOTAL.Text = TotalPagar.ToString("0.00")
        TXT_DR.Text = ""
        TXT_CAMBIO.Text = "0.00"

        CargarMetodosPago()
        Me.Text = $"Cobro de {TipoTransaccion}"
    End Sub

    Private Sub CargarMetodosPago()
        If CB_Pago IsNot Nothing Then
            If CB_Pago.Items.Count = 0 Then
                CB_Pago.Items.Add("Efectivo")
                CB_Pago.Items.Add("Tarjeta de crédito")
            End If
            CB_Pago.SelectedIndex = -1
        End If
    End Sub

    Private Sub TXT_DR_TextChanged(sender As Object, e As EventArgs) Handles TXT_DR.TextChanged
        Dim dineroRecibido As Decimal = 0D
        If Decimal.TryParse(TXT_DR.Text, dineroRecibido) Then
            Dim cambio As Decimal = dineroRecibido - TotalPagar
            TXT_CAMBIO.Text = If(cambio >= 0, cambio.ToString("0.00"), "0.00")
        Else
            TXT_CAMBIO.Text = "0.00"
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim dineroRecibido As Decimal = 0D
        If Not Decimal.TryParse(TXT_DR.Text, dineroRecibido) OrElse dineroRecibido < TotalPagar Then
            MessageBox.Show("El dinero recibido es inválido o insuficiente.", "Error de Pago", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            TXT_DR.Focus()
            Exit Sub
        End If

        If CB_Pago.SelectedIndex = -1 AndAlso String.IsNullOrWhiteSpace(CB_Pago.Text) Then
            MessageBox.Show("Por favor seleccione un método de pago.", "Método Requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            CB_Pago.Focus()
            Exit Sub
        End If

        Dim textoMetodoPago As String = CB_Pago.Text.Trim()

        If TipoTransaccion.Equals("Venta", StringComparison.OrdinalIgnoreCase) Then
            GuardarVenta(textoMetodoPago)
        Else
            GuardarCompra(textoMetodoPago)
        End If
    End Sub

    ' Extrae: (IdProd, Cantidad, Precio/Costo, Descuento, Subtotal, Descripcion)
    Private Function ExtraerDatosDetalle() As List(Of Tuple(Of Integer, Decimal, Decimal, Decimal, Decimal, String))
        Dim lista As New List(Of Tuple(Of Integer, Decimal, Decimal, Decimal, Decimal, String))()

        If DetalleTransaccion Is Nothing Then Return lista

        If TypeOf DetalleTransaccion Is DataGridViewRowCollection OrElse TypeOf DetalleTransaccion Is IEnumerable(Of DataGridViewRow) Then
            Dim filas As IEnumerable = CType(DetalleTransaccion, IEnumerable)
            For Each r In filas
                If TypeOf r Is DataGridViewRow Then
                    Dim row As DataGridViewRow = CType(r, DataGridViewRow)
                    If Not row.IsNewRow Then
                        Dim idProd As Integer = ExtraerIdEnteroFila(row)
                        Dim cant As Decimal = ExtraerDecimalFila(row, {"Cantidad", "Cantidad_VP", "Cantidad_CP", "cant"}, 1D)
                        Dim prec As Decimal = ExtraerDecimalFila(row, {"Precio", "Precio_VP", "CostoUnitario_CP", "Precio unitario"}, 0D)
                        Dim desc As Decimal = ExtraerDecimalFila(row, {"Descuento", "Descuento_VP", "Descuento_CP"}, 0D)
                        Dim subt As Decimal = ExtraerDecimalFila(row, {"Subtotal", "Subtotal_VP", "subtotal_CP"}, 0D)
                        Dim nombreDesc As String = ExtraerTextoFila(row, {"Descripción", "Descripcion", "Descripcion_prod", "Nombre"})
                        lista.Add(New Tuple(Of Integer, Decimal, Decimal, Decimal, Decimal, String)(idProd, cant, prec, desc, subt, nombreDesc))
                    End If
                End If
            Next
        ElseIf TypeOf DetalleTransaccion Is DataTable Then
            Dim dt As DataTable = CType(DetalleTransaccion, DataTable)
            For Each row As DataRow In dt.Rows
                Dim idProd As Integer = ExtraerIdEnteroDataRow(row)
                Dim cant As Decimal = ExtraerDecimalDataRow(row, {"Cantidad", "Cantidad_VP", "Cantidad_CP"}, 1D)
                Dim prec As Decimal = ExtraerDecimalDataRow(row, {"Precio", "Precio_VP", "CostoUnitario_CP"}, 0D)
                Dim desc As Decimal = ExtraerDecimalDataRow(row, {"Descuento", "Descuento_VP", "Descuento_CP"}, 0D)
                Dim subt As Decimal = ExtraerDecimalDataRow(row, {"Subtotal", "Subtotal_VP", "subtotal_CP"}, 0D)
                Dim nombreDesc As String = ExtraerTextoDataRow(row, {"Descripción", "Descripcion", "Descripcion_prod"})
                lista.Add(New Tuple(Of Integer, Decimal, Decimal, Decimal, Decimal, String)(idProd, cant, prec, desc, subt, nombreDesc))
            Next
        ElseIf TypeOf DetalleTransaccion Is DataGridView Then
            Dim dgv As DataGridView = CType(DetalleTransaccion, DataGridView)
            For Each row As DataGridViewRow In dgv.Rows
                If Not row.IsNewRow Then
                    Dim idProd As Integer = ExtraerIdEnteroFila(row)
                    Dim cant As Decimal = ExtraerDecimalFila(row, {"Cantidad", "Cantidad_VP", "Cantidad_CP", "cant"}, 1D)
                    Dim prec As Decimal = ExtraerDecimalFila(row, {"Precio", "Precio_VP", "CostoUnitario_CP", "Precio unitario"}, 0D)
                    Dim desc As Decimal = ExtraerDecimalFila(row, {"Descuento", "Descuento_VP", "Descuento_CP"}, 0D)
                    Dim subt As Decimal = ExtraerDecimalFila(row, {"Subtotal", "Subtotal_VP", "subtotal_CP"}, 0D)
                    Dim nombreDesc As String = ExtraerTextoFila(row, {"Descripción", "Descripcion", "Descripcion_prod", "Nombre"})
                    lista.Add(New Tuple(Of Integer, Decimal, Decimal, Decimal, Decimal, String)(idProd, cant, prec, desc, subt, nombreDesc))
                End If
            Next
        End If

        Return lista
    End Function

    Private Function ExtraerIdEnteroFila(row As DataGridViewRow) As Integer
        Dim nombresId As String() = {"Código", "Codigo", "Id_prod", "ID", "ID_Producto", "colCodigo", "Id"}
        If row.DataGridView IsNot Nothing Then
            For Each col In nombresId
                For Each dgvCol As DataGridViewColumn In row.DataGridView.Columns
                    If dgvCol.Name.Equals(col, StringComparison.OrdinalIgnoreCase) OrElse dgvCol.HeaderText.Equals(col, StringComparison.OrdinalIgnoreCase) Then
                        Dim val = row.Cells(dgvCol.Index).Value
                        Dim parsedId As Integer
                        If val IsNot Nothing AndAlso Integer.TryParse(val.ToString(), parsedId) AndAlso parsedId > 0 Then
                            Return parsedId
                        End If
                    End If
                Next
            Next
        End If

        For Each cell As DataGridViewCell In row.Cells
            Dim headerText As String = cell.OwningColumn.HeaderText.ToLower()
            If headerText.Contains("cód") OrElse headerText.Contains("cod") OrElse headerText.Contains("id") Then
                Dim valStr As String = cell.Value?.ToString().Trim()
                Dim idResult As Integer
                If Integer.TryParse(valStr, idResult) AndAlso idResult > 0 Then
                    Return idResult
                End If
            End If
        Next

        For Each cell As DataGridViewCell In row.Cells
            If cell.Value IsNot Nothing AndAlso Not IsDBNull(cell.Value) Then
                Dim valStr As String = cell.Value.ToString().Trim()
                Dim idResult As Integer
                If Integer.TryParse(valStr, idResult) AndAlso idResult > 0 Then
                    Return idResult
                End If
            End If
        Next
        Return 1
    End Function

    Private Function ExtraerDecimalFila(row As DataGridViewRow, nombresColumna() As String, valorDefecto As Decimal) As Decimal
        If row.DataGridView IsNot Nothing Then
            For Each col In nombresColumna
                For Each dgvCol As DataGridViewColumn In row.DataGridView.Columns
                    If dgvCol.Name.Equals(col, StringComparison.OrdinalIgnoreCase) OrElse dgvCol.HeaderText.Equals(col, StringComparison.OrdinalIgnoreCase) Then
                        Dim val = row.Cells(dgvCol.Index).Value
                        Dim res As Decimal
                        If val IsNot Nothing AndAlso Decimal.TryParse(val.ToString(), res) Then
                            Return res
                        End If
                    End If
                Next
            Next
        End If
        Return valorDefecto
    End Function

    Private Function ExtraerTextoFila(row As DataGridViewRow, nombresColumna() As String) As String
        If row.DataGridView IsNot Nothing Then
            For Each col In nombresColumna
                For Each dgvCol As DataGridViewColumn In row.DataGridView.Columns
                    If dgvCol.Name.Equals(col, StringComparison.OrdinalIgnoreCase) OrElse dgvCol.HeaderText.Equals(col, StringComparison.OrdinalIgnoreCase) Then
                        Dim val = row.Cells(dgvCol.Index).Value
                        If val IsNot Nothing AndAlso Not IsDBNull(val) Then
                            Return val.ToString()
                        End If
                    End If
                Next
            Next
        End If

        For Each cell As DataGridViewCell In row.Cells
            If cell.Value IsNot Nothing AndAlso Not IsDBNull(cell.Value) Then
                Dim strVal As String = cell.Value.ToString()
                Dim dummyInt As Integer
                Dim dummyDec As Decimal
                If Not Integer.TryParse(strVal, dummyInt) AndAlso Not Decimal.TryParse(strVal, dummyDec) Then
                    Return strVal
                End If
            End If
        Next
        Return ""
    End Function

    Private Function ExtraerIdEnteroDataRow(row As DataRow) As Integer
        Dim nombresId As String() = {"Id_prod", "ID", "Código", "Codigo", "ID_Producto", "Id"}
        For Each col In nombresId
            If row.Table.Columns.Contains(col) AndAlso Not IsDBNull(row(col)) Then
                Dim res As Integer
                If Integer.TryParse(row(col).ToString(), res) AndAlso res > 0 Then Return res
            End If
        Next
        Return 1
    End Function

    Private Function ExtraerDecimalDataRow(row As DataRow, nombresColumna() As String, valorDefecto As Decimal) As Decimal
        For Each col In nombresColumna
            If row.Table.Columns.Contains(col) AndAlso Not IsDBNull(row(col)) Then
                Dim res As Decimal
                If Decimal.TryParse(row(col).ToString(), res) Then Return res
            End If
        Next
        Return valorDefecto
    End Function

    Private Function ExtraerTextoDataRow(row As DataRow, nombresColumna() As String) As String
        For Each col In nombresColumna
            If row.Table.Columns.Contains(col) AndAlso Not IsDBNull(row(col)) Then Return row(col).ToString()
        Next
        Return ""
    End Function

    Private Function ObtenerNombreEmpleado() As String
        Try
            Using con As OleDbConnection = ObtenerConexion()
                Dim cmd As New OleDbCommand("SELECT Nombre_emp FROM Empleado WHERE Id_emp = ?", con)
                cmd.Parameters.Add("?", OleDbType.Integer).Value = IdEmpleado
                Dim res = cmd.ExecuteScalar()
                If res IsNot Nothing AndAlso res IsNot DBNull.Value Then Return res.ToString()
            End Using
        Catch ex As Exception
        End Try
        Return "Sistema"
    End Function

    Private Sub GuardarVenta(metodoPago As String)
        Try
            Using con As OleDbConnection = ObtenerConexion()
                Using trans As OleDbTransaction = con.BeginTransaction()
                    Try
                        Dim queryVenta As String = "INSERT INTO Venta (fecha_v, Id_cli, Id_emp, Id_cor, total_v, MetodoPago_v) VALUES (?, ?, ?, ?, ?, ?)"
                        Dim idVentaGen As Integer = 0

                        Using cmdVenta As New OleDbCommand(queryVenta, con, trans)
                            cmdVenta.Parameters.Add("?", OleDbType.Date).Value = DateTime.Now
                            cmdVenta.Parameters.Add("?", OleDbType.Integer).Value = IdClienteProveedor
                            cmdVenta.Parameters.Add("?", OleDbType.Integer).Value = IdEmpleado
                            cmdVenta.Parameters.Add("?", OleDbType.Integer).Value = IdCorte
                            cmdVenta.Parameters.Add("?", OleDbType.Currency).Value = TotalPagar
                            cmdVenta.Parameters.Add("?", OleDbType.VarChar).Value = metodoPago
                            cmdVenta.ExecuteNonQuery()

                            cmdVenta.CommandText = "SELECT @@IDENTITY"
                            idVentaGen = Convert.ToInt32(cmdVenta.ExecuteScalar())
                        End Using

                        Dim items = ExtraerDatosDetalle()
                        For Each item In items
                            Dim idProd = item.Item1
                            Dim cantidad = item.Item2
                            Dim precio = item.Item3
                            Dim descVal = item.Item4
                            Dim subtotal = item.Item5

                            Dim queryDet As String = "INSERT INTO Detalle_VP (Id_v, Id_prod, Cantidad_VP, Precio_VP, Descuento_VP, Subtotal_VP) VALUES (?, ?, ?, ?, ?, ?)"
                            Using cmdDet As New OleDbCommand(queryDet, con, trans)
                                cmdDet.Parameters.Add("?", OleDbType.Integer).Value = idVentaGen
                                cmdDet.Parameters.Add("?", OleDbType.Integer).Value = idProd
                                cmdDet.Parameters.Add("?", OleDbType.Decimal).Value = cantidad
                                cmdDet.Parameters.Add("?", OleDbType.Currency).Value = precio
                                cmdDet.Parameters.Add("?", OleDbType.Currency).Value = descVal
                                cmdDet.Parameters.Add("?", OleDbType.Currency).Value = subtotal
                                cmdDet.ExecuteNonQuery()
                            End Using

                            Dim queryStock As String = "UPDATE Producto SET Existencias = Existencias - ? WHERE Id_prod = ?"
                            Using cmdStock As New OleDbCommand(queryStock, con, trans)
                                cmdStock.Parameters.Add("?", OleDbType.Decimal).Value = cantidad
                                cmdStock.Parameters.Add("?", OleDbType.Integer).Value = idProd
                                cmdStock.ExecuteNonQuery()
                            End Using
                        Next

                        trans.Commit()

                        If CheckBox1 IsNot Nothing AndAlso CheckBox1.Checked Then
                            ImprimirTicket(idVentaGen, metodoPago, items)
                        End If

                        MessageBox.Show("¡Venta registrada exitosamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        DialogResult = DialogResult.OK
                        Close()

                    Catch ex As Exception
                        trans.Rollback()
                        Throw
                    End Try
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al registrar la venta: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub GuardarCompra(metodoPago As String)
        Try
            Using con As OleDbConnection = ObtenerConexion()
                Using trans As OleDbTransaction = con.BeginTransaction()
                    Try
                        Dim queryCompra As String = "INSERT INTO Compras (Fecha_com, ID_prov, ID_emp, total_com, MetodoPago_com) VALUES (?, ?, ?, ?, ?)"
                        Dim idCompraGen As Integer = 0

                        Using cmdComp As New OleDbCommand(queryCompra, con, trans)
                            cmdComp.Parameters.Add("?", OleDbType.Date).Value = DateTime.Now
                            cmdComp.Parameters.Add("?", OleDbType.Integer).Value = IdClienteProveedor
                            cmdComp.Parameters.Add("?", OleDbType.Integer).Value = IdEmpleado
                            cmdComp.Parameters.Add("?", OleDbType.Currency).Value = TotalPagar
                            cmdComp.Parameters.Add("?", OleDbType.VarChar).Value = metodoPago
                            cmdComp.ExecuteNonQuery()

                            cmdComp.CommandText = "SELECT @@IDENTITY"
                            idCompraGen = Convert.ToInt32(cmdComp.ExecuteScalar())
                        End Using

                        Dim items = ExtraerDatosDetalle()
                        For Each item In items
                            Dim idProd = item.Item1
                            Dim cantidad = item.Item2
                            Dim costo = item.Item3
                            Dim descVal = item.Item4
                            Dim subtotal = item.Item5

                            Dim queryDet As String = "INSERT INTO Detalle_CP (ID_com, ID_prod, Cantidad_CP, CostoUnitario_CP, Descuento_CP, subtotal_CP) VALUES (?, ?, ?, ?, ?, ?)"
                            Using cmdDet As New OleDbCommand(queryDet, con, trans)
                                cmdDet.Parameters.Add("?", OleDbType.Integer).Value = idCompraGen
                                cmdDet.Parameters.Add("?", OleDbType.Integer).Value = idProd
                                cmdDet.Parameters.Add("?", OleDbType.Decimal).Value = cantidad
                                cmdDet.Parameters.Add("?", OleDbType.Currency).Value = costo
                                cmdDet.Parameters.Add("?", OleDbType.Currency).Value = descVal
                                cmdDet.Parameters.Add("?", OleDbType.Currency).Value = subtotal
                                cmdDet.ExecuteNonQuery()
                            End Using

                            Dim queryStock As String = "UPDATE Producto SET Existencias = Existencias + ? WHERE Id_prod = ?"
                            Using cmdStock As New OleDbCommand(queryStock, con, trans)
                                cmdStock.Parameters.Add("?", OleDbType.Decimal).Value = cantidad
                                cmdStock.Parameters.Add("?", OleDbType.Integer).Value = idProd
                                cmdStock.ExecuteNonQuery()
                            End Using
                        Next

                        trans.Commit()

                        If CheckBox1 IsNot Nothing AndAlso CheckBox1.Checked Then
                            ImprimirTicket(idCompraGen, metodoPago, items)
                        End If

                        MessageBox.Show("¡Compra registrada exitosamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        DialogResult = DialogResult.OK
                        Close()

                    Catch ex As Exception
                        trans.Rollback()
                        Throw
                    End Try
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al registrar la compra: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ImprimirTicket(folio As Integer, metodoPago As String, items As List(Of Tuple(Of Integer, Decimal, Decimal, Decimal, Decimal, String)))
        Try
            Dim nombreEmp As String = ObtenerNombreEmpleado()
            Dim tipoTx As String = TipoTransaccion.ToUpper()
            Dim etiquetaPersona As String = If(EsVenta, "Cliente: ", "Proveedor: ")

            Dim pd As New PrintDocument()
            AddHandler pd.PrintPage, Sub(senderObj, ev)
                                         Dim fTitulo As New Font("Arial", 10, FontStyle.Bold)
                                         Dim fSub As New Font("Arial", 8, FontStyle.Bold)
                                         Dim fTexto As New Font("Arial", 8, FontStyle.Regular)
                                         Dim yPos As Single = 10
                                         Dim posX As Single = 10

                                         ' Datos del Negocio
                                         ev.Graphics.DrawString("HELADOS REGIA", fTitulo, Brushes.Black, posX, yPos)
                                         yPos += 18
                                         ev.Graphics.DrawString("Av. Gaspar Castaño 360,", fTexto, Brushes.Black, posX, yPos)
                                         yPos += 12
                                         ev.Graphics.DrawString("66648 Cdad. Apodaca, N.L.", fTexto, Brushes.Black, posX, yPos)
                                         yPos += 18

                                         ' Tipo de Transacción y Folio
                                         ev.Graphics.DrawString($"--- TICKET DE {tipoTx} ---", fSub, Brushes.Black, posX, yPos)
                                         yPos += 15
                                         ev.Graphics.DrawString($"Folio #: {folio}", fTexto, Brushes.Black, posX, yPos)
                                         yPos += 12
                                         ev.Graphics.DrawString($"Fecha: {DateTime.Now:dd/MM/yyyy HH:mm}", fTexto, Brushes.Black, posX, yPos)
                                         yPos += 12
                                         ev.Graphics.DrawString($"{etiquetaPersona}{NombreCliente}", fTexto, Brushes.Black, posX, yPos)
                                         yPos += 12
                                         ev.Graphics.DrawString($"Atendió: {nombreEmp}", fTexto, Brushes.Black, posX, yPos)
                                         yPos += 12
                                         ev.Graphics.DrawString($"Método Pago: {metodoPago}", fTexto, Brushes.Black, posX, yPos)
                                         yPos += 15
                                         ev.Graphics.DrawString("------------------------------------------", fTexto, Brushes.Black, posX, yPos)
                                         yPos += 15

                                         ' Detalle de Productos
                                         For Each item In items
                                             Dim cant = item.Item2
                                             Dim descProd = item.Item6
                                             Dim descuentoVal = item.Item4
                                             Dim subt = item.Item5

                                             ev.Graphics.DrawString($"{cant} x {descProd}", fTexto, Brushes.Black, posX, yPos)
                                             yPos += 13

                                             If descuentoVal > 0 Then
                                                 ev.Graphics.DrawString($"    Descuento: {descuentoVal.ToString("$#,##0.00")}", fTexto, Brushes.Black, posX, yPos)
                                                 yPos += 13
                                             End If

                                             ev.Graphics.DrawString($"    Subtotal: {subt.ToString("$#,##0.00")}", fTexto, Brushes.Black, posX, yPos)
                                             yPos += 15
                                         Next

                                         ev.Graphics.DrawString("------------------------------------------", fTexto, Brushes.Black, posX, yPos)
                                         yPos += 15

                                         ' Totales y Pagos
                                         ev.Graphics.DrawString($"TOTAL: {TotalPagar.ToString("$#,##0.00")}", fSub, Brushes.Black, posX, yPos)
                                         yPos += 15
                                         ev.Graphics.DrawString($"Dinero Recibido: ${TXT_DR.Text}", fTexto, Brushes.Black, posX, yPos)
                                         yPos += 12
                                         ev.Graphics.DrawString($"Cambio: ${TXT_CAMBIO.Text}", fTexto, Brushes.Black, posX, yPos)
                                         yPos += 22

                                         ' Mensaje de Agradecimiento
                                         ev.Graphics.DrawString("¡Gracias por su compra!", fSub, Brushes.Black, posX, yPos)
                                     End Sub
            pd.Print()
        Catch ex As Exception
            MessageBox.Show("No se pudo imprimir el ticket: " & ex.Message, "Impresión", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

End Class