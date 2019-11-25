Imports Logica.AccesoLogica
Imports DevComponents.DotNetBar

Public Class PR_SocioListaSociosActivos

#Region "Variables Globales"



#End Region

#Region "Eventos"

    Private Sub PR_SocioListaSociosActivos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        P_prInicio()
    End Sub

    Private Sub btnGenerar_Click(sender As Object, e As EventArgs) Handles btnGenerar.Click
        P_prGenerarReporte()
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

#End Region

#Region "Metodos"

    Private Sub P_prInicio()
        'Abrir conexion
        'L_prAbrirConexion()

        'Setear formulario
        Me.Text = "L I S T A   D E   S O C I O S   A C T I V O S"
        Me.WindowState = FormWindowState.Maximized

        Me.MReportViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        SbUnoTodos.Value = False
        CbFiltro.ReadOnly = True

        P_prArmarCombos()
    End Sub

#End Region

    Private Sub P_prGenerarReporte()
        Dim dt As DataTable = New DataTable
        Dim filtro As String = ""
        If (Not SbUnoTodos.Value) Then
            dt = L_fnSocioReporteSocioListaSociosActivos("0")
            filtro = "TODOS"
        Else
            dt = L_fnSocioReporteSocioListaSociosActivos(CbFiltro.Value.ToString)
            filtro = CbFiltro.Text
        End If

        If (dt.Rows.Count > 0) Then
            dt = P_fnConcatenarDetalle(dt)

            Dim objrep As New R_SocioListaSociosActivos

            objrep.SetDataSource(dt)

            MReportViewer.ReportSource = objrep

            objrep.SetParameterValue("TipoSocio", filtro)

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

    Private Function P_fnConcatenarDetalle(dt As DataTable) As DataTable
        For Each f As DataRow In dt.Rows
            Dim numi As String = f.Item("numi").ToString
            Dim telefonos As String = ""
            Dim hijos As String = ""
            Dim vehiculos As String = ""
            Dim dtTelefono As DataTable = L_fnSocioReporteSocioListaSociosActivosDetalle(numi, "1")
            Dim dtHijos As DataTable = L_fnSocioReporteSocioListaSociosActivosDetalle(numi, "2")
            Dim dtVehiculos As DataTable = L_fnSocioReporteSocioListaSociosActivosDetalle(numi, "3")

            Dim i As Integer = 0
            For Each ft As DataRow In dtTelefono.Rows
                i += 1
                telefonos = telefonos + i.ToString + ")" + ft.Item("telf").ToString + "/" + ft.Item("tipo").ToString + " " + ChrW(13)
            Next
            i = 0
            For Each fh As DataRow In dtHijos.Rows
                i += 1
                hijos = hijos + i.ToString + ")" + fh.Item("nom").ToString + " " + ChrW(13)
            Next
            i = 0
            For Each fv As DataRow In dtVehiculos.Rows
                i += 1
                vehiculos = vehiculos + i.ToString + ")" + fv.Item("marca").ToString + "/" + fv.Item("modelo").ToString + "/" + fv.Item("placa").ToString + " " + ChrW(13)
            Next
            f.Item("telfonos") = telefonos
            f.Item("hijos") = hijos
            f.Item("vehiculos") = vehiculos
        Next
        Return dt
    End Function


    Private Sub SbUnoTodos_ValueChanged(sender As Object, e As EventArgs) Handles SbUnoTodos.ValueChanged
        If (Not SbUnoTodos.Value) Then
            CbFiltro.ReadOnly = True
            CbFiltro.Clear()
        Else
            CbFiltro.ReadOnly = False
        End If
    End Sub

    Private Sub P_prArmarCombos()
        _prCargarComboLibreria(CbFiltro, gi_LibSOCIO, gi_LibSOCTipo)
    End Sub

End Class