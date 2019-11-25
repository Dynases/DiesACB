Imports Logica.AccesoLogica
Imports DevComponents.DotNetBar

Public Class PR_HotelResumenReservas

#Region "Metodos privados"
    Private Sub _prIniciarTodo()
        _PMIniciarTodo()
        Me.Text = "R E P O R T E    D E    R E S U M E N    D E    R E S E R V A S    D E L    H O T E L"

        MReportViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None

    End Sub

    Private Sub _prCargarReporte()

        Dim dt As DataTable = L_prHotelReservaReporteResumenReservas(tbFechaDel.Value.ToString("yyyy/MM/dd"), tbFechaAl.Value.ToString("yyyy/MM/dd"))

        If (dt.Rows.Count > 0) Then
            Dim objrep As New R_HotelResumenReservas


            objrep.SetDataSource(dt)
            MReportViewer.ReportSource = objrep

            objrep.SetParameterValue("fechaDel", tbFechaDel.Value.Date.ToString("dd-MM-yyyy"))
            objrep.SetParameterValue("fechaAl", tbFechaAl.Value.Date.ToString("dd-MM-yyyy"))

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


    Private Sub PR_CronoClasesPracticas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _prIniciarTodo()
    End Sub

    Private Sub btnGenerar_Click(sender As Object, e As EventArgs) Handles btnGenerar.Click
        _prCargarReporte()
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub


End Class