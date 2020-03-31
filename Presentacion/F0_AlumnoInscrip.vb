Imports Logica.AccesoLogica
Imports Janus.Windows.GridEX
Imports DevComponents.DotNetBar
Imports System.IO
Imports DevComponents.DotNetBar.SuperGrid


Public Class F0_AlumnoInscrip
#Region "Variable Globales"
    Public _nameButton As String
    Public Sucursal As Integer
    Public CodAlumno As Integer
    Public Alumno As String

    Dim _Pos As Integer
    Dim IdVenta As Integer

#End Region

    Private Sub F1_AlumnoInscrip_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _prIniciarTodo()
    End Sub
    Private Sub _prIniciarTodo()
        Me.Text = "I N S C R I P C I Ó N   D E   A L U M N O S"
        Dim blah As Bitmap = My.Resources.cliente
        Dim ico As Icon = Icon.FromHandle(blah.GetHicon())
        Me.Icon = ico
        '_prAsignarPermisos()
        _prCargarComboHorarioSucursal()
        tbAlumno.Text = Alumno
        _prCargarComboServicios(Sucursal)

        _CargarInscripcion(CodAlumno)
        '_CargarGridDetalle(-1)
        '_prAddDetalleVenta()

        'btnModificar.Enabled = False
        'btnEliminar.Enabled = False
        SuperTabPrincipal.SelectedTabIndex = 0
        _Inhabilitar()
        btnNuevo.PerformClick()
    End Sub
    Private Sub _prCargarComboHorarioSucursal()
        Dim dt As New DataTable
        dt = L_prHorarioSucursal()

        With cbHoraSuc
            .DropDownList.Columns.Clear()

            .DropDownList.Columns.Add("cbsuc").Width = 70
            .DropDownList.Columns("cbsuc").Caption = "COD"

            .DropDownList.Columns.Add("cadesc").Width = 300
            .DropDownList.Columns("cadesc").Caption = "descripcion".ToUpper

            .ValueMember = "cbsuc"
            .DisplayMember = "cadesc"
            .DataSource = dt
            .Refresh()
        End With

        'If gb_userTodasSuc = False Then
        '    tbSuc.Enabled = False
        'End If

        'tbSuc.Value = 11
        cbHoraSuc.SelectedIndex = 0
    End Sub

    Private Sub _prCargarComboServicios(Suc As Integer)
        Dim dt As New DataTable
        dt = L_prListarServicios(Suc)
        If dt.Rows.Count > 0 Then
            With cbServicio
                .DropDownList.Columns.Clear()

                .DropDownList.Columns.Add("ednumi").Width = 70
                .DropDownList.Columns("ednumi").Caption = "COD"

                .DropDownList.Columns.Add("eddesc").Width = 300
                .DropDownList.Columns("eddesc").Caption = "descripcion".ToUpper

                .ValueMember = "ednumi"
                .DisplayMember = "eddesc"
                .DataSource = dt
                .Refresh()
            End With
            cbServicio.SelectedIndex = 0
        Else
            Dim img As Bitmap = New Bitmap(My.Resources.cancel, 50, 50)
            ToastNotification.Show(Me, "La Sucursal que se eligió para el alumno no tiene servicios enlazados".ToUpper, img, 4000, eToastGlowColor.Red, eToastPosition.BottomCenter)
            Exit Sub
        End If

    End Sub

    Private Sub tbNFactura_KeyDown(sender As Object, e As KeyEventArgs) Handles tbNFactura.KeyDown
        If (_fnAccesible()) Then
            If e.KeyData = Keys.Control + Keys.Enter Then
                Dim dt As DataTable
                dt = L_prListarFacturas(Sucursal)

                Dim listEstCeldas As New List(Of Modelos.Celda)
                listEstCeldas.Add(New Modelos.Celda("vcnumi,", False, "NRO VENTA", 100))
                listEstCeldas.Add(New Modelos.Celda("factura", True, "NRO FACTURA".ToUpper, 100))
                listEstCeldas.Add(New Modelos.Celda("vcobs", True, "OBSERVACIÓN", 300))
                listEstCeldas.Add(New Modelos.Celda("vctotal", True, "TOTAL", 90, 0.00))
                listEstCeldas.Add(New Modelos.Celda("vcalm", False, "", 50))
                listEstCeldas.Add(New Modelos.Celda("sucursal", True, "SUCURSAL", 160))
                listEstCeldas.Add(New Modelos.Celda("vcsector", False, "", 50))
                listEstCeldas.Add(New Modelos.Celda("sector", False, "", 50))
                listEstCeldas.Add(New Modelos.Celda("vcfdoc", True, "FECHA", 120, "dd/MM/yyyy"))
                listEstCeldas.Add(New Modelos.Celda("nit", True, "NIT", 100))
                listEstCeldas.Add(New Modelos.Celda("lanom", True, "RAZÓN SOCIAL", 220))

                Dim ef = New EfectoAyuda
                ef.tipo = 3
                ef.dt = dt
                'Modelos.MGlobal.SeleccionarCol = 5
                ef.SeleclCol = 2
                ef.listEstCeldas = listEstCeldas
                ef.alto = 110
                ef.ancho = 310
                ef.Context = "Seleccione Factura".ToUpper
                ef.ShowDialog()
                Dim bandera As Boolean = False
                bandera = ef.band
                If (bandera = True) Then
                    Dim Row As Janus.Windows.GridEX.GridEXRow = ef.Row
                    IdVenta = Row.Cells("vcnumi").Value
                    tbNFactura.Text = Row.Cells("factura").Value
                End If
            End If
        End If


    End Sub

    Public Function _fnAccesible()
        Return tbObservacion.ReadOnly = False
    End Function

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        _Limpiar()
        _Habilitar()

        'btnNuevo.Enabled = False
        'btnModificar.Enabled = False
        'btnEliminar.Enabled = False
        'btnGrabar.Enabled = True
        'PanelNavegacion.Enabled = False
    End Sub

    Private Sub _Limpiar()
        tbCodigo.Clear()
        dtFecha.Value = Now.Date
        'tbAlumno.Clear()
        IdVenta = 0
        tbNFactura.Clear()
        tbObservacion.Clear()
        cbHoraSuc.SelectedIndex = 0
        'cbServicio.SelectedIndex = 0
        tbNGrupo.Clear()

        If cbServicio.SelectedIndex <= -1 Then
            cbServicio.Value = ""
        Else
            cbServicio.SelectedIndex = 0
        End If

        _CargarGridDetalle(-1)
    End Sub

    Private Sub _prAddDetalleVenta()
        CType(JGDetalle.DataSource, DataTable).Rows.Add(_fnSiguienteNumi() + 1, 0, 0, 0, "", 0, "", "", 0)
    End Sub
    Public Function _fnSiguienteNumi()
        Dim dt As DataTable = CType(JGDetalle.DataSource, DataTable)
        Dim rows() As DataRow = dt.Select("cdnumi=MAX(cdnumi)")
        If (rows.Count > 0) Then
            Return rows(rows.Count - 1).Item("cdnumi")
        End If
        Return 1
    End Function

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        _prAddDetalleVenta()
        Dim pos As Integer = -1
        JGDetalle.Row = JGDetalle.RowCount - 1
        _fnObtenerFilaDetalle(pos, JGDetalle.GetValue("cdnumi"))
        CType(JGDetalle.DataSource, DataTable).Rows(pos).Item("cdhorsuc") = cbHoraSuc.Value
        CType(JGDetalle.DataSource, DataTable).Rows(pos).Item("cadesc") = cbHoraSuc.Text
        CType(JGDetalle.DataSource, DataTable).Rows(pos).Item("cdservicio") = cbServicio.Value
        CType(JGDetalle.DataSource, DataTable).Rows(pos).Item("eddesc") = cbServicio.Text
        CType(JGDetalle.DataSource, DataTable).Rows(pos).Item("cdngrupo") = tbNGrupo.Text

    End Sub
    Public Sub _fnObtenerFilaDetalle(ByRef pos As Integer, numi As Integer)
        For i As Integer = 0 To CType(JGDetalle.DataSource, DataTable).Rows.Count - 1 Step 1
            Dim _numi As Integer = CType(JGDetalle.DataSource, DataTable).Rows(i).Item("cdnumi")
            If (_numi = numi) Then
                pos = i
                Return
            End If
        Next
    End Sub

    Private Sub btnGrabar_Click(sender As Object, e As EventArgs) Handles btnGrabar.Click
        If _ValidarCampos() = False Then
            Exit Sub
        End If

        If (tbCodigo.Text = String.Empty) Then
            _GuardarNuevo()
        Else
            If (tbCodigo.Text <> String.Empty) Then
                _GuardarModificado()
            End If
        End If
    End Sub
    Public Function _ValidarCampos() As Boolean
        If (tbNFactura.Text.Length = 0) Then
            Dim img As Bitmap = New Bitmap(My.Resources.Mensaje, 50, 50)
            ToastNotification.Show(Me, "Por Favor Inserte Nro. de Factura".ToUpper, img, 2000, eToastGlowColor.Red, eToastPosition.BottomCenter)
            tbNFactura.Focus()
            Return False
        End If
        If (tbNGrupo.Text.Length = 0) Then
            Dim img As Bitmap = New Bitmap(My.Resources.Mensaje, 50, 50)
            ToastNotification.Show(Me, "Por Favor Inserte el Nro. de Grupo".ToUpper, img, 2000, eToastGlowColor.Red, eToastPosition.BottomCenter)
            tbNGrupo.Focus()
            Return False
        End If
        If (cbHoraSuc.SelectedIndex < 0) Then
            Dim img As Bitmap = New Bitmap(My.Resources.Mensaje, 50, 50)
            ToastNotification.Show(Me, "Por Favor Seleccione una Hora-Sucursal".ToUpper, img, 2000, eToastGlowColor.Red, eToastPosition.BottomCenter)
            cbHoraSuc.Focus()
            Return False
        End If
        If (JGDetalle.RowCount = 0) Then
            Dim img As Bitmap = New Bitmap(My.Resources.Mensaje, 50, 50)
            ToastNotification.Show(Me, "Por Favor agregue un detalle para la inscripción".ToUpper, img, 2000, eToastGlowColor.Red, eToastPosition.BottomCenter)
            Return False
        End If

        Return True
    End Function
    Public Sub _GuardarNuevo()
        Dim numi As String = ""
        Dim res As Boolean = L_prGrabarInscripcion(numi, CodAlumno, dtFecha.Value, IdVenta, tbNFactura.Text, tbObservacion.Text, CType(JGDetalle.DataSource, DataTable))

        If res Then

            Dim img As Bitmap = New Bitmap(My.Resources.checked, 50, 50)
            ToastNotification.Show(Me, "Inscripción ".ToUpper + numi + " Grabada con éxito.".ToUpper,
                                      img, 2000,
                                      eToastGlowColor.Green,
                                      eToastPosition.TopCenter
                                      )

            _CargarInscripcion(CodAlumno)
            _Limpiar()
            _Salir()

            Dim info As New TaskDialogInfo("clases practicas".ToUpper, eTaskDialogIcon.Delete, "clases practicas".ToUpper, "¿Desea programar las clases practicas del alumno registrado?".ToUpper, eTaskDialogButton.Yes Or eTaskDialogButton.Cancel, eTaskDialogBackgroundColor.Blue)
            Dim result As eTaskDialogResult = TaskDialog.Show(info)
            If result = eTaskDialogResult.Yes Then
                Dim frm As F0_ClasesPracticas3
                frm = New F0_ClasesPracticas3
                frm._numiAlumInscrito = CodAlumno
                frm.idInscripcion = tbCodigo.Text
                frm.Show()
            End If

        Else
            Dim img As Bitmap = New Bitmap(My.Resources.cancel, 50, 50)
            ToastNotification.Show(Me, "La inscripción no pudo ser insertada.".ToUpper, img, 2000, eToastGlowColor.Red, eToastPosition.BottomCenter)
        End If

    End Sub
    Public Sub _GuardarModificado()
        Dim res As Boolean = L_prGrabarModificadoInscripcion(tbCodigo.Text, CodAlumno, dtFecha.Value, IdVenta, tbNFactura.Text, tbObservacion.Text, CType(JGDetalle.DataSource, DataTable))
        If res Then
            Dim img As Bitmap = New Bitmap(My.Resources.checked, 50, 50)
            ToastNotification.Show(Me, "Código de Inscripción ".ToUpper + tbCodigo.Text + " Modificado con éxito.".ToUpper,
                                      img, 2000,
                                      eToastGlowColor.Green,
                                      eToastPosition.TopCenter
                                      )

            _CargarInscripcion(CodAlumno)
            _Salir()
        Else
            Dim img As Bitmap = New Bitmap(My.Resources.cancel, 50, 50)
            ToastNotification.Show(Me, "La inscripción no pudo ser Modificada".ToUpper, img, 2000, eToastGlowColor.Red, eToastPosition.BottomCenter)

        End If
    End Sub

    Private Sub ELIMINARToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ELIMINARToolStripMenuItem.Click
        If JGDetalle.GetValue("estado") = 0 Then
            JGDetalle.CurrentRow.EndEdit()
            JGDetalle.CurrentRow.Delete()
            JGDetalle.Refetch()
            JGDetalle.Refresh()
            JGDetalle.UpdateData()
        ElseIf JGDetalle.GetValue("estado") = 1 Then
            Dim pos As Integer = -1
            Dim lin As Integer = JGDetalle.GetValue("cdnumi")
            _fnObtenerFilaDetalle(pos, lin)

            CType(JGDetalle.DataSource, DataTable).Rows(pos).Item("estado") = -1

            JGDetalle.RootTable.ApplyFilter(New Janus.Windows.GridEX.GridEXFilterCondition(JGDetalle.RootTable.Columns("estado"), Janus.Windows.GridEX.ConditionOperator.GreaterThanOrEqualTo, 0))
            JGDetalle.Select()
            JGDetalle.Col = 5
            JGDetalle.Row = JGDetalle.RowCount - 1

        End If


    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        _Salir()
    End Sub
    Private Sub _Salir()
        If btnGrabar.Enabled = True Then
            _Inhabilitar()
            If JGInscripcion.RowCount > 0 Then
                _MostrarRegistro(0)
            End If
        Else
            Me.Close()
        End If
    End Sub

    Private Sub JGDetalle_SelectionChanged(sender As Object, e As EventArgs) Handles JGDetalle.SelectionChanged
        If (Not _fnAccesible()) Then
            If JGDetalle.Row >= 0 Then
                Dim _Pos1 As Integer
                _Pos = JGDetalle.Row
                _MostrarDetalle(_Pos1)
            End If
        End If
    End Sub
    Private Sub _CargarInscripcion(CodAlumno As Integer)
        Dim dt As New DataTable
        dt = L_prListarInscripcion(CodAlumno)
        JGInscripcion.DataSource = dt
        JGInscripcion.RetrieveStructure()
        JGInscripcion.AlternatingColors = True

        With JGInscripcion.RootTable.Columns("ccnumi")
            .Width = 90
            .Caption = "CODIGO"
            .Visible = True
            .TextAlignment = TextAlignment.Near
        End With
        With JGInscripcion.RootTable.Columns("cccbnumi")
            .Width = 120
            .Visible = True
            .Caption = "COD ALUMNO"
        End With
        With JGInscripcion.RootTable.Columns("alumno")
            .Width = 250
            .Visible = True
            .Caption = "ALUMNO"
            .TextAlignment = TextAlignment.Near
        End With
        With JGInscripcion.RootTable.Columns("ccfecha")
            .Width = 90
            .Caption = "FECHA"
            .FormatString = "dd/MM/yyyy"
            .Visible = True
        End With
        With JGInscripcion.RootTable.Columns("ccidventa")
            .Width = 90
            .Visible = False
        End With
        With JGInscripcion.RootTable.Columns("ccnfactura")
            .Width = 120
            .Visible = True
            .Caption = "NRO. FACTURA"
        End With
        With JGInscripcion.RootTable.Columns("ccobs")
            .Width = 350
            .Visible = True
            .Caption = "OBSERVACIÓN"
        End With
        With JGInscripcion.RootTable.Columns("ccest")
            .Width = 90
            .Visible = False
        End With
        With JGInscripcion.RootTable.Columns("ccfact")
            .Width = 90
            .Visible = False
        End With
        With JGInscripcion.RootTable.Columns("cchact")
            .Width = 90
            .Visible = False
        End With
        With JGInscripcion.RootTable.Columns("ccuact")
            .Width = 90
            .Visible = False
        End With

        With JGInscripcion
            .DefaultFilterRowComparison = FilterConditionOperator.Contains
            .FilterMode = FilterMode.Automatic
            .FilterRowUpdateMode = FilterRowUpdateMode.WhenValueChanges
            .GroupByBoxVisible = False
            'diseño de la grilla
        End With
        If (dt.Rows.Count <= 0) Then
            _CargarGridDetalle(-1)
            LblPaginacion.Text = Str(0) + "/" + JGInscripcion.RowCount.ToString
        End If

    End Sub
    Private Sub _CargarGridDetalle(idCabecera As String)
        Dim dt As New DataTable
        dt = L_prListarDetalle(idCabecera)

        JGDetalle.BoundMode = BoundMode.Bound
        JGDetalle.DataSource = dt
        JGDetalle.RetrieveStructure()

        'dar formato a las columnas
        With JGDetalle.RootTable.Columns("cdnumi")
            .Visible = False
            .Caption = "Código"
            .Width = 70
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        End With

        With JGDetalle.RootTable.Columns("cdccnumi")
            .Visible = False
            .Caption = "Cod Inscripción"
            .Width = 70
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .DefaultValue = 0
        End With

        With JGDetalle.RootTable.Columns("cdcbnumi")
            .Visible = False
            .Caption = "Cod  Alumno"
            .Width = 150
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .FormatString = "0.00"
        End With

        With JGDetalle.RootTable.Columns("cdhorsuc")
            .Caption = "Id Horario-Suc".ToUpper
            .Visible = False
            .Width = 70
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        End With

        With JGDetalle.RootTable.Columns("cadesc")
            .Caption = "Horario Sucursal".ToUpper
            .Visible = True
            .Width = 300
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        End With

        With JGDetalle.RootTable.Columns("cdservicio")
            .Visible = False
            .Caption = "Id Servicio".ToUpper
            .Width = 120
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .EmptyStringValue = ""

        End With
        With JGDetalle.RootTable.Columns("eddesc")
            .Caption = "Servicio".ToUpper
            .Width = 300
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .EmptyStringValue = ""
        End With
        With JGDetalle.RootTable.Columns("cdngrupo")
            .Caption = "Nro Grupo".ToUpper
            .Width = 190
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .EmptyStringValue = ""
        End With
        With JGDetalle.RootTable.Columns("estado")
            .Visible = False
            .Caption = "Estado"
            .Width = 50
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .EmptyStringValue = ""

        End With

        'Habilitar Filtradores
        With JGDetalle
            '.DefaultFilterRowComparison = FilterConditionOperator.Contains
            '.FilterMode = FilterMode.Automatic
            '.FilterRowUpdateMode = FilterRowUpdateMode.WhenValueChanges
            .GroupByBoxVisible = False

            'diseño de la grilla
            .VisualStyle = VisualStyle.Office2007

            .AllowAddNew = InheritableBoolean.False
            .ContextMenuStrip = ContextMenuStrip1
        End With
    End Sub
    Private Sub _MostrarRegistro(_N As Integer)
        'JGInscripcion.Row = _Pos
        With JGInscripcion
            tbCodigo.Text = .GetValue("ccnumi").ToString
            dtFecha.Value = .GetValue("ccfecha")
            CodAlumno = .GetValue("cccbnumi")
            tbAlumno.Text = .GetValue("alumno").ToString
            IdVenta = .GetValue("ccidventa")
            tbNFactura.Text = .GetValue("ccnfactura").ToString
            tbObservacion.Text = .GetValue("ccobs").ToString
        End With
        _CargarGridDetalle(tbCodigo.Text)
        LblPaginacion.Text = Str(_Pos + 1) + "/" + JGInscripcion.RowCount.ToString
    End Sub
    Private Sub _MostrarDetalle(_N As Integer)

        With JGDetalle
            cbHoraSuc.Value = .GetValue("cdhorsuc")
            cbServicio.Value = .GetValue("cdservicio")
            tbNGrupo.Text = .GetValue("cdngrupo").ToString
        End With

        'LblPaginacion.Text = Str(_Pos + 1) + "/" + JGInscripcion.RowCount.ToString
    End Sub

    Private Sub JGDetalle_EditingCell(sender As Object, e As EditingCellEventArgs) Handles JGDetalle.EditingCell
        e.Cancel = True
    End Sub



    Private Sub JGInscripcion_SelectionChanged(sender As Object, e As EventArgs) Handles JGInscripcion.SelectionChanged
        If (JGInscripcion.RowCount >= 0 And JGInscripcion.Row >= 0) Then
            _MostrarRegistro(JGInscripcion.Row)
        End If

    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        _EliminarRegistro()
    End Sub
    Private Sub _EliminarRegistro()
        Dim info As New TaskDialogInfo("¿esta seguro de eliminar el registro?".ToUpper, eTaskDialogIcon.Delete, "advertencia".ToUpper, "mensaje principal".ToUpper, eTaskDialogButton.Yes Or eTaskDialogButton.Cancel, eTaskDialogBackgroundColor.Blue)
        Dim result As eTaskDialogResult = TaskDialog.Show(info)
        If result = eTaskDialogResult.Yes Then
            Dim mensajeError As String = ""
            Dim res As Boolean = L_prEliminarInscripcion(tbCodigo.Text, mensajeError)
            If res Then
                ToastNotification.Show(Me, "Codigo de alumno: ".ToUpper + tbCodigo.Text + " eliminado con Exito.".ToUpper, My.Resources.GRABACION_EXITOSA, 5000, eToastGlowColor.Green, eToastPosition.TopCenter)
                _CargarInscripcion(CodAlumno)
            Else
                ToastNotification.Show(Me, mensajeError, My.Resources.WARNING, 8000, eToastGlowColor.Red, eToastPosition.TopCenter)
            End If
        End If
    End Sub
    Private Sub _Inhabilitar()
        dtFecha.Enabled = False
        tbAlumno.ReadOnly = True
        tbNFactura.ReadOnly = True
        tbObservacion.ReadOnly = True
        cbHoraSuc.ReadOnly = True
        cbServicio.ReadOnly = True
        tbNGrupo.ReadOnly = True
        btnAgregar.Enabled = False

        btnModificar.Enabled = True
        btnGrabar.Enabled = False
        btnNuevo.Enabled = True
        btnEliminar.Enabled = True
        PanelNavegacion.Enabled = True

        'JGInscripcion.Enabled = True
        'JGDetalle.Enabled = False

    End Sub
    Private Sub _Habilitar()
        dtFecha.Enabled = True
        tbAlumno.ReadOnly = False
        tbNFactura.ReadOnly = False
        tbObservacion.ReadOnly = False
        cbHoraSuc.ReadOnly = False
        cbServicio.ReadOnly = False
        tbNGrupo.ReadOnly = False
        btnAgregar.Enabled = True

        btnNuevo.Enabled = False
        btnModificar.Enabled = False
        btnEliminar.Enabled = False
        btnGrabar.Enabled = True
        PanelNavegacion.Enabled = False

        'JGDetalle.Enabled = True

    End Sub

    Private Sub JGInscripcion_KeyDown(sender As Object, e As KeyEventArgs) Handles JGInscripcion.KeyDown
        If e.KeyData = Keys.Enter Then
            SuperTabPrincipal.SelectedTabIndex = 0
            JGDetalle.Focus()
        End If
    End Sub

    Private Sub JGInscripcion_DoubleClick(sender As Object, e As EventArgs) Handles JGInscripcion.DoubleClick
        SuperTabPrincipal.SelectedTabIndex = 0
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        If (JGInscripcion.RowCount > 0) Then
            _Habilitar()
            PanelNavegacion.Enabled = False
        End If
    End Sub

    Private Sub btnPrimero_Click(sender As Object, e As EventArgs) Handles btnPrimero.Click
        _PrimerRegistro()
    End Sub
    Public Sub _PrimerRegistro()
        Dim _MPos As Integer
        If JGInscripcion.RowCount > 0 Then
            _MPos = 0
            JGInscripcion.Row = _MPos
            LblPaginacion.Text = Str(_MPos + 1) + "/" + JGInscripcion.RowCount.ToString
        End If
    End Sub

    Private Sub btnAnterior_Click(sender As Object, e As EventArgs) Handles btnAnterior.Click
        _AnteriorRegistro()
    End Sub

    Public Sub _AnteriorRegistro()
        Dim _MPos As Integer = JGInscripcion.Row
        If _MPos > 0 And JGInscripcion.RowCount > 0 Then
            _MPos = _MPos - 1
            JGInscripcion.Row = _MPos
            LblPaginacion.Text = Str(_MPos + 1) + "/" + JGInscripcion.RowCount.ToString
        End If
    End Sub

    Private Sub btnSiguiente_Click(sender As Object, e As EventArgs) Handles btnSiguiente.Click
        _SiguienteRegistro()
    End Sub
    Public Sub _SiguienteRegistro()
        Dim _pos As Integer = JGInscripcion.Row
        If _pos < JGInscripcion.RowCount - 1 And _pos >= 0 Then
            _pos = JGInscripcion.Row + 1
            JGInscripcion.Row = _pos
            LblPaginacion.Text = Str(_pos + 1) + "/" + JGInscripcion.RowCount.ToString
        End If
    End Sub
    Private Sub btnUltimo_Click(sender As Object, e As EventArgs) Handles btnUltimo.Click
        _PUltimoRegistro()
    End Sub
    Private Sub _PUltimoRegistro()
        Dim _pos As Integer = JGInscripcion.Row
        If JGInscripcion.RowCount > 0 Then
            _pos = JGInscripcion.RowCount - 1
            JGInscripcion.Row = _pos
            LblPaginacion.Text = Str(_pos + 1) + "/" + JGInscripcion.RowCount.ToString
        End If
    End Sub
End Class