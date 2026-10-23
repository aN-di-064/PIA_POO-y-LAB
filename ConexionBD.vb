Imports System.Data.OleDb

Module ConexionBD

    Public ReadOnly StringConexion As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\FIME\5to Semestre\Laboratorio de programación orientada a objetos\PIA\Dulceria.accdb;"

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
