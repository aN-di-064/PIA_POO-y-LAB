Imports System.ComponentModel
Imports System.Data.OleDb

Public Class Busqueda_Venta

    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property TipoBusqueda As String = "EMPLEADO"

    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property CodigoSeleccionado As String

    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property DescripcionSeleccionada As String

    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property DireccionSeleccionada As String

    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property TelefonoSeleccionado As String

    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property PrecioSeleccionado As Decimal

    Private Sub Busqueda_Venta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If TipoBusqueda = "EMPLEADO" Then
            If ComboBox IsNot Nothing Then ComboBox.Visible = True
            CargarFiltroRoles()
            CargarDatosGrid("")
        Else
            If ComboBox IsNot Nothing Then ComboBox.Visible = False
            CargarDatosGrid("")
        End If
    End Sub

    Private Sub CargarFiltroRoles()
        Try
            Using con As OleDbConnection = ObtenerConexion()
                Dim query As String = "SELECT ID_rol, Descripcion_rol FROM Rol"
                Using adapter As New OleDbDataAdapter(query, con)
                    Dim dt As New DataTable()
                    adapter.Fill(dt)

                    Dim filaTodos As DataRow = dt.NewRow()
                    filaTodos("ID_rol") = 0
                    filaTodos("Descripcion_rol") = "Todos"
                    dt.Rows.InsertAt(filaTodos, 0)

                    ComboBox.DataSource = dt
                    ComboBox.DisplayMember = "Descripcion_rol"
                    ComboBox.ValueMember = "ID_rol"
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al cargar roles: " & ex.Message)
        End Try
    End Sub

    Private Sub CargarDatosGrid(filtro As String)
        Try
            Using con As OleDbConnection = ObtenerConexion()
                Dim query As String = ""

                If TipoBusqueda = "EMPLEADO" Then
                    query = "SELECT E.Id_emp, E.Nombre_emp, R.Descripcion_rol, E.Telefono_emp, E.rfc_emp " &
                            "FROM Empleado E INNER JOIN Rol R ON E.ID_rol = R.ID_rol WHERE 1=1"

                    If Not String.IsNullOrWhiteSpace(txtBuscar.Text) Then
                        query &= " AND E.Nombre_emp LIKE ?"
                    End If

                    If ComboBox IsNot Nothing AndAlso ComboBox.Visible AndAlso ComboBox.SelectedValue IsNot Nothing AndAlso TypeOf ComboBox.SelectedValue Is Integer Then
                        Dim idRolSeleccionado As Integer = Convert.ToInt32(ComboBox.SelectedValue)
                        If idRolSeleccionado > 0 Then
                            query &= " AND E.ID_rol = " & idRolSeleccionado
                        End If
                    End If

                ElseIf TipoBusqueda = "CATEGORIA" Then
                    query = "SELECT Id_cat, Nombre_cat FROM Categoria WHERE 1=1"
                    If Not String.IsNullOrWhiteSpace(txtBuscar.Text) Then
                        query &= " AND Nombre_cat LIKE ?"
                    End If

                ElseIf TipoBusqueda = "PROVEEDOR" Then
                    query = "SELECT Id_prov, Nombre_prov, Direccion_prov, Telefono_prov FROM Proveedor WHERE 1=1"
                    If Not String.IsNullOrWhiteSpace(txtBuscar.Text) Then
                        query &= " AND Nombre_prov LIKE ?"
                    End If

                Else ' PRODUCTO (Incluye Id_cat e Id_prov para las relaciones foráneas)
                    query = "SELECT Id_prod, Descripcion_prod, PVenta_prod, PCompra_prod, Existencias, Id_cat, Id_prov FROM Producto WHERE 1=1"
                    If Not String.IsNullOrWhiteSpace(txtBuscar.Text) Then
                        query &= " AND Descripcion_prod LIKE ?"
                    End If
                End If

                Using cmd As New OleDbCommand(query, con)
                    If Not String.IsNullOrWhiteSpace(txtBuscar.Text) Then
                        cmd.Parameters.AddWithValue("?", "%" & txtBuscar.Text.Trim() & "%")
                    End If

                    Using adapter As New OleDbDataAdapter(cmd)
                        Dim dt As New DataTable()
                        adapter.Fill(dt)
                        dgvProductos.DataSource = dt
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al filtrar los datos: " & ex.Message)
        End Try
    End Sub

    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        CargarDatosGrid(txtBuscar.Text)
    End Sub

    Private Sub ComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox.SelectedIndexChanged
        If ComboBox IsNot Nothing AndAlso ComboBox.Visible AndAlso ComboBox.SelectedValue IsNot Nothing AndAlso TypeOf ComboBox.SelectedValue Is Integer Then
            CargarDatosGrid("")
        End If
    End Sub

    Private Sub dgvProductos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProductos.CellDoubleClick
        If e.RowIndex >= 0 Then
            Dim fila = dgvProductos.Rows(e.RowIndex)

            If TipoBusqueda = "EMPLEADO" Then
                CodigoSeleccionado = fila.Cells("Id_emp").Value.ToString()
                Me.Tag = CodigoSeleccionado

            ElseIf TipoBusqueda = "CATEGORIA" Then
                CodigoSeleccionado = fila.Cells("Id_cat").Value.ToString()
                DescripcionSeleccionada = fila.Cells("Nombre_cat").Value.ToString()

            ElseIf TipoBusqueda = "PROVEEDOR" Then
                CodigoSeleccionado = fila.Cells("Id_prov").Value.ToString()
                DescripcionSeleccionada = fila.Cells("Nombre_prov").Value.ToString()
                DireccionSeleccionada = If(fila.Cells("Direccion_prov").Value Is DBNull.Value, "", fila.Cells("Direccion_prov").Value.ToString())
                TelefonoSeleccionado = If(fila.Cells("Telefono_prov").Value Is DBNull.Value, "", fila.Cells("Telefono_prov").Value.ToString())

            Else ' PRODUCTO
                CodigoSeleccionado = fila.Cells("Id_prod").Value.ToString()
                DescripcionSeleccionada = fila.Cells("Descripcion_prod").Value.ToString()
                PrecioSeleccionado = Convert.ToDecimal(fila.Cells("PVenta_prod").Value)
            End If

            DialogResult = DialogResult.OK
            Close()
        End If
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
    End Sub

End Class