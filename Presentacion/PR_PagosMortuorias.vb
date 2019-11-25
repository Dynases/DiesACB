Imports Logica.AccesoLogica
Imports Janus.Windows.GridEX.EditControls
Imports DevComponents.DotNetBar

Public Class PR_PagosMortuorias

#Region "Variables"



#End Region

#Region "Eventos"

    Private Sub PR_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        P_Inicio()
    End Sub

    Private Sub btnGenerar_Click(sender As Object, e As EventArgs) Handles btnGenerar.Click
        P_CargarReporte()
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

#End Region

#Region "Metodos"

    Private Sub P_Inicio()
        'Abrir conexion
        'L_prAbrirConexion()

        'Inicializar componentes
        Me.Text = "R E P O R T E   D E   P A G O S   D E   C A J A   M O R T U O R I A"
        RbGeneral.Checked = True
        TbiCantidadGestiones.IsInputReadOnly = Not RbCantMeses.Checked
        TbiCantidadGestiones.Value = 0

        P_prArmarCombos()
    End Sub

    Private Sub P_prArmarCombos()
        _prCargarComboLibreria(CbFiltro, gi_LibSOCIO, gi_LibSOCTipo)
    End Sub

    Private Sub P_CargarReporte()
        Dim dt As New DataTable
        Dim filtro As String = ""
        If (SbUnoTodos.Value) Then
            If (Not IsNumeric(CbFiltro.Value)) Then
                ToastNotification.Show(Me, "Debe elegir un tipo de socio.".ToUpper,
                                       My.Resources.INFORMATION, 2000,
                                       eToastGlowColor.Blue,
                                       eToastPosition.BottomLeft)
                Exit Sub
            End If
        End If

        If (RbGeneral.Checked) Then
            dt = L_fnSocioPagosMortuoriaReporteGeneral("1", IIf(IsNumeric(CbFiltro.Value), CbFiltro.Value, 0))
            filtro = "GENERAL"
        ElseIf (RbSinMora.Checked) Then
            dt = L_fnSocioPagosMortuoriaReporteSoloSinMora("2", IIf(IsNumeric(CbFiltro.Value), CbFiltro.Value, 0))
            filtro = "SIN MORA"
        ElseIf (RbMora.Checked) Then
            dt = L_fnSocioPagosMortuoriaReporteSoloMora("3", IIf(IsNumeric(CbFiltro.Value), CbFiltro.Value, 0))
            filtro = "CON MORA"
        ElseIf (RbCantMeses.Checked) Then
            If (TbiCantidadGestiones.Value > 0) Then
                dt = L_fnSocioPagosMortuoriaReporteCantidadMeses("4", TbiCantidadGestiones.Value.ToString, IIf(IsNumeric(CbFiltro.Value), CbFiltro.Value, 0))
                filtro = "CON CANTIDAD DE MORA >= " + TbiCantidadGestiones.Value.ToString
            Else
                ToastNotification.Show(Me, "la cantidad de años debe ser mayor a cero.".ToUpper,
                                       My.Resources.INFORMATION, 2000,
                                       eToastGlowColor.Blue,
                                       eToastPosition.BottomLeft)
            End If
        ElseIf (RbGestionesPagadas.Checked) Then
            dt = L_fnSocioPagosMortuoriaGestionesPagadasReporteGeneral()

            If (dt.Rows.Count > 0) Then
                Dim objrep As New R_PagosMortuoriaGestionesPagadas

                objrep.SetDataSource(dt)
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

            Exit Sub
        End If

        If (dt.Rows.Count > 0) Then
            Dim objrep As New R_PagosMortuoria

            objrep.SetDataSource(dt)
            objrep.SetParameterValue("Titulo", filtro)

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

    Private Sub RbCantMeses_CheckedChanged(sender As Object, e As EventArgs) Handles RbCantMeses.CheckedChanged
        TbiCantidadGestiones.IsInputReadOnly = Not RbCantMeses.Checked
        TbiCantidadGestiones.Value = 0
    End Sub

    Private Sub SbUnoTodos_ValueChanged(sender As Object, e As EventArgs) Handles SbUnoTodos.ValueChanged
        If (Not SbUnoTodos.Value) Then
            CbFiltro.ReadOnly = True
            CbFiltro.Clear()
        Else
            CbFiltro.ReadOnly = False
        End If
    End Sub
End Class