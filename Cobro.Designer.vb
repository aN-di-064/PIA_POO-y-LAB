<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Cobro
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Label1 = New Label()
        TXT_TOTAL = New TextBox()
        Label2 = New Label()
        Button1 = New Button()
        Label3 = New Label()
        TXT_DR = New TextBox()
        Label4 = New Label()
        TXT_CAMBIO = New TextBox()
        TableLayoutPanel1 = New TableLayoutPanel()
        Panel1 = New Panel()
        CheckBox1 = New CheckBox()
        TableLayoutPanel1.SuspendLayout()
        Panel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(0, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(0, 15)
        Label1.TabIndex = 0
        ' 
        ' TXT_TOTAL
        ' 
        TXT_TOTAL.BackColor = Color.White
        TXT_TOTAL.Font = New Font("Segoe UI", 12.0F)
        TXT_TOTAL.Location = New Point(170, 38)
        TXT_TOTAL.Name = "TXT_TOTAL"
        TXT_TOTAL.ReadOnly = True
        TXT_TOTAL.Size = New Size(150, 29)
        TXT_TOTAL.TabIndex = 1
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 12.0F)
        Label2.Location = New Point(22, 38)
        Label2.Name = "Label2"
        Label2.Size = New Size(45, 21)
        Label2.TabIndex = 2
        Label2.Text = "Total:"
        ' 
        ' Button1
        ' 
        Button1.Font = New Font("Segoe UI", 12.0F)
        Button1.Location = New Point(109, 256)
        Button1.Name = "Button1"
        Button1.Size = New Size(122, 30)
        Button1.TabIndex = 3
        Button1.Text = "Confirmar"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 12.0F)
        Label3.Location = New Point(22, 83)
        Label3.Name = "Label3"
        Label3.Size = New Size(120, 21)
        Label3.TabIndex = 5
        Label3.Text = "Dinero recibido:"
        ' 
        ' TXT_DR
        ' 
        TXT_DR.Font = New Font("Segoe UI", 12.0F)
        TXT_DR.Location = New Point(170, 83)
        TXT_DR.Name = "TXT_DR"
        TXT_DR.Size = New Size(150, 29)
        TXT_DR.TabIndex = 4
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Segoe UI", 12.0F)
        Label4.Location = New Point(22, 128)
        Label4.Name = "Label4"
        Label4.Size = New Size(64, 21)
        Label4.TabIndex = 7
        Label4.Text = "Cambio"
        ' 
        ' TXT_CAMBIO
        ' 
        TXT_CAMBIO.BackColor = Color.White
        TXT_CAMBIO.Font = New Font("Segoe UI", 12.0F)
        TXT_CAMBIO.Location = New Point(170, 128)
        TXT_CAMBIO.Name = "TXT_CAMBIO"
        TXT_CAMBIO.ReadOnly = True
        TXT_CAMBIO.Size = New Size(150, 29)
        TXT_CAMBIO.TabIndex = 6
        ' 
        ' TableLayoutPanel1
        ' 
        TableLayoutPanel1.ColumnCount = 1
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50.0F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50.0F))
        TableLayoutPanel1.Controls.Add(Panel1, 0, 0)
        TableLayoutPanel1.Dock = DockStyle.Fill
        TableLayoutPanel1.Location = New Point(0, 0)
        TableLayoutPanel1.Margin = New Padding(3, 2, 3, 2)
        TableLayoutPanel1.Name = "TableLayoutPanel1"
        TableLayoutPanel1.RowCount = 1
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 50.0F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 50.0F))
        TableLayoutPanel1.Size = New Size(424, 346)
        TableLayoutPanel1.TabIndex = 8
        ' 
        ' Panel1
        ' 
        Panel1.Anchor = AnchorStyles.None
        Panel1.BackColor = Color.White
        Panel1.Controls.Add(CheckBox1)
        Panel1.Controls.Add(Button1)
        Panel1.Controls.Add(TXT_CAMBIO)
        Panel1.Controls.Add(Label4)
        Panel1.Controls.Add(TXT_DR)
        Panel1.Controls.Add(Label2)
        Panel1.Controls.Add(Label3)
        Panel1.Controls.Add(TXT_TOTAL)
        Panel1.Location = New Point(37, 23)
        Panel1.Margin = New Padding(3, 2, 3, 2)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(350, 300)
        Panel1.TabIndex = 0
        ' 
        ' CheckBox1
        ' 
        CheckBox1.AutoSize = True
        CheckBox1.Location = New Point(125, 201)
        CheckBox1.Name = "CheckBox1"
        CheckBox1.Size = New Size(106, 19)
        CheckBox1.TabIndex = 9
        CheckBox1.Text = "Imprimir Ticket"
        CheckBox1.UseVisualStyleBackColor = True
        ' 
        ' Cobro
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(424, 346)
        Controls.Add(Label1)
        Controls.Add(TableLayoutPanel1)
        MaximizeBox = False
        MaximumSize = New Size(440, 385)
        MinimizeBox = False
        MinimumSize = New Size(440, 385)
        Name = "Cobro"
        Text = "Cobro"
        TableLayoutPanel1.ResumeLayout(False)
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents TXT_TOTAL As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents TXT_DR As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents TXT_CAMBIO As TextBox
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents CheckBox1 As CheckBox
End Class