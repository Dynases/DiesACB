
Imports System.ComponentModel
Imports System.Text
Imports DevComponents.DotNetBar
Public Class EfectoAyuda
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

    'Socio
    Public codigo As Integer
    Public nombre As String






    Private Sub Efecto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized

        Select Case tipo
            Case 1
                _prMostrarMensaje()
            Case 2
                _prMostrarMensajeDelete()
            Case 3
                _prMostrarFormAyuda()
            Case 4
                _prMostraVisualizador()
            Case 5
                _prMostrarFormAyudaPersonalizado()

        End Select
    End Sub

    Sub _prMostrarFormAyuda()

        Dim frmAyuda As Modelos.ModeloAyuda
        frmAyuda = New Modelos.ModeloAyuda(alto, ancho, dt, Context.ToUpper, listEstCeldas)

        frmAyuda.ShowDialog()
        If frmAyuda.seleccionado = True Then
            Row = frmAyuda.filaSelect
            band = True
            Me.Close()
        Else
            band = False
            Me.Close()
        End If

    End Sub
    Sub _prMostrarFormAyudaPersonalizado()

        Dim frmAyuda As Frm_AyudaP
        frmAyuda = New Frm_AyudaP(alto, ancho, dt, Context.ToUpper, listEstCeldas)

        frmAyuda.ShowDialog()
        If frmAyuda.seleccionado = True Then
            Row = frmAyuda.filaSelect
            band = True
            Me.Close()
        Else
            band = False
            Me.Close()
        End If

    End Sub
    Sub _prMostrarMensaje()
        Dim blah As Bitmap = My.Resources.Mensaje
        Dim ico As Icon = Icon.FromHandle(blah.GetHicon())

        If (MessageBox.Show(Context, Header, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes) Then
            'Process.Start(_archivo)
            band = True
            Me.Close()
        Else
            band = False
            Me.Close()


        End If
    End Sub
    Sub _prMostrarMensajeDelete()

        Dim info As New TaskDialogInfo(Context, eTaskDialogIcon.Delete, "advertencia".ToUpper, Header, eTaskDialogButton.Yes Or eTaskDialogButton.Cancel, eTaskDialogBackgroundColor.Default)
        Dim result As eTaskDialogResult = TaskDialog.Show(info)
        If result = eTaskDialogResult.Yes Then
            Dim mensajeError As String = ""
            band = True
            Me.Close()

        Else
            band = False
            Me.Close()

        End If
    End Sub

    Private Sub _prMostraVisualizador()
        Dim frmAyuda As New F_SocioVehiculo
        frmAyuda.codigoSocio = codigo
        frmAyuda.nombreSocio = nombre

        frmAyuda.StartPosition = FormStartPosition.CenterScreen
        frmAyuda.ShowDialog()
        Me.Close()
    End Sub

End Class