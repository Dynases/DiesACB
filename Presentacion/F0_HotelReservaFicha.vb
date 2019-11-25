
Imports Logica.AccesoLogica
Imports Janus.Windows.GridEX
Imports DevComponents.DotNetBar
Imports System.IO
Imports DevComponents.DotNetBar.SuperGrid

Public Class F0_HotelReservaFicha

    Const conEstResRealizada As Integer = 1
    Private _detalleClientes As DataTable
    Public _resp As Boolean
    Private _frmHuesped As F0_HotelReservaHuespedes

    Public _numiRes As Integer = -1
    Public _ReasignacionReserva As Boolean = False
    Public _diasPermitidos As Integer = 0


    Const conEstResConfirmadaPagada As Integer = 2
    Const conEstResPagadaCancelada As Integer = 3 'Const conEstResSinOcupar As Integer = 3
    Const conEstResReasignada As Integer = 4
    Const conEstResOriginalReasignada As Integer = 5

#Region "Metodos privados"
    Public Sub _prIniciarTodo()


        _prInhabilitar()
        _prLimpiar()
        _prHabilitarFocus()
        tbUsuarioEncargado.Text = P_Global.gs_user

        _frmHuesped = New F0_HotelReservaHuespedes(_numiRes)
        If _numiRes > 0 Then
            _prCargarDatos()
        End If


        If _ReasignacionReserva = True Then
            tbFechaIn.Enabled = True
            tbFechaOut.Enabled = True
            tbTipo.ReadOnly = True

            grCabañas.Visible = True
            btnVerDisponibilidad.Visible = True
        End If
    End Sub

    Private Sub _prCargarComboPreciosCabaña(_numiCab)
        Dim dt As New DataTable
        dt = L_prCabañaDetalleBasicodgr(_numiCab)

        With tbTipo
            .DropDownList.Columns.Clear()

            .DropDownList.Columns.Add("cedesc1").Width = 200
            .DropDownList.Columns("cedesc1").Caption = "tipo tarifa".ToUpper

            .DropDownList.Columns.Add("hgprecio").Width = 70
            .DropDownList.Columns("hgprecio").Caption = "precio".ToUpper

            .ValueMember = "hgprecio"
            .DisplayMember = "cedesc1"
            .DataSource = dt
            .Refresh()
        End With


    End Sub

    Private Sub _prCargarDatos()
        Dim dtRes As DataTable = L_prHotelReservaGetReservaCompleta(_numiRes)
        tbFechaIn.Value = dtRes.Rows(0).Item("hdfcin")
        tbFechaOut.Value = dtRes.Rows(0).Item("hdfcou")
        tbObs.Text = dtRes.Rows(0).Item("hdobs")
        tbUsuarioEncargado.Text = dtRes.Rows(0).Item("hdencres").ToString

        tbClienteAlDia.Value = True
        tbSocioRefAlDia.Value = True


        Dim lugReserva As Boolean
        If IsDBNull(dtRes.Rows(0).Item("hdlugres")) Then
            lugReserva = True
        Else
            If dtRes.Rows(0).Item("hdlugres") = 1 Then
                lugReserva = True
            Else
                lugReserva = False
            End If

        End If
        tbLugRes.Value = lugReserva

        tbEsSocio.Value = IIf(dtRes.Rows(0).Item("hdtip") = 1, True, False)
        If tbEsSocio.Value = False Then
            gpSocioRef.Visible = True
            tbSocioRef.Tag = dtRes.Rows(0).Item("hdtc1soc")
            tbSocioRef.Text = dtRes.Rows(0).Item("hdtc1soc2")
        End If

        tbEncargadoRes.Tag = dtRes.Rows(0).Item("hdtc1cli")
        tbEncargadoRes.Text = dtRes.Rows(0).Item("hdtc1cli2")

        tbCabaña.Tag = dtRes.Rows(0).Item("hdtc2cab")
        tbCabaña.Text = dtRes.Rows(0).Item("hbnom")

        tbPrecio.Value = dtRes.Rows(0).Item("hdprecio")
        tbTotal.Value = IIf(IsDBNull(dtRes.Rows(0).Item("hdtotal")) = True, 0, dtRes.Rows(0).Item("hdtotal"))

        _prCargarComboPreciosCabaña(dtRes.Rows(0).Item("hdtc2cab"))

        tbFechaIn.Enabled = False
        tbFechaOut.Enabled = False
        tbCantPers.Enabled = False
        grCabañas.Visible = False
        btnVerDisponibilidad.Visible = False
        tbTipo.ReadOnly = True
        tbTotal.IsInputReadOnly = True
        'panelCabaña.Visible = True
    End Sub

    Private Sub _prBuscarDisponibilidad()
        If tbFechaIn.Value > tbFechaOut.Value Then
            ToastNotification.Show(Me, "la fecha de ingreso es mayor a la fecha de salida".ToUpper, My.Resources.WARNING, 5000, eToastGlowColor.Red, eToastPosition.TopCenter)
            Exit Sub
        End If

        Dim dt As New DataTable
        'dt = L_prHotelReservaGetCabañasRangoFecha(tbFechaIn.Value.ToString("yyyy/MM/dd"), tbFechaOut.Value.ToString("yyyy/MM/dd"), tbCantPers.Value)
        dt = L_prHotelReservaGetCabañasPorCantPersonas(tbCantPers.Value)
        'empiezo a discriminar solamente las cabañas que estan libres
        Dim i As Integer = 0

        While i <= dt.Rows.Count - 1 Or dt.Rows.Count = 0
            Dim fechaIni As Date = tbFechaIn.Value
            Dim ocupado As Boolean = False
            While fechaIni <= tbFechaOut.Value
                Dim dtResCab As DataTable = L_prHotelReservaGetReservasEnFechaYCabaña(fechaIni.ToString("yyyy/MM/dd"), dt.Rows(i).Item("hbnumi"))
                If dtResCab.Rows.Count >= 1 Then
                    ocupado = True
                    Exit While
                End If

                Dim dtCabLiberada As DataTable = L_prHotelReservaGetLiberadosPorFechaYCabaña(fechaIni.ToString("yyyy/MM/dd"), dt.Rows(i).Item("hbnumi"))
                If dtResCab.Rows.Count >= 1 Then
                    ocupado = True
                    Exit While
                End If
                fechaIni = DateAdd(DateInterval.Day, 1, fechaIni)
            End While

            If ocupado = True Then
                dt.Rows.RemoveAt(i)
            Else
                i = i + 1
            End If
        End While


        grCabañas.DataSource = dt
        grCabañas.RetrieveStructure()

        'dar formato a las columnas
        With grCabañas.RootTable.Columns("hbnumi")
            .Caption = "Cod.".ToUpper
            .Visible = True
            .Width = 70
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .EditType = EditType.NoEdit
        End With


        With grCabañas.RootTable.Columns("hbnom")
            .Caption = "CABAÑA"
            .Width = 300
            .EditType = EditType.NoEdit
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
        End With

        With grCabañas.RootTable.Columns("ok")
            .Visible = False
            .Caption = "OK"
            .Width = 70
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
        End With

        'Habilitar Filtradores
        With grCabañas
            '.DefaultFilterRowComparison = FilterConditionOperator.Contains
            '.FilterMode = FilterMode.Automatic
            '.FilterRowUpdateMode = FilterRowUpdateMode.WhenValueChanges
            .GroupByBoxVisible = False

            'diseño de la grilla
            .VisualStyle = VisualStyle.Office2007
        End With
        grCabañas.SelectionMode = SelectionMode.SingleSelection
        grCabañas.SelectedFormatStyle.BackColor = Color.Green


        'cargar condicion
        'Dim fc As GridEXFormatCondition
        'fc = New GridEXFormatCondition(grCabañas.RootTable.Columns("clasesFalt"), ConditionOperator.GreaterThan, 0)
        'fc.FormatStyle.ForeColor = Color.Red
        'grCabañas.RootTable.FormatConditions.Add(fc)

    End Sub



    Private Sub _prLimpiar()
        tbFechaIn.Value = Now.Date
        tbFechaOut.Value = Now.Date

    End Sub
    Private Sub _prInhabilitar()
        tbEncargadoRes.ReadOnly = True
        tbSocioRef.ReadOnly = True

        gpSocioRef.Visible = False
        btnVerReclamos.Visible = False

        tbCabaña.ReadOnly = True
        'panelCabaña.Visible = False

        btnAddNuevoCliente.Visible = False
        'btnAddNuevoCliente.Visible = False
    End Sub
    Public Sub _prHabilitarFocus()
        With MHighlighterFocus
            .SetHighlightOnFocus(tbEncargadoRes, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
            .SetHighlightOnFocus(tbCantPers, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
            .SetHighlightOnFocus(tbFechaIn, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
            .SetHighlightOnFocus(tbFechaOut, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)

        End With
    End Sub
    Public Function _prValidar() As Boolean
        Dim _ok As Boolean = True
        MEP.Clear()

        If tbEncargadoRes.Text = String.Empty Then
            tbEncargadoRes.BackColor = Color.Red
            MEP.SetError(tbEncargadoRes, "seleccione el encargado de la reserva!".ToUpper)
            _ok = False
        Else
            tbEncargadoRes.BackColor = Color.White
            MEP.SetError(tbEncargadoRes, "")
        End If

        If btnAddNuevoCliente.Visible = True Then
            btnAddNuevoCliente.BackColor = Color.Red
            MEP.SetError(btnAddNuevoCliente, "adicionar nuevo cliente o seleccionar uno ya registrado en sistema!".ToUpper)
            _ok = False
        Else
            btnAddNuevoCliente.BackColor = Color.White
            MEP.SetError(btnAddNuevoCliente, "")
        End If

        If tbEsSocio.Value = False Then
            If tbSocioRef.Text = String.Empty Then
                tbSocioRef.BackColor = Color.Red
                MEP.SetError(tbSocioRef, "seleccione el socio de referencia".ToUpper)
                _ok = False
            Else
                tbSocioRef.BackColor = Color.White
                MEP.SetError(tbSocioRef, "")
            End If

            If tbSocioRefAlDia.Value = False Then
                tbSocioRefAlDia.BackColor = Color.Red
                MEP.SetError(tbSocioRefAlDia, "socio en mora, no puede realizar reserva!".ToUpper)
                _ok = False
            Else
                tbSocioRefAlDia.BackColor = Color.White
                MEP.SetError(tbSocioRefAlDia, "")
            End If
        End If

        If btnVerDisponibilidad.Visible = True Then
            If grCabañas.RowCount = 0 Then
                btnVerDisponibilidad.BackColor = Color.Red
                MEP.SetError(btnVerDisponibilidad, "seleccione cabaña!".ToUpper)
                _ok = False
            Else
                btnVerDisponibilidad.BackColor = Color.White
                MEP.SetError(btnVerDisponibilidad, "")
            End If
        End If

        If tbEsSocio.Value = True Then
            If tbClienteAlDia.Value = False Then
                tbClienteAlDia.BackColor = Color.Red
                MEP.SetError(tbClienteAlDia, "socio en mora, no puede realizar reserva!".ToUpper)
                _ok = False
            Else
                tbClienteAlDia.BackColor = Color.White
                MEP.SetError(tbClienteAlDia, "")
            End If
        End If

        'preguntar si la cantidad de noches es la misma
        If _ReasignacionReserva = True Then
            Dim cantNoches As Integer = DateDiff(DateInterval.Day, tbFechaIn.Value, tbFechaOut.Value) + 1
            If _diasPermitidos <> cantNoches Then
                ToastNotification.Show(Me, "solo se permiten ".ToUpper + _diasPermitidos.ToString + " noches para programar".ToUpper, My.Resources.WARNING, 8000, eToastGlowColor.Red, eToastPosition.TopCenter)

                _ok = False

            End If
        End If

        MHighlighterFocus.UpdateHighlights()
        Return _ok

    End Function

    Private Sub _prGrabarReserva()
        If _prValidar() Then
            If _numiRes = -1 Then
                Dim numiCli As String = tbEncargadoRes.Tag.ToString
                Dim numi As String = ""
                Dim obs As String = tbObs.Text
                Dim numiCabana As String = grCabañas.GetValue("hbnumi") '_prObtenerNumiCabaña()
                Dim dtDetalle As DataTable = _frmHuesped._dtGrid
                Dim tipo As String = IIf(tbEsSocio.Value = True, "1", "0")
                Dim refSocio As String = IIf(tbEsSocio.Value = True, "0", tbSocioRef.Tag)
                Dim lugReserva As String = IIf(tbLugRes.Value = True, "1", "2")
                Dim respuesta As Boolean = L_prHotelReservaGrabar(numi, Now.Date.ToString("yyyy/MM/dd"), numiCli, tbFechaIn.Value.ToString("yyyy/MM/dd"), tbFechaOut.Value.ToString("yyyy/MM/dd"), numiCabana, obs, conEstResRealizada, tipo, refSocio, lugReserva, tbUsuarioEncargado.Text, tbPrecio.Value, tbTotal.Value, dtDetalle)
                If respuesta Then
                    _resp = True
                    Close()
                End If
            Else
                If _ReasignacionReserva = True Then
                    Dim numiCli As String = tbEncargadoRes.Tag.ToString
                    Dim numi As String = ""
                    Dim obs As String = tbObs.Text
                    Dim numiCabana As String = grCabañas.GetValue("hbnumi") '_prObtenerNumiCabaña()
                    Dim dtDetalle As DataTable = _frmHuesped._dtGrid
                    Dim tipo As String = IIf(tbEsSocio.Value = True, "1", "0")
                    Dim refSocio As String = IIf(tbEsSocio.Value = True, "0", tbSocioRef.Tag)
                    Dim lugReserva As String = IIf(tbLugRes.Value = True, "1", "2")
                    Dim respuesta As Boolean = L_prHotelReservaGrabar(numi, Now.Date.ToString("yyyy/MM/dd"), numiCli, tbFechaIn.Value.ToString("yyyy/MM/dd"), tbFechaOut.Value.ToString("yyyy/MM/dd"), numiCabana, obs, conEstResRealizada, tipo, refSocio, lugReserva, tbUsuarioEncargado.Text, tbPrecio.Value, tbTotal.Value, dtDetalle)
                    If respuesta Then
                        _resp = True

                        'ahora cambio el estado de la reserva original
                        Dim numiRes As Integer = _numiRes
                        L_prHotelReservaModificarEstado(numiRes, conEstResOriginalReasignada)

                        Close()
                    End If
                Else 'entonces es una modificacion
                    Dim numiCli As String = tbEncargadoRes.Tag.ToString
                    Dim numi As String = _numiRes
                    Dim obs As String = tbObs.Text

                    Dim dtDetalle As DataTable = _frmHuesped._dtGrid
                    Dim tipo As String = IIf(tbEsSocio.Value = True, "1", "0")
                    Dim refSocio As String = IIf(tbEsSocio.Value = True, "0", tbSocioRef.Tag)
                    Dim lugReserva As String = IIf(tbLugRes.Value = True, "1", "2")

                    Dim respuesta As Boolean = L_prHotelReservaModificarDatos(numi, numiCli, tbObs.Text, tipo, refSocio, lugReserva, tbPrecio.Value, dtDetalle)
                    If respuesta Then
                        _resp = True
                        Close()
                    End If
                End If

            End If

        End If

    End Sub

    Private Sub _prCalcularTotal()
        Dim cantNoches As Integer = DateDiff(DateInterval.Day, tbFechaIn.Value, tbFechaOut.Value) + 1
        tbTotal.Value = cantNoches * tbPrecio.Value
    End Sub

#End Region

    Private Sub F_ClienteNuevoServicio_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _prIniciarTodo()
        _prHabilitarFocus()

    End Sub



    Private Sub ModeloHor_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MyBase.KeyPress

        e.KeyChar = e.KeyChar.ToString.ToUpper
        If (e.KeyChar = ChrW(Keys.Enter)) Then
            e.Handled = True
            P_Moverenfoque()
        End If
    End Sub

    Private Sub P_Moverenfoque()
        SendKeys.Send("{TAB}")
    End Sub


    Private Sub btnSalir_Click_1(sender As Object, e As EventArgs) Handles btnSalir.Click
        _resp = False
        Close()
    End Sub

    Private Sub ButtonX1_Click(sender As Object, e As EventArgs) Handles btnVerDisponibilidad.Click
        _prBuscarDisponibilidad()
    End Sub

    Private Sub tbEncargadoRes_KeyDown(sender As Object, e As KeyEventArgs) Handles tbEncargadoRes.KeyDown
        If e.KeyData = Keys.Control + Keys.Enter Then
            If _ReasignacionReserva = True Then
                Return
            End If

            'grabar horario
            Dim frmAyuda As Modelos.ModeloAyuda
            Dim dt As DataTable
            dt = L_prHotelReservaGetClientes()

            Dim listEstCeldas As New List(Of Modelos.Celda)
            listEstCeldas.Add(New Modelos.Celda("hanumi", True, "Codigo".ToUpper, 70))
            listEstCeldas.Add(New Modelos.Celda("hansoc", True, "Nro socio".ToUpper, 70))
            listEstCeldas.Add(New Modelos.Celda("haci", True, "ci".ToUpper, 100))
            listEstCeldas.Add(New Modelos.Celda("hanom2", True, "nombre".ToUpper, 200))
            listEstCeldas.Add(New Modelos.Celda("hafnac", True, "fecha nac.".ToUpper, 100))
            listEstCeldas.Add(New Modelos.Celda("cftsoc", False))

            frmAyuda = New Modelos.ModeloAyuda(0, 0, dt, "seleccione el encargado de la reserva".ToUpper, listEstCeldas)

            Dim fc As GridEXFormatCondition
            fc = New GridEXFormatCondition(frmAyuda.grJBuscador.RootTable.Columns("hansoc"), ConditionOperator.GreaterThan, 0)
            fc.FormatStyle.BackColor = Color.LightGreen
            frmAyuda.grJBuscador.RootTable.FormatConditions.Add(fc)

            frmAyuda.ShowDialog()

            If frmAyuda.seleccionado = True Then
                Dim numi As String = frmAyuda.filaSelect.Cells("hanumi").Value
                Dim nombre As String = frmAyuda.filaSelect.Cells("hanom2").Value
                Dim nroSocio As String = frmAyuda.filaSelect.Cells("hansoc").Value
                Dim tipoSocio As Integer = frmAyuda.filaSelect.Cells("cftsoc").Value

                If frmAyuda.grJBuscador.RowCount = 0 Then
                    tbEncargadoRes.Tag = 0
                    tbEncargadoRes.Text = nombre
                    btnAddNuevoCliente.Visible = True

                    gpSocioRef.Visible = True
                    tbEsSocio.Value = False
                    tbSocioRef.Text = ""
                Else
                    tbEncargadoRes.Tag = numi
                    tbEncargadoRes.Text = nombre
                    btnAddNuevoCliente.Visible = False


                    If nroSocio = 0 Then
                        gpSocioRef.Visible = True
                        tbEsSocio.Value = False
                        tbSocioRef.Text = ""
                        tbClienteAlDia.Visible = False
                    Else
                        gpSocioRef.Visible = False
                        tbEsSocio.Value = True
                        tbClienteAlDia.Visible = True

                    End If

                    Dim dtIncidencias As DataTable = L_prHotelIncidenciaDetalleClientes(numi)
                    If dtIncidencias.Rows.Count > 0 Then
                        btnVerReclamos.Visible = True
                    Else
                        btnVerReclamos.Visible = False
                    End If

                    If nroSocio <> 0 Then
                        'pregunto si es socio honorario o meritorio para no preguntar sus pagos
                        If tipoSocio = 2 Or tipoSocio = 3 Then
                            tbClienteAlDia.Value = True
                        Else
                            'pregunto si el socio esta en mora
                            Dim dtPagos As DataTable = L_prObtenerUltimoPagoSocio(nroSocio)
                            If dtPagos.Rows.Count = 0 Then
                                Dim dtRegSocio As DataTable = L_prHotelReservaObtenerSocioConFechaIngresoYMora(nroSocio)
                                Dim fechaIngreso As DateTime = dtRegSocio.Rows(0).Item("cffing")
                                Dim mesesDiferencia As Integer = DateDiff(DateInterval.Month, fechaIngreso, Now)
                                'If fechaIngreso.Day > Now.Day Then
                                '    mesesDiferencia = mesesDiferencia - 1
                                'End If

                                If mesesDiferencia >= dtRegSocio.Rows(0).Item("mora") Then
                                    tbClienteAlDia.Value = False

                                Else
                                    tbClienteAlDia.Value = True

                                End If
                            Else
                                'tbFechaPago.Text = "Mes: " + FechaPago.Rows(0).Item("semes").ToString + " Año: " + FechaPago.Rows(0).Item("seano").ToString
                                If Now.Year >= dtPagos.Rows(0).Item("seano") Then

                                    If (Now.Year = dtPagos.Rows(0).Item("seano") Or Now.Year = dtPagos.Rows(0).Item("seano") + 1) Then
                                        Dim MesSitema As Integer = dtPagos.Rows(0).Item("semes")
                                        Dim mora As Integer = dtPagos.Rows(0).Item("mora")

                                        Dim FechaDePago As Date = New Date(dtPagos.Rows(0).Item("seano"), dtPagos.Rows(0).Item("semes"), 1)
                                        Dim fecha As Date = Date.Now.AddMonths(-mora)
                                        fecha = fecha.AddDays(-(fecha.Day) + 1)

                                        If ((fecha <= FechaDePago)) Then
                                            tbClienteAlDia.Value = True
                                        Else
                                            tbClienteAlDia.Value = False
                                        End If

                                    Else
                                        tbClienteAlDia.Value = False
                                    End If
                                Else
                                    tbClienteAlDia.Value = True
                                End If
                            End If
                            End If

                    End If


                End If

            End If


        End If
    End Sub

    Private Sub tbSocioRef_KeyDown(sender As Object, e As KeyEventArgs) Handles tbSocioRef.KeyDown
        If e.KeyData = Keys.Control + Keys.Enter Then

            'grabar horario
            Dim frmAyuda As Modelos.ModeloAyuda
            Dim dt As DataTable
            dt = L_prHotelReservaGetClientesSoloSocios()

            Dim listEstCeldas As New List(Of Modelos.Celda)
            listEstCeldas.Add(New Modelos.Celda("hanumi", True, "Codigo".ToUpper, 70))
            listEstCeldas.Add(New Modelos.Celda("hansoc", True, "Nro socio".ToUpper, 70))
            listEstCeldas.Add(New Modelos.Celda("haci", True, "ci".ToUpper, 100))
            listEstCeldas.Add(New Modelos.Celda("hanom2", True, "nombre".ToUpper, 200))
            listEstCeldas.Add(New Modelos.Celda("hafnac", True, "fecha nac.".ToUpper, 100))
            listEstCeldas.Add(New Modelos.Celda("cftsoc", False))

            frmAyuda = New Modelos.ModeloAyuda(0, 0, dt, "seleccione socio de referencia".ToUpper, listEstCeldas)
            frmAyuda.ShowDialog()

            If frmAyuda.seleccionado = True Then
                Dim numi As String = frmAyuda.filaSelect.Cells("hanumi").Value
                Dim nombre As String = frmAyuda.filaSelect.Cells("hanom2").Value
                Dim nroSocio As String = frmAyuda.filaSelect.Cells("hansoc").Value
                Dim tipoSocio As Integer = frmAyuda.filaSelect.Cells("cftsoc").Value

                tbSocioRef.Tag = numi
                tbSocioRef.Text = nombre

                'pregunto si el socio es honorable
                If tipoSocio = 2 Or tipoSocio = 3 Then
                    tbSocioRefAlDia.Value = True

                Else
                    'pregunto si el socio esta en mora
                    Dim dtPagos As DataTable = L_prObtenerUltimoPagoSocio(nroSocio)
                    If dtPagos.Rows.Count = 0 Then
                        tbSocioRefAlDia.Value = False

                        Dim dtRegSocio As DataTable = L_prHotelReservaObtenerSocioConFechaIngresoYMora(nroSocio)
                        Dim fechaIngreso As DateTime = dtRegSocio.Rows(0).Item("cffing")
                        Dim mesesDiferencia As Integer = DateDiff(DateInterval.Month, fechaIngreso, Now)
                        'If fechaIngreso.Day > Now.Day Then
                        '    mesesDiferencia = mesesDiferencia - 1
                        'End If

                        If mesesDiferencia >= dtRegSocio.Rows(0).Item("mora") Then
                            tbSocioRefAlDia.Value = False

                        Else
                            tbSocioRefAlDia.Value = True

                        End If
                    Else
                        'tbFechaPago.Text = "Mes: " + FechaPago.Rows(0).Item("semes").ToString + " Año: " + FechaPago.Rows(0).Item("seano").ToString
                        If Now.Year >= dtPagos.Rows(0).Item("seano") Then
                            If (Now.Year = dtPagos.Rows(0).Item("seano") Or Now.Year = dtPagos.Rows(0).Item("seano") + 1) Then
                                Dim MesSitema As Integer = dtPagos.Rows(0).Item("semes")
                                Dim mora As Integer = dtPagos.Rows(0).Item("mora")

                                Dim FechaDePago As Date = New Date(dtPagos.Rows(0).Item("seano"), dtPagos.Rows(0).Item("semes"), 1)
                                Dim fecha As Date = Date.Now.AddMonths(-mora)
                                fecha = fecha.AddDays(-(fecha.Day) + 1)

                                If ((fecha <= FechaDePago)) Then
                                    tbSocioRefAlDia.Value = True
                                Else
                                    tbSocioRefAlDia.Value = False
                                End If

                            Else
                                tbSocioRefAlDia.Value = False
                            End If
                        Else
                            tbSocioRefAlDia.Value = True
                        End If
                    End If
                    End If


            End If


        End If
    End Sub

    Private Sub btnVerReclamos_Click(sender As Object, e As EventArgs) Handles btnVerReclamos.Click

        'grabar horario
        Dim frmAyuda As Modelos.ModeloAyuda
        Dim dt As DataTable
        dt = L_prHotelIncidenciaDetalleClientes(tbEncargadoRes.Tag.ToString)

        Dim listEstCeldas As New List(Of Modelos.Celda)
        listEstCeldas.Add(New Modelos.Celda("efnumi", False))
        listEstCeldas.Add(New Modelos.Celda("eftc1cli", False))
        listEstCeldas.Add(New Modelos.Celda("eftc3res", True, "Cod. Reserva".ToUpper, 80))
        listEstCeldas.Add(New Modelos.Celda("hdfcin", True, "fecha ing.".ToUpper, 100))
        listEstCeldas.Add(New Modelos.Celda("hdfcou", True, "fecha sal.".ToUpper, 100))
        listEstCeldas.Add(New Modelos.Celda("efobs", True, "observacion".ToUpper, 400))

        frmAyuda = New Modelos.ModeloAyuda(0, 0, dt, "reclamos registrados del huesped".ToUpper, listEstCeldas)
        frmAyuda.ShowDialog()

    End Sub

    Private Sub btnAddNuevoCliente_Click(sender As Object, e As EventArgs) Handles btnAddNuevoCliente.Click
        Dim frmCli As New F0_HotelReserva_Cliente
        frmCli.tbNombre.Text = tbEncargadoRes.Text
        frmCli.ShowDialog()
        If frmCli.respuesta Then
            tbEncargadoRes.Text = frmCli.nombre
            tbEncargadoRes.Tag = frmCli.numiCli
            gpSocioRef.Visible = True
            tbEsSocio.Value = False
            tbSocioRef.Text = ""
            tbClienteAlDia.Visible = False

            btnAddNuevoCliente.Visible = False
        End If
    End Sub

    Private Sub btnGrabar_Click(sender As Object, e As EventArgs) Handles btnGrabar.Click
        _prGrabarReserva()
    End Sub

    Private Sub btnAddClientes_Click(sender As Object, e As EventArgs) Handles btnAddClientes.Click
        _frmHuesped.ShowDialog()
    End Sub

    Private Sub tbNoches_ValueChanged(sender As Object, e As EventArgs) Handles tbNoches.ValueChanged
        'tbFechaOut.Value = DateAdd(DateInterval.Day, tbNoches.Value - 1, tbFechaIn.Value)
        _prCalcularTotal()

    End Sub

    Private Sub tbFechaIn_ValueChanged(sender As Object, e As EventArgs) Handles tbFechaIn.ValueChanged
        'tbFechaOut.Value = DateAdd(DateInterval.Day, tbNoches.Value - 1, tbFechaIn.Value)
        If _ReasignacionReserva = False Then
            _prCalcularTotal()
        End If

    End Sub

    Private Sub tbFechaOut_ValueChanged(sender As Object, e As EventArgs) Handles tbFechaOut.ValueChanged
        'tbNoches.Value = DateDiff(DateInterval.Day, tbFechaIn.Value, tbFechaOut.Value) - 1
        If _ReasignacionReserva = False Then
            _prCalcularTotal()

        End If

    End Sub

    Private Sub tbTipo_ValueChanged(sender As Object, e As EventArgs)
        If tbTipo.SelectedIndex >= 0 Then
            tbPrecio.Value = tbTipo.Value
        End If

    End Sub

    Private Sub grCabañas_SelectionChanged(sender As Object, e As EventArgs) Handles grCabañas.SelectionChanged
        If grCabañas.Row >= 0 Then
            If _ReasignacionReserva = True Then
                Return
            End If
            _prCargarComboPreciosCabaña(grCabañas.GetValue("hbnumi"))
            tbTipo.SelectedIndex = -1
            tbPrecio.Value = 0
            tbTotal.Value = 0
        End If

    End Sub

    Private Sub tbPrecio_ValueChanged(sender As Object, e As EventArgs) Handles tbPrecio.ValueChanged
        _prCalcularTotal()

    End Sub

    Private Sub tbTotal_ValueChanged(sender As Object, e As EventArgs) Handles tbTotal.ValueChanged
        Dim cantNoches As Integer = DateDiff(DateInterval.Day, tbFechaIn.Value, tbFechaOut.Value) + 1
        tbPrecio.Value = tbTotal.Value / cantNoches
    End Sub

    Private Sub MultiColumnCombo1_ValueChanged(sender As Object, e As EventArgs) Handles tbTipo.ValueChanged
        If tbTipo.SelectedIndex >= 0 Then
            tbPrecio.Value = tbTipo.Value
        End If
    End Sub

    Private Sub tbSocioRef_TextChanged(sender As Object, e As EventArgs) Handles tbSocioRef.TextChanged

    End Sub

    Private Sub tbEncargadoRes_TextChanged(sender As Object, e As EventArgs) Handles tbEncargadoRes.TextChanged

    End Sub
End Class