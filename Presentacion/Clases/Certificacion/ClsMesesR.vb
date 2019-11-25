Public Class ClsMesesR
    Public vmes1 As ClsMesR
    Public vmes2 As ClsMesR

    Public vmesAct As Date
    Public vDtAlumnos As DataTable
    Public vNumiInstruc As String


    Public Sub New(mesAct1 As Date, nInst As String, dtalum As DataTable, numiSuc As String)
        vmesAct = mesAct1
        vNumiInstruc = nInst
        vDtAlumnos = dtalum

        'cargar los 2 meses
        vmes1 = New ClsMesR(vmesAct, vNumiInstruc, vDtAlumnos, numiSuc)
        vmes2 = New ClsMesR(DateAdd(DateInterval.Month, 1, vmesAct), vNumiInstruc, vDtAlumnos, numiSuc)

    End Sub

    Public Sub New(mesAct1 As Date, numiSuc As String)
        vmesAct = mesAct1

        'cargar los 2 meses
        vmes1 = New ClsMesR(vmesAct, numiSuc)
        vmes2 = New ClsMesR(DateAdd(DateInterval.Month, 1, vmesAct), numiSuc)

    End Sub

    Public Sub _prCargarDiaMes1(f As Integer, c As Integer, _color As Color, numiAlum As String, numClase As Integer, estado As Integer)
        vmes1._prCargarNuevaFecha(f, c, _color, numiAlum, numClase, estado)
    End Sub

    Public Sub _prCargarDiaMes2(f As Integer, c As Integer, _color As Color, numiAlum As String, numClase As Integer, estado As Integer)
        vmes2._prCargarNuevaFecha(f, c, _color, numiAlum, numClase, estado)
    End Sub
End Class
