Imports Logica.AccesoLogica
Imports DevComponents.DotNetBar
Imports System.Data.OleDb
Public Class Pr_ServiciosLavadero

    Public Sub _prIniciarTodo()

        _PMIniciarTodo()
        Me.Text = "REPORTE DE SERVICIOS"
        _prCargarComboLibreria(cbTipoCliente, 14, 4)
        _prCargarComboLibreria(cbModulo, 6, 1)

    End Sub
    Private Sub _prCargarReporte()
        Dim _dt As New DataTable
        _prInterpretarDatos(_dt)
        If (_dt.Rows.Count > 0) Then

            Dim objrep As New R_Servicios
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
    Public Sub _prInterpretarDatos(ByRef _dt As DataTable)
        If (CheckTodosModulo.Checked And checkTodosTipoCliente.Checked) Then

            _dt = L_prServiciostodosModulostodosClientes()

        End If

        If (checkUnaModulo.Checked And checkTodosTipoCliente.Checked) Then
            _dt = L_prServiciosUnModulostodosClientes(cbModulo.Value)
        End If

        If (CheckTodosModulo.Checked And checkUnaTipoCliente.Checked) Then
            _dt = L_prServiciosTodosModuloUnClientes(cbTipoCliente.Value)

        End If
        If (checkUnaModulo.Checked And checkUnaTipoCliente.Checked) Then
            _dt = L_prServiciosUnModuloUnClientes(cbModulo.Value, cbTipoCliente.Value)

        End If
    End Sub
    Sub _prInhabilitarModulo()
        cbModulo.Enabled = False
    End Sub
    Sub _prhabilitarModulo()
        cbModulo.Enabled = True
    End Sub

    Sub _prInhabilitarTipoCliente()
        cbTipoCliente.Enabled = False
    End Sub
    Sub _prhabilitarTipoCliente()
        cbTipoCliente.Enabled = True
    End Sub

    Private Sub CheckTodosAlmacen_CheckValueChanged(sender As Object, e As EventArgs) Handles CheckTodosModulo.CheckValueChanged
        If (CheckTodosModulo.Checked) Then
            _prInhabilitarModulo()
        Else
            _prhabilitarModulo()
        End If
    End Sub

    Private Sub checkTodosGrupos_CheckValueChanged(sender As Object, e As EventArgs) Handles checkTodosTipoCliente.CheckValueChanged
        If (checkTodosTipoCliente.Checked) Then
            _prInhabilitarTipoCliente()
        Else
            _prhabilitarTipoCliente()
        End If
    End Sub

    Private Sub Pr_ServiciosLavadero_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _prIniciarTodo()
    End Sub

    Private Sub btnGenerar_Click(sender As Object, e As EventArgs) Handles btnGenerar.Click
        _prCargarReporte()

    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()

    End Sub
End Class