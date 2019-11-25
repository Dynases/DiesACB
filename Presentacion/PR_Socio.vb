Imports Logica.AccesoLogica
Imports Janus.Windows.GridEX.EditControls
Imports DevComponents.DotNetBar

Public Class PR_Socio

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
        Me.Text = "R E P O R T E   D E   S O C I O S"
        SbUnoTodos.Value = False
        CbFiltro.ReadOnly = True

        'Cargar combos
        P_ArmarCombos()

    End Sub

    Private Sub P_CargarReporte()
        Dim dt As DataTable
        Dim filtro As String = ""
        If (Not SbUnoTodos.Value) Then
            dt = L_fnSocioReporteSocio("0")
            filtro = "TODOS"
        Else
            dt = L_fnSocioReporteSocio(CbFiltro.Value.ToString)
            filtro = CbFiltro.Text
        End If

        If (dt.Rows.Count > 0) Then
            Dim objrep As New R_Socio

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

#End Region

    Private Sub P_ArmarCombos()
        _prCargarComboLibreria(CbFiltro, gi_LibSOCIO, gi_LibSOCTipo)
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