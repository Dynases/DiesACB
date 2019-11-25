Imports Logica.AccesoLogica
Imports Janus.Windows.GridEX
Imports DevComponents.DotNetBar

Public Class F0_Antigue_Vacacion


#Region "Variables Lcales"
    Dim _Dsencabezado As DataSet
    Dim _Pos As Integer
    Dim _Nuevo1 As Boolean
    Dim _Nuevo2 As Boolean
    'Dim _Modificar As Boolean

#End Region

#Region "Metodos Privados"
    Private Sub _PIniciarTodo()
        Me.Text = "B O N O S"
        Me.WindowState = FormWindowState.Maximized

        'L_abrirConexion()

        _PInhabilitar1()
        _PInhabilitar2()

        _PCargarGridBonosAntiguedad()
        _PCargarGridVacaciones()
        _PHabilitarFocus()

        _pCambiarFuente()
    End Sub

    Private Sub _pCambiarFuente()
        'Dim fuente As New Font("Tahoma", gi_fuenteTamano, FontStyle.Regular)
        'Dim xCtrl As Control
        'For Each xCtrl In GroupPanel2.Controls
        '    Try
        '        xCtrl.Font = fuente
        '    Catch ex As Exception
        '    End Try
        'Next
        'For Each xCtrl In GroupPanel1.Controls
        '    Try
        '        xCtrl.Font = fuente
        '    Catch ex As Exception
        '    End Try
        'Next
        'GroupPanel1.Font = fuente
        'GroupPanel2.Font = fuente
    End Sub
    Private Sub _PCargarGridVacaciones()
        Dim dt As New DataTable
        dt = L_Vacacion_General(0).Tables(0)

        JGr_Vacaciones.BoundMode = BoundMode.Bound
        JGr_Vacaciones.DataSource = dt
        JGr_Vacaciones.RetrieveStructure()

        'dar formato a las columnas
        With JGr_Vacaciones.RootTable.Columns("penumi")
            .Caption = "Codigo"
            .Width = 90
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        End With

        With JGr_Vacaciones.RootTable.Columns("pemeses")
            .Caption = "Meses"
            .Width = 90
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        End With

        With JGr_Vacaciones.RootTable.Columns("pedias")
            .Caption = "Dias"
            .Width = 100
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        End With

        With JGr_Vacaciones.RootTable.Columns("pefvig")
            .Caption = "Vigencia"
            .Width = 100
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        End With

        With JGr_Vacaciones.RootTable.Columns("petipo")
            .Caption = "Dias Habiles"
            .Width = 100
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
        End With


        With JGr_Vacaciones
            .GroupByBoxVisible = False
            'diseño de la grilla
            JGr_Vacaciones.VisualStyle = VisualStyle.Office2007
        End With

    End Sub
    Private Sub _PCargarGridBonosAntiguedad()
        Dim dt As New DataTable
        dt = L_BonosAntiguedad_General(0).Tables(0)

        JGr_BonoAntiguedad.BoundMode = BoundMode.Bound
        JGr_BonoAntiguedad.DataSource = dt
        JGr_BonoAntiguedad.RetrieveStructure()

        'dar formato a las columnas
        With JGr_BonoAntiguedad.RootTable.Columns("pdnumi")
            .Caption = "Codigo"
            .Width = 100
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        End With

        With JGr_BonoAntiguedad.RootTable.Columns("pdmeses")
            .Caption = "Meses"
            .Width = 100
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        End With

        With JGr_BonoAntiguedad.RootTable.Columns("pdmonto")
            .Caption = "Monto"
            .Width = 100
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .FormatString = "0.00"
        End With


        With JGr_BonoAntiguedad
            .GroupByBoxVisible = False
            'diseño de la grilla
            JGr_BonoAntiguedad.VisualStyle = VisualStyle.Office2007
        End With

    End Sub

    Private Sub _PHabilitarFocus()

        MHighlighterFocus.SetHighlightOnFocus(Tb_BonoImporte, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
        MHighlighterFocus.SetHighlightOnFocus(Tb_BonoMeses, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
        MHighlighterFocus.SetHighlightOnFocus(Tb_VacacionesDias, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
        MHighlighterFocus.SetHighlightOnFocus(Tb_VacacionesMeses, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)

        Tb_BonoMeses.TabIndex = 1
        Tb_BonoImporte.TabIndex = 2
        Tb_VacacionesMeses.TabIndex = 1
        Tb_VacacionesDias.TabIndex = 2
    End Sub

#Region "Bono Antiguedad"
    Private Sub _PHabilitar1()
        Tb_BonoImporte.Enabled = True
        Tb_BonoMeses.Enabled = True

        BBtn_Nuevo1.Enabled = False
        BBtn_Modificar1.Enabled = False
        BBtn_Eliminar1.Enabled = False
        BBtn_Grabar1.Enabled = True

    End Sub
    Private Sub _PInhabilitar1()
        Tb_id1.Visible = False
        Tb_id2.Visible = False

        Tb_BonoImporte.Enabled = False
        Tb_BonoMeses.Enabled = False

        BBtn_Nuevo1.Enabled = True
        BBtn_Modificar1.Enabled = True
        BBtn_Eliminar1.Enabled = True
        BBtn_Grabar1.Enabled = False

        LblPaginacion.Text = ""

        BBtn_Grabar1.Image = My.Resources.GUARDAR

        _PLimpiarErrores1()

        JGr_BonoAntiguedad.Enabled = True
    End Sub
    Private Sub _PLimpiarErrores1()
        'Ep1.Clear()
        'Ep2.Clear()
        'J_Cb_Ciudad.BackColor = Color.White
        'J_Cb_Provincia.BackColor = Color.White
        'J_Cb_Zona.BackColor = Color.White
        'ButtonX1.BackColor = Color.White
    End Sub
    Private Sub _PLimpiar1()
        Tb_BonoMeses.Text = ""
        Tb_BonoImporte.Text = ""

        'aumentado 
        LblPaginacion.Text = ""
    End Sub

    Private Sub _PGrabarRegistro1()
        Dim _Error As Boolean = False
        If _PValidar1() Then
            Exit Sub
        End If
        If BBtn_Grabar1.Enabled = False Then
            Exit Sub
        End If

        If False Then 'BBtn_Grabar1.Tag = 0
            'BBtn_Grabar1.Tag = 1
            'BBtn_Grabar1.Image = My.Resources.CONFIRMACION
            'BBtn_Grabar1.ImageLarge = My.Resources.CONFIRMACION
            'BubbleBar9.Refresh()
            'Exit Sub
        Else
            BBtn_Grabar1.Tag = 0

        End If


        If _Nuevo1 Then
            Dim numi As String = Tb_id1.Text
            L_BonosAntiguedad_Grabar(numi, Tb_BonoMeses.Text, Tb_BonoImporte.Text)

            'actualizar el grid
            _PCargarGridBonosAntiguedad()

            Tb_BonoMeses.Focus()
            ToastNotification.Show(Me, "Codigo de Bono Antiguedad ".ToUpper + numi + " Grabado con Exito.".ToUpper, My.Resources.GRABACION_EXITOSA, 5000, eToastGlowColor.Green, eToastPosition.BottomLeft)
            'Tsbl0_Mensaje.Text = ""
            _PLimpiar1()
        Else
            Dim numi As String = Tb_id1.Text
            L_BonosAntiguedad_Modificar(numi, Tb_BonoMeses.Text, Tb_BonoImporte.Text)

            'actualizar el grid
            _PCargarGridBonosAntiguedad()

            ToastNotification.Show(Me, "Codigo de Bono Antiguedad ".ToUpper + numi + " Modificado con Exito.".ToUpper, My.Resources.GRABACION_EXITOSA, 5000, eToastGlowColor.Green, eToastPosition.BottomLeft)

            _Nuevo1 = False 'aumentado danny
            _PInhabilitar1()
        End If
    End Sub

    Private Sub _PNuevoRegistro1()
        _PHabilitar1()
        BBtn_Nuevo1.Enabled = True

        _PLimpiar1()
        Tb_BonoMeses.Focus()
        _Nuevo1 = True

        JGr_BonoAntiguedad.Enabled = False
    End Sub

    Private Sub _PModificarRegistro1()
        _Nuevo1 = False
        '_Modificar = True
        _PHabilitar1()

        'capturar la fila a eliminar
        Tb_id1.Text = JGr_BonoAntiguedad.GetValue("pdnumi")
        Tb_BonoMeses.Text = JGr_BonoAntiguedad.GetValue("pdmeses")
        Tb_BonoImporte.Text = JGr_BonoAntiguedad.GetValue("pdmonto")

        JGr_BonoAntiguedad.Enabled = False

    End Sub

    Private Sub _PEliminarRegistro1()
        Dim _Result As MsgBoxResult
        _Result = MsgBox("Esta seguro de Eliminar el Registro?", MsgBoxStyle.YesNo, "Advertencia")
        If _Result = MsgBoxResult.Yes Then
            Dim numi As String = JGr_BonoAntiguedad.GetValue("pdnumi")
            L_BonosAntiguedad_Borrar(numi)
            _PCargarGridBonosAntiguedad()
        End If
    End Sub

    Private Sub _PSalirRegistro1()
        If BBtn_Grabar1.Enabled = True Then
            _PInhabilitar1()
            _PCargarGridBonosAntiguedad()
        Else
            Me.Close()
        End If
    End Sub

    Private Function _PValidar1() As Boolean
        Dim _Error As Boolean = False

        If Tb_BonoImporte.Text = "" Then
            Tb_BonoImporte.BackColor = Color.Red   'error de validacion
            'Ep1.SetError(Tb_Nombre, "Ingrese el nombre del empleado!")
            _Error = True
        Else
            Tb_BonoImporte.BackColor = Color.White
            'Ep1.SetError(Tb_Nombre, "")
        End If

        If Tb_BonoMeses.Text = "" Then
            Tb_BonoMeses.BackColor = Color.Red   'error de validacion
            'Ep1.SetError(Tb_Nombre, "Ingrese el nombre del empleado!")
            _Error = True
        Else
            Tb_BonoMeses.BackColor = Color.White
            'Ep1.SetError(Tb_Nombre, "")
        End If


        Return _Error
    End Function

#End Region

#Region "Vacaciones"
    Private Sub _PHabilitar2()
        Tb_VacacionesDias.Enabled = True
        Tb_VacacionesMeses.Enabled = True
        Tb_VacacionesFecha.Enabled = True
        Tb_VacacionesTipo.Enabled = True

        BBtn_Nuevo2.Enabled = False
        BBtn_Modificar2.Enabled = False
        BBtn_Eliminar2.Enabled = False
        BBtn_Grabar2.Enabled = True

    End Sub
    Private Sub _PInhabilitar2()
        Tb_VacacionesDias.Enabled = False
        Tb_VacacionesMeses.Enabled = False
        Tb_VacacionesFecha.Enabled = False
        Tb_VacacionesTipo.Enabled = False

        BBtn_Nuevo2.Enabled = True
        BBtn_Modificar2.Enabled = True
        BBtn_Eliminar2.Enabled = True
        BBtn_Grabar2.Enabled = False

        LblPaginacion.Text = ""

        BBtn_Grabar2.Image = My.Resources.GUARDAR

        _PLimpiarErrores2()

        JGr_Vacaciones.Enabled = True
    End Sub
    Private Sub _PLimpiarErrores2()
        'Ep1.Clear()
        'Ep2.Clear()
        'J_Cb_Ciudad.BackColor = Color.White
        'J_Cb_Provincia.BackColor = Color.White
        'J_Cb_Zona.BackColor = Color.White
        'ButtonX1.BackColor = Color.White
    End Sub
    Private Sub _PLimpiar2()
        Tb_VacacionesDias.Text = ""
        Tb_VacacionesMeses.Text = ""
        Tb_VacacionesTipo.Value = True

        'aumentado 
        LblPaginacion.Text = ""
    End Sub

    Private Sub _PGrabarRegistro2()
        Dim _Error As Boolean = False
        If _PValidar2() Then
            Exit Sub
        End If
        If BBtn_Grabar2.Enabled = False Then
            Exit Sub
        End If

        If False Then 'BBtn_Grabar2.Tag = 0
            'BBtn_Grabar2.Tag = 1
            'BBtn_Grabar2.Image = My.Resources.CONFIRMACION
            'BBtn_Grabar2.ImageLarge = My.Resources.CONFIRMACION
            'BubbleBar7.Refresh()
            'Exit Sub
        Else
            BBtn_Grabar2.Tag = 0
            
        End If


        If _Nuevo2 Then
            Dim numi As String = Tb_id2.Text
            L_Vacacion_Grabar(numi, Tb_VacacionesMeses.Text, Tb_VacacionesDias.Text, Tb_VacacionesFecha.Value.ToString("yyyy/MM/dd"), IIf(Tb_VacacionesTipo.Value, "1", "0"))

            'actualizar el grid
            _PCargarGridVacaciones()

            Tb_VacacionesMeses.Focus()
            ToastNotification.Show(Me, "Codigo Vacacion ".ToUpper + numi + " Grabado con Exito.".ToUpper, My.Resources.GRABACION_EXITOSA, 5000, eToastGlowColor.Green, eToastPosition.BottomLeft)
            'Tsbl0_Mensaje.Text = ""
            _PLimpiar2()
        Else
            Dim numi As String = Tb_id2.Text
            L_Vacacion_Modificar(numi, Tb_VacacionesMeses.Text, Tb_VacacionesDias.Text, Tb_VacacionesFecha.Value.ToString("yyyy/MM/dd"), IIf(Tb_VacacionesTipo.Value, "1", "0"))

            'actualizar el grid
            _PCargarGridVacaciones()

            ToastNotification.Show(Me, "Codigo de Vacacion ".ToUpper + numi + " Modificado con Exito.".ToUpper, My.Resources.GRABACION_EXITOSA, 5000, eToastGlowColor.Green, eToastPosition.BottomLeft)

            _Nuevo2 = False 'aumentado danny
            _PInhabilitar2()
        End If
    End Sub

    Private Sub _PNuevoRegistro2()
        _PHabilitar2()
        BBtn_Nuevo2.Enabled = True

        _PLimpiar2()
        Tb_VacacionesMeses.Focus()
        _Nuevo2 = True

        JGr_Vacaciones.Enabled = False
    End Sub

    Private Sub _PModificarRegistro2()
        _Nuevo2 = False
        '_Modificar = True
        _PHabilitar2()

        'capturar la fila a eliminar
        Tb_id2.Text = JGr_Vacaciones.GetValue("penumi")
        Tb_VacacionesMeses.Text = JGr_Vacaciones.GetValue("pemeses")
        Tb_VacacionesDias.Text = JGr_Vacaciones.GetValue("pedias")

        JGr_Vacaciones.Enabled = False

    End Sub

    Private Sub _PEliminarRegistro2()
        Dim _Result As MsgBoxResult
        _Result = MsgBox("Esta seguro de Eliminar el Registro?", MsgBoxStyle.YesNo, "Advertencia")
        If _Result = MsgBoxResult.Yes Then
            Dim numi As String = JGr_Vacaciones.GetValue("penumi")
            L_Vacacion_Borrar(numi)
            _PCargarGridVacaciones()
        End If
    End Sub

    Private Sub _PSalirRegistro2()
        If BBtn_Grabar2.Enabled = True Then
            _PInhabilitar2()
            _PCargarGridVacaciones()
        Else
            Me.Close()
        End If
    End Sub

    Private Function _PValidar2() As Boolean
        Dim _Error As Boolean = False

        If Tb_VacacionesDias.Text = "" Then
            Tb_VacacionesDias.BackColor = Color.Red   'error de validacion
            'Ep1.SetError(Tb_Nombre, "Ingrese el nombre del empleado!")
            _Error = True
        Else
            Tb_VacacionesDias.BackColor = Color.White
            'Ep1.SetError(Tb_Nombre, "")
        End If

        If Tb_VacacionesMeses.Text = "" Then
            Tb_VacacionesMeses.BackColor = Color.Red   'error de validacion
            'Ep1.SetError(Tb_Nombre, "Ingrese el nombre del empleado!")
            _Error = True
        Else
            Tb_VacacionesMeses.BackColor = Color.White
            'Ep1.SetError(Tb_Nombre, "")
        End If


        Return _Error
    End Function

#End Region



#End Region


    Private Sub BBtn_Nuevo1_Click(sender As Object, e As EventArgs) Handles BBtn_Nuevo1.Click
        _PNuevoRegistro1()
    End Sub

    Private Sub BBtn_Modificar1_Click(sender As Object, e As EventArgs) Handles BBtn_Modificar1.Click
        _PModificarRegistro1()
    End Sub

    Private Sub BBtn_Eliminar1_Click(sender As Object, e As EventArgs) Handles BBtn_Eliminar1.Click
        _PEliminarRegistro1()
    End Sub

    Private Sub BBtn_Grabar1_Click(sender As Object, e As EventArgs) Handles BBtn_Grabar1.Click
        _PGrabarRegistro1()
    End Sub

    Private Sub BBtn_Salir1_Click(sender As Object, e As EventArgs) Handles BBtn_Salir1.Click
        _PSalirRegistro1()
    End Sub

    Private Sub BBtn_Nuevo2_Click(sender As Object, e As EventArgs) Handles BBtn_Nuevo2.Click
        _PNuevoRegistro2()
    End Sub

    Private Sub BBtn_Modificar2_Click(sender As Object, e As EventArgs) Handles BBtn_Modificar2.Click
        _PModificarRegistro2()
    End Sub

    Private Sub BBtn_Eliminar2_Click(sender As Object, e As EventArgs) Handles BBtn_Eliminar2.Click
        _PEliminarRegistro2()
    End Sub

    Private Sub BBtn_Grabar2_Click(sender As Object, e As EventArgs) Handles BBtn_Grabar2.Click
        _PGrabarRegistro2()
    End Sub

    Private Sub BBtn_Salir2_Click(sender As Object, e As EventArgs) Handles BBtn_Salir2.Click
        _PSalirRegistro2()
    End Sub

    Private Sub JGr_BonoAntiguedad_SelectionChanged(sender As Object, e As EventArgs) Handles JGr_BonoAntiguedad.SelectionChanged
        'COLOREAR FILA
        'Dim estiloFila As New GridEXFormatStyle()
        'estiloFila.BackColor = Color.AliceBlue
        'JGr_BonoAntiguedad.CurrentRow.RowStyle = estiloFila

        'capturar la fila a eliminar
        If JGr_BonoAntiguedad.Row >= 0 Then
            Tb_id1.Text = JGr_BonoAntiguedad.GetValue("pdnumi")
            Tb_BonoMeses.Text = JGr_BonoAntiguedad.GetValue("pdmeses")
            Tb_BonoImporte.Text = JGr_BonoAntiguedad.GetValue("pdmonto")
        End If

    End Sub

    Private Sub JGr_Vacaciones_SelectionChanged(sender As Object, e As EventArgs) Handles JGr_Vacaciones.SelectionChanged
        'capturar la fila a eliminar
        If JGr_Vacaciones.Row >= 0 Then
            Tb_id2.Text = JGr_Vacaciones.GetValue("penumi")
            Tb_VacacionesMeses.Text = JGr_Vacaciones.GetValue("pemeses")
            Tb_VacacionesDias.Text = JGr_Vacaciones.GetValue("pedias")
            Tb_VacacionesFecha.Value = JGr_Vacaciones.GetValue("pefvig")
            Tb_VacacionesTipo.Value = JGr_Vacaciones.GetValue("petipo")
        End If

    End Sub

    Private Sub JGr_BonoAntiguedad_EditingCell(sender As Object, e As EditingCellEventArgs) Handles JGr_BonoAntiguedad.EditingCell
        e.Cancel = True
    End Sub

    Private Sub JGr_Vacaciones_EditingCell(sender As Object, e As EditingCellEventArgs) Handles JGr_Vacaciones.EditingCell
        e.Cancel = True
    End Sub

    Private Sub F0_Antigue_Vacacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _PIniciarTodo()
    End Sub
End Class