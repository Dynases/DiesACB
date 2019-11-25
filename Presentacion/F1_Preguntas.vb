Imports Logica.AccesoLogica
Imports DevComponents.DotNetBar

Public Class F1_Preguntas
    Public _nameButton As String

#Region "METODOS PRIVADOS"
    Private Sub _prIniciarTodo()
        L_prAbrirConexion(gs_Ip, gs_UsuarioSql, gs_ClaveSql, gs_NombreBD)

        Me.Text = "P R E G U N T A S"
        _prCargarComboCategoria()
        CargarComboExamen()
        _PMIniciarTodo()

        _prAsignarPermisos()
        With JGrM_Buscador.RootTable.Columns("enval")
            .FormatString = "0.00"

        End With


    End Sub
    Private Sub CargarComboExamen()
        tbTipo.Items.Clear()
        tbTipo.Items.Add("EVALUACION TEORICA")
        tbTipo.Items.Add("EVALUACION CONOCIMIENTOS MECANICA")
        tbTipo.Items.Add("EVALUACION EN PISTA O CIRCUITO")
        tbTipo.Items.Add("EVALUACION EN VIA PUBLICA")
        
    End Sub
    Public Function ObtenerValorTipo() As Integer
        Select Case tbTipo.SelectedItem.ToString
            
            Case "EVALUACION TEORICA"
                Return 1
            Case "EVALUACION CONOCIMIENTOS MECANICA"
                Return 2
            Case "EVALUACION EN PISTA O CIRCUITO"
                Return 3
            Case "EVALUACION EN VIA PUBLICA"
                Return 4
        End Select
        Return -1
        'If (tbTipo.SelectedItem.ToString = "EXAMEN TEORICO") Then
        '    Return 1
        'Else
        '    If (tbTipo.SelectedItem.ToString = "EXAMEN PRACTICO") Then
        '        Return 2
        '    Else
        '        Return -1
        '    End If
        'End If
    End Function
    Private Sub _prCargarComboCategoria()
        Dim dt As New DataTable
        dt = L_prCategoriaCombo()

        With tbCat 
            .DropDownList.Columns.Clear()

            .DropDownList.Columns.Add("cenum").Width = 70
            .DropDownList.Columns("cenum").Caption = "COD"

            .DropDownList.Columns.Add("cedesc1").Width = 200
            .DropDownList.Columns("cedesc1").Caption = "CATEGORIA".ToUpper

            .ValueMember = "cenum"
            .DisplayMember = "cedesc1"
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

        tbDesc.ReadOnly = False
        tbTipo.Enabled = True
        tbCat.ReadOnly = False
        tbPonderacion.Enabled = True


    End Sub
    Public Overrides Sub _PMOInhabilitar()
        tbDesc.ReadOnly = True
        tbNumi.ReadOnly = True
        tbTipo.Enabled = False
        tbCat.ReadOnly = True
        tbPonderacion.Enabled = False

    End Sub
    Public Overrides Sub _PMOHabilitarFocus()
        With MHighlighterFocus
            .SetHighlightOnFocus(tbDesc, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
            .SetHighlightOnFocus(tbTipo, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
            .SetHighlightOnFocus(tbCat, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
            .SetHighlightOnFocus(tbPonderacion, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
        End With
    End Sub
    Public Overrides Sub _PMOLimpiar()
        tbDesc.Text = ""
        tbNumi.Text = ""
        tbPonderacion.Text = ""
        tbCat.SelectedIndex = 0
        tbTipo.SelectedIndex = 0

    End Sub
    Public Overrides Sub _PMOLimpiarErrores()

        MEP.Clear()
        tbDesc.BackColor = Color.White
        tbTipo.BackColor = Color.White
        tbCat.BackColor = Color.White
        tbPonderacion.BackColor = Color.White
    End Sub
    Public Overrides Function _PMOValidarCampos() As Boolean
        Dim _ok As Boolean = True
        MEP.Clear()

        If tbDesc.Text = String.Empty Then
            tbDesc.BackColor = Color.Red
            MEP.SetError(tbDesc, "ingrese la descripcion del examen!".ToUpper)
            _ok = False
        Else
            tbDesc.BackColor = Color.White
            MEP.SetError(tbDesc, "")
        End If
        If tbPonderacion.Text = String.Empty Then
            tbPonderacion.BackColor = Color.Red
            MEP.SetError(tbPonderacion, "ingrese ponderacion del examen!".ToUpper)
            _ok = False
        Else
            tbPonderacion.BackColor = Color.White
            MEP.SetError(tbPonderacion, "")
        End If
        

        If tbTipo.SelectedIndex < 0 Then
            tbTipo.BackColor = Color.Red
            MEP.SetError(tbTipo, "seleccione el tipo del Examen!".ToUpper)
            _ok = False
        Else
            tbTipo.BackColor = Color.White
            MEP.SetError(tbTipo, "")
        End If

        If tbCat.SelectedIndex < 0 Then
            tbCat.BackColor = Color.Red
            MEP.SetError(tbCat, "seleccione la categoria!".ToUpper)
            _ok = False
        Else
            tbCat.BackColor = Color.White
            MEP.SetError(tbCat, "")
        End If

        MHighlighterFocus.UpdateHighlights()
        Return _ok
    End Function
    Public Overrides Function _PMOGetListEstructuraBuscador() As List(Of Modelos.Celda)
        Dim listEstCeldas As New List(Of Modelos.Celda)
        listEstCeldas.Add(New Modelos.Celda("ennumi", True, "ID", 70))
        listEstCeldas.Add(New Modelos.Celda("entipo", False, "TIPO", 70))
        listEstCeldas.Add(New Modelos.Celda("endesc", True, "DESCRIPCION", 700))
        listEstCeldas.Add(New Modelos.Celda("enlic", False, "CATEGORIA", 100))
        listEstCeldas.Add(New Modelos.Celda("enval", True, "PONDERACION", 100))
        listEstCeldas.Add(New Modelos.Celda("enfact", False))
        listEstCeldas.Add(New Modelos.Celda("enhact", False))
        listEstCeldas.Add(New Modelos.Celda("enuact", False))
        listEstCeldas.Add(New Modelos.Celda("cedesc1", True, "CATEGORIA", 100))
        listEstCeldas.Add(New Modelos.Celda("tipo", True, "TIPO DE EXAMEN", 200))
        Return listEstCeldas

    End Function
    Public Overrides Function _PMOGetTablaBuscador() As DataTable
        Dim dtBuscador As DataTable = L_prPreguntasGeneral()

        Return dtBuscador
    End Function
    Public Overrides Sub _PMOMostrarRegistro(_N As Integer)
        JGrM_Buscador.Row = _MPos

        With JGrM_Buscador
            tbNumi.Text = .GetValue("ennumi").ToString
            tbCat.Text = .GetValue("cedesc1")
            tbDesc.Text = .GetValue("endesc").ToString
            tbPonderacion.Text = .GetValue("enval").ToString

            tbDesc.Text = .GetValue("endesc").ToString

            lbFecha.Text = CType(.GetValue("enfact"), Date).ToString("dd/MM/yyyy")
            lbHora.Text = .GetValue("enhact").ToString
            lbUsuario.Text = .GetValue("enuact").ToString

        End With
        _prSeleccionarCategoria(JGrM_Buscador.GetValue("enlic"))
        Dim tipo As Integer = JGrM_Buscador.GetValue("entipo")
        tbTipo.SelectedIndex = tipo - 1
        'If (tipo = 1) Then
        '    tbTipo.SelectedIndex = 0
        'Else
        '    If (tipo = 2) Then
        '        tbTipo.SelectedIndex = 1

        '    End If
        'End If
        LblPaginacion.Text = Str(_MPos + 1) + "/" + JGrM_Buscador.RowCount.ToString
    End Sub
    Public Sub _prSeleccionarCategoria(_cenum As Integer)
        Dim length As Integer = CType(tbCat.DataSource, DataTable).Rows.Count
        For i As Integer = 0 To length Step 1
            Dim cenum As Integer = CType(tbCat.DataSource, DataTable).Rows(i).Item("cenum")
            If (_cenum = cenum) Then
                tbCat.SelectedIndex = i
                Return
            End If

        Next

    End Sub

    Public Overrides Function _PMOGrabarRegistro() As Boolean
        Dim a As Integer = 0
        Dim b As Integer = ObtenerValorTipo()
        Dim c As Integer = tbCat.Value
        Dim d As String = Convert.ToDouble(tbPonderacion.Value)
        Dim res As Boolean = L_prPreguntasGrabar(a, tbDesc.Text, b, c, d)
        If res Then
            ToastNotification.Show(Me, "Codigo de Preguntas ".ToUpper + tbNumi.Text + " Grabado con Exito.".ToUpper, My.Resources.GRABACION_EXITOSA, 5000, eToastGlowColor.Green, eToastPosition.TopCenter)
            tbDesc.Focus()
        End If
        Return res

    End Function
    Public Overrides Function _PMOModificarRegistro() As Boolean
        Dim a As Integer = 0
        Dim b As Integer = ObtenerValorTipo()
        Dim c As Integer = tbCat.Value
        Dim d As String = Convert.ToDouble(tbPonderacion.Value)
        Dim res As Boolean = L_prPreguntasModificar(tbNumi.Text, tbDesc.Text, b, c, d)
        If res Then
            ToastNotification.Show(Me, "Codigo de Preguntas ".ToUpper + tbNumi.Text + " Modificado con Exito.".ToUpper, My.Resources.GRABACION_EXITOSA, 5000, eToastGlowColor.Green, eToastPosition.TopCenter)
            tbDesc.Focus()
        End If
        Return res
    End Function
    Public Overrides Sub _PMOEliminarRegistro()
        Dim info As New TaskDialogInfo("¿esta seguro de eliminar el registro?".ToUpper, eTaskDialogIcon.Delete, "advertencia".ToUpper, "mensaje principal".ToUpper, eTaskDialogButton.Yes Or eTaskDialogButton.Cancel, eTaskDialogBackgroundColor.Blue)
        Dim result As eTaskDialogResult = TaskDialog.Show(info)
        If result = eTaskDialogResult.Yes Then
            Dim mensajeError As String = ""
            Dim res As Boolean = L_prPreguntasBorrar(tbNumi.Text, mensajeError)
            If res Then
                ToastNotification.Show(Me, "Codigo de equipo ".ToUpper + tbNumi.Text + " eliminado con Exito.".ToUpper, My.Resources.GRABACION_EXITOSA, 5000, eToastGlowColor.Green, eToastPosition.TopCenter)
                _PMFiltrar()
            Else
                ToastNotification.Show(Me, mensajeError, My.Resources.WARNING, 8000, eToastGlowColor.Red, eToastPosition.TopCenter)
            End If
        End If
    End Sub
#End Region



    Private Sub F1_Preguntas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _prIniciarTodo()

    End Sub
    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        tbDesc.Focus()
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        tbDesc.Focus()
    End Sub

    Private Sub tbDesc_TextChanged(sender As Object, e As EventArgs) Handles tbDesc.TextChanged

    End Sub
End Class