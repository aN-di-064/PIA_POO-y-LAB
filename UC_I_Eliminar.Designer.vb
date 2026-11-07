<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class UC_I_Eliminar
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
        Panel1 = New Panel()
        CB_Proveedores = New ComboBox()
        Button_Prov = New Button()
        Label1 = New Label()
        Me.Button_Cat = New Button()
        CB_Cat = New ComboBox()
        Button_Buscar = New Button()
        MTB_Existencias = New MaskedTextBox()
        MTB_PVenta = New MaskedTextBox()
        Label7 = New Label()
        MTB_PCompra = New MaskedTextBox()
        MTB_Codigo = New MaskedTextBox()
        Label2 = New Label()
        MTB_Descripcion = New MaskedTextBox()
        Label3 = New Label()
        Label4 = New Label()
        Label6 = New Label()
        Label5 = New Label()
        Panel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.Anchor = AnchorStyles.None
        Panel1.AutoScroll = True
        Panel1.Controls.Add(CB_Proveedores)
        Panel1.Controls.Add(Button_Prov)
        Panel1.Controls.Add(Label1)
        Panel1.Controls.Add(Me.Button_Cat)
        Panel1.Controls.Add(CB_Cat)
        Panel1.Controls.Add(Button_Buscar)
        Panel1.Controls.Add(MTB_Existencias)
        Panel1.Controls.Add(MTB_PVenta)
        Panel1.Controls.Add(Label7)
        Panel1.Controls.Add(MTB_PCompra)
        Panel1.Controls.Add(MTB_Codigo)
        Panel1.Controls.Add(Label2)
        Panel1.Controls.Add(MTB_Descripcion)
        Panel1.Controls.Add(Label3)
        Panel1.Controls.Add(Label4)
        Panel1.Controls.Add(Label6)
        Panel1.Controls.Add(Label5)
        Panel1.Location = New Point(-8, -21)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(694, 444)
        Panel1.TabIndex = 8
        ' 
        ' CB_Proveedores
        ' 
        CB_Proveedores.FormattingEnabled = True
        CB_Proveedores.Location = New Point(256, 347)
        CB_Proveedores.Name = "CB_Proveedores"
        CB_Proveedores.Size = New Size(202, 23)
        CB_Proveedores.TabIndex = 90
        ' 
        ' Button_Prov
        ' 
        Button_Prov.Font = New Font("Segoe UI", 12.0F)
        Button_Prov.Location = New Point(482, 347)
        Button_Prov.Name = "Button_Prov"
        Button_Prov.Size = New Size(175, 26)
        Button_Prov.TabIndex = 89
        Button_Prov.Text = "Buscar Proveedor"
        Button_Prov.UseVisualStyleBackColor = True
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 12.0F)
        Label1.Location = New Point(90, 344)
        Label1.Name = "Label1"
        Label1.Size = New Size(97, 21)
        Label1.TabIndex = 87
        Label1.Text = "Proveedores"
        ' 
        ' Button_Cat
        ' 
        Me.Button_Cat.Font = New Font("Segoe UI", 12.0F)
        Me.Button_Cat.Location = New Point(481, 142)
        Me.Button_Cat.Name = "Button_Cat"
        Me.Button_Cat.Size = New Size(175, 26)
        Me.Button_Cat.TabIndex = 82
        Me.Button_Cat.Text = "Buscar Categoría"
        Me.Button_Cat.UseVisualStyleBackColor = True
        ' 
        ' CB_Cat
        ' 
        CB_Cat.FormattingEnabled = True
        CB_Cat.Location = New Point(257, 142)
        CB_Cat.Name = "CB_Cat"
        CB_Cat.Size = New Size(202, 23)
        CB_Cat.TabIndex = 81
        ' 
        ' Button_Buscar
        ' 
        Button_Buscar.Font = New Font("Segoe UI", 12.0F)
        Button_Buscar.Location = New Point(481, 38)
        Button_Buscar.Name = "Button_Buscar"
        Button_Buscar.Size = New Size(175, 26)
        Button_Buscar.TabIndex = 67
        Button_Buscar.Text = "Buscar Producto"
        Button_Buscar.UseVisualStyleBackColor = True
        ' 
        ' MTB_Existencias
        ' 
        MTB_Existencias.Font = New Font("Segoe UI", 12.0F)
        MTB_Existencias.Location = New Point(257, 292)
        MTB_Existencias.Name = "MTB_Existencias"
        MTB_Existencias.Size = New Size(201, 29)
        MTB_Existencias.TabIndex = 80
        ' 
        ' MTB_PVenta
        ' 
        MTB_PVenta.Font = New Font("Segoe UI", 12.0F)
        MTB_PVenta.Location = New Point(256, 240)
        MTB_PVenta.Name = "MTB_PVenta"
        MTB_PVenta.Size = New Size(202, 29)
        MTB_PVenta.TabIndex = 79
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Font = New Font("Segoe UI", 12.0F)
        Label7.Location = New Point(88, 293)
        Label7.Name = "Label7"
        Label7.Size = New Size(84, 21)
        Label7.TabIndex = 65
        Label7.Text = "Existencias"
        ' 
        ' MTB_PCompra
        ' 
        MTB_PCompra.Font = New Font("Segoe UI", 12.0F)
        MTB_PCompra.Location = New Point(256, 188)
        MTB_PCompra.Name = "MTB_PCompra"
        MTB_PCompra.Size = New Size(202, 29)
        MTB_PCompra.TabIndex = 78
        ' 
        ' MTB_Codigo
        ' 
        MTB_Codigo.Font = New Font("Segoe UI", 12.0F)
        MTB_Codigo.Location = New Point(256, 38)
        MTB_Codigo.Name = "MTB_Codigo"
        MTB_Codigo.Size = New Size(202, 29)
        MTB_Codigo.TabIndex = 76
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 12.0F)
        Label2.Location = New Point(88, 38)
        Label2.Name = "Label2"
        Label2.Size = New Size(60, 21)
        Label2.TabIndex = 54
        Label2.Text = "Código"
        ' 
        ' MTB_Descripcion
        ' 
        MTB_Descripcion.Font = New Font("Segoe UI", 12.0F)
        MTB_Descripcion.Location = New Point(256, 90)
        MTB_Descripcion.Name = "MTB_Descripcion"
        MTB_Descripcion.Size = New Size(202, 29)
        MTB_Descripcion.TabIndex = 77
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 12.0F)
        Label3.Location = New Point(88, 140)
        Label3.Name = "Label3"
        Label3.Size = New Size(77, 21)
        Label3.TabIndex = 57
        Label3.Text = "Categoría"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Segoe UI", 12.0F)
        Label4.Location = New Point(88, 89)
        Label4.Name = "Label4"
        Label4.Size = New Size(91, 21)
        Label4.TabIndex = 58
        Label4.Text = "Descripción"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Segoe UI", 12.0F)
        Label6.Location = New Point(88, 242)
        Label6.Name = "Label6"
        Label6.Size = New Size(116, 21)
        Label6.TabIndex = 60
        Label6.Text = "Precio de venta"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Segoe UI", 12.0F)
        Label5.Location = New Point(88, 191)
        Label5.Name = "Label5"
        Label5.Size = New Size(131, 21)
        Label5.TabIndex = 59
        Label5.Text = "Precio de compra"
        ' 
        ' UC_I_Eliminar
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        Controls.Add(Panel1)
        Name = "UC_I_Eliminar"
        Size = New Size(678, 403)
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Button_Buscar As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents CB_Cat As ComboBox
    Friend WithEvents MTB_Existencias As MaskedTextBox
    Friend WithEvents MTB_PVenta As MaskedTextBox
    Friend WithEvents MTB_PCompra As MaskedTextBox
    Friend WithEvents MTB_Codigo As MaskedTextBox
    Friend WithEvents MTB_Descripcion As MaskedTextBox
    Friend WithEvents Button_Prov As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Button_Cat As Button
    Friend WithEvents CB_Proveedores As ComboBox
End Class