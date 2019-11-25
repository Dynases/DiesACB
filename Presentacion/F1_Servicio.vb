Option Strict Off
Imports Logica.AccesoLogica
Imports DevComponents.DotNetBar
Imports Janus.Windows.GridEX

'DESARROLLADO POR: DANNY GUTIERREZ
Public Class F1_Servicio

    Public _nameButton As String
    Private _fDet As Integer
    Private _fDet2 As Integer
    Private _tipoValor As Integer = 3
    Private _edicionCodigo As Boolean = False


#Region "METODOS PRIVADOS"
    Private Sub _prIniciarTodo()
        Me.Text = "S E R V I C I O"
        _prCargarComboLibreria(tbTipo, gi_LibServicio, gi_LibSERVTipo)
        _prCargarComboLibreria2(tbTipoPrecio, gi_LibVEHICULO, gi_LibVEHITam)
        _prCargarComboSucursal(cbsucursal)
        _PMIniciarTodo()

        _prAsignarPermisos()
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

    Private Sub _prCargarComboLibreria(mCombo As Janus.Windows.GridEX.EditControls.MultiColumnCombo, cod1 As String, cod2 As String)
        Dim dt As New DataTable
        dt = L_prLibreriaDetalleGeneral(cod1, cod2)

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
    Private Sub _prCargarComboSucursal(mCombo As Janus.Windows.GridEX.EditControls.MultiColumnCombo)
        Dim dt As New DataTable
        dt = L_prListarSucursales()

        With mCombo
            .DropDownList.Columns.Clear()

            .DropDownList.Columns.Add("canumi").Width = 70
            .DropDownList.Columns("canumi").Caption = "COD"

            .DropDownList.Columns.Add("cadesc").Width = 200
            .DropDownList.Columns("cadesc").Caption = "DESCRIPCION"

            .ValueMember = "canumi"
            .DisplayMember = "cadesc"
            .DataSource = dt
            .Refresh()
        End With
    End Sub
    Private Sub _prCargarComboLibreria2(mCombo As Janus.Windows.GridEX.EditControls.MultiColumnCombo, cod1 As String, cod2 As String)
        Dim dt As New DataTable
        dt = L_prLibreriaDetalleGeneral(cod1, cod2)

        With mCombo
            .DropDownList.Columns.Clear()

            '.DropDownList.Columns.Add("cenum").Width = 70
            '.DropDownList.Columns("cenum").Caption = "COD"

            .DropDownList.Columns.Add("cedesc1").Width = 200
            .DropDownList.Columns("cedesc1").Caption = "DESCRIPCION"

            .ValueMember = "cedesc1"
            .DisplayMember = "cedesc1"
            .DataSource = dt
            .Refresh()
        End With
    End Sub

    Private Sub _prCargarGridDetalle(idCabecera As String)
        Dim dt As New DataTable
        dt = L_prServicioDetalleGeneral(idCabecera)

        grDetalle.DataSource = dt
        grDetalle.RetrieveStructure()

        'dar formato a las columnas
        With grDetalle.RootTable.Columns("eelinea")
            .Width = 50
            .Visible = False
        End With

        With grDetalle.RootTable.Columns("eenumi")
            .Width = 60
            .Visible = False
        End With

        With grDetalle.RootTable.Columns("eeano")
            .Caption = "AÑO"
            .Width = 50
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        End With

        With grDetalle.RootTable.Columns("eemes")
            .Caption = "MES"
            .Width = 50
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        End With

        With grDetalle.RootTable.Columns("eeprecio")
            .Caption = "PRECIO"
            .Width = 100
            .FormatString = "0.00"
            .CellStyle.TextAlignment = TextAlignment.Far
        End With

        With grDetalle.RootTable.Columns("estado")
            .Visible = False
            .DefaultValue = 0
        End With

        With grDetalle
            .GroupByBoxVisible = False
            'diseño de la grilla
            .VisualStyle = VisualStyle.Office2007
            .AllowAddNew = InheritableBoolean.False
            .ContextMenuStrip = cmOpciones
        End With

        Dim fc As GridEXFormatCondition
        fc = New GridEXFormatCondition(grDetalle.RootTable.Columns("estado"), ConditionOperator.Equal, 1)
        fc.FormatStyle.BackColor = Color.LightGreen
        grDetalle.RootTable.FormatConditions.Add(fc)

    End Sub

    Private Sub _prCargarGridPrecios2(numiCab As String)
        Dim dt As New DataTable
        dt = L_prServicioDetallePrecio(numiCab)

        grDetalle2.DataSource = dt
        grDetalle2.RetrieveStructure()

        'dar formato a las columnas
        With grDetalle2.RootTable.Columns("eqnumi")
            .Visible = False
        End With

        With grDetalle2.RootTable.Columns("eqtce4")
            .Visible = False
        End With

        With grDetalle2.RootTable.Columns("eqtip1_4")
            .Caption = "Cod.".ToUpper
            .Visible = False
            .Width = 50
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        End With

        With grDetalle2.RootTable.Columns("cedesc1")
            .Caption = "Tipo".ToUpper
            .Width = 120
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .EditType = EditType.MultiColumnDropDown
            .DropDown = tbTipoPrecio.DropDownList
        End With

        With grDetalle2.RootTable.Columns("eqmes")
            .Caption = "mes".ToUpper
            .Width = 70
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        End With

        With grDetalle2.RootTable.Columns("eqano")
            .Caption = "año".ToUpper
            .Width = 70
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        End With

        With grDetalle2.RootTable.Columns("eqprecio")
            .Caption = "precio".ToUpper
            .Width = 70
            .FormatString = "0.00"
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        End With

        With grDetalle2.RootTable.Columns("estado")
            .Visible = False
            .DefaultValue = 0
        End With

        'Habilitar Filtradores
        With grDetalle2
            '.DefaultFilterRowComparison = FilterConditionOperator.Contains
            '.FilterMode = FilterMode.Automatic
            '.FilterRowUpdateMode = FilterRowUpdateMode.WhenValueChanges
            .GroupByBoxVisible = False
            'diseño de la grilla
            .AllowAddNew = InheritableBoolean.False
            .VisualStyle = VisualStyle.Office2007
        End With

        grDetalle2.ContextMenuStrip = cmOpciones2

        Dim fc As GridEXFormatCondition
        fc = New GridEXFormatCondition(grDetalle2.RootTable.Columns("estado"), ConditionOperator.Equal, 1)
        fc.FormatStyle.BackColor = Color.LightGreen
        grDetalle2.RootTable.FormatConditions.Add(fc)
    End Sub

    Private Sub _prLlenarNumTiposPrecios()
        Dim dt As DataTable = CType(grDetalle2.DataSource, DataTable)
        For Each fila As DataRow In dt.Rows
            Dim dtElem As DataTable = L_prLibreriaDetalleGetNum(gi_LibVEHICULO, gi_LibVEHITam, fila.Item("cedesc1"))
            Dim num As String = dtElem.Rows(0).Item("cenum").ToString.Trim
            fila.Item("eqtip1_4") = num
        Next
    End Sub

#End Region

#Region "METODOS SOBRECARGADOS"
    Public Overrides Sub _PMOHabilitar()
        tbDesc.ReadOnly = False
        tbTipo.ReadOnly = False
        tbCodigo.ReadOnly = False
        tbEstado.IsReadOnly = False
        'tbPrecio.IsInputReadOnly = False
        cbsucursal.ReadOnly = False
        'grDetalle.Enabled = True
        grDetalle.AllowAddNew = InheritableBoolean.True

        'permitir añadir nuevo
        grDetalle2.AllowAddNew = InheritableBoolean.True

        btnElimFila1.Visible = True
        btnEliminar2.Visible = True
    End Sub

    Public Overrides Sub _PMOInhabilitar()
        tbNumi.ReadOnly = True
        tbDesc.ReadOnly = True
        tbCodigo.ReadOnly = True
        tbTipo.ReadOnly = True
        tbEstado.IsReadOnly = True
        tbPrecio.ReadOnly = True

        btnElimFila1.Visible = False
        btnEliminar2.Visible = False
        cbsucursal.ReadOnly = True
        'grDetalle.Enabled = False
    End Sub

    Public Overrides Sub _PMOLimpiar()
        tbDesc.Text = ""
        tbNumi.Text = ""
        tbCodigo.Text = ""
        tbTipo.Text = ""
        tbEstado.Value = True
        tbPrecio.Text = "0"

        'VACIO EL DETALLE
        _prCargarGridDetalle(-1)
        grDetalle.AllowAddNew = InheritableBoolean.True

        _prCargarGridPrecios2(-1)
        grDetalle2.AllowAddNew = InheritableBoolean.True

        gpDetalle1.Visible = True
        gpDetalle2.Visible = False
    End Sub

    Public Overrides Sub _PMOLimpiarErrores()
        MEP.Clear()
        tbDesc.BackColor = Color.White
        tbEstado.BackColor = Color.White
        tbTipo.BackColor = Color.White
        tbCodigo.BackColor = Color.White
        tbPrecio.BackColor = Color.White
        cbsucursal.BackColor = Color.White
    End Sub

    Public Overrides Function _PMOGrabarRegistro() As Boolean
        If grDetalle.RowCount >= 1 Then
            Dim pos As Integer = grDetalle.RowCount - 1
            grDetalle.Row = pos
            tbPrecio.Text = grDetalle.GetValue("eeprecio")
        End If

        _prLlenarNumTiposPrecios()
        Dim dtDetalle2 As DataTable = CType(grDetalle2.DataSource, DataTable).DefaultView.ToTable(True, "eqnumi", "eqtce4", "eqtip1_4", "eqmes", "eqano", "eqprecio", "estado")
        Dim res As Boolean = L_prServicioGrabar(tbNumi.Text, tbCodigo.Text, tbDesc.Text, tbPrecio.Text, tbTipo.Value, IIf(tbEstado.Value = True, 1, 0), CType(grDetalle.DataSource, DataTable), dtDetalle2, cbsucursal.Value)
        If res Then
            ToastNotification.Show(Me, "Codigo de servicio ".ToUpper + tbNumi.Text + " Grabado con Exito.".ToUpper, My.Resources.GRABACION_EXITOSA, 5000, eToastGlowColor.Green, eToastPosition.TopCenter)
            tbCodigo.Focus()
        End If
        Return res

    End Function

    Public Overrides Function _PMOModificarRegistro() As Boolean
        If grDetalle.RowCount >= 1 Then
            Dim pos As Integer = grDetalle.RowCount - 1
            grDetalle.Row = pos
            tbPrecio.Text = grDetalle.GetValue("eeprecio")
        End If

        Dim mensaje As String = String.Empty
        _prLlenarNumTiposPrecios()
        Dim dtDetalle2 As DataTable = CType(grDetalle2.DataSource, DataTable).DefaultView.ToTable(True, "eqnumi", "eqtce4", "eqtip1_4", "eqmes", "eqano", "eqprecio", "estado")
        Dim res As Boolean = L_prServicioModificar(tbNumi.Text, tbCodigo.Text, tbDesc.Text, tbPrecio.Text, tbTipo.Value, IIf(tbEstado.Value = True, 1, 0), CType(grDetalle.DataSource, DataTable), dtDetalle2, mensaje, cbsucursal.Value)
        If res Then
            ToastNotification.Show(Me, "Codigo de servicio ".ToUpper + tbNumi.Text + " modificado con Exito.".ToUpper, My.Resources.GRABACION_EXITOSA, 5000, eToastGlowColor.Green, eToastPosition.TopCenter)
        Else
            If mensaje <> String.Empty Then
                ToastNotification.Show(Me, mensaje, My.Resources.WARNING, 5000, eToastGlowColor.Red, eToastPosition.TopCenter)
            End If
        End If
        Return res
    End Function

    Public Overrides Sub _PMOEliminarRegistro()
        Dim info As New TaskDialogInfo("¿esta seguro de eliminar el registro?".ToUpper, eTaskDialogIcon.Delete, "advertencia".ToUpper, "mensaje principal".ToUpper, eTaskDialogButton.Yes Or eTaskDialogButton.Cancel, eTaskDialogBackgroundColor.Blue)
        Dim result As eTaskDialogResult = TaskDialog.Show(info)
        If result = eTaskDialogResult.Yes Then
            Dim mensajeError As String = ""
            Dim res As Boolean = L_prServicioBorrar(tbNumi.Text, mensajeError)
            If res Then
                ToastNotification.Show(Me, "Codigo de servicio ".ToUpper + tbNumi.Text + " eliminado con Exito.".ToUpper, My.Resources.GRABACION_EXITOSA, 5000, eToastGlowColor.Green, eToastPosition.TopCenter)
                _PMFiltrar()
            Else
                ToastNotification.Show(Me, mensajeError, My.Resources.WARNING, 8000, eToastGlowColor.Red, eToastPosition.TopCenter)
            End If
        End If
    End Sub
    Public Overrides Function _PMOValidarCampos() As Boolean
        Dim _ok As Boolean = True
        MEP.Clear()

        If tbDesc.Text = String.Empty Then
            tbDesc.BackColor = Color.Red
            MEP.SetError(tbDesc, "ingrese la descripcion del servicio!".ToUpper)
            _ok = False
        Else
            tbDesc.BackColor = Color.White
            MEP.SetError(tbDesc, "")
        End If

        If tbCodigo.Text = String.Empty Then
            tbCodigo.BackColor = Color.Red
            MEP.SetError(tbCodigo, "ingrese el codigo del servicio!".ToUpper)
            _ok = False
        Else
            tbCodigo.BackColor = Color.White
            MEP.SetError(tbCodigo, "")
        End If

        If tbTipo.SelectedIndex < 0 Then
            tbTipo.BackColor = Color.Red
            MEP.SetError(tbTipo, "seleccione el tipo del servicio!".ToUpper)
            _ok = False
        Else
            tbTipo.BackColor = Color.White
            MEP.SetError(tbTipo, "")
        End If

        If tbPrecio.Text = String.Empty Then
            tbPrecio.BackColor = Color.Red
            MEP.SetError(tbPrecio, "ingrese el precio del servicio!".ToUpper)
            _ok = False
        Else
            tbPrecio.BackColor = Color.White
            MEP.SetError(tbPrecio, "")
        End If
        If cbsucursal.SelectedIndex < 0 Then
            cbsucursal.BackColor = Color.Red
            MEP.SetError(cbsucursal, "seleccione una sucursal!".ToUpper)
            _ok = False
        Else
            cbsucursal.BackColor = Color.White
            MEP.SetError(cbsucursal, "")
        End If
        MHighlighterFocus.UpdateHighlights()
        Return _ok
    End Function

    Public Overrides Function _PMOGetTablaBuscador() As DataTable
        Dim dtBuscador As DataTable = L_prServicioGeneral()
        Return dtBuscador
    End Function

    Public Overrides Function _PMOGetListEstructuraBuscador() As List(Of Modelos.Celda)
        Dim listEstCeldas As New List(Of Modelos.Celda)
        listEstCeldas.Add(New Modelos.Celda("ednumi", True, "ID", 70))
        listEstCeldas.Add(New Modelos.Celda("edcod", True, "COD", 70))
        listEstCeldas.Add(New Modelos.Celda("eddesc", True, "DESCRIPCION", 300))
        listEstCeldas.Add(New Modelos.Celda("edtipo", False))
        listEstCeldas.Add(New Modelos.Celda("tipodesc", True, "TIPO", 100))
        listEstCeldas.Add(New Modelos.Celda("edest", False))
        listEstCeldas.Add(New Modelos.Celda("edest2", True, "ESTADO", 70))
        listEstCeldas.Add(New Modelos.Celda("edprec", True, "PRECIO", 70, "0.00"))
        listEstCeldas.Add(New Modelos.Celda("edfact", False))
        listEstCeldas.Add(New Modelos.Celda("edhact", False))
        listEstCeldas.Add(New Modelos.Celda("eduact", False))
        listEstCeldas.Add(New Modelos.Celda("edsuc", False))
        listEstCeldas.Add(New Modelos.Celda("sucursal", True, "SUCURSAL", 250))

        Return listEstCeldas
    End Function

    Public Overrides Sub _PMOMostrarRegistro(_N As Integer)
        JGrM_Buscador.Row = _MPos

        With JGrM_Buscador
            tbNumi.Text = .GetValue("ednumi").ToString
            tbCodigo.Text = .GetValue("edcod")
            tbDesc.Text = .GetValue("eddesc").ToString
            tbEstado.Value = .GetValue("edest").ToString
            tbTipo.Text = .GetValue("tipodesc").ToString
            tbPrecio.Text = .GetValue("edprec")
            cbsucursal.Value = .GetValue("edsuc")
            lbFecha.Text = CType(.GetValue("edfact"), Date).ToString("dd/MM/yyyy")
            lbHora.Text = .GetValue("edhact").ToString
            lbUsuario.Text = .GetValue("eduact").ToString

            'CARGAR DETALLE
            If tbTipo.Value = _tipoValor Then
                _prCargarGridPrecios2(tbNumi.Text)
                _prCargarGridDetalle(-1)
                gpDetalle1.Visible = False
                gpDetalle2.Visible = True
            Else
                _prCargarGridDetalle(tbNumi.Text)
                _prCargarGridPrecios2(-1)
                gpDetalle1.Visible = True
                gpDetalle2.Visible = False
            End If
        End With

        LblPaginacion.Text = Str(_MPos + 1) + "/" + JGrM_Buscador.RowCount.ToString

    End Sub
    Public Overrides Sub _PMOHabilitarFocus()
        With MHighlighterFocus
            .SetHighlightOnFocus(tbDesc, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
            .SetHighlightOnFocus(tbCodigo, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
            .SetHighlightOnFocus(tbEstado, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
            .SetHighlightOnFocus(tbTipo, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
            .SetHighlightOnFocus(tbPrecio, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
            .SetHighlightOnFocus(cbsucursal, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
        End With

    End Sub

#End Region

    Private Sub F1_Servicio_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _prIniciarTodo()
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        tbCodigo.Focus()
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        tbCodigo.Focus()
        _fDet = grDetalle.RowCount - 1
        _fDet2 = grDetalle2.RowCount - 1
    End Sub

    Private Sub grDetalle_DefaultValuesNeeded(sender As Object, e As DataGridViewRowEventArgs)
        With e.Row
            .Cells("estado").Value = 0
        End With
    End Sub

    Private Sub grDetalle_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs)
        'Dim estado As Integer
        'estado = grDetalle.Rows(e.RowIndex).Cells("estado").Value
        'If estado = 1 Then
        '    grDetalle.Rows(e.RowIndex).Cells("estado").Value = 2
        'End If
    End Sub

    Private Sub ELIMINARFILAToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles btnElimFila1.Click
        If grDetalle.Row >= 0 Then
            Dim estado As Integer = grDetalle.GetValue("estado")

            If estado = 1 Then
                grDetalle.GetRow(grDetalle.Row).BeginEdit()
                grDetalle.CurrentRow.Cells.Item("estado").Value = -1
            Else
                grDetalle.GetRow(grDetalle.Row).BeginEdit()
                grDetalle.CurrentRow.Cells.Item("estado").Value = -2
            End If

            grDetalle.RemoveFilters()
            grDetalle.RootTable.ApplyFilter(New Janus.Windows.GridEX.GridEXFilterCondition(grDetalle.RootTable.Columns("estado"), Janus.Windows.GridEX.ConditionOperator.GreaterThan, -1))
        End If
    End Sub

    Private Sub MPanelSup_Paint(sender As Object, e As PaintEventArgs) Handles MPanelSup.Paint

    End Sub

    Private Sub btTipo_Click(sender As Object, e As EventArgs) Handles btTipo.Click
        Dim numi As String = ""

        If L_prLibreriaGrabar(numi, gi_LibServicio, gi_LibSERVTipo, tbTipo.Text, "") Then
            _prCargarComboLibreria(tbTipo, gi_LibServicio, gi_LibSERVTipo)
            tbTipo.SelectedIndex = CType(tbTipo.DataSource, DataTable).Rows.Count - 1
        End If
    End Sub

    Private Sub tbTipo_ValueChanged(sender As Object, e As EventArgs) Handles tbTipo.ValueChanged
        If tbTipo.SelectedIndex < 0 And tbTipo.Text <> String.Empty Then
            btTipo.Visible = True
        Else
            btTipo.Visible = False
            If tbTipo.Value = _tipoValor Then
                gpDetalle2.Visible = True
                gpDetalle1.Visible = False
            Else
                gpDetalle2.Visible = False
                gpDetalle1.Visible = True
            End If

        End If
    End Sub

    Private Sub grDetalle_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs)
        If e.RowIndex < _fDet Then
            e.Cancel = True
        End If

    End Sub

    Private Sub grDetalle2_EditingCell(sender As Object, e As EditingCellEventArgs) Handles grDetalle2.EditingCell
        If btnGrabar.Enabled = False Then
            e.Cancel = True
            Exit Sub
        End If

        If e.Column.Key <> "eqmes" And e.Column.Key <> "eqano" And e.Column.Key <> "eqprecio" And e.Column.Key <> "cedesc1" Then
            e.Cancel = True
            Exit Sub
        End If

        If grDetalle2.Row <= _fDet2 And grDetalle2.Row >= 0 Then 'And _edicionCodigo = False
            e.Cancel = True
        End If

    End Sub

    Private Sub grDetalle2_GetNewRow(sender As Object, e As GetNewRowEventArgs) Handles grDetalle2.GetNewRow
        'Dim fila As GridEXRow = CType(e.NewRow, GridEXRow)

    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles btnEliminar2.Click
        If grDetalle2.Row >= 0 Then
            'Dim dt As DataTable = CType(grDetalle2.DataSource, DataTable)
            'dt.Rows(grDetalle2.Row).Item("estado") = -1

            'grDetalle2.GetRow(grDetalle2.Row).BeginEdit()
            'grDetalle2.SetValue(5, -1)
            Dim estado As Integer = grDetalle2.GetValue("estado")

            If estado = 1 Then
                grDetalle2.GetRow(grDetalle2.Row).BeginEdit()
                grDetalle2.CurrentRow.Cells.Item("estado").Value = -1
            Else
                grDetalle2.GetRow(grDetalle2.Row).BeginEdit()
                grDetalle2.CurrentRow.Cells.Item("estado").Value = -2
            End If


            grDetalle2.RemoveFilters()
            grDetalle2.RootTable.ApplyFilter(New Janus.Windows.GridEX.GridEXFilterCondition(grDetalle2.RootTable.Columns("estado"), Janus.Windows.GridEX.ConditionOperator.GreaterThan, -1))
        End If

    End Sub

    Private Sub grDetalle_EditingCell(sender As Object, e As EditingCellEventArgs) Handles grDetalle.EditingCell
        If btnGrabar.Enabled = False Then
            e.Cancel = True
            Exit Sub
        End If

        If e.Column.Key <> "eeano" And e.Column.Key <> "eemes" And e.Column.Key <> "eeprecio" Then
            e.Cancel = True
            Exit Sub
        End If

        If grDetalle.Row <= _fDet And grDetalle.Row >= 0 Then 'And _edicionCodigo = False
            e.Cancel = True
        End If
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click

    End Sub

    Private Sub MultiColumnCombo1_ValueChanged(sender As Object, e As EventArgs) Handles cbsucursal.ValueChanged

    End Sub
End Class