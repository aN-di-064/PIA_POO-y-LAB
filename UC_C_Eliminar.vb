Imports System.Data.OleDb

Public Class UC_C_Eliminar

    Private Sub UC_C_Eliminar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MTB_Codigo.ReadOnly = True
        MTB_Nombre.ReadOnly = True
        MTB_Telefono.ReadOnly = True
        MTB_Correo.ReadOnly = True
        MTB_RFC.ReadOnly = True
        MTB_Direccion.ReadOnly = True
    End Sub

    ' Botón Buscar Cliente
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

    ' Botón Eliminar
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If String.IsNullOrWhiteSpace(MTB_Codigo.Text) Then
            MessageBox.Show("Por favor, busque y seleccione un cliente para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim respuesta As DialogResult = MessageBox.Show($"¿Estás seguro de eliminar al cliente '{MTB_Nombre.Text}'?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If respuesta = DialogResult.Yes Then
            Try
                Using con As OleDbConnection = ObtenerConexion()
                    Dim query As String = "DELETE FROM Cliente WHERE Id_cli = ?"
                    Using cmd As New OleDbCommand(query, con)
                        cmd.Parameters.AddWithValue("?", Convert.ToInt32(MTB_Codigo.Text.Trim()))
                        cmd.ExecuteNonQuery()
                    End Using
                End Using

                MessageBox.Show("¡Cliente eliminado exitosamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LimpiarCampos()
            Catch ex As Exception
                MessageBox.Show("Error al eliminar el cliente: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub LimpiarCampos()
        MTB_Codigo.Clear()
        MTB_Nombre.Clear()
        MTB_Telefono.Clear()
        MTB_Correo.Clear()
        MTB_RFC.Clear()
        MTB_Direccion.Clear()
    End Sub

    Private Sub Panel_Form_Paint(sender As Object, e As PaintEventArgs) Handles Panel_Form.Paint

    End Sub
End Class