<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UC_C_Modificar
    Inherits System.Windows.Forms.UserControl

    'UserControl reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        MaskedTextBox6 = New MaskedTextBox()
        Label7 = New Label()
        Label1 = New Label()
        Button1 = New Button()
        MaskedTextBox5 = New MaskedTextBox()
        Label2 = New Label()
        MaskedTextBox4 = New MaskedTextBox()
        MaskedTextBox1 = New MaskedTextBox()
        MaskedTextBox3 = New MaskedTextBox()
        Label3 = New Label()
        MaskedTextBox2 = New MaskedTextBox()
        Label4 = New Label()
        Label6 = New Label()
        Label5 = New Label()
        SuspendLayout()
        ' 
        ' MaskedTextBox6
        ' 
        MaskedTextBox6.Location = New Point(191, 289)
        MaskedTextBox6.Name = "MaskedTextBox6"
        MaskedTextBox6.Size = New Size(201, 23)
        MaskedTextBox6.TabIndex = 77
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Location = New Point(101, 297)
        Label7.Name = "Label7"
        Label7.Size = New Size(28, 15)
        Label7.TabIndex = 76
        Label7.Text = "RFC"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(249, 28)
        Label1.Name = "Label1"
        Label1.Size = New Size(147, 15)
        Label1.TabIndex = 64
        Label1.Text = "Modificar datos del cliente"
        ' 
        ' Button1
        ' 
        Button1.Location = New Point(503, 351)
        Button1.Name = "Button1"
        Button1.Size = New Size(75, 23)
        Button1.TabIndex = 67
        Button1.Text = "Eliminar"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' MaskedTextBox5
        ' 
        MaskedTextBox5.Location = New Point(191, 336)
        MaskedTextBox5.Name = "MaskedTextBox5"
        MaskedTextBox5.Size = New Size(201, 23)
        MaskedTextBox5.TabIndex = 75
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(101, 99)
        Label2.Name = "Label2"
        Label2.Size = New Size(46, 15)
        Label2.TabIndex = 65
        Label2.Text = "Código"
        ' 
        ' MaskedTextBox4
        ' 
        MaskedTextBox4.Location = New Point(191, 241)
        MaskedTextBox4.Name = "MaskedTextBox4"
        MaskedTextBox4.Size = New Size(201, 23)
        MaskedTextBox4.TabIndex = 74
        ' 
        ' MaskedTextBox1
        ' 
        MaskedTextBox1.Location = New Point(191, 96)
        MaskedTextBox1.Name = "MaskedTextBox1"
        MaskedTextBox1.Size = New Size(201, 23)
        MaskedTextBox1.TabIndex = 66
        ' 
        ' MaskedTextBox3
        ' 
        MaskedTextBox3.Location = New Point(191, 190)
        MaskedTextBox3.Name = "MaskedTextBox3"
        MaskedTextBox3.Size = New Size(201, 23)
        MaskedTextBox3.TabIndex = 73
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(101, 198)
        Label3.Name = "Label3"
        Label3.Size = New Size(18, 15)
        Label3.TabIndex = 68
        Label3.Text = "ID"
        ' 
        ' MaskedTextBox2
        ' 
        MaskedTextBox2.Location = New Point(191, 148)
        MaskedTextBox2.Name = "MaskedTextBox2"
        MaskedTextBox2.Size = New Size(201, 23)
        MaskedTextBox2.TabIndex = 72
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(101, 148)
        Label4.Name = "Label4"
        Label4.Size = New Size(51, 15)
        Label4.TabIndex = 69
        Label4.Text = "Nombre"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Location = New Point(101, 339)
        Label6.Name = "Label6"
        Label6.Size = New Size(67, 15)
        Label6.TabIndex = 71
        Label6.Text = "Contraseña"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(101, 244)
        Label5.Name = "Label5"
        Label5.Size = New Size(52, 15)
        Label5.TabIndex = 70
        Label5.Text = "Telefono"
        ' 
        ' UC_C_Modificar
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        Controls.Add(MaskedTextBox6)
        Controls.Add(Label7)
        Controls.Add(Label1)
        Controls.Add(Button1)
        Controls.Add(MaskedTextBox5)
        Controls.Add(Label2)
        Controls.Add(MaskedTextBox4)
        Controls.Add(MaskedTextBox1)
        Controls.Add(MaskedTextBox3)
        Controls.Add(Label3)
        Controls.Add(MaskedTextBox2)
        Controls.Add(Label4)
        Controls.Add(Label6)
        Controls.Add(Label5)
        Name = "UC_C_Modificar"
        Size = New Size(678, 403)
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents MaskedTextBox6 As MaskedTextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents MaskedTextBox5 As MaskedTextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents MaskedTextBox4 As MaskedTextBox
    Friend WithEvents MaskedTextBox1 As MaskedTextBox
    Friend WithEvents MaskedTextBox3 As MaskedTextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents MaskedTextBox2 As MaskedTextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label

End Class
