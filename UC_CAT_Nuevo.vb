Imports System.Data.OleDb

Public Class UC_CAT_Nuevo

    Private Sub UC_CAT_Nuevo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MTB_Codigo.ReadOnly = True
        ObtenerSiguienteID()
    End Sub

    ' Obtiene el ID más alto actual + 1 para mostrarlo como preview
    Private Sub ObtenerSiguienteID()
        Try
            Using con As OleDbConnection = ObtenerConexion()
                Dim query As String = "SELECT MAX(Id_cat) FROM Categoria"
                Using cmd As New OleDbCommand(query, con)
                    Dim result = cmd.ExecuteScalar()
                    If result IsNot DBNull.Value AndAlso result IsNot Nothing Then
                        MTB_Codigo.Text = (Convert.ToInt32(result) + 1).ToString()
                    Else
                        MTB_Codigo.Text = "1"
                    End If
                End Using
            End Using
        Catch ex As Exception
            MTB_Codigo.Text = "1"
        End Try
    End Sub

    ' Botón Agregar
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If String.IsNullOrWhiteSpace(MTB_Nombre.Text) Then
            MessageBox.Show("Por favor, ingrese el nombre de la categoría.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Try
            Using con As OleDbConnection = ObtenerConexion()
                ' Usamos el nombre exacto de la columna en la base de datos: Nombre_cat
                Dim query As String = "INSERT INTO Categoria (Nombre_cat) VALUES (?)"
                Using cmd As New OleDbCommand(query, con)
                    cmd.Parameters.AddWithValue("?", MTB_Nombre.Text.Trim())
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show("¡Categoría registrada exitosamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LimpiarCampos()
            ObtenerSiguienteID()
        Catch ex As Exception
            MessageBox.Show("Error al registrar la categoría: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LimpiarCampos()
        MTB_Nombre.Clear()
    End Sub

End Class