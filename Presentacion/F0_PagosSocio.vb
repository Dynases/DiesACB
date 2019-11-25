Option Strict Off 
Imports Logica.AccesoLogica
Imports Janus.Windows.GridEX
Imports DevComponents.DotNetBar
Imports System.IO
Imports DevComponents.DotNetBar.SuperGrid
Imports System.Drawing
Imports DevComponents.DotNetBar.Controls
Imports System.Threading
Imports System.Drawing.Text
Imports System.Reflection
Imports System.Runtime.InteropServices
Imports System.Drawing.Printing
Imports CrystalDecisions.Shared
Imports Datos
Imports Facturacion

Public Class F0_PagosSocio



#Region "VARIABLES MARCO "
    Dim nit As String = "5465454654"
    Dim namefactura As String = "MARCO ANTONIO MAMANI CHURA"
    Dim dt_detalle As DataTable '''
    Dim bandera = False
#End Region

#Region "Variables Globales"

    Dim Duracion As Integer = 5 'Duracion es segundo de los mensajes tipo (Toast)
    Dim GrDatos As GridEXRow() 'Arreglo que tiene las filas actuales de la grilla de datos
    Dim DsGeneral As DataSet 'Dataset que contendra a todos los datatable
    Dim DtCabecera As DataTable 'Datatable de la cabecera
    Dim DtDetalle As DataTable 'Datatable del detalle de la cabecera
    Dim Nuevo As Boolean 'Variable en true cuando se presiona el boton nuevo
    Dim Modificar As Boolean 'Variable en true cuando se presiona el boton modificar
    Dim Eliminar As Boolean 'Variable en true cuando se presiona el boton eliminar
    Dim IndexReg As Integer 'Indice de navegación de registro
    Dim CantidadReg As Integer 'Cantidad de registro de la Tabla
    Dim Grabar As Byte 'Variable que ayuda a la secuencia de grabar

    Dim Numi As String
    Dim DtPrecio As DataTable
    Dim DtPrecioMortuoria As DataTable
    Dim DtMortuoria As DataTable
    Dim BoMortuaria As Boolean = False

    Dim FontHeader As New Font("Arial", gi_userFuente, FontStyle.Bold)
    Dim FontText As New Font("Arial", gi_userFuente - 1, FontStyle.Regular)

    Public _nameButton As String

    Private deCuotaSocio As Decimal = 150
    Private deCuotaSocioAnual As Decimal = 137.5
    Private deCuotaSocioAusente As Decimal = 75
    Private boEsAusente As Boolean = False

    Private FacturaSocio As Boolean = False
#End Region

#Region "Eventos"

    Private Sub P_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        P_Inicio()
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        P_Nuevo()
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        P_Modificar()
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        P_Eliminar()
    End Sub

    Private Sub btnGrabar_Click(sender As Object, e As EventArgs) Handles btnGrabar.Click
        P_Grabar()
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        P_Cancelar()
    End Sub

    Private Sub btnPrimero_Click(sender As Object, e As EventArgs) Handles btnPrimero.Click
        IndexReg = 0
        P_LlenarDatos(IndexReg)
        P_ActualizarPaginacion(IndexReg)
    End Sub

    Private Sub btnAnterior_Click(sender As Object, e As EventArgs) Handles btnAnterior.Click
        IndexReg -= 1
        P_LlenarDatos(IndexReg)
        P_ActualizarPaginacion(IndexReg)
    End Sub

    Private Sub btnSiguiente_Click(sender As Object, e As EventArgs) Handles btnSiguiente.Click
        IndexReg += 1
        P_LlenarDatos(IndexReg)
        P_ActualizarPaginacion(IndexReg)
    End Sub

    Private Sub btnUltimo_Click(sender As Object, e As EventArgs) Handles btnUltimo.Click
        IndexReg = CantidadReg
        P_LlenarDatos(IndexReg)
        P_ActualizarPaginacion(IndexReg)
    End Sub

#End Region

#Region "Metodos"

    Private Sub P_Inicio()
        'Abrir la conexion de la base de datos
        'L_prAbrirConexion()

        'Poner visible=false, los componente que no se ocuparan
        btnImprimir.Visible = False
        cargarVariable()
        'Poner titulo al formulario
        Me.Text = "P A G O S   S O C I O"
        Me.WindowState = FormWindowState.Maximized
        SuperTabPrincipal.SelectedTabIndex = 0

        'Inhabilitar el boton de grabar
        btnGrabar.Enabled = False
        'TbiNroSocio.IsInputReadOnly = True
        Tb2NombreSocio.ReadOnly = True
        Dt1FechaIngreso.IsInputReadOnly = True
        Dt1FechaIngreso.ButtonDropDown.Enabled = False
        dgjTelefono.AllowEdit = InheritableBoolean.False
        Tb4Cambio.ReadOnly = True
        SupTabItemBusqueda.Visible = False
        btnEliminar.Visible = False
        BubbleBarUsuario.Visible = False
        PanelNavegacion.Visible = False
        chPagoAnho.Checked = False

        'Poner texto de salir a boton de cancelar
        btnSalir.Tooltip = "SALIR"

        'Deshabilitar componentes
        P_Deshabilitar()

        'Limpiar
        P_Limpiar()

        'Armar combos
        P_ArmarCombos()

        'Armar grillas
        P_ArmarGrillas()

        'Cargar variables locales
        'P_CargarVariablesLocales()
        deCuotaSocio = L_fnObtenerTabla("top(1) *",
                                        "TCE004 a inner join TCE0041 b on a.ednumi=b.eenumi and a.ednumi=1",
                                        "1=1 order by eelinea desc").Rows(0).Item("eeprecio")
        deCuotaSocioAnual = ((deCuotaSocio * 12) - deCuotaSocio) / 12
        deCuotaSocioAusente = deCuotaSocio / 2

        'Navegación de registro
        P_ActualizarPuterosNavegacion()
        IndexReg = 0
        P_LlenarDatos(IndexReg)

        tbiGestion.MaxValue = Now.Year + 5

        'Nombres Usuario
        TxtNombreUsu.Text = L_Usuario
        TxtNombreUsu.ReadOnly = True

        _prAsignarPermisos()
    End Sub
    Public Sub cargarVariable()
        Dim dt As DataTable = L_fnSocioObtenerEstadoFactura()
        If (dt.Rows.Count > 0) Then
            FacturaSocio = dt.Rows(0).Item("factura")
        End If
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

    Private Sub P_Nuevo()
        P_Limpiar()
        btnGrabar.Tooltip = "GRABAR NUEVO REGISTRO"
        P_Habilitar()
        tbiGestion.Select()
        'Grabar = 1
        Grabar = 2
        rlAccion.Text = "NUEVO"
        P_EstadoNueModEli(1)
    End Sub

    Private Sub P_Modificar()
        btnGrabar.Tooltip = "GRABAR MODIFICACIÓN DE REGISTRO"
        P_Habilitar()
        tbiGestion.Select()
        'Grabar = 3
        Grabar = 4
        rlAccion.Text = "MODIFICAR"
        P_EstadoNueModEli(2)
        Tb3NroRecibo.Text = "0"
    End Sub

    Private Sub P_Eliminar()
        btnGrabar.Tooltip = "GRABAR ELIMINACIÓN DE REGISTRO"
        P_Deshabilitar()
        ToastNotification.Show(Me, "SE ELIMINARÁ ESTE EL CLIENTE CON CÓDIGO: " + "Dato",
                               My.Resources.INFORMATION,
                               Duracion * 1000,
                               eToastGlowColor.Blue,
                               eToastPosition.BottomRight)
        'Grabar = 5
        Grabar = 6
        rlAccion.Text = "ELIMINAR"
        P_EstadoNueModEli(3)
    End Sub

    Private Function P_fnValidarFactura() As Boolean
        Return True
    End Function
    Private Function P_fnGrabarFacturarTFV001(numi As String, sucursal As String) As Boolean
        Dim a As Double = CDbl(Tbd1Monto.Value - Convert.ToDouble(Tb4Cambio.Text))
        Dim b As Double = CDbl(0) 'Ya esta calculado el 55% del ICE
        Dim c As Double = CDbl("0")
        Dim d As Double = CDbl("0")
        Dim e As Double = a - b - c - d
        Dim f As Double = CDbl(0)
        Dim g As Double = e - f
        Dim h As Double = g * (gi_IVA / 100)

        Dim res As Boolean = False
        'Grabado de Cabesera Factura
        L_Grabar_Factura(numi,
                        Dt2FechaPago.Value.ToString("yyyy/MM/dd"),
                        "0",
                        "0",
                        "1",
                        nit,
                        "0",
                        namefactura,
                        "",
                        CStr(Format(a, "####0.00")),
                        CStr(Format(b, "####0.00")),
                        CStr(Format(c, "####0.00")),
                        CStr(Format(d, "####0.00")),
                        CStr(Format(e, "####0.00")),
                        CStr(Format(f, "####0.00")),
                        CStr(Format(g, "####0.00")),
                        CStr(Format(h, "####0.00")),
                        "",
                        Now.Date.ToString("yyyy/MM/dd"),
                        "''",
                        sucursal,
                        numi)

        Dim s As String = ""

        For fil As Integer = 0 To dt_detalle.Rows.Count - 1 Step 1

            Dim codServ As Integer
            If (dt_detalle.Rows(fil).Item("codigo") > 0) Then
                codServ = dt_detalle.Rows(fil).Item("codigo")

            End If
            L_Grabar_Factura_Detalle(numi.ToString,
                                       Str(codServ).ToString.Trim,
                                        dt_detalle.Rows(fil).Item("servicio").ToString.Trim,
                                       "1",
                                        dt_detalle.Rows(fil).Item("total"),
                                        numi)
            res = True

        Next
        Return res
    End Function
    Private Function P_fnGenerarFactura(numi As String) As Boolean
        Dim res As Boolean = False
        res = P_fnGrabarFacturarTFV001(numi, 1) ' Grabar en la TFV001
        If (res) Then
            If (P_fnValidarFactura()) Then
                'Validar para facturar
                P_prImprimirFacturar(numi, True, True) '_Codigo de a tabla TV001
            Else
                'Volver todo al estada anterior
                ToastNotification.Show(Me, "No es posible facturar, vuelva a ingresar a la mesa he intente nuevamente!!!".ToUpper,
                                       My.Resources.OK1,
                                       5 * 1000,
                                       eToastGlowColor.Red,
                                       eToastPosition.MiddleCenter)
            End If

            If (Not nit.ToString.Trim.Equals("0")) Then
                L_Grabar_Nit(nit.ToString.Trim, namefactura.ToString.Trim, "")
            Else
                L_Grabar_Nit(nit.ToString.Trim, "S/N", "")
            End If
        End If

        Return res
    End Function


    Public Function P_fnImageToByteArray(ByVal imageIn As Image) As Byte()
        Dim ms As New System.IO.MemoryStream()
        imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg)
        Return ms.ToArray()
    End Function
    Public Function _CompletarMonth(numero As Integer) As String
        If (numero < 10) Then
            Return "0".Trim + Str(numero).Trim
        Else
            Return Str(numero).Trim
        End If
    End Function
    Private Sub P_prImprimirFacturar(numi As String, impFactura As Boolean, grabarPDF As Boolean)
        Dim _Fecha, _FechaAl As Date
        Dim _Ds, _Ds1, _Ds2, _Ds3 As New DataSet
        Dim _Autorizacion, _Nit, _Fechainv, _Total, _Key, _Cod_Control, _Hora,
            _Literal, _TotalDecimal, _TotalDecimal2 As String
        Dim I, _NumFac, _numidosif, _TotalCC As Integer
        Dim ice, _Desc, _TotalLi As Decimal
        Dim _VistaPrevia As Integer = 0
        _Desc = CDbl(0)
        If Not IsNothing(P_Global.Visualizador) Then
            P_Global.Visualizador.Close()
        End If

        _Fecha = Dt2FechaPago.Value '.ToString("dd/MM/yyyy")
        _Hora = Now.Hour.ToString + ":" + Now.Minute.ToString
        _Ds1 = L_Dosificacion("1", 1, _Fecha)

        _Ds = L_Reporte_Factura(numi, numi)
        _Autorizacion = _Ds1.Tables(0).Rows(0).Item("sbautoriz").ToString
        _NumFac = CInt(_Ds1.Tables(0).Rows(0).Item("sbnfac")) + 1
        _Nit = _Ds.Tables(0).Rows(0).Item("fvanitcli").ToString
        _Fechainv = _Fecha.Year.ToString +
                   _CompletarMonth(_Fecha.Month).Trim +
                   _CompletarMonth(_Fecha.Day).Trim
        _Total = _Ds.Tables(0).Rows(0).Item("fvatotal").ToString
        ice = _Ds.Tables(0).Rows(0).Item("fvaimpsi")
        _numidosif = _Ds1.Tables(0).Rows(0).Item("sbnumi").ToString
        _Key = _Ds1.Tables(0).Rows(0).Item("sbkey")
        _FechaAl = _Ds1.Tables(0).Rows(0).Item("sbfal")

        Dim maxNFac As Integer = L_fnObtenerMaxIdTabla("TFV001", "fvanfac", "fvaautoriz = " + _Autorizacion)
        _NumFac = maxNFac + 1

        _TotalCC = Math.Round(CDbl(_Total), MidpointRounding.AwayFromZero)
        _Cod_Control = ControlCode.generateControlCode(_Autorizacion, _NumFac, _Nit, _Fechainv, CStr(_TotalCC), _Key)

        'Literal 
        _TotalLi = _Ds.Tables(0).Rows(0).Item("fvastot") - _Ds.Tables(0).Rows(0).Item("fvadesc")
        _TotalDecimal = _TotalLi - Math.Truncate(_TotalLi)
        _TotalDecimal2 = CDbl(_TotalDecimal) * 100

        'Dim li As String = Facturacion.ConvertirLiteral.A_fnConvertirLiteral(CDbl(_Total) - CDbl(_TotalDecimal)) + " con " + IIf(_TotalDecimal2.Equals("0"), "00", _TotalDecimal2) + "/100 Bolivianos"
        _Literal = Facturacion.ConvertirLiteral.A_fnConvertirLiteral(CDbl(_TotalLi) - CDbl(_TotalDecimal)) + " con " + IIf(_TotalDecimal2.Equals("0"), "00", _TotalDecimal2) + "/100 Bolivianos"
        _Ds2 = L_Reporte_Factura_Cia("1")
        QrFactura.Text = _Ds2.Tables(0).Rows(0).Item("scnit").ToString + "|" + Str(_NumFac).Trim + "|" + _Autorizacion + "|" + _Fecha + "|" + _Total + "|" + _TotalLi.ToString + "|" + _Cod_Control + "|" + nit.ToString + "|" + ice.ToString + "|0|0|" + Str(_Desc).Trim

        L_fnActualizarNroFactura(numi, _NumFac)

        L_Modificar_Factura("fvanumi = " + CStr(numi),
                            "",
                            CStr(_NumFac),
                            CStr(_Autorizacion),
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            _Cod_Control,
                            _FechaAl.ToString("yyyy/MM/dd"),
                            "",
                            "",
                            CStr(numi))

        _Ds = L_Reporte_Factura(numi, numi)
        Dim dt As DataTable = L_fnFacturaLavadero(numi)
        Dim dtAyuda As DataTable = L_fnFacturaAyudaPagoSocios(numi)

        '''''''''''''AQUI DE UN AñO ANTERIOR '''''''''''''''''''''''
        Dim result As DataRow() = dtAyuda.Select("seano=" + Str(Now.Date.Year - 1))
        Dim total As Decimal = 0
        For l As Integer = 0 To result.Length - 1 Step 1
            total += result(l).Item("Total")

        Next

        If (result.Length > 0) Then

            '1 as Cantidad, detalle
            '			, PrecioUnitario, Total,vdnumi , img
            If (result.Length > 1) Then

                dt.Rows.Add(result.Length, "PAGO CUOTA DE SOCIO DE " + result(0).Item("detalle") + " A " + result(result.Length - 1).Item("detalle") + " DEL " + Str(Now.Date.Year - 1), total / result.Length, total, 0, DBNull.Value)
            Else
                dt.Rows.Add(result.Length, "PAGO CUOTA DE SOCIO DE " + result(0).Item("detalle") + " DEL " + Str(Now.Date.Year - 1), total / result.Length, total, 0, DBNull.Value)
            End If

        End If
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '''''''''''''AQUI DEL AñO ACTUAL '''''''''''''''''''''''
        Dim resultActual As DataRow() = dtAyuda.Select("seano=" + Str(Now.Date.Year))
        Dim totalActual As Decimal = 0
        For l As Integer = 0 To resultActual.Length - 1 Step 1
            totalActual += resultActual(l).Item("Total")

        Next

        If (resultActual.Length > 0) Then

            '1 as Cantidad, detalle
            '			, PrecioUnitario, Total,vdnumi , img
            If (resultActual.Length > 1) Then

                dt.Rows.Add(resultActual.Length, "PAGO CUOTA DE SOCIO DE " + resultActual(0).Item("detalle") + " A " + resultActual(resultActual.Length - 1).Item("detalle").ToString + " DEL " + Str(Now.Date.Year), totalActual / resultActual.Length, totalActual, 0, DBNull.Value)
            Else
                dt.Rows.Add(resultActual.Length, "PAGO CUOTA DE SOCIO DE " + resultActual(0).Item("detalle") + " DEL " + Str(Now.Date.Year), totalActual / resultActual.Length, totalActual, 0, DBNull.Value)
            End If

        End If
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''


        For j As Integer = 0 To dt.Rows.Count - 1 Step 1
            dt.Rows(j).Item("img") = P_fnImageToByteArray(QrFactura.Image)
        Next
        For I = 0 To _Ds.Tables(0).Rows.Count - 1
            _Ds.Tables(0).Rows(I).Item("fvaimgqr") = P_fnImageToByteArray(QrFactura.Image)
        Next


        If (True) Then 'Vista Previa de la Ventana de Vizualización 1 = True 0 = False
            P_Global.Visualizador = New Visualizador 'Comentar
        End If
        Dim objrep As Object = Nothing

            objrep = New R_Mam_FacturaLavadero
        '' If (Not _Ds.Tables(0).Rows.Count = gi_FacturaCantidadItems) Then
        ''For index = _Ds.Tables(0).Rows.Count To gi_FacturaCantidadItems - 1
        'Insertamos la primera fila con el saldo Inicial
        ''''  Dim f As DataRow = _Ds.Tables(0).NewRow
        ''f.ItemArray() = _Ds.Tables(0).Rows(0).ItemArray
        ''f.Item("fvbcant") = -1
        ''_Ds.Tables(0).Rows.Add(f)
        ''     Next

        objrep.SetDataSource(dt)
        objrep.SetParameterValue("nroFactura", _CompletarNroFactura(_Ds.Tables(0).Rows(0).Item("fvanfac")))
        objrep.SetParameterValue("nroAutorizacion", _Ds.Tables(0).Rows(0).Item("fvaautoriz"))
        objrep.SetParameterValue("MensajeContribuyente", "''" + _Ds1.Tables(0).Rows(0).Item("sbnota").ToString + "''.")
        objrep.SetParameterValue("nit", _Ds2.Tables(0).Rows(0).Item("scnit").ToString)
        objrep.SetParameterValue("lugarFecha", "Cochabamba, " + Str(Dt2FechaPago.Value.Day) + " De " + MonthName(Dt2FechaPago.Value.Month) + " De " + Str(Dt2FechaPago.Value.Year))
        objrep.SetParameterValue("nombreFactura", namefactura.ToString)
        objrep.SetParameterValue("nitCliente", nit.ToString)
        objrep.SetParameterValue("TotalBs", _Literal)
        objrep.SetParameterValue("CodeControl", _Ds.Tables(0).Rows(0).Item("fvaccont"))
        objrep.SetParameterValue("FechaLimiteEmision", _Ds.Tables(0).Rows(0).Item("fvaflim"))
        objrep.SetParameterValue("mensaje2", _Ds1.Tables(0).Rows(0).Item("sbnota2").ToString)
        objrep.SetParameterValue("Obs", TbiNroSocio.Value.ToString + " - " + Tb2NombreSocio.Text.Trim)


        P_Global.Visualizador.CRV1.ReportSource = objrep 'Comentar
        P_Global.Visualizador.Show() 'Comentar
            P_Global.Visualizador.BringToFront() 'Comentar


        'Dim pd As New PrintDocument()
        'pd.PrinterSettings.PrinterName = _Ds3.Tables(0).Rows(0).Item("cbrut").ToString
        'If (Not pd.PrinterSettings.IsValid) Then
        '    ToastNotification.Show(Me, "La Impresora ".ToUpper + _Ds3.Tables(0).Rows(0).Item("cbrut").ToString + Chr(13) + "No Existe".ToUpper,
        '                           My.Resources.WARNING, 5 * 1000,
        '                           eToastGlowColor.Blue, eToastPosition.BottomRight)
        'Else
        '    objrep.PrintOptions.PrinterName = _Ds3.Tables(0).Rows(0).Item("cbrut").ToString '"EPSON TM-T20II Receipt5 (1)"
        '    objrep.PrintToPrinter(1, False, 1, 1)

        'End If

        If (grabarPDF) Then
                'Copia de Factura en PDF
                If (Not Directory.Exists(gs_CarpetaRaiz + "\Facturas")) Then
                    Directory.CreateDirectory(gs_CarpetaRaiz + "\Facturas")
                End If
                objrep.ExportToDisk(ExportFormatType.PortableDocFormat, gs_CarpetaRaiz + "\Facturas\" + CStr(_NumFac) + "_" + CStr(_Autorizacion) + ".pdf")

            End If
        '' End If
        L_Actualiza_Dosificacion(_numidosif, _NumFac, numi)
    End Sub

    Public Function _CompletarNroFactura(numero As Integer) As String
        Dim n As Integer = 7 - numero.ToString.Length
        Dim cadena As String = "" + Str(numero).Trim
        For i As Integer = 0 To n Step 1
            cadena = "0" + cadena
        Next
        Return cadena
    End Function
    Public Function _fnObtenerNit() As Boolean
        If (FacturaSocio = False) Then
            Return True
        End If
        Dim f1 As F1_VentanaFactura
        f1 = New F1_VentanaFactura
        f1.Nombre = Tb2NombreSocio.Text
        f1.ShowDialog()
        If (f1.nameFactura.ToString.Length > 0 And f1.nit.ToString.Length > 0) Then
            nit = f1.nit.ToString
            namefactura = f1.nameFactura.ToString
            Return True
        Else
            Return False
        End If
    End Function
    Private Sub P_Grabar()
        If (Nuevo) Then
            If (P_Validar(2)) Then
                If (Grabar = 2 And _fnObtenerNit()) Then

                    'CODIGO DANNY--------------------------------
                    If (FacturaSocio = True) Then
                        Dim dtSet As DataSet = L_Dosificacion("1", 1, Dt2FechaPago.Value)
                        If dtSet.Tables.Count > 0 Then
                            If dtSet.Tables(0).Rows.Count = 0 Then
                                Dim img As Bitmap = New Bitmap(My.Resources.cancel, 50, 50)
                                ToastNotification.Show(Me, "no existe la dosificacion automatica habilitada para esta sucursal, por lo tanto no se puede realizar la facturacion automatica".ToUpper, img, 4000, eToastGlowColor.Red, eToastPosition.BottomCenter)
                                Return
                            End If
                        Else

                            Dim img As Bitmap = New Bitmap(My.Resources.cancel, 50, 50)
                            ToastNotification.Show(Me, "no existe la dosificacion automatica habilitada para esta sucursal, por lo tanto no se puede realizar la facturacion automatica".ToUpper, img, 4000, eToastGlowColor.Red, eToastPosition.BottomCenter)
                            Return
                        End If
                    End If
                    'CODIGO DANNY----------------------------------

                    'Grabar
                    Dim Dt1 As DataTable
                    Dim Dt2 As DataTable
                    Dim DtM1 As DataTable
                    Dim DtM2 As DataTable

                    Dim ppnc As Boolean
                    'Año anterior
                    'senumi, semes, seano, sefec, serec, seimp1, sesaldo, seest, sefact, sehact, seuact
                    Dt1 = CType(DgdPagos.PrimaryGrid.DataSource, DataTable).DefaultView.ToTable(True, "senumi", "semes", "senmes", "seano", "sefec", "serec", "seimp1", "sesaldo", "seest", "selin", "estado", "sefact", "sehact", "seuact")
                    ppnc = P_prPonerPagosNoCorresponde(Dt1, "seest")

                    'Año actual
                    Dt2 = CType(DgdPagos.PrimaryGrid.DataSource, DataTable).DefaultView.ToTable(True, "senumi2", "semes2", "senmes2", "seano2", "sefec2", "serec2", "seimp12", "sesaldo2", "seest2", "selin2", "estado2", "sefact2", "sehact2", "seuact2")

                    If (Not ppnc) Then
                        P_prPonerPagosNoCorresponde(Dt2, "seest2")
                    End If
                    Dim ppmnc As Boolean
                    'Año anterior
                    'numi, fdoc, rec, monto, saldo, gestion, est, lin, fact, hact, uact, estado
                    DtM1 = CType(DgdMortuoria.PrimaryGrid.DataSource, DataTable).DefaultView.ToTable(True, "numi", "fdoc", "rec", "monto", "saldo", "gestion", "est", "lin", "fact", "hact", "uact", "estado")
                    ppmnc = P_prPonerPagosMortuoriaNoCorresponde(DtM1, "est")

                    'Año actual
                    DtM2 = CType(DgdMortuoria.PrimaryGrid.DataSource, DataTable).DefaultView.ToTable(True, "numi2", "fdoc2", "rec2", "monto2", "saldo2", "gestion2", "est2", "lin2", "fact2", "hact2", "uact2", "estado2")

                    If (Not ppmnc) Then
                        P_prPonerPagosMortuoriaNoCorresponde(DtM2, "est2")
                    End If
                    Dim total As Double = Tbd1Monto.Value - Convert.ToDouble(Tb4Cambio.Text)
                    Dim numiVentas As String = "-1"
                    Dim Obs As String = TbiNroSocio.Text.Trim + " - " + Tb2NombreSocio.Text.Trim

                    Dim InsertVenta As Boolean = True
                    If (FacturaSocio = True) Then
                        InsertVenta = L_fnSocioVentaDicontaPagosGrabar(numiVentas, Numi, total, Dt2FechaPago.Value.ToString("yyyy/MM/dd"), Obs)
                    End If

                    If (InsertVenta = False) Then
                        ToastNotification.Show(Me, "No se pudo grabar el pago de socio con numero de socio ".ToUpper + TbiNroSocio.Value.ToString + ", intente nuevamente.".ToUpper,
                                         My.Resources.WARNING,
                                         Duracion * 1000,
                                         eToastGlowColor.Red,
                                         eToastPosition.TopCenter)
                    End If
                    Dim res As Boolean = L_fnSocioPagosGrabar(Numi, Dt1, DtM1, numiVentas)
                    Dim res2 As Boolean = L_fnSocioPagosGrabar(Numi, Dt2, DtM2, numiVentas)
                    If (FacturaSocio = True) Then
                        dt_detalle = L_fnSocioObtenerDetallePagoFactura(numiVentas)
                        P_fnGenerarFactura(numiVentas)
                    End If


                    If (res) Then
                        'P_Limpiar()
                        P_ArmarGrillaBusqueda()
                        btnSalir.PerformClick()
                        ToastNotification.Show(Me, "El pago del socio con numero ".ToUpper + TbiNroSocio.Value.ToString + " Grabado con Exito.".ToUpper,
                                           My.Resources.GRABACION_EXITOSA,
                                           Duracion * 1000,
                                           eToastGlowColor.Green,
                                           eToastPosition.TopCenter)
                    Else
                        ToastNotification.Show(Me, "No se pudo grabar el pago de socio con numero de socio ".ToUpper + TbiNroSocio.Value.ToString + ", intente nuevamente.".ToUpper,
                                           My.Resources.WARNING,
                                           Duracion * 1000,
                                           eToastGlowColor.Red,
                                           eToastPosition.TopCenter)
                    End If
                    Grabar = 1
                Else
                    btnGrabar.Tooltip = "CONFIRMAR GRABADO DE REGISTRO"
                    Grabar = 2
                End If
            End If
        ElseIf (Modificar) Then
            If (P_Validar(2)) Then
                If (Grabar = 4) Then
                    'Modificar
                    'Grabar
                    Dim Dt1 As DataTable
                    Dim Dt2 As DataTable
                    Dim DtM1 As DataTable
                    Dim DtM2 As DataTable

                    'Año anterior
                    'senumi, semes, seano, sefec, serec, seimp1, sesaldo, seest, sefact, sehact, seuact
                    Dt1 = CType(DgdPagos.PrimaryGrid.DataSource, DataTable).DefaultView.ToTable(True, "senumi", "semes", "senmes", "seano", "sefec", "serec", "seimp1", "sesaldo", "seest", "selin", "estado", "sefact", "sehact", "seuact")
                    'Año actual
                    Dt2 = CType(DgdPagos.PrimaryGrid.DataSource, DataTable).DefaultView.ToTable(True, "senumi2", "semes2", "senmes2", "seano2", "sefec2", "serec2", "seimp12", "sesaldo2", "seest2", "selin2", "estado2", "sefact2", "sehact2", "seuact2")

                    'Año anterior
                    'numi, fdoc, rec, monto, saldo, gestion, est, lin, fact, hact, uact, estado
                    DtM1 = CType(DgdMortuoria.PrimaryGrid.DataSource, DataTable).DefaultView.ToTable(True, "numi", "fdoc", "rec", "monto", "saldo", "gestion", "est", "lin", "fact", "hact", "uact", "estado")
                    'Año actual
                    DtM2 = CType(DgdMortuoria.PrimaryGrid.DataSource, DataTable).DefaultView.ToTable(True, "numi2", "fdoc2", "rec2", "monto2", "saldo2", "gestion2", "est2", "lin2", "fact2", "hact2", "uact2", "estado2")


                    Dim res As Boolean = L_fnSocioPagosGrabar(Numi, Dt1, DtM1, 0)
                    Dim res2 As Boolean = L_fnSocioPagosGrabar(Numi, Dt2, DtM2, 0)

                    If (res) Then
                        'P_Limpiar()
                        P_ArmarGrillaBusqueda()
                        btnSalir.PerformClick()
                        ToastNotification.Show(Me, "El pago del socio con numero ".ToUpper + TbiNroSocio.Value.ToString + " Grabado con Exito.".ToUpper,
                                           My.Resources.GRABACION_EXITOSA,
                                           Duracion * 1000,
                                           eToastGlowColor.Green,
                                           eToastPosition.TopCenter)
                    Else
                        ToastNotification.Show(Me, "No se pudo grabar el pago de socio con numero de socio ".ToUpper + TbiNroSocio.Value.ToString + ", intente nuevamente.".ToUpper,
                                           My.Resources.WARNING,
                                           Duracion * 1000,
                                           eToastGlowColor.Red,
                                           eToastPosition.TopCenter)
                    End If

                    Grabar = 3
                Else
                    btnGrabar.Tooltip = "CONFIRMAR MODIFICACIÓN DE REGISTRO"
                    Grabar = 4
                End If
            End If
        End If
        P_ActualizarPuterosNavegacion()
    End Sub

    Private Sub P_Cancelar()
        If (Not btnGrabar.Enabled) Then
            Me.Close()
        Else
            P_Limpiar()
            P_Deshabilitar()
            GrDatos = Dgj1Busqueda.GetRows
            P_LlenarDatos(IndexReg)
            Grabar = 0
            rlAccion.Text = ""
            rlMortuoria.Text = ""
            rlTipoSocio.Text = ""
            btnGrabar.Tooltip = "GRABAR"
        End If
        P_EstadoNueModEli(4)
    End Sub

    Private Sub P_EstadoNueModEli(val As Integer)
        Nuevo = (val = 1)
        Modificar = (val = 2)
        Eliminar = (val = 3)

        btnNuevo.Enabled = (val = 4)
        btnModificar.Enabled = (val = 4)
        btnEliminar.Enabled = (val = 4)
        btnGrabar.Enabled = Not (val = 4)

        If (val = 4) Then
            btnSalir.Tooltip = "SALIR"
            btnSalir.Text = "SALIR"
        Else
            btnSalir.Tooltip = "CANCELAR"
            btnSalir.Text = "CANCELAR"
        End If
        btnPrimero.Enabled = (val = 4)
        btnAnterior.Enabled = (val = 4)
        btnSiguiente.Enabled = (val = 4)
        btnUltimo.Enabled = (val = 4)
        'SupTabItemBusqueda.Visible = (val = 4)

    End Sub

    Private Sub P_Habilitar()
        'Componentes a habilitar
        TbiNroSocio.IsInputReadOnly = False
        Tbd1Monto.IsInputReadOnly = False
        Tb3NroRecibo.ReadOnly = False
        Bt1Buscar.Enabled = True
        Bt2Generar.Enabled = True

        tbiGestion.IsInputReadOnly = False

        Dt2FechaPago.IsInputReadOnly = False
        Dt2FechaPago.ButtonDropDown.Enabled = True

        DgdPagos.PrimaryGrid.ReadOnly = False
        chPagoAnho.Enabled = True
    End Sub

    Private Sub P_Deshabilitar()
        'Componentes a deshabilitar
        TbiNroSocio.IsInputReadOnly = True
        Tbd1Monto.IsInputReadOnly = True
        Tb3NroRecibo.ReadOnly = True
        Bt1Buscar.Enabled = False
        Bt2Generar.Enabled = False

        tbiGestion.IsInputReadOnly = True

        Dt2FechaPago.IsInputReadOnly = True
        Dt2FechaPago.ButtonDropDown.Enabled = False

        DgdPagos.PrimaryGrid.ReadOnly = True
        chPagoAnho.Enabled = False
    End Sub

    Private Sub P_Limpiar()
        'Componentes a limpiar
        TbiNroSocio.Value = 0
        Tb2NombreSocio.Clear()
        Tb3NroRecibo.Clear()
        Dt1FechaIngreso.Value = Now.Date
        Tbd1Monto.Value = 0
        dgjTelefono.DataSource = Nothing
        Dt2FechaPago.Value = Now.Date

        tbiGestion.Value = Now.Date.Year

        'Componentes Grid
        DgdPagos.PrimaryGrid.DataSource = Nothing
        DgdMortuoria.PrimaryGrid.DataSource = Nothing

        chPagoAnho.Checked = False
    End Sub

    Private Sub P_ActualizarPuterosNavegacion()
        If (GrDatos Is Nothing) Then
            GrDatos = Dgj1Busqueda.GetRows
        End If
        CantidadReg = Dgj1Busqueda.GetRows.Count - 1
        If (IndexReg > CantidadReg) Then
            IndexReg = CantidadReg
        End If
        P_ActualizarPaginacion(IndexReg)
    End Sub

    Private Sub P_LlenarDatos(index As Integer)
        If (index <= CantidadReg And index >= 0 And GrDatos.Count > 0) Then
            'Llenar los datos a los componentes
            With GrDatos(index)
                'Campos

            End With
        Else
            If (IndexReg < 0) Then
                IndexReg = 0
            Else
                IndexReg = CantidadReg
            End If
        End If
    End Sub

    Private Sub P_ActualizarPaginacion(index As Integer)
        LblPaginacion.Text = "Reg. " & index + 1 & " de " & CantidadReg + 1
    End Sub

#End Region

    Private Function P_Validar(modo As Integer) As Boolean
        Dim sms As String = ""
        If (modo = 1) Then
            If (Tbd1Monto.Value <= 0) Then
                If (sms = String.Empty) Then
                    sms = "el monto no puede ser cero (0), debe ser mayor.".ToUpper
                Else
                    sms = sms + ChrW(13) + "el monto no puede ser cero (0), debe ser mayor.".ToUpper
                End If
            End If
            If (FacturaSocio = False) Then
                If (Tb3NroRecibo.Text = String.Empty) Then
                    If (sms = String.Empty) Then
                        sms = "el campo recibo no puede quedar vacio, debe poner un número de recibo.".ToUpper
                    Else
                        sms = sms + ChrW(13) + "el campo recibo no puede quedar vacio, debe poner un número de recibo.".ToUpper
                    End If
                End If
            End If


            If (Not sms = String.Empty) Then
                ToastNotification.Show(Me, sms.ToUpper,
                           My.Resources.WARNING,
                           Duracion * 1000,
                           eToastGlowColor.Red,
                           eToastPosition.TopCenter)
                Return False
                Exit Function
            End If
            Return True
        ElseIf (modo = 2) Then
            If (DgdMortuoria.PrimaryGrid.Rows.Count > 0) Then
                Dim c1 As GridCell = DgdMortuoria.PrimaryGrid.GetCell(0, DgdMortuoria.PrimaryGrid.Columns("check11").ColumnIndex)
                Dim c2 As GridCell = DgdMortuoria.PrimaryGrid.GetCell(0, DgdMortuoria.PrimaryGrid.Columns("check12").ColumnIndex)

                If (FacturaSocio = False) Then
                    If (c1.Value = 1) Then
                        If (DgdMortuoria.PrimaryGrid.GetCell(0, DgdMortuoria.PrimaryGrid.Columns("rec").ColumnIndex).Value = 0 Or
                           DgdMortuoria.PrimaryGrid.GetCell(0, DgdMortuoria.PrimaryGrid.Columns("rec").ColumnIndex).Value.ToString = String.Empty) Then
                            If (sms = String.Empty) Then
                                sms = "la columna de recibo no puede quedar vacio o en cero, debe poner un número de recibo.".ToUpper
                            Else
                                sms = sms + ChrW(13) + "la columna de recibo no puede quedar vacio o en cero, debe poner un número de recibo".ToUpper
                            End If
                        End If
                    End If
                    If (c2.Value = 1) Then
                        If (DgdMortuoria.PrimaryGrid.GetCell(0, DgdMortuoria.PrimaryGrid.Columns("rec2").ColumnIndex).Value = 0 Or
                           DgdMortuoria.PrimaryGrid.GetCell(0, DgdMortuoria.PrimaryGrid.Columns("rec2").ColumnIndex).Value.ToString = String.Empty) Then
                            If (sms = String.Empty) Then
                                sms = "la columna de recibo no puede quedar vacio o en cero, debe poner un número de recibo".ToUpper
                            Else
                                sms = sms + ChrW(13) + "la columna de recibo no puede quedar vacio o en cero, debe poner un número de recibo".ToUpper
                            End If
                        End If
                    End If
                End If

            End If

                If (Tbd1Monto.Value = CDec(Tb4Cambio.Text)) Then
                If (sms = String.Empty) Then
                    sms = "no puede guardar si no a hecho ni un pago, para salir presione cancelar".ToUpper
                Else
                    sms = sms + ChrW(13) + "no puede guardar si no a hecho ni un pago, para salir presione cancelar".ToUpper
                End If
            End If

            If (chPagoAnho.Checked) Then
                Dim cambio As Double = 0
                If (deCuotaSocioAnual * 12 <
                    Tbd1Monto.Value) Then
                    cambio = Tbd1Monto.Value - (deCuotaSocioAnual * 12)

                    If (CDbl(Tb4Cambio.Text) <> cambio And CDbl(Tb4Cambio.Text) > 0) Then
                            sms = "debe tikear 12 meses para que pueda grabar.".ToUpper
                        End If

                Else
                        If (CDbl(Tb4Cambio.Text) > 0) Then
                        If (sms = String.Empty) Then
                            sms = "debe tikear 12 meses para que pueda grabar.".ToUpper
                        Else
                            sms = sms + ChrW(13) + "debe tikear 12 meses para que pueda grabar.".ToUpper
                        End If
                    End If
                End If



            End If
            If (nit.ToString.Length <= 0) Then
                If (sms = String.Empty) Then
                    sms = "Debe Introducir un Nit Para Efectuar el Pago".ToUpper
                Else
                    sms = sms + ChrW(13) + "Debe Introducir un Nit Para Efectuar el Pago".ToUpper

                End If
            End If
            If (namefactura.ToString.Length <= 0) Then
                If (sms = String.Empty) Then
                    sms = "Debe Introducir un nombre a quien se facturara Para Efectuar el Pago".ToUpper
                Else
                    sms = sms + ChrW(13) + "Debe Introducir un nombre a quien se facturara Para Efectuar el Pago".ToUpper
                    End
                End If

            End If
            If (Not sms = String.Empty) Then
                        ToastNotification.Show(Me, sms.ToUpper,
                           My.Resources.WARNING,
                           Duracion * 1000,
                           eToastGlowColor.Red,
                           eToastPosition.TopCenter)
                        Return False
                        Exit Function
                    End If
                    Return True
                End If
                Return True
    End Function

    Private Sub Dgj1Busqueda_EditingCell(sender As Object, e As EditingCellEventArgs) Handles Dgj1Busqueda.EditingCell
        e.Cancel = True
    End Sub

    Private Sub P_ArmarCombos()

    End Sub

    Private Sub P_ArmarGrillas()
        P_ArmarGrillaBusqueda()
        P_ArmarGrillaPagos(1)
        P_ArmarGrillaMortuoria(1)
        'DgdPagos.Visible = False
    End Sub

    Private Sub P_ArmarGrillaBusqueda()
        DtCabecera = New DataTable
        DtCabecera = L_fnSocioGeneral()

        Dgj1Busqueda.BoundMode = Janus.Data.BoundMode.Bound
        Dgj1Busqueda.DataSource = DtCabecera
        Dgj1Busqueda.RetrieveStructure()

        'a.cfnumi, a.cftsoc, b.cedesc1 as tsocio, a.cffing, a.cffnac, a.cflnac, a.cfnom, a.cfapat, a.cfamat, a.cfprof, a.cfdir1,
        'a.cfdir2, a.cfsdir, a.cfcas, a.cfemail, cfci, a.cfciemi, c.cedesc1 as lemision, a.cfnome, a.cffnace, a.cflnace, a.cfobs, a.cfmor,
        'a.cftar, a.cfntar, a.cfest, a.cfimg, a.cffact, a.cfhact, a.cfuact

        'dar formato a las columnas
        With Dgj1Busqueda.RootTable.Columns(0)
            .Caption = ""
            .Key = "cfnumi"
            .Width = 0
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = 8
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = False
        End With
        With Dgj1Busqueda.RootTable.Columns(1)
            .Caption = ""
            .Key = "cftsoc"
            .Width = 0
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = 8
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = False
        End With
        With Dgj1Busqueda.RootTable.Columns(2)
            .Caption = "Tipo Socio"
            .Key = "tsocio"
            .Width = 100
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = 8
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = True
        End With
        With Dgj1Busqueda.RootTable.Columns(3)
            .Caption = "Nro Socio"
            .Key = "cfnsoc"
            .Width = 100
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = 8
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = True
        End With
        With Dgj1Busqueda.RootTable.Columns(4)
            .Caption = "Fecha Ingreso"
            .Key = "cffing"
            .Width = 100
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = 8
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = True
        End With
        With Dgj1Busqueda.RootTable.Columns(5)
            .Caption = "Fecha Nacimiento"
            .Key = "cffnac"
            .Width = 100
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = 8
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = True
        End With
        With Dgj1Busqueda.RootTable.Columns(6)
            .Caption = "Lugar Nacimiento"
            .Key = "cflnac"
            .Width = 150
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = 8
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = False
        End With
        With Dgj1Busqueda.RootTable.Columns(7)
            .Caption = "Nombre"
            .Key = "cfnom"
            .Width = 150
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = 8
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = True
        End With
        With Dgj1Busqueda.RootTable.Columns(8)
            .Caption = "Apellido Paterno"
            .Key = "cfapat"
            .Width = 120
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = 8
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = True
        End With
        With Dgj1Busqueda.RootTable.Columns(9)
            .Caption = "Apellido Materno"
            .Key = "cfamat"
            .Width = 120
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = 8
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = True
        End With
        With Dgj1Busqueda.RootTable.Columns(10)
            .Caption = "Profesión"
            .Key = "cfprof"
            .Width = 120
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = 8
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = True
        End With
        With Dgj1Busqueda.RootTable.Columns(11)
            .Caption = "Dir Oficina"
            .Key = "cfdir1"
            .Width = 150
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = 8
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = False
        End With
        With Dgj1Busqueda.RootTable.Columns(12)
            .Caption = "Dir Domicilio"
            .Key = "cfdir2"
            .Width = 150
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = 8
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = False
        End With
        With Dgj1Busqueda.RootTable.Columns(13)
            .Caption = "Dir Envio"
            .Key = "cfsdir"
            .Width = 100
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = 8
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .Visible = False
        End With
        With Dgj1Busqueda.RootTable.Columns(14)
            .Caption = "Nro Casilla"
            .Key = "cfcas"
            .Width = 120
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = 8
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = False
        End With
        With Dgj1Busqueda.RootTable.Columns(15)
            .Caption = "E-Mail"
            .Key = "cfemail"
            .Width = 120
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = 8
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = False
        End With
        With Dgj1Busqueda.RootTable.Columns(16)
            .Caption = "Carnet de Identidad"
            .Key = "cfci"
            .Width = 120
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = 8
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = True
        End With
        With Dgj1Busqueda.RootTable.Columns(17)
            .Caption = ""
            .Key = "cfciemi"
            .Width = 0
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = 8
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = False
        End With
        With Dgj1Busqueda.RootTable.Columns(18)
            .Caption = "Lugar Emisión"
            .Key = "lemision"
            .Width = 150
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = 8
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = False
        End With
        With Dgj1Busqueda.RootTable.Columns(19)
            .Caption = "Nombre Esposa"
            .Key = "cfnome"
            .Width = 200
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = 8
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = False
        End With
        With Dgj1Busqueda.RootTable.Columns(20)
            .Caption = "Fecha Nac Esposa"
            .Key = "cffnace"
            .Width = 100
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = 8
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = False
        End With
        With Dgj1Busqueda.RootTable.Columns(21)
            .Caption = "Lugar Nac Esposa"
            .Key = "cflnace"
            .Width = 150
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = 8
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = False
        End With
        With Dgj1Busqueda.RootTable.Columns(22)
            .Caption = "Observaciones"
            .Key = "cfobs"
            .Width = 200
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = 8
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = False
        End With
        With Dgj1Busqueda.RootTable.Columns(23)
            .Caption = "Caja Mortoria"
            .Key = "cfmor"
            .Width = 100
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = 8
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .Visible = False
        End With
        With Dgj1Busqueda.RootTable.Columns(24)
            .Caption = "Tarjeta Deb/Cre"
            .Key = "cftar"
            .Width = 100
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = 8
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .Visible = True
        End With
        With Dgj1Busqueda.RootTable.Columns(25)
            .Caption = "Nro Tarjeta"
            .Key = "cfntar"
            .Width = 120
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = 8
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = True
        End With
        With Dgj1Busqueda.RootTable.Columns(26)
            .Caption = "Estado"
            .Key = "cfest"
            .Width = 100
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = 8
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .Visible = False
        End With
        With Dgj1Busqueda.RootTable.Columns(27)
            .Caption = "Foto"
            .Key = "cfimg"
            .Width = 150
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = 8
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = False
        End With
        With Dgj1Busqueda.RootTable.Columns(28)
            .Caption = ""
            .Key = "cffact"
            .Width = 0
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = 8
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = False
        End With
        With Dgj1Busqueda.RootTable.Columns(29)
            .Caption = ""
            .Key = "cfhact"
            .Width = 0
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = 8
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = False
        End With
        With Dgj1Busqueda.RootTable.Columns(30)
            .Caption = ""
            .Key = "cfuact"
            .Width = 0
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = 8
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = False
        End With

        'Habilitar Filtradores
        With Dgj1Busqueda
            .GroupByBoxVisible = False
            '.FilterRowFormatStyle.BackColor = Color.Blue
            .DefaultFilterRowComparison = FilterConditionOperator.Contains
            .FilterMode = FilterMode.Automatic
            .FilterRowUpdateMode = FilterRowUpdateMode.WhenValueChanges
            'Diseño de la tabla
            .VisualStyle = VisualStyle.Office2007
            .SelectionMode = SelectionMode.SingleSelection
            .AlternatingColors = True
        End With
    End Sub

    Private Sub P_ArmarGrillaPagos(sw As Byte)
        If (sw = 1) Then
            DtDetalle = New DataTable
            DtDetalle = L_fnSocioDetallePagosUltimoDosAnho("-1", tbiGestion.Value)
        End If

        DgdPagos.PrimaryGrid.Columns.Clear()
        Dim col As GridColumn

        '1
        With DgdPagos.PrimaryGrid.Columns
            col = New GridColumn("senumi")
            col.HeaderText = ""
            col.HeaderStyles.Default.Font = FontHeader
            col.Width = 0
            col.CellStyles.Default.Font = FontText
            col.HeaderStyles.Default.Alignment = Style.Alignment.MiddleCenter
            col.CellStyles.Default.Alignment = Style.Alignment.MiddleRight
            col.Visible = False
            col.ReadOnly = True
            .Add(col)
        End With
        '2
        With DgdPagos.PrimaryGrid.Columns
            col = New GridColumn("semes")
            col.HeaderText = ""
            col.HeaderStyles.Default.Font = FontHeader
            col.Width = 0
            col.CellStyles.Default.Font = FontText
            col.HeaderStyles.Default.Alignment = Style.Alignment.MiddleCenter
            col.CellStyles.Default.Alignment = Style.Alignment.MiddleRight
            col.Visible = False
            col.ReadOnly = True
            .Add(col)
        End With
        '3
        With DgdPagos.PrimaryGrid.Columns
            col = New GridColumn("senmes")
            col.HeaderText = "Mes"
            col.HeaderStyles.Default.Font = FontHeader
            col.Width = 80
            col.CellStyles.Default.Font = FontText
            col.HeaderStyles.Default.Alignment = Style.Alignment.MiddleCenter
            col.CellStyles.Default.Alignment = Style.Alignment.MiddleRight
            col.Visible = True
            col.ReadOnly = True
            .Add(col)
        End With
        '4
        With DgdPagos.PrimaryGrid.Columns
            col = New GridColumn("seano")
            col.HeaderText = "Año"
            col.HeaderStyles.Default.Font = FontHeader
            col.Width = 50
            col.CellStyles.Default.Font = FontText
            col.HeaderStyles.Default.Alignment = Style.Alignment.MiddleCenter
            col.CellStyles.Default.Alignment = Style.Alignment.MiddleRight
            col.Visible = True
            col.ReadOnly = True
            .Add(col)
        End With
        '5
        With DgdPagos.PrimaryGrid.Columns
            col = New GridColumn("sefec")
            col.HeaderText = "Fecha"
            col.HeaderStyles.Default.Font = FontHeader
            col.Width = 80
            col.CellStyles.Default.Font = FontText
            col.HeaderStyles.Default.Alignment = Style.Alignment.MiddleCenter
            col.CellStyles.Default.Alignment = Style.Alignment.MiddleRight
            col.Visible = True
            col.ReadOnly = True
            col.EditorType = GetType(GridDateTimePickerEditControl)
            .Add(col)
        End With
        '6
        With DgdPagos.PrimaryGrid.Columns
            col = New GridColumn("serec")
            col.HeaderText = "Recibo"
            col.HeaderStyles.Default.Font = FontHeader
            col.Width = 60
            col.CellStyles.Default.Font = FontText
            col.HeaderStyles.Default.Alignment = Style.Alignment.MiddleCenter
            col.CellStyles.Default.Alignment = Style.Alignment.MiddleRight
            col.Visible = True
            col.ReadOnly = True
            .Add(col)
        End With
        '7
        With DgdPagos.PrimaryGrid.Columns
            col = New GridColumn("seimp1")
            col.HeaderText = "Importe"
            col.HeaderStyles.Default.Font = FontHeader
            col.Width = 60
            col.CellStyles.Default.Font = FontText
            col.HeaderStyles.Default.Alignment = Style.Alignment.MiddleCenter
            col.CellStyles.Default.Alignment = Style.Alignment.MiddleRight
            col.Visible = True
            col.ReadOnly = True
            .Add(col)
        End With
        '8
        With DgdPagos.PrimaryGrid.Columns
            col = New GridColumn("check1")
            col.HeaderText = ""
            col.HeaderStyles.Default.Font = FontHeader
            col.Width = 30
            col.CellStyles.Default.Font = FontText
            col.HeaderStyles.Default.Alignment = Style.Alignment.MiddleCenter
            col.CellStyles.Default.Alignment = Style.Alignment.MiddleCenter
            col.Visible = True
            col.ReadOnly = False
            col.EditorType = GetType(GridCheckBoxEditControl)
            .Add(col)
        End With
        '9
        With DgdPagos.PrimaryGrid.Columns
            col = New GridColumn("sesaldo")
            col.HeaderText = "Saldo"
            col.HeaderStyles.Default.Font = FontHeader
            col.Width = 60
            col.CellStyles.Default.Font = FontText
            col.HeaderStyles.Default.Alignment = Style.Alignment.MiddleCenter
            col.CellStyles.Default.Alignment = Style.Alignment.MiddleRight
            col.Visible = True
            col.ReadOnly = True
            .Add(col)
        End With
        '10
        With DgdPagos.PrimaryGrid.Columns
            col = New GridColumn("saldoBD")
            col.HeaderText = ""
            col.HeaderStyles.Default.Font = FontHeader
            col.Width = 60
            col.CellStyles.Default.Font = FontText
            col.HeaderStyles.Default.Alignment = Style.Alignment.MiddleCenter
            col.CellStyles.Default.Alignment = Style.Alignment.MiddleRight
            col.Visible = False
            col.ReadOnly = True
            .Add(col)
        End With
        '11
        With DgdPagos.PrimaryGrid.Columns
            col = New GridColumn("seest")
            col.HeaderText = "Estado"
            col.HeaderStyles.Default.Font = FontHeader
            col.Width = 80
            col.CellStyles.Default.Font = FontText
            col.HeaderStyles.Default.Alignment = Style.Alignment.MiddleCenter
            col.CellStyles.Default.Alignment = Style.Alignment.MiddleRight
            col.Visible = False
            col.ReadOnly = True
            .Add(col)
        End With
        '12
        With DgdPagos.PrimaryGrid.Columns
            col = New GridColumn("selin")
            col.HeaderText = "Linea"
            col.HeaderStyles.Default.Font = FontHeader
            col.Width = 50
            col.CellStyles.Default.Font = FontText
            col.HeaderStyles.Default.Alignment = Style.Alignment.MiddleCenter
            col.CellStyles.Default.Alignment = Style.Alignment.MiddleRight
            col.Visible = False
            col.ReadOnly = True
            .Add(col)
        End With
        '13
        With DgdPagos.PrimaryGrid.Columns
            col = New GridColumn("estado")
            col.HeaderText = ""
            col.HeaderStyles.Default.Font = FontHeader
            col.Width = 0
            col.CellStyles.Default.Font = FontText
            col.HeaderStyles.Default.Alignment = Style.Alignment.MiddleCenter
            col.CellStyles.Default.Alignment = Style.Alignment.MiddleRight
            col.Visible = False
            col.ReadOnly = True
            .Add(col)
        End With
        '14
        With DgdPagos.PrimaryGrid.Columns
            col = New GridColumn("sefact")
            col.HeaderText = ""
            col.HeaderStyles.Default.Font = FontHeader
            col.Width = 0
            col.CellStyles.Default.Font = FontText
            col.HeaderStyles.Default.Alignment = Style.Alignment.MiddleCenter
            col.CellStyles.Default.Alignment = Style.Alignment.MiddleRight
            col.Visible = False
            col.ReadOnly = True
            .Add(col)
        End With
        '15
        With DgdPagos.PrimaryGrid.Columns
            col = New GridColumn("sehact")
            col.HeaderText = ""
            col.HeaderStyles.Default.Font = FontHeader
            col.Width = 0
            col.CellStyles.Default.Font = FontText
            col.HeaderStyles.Default.Alignment = Style.Alignment.MiddleCenter
            col.CellStyles.Default.Alignment = Style.Alignment.MiddleRight
            col.Visible = False
            col.ReadOnly = True
            .Add(col)
        End With
        '16
        With DgdPagos.PrimaryGrid.Columns
            col = New GridColumn("seuact")
            col.HeaderText = ""
            col.HeaderStyles.Default.Font = FontHeader
            col.Width = 0
            col.CellStyles.Default.Font = FontText
            col.HeaderStyles.Default.Alignment = Style.Alignment.MiddleCenter
            col.CellStyles.Default.Alignment = Style.Alignment.MiddleRight
            col.Visible = False
            col.ReadOnly = True
            .Add(col)
        End With

        '17
        With DgdPagos.PrimaryGrid.Columns
            col = New GridColumn("senumi2")
            col.HeaderText = ""
            col.HeaderStyles.Default.Font = FontHeader
            col.Width = 0
            col.CellStyles.Default.Font = FontText
            col.HeaderStyles.Default.Alignment = Style.Alignment.MiddleCenter
            col.CellStyles.Default.Alignment = Style.Alignment.MiddleRight
            col.Visible = False
            col.ReadOnly = True
            .Add(col)
        End With
        '18
        With DgdPagos.PrimaryGrid.Columns
            col = New GridColumn("semes2")
            col.HeaderText = ""
            col.HeaderStyles.Default.Font = FontHeader
            col.Width = 0
            col.CellStyles.Default.Font = FontText
            col.HeaderStyles.Default.Alignment = Style.Alignment.MiddleCenter
            col.CellStyles.Default.Alignment = Style.Alignment.MiddleRight
            col.Visible = False
            col.ReadOnly = True
            .Add(col)
        End With
        '19
        With DgdPagos.PrimaryGrid.Columns
            col = New GridColumn("senmes2")
            col.HeaderText = "Mes"
            col.HeaderStyles.Default.Font = FontHeader
            col.Width = 80
            col.CellStyles.Default.Font = FontText
            col.HeaderStyles.Default.Alignment = Style.Alignment.MiddleCenter
            col.CellStyles.Default.Alignment = Style.Alignment.MiddleRight
            col.Visible = True
            col.ReadOnly = True
            .Add(col)
        End With
        '20
        With DgdPagos.PrimaryGrid.Columns
            col = New GridColumn("seano2")
            col.HeaderText = "Año"
            col.HeaderStyles.Default.Font = FontHeader
            col.Width = 50
            col.CellStyles.Default.Font = FontText
            col.HeaderStyles.Default.Alignment = Style.Alignment.MiddleCenter
            col.CellStyles.Default.Alignment = Style.Alignment.MiddleRight
            col.Visible = True
            col.ReadOnly = True
            .Add(col)
        End With
        '21
        With DgdPagos.PrimaryGrid.Columns
            col = New GridColumn("sefec2")
            col.HeaderText = "Fecha"
            col.HeaderStyles.Default.Font = FontHeader
            col.Width = 80
            col.CellStyles.Default.Font = FontText
            col.HeaderStyles.Default.Alignment = Style.Alignment.MiddleCenter
            col.CellStyles.Default.Alignment = Style.Alignment.MiddleRight
            col.Visible = True
            col.ReadOnly = True
            col.EditorType = GetType(GridDateTimePickerEditControl)
            .Add(col)
        End With
        '22
        With DgdPagos.PrimaryGrid.Columns
            col = New GridColumn("serec2")
            col.HeaderText = "Recibo"
            col.HeaderStyles.Default.Font = FontHeader
            col.Width = 60
            col.CellStyles.Default.Font = FontText
            col.HeaderStyles.Default.Alignment = Style.Alignment.MiddleCenter
            col.CellStyles.Default.Alignment = Style.Alignment.MiddleRight
            col.Visible = True
            col.ReadOnly = True
            .Add(col)
        End With
        '23
        With DgdPagos.PrimaryGrid.Columns
            col = New GridColumn("seimp12")
            col.HeaderText = "Importe"
            col.HeaderStyles.Default.Font = FontHeader
            col.Width = 60
            col.CellStyles.Default.Font = FontText
            col.HeaderStyles.Default.Alignment = Style.Alignment.MiddleCenter
            col.CellStyles.Default.Alignment = Style.Alignment.MiddleRight
            col.Visible = True
            col.ReadOnly = True
            .Add(col)
        End With
        '24
        With DgdPagos.PrimaryGrid.Columns
            col = New GridColumn("check2")
            col.HeaderText = ""
            col.HeaderStyles.Default.Font = FontHeader
            col.Width = 30
            col.CellStyles.Default.Font = FontText
            col.HeaderStyles.Default.Alignment = Style.Alignment.MiddleCenter
            col.CellStyles.Default.Alignment = Style.Alignment.MiddleCenter
            col.Visible = True
            col.ReadOnly = False
            col.EditorType = GetType(GridCheckBoxEditControl)
            .Add(col)
        End With
        '25
        With DgdPagos.PrimaryGrid.Columns
            col = New GridColumn("sesaldo2")
            col.HeaderText = "Saldo"
            col.HeaderStyles.Default.Font = FontHeader
            col.Width = 60
            col.CellStyles.Default.Font = FontText
            col.HeaderStyles.Default.Alignment = Style.Alignment.MiddleCenter
            col.CellStyles.Default.Alignment = Style.Alignment.MiddleRight
            col.Visible = True
            col.ReadOnly = True
            .Add(col)
        End With
        '26
        With DgdPagos.PrimaryGrid.Columns
            col = New GridColumn("saldoBD2")
            col.HeaderText = ""
            col.HeaderStyles.Default.Font = FontHeader
            col.Width = 60
            col.CellStyles.Default.Font = FontText
            col.HeaderStyles.Default.Alignment = Style.Alignment.MiddleCenter
            col.CellStyles.Default.Alignment = Style.Alignment.MiddleRight
            col.Visible = False
            col.ReadOnly = True
            .Add(col)
        End With
        '27
        With DgdPagos.PrimaryGrid.Columns
            col = New GridColumn("seest2")
            col.HeaderText = "Estado"
            col.HeaderStyles.Default.Font = FontHeader
            col.Width = 80
            col.CellStyles.Default.Font = FontText
            col.HeaderStyles.Default.Alignment = Style.Alignment.MiddleCenter
            col.CellStyles.Default.Alignment = Style.Alignment.MiddleRight
            col.Visible = False
            col.ReadOnly = True
            .Add(col)
        End With
        '28
        With DgdPagos.PrimaryGrid.Columns
            col = New GridColumn("selin2")
            col.HeaderText = "Linea"
            col.HeaderStyles.Default.Font = FontHeader
            col.Width = 50
            col.CellStyles.Default.Font = FontText
            col.HeaderStyles.Default.Alignment = Style.Alignment.MiddleCenter
            col.CellStyles.Default.Alignment = Style.Alignment.MiddleRight
            col.Visible = False
            col.ReadOnly = True
            .Add(col)
        End With
        '29
        With DgdPagos.PrimaryGrid.Columns
            col = New GridColumn("estado2")
            col.HeaderText = ""
            col.HeaderStyles.Default.Font = FontHeader
            col.Width = 0
            col.CellStyles.Default.Font = FontText
            col.HeaderStyles.Default.Alignment = Style.Alignment.MiddleCenter
            col.CellStyles.Default.Alignment = Style.Alignment.MiddleRight
            col.Visible = False
            col.ReadOnly = True
            .Add(col)
        End With
        '30
        With DgdPagos.PrimaryGrid.Columns
            col = New GridColumn("sefact2")
            col.HeaderText = ""
            col.HeaderStyles.Default.Font = FontHeader
            col.Width = 0
            col.CellStyles.Default.Font = FontText
            col.HeaderStyles.Default.Alignment = Style.Alignment.MiddleCenter
            col.CellStyles.Default.Alignment = Style.Alignment.MiddleRight
            col.Visible = False
            col.ReadOnly = True
            .Add(col)
        End With
        '31
        With DgdPagos.PrimaryGrid.Columns
            col = New GridColumn("sehact2")
            col.HeaderText = ""
            col.HeaderStyles.Default.Font = FontHeader
            col.Width = 0
            col.CellStyles.Default.Font = FontText
            col.HeaderStyles.Default.Alignment = Style.Alignment.MiddleCenter
            col.CellStyles.Default.Alignment = Style.Alignment.MiddleRight
            col.Visible = False
            col.ReadOnly = True
            .Add(col)
        End With
        '32
        With DgdPagos.PrimaryGrid.Columns
            col = New GridColumn("seuact2")
            col.HeaderText = ""
            col.HeaderStyles.Default.Font = FontHeader
            col.Width = 0
            col.CellStyles.Default.Font = FontText
            col.HeaderStyles.Default.Alignment = Style.Alignment.MiddleCenter
            col.CellStyles.Default.Alignment = Style.Alignment.MiddleRight
            col.Visible = False
            col.ReadOnly = True
            .Add(col)
        End With

        With DgdPagos.PrimaryGrid
            .ColumnHeader.RowHeight = 25
            .ShowRowHeaders = False
            .UseAlternateRowStyle = True
            .AllowRowHeaderResize = False
            .AllowRowResize = False
            .DefaultRowHeight = 35
            .SelectionGranularity = SelectionGranularity.Cell
        End With

        DgdPagos.PrimaryGrid.DataSource = DtDetalle
        P_LlenarDatosGrillaPagos()
    End Sub

    Private Sub Bt1Buscar_Click(sender As Object, e As EventArgs) Handles Bt1Buscar.Click
        P_FiltrarGridBusqueda()
    End Sub

    Private Sub P_FiltrarGridBusqueda()
        SupTabItemBusqueda.Visible = True
        SuperTabPrincipal.SelectedTabIndex = 1
        Dgj1Busqueda.Select()

        Dgj1Busqueda.RemoveFilters()

        Dgj1Busqueda.MoveTo(Dgj1Busqueda.FilterRow)
        Dgj1Busqueda.Col = 2
        Dgj1Busqueda.AlternatingColors = True
    End Sub

    Private Sub Dgj1Busqueda_KeyDown(sender As Object, e As KeyEventArgs) Handles Dgj1Busqueda.KeyDown
        If (e.KeyData = Keys.Enter And Dgj1Busqueda.CurrentRow.RowIndex > -1) Then
            P_PonerDatosBusqueda()
        End If
    End Sub

    Private Sub P_PonerDatosBusqueda()
        Numi = Dgj1Busqueda.GetValue("cfnumi").ToString

        P_prPonerDatosSocio(Numi, Dgj1Busqueda.GetValue("cfnsoc").ToString,
                            Dgj1Busqueda.GetValue("cfnom").ToString + " " + Dgj1Busqueda.GetValue("cfapat").ToString + " " + Dgj1Busqueda.GetValue("cfamat").ToString,
                            Dgj1Busqueda.GetValue("cffing").ToString, Dgj1Busqueda.GetValue("cfmor").ToString,
                            Dgj1Busqueda.GetValue("cftsoc").ToString, Dgj1Busqueda.GetValue("tsocio").ToString)

        P_Generar(1)

        SuperTabPrincipal.SelectedTabIndex = 0

        Tbd1Monto.Select()
    End Sub

    Private Sub SuperTabPrincipal_SelectedTabChanged(sender As Object, e As SuperTabStripSelectedTabChangedEventArgs) Handles SuperTabPrincipal.SelectedTabChanged
        SupTabItemBusqueda.Visible = Not SuperTabPrincipal.SelectedTabIndex = 0
    End Sub

    Private Sub Dgj1Busqueda_DoubleClick(sender As Object, e As EventArgs) Handles Dgj1Busqueda.DoubleClick
        If (Dgj1Busqueda.CurrentRow.RowIndex > -1) Then
            P_PonerDatosBusqueda()
        End If
    End Sub

    Private Sub Bt2Generar_Click(sender As Object, e As EventArgs) Handles Bt2Generar.Click
        P_CargarVariablesLocales()

        If (Nuevo) Then
            If (P_Validar(1)) Then
                P_ArmarGrillaPagos(0)
                P_ArmarGrillaMortuoria(0)
                P_ValidarCeldasPagos()
                P_ValidarCeldasMortuoria()
            End If
        End If
        If (Modificar) Then
            P_ArmarGrillaPagos(0)
            P_ArmarGrillaMortuoria(0)
            P_ValidarCeldasPagos()
            P_ValidarCeldasMortuoria()
            Tbd1Monto.Value = P_SumarTodo()
            Tb4Cambio.Text = "0"
        End If

    End Sub

    Private Function P_ValidarExistePagos() As Boolean
        Dim Dt As DataTable = L_fnSocioDetallePagos(Numi)
        Return Dt.Rows.Count > 0
    End Function

    Private Function P_ValidarExistePagosMortuoria() As Boolean
        Dim Dt As DataTable = L_fnSocioDetallePagosMortuoria(Numi)
        Return Dt.Rows.Count > 0
    End Function

    Private Function P_ValidarExistePagosAnhoActual() As Boolean
        Dim Dt As DataTable = L_fnSocioDetallePagos(Numi, tbiGestion.Value)
        Return Dt.Rows.Count > 0
    End Function

    Private Function P_ValidarExistePagosAnho(anho As Integer) As Boolean
        Dim Dt As DataTable = L_fnSocioDetallePagos(Numi, anho)
        Return Dt.Rows.Count > 0
    End Function

    Private Function P_ValidarExistePagoAnhoActualMortuoria() As Boolean
        Dim Dt As DataTable = L_fnSocioDetallePagosMortuoria(Numi, Now.Year.ToString)
        Return Dt.Rows.Count > 0
    End Function

    Private Function P_ValidarExistePagoAnhoMortuoria(anho As Integer) As Boolean
        Dim Dt As DataTable = L_fnSocioDetallePagosMortuoria(Numi, anho)
        Return Dt.Rows.Count > 0
    End Function

    Private Function P_ValidarCobro(modo As Byte) As String
        Dim res As String = ""
        If (modo = 1) Then
            If (TbiNroSocio.Value.ToString.Trim.Length = 0) Then
                If (res.Length > 0) Then
                    res = res + ChrW(13) + "elija un socio."
                Else
                    res = "elija un socio."
                End If
            End If
        End If

        If (modo = 2) Then
            If (TbiNroSocio.Value.ToString.Trim.Length = 0) Then
                If (res.Length > 0) Then
                    res = res + ChrW(13) + "elija un socio."
                Else
                    res = "elija un socio."
                End If
            End If
            If (Tbd1Monto.Value = 0) Then
                If (res.Length > 0) Then
                    res = res + ChrW(13) + "ponga un monto."
                Else
                    res = "ponga un monto."
                End If
            End If
            If (Tb3NroRecibo.Text.Trim.Length = 0) Then
                If (res.Length > 0) Then
                    res = res + ChrW(13) + "ponga un número de recibo."
                Else
                    res = "ponga un número de recibo."
                End If
            End If
        End If

        Return res
    End Function

    Private Sub Tbd1Monto_ValueChanged(sender As Object, e As EventArgs) Handles Tbd1Monto.ValueChanged
        If (bandera = False) Then
            Tb4Cambio.Text = Tbd1Monto.Value.ToString
        End If

    End Sub

    Private Function P_SumarPagosCuotas(fecha As Date, est As Integer) As Double
        Dim acu As Double = 0
        For Each fil As GridRow In DgdPagos.PrimaryGrid.Rows
            If (fil.Cells("sefec").Value = fecha And fil.Cells("check1").ReadOnly = False And fil.Cells("seest").Value = est) Then 'Cambiar la fecha por el estado de la grilla (estado)
                If (fil.Cells("sesaldo").Value = 0) Then
                    acu = acu + fil.Cells("saldoBD").Value
                End If
                If (fil.Cells("sesaldo2").Value = 0) Then
                    acu = acu + fil.Cells("saldoBD2").Value
                End If
            ElseIf (fil.Cells("sefec2").Value = fecha And fil.Cells("check2").ReadOnly = False And fil.Cells("seest2").Value = est) Then
                If (fil.Cells("sesaldo").Value = 0) Then
                    acu = acu + fil.Cells("saldoBD").Value
                End If
                If (fil.Cells("sesaldo2").Value = 0) Then
                    acu = acu + fil.Cells("saldoBD2").Value
                End If
            End If
        Next
        Return acu
    End Function

    Private Function P_SumarPagosMortuoria(est As Integer) As Double
        Dim acu As Double = 0
        For Each fil As GridRow In DgdMortuoria.PrimaryGrid.Rows
            If (fil.Cells("check11").ReadOnly = False And fil.Cells("est").Value = est) Then
                If (fil.Cells("saldo").Value = 0) Then
                    acu = acu + fil.Cells("monto").Value
                End If

            ElseIf (fil.Cells("check12").ReadOnly = False And fil.Cells("est2").Value = est) Then

                If (fil.Cells("saldo2").Value = 0) Then
                    acu = acu + fil.Cells("monto2").Value
                End If
            End If
        Next
        Return acu
    End Function

    Private Function P_SumarTodo() As Double
        Dim acu As Double = 0
        For Each fil As GridRow In DgdPagos.PrimaryGrid.Rows
            If (fil.Cells("check1").Value = 1) Then
                acu = acu + fil.Cells("seimp1").Value
            End If
            If (fil.Cells("check2").Value = 1) Then
                acu = acu + fil.Cells("seimp12").Value
            End If
        Next
        For Each fil As GridRow In DgdMortuoria.PrimaryGrid.Rows
            If (fil.Cells("check11").Value = 1) Then
                acu = acu + fil.Cells("monto").Value
            End If
            If (fil.Cells("check12").Value = 1) Then
                acu = acu + fil.Cells("monto2").Value
            End If
        Next
        Return acu
    End Function

    Private Sub Dgd1Pagos_CellValueChanged(sender As Object, e As GridCellValueChangedEventArgs) Handles DgdPagos.CellValueChanged
        'Cuando se marca un check del año anterior 
        'Cuando se marca un check del año actual

        If (e.GridCell.ColumnIndex = DgdPagos.PrimaryGrid.Columns("check1").ColumnIndex Or
            e.GridCell.ColumnIndex = DgdPagos.PrimaryGrid.Columns("check2").ColumnIndex) Then 'Los dos check dela año actual y año anterior
            Dim ifil As Integer = e.GridCell.RowIndex
            Dim icol As Integer = e.GridCell.ColumnIndex

            Dim fecha As GridCell = DgdPagos.PrimaryGrid.GetCell(ifil, icol - 3)
            Dim recibo As GridCell = DgdPagos.PrimaryGrid.GetCell(ifil, icol - 2)
            Dim importe As GridCell = DgdPagos.PrimaryGrid.GetCell(ifil, icol - 1)
            Dim check As GridCell = DgdPagos.PrimaryGrid.GetCell(ifil, icol)
            Dim saldo As GridCell = DgdPagos.PrimaryGrid.GetCell(ifil, icol + 1)
            Dim saldoBD As GridCell = DgdPagos.PrimaryGrid.GetCell(ifil, icol + 2)
            Dim estado1 As GridCell = DgdPagos.PrimaryGrid.GetCell(ifil, 12)
            Dim estado2 As GridCell = DgdPagos.PrimaryGrid.GetCell(ifil, 28)
            Dim est1 As GridCell = DgdPagos.PrimaryGrid.GetCell(ifil, 10)
            Dim est2 As GridCell = DgdPagos.PrimaryGrid.GetCell(ifil, 26)

            If (Nuevo) Then
                If (e.NewValue = True) Then
                    If (CDbl(Tb4Cambio.Text) > 0) Then
                        Dim monto As Double = Tbd1Monto.Value - P_SumarPagosCuotas(Dt2FechaPago.Value, 2) - P_SumarPagosMortuoria(2)

                        fecha.Value = Dt2FechaPago.Value
                        recibo.Value = IIf(Tb3NroRecibo.Text = String.Empty, 0, Tb3NroRecibo.Text)
                        If (monto >= importe.Value) Then
                            If (saldoBD.Value = 0) Then
                                saldo.Value = 0
                                monto = monto - importe.Value
                            Else
                                saldo.Value = 0
                                monto = monto - saldoBD.Value
                            End If

                            If (e.GridCell.ColumnIndex < 14) Then
                                estado1.Value = 2
                                est1.Value = 2
                            Else
                                estado2.Value = 2
                                est2.Value = 2
                            End If
                            Tb4Cambio.Text = monto.ToString
                        Else
                            ToastNotification.Show(Me, "El cambio del monto recibido insuficiente para cubrir la cuota de socio".ToUpper,
                                               My.Resources.INFORMATION, Duracion * 500,
                                               eToastGlowColor.Red,
                                               eToastPosition.TopCenter)
                            e.GridCell.Value = e.OldValue
                        End If
                    Else
                        ToastNotification.Show(Me, "El cambio del monto recibido es cero (0)".ToUpper,
                                               My.Resources.INFORMATION, Duracion * 500,
                                               eToastGlowColor.Red,
                                               eToastPosition.TopCenter)
                        e.GridCell.Value = e.OldValue
                    End If
                ElseIf (e.NewValue = False) Then
                    Dim monto As Double = Tbd1Monto.Value - P_SumarPagosCuotas(Dt2FechaPago.Value, 2) - P_SumarPagosMortuoria(2)

                    fecha.Value = "2000/01/01"
                    recibo.Value = 0
                    If (saldo.Value = 0) Then
                        monto = monto + importe.Value
                        saldo.Value = importe.Value

                        If (e.GridCell.ColumnIndex < 14) Then
                            estado1.Value = 1
                            est1.Value = 1
                        Else
                            estado2.Value = 1
                            est2.Value = 1
                        End If
                        Tb4Cambio.Text = monto.ToString
                    End If
                End If
                If (CDbl(Tb4Cambio.Text) <= 0) Then
                    Tb4Cambio.Text = "0"
                End If
            End If

            'Ver luego
            If (Modificar) Then
                If (e.NewValue = True) Then
                    'Dim monto As Double = Tbd1Monto.Value - P_SumarTodo()
                    Dim monto As Double = CDbl(Tb4Cambio.Text)
                    If (monto >= importe.Value) Then
                        fecha.Value = Dt2FechaPago.Value
                        recibo.Value = Tb3NroRecibo.Text
                        If (saldoBD.Value = 0) Then
                            saldo.Value = 0
                            monto = monto - importe.Value
                        Else
                            saldo.Value = 0
                            monto = monto - saldoBD.Value
                        End If

                        If (e.GridCell.ColumnIndex < 14) Then
                            estado1.Value = 2
                            est1.Value = 2
                        Else
                            estado2.Value = 2
                            est2.Value = 2
                        End If
                        Tb4Cambio.Text = monto.ToString
                    Else
                        ToastNotification.Show(Me, "El cambio del monto recibido insuficiente para cubrir la cuota de socio".ToUpper,
                                           My.Resources.INFORMATION, Duracion * 500,
                                           eToastGlowColor.Red,
                                           eToastPosition.TopCenter)
                        e.GridCell.Value = e.OldValue
                    End If
                ElseIf (e.NewValue = False) Then
                    'Dim monto As Double = Tbd1Monto.Value - P_SumarPagosCuotas(Now.Date, 2) - P_SumarPagosMortuoria(2)
                    Dim monto As Double = Tbd1Monto.Value - P_SumarTodo()

                    fecha.Value = "2000/01/01"
                    recibo.Value = 0
                    If (saldo.Value = 0) Then
                        saldo.Value = importe.Value
                        If (e.GridCell.ColumnIndex < 14) Then
                            estado1.Value = 2
                            est1.Value = 1
                        Else
                            estado2.Value = 2
                            est2.Value = 1
                        End If
                        Tb4Cambio.Text = monto.ToString
                    End If
                End If
                If (CDbl(Tb4Cambio.Text) <= 0) Then
                    Tb4Cambio.Text = "0"
                End If
            End If

        End If
    End Sub

    Private Sub P_ValidarCeldasPagos()
        Dim lim As Integer = (DgdPagos.PrimaryGrid.Columns.Count / 2) - 1
        Dim precio As Double = 0
        'Poner precio y solo lectura a lo que corresponde
        For Each fil As GridRow In DgdPagos.PrimaryGrid.Rows
            '---------------------------------Anho Pasado----------------------------------------------
            'Poner precio anho pasado
            If (fil.Cells("seest").Value = -2) Then 'Estado GENERADO
                precio = P_PonerPrecioCuotaSocio(fil.Cells("semes").Value, fil.Cells("seano").Value)
                fil.Cells("seimp1").Value = precio
                fil.Cells("sesaldo").Value = precio
                fil.Cells("saldoBD").Value = precio
                If (precio > 0) Then 'Poner estado CON PRECIO
                    fil.Cells("seest").Value = 1
                Else 'Poner estado SIN PRECIO
                    fil.Cells("seest").Value = -1
                End If
            Else
                'Se esta modificando los precio de las cuotas que estan sin pagar
                If (fil.Cells("seest").Value = 1) Then
                    precio = P_PonerPrecioCuotaSocio(fil.Cells("semes").Value, fil.Cells("seano").Value)
                    fil.Cells("seimp1").Value = precio
                    fil.Cells("sesaldo").Value = precio
                    fil.Cells("saldoBD").Value = precio
                End If
                'Poner como pagado las coutas que no corresponden
                'If (fil.Cells("seest").Value = 0) Then
                '    fil.Cells("sesaldo").Value = 0
                '    fil.Cells("check1").Value = True
                'End If
            End If

            'Poner readonly las celdas checkeadas
            If (fil.Cells("seest").Value = -1) Then
                fil.Cells("check1").ReadOnly = True
            ElseIf (fil.Cells("seest").Value = 0) Then
                fil.Cells("check1").ReadOnly = True
            ElseIf (fil.Cells("seest").Value = 1) Then
                fil.Cells("check1").ReadOnly = False
            ElseIf (fil.Cells("seest").Value = 2) Then
                fil.Cells("check1").ReadOnly = Not Modificar
            End If
            '---------------------------------Anho Actual----------------------------------------------
            'Poner precio anho pasado
            If (fil.Cells("seest2").Value = -2) Then 'Estado GENERADO
                precio = P_PonerPrecioCuotaSocio(fil.Cells("semes2").Value, fil.Cells("seano2").Value)
                fil.Cells("seimp12").Value = precio
                fil.Cells("sesaldo2").Value = precio
                fil.Cells("saldoBD2").Value = precio
                If (precio > 0) Then 'Poner estado CON PRECIO
                    fil.Cells("seest2").Value = 1
                Else 'Poner estado SIN PRECIO
                    fil.Cells("seest2").Value = -1
                End If
            Else
                'Se esta modificando los precio de las cuotas que estan sin pagar
                If (fil.Cells("seest2").Value = 1) Then
                    precio = P_PonerPrecioCuotaSocio(fil.Cells("semes2").Value, fil.Cells("seano2").Value)
                    fil.Cells("seimp12").Value = precio
                    fil.Cells("sesaldo2").Value = precio
                    fil.Cells("saldoBD2").Value = precio
                End If
                'Poner como pagado las coutas que no corresponden
                'If (fil.Cells("seest2").Value = 0) Then
                '    fil.Cells("sesaldo2").Value = 0
                '    fil.Cells("check2").Value = True
                'End If
            End If

            'Poner readonly las celdas checkeadas
            If (fil.Cells("seest2").Value = -1) Then
                fil.Cells("check2").ReadOnly = True
            ElseIf (fil.Cells("seest2").Value = 0) Then
                fil.Cells("check2").ReadOnly = True
            ElseIf (fil.Cells("seest2").Value = 1) Then
                fil.Cells("check2").ReadOnly = False
            ElseIf (fil.Cells("seest2").Value = 2) Then
                fil.Cells("check2").ReadOnly = Not Modificar
            End If
        Next

        '---------------------------------Poner color a los anho----------------------------------------------
        For Each fil As GridRow In DgdPagos.PrimaryGrid.Rows
            For Each cel As GridCell In fil.Cells
                If (cel.ColumnIndex <= lim) Then
                    cel.CellStyles.Default.Background.Color1 = Color.LightYellow
                Else
                    cel.CellStyles.Default.Background.Color1 = Color.LightBlue
                End If
            Next
        Next
        DgdPagos.Refresh()
    End Sub

    Private Sub P_ValidarCeldasMortuoria()
        Dim lim As Integer = (DgdMortuoria.PrimaryGrid.Columns.Count / 2) - 1
        Dim precio As Double = 0
        'Poner precio y solo lectura a lo que corresponde
        For Each fil As GridRow In DgdMortuoria.PrimaryGrid.Rows
            '---------------------------------Anho Pasado----------------------------------------------
            'Poner precio anho pasado
            If (fil.Cells("est").Value = -2) Then 'Estado GENERADO
                precio = P_PonerPrecioCuotaMortuoria(fil.Cells("gestion").Value)
                fil.Cells("monto").Value = precio
                fil.Cells("saldo").Value = precio
                If (precio > 0) Then 'Poner estado CON PRECIO
                    fil.Cells("est").Value = 1
                Else 'Poner estado SIN PRECIO
                    fil.Cells("est").Value = -1
                End If
            Else
                'Se esta modificando los precio de las cuotas que estan sin pagar
                If (fil.Cells("est").Value = 1) Then
                    precio = P_PonerPrecioCuotaMortuoria(fil.Cells("gestion").Value)
                    fil.Cells("monto").Value = precio
                    fil.Cells("saldo").Value = precio
                End If
                'Poner como pagado las coutas mortuoaria que no corresponden
                'If (fil.Cells("est").Value = 0) Then
                '    fil.Cells("saldo").Value = 0
                '    fil.Cells("check11").Value = True
                'End If
            End If

            If (BoMortuaria) Then
                'Poner readonly las celdas checkeadas
                If (fil.Cells("est").Value = -1) Then
                    fil.Cells("check11").ReadOnly = True
                ElseIf (fil.Cells("est").Value = 0) Then
                    fil.Cells("check11").ReadOnly = True
                ElseIf (fil.Cells("est").Value = 1) Then
                    fil.Cells("check11").ReadOnly = False
                ElseIf (fil.Cells("est").Value = 2) Then
                    fil.Cells("check11").ReadOnly = Not Modificar
                End If
            Else
                fil.Cells("check11").ReadOnly = True
            End If

            '---------------------------------Anho Actual----------------------------------------------
            'Poner precio anho pasado
            If (fil.Cells("est2").Value = -2) Then 'Estado GENERADO
                precio = P_PonerPrecioCuotaMortuoria(fil.Cells("gestion2").Value)
                fil.Cells("monto2").Value = precio
                fil.Cells("saldo2").Value = precio
                If (precio > 0) Then 'Poner estado CON PRECIO
                    fil.Cells("est2").Value = 1
                Else 'Poner estado SIN PRECIO
                    fil.Cells("est2").Value = -1
                End If
            Else
                'Se esta modificando los precio de las cuotas que estan sin pagar
                If (fil.Cells("est2").Value = 1) Then
                    precio = P_PonerPrecioCuotaMortuoria(fil.Cells("gestion2").Value)
                    fil.Cells("monto2").Value = precio
                    fil.Cells("saldo2").Value = precio
                End If
                'Poner como pagado las coutas mortuoaria que no corresponden
                'If (fil.Cells("est2").Value = 0) Then
                '    fil.Cells("saldo2").Value = 0
                '    fil.Cells("check12").Value = True
                'End If
            End If

            If (BoMortuaria) Then
                'Poner readonly las celdas checkeadas
                If (fil.Cells("est2").Value = -1) Then
                    fil.Cells("check12").ReadOnly = True
                ElseIf (fil.Cells("est2").Value = 0) Then
                    fil.Cells("check12").ReadOnly = True
                ElseIf (fil.Cells("est2").Value = 1) Then
                    fil.Cells("check12").ReadOnly = False
                ElseIf (fil.Cells("est2").Value = 2) Then
                    fil.Cells("check12").ReadOnly = Not Modificar
                End If
            Else
                fil.Cells("check12").ReadOnly = True
            End If
        Next

        '---------------------------------Poner color a los anho----------------------------------------------
        For Each fil As GridRow In DgdMortuoria.PrimaryGrid.Rows
            For Each cel As GridCell In fil.Cells
                If (cel.ColumnIndex <= lim) Then
                    cel.CellStyles.Default.Background.Color1 = Color.LightYellow
                Else
                    cel.CellStyles.Default.Background.Color1 = Color.LightBlue
                End If
            Next
        Next
        DgdMortuoria.Refresh()
    End Sub
    Private Function P_PonerPrecioCuotaSocio(mes As Integer, anho As Integer) As Double
        Return DtPrecio.Select("eemes=" + mes.ToString + " and eeano=" + anho.ToString)(0).Item("eeprecio")
    End Function

    Private Function P_PonerPrecioCuotaMortuoria(anho As Integer) As Double
        Return DtPrecioMortuoria.Select("eeano=" + anho.ToString)(0).Item("eeprecio")
    End Function

    Private Sub P_Generar(modo As Integer)
        Dim sms As String = P_ValidarCobro(modo)
        If (sms.Equals("")) Then
            If (P_ValidarExistePagos()) Then
                If (Not P_ValidarExistePagosAnho(tbiGestion.Value - 1)) Then
                    'Insertar año xxxx-1 completo
                    Dim res As Boolean = L_fnSocioPagosGrabarAnho(Numi, tbiGestion.Value.ToString)
                End If
                If (Not P_ValidarExistePagosAnho(tbiGestion.Value)) Then
                    'Insertar año xxxx completo
                    Dim res As Boolean = L_fnSocioPagosGrabarAnho(Numi, tbiGestion.Value.ToString)
                End If
                DtDetalle = L_fnSocioDetallePagosUltimoDosAnho(Numi, tbiGestion.Value.ToString)
            Else
                'Insertar año actual y año anterior completo
                Dim res As Boolean = L_fnSocioPagosGrabarAnho(Numi, (tbiGestion.Value - 1).ToString)
                Dim res2 As Boolean = L_fnSocioPagosGrabarAnho(Numi, tbiGestion.Value.ToString)

                'Solo traer pagos ultimos dos año
                DtDetalle = L_fnSocioDetallePagosUltimoDosAnho(Numi, tbiGestion.Value.ToString)
            End If
            'P_ArmarGrillaPagos(0)

            If (P_ValidarExistePagosMortuoria()) Then
                If (Not P_ValidarExistePagoAnhoMortuoria(tbiGestion.Value - 1)) Then
                    'Insertar año xxxx-1 completo
                    Dim res As Boolean = L_fnSocioPagosMortuoriaGrabarAnho(Numi, tbiGestion.Value.ToString)
                End If
                If (Not P_ValidarExistePagoAnhoMortuoria(tbiGestion.Value)) Then
                    'Insertar año xxxx completo
                    Dim res As Boolean = L_fnSocioPagosMortuoriaGrabarAnho(Numi, tbiGestion.Value.ToString)
                End If
                'DtMortuoria = L_fnSocioDetallePagosMortuoriaUltimoDosAnho(Numi, tbiGestion.Value.ToString)
                DtMortuoria = L_fnSocioDetallePagosMortuoriaUltimoDosAnho(TbiNroSocio.Value, tbiGestion.Value.ToString)
            Else
                'Insertar año actual y año anterior completo
                Dim res As Boolean = L_fnSocioPagosMortuoriaGrabarAnho(Numi, (tbiGestion.Value - 1).ToString)
                Dim res2 As Boolean = L_fnSocioPagosMortuoriaGrabarAnho(Numi, tbiGestion.Value.ToString)

                'Solo traer pagos ultimos dos año
                'DtMortuoria = L_fnSocioDetallePagosMortuoriaUltimoDosAnho(Numi, tbiGestion.Value.ToString)
                DtMortuoria = L_fnSocioDetallePagosMortuoriaUltimoDosAnho(TbiNroSocio.Value, tbiGestion.Value.ToString)
            End If
            'P_ArmarGrillaMortuoria(0)
        Else
            ToastNotification.Show(Me, sms.ToUpper,
                       My.Resources.WARNING,
                       Duracion * 1000,
                       eToastGlowColor.Red,
                       eToastPosition.TopCenter)
        End If
    End Sub

    Private Sub P_CargarVariablesLocales()
        P_prArmarDtPrecioCuota()
        P_prArmarDtPrecioMortuoria()
    End Sub

    Private Sub P_ArmarGrillaMortuoria(sw As Byte)
        If (sw = 1) Then
            DtMortuoria = New DataTable
            DtMortuoria = L_fnSocioDetallePagosMortuoriaUltimoDosAnho("-1", tbiGestion.Value)
        End If

        DgdMortuoria.PrimaryGrid.Columns.Clear()
        Dim col As GridColumn

        '1
        With DgdMortuoria.PrimaryGrid.Columns
            col = New GridColumn("numi")
            col.HeaderText = ""
            col.HeaderStyles.Default.Font = FontHeader
            col.Width = 0
            col.CellStyles.Default.Font = FontText
            col.HeaderStyles.Default.Alignment = Style.Alignment.MiddleCenter
            col.CellStyles.Default.Alignment = Style.Alignment.MiddleRight
            col.Visible = False
            col.ReadOnly = True
            .Add(col)
        End With
        '2
        With DgdMortuoria.PrimaryGrid.Columns
            col = New GridColumn("gestion")
            col.HeaderText = "Pago Mortuoria"
            col.HeaderStyles.Default.Font = FontHeader
            col.Width = 130
            col.CellStyles.Default.Font = FontText
            col.HeaderStyles.Default.Alignment = Style.Alignment.MiddleCenter
            col.CellStyles.Default.Alignment = Style.Alignment.MiddleCenter
            col.Visible = True
            col.ReadOnly = True
            .Add(col)
        End With
        '3
        With DgdMortuoria.PrimaryGrid.Columns
            col = New GridColumn("fdoc")
            col.HeaderText = "Fecha"
            col.HeaderStyles.Default.Font = FontHeader
            col.Width = 80
            col.CellStyles.Default.Font = FontText
            col.HeaderStyles.Default.Alignment = Style.Alignment.MiddleCenter
            col.CellStyles.Default.Alignment = Style.Alignment.MiddleRight
            col.Visible = True
            col.ReadOnly = True
            col.EditorType = GetType(GridDateTimePickerEditControl)
            .Add(col)
        End With
        '4
        With DgdMortuoria.PrimaryGrid.Columns
            col = New GridColumn("rec")
            col.HeaderText = "Recibo"
            col.HeaderStyles.Default.Font = FontHeader
            col.Width = 60
            col.CellStyles.Default.Font = FontText
            col.HeaderStyles.Default.Alignment = Style.Alignment.MiddleCenter
            col.CellStyles.Default.Alignment = Style.Alignment.MiddleRight
            col.Visible = True
            col.ReadOnly = True
            .Add(col)
        End With
        '5
        With DgdMortuoria.PrimaryGrid.Columns
            col = New GridColumn("monto")
            col.HeaderText = "Importe"
            col.HeaderStyles.Default.Font = FontHeader
            col.Width = 60
            col.CellStyles.Default.Font = FontText
            col.HeaderStyles.Default.Alignment = Style.Alignment.MiddleCenter
            col.CellStyles.Default.Alignment = Style.Alignment.MiddleRight
            col.Visible = True
            col.ReadOnly = True
            .Add(col)
        End With
        '6
        With DgdMortuoria.PrimaryGrid.Columns
            col = New GridColumn("check11")
            col.HeaderText = ""
            col.HeaderStyles.Default.Font = FontHeader
            col.Width = 30
            col.CellStyles.Default.Font = FontText
            col.HeaderStyles.Default.Alignment = Style.Alignment.MiddleCenter
            col.CellStyles.Default.Alignment = Style.Alignment.MiddleCenter
            col.Visible = True
            col.ReadOnly = False
            col.EditorType = GetType(GridCheckBoxEditControl)
            .Add(col)
        End With
        '7
        With DgdMortuoria.PrimaryGrid.Columns
            col = New GridColumn("est")
            col.HeaderText = ""
            col.HeaderStyles.Default.Font = FontHeader
            col.Width = 30
            col.CellStyles.Default.Font = FontText
            col.HeaderStyles.Default.Alignment = Style.Alignment.MiddleCenter
            col.CellStyles.Default.Alignment = Style.Alignment.MiddleCenter
            col.Visible = False
            col.ReadOnly = True
            .Add(col)
        End With
        '8
        With DgdMortuoria.PrimaryGrid.Columns
            col = New GridColumn("saldo")
            col.HeaderText = "Saldo"
            col.HeaderStyles.Default.Font = FontHeader
            col.Width = 60
            col.CellStyles.Default.Font = FontText
            col.HeaderStyles.Default.Alignment = Style.Alignment.MiddleCenter
            col.CellStyles.Default.Alignment = Style.Alignment.MiddleRight
            col.Visible = True
            col.ReadOnly = True
            .Add(col)
        End With
        '9
        With DgdMortuoria.PrimaryGrid.Columns
            col = New GridColumn("lin")
            col.HeaderText = ""
            col.HeaderStyles.Default.Font = FontHeader
            col.Width = 0
            col.CellStyles.Default.Font = FontText
            col.HeaderStyles.Default.Alignment = Style.Alignment.MiddleCenter
            col.CellStyles.Default.Alignment = Style.Alignment.BottomRight
            col.Visible = False
            col.ReadOnly = False
            .Add(col)
        End With
        '10
        With DgdMortuoria.PrimaryGrid.Columns
            col = New GridColumn("estado")
            col.HeaderText = ""
            col.HeaderStyles.Default.Font = FontHeader
            col.Width = 0
            col.CellStyles.Default.Font = FontText
            col.HeaderStyles.Default.Alignment = Style.Alignment.MiddleCenter
            col.CellStyles.Default.Alignment = Style.Alignment.BottomRight
            col.Visible = False
            col.ReadOnly = False
            .Add(col)
        End With
        '11
        With DgdMortuoria.PrimaryGrid.Columns
            col = New GridColumn("fact")
            col.HeaderText = ""
            col.HeaderStyles.Default.Font = FontHeader
            col.Width = 0
            col.CellStyles.Default.Font = FontText
            col.HeaderStyles.Default.Alignment = Style.Alignment.MiddleCenter
            col.CellStyles.Default.Alignment = Style.Alignment.MiddleRight
            col.Visible = False
            col.ReadOnly = True
            .Add(col)
        End With
        '12
        With DgdMortuoria.PrimaryGrid.Columns
            col = New GridColumn("hact")
            col.HeaderText = ""
            col.HeaderStyles.Default.Font = FontHeader
            col.Width = 0
            col.CellStyles.Default.Font = FontText
            col.HeaderStyles.Default.Alignment = Style.Alignment.MiddleCenter
            col.CellStyles.Default.Alignment = Style.Alignment.MiddleRight
            col.Visible = False
            col.ReadOnly = True
            .Add(col)
        End With
        '13
        With DgdMortuoria.PrimaryGrid.Columns
            col = New GridColumn("uact")
            col.HeaderText = ""
            col.HeaderStyles.Default.Font = FontHeader
            col.Width = 0
            col.CellStyles.Default.Font = FontText
            col.HeaderStyles.Default.Alignment = Style.Alignment.MiddleCenter
            col.CellStyles.Default.Alignment = Style.Alignment.MiddleRight
            col.Visible = False
            col.ReadOnly = True
            .Add(col)
        End With

        'Datos para el segundo año
        '1
        With DgdMortuoria.PrimaryGrid.Columns
            col = New GridColumn("numi2")
            col.HeaderText = ""
            col.HeaderStyles.Default.Font = FontHeader
            col.Width = 0
            col.CellStyles.Default.Font = FontText
            col.HeaderStyles.Default.Alignment = Style.Alignment.MiddleCenter
            col.CellStyles.Default.Alignment = Style.Alignment.MiddleRight
            col.Visible = False
            col.ReadOnly = True
            .Add(col)
        End With
        '2
        With DgdMortuoria.PrimaryGrid.Columns
            col = New GridColumn("gestion2")
            col.HeaderText = "Pago Mortuoria"
            col.HeaderStyles.Default.Font = FontHeader
            col.Width = 130
            col.CellStyles.Default.Font = FontText
            col.HeaderStyles.Default.Alignment = Style.Alignment.MiddleCenter
            col.CellStyles.Default.Alignment = Style.Alignment.MiddleCenter
            col.Visible = True
            col.ReadOnly = True
            .Add(col)
        End With
        '3
        With DgdMortuoria.PrimaryGrid.Columns
            col = New GridColumn("fdoc2")
            col.HeaderText = "Fecha"
            col.HeaderStyles.Default.Font = FontHeader
            col.Width = 80
            col.CellStyles.Default.Font = FontText
            col.HeaderStyles.Default.Alignment = Style.Alignment.MiddleCenter
            col.CellStyles.Default.Alignment = Style.Alignment.MiddleRight
            col.Visible = True
            col.ReadOnly = True
            col.EditorType = GetType(GridDateTimePickerEditControl)
            .Add(col)
        End With
        '4
        With DgdMortuoria.PrimaryGrid.Columns
            col = New GridColumn("rec2")
            col.HeaderText = "Recibo"
            col.HeaderStyles.Default.Font = FontHeader
            col.Width = 60
            col.CellStyles.Default.Font = FontText
            col.HeaderStyles.Default.Alignment = Style.Alignment.MiddleCenter
            col.CellStyles.Default.Alignment = Style.Alignment.MiddleRight
            col.Visible = True
            col.ReadOnly = True
            .Add(col)
        End With
        '5
        With DgdMortuoria.PrimaryGrid.Columns
            col = New GridColumn("monto2")
            col.HeaderText = "Importe"
            col.HeaderStyles.Default.Font = FontHeader
            col.Width = 60
            col.CellStyles.Default.Font = FontText
            col.HeaderStyles.Default.Alignment = Style.Alignment.MiddleCenter
            col.CellStyles.Default.Alignment = Style.Alignment.MiddleRight
            col.Visible = True
            col.ReadOnly = True
            .Add(col)
        End With
        '6
        With DgdMortuoria.PrimaryGrid.Columns
            col = New GridColumn("check12")
            col.HeaderText = ""
            col.HeaderStyles.Default.Font = FontHeader
            col.Width = 30
            col.CellStyles.Default.Font = FontText
            col.HeaderStyles.Default.Alignment = Style.Alignment.MiddleCenter
            col.CellStyles.Default.Alignment = Style.Alignment.MiddleCenter
            col.Visible = True
            col.ReadOnly = False
            col.EditorType = GetType(GridCheckBoxEditControl)
            .Add(col)
        End With
        '7
        With DgdMortuoria.PrimaryGrid.Columns
            col = New GridColumn("est2")
            col.HeaderText = ""
            col.HeaderStyles.Default.Font = FontHeader
            col.Width = 30
            col.CellStyles.Default.Font = FontText
            col.HeaderStyles.Default.Alignment = Style.Alignment.MiddleCenter
            col.CellStyles.Default.Alignment = Style.Alignment.MiddleCenter
            col.Visible = False
            col.ReadOnly = True
            .Add(col)
        End With
        '8
        With DgdMortuoria.PrimaryGrid.Columns
            col = New GridColumn("saldo2")
            col.HeaderText = "Saldo"
            col.HeaderStyles.Default.Font = FontHeader
            col.Width = 60
            col.CellStyles.Default.Font = FontText
            col.HeaderStyles.Default.Alignment = Style.Alignment.MiddleCenter
            col.CellStyles.Default.Alignment = Style.Alignment.MiddleRight
            col.Visible = True
            col.ReadOnly = True
            .Add(col)
        End With
        '9
        With DgdMortuoria.PrimaryGrid.Columns
            col = New GridColumn("lin2")
            col.HeaderText = ""
            col.HeaderStyles.Default.Font = FontHeader
            col.Width = 0
            col.CellStyles.Default.Font = FontText
            col.HeaderStyles.Default.Alignment = Style.Alignment.MiddleCenter
            col.CellStyles.Default.Alignment = Style.Alignment.BottomRight
            col.Visible = False
            col.ReadOnly = False
            .Add(col)
        End With
        '10
        With DgdMortuoria.PrimaryGrid.Columns
            col = New GridColumn("estado2")
            col.HeaderText = ""
            col.HeaderStyles.Default.Font = FontHeader
            col.Width = 0
            col.CellStyles.Default.Font = FontText
            col.HeaderStyles.Default.Alignment = Style.Alignment.MiddleCenter
            col.CellStyles.Default.Alignment = Style.Alignment.MiddleRight
            col.Visible = False
            col.ReadOnly = True
            .Add(col)
        End With
        '11
        With DgdMortuoria.PrimaryGrid.Columns
            col = New GridColumn("fact2")
            col.HeaderText = ""
            col.HeaderStyles.Default.Font = FontHeader
            col.Width = 0
            col.CellStyles.Default.Font = FontText
            col.HeaderStyles.Default.Alignment = Style.Alignment.MiddleCenter
            col.CellStyles.Default.Alignment = Style.Alignment.MiddleRight
            col.Visible = False
            col.ReadOnly = True
            .Add(col)
        End With
        '12
        With DgdMortuoria.PrimaryGrid.Columns
            col = New GridColumn("hact2")
            col.HeaderText = ""
            col.HeaderStyles.Default.Font = FontHeader
            col.Width = 0
            col.CellStyles.Default.Font = FontText
            col.HeaderStyles.Default.Alignment = Style.Alignment.MiddleCenter
            col.CellStyles.Default.Alignment = Style.Alignment.MiddleRight
            col.Visible = False
            col.ReadOnly = True
            .Add(col)
        End With
        '13
        With DgdMortuoria.PrimaryGrid.Columns
            col = New GridColumn("uact2")
            col.HeaderText = ""
            col.HeaderStyles.Default.Font = FontHeader
            col.Width = 0
            col.CellStyles.Default.Font = FontText
            col.HeaderStyles.Default.Alignment = Style.Alignment.MiddleCenter
            col.CellStyles.Default.Alignment = Style.Alignment.MiddleRight
            col.Visible = False
            col.ReadOnly = True
            .Add(col)
        End With

        With DgdMortuoria.PrimaryGrid
            .ColumnHeader.RowHeight = 25
            .ShowRowHeaders = False
            .UseAlternateRowStyle = True
            .AllowRowHeaderResize = False
            .AllowRowResize = False
            .DefaultRowHeight = 35
            .SelectionGranularity = SelectionGranularity.Cell
        End With

        DgdMortuoria.PrimaryGrid.DataSource = DtMortuoria
        P_LlenarDatosGrillaMortuoria()
    End Sub

    Private Sub P_LlenarDatosGrillaPagos()
        DgdPagos.PrimaryGrid.Rows.Clear()
        'DgdPagos.PrimaryGrid.DataSource = Nothing

        Dim fild As GridRow
        Dim celd As GridCell
        For Each f As DataRow In DtDetalle.Rows
            fild = New GridRow


            celd = New GridCell
            celd.Value = f.Item("senumi")
            fild.Cells.Add(celd)

            celd = New GridCell
            celd.Value = f.Item("semes")
            fild.Cells.Add(celd)

            celd = New GridCell
            celd.Value = f.Item("senmes")
            fild.Cells.Add(celd)

            celd = New GridCell
            celd.Value = f.Item("seano")
            fild.Cells.Add(celd)

            celd = New GridCell
            celd.Value = f.Item("sefec")
            fild.Cells.Add(celd)

            celd = New GridCell
            celd.Value = f.Item("serec")
            fild.Cells.Add(celd)

            celd = New GridCell
            celd.Value = f.Item("seimp1")
            fild.Cells.Add(celd)

            celd = New GridCell
            celd.Value = f.Item("check1")
            fild.Cells.Add(celd)

            celd = New GridCell
            celd.Value = f.Item("sesaldo")
            fild.Cells.Add(celd)

            celd = New GridCell
            celd.Value = f.Item("saldoBD")
            fild.Cells.Add(celd)

            celd = New GridCell
            celd.Value = f.Item("seest")
            fild.Cells.Add(celd)

            celd = New GridCell
            celd.Value = f.Item("selin")
            fild.Cells.Add(celd)

            celd = New GridCell
            celd.Value = f.Item("estado")
            fild.Cells.Add(celd)

            celd = New GridCell
            celd.Value = f.Item("sefact")
            fild.Cells.Add(celd)

            celd = New GridCell
            celd.Value = f.Item("sehact")
            fild.Cells.Add(celd)

            celd = New GridCell
            celd.Value = f.Item("seuact")
            fild.Cells.Add(celd)



            celd = New GridCell
            celd.Value = f.Item("senumi2")
            fild.Cells.Add(celd)

            celd = New GridCell
            celd.Value = f.Item("semes2")
            fild.Cells.Add(celd)

            celd = New GridCell
            celd.Value = f.Item("senmes2")
            fild.Cells.Add(celd)

            celd = New GridCell
            celd.Value = f.Item("seano2")
            fild.Cells.Add(celd)

            celd = New GridCell
            celd.Value = f.Item("sefec2")
            fild.Cells.Add(celd)

            celd = New GridCell
            celd.Value = f.Item("serec2")
            fild.Cells.Add(celd)

            celd = New GridCell
            celd.Value = f.Item("seimp12")
            fild.Cells.Add(celd)

            celd = New GridCell
            celd.Value = f.Item("check2")
            fild.Cells.Add(celd)

            celd = New GridCell
            celd.Value = f.Item("sesaldo2")
            fild.Cells.Add(celd)

            celd = New GridCell
            celd.Value = f.Item("saldoBD2")
            fild.Cells.Add(celd)

            celd = New GridCell
            celd.Value = f.Item("seest2")
            fild.Cells.Add(celd)

            celd = New GridCell
            celd.Value = f.Item("selin2")
            fild.Cells.Add(celd)

            celd = New GridCell
            celd.Value = f.Item("estado2")
            fild.Cells.Add(celd)

            celd = New GridCell
            celd.Value = f.Item("sefact2")
            fild.Cells.Add(celd)

            celd = New GridCell
            celd.Value = f.Item("sehact2")
            fild.Cells.Add(celd)

            celd = New GridCell
            celd.Value = f.Item("seuact2")
            fild.Cells.Add(celd)

            DgdPagos.PrimaryGrid.Rows.Add(fild)
        Next
        DgdPagos.Refresh()
    End Sub

    Private Sub P_LlenarDatosGrillaMortuoria()
        DgdMortuoria.PrimaryGrid.Rows.Clear()
        'DgdPagos.PrimaryGrid.DataSource = Nothing

        Dim fild As GridRow
        Dim celd As GridCell
        For Each f As DataRow In DtMortuoria.Rows
            fild = New GridRow


            celd = New GridCell
            celd.Value = f.Item("numi")
            fild.Cells.Add(celd)

            celd = New GridCell
            celd.Value = f.Item("gestion")
            fild.Cells.Add(celd)

            celd = New GridCell
            celd.Value = f.Item("fdoc")
            fild.Cells.Add(celd)

            celd = New GridCell
            celd.Value = f.Item("rec")
            celd.ReadOnly = True
            fild.Cells.Add(celd)

            celd = New GridCell
            celd.Value = f.Item("monto")
            fild.Cells.Add(celd)

            celd = New GridCell
            celd.Value = f.Item("check11")
            fild.Cells.Add(celd)

            celd = New GridCell
            celd.Value = f.Item("est")
            fild.Cells.Add(celd)

            celd = New GridCell
            celd.Value = f.Item("saldo")
            fild.Cells.Add(celd)

            celd = New GridCell
            celd.Value = f.Item("lin")
            fild.Cells.Add(celd)

            celd = New GridCell
            celd.Value = f.Item("estado")
            fild.Cells.Add(celd)

            celd = New GridCell
            celd.Value = f.Item("fact")
            fild.Cells.Add(celd)

            celd = New GridCell
            celd.Value = f.Item("hact")
            fild.Cells.Add(celd)

            celd = New GridCell
            celd.Value = f.Item("uact")
            fild.Cells.Add(celd)



            celd = New GridCell
            celd.Value = f.Item("numi2")
            fild.Cells.Add(celd)

            celd = New GridCell
            celd.Value = f.Item("gestion2")
            fild.Cells.Add(celd)

            celd = New GridCell
            celd.Value = f.Item("fdoc2")
            fild.Cells.Add(celd)

            celd = New GridCell
            celd.Value = f.Item("rec2")
            celd.ReadOnly = True
            fild.Cells.Add(celd)

            celd = New GridCell
            celd.Value = f.Item("monto2")
            fild.Cells.Add(celd)

            celd = New GridCell
            celd.Value = f.Item("check12")
            fild.Cells.Add(celd)

            celd = New GridCell
            celd.Value = f.Item("est2")
            fild.Cells.Add(celd)

            celd = New GridCell
            celd.Value = f.Item("saldo2")
            fild.Cells.Add(celd)

            celd = New GridCell
            celd.Value = f.Item("lin2")
            fild.Cells.Add(celd)

            celd = New GridCell
            celd.Value = f.Item("estado2")
            fild.Cells.Add(celd)

            celd = New GridCell
            celd.Value = f.Item("fact2")
            fild.Cells.Add(celd)

            celd = New GridCell
            celd.Value = f.Item("hact2")
            fild.Cells.Add(celd)

            celd = New GridCell
            celd.Value = f.Item("uact2")
            fild.Cells.Add(celd)

            DgdMortuoria.PrimaryGrid.Rows.Add(fild)
        Next
        DgdMortuoria.Refresh()
    End Sub

    Private Sub DgdMortuoria_CellValidating(sender As Object, e As GridCellValidatingEventArgs) Handles DgdMortuoria.CellValidating
        If (e.GridCell.ColumnIndex = DgdMortuoria.PrimaryGrid.Columns("rec").ColumnIndex Or
            e.GridCell.ColumnIndex = DgdMortuoria.PrimaryGrid.Columns("rec2").ColumnIndex) Then
            If (Not IsNumeric(e.Value)) Then
                e.Value = 0
                Exit Sub
            Else
                If (Not e.Value <= 2147483647) Then
                    e.Value = 2147483647
                    ToastNotification.Show(Me, "el número de recibo soporta hasta 2147483647".ToUpper & ChrW(13) _
                                           & "el numero de recibo es mayor al limite.".ToUpper,
                       My.Resources.WARNING,
                       Duracion * 1000,
                       eToastGlowColor.Red,
                       eToastPosition.TopCenter)
                End If
            End If
        End If
    End Sub

    Private Sub DgdMortuoria_CellValueChanged(sender As Object, e As GridCellValueChangedEventArgs) Handles DgdMortuoria.CellValueChanged
        If (e.GridCell.ColumnIndex = DgdMortuoria.PrimaryGrid.Columns("check11").ColumnIndex Or
            e.GridCell.ColumnIndex = DgdMortuoria.PrimaryGrid.Columns("check12").ColumnIndex) Then
            Dim ifil As Integer = e.GridCell.RowIndex
            Dim icol As Integer = e.GridCell.ColumnIndex

            Dim fecha As GridCell = DgdMortuoria.PrimaryGrid.GetCell(ifil, icol - 3)
            Dim recibo As GridCell = DgdMortuoria.PrimaryGrid.GetCell(ifil, icol - 2)
            Dim monto As GridCell = DgdMortuoria.PrimaryGrid.GetCell(ifil, icol - 1)
            Dim check As GridCell = DgdMortuoria.PrimaryGrid.GetCell(ifil, icol)
            Dim saldo As GridCell = DgdMortuoria.PrimaryGrid.GetCell(ifil, icol + 2)

            Dim estado1 As GridCell = DgdMortuoria.PrimaryGrid.GetCell(ifil, 9)
            Dim estado2 As GridCell = DgdMortuoria.PrimaryGrid.GetCell(ifil, 22)
            Dim est1 As GridCell = DgdMortuoria.PrimaryGrid.GetCell(ifil, 6)
            Dim est2 As GridCell = DgdMortuoria.PrimaryGrid.GetCell(ifil, 19)

            Dim MontoRecibido As Double = Tbd1Monto.Value

            If (Nuevo) Then
                If (e.NewValue = True) Then
                    If (chPagoAnho.Checked) Then
                        If (Tbd1Monto.Value = deCuotaSocioAnual * 12) Then
                            bandera = True
                            Tbd1Monto.Value += monto.Value
                            bandera = False
                            Tb4Cambio.Text = (CDbl(Tb4Cambio.Text)) + monto.Value
                        Else
                            If (Tbd1Monto.Value = ((deCuotaSocioAnual * 12) + monto.Value)) Then
                                bandera = True
                                Tbd1Monto.Value += monto.Value
                                bandera = False
                                Tb4Cambio.Text = (CDbl(Tb4Cambio.Text)) + monto.Value
                            End If
                        End If

                        fecha.Value = Dt2FechaPago.Value
                            recibo.Value = IIf(Tb3NroRecibo.Text = String.Empty, 0, Tb3NroRecibo.Text)
                            saldo.Value = 0
                            Tb4Cambio.Text = (CDbl(Tb4Cambio.Text) - monto.Value).ToString
                            'recibo.ReadOnly = False
                            If (e.GridCell.ColumnIndex < 12) Then
                                estado1.Value = 2
                                est1.Value = IIf(saldo.Value = 0, 2, 1)
                            Else
                                estado2.Value = 2
                                est2.Value = IIf(saldo.Value = 0, 2, 1)
                            End If

                        Else

                            If (CDbl(Tb4Cambio.Text) >= monto.Value) Then
                            fecha.Value = Dt2FechaPago.Value
                            recibo.Value = IIf(Tb3NroRecibo.Text = String.Empty, 0, Tb3NroRecibo.Text)
                            saldo.Value = 0
                            Tb4Cambio.Text = (CDbl(Tb4Cambio.Text) - monto.Value).ToString
                            'recibo.ReadOnly = False
                            If (e.GridCell.ColumnIndex < 12) Then
                                estado1.Value = 2
                                est1.Value = IIf(saldo.Value = 0, 2, 1)
                            Else
                                estado2.Value = 2
                                est2.Value = IIf(saldo.Value = 0, 2, 1)
                            End If

                        Else
                            ToastNotification.Show(Me, "El cambio del monto recibido insuficiente para cubrir la cuota mortuoria".ToUpper,
                                               My.Resources.INFORMATION, Duracion * 500,
                                               eToastGlowColor.Red,
                                               eToastPosition.TopCenter)
                            e.GridCell.Value = False
                        End If
                    End If
                ElseIf (e.NewValue = False) Then

                    fecha.Value = DgdMortuoria.PrimaryGrid.GetCell(ifil, 14).Value.ToString + "/01/01"
                    recibo.Value = 0
                    saldo.Value = monto.Value
                    Tb4Cambio.Text = MontoRecibido - P_SumarPagosCuotas(Dt2FechaPago.Value, 2) - P_SumarPagosMortuoria(2)
                    'recibo.ReadOnly = True
                    If (e.GridCell.ColumnIndex < 12) Then
                        estado1.Value = 1
                        est1.Value = IIf(saldo.Value = 0, 2, 1)
                    Else
                        estado2.Value = 1
                        est2.Value = IIf(saldo.Value = 0, 2, 1)
                    End If
                End If
            End If
            If (Modificar) Then
                If (e.NewValue = True) Then
                    If (CDbl(Tb4Cambio.Text) >= monto.Value) Then
                        fecha.Value = Dt2FechaPago.Value
                        recibo.Value = Tb3NroRecibo.Text
                        saldo.Value = 0
                        Tb4Cambio.Text = (CDbl(Tb4Cambio.Text) - monto.Value).ToString
                        'recibo.ReadOnly = False
                        If (e.GridCell.ColumnIndex < 12) Then
                            estado1.Value = 2
                            est1.Value = IIf(saldo.Value = 0, 2, 1)
                        Else
                            estado2.Value = 2
                            est2.Value = IIf(saldo.Value = 0, 2, 1)
                        End If
                    Else
                        ToastNotification.Show(Me, "El cambio del monto recibido insuficiente para cubrir la cuota mortuoria".ToUpper,
                                               My.Resources.INFORMATION, Duracion * 500,
                                               eToastGlowColor.Red,
                                               eToastPosition.TopCenter)
                        e.GridCell.Value = False
                    End If
                ElseIf (e.NewValue = False) Then
                    fecha.Value = DgdMortuoria.PrimaryGrid.GetCell(ifil, 14).Value.ToString + "/01/01"
                    recibo.Value = 0
                    saldo.Value = monto.Value
                    Tb4Cambio.Text = MontoRecibido - P_SumarTodo()
                    'recibo.ReadOnly = True
                    If (e.GridCell.ColumnIndex < 12) Then
                        estado1.Value = 2
                        est1.Value = IIf(saldo.Value = 0, 2, 1)
                    Else
                        estado2.Value = 2
                        est2.Value = IIf(saldo.Value = 0, 2, 1)
                    End If
                End If
            End If
        End If
    End Sub
    Dim vamortuoria As Byte = 0 'Variable de ayuda para que no entre dos veces al switch false de la grilla de la caja mortuoria
    Dim vapagos As Byte = 0 'Variable de ayuda para que no entre dos veces al switch false de la grilla de la caja mortuoria, enviado desde el switch true
    Private Sub TbiNroSocio_KeyDown(sender As Object, e As KeyEventArgs) Handles TbiNroSocio.KeyDown
        If (Nuevo Or Modificar) Then
            If (e.KeyData = Keys.Enter) Then
                If (TbiNroSocio.Value > 0) Then
                    Dim array As DataRow() = DtCabecera.Select("cfnsoc=" + TbiNroSocio.Value.ToString)
                    If (array.Length = 1) Then
                        Numi = array(0).Item("cfnumi").ToString
                        P_prPonerDatosSocio(array(0).Item("cfnumi"), array(0).Item("cfnsoc"),
                                            array(0).Item("cfnom") + " " + array(0).Item("cfapat") + " " + array(0).Item("cfamat"),
                                            array(0).Item("cffing"), array(0).Item("cfmor"), array(0).Item("cftsoc"), array(0).Item("tsocio"))
                    Else
                        ToastNotification.Show(Me, "el número de socio: ".ToUpper + TbiNroSocio.Value.ToString + ", no existe".ToUpper,
                                           My.Resources.WARNING, Duracion * 1000,
                                           eToastGlowColor.Red,
                                           eToastPosition.TopCenter)
                    End If
                Else
                    ToastNotification.Show(Me, "ponga un número de socio mayor a cero(0)".ToUpper,
                                           My.Resources.WARNING, Duracion * 1000,
                                           eToastGlowColor.Red,
                                           eToastPosition.TopCenter)
                End If


            End If
        End If
    End Sub

    Private Sub P_prPonerDatosSocio(numi As String, nroSocio As String, nomSocio As String, fingSocio As String,
                                    mortuoria As String, codTipoSocio As String, tipoSocio As String)
        TbiNroSocio.Value = nroSocio
        Tb2NombreSocio.Text = nomSocio
        Dt1FechaIngreso.Value = fingSocio
        BoMortuaria = mortuoria.Equals("1")
        rlMortuoria.Text = "Cuota Mortuoria : " + IIf(BoMortuaria, "SI", "NO")
        rlTipoSocio.Text = "Tipo de Socio : " + tipoSocio
        boEsAusente = codTipoSocio.Equals("4")

        chPagoAnho.Enabled = Not codTipoSocio.Equals("4")

        'Poner Telefonos
        P_prArmarGrillaTelefono(numi)

        GroupPanelDatosPago.Select()
    End Sub

    Private Sub TbiNroSocio_Leave(sender As Object, e As EventArgs) Handles TbiNroSocio.Leave
        If (Nuevo Or Modificar) Then
            If (TbiNroSocio.Value > 0) Then
                Dim array As DataRow() = DtCabecera.Select("cfnsoc=" + TbiNroSocio.Value.ToString)
                If (array.Count = 1) Then
                    P_Generar(1)
                Else
                    ToastNotification.Show(Me, "el número de socio: ".ToUpper + TbiNroSocio.Value.ToString + ", no existe".ToUpper,
                                       My.Resources.WARNING, Duracion * 1000,
                                       eToastGlowColor.Red,
                                       eToastPosition.TopCenter)
                End If
            End If
        End If
    End Sub

    Private Function P_prPonerPagosNoCorresponde(ByRef Dt1 As DataTable, colest As String) As Boolean
        Dim res As Boolean = False
        Dim dt As DataTable = L_fnSocioObtenerPagosNoCorresponde(DtCabecera.Select("cfnsoc=" + TbiNroSocio.Value.ToString)(0).Item("cfnumi").ToString)
        If (dt.Rows.Count = 0) Then
            If (P_fnSiPagoCuotaSocio()) Then
                For Each fil As DataRow In Dt1.Rows
                    If (fil.Item(colest) = 1) Then
                        fil.Item(colest) = 0
                    End If
                    If (fil.Item(colest) = 2) Then
                        res = True
                        Exit For
                    End If
                Next
            Else
                For Each fil As DataRow In Dt1.Rows
                    fil.Item(colest) = -2
                Next
            End If
        End If
        Return res
    End Function

    Private Function P_prPonerPagosMortuoriaNoCorresponde(ByRef Dt1 As DataTable, colest As String) As Boolean
        Dim res As Boolean = False
        Dim dt As DataTable = L_fnSocioObtenerPagosMortuoriaNoCorresponde(DtCabecera.Select("cfnsoc=" + TbiNroSocio.Value.ToString)(0).Item("cfnumi").ToString)
        If (dt.Rows.Count = 0) Then
            If (P_fnSiPagoCuotaMortuoria()) Then
                For Each fil As DataRow In Dt1.Rows
                    If (fil.Item(colest) = 1) Then
                        fil.Item(colest) = 0
                    End If
                    If (fil.Item(colest) = 2) Then
                        res = True
                        Exit For
                    End If
                Next
            Else
                For Each fil As DataRow In Dt1.Rows
                    fil.Item(colest) = -2
                Next
            End If
            
        End If
        Return res
    End Function

    Private Sub P_prArmarDtPrecioCuota()
        If (Not chPagoAnho.Checked And Not boEsAusente) Then 'Normal
            DtPrecio = L_prServicioDetallePrecioCuotaSocio(gi_LibSERVTipoCuotaSocio.ToString, "1")
        ElseIf (chPagoAnho.Checked And Not boEsAusente) Then 'Pago de un año completo
            DtPrecio = L_prServicioDetallePrecioCuotaSocio(gi_LibSERVTipoCuotaSocio.ToString, "3")
        ElseIf (Not chPagoAnho.Checked And boEsAusente) Then 'Pago de un socio Ausente
            DtPrecio = L_prServicioDetallePrecioCuotaSocio(gi_LibSERVTipoCuotaSocio.ToString, "4")
        Else
            Exit Sub
        End If

        'Si el precio del servico esta desde 2017, poner un registro desde el 2016
        Dim dtAnhoInicio As DataTable = L_fnObtenerTabla("min(seano) as anho", "TCS014", "1=1")
        Dim anoInicio As Integer = Now.Year - 1
        If (dtAnhoInicio.Rows.Count > 0) Then
            anoInicio = dtAnhoInicio.Rows(0).Item("anho")
        End If

        Dim arrayAP As DataRow() = DtPrecio.Select("eeano=" + anoInicio.ToString)

        If (arrayAP.Length = 0) Then
            Dim f As DataRow = DtPrecio.NewRow
            f.Item(0) = 0
            f.Item(1) = 0
            f.Item(2) = anoInicio
            f.Item(3) = 0
            f.Item(4) = 0
            DtPrecio.Rows.InsertAt(f, 0)
        End If

        Dim Dt1 As DataTable = DtPrecio.Clone
        Dim Dt2 As DataTable = DtPrecio.DefaultView.ToTable(True, "eeano")

        'b.eelinea, b.eenumi, b.eeano, b.eemes, b.eeprecio
        For Each fil As DataRow In Dt2.Rows
            For i As Integer = 1 To 12
                Dt1.Rows.Add({Dt1.Rows.Count + 1, 0, fil.Item("eeano"), i, 0})
            Next
        Next

        For Each fil As DataRow In DtPrecio.Rows
            For Each fil2 As DataRow In Dt1.Rows
                If (fil.Item("eeano") = fil2.Item("eeano") And fil2.Item("eemes") >= fil.Item("eemes")) Then
                    fil2.Item("eeprecio") = fil.Item("eeprecio")
                End If
            Next
        Next

        Dim uano As Integer = Dt1.Rows(Dt1.Rows.Count - 1).Item("eeano")
        While (uano <> tbiGestion.Value And uano <= tbiGestion.Value)
            For i As Integer = 1 To 12
                Dt1.Rows.Add({Dt1.Rows.Count + 1, 0, uano + 1, i, DtPrecio.Rows(DtPrecio.Rows.Count - 1).Item("eeprecio")})
            Next
            uano += 1
        End While

        DtPrecio = Dt1
    End Sub

    Private Sub P_prArmarDtPrecioMortuoria()
        DtPrecioMortuoria = L_prServicioDetallePrecioCuotaSocio(gi_LibSERVTipoCuotaSocio.ToString, "2")

        'Si el precio del servico esta desde 2017, poner un registro desde el 2016
        Dim dtAnhoInicio As DataTable = L_fnObtenerTabla("min(sfgestion) as anho", "TCS015", "1=1")
        Dim anoInicio As Integer = Now.Year - 1
        If (dtAnhoInicio.Rows.Count > 0) Then
            anoInicio = dtAnhoInicio.Rows(0).Item("anho")
        End If
        Dim arrayAP As DataRow() = DtPrecioMortuoria.Select("eeano=" + anoInicio.ToString)

        If (arrayAP.Length = 0) Then
            Dim f As DataRow = DtPrecioMortuoria.NewRow
            f.Item(0) = 0
            f.Item(1) = 0
            f.Item(2) = anoInicio
            f.Item(3) = 0
            f.Item(4) = 0
            DtPrecioMortuoria.Rows.InsertAt(f, 0)
        End If

        Dim uano As Integer = DtPrecioMortuoria.Rows(DtPrecioMortuoria.Rows.Count - 1).Item("eeano")
        While (uano <> tbiGestion.Value And uano <= tbiGestion.Value)
            DtPrecioMortuoria.Rows.Add({DtPrecioMortuoria.Rows.Count + 1, 0, uano + 1, 1, DtPrecioMortuoria.Rows(DtPrecioMortuoria.Rows.Count - 1).Item("eeprecio")})
            uano += 1
        End While
    End Sub

    Private Function P_fnSiPagoCuotaSocio() As Boolean
        Dim res As Boolean = False
        Dim dt As DataTable = CType(DgdPagos.PrimaryGrid.DataSource, DataTable)
        For Each fil As DataRow In dt.Rows
            If (fil.Item("seest") = 2) Then
                res = True
                Exit For
            End If
            If (fil.Item("seest2") = 2) Then
                res = True
                Exit For
            End If
        Next
        Return res
    End Function

    Private Function P_fnSiPagoCuotaMortuoria() As Boolean
        Dim res As Boolean = False
        Dim dt As DataTable = CType(DgdMortuoria.PrimaryGrid.DataSource, DataTable)
        For Each fil As DataRow In dt.Rows
            If (fil.Item("est") = 2) Then
                res = True
                Exit For
            End If
            If (fil.Item("est2") = 2) Then
                res = True
                Exit For
            End If
        Next
        Return res
    End Function

    Private Sub P_prArmarGrillaTelefono(numi As String)
        Dim dt As DataTable
        dt = L_fnSocioDetalle1(numi)

        dgjTelefono.BoundMode = BoundMode.Bound
        dgjTelefono.DataSource = dt
        dgjTelefono.RetrieveStructure()

        With dgjTelefono.RootTable.Columns("cgnumi")
            .Visible = False
        End With

        With dgjTelefono.RootTable.Columns("cgttip")
            .Visible = False
        End With

        With dgjTelefono.RootTable.Columns("cedesc1")
            .Caption = "Tipo"
            .Width = 120
            .HeaderStyle.Font = FontHeader
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FontText
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = True
            '.CellStyle.BackColor = Color.AliceBlue
        End With

        With dgjTelefono.RootTable.Columns("cgdesc")
            .Caption = "Número"
            .Width = 150
            .HeaderStyle.Font = FontHeader
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = FontText
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = True
            '.CellStyle.BackColor = Color.AliceBlue
        End With

        With dgjTelefono.RootTable.Columns("cglin")
            .Visible = False
        End With

        With dgjTelefono.RootTable.Columns("estado")
            .Visible = False
        End With

        With dgjTelefono
            .GroupByBoxVisible = False
            '.FilterRowFormatStyle.BackColor = Color.Blue
            .DefaultFilterRowComparison = FilterConditionOperator.Contains
            '.FilterMode = FilterMode.Automatic
            .FilterRowUpdateMode = FilterRowUpdateMode.WhenValueChanges
            'Diseño de la tabla
            .VisualStyle = VisualStyle.Office2007
            .SelectionMode = SelectionMode.MultipleSelection
            .AlternatingColors = True
            .RecordNavigator = True
            .RowHeaders = InheritableBoolean.True
        End With

    End Sub

    Private Sub chPagoAnho_CheckedChanged(sender As Object, e As EventArgs) Handles chPagoAnho.CheckedChanged
        If (chPagoAnho.Checked) Then
            Tbd1Monto.IsInputReadOnly = True
            Tbd1Monto.Value = deCuotaSocioAnual * 12
        Else
            Tbd1Monto.IsInputReadOnly = False
            Tbd1Monto.Value = 0
        End If
    End Sub

End Class