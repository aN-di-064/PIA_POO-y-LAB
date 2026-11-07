<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class C_SeleccionarProducto
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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
        txtBuscar = New TextBox()
        Label1 = New Label()
        Label2 = New Label()
        dgvProductos = New DataGridView()
        Descripcion = New DataGridViewTextBoxColumn()
        precioCom = New DataGridViewTextBoxColumn()
        btnSeleccionar = New Button()
        btnCancelar = New Button()
        CType(dgvProductos, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' txtBuscar
        ' 
        txtBuscar.Location = New Point(117, 64)
        txtBuscar.Name = "txtBuscar"
        txtBuscar.Size = New Size(302, 23)
        txtBuscar.TabIndex = 0
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(12, 67)
        Label1.Name = "Label1"
        Label1.Size = New Size(99, 15)
        Label1.TabIndex = 1
        Label1.Text = "Buscar Productos"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 18.0F)
        Label2.Location = New Point(12, 15)
        Label2.Name = "Label2"
        Label2.Size = New Size(238, 32)
        Label2.TabIndex = 2
        Label2.Text = "Seleccionar Producto"
        ' 
        ' dgvProductos
        ' 
        dgvProductos.BackgroundColor = Color.FromArgb(CByte(224), CByte(224), CByte(224))
        dgvProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvProductos.Columns.AddRange(New DataGridViewColumn() {Descripcion, precioCom})
        dgvProductos.Location = New Point(12, 93)
        dgvProductos.Name = "dgvProductos"
        dgvProductos.Size = New Size(776, 277)
        dgvProductos.TabIndex = 3
        ' 
        ' Descripcion
        ' 
        Descripcion.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Descripcion.HeaderText = "Descripción"
        Descripcion.Name = "Descripcion"
        Descripcion.ReadOnly = True
        ' 
        ' precioCom
        ' 
        precioCom.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        precioCom.HeaderText = "Precio de compra"
        precioCom.Name = "precioCom"
        precioCom.ReadOnly = True
        ' 
        ' btnSeleccionar
        ' 
        btnSeleccionar.Location = New Point(684, 398)
        btnSeleccionar.Name = "btnSeleccionar"
        btnSeleccionar.Size = New Size(104, 31)
        btnSeleccionar.TabIndex = 4
        btnSeleccionar.Text = "Seleccionar"
        btnSeleccionar.UseVisualStyleBackColor = True
        ' 
        ' btnCancelar
        ' 
        btnCancelar.Location = New Point(557, 398)
        btnCancelar.Name = "btnCancelar"
        btnCancelar.Size = New Size(104, 31)
        btnCancelar.TabIndex = 5
        btnCancelar.Text = "Cancelar"
        btnCancelar.UseVisualStyleBackColor = True
        ' 
        ' C_SeleccionarProducto
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(btnCancelar)
        Controls.Add(btnSeleccionar)
        Controls.Add(dgvProductos)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(txtBuscar)
        Name = "C_SeleccionarProducto"
        Text = "C_SeleccionarProducto"
        CType(dgvProductos, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents txtBuscar As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents dgvProductos As DataGridView
    Friend WithEvents Descripcion As DataGridViewTextBoxColumn
    Friend WithEvents precioCom As DataGridViewTextBoxColumn
    Friend WithEvents btnSeleccionar As Button
    Friend WithEvents btnCancelar As Button
End Class
