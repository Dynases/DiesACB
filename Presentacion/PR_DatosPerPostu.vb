Imports Logica.AccesoLogica
Imports DevComponents.DotNetBar
Imports System.IO

Public Class PR_DatosPerPostu
    'Dim RutaGlobal As String = gs_CarpetaRaiz + "\Imagenes\"
    Dim RutaGlobal As String = gs_CarpetaRaiz + "\Imagenes\Imagenes Alumnos Certificacion\"

#Region "Metodos Privados"
    Private Sub _prIniciarTodo()
        _PMIniciarTodo()
        'L_prAbrirConexion(gs_Ip, gs_UsuarioSql, gs_ClaveSql, gs_NombreBD)
        Me.Text = "R E P O R T E  D A T O S   P E R S O N A L E S   P O S T U L A N T E S"

        tbName.Enabled = False
        MReportViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
    End Sub
    Private Sub _prCargarReporte()
        Dim _dt As New DataTable


        _dt = L_prDatosPersonalesPost(tbNumi.Text, tbNroFact.Text)


        If (_dt.Rows.Count > 0) Then
            Dim objrep As New R_DatosPersoPostu
            _prDibujarDataSourceImagen(_dt)

            Dim fechaTeo1, fechaTeo2, fechaPrac1, fechaPrac2 As String
            fechaTeo1 = ""
            fechaTeo2 = ""
            fechaPrac1 = ""
            fechaPrac2 = ""

            Dim dtRegTeo As DataTable = L_prExamenAlumnoCertiGeneralRegistrosPorNroFactura(tbNroFact.Text, tbNumi.Text, 1)
            Dim dtRegPrac As DataTable = L_prExamenAlumnoCertiGeneralRegistrosPorNroFactura(tbNroFact.Text, tbNumi.Text, 2)
            If dtRegTeo.Rows.Count > 0 Then
                If dtRegTeo.Rows.Count = 1 Then
                    fechaTeo1 = dtRegTeo.Rows(0).Item("emfecha")
                Else
                    fechaTeo1 = dtRegTeo.Rows(0).Item("emfecha")
                    fechaTeo2 = dtRegTeo.Rows(1).Item("emfecha")
                End If
            End If

            If dtRegPrac.Rows.Count > 0 Then
                If dtRegPrac.Rows.Count = 1 Then
                    fechaPrac1 = dtRegPrac.Rows(0).Item("emfecha")
                Else
                    fechaPrac1 = dtRegPrac.Rows(0).Item("emfecha")
                    fechaPrac2 = dtRegPrac.Rows(1).Item("emfecha")
                End If
            End If



            objrep.SetDataSource(_dt)
            MReportViewer.ReportSource = objrep

            objrep.SetParameterValue("nombres", tbName.Text)
            objrep.SetParameterValue("FechaTeo1", fechaTeo1)
            objrep.SetParameterValue("FechaTeo2", fechaTeo2)
            objrep.SetParameterValue("FechaPrac1", fechaPrac1)
            objrep.SetParameterValue("FechaPrac2", fechaPrac2)
            objrep.SetParameterValue("DiaTeo", "lunes: 07:30am".ToUpper)
            objrep.SetParameterValue("DiaPrac", "lunes: 09:30am".ToUpper)

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
    Private Sub _prDibujarDataSourceImagen(_datatable As DataTable)
        Dim length As Integer
        length = _datatable.Rows.Count

        For i As Integer = 0 To length - 1 Step 1

            Dim name As String
            name = _datatable.Rows(i).Item("elfot")
            'Aqui Inserto la imagen la que esta el nombre en la base de datos y la ruta predefinida
            'conforme a su carpeta correspondiente
            If (name.Equals("")) Then
                ''  _datatable.Rows(i).Item("elimg") = null
            Else
                If (IO.File.Exists(RutaGlobal + name)) Then
                    _datatable.Rows(i).Item("elimg") = _fnImageToByteArrayParaReporte(RutaGlobal + name)
                End If
            End If

        Next
    End Sub
    'Public Function _fnBytesArchivo(ruta As String) As Byte()

    '    If Not (ruta.Equals(" ")) Then ' esta sería una función que verifica que realmente existe el archivo, devolviendo true o false...

    '        Return IO.File.ReadAllBytes(ruta)

    '    Else

    '        Throw New Exception("No se encuentra el archivo: " & ruta)

    '    End If

    'End Function

    Public Function _fnImageToByteArrayParaReporte(ByVal ruta As String) As Byte()

        Dim bitmap As Bitmap = New Bitmap(New MemoryStream(IO.File.ReadAllBytes(ruta)))
        Dim img As Bitmap = New Bitmap(bitmap)
        Dim Bin As New MemoryStream
        img.Save(Bin, Imaging.ImageFormat.Jpeg)

        Return Bin.GetBuffer
    End Function
#End Region
    Private Sub PR_DatosPerPostu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _prIniciarTodo()
    End Sub

    Private Sub btnGenerar_Click(sender As Object, e As EventArgs) Handles btnGenerar.Click
        _prCargarReporte()
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub
    Private Sub tbSucursal_KeyDown(sender As Object, e As KeyEventArgs) Handles tbName.KeyDown
        If e.KeyData = Keys.Control + Keys.Enter Then

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
                Dim nroFact As String = frmAyuda.filaSelect.Cells("emznfact").Value

                tbNroFact.Text = nroFact
                tbName.Text = nombre
                tbNumi.Text = numi

            End If
        End If
    End Sub

    Private Sub tbFiltrarSuc_ValueChanged(sender As Object, e As EventArgs) Handles tbFiltrarSuc.ValueChanged
        tbName.Enabled = tbFiltrarSuc.Value

    End Sub
End Class