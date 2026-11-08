Imports System.Data.OleDb
Imports System.IO

Module ConexionBD

    Public ReadOnly StringConexion As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Base de datos\Dulceria.accdb") & ";"

    ' Devuelve la conexión sin abrir para que cada bloque Using controle su propio inicio y cierre
    Public Function ObtenerConexion() As OleDbConnection
        Return New OleDbConnection(StringConexion)
    End Function

    Public Function ProbarConexion() As Boolean
        Try
            Using con As OleDbConnection = ObtenerConexion()
                con.Open()
                Return True
            End Using
        Catch ex As Exception
            MessageBox.Show("Error de conexión: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

End Module