Imports System.Drawing.Printing

Public Class Cobro

    Public EsVenta As Boolean
    Public TotalTransaccion As Decimal
    ' Datos adicionales para el ticket (puedes pasarlos desde UC_Ventas)
    Public FolioVenta As String
    Public NombreCliente As String
    Public ListaProductos As DataGridViewRowCollection
    Public DineroRecibido As Decimal
    Public Cambio As Decimal

    Private Sub Cobro_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If EsVenta Then
            Me.Text = "Cobro Venta"
            Button1.Text = "Confirmar"
        Else
            Me.Text = "Cobro Compra"
            Button1.Text = "Confirmar"
        End If

        TXT_TOTAL.Text = TotalTransaccion.ToString("N2")
        TXT_DR.Focus()
    End Sub

    Private Sub TXT_DR_TextChanged(sender As Object, e As EventArgs) Handles TXT_DR.TextChanged
        Dim dineroRecibidoVal As Decimal = 0
        If Decimal.TryParse(TXT_DR.Text, dineroRecibidoVal) Then
            Dim cambioVal As Decimal = dineroRecibidoVal - TotalTransaccion
            TXT_CAMBIO.Text = If(cambioVal >= 0, cambioVal.ToString("N2"), "0.00")
        Else
            TXT_CAMBIO.Text = "0.00"
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim dineroRecibidoVal As Decimal = 0
        If Not Decimal.TryParse(TXT_DR.Text, dineroRecibidoVal) OrElse dineroRecibidoVal < TotalTransaccion Then
            MessageBox.Show("El dinero recibido es inválido o insuficiente.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If ' <--- Aquí se cierra correctamente el If de VB.NET con End If

        ' Guardar valores para el ticket
        DineroRecibido = dineroRecibidoVal
        Decimal.TryParse(TXT_CAMBIO.Text, Cambio)

        ' Si el checkbox de imprimir está marcado
        If CheckBox1.Checked Then
            ImprimirTicketEpson()
        End If

        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    ' --- CONFIGURACIÓN DE IMPRESIÓN PARA EPSON TM-T20II (80 mm) ---
    Private Sub ImprimirTicketEpson()
        Try
            Dim printDoc As New PrintDocument()

            ' Configurar la impresora predeterminada (o puedes especificar el nombre de la Epson)
            ' printDoc.PrinterSettings.PrinterName = "EPSON TM-T20II Receipt"

            AddHandler printDoc.PrintPage, AddressOf Me.Documento_PrintPage
            printDoc.Print()
        Catch ex As Exception
            MessageBox.Show("Error al intentar imprimir el ticket: " & ex.Message, "Error de Impresión", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Documento_PrintPage(sender As Object, e As PrintPageEventArgs)
        ' Configuración de fuentes y coordenadas iniciales para papel de 80mm
        Dim fuenteTitulo As New Font("Consolas", 11, FontStyle.Bold)
        Dim fuenteNormal As New Font("Consolas", 9, FontStyle.Regular)
        Dim fuenteNegrita As New Font("Consolas", 9, FontStyle.Bold)

        Dim x As Single = 10  ' Margen izquierdo
        Dim y As Single = 10  ' Margen superior
        Dim anchoAncho As Single = 270 ' Ancho aproximado para papel de 80mm en puntos

        Dim formatoCentro As New StringFormat() With {.Alignment = StringAlignment.Center}
        Dim formatoDerecha As New StringFormat() With {.Alignment = StringAlignment.Far}
        Dim formatoIzquierda As New StringFormat() With {.Alignment = StringAlignment.Near}

        ' 1. Encabezado del Negocio
        e.Graphics.DrawString("DULCERÍA Y MATERIALES", fuenteTitulo, Brushes.Black, CSng(anchoAncho / 2), y, formatoCentro)
        y += 20
        e.Graphics.DrawString("Ticket de Venta", fuenteNormal, Brushes.Black, CSng(anchoAncho / 2), y, formatoCentro)
        y += 15
        e.Graphics.DrawString("------------------------------------", fuenteNormal, Brushes.Black, x, y)
        y += 15

        ' 2. Datos de la Venta
        e.Graphics.DrawString($"Ticket No: {FolioVenta}", fuenteNormal, Brushes.Black, x, y)
        y += 15
        e.Graphics.DrawString($"Fecha: {DateTime.Now.ToString("dd/MM/yyyy HH:mm")}", fuenteNormal, Brushes.Black, x, y)
        y += 15
        e.Graphics.DrawString($"Cliente: {NombreCliente}", fuenteNormal, Brushes.Black, x, y)
        y += 15
        e.Graphics.DrawString("------------------------------------", fuenteNormal, Brushes.Black, x, y)
        y += 15

        ' 3. Cabecera de la tabla de productos
        e.Graphics.DrawString("Cant  Descripción       P.Unit   Subtotal", fuenteNegrita, Brushes.Black, x, y)
        y += 15
        e.Graphics.DrawString("------------------------------------", fuenteNormal, Brushes.Black, x, y)
        y += 15

        ' 4. Productos en el DataGridView (Pasados desde UC_Ventas)
        If ListaProductos IsNot Nothing Then
            For Each row As DataGridViewRow In ListaProductos
                If row.IsNewRow Then Continue For

                Dim cant As String = row.Cells("Col_Cantidad").Value.ToString()
                Dim desc As String = row.Cells("Col_Descripcion").Value.ToString()
                If desc.Length > 15 Then desc = desc.Substring(0, 15) ' Limitar caracteres para que quepa
                Dim precio As Decimal = Convert.ToDecimal(row.Cells("Col_Precio").Value)
                Dim subtotal As Decimal = Convert.ToDecimal(row.Cells("Col_Importe").Value)

                Dim lineaItem As String = $"{cant.PadLeft(4)} {desc.PadRight(16)} {precio.ToString("N0").PadLeft(5)} {subtotal.ToString("N0").PadLeft(6)}"
                e.Graphics.DrawString(lineaItem, fuenteNormal, Brushes.Black, x, y)
                y += 15
            Next
        End If

        e.Graphics.DrawString("------------------------------------", fuenteNormal, Brushes.Black, x, y)
        y += 15

        ' 5. Totales, Dinero Recibido y Cambio
        e.Graphics.DrawString($"TOTAL: $ {TotalTransaccion.ToString("N2")}", fuenteNegrita, Brushes.Black, x, y)
        y += 18
        e.Graphics.DrawString($"Efectivo Recibido: $ {DineroRecibido.ToString("N2")}", fuenteNormal, Brushes.Black, x, y)
        y += 15
        e.Graphics.DrawString($"Cambio: $ {Cambio.ToString("N2")}", fuenteNormal, Brushes.Black, x, y)
        y += 25

        ' 6. Pie de página
        e.Graphics.DrawString("¡Gracias por su compra!", fuenteNormal, Brushes.Black, CSng(anchoAncho / 2), y, formatoCentro)

        ' Indica que no hay más páginas que imprimir
        e.HasMorePages = False
    End Sub

End Class