Imports Logica.AccesoLogica
Imports DevComponents.DotNetBar

Public Class Pr_LavaderoGeneralServicios

#Region "Metodos privados"
    Private Sub _prIniciarTodo()
        _PMIniciarTodo()
        'L_prAbrirConexion(gs_Ip, gs_UsuarioSql, gs_ClaveSql, gs_NombreBD)
        Me.Text = "R E P O R T E  S E R V I C I O S  D I A R I O  L A V A D E R O"

        MReportViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None

    End Sub
    Private Sub _prCargarReporte()
        Dim _dt As New DataTable
        Dim dt1 As DataTable = L_prReporteServiciosGeneralTipoVenta(tbFechaI.Value.ToString("yyyy/MM/dd"), tbFechaF.Value.ToString("yyyy/MM/dd"))


        _dt = L_prReporteServiciosGeneral(tbFechaI.Value.ToString("yyyy/MM/dd"), tbFechaF.Value.ToString("yyyy/MM/dd"))
        If (_dt.Rows.Count > 0) Then
            Dim Fecha As String = tbFechaI.Value.ToString("dd/mm/yyyy") + " AL " + tbFechaF.Value.ToString("dd/MM/yyyy")
            Dim objrep As New R_SerLavaderoGeneral
            objrep.DataSourceConnections.Item(0).SetLogon(P_Global.gs_UsuarioSql, P_Global.gs_ClaveSql)
            objrep.Subreports.Item("R_TipoVenta.rpt").SetDataSource(dt1)
            objrep.SetDataSource(_dt)
            objrep.SetParameterValue("RangoFecha", Fecha)
            MReportViewer.ReportSource = objrep
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
  
#Region "Evento del Formulario"
    Private Sub Pr_LavaderoGeneralServicios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _prIniciarTodo()
    End Sub
    Private Sub btnGenerar_Click(sender As Object, e As EventArgs) Handles btnGenerar.Click

        _prCargarReporte()

    End Sub
    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub
#End Region

    
End Class