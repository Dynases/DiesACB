Imports Logica.AccesoLogica
Imports DevComponents.DotNetBar

Public Class PR_EstadosAlumnos
#Region "Metodos Privados"

    Private Sub _prIniciarTodo()
        _PMIniciarTodo()
        Me.Text = "R E P O R T E     E S T A D O     D E    A L U M N O S"
        MReportViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        tbFiltrarInst.Value = False
        tbInst.Enabled = False
        _prCargarComboEstados()
    End Sub
    
    Private Sub _prCargarReporte()
        Dim _dt As New DataTable
        Dim numiSuc, numiInst As String

        If tbFiltrarInst.Value = True Then
            If tbNumiInst.Text = String.Empty Then
                ToastNotification.Show(Me, "Seleccione Instructor!".ToUpper, My.Resources.INFORMATION, 2000, eToastGlowColor.Blue, eToastPosition.BottomLeft)
                Exit Sub
            Else
                numiInst = tbNumiInst.Text
            End If
        Else
            numiInst = "-1"
        End If

        If tbFiltrarSuc.Value = True Then
            If tbNumiSuc.Text = String.Empty Then
                ToastNotification.Show(Me, "Seleccione Sucursal!".ToUpper, My.Resources.INFORMATION, 2000, eToastGlowColor.Blue, eToastPosition.BottomLeft)
                Exit Sub
            Else
                numiSuc = tbNumiSuc.Text
            End If
        Else
            numiSuc = "-1"
        End If

        _dt = L_prPreExamenResporteEstadoExamenes(tbFecha.Value.ToString("yyyy/MM/dd"), tbEstado.Value, numiInst, numiSuc)

        If (_dt.Rows.Count > 0) Then
            Dim objrep As New R_Examenes


            objrep.SetDataSource(_dt)
            MReportViewer.ReportSource = objrep

            objrep.SetParameterValue("ParamFecha", tbFecha.Value.Date.ToString("yyyy-MM-dd"))

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

    Private Sub _prCargarComboEstados()

        Dim dtEstados As New DataTable
        dtEstados.Columns.Add("numi")
        dtEstados.Columns.Add("estado")

        dtEstados.Rows.Clear()

        dtEstados.Rows.Add(-1, "TODOS")

        dtEstados.Rows.Add(0, "PROGRAMADO")
        dtEstados.Rows.Add(1, "APROBADO")
        dtEstados.Rows.Add(2, "REPROBADO")
        dtEstados.Rows.Add(3, "FALTA")
        dtEstados.Rows.Add(4, "PERMISO")

        With tbEstado
            .DropDownList.Columns.Clear()

            '.DropDownList.Columns.Add("numi").Width = 40
            '.DropDownList.Columns("numi").Caption = "COD"
            .DropDownList.Columns.Add("estado").Width = 150
            .DropDownList.Columns("estado").Caption = "ESTADO"

            .ValueMember = "numi"
            .DisplayMember = "estado"
            .DataSource = dtEstados
            .Refresh()
            tbEstado.SelectedIndex = 0
        End With


    End Sub
#End Region

    Private Sub PR_PreExamen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _prIniciarTodo()
    End Sub

    Private Sub btnGenerar_Click(sender As Object, e As EventArgs) Handles btnGenerar.Click
        _prCargarReporte()
    End Sub

    Private Sub tbFiltrarInst_ValueChanged(sender As Object, e As EventArgs) Handles tbFiltrarInst.ValueChanged
        tbInst.Enabled = tbFiltrarInst.Value
    End Sub

    Private Sub tbInst_KeyDown(sender As Object, e As KeyEventArgs) Handles tbInst.KeyDown
        If e.KeyData = Keys.Control + Keys.Enter Then

            'grabar horario
            Dim frmAyuda As Modelos.ModeloAyuda
            Dim dt As DataTable = L_prPersonaAyudaGeneralPorSucursal(gi_userSuc, gi_LibPERSTIPOInstructor)
            Dim listEstCeldas As New List(Of Modelos.Celda)
            listEstCeldas.Add(New Modelos.Celda("panumi", True, "Codigo".ToUpper, 70))
            listEstCeldas.Add(New Modelos.Celda("panom", True, "nombre".ToUpper, 200))
            listEstCeldas.Add(New Modelos.Celda("paape", True, "apellido".ToUpper, 200))
            listEstCeldas.Add(New Modelos.Celda("panom1", True, "Nombre completo".ToUpper, 300))

            frmAyuda = New Modelos.ModeloAyuda(200, 200, dt, "seleccione el instructor".ToUpper, listEstCeldas)
            frmAyuda.ShowDialog()

            If frmAyuda.seleccionado = True Then
                Dim numiInst As String = frmAyuda.filaSelect.Cells("panumi").Value
                Dim nombreInst As String = frmAyuda.filaSelect.Cells("panom1").Value

                tbNumiInst.Text = numiInst
                tbInst.Text = nombreInst
            End If
        End If
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub tbSucursal_KeyDown(sender As Object, e As KeyEventArgs) Handles tbSucursal.KeyDown
        If e.KeyData = Keys.Control + Keys.Enter Then

            'grabar horario
            Dim frmAyuda As Modelos.ModeloAyuda
            Dim dt As DataTable

            dt = L_prSucursalAyuda()

            Dim listEstCeldas As New List(Of Modelos.Celda)
            listEstCeldas.Add(New Modelos.Celda("canumi", True, "Codigo".ToUpper, 70))
            listEstCeldas.Add(New Modelos.Celda("cadesc", True, "descripcion".ToUpper, 200))

            frmAyuda = New Modelos.ModeloAyuda(200, 200, dt, "seleccione sucursal".ToUpper, listEstCeldas)
            frmAyuda.ShowDialog()

            If frmAyuda.seleccionado = True Then
                Dim numiSuc As String = frmAyuda.filaSelect.Cells("canumi").Value
                Dim nombreSuc As String = frmAyuda.filaSelect.Cells("cadesc").Value

                tbSucursal.Text = nombreSuc
                tbNumiSuc.Text = numiSuc

                tbNumiInst.Text = ""
                tbInst.Text = ""

            End If
        End If
    End Sub

    Private Sub tbFiltrarSuc_ValueChanged(sender As Object, e As EventArgs) Handles tbFiltrarSuc.ValueChanged
        tbSucursal.Enabled = tbFiltrarSuc.Value
        tbInst.Text = ""
        tbNumiInst.Text = ""

    End Sub
End Class