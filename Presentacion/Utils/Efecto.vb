
Imports System.ComponentModel
Imports System.Text
Imports DevComponents.DotNetBar
Public Class Efecto
    Public _archivo As String
    Public band As Boolean = False
    Public Header As String = ""
    Public tipo As Integer = 0
    Public Context As String = ""
    Public listEstCeldas As List(Of Modelos.Celda)
    Public dt As DataTable
    Public alto As Integer
    Public ancho As Integer
    Public Row As Janus.Windows.GridEX.GridEXRow
    Public SeleclCol As Integer = -1
    Public PosicionData As Integer




    Private Sub Efecto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        If (tipo = 1) Then
            _prMostrarTamanoVehiculo()
        Else
            _prMostrarTipoVehiculo()
        End If

    End Sub
    Public Sub _prMostrarTipoVehiculo()
        Dim frmAyuda As F0_TipoVehiculo = New F0_TipoVehiculo
        frmAyuda.ShowDialog()
        PosicionData = frmAyuda.PosicionData
        Me.Close()


    End Sub
    Public Sub _prMostrarTamanoVehiculo()
        Dim frmAyuda As F0_TamanoVehiculo = New F0_TamanoVehiculo
        frmAyuda.ShowDialog()
        PosicionData = frmAyuda.PosicionData
        Me.Close()


    End Sub
    
   
End Class