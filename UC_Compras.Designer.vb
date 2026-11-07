<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UC_Compras
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
        lblTotal = New Label()
        Label6 = New Label()
        btnCobrar = New Button()
        btnEliminar = New Button()
        LBL_TOTAL = New Label()
        cboProveedor = New ComboBox()
        Label2 = New Label()
        Label1 = New Label()
        Button1 = New Button()
        BTN_BORRAR = New Button()
        Label4 = New Label()
        dgvCompra = New DataGridView()
        Col_Cantidad = New DataGridViewTextBoxColumn()
        Col_Código = New DataGridViewTextBoxColumn()
        Col_Descripcion = New DataGridViewTextBoxColumn()
        Col_Precio = New DataGridViewTextBoxColumn()
        Col_Importe = New DataGridViewTextBoxColumn()
        lblNumeroCompra = New Label()
        btnBuscarProducto = New Button()
        Label3 = New Label()
        Panel1.SuspendLayout()
        CType(dgvCompra, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.Anchor = AnchorStyles.None
        Panel1.BackColor = Color.White
        Panel1.Controls.Add(lblTotal)
        Panel1.Controls.Add(Label6)
        Panel1.Controls.Add(btnCobrar)
        Panel1.Controls.Add(btnEliminar)
        Panel1.Controls.Add(LBL_TOTAL)
        Panel1.Controls.Add(cboProveedor)
        Panel1.Controls.Add(Label2)
        Panel1.Controls.Add(Label1)
        Panel1.Controls.Add(Button1)
        Panel1.Controls.Add(BTN_BORRAR)
        Panel1.Controls.Add(Label4)
        Panel1.Controls.Add(dgvCompra)
        Panel1.Controls.Add(lblNumeroCompra)
        Panel1.Controls.Add(btnBuscarProducto)
        Panel1.Controls.Add(Label3)
        Panel1.Location = New Point(190, 84)
        Panel1.Margin = New Padding(3, 2, 3, 2)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(910, 525)
        Panel1.TabIndex = 1
        ' 
        ' lblTotal
        ' 
        lblTotal.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        lblTotal.AutoSize = True
        lblTotal.Font = New Font("Segoe UI", 12F)
        lblTotal.Location = New Point(656, 460)
        lblTotal.Name = "lblTotal"
        lblTotal.Size = New Size(43, 21)
        lblTotal.TabIndex = 29
        lblTotal.Text = "label"
        ' 
        ' Label6
        ' 
        Label6.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        Label6.AutoSize = True
        Label6.Font = New Font("Segoe UI", 12F)
        Label6.Location = New Point(604, 460)
        Label6.Name = "Label6"
        Label6.Size = New Size(45, 21)
        Label6.TabIndex = 28
        Label6.Text = "Total:"
        ' 
        ' btnCobrar
        ' 
        btnCobrar.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        btnCobrar.Font = New Font("Segoe UI", 12F)
        btnCobrar.Location = New Point(753, 450)
        btnCobrar.Name = "btnCobrar"
        btnCobrar.Size = New Size(131, 40)
        btnCobrar.TabIndex = 26
        btnCobrar.Text = "Cobrar"
        btnCobrar.UseVisualStyleBackColor = True
        ' 
        ' btnEliminar
        ' 
        btnEliminar.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        btnEliminar.Font = New Font("Segoe UI", 12F)
        btnEliminar.Location = New Point(28, 450)
        btnEliminar.Name = "btnEliminar"
        btnEliminar.Size = New Size(147, 40)
        btnEliminar.TabIndex = 27
        btnEliminar.Text = "Eliminar selección"
        btnEliminar.UseVisualStyleBackColor = True
        ' 
        ' LBL_TOTAL
        ' 
        LBL_TOTAL.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        LBL_TOTAL.AutoSize = True
        LBL_TOTAL.Font = New Font("Segoe UI", 12F)
        LBL_TOTAL.Location = New Point(1436, 853)
        LBL_TOTAL.Name = "LBL_TOTAL"
        LBL_TOTAL.Size = New Size(43, 21)
        LBL_TOTAL.TabIndex = 23
        LBL_TOTAL.Text = "label"
        ' 
        ' cboProveedor
        ' 
        cboProveedor.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        cboProveedor.AutoCompleteSource = AutoCompleteSource.ListItems
        cboProveedor.Font = New Font("Segoe UI", 12F)
        cboProveedor.FormattingEnabled = True
        cboProveedor.Location = New Point(219, 82)
        cboProveedor.Name = "cboProveedor"
        cboProveedor.Size = New Size(121, 29)
        cboProveedor.TabIndex = 25
        ' 
        ' Label2
        ' 
        Label2.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 12F)
        Label2.Location = New Point(1384, 853)
        Label2.Name = "Label2"
        Label2.Size = New Size(45, 21)
        Label2.TabIndex = 22
        Label2.Text = "Total:"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(9, 11)
        Label1.Name = "Label1"
        Label1.Size = New Size(240, 32)
        Label1.TabIndex = 18
        Label1.Text = "Compra de material"
        ' 
        ' Button1
        ' 
        Button1.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        Button1.Font = New Font("Segoe UI", 12F)
        Button1.Location = New Point(1410, 883)
        Button1.Name = "Button1"
        Button1.Size = New Size(113, 29)
        Button1.TabIndex = 15
        Button1.Text = "Cobrar"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' BTN_BORRAR
        ' 
        BTN_BORRAR.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        BTN_BORRAR.Font = New Font("Segoe UI", 12F)
        BTN_BORRAR.Location = New Point(26, 853)
        BTN_BORRAR.Name = "BTN_BORRAR"
        BTN_BORRAR.Size = New Size(153, 56)
        BTN_BORRAR.TabIndex = 19
        BTN_BORRAR.Text = "Borrar producto seleccionado"
        BTN_BORRAR.UseVisualStyleBackColor = True
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Segoe UI", 12F)
        Label4.Location = New Point(26, 82)
        Label4.Name = "Label4"
        Label4.Size = New Size(168, 21)
        Label4.TabIndex = 24
        Label4.Text = "Nombre de proveedor:"
        ' 
        ' dgvCompra
        ' 
        dgvCompra.AllowUserToAddRows = False
        dgvCompra.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvCompra.BackgroundColor = Color.White
        dgvCompra.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvCompra.Columns.AddRange(New DataGridViewColumn() {Col_Cantidad, Col_Código, Col_Descripcion, Col_Precio, Col_Importe})
        dgvCompra.Location = New Point(26, 120)
        dgvCompra.Name = "dgvCompra"
        dgvCompra.RowHeadersWidth = 51
        dgvCompra.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvCompra.Size = New Size(858, 300)
        dgvCompra.TabIndex = 17
        ' 
        ' Col_Cantidad
        ' 
        Col_Cantidad.HeaderText = "Cantidad (kg)"
        Col_Cantidad.MinimumWidth = 6
        Col_Cantidad.Name = "Col_Cantidad"
        ' 
        ' Col_Código
        ' 
        Col_Código.HeaderText = "Código"
        Col_Código.MinimumWidth = 6
        Col_Código.Name = "Col_Código"
        Col_Código.ReadOnly = True
        ' 
        ' Col_Descripcion
        ' 
        Col_Descripcion.FillWeight = 200F
        Col_Descripcion.HeaderText = "Descripción"
        Col_Descripcion.MinimumWidth = 6
        Col_Descripcion.Name = "Col_Descripcion"
        Col_Descripcion.ReadOnly = True
        ' 
        ' Col_Precio
        ' 
        Col_Precio.HeaderText = "Precio por kilo"
        Col_Precio.MinimumWidth = 6
        Col_Precio.Name = "Col_Precio"
        Col_Precio.ReadOnly = True
        ' 
        ' Col_Importe
        ' 
        Col_Importe.HeaderText = "Subtotal"
        Col_Importe.MinimumWidth = 6
        Col_Importe.Name = "Col_Importe"
        Col_Importe.ReadOnly = True
        ' 
        ' lblNumeroCompra
        ' 
        lblNumeroCompra.AutoSize = True
        lblNumeroCompra.Font = New Font("Segoe UI", 12F)
        lblNumeroCompra.Location = New Point(114, 52)
        lblNumeroCompra.Name = "lblNumeroCompra"
        lblNumeroCompra.Size = New Size(43, 21)
        lblNumeroCompra.TabIndex = 20
        lblNumeroCompra.Text = "label"
        ' 
        ' btnBuscarProducto
        ' 
        btnBuscarProducto.Font = New Font("Segoe UI", 12F)
        btnBuscarProducto.Location = New Point(656, 82)
        btnBuscarProducto.Name = "btnBuscarProducto"
        btnBuscarProducto.Size = New Size(175, 29)
        btnBuscarProducto.TabIndex = 16
        btnBuscarProducto.Text = "Buscar producto"
        btnBuscarProducto.UseVisualStyleBackColor = True
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 12F)
        Label3.Location = New Point(26, 52)
        Label3.Name = "Label3"
        Label3.Size = New Size(74, 21)
        Label3.TabIndex = 21
        Label3.Text = "Venta no."
        ' 
        ' UC_Compras
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        Controls.Add(Panel1)
        Margin = New Padding(3, 2, 3, 2)
        Name = "UC_Compras"
        Size = New Size(1291, 693)
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        CType(dgvCompra, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents lblTotal As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents btnCobrar As Button
    Friend WithEvents btnEliminar As Button
    Friend WithEvents LBL_TOTAL As Label
    Friend WithEvents cboProveedor As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents BTN_BORRAR As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents dgvCompra As DataGridView
    Friend WithEvents Col_Cantidad As DataGridViewTextBoxColumn
    Friend WithEvents Col_Código As DataGridViewTextBoxColumn
    Friend WithEvents Col_Descripcion As DataGridViewTextBoxColumn
    Friend WithEvents Col_Precio As DataGridViewTextBoxColumn
    Friend WithEvents Col_Importe As DataGridViewTextBoxColumn
    Friend WithEvents lblNumeroCompra As Label
    Friend WithEvents btnBuscarProducto As Button
    Friend WithEvents Label3 As Label

End Class
