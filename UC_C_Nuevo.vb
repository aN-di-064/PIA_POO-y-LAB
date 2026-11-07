Imports System.Data.OleDb

Public Class UC_C_Nuevo

    Private Sub UC_C_Nuevo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MTB_Codigo.ReadOnly = True
        ObtenerSiguienteID()
    End Sub

    Private Sub ObtenerSiguienteID()
        Try
            Using con As OleDbConnection = ObtenerConexion()
                Dim query As String = "SELECT MAX(Id_cli) FROM Cliente"
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
            MessageBox.Show("Por favor, ingrese el nombre del cliente.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MTB_Nombre.Focus()
            Exit Sub
        End If

        Try
            Using con As OleDbConnection = ObtenerConexion()
                Dim query As String = "INSERT INTO Cliente (Nombre_cli, Telefono_cli, Correo_cli, RFC_cli, Direccion_cli) VALUES (?, ?, ?, ?, ?)"
                Using cmd As New OleDbCommand(query, con)
                    cmd.Parameters.AddWithValue("?", MTB_Nombre.Text.Trim())
                    cmd.Parameters.AddWithValue("?", MTB_Telefono.Text.Trim())
                    cmd.Parameters.AddWithValue("?", MTB_Correo.Text.Trim())
                    cmd.Parameters.AddWithValue("?", MTB_RFC.Text.Trim())
                    cmd.Parameters.AddWithValue("?", MTB_Direccion.Text.Trim())
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show("¡Cliente registrado exitosamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LimpiarCampos()
            ObtenerSiguienteID()
        Catch ex As Exception
            MessageBox.Show("Error al registrar el cliente: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LimpiarCampos()
        MTB_Nombre.Clear()
        MTB_Telefono.Clear()
        MTB_Correo.Clear()
        MTB_RFC.Clear()
        MTB_Direccion.Clear()
    End Sub

End Class