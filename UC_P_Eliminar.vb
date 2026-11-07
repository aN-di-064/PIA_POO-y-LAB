Imports System.Data.OleDb

Public Class UC_P_Eliminar

    Private Sub UC_P_Eliminar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MTB_Codigo.ReadOnly = True
        MTB_Nombre.ReadOnly = True
        MTB_Direccion.ReadOnly = True
        MTB_Telefono.ReadOnly = True
    End Sub

    ' Botón "Buscar Proveedor" - Añadido Handles Button_Buscar.Click
    Private Sub Button_Buscar_Click(sender As Object, e As EventArgs) Handles Button_Buscar.Click
        Dim buscador As New Busqueda_Venta
        buscador.TipoBusqueda = "PROVEEDOR"

        If buscador.ShowDialog = DialogResult.OK Then
            MTB_Codigo.Text = buscador.CodigoSeleccionado
            MTB_Nombre.Text = buscador.DescripcionSeleccionada
            MTB_Direccion.Text = buscador.DireccionSeleccionada
            MTB_Telefono.Text = buscador.TelefonoSeleccionado
        End If
    End Sub

    ' Botón Eliminar - Añadido Handles Button1.Click (o el nombre real de tu botón)
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If String.IsNullOrWhiteSpace(MTB_Codigo.Text) Then
            MessageBox.Show("Por favor, busque y seleccione un proveedor para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim respuesta = MessageBox.Show($"¿Estás seguro de eliminar al proveedor '{MTB_Nombre.Text}'?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If respuesta = DialogResult.Yes Then
            Try
                Using con = ObtenerConexion()
                    Dim query = "DELETE FROM Proveedor WHERE Id_prov = ?"
                    Using cmd As New OleDbCommand(query, con)
                        cmd.Parameters.AddWithValue("?", Convert.ToInt32(MTB_Codigo.Text.Trim))
                        cmd.ExecuteNonQuery()
                    End Using
                End Using

                MessageBox.Show("¡Proveedor eliminado exitosamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LimpiarCampos()
            Catch ex As Exception
                MessageBox.Show("Error al eliminar el proveedor. Verifique que no tenga productos asociados.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub LimpiarCampos()
        MTB_Codigo.Clear()
        MTB_Nombre.Clear()
        MTB_Direccion.Clear()
        MTB_Telefono.Clear()
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
    End Sub

End Class