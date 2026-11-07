
Imports System.Data.OleDb

Public Class UC_Compras

    '========================================
    ' INICIALIZAR FORMULARIO
    '========================================

    Private Sub UC_Compras_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ConfigurarTabla()
        CargarProveedor()
        ActualizarNumeroCompra()

        btnBuscarProducto.Enabled = False
        btnCobrar.Enabled = False
        btnEliminar.Enabled = False

        lblTotal.Text = "$0.00"

    End Sub

    '========================================
    ' CONFIGURAR DATAGRIDVIEW
    '========================================

    Private Sub ConfigurarTabla()

        dgvCompra.Columns.Clear()

        dgvCompra.AllowUserToAddRows = False
        dgvCompra.AllowUserToDeleteRows = False
        dgvCompra.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvCompra.MultiSelect = False
        dgvCompra.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

        dgvCompra.Columns.Add("ID_prod", "ID")
        dgvCompra.Columns.Add("Cantidad", "Cantidad (kg)")
        dgvCompra.Columns.Add("Codigo", "Código")
        dgvCompra.Columns.Add("Descripcion", "Descripción")
        dgvCompra.Columns.Add("Precio", "Precio por kilo")
        dgvCompra.Columns.Add("Descuento", "Descuento (%)")
        dgvCompra.Columns.Add("Subtotal", "Subtotal")

        dgvCompra.Columns("ID_prod").Visible = False

        dgvCompra.Columns("Cantidad").ReadOnly = False
        dgvCompra.Columns("Descuento").ReadOnly = False

        dgvCompra.Columns("Codigo").ReadOnly = True
        dgvCompra.Columns("Descripcion").ReadOnly = True
        dgvCompra.Columns("Precio").ReadOnly = True
        dgvCompra.Columns("Subtotal").ReadOnly = True

        dgvCompra.Columns("Precio").DefaultCellStyle.Format = "C2"
        dgvCompra.Columns("Subtotal").DefaultCellStyle.Format = "C2"
        dgvCompra.Columns("Descuento").DefaultCellStyle.Format = "N2"

    End Sub

    '========================================
    ' CARGAR PROVEEDORES
    '========================================

    Private Sub CargarProveedor()

        Try

            Using conexion As OleDbConnection = ObtenerConexion()

                Dim consulta As String =
                    "SELECT ID_prov, Nombre_prov FROM proveedor ORDER BY Nombre_prov"

                Using adaptador As New OleDbDataAdapter(consulta, conexion)

                    Dim tabla As New DataTable()
                    adaptador.Fill(tabla)

                    cboProveedor.DataSource = tabla
                    cboProveedor.DisplayMember = "Nombre_prov"
                    cboProveedor.ValueMember = "ID_prov"
                    cboProveedor.SelectedIndex = -1

                End Using

            End Using

        Catch ex As Exception

            MessageBox.Show("Error al cargar proveedores: " & ex.Message)

        End Try

    End Sub

    '========================================
    ' SELECCIONAR PROVEEDOR
    '========================================

    Private Sub cboProveedor_SelectedIndexChanged(
        sender As Object,
        e As EventArgs
    ) Handles cboProveedor.SelectedIndexChanged

        btnBuscarProducto.Enabled =
            TypeOf cboProveedor.SelectedValue Is Integer

    End Sub

    '========================================
    ' ABRIR VENTANA DE PRODUCTOS
    '========================================

    Private Sub btnBuscarProducto_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnBuscarProducto.Click

        If cboProveedor.SelectedIndex = -1 Then
            MessageBox.Show("Selecciona un proveedor primero.")
            Return
        End If

        Using ventana As New C_SeleccionarProducto()

            If ventana.ShowDialog() = DialogResult.OK Then

                AgregarProducto(
                    ventana.IDProducto,
                    ventana.CodigoProducto,
                    ventana.DescripcionProducto,
                    ventana.PrecioProducto
                )

            End If

        End Using

    End Sub

    '========================================
    ' AGREGAR PRODUCTO A LA COMPRA
    '========================================

    Private Sub AgregarProducto(
        id As Integer,
        codigo As String,
        descripcion As String,
        precio As Decimal
    )

        'Verificar si el producto ya está agregado

        For Each fila As DataGridViewRow In dgvCompra.Rows

            If CInt(fila.Cells("ID_prod").Value) = id Then

                Dim cantidadActual As Decimal =
                    CDec(fila.Cells("Cantidad").Value)

                fila.Cells("Cantidad").Value = cantidadActual + 1

                ActualizarSubtotal(fila)

                Return

            End If

        Next

        'Agregar nuevo producto

        dgvCompra.Rows.Add(
            id,
            1D,
            codigo,
            descripcion,
            precio,
            0D,
            precio
        )

        btnCobrar.Enabled = True
        btnEliminar.Enabled = True

        CalcularTotal()

    End Sub

    '========================================
    ' MODIFICAR CANTIDAD
    '========================================

    Private Sub dgvCompra_CellEndEdit(
        sender As Object,
        e As DataGridViewCellEventArgs
    ) Handles dgvCompra.CellEndEdit

        If e.RowIndex < 0 Then Return

        Dim fila As DataGridViewRow = dgvCompra.Rows(e.RowIndex)

        Select Case dgvCompra.Columns(e.ColumnIndex).Name

            Case "Cantidad"

                Dim cantidad As Decimal

                If Not Decimal.TryParse(
                Convert.ToString(fila.Cells("Cantidad").Value),
                cantidad
            ) OrElse cantidad <= 0 Then

                    MessageBox.Show("Ingresa una cantidad válida.")

                    fila.Cells("Cantidad").Value = 1D

                End If

            Case "Descuento"

                Dim descuento As Decimal

                If Not Decimal.TryParse(
                Convert.ToString(fila.Cells("Descuento").Value),
                descuento
            ) OrElse descuento < 0 OrElse descuento > 100 Then

                    MessageBox.Show(
                    "El descuento debe ser un valor entre 0 y 100."
                )

                    fila.Cells("Descuento").Value = 0D

                End If

        End Select

        ActualizarSubtotal(fila)

    End Sub

    '========================================
    ' ACTUALIZAR SUBTOTAL
    '========================================

    Private Sub ActualizarSubtotal(fila As DataGridViewRow)

        Dim cantidad As Decimal =
            Convert.ToDecimal(fila.Cells("Cantidad").Value)

        Dim precio As Decimal =
            Convert.ToDecimal(fila.Cells("Precio").Value)

        Dim descuento As Decimal =
            Convert.ToDecimal(fila.Cells("Descuento").Value)

        'Aplicar descuento al precio unitario
        Dim precioDescontado As Decimal =
            precio * (1 - descuento / 100D)

        'Redondear el precio unitario a dos decimales
        precioDescontado = Math.Round(
            precioDescontado,
            2,
            MidpointRounding.AwayFromZero
        )

        'Calcular subtotal
        Dim subtotal As Decimal =
            cantidad * precioDescontado

        fila.Cells("Subtotal").Value = Math.Round(
            subtotal,
            2,
            MidpointRounding.AwayFromZero
        )

        CalcularTotal()

    End Sub

    '========================================
    ' CALCULAR TOTAL DE LA COMPRA
    '========================================

    Private Sub CalcularTotal()

        Dim total As Decimal = 0

        For Each fila As DataGridViewRow In dgvCompra.Rows

            total += Convert.ToDecimal(fila.Cells("Subtotal").Value)

        Next

        lblTotal.Text = total.ToString("C2")

    End Sub

    '========================================
    ' ELIMINAR PRODUCTO SELECCIONADO
    '========================================

    Private Sub btnEliminar_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnEliminar.Click

        If dgvCompra.SelectedRows.Count = 0 Then

            MessageBox.Show("Selecciona un producto para eliminar.")
            Return

        End If

        dgvCompra.Rows.Remove(dgvCompra.SelectedRows(0))

        CalcularTotal()

        If dgvCompra.Rows.Count = 0 Then

            btnCobrar.Enabled = False
            btnEliminar.Enabled = False

        End If

    End Sub

    '========================================
    ' REGISTRAR COMPRA
    '========================================

    Private Sub btnAgregar_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnCobrar.Click

        GuardarCompra()

    End Sub

    Private Sub GuardarCompra()

        If cboProveedor.SelectedIndex = -1 OrElse
           Not TypeOf cboProveedor.SelectedValue Is Integer Then

            MessageBox.Show("Selecciona un proveedor.")
            Return

        End If

        If dgvCompra.Rows.Count = 0 Then

            MessageBox.Show("Agrega al menos un producto.")
            Return

        End If

        If InicioSesion.IdUsuarioActual <= 0 Then

            MessageBox.Show("No se ha identificado al empleado.")
            Return

        End If

        Try

            dgvCompra.EndEdit()

            Dim total As Decimal = 0

            'Calcular y validar total

            For Each fila As DataGridViewRow In dgvCompra.Rows

                Dim cantidad As Decimal =
            Convert.ToDecimal(fila.Cells("Cantidad").Value)

                Dim precio As Decimal =
            Convert.ToDecimal(fila.Cells("Precio").Value)

                Dim descuento As Decimal =
            Convert.ToDecimal(fila.Cells("Descuento").Value)

                If cantidad <= 0 OrElse precio < 0 OrElse
           descuento < 0 OrElse descuento > 100 Then

                    MessageBox.Show(
                "Verifica las cantidades, precios y descuentos. " &
                "El descuento debe estar entre 0 y 100."
            )

                    Return

                End If

                Dim precioDescontado As Decimal =
            Math.Round(
                precio * (1 - descuento / 100D),
                2,
                MidpointRounding.AwayFromZero
            )

                total += Math.Round(
                cantidad * precioDescontado,
                2,
                MidpointRounding.AwayFromZero
             )

            Next

            Dim idProveedor As Integer =
                Convert.ToInt32(cboProveedor.SelectedValue)

            Using conexion As OleDbConnection = ObtenerConexion()

                Using transaccion As OleDbTransaction =
                    conexion.BeginTransaction()

                    Try

                        '--------------------------------
                        ' INSERTAR COMPRA
                        '--------------------------------

                        Dim consultaCompra As String =
                            "INSERT INTO Compra " &
                            "(Fecha_com, ID_prov, ID_emp, total_com) " &
                            "VALUES (?, ?, ?, ?)"

                        Using comando As New OleDbCommand(
                            consultaCompra,
                            conexion,
                            transaccion
                        )

                            comando.Parameters.Add(
                                "Fecha", OleDbType.Date
                            ).Value = DateTime.Now

                            comando.Parameters.Add(
                                "Proveedor", OleDbType.Integer
                            ).Value = idProveedor

                            comando.Parameters.Add(
                                "Empleado", OleDbType.Integer
                            ).Value = InicioSesion.IdUsuarioActual

                            comando.Parameters.Add(
                                "Total", OleDbType.Currency
                            ).Value = total

                            comando.ExecuteNonQuery()

                        End Using

                        '--------------------------------
                        ' OBTENER ID DE LA COMPRA
                        '--------------------------------

                        Dim idCompra As Integer

                        Using comandoID As New OleDbCommand(
                            "SELECT @@IDENTITY",
                            conexion,
                            transaccion
                        )

                            idCompra = Convert.ToInt32(
                                comandoID.ExecuteScalar()
                            )

                        End Using

                        '--------------------------------
                        ' INSERTAR DETALLES EN Detalle_CP
                        '--------------------------------

                        Dim consultaDetalle As String =
                            "INSERT INTO Detalle_CP " &
                            "(ID_com, ID_prod, Cantidad_CP, " &
                            "CostoUnitario_CP, Descuento_CP, subtotal_CP) " &
                            "VALUES (?, ?, ?, ?, ?, ?)"

                        For Each fila As DataGridViewRow In dgvCompra.Rows
                            Dim idProducto As Integer =
                                CInt(fila.Cells("ID_prod").Value)

                            Dim cantidad As Decimal =
                                CDec(fila.Cells("Cantidad").Value)

                            Dim precio As Decimal =
                                CDec(fila.Cells("Precio").Value)

                            Dim descuento As Decimal =
                                CDec(fila.Cells("Descuento").Value)

                            'Calcular precio unitario con descuento
                            Dim precioDescontado As Decimal =
                                Math.Round(
                                    precio * (1 - descuento / 100D),
                                    2,
                                    MidpointRounding.AwayFromZero
                                )

                            'Calcular subtotal con descuento
                            Dim subtotal As Decimal =
                                Math.Round(
                                    cantidad * precioDescontado,
                                    2,
                                    MidpointRounding.AwayFromZero
                                )

                            Using comando As New OleDbCommand(
                                consultaDetalle,
                                conexion,
                                transaccion
                            )

                                comando.Parameters.Add(
                                    "Compra", OleDbType.Integer
                                ).Value = idCompra

                                comando.Parameters.Add(
                                    "Producto", OleDbType.Integer
                                ).Value = idProducto

                                comando.Parameters.Add(
                                    "Cantidad", OleDbType.Double
                                ).Value = CDbl(cantidad)

                                comando.Parameters.Add(
                                    "Costo", OleDbType.Currency
                                ).Value = precio

                                comando.Parameters.Add(
                                    "Descuento", OleDbType.Double
                                ).Value = CDbl(descuento)

                                comando.Parameters.Add(
                                    "Subtotal", OleDbType.Currency
                                ).Value = subtotal

                                comando.ExecuteNonQuery()

                            End Using

                        Next

                        '--------------------------------
                        ' CONFIRMAR TRANSACCIÓN
                        '--------------------------------

                        transaccion.Commit()

                        MessageBox.Show(
                            "Compra registrada correctamente." &
                            vbCrLf & "Folio: " & idCompra &
                            vbCrLf & "Total: " & total.ToString("C2"),
                            "Compra registrada",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        )

                    Catch ex As Exception

                        transaccion.Rollback()

                        Throw New Exception(
                            "Error al registrar la compra: " & ex.Message
                        )

                    End Try

                End Using

            End Using

            '--------------------------------
            ' LIMPIAR FORMULARIO
            '--------------------------------

            dgvCompra.Rows.Clear()

            cboProveedor.SelectedIndex = -1

            lblTotal.Text = "$0.00"

            btnBuscarProducto.Enabled = False
            btnCobrar.Enabled = False
            btnEliminar.Enabled = False

            'Actualizar el siguiente número de compra
            ActualizarNumeroCompra()

        Catch ex As Exception

            MessageBox.Show(
                ex.Message,
                "Error al registrar compra",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )

        End Try

    End Sub

    '========================================
    ' MOSTRAR SIGUIENTE NÚMERO DE COMPRA
    '========================================

    Private Sub ActualizarNumeroCompra()

        Try

            Using conexion As OleDbConnection = ObtenerConexion()

                Dim consulta As String =
                "SELECT MAX(ID_com) FROM Compras"

                Using comando As New OleDbCommand(consulta, conexion)

                    Dim resultado As Object = comando.ExecuteScalar()

                    Dim siguienteID As Integer = 1

                    If resultado IsNot DBNull.Value AndAlso resultado IsNot Nothing Then
                        siguienteID = Convert.ToInt32(resultado) + 1
                    End If

                    lblNumeroCompra.Text = siguienteID.ToString()

                End Using

            End Using

        Catch ex As Exception

            MessageBox.Show(
            "Error al consultar el número de compra: " & ex.Message
        )

        End Try

    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles lblTotal.Click

    End Sub
End Class

