<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UC_Cliente
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
        TableLayoutPanel1 = New TableLayoutPanel()
        Panel1 = New Panel()
        Label1 = New Label()
        Panel_de_contenido = New Panel()
        Panel3 = New Panel()
        BTN_DEL = New Button()
        BTN_MOD = New Button()
        BTN_NEW = New Button()
        TableLayoutPanel1.SuspendLayout()
        Panel1.SuspendLayout()
        Panel3.SuspendLayout()
        SuspendLayout()
        ' 
        ' TableLayoutPanel1
        ' 
        TableLayoutPanel1.ColumnCount = 1
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        TableLayoutPanel1.Controls.Add(Panel1, 0, 0)
        TableLayoutPanel1.Dock = DockStyle.Fill
        TableLayoutPanel1.Location = New Point(0, 0)
        TableLayoutPanel1.Name = "TableLayoutPanel1"
        TableLayoutPanel1.RowCount = 1
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 50F))
        TableLayoutPanel1.Size = New Size(1120, 540)
        TableLayoutPanel1.TabIndex = 0
        ' 
        ' Panel1
        ' 
        Panel1.Anchor = AnchorStyles.None
        Panel1.BackColor = Color.White
        Panel1.Controls.Add(Label1)
        Panel1.Controls.Add(Panel_de_contenido)
        Panel1.Controls.Add(Panel3)
        Panel1.Location = New Point(105, 7)
        Panel1.Margin = New Padding(3, 2, 3, 2)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(910, 525)
        Panel1.TabIndex = 0
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 16F, FontStyle.Bold)
        Label1.Location = New Point(26, 10)
        Label1.Name = "Label1"
        Label1.Size = New Size(95, 30)
        Label1.TabIndex = 2
        Label1.Text = "Clientes"
        ' 
        ' Panel_de_contenido
        ' 
        Panel_de_contenido.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        Panel_de_contenido.AutoScroll = True
        Panel_de_contenido.Location = New Point(26, 90)
        Panel_de_contenido.Name = "Panel_de_contenido"
        Panel_de_contenido.Size = New Size(858, 405)
        Panel_de_contenido.TabIndex = 4
        ' 
        ' Panel3
        ' 
        Panel3.Anchor = AnchorStyles.Left Or AnchorStyles.Right
        Panel3.BackColor = Color.LightGray
        Panel3.Controls.Add(BTN_DEL)
        Panel3.Controls.Add(BTN_MOD)
        Panel3.Controls.Add(BTN_NEW)
        Panel3.Location = New Point(26, 45)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(858, 45)
        Panel3.TabIndex = 3
        ' 
        ' BTN_DEL
        ' 
        BTN_DEL.Font = New Font("Segoe UI", 12F)
        BTN_DEL.Location = New Point(711, 9)
        BTN_DEL.Name = "BTN_DEL"
        BTN_DEL.Size = New Size(122, 30)
        BTN_DEL.TabIndex = 2
        BTN_DEL.Text = "Eliminar"
        BTN_DEL.UseVisualStyleBackColor = True
        ' 
        ' BTN_MOD
        ' 
        BTN_MOD.Font = New Font("Segoe UI", 12F)
        BTN_MOD.Location = New Point(389, 9)
        BTN_MOD.Name = "BTN_MOD"
        BTN_MOD.Size = New Size(122, 30)
        BTN_MOD.TabIndex = 1
        BTN_MOD.Text = "Modificar"
        BTN_MOD.UseVisualStyleBackColor = True
        ' 
        ' BTN_NEW
        ' 
        BTN_NEW.Font = New Font("Segoe UI", 12F)
        BTN_NEW.Location = New Point(79, 9)
        BTN_NEW.Name = "BTN_NEW"
        BTN_NEW.Size = New Size(122, 30)
        BTN_NEW.TabIndex = 0
        BTN_NEW.Text = "Agregar"
        BTN_NEW.UseVisualStyleBackColor = True
        ' 
        ' UC_Cliente
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        Controls.Add(TableLayoutPanel1)
        Name = "UC_Cliente"
        Size = New Size(1120, 540)
        TableLayoutPanel1.ResumeLayout(False)
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        Panel3.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents BTN_DEL As Button
    Friend WithEvents BTN_MOD As Button
    Friend WithEvents BTN_NEW As Button
    Friend WithEvents Panel_de_contenido As Panel
    Friend WithEvents Label1 As Label

End Class
