Imports System.Data.OleDb

Public Class UC_C_Modificar

    Private Sub UC_C_Modificar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MTB_Codigo.ReadOnly = True
    End Sub

    ' Botón Buscar Cliente (o Buscar Material según tu diseñador)
    Private Sub Button_Buscar_Click(sender As Object, e As EventArgs) Handles Button_Buscar.Click
        Dim buscador As New Busqueda_Venta()
        buscador.TipoBusqueda = "CLIENTE"

        If buscador.ShowDialog() = DialogResult.OK Then
            MTB_Codigo.Text = buscador.CodigoSeleccionado
            CargarDetallesCliente(Convert.ToInt32(buscador.CodigoSeleccionado))
        End If
    End Sub

    Private Sub CargarDetallesCliente(idCliente As Integer)
        Try
            Using con As OleDbConnection = ObtenerConexion()
                Dim query As String = "SELECT * FROM Cliente WHERE Id_cli = ?"
                Using cmd As New OleDbCommand(query, con)
                    cmd.Parameters.AddWithValue("?", idCliente)
                    Using reader As OleDbDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            MTB_Nombre.Text = reader("Nombre_cli").ToString()
                            MTB_Telefono.Text = reader("Telefono_cli").ToString()
                            MTB_Correo.Text = reader("Correo_cli").ToString()
                            MTB_RFC.Text = reader("RFC_cli").ToString()
                            MTB_Direccion.Text = reader("Direccion_cli").ToString()
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al cargar los detalles del cliente: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Botón Modificar
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If String.IsNullOrWhiteSpace(MTB_Codigo.Text) Then
            MessageBox.Show("Por favor, busque y seleccione un cliente primero.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If String.IsNullOrWhiteSpace(MTB_Nombre.Text) Then
            MessageBox.Show("El nombre del cliente no puede estar vacío.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Try
            Using con As OleDbConnection = ObtenerConexion()
                Dim query As String = "UPDATE Cliente SET Nombre_cli = ?, Telefono_cli = ?, Correo_cli = ?, RFC_cli = ?, Direccion_cli = ? WHERE Id_cli = ?"
                Using cmd As New OleDbCommand(query, con)
                    cmd.Parameters.AddWithValue("?", MTB_Nombre.Text.Trim())
                    cmd.Parameters.AddWithValue("?", MTB_Telefono.Text.Trim())
                    cmd.Parameters.AddWithValue("?", MTB_Correo.Text.Trim())
                    cmd.Parameters.AddWithValue("?", MTB_RFC.Text.Trim())
                    cmd.Parameters.AddWithValue("?", MTB_Direccion.Text.Trim())
                    cmd.Parameters.AddWithValue("?", Convert.ToInt32(MTB_Codigo.Text.Trim()))
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show("¡Cliente modificado exitosamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LimpiarCampos()
        Catch ex As Exception
            MessageBox.Show("Error al actualizar el cliente: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LimpiarCampos()
        MTB_Codigo.Clear()
        MTB_Nombre.Clear()
        MTB_Telefono.Clear()
        MTB_Correo.Clear()
        MTB_RFC.Clear()
        MTB_Direccion.Clear()
    End Sub

End Class