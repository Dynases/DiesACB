Imports Logica.AccesoLogica
Imports DevComponents.DotNetBar

Public Class PR_CertiAlumnosFiltrado

#Region "Metodos Privados"
    Private Sub _prIniciarTodo()
        _PMIniciarTodo()
        Me.Text = "R e p o r t e   d e   a l u m n o s   f i l t r a d o s ".ToUpper



        MReportViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
    End Sub


    Private Sub _prCargarReporte()
        Dim _dt As New DataTable
        _dt = L_prAlumnoCertiGetFiltrados(IIf(tbEstado.Value = True, 2, 3), IIf(tbOrigen.Value = True, 1, 0))
        Dim filasFiltradas As DataRow()
        filasFiltradas = _dt.Select("emfecha>='" + tbFechaDel.Value.ToString("yyyy/MM/dd") + "' and emfecha<='" + tbFechaAl.Value.ToString("yyyy/MM/dd") + "'", "emalum asc")
        If filasFiltradas.Count > 0 Then
            _dt = filasFiltradas.CopyToDataTable
        Else
            _dt = New DataTable
        End If

        If (_dt.Rows.Count > 0) Then
            Dim objrep As New R_CertiAlumnosEscuelaAprobadosFiltrado


            objrep.SetDataSource(_dt)
            objrep.SetParameterValue("fechaDel", tbFechaDel.Value.ToString("dd/MM/yyyy"))
            objrep.SetParameterValue("fechaAl", tbFechaAl.Value.ToString("dd/MM/yyyy"))

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

    Private Sub PR_PreExamen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _prIniciarTodo()
    End Sub

    Private Sub btnGenerar_Click(sender As Object, e As EventArgs) Handles btnGenerar.Click
        _prCargarReporte()
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Close()
    End Sub
End Class