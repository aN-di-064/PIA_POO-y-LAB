<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UC_ReporteDia
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
        DataGridView1 = New DataGridView()
        Col_Código = New DataGridViewTextBoxColumn()
        Col_Descripcion = New DataGridViewTextBoxColumn()
        Col_Cantidad = New DataGridViewTextBoxColumn()
        Col_Precio = New DataGridViewTextBoxColumn()
        Col_Importe = New DataGridViewTextBoxColumn()
        Label1 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        Label4 = New Label()
        Label5 = New Label()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' DataGridView1
        ' 
        DataGridView1.AllowUserToAddRows = False
        DataGridView1.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView1.Columns.AddRange(New DataGridViewColumn() {Col_Código, Col_Descripcion, Col_Cantidad, Col_Precio, Col_Importe})
        DataGridView1.Location = New Point(72, 110)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        DataGridView1.Size = New Size(692, 204)
        DataGridView1.TabIndex = 5
        ' 
        ' Col_Código
        ' 
        Col_Código.HeaderText = "Código"
        Col_Código.Name = "Col_Código"
        ' 
        ' Col_Descripcion
        ' 
        Col_Descripcion.FillWeight = 200F
        Col_Descripcion.HeaderText = "Descripción"
        Col_Descripcion.Name = "Col_Descripcion"
        ' 
        ' Col_Cantidad
        ' 
        Col_Cantidad.HeaderText = "Cantidad"
        Col_Cantidad.Name = "Col_Cantidad"
        ' 
        ' Col_Precio
        ' 
        Col_Precio.HeaderText = "Precio"
        Col_Precio.Name = "Col_Precio"
        ' 
        ' Col_Importe
        ' 
        Col_Importe.HeaderText = "Importe"
        Col_Importe.Name = "Col_Importe"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(72, 29)
        Label1.Name = "Label1"
        Label1.Size = New Size(82, 15)
        Label1.TabIndex = 6
        Label1.Text = "Ventas del dia:"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(181, 29)
        Label2.Name = "Label2"
        Label2.Size = New Size(41, 15)
        Label2.TabIndex = 7
        Label2.Text = "Label2"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(72, 70)
        Label3.Name = "Label3"
        Label3.Size = New Size(59, 15)
        Label3.TabIndex = 8
        Label3.Text = "Resumen:"
        ' 
        ' Label4
        ' 
        Label4.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        Label4.AutoSize = True
        Label4.Location = New Point(72, 342)
        Label4.Name = "Label4"
        Label4.Size = New Size(88, 15)
        Label4.TabIndex = 9
        Label4.Text = "Total de ventas:"
        ' 
        ' Label5
        ' 
        Label5.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        Label5.AutoSize = True
        Label5.Location = New Point(197, 342)
        Label5.Name = "Label5"
        Label5.Size = New Size(88, 15)
        Label5.TabIndex = 10
        Label5.Text = "Total de ventas:"
        ' 
        ' UC_ReporteDia
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        Controls.Add(Label5)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(DataGridView1)
        Name = "UC_ReporteDia"
        Size = New Size(836, 380)
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Col_Código As DataGridViewTextBoxColumn
    Friend WithEvents Col_Descripcion As DataGridViewTextBoxColumn
    Friend WithEvents Col_Cantidad As DataGridViewTextBoxColumn
    Friend WithEvents Col_Precio As DataGridViewTextBoxColumn
    Friend WithEvents Col_Importe As DataGridViewTextBoxColumn
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label

End Class
