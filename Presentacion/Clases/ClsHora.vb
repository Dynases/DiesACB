Public Class ClsHora
    Public ccolor As Color
    Public line As Integer
    Public numiAlm As Integer
    Public numCla As Integer
    Public estado As Integer
    Public desc As String
    Public estadoCls As Integer
    Public claseSobrepuesta As Boolean


    Public Sub New(c1 As Color, na As Integer, numc As Integer, est As Integer, Optional desc1 As String = "", Optional line1 As Integer = 0, Optional estC As Integer = 0)
        line = line1
        ccolor = c1
        numiAlm = na
        numCla = numc
        estado = est
        desc = desc1
        estadoCls = estC
    End Sub


End Class
