Public Class UC_ReporteDia
    ' Variables para almacenar el rango de fechas recibido
    Public FechaInicio As DateTime
    Public FechaFin As DateTime

    ' Constructor predeterminado (requerido por el Diseñador de Visual Studio)
    Public Sub New()
        InitializeComponent()
    End Sub

    ' Constructor personalizado para recibir las fechas directamente
    Public Sub New(fInicio As DateTime, fFin As DateTime)
        InitializeComponent()
        FechaInicio = fInicio
        FechaFin = fFin
    End Sub

    Private Sub UC_ReporteDia_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Si se pasaron fechas válidas, muestra el rango; de lo contrario, muestra la fecha actual
        If FechaInicio <> Nothing AndAlso FechaFin <> Nothing Then
            Label2.Text = $"{FechaInicio.ToString("dd/MM/yyyy")} al {FechaFin.ToString("dd/MM/yyyy")}"
        Else
            Label2.Text = DateTime.Now.ToString("dd/MM/yyyy")
        End If

        ' Aquí puedes llamar a tu método para cargar las ventas desde la base de datos
        ' CargarVentas(FechaInicio, FechaFin)
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
    End Sub
End Class
