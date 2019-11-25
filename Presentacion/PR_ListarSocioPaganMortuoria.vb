Imports Logica.AccesoLogica
Imports DevComponents.DotNetBar

Public Class PR_ListarSocioPaganMortuoria

#Region "Variables"

    Dim Duracion As Integer = 5

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
        Me.Text = "R E P O R T E   D E   P A G O S   D E   S O C I O S"

        Me.MReportViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None

        RbHonorario.Checked = True
        RbTodos.Checked = True

    End Sub

    Private Sub P_CargarReporte()
        Dim dt As DataTable
        If (P_Validar()) Then
            Dim tsoc As String = ""
            Dim criterio As String = ""
            Dim filtro As String = "TODOS LOS QUE ''SI'' Y ''NO'' APORTAN"
            If (RbHonorario.Checked) Then
                tsoc = "2"
            ElseIf (RbActivo.Checked) Then
                tsoc = "1"
            ElseIf (RbMeritorio.Checked) Then
                tsoc = "3"
            End If

            If (RbSiMor.Checked) Then
                criterio = " and a.mor=1"
                filtro = "TODOS LOS QUE ''SI'' APORTAN"
            ElseIf (RbNoMor.Checked) Then
                criterio = " and a.mor=0"
                filtro = "TODOS LOS QUE ''NO'' APORTAN"
            End If

            dt = L_fnListarSocioPaganMortuoria(tsoc, criterio)

            If (dt.Rows.Count > 0) Then
                Dim objrep As New R_ListarSocioPaganMortuoria

                objrep.SetDataSource(dt)

                objrep.SetParameterValue("Filtro", filtro)

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


    Private Function P_Validar() As Boolean
        Dim sms As String = ""

        'If (Not IsNumeric(CbSocio.Value)) Then
        '    If (sms = String.Empty) Then
        '        sms = "debe eligir un socio de la lista.".ToUpper
        '    Else
        '        sms = sms + ChrW(13) + "debe eligir un socio de la lista.".ToUpper
        '    End If
        'End If

        If (Not sms = String.Empty) Then
            ToastNotification.Show(Me, sms.ToUpper,
                       My.Resources.WARNING,
                       Duracion * 1000,
                       eToastGlowColor.Red,
                       eToastPosition.TopCenter)
            Return False
            Exit Function
        End If

        Return True
    End Function

#End Region

End Class