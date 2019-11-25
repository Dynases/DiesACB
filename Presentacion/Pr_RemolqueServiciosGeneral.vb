Imports Logica.AccesoLogica
Imports DevComponents.DotNetBar

Public Class Pr_RemolqueServiciosGeneral

#Region "Metodos privados"
    Private Sub _prIniciarTodo()
        _PMIniciarTodo()

        _prCargarComboChofer(cbFiltro)
        'L_prAbrirConexion(gs_Ip, gs_UsuarioSql, gs_ClaveSql, gs_NombreBD)
        Me.Text = "R E P O R T E    S E R V I C I O S    D I A R I O   R E M O L Q U E"

        MReportViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None

    End Sub
    Private Sub _prCargarReporte()
        Dim _dt As New DataTable
        Dim _dt2 As New DataTable

        If swFiltrar.Value = True Then
            If cbFiltro.SelectedIndex = -1 Then
                ToastNotification.Show(Me, "seleccione un chofer...!!".ToUpper(),
                                          My.Resources.INFORMATION, 2000,
                                          eToastGlowColor.Blue,
                                          eToastPosition.BottomLeft)
                MReportViewer.ReportSource = Nothing
                Exit Sub
            End If
            _dt = L_prReporteServiciosGeneralRemolque(tbFechaI.Value.ToString("yyyy/MM/dd"), tbFechaF.Value.ToString("yyyy/MM/dd"), cbFiltro.Value)
            _dt2 = L_prReporteServiciosDetalleGeneralRemolque(tbFechaI.Value.ToString("yyyy/MM/dd"), tbFechaF.Value.ToString("yyyy/MM/dd"), cbFiltro.Value)
            If (_dt.Rows.Count > 0) Then
                Dim objrep As New R_ConciliacionRemolque
                '' GenerarNro(_dt)
                objrep.SetDataSource(_dt)
                objrep.Subreports.Item("R_ConciliacionResumenRemolque.rpt").SetDataSource(_dt2)
                objrep.SetParameterValue("FechaI", tbFechaI.Value.ToString("dd/MM/yyyy"))
                objrep.SetParameterValue("FechaF", tbFechaF.Value.ToString("dd/MM/yyyy"))
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
        Else
            _dt = L_prReporteServiciosGeneralRemolque(tbFechaI.Value.ToString("yyyy/MM/dd"), tbFechaF.Value.ToString("yyyy/MM/dd"))
            _dt2 = L_prReporteServiciosDetalleGeneralRemolque(tbFechaI.Value.ToString("yyyy/MM/dd"), tbFechaF.Value.ToString("yyyy/MM/dd"))
            If (_dt.Rows.Count > 0) Then
                Dim objrep As New R_ConciliacionRemolque
                '' GenerarNro(_dt)
                objrep.SetDataSource(_dt)
                objrep.Subreports.Item("R_ConciliacionResumenRemolque.rpt").SetDataSource(_dt2)
                objrep.SetParameterValue("FechaI", tbFechaI.Value.ToString("dd/MM/yyyy"))
                objrep.SetParameterValue("FechaF", tbFechaF.Value.ToString("dd/MM/yyyy"))
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
        End If


    End Sub

    Private Sub _prCargarComboChofer(mCombo As Janus.Windows.GridEX.EditControls.MultiColumnCombo)
        Dim dt As DataTable
        dt = L_prRemolqueObtenerPersonal()
        With mCombo
            .DropDownList.Columns.Clear()
            .DropDownList.Columns.Add("panumi").Width = 60
            .DropDownList.Columns("panumi").Caption = "COD"
            .DropDownList.Columns.Add("nombre").Width = 500
            .DropDownList.Columns("nombre").Caption = "CATEGORIA"
            .ValueMember = "panumi"
            .DisplayMember = "nombre"
            .DataSource = dt
            .Refresh()
        End With
        If (CType(mCombo.DataSource, DataTable).Rows.Count > 0) Then
            mCombo.SelectedIndex = 0
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

    Private Sub MultiColumnCombo1_ValueChanged(sender As Object, e As EventArgs) Handles cbFiltro.ValueChanged


    End Sub

    Private Sub swFiltrar_ValueChanged(sender As Object, e As EventArgs) Handles swFiltrar.ValueChanged
        cbFiltro.Enabled = swFiltrar.Value
    End Sub
#End Region


End Class