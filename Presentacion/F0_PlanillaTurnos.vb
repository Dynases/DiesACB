Imports DevComponents.DotNetBar
Imports Logica.AccesoLogica
Imports Janus.Windows.GridEX

Public Class F0_PlanillaTurnos
#Region "VARIABLES LOCALES"
    Public _MPos As Integer
    Public _MNuevo As Boolean
    Public _MModificar As Boolean

#End Region


#Region "METODOS PRIVADOS"

    Public Sub _prIniciarTodo()

        Me.Text = "´c o n t r o l    d e    a s i s t e n c i a".ToUpper

        'Txt_NombreUsu.Text = P_Global.gs_Usuario
        'Txt_NombreUsu.ReadOnly = True

        btnNuevo.Visible = False
        btnImprimir.Visible = False
        btnModificar.Enabled = True
        btnEliminar.Visible = False
        btnGrabar.Enabled = False
        tbFecha.Enabled = False

        Me.WindowState = FormWindowState.Maximized

        _prCargarComboLibreria(tbTipo, gi_LibPERSONAL, gi_LibPERSTipo)

        _prCargarGridPlanilla()

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

        If dt.Rows.Count > 0 Then
            mCombo.SelectedIndex = 0
        End If
    End Sub

    Private Sub _prHabilitar()
        tbFecha.Enabled = True
        btnModificar.Enabled = False
        btnGrabar.Enabled = True

        'inhabilitar
        tbTipo.Enabled = False
    End Sub

    Private Sub _prInabilitar()
        tbFecha.Enabled = False
        btnModificar.Enabled = True
        btnGrabar.Enabled = False

        tbTipo.Enabled = True
    End Sub
    Private Sub _prSalir()
        If btnGrabar.Enabled = True Then
            _prInabilitar()
            _prCargarGridPlanilla()
        Else
            Close()
        End If

    End Sub

    Private Sub _prCargarDatosDT(ByRef dt As DataTable)
        Dim dtDatos As DataTable
        For Each fila As DataRow In dt.Rows
            dtDatos = L_prAsistenciaDatosPorPersonalGeneral(fila.Item("cbnumi"))
            If dtDatos.Rows.Count > 0 Then
                fila.Item(dtDatos.Rows(0).Item("piturno").ToString) = 1
            End If

        Next
    End Sub

    Private Sub _prCargarGridPlanilla()
        Dim dt As New DataTable
        dt = L_prAsistenciaEstructuraGeneral()
        Dim dtTurnos As DataTable = L_prTurnoGeneral()

        For Each fila As DataRow In dtTurnos.Rows
            dt.Columns.Add(fila.Item("cnnumi"), Type.GetType("System.Boolean"))
        Next
        dt.Columns.Add("estado", Type.GetType("System.Int32"))

        For Each fila As DataRow In dt.Rows
            For Each fila1 As DataRow In dtTurnos.Rows
                fila.Item(fila1.Item("cnnumi").ToString) = 0
            Next
            fila.Item("estado") = 0
        Next

        'cargar los datos que ya estan grabados en la planilla
        _prCargarDatosDT(dt)

        grPlanilla.DataSource = dt
        grPlanilla.RetrieveStructure()

        'dar formato a las columnas
        With grPlanilla.RootTable.Columns("cbnumi")
            .Caption = "cod".ToUpper
            .Width = 50
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .CellStyle.BackColor = Color.AliceBlue
        End With

        With grPlanilla.RootTable.Columns("cbdesc")
            .Caption = "NOMBRE"
            .Width = 250
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.BackColor = Color.AliceBlue
        End With
        With grPlanilla.RootTable.Columns("ultFecha")
            .Caption = "ult. Turno".ToUpper
            .Width = 100
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .CellStyle.BackColor = Color.AliceBlue
        End With

        For Each fila1 As DataRow In dtTurnos.Rows
            With grPlanilla.RootTable.Columns(fila1.Item("cnnumi").ToString)
                .Caption = fila1.Item("cnobs").ToString
                .Width = 100
                .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            End With
        Next
        With grPlanilla.RootTable.Columns("estado")
            .Visible = False
        End With
        With grPlanilla.RootTable.Columns("patipo")
            .Visible = False
        End With

        Dim fc As GridEXFormatCondition
        fc = New GridEXFormatCondition(grPlanilla.RootTable.Columns("estado"), ConditionOperator.Equal, 1)
        fc.FormatStyle.BackColor = Color.LightGreen
        grPlanilla.RootTable.FormatConditions.Add(fc)

        'Habilitar Filtradores
        With grPlanilla
            '.DefaultFilterRowComparison = FilterConditionOperator.Contains
            '.FilterMode = FilterMode.Automatic
            '.FilterRowUpdateMode = FilterRowUpdateMode.WhenValueChanges
            .GroupByBoxVisible = False
            'diseño de la grilla
            .VisualStyle = VisualStyle.Office2007
        End With

        'aplico el filtro de tipo de personal
        grPlanilla.RemoveFilters()
        grPlanilla.RootTable.ApplyFilter(New Janus.Windows.GridEX.GridEXFilterCondition(grPlanilla.RootTable.Columns("patipo"), Janus.Windows.GridEX.ConditionOperator.Equal, tbTipo.Value))
    End Sub

    Private Sub _prGrabar()
        tbFecha.Focus()
        Dim dt As DataTable = CType(grPlanilla.DataSource, DataTable)
        Dim dtReg As New DataTable
        dtReg.Columns.Add("picper")
        dtReg.Columns.Add("pifdoc")
        dtReg.Columns.Add("piturno")

        For i = 0 To dt.Rows.Count - 1
            If dt.Rows(i).Item("estado") = 1 Then
                Dim numiTurno As Integer = getTurno(i, dt)

                If numiTurno > 0 Then
                    dtReg.Rows.Add(dt.Rows(i).Item("cbnumi"), tbFecha.Value.ToString("yyyy-MM-dd"), numiTurno)
                Else
                    ToastNotification.Show(Me, "Seleccione algun turno del personal: ".ToUpper + dt.Rows(i).Item("cbdesc"), My.Resources.WARNING, 4000, eToastGlowColor.Red, eToastPosition.TopCenter)
                    Exit Sub
                End If
            End If
        Next
        Dim res As Boolean = L_prAsistenciaGrabarTabla(dtReg)
        If res Then
            ToastNotification.Show(Me, "grabacion de planilla con exito".ToUpper, My.Resources.GRABACION_EXITOSA, 4000, eToastGlowColor.Red, eToastPosition.TopCenter)
            _prSalir()
        End If

    End Sub

    Private Function getTurno(fila As Integer, dt As DataTable) As Integer
        For i = 2 To dt.Columns.Count - 2
            If dt.Rows(fila).Item(i).ToString = "True" Then
                Return Int(dt.Columns(i).ColumnName)
            End If
        Next
        Return -1
    End Function

#End Region

    Private Sub F0_PlanillaTurnos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _prIniciarTodo()
    End Sub

    Private Sub btnGrabar_Click(sender As Object, e As EventArgs) Handles btnGrabar.Click
        _prGrabar()
    End Sub

    Private Sub grPlanilla_CellEdited(sender As Object, e As ColumnActionEventArgs) Handles grPlanilla.CellEdited
        If grPlanilla.Row >= 0 Then
            'If e.Column.Index >= 2 And e.Column.Index <= grPlanilla. - 2 Then
            '    grPlanilla.SetValue("estado", 1)
            'End If
            grPlanilla.SetValue("estado", 1)
        End If
    End Sub

    Private Sub grPlanilla_EditingCell(sender As Object, e As EditingCellEventArgs) Handles grPlanilla.EditingCell
        If btnGrabar.Enabled = True Then
            If e.Column.Index < 3 Then
                e.Cancel = True
            End If
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        _prHabilitar()
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        _prSalir()
    End Sub

    Private Sub tbTipo_ValueChanged(sender As Object, e As EventArgs) Handles tbTipo.ValueChanged

        If IsNothing(grPlanilla.DataSource) = False Then
            grPlanilla.RemoveFilters()
            grPlanilla.RootTable.ApplyFilter(New Janus.Windows.GridEX.GridEXFilterCondition(grPlanilla.RootTable.Columns("patipo"), Janus.Windows.GridEX.ConditionOperator.Equal, tbTipo.Value))
        End If

    End Sub
End Class