Imports Logica.AccesoLogica
Imports DevComponents.DotNetBar


'DESARROLLADO POR: DANNY GUTIERREZ
Public Class F1_Equipo
    Public _nameButton As String

#Region "METODOS PRIVADOS"
    Private Sub _prIniciarTodo()
        Me.Text = "E Q U I P O S"
        _prCargarComboLibreria(tbTipo, gi_LibEquipo, gi_LibEQUITipo)
        _prCargarComboSucursal()
        '_prCargarComboPersona()

        btNuevoTipo.Visible = False

        _PMIniciarTodo()

        _prAsignarPermisos()
    End Sub

    Private Sub _prCargarComboPersona()
        Dim dt As New DataTable

        If tbSuc.SelectedIndex >= 0 Then
            dt = L_prPersonaAyudaGeneralPorSucursal(tbSuc.Value, gi_LibPERSTIPOInstructor)
        Else
            dt = L_prPersonaAyudaGeneralPorSucursal(-1, gi_LibPERSTIPOInstructor)
        End If

        With tbPersona
            .DropDownList.Columns.Clear()

            .DropDownList.Columns.Add("panumi").Width = 70
            .DropDownList.Columns("panumi").Caption = "COD"

            .DropDownList.Columns.Add("panom1").Width = 200
            .DropDownList.Columns("panom1").Caption = "NOMBRE COMPLETO"

            .ValueMember = "panumi"
            .DisplayMember = "panom1"
            .DataSource = dt
            .Refresh()
        End With
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

        If gb_userTodasSuc = False Then
            tbSuc.Enabled = False
        End If
    End Sub
#End Region

#Region "METODOS SOBRECARGADOS"
    Public Overrides Sub _PMOHabilitar()
        tbDesc.ReadOnly = False
        tbTipo.ReadOnly = False
        tbCodigo.ReadOnly = False
        tbEstado.IsReadOnly = False
        tbSuc.ReadOnly = False
        tbPersona.ReadOnly = False
    End Sub

    Public Overrides Sub _PMOInhabilitar()
        tbNumi.ReadOnly = True
        tbDesc.ReadOnly = True
        tbCodigo.ReadOnly = True
        tbTipo.ReadOnly = True
        tbEstado.IsReadOnly = True
        tbSuc.ReadOnly = True
        tbPersona.ReadOnly = True
    End Sub

    Public Overrides Sub _PMOLimpiar()
        tbDesc.Text = ""
        tbNumi.Text = ""
        tbCodigo.Text = ""
        tbTipo.Text = ""
        tbEstado.Value = True
        tbSuc.Value = gi_userSuc
        tbPersona.Text = ""
    End Sub

    Public Overrides Sub _PMOLimpiarErrores()
        MEP.Clear()
        tbDesc.BackColor = Color.White
        tbEstado.BackColor = Color.White
        tbTipo.BackColor = Color.White
        tbCodigo.BackColor = Color.White
        tbSuc.BackColor = Color.White
        tbPersona.BackColor = Color.White
    End Sub

    Public Overrides Function _PMOGrabarRegistro() As Boolean
        Dim res As Boolean = L_prEquipoGrabar(tbNumi.Text, tbCodigo.Text, tbDesc.Text, tbTipo.Value, IIf(tbEstado.Value = True, 1, 0), tbSuc.Value, tbPersona.Value)
        If res Then
            ToastNotification.Show(Me, "Codigo de equipo ".ToUpper + tbNumi.Text + " Grabado con Exito.".ToUpper, My.Resources.GRABACION_EXITOSA, 5000, eToastGlowColor.Green, eToastPosition.TopCenter)
            tbCodigo.Focus()
        End If
        Return res

    End Function

    Public Overrides Function _PMOModificarRegistro() As Boolean
        Dim res As Boolean = L_prEquipoModificar(tbNumi.Text, tbCodigo.Text, tbDesc.Text, tbTipo.Value, IIf(tbEstado.Value = True, 1, 0), tbSuc.Value, tbPersona.Value)
        If res Then
            ToastNotification.Show(Me, "Codigo de equipo ".ToUpper + tbNumi.Text + " modificado con Exito.".ToUpper, My.Resources.GRABACION_EXITOSA, 5000, eToastGlowColor.Green, eToastPosition.TopCenter)
        End If
        Return res
    End Function

    Public Overrides Sub _PMOEliminarRegistro()
        Dim info As New TaskDialogInfo("¿esta seguro de eliminar el registro?".ToUpper, eTaskDialogIcon.Delete, "advertencia".ToUpper, "mensaje principal".ToUpper, eTaskDialogButton.Yes Or eTaskDialogButton.Cancel, eTaskDialogBackgroundColor.Blue)
        Dim result As eTaskDialogResult = TaskDialog.Show(info)
        If result = eTaskDialogResult.Yes Then
            Dim mensajeError As String = ""
            Dim res As Boolean = L_prEquipoBorrar(tbNumi.Text, mensajeError)
            If res Then
                ToastNotification.Show(Me, "Codigo de equipo ".ToUpper + tbNumi.Text + " eliminado con Exito.".ToUpper, My.Resources.GRABACION_EXITOSA, 5000, eToastGlowColor.Green, eToastPosition.TopCenter)
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
            MEP.SetError(tbDesc, "ingrese la descripcion del equipo!".ToUpper)
            _ok = False
        Else
            tbDesc.BackColor = Color.White
            MEP.SetError(tbDesc, "")
        End If

        If tbCodigo.Text = String.Empty Then
            tbCodigo.BackColor = Color.Red
            MEP.SetError(tbCodigo, "ingrese el codigo del equipo!".ToUpper)
            _ok = False
        Else
            tbCodigo.BackColor = Color.White
            MEP.SetError(tbCodigo, "")
        End If

        If tbTipo.SelectedIndex < 0 Then
            tbTipo.BackColor = Color.Red
            MEP.SetError(tbTipo, "seleccione el tipo del equipo!".ToUpper)
            _ok = False
        Else
            tbTipo.BackColor = Color.White
            MEP.SetError(tbTipo, "")
        End If

        If tbSuc.SelectedIndex < 0 Then
            tbSuc.BackColor = Color.Red
            MEP.SetError(tbSuc, "seleccione la sucursal del equipo!".ToUpper)
            _ok = False
        Else
            tbSuc.BackColor = Color.White
            MEP.SetError(tbSuc, "")
        End If

        If tbPersona.SelectedIndex < 0 Then
            tbPersona.BackColor = Color.Red
            MEP.SetError(tbPersona, "seleccione el responsable del equipo!".ToUpper)
            _ok = False
        Else
            tbPersona.BackColor = Color.White
            MEP.SetError(tbPersona, "")
        End If

        MHighlighterFocus.UpdateHighlights()
        Return _ok
    End Function

    Public Overrides Function _PMOGetTablaBuscador() As DataTable
        Dim numiSuc As String = IIf(gb_userTodasSuc = True, "-1", gi_userSuc)
        Dim dtBuscador As DataTable = L_prEquipoGeneral(numiSuc)
        Return dtBuscador
    End Function

    Public Overrides Function _PMOGetListEstructuraBuscador() As List(Of Modelos.Celda)
        Dim listEstCeldas As New List(Of Modelos.Celda)
        listEstCeldas.Add(New Modelos.Celda("ecnumi", True, "ID", 70))
        listEstCeldas.Add(New Modelos.Celda("eccod", True, "COD", 70))
        listEstCeldas.Add(New Modelos.Celda("ecdesc", True, "DESCRIPCION", 200))
        listEstCeldas.Add(New Modelos.Celda("ectipo", False))
        listEstCeldas.Add(New Modelos.Celda("tipodesc", True, "TIPO", 100))
        listEstCeldas.Add(New Modelos.Celda("ecest", False))
        listEstCeldas.Add(New Modelos.Celda("ecest2", True, "ESTADO", 70))
        listEstCeldas.Add(New Modelos.Celda("ecsuc", False))
        listEstCeldas.Add(New Modelos.Celda("cadesc", True, "SUCURSAL", 150))
        listEstCeldas.Add(New Modelos.Celda("ecper", False))
        listEstCeldas.Add(New Modelos.Celda("panom1", True, "RESPONSABLE", 150))
        listEstCeldas.Add(New Modelos.Celda("ecfact", False))
        listEstCeldas.Add(New Modelos.Celda("echact", False))
        listEstCeldas.Add(New Modelos.Celda("ecuact", False))
        Return listEstCeldas
    End Function

    Public Overrides Sub _PMOMostrarRegistro(_N As Integer)
        JGrM_Buscador.Row = _MPos

        With JGrM_Buscador
            tbNumi.Text = .GetValue("ecnumi").ToString
            tbCodigo.Text = .GetValue("eccod")
            tbDesc.Text = .GetValue("ecdesc").ToString
            tbEstado.Value = .GetValue("ecest").ToString
            tbTipo.Text = .GetValue("tipodesc").ToString
            tbSuc.Text = .GetValue("cadesc").ToString
            tbPersona.Value = .GetValue("panom1").ToString

            lbFecha.Text = CType(.GetValue("ecfact"), Date).ToString("dd/MM/yyyy")
            lbHora.Text = .GetValue("echact").ToString
            lbUsuario.Text = .GetValue("ecuact").ToString

        End With

        LblPaginacion.Text = Str(_MPos + 1) + "/" + JGrM_Buscador.RowCount.ToString

    End Sub
    Public Overrides Sub _PMOHabilitarFocus()
        With MHighlighterFocus
            .SetHighlightOnFocus(tbDesc, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
            .SetHighlightOnFocus(tbCodigo, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
            .SetHighlightOnFocus(tbEstado, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
            .SetHighlightOnFocus(tbTipo, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
            .SetHighlightOnFocus(tbSuc, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
            .SetHighlightOnFocus(tbPersona, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
        End With

    End Sub

#End Region


    Private Sub F1_Equipo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _prIniciarTodo()
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        tbCodigo.Focus()
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        tbCodigo.Focus()
    End Sub

    Private Sub btNuevoTipo_Click(sender As Object, e As EventArgs) Handles btNuevoTipo.Click
        Dim numi As String = ""

        If L_prLibreriaGrabar(numi, gi_LibEquipo, gi_LibEQUITipo, tbTipo.Text, "") Then
            _prCargarComboLibreria(tbTipo, gi_LibEquipo, gi_LibEQUITipo)
            tbTipo.SelectedIndex = CType(tbTipo.DataSource, DataTable).Rows.Count - 1
        End If
    End Sub

    Private Sub tbTipo_ValueChanged(sender As Object, e As EventArgs) Handles tbTipo.ValueChanged
        If tbTipo.SelectedIndex < 0 And tbTipo.Text <> String.Empty Then
            btNuevoTipo.Visible = True
        Else
            btNuevoTipo.Visible = False
        End If
    End Sub

   
    Private Sub tbSuc_ValueChanged(sender As Object, e As EventArgs) Handles tbSuc.ValueChanged
        _prCargarComboPersona()
    End Sub
End Class