Imports Logica.AccesoLogica
Imports DevComponents.DotNetBar

Public Class F1_POLITICA

    Public _nameButton As String

#Region "METODOS PRIVADOS"
    Private Sub _prIniciarTodo()

        Me.Text = "P O L I T I C A S"
        _prCargarComboLibreriaP(cbTipo, gi_LibServicio, gi_LibSERVTipo)



        _PMIniciarTodo()

        _prAsignarPermisos()
        GroupPanelBuscador.Style.BackColor = Color.FromArgb(13, 71, 161)
        GroupPanelBuscador.Style.BackColor2 = Color.FromArgb(13, 71, 161)
        GroupPanelBuscador.Style.TextColor = Color.White
        JGrM_Buscador.RootTable.Columns("cfcuota").TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        JGrM_Buscador.RootTable.Columns("cfcant").TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        JGrM_Buscador.RootTable.Columns("cfnumi").TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        JGrM_Buscador.RootTable.HeaderFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True
        JGrM_Buscador.RootTable.HeaderFormatStyle.FontSize = 10
    
        tbCuota.MaxLength = 10
        tbCantidad.MaxLength = 10
        tbObs.MaxLength = 100
    End Sub

    Public Sub _prCargarComboLibreriaP(mCombo As Janus.Windows.GridEX.EditControls.MultiColumnCombo, cod1 As String, cod2 As String)
        Dim dt As New DataTable
        dt = L_prLibreriaPoliticaComboGeneral(cod1, cod2)

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
    Public Sub _prCargarComboServicio(mCombo As Janus.Windows.GridEX.EditControls.MultiColumnCombo, _value As Integer)
        Dim dt As New DataTable
        dt = L_prServiciosTabla(_value)
        'ednumi ,edcod ,eddesc ,edprec ,edtipo ,edest ,edfact ,edhact ,eduact 
        With mCombo
            .DropDownList.Columns.Clear()

            .DropDownList.Columns.Add("ednumi").Width = 70
            .DropDownList.Columns("ednumi").Caption = "COD"

            .DropDownList.Columns.Add("eddesc").Width = 300
            .DropDownList.Columns("eddesc").Caption = "DESCRIPCION"


            .DropDownList.Columns.Add("edprec").Width = 100
            .DropDownList.Columns("edprec").Caption = "PRECIOS"

            .ValueMember = "ednumi"
            .DisplayMember = "eddesc"
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
#End Region
#Region "METODOS SOBREESCRITOS"
    Public Overrides Sub _PMOHabilitar()
 
        cbTipo.ReadOnly = False
        cbServicios.ReadOnly = False
        tbCuota.ReadOnly = False
        tbCantidad.ReadOnly = False
        tbDesc.ReadOnly = False
        tbObs.ReadOnly = False
        JGrM_Buscador.RootTable.Columns("cfcuota").TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        JGrM_Buscador.RootTable.Columns("cfcant").TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        JGrM_Buscador.RootTable.Columns("cfnumi").TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        JGrM_Buscador.RootTable.HeaderFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True
        JGrM_Buscador.RootTable.HeaderFormatStyle.FontSize = 10

        cbTipo.Focus()


    End Sub
    Public Overrides Sub _PMOInhabilitar()
        tbNumi.ReadOnly = True
        cbTipo.ReadOnly = True
        tbCuota.ReadOnly = True
        tbCantidad.ReadOnly = True
        tbDesc.ReadOnly = True
        tbObs.ReadOnly = True
        cbServicios.ReadOnly = True
        JGrM_Buscador.RootTable.Columns("cfcuota").TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        JGrM_Buscador.RootTable.Columns("cfcant").TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        JGrM_Buscador.RootTable.Columns("cfnumi").TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        JGrM_Buscador.RootTable.HeaderFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True
        JGrM_Buscador.RootTable.HeaderFormatStyle.FontSize = 10


    End Sub
    Public Overrides Sub _PMOHabilitarFocus()
        With MHighlighterFocus
            .SetHighlightOnFocus(cbTipo, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
            .SetHighlightOnFocus(tbCuota, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
            .SetHighlightOnFocus(tbCantidad, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
            .SetHighlightOnFocus(tbDesc, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
            .SetHighlightOnFocus(tbObs, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
        End With
    End Sub
    Public Overrides Sub _PMOLimpiar()
      
        cbTipo.SelectedIndex = -1
        cbServicios.SelectedIndex = -1
        tbCuota.Text = ""
        tbCantidad.Text = ""
        tbDesc.Text = ""
        tbObs.Text = ""
        tbNumi.Text = ""

        JGrM_Buscador.RootTable.Columns("cfcuota").TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        JGrM_Buscador.RootTable.Columns("cfcant").TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        JGrM_Buscador.RootTable.Columns("cfnumi").TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        JGrM_Buscador.RootTable.HeaderFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True
        JGrM_Buscador.RootTable.HeaderFormatStyle.FontSize = 10

        cbTipo.Focus()


    End Sub
    Public Overrides Sub _PMOLimpiarErrores()

        MEP.Clear()
        cbTipo.BackColor = Color.White
        tbCuota.BackColor = Color.White
        tbCantidad.BackColor = Color.White
        tbDesc.BackColor = Color.White
        tbObs.BackColor = Color.White

    End Sub
    Public Overrides Function _PMOValidarCampos() As Boolean
        Dim _ok As Boolean = True
        MEP.Clear()

        If cbTipo.SelectedIndex < 0 Then
            cbTipo.BackColor = Color.Red
            MEP.SetError(cbTipo, "Seleccione un Tipos!".ToUpper)
            _ok = False
        Else
            cbTipo.BackColor = Color.White
            MEP.SetError(cbTipo, "")
        End If

        If cbServicios.SelectedIndex < 0 Then
            cbServicios.BackColor = Color.Red
            MEP.SetError(cbServicios, "Seleccione un Tipos!".ToUpper)
            _ok = False
        Else
            cbServicios.BackColor = Color.White
            MEP.SetError(cbServicios, "")
        End If
        If tbCuota.Text = String.Empty Then
            tbCuota.BackColor = Color.Red
            MEP.SetError(tbCuota, "ingrese la Cuota!".ToUpper)
            _ok = False
        Else
            tbCuota.BackColor = Color.White
            MEP.SetError(tbCuota, "")
        End If


        If tbCantidad.Text = String.Empty Then
            tbCantidad.BackColor = Color.Red
            MEP.SetError(tbCantidad, "Ingrese una Cantidad!".ToUpper)
            _ok = False
        Else
            tbCantidad.BackColor = Color.White
            MEP.SetError(tbCantidad, "")
        End If

        If tbDesc.Text = String.Empty Then
            tbDesc.BackColor = Color.Red
            MEP.SetError(tbDesc, "seleccione la descripcion!".ToUpper)
            _ok = False
        Else
            tbDesc.BackColor = Color.White
            MEP.SetError(tbDesc, "")
        End If

        MHighlighterFocus.UpdateHighlights()
        Return _ok
    End Function
    Public Overrides Function _PMOGetListEstructuraBuscador() As List(Of Modelos.Celda)
        Dim listEstCeldas As New List(Of Modelos.Celda)
        '      t.cfnumi,t.cftipo,b.cedesc1 as tipo,t.cfcuota ,t.cfcant ,t.cfdesc ,t.cfobs,t.cftce4ser ,c.eddesc  
        ',t.cffact ,t.cfhact ,t.cfuact 
      
        listEstCeldas.Add(New Modelos.Celda("cfnumi", True, "ID", 70))
        listEstCeldas.Add(New Modelos.Celda("cftipo", False))
        listEstCeldas.Add(New Modelos.Celda("tipo", True, "TIPO", 150))
        listEstCeldas.Add(New Modelos.Celda("cfcuota", True, "CUOTA", 130))
        listEstCeldas.Add(New Modelos.Celda("cfcant", True, "CANTIDAD", 130))
        listEstCeldas.Add(New Modelos.Celda("cfdesc", True, "DESCUENTO (%)", 200))
        listEstCeldas.Add(New Modelos.Celda("cfobs", True, "OBSERVACION", 400))
        listEstCeldas.Add(New Modelos.Celda("cftce4ser", False))
        listEstCeldas.Add(New Modelos.Celda("eddesc", True, "SERVICIO", 250))
        listEstCeldas.Add(New Modelos.Celda("cffact", False))
        listEstCeldas.Add(New Modelos.Celda("cfhact", False))
        listEstCeldas.Add(New Modelos.Celda("cfuact", False))
        Return listEstCeldas

    End Function
    Public Overrides Function _PMOGetTablaBuscador() As DataTable
        Dim dtBuscador As DataTable = L_prLibreriaPoliticaGeneral(gi_LibServicio, gi_LibSERVTipo)
        Return dtBuscador
    End Function
    Public Overrides Sub _PMOMostrarRegistro(_N As Integer)
        JGrM_Buscador.Row = _MPos

        With JGrM_Buscador

            tbNumi.Text = .GetValue("cfnumi").ToString
            cbTipo.Value = .GetValue("cftipo")
            cbServicios.Value = .GetValue("cftce4ser")
            tbCuota.Text = .GetValue("cfcuota").ToString
            tbCantidad.Text = .GetValue("cfcant").ToString
            tbDesc.Text = .GetValue("cfdesc")
            tbObs.Text = .GetValue("cfobs").ToString

            lbFecha.Text = CType(.GetValue("cffact"), Date).ToString("dd/MM/yyyy")
            lbHora.Text = .GetValue("cfhact").ToString
            lbUsuario.Text = .GetValue("cfuact").ToString

        End With
        JGrM_Buscador.RootTable.Columns("cfcuota").TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        JGrM_Buscador.RootTable.Columns("cfcant").TextAlignment = Janus.Windows.GridEX.TextAlignment.Center

        JGrM_Buscador.Focus()

        LblPaginacion.Text = Str(_MPos + 1) + "/" + JGrM_Buscador.RowCount.ToString
    End Sub


    Public Overrides Function _PMOGrabarRegistro() As Boolean

        Dim res As Boolean = L_prPoliticaGrabar(tbNumi.Text, cbTipo.Value, tbCuota.Text, tbCantidad.Text, tbDesc.Text, tbObs.Text, cbServicios.Value)
        If res Then
            ToastNotification.Show(Me, "Codigo de Politica ".ToUpper + tbNumi.Text + " Grabado con Exito.".ToUpper, My.Resources.GRABACION_EXITOSA, 5000, eToastGlowColor.Green, eToastPosition.TopCenter)
            cbTipo.Focus()
        End If
        Return res

    End Function
    Public Overrides Function _PMOModificarRegistro() As Boolean
   
        Dim res As Boolean = L_prPoliticaModificar(tbNumi.Text, cbTipo.Value, tbCuota.Text, tbCantidad.Text, tbDesc.Text, tbObs.Text,
                                                   cbServicios .Value )
        If res Then
            ToastNotification.Show(Me, "Codigo de Politica ".ToUpper + tbNumi.Text + " Modificado con Exito.".ToUpper, My.Resources.GRABACION_EXITOSA, 5000, eToastGlowColor.Green, eToastPosition.TopCenter)
            cbTipo.Focus()
        End If
        Return res
    End Function
    Public Overrides Sub _PMOEliminarRegistro()
        Dim info As New TaskDialogInfo("¿esta seguro de eliminar el registro?".ToUpper, eTaskDialogIcon.Delete, "advertencia".ToUpper, "mensaje principal".ToUpper, eTaskDialogButton.Yes Or eTaskDialogButton.Cancel, eTaskDialogBackgroundColor.Blue)
        Dim result As eTaskDialogResult = TaskDialog.Show(info)
        If result = eTaskDialogResult.Yes Then
            Dim mensajeError As String = ""
            Dim res As Boolean = L_prPoliticaBorrar(tbNumi.Text, mensajeError)
            If res Then
                ToastNotification.Show(Me, "Codigo de Politica ".ToUpper + tbNumi.Text + " eliminado con Exito.".ToUpper, My.Resources.GRABACION_EXITOSA, 5000, eToastGlowColor.Green, eToastPosition.TopCenter)
                _PMFiltrar()
            Else
                ToastNotification.Show(Me, mensajeError, My.Resources.WARNING, 8000, eToastGlowColor.Red, eToastPosition.TopCenter)
            End If
        End If
    End Sub
#End Region



    Private Sub F1_POLITICA_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _prIniciarTodo()

    End Sub

   
    Private Sub tbCuota_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbCuota.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSymbol(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsWhiteSpace(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If

        tbCuota.Text = Trim(Replace(tbCuota.Text, "  ", " "))
        tbCuota.Select(tbCuota.Text.Length, 0)
    End Sub

   
    Private Sub cbTipo_ValueChanged(sender As Object, e As EventArgs) Handles cbTipo.ValueChanged
        Dim selected As Integer = cbTipo.SelectedIndex
        If (selected >= 0) Then
            Dim value As Integer = cbTipo.Value
            cbServicios.Text = ""
            _prCargarComboServicio(cbServicios, value)
        End If
    End Sub
End Class