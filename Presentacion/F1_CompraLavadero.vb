Imports Logica.AccesoLogica
Imports Janus.Windows.GridEX
Imports DevComponents.DotNetBar
Imports System.IO
Imports DevComponents.DotNetBar.SuperGrid


Public Class F1_CompraLavadero

#Region "Variables Globales"
    Dim RutaGlobal As String = gs_CarpetaRaiz
    Public _nameButton As String
#End Region



#Region "METODOS PRIVADOS"
    Private Sub _prIniciarTodo()
        'L_prAbrirConexion(gs_Ip, gs_UsuarioSql, gs_ClaveSql, gs_NombreBD)
        Me.Text = "C O M P R A    D E    P R O D U C T O S"
        _PMIniciarTodo()
        _prAsignarPermisos()
        GroupPanelBuscador.Style.BackColor = Color.FromArgb(13, 71, 161)
        GroupPanelBuscador.Style.BackColor2 = Color.FromArgb(13, 71, 161)
        GroupPanelBuscador.Style.TextColor = Color.White
        Dim blah As Bitmap = My.Resources.venta
        Dim ico As Icon = Icon.FromHandle(blah.GetHicon())
        Me.Icon = ico
        JGrM_Buscador.RootTable.HeaderFormatStyle.FontBold = TriState.True
        _prCargarStyle()
        tbObs.MaxLength = 100
    End Sub
   
    Private Sub _prCargarGridDetalle(_fnumi As Integer)
        Dim dt As New DataTable
        dt = L_prCompraLavaderoDetalle(_fnumi)

        ''''janosssssssss''''''
        grDetalle.DataSource = dt
        grDetalle.RetrieveStructure()
        grDetalle.AlternatingColors = True
        grDetalle.RowFormatStyle.Font = New Font("arial", 10)

        'dar formato a las columnas

        '  a.lgnumi ,a.lgtcl3cpro,b.ldcdprod1 as descripcion  ,a.lgcant ,a.lgpc ,a.lgpv ,a.lglin,
        '1 as estado
        With grDetalle.RootTable.Columns("lgnumi")
            .Width = 80
            .TextAlignment = TextAlignment.Center
            .Caption = "CODIGO"
            .Visible = False
        End With
        With grDetalle.RootTable.Columns("lgtcl3cpro")
            .Width = 60
            .Visible = False
        End With
        With grDetalle.RootTable.Columns("descripcion")
            .Width = 350
            .Visible = True
            .Caption = "PRODUCTO"

        End With
        With grDetalle.RootTable.Columns("lgcant")
            .Width = 100
            .Caption = "CANTIDAD"
            .FormatString = "0.00"
            .Visible = True
        End With
        With grDetalle.RootTable.Columns("lgpc")
            .Width = 150
            .Visible = True
            .Caption = "PRECIO DE COMPRA"
            .FormatString = "0.00"

        End With
        With grDetalle.RootTable.Columns("lgpv")
            .Width = 150
            .Caption = "PRECIO DE VENTA"
            .Visible = True
            .FormatString = "0.00"
        End With
        With grDetalle.RootTable.Columns("lglin")
            .Caption = "CODIGO"
            .Width = 150
            .Visible = True
        End With
        With grDetalle.RootTable.Columns("lglin")
            .Caption = "CODIGO"
            .Width = 150
            .Visible = True
        End With
        With grDetalle.RootTable.Columns("lgstocka")
            .Caption = "STOCK ACTUAL"
            .Width = 150
            .FormatString = "0.00"
            .Visible = True
        End With
        With grDetalle.RootTable.Columns("lgstockf")
            .Caption = "STOCK PREVIO"
            .Width = 150
            .FormatString = "0.00"
            .Visible = True
        End With
        With grDetalle.RootTable.Columns("precioTotal")
            .Caption = "TOTAL"
            .Width = 150
            .Visible = True
            .FormatString = "0.00"
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

    Public Sub _prCargarStyle()
        GpDetalle.Style.BackColor = Color.FromArgb(13, 71, 161)
        GpDetalle.Style.BackColor2 = Color.FromArgb(13, 71, 161)
        GpDetalle.Style.TextColor = Color.White

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

    Public Function _fnValidarDatosDetalle()
        Dim row As Integer = CType(grDetalle.DataSource, DataTable).Rows.Count - 1
        If (grDetalle.RowCount <= 0) Then
            ToastNotification.Show(Me, "           Inserte un Producto Antes de Guardar  !!             ", My.Resources.WARNING, 8000, eToastGlowColor.Red, eToastPosition.TopCenter)
            Return False
        End If
        grDetalle.Row = grDetalle.RowCount - 1
        If (grDetalle.GetValue("lgtcl3cpro") <= 0) Then
            ToastNotification.Show(Me, "           Inserte un Producto Antes de Guardar  !!             ", My.Resources.WARNING, 8000, eToastGlowColor.Red, eToastPosition.TopCenter)
            Return False
        End If
        Return True
    End Function
    Public Sub _prVolverAtras()
        MPanelSup.Visible = True
        JGrM_Buscador.Visible = False
        GroupPanelBuscador.Visible = False
        MPanelSup.Dock = DockStyle.Top
        PanelSuperior.Visible = True
        ButtonX2.Visible = False
        ButtonX1.Visible = True
    End Sub
   
    Public Function _fnVisualizarRegistros() As Boolean
        Return tbFechaCompra.Enabled = False
    End Function

    Public Function _fnObtenerLinDetalle() As Integer
        Dim length As Integer = CType(grDetalle.DataSource, DataTable).Rows.Count
        Dim lin As Integer
        If (length > 0) Then
            lin = CType(grDetalle.DataSource, DataTable).Rows(length - 1).Item("lglin")
            Return lin

        Else
            Return 0
        End If

    End Function

    Public Sub _prAddFilaDetalle()
        '     a.lglin,a.lgnumi ,a.lgtcl3cpro,b.ldcdprod1 as descripcion  ,a.lgcant ,a.lgpc ,a.lgpv ,Cast(0 as decimal(18,2)) as precioTotal,
        '1 as estado
        Dim lin As Integer = _fnObtenerLinDetalle() + 1
        _prCalcularPrecioTotal()
        CType(grDetalle.DataSource, DataTable).Rows.Add({lin, 0, 0, "", 0, 0, 0, 0, 0, 0, 0})
    End Sub

    Public Function _fnValidarColumn(pos As Integer, row As Integer, _MostrarMensaje As Boolean) As Boolean
        If (CType(grDetalle.DataSource, DataTable).Rows(pos).Item("descripcion") = String.Empty) Then


            If (_MostrarMensaje = True) Then
                grDetalle.Row = row
                grDetalle.Col = 3
                grDetalle.FocusCellFormatStyle.BackColor = Color.Red
                ToastNotification.Show(Me, "           Seleccione un Producto !!             ", My.Resources.WARNING, 3000, eToastGlowColor.Red, eToastPosition.TopCenter)


            End If

            Return False
        End If

        If (grDetalle.GetValue("lgpv") <= 0) Then

            If (_MostrarMensaje = True) Then
                grDetalle.Row = row
                grDetalle.Col = 6
                grDetalle.FocusCellFormatStyle.BackColor = Color.Red
                ToastNotification.Show(Me, "             Inserte Un Precio de Compra Valido !!               ", My.Resources.WARNING, 3000, eToastGlowColor.Red, eToastPosition.TopCenter)
            End If

            Return False
        End If
        If (grDetalle.GetValue("lgpc") <= 0) Then

            If (_MostrarMensaje = True) Then
                grDetalle.Row = row
                grDetalle.Col = 5
                grDetalle.FocusCellFormatStyle.BackColor = Color.Red
                ToastNotification.Show(Me, "             Inserte Un Precio de Venta Valido !!               ", My.Resources.WARNING, 3000, eToastGlowColor.Red, eToastPosition.TopCenter)
            End If

            Return False
        End If
        Return True
    End Function

    Public Sub _prCalcularPrecioTotal()
        Dim length As Integer = CType(grDetalle.DataSource, DataTable).Rows.Count
        Dim sum As Double = 0
        For i As Integer = 0 To length - 1 Step 1

            If (CType(grDetalle.DataSource, DataTable).Rows(i).Item("estado") >= 0) Then
                sum = sum + Convert.ToDouble(CType(grDetalle.DataSource, DataTable).Rows(i).Item("precioTotal"))

            End If


        Next
        tbTotal.Text = sum

    End Sub

    Public Sub _prObtenerPosicionDetalle(ByRef pos As Integer, ByVal Lin As Integer)
        Dim length As Integer = CType(grDetalle.DataSource, DataTable).Rows.Count
        pos = -1
        For i As Integer = 0 To length Step 1
            Dim numi As Integer = CType(grDetalle.DataSource, DataTable).Rows(i).Item("lglin")
            If (numi = Lin) Then
                pos = i
                Return

            End If

        Next

    End Sub



    Private Sub P_PonerTotal(rowIndex As Integer)
        grDetalle.Row = rowIndex
        Dim lin As Integer = grDetalle.GetValue("lglin")
        Dim pos As Integer = -1
        _prObtenerPosicionDetalle(pos, lin)
        Dim cant As Double = grDetalle.GetValue("lgcant")

        Dim uni As Double = grDetalle.GetValue("lgpc")
        If (pos >= 0) Then
            CType(grDetalle.DataSource, DataTable).Rows(pos).Item("precioTotal") = cant * uni

        End If
        _prCalcularPrecioTotal()


    End Sub


    Public Function _prBuscarExisteNumiServ(_numiServ As Integer) As Boolean
        Dim length As Integer = CType(grDetalle.DataSource, DataTable).Rows.Count
        For i As Integer = 0 To length - 1 Step 1
            Dim estado As Integer = CType(grDetalle.DataSource, DataTable).Rows(i).Item("estado")
            Dim numiproducto As Integer = CType(grDetalle.DataSource, DataTable).Rows(i).Item("lgtcl3cpro")
            If (estado <> -1 And numiproducto = _numiServ) Then
                Return True

            End If

        Next
        Return False
    End Function
  
#End Region

#Region "METODOS SOBREESCRITOS"



    Public Overrides Sub _PMOHabilitar()

        tbFechaCompra.Enabled = True
        tbObs.ReadOnly = False
      
        ButtonX1.Visible = False
        Eliminarms.Visible = True


    End Sub
    Public Overrides Sub _PMOInhabilitar()

        tbProveedor.ReadOnly = True
       
        tbFechaCompra.Enabled = False
        tbCodigo.Enabled = False
        tbObs.ReadOnly = True
       
        ButtonX1.Visible = True
       
        Eliminarms.Visible = False
        If (JGrM_Buscador.RowCount = 0) Then
            _PMOLimpiar()

        End If
        tbTotal.IsInputReadOnly = True

    End Sub
    Public Overrides Sub _PMOHabilitarFocus()
        With MHighlighterFocus
            .SetHighlightOnFocus(tbProveedor, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
            .SetHighlightOnFocus(tbFechaCompra, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
            .SetHighlightOnFocus(tbObs, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
        End With
    End Sub
    Public Overrides Sub _PMOLimpiar()
        tbProveedor.Text = ""
        tbnumiProveedor.Text = 0
        tbCodigo.Text = ""
        tbObs.Text = ""
        tbFechaCompra.Text = DateTime.Now.ToString("dd/MM/yyyy")
        tbObs.Focus()
        _prCargarGridDetalle(-1)
        _prAddFilaDetalle()
        tbTotal.Text = 0
        ButtonX1.Visible = False
        ButtonX2.Visible = False
    End Sub
    Public Overrides Sub _PMOLimpiarErrores()

        MEP.Clear()
        tbProveedor.BackColor = Color.White

    End Sub
    Public Overrides Function _PMOValidarCampos() As Boolean
        Dim _ok As Boolean = True
        MEP.Clear()

        'If tbProveedor.Text = String.Empty Then
        '    tbProveedor.BackColor = Color.Red
        '    MEP.SetError(tbProveedor, "Seleccione un Proveedor con Ctrl+Enter!".ToUpper)
        '    _ok = False
        'Else
        '    tbProveedor.BackColor = Color.White
        '    MEP.SetError(tbProveedor, "")
        'End If
       
        If (_fnValidarDatosDetalle() = False) Then
            _ok = False
        End If
        MHighlighterFocus.UpdateHighlights()
        Return _ok
    End Function
    Public Overrides Function _PMOGetListEstructuraBuscador() As List(Of Modelos.Celda)
        Dim listEstCeldas As New List(Of Modelos.Celda)

        ' a.lfnumi ,a.lffecha ,a.lfprov ,a.lfobs ,a.lffact ,a.lfhact ,a.lfuact 
        listEstCeldas.Add(New Modelos.Celda("lfnumi", True, "CODIGO COMPRA", 150))
        listEstCeldas.Add(New Modelos.Celda("lffecha", True, "FECHA DE COMPRA", 150))
        listEstCeldas.Add(New Modelos.Celda("lfprov", False))
        listEstCeldas.Add(New Modelos.Celda("proveedor", False, "PROVEEDOR", 150))
        listEstCeldas.Add(New Modelos.Celda("lfobs", True, "OBSERVACION", 400))
        listEstCeldas.Add(New Modelos.Celda("lffact", False))
        listEstCeldas.Add(New Modelos.Celda("lfhact", False))
        listEstCeldas.Add(New Modelos.Celda("lfuact", False))
        Return listEstCeldas


    End Function
    Public Overrides Function _PMOGetTablaBuscador() As DataTable
        Dim dtBuscador As DataTable = L_prCompraLavaderoGeneral()
        Return dtBuscador
    End Function


    Public Overrides Sub _PMOMostrarRegistro(_N As Integer)
        JGrM_Buscador.Row = _MPos

        With JGrM_Buscador
            tbProveedor.Text = .GetValue("proveedor").ToString
            tbnumiProveedor.Text = .GetValue("lfprov")
            tbCodigo.Text = .GetValue("lfnumi")
            tbFechaCompra.Value = .GetValue("lffecha")
            lbFecha.Text = CType(.GetValue("lffact"), Date).ToString("dd/MM/yyyy")
            lbHora.Text = .GetValue("lfhact").ToString
            lbUsuario.Text = .GetValue("lfuact").ToString
            tbObs.Text = .GetValue("lfobs").ToString
        End With
       

        _prCargarGridDetalle(tbCodigo.Text)
        _prCalcularPrecioTotal()

        LblPaginacion.Text = Str(_MPos + 1) + "/" + JGrM_Buscador.RowCount.ToString

    End Sub



    Public Overrides Function _PMOGrabarRegistro() As Boolean
        Dim res As Boolean
        'ByRef _lfnumi As String, _lffecha As Date, _lfprov As Integer, _lfobs As String, _TCL0051 As DataTable
        res = L_prCompraLavaderoGrabar(tbCodigo.Text, tbFechaCompra.Value.ToString("yyyy/MM/dd"), 1, tbObs.Text, CType(grDetalle.DataSource, DataTable))
        If res Then
            ToastNotification.Show(Me, "Codigo de Compra ".ToUpper + tbCodigo.Text + " Grabado con Exito.".ToUpper, My.Resources.GRABACION_EXITOSA, 5000, eToastGlowColor.Green, eToastPosition.TopCenter)
        End If
        Return res
    End Function
    Public Overrides Function _PMOModificarRegistro() As Boolean
        Dim res As Boolean


        res = L_prCompraLavaderoModificar(tbCodigo.Text, tbFechaCompra.Value.ToString("yyyy/MM/dd"), 1, tbObs.Text, CType(grDetalle.DataSource, DataTable))
        If res Then


            ToastNotification.Show(Me, "Codigo de Compra ".ToUpper + tbCodigo.Text + " modificado con Exito.".ToUpper, My.Resources.GRABACION_EXITOSA, 5000, eToastGlowColor.Green, eToastPosition.TopCenter)
        End If

        Return res
    End Function


    Public Overrides Sub _PMOEliminarRegistro()
        Dim info As New TaskDialogInfo("¿esta seguro de eliminar el registro?".ToUpper, eTaskDialogIcon.Delete, "advertencia".ToUpper, "mensaje principal".ToUpper, eTaskDialogButton.Yes Or eTaskDialogButton.Cancel, eTaskDialogBackgroundColor.Blue)
        Dim result As eTaskDialogResult = TaskDialog.Show(info)
        If result = eTaskDialogResult.Yes Then
            Dim mensajeError As String = ""
            Dim res As Boolean = L_prCompraLavaderoBorrar(tbCodigo.Text, mensajeError)
            If res Then
                ToastNotification.Show(Me, "Codigo de Compra ".ToUpper + tbCodigo.Text + " eliminado con Exito.".ToUpper, My.Resources.GRABACION_EXITOSA, 5000, eToastGlowColor.Green, eToastPosition.TopCenter)
                _PMFiltrar()

            Else
                ToastNotification.Show(Me, mensajeError, My.Resources.WARNING, 8000, eToastGlowColor.Red, eToastPosition.TopCenter)
            End If
        End If
    End Sub
#End Region

#Region "Eventos del Formulario"

    Private Sub F1_ServicioVenta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _prIniciarTodo()

    End Sub



    Private Sub ButtonX2_Click(sender As Object, e As EventArgs)
        If (JGrM_Buscador.Row < 0) Then
            If (JGrM_Buscador.RowCount > 0) Then
                JGrM_Buscador.Row = 0

            End If


        End If
        _prVolverAtras()

    End Sub
    Public Function _fnActionNuevo() As Boolean
        Return tbCodigo.Text = String.Empty And tbObs.ReadOnly = False

    End Function

    Private Sub Estado_Leave(sender As Object, e As EventArgs)
        '' grDetalle.Select()
    End Sub



    Private Sub ELIMINARFILAToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Eliminarms.Click
        Dim pos As Integer = grDetalle.Row

        If (grDetalle.RowCount <= 0) Then
            ToastNotification.Show(Me, "No Se Puede Eliminar Un Detalle De La Compra Debe haber Al Menos Un Producto insertado !!             ", My.Resources.WARNING, 8000, eToastGlowColor.Red, eToastPosition.TopCenter)
            Return
        End If

        If pos >= 0 And pos <= grDetalle.RowCount - 1 Then
            Dim estado As Integer

            Dim lin As Integer = grDetalle.GetValue("lglin")
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

        tbProveedor.Focus()

    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click

        tbProveedor.Focus()


    End Sub





    Private Sub btnGrabar_Click(sender As Object, e As EventArgs) Handles btnGrabar.Click

    End Sub





    Private Sub grDetalle_Enter_1(sender As Object, e As EventArgs) Handles grDetalle.Enter

        
            If (Not _fnVisualizarRegistros()) Then
                grDetalle.Row = 0
            grDetalle.Col = 3
            End If


    End Sub

    Private Sub grDetalle_EditingCell_1(sender As Object, e As EditingCellEventArgs) Handles grDetalle.EditingCell
        If (Not _fnVisualizarRegistros()) Then
            'Habilitar solo las columnas de Precio, %, Monto y Observación
            If (e.Column.Index = grDetalle.RootTable.Columns("lgcant").Index Or
                e.Column.Index = grDetalle.RootTable.Columns("lgpc").Index Or
                e.Column.Index = grDetalle.RootTable.Columns("lgpv").Index) Then
                e.Cancel = False
            Else
                e.Cancel = True
            End If
        Else
            e.Cancel = True
        End If
    End Sub


    Private Sub grDetalle_KeyDown_1(sender As Object, e As KeyEventArgs) Handles grDetalle.KeyDown
        If (e.KeyData = Keys.Tab And grDetalle.Row >= 0 And (Not _fnVisualizarRegistros())) Then
            ''TbdPorcentajeDescuento.Select()
            Exit Sub
        End If

        If (e.KeyData = Keys.Enter) Then
            Dim f, c As Integer
            c = grDetalle.Col
            f = grDetalle.Row

            If (tbFechaCompra.Enabled = True And grDetalle.Col = grDetalle.RootTable.Columns("lgcant").Index) Then
                ''P_AddFilaDetalle()
                'Pasar el foco a la siguente fila
                Dim tam As Integer = grDetalle.RowCount - 1
                Dim lin As Integer = grDetalle.GetValue("lglin")
                Dim pos As Integer = -1
                _prObtenerPosicionDetalle(pos, lin)
                Dim bol As Boolean = _fnValidarColumn(pos, grDetalle.Row, True)
                If (bol = True) Then
                    If (tam <= f) Then
                        _prAddFilaDetalle()

                    End If

                    grDetalle.Row = f + 1
                    grDetalle.Col = 2
                    grDetalle.FocusCellFormatStyle.BackColor = DefaultBackColor
                End If

            End If
salirIf:
        End If

        If (e.KeyData = Keys.Control + Keys.Enter And grDetalle.Row >= 0 And tbFechaCompra.Enabled = True) Then
            Dim indexfil As Integer = grDetalle.Row
            Dim indexcol As Integer = grDetalle.Col

            If (grDetalle.Col = grDetalle.RootTable.Columns("descripcion").Index) Then 'Esta en la cerca de Servicio
                Dim frmAyuda As Modelos.ModeloAyuda
                Dim dt As DataTable = L_prProductoGeneral()
                If (dt.Rows.Count <= 0) Then
                    MsgBox("No Existe Ningun Servicio Registrado Para Efectuar La Venta Registre Servicios Por Favor", MsgBoxStyle.Exclamation, "Error")
                    Return

                End If
                Dim listEstCeldas As New List(Of Modelos.Celda)


                ' a.ldnumi ,a.ldcdprod1 ,a.ldprec ,a.ldprev ,a.ldsmin 
                listEstCeldas.Add(New Modelos.Celda("ldnumi", True, "ID", 60))
                listEstCeldas.Add(New Modelos.Celda("ldcdprod1", True, "DESCRIPCION DE PRODUCTO", 200))
                listEstCeldas.Add(New Modelos.Celda("ldgr1", False))
                listEstCeldas.Add(New Modelos.Celda("GrupoProducto", True, "GRUPO DE PRODUCTOS", 180))
                listEstCeldas.Add(New Modelos.Celda("ldprec", True, "PRECIO DE COMPRA", 150, "0.00"))
                listEstCeldas.Add(New Modelos.Celda("ldprev", True, "PRECIO DE VENTA", 150, "0.00"))
                listEstCeldas.Add(New Modelos.Celda("ldsmin", True, "STOCK MINIMO", 150, "0.00"))
                listEstCeldas.Add(New Modelos.Celda("stock", True, "STOCK ACTUAL", 150, "0.00"))
                frmAyuda = New Modelos.ModeloAyuda(50, 250, dt, "SELECCIONE UN PRODUCTO".ToUpper, listEstCeldas)
                frmAyuda.ShowDialog()



                If frmAyuda.seleccionado = True Then
                    Dim idProd As String = frmAyuda.filaSelect.Cells("ldnumi").Value
                    Dim descr As String = frmAyuda.filaSelect.Cells("ldcdprod1").Value
                    Dim precioc As Double = frmAyuda.filaSelect.Cells("ldprec").Value
                    Dim preciov As Double = frmAyuda.filaSelect.Cells("ldprev").Value
                    Dim stock As Double = frmAyuda.filaSelect.Cells("stock").Value
                    Dim lin As Integer = grDetalle.GetValue("lglin")
                    Dim pos As Integer = -1
                    If (Not _prBuscarExisteNumiServ(idProd)) Then

                        _prObtenerPosicionDetalle(pos, lin)
                        If (pos >= 0) Then
                            CType(grDetalle.DataSource, DataTable).Rows(pos).Item("lgtcl3cpro") = idProd
                            CType(grDetalle.DataSource, DataTable).Rows(pos).Item("descripcion") = descr
                            CType(grDetalle.DataSource, DataTable).Rows(pos).Item("lgpc") = precioc
                            CType(grDetalle.DataSource, DataTable).Rows(pos).Item("lgpv") = preciov
                            CType(grDetalle.DataSource, DataTable).Rows(pos).Item("lgcant") = 1
                            CType(grDetalle.DataSource, DataTable).Rows(pos).Item("lgstocka") = stock
                            CType(grDetalle.DataSource, DataTable).Rows(pos).Item("lgstockf") = stock + 1
                            CType(grDetalle.DataSource, DataTable).Rows(pos).Item("precioTotal") = precioc
                            Dim estado As Integer = CType(grDetalle.DataSource, DataTable).Rows(pos).Item("estado")
                            If (estado = 1) Then
                                CType(grDetalle.DataSource, DataTable).Rows(pos).Item("estado") = 2


                            End If

                          



                        End If

                        If (grDetalle.FocusCellFormatStyle.BackColor = Color.Red) Then
                            grDetalle.FocusCellFormatStyle.BackColor = DefaultBackColor
                        End If
                        'Poner el focus en la siguente casilla
                        grDetalle.Row = indexfil
                        grDetalle.Col = indexcol + 1

                        _prCalcularPrecioTotal()
                    Else
                        ToastNotification.Show(Me, "    Este Servicio ya esta insertado en el detalle de la venta,Pero Usted puede modificar la cantidad del servicio que requiera!!               ", My.Resources.WARNING, 3000, eToastGlowColor.Red, eToastPosition.TopCenter)
                    End If
                    Exit Sub
                End If
            End If

          

        End If
    End Sub


    Private Sub ButtonX1_Click_1(sender As Object, e As EventArgs) Handles ButtonX1.Click
        JGrM_Buscador.RemoveFilters()

        MPanelSup.Visible = False
        JGrM_Buscador.Visible = True
        GroupPanelBuscador.Visible = True

        JGrM_Buscador.Enabled = True
        GroupPanelBuscador.Enabled = True

        PanelSuperior.Visible = False
        JGrM_Buscador.Focus()
        'JGrM_Buscador.MoveTo(JGrM_Buscador.FilterRow)
        'JGrM_Buscador.Col = 7

        ButtonX2.Visible = True
        ButtonX1.Visible = False
    End Sub

    Private Sub ButtonX2_Click_1(sender As Object, e As EventArgs) Handles ButtonX2.Click
        If (JGrM_Buscador.Row < 0) Then
            If (JGrM_Buscador.RowCount > 0) Then
                JGrM_Buscador.Row = 0

            End If


        End If
        _prVolverAtras()

    End Sub

#End Region



    Private Sub grDetalle_CellValueChanged(sender As Object, e As ColumnActionEventArgs) Handles grDetalle.CellValueChanged
        Dim rowIndex As Integer = grDetalle.Row
        'Columna de Precio Venta
        If (Not grDetalle.GetValue("lgcant").ToString = String.Empty) Then


            If (e.Column.Index = grDetalle.RootTable.Columns("lgcant").Index) Then
                If (Not IsNumeric(grDetalle.GetValue("lgcant"))) Then

                    grDetalle.GetRow(rowIndex).Cells("lgcant").Value = 1
                    ''  grDetalle.CurrentRow.Cells.Item("cant").Value = 
                    grDetalle.GetRow(rowIndex).Cells("lgstockf").Value = grDetalle.GetValue("lgstocka") + 1
                    grDetalle.SetValue("lgcant", 1)
                Else
                    If (grDetalle.GetValue("lgcant") > 0) Then


                        P_PonerTotal(rowIndex)
                        grDetalle.GetRow(rowIndex).Cells("lgstockf").Value = grDetalle.GetValue("lgstocka") + grDetalle.GetValue("lgcant")
                    Else
                        grDetalle.GetRow(rowIndex).Cells("lgcant").Value = 1
                        grDetalle.SetValue("lgcant", 1)
                        ''  grDetalle.CurrentRow.Cells.Item("cant").Value = 
                        grDetalle.GetRow(rowIndex).Cells("lgstockf").Value = grDetalle.GetValue("lgstocka") + 1
                        _prCalcularPrecioTotal()

                    End If
                End If
            End If
        Else

            Dim lin As Integer = grDetalle.GetValue("lglin")
            Dim pos As Integer = -1
            _prObtenerPosicionDetalle(pos, lin)
            grDetalle.SetValue("lgcant", 1)
            CType(grDetalle.DataSource, DataTable).Rows(pos).Item("lgcant") = 1
            CType(grDetalle.DataSource, DataTable).Rows(pos).Item("lgstockf") = grDetalle.GetValue("lgstocka")
            CType(grDetalle.DataSource, DataTable).Rows(pos).Item("precioTotal") = CType(grDetalle.DataSource, DataTable).Rows(pos).Item("lgpc")


        End If

        ''''Si es Precio Compra

        If (Not grDetalle.GetValue("lgpc").ToString = String.Empty) Then


            If (e.Column.Index = grDetalle.RootTable.Columns("lgpc").Index) Then
                If (Not IsNumeric(grDetalle.GetValue("lgpc"))) Then

                    grDetalle.GetRow(rowIndex).Cells("lgpc").Value = 1
                    ''  grDetalle.CurrentRow.Cells.Item("cant").Value = 1




                Else
                    If (grDetalle.GetValue("lgpc") > 0) Then


                        P_PonerTotal(rowIndex)

                    Else
                        grDetalle.GetRow(rowIndex).Cells("lgpc").Value = 1
                        _prCalcularPrecioTotal()

                    End If
                End If
            End If
        Else

            Dim lin As Integer = grDetalle.GetValue("lglin")
            Dim pos As Integer = -1
            _prObtenerPosicionDetalle(pos, lin)

            CType(grDetalle.DataSource, DataTable).Rows(pos).Item("lgpc") = 0
            CType(grDetalle.DataSource, DataTable).Rows(pos).Item("precioTotal") = 0


        End If




        Dim line As Integer = grDetalle.GetValue("lglin")
        Dim posi As Integer = -1
        _prObtenerPosicionDetalle(posi, line)
        Dim estado As Integer = CType(grDetalle.DataSource, DataTable).Rows(posi).Item("estado")
        If (estado = 1) Then
            CType(grDetalle.DataSource, DataTable).Rows(posi).Item("estado") = 2
        End If


    End Sub

    Private Sub grDetalle_FormattingRow(sender As Object, e As RowLoadEventArgs) Handles grDetalle.FormattingRow

    End Sub

    Private Sub tbobs_TextChanged(sender As Object, e As EventArgs) Handles tbObs.TextChanged

    End Sub

    Private Sub LabelX3_Click(sender As Object, e As EventArgs) Handles LabelX3.Click

    End Sub
End Class