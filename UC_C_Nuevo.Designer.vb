<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UC_C_Nuevo
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
        Me.MTB_RFC = New MaskedTextBox()
        Label7 = New Label()
        Button1 = New Button()
        MTB_Direccion = New MaskedTextBox()
        Label2 = New Label()
        MTB_Correo = New MaskedTextBox()
        MTB_Codigo = New MaskedTextBox()
        MTB_Telefono = New MaskedTextBox()
        Label3 = New Label()
        MTB_Nombre = New MaskedTextBox()
        Label4 = New Label()
        Label6 = New Label()
        Label5 = New Label()
        Panel_Form.SuspendLayout()
        SuspendLayout()
        ' 
        ' Panel_Form
        ' 
        Panel_Form.Anchor = AnchorStyles.None
        Panel_Form.AutoScroll = True
        Panel_Form.Controls.Add(Me.MTB_RFC)
        Panel_Form.Controls.Add(Label7)
        Panel_Form.Controls.Add(Button1)
        Panel_Form.Controls.Add(MTB_Direccion)
        Panel_Form.Controls.Add(Label2)
        Panel_Form.Controls.Add(MTB_Correo)
        Panel_Form.Controls.Add(MTB_Codigo)
        Panel_Form.Controls.Add(MTB_Telefono)
        Panel_Form.Controls.Add(Label3)
        Panel_Form.Controls.Add(MTB_Nombre)
        Panel_Form.Controls.Add(Label4)
        Panel_Form.Controls.Add(Label6)
        Panel_Form.Controls.Add(Label5)
        Panel_Form.Location = New Point(3, 3)
        Panel_Form.Name = "Panel_Form"
        Panel_Form.Size = New Size(694, 444)
        Panel_Form.TabIndex = 4
        ' 
        ' MTB_RFC
        ' 
        Me.MTB_RFC.Font = New Font("Segoe UI", 12F)
        Me.MTB_RFC.Location = New Point(262, 300)
        Me.MTB_RFC.Name = "MTB_RFC"
        Me.MTB_RFC.Size = New Size(201, 29)
        Me.MTB_RFC.TabIndex = 66
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Font = New Font("Segoe UI", 12F)
        Label7.Location = New Point(88, 300)
        Label7.Name = "Label7"
        Label7.Size = New Size(38, 21)
        Label7.TabIndex = 65
        Label7.Text = "RFC"
        ' 
        ' Button1
        ' 
        Button1.Font = New Font("Segoe UI", 12F)
        Button1.Location = New Point(306, 352)
        Button1.Name = "Button1"
        Button1.Size = New Size(122, 30)
        Button1.TabIndex = 56
        Button1.Text = "Agregar"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' MTB_Direccion
        ' 
        MTB_Direccion.Font = New Font("Segoe UI", 12F)
        MTB_Direccion.Location = New Point(262, 248)
        MTB_Direccion.Name = "MTB_Direccion"
        MTB_Direccion.Size = New Size(202, 29)
        MTB_Direccion.TabIndex = 64
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 12F)
        Label2.Location = New Point(88, 38)
        Label2.Name = "Label2"
        Label2.Size = New Size(60, 21)
        Label2.TabIndex = 54
        Label2.Text = "Código"
        ' 
        ' MTB_Correo
        ' 
        MTB_Correo.Font = New Font("Segoe UI", 12F)
        MTB_Correo.Location = New Point(262, 195)
        MTB_Correo.Name = "MTB_Correo"
        MTB_Correo.Size = New Size(202, 29)
        MTB_Correo.TabIndex = 63
        ' 
        ' MTB_Codigo
        ' 
        MTB_Codigo.Font = New Font("Segoe UI", 12F)
        MTB_Codigo.Location = New Point(262, 38)
        MTB_Codigo.Name = "MTB_Codigo"
        MTB_Codigo.Size = New Size(202, 29)
        MTB_Codigo.TabIndex = 55
        ' 
        ' MTB_Telefono
        ' 
        MTB_Telefono.Font = New Font("Segoe UI", 12F)
        MTB_Telefono.Location = New Point(262, 142)
        MTB_Telefono.Name = "MTB_Telefono"
        MTB_Telefono.Size = New Size(202, 29)
        MTB_Telefono.TabIndex = 62
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 12F)
        Label3.Location = New Point(88, 142)
        Label3.Name = "Label3"
        Label3.Size = New Size(68, 21)
        Label3.TabIndex = 57
        Label3.Text = "Telefono"
        ' 
        ' MTB_Nombre
        ' 
        MTB_Nombre.Font = New Font("Segoe UI", 12F)
        MTB_Nombre.Location = New Point(262, 90)
        MTB_Nombre.Name = "MTB_Nombre"
        MTB_Nombre.Size = New Size(202, 29)
        MTB_Nombre.TabIndex = 61
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Segoe UI", 12F)
        Label4.Location = New Point(88, 90)
        Label4.Name = "Label4"
        Label4.Size = New Size(68, 21)
        Label4.TabIndex = 58
        Label4.Text = "Nombre"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Segoe UI", 12F)
        Label6.Location = New Point(88, 248)
        Label6.Name = "Label6"
        Label6.Size = New Size(75, 21)
        Label6.TabIndex = 60
        Label6.Text = "Dirección"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Segoe UI", 12F)
        Label5.Location = New Point(88, 195)
        Label5.Name = "Label5"
        Label5.Size = New Size(58, 21)
        Label5.TabIndex = 59
        Label5.Text = "Correo"
        ' 
        ' UC_C_Nuevo
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        Controls.Add(Panel_Form)
        Name = "UC_C_Nuevo"
        Size = New Size(694, 444)
        Panel_Form.ResumeLayout(False)
        Panel_Form.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents Panel_Form As Panel
    Friend WithEvents MTB_RFC As MaskedTextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents MTB_Direccion As MaskedTextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents MTB_Correo As MaskedTextBox
    Friend WithEvents MTB_Codigo As MaskedTextBox
    Friend WithEvents MTB_Telefono As MaskedTextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents MTB_Nombre As MaskedTextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label

End Class
