Imports Logica.AccesoLogica
Imports Janus.Windows.GridEX
Imports DevComponents.DotNetBar
Imports DevComponents.Editors.DateTimeAdv

Public Class F0_PedidoVacacion

#Region "Variables Lcales"
    Dim _Dsencabezado As DataSet
    Dim _Pos As Integer
    Dim _Nuevo As Boolean
    Dim _Modificar As Boolean
#End Region

#Region "Metodos Privados"

    Private Sub _PCargarDetalleFechas(numiEmpleado As String)
        Dim dt As New DataTable
        dt = L_PedidoVacacionDetalleFechas(numiEmpleado)

        'llenar la tabla con los dias de vacacion de acuerdo a la antiguedad-------------------------------
        Dim dtDiasVacacion As DataTable = L_Vacacion_General(0).Tables(0)
        Dim fechaIni As Date = dt.Rows(0).Item("cbfing")
        Dim diasTotal As Integer = 0
        Dim diasUsadosTotal As Integer = 0
        Dim diasLibresTotal As Integer = 0

        dt.Clear()
        Dim row As DataRow
        ''Dim cantAños As Integer = DateDiff(DateInterval.Year, fechaIni, Today)
        Dim cantAños As Integer = DateDiff(DateInterval.DayOfYear, fechaIni, Today) \ 365
        Dim mesesRestantes As Integer = DateDiff(DateInterval.Month, fechaIni, Today) - (12 * cantAños)

        Dim dias As Integer
        Dim fechaFin As Date
        Dim i As Integer
        Dim diasUsadosEnGestion As Integer

        Dim diasUsados As Integer = L_PedidoVacacion_ObtenerDiasUsados(JMc_Persona.Value)
        If cantAños >= 1 Then
            For i = 1 To cantAños

                'Dim meses As Integer = dtDiasVacacion.Rows(i).Item("pemeses")
                'Dim dias As Integer = dtDiasVacacion.Rows(i).Item("pedias")
                dias = L_PedidoVacacion_ObtenerDiasVacacion(12 * i)

                ''Dim fechaFin As Date = DateAdd(DateInterval.Month, meses, fechaIni)
                fechaFin = DateAdd(DateInterval.Year, 1, fechaIni)

                'calcular cuantos dias se usaron en esta gestion
                diasUsadosEnGestion = 0
                If diasUsados > 0 Then
                    If diasUsados > dias Then
                        diasUsadosEnGestion = dias
                        diasUsados = diasUsados - dias
                    Else
                        diasUsadosEnGestion = diasUsados
                        diasUsados = 0
                    End If
                End If

                'agregar fila
                row = dt.NewRow()
                row("cbfing") = fechaIni
                row("fechaFin") = fechaFin
                row("diasLibres") = dias
                row("diasUsados") = diasUsadosEnGestion
                row("saldo") = dias - diasUsadosEnGestion

                dt.Rows.Add(row)

                diasTotal = diasTotal + dias
                diasUsadosTotal = diasUsadosTotal + diasUsadosEnGestion
                diasLibresTotal = diasLibresTotal + dias - diasUsadosEnGestion

                fechaIni = fechaFin

            Next

            'cargar los ultimos dias que le corresponden con los meses restantes
            dias = L_PedidoVacacion_ObtenerDiasVacacion(12 * (i - 1))
            Dim diasFinales As Integer = (mesesRestantes * dias) / 12
            'dias = L_PedidoVacacion_ObtenerDiasVacacion(mesesRestantes)
            fechaFin = Today
            'agregar fila
            row = dt.NewRow()
            row("cbfing") = fechaIni
            row("fechaFin") = fechaFin
            row("diasLibres") = diasFinales
            ''''row("diasUsados") = diasUsadosEnGestion 'CORRECCION DANNY
            row("diasUsados") = diasUsados
            ''''row("saldo") = diasFinales - diasUsadosEnGestion 'CORRECCION DANNY
            row("saldo") = diasFinales - diasUsados
            dt.Rows.Add(row)
            diasTotal = diasTotal + dias
            ''''diasUsadosTotal = diasUsadosTotal + diasUsadosEnGestion
            ''''diasLibresTotal = diasLibresTotal + diasFinales - diasUsadosEnGestion
            diasUsadosTotal = diasUsadosTotal + diasUsados
            diasLibresTotal = diasLibresTotal + diasFinales - diasUsados

        Else 'por el caso de que no halla pasado ni un año
            'cargar los ultimos dias que le corresponden con los meses restantes
            dias = L_PedidoVacacion_ObtenerDiasVacacion(12)
            Dim diasFinales As Integer = (mesesRestantes * dias) / 12
            'dias = L_PedidoVacacion_ObtenerDiasVacacion(mesesRestantes)
            fechaFin = Today
            'agregar fila
            row = dt.NewRow()
            row("cbfing") = fechaIni
            row("fechaFin") = fechaFin
            row("diasLibres") = diasFinales
            row("diasUsados") = diasUsados
            row("saldo") = diasFinales - diasUsados
            dt.Rows.Add(row)
            diasLibresTotal = diasFinales - diasUsados

        End If


        'cargar los dias permitidos o saldo de dias
        Tb_DiasPermitidos.Text = diasLibresTotal
        Tb_DiasPedidos.MaxValue = diasLibresTotal
        Tb_DiasPedidos.MinValue = 1
        Tb_DiasPedidos.Text = 1
        _PCargarDiaVacacionCalendario(Tb_FechaSalida.Value)
        Calendario.Refresh()

        JGr_DetalleFechas.DataSource = dt
        JGr_DetalleFechas.RetrieveStructure()

        'dar formato a las columnas
        With JGr_DetalleFechas.RootTable.Columns("cbfing")
            .Caption = "Fecha Ini"
            .Width = 70
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        End With

        With JGr_DetalleFechas.RootTable.Columns("fechaFin")
            .Caption = "Fecha Fin"
            .Width = 70
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        End With

        With JGr_DetalleFechas.RootTable.Columns("diasLibres")
            .Caption = "Dias Libres"
            .Width = 70
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        End With

        With JGr_DetalleFechas.RootTable.Columns("diasUsados")
            .Caption = "Dias Usados"
            .Width = 70
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        End With

        With JGr_DetalleFechas.RootTable.Columns("saldo")
            .Caption = "Saldo"
            .Width = 70
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        End With

        'Habilitar Filtradores
        With JGr_DetalleFechas
            '.DefaultFilterRowComparison = FilterConditionOperator.Contains
            '.FilterMode = FilterMode.Automatic
            '.FilterRowUpdateMode = FilterRowUpdateMode.WhenValueChanges
            .GroupByBoxVisible = False

            'diseño de la grilla
            .VisualStyle = VisualStyle.Office2007
            '.AllowAddNew = InheritableBoolean.True
        End With


    End Sub

    Private Sub _PCargarBuscador()
        Dim dt As New DataTable
        dt = L_PedidoVacacionCabecera_General(0).Tables(0)

        JGr_Buscador.DataSource = dt
        JGr_Buscador.RetrieveStructure()

        'dar formato a las columnas
        With JGr_Buscador.RootTable.Columns("pgnumi")
            .Caption = "Codigo"
            .Width = 60
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        End With

        With JGr_Buscador.RootTable.Columns("pgcper")
            .Caption = "Cod Persona"
            .Width = 70
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        End With

        With JGr_Buscador.RootTable.Columns("cbdesc")
            .Caption = "Nombre"
            .Width = 180
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
        End With

        With JGr_Buscador.RootTable.Columns("pgfdoc")
            .Caption = "Fecha"
            .Width = 70
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        End With

        'Habilitar Filtradores
        With JGr_Buscador
            .DefaultFilterRowComparison = FilterConditionOperator.Contains
            .FilterMode = FilterMode.Automatic
            .FilterRowUpdateMode = FilterRowUpdateMode.WhenValueChanges
            .GroupByBoxVisible = False

            'diseño de la grilla
            .VisualStyle = VisualStyle.Office2007
        End With

    End Sub

    Private Sub _PCargarComboEmpleados()
        Dim _Ds As New DataSet
        _Ds.Tables.Add(L_prPersonaAyudaTodosGeneral())

        JMc_Persona.DropDownList.Columns.Clear()


        JMc_Persona.DropDownList.Columns.Add(_Ds.Tables(0).Columns("panumi").ToString).Width = 50
        JMc_Persona.DropDownList.Columns(0).Caption = "Código"
        JMc_Persona.DropDownList.Columns.Add(_Ds.Tables(0).Columns("paci").ToString).Width = 70
        JMc_Persona.DropDownList.Columns(1).Caption = "CI"
        JMc_Persona.DropDownList.Columns.Add(_Ds.Tables(0).Columns("panom1").ToString).Width = 250
        JMc_Persona.DropDownList.Columns(2).Caption = "Descripcion"

        JMc_Persona.ValueMember = _Ds.Tables(0).Columns("panumi").ToString
        JMc_Persona.DisplayMember = _Ds.Tables(0).Columns("panom1").ToString
        JMc_Persona.DataSource = _Ds.Tables(0)
        JMc_Persona.Refresh()
    End Sub

    Private Sub _PHabilitar()
        Tb_Fecha.Enabled = True
        Tb_Estado.Enabled = True
        Tb_Obs.Enabled = True
        Tb_DiasPedidos.Enabled = True
        Tb_FechaSalida.Enabled = True

        JMc_Persona.Enabled = True

        btnNuevo.Enabled = False
        btnModificar.Enabled = False
        btnEliminar.Enabled = False
        btnGrabar.Enabled = True

        JGr_Buscador.Enabled = False
    End Sub
    Private Sub _PInhabilitar()
        Tb_Id.Enabled = False
        Tb_Fecha.Enabled = False
        Tb_Estado.Enabled = False
        Tb_Obs.Enabled = False
        Tb_DiasPedidos.Enabled = False
        Tb_DiasPermitidos.Enabled = False
        Tb_FechaIngreso.Enabled = False
        Tb_FechaSalida.Enabled = False

        JMc_Persona.Enabled = False

        btnNuevo.Enabled = True
        btnModificar.Enabled = True
        btnEliminar.Enabled = True
        btnGrabar.Enabled = False

        btnGrabar.Image = My.Resources.GUARDAR


        _PLimpiarErrores()

        JGr_Buscador.Enabled = True

        _Nuevo = False
        _Modificar = False
    End Sub
    Private Sub _PLimpiarErrores()
        MEP.Clear()
        Tb_Fecha.BackColor = Color.White
        Tb_Fecha.BackColor = Color.White
        Tb_Obs.BackColor = Color.White
    End Sub
    Private Sub _PLimpiar()
        Tb_Id.Text = ""
        Tb_Obs.Text = ""
        Tb_DiasPedidos.Text = ""
        Tb_DiasPermitidos.Text = ""
        Tb_Estado.Value = True
        _PLimpiarCalendario()

        JMc_Persona.SelectedIndex = -1

        JGr_DetalleFechas.ClearStructure()

        'aumentado 
        LblPaginacion.Text = ""

    End Sub
    Private Sub _PHabilitarFocus()

        MHighlighterFocus.SetHighlightOnFocus(Tb_Fecha, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
        MHighlighterFocus.SetHighlightOnFocus(Tb_Estado, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
        MHighlighterFocus.SetHighlightOnFocus(Tb_Obs, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
        MHighlighterFocus.SetHighlightOnFocus(JMc_Persona, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)


        Tb_Estado.TabIndex = 1
        JMc_Persona.TabIndex = 2
        Tb_Fecha.TabIndex = 3
        Tb_Obs.TabIndex = 4

    End Sub


    Private Sub _PIniciarTodo()
        'abrir conexion
        'L_abrirConexion()

        Me.Text = "F E R I A D O S"
        Me.WindowState = FormWindowState.Maximized

        'iniciar variables
        SuperTabControlPanelBuscador.Visible = False

        _PCargarComboEmpleados()

        _PInhabilitar()
        _PFiltrar()

        _PHabilitarFocus()

        _PCargarBuscador()



    End Sub

    Private Sub _PFiltrar()
        _Dsencabezado = New DataSet
        _Dsencabezado = L_PedidoVacacionCabecera_General(0)
        '_First = False
        If _Dsencabezado.Tables(0).Rows.Count <> 0 Then
            _Pos = 0
            _PMostrarRegistro(_Pos)
            LblPaginacion.Text = Str(_Pos + 1) + "/" + _Dsencabezado.Tables(0).Rows.Count.ToString
            If _Dsencabezado.Tables(0).Rows.Count > 0 Then
                btnPrimero.Visible = True
                btnAnterior.Visible = True
                btnSiguiente.Visible = True
                btnUltimo.Visible = True
            End If
        End If

    End Sub
    Private Sub _PMostrarRegistro(_N As Integer)

        With _Dsencabezado.Tables(0).Rows(_N)
            Tb_Id.Text = .Item("pgnumi").ToString

            JMc_Persona.Text = .Item("cbdesc").ToString()
            _PCargarDetalleFechas(JMc_Persona.Value)
            _PCargarFeriadosAlCalendario()

            Tb_Fecha.Value = IIf(IsDBNull(.Item("pgfdoc")), Today, .Item("pgfdoc"))
            Tb_Obs.Text = .Item("pgobs").ToString
            Tb_FechaSalida.Value = IIf(IsDBNull(.Item("pgfsal")), Today, .Item("pgfsal"))
            Tb_FechaIngreso.Value = IIf(IsDBNull(.Item("pgfing")), Today, .Item("pgfing"))
            Tb_DiasPedidos.Value = .Item("pgdias")
        End With

    End Sub

    Public Function P_Validar() As Boolean
        Return Not _PValidar()
    End Function
    Private Function _PValidar() As Boolean
        Dim _Error As Boolean = False
        MEP.Clear()
        If Tb_Obs.Text = "" Then
            Tb_Obs.BackColor = Color.Red
            MEP.SetError(Tb_Obs, "Ingrese una observacion!")
            _Error = True
        Else
            Tb_Obs.BackColor = Color.White
            MEP.SetError(Tb_Obs, "")
        End If

        If Tb_DiasPedidos.Text = "" Then
            Tb_DiasPedidos.BackColor = Color.Red
            MEP.SetError(Tb_DiasPedidos, "Ingrese la cantidad de dias de vacacion!")
            _Error = True
        Else
            Tb_DiasPedidos.BackColor = Color.White
            MEP.SetError(Tb_DiasPedidos, "")
        End If

        If JMc_Persona.SelectedIndex < 0 Then
            JMc_Persona.BackColor = Color.Red
            MEP.SetError(JMc_Persona, "Seleccione una persona!")
            _Error = True
        Else
            JMc_Persona.BackColor = Color.White
            MEP.SetError(JMc_Persona, "")
        End If

        MHighlighterFocus.UpdateHighlights()
        Return _Error
    End Function

    Private Sub _PGrabarRegistro()
        Dim _Error As Boolean = False
        If P_Validar() = False Then
            Exit Sub
        End If
        If btnGrabar.Enabled = False Then
            Exit Sub
        End If

        If False Then 'BBtn_Grabar.Tag = 0
            'BBtn_Grabar.Tag = 1
            'BBtn_Grabar.Image = My.Resources.CONFIRMACION
            'BBtn_Grabar.ImageLarge = My.Resources.CONFIRMACION
            'BubbleBar1.Refresh()
            Exit Sub
        Else
            btnGrabar.Tag = 0
            'BBtn_Grabar.Image = My.Resources.GRABAR
            'BBtn_Grabar.ImageLarge = My.Resources.GRABAR
            'BubbleBar1.Refresh()
        End If


        If _Nuevo Then
            L_PedidoVacacionCabecera_Grabar(Tb_Id.Text, JMc_Persona.Value, Tb_Fecha.Value.ToString("yyyy/MM/dd"), IIf(Tb_Estado.Value, "1", "0"), Tb_Obs.Text, Tb_FechaSalida.Value.ToString("yyyy/MM/dd"), Tb_FechaIngreso.Value.ToString("yyyy/MM/dd"), Tb_DiasPedidos.Text)

            'actualizar el grid de buscador
            _PCargarBuscador()

            Tb_Fecha.Focus()
            ToastNotification.Show(Me, "Pedido de Vacacion ".ToUpper + Tb_Id.Text + " Grabado con Exito.".ToUpper, My.Resources.GRABACION_EXITOSA, 5000, eToastGlowColor.Green, eToastPosition.TopCenter)
            _PLimpiar()

        Else
            L_PedidoVacacionCabecera_Modificar(Tb_Id.Text, JMc_Persona.Value, Tb_Fecha.Value.ToString("yyyy/MM/dd"), IIf(Tb_Estado.Value, "1", "0"), Tb_Obs.Text, Tb_FechaSalida.Value.ToString("yyyy/MM/dd"), Tb_FechaIngreso.Value.ToString("yyyy/MM/dd"), Tb_DiasPedidos.Text)

            ToastNotification.Show(Me, "Pedido de Vacacion ".ToUpper + Tb_Id.Text + " Modificado con Exito.".ToUpper, My.Resources.GRABACION_EXITOSA, 5000, eToastGlowColor.Green, eToastPosition.TopCenter)

            'actualizar el grid de buscador
            _PCargarBuscador()

            _Nuevo = False 'aumentado danny
            _PInhabilitar()
            _PFiltrar()

        End If
    End Sub

    Private Sub _PCalcularFechaRegreso()
        Dim i As Integer
        'obtener dias feriados
        Dim dtFeriados As DataTable = L_prFeriadoGeneral(0)
        Dim listFeriados As New List(Of DateTime)
        For i = 0 To dtFeriados.Rows.Count - 1
            Dim fs As String = dtFeriados.Rows(i).Item("pfflib").ToString
            Dim f As DateTime = Convert.ToDateTime(fs)
            listFeriados.Add(f)
        Next

        'calcular la fecha de regreso sin tomar en cuenta los feriados y los sabados y domingos 
        i = 1
        Dim fecha As New DateTime
        fecha = Tb_FechaSalida.Value.ToShortDateString()

        'Limpiar calendario
        _PLimpiarCalendario()
        _PCargarDiaVacacionCalendario(fecha)
        Calendario.Refresh()

        While i <= Tb_DiasPedidos.Text
            If listFeriados.Contains(fecha) = False And (fecha.DayOfWeek = DayOfWeek.Sunday Or fecha.DayOfWeek = DayOfWeek.Saturday) = False Then
                i = i + 1
                _PCargarDiaVacacionCalendario(fecha)
            End If
            fecha = DateAdd(DateInterval.Day, 1, fecha)
        End While

        While listFeriados.Contains(fecha) Or fecha.DayOfWeek = DayOfWeek.Sunday Or fecha.DayOfWeek = DayOfWeek.Saturday
            fecha = DateAdd(DateInterval.Day, 1, fecha)
        End While
        Calendario.Refresh()
        '_PCargarDiaVacacionCalendario(fecha)
        Tb_FechaIngreso.Value = fecha
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
            End If

        Next
    End Sub

    Private Sub _PCargarDiaVacacionCalendario(fecha As Date)
        Dim dia As DayLabel = Calendario.GetDay(fecha)
        If Not dia Is Nothing Then
            dia.TextAlign = eLabelPartAlignment.MiddleLeft
            dia.Tooltip = "Dia Pedido"
            dia.BackgroundStyle.BackColor = Color.LightGreen
        End If
        Calendario.Refresh()
    End Sub

    Private Sub _PLimpiarCalendario()
        'Dim primerDia As Date = Tb_FechaSalida.Value
        Dim primerDia As New Date(Tb_FechaSalida.Value.Year, Tb_FechaSalida.Value.Month, 1)
        Dim i As Integer
        For i = 1 To 31
            Dim dia As DayLabel = Calendario.GetDay(primerDia)
            If Not dia Is Nothing Then
                dia.TextAlign = eLabelPartAlignment.MiddleLeft
                dia.Tooltip = ""
                dia.BackgroundStyle.BackColor = Color.White
            End If
            primerDia = DateAdd(DateInterval.Day, 1, primerDia)
        Next

    End Sub


    Private Sub _PNuevoRegistro()
        _PHabilitar()
        btnNuevo.Enabled = True

        _PLimpiar()
        Tb_Fecha.Focus()
        _Nuevo = True
    End Sub

    Private Sub _PModificarRegistro()
        _Nuevo = False
        _Modificar = True
        '_Modificar = True
        _PHabilitar()
        btnModificar.Enabled = True 'aumentado para q funcione con el modelo de guido
    End Sub

    Private Sub _PEliminarRegistro()
        Dim _Result As MsgBoxResult
        _Result = MsgBox("Esta seguro de Eliminar el Registro?", MsgBoxStyle.YesNo, "Advertencia")
        If _Result = MsgBoxResult.Yes Then
            L_PedidoVacacionCabecera_Borrar(Tb_Id.Text)
            L_PedidoVacacionDetalle_Borrar(Tb_Id.Text)

            _PFiltrar()

            'mi codigo, actualizo el sub
            _Pos = 0
            LblPaginacion.Text = Str(_Pos + 1) + "/" + _Dsencabezado.Tables(0).Rows.Count.ToString
        End If
    End Sub

    Private Sub _PSalirRegistro()
        If btnGrabar.Enabled = True Then
            _PInhabilitar()
            _PFiltrar()
        Else
            Me.Close()
        End If
    End Sub


    Private Sub _PPrimerRegistro()
        _Pos = 0
        _PMostrarRegistro(_Pos)
        LblPaginacion.Text = Str(_Pos + 1) + "/" + _Dsencabezado.Tables(0).Rows.Count.ToString
    End Sub
    Private Sub _PAnteriorRegistro()
        If _Pos > 0 Then
            _Pos = _Pos - 1
            _PMostrarRegistro(_Pos)
            LblPaginacion.Text = Str(_Pos + 1) + "/" + _Dsencabezado.Tables(0).Rows.Count.ToString
        End If
    End Sub
    Private Sub _PSiguienteRegistro()
        If _Pos < _Dsencabezado.Tables(0).Rows.Count - 1 Then
            _Pos = _Pos + 1
            _PMostrarRegistro(_Pos)
            LblPaginacion.Text = Str(_Pos + 1) + "/" + _Dsencabezado.Tables(0).Rows.Count.ToString
        End If
    End Sub
    Private Sub _PUltimoRegistro()
        _Pos = _Dsencabezado.Tables(0).Rows.Count - 1
        _PMostrarRegistro(_Pos)
        LblPaginacion.Text = Str(_Pos + 1) + "/" + _Dsencabezado.Tables(0).Rows.Count.ToString
    End Sub

#End Region


    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        _PNuevoRegistro()
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        _PModificarRegistro()
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        _PEliminarRegistro()
    End Sub

    Private Sub btnGrabar_Click(sender As Object, e As EventArgs) Handles btnGrabar.Click
        _PGrabarRegistro()
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        _PSalirRegistro()
    End Sub

    Private Sub F0_PedidoVacacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _PIniciarTodo()
    End Sub

    Private Sub JMc_Persona_ValueChanged(sender As Object, e As EventArgs) Handles JMc_Persona.ValueChanged
        If _Nuevo = True Or _Modificar = True Then
            If JMc_Persona.SelectedIndex >= 0 Then
                _PCargarDetalleFechas(JMc_Persona.Value)
                _PCargarFeriadosAlCalendario()
            End If
        End If


    End Sub
    Private Sub Tb_FechaSalida_ValueChanged(sender As Object, e As EventArgs) Handles Tb_FechaSalida.ValueChanged
        If _Nuevo = True Or _Modificar = True Then
            'actualizar el calendario
            Calendario.DisplayMonth = Tb_FechaSalida.Value

            'Tb_FechaIngreso.Value = DateAdd(DateInterval.Day, Int(Tb_DiasPedidos.Text), Tb_FechaSalida.Value)
            _PCalcularFechaRegreso()
        End If
    End Sub

    Private Sub Tb_DiasPedidos_ValueChanged(sender As Object, e As EventArgs) Handles Tb_DiasPedidos.ValueChanged
        If _Nuevo = True Or _Modificar = True Then
            If IsNumeric(Tb_DiasPedidos.Text) Then
                'Tb_FechaIngreso.Value = DateAdd(DateInterval.Day, Int(Tb_DiasPedidos.Text), Tb_FechaSalida.Value)
                _PCalcularFechaRegreso()
            Else
                Tb_FechaIngreso.Value = Tb_FechaSalida.Value
            End If
        End If


    End Sub
    Private Sub Calendario_MonthChanged(sender As Object, e As EventArgs) Handles Calendario.MonthChanged
        _PCargarFeriadosAlCalendario()
    End Sub
    Private Sub JGr_DetalleFechas_EditingCell(sender As Object, e As EditingCellEventArgs) Handles JGr_DetalleFechas.EditingCell
        e.Cancel = True
    End Sub
    Private Sub JGr_Buscador_SelectionChanged(sender As Object, e As EventArgs) Handles JGr_Buscador.SelectionChanged
        If JGr_Buscador.Row >= 0 Then
            _Pos = JGr_Buscador.Row
            _PMostrarRegistro(_Pos)
            LblPaginacion.Text = Str(_Pos + 1) + "/" + _Dsencabezado.Tables(0).Rows.Count.ToString
        End If
    End Sub
End Class