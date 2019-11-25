Imports Logica.AccesoLogica
Imports Janus.Windows.GridEX
Imports DevComponents.DotNetBar
Imports System.IO
Imports DevComponents.DotNetBar.SuperGrid
Imports Presentacion.F_ClienteNuevoServicio



Public Class F1_ServicioVenta


#Region "Variables Globales"
    Dim RutaGlobal As String = gs_CarpetaRaiz
    Dim TipoTamano As Integer = -1
    Public Cliente As Boolean = False
    Dim TableCliente As Boolean = False
    Dim IDbanco As Integer = -1
    Public placa As String = ""
    Dim TablaPolitica As DataTable ''en este datatable colocare las politicas que existiera para un servicio
    Dim TablaServiciosP As DataTable ''En este datatable Tempora colocare un historial de servicios de politica de un cliente
    Dim TablaGeneralServicios As DataTable
    ''Aqui acumulare todos los servicios que cumple la politica
    Dim PagoAlDia As Boolean = False
    Dim HabilitarServicio As Boolean = True ''''''True=Servicios   False=Productos
    Public _nameButton As String
    Dim TablaImagenes As DataTable
    Dim TablaInventario As DataTable
    Dim Automovil As Boolean = False ''''Variable para verificar si el vehiculo es para el automovil del acb
#End Region
#Region "METODOS PRIVADOS"
    Private Sub _prIniciarTodo()

        Me.Text = "S E R V I C I O   V E N T A"
        _prCargarComboLibreria(cbTipo, 1, 4) ''Libreria Vehiculo=1  TamVehiculo=4
        _prCargarComboLibreria(cbTamanoR, 1, 4) ''Libreria Vehiculo=1  TamVehiculo=4
        _prCargarComboLibreria(cbTipoVehiculoR, 14, 2) ''Libreria Vehiculo=1  TamVehiculo=4
        _prCargarComboLibreria(cbventa, 14, 3) ''Libreria Contado, Credito,ATC
        _PMIniciarTodo()
        _prAsignarPermisos()
        TablaGeneralServicios = L_prObtenerHistorialdeServiciosPolitica(-1, 0)
        GroupPanelBuscador.Style.BackColor = Color.FromArgb(13, 71, 161)
        GroupPanelBuscador.Style.BackColor2 = Color.FromArgb(13, 71, 161)
        GroupPanelBuscador.Style.TextColor = Color.White
        JGrM_Buscador.RootTable.Columns("ldmefec").FormatString = "0.00"
        Dim blah As Bitmap = My.Resources.venta
        Dim ico As Icon = Icon.FromHandle(blah.GetHicon())

        Me.Icon = ico
        JGrM_Buscador.RootTable.HeaderFormatStyle.FontBold = TriState.True
        _prAplicarCondiccionJanus()
        _prCargarStyle()
        _prCargarGridVentaSinPagar()
        _prFiltroVentaSinPagar()



    End Sub


    Private Sub _prCargarAyudaProductos()
        Dim dt As New DataTable
        dt = L_prProductoGeneralLavadero(CType(grDetalle.DataSource, DataTable))
        ''''janosssssssss''''''
        grProducto.DataSource = dt
        grProducto.RetrieveStructure()
        grProducto.AlternatingColors = True
        grProducto.RowFormatStyle.Font = New Font("arial", 10)
        '     ldnumi ,ldcprod ,ldcdprod1,ldprec ,ldprev  ,ldgr1,grupo.cedesc1 as GrupoProducto ,ldumed 
        ',ldsmin ,ldap,CAST(IIF(ldap=1,1,0) as bit) as estado,ldimg 
        ', CAST('' as Image) as img,ldfact ,ldhact ,lduact,ISNULL(ti.iccven,0 ) as inventario
        With grProducto.RootTable.Columns("ldnumi")
            .Width = 70
            .TextAlignment = TextAlignment.Center
            .Caption = "ID"
            .Visible = False
        End With
        With grProducto.RootTable.Columns("ldcprod")
            .Width = 100
            .TextAlignment = TextAlignment.Near
            .Caption = "CODIGO"
            .Visible = False
        End With

        With grProducto.RootTable.Columns("ldcdprod1")
            .Width = 450
            .Visible = True
            .Caption = "DESCRIPCION DE PRODUCTO"

        End With

        With grProducto.RootTable.Columns("ldprec")
            .Width = 180
            .Visible = False
        End With

        With grProducto.RootTable.Columns("ldprev")
            .Width = 150
            .Visible = True
            .Caption = "PRECIO"
            .FormatString = "0.00"
        End With
        With grProducto.RootTable.Columns("ldgr1")
            .Width = 90
            .Visible = False

        End With
        With grProducto.RootTable.Columns("GrupoProducto")
            .Width = 90
            .Visible = False

        End With

        With grProducto.RootTable.Columns("ldumed")
            .Width = 90
            .Visible = False

        End With
        With grProducto.RootTable.Columns("ldsmin")
            .Width = 90
            .Visible = False

        End With

        With grProducto.RootTable.Columns("ldap")
            .Width = 90
            .Visible = False

        End With
        With grProducto.RootTable.Columns("estado")
            .Width = 90
            .Visible = False

        End With
        With grProducto.RootTable.Columns("ldimg")
            .Width = 90
            .Visible = False

        End With
        With grProducto.RootTable.Columns("img")
            .Width = 90
            .Visible = False

        End With
        With grProducto.RootTable.Columns("inventario")
            .Width = 150
            .Visible = True
            .Caption = "INVENTARIO"
            .FormatString = "0.00"

        End With
        With grProducto.RootTable.Columns("ldfact")
            .Width = 90
            .Visible = False

        End With
        With grProducto.RootTable.Columns("ldhact")
            .Width = 90
            .Visible = False

        End With
        With grProducto.RootTable.Columns("lduact")
            .Width = 90
            .Visible = False

        End With
       
        With grProducto
            .GroupByBoxVisible = False
            'diseño de la grilla
            .VisualStyle = VisualStyle.Office2007
            .DefaultFilterRowComparison = FilterConditionOperator.Contains
            .FilterMode = FilterMode.Automatic
            .FilterRowUpdateMode = FilterRowUpdateMode.WhenValueChanges
            .GroupByBoxVisible = False
        End With
        grProducto.RootTable.HeaderFormatStyle.FontBold = TriState.True
        _prAplicarCondiccionJanusServicio()
    End Sub
    Public Sub _prAplicarCondiccionJanusServicio()
        Dim fc As GridEXFormatCondition
        fc = New GridEXFormatCondition(grProducto.RootTable.Columns("inventario"), ConditionOperator.LessThanOrEqualTo, 0)
        fc.FormatStyle.ForeColor = Color.LightSalmon
        ''  fc.FormatStyle.FontBold = TriState.True

        grProducto.RootTable.FormatConditions.Add(fc)
    End Sub

    Private Sub _prCargarAyudaServicios()
        Dim dt As New DataTable
        dt = L_prServicioVentaAyudaServicio(gi_LibServLav, cbTipo.Value, CType(grDetalle.DataSource, DataTable))

        ''''janosssssssss''''''
        grProducto.DataSource = dt
        grProducto.RetrieveStructure()
        grProducto.AlternatingColors = True
        grProducto.RowFormatStyle.Font = New Font("arial", 10)
        'a.ednumi, a.edcod, a.eddesc, b.eqprecio, b.eqmes
        ',b.eqano,a.edtipo ,a.edest,q.cedesc1 ,a.edfact ,a.edhact ,a.eduact
        With grProducto.RootTable.Columns("ednumi")
            .Width = 70
            .TextAlignment = TextAlignment.Center
            .Caption = "ID"
            .Visible = False
        End With
        With grProducto.RootTable.Columns("edcod")
            .Width = 100
            .TextAlignment = TextAlignment.Near
            .Caption = "CODIGO"
            .Visible = False
        End With

        With grProducto.RootTable.Columns("eddesc")
            .Width = 450
            .Visible = True
            .Caption = "SERVICIOS"

        End With
       
        With grProducto.RootTable.Columns("eqprecio")
            .Width = 180
            .Visible = True
            .Caption = "PRECIO"
            .FormatString = "0.00"
        End With

        With grProducto.RootTable.Columns("eqmes")
            .Width = 90
            .Visible = False

        End With
        With grProducto.RootTable.Columns("eqano")
            .Width = 90
            .Visible = False

        End With
        With grProducto.RootTable.Columns("edtipo")
            .Width = 90
            .Visible = False

        End With
       
        With grProducto.RootTable.Columns("edest")
            .Width = 90
            .Visible = False

        End With
        With grProducto.RootTable.Columns("cedesc1")
            .Width = 90
            .Visible = False

        End With
        With grProducto.RootTable.Columns("edfact")
            .Width = 90
            .Visible = False

        End With
        With grProducto.RootTable.Columns("edhact")
            .Width = 90
            .Visible = False

        End With
        With grProducto.RootTable.Columns("eduact")
            .Width = 90
            .Visible = False

        End With
        With grProducto.RootTable.Columns("NumiDetalleServicio")
            .Width = 90
            .Visible = False

        End With
        With grProducto
            .GroupByBoxVisible = False
            'diseño de la grilla
            .VisualStyle = VisualStyle.Office2007
            .DefaultFilterRowComparison = FilterConditionOperator.Contains
            .FilterMode = FilterMode.Automatic
            .FilterRowUpdateMode = FilterRowUpdateMode.WhenValueChanges
            .GroupByBoxVisible = False
        End With
        grProducto.RootTable.HeaderFormatStyle.FontBold = TriState.True

    End Sub
    Private Sub _prCargarComboLibreria(mCombo As Janus.Windows.GridEX.EditControls.MultiColumnCombo, cod1 As String, cod2 As String)
        Dim dt As New DataTable
        dt = L_prLibreriaClienteLGeneral(cod1, cod2)

        With mCombo
            .DropDownList.Columns.Clear()

            .DropDownList.Columns.Add("cenum").Width = 70
            .DropDownList.Columns("cenum").Caption = "COD"

            .DropDownList.Columns.Add("cedesc1").Width = 200
            .DropDownList.Columns("cedesc1").Caption = "DESCRIPCION"

            .ValueMember = "cenum"
            .DisplayMember = "cedesc1"
            .DataSource = dt
            .Refresh()
        End With
    End Sub
    Public Sub _prAplicarCondiccionJanus()
        Dim fc As GridEXFormatCondition
        fc = New GridEXFormatCondition(JGrM_Buscador.RootTable.Columns("ldest"), ConditionOperator.Equal, 0)
        fc.FormatStyle.BackColor = Color.Red
        JGrM_Buscador.RootTable.FormatConditions.Add(fc)
    End Sub
    Private Sub _prFiltroVentaSinPagar()

        grVentasPendientes.RootTable.ApplyFilter(New Janus.Windows.GridEX.GridEXFilterCondition(grVentasPendientes.RootTable.Columns("ldest"), Janus.Windows.GridEX.ConditionOperator.Equal, 0))
    End Sub
    Private Sub _prCargarGridVentaSinPagar()
        Dim dt As New DataTable
        dt = CType(JGrM_Buscador.DataSource, DataTable)

        ''''janosssssssss''''''
        grVentasPendientes.DataSource = dt
        grVentasPendientes.RetrieveStructure()
        grVentasPendientes.AlternatingColors = True
        grVentasPendientes.RowFormatStyle.Font = New Font("arial", 10)
        With grVentasPendientes.RootTable.Columns("ldnumi")
            .Width = 70
            .TextAlignment = TextAlignment.Center
            .Caption = "ID"
            .Visible = False
        End With
        With grVentasPendientes.RootTable.Columns("ldnord")
            .Width = 100
            .TextAlignment = TextAlignment.Near

            .Caption = "N.Orden"
            .Visible = True
        End With

        With grVentasPendientes.RootTable.Columns("ldsuc")
            .Width = 60
            .Visible = False
        End With
        With grVentasPendientes.RootTable.Columns("ldtcl1cli")
            .Width = 90
            .Visible = False
        End With
        With grVentasPendientes.RootTable.Columns("laci")
            .Width = 100
            .Caption = "CI"
            .Visible = True
        End With
        With grVentasPendientes.RootTable.Columns("nombre")
            .Width = 250
            .Caption = "CLIENTE"
            .Visible = True
        End With


        With grVentasPendientes.RootTable.Columns("ldtcl11veh")
            .Width = 250
            .Caption = "VEHICULOS"
            .Visible = False
        End With

        With grVentasPendientes.RootTable.Columns("lbplac")
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




        With grVentasPendientes.RootTable.Columns("lafot")
            .Width = 90
            .Visible = False
        End With
        With grVentasPendientes.RootTable.Columns("ldtven")
            .Width = 90
            .Visible = False
        End With

        With grVentasPendientes.RootTable.Columns("TipoVenta")
            .Width = 90
            .Visible = False
        End With
        With grVentasPendientes.RootTable.Columns("ldfdoc")
            .Width = 110
            .Caption = "FECHA VENTA"
            .Visible = True
        End With
        With grVentasPendientes.RootTable.Columns("ldfvcr")
            .Width = 90
            .Visible = False
        End With
        With grVentasPendientes.RootTable.Columns("ldtmon")
            .Width = 90
            .Visible = False
        End With
        With grVentasPendientes.RootTable.Columns("TipoMoneda")
            .Width = 90
            .Visible = False

        End With

        With grVentasPendientes.RootTable.Columns("ldpdes")
            .Width = 90
            .Visible = False

        End With
        With grVentasPendientes.RootTable.Columns("ldmdes")
            .Width = 90
            .Visible = False

        End With
        With grVentasPendientes.RootTable.Columns("ldest")
            .Width = 90
            .Visible = False

        End With
        With grVentasPendientes.RootTable.Columns("Estado")
            .Width = 100
            .Caption = "ESTADO"
            .Visible = True

        End With


        With grVentasPendientes.RootTable.Columns("ldtpago")
            .Width = 90
            .Visible = False

        End With
        With grVentasPendientes.RootTable.Columns("TipoPago")
            .Width = 90
            .Visible = False

        End With
        With grVentasPendientes.RootTable.Columns("ldmefec")
            .Width = 90
            .Caption = "MONTO TOTAL"
            .Visible = False

        End With
        With grVentasPendientes.RootTable.Columns("ldmtar")
            .Width = 90
            .Visible = False

        End With
        With grVentasPendientes.RootTable.Columns("ldtip1_4")
            .Width = 90
            .Visible = False

        End With
        With grVentasPendientes.RootTable.Columns("tamano")
            .Width = 90
            .Visible = False

        End With
        With grVentasPendientes.RootTable.Columns("ldfact")
            .Width = 90
            .Visible = False

        End With
        With grVentasPendientes.RootTable.Columns("ldhact")
            .Width = 90
            .Visible = False

        End With
        With grVentasPendientes.RootTable.Columns("lduact")
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
    Private Sub _prCargarGridDetalle(_ldnumi As Integer)
        Dim dt As New DataTable
        dt = L_prServicioVentaDetalle(_ldnumi)

        ''''janosssssssss''''''
        grDetalle.DataSource = dt
        grDetalle.RetrieveStructure()
        grDetalle.AlternatingColors = True
        grDetalle.RowFormatStyle.Font = New Font("arial", 10)

        'dar formato a las columnas

        '     lcnumi ,lctce4pro,b.eddesc  ,lctp1emp,CONCAT (a.panom ,' ',a.paape )as nombre 
        ',lcpuni ,lccant,lcpdes ,lcmdes ,lcptot 
        ',lcfpag ,lcppagper ,lcmpagper ,lcest ,lclin
        With grDetalle.RootTable.Columns("lclin")
            .Width = 80
            .TextAlignment = TextAlignment.Center
            .Caption = "CODIGO"
            .Visible = False
        End With
        With grDetalle.RootTable.Columns("lcnumi")
            .Width = 60
            .Visible = False


        End With
        With grDetalle.RootTable.Columns("lctce4pro")
            .Width = 90
            .Visible = False
        End With
        With grDetalle.RootTable.Columns("lctcl3pro")
            .Width = 90
            .Visible = False
        End With
        With grDetalle.RootTable.Columns("eddesc")
            .Width = 350
            .Caption = "SERVICIO"
            .Visible = True
        End With
        With grDetalle.RootTable.Columns("lctp1emp")
            .Width = 90
            .Visible = False
        End With
        With grDetalle.RootTable.Columns("lctce42pro")
            .Width = 90
            .Visible = False
        End With
        With grDetalle.RootTable.Columns("nombre")
            .Width = 250
            .Caption = "PERSONAL"
            .Visible = False
        End With
        With grDetalle.RootTable.Columns("lcpuni")
            .Caption = "PRECIO UNITARIO"
            .Width = 150
            .FormatString = "0.00"
            .TextAlignment = TextAlignment.Center
            .Visible = True
        End With
        With grDetalle.RootTable.Columns("lccant")
            .Caption = "CANTIDAD"
            .FormatString = "0.00"
            .TextAlignment = TextAlignment.Center
            .Width = 100
            .Visible = True
        End With
        With grDetalle.RootTable.Columns("lcpdes")
            .Width = 120
            .Caption = "% DESCUENTO"
            .TextAlignment = TextAlignment.Center
            .FormatString = "0.00"
            .Visible = True

        End With
        With grDetalle.RootTable.Columns("lcmdes")
            .Caption = "MONTO DE DESCUENTO"
            .Width = 200
            .TextAlignment = TextAlignment.Center
            .FormatString = "0.00"
            .Visible = True
        End With
        With grDetalle.RootTable.Columns("lcptot")
            .Width = 200
            .Caption = "PRECIO TOTAL"
            .TextAlignment = TextAlignment.Far
            .FormatString = "0.00"
            .Visible = True
            .AggregateFunction = AggregateFunction.Sum
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        End With
        With grDetalle.RootTable.Columns("lcfpag")
            .Width = 100
            .Visible = False
        End With

        With grDetalle.RootTable.Columns("lcppagper")
            .Width = 100
            .Visible = False
        End With
        With grDetalle.RootTable.Columns("lcmpagper")
            .Width = 100
            .Visible = False
        End With
        With grDetalle.RootTable.Columns("lcest")
            .Width = 100
            .Visible = False
        End With
        With grDetalle.RootTable.Columns("estado")
            .Width = 100
            .Visible = False
        End With
        With grDetalle.RootTable.Columns("stockminimo")
            .Width = 100
            .Visible = False
        End With
        With grDetalle.RootTable.Columns("inventario")
            .Width = 100
            .Visible = False
        End With
        With grDetalle
            .GroupByBoxVisible = False
            grDetalle.TotalRow = InheritableBoolean.True
            .TotalRowFormatStyle.BackColor = Color.DodgerBlue
            .TotalRowPosition = TotalRowPosition.BottomFixed

            .VisualStyle = VisualStyle.Office2007

        End With
        grDetalle.RootTable.HeaderFormatStyle.FontBold = TriState.True
        grDetalle.RootTable.SortKeys.Add(
            "lclin", SortOrder.Ascending) ''Esta instruccion me orden las columnas




    End Sub

    Private Sub _prCargarGridAyudaPlacaCLiente()
        GpVentasSinCobrar.Text = "V E H I C U L O S    C L I E N T E S"
        Dim dt As New DataTable
        dt = L_prServicioVehiculoCliente()


        ''''janosssssssss''''''
        grVentasPendientes.DataSource = dt
        grVentasPendientes.RetrieveStructure()
        grVentasPendientes.AlternatingColors = True
        grVentasPendientes.RowFormatStyle.Font = New Font("arial", 10)

        'dar formato a las columnas
        '        a.lblin,b.lanumi ,a.lbplac,marca.cedesc1 as marca,modelo .cedesc1  as modelo
        ',Concat(b.lanom,' ',b.laapat ,' ',b.laamat  )as nombre

        With grVentasPendientes.RootTable.Columns("lblin")
            .Width = 80
            .TextAlignment = TextAlignment.Center
            .Caption = "CODIGO"
            .Visible = False
        End With
        With grVentasPendientes.RootTable.Columns("lanumi")
            .Width = 60
            .Visible = False
        End With
        With grVentasPendientes.RootTable.Columns("lansoc")
            .Width = 60
            .Visible = False
        End With
        With grVentasPendientes.RootTable.Columns("lbplac")
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
        With grVentasPendientes.RootTable.Columns("lafot")
            .Width = 250
            .Visible = False
        End With
        With grVentasPendientes.RootTable.Columns("lbtip1_4")
            .Width = 250
            .Visible = False
        End With
        With grVentasPendientes.RootTable.Columns("VehiculoRegistrado")
            .Width = 250
            .Visible = False
        End With
        With grVentasPendientes.RootTable.Columns("tipo")
            .Width = 250
            .Visible = False
        End With
        With grVentasPendientes.RootTable.Columns("acb")
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
        GpDetalle.Style.BackColor = Color.FromArgb(13, 71, 161)
        GpDetalle.Style.BackColor2 = Color.FromArgb(13, 71, 161)
        GpDetalle.Style.TextColor = Color.White

        GpVentasSinCobrar.Style.BackColor = Color.FromArgb(13, 71, 161)
        GpVentasSinCobrar.Style.BackColor2 = Color.FromArgb(13, 71, 161)
        GpVentasSinCobrar.Style.TextColor = Color.White




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
        'MPanelSup.Dock = DockStyle.Top
        PanelSuperior.Visible = True
        ButtonX2.Visible = False
        ButtonX1.Visible = True
    End Sub
    Public Function _fnActionNuevo() As Boolean
        Return tbCodigo.Text = String.Empty

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
                            CType(grDetalle.DataSource, DataTable).Rows.RemoveAt(i)
                        End If


                    End If
                    i = i + 1


                End While




                grDetalle.RootTable.ApplyFilter(New Janus.Windows.GridEX.GridEXFilterCondition(grDetalle.RootTable.Columns("estado"), Janus.Windows.GridEX.ConditionOperator.GreaterThanOrEqualTo, 0))
                _prAddFilaDetalle()

            End If
        End If
    End Sub
    Public Function _fnVisualizarRegistros() As Boolean
        Return Estado.IsReadOnly = True


    End Function

    Public Function _fnObtenerLinDetalle() As Integer
        Dim length As Integer = CType(grDetalle.DataSource, DataTable).Rows.Count
        Dim lin As Integer
        If (length > 0) Then
            lin = CType(grDetalle.DataSource, DataTable).Rows(length - 1).Item("lclin")
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
        CType(grDetalle.DataSource, DataTable).Rows.Add({lin, 0, 0, 0, "", 0, 0, "", 0, 0, 0, 0, 0, Now.Date, 0, 0, 1, 0, 0, 0})
    End Sub

    Public Function _fnValidarColumn(pos As Integer, row As Integer, _MostrarMensaje As Boolean) As Boolean
        If (CType(grDetalle.DataSource, DataTable).Rows(pos).Item("eddesc") = String.Empty) Then
            grDetalle.Row = row
            grDetalle.Col = 3
            grDetalle.FocusCellFormatStyle.BackColor = Color.Red

            If (_MostrarMensaje = True) Then
                ToastNotification.Show(Me, "           Seleccione un Servicio o Producto!!             ", My.Resources.WARNING, 3000, eToastGlowColor.Red, eToastPosition.TopCenter)
            End If

            Return False
        End If


        Return True
    End Function

    Public Sub _prCalcularPrecioTotal()
        'tbTotal.Text = grDetalle.GetTotal(grDetalle.RootTable.Columns("lcptot"), AggregateFunction.Sum)
    End Sub
    Public Sub _prBuscarDescuentoEliminadoNumiServ(ByRef _pos As Integer, _numiServ As Integer)
        Dim length As Integer = CType(grDetalle.DataSource, DataTable).Rows.Count
        For i As Integer = 0 To length - 1 Step 1
            Dim estado As Integer = CType(grDetalle.DataSource, DataTable).Rows(i).Item("estado")
            Dim numiserv As Integer = CType(grDetalle.DataSource, DataTable).Rows(i).Item("lctce4pro")
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
            Dim numiserv As Integer = IIf(IsDBNull(CType(grDetalle.DataSource, DataTable).Rows(i).Item("lctce4pro")), 0, CType(grDetalle.DataSource, DataTable).Rows(i).Item("lctce4pro"))
            If (estado <> -1 And numiserv = _numiServ) Then
                Return True

            End If
        Next
        Return False
    End Function

    Public Function _prBuscarExisteNumiProd(_numiProd As Integer) As Boolean
        Dim length As Integer = CType(grDetalle.DataSource, DataTable).Rows.Count
        For i As Integer = 0 To length - 1 Step 1
            Dim estado As Integer = CType(grDetalle.DataSource, DataTable).Rows(i).Item("estado")
            Dim numiprod As Integer = CType(grDetalle.DataSource, DataTable).Rows(i).Item("lctcl3pro")
            If (estado <> -1 And numiprod = _numiProd) Then
                Return True

            End If

        Next
        Return False
    End Function
    Public Sub _prObtenerPosicionDetalle(ByRef pos As Integer, ByVal Lin As Integer)
        Dim length As Integer = CType(grDetalle.DataSource, DataTable).Rows.Count
        pos = -1
        For i As Integer = 0 To length Step 1
            Dim numi As Integer = CType(grDetalle.DataSource, DataTable).Rows(i).Item("lclin")
            If (numi = Lin) Then
                pos = i
                Return

            End If
        Next

    End Sub

    Private Sub _prValidarInventario(rowIndex As Integer)
        grDetalle.Row = rowIndex
        Dim lin As Integer = grDetalle.GetValue("lclin")
        Dim pos As Integer = -1
        _prObtenerPosicionDetalle(pos, lin)
        Dim cant As Double = grDetalle.GetValue("lccant")
        Dim StockMinimo As Double = grDetalle.GetValue("stockminimo")
        Dim almacen As Double = grDetalle.GetValue("inventario")
        If (pos >= 0) Then
            If ((almacen - cant) >= 0 And (almacen - cant) <= StockMinimo) Then
                Dim mensaje As String = "La cantidad de venta del producto es menor al stock minimo ".ToUpper + vbCrLf + _
                                      "Inventario          : ".ToUpper + Str(almacen) + vbCrLf + _
                                      "Cantidad Venta: ".ToUpper + Str(cant) + vbCrLf + _
                                      "Stock Minimo: ".ToUpper + Str(StockMinimo)
                ToastNotification.Show(Me, mensaje.ToUpper, My.Resources.WARNING, 5000, eToastGlowColor.Red, eToastPosition.BottomCenter)

           



                'Dim info As New TaskDialogInfo("advertencia".ToUpper, eTaskDialogIcon.Delete, "¿desea continuar?".ToUpper, mensaje.ToUpper, eTaskDialogButton.Yes Or eTaskDialogButton.No, eTaskDialogBackgroundColor.Blue)
                'Dim result As eTaskDialogResult = TaskDialog.Show(info)
                'If result = eTaskDialogResult.Yes Then

                'Else
                '    CType(grDetalle.DataSource, DataTable).Rows(pos).Item("lccant") = 1
                '    grDetalle.SetValue("lccant", 1)


                'End If

            End If
            If ((almacen - cant) < 0) Then


                Dim mensaje As String = "La cantidad de venta del producto es mayor a la cantidad que existe en el inventario".ToUpper + vbCrLf + _
                                      "Inventario          : ".ToUpper + Str(almacen) + vbCrLf + _
                                      "Cantidad Venta: ".ToUpper + Str(cant) + vbCrLf + " No se Puede Sacar mas de :" + Str(almacen)
                ToastNotification.Show(Me, mensaje.ToUpper, My.Resources.WARNING, 8000, eToastGlowColor.Red, eToastPosition.BottomCenter)
                grDetalle.SetValue("lccant", almacen)

                'Dim info As New TaskDialogInfo("advertencia".ToUpper, eTaskDialogIcon.Delete, "¿desea continuar?".ToUpper, mensaje.ToUpper, eTaskDialogButton.Yes Or eTaskDialogButton.No, eTaskDialogBackgroundColor.Blue)
                'Dim result As eTaskDialogResult = TaskDialog.Show(info)
                'If result = eTaskDialogResult.Yes Then

                'Else
                '    CType(grDetalle.DataSource, DataTable).Rows(pos).Item("lccant") = 1
                '    grDetalle.SetValue("lccant", 1)

                'End If

            End If

        End If
        P_PonerTotal(rowIndex)


    End Sub
    Private Sub P_PonerTotal(rowIndex As Integer)
        If (rowIndex < grDetalle.RowCount) Then


            grDetalle.Row = rowIndex
            Dim lin As Integer = grDetalle.GetValue("lclin")
            Dim pos As Integer = -1
            _prObtenerPosicionDetalle(pos, lin)
            Dim cant As Double = grDetalle.GetValue("lccant")

            Dim uni As Double = grDetalle.GetValue("lcpuni")

            If (pos >= 0) Then

                Dim porcdesc As Double = IIf(IsDBNull(grDetalle.GetValue("lcpdes")), 0, grDetalle.GetValue("lcpdes"))
                Dim TotalUnitario As Double = cant * uni
                Dim montodesc As Double = (TotalUnitario * (porcdesc / 100))
                'grDetalle.SetValue("lcmdes", montodesc)
                CType(grDetalle.DataSource, DataTable).Rows(pos).Item("lcmdes") = montodesc
                grDetalle.SetValue("lcptot", (cant * uni) - montodesc)
                CType(grDetalle.DataSource, DataTable).Rows(pos).Item("lcptot") = ((cant * uni) - montodesc)
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
                    CType(grDetalle.DataSource, DataTable).Rows.RemoveAt(i)

                End If
            End If
        Next
        grDetalle.RootTable.ApplyFilter(New Janus.Windows.GridEX.GridEXFilterCondition(grDetalle.RootTable.Columns("estado"), Janus.Windows.GridEX.ConditionOperator.GreaterThanOrEqualTo, 0))
    End Sub

    Private Sub _prImprimir(_numiVenta As Integer)
        Dim _dt As New DataTable
        _dt = L_prReporteServicioVentaCliente(_numiVenta)
        Dim form As New PR_ServiciosVenta
        form._dt = _dt
        form.pTitulo = "V E N T A S   D E   S E R V I C I O S"
        form.pTipo = 2
        form.Show()


    End Sub

#End Region

#Region "METODOS SOBREESCRITOS"



    Public Overrides Sub _PMOHabilitar()
        Estado.IsReadOnly = False
        _prAplicarCondiccionJanus()
        JGrM_Buscador.RootTable.Columns("ldmefec").FormatString = "0.00"
        ButtonX1.Visible = False
        Eliminarms.Visible = True
        tbVehiculo.ReadOnly = False
        btnAnadir.Visible = True
        _prCargarGridAyudaPlacaCLiente()
        tbNumeroOrden.ReadOnly = False
        FechaVenta.Enabled = True
        cbventa.ReadOnly = False
        cbmoneda.IsReadOnly = False
        'tbbanco.ReadOnly = False
        tbObservacion.ReadOnly = False

        tbcredito.IsInputReadOnly = False
    End Sub
    Public Overrides Sub _PMOInhabilitar()
        cbventa.ReadOnly = True
        cbmoneda.IsReadOnly = True
        tbcredito.IsInputReadOnly = True
        tbTablet.IsReadOnly = True
        tbNumeroOrden.Enabled = True
        FechaVenta.Enabled = False

        tbClienteSocio.IsReadOnly = True
        tbNumeroOrden.ReadOnly = True
        tbCliente.ReadOnly = True
        tbVehiculo.ReadOnly = True
        cbTipo.ReadOnly = True
        Estado.IsReadOnly = True
        tbCodigo.Enabled = False
        _prAplicarCondiccionJanus()
        JGrM_Buscador.RootTable.Columns("ldmefec").FormatString = "0.00"
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
        SuperTabItem2.Visible = False
        SuperTabControl1.SelectedTabIndex = 0
        If (grPolitica.RowCount > 0) Then
            CType(grPolitica.DataSource, DataTable).Rows.Clear()
        End If
        TipoTamano = -1
        TablaGeneralServicios = L_prObtenerHistorialdeServiciosPolitica(-1, 0)
        PagoAlDia = False
        If (GpPanelServicio.Visible = True) Then
            GpPanelServicio.Visible = False
            PanelInferior.Visible = True

        End If
        tbbanco.ReadOnly = True
        tbObservacion.ReadOnly = True

    End Sub
    Public Overrides Sub _PMOHabilitarFocus()
        With MHighlighterFocus
            .SetHighlightOnFocus(tbCliente, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
            .SetHighlightOnFocus(FechaVenta, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
            .SetHighlightOnFocus(cbTipo, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
            .SetHighlightOnFocus(Estado, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
            .SetHighlightOnFocus(tbVehiculo, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
            .SetHighlightOnFocus(tbNumeroOrden, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
            .SetHighlightOnFocus(tbFechaPago, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
            .SetHighlightOnFocus(tbbanco, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
            .SetHighlightOnFocus(tbObservacion, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
        End With
    End Sub
    Public Overrides Sub _PMOLimpiar()
        Automovil = False
        IDbanco = -1
        tbbanco.Clear()
        tbObservacion.Clear()
        tbCliente.Text = ""
        tbnumiCliente.Text = 0
        tbnumiVehiculo.Text = 0
        tbVehiculo.Text = ""
        tbCodigo.Text = ""
        'FechaVenta.Text = DateTime.Now.ToString("dd/MM/yyyy")
        FechaVenta.Value = Now.Date
        cbTipo.SelectedIndex = -1
        TipoTamano = -1
        tbNumeroOrden.Text = ""
        Estado.Value = False
        Dim img As New Bitmap(New Bitmap(My.Resources.imageDefault), 180, 157)
        UsImg.pbImage.Image = img

        _prCargarGridDetalle(-1)
        _prAddFilaDetalle()

        ButtonX1.Visible = False
        ButtonX2.Visible = False
        _prCargarGridAyudaPlacaCLiente()
        tbFechaPago.Text = ""
        lbFechaPago.Visible = False
        tbFechaPago.Visible = False
        tbClienteSocio.Value = True
        SuperTabControl1.SelectedTabIndex = 0
        SuperTabItem2.Visible = False
        If (grPolitica.RowCount > 0) Then
            CType(grPolitica.DataSource, DataTable).Rows.Clear()
        End If
        TipoTamano = -1
        TablaGeneralServicios = L_prObtenerHistorialdeServiciosPolitica(-1, 0)
        PagoAlDia = False
        tbTablet.IsReadOnly = False
        tbTablet.Value = True
        btnAnadir.Visible = False
        _prLimpiarOrden()
        tbNumeroOrden.Focus()
        cbventa.SelectedIndex = 1
        cbmoneda.Value = True
        tbcredito.Value = Now.Date
    End Sub
    Public Overrides Sub _PMOLimpiarErrores()

        MEP.Clear()
        tbCliente.BackColor = Color.White
        cbTipo.BackColor = Color.White
        tbNumeroOrden.BackColor = Color.White
    End Sub
    Public Overrides Function _PMOValidarCampos() As Boolean
        Dim _ok As Boolean = True
        MEP.Clear()
        If tbNumeroOrden.Text = String.Empty Then
            tbNumeroOrden.BackColor = Color.Red
            MEP.SetError(tbNumeroOrden, "INSERTE UNA NUMERO DE ORDEN".ToUpper)
            _ok = False
        Else
            tbNumeroOrden.BackColor = Color.White
            MEP.SetError(tbNumeroOrden, "")
        End If
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
        If cbTipo.SelectedIndex < 0 Then
            cbTipo.BackColor = Color.Red
            MEP.SetError(cbTipo, "Seleccione un Tipo de Vehiculo!".ToUpper)
            _ok = False
        Else
            cbTipo.BackColor = Color.White
            MEP.SetError(cbTipo, "")
        End If

        If cbventa.SelectedIndex < 0 Then
            cbventa.BackColor = Color.Red
            MEP.SetError(cbventa, "Seleccione un Tipo de Venta!".ToUpper)
            _ok = False
        Else
            cbventa.BackColor = Color.White
            MEP.SetError(cbventa, "")
        End If
        If (_fnValidarDatosDetalle() = False) Then
            _ok = False
        End If
        MHighlighterFocus.UpdateHighlights()
        Return _ok
    End Function
    Public Overrides Function _PMOGetListEstructuraBuscador() As List(Of Modelos.Celda)
        Dim listEstCeldas As New List(Of Modelos.Celda)

        'ldtcl11veh,c.lbplac ,marca .cedesc1 as marcas,modelo .cedesc1 as modelos
        listEstCeldas.Add(New Modelos.Celda("ldnumi", False, "ID", 60))
        listEstCeldas.Add(New Modelos.Celda("ldsuc", False))
        listEstCeldas.Add(New Modelos.Celda("ldtcl1cli", False))
        listEstCeldas.Add(New Modelos.Celda("laci", True, "CI", 80))
        listEstCeldas.Add(New Modelos.Celda("nombre", True, "NOMBRE", 320))

        listEstCeldas.Add(New Modelos.Celda("ldtcl11veh", False))
        listEstCeldas.Add(New Modelos.Celda("lbplac", True, "PLACA", 100))
        listEstCeldas.Add(New Modelos.Celda("marcas", True, "MARCA", 100))
        listEstCeldas.Add(New Modelos.Celda("modelos", True, "MODELO", 100))
        listEstCeldas.Add(New Modelos.Celda("lafot", False))
        listEstCeldas.Add(New Modelos.Celda("ldtven", False))
        listEstCeldas.Add(New Modelos.Celda("TipoVenta", False, "TIPO DE VENTA", 150))
        listEstCeldas.Add(New Modelos.Celda("ldfdoc", True, "FECHA VENTA", 120))
        listEstCeldas.Add(New Modelos.Celda("ldfvcr", False))
        listEstCeldas.Add(New Modelos.Celda("ldtmon", False))
        listEstCeldas.Add(New Modelos.Celda("TipoMoneda", False, "TIPO DE MONEDA", 150))
        listEstCeldas.Add(New Modelos.Celda("ldpdes", False))
        listEstCeldas.Add(New Modelos.Celda("ldmdes", False))
        listEstCeldas.Add(New Modelos.Celda("ldest", False))
        listEstCeldas.Add(New Modelos.Celda("Estado", True, "ESTADO VENTA", 110))
        listEstCeldas.Add(New Modelos.Celda("ldtpago", False))
        listEstCeldas.Add(New Modelos.Celda("TipoPago", False, "TIPO DE PAGO", 150))
        listEstCeldas.Add(New Modelos.Celda("ldmefec", True, "MONTO TOTAL", 120, "0.00"))
        listEstCeldas.Add(New Modelos.Celda("ldnord", True, "NUMERO DE ORDEN", 150))
        listEstCeldas.Add(New Modelos.Celda("ldmtar", False))
        listEstCeldas.Add(New Modelos.Celda("ldtip1_4", False))
        listEstCeldas.Add(New Modelos.Celda("tamano", True, "TAMAÑO VEHICULO", 150))
        listEstCeldas.Add(New Modelos.Celda("ldbanco", False))
        listEstCeldas.Add(New Modelos.Celda("banco", True, "BANCO", 150))
        listEstCeldas.Add(New Modelos.Celda("ldobs", True, "OBSERVACION", 150))
        listEstCeldas.Add(New Modelos.Celda("ldfact", False))
        listEstCeldas.Add(New Modelos.Celda("ldhact", False))
        listEstCeldas.Add(New Modelos.Celda("lduact", False))
        listEstCeldas.Add(New Modelos.Celda("lansoc", False))
        listEstCeldas.Add(New Modelos.Celda("ldtablet", False))
        listEstCeldas.Add(New Modelos.Celda("acb", False))
        Return listEstCeldas


    End Function
    Public Overrides Function _PMOGetTablaBuscador() As DataTable
        Dim dtBuscador As DataTable = L_prServicioVentaGeneral()
        Return dtBuscador
    End Function
    Public Sub _prCargarDatosNOrden()

        Dim dt As DataTable = L_prGeneralRecepcionNumi(tbNumeroOrden.Text)
        If (dt.Rows.Count <= 0) Then
            Return
        End If

        tbNroOrdenR.Text = dt.Rows(0).Item("lfnumi")
        tbFechaR.Value = dt.Rows(0).Item("lffecha")
        tbClienteR.Text = dt.Rows(0).Item("nombre")
        tbPlacaR.Text = dt.Rows(0).Item("placa")
        tbObservacionR.Text = dt.Rows(0).Item("lfobs")
        cbTipoVehiculoR.Value = dt.Rows(0).Item("lftipo")
        cbTamanoR.Value = dt.Rows(0).Item("lftam")
        tbMarcaR.Text = dt.Rows(0).Item("cedesc1").ToString

        Dim nsocio As Integer = IIf(IsDBNull(dt.Rows(0).Item("lansoc")), 0, dt.Rows(0).Item("lansoc"))
        If (nsocio > 0) Then
            SwClienteR.Value = False
        Else
            SwClienteR.Value = True
        End If
        TablaImagenes = L_prCargarImagenesRecepcion(tbNumeroOrden.Text)
        TablaInventario = L_prCargarInventarioRecepcion(tbNumeroOrden.Text)
        _prMarcarCheck()
        _prCargarImagen()
    End Sub
    Public Sub _prCargarImagen()
        panelA.Controls.Clear()
        pbImgProdu.Image = Nothing

        Dim i As Integer = 0
        For Each fila As DataRow In TablaImagenes.Rows
            Dim elemImg As UCLavadero = New UCLavadero
            Dim rutImg = fila.Item("lhima").ToString
            Dim estado As Integer = fila.Item("estado")

            If (estado = 0) Then
                elemImg.pbImg.SizeMode = PictureBoxSizeMode.StretchImage
                Dim bm As Bitmap = Nothing
                Dim by As Byte() = fila.Item("img")
                Dim ms As New MemoryStream(by)
                bm = New Bitmap(ms)


                elemImg.pbImg.Image = bm

                pbImgProdu.SizeMode = PictureBoxSizeMode.StretchImage
                pbImgProdu.Image = bm
                elemImg.pbImg.Tag = i
                elemImg.Dock = DockStyle.Top
                pbImgProdu.Tag = i
                AddHandler elemImg.pbImg.MouseEnter, AddressOf pbImg_MouseEnter

                panelA.Controls.Add(elemImg)
                ms.Dispose()

            Else
                If (estado = 1) Then
                    If (File.Exists(RutaGlobal + "\Imagenes\Imagenes RecepcionVehiculo\" + "Recepcion_" + tbNumeroOrden.Text.Trim + rutImg)) Then
                        Dim bm As Bitmap = New Bitmap(RutaGlobal + "\Imagenes\Imagenes RecepcionVehiculo\" + "Recepcion_" + tbNumeroOrden.Text + rutImg)
                        elemImg.pbImg.SizeMode = PictureBoxSizeMode.StretchImage
                        elemImg.pbImg.Image = bm
                        pbImgProdu.SizeMode = PictureBoxSizeMode.StretchImage
                        pbImgProdu.Image = bm
                        elemImg.pbImg.Tag = RutaGlobal + "\Imagenes\Imagenes RecepcionVehiculo\" + "Recepcion_" + tbNumeroOrden.Text + rutImg
                        elemImg.Dock = DockStyle.Top
                        pbImgProdu.Tag = RutaGlobal + "\Imagenes\Imagenes RecepcionVehiculo\" + "Recepcion_" + tbNumeroOrden.Text + rutImg
                        AddHandler elemImg.pbImg.MouseEnter, AddressOf pbImg_MouseEnter
                        elemImg.Height = panelA.Height / 3
                        'elemImg.Width = 500
                        panelA.Controls.Add(elemImg)
                    End If

                End If
            End If




            i += 1
        Next

    End Sub
    Private Function FindControl(ByVal ContainerControl As Control, ByVal Name As String) As Control
        Dim ReturnValue As Control = Nothing
        Dim FoundControls As Control() = ContainerControl.Controls.Find(Name, True)
        If FoundControls.Length > 0 Then
            ReturnValue = FoundControls(0)
        End If
        Return ReturnValue
    End Function
    Public Sub _prMarcarCheck()
        '        lgnumi, lgnumitc6, lglin, descripcion, estado
        '0	        0	     1	    LLanta de Auxilio	  0
        '0	        0	     2	    Manivela de Gata	  0
        '0        	0	     3	    Sobrepisos	          0
        For i As Integer = 0 To TablaInventario.Rows.Count - 1 Step 1
            Dim estado As Integer = TablaInventario.Rows(i).Item("estado")
            Dim numi As Integer = TablaInventario.Rows(i).Item("lglin")
            Dim cboxName As String
            Dim cbox As DevComponents.DotNetBar.Controls.CheckBoxX
            If (_fnActionNuevo()) Then
                If (estado = 0) Then
                    cboxName = "cb" + Str(numi).Trim
                    'cbox = CType(cboxName, Object)
                    'cbox.Checked = False
                    Dim ctrl As Control = FindControl(Me, cboxName)
                    If ctrl IsNot Nothing Then
                        cbox = CType(ctrl, DevComponents.DotNetBar.Controls.CheckBoxX)
                        cbox.Checked = True
                    End If

                End If
            Else
                If (estado = 1) Then
                    cboxName = "cb" + Str(numi).Trim
                    'cbox = CType(cboxName, Object)
                    'cbox.Checked = False
                    Dim ctrl As Control = FindControl(Me, cboxName)
                    If ctrl IsNot Nothing Then
                        cbox = CType(ctrl, DevComponents.DotNetBar.Controls.CheckBoxX)
                        cbox.Checked = True
                        cbox.Enabled = False
                    End If
                    cboxName = "cbb" + Str(numi).Trim
                    'cbox = CType(cboxName, Object)
                    'cbox.Checked = False
                    Dim ctrl2 As Control = FindControl(Me, cboxName)
                    If ctrl2 IsNot Nothing Then
                        cbox = CType(ctrl2, DevComponents.DotNetBar.Controls.CheckBoxX)

                        cbox.Enabled = False
                    End If
                End If
                If (estado = 0) Then

                    cboxName = "cbb" + Str(numi).Trim
                    'cbox = CType(cboxName, Object)
                    'cbox.Checked = False
                    Dim ctrl As Control = FindControl(Me, cboxName)
                    If ctrl IsNot Nothing Then
                        cbox = CType(ctrl, DevComponents.DotNetBar.Controls.CheckBoxX)
                        cbox.Checked = True
                        cbox.Enabled = False
                    End If
                    cboxName = "cb" + Str(numi).Trim
                    'cbox = CType(cboxName, Object)
                    'cbox.Checked = False
                    Dim ctrl2 As Control = FindControl(Me, cboxName)
                    If ctrl2 IsNot Nothing Then
                        cbox = CType(ctrl2, DevComponents.DotNetBar.Controls.CheckBoxX)

                        cbox.Enabled = False
                    End If
                    TablaInventario.Rows(i).Item("estado") = -2

                End If
            End If

        Next
    End Sub
    Private Sub pbImg_MouseEnter(sender As Object, e As EventArgs)
        Dim pb As PictureBox = CType(sender, PictureBox)
        pbImgProdu.Image = pb.Image
        pbImgProdu.Tag = pb.Tag

    End Sub
    Public Overrides Sub _PMOMostrarRegistro(_N As Integer)
        JGrM_Buscador.Row = _MPos
        Dim dt As DataTable = CType(JGrM_Buscador.DataSource, DataTable)
        With JGrM_Buscador
            tbCliente.Text = .GetValue("nombre").ToString
            tbnumiCliente.Text = .GetValue("ldtcl1cli")
            tbCodigo.Text = .GetValue("ldnumi")
            FechaVenta.Value = .GetValue("ldfdoc")
            IDbanco = .GetValue("ldbanco")
            tbbanco.Text = .GetValue("banco")
            tbObservacion.Text = .GetValue("ldobs")
            cbventa.Value = .GetValue("ldtven")
            cbmoneda.Value = .GetValue("ldtmon")
            tbcredito.Value = .GetValue("ldfvcr")
            Dim est = .GetValue("ldest")
            If (est = 1) Then
                Estado.Value = True
            Else
                Estado.Value = False

            End If
            If (.GetValue("acb") = 1) Then
                Automovil = True
            Else
                Automovil = False
            End If
            tbnumiVehiculo.Text = .GetValue("ldtcl11veh")

            tbVehiculo.Text = .GetValue("lbplac").ToString
            cbTipo.Value = .GetValue("ldtip1_4")
        End With
        Dim name As String = JGrM_Buscador.GetValue("lafot")
        If name.Equals("Default.jpg") Or Not File.Exists(RutaGlobal + "\Imagenes\Imagenes ClienteL" + name) Then
            Dim im As New Bitmap(My.Resources.imageDefault)
            UsImg.pbImage.Image = im
        Else


            If (File.Exists(RutaGlobal + "\Imagenes\Imagenes ClienteL" + name)) Then
                Dim Bin As New MemoryStream
                Dim im As New Bitmap(New Bitmap(RutaGlobal + "\Imagenes\Imagenes ClienteL" + name), 180, 157)
                im.Save(Bin, System.Drawing.Imaging.ImageFormat.Jpeg)
                UsImg.pbImage.Image = Image.FromStream(Bin)
                Bin.Dispose()

            End If


        End If

        _prCargarGridDetalle(tbCodigo.Text)

        _prCalcularPrecioTotal()
        If (Not IsDBNull(JGrM_Buscador.GetValue("ldnord"))) Then
            tbNumeroOrden.Text = JGrM_Buscador.GetValue("ldnord").ToString
        Else
            tbNumeroOrden.Text = ""

        End If
        _prVerificarSocio()
        TipoTamano = cbTipo.SelectedIndex
        tbTablet.Value = IIf(IsDBNull(JGrM_Buscador.GetValue("ldtablet")), 0, JGrM_Buscador.GetValue("ldtablet"))
        If (tbTablet.Value = True) Then
            SupTabItemBusqueda.Visible = True
            _prCargarDatosNOrden()
        Else
            SupTabItemBusqueda.Visible = False
            _prLimpiarOrden()
        End If
        LblPaginacion.Text = Str(_MPos + 1) + "/" + JGrM_Buscador.RowCount.ToString

    End Sub
    Public Sub _prLimpiarOrden()
        tbNroOrdenR.Clear()
        tbPlacaR.Clear()
        tbClienteR.Clear()
        tbMarcaR.Clear()
        IIf(CType(cbTamanoR.DataSource, DataTable).Rows.Count > 0, cbTamanoR.SelectedIndex = 0, cbTamanoR.SelectedIndex = -1)
        IIf(CType(cbTipoVehiculoR.DataSource, DataTable).Rows.Count > 0, cbTipoVehiculoR.SelectedIndex = 0, cbTipoVehiculoR.SelectedIndex = -1)
        tbFechaR.Value = Now.Date
        tbObservacionR.Clear()
        SwClienteR.Value = True



        TablaImagenes = L_prCargarImagenesRecepcion(-1)
        TablaInventario = L_prCargarInventarioRecepcion(-1)

        _prMarcarCheck()
        _prCargarImagen()
    End Sub
    Public Sub _prVerificarSocio()
        Dim nsoc As Integer = JGrM_Buscador.GetValue("lansoc")
        If (nsoc > 0) Then
            tbClienteSocio.Value = False
        Else
            tbClienteSocio.Value = True

        End If
    End Sub

    Public Function _fnValidarDatosDetalle()
        Dim row As Integer = CType(grDetalle.DataSource, DataTable).Rows.Count - 1

        If (CType(grDetalle.DataSource, DataTable).Rows(row).Item("eddesc") = String.Empty) Then


            If (row > 0) Then ''Aqui pregunto si hay al menos un servicio insertado en el detalle de venta
                CType(grDetalle.DataSource, DataTable).Rows.RemoveAt(row)
                Return True

            Else
                ToastNotification.Show(Me, "           Seleccione un Servicio Antes de guardar los datos no se puede guardar el detalle sin ningun servicio o producto seleccionado !!             ", My.Resources.WARNING, 8000, eToastGlowColor.Red, eToastPosition.TopCenter)
                Return False
            End If


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

        Dim res As Boolean

        res = L_prServicioVentaGrabar(tbCodigo.Text, tbnumiCliente.Text, tbNumeroOrden.Text, tbnumiVehiculo.Text, FechaVenta.Value.ToString("yyyy/MM/dd"), IIf(Estado.Value = True, 1, 0), grDetalle.GetTotal(grDetalle.RootTable.Columns("lcptot"), AggregateFunction.Sum), cbTipo.Value, CType(grDetalle.DataSource, DataTable), TablaGeneralServicios, IIf(tbTablet.Value = True, 1, 0), cbventa.Value, IIf(cbmoneda.Value = True, 1, 0), tbcredito.Value.ToString("yyyy/MM/dd"), IDbanco, tbObservacion.Text)
        If res Then

            TipoTamano = -1
            TablaGeneralServicios = L_prObtenerHistorialdeServiciosPolitica(-1, 0)
            ToastNotification.Show(Me, "Codigo de Servicio Venta ".ToUpper + tbCodigo.Text + " Grabado con Exito.".ToUpper, My.Resources.GRABACION_EXITOSA, 5000, eToastGlowColor.Green, eToastPosition.TopCenter)
            _prMesajeImprimi(tbCodigo.Text)

        End If

        Return res
    End Function
    Public Overrides Function _PMOModificarRegistro() As Boolean
        Dim res As Boolean


        res = L_prServicioVentaModificar(tbCodigo.Text, tbnumiCliente.Text, tbnumiVehiculo.Text,
                                         tbNumeroOrden.Text, FechaVenta.Value.ToString("yyyy/MM/dd"), IIf(Estado.Value = True, 1, 0), grDetalle.GetTotal(grDetalle.RootTable.Columns("lcptot"), AggregateFunction.Sum), cbTipo.Value, CType(grDetalle.DataSource, DataTable),
                                         TablaGeneralServicios, IIf(tbTablet.Value = True, 1, 0), cbventa.Value, IIf(cbmoneda.Value = True, 1, 0), tbcredito.Value.ToString("yyyy/MM/dd"), IDbanco, tbObservacion.Text)
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
            Dim res As Boolean = L_prServicioVentaBorrar(tbCodigo.Text, mensajeError)
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
                dt = L_prServicioVentaAYUdaCLiente()

                Dim listEstCeldas As New List(Of Modelos.Celda)
                listEstCeldas.Add(New Modelos.Celda("lanumi", True, "ID", 50))
                listEstCeldas.Add(New Modelos.Celda("latipo", False))
                listEstCeldas.Add(New Modelos.Celda("cedesc1", True, "TIPO", 120))
                listEstCeldas.Add(New Modelos.Celda("lansoc", True, "NUMERO DE SOCIO", 150))
                listEstCeldas.Add(New Modelos.Celda("lafing", False, "FECHA DE INGRESO", 200))
                listEstCeldas.Add(New Modelos.Celda("lafnac", False, "FECHA DE NACIMIENTO", 170))
                listEstCeldas.Add(New Modelos.Celda("lanom", True, "NOMBRES", 150))
                listEstCeldas.Add(New Modelos.Celda("laapat", True, "APELLIDO PATERNO", 150))
                listEstCeldas.Add(New Modelos.Celda("laamat", True, "APELLIDO MATERNO", 150))

                listEstCeldas.Add(New Modelos.Celda("ladir", False, "DIRECCION", 150))
                listEstCeldas.Add(New Modelos.Celda("laemail", False, "CORREO ELECTRONICO", 150))
                listEstCeldas.Add(New Modelos.Celda("laci", True, "CI", 90))
                listEstCeldas.Add(New Modelos.Celda("lafot", False))
                listEstCeldas.Add(New Modelos.Celda("img", False, "IMAGEN", 150))

                listEstCeldas.Add(New Modelos.Celda("laobs", False, "OBSERVACION", 100))
                listEstCeldas.Add(New Modelos.Celda("laest", False))
                listEstCeldas.Add(New Modelos.Celda("estado", False, "ESTADO", 80))
                listEstCeldas.Add(New Modelos.Celda("latelf1", False, "TELEFONO 1", 100))
                listEstCeldas.Add(New Modelos.Celda("latelf2", False, "TELEFONO 2", 100))

                listEstCeldas.Add(New Modelos.Celda("lafact", False))
                listEstCeldas.Add(New Modelos.Celda("lahact", False))
                listEstCeldas.Add(New Modelos.Celda("lauact", False))

                frmAyuda = New Modelos.ModeloAyuda(50, 250, dt, "SELECCIONE CLIENTE DEL LAVADERO".ToUpper, listEstCeldas)
                frmAyuda.ShowDialog()


                If frmAyuda.seleccionado = True Then



                    Dim numi As String = frmAyuda.filaSelect.Cells("lanumi").Value
                    If (codigo >= 0) Then
                        If (codigo <> numi) Then
                            _fnValidarNuevoCliente()
                            tbVehiculo.Text = ""
                            tbnumiVehiculo.Text = 0
                            cbTipo.SelectedIndex = -1


                        End If
                    End If

                    Dim nombre As String = frmAyuda.filaSelect.Cells("lanom").Value + " " + frmAyuda.filaSelect.Cells("laapat").Value + " " + frmAyuda.filaSelect.Cells("laamat").Value
                    Dim name As String = frmAyuda.filaSelect.Cells("lafot").Value.ToString
                    If name.Equals("Default.jpg") Or Not File.Exists(RutaGlobal + "\Imagenes\Imagenes ClienteL" + name) Then
                        Dim im As New Bitmap(My.Resources.imageDefault)
                        UsImg.pbImage.Image = im
                    Else


                        If (File.Exists(RutaGlobal + "\Imagenes\Imagenes ClienteL" + name)) Then
                            Dim Bin As New MemoryStream
                            Dim im As New Bitmap(New Bitmap(RutaGlobal + "\Imagenes\Imagenes ClienteL" + name), 180, 157)
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
        If (Not tbCliente.Text.ToString = String.Empty And
           Not tbVehiculo.Text.ToString = String.Empty And cbTipo.SelectedIndex < 0) Then
            cbTipo.Focus()

            ToastNotification.Show(Me, "           Antes De Continuar Por favor Seleccione un Tipo de Vehiculo !!             ", My.Resources.WARNING, 4000, eToastGlowColor.Red, eToastPosition.TopCenter)
            Return
        End If
        If (tbnumiVehiculo.Text = 0) Then
            tbVehiculo.Focus()

            ToastNotification.Show(Me, "           Antes De Continuar Por favor Seleccione un Vehiculo !!             ", My.Resources.WARNING, 4000, eToastGlowColor.Red, eToastPosition.TopCenter)
            Return

        End If
        grDetalle.Select()
        grDetalle.Col = 4
        grDetalle.Row = 0


    End Sub

    Public Sub _prCrearTablaPoliticajanus()
        Dim TableServicioPolitica As DataTable = L_prObtenerServicioPolitica()
        Dim GrPoliticaTabla As DataTable = New DataTable()
        GrPoliticaTabla.Columns.Add(New DataColumn("Servicio", GetType(String)))
        GrPoliticaTabla.Columns.Add(New DataColumn("Mes", GetType(String)))
        GrPoliticaTabla.Columns.Add(New DataColumn("Estado", GetType(Boolean)))
        GrPoliticaTabla.Columns.Add(New DataColumn("NOrden", GetType(String)))
        Dim Libre As Boolean = False 'BAndera que encontrara el primer mes libre
        Dim PosLibre As Integer = -1 'Variable que encontrara la posicion Libre 
        For i As Integer = 0 To TableServicioPolitica.Rows.Count - 1 Step 1



            Dim _MesInicial As Date = TableServicioPolitica.Rows(0).Item("MesInicial")
            _MesInicial = _MesInicial.AddDays(-(_MesInicial.Day) + 1)
            Dim MesFinal As Date = _MesInicial.AddMonths(3)
            While (_MesInicial <= MesFinal)
                Dim NumiVenta As Integer = -1
                TablaPolitica = L_prExistePoliticaDescuentoServicio(tbnumiCliente.Text, TableServicioPolitica.Rows(i).Item("ednumi"))
                Dim TablaP As DataTable = L_prObtenerHistorialdeServiciosPolitica(tbnumiCliente.Text, TableServicioPolitica.Rows(i).Item("ednumi"))
                If (_fnTienePoliticaInsertada(_MesInicial.Month, _MesInicial.Year, NumiVenta, TablaP) = True) Then
                    Dim TableNord As DataTable = L_prObtenerNumeroOrden(NumiVenta)
                    If (TableNord.Rows.Count > 0) Then

                        GrPoliticaTabla.Rows.Add(TableServicioPolitica.Rows(i).Item("eddesc").ToString, MonthName(_MesInicial.Month), True, TableNord.Rows(0).Item("ldnord").ToString)
                    Else
                        GrPoliticaTabla.Rows.Add(TableServicioPolitica.Rows(i).Item("eddesc").ToString, MonthName(_MesInicial.Month), True, "")
                    End If

                Else
                    GrPoliticaTabla.Rows.Add(TableServicioPolitica.Rows(i).Item("eddesc").ToString, MonthName(_MesInicial.Month), False, "")
                    If (Libre = False) Then ''Aqui Verificamos que Fila esta Libre Para Seleccionar el descuento
                        PosLibre = GrPoliticaTabla.Rows.Count - 1
                        Libre = True
                    End If
                End If
                _MesInicial = _MesInicial.AddMonths(1)
            End While
        Next

        grPolitica.DataSource = GrPoliticaTabla
        grPolitica.RetrieveStructure()
        grPolitica.RootTable.Columns("Servicio").Width = 250
        With grPolitica
            .GroupByBoxVisible = False
            '.FilterRowFormatStyle.BackColor = Color.Blue
            .AllowEdit = InheritableBoolean.False
            'Diseño de la tabla
            .VisualStyle = VisualStyle.Office2007
            .SelectionMode = SelectionMode.SingleSelection
            .AlternatingColors = True
        End With
        'If (Libre = True) Then
        '    _prSeleccionarPolitica(PosLibre)
        'End If
        _prSeleccionarPolitica(PosLibre)
    End Sub
    Public Sub _prSeleccionarPolitica(poslibre As Integer)
        Dim b As Boolean = False
        Dim i As Integer = 0
        For Each _fil As Janus.Windows.GridEX.GridEXRow In grPolitica.GetRows
            Dim _estiloFila As New GridEXFormatStyle()

            If (i <> 0 And i Mod 3 = 0) Then
                If (b = False) Then
                    b = True
                Else
                    b = False

                End If
            End If
            If (b = False) Then
                _estiloFila.BackColor = Color.LightGray
                _fil.RowStyle = _estiloFila
            Else
                _estiloFila.BackColor = Color.White
                _fil.RowStyle = _estiloFila
            End If
            If (i = poslibre) Then
                _estiloFila.BackColor = Color.DodgerBlue
                _estiloFila.FontBold = TriState.True
                _estiloFila.ForeColor = Color.White
                _fil.RowStyle = _estiloFila
            End If
            '_estiloFila.BackColor = Color.DarkGray
            i += 1
        Next






    End Sub
    Public Function _fnTienePoliticaInsertada(_Mes As Integer, _Ano As Integer, ByRef NumiVenta As Integer, TableP As DataTable)
        Dim i As Integer = 0
        While (i < TableP.Rows.Count)
            Dim cant As Integer = TablaPolitica.Rows(0).Item("cfcant")
            If (TableP.Rows(i).Item("lemes") = _Mes And
               TableP.Rows(i).Item("lecant") = cant And TableP.Rows(i).Item("leano") = _Ano
                ) Then
                NumiVenta = TableP.Rows(i).Item("letcl2")

                Return True
            End If
            i += 1
        End While
        Return False
    End Function
    Public Sub _VerificarPagoAlDia(_nsoc As Integer)
        If (PagoAlDia = False And _nsoc > 0 And Automovil = False) Then
            MsgBox("El Socio Esta Sin Pagos Al Dia Por Lo Tanto El Sistema No Aplicara Ningun Tipo De Descuento y Solo Hara Su Servicios Como Cliente!", MsgBoxStyle.Exclamation, "Error")
        End If
    End Sub

    Public Function _fnSiguienteNumi()
        Dim numi As Integer = 0
        Dim dt As DataTable = CType(grDetalle.DataSource, DataTable)
        For i As Integer = 0 To dt.Rows.Count - 1 Step 1
            Dim lin As Integer = IIf(IsDBNull(dt.Rows(i).Item("lclin")), 0, dt.Rows(i).Item("lclin"))
            If (lin > numi) Then
                numi = lin
            End If

        Next
        Return numi
    End Function
    Private Sub _prAddDetalleVenta()
        '     lclin ,lcnumi ,lctce4pro,lctcl3pro  ,b.eddesc  ,lctp1emp,lctce42pro,'' as nombre 
        ',lcpuni ,lccant,lcpdes ,lcmdes ,lcptot 
        ',lcfpag ,lcppagper ,lcmpagper ,lcest,1 as estado,0 as stockminimo,0 as inventario


        CType(grDetalle.DataSource, DataTable).Rows.Add()
        Dim pos As Integer = CType(grDetalle.DataSource, DataTable).Rows.Count - 1
        If (pos >= 0) Then

            CType(grDetalle.DataSource, DataTable).Rows(pos).Item("estado") = 0
            CType(grDetalle.DataSource, DataTable).Rows(pos).Item("lclin") = _fnSiguienteNumi() + 1
            CType(grDetalle.DataSource, DataTable).Rows(pos).Item("lcnumi") = 0
            CType(grDetalle.DataSource, DataTable).Rows(pos).Item("lctce4pro") = 0
            CType(grDetalle.DataSource, DataTable).Rows(pos).Item("lctcl3pro") = 0
            CType(grDetalle.DataSource, DataTable).Rows(pos).Item("eddesc") = ""

        End If

    End Sub

    Private Sub _HabilitarServicios()
        GpPanelServicio.Visible = True
        PanelInferior.Visible = False
        If (HabilitarServicio) Then
            _prCargarAyudaServicios()
        Else
            _prCargarAyudaProductos()
        End If
        grProducto.Focus()
        grProducto.MoveTo(grProducto.FilterRow)
        grProducto.Col = 1
    End Sub
    Private Sub _DesHabilitarServicio()
        If (GpPanelServicio.Visible = True) Then
            GpPanelServicio.Visible = False
            PanelInferior.Visible = True
            grDetalle.Select()
            grDetalle.Col = 4
            grDetalle.Row = grDetalle.RowCount - 1
        End If

    End Sub
    Private Sub grDetalle_KeyDown(sender As Object, e As KeyEventArgs) Handles grDetalle.KeyDown

        If (e.KeyData = Keys.Control + Keys.Enter And grDetalle.Row >= 0 And (Not _fnVisualizarRegistros())) Then
            Dim indexfil As Integer = grDetalle.Row
            Dim indexcol As Integer = grDetalle.Col

            If (grDetalle.Col = grDetalle.RootTable.Columns("eddesc").Index) Then 'Esta en la celda de Servicio

                Dim indexfila As Integer = grDetalle.Row
                Dim indexcolu As Integer = grDetalle.Col
                grDetalle.Row = grDetalle.RowCount - 1
                If (grDetalle.Row > 0 And (Not IsDBNull(grDetalle.GetValue("lctce4pro")) Or Not IsDBNull(grDetalle.GetValue("lctcl3pro")))) Then
                    '_prAddDetalleVenta()
                End If
                HabilitarServicio = True
                _HabilitarServicios()
            End If
        End If

        If (e.KeyData = Keys.Control + Keys.A And grDetalle.Row >= 0 And (Not _fnVisualizarRegistros())) Then
            Dim indexfil As Integer = grDetalle.Row
            Dim indexcol As Integer = grDetalle.Col
            If (e.KeyData = Keys.Control + Keys.A And grDetalle.Row >= 0 And grDetalle.Col = grDetalle.RootTable.Columns("eddesc").Index) Then 'Esta en la celda de Personal
                Dim indexfila As Integer = grDetalle.Row
                Dim indexcolu As Integer = grDetalle.Col
                grDetalle.Row = grDetalle.RowCount - 1
                If (grDetalle.Row > 0 And (Not IsDBNull(grDetalle.GetValue("lctce4pro")) Or Not IsDBNull(grDetalle.GetValue("lctcl3pro")))) Then
                    ''   _prAddDetalleVenta()
                End If
                HabilitarServicio = False
                _HabilitarServicios()
            End If

        End If
    End Sub
    Public Function _prVerificarPoliticarServicio() As Double

        For i As Integer = 0 To TablaPolitica.Rows.Count - 1 Step 1 ''Recorro todas las politicas que existen en el servicio
            'Dim mesInicial = TablaPolitica.Rows(i).Item("MesInicial") ''Saco el mes inicial para recorrer de ahi hasta 3 meses mas
            'Dim mesFinal = mesInicial + 3

            Dim _MesInicial As Date = TablaPolitica.Rows(0).Item("MesInicial")
            _MesInicial = _MesInicial.AddDays(-(_MesInicial.Day) + 1)
            Dim MesFinal As Date = _MesInicial.AddMonths(3)
            While (_MesInicial <= MesFinal)
                Dim k As Integer = 0
                Dim cant As Integer = 0
                Dim CantPolitica As Integer = TablaPolitica.Rows(i).Item("cfcant")
                While (k < TablaServiciosP.Rows.Count) ''Aqui comparo los meses y cantidad por si hubiera politica libre en algun mes
                    Dim mesa As Integer = TablaServiciosP.Rows(k).Item("lemes")
                    Dim Cantidad As Integer = TablaServiciosP.Rows(k).Item("lecant")
                    If (mesa = _MesInicial.Month And _MesInicial.Year = TablaServiciosP.Rows(k).Item("leano") And cant < Cantidad) Then
                        cant = Cantidad

                    End If
                    k += 1
                End While
                ''Aqui obtengo la cantidad que valida la politica
                If (cant + 1 <= CantPolitica) Then 'Aqui comparo si en el mes hay espacio para una politica
                    If (cant + 1 = CantPolitica) Then 'Si cumple el mes que es igual a una politica la inserto en la tabla y devuelvo el porcentaje de descuento
                        'a.lenumi, a.lensoc, a.letcl2, a.letce4pro, a.leano, a.lemes, a.lecant
                        TablaGeneralServicios.Rows.Add(0, tbnumiCliente.Text, 0, TablaPolitica.Rows(i).Item("ednumi"), _MesInicial.Year, _MesInicial.Month, cant + 1, 0)

                        Return TablaPolitica.Rows(i).Item("cfdesc")
                    Else
                        TablaGeneralServicios.Rows.Add(0, tbnumiCliente.Text, 0, TablaPolitica.Rows(i).Item("ednumi"), _MesInicial.Year, _MesInicial.Month, cant + 1, 0)
                        Return 0
                    End If
                End If
                _MesInicial = _MesInicial.AddMonths(1)
            End While

        Next
        Return 0

    End Function

    Private Sub grDetalle_EditingCell(sender As Object, e As EditingCellEventArgs) Handles grDetalle.EditingCell
        If (Not _fnVisualizarRegistros()) Then
            'Habilitar solo las columnas de Precio, %, Monto y Observación
            If (e.Column.Index = grDetalle.RootTable.Columns("lccant").Index) Then
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
        If (e.Column.Index = grDetalle.RootTable.Columns("lccant").Index) Then
            If (Not IsNumeric(grDetalle.GetValue("lccant")) Or grDetalle.GetValue("lccant").ToString = String.Empty) Then

                'grDetalle.GetRow(rowIndex).Cells("cant").Value = 1
                '  grDetalle.CurrentRow.Cells.Item("cant").Value = 1
                Dim lin As Integer = grDetalle.GetValue("lclin")
                Dim pos As Integer = -1
                _prObtenerPosicionDetalle(pos, lin)
                CType(grDetalle.DataSource, DataTable).Rows(pos).Item("lccant") = 1
                CType(grDetalle.DataSource, DataTable).Rows(pos).Item("lcptot") = CType(grDetalle.DataSource, DataTable).Rows(pos).Item("lcpuni")




            Else
                If (grDetalle.GetValue("lccant") > 0) Then
                    'stockminimo
                    'If (grDetalle.GetValue("lccant") > grDetalle.GetValue("stockminimo")) Then
                    '    grDetalle.SetValue("lccant", grDetalle.GetValue("stockminimo"))


                    'Else
                    '    P_PonerTotal(rowIndex)
                    'End If

                    If (grDetalle.GetValue("lctcl3pro") > 0) Then
                        _prValidarInventario(grDetalle.Row)
                    End If




                Else
                    grDetalle.GetRow(rowIndex).Cells("lccant").Value = 1
                    _prCalcularPrecioTotal()

                End If
            End If
        End If

        If (e.Column.Index = grDetalle.RootTable.Columns("lcpdes").Index) Then
            If (Not IsNumeric(grDetalle.GetValue("lcpdes")) Or grDetalle.GetValue("lcpdes").ToString = String.Empty) Then

                Dim lin As Integer = grDetalle.GetValue("lclin")
                Dim pos As Integer = -1
                _prObtenerPosicionDetalle(pos, lin)
                Dim cantidad As Integer = grDetalle.GetValue("lccant")
                CType(grDetalle.DataSource, DataTable).Rows(pos).Item("lcpdes") = 0
                CType(grDetalle.DataSource, DataTable).Rows(pos).Item("lcmdes") = 0
                CType(grDetalle.DataSource, DataTable).Rows(pos).Item("lcptot") = CType(grDetalle.DataSource, DataTable).Rows(pos).Item("lcpuni") * cantidad
            Else
                Dim lin As Integer = grDetalle.GetValue("lclin")
                Dim pos As Integer = -1
                _prObtenerPosicionDetalle(pos, lin)
                If (grDetalle.GetValue("lcpdes") > 0) Then
                    Dim porcdesc As Double = grDetalle.GetValue("lcpdes")

                    If (porcdesc = 0 Or porcdesc > 100) Then
                        grDetalle.SetValue("lcpdes", 0)
                        grDetalle.SetValue("lcmdes", 0)
                        _prCalcularPrecioTotal()

                    Else

                        Dim TotalUnitario As Integer = CType(grDetalle.DataSource, DataTable).Rows(pos).Item("lcpuni")
                        Dim montodesc As Double = (TotalUnitario * (porcdesc / 100))
                        grDetalle.SetValue("lcmdes", montodesc)
                        _prCalcularPrecioTotal()
                    End If


                    P_PonerTotal(rowIndex)
                Else
                    grDetalle.GetRow(rowIndex).Cells("lcpdes").Value = 0
                    grDetalle.GetRow(rowIndex).Cells("lcmdes").Value = 0
                    _prCalcularPrecioTotal()
                End If
            End If
        End If

    End Sub

    Private Sub ELIMINARFILAToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Eliminarms.Click
        Dim pos As Integer = grDetalle.Row


        If grDetalle.RowCount > 1 And pos >= 0 And pos <= grDetalle.RowCount - 1 Then
            Dim estado As Integer
            Dim dt As DataTable = CType(grDetalle.DataSource, DataTable)

            Dim lin As Integer = grDetalle.GetValue("lclin")
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
                        CType(grDetalle.DataSource, DataTable).Rows(PosicionData).Item("estado") = -2


                        grDetalle.RootTable.ApplyFilter(New Janus.Windows.GridEX.GridEXFilterCondition(grDetalle.RootTable.Columns("estado"), Janus.Windows.GridEX.ConditionOperator.GreaterThanOrEqualTo, 0))
                        _prCalcularPrecioTotal()
                    Else

                        CType(grDetalle.DataSource, DataTable).Rows(PosicionData).Item("estado") = -2


                        grDetalle.RootTable.ApplyFilter(New Janus.Windows.GridEX.GridEXFilterCondition(grDetalle.RootTable.Columns("estado"), Janus.Windows.GridEX.ConditionOperator.GreaterThanOrEqualTo, 0))
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

        tbNumeroOrden.Focus()
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click

        tbNumeroOrden.Focus()

    End Sub

    Private Sub tbVehiculo_KeyDown_1(sender As Object, e As KeyEventArgs) Handles tbVehiculo.KeyDown
        If (Not _fnVisualizarRegistros() And Estado.IsReadOnly = False) Then


            If e.KeyData = Keys.Control + Keys.Enter Then

                If (tbVehiculo.Text <> String.Empty) Then

                    If (grVentasPendientes.RowCount > 0) Then
                        grVentasPendientes.Row = 0

                        tbCliente.Text = grVentasPendientes.GetValue("nombre")
                        tbnumiCliente.Text = grVentasPendientes.GetValue("lanumi")
                        tbnumiVehiculo.Text = grVentasPendientes.GetValue("lblin")
                        tbVehiculo.Text = grVentasPendientes.GetValue("lbplac")
                        Dim tipo As Object = grVentasPendientes.GetValue("lbtip1_4")
                        TableCliente = True ''Bandera para no lanzar ventana de advertencia
                        Dim TipoRegistrado As Integer = grVentasPendientes.GetValue("VehiculoRegistrado")
                        If (TipoRegistrado > 0) Then
                            cbTipo.ReadOnly = True

                        Else
                            cbTipo.ReadOnly = False
                        End If
                        If (IsDBNull(tipo)) Then
                            cbTipo.SelectedIndex = -1

                        Else
                            If (tipo > 0) Then
                                cbTipo.Value = tipo
                            Else
                                cbTipo.SelectedIndex = -1

                            End If
                        End If
                        TableCliente = False
                        Dim nsoc As Integer = grVentasPendientes.GetValue("lansoc")
                        Dim HonorarioMeritorio As Integer = grVentasPendientes.GetValue("tipo")
                        If (nsoc > 0) Then
                            tbClienteSocio.Value = False
                            Dim FechaPago As DataTable = L_prObtenerUltimoPagoSocio(nsoc)
                            lbFechaPago.Visible = True
                            tbFechaPago.Visible = True
                            If (FechaPago.Rows.Count > 0) Then
                                tbFechaPago.Text = "Mes: " + FechaPago.Rows(0).Item("semes").ToString + " Año: " + FechaPago.Rows(0).Item("seano").ToString
                                If (Now.Year = FechaPago.Rows(0).Item("seano") Or (HonorarioMeritorio = 2 Or HonorarioMeritorio = 3)) Then
                                    Dim MesSitema As Integer = FechaPago.Rows(0).Item("semes")
                                    Dim mora As Integer = FechaPago.Rows(0).Item("mora")
                                    If (((Now.Month - mora) <= MesSitema) Or (HonorarioMeritorio = 2 Or HonorarioMeritorio = 3)) Then

                                        tbFechaPago.BackColor = Color.White
                                        MEP.SetError(tbFechaPago, "")
                                        MHighlighterFocus.UpdateHighlights()
                                        lbUltimaPago.Visible = True
                                        lbUltimaPago.Text = "HABILITADO"
                                        lbUltimaPago.ForeColor = Color.DarkSlateGray
                                        PagoAlDia = True
                                        SuperTabItem2.Visible = True
                                        SuperTabControl1.SelectedTabIndex = 1
                                        _prCrearTablaPoliticajanus()
                                    Else
                                        PagoAlDia = False
                                        MEP.SetError(tbFechaPago, "Socio esta con deudas atrazas!".ToUpper)
                                        MHighlighterFocus.UpdateHighlights()
                                        tbFechaPago.BackColor = Color.Red
                                        lbUltimaPago.Visible = True
                                        lbUltimaPago.Text = "INHABILITADO"
                                        lbUltimaPago.ForeColor = Color.Red
                                        SuperTabItem2.Visible = False
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
                                    SuperTabItem2.Visible = False
                                    SuperTabControl1.SelectedTabIndex = 0
                                End If

                            Else 'Si el socio no hizo ningun pago
                                If (HonorarioMeritorio = 2 Or HonorarioMeritorio = 3) Then
                                    tbFechaPago.Clear()
                                    tbFechaPago.Text = "HONORARIO"
                                    tbFechaPago.BackColor = Color.White
                                    MEP.SetError(tbFechaPago, "")
                                    MHighlighterFocus.UpdateHighlights()
                                    lbUltimaPago.Visible = True
                                    lbUltimaPago.Text = "HABILITADO"
                                    lbUltimaPago.ForeColor = Color.DarkSlateGray
                                    PagoAlDia = True
                                    SuperTabItem2.Visible = True
                                    SuperTabControl1.SelectedTabIndex = 1
                                    _prCrearTablaPoliticajanus()
                                Else
                                    PagoAlDia = False
                                    MEP.SetError(tbFechaPago, "Socio esta con deudas atrazas!".ToUpper)
                                    MHighlighterFocus.UpdateHighlights()
                                    tbFechaPago.BackColor = Color.Red
                                    tbFechaPago.Text = "Sin Ningun Pago"
                                    lbUltimaPago.Visible = True
                                    lbUltimaPago.Text = "INHABILITADO"
                                    lbUltimaPago.ForeColor = Color.Red
                                    SuperTabItem2.Visible = False
                                    SuperTabControl1.SelectedTabIndex = 0
                                End If

                            End If
                        Else
                            tbClienteSocio.Value = True
                            tbFechaPago.Text = ""
                            lbFechaPago.Visible = False
                            tbFechaPago.Visible = False
                            lbUltimaPago.Visible = False
                            SuperTabItem2.Visible = False
                            SuperTabControl1.SelectedTabIndex = 0
                        End If

                        _VerificarPagoAlDia(nsoc)
                        Dim nameimagen As String = grVentasPendientes.GetValue("lafot")
                        If (File.Exists(RutaGlobal + "\Imagenes\Imagenes ClienteL" + nameimagen)) Then
                            Dim im As New Bitmap(New Bitmap(RutaGlobal + "\Imagenes\Imagenes ClienteL" + nameimagen))
                            UsImg.pbImage.SizeMode = PictureBoxSizeMode.StretchImage

                            UsImg.pbImage.Image = im

                        End If

                        _prCambiarEstadoItemEliminar()
                        If (grDetalle.RowCount = 0) Then
                            _prAddFilaDetalle()

                        End If
                        grDetalle.Focus()

                        grDetalle.Select()
                        grDetalle.Col = 4
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

    Private Sub cbTipo_ValueChanged(sender As Object, e As EventArgs) Handles cbTipo.ValueChanged
        Dim pos As Integer = cbTipo.SelectedIndex
        If (TableCliente = False) Then


            If (pos >= 0 And grDetalle.RowCount >= 1 And Not tbCodigo.Text = String.Empty And TipoTamano <> -1 And TipoTamano <> pos And cbTipo.ReadOnly = False) Then
                Dim mensaje As String = "Si Cambia el Tipo de Tamaño se borrara todo el detalle de la venta"
                Dim info As New TaskDialogInfo("advertencia".ToUpper, eTaskDialogIcon.Delete, "¿desea continuar?".ToUpper, mensaje.ToUpper, eTaskDialogButton.Yes Or eTaskDialogButton.No, eTaskDialogBackgroundColor.Blue)
                Dim result As eTaskDialogResult = TaskDialog.Show(info)
                If result = eTaskDialogResult.Yes Then
                    _fnValidarNuevoCliente() ''Aqui hacemos si cambia el tamaño del vehiculo y existia detalle lo eliminamos
                    TipoTamano = cbTipo.SelectedIndex


                Else

                    cbTipo.SelectedIndex = TipoTamano

                End If
            Else
                If (pos >= 0 And grDetalle.RowCount >= 1 And tbCodigo.Text = String.Empty And cbTipo.ReadOnly = False) Then


                    _fnValidarNuevoCliente() ''Aqui hacemos si cambia el tamaño del vehiculo y existia detalle lo eliminamos
                    TipoTamano = cbTipo.SelectedIndex

                End If


            End If
        End If
    End Sub

    Private Sub grDetalle_CellValueChanged(sender As Object, e As ColumnActionEventArgs) Handles grDetalle.CellValueChanged
        '' grDetalle.GetRow(grDetalle.Row).BeginEdit()

        ''Dim rowIndex As Integer = grDetalle.CurrentRow.RowIndex
        Dim rowIndex As Integer = grDetalle.Row
        'Columna de Precio Venta
        If (Not grDetalle.GetValue("lccant").ToString = String.Empty) Then


            If (e.Column.Index = grDetalle.RootTable.Columns("lccant").Index) Then
                Dim ob As Object = grDetalle.GetValue("lccant")

                If (Not IsNumeric(grDetalle.GetValue("lccant"))) Then

                    grDetalle.SetValue("lccant", 1)
                    'grDetalle.GetRow(rowIndex).Cells("cant").Value = 1
                    ''  grDetalle.CurrentRow.Cells.Item("cant").Value = 1




                Else
                    If (grDetalle.GetValue("lccant") > 0) Then

                        Dim idprod As Integer = grDetalle.GetValue("lctcl3pro")
                        If (idprod > 0) Then

                            '' _prValidarInventario(rowIndex)

                            P_PonerTotal(rowIndex)
                        Else
                            P_PonerTotal(rowIndex)

                        End If





                    Else
                        grDetalle.GetRow(rowIndex).Cells("lccant").Value = 1
                        _prCalcularPrecioTotal()

                    End If
                End If
            End If
        Else

            Dim lin As Integer = grDetalle.GetValue("lclin")
            Dim pos As Integer = -1
            _prObtenerPosicionDetalle(pos, lin)

            CType(grDetalle.DataSource, DataTable).Rows(pos).Item("lccant") = 1
            CType(grDetalle.DataSource, DataTable).Rows(pos).Item("lcptot") = CType(grDetalle.DataSource, DataTable).Rows(pos).Item("lcpuni")


        End If
        '' AQUI CALCULAMOS EL PORCENTAJE DE DESCUENTO
        If (e.Column.Index = grDetalle.RootTable.Columns("lcpdes").Index) Then
            If (Not IsNumeric(grDetalle.GetValue("lcpdes")) Or grDetalle.GetValue("lcpdes").ToString = String.Empty) Then

                Dim lin As Integer = grDetalle.GetValue("lclin")
                Dim pos As Integer = -1
                _prObtenerPosicionDetalle(pos, lin)
                Dim cantidad As Integer = grDetalle.GetValue("lccant")
                CType(grDetalle.DataSource, DataTable).Rows(pos).Item("lcpdes") = 0
                CType(grDetalle.DataSource, DataTable).Rows(pos).Item("lcmdes") = 0
                CType(grDetalle.DataSource, DataTable).Rows(pos).Item("lcptot") = CType(grDetalle.DataSource, DataTable).Rows(pos).Item("lcpuni") * cantidad
            Else
                Dim lin As Integer = grDetalle.GetValue("lclin")
                Dim pos As Integer = -1
                _prObtenerPosicionDetalle(pos, lin)
                If (grDetalle.GetValue("lcpdes") > 0) Then
                    Dim porcdesc As Double = grDetalle.GetValue("lcpdes")

                    If (porcdesc = 0 Or porcdesc > 100) Then
                        grDetalle.SetValue("lcpdes", 0)
                        grDetalle.SetValue("lcmdes", 0)
                        P_PonerTotal(rowIndex)

                    Else

                        Dim TotalUnitario As Double = grDetalle.GetValue("lcpuni") * grDetalle.GetValue("lccant")
                        Dim montodesc As Double = (TotalUnitario * (porcdesc / 100))
                        grDetalle.SetValue("lcmdes", montodesc)
                        P_PonerTotal(rowIndex)
                    End If

                    _prCalcularPrecioTotal()

                Else
                    grDetalle.GetRow(rowIndex).Cells("lcpdes").Value = 0
                    grDetalle.GetRow(rowIndex).Cells("lcmdes").Value = 0
                    _prCalcularPrecioTotal()
                End If
            End If
        End If



        '' AQUI CALCULAMOS EL MONTO DE DESCUENTO
        If (e.Column.Index = grDetalle.RootTable.Columns("lcmdes").Index) Then
            If (Not IsNumeric(grDetalle.GetValue("lcmdes")) Or grDetalle.GetValue("lcmdes").ToString = String.Empty) Then

                Dim lin As Integer = grDetalle.GetValue("lclin")
                Dim pos As Integer = -1
                _prObtenerPosicionDetalle(pos, lin)
                Dim cantidad As Double = grDetalle.GetValue("lccant")
                CType(grDetalle.DataSource, DataTable).Rows(pos).Item("lcpdes") = 0
                CType(grDetalle.DataSource, DataTable).Rows(pos).Item("lcmdes") = 0
                CType(grDetalle.DataSource, DataTable).Rows(pos).Item("lcptot") = CType(grDetalle.DataSource, DataTable).Rows(pos).Item("lcpuni") * cantidad
            Else
                Dim lin As Integer = grDetalle.GetValue("lclin")
                Dim pos As Integer = -1
                _prObtenerPosicionDetalle(pos, lin)
                If (grDetalle.GetValue("lcmdes") > 0) Then
                    Dim mondesc As Double = grDetalle.GetValue("lcmdes")
                    Dim total As Double = grDetalle.GetValue("lcpuni") * grDetalle.GetValue("lccant")
                    If (mondesc = 0 Or mondesc > total) Then
                        grDetalle.SetValue("lcpdes", 0)
                        grDetalle.SetValue("lcmdes", 0)
                        _prCalcularPrecioTotal()

                    Else

                        Dim TotalUnitario As Double = grDetalle.GetValue("lcpuni") * grDetalle.GetValue("lccant")
                        Dim pordesc As Double = ((mondesc * 100) / TotalUnitario)
                        grDetalle.SetValue("lcpdes", pordesc)

                        _prCalcularPrecioTotal()
                    End If


                    P_PonerTotal(rowIndex)
                Else
                    grDetalle.GetRow(rowIndex).Cells("lcpdes").Value = 0
                    grDetalle.GetRow(rowIndex).Cells("lcmdes").Value = 0
                    _prCalcularPrecioTotal()
                End If
            End If
        End If
    End Sub

    Private Sub ButtonX3_Click(sender As Object, e As EventArgs) Handles btnAnadir.Click

        Dim frm As New F_ClienteNuevoServicio
        Dim dt As DataTable
        frm.placaV = tbVehiculo.Text
        frm.ShowDialog()
        Dim placa As String = frm.placaV

        If (frm.Cliente = True) Then ''Aqui Consulto si se inserto un nuevo Cliente cargo sus datos del nuevo cliente insertado

            dt = L_prServicioVentaAyudaVehiculo(placa)
            If (dt.Rows.Count > 0) Then
                tbCliente.Text = dt.Rows(0).Item("nombre")
                tbnumiCliente.Text = dt.Rows(0).Item("lanumi")
                tbnumiVehiculo.Text = dt.Rows(0).Item("lblin")
                tbVehiculo.Text = placa
                TableCliente = True
                cbTipo.Value = dt.Rows(0).Item("lbtip1_4")
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
                grDetalle.Col = 4
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

                cbTipo.SelectedIndex = -1
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
                    grVentasPendientes.RootTable.ApplyFilter(New Janus.Windows.GridEX.GridEXFilterCondition(grVentasPendientes.RootTable.Columns("lbplac"), Janus.Windows.GridEX.ConditionOperator.Contains, tbVehiculo.Text))

                End If

            End If
        End If

    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        _prImprimir(tbCodigo.Text)
    End Sub
    Private Sub cbTipo_MouseClick(sender As Object, e As MouseEventArgs) Handles cbTipo.MouseClick

        If (tbnumiVehiculo.Text = 0) Then
            tbVehiculo.Focus()

            ToastNotification.Show(Me, "           Antes De Continuar Por favor Seleccione un Vehiculo !!             ", My.Resources.WARNING, 4000, eToastGlowColor.Red, eToastPosition.TopCenter)
            Return

        End If

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



    Private Sub grVentasPendientes_KeyDown(sender As Object, e As KeyEventArgs) Handles grVentasPendientes.KeyDown

        If (_fnAccesible() And tbTablet.Value = False) Then
            If (e.KeyData = Keys.Enter) Then
                If (grVentasPendientes.RowCount > 0) Then
                    tbCliente.Text = grVentasPendientes.GetValue("nombre")
                    tbnumiCliente.Text = grVentasPendientes.GetValue("lanumi")
                    tbnumiVehiculo.Text = grVentasPendientes.GetValue("lblin")
                    tbVehiculo.Text = grVentasPendientes.GetValue("lbplac")
                    If (grVentasPendientes.GetValue("acb") = 1) Then
                        Automovil = True
                    Else
                        Automovil = False
                    End If
                    Dim tipo As Object = grVentasPendientes.GetValue("lbtip1_4")
                    TableCliente = True ''Coloco esta bandera para que no me lanze la advertencia por si cargo otro vehiculo con otro tipo de tamaño
                    Dim HonorarioMeritorio As Integer = grVentasPendientes.GetValue("tipo")
                    If (IsDBNull(tipo)) Then
                        cbTipo.SelectedIndex = -1

                    Else
                        If (tipo > 0) Then
                            cbTipo.Value = tipo
                        Else
                            cbTipo.SelectedIndex = -1

                        End If
                        TableCliente = False
                    End If



                    Dim nameimagen As String = grVentasPendientes.GetValue("lafot")
                    If (File.Exists(RutaGlobal + "\Imagenes\Imagenes ClienteL" + nameimagen)) Then
                        Dim im As New Bitmap(New Bitmap(RutaGlobal + "\Imagenes\Imagenes ClienteL" + nameimagen))
                        UsImg.pbImage.SizeMode = PictureBoxSizeMode.StretchImage

                        UsImg.pbImage.Image = im

                    End If
                    Dim nsoc As Integer = grVentasPendientes.GetValue("lansoc")
                    If (nsoc > 0) Then
                        tbClienteSocio.Value = False
                        Dim FechaPago As DataTable = L_prObtenerUltimoPagoSocio(nsoc)
                        lbFechaPago.Visible = True
                        tbFechaPago.Visible = True
                        If (FechaPago.Rows.Count > 0) Then

                            tbFechaPago.Text = "Mes: " + FechaPago.Rows(0).Item("semes").ToString + " Año: " + FechaPago.Rows(0).Item("seano").ToString

                            If (Now.Year = FechaPago.Rows(0).Item("seano") Or Now.Year = FechaPago.Rows(0).Item("seano") + 1 Or (HonorarioMeritorio = 2 Or HonorarioMeritorio = 3)) Then
                                Dim MesSitema As Integer = FechaPago.Rows(0).Item("semes")
                                Dim mora As Integer = FechaPago.Rows(0).Item("mora")

                                Dim FechaDePago As Date = New Date(FechaPago.Rows(0).Item("seano"), FechaPago.Rows(0).Item("semes"), 1)
                                Dim fecha As Date = Date.Now.AddMonths(-mora)
                                fecha = fecha.AddDays(-(fecha.Day) + 1)
                                If ((fecha <= FechaDePago) Or (HonorarioMeritorio = 2 Or HonorarioMeritorio = 3)) Then

                                    tbFechaPago.BackColor = Color.White
                                    MEP.SetError(tbFechaPago, "")
                                    MHighlighterFocus.UpdateHighlights()
                                    lbUltimaPago.Visible = True
                                    lbUltimaPago.Text = "HABILITADO"
                                    lbUltimaPago.ForeColor = Color.DarkSlateGray
                                    PagoAlDia = True
                                    SuperTabItem2.Visible = True
                                    SuperTabControl1.SelectedTabIndex = 1
                                    _prCrearTablaPoliticajanus()
                                Else

                                    MEP.SetError(tbFechaPago, "Socio esta con deudas atrazas!".ToUpper)
                                    MHighlighterFocus.UpdateHighlights()
                                    tbFechaPago.BackColor = Color.Red
                                    lbUltimaPago.Visible = True
                                    lbUltimaPago.Text = "INHABILITADO"
                                    lbUltimaPago.ForeColor = Color.Red
                                    PagoAlDia = False
                                    SuperTabItem2.Visible = False
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
                                SuperTabItem2.Visible = False
                                SuperTabControl1.SelectedTabIndex = 0
                            End If

                        Else 'Si el socio no hizo ningun pago

                            If (Automovil = True) Then ''Si el cliente es un vehiculo del automovil puede hacer su servicio libremente
                                tbFechaPago.Clear()
                                tbFechaPago.Text = "ACB"
                                tbFechaPago.BackColor = Color.White
                                MEP.SetError(tbFechaPago, "")
                                MHighlighterFocus.UpdateHighlights()
                                lbUltimaPago.Visible = True
                                lbUltimaPago.Text = "HABILITADO"
                                lbUltimaPago.ForeColor = Color.DarkSlateGray
                                ''   PagoAlDia = True



                            Else
                                If (HonorarioMeritorio = 2 Or HonorarioMeritorio = 3) Then
                                    tbFechaPago.Clear()
                                    tbFechaPago.Text = "HONORARIO"
                                    tbFechaPago.BackColor = Color.White
                                    MEP.SetError(tbFechaPago, "")
                                    MHighlighterFocus.UpdateHighlights()
                                    lbUltimaPago.Visible = True
                                    lbUltimaPago.Text = "HABILITADO"
                                    lbUltimaPago.ForeColor = Color.DarkSlateGray
                                    PagoAlDia = True
                                    SuperTabItem2.Visible = True
                                    SuperTabControl1.SelectedTabIndex = 1
                                    _prCrearTablaPoliticajanus()
                                Else
                                    MEP.SetError(tbFechaPago, "Socio esta con deudas atrazas!".ToUpper)
                                    MHighlighterFocus.UpdateHighlights()
                                    tbFechaPago.BackColor = Color.Red
                                    tbFechaPago.Text = "Sin Ningun Pago"
                                    lbUltimaPago.Visible = True
                                    lbUltimaPago.Text = "INHABILITADO"
                                    lbUltimaPago.ForeColor = Color.Red
                                    PagoAlDia = False
                                    SuperTabItem2.Visible = False
                                    SuperTabControl1.SelectedTabIndex = 0
                                End If

                            End If

                        End If
                    Else
                        tbClienteSocio.Value = True
                        tbFechaPago.Text = ""
                        lbFechaPago.Visible = False
                        tbFechaPago.Visible = False
                        lbUltimaPago.Visible = False
                        SuperTabItem2.Visible = False
                        SuperTabControl1.SelectedTabIndex = 0
                    End If
                    Dim TipoRegistrado As Integer = grVentasPendientes.GetValue("VehiculoRegistrado")
                    If (TipoRegistrado > 0) Then
                        cbTipo.ReadOnly = True

                    Else
                        cbTipo.ReadOnly = False
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
                    grDetalle.Col = 4
                    grDetalle.Row = 0
                End If




            End If
        End If

    End Sub
#End Region



    Public Sub _fnObtenerFilaDetalle(ByRef pos As Integer, numi As Integer)
        For i As Integer = 0 To CType(grDetalle.DataSource, DataTable).Rows.Count - 1 Step 1
            Dim _numi As Integer = CType(grDetalle.DataSource, DataTable).Rows(i).Item("lclin")
            If (_numi = numi) Then
                pos = i
                Return
            End If
        Next

    End Sub
    Public Function _fnAccesible() As Boolean
        Return Estado.IsReadOnly = False
    End Function


    Public Sub _prCargarServicioRecepcion(_dt As DataTable)

        For i As Integer = 0 To _dt.Rows.Count - 1 Step 1

            Dim idServ As String = _dt.Rows(i).Item("ednumi")
            Dim descr As String = _dt.Rows(i).Item("eddesc")
            Dim precio As Double = _dt.Rows(i).Item("eqprecio")
            Dim IdDetalleServicio As Integer = _dt.Rows(i).Item("NumiDetalleServicio")

            Dim existe As Boolean = _prBuscarExisteNumiServ(idServ)
            Dim pos As Integer = -1
            If ((Not existe)) Then
                Dim dt As DataTable = CType(grDetalle.DataSource, DataTable)
                If ((grDetalle.GetValue("lctce4pro") > 0 Or grDetalle.GetValue("lctcl3pro") > 0)) Then
                    _prAddDetalleVenta()
                End If
                grDetalle.Row = grDetalle.RowCount - 1
                Dim lin As Integer = grDetalle.GetValue("lclin")
                _prObtenerPosicionDetalle(pos, lin)
                If (pos >= 0) Then
                    CType(grDetalle.DataSource, DataTable).Rows(pos).Item("lctce4pro") = idServ
                    CType(grDetalle.DataSource, DataTable).Rows(pos).Item("eddesc") = descr
                    CType(grDetalle.DataSource, DataTable).Rows(pos).Item("lcpuni") = precio
                    CType(grDetalle.DataSource, DataTable).Rows(pos).Item("lccant") = 1
                    CType(grDetalle.DataSource, DataTable).Rows(pos).Item("lctce42pro") = IdDetalleServicio
                    CType(grDetalle.DataSource, DataTable).Rows(pos).Item("lctcl3pro") = 0

                    Dim posicion As Integer = -1
                    TablaPolitica = L_prExistePoliticaDescuentoServicio(tbnumiCliente.Text, idServ)
                    _prBuscarDescuentoEliminadoNumiServ(posicion, idServ) ''LLamo a este procedimiento si existe un detalle eliminado con porcentaje de descuento para añadirle el mismo porcentaje al nuevo servicio seleccionado
                    If (TablaPolitica.Rows.Count > 0 And posicion = -1 And PagoAlDia = True) Then ''Aqui pregunto si Existe politica para un servicio y si el cliente es socio por que solo existe descuento para socios

                        TablaServiciosP = L_prObtenerHistorialdeServiciosPolitica(tbnumiCliente.Text, idServ)
                        ''  _prCrearTablaPoliticajanus()
                        Dim PorDesc As Double = _prVerificarPoliticarServicio()

                        If (PorDesc > 0) Then
                            Dim porcentajeDescuento As Double = PorDesc
                            Dim MontoDescuento As Double = (precio * (porcentajeDescuento / 100))
                            CType(grDetalle.DataSource, DataTable).Rows(pos).Item("lcpdes") = porcentajeDescuento
                            CType(grDetalle.DataSource, DataTable).Rows(pos).Item("lcmdes") = MontoDescuento
                            CType(grDetalle.DataSource, DataTable).Rows(pos).Item("lcptot") = precio - MontoDescuento

                        Else
                            CType(grDetalle.DataSource, DataTable).Rows(pos).Item("lcptot") = precio
                        End If

                    Else



                        If (posicion >= 0) Then
                            Dim porcentajeDescuento As Double = CType(grDetalle.DataSource, DataTable).Rows(posicion).Item("lcpdes")
                            Dim MontoDescuento As Double = (precio * (porcentajeDescuento / 100))
                            CType(grDetalle.DataSource, DataTable).Rows(pos).Item("lcpdes") = porcentajeDescuento
                            CType(grDetalle.DataSource, DataTable).Rows(pos).Item("lcmdes") = MontoDescuento
                            CType(grDetalle.DataSource, DataTable).Rows(pos).Item("lcptot") = precio - MontoDescuento

                        Else
                            If (Automovil = True) Then ''''''Socios del acb
                                Dim porcentajeDescuento As Double = 100
                                Dim MontoDescuento As Double = (precio * (porcentajeDescuento / 100))
                                CType(grDetalle.DataSource, DataTable).Rows(pos).Item("lcpdes") = porcentajeDescuento
                                CType(grDetalle.DataSource, DataTable).Rows(pos).Item("lcmdes") = MontoDescuento
                                CType(grDetalle.DataSource, DataTable).Rows(pos).Item("lcptot") = precio - MontoDescuento
                            Else
                                CType(grDetalle.DataSource, DataTable).Rows(pos).Item("lcptot") = precio
                            End If
                        End If

                    End If

                    Dim estado = CType(grDetalle.DataSource, DataTable).Rows(pos).Item("estado")
                    If (estado = 1) Then
                        CType(grDetalle.DataSource, DataTable).Rows(pos).Item("estado") = 2
                    End If


                End If

                If (grDetalle.FocusCellFormatStyle.BackColor = Color.Red) Then
                    grDetalle.FocusCellFormatStyle.BackColor = DefaultBackColor
                End If

                ''_prCargarClientes()



            End If


        Next




    End Sub

    Public Sub _prServiciosAgregar()
        Dim f, c As Integer
        c = grProducto.Col
        f = grProducto.Row

        If (f >= 0) Then



            Dim existe As Boolean = _prBuscarExisteNumiServ(grProducto.GetValue("ednumi"))

            Dim idServ As String = grProducto.GetValue("ednumi")
            Dim descr As String = grProducto.GetValue("eddesc")
            Dim precio As Double = grProducto.GetValue("eqprecio")
            Dim IdDetalleServicio As Integer = grProducto.GetValue("NumiDetalleServicio")

            Dim pos As Integer = -1
            If ((Not existe)) Then
                Dim dt As DataTable = CType(grDetalle.DataSource, DataTable)
                If ((grDetalle.GetValue("lctce4pro") > 0 Or grDetalle.GetValue("lctcl3pro") > 0)) Then
                    _prAddDetalleVenta()
                End If
                grDetalle.Row = grDetalle.RowCount - 1
                Dim lin As Integer = grDetalle.GetValue("lclin")
                _prObtenerPosicionDetalle(pos, lin)
                If (pos >= 0) Then
                    CType(grDetalle.DataSource, DataTable).Rows(pos).Item("lctce4pro") = idServ
                    CType(grDetalle.DataSource, DataTable).Rows(pos).Item("eddesc") = descr
                    CType(grDetalle.DataSource, DataTable).Rows(pos).Item("lcpuni") = precio
                    CType(grDetalle.DataSource, DataTable).Rows(pos).Item("lccant") = 1
                    CType(grDetalle.DataSource, DataTable).Rows(pos).Item("lctce42pro") = IdDetalleServicio
                    CType(grDetalle.DataSource, DataTable).Rows(pos).Item("lctcl3pro") = 0

                    Dim posicion As Integer = -1
                    TablaPolitica = L_prExistePoliticaDescuentoServicio(tbnumiCliente.Text, idServ)
                    _prBuscarDescuentoEliminadoNumiServ(posicion, idServ) ''LLamo a este procedimiento si existe un detalle eliminado con porcentaje de descuento para añadirle el mismo porcentaje al nuevo servicio seleccionado
                    If (TablaPolitica.Rows.Count > 0 And posicion = -1 And PagoAlDia = True) Then ''Aqui pregunto si Existe politica para un servicio y si el cliente es socio por que solo existe descuento para socios

                        TablaServiciosP = L_prObtenerHistorialdeServiciosPolitica(tbnumiCliente.Text, idServ)
                        ''  _prCrearTablaPoliticajanus()
                        Dim PorDesc As Double = _prVerificarPoliticarServicio()

                        If (PorDesc > 0) Then
                            Dim porcentajeDescuento As Double = PorDesc
                            Dim MontoDescuento As Double = (precio * (porcentajeDescuento / 100))
                            CType(grDetalle.DataSource, DataTable).Rows(pos).Item("lcpdes") = porcentajeDescuento
                            CType(grDetalle.DataSource, DataTable).Rows(pos).Item("lcmdes") = MontoDescuento
                            CType(grDetalle.DataSource, DataTable).Rows(pos).Item("lcptot") = precio - MontoDescuento

                        Else
                            CType(grDetalle.DataSource, DataTable).Rows(pos).Item("lcptot") = precio
                        End If

                    Else


                        If (posicion >= 0) Then
                            Dim porcentajeDescuento As Double = CType(grDetalle.DataSource, DataTable).Rows(posicion).Item("lcpdes")
                            Dim MontoDescuento As Double = (precio * (porcentajeDescuento / 100))
                            CType(grDetalle.DataSource, DataTable).Rows(pos).Item("lcpdes") = porcentajeDescuento
                            CType(grDetalle.DataSource, DataTable).Rows(pos).Item("lcmdes") = MontoDescuento
                            CType(grDetalle.DataSource, DataTable).Rows(pos).Item("lcptot") = precio - MontoDescuento

                        Else
                            If (Automovil = True) Then ''''''Socios del acb
                                Dim porcentajeDescuento As Double = 100
                                Dim MontoDescuento As Double = (precio * (porcentajeDescuento / 100))
                                CType(grDetalle.DataSource, DataTable).Rows(pos).Item("lcpdes") = porcentajeDescuento
                                CType(grDetalle.DataSource, DataTable).Rows(pos).Item("lcmdes") = MontoDescuento
                                CType(grDetalle.DataSource, DataTable).Rows(pos).Item("lcptot") = precio - MontoDescuento
                            Else
                                CType(grDetalle.DataSource, DataTable).Rows(pos).Item("lcptot") = precio
                            End If


                        End If

                    End If

                    Dim estado = CType(grDetalle.DataSource, DataTable).Rows(pos).Item("estado")
                    If (estado = 1) Then
                        CType(grDetalle.DataSource, DataTable).Rows(pos).Item("estado") = 2
                    End If


                End If

                If (grDetalle.FocusCellFormatStyle.BackColor = Color.Red) Then
                    grDetalle.FocusCellFormatStyle.BackColor = DefaultBackColor
                End If

                ''_prCargarClientes()

                _prCargarAyudaServicios()
                grProducto.RemoveFilters()
                grProducto.Focus()
                grProducto.MoveTo(grProducto.FilterRow)
                grProducto.Col = 1
            Else
                If (existe) Then
                    Dim img As Bitmap = New Bitmap(My.Resources.Mensaje, 50, 50)
                    ToastNotification.Show(Me, "El producto ya existe en el detalle".ToUpper, img, 2000, eToastGlowColor.Red, eToastPosition.BottomCenter)
                    grProducto.RemoveFilters()
                    grProducto.Focus()
                    grProducto.MoveTo(grProducto.FilterRow)
                    grProducto.Col = 1
                End If
            End If
        End If
    End Sub
    Public Sub _prProductosAgregar()

        Dim dt As DataTable = CType(grProducto.DataSource, DataTable)
        Dim idProd As String = grProducto.GetValue("ldnumi")
        Dim descr As String = grProducto.GetValue("ldcdprod1")
        Dim precio As Double = grProducto.GetValue("ldprev")

        Dim pos As Integer = -1
        grDetalle.Row = grDetalle.RowCount - 1
        If (Not _prBuscarExisteNumiProd(idProd)) Then



            If (grProducto.GetValue("inventario") <= 0) Then
                Dim mensaje As String = "EL PRODUCTO NO CUENTA CON STOCK POR FAVOR INGRESE MAS CANTIDAD DEL MISMO"
                ToastNotification.Show(Me, mensaje.ToUpper, My.Resources.WARNING, 5000, eToastGlowColor.Red, eToastPosition.BottomCenter)
                Return
            End If



            If ((grDetalle.GetValue("lctce4pro") > 0 Or grDetalle.GetValue("lctcl3pro") > 0)) Then
                _prAddDetalleVenta()
            End If
            grDetalle.Row = grDetalle.RowCount - 1
            Dim lin As Integer = grDetalle.GetValue("lclin")
            _prObtenerPosicionDetalle(pos, lin)


            If (pos >= 0) Then


                CType(grDetalle.DataSource, DataTable).Rows(pos).Item("lctcl3pro") = idProd
                CType(grDetalle.DataSource, DataTable).Rows(pos).Item("eddesc") = descr
                CType(grDetalle.DataSource, DataTable).Rows(pos).Item("lcpuni") = precio
                CType(grDetalle.DataSource, DataTable).Rows(pos).Item("lccant") = 1
                CType(grDetalle.DataSource, DataTable).Rows(pos).Item("lctce42pro") = 0
                CType(grDetalle.DataSource, DataTable).Rows(pos).Item("lctce4pro") = 0
                Dim MontoDescuento As Double = 0
                If (Automovil = True) Then ''''''Socios del acb
                    Dim porcentajeDescuento As Double = 100
                    MontoDescuento = (precio * (porcentajeDescuento / 100))
                    CType(grDetalle.DataSource, DataTable).Rows(pos).Item("lcpdes") = porcentajeDescuento
                    CType(grDetalle.DataSource, DataTable).Rows(pos).Item("lcmdes") = MontoDescuento

                End If
                CType(grDetalle.DataSource, DataTable).Rows(pos).Item("lcptot") = precio - MontoDescuento
                CType(grDetalle.DataSource, DataTable).Rows(pos).Item("stockminimo") = grProducto.GetValue("ldsmin")
                CType(grDetalle.DataSource, DataTable).Rows(pos).Item("inventario") = grProducto.GetValue("inventario")

            End If

            If (grDetalle.FocusCellFormatStyle.BackColor = Color.Red) Then
                grDetalle.FocusCellFormatStyle.BackColor = DefaultBackColor
            End If

            _prCargarAyudaProductos()
            grProducto.RemoveFilters()
            grProducto.Focus()
            grProducto.MoveTo(grProducto.FilterRow)
            grProducto.Col = 1
        End If

    End Sub
    Private Sub grProducto_KeyDown(sender As Object, e As KeyEventArgs) Handles grProducto.KeyDown
        If (Not _fnAccesible()) Then
            Return
        End If
        If (e.KeyData = Keys.Enter) Then
            If (HabilitarServicio) Then
                _prServiciosAgregar()
            Else
                _prProductosAgregar()
            End If
        End If
        If e.KeyData = Keys.Escape Then
            _DesHabilitarServicio()

        End If
    End Sub

    Private Sub tbTablet_ValueChanged(sender As Object, e As EventArgs) Handles tbTablet.ValueChanged
        If (Not _fnActionNuevo() And _fnAccesible()) Then
            Return
        End If
        If (tbTablet.Value = True) Then

            If (_fnActionNuevo() And tbCliente.Text <> String.Empty) Then
                _limpiarTablet()
                tbVehiculo.ReadOnly = True
                cbTipo.ReadOnly = True
                tbNumeroOrden.Focus()
                btnAnadir.Visible = False
                tbNumeroOrden.ReadOnly = True
            End If
            '_limpiarTablet()
            SupTabItemBusqueda.Visible = True
        Else
            '_prLimpiarOrden()

            '_PMOLimpiar()
            If (_fnActionNuevo() And tbCliente.Text <> String.Empty) Then
                _limpiarTablet()
                cbTipo.ReadOnly = False
                tbVehiculo.ReadOnly = False
                btnAnadir.Visible = True
                tbNumeroOrden.ReadOnly = False
                tbNumeroOrden.Focus()
                tbVehiculo.Focus()
            End If
            SupTabItemBusqueda.Visible = False
        End If
    End Sub
    Public Sub _limpiarTablet()
        tbCliente.Text = ""
        tbnumiCliente.Text = 0
        tbnumiVehiculo.Text = 0
        tbVehiculo.Text = ""
        tbCodigo.Text = ""
        'FechaVenta.Text = DateTime.Now.ToString("dd/MM/yyyy")
        FechaVenta.Value = Now.Date
        cbTipo.SelectedIndex = -1
        TipoTamano = -1
        tbNumeroOrden.Text = ""
        Estado.Value = False
        Dim img As New Bitmap(New Bitmap(My.Resources.imageDefault), 180, 157)
        UsImg.pbImage.Image = img

        _prCargarGridDetalle(-1)
        _prAddFilaDetalle()

        ButtonX1.Visible = False
        ButtonX2.Visible = False
        _prCargarGridAyudaPlacaCLiente()
        tbFechaPago.Text = ""
        lbFechaPago.Visible = False
        tbFechaPago.Visible = False
        tbClienteSocio.Value = True
        SuperTabControl1.SelectedTabIndex = 0
        SuperTabItem2.Visible = False
        If (grPolitica.RowCount > 0) Then
            CType(grPolitica.DataSource, DataTable).Rows.Clear()
        End If
        TipoTamano = -1
        TablaGeneralServicios = L_prObtenerHistorialdeServiciosPolitica(-1, 0)
        PagoAlDia = False

    End Sub


    Private Sub tbNumeroOrden_KeyDown(sender As Object, e As KeyEventArgs) Handles tbNumeroOrden.KeyDown


        If (_fnAccesible() And tbTablet.Value = True) Then
            If e.KeyData = Keys.Control + Keys.Enter Then

                Dim dt As DataTable

                dt = L_prServicioVentaNumeroOrdenGeneral()
                '             a.lfnumi ,a.lftcl1soc,cliente.lanom as nombre ,a.lffecha ,a.lfcl1veh,
                'vehiculo.lbplac as placa,vehiculo .lbtip1_4 ,MarcaCliente .cedesc1 ,a.lfcomb ,a.lfobs ,
                'a.lftipo ,a.lftam ,a.lffact ,a.lfhact ,a.lfuact ,cliente.lansoc 

                Dim listEstCeldas As New List(Of Modelos.Celda)

                listEstCeldas.Add(New Modelos.Celda("lfnumi", True, "ID", 50))
                listEstCeldas.Add(New Modelos.Celda("lftcl1soc,", False, "ID", 50))
                listEstCeldas.Add(New Modelos.Celda("nombre", True, "NOMBRE DEL CLIENTE", 280))
                listEstCeldas.Add(New Modelos.Celda("lffecha,", True, "FECHA", 100, "yyyy/MM/dd"))
                listEstCeldas.Add(New Modelos.Celda("lfcl1veh,", False, "ID", 50))
                listEstCeldas.Add(New Modelos.Celda("placa", True, "PLACA".ToUpper, 150))
                listEstCeldas.Add(New Modelos.Celda("lbtip1_4", False, "".ToUpper, 200))
                listEstCeldas.Add(New Modelos.Celda("cedesc1", True, "MARCA", 100))
                listEstCeldas.Add(New Modelos.Celda("lfcomb", False, "".ToUpper, 200))
                listEstCeldas.Add(New Modelos.Celda("lfobs", False, "".ToUpper, 200))
                listEstCeldas.Add(New Modelos.Celda("lftipo", False, "".ToUpper, 200))
                listEstCeldas.Add(New Modelos.Celda("lftam", False, "".ToUpper, 200))
                listEstCeldas.Add(New Modelos.Celda("lffact", False, "".ToUpper, 200))
                listEstCeldas.Add(New Modelos.Celda("lfhact", False, "".ToUpper, 200))
                listEstCeldas.Add(New Modelos.Celda("lfuact", False, "".ToUpper, 200))
                listEstCeldas.Add(New Modelos.Celda("lansoc", False, "".ToUpper, 200))
                listEstCeldas.Add(New Modelos.Celda("tipo", False, "".ToUpper, 200))
                listEstCeldas.Add(New Modelos.Celda("acb", False, "".ToUpper, 200))
                listEstCeldas.Add(New Modelos.Celda("estado", True, "Estado".ToUpper, 120))
                Dim ef = New EfectoAyuda
                ef.tipo = 5
                ef.dt = dt
                ef.SeleclCol = 2
                ef.listEstCeldas = listEstCeldas
                ef.alto = 50
                ef.ancho = 350
                ef.Context = "Seleccione Cliente".ToUpper
                ef.ShowDialog()
                Dim bandera As Boolean = False
                bandera = ef.band
                If (bandera = True) Then
                    Dim Row As Janus.Windows.GridEX.GridEXRow = ef.Row
                    tbNumeroOrden.Text = Row.Cells("lfnumi").Value
                    tbCliente.Text = Row.Cells("nombre").Value
                    tbnumiCliente.Text = Row.Cells("lftcl1soc").Value
                    tbnumiVehiculo.Text = Row.Cells("lfcl1veh").Value
                    tbVehiculo.Text = Row.Cells("placa").Value
                    Dim tipo As Object = Row.Cells("lbtip1_4").Value
                    TableCliente = True ''Bandera para no lanzar ventana de advertencia
                    cbTipo.ReadOnly = False
                    _prCargarDatosNOrden()
                    If (Row.Cells("acb").Value = 1) Then
                        Automovil = True
                    Else
                        Automovil = False
                    End If

                    If (IsDBNull(tipo)) Then
                        cbTipo.SelectedIndex = -1

                    Else
                        If (tipo > 0) Then
                            cbTipo.Value = tipo
                        Else
                            cbTipo.SelectedIndex = -1

                        End If
                    End If
                    '             a.lfnumi ,a.lftcl1soc,cliente.lanom as nombre ,a.lffecha ,a.lfcl1veh,
                    'vehiculo.lbplac as placa,vehiculo .lbtip1_4 ,MarcaCliente .cedesc1 ,a.lfcomb ,a.lfobs ,
                    'a.lftipo ,a.lftam ,a.lffact ,a.lfhact ,a.lfuact ,cliente.lansoc 
                    TableCliente = False
                    Dim nsoc As Integer = Row.Cells("lansoc").Value
                    Dim HonorarioMeritorio As Integer = Row.Cells("tipo").Value
                    If (nsoc > 0) Then
                        tbClienteSocio.Value = False
                        Dim FechaPago As DataTable = L_prObtenerUltimoPagoSocio(nsoc)
                        lbFechaPago.Visible = True
                        tbFechaPago.Visible = True
                        If (FechaPago.Rows.Count > 0) Then
                            tbFechaPago.Text = "Mes: " + FechaPago.Rows(0).Item("semes").ToString + " Año: " + FechaPago.Rows(0).Item("seano").ToString
                            'If (Now.Year = FechaPago.Rows(0).Item("seano") Or Now.Year = FechaPago.Rows(0).Item("seano") + 1 Or honorario = 2) Then
                            If (FechaPago.Rows(0).Item("seano") >= Now.Year - 1 Or (HonorarioMeritorio = 2 Or HonorarioMeritorio = 3)) Then
                                Dim MesSitema As Integer = FechaPago.Rows(0).Item("semes")
                                Dim mora As Integer = FechaPago.Rows(0).Item("mora")

                                Dim FechaDePago As Date = New Date(FechaPago.Rows(0).Item("seano"), FechaPago.Rows(0).Item("semes"), 1)
                                Dim fecha As Date = Date.Now.AddMonths(-mora)
                                fecha = fecha.AddDays(-(fecha.Day) + 1)
                                If ((fecha <= FechaDePago) Or (HonorarioMeritorio = 2 Or HonorarioMeritorio = 3)) Then

                                    tbFechaPago.BackColor = Color.White
                                    MEP.SetError(tbFechaPago, "")
                                    MHighlighterFocus.UpdateHighlights()
                                    lbUltimaPago.Visible = True
                                    lbUltimaPago.Text = "HABILITADO"
                                    lbUltimaPago.ForeColor = Color.DarkSlateGray
                                    PagoAlDia = True
                                    SuperTabItem2.Visible = True
                                    SuperTabControl1.SelectedTabIndex = 1
                                    _prCrearTablaPoliticajanus()
                                Else
                                    PagoAlDia = False
                                    MEP.SetError(tbFechaPago, "Socio esta con deudas atrazas!".ToUpper)
                                    MHighlighterFocus.UpdateHighlights()
                                    tbFechaPago.BackColor = Color.Red
                                    lbUltimaPago.Visible = True
                                    lbUltimaPago.Text = "INHABILITADO"
                                    lbUltimaPago.ForeColor = Color.Red
                                    SuperTabItem2.Visible = False
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
                                SuperTabItem2.Visible = False
                                SuperTabControl1.SelectedTabIndex = 0
                            End If

                        Else 'Si el socio no hizo ningun pago
                            If (Automovil = True) Then
                                tbFechaPago.Clear()
                                tbFechaPago.Text = "ACB"
                                tbFechaPago.BackColor = Color.White
                                MEP.SetError(tbFechaPago, "")
                                MHighlighterFocus.UpdateHighlights()
                                lbUltimaPago.Visible = True
                                lbUltimaPago.Text = "HABILITADO"
                                lbUltimaPago.ForeColor = Color.DarkSlateGray
                                '' PagoAlDia = True



                            Else
                                If (HonorarioMeritorio = 2 Or HonorarioMeritorio = 3) Then
                                    tbFechaPago.Clear()
                                    tbFechaPago.Text = "HONORARIO"
                                    tbFechaPago.BackColor = Color.White
                                    MEP.SetError(tbFechaPago, "")
                                    MHighlighterFocus.UpdateHighlights()
                                    lbUltimaPago.Visible = True
                                    lbUltimaPago.Text = "HABILITADO"
                                    lbUltimaPago.ForeColor = Color.DarkSlateGray
                                    PagoAlDia = True
                                    SuperTabItem2.Visible = True
                                    SuperTabControl1.SelectedTabIndex = 1
                                    _prCrearTablaPoliticajanus()
                                Else
                                    PagoAlDia = False
                                    MEP.SetError(tbFechaPago, "Socio esta con deudas atrazas!".ToUpper)
                                    MHighlighterFocus.UpdateHighlights()
                                    tbFechaPago.BackColor = Color.Red
                                    tbFechaPago.Text = "Sin Ningun Pago"
                                    lbUltimaPago.Visible = True
                                    lbUltimaPago.Text = "INHABILITADO"
                                    lbUltimaPago.ForeColor = Color.Red
                                    SuperTabItem2.Visible = False
                                    SuperTabControl1.SelectedTabIndex = 0
                                End If

                            End If

                        End If
                    Else
                        tbClienteSocio.Value = True
                        tbFechaPago.Text = ""
                        lbFechaPago.Visible = False
                        tbFechaPago.Visible = False
                        lbUltimaPago.Visible = False
                        SuperTabItem2.Visible = False
                        SuperTabControl1.SelectedTabIndex = 0
                    End If

                    _VerificarPagoAlDia(nsoc)
                    Dim nameimagen As String = grVentasPendientes.GetValue("lafot")
                    If (File.Exists(RutaGlobal + "\Imagenes\Imagenes ClienteL" + nameimagen)) Then
                        Dim im As New Bitmap(New Bitmap(RutaGlobal + "\Imagenes\Imagenes ClienteL" + nameimagen))
                        UsImg.pbImage.SizeMode = PictureBoxSizeMode.StretchImage

                        UsImg.pbImage.Image = im

                    End If

                    _prCambiarEstadoItemEliminar()
                    If (grDetalle.RowCount = 0) Then
                        _prAddFilaDetalle()

                    End If
                    btnAnadir.Visible = False
                    cbTipo.ReadOnly = True
                    tbVehiculo.ReadOnly = True




                    _prCargarServicioRecepcion(L_prServicioCargarRecepcion(gi_LibServLav, cbTipo.Value, tbNumeroOrden.Text))
                    grDetalle.Focus()

                    grDetalle.Select()
                    grDetalle.Col = 4
                    grDetalle.Row = grDetalle.RowCount - 1
                End If

            End If

        End If

    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click


    End Sub
    Private Sub _prSalir()

    End Sub

    Private Sub pbImgProdu_Click(sender As Object, e As EventArgs) Handles pbImgProdu.Click
        If (IsNothing(pbImgProdu.Tag)) Then
            Return
        End If
        Dim direction As String = pbImgProdu.Tag

        Shell("rundll32.exe C:\WINDOWS\system32\shimgvw.dll,ImageView_Fullscreen " + direction)
    End Sub

    Private Sub UsImg_Load(sender As Object, e As EventArgs) Handles UsImg.Load

    End Sub

    Private Sub SwitchButton1_ValueChanged(sender As Object, e As EventArgs) Handles cbmoneda.ValueChanged

    End Sub

    Private Sub cbventa_ValueChanged(sender As Object, e As EventArgs) Handles cbventa.ValueChanged
        If (cbventa.Value = 0) Then
            lbcredito.Visible = True
            tbcredito.Visible = True
        Else
            lbcredito.Visible = False
            tbcredito.Visible = False
        End If
        If (cbventa.Value = 4) Then
            lbbanco.Visible = True
            tbbanco.Visible = True
            lboservacion.Visible = True
            tbObservacion.Visible = True
        Else
            lbbanco.Visible = False
            tbbanco.Visible = False
            lboservacion.Visible = False
            tbObservacion.Visible = False
        End If


    End Sub

    Private Sub tbbanco_KeyDown(sender As Object, e As KeyEventArgs) Handles tbbanco.KeyDown
        If (Not _fnVisualizarRegistros() And Estado.IsReadOnly = False) Then


            If e.KeyData = Keys.Control + Keys.Enter Then

                'grabar horario
                Dim frmAyuda As Modelos.ModeloAyuda

                Dim dt As DataTable
                ''Aqui puse estatico la libreria de CLiente Lavadero 14 , 1
                dt = L_prBancoGeneral()
                't.canumi , t.canombre, t.cacuenta, t.caobs, t.cafact, t.cahact, t.cauact 
                Dim listEstCeldas As New List(Of Modelos.Celda)
                listEstCeldas.Add(New Modelos.Celda("canumi", True, "ID", 50))
                listEstCeldas.Add(New Modelos.Celda("canombre", True, "NOMBRE", 150))
                listEstCeldas.Add(New Modelos.Celda("cacuenta", True, "CUENTA", 150))
                listEstCeldas.Add(New Modelos.Celda("caobs", True, "OBSERVACION", 300))



                listEstCeldas.Add(New Modelos.Celda("cafact", False))
                listEstCeldas.Add(New Modelos.Celda("cahact", False))
                listEstCeldas.Add(New Modelos.Celda("cauact", False))

                frmAyuda = New Modelos.ModeloAyuda(50, 250, dt, "SELECCIONE UN BANCO".ToUpper, listEstCeldas)
                frmAyuda.ShowDialog()


                If frmAyuda.seleccionado = True Then



                    IDbanco = frmAyuda.filaSelect.Cells("canumi").Value


                    tbbanco.Text = frmAyuda.filaSelect.Cells("canombre").Value + " " + frmAyuda.filaSelect.Cells("cacuenta").Value


                End If
            End If
        End If
    End Sub

    Private Sub SuperTabPrincipal_SelectedTabChanged(sender As Object, e As SuperTabStripSelectedTabChangedEventArgs) Handles SuperTabPrincipal.SelectedTabChanged

    End Sub
End Class