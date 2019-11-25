Imports Logica.AccesoLogica
Imports DevComponents.DotNetBar
Imports Janus.Windows.GridEX

Public Class Pr_ListAlumnAprovb

#Region "Metodos Privados"
    Private Sub _prIniciarTodo()
        _PMIniciarTodo()
        'L_prAbrirConexion(gs_Ip, gs_UsuarioSql, gs_ClaveSql, gs_NombreBD)
        Me.Text = "R E P O R T E  A L U M N O S   A P R O B A D O S"

        MReportViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        _prCargarComboEstado()
        _prCargarComboEscuela()

        _prCargarGridSucursales()

        cbestado.SelectedIndex = 2
        tbEscuela.SelectedIndex = 2
    End Sub

    'Private Sub _prCargarComboSucursal()
    '    Dim dt As New DataTable
    '    dt = L_prSucursalAyuda()
    '    'dt.Rows.Add(0, "SIN SUCURSAL")

    '    With tbSuc
    '        .DropDownList.Columns.Clear()

    '        .DropDownList.Columns.Add("canumi").Width = 70
    '        .DropDownList.Columns("canumi").Caption = "COD"

    '        .DropDownList.Columns.Add("cadesc").Width = 200
    '        .DropDownList.Columns("cadesc").Caption = "descripcion".ToUpper

    '        .ValueMember = "canumi"
    '        .DisplayMember = "cadesc"
    '        .DataSource = dt
    '        .Refresh()
    '    End With



    'End Sub
    Private Sub _prCargarGridSucursales()
        Dim dt As New DataTable
        dt = L_prSucursalAyuda()

        dt.Columns.Add("ok", GetType(Boolean))
        For Each fila As DataRow In dt.Rows
            fila.Item("ok") = False
        Next

        grSucursales.DataSource = dt
        grSucursales.RetrieveStructure()

        'dar formato a las columnas
        With grSucursales.RootTable.Columns("canumi")
            .Caption = "Cod".ToUpper
            .Visible = True
            .Width = 50
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .EditType = EditType.NoEdit
        End With




        With grSucursales.RootTable.Columns("cadesc")
            .Caption = "descripcion".ToUpper
            .Width = 220
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .EditType = EditType.NoEdit

        End With

        With grSucursales.RootTable.Columns("ok")
            .Caption = "ok".ToUpper
            .Visible = True
            .Width = 50
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        End With

        'Habilitar Filtradores
        With grSucursales
            '.DefaultFilterRowComparison = FilterConditionOperator.Contains
            '.FilterMode = FilterMode.Automatic
            '.FilterRowUpdateMode = FilterRowUpdateMode.WhenValueChanges
            .GroupByBoxVisible = False

            'diseño de la grilla
            .VisualStyle = VisualStyle.Office2007
        End With
        grSucursales.SelectionMode = SelectionMode.MultipleSelection

    End Sub


    Public Function ObtenerValorEstado() As Integer
        If (cbestado.SelectedItem.ToString = "APROBADO") Then
            Return 2
        Else
            If (cbestado.SelectedItem.ToString = "REPROBADO") Then
                Return 3
            Else
                Return -1
            End If
        End If
    End Function

    Public Function ObtenerValorEscuela() As Integer
        If (tbEscuela.SelectedItem.ToString = "SI") Then
            Return 1
        Else
            If (tbEscuela.SelectedItem.ToString = "NO") Then
                Return 0
            Else
                Return -1
            End If
        End If
    End Function

    Public Sub GenerarNro(ByRef _dt As DataTable)
        Dim length As Integer = _dt.Rows.Count
        Dim j As Integer = 1
        Dim i As Integer
        For i = 0 To length - 1 Step 1
            _dt.Rows(i).Item("NRO") = j
            If "REPROBADO" = _dt.Rows(i).Item("estado") Then
                Exit For
            End If
            j = j + 1
        Next
        j = 1
        For i = i To length - 1 Step 1
            _dt.Rows(i).Item("NRO") = j
            j = j + 1

        Next

    End Sub

    Public Sub GenerarNro2(ByRef _dt As DataTable)
        Dim length As Integer = _dt.Rows.Count
        Dim j As Integer = 1
        Dim i As Integer
        For i = 0 To length - 1 Step 1
            _dt.Rows(i).Item("NRO") = j
            j = j + 1
        Next


    End Sub
    Private Function _prSucursalSeleccionada() As Boolean
        Dim dt As DataTable = CType(grSucursales.DataSource, DataTable)
        For Each fila As DataRow In dt.Rows
            If fila.Item("ok") = True Then
                Return True
            End If
        Next
        Return False
    End Function
    Private Sub _prCargarReporte()
        tbFecha.Focus()
        Dim _dt As New DataTable
        If (ObtenerValorEstado() > 0) Then
            'Dim fecha As String = Str(tbFecha.Value.Year) + "-" + Str(tbFecha.Value.Month) + "-" + Str(tbFecha.Value.Day)
            Dim fecha As String = tbFecha.Value.ToString("yyyy/MM/dd")

            '_dt = L_prPreAlumnosResporteAprobados(tbFecha.Value.ToString, ObtenerValorEstado)
            _dt = L_prPreAlumnosResporteAprobados(tbFecha.Value.ToString("yyyy/MM/dd"), ObtenerValorEstado, ObtenerValorEscuela)

            If _prSucursalSeleccionada() = False Then
                ToastNotification.Show(Me, "seleccione sucursal..!!!".ToUpper,
                                       My.Resources.INFORMATION, 2000,
                                       eToastGlowColor.Blue,
                                       eToastPosition.BottomLeft)
                Exit Sub
            End If
            'filtro por sucursal
            Dim dtSucursales As DataTable = CType(grSucursales.DataSource, DataTable)
            Dim dtFinal As DataTable = _dt.Copy
            dtFinal.Rows.Clear()
            For Each fila As DataRow In dtSucursales.Rows
                If fila.Item("ok") = True Then
                    Dim filasFiltradas As DataRow() = _dt.Select("suc=" + fila.Item("canumi").ToString.Trim)
                    If filasFiltradas.Count > 0 Then
                        dtFinal.Merge(filasFiltradas.CopyToDataTable)

                    End If
                End If
            Next

            If (dtFinal.Rows.Count > 0) Then
                Dim objrep As New R_ListaAlumnosAprobados
                GenerarNro2(dtFinal)

                objrep.SetDataSource(dtFinal)
                MReportViewer.ReportSource = objrep

                objrep.SetParameterValue("Codigo", "ACB.F - CER - 002")
                objrep.SetParameterValue("Rev", "0")
                objrep.SetParameterValue("Fecha", tbFecha.Value.ToString)
                objrep.SetParameterValue("estado", "APROBADOS")

                MReportViewer.Show()
                MReportViewer.BringToFront()
            Else
                ToastNotification.Show(Me, "NO HAY DATOS PARA LOS PARAMETROS SELECCIONADOS..!!!",
                                           My.Resources.INFORMATION, 2000,
                                           eToastGlowColor.Blue,
                                           eToastPosition.BottomLeft)
                MReportViewer.ReportSource = Nothing
            End If

        Else
            '_dt = L_prPreAlumnosReporteAprobReprob(tbFecha.Value.ToString)
            _dt = L_prPreAlumnosReporteAprobReprob(tbFecha.Value.ToString("yyyy/MM/dd"), ObtenerValorEscuela)
            If _prSucursalSeleccionada() = False Then
                ToastNotification.Show(Me, "seleccione sucursal..!!!".ToUpper,
                                       My.Resources.INFORMATION, 2000,
                                       eToastGlowColor.Blue,
                                       eToastPosition.BottomLeft)
                Exit Sub
            End If

            'filtro por sucursal
            Dim dtSucursales As DataTable = CType(grSucursales.DataSource, DataTable)
            Dim dtFinal As DataTable = _dt.Copy
            dtFinal.Rows.Clear()
            For Each fila As DataRow In dtSucursales.Rows
                If fila.Item("ok") = True Then
                    Dim filasFiltradas As DataRow() = _dt.Select("suc=" + fila.Item("canumi").ToString.Trim)
                    If filasFiltradas.Count > 0 Then
                        dtFinal.Merge(filasFiltradas.CopyToDataTable)

                    End If
                End If
            Next

            If (dtFinal.Rows.Count > 0) Then
                Dim objrep As New R_ListaAlumnosAprobadosTodos

                GenerarNro(dtFinal)
                objrep.SetDataSource(dtFinal)
                MReportViewer.ReportSource = objrep

                objrep.SetParameterValue("Codigo", "ACB.F - CER - 002")
                objrep.SetParameterValue("Rev", "0")
                objrep.SetParameterValue("Fecha", tbFecha.Value.ToString)

                MReportViewer.Show()
                MReportViewer.BringToFront()
            Else
                ToastNotification.Show(Me, "NO HAY DATOS PARA LOS PARAMETROS SELECCIONADOS..!!!",
                                           My.Resources.INFORMATION, 2000,
                                           eToastGlowColor.Blue,
                                           eToastPosition.BottomLeft)
                MReportViewer.ReportSource = Nothing
            End If

        End If

    End Sub

    Private Sub _prCargarComboEstado()

        cbestado.Items.Add("APROBADO")
        cbestado.Items.Add("REPROBADO")
        cbestado.Items.Add("TODOS")
    End Sub

    Private Sub _prCargarComboEscuela()

        tbEscuela.Items.Add("SI")
        tbEscuela.Items.Add("NO")
        tbEscuela.Items.Add("TODOS")
    End Sub


#End Region
    Private Sub Pr_ListAlumnAprovb_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _prIniciarTodo()
    End Sub



    Private Sub btnGenerar_Click(sender As Object, e As EventArgs) Handles btnGenerar.Click
        _prCargarReporte()
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub



    Private Sub ComboBoxEx1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbestado.SelectedIndexChanged

    End Sub

    Private Sub LabelX16_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub tbEscuela_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tbEscuela.SelectedIndexChanged
        'If tbEscuela.Text = "SI" Then
        '    tbSuc.Visible = True
        '    LabelX16.Visible = True
        'Else
        '    tbSuc.Visible = False
        '    LabelX16.Visible = False
        'End If
    End Sub
End Class