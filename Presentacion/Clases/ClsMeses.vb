Imports Logica.AccesoLogica
Public Class ClsMeses
    Public vmes1 As ClsMes
    Public vmes2 As ClsMes

    Public vmesAct As Date
    Public vDtAlumnos As DataTable
    Public vNumiInstruc As String


    Public Sub New(mesAct1 As Date, nInst As String, dtalum As DataTable, dtAlum2 As DataTable, numiSuc As String)
        vmesAct = mesAct1
        vNumiInstruc = nInst
        vDtAlumnos = dtalum

        'cargar los 2 meses
        vmes1 = New ClsMes(vmesAct, vNumiInstruc, vDtAlumnos, numiSuc)

        'aumente la cuestion de volver a preguntar los alumnos para este mes,ya que mandaba del anterior mes
        'Dim dt As New DataTable
        'dt = L_prAlumnoAyudaColor(numiSuc, vNumiInstruc, DateAdd(DateInterval.Month, 1, vmesAct).ToString("yyyy/MM/dd")) 'gi_userSuc
        'vmes2 = New ClsMes(DateAdd(DateInterval.Month, 1, vmesAct), vNumiInstruc, dt, numiSuc) 'vmes2 = New ClsMes(DateAdd(DateInterval.Month, 1, vmesAct), vNumiInstruc, vDtAlumnos, numiSuc)
        vmes2 = New ClsMes(DateAdd(DateInterval.Month, 1, vmesAct), vNumiInstruc, dtAlum2, numiSuc)

    End Sub

    Public Sub New(mesAct1 As Date, numiSuc As String)
        vmesAct = mesAct1

        'cargar los 2 meses
        vmes1 = New ClsMes(vmesAct, numiSuc)
        vmes2 = New ClsMes(DateAdd(DateInterval.Month, 1, vmesAct), numiSuc)

    End Sub

    Public Sub _prCargarDiaMes1(f As Integer, c As Integer, _color As Color, numiAlum As String, numClase As Integer, estado As Integer)
        vmes1._prCargarNuevaFecha(f, c, _color, numiAlum, numClase, estado)
    End Sub

    Public Sub _prCargarDiaMes2(f As Integer, c As Integer, _color As Color, numiAlum As String, numClase As Integer, estado As Integer)
        vmes2._prCargarNuevaFecha(f, c, _color, numiAlum, numClase, estado)
    End Sub
End Class
