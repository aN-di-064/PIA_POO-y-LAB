<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class UC_Inventario
    Inherits System.Windows.Forms.UserControl

    'UserControl reemplaza a Dispose para limpiar la lista de componentes.
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
        Panel1 = New TableLayoutPanel()
        Panel_de_contenido = New Panel()
        Panel_de_botones = New Panel()
        BTN_NEW = New Button()
        BTN_MOD = New Button()
        BTN_DEL = New Button()
        BTN_CAT = New Button()
        Label1 = New Label()
        Panel2 = New Panel()
        Panel1.SuspendLayout()
        Panel_de_botones.SuspendLayout()
        Panel2.SuspendLayout()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.ColumnCount = 1
        Panel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100.0F))
        Panel1.Controls.Add(Panel2, 0, 0)
        Panel1.Dock = DockStyle.Fill
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.RowCount = 1
        Panel1.RowStyles.Add(New RowStyle(SizeType.Percent, 100.0F))
        Panel1.Size = New Size(1120, 540)
        Panel1.TabIndex = 0
        ' 
        ' Panel_de_contenido
        ' 
        Panel_de_contenido.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        Panel_de_contenido.AutoScroll = True
        Panel_de_contenido.Location = New Point(26, 90)
        Panel_de_contenido.Name = "Panel_de_contenido"
        Panel_de_contenido.Size = New Size(858, 405)
        Panel_de_contenido.TabIndex = 0
        ' 
        ' Panel_de_botones
        ' 
        Panel_de_botones.Anchor = AnchorStyles.Left Or AnchorStyles.Right
        Panel_de_botones.BackColor = Color.LightGray
        Panel_de_botones.Controls.Add(BTN_CAT)
        Panel_de_botones.Controls.Add(BTN_DEL)
        Panel_de_botones.Controls.Add(BTN_MOD)
        Panel_de_botones.Controls.Add(BTN_NEW)
        Panel_de_botones.Location = New Point(26, 45)
        Panel_de_botones.Name = "Panel_de_botones"
        Panel_de_botones.Size = New Size(858, 45)
        Panel_de_botones.TabIndex = 0
        ' 
        ' BTN_NEW
        ' 
        BTN_NEW.Font = New Font("Segoe UI", 12.0F)
        BTN_NEW.Location = New Point(65, 9)
        BTN_NEW.Name = "BTN_NEW"
        BTN_NEW.Size = New Size(122, 30)
        BTN_NEW.TabIndex = 0
        BTN_NEW.Text = "Agregar"
        BTN_NEW.UseVisualStyleBackColor = True
        ' 
        ' BTN_MOD
        ' 
        BTN_MOD.Font = New Font("Segoe UI", 12.0F)
        BTN_MOD.Location = New Point(278, 9)
        BTN_MOD.Name = "BTN_MOD"
        BTN_MOD.Size = New Size(122, 30)
        BTN_MOD.TabIndex = 1
        BTN_MOD.Text = "Modificar"
        BTN_MOD.UseVisualStyleBackColor = True
        ' 
        ' BTN_DEL
        ' 
        BTN_DEL.Font = New Font("Segoe UI", 12.0F)
        BTN_DEL.Location = New Point(491, 9)
        BTN_DEL.Name = "BTN_DEL"
        BTN_DEL.Size = New Size(122, 30)
        BTN_DEL.TabIndex = 2
        BTN_DEL.Text = "Eliminar"
        BTN_DEL.UseVisualStyleBackColor = True
        ' 
        ' BTN_CAT
        ' 
        BTN_CAT.Font = New Font("Segoe UI", 12.0F)
        BTN_CAT.Location = New Point(704, 9)
        BTN_CAT.Name = "BTN_CAT"
        BTN_CAT.Size = New Size(122, 30)
        BTN_CAT.TabIndex = 3
        BTN_CAT.Text = "Categoría"
        BTN_CAT.UseVisualStyleBackColor = True
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 16.0F, FontStyle.Bold)
        Label1.Location = New Point(26, 10)
        Label1.Name = "Label1"
        Label1.Size = New Size(119, 30)
        Label1.TabIndex = 1
        Label1.Text = "Inventario"
        ' 
        ' Panel2
        ' 
        Panel2.Anchor = AnchorStyles.None
        Panel2.BackColor = Color.White
        Panel2.Controls.Add(Label1)
        Panel2.Controls.Add(Panel_de_botones)
        Panel2.Controls.Add(Panel_de_contenido)
        Panel2.Location = New Point(105, 7)
        Panel2.Margin = New Padding(3, 2, 3, 2)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(910, 525)
        Panel2.TabIndex = 0
        ' 
        ' UC_Inventario
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        Controls.Add(Panel1)
        Name = "UC_Inventario"
        Size = New Size(1120, 540)
        Panel1.ResumeLayout(False)
        Panel_de_botones.ResumeLayout(False)
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents Panel1 As TableLayoutPanel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel_de_botones As Panel
    Friend WithEvents BTN_CAT As Button
    Friend WithEvents BTN_DEL As Button
    Friend WithEvents BTN_MOD As Button
    Friend WithEvents BTN_NEW As Button
    Friend WithEvents Panel_de_contenido As Panel
End Class