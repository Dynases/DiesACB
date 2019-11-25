Imports CrystalDecisions.Shared
Imports DevComponents.DotNetBar
Imports CrystalDecisions.CrystalReports.Engine

Public Class PR_ListasCertiTeoPrac2
    Public _dt As New DataTable
    Public _teo As Boolean
    Public _printerName As String
    Private _prRutaPdf As String = gs_CarpetaRaiz
    Public _tipoRep As Boolean
    Private Sub _prIniciarTodo()
        _PMIniciarTodo()
        Me.Text = "reporte de lista de postulantes".ToUpper

        CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        _prCargarReporte()
    End Sub

    Private Sub _prCargarReporte()


        If (_dt.Rows.Count > 0) Then
            If _teo Then
                Dim objrep As New R_CertAlumnosTeorico
                objrep.SetDataSource(_dt)
                CrystalReportViewer1.ReportSource = objrep

                objrep.SetParameterValue("tipoRep", _tipoRep)

                CrystalReportViewer1.Show()
                CrystalReportViewer1.BringToFront()
            Else
                Dim objrep As New R_CertAlumnosPractico
                objrep.SetDataSource(_dt)
                CrystalReportViewer1.ReportSource = objrep

                objrep.SetParameterValue("tipoRep", _tipoRep)

                CrystalReportViewer1.Show()
                CrystalReportViewer1.BringToFront()
            End If
            '_prExportarToPdf()
        Else
            ToastNotification.Show(Me, "NO HAY DATOS PARA LOS PARAMETROS SELECCIONADOS..!!!",
                                       My.Resources.INFORMATION, 2000,
                                       eToastGlowColor.Blue,
                                       eToastPosition.BottomLeft)
            MReportViewer.ReportSource = Nothing
        End If

    End Sub

    Private Sub _prExportarToPdf()
        Dim CrExportOptions As ExportOptions
        Dim CrDiskFileDestinationOptions As New DiskFileDestinationOptions()

        Dim CrFormatTypeOptions As New PdfRtfWordFormatOptions()


        Dim objrep As Object
        Dim rutaFinal As String
        If _teo Then
            rutaFinal = _prRutaPdf + "\Certificacion\PDF\ListaTeorico " + Now.Date.ToString("dd_MM_yyyy") + ".pdf"
            CrDiskFileDestinationOptions.DiskFileName = rutaFinal

            objrep = New R_CertAlumnosTeorico
            objrep.SetDataSource(_dt)
            objrep.SetParameterValue("tipoRep", _tipoRep)
            CrExportOptions = objrep.ExportOptions
        Else
            rutaFinal = _prRutaPdf + "\Certificacion\PDF\ListaPractico " + Now.Date.ToString("dd_MM_yyyy") + ".pdf"
            CrDiskFileDestinationOptions.DiskFileName = rutaFinal

            objrep = New R_CertAlumnosPractico
            objrep.SetDataSource(_dt)
            objrep.SetParameterValue("tipoRep", _tipoRep)
            CrExportOptions = objrep.ExportOptions
        End If


        ' Esto pudiera estar parametrizado para permitir otras respuestas
        With CrExportOptions
            .ExportDestinationType = ExportDestinationType.DiskFile

            .ExportFormatType = ExportFormatType.PortableDocFormat ' pdf OK default

            .DestinationOptions = CrDiskFileDestinationOptions
            .FormatOptions = CrFormatTypeOptions
        End With

        ' Genera PDF
        If (IO.File.Exists(rutaFinal) = True) Then
            objrep.Export()
        End If

    End Sub

    Private Sub _prImprimir()
        If _teo Then
            Dim objrep As New R_CertAlumnosTeorico
            objrep.PrintOptions.PrinterName = _printerName
            objrep.SetDataSource(_dt)
            objrep.SetParameterValue("tipoRep", _tipoRep)
            objrep.PrintToPrinter(1, False, 1, 10)

        Else
            Dim objrep As New R_CertAlumnosPractico
            objrep.PrintOptions.PrinterName = _printerName
            objrep.SetDataSource(_dt)
            objrep.SetParameterValue("tipoRep", _tipoRep)
            objrep.PrintToPrinter(1, False, 1, 10)
        End If
        _prExportarToPdf()
    End Sub

    Private Sub _prExportarToExcel()
        Dim objrep As New R_CertAlumnosTeorico

        'Dim objExcelOptions As ExcelFormatOptions = New ExcelFormatOptions
        'objExcelOptions.ExcelUseConstantColumnWidth = False
        'rptExcel.ExportOptions.FormatOptions = objExcelOptions 'so that your Page_Init now reads

        Dim rptExcel As New ReportDocument
        Dim strExportFile As String = "C:\Desarrollo Danny\DIES" & "/bad.xls"
        'rptExcel.Load(Server.MapPath("bad.rpt"))
        rptExcel.Load("D:\Sistemas\TFS Dinases\Proyecto Dies\ProyectoDies\Presentacion\Reportes\R_CertAlumnosTeorico.rpt")
        rptExcel.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile
        rptExcel.ExportOptions.ExportFormatType = ExportFormatType.Excel
        Dim objExcelOptions As ExcelFormatOptions = New ExcelFormatOptions
        objExcelOptions.ExcelUseConstantColumnWidth = False
        rptExcel.ExportOptions.FormatOptions = objExcelOptions
        Dim objOptions As DiskFileDestinationOptions = New DiskFileDestinationOptions
        objOptions.DiskFileName = strExportFile
        rptExcel.ExportOptions.DestinationOptions = objOptions
        rptExcel.Export()
        objOptions = Nothing
        rptExcel = Nothing
        'Response.Redirect("bad.xls")
    End Sub
    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub PR_ListasCertiTeoPrac2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _prIniciarTodo()
    End Sub

    Private Sub btnGenerar_Click(sender As Object, e As EventArgs) Handles btnGenerar.Click
        _prImprimir()

        '_prExportarToExcel()
        Me.Close()
    End Sub
End Class