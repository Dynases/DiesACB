Imports Logica.AccesoLogica
Public Class PR_Asistencia
#Region "METODOS PRIVADOS"
    Private Sub _prIniciarTodo()
        _PMIniciarTodo()
        Me.Text = "R E P O R T E     D E     A S I S T E N C I A S"
        MReportViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
    End Sub

    Private Sub _prCargarReporte()
        Dim _dt As New DataTable

        Dim objrep As New R_PlanillaAsistencia

        _dt = L_prAsistenciaReportePlanilla(tbFecha1.Value.ToString("yyyy/MM/dd"), tbFecha2.Value.ToString("yyyy/MM/dd"))

        objrep.SetDataSource(_dt)
        MReportViewer.ReportSource = objrep

    End Sub
    Private Sub _prCargarComboPersona()
        Dim _Ds As New DataSet
        _Ds.Tables.Add(L_prPersonaAyudaTodosGeneral())

        tbPersona.DropDownList.Columns.Clear()


        tbPersona.DropDownList.Columns.Add(_Ds.Tables(0).Columns("panumi").ToString).Width = 50
        tbPersona.DropDownList.Columns(0).Caption = "Código"
        tbPersona.DropDownList.Columns.Add(_Ds.Tables(0).Columns("paci").ToString).Width = 70
        tbPersona.DropDownList.Columns(1).Caption = "CI"
        tbPersona.DropDownList.Columns.Add(_Ds.Tables(0).Columns("panom1").ToString).Width = 250
        tbPersona.DropDownList.Columns(2).Caption = "Descripcion"

        tbPersona.ValueMember = _Ds.Tables(0).Columns("panumi").ToString
        tbPersona.DisplayMember = _Ds.Tables(0).Columns("panom1").ToString
        tbPersona.DataSource = _Ds.Tables(0)
        tbPersona.Refresh()
    End Sub
#End Region

    Private Sub Sw_Filtrar_ValueChanged(sender As Object, e As EventArgs) Handles Sw_Filtrar.ValueChanged
        tbPersona.Enabled = Sw_Filtrar.Value
    End Sub

    Private Sub btnGenerar_Click(sender As Object, e As EventArgs) Handles btnGenerar.Click
        _prCargarReporte()
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub PR_Asistencia_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _prIniciarTodo()
    End Sub
End Class