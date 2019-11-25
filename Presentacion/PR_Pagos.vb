Imports Logica.AccesoLogica
Imports Janus.Windows.GridEX.EditControls
Imports DevComponents.DotNetBar

Public Class PR_Pagos

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

        'Cargar combos
        P_ArmarCombos()

    End Sub

    Private Sub P_CargarReporte()
        Dim dt As DataTable
        Dim filtro As String = ""
        If (P_Validar) Then
            dt = L_fnSocioPagosReportePagos(CbSocio.Value.ToString, CbGestion.Text)

            If (dt.Rows.Count > 0) Then
                Dim objrep As New R_Pagos

                objrep.SetDataSource(dt)

                objrep.SetParameterValue("NombreSocio", CbSocio.Text)
                objrep.SetParameterValue("NroSocio", CbSocio.Value.ToString)
                objrep.SetParameterValue("Anho1", (CInt(CbGestion.Text) - 1).ToString)
                objrep.SetParameterValue("Anho2", CbGestion.Text)

                Dim dtM As DataTable = L_fnSocioDetallePagosMortuoriaUltimoDosAnho(CbSocio.Value.ToString, CbGestion.Text)
                If (dtM.Rows.Count > 0) Then
                    objrep.SetParameterValue("Fecha1", dtM.Rows(0).Item("fdoc").ToString)
                    objrep.SetParameterValue("Fecha2", dtM.Rows(0).Item("fdoc2").ToString)
                    objrep.SetParameterValue("Recibo1", dtM.Rows(0).Item("rec").ToString)
                    objrep.SetParameterValue("Recibo2", dtM.Rows(0).Item("rec2").ToString)
                    objrep.SetParameterValue("Importe1", dtM.Rows(0).Item("monto").ToString)
                    objrep.SetParameterValue("Importe2", dtM.Rows(0).Item("monto2").ToString)
                    objrep.SetParameterValue("Saldo1", dtM.Rows(0).Item("saldo").ToString)
                    objrep.SetParameterValue("Saldo2", dtM.Rows(0).Item("saldo2").ToString)
                Else
                    objrep.SetParameterValue("Fecha1", "01/01/2000")
                    objrep.SetParameterValue("Fecha2", "01/01/2000")
                    objrep.SetParameterValue("Recibo1", "0")
                    objrep.SetParameterValue("Recibo2", "0")
                    objrep.SetParameterValue("Importe1", "278.50")
                    objrep.SetParameterValue("Importe2", "278.50")
                    objrep.SetParameterValue("Saldo1", "278.50")
                    objrep.SetParameterValue("Saldo2", "278.50")
                End If

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

    Private Sub P_ArmarCombos()
        P_ArmarComboSocio()
        P_ArmarComboAnho()
    End Sub

    Private Sub P_ArmarComboSocio()
        g_prArmarCombo(CbSocio, L_fnSocioPagosReporteComboSocio(), 60, 500, "Nro. Socio", "Nombre Socio")
        CbSocio.SelectedIndex = 0
    End Sub

    Private Sub P_ArmarComboAnho()
        g_prArmarCombo(CbGestion, L_fnSocioPagosReporteComboAbho(), 60, 250, "Código", "Año")
        CbGestion.SelectedText = Now.Year.ToString
    End Sub

    Private Function P_Validar() As Boolean
        Dim sms As String = ""

        If (Not IsNumeric(CbSocio.Value)) Then
            If (sms = String.Empty) Then
                sms = "debe eligir un socio de la lista.".ToUpper
            Else
                sms = sms + ChrW(13) + "debe eligir un socio de la lista.".ToUpper
            End If
        End If

        If (Not IsNumeric(CbGestion.Value)) Then
            If (sms = String.Empty) Then
                sms = "debe eligir una gestión de la lista.".ToUpper
            Else
                sms = sms + ChrW(13) + "debe eligir una gestión de la lista.".ToUpper
            End If
        End If

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

    Private Sub CbSocio_KeyDown(sender As Object, e As KeyEventArgs) Handles CbSocio.KeyDown
        If (e.KeyData = Keys.Control + Keys.Enter) Then
            Dim frmAyuda As Modelos.ModeloAyuda
            Dim dt As DataTable = L_fnSocioPagosReporteComboSocio()
            Dim listEstCeldas As New List(Of Modelos.Celda)
            listEstCeldas.Add(New Modelos.Celda("cod", True, "Codigo".ToUpper, 70))
            listEstCeldas.Add(New Modelos.Celda("desc", True, "nombre".ToUpper, 300))

            frmAyuda = New Modelos.ModeloAyuda(200, 200, dt, "Seleccione un socio".ToUpper, listEstCeldas)
            frmAyuda.ShowDialog()

            If frmAyuda.seleccionado = True Then
                CbSocio.Clear()
                CbSocio.SelectedText = frmAyuda.filaSelect.Cells("desc").Value.ToString
            End If
        End If
    End Sub

#End Region

End Class