Imports Logica.AccesoLogica
Imports Janus.Windows.GridEX
Imports DevComponents.DotNetBar

Public Class F0_HotelReserva
#Region "VARIABLES PRIVADAS"
    Dim _listColores As List(Of Color)
    Dim _marcando As Boolean
    Dim _mesVisto As Integer = 1
    Dim _meses As ClsHMeses
    Dim _fechaIng As Date
    Dim _fechaSal As Date
    Dim _numiCabana As String
    Dim _RegSelect As Integer
    Dim _marcarManual As Integer

    Dim _dtHorasLiberar As New DataTable

    Const conHoraLiberada As Integer = -4
    Const conDomingo As Integer = -2
    Const conSabado As Integer = -1
    Const conMarcado As Integer = 0
    Const conDiaGrabadoCliente As Integer = 1

    Const conEstResRealizada As Integer = 1
    Const conEstResConfirmadaPagada As Integer = 2
    Const conEstResPagadaCancelada As Integer = 3 'Const conEstResSinOcupar As Integer = 3
    Const conEstResReasignada As Integer = 4
    Const conEstResOriginalReasignada As Integer = 5
#End Region

#Region "METODOS PRIVADOS"

    Private Sub _prIniciarTodo()

        'Dim fecha As DateTime =
        '_prCargarBuscador(New DateTime(2017, 1, 1))
        Me.Text = "r e s e r v a    d e    c a b a ñ a s".ToUpper
        Me.WindowState = FormWindowState.Maximized

        'cargar colores a la lista
        _prCargarListaColores()

        tbFechaSelect.Value = New Date(Now.Year, Now.Month, 1)

        _marcando = False
        _RegSelect = -1

        btnNuevo.Enabled = False
        btnModificar.Enabled = False
        LblPaginacion.Text = ""
        PanelFechas.Enabled = True
        _marcarManual = 0

        _dtHorasLiberar = New DataTable
        _dtHorasLiberar.Columns.Add("egglin", GetType(Integer))
        _dtHorasLiberar.Columns.Add("eggcab", GetType(Integer))
        _dtHorasLiberar.Columns.Add("eggfec", GetType(Date))
        _dtHorasLiberar.Columns.Add("eggobs", GetType(String))

        'poner formato a la fecha
        tbFechaSelect.Format = DateTimePickerFormat.Custom
        tbFechaSelect.CustomFormat = "MMMM yyyy"

        _prCargarGridRegReservas()
        _prCargarGridHorario(tbFechaSelect.Value)
        'poner eventos
        AddHandler tbFechaSelect.ValueChanged, AddressOf tbFechaSelect_ValueChanged

    End Sub

    Private Sub _prCargarListaColores()
        _listColores = New List(Of Color)
        _listColores.Add(_prGetColorFromHex("#FFCDD2")) 'red 100
        _listColores.Add(_prGetColorFromHex("#E1BEE7")) 'purple 100
        _listColores.Add(_prGetColorFromHex("#C5CAE9")) 'indigo 100
        _listColores.Add(_prGetColorFromHex("#80D8FF")) 'ligth blue A100
        _listColores.Add(_prGetColorFromHex("#1DE9B6")) 'teal A400
        _listColores.Add(_prGetColorFromHex("#CCFF90")) 'light green A100
        _listColores.Add(_prGetColorFromHex("#FFFF8D")) 'yellow A100
        _listColores.Add(_prGetColorFromHex("#FFAB40")) 'orange A200
        _listColores.Add(_prGetColorFromHex("#F48FB1")) 'pink 200
        _listColores.Add(_prGetColorFromHex("#B39DDB")) 'deep purple 200
        _listColores.Add(_prGetColorFromHex("#90CAF9")) 'blue 200
        _listColores.Add(_prGetColorFromHex("#00B8D4")) 'cyan A700
        _listColores.Add(_prGetColorFromHex("#69F0AE")) 'green A200
        _listColores.Add(_prGetColorFromHex("#C6FF00")) 'lime A400
        _listColores.Add(_prGetColorFromHex("#FFAB00")) 'amber A700
        _listColores.Add(_prGetColorFromHex("#FF6E40")) 'Deep orange A200
        _listColores.Add(_prGetColorFromHex("#EF9A9A")) 'red 200
        _listColores.Add(_prGetColorFromHex("#CE93D8")) 'purple 200
        _listColores.Add(_prGetColorFromHex("#9FA8DA")) 'indigo 200
        _listColores.Add(_prGetColorFromHex("#00B0FF")) 'light blue A400
        _listColores.Add(_prGetColorFromHex("#00BFA5")) 'teal A700
        _listColores.Add(_prGetColorFromHex("#76FF03")) 'light green A400
        _listColores.Add(_prGetColorFromHex("#FF9100")) 'orange A400
        _listColores.Add(_prGetColorFromHex("#D7CCC8")) 'brown 100
        _listColores.Add(_prGetColorFromHex("#F8BBD0")) 'pink 200
        _listColores.Add(_prGetColorFromHex("#D1C4E9")) 'deep purple 100
        _listColores.Add(_prGetColorFromHex("#42A5F5")) 'blue 400
        _listColores.Add(_prGetColorFromHex("#00E5FF")) 'cyan A400
        _listColores.Add(_prGetColorFromHex("#00E676")) 'green A400
        _listColores.Add(_prGetColorFromHex("#F4FF81")) 'lime A100
        _listColores.Add(_prGetColorFromHex("#FFC400")) 'amber A400
        _listColores.Add(_prGetColorFromHex("#FF9E80")) 'deep orange A100
    End Sub
    Private Function _prGetColorFromHex(hexcolor As String) As Color

        Dim Red As String
        Dim Green As String
        Dim Blue As String
        hexcolor = Replace(hexcolor, "#", "")
        Red = Val("&H" & Mid(hexcolor, 1, 2))
        Green = Val("&H" & Mid(hexcolor, 3, 2))
        Blue = Val("&H" & Mid(hexcolor, 5, 2))
        Return Color.FromArgb(Red, Green, Blue)
    End Function
    Private Sub _prCargarGridRegReservas()
        Dim dt As New DataTable
        dt = L_prHotelReservaGetReservasDeLaFecha(tbFechaSelect.Value.ToString("yyyy/MM/dd"))

        'For i = 0 To dt.Rows.Count - 1
        '    dt.Rows(i).Item("color") = _listColores.Item(i).ToArgb()
        'Next

        dt.Columns.Add("select", GetType(Integer))
        For i = 0 To dt.Rows.Count - 1
            dt.Rows(i).Item("select") = 0
        Next

        grRegReservas.DataSource = dt
        grRegReservas.RetrieveStructure()

        'dar formato a las columnas
        With grRegReservas.RootTable.Columns("hdnumi")
            .Caption = "Cod. Reserva"
            .Visible = True
            .Width = 50
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        End With

        With grRegReservas.RootTable.Columns("hdfing")
            .Visible = False
        End With

        With grRegReservas.RootTable.Columns("hdtc1cli")
            .Visible = False
        End With


        With grRegReservas.RootTable.Columns("hdtip")
            .Visible = False
        End With


        With grRegReservas.RootTable.Columns("hdtc1soc")
            .Visible = False
        End With
        With grRegReservas.RootTable.Columns("hanom2")
            .Caption = "Nombre"
            .Width = 300
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
        End With

        With grRegReservas.RootTable.Columns("hdfcin")
            .Visible = False
        End With

        With grRegReservas.RootTable.Columns("hdfcou")
            .Visible = False
        End With

        With grRegReservas.RootTable.Columns("hdtc2cab")
            .Visible = False
        End With

        With grRegReservas.RootTable.Columns("hdobs")
            .Visible = False
        End With

        With grRegReservas.RootTable.Columns("hdest")
            .Visible = False
        End With

        With grRegReservas.RootTable.Columns("color")
            .Visible = False
        End With

        With grRegReservas.RootTable.Columns("color2")
            .Caption = "Color"
            .Width = 40
            .Visible = False
        End With

        With grRegReservas.RootTable.Columns("hdlugres")
            .Visible = False
        End With

        With grRegReservas.RootTable.Columns("select")
            .Visible = True
        End With

        'Habilitar Filtradores
        With grRegReservas
            .DefaultFilterRowComparison = FilterConditionOperator.Contains
            .FilterMode = FilterMode.Automatic
            .FilterRowUpdateMode = FilterRowUpdateMode.WhenValueChanges
            .GroupByBoxVisible = False

            'diseño de la grilla
            .VisualStyle = VisualStyle.Office2007

            '.SelectedFormatStyle.BackColor = Color.Yellow
            '.RowFormatStyle.BackColor = Color.AliceBlue
            '.SelectionMode = SelectionMode.SingleSelection
            '.SelectedFormatStyle.BackColor = Color.LightGreen
            '.RowFormatStyle.BackColor = Color.MediumTurquoise
        End With
        'grRegReservas.SelectionMode = SelectionMode.SingleSelection
        grRegReservas.ContextMenuStrip = msRegReservas

        'cargar condicion
        Dim fc As GridEXFormatCondition
        fc = New GridEXFormatCondition(grRegReservas.RootTable.Columns("select"), ConditionOperator.Equal, 1)
        fc.FormatStyle.BackColor = Color.Yellow
        grRegReservas.RootTable.FormatConditions.Add(fc)

        'fc = New GridEXFormatCondition(grRegReservas.RootTable.Columns("hdest"), ConditionOperator.GreaterThan, conEstResConfirmadaPagada)
        'fc.FormatStyle.BackColor = Color.Green
        'grRegReservas.RootTable.FormatConditions.Add(fc)

        'fc = New GridEXFormatCondition(grRegReservas.RootTable.Columns("hdest"), ConditionOperator.GreaterThan, conEstResPagadaCancelada)
        'fc.FormatStyle.BackColor = Color.Orange
        'grRegReservas.RootTable.FormatConditions.Add(fc)

        'fc = New GridEXFormatCondition(grRegReservas.RootTable.Columns("hdest"), ConditionOperator.GreaterThan, conEstResReasignada)
        'fc.FormatStyle.BackColor = Color.Yellow
        'grRegReservas.RootTable.FormatConditions.Add(fc)

    End Sub
    Private Sub _prCargarGridHorario(fecha As DateTime)
        _mesVisto = 1
        _marcando = False

        Dim _dt As DataTable 'OJO ESTE ERA GLOBAL
        _dt = New DataTable()
        _dt = L_prHotelReservaGetEstructuraDeDias()
        grHorario.DataSource = _dt

        Dim dtCabecera As DataTable = L_prHotelReservaGetEstructuraDeDias()
        grCabecera.DataSource = dtCabecera

        Dim dtCabanas As DataTable = L_prHotelReservaGetCabanas()

        'CARGAR LA ESTRUCTURA DE LOS MESES
        'antes optengo los registros del proximo mes para cargarlos
        Dim dt2 As New DataTable
        dt2 = L_prHotelReservaGetReservasDeLaFecha(DateAdd(DateInterval.Month, 1, tbFechaSelect.Value).ToString("yyyy/MM/dd"))
        For i = 0 To dt2.Rows.Count - 1
            If i < 32 Then
                dt2.Rows(i).Item("color") = _listColores.Item(i).ToArgb()
            End If
        Next

        _meses = New ClsHMeses(fecha, dtCabanas, CType(grRegReservas.DataSource, DataTable), dt2)


        Dim fuente As New Font("Tahoma", 10, FontStyle.Regular)
        For i = 1 To 31
            Dim col As String = "d" + Str(i).Trim
            With grHorario.Columns(col) '"d" + Str(i)
                fecha = fecha.AddDays(-1)
                .HeaderText = Str(i) '+ "(" + WeekdayName(Weekday(fecha), True, FirstDayOfWeek.Monday) + ")"
                grCabecera.Columns(col).HeaderText = WeekdayName(Weekday(fecha), True, FirstDayOfWeek.Monday)
                fecha = fecha.AddDays(1)
                .HeaderCell.Style.Font = fuente
                .Width = 30
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                fecha = fecha.AddDays(1)
                .Visible = True

                grCabecera.Columns(col).HeaderCell.Style.Font = fuente
                grCabecera.Columns(col).Width = 30
                grCabecera.Columns(col).Visible = True
                If i > _meses.vUltDia1 Then
                    .Visible = False
                    grCabecera.Columns(col).Visible = False
                End If

            End With
        Next


        'aumentar las cabañas
        With grHorario.Columns(0) '"d" + Str(i)
            grCabecera.Columns(0).HeaderCell.Style.Font = fuente
            grCabecera.Columns(0).HeaderText = ""
            grCabecera.Columns(0).Width = 150
            grCabecera.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grCabecera.Columns(0).DefaultCellStyle.BackColor = Color.Azure

            .HeaderText = "CABAÑA"
            .HeaderCell.Style.Font = fuente
            .Width = 150
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .DefaultCellStyle.BackColor = Color.Azure
        End With

        _dt.Rows.Clear()
        For I = 0 To dtCabanas.Rows.Count - 1
            _dt.Rows.Add(dtCabanas.Rows(I).Item("hbnom"))
        Next

        grHorario.AllowUserToAddRows = False
        grHorario.Refresh()

        'pongo el menu
        ''grHorario.ContextMenuStrip = msHorario

        grHorario.AllowDrop = False
        grHorario.AllowUserToOrderColumns = False
        For Each col As DataGridViewColumn In grHorario.Columns
            col.SortMode = DataGridViewColumnSortMode.NotSortable
        Next

        'cargar los datos del mes
        _prRepaintGrilla(1)

    End Sub

    Private Sub _prCargarGridHorarioSinReestructurar(mesSelect As Integer, fecha As DateTime)
        Dim _dt As New DataTable
        _dt = New DataTable()
        _dt = L_prHotelReservaGetEstructuraDeDias()
        grHorario.DataSource = _dt

        Dim dtCabecera As DataTable = L_prClasesPracDetFechasEsctructuraGeneral()
        grCabecera.DataSource = dtCabecera

        'CARGAR LA ESTRUCTURA DE LOS MESES
        '_meses = New ClsMeses(fecha, numiInst, CType(grAlumnos.DataSource, DataTable))

        Dim ultDia As Integer
        If mesSelect = 1 Then
            ultDia = _meses.vUltDia1
        Else
            ultDia = _meses.vUltDia2
        End If



        Dim fuente As New Font("Tahoma", 10, FontStyle.Regular)
        For i = 1 To 31
            Dim col As String = "d" + Str(i).Trim
            With grHorario.Columns(col) '"d" + Str(i)
                fecha = fecha.AddDays(-1)
                .HeaderText = Str(i) '+ "(" + WeekdayName(Weekday(fecha), True, FirstDayOfWeek.Monday) + ")"
                grCabecera.Columns(col).HeaderText = WeekdayName(Weekday(fecha), True, FirstDayOfWeek.Monday)
                fecha = fecha.AddDays(1)
                .HeaderCell.Style.Font = fuente
                .Width = 25
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                fecha = fecha.AddDays(1)
                .Visible = True

                grCabecera.Columns(col).HeaderCell.Style.Font = fuente
                grCabecera.Columns(col).Width = 25
                grCabecera.Columns(col).Visible = True
                If i > ultDia Then
                    .Visible = False
                    grCabecera.Columns(col).Visible = False
                End If

            End With
        Next

        'aumentar las cabañas
        With grHorario.Columns(0) '"d" + Str(i)
            grCabecera.Columns(0).HeaderCell.Style.Font = fuente
            grCabecera.Columns(0).HeaderText = ""
            grCabecera.Columns(0).Width = 150
            grCabecera.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grCabecera.Columns(0).DefaultCellStyle.BackColor = Color.Azure

            .HeaderText = "CABAÑA"
            .HeaderCell.Style.Font = fuente
            .Width = 150
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .DefaultCellStyle.BackColor = Color.Azure
        End With


        _dt.Rows.Clear()
        _dt.Rows.Clear()
        For I = 0 To _meses.vdtCabanas.Rows.Count - 1
            _dt.Rows.Add(_meses.vdtCabanas.Rows(I).Item("hbnom"))
        Next



        grHorario.AllowUserToAddRows = False
        grHorario.Refresh()

        'pongo el menu
        ''grHorario.ContextMenuStrip = msHorario

        'cargar los datos del mes
        _prRepaintGrilla(mesSelect)

    End Sub

    Private Sub _prRepaintGrilla(mes As Integer)
        If mes = 1 Then
            For f As Integer = 0 To _meses.vdtCabanas.Rows.Count - 1
                For c As Integer = 0 To _meses.vUltDia1 - 1
                    If IsNothing(_meses.vDias1(f, c)) = False Then
                        grHorario.Rows(f).Cells(c + 1).Style.BackColor = _meses.vDias1(f, c).cColor
                        If _meses.vDias1(f, c).estado = conHoraLiberada Then
                            grHorario.Rows(f).Cells(c + 1).Value = "I"
                            grHorario.Rows(f).Cells(c + 1).Style.ForeColor = Color.White
                        End If
                        If _meses.vDias1(f, c).estHora = conEstResRealizada Then
                            grHorario.Rows(f).Cells(c + 1).Value = "RE"
                        End If

                        If _meses.vDias1(f, c).estHora = conEstResConfirmadaPagada Then
                            grHorario.Rows(f).Cells(c + 1).Value = "CO"
                        End If

                        If _meses.vDias1(f, c).estHora = conEstResPagadaCancelada Then
                            grHorario.Rows(f).Cells(c + 1).Value = "NS"
                        End If

                        If _meses.vDias1(f, c).estHora = conEstResReasignada Then
                            grHorario.Rows(f).Cells(c + 1).Value = ""
                        End If

                        'If _meses.vmes1.vDias(f, c).desc <> String.Empty Then
                        '    grHorario.Rows(f).Cells(c + 1).Style.Font = New Font("Arial", 10, FontStyle.Bold Or FontStyle.Underline)
                        'End If

                        'If _meses.vmes1.vDias(f, c).estado = 1 Or _meses.vmes1.vDias(f, c).estado = 0 Then
                        '    If _meses.vmes1.vDias(f, c).estadoCls = 2 Then
                        '        grHorario.Rows(f).Cells(c + 1).Value = "P"
                        '    Else
                        '        grHorario.Rows(f).Cells(c + 1).Value = _meses.vmes1.vDias(f, c).numCla
                        '    End If

                        '    If _meses.vmes1.vDias(f, c).estadoCls = 1 Then
                        '        grHorario.Rows(f).Cells(c + 1).Style.ForeColor = Color.Green
                        '    End If
                        'End If
                    End If
                Next
            Next
        Else
            For f As Integer = 0 To _meses.vdtCabanas.Rows.Count - 1
                For c As Integer = 0 To _meses.vUltDia2 - 1
                    If IsNothing(_meses.vDias2(f, c)) = False Then
                        grHorario.Rows(f).Cells(c + 1).Style.BackColor = _meses.vDias2(f, c).cColor
                        'If _meses.vmes2.vDias(f, c).desc <> String.Empty Then
                        '    grHorario.Rows(f).Cells(c + 1).Style.Font = New Font("Arial", 10, FontStyle.Bold Or FontStyle.Underline)
                        'End If
                        'If _meses.vmes2.vDias(f, c).estado = 1 Or _meses.vmes2.vDias(f, c).estado = 0 Then
                        '    If _meses.vmes2.vDias(f, c).estadoCls = 2 Then
                        '        grHorario.Rows(f).Cells(c + 1).Value = "P"
                        '    Else
                        '        grHorario.Rows(f).Cells(c + 1).Value = _meses.vmes2.vDias(f, c).numCla
                        '    End If

                        'End If

                        'If _meses.vmes2.vDias(f, c).estadoCls = 1 Then
                        '    grHorario.Rows(f).Cells(c + 1).Style.ForeColor = Color.Green
                        'End If
                    End If
                Next
            Next
        End If

    End Sub

    Private Sub _prRealizarReserva()
        If btnNuevo.Enabled = True Then
            ToastNotification.Show(Me, "si quiere volver a marcar, primero limpie el horario con el boton 'limpiar' ".ToUpper, My.Resources.WARNING, 5000, eToastGlowColor.Green, eToastPosition.TopCenter)
            Exit Sub
        End If

        Dim i As Integer = 1
        Dim c As Integer = grHorario.CurrentCell.ColumnIndex
        Dim f As Integer = grHorario.CurrentCell.RowIndex

        Dim input As String = InputBox("¿Cuántas noches desea reservar?", "Cantidad de noches para reservar", "1")
        If Not IsNumeric(input) Then
            Exit Sub
        End If
        Dim n As Integer = Int(input)

        'poner fecha de inicio y finalizacion
        _fechaIng = New Date(tbFechaSelect.Value.Year, tbFechaSelect.Value.Month, c)


        Dim vistaFecha As Integer = 1
        Dim c1 As Integer = 1
        While i <= n
            If c - 1 <= _meses.vUltDia1 - 1 And vistaFecha = 1 Then
                If IsNothing(_meses.vDias1(f, c - 1)) Then 'IsNothing(_meses.vDias1(f, c - 1))
                    grHorario.CurrentRow.Cells(c).Style.BackColor = Color.Green
                    'cargar dia marcado
                    _meses.vDias1(f, c - 1) = New ClsHDia(conMarcado, 0, 0, 0, "", 0, Color.Green)
                    i = i + 1
                Else
                    Dim obj As ClsHDia = _meses.vDias1(f, c - 1)
                    If obj.estado = conDiaGrabadoCliente Or obj.estado = conHoraLiberada Then
                        Dim diaConflicto As String = c.ToString + "/" + _meses.vFecha1.Month.ToString + "/" + _meses.vFecha1.Year.ToString
                        Dim info As New TaskDialogInfo("reserva".ToUpper, eTaskDialogIcon.Delete, "conflicto con otra reserva el dia ".ToUpper + diaConflicto,
                                                       "solo se pudo reservar ".ToUpper + (i - 1).ToString + " dias por que hay conflicto con otro horario el dia ".ToUpper + diaConflicto, eTaskDialogButton.Ok Or eTaskDialogButton.Close, eTaskDialogBackgroundColor.Blue)
                        Dim result As eTaskDialogResult = TaskDialog.Show(info)
                        If result = eTaskDialogResult.Yes Then

                        End If
                        Exit While
                    Else
                        grHorario.CurrentRow.Cells(c).Style.BackColor = Color.Green
                        'cargar dia marcado
                        _meses.vDias1(f, c - 1) = New ClsHDia(conMarcado, 0, 0, 0, "", 0, Color.Green)
                        i = i + 1
                    End If

                End If
            Else
                vistaFecha = 2
                If IsNothing(_meses.vDias2(f, c1 - 1)) Then
                    _meses.vDias2(f, c1 - 1) = New ClsHDia(conMarcado, 0, 0, 0, "", 0, Color.Green)
                    i = i + 1
                Else
                    Dim obj As ClsHDia = _meses.vDias2(f, c1 - 1)
                    If obj.estado = conDiaGrabadoCliente Or obj.estado = conHoraLiberada Then
                        Dim diaConflicto As String = c1.ToString + "/" + _meses.vFecha2.Month.ToString + "/" + _meses.vFecha2.Year.ToString
                        Dim info As New TaskDialogInfo("reserva".ToUpper, eTaskDialogIcon.Delete, "conflicto con otra reserva el dia ".ToUpper + diaConflicto,
                                                       "solo se pudo reservar ".ToUpper + (i - 1).ToString + " dias por que hay conflicto con otro horario el dia ".ToUpper + diaConflicto, eTaskDialogButton.Ok Or eTaskDialogButton.Close, eTaskDialogBackgroundColor.Blue)
                        Dim result As eTaskDialogResult = TaskDialog.Show(info)
                        If result = eTaskDialogResult.Yes Then

                        End If
                        Exit While
                    Else
                        _meses.vDias2(f, c1 - 1) = New ClsHDia(conMarcado, 0, 0, 0, "", 0, Color.Green)
                        i = i + 1
                    End If
                End If
            End If

            If vistaFecha = 1 Then
                c = c + 1
            Else
                c1 = c1 + 1
            End If
        End While

        Dim fecha As Date = tbFechaSelect.Value
        If vistaFecha = 1 Then
            _fechaSal = New Date(fecha.Year, fecha.Month, c - 1)
        Else
            fecha = DateAdd(DateInterval.Month, 1, fecha)
            _fechaSal = New Date(fecha.Year, fecha.Month, c1 - 1)
        End If
        _numiCabana = _meses.vdtCabanas.Rows(f).Item("hbnumi").ToString


        btnNuevo.Enabled = True
        btnModificar.Enabled = True
        _marcando = True
        tbFechaSelect.Enabled = False
    End Sub

    Private Sub _prGrabarRegistro()
        Dim frmAyuda As Modelos.ModeloAyuda
        Dim dt As DataTable = L_prHotelReservaGetClientes()
        Dim listEstCeldas As New List(Of Modelos.Celda)
        listEstCeldas.Add(New Modelos.Celda("hanumi", True, "Codigo".ToUpper, 70))
        listEstCeldas.Add(New Modelos.Celda("haci", True, "CI".ToUpper, 70))
        listEstCeldas.Add(New Modelos.Celda("hansoc", False))
        listEstCeldas.Add(New Modelos.Celda("hanom2", True, "Nombre completo".ToUpper, 300))

        frmAyuda = New Modelos.ModeloAyuda(600, 300, dt, "seleccione el cliente para programar la reserva".ToUpper, listEstCeldas)
        frmAyuda.ShowDialog()

        If frmAyuda.seleccionado = True Then
            Dim numiCli As String = frmAyuda.filaSelect.Cells("hanumi").Value
            Dim numi As String = ""
            Dim obs As String = ""
            Dim numiCabana As String = _numiCabana
            ''Dim respuesta As Boolean = L_prHotelReservaGrabar(numi, Now.Date.ToString("yyyy/MM/dd"), numiCli, _fechaIng.ToString("yyyy/MM/dd"), _fechaSal.ToString("yyyy/MM/dd"), numiCabana, obs, "1", Nothing)
            Dim respuesta As Boolean = False
            If respuesta Then
                _prCargarGridRegReservas()
                _prCargarGridHorario(tbFechaSelect.Value)
                btnNuevo.Enabled = False
                tbFechaSelect.Enabled = True
            End If
        End If
    End Sub
    Private Sub _prGrabarRegistro2()
        SupTabItemRegistro.Visible = False
        SupTabItemBusqueda.Visible = True
        SuperTabPrincipal.SelectedTabIndex = 1
        _prCargarGridBusquedaClientes()
        _prCargarGridClientes("-1")

    End Sub
    Private Sub _prModificarRegistroFecha()

        Dim numiReg As String = _RegSelect.ToString.Trim
        Dim numi As String = ""
        Dim numiCabana As String = _numiCabana
        Dim respuesta As Boolean = L_prHotelReservaModificarFecha(numiReg, _fechaIng.ToString("yyyy/MM/dd"), _fechaSal.ToString("yyyy/MM/dd"), numiCabana)
        If respuesta Then
            _prCargarGridRegReservas()
            _prCargarGridHorario(tbFechaSelect.Value)
            btnNuevo.Enabled = False
            tbFechaSelect.Enabled = True
            _RegSelect = -1
        End If

    End Sub
    Private Sub _prModificarRegistroDatos()

        'Dim numiReg As String = _RegSelect.ToString.Trim
        'Dim numi As String = ""
        'Dim obs As String = tbObs.Text
        'Dim numiCabana As String = _numiCabana

        'Dim dtDetalle As DataTable = CType(grClientesReg.DataSource, DataTable).DefaultView.ToTable(True, "henumi", "hetc3rev", "hetc1cli", "estado")
        'Dim tipo As String = IIf(tbEncEsSocio.Value = True, "1", "0")
        'Dim refSocio As String = IIf(tbEncEsSocio.Value = True, "0", tbSocNumi.Text)
        'Dim lugReserva As String = IIf(tbLugRes.Value = True, "1", "2")

        'Dim respuesta As Boolean = L_prHotelReservaModificarDatos(numiReg, tbEncNumi.Text, obs, tipo, refSocio, lugReserva, dtDetalle)
        'If respuesta Then
        '    _prCargarGridRegReservas()
        '    _prCargarGridHorario(tbFechaSelect.Value)
        '    btnNuevo.Enabled = False
        '    tbFechaSelect.Enabled = True
        '    _RegSelect = -1
        '    SupTabItemRegistro.Visible = True
        '    SupTabItemBusqueda.Visible = False
        '    SuperTabPrincipal.SelectedTabIndex = 0
        '    _marcando = False

        'End If

    End Sub

    Private Sub _prCargarGridBusquedaClientes()
        Dim dt As New DataTable
        dt = L_prHotelReservaGetClientes()

        grBusquedaCliente.DataSource = dt
        grBusquedaCliente.RetrieveStructure()

        'dar formato a las columnas
        With grBusquedaCliente.RootTable.Columns("hanumi")
            .Caption = "Cod.".ToUpper
            .Width = 50
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        End With

        With grBusquedaCliente.RootTable.Columns("hansoc")
            .Caption = "nro. socio".ToUpper
            .Width = 50
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        End With

        With grBusquedaCliente.RootTable.Columns("haci")
            .Caption = "ci".ToUpper
            .Width = 70
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        End With

        With grBusquedaCliente.RootTable.Columns("hanom2")
            .Caption = "Nombre".ToUpper
            .Width = 250
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
        End With

        With grBusquedaCliente.RootTable.Columns("hafnac")
            .Caption = "Fecha Nac.".ToUpper
            .Width = 100
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        End With


        'Habilitar Filtradores
        With grBusquedaCliente
            .DefaultFilterRowComparison = FilterConditionOperator.Contains
            .FilterMode = FilterMode.Automatic
            .FilterRowUpdateMode = FilterRowUpdateMode.WhenValueChanges
            .GroupByBoxVisible = False
            'diseño de la grilla
            .VisualStyle = VisualStyle.Office2007
        End With

        grBusquedaCliente.ContextMenuStrip = msBusquedaClientes

        Dim fc As GridEXFormatCondition
        fc = New GridEXFormatCondition(grBusquedaCliente.RootTable.Columns("hansoc"), ConditionOperator.GreaterThan, 0)
        fc.FormatStyle.BackColor = Color.LightGreen
        grBusquedaCliente.RootTable.FormatConditions.Add(fc)

    End Sub

    Private Sub _prCargarGridClientes(numiReserva As String)
        Dim dt As New DataTable
        dt = L_prHotelReservaDetalleClientes(numiReserva)

        grClientesReg.DataSource = dt
        grClientesReg.RetrieveStructure()

        'dar formato a las columnas
        With grClientesReg.RootTable.Columns("henumi")
            .Visible = False
        End With
        With grClientesReg.RootTable.Columns("hetc3rev")
            .Visible = False
        End With
        With grClientesReg.RootTable.Columns("hetc1cli")
            .Caption = "Cod.".ToUpper
            .Width = 50
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        End With

        With grClientesReg.RootTable.Columns("hansoc")
            .Caption = "nro. socio".ToUpper
            .Width = 50
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        End With

        With grClientesReg.RootTable.Columns("haci")
            .Caption = "ci".ToUpper
            .Width = 70
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        End With

        With grClientesReg.RootTable.Columns("hanom2")
            .Caption = "Nombre".ToUpper
            .Width = 250
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
        End With

        With grClientesReg.RootTable.Columns("hafnac")
            .Caption = "Fecha Nac.".ToUpper
            .Width = 100
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        End With


        'Habilitar Filtradores
        With grClientesReg
            '.DefaultFilterRowComparison = FilterConditionOperator.Contains
            '.FilterMode = FilterMode.Automatic
            '.FilterRowUpdateMode = FilterRowUpdateMode.WhenValueChanges
            .GroupByBoxVisible = False
            'diseño de la grilla
            .VisualStyle = VisualStyle.Office2007
        End With

        grClientesReg.ContextMenuStrip = msClientesReg
    End Sub

    Private Sub _prCargarGridIncidencias(numiClie As String)
        Dim dt As New DataTable
        dt = L_prHotelIncidenciaDetalleClientes(numiClie)

        grIncidencias.DataSource = dt
        grIncidencias.RetrieveStructure()

        'dar formato a las columnas
        With grIncidencias.RootTable.Columns("efnumi")
            .Visible = False
        End With
        With grIncidencias.RootTable.Columns("eftc1cli")
            .Visible = False
        End With
        With grIncidencias.RootTable.Columns("eftc3res")
            .Caption = "Cod. Reserva".ToUpper
            .Width = 70
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        End With

        With grIncidencias.RootTable.Columns("hdfcin")
            .Caption = "fecha ing.".ToUpper
            .Width = 100
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        End With

        With grIncidencias.RootTable.Columns("hdfcou")
            .Caption = "fecha sal.".ToUpper
            .Width = 100
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        End With

        With grIncidencias.RootTable.Columns("efobs")
            .Caption = "observacion".ToUpper
            .Width = 300
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
        End With


        'Habilitar Filtradores
        With grIncidencias
            '.DefaultFilterRowComparison = FilterConditionOperator.Contains
            '.FilterMode = FilterMode.Automatic
            '.FilterRowUpdateMode = FilterRowUpdateMode.WhenValueChanges
            .GroupByBoxVisible = False
            'diseño de la grilla
            .VisualStyle = VisualStyle.Office2007
        End With

    End Sub

    Private Sub _prAdicionarSeleccionado()
        Dim numiCab, nsoc, estado, line, numiCli As Integer
        Dim ci, nombre As String
        Dim fechaNac As Date
        numiCab = 0
        estado = 0
        line = 0
        numiCli = grBusquedaCliente.GetValue("hanumi")
        nsoc = grBusquedaCliente.GetValue("hansoc")
        ci = grBusquedaCliente.GetValue("haci")
        nombre = grBusquedaCliente.GetValue("hanom2")
        fechaNac = grBusquedaCliente.GetValue("hafnac")
        For Each fila As DataRow In CType(grClientesReg.DataSource, DataTable).Rows
            If numiCli = fila.Item("hetc1cli") Or numiCli.ToString = tbEncNumi.Text Or numiCli.ToString = tbSocNumi.Text Then
                ToastNotification.Show(Me, "cliente ya seleccionado".ToUpper, My.Resources.WARNING, 8000, eToastGlowColor.Red, eToastPosition.TopCenter)
                Exit Sub
            End If

        Next
        CType(grClientesReg.DataSource, DataTable).Rows.Add(line, numiCab, numiCli, nsoc, ci, nombre, fechaNac, estado)

    End Sub
    Private Sub _prAdicionarNuevoCliente()
        If _prValidarCamposNuevoCliente() = True Then
            Dim ci, nombre, fecha, numi As String
            numi = ""
            With grBusquedaCliente.FilterRow
                ci = .Cells("haci").Value
                nombre = .Cells("hanom2").Value
                fecha = CType(.Cells("hafnac").Value, Date).ToString("yyyy/MM/dd")
                Dim resp As Boolean = L_prClienteHGrabar(numi, 1, 0, Now.Date.ToString("yyyy/MM/dd"), fecha, nombre, "", "", "", "", ci, "", "", 1, "", "")
                If resp Then
                    ToastNotification.Show(Me, "cliente nuevo grabado exitosamente".ToUpper, My.Resources.GRABACION_EXITOSA, 8000, eToastGlowColor.Green, eToastPosition.TopCenter)
                    _prCargarGridBusquedaClientes()
                End If

            End With


        End If

    End Sub
    Private Function _prValidarCamposNuevoCliente() As Boolean

        With grBusquedaCliente.FilterRow
            If .Cells("haci").Value = String.Empty Then
                ToastNotification.Show(Me, "ingrese el ci del nuevo cliente".ToUpper, My.Resources.WARNING, 8000, eToastGlowColor.Red, eToastPosition.TopCenter)
                Return False
            End If
            If .Cells("hanom2").Value = String.Empty Then
                ToastNotification.Show(Me, "ingrese el nombre del nuevo cliente".ToUpper, My.Resources.WARNING, 8000, eToastGlowColor.Red, eToastPosition.TopCenter)
                Return False
            End If
            If IsNothing(.Cells("hafnac").Value) Then
                ToastNotification.Show(Me, "ingrese la fecha de naciemiento del nuevo cliente".ToUpper, My.Resources.WARNING, 8000, eToastGlowColor.Red, eToastPosition.TopCenter)
                Return False
            End If
        End With

        Return True

    End Function

    Private Sub _prGrabarReserva()
        'Dim numiCli As String = tbEncNumi.Text
        'Dim numi As String = ""
        'Dim obs As String = tbObs.Text
        'Dim numiCabana As String = _numiCabana
        'Dim dtDetalle As DataTable = CType(grClientesReg.DataSource, DataTable).DefaultView.ToTable(True, "henumi", "hetc3rev", "hetc1cli", "estado")
        'Dim tipo As String = IIf(tbEncEsSocio.Value = True, "1", "0")
        'Dim refSocio As String = IIf(tbEncEsSocio.Value = True, "0", tbSocNumi.Text)
        'Dim lugReserva As String = IIf(tbLugRes.Value = True, "1", "2")
        'Dim respuesta As Boolean = L_prHotelReservaGrabar(numi, Now.Date.ToString("yyyy/MM/dd"), numiCli, _fechaIng.ToString("yyyy/MM/dd"), _fechaSal.ToString("yyyy/MM/dd"), numiCabana, obs, conEstResRealizada, tipo, refSocio, lugReserva, dtDetalle)
        'If respuesta Then
        '    _prCargarGridRegReservas()
        '    _prCargarGridHorario(tbFechaSelect.Value)
        '    btnNuevo.Enabled = False
        '    tbFechaSelect.Enabled = True

        '    SupTabItemRegistro.Visible = True
        '    SupTabItemBusqueda.Visible = False
        '    SuperTabPrincipal.SelectedTabIndex = 0
        'End If
    End Sub

    Private Sub _prLimpiarCampos()
        tbEncCi.Text = String.Empty
        tbEncNombre.Text = String.Empty
        tbEncNumi.Text = String.Empty

        tbSocCi.Text = String.Empty
        tbSocNombre.Text = String.Empty
        tbSocNroSoc.Text = String.Empty
        tbSocNumi.Text = String.Empty


        tbObs.Text = String.Empty
        tbLugRes.Value = True

    End Sub
    Private Sub _prCargarDatosReservaParaModificar()
        SupTabItemRegistro.Visible = False
        SupTabItemBusqueda.Visible = True
        SuperTabPrincipal.SelectedTabIndex = 1

        Dim dtClie As DataTable = L_prHotelReservaGetCliente(grRegReservas.GetValue("hdtc1cli"))
        Dim tipo As Integer = grRegReservas.GetValue("hdtip")

        tbEncCi.Text = dtClie.Rows(0).Item("haci")
        tbEncNombre.Text = dtClie.Rows(0).Item("hanom2")
        tbEncNumi.Text = dtClie.Rows(0).Item("hanumi")
        tbEncEsSocio.Value = IIf(tipo = 1, True, False)

        If tbEncEsSocio.Value = False Then
            dtClie = L_prHotelReservaGetCliente(grRegReservas.GetValue("hdtc1soc"))

            tbSocCi.Text = dtClie.Rows(0).Item("haci")
            tbSocNombre.Text = dtClie.Rows(0).Item("hanom2")
            tbSocNumi.Text = dtClie.Rows(0).Item("hanumi")
            tbSocNroSoc.Text = dtClie.Rows(0).Item("hansoc")
            gpSocioReferencia.Visible = True
        Else
            gpSocioReferencia.Visible = False
        End If

        tbObs.Text = grRegReservas.GetValue("hdobs")
        Dim lugReserva As Boolean
        If IsDBNull(grRegReservas.GetValue("hdlugres")) Then
            lugReserva = True
        Else
            If grRegReservas.GetValue("hdlugres") = 1 Then
                lugReserva = True
            Else
                lugReserva = False
            End If

        End If

        tbLugRes.Value = lugReserva

        _prCargarGridBusquedaClientes()
        _prCargarGridClientes(_RegSelect)
    End Sub


    Private Sub _prLiberarHoraEmpezar()
        btnImprimir.Text = "Confirmar".ToUpper
        PanelToolBar1.Visible = False
        _marcarManual = 2
    End Sub
    Private Sub _prLiberarHoraGrabar()

        Dim dtHoras As DataTable = New DataTable

        Dim obs As String = InputBox("ingrese la observacion".ToUpper, "OBSERVACION".ToUpper, "").ToUpper
        If obs <> String.Empty Then

            L_prHoraLibreTCH0033Grabar(_dtHorasLiberar, obs)

        End If
        'reiniciar todo
        btnImprimir.Text = "liberar hora".ToUpper
        PanelToolBar1.Visible = True

        _marcarManual = 0
        _prCargarGridRegReservas()
        _prCargarGridHorario(tbFechaSelect.Value)
        btnNuevo.Enabled = False
        _dtHorasLiberar.Rows.Clear()
        tbFechaSelect.Enabled = True

    End Sub

    Private Sub _prInsertarTablaLiberarHora(fecha As Date, numiCab As String)
        _dtHorasLiberar.Rows.Add(0, numiCab, fecha, "")
    End Sub

    Private Sub _prSeleccionarHoras()


        Dim dtCabañas As DataTable = _meses.vdtCabanas
        Dim vCabanas As List(Of String) = New List(Of String)
        For Each fila As DataRow In dtCabañas.Rows
            vCabanas.Add(fila.Item("hbnumi"))
        Next



        Dim i As Integer = 0
        While i < grHorario.SelectedCells.Count
            grHorario.SelectedCells(i).Selected = False
        End While

        Dim dtReserva As DataTable = L_prHotelReservaGetReservaCompleta(grRegReservas.GetValue("hdnumi"))

        Dim fechaEntr As DateTime = dtReserva.Rows(0).Item("hdfcin")
        Dim fechaSal As DateTime = dtReserva.Rows(0).Item("hdfcou")
        Dim f As Integer = vCabanas.IndexOf(dtReserva.Rows(0).Item("hdtc2cab"))


        While fechaEntr <= fechaSal
            If fechaEntr.Month = _meses.vFecha1.Month And fechaEntr.Year = _meses.vFecha1.Year Then
                grHorario.Rows(f).Cells(fechaEntr.Day).Selected = True

            End If
            fechaEntr = DateAdd(DateInterval.Day, 1, fechaEntr)
        End While


    End Sub
#End Region


#Region "Eventos programados manualmente"
    Private Sub tbFechaSelect_ValueChanged(sender As Object, e As EventArgs)
        If _marcando = False And tbFechaSelect.Focused = True Then
            _prCargarGridRegReservas()
            _prCargarGridHorario(tbFechaSelect.Value)
        End If

    End Sub
#End Region

    Private Sub F0_HotelReserva_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _prIniciarTodo()
    End Sub
    Private Sub grCabecera_ColumnWidthChanged(sender As Object, e As DataGridViewColumnEventArgs) Handles grCabecera.ColumnWidthChanged
        grHorario.Columns(e.Column.Index).Width = grCabecera.Columns(e.Column.Index).Width
    End Sub

    Private Sub grHorario_ColumnWidthChanged(sender As Object, e As DataGridViewColumnEventArgs) Handles grHorario.ColumnWidthChanged
        grCabecera.Columns(e.Column.Index).Width = grHorario.Columns(e.Column.Index).Width
    End Sub

    Private Sub grAlumnos_FormattingRow(sender As Object, e As RowLoadEventArgs) Handles grRegReservas.FormattingRow
        'if (e.Row.Cells["ColumnName"].Value == someValue) 
        e.Row.Cells("color2").FormatStyle = New GridEXFormatStyle
        If e.Row.RowIndex < 32 Then
            e.Row.Cells("color2").FormatStyle.BackColor = _listColores.Item(e.Row.RowIndex)
        Else
            e.Row.Cells("color2").FormatStyle.BackColor = _listColores.Item(31)
        End If
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Close()
    End Sub

    Private Sub btnFAnt_Click(sender As Object, e As EventArgs) Handles btnFAnt.Click

        If _marcando = False Then
            tbFechaSelect.Value = DateAdd(DateInterval.Month, -1, tbFechaSelect.Value)
            _prCargarGridRegReservas()
            _prCargarGridHorario(tbFechaSelect.Value)
        Else
            If _mesVisto = 2 Then
                tbFechaSelect.Value = DateAdd(DateInterval.Month, -1, tbFechaSelect.Value)
                _prCargarGridHorarioSinReestructurar(1, tbFechaSelect.Value)
                _mesVisto = 1
            End If

        End If
    End Sub


    Private Sub btnFSig_Click(sender As Object, e As EventArgs) Handles btnFSig.Click

        If _marcando = False Then
            tbFechaSelect.Value = DateAdd(DateInterval.Month, 1, tbFechaSelect.Value)
            _prCargarGridRegReservas()
            _prCargarGridHorario(tbFechaSelect.Value)

        Else
            If _mesVisto = 1 Then
                tbFechaSelect.Value = DateAdd(DateInterval.Month, 1, tbFechaSelect.Value)
                _prCargarGridHorarioSinReestructurar(2, tbFechaSelect.Value)
                _mesVisto = 2
            End If
        End If
    End Sub

    Private Sub REALIZARRESERVAToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles REALIZARRESERVAToolStripMenuItem.Click
        _prRealizarReserva()
    End Sub
    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        _prCargarGridRegReservas()
        _prCargarGridHorario(tbFechaSelect.Value)
        btnNuevo.Enabled = False
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        If _RegSelect < 0 Then
            _prGrabarRegistro2()
            _prLimpiarCampos()
            grBusquedaCliente.Focus()
            grBusquedaCliente.MoveTo(grBusquedaCliente.FilterRow)
            grBusquedaCliente.Col = grBusquedaCliente.RootTable.Columns("hanom2").Index
        Else
            _prModificarRegistroFecha()

        End If
    End Sub

    Private Sub grRegReservas_EditingCell(sender As Object, e As EditingCellEventArgs) Handles grRegReservas.EditingCell
        e.Cancel = True
    End Sub

    Private Sub MODIFICARRESERVAToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MODIFICARRESERVAToolStripMenuItem.Click
        If grRegReservas.Row >= 0 Then
            _RegSelect = grRegReservas.GetValue("hdnumi")
        End If

    End Sub

    Private Sub ELIMINARRESERVAToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ELIMINARRESERVAToolStripMenuItem.Click
        If grRegReservas.Row >= 0 Then
            Dim numiReg As String = grRegReservas.GetValue("hdnumi").ToString.Trim
            'verificar si la reserva ya facturo o fue vendida
            Dim dtVenta As DataTable = L_prHotelReservaObtenerVentasPorNumiReserva(numiReg)
            If dtVenta.Rows.Count = 0 Then
                'Dim info As New TaskDialogInfo("¿esta seguro de eliminar el registro?".ToUpper, eTaskDialogIcon.Delete, "advertencia".ToUpper, "mensaje principal".ToUpper, eTaskDialogButton.Yes Or eTaskDialogButton.Cancel, eTaskDialogBackgroundColor.Blue)
                Dim info As New TaskDialogInfo("eliminacion".ToUpper, eTaskDialogIcon.Delete, "¿esta seguro de eliminar el registro?".ToUpper, "".ToUpper, eTaskDialogButton.Yes Or eTaskDialogButton.Cancel, eTaskDialogBackgroundColor.Blue)
                Dim result As eTaskDialogResult = TaskDialog.Show(info)
                If result = eTaskDialogResult.Yes Then
                    Dim mensajeError As String = ""
                    Dim res As Boolean = L_prHotelReservaBorrar(numiReg, mensajeError)
                    If res Then
                        ToastNotification.Show(Me, "reserva ".ToUpper + numiReg + " eliminado con Exito.".ToUpper, My.Resources.GRABACION_EXITOSA, 5000, eToastGlowColor.Green, eToastPosition.TopCenter)
                        _prCargarGridRegReservas()
                        _prCargarGridHorario(tbFechaSelect.Value)
                    Else
                        ToastNotification.Show(Me, mensajeError, My.Resources.WARNING, 8000, eToastGlowColor.Red, eToastPosition.TopCenter)
                    End If
                End If
            Else
                ToastNotification.Show(Me, "la reserva ya esta vendida y facturada, no se puede eliminar".ToUpper, My.Resources.WARNING, 8000, eToastGlowColor.Red, eToastPosition.TopCenter)

            End If



        End If
    End Sub

    Private Sub tbAtras_Click(sender As Object, e As EventArgs) Handles tbAtras.Click
        SupTabItemRegistro.Visible = True
        SupTabItemBusqueda.Visible = False
        SuperTabPrincipal.SelectedTabIndex = 0
        _marcando = False
        _RegSelect = -1
    End Sub

    Private Sub grBusquedaCliente_KeyDown(sender As Object, e As KeyEventArgs) Handles grBusquedaCliente.KeyDown
        If (e.KeyData = Keys.Control + Keys.Enter) Then
            If grBusquedaCliente.Row >= 0 Then
                _prAdicionarSeleccionado()
            End If


        End If
    End Sub

    Private Sub ButtonX8_Click(sender As Object, e As EventArgs) Handles ButtonX8.Click
        _prAdicionarNuevoCliente()
    End Sub

    Private Sub ButtonX3_Click(sender As Object, e As EventArgs) Handles ButtonX3.Click
        If _RegSelect < 0 Then
            _prGrabarReserva()
        Else
            _prModificarRegistroDatos()
        End If


    End Sub

    Private Sub AGREGARCOMOENCARGADODERESERVAToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AGREGARCOMOENCARGADODERESERVAToolStripMenuItem.Click
        If grBusquedaCliente.Row >= 0 Then
            Dim ci, numi, nombre As String
            Dim nroSoc As Integer
            ci = grBusquedaCliente.GetValue("haci")
            numi = grBusquedaCliente.GetValue("hanumi")
            nombre = grBusquedaCliente.GetValue("hanom2")
            nroSoc = grBusquedaCliente.GetValue("hansoc")

            tbEncCi.Text = ci
            tbEncNombre.Text = nombre
            tbEncNumi.Text = numi
            If nroSoc > 0 Then
                tbEncEsSocio.Value = True
                gpSocioReferencia.Visible = False
            Else
                tbEncEsSocio.Value = False
                gpSocioReferencia.Visible = True
            End If
            tbSocCi.Text = String.Empty
            tbSocNombre.Text = String.Empty
            tbSocNroSoc.Text = String.Empty
            tbSocNumi.Text = String.Empty

        End If

    End Sub

    Private Sub AGREGARCOMOSOCIODEREFERENCIAToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AGREGARCOMOSOCIODEREFERENCIAToolStripMenuItem.Click
        If grBusquedaCliente.Row >= 0 And tbEncEsSocio.Value = False Then
            Dim ci, numi, nombre As String
            Dim nroSoc As Integer
            ci = grBusquedaCliente.GetValue("haci")
            numi = grBusquedaCliente.GetValue("hanumi")
            nombre = grBusquedaCliente.GetValue("hanom2")
            nroSoc = grBusquedaCliente.GetValue("hansoc")
            If nroSoc > 0 Then
                tbSocCi.Text = ci
                tbSocNombre.Text = nombre
                tbSocNumi.Text = numi
                tbSocNroSoc.Text = nroSoc
            Else
                ToastNotification.Show(Me, "seleccione a un cliente que sea socio".ToUpper, My.Resources.WARNING, 8000, eToastGlowColor.Red, eToastPosition.TopCenter)
            End If

        End If

    End Sub

    Private Sub MODIFICARDATOSDERESERVAToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MODIFICARDATOSDERESERVAToolStripMenuItem.Click
        If grRegReservas.Row >= 0 Then
            _RegSelect = grRegReservas.GetValue("hdnumi")
            '_prCargarDatosReservaParaModificar()
            Dim frm As New F0_HotelReservaFicha
            frm._numiRes = _RegSelect

            frm.ShowDialog()

            If frm._resp Then
                ToastNotification.Show(Me, "se registro la reserva exitosamente".ToUpper, My.Resources.GRABACION_EXITOSA, 5000, eToastGlowColor.Green, eToastPosition.TopCenter)
                _prCargarGridRegReservas()
                _prCargarGridHorario(tbFechaSelect.Value)

            End If
        End If

    End Sub

    Private Sub ELIMINARFILAToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ELIMINARFILAToolStripMenuItem.Click
        If grClientesReg.Row >= 0 Then
            CType(grClientesReg.DataSource, DataTable).Rows(grClientesReg.Row).Delete()
            'Dim estado As Integer = grIncidencias.GetValue("estado")

            'If estado = 1 Then
            '    grIncidencias.GetRow(grIncidencias.Row).BeginEdit()
            '    grIncidencias.CurrentRow.Cells.Item("estado").Value = -1
            'Else
            '    grIncidencias.GetRow(grIncidencias.Row).BeginEdit()
            '    grIncidencias.CurrentRow.Cells.Item("estado").Value = -2
            'End If

            'grIncidencias.RemoveFilters()
            'grIncidencias.RootTable.ApplyFilter(New Janus.Windows.GridEX.GridEXFilterCondition(grIncidencias.RootTable.Columns("estado"), Janus.Windows.GridEX.ConditionOperator.GreaterThan, -1))
        End If
    End Sub


    Private Sub grBusquedaCliente_SelectionChanged(sender As Object, e As EventArgs) Handles grBusquedaCliente.SelectionChanged
        If grBusquedaCliente.Row >= 0 Then
            Dim numiClie As String = grBusquedaCliente.GetValue("hanumi")
            _prCargarGridIncidencias(numiClie)
        End If
    End Sub

    Private Sub ADICIONARRECLAMOToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ADICIONARRECLAMOToolStripMenuItem.Click
        If grRegReservas.Row >= 0 Then
            Dim numiClie As Integer = grRegReservas.GetValue("hdtc1cli")
            Dim numiRese As Integer = grRegReservas.GetValue("hdnumi")
            Dim numi As String = ""
            Dim obs As String = InputBox("INGRESE EL RECLAMO QUE SE DESEA REGISTRAR", "RECLAMO DE LA RESERVA", "").ToUpper
            If obs <> String.Empty Then
                L_prHotelIncidenciaGrabar(numiRese, numiClie, obs)
            End If
        End If

    End Sub

    Private Sub AGREGARCLIENTEToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AGREGARCLIENTEToolStripMenuItem.Click
        If grBusquedaCliente.Row >= 0 Then
            _prAdicionarSeleccionado()
        End If
    End Sub

    Private Sub VERRESERVAToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VERRESERVAToolStripMenuItem.Click
        'Dim frm As New PR_ReservaHotel
        'frm.numiReserva = grRegReservas.GetValue("hdnumi").ToString
        'frm.ShowDialog()
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        If PanelToolBar1.Visible = False Then
            _prLiberarHoraGrabar()
        Else
            _prLiberarHoraEmpezar()
        End If

    End Sub

    Private Sub grHorario_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles grHorario.CellClick
        If _marcarManual = 2 Then
            Dim f1 As Integer = e.RowIndex
            Dim c1 As Integer = e.ColumnIndex
            If IsNothing(_meses.vDias1(f1, c1 - 1)) = False Then
                If _meses.vDias1(f1, c1 - 1).estado = conDiaGrabadoCliente Or _meses.vDias1(f1, c1 - 1).estado = conHoraLiberada Then
                    Exit Sub
                End If

            End If

            Dim numiCab As String = _meses.vdtCabanas.Rows(f1).Item("hbnumi").ToString

            grHorario.CurrentRow.Cells(c1).Style.BackColor = Color.Green
            grHorario.CurrentRow.Cells(c1).Style.ForeColor = Color.Black
            grHorario.CurrentRow.Cells(c1).Value = "I"
            _prInsertarTablaLiberarHora(New Date(tbFechaSelect.Value.Year, tbFechaSelect.Value.Month, c1).ToString("yyyy/MM/dd"), numiCab)
            _meses._prCargarDiaLiberadoMes1(f1, c1 - 1)
            Exit Sub
        End If


        Dim c As Integer = grHorario.CurrentCell.ColumnIndex
        Dim f As Integer = grHorario.CurrentCell.RowIndex
        If f >= 0 And c >= 1 Then
            Dim obj As ClsHDia = _meses.vDias1(f, c - 1)
            If IsNothing(obj) = False Then

                'que seleecione el cliente
                If obj.estado = conDiaGrabadoCliente Then
                    Dim numiReg As Integer = obj.numiCabecera
                    Dim i As Integer = 0
                    For Each fila As GridEXRow In grRegReservas.GetRows
                        If fila.Cells("hdnumi").Value = numiReg Then
                            Exit For
                        End If
                        i = i + 1
                    Next

                    grRegReservas.Row = -2


                    Dim dt As DataTable = CType(grRegReservas.DataSource, DataTable)
                    For j = 0 To dt.Rows.Count - 1
                        Try
                            dt.Rows(j).Item("select") = 0
                            If j = i Then
                                dt.Rows(j).Item("select") = 1

                            End If
                        Catch ex As Exception

                        End Try

                    Next


                End If
            End If


        End If

    End Sub

    Private Sub grHorario_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles grHorario.CellDoubleClick
        Dim c As Integer = grHorario.CurrentCell.ColumnIndex
        Dim f As Integer = grHorario.CurrentCell.RowIndex


        If f >= 0 And c >= 1 Then
            Dim obj As ClsHDia = _meses.vDias1(f, c - 1)
            If IsNothing(obj) = False Then
                If obj.estado = conHoraLiberada Then 'obj.estado = conDiaGrabadoCliente Or 
                    ToastNotification.Show(Me, obj.obs.ToUpper, My.Resources.INFORMATION, 5000, eToastGlowColor.Blue, eToastPosition.TopCenter)
                End If

                'que seleecione el cliente
                'If obj.estado = conDiaGrabadoCliente Then
                '    Dim numiReg As Integer = obj.numiCabecera
                '    Dim i As Integer = 0
                '    For Each fila As GridEXRow In grRegReservas.GetRows
                '        If fila.Cells("hdnumi").Value = numiReg Then
                '            Exit For
                '        End If
                '        i = i + 1
                '    Next

                '    grRegReservas.Row = i


                'End If
            End If


        End If

    End Sub

    Private Sub RESERVANOUSADAToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RESERVANOUSADAToolStripMenuItem.Click
        If grRegReservas.Row >= 0 Then
            'Dim numiClie As Integer = grRegReservas.GetValue("hdtc1cli")
            Dim numiRes As Integer = grRegReservas.GetValue("hdnumi")

            Dim respuesta As Double = L_prHotelReservaModificarEstado(numiRes, conEstResPagadaCancelada)
            If respuesta Then
                ToastNotification.Show(Me, "se cambio el estado de la reserva".ToUpper, My.Resources.INFORMATION, 5000, eToastGlowColor.Green, eToastPosition.TopCenter)
                _prCargarGridRegReservas()
                _prCargarGridHorario(tbFechaSelect.Value)
            End If

            'Dim obs As String = InputBox("INGRESE EL RECLAMO QUE SE DESEA REGISTRAR", "RECLAMO DE LA RESERVA", "").ToUpper
            'If obs <> String.Empty Then
            '    L_prHotelIncidenciaGrabar(numiRese, numiClie, obs)
            'End If
        End If
    End Sub

    Private Sub VERRESERVAToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles VERRESERVAToolStripMenuItem1.Click
        Dim frm As New PR_ReservaHotel
        frm.numiReserva = grRegReservas.GetValue("hdnumi").ToString
        frm.ShowDialog()
    End Sub

    Private Sub RESERVAOCUPADAToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RESERVAOCUPADAToolStripMenuItem.Click
        If grRegReservas.Row >= 0 Then
            'Dim numiClie As Integer = grRegReservas.GetValue("hdtc1cli")
            Dim numiRes As Integer = grRegReservas.GetValue("hdnumi")

            Dim respuesta As Double = L_prHotelReservaModificarEstado(numiRes, conEstResConfirmadaPagada)
            If respuesta Then
                ToastNotification.Show(Me, "se cambio el estado de la reserva".ToUpper, My.Resources.INFORMATION, 5000, eToastGlowColor.Green, eToastPosition.TopCenter)
                _prCargarGridRegReservas()
                _prCargarGridHorario(tbFechaSelect.Value)
            End If

            'Dim obs As String = InputBox("INGRESE EL RECLAMO QUE SE DESEA REGISTRAR", "RECLAMO DE LA RESERVA", "").ToUpper
            'If obs <> String.Empty Then
            '    L_prHotelIncidenciaGrabar(numiRese, numiClie, obs)
            'End If
        End If
    End Sub

    Private Sub CANCELARToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CANCELARToolStripMenuItem.Click
        If grRegReservas.Row >= 0 Then
            'Dim numiClie As Integer = grRegReservas.GetValue("hdtc1cli")
            Dim numiRes As Integer = grRegReservas.GetValue("hdnumi")

            Dim respuesta As Double = L_prHotelReservaModificarEstado(numiRes, conEstResRealizada)
            If respuesta Then
                ToastNotification.Show(Me, "se cambio el estado de la reserva".ToUpper, My.Resources.INFORMATION, 5000, eToastGlowColor.Green, eToastPosition.TopCenter)
                _prCargarGridRegReservas()
                _prCargarGridHorario(tbFechaSelect.Value)
            End If

            'Dim obs As String = InputBox("INGRESE EL RECLAMO QUE SE DESEA REGISTRAR", "RECLAMO DE LA RESERVA", "").ToUpper
            'If obs <> String.Empty Then
            '    L_prHotelIncidenciaGrabar(numiRese, numiClie, obs)
            'End If
        End If
    End Sub

    'RESERVAR EN HOTEL
    Private Sub btnGrabar_Click(sender As Object, e As EventArgs) Handles btnGrabar.Click
        Dim frm As New F0_HotelReservaFicha
        frm.ShowDialog()

        If frm._resp Then
            ToastNotification.Show(Me, "se registro la reserva exitosamente".ToUpper, My.Resources.GRABACION_EXITOSA, 5000, eToastGlowColor.Green, eToastPosition.TopCenter)
            _prCargarGridRegReservas()
            _prCargarGridHorario(tbFechaSelect.Value)
          
        End If
    End Sub

    Private Sub grHorario_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles grHorario.CellBeginEdit
        e.Cancel = True
    End Sub

    Private Sub grRegReservas_SelectionChanged(sender As Object, e As EventArgs) Handles grRegReservas.SelectionChanged
        If Not IsNothing(grHorario.DataSource) Then
            If grRegReservas.Row >= 0 Then
                Dim dt As DataTable = CType(grRegReservas.DataSource, DataTable)
                For j = 0 To dt.Rows.Count - 1
                    dt.Rows(j).Item("select") = 0

                Next

                _prSeleccionarHoras()
            Else

            End If
        End If
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim dtReservasCanceladas As DataTable = L_prHotelReservaGetReservasCanceladas()
        Dim frmAyuda As Modelos.ModeloAyuda
        Dim listEstCeldas As New List(Of Modelos.Celda)
        listEstCeldas.Add(New Modelos.Celda("hdnumi", True, "Cod. res.".ToUpper, 70))
        listEstCeldas.Add(New Modelos.Celda("hdtc1cli", False,))
        listEstCeldas.Add(New Modelos.Celda("hdtc1cli2", True, "Cliente Encargado".ToUpper, 200))
        listEstCeldas.Add(New Modelos.Celda("hansoc", False,))
        listEstCeldas.Add(New Modelos.Celda("hdfcin", True, "Fecha ing".ToUpper, 70))
        listEstCeldas.Add(New Modelos.Celda("hdfcou", True, "fecha sal".ToUpper, 70))
        listEstCeldas.Add(New Modelos.Celda("hdtc2cab", False,))
        listEstCeldas.Add(New Modelos.Celda("hbnom", True, "cabaña".ToUpper, 120))
        listEstCeldas.Add(New Modelos.Celda("hdest", False,))
        listEstCeldas.Add(New Modelos.Celda("hdtip", False,))
        listEstCeldas.Add(New Modelos.Celda("hdtc1soc", False,))
        listEstCeldas.Add(New Modelos.Celda("hdtc1soc2", True, "Socio de referencia".ToUpper, 200))
        listEstCeldas.Add(New Modelos.Celda("hdlugres", False,))
        listEstCeldas.Add(New Modelos.Celda("hdlugres2", True, "lugar res".ToUpper, 120))


        frmAyuda = New Modelos.ModeloAyuda(0, 0, dtReservasCanceladas, "seleccione la reserva cancelada que desea reasignar".ToUpper, listEstCeldas)
        frmAyuda.ShowDialog()

        If frmAyuda.seleccionado = True Then
            Dim numiRes As String = frmAyuda.filaSelect.Cells("hdnumi").Value
            Dim fechaIn As DateTime = frmAyuda.filaSelect.Cells("hdfcin").Value
            Dim fechaOut As DateTime = frmAyuda.filaSelect.Cells("hdfcou").Value

            Dim cantNoches As Integer = DateDiff(DateInterval.Day, fechaIn, fechaOut) + 1


            Dim frm As New F0_HotelReservaFicha
            frm._numiRes = numiRes
            frm._ReasignacionReserva = True
            frm._diasPermitidos = cantNoches
            frm.ShowDialog()

            If frm._resp Then
                ToastNotification.Show(Me, "se reasigno la reserva exitosamente".ToUpper, My.Resources.GRABACION_EXITOSA, 5000, eToastGlowColor.Green, eToastPosition.TopCenter)
                _prCargarGridRegReservas()
                _prCargarGridHorario(tbFechaSelect.Value)

            End If
        End If
    End Sub
End Class