Imports System.ComponentModel
Imports System.Data.OleDb

Public Class Busqueda_Venta

    ' Propiedades públicas para devolver la selección al formulario principal
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property CodigoSeleccionado As String = ""

    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property DescripcionSeleccionada As String = ""

    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property PrecioSeleccionado As Decimal = 0D

    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property DireccionSeleccionada As String = ""

    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property TelefonoSeleccionado As String = ""

    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property TipoBusqueda As String = "PRODUCTO"

    Private Sub Busqueda_Venta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Configurar el DataGridView para deshabilitar la fila vacía con el asterisco
        If dgvProductos IsNot Nothing Then
            dgvProductos.AllowUserToAddRows = False
            dgvProductos.AllowUserToDeleteRows = False
            dgvProductos.MultiSelect = False
            dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            dgvProductos.ReadOnly = True
        End If

        ' Inicializar según el tipo de búsqueda solicitado
        CargarDatosIniciales()
    End Sub

    Private Sub CargarDatosIniciales()
        Select Case TipoBusqueda.ToUpper()
            Case "EMPLEADO"
                Me.Text = "Buscar Empleado"
                If ComboBox IsNot Nothing Then ComboBox.Visible = False
                CargarDatosGenericos("SELECT E.Id_emp, E.Nombre_emp, R.Descripcion_rol, E.Telefono_emp, E.rfc_emp FROM (Empleado E INNER JOIN Rol R ON E.ID_rol = R.ID_rol)")

            Case "PROVEEDOR"
                Me.Text = "Buscar Proveedor"
                If ComboBox IsNot Nothing Then ComboBox.Visible = False
                CargarDatosGenericos("SELECT Id_prov AS Código, Nombre_prov AS Proveedor, Direccion_prov AS Dirección, Telefono_prov AS Teléfono FROM Proveedor")

            Case "CLIENTE"
                Me.Text = "Buscar Cliente"
                If ComboBox IsNot Nothing Then ComboBox.Visible = False
                CargarDatosGenericos("SELECT Id_cli AS Código, Nombre_cli AS Cliente, Telefono_cli AS Teléfono, Correo_cli AS Correo, Direccion_cli AS Dirección FROM Cliente")

            Case "CATEGORIA"
                Me.Text = "Buscar Categoría"
                If ComboBox IsNot Nothing Then ComboBox.Visible = False
                CargarDatosGenericos("SELECT Id_cat AS Código, Nombre_cat AS Categoría FROM Categoria")

            Case Else ' "PRODUCTO"
                Me.Text = "Buscar Producto"
                If ComboBox IsNot Nothing Then ComboBox.Visible = True
                CargarCategorias()
                FiltrarProductos("", 0)
        End Select
    End Sub

    ' Método general para cargar tablas sin filtro complejo
    Private Sub CargarDatosGenericos(queryBase As String, Optional filtro As String = "")
        Try
            Using con As OleDbConnection = ObtenerConexion()
                Dim query As String = queryBase
                Dim cmd As OleDbCommand

                If Not String.IsNullOrWhiteSpace(filtro) Then
                    Dim campoFiltro As String = "Nombre_prov"
                    If TipoBusqueda.ToUpper() = "EMPLEADO" Then campoFiltro = "E.Nombre_emp"
                    If TipoBusqueda.ToUpper() = "CLIENTE" Then campoFiltro = "Nombre_cli"
                    If TipoBusqueda.ToUpper() = "CATEGORIA" Then campoFiltro = "Nombre_cat"

                    query &= $" WHERE {campoFiltro} LIKE ?"
                    cmd = New OleDbCommand(query, con)
                    cmd.Parameters.Add("?", OleDbType.VarChar).Value = "%" & filtro.Trim() & "%"
                Else
                    cmd = New OleDbCommand(query, con)
                End If

                Using adapter As New OleDbDataAdapter(cmd)
                    Dim dt As New DataTable()
                    adapter.Fill(dt)
                    If dgvProductos IsNot Nothing Then
                        dgvProductos.DataSource = dt
                        dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al cargar datos: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Cargar categorías para el ComboBox de productos
    Private Sub CargarCategorias()
        Try
            Using con As OleDbConnection = ObtenerConexion()
                Dim query As String = "SELECT Id_cat, Nombre_cat FROM Categoria"
                Using adapter As New OleDbDataAdapter(query, con)
                    Dim dt As New DataTable()
                    adapter.Fill(dt)

                    Dim filaTodas As DataRow = dt.NewRow()
                    filaTodas("Id_cat") = 0
                    filaTodas("Nombre_cat") = "-- Todas las categorías --"
                    dt.Rows.InsertAt(filaTodas, 0)

                    If ComboBox IsNot Nothing Then
                        ComboBox.DataSource = dt
                        ComboBox.DisplayMember = "Nombre_cat"
                        ComboBox.ValueMember = "Id_cat"
                        ComboBox.SelectedIndex = 0
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al cargar categorías: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Filtrar productos por texto y categoría (mostrando nombres de Categoría y Proveedor)
    Private Sub FiltrarProductos(filtroTexto As String, idCategoria As Integer)
        Try
            Using con As OleDbConnection = ObtenerConexion()
                Dim query As String = "SELECT P.Id_prod AS [Código], P.Descripcion_prod AS [Descripción], " &
                                      "P.PVenta_prod AS [Precio Venta], P.PCompra_prod AS [Precio Compra], " &
                                      "P.Existencias AS [Existencias], C.Nombre_cat AS [Categoría], Pr.Nombre_prov AS [Proveedor] " &
                                      "FROM ((Producto P " &
                                      "INNER JOIN Categoria C ON P.Id_cat = C.Id_cat) " &
                                      "INNER JOIN Proveedor Pr ON P.Id_prov = Pr.ID_prov) " &
                                      "WHERE 1=1"

                If Not String.IsNullOrWhiteSpace(filtroTexto) Then
                    query &= " AND P.Descripcion_prod LIKE ?"
                End If

                If idCategoria > 0 Then
                    query &= " AND P.Id_cat = ?"
                End If

                Using cmd As New OleDbCommand(query, con)
                    If Not String.IsNullOrWhiteSpace(filtroTexto) Then
                        cmd.Parameters.Add("?", OleDbType.VarChar).Value = "%" & filtroTexto.Trim() & "%"
                    End If

                    If idCategoria > 0 Then
                        cmd.Parameters.Add("?", OleDbType.Integer).Value = idCategoria
                    End If

                    Using adapter As New OleDbDataAdapter(cmd)
                        Dim dt As New DataTable()
                        adapter.Fill(dt)

                        If dgvProductos IsNot Nothing Then
                            dgvProductos.DataSource = dt
                            dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al filtrar productos: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Evento unificado para el txtBuscar en cualquier módulo
    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        Select Case TipoBusqueda.ToUpper()
            Case "PRODUCTO"
                Dim idCatSel As Integer = 0
                If ComboBox IsNot Nothing AndAlso ComboBox.SelectedValue IsNot Nothing AndAlso TypeOf ComboBox.SelectedValue Is Integer Then
                    Integer.TryParse(ComboBox.SelectedValue.ToString(), idCatSel)
                End If
                FiltrarProductos(txtBuscar.Text, idCatSel)

            Case "EMPLEADO"
                CargarDatosGenericos("SELECT E.Id_emp, E.Nombre_emp, R.Descripcion_rol, E.Telefono_emp, E.rfc_emp FROM (Empleado E INNER JOIN Rol R ON E.ID_rol = R.ID_rol)", txtBuscar.Text)

            Case "PROVEEDOR"
                CargarDatosGenericos("SELECT Id_prov AS Código, Nombre_prov AS Proveedor, Direccion_prov AS Dirección, Telefono_prov AS Teléfono FROM Proveedor", txtBuscar.Text)

            Case "CLIENTE"
                CargarDatosGenericos("SELECT Id_cli AS Código, Nombre_cli AS Cliente, Telefono_cli AS Teléfono, Correo_cli AS Correo, Direccion_cli AS Dirección FROM Cliente", txtBuscar.Text)

            Case "CATEGORIA"
                CargarDatosGenericos("SELECT Id_cat AS Código, Nombre_cat AS Categoría FROM Categoria", txtBuscar.Text)
        End Select
    End Sub

    Private Sub Combobox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox.SelectedIndexChanged
        If TipoBusqueda.ToUpper() = "PRODUCTO" AndAlso ComboBox IsNot Nothing AndAlso ComboBox.SelectedValue IsNot Nothing AndAlso TypeOf ComboBox.SelectedValue Is Integer Then
            Dim idCatSel As Integer = Convert.ToInt32(ComboBox.SelectedValue)
            FiltrarProductos(txtBuscar.Text, idCatSel)
        End If
    End Sub

    Private Sub dgvProductos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProductos.CellDoubleClick
        If e.RowIndex >= 0 Then
            SeleccionarActual()
        End If
    End Sub

    Private Sub dgvProductos_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvProductos.KeyDown
        If e.KeyCode = Keys.Enter Then
            SeleccionarActual()
            e.Handled = True
        End If
    End Sub

    ' Función auxiliar para buscar el valor de una celda por su alias o por su nombre de columna original
    Private Function ObtenerValorCelda(row As DataGridViewRow, col1 As String, Optional col2 As String = "") As String
        If dgvProductos.Columns.Contains(col1) AndAlso row.Cells(col1).Value IsNot Nothing Then
            Return row.Cells(col1).Value.ToString()
        ElseIf Not String.IsNullOrEmpty(col2) AndAlso dgvProductos.Columns.Contains(col2) AndAlso row.Cells(col2).Value IsNot Nothing Then
            Return row.Cells(col2).Value.ToString()
        End If
        Return ""
    End Function

    Private Sub SeleccionarActual()
        If dgvProductos IsNot Nothing AndAlso dgvProductos.CurrentRow IsNot Nothing Then
            Dim row As DataGridViewRow = dgvProductos.CurrentRow
            If row.IsNewRow Then Exit Sub

            Select Case TipoBusqueda.ToUpper()
                Case "EMPLEADO"
                    CodigoSeleccionado = ObtenerValorCelda(row, "Id_emp", "Código")
                    DescripcionSeleccionada = ObtenerValorCelda(row, "Nombre_emp", "Empleado")
                    TelefonoSeleccionado = ObtenerValorCelda(row, "Telefono_emp", "Teléfono")

                Case "PROVEEDOR"
                    CodigoSeleccionado = ObtenerValorCelda(row, "Código", "Id_prov")
                    DescripcionSeleccionada = ObtenerValorCelda(row, "Proveedor", "Nombre_prov")
                    DireccionSeleccionada = ObtenerValorCelda(row, "Dirección", "Direccion_prov")
                    TelefonoSeleccionado = ObtenerValorCelda(row, "Teléfono", "Telefono_prov")

                Case "CLIENTE"
                    CodigoSeleccionado = ObtenerValorCelda(row, "Código", "Id_cli")
                    DescripcionSeleccionada = ObtenerValorCelda(row, "Cliente", "Nombre_cli")
                    TelefonoSeleccionado = ObtenerValorCelda(row, "Teléfono", "Telefono_cli")
                    DireccionSeleccionada = ObtenerValorCelda(row, "Dirección", "Direccion_cli")

                Case "CATEGORIA"
                    CodigoSeleccionado = ObtenerValorCelda(row, "Código", "Id_cat")
                    DescripcionSeleccionada = ObtenerValorCelda(row, "Categoría", "Nombre_cat")

                Case Else ' "PRODUCTO"
                    CodigoSeleccionado = ObtenerValorCelda(row, "Código", "Id_prod")
                    DescripcionSeleccionada = ObtenerValorCelda(row, "Descripción", "Descripcion_prod")

                    Dim precioTexto As String = ""
                    If Me.Tag IsNot Nothing AndAlso Me.Tag.ToString() = "COMPRA" Then
                        precioTexto = ObtenerValorCelda(row, "Precio Compra", "PCompra_prod")
                    Else
                        precioTexto = ObtenerValorCelda(row, "Precio Venta", "PVenta_prod")
                    End If

                    Decimal.TryParse(precioTexto, PrecioSeleccionado)
            End Select

            If Not String.IsNullOrWhiteSpace(CodigoSeleccionado) Then
                DialogResult = DialogResult.OK
                Close()
            End If
        End If
    End Sub

End Class