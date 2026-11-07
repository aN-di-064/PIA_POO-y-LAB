Imports System.Data.OleDb

Public Class UC_CAT_Eliminar

    Private Sub UC_CAT_Eliminar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MTB_Codigo.ReadOnly = True
        MTB_Nombre.ReadOnly = True
    End Sub

    ' Botón "Buscar categoria"
    Private Sub Button_Buscar_Click(sender As Object, e As EventArgs) Handles Button_Buscar.Click
        Dim buscador As New Busqueda_Venta()
        buscador.TipoBusqueda = "CATEGORIA"

        If buscador.ShowDialog() = DialogResult.OK Then
            MTB_Codigo.Text = buscador.CodigoSeleccionado
            MTB_Nombre.Text = buscador.DescripcionSeleccionada
        End If
    End Sub

    ' Botón Eliminar
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If String.IsNullOrWhiteSpace(MTB_Codigo.Text) Then
            MessageBox.Show("Por favor, busque y seleccione una categoría para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim respuesta As DialogResult = MessageBox.Show($"¿Estás seguro de eliminar la categoría '{MTB_Nombre.Text}'?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If respuesta = DialogResult.Yes Then
            Try
                Using con As OleDbConnection = ObtenerConexion()
                    Dim query As String = "DELETE FROM Categoria WHERE Id_cat = ?"
                    Using cmd As New OleDbCommand(query, con)
                        cmd.Parameters.AddWithValue("?", Convert.ToInt32(MTB_Codigo.Text.Trim()))
                        cmd.ExecuteNonQuery()
                    End Using
                End Using

                MessageBox.Show("¡Categoría eliminada exitosamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LimpiarCampos()
            Catch ex As Exception
                MessageBox.Show("Error al eliminar la categoría. Verifique que no tenga productos asociados.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub LimpiarCampos()
        MTB_Codigo.Clear()
        MTB_Nombre.Clear()
    End Sub

End Class