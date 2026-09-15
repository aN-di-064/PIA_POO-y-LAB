<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UC_I_Nuevo
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
        Panel_Form = New Panel()
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
        Panel_Form.SuspendLayout()
        SuspendLayout()
        ' 
        ' Panel_Form
        ' 
        Panel_Form.Controls.Add(Label1)
        Panel_Form.Controls.Add(Button1)
        Panel_Form.Controls.Add(MaskedTextBox5)
        Panel_Form.Controls.Add(Label2)
        Panel_Form.Controls.Add(MaskedTextBox4)
        Panel_Form.Controls.Add(MaskedTextBox1)
        Panel_Form.Controls.Add(MaskedTextBox3)
        Panel_Form.Controls.Add(Label3)
        Panel_Form.Controls.Add(MaskedTextBox2)
        Panel_Form.Controls.Add(Label4)
        Panel_Form.Controls.Add(Label6)
        Panel_Form.Controls.Add(Label5)
        Panel_Form.Dock = DockStyle.Fill
        Panel_Form.Location = New Point(0, 0)
        Panel_Form.Name = "Panel_Form"
        Panel_Form.Size = New Size(678, 403)
        Panel_Form.TabIndex = 0
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(252, 32)
        Label1.Name = "Label1"
        Label1.Size = New Size(139, 15)
        Label1.TabIndex = 24
        Label1.Text = "Agregar Nuevo Producto"
        ' 
        ' Button1
        ' 
        Button1.Location = New Point(510, 339)
        Button1.Name = "Button1"
        Button1.Size = New Size(75, 23)
        Button1.TabIndex = 27
        Button1.Text = "Agregar"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' MaskedTextBox5
        ' 
        MaskedTextBox5.Location = New Point(219, 294)
        MaskedTextBox5.Name = "MaskedTextBox5"
        MaskedTextBox5.Size = New Size(201, 23)
        MaskedTextBox5.TabIndex = 35
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(129, 107)
        Label2.Name = "Label2"
        Label2.Size = New Size(46, 15)
        Label2.TabIndex = 25
        Label2.Text = "Código"
        ' 
        ' MaskedTextBox4
        ' 
        MaskedTextBox4.Location = New Point(219, 249)
        MaskedTextBox4.Name = "MaskedTextBox4"
        MaskedTextBox4.Size = New Size(201, 23)
        MaskedTextBox4.TabIndex = 34
        ' 
        ' MaskedTextBox1
        ' 
        MaskedTextBox1.Location = New Point(219, 104)
        MaskedTextBox1.Name = "MaskedTextBox1"
        MaskedTextBox1.Size = New Size(201, 23)
        MaskedTextBox1.TabIndex = 26
        ' 
        ' MaskedTextBox3
        ' 
        MaskedTextBox3.Location = New Point(219, 198)
        MaskedTextBox3.Name = "MaskedTextBox3"
        MaskedTextBox3.Size = New Size(201, 23)
        MaskedTextBox3.TabIndex = 33
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(129, 206)
        Label3.Name = "Label3"
        Label3.Size = New Size(61, 15)
        Label3.TabIndex = 28
        Label3.Text = "Proveedor"
        ' 
        ' MaskedTextBox2
        ' 
        MaskedTextBox2.Location = New Point(219, 156)
        MaskedTextBox2.Name = "MaskedTextBox2"
        MaskedTextBox2.Size = New Size(201, 23)
        MaskedTextBox2.TabIndex = 32
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(129, 156)
        Label4.Name = "Label4"
        Label4.Size = New Size(69, 15)
        Label4.TabIndex = 29
        Label4.Text = "Descripción"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Location = New Point(129, 302)
        Label6.Name = "Label6"
        Label6.Size = New Size(64, 15)
        Label6.TabIndex = 31
        Label6.Text = "Existencias"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(129, 252)
        Label5.Name = "Label5"
        Label5.Size = New Size(58, 15)
        Label5.TabIndex = 30
        Label5.Text = "Categoría"
        ' 
        ' UC_I_Nuevo
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        Controls.Add(Panel_Form)
        Name = "UC_I_Nuevo"
        Size = New Size(678, 403)
        Panel_Form.ResumeLayout(False)
        Panel_Form.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents Panel_Form As Panel
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
