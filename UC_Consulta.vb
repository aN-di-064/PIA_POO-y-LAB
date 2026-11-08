Imports System.Data.OleDb

Public Class UC_Consulta

    Private idSeleccionado As Integer = 0

    Private Sub UC_Consulta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If ComboBox1.Items.Count = 0 Then
            ComboBox1.Items.Add("Inventario")
            ComboBox1.Items.Add("Categoria")
            ComboBox1.Items.Add("Clientes")
            ComboBox1.Items.Add("Proveedores")
            ComboBox1.SelectedIndex = 0
        End If

        ' Configuración de solo lectura en el DataGridView
        dgvProductos.ReadOnly = True
        dgvProductos.AllowUserToAddRows = False
        dgvProductos.AllowUserToDeleteRows = False
        dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvProductos.MultiSelect = False
        dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

        CentrarPanel()
        CargarDatosTabla(txtBuscar.Text.Trim())
    End Sub

    Private Sub UC_Consulta_Resized(sender As Object, e As EventArgs) Handles MyBase.Resize
        CentrarPanel()
    End Sub

    Private Sub CentrarPanel()
        If Panel1 IsNot Nothing AndAlso TableLayoutPanel1 IsNot Nothing Then
            Panel1.Location = New Point((TableLayoutPanel1.Width - Panel1.Width) \ 2, (TableLayoutPanel1.Height - Panel1.Height) \ 2)
        End If
    End Sub

    Private Sub CargarDatosTabla(Optional filtro As String = "")
        If filtro = "Buscar..." Then
            filtro = ""
        End If

        Try
            Dim query As String = ""
            Dim parametros As New List(Of OleDbParameter) From {}

            Select Case ComboBox1.SelectedIndex
                Case 0 ' Inventario (Productos)
                    query = "SELECT Id_prod AS 'Código', Descripcion_prod AS 'Descripción', PCompra_prod AS 'Precio Compra', PVenta_prod AS 'Precio Venta', Existencias AS 'Existencias' FROM Producto"
                    If Not String.IsNullOrEmpty(filtro) Then
                        query &= " WHERE Descripcion_prod LIKE ?"
                        parametros.Add(New OleDbParameter("?", "%" & filtro & "%"))
                    End If

                Case 1 ' Categoria
                    query = "SELECT Id_cat AS 'Código', Nombre_cat AS 'Categoría' FROM Categoria"
                    If Not String.IsNullOrEmpty(filtro) Then
                        query &= " WHERE Nombre_cat LIKE ?"
                        parametros.Add(New OleDbParameter("?", "%" & filtro & "%"))
                    End If

                Case 2 ' Clientes
                    query = "SELECT Id_cli AS 'ID', Nombre_cli AS 'Nombre', Telefono_cli AS 'Teléfono', Direccion_cli AS 'Dirección' FROM Cliente"
                    If Not String.IsNullOrEmpty(filtro) Then
                        query &= " WHERE Nombre_cli LIKE ?"
                        parametros.Add(New OleDbParameter("?", "%" & filtro & "%"))
                    End If

                Case 3 ' Proveedores
                    query = "SELECT ID_prov AS 'ID', Nombre_prov AS 'Nombre', Telefono_prov AS 'Teléfono', Direccion_prov AS 'Dirección' FROM Proveedor"
                    If Not String.IsNullOrEmpty(filtro) Then
                        query &= " WHERE Nombre_prov LIKE ?"
                        parametros.Add(New OleDbParameter("?", "%" & filtro & "%"))
                    End If
            End Select

            Dim dt As New DataTable()
            Using conexion As OleDbConnection = ObtenerConexion()
                If conexion IsNot Nothing AndAlso conexion.State = ConnectionState.Open Then
                    Using comando As New OleDbCommand(query, conexion)
                        If parametros.Count > 0 Then
                            comando.Parameters.AddRange(parametros.ToArray())
                        End If
                        Using adaptador As New OleDbDataAdapter(comando)
                            adaptador.Fill(dt)
                        End Using
                    End Using
                End If
            End Using

            dgvProductos.DataSource = dt
            idSeleccionado = 0
        Catch ex As Exception
            MessageBox.Show("Error al cargar los datos: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        CargarDatosTabla(txtBuscar.Text.Trim())
    End Sub

    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        CargarDatosTabla(txtBuscar.Text.Trim())
    End Sub

    Private Sub dgvProductos_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProductos.CellClick
        If e.RowIndex >= 0 Then
            Dim fila As DataGridViewRow = dgvProductos.Rows(e.RowIndex)
            If fila.Cells(0).Value IsNot Nothing Then
                Integer.TryParse(fila.Cells(0).Value.ToString(), idSeleccionado)
            End If
        End If
    End Sub

End Class