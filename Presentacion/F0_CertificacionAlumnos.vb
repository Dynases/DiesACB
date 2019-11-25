Imports Logica.AccesoLogica
Imports Janus.Windows.GridEX
Imports DevComponents.DotNetBar
Imports System.IO

Public Class F0_CertificacionAlumnos

#Region "METODOS PRIVADOS"
    Private _ruta As String = gs_CarpetaRaiz + "\Imagenes\Imagenes Alumnos Certificacion\"

    Private Sub _prIniciarTodo()
        btnImprimir.Visible = False
        Me.Text = "c e r t i f i c a c i o n     d e     a l u m n o s ".ToUpper
        Me.WindowState = FormWindowState.Maximized
        SuperTabPrincipal.SelectedTabIndex = 0
        _prCargarGridAlumnos()
    End Sub
    Private Sub _prCargarGridAlumnos()

        Dim dtGrid As DataTable = L_prCertificadosAlumnosLista()
        grAlumnos.DataSource = dtGrid
        grAlumnos.RetrieveStructure()


        With grAlumnos.RootTable.Columns("emcatlic")
            .Visible = False
        End With

        With grAlumnos.RootTable.Columns("emfecha")
            .Visible = False
        End With

        With grAlumnos.RootTable.Columns("emznfact")
            .Caption = "nro. fact.".ToUpper
            .Width = 100
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        End With

        With grAlumnos.RootTable.Columns("emalum")
            .Caption = "COD. ALUM".ToUpper
            .Width = 50
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        End With

        With grAlumnos.RootTable.Columns("elci")
            .Caption = "CI".ToUpper
            .Width = 70
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        End With

        With grAlumnos.RootTable.Columns("elnom")
            .Caption = "nombre".ToUpper
            .Width = 150
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
        End With

        With grAlumnos.RootTable.Columns("elapep")
            .Caption = "ape. pat.".ToUpper
            .Width = 150
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
        End With

        With grAlumnos.RootTable.Columns("elapem")
            .Caption = "ape. mat.".ToUpper
            .Width = 150
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
        End With



        With grAlumnos.RootTable.Columns("elfot")
            .Visible = False
        End With

        With grAlumnos.RootTable.Columns("elesc")
            .Visible = False
        End With

        With grAlumnos.RootTable.Columns("elesc2")
            .Caption = "ESC.".ToUpper
            .Width = 50
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        End With

        With grAlumnos.RootTable.Columns("ok")
            .Caption = "ok.".ToUpper
            .Width = 50
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.BackColor = Color.LightGreen
        End With



        With grAlumnos.RootTable.Columns("estado")
            .Visible = False
        End With

        'Habilitar Filtradores
        With grAlumnos
            .DefaultFilterRowComparison = FilterConditionOperator.Contains
            .FilterMode = FilterMode.Automatic
            .FilterRowUpdateMode = FilterRowUpdateMode.WhenValueChanges
            .GroupByBoxVisible = False
            .VisualStyle = VisualStyle.Office2007
        End With


    End Sub

    Private Sub _prSeleccionarTodos()
        With grAlumnos
            For i = 0 To .RowCount - 1
                .Row = i
                .SetValue("ok", True)
            Next
        End With
    End Sub

    Private Sub _prGrabar()
        Dim numiAlum, nroFact, fecha, catlic As String
        Dim notaTeo, notaMec, notaPrac, notaFin As Double
        Dim dtExamenTeo, dtExamenPrac As DataTable
        'Dim impresora As Boolean = False
        With grAlumnos
            For i = 0 To .RowCount - 1
                .Row = i
                Dim ok As Boolean = .GetValue("ok")
                If ok Then
                    'If impresora = False Then
                    '    If PrintDialog1.ShowDialog = DialogResult.OK Then
                    '        objrep.PrintOptions.PrinterName = PrintDialog1.PrinterSettings.PrinterName
                    '    End If
                    '    impresora = True
                    'End If
                    numiAlum = .GetValue("emalum")
                    nroFact = .GetValue("emznfact")
                    catlic = .GetValue("emcatlic")
                    'fecha = Now.Date.ToString("yyyy/MM/dd")
                    fecha = CType(.GetValue("emfecha"), Date).ToString("yyyy/MM/dd")
                    dtExamenTeo = L_prCertificadosAlumnosGetUltimaClaseTeorica(numiAlum, nroFact)
                    dtExamenPrac = L_prCertificadosAlumnosGetUltimaClasePractica(numiAlum, nroFact)
                    If catlic = 6 Then
                        notaPrac = 0
                    Else
                        notaPrac = dtExamenPrac.Rows(0).Item("emnota")

                    End If
                    notaTeo = L_prCertificadosAlumnosGetNotaEvaluacionTeorica(dtExamenTeo.Rows(0).Item("emnumi").ToString).Rows(0).Item("nota")
                    If catlic = 6 Then
                        notaMec = 0
                    Else
                        notaMec = L_prCertificadosAlumnosGetNotaEvaluacionConocMecanica(dtExamenTeo.Rows(0).Item("emnumi").ToString).Rows(0).Item("nota")
                    End If
                    notaFin = notaPrac + notaTeo + notaMec

                    Dim numiReg As String = ""
                    L_prCertificadosAlumnosGrabar(numiReg, numiAlum, nroFact, fecha, catlic, notaTeo, notaMec, notaPrac, notaFin)

                    'imprimir el certificado
                    Dim _Nombre As String
                    Dim dtReg As DataTable = L_prCertificadosAlumnosReporteCerti(numiReg)
                    If dtReg(0)("elnac") = 4 Then 'Brasilero
                        _Nombre = dtReg(0).Item("elnom") + " " + dtReg(0).Item("elapem") + " " + dtReg(0).Item("elapep")
                    Else
                        _Nombre = dtReg(0).Item("elnom") + " " + dtReg(0).Item("elapep") + " " + dtReg(0).Item("elapem")
                    End If
                    Dim img As Bitmap
                    Dim img2 As Bitmap
                    If (IO.File.Exists(_ruta + .GetValue("elfot").ToString)) Then
                        img = New Bitmap(_ruta + .GetValue("elfot").ToString)
                        img2 = New Bitmap(img, 50, 50) 'img2 = New Bitmap(img, 40, 40)
                        '_cel.CellStyles.Default.Image = img2

                        For Each fila1 As DataRow In dtReg.Rows
                            fila1.Item("foto") = _fnImageToByteArrayParaReporte(_ruta + .GetValue("elfot").ToString)
                        Next
                    End If

                    Dim j As Integer = 0
                    Dim numiTipo As Integer = -1 'dtReg.Rows(0).Item("entipo")


                    For l = 0 To dtReg.Rows.Count - 1
                        If numiTipo <> dtReg.Rows(l).Item("entipo") Then
                            j = 1
                            numiTipo = dtReg.Rows(l).Item("entipo")
                        Else
                            j = j + 1
                        End If
                        dtReg.Rows(l).Item("num") = j
                    Next

                    ''objrep.SetDataSource(dtReg)
                    ' ''Dim dirImgCat As String = "E:\DANNY\TRABAJO 2016\PROYECTO AUTOMOVIL CLUB\INFORMACION DE ACB OBTENIDA\PEDIDOS DE INFORMACION\categoria_A.png"
                    ''Dim dirImgCat As String = G_getImgCategoria(dtReg.Rows(0).Item("cedesc1"))
                    ''objrep.SetParameterValue("DirImgCat", dirImgCat)
                    ''objrep.PrintToPrinter(1, False, 1, 10)


                    If catlic = 6 Then
                        Dim objrep As New R_ReporteCertificadoH

                        'ahora lo mando al visualizador
                        P_Global.Visualizador = New Visualizador
                        objrep.SetDataSource(dtReg)
                        Dim dirImgCat As String = G_getImgCategoria(dtReg.Rows(0).Item("cedesc1"))
                        objrep.SetParameterValue("DirImgCat", dirImgCat)
                        P_Global.Visualizador.CRV1.ReportSource = objrep 'Comentar
                        P_Global.Visualizador.Show() 'Comentar
                        P_Global.Visualizador.BringToFront() 'Comentar
                    Else
                        Dim objrep As New R_ReporteCertificado

                        'ahora lo mando al visualizador
                        P_Global.Visualizador = New Visualizador
                        objrep.SetDataSource(dtReg)

                        Dim dirImgCat As String = G_getImgCategoria(dtReg.Rows(0).Item("cedesc1"))
                        objrep.SetParameterValue("DirImgCat", dirImgCat)
                        objrep.SetParameterValue("Nombre", _Nombre)
                        P_Global.Visualizador.CRV1.ReportSource = objrep 'Comentar
                        P_Global.Visualizador.Show() 'Comentar
                        P_Global.Visualizador.BringToFront() 'Comentar
                    End If

                End If

            Next
        End With

        ToastNotification.Show(Me, "Se genero exitosamente los certificados".ToUpper, My.Resources.GRABACION_EXITOSA, 5000, eToastGlowColor.Green, eToastPosition.TopCenter)
        _prCargarGridAlumnos()
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

    Private Sub F0_ListaCertificados_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _prIniciarTodo()
    End Sub

    Private Sub btMarcarTodos_Click(sender As Object, e As EventArgs) Handles btMarcarTodos.Click
        _prSeleccionarTodos()
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btnGrabar_Click(sender As Object, e As EventArgs) Handles btnGrabar.Click
        _prGrabar()
    End Sub

    Private Sub grAlumnos_EditingCell(sender As Object, e As EditingCellEventArgs) Handles grAlumnos.EditingCell
        If e.Column.Key <> "ok" Then
            e.Cancel = True
        End If

    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click

    End Sub

    Private Sub tbTodos_ValueChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        _prCargarGridAlumnos()

    End Sub
End Class