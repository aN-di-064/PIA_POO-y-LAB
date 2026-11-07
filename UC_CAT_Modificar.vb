Imports System.Data.OleDb

Public Class UC_CAT_Modificar

    Private Sub UC_CAT_Modificar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MTB_Codigo.ReadOnly = True
    End Sub

    ' Botón "Buscar categoría"
    Private Sub Button_Buscar_Click(sender As Object, e As EventArgs) Handles Button_Buscar.Click
        Dim buscador As New Busqueda_Venta()
        buscador.TipoBusqueda = "CATEGORIA"

        If buscador.ShowDialog() = DialogResult.OK Then
            MTB_Codigo.Text = buscador.CodigoSeleccionado
            MTB_Nombre.Text = buscador.DescripcionSeleccionada
        End If
    End Sub

    ' Botón Modificar
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If String.IsNullOrWhiteSpace(MTB_Codigo.Text) Then
            MessageBox.Show("Por favor, busque y seleccione una categoría primero.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If String.IsNullOrWhiteSpace(MTB_Nombre.Text) Then
            MessageBox.Show("El nombre de la categoría no puede estar vacío.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Try
            Using con As OleDbConnection = ObtenerConexion()
                ' Campo actualizado a Nombre_cat
                Dim query As String = "UPDATE Categoria SET Nombre_cat = ? WHERE Id_cat = ?"
                Using cmd As New OleDbCommand(query, con)
                    cmd.Parameters.AddWithValue("?", MTB_Nombre.Text.Trim())
                    cmd.Parameters.AddWithValue("?", Convert.ToInt32(MTB_Codigo.Text.Trim()))
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show("¡Categoría modificada exitosamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LimpiarCampos()
        Catch ex As Exception
            MessageBox.Show("Error al actualizar la categoría: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LimpiarCampos()
        MTB_Codigo.Clear()
        MTB_Nombre.Clear()
    End Sub

End Class