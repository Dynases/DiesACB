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


Imports Logica

Public Class F1_HojaRutaRemolque


#Region "Variables Globales"
#Region "MApas"
    Dim _Punto As Integer
    Dim _ListPuntos As List(Of PointLatLng)
    Dim _Overlay As GMapOverlay
    Dim _latitud As Double = 0
    Dim _longitud As Double = 0
#End Region

    Dim RutaGlobal As String = gs_CarpetaRaiz
    Dim RutaTemporal As String = "C:\Temporal"
    Dim StCarpetaImgVehiculo As String = gs_CarpetaRaiz + "\Imagenes\Imagenes Venta\"
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
    Public TablaImagenes As DataTable
    Dim Modificar As Boolean = False
    Dim posImg As Integer = 0
#End Region
#Region "METODOS PRIVADOS"

    Public Function _fnBytesArchivo(ruta As String) As Byte()

        If Not (ruta.Equals(" ")) Then ' esta sería una función que verifica que realmente existe el archivo, devolviendo true o false...

            Return IO.File.ReadAllBytes(ruta)

        Else

            Throw New Exception("No se encuentra el archivo: " & ruta)

        End If

    End Function
#Region "Carpeta Imagenes"

    'Private Sub _prCrearCarpetaImagenes(carpetaFinal As String)
    '    Dim rutaDestino As String = RutaGlobal + "\Imagenes\Imagenes VentaRemolque\" + carpetaFinal + "\"

    '    If System.IO.Directory.Exists(RutaGlobal + "\Imagenes\Imagenes VentaRemolque\" + carpetaFinal) = False Then
    '        If System.IO.Directory.Exists(RutaGlobal + "\Imagenes") = False Then
    '            System.IO.Directory.CreateDirectory(RutaGlobal + "\Imagenes")
    '            If System.IO.Directory.Exists(RutaGlobal + "\Imagenes\Imagenes VentaRemolque") = False Then
    '                System.IO.Directory.CreateDirectory(RutaGlobal + "\Imagenes\Imagenes VentaRemolque")
    '                System.IO.Directory.CreateDirectory(RutaGlobal + "\Imagenes\Imagenes VentaRemolque\" + carpetaFinal + "\")
    '            End If
    '        Else
    '            If System.IO.Directory.Exists(RutaGlobal + "\Imagenes\Imagenes VentaRemolque") = False Then
    '                System.IO.Directory.CreateDirectory(RutaGlobal + "\Imagenes\Imagenes VentaRemolque")
    '                System.IO.Directory.CreateDirectory(RutaGlobal + "\Imagenes\Imagenes VentaRemolque\" + carpetaFinal + "\")
    '            Else
    '                If System.IO.Directory.Exists(RutaGlobal + "\Imagenes\Imagenes VentaRemolque\" + carpetaFinal) = False Then
    '                    System.IO.Directory.CreateDirectory(RutaGlobal + "\Imagenes\Imagenes VentaRemolque\" + carpetaFinal + "\")
    '                End If

    '            End If
    '        End If
    '    End If
    'End Sub

    'Private Sub _prCrearCarpetaTemporal()

    '    If System.IO.Directory.Exists(RutaTemporal) = False Then
    '        System.IO.Directory.CreateDirectory(RutaTemporal)
    '    Else

    '        My.Computer.FileSystem.DeleteDirectory(RutaTemporal, FileIO.DeleteDirectoryOption.DeleteAllContents)
    '        My.Computer.FileSystem.CreateDirectory(RutaTemporal)

    '    End If

    'End Sub
#End Region
    Private Sub _prIniciarTodo()


        Me.Text = "S E R V I C I O   V E N T A   R E M O L Q U E"
        _prInicarMapa()
        _PMIniciarTodo()
        _prAsignarPermisos()
        GroupPanelBuscador.Style.BackColor = Color.FromArgb(13, 71, 161)
        GroupPanelBuscador.Style.BackColor2 = Color.FromArgb(13, 71, 161)
        GroupPanelBuscador.Style.TextColor = Color.White
        JGrM_Buscador.RootTable.Columns("remefec").FormatString = "0.00"
        Dim blah As Bitmap = My.Resources.venta
        Dim ico As Icon = Icon.FromHandle(blah.GetHicon())
        Me.Icon = ico
        JGrM_Buscador.RootTable.HeaderFormatStyle.FontBold = TriState.True
        _prCargarStyle()
        TablaGeneralServicios = L_prObtenerHistorialdeServiciosPoliticaRemolque(-1, 0)
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

    Private Sub _prCargarGridDetalle(_renumi As Integer)
        Dim dt As New DataTable
        dt = L_prServicioVentaGruaDetalle(_renumi)
        ''''janosssssssss''''''
        grdetalle.DataSource = dt
        grdetalle.RetrieveStructure()
        grdetalle.AlternatingColors = True
        grdetalle.RowFormatStyle.Font = New Font("arial", 10)

        'dar formato a las columnas

        'a.rfnumi ,a.rflin ,a.rfTC51ServLib,servicio .cedesc1 as servicio,Cast(1 as bit) as est,1 as estado
        With grdetalle.RootTable.Columns("rflin")
            .Width = 80
            .TextAlignment = TextAlignment.Center
            .Caption = "CODIGO"
            .Visible = False
        End With
        With grdetalle.RootTable.Columns("rfnumi")
            .Width = 60
            .Visible = False
        End With
        With grdetalle.RootTable.Columns("rfTCE04Serv")
            .Width = 90
            .Visible = False
        End With
        With grdetalle.RootTable.Columns("rfprec")
            .Width = 80
            .Visible = True
            .FormatString = "0.00"

            .Caption = "Precio"

        End With
        With grdetalle.RootTable.Columns("rfpdesc")
            .Width = 80
            .Visible = True
            .FormatString = "0.00"

            .Caption = "P. Desc"

        End With
        With grdetalle.RootTable.Columns("rfmdesc")
            .Width = 80
            .Visible = True
            .FormatString = "0.00"

            .Caption = "M. Desc"

        End With
        With grdetalle.RootTable.Columns("total")
            .Width = 80
            .Visible = True
            .FormatString = "0.00"
            .AggregateFunction = AggregateFunction.Sum
            .Caption = "Total"

        End With
        With grdetalle.RootTable.Columns("servicio")
            .Width = 250
            .Caption = "Servicio"
            .Visible = True
        End With
        With grdetalle.RootTable.Columns("est")
            .Width = 70
            .Caption = "Estado"
            .Visible = True
        End With
        With grdetalle.RootTable.Columns("estado")
            .Width = 250
            .Visible = False
        End With

        With grdetalle
            .GroupByBoxVisible = False
            'diseño de la grilla
            .VisualStyle = VisualStyle.Office2007
            .TotalRow = InheritableBoolean.True
        End With
        grdetalle.RootTable.HeaderFormatStyle.FontBold = TriState.True


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
        With grVentasPendientes.RootTable.Columns("rafacnom")
            .Width = 250
            .Visible = False
        End With
        With grVentasPendientes.RootTable.Columns("ranit")
            .Width = 250
            .Visible = False
        End With
        With grVentasPendientes.RootTable.Columns("radir")
            .Width = 250
            .Visible = False
        End With
        With grVentasPendientes.RootTable.Columns("ratelf1")
            .Width = 250
            .Visible = False
        End With
        With grVentasPendientes.RootTable.Columns("raci")
            .Width = 250
            .Caption = "CI"
            .Visible = True
        End With

        With grVentasPendientes.RootTable.Columns("cftsoc")
            .Width = 250
            .Visible = False
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
        Return tbCodigo.Text = String.Empty And tbnumeroControl.ReadOnly = False
    End Function

    Public Function _fnVisualizarRegistros() As Boolean
        Return tbFactura.ReadOnly = True
    End Function


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

        JGrM_Buscador.RootTable.Columns("remefec").FormatString = "0.00"
        ButtonX1.Visible = False
        Eliminarms.Visible = True
        btnAnadir.Visible = True
        _prCargarGridAyudaPlacaCLiente()
        tbFechaVenta.IsInputReadOnly = False
        ''''''''''Cliente'''''''''''''''''
        tbFactura.ReadOnly = False
        tbnit.ReadOnly = False
        tbplaca.ReadOnly = False
        ''''''''''''Venta'''''''''''''''''
        tbnumeroControl.ReadOnly = False
        tbkmSalida.IsInputReadOnly = False
        tbkmEntrada.IsInputReadOnly = False



        tbHoraEntrada.Enabled = True
        tbHoraSalida.Enabled = True
        ''  tbTiempoUtilizado.Enabled = True

        tbLugarOrigen.ReadOnly = False
        tbLugarDestino.ReadOnly = False

        tbobs.ReadOnly = False
        checkGratis.Enabled = True
        CheckCredito.Enabled = True
        CheckEfectivo.Enabled = True
        CheckCheque.Enabled = True
        ''''''''''''''''''''''''''''''
        SuperTabItem1.Visible = True
        SuperTabControl1.SelectedTabIndex = 0
        tbplaca.Focus()
        'tbTiempoUtilizado.IsInputReadOnly = False
        Modificar = True
        tbdireccion.ReadOnly = False
        tbtelefono.ReadOnly = False
        _prCargarImagen()
        btDeleteImg.Visible = True

    End Sub
    Public Overrides Sub _PMOInhabilitar()

        JGrM_Buscador.RootTable.Columns("remefec").FormatString = "0.00"
        ButtonX1.Visible = True
        Eliminarms.Visible = False
        btnAnadir.Visible = False
        _prCargarGridAyudaPlacaCLiente()
        'GpVentasSinCobrar.Text = "V E N T A S    S I N    C O B R A R"
        ''''''''''Cliente'''''''''''''''''
        tbplaca.ReadOnly = True
        tbCliente.ReadOnly = True
        tbmodeloCliente.ReadOnly = True
        tbmarcaCLiente.ReadOnly = True
        tbFactura.ReadOnly = True
        tbnit.ReadOnly = True
        tbFechaVenta.IsInputReadOnly = True
        tbFechaPago.Visible = False
        lbFechaPago.Visible = False
        lbUltimaPago.Visible = False
        tbClienteSocio.IsReadOnly = True
        SuperTabItem1.Visible = False
        PagoAlDia = False
        ''''''''''''Venta'''''''''''''''''
        tbCodigo.Enabled = False
        tbnumeroControl.ReadOnly = True
        tbkmSalida.IsInputReadOnly = True
        tbkmEntrada.IsInputReadOnly = True
        tbTotalKilomentraje.IsInputReadOnly = True
        tbVehiculoAsignado.ReadOnly = True
        tbmarcaEmpleado.ReadOnly = True
        tbmodeloEmpleado.ReadOnly = True
        tbChofer.ReadOnly = True

        tbHoraEntrada.Enabled = False
        tbHoraSalida.Enabled = False
        tbTiempoUtilizado.Enabled = False

        tbLugarOrigen.ReadOnly = True
        tbLugarDestino.ReadOnly = True
        tbdireccion.ReadOnly = True
        tbtelefono.ReadOnly = True
        tbobs.ReadOnly = False
        checkGratis.Enabled = False
        CheckCredito.Enabled = False
        CheckEfectivo.Enabled = False
        CheckCheque.Enabled = False
        ''''''''''''''''''''''''''''''
        Modificar = False
        btDeleteImg.Visible = False
        TablaGeneralServicios = L_prObtenerHistorialdeServiciosPoliticaRemolque(-1, 0)
        SuperTabItem4.Visible = False
    End Sub
    Public Overrides Sub _PMOHabilitarFocus()
        With MHighlighterFocus
            .SetHighlightOnFocus(tbCliente, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
            .SetHighlightOnFocus(tbFechaVenta, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
            .SetHighlightOnFocus(tbplaca, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
            .SetHighlightOnFocus(tbmarcaCLiente, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
            .SetHighlightOnFocus(tbmodeloCliente, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
            .SetHighlightOnFocus(tbFactura, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
            .SetHighlightOnFocus(tbnit, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
            .SetHighlightOnFocus(tbdireccion, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
            .SetHighlightOnFocus(tbtelefono, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
            .SetHighlightOnFocus(tbnumeroControl, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
            .SetHighlightOnFocus(tbVehiculoAsignado, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
            .SetHighlightOnFocus(tbmarcaEmpleado, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
            .SetHighlightOnFocus(tbmodeloEmpleado, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
            .SetHighlightOnFocus(tbChofer, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
            .SetHighlightOnFocus(tbHoraSalida, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
            .SetHighlightOnFocus(tbHoraEntrada, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
            .SetHighlightOnFocus(tbTiempoUtilizado, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
            .SetHighlightOnFocus(tbLugarDestino, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
            .SetHighlightOnFocus(tbLugarOrigen, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
            .SetHighlightOnFocus(tbobs, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)


        End With
    End Sub
    Public Overrides Sub _PMOLimpiar()


        tbnumiCliente.Text = 0
        tbnumiVehiculoEmpleado.Text = 0
        tbvehiculoCliente.Text = 0
        tbnumiEmpleado.Text = 0
        tbnsoc.Text = 0
        TipoTamano = -1
        _prCargarGridDetalle(-1)
        ButtonX1.Visible = False
        ButtonX2.Visible = False
        _prCargarGridAyudaPlacaCLiente()
        tbFechaPago.Text = ""
        lbFechaPago.Visible = False
        tbFechaPago.Visible = False
        tbClienteSocio.Value = True
        TipoTamano = -1
        PagoAlDia = False
        _latitud = 0
        _longitud = 0
        _Overlay.Markers.Clear()
        tbobs.Text = ""
        tbFechaVenta.Text = DateTime.Now.ToString("dd/MM/yyyy")
        ''''''''''Cliente'''''''''''''''''
        tbplaca.Text = ""
        tbCliente.Text = ""
        tbmodeloCliente.Text = ""
        tbmarcaCLiente.Text = ""
        tbFactura.Text = ""
        tbnit.Text = ""
        tbFechaVenta.IsInputReadOnly = False
        tbFechaPago.Visible = False
        lbFechaPago.Visible = False
        lbUltimaPago.Visible = False
        tbClienteSocio.IsReadOnly = True
        PagoAlDia = False
        ''''''''''''Venta'''''''''''''''''
        tbCodigo.Enabled = False
        tbnumeroControl.Text = ""
        tbkmSalida.Text = ""
        tbkmEntrada.Text = ""
        tbTotalKilomentraje.Text = ""
        tbVehiculoAsignado.Text = ""
        tbmarcaEmpleado.Text = ""
        tbmodeloEmpleado.Text = ""
        tbChofer.Text = ""
        tbHoraEntrada.Text = ""
        tbHoraSalida.Text = ""
        tbTiempoUtilizado.Text = ""
        tbLugarOrigen.Text = ""
        tbLugarDestino.Text = ""

        tbobs.ReadOnly = False
        checkGratis.Enabled = True
        CheckCredito.Enabled = True
        CheckEfectivo.Enabled = True
        CheckCheque.Enabled = True
        TablaImagenes = L_prCargarImagenes(-1)
        Modificar = True
        _prCargarImagen()
        TablaGeneralServicios = L_prObtenerHistorialdeServiciosPoliticaRemolque(-1, 0)
        SuperTabItem4.Visible = False
    End Sub
    Public Overrides Sub _PMOLimpiarErrores()

        MEP.Clear()
        tbCliente.BackColor = Color.White
        tbplaca.BackColor = Color.White
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
        If tbplaca.Text = String.Empty Then
            tbplaca.BackColor = Color.Red
            MEP.SetError(tbplaca, "Seleccione un Vehiculo con Ctrl+Enter!".ToUpper)
            _ok = False
        Else
            tbplaca.BackColor = Color.White
            MEP.SetError(tbplaca, "")
        End If

        If (_fnValidarDatosDetalle() = False) Then
            _ok = False
        End If
        MHighlighterFocus.UpdateHighlights()
        Return _ok
    End Function
    Public Overrides Function _PMOGetListEstructuraBuscador() As List(Of Modelos.Celda)
        Dim listEstCeldas As New List(Of Modelos.Celda)

        ' ,a.refdoc,modelo .cedesc1 as modelo,c.gcid as placa,a.rekmsa ,a.rekmen ,
        'a.rehorsa ,a.rehoren ,b.ransoc ,b.ranom as NombreCliente,b.rafacnom as NombreFactura,b.ranit ,
        'b.radir ,b.ratelf1 ,MarcaCliente .cedesc1 as MarcaCliente,ModeloCliente .cedesc1 as ModeloCliente
        ',r.rbplac ,a.relugo ,a.relugd,a.retpago ,a.relat ,a.relong ,a.remefec ,a.reobs ,a.refact ,a.rehact ,a.reuact
        listEstCeldas.Add(New Modelos.Celda("renumi", True, "CODIGO VENTA", 120))
        listEstCeldas.Add(New Modelos.Celda("rencont", True, "N.CONTROL"))
        listEstCeldas.Add(New Modelos.Celda("refdoc", False))
        listEstCeldas.Add(New Modelos.Celda("modelo", False))
        listEstCeldas.Add(New Modelos.Celda("marca", False))
        listEstCeldas.Add(New Modelos.Celda("placa", False))
        listEstCeldas.Add(New Modelos.Celda("rekmsa", False))
        listEstCeldas.Add(New Modelos.Celda("rekmen", False))
        listEstCeldas.Add(New Modelos.Celda("rehorsa", False))
        listEstCeldas.Add(New Modelos.Celda("rehoren", False))
        listEstCeldas.Add(New Modelos.Celda("ransoc", False))
        listEstCeldas.Add(New Modelos.Celda("NombreCliente", True, "CLIENTE", 120))
        listEstCeldas.Add(New Modelos.Celda("NombreFactura", False))
        listEstCeldas.Add(New Modelos.Celda("ranit", False))
        listEstCeldas.Add(New Modelos.Celda("radir", False))
        listEstCeldas.Add(New Modelos.Celda("ratelf1", False))
        listEstCeldas.Add(New Modelos.Celda("MarcaCliente", False))
        listEstCeldas.Add(New Modelos.Celda("ModeloCliente", False))
        listEstCeldas.Add(New Modelos.Celda("rbplac", False))
        listEstCeldas.Add(New Modelos.Celda("relugo", False))
        listEstCeldas.Add(New Modelos.Celda("relugd", False))
        listEstCeldas.Add(New Modelos.Celda("retpago", False))
        listEstCeldas.Add(New Modelos.Celda("relat", False))
        listEstCeldas.Add(New Modelos.Celda("relong", False))
        listEstCeldas.Add(New Modelos.Celda("remefec", True, "TOTAL", 90))
        listEstCeldas.Add(New Modelos.Celda("reobs", False))
        listEstCeldas.Add(New Modelos.Celda("refact", False))
        listEstCeldas.Add(New Modelos.Celda("rehact", False))
        listEstCeldas.Add(New Modelos.Celda("reuact", False))

        listEstCeldas.Add(New Modelos.Celda("raci", False))
        listEstCeldas.Add(New Modelos.Celda("retcg2veh", False))
        listEstCeldas.Add(New Modelos.Celda("retcr11vehcli", False))
        listEstCeldas.Add(New Modelos.Celda("retcr1cli", False))
        listEstCeldas.Add(New Modelos.Celda("retp1empl", False))
        listEstCeldas.Add(New Modelos.Celda("nombreEmpleado", False))
        listEstCeldas.Add(New Modelos.Celda("rehorfin", False))
        Return listEstCeldas


    End Function
    Public Overrides Function _PMOGetTablaBuscador() As DataTable
        Dim dtBuscador As DataTable = L_prServicioVentaGruaGeneral()
        Return dtBuscador
    End Function
    Public Sub _prSeleccionarTipoPago(tipo As Integer)
        Select Case tipo
            Case 1

                checkGratis.CheckValue = True
                CheckCredito.CheckValue = False
                CheckEfectivo.CheckValue = False
                CheckCheque.CheckValue = False
            Case 2
                CheckCredito.CheckValue = True

                checkGratis.CheckValue = False
                CheckEfectivo.CheckValue = False
                CheckCheque.CheckValue = False
            Case 3
                CheckEfectivo.CheckValue = True

                checkGratis.CheckValue = False
                CheckCredito.CheckValue = False
                CheckCheque.CheckValue = False
            Case 4
                CheckCheque.CheckValue = True

                checkGratis.CheckValue = False
                CheckCredito.CheckValue = False
                CheckEfectivo.CheckValue = False

        End Select
    End Sub
    Public Function _fnObtenerTipoPago() As Integer

        If (checkGratis.Checked) Then
            Return 1
        End If

        If CheckCredito.Checked Then
            Return 2
        End If
        If CheckEfectivo.Checked Then
            Return 3
        End If
        If CheckCheque.Checked Then
            Return 4
        End If
        Return -1
    End Function

    Public Overrides Sub _PMOMostrarRegistro(_N As Integer)
        JGrM_Buscador.Row = _MPos
        ',a.remefec ,a.reobs ,a.refact ,a.rehact ,a.reuact
        With JGrM_Buscador
            tbCodigo.Text = .GetValue("renumi").ToString
            tbnumeroControl.Text = .GetValue("rencont").ToString
            tbFechaVenta.Value = IIf(IsDBNull(.GetValue("refdoc")), .GetValue("refact"), .GetValue("refdoc"))
            tbmodeloCliente.Text = .GetValue("ModeloCliente").ToString
            tbmarcaCLiente.Text = .GetValue("MarcaCliente").ToString
            tbFactura.Text = .GetValue("NombreFactura").ToString
            tbnit.Text = .GetValue("ranit").ToString
            tbmodeloEmpleado.Text = .GetValue("modelo").ToString
            tbplaca.Text = .GetValue("rbplac").ToString
            tbkmSalida.Text = .GetValue("rekmsa").ToString
            tbkmEntrada.Text = .GetValue("rekmen").ToString

            Dim ob1 As Object = .GetValue("rehorsa")
            Dim ob2 As Object = .GetValue("rehoren")
            If (IsDBNull(.GetValue("rehorsa")) Or .GetValue("rehorsa") = String.Empty Or .GetValue("rehorsa") = " ") Then
                tbHoraSalida.Text = ""
            Else
                If (.GetValue("rehorsa").ToString.Length > 5) Then
                    tbHoraSalida.Text = .GetValue("rehorsa").ToString.Substring(0, 5)
                Else
                    tbHoraSalida.Text = .GetValue("rehorsa")
                End If

            End If
            If (IsDBNull(.GetValue("rehoren")) Or .GetValue("rehoren") = String.Empty Or .GetValue("rehoren") = " ") Then
                tbHoraEntrada.Text = ""
            Else

                If (.GetValue("rehoren").ToString.Length > 5) Then
                    tbHoraEntrada.Text = .GetValue("rehoren").ToString.Substring(0, 5)
                Else
                    tbHoraEntrada.Text = .GetValue("rehoren")
                End If

            End If

            tbnsoc.Text = .GetValue("ransoc").ToString
            tbCliente.Text = .GetValue("NombreCliente").ToString
            tbdireccion.Text = .GetValue("radir").ToString
            tbtelefono.Text = .GetValue("ratelf1").ToString
            tbVehiculoAsignado.Text = .GetValue("placa").ToString
            tbLugarOrigen.Text = .GetValue("relugo").ToString
            tbLugarDestino.Text = .GetValue("relugd").ToString
            _prSeleccionarTipoPago(.GetValue("retpago"))
            _latitud = .GetValue("relat")
            _longitud = .GetValue("relong")
            tbobs.Text = .GetValue("reobs").ToString

            lbFecha.Text = CType(.GetValue("refact"), Date).ToString("dd/MM/yyyy")
            lbHora.Text = .GetValue("rehact").ToString
            lbUsuario.Text = .GetValue("reuact").ToString
            tbmarcaEmpleado.Text = .GetValue("marca").ToString
            tbChofer.Text = .GetValue("nombreEmpleado").ToString

            'listEstCeldas.Add(New Modelos.Celda("retcg2veh", False))
            'listEstCeldas.Add(New Modelos.Celda("retcr11vehcli", False))
            'listEstCeldas.Add(New Modelos.Celda("retcr1cli", False))
            'listEstCeldas.Add(New Modelos.Celda("retp1empl", False))

            tbnumiVehiculoEmpleado.Text = .GetValue("retcg2veh").ToString
            tbvehiculoCliente.Text = .GetValue("retcr11vehcli").ToString
            tbnumiCliente.Text = .GetValue("retcr1cli").ToString
            tbnumiEmpleado.Text = .GetValue("retp1empl").ToString
            ''  tbTiempoUtilizado.Text = .GetValue("rehorfin").ToString

            TablaImagenes = L_prCargarImagenes(.GetValue("renumi"))
            _prCargarImagen()
        End With


        _prCargarGridDetalle(tbCodigo.Text)
        _prVerificarSocio()
        _dibujarUbicacion(JGrM_Buscador.GetValue("NombreCliente").ToString, JGrM_Buscador.GetValue("raci").ToString)
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
        For i As Integer = 0 To CType(grdetalle.DataSource, DataTable).Rows.Count - 1
            If (CType(grdetalle.DataSource, DataTable).Rows(i).Item("est") = True) Then
                Return True
            End If

        Next
        Return False
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
        Dim tot As Double = grdetalle.GetTotal(grdetalle.RootTable.Columns("total"), AggregateFunction.Sum)
        Dim res As Boolean
        Dim remol As remolque = New remolque(tbnit.Text, tbFactura.Text, tbdireccion.Text, tbtelefono.Text)
        res = L_prServicioVentaGruaGrabar(tbCodigo.Text, tbnumiCliente.Text, tbvehiculoCliente.Text, tbnumiVehiculoEmpleado.Text, tbnumiEmpleado.Text, tbnumeroControl.Text, tbFechaVenta.Value.ToString("yyyy/MM/dd"), tbkmSalida.Value, tbkmEntrada.Value, tbHoraSalida.Text, tbHoraEntrada.Text, _fnObtenerTipoPago(), _latitud, _longitud, tot, tbLugarOrigen.Text, tbLugarDestino.Text, tbobs.Text, CType(grdetalle.DataSource, DataTable), tbTiempoUtilizado.Text, TablaGeneralServicios, remol)
        If res Then
            '_prCrearCarpetaImagenes("Venta_" + tbCodigo.Text)
            TablaGeneralServicios = L_prObtenerHistorialdeServiciosPoliticaRemolque(-1, 0)
            '_prGuardarImagenes(RutaGlobal + "\Imagenes\Imagenes VentaRemolque\" + "Venta_" + tbCodigo.Text + "\")
            ToastNotification.Show(Me, "Codigo de Servicio Venta ".ToUpper + tbCodigo.Text + " Grabado con Exito.".ToUpper, My.Resources.GRABACION_EXITOSA, 5000, eToastGlowColor.Green, eToastPosition.TopCenter)
            _prMesajeImprimi(tbCodigo.Text)
        End If
        Return res
    End Function
    Public Sub _prGuardarImagenes(_ruta As String)
        panelA.Controls.Clear()


        For i As Integer = 0 To TablaImagenes.Rows.Count - 1 Step 1
            Dim estado As Integer = TablaImagenes.Rows(i).Item("estado")
            If (estado = 0) Then

                Dim bm As Bitmap = Nothing
                Dim by As Byte() = TablaImagenes.Rows(i).Item("img")
                Dim ms As New MemoryStream(by)
                bm = New Bitmap(ms)
                Try
                    bm.Save(_ruta + TablaImagenes.Rows(i).Item("rgima"), System.Drawing.Imaging.ImageFormat.Jpeg)
                Catch ex As Exception

                End Try




            End If
            If (estado = -1) Then
                Try
                    Me.pbImgProdu.Image.Dispose()
                    Me.pbImgProdu.Image = Nothing
                    Application.DoEvents()
                    TablaImagenes.Rows(i).Item("img") = Nothing



                    If (File.Exists(_ruta + TablaImagenes.Rows(i).Item("rgima"))) Then
                        My.Computer.FileSystem.DeleteFile(_ruta + TablaImagenes.Rows(i).Item("rgima"))
                    End If

                Catch ex As Exception

                End Try
            End If
        Next
    End Sub
    Public Overrides Function _PMOModificarRegistro() As Boolean
        Dim res As Boolean
        Dim tot As Double = grdetalle.GetTotal(grdetalle.RootTable.Columns("total"), AggregateFunction.Sum)
        Dim remol As remolque = New remolque(tbnit.Text, tbFactura.Text, tbdireccion.Text, tbtelefono.Text)
        res = L_prServicioVentaGruaModificar(tbCodigo.Text, tbnumiCliente.Text, tbvehiculoCliente.Text, tbnumiVehiculoEmpleado.Text, tbnumiEmpleado.Text, tbnumeroControl.Text, tbFechaVenta.Value.ToString("yyyy/MM/dd"), tbkmSalida.Value, tbkmEntrada.Value, tbHoraSalida.Text, tbHoraEntrada.Text, _fnObtenerTipoPago(), _latitud, _longitud, tot, tbLugarOrigen.Text, tbLugarDestino.Text, tbobs.Text, CType(grdetalle.DataSource, DataTable), tbTiempoUtilizado.Text, TablaGeneralServicios, remol)
        If res Then
            '_prCrearCarpetaImagenes("Venta_" + tbCodigo.Text)

            TablaGeneralServicios = L_prObtenerHistorialdeServiciosPoliticaRemolque(-1, 0)
            '_prGuardarImagenes(RutaGlobal + "\Imagenes\Imagenes VentaRemolque\" + "Venta_" + tbCodigo.Text + "\")
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



    Public Sub _VerificarPagoAlDia(_nsoc As Integer)
        If (PagoAlDia = False And _nsoc > 0) Then
            MsgBox("El Socio Esta Sin Pagos Al Dia Por Lo Tanto El Sistema No Aplicara Ningun Tipo De Descuento y Solo Hara Su Servicios Como Cliente!", MsgBoxStyle.Exclamation, "Error")
        End If
    End Sub




    Private Sub JGrM_Buscador_DoubleClick(sender As Object, e As EventArgs) Handles JGrM_Buscador.DoubleClick
        _prVolverAtras()

    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        tbplaca.Focus()

    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        tbplaca.Focus()


    End Sub







    Private Sub tbVehiculo_KeyDown_1(sender As Object, e As KeyEventArgs) Handles tbplaca.KeyDown
        If (Not _fnVisualizarRegistros() And tbnumeroControl.ReadOnly = False) Then
            If e.KeyData = Keys.Control + Keys.Enter Then
                If (tbplaca.Text <> String.Empty) Then

                    If (grVentasPendientes.RowCount > 0) Then
                        grVentasPendientes.Row = 0

                        tbCliente.Text = grVentasPendientes.GetValue("nombre")
                        tbnumiCliente.Text = grVentasPendientes.GetValue("ranumi")
                        tbvehiculoCliente.Text = grVentasPendientes.GetValue("rblin")
                        tbplaca.Text = grVentasPendientes.GetValue("rbplac")
                        tbmarcaCLiente.Text = grVentasPendientes.GetValue("marca")
                        tbmodeloCliente.Text = grVentasPendientes.GetValue("modelo")
                        tbFactura.Text = grVentasPendientes.GetValue("rafacnom")
                        tbnit.Text = grVentasPendientes.GetValue("ranit")
                        Dim nsoc As Integer = grVentasPendientes.GetValue("ransoc")
                        tbdireccion.Text = grVentasPendientes.GetValue("radir")
                        tbtelefono.Text = grVentasPendientes.GetValue("ratelf1")
                        Dim HonorarioMeritorio As Integer = grVentasPendientes.GetValue("cftsoc")
                        If (nsoc > 0) Then
                            tbClienteSocio.Value = False
                            Dim FechaPago As DataTable = L_prObtenerUltimoPagoSocio(nsoc)
                            lbFechaPago.Visible = True
                            tbFechaPago.Visible = True
                            If (HonorarioMeritorio = 2 Or HonorarioMeritorio = 3) Then
                                tbFechaPago.BackColor = Color.White
                                MEP.SetError(tbFechaPago, "")
                                MHighlighterFocus.UpdateHighlights()
                                lbUltimaPago.Visible = True
                                lbUltimaPago.Text = "HABILITADO"
                                lbUltimaPago.ForeColor = Color.DarkSlateGray
                                PagoAlDia = True
                                _prCrearTablaPoliticajanus()
                                SuperTabItem4.Visible = True
                                SuperTabControl1.SelectedTabIndex = 3
                            Else

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
                                        SuperTabItem4.Visible = True
                                        SuperTabControl1.SelectedTabIndex = 3
                                        _prCrearTablaPoliticajanus()
                                    Else
                                        PagoAlDia = False
                                        MEP.SetError(tbFechaPago, "Socio esta con deudas atrazas!".ToUpper)
                                        MHighlighterFocus.UpdateHighlights()
                                        tbFechaPago.BackColor = Color.Red
                                        lbUltimaPago.Visible = True
                                        lbUltimaPago.Text = "INHABILITADO"
                                        lbUltimaPago.ForeColor = Color.Red
                                        SuperTabItem4.Visible = False
                                        SuperTabControl1.SelectedTabIndex = 0
                                    End If
                                Else
                                    PagoAlDia = False
                                    MEP.SetError(tbFechaPago, "Socio esta con deudas atrazas!".ToUpper)
                                    MHighlighterFocus.UpdateHighlights()
                                    tbFechaPago.BackColor = Color.Red
                                    lbUltimaPago.Visible = True
                                    lbUltimaPago.Text = "INHABILITADO"
                                    lbUltimaPago.ForeColor = Color.Red
                                    SuperTabItem4.Visible = False
                                    SuperTabControl1.SelectedTabIndex = 0
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
                                SuperTabItem4.Visible = False
                                SuperTabControl1.SelectedTabIndex = 0
                            End If
                        End If

                    Else
                            tbClienteSocio.Value = True
                            tbFechaPago.Text = ""
                            lbFechaPago.Visible = False
                            tbFechaPago.Visible = False
                            lbUltimaPago.Visible = False
                            SuperTabItem4.Visible = False
                            SuperTabControl1.SelectedTabIndex = 0
                        End If

                        _VerificarPagoAlDia(nsoc)

                    End If
                    ''Aqui
                End If

            End If
            If (e.KeyData = Keys.Enter) Then
                If (tbvehiculoCliente.Text = 0) Then
                    tbplaca.Focus()

                    ToastNotification.Show(Me, "           Antes De Continuar Por favor Seleccione un Vehiculo !!             ", My.Resources.WARNING, 4000, eToastGlowColor.Red, eToastPosition.TopCenter)
                    Return

                End If
            End If
        End If
    End Sub




    Private Sub ButtonX3_Click(sender As Object, e As EventArgs) Handles btnAnadir.Click

        Dim frm As New F_ClienteNuevoRemolque
        Dim dt As DataTable
        frm.placaV = tbplaca.Text
        frm.ShowDialog()
        Dim placa As String = frm.placaV

        If (frm.Cliente = True) Then ''Aqui Consulto si se inserto un nuevo Cliente cargo sus datos del nuevo cliente insertado ,a.radir ,a.ratelf1

            dt = L_prServicioVentaAyudaVehiculoRemolque(placa)
            If (dt.Rows.Count > 0) Then
                tbCliente.Text = dt.Rows(0).Item("nombre")
                tbnumiCliente.Text = dt.Rows(0).Item("ranumi")
                tbvehiculoCliente.Text = dt.Rows(0).Item("rblin")
                tbmarcaCLiente.Text = dt.Rows(0).Item("marca")
                tbmodeloCliente.Text = dt.Rows(0).Item("modelo")
                tbtelefono.Text = dt.Rows(0).Item("ratelf1")
                tbdireccion.Text = dt.Rows(0).Item("radir")
                tbplaca.Text = placa
                TableCliente = True
                TableCliente = False
                Cliente = False
                grdetalle.Focus()
                placa = ""
                tbClienteSocio.Value = True
                lbFechaPago.Visible = False
                tbFechaPago.Text = ""
                tbFechaPago.Visible = False
                If (dt.Rows(0).Item("radir") = String.Empty) Then
                    tbdireccion.Clear()

                End If
                If (dt.Rows(0).Item("ratelf1") = String.Empty) Then
                    tbtelefono.Clear()

                End If
                If (_fnActionNuevo()) Then


                End If


            End If
        End If
    End Sub



    Private Sub tbVehiculo_TextChanged(sender As Object, e As EventArgs) Handles tbplaca.TextChanged
        If (_fnActionNuevo() Or tbplaca.ReadOnly = False) Then
            If (tbplaca.Text = String.Empty) Then
                tbCliente.Text = ""
                tbnumiCliente.Text = 0
                tbClienteSocio.Value = True
                lbFechaPago.Visible = False
                tbFechaPago.Text = ""
                tbFechaPago.Visible = False
                tbvehiculoCliente.Text = 0
                lbUltimaPago.Visible = False
                tbplaca.Text = ""
                tbmarcaCLiente.Text = ""
                tbmodeloCliente.Text = ""
                tbFactura.Text = ""
                tbnit.Text = ""
                tbnsoc.Text = ""
                tbdireccion.Text = ""
                tbtelefono.Text = ""
                If (_fnActionNuevo()) Then

                End If
                grVentasPendientes.RemoveFilters()


            Else
                If (Not IsNothing(grVentasPendientes.DataSource) And Not IsNothing(grdetalle.DataSource)) Then
                    grVentasPendientes.RootTable.ApplyFilter(New Janus.Windows.GridEX.GridEXFilterCondition(grVentasPendientes.RootTable.Columns("rbplac"), Janus.Windows.GridEX.ConditionOperator.Contains, tbplaca.Text))

                End If

            End If
        End If

    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        _prImprimir(tbCodigo.Text)
    End Sub

    Private Sub grVentasPendientes_KeyDown(sender As Object, e As KeyEventArgs) Handles grVentasPendientes.KeyDown

        If (_fnActionNuevo() Or tbplaca.ReadOnly = False) Then
            If (e.KeyData = Keys.Enter) Then
                If (grVentasPendientes.RowCount > 0) Then
                    tbCliente.Text = grVentasPendientes.GetValue("nombre")
                    tbnumiCliente.Text = grVentasPendientes.GetValue("ranumi")
                    tbvehiculoCliente.Text = grVentasPendientes.GetValue("rblin")
                    tbplaca.Text = grVentasPendientes.GetValue("rbplac")
                    tbmarcaCLiente.Text = grVentasPendientes.GetValue("marca")
                    tbmodeloCliente.Text = grVentasPendientes.GetValue("modelo")
                    tbFactura.Text = grVentasPendientes.GetValue("rafacnom")
                    tbnit.Text = grVentasPendientes.GetValue("ranit")
                    tbdireccion.Text = grVentasPendientes.GetValue("radir")
                    tbtelefono.Text = grVentasPendientes.GetValue("ratelf1")
                    tbnsoc.Text = grVentasPendientes.GetValue("ransoc")
                    Dim HonorarioMeritorio As Integer = grVentasPendientes.GetValue("cftsoc")
                    Dim nsoc As Integer = grVentasPendientes.GetValue("ransoc")
                    If (nsoc > 0) Then
                        tbClienteSocio.Value = False
                        Dim FechaPago As DataTable = L_prObtenerUltimoPagoSocio(nsoc)
                        lbFechaPago.Visible = True
                        tbFechaPago.Visible = True
                        If (HonorarioMeritorio = 2 Or HonorarioMeritorio = 3) Then
                            tbFechaPago.BackColor = Color.White
                            MEP.SetError(tbFechaPago, "")
                            MHighlighterFocus.UpdateHighlights()
                            lbUltimaPago.Visible = True
                            lbUltimaPago.Text = "HABILITADO"
                            lbUltimaPago.ForeColor = Color.DarkSlateGray
                            PagoAlDia = True
                            _prCrearTablaPoliticajanus()
                            SuperTabItem4.Visible = True
                            SuperTabControl1.SelectedTabIndex = 3
                        Else

                            If (FechaPago.Rows.Count > 0) Then

                            tbFechaPago.Text = "Mes: " + FechaPago.Rows(0).Item("semes").ToString + " Año: " + FechaPago.Rows(0).Item("seano").ToString
                            If (Now.Year = FechaPago.Rows(0).Item("seano") Or Now.Year - 1 = FechaPago.Rows(0).Item("seano")) Then
                                ''   Dim MesSitema As Integer = FechaPago.Rows(0).Item("semes")
                                Dim mora As Integer = FechaPago.Rows(0).Item("mora")

                                Dim FechaDePago As Date = New Date(FechaPago.Rows(0).Item("seano"), FechaPago.Rows(0).Item("semes"), 1)
                                Dim fecha As Date = Date.Now.AddMonths(-mora)
                                fecha = fecha.AddDays(-(fecha.Day) + 1)
                                If ((fecha <= FechaDePago)) Then

                                    'If (((Now.Month - mora) <= MesSitema)) Then

                                    tbFechaPago.BackColor = Color.White
                                    MEP.SetError(tbFechaPago, "")
                                    MHighlighterFocus.UpdateHighlights()
                                    lbUltimaPago.Visible = True
                                    lbUltimaPago.Text = "HABILITADO"
                                    lbUltimaPago.ForeColor = Color.DarkSlateGray
                                    PagoAlDia = True
                                    _prCrearTablaPoliticajanus()
                                    SuperTabItem4.Visible = True
                                    SuperTabControl1.SelectedTabIndex = 3
                                Else

                                    MEP.SetError(tbFechaPago, "Socio esta con deudas atrazas!".ToUpper)
                                    MHighlighterFocus.UpdateHighlights()
                                    tbFechaPago.BackColor = Color.Red
                                    lbUltimaPago.Visible = True
                                    lbUltimaPago.Text = "INHABILITADO"
                                    lbUltimaPago.ForeColor = Color.Red
                                    PagoAlDia = False
                                    SuperTabItem4.Visible = False
                                    SuperTabControl1.SelectedTabIndex = 0
                                End If

                            Else
                                MEP.SetError(tbFechaPago, "Socio esta con deudas atrazas!".ToUpper)
                                MHighlighterFocus.UpdateHighlights()
                                tbFechaPago.BackColor = Color.Red
                                lbUltimaPago.Visible = True
                                lbUltimaPago.Text = "INHABILITADO"
                                lbUltimaPago.ForeColor = Color.Red
                                PagoAlDia = False
                                SuperTabItem4.Visible = False
                                SuperTabControl1.SelectedTabIndex = 0
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
                            SuperTabItem4.Visible = False
                            SuperTabControl1.SelectedTabIndex = 0
                        End If

                    End If

                Else
                        tbClienteSocio.Value = True
                        tbFechaPago.Text = ""
                        lbFechaPago.Visible = False
                        tbFechaPago.Visible = False
                        lbUltimaPago.Visible = False
                        SuperTabItem4.Visible = False
                        SuperTabControl1.SelectedTabIndex = 0
                    End If


                    If (_fnActionNuevo()) Then

                    End If
                    _VerificarPagoAlDia(nsoc)


                End If




            End If
        End If

    End Sub
#End Region

    Private Sub grDetalle_FormattingRow(sender As Object, e As RowLoadEventArgs)


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

    Private Sub tbnumiVehiculo_TextChanged(sender As Object, e As EventArgs) Handles tbnumiVehiculoEmpleado.TextChanged

    End Sub

    Private Sub LabelX2_Click(sender As Object, e As EventArgs) Handles LabelX2.Click

    End Sub

    Private Sub tbCliente_TextChanged(sender As Object, e As EventArgs) Handles tbCliente.TextChanged

    End Sub

    Private Sub tbnumiCliente_TextChanged(sender As Object, e As EventArgs) Handles tbnumiCliente.TextChanged

    End Sub

    Private Sub LabelX8_Click(sender As Object, e As EventArgs) Handles LabelX8.Click

    End Sub

    Private Sub FechaVenta_Click(sender As Object, e As EventArgs) Handles tbFechaVenta.Click

    End Sub

    Private Sub tbobs_TextChanged(sender As Object, e As EventArgs) Handles tbobs.TextChanged

    End Sub

    Private Sub LabelX3_Click(sender As Object, e As EventArgs) Handles LabelX3.Click

    End Sub

    Private Sub tbVehiculo_Click(sender As Object, e As EventArgs) Handles tbplaca.Click
        SuperTabControl1.SelectedTabIndex = 0
        tbplaca.Focus()

    End Sub


    Private Sub tbVehiculoAsignado_KeyDown(sender As Object, e As KeyEventArgs) Handles tbVehiculoAsignado.KeyDown
        If (Not _fnVisualizarRegistros() And tbnumeroControl.ReadOnly = False) Then
            If e.KeyData = Keys.Control + Keys.Enter Then

                'grabar horario
                Dim frmAyuda As Modelos.ModeloAyuda

                Dim dt As DataTable
                ''Aqui puse estatico la libreria de CLiente Lavadero 14 , 1
                dt = L_prRemolqueVehiculo()
                'a.gcnumi ,a.gcid,marca.cedesc1 as marca,modelo .cedesc1 as modelo ,Concat(personal .panom ,' ',personal .paape ) as nombre

                Dim listEstCeldas As New List(Of Modelos.Celda)
                listEstCeldas.Add(New Modelos.Celda("gcnumi", True, "ID", 50))
                listEstCeldas.Add(New Modelos.Celda("gcper", False))
                listEstCeldas.Add(New Modelos.Celda("gcid", True, "PLACA", 90))
                listEstCeldas.Add(New Modelos.Celda("marca", True, "MARCA", 120))
                listEstCeldas.Add(New Modelos.Celda("modelo", True, "MODELO", 120))
                listEstCeldas.Add(New Modelos.Celda("nombre", True, "Personal Asignado", 200))

                frmAyuda = New Modelos.ModeloAyuda(50, 250, dt, "ASIGNE VEHICULO PARA EL SERVICIO".ToUpper, listEstCeldas)
                frmAyuda.ShowDialog()


                If frmAyuda.seleccionado = True Then

                    Dim nombre As String = frmAyuda.filaSelect.Cells("nombre").Value
                    Dim numiEmpleado As String = frmAyuda.filaSelect.Cells("gcper").Value
                    Dim numiVehiculo As String = frmAyuda.filaSelect.Cells("gcnumi").Value
                    tbnumiEmpleado.Text = numiEmpleado
                    tbnumiVehiculoEmpleado.Text = numiVehiculo
                    tbChofer.Text = nombre
                    tbmarcaEmpleado.Text = frmAyuda.filaSelect.Cells("marca").Value
                    tbmodeloEmpleado.Text = frmAyuda.filaSelect.Cells("modelo").Value
                    tbVehiculoAsignado.Text = frmAyuda.filaSelect.Cells("gcid").Value
                End If
                'tbCliente.Text = nombre
                'tbnumiCliente.Text = numi


            End If
        End If


    End Sub

    Private Sub tbChofer_KeyDown(sender As Object, e As KeyEventArgs) Handles tbChofer.KeyDown
        If (Not _fnVisualizarRegistros() And tbnumeroControl.ReadOnly = False) Then
            If e.KeyData = Keys.Control + Keys.Enter Then

                'grabar horario
                Dim frmAyuda As Modelos.ModeloAyuda

                Dim dt As DataTable

                dt = L_prRemolqueObtenerPersonal()
                'personal.panumi ,Concat(personal .panom ,' ',personal .paape ) as nombre,personal .paci

                Dim listEstCeldas As New List(Of Modelos.Celda)
                listEstCeldas.Add(New Modelos.Celda("panumi", True, "ID", 50))
                listEstCeldas.Add(New Modelos.Celda("nombre", True, "PERSONAL", 200))
                listEstCeldas.Add(New Modelos.Celda("paci", True, "CI", 120))

                frmAyuda = New Modelos.ModeloAyuda(50, 250, dt, "ASIGNE PERSONAL".ToUpper, listEstCeldas)
                frmAyuda.ShowDialog()


                If frmAyuda.seleccionado = True Then

                    tbnumiEmpleado.Text = frmAyuda.filaSelect.Cells("panumi").Value

                    tbChofer.Text = frmAyuda.filaSelect.Cells("nombre").Value

                End If
                'tbCliente.Text = nombre
                'tbnumiCliente.Text = numi


            End If
        End If
    End Sub

    Private Sub tbkmSalida_ValueChanged(sender As Object, e As EventArgs) Handles tbkmSalida.ValueChanged
        If (tbkmSalida.Text <> String.Empty) Then
            If (tbkmEntrada.Text <> String.Empty) Then

                tbTotalKilomentraje.Text = tbkmEntrada.Text - tbkmSalida.Text
            Else
                tbTotalKilomentraje.Text = tbkmSalida.Text
            End If


        Else
            If (tbkmEntrada.Text <> String.Empty) Then ''Aqui pregunto si esta vacio el km entrada
                tbTotalKilomentraje.Text = tbkmEntrada.Text

            Else
                tbTotalKilomentraje.Text = 0

            End If
        End If
    End Sub

    Private Sub tbkmEntrada_ValueChanged(sender As Object, e As EventArgs) Handles tbkmEntrada.ValueChanged
        If (tbkmEntrada.Text <> String.Empty) Then
            If (tbkmSalida.Text <> String.Empty) Then

                tbTotalKilomentraje.Text = tbkmEntrada.Text - tbkmSalida.Text
            Else
                tbTotalKilomentraje.Text = tbkmEntrada.Text
            End If


        Else
            If (tbkmSalida.Text <> String.Empty) Then ''Aqui pregunto si esta vacio el km entrada
                tbTotalKilomentraje.Text = tbkmSalida.Text

            Else
                tbTotalKilomentraje.Text = 0

            End If
        End If
    End Sub

    Private Sub grdetalle_EditingCell(sender As Object, e As EditingCellEventArgs) Handles grdetalle.EditingCell
        If (Not _fnVisualizarRegistros()) Then
            'Habilitar solo las columnas de Precio, %, Monto y Observación
            If (e.Column.Index = grdetalle.RootTable.Columns("rfprec").Index) Then
                e.Cancel = False
            Else
                e.Cancel = True
            End If
        Else
            e.Cancel = True
        End If
    End Sub
    Public Sub _cambiarEstadoPolitica(est As Integer, numi As Integer)
        For i As Integer = 0 To TablaGeneralServicios.Rows.Count - 1 Step 1

            If (TablaGeneralServicios.Rows(i).Item("rhtce04serv") = numi) Then
                If (TablaGeneralServicios.Rows(i).Item("rhnumi") = 0) Then
                    TablaGeneralServicios.Rows(i).Item("estado") = est
                End If

            End If
        Next

    End Sub
    Private Sub grdetalle_CellValueChanged(sender As Object, e As ColumnActionEventArgs) Handles grdetalle.CellValueChanged
        '' grDetalle.GetRow(grDetalle.Row).BeginEdit()

        ''Dim rowIndex As Integer = grDetalle.CurrentRow.RowIndex
        Dim rowIndex As Integer = grdetalle.Row
        'Columna de Precio Venta
        If (Not grdetalle.GetValue("rfprec").ToString = String.Empty) Then


            If (e.Column.Index = grdetalle.RootTable.Columns("rfprec").Index) Then
                Dim ob As Object = grdetalle.GetValue("rfprec")

                If (Not IsNumeric(grdetalle.GetValue("rfprec"))) Then

                    grdetalle.SetValue("rfprec", 0)
                    grdetalle.SetValue("est", False)
                    grdetalle.SetValue("total", 0)
                    Dim estado As Integer = grdetalle.GetValue("estado")
                    If (estado = 1 Or estado = 2) Then
                        grdetalle.SetValue("estado", -1)

                    End If
                    If (grdetalle.GetValue("rfpdesc") > 0) Then
                        _cambiarEstadoPolitica(-1, grdetalle.GetValue("rfTCE04Serv"))

                    End If

                    'grDetalle.GetRow(rowIndex).Cells("cant").Value = 1
                    ''  grDetalle.CurrentRow.Cells.Item("cant").Value = 1




                Else
                    If (grdetalle.GetValue("rfprec") > 0) Then
                        grdetalle.SetValue("est", True)

                        Dim est As Integer = grdetalle.GetValue("estado")
                        If (est = 1 Or est = -1) Then
                            grdetalle.SetValue("estado", 2)

                        End If
                        If (grdetalle.GetValue("rfpdesc") > 0) Then
                            _cambiarEstadoPolitica(0, grdetalle.GetValue("rfTCE04Serv"))
                        End If
                        Dim montodesc As Double = (grdetalle.GetValue("rfprec") * (grdetalle.GetValue("rfpdesc") / 100))
                        grdetalle.SetValue("rfmdesc", montodesc)
                        grdetalle.SetValue("total", grdetalle.GetValue("rfprec") - montodesc)


                    Else
                        grdetalle.SetValue("est", False)
                        grdetalle.SetValue("total", 0)
                        CType(grdetalle.DataSource, DataTable).Rows(rowIndex).Item("rfprec") = 0
                        Dim estado As Integer = grdetalle.GetValue("estado")
                        If (estado = 1 Or estado = 2) Then
                            grdetalle.SetValue("estado", -1)

                        End If
                        If (grdetalle.GetValue("rfpdesc") > 0) Then
                            _cambiarEstadoPolitica(-1, grdetalle.GetValue("rfTCE04Serv"))

                        End If
                    End If
                End If
            End If
        End If




    End Sub

    Private Sub grdetalle_CellUpdated(sender As Object, e As ColumnActionEventArgs) Handles grdetalle.CellUpdated
        Dim rowIndex As Integer = grdetalle.Row
        'Columna de Precio Venta
        If (grdetalle.GetValue("rfprec").ToString = String.Empty) Then

            grdetalle.SetValue("rfprec", 0)
            grdetalle.SetValue("est", False)
            Dim estado As Integer = grdetalle.GetValue("estado")
            If (estado = 1 Or estado = 2) Then
                grdetalle.SetValue("estado", -1)

            End If
        End If

    End Sub

    Private Sub checkGratis_CheckValueChanged(sender As Object, e As EventArgs) Handles checkGratis.CheckValueChanged
        If (checkGratis.Checked) Then
            CheckEfectivo.CheckValue = False
            CheckCredito.CheckValue = False
            CheckCheque.CheckValue = False
        Else

        End If
    End Sub

    Private Sub CheckCredito_CheckValueChanged(sender As Object, e As EventArgs) Handles CheckCredito.CheckValueChanged
        If (CheckCredito.Checked) Then
            CheckEfectivo.CheckValue = False
            checkGratis.CheckValue = False
            CheckCheque.CheckValue = False
        Else

        End If
    End Sub

    Private Sub CheckEfectivo_CheckValueChanged(sender As Object, e As EventArgs) Handles CheckEfectivo.CheckValueChanged
        If (CheckEfectivo.Checked) Then
            CheckCredito.CheckValue = False
            checkGratis.CheckValue = False
            CheckCheque.CheckValue = False
        Else

        End If
    End Sub

    Private Sub CheckCheque_CheckValueChanged(sender As Object, e As EventArgs) Handles CheckCheque.CheckValueChanged
        If (CheckCheque.Checked) Then
            CheckCredito.CheckValue = False
            checkGratis.CheckValue = False
            CheckEfectivo.CheckValue = False
        Else

        End If
    End Sub
    Public Sub _prCargarImagen()
        panelA.Controls.Clear()
        pbImgProdu.Image = Nothing
        posImg = -1

        Dim i As Integer = 0
        For Each fila As DataRow In TablaImagenes.Rows
            Dim elemImg As UCItemImg = New UCItemImg
            Dim rutImg = fila.Item("rgima").ToString
            Dim estado As Integer = fila.Item("estado")

            If (estado = 0) Then
                elemImg.pbJpg.SizeMode = PictureBoxSizeMode.StretchImage
                Dim bm As Bitmap = Nothing
                Dim by As Byte() = fila.Item("img")
                Dim ms As New MemoryStream(by)
                bm = New Bitmap(ms)


                elemImg.pbJpg.Image = bm

                pbImgProdu.SizeMode = PictureBoxSizeMode.StretchImage
                pbImgProdu.Image = bm
                elemImg.pbJpg.Tag = i
                elemImg.Dock = DockStyle.Top
                pbImgProdu.Tag = i
                AddHandler elemImg.pbJpg.MouseEnter, AddressOf pbImg_MouseEnter

                panelA.Controls.Add(elemImg)
            Else
                If (estado = 1) Then
                    If (File.Exists(RutaGlobal + "\Imagenes\Imagenes VentaRemolque\" + "Venta_" + tbCodigo.Text + rutImg)) Then
                        Dim bm As Bitmap = New Bitmap(RutaGlobal + "\Imagenes\Imagenes VentaRemolque\" + "Venta_" + tbCodigo.Text + rutImg)
                        elemImg.pbJpg.SizeMode = PictureBoxSizeMode.StretchImage
                        elemImg.pbJpg.Image = bm
                        pbImgProdu.SizeMode = PictureBoxSizeMode.StretchImage
                        pbImgProdu.Image = bm
                        elemImg.pbJpg.Tag = i
                        elemImg.Dock = DockStyle.Top
                        pbImgProdu.Tag = i
                        AddHandler elemImg.pbJpg.MouseEnter, AddressOf pbImg_MouseEnter

                        panelA.Controls.Add(elemImg)
                    End If

                End If
            End If




            i += 1
        Next
        If (Modificar = True) Then
            Dim elemImgAdd As UCItemImg = New UCItemImg

            Dim imgadd As Bitmap = New Bitmap(My.Resources.addimage)
            elemImgAdd.pbJpg.SizeMode = PictureBoxSizeMode.StretchImage
            elemImgAdd.pbJpg.Image = imgadd
            elemImgAdd.Dock = DockStyle.Top
            AddHandler elemImgAdd.pbJpg.Click, AddressOf pbJpg_MouseClick
            panelA.Controls.Add(elemImgAdd)
        End If
        If (Modificar = True And _fnObtenerNumeroFilasActivas() < 0) Then
            btDeleteImg.Visible = False
        Else
            If (Modificar = True) Then
                btDeleteImg.Visible = True
            End If


        End If
    End Sub
    Public Function _fnObtenerNumeroFilasActivas() As Integer
        Dim n As Integer = -1
        For i As Integer = 0 To TablaImagenes.Rows.Count - 1 Step 1
            Dim estado As Integer = TablaImagenes.Rows(i).Item("estado")
            If (estado = 0 Or estado = 1) Then
                n += 1

            End If
        Next
        Return n
    End Function
    Private Sub pbJpg_MouseClick(sender As Object, e As EventArgs)

        _fnCopiarImagenRutaDefinida()
        _prCargarImagen()

    End Sub

    Private Function _fnCopiarImagenRutaDefinida() As String
        'copio la imagen en la carpeta del sistema

        Dim file As New OpenFileDialog()
        file.Filter = "Ficheros JPG o JPEG o PNG|*.jpg;*.jpeg;*.png" &
                      "|Ficheros GIF|*.gif" &
                      "|Ficheros BMP|*.bmp" &
                      "|Ficheros PNG|*.png" &
                      "|Ficheros TIFF|*.tif"
        If file.ShowDialog() = DialogResult.OK Then
            Dim ruta As String = file.FileName
            Dim nombre As String = ""

            If file.CheckFileExists = True Then
                Dim img As New Bitmap(New Bitmap(ruta))
                Dim a As Object = file.GetType.ToString

                Dim da As String = Str(Now.Day).Trim + Str(Now.Month).Trim + Str(Now.Year).Trim + Str(Now.Hour) + Str(Now.Minute) + Str(Now.Second)

                nombre = "\Imagen_" + da + ".jpg".Trim


                If (_fnActionNuevo()) Then
                    Dim mstream = New MemoryStream()

                    img.Save(mstream, System.Drawing.Imaging.ImageFormat.Jpeg)

                    TablaImagenes.Rows.Add(0, 0, nombre, mstream.ToArray(), 0)
                    mstream.Dispose()

                Else
                    Dim mstream = New MemoryStream()

                    img.Save(mstream, System.Drawing.Imaging.ImageFormat.Jpeg)
                    TablaImagenes.Rows.Add(0, tbCodigo.Text, nombre, mstream.ToArray(), 0)
                    mstream.Dispose()

                End If

                'img.Save(RutaTemporal + nombre, System.Drawing.Imaging.ImageFormat.Jpeg)




            End If
            Return nombre
        End If

        Return "default.jpg"
    End Function
    Private Sub ELIMINARToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub
    Private Sub pbImg_MouseEnter(sender As Object, e As EventArgs)
        Dim pb As PictureBox = CType(sender, PictureBox)
        pbImgProdu.Image = pb.Image
        pbImgProdu.Tag = pb.Tag

    End Sub

    Private Sub pbImgProdu_MouseClick(sender As Object, e As MouseEventArgs) Handles pbImgProdu.MouseClick
        pbImgProdu.Size = New System.Drawing.Size(pbImgProdu.Width + e.Delta / 1, pbImgProdu.Height + e.Delta / 1)
        pbImgProdu.Location = New Point(Control.MousePosition.X - pbImgProdu.Width / 2, Control.MousePosition.Y - pbImgProdu.Height / 2)

    End Sub


    Private Sub btDeleteImg_Click(sender As Object, e As EventArgs) Handles btDeleteImg.Click
        Dim pos As Integer = CType(pbImgProdu.Tag, Integer)

        If (pos >= 0) Then
            TablaImagenes.Rows(pos).Item("estado") = -1
            _prCargarImagen()
        End If

    End Sub
    Public Sub _prCrearTablaPoliticajanus()
        Dim TableServicioPolitica As DataTable = L_prObtenerServicioPoliticaRemolque()
        Dim GrPoliticaTabla As DataTable = New DataTable()
        GrPoliticaTabla.Columns.Add(New DataColumn("idServ", GetType(Integer)))
        GrPoliticaTabla.Columns.Add(New DataColumn("Servicio", GetType(String)))
        GrPoliticaTabla.Columns.Add(New DataColumn("cant", GetType(String)))
        GrPoliticaTabla.Columns.Add(New DataColumn("Año", GetType(String)))
        GrPoliticaTabla.Columns.Add(New DataColumn("Estado", GetType(Boolean)))
        GrPoliticaTabla.Columns.Add(New DataColumn("NControl", GetType(String)))
        GrPoliticaTabla.Columns.Add(New DataColumn("Porcentaje Desc", GetType(String)))
        For i As Integer = 0 To TableServicioPolitica.Rows.Count - 1 Step 1
            Dim _Año As Integer = TableServicioPolitica.Rows(0).Item("ano")
            Dim Libre As Boolean = False 'BAndera que encontrara el primer mes libre
            Dim PosLibre As Integer = -1 'Variable que encontrara la posicion Libre 

            Dim NumiVenta As Integer = -1
            TablaPolitica = L_prExistePoliticaDescuentoServicioRemolque(tbnumiCliente.Text, TableServicioPolitica.Rows(i).Item("ednumi"))
            Dim TablaP As DataTable = L_prObtenerHistorialdeServiciosPoliticaRemolque(tbnumiCliente.Text, TableServicioPolitica.Rows(i).Item("ednumi"))
            Dim ayuda As DataTable = TablaP.Copy
            For j As Integer = 0 To TablaP.Rows.Count - 1
                Dim numi As Integer = -1
                If (_fnTienePoliticaInsertada(_Año, numi, TablaP) = True) Then
                    Dim TableNord As DataTable = L_prObtenerNumeroControlRemolque(ayuda.Rows(j).Item("rhtcr3"))
                    If (TableNord.Rows.Count > 0) Then

                        GrPoliticaTabla.Rows.Add(TableServicioPolitica.Rows(i).Item("ednumi"), TablaP.Rows(j).Item("servicio").ToString, TablaP.Rows(j).Item("rhcant"), Now.Year.ToString, True, TableNord.Rows(0).Item("rencont").ToString, TablaP.Rows(j).Item("pdesc"))
                    Else
                        GrPoliticaTabla.Rows.Add(TableServicioPolitica.Rows(i).Item("ednumi"), TablaP.Rows(j).Item("servicio").ToString, TablaP.Rows(j).Item("rhcant"), Now.Year.ToString, True, "", TablaP.Rows(j).Item("pdesc"))
                    End If


                End If

            Next

            If (TablaPolitica.Rows.Count > i + 1 And GrPoliticaTabla.Rows.Count > 0) Then
                GrPoliticaTabla.Rows.Add(TableServicioPolitica.Rows(i).Item("ednumi"), TablaPolitica.Rows(0).Item("eddesc").ToString, TablaPolitica.Rows(i + 1).Item("cfcant"), Now.Year.ToString, False, "", TablaPolitica.Rows(i + 1).Item("cfdesc"))
            Else

                GrPoliticaTabla.Rows.Add(TableServicioPolitica.Rows(i).Item("ednumi"), TablaPolitica.Rows(0).Item("eddesc").ToString, TablaPolitica.Rows(0).Item("cfcant"), Now.Year.ToString, False, "", TablaPolitica.Rows(0).Item("cfdesc"))
            End If

            If (Libre = False) Then ''Aqui Verificamos que Fila esta Libre Para Seleccionar el descuento
                PosLibre = GrPoliticaTabla.Rows.Count - 1
                Libre = True
            End If


        Next

        _prCargarPorcentajeDescuento(GrPoliticaTabla)

        grPolitica.DataSource = GrPoliticaTabla
        grPolitica.RetrieveStructure()
        grPolitica.RootTable.Columns("Servicio").Width = 150
        grPolitica.RootTable.Columns("cant").Visible = False
        grPolitica.RootTable.ApplyFilter(New Janus.Windows.GridEX.GridEXFilterCondition(grPolitica.RootTable.Columns("idServ"), Janus.Windows.GridEX.ConditionOperator.NotEqual, 36))
        grPolitica.RootTable.Columns("idServ").Visible = False
        With grPolitica
            .GroupByBoxVisible = False
            '.FilterRowFormatStyle.BackColor = Color.Blue
            .AllowEdit = InheritableBoolean.False
            'Diseño de la tabla
            .VisualStyle = VisualStyle.Office2007
            .SelectionMode = SelectionMode.SingleSelection
            .AlternatingColors = True
        End With


        _prCargarPolitica()
        _prPintar()
    End Sub
    Public Sub _prPintar()
        For Each _fil As Janus.Windows.GridEX.GridEXRow In grPolitica.GetRows
            Dim _estiloFila As New GridEXFormatStyle()
            If (_fil.RowIndex = grPolitica.RowCount - 1) Then
                _estiloFila.BackColor = Color.Gold
                _fil.RowStyle = _estiloFila
            Else
                _estiloFila.BackColor = Color.White
                _fil.RowStyle = _estiloFila
            End If
        Next
    End Sub
    Public Sub _prCargarPolitica()

        For i As Integer = 0 To grPolitica.RowCount - 1 Step 1
            '   a.rhnumi  ,a.rhtcr1  ,a.rhtcr3  ,a.rhtce04serv  ,a.rhano  ,a.rhmes  ,a.rhcant ,1 as estado
            Dim dt As DataTable = CType(grPolitica.DataSource, DataTable)
            If (CType(grPolitica.DataSource, DataTable).Rows(i).Item("Estado") = True) Then
                TablaGeneralServicios.Rows.Add(1, 0, 0, CType(grPolitica.DataSource, DataTable).Rows(i).Item("idServ"), Now.Year, Now.Month, CType(grPolitica.DataSource, DataTable).Rows(i).Item("cant"), 2)
            Else
                TablaGeneralServicios.Rows.Add(0, 0, 0, CType(grPolitica.DataSource, DataTable).Rows(i).Item("idServ"), Now.Year, Now.Month, CType(grPolitica.DataSource, DataTable).Rows(i).Item("cant"), -1)

            End If

        Next

    End Sub
    Public Sub _prCargarPorcentajeDescuento(tabalap As DataTable)
        For i As Integer = 0 To CType(grdetalle.DataSource, DataTable).Rows.Count - 1 Step 1
            For j As Integer = 0 To tabalap.Rows.Count - 1 Step 1
                If (CType(grdetalle.DataSource, DataTable).Rows(i).Item("rfTCE04Serv") = tabalap.Rows(j).Item("idServ")) Then
                    CType(grdetalle.DataSource, DataTable).Rows(i).Item("rfpdesc") = tabalap.Rows(j).Item("Porcentaje Desc")

                End If
            Next
        Next
    End Sub
    Public Function _fnTienePoliticaInsertada(_Ano As Integer, ByRef NumiVenta As Integer, TableP As DataTable)
        Dim i As Integer = 0
        While (i < TableP.Rows.Count)
            Dim cant As Integer = TablaPolitica.Rows(0).Item("cfcant")
            If (TableP.Rows(i).Item("rhano") = _Ano And
               TableP.Rows(i).Item("rhcant") = cant) Then
                NumiVenta = TableP.Rows(i).Item("rhtcr3")
                Return True
            End If
            i += 1
        End While
        Return False
    End Function

    Private Sub tbHoraEntrada_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub tbHoraEntrada_ValueChanged(sender As Object, e As EventArgs) Handles tbHoraEntrada.ValueChanged
        Dim salida As DateTime = tbHoraSalida.Value
        Dim entrada As DateTime = tbHoraEntrada.Value
        tbTiempoUtilizado.Value = sTiempo(salida, entrada)

    End Sub
    Function sTiempo(dInicio As DateTime, dFin As DateTime) As String

        Dim horaInicio As DateTime = dInicio
        Dim horaFin As DateTime = dFin

        If horaInicio > horaFin Then
            horaFin = horaFin.AddDays(1)
            Dim diferencia As TimeSpan = horaFin.Subtract(horaInicio)
            Dim Horas As String = Str(Math.Abs(diferencia.Hours)) + ":" + Str(Math.Abs(diferencia.Minutes))
            Return Horas

        End If


        'Return diferencia.ToString()

        Dim Tiempo As String = ""
        ''Tiempo = Str((DateDiff("s", dInicio, dFin) \ 86400) Mod 365) & " días, "
        Tiempo = Tiempo & Str((DateDiff("s", dInicio, dFin) \ 3600) Mod 24) & ":"

        Tiempo = Tiempo & Str((DateDiff("s", dInicio, dFin) \ 60) Mod 60)
        If (Tiempo.Contains("-")) Then
            Tiempo = "0:0"
        End If

        '  Tiempo = Tiempo & Str(DateDiff("s", dInicio, dFin) Mod 60) & " segundos."

        sTiempo = Tiempo
    End Function

    Private Sub tbTiempoUtilizado_Click(sender As Object, e As EventArgs) Handles tbTiempoUtilizado.Click

    End Sub

    Private Sub tbHoraSalida_ValueChanged(sender As Object, e As EventArgs) Handles tbHoraSalida.ValueChanged
        Dim salida As DateTime = tbHoraSalida.Value
        Dim entrada As DateTime = tbHoraEntrada.Value
        tbTiempoUtilizado.Value = sTiempo(salida, entrada)
    End Sub

    Private Sub btnGrabar_Click(sender As Object, e As EventArgs) Handles btnGrabar.Click

    End Sub

    Private Sub grVentasPendientes_FormattingRow(sender As Object, e As RowLoadEventArgs) Handles grVentasPendientes.FormattingRow

    End Sub

    Private Sub tbChofer_TextChanged(sender As Object, e As EventArgs) Handles tbChofer.TextChanged

    End Sub
End Class