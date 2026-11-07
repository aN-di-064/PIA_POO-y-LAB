Imports System.Data.OleDb

Public Class UC_P_Nuevo

    Private Sub UC_P_Nuevo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MTB_Codigo.ReadOnly = True
        ObtenerSiguienteID()
    End Sub

    Private Sub ObtenerSiguienteID()
        Try
            Using con As OleDbConnection = ObtenerConexion()
                Dim query As String = "SELECT MAX(Id_prov) FROM Proveedor"
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
            MessageBox.Show("Por favor, ingrese el nombre del proveedor.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Try
            Using con As OleDbConnection = ObtenerConexion()
                Dim query As String = "INSERT INTO Proveedor (Nombre_prov, Direccion_prov, Telefono_prov) VALUES (?, ?, ?)"
                Using cmd As New OleDbCommand(query, con)
                    cmd.Parameters.AddWithValue("?", MTB_Nombre.Text.Trim())
                    cmd.Parameters.AddWithValue("?", MTB_Direccion.Text.Trim())
                    cmd.Parameters.AddWithValue("?", MTB_Telefono.Text.Trim())
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show("¡Proveedor registrado exitosamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LimpiarCampos()
            ObtenerSiguienteID()
        Catch ex As Exception
            MessageBox.Show("Error al registrar el proveedor: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LimpiarCampos()
        MTB_Nombre.Clear()
        MTB_Direccion.Clear()
        MTB_Telefono.Clear()
    End Sub

End Class