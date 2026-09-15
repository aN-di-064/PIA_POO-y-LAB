Public Class UC_I_Nuevo
    Private Sub UC_I_Nuevo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CentrarFormulario()
    End Sub

    Private Sub UC_I_Nuevo_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        CentrarFormulario()
    End Sub

    Private Sub CentrarFormulario()
        ' Usamos Panel_Form, que es el nombre exacto registrado en tus Propiedades
        If Panel_Form IsNot Nothing Then
            Dim x As Integer = (Me.ClientSize.Width - Panel_Form.Width) \ 2
            Dim y As Integer = (Me.ClientSize.Height - Panel_Form.Height) \ 2

            If x < 0 Then x = 0
            If y < 0 Then y = 0

            Panel_Form.Location = New Point(x, y)
        End If
    End Sub

End Class
