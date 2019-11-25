Imports Logica.AccesoLogica
Imports DevComponents.DotNetBar
Imports DevComponents.Editors.DateTimeAdv

'DESARROLLADO POR: DANNY GUTIERREZ
Public Class F1_Feriado

    Public _nameButton As String

#Region "METODOS PRIVADOS"
    Private Sub _prIniciarTodo()
        Me.Text = "F E R I A D O S"

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

    Private Sub _PCargarFeriadosAlCalendario()
        Dim dtFechas As DataTable = L_prFeriadoGeneral()

        For i = 0 To dtFechas.Rows.Count - 1
            Dim fecha As DateTime = dtFechas.Rows(i).Item("pfflib")
            Dim desc As String = dtFechas.Rows(i).Item("pfdes")

            Dim dia As DayLabel = Calendario.GetDay(fecha)
            If Not dia Is Nothing Then
                dia.Image = My.Resources.Resources.FERIADO
                dia.ImageAlign = eLabelPartAlignment.MiddleRight
                dia.TextAlign = eLabelPartAlignment.MiddleLeft
                dia.Tooltip = "Click en la imagen para ver la descripcion"

                dia.SubItems.Add(New ButtonItem("Descripcion", desc))

                dia.BackgroundStyle.BackColor = Color.OrangeRed
            End If
        Next
    End Sub
#End Region

#Region "METODOS SOBRECARGADOS"
    Public Overrides Sub _PMOHabilitar()
        tbDesc.ReadOnly = False
        tbFecha.Enabled = True

    End Sub

    Public Overrides Sub _PMOInhabilitar()
        tbNumi.ReadOnly = True
        tbDesc.ReadOnly = True
        tbFecha.Enabled = False
        _PCargarFeriadosAlCalendario()
    End Sub

    Public Overrides Sub _PMOLimpiar()
        tbDesc.Text = ""
        tbNumi.Text = ""
        tbFecha.Value = Now.Date
        _PCargarFeriadosAlCalendario()
    End Sub

    Public Overrides Sub _PMOLimpiarErrores()
        MEP.Clear()
        tbDesc.BackColor = Color.White
        tbFecha.BackColor = Color.White
    End Sub

    Public Overrides Function _PMOGrabarRegistro() As Boolean
        Dim res As Boolean = L_prFeriadoGrabar(tbNumi.Text, tbFecha.Value.ToString("yyyy/MM/dd"), tbDesc.Text)
        If res Then
            ToastNotification.Show(Me, "Codigo de feriado ".ToUpper + tbNumi.Text + " Grabado con Exito.".ToUpper, My.Resources.GRABACION_EXITOSA, 5000, eToastGlowColor.Green, eToastPosition.TopCenter)
        End If
        Return res

    End Function

    Public Overrides Function _PMOModificarRegistro() As Boolean
        Dim res As Boolean = L_prFeriadoModificar(tbNumi.Text, tbFecha.Value.ToString("yyyy/MM/dd"), tbDesc.Text)
        If res Then
            ToastNotification.Show(Me, "Codigo de feriado ".ToUpper + tbNumi.Text + " modificado con Exito.".ToUpper, My.Resources.GRABACION_EXITOSA, 5000, eToastGlowColor.Green, eToastPosition.TopCenter)
        End If
        Return res
    End Function

    Public Overrides Sub _PMOEliminarRegistro()
        Dim info As New TaskDialogInfo("¿esta seguro de eliminar el registro?".ToUpper, eTaskDialogIcon.Delete, "advertencia".ToUpper, "mensaje principal".ToUpper, eTaskDialogButton.Yes Or eTaskDialogButton.Cancel, eTaskDialogBackgroundColor.Blue)
        Dim result As eTaskDialogResult = TaskDialog.Show(info)
        If result = eTaskDialogResult.Yes Then
            Dim mensajeError As String = ""
            Dim res As Boolean = L_prFeriadoBorrar(tbNumi.Text, mensajeError)
            If res Then
                ToastNotification.Show(Me, "Codigo de feriado ".ToUpper + tbNumi.Text + " eliminado con Exito.".ToUpper, My.Resources.GRABACION_EXITOSA, 5000, eToastGlowColor.Green, eToastPosition.TopCenter)
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
            MEP.SetError(tbDesc, "ingrese la descripcion del feriado!".ToUpper)
            _ok = False
        Else
            tbDesc.BackColor = Color.White
            MEP.SetError(tbDesc, "")
        End If

        MHighlighterFocus.UpdateHighlights()
        Return _ok
    End Function

    Public Overrides Function _PMOGetTablaBuscador() As DataTable
        Dim dtBuscador As DataTable = L_prFeriadoGeneral()
        Return dtBuscador
    End Function

    Public Overrides Function _PMOGetListEstructuraBuscador() As List(Of Modelos.Celda)
        Dim listEstCeldas As New List(Of Modelos.Celda)
        listEstCeldas.Add(New Modelos.Celda("pfnumi", True, "COD", 70))
        listEstCeldas.Add(New Modelos.Celda("pfflib", True, "FECHA", 70))
        listEstCeldas.Add(New Modelos.Celda("pfdes", True, "DESCRIPCION", 200))
        listEstCeldas.Add(New Modelos.Celda("pffact", False))
        listEstCeldas.Add(New Modelos.Celda("pfhact", False))
        listEstCeldas.Add(New Modelos.Celda("pfuact", False))
        Return listEstCeldas
    End Function

    Public Overrides Sub _PMOMostrarRegistro(_N As Integer)
        JGrM_Buscador.Row = _MPos

        With JGrM_Buscador
            tbNumi.Text = .GetValue("pfnumi").ToString
            tbFecha.Value = .GetValue("pfflib")
            tbDesc.Text = .GetValue("pfdes").ToString

            lbFecha.Text = CType(.GetValue("pffact"), Date).ToString("dd/MM/yyyy")
            lbHora.Text = .GetValue("pfhact").ToString
            lbUsuario.Text = .GetValue("pfuact").ToString

        End With

        LblPaginacion.Text = Str(_MPos + 1) + "/" + JGrM_Buscador.RowCount.ToString

    End Sub
    Public Overrides Sub _PMOHabilitarFocus()
        With MHighlighterFocus
            .SetHighlightOnFocus(tbDesc, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
            .SetHighlightOnFocus(tbFecha, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
        End With

    End Sub

#End Region


    Private Sub F1_Feriado_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _prIniciarTodo()
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        tbFecha.Focus()
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        tbFecha.Focus()
    End Sub

    Private Sub Calendario_MonthChanged(sender As Object, e As EventArgs) Handles Calendario.MonthChanged
        _PCargarFeriadosAlCalendario()
    End Sub
End Class