Public Class RangoFechas
    ' Propiedades para transferir las fechas a la vista principal

    Public FechaInicio As DateTime
    Public FechaFin As DateTime

    Private Sub RangoFechas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Establecer la fecha actual por defecto en ambos controles
        DateTimePicker1.Value = DateTime.Now
        DateTimePicker2.Value = DateTime.Now
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Validar que la fecha inicial no sea posterior a la fecha final
        If DateTimePicker1.Value.Date > DateTimePicker2.Value.Date Then
            MessageBox.Show("La fecha de inicio no puede ser posterior a la fecha de fin.",
                            "Rango Inválido",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' Asignar la fecha de inicio
        FechaInicio = DateTimePicker1.Value.Date

        ' Asignar la fecha final marcando el límite exacto del día (23:59:59)
        FechaFin = DateTimePicker2.Value.Date.AddDays(1).AddSeconds(-1)

        ' Indicar que la acción fue exitosa y cerrar la ventana modal
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub
End Class