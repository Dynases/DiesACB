Imports Logica.AccesoLogica
Imports Janus.Windows.GridEX.EditControls
Imports DevComponents.DotNetBar

Public Class PR_SocioEdad

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
        Me.Text = "R E P O R T E  E D A D   D E   S O C I O S"
        DtiFechaIni.Value = Now.Date
        DtiFechaFin.Value = Now.Date.AddDays(6)

    End Sub

    Private Sub P_CargarReporte()
        Dim dt As DataTable
        Dim filtro As String = ""
        If (DtiFechaIni.Value <= DtiFechaFin.Value) Then
            dt = L_fnSocioReporteSocioEdad(DtiFechaIni.Value.ToString("yyyy/MM/dd"), DtiFechaFin.Value.ToString("yyyy/MM/dd"))

            If (dt.Rows.Count > 0) Then
                Dim objrep As New R_SocioCumpleanhos

                objrep.SetDataSource(dt)

                objrep.SetParameterValue("FechaIni", DtiFechaIni.Value.Day.ToString("00") + "-" + DtiFechaIni.Value.Month.ToString("00"))
                objrep.SetParameterValue("FechaFin", DtiFechaFin.Value.Day.ToString("00") + "-" + DtiFechaFin.Value.Month.ToString("00"))

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
            ToastNotification.Show(Me, "LA FECHA DESDE DEBE SER MENOR O IGUAL A LA FECHA HASTA..!!",
                                           My.Resources.INFORMATION, 2000,
                                           eToastGlowColor.Blue,
                                           eToastPosition.BottomLeft)
        End If
    End Sub

#End Region

End Class