Imports System.Data.OleDb

Public Class UC_I_Nuevo

    Private Sub UC_I_Nuevo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MTB_Codigo.ReadOnly = True
        ObtenerSiguienteID()
        CargarCategoriasEnComboBox()
        CargarProveedoresEnComboBox()
    End Sub

    Private Sub ObtenerSiguienteID()
        Try
            Using con As OleDbConnection = ObtenerConexion()
                Dim query As String = "SELECT MAX(Id_prod) FROM Producto"
                Using cmd As New OleDbCommand(query, con)
                    Dim result = cmd.ExecuteScalar()
                    If result IsNot DBNull.Value AndAlso result IsNot Nothing Then
                        MTB_Codigo.Text = (Convert.ToInt32(result) + 1).ToString()
                    Else
                        MTB_Codigo.Text = "1"
                    End If
                End Using
            End Using
        Catch ex As Exception
            MTB_Codigo.Text = "1"
        End Try
    End Sub

    Private Sub CargarCategoriasEnComboBox()
        Try
            Using con As OleDbConnection = ObtenerConexion()
                Dim query As String = "SELECT Id_cat, Nombre_cat FROM Categoria"
                Using adapter As New OleDbDataAdapter(query, con)
                    Dim dt As New DataTable()
                    adapter.Fill(dt)
                    CB_Cat.DataSource = dt
                    CB_Cat.DisplayMember = "Nombre_cat"
                    CB_Cat.ValueMember = "Id_cat"
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al cargar categorías: " & ex.Message)
        End Try
    End Sub

    Private Sub CargarProveedoresEnComboBox()
        Try
            Using con As OleDbConnection = ObtenerConexion()
                Dim query As String = "SELECT Id_prov, Nombre_prov FROM Proveedor"
                Using adapter As New OleDbDataAdapter(query, con)
                    Dim dt As New DataTable()
                    adapter.Fill(dt)
                    CB_Proveedores.DataSource = dt
                    CB_Proveedores.DisplayMember = "Nombre_prov"
                    CB_Proveedores.ValueMember = "Id_prov"
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al cargar proveedores: " & ex.Message)
        End Try
    End Sub

    ' Botón Agregar / Guardar
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If String.IsNullOrWhiteSpace(MTB_Descripcion.Text) Then
            MessageBox.Show("Por favor, ingrese la descripción del producto.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Try
            Using con As OleDbConnection = ObtenerConexion()
                Dim query As String = "INSERT INTO Producto (Descripcion_prod, Id_cat, PVenta_prod, PCompra_prod, Existencias, Id_prov) VALUES (?, ?, ?, ?, ?, ?)"
                Using cmd As New OleDbCommand(query, con)
                    cmd.Parameters.AddWithValue("?", MTB_Descripcion.Text.Trim())
                    cmd.Parameters.AddWithValue("?", Convert.ToInt32(CB_Cat.SelectedValue))
                    cmd.Parameters.AddWithValue("?", Convert.ToDecimal(MTB_PVenta.Text.Trim()))
                    cmd.Parameters.AddWithValue("?", Convert.ToDecimal(MTB_PCompra.Text.Trim()))
                    cmd.Parameters.AddWithValue("?", Convert.ToInt32(MTB_Existencias.Text.Trim()))
                    cmd.Parameters.AddWithValue("?", Convert.ToInt32(CB_Proveedores.SelectedValue))
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show("¡Producto registrado exitosamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LimpiarCampos()
            ObtenerSiguienteID()
        Catch ex As Exception
            MessageBox.Show("Error al registrar el producto: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LimpiarCampos()
        MTB_Descripcion.Clear()
        MTB_PCompra.Clear()
        MTB_PVenta.Clear()
        MTB_Existencias.Clear()
        If CB_Cat.Items.Count > 0 Then CB_Cat.SelectedIndex = 0
        If CB_Proveedores.Items.Count > 0 Then CB_Proveedores.SelectedIndex = 0
    End Sub

End Class