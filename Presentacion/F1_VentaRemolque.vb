Imports Logica.AccesoLogica
Imports Janus.Windows.GridEX
Imports DevComponents.DotNetBar
Imports System.IO
Imports DevComponents.DotNetBar.SuperGrid
Imports Presentacion.F_ClienteNuevoServicio
Imports GMap.NET.MapProviders
Imports GMap.NET
Imports GMap.NET.WindowsForms.Markers
Imports GMap.NET.WindowsForms
Imports GMap.NET.WindowsForms.ToolTips



Public Class F1_VentaRemolque


#Region "Variables Globales"
#Region "MApas"
    Dim _Punto As Integer
    Dim _ListPuntos As List(Of PointLatLng)
    Dim _Overlay As GMapOverlay
    Dim _latitud As Double = 0
    Dim _longitud As Double = 0
#End Region
    Dim RutaGlobal As String = gs_CarpetaRaiz
    Dim TipoTamano As Integer = -1
    Public Cliente As Boolean = False
    Dim TableCliente As Boolean = False
    Public placa As String = ""
    Dim TablaPolitica As DataTable ''en este datatable colocare las politicas que existiera para un servicio
    Dim TablaServiciosP As DataTable ''En este datatable Tempora colocare un historial de servicios de politica de un cliente
    Dim TablaGeneralServicios As DataTable
    ''Aqui acumulare todos los servicios que cumple la politica
    Dim PagoAlDia As Boolean = False
    Public _nameButton As String

#End Region
#Region "METODOS PRIVADOS"
    Private Sub _prIniciarTodo()
        tbTotal.IsInputReadOnly = True

        Me.Text = "S E R V I C I O   V E N T A   R E M O L Q U E"
        _prInicarMapa()
        _PMIniciarTodo()
        _prAsignarPermisos()
        TablaGeneralServicios = L_prObtenerHistorialdeServiciosPolitica(-1, 0)
        GroupPanelBuscador.Style.BackColor = Color.FromArgb(13, 71, 161)
        GroupPanelBuscador.Style.BackColor2 = Color.FromArgb(13, 71, 161)
        GroupPanelBuscador.Style.TextColor = Color.White
        JGrM_Buscador.RootTable.Columns("rcmefec").FormatString = "0.00"
        Dim blah As Bitmap = My.Resources.venta
        Dim ico As Icon = Icon.FromHandle(blah.GetHicon())
        Me.Icon = ico
        JGrM_Buscador.RootTable.HeaderFormatStyle.FontBold = TriState.True
        _prAplicarCondiccionJanus()
        _prCargarStyle()
        _prCargarGridVentaSinPagar()
        _prFiltroVentaSinPagar()



    End Sub
    Public Sub _dibujarUbicacion(_nombre As String, _ci As String)
        If (_latitud <> 0 And _longitud <> 0) Then
            Dim plg As PointLatLng = New PointLatLng(_latitud, _longitud)
            _Overlay.Markers.Clear()
            P_AgregarPunto(plg, _nombre, _ci)
        Else


            _Overlay.Markers.Clear()
            Gmc_Cliente.Position = New PointLatLng(-17.3931784, -66.1738852)
        End If
    End Sub
    Public Sub _prInicarMapa()
        _Punto = 0
        '_ListPuntos = New List(Of PointLatLng)
        _Overlay = New GMapOverlay("points")
        Gmc_Cliente.Overlays.Add(_Overlay)
        P_IniciarMap()
    End Sub
    Private Sub P_AgregarPunto(pointLatLng As PointLatLng, _nombre As String, _ci As String)
        If (Not IsNothing(_Overlay)) Then
            'añadir puntos
            'Dim markersOverlay As New GMapOverlay("markers")
            Dim marker As New GMarkerGoogle(pointLatLng, My.Resources.markerIcono)
            'añadir tooltip
            Dim mode As MarkerTooltipMode = MarkerTooltipMode.OnMouseOver
            marker.ToolTip = New GMapBaloonToolTip(marker)
            marker.ToolTipMode = mode
            Dim ToolTipBackColor As New SolidBrush(Color.Blue)
            marker.ToolTip.Fill = ToolTipBackColor
            marker.ToolTip.Foreground = Brushes.White
            If (Not _nombre.ToString = String.Empty) Then
                marker.ToolTipText = "CLIENTE: " + _nombre & vbNewLine & " CI:" + _ci
            End If
            _Overlay.Markers.Add(marker)
            'mapa.Overlays.Add(markersOverlay)
            Gmc_Cliente.Position = pointLatLng
        End If



    End Sub
    Private Sub P_IniciarMap()
        Gmc_Cliente.DragButton = MouseButtons.Left
        Gmc_Cliente.CanDragMap = True
        Gmc_Cliente.MapProvider = GMapProviders.GoogleMap
        If (_latitud <> 0 And _longitud <> 0) Then

            Gmc_Cliente.Position = New PointLatLng(_latitud, _longitud)
        Else

            _Overlay.Markers.Clear()
            Gmc_Cliente.Position = New PointLatLng(-17.3931784, -66.1738852)
        End If

        Gmc_Cliente.MinZoom = 0
        Gmc_Cliente.MaxZoom = 24
        Gmc_Cliente.Zoom = 15.5
        Gmc_Cliente.AutoScroll = True

        GMapProvider.Language = LanguageType.Spanish
    End Sub
    Public Sub _prAplicarCondiccionJanus()
        Dim fc As GridEXFormatCondition
        fc = New GridEXFormatCondition(JGrM_Buscador.RootTable.Columns("rcest"), ConditionOperator.Equal, 0)
        fc.FormatStyle.BackColor = Color.Red
        JGrM_Buscador.RootTable.FormatConditions.Add(fc)
    End Sub
    Private Sub _prFiltroVentaSinPagar()

        grVentasPendientes.RootTable.ApplyFilter(New Janus.Windows.GridEX.GridEXFilterCondition(grVentasPendientes.RootTable.Columns("rcest"), Janus.Windows.GridEX.ConditionOperator.Equal, 0))
    End Sub
    Private Sub _prCargarGridVentaSinPagar()
       Dim dt As New DataTable
        dt = CType(JGrM_Buscador.DataSource, DataTable)
        SuperTabItem1.Text = "Ventas Sin Pagar"
        ''''janosssssssss''''''
        grVentasPendientes.DataSource = dt
        grVentasPendientes.RetrieveStructure()
        grVentasPendientes.AlternatingColors = True
        grVentasPendientes.RowFormatStyle.Font = New Font("arial", 10)
        With grVentasPendientes.RootTable.Columns("rcnumi")
            .Width = 70
            .TextAlignment = TextAlignment.Center
            .Caption = "ID"
            .Visible = True
        End With
        With grVentasPendientes.RootTable.Columns("rcsuc")
            .Width = 60
            .Visible = False
        End With
        With grVentasPendientes.RootTable.Columns("rctcl1cli")
            .Width = 90
            .Visible = False
        End With
        With grVentasPendientes.RootTable.Columns("raci")
            .Width = 80
            .Caption = "CI"
            .Visible = True
        End With
        With grVentasPendientes.RootTable.Columns("nombre")
            .Width = 250
            .Caption = "CLIENTE"
            .Visible = True
        End With


        With grVentasPendientes.RootTable.Columns("rctcl11veh")
            .Width = 250
            .Caption = "VEHICULOS"
            .Visible = False
        End With

        With grVentasPendientes.RootTable.Columns("rbplac")
            .Width = 250
            .Caption = "PLACA"
            .Visible = False
        End With

        With grVentasPendientes.RootTable.Columns("marcas")
            .Width = 250
            .Caption = "MARCA"
            .Visible = False
        End With

        With grVentasPendientes.RootTable.Columns("modelos")
            .Width = 250
            .Caption = "MODELO"
            .Visible = False
        End With




        With grVentasPendientes.RootTable.Columns("rafot")
            .Width = 90
            .Visible = False
        End With
        With grVentasPendientes.RootTable.Columns("rctven")
            .Width = 90
            .Visible = False
        End With

        With grVentasPendientes.RootTable.Columns("TipoVenta")
            .Width = 90
            .Visible = False
        End With
        With grVentasPendientes.RootTable.Columns("rcfdoc")
            .Width = 120
            .Caption = "FECHA VENTA"
            .Visible = True
        End With
        With grVentasPendientes.RootTable.Columns("rcfvcr")
            .Width = 90
            .Visible = False
        End With
        With grVentasPendientes.RootTable.Columns("rctmon")
            .Width = 90
            .Visible = False
        End With
        With grVentasPendientes.RootTable.Columns("TipoMoneda")
            .Width = 90
            .Visible = False

        End With

        With grVentasPendientes.RootTable.Columns("rcpdes")
            .Width = 90
            .Visible = False

        End With
        With grVentasPendientes.RootTable.Columns("rcmdes")
            .Width = 90
            .Visible = False

        End With
        With grVentasPendientes.RootTable.Columns("rcest")
            .Width = 90
            .Visible = False

        End With
        With grVentasPendientes.RootTable.Columns("Estado")
            .Width = 150
            .Caption = "ESTADO DE VENTA"
            .Visible = True

        End With


        With grVentasPendientes.RootTable.Columns("rctpago")
            .Width = 90
            .Visible = False

        End With
        With grVentasPendientes.RootTable.Columns("TipoPago")
            .Width = 90
            .Visible = False

        End With
        With grVentasPendientes.RootTable.Columns("rcmefec")
            .Width = 90
            .Caption = "MONTO TOTAL"
            .Visible = False

        End With
        With grVentasPendientes.RootTable.Columns("rcmtar")
            .Width = 90
            .Visible = False

        End With
        With grVentasPendientes.RootTable.Columns("rcfact")
            .Width = 90
            .Visible = False

        End With
        With grVentasPendientes.RootTable.Columns("rchact")
            .Width = 90
            .Visible = False

        End With
        With grVentasPendientes.RootTable.Columns("rcuact")
            .Width = 90
            .Visible = False

        End With


        With grVentasPendientes
            .GroupByBoxVisible = False
            'diseño de la grilla
            .VisualStyle = VisualStyle.Office2007
        End With
        grVentasPendientes.RootTable.HeaderFormatStyle.FontBold = TriState.True
    End Sub
    Private Sub _prCargarGridDetalle(_rcnumi As Integer)
        Dim dt As New DataTable
        dt = L_prServicioVentaGruaDetalle(_rcnumi)

        ''''janosssssssss''''''
        grDetalle.DataSource = dt
        grDetalle.RetrieveStructure()
        grDetalle.AlternatingColors = True
        grDetalle.RowFormatStyle.Font = New Font("arial", 10)

        'dar formato a las columnas

        '     rdnumi ,rdtce4pro,b.eddesc  ,rdtp1emp,CONCAT (a.panom ,' ',a.paape )as nombre 
        ',rdpuni ,rdcant,rdpdes ,rdmdes ,rdptot 
        ',rdfpag ,rdppagper ,rdmpagper ,rdest ,rdlin
        With grDetalle.RootTable.Columns("rdlin")
            .Width = 80
            .TextAlignment = TextAlignment.Center
            .Caption = "CODIGO"
            .Visible = True
        End With
        With grDetalle.RootTable.Columns("rdnumi")
            .Width = 60
            .Visible = False
        End With
        With grDetalle.RootTable.Columns("rdtce4pro")
            .Width = 90
            .Visible = False
        End With
        With grDetalle.RootTable.Columns("eddesc")
            .Width = 250
            .Caption = "SERVICIO"
            .Visible = True
        End With
        With grDetalle.RootTable.Columns("rdtp1emp")
            .Width = 90
            .Visible = False
        End With
        With grDetalle.RootTable.Columns("nombre")
            .Width = 250
            .Caption = "PERSONAL"
            .Visible = True
        End With
        With grDetalle.RootTable.Columns("rdpuni")
            .Caption = "PRECIO UNITARIO"
            .Width = 150
            .FormatString = "0.00"
            .TextAlignment = TextAlignment.Center
            .Visible = True
        End With
        With grDetalle.RootTable.Columns("rdcant")
            .Caption = "CANTIDAD"
            .TextAlignment = TextAlignment.Center
            .Width = 100
            .Visible = True
        End With
        With grDetalle.RootTable.Columns("rdpdes")
            .Width = 120
            .Caption = "% DESCUENTO"
            .TextAlignment = TextAlignment.Center
            .FormatString = "0.00"
            .Visible = True

        End With
        With grDetalle.RootTable.Columns("rdmdes")
            .Caption = "MONTO DE DESCUENTO"
            .Width = 200
            .TextAlignment = TextAlignment.Center
            .FormatString = "0.00"
            .Visible = True
        End With
        With grDetalle.RootTable.Columns("rdptot")
            .Width = 200
            .Caption = "PRECIO TOTAL"
            .TextAlignment = TextAlignment.Center
            .FormatString = "0.00"
            .Visible = True
        End With
        With grDetalle.RootTable.Columns("rdfpag")
            .Width = 100
            .Visible = False
        End With

        With grDetalle.RootTable.Columns("rdppagper")
            .Width = 100
            .Visible = False
        End With
        With grDetalle.RootTable.Columns("rdmpagper")
            .Width = 100
            .Visible = False
        End With
        With grDetalle.RootTable.Columns("rdest")
            .Width = 100
            .Visible = False
        End With
        With grDetalle.RootTable.Columns("estado")
            .Width = 100
            .Visible = False
        End With
        With grDetalle
            .GroupByBoxVisible = False
            'diseño de la grilla
            .VisualStyle = VisualStyle.Office2007
        End With
        grDetalle.RootTable.HeaderFormatStyle.FontBold = TriState.True


    End Sub

    Private Sub _prCargarGridAyudaPlacaCLiente()
        GpVentasSinCobrar.Text = "INFORMACION DE AYUDA"
        SuperTabItem1.Text = "Vehiculo de clientes"

        Dim dt As New DataTable
        dt = L_prServicioVehiculoClienteRemolque()


        ''''janosssssssss''''''
        grVentasPendientes.DataSource = dt
        grVentasPendientes.RetrieveStructure()
        grVentasPendientes.AlternatingColors = True
        grVentasPendientes.RowFormatStyle.Font = New Font("arial", 10)

        'dar formato a las columnas
        '        a.lblin,b.lanumi ,a.lbplac,marca.cedesc1 as marca,modelo .cedesc1  as modelo
        ',Concat(b.lanom,' ',b.laapat ,' ',b.laamat  )as nombre

        With grVentasPendientes.RootTable.Columns("rblin")
            .Width = 80
            .TextAlignment = TextAlignment.Center
            .Caption = "CODIGO"
            .Visible = False
        End With
        With grVentasPendientes.RootTable.Columns("ranumi")
            .Width = 60
            .Visible = False
        End With
        With grVentasPendientes.RootTable.Columns("ransoc")
            .Width = 60
            .Visible = False
        End With
        With grVentasPendientes.RootTable.Columns("rbplac")
            .Width = 100
            .Visible = True
            .Caption = "PLACA"
        End With
        With grVentasPendientes.RootTable.Columns("marca")
            .Width = 150
            .Visible = True
            .Caption = "MARCA"
        End With
        With grVentasPendientes.RootTable.Columns("modelo")
            .Width = 150
            .Caption = "MODELO"
            .Visible = True
        End With
        With grVentasPendientes.RootTable.Columns("nombre")
            .Width = 250
            .Visible = True
            .Caption = "CLIENTES"
        End With
        With grVentasPendientes.RootTable.Columns("rafot")
            .Width = 250
            .Visible = False
        End With
        With grVentasPendientes.RootTable.Columns("raci")
            .Width = 250
            .Caption = "CI"
            .Visible = True
        End With
        With grVentasPendientes
            .GroupByBoxVisible = False
            'diseño de la grilla
            .VisualStyle = VisualStyle.Office2007
            .DefaultFilterRowComparison = FilterConditionOperator.Contains
            .FilterMode = FilterMode.Automatic
            .FilterRowUpdateMode = FilterRowUpdateMode.WhenValueChanges
        End With
        grVentasPendientes.RootTable.HeaderFormatStyle.FontBold = TriState.True

    End Sub

    Public Sub _prCargarStyle()
        GpDetalle.Style.BackColor = Color.FromArgb(13, 71, 161)
        GpDetalle.Style.BackColor2 = Color.FromArgb(13, 71, 161)
        GpDetalle.Style.TextColor = Color.White

        GpVentasSinCobrar.Style.BackColor = Color.FromArgb(13, 71, 161)
        GpVentasSinCobrar.Style.BackColor2 = Color.FromArgb(13, 71, 161)
        GpVentasSinCobrar.Style.TextColor = Color.White

        LabelX4.FontBold = True


    End Sub
    Private Sub _prAsignarPermisos()

        Dim dtRolUsu As DataTable = L_prRolDetalleGeneral(gi_userRol, _nameButton)

        Dim show As Boolean = dtRolUsu.Rows(0).Item("ycshow")
        Dim add As Boolean = dtRolUsu.Rows(0).Item("ycadd")
        Dim modif As Boolean = dtRolUsu.Rows(0).Item("ycmod")
        Dim del As Boolean = dtRolUsu.Rows(0).Item("ycdel")

        If add = False Then
            btnNuevo.Visible = False
        End If
        If modif = False Then
            btnModificar.Visible = False
        End If
        If del = False Then
            btnEliminar.Visible = False
        End If

    End Sub
    Public Sub _prVolverAtras()
        MPanelSup.Visible = True
        JGrM_Buscador.Visible = False
        GroupPanelBuscador.Visible = False
        MPanelSup.Dock = DockStyle.Top
        PanelSuperior.Visible = True
        ButtonX2.Visible = False
        ButtonX1.Visible = True
    End Sub
    Public Function _fnActionNuevo() As Boolean
        Return tbCodigo.Text = String.Empty And Estado.IsReadOnly = False
    End Function
    Private Sub _fnValidarNuevoCliente()
        Dim length As Integer = CType(grDetalle.DataSource, DataTable).Rows.Count
        If (length > 0 And tbCodigo.Text = String.Empty) Then ''Aqui se ejecuta si estamos hacienda una nueva venta
            CType(grDetalle.DataSource, DataTable).Rows.Clear()
            _prAddFilaDetalle()
        Else
            Dim da As DataTable = CType(grDetalle.DataSource, DataTable)

            If (length > 0 And Not tbCodigo.Text = String.Empty) Then ''Aqui se ejecuta si estamos modificando una venta para cambiar el estado de las ventas ya guardadas
                Dim i As Integer = 0
                While (i <= length - 1)
                    Dim estado As Integer = CType(grDetalle.DataSource, DataTable).Rows(i).Item("estado")
                    If (estado = 1 Or estado = 2) Then
                        CType(grDetalle.DataSource, DataTable).Rows(i).Item("estado") = -1

                    Else
                        If (estado = 0) Then
                            CType(grDetalle.DataSource, DataTable).Rows(i).Item("estado") = -2
                        End If


                    End If
                    i = i + 1


                End While

                tbTotal.Text = 0


                grDetalle.RootTable.ApplyFilter(New Janus.Windows.GridEX.GridEXFilterCondition(grDetalle.RootTable.Columns("estado"), Janus.Windows.GridEX.ConditionOperator.GreaterThanOrEqualTo, 0))
                _prAddFilaDetalle()

            End If
        End If
    End Sub
    Public Function _fnVisualizarRegistros() As Boolean
        Return btnNuevo.Enabled = True
    End Function

    Public Function _fnObtenerLinDetalle() As Integer
        Dim length As Integer = CType(grDetalle.DataSource, DataTable).Rows.Count
        Dim lin As Integer
        If (length > 0) Then
            lin = CType(grDetalle.DataSource, DataTable).Rows(length - 1).Item("rdlin")
            Return lin

        Else
            Return 0
        End If

    End Function

    Public Sub _prAddFilaDetalle()
        '     lclin ,lcnumi ,lctce4pro,b.eddesc  ,lctp1emp,CONCAT (a.panom ,' ',a.paape )as nombre 
        ',lcpuni ,lccant,lcpdes ,lcmdes ,lcptot 
        ',lcfpag ,lcppagper ,lcmpagper ,lcest,1 as estado

        Dim lin As Integer = _fnObtenerLinDetalle() + 1
        _prCalcularPrecioTotal()
        CType(grDetalle.DataSource, DataTable).Rows.Add({lin, 0, 0, "", 0, "", 0, 0, 0, 0, 0, Now.Date, 0, 0, 1, 0})
    End Sub

    Public Function _fnValidarColumn(pos As Integer, row As Integer, _MostrarMensaje As Boolean) As Boolean
        If (CType(grDetalle.DataSource, DataTable).Rows(pos).Item("eddesc") = String.Empty) Then


            If (_MostrarMensaje = True) Then
                grDetalle.Row = row
                grDetalle.Col = 2
                grDetalle.FocusCellFormatStyle.BackColor = Color.Red
                ToastNotification.Show(Me, "           Seleccione un Servicio !!             ", My.Resources.WARNING, 3000, eToastGlowColor.Red, eToastPosition.TopCenter)


            End If

            Return False
        End If

        If (CType(grDetalle.DataSource, DataTable).Rows(pos).Item("nombre") = String.Empty) Then

            If (_MostrarMensaje = True) Then
                grDetalle.Row = row
                grDetalle.Col = 4
                grDetalle.FocusCellFormatStyle.BackColor = Color.Red
                ToastNotification.Show(Me, "             Seleccione un Personal !!               ", My.Resources.WARNING, 3000, eToastGlowColor.Red, eToastPosition.TopCenter)
            End If

            Return False
        End If
        Return True
    End Function

    Public Sub _prCalcularPrecioTotal()
        tbTotal.Text = grDetalle.GetTotal(grDetalle.RootTable.Columns("rdptot"), AggregateFunction.Sum)
    End Sub
    Public Sub _prBuscarDescuentoEliminadoNumiServ(ByRef _pos As Integer, _numiServ As Integer)
        Dim length As Integer = CType(grDetalle.DataSource, DataTable).Rows.Count
        For i As Integer = 0 To length - 1 Step 1
            Dim estado As Integer = CType(grDetalle.DataSource, DataTable).Rows(i).Item("estado")
            Dim numiserv As Integer = CType(grDetalle.DataSource, DataTable).Rows(i).Item("rdtce4pro")
            If (estado = -1 And numiserv = _numiServ) Then
                _pos = i
                Return

            End If

        Next

    End Sub

    Public Function _prBuscarExisteNumiServ(_numiServ As Integer) As Boolean
        Dim length As Integer = CType(grDetalle.DataSource, DataTable).Rows.Count
        For i As Integer = 0 To length - 1 Step 1
            Dim estado As Integer = CType(grDetalle.DataSource, DataTable).Rows(i).Item("estado")
            Dim numiserv As Integer = CType(grDetalle.DataSource, DataTable).Rows(i).Item("rdtce4pro")
            If (estado <> -1 And numiserv = _numiServ) Then
                Return True

            End If

        Next
        Return False
    End Function

    Public Sub _prObtenerPosicionDetalle(ByRef pos As Integer, ByVal Lin As Integer)
        Dim length As Integer = CType(grDetalle.DataSource, DataTable).Rows.Count
        pos = -1
        For i As Integer = 0 To length Step 1
            Dim numi As Integer = CType(grDetalle.DataSource, DataTable).Rows(i).Item("rdlin")
            If (numi = Lin) Then
                pos = i
                Return

            End If

        Next
    End Sub

    Private Sub P_PonerTotal(rowIndex As Integer)
        If (rowIndex < grDetalle.RowCount) Then
            grDetalle.Row = rowIndex
            Dim lin As Integer = grDetalle.GetValue("rdlin")
            Dim pos As Integer = -1
            _prObtenerPosicionDetalle(pos, lin)
            Dim cant As Double = grDetalle.GetValue("rdcant")

            Dim uni As Double = grDetalle.GetValue("rdpuni")

            If (pos >= 0) Then

                Dim porcdesc As Double = grDetalle.GetValue("rdpdes")
                Dim TotalUnitario As Double = cant * uni
                Dim montodesc As Double = (TotalUnitario * (porcdesc / 100))
                'grDetalle.SetValue("lcmdes", montodesc)
                grDetalle.GetRow(rowIndex).Cells("rdmdes").Value = montodesc
                CType(grDetalle.DataSource, DataTable).Rows(pos).Item("rdmdes") = montodesc

                grDetalle.SetValue("rdptot", (cant * uni) - montodesc)
                CType(grDetalle.DataSource, DataTable).Rows(pos).Item("rdptot") = ((cant * uni) - montodesc)
                Dim estado As Integer = CType(grDetalle.DataSource, DataTable).Rows(pos).Item("estado")
                If (estado = 1) Then
                    CType(grDetalle.DataSource, DataTable).Rows(pos).Item("estado") = 2
                End If
            End If
            _prCalcularPrecioTotal()
        End If



    End Sub
    Public Sub _prCambiarEstadoItemEliminar()
        For i As Integer = 0 To CType(grDetalle.DataSource, DataTable).Rows.Count - 1 Step 1
            Dim estado As Integer = CType(grDetalle.DataSource, DataTable).Rows(i).Item("estado")
            If (estado = 1 Or estado = 2) Then
                CType(grDetalle.DataSource, DataTable).Rows(i).Item("estado") = -1
            Else
                If (estado = 0) Then
                    CType(grDetalle.DataSource, DataTable).Rows(i).Item("estado") = -2

                End If
            End If
        Next
        grDetalle.RootTable.ApplyFilter(New Janus.Windows.GridEX.GridEXFilterCondition(grDetalle.RootTable.Columns("estado"), Janus.Windows.GridEX.ConditionOperator.GreaterThanOrEqualTo, 0))
    End Sub

    Private Sub _prImprimir(_numiVenta As Integer)
        Dim objrep As New R_ImprimirVentaRemolque
        Dim _dt As New DataTable
        _dt = L_prReporteServicioVentaClienteRemolque(_numiVenta)

        'imprimir
        If PrintDialog1.ShowDialog = DialogResult.OK Then
            objrep.SetDataSource(_dt)


            objrep.PrintOptions.PrinterName = PrintDialog1.PrinterSettings.PrinterName
            objrep.PrintToPrinter(2, False, 1, 10)
        End If
    End Sub

#End Region

#Region "METODOS SOBREESCRITOS"



    Public Overrides Sub _PMOHabilitar()
        Estado.IsReadOnly = False
        _prAplicarCondiccionJanus()
        JGrM_Buscador.RootTable.Columns("rcmefec").FormatString = "0.00"
        ButtonX1.Visible = False
        Eliminarms.Visible = True
        tbVehiculo.ReadOnly = False
        btnAnadir.Visible = True
        _prCargarGridAyudaPlacaCLiente()
        tbobs.ReadOnly = False

    End Sub
    Public Overrides Sub _PMOInhabilitar()
        FechaVenta.Enabled = False
        tbClienteSocio.IsReadOnly = True
        tbCliente.ReadOnly = True
        tbVehiculo.ReadOnly = True
        Estado.IsReadOnly = True
        tbCodigo.Enabled = False
        _prAplicarCondiccionJanus()
        JGrM_Buscador.RootTable.Columns("rcmefec").FormatString = "0.00"
        ButtonX1.Visible = True
        Eliminarms.Visible = False
        btnAnadir.Visible = False
        _prCargarGridAyudaPlacaCLiente()
        _prCargarGridVentaSinPagar()
        _prFiltroVentaSinPagar()
        tbFechaPago.Visible = False
        lbFechaPago.Visible = False
        lbUltimaPago.Visible = False
        GpVentasSinCobrar.Text = "V E N T A S    S I N    C O B R A R"
        TipoTamano = -1
        TablaGeneralServicios = L_prObtenerHistorialdeServiciosPolitica(-1, 0)
        PagoAlDia = False
        tbobs.ReadOnly = True
    End Sub
    Public Overrides Sub _PMOHabilitarFocus()
        With MHighlighterFocus
            .SetHighlightOnFocus(tbCliente, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
            .SetHighlightOnFocus(FechaVenta, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
             .SetHighlightOnFocus(Estado, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
            .SetHighlightOnFocus(tbVehiculo, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
           .SetHighlightOnFocus(tbFechaPago, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
        End With
    End Sub
    Public Overrides Sub _PMOLimpiar()
        tbCliente.Text = ""
        tbnumiCliente.Text = 0
        tbnumiVehiculo.Text = 0
        tbVehiculo.Text = ""
        tbCodigo.Text = ""
        FechaVenta.Text = DateTime.Now.ToString("dd/MM/yyyy")
        TipoTamano = -1
        Estado.Value = False
        Dim img As New Bitmap(New Bitmap(My.Resources.imageDefault), 180, 157)
        UsImg.pbImage.Image = img
        _prCargarGridDetalle(-1)
        _prAddFilaDetalle()
        tbTotal.Text = 0
        ButtonX1.Visible = False
        ButtonX2.Visible = False
        _prCargarGridAyudaPlacaCLiente()
        tbFechaPago.Text = ""
        lbFechaPago.Visible = False
        tbFechaPago.Visible = False
        tbClienteSocio.Value = True
        SuperTabControl1.SelectedTabIndex = 0
        TipoTamano = -1
        TablaGeneralServicios = L_prObtenerHistorialdeServiciosPolitica(-1, 0)
        PagoAlDia = False
        tbVehiculo.Focus()
        _latitud = 0
        _longitud = 0
        _Overlay.Markers.Clear()
        tbobs.Text = ""
    End Sub
    Public Overrides Sub _PMOLimpiarErrores()

        MEP.Clear()
        tbCliente.BackColor = Color.White
        tbVehiculo.BackColor = Color.White
    End Sub
    Public Overrides Function _PMOValidarCampos() As Boolean
        Dim _ok As Boolean = True
        MEP.Clear()

        If tbCliente.Text = String.Empty Then
            tbCliente.BackColor = Color.Red
            MEP.SetError(tbCliente, "Seleccione un Cliente con Ctrl+Enter!".ToUpper)
            _ok = False
        Else
            tbCliente.BackColor = Color.White
            MEP.SetError(tbCliente, "")
        End If
        If tbVehiculo.Text = String.Empty Then
            tbVehiculo.BackColor = Color.Red
            MEP.SetError(tbVehiculo, "Seleccione un Vehiculo con Ctrl+Enter!".ToUpper)
            _ok = False
        Else
            tbVehiculo.BackColor = Color.White
            MEP.SetError(tbVehiculo, "")
        End If
      
        If (_fnValidarDatosDetalle() = False) Then
            _ok = False
        End If
        MHighlighterFocus.UpdateHighlights()
        Return _ok
    End Function
    Public Overrides Function _PMOGetListEstructuraBuscador() As List(Of Modelos.Celda)
        Dim listEstCeldas As New List(Of Modelos.Celda)

        'rctcl11veh,c.lbplac ,marca .cedesc1 as marcas,modelo .cedesc1 as modelos
        listEstCeldas.Add(New Modelos.Celda("rcnumi", True, "CODIGO VENTA", 120))
        listEstCeldas.Add(New Modelos.Celda("rcsuc", False))
        listEstCeldas.Add(New Modelos.Celda("rctcl1cli", False))
        listEstCeldas.Add(New Modelos.Celda("raci", True, "CI", 130))
        listEstCeldas.Add(New Modelos.Celda("nombre", True, "NOMBRE", 350))

        listEstCeldas.Add(New Modelos.Celda("rctcl11veh", False))
        listEstCeldas.Add(New Modelos.Celda("rbplac", True, "PLACA", 100))
        listEstCeldas.Add(New Modelos.Celda("marcas", True, "MARCA", 100))
        listEstCeldas.Add(New Modelos.Celda("modelos", True, "MODELO", 100))

        listEstCeldas.Add(New Modelos.Celda("rafot", False))
        listEstCeldas.Add(New Modelos.Celda("rctven", False))
        listEstCeldas.Add(New Modelos.Celda("TipoVenta", False, "TIPO DE VENTA", 150))
        listEstCeldas.Add(New Modelos.Celda("rcfdoc", True, "FECHA VENTA", 150))
        listEstCeldas.Add(New Modelos.Celda("rcfvcr", False))
        listEstCeldas.Add(New Modelos.Celda("rctmon", False))
        listEstCeldas.Add(New Modelos.Celda("TipoMoneda", False, "TIPO DE MONEDA", 150))
        listEstCeldas.Add(New Modelos.Celda("rcpdes", False))
        listEstCeldas.Add(New Modelos.Celda("rcmdes", False))
        listEstCeldas.Add(New Modelos.Celda("rcest", False))
        listEstCeldas.Add(New Modelos.Celda("Estado", True, "ESTADO DE VENTA", 150))
        listEstCeldas.Add(New Modelos.Celda("rctpago", False))
        listEstCeldas.Add(New Modelos.Celda("TipoPago", False, "TIPO DE PAGO", 150))
        listEstCeldas.Add(New Modelos.Celda("rcmefec", True, "MONTO TOTAL", 150))
        listEstCeldas.Add(New Modelos.Celda("rcmtar", False))
        listEstCeldas.Add(New Modelos.Celda("rclat", False))
        listEstCeldas.Add(New Modelos.Celda("rclong", False))
        listEstCeldas.Add(New Modelos.Celda("rcobs", False))
        listEstCeldas.Add(New Modelos.Celda("rcfact", False))
        listEstCeldas.Add(New Modelos.Celda("rchact", False))
        listEstCeldas.Add(New Modelos.Celda("rcuact", False))

        Return listEstCeldas


    End Function
    Public Overrides Function _PMOGetTablaBuscador() As DataTable
        Dim dtBuscador As DataTable = L_prServicioVentaGruaGeneral()
        Return dtBuscador
    End Function

    Public Overrides Sub _PMOMostrarRegistro(_N As Integer)
        JGrM_Buscador.Row = _MPos

        With JGrM_Buscador
            tbCliente.Text = .GetValue("nombre").ToString
            tbnumiCliente.Text = .GetValue("rctcl1cli")
            tbCodigo.Text = .GetValue("rcnumi")
            FechaVenta.Value = .GetValue("rcfdoc")
            _latitud = .GetValue("rclat")
            _longitud = .GetValue("rclong")
            tbobs.Text = .GetValue("rcobs").ToString
            Dim est = .GetValue("rcest")
            If (est = 1) Then
                Estado.Value = True
            Else
                Estado.Value = False

            End If

            tbnumiVehiculo.Text = .GetValue("rctcl11veh")

            tbVehiculo.Text = .GetValue("rbplac").ToString

        End With
        Dim name As String = JGrM_Buscador.GetValue("rafot")
        If name.Equals("Default.jpg") Or Not File.Exists(RutaGlobal + "\Imagenes\Imagenes ClienteR" + name) Then
            Dim im As New Bitmap(My.Resources.imageDefault)
            UsImg.pbImage.Image = im
        Else


            If (File.Exists(RutaGlobal + "\Imagenes\Imagenes ClienteR" + name)) Then
                Dim Bin As New MemoryStream
                Dim im As New Bitmap(New Bitmap(RutaGlobal + "\Imagenes\Imagenes ClienteR" + name), 180, 157)
                im.Save(Bin, System.Drawing.Imaging.ImageFormat.Jpeg)
                UsImg.pbImage.Image = Image.FromStream(Bin)
                Bin.Dispose()

            End If


        End If
        _prCargarGridDetalle(tbCodigo.Text)

        _prCalcularPrecioTotal()
        
        _prVerificarSocio()
        _dibujarUbicacion(JGrM_Buscador.GetValue("nombre").ToString, JGrM_Buscador.GetValue("raci").ToString)
        LblPaginacion.Text = Str(_MPos + 1) + "/" + JGrM_Buscador.RowCount.ToString

    End Sub
    Public Sub _prVerificarSocio()
        Dim nsoc As Integer = JGrM_Buscador.GetValue("ransoc")
        If (nsoc > 0) Then
            tbClienteSocio.Value = False
        Else
            tbClienteSocio.Value = True

        End If
    End Sub

    Public Function _fnValidarDatosDetalle()
        Dim row As Integer = CType(grDetalle.DataSource, DataTable).Rows.Count - 1
        If (grDetalle.RowCount <= 0) Then
            ToastNotification.Show(Me, "           Inserte un Servicio Antes de Guardar  !!             ", My.Resources.WARNING, 8000, eToastGlowColor.Red, eToastPosition.TopCenter)
            Return False
            Return False
        End If
        If (CType(grDetalle.DataSource, DataTable).Rows(row).Item("eddesc") = String.Empty) Then
            grDetalle.Select()
            grDetalle.Row = grDetalle.RowCount - 1
            grDetalle.Col = 2
            grDetalle.FocusCellFormatStyle.BackColor = Color.Red

            ToastNotification.Show(Me, "           Seleccione un Servicio Antes de guardar los datos O Elimine la fila !!             ", My.Resources.WARNING, 8000, eToastGlowColor.Red, eToastPosition.TopCenter)
            Return False
        End If

        If (CType(grDetalle.DataSource, DataTable).Rows(row).Item("nombre") = String.Empty) Then
            grDetalle.Select()
            grDetalle.Row = grDetalle.RowCount - 1
            grDetalle.Col = 4
            grDetalle.FocusCellFormatStyle.BackColor = Color.Red
            ToastNotification.Show(Me, "             Seleccione un Personal !!               ", My.Resources.WARNING, 8000, eToastGlowColor.Red, eToastPosition.TopCenter)
            Return False
        End If
        Return True
    End Function
    Public Sub _prMesajeImprimi(Codigo As Integer)
        Dim info As New TaskDialogInfo("advertencia".ToUpper, eTaskDialogIcon.Delete, "¿desea continuar?".ToUpper, "DESEA IMPRIMIR REPORTE DE ESTA VENTA REGISTRADA".ToUpper, eTaskDialogButton.Yes Or eTaskDialogButton.No, eTaskDialogBackgroundColor.Blue)
        Dim result As eTaskDialogResult = TaskDialog.Show(info)
        If result = eTaskDialogResult.Yes Then
            _prImprimir(Codigo)
        Else



        End If
    End Sub
    Public Overrides Function _PMOGrabarRegistro() As Boolean

        Dim res As Boolean = True
        'res = L_prServicioVentaGruaGrabar(tbCodigo.Text, tbnumiCliente.Text, tbnumiVehiculo.Text, FechaVenta.Value.ToString("yyyy/MM/dd"), IIf(Estado.Value = True, 1, 0), tbTotal.Value, _latitud, _longitud, tbobs.Text, CType(grDetalle.DataSource, DataTable))
        If res Then

            TipoTamano = -1
            TablaGeneralServicios = L_prObtenerHistorialdeServiciosPolitica(-1, 0)

            _prCargarGridVentaSinPagar()

            ToastNotification.Show(Me, "Codigo de Servicio Venta ".ToUpper + tbCodigo.Text + " Grabado con Exito.".ToUpper, My.Resources.GRABACION_EXITOSA, 5000, eToastGlowColor.Green, eToastPosition.TopCenter)
            _prMesajeImprimi(tbCodigo.Text)
        End If
        Return res
    End Function
    Public Overrides Function _PMOModificarRegistro() As Boolean
        Dim res As Boolean = True
        'res = L_prServicioVentaGruaModificar(tbCodigo.Text, tbnumiCliente.Text, tbnumiVehiculo.Text, FechaVenta.Value.ToString("yyyy/MM/dd"), IIf(Estado.Value = True, 1, 0), tbTotal.Value, _latitud, _longitud, tbobs.Text, CType(grDetalle.DataSource, DataTable))
        If res Then
            _prCargarGridVentaSinPagar()
            TipoTamano = -1
            TablaGeneralServicios = L_prObtenerHistorialdeServiciosPolitica(-1, 0)
            ToastNotification.Show(Me, "Codigo de Servicio Venta ".ToUpper + tbCodigo.Text + " modificado con Exito.".ToUpper, My.Resources.GRABACION_EXITOSA, 5000, eToastGlowColor.Green, eToastPosition.TopCenter)
        End If

        Return res
    End Function


    Public Overrides Sub _PMOEliminarRegistro()
        Dim info As New TaskDialogInfo("¿esta seguro de eliminar el registro?".ToUpper, eTaskDialogIcon.Delete, "advertencia".ToUpper, "mensaje principal".ToUpper, eTaskDialogButton.Yes Or eTaskDialogButton.Cancel, eTaskDialogBackgroundColor.Blue)
        Dim result As eTaskDialogResult = TaskDialog.Show(info)
        If result = eTaskDialogResult.Yes Then
            Dim mensajeError As String = ""
            Dim res As Boolean = L_prServicioVentaGruaBorrar(tbCodigo.Text, mensajeError)
            If res Then

                TipoTamano = -1
                ToastNotification.Show(Me, "Codigo de Servicio Venta ".ToUpper + tbCodigo.Text + " eliminado con Exito.".ToUpper, My.Resources.GRABACION_EXITOSA, 5000, eToastGlowColor.Green, eToastPosition.TopCenter)
                _PMFiltrar()
                _prCargarGridVentaSinPagar()
                _prFiltroVentaSinPagar()
                _prAplicarCondiccionJanus()
            Else
                ToastNotification.Show(Me, mensajeError, My.Resources.WARNING, 8000, eToastGlowColor.Red, eToastPosition.TopCenter)
            End If
        End If
    End Sub
#End Region

#Region "Eventos Formulario"


    Private Sub F1_ServicioVenta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _prIniciarTodo()

    End Sub

    Private Sub ButtonX1_Click(sender As Object, e As EventArgs) Handles ButtonX1.Click

        JGrM_Buscador.RemoveFilters()

        MPanelSup.Visible = False
        JGrM_Buscador.Visible = True
        GroupPanelBuscador.Visible = True

        JGrM_Buscador.Enabled = True
        GroupPanelBuscador.Enabled = True

        PanelSuperior.Visible = False
        JGrM_Buscador.Focus()
        JGrM_Buscador.MoveTo(JGrM_Buscador.FilterRow)
        JGrM_Buscador.Col = 4

        ButtonX2.Visible = True
        ButtonX1.Visible = False
    End Sub

    Private Sub ButtonX2_Click(sender As Object, e As EventArgs) Handles ButtonX2.Click
        If (JGrM_Buscador.Row < 0) Then
            If (JGrM_Buscador.RowCount > 0) Then
                JGrM_Buscador.Row = 0

            End If


        End If
        _prVolverAtras()

    End Sub

    Private Sub tbCliente_KeyDown(sender As Object, e As KeyEventArgs) Handles tbCliente.KeyDown
        If (Not _fnVisualizarRegistros() And Estado.IsReadOnly = False) Then


            If e.KeyData = Keys.Control + Keys.Enter Then
                Dim codigo As Integer = -1
                If (Not tbnumiCliente.Text.ToString = String.Empty) Then
                    codigo = tbnumiCliente.Text
                End If
                'grabar horario
                Dim frmAyuda As Modelos.ModeloAyuda

                Dim dt As DataTable
                ''Aqui puse estatico la libreria de CLiente Lavadero 14 , 1
                dt = L_prServicioVentaAYUdaCLienteRemolque()

                Dim listEstCeldas As New List(Of Modelos.Celda)
                listEstCeldas.Add(New Modelos.Celda("ranumi", True, "ID", 50))
                listEstCeldas.Add(New Modelos.Celda("ratipo", False))
                listEstCeldas.Add(New Modelos.Celda("cedesc1", True, "TIPO", 120))
                listEstCeldas.Add(New Modelos.Celda("ransoc", True, "NUMERO DE SOCIO", 150))
                listEstCeldas.Add(New Modelos.Celda("rafing", False, "FECHA DE INGRESO", 200))
                listEstCeldas.Add(New Modelos.Celda("rafnac", False, "FECHA DE NACIMIENTO", 170))
                listEstCeldas.Add(New Modelos.Celda("ranom", True, "NOMBRES", 150))
                listEstCeldas.Add(New Modelos.Celda("raapat", True, "APELLIDO PATERNO", 150))
                listEstCeldas.Add(New Modelos.Celda("raamat", True, "APELLIDO MATERNO", 150))

                listEstCeldas.Add(New Modelos.Celda("radir", False, "DIRECCION", 150))
                listEstCeldas.Add(New Modelos.Celda("raemail", False, "CORREO ELECTRONICO", 150))
                listEstCeldas.Add(New Modelos.Celda("raci", True, "CI", 90))
                listEstCeldas.Add(New Modelos.Celda("rafot", False))
                listEstCeldas.Add(New Modelos.Celda("img", False, "IMAGEN", 150))

                listEstCeldas.Add(New Modelos.Celda("raobs", False, "OBSERVACION", 100))
                listEstCeldas.Add(New Modelos.Celda("raest", False))
                listEstCeldas.Add(New Modelos.Celda("estado", False, "ESTADO", 80))
                listEstCeldas.Add(New Modelos.Celda("ratelf1", False, "TELEFONO 1", 100))
                listEstCeldas.Add(New Modelos.Celda("ratelf2", False, "TELEFONO 2", 100))

                listEstCeldas.Add(New Modelos.Celda("rafact", False))
                listEstCeldas.Add(New Modelos.Celda("rahact", False))
                listEstCeldas.Add(New Modelos.Celda("rauact", False))

                frmAyuda = New Modelos.ModeloAyuda(50, 250, dt, "SELECCIONE CLIENTE DEL LAVADERO".ToUpper, listEstCeldas)
                frmAyuda.ShowDialog()


                If frmAyuda.seleccionado = True Then



                    Dim numi As String = frmAyuda.filaSelect.Cells("ranumi").Value
                    If (codigo >= 0) Then
                        If (codigo <> numi) Then
                            _fnValidarNuevoCliente()
                            tbVehiculo.Text = ""
                            tbnumiVehiculo.Text = 0
                        End If
                    End If

                    Dim nombre As String = frmAyuda.filaSelect.Cells("ranom").Value + " " + frmAyuda.filaSelect.Cells("raapat").Value + " " + frmAyuda.filaSelect.Cells("raamat").Value
                    Dim name As String = frmAyuda.filaSelect.Cells("rafot").Value.ToString
                    If name.Equals("Default.jpg") Or Not File.Exists(RutaGlobal + "\Imagenes\Imagenes ClienteR" + name) Then
                        Dim im As New Bitmap(My.Resources.imageDefault)
                        UsImg.pbImage.Image = im
                    Else


                        If (File.Exists(RutaGlobal + "\Imagenes\Imagenes ClienteR" + name)) Then
                            Dim Bin As New MemoryStream
                            Dim im As New Bitmap(New Bitmap(RutaGlobal + "\Imagenes\Imagenes ClienteR" + name), 180, 157)
                            im.Save(Bin, System.Drawing.Imaging.ImageFormat.Jpeg)
                            UsImg.pbImage.Image = Image.FromStream(Bin)
                            Bin.Dispose()

                        End If

                    End If
                    tbCliente.Text = nombre
                    tbnumiCliente.Text = numi
                    tbVehiculo.Focus()

                End If
            End If
        End If
    End Sub

    Private Sub grDetalle_Enter(sender As Object, e As EventArgs) Handles grDetalle.Enter
       
        If (tbnumiVehiculo.Text = 0) Then
            tbVehiculo.Focus()
            ToastNotification.Show(Me, "           Antes De Continuar Por favor Seleccione un Vehiculo !!             ", My.Resources.WARNING, 4000, eToastGlowColor.Red, eToastPosition.TopCenter)
            Return

        End If
        grDetalle.Select()
        grDetalle.Col = 4
        grDetalle.Row = 0


    End Sub
    Public Sub _VerificarPagoAlDia(_nsoc As Integer)
        If (PagoAlDia = False And _nsoc > 0) Then
            MsgBox("El Socio Esta Sin Pagos Al Dia Por Lo Tanto El Sistema No Aplicara Ningun Tipo De Descuento y Solo Hara Su Servicios Como Cliente!", MsgBoxStyle.Exclamation, "Error")
        End If
    End Sub
    Private Sub grDetalle_KeyDown(sender As Object, e As KeyEventArgs) Handles grDetalle.KeyDown

        If (e.KeyData = Keys.Tab And grDetalle.Row >= 0 And (Not _fnVisualizarRegistros())) Then
            ''TbdPorcentajeDescuento.Select()
            Exit Sub
        End If

        If (e.KeyData = Keys.Enter) Then
            Dim f, c As Integer
            c = grDetalle.Col
            f = grDetalle.Row

            If (grDetalle.Col = grDetalle.RootTable.Columns("rdcant").Index) Then
                ''P_AddFilaDetalle()
                'Pasar el foco a la siguente fila
                Dim tam As Integer = grDetalle.RowCount - 1
                Dim lin As Integer = grDetalle.GetValue("rdlin")
                Dim pos As Integer = -1
                _prObtenerPosicionDetalle(pos, lin)
                Dim bol As Boolean = _fnValidarColumn(pos, grDetalle.Row, True)
                If (bol = True) Then
                    If (tam <= f) Then
                        _prAddFilaDetalle()

                    End If

                    grDetalle.Row = f + 1
                    grDetalle.Col = 2
                End If

            End If
salirIf:
        End If

     If (e.KeyData = Keys.Control + Keys.Enter And grDetalle.Row >= 0 And btnGrabar.Enabled = True) Then
            Dim indexfil As Integer = grDetalle.Row
            Dim indexcol As Integer = grDetalle.Col

            If (grDetalle.Col = grDetalle.RootTable.Columns("eddesc").Index) Then 'Esta en la cerca de Servicio
                Dim frmAyuda As Modelos.ModeloAyuda
                Dim dt As DataTable = L_prServicioVentaGruaAyudaServicio(gi_LibServRem)
                If (dt.Rows.Count <= 0) Then
                    MsgBox("No Existe Ningun Servicio Registrado Para Efectuar La Venta Registre Servicios Por Favor", MsgBoxStyle.Exclamation, "Error")
                    Return

                End If
                Dim listEstCeldas As New List(Of Modelos.Celda)


                ' ednumi ,edcod ,eddesc, edprec ,edtipo ,edest,edfact ,edhact ,eduact 
                listEstCeldas.Add(New Modelos.Celda("ednumi", True, "ID", 50))
                listEstCeldas.Add(New Modelos.Celda("edcod", False))
                listEstCeldas.Add(New Modelos.Celda("eddesc", True, "SERVICIOS", 200))
                listEstCeldas.Add(New Modelos.Celda("edprec", True, "TIPO", 120))
                listEstCeldas.Add(New Modelos.Celda("edtipo", False))
                listEstCeldas.Add(New Modelos.Celda("edest", False))
                listEstCeldas.Add(New Modelos.Celda("edfact", False))
                listEstCeldas.Add(New Modelos.Celda("edhact", False))
                listEstCeldas.Add(New Modelos.Celda("eduact", False))


                frmAyuda = New Modelos.ModeloAyuda(50, 250, dt, "SELECCIONE SERVICIO DEL REMOLQUE".ToUpper, listEstCeldas)
                frmAyuda.ShowDialog()



                If frmAyuda.seleccionado = True Then
                    Dim idServ As String = frmAyuda.filaSelect.Cells("ednumi").Value
                    Dim descr As String = frmAyuda.filaSelect.Cells("eddesc").Value
                    Dim precio As Double = frmAyuda.filaSelect.Cells("edprec").Value

                    Dim lin As Integer = grDetalle.GetValue("rdlin")
                    Dim pos As Integer = -1
                    If (Not _prBuscarExisteNumiServ(idServ)) Then

                        _prObtenerPosicionDetalle(pos, lin)
                        If (pos >= 0) Then
                            CType(grDetalle.DataSource, DataTable).Rows(pos).Item("rdtce4pro") = idServ
                            CType(grDetalle.DataSource, DataTable).Rows(pos).Item("eddesc") = descr
                            CType(grDetalle.DataSource, DataTable).Rows(pos).Item("rdpuni") = precio
                            CType(grDetalle.DataSource, DataTable).Rows(pos).Item("rdcant") = 1

                            Dim posicion As Integer = -1
                            Dim da As DataTable = L_prServicioVentaGruaPoliticaDescuento(tbnumiCliente.Text, idServ)
                            _prBuscarDescuentoEliminadoNumiServ(posicion, idServ) ''LLamo a este procedimiento si existe un detalle eliminado con porcentaje de descuento para añadirle el mismo porcentaje al nuevo servicio seleccionado
                            Dim estado As Integer = CType(grDetalle.DataSource, DataTable).Rows(pos).Item("estado")
                            If (estado = 1) Then
                                CType(grDetalle.DataSource, DataTable).Rows(pos).Item("estado") = 2


                            End If

                            If (da.Rows.Count > 0 And posicion = -1) Then
                                Dim porcentajeDescuento As Double = da.Rows(0).Item("porcentaje")
                                Dim MontoDescuento As Double = (precio * (porcentajeDescuento / 100))
                                CType(grDetalle.DataSource, DataTable).Rows(pos).Item("rdpdes") = porcentajeDescuento
                                CType(grDetalle.DataSource, DataTable).Rows(pos).Item("rdmdes") = MontoDescuento
                                CType(grDetalle.DataSource, DataTable).Rows(pos).Item("rdptot") = precio - MontoDescuento


                            Else

                                If (posicion >= 0) Then
                                    Dim porcentajeDescuento As Double = CType(grDetalle.DataSource, DataTable).Rows(posicion).Item("rdpdes")
                                    Dim MontoDescuento As Double = (precio * (porcentajeDescuento / 100))
                                    CType(grDetalle.DataSource, DataTable).Rows(pos).Item("rdpdes") = porcentajeDescuento
                                    CType(grDetalle.DataSource, DataTable).Rows(pos).Item("rdmdes") = MontoDescuento
                                    CType(grDetalle.DataSource, DataTable).Rows(pos).Item("rdptot") = precio - MontoDescuento

                                Else
                                    CType(grDetalle.DataSource, DataTable).Rows(pos).Item("rdptot") = precio

                                End If
                            End If
                        End If

                        If (grDetalle.FocusCellFormatStyle.BackColor = Color.Red) Then
                            grDetalle.FocusCellFormatStyle.BackColor = DefaultBackColor
                        End If
                        'Poner el focus en la siguente casilla
                        grDetalle.Row = indexfil
                        grDetalle.Col = indexcol + 2

                        _prCalcularPrecioTotal()
                    Else
                        ToastNotification.Show(Me, "    Este Servicio ya esta insertado en el detalle de la venta,Pero Usted puede modificar la cantidad del servicio que requiera!!               ", My.Resources.WARNING, 3000, eToastGlowColor.Red, eToastPosition.TopCenter)
                    End If
                    Exit Sub
                End If
            End If

            If (e.KeyData = Keys.Control + Keys.Enter And grDetalle.Row >= 0 And grDetalle.Col = grDetalle.RootTable.Columns("nombre").Index And btnGrabar.Enabled = True) Then 'Esta en la cerca de Personal
                Dim frmAyuda As Modelos.ModeloAyuda
                Dim dt As DataTable = L_prServicioVentaGruaAyudaPersonal()
                If (dt.Rows.Count <= 0) Then
                    MsgBox("No Existe Ningun Personal Para El Remolque Registrado", MsgBoxStyle.Exclamation, "Error")
                    Return
                End If
                Dim listEstCeldas As New List(Of Modelos.Celda)

                'panumi ,paci ,panom ,paape ,patelef1

                listEstCeldas.Add(New Modelos.Celda("panumi", True, "ID", 50))
                listEstCeldas.Add(New Modelos.Celda("paci", True, "CI", 80))
                listEstCeldas.Add(New Modelos.Celda("panom", True, "NOMBRES", 200))
                listEstCeldas.Add(New Modelos.Celda("paape", True, "APELLIDOS", 200))
                listEstCeldas.Add(New Modelos.Celda("patelef1", True, "TELEFONO", 120))


                frmAyuda = New Modelos.ModeloAyuda(330, 300, dt, "Seleccione Personal".ToUpper, listEstCeldas)
                frmAyuda.ShowDialog()

                If frmAyuda.seleccionado = True Then
                    Dim idEmpleado As String = frmAyuda.filaSelect.Cells("panumi").Value
                    Dim NameEmpleado As String = frmAyuda.filaSelect.Cells("panom").Value + " " + frmAyuda.filaSelect.Cells("paape").Value
                    Dim lin As Integer = grDetalle.GetValue("rdlin")
                    Dim pos As Integer = -1
                    _prObtenerPosicionDetalle(pos, lin)
                    If (pos >= 0) Then
                        Dim estado As Integer = CType(grDetalle.DataSource, DataTable).Rows(pos).Item("estado")
                        If (estado = 1) Then
                            CType(grDetalle.DataSource, DataTable).Rows(pos).Item("estado") = 2
                        End If
                        CType(grDetalle.DataSource, DataTable).Rows(pos).Item("rdtp1emp") = idEmpleado
                        CType(grDetalle.DataSource, DataTable).Rows(pos).Item("nombre") = NameEmpleado
                    End If

                    If (grDetalle.FocusCellFormatStyle.BackColor = Color.Red) Then
                        grDetalle.FocusCellFormatStyle.BackColor = DefaultBackColor
                    End If
                    grDetalle.Row = indexfil
                    grDetalle.Col = indexcol + 2
                End If


                Exit Sub
            End If


        End If
    End Sub
   

    Private Sub grDetalle_EditingCell(sender As Object, e As EditingCellEventArgs) Handles grDetalle.EditingCell
        If (Not _fnVisualizarRegistros()) Then
            'Habilitar solo las columnas de Precio, %, Monto y Observación
            If (e.Column.Index = grDetalle.RootTable.Columns("rdcant").Index Or e.Column.Index = grDetalle.RootTable.Columns("rdpdes").Index Or e.Column.Index = grDetalle.RootTable.Columns("rdmdes").Index) Then
                e.Cancel = False
            Else
                e.Cancel = True
            End If
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub grDetalle_CellEdited(sender As Object, e As ColumnActionEventArgs) Handles grDetalle.CellEdited
        ' grDetalle.GetRow(grDetalle.Row).BeginEdit()

        Dim rowIndex As Integer = grDetalle.CurrentRow.RowIndex
        'Columna de Precio Venta
        If (e.Column.Index = grDetalle.RootTable.Columns("rdcant").Index) Then
            If (Not IsNumeric(grDetalle.GetValue("rdcant")) Or grDetalle.GetValue("rdcant").ToString = String.Empty) Then

                'grDetalle.GetRow(rowIndex).Cells("cant").Value = 1
                '  grDetalle.CurrentRow.Cells.Item("cant").Value = 1
                Dim lin As Integer = grDetalle.GetValue("rdlin")
                Dim pos As Integer = -1
                _prObtenerPosicionDetalle(pos, lin)
                CType(grDetalle.DataSource, DataTable).Rows(pos).Item("rdcant") = 1
                CType(grDetalle.DataSource, DataTable).Rows(pos).Item("rdptot") = CType(grDetalle.DataSource, DataTable).Rows(pos).Item("rdpuni")




            Else
                If (grDetalle.GetValue("rdcant") > 0) Then
                    P_PonerTotal(rowIndex)



                Else
                    grDetalle.GetRow(rowIndex).Cells("rdcant").Value = 1
                    _prCalcularPrecioTotal()

                End If
            End If
        End If

        If (e.Column.Index = grDetalle.RootTable.Columns("rdpdes").Index) Then
            If (Not IsNumeric(grDetalle.GetValue("rdpdes")) Or grDetalle.GetValue("rdpdes").ToString = String.Empty) Then

                Dim lin As Integer = grDetalle.GetValue("rdlin")
                Dim pos As Integer = -1
                _prObtenerPosicionDetalle(pos, lin)
                Dim cantidad As Integer = grDetalle.GetValue("rdcant")
                CType(grDetalle.DataSource, DataTable).Rows(pos).Item("rdpdes") = 0
                CType(grDetalle.DataSource, DataTable).Rows(pos).Item("rdmdes") = 0
                CType(grDetalle.DataSource, DataTable).Rows(pos).Item("rdptot") = CType(grDetalle.DataSource, DataTable).Rows(pos).Item("rdpuni") * cantidad
            Else
                Dim lin As Integer = grDetalle.GetValue("rdlin")
                Dim pos As Integer = -1
                _prObtenerPosicionDetalle(pos, lin)
                If (grDetalle.GetValue("rdpdes") > 0) Then
                    Dim porcdesc As Double = grDetalle.GetValue("rdpdes")

                    If (porcdesc = 0 Or porcdesc > 100) Then
                        grDetalle.SetValue("rdpdes", 0)
                        grDetalle.SetValue("rdmdes", 0)
                        _prCalcularPrecioTotal()

                    Else

                        Dim TotalUnitario As Integer = CType(grDetalle.DataSource, DataTable).Rows(pos).Item("rdpuni")
                        Dim montodesc As Double = (TotalUnitario * (porcdesc / 100))
                        grDetalle.SetValue("rdmdes", montodesc)
                        _prCalcularPrecioTotal()
                    End If


                    P_PonerTotal(rowIndex)
                Else
                    grDetalle.GetRow(rowIndex).Cells("rdpdes").Value = 0
                    grDetalle.GetRow(rowIndex).Cells("rdmdes").Value = 0
                    _prCalcularPrecioTotal()
                End If
            End If
        End If
        '' AQUI CALCULAMOS EL MONTO DE DESCUENTO
        If (e.Column.Index = grDetalle.RootTable.Columns("rdmdes").Index) Then
            If (Not IsNumeric(grDetalle.GetValue("rdmdes")) Or grDetalle.GetValue("rdmdes").ToString = String.Empty) Then

                Dim lin As Integer = grDetalle.GetValue("rdlin")
                Dim pos As Integer = -1
                _prObtenerPosicionDetalle(pos, lin)
                Dim cantidad As Double = grDetalle.GetValue("rdcant")
                CType(grDetalle.DataSource, DataTable).Rows(pos).Item("rdpdes") = 0
                CType(grDetalle.DataSource, DataTable).Rows(pos).Item("rdmdes") = 0
                CType(grDetalle.DataSource, DataTable).Rows(pos).Item("rdptot") = CType(grDetalle.DataSource, DataTable).Rows(pos).Item("rdpuni") * cantidad
            Else
                Dim lin As Integer = grDetalle.GetValue("rdlin")
                Dim pos As Integer = -1
                _prObtenerPosicionDetalle(pos, lin)
                If (grDetalle.GetValue("rdmdes") > 0) Then
                    Dim mondesc As Double = grDetalle.GetValue("rdmdes")
                    Dim total As Double = grDetalle.GetValue("rdpuni") * grDetalle.GetValue("rdcant")
                    If (mondesc = 0 Or mondesc > total) Then
                        grDetalle.SetValue("rdpdes", 0)
                        grDetalle.SetValue("rdmdes", 0)
                        _prCalcularPrecioTotal()

                    Else

                        Dim TotalUnitario As Double = grDetalle.GetValue("rdpuni") * grDetalle.GetValue("rdcant")
                        Dim pordesc As Double = ((mondesc * 100) / TotalUnitario)
                        grDetalle.SetValue("rdpdes", pordesc)

                        _prCalcularPrecioTotal()
                    End If


                    P_PonerTotal(rowIndex)
                Else
                    grDetalle.GetRow(rowIndex).Cells("rdpdes").Value = 0
                    grDetalle.GetRow(rowIndex).Cells("rdmdes").Value = 0
                    _prCalcularPrecioTotal()
                End If
            End If
        End If

    End Sub

    Private Sub ELIMINARFILAToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Eliminarms.Click
        Dim pos As Integer = grDetalle.Row


        If grDetalle.RowCount > 1 And pos >= 0 And pos <= grDetalle.RowCount - 1 Then
            Dim estado As Integer

            Dim lin As Integer = grDetalle.GetValue("rdlin")
            Dim PosicionData As Integer = -1
            _prObtenerPosicionDetalle(PosicionData, lin)

            estado = CType(grDetalle.DataSource, DataTable).Rows(PosicionData).Item("estado")

            If estado = 1 Or estado = 2 Then ' si estoy eliminando una fila ya guardada le cambio el estado y lo oculto de la grilla
                CType(grDetalle.DataSource, DataTable).Rows(PosicionData).Item("estado") = -1


                grDetalle.RootTable.ApplyFilter(New Janus.Windows.GridEX.GridEXFilterCondition(grDetalle.RootTable.Columns("estado"), Janus.Windows.GridEX.ConditionOperator.GreaterThanOrEqualTo, 0))
                _prCalcularPrecioTotal()



            Else 'si estoy eliminando una fila nueva, simplemente la elimino del grid

                ' CType(grDetalleEquipo.DataSource, DataTable).Rows(pos).Delete()
                If (estado = 0) Then

                    If (Not _fnValidarColumn(PosicionData, pos, False)) Then
                        grDetalle.FocusCellFormatStyle.BackColor = DefaultBackColor
                        CType(grDetalle.DataSource, DataTable).Rows.RemoveAt(PosicionData)
                        _prCalcularPrecioTotal()
                    Else

                        CType(grDetalle.DataSource, DataTable).Rows.RemoveAt(PosicionData)
                        _prCalcularPrecioTotal()
                    End If
                End If


            End If
        End If
    End Sub

    Private Sub JGrM_Buscador_DoubleClick(sender As Object, e As EventArgs) Handles JGrM_Buscador.DoubleClick
        _prVolverAtras()

    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        tbVehiculo.Focus()

    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        tbVehiculo.Focus()


    End Sub



    Private Sub grVentasPendientes_Click(sender As Object, e As EventArgs) Handles grVentasPendientes.Click

        If (Not _fnActionNuevo() And tbVehiculo.ReadOnly()) Then
            Dim row As Integer = grVentasPendientes.Row
            If (row >= 0 And row < grVentasPendientes.RowCount) Then

                Dim numi As Integer = grVentasPendientes.GetValue("rcnumi")

                JGrM_Buscador.RootTable.ApplyFilter(New Janus.Windows.GridEX.GridEXFilterCondition(JGrM_Buscador.RootTable.Columns("rcnumi"), Janus.Windows.GridEX.ConditionOperator.Equal, numi))
            End If
        End If


    End Sub

    Private Sub btnGrabar_Click(sender As Object, e As EventArgs) Handles btnGrabar.Click

    End Sub



    Private Sub tbVehiculo_KeyDown_1(sender As Object, e As KeyEventArgs) Handles tbVehiculo.KeyDown
        If (Not _fnVisualizarRegistros() And Estado.IsReadOnly = False) Then


            If e.KeyData = Keys.Control + Keys.Enter Then

                If (tbVehiculo.Text <> String.Empty) Then

                    If (grVentasPendientes.RowCount > 0) Then
                        grVentasPendientes.Row = 0

                        tbCliente.Text = grVentasPendientes.GetValue("nombre")
                        tbnumiCliente.Text = grVentasPendientes.GetValue("ranumi")
                        tbnumiVehiculo.Text = grVentasPendientes.GetValue("rblin")
                        tbVehiculo.Text = grVentasPendientes.GetValue("rbplac")
                        TableCliente = True ''Bandera para no lanzar ventana de advertencia

                      
                        TableCliente = False
                        Dim nsoc As Integer = grVentasPendientes.GetValue("ransoc")
                        If (nsoc > 0) Then
                            tbClienteSocio.Value = False
                            Dim FechaPago As DataTable = L_prObtenerUltimoPagoSocio(nsoc)
                            lbFechaPago.Visible = True
                            tbFechaPago.Visible = True
                            If (FechaPago.Rows.Count > 0) Then
                                tbFechaPago.Text = "Mes: " + FechaPago.Rows(0).Item("semes").ToString + " Año: " + FechaPago.Rows(0).Item("seano").ToString
                                If (Now.Year = FechaPago.Rows(0).Item("seano")) Then
                                    Dim MesSitema As Integer = FechaPago.Rows(0).Item("semes")
                                    Dim mora As Integer = FechaPago.Rows(0).Item("mora")
                                    If (((Now.Month - mora) <= MesSitema)) Then

                                        tbFechaPago.BackColor = Color.White
                                        MEP.SetError(tbFechaPago, "")
                                        MHighlighterFocus.UpdateHighlights()
                                        lbUltimaPago.Visible = True
                                        lbUltimaPago.Text = "HABILITADO"
                                        lbUltimaPago.ForeColor = Color.DarkSlateGray
                                        PagoAlDia = True
                                  
                                    Else
                                        PagoAlDia = False
                                        MEP.SetError(tbFechaPago, "Socio esta con deudas atrazas!".ToUpper)
                                        MHighlighterFocus.UpdateHighlights()
                                        tbFechaPago.BackColor = Color.Red
                                        lbUltimaPago.Visible = True
                                        lbUltimaPago.Text = "INHABILITADO"
                                        lbUltimaPago.ForeColor = Color.Red
                                     
                                    End If
                                Else
                                    PagoAlDia = False
                                    MEP.SetError(tbFechaPago, "Socio esta con deudas atrazas!".ToUpper)
                                    MHighlighterFocus.UpdateHighlights()
                                    tbFechaPago.BackColor = Color.Red
                                    lbUltimaPago.Visible = True
                                    lbUltimaPago.Text = "INHABILITADO"
                                    lbUltimaPago.ForeColor = Color.Red
                                    
                                End If

                            Else 'Si el socio no hizo ningun pago
                                PagoAlDia = False
                                MEP.SetError(tbFechaPago, "Socio esta con deudas atrazas!".ToUpper)
                                MHighlighterFocus.UpdateHighlights()
                                tbFechaPago.BackColor = Color.Red
                                tbFechaPago.Text = "Sin Ningun Pago"
                                lbUltimaPago.Visible = True
                                lbUltimaPago.Text = "INHABILITADO"
                                lbUltimaPago.ForeColor = Color.Red
                          
                            End If
                        Else
                            tbClienteSocio.Value = True
                            tbFechaPago.Text = ""
                            lbFechaPago.Visible = False
                            tbFechaPago.Visible = False
                            lbUltimaPago.Visible = False
                           
                        End If

                        _VerificarPagoAlDia(nsoc)
                        Dim nameimagen As String = grVentasPendientes.GetValue("rafot")
                        If (File.Exists(RutaGlobal + "\Imagenes\Imagenes ClienteR" + nameimagen)) Then
                            Dim im As New Bitmap(New Bitmap(RutaGlobal + "\Imagenes\Imagenes ClienteR" + nameimagen))
                            UsImg.pbImage.SizeMode = PictureBoxSizeMode.StretchImage

                            UsImg.pbImage.Image = im

                        End If

                        _prCambiarEstadoItemEliminar()
                        If (grDetalle.RowCount = 0) Then
                            _prAddFilaDetalle()

                        End If
                        grDetalle.Focus()

                        grDetalle.Select()
                        grDetalle.Col = 2
                        grDetalle.Row = 0
                    End If
                    ''Aqui
                End If

            End If
            If (e.KeyData = Keys.Enter) Then
                If (tbnumiVehiculo.Text = 0) Then
                    tbVehiculo.Focus()

                    ToastNotification.Show(Me, "           Antes De Continuar Por favor Seleccione un Vehiculo !!             ", My.Resources.WARNING, 4000, eToastGlowColor.Red, eToastPosition.TopCenter)
                    Return

                End If
            End If
        End If
    End Sub

  

    Private Sub grDetalle_CellValueChanged(sender As Object, e As ColumnActionEventArgs) Handles grDetalle.CellValueChanged
        Dim rowIndex As Integer = grDetalle.CurrentRow.RowIndex
        'Columna de Precio Venta
        If (e.Column.Index = grDetalle.RootTable.Columns("rdcant").Index) Then
            If (Not IsNumeric(grDetalle.GetValue("rdcant")) Or grDetalle.GetValue("rdcant").ToString = String.Empty) Then

                'grDetalle.GetRow(rowIndex).Cells("cant").Value = 1
                '  grDetalle.CurrentRow.Cells.Item("cant").Value = 1
                Dim lin As Integer = grDetalle.GetValue("rdlin")
                Dim pos As Integer = -1
                _prObtenerPosicionDetalle(pos, lin)
                CType(grDetalle.DataSource, DataTable).Rows(pos).Item("rdcant") = 1
                CType(grDetalle.DataSource, DataTable).Rows(pos).Item("rdptot") = CType(grDetalle.DataSource, DataTable).Rows(pos).Item("rdpuni")




            Else
                If (grDetalle.GetValue("rdcant") > 0) Then
                    P_PonerTotal(rowIndex)



                Else
                    grDetalle.GetRow(rowIndex).Cells("rdcant").Value = 1
                    _prCalcularPrecioTotal()

                End If
            End If
        End If

        If (e.Column.Index = grDetalle.RootTable.Columns("rdpdes").Index) Then
            If (Not IsNumeric(grDetalle.GetValue("rdpdes")) Or grDetalle.GetValue("rdpdes").ToString = String.Empty) Then

                Dim lin As Integer = grDetalle.GetValue("rdlin")
                Dim pos As Integer = -1
                _prObtenerPosicionDetalle(pos, lin)
                Dim cantidad As Integer = grDetalle.GetValue("rdcant")
                CType(grDetalle.DataSource, DataTable).Rows(pos).Item("rdpdes") = 0
                CType(grDetalle.DataSource, DataTable).Rows(pos).Item("rdmdes") = 0
                CType(grDetalle.DataSource, DataTable).Rows(pos).Item("rdptot") = CType(grDetalle.DataSource, DataTable).Rows(pos).Item("rdpuni") * cantidad
            Else
                Dim lin As Integer = grDetalle.GetValue("rdlin")
                Dim pos As Integer = -1
                _prObtenerPosicionDetalle(pos, lin)
                If (grDetalle.GetValue("rdpdes") > 0) Then
                    Dim porcdesc As Double = grDetalle.GetValue("rdpdes")

                    If (porcdesc = 0 Or porcdesc > 100) Then
                        grDetalle.SetValue("rdpdes", 0)
                        grDetalle.SetValue("rdmdes", 0)
                        _prCalcularPrecioTotal()

                    Else

                        Dim TotalUnitario As Integer = CType(grDetalle.DataSource, DataTable).Rows(pos).Item("rdpuni")
                        Dim montodesc As Double = (TotalUnitario * (porcdesc / 100))
                        grDetalle.SetValue("rdmdes", montodesc)
                        _prCalcularPrecioTotal()
                    End If


                    P_PonerTotal(rowIndex)
                Else
                    grDetalle.GetRow(rowIndex).Cells("rdpdes").Value = 0
                    grDetalle.GetRow(rowIndex).Cells("rdmdes").Value = 0
                    grDetalle.GetRow(rowIndex).Cells("rdptot").Value = grDetalle.GetValue("rdpuni")
                    _prCalcularPrecioTotal()
                End If
            End If
        End If
        '' AQUI CALCULAMOS EL MONTO DE DESCUENTO
        If (e.Column.Index = grDetalle.RootTable.Columns("rdmdes").Index) Then
            If (Not IsNumeric(grDetalle.GetValue("rdmdes")) Or grDetalle.GetValue("rdmdes").ToString = String.Empty) Then

                Dim lin As Integer = grDetalle.GetValue("rdlin")
                Dim pos As Integer = -1
                _prObtenerPosicionDetalle(pos, lin)
                Dim cantidad As Double = grDetalle.GetValue("rdcant")
                CType(grDetalle.DataSource, DataTable).Rows(pos).Item("rdpdes") = 0
                CType(grDetalle.DataSource, DataTable).Rows(pos).Item("rdmdes") = 0
                CType(grDetalle.DataSource, DataTable).Rows(pos).Item("rdptot") = CType(grDetalle.DataSource, DataTable).Rows(pos).Item("rdpuni") * cantidad
            Else
                Dim lin As Integer = grDetalle.GetValue("rdlin")
                Dim pos As Integer = -1
                _prObtenerPosicionDetalle(pos, lin)
                If (grDetalle.GetValue("rdmdes") > 0) Then
                    Dim mondesc As Double = grDetalle.GetValue("rdmdes")
                    Dim total As Double = grDetalle.GetValue("rdpuni") * grDetalle.GetValue("rdcant")
                    If (mondesc = 0 Or mondesc > total) Then
                        grDetalle.SetValue("rdpdes", 0)
                        grDetalle.SetValue("rdmdes", 0)
                        _prCalcularPrecioTotal()

                    Else

                        Dim TotalUnitario As Double = grDetalle.GetValue("rdpuni") * grDetalle.GetValue("rdcant")
                        Dim pordesc As Double = ((mondesc * 100) / TotalUnitario)
                        grDetalle.SetValue("rdpdes", pordesc)

                        _prCalcularPrecioTotal()
                    End If


                    P_PonerTotal(rowIndex)
                Else
                    grDetalle.GetRow(rowIndex).Cells("rdpdes").Value = 0
                    grDetalle.GetRow(rowIndex).Cells("rdmdes").Value = 0
                    grDetalle.GetRow(rowIndex).Cells("rdptot").Value = grDetalle.GetValue("rdpuni")
                    _prCalcularPrecioTotal()
                End If
            End If
        End If

    End Sub

    Private Sub ButtonX3_Click(sender As Object, e As EventArgs) Handles btnAnadir.Click

        Dim frm As New F_ClienteNuevoRemolque
        Dim dt As DataTable
        frm.placaV = tbVehiculo.Text
        frm.ShowDialog()
        Dim placa As String = frm.placaV

        If (frm.Cliente = True) Then ''Aqui Consulto si se inserto un nuevo Cliente cargo sus datos del nuevo cliente insertado 

            dt = L_prServicioVentaAyudaVehiculoRemolque(placa)
            If (dt.Rows.Count > 0) Then
                tbCliente.Text = dt.Rows(0).Item("nombre")
                tbnumiCliente.Text = dt.Rows(0).Item("ranumi")
                tbnumiVehiculo.Text = dt.Rows(0).Item("rblin")

                tbVehiculo.Text = placa
                TableCliente = True
                TableCliente = False
                Cliente = False
                grDetalle.Focus()
                placa = ""
                tbClienteSocio.Value = True
                lbFechaPago.Visible = False
                tbFechaPago.Text = ""
                tbFechaPago.Visible = False

                If (_fnActionNuevo()) Then
                    CType(grDetalle.DataSource, DataTable).Rows.Clear()
                    _prAddFilaDetalle()
                    grVentasPendientes.RemoveFilters()
                Else
                    _prCambiarEstadoItemEliminar()
                    If (grDetalle.RowCount = 0) Then
                        _prAddFilaDetalle()

                    End If
                    grVentasPendientes.RemoveFilters()
                End If
                grDetalle.Focus()

                grDetalle.Select()
                grDetalle.Col = 2
                grDetalle.Row = 0
                UsImg.pbImage.Image = My.Resources.imageDefault

            End If
        End If
    End Sub



    Private Sub tbVehiculo_TextChanged(sender As Object, e As EventArgs) Handles tbVehiculo.TextChanged
        If (_fnActionNuevo() Or tbVehiculo.ReadOnly = False) Then
            If (tbVehiculo.Text = String.Empty) Then
                tbCliente.Text = ""
                tbnumiCliente.Text = 0
                tbnumiVehiculo.Text = 0
                UsImg.pbImage.Image = My.Resources.imageDefault
                tbClienteSocio.Value = True
                lbFechaPago.Visible = False
                tbFechaPago.Text = ""
                tbFechaPago.Visible = False

                If (_fnActionNuevo()) Then
                    CType(grDetalle.DataSource, DataTable).Rows.Clear()
                    _prAddFilaDetalle()
                    grVentasPendientes.RemoveFilters()
                Else
                    _prCambiarEstadoItemEliminar()

                    If (grDetalle.RowCount = 0) Then
                        _prAddFilaDetalle()

                    End If
                    grVentasPendientes.RemoveFilters()
                End If


            Else
                If (Not IsNothing(grVentasPendientes.DataSource) And Not IsNothing(grDetalle.DataSource)) Then
                    grVentasPendientes.RootTable.ApplyFilter(New Janus.Windows.GridEX.GridEXFilterCondition(grVentasPendientes.RootTable.Columns("rbplac"), Janus.Windows.GridEX.ConditionOperator.Contains, tbVehiculo.Text))

                End If

            End If
        End If

    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        _prImprimir(tbCodigo.Text)
    End Sub
 

    Private Sub FechaVenta_MouseClick(sender As Object, e As MouseEventArgs) Handles FechaVenta.MouseClick
        If (tbnumiVehiculo.Text = 0) Then
            tbVehiculo.Focus()
            ToastNotification.Show(Me, "           Antes De Continuar Por favor Seleccione un Vehiculo !!             ", My.Resources.WARNING, 4000, eToastGlowColor.Red, eToastPosition.TopCenter)
            Return

        End If
    End Sub

    Private Sub Estado_MouseClick(sender As Object, e As MouseEventArgs) Handles Estado.MouseClick
        If (tbnumiVehiculo.Text = 0) Then
            tbVehiculo.Focus()

            ToastNotification.Show(Me, "           Antes De Continuar Por favor Seleccione un Vehiculo !!             ", My.Resources.WARNING, 4000, eToastGlowColor.Red, eToastPosition.TopCenter)
            Return

        End If
    End Sub

    Private Sub tbVehiculo_Leave(sender As Object, e As EventArgs) Handles tbVehiculo.Leave

        If (Not btnNuevo.Focused And btnModificar.Focused And grVentasPendientes.Focused And Not btnSalir.Focused And Not btnAnadir.Focused) Then
            If (tbnumiVehiculo.Text = 0) Then
                tbVehiculo.Focus()

                ToastNotification.Show(Me, "           Antes De Continuar Por favor Seleccione un Vehiculo !!             ", My.Resources.WARNING, 4000, eToastGlowColor.Red, eToastPosition.TopCenter)
                Return

            End If
        End If

    End Sub

    Private Sub grVentasPendientes_FormattingRow(sender As Object, e As RowLoadEventArgs) Handles grVentasPendientes.FormattingRow

    End Sub

    Private Sub grVentasPendientes_KeyDown(sender As Object, e As KeyEventArgs) Handles grVentasPendientes.KeyDown

        If (_fnActionNuevo() Or tbVehiculo.ReadOnly = False) Then
            If (e.KeyData = Keys.Enter) Then
                If (grVentasPendientes.RowCount > 0) Then
                    tbCliente.Text = grVentasPendientes.GetValue("nombre")
                    tbnumiCliente.Text = grVentasPendientes.GetValue("ranumi")
                    tbnumiVehiculo.Text = grVentasPendientes.GetValue("rblin")
                    tbVehiculo.Text = grVentasPendientes.GetValue("rbplac")
                    Dim nameimagen As String = grVentasPendientes.GetValue("rafot")
                    If (File.Exists(RutaGlobal + "\Imagenes\Imagenes ClienteR" + nameimagen)) Then
                        Dim im As New Bitmap(New Bitmap(RutaGlobal + "\Imagenes\Imagenes ClienteR" + nameimagen))
                        UsImg.pbImage.SizeMode = PictureBoxSizeMode.StretchImage

                        UsImg.pbImage.Image = im

                    End If
                    Dim nsoc As Integer = grVentasPendientes.GetValue("ransoc")
                    If (nsoc > 0) Then
                        tbClienteSocio.Value = False
                        Dim FechaPago As DataTable = L_prObtenerUltimoPagoSocio(nsoc)
                        lbFechaPago.Visible = True
                        tbFechaPago.Visible = True
                        If (FechaPago.Rows.Count > 0) Then

                            tbFechaPago.Text = "Mes: " + FechaPago.Rows(0).Item("semes").ToString + " Año: " + FechaPago.Rows(0).Item("seano").ToString
                            If (Now.Year = FechaPago.Rows(0).Item("seano")) Then
                                Dim MesSitema As Integer = FechaPago.Rows(0).Item("semes")
                                Dim mora As Integer = FechaPago.Rows(0).Item("mora")
                                If (((Now.Month - mora) <= MesSitema)) Then

                                    tbFechaPago.BackColor = Color.White
                                    MEP.SetError(tbFechaPago, "")
                                    MHighlighterFocus.UpdateHighlights()
                                    lbUltimaPago.Visible = True
                                    lbUltimaPago.Text = "HABILITADO"
                                    lbUltimaPago.ForeColor = Color.DarkSlateGray
                                    PagoAlDia = True
                                  
                                Else

                                    MEP.SetError(tbFechaPago, "Socio esta con deudas atrazas!".ToUpper)
                                    MHighlighterFocus.UpdateHighlights()
                                    tbFechaPago.BackColor = Color.Red
                                    lbUltimaPago.Visible = True
                                    lbUltimaPago.Text = "INHABILITADO"
                                    lbUltimaPago.ForeColor = Color.Red
                                    PagoAlDia = False
                                   
                                End If

                            Else
                                MEP.SetError(tbFechaPago, "Socio esta con deudas atrazas!".ToUpper)
                                MHighlighterFocus.UpdateHighlights()
                                tbFechaPago.BackColor = Color.Red
                                lbUltimaPago.Visible = True
                                lbUltimaPago.Text = "INHABILITADO"
                                lbUltimaPago.ForeColor = Color.Red
                                PagoAlDia = False
                              
                            End If

                        Else 'Si el socio no hizo ningun pago
                            MEP.SetError(tbFechaPago, "Socio esta con deudas atrazas!".ToUpper)
                            MHighlighterFocus.UpdateHighlights()
                            tbFechaPago.BackColor = Color.Red
                            tbFechaPago.Text = "Sin Ningun Pago"
                            lbUltimaPago.Visible = True
                            lbUltimaPago.Text = "INHABILITADO"
                            lbUltimaPago.ForeColor = Color.Red
                            PagoAlDia = False
                     
                        End If
                    Else
                        tbClienteSocio.Value = True
                        tbFechaPago.Text = ""
                        lbFechaPago.Visible = False
                        tbFechaPago.Visible = False
                        lbUltimaPago.Visible = False
              
                    End If
                

                    If (_fnActionNuevo()) Then
                        CType(grDetalle.DataSource, DataTable).Rows.Clear()
                        _prAddFilaDetalle()
                        grVentasPendientes.RemoveFilters()
                    Else
                        _prCambiarEstadoItemEliminar()
                        If (grDetalle.RowCount = 0) Then
                            _prAddFilaDetalle()

                        End If
                        grVentasPendientes.RemoveFilters()
                    End If
                    _VerificarPagoAlDia(nsoc)

                    grDetalle.Focus()

                    grDetalle.Select()
                    grDetalle.Col = 2
                    grDetalle.Row = 0
                End If




            End If
        End If

    End Sub
#End Region

    Private Sub grDetalle_FormattingRow(sender As Object, e As RowLoadEventArgs) Handles grDetalle.FormattingRow


    End Sub



    Private Sub Gmc_Cliente_DoubleClick(sender As Object, e As EventArgs) Handles Gmc_Cliente.DoubleClick
        If (btnGrabar.Enabled = True) Then


            _Overlay.Markers.Clear()

            Dim gm As GMapControl = CType(sender, GMapControl)
            Dim hj As MouseEventArgs = CType(e, MouseEventArgs)
            Dim plg As PointLatLng = gm.FromLocalToLatLng(hj.X, hj.Y)
            _latitud = plg.Lat
            _longitud = plg.Lng
            ''  MsgBox("latitud:" + Str(plg.Lat) + "   Logitud:" + Str(plg.Lng))

            P_AgregarPunto(plg, "", "")

            '' _ListPuntos.Add(plg)
            'Btnx_ChekGetPoint.Visible = False
        End If
    End Sub

    Private Sub ButtonX3_Click_1(sender As Object, e As EventArgs) Handles ButtonX3.Click
        If (Gmc_Cliente.Zoom <= Gmc_Cliente.MaxZoom) Then
            Gmc_Cliente.Zoom = Gmc_Cliente.Zoom + 1
        End If

    End Sub

    Private Sub ButtonX4_Click(sender As Object, e As EventArgs) Handles ButtonX4.Click
        If (Gmc_Cliente.Zoom >= Gmc_Cliente.MinZoom) Then
            Gmc_Cliente.Zoom = Gmc_Cliente.Zoom - 1
        End If

    End Sub

    Private Sub lbFechaPago_Click(sender As Object, e As EventArgs) Handles lbFechaPago.Click

    End Sub

    Private Sub tbFechaPago_TextChanged(sender As Object, e As EventArgs) Handles tbFechaPago.TextChanged

    End Sub

    Private Sub LabelX6_Click(sender As Object, e As EventArgs) Handles LabelX6.Click

    End Sub

    Private Sub tbCodigo_TextChanged(sender As Object, e As EventArgs) Handles tbCodigo.TextChanged

    End Sub

    Private Sub tbClienteSocio_ValueChanged(sender As Object, e As EventArgs) Handles tbClienteSocio.ValueChanged

    End Sub

    Private Sub LabelX1_Click(sender As Object, e As EventArgs) Handles LabelX1.Click

    End Sub

    Private Sub tbnumiVehiculo_TextChanged(sender As Object, e As EventArgs) Handles tbnumiVehiculo.TextChanged

    End Sub

    Private Sub LabelX2_Click(sender As Object, e As EventArgs) Handles LabelX2.Click

    End Sub

    Private Sub tbCliente_TextChanged(sender As Object, e As EventArgs) Handles tbCliente.TextChanged

    End Sub

    Private Sub tbnumiCliente_TextChanged(sender As Object, e As EventArgs) Handles tbnumiCliente.TextChanged

    End Sub

    Private Sub LabelX8_Click(sender As Object, e As EventArgs) Handles LabelX8.Click

    End Sub

    Private Sub FechaVenta_Click(sender As Object, e As EventArgs) Handles FechaVenta.Click

    End Sub

    Private Sub tbobs_TextChanged(sender As Object, e As EventArgs) Handles tbobs.TextChanged

    End Sub

    Private Sub LabelX3_Click(sender As Object, e As EventArgs) Handles LabelX3.Click

    End Sub

    Private Sub tbVehiculo_Click(sender As Object, e As EventArgs) Handles tbVehiculo.Click
        SuperTabControl1.SelectedTabIndex = 0
    End Sub
End Class