Imports System.Data.OleDb

Public Class UC_Corte

    Private Function ObtenerIdEmpleadoActivo() As Integer
        Return If(InicioSesion.IdUsuarioActual > 0, InicioSesion.IdUsuarioActual, 1)
    End Function

    Private Sub UC_Corte_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarOEstructurarCajaActiva()
    End Sub

    ' Mantiene siempre una caja abierta activa y calcula entradas/salidas basadas estrictamente en las fechas del turno
    Private Sub CargarOEstructurarCajaActiva()
        Try
            Using con As OleDbConnection = ObtenerConexion()

                ' 1. Buscar si hay una caja abierta actualmente
                Dim query As String = "SELECT TOP 1 Id_cor, MontoInicial_cor, FechaApertura_cor FROM Corte WHERE FechaCierre_cor IS NULL ORDER BY Id_cor DESC"
                Dim idCorteActivo As Object = Nothing
                Dim montoInicial As Decimal = 0
                Dim fechaApertura As DateTime = DateTime.Now

                Using cmd As New OleDbCommand(query, con)
                    Using reader As OleDbDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            idCorteActivo = reader("Id_cor")
                            If reader("MontoInicial_cor") IsNot DBNull.Value Then
                                montoInicial = Convert.ToDecimal(reader("MontoInicial_cor"))
                            End If
                            If reader("FechaApertura_cor") IsNot DBNull.Value Then
                                fechaApertura = Convert.ToDateTime(reader("FechaApertura_cor"))
                            End If
                        End If
                    End Using
                End Using

                ' 2. Si NO existe caja abierta, crear una automática
                If idCorteActivo Is Nothing OrElse idCorteActivo Is DBNull.Value Then
                    Dim idEmpleado As Integer = ObtenerIdEmpleadoActivo()
                    fechaApertura = DateTime.Now
                    montoInicial = 200D ' Fondo inicial predeterminado por seguridad (puedes ajustarlo)

                    Dim queryAperturaAuto As String = "INSERT INTO Corte (ID_emp, FechaApertura_cor, MontoInicial_cor) VALUES (?, ?, ?)"
                    Using cmdApertura As New OleDbCommand(queryAperturaAuto, con)
                        cmdApertura.Parameters.Add("?", OleDbType.Integer).Value = idEmpleado
                        cmdApertura.Parameters.Add("?", OleDbType.Date).Value = fechaApertura
                        cmdApertura.Parameters.Add("?", OleDbType.Currency).Value = montoInicial
                        cmdApertura.ExecuteNonQuery()
                    End Using

                    Using cmd As New OleDbCommand(query, con)
                        Using reader As OleDbDataReader = cmd.ExecuteReader()
                            If reader.Read() Then
                                idCorteActivo = reader("Id_cor")
                            End If
                        End Using
                    End Using
                End If

                ' 3. Cargar datos e importes filtrados exclusivamente a este turno
                If idCorteActivo IsNot Nothing AndAlso idCorteActivo IsNot DBNull.Value Then
                    Dim idCorInt As Integer = Convert.ToInt32(idCorteActivo)
                    Label_CorteNo.Text = idCorInt.ToString()
                    MTB_MontoInicial.Text = montoInicial.ToString("N2")
                    MTB_MontoInicial.ReadOnly = True

                    ' Calcular métricas financieras acotadas a la fecha de este turno
                    Dim resumen = CalcularResumenTurno(idCorInt, fechaApertura, con)

                    MTB_TotalVentas.Text = resumen("NetoEnCaja").ToString("N2")
                    MTB_TotalVentas.ReadOnly = True
                    LabelTotalVentas.Text = "Efectivo en Caja:"

                    MTB_MontoFinal.Clear()
                    MTB_MontoFinal.Focus()
                End If

            End Using
        Catch ex As Exception
            MessageBox.Show("Error al gestionar el estado de la caja: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Calcula ventas y compras FILTRADAS únicamente desde la fecha de apertura de este corte
    Private Function CalcularResumenTurno(idCorte As Integer, fechaApertura As DateTime, con As OleDbConnection) As Dictionary(Of String, Decimal)
        Dim resultado As New Dictionary(Of String, Decimal)
        Dim ventasEfectivo As Decimal = 0D
        Dim ventasTarjeta As Decimal = 0D
        Dim totalCompras As Decimal = 0D

        ' 1. Sumar ventas del turno actual (asociadas al Id_cor o filtradas desde la fecha de apertura)
        Dim queryVentas As String = "SELECT MetodoPago_v, SUM(total_v) FROM Venta WHERE Id_cor = ? GROUP BY MetodoPago_v"
        Using cmd As New OleDbCommand(queryVentas, con)
            cmd.Parameters.Add("?", OleDbType.Integer).Value = idCorte
            Using reader As OleDbDataReader = cmd.ExecuteReader()
                While reader.Read()
                    Dim metodo = reader(0)?.ToString().Trim().ToLower()
                    Dim subtotal = Convert.ToDecimal(reader(1))
                    If metodo IsNot Nothing AndAlso (metodo.Contains("efectivo") OrElse metodo.Contains("cash")) Then
                        ventasEfectivo += subtotal
                    Else
                        ventasTarjeta += subtotal
                    End If
                End While
            End Using
        End Using

        ' 2. Sumar compras realizadas SOLAMENTE durante el periodo de este turno (desde la fecha de apertura)
        Dim queryCompras As String = "SELECT SUM(total_com) FROM Compras WHERE Fecha_com >= ?"
        Using cmdComp As New OleDbCommand(queryCompras, con)
            cmdComp.Parameters.Add("?", OleDbType.Date).Value = fechaApertura
            Dim resComp = cmdComp.ExecuteScalar()
            If resComp IsNot Nothing AndAlso resComp IsNot DBNull.Value Then
                totalCompras = Convert.ToDecimal(resComp)
            End If
        End Using

        ' Obtener el Monto Inicial de esta caja
        Dim montoInicial As Decimal = 0D
        Dim queryInit As String = "SELECT MontoInicial_cor FROM Corte WHERE Id_cor = ?"
        Using cmdInit As New OleDbCommand(queryInit, con)
            cmdInit.Parameters.Add("?", OleDbType.Integer).Value = idCorte
            Dim resInit = cmdInit.ExecuteScalar()
            If resInit IsNot Nothing AndAlso resInit IsNot DBNull.Value Then
                montoInicial = Convert.ToDecimal(resInit)
            End If
        End Using

        ' Neto físico esperado en el cajón = Inicial + Ventas Efectivo - Compras del turno
        Dim netoEnCaja As Decimal = montoInicial + ventasEfectivo - totalCompras

        resultado.Add("VentasEfectivo", ventasEfectivo)
        resultado.Add("VentasTarjeta", ventasTarjeta)
        resultado.Add("TotalCompras", totalCompras)
        resultado.Add("NetoEnCaja", netoEnCaja)

        Return resultado
    End Function

    Private Sub Button_Cerrar_Click(sender As Object, e As EventArgs) Handles Button_Cerrar.Click
        Dim montoFinalVal As Decimal = 0
        If Not Decimal.TryParse(MTB_MontoFinal.Text, montoFinalVal) Then
            MessageBox.Show("Ingrese un monto válido de conteo físico para el cierre.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MTB_MontoFinal.Focus()
            Exit Sub
        End If

        Dim respuesta As DialogResult = MessageBox.Show("¿Desea cerrar la caja actual e iniciar un nuevo turno de inmediato?", "Confirmar Cierre de Caja", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If respuesta = DialogResult.No Then Exit Sub

        Try
            Using con As OleDbConnection = ObtenerConexion()

                Dim queryId As String = "SELECT TOP 1 Id_cor, FechaApertura_cor FROM Corte WHERE FechaCierre_cor IS NULL ORDER BY Id_cor DESC"
                Dim idCorteActivo As Integer = 0
                Dim fechaApertura As DateTime = DateTime.Now

                Using cmdId As New OleDbCommand(queryId, con)
                    Using reader As OleDbDataReader = cmdId.ExecuteReader()
                        If reader.Read() Then
                            idCorteActivo = Convert.ToInt32(reader("Id_cor"))
                            If reader("FechaApertura_cor") IsNot DBNull.Value Then
                                fechaApertura = Convert.ToDateTime(reader("FechaApertura_cor"))
                            End If
                        End If
                    End Using
                End Using

                If idCorteActivo = 0 Then
                    MessageBox.Show("No se encontró ninguna caja activa para cerrar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If

                Dim resumen = CalcularResumenTurno(idCorteActivo, fechaApertura, con)
                Dim efectivoEsperado As Decimal = resumen("NetoEnCaja")

                ' a) Cerrar caja actual
                Dim queryCierre As String = "UPDATE Corte SET FechaCierre_cor = ?, Total_cor = ?, MontoFinal_cor = ? WHERE Id_cor = ?"
                Using cmdCierre As New OleDbCommand(queryCierre, con)
                    cmdCierre.Parameters.Add("?", OleDbType.Date).Value = DateTime.Now
                    cmdCierre.Parameters.Add("?", OleDbType.Currency).Value = efectivoEsperado
                    cmdCierre.Parameters.Add("?", OleDbType.Currency).Value = montoFinalVal
                    cmdCierre.Parameters.Add("?", OleDbType.Integer).Value = idCorteActivo
                    cmdCierre.ExecuteNonQuery()
                End Using

                ' b) Abrir siguiente turno (Fondo inicial sugerido fijo de 200 o el conteo físico anterior, según prefieras)
                Dim idEmpleado As Integer = ObtenerIdEmpleadoActivo()
                Dim queryNuevaApertura As String = "INSERT INTO Corte (ID_emp, FechaApertura_cor, MontoInicial_cor) VALUES (?, ?, ?)"
                Using cmdNueva As New OleDbCommand(queryNuevaApertura, con)
                    cmdNueva.Parameters.Add("?", OleDbType.Integer).Value = idEmpleado
                    cmdNueva.Parameters.Add("?", OleDbType.Date).Value = DateTime.Now
                    cmdNueva.Parameters.Add("?", OleDbType.Currency).Value = 200D ' Fondo inicial base estándar para la caja
                    cmdNueva.ExecuteNonQuery()
                End Using

                Dim diferencia As Decimal = montoFinalVal - efectivoEsperado
                Dim mensajeResultado As String = $"¡Corte cerrado correctamente!" & vbCrLf &
                                                 $"Ventas en efectivo: {resumen("VentasEfectivo"):C2}" & vbCrLf &
                                                 $"Ventas con tarjeta: {resumen("VentasTarjeta"):C2}" & vbCrLf &
                                                 $"Compras del turno: {resumen("TotalCompras"):C2}" & vbCrLf &
                                                 $"Efectivo esperado: {efectivoEsperado:C2}" & vbCrLf &
                                                 $"Conteo físico: {montoFinalVal:C2}" & vbCrLf &
                                                 If(diferencia = 0, "¡Caja cuadrada exacto sin diferencias!", If(diferencia > 0, $"Sobrante en caja: {diferencia:C2}", $"Faltante en caja: {Math.Abs(diferencia):C2}"))

                MessageBox.Show(mensajeResultado, "Reporte de Cierre de Caja", MessageBoxButtons.OK, MessageBoxIcon.Information)

            End Using

            CargarOEstructurarCajaActiva()

        Catch ex As Exception
            MessageBox.Show("Error durante la operación de corte: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class