Imports System.Data.OleDb

Public Class UC_I_Modificar

    Private Sub UC_I_Modificar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MTB_Codigo.ReadOnly = True
        CargarCombos()
    End Sub

    Private Sub CargarCombos()
        Try
            Using con As OleDbConnection = ObtenerConexion()
                Dim dtCat As New DataTable()
                Using adapterCat As New OleDbDataAdapter("SELECT Id_cat, Nombre_cat FROM Categoria", con)
                    adapterCat.Fill(dtCat)
                    CB_Cat.DataSource = dtCat
                    CB_Cat.DisplayMember = "Nombre_cat"
                    CB_Cat.ValueMember = "Id_cat"
                End Using

                Dim dtProv As New DataTable()
                Using adapterProv As New OleDbDataAdapter("SELECT Id_prov, Nombre_prov FROM Proveedor", con)
                    adapterProv.Fill(dtProv)
                    CB_Proveedores.DataSource = dtProv
                    CB_Proveedores.DisplayMember = "Nombre_prov"
                    CB_Proveedores.ValueMember = "Id_prov"
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al cargar combos: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Botón Buscar Producto
    Private Sub Button_Buscar_Click(sender As Object, e As EventArgs) Handles Button_Buscar.Click
        Dim buscador As New Busqueda_Venta()
        buscador.TipoBusqueda = "PRODUCTO"

        If buscador.ShowDialog() = DialogResult.OK Then
            MTB_Codigo.Text = buscador.CodigoSeleccionado
            MTB_Descripcion.Text = buscador.DescripcionSeleccionada
            MTB_PVenta.Text = buscador.PrecioSeleccionado.ToString()

            CargarDetallesProducto(Convert.ToInt32(buscador.CodigoSeleccionado))
        End If
    End Sub

    ' Botón Buscar Categoría
    Private Sub Button_Cat_Click(sender As Object, e As EventArgs) Handles Button_Cat.Click
        Dim buscador As New Busqueda_Venta()
        buscador.TipoBusqueda = "CATEGORIA"
        If buscador.ShowDialog() = DialogResult.OK Then
            CB_Cat.SelectedValue = Convert.ToInt32(buscador.CodigoSeleccionado)
        End If
    End Sub

    ' Botón Buscar Proveedor
    Private Sub Button_Prov_Click(sender As Object, e As EventArgs) Handles Button_Prov.Click
        Dim buscador As New Busqueda_Venta()
        buscador.TipoBusqueda = "PROVEEDOR"
        If buscador.ShowDialog() = DialogResult.OK Then
            CB_Proveedores.SelectedValue = Convert.ToInt32(buscador.CodigoSeleccionado)
        End If
    End Sub

    Private Sub CargarDetallesProducto(idProd As Integer)
        Try
            Using con As OleDbConnection = ObtenerConexion()
                Dim query As String = "SELECT * FROM Producto WHERE Id_prod = ?"
                Using cmd As New OleDbCommand(query, con)
                    cmd.Parameters.AddWithValue("?", idProd)
                    Using reader As OleDbDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            MTB_PCompra.Text = reader("PCompra_prod").ToString()
                            MTB_Existencias.Text = reader("Existencias").ToString()
                            CB_Cat.SelectedValue = reader("Id_cat")
                            CB_Proveedores.SelectedValue = reader("Id_prov")
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al cargar detalles del producto: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Botón Modificar
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If String.IsNullOrWhiteSpace(MTB_Codigo.Text) Then
            MessageBox.Show("Por favor, busque y seleccione un producto primero.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If String.IsNullOrWhiteSpace(MTB_Descripcion.Text) Then
            MessageBox.Show("La descripción del producto no puede estar vacía.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Try
            Using con As OleDbConnection = ObtenerConexion()
                Dim query As String = "UPDATE Producto SET Descripcion_prod = ?, Id_cat = ?, PVenta_prod = ?, PCompra_prod = ?, Existencias = ?, Id_prov = ? WHERE Id_prod = ?"
                Using cmd As New OleDbCommand(query, con)
                    cmd.Parameters.AddWithValue("?", MTB_Descripcion.Text.Trim())
                    cmd.Parameters.AddWithValue("?", Convert.ToInt32(CB_Cat.SelectedValue))
                    cmd.Parameters.AddWithValue("?", Convert.ToDecimal(MTB_PVenta.Text.Trim()))
                    cmd.Parameters.AddWithValue("?", Convert.ToDecimal(MTB_PCompra.Text.Trim()))
                    cmd.Parameters.AddWithValue("?", Convert.ToInt32(MTB_Existencias.Text.Trim()))
                    cmd.Parameters.AddWithValue("?", Convert.ToInt32(CB_Proveedores.SelectedValue))
                    cmd.Parameters.AddWithValue("?", Convert.ToInt32(MTB_Codigo.Text.Trim()))
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show("¡Producto modificado exitosamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LimpiarCampos()
        Catch ex As Exception
            MessageBox.Show("Error al actualizar el producto: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LimpiarCampos()
        MTB_Codigo.Clear()
        MTB_Descripcion.Clear()
        MTB_PCompra.Clear()
        MTB_PVenta.Clear()
        MTB_Existencias.Clear()
        If CB_Cat.Items.Count > 0 Then CB_Cat.SelectedIndex = 0
        If CB_Proveedores.Items.Count > 0 Then CB_Proveedores.SelectedIndex = 0
    End Sub

End Class