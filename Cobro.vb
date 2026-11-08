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
        ' Respetar las opciones agregadas desde el diseñador ("Efectivo", "Tarjeta de crédito")
        If CB_Pago IsNot Nothing Then
            If CB_Pago.Items.Count = 0 Then
                CB_Pago.Items.Add("Efectivo")
                CB_Pago.Items.Add("Tarjeta de crédito")
            End If
            CB_Pago.SelectedIndex = -1 ' Sin selección inicial obligatoria
        End If
    End Sub

    ' Calcular cambio automáticamente al escribir en TXT_DR
    Private Sub TXT_DR_TextChanged(sender As Object, e As EventArgs) Handles TXT_DR.TextChanged
        Dim dineroRecibido As Decimal = 0D
        If Decimal.TryParse(TXT_DR.Text, dineroRecibido) Then
            Dim cambio As Decimal = dineroRecibido - TotalPagar
            TXT_CAMBIO.Text = If(cambio >= 0, cambio.ToString("0.00"), "0.00")
        Else
            TXT_CAMBIO.Text = "0.00"
        End If
    End Sub

    ' Botón Confirmar Pago
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' 1. Validar Dinero Recibido
        Dim dineroRecibido As Decimal = 0D
        If Not Decimal.TryParse(TXT_DR.Text, dineroRecibido) OrElse dineroRecibido < TotalPagar Then
            MessageBox.Show("El dinero recibido es inválido o insuficiente.", "Error de Pago", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            TXT_DR.Focus()
            Exit Sub
        End If

        ' 2. Validar Selección del Método de Pago Obligatorio
        If CB_Pago.SelectedIndex = -1 AndAlso String.IsNullOrWhiteSpace(CB_Pago.Text) Then
            MessageBox.Show("Por favor seleccione un método de pago.", "Método Requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            CB_Pago.Focus()
            Exit Sub
        End If

        Dim textoMetodoPago As String = CB_Pago.Text.Trim()

        ' 3. Procesar y guardar en la base de datos
        If TipoTransaccion.Equals("Venta", StringComparison.OrdinalIgnoreCase) Then
            GuardarVenta(textoMetodoPago)
        Else
            GuardarCompra(textoMetodoPago)
        End If
    End Sub

    ' Función auxiliar universal para extraer los detalles de cualquier origen (DataTable o Grid)
    Private Function ExtraerDatosDetalle() As List(Of Tuple(Of Integer, Decimal, Decimal, Decimal, String))
        Dim lista As New List(Of Tuple(Of Integer, Decimal, Decimal, Decimal, String))()

        If DetalleTransaccion Is Nothing Then Return lista

        If TypeOf DetalleTransaccion Is DataGridViewRowCollection OrElse TypeOf DetalleTransaccion Is IEnumerable(Of DataGridViewRow) Then
            Dim filas As IEnumerable = CType(DetalleTransaccion, IEnumerable)
            For Each r In filas
                If TypeOf r Is DataGridViewRow Then
                    Dim row As DataGridViewRow = CType(r, DataGridViewRow)
                    If Not row.IsNewRow Then
                        Dim idProd As Integer = Convert.ToInt32(ObtenerValorFila(row, "Código", "Id_prod"))
                        Dim cant As Decimal = Convert.ToDecimal(ObtenerValorFila(row, "Cantidad", "Cantidad_VP", "Cantidad_CP"))
                        Dim prec As Decimal = Convert.ToDecimal(ObtenerValorFila(row, "Precio", "Precio_VP", "CostoUnitario_CP"))
                        Dim subt As Decimal = Convert.ToDecimal(ObtenerValorFila(row, "Subtotal", "Subtotal_VP", "subtotal_CP"))
                        Dim desc As String = ObtenerValorFila(row, "Descripción", "Descripcion_prod")
                        lista.Add(New Tuple(Of Integer, Decimal, Decimal, Decimal, String)(idProd, cant, prec, subt, desc))
                    End If
                End If
            Next
        ElseIf TypeOf DetalleTransaccion Is DataTable Then
            Dim dt As DataTable = CType(DetalleTransaccion, DataTable)
            For Each row As DataRow In dt.Rows
                Dim idProd As Integer = Convert.ToInt32(ObtenerValorDataRow(row, "Código", "Id_prod"))
                Dim cant As Decimal = Convert.ToDecimal(ObtenerValorDataRow(row, "Cantidad", "Cantidad_VP", "Cantidad_CP"))
                Dim prec As Decimal = Convert.ToDecimal(ObtenerValorDataRow(row, "Precio", "Precio_VP", "CostoUnitario_CP"))
                Dim subt As Decimal = Convert.ToDecimal(ObtenerValorDataRow(row, "Subtotal", "Subtotal_VP", "subtotal_CP"))
                Dim desc As String = ObtenerValorDataRow(row, "Descripción", "Descripcion_prod")
                lista.Add(New Tuple(Of Integer, Decimal, Decimal, Decimal, String)(idProd, cant, prec, subt, desc))
            Next
        ElseIf TypeOf DetalleTransaccion Is DataGridView Then
            Dim dgv As DataGridView = CType(DetalleTransaccion, DataGridView)
            For Each row As DataGridViewRow In dgv.Rows
                If Not row.IsNewRow Then
                    Dim idProd As Integer = Convert.ToInt32(ObtenerValorFila(row, "Código", "Id_prod"))
                    Dim cant As Decimal = Convert.ToDecimal(ObtenerValorFila(row, "Cantidad", "Cantidad_VP", "Cantidad_CP"))
                    Dim prec As Decimal = Convert.ToDecimal(ObtenerValorFila(row, "Precio", "Precio_VP", "CostoUnitario_CP"))
                    Dim subt As Decimal = Convert.ToDecimal(ObtenerValorFila(row, "Subtotal", "Subtotal_VP", "subtotal_CP"))
                    Dim desc As String = ObtenerValorFila(row, "Descripción", "Descripcion_prod")
                    lista.Add(New Tuple(Of Integer, Decimal, Decimal, Decimal, String)(idProd, cant, prec, subt, desc))
                End If
            Next
        End If

        Return lista
    End Function

    Private Function ObtenerValorFila(row As DataGridViewRow, ParamArray nombresColumna() As String) As Object
        For Each col In nombresColumna
            If row.DataGridView IsNot Nothing AndAlso row.DataGridView.Columns.Contains(col) AndAlso row.Cells(col).Value IsNot Nothing Then
                Return row.Cells(col).Value
            End If
        Next
        Return 0
    End Function

    Private Function ObtenerValorDataRow(row As DataRow, ParamArray nombresColumna() As String) As Object
        For Each col In nombresColumna
            If row.Table.Columns.Contains(col) AndAlso row(col) IsNot DBNull.Value AndAlso row(col) IsNot Nothing Then
                Return row(col)
            End If
        Next
        Return 0
    End Function

    Private Sub GuardarVenta(metodoPago As String)
        Try
            Using con As OleDbConnection = ObtenerConexion()
                con.Open()
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
                            Dim subtotal = item.Item4

                            Dim queryDet As String = "INSERT INTO Detalle_VP (Id_v, Id_prod, Cantidad_VP, Precio_VP, Subtotal_VP) VALUES (?, ?, ?, ?, ?)"
                            Using cmdDet As New OleDbCommand(queryDet, con, trans)
                                cmdDet.Parameters.Add("?", OleDbType.Integer).Value = idVentaGen
                                cmdDet.Parameters.Add("?", OleDbType.Integer).Value = idProd
                                cmdDet.Parameters.Add("?", OleDbType.Decimal).Value = cantidad
                                cmdDet.Parameters.Add("?", OleDbType.Currency).Value = precio
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
                con.Open()
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
                            Dim subtotal = item.Item4

                            Dim queryDet As String = "INSERT INTO Detalle_CP (ID_com, ID_prod, Cantidad_CP, CostoUnitario_CP, subtotal_CP) VALUES (?, ?, ?, ?, ?)"
                            Using cmdDet As New OleDbCommand(queryDet, con, trans)
                                cmdDet.Parameters.Add("?", OleDbType.Integer).Value = idCompraGen
                                cmdDet.Parameters.Add("?", OleDbType.Integer).Value = idProd
                                cmdDet.Parameters.Add("?", OleDbType.Decimal).Value = cantidad
                                cmdDet.Parameters.Add("?", OleDbType.Currency).Value = costo
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

    Private Sub ImprimirTicket(folio As Integer, metodoPago As String, items As List(Of Tuple(Of Integer, Decimal, Decimal, Decimal, String)))
        Try
            Dim pd As New PrintDocument()
            AddHandler pd.PrintPage, Sub(senderObj, ev)
                                         Dim fuenteTitulo As New Font("Arial", 10, FontStyle.Bold)
                                         Dim fuenteTexto As New Font("Arial", 8, FontStyle.Regular)
                                         Dim fuenteBold As New Font("Arial", 8, FontStyle.Bold)
                                         Dim yPos As Single = 10
                                         Dim posX As Single = 10

                                         ev.Graphics.DrawString("--- TICKET DE " & TipoTransaccion.ToUpper() & " ---", fuenteTitulo, Brushes.Black, posX, yPos)
                                         yPos += 20
                                         ev.Graphics.DrawString("Folio #: " & folio, fuenteBold, Brushes.Black, posX, yPos)
                                         yPos += 15
                                         ev.Graphics.DrawString("Fecha: " & DateTime.Now.ToString("dd/MM/yyyy HH:mm"), fuenteTexto, Brushes.Black, posX, yPos)
                                         yPos += 15
                                         ev.Graphics.DrawString("Método Pago: " & metodoPago, fuenteTexto, Brushes.Black, posX, yPos)
                                         yPos += 20
                                         ev.Graphics.DrawString("------------------------------------------", fuenteTexto, Brushes.Black, posX, yPos)
                                         yPos += 15

                                         For Each item In items
                                             Dim desc = item.Item5
                                             Dim cant = item.Item2
                                             Dim subt = item.Item4.ToString("$#,##0.00")

                                             ev.Graphics.DrawString($"{cant} x {desc}", fuenteTexto, Brushes.Black, posX, yPos)
                                             yPos += 15
                                             ev.Graphics.DrawString($"    Subtotal: {subt}", fuenteTexto, Brushes.Black, posX, yPos)
                                             yPos += 15
                                         Next

                                         yPos += 10
                                         ev.Graphics.DrawString("------------------------------------------", fuenteTexto, Brushes.Black, posX, yPos)
                                         yPos += 15
                                         ev.Graphics.DrawString("TOTAL: " & TotalPagar.ToString("$#,##0.00"), fuenteTitulo, Brushes.Black, posX, yPos)
                                         yPos += 15
                                         ev.Graphics.DrawString("Recibido: $" & TXT_DR.Text, fuenteTexto, Brushes.Black, posX, yPos)
                                         yPos += 15
                                         ev.Graphics.DrawString("Cambio: $" & TXT_CAMBIO.Text, fuenteTexto, Brushes.Black, posX, yPos)
                                         yPos += 25
                                         ev.Graphics.DrawString("¡Gracias por su preferencia!", fuenteBold, Brushes.Black, posX, yPos)
                                     End Sub
            pd.Print()
        Catch ex As Exception
            MessageBox.Show("No se pudo imprimir el ticket: " & ex.Message, "Impresión", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

End Class