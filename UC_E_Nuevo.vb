Imports System.Data.OleDb

Public Class UC_E_Nuevo

    Private Sub UC_E_Nuevo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Cargar lista de roles desde la base de datos
        CargarRoles()

        ' Al cargar el control, calculamos y mostramos el ID disponible
        CargarSiguienteID()

        ' Hacemos que el campo de Código sea de solo lectura para el usuario
        MTB_Codigo.ReadOnly = True
    End Sub

    ' Llena el ComboBox desde la tabla Rol mostrando la descripción y conservando el ID
    Private Sub CargarRoles()
        Try
            Using con As OleDbConnection = ObtenerConexion()
                Dim query As String = "SELECT ID_rol, Descripcion_rol FROM Rol"
                Using adapter As New OleDbDataAdapter(query, con)
                    Dim dt As New DataTable()
                    adapter.Fill(dt)

                    CB_Rol.DataSource = dt
                    CB_Rol.DisplayMember = "Descripcion_rol" ' Texto visible ("Administrador", "Cajero")
                    CB_Rol.ValueMember = "ID_rol"           ' Valor numérico almacenado en BD (1, 2)
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al cargar los roles: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Método para obtener el ID más bajo disponible o el siguiente consecutivo
    Private Sub CargarSiguienteID()
        Try
            Using con As OleDbConnection = ObtenerConexion()
                ' Reemplazamos NZ por IIF y IsNull para compatibilidad total con OleDb en Access
                Dim query As String = "SELECT IIF(IsNull(MAX(Id_emp)), 1, MAX(Id_emp) + 1) FROM Empleado"
                Using cmd As New OleDbCommand(query, con)
                    Dim siguienteId As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                    MTB_Codigo.Text = siguienteId.ToString()
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al obtener el código: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Botón Agregar / Guardar
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Validar campos obligatorios básicos
        If String.IsNullOrWhiteSpace(MTB_Nombre.Text) OrElse
           CB_Rol.SelectedValue Is Nothing OrElse
           String.IsNullOrWhiteSpace(MTB_Contraseña.Text) Then
            MessageBox.Show("Por favor, complete al menos los campos obligatorios (Nombre, Rol y Contraseña).", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Try
            Using con As OleDbConnection = ObtenerConexion()
                ' Consulta de inserción parametrizada para evitar errores de sintaxis o inyección SQL
                Dim query As String = "INSERT INTO Empleado (Nombre_emp, ID_rol, Telefono_emp, rfc_emp, contraseña_emp) VALUES (?, ?, ?, ?, ?)"

                Using cmd As New OleDbCommand(query, con)
                    cmd.Parameters.AddWithValue("?", MTB_Nombre.Text.Trim())
                    cmd.Parameters.AddWithValue("?", Convert.ToInt32(CB_Rol.SelectedValue))
                    cmd.Parameters.AddWithValue("?", MTB_Telefono.Text.Trim())
                    cmd.Parameters.AddWithValue("?", MTB_RFC.Text.Trim())
                    cmd.Parameters.AddWithValue("?", MTB_Contraseña.Text.Trim())

                    cmd.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show("¡Empleado registrado exitosamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' Limpiar los campos para un nuevo registro
            MTB_Nombre.Clear()
            If CB_Rol.Items.Count > 0 Then CB_Rol.SelectedIndex = 0
            MTB_Telefono.Clear()
            MTB_RFC.Clear()
            MTB_Contraseña.Clear()

            ' Actualizar el código disponible para el siguiente registro
            CargarSiguienteID()

        Catch ex As Exception
            MessageBox.Show("Error al guardar en la base de datos: " & ex.Message, "Error de Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Panel_Form_Paint(sender As Object, e As PaintEventArgs) Handles Panel_Form.Paint

    End Sub

End Class