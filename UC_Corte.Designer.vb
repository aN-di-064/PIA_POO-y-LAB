<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class UC_Corte
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
        Label1 = New Label()
        Label7 = New Label()
        Label_CorteNo = New Label()
        LabelMontoInicial = New Label()
        MTB_MontoInicial = New MaskedTextBox()
        LabelTotalVentas = New Label()
        MTB_TotalVentas = New MaskedTextBox()
        LabelMontoFinal = New Label()
        MTB_MontoFinal = New MaskedTextBox()
        Button_Abrir = New Button()
        Button_Cerrar = New Button()
        Panel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.Anchor = AnchorStyles.None
        Panel1.BackColor = Color.White
        Panel1.Controls.Add(Label1)
        Panel1.Controls.Add(Label7)
        Panel1.Controls.Add(Label_CorteNo)
        Panel1.Controls.Add(LabelMontoInicial)
        Panel1.Controls.Add(MTB_MontoInicial)
        Panel1.Controls.Add(LabelTotalVentas)
        Panel1.Controls.Add(MTB_TotalVentas)
        Panel1.Controls.Add(LabelMontoFinal)
        Panel1.Controls.Add(MTB_MontoFinal)
        Panel1.Controls.Add(Button_Abrir)
        Panel1.Controls.Add(Button_Cerrar)
        Panel1.Location = New Point(105, 24)
        Panel1.Margin = New Padding(3, 2, 3, 2)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(650, 450)
        Panel1.TabIndex = 1
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 18.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(26, 25)
        Label1.Name = "Label1"
        Label1.Size = New Size(164, 32)
        Label1.TabIndex = 9
        Label1.Text = "Corte de caja"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Font = New Font("Segoe UI", 12.0F)
        Label7.Location = New Point(26, 75)
        Label7.Name = "Label7"
        Label7.Size = New Size(73, 21)
        Label7.TabIndex = 27
        Label7.Text = "Corte no."
        ' 
        ' Label_CorteNo
        ' 
        Label_CorteNo.AutoSize = True
        Label_CorteNo.Font = New Font("Segoe UI", 12.0F)
        Label_CorteNo.Location = New Point(120, 75)
        Label_CorteNo.Name = "Label_CorteNo"
        Label_CorteNo.Size = New Size(43, 21)
        Label_CorteNo.TabIndex = 26
        Label_CorteNo.Text = "label"
        ' 
        ' LabelMontoInicial
        ' 
        LabelMontoInicial.AutoSize = True
        LabelMontoInicial.Font = New Font("Segoe UI", 12.0F)
        LabelMontoInicial.Location = New Point(26, 130)
        LabelMontoInicial.Name = "LabelMontoInicial"
        LabelMontoInicial.Size = New Size(103, 21)
        LabelMontoInicial.TabIndex = 28
        LabelMontoInicial.Text = "Monto inicial:"
        ' 
        ' MTB_MontoInicial
        ' 
        MTB_MontoInicial.Font = New Font("Segoe UI", 12.0F)
        MTB_MontoInicial.Location = New Point(210, 127)
        MTB_MontoInicial.Name = "MTB_MontoInicial"
        MTB_MontoInicial.Size = New Size(200, 29)
        MTB_MontoInicial.TabIndex = 29
        ' 
        ' LabelTotalVentas
        ' 
        LabelTotalVentas.AutoSize = True
        LabelTotalVentas.Font = New Font("Segoe UI", 12.0F)
        LabelTotalVentas.Location = New Point(26, 185)
        LabelTotalVentas.Name = "LabelTotalVentas"
        LabelTotalVentas.Size = New Size(126, 21)
        LabelTotalVentas.TabIndex = 30
        LabelTotalVentas.Text = "Ventas del turno:"
        ' 
        ' MTB_TotalVentas
        ' 
        MTB_TotalVentas.Font = New Font("Segoe UI", 12.0F)
        MTB_TotalVentas.Location = New Point(210, 182)
        MTB_TotalVentas.Name = "MTB_TotalVentas"
        MTB_TotalVentas.ReadOnly = True
        MTB_TotalVentas.Size = New Size(200, 29)
        MTB_TotalVentas.TabIndex = 31
        ' 
        ' LabelMontoFinal
        ' 
        LabelMontoFinal.AutoSize = True
        LabelMontoFinal.Font = New Font("Segoe UI", 12.0F)
        LabelMontoFinal.Location = New Point(26, 240)
        LabelMontoFinal.Name = "LabelMontoFinal"
        LabelMontoFinal.Size = New Size(159, 21)
        LabelMontoFinal.TabIndex = 32
        LabelMontoFinal.Text = "Conteo físico (Cierre):"
        ' 
        ' MTB_MontoFinal
        ' 
        MTB_MontoFinal.Font = New Font("Segoe UI", 12.0F)
        MTB_MontoFinal.Location = New Point(210, 237)
        MTB_MontoFinal.Name = "MTB_MontoFinal"
        MTB_MontoFinal.Size = New Size(200, 29)
        MTB_MontoFinal.TabIndex = 33
        ' 
        ' Button_Abrir
        ' 
        Button_Abrir.Font = New Font("Segoe UI", 12.0F)
        Button_Abrir.Location = New Point(26, 320)
        Button_Abrir.Name = "Button_Abrir"
        Button_Abrir.Size = New Size(175, 40)
        Button_Abrir.TabIndex = 15
        Button_Abrir.Text = "Abrir Caja"
        Button_Abrir.UseVisualStyleBackColor = True
        ' 
        ' Button_Cerrar
        ' 
        Button_Cerrar.Font = New Font("Segoe UI", 12.0F)
        Button_Cerrar.Location = New Point(235, 320)
        Button_Cerrar.Name = "Button_Cerrar"
        Button_Cerrar.Size = New Size(175, 40)
        Button_Cerrar.TabIndex = 16
        Button_Cerrar.Text = "Cerrar / Realizar Corte"
        Button_Cerrar.UseVisualStyleBackColor = True
        ' 
        ' UC_Corte
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        Controls.Add(Panel1)
        Name = "UC_Corte"
        Size = New Size(846, 520)
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label_CorteNo As Label
    Friend WithEvents LabelMontoInicial As Label
    Friend WithEvents MTB_MontoInicial As MaskedTextBox
    Friend WithEvents LabelTotalVentas As Label
    Friend WithEvents MTB_TotalVentas As MaskedTextBox
    Friend WithEvents LabelMontoFinal As Label
    Friend WithEvents MTB_MontoFinal As MaskedTextBox
    Friend WithEvents Button_Abrir As Button
    Friend WithEvents Button_Cerrar As Button

End Class