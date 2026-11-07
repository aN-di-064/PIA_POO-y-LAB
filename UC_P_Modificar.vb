Imports System.Data.OleDb

Public Class UC_P_Modificar

    Private Sub UC_P_Modificar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MTB_Codigo.ReadOnly = True
    End Sub

    ' Botón "Buscar Proveedor"
    Private Sub Button_Buscar_Click(sender As Object, e As EventArgs) Handles Button_Buscar.Click
        Dim buscador As New Busqueda_Venta()
        buscador.TipoBusqueda = "PROVEEDOR"

        If buscador.ShowDialog() = DialogResult.OK Then
            MTB_Codigo.Text = buscador.CodigoSeleccionado
            MTB_Nombre.Text = buscador.DescripcionSeleccionada
            MTB_Direccion.Text = buscador.DireccionSeleccionada
            MTB_Telefono.Text = buscador.TelefonoSeleccionado
        End If
    End Sub

    ' Botón Modificar
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If String.IsNullOrWhiteSpace(MTB_Codigo.Text) Then
            MessageBox.Show("Por favor, busque y seleccione un proveedor primero.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If String.IsNullOrWhiteSpace(MTB_Nombre.Text) Then
            MessageBox.Show("El nombre del proveedor no puede estar vacío.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Try
            Using con As OleDbConnection = ObtenerConexion()
                Dim query As String = "UPDATE Proveedor SET Nombre_prov = ?, Direccion_prov = ?, Telefono_prov = ? WHERE Id_prov = ?"
                Using cmd As New OleDbCommand(query, con)
                    cmd.Parameters.AddWithValue("?", MTB_Nombre.Text.Trim())
                    cmd.Parameters.AddWithValue("?", MTB_Direccion.Text.Trim())
                    cmd.Parameters.AddWithValue("?", MTB_Telefono.Text.Trim())
                    cmd.Parameters.AddWithValue("?", Convert.ToInt32(MTB_Codigo.Text.Trim()))
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show("¡Proveedor modificado exitosamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LimpiarCampos()
        Catch ex As Exception
            MessageBox.Show("Error al actualizar el proveedor: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
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