Imports System.Data.OleDb

Public Class UC_Corte

    ' ID del empleado logueado (puedes reemplazarlo por InicioSesion.ID_emp o la variable de sesión real)
    Private Function ObtenerIdEmpleadoActivo() As Integer
        Return 1
    End Function

    Private Sub UC_Corte_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarOEstructurarCajaActiva()
    End Sub

    ' Mantiene siempre una caja abierta activa
    Private Sub CargarOEstructurarCajaActiva()
        Try
            Using con As OleDbConnection = ObtenerConexion()

                ' 1. Buscar si hay una caja abierta actualmente
                Dim query As String = "SELECT TOP 1 Id_cor, MontoInicial_cor FROM Corte WHERE FechaCierre_cor IS NULL ORDER BY Id_cor DESC"
                Dim idCorteActivo As Object = Nothing
                Dim montoInicial As Decimal = 0

                Using cmd As New OleDbCommand(query, con)
                    Using reader As OleDbDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            idCorteActivo = reader("Id_cor")
                            If reader("MontoInicial_cor") IsNot DBNull.Value Then
                                montoInicial = Convert.ToDecimal(reader("MontoInicial_cor"))
                            End If
                        End If
                    End Using
                End Using

                ' 2. Si NO existe caja abierta, crear una de forma automática inmediatamente
                If idCorteActivo Is Nothing OrElse idCorteActivo Is DBNull.Value Then
                    Dim idEmpleado As Integer = ObtenerIdEmpleadoActivo()
                    Dim queryAperturaAuto As String = "INSERT INTO Corte (ID_emp, FechaApertura_cor, MontoInicial_cor) VALUES (?, ?, ?)"
                    Using cmdApertura As New OleDbCommand(queryAperturaAuto, con)
                        cmdApertura.Parameters.Add("?", OleDbType.Integer).Value = idEmpleado
                        cmdApertura.Parameters.Add("?", OleDbType.Date).Value = DateTime.Now
                        cmdApertura.Parameters.Add("?", OleDbType.Currency).Value = 0.00D
                        cmdApertura.ExecuteNonQuery()
                    End Using

                    ' Reobtener el ID recién creado
                    Using cmd As New OleDbCommand(query, con)
                        idCorteActivo = cmd.ExecuteScalar()
                    End Using
                End If

                ' 3. Cargar datos en la pantalla
                If idCorteActivo IsNot Nothing AndAlso idCorteActivo IsNot DBNull.Value Then
                    Dim idCorInt As Integer = Convert.ToInt32(idCorteActivo)
                    Label_CorteNo.Text = idCorInt.ToString()
                    MTB_MontoInicial.Text = montoInicial.ToString("N2")
                    MTB_MontoInicial.ReadOnly = True

                    ' Sumar ventas del turno actual
                    Dim totalVentas As Decimal = CalcularVentasDelTurno(idCorInt, con)
                    MTB_TotalVentas.Text = totalVentas.ToString("N2")
                    MTB_TotalVentas.ReadOnly = True

                    MTB_MontoFinal.Clear()
                    MTB_MontoFinal.Focus()
                End If

            End Using
        Catch ex As Exception
            MessageBox.Show("Error al gestionar el estado de la caja: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Obtener la suma total acumulada de ventas para la caja activa
    Private Function CalcularVentasDelTurno(idCorte As Integer, con As OleDbConnection) As Decimal
        Dim queryVentas As String = "SELECT SUM(total_v) FROM Venta WHERE Id_cor = ?"
        Using cmd As New OleDbCommand(queryVentas, con)
            ' Especificar OleDbType.Integer explícitamente evita el conflicto de tipos en Access
            cmd.Parameters.Add("?", OleDbType.Integer).Value = idCorte
            Dim result = cmd.ExecuteScalar()
            If result IsNot Nothing AndAlso result IsNot DBNull.Value Then
                Return Convert.ToDecimal(result)
            End If
        End Using
        Return 0.00D
    End Function

    ' ÚNICO BOTÓN: Cerrar caja e iniciar inmediatamente la siguiente
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

                ' a) Obtener ID de la caja activa
                Dim queryId As String = "SELECT TOP 1 Id_cor FROM Corte WHERE FechaCierre_cor IS NULL ORDER BY Id_cor DESC"
                Dim idCorteActivo As Integer = 0
                Using cmdId As New OleDbCommand(queryId, con)
                    Dim res = cmdId.ExecuteScalar()
                    If res IsNot Nothing AndAlso res IsNot DBNull.Value Then
                        idCorteActivo = Convert.ToInt32(res)
                    End If
                End Using

                If idCorteActivo = 0 Then
                    MessageBox.Show("No se encontró ninguna caja activa para cerrar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If

                Dim totalVentasTurno As Decimal = CalcularVentasDelTurno(idCorteActivo, con)

                ' b) Realizar Cierre de la caja actual
                Dim queryCierre As String = "UPDATE Corte SET FechaCierre_cor = ?, Total_cor = ?, MontoFinal_cor = ? WHERE Id_cor = ?"
                Using cmdCierre As New OleDbCommand(queryCierre, con)
                    cmdCierre.Parameters.Add("?", OleDbType.Date).Value = DateTime.Now
                    cmdCierre.Parameters.Add("?", OleDbType.Currency).Value = totalVentasTurno
                    cmdCierre.Parameters.Add("?", OleDbType.Currency).Value = montoFinalVal
                    cmdCierre.Parameters.Add("?", OleDbType.Integer).Value = idCorteActivo
                    cmdCierre.ExecuteNonQuery()
                End Using

                ' c) APERTURA AUTOMÁTICA DEL SIGUIENTE TURNO / CAJA
                Dim idEmpleado As Integer = ObtenerIdEmpleadoActivo()
                Dim queryNuevaApertura As String = "INSERT INTO Corte (ID_emp, FechaApertura_cor, MontoInicial_cor) VALUES (?, ?, ?)"
                Using cmdNueva As New OleDbCommand(queryNuevaApertura, con)
                    cmdNueva.Parameters.Add("?", OleDbType.Integer).Value = idEmpleado
                    cmdNueva.Parameters.Add("?", OleDbType.Date).Value = DateTime.Now
                    cmdNueva.Parameters.Add("?", OleDbType.Currency).Value = montoFinalVal
                    cmdNueva.ExecuteNonQuery()
                End Using

            End Using

            MessageBox.Show("¡Corte cerrado correctamente y nueva caja iniciada al instante!", "Corte Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' Recargar interfaz con la nueva caja
            CargarOEstructurarCajaActiva()

        Catch ex As Exception
            MessageBox.Show("Error durante la operación de corte: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class