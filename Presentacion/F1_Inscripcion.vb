Imports Logica.AccesoLogica
Imports DevComponents.DotNetBar

Public Class F1_Inscripcion
    Public _nameButton As String

#Region "METODOS PRIVADOS"
    Private Sub _prIniciarTodo()
        Me.Text = "INSCRIPCION DE ALUMNOS"
        _prCargarComboAlumno()
        _prCargarComboServicio()

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

    Private Sub _prCargarComboAlumno()
        Dim dt As New DataTable
        dt = L_prAlumnoAyuda(gi_userSuc)

        With tbAlumno
            .DropDownList.Columns.Clear()

            .DropDownList.Columns.Add("cbnumi").Width = 70
            .DropDownList.Columns("cbnumi").Caption = "COD"

            .DropDownList.Columns.Add("cbnom2").Width = 200
            .DropDownList.Columns("cbnom2").Caption = "Nombre completo".ToUpper

            .ValueMember = "cbnumi"
            .DisplayMember = "cbnom2"
            .DataSource = dt
            .Refresh()
        End With
    End Sub

    Private Sub _prCargarComboServicio()
        Dim dt As New DataTable
        dt = L_prServicioEscuelaAyuda()

        With tbServicio
            .DropDownList.Columns.Clear()

            .DropDownList.Columns.Add("ednumi").Width = 70
            .DropDownList.Columns("ednumi").Caption = "COD"

            .DropDownList.Columns.Add("eddesc").Width = 200
            .DropDownList.Columns("eddesc").Caption = "descripcion".ToUpper

            .ValueMember = "ednumi"
            .DisplayMember = "eddesc"
            .DataSource = dt
            .Refresh()
        End With
    End Sub
#End Region

#Region "METODOS SOBRECARGADOS"
    Public Overrides Sub _PMOHabilitar()
        tbAlumno.ReadOnly = False
        tbNroIng.ReadOnly = False
        tbObs.ReadOnly = False
        tbServicio.ReadOnly = False
        tbFecha.Enabled = True
    End Sub

    Public Overrides Sub _PMOInhabilitar()
        tbNumi.ReadOnly = True
        tbAlumno.ReadOnly = True
        tbNroIng.ReadOnly = True
        tbObs.ReadOnly = True
        tbServicio.ReadOnly = True
        tbFecha.Enabled = False
    End Sub

    Public Overrides Sub _PMOLimpiar()
        tbAlumno.Text = ""
        tbNumi.Text = ""
        tbNroIng.Text = ""
        tbObs.Text = ""
        tbServicio.Text = ""
        tbFecha.Value = Now.Date
    End Sub

    Public Overrides Sub _PMOLimpiarErrores()
        MEP.Clear()
        tbAlumno.BackColor = Color.White
        tbNroIng.BackColor = Color.White
        tbObs.BackColor = Color.White
        tbServicio.BackColor = Color.White

    End Sub

    Public Overrides Function _PMOGrabarRegistro() As Boolean
        Dim res As Boolean = L_prInscripcionGrabar(tbNumi.Text, tbAlumno.Value, tbFecha.Value.Date.ToString("yyyy/MM/dd"), tbServicio.Value, tbNroIng.Text, tbObs.Text)
        If res Then
            ToastNotification.Show(Me, "Codigo de inscripcion ".ToUpper + tbNumi.Text + " Grabado con Exito.".ToUpper, My.Resources.GRABACION_EXITOSA, 5000, eToastGlowColor.Green, eToastPosition.TopCenter)
            tbNroIng.Focus()
        End If
        Return res

    End Function

    Public Overrides Function _PMOModificarRegistro() As Boolean
        Dim res As Boolean = L_prInscripcionModificar(tbNumi.Text, tbAlumno.Value, tbFecha.Value.Date.ToString("yyyy/MM/dd"), tbServicio.Value, tbNroIng.Text, tbObs.Text)
        If res Then
            ToastNotification.Show(Me, "Codigo de Inscripcion ".ToUpper + tbNumi.Text + " modificado con Exito.".ToUpper, My.Resources.GRABACION_EXITOSA, 5000, eToastGlowColor.Green, eToastPosition.TopCenter)
        End If
        Return res
    End Function

    Public Overrides Sub _PMOEliminarRegistro()
        Dim info As New TaskDialogInfo("¿esta seguro de eliminar el registro?".ToUpper, eTaskDialogIcon.Delete, "advertencia".ToUpper, "mensaje principal".ToUpper, eTaskDialogButton.Yes Or eTaskDialogButton.Cancel, eTaskDialogBackgroundColor.Blue)
        Dim result As eTaskDialogResult = TaskDialog.Show(info)
        If result = eTaskDialogResult.Yes Then
            Dim mensajeError As String = ""
            Dim res As Boolean = L_prInscripcionBorrar(tbNumi.Text, mensajeError)
            If res Then
                ToastNotification.Show(Me, "Codigo de inscripcion ".ToUpper + tbNumi.Text + " eliminado con Exito.".ToUpper, My.Resources.GRABACION_EXITOSA, 5000, eToastGlowColor.Green, eToastPosition.TopCenter)
                _PMFiltrar()
            Else
                ToastNotification.Show(Me, mensajeError, My.Resources.WARNING, 8000, eToastGlowColor.Red, eToastPosition.TopCenter)
            End If
        End If
    End Sub
    Public Overrides Function _PMOValidarCampos() As Boolean
        Dim _ok As Boolean = True
        MEP.Clear()

        If tbNroIng.Text = String.Empty Then
            tbNroIng.BackColor = Color.Red
            MEP.SetError(tbNroIng, "ingrese el numero de inscripcion!".ToUpper)
            _ok = False
        Else
            tbNroIng.BackColor = Color.White
            MEP.SetError(tbNroIng, "")
        End If

        If tbServicio.SelectedIndex < 0 Then
            tbServicio.BackColor = Color.Red
            MEP.SetError(tbServicio, "seleccione el servicio!".ToUpper)
            _ok = False
        Else
            tbServicio.BackColor = Color.White
            MEP.SetError(tbServicio, "")
        End If

        If tbAlumno.SelectedIndex < 0 Then
            tbAlumno.BackColor = Color.Red
            MEP.SetError(tbAlumno, "seleccione el alumno!".ToUpper)
            _ok = False
        Else
            tbAlumno.BackColor = Color.White
            MEP.SetError(tbAlumno, "")
        End If

        MHighlighterFocus.UpdateHighlights()
        Return _ok
    End Function

    Public Overrides Function _PMOGetTablaBuscador() As DataTable
        Dim dtBuscador As DataTable = L_prInscripcionGeneral()
        Return dtBuscador
    End Function

    Public Overrides Function _PMOGetListEstructuraBuscador() As List(Of Modelos.Celda)
        Dim listEstCeldas As New List(Of Modelos.Celda)
        listEstCeldas.Add(New Modelos.Celda("efnumi", True, "ID", 70))
        listEstCeldas.Add(New Modelos.Celda("efalum", False))
        listEstCeldas.Add(New Modelos.Celda("cbnom2", True, "ALUMNO", 150))
        listEstCeldas.Add(New Modelos.Celda("effech", True, "FECHA", 70))
        listEstCeldas.Add(New Modelos.Celda("efserv", False))
        listEstCeldas.Add(New Modelos.Celda("eddesc", True, "SERVICIO", 150))
        listEstCeldas.Add(New Modelos.Celda("efning", True, "NRO INGRESO", 100))
        listEstCeldas.Add(New Modelos.Celda("efobs", True, "OBSERVACION", 150))
        listEstCeldas.Add(New Modelos.Celda("effact", False))
        listEstCeldas.Add(New Modelos.Celda("efhact", False))
        listEstCeldas.Add(New Modelos.Celda("efuact", False))
        Return listEstCeldas
    End Function

    Public Overrides Sub _PMOMostrarRegistro(_N As Integer)
        JGrM_Buscador.Row = _MPos

        With JGrM_Buscador
            tbNumi.Text = .GetValue("efnumi").ToString
            tbAlumno.Text = .GetValue("cbnom2")
            tbFecha.Value = .GetValue("effech")
            tbServicio.Value = .GetValue("eddesc").ToString
            tbObs.Text = .GetValue("efobs").ToString
            tbNroIng.Text = .GetValue("efning").ToString

            lbFecha.Text = CType(.GetValue("effact"), Date).ToString("dd/MM/yyyy")
            lbHora.Text = .GetValue("efhact").ToString
            lbUsuario.Text = .GetValue("efuact").ToString

        End With

        LblPaginacion.Text = Str(_MPos + 1) + "/" + JGrM_Buscador.RowCount.ToString

    End Sub
    Public Overrides Sub _PMOHabilitarFocus()
        With MHighlighterFocus
            .SetHighlightOnFocus(tbAlumno, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
            .SetHighlightOnFocus(tbFecha, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
            .SetHighlightOnFocus(tbNroIng, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
            .SetHighlightOnFocus(tbObs, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
            .SetHighlightOnFocus(tbServicio, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
        End With

    End Sub

#End Region

    Private Sub F1_Inscripcion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _prIniciarTodo()
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        tbNroIng.Focus()
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        tbNroIng.Focus()
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click

    End Sub
End Class