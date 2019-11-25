Imports DevComponents.DotNetBar
Imports Logica.AccesoLogica
Public Class PR_ReservaHotel
#Region "Metodos Privados"
    Public numiReserva As String
    Private Sub _prIniciarTodo()
        _PMIniciarTodo()
        Me.Text = "R E P O R T E     R E S E R V A    D E    H O T E L"
        MReportViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        MGPFiltros.Visible = False
    End Sub

    Public Sub _prCargarReporte()
        Dim _dt As New DataTable


        _dt = L_prHotelReservaGetReservaReporte(numiReserva)

        If (_dt.Rows.Count > 0) Then
            Dim objrep As New R_ReservaHotel
            objrep.SetDataSource(_dt)
            MReportViewer.ReportSource = objrep

            'objrep.SetParameterValue("ParamFecha", tbFecha.Value.Date.ToString("yyyy-MM-dd"))

            MReportViewer.Show()
            MReportViewer.BringToFront()
        Else
            ToastNotification.Show(Me, "NO HAY DATOS PARA LOS PARAMETROS SELECCIONADOS..!!!",
                                       My.Resources.INFORMATION, 2000,
                                       eToastGlowColor.Blue,
                                       eToastPosition.BottomLeft)
            MReportViewer.ReportSource = Nothing
        End If
    End Sub

#End Region

    Private Sub PR_ReservaHotel_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _prIniciarTodo()
        _prCargarReporte()
    End Sub

    Private Sub btnGenerar_Click(sender As Object, e As EventArgs) Handles btnGenerar.Click
        _prCargarReporte()
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Close()
    End Sub
End Class