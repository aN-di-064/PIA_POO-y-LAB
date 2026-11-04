Imports System.Data.OleDb

Public Class UC_E_Nuevo

    Private Sub UC_E_Nuevo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Al cargar el control, calculamos y mostramos el ID disponible
        CargarSiguienteID()

        ' Hacemos que el campo de Código sea de solo lectura para el usuario
        MTB_Codigo.ReadOnly = True
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
           String.IsNullOrWhiteSpace(MTB_Rol.Text) OrElse
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
                    cmd.Parameters.AddWithValue("?", Convert.ToInt32(MTB_Rol.Text.Trim()))
                    cmd.Parameters.AddWithValue("?", MTB_Telefono.Text.Trim())
                    cmd.Parameters.AddWithValue("?", MTB_RFC.Text.Trim())
                    cmd.Parameters.AddWithValue("?", MTB_Contraseña.Text.Trim())

                    cmd.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show("¡Empleado registrado exitosamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' Limpiar los campos para un nuevo registro
            MTB_Nombre.Clear()
            MTB_Rol.Clear()
            MTB_Telefono.Clear()
            MTB_RFC.Clear()
            MTB_Contraseña.Clear()

            ' Actualizar el código disponible para el siguiente registro
            CargarSiguienteID()

        Catch ex As Exception
            MessageBox.Show("Error al guardar en la base de datos: " & ex.Message, "Error de Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class