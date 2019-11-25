
Imports Logica.AccesoLogica
Imports DevComponents.DotNetBar

Imports Janus.Windows.GridEX

Imports System.IO
Imports DevComponents.DotNetBar.SuperGrid
Imports Presentacion.F_ClienteNuevoServicio
Public Class Pr_HistorialSevLav
#Region "Variables Globales"
    Dim NumiClie As Integer
    Dim Ci As String
    Dim Nsoc As Integer
    Dim Nombre As String
    Dim numiVehiculo As String

#End Region
#Region "Metodos Privados"
    Private Sub _prIniciarTodo()
        _PMIniciarTodo()
        'L_prAbrirConexion(gs_Ip, gs_UsuarioSql, gs_ClaveSql, gs_NombreBD)
        Me.Text = "R E P O R T E  H I S T O R I A L   S E R V I C I O S  L A V A D E R O"
        MReportViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        cargarFocusTextbox()
        tbFiltrarCliente.Value = True
        tbcliente.Focus()

    End Sub
    Public Sub cargarFocusTextbox()

        With MHighlighterFocus
            .SetHighlightOnFocus(tbPlaca, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
            .SetHighlightOnFocus(tbcliente, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
        End With
    End Sub

    Private Sub _prCargarReporte()
        Dim _dt As New DataTable
        If (tbFiltrarCliente.Value = True) Then

            _dt = L_prReporteHistorialServicios(tbFechaI.Value.ToString("yyyy/MM/dd"), tbFechaF.Value.ToString("yyyy/MM/dd"), NumiClie)
        Else
            _dt = L_prReporteHistorialServiciosPorPlaca(tbFechaI.Value.ToString("yyyy/MM/dd"), tbFechaF.Value.ToString("yyyy/MM/dd"), numiVehiculo)
        End If

        If (_dt.Rows.Count > 0) Then
            Dim fecha As String = tbFechaI.Value.Date.ToString("dd/MM/yyyy") + " Al " + tbFechaF.Value.Date.ToString("dd/MM/yyyy")
            Dim objrep As New R_ServLavaderoClienteFecha
            objrep.SetDataSource(_dt)
            objrep.SetParameterValue("RangoFecha", fecha)
            objrep.SetParameterValue("nombre", Nombre.ToString.ToUpper)
            objrep.SetParameterValue("ci", Ci.ToString.ToUpper)
            objrep.SetParameterValue("nsoc", Nsoc)
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
        tbcliente.Focus()

    End Sub

#End Region
#Region "Eventos Formulario"
    Private Sub Pr_LavaderoGeneralServicios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _prIniciarTodo()
    End Sub
    Private Sub btnGenerar_Click(sender As Object, e As EventArgs) Handles btnGenerar.Click
        If (Not tbcliente.Text = String.Empty) Then

            _prCargarReporte()
        Else
            ToastNotification.Show(Me, "Seleccione un Cliente Por favor..!!!",
                                      My.Resources.INFORMATION, 2000,
                                      eToastGlowColor.Blue,
                                      eToastPosition.BottomLeft)
            MReportViewer.ReportSource = Nothing
        End If


    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub TextBoxX1_KeyDown(sender As Object, e As KeyEventArgs) Handles tbcliente.KeyDown
        If e.KeyData = Keys.Control + Keys.Enter Then

            'grabar horario
            Dim frmAyuda As Modelos.ModeloAyuda
            Dim dt As DataTable
            '          b.lblin,a.lanumi ,b.lbplac,marca.cedesc1 as marca,modelo .cedesc1  as modelo
            '      ,Concat(a.lanom,' ',a.laapat ,' ',a.laamat  )as nombre,a.lafot ,b.lbtip1_4 ,a.lansoc,
            'Isnull((select top 1 e.ldnumi  from TCL002 as e where e.ldtcl11veh=lblin  ),0)as VehiculoRegistrado,a.laci 


            dt = L_prServicioVehiculoCliente()
            Dim listEstCeldas As New List(Of Modelos.Celda)
            listEstCeldas.Add(New Modelos.Celda("lblin", False))
            listEstCeldas.Add(New Modelos.Celda("lanumi", False))
            listEstCeldas.Add(New Modelos.Celda("lbplac", True, "PLACA", 120))
            listEstCeldas.Add(New Modelos.Celda("marca", True, "MARCA", 150))
            listEstCeldas.Add(New Modelos.Celda("modelo", True, "MODELO", 150))
            listEstCeldas.Add(New Modelos.Celda("nombre", True, "NOMBRE", 200))
            listEstCeldas.Add(New Modelos.Celda("lafot", False))
            listEstCeldas.Add(New Modelos.Celda("lbtip1_4", False))
            listEstCeldas.Add(New Modelos.Celda("lansoc", True, "NUMERO DE SOCIO", 120))
            listEstCeldas.Add(New Modelos.Celda("VehiculoRegistrado", False))
            listEstCeldas.Add(New Modelos.Celda("laci", True, "CI", 80))

            frmAyuda = New Modelos.ModeloAyuda(350, 300, dt, "seleccione Cliente".ToUpper, listEstCeldas)
            frmAyuda.ShowDialog()

            If frmAyuda.seleccionado = True Then
                NumiClie = frmAyuda.filaSelect.Cells("lanumi").Value
                Nombre = frmAyuda.filaSelect.Cells("nombre").Value.ToString
                Ci = frmAyuda.filaSelect.Cells("laci").Value
                Nsoc = frmAyuda.filaSelect.Cells("lansoc").Value
                tbcliente.Text = Nombre
                numiVehiculo = frmAyuda.filaSelect.Cells("lblin").Value
                tbPlaca.Text = frmAyuda.filaSelect.Cells("lbplac").Value.ToString

            End If
        End If
    End Sub
#End Region
    
   
End Class