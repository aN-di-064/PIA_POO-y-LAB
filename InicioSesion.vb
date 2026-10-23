Public Module InicioSesion
    ' Variables globales para almacenar los datos del usuario en sesión
    Public IdUsuarioActual As String = ""
    Public NombreUsuarioActual As String = ""
    Public IdRolActual As Integer = 0
    Public DescripcionRolActual As String = ""

    ' Método para cerrar sesión cuando presionen el botón "Volver"
    Public Sub CerrarSesion()
        IdUsuarioActual = ""
        NombreUsuarioActual = ""
        IdRolActual = 0
        DescripcionRolActual = ""
    End Sub

End Module
