Imports System.ComponentModel

Public Class RangoFechas

    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property FechaInicio As DateTime

    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property FechaFin As DateTime

    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property TipoConsulta As String = "Ventas"

    Private Sub RangoFechas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DateTimePicker1.Value = DateTime.Now
        DateTimePicker2.Value = DateTime.Now

        ' Si el ComboBox del diseñador está vacío, agregar las opciones en plural
        If CB_TIPOCONSULTA.Items.Count = 0 Then
            CB_TIPOCONSULTA.Items.Clear()
            CB_TIPOCONSULTA.Items.Add("Ventas")
            CB_TIPOCONSULTA.Items.Add("Compras")
        End If

        If CB_TIPOCONSULTA.SelectedIndex = -1 Then
            CB_TIPOCONSULTA.SelectedIndex = 0 ' Selecciona "Ventas" por defecto
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If DateTimePicker1.Value.Date > DateTimePicker2.Value.Date Then
            MessageBox.Show("La fecha de inicio no puede ser posterior a la fecha de fin.",
                            "Rango Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If CB_TIPOCONSULTA.SelectedIndex = -1 Then
            MessageBox.Show("Por favor seleccione si desea consultar Ventas o Compras.",
                            "Opción Requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            CB_TIPOCONSULTA.Focus()
            Exit Sub
        End If

        FechaInicio = DateTimePicker1.Value.Date
        FechaFin = DateTimePicker2.Value.Date.AddDays(1).AddSeconds(-1)
        TipoConsulta = CB_TIPOCONSULTA.SelectedItem.ToString()

        DialogResult = DialogResult.OK
        Close()
    End Sub

End Class