<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RangoFechas
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
        TableLayoutPanel1 = New TableLayoutPanel()
        Panel1 = New Panel()
        Button1 = New Button()
        CB_TIPOCONSULTA = New ComboBox()
        Label3 = New Label()
        Label2 = New Label()
        DateTimePicker1 = New DateTimePicker()
        DateTimePicker2 = New DateTimePicker()
        Label1 = New Label()
        TableLayoutPanel1.SuspendLayout()
        Panel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' TableLayoutPanel1
        ' 
        TableLayoutPanel1.ColumnCount = 1
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        TableLayoutPanel1.Controls.Add(Panel1, 0, 0)
        TableLayoutPanel1.Dock = DockStyle.Fill
        TableLayoutPanel1.Location = New Point(0, 0)
        TableLayoutPanel1.Name = "TableLayoutPanel1"
        TableLayoutPanel1.RowCount = 1
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 50F))
        TableLayoutPanel1.Size = New Size(509, 415)
        TableLayoutPanel1.TabIndex = 0
        ' 
        ' Panel1
        ' 
        Panel1.Anchor = AnchorStyles.None
        Panel1.Controls.Add(Button1)
        Panel1.Controls.Add(CB_TIPOCONSULTA)
        Panel1.Controls.Add(Label3)
        Panel1.Controls.Add(Label2)
        Panel1.Controls.Add(DateTimePicker1)
        Panel1.Controls.Add(DateTimePicker2)
        Panel1.Controls.Add(Label1)
        Panel1.Location = New Point(35, 20)
        Panel1.Margin = New Padding(3, 2, 3, 2)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(438, 375)
        Panel1.TabIndex = 0
        ' 
        ' Button1
        ' 
        Button1.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        Button1.Font = New Font("Segoe UI", 12F)
        Button1.Location = New Point(153, 287)
        Button1.Name = "Button1"
        Button1.Size = New Size(122, 30)
        Button1.TabIndex = 32
        Button1.Text = "Aceptar"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' CB_TIPOCONSULTA
        ' 
        CB_TIPOCONSULTA.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        CB_TIPOCONSULTA.AutoCompleteSource = AutoCompleteSource.ListItems
        CB_TIPOCONSULTA.Font = New Font("Segoe UI", 12F)
        CB_TIPOCONSULTA.FormattingEnabled = True
        CB_TIPOCONSULTA.Items.AddRange(New Object() {"Compras", "Ventas"})
        CB_TIPOCONSULTA.Location = New Point(192, 214)
        CB_TIPOCONSULTA.Name = "CB_TIPOCONSULTA"
        CB_TIPOCONSULTA.Size = New Size(228, 29)
        CB_TIPOCONSULTA.TabIndex = 33
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 12F)
        Label3.Location = New Point(18, 207)
        Label3.Name = "Label3"
        Label3.Size = New Size(154, 42)
        Label3.TabIndex = 34
        Label3.Text = "Seleccione la opción " & vbCrLf & "que desea consultar:"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 12F)
        Label2.Location = New Point(18, 131)
        Label2.Name = "Label2"
        Label2.Size = New Size(144, 42)
        Label2.TabIndex = 31
        Label2.Text = "Seleccione la fecha " & vbCrLf & "del fin del reporte"
        ' 
        ' DateTimePicker1
        ' 
        DateTimePicker1.CalendarFont = New Font("Segoe UI", 12F)
        DateTimePicker1.Font = New Font("Segoe UI", 12F)
        DateTimePicker1.Location = New Point(192, 64)
        DateTimePicker1.Name = "DateTimePicker1"
        DateTimePicker1.Size = New Size(228, 29)
        DateTimePicker1.TabIndex = 28
        ' 
        ' DateTimePicker2
        ' 
        DateTimePicker2.CalendarFont = New Font("Segoe UI", 12F)
        DateTimePicker2.Font = New Font("Segoe UI", 12F)
        DateTimePicker2.Location = New Point(192, 139)
        DateTimePicker2.Name = "DateTimePicker2"
        DateTimePicker2.Size = New Size(228, 29)
        DateTimePicker2.TabIndex = 29
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 12F)
        Label1.Location = New Point(18, 57)
        Label1.Name = "Label1"
        Label1.Size = New Size(144, 42)
        Label1.TabIndex = 30
        Label1.Text = "Seleccione la fecha " & vbCrLf & "de Inicio de reporte"
        ' 
        ' RangoFechas
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(509, 415)
        Controls.Add(TableLayoutPanel1)
        MaximumSize = New Size(700, 454)
        MinimumSize = New Size(525, 454)
        Name = "RangoFechas"
        Text = "RangoFechas"
        TableLayoutPanel1.ResumeLayout(False)
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Button1 As Button
    Friend WithEvents CB_TIPOCONSULTA As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents DateTimePicker2 As DateTimePicker
    Friend WithEvents Label1 As Label
End Class
