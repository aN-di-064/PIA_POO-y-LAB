<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class UC_Consulta
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
        Label1 = New Label()
        txtBuscar = New TextBox()
        dgvProductos = New DataGridView()
        ComboBox1 = New ComboBox()
        TableLayoutPanel1 = New TableLayoutPanel()
        Panel1 = New Panel()
        CType(dgvProductos, ComponentModel.ISupportInitialize).BeginInit()
        TableLayoutPanel1.SuspendLayout()
        Panel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.White
        Label1.Font = New Font("Segoe UI", 12.0F)
        Label1.Location = New Point(70, 50)
        Label1.Name = "Label1"
        Label1.Size = New Size(89, 28)
        Label1.TabIndex = 6
        Label1.Text = "Nombre:"
        ' 
        ' txtBuscar
        ' 
        txtBuscar.Font = New Font("Segoe UI", 12.0F)
        txtBuscar.Location = New Point(180, 50)
        txtBuscar.Margin = New Padding(3, 4, 3, 4)
        txtBuscar.Name = "txtBuscar"
        txtBuscar.Size = New Size(327, 34)
        txtBuscar.TabIndex = 5
        ' 
        ' dgvProductos
        ' 
        dgvProductos.AllowUserToAddRows = False
        dgvProductos.AllowUserToDeleteRows = False
        dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvProductos.BackgroundColor = Color.White
        dgvProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvProductos.Location = New Point(30, 120)
        dgvProductos.Margin = New Padding(3, 4, 3, 4)
        dgvProductos.MultiSelect = False
        dgvProductos.Name = "dgvProductos"
        dgvProductos.ReadOnly = True
        dgvProductos.RowHeadersWidth = 62
        dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvProductos.Size = New Size(980, 540)
        dgvProductos.TabIndex = 4
        ' 
        ' ComboBox1
        ' 
        ComboBox1.Font = New Font("Segoe UI", 12.0F)
        ComboBox1.FormattingEnabled = True
        ComboBox1.Location = New Point(600, 50)
        ComboBox1.Margin = New Padding(2, 3, 2, 3)
        ComboBox1.Name = "ComboBox1"
        ComboBox1.Size = New Size(147, 36)
        ComboBox1.TabIndex = 7
        ' 
        ' TableLayoutPanel1
        ' 
        TableLayoutPanel1.ColumnCount = 1
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50.0F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50.0F))
        TableLayoutPanel1.Controls.Add(Panel1, 0, 0)
        TableLayoutPanel1.Dock = DockStyle.Fill
        TableLayoutPanel1.Location = New Point(0, 0)
        TableLayoutPanel1.Name = "TableLayoutPanel1"
        TableLayoutPanel1.RowCount = 1
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 50.0F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 50.0F))
        TableLayoutPanel1.Size = New Size(1280, 720)
        TableLayoutPanel1.TabIndex = 8
        ' 
        ' Panel1
        ' 
        Panel1.Anchor = AnchorStyles.None
        Panel1.BackColor = Color.White
        Panel1.Controls.Add(ComboBox1)
        Panel1.Controls.Add(Label1)
        Panel1.Controls.Add(dgvProductos)
        Panel1.Controls.Add(txtBuscar)
        Panel1.Location = New Point(120, 10)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(1040, 700)
        Panel1.TabIndex = 0
        ' 
        ' UC_Consulta
        ' 
        AutoScaleDimensions = New SizeF(8.0F, 20.0F)
        AutoScaleMode = AutoScaleMode.Font
        Controls.Add(TableLayoutPanel1)
        Margin = New Padding(3, 4, 3, 4)
        Name = "UC_Consulta"
        Size = New Size(1280, 720)
        CType(dgvProductos, ComponentModel.ISupportInitialize).EndInit()
        TableLayoutPanel1.ResumeLayout(False)
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents txtBuscar As TextBox
    Friend WithEvents dgvProductos As DataGridView
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Panel1 As Panel
End Class