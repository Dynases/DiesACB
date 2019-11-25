
Imports Logica.AccesoLogica
Imports DevComponents.DotNetBar

Imports Janus.Windows.GridEX

Imports System.IO
Imports DevComponents.DotNetBar.SuperGrid
Imports Presentacion.F_ClienteNuevoServicio
Public Class Pr_HistorialDeDescuentosLavadero
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
        Me.Text = "R E P O R T E  H I S T O R I A L   D E S C U E N T O S   L A V A D E R O"
        MReportViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        cargarFocusTextbox()
        tbFiltrarCliente.Value = True
        tbcliente.Focus()

    End Sub
    Public Sub cargarFocusTextbox()

        With MHighlighterFocus

            .SetHighlightOnFocus(tbcliente, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
        End With
    End Sub
    Public Sub _prCargarDescuentosTabla(ByRef dt As DataTable, ayuda As DataTable)
        Dim tabla As DataTable = ayuda
        Dim te As DataTable = tabla.Copy
        For Each fila2 As DataRow In dt.Rows
            Dim nsoc As Integer = fila2.Item("lansoc")
            For Each fila3 As DataRow In tabla.Rows
                Dim nsoca As Integer = fila3.Item("lansoc")
                If (nsoc = nsoca) Then
                    'If (fila3("Marzo") <> String.Empty) Then

                    'End If
                    For Each column As DataColumn In te.Columns
                        Dim col As Object = column.ToString
                        If (Not fila3(col).ToString.Trim = String.Empty And fila2(col).ToString = String.Empty) Then
                            Dim val As Object = fila3(col)
                            fila2(col) = val
                        End If

                    Next


                End If
            Next
        Next
    End Sub

    Private Sub _prCargarReporte()
        Dim _dt As New DataTable
        If (tbFiltrarCliente.Value = True) Then

            _dt = L_prReporteHistorialDescuentos()
            _prCargarDescuentosTabla(_dt, L_prAyudaHistorialDescuentos(tbano.Value.Year))

        Else
            _dt = L_prReporteHistorialDescuentosCliente(Nsoc)
            _prCargarDescuentosTabla(_dt, L_prAyudaHistorialDescuentosPorCliente(Nsoc, tbano.Value.Year))

        End If

        If (_dt.Rows.Count > 0) Then

            Dim objrep As New R_HistorialDescuentosSocio
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
        tbcliente.Focus()

    End Sub

#End Region
#Region "Eventos Formulario"
    Private Sub Pr_LavaderoGeneralServicios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _prIniciarTodo()
    End Sub
    Private Sub btnGenerar_Click(sender As Object, e As EventArgs) Handles btnGenerar.Click


        _prCargarReporte()



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


            dt = L_prServicioVehiculoClienteCliente()
            Dim listEstCeldas As New List(Of Modelos.Celda)
            listEstCeldas.Add(New Modelos.Celda("rblin", False))
            listEstCeldas.Add(New Modelos.Celda("ranumi", False))
            listEstCeldas.Add(New Modelos.Celda("rbplac", True, "PLACA", 120))
            listEstCeldas.Add(New Modelos.Celda("marca", True, "MARCA", 150))
            listEstCeldas.Add(New Modelos.Celda("modelo", True, "MODELO", 150))
            listEstCeldas.Add(New Modelos.Celda("nombre", True, "NOMBRE", 200))
            listEstCeldas.Add(New Modelos.Celda("rafot", False))
            listEstCeldas.Add(New Modelos.Celda("ransoc", True, "NUMERO DE SOCIO", 120))
            listEstCeldas.Add(New Modelos.Celda("raci", True, "CI", 80))
            frmAyuda = New Modelos.ModeloAyuda(350, 300, dt, "seleccione Cliente".ToUpper, listEstCeldas)
            frmAyuda.ShowDialog()

            If frmAyuda.seleccionado = True Then
                NumiClie = frmAyuda.filaSelect.Cells("ranumi").Value
                Nombre = frmAyuda.filaSelect.Cells("nombre").Value.ToString
                Ci = frmAyuda.filaSelect.Cells("raci").Value
                Nsoc = frmAyuda.filaSelect.Cells("ransoc").Value
                tbcliente.Text = Nombre
                numiVehiculo = frmAyuda.filaSelect.Cells("rblin").Value


            End If
        End If
    End Sub
#End Region


End Class