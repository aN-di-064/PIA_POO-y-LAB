Imports System.Data.OleDb

Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Ocultar los caracteres digitados en el campo de contraseña
        TextBox2.UseSystemPasswordChar = True

        ' Limitar la entrada a máximo 10 caracteres
        TextBox2.MaxLength = 10
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Validar campos vacíos
        If String.IsNullOrWhiteSpace(TextBox1.Text) OrElse String.IsNullOrWhiteSpace(TextBox2.Text) Then
            MessageBox.Show("Por favor ingresa un usuario y contraseña válidos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' Consulta parametrizada usando '?' para OleDb / Access
        Dim consulta As String = "SELECT E.Id_emp, E.Nombre_emp, E.ID_rol, R.Descripcion_rol " &
                                 "FROM Empleado E " &
                                 "INNER JOIN Rol R ON E.ID_rol = R.ID_rol " &
                                 "WHERE E.Id_emp = ? AND E.contraseña_emp = ?"

        Try
            ' Usamos la conexión global unificada de tu módulo ConexionBD
            Using con As OleDbConnection = ObtenerConexion()
                Using cmd As New OleDbCommand(consulta, con)
                    ' OleDb asigna los parámetros en orden de aparición de los '?'
                    cmd.Parameters.AddWithValue("?", Convert.ToInt32(TextBox1.Text.Trim()))
                    cmd.Parameters.AddWithValue("?", TextBox2.Text.Trim())

                    Using reader As OleDbDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            ' Guardar los datos de la sesión en el módulo InicioSesion
                            IdUsuarioActual = reader("Id_emp").ToString()
                            NombreUsuarioActual = reader("Nombre_emp").ToString()
                            IdRolActual = Convert.ToInt32(reader("ID_rol"))
                            DescripcionRolActual = reader("Descripcion_rol").ToString()

                            MessageBox.Show($"Bienvenido(a) {NombreUsuarioActual} ({DescripcionRolActual})", "Acceso Concedido", MessageBoxButtons.OK, MessageBoxIcon.Information)

                            ' Mostrar la pantalla principal y ocultar el Login
                            Interfaz_Principal.Show()
                            Me.Hide()

                            ' Limpiar cajas de texto
                            TextBox1.Clear()
                            TextBox2.Clear()
                        Else
                            MessageBox.Show("Usuario o contraseña incorrectos.", "Error de autenticación", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al conectar con la base de datos: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

End Class