
Imports System.Data.OleDb

Public Class C_SeleccionarProducto

    '========================================
    ' PROPIEDADES PARA ENVIAR DATOS A UC_COMPRAS
    '========================================

    Public IDProducto As Integer
    Public CodigoProducto As String
    Public DescripcionProducto As String
    Public PrecioProducto As Decimal

    '========================================
    ' INICIAR FORMULARIO
    '========================================

    Private Sub C_SeleccionarProducto_Load(
        sender As Object,
        e As EventArgs
    ) Handles MyBase.Load

        ConfigurarTabla()
        CargarProductos("")

    End Sub

    '========================================
    ' CONFIGURAR DATAGRIDVIEW
    '========================================

    Private Sub ConfigurarTabla()

        dgvProductos.AutoGenerateColumns = True
        dgvProductos.AllowUserToAddRows = False
        dgvProductos.AllowUserToDeleteRows = False
        dgvProductos.ReadOnly = True

        dgvProductos.SelectionMode =
            DataGridViewSelectionMode.FullRowSelect

        dgvProductos.MultiSelect = False

        dgvProductos.AutoSizeColumnsMode =
            DataGridViewAutoSizeColumnsMode.Fill

    End Sub

    '========================================
    ' CARGAR Y BUSCAR PRODUCTOS
    '========================================

    Private Sub CargarProductos(filtro As String)

        Try

            Using conexion As OleDbConnection = ObtenerConexion()

                Dim consulta As String =
                    "SELECT ID_prod, Descripcion_prod, PCompra_prod " &
                    "FROM producto " &
                    "WHERE Descripcion_prod LIKE ? " &
                    "ORDER BY Descripcion_prod"

                Using comando As New OleDbCommand(consulta, conexion)

                    comando.Parameters.Add(
                        "Busqueda",
                        OleDbType.VarWChar
                    ).Value = "*" & filtro & "*"

                    Using adaptador As New OleDbDataAdapter(comando)

                        Dim tabla As New DataTable()

                        adaptador.Fill(tabla)

                        dgvProductos.DataSource = tabla

                    End Using

                End Using

            End Using

            'Ocultar identificador

            If dgvProductos.Columns.Contains("ID_prod") Then

                dgvProductos.Columns("ID_prod").Visible = False

            End If

            'Configurar encabezados

            If dgvProductos.Columns.Contains("Descripcion_prod") Then

                dgvProductos.Columns("Descripcion_prod").HeaderText =
                    "Descripción"

            End If

            If dgvProductos.Columns.Contains("PCompra_prod") Then

                dgvProductos.Columns("PCompra_prod").HeaderText =
                    "Precio de compra"

                dgvProductos.Columns("PCompra_prod").DefaultCellStyle.Format =
                    "C2"

            End If

        Catch ex As Exception

            MessageBox.Show(
                "Error al cargar los productos: " & ex.Message,
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )

        End Try

    End Sub

    '========================================
    ' BUSCAR PRODUCTOS AL ESCRIBIR
    '========================================

    Private Sub TextBox1_TextChanged(
        sender As Object,
        e As EventArgs
    ) Handles txtBuscar.TextChanged

        CargarProductos(txtBuscar.Text.Trim())

    End Sub

    '========================================
    ' SELECCIONAR PRODUCTO
    '========================================

    Private Sub Button1_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnSeleccionar.Click

        If dgvProductos.SelectedRows.Count = 0 Then

            MessageBox.Show(
                "Selecciona un producto.",
                "Aviso",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            )

            Return

        End If

        Try

            Dim fila As DataGridViewRow =
                dgvProductos.SelectedRows(0)

            'Obtener datos del producto

            IDProducto =
                Convert.ToInt32(fila.Cells("ID_prod").Value)

            CodigoProducto =
                IDProducto.ToString()

            DescripcionProducto =
                Convert.ToString(
                    fila.Cells("Descripcion_prod").Value
                )

            PrecioProducto =
                Convert.ToDecimal(
                    fila.Cells("PCompra_prod").Value
                )

            'Devolver información al formulario principal

            Me.DialogResult = DialogResult.OK

            Me.Close()

        Catch ex As Exception

            MessageBox.Show(
                "Error al seleccionar el producto: " & ex.Message
            )

        End Try

    End Sub

    '========================================
    ' CANCELAR SELECCIÓN
    '========================================

    Private Sub btnCancelar_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnCancelar.Click

        Me.DialogResult = DialogResult.Cancel

        Me.Close()

    End Sub

    '========================================
    ' SELECCIONAR MEDIANTE DOBLE CLIC
    '========================================

    Private Sub dgvProductos_CellDoubleClick(
        sender As Object,
        e As DataGridViewCellEventArgs
    ) Handles dgvProductos.CellDoubleClick

        If e.RowIndex >= 0 Then

            btnSeleccionar.PerformClick()

        End If

    End Sub

End Class
