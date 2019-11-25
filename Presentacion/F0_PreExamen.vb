Imports Logica.AccesoLogica
Imports Janus.Windows.GridEX
Imports DevComponents.DotNetBar

Public Class F0_PreExamen
#Region "ATRIBUTOS"
    Dim _asignar As Boolean
    Dim _modificar As Boolean
#End Region

#Region "METODOS"
    Private Sub _prIniciarTodo()
        btnImprimir.Visible = False
        Me.Text = "p r e    e x a m e n".ToUpper
        Me.WindowState = FormWindowState.Maximized
        SuperTabPrincipal.SelectedTabIndex = 0

        PanelInfo.Visible = False
        btnGrabar.Enabled = False
        tbFecha.Enabled = False

        _prCargarComboEstados()

        _prCargarGridAsignados()

        PanelFecha.Visible = False

    End Sub

    Private Sub _prCargarComboEstados()

        Dim dtEstados As New DataTable
        dtEstados.Columns.Add("estado")

        dtEstados.Rows.Clear()
        dtEstados.Rows.Add("PROGRAMADO")
        dtEstados.Rows.Add("APROBADO")
        dtEstados.Rows.Add("REPROBADO")
        dtEstados.Rows.Add("FALTA")
        dtEstados.Rows.Add("PERMISO")

        With tbEstados
            .DropDownList.Columns.Clear()

            .DropDownList.Columns.Add("estado").Width = 150
            .DropDownList.Columns("estado").Caption = "ESTADO"

            .ValueMember = "estado"
            .DisplayMember = "estado"
            .DataSource = dtEstados
            .Refresh()
        End With


    End Sub
    Private Sub _prCargarGridAsignados()

        Dim dtGrid As DataTable = L_prPreExamenGeneral()
        grAsignacion.DataSource = dtGrid
        grAsignacion.RetrieveStructure()

        'dar formato a las columnas
        With grAsignacion.RootTable.Columns("ejnumi")
            .Visible = False
        End With

        With grAsignacion.RootTable.Columns("ejalum")
            .Caption = "COD. ALUM".ToUpper
            .Width = 80
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        End With

        With grAsignacion.RootTable.Columns("cbnom2")
            .Caption = "alumno".ToUpper
            .Width = 300
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
        End With

        With grAsignacion.RootTable.Columns("ejfecha")
            .Caption = "fecha".ToUpper
            .Width = 80
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        End With

        With grAsignacion.RootTable.Columns("ejestado")
            .Visible = False
        End With

        With grAsignacion.RootTable.Columns("ejestado2")
            .DropDown = tbEstados.DropDownList
            .EditType = EditType.MultiColumnDropDown
            .Caption = "estado".ToUpper
            .Width = 150
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
        End With

        With grAsignacion.RootTable.Columns("ejchof")
            .Caption = "COD. inst".ToUpper
            .Width = 80
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        End With

        With grAsignacion.RootTable.Columns("panom2")
            .Caption = "instructor".ToUpper
            .Width = 300
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
        End With

        With grAsignacion.RootTable.Columns("ejnota")
            .Caption = "NOTA".ToUpper
            .Width = 80
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        End With

        With grAsignacion.RootTable.Columns("ckeck")
            .Visible = False
            .Caption = "si/no".ToUpper
            .Width = 50
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        End With

        With grAsignacion.RootTable.Columns("ejuact")
            .Visible = False
        End With

        With grAsignacion.RootTable.Columns("ejhact")
            .Visible = False
        End With

        With grAsignacion.RootTable.Columns("ejfact")
            .Visible = False
        End With

        With grAsignacion.RootTable.Columns("estado")
            .Visible = False
        End With

        With grAsignacion.RootTable.Columns("tieneNota")
            .Visible = False
        End With

        'Habilitar Filtradores
        With grAsignacion
            .DefaultFilterRowComparison = FilterConditionOperator.Contains
            .FilterMode = FilterMode.Automatic
            .FilterRowUpdateMode = FilterRowUpdateMode.WhenValueChanges
            .GroupByBoxVisible = False
            .VisualStyle = VisualStyle.Office2007
        End With

        Dim fc As GridEXFormatCondition
        fc = New GridEXFormatCondition(grAsignacion.RootTable.Columns("ejestado"), ConditionOperator.Equal, 1)
        fc.FormatStyle.BackColor = Color.LightGreen
        grAsignacion.RootTable.FormatConditions.Add(fc)

        fc = New GridEXFormatCondition(grAsignacion.RootTable.Columns("ejestado"), ConditionOperator.Equal, 2)
        fc.FormatStyle.BackColor = Color.OrangeRed
        grAsignacion.RootTable.FormatConditions.Add(fc)

        fc = New GridEXFormatCondition(grAsignacion.RootTable.Columns("ejestado"), ConditionOperator.Equal, 3)
        fc.FormatStyle.BackColor = Color.LightGray
        grAsignacion.RootTable.FormatConditions.Add(fc)

        fc = New GridEXFormatCondition(grAsignacion.RootTable.Columns("ejestado"), ConditionOperator.Equal, 4)
        fc.FormatStyle.BackColor = Color.LightYellow
        grAsignacion.RootTable.FormatConditions.Add(fc)

        fc = New GridEXFormatCondition(grAsignacion.RootTable.Columns("tieneNota"), ConditionOperator.Equal, 1)
        fc.FormatStyle.FontBold = TriState.True
        grAsignacion.RootTable.FormatConditions.Add(fc)

    End Sub

    Private Sub _prCargarGridAsignacion()


        Dim dtGrid As DataTable = L_prPreExamenAprovadosHastaFechaGeneral(tbFecha.Value.ToString("yyyy/MM/dd"))
        grAsignacion.DataSource = dtGrid
        grAsignacion.RetrieveStructure()

        'dar formato a las columnas
        With grAsignacion.RootTable.Columns("ejnumi")
            .Visible = False
        End With

        With grAsignacion.RootTable.Columns("ejalum")
            .Caption = "COD. ALUM".ToUpper
            .Width = 80
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        End With

        With grAsignacion.RootTable.Columns("cbnom2")
            .Caption = "alumno".ToUpper
            .Width = 300
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
        End With

        With grAsignacion.RootTable.Columns("ejfecha")
            .Caption = "fecha".ToUpper
            .Width = 80
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        End With

        With grAsignacion.RootTable.Columns("ejestado")
            .Visible = False
        End With

        With grAsignacion.RootTable.Columns("ejchof")
            .Caption = "COD. inst".ToUpper
            .Width = 80
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        End With

        With grAsignacion.RootTable.Columns("panom2")
            .Caption = "instructor".ToUpper
            .Width = 300
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
        End With

        With grAsignacion.RootTable.Columns("ejnota")
            .Visible = False
        End With

        With grAsignacion.RootTable.Columns("ckeck")
            .Caption = "si/no".ToUpper
            .Width = 50
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        End With

        With grAsignacion.RootTable.Columns("ejuact")
            .Visible = False
        End With

        With grAsignacion.RootTable.Columns("ejhact")
            .Visible = False
        End With

        With grAsignacion.RootTable.Columns("ejfact")
            .Visible = False
        End With

        With grAsignacion.RootTable.Columns("estado")
            .Visible = False
        End With
        'Habilitar Filtradores
        With grAsignacion
            .DefaultFilterRowComparison = FilterConditionOperator.Contains
            .FilterMode = FilterMode.None
            .FilterRowUpdateMode = FilterRowUpdateMode.WhenValueChanges
            .GroupByBoxVisible = False
            .VisualStyle = VisualStyle.Office2007
        End With

        'pongo el menu
        'grHorario.ContextMenuStrip = msOpsHorario

    End Sub

    Private Sub _prSalir()
        If btnGrabar.Enabled = True Then
            btnGrabar.Enabled = False
            btnModificar.Enabled = True
            btnAsignar.Enabled = True
            PanelInfo.Visible = False
            PanelFecha.Visible = False
            _prCargarGridAsignados()
            btnNotas.Enabled = True

        Else
            Me.Close()
        End If
    End Sub

    Private Sub _prAsignar()
        _asignar = True
        _modificar = False

        btnGrabar.Enabled = True
        PanelInfo.Visible = True
        btnAsignar.Enabled = False
        tbFecha.Value = Now.Date
        tbFecha.Enabled = True
        _prCargarGridAsignacion()

        PanelFecha.Visible = True
        btnModificar.Enabled = False

        btnNotas.Enabled = False
    End Sub

    Private Sub _prGrabarAsignados()
        tbFecha.Focus()

        Dim dtRegistros As DataTable
        dtRegistros = CType(grAsignacion.DataSource, DataTable).DefaultView.ToTable(True, "ejnumi", "ejalum", "ejfecha", "ejestado", "ejchof", "ejnota", "ejfact", "ejhact", "ejuact", "estado")
        Dim resp As Boolean = L_prPreExamenGrabarAsignados(dtRegistros)
        If resp Then
            ToastNotification.Show(Me, "Se registro exitosamente".ToUpper, My.Resources.GRABACION_EXITOSA, 5000, eToastGlowColor.Green, eToastPosition.TopCenter)
            btnGrabar.Enabled = False
            btnAsignar.Enabled = True
            btnModificar.Enabled = True
            PanelInfo.Visible = False
            PanelFecha.Visible = False
            _prCargarGridAsignados()

            btnNotas.Enabled = True
        End If

    End Sub

    Private Sub _prGrabarModificion()
        tbFecha.Focus()

        Dim dtRegistros As DataTable
        dtRegistros = CType(grAsignacion.DataSource, DataTable).DefaultView.ToTable(True, "ejnumi", "ejalum", "ejfecha", "ejestado", "ejchof", "ejnota", "ejfact", "ejhact", "ejuact", "estado")
        Dim resp As Boolean = L_prPreExamenModificar(dtRegistros)
        If resp Then
            ToastNotification.Show(Me, "Se modifico exitosamente".ToUpper, My.Resources.GRABACION_EXITOSA, 5000, eToastGlowColor.Green, eToastPosition.TopCenter)
            btnGrabar.Enabled = False
            btnAsignar.Enabled = True
            btnModificar.Enabled = True
            PanelInfo.Visible = False
            _prCargarGridAsignados()
            btnNotas.Enabled = True
        End If

    End Sub

    Private Sub _prModificar()
        btnAsignar.Enabled = False
        btnGrabar.Enabled = True

        btnModificar.Enabled = False
        _modificar = True
        _asignar = False

        btnNotas.Enabled = False


    End Sub

    Private Sub _prSetFecha()
        Dim dt As DataTable = CType(grAsignacion.DataSource, DataTable)
        For Each fila As DataRow In dt.Rows
            fila.Item("ejfecha") = tbFechaP.Value
        Next
    End Sub

    Private Sub _prMarcarTodos()
        Dim dt As DataTable = CType(grAsignacion.DataSource, DataTable)
        For Each fila As DataRow In dt.Rows
            fila.Item("ckeck") = True
            fila.Item("estado") = True
        Next
    End Sub

    Private Sub _prCargarNotas()
        SupTabItemBusqueda.Visible = True
        SupTabItemRegistro.Visible = False
        SuperTabPrincipal.SelectedTabIndex = 1

        tbNumi.Text = grAsignacion.GetValue("ejnumi")
        tbNombre.Text = grAsignacion.GetValue("cbnom2")

        _prCargarGridNotas(grAsignacion.GetValue("ejnumi"))
    End Sub

    Private Sub _prCargarGridNotas(numi As String)


        Dim dtGrid As DataTable = L_prPreExamenDetalleGeneral(numi)
        grPreguntas.DataSource = dtGrid
        grPreguntas.RetrieveStructure()

        'dar formato a las columnas
        With grPreguntas.RootTable.Columns("esnumi")
            .Visible = False
        End With

        With grPreguntas.RootTable.Columns("esnumitce7")
            .Visible = False
        End With

        With grPreguntas.RootTable.Columns("esnumitc51")
            .Visible = False
        End With


        With grPreguntas.RootTable.Columns("cedesc1")
            .Caption = "pregunta".ToUpper
            .Width = 400
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .EditType = EditType.NoEdit
        End With

        With grPreguntas.RootTable.Columns("esnota")
            .Caption = "nota".ToUpper
            .Width = 150
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .FormatString = "0.00"
        End With

        With grPreguntas.RootTable.Columns("estado")
            .Visible = False
        End With


        'Habilitar Filtradores
        With grPreguntas
            .DefaultFilterRowComparison = FilterConditionOperator.Contains
            .FilterMode = FilterMode.None
            .FilterRowUpdateMode = FilterRowUpdateMode.WhenValueChanges
            .GroupByBoxVisible = False
            .VisualStyle = VisualStyle.Office2007
        End With

        'pongo el menu
        'grHorario.ContextMenuStrip = msOpsHorario

    End Sub

    Private Sub _prGrabarNotas()
        Dim dtRegistros As DataTable
        dtRegistros = CType(grPreguntas.DataSource, DataTable).DefaultView.ToTable(True, "esnumi", "esnumitce7", "esnumitc51", "esnota", "estado")
        Dim resp As Boolean = L_prPreExamenNotasGrabar(tbNumi.Text, dtRegistros)
        If resp Then
            ToastNotification.Show(Me, "Se grabo las notas exitosamente".ToUpper, My.Resources.GRABACION_EXITOSA, 5000, eToastGlowColor.Green, eToastPosition.TopCenter)
            SupTabItemRegistro.Visible = True
            SupTabItemBusqueda.Visible = False
            SuperTabPrincipal.SelectedTabIndex = 0
            _prCargarGridAsignados()

        End If
    End Sub
#End Region

    Private Sub F0_PreExamen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _prIniciarTodo()
    End Sub



    Private Sub grAsignacion_KeyDown(sender As Object, e As KeyEventArgs) Handles grAsignacion.KeyDown

        'e.KeyCode = Keys.Control + Keys.Enter
        If e.KeyData = Keys.Control + Keys.Enter And grAsignacion.Row >= 0 Then
            If (grAsignacion.CurrentColumn.Key = "ejchof") Or (grAsignacion.CurrentColumn.Key = "panom2") Then
                'grabar horario
                Dim frmAyuda As Modelos.ModeloAyuda
                Dim dt As DataTable = L_prPersonaAyudaGeneralPorSucursal(gi_userSuc, gi_LibPERSTIPOInstructor)
                Dim listEstCeldas As New List(Of Modelos.Celda)
                listEstCeldas.Add(New Modelos.Celda("panumi", True, "Codigo".ToUpper, 70))
                listEstCeldas.Add(New Modelos.Celda("panom", True, "nombre".ToUpper, 200))
                listEstCeldas.Add(New Modelos.Celda("paape", True, "apellido".ToUpper, 200))
                listEstCeldas.Add(New Modelos.Celda("panom1", True, "Nombre completo".ToUpper, 300))

                frmAyuda = New Modelos.ModeloAyuda(200, 200, dt, "Seleccione el estudiante a quien se programara el horario".ToUpper, listEstCeldas)
                frmAyuda.ShowDialog()

                If frmAyuda.seleccionado = True Then
                    Dim numiInst As String = frmAyuda.filaSelect.Cells("panumi").Value
                    Dim nombreInst As String = frmAyuda.filaSelect.Cells("panom1").Value
                    grAsignacion.SetValue("ejchof", numiInst)
                    grAsignacion.SetValue("panom2", nombreInst)
                    grAsignacion.SetValue("estado", 2)
                End If
            End If

        End If
    End Sub

    Private Sub grAsignacion_EditingCell(sender As Object, e As EditingCellEventArgs) Handles grAsignacion.EditingCell
        If btnGrabar.Enabled = False Then
            e.Cancel = True
        Else
            If e.Column.Key <> "ejfecha" And e.Column.Key <> "ckeck" And e.Column.Key <> "ejestado2" And e.Column.Key <> "ejnota" Then
                e.Cancel = True
            End If

        End If
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        _prSalir()
    End Sub

    Private Sub btnAsignar_Click(sender As Object, e As EventArgs) Handles btnAsignar.Click
        _prAsignar()
    End Sub

    Private Sub btnGrabar_Click(sender As Object, e As EventArgs) Handles btnGrabar.Click
        If _asignar = True Then
            _prGrabarAsignados()
        Else
            If _modificar = True Then
                _prGrabarModificion()
            End If

        End If

    End Sub

    Private Sub grAsignacion_CellEdited(sender As Object, e As ColumnActionEventArgs) Handles grAsignacion.CellEdited


        If e.Column.Key = "ckeck" Then
            Dim check As Boolean = grAsignacion.CurrentRow.Cells("ckeck").Value
            If check Then
                grAsignacion.SetValue("estado", 1)
            Else
                grAsignacion.SetValue("estado", 0)
            End If

        End If

        If e.Column.Key = "ejestado2" Then
            Dim estado As String = grAsignacion.GetValue("ejestado2")
            Dim numiEst As Integer
            Select Case estado
                Case "PROGRAMADO"
                    numiEst = 0
                Case "APROBADO"
                    numiEst = 1
                Case "REPROBADO"
                    numiEst = 2
                Case "FALTA"
                    numiEst = 3
                Case "PERMISO"
                    numiEst = 4

            End Select
            grAsignacion.SetValue("ejestado", numiEst)
        End If

        If _modificar = True Then
            grAsignacion.SetValue("estado", 2)
        End If


    End Sub


    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        _prModificar()
    End Sub

    
    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles tbFechaP.ValueChanged
        _prSetFecha()
    End Sub

    
    Private Sub btMarcarTodos_Click(sender As Object, e As EventArgs) Handles btMarcarTodos.Click
        _prMarcarTodos()
    End Sub

    Private Sub tbFecha_ValueChanged(sender As Object, e As EventArgs) Handles tbFecha.ValueChanged
        _prCargarGridAsignacion()
    End Sub

    Private Sub btnNotas_Click(sender As Object, e As EventArgs) Handles btnNotas.Click
        If grAsignacion.Row >= 0 Then
            _prCargarNotas()
        Else
            ToastNotification.Show(Me, "seleccione a un alumno primeramente".ToUpper, My.Resources.WARNING, 5000, eToastGlowColor.Blue, eToastPosition.TopCenter)

        End If
    End Sub

    Private Sub ButtonX3_Click(sender As Object, e As EventArgs) Handles ButtonX3.Click
        _prGrabarNotas()
        
    End Sub

    Private Sub ButtonX2_Click(sender As Object, e As EventArgs) Handles ButtonX2.Click
        SupTabItemRegistro.Visible = True
        SupTabItemBusqueda.Visible = False
        SuperTabPrincipal.SelectedTabIndex = 0
    End Sub

    Private Sub grPreguntas_CellEdited(sender As Object, e As ColumnActionEventArgs) Handles grPreguntas.CellEdited
        Dim estado As Integer = grPreguntas.GetValue("estado")
        If estado = 1 Then
            grPreguntas.SetValue("estado", 2)
        End If
    End Sub
End Class