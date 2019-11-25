Imports Logica.AccesoLogica
Imports DevComponents.DotNetBar

Public Class F1_Horarios

    Public _nameButton As String

#Region "METODOS PRIVADOS"
    Private Sub _prIniciarTodo()
        Me.Text = "H O R A R I O S"

        _PMIniciarTodo()
        _prCargarComboSucursal()
        _prCargarComboLibreria(tbTipo, gi_LibHORARIO, gi_LibHORARIOTipo)

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
    Private Sub _prCargarComboSucursal()
        Dim dt As New DataTable
        dt = L_prSucursalAyuda()

        With tbSuc
            .DropDownList.Columns.Clear()

            .DropDownList.Columns.Add("canumi").Width = 70
            .DropDownList.Columns("canumi").Caption = "COD"

            .DropDownList.Columns.Add("cadesc").Width = 200
            .DropDownList.Columns("cadesc").Caption = "descripcion".ToUpper

            .ValueMember = "canumi"
            .DisplayMember = "cadesc"
            .DataSource = dt
            .Refresh()
        End With
    End Sub
    Private Sub _prCargarGridDetalle(idCabecera As String)
        Dim dt As New DataTable
        dt = L_prHoraDetGeneral(idCabecera)

        grDetalle.DataSource = dt

        'dar formato a las columnas
        With grDetalle.Columns("cclinea")
            .Width = 50
            .Visible = False
        End With

        With grDetalle.Columns("ccnumi")
            .Width = 60
            .Visible = False
        End With

        With grDetalle.Columns("cchora")
            .HeaderText = "HORA"
            .Width = 70
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        End With

        With grDetalle.Columns("estado")
            .ReadOnly = True
            .Visible = False
        End With

        With grDetalle
            .AllowUserToAddRows = False
            .ContextMenuStrip = cmOpciones
        End With


    End Sub
#End Region

#Region "METODOS SOBRECARGADOS"
    Public Overrides Sub _PMOHabilitar()
        tbObs.ReadOnly = False
        tbSuc.ReadOnly = False
        tbTipo.ReadOnly = False
        tbFecha.Enabled = True

        grDetalle.Enabled = True
        grDetalle.AllowUserToAddRows = True
    End Sub

    Public Overrides Sub _PMOInhabilitar()
        tbNumi.ReadOnly = True
        tbObs.ReadOnly = True
        tbTipo.ReadOnly = True
        tbFecha.Enabled = False
        tbSuc.ReadOnly = True

        grDetalle.Enabled = False
    End Sub

    Public Overrides Sub _PMOLimpiar()
        tbObs.Text = ""
        tbNumi.Text = ""
        tbFecha.Value = Now.Date
        tbSuc.Text = ""
        tbTipo.Text = ""

        'VACIO EL DETALLE
        _prCargarGridDetalle(-1)
        grDetalle.AllowUserToAddRows = True
    End Sub

    Public Overrides Sub _PMOLimpiarErrores()
        MEP.Clear()
        tbObs.BackColor = Color.White
        tbFecha.BackColor = Color.White
        tbSuc.BackColor = Color.White
        tbTipo.BackColor = Color.White
    End Sub

    Public Overrides Function _PMOGrabarRegistro() As Boolean

        Dim res As Boolean = L_prHoraGrabar(tbNumi.Text, tbFecha.Value.ToString("yyyy/MM/dd"), tbObs.Text, tbSuc.Value, tbTipo.Value, CType(grDetalle.DataSource, DataTable))
        If res Then
            ToastNotification.Show(Me, "Codigo de horario ".ToUpper + tbNumi.Text + " Grabado con Exito.".ToUpper, My.Resources.GRABACION_EXITOSA, 5000, eToastGlowColor.Green, eToastPosition.TopCenter)
            tbFecha.Focus()
        End If
        Return res

    End Function

    Public Overrides Function _PMOModificarRegistro() As Boolean
       
        Dim res As Boolean = L_prHoraModificar(tbNumi.Text, tbFecha.Value.ToString("yyyy/MM/dd"), tbObs.Text, tbSuc.Value, tbTipo.Value, CType(grDetalle.DataSource, DataTable))
        If res Then
            ToastNotification.Show(Me, "Codigo de horario ".ToUpper + tbNumi.Text + " modificado con Exito.".ToUpper, My.Resources.GRABACION_EXITOSA, 5000, eToastGlowColor.Green, eToastPosition.TopCenter)
        End If
        Return res
    End Function

    Public Overrides Sub _PMOEliminarRegistro()
        Dim info As New TaskDialogInfo("¿esta seguro de eliminar el registro?".ToUpper, eTaskDialogIcon.Delete, "advertencia".ToUpper, "mensaje principal".ToUpper, eTaskDialogButton.Yes Or eTaskDialogButton.Cancel, eTaskDialogBackgroundColor.Blue)
        Dim result As eTaskDialogResult = TaskDialog.Show(info)
        If result = eTaskDialogResult.Yes Then
            Dim mensajeError As String = ""
            Dim res As Boolean = L_prHoraBorrar(tbNumi.Text, mensajeError)
            If res Then
                ToastNotification.Show(Me, "Codigo de horario ".ToUpper + tbNumi.Text + " eliminado con Exito.".ToUpper, My.Resources.GRABACION_EXITOSA, 5000, eToastGlowColor.Green, eToastPosition.TopCenter)
                _PMFiltrar()
            Else
                ToastNotification.Show(Me, mensajeError, My.Resources.WARNING, 8000, eToastGlowColor.Red, eToastPosition.TopCenter)
            End If
        End If
    End Sub
    Public Overrides Function _PMOValidarCampos() As Boolean
        Dim _ok As Boolean = True
        MEP.Clear()

        If tbObs.Text = String.Empty Then
            tbObs.BackColor = Color.Red
            MEP.SetError(tbObs, "ingrese la observacion del horario!".ToUpper)
            _ok = False
        Else
            tbObs.BackColor = Color.White
            MEP.SetError(tbObs, "")
        End If


        If tbSuc.SelectedIndex < 0 Then
            tbSuc.BackColor = Color.Red
            MEP.SetError(tbSuc, "seleccione la sucursal del horario!".ToUpper)
            _ok = False
        Else
            tbSuc.BackColor = Color.White
            MEP.SetError(tbSuc, "")
        End If

        If tbTipo.SelectedIndex < 0 Then
            tbTipo.BackColor = Color.Red
            MEP.SetError(tbTipo, "seleccione el tipo del horario!".ToUpper)
            _ok = False
        Else
            tbTipo.BackColor = Color.White
            MEP.SetError(tbTipo, "")
        End If

        MHighlighterFocus.UpdateHighlights()
        Return _ok
    End Function

    Public Overrides Function _PMOGetTablaBuscador() As DataTable
        Dim dtBuscador As DataTable = L_prHoraGeneral()
        Return dtBuscador
    End Function

    Public Overrides Function _PMOGetListEstructuraBuscador() As List(Of Modelos.Celda)
        Dim listEstCeldas As New List(Of Modelos.Celda)
        listEstCeldas.Add(New Modelos.Celda("cbnumi", True, "ID", 70))
        listEstCeldas.Add(New Modelos.Celda("cbfecha", True, "FECHA", 100))
        listEstCeldas.Add(New Modelos.Celda("cbobs", True, "OBSERVACION", 200))
        listEstCeldas.Add(New Modelos.Celda("cbsuc", False))
        listEstCeldas.Add(New Modelos.Celda("cadesc", True, "SUCURSAL", 200))
        listEstCeldas.Add(New Modelos.Celda("cbtipo", False))
        listEstCeldas.Add(New Modelos.Celda("cbtipo2", True, "TIPO", 150))
        listEstCeldas.Add(New Modelos.Celda("cbfact", False))
        listEstCeldas.Add(New Modelos.Celda("cbhact", False))
        listEstCeldas.Add(New Modelos.Celda("cbuact", False))
        Return listEstCeldas
    End Function

    Public Overrides Sub _PMOMostrarRegistro(_N As Integer)
        JGrM_Buscador.Row = _MPos

        With JGrM_Buscador
            tbNumi.Text = .GetValue("cbnumi").ToString
            tbObs.Text = .GetValue("cbobs").ToString
            'tbSuc.Text = .GetValue("cadesc").ToString.Trim
            tbSuc.Value = .GetValue("cbsuc")
            tbFecha.Value = .GetValue("cbfecha")
            tbTipo.Value = .GetValue("cbtipo")

            lbFecha.Text = CType(.GetValue("cbfact"), Date).ToString("dd/MM/yyyy")
            lbHora.Text = .GetValue("cbhact").ToString
            lbUsuario.Text = .GetValue("cbuact").ToString

            'CARGAR DETALLE
            _prCargarGridDetalle(tbNumi.Text)
        End With

        LblPaginacion.Text = Str(_MPos + 1) + "/" + JGrM_Buscador.RowCount.ToString

    End Sub
    Public Overrides Sub _PMOHabilitarFocus()
        With MHighlighterFocus
            .SetHighlightOnFocus(tbObs, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
            .SetHighlightOnFocus(tbFecha, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
            .SetHighlightOnFocus(tbSuc, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
            .SetHighlightOnFocus(tbTipo, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
        End With

    End Sub

#End Region

    Private Sub F1_Horarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _prIniciarTodo()
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        tbFecha.Focus()
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        tbFecha.Focus()
    End Sub

    Private Sub ELIMINARFILAToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ELIMINARFILAToolStripMenuItem.Click
        Dim pos As Integer = grDetalle.CurrentRow.Index
        If pos >= 0 And pos <= grDetalle.RowCount - 2 Then
            'grDetalle.Rows.RemoveAt(pos)
            CType(grDetalle.DataSource, DataTable).Rows.RemoveAt(pos)
        End If
    End Sub

    Private Sub grDetalle_DefaultValuesNeeded(sender As Object, e As DataGridViewRowEventArgs) Handles grDetalle.DefaultValuesNeeded
        With e.Row
            .Cells("estado").Value = 0
        End With
    End Sub
End Class