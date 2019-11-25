Imports Logica.AccesoLogica
Public Class ClsMes
    Public vDias As ClsHora(,)
    Public vHoras As List(Of String)
    Public vUltDia As Integer
    Public vFecha As Date

    'estados 
    '-2=feriado
    '-1=dia sabado
    '0=dia marcado
    '1=dia ya grabado del alumno
    Const conHoraDiligencia As Integer = -5
    Const conHoraLiberada As Integer = -4
    Const conCumple As Integer = -3
    Const conFeriado As Integer = -2
    Const conSabado As Integer = -1
    Const conDiaMarcado As Integer = 0
    Const conDiaGrabadoAlumno As Integer = 1

    Const conEstClaseFalta As Integer = -1
    Const conEstClaseProgramada As Integer = 0
    Const conEstClaseAsistida As Integer = 1
    Const conEstClasePermiso As Integer = 2
    Const conEstClaseSuspension As Integer = 3

    Public Sub New(fecha1 As Date, numiInstr As String, dtAlumnos As DataTable, numiSuc As String)
        vDias = New ClsHora(50, 50) {}

        vFecha = fecha1

        'cargo las horas en la lista de horas
        Dim dtHoras As DataTable = L_prHoraDetDelMesGeneral(vFecha.ToString("yyyy/MM/dd"), numiSuc, gi_LibHORARIOTipoPractEscuela)
        vHoras = New List(Of String)
        For Each fila As DataRow In dtHoras.Rows
            vHoras.Add(fila.Item("cchora"))
        Next

        'poner ultimo dia del mes
        vUltDia = DateSerial(Year(vFecha), Month(vFecha) + 1, 0).Day

        'cargar domingos
        _prCargarFinSemana()

        'cargar feriados
        _prCargarFeriados()

        If gi_cumpleInstructor = 1 Then
            _prCargarCumpleanosInstructor(numiInstr)
        End If

        'cargar fechas de los alumnos
        'cargar los datos de la grilla
        'Dim numiAlum As String
        'For i = 0 To dtAlumnos.Rows.Count - 1
        '    numiAlum = dtAlumnos.Rows(i).Item("cbnumi")

        '    _prCargarDiasDeAlumnos(numiInstr.ToString, numiAlum.ToString, Color.FromArgb(dtAlumnos.Rows(i).Item("color")))
        'Next

        '----------------------------------------------------------
        'probando una solucion para que sea menos lento
        Dim dtHorasTodoElMesInstructor As DataTable = L_prClasesPracDetFechasPorAlumnoYFechaGeneral_FiltradoPorSoloChofer(numiInstr.ToString.Trim, vFecha.ToString("yyyy/MM/dd"))
        Dim dtHorasMesesAnterioresPorInstructor As DataTable = L_prClasesPracDetFechasPorAlumnoYFechaGeneralContables_FiltradoPorSoloChofer(numiInstr.ToString.Trim, DateAdd(DateInterval.Month, -1, vFecha).ToString("yyyy/MM/dd"))
        'cargar fechas de los alumnos
        'cargar los datos de la grilla
        Dim numiAlum As String
        For i = 0 To dtAlumnos.Rows.Count - 1
            numiAlum = dtAlumnos.Rows(i).Item("cbnumi")

            _prCargarDiasDeAlumnos2(numiInstr.ToString, numiAlum.ToString, Color.FromArgb(dtAlumnos.Rows(i).Item("color")), dtHorasTodoElMesInstructor, dtHorasMesesAnterioresPorInstructor)
        Next
        '----------------------------------------------------------

        _prCargarHorasLiberadas(numiInstr)
        _prCargarHorasDiligencias(numiInstr)
    End Sub

    Public Sub New(fecha1 As Date, numiSuc As String)
        vDias = New ClsHora(50, 50) {}

        vFecha = fecha1

        'cargo las horas en la lista de horas
        Dim dtHoras As DataTable = L_prHoraDetDelMesGeneral(vFecha.ToString("yyyy/MM/dd"), numiSuc, gi_LibHORARIOTipoPractEscuela)
        vHoras = New List(Of String)
        For Each fila As DataRow In dtHoras.Rows
            vHoras.Add(fila.Item("cchora"))
        Next

        'poner ultimo dia del mes
        vUltDia = DateSerial(Year(vFecha), Month(vFecha) + 1, 0).Day

        'cargar domingos
        _prCargarFinSemana()

        'cargar feriados
        _prCargarFeriados()

    End Sub
    Private Sub _prCargarHorasLiberadas(numiInstr As String)
        Dim dtHorasLiberadas As DataTable = L_prHoraLibreTCE0062GetPorFechaInstructor(vFecha.ToString("yyyy/MM/dd"), numiInstr)

        For Each fila As DataRow In dtHorasLiberadas.Rows
            Dim hora As String = fila.Item("ehhhor")
            Dim fecha As Date = fila.Item("ehhfec")
            Dim obs As String = fila.Item("ehhobs")
            Dim numi As String = fila.Item("ehhlin")
            Dim f As Integer = vHoras.IndexOf(hora)
            vDias(f, fecha.Day - 1) = New ClsHora(Color.Black, 0, 0, conHoraLiberada, obs, numi)
        Next
    End Sub

    Private Sub _prCargarHorasDiligencias(numiInstr As String)
        Dim dtHorasLiberadas As DataTable = L_prHoraDiligenciaTCE0063GetPorFechaInstructor(vFecha.ToString("yyyy/MM/dd"), numiInstr)

        For Each fila As DataRow In dtHorasLiberadas.Rows
            Dim hora As String = fila.Item("ehihor")
            Dim fecha As Date = fila.Item("ehifec")
            Dim obs As String = fila.Item("ehiobs")
            Dim numi As String = fila.Item("ehilin")
            Dim f As Integer = vHoras.IndexOf(hora)
            vDias(f, fecha.Day - 1) = New ClsHora(Color.Black, 0, 0, conHoraDiligencia, obs, numi)
        Next
    End Sub


    Public Sub _prCargarRecursivoFinSemana(n As Integer, ByRef fecha As Date)
        If (n = 0) Then
            If fecha.DayOfWeek = DayOfWeek.Sunday Then
                _prCargarDiaDomingo(fecha.Day - 1)
            End If
            If fecha.DayOfWeek = DayOfWeek.Saturday Then
                _prCargarDiaSabado(fecha.Day - 1)
            End If
            fecha = fecha.AddDays(1)
        Else
            _prCargarRecursivoFinSemana(n - 1, fecha)

        End If
        If fecha.DayOfWeek = DayOfWeek.Sunday Then
            _prCargarDiaDomingo(fecha.Day - 1)
        End If
        If fecha.DayOfWeek = DayOfWeek.Saturday Then
            _prCargarDiaSabado(fecha.Day - 1)
        End If
        fecha = fecha.AddDays(1)
    End Sub
    Public Sub _prCargarFinSemana()
        Dim fecha As Date = vFecha
        '_prCargarRecursivoFinSemana(vUltDia, fecha)
        For i = 1 To vUltDia
            If fecha.DayOfWeek = DayOfWeek.Sunday Then
                _prCargarDiaDomingo(fecha.Day - 1)
            End If
            If fecha.DayOfWeek = DayOfWeek.Saturday Then
                _prCargarDiaSabado(fecha.Day - 1)
            End If
            fecha = fecha.AddDays(1)
        Next
    End Sub
    Private Sub _prCargarDiaDomingo(dia As Integer)
        For i = 0 To vHoras.Count - 1
            vDias(i, dia) = New ClsHora(Color.Red, 0, 0, -2)
        Next
    End Sub

    Private Sub _prCargarDiaSabado(dia As Integer)
        For i = 0 To vHoras.Count - 1
            vDias(i, dia) = New ClsHora(Color.Yellow, 0, 0, -1)
        Next
    End Sub

    Private Sub _prCargarFeriados()
        Dim dtFeriados As DataTable = L_prFeriadoGeneralPorFecha(vFecha.ToString("yyyy-MM-dd"))
        For Each fila As DataRow In dtFeriados.Rows
            Dim fFeriado As Date = fila.Item("pfflib")
            Dim desc As String = fila.Item("pfdes")
            _prCargarDiaFeriado(fFeriado.Day - 1, desc)
        Next
    End Sub
    Private Sub _prCargarCumpleanosInstructor(numiInst As String)
        Dim dtInstructor As DataTable = L_prPersonaBuscarNumiGeneral2(numiInst)
        Dim fecha As Date = dtInstructor.Rows(0).Item("pafnac")
        If fecha.Month = vFecha.Month Then
            For i = 0 To vHoras.Count - 1
                'vDias(i, dia) = New ClsHora(Color.Silver, 0, 0, -2, desc)
                vDias(i, fecha.Day - 1) = New ClsHora(Color.GreenYellow, 0, 0, conCumple, "cumpleaño".ToUpper)
            Next
        End If

    End Sub

    Private Sub _prCargarDiaFeriado(dia As Integer, desc As String)
        For i = 0 To vHoras.Count - 1
            'vDias(i, dia) = New ClsHora(Color.Silver, 0, 0, -2, desc)
            vDias(i, dia) = New ClsHora(Color.Gray, 0, 0, -2, desc)
        Next
    End Sub

    Public Sub _prCargarDiasDeAlumnos(numiInstruc As String, numiAlum As String, c As Color)
        'Dim dtFechas As DataTable = L_prClasesPracDetFechasPorAlumnoGeneral(numiInstruc, numiAlum)
        Dim dtFechasAnt As DataTable = L_prClasesPracDetFechasPorAlumnoYFechaGeneralContables(numiInstruc, numiAlum, DateAdd(DateInterval.Month, -1, vFecha).ToString("yyyy/MM/dd"))

        Dim dtFechas As DataTable = L_prClasesPracDetFechasPorAlumnoYFechaGeneral(numiInstruc, numiAlum, vFecha.ToString("yyyy/MM/dd"))

        Dim num As Integer
        If dtFechasAnt.Rows.Count = 0 Then
            num = 1
        Else
            num = dtFechasAnt.Rows.Count + 1
        End If

        Dim dtFechasAntDeOtroInstructor As DataTable = L_prClasesPracDetFechasPorAlumnoYFechaGeneralContablesMenorAUnaFechaYHoraX(numiInstruc, numiAlum, CType(dtFechas.Rows(0).Item("ehfec"), Date).ToString("yyyy/MM/dd")) ', dtFechas.Rows(0).Item("ehhor")
        num = num + dtFechasAntDeOtroInstructor.Rows.Count
        For Each fila As DataRow In dtFechas.Rows
            Dim fecha As Date = fila.Item("ehfec")
            Dim hora As String = fila.Item("ehhor")
            Dim line As Integer = fila.Item("ehlin")
            Dim est As Integer = fila.Item("ehest")
            Dim obs As String = fila.Item("ehobs")
            Dim f As Integer = vHoras.IndexOf(hora)

            If fecha.Month = vFecha.Month Then
                Dim claseAnt As ClsHora = vDias(f, fecha.Day - 1)
                Dim b As Boolean = False
                If Not IsNothing(claseAnt) Then
                    If claseAnt.estado = conDiaGrabadoAlumno Then
                        b = True
                    End If

                End If

                If est = conEstClaseProgramada Or est = conEstClaseAsistida Then 'clase programada y asistencia
                    vDias(f, fecha.Day - 1) = New ClsHora(c, numiAlum, num, 1, obs, line, est)
                    vDias(f, fecha.Day - 1).claseSobrepuesta = b
                    num = num + 1
                End If
                If est = conEstClasePermiso Or est = conEstClaseSuspension Then 'clase con permiso
                    If b = False Then 'pregunto si es no ya hay una clase grabada con estado de programado o asistido en la hora para poner le permiso o ignorarlo
                        vDias(f, fecha.Day - 1) = New ClsHora(Color.LightGray, numiAlum, num, 1, obs, line, est)
                    End If
                    vDias(f, fecha.Day - 1).claseSobrepuesta = b
                End If

                If est = conEstClaseFalta Then 'clase con falta o suspension
                    vDias(f, fecha.Day - 1) = New ClsHora(Color.Red, numiAlum, num, 1, obs, line, est)
                    vDias(f, fecha.Day - 1).claseSobrepuesta = b
                    num = num + 1
                End If

                'verifico si es que hay 2 clases programadas en ese mismo dia,mas que todo un permiso y una clase programada
                'If IsNothing(claseAnt) Then
                '    If claseAnt.estadoCls = 2 Then
                '        Dim ii As Integer = 0
                '    End If

                'End If


            End If
        Next
    End Sub

    Public Sub _prCargarDiasDeAlumnos2(numiInstruc As String, numiAlum As String, c As Color, dtFechasTotales As DataTable, dtFechasAntTotales As DataTable)
        'Dim dtFechas As DataTable = L_prClasesPracDetFechasPorAlumnoGeneral(numiInstruc, numiAlum)
        ''Dim dtFechasAnt As DataTable = L_prClasesPracDetFechasPorAlumnoYFechaGeneralContables(numiInstruc, numiAlum, DateAdd(DateInterval.Month, -1, vFecha).ToString("yyyy/MM/dd"))
        Dim dtFechasAnt As DataTable = dtFechasAntTotales.Copy
        dtFechasAnt.Rows.Clear()
        Dim filasFiltradasFechasAnte As DataRow() = dtFechasAntTotales.Select("egalum=" + numiAlum)
        If filasFiltradasFechasAnte.Count > 0 Then
            dtFechasAnt = filasFiltradasFechasAnte.CopyToDataTable
        End If

        Dim dtFechas As DataTable = dtFechasTotales.Copy()
        dtFechas.Rows.Clear()
        Dim filasFiltradas As DataRow() = dtFechasTotales.Select("egalum=" + numiAlum)
        If filasFiltradas.Count > 0 Then
            dtFechas = filasFiltradas.CopyToDataTable
        End If

        ''dtFechas = L_prClasesPracDetFechasPorAlumnoYFechaGeneral(numiInstruc, numiAlum, vFecha.ToString("yyyy/MM/dd"))

        Dim num As Integer
        If dtFechasAnt.Rows.Count = 0 Then
            num = 1
        Else
            num = dtFechasAnt.Rows.Count + 1
        End If

        Dim dtFechasAntDeOtroInstructor As DataTable = L_prClasesPracDetFechasPorAlumnoYFechaGeneralContablesMenorAUnaFechaYHoraX(numiInstruc, numiAlum, CType(dtFechas.Rows(0).Item("ehfec"), Date).ToString("yyyy/MM/dd")) ', dtFechas.Rows(0).Item("ehhor")
        num = num + dtFechasAntDeOtroInstructor.Rows.Count
        For Each fila As DataRow In dtFechas.Rows
            Dim fecha As Date = fila.Item("ehfec")
            Dim hora As String = fila.Item("ehhor")
            Dim line As Integer = fila.Item("ehlin")
            Dim est As Integer = fila.Item("ehest")
            Dim obs As String = fila.Item("ehobs")
            Dim f As Integer = vHoras.IndexOf(hora)

            If fecha.Month = vFecha.Month Then
                Dim claseAnt As ClsHora = vDias(f, fecha.Day - 1)
                Dim b As Boolean = False
                If Not IsNothing(claseAnt) Then
                    If claseAnt.estado = conDiaGrabadoAlumno Then
                        b = True
                    End If

                End If

                If est = conEstClaseProgramada Or est = conEstClaseAsistida Then 'clase programada y asistencia
                    vDias(f, fecha.Day - 1) = New ClsHora(c, numiAlum, num, 1, obs, line, est)
                    vDias(f, fecha.Day - 1).claseSobrepuesta = b
                    num = num + 1
                End If
                If est = conEstClasePermiso Or est = conEstClaseSuspension Then 'clase con permiso
                    If b = False Then 'pregunto si es no ya hay una clase grabada con estado de programado o asistido en la hora para poner le permiso o ignorarlo
                        vDias(f, fecha.Day - 1) = New ClsHora(Color.LightGray, numiAlum, num, 1, obs, line, est)
                    End If
                    vDias(f, fecha.Day - 1).claseSobrepuesta = b
                End If

                If est = conEstClaseFalta Then 'clase con falta o suspension
                    vDias(f, fecha.Day - 1) = New ClsHora(Color.Red, numiAlum, num, 1, obs, line, est)
                    vDias(f, fecha.Day - 1).claseSobrepuesta = b
                    num = num + 1
                End If

                'verifico si es que hay 2 clases programadas en ese mismo dia,mas que todo un permiso y una clase programada
                'If IsNothing(claseAnt) Then
                '    If claseAnt.estadoCls = 2 Then
                '        Dim ii As Integer = 0
                '    End If

                'End If


            End If
        Next
    End Sub

    Public Sub _prCargarNuevaFecha(f As Integer, c As Integer, _color As Color, numiAlum As String, numClase As String, estado As String)
        vDias(f, c) = New ClsHora(_color, numiAlum, numClase, estado)
    End Sub
End Class
