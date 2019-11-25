Imports DevComponents.DotNetBar
Imports Logica.AccesoLogica
Imports Janus.Windows.GridEX
Imports System.IO

Public Class PR_CertificadosYFormularios
#Region "Metodos Privados"
    Private _ruta As String = gs_CarpetaRaiz + "\Imagenes\Imagenes Alumnos Certificacion\"
    Private filaSelect As GridEXRow = Nothing
    Private Sub _prIniciarTodo()
        _PMIniciarTodo()

        Me.Text = "r e p o r t e    d e    c e r i f i c a d o    d e    a l u m n o s    y    f o r m u l a r i o s    d e    e x a m e n".ToUpper


        MReportViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
    End Sub
    Private Sub _prCargarReporteCertificado()
        If tbNumiTCE013.Text = String.Empty Then
            ToastNotification.Show(Me, "Seleccione un alumno..!!!".ToUpper,
                                       My.Resources.INFORMATION, 2000,
                                       eToastGlowColor.Blue,
                                       eToastPosition.BottomLeft)
            Exit Sub
        End If


        Dim _dt As New DataTable
        _dt = L_prCertificadosAlumnosReporteCerti(tbNumiTCE013.Text)

        If (_dt.Rows.Count > 0) Then
            'imprimir el certificado
            Dim img As Bitmap
            If (IO.File.Exists(_ruta + tbFoto.Text)) Then
                img = New Bitmap(_ruta + tbFoto.Text)
                For Each fila1 As DataRow In _dt.Rows
                    fila1.Item("foto") = _fnImageToByteArrayParaReporte(_ruta + tbFoto.Text)
                Next

            End If

            Dim j As Integer = 0
            Dim numiTipo As Integer = -1 'dtReg.Rows(0).Item("entipo")


            For l = 0 To _dt.Rows.Count - 1
                If numiTipo <> _dt.Rows(l).Item("entipo") Then
                    j = 1
                    numiTipo = _dt.Rows(l).Item("entipo")
                Else
                    j = j + 1
                End If
                _dt.Rows(l).Item("num") = j
            Next
            '--------------------------------
            Dim numiCatLic As Integer = _dt.Rows(0).Item("epcatlic")
            If numiCatLic = 6 Then
                Dim objrep As New R_ReporteCertificadoH

                objrep.SetDataSource(_dt)
                'Dim dirImgCat As String = "E:\DANNY\TRABAJO 2016\PROYECTO AUTOMOVIL CLUB\INFORMACION DE ACB OBTENIDA\PEDIDOS DE INFORMACION\categoria_A.png"
                Dim dirImgCat As String = G_getImgCategoria(_dt.Rows(0).Item("cedesc1"))
                objrep.SetParameterValue("DirImgCat", dirImgCat)

                MReportViewer.ReportSource = objrep

                MReportViewer.Show()
                MReportViewer.BringToFront()
            Else
                Dim objrep As New R_ReporteCertificado

                objrep.SetDataSource(_dt)
                'Dim dirImgCat As String = "E:\DANNY\TRABAJO 2016\PROYECTO AUTOMOVIL CLUB\INFORMACION DE ACB OBTENIDA\PEDIDOS DE INFORMACION\categoria_A.png"
                Dim dirImgCat As String = G_getImgCategoria(_dt.Rows(0).Item("cedesc1"))
                objrep.SetParameterValue("DirImgCat", dirImgCat)

                MReportViewer.ReportSource = objrep

                MReportViewer.Show()
                MReportViewer.BringToFront()
            End If

        Else
            ToastNotification.Show(Me, "NO HAY DATOS PARA LOS PARAMETROS SELECCIONADOS..!!!",
                                       My.Resources.INFORMATION, 2000,
                                       eToastGlowColor.Blue,
                                       eToastPosition.BottomLeft)
            MReportViewer.ReportSource = Nothing
        End If
    End Sub

    Private Sub _prCargarReporteFormularioExamen()
        If tbNumiCatLic.Text = String.Empty Then
            ToastNotification.Show(Me, "Seleccione un alumno..!!!".ToUpper,
                                       My.Resources.INFORMATION, 2000,
                                       eToastGlowColor.Blue,
                                       eToastPosition.BottomLeft)
            Exit Sub
        End If


        Dim _dt As New DataTable
        _dt = L_prNotasPreguntasPorPorCategoriaYTipo(tbNumiCatLic.Text, 2) 'obtengo el formulario de preguntas teoricas

        If (_dt.Rows.Count > 0) Then
            'imprimir el certificado
            Dim img As Bitmap
            If (IO.File.Exists(_ruta + tbFoto.Text)) Then
                img = New Bitmap(_ruta + tbFoto.Text)
                For Each fila1 As DataRow In _dt.Rows
                    fila1.Item("foto") = _fnImageToByteArrayParaReporte(_ruta + tbFoto.Text)
                Next

            End If

            Dim j As Integer = 0
            Dim numiTipo As Integer = -1 'dtReg.Rows(0).Item("entipo")


            For l = 0 To _dt.Rows.Count - 1
                If numiTipo <> _dt.Rows(l).Item("entipo") Then
                    j = 1
                    numiTipo = _dt.Rows(l).Item("entipo")
                Else
                    j = j + 1
                End If
                _dt.Rows(l).Item("num") = j
            Next
            '--------------------------------
            Dim objrep As New R_ReporteFormularioExamen

            Dim nombre As String = filaSelect.Cells("elnom").Value.ToString
            Dim apePat As String = filaSelect.Cells("elapep").Value.ToString
            Dim apeMat As String = filaSelect.Cells("elapem").Value.ToString
            Dim fecha As String = CType(filaSelect.Cells("emfecha").Value.ToString, Date).ToString("dd/MM/yyyy")
            Dim ci As String = filaSelect.Cells("elci").Value.ToString
            Dim edad As String = filaSelect.Cells("edad").Value.ToString
            Dim catLic As String = filaSelect.Cells("cedesc1").Value.ToString

            objrep.SetDataSource(_dt)
            MReportViewer.ReportSource = objrep

            objrep.SetParameterValue("Categoria", catLic)
            objrep.SetParameterValue("Nombre", nombre)
            objrep.SetParameterValue("ApePat", apePat)
            objrep.SetParameterValue("ApeMat", apeMat)
            objrep.SetParameterValue("Fecha", fecha)
            objrep.SetParameterValue("Edad", edad)
            objrep.SetParameterValue("Ci", ci)
            'Dim dirImgCat As String = "E:\DANNY\TRABAJO 2016\PROYECTO AUTOMOVIL CLUB\INFORMACION DE ACB OBTENIDA\PEDIDOS DE INFORMACION\categoria_A.png"
            Dim dirImgCat As String = G_getImgCategoria(catLic)
            objrep.SetParameterValue("DirImgCat", dirImgCat)

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

    Private Sub _prAyudaCertificado()
        'grabar horario
        Dim frmAyuda As Modelos.ModeloAyuda
        Dim dt As DataTable

        dt = L_prCertificadosAlumnosListaReimpresion()

        Dim listEstCeldas As New List(Of Modelos.Celda)
        listEstCeldas.Add(New Modelos.Celda("epnumi", False))
        listEstCeldas.Add(New Modelos.Celda("epznfact", True, "Nro. Factura".ToUpper, 70))
        listEstCeldas.Add(New Modelos.Celda("epalum", True, "CODIGO".ToUpper, 70))
        listEstCeldas.Add(New Modelos.Celda("elnom", True, "nombre".ToUpper, 150))
        listEstCeldas.Add(New Modelos.Celda("elapep", True, "Apellido Paterno".ToUpper, 150))
        listEstCeldas.Add(New Modelos.Celda("elapem", True, "Apellido Materno".ToUpper, 150))
        listEstCeldas.Add(New Modelos.Celda("elci", True, "CI".ToUpper, 70))
        listEstCeldas.Add(New Modelos.Celda("epfecha", True, "FECHA".ToUpper, 70))
        listEstCeldas.Add(New Modelos.Celda("epcatlic", False))
        listEstCeldas.Add(New Modelos.Celda("cedesc1", True, "CATEGORIA".ToUpper, 70))
        listEstCeldas.Add(New Modelos.Celda("elfot", False))


        frmAyuda = New Modelos.ModeloAyuda(200, 200, dt, "seleccione Alumno".ToUpper, listEstCeldas)
        frmAyuda.ShowDialog()

        If frmAyuda.seleccionado = True Then
            Dim numi As String = frmAyuda.filaSelect.Cells("epalum").Value
            Dim nombre As String = frmAyuda.filaSelect.Cells("elnom").Value + " " + frmAyuda.filaSelect.Cells("elapep").Value + " " + frmAyuda.filaSelect.Cells("elapem").Value
            Dim numiTCE013 As String = frmAyuda.filaSelect.Cells("epnumi").Value
            Dim foto As String = frmAyuda.filaSelect.Cells("elfot").Value

            tbAlumno.Text = nombre
            tbNumiAlum.Text = numi
            tbNumiTCE013.Text = numiTCE013
            tbFoto.Text = foto

        End If
    End Sub

    Private Sub _prAyudaFormulario()
        'grabar horario
        Dim frmAyuda As Modelos.ModeloAyuda
        Dim dt As DataTable

        dt = L_prExamenAlumnoCertiGeneralAyudaParaReporteFormularios()

        Dim listEstCeldas As New List(Of Modelos.Celda)
        listEstCeldas.Add(New Modelos.Celda("emznfact", True, "Nro. Factura".ToUpper, 70))
        listEstCeldas.Add(New Modelos.Celda("emcatlic", False))
        listEstCeldas.Add(New Modelos.Celda("cedesc1", True, "CATEGORIA".ToUpper, 70))
        listEstCeldas.Add(New Modelos.Celda("emalum", True, "CODIGO".ToUpper, 70))
        listEstCeldas.Add(New Modelos.Celda("elci", True, "CI".ToUpper, 70))
        listEstCeldas.Add(New Modelos.Celda("elnom", True, "nombre".ToUpper, 150))
        listEstCeldas.Add(New Modelos.Celda("elapep", True, "Apellido Paterno".ToUpper, 150))
        listEstCeldas.Add(New Modelos.Celda("elapem", True, "Apellido Materno".ToUpper, 150))
        listEstCeldas.Add(New Modelos.Celda("elfot", False))
        listEstCeldas.Add(New Modelos.Celda("emfecha", False))
        listEstCeldas.Add(New Modelos.Celda("edad", False))

        frmAyuda = New Modelos.ModeloAyuda(200, 200, dt, "seleccione Alumno".ToUpper, listEstCeldas)
        frmAyuda.ShowDialog()

        If frmAyuda.seleccionado = True Then
            Dim numi As String = frmAyuda.filaSelect.Cells("emalum").Value
            Dim nombre As String = frmAyuda.filaSelect.Cells("elnom").Value + " " + frmAyuda.filaSelect.Cells("elapep").Value + " " + frmAyuda.filaSelect.Cells("elapem").Value
            Dim foto As String = frmAyuda.filaSelect.Cells("elfot").Value
            Dim numiCatLic As String = frmAyuda.filaSelect.Cells("emcatlic").Value

            tbAlumno.Text = nombre
            tbNumiAlum.Text = numi
            tbNumiCatLic.Text = numiCatLic
            tbFoto.Text = foto

            filaSelect = frmAyuda.filaSelect
        End If
    End Sub

    'Public Function _fnImageToByteArray(ByVal imageIn As Image) As Byte()
    '    Dim ms As New System.IO.MemoryStream()
    '    imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg)
    '    Return ms.ToArray()
    'End Function

    Public Function _fnImageToByteArrayParaReporte(ByVal ruta As String) As Byte()

        Dim bitmap As Bitmap = New Bitmap(New MemoryStream(IO.File.ReadAllBytes(ruta)))
        Dim img As Bitmap = New Bitmap(bitmap)
        Dim Bin As New MemoryStream
        img.Save(Bin, Imaging.ImageFormat.Jpeg)

        Return Bin.GetBuffer
    End Function

#End Region

    Private Sub tbAlumno_KeyDown(sender As Object, e As KeyEventArgs) Handles tbAlumno.KeyDown
        If e.KeyData = Keys.Control + Keys.Enter Then

            If tbTipoReporte.Value Then
                _prAyudaCertificado()
            Else
                _prAyudaFormulario()
            End If

        End If
    End Sub

    Private Sub btnGenerar_Click(sender As Object, e As EventArgs) Handles btnGenerar.Click
        If tbTipoReporte.Value Then
            _prCargarReporteCertificado()
        Else
            _prCargarReporteFormularioExamen()
        End If

    End Sub

    Private Sub PR_CertificadosYFormularios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _prIniciarTodo()
    End Sub

    Private Sub tbTipoReporte_ValueChanged(sender As Object, e As EventArgs) Handles tbTipoReporte.ValueChanged
        tbAlumno.Text = String.Empty
        tbFoto.Text = String.Empty
        tbNumiAlum.Text = String.Empty
        tbNumiTCE013.Text = String.Empty
        tbNumiCatLic.Text = String.Empty
        filaSelect = Nothing
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub
End Class