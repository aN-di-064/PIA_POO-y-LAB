Imports System.ComponentModel
Imports System.Data.OleDb

Public Class Busqueda_Venta

    ' Atributos para ignorar la serialización en el diseñador de Windows Forms
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property CodigoSeleccionado As String

    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property DescripcionSeleccionada As String

    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property PrecioSeleccionado As Decimal

    Private Sub Busqueda_Venta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Lógica de carga al abrir el buscador
    End Sub

    Private Sub DgvProductos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProductos.CellDoubleClick
        If e.RowIndex >= 0 Then
            Dim fila As DataGridViewRow = dgvProductos.Rows(e.RowIndex)

            ' Coincidir con los campos reales del esquema: Id_prod, Descripcion_prod, Precio_prod
            CodigoSeleccionado = fila.Cells("Id_prod").Value.ToString()
            DescripcionSeleccionada = fila.Cells("Descripcion_prod").Value.ToString()
            PrecioSeleccionado = Convert.ToDecimal(fila.Cells("Precio_prod").Value)

            Me.DialogResult = DialogResult.OK
            Me.Close()
        End If
    End Sub

End Class