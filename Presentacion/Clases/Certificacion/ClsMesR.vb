Imports Logica.AccesoLogica
Public Class ClsMesR
    Public vDias As ClsHoraR(,)
    Public vHoras As List(Of String)
    Public vUltDia As Integer
    Public vFecha As Date

    'estados 
    '-2=feriado
    '-1=dia sabado
    '0=dia marcado
    '1=dia ya grabado del alumno
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
        vDias = New ClsHoraR(50, 50) {}

        vFecha = fecha1

        'cargo las horas en la lista de horas
        Dim dtHoras As DataTable = L_prHoraDetDelMesGeneral(vFecha.ToString("yyyy/MM/dd"), numiSuc, gi_LibHORARIOTipoReforCertificacion)
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
        Dim numiAlum As String
        For i = 0 To dtAlumnos.Rows.Count - 1
            numiAlum = dtAlumnos.Rows(i).Item("cbnumi")

            _prCargarDiasDeAlumnos(numiInstr.ToString, numiAlum.ToString, Color.FromArgb(dtAlumnos.Rows(i).Item("color")))
        Next

        _prCargarHorasLiberadas(numiInstr)
    End Sub

    Public Sub New(fecha1 As Date, numiSuc As String)
        vDias = New ClsHoraR(50, 50) {}

        vFecha = fecha1

        'cargo las horas en la lista de horas
        Dim dtHoras As DataTable = L_prHoraDetDelMesGeneral(vFecha.ToString("yyyy/MM/dd"), numiSuc, gi_LibHORARIOTipoReforCertificacion)
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
        Dim dtHorasLiberadas As DataTable = L_prHoraLibreTCE0062GetPorFechaInstructorR(vFecha.ToString("yyyy/MM/dd"), numiInstr)

        For Each fila As DataRow In dtHorasLiberadas.Rows
            Dim hora As String = fila.Item("errhor")
            Dim fecha As Date = fila.Item("errfec")
            Dim obs As String = fila.Item("errobs")
            Dim f As Integer = vHoras.IndexOf(hora)
            vDias(f, fecha.Day - 1) = New ClsHoraR(Color.Black, 0, 0, conHoraLiberada, obs)
        Next
    End Sub
    Public Sub _prCargarFinSemana()
        Dim fecha As Date = vFecha
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
            vDias(i, dia) = New ClsHoraR(Color.Red, 0, 0, -2)
        Next
    End Sub

    Private Sub _prCargarDiaSabado(dia As Integer)
        For i = 0 To vHoras.Count - 1
            vDias(i, dia) = New ClsHoraR(Color.Yellow, 0, 0, -1)
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
                'vDias(i, dia) = New ClsHoraR(Color.Silver, 0, 0, -2, desc)
                vDias(i, fecha.Day - 1) = New ClsHoraR(Color.GreenYellow, 0, 0, conCumple, "cumpleaño".ToUpper)
            Next
        End If

    End Sub

    Private Sub _prCargarDiaFeriado(dia As Integer, desc As String)
        For i = 0 To vHoras.Count - 1
            'vDias(i, dia) = New ClsHoraR(Color.Silver, 0, 0, -2, desc)
            vDias(i, dia) = New ClsHoraR(Color.Gray, 0, 0, -2, desc)
        Next
    End Sub

    Public Sub _prCargarDiasDeAlumnos(numiInstruc As String, numiAlum As String, c As Color)
        'Dim dtFechas As DataTable = L_prClasesPracDetFechasPorAlumnoGeneral(numiInstruc, numiAlum)
        Dim dtFechasAnt As DataTable = L_prClasesPracDetFechasPorAlumnoYFechaGeneralContablesR(numiInstruc, numiAlum, DateAdd(DateInterval.Month, -1, vFecha).ToString("yyyy/MM/dd"))

        Dim dtFechas As DataTable = L_prClasesPracDetFechasPorAlumnoYFechaGeneralR(numiInstruc, numiAlum, vFecha.ToString("yyyy/MM/dd"))

        Dim num As Integer
        If dtFechasAnt.Rows.Count = 0 Then
            num = 1
        Else
            num = dtFechasAnt.Rows.Count + 1
        End If


        For Each fila As DataRow In dtFechas.Rows
            Dim fecha As Date = fila.Item("erfec")
            Dim hora As String = fila.Item("erhor")
            Dim line As Integer = fila.Item("erlin")
            Dim est As Integer = fila.Item("erest")
            Dim obs As String = fila.Item("erobs")
            Dim tipoClase As String = fila.Item("ertser2")
            Dim f As Integer = vHoras.IndexOf(hora)

            If fecha.Month = vFecha.Month Then
                Dim claseAnt As ClsHoraR = vDias(f, fecha.Day - 1)
                Dim b As Boolean = False
                If Not IsNothing(claseAnt) Then
                    If claseAnt.estado = conDiaGrabadoAlumno Then
                        b = True
                    End If

                End If

                If est = conEstClaseProgramada Or est = conEstClaseAsistida Then 'clase programada y asistencia
                    vDias(f, fecha.Day - 1) = New ClsHoraR(c, numiAlum, num, conDiaGrabadoAlumno, obs, line, est)
                    vDias(f, fecha.Day - 1).claseSobrepuesta = b
                    vDias(f, fecha.Day - 1).tipoClase = tipoClase.Substring(0, 2)
                    num = num + 1
                End If
                If est = conEstClasePermiso Or est = conEstClaseSuspension Then 'clase con permiso
                    vDias(f, fecha.Day - 1) = New ClsHoraR(Color.LightGray, numiAlum, num, conDiaGrabadoAlumno, obs, line, est)
                    vDias(f, fecha.Day - 1).claseSobrepuesta = b
                    vDias(f, fecha.Day - 1).tipoClase = tipoClase.Substring(0, 2)
                End If

                If est = conEstClaseFalta Then 'clase con falta o suspension
                    vDias(f, fecha.Day - 1) = New ClsHoraR(Color.Red, numiAlum, num, conDiaGrabadoAlumno, obs, line, est)
                    vDias(f, fecha.Day - 1).claseSobrepuesta = b
                    vDias(f, fecha.Day - 1).tipoClase = tipoClase.Substring(0, 2)
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
        vDias(f, c) = New ClsHoraR(_color, numiAlum, numClase, estado)
    End Sub
End Class
