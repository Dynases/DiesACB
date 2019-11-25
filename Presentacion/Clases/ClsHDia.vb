Public Class ClsHDia

    Public estado As Integer
    Public numiCabecera As Integer
    Public numiCli As Integer
    Public numiCabana As Integer
    Public obs As String
    Public estHora As Integer
    Public cColor As Color


    Public Sub New(estado1 As Integer, numiCabecera1 As Integer, numiCli1 As Integer, numiCabana1 As Integer, obs1 As String, estHora1 As Integer, cColor1 As Color)

        numiCabecera = numiCabecera1
        numiCli = numiCli1
        numiCabana = numiCabana1
        obs = obs1
        estHora = estHora1
        cColor = cColor1
        estado = estado1
    End Sub


End Class
