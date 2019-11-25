Public Class PR_ListasCertiTeoPrac
    Private Sub _prIniciarTodo()
        _PMIniciarTodo()
        Me.Text = "reporte de postulantes a examen teorico y practico".ToUpper

        CrystalReportViewerPrac.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        CrystalReportViewerTeo.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
    End Sub
    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub
End Class