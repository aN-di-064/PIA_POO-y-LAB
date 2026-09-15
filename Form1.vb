Imports System.ComponentModel

Public Class Form1


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If (TextBox1.Text = "user") And (TextBox2.Text = "Caña") Then

            Interfaz_Principal.Show()
            Me.Hide()
            TextBox1.Text = ""
            TextBox2.Text = ""

        Else
            MessageBox.Show("Los datos de inicio de sesión son incorrectos", "Advertencia",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If






    End Sub
End Class
