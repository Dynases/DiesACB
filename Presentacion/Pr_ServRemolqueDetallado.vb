Imports Logica.AccesoLogica
Imports DevComponents.DotNetBar

Public Class Pr_ServRemolqueDetallado

#Region "Metodos Privados"
    Private Sub _prIniciarTodo()
        _PMIniciarTodo()
        'L_prAbrirConexion(gs_Ip, gs_UsuarioSql, gs_ClaveSql, gs_NombreBD)
        Me.Text = "R E P O R T E  S E R V I C I O S  D I A R I O  L A V A D E R O"

        MReportViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None

    End Sub
    Private Sub _prCargarReporte()
        Dim _dt As New DataTable



        _dt = L_prReporteDetalladoServRemolque(tbFechaI.Value.ToString("yyyy/MM/dd"), tbFechaF.Value.ToString("yyyy/MM/dd"))
        If (_dt.Rows.Count > 0) Then
            Dim objrep As New R_ServDetalleRemolque

            '' GenerarNro(_dt)

            objrep.SetDataSource(_dt)
            Dim fecha As String = tbFechaI.Value.ToString("dd/MM/yyyy") + " AL " + tbFechaI.Value.ToString("dd/MM/yyyy")
            objrep.SetParameterValue("RangoFecha", fecha)
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
    Private Sub Pr_ListAlumnAprovb_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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