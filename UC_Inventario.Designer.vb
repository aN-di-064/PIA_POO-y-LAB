<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UC_Inventario
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
        PANEL_IZQUIERDO = New Panel()
        BTN_CAT = New Button()
        BTN_DEL = New Button()
        BTN_MOD = New Button()
        BTN_NEW = New Button()
        PANEL_DERECHO = New Panel()
        PANEL_IZQUIERDO.SuspendLayout()
        SuspendLayout()
        ' 
        ' PANEL_IZQUIERDO
        ' 
        PANEL_IZQUIERDO.Controls.Add(BTN_CAT)
        PANEL_IZQUIERDO.Controls.Add(BTN_DEL)
        PANEL_IZQUIERDO.Controls.Add(BTN_MOD)
        PANEL_IZQUIERDO.Controls.Add(BTN_NEW)
        PANEL_IZQUIERDO.Dock = DockStyle.Left
        PANEL_IZQUIERDO.Location = New Point(0, 0)
        PANEL_IZQUIERDO.Name = "PANEL_IZQUIERDO"
        PANEL_IZQUIERDO.Size = New Size(203, 445)
        PANEL_IZQUIERDO.TabIndex = 1
        ' 
        ' BTN_CAT
        ' 
        BTN_CAT.Location = New Point(29, 264)
        BTN_CAT.Name = "BTN_CAT"
        BTN_CAT.Size = New Size(127, 23)
        BTN_CAT.TabIndex = 3
        BTN_CAT.Text = "Categoria"
        BTN_CAT.UseVisualStyleBackColor = True
        ' 
        ' BTN_DEL
        ' 
        BTN_DEL.Location = New Point(29, 200)
        BTN_DEL.Name = "BTN_DEL"
        BTN_DEL.Size = New Size(127, 23)
        BTN_DEL.TabIndex = 2
        BTN_DEL.Text = "Eliminar"
        BTN_DEL.UseVisualStyleBackColor = True
        ' 
        ' BTN_MOD
        ' 
        BTN_MOD.Location = New Point(29, 138)
        BTN_MOD.Name = "BTN_MOD"
        BTN_MOD.Size = New Size(127, 23)
        BTN_MOD.TabIndex = 1
        BTN_MOD.Text = "Modificar"
        BTN_MOD.UseVisualStyleBackColor = True
        ' 
        ' BTN_NEW
        ' 
        BTN_NEW.Location = New Point(29, 80)
        BTN_NEW.Name = "BTN_NEW"
        BTN_NEW.Size = New Size(127, 25)
        BTN_NEW.TabIndex = 0
        BTN_NEW.Text = "Nuevo"
        BTN_NEW.UseVisualStyleBackColor = True
        ' 
        ' PANEL_DERECHO
        ' 
        PANEL_DERECHO.Dock = DockStyle.Fill
        PANEL_DERECHO.Location = New Point(203, 0)
        PANEL_DERECHO.Name = "PANEL_DERECHO"
        PANEL_DERECHO.Size = New Size(556, 445)
        PANEL_DERECHO.TabIndex = 2
        ' 
        ' UC_Inventario
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        Controls.Add(PANEL_DERECHO)
        Controls.Add(PANEL_IZQUIERDO)
        Name = "UC_Inventario"
        Size = New Size(759, 445)
        PANEL_IZQUIERDO.ResumeLayout(False)
        ResumeLayout(False)
    End Sub
    Friend WithEvents PANEL_IZQUIERDO As Panel
    Friend WithEvents BTN_CAT As Button
    Friend WithEvents BTN_DEL As Button
    Friend WithEvents BTN_MOD As Button
    Friend WithEvents BTN_NEW As Button
    Friend WithEvents PANEL_DERECHO As Panel

End Class
