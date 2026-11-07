<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UC_P_Eliminar
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
        Panel1 = New Panel()
        Button_Buscar = New Button()
        Button1 = New Button()
        Label2 = New Label()
        Label1 = New Label()
        MTB_Codigo = New MaskedTextBox()
        MTB_Nombre = New MaskedTextBox()
        MTB_Direccion = New MaskedTextBox()
        MTB_Telefono = New MaskedTextBox()
        Label5 = New Label()
        Label6 = New Label()
        Panel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.Anchor = AnchorStyles.None
        Panel1.AutoScroll = True
        Panel1.Controls.Add(Button_Buscar)
        Panel1.Controls.Add(Button1)
        Panel1.Controls.Add(Label2)
        Panel1.Controls.Add(Label1)
        Panel1.Controls.Add(MTB_Codigo)
        Panel1.Controls.Add(MTB_Nombre)
        Panel1.Controls.Add(MTB_Direccion)
        Panel1.Controls.Add(MTB_Telefono)
        Panel1.Controls.Add(Label5)
        Panel1.Controls.Add(Label6)
        Panel1.Location = New Point(8, 8)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(694, 444)
        Panel1.TabIndex = 11
        ' 
        ' Button_Buscar
        ' 
        Button_Buscar.Font = New Font("Segoe UI", 12F)
        Button_Buscar.Location = New Point(478, 51)
        Button_Buscar.Name = "Button_Buscar"
        Button_Buscar.Size = New Size(175, 26)
        Button_Buscar.TabIndex = 84
        Button_Buscar.Text = "Buscar Proveedor"
        Button_Buscar.UseVisualStyleBackColor = True
        ' 
        ' Button1
        ' 
        Button1.Font = New Font("Segoe UI", 12F)
        Button1.Location = New Point(274, 356)
        Button1.Name = "Button1"
        Button1.Size = New Size(122, 30)
        Button1.TabIndex = 83
        Button1.Text = "Eliminar"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 12F)
        Label2.Location = New Point(60, 114)
        Label2.Name = "Label2"
        Label2.Size = New Size(68, 21)
        Label2.TabIndex = 82
        Label2.Text = "Nombre"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 12F)
        Label1.Location = New Point(60, 62)
        Label1.Name = "Label1"
        Label1.Size = New Size(60, 21)
        Label1.TabIndex = 81
        Label1.Text = "Codigo"
        ' 
        ' MTB_Codigo
        ' 
        MTB_Codigo.Font = New Font("Segoe UI", 12F)
        MTB_Codigo.Location = New Point(234, 54)
        MTB_Codigo.Name = "MTB_Codigo"
        MTB_Codigo.Size = New Size(202, 29)
        MTB_Codigo.TabIndex = 80
        ' 
        ' MTB_Nombre
        ' 
        MTB_Nombre.Font = New Font("Segoe UI", 12F)
        MTB_Nombre.Location = New Point(234, 111)
        MTB_Nombre.Name = "MTB_Nombre"
        MTB_Nombre.Size = New Size(202, 29)
        MTB_Nombre.TabIndex = 79
        ' 
        ' MTB_Direccion
        ' 
        MTB_Direccion.Font = New Font("Segoe UI", 12F)
        MTB_Direccion.Location = New Point(234, 168)
        MTB_Direccion.Name = "MTB_Direccion"
        MTB_Direccion.Size = New Size(202, 29)
        MTB_Direccion.TabIndex = 77
        ' 
        ' MTB_Telefono
        ' 
        MTB_Telefono.Font = New Font("Segoe UI", 12F)
        MTB_Telefono.Location = New Point(234, 225)
        MTB_Telefono.Name = "MTB_Telefono"
        MTB_Telefono.Size = New Size(202, 29)
        MTB_Telefono.TabIndex = 78
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Segoe UI", 12F)
        Label5.Location = New Point(60, 225)
        Label5.Name = "Label5"
        Label5.Size = New Size(68, 21)
        Label5.TabIndex = 74
        Label5.Text = "Telefono"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Segoe UI", 12F)
        Label6.Location = New Point(60, 171)
        Label6.Name = "Label6"
        Label6.Size = New Size(75, 21)
        Label6.TabIndex = 75
        Label6.Text = "Direccion"
        ' 
        ' UC_P_Eliminar
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        Controls.Add(Panel1)
        Name = "UC_P_Eliminar"
        Size = New Size(694, 444)
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Button_Buscar As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents MTB_Codigo As MaskedTextBox
    Friend WithEvents MTB_Nombre As MaskedTextBox
    Friend WithEvents MTB_Direccion As MaskedTextBox
    Friend WithEvents MTB_Telefono As MaskedTextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label

End Class
