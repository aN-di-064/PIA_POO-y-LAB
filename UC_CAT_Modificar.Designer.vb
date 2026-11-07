<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UC_CAT_Modificar
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
        MTB_Codigo = New MaskedTextBox()
        MTB_Nombre = New MaskedTextBox()
        Button_Buscar = New Button()
        Button1 = New Button()
        Label2 = New Label()
        Label4 = New Label()
        SuspendLayout()
        ' 
        ' MTB_Codigo
        ' 
        MTB_Codigo.Font = New Font("Segoe UI", 12F)
        MTB_Codigo.Location = New Point(236, 50)
        MTB_Codigo.Name = "MTB_Codigo"
        MTB_Codigo.Size = New Size(202, 29)
        MTB_Codigo.TabIndex = 84
        ' 
        ' MTB_Nombre
        ' 
        MTB_Nombre.Font = New Font("Segoe UI", 12F)
        MTB_Nombre.Location = New Point(236, 102)
        MTB_Nombre.Name = "MTB_Nombre"
        MTB_Nombre.Size = New Size(202, 29)
        MTB_Nombre.TabIndex = 85
        ' 
        ' Button_Buscar
        ' 
        Button_Buscar.Font = New Font("Segoe UI", 12F)
        Button_Buscar.Location = New Point(456, 50)
        Button_Buscar.Name = "Button_Buscar"
        Button_Buscar.Size = New Size(175, 26)
        Button_Buscar.TabIndex = 83
        Button_Buscar.Text = "Buscar categoria"
        Button_Buscar.UseVisualStyleBackColor = True
        ' 
        ' Button1
        ' 
        Button1.Font = New Font("Segoe UI", 12F)
        Button1.Location = New Point(281, 364)
        Button1.Name = "Button1"
        Button1.Size = New Size(122, 30)
        Button1.TabIndex = 77
        Button1.Text = "Modificar"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 12F)
        Label2.Location = New Point(63, 50)
        Label2.Name = "Label2"
        Label2.Size = New Size(60, 21)
        Label2.TabIndex = 76
        Label2.Text = "Código"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Segoe UI", 12F)
        Label4.Location = New Point(63, 102)
        Label4.Name = "Label4"
        Label4.Size = New Size(68, 21)
        Label4.TabIndex = 79
        Label4.Text = "Nombre"
        ' 
        ' UC_CAT_Modificar
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        Controls.Add(MTB_Codigo)
        Controls.Add(MTB_Nombre)
        Controls.Add(Button_Buscar)
        Controls.Add(Button1)
        Controls.Add(Label2)
        Controls.Add(Label4)
        Name = "UC_CAT_Modificar"
        Size = New Size(694, 444)
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents MTB_Codigo As MaskedTextBox
    Friend WithEvents MTB_Nombre As MaskedTextBox
    Friend WithEvents Button_Buscar As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Label4 As Label

End Class
