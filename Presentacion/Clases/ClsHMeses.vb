Imports Logica.AccesoLogica
Public Class ClsHMeses
    Public vDias1 As ClsHDia(,)
    Public vDias2 As ClsHDia(,)

    Public vUltDia1 As Integer
    Public vUltDia2 As Integer
    Public vFecha1 As Date
    Public vFecha2 As Date

    Public vdtCabanas As DataTable

    'estados 
    '-2=dia Domingo
    '-1=dia sabado
    '0=dia marcado
    '1=dia ya grabado del Cliente
    Const conHoraLiberada As Integer = -4
    Const conDomingo As Integer = -2
    Const conSabado As Integer = -1
    Const conMarcado As Integer = 0
    Const conDiaGrabadoCliente As Integer = 1

    'Const conEstResRealizada As Integer = 1
    'Const conEstResOcupada As Integer = 2
    'Const conEstResSinOcupar As Integer = 3
    'Const conEstResCancelada As Integer = 4
    Const conEstResRealizada As Integer = 1
    Const conEstResConfirmadaPagada As Integer = 2
    Const conEstResPagadaCancelada As Integer = 3 'Const conEstResSinOcupar As Integer = 3
    Const conEstResReasignada As Integer = 4


    Public Sub New(fecha As Date, dtCabanas1 As DataTable, dtReservas As DataTable, dtReservas2 As DataTable)
        vdtCabanas = dtCabanas1

        vDias1 = New ClsHDia(50, 50) {}
        vDias2 = New ClsHDia(50, 50) {}

        vFecha1 = fecha
        vFecha2 = DateAdd(DateInterval.Month, 1, fecha)

        'poner ultimo dia del mes
        vUltDia1 = DateSerial(Year(vFecha1), Month(vFecha1) + 1, 0).Day
        vUltDia2 = DateSerial(Year(vFecha2), Month(vFecha2) + 1, 0).Day

        'cargar los fines de semana
        _prCargarFinSemana(vFecha1, vUltDia1, vDias1)
        _prCargarFinSemana(vFecha2, vUltDia2, vDias2)

        'cargar las dias liberados
        _prCargarHorasLiberadas(vFecha1.ToString("yyyy/MM/dd"), vDias1)
        _prCargarHorasLiberadas(vFecha2.ToString("yyyy/MM/dd"), vDias2)

        'cargar fechas de las cabañas
        'cargar los datos de la grilla
        Dim numiReg, numiCli, numiCab, est As Integer
        Dim fIng, fSal As Date
        Dim obs As String
        For Each fila As DataRow In dtReservas.Rows

            numiReg = fila.Item("hdnumi")
            numiCli = fila.Item("hdtc1cli")
            fIng = fila.Item("hdfcin")
            fSal = fila.Item("hdfcou")
            numiCab = fila.Item("hdtc2cab")
            obs = fila.Item("hdobs")
            est = fila.Item("hdest")
            Dim miColor As Color
            Select Case est
                Case 1
                    miColor = Color.Yellow
                Case 2
                    miColor = Color.Green
                Case 3
                    miColor = Color.Orange
                Case 4
                    miColor = Color.Yellow
            End Select
            Dim n As Integer = DateDiff(DateInterval.Day, fIng, fSal)
            Dim fec As Date = fIng
            Dim f As Integer = _prBuscarnNroFilaDeCabana(numiCab)
            For i = 1 To n + 1
                If fec.Year = vFecha1.Year And fec.Month = vFecha1.Month Then
                    vDias1(f, fec.Day - 1) = New ClsHDia(conDiaGrabadoCliente, numiReg, numiCli, numiCab, obs, est, miColor) 'Color.FromArgb(fila.Item("color"))
                Else
                    vDias2(f, fec.Day - 1) = New ClsHDia(conDiaGrabadoCliente, numiReg, numiCli, numiCab, obs, est, miColor) 'Color.FromArgb(fila.Item("color"))
                End If
                fec = DateAdd(DateInterval.Day, 1, fec)
            Next
        Next

        'cargos los dias del segundo mes
        For Each fila As DataRow In dtReservas2.Rows

            numiReg = fila.Item("hdnumi")
            numiCli = fila.Item("hdtc1cli")
            fIng = fila.Item("hdfcin")
            fSal = fila.Item("hdfcou")
            numiCab = fila.Item("hdtc2cab")
            obs = fila.Item("hdobs")
            est = fila.Item("hdest")

            Dim miColor As Color
            Select Case est
                Case 1
                    miColor = Color.Yellow
                Case 2
                    miColor = Color.Green
                Case 3
                    miColor = Color.Orange
                Case Else
                    miColor = Color.Yellow
            End Select

            Dim n As Integer = DateDiff(DateInterval.Day, fIng, fSal)
            Dim fec As Date = fIng
            Dim f As Integer = _prBuscarnNroFilaDeCabana(numiCab)
            For i = 1 To n + 1
                If fec.Year = vFecha1.Year And fec.Month = vFecha1.Month Then
                    'vDias1(f, fec.Day - 1) = New ClsHDia(conDiaGrabadoCliente, numiReg, numiCli, numiCab, obs, est, Color.FromArgb(fila.Item("color")))
                Else
                    vDias2(f, fec.Day - 1) = New ClsHDia(conDiaGrabadoCliente, numiReg, numiCli, numiCab, obs, est, miColor) 'Color.FromArgb(fila.Item("color"))
                End If
                fec = DateAdd(DateInterval.Day, 1, fec)
            Next
        Next


    End Sub
    Private Function _prBuscarnNroFilaDeCabana(numiCabana As Integer) As Integer
        Dim i As Integer = 0
        For i = 0 To vdtCabanas.Rows.Count - 1
            If vdtCabanas.Rows(i).Item("hbnumi") = numiCabana Then
                Return i
            End If
        Next
        Return i
    End Function

    Public Sub _prCargarFinSemana(fecha As Date, ultDia As Integer, dias As ClsHDia(,))

        For i = 1 To ultDia
            If fecha.DayOfWeek = DayOfWeek.Sunday Then
                _prCargarDiaDomingo(fecha.Day - 1, dias)
            End If
            If fecha.DayOfWeek = DayOfWeek.Saturday Then
                _prCargarDiaSabado(fecha.Day - 1, dias)
            End If
            fecha = fecha.AddDays(1)
        Next
    End Sub
    Private Sub _prCargarDiaDomingo(dia As Integer, dias As ClsHDia(,))
        For i = 0 To vdtCabanas.Rows.Count - 1
            dias(i, dia) = New ClsHDia(conDomingo, 0, 0, 0, "", 0, Color.Red)
        Next
    End Sub

    Private Sub _prCargarDiaSabado(dia As Integer, dias As ClsHDia(,))
        For i = 0 To vdtCabanas.Rows.Count - 1
            dias(i, dia) = New ClsHDia(conDomingo, 0, 0, 0, "", 0, Color.LightBlue)
        Next
    End Sub

    Private Sub _prCargarHorasLiberadas(fecha As Date, dias As ClsHDia(,))
        Dim dtHorasLiberadas As DataTable = L_prHoraLibreTCH0033GetPorFecha(fecha.ToString("yyyy/MM/dd"))

        For Each fila As DataRow In dtHorasLiberadas.Rows
            Dim fecha1 As Date = fila.Item("eggfec")
            Dim obs As String = fila.Item("eggobs")
            Dim numiCab As String = fila.Item("eggcab")

            Dim f As Integer = _prBuscarnNroFilaDeCabana(numiCab)

            dias(f, fecha1.Day - 1) = New ClsHDia(conHoraLiberada, 0, 0, 0, obs, 0, Color.Black)
        Next
    End Sub

    Public Sub _prCargarDiaLiberadoMes1(f As Integer, c As Integer)
        vDias1(f, c) = New ClsHDia(conHoraLiberada, 0, 0, 0, "", 0, Color.Black)
    End Sub
End Class
