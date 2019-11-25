Imports Logica.AccesoLogica
Imports Janus.Windows.GridEX
Imports DevComponents.DotNetBar

Public Class F0_DescuentosFijos

#Region "Variables Lcales"
    Dim _Dsencabezado As DataSet
    Dim _Pos As Integer
    Dim _Nuevo As Boolean

#End Region

#Region "Metodos Privados"

    Private Sub _PCargarBuscador()
        Dim dt As New DataTable
        dt = L_DescuentoFijo_General(0).Tables(0)

        JGr_Buscador.BoundMode = BoundMode.Bound
        JGr_Buscador.DataSource = dt
        JGr_Buscador.RetrieveStructure()

        'dar formato a las columnas
        With JGr_Buscador.RootTable.Columns("panumi")
            .Caption = "Codigo"
            .Width = 70
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        End With

        With JGr_Buscador.RootTable.Columns("patipo")
            .Caption = "Tipo Desc."
            .Width = 90
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        End With

        With JGr_Buscador.RootTable.Columns("pavalor")
            .Caption = "Descuento"
            .Width = 130
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .FormatString = "0.00"
        End With

        With JGr_Buscador.RootTable.Columns("pacper")
            .Caption = "Cod. Persona"
            .Width = 90
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        End With

        With JGr_Buscador.RootTable.Columns("cbdesc")
            .Caption = "Nombre"
            .Width = 300
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
        End With

        With JGr_Buscador.RootTable.Columns("paobs")
            .Caption = "Observacion"
            .Width = 300
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
        End With

        With JGr_Buscador.RootTable.Columns("pavenc")
            .Caption = "Venci"
            .Visible = True
            .Width = 60
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .EditType = EditType.CheckBox
            .ColumnType = ColumnType.CheckBox
            .CheckBoxFalseValue = 0
            .CheckBoxTrueValue = 1
        End With

        With JGr_Buscador.RootTable.Columns("pafvenc")
            .Caption = "Fecha Venc"
            .Width = 100
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        End With

        'Habilitar Filtradores
        With JGr_Buscador
            .DefaultFilterRowComparison = FilterConditionOperator.Contains
            .FilterMode = FilterMode.Automatic
            .FilterRowUpdateMode = FilterRowUpdateMode.WhenValueChanges
            .GroupByBoxVisible = False
            'diseño de la grilla
            JGr_Buscador.VisualStyle = VisualStyle.Office2007
        End With


    End Sub

    Private Sub _PCargarComboEmpleados()
        Dim _Ds As New DataSet
        _Ds.Tables.Add(L_prPersonaAyudaTodosGeneral())

        JMc_Persona.DropDownList.Columns.Clear()


        JMc_Persona.DropDownList.Columns.Add(_Ds.Tables(0).Columns("panumi").ToString).Width = 50
        JMc_Persona.DropDownList.Columns(0).Caption = "Código"
        JMc_Persona.DropDownList.Columns.Add(_Ds.Tables(0).Columns("paci").ToString).Width = 70
        JMc_Persona.DropDownList.Columns(1).Caption = "CI"
        JMc_Persona.DropDownList.Columns.Add(_Ds.Tables(0).Columns("panom1").ToString).Width = 250
        JMc_Persona.DropDownList.Columns(2).Caption = "Descripcion"

        JMc_Persona.ValueMember = _Ds.Tables(0).Columns("panumi").ToString
        JMc_Persona.DisplayMember = _Ds.Tables(0).Columns("panom1").ToString
        JMc_Persona.DataSource = _Ds.Tables(0)
        JMc_Persona.Refresh()
    End Sub

    Private Sub _PHabilitar()
        'Tb_Observacion.Enabled = True
        'Tb_TipoMov.Enabled = True
        'Tb_Valor.Enabled = True
        'JMc_Persona.Enabled = True
        'tbVencimiento.Enabled = True

        Tb_Observacion.ReadOnly = False
        Tb_TipoMov.Enabled = True
        Tb_Valor.ReadOnly = False
        JMc_Persona.ReadOnly = False
        tbVencimiento.Enabled = True

        If tbVencimiento.Value = True Then
            tbFechaVenci.Enabled = True
        End If



        btnNuevo.Enabled = False
        btnModificar.Enabled = False
        btnEliminar.Enabled = False
        btnGrabar.Enabled = True

    End Sub
    Private Sub _PInhabilitar()
        'Tb_Id.Enabled = False
        'Tb_Observacion.Enabled = False
        'Tb_TipoMov.Enabled = False
        'Tb_Valor.Enabled = False
        'JMc_Persona.Enabled = False
        'tbFechaVenci.Enabled = False
        'tbVencimiento.Enabled = False

        Tb_Id.ReadOnly = True
        Tb_Observacion.ReadOnly = True
        Tb_TipoMov.Enabled = False
        Tb_Valor.ReadOnly = True
        JMc_Persona.ReadOnly = True
        tbFechaVenci.Enabled = False
        tbVencimiento.Enabled = False


        btnNuevo.Enabled = True
        btnModificar.Enabled = True
        btnEliminar.Enabled = True
        btnGrabar.Enabled = False

        LblPaginacion.Text = ""

        btnGrabar.Image = My.Resources.GUARDAR

        _PLimpiarErrores()
    End Sub
    Private Sub _PLimpiarErrores()
        'Ep1.Clear()
        'Ep2.Clear()
        'J_Cb_Ciudad.BackColor = Color.White
        'J_Cb_Provincia.BackColor = Color.White
        'J_Cb_Zona.BackColor = Color.White
        'ButtonX1.BackColor = Color.White
    End Sub
    Private Sub _PLimpiar()
        Tb_Id.Text = ""
        Tb_Observacion.Text = ""
        Tb_TipoMov.Value = True
        Tb_Valor.Text = ""
        tbFechaVenci.Value = Today.Date
        tbVencimiento.Value = False

        'aumentado 
        LblPaginacion.Text = ""

    End Sub
    Private Sub _PHabilitarFocus()

        MHighlighterFocus.SetHighlightOnFocus(Tb_TipoMov, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
        MHighlighterFocus.SetHighlightOnFocus(Tb_Valor, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
        MHighlighterFocus.SetHighlightOnFocus(JMc_Persona, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
        MHighlighterFocus.SetHighlightOnFocus(Tb_Observacion, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
        MHighlighterFocus.SetHighlightOnFocus(tbVencimiento, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
        MHighlighterFocus.SetHighlightOnFocus(tbFechaVenci, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)

        Tb_TipoMov.TabIndex = 1
        Tb_Valor.TabIndex = 2
        JMc_Persona.TabIndex = 3
        Tb_Observacion.TabIndex = 4
        GroupPanel1.TabIndex = 5
        tbVencimiento.TabIndex = 1
        tbFechaVenci.TabIndex = 2
    End Sub

    Private Sub _PIniciarTodo()
        Me.Text = "D E S C U E N T O S     F I J O S"
        Me.WindowState = FormWindowState.Maximized

        'abrir conexion
        _PCargarBuscador()

        _PCargarComboEmpleados()

        _PFiltrar()
        _PInhabilitar()

        _PHabilitarFocus()

        _pCambiarFuente()
    End Sub

    Private Sub _pCambiarFuente()
        'Dim fuente As New Font("Tahoma", gi_fuenteTamano, FontStyle.Regular)
        'Dim xCtrl As Control
        'For Each xCtrl In PanelEx3.Controls
        '    Try
        '        xCtrl.Font = fuente
        '    Catch ex As Exception
        '    End Try
        'Next

        'For Each xCtrl In PanelEx4.Controls
        '    Try
        '        xCtrl.Font = fuente
        '    Catch ex As Exception
        '    End Try
        'Next

    End Sub

    Private Sub _PFiltrar()
        _Dsencabezado = New DataSet
        _Dsencabezado = L_DescuentoFijo_General(0)
        '_First = False
        If _Dsencabezado.Tables(0).Rows.Count <> 0 Then
            _Pos = 0
            _PMostrarRegistro(_Pos)
            If _Dsencabezado.Tables(0).Rows.Count > 0 Then
                btnPrimero.Visible = True
                btnAnterior.Visible = True
                btnSiguiente.Visible = True
                btnUltimo.Visible = True
            End If
        End If

    End Sub
    Private Sub _PMostrarRegistro(_N As Integer)

        JGr_Buscador.Row = _Pos
        With JGr_Buscador
            Tb_Id.Text = .GetValue("panumi").ToString

            Tb_TipoMov.Value = .GetValue("patipo")

            Tb_Valor.Text = .GetValue("pavalor").ToString

            JMc_Persona.Text = .GetValue("cbdesc").ToString

            Tb_Observacion.Text = .GetValue("paobs").ToString

            tbVencimiento.Value = IIf(.GetValue("pavenc") = 1, True, False)

            tbFechaVenci.Value = .GetValue("pafvenc")

        End With
        LblPaginacion.Text = Str(_Pos + 1) + "/" + JGr_Buscador.RowCount.ToString
    End Sub
    Private Function _PValidar() As Boolean
        Dim _Error As Boolean = False

        If Tb_Valor.Text = "" Then
            Tb_Valor.BackColor = Color.Red   'error de validacion
            'Ep1.SetError(Tb_Nombre, "Ingrese el nombre del empleado!")
            _Error = True
        Else
            Tb_Valor.BackColor = Color.White
            'Ep1.SetError(Tb_Nombre, "")
        End If

        If JMc_Persona.SelectedIndex < 0 Then
            JMc_Persona.BackColor = Color.Red   'error de validacion
            'Ep1.SetError(Tb_Nombre, "Ingrese el nombre del empleado!")
            _Error = True
        Else
            JMc_Persona.BackColor = Color.White
            'Ep1.SetError(Tb_Nombre, "")
        End If

        Return _Error
    End Function

    Private Sub _PGrabarRegistro()
        Dim _Error As Boolean = False
        If _PValidar() Then
            Exit Sub
        End If
        If btnGrabar.Enabled = False Then
            Exit Sub
        End If

        'If Lb_Mensaje.Text = "" Then
        '    Lb_Mensaje.Text = "Esta Seguro de Grabar?"
        '    Exit Sub
        'Else
        '    Lb_Mensaje.Text = ""
        'End If
        If False Then 'bbtGrabar.Tag = 0 
            'bbtGrabar.Tag = 1
            'bbtGrabar.Image = My.Resources.CONFIRMACION
            'bbtGrabar.ImageLarge = My.Resources.CONFIRMACION
            'BubbleBar6.Refresh()
            'Exit Sub
        Else
            btnGrabar.Tag = 0
        End If


        If _Nuevo Then
            Dim tipo As String
            If Tb_TipoMov.Value Then
                tipo = "1"
            Else
                tipo = "0"
            End If

            L_DescuentoFijo_Grabar(Tb_Id.Text, tipo, Tb_Valor.Text, JMc_Persona.Value, Tb_Observacion.Text, IIf(tbVencimiento.Value = True, "1", "0"), tbFechaVenci.Value.ToString("yyyy/MM/dd"))

            'actualizar el grid de buscador
            _PCargarBuscador()

            Tb_Valor.Focus()
            ToastNotification.Show(Me, "Codigo de descuento fijo ".ToUpper + Tb_Id.Text + " Grabado con Exito.".ToUpper, My.Resources.GRABACION_EXITOSA, 5000, eToastGlowColor.Green, eToastPosition.BottomLeft)
            'Tsbl0_Mensaje.Text = ""
            _PLimpiar()
        Else
            Dim tipo As String
            If Tb_TipoMov.Value Then
                tipo = "1"
            Else
                tipo = "0"
            End If
            L_DescuentoFijo_Modificar(Tb_Id.Text, tipo, Tb_Valor.Text, JMc_Persona.Value, Tb_Observacion.Text, IIf(tbVencimiento.Value = True, "1", "0"), tbFechaVenci.Value.ToString("yyyy/MM/dd"))

            ToastNotification.Show(Me, "Codigo de descuento fijo ".ToUpper + Tb_Id.Text + " Modificado con Exito.".ToUpper, My.Resources.GRABACION_EXITOSA, 5000, eToastGlowColor.Green, eToastPosition.BottomLeft)
            '_Deshabilitar()

            'TSB0_5.PerformClick()
            _Nuevo = False 'aumentado danny
            '_Modificar = False 'aumentado danny
            _PInhabilitar()
            _PCargarBuscador()
            _PFiltrar()
        End If
    End Sub

    Private Sub _PNuevoRegistro()
        _PHabilitar()
        btnNuevo.Enabled = True

        _PLimpiar()
        Tb_Valor.Focus()
        _Nuevo = True
    End Sub

    Private Sub _PModificarRegistro()
        _Nuevo = False
        '_Modificar = True
        _PHabilitar()
    End Sub

    Private Sub _PEliminarRegistro()
        Dim _Result As MsgBoxResult
        _Result = MsgBox("Esta seguro de Eliminar el Registro?", MsgBoxStyle.YesNo, "Advertencia")
        If _Result = MsgBoxResult.Yes Then
            L_DescuentoFijo_Borrar(Tb_Id.Text)
            'borro el detalle del encabezado
            'L_Borrar_LibreriasDetalle(Tb_Id.Text)
            _PFiltrar()

            'mi codigo, actualizo el sub
            _Pos = 0
            LblPaginacion.Text = Str(_Pos + 1) + "/" + _Dsencabezado.Tables(0).Rows.Count.ToString
        End If
    End Sub

    Private Sub _PSalirRegistro()
        If btnGrabar.Enabled = True Then
            _PInhabilitar()
            _PFiltrar()
        Else
            Me.Close()
        End If
    End Sub

    Private Sub _PGrabarNuevasLibrerias()
        ''Dim codCiu, codProv, codZona As Integer
        ''If J_Cb_Ciudad.SelectedIndex < 0 Then
        ''    L_Grabar_LibreriaDetalle(13, 13, codCiu, J_Cb_Ciudad.Text)
        ''    _LlenarComboLibreria(J_Cb_Ciudad, 13)
        ''    J_Cb_Ciudad.Value = codCiu
        ''    Ep2.SetError(J_Cb_Ciudad, "")
        ''End If

        ''If J_Cb_Provincia.SelectedIndex < 0 Then
        ''    L_Grabar_LibreriaDetalle(4, 4, codProv, J_Cb_Provincia.Text)
        ''    _LlenarComboLibreria(J_Cb_Provincia, 4)
        ''    J_Cb_Provincia.Value = codProv
        ''    Ep2.SetError(J_Cb_Provincia, "")
        ''End If

        ''If J_Cb_Zona.SelectedIndex < 0 Then
        ''    L_Grabar_LibreriaDetalle(2, 2, codZona, J_Cb_Zona.Text)
        ''    _LlenarComboLibreria(J_Cb_Zona, 2)
        ''    J_Cb_Zona.Value = codZona
        ''    Ep2.SetError(J_Cb_Zona, "")
        ''End If
        ''Pan_Dialogo.Visible = False
    End Sub

    Private Sub _PPrimerRegistro()
        If JGr_Buscador.RowCount > 0 Then
            _Pos = 0
            _PMostrarRegistro(_Pos)
        End If
    End Sub
    Private Sub _PAnteriorRegistro()
        If _Pos > 0 Then
            _Pos = _Pos - 1
            _PMostrarRegistro(_Pos)
        End If
    End Sub
    Private Sub _PSiguienteRegistro()
        If _Pos < JGr_Buscador.RowCount - 1 Then
            _Pos = _Pos + 1
            _PMostrarRegistro(_Pos)
        End If
    End Sub
    Private Sub _PUltimoRegistro()
        If JGr_Buscador.RowCount > 0 Then
            _Pos = JGr_Buscador.RowCount - 1
            _PMostrarRegistro(_Pos)
        End If
    End Sub

#End Region

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        _PNuevoRegistro()
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        _PModificarRegistro()
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        _PEliminarRegistro()
    End Sub

    Private Sub btnGrabar_Click(sender As Object, e As EventArgs) Handles btnGrabar.Click
        _PGrabarRegistro()
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        _PSalirRegistro()
    End Sub

    Private Sub btnPrimero_Click(sender As Object, e As EventArgs) Handles btnPrimero.Click
        _PPrimerRegistro()
    End Sub

    Private Sub btnAnterior_Click(sender As Object, e As EventArgs) Handles btnAnterior.Click
        _PAnteriorRegistro()
    End Sub

    Private Sub btnSiguiente_Click(sender As Object, e As EventArgs) Handles btnSiguiente.Click
        _PSiguienteRegistro()
    End Sub

    Private Sub btnUltimo_Click(sender As Object, e As EventArgs) Handles btnUltimo.Click
        _PUltimoRegistro()
    End Sub

    Private Sub F0_DescuentosFijos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _PIniciarTodo()
    End Sub

    Private Sub JGr_Buscador_EditingCell(sender As Object, e As EditingCellEventArgs) Handles JGr_Buscador.EditingCell
        e.Cancel = True
    End Sub

    Private Sub tbVencimiento_ValueChanged(sender As Object, e As EventArgs) Handles tbVencimiento.ValueChanged
        If btnGrabar.Enabled = True Then
            tbFechaVenci.Enabled = tbVencimiento.Value
        End If
    End Sub

    'Private Sub FlyoutUsuario_PrepareContent(sender As Object, e As EventArgs) Handles FlyoutUsuario.PrepareContent
    '    If sender Is BubbleBar5 And bbtGrabar.Enabled = False Then
    '        Dim dtAud As DataTable = L_ObtenerAuditoria("TP001", "pa", "panumi=" + Tb_Id.Text)
    '        If IsDBNull(dtAud.Rows(0).Item(0)) = True Then
    '            lbFecha.Text = ""
    '        Else
    '            lbFecha.Text = Convert.ToDateTime(dtAud.Rows(0).Item(0)).ToString("dd/MM/yyyy")
    '        End If
    '        lbHora.Text = dtAud.Rows(0).Item(1).ToString
    '        lbUsuario.Text = dtAud.Rows(0).Item(2).ToString
    '        FlyoutUsuario.BorderColor = Color.FromArgb(&HC0, 0, 0)
    '        FlyoutUsuario.Content = PanelUsuario
    '    End If
    'End Sub

    'Private Sub BBtn_Usuario_Click(sender As Object, e As ClickEventArgs) Handles BBtn_Usuario.Click
    '    FlyoutUsuario_PrepareContent(BubbleBar5, e)
    'End Sub

    Private Sub JGr_Buscador_SelectionChanged(sender As Object, e As EventArgs) Handles JGr_Buscador.SelectionChanged
        If JGr_Buscador.Row >= 0 Then
            _Pos = JGr_Buscador.Row
            _PMostrarRegistro(_Pos)
        End If
    End Sub

End Class