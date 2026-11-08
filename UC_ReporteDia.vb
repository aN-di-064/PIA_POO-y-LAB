Imports System.Data.OleDb

Public Class UC_ReporteDia

    ' Variables para almacenar el rango de fechas y el tipo de consulta
    Public FechaInicio As DateTime
    Public FechaFin As DateTime
    Public TipoReporte As String = "Ventas"

    ' Constructor predeterminado
    Public Sub New()
        InitializeComponent()
    End Sub

    ' Constructor personalizado para recibir los parámetros desde la ventana de fechas
    Public Sub New(fInicio As DateTime, fFin As DateTime, tipo As String)
        InitializeComponent()
        FechaInicio = fInicio
        FechaFin = fFin
        If Not String.IsNullOrWhiteSpace(tipo) Then
            TipoReporte = tipo.Trim()
        Else
            TipoReporte = "Ventas"
        End If
    End Sub

    ' Función auxiliar para validar si el reporte corresponde a ventas (singular o plural)
    Private Function EsReporteDeVentas() As Boolean
        Return TipoReporte.Equals("Venta", StringComparison.OrdinalIgnoreCase) OrElse
               TipoReporte.Equals("Ventas", StringComparison.OrdinalIgnoreCase) OrElse
               TipoReporte.ToLower().StartsWith("venta")
    End Function

    Private Sub UC_ReporteDia_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Ajustar el encabezado del reporte
        If FechaInicio <> Nothing AndAlso FechaFin <> Nothing Then
            Label1.Text = $"Reporte de {TipoReporte} del:"
            Label2.Text = $"{FechaInicio.ToString("dd/MM/yyyy")} al {FechaFin.ToString("dd/MM/yyyy")}"
        Else
            FechaInicio = DateTime.Now.Date
            FechaFin = DateTime.Now.Date.AddDays(1).AddSeconds(-1)
            Label1.Text = $"Reporte de {TipoReporte} del día:"
            Label2.Text = DateTime.Now.ToString("dd/MM/yyyy")
        End If

        ' Cambiar dinámicamente la etiqueta indicadora ("Total de ventas:" o "Total de compras:")
        ' Asumiendo que la etiqueta estática de la izquierda se llama Label3 (o ajusta su nombre si difiere)
        If Controls.ContainsKey("Label3") Then
            Controls("Label3").Text = If(EsReporteDeVentas(), "Total de ventas:", "Total de compras:")
        End If

        DataGridView1.AutoGenerateColumns = True
        CargarDatosGenerales()
    End Sub

    ' Cargar información general de Ventas o Compras y realizar la sumatoria acumulada
    Private Sub CargarDatosGenerales()
        Try
            Using con As OleDbConnection = ObtenerConexion()
                Dim query As String = ""

                If EsReporteDeVentas() Then
                    ' Consulta para Ventas
                    query = "SELECT V.Id_v AS Folio, V.fecha_v AS Fecha, C.Nombre_cli AS Cliente, E.Nombre_emp AS Empleado, V.total_v AS Total " &
                            "FROM ((Venta V INNER JOIN Cliente C ON V.Id_cli = C.Id_cli) " &
                            "INNER JOIN Empleado E ON V.Id_emp = E.Id_emp) " &
                            "WHERE V.fecha_v BETWEEN ? AND ? ORDER BY V.Id_v DESC"
                Else
                    ' Consulta para Compras
                    query = "SELECT Com.ID_com AS Folio, Com.Fecha_com AS Fecha, Prov.Nombre_prov AS Proveedor, Emp.Nombre_emp AS Empleado, Com.total_com AS Total " &
                            "FROM ((Compras Com INNER JOIN Proveedor Prov ON Com.ID_prov = Prov.ID_prov) " &
                            "INNER JOIN Empleado Emp ON Com.ID_emp = Emp.Id_emp) " &
                            "WHERE Com.Fecha_com BETWEEN ? AND ? ORDER BY Com.ID_com DESC"
                End If

                Using cmd As New OleDbCommand(query, con)
                    cmd.Parameters.Add("?", OleDbType.Date).Value = FechaInicio
                    cmd.Parameters.Add("?", OleDbType.Date).Value = FechaFin

                    Using adapter As New OleDbDataAdapter(cmd)
                        Dim dt As New DataTable()
                        adapter.Fill(dt)

                        DataGridView1.Columns.Clear()
                        DataGridView1.DataSource = dt

                        For Each col As DataGridViewColumn In DataGridView1.Columns
                            col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                        Next

                        ' Calcular la sumatoria de la columna Total
                        Dim totalAcumulado As Decimal = 0D
                        If dt.Rows.Count > 0 Then
                            Dim sumaObj As Object = dt.Compute("SUM(Total)", "")
                            If Not IsDBNull(sumaObj) AndAlso sumaObj IsNot Nothing Then
                                Decimal.TryParse(sumaObj.ToString(), totalAcumulado)
                            End If
                        End If

                        ' Asignar el total formateado en LBL_TOTAL
                        If LBL_TOTAL IsNot Nothing Then
                            LBL_TOTAL.Text = totalAcumulado.ToString("$#,##0.00")
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al cargar el reporte: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Evento de doble clic para consultar detalle de folio
    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        If e.RowIndex >= 0 Then
            Dim filaSeleccionada = DataGridView1.Rows(e.RowIndex)
            Dim idFolio As Integer = Convert.ToInt32(filaSeleccionada.Cells("Folio").Value)

            MostrarDetalleFolio(idFolio)
        End If
    End Sub

    ' Consulta y muestra una ventana modal con los items del folio
    Private Sub MostrarDetalleFolio(folio As Integer)
        Try
            Using con As OleDbConnection = ObtenerConexion()
                Dim queryDetalle As String = ""

                If EsReporteDeVentas() Then
                    queryDetalle = "SELECT P.Id_prod AS Código, P.Descripcion_prod AS Descripción, D.Cantidad_VP AS Cantidad, D.Precio_VP AS Precio, D.Subtotal_VP AS Subtotal " &
                                   "FROM Detalle_VP D INNER JOIN Producto P ON D.Id_prod = P.Id_prod " &
                                   "WHERE D.Id_v = ?"
                Else
                    queryDetalle = "SELECT P.Id_prod AS Código, P.Descripcion_prod AS Descripción, D.Cantidad_CP AS Cantidad, D.CostoUnitario_CP AS Precio, D.subtotal_CP AS Subtotal " &
                                   "FROM Detalle_CP D INNER JOIN Producto P ON D.ID_prod = P.Id_prod " &
                                   "WHERE D.ID_com = ?"
                End If

                Using cmd As New OleDbCommand(queryDetalle, con)
                    cmd.Parameters.Add("?", OleDbType.Integer).Value = folio

                    Using adapter As New OleDbDataAdapter(cmd)
                        Dim dtDetalle As New DataTable()
                        adapter.Fill(dtDetalle)

                        Dim frmDetalle As New Form()
                        frmDetalle.Text = $"Detalle de {TipoReporte} - Folio #{folio}"
                        frmDetalle.Size = New Size(650, 350)
                        frmDetalle.StartPosition = FormStartPosition.CenterParent

                        Dim dgvDetalle As New DataGridView()
                        dgvDetalle.Dock = DockStyle.Fill
                        dgvDetalle.AutoGenerateColumns = True
                        dgvDetalle.DataSource = dtDetalle
                        dgvDetalle.ReadOnly = True
                        dgvDetalle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

                        frmDetalle.Controls.Add(dgvDetalle)
                        frmDetalle.ShowDialog()
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al consultar el detalle: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub TableLayoutPanel1_Paint(sender As Object, e As PaintEventArgs) Handles TableLayoutPanel1.Paint
    End Sub

End Class