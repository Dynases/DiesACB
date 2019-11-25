Imports DevComponents.DotNetBar.SuperGrid
Imports Logica.AccesoLogica


Public Class F0_ListaExamenPracticoCerti2
#Region "VARIABLES LOCALES"
    Private _ruta As String = gs_CarpetaRaiz + "\Imagenes\Imagenes Alumnos Certificacion\"
    Private _fuenteTamano As Integer = 10
#End Region

#Region "METODOS PRIVADOS"
    Private Sub _prIniciarTodo()
        Me.Text = "l i s t a    d e    p o s t u l a n t e s    e x a m e n     p r a c t i c o ".ToUpper
        Me.WindowState = FormWindowState.Maximized
        _prCargarGridAlumnos()
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
    Private Sub _prCargarGridAlumnos()
        Dim dtAlumnos As DataTable
        dtAlumnos = L_prExamenAlumnoCertiGeneralReporteExamenPractico()

        'elnumi,elci,elnom,elapep,elapem,elfnac,elcatlic,elfot,elesc,elesc2,elest,elest2,elalumnumi

        grAlumnos.PrimaryGrid.Columns.Clear()
        grAlumnos.PrimaryGrid.Columns.Add(New GridColumn("emnumi"))
        grAlumnos.PrimaryGrid.Columns.Add(New GridColumn("fila"))
        grAlumnos.PrimaryGrid.Columns.Add(New GridColumn("elnumi"))
        grAlumnos.PrimaryGrid.Columns.Add(New GridColumn("elci"))
        grAlumnos.PrimaryGrid.Columns.Add(New GridColumn("elnom"))
        grAlumnos.PrimaryGrid.Columns.Add(New GridColumn("elapep"))
        grAlumnos.PrimaryGrid.Columns.Add(New GridColumn("elapem"))
        grAlumnos.PrimaryGrid.Columns.Add(New GridColumn("elfnac"))
        grAlumnos.PrimaryGrid.Columns.Add(New GridColumn("elcatlic"))
        grAlumnos.PrimaryGrid.Columns.Add(New GridColumn("cedesc1"))
        grAlumnos.PrimaryGrid.Columns.Add(New GridColumn("elfot"))
        grAlumnos.PrimaryGrid.Columns.Add(New GridColumn("elesc"))
        grAlumnos.PrimaryGrid.Columns.Add(New GridColumn("elesc2"))
        grAlumnos.PrimaryGrid.Columns.Add(New GridColumn("img"))
        grAlumnos.PrimaryGrid.Columns.Add(New GridColumn("seleccionar"))

        With grAlumnos.PrimaryGrid.Columns("emnumi")
            .Visible = True
        End With
        With grAlumnos.PrimaryGrid.Columns("fila")
            .HeaderText = "Nº".ToUpper
            .Width = 30
            .EditorType = GetType(DevComponents.DotNetBar.SuperGrid.GridTextBoxXEditControl)
            .CellStyles.Default.Font = New Font("Arial", _fuenteTamano)
            .ReadOnly = True
            .CellStyles.Default.Alignment = Style.Alignment.MiddleLeft
        End With

        With grAlumnos.PrimaryGrid.Columns("elnumi")
            .HeaderText = "cod".ToUpper
            .Width = 50
            .EditorType = GetType(DevComponents.DotNetBar.SuperGrid.GridTextBoxXEditControl)
            .CellStyles.Default.Font = New Font("Arial", _fuenteTamano)
            .ReadOnly = True
            .Visible = False
            .CellStyles.Default.Alignment = Style.Alignment.MiddleLeft
        End With

        With grAlumnos.PrimaryGrid.Columns("elci")
            .HeaderText = "ci".ToUpper
            .Width = 60
            .EditorType = GetType(DevComponents.DotNetBar.SuperGrid.GridTextBoxXEditControl)
            .CellStyles.Default.Font = New Font("Arial", _fuenteTamano)
            .ReadOnly = True
            .CellStyles.Default.Alignment = Style.Alignment.MiddleRight
        End With

        With grAlumnos.PrimaryGrid.Columns("elnom")
            .HeaderText = "nombre".ToUpper
            .Width = 200
            .EditorType = GetType(DevComponents.DotNetBar.SuperGrid.GridTextBoxXEditControl)
            .CellStyles.Default.Font = New Font("Arial", _fuenteTamano)
            .ReadOnly = True
            .CellStyles.Default.Alignment = Style.Alignment.MiddleLeft
        End With

        With grAlumnos.PrimaryGrid.Columns("elapem")
            .HeaderText = "apellido mat.".ToUpper
            .Width = 150
            .EditorType = GetType(DevComponents.DotNetBar.SuperGrid.GridTextBoxXEditControl)
            .CellStyles.Default.Font = New Font("Arial", _fuenteTamano)
            .ReadOnly = True
            .CellStyles.Default.Alignment = Style.Alignment.MiddleLeft
        End With

        With grAlumnos.PrimaryGrid.Columns("elapep")
            .HeaderText = "apellido pat.".ToUpper
            .Width = 150
            .EditorType = GetType(DevComponents.DotNetBar.SuperGrid.GridTextBoxXEditControl)
            .CellStyles.Default.Font = New Font("Arial", _fuenteTamano)
            .ReadOnly = True
            .CellStyles.Default.Alignment = Style.Alignment.MiddleLeft
        End With

        With grAlumnos.PrimaryGrid.Columns("elfnac")
            .HeaderText = "fecha nac.".ToUpper
            .Width = 100
            .EditorType = GetType(DevComponents.DotNetBar.SuperGrid.GridTextBoxXEditControl)
            .CellStyles.Default.Font = New Font("Arial", _fuenteTamano)
            .ReadOnly = True
            .CellStyles.Default.Alignment = Style.Alignment.MiddleRight
        End With



        With grAlumnos.PrimaryGrid.Columns("img")
            .HeaderText = "foto".ToUpper
            .Width = 70
            .EditorType = GetType(DevComponents.DotNetBar.SuperGrid.GridTextBoxXEditControl)
            .CellStyles.Default.Font = New Font("Arial", _fuenteTamano)
            .ReadOnly = True
            .CellStyles.Default.Alignment = Style.Alignment.MiddleCenter
        End With

        With grAlumnos.PrimaryGrid.Columns("elcatlic")
            .Visible = False
        End With

        With grAlumnos.PrimaryGrid.Columns("elfot")
            .Visible = False
        End With

        With grAlumnos.PrimaryGrid.Columns("emnumi")
            .Visible = False
        End With

        With grAlumnos.PrimaryGrid.Columns("cedesc1")
            .HeaderText = "Cat. lic.".ToUpper
            .Width = 60
            .EditorType = GetType(DevComponents.DotNetBar.SuperGrid.GridTextBoxXEditControl)
            .CellStyles.Default.Font = New Font("Arial", _fuenteTamano)
            .ReadOnly = True
            .CellStyles.Default.Alignment = Style.Alignment.MiddleCenter
        End With

        With grAlumnos.PrimaryGrid.Columns("elesc")
            .Visible = False
        End With

        With grAlumnos.PrimaryGrid.Columns("elesc2")
            .HeaderText = "escuela".ToUpper
            .Width = 80
            .EditorType = GetType(DevComponents.DotNetBar.SuperGrid.GridCheckBoxEditControl)
            .ReadOnly = True
        End With

        With grAlumnos.PrimaryGrid.Columns("seleccionar")
            .HeaderText = "check".ToUpper
            .Width = 80
            .EditorType = GetType(DevComponents.DotNetBar.SuperGrid.GridCheckBoxEditControl)
            .ReadOnly = False
        End With


        P_LlenarDatosGrid(dtAlumnos)

    End Sub

    Private Sub P_LlenarDatosGrid(dt As DataTable)
        grAlumnos.PrimaryGrid.Rows.Clear()

        Dim _fil As GridRow
        Dim _cel As GridCell

        'elnumi,elci,elnom,elapep,elapem,elfnac,elcatlic,elfot,elesc,elesc2,elest,elest2,elalumnumi
        Dim i As Integer = 1
        For Each _f As DataRow In dt.Rows
            _fil = New GridRow
            _fil.RowHeight = 50

            _cel = New GridCell
            _cel.EditorType = GetType(DevComponents.DotNetBar.SuperGrid.GridTextBoxXEditControl)
            _cel.Value = _f.Item("emnumi").ToString
            _fil.Cells.Add(_cel)

            _cel = New GridCell
            _cel.EditorType = GetType(DevComponents.DotNetBar.SuperGrid.GridTextBoxXEditControl)
            _cel.Value = i '_f.Item("fila").ToString
            _fil.Cells.Add(_cel)

            _cel = New GridCell
            _cel.EditorType = GetType(DevComponents.DotNetBar.SuperGrid.GridTextBoxXEditControl)
            _cel.Value = _f.Item("elnumi").ToString
            _fil.Cells.Add(_cel)

            _cel = New GridCell
            _cel.EditorType = GetType(DevComponents.DotNetBar.SuperGrid.GridTextBoxXEditControl)
            _cel.Value = _f.Item("elci").ToString
            _fil.Cells.Add(_cel)

            _cel = New GridCell
            _cel.EditorType = GetType(DevComponents.DotNetBar.SuperGrid.GridTextBoxXEditControl)
            _cel.Value = _f.Item("elnom").ToString
            _fil.Cells.Add(_cel)

            _cel = New GridCell
            _cel.EditorType = GetType(DevComponents.DotNetBar.SuperGrid.GridTextBoxXEditControl)
            _cel.Value = _f.Item("elapep").ToString
            _fil.Cells.Add(_cel)

            _cel = New GridCell
            _cel.EditorType = GetType(DevComponents.DotNetBar.SuperGrid.GridTextBoxXEditControl)
            _cel.Value = _f.Item("elapem").ToString
            _fil.Cells.Add(_cel)

            _cel = New GridCell
            _cel.EditorType = GetType(DevComponents.DotNetBar.SuperGrid.GridTextBoxXEditControl)
            _cel.Value = CType(_f.Item("elfnac"), Date).ToString("dd/MM/yyyy")
            _fil.Cells.Add(_cel)

            _cel = New GridCell
            _cel.EditorType = GetType(DevComponents.DotNetBar.SuperGrid.GridTextBoxXEditControl)
            _cel.Value = _f.Item("elcatlic").ToString
            _fil.Cells.Add(_cel)

            _cel = New GridCell
            _cel.EditorType = GetType(DevComponents.DotNetBar.SuperGrid.GridTextBoxXEditControl)
            _cel.Value = _f.Item("cedesc1").ToString
            _fil.Cells.Add(_cel)

            _cel = New GridCell
            _cel.EditorType = GetType(DevComponents.DotNetBar.SuperGrid.GridTextBoxXEditControl)
            _cel.Value = _f.Item("elfot").ToString
            'Dim img As Bitmap
            'Dim img2 As Bitmap
            'If (IO.File.Exists(_ruta + _f.Item("elfot").ToString)) Then
            '    img = New Bitmap(_ruta + _f.Item("elfot").ToString)
            '    img2 = New Bitmap(img, 50, 50) 'img2 = New Bitmap(img, 40, 40)
            '    _cel.CellStyles.Default.Image = img2
            'End If
            _fil.Cells.Add(_cel)

            _cel = New GridCell
            _cel.EditorType = GetType(DevComponents.DotNetBar.SuperGrid.GridCheckBoxEditControl)
            _cel.Value = _f.Item("elesc").ToString
            _fil.Cells.Add(_cel)

            _cel = New GridCell
            _cel.EditorType = GetType(DevComponents.DotNetBar.SuperGrid.GridCheckBoxEditControl)
            _cel.Value = _f.Item("elesc2").ToString
            _fil.Cells.Add(_cel)

            _cel = New GridCell
            _cel.EditorType = GetType(DevComponents.DotNetBar.SuperGrid.GridTextBoxXEditControl)
            Dim img As Bitmap
            Dim img2 As Bitmap
            If (IO.File.Exists(_ruta + _f.Item("elfot").ToString)) Then
                img = New Bitmap(_ruta + _f.Item("elfot").ToString)
                img2 = New Bitmap(img, 50, 50) 'img2 = New Bitmap(img, 40, 40)
                _cel.CellStyles.Default.Image = img2
            End If
            _fil.Cells.Add(_cel)

            _cel = New GridCell
            _cel.EditorType = GetType(DevComponents.DotNetBar.SuperGrid.GridCheckBoxEditControl)
            _cel.Value = _f.Item("seleccionar").ToString
            _fil.Cells.Add(_cel)

            '_cel = New GridCell
            '_cel.EditorType = GetType(DevComponents.DotNetBar.SuperGrid.GridCheckBoxEditControl)
            '_cel.Value = _f.Item("elest").ToString
            '_fil.Cells.Add(_cel)

            '_cel = New GridCell
            '_cel.EditorType = GetType(DevComponents.DotNetBar.SuperGrid.GridCheckBoxEditControl)
            '_cel.Value = _f.Item("elest2").ToString
            '_fil.Cells.Add(_cel)

            '_cel = New GridCell
            '_cel.EditorType = GetType(DevComponents.DotNetBar.SuperGrid.GridCheckBoxEditControl)
            '_cel.Value = _f.Item("elalumnumi").ToString
            '_fil.Cells.Add(_cel)


            'Dim img As New Bitmap(My.Resources.GRABACION_EXITOSA)
            'Dim img2 As New Bitmap(img, 15, 15)
            '_f.Cells.Item("fdev").CellStyles.Default.Image = img2

            grAlumnos.PrimaryGrid.Rows.Add(_fil)
            i = i + 1
        Next
    End Sub

    Private Sub _prCambiarEstados()
        Dim dtReporte As DataTable = L_prExamenAlumnoCertiGeneralReporteExamenTeoricoEstructura()
        Dim j As Integer = 0
        With grAlumnos.PrimaryGrid
            For i = 0 To .Rows.Count - 1
                Dim numiLine As Integer = .GetCell(i, .Columns("emnumi").ColumnIndex).Value
                Dim check As String = .GetCell(i, .Columns("seleccionar").ColumnIndex).Value.ToString
                If check = "True" Then
                    L_prExamenAlumnoCertiModificarEstado(numiLine, 1)
                    Dim obj As String = .GetCell(i, .Columns("elci").ColumnIndex).Value
                    obj = .GetCell(i, .Columns("elci").ColumnIndex).Value
                    obj = .GetCell(i, .Columns("elnom").ColumnIndex).Value
                    obj = .GetCell(i, .Columns("elapep").ColumnIndex).Value
                    obj = .GetCell(i, .Columns("elfnac").ColumnIndex).Value
                    obj = .GetCell(i, .Columns("elcatlic").ColumnIndex).Value
                    obj = .GetCell(i, .Columns("cedesc1").ColumnIndex).Value
                    obj = .GetCell(i, .Columns("elfot").ColumnIndex).Value
                    obj = .GetCell(i, .Columns("elesc").ColumnIndex).Value
                    obj = .GetCell(i, .Columns("elesc2").ColumnIndex).Value


                    dtReporte.Rows.Add(j + 1,
                                       j + 1,
                                       j + 1,
                                       .GetCell(i, .Columns("elci").ColumnIndex).Value,
                                       .GetCell(i, .Columns("elnom").ColumnIndex).Value,
                                       .GetCell(i, .Columns("elapep").ColumnIndex).Value,
                                       .GetCell(i, .Columns("elapem").ColumnIndex).Value,
                                       New Date(1990, 1, 1),
                                       .GetCell(i, .Columns("elcatlic").ColumnIndex).Value,
                                       .GetCell(i, .Columns("cedesc1").ColumnIndex).Value,
                                       .GetCell(i, .Columns("elfot").ColumnIndex).Value,
                                       .GetCell(i, .Columns("elesc").ColumnIndex).Value,
                                       .GetCell(i, .Columns("elesc2").ColumnIndex).Value,
                                       Nothing)
                    j = j + 1
                End If

            Next
        End With
        _prCargarReportePractico(dtReporte)
        _prCargarGridAlumnos()

    End Sub

    Private Sub _prSeleccionarTodos()
        With grAlumnos.PrimaryGrid
            For i = 0 To .Rows.Count - 1
                .GetCell(i, .Columns("seleccionar").ColumnIndex).Value = True
            Next
        End With
    End Sub
#End Region


    Private Sub F0_ListaExamenCerti_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _prIniciarTodo()
    End Sub

    Private Sub btnGrabar_Click(sender As Object, e As EventArgs) Handles btnGrabar.Click
        _prCambiarEstados()
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        _prCargarReporteListaPractico()
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Dim dtReporte As DataTable = L_prExamenAlumnoCertiGeneralReporteExamenTeoricoEstructura()
        Dim j As Integer = 0
        With grAlumnos.PrimaryGrid
            For i = 0 To .Rows.Count - 1
                Dim numiLine As Integer = .GetCell(i, .Columns("emnumi").ColumnIndex).Value
                Dim check As String = .GetCell(i, .Columns("seleccionar").ColumnIndex).Value.ToString
                If check = "True" Then
                    Dim obj As String = .GetCell(i, .Columns("elci").ColumnIndex).Value
                    obj = .GetCell(i, .Columns("elci").ColumnIndex).Value
                    obj = .GetCell(i, .Columns("elnom").ColumnIndex).Value
                    obj = .GetCell(i, .Columns("elapep").ColumnIndex).Value
                    obj = .GetCell(i, .Columns("elfnac").ColumnIndex).Value
                    obj = .GetCell(i, .Columns("elcatlic").ColumnIndex).Value
                    obj = .GetCell(i, .Columns("cedesc1").ColumnIndex).Value
                    obj = .GetCell(i, .Columns("elfot").ColumnIndex).Value
                    obj = .GetCell(i, .Columns("elesc").ColumnIndex).Value
                    obj = .GetCell(i, .Columns("elesc2").ColumnIndex).Value


                    dtReporte.Rows.Add(j + 1,
                                       j + 1,
                                       j + 1,
                                       .GetCell(i, .Columns("elci").ColumnIndex).Value,
                                       .GetCell(i, .Columns("elnom").ColumnIndex).Value,
                                       .GetCell(i, .Columns("elapep").ColumnIndex).Value,
                                       .GetCell(i, .Columns("elapem").ColumnIndex).Value,
                                       New Date(1990, 1, 1),
                                       .GetCell(i, .Columns("elcatlic").ColumnIndex).Value,
                                       .GetCell(i, .Columns("cedesc1").ColumnIndex).Value,
                                       .GetCell(i, .Columns("elfot").ColumnIndex).Value,
                                       .GetCell(i, .Columns("elesc").ColumnIndex).Value,
                                       .GetCell(i, .Columns("elesc2").ColumnIndex).Value,
                                       Nothing)
                    j = j + 1
                End If

            Next
        End With
        _prCargarReportePractico(dtReporte)
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btMarcarTodos_Click(sender As Object, e As EventArgs) Handles btMarcarTodos.Click
        _prSeleccionarTodos()
    End Sub
End Class