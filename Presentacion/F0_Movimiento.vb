Imports Logica.AccesoLogica
Imports Janus.Windows.GridEX.EditControls
Imports Janus.Windows.GridEX
Imports DevComponents.DotNetBar

Public Class F0_Movimiento


#Region "Atributos"

    Private Titulo As String
    Private Tipo As Byte

    Public Property pTitulo() As String
        Get
            Return Titulo
        End Get
        Set(ByVal valor As String)
            Titulo = valor
        End Set
    End Property

    Public Property pTipo() As Byte
        Get
            Return Tipo
        End Get
        Set(ByVal valor As Byte)
            Tipo = valor
        End Set
    End Property

#End Region

#Region "Variables Globales"

    Dim _Pos As Integer
    Dim _Nuevo As Boolean
    Dim _Dsencabezado As DataSet

    Dim _BindingSource As BindingSource
    Dim _Modificar As Boolean

    Dim _Eliminar As Boolean

    Dim lDtActStock As DataTable
    Dim lIdAlm As String
    Dim lTipoMov As Boolean

    Dim FtTitulo As Font = New Font("Arial", gi_userFuente + 2, FontStyle.Bold Or FontStyle.Italic)
    Dim FtNormal As Font = New Font("Arial", gi_userFuente, FontStyle.Regular)

#End Region

#Region "Eventos Componentes"

    Private Sub P_Movimientos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _PIniciarTodo()
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        _Habilitar()
        _Limpiar()
        Tb_Fecha.Focus()
        _Nuevo = True
        MRlAccion.Text = "NUEVO"
        P_prEstadoNueModEli(1)
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        _Nuevo = False
        _Modificar = True
        _Habilitar()

        _moverDatosDetalleMod()

        'preparar la actualizada del stock
        lDtActStock = New DataTable
        lDtActStock.Columns.Add("codP")
        lDtActStock.Columns.Add("can")
        For i = 0 To DgjDetalle.RowCount - 1
            DgjDetalle.Row = i
            If IsNothing(DgjDetalle.GetValue(0)) Then
                Exit For
            End If

            Dim codProd As String = DgjDetalle.GetValue(0).ToString
            Dim cant As Integer = DgjDetalle.GetValue(2).ToString
            cant = cant * (-1)
            lDtActStock.Rows.Add(codProd, cant)
        Next
        lIdAlm = 1 'tbAlmacen.Value
        MRlAccion.Text = "MODIFICAR"
        P_prEstadoNueModEli(2)
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim _Result As MsgBoxResult
        _Result = MsgBox("Esta seguro de Eliminar el Registro?", MsgBoxStyle.YesNo, "Advertencia")
        If _Result = MsgBoxResult.Yes Then
            L_Borrar_Movimientos(Tb_Id.Text)
            'borro el detalle del encabezado
            L_Borrar_MovimientosDetalle(Tb_Id.Text)

            'preparar la actualizada del stock
            lDtActStock = New DataTable
            lDtActStock.Columns.Add("codP")
            lDtActStock.Columns.Add("can")
            For i = 0 To DgjDetalle.RowCount - 1
                DgjDetalle.Row = i
                Dim codProd As String = DgjDetalle.GetValue(0).ToString
                Dim cant As Integer = DgjDetalle.GetValue(2)
                cant = cant * (-1)
                lDtActStock.Rows.Add(codProd, cant)
            Next
            'lIdAlm = tbAlmacen.Value
            lIdAlm = 1
            g_prActualizarStock(lDtActStock, True, lIdAlm)

            _Filtrar()
            'mi codigo, actualizo el sub
            _Pos = 0
            LblPaginacion.Text = "Reg: " + Str(_Pos + 1) + "/" + _Dsencabezado.Tables(0).Rows.Count.ToString
        End If
    End Sub

    Private Sub btnGrabar_Click(sender As Object, e As EventArgs) Handles btnGrabar.Click
        _PGrabarRegistro()
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        If (btnGrabar.Enabled = True) Then
            _Nuevo = False 'aumentado danny
            _Modificar = False 'aumentado danny
            _Inhabilitar()
            _Filtrar()
            btnGrabar.Tag = 0

            LblPaginacion.Text = "Reg: " + Str(_Pos + 1) + "/" + _Dsencabezado.Tables(0).Rows.Count.ToString

            P_prEstadoNueModEli(4)
            MRlAccion.Text = ""
        Else
            Me.Close()
        End If
    End Sub

    Private Sub btnPrimero_Click(sender As Object, e As EventArgs) Handles btnPrimero.Click
        _Pos = 0
        MostrarRegistro(_Pos)
        LblPaginacion.Text = "Reg: " + Str(_Pos + 1) + "/" + _Dsencabezado.Tables(0).Rows.Count.ToString
    End Sub

    Private Sub btnAnterior_Click(sender As Object, e As EventArgs) Handles btnAnterior.Click
        If _Pos > 0 Then
            _Pos = _Pos - 1
            MostrarRegistro(_Pos)
            LblPaginacion.Text = "Reg: " + Str(_Pos + 1) + "/" + _Dsencabezado.Tables(0).Rows.Count.ToString
        End If
    End Sub

    Private Sub btnSiguiente_Click(sender As Object, e As EventArgs) Handles btnSiguiente.Click
        If _Pos < _Dsencabezado.Tables(0).Rows.Count - 1 Then
            _Pos = _Pos + 1
            MostrarRegistro(_Pos)
            LblPaginacion.Text = "Reg: " + Str(_Pos + 1) + "/" + _Dsencabezado.Tables(0).Rows.Count.ToString
        End If
    End Sub

    Private Sub btnUltimo_Click(sender As Object, e As EventArgs) Handles btnUltimo.Click
        _Pos = _Dsencabezado.Tables(0).Rows.Count - 1
        MostrarRegistro(_Pos)
        LblPaginacion.Text = "Reg: " + Str(_Pos + 1) + "/" + _Dsencabezado.Tables(0).Rows.Count.ToString
    End Sub

    Private Sub Dgv_Detalle_CellValueChanged(sender As Object, e As ColumnActionEventArgs) Handles DgjDetalle.CellValueChanged
        'If _Nuevo Then
        '    Dim f, c As Integer
        '    c = e.Column.Index
        '    f = Dgv_Detalle.Row
        '    Dim elem As String
        '    'elem = Dgv_Detalle.SelectedItems(0).GetRow.Cells(0).ToString
        '    elem = Dgv_Detalle.CurrentRow.Cells.Item(0).Value
        'End If

        Dim f, c As Integer
        c = e.Column.Index
        f = DgjDetalle.Row

        DgjDetalle.Row = f
        DgjDetalle.Col = 2

        'pasar el foco a peso
        If DgjDetalle.EditMode = EditMode.EditOn Then
            'Dgv_Detalle.Row = f
            'Dgv_Detalle.Col = 2
        End If
    End Sub

    Private Sub Dgv_Detalle_CellUpdated(sender As Object, e As ColumnActionEventArgs) Handles DgjDetalle.CellUpdated
        If _Nuevo Or _Modificar = True Then
            Dim f, c As Integer
            c = e.Column.Index
            f = DgjDetalle.Row
            'If c = 0 Then
            '    Dim elem, descrProd As String
            '    'elem = Dgv_Detalle.SelectedItems(0).GetRow.Cells(0).ToString
            '    elem = Dgv_Detalle.CurrentRow.Cells.Item(0).Value
            '    descrProd = L_Validar_Producto(elem) 'busco la descripcion por el codigo de producto
            '    Dgv_Detalle.CurrentRow.BeginEdit()
            '    Dgv_Detalle.CurrentRow.Cells.Item(1).Value = descrProd

            '    'pasar el foco a peso
            '    'Dgv_Detalle.Row = f
            '    'Dgv_Detalle.Col = 2
            '    'Dgv_Detalle.CurrentRow.BeginEdit()

            'End If

            'verifico si es que esta editando en la ultima fila para agregar filas
            If f + 1 = DgjDetalle.RowCount Then
                _agregarFilasDetalle(2)
            End If
        End If
    End Sub

    Private Sub Dgv_Detalle_EndCustomEdit(sender As Object, e As EndCustomEditEventArgs) Handles DgjDetalle.EndCustomEdit
        'Dim f, c As Integer
        'c = e.Column.Index
        'f = Dgv_Detalle.Row

        ''pasar el foco a peso

        'Dgv_Detalle.Row = f
        'Dgv_Detalle.Col = 2
    End Sub

    Private Sub Dgv_Detalle_UpdatingCell(sender As Object, e As UpdatingCellEventArgs) Handles DgjDetalle.UpdatingCell
        'Dim f, c As Integer
        'c = e.Column.Index
        'f = Dgv_Detalle.Row

        ''pasar el foco a peso

        'Dgv_Detalle.Row = f
        'Dgv_Detalle.Col = 2
    End Sub

    Private Sub Dgv_Detalle_KeyDown(sender As Object, e As KeyEventArgs) Handles DgjDetalle.KeyDown
        If e.KeyCode = Keys.Enter And e.KeyCode = Keys.Tab Then
            Dim f, c As Integer
            c = DgjDetalle.Col
            f = DgjDetalle.Row

            'pasar el foco a peso

            DgjDetalle.Row = f
            DgjDetalle.Col = 2
        End If

        If e.KeyData = Keys.Control + Keys.Enter And (DgjDetalle.Col = 0 Or DgjDetalle.Col = 1) And DgjDetalle.Row >= 0 Then
            Dim frmAyuda As Modelos.ModeloAyuda
            Dim dt As DataTable = L_ProductosGeneral(1, "ldap=1").Tables(0)
            Dim listEstCeldas As New List(Of Modelos.Celda)
            listEstCeldas.Add(New Modelos.Celda("", True, "Código", 70))
            listEstCeldas.Add(New Modelos.Celda("", True, IIf(pTipo = 1, "Equipo", "Próducto"), 150))
            listEstCeldas.Add(New Modelos.Celda("", True, "UM", 150))

            frmAyuda = New Modelos.ModeloAyuda(600, 300, dt, "Seleccione ".ToUpper + IIf(pTipo = 1, "Equipo".ToUpper, "Próducto".ToUpper), listEstCeldas)
            frmAyuda.StartPosition = FormStartPosition.CenterScreen
            frmAyuda.ShowDialog()

            If frmAyuda.seleccionado = True Then
                Dim idProd As String = frmAyuda.filaSelect.Cells("ldnumi").Value
                Dim descr As String = frmAyuda.filaSelect.Cells("ldcdprod1").Value
                DgjDetalle.SetValue(0, idProd)
                DgjDetalle.SetValue(1, descr)
            End If
        End If
    End Sub

    Private Sub JCb_Concepto_ValueChanged(sender As Object, e As EventArgs) Handles JCb_Concepto.ValueChanged
        If JCb_Concepto.SelectedIndex >= 0 Then
            '    If JCb_Concepto.Value <> Nothing Then
            '        Tb_CodConcepto.Text = "Nuevo Tipo"
            '        Bt_AyudaNuevo.Visible = True
            '    Else
            '        Tb_CodConcepto.Text = "Ingrese algo"
            '        Bt_AyudaNuevo.Visible = False
            '    End If
            'Else
            Tb_CodConcepto.Text = JCb_Concepto.Value.ToString
            '    Tb_CodConcepto.Tag = CType(JCb_Concepto.DataSource, DataTable).Select("cpnumi=" + Tb_CodConcepto.Text.Trim)(0).Item("cpmov").ToString
            '    'MsgBox(Tb_CodConcepto.Tag)
            '    Bt_AyudaNuevo.Visible = False
        End If
    End Sub

    Private Sub Bt_AyudaNuevo_Click(sender As Object, e As EventArgs) Handles Bt_AyudaNuevo.Click
        'Dim num As Integer = 0
        'L_Grabar_Libreria(gi_LibMovimientoInv, num, JCb_Concepto.Value.ToString, "") 'le mando num para recuperar su numero del nuevo tipo
        '_LlenarTipoConcepto()
        'JCb_Concepto.SelectedIndex = num - 1
        'JCb_Concepto.Focus()
        Dim num As Integer = 0
        L_AgregarDatosTCI001("", JCb_Concepto.Text.Trim, "1", "0", IIf(pTipo = 1, "2", "3"), "1")
        _LlenarTipoConcepto()
        JCb_Concepto.SelectedIndex = num - 1
        JCb_Concepto.Focus()
    End Sub

    Private Sub QuitarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QuitarToolStripMenuItem.Click
        If (btnGrabar.Enabled) Then
            Try
                DgjDetalle.CurrentRow.EndEdit()
                DgjDetalle.CurrentRow.Delete()
                DgjDetalle.Refetch()
                DgjDetalle.Refresh()
            Catch ex As Exception
                'sms
            End Try
        End If
    End Sub

#End Region

#Region "Metodos Privados"

    Private Sub _PIniciarTodo()

        'L_prAbrirConexion()

        Me.Text = pTitulo

        _LlenarTipoConcepto()
        _prCargarComboAlmacen()
        '_Armar_Detalle("1")
        _Filtrar()

        _Nuevo = False
        _Modificar = False
        _Eliminar = False

        LblPaginacion.Text = "Reg: " + Str(_Pos + 1) + "/" + _Dsencabezado.Tables(0).Rows.Count.ToString

        Bt_AyudaNuevo.Visible = False
        btnGrabar.Enabled = False
        QuitarToolStripMenuItem.Visible = False
        SupTabItemBusqueda.Visible = False
        btnImprimir.Visible = False

        'activar los permisos del rol
        '_PAsignarPermisos()
        '_pCambiarFuente()
    End Sub

    Private Sub _pCambiarFuente()
        Dim fuente As New Font("Tahoma", gi_userFuente, FontStyle.Regular)
        Dim xCtrl As Control
        For Each xCtrl In PanelPrincipal.Controls
            Try
                xCtrl.Font = fuente
            Catch ex As Exception
            End Try
        Next
        For Each xCtrl In PanelPrincipal.Controls
            Try
                xCtrl.Font = fuente
            Catch ex As Exception
            End Try
        Next
    End Sub

    Private Sub _PAsignarPermisos()
        Dim idRolUsu As String = L_Usuario_General(-1, " AND yduser='" + P_Global.gs_user + "' ").Tables(0).Rows(0).Item("ybnumi")
        Dim dtRolUsu As DataTable = L_RolDetalle_General2(-1, idRolUsu, "ycyanumi=" + IIf(pTipo = 1, "24", "59"))
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

    Private Sub _prCargarComboAlmacen()
        'Dim _dt As DataTable
        '_dt = L_AlmacenGeneral()

        'With tbAlmacen.DropDownList
        '    .Columns.Clear()
        '    .Columns.Add(_dt.Columns("cinumi").ToString).Width = 50
        '    .Columns(0).Caption = "Código"
        '    .Columns.Add(_dt.Columns("cidesc").ToString).Width = 250
        '    .Columns(1).Caption = "Descripcion"
        'End With

        'With tbAlmacen
        '    .ValueMember = _dt.Columns("cinumi").ToString
        '    .DisplayMember = _dt.Columns("cidesc").ToString
        '    .DataSource = _dt
        '    .Refresh()
        'End With
    End Sub

    Private Sub _Habilitar()
        Tb_Observacion.Enabled = True
        Tb_Observacion.ReadOnly = False
        JCb_Concepto.Enabled = True
        'tbAlmacen.Enabled = True
        Tb_Fecha.Enabled = True

        DgjDetalle.Enabled = True

        Rb_Inac.Enabled = True
        Rb_Act.Enabled = True

        btnNuevo.Enabled = False
        btnModificar.Enabled = False
        btnEliminar.Enabled = False
        btnGrabar.Enabled = True
    End Sub

    Private Sub _Inhabilitar()
        Tb_Id.ReadOnly = True
        Tb_Observacion.Enabled = False
        Tb_Observacion.ReadOnly = True
        Tb_Fecha.Enabled = False

        JCb_Concepto.Enabled = False
        'tbAlmacen.Enabled = False

        DgjDetalle.Enabled = False

        Rb_Inac.Enabled = False
        Rb_Act.Enabled = False

        btnNuevo.Enabled = True
        btnModificar.Enabled = True
        btnEliminar.Enabled = True
        btnGrabar.Enabled = False
        'JCb_Prod.BackColor = Color.White
        'Ep1.SetError(JCb_Prod, "")
    End Sub

    Private Sub _Limpiar()
        Tb_Id.Text = ""
        Tb_Fecha.Value = Now.Date

        'JCb_Insumo.SelectedIndex = 0
        JCb_Concepto.SelectedIndex = 0
        Tb_Observacion.Text = ""

        Rb_Act.Checked = True

        'vaciar detalle para nuevo
        _Armar_Detalle(-1)
        DgjDetalle.BoundMode = Janus.Windows.GridEX.BoundMode.Unbound
        _agregarFilasDetalle(3)
    End Sub

    Private Sub P_prEstadoNueModEli(Val As Integer)
        _Nuevo = (Val = 1)
        _Modificar = (Val = 2)
        _Eliminar = (Val = 3)

        btnNuevo.Enabled = (Val = 4)
        btnModificar.Enabled = (Val = 4)
        btnEliminar.Enabled = (Val = 4)
        btnGrabar.Enabled = Not (Val = 4)

        If (Val = 4) Then
            btnSalir.Tooltip = "SALIR"
        Else
            btnSalir.Tooltip = "CANCELAR"
        End If

        btnPrimero.Enabled = (Val = 4)
        btnAnterior.Enabled = (Val = 4)
        btnSiguiente.Enabled = (Val = 4)
        btnUltimo.Enabled = (Val = 4)
        PanelToolBar1.Refresh()

        'SuperTabItem2.Visible = (Val = 4)
        QuitarToolStripMenuItem.Visible = (Val = 1)
    End Sub

    Private Function _Validar() As Boolean
        Dim _Error As Boolean = False
        'If Tb_Codigo.Text = "" Then
        '    Tb_Codigo.BackColor = Color.Red   'error de validacion
        '    Ep1.SetError(Tb_Codigo, "Tiene que ingresar Codigo")
        '    _Error = True
        'Else
        '    Tb_Codigo.BackColor = Color.White
        '    Ep1.SetError(Tb_Codigo, "")
        '    _Error = False
        'End If

        'Validar comboBox
        If JCb_Concepto.SelectedIndex < 0 Then
            JCb_Concepto.BackColor = Color.Red   'error de validacion
            MEP.SetError(JCb_Concepto, "Tiene que Elegir Producto")
            _Error = True
        Else
            JCb_Concepto.BackColor = Color.White
            MEP.SetError(JCb_Concepto, "")
            '_Error = False
        End If

        'If tbAlmacen.SelectedIndex < 0 Then
        '    tbAlmacen.BackColor = Color.Red
        '    Ep1.SetError(tbAlmacen, "Seleccione almacen!".ToUpper)
        '    _Error = True
        'Else
        '    tbAlmacen.BackColor = Color.White
        '    Ep1.SetError(tbAlmacen, "")
        'End If
        Return _Error
    End Function

    Private Sub MostrarRegistro(_N As Integer)
        Dim _Ds As New DataSet

        Tb_Id.Text = _Dsencabezado.Tables(0).Rows(_N).Item("ibid")
        Tb_Fecha.Value = _Dsencabezado.Tables(0).Rows(_N).Item("ibfdoc")

        'Poner descripcion del concepto
        Dim codConcepto As String = _Dsencabezado.Tables(0).Rows(_N).Item("ibconcep")
        'JCb_Prod.SelectedIndex = Int(_Dsencabezado.Tables(0).Rows(_N).Item("cdcprod")) - 1
        'JCb_Concepto.Text = L_Validar_Librerias(gi_LibMovimientoInv, codConcepto)
        Dim text As String = CType(JCb_Concepto.DataSource, DataTable).Select("cpnumi=" + codConcepto)(0).Item("cpdesc").ToString
        JCb_Concepto.Clear()
        JCb_Concepto.SelectedText = text
        Tb_CodConcepto.Text = codConcepto

        Tb_Observacion.Text = _Dsencabezado.Tables(0).Rows(_N).Item("ibobs")
        'ahora poner el detalle de acuerdo con el producto seleccionado
        _Armar_Detalle(Tb_Id.Text)

        'Tb_Peso.Text = _Dsencabezado.Tables(0).Rows(_N).Item(3)
        Dim estado As String = _Dsencabezado.Tables(0).Rows(_N).Item("ibest")
        If estado = "1" Then
            Rb_Act.Checked = True
        Else
            Rb_Inac.Checked = True
        End If
        'tbAlmacen.Text = _Dsencabezado.Tables(0).Rows(_N).Item("cidesc")
    End Sub

    Private Sub _Filtrar()
        _Dsencabezado = New DataSet
        _Dsencabezado = L_MovimientosGeneral(1, "ibest=" + IIf(pTipo = 1, "1", "3")) '1=Movimientos de equipos,2=Movimientos desde el detalle de clientes, 3=Movimientos de productos, 4=Movimientos desde el detalle de venta

        If _Dsencabezado.Tables(0).Rows.Count <> 0 Then
            MostrarRegistro(0)
            If _Dsencabezado.Tables(0).Rows.Count > 0 Then
                btnSiguiente.Visible = True
                btnUltimo.Visible = True
                btnAnterior.Visible = True
                btnPrimero.Visible = True
            End If
        End If
    End Sub

    Private Sub _LlenarTipoConcepto()
        Dim dt As New DataTable
        dt = L_ConceptoInventario(IIf(pTipo = 1, "2", "3")) '2=Concepto de inventario de equipos, 3=Concepto de inventario de productos

        JCb_Concepto.DropDownList.Columns.Clear()
        JCb_Concepto.DropDownList.Columns.Add(dt.Columns(0).ToString).Width = 50
        JCb_Concepto.DropDownList.Columns(0).Caption = "Código"
        JCb_Concepto.DropDownList.Columns.Add(dt.Columns(1).ToString).Width = 250
        JCb_Concepto.DropDownList.Columns(1).Caption = "Descripcion"
        JCb_Concepto.DropDownList.Columns.Add(dt.Columns(2).ToString).Width = 0
        JCb_Concepto.DropDownList.Columns(2).Caption = ""
        JCb_Concepto.DropDownList.Columns(2).Visible = False

        JCb_Concepto.ValueMember = dt.Columns(0).ToString
        JCb_Concepto.DisplayMember = dt.Columns(1).ToString
        JCb_Concepto.DataSource = dt
        JCb_Concepto.Refresh()
    End Sub

    Private Sub _Armar_Detalle(idReceta As String)
        Dim _Ds, _Ds1 As New DataSet
        _Ds = L_MovimientosDetalleGeneral(1, idReceta) 'PENDIENTE HACER EL DETALLE EN LOGICA
        _BindingSource = New BindingSource
        _BindingSource.DataSource = _Ds.Tables(0).DefaultView
        'Dgv_Detalle.RowTemplate.Height = 15

        'mi codigo, cambio el modo de llenado de la tabla
        DgjDetalle.BoundMode = Janus.Windows.GridEX.BoundMode.Bound

        DgjDetalle.DataSource = _BindingSource.DataSource
        DgjDetalle.RetrieveStructure()

        'preparar los datos para el multicombo

        With DgjDetalle.RootTable.Columns(0)
            .Caption = "ID"
            .Width = 80
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .HeaderStyle.Font = FtTitulo
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .EditType = EditType.NoEdit
        End With
        With DgjDetalle.RootTable.Columns(1)
            .Caption = "Descripcion"
            .Width = 250
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .HeaderStyle.Font = FtTitulo
            .CellStyle.Font = FtNormal
            .CellStyle.BackColor = Color.LightGray
            .EditType = EditType.NoEdit
            .AllowSort = False
        End With
        With DgjDetalle.RootTable.Columns(2)
            .Caption = "Cantidad"
            .Width = 80
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .HeaderStyle.Font = FtTitulo
            .CellStyle.Font = FtNormal
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .FormatString = "0.00"
        End With

        With DgjDetalle
            .GroupByBoxVisible = False
            '.FilterRowFormatStyle.BackColor = Color.Blue
            .DefaultFilterRowComparison = FilterConditionOperator.Contains
            '.FilterMode = FilterMode.Automatic
            .FilterRowUpdateMode = FilterRowUpdateMode.WhenValueChanges
            'Diseño de la tabla
            .VisualStyle = VisualStyle.Office2007
            .SelectionMode = SelectionMode.SingleSelection
            .AlternatingColors = True
            .RowHeaders = InheritableBoolean.True
            '.View = View.CardView
            '.AllowDelete = InheritableBoolean.True
        End With

    End Sub

    Private Sub _agregarFilasDetalle(cant As Integer)
        Dim newRow As GridEXRow
        Dim i As Integer
        For i = 1 To cant
            newRow = DgjDetalle.AddItem()
        Next
    End Sub

    Private Sub _moverDatosDetalleMod()
        Dim _Ds As New DataSet
        _Ds = L_MovimientosDetalleGeneral(1, Tb_Id.Text)
        Dim _Dt As DataTable
        _Dt = _Ds.Tables(0)

        'agregar filas necesarias para llenar el detalle
        DgjDetalle.BoundMode = Janus.Windows.GridEX.BoundMode.Unbound
        _agregarFilasDetalle(_Dt.Rows.Count + 1)

        Dim idProd, descProd, cant As String
        DgjDetalle.Row = 0
        DgjDetalle.CurrentRow.BeginEdit()
        For Each row As DataRow In _Dt.Rows
            idProd = row(0)
            DgjDetalle.CurrentRow.Cells.Item(0).Value = idProd

            descProd = row(1)
            DgjDetalle.CurrentRow.Cells.Item(1).Value = descProd

            cant = row(2)
            DgjDetalle.CurrentRow.Cells.Item(2).Value = cant

            'bloquear fila
            DgjDetalle.Row = DgjDetalle.Row + 1
            DgjDetalle.CurrentRow.BeginEdit()
        Next
    End Sub

    Private Sub _PGrabarRegistro()
        Dim _Error As Boolean = False
        If _Validar() Then
            Exit Sub
        End If
        If btnGrabar.Enabled = False Then
            Exit Sub
        End If

        If _Nuevo Then
            L_Grabar_Movimientos(Tb_Id.Text, _
                              Tb_Fecha.Value.Date.ToString("yyyy/MM/dd"), _
                              JCb_Concepto.Value, _
                              Tb_Observacion.Text, _
                              IIf(pTipo = 1, "1", "3"), "1", 0)
            'grabar detalle
            Dim i, mov As Integer
            Dim idMovimiento, idProd, cant As String
            idMovimiento = Tb_Id.Text
            mov = CInt(CType(JCb_Concepto.DataSource, DataTable).Select("cpnumi=" + JCb_Concepto.Value.ToString)(0).Item("cpmov").ToString)
            For i = 0 To DgjDetalle.RowCount - 1
                DgjDetalle.Row = i
                Try
                    idProd = DgjDetalle.CurrentRow.Cells.Item(0).Value
                    cant = DgjDetalle.CurrentRow.Cells.Item(2).Value
                    If idProd <> Nothing And cant <> Nothing And idProd <> "" And cant <> "" Then
                        L_Grabar_MovimientosDetalle(idMovimiento, idProd, cant)
                        'actualizamos el stock
                        L_Actualizar_StockMovimiento(idProd, cant * mov, 1)
                    End If
                Catch ex As Exception

                End Try
            Next
            Tb_Fecha.Focus()
            ToastNotification.Show(Me,
                                   "Codigo de Movimiento " + Tb_Id.Text + " Grabado con Exito.",
                                   My.Resources.GRABACION_EXITOSA, 5000,
                                   eToastGlowColor.Green,
                                   eToastPosition.TopCenter)
            _Limpiar()
            btnSalir.PerformClick()
        Else
            L_Modificar_Movimientos(Tb_Id.Text, _
                              Tb_Fecha.Value.Date.ToString("yyyy/MM/dd"), _
                              JCb_Concepto.Value, _
                              Tb_Observacion.Text, _
                              IIf(pTipo = 1, "1", "3"))
            Dim i, mov As Integer
            Dim idMovimiento, idProd, cant As String
            idMovimiento = Tb_Id.Text
            mov = CInt(CType(JCb_Concepto.DataSource, DataTable).Select("cpnumi=" + JCb_Concepto.Value.ToString)(0).Item("cpmov").ToString)
            'borrar detalle
            L_Borrar_MovimientosDetalle(idMovimiento)
            'sacar stock que estaba anteriormente
            g_prActualizarStock(lDtActStock, True, lIdAlm)
            'grabar nuevo detalle
            For i = 0 To DgjDetalle.RowCount - 1
                DgjDetalle.Row = i
                Try
                    idProd = DgjDetalle.CurrentRow.Cells.Item(0).Value
                    cant = DgjDetalle.CurrentRow.Cells.Item(2).Value
                    If idProd <> Nothing And cant <> Nothing And idProd <> "" And cant <> "" Then
                        L_Grabar_MovimientosDetalle(idMovimiento, idProd, cant)
                        L_Actualizar_StockMovimiento(idProd, cant * mov, 1)
                    End If
                Catch ex As Exception

                End Try
            Next

            _Nuevo = False 'aumentado danny
            _Modificar = False 'aumentado danny
            _Inhabilitar()
            _Filtrar()

            MRlAccion.Text = ""
            ToastNotification.Show(Me,
                                   "Codigo de Movimiento " + Tb_Id.Text + " Modificado con Exito.",
                                   My.Resources.GRABACION_EXITOSA,
                                   5000, eToastGlowColor.Green,
                                   eToastPosition.TopCenter)
        End If
    End Sub

#End Region

End Class