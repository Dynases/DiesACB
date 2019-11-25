Imports Logica.AccesoLogica
Imports DevComponents.DotNetBar

Public Class PR_EscuelaHorasTrabajadasExtrasInst

    Private _horaEntrada As String
    Private _horaSalida As String
#Region "Metodos Privados"
    Private Sub _prIniciarTodo()
        _PMIniciarTodo()
        Me.Text = "R E P O R T E     h o r a s    E X T R A S    t r a b a j a d a s    p o r    i n s t r u c t o r".ToUpper
        tbFiltrarInst.Value = False
        tbInst.Enabled = False

        MReportViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None

        'cargar hora de entrada y de salida
        Dim dt As DataTable = L_prTCE000General()
        _horaEntrada = dt.Rows(0).Item("eheentrada")
        _horaSalida = dt.Rows(0).Item("ehesalida")

    End Sub
    Private Sub _prCargarReporte()
        Dim _dt As DataTable = L_prClasesGetInstructoresParaReporteHorasTrabajadas()

        If tbFiltrarInst.Value = True Then
            If tbNumiInst.Text = String.Empty Then
                ToastNotification.Show(Me, "Seleccione Instructor!".ToUpper, My.Resources.INFORMATION, 2000, eToastGlowColor.Blue, eToastPosition.BottomLeft)
                Exit Sub
            Else
                Dim filasInstruc As DataRow()
                filasInstruc = _dt.Select("panumi=" + tbNumiInst.Text)
                _dt = filasInstruc.CopyToDataTable
            End If
        End If

        'ahora cargar las horas trabajadas de acuerdo a los horas trabajadas

        'CARGAR MINUTOS QUE TRANSCURRIERON EN CADA HORARIO
        Dim numiSuc As String = _dt.Rows(0).Item("pasuc")
        Dim dtHoras As DataTable = L_prHoraDetDelMesGeneral(tbFechaDel.Value.ToString("yyyy/MM/dd"), numiSuc, gi_LibHORARIOTipoPractEscuela)
        dtHoras.Columns.Add("minutos", GetType(Integer))
        For i = 0 To dtHoras.Rows.Count - 2
            Dim horaEnt1 As DateTime = _prToHora(dtHoras.Rows(i).Item("cchora"))
            Dim horaSal1 As DateTime = _prToHora(dtHoras.Rows(i + 1).Item("cchora"))
            Dim minutosDif As Integer = DateDiff(DateInterval.Minute, horaEnt1, horaSal1)
            dtHoras.Rows(i).Item("minutos") = minutosDif
        Next
        dtHoras.Rows(dtHoras.Rows.Count - 1).Item("minutos") = dtHoras.Rows(dtHoras.Rows.Count - 2).Item("minutos")

        'CARGAR SI CUENTA COMO DOBLE CLASE EL HORARIO
        dtHoras.Columns.Add("extra", GetType(Integer))
        Dim j As Integer = 0
        For j = 0 To dtHoras.Rows.Count - 1
            If _horaEntrada = dtHoras.Rows(j).Item("cchora") Then
                Exit For
            Else
                dtHoras.Rows(j).Item("extra") = 1
            End If
        Next
        For k = j To dtHoras.Rows.Count - 1
            If _horaSalida = dtHoras.Rows(k).Item("cchora") Then
                Exit For
            Else
                dtHoras.Rows(k).Item("extra") = 0
                j = j + 1
            End If
        Next
        For k = j To dtHoras.Rows.Count - 1
            dtHoras.Rows(k).Item("extra") = 1
        Next

        Dim dtFeriados As DataTable = L_prFeriadoGeneralPorRangoFecha(tbFechaDel.Value.ToString("yyyy/MM/dd"), tbFechaAl.Value.ToString("yyyy/MM/dd"))
        Dim listFeriados As New List(Of Date)
        For Each filaFecha As DataRow In dtFeriados.Rows
            listFeriados.Add(filaFecha.Item("pfflib"))
        Next
        For Each fila As DataRow In _dt.Rows
            If numiSuc <> fila.Item("pasuc") Then
                numiSuc = fila.Item("pasuc")

                dtHoras = L_prHoraDetDelMesGeneral(tbFechaDel.Value.ToString("yyyy/MM/dd"), numiSuc, gi_LibHORARIOTipoPractEscuela)
                dtHoras.Columns.Add("minutos", GetType(Integer))
                For i = 0 To dtHoras.Rows.Count - 2
                    Dim horaEnt1 As DateTime = _prToHora(dtHoras.Rows(i).Item("cchora"))
                    Dim horaSal1 As DateTime = _prToHora(dtHoras.Rows(i + 1).Item("cchora"))
                    Dim minutosDif As Integer = DateDiff(DateInterval.Minute, horaSal1, horaEnt1)
                    dtHoras.Rows(i).Item("minutos") = minutosDif
                Next
                dtHoras.Rows(dtHoras.Rows.Count - 1).Item("minutos") = dtHoras.Rows(dtHoras.Rows.Count - 2).Item("minutos")

                'CARGAR SI CUENTA COMO DOBLE CLASE EL HORARIO
                dtHoras.Columns.Add("extra", GetType(Integer))
                Dim m As Integer = 0
                For m = 0 To dtHoras.Rows.Count - 1
                    If _horaEntrada = dtHoras.Rows(m).Item("cchora") Then
                        Exit For
                    Else
                        dtHoras.Rows(m).Item("extra") = 1
                    End If
                Next
                For k = m To dtHoras.Rows.Count - 1
                    If _horaSalida = dtHoras.Rows(k).Item("cchora") Then
                        Exit For
                    Else
                        dtHoras.Rows(k).Item("extra") = 0
                        m = m + 1
                    End If
                Next
                For k = m To dtHoras.Rows.Count - 1
                    dtHoras.Rows(k).Item("extra") = 1
                Next
            End If

            'ahora consulto por dia cuanto trabajo
            Dim fechaInicio As DateTime = tbFechaDel.Value
            Dim fechaFin As DateTime = tbFechaAl.Value
            Dim sumHorasParaTrabajar As Integer = 0
            Dim sumHorasTrabajados As Integer = 0
            Dim sumHorasExtras As Integer = 0
            Dim dtHorasLiberadasInst As DataTable = L_prHoraLibreTCE0062GetPorRangoFechaInstructor(tbFechaDel.Value.ToString("yyyy/MM/dd"), tbFechaAl.Value.ToString("yyyy/MM/dd"), fila.Item("panumi"))
            Dim dtHorasDiligenciaInst As DataTable = L_prHoraDiligenciaTCE0063GetPorRangoFechaInstructor(tbFechaDel.Value.ToString("yyyy/MM/dd"), tbFechaAl.Value.ToString("yyyy/MM/dd"), fila.Item("panumi"))
            While fechaInicio <= fechaFin

                If fechaInicio.DayOfWeek <> DayOfWeek.Sunday And (listFeriados.Contains(fechaInicio) = False) Then 'no tomar en cuenta los domingos
                    Dim filasFiltradasLiberadas As DataRow() = dtHorasLiberadasInst.Select("ehhfec='" + fechaInicio.ToString("yyyy/MM/dd") + "'")
                    Dim listaHorasLiberadas As New List(Of String)
                    For Each filaLiberada As DataRow In filasFiltradasLiberadas
                        listaHorasLiberadas.Add(filaLiberada.Item("ehhhor"))
                    Next

                    Dim filasFiltradasDiligencia As DataRow() = dtHorasDiligenciaInst.Select("ehifec='" + fechaInicio.ToString("yyyy/MM/dd") + "'")
                    Dim listaHorasDiligencia As New List(Of String)
                    For Each filaLiberada As DataRow In filasFiltradasDiligencia
                        listaHorasDiligencia.Add(filaLiberada.Item("ehihor"))
                    Next


                    Dim dtHorasGrabadas As DataTable = L_prClasesPracDetGetHorasPorInstConFaltasMas(fechaInicio.ToString("yyyy/MM/dd"), fila.Item("panumi"))
                    Dim listaHorasGrabadas As New List(Of String)
                    For Each filaGrabada As DataRow In dtHorasGrabadas.Rows
                        listaHorasGrabadas.Add(filaGrabada.Item("ehhor"))
                    Next


                    Dim ii As Integer = 0
                    Dim jj As Integer = 0
                    Dim turnosBasicosParaTrabajar As Integer = 4
                    Dim cantTurnos As Integer = 0
                    For Each filaHora As DataRow In dtHoras.Rows
                        sumHorasParaTrabajar = sumHorasParaTrabajar + 1
                        'If jj <= dtHorasGrabadas.Rows.Count - 1 Then
                        '    If filaHora.Item("cchora") = dtHorasGrabadas(jj).Item("ehhor") Or listaHorasDiligencia.Contains(filaHora.Item("cchora")) = True Then ' and listaHorasLiberadas.Contains(dtHorasGrabadas(jj).Item("ehhor")) = False
                        '        If filaHora.Item("extra") = 1 Then
                        '            'sumHorasTrabajados = sumHorasTrabajados + (1 * 2)
                        '            'cantTurnos = cantTurnos + 2
                        '            sumHorasExtras = sumHorasExtras + (1 * 2)
                        '        Else
                        '            sumHorasTrabajados = sumHorasTrabajados + 1
                        '            cantTurnos = cantTurnos + 1
                        '        End If

                        '        jj = jj + 1
                        '        'sumar horas extras
                        '        If cantTurnos > turnosBasicosParaTrabajar And filaHora.Item("extra") <> 1 Then
                        '            sumHorasExtras = sumHorasExtras + 1
                        '            'If filaHora.Item("extra") = 1 Then
                        '            '    sumHorasExtras = sumHorasExtras + (1 * 2)
                        '            'Else
                        '            '    sumHorasExtras = sumHorasExtras + 1
                        '            'End If
                        '        End If

                        '    End If
                        'End If

                        If listaHorasGrabadas.Contains(filaHora.Item("cchora")) Or listaHorasDiligencia.Contains(filaHora.Item("cchora")) = True Then ' and listaHorasLiberadas.Contains(dtHorasGrabadas(jj).Item("ehhor")) = False
                            If filaHora.Item("extra") = 1 Then
                                'sumHorasTrabajados = sumHorasTrabajados + (1 * 2)
                                'cantTurnos = cantTurnos + 2
                                sumHorasExtras = sumHorasExtras + (1 * 2)
                                sumHorasTrabajados = sumHorasTrabajados + 1

                            Else
                                sumHorasTrabajados = sumHorasTrabajados + 1
                                cantTurnos = cantTurnos + 1
                            End If

                            jj = jj + 1
                            'sumar horas extras
                            If cantTurnos > turnosBasicosParaTrabajar And filaHora.Item("extra") <> 1 Then
                                sumHorasExtras = sumHorasExtras + 1
                                'If filaHora.Item("extra") = 1 Then
                                '    sumHorasExtras = sumHorasExtras + (1 * 2)
                                'Else
                                '    sumHorasExtras = sumHorasExtras + 1
                                'End If
                            End If

                        End If
                    Next
                End If

                fechaInicio = DateAdd(DateInterval.Day, 1, fechaInicio)
            End While

            'ahora lo convierto a hora y lo pongo en el dtFinal
            Dim horasParaTrabajar As Double = sumHorasParaTrabajar
            Dim horasTrabajadas As Double = sumHorasTrabajados
            Dim horasLibres As Double = horasParaTrabajar - horasTrabajadas
            Dim horasExtras As Double = sumHorasExtras

            fila.Item("horasTot") = horasParaTrabajar
            fila.Item("horasT") = horasTrabajadas
            'fila.Item("horasL") = horasParaTrabajar - horasTrabajadas
            fila.Item("horasL") = horasExtras
        Next

        If (_dt.Rows.Count > 0) Then
            Dim objrep As New R_HorasTrabajadasExtrasIntsEscuela


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
    Private Function _prToHora(cad As String) As DateTime
        'Dim hora As String = cad.Split(":")(0)
        'Dim segundo As String = cad.Split(":")(1)
        Dim horaFin As DateTime = DateTime.Parse(cad + ":00")
        Return horaFin
    End Function
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
            Dim dt As DataTable
            dt = L_prPersonaAyudaGeneral(gi_LibPERSTIPOInstructor)

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



    Private Sub GroupPanel1_Click(sender As Object, e As EventArgs) Handles GroupPanel1.Click

    End Sub
End Class