Imports Logica.AccesoLogica
Imports DevComponents.DotNetBar

Public Class PR_EscuelaCertificado
    'Dim RutaGlobal As String = gs_CarpetaRaiz + "\Imagenes\"
    Dim RutaGlobal As String = gs_CarpetaRaiz + "\Imagenes\Imagenes Alumnos\"
    Dim jefeEscuelaConductores As String = ""
    Dim gerente As String = ""
    Dim presidente As String = ""
    Dim codReporte As String = "RECert"

#Region "Metodos Privados"
    Private Sub _prIniciarTodo()
        _PMIniciarTodo()
        Me.Text = "C E R T I F I C A D O     D E     E S C U E L A"


        Dim dt As DataTable = L_prTCE000General()
        Dim dtTitulos As DataTable = L_prTitulosAll(codReporte)
        'jefeEscuelaConductores = dt.Rows(0).Item("ejefeescuela").ToString
        'gerente = dt.Rows(0).Item("egerente").ToString
        'presidente = dt.Rows(0).Item("epresidente").ToString
        If dtTitulos.Rows.Count > 0 Then
            jefeEscuelaConductores = dtTitulos.Rows(0).Item("yedesc").ToString
            gerente = dtTitulos.Rows(1).Item("yedesc").ToString
            presidente = dtTitulos.Rows(2).Item("yedesc").ToString
        End If

        tbName.Enabled = False
        MReportViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
    End Sub
    Private Sub _prCargarReporte()
        Dim _dt As New DataTable


        If tbFiltrarAlumno.Value = False Then
            _dt = L_prPreExamenAprobadosCertificadoPorNroGrupo(tbNroGrupo.Text)
        Else
            If tbNumi.Text <> "" Then
                _dt = L_prPreExamenAprobadosCertificadoPorNumiAlumno(tbNumi.Text)
            Else
                ToastNotification.Show(Me, "seleccione a un alumno..!!!".ToUpper,
                                       My.Resources.INFORMATION, 2000,
                                       eToastGlowColor.Blue,
                                       eToastPosition.BottomLeft)
            End If
        End If


        If (_dt.Rows.Count > 0) Then
            Dim objrep As New R_EscuelaCertificado
            _prDibujarDataSourceImagen(_dt)

            objrep.SetDataSource(_dt)
            MReportViewer.ReportSource = objrep
            objrep.SetParameterValue("fecha", Now.Date)
            objrep.SetParameterValue("nombre1", jefeEscuelaConductores)
            objrep.SetParameterValue("nombre2", gerente)
            objrep.SetParameterValue("nombre3", presidente)

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
            name = _datatable.Rows(i).Item("cbfot")
            'Aqui Inserto la imagen la que esta el nombre en la base de datos y la ruta predefinida
            'conforme a su carpeta correspondiente
            If (name.Equals("")) Then
                ''  _datatable.Rows(i).Item("elimg") = null
            Else
                _datatable.Rows(i).Item("cbfot2") = _fnBytesArchivo(RutaGlobal + name)

            End If

        Next
    End Sub
    Public Function _fnBytesArchivo(ruta As String) As Byte()

        If IO.File.Exists(ruta) Then ' esta sería una función que verifica que realmente existe el archivo, devolviendo true o false...

            Return IO.File.ReadAllBytes(ruta)

        End If

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

            dt = L_prPreExamenObtenerTodosAlumnosAprobados()

            Dim listEstCeldas As New List(Of Modelos.Celda)
            listEstCeldas.Add(New Modelos.Celda("ejalum", True, "CODIGO".ToUpper, 70))
            listEstCeldas.Add(New Modelos.Celda("cbci", True, "CI".ToUpper, 70))
            listEstCeldas.Add(New Modelos.Celda("cbnom2", True, "nombre".ToUpper, 300))


            frmAyuda = New Modelos.ModeloAyuda(200, 200, dt, "seleccione Alumno".ToUpper, listEstCeldas)
            frmAyuda.ShowDialog()

            If frmAyuda.seleccionado = True Then
                Dim numi As String = frmAyuda.filaSelect.Cells("ejalum").Value
                Dim nombre As String = frmAyuda.filaSelect.Cells("cbnom2").Value

                tbName.Text = nombre
                tbNumi.Text = numi
            Else
                tbNumi.Text = ""
                tbName.Text = ""
            End If
        End If
    End Sub

    Private Sub tbFiltrarSuc_ValueChanged(sender As Object, e As EventArgs) Handles tbFiltrarAlumno.ValueChanged
        tbName.Enabled = tbFiltrarAlumno.Value
        tbNroGrupo.Enabled = Not tbFiltrarAlumno.Value

    End Sub
End Class