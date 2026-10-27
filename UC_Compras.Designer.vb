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
        LBL_TOTAL = New Label()
        CB_Vendedor = New ComboBox()
        Label2 = New Label()
        Label1 = New Label()
        Button1 = New Button()
        BTN_BORRAR = New Button()
        Label4 = New Label()
        DataGridView1 = New DataGridView()
        Col_Cantidad = New DataGridViewTextBoxColumn()
        Col_Código = New DataGridViewTextBoxColumn()
        Col_Descripcion = New DataGridViewTextBoxColumn()
        Col_Precio = New DataGridViewTextBoxColumn()
        Col_Importe = New DataGridViewTextBoxColumn()
        LBL_IDCOMPRA = New Label()
        Button2 = New Button()
        Label3 = New Label()
        Label5 = New Label()
        Label6 = New Label()
        Button3 = New Button()
        Button4 = New Button()
        Panel1.SuspendLayout()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.Anchor = AnchorStyles.None
        Panel1.BackColor = Color.White
        Panel1.Controls.Add(Label5)
        Panel1.Controls.Add(Label6)
        Panel1.Controls.Add(Button3)
        Panel1.Controls.Add(Button4)
        Panel1.Controls.Add(LBL_TOTAL)
        Panel1.Controls.Add(CB_Vendedor)
        Panel1.Controls.Add(Label2)
        Panel1.Controls.Add(Label1)
        Panel1.Controls.Add(Button1)
        Panel1.Controls.Add(BTN_BORRAR)
        Panel1.Controls.Add(Label4)
        Panel1.Controls.Add(DataGridView1)
        Panel1.Controls.Add(LBL_IDCOMPRA)
        Panel1.Controls.Add(Button2)
        Panel1.Controls.Add(Label3)
        Panel1.Location = New Point(105, 24)
        Panel1.Margin = New Padding(3, 2, 3, 2)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(910, 525)
        Panel1.TabIndex = 1
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
        ' CB_Vendedor
        ' 
        CB_Vendedor.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        CB_Vendedor.AutoCompleteSource = AutoCompleteSource.ListItems
        CB_Vendedor.Font = New Font("Segoe UI", 12F)
        CB_Vendedor.FormattingEnabled = True
        CB_Vendedor.Location = New Point(219, 82)
        CB_Vendedor.Name = "CB_Vendedor"
        CB_Vendedor.Size = New Size(121, 29)
        CB_Vendedor.TabIndex = 25
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
        Label4.Size = New Size(166, 21)
        Label4.TabIndex = 24
        Label4.Text = "Nombre del vendedor:"
        ' 
        ' DataGridView1
        ' 
        DataGridView1.AllowUserToAddRows = False
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DataGridView1.BackgroundColor = Color.White
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView1.Columns.AddRange(New DataGridViewColumn() {Col_Cantidad, Col_Código, Col_Descripcion, Col_Precio, Col_Importe})
        DataGridView1.Location = New Point(26, 120)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.RowHeadersWidth = 51
        DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        DataGridView1.Size = New Size(858, 300)
        DataGridView1.TabIndex = 17
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
        ' LBL_IDCOMPRA
        ' 
        LBL_IDCOMPRA.AutoSize = True
        LBL_IDCOMPRA.Font = New Font("Segoe UI", 12F)
        LBL_IDCOMPRA.Location = New Point(114, 52)
        LBL_IDCOMPRA.Name = "LBL_IDCOMPRA"
        LBL_IDCOMPRA.Size = New Size(43, 21)
        LBL_IDCOMPRA.TabIndex = 20
        LBL_IDCOMPRA.Text = "label"
        ' 
        ' Button2
        ' 
        Button2.Font = New Font("Segoe UI", 12F)
        Button2.Location = New Point(656, 82)
        Button2.Name = "Button2"
        Button2.Size = New Size(175, 29)
        Button2.TabIndex = 16
        Button2.Text = "Buscar producto"
        Button2.UseVisualStyleBackColor = True
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
        ' Label5
        ' 
        Label5.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        Label5.AutoSize = True
        Label5.Font = New Font("Segoe UI", 12F)
        Label5.Location = New Point(726, 442)
        Label5.Name = "Label5"
        Label5.Size = New Size(43, 21)
        Label5.TabIndex = 29
        Label5.Text = "label"
        ' 
        ' Label6
        ' 
        Label6.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        Label6.AutoSize = True
        Label6.Font = New Font("Segoe UI", 12F)
        Label6.Location = New Point(674, 442)
        Label6.Name = "Label6"
        Label6.Size = New Size(45, 21)
        Label6.TabIndex = 28
        Label6.Text = "Total:"
        ' 
        ' Button3
        ' 
        Button3.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        Button3.Font = New Font("Segoe UI", 12F)
        Button3.Location = New Point(700, 472)
        Button3.Name = "Button3"
        Button3.Size = New Size(113, 29)
        Button3.TabIndex = 26
        Button3.Text = "Cobrar"
        Button3.UseVisualStyleBackColor = True
        ' 
        ' Button4
        ' 
        Button4.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        Button4.Font = New Font("Segoe UI", 12F)
        Button4.Location = New Point(26, 442)
        Button4.Name = "Button4"
        Button4.Size = New Size(153, 56)
        Button4.TabIndex = 27
        Button4.Text = "Borrar producto seleccionado"
        Button4.UseVisualStyleBackColor = True
        ' 
        ' UC_Compras
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        Controls.Add(Panel1)
        Margin = New Padding(3, 2, 3, 2)
        Name = "UC_Compras"
        Size = New Size(1120, 573)
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Button3 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents LBL_TOTAL As Label
    Friend WithEvents CB_Vendedor As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents BTN_BORRAR As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Col_Cantidad As DataGridViewTextBoxColumn
    Friend WithEvents Col_Código As DataGridViewTextBoxColumn
    Friend WithEvents Col_Descripcion As DataGridViewTextBoxColumn
    Friend WithEvents Col_Precio As DataGridViewTextBoxColumn
    Friend WithEvents Col_Importe As DataGridViewTextBoxColumn
    Friend WithEvents LBL_IDCOMPRA As Label
    Friend WithEvents Button2 As Button
    Friend WithEvents Label3 As Label

End Class
