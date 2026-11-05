<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Form1Container = New TableLayoutPanel()
        Panel1 = New Panel()
        Label1 = New Label()
        Label2 = New Label()
        Button1 = New Button()
        TextBox2 = New TextBox()
        TextBox1 = New TextBox()
        Form1Container.SuspendLayout()
        Panel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' Form1Container
        ' 
        Form1Container.ColumnCount = 1
        Form1Container.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        Form1Container.Controls.Add(Panel1, 0, 0)
        Form1Container.Dock = DockStyle.Fill
        Form1Container.Location = New Point(0, 0)
        Form1Container.Name = "Form1Container"
        Form1Container.RowCount = 1
        Form1Container.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        Form1Container.Size = New Size(803, 457)
        Form1Container.TabIndex = 5
        ' 
        ' Panel1
        ' 
        Panel1.Anchor = AnchorStyles.None
        Panel1.BackColor = Color.White
        Panel1.Controls.Add(Label1)
        Panel1.Controls.Add(Label2)
        Panel1.Controls.Add(Button1)
        Panel1.Controls.Add(TextBox2)
        Panel1.Controls.Add(TextBox1)
        Panel1.Location = New Point(201, 28)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(400, 400)
        Panel1.TabIndex = 5
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 11F)
        Label1.Location = New Point(128, 67)
        Label1.Name = "Label1"
        Label1.Size = New Size(131, 20)
        Label1.TabIndex = 0
        Label1.Text = "Código de usuario"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 11F)
        Label2.Location = New Point(160, 160)
        Label2.Name = "Label2"
        Label2.Size = New Size(83, 20)
        Label2.TabIndex = 4
        Label2.Text = "Contraseña"
        ' 
        ' Button1
        ' 
        Button1.Font = New Font("Segoe UI", 11F)
        Button1.Location = New Point(141, 250)
        Button1.Name = "Button1"
        Button1.Size = New Size(118, 32)
        Button1.TabIndex = 1
        Button1.Text = "Ingresar"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' TextBox2
        ' 
        TextBox2.Location = New Point(98, 190)
        TextBox2.Name = "TextBox2"
        TextBox2.PasswordChar = "*"c
        TextBox2.Size = New Size(203, 23)
        TextBox2.TabIndex = 3
        ' 
        ' TextBox1
        ' 
        TextBox1.Location = New Point(98, 110)
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(203, 23)
        TextBox1.TabIndex = 2
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(803, 457)
        Controls.Add(Form1Container)
        MaximizeBox = False
        MinimizeBox = False
        Name = "Form1"
        Text = "Form1"
        Form1Container.ResumeLayout(False)
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents Form1Container As TableLayoutPanel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents TextBox2 As TextBox
End Class