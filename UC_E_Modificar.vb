Imports System.Data.OleDb

Public Class UC_E_Modificar

    Private Sub UC_E_Modificar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarRoles()
        MTB_Codigo.ReadOnly = True
    End Sub

    Private Sub CargarRoles()
        Try
            Using con As OleDbConnection = ObtenerConexion()
                Dim query As String = "SELECT ID_rol, Descripcion_rol FROM Rol"
                Using adapter As New OleDbDataAdapter(query, con)
                    Dim dt As New DataTable()
                    adapter.Fill(dt)
                    CB_Rol.DataSource = dt
                    CB_Rol.DisplayMember = "Descripcion_rol"
                    CB_Rol.ValueMember = "ID_rol"
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al cargar roles: " & ex.Message)
        End Try
    End Sub

    ' Botón "Buscar Material" / "Buscar Empleado"
    Private Sub Button_Buscar_Click(sender As Object, e As EventArgs) Handles Button_Buscar.Click
        Dim buscador As New Busqueda_Venta()
        buscador.TipoBusqueda = "EMPLEADO"

        If buscador.ShowDialog() = DialogResult.OK Then
            Dim idSeleccionado As String = buscador.CodigoSeleccionado
            CargarDatosEmpleado(idSeleccionado)
        End If
    End Sub

    Private Sub CargarDatosEmpleado(id As String)
        Try
            Using con As OleDbConnection = ObtenerConexion()
                Dim query As String = "SELECT * FROM Empleado WHERE Id_emp = ?"
                Using cmd As New OleDbCommand(query, con)
                    cmd.Parameters.AddWithValue("?", Convert.ToInt32(id))
                    Using reader As OleDbDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            MTB_Codigo.Text = reader("Id_emp").ToString()
                            MTB_Nombre.Text = reader("Nombre_emp").ToString()
                            CB_Rol.SelectedValue = Convert.ToInt32(reader("ID_rol"))
                            MTB_Telefono.Text = reader("Telefono_emp").ToString()
                            MTB_RFC.Text = reader("rfc_emp").ToString()
                            MTB_Contraseña.Text = reader("contraseña_emp").ToString()
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al cargar los datos del empleado: " & ex.Message)
        End Try
    End Sub

    ' Botón Modificar / Actualizar
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If String.IsNullOrWhiteSpace(MTB_Codigo.Text) Then
            MessageBox.Show("Por favor, busque y seleccione un empleado primero.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Try
            Using con As OleDbConnection = ObtenerConexion()
                Dim query As String = "UPDATE Empleado SET Nombre_emp = ?, ID_rol = ?, Telefono_emp = ?, rfc_emp = ?, contraseña_emp = ? WHERE Id_emp = ?"
                Using cmd As New OleDbCommand(query, con)
                    cmd.Parameters.AddWithValue("?", MTB_Nombre.Text.Trim())
                    cmd.Parameters.AddWithValue("?", Convert.ToInt32(CB_Rol.SelectedValue))
                    cmd.Parameters.AddWithValue("?", MTB_Telefono.Text.Trim())
                    cmd.Parameters.AddWithValue("?", MTB_RFC.Text.Trim())
                    cmd.Parameters.AddWithValue("?", MTB_Contraseña.Text.Trim())
                    cmd.Parameters.AddWithValue("?", Convert.ToInt32(MTB_Codigo.Text.Trim()))

                    cmd.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show("¡Empleado modificado exitosamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LimpiarCampos()
        Catch ex As Exception
            MessageBox.Show("Error al actualizar: " & ex.Message)
        End Try
    End Sub

    Private Sub LimpiarCampos()
        MTB_Codigo.Clear()
        MTB_Nombre.Clear()
        MTB_Telefono.Clear()
        MTB_RFC.Clear()
        MTB_Contraseña.Clear()
        If CB_Rol.Items.Count > 0 Then CB_Rol.SelectedIndex = 0
    End Sub

    Private Sub Panel_Form_Paint(sender As Object, e As PaintEventArgs) Handles Panel_Form.Paint
    End Sub
End Class