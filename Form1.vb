Imports System.ComponentModel
Imports System.Data.OleDb

Public Class Form1

    ' Modifica con tu cadena de conexión a la base de datos
    Private cadenaConexion As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\FIME\5to Semestre\Laboratorio de programación orientada a objetos\PIA\Dulceria.accdb;"

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

        ' Consulta parametrizada buscando en la tabla Empleado y Rol
        Dim consulta = "SELECT E.Id_emp, E.Nombre_emp, E.ID_rol, R.Descripcion_rol " &
                                 "FROM Empleado E " &
                                 "INNER JOIN Rol R ON E.ID_rol = R.ID_rol " &
                                 "WHERE E.Id_emp = @Usuario AND E.contraseña_emp = @Contrasena"

        Using con As New OleDbConnection(cadenaConexion)
            Using cmd As New OleDbCommand(consulta, con)
                cmd.Parameters.AddWithValue("@Usuario", TextBox1.Text.Trim)
                cmd.Parameters.AddWithValue("@Contrasena", TextBox2.Text.Trim)

                Try
                    con.Open
                    Dim reader = cmd.ExecuteReader

                    If reader.Read Then
                        ' Guardar los datos de la sesión en el módulo InicioSesion
                        IdUsuarioActual = reader("Id_emp").ToString
                        NombreUsuarioActual = reader("Nombre_emp").ToString
                        IdRolActual = Convert.ToInt32(reader("ID_rol"))
                        DescripcionRolActual = reader("Descripcion_rol").ToString

                        MessageBox.Show($"Bienvenido(a) {NombreUsuarioActual} ({DescripcionRolActual})", "Acceso Concedido", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        ' Mostrar la pantalla principal y ocultar la de Login
                        Interfaz_Principal.Show
                        Hide

                        ' Limpiar cajas de texto
                        TextBox1.Clear
                        TextBox2.Clear
                    Else
                        MessageBox.Show("Usuario o contraseña incorrectos.", "Error de autenticación", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If

                    reader.Close
                Catch ex As Exception
                    MessageBox.Show("Error al conectar con la base de datos: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End Using
    End Sub

End Class
