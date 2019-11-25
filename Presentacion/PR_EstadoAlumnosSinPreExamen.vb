Imports Logica.AccesoLogica
Imports DevComponents.DotNetBar

Public Class PR_EstadoAlumnosSinPreExamen
#Region "Metodos Privados"
    Private Sub _prIniciarTodo()
        _PMIniciarTodo()
        Me.Text = "R E P O R T E     P R E - E X A M E N"
        tbFiltrarInst.Value = False
        tbInst.Enabled = False
        tbSucursal.Enabled = False
        MReportViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
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

        _dt = L_prPreExamenAlumnosSinPreExamen(numiInst, numiSuc)

        If (_dt.Rows.Count > 0) Then
            Dim objrep As New R_dg_EstadoAlumAutoEscuela


            objrep.SetDataSource(_dt)
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

    Private Sub PR_EstadoAlumnosSinPreExamen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
            Dim dt As DataTable
            If tbFiltrarSuc.Value = True Then
                If tbNumiSuc.Text = String.Empty Then
                    ToastNotification.Show(Me, "Seleccione sucursal!", My.Resources.INFORMATION, 2000, eToastGlowColor.Blue, eToastPosition.BottomLeft)
                    Exit Sub
                Else
                    dt = L_prPersonaAyudaGeneralPorSucursal(tbNumiSuc.Text, gi_LibPERSTIPOInstructor)
                End If
            Else
                dt = L_prPersonaAyudaGeneral(gi_LibPERSTIPOInstructor)
            End If

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