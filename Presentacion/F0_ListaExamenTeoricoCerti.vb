Imports DevComponents.DotNetBar.SuperGrid
Imports Logica.AccesoLogica
Imports DevComponents.DotNetBar
Imports Janus.Windows.GridEX
Imports System.IO


Public Class F0_ListaExamenTeoricoCerti

#Region "VARIABLES LOCALES"
    Private _ruta As String = gs_CarpetaRaiz + "\Imagenes\Imagenes Alumnos Certificacion\"
    Private _fuenteTamano As Integer = 10
#End Region

#Region "METODOS PRIVADOS"
    Private Sub _prIniciarTodo()
        Me.Text = "l i s t a    d e    p o s t u l a n t e s    e x a m e n     t e o r i c o ".ToUpper
        Me.WindowState = FormWindowState.Maximized
        _prCargarComboSucursal()
        _prCargarGridAlumnos()
    End Sub

    Private Sub _prCargarComboSucursal()
        Dim dt As New DataTable
        dt = L_prSucursalAyuda()
        dt.Rows.Add(-1, "TODOS")
        With tbSuc
            .DropDownList.Columns.Clear()

            .DropDownList.Columns.Add("canumi").Width = 70
            .DropDownList.Columns("canumi").Caption = "COD"

            .DropDownList.Columns.Add("cadesc").Width = 200
            .DropDownList.Columns("cadesc").Caption = "descripcion".ToUpper

            .ValueMember = "canumi"
            .DisplayMember = "cadesc"
            .DataSource = dt
            .Refresh()
        End With

        tbSuc.SelectedIndex = dt.Rows.Count - 1
        'If gb_userTodasSuc = False Then
        '    tbSuc.Enabled = False
        'End If
    End Sub

    Private Sub _prCargarReporteTeorico(dtAlumnos As DataTable)


        'codigo danny
        'Dim dtAlumnos As DataTable = L_prAlumnoCertiGeneralReporteExamenTeorico()
        For Each fila As DataRow In dtAlumnos.Rows
            Dim img As Bitmap
            Dim img2 As Bitmap
            If (IO.File.Exists(_ruta + fila.Item("elfot").ToString)) Then
                img = New Bitmap(_ruta + fila.Item("elfot").ToString)
                img2 = New Bitmap(img, 50, 50) 'img2 = New Bitmap(img, 40, 40)
                '_cel.CellStyles.Default.Image = img2
                fila.Item("img") = _fnImageToByteArrayParaReporte(_ruta + fila.Item("elfot").ToString)
            End If
        Next

        Dim fr As New PR_ListasCertiTeoPrac2
        fr._teo = True
        fr._dt = dtAlumnos
        fr._tipoRep = tbTipoRep.Value
        fr._printerName = PrintDialog1.PrinterSettings.PrinterName
        fr.ShowDialog()
        'Dim objrep As New R_CertAlumnosTeorico
        'objrep.PrintOptions.PrinterName = PrintDialog1.PrinterSettings.PrinterName
        'objrep.SetDataSource(dtAlumnos)
        'objrep.PrintToPrinter(1, False, 1, 10)



    End Sub

    Private Sub _prCargarReportePractico(dtAlumnos As DataTable)

        'codigo danny
        'Dim dtAlumnos As DataTable = L_prAlumnoCertiGeneralReporteExamenTeorico()
        For Each fila As DataRow In dtAlumnos.Rows
            Dim img As Bitmap
            Dim img2 As Bitmap
            If (IO.File.Exists(_ruta + fila.Item("elfot").ToString)) Then
                img = New Bitmap(_ruta + fila.Item("elfot").ToString)
                img2 = New Bitmap(img, 50, 50) 'img2 = New Bitmap(img, 40, 40)
                '_cel.CellStyles.Default.Image = img2
                fila.Item("img") = _fnImageToByteArrayParaReporte(_ruta + fila.Item("elfot").ToString) '_fnImageToByteArrayParaReporte
            End If
        Next

        Dim fr As New PR_ListasCertiTeoPrac2
        fr._teo = False
        fr._dt = dtAlumnos
        fr._tipoRep = tbTipoRep.Value
        fr._printerName = PrintDialog1.PrinterSettings.PrinterName
        fr.ShowDialog()
        'Dim objrep As New R_CertAlumnosPractico
        'objrep.PrintOptions.PrinterName = PrintDialog1.PrinterSettings.PrinterName
        'objrep.SetDataSource(dtAlumnos)
        'objrep.PrintToPrinter(1, False, 1, 10)


    End Sub

    Private Sub _prCargarReporteListaPractico()
        'codigo danny
        Dim dtAlumnos As DataTable = L_prAlumnoCertiGeneralReporteExamenTeorico()
        For Each fila As DataRow In dtAlumnos.Rows
            Dim img As Bitmap
            Dim img2 As Bitmap
            If (IO.File.Exists(_ruta + fila.Item("elfot").ToString)) Then
                img = New Bitmap(_ruta + fila.Item("elfot").ToString)
                img2 = New Bitmap(img, 50, 50) 'img2 = New Bitmap(img, 40, 40)
                '_cel.CellStyles.Default.Image = img2
                fila.Item("img") = _fnImageToByteArray(img2)
            End If

        Next

        Dim objrep As New R_CertAlumnosPractico
        'imprimir
        If PrintDialog1.ShowDialog = DialogResult.OK Then
            objrep.PrintOptions.PrinterName = PrintDialog1.PrinterSettings.PrinterName
            objrep.SetDataSource(dtAlumnos)
            objrep.PrintToPrinter(1, False, 1, 10)
        End If

    End Sub
    Public Function _fnImageToByteArray(ByVal imageIn As Image) As Byte()
        Dim ms As New System.IO.MemoryStream()
        imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg)
        Return ms.ToArray()
    End Function
    Public Function _fnImageToByteArrayParaReporte(ByVal ruta As String) As Byte()

        Dim bitmap As Bitmap = New Bitmap(New MemoryStream(IO.File.ReadAllBytes(ruta)))
        Dim img As Bitmap = New Bitmap(bitmap)
        Dim Bin As New MemoryStream
        img.Save(Bin, Imaging.ImageFormat.Jpeg)

        Return Bin.GetBuffer
    End Function
    Private Sub _prCargarGridAlumnos()
        Dim dtAlumnos As DataTable
        dtAlumnos = L_prExamenAlumnoCertiGeneralReporteExamenTeorico(tbFecha.Value.ToString("yyyy/MM/dd"), tbSuc.Value)

        Dim dtEstados As DataTable = New DataTable
        dtEstados.Columns.Add("numi", GetType(Integer))
        dtEstados.Columns.Add("desc", GetType(String))
        dtEstados.Rows.Add(2, "A")
        dtEstados.Rows.Add(3, "R")
        dtEstados.Rows.Add(4, "NSP")
        dtEstados.Rows.Add(5, "R")
        dtEstados.Rows.Add(0, "NSP")

        'For Each fila As DataRow In dtAlumnos.Rows
        '    Dim img As Bitmap
        '    Dim img2 As Bitmap
        '    If (IO.File.Exists(_ruta + fila.Item("elfot").ToString)) Then
        '        img = New Bitmap(_ruta + fila.Item("elfot").ToString)
        '        img2 = New Bitmap(img, 50, 50) 'img2 = New Bitmap(img, 40, 40)
        '        '_cel.CellStyles.Default.Image = img2
        '        fila.Item("img") = _fnImageToByteArray(img2)
        '    End If
        'Next

        'aumento la columna para que puedan chequear si no se presento
        dtAlumnos.Columns.Add("nsp", GetType(Boolean))
        For Each fila1 As DataRow In dtAlumnos.Rows
            fila1.Item("nsp") = False
        Next
        grAlumnos.DataSource = dtAlumnos
        grAlumnos.RetrieveStructure()

        With grAlumnos.RootTable.Columns("emznfact")
            .Caption = "Nº fact".ToUpper
            .Width = 80
            .TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .CellStyle.BackColor = Color.AliceBlue
            .AllowSort = False
        End With

        With grAlumnos.RootTable.Columns("emnumi")
            .Visible = False
        End With
        With grAlumnos.RootTable.Columns("fila")
            .Caption = "Nº".ToUpper
            .Width = 30
            .Visible = False
        End With

        With grAlumnos.RootTable.Columns("elnumi")
            .Caption = "cod".ToUpper
            .Width = 50
            .Visible = False
        End With

        With grAlumnos.RootTable.Columns("emnopc")
            .Caption = "Nº Opcion".ToUpper
            .Width = 70
            .TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .CellStyle.BackColor = Color.AliceBlue
            .AllowSort = False

        End With

        With grAlumnos.RootTable.Columns("emtipo")
            .Visible = False
        End With

        With grAlumnos.RootTable.Columns("emtipo2")
            .Caption = "tipo".ToUpper
            .Width = 90
            .TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .CellStyle.BackColor = Color.AliceBlue
            .AllowSort = False

        End With

        With grAlumnos.RootTable.Columns("emfecha")
            .Caption = "Fecha".ToUpper
            .Width = 90
            .TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .AllowSort = False

        End With

        With grAlumnos.RootTable.Columns("elci")
            .Caption = "ci".ToUpper
            .Width = 60
            .AllowSort = False

        End With

        With grAlumnos.RootTable.Columns("elnom")
            .Caption = "nombre".ToUpper
            .Width = 180
            .AllowSort = False

        End With

        With grAlumnos.RootTable.Columns("elapem")
            .Caption = "apellido mat.".ToUpper
            .Width = 130
            .AllowSort = False

        End With

        With grAlumnos.RootTable.Columns("elapep")
            .Caption = "apellido pat.".ToUpper
            .Width = 130
            .AllowSort = False

        End With

        With grAlumnos.RootTable.Columns("elfnac")
            .Caption = "fecha nac.".ToUpper
            .Width = 100
            .AllowSort = False

        End With

        With grAlumnos.RootTable.Columns("img")
            .Caption = "foto".ToUpper
            .Width = 70
            .TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.ImageHorizontalAlignment = Janus.Windows.GridEX.ImageHorizontalAlignment.Center
            .CellStyle.ImageVerticalAlignment = Janus.Windows.GridEX.ImageVerticalAlignment.Center
            .Visible = False
        End With

        With grAlumnos.RootTable.Columns("elcatlic")
            .Visible = False
        End With

        With grAlumnos.RootTable.Columns("elfot")
            .Visible = False
        End With

        With grAlumnos.RootTable.Columns("cedesc1")
            .Caption = "Cat. lic.".ToUpper
            .Width = 70
            .AllowSort = False

        End With

        With grAlumnos.RootTable.Columns("elesc")
            .Visible = False
        End With

        With grAlumnos.RootTable.Columns("elesc2")
            .Caption = "escuela".ToUpper
            .Width = 80
            .AllowSort = False

        End With

        With grAlumnos.RootTable.Columns("seleccionar")
            .Caption = "check".ToUpper
            .Width = 80
            .AllowSort = False

        End With

        With grAlumnos.RootTable.Columns("emestado")
            .Visible = tbTipoRep.Value

            .Caption = "Resultado".ToUpper
            .Width = 60

            .HasValueList = True
            'Set EditType to Combo or DropDownList.
            'In a MultipleValues Column, the dropdown will appear with a CheckBox
            'at the left of each item to let the user select multiple items
            .EditType = EditType.DropDownList
            .ValueList.PopulateValueList(dtEstados.DefaultView, "numi", "desc")
            .CompareTarget = ColumnCompareTarget.Text
            .DefaultGroupInterval = GroupInterval.Text
            .AllowSort = False

        End With

        With grAlumnos.RootTable.Columns("ordenCatLic")
            .Visible = False
        End With

        With grAlumnos.RootTable.Columns("nsp")
            .Caption = "R/NSP".ToUpper
            .Width = 80
            .AllowSort = False
            .Visible = tbTipoRep.Value
        End With

        'Habilitar Filtradores
        With grAlumnos
            .DefaultFilterRowComparison = FilterConditionOperator.Contains
            .FilterMode = FilterMode.Automatic
            .FilterRowUpdateMode = FilterRowUpdateMode.WhenValueChanges
            .GroupByBoxVisible = False
            'diseño de la grilla
            .VisualStyle = VisualStyle.Office2007
        End With


    End Sub



    Private Sub _prCambiarEstados()
        Dim dtReporte As DataTable = L_prExamenAlumnoCertiGeneralReporteExamenTeoricoEstructura()
        Dim dtReportePrac As DataTable = L_prExamenAlumnoCertiGeneralReporteExamenTeoricoEstructura()
        Dim j As Integer = 0
        With grAlumnos
            For i = 0 To .RowCount - 1
                .Row = i
                Dim numiLine As Integer = .GetValue("emnumi")
                Dim check As String = .GetValue("seleccionar")
                If check = "True" Then
                    L_prExamenAlumnoCertiModificarEstado(numiLine, 1)
                    Dim nroFact, numiAlum, ci, nom, apePat, apeMat, fnac, numiCatLic, catLic, foto, numiEsc, escuela As String

                    numiAlum = .GetValue("elnumi")
                    nroFact = .GetValue("emznfact")
                    ci = .GetValue("elci")
                    nom = .GetValue("elnom")
                    apePat = .GetValue("elapep")
                    apeMat = .GetValue("elapem")
                    fnac = .GetValue("elfnac")
                    numiCatLic = .GetValue("elcatlic")
                    catLic = .GetValue("cedesc1")
                    foto = .GetValue("elfot")
                    numiEsc = .GetValue("elesc")
                    escuela = .GetValue("elesc2")

                    'cargo los datos para el reporte teorico
                    dtReporte.Rows.Add(j + 1,
                                       j + 1,
                                       j + 1,
                                       .GetValue("elci"),
                                       nom = .GetValue("elnom"),
                                       .GetValue("elapep"),
                                       .GetValue("elapem"),
                                       New Date(1990, 1, 1),
                                       .GetValue("elcatlic"),
                                       .GetValue("cedesc1"),
                                       .GetValue("elfot"),
                                       .GetValue("elesc"),
                                       .GetValue("elesc2"),
                                       Nothing)
                    'cargo los datos para el reporte practico
                    dtReportePrac.Rows.Add(j + 1,
                                       j + 1,
                                       j + 1,
                                       .GetValue("elci"),
                                       nom = .GetValue("elnom"),
                                       .GetValue("elapep"),
                                       .GetValue("elapem"),
                                       New Date(1990, 1, 1),
                                       .GetValue("elcatlic"),
                                       .GetValue("cedesc1"),
                                       .GetValue("elfot"),
                                       .GetValue("elesc"),
                                       .GetValue("elesc2"),
                                       Nothing)

                    j = j + 1
                End If

            Next
        End With

        Dim info As New TaskDialogInfo("impresion".ToUpper, eTaskDialogIcon.Delete, j.ToString + " formularios de examen practico".ToUpper, "¿Desea imprimir los formularios de examen práctico de los alumnos?".ToUpper, eTaskDialogButton.Yes Or eTaskDialogButton.Cancel, eTaskDialogBackgroundColor.Blue)
        Dim result As eTaskDialogResult = TaskDialog.Show(info)
        If result = eTaskDialogResult.Yes Then
            _prImprimirFormulariosDeExamen()
        End If



        _prCargarReporteTeorico(dtReporte)
        _prCargarReportePractico(dtReporte)
        _prCargarGridAlumnos()

    End Sub

    Private Sub _prGenerarReportes()
        tbFecha.Focus()

        Dim dtReporte As DataTable = L_prExamenAlumnoCertiGeneralReporteExamenTeoricoEstructura()
        Dim dtReportePrac As DataTable = L_prExamenAlumnoCertiGeneralReporteExamenTeoricoEstructura()
        Dim j As Integer = 0
        'With grAlumnos
        '    For i = 0 To .RowCount - 1
        '        .Row = i
        '        Dim numiLine As Integer = .GetValue("emnumi")
        '        Dim check As String = .GetValue("seleccionar")
        '        If check = "True" Then
        '            'L_prExamenAlumnoCertiModificarEstado(numiLine, 1)
        '            Dim nroFact, numiAlum, ci, nom, apePat, apeMat, fnac, numiCatLic, catLic, foto, numiEsc, escuela, nroOpcion, estado As String

        '            numiAlum = .GetValue("elnumi")
        '            nroFact = .GetValue("emznfact")
        '            ci = .GetValue("elci")
        '            nom = .GetValue("elnom")
        '            apePat = .GetValue("elapep")
        '            apeMat = .GetValue("elapem")
        '            fnac = .GetValue("elfnac")
        '            numiCatLic = .GetValue("elcatlic")
        '            catLic = .GetValue("cedesc1")
        '            foto = .GetValue("elfot")
        '            numiEsc = .GetValue("elesc")
        '            escuela = .GetValue("elesc2")
        '            nroOpcion = .GetValue("emnopc")
        '            estado = .GetValue("emestado")

        '            Dim tipo As Integer = .GetValue("emtipo")

        '            'cargo los datos para el reporte teorico
        '            If tipo = 1 Then
        '                dtReporte.Rows.Add(j + 1,
        '                               j + 1,
        '                               j + 1,
        '                               .GetValue("elci"),
        '                               .GetValue("elnom"),
        '                               .GetValue("elapep"),
        '                               .GetValue("elapem"),
        '                               .GetValue("elfnac"),
        '                               .GetValue("elcatlic"),
        '                               .GetValue("cedesc1"),
        '                               .GetValue("elfot"),
        '                               .GetValue("elesc"),
        '                               .GetValue("elesc2"),
        '                               Nothing,
        '                               True,
        '                               .GetValue("emnopc"),
        '                               estado)
        '            End If

        '            'cargo los datos para el reporte practico
        '            If tipo = 2 Then
        '                dtReportePrac.Rows.Add(j + 1,
        '                               j + 1,
        '                               j + 1,
        '                               .GetValue("elci"),
        '                               .GetValue("elnom"),
        '                               .GetValue("elapep"),
        '                               .GetValue("elapem"),
        '                               .GetValue("elfnac"),
        '                               .GetValue("elcatlic"),
        '                               .GetValue("cedesc1"),
        '                               .GetValue("elfot"),
        '                               .GetValue("elesc"),
        '                               .GetValue("elesc2"),
        '                               Nothing,
        '                               True,
        '                               .GetValue("emnopc"),
        '                               estado)
        '            End If

        '            j = j + 1
        '        End If

        '    Next
        'End With

        Dim dtGrAlumnos As DataTable = CType(grAlumnos.DataSource, DataTable)
        Dim dtfilasAlumnos As Janus.Windows.GridEX.GridEXRow() = grAlumnos.GetRows
        With dtfilasAlumnos
            For i = 0 To .Count - 1
                Dim numiLine As Integer = dtfilasAlumnos(i).Cells("emnumi").Value '.Rows(i).Item("emnumi")
                Dim check As String = dtfilasAlumnos(i).Cells("seleccionar").Value
                If check = "True" Then
                    'L_prExamenAlumnoCertiModificarEstado(numiLine, 1)
                    Dim nroFact, numiAlum, ci, nom, apePat, apeMat, fnac, numiCatLic, catLic, foto, numiEsc, escuela, nroOpcion, estado As String

                    numiAlum = dtfilasAlumnos(i).Cells("elnumi").Value
                    nroFact = dtfilasAlumnos(i).Cells("emznfact").Value
                    ci = dtfilasAlumnos(i).Cells("elci").Value
                    nom = dtfilasAlumnos(i).Cells("elnom").Value
                    apePat = dtfilasAlumnos(i).Cells("elapep").Value
                    apeMat = dtfilasAlumnos(i).Cells("elapem").Value
                    fnac = dtfilasAlumnos(i).Cells("elfnac").Value
                    numiCatLic = dtfilasAlumnos(i).Cells("elcatlic").Value
                    catLic = dtfilasAlumnos(i).Cells("cedesc1").Value
                    foto = dtfilasAlumnos(i).Cells("elfot").Value
                    numiEsc = dtfilasAlumnos(i).Cells("elesc").Value
                    escuela = dtfilasAlumnos(i).Cells("elesc2").Value
                    nroOpcion = dtfilasAlumnos(i).Cells("emnopc").Value
                    estado = dtfilasAlumnos(i).Cells("emestado").Value

                    If tbTipoRep.Value = True Then
                        If estado = 5 Then
                            L_prExamenAlumnoCertiModificarEstado(numiLine, "3")
                            estado = 3
                        End If
                        If estado = 4 Then
                            L_prExamenAlumnoCertiModificarEstado(numiLine, "4")

                        End If
                    End If

                    Dim tipo As Integer = dtfilasAlumnos(i).Cells("emtipo").Value

                    'cargo los datos para el reporte teorico
                    If tipo = 1 Then
                        dtReporte.Rows.Add(j + 1,
                                       j + 1,
                                       j + 1,
                                       dtfilasAlumnos(i).Cells("elci").Value,
                                       dtfilasAlumnos(i).Cells("elnom").Value,
                                       dtfilasAlumnos(i).Cells("elapep").Value,
                                       dtfilasAlumnos(i).Cells("elapem").Value,
                                       dtfilasAlumnos(i).Cells("elfnac").Value,
                                       dtfilasAlumnos(i).Cells("elcatlic").Value,
                                       dtfilasAlumnos(i).Cells("cedesc1").Value,
                                       dtfilasAlumnos(i).Cells("elfot").Value,
                                       dtfilasAlumnos(i).Cells("elesc").Value,
                                       dtfilasAlumnos(i).Cells("elesc2").Value,
                                       Nothing,
                                       True,
                                       dtfilasAlumnos(i).Cells("emnopc").Value,
                                       estado)
                    End If

                    'cargo los datos para el reporte practico
                    If tipo = 2 Then
                        dtReportePrac.Rows.Add(j + 1,
                                       j + 1,
                                       j + 1,
                                       dtfilasAlumnos(i).Cells("elci").Value,
                                       dtfilasAlumnos(i).Cells("elnom").Value,
                                       dtfilasAlumnos(i).Cells("elapep").Value,
                                       dtfilasAlumnos(i).Cells("elapem").Value,
                                       dtfilasAlumnos(i).Cells("elfnac").Value,
                                       dtfilasAlumnos(i).Cells("elcatlic").Value,
                                       dtfilasAlumnos(i).Cells("cedesc1").Value,
                                       dtfilasAlumnos(i).Cells("elfot").Value,
                                       dtfilasAlumnos(i).Cells("elesc").Value,
                                       dtfilasAlumnos(i).Cells("elesc2").Value,
                                       Nothing,
                                       True,
                                       dtfilasAlumnos(i).Cells("emnopc").Value,
                                       estado)
                    End If

                    j = j + 1
                End If

            Next
        End With

        'Dim filasFiltradas As DataRow() = dtReporte.Select("1=1", "emnopc asc")
        'Dim k As Integer = 1
        'For Each fila As DataRow In filasFiltradas
        '    fila.Item("fila") = k
        '    fila.Item("emnumi") = k
        '    fila.Item("elnumi") = k
        '    k = k + 1
        'Next
        'If filasFiltradas.Count > 0 Then
        '    dtReporte = filasFiltradas.CopyToDataTable
        'End If

        'enumerar las filas de acuerdo al numero de opcion en la lista teorica
        Dim fx As Integer = 1

        For Each fila As DataRow In dtReporte.Rows

            If fila.Item("emnopc") = 1 Then
                fila.Item("fila") = fx
                fila.Item("emnumi") = fx
                fila.Item("elnumi") = fx
                fx = fx + 1
            Else

            End If

        Next

        For Each fila As DataRow In dtReporte.Rows

            If fila.Item("emnopc") = 1 Then

            Else
                fila.Item("fila") = fx
                fila.Item("emnumi") = fx
                fila.Item("elnumi") = fx
                fx = fx + 1
            End If

        Next

        'enumerar las filas de acuerdo al numero de opcion en la lista practica
        fx = 1

        For Each fila As DataRow In dtReportePrac.Rows
            If fila.Item("emnopc") = 1 Then
                fila.Item("fila") = fx
                fila.Item("emnumi") = fx
                fila.Item("elnumi") = fx
                fx = fx + 1
            Else

            End If

        Next

        For Each fila As DataRow In dtReportePrac.Rows
            If fila.Item("emnopc") = 1 Then

            Else
                fila.Item("fila") = fx
                fila.Item("emnumi") = fx
                fila.Item("elnumi") = fx
                fx = fx + 1
            End If

        Next

        If tbForm.Checked = True Or tbPrac.Checked = True Or tbTeo.Checked = True Then
            'If PrintDialog1.ShowDialog = DialogResult.OK Then

            'End If

            If tbTeo.Checked = True Then
                _prCargarReporteTeorico(dtReporte)
            End If

            If tbPrac.Checked = True Then
                '_prCargarReportePractico(dtReporte)
                _prCargarReportePractico(dtReportePrac)
            End If

            If tbForm.Checked = True Then
                _prImprimirFormulariosDeExamen()
            End If
        End If

        _prCargarGridAlumnos()
        'tbFiltFecha.Value = False
    End Sub


    Private Sub _prImprimirFormulariosDeExamen()
        Dim dtFinal As DataTable = L_prNotasPreguntasPorRegistro(-1, "", "")
        dtFinal.Rows.Clear()
        Dim cantidadFormularios As Integer = 0
        With grAlumnos
            For i = 0 To .RowCount - 1
                .Row = i
                Dim check As String = .GetValue("seleccionar")
                Dim tipo As Integer = .GetValue("emtipo")
                If check = "True" And tipo = 2 Then
                    cantidadFormularios = cantidadFormularios + 1
                    'Dim nroFact, numiAlum, ci, nom, apePat, apeMat, numiCatLic, catLic, edad As String
                    Dim foto As String
                    'Dim fnac As Date
                    'numiAlum = .GetValue("elnumi")
                    'nroFact = .GetValue("emznfact")
                    'ci = .GetValue("elci")
                    'nom = .GetValue("elnom")
                    'apePat = .GetValue("elapep")
                    'apeMat = .GetValue("elapem")
                    'fnac = .GetValue("elfnac")
                    'numiCatLic = .GetValue("elcatlic")
                    'catLic = .GetValue("cedesc1")
                    foto = .GetValue("elfot")

                    'edad = DateDiff("yyyy", fnac, Now.Date)

                    'Dim dtRegPrac As DataTable = L_prExamenAlumnoCertiGeneralRegistrosPorNroFactura(nroFact, numiAlum, 2)
                    'Dim fecha As String = CType(dtRegPrac.Rows(dtRegPrac.Rows.Count - 1).Item("emfecha"), Date).ToString("dd/MM/yyyy")

                    '_prCargarReporteFormularioExamen(nom, apePat, apeMat, fecha, ci, edad, numiCatLic, catLic, foto)

                    Dim numiReg As String = .GetValue("emnumi")
                    Dim dtPreguntas As DataTable = L_prNotasPreguntasPorRegistro(numiReg, gs_CarpetaRaiz + "\Imagenes Categorias\" + "categoria_", _ruta)

                    '---------------------------------------------------------------------------------------
                    'Dim direccionFoto As String = ""

                    'Dim img As Bitmap
                    'If (IO.File.Exists(_ruta + foto)) Then
                    '    img = New Bitmap(_ruta + foto)
                    '    'img = New Bitmap("C:\Imagenes\ACB\Imagenes\Imagenes Alumnos Certificacion\alum_cert_20.jpg")

                    '    direccionFoto = _ruta + foto
                    '    For Each fila1 As DataRow In dtPreguntas.Rows
                    '        fila1.Item("foto") = _fnImageToByteArrayParaReporte(direccionFoto)
                    '        'img = New Bitmap(_ruta + foto)
                    '        'fila1.Item("foto") = _fnImageToByteArray(img)
                    '        'fila1.Item("foto") = _fnBytesArchivo(direccionFoto)
                    '    Next
                    '    '_dt.Rows(0).Item("foto") = _fnImageToByteArray(img)
                    '    '_dt.Rows(0).Item("foto") = _fnBytesArchivo(direccionFoto)
                    'End If
                    '-------------------------------------------------------------------------------------------

                    Dim j As Integer = 0
                    Dim numiTipo As Integer = -1 'dtReg.Rows(0).Item("entipo")


                    For l = 0 To dtPreguntas.Rows.Count - 1
                        If numiTipo <> dtPreguntas.Rows(l).Item("entipo") Then
                            j = 1
                            numiTipo = dtPreguntas.Rows(l).Item("entipo")
                        Else
                            j = j + 1
                        End If
                        dtPreguntas.Rows(l).Item("num") = j
                    Next

                    dtFinal.Merge(dtPreguntas)


                End If

            Next
        End With


        Dim info As New TaskDialogInfo("impresion".ToUpper, eTaskDialogIcon.Delete, cantidadFormularios.ToString + " formularios de examen practico".ToUpper, "¿Desea imprimir los formularios de examen práctico de los alumnos?".ToUpper, eTaskDialogButton.Yes Or eTaskDialogButton.Cancel, eTaskDialogBackgroundColor.Blue)
        Dim result As eTaskDialogResult = TaskDialog.Show(info)
        If result = eTaskDialogResult.Yes Then
            'ahora mando a imprimir el reporte con todo consolidado
            Dim objrep As New R_ReporteFormularioExamen2

            'objrep.PrintOptions.PrinterName = PrintDialog1.PrinterSettings.PrinterName
            'objrep.SetDataSource(dtFinal)

            'objrep.PrintToPrinter(1, False, 1, 10)

            P_Global.Visualizador = New Visualizador
            objrep.SetDataSource(dtFinal)

            P_Global.Visualizador.CRV1.ReportSource = objrep 'Comentar
            P_Global.Visualizador.Show() 'Comentar
            P_Global.Visualizador.BringToFront() 'Comentar
        End If




    End Sub

    Private Sub _prSeleccionarTodos()
        Dim dt As DataTable = CType(grAlumnos.DataSource, DataTable)
        'With grAlumnos
        '    For i = 0 To .RowCount - 1
        '        .Row = i
        '        .SetValue("seleccionar", True)
        '    Next
        'End With
        For Each fila As DataRow In dt.Rows
            fila.Item("seleccionar") = True
        Next
    End Sub

    Private Sub _prCargarReporteFormularioExamen(nombre As String, apePat As String, apeMat As String, fecha As String, ci As String, edad As String, numiCatLic As String, catLic As String, foto As String)

        Dim _dt As New DataTable
        '_dt = L_prNotasPreguntasPorPorCategoriaYTipo(numiCatLic, 2) 'obtengo el formulario de preguntas teoricas
        _dt = L_prNotasPreguntasPorPorCategoria(numiCatLic) 'obtengo el formulario de preguntas practicas y tambien teoricas
        Dim direccionFoto As String = ""
        If (_dt.Rows.Count > 0) Then
            'imprimir el certificado
            Dim img As Bitmap
            If (IO.File.Exists(_ruta + foto)) Then
                img = New Bitmap(_ruta + foto)
                'img = New Bitmap("C:\Imagenes\ACB\Imagenes\Imagenes Alumnos Certificacion\alum_cert_20.jpg")

                direccionFoto = _ruta + foto
                For Each fila1 As DataRow In _dt.Rows
                    fila1.Item("foto") = _fnImageToByteArrayParaReporte(direccionFoto)
                    'img = New Bitmap(_ruta + foto)
                    'fila1.Item("foto") = _fnImageToByteArray(img)
                    'fila1.Item("foto") = _fnBytesArchivo(direccionFoto)
                Next
                '_dt.Rows(0).Item("foto") = _fnImageToByteArray(img)
                '_dt.Rows(0).Item("foto") = _fnBytesArchivo(direccionFoto)
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

            objrep.PrintOptions.PrinterName = PrintDialog1.PrinterSettings.PrinterName
            objrep.SetDataSource(_dt)

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


            'Dim direccionFotoPng As String = ""
            'If direccionFoto = "" Then
            '    direccionFotoPng = direccionFoto.Substring(0, direccionFoto.Count - 4) + ".png"
            'End If

            'If IO.File.Exists(direccionFotoPng) = False Then
            '    'Dim image1 As System.Drawing.Image = System.Drawing.Image.FromFile(direccionaFoto)
            '    'image1.Save(direccionaFoto, System.Drawing.Imaging.ImageFormat.Jpeg) 'image1, System.Drawing.Imaging.ImageFormat.Jpeg
            '    ''FileCopy(direccionFoto, direccionFotoPng)
            'End If
            ''objrep.SetParameterValue("DirImgFoto", direccionFoto) 'direccionFotoPng

            objrep.PrintToPrinter(1, False, 1, 10)


        End If
    End Sub

    Public Function _fnBytesArchivo(ruta As String) As Byte()

        If Not (ruta.Equals(" ")) Then ' esta sería una función que verifica que realmente existe el archivo, devolviendo true o false...

            Return IO.File.ReadAllBytes(ruta)

        Else

            Throw New Exception("No se encuentra el archivo: " & ruta)

        End If

    End Function
#End Region


    Private Sub F0_ListaExamenCerti_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _prIniciarTodo()
    End Sub

    Private Sub btnGrabar_Click(sender As Object, e As EventArgs) Handles btnGrabar.Click
        '_prCambiarEstados()
        _prCargarGridAlumnos()
        'tbFiltFecha.Value = False
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        _prCargarReporteListaPractico()
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        _prGenerarReportes()
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btMarcarTodos_Click(sender As Object, e As EventArgs) Handles btMarcarTodos.Click
        _prSeleccionarTodos()
    End Sub

    Private Sub grAlumnos_EditingCell(sender As Object, e As EditingCellEventArgs) Handles grAlumnos.EditingCell
        If e.Column.Key = "seleccionar" Or e.Column.Key = "nsp" Then
            e.Cancel = False
        Else
            e.Cancel = True
        End If

    End Sub

    Private Sub tbFecha_ValueChanged(sender As Object, e As EventArgs) Handles tbFecha.ValueChanged
        'If (tbFiltFecha.Value) Then
        '    grAlumnos.RemoveFilters()
        '    grAlumnos.RootTable.ApplyFilter(New Janus.Windows.GridEX.GridEXFilterCondition(grAlumnos.RootTable.Columns("emfecha"), Janus.Windows.GridEX.ConditionOperator.Equal, tbFecha.Value.ToString("dd/MM/yyyy")))
        'End If
        _prCargarGridAlumnos()
    End Sub

    Private Sub tbFiltFecha_ValueChanged(sender As Object, e As EventArgs)
        'If (tbFiltFecha.Value) Then
        '    grAlumnos.RemoveFilters()
        '    grAlumnos.RootTable.ApplyFilter(New Janus.Windows.GridEX.GridEXFilterCondition(grAlumnos.RootTable.Columns("emfecha"), Janus.Windows.GridEX.ConditionOperator.Equal, tbFecha.Value.ToString("dd/MM/yyyy")))
        'Else
        '    grAlumnos.RemoveFilters()
        'End If
        _prCargarGridAlumnos()

    End Sub

    Private Sub ButtonX1_Click(sender As Object, e As EventArgs) Handles ButtonX1.Click
        Dim direccion As String = gs_CarpetaRaiz + "\Certificacion\PDF\"
        If (IO.File.Exists(direccion) = True) Then
            Process.Start(direccion)

        End If
    End Sub

    Private Sub tbTipoRep_ValueChanged(sender As Object, e As EventArgs) Handles tbTipoRep.ValueChanged
        With grAlumnos.RootTable.Columns("emestado")
            .Visible = tbTipoRep.Value
        End With

        With grAlumnos.RootTable.Columns("nsp")
            .Visible = tbTipoRep.Value
        End With
    End Sub

    Private Sub grAlumnos_RecordUpdated(sender As Object, e As EventArgs) Handles grAlumnos.RecordUpdated

    End Sub

    Private Sub grAlumnos_CellEdited(sender As Object, e As ColumnActionEventArgs) Handles grAlumnos.CellEdited
        If grAlumnos.Row >= 0 Then
            If e.Column.Key = "nsp" Then
                Dim estado As Integer = grAlumnos.GetValue("emestado")
                Dim valor As Boolean = grAlumnos.GetValue("nsp")
                If estado <> 2 And estado <> 3 Then
                    If valor = True Then
                        grAlumnos.SetValue("emestado", 5)
                    Else
                        grAlumnos.SetValue("emestado", 4)

                    End If
                End If


            End If
        End If
    End Sub

    Private Sub tbSuc_ValueChanged(sender As Object, e As EventArgs) Handles tbSuc.ValueChanged
        _prCargarGridAlumnos()

    End Sub
End Class