Imports Logica.AccesoLogica
Imports DevComponents.DotNetBar

Public Class PR_PlanillaMensualMarcacion

#Region "Metodos privados"
    Private Sub _prIniciarTodo()
        tbAnio.Value = Now.Year
        tbMes.Value = Now.Month
        _PMIniciarTodo()
        Me.Text = "R E P O R T E     D E    p l a n i l l a    m e n s u a l    d e    m a r c a c i o n    d e l    p e r s o n a l".ToUpper

        MReportViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None

    End Sub
    Private Sub _prCargarReporte()
        Dim dtFinal As DataTable = L_prAsistenciaGetEstructuraReporteMensual()
        Dim dtPersonal As DataTable = dtFinal.Copy
        Dim dtTurnoFin As DataTable
        dtFinal.Rows.Clear()
        Dim dtRegistros As DataTable = L_prAsistenciaGetRegistrosTP0071PorMes(New Date(tbAnio.Value, tbMes.Value, 1).ToString("yyyy/MM/dd"))
        Dim fecha As DateTime = New Date(tbAnio.Value, tbMes.Value, 1)
        Dim ultDia As Integer = DateSerial(Year(fecha), Month(fecha) + 1, 0).Day

        'pregunto si estoy filtrando por personal
        If tbFiltrar.Value = True Then
            If tbPersonal.Tag > 0 Then
                Dim filasSeleccionadas As DataRow() = dtPersonal.Select("panumi=" + tbPersonal.Tag.ToString.Trim)
                If filasSeleccionadas.Count > 0 Then
                    dtPersonal = filasSeleccionadas.CopyToDataTable
                Else
                    ToastNotification.Show(Me, "el personal seleccionado no tiene marcaciones grabadas en el año y mes seleccionados..!!!".ToUpper,
                                       My.Resources.INFORMATION, 2000,
                                       eToastGlowColor.Blue,
                                          eToastPosition.BottomLeft)
                    MReportViewer.ReportSource = Nothing
                    Return
                End If
            Else
                ToastNotification.Show(Me, "seleccione personal con ctrl+enter en la casilla personal..!!!".ToUpper,
                                       My.Resources.INFORMATION, 2000,
                                       eToastGlowColor.Blue,
                                          eToastPosition.BottomLeft)
                MReportViewer.ReportSource = Nothing
                Return
            End If

        End If
        For Each fila As DataRow In dtPersonal.Rows
            Dim numiPer As String = fila.Item("panumi")
            Dim descPer As String = fila.Item("panom1")
            Dim filasFiltradas As DataRow()
            filasFiltradas = dtRegistros.Select("pjcper=" + numiPer, "pjfecha asc")
            If filasFiltradas.Count > 0 Then
                Dim dtRegPersona As DataTable = filasFiltradas.CopyToDataTable
                Dim sumRetrasoTotal As Integer = 0
                Dim sumFaltas As Integer = 0
                Dim sumAsistencia As Integer = 0
                For i = 0 To ultDia - 1

                    dtTurnoFin = L_prAsistenciaCorreccionGetTurnoPorPersona(New DateTime(fecha.Year, fecha.Month, 1).ToString("yyyy/MM/dd"), numiPer)
                    If dtTurnoFin.Rows.Count = 0 Then
                        dtTurnoFin = L_prAsistenciaCorreccionGetTurnoPorPersonaAnteriorMeses(New DateTime(fecha.Year, fecha.Month, 1).ToString("yyyy/MM/dd"), numiPer)
                    Else
                        If CType(dtTurnoFin.Rows(0).Item("pifdoc"), Date).Day <> 1 Then
                            Dim dtUltimoTurno As DataTable = L_prAsistenciaCorreccionGetTurnoPorPersonaAnteriorMeses(New DateTime(fecha.Year, fecha.Month, 1).ToString("yyyy/MM/dd"), numiPer)
                            If dtUltimoTurno.Rows.Count > 0 Then
                                Dim filaUltimoTurno As DataRow = dtUltimoTurno.Rows(0)
                                dtTurnoFin.ImportRow(filaUltimoTurno)
                                ''MUY IMPORTANTE,SI FALLA HAY QUE PONER ESA FECHA QUE AUMENTE DEL ULTIMO TURNO COMO PRIMERO DE ESTE MES
                                Dim ordenar As DataRow() = dtTurnoFin.Select("1=1", "pifdoc asc")
                                dtTurnoFin = ordenar.CopyToDataTable
                            Else
                                ToastNotification.Show(Me, "existe un problema con el personal :".ToUpper + numiPer + " " + descPer + " no cuenta con un turno anterior al primero de este mes y no se pueden cargar sus marcaciones".ToUpper, My.Resources.WARNING, 5000, eToastGlowColor.Green, eToastPosition.TopCenter)
                                MReportViewer.ReportSource = Nothing
                                Exit Sub ' esto lo comente por si acaso,para ver si sigue el ciclo
                            End If

                        End If
                    End If

                    Dim fechaDia As String = New DateTime(fecha.Year, fecha.Month, i + 1).ToString("yyyy/MM/dd")
                    Dim dtRegDia As New DataTable
                    Dim filasDia As DataRow()
                    filasDia = dtRegPersona.Select("pjcper=" + numiPer + " and pjfecha='" + fechaDia + "'", "pjturno asc")
                    'preparo los datos para poner en el datatable
                    Dim dia As String = i + 1
                    Dim ing1 As String = ""
                    Dim sal1 As String = ""
                    Dim ing2 As String = ""
                    Dim sal2 As String = ""
                    Dim obs As String = ""
                    Dim horaEnt1 As DateTime
                    Dim horaSal1 As DateTime
                    Dim horaEnt2 As DateTime
                    Dim horaSal2 As DateTime

                    Dim turnoEnt1 As DateTime
                    Dim turnoSal1 As DateTime
                    Dim turnoEnt2 As DateTime
                    Dim turnoSal2 As DateTime

                    Dim difEnt1 As Integer
                    Dim difSal1 As Integer
                    Dim difEnt2 As Integer
                    Dim difSal2 As Integer

                    If filasDia.Count > 0 Then
                        dtRegDia = filasDia.CopyToDataTable

                        If dtRegDia.Rows.Count = 1 Then 'significa que solo marco un turno en el dia
                            ing1 = dtRegDia.Rows(0).Item("pjent")
                            sal1 = dtRegDia.Rows(0).Item("pjsal")

                            horaEnt1 = _prToHora(ing1)
                            horaSal1 = _prToHora(sal1)
                        Else 'significa que marco 2 turnos en el dia
                            ing1 = dtRegDia.Rows(0).Item("pjent")
                            sal1 = dtRegDia.Rows(0).Item("pjsal")
                            ing2 = dtRegDia.Rows(1).Item("pjent")
                            sal2 = dtRegDia.Rows(1).Item("pjsal")

                            horaEnt1 = _prToHora(ing1)
                            horaSal1 = _prToHora(sal1)
                            horaEnt2 = _prToHora(ing2)
                            horaSal2 = _prToHora(sal2)
                        End If

                        Dim pos As Integer

                        If dtTurnoFin.Rows.Count = 1 Then
                            pos = 0
                        Else
                            Dim q As Integer = 0
                            pos = 0
                            While q < dtTurnoFin.Rows.Count
                                If fechaDia >= CType(dtTurnoFin.Rows(q).Item("pifdoc"), Date) Then
                                    Exit While
                                End If
                                q = q + 1
                            End While
                            pos = q
                        End If

                        'ahora se que turno corresponde a este dia
                        If dtTurnoFin.Rows(pos).Item("nTurnos") = 1 Then
                            turnoEnt1 = _prToHora(dtTurnoFin.Rows(pos).Item("coing1"))
                            turnoSal1 = _prToHora(dtTurnoFin.Rows(pos).Item("cosal1"))

                            difEnt1 = DateDiff(DateInterval.Minute, turnoEnt1, horaEnt1)
                            difSal1 = DateDiff(DateInterval.Minute, turnoSal1, horaSal1)
                        Else
                            turnoEnt1 = _prToHora(dtTurnoFin.Rows(pos).Item("coing1"))
                            turnoSal1 = _prToHora(dtTurnoFin.Rows(pos).Item("cosal1"))
                            turnoEnt2 = _prToHora(dtTurnoFin.Rows(pos).Item("coing2"))
                            turnoSal2 = _prToHora(dtTurnoFin.Rows(pos).Item("cosal2"))

                            difEnt1 = DateDiff(DateInterval.Minute, horaEnt1, turnoEnt1)
                            difSal1 = DateDiff(DateInterval.Minute, horaSal1, turnoSal1)
                            difEnt2 = DateDiff(DateInterval.Minute, horaEnt2, turnoEnt2)
                            difSal2 = DateDiff(DateInterval.Minute, horaSal2, turnoSal2)
                        End If
                        Dim difTotal As Integer = IIf(difEnt1 < 0, difEnt1 * -1, difEnt1) + IIf(difEnt2 < 0, difEnt2 * -1, difEnt2) '+ IIf(difSal1 > 0, difSal1, 0) + IIf(difSal2 > 0, difSal2, 0)
                        obs = difTotal.ToString
                    Else
                        obs = "F"
                    End If

                    If New DateTime(fecha.Year, fecha.Month, i + 1).DayOfWeek = DayOfWeek.Sunday Then
                        obs = "DOMINGO"
                        ing1 = "-------------"
                        sal1 = "-------------"
                        ing2 = "-------------"
                        sal2 = "-------------"
                    End If
                    ''If New DateTime(fecha.Year, fecha.Month, i + 1).DayOfWeek = DayOfWeek.Saturday Then
                    ''    obs = "SABADO"
                    ''    ing1 = "-------------"
                    ''    sal1 = "-------------"
                    ''    ing2 = "-------------"
                    ''    sal2 = "-------------"
                    ''End If
                    'inserto al datatable
                    dtFinal.Rows.Add(numiPer, descPer, dia, ing1, sal1, ing2, sal2, obs)
                Next
            Else 'no hay marcaciones del personal entonces simplemente ponerle sin marcacion

            End If
        Next

        'cargar el reporte
        If (dtFinal.Rows.Count > 0) Then
            Dim objrep As New R_PlanillaMensualMarcacion

            objrep.SetDataSource(dtFinal)
            MReportViewer.ReportSource = objrep

            objrep.SetParameterValue("gestion", fecha.Month.ToString + "/" + fecha.Year.ToString)

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

    Private Function _prToHora(cad As String) As DateTime
        'Dim hora As String = cad.Split(":")(0)
        'Dim segundo As String = cad.Split(":")(1)
        Dim horaFin As DateTime = DateTime.Parse(cad + ":00")
        Return horaFin
    End Function
#End Region
    Private Sub PR_PlanillaMensualMarcacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _prIniciarTodo()
    End Sub

    Private Sub btnGenerar_Click(sender As Object, e As EventArgs) Handles btnGenerar.Click
        _prCargarReporte()
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub GroupPanel2_Click(sender As Object, e As EventArgs) Handles GroupPanel2.Click

    End Sub

    Private Sub tbPersonal_KeyDown(sender As Object, e As KeyEventArgs) Handles tbPersonal.KeyDown
        If e.KeyData = Keys.Control + Keys.Enter Then

            'grabar horario
            Dim frmAyuda As Modelos.ModeloAyuda
            Dim dt As DataTable

            dt = L_prPersonaAyudaObtenerConGrabacionesEnMesAnio(tbMes.Value, tbAnio.Value)

            Dim listEstCeldas As New List(Of Modelos.Celda)
            listEstCeldas.Add(New Modelos.Celda("panumi", True, "Codigo".ToUpper, 70))
            listEstCeldas.Add(New Modelos.Celda("paci", True, "ci".ToUpper, 150))
            listEstCeldas.Add(New Modelos.Celda("panom", True, "nombre".ToUpper, 200))
            listEstCeldas.Add(New Modelos.Celda("paape", True, "apellido".ToUpper, 200))
            listEstCeldas.Add(New Modelos.Celda("panom1", False, "descripcion".ToUpper, 200))

            frmAyuda = New Modelos.ModeloAyuda(200, 200, dt, "seleccione personal".ToUpper, listEstCeldas)
            frmAyuda.ShowDialog()

            If frmAyuda.seleccionado = True Then
                Dim numiPer As String = frmAyuda.filaSelect.Cells("panumi").Value
                Dim nombrePer As String = frmAyuda.filaSelect.Cells("panom1").Value

                tbPersonal.Text = nombrePer
                tbPersonal.Tag = numiPer
            End If
        End If
    End Sub

    Private Sub tbAnio_ValueChanged(sender As Object, e As EventArgs) Handles tbAnio.ValueChanged, tbMes.ValueChanged
        tbPersonal.Tag = 0
        tbPersonal.Text = ""
        MReportViewer.ReportSource = Nothing

    End Sub

    Private Sub tbFiltrar_ValueChanged(sender As Object, e As EventArgs) Handles tbFiltrar.ValueChanged
        tbPersonal.Tag = 0
        tbPersonal.Text = ""
        tbPersonal.Enabled = tbFiltrar.Value
    End Sub
End Class