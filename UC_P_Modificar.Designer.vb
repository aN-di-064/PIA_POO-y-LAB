<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UC_P_Modificar
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
        MTB_Telefono = New MaskedTextBox()
        MTB_Direccion = New MaskedTextBox()
        Label2 = New Label()
        Label5 = New Label()
        Label4 = New Label()
        MTB_Codigo = New MaskedTextBox()
        Label6 = New Label()
        MTB_Nombre = New MaskedTextBox()
        Button1 = New Button()
        Panel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.Anchor = AnchorStyles.None
        Panel1.AutoScroll = True
        Panel1.Controls.Add(Button1)
        Panel1.Controls.Add(Button_Buscar)
        Panel1.Controls.Add(MTB_Telefono)
        Panel1.Controls.Add(MTB_Direccion)
        Panel1.Controls.Add(Label2)
        Panel1.Controls.Add(Label5)
        Panel1.Controls.Add(Label4)
        Panel1.Controls.Add(MTB_Codigo)
        Panel1.Controls.Add(Label6)
        Panel1.Controls.Add(MTB_Nombre)
        Panel1.Location = New Point(8, 8)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(694, 444)
        Panel1.TabIndex = 8
        ' 
        ' Button_Buscar
        ' 
        Button_Buscar.Font = New Font("Segoe UI", 12F)
        Button_Buscar.Location = New Point(455, 40)
        Button_Buscar.Name = "Button_Buscar"
        Button_Buscar.Size = New Size(175, 26)
        Button_Buscar.TabIndex = 81
        Button_Buscar.Text = "Buscar Proveedor"
        Button_Buscar.UseVisualStyleBackColor = True
        ' 
        ' MTB_Telefono
        ' 
        MTB_Telefono.Font = New Font("Segoe UI", 12F)
        MTB_Telefono.Location = New Point(234, 222)
        MTB_Telefono.Name = "MTB_Telefono"
        MTB_Telefono.Size = New Size(205, 29)
        MTB_Telefono.TabIndex = 83
        ' 
        ' MTB_Direccion
        ' 
        MTB_Direccion.Font = New Font("Segoe UI", 12F)
        MTB_Direccion.Location = New Point(234, 157)
        MTB_Direccion.Name = "MTB_Direccion"
        MTB_Direccion.Size = New Size(205, 29)
        MTB_Direccion.TabIndex = 82
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 12F)
        Label2.Location = New Point(60, 45)
        Label2.Name = "Label2"
        Label2.Size = New Size(60, 21)
        Label2.TabIndex = 69
        Label2.Text = "Código"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Segoe UI", 12F)
        Label5.Location = New Point(60, 230)
        Label5.Name = "Label5"
        Label5.Size = New Size(68, 21)
        Label5.TabIndex = 74
        Label5.Text = "Telefono"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Segoe UI", 12F)
        Label4.Location = New Point(60, 94)
        Label4.Name = "Label4"
        Label4.Size = New Size(68, 21)
        Label4.TabIndex = 73
        Label4.Text = "Nombre"
        ' 
        ' MTB_Codigo
        ' 
        MTB_Codigo.Font = New Font("Segoe UI", 12F)
        MTB_Codigo.Location = New Point(234, 39)
        MTB_Codigo.Name = "MTB_Codigo"
        MTB_Codigo.Size = New Size(205, 29)
        MTB_Codigo.TabIndex = 70
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Segoe UI", 12F)
        Label6.Location = New Point(60, 165)
        Label6.Name = "Label6"
        Label6.Size = New Size(75, 21)
        Label6.TabIndex = 75
        Label6.Text = "Direccion"
        ' 
        ' MTB_Nombre
        ' 
        MTB_Nombre.Font = New Font("Segoe UI", 12F)
        MTB_Nombre.Location = New Point(234, 94)
        MTB_Nombre.Name = "MTB_Nombre"
        MTB_Nombre.Size = New Size(205, 29)
        MTB_Nombre.TabIndex = 76
        ' 
        ' Button1
        ' 
        Button1.Font = New Font("Segoe UI", 12F)
        Button1.Location = New Point(275, 384)
        Button1.Name = "Button1"
        Button1.Size = New Size(122, 30)
        Button1.TabIndex = 71
        Button1.Text = "Modificar"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' UC_P_Modificar
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        Controls.Add(Panel1)
        Name = "UC_P_Modificar"
        Size = New Size(694, 444)
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Button_Buscar As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents MTB_Codigo As MaskedTextBox
    Friend WithEvents MTB_Nombre As MaskedTextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents MTB_Telefono As MaskedTextBox
    Friend WithEvents MTB_Direccion As MaskedTextBox

End Class
