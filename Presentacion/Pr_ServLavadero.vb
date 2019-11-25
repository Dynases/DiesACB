Imports Logica.AccesoLogica
Imports DevComponents.DotNetBar
Imports System.Data.OleDb

Public Class Pr_ServLavaderoGeneral

#Region "Metodos Privados"
    Private Sub _prIniciarTodo()
        _PMIniciarTodo()
        'L_prAbrirConexion(gs_Ip, gs_UsuarioSql, gs_ClaveSql, gs_NombreBD)
        Me.Text = "R E P O R T E  S E R V I C I O S  D I A R I O  L A V A D E R O"

        MReportViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None

    End Sub
    Private Sub _prCargarReporte()
        Dim _dt As New DataTable
        Dim dt1 As DataTable = L_prReporteServiciosGeneralTipoVenta(tbFechaI.Value.ToString("yyyy/MM/dd"), tbFechaF.Value.ToString("yyyy/MM/dd"))



        _dt = L_prReporteServiciosLavaderoPorPlaca(tbFechaI.Value.ToString("yyyy/MM/dd"), tbFechaF.Value.ToString("yyyy/MM/dd"))
        If (_dt.Rows.Count > 0) Then
            Dim objrep As New R_ServLavadero1

            '' GenerarNro(_dt)

            objrep.SetDataSource(_dt)
            Dim fecha As String = tbFechaI.Value.ToString("dd/MM/yyyy") + " AL " + tbFechaI.Value.ToString("dd/MM/yyyy")
            objrep.DataSourceConnections.Item(0).SetLogon(P_Global.gs_UsuarioSql, P_Global.gs_ClaveSql)
            objrep.Subreports.Item("R_TipoVenta.rpt").SetDataSource(dt1)
            objrep.SetParameterValue("RangoFecha", fecha)
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
#End Region
#Region "Evento del Formulario"
    Private Sub Pr_ListAlumnAprovb_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _prIniciarTodo()
    End Sub

    Private Function GetDataExcel( _
  ByVal fileName As String, ByVal sheetName As String) As DataTable

        ' Comprobamos los parámetros.
        '
        If ((String.IsNullOrEmpty(fileName)) OrElse _
          (String.IsNullOrEmpty(sheetName))) Then _
          Throw New ArgumentNullException()

        Try
            Dim extension As String = IO.Path.GetExtension(fileName)

            Dim connString As String = "Data Source=" & fileName

            If (extension = ".xls") Then
                connString &= ";Provider=Microsoft.Jet.OLEDB.4.0;" & _
                       "Extended Properties='Excel 8.0;HDR=YES;IMEX=1'"

            ElseIf (extension = ".xlsx") Then
                connString &= ";Provider=Microsoft.ACE.OLEDB.12.0;" & _
                       "Extended Properties='Excel 12.0 Xml;HDR=YES;IMEX=1'"
            Else
                Throw New ArgumentException( _
                  "La extensión " & extension & " del archivo no está permitida.")
            End If

            Using conexion As New OleDbConnection(connString)

                Dim sql As String = "SELECT * FROM [" & sheetName & "$]"
                Dim adaptador As New OleDbDataAdapter(sql, conexion)

                Dim dt As New DataTable("Excel")

                adaptador.Fill(dt)

                Return dt

            End Using

        Catch ex As Exception
            Throw

        End Try

    End Function
    Private Sub btnGenerar_Click(sender As Object, e As EventArgs) Handles btnGenerar.Click
        _prCargarReporte()
      
    End Sub
    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub
#End Region
End Class