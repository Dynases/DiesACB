Imports Logica.AccesoLogica
Imports DevComponents.DotNetBar
Imports System.Data.OleDb

Public Class PR_AcbSalidaProducto

#Region "Metodos Privados"
    Private Sub _prIniciarTodo()
        _PMIniciarTodo()
        'L_prAbrirConexion(gs_Ip, gs_UsuarioSql, gs_ClaveSql, gs_NombreBD)
        Me.Text = "REPORTE SALIDA DE PRODUCTOS ACB ESCUELA"

        MReportViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        _LlenarTipoConcepto()
    End Sub
    Private Sub _LlenarTipoConcepto()
        Dim dt As New DataTable
        dt = L_ConceptoInventario(IIf(2 = 1, "2", "3")) '2=Concepto de inventario de equipos, 3=Concepto de inventario de productos

        JCb_Concepto.DropDownList.Columns.Clear()
        JCb_Concepto.DropDownList.Columns.Add(dt.Columns(0).ToString).Width = 80
        JCb_Concepto.DropDownList.Columns(0).Caption = "Código"
        JCb_Concepto.DropDownList.Columns.Add(dt.Columns(1).ToString).Width = 250
        JCb_Concepto.DropDownList.Columns(1).Caption = "Descripcion"
        JCb_Concepto.DropDownList.Columns.Add(dt.Columns(2).ToString).Width = 0
        JCb_Concepto.DropDownList.Columns(2).Caption = ""
        JCb_Concepto.DropDownList.Columns(2).Visible = False

        JCb_Concepto.ValueMember = dt.Columns(0).ToString
        JCb_Concepto.DisplayMember = dt.Columns(1).ToString
        JCb_Concepto.DataSource = dt
        JCb_Concepto.Refresh()
        JCb_Concepto.ReadOnly = False
        JCb_Concepto.Enabled = True
        If (CType(JCb_Concepto.DataSource, DataTable).Rows.Count > 2) Then
            JCb_Concepto.SelectedIndex = 2
        End If
    End Sub

    Public Sub _prCargarReporteGeneral()
        Dim _dt As New DataTable

        _dt = L_prProductoKardexGeneralAcb(tbFechaI.Value.ToString("yyyy/MM/dd"), tbFechaF.Value.ToString("yyyy/MM/dd"), JCb_Concepto.Value)
        If (_dt.Rows.Count > 0) Then
            Dim objrep As New R_KardexGeneralAcb

            '' GenerarNro(_dt)

            objrep.SetDataSource(_dt)

            objrep.SetParameterValue("fechaI", tbFechaI.Value.ToString("dd/MM/yyyy"))
            objrep.SetParameterValue("fechaF", tbFechaF.Value.ToString("dd/MM/yyyy"))
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
    Public Sub _prCargarReporteDetallado()
        Dim _dt As New DataTable

        _dt = L_prProductoKardexDetalladoAcb(tbFechaI.Value.ToString("yyyy/MM/dd"), tbFechaF.Value.ToString("yyyy/MM/dd"), JCb_Concepto.Value)
        If (_dt.Rows.Count > 0) Then
            Dim objrep As New R_KardexDetalladoAcb

            '' GenerarNro(_dt)

            objrep.SetDataSource(_dt)

            objrep.SetParameterValue("fechaI", tbFechaI.Value.ToString("dd/MM/yyyy"))
            objrep.SetParameterValue("fechaF", tbFechaF.Value.ToString("dd/MM/yyyy"))
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
    Private Sub _prCargarReporte()
        If (cbtipo.Value = True) Then
            _prCargarReporteGeneral()
        Else
            _prCargarReporteDetallado()
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