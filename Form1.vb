Imports System.ComponentModel

Public Class Form1


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If (TextBox1.Text = "user") Then
            Interfaz_Principal.Show()

        Else
            MessageBox.Show("Los datos de inicio de sesión son incorrectos", "Advertencia",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If






    End Sub
End Class
