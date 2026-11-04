Imports System.Data.OleDb
Imports System.IO

Module ConexionBD

    ' Ruta dinámica que apunta automáticamente a la carpeta "Base de datos" junto al ejecutable
    Public ReadOnly StringConexion As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Base de datos\Dulceria.accdb") & ";"

    Public Function ObtenerConexion() As OleDbConnection
        Dim con As New OleDbConnection(StringConexion)
        con.Open()
        Return con
    End Function

    Public Function ProbarConexion() As Boolean
        Try
            Using con As OleDbConnection = ObtenerConexion()
                Return True
            End Using
        Catch ex As Exception
            MessageBox.Show("Error de conexión: " & ex.Message)
            Return False
        End Try
    End Function

End Module