<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F0_PagosSocio
    Inherits Modelos.ModeloF0

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F0_PagosSocio))
        Me.Pn1Cabecera = New DevComponents.DotNetBar.PanelEx()
        Me.GroupPanelDatosPago = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.QrFactura = New Gma.QrCodeNet.Encoding.Windows.Forms.QrCodeImgControl()
        Me.chPagoAnho = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.rlMortuoria = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.LabelX8 = New DevComponents.DotNetBar.LabelX()
        Me.Dt2FechaPago = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.LabelX7 = New DevComponents.DotNetBar.LabelX()
        Me.Tb4Cambio = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Bt2Generar = New DevComponents.DotNetBar.ButtonX()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.Tb3NroRecibo = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Tbd1Monto = New DevComponents.Editors.DoubleInput()
        Me.GroupPanelDatosSocio = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.dgjTelefono = New Janus.Windows.GridEX.GridEX()
        Me.rlTipoSocio = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.TbiNroSocio = New DevComponents.Editors.IntegerInput()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.Bt1Buscar = New DevComponents.DotNetBar.ButtonX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.Tb2NombreSocio = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.Dt1FechaIngreso = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.GroupPanelGestionPago = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.tbiGestion = New DevComponents.Editors.IntegerInput()
        Me.LabelX9 = New DevComponents.DotNetBar.LabelX()
        Me.Pn2Detalle = New DevComponents.DotNetBar.PanelEx()
        Me.DgdPagos = New DevComponents.DotNetBar.SuperGrid.SuperGridControl()
        Me.DgdMortuoria = New DevComponents.DotNetBar.SuperGrid.SuperGridControl()
        Me.Dgj1Busqueda = New Janus.Windows.GridEX.GridEX()
        Me.rlAccion = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        CType(Me.SuperTabPrincipal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuperTabPrincipal.SuspendLayout()
        Me.SuperTabControlPanelBuscador.SuspendLayout()
        Me.SuperTabControlPanelRegistro.SuspendLayout()
        Me.PanelSuperior.SuspendLayout()
        Me.PanelInferior.SuspendLayout()
        CType(Me.BubbleBarUsuario, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelToolBar1.SuspendLayout()
        Me.PanelToolBar2.SuspendLayout()
        Me.PanelPrincipal.SuspendLayout()
        Me.PanelUsuario.SuspendLayout()
        Me.PanelNavegacion.SuspendLayout()
        Me.MPanelUserAct.SuspendLayout()
        CType(Me.MEP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Pn1Cabecera.SuspendLayout()
        Me.GroupPanelDatosPago.SuspendLayout()
        CType(Me.QrFactura, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Dt2FechaPago, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Tbd1Monto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanelDatosSocio.SuspendLayout()
        CType(Me.dgjTelefono, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TbiNroSocio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Dt1FechaIngreso, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanelGestionPago.SuspendLayout()
        CType(Me.tbiGestion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Pn2Detalle.SuspendLayout()
        CType(Me.Dgj1Busqueda, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SuperTabPrincipal
        '
        '
        '
        '
        '
        '
        '
        Me.SuperTabPrincipal.ControlBox.CloseBox.Name = ""
        '
        '
        '
        Me.SuperTabPrincipal.ControlBox.MenuBox.Name = ""
        Me.SuperTabPrincipal.ControlBox.Name = ""
        Me.SuperTabPrincipal.ControlBox.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.SuperTabPrincipal.ControlBox.MenuBox, Me.SuperTabPrincipal.ControlBox.CloseBox})
        Me.SuperTabPrincipal.Margin = New System.Windows.Forms.Padding(5)
        Me.SuperTabPrincipal.SelectedTabIndex = 1
        Me.SuperTabPrincipal.Size = New System.Drawing.Size(1312, 814)
        Me.SuperTabPrincipal.Controls.SetChildIndex(Me.SuperTabControlPanelBuscador, 0)
        Me.SuperTabPrincipal.Controls.SetChildIndex(Me.SuperTabControlPanelRegistro, 0)
        '
        'SuperTabControlPanelBuscador
        '
        Me.SuperTabControlPanelBuscador.Controls.Add(Me.Dgj1Busqueda)
        Me.SuperTabControlPanelBuscador.Location = New System.Drawing.Point(0, 28)
        Me.SuperTabControlPanelBuscador.Padding = New System.Windows.Forms.Padding(5)
        Me.SuperTabControlPanelBuscador.Size = New System.Drawing.Size(1179, 662)
        '
        'SuperTabControlPanelRegistro
        '
        Me.SuperTabControlPanelRegistro.Location = New System.Drawing.Point(0, 28)
        Me.SuperTabControlPanelRegistro.Margin = New System.Windows.Forms.Padding(5)
        Me.SuperTabControlPanelRegistro.Size = New System.Drawing.Size(1312, 786)
        Me.SuperTabControlPanelRegistro.Controls.SetChildIndex(Me.PanelSuperior, 0)
        Me.SuperTabControlPanelRegistro.Controls.SetChildIndex(Me.PanelInferior, 0)
        Me.SuperTabControlPanelRegistro.Controls.SetChildIndex(Me.PanelPrincipal, 0)
        '
        'PanelSuperior
        '
        Me.PanelSuperior.Controls.Add(Me.rlAccion)
        Me.PanelSuperior.Margin = New System.Windows.Forms.Padding(5)
        Me.PanelSuperior.Size = New System.Drawing.Size(1312, 89)
        Me.PanelSuperior.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelSuperior.Style.BackColor1.Color = System.Drawing.Color.Yellow
        Me.PanelSuperior.Style.BackColor2.Color = System.Drawing.Color.Khaki
        Me.PanelSuperior.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelSuperior.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelSuperior.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelSuperior.Style.GradientAngle = 90
        Me.PanelSuperior.Controls.SetChildIndex(Me.MRlAccion, 0)
        Me.PanelSuperior.Controls.SetChildIndex(Me.PanelToolBar1, 0)
        Me.PanelSuperior.Controls.SetChildIndex(Me.PanelToolBar2, 0)
        Me.PanelSuperior.Controls.SetChildIndex(Me.rlAccion, 0)
        '
        'PanelInferior
        '
        Me.PanelInferior.Location = New System.Drawing.Point(0, 742)
        Me.PanelInferior.Margin = New System.Windows.Forms.Padding(5)
        Me.PanelInferior.Size = New System.Drawing.Size(1312, 44)
        Me.PanelInferior.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelInferior.Style.BackColor1.Color = System.Drawing.Color.Gold
        Me.PanelInferior.Style.BackColor2.Color = System.Drawing.Color.Gold
        Me.PanelInferior.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelInferior.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelInferior.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelInferior.Style.GradientAngle = 90
        '
        'BubbleBarUsuario
        '
        '
        '
        '
        Me.BubbleBarUsuario.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.BubbleBarUsuario.ButtonBackAreaStyle.BackColor = System.Drawing.Color.Transparent
        Me.BubbleBarUsuario.ButtonBackAreaStyle.BorderBottomWidth = 1
        Me.BubbleBarUsuario.ButtonBackAreaStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.BubbleBarUsuario.ButtonBackAreaStyle.BorderLeftWidth = 1
        Me.BubbleBarUsuario.ButtonBackAreaStyle.BorderRightWidth = 1
        Me.BubbleBarUsuario.ButtonBackAreaStyle.BorderTopWidth = 1
        Me.BubbleBarUsuario.ButtonBackAreaStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.BubbleBarUsuario.ButtonBackAreaStyle.PaddingBottom = 3
        Me.BubbleBarUsuario.ButtonBackAreaStyle.PaddingLeft = 3
        Me.BubbleBarUsuario.ButtonBackAreaStyle.PaddingRight = 3
        Me.BubbleBarUsuario.ButtonBackAreaStyle.PaddingTop = 3
        Me.BubbleBarUsuario.MouseOverTabColors.BorderColor = System.Drawing.SystemColors.Highlight
        Me.BubbleBarUsuario.SelectedTabColors.BorderColor = System.Drawing.Color.Black
        '
        'btnSalir
        '
        '
        'btnGrabar
        '
        '
        'btnEliminar
        '
        '
        'btnModificar
        '
        '
        'btnNuevo
        '
        '
        'PanelToolBar2
        '
        Me.PanelToolBar2.Location = New System.Drawing.Point(1205, 0)
        Me.PanelToolBar2.Margin = New System.Windows.Forms.Padding(5)
        '
        'PanelPrincipal
        '
        Me.PanelPrincipal.Controls.Add(Me.Pn2Detalle)
        Me.PanelPrincipal.Controls.Add(Me.Pn1Cabecera)
        Me.PanelPrincipal.Margin = New System.Windows.Forms.Padding(5)
        Me.PanelPrincipal.Size = New System.Drawing.Size(1312, 653)
        Me.PanelPrincipal.Controls.SetChildIndex(Me.PanelUsuario, 0)
        Me.PanelPrincipal.Controls.SetChildIndex(Me.Pn1Cabecera, 0)
        Me.PanelPrincipal.Controls.SetChildIndex(Me.Pn2Detalle, 0)
        '
        'btnUltimo
        '
        Me.btnUltimo.Location = New System.Drawing.Point(171, 0)
        '
        'btnSiguiente
        '
        '
        'btnAnterior
        '
        '
        'btnPrimero
        '
        '
        'MPanelUserAct
        '
        Me.MPanelUserAct.Location = New System.Drawing.Point(1045, 0)
        Me.MPanelUserAct.Margin = New System.Windows.Forms.Padding(5)
        '
        'MRlAccion
        '
        '
        '
        '
        Me.MRlAccion.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'Pn1Cabecera
        '
        Me.Pn1Cabecera.CanvasColor = System.Drawing.SystemColors.Control
        Me.Pn1Cabecera.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Pn1Cabecera.Controls.Add(Me.GroupPanelDatosPago)
        Me.Pn1Cabecera.Controls.Add(Me.GroupPanelDatosSocio)
        Me.Pn1Cabecera.Controls.Add(Me.GroupPanelGestionPago)
        Me.Pn1Cabecera.DisabledBackColor = System.Drawing.Color.Empty
        Me.Pn1Cabecera.Dock = System.Windows.Forms.DockStyle.Left
        Me.Pn1Cabecera.Location = New System.Drawing.Point(0, 0)
        Me.Pn1Cabecera.Margin = New System.Windows.Forms.Padding(4)
        Me.Pn1Cabecera.Name = "Pn1Cabecera"
        Me.Pn1Cabecera.Size = New System.Drawing.Size(579, 653)
        Me.Pn1Cabecera.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.Pn1Cabecera.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Pn1Cabecera.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Pn1Cabecera.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.Pn1Cabecera.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.Pn1Cabecera.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.Pn1Cabecera.Style.GradientAngle = 90
        Me.Pn1Cabecera.TabIndex = 20
        '
        'GroupPanelDatosPago
        '
        Me.GroupPanelDatosPago.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanelDatosPago.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanelDatosPago.Controls.Add(Me.QrFactura)
        Me.GroupPanelDatosPago.Controls.Add(Me.chPagoAnho)
        Me.GroupPanelDatosPago.Controls.Add(Me.rlMortuoria)
        Me.GroupPanelDatosPago.Controls.Add(Me.LabelX8)
        Me.GroupPanelDatosPago.Controls.Add(Me.Dt2FechaPago)
        Me.GroupPanelDatosPago.Controls.Add(Me.LabelX7)
        Me.GroupPanelDatosPago.Controls.Add(Me.Tb4Cambio)
        Me.GroupPanelDatosPago.Controls.Add(Me.Bt2Generar)
        Me.GroupPanelDatosPago.Controls.Add(Me.LabelX6)
        Me.GroupPanelDatosPago.Controls.Add(Me.LabelX5)
        Me.GroupPanelDatosPago.Controls.Add(Me.Tb3NroRecibo)
        Me.GroupPanelDatosPago.Controls.Add(Me.Tbd1Monto)
        Me.GroupPanelDatosPago.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanelDatosPago.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupPanelDatosPago.Location = New System.Drawing.Point(0, 410)
        Me.GroupPanelDatosPago.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupPanelDatosPago.Name = "GroupPanelDatosPago"
        Me.GroupPanelDatosPago.Size = New System.Drawing.Size(579, 243)
        '
        '
        '
        Me.GroupPanelDatosPago.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GroupPanelDatosPago.Style.BackColorGradientAngle = 90
        Me.GroupPanelDatosPago.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.GroupPanelDatosPago.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanelDatosPago.Style.BorderBottomWidth = 1
        Me.GroupPanelDatosPago.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanelDatosPago.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanelDatosPago.Style.BorderLeftWidth = 1
        Me.GroupPanelDatosPago.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanelDatosPago.Style.BorderRightWidth = 1
        Me.GroupPanelDatosPago.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanelDatosPago.Style.BorderTopWidth = 1
        Me.GroupPanelDatosPago.Style.CornerDiameter = 4
        Me.GroupPanelDatosPago.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanelDatosPago.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanelDatosPago.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanelDatosPago.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanelDatosPago.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanelDatosPago.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanelDatosPago.TabIndex = 2
        Me.GroupPanelDatosPago.Text = "DATOS DE PAGO"
        '
        'QrFactura
        '
        Me.QrFactura.ErrorCorrectLevel = Gma.QrCodeNet.Encoding.ErrorCorrectionLevel.M
        Me.QrFactura.Image = CType(resources.GetObject("QrFactura.Image"), System.Drawing.Image)
        Me.QrFactura.Location = New System.Drawing.Point(399, 172)
        Me.QrFactura.Name = "QrFactura"
        Me.QrFactura.QuietZoneModule = Gma.QrCodeNet.Encoding.Windows.Render.QuietZoneModules.Two
        Me.QrFactura.Size = New System.Drawing.Size(42, 35)
        Me.QrFactura.TabIndex = 11
        Me.QrFactura.TabStop = False
        Me.QrFactura.Text = "QrCodeImgControl1"
        Me.QrFactura.Visible = False
        '
        'chPagoAnho
        '
        '
        '
        '
        Me.chPagoAnho.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.chPagoAnho.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chPagoAnho.Location = New System.Drawing.Point(300, 4)
        Me.chPagoAnho.Margin = New System.Windows.Forms.Padding(4)
        Me.chPagoAnho.Name = "chPagoAnho"
        Me.chPagoAnho.Size = New System.Drawing.Size(259, 28)
        Me.chPagoAnho.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.chPagoAnho.TabIndex = 10
        Me.chPagoAnho.Text = "Pagar un año completo"
        '
        'rlMortuoria
        '
        '
        '
        '
        Me.rlMortuoria.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.rlMortuoria.Font = New System.Drawing.Font("Microsoft Sans Serif", 22.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rlMortuoria.ForeColor = System.Drawing.Color.Black
        Me.rlMortuoria.Location = New System.Drawing.Point(76, 158)
        Me.rlMortuoria.Margin = New System.Windows.Forms.Padding(4)
        Me.rlMortuoria.Name = "rlMortuoria"
        Me.rlMortuoria.Size = New System.Drawing.Size(403, 49)
        Me.rlMortuoria.TabIndex = 8
        Me.rlMortuoria.Text = "<b><font size=""+10""><font color=""#FF0000""></font></font></b>"
        '
        'LabelX8
        '
        '
        '
        '
        Me.LabelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX8.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX8.Location = New System.Drawing.Point(4, 75)
        Me.LabelX8.Margin = New System.Windows.Forms.Padding(4)
        Me.LabelX8.Name = "LabelX8"
        Me.LabelX8.Size = New System.Drawing.Size(147, 28)
        Me.LabelX8.TabIndex = 6
        Me.LabelX8.Text = "Fecha Pago:"
        '
        'Dt2FechaPago
        '
        '
        '
        '
        Me.Dt2FechaPago.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Dt2FechaPago.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dt2FechaPago.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.Dt2FechaPago.ButtonDropDown.Visible = True
        Me.Dt2FechaPago.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Dt2FechaPago.IsPopupCalendarOpen = False
        Me.Dt2FechaPago.Location = New System.Drawing.Point(159, 75)
        Me.Dt2FechaPago.Margin = New System.Windows.Forms.Padding(4)
        '
        '
        '
        '
        '
        '
        Me.Dt2FechaPago.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dt2FechaPago.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.Dt2FechaPago.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.Dt2FechaPago.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.Dt2FechaPago.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.Dt2FechaPago.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.Dt2FechaPago.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Dt2FechaPago.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.Dt2FechaPago.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.Dt2FechaPago.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dt2FechaPago.MonthCalendar.DisplayMonth = New Date(2016, 12, 1, 0, 0, 0, 0)
        Me.Dt2FechaPago.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday
        '
        '
        '
        Me.Dt2FechaPago.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Dt2FechaPago.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.Dt2FechaPago.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Dt2FechaPago.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dt2FechaPago.MonthCalendar.TodayButtonVisible = True
        Me.Dt2FechaPago.Name = "Dt2FechaPago"
        Me.Dt2FechaPago.Size = New System.Drawing.Size(133, 26)
        Me.Dt2FechaPago.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Dt2FechaPago.TabIndex = 2
        '
        'LabelX7
        '
        '
        '
        '
        Me.LabelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX7.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX7.Location = New System.Drawing.Point(4, 111)
        Me.LabelX7.Margin = New System.Windows.Forms.Padding(4)
        Me.LabelX7.Name = "LabelX7"
        Me.LabelX7.Size = New System.Drawing.Size(147, 28)
        Me.LabelX7.TabIndex = 7
        Me.LabelX7.Text = "Cambio:"
        '
        'Tb4Cambio
        '
        '
        '
        '
        Me.Tb4Cambio.Border.Class = "TextBoxBorder"
        Me.Tb4Cambio.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Tb4Cambio.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tb4Cambio.Location = New System.Drawing.Point(159, 111)
        Me.Tb4Cambio.Margin = New System.Windows.Forms.Padding(4)
        Me.Tb4Cambio.Name = "Tb4Cambio"
        Me.Tb4Cambio.PreventEnterBeep = True
        Me.Tb4Cambio.Size = New System.Drawing.Size(133, 26)
        Me.Tb4Cambio.TabIndex = 9
        Me.Tb4Cambio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Bt2Generar
        '
        Me.Bt2Generar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Bt2Generar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Bt2Generar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Bt2Generar.Image = Global.Presentacion.My.Resources.Resources.FECHA_SIG
        Me.Bt2Generar.ImageFixedSize = New System.Drawing.Size(75, 75)
        Me.Bt2Generar.Location = New System.Drawing.Point(300, 39)
        Me.Bt2Generar.Margin = New System.Windows.Forms.Padding(4)
        Me.Bt2Generar.Name = "Bt2Generar"
        Me.Bt2Generar.Size = New System.Drawing.Size(259, 100)
        Me.Bt2Generar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bt2Generar.TabIndex = 3
        Me.Bt2Generar.Text = "Iniciar Pagos"
        '
        'LabelX6
        '
        '
        '
        '
        Me.LabelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX6.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX6.Location = New System.Drawing.Point(4, 39)
        Me.LabelX6.Margin = New System.Windows.Forms.Padding(4)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(147, 28)
        Me.LabelX6.TabIndex = 5
        Me.LabelX6.Text = "Nro. Recibo:"
        '
        'LabelX5
        '
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX5.Location = New System.Drawing.Point(4, 4)
        Me.LabelX5.Margin = New System.Windows.Forms.Padding(4)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(147, 28)
        Me.LabelX5.TabIndex = 4
        Me.LabelX5.Text = "Monto:"
        '
        'Tb3NroRecibo
        '
        '
        '
        '
        Me.Tb3NroRecibo.Border.Class = "TextBoxBorder"
        Me.Tb3NroRecibo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Tb3NroRecibo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tb3NroRecibo.Location = New System.Drawing.Point(159, 39)
        Me.Tb3NroRecibo.Margin = New System.Windows.Forms.Padding(4)
        Me.Tb3NroRecibo.Name = "Tb3NroRecibo"
        Me.Tb3NroRecibo.PreventEnterBeep = True
        Me.Tb3NroRecibo.Size = New System.Drawing.Size(133, 26)
        Me.Tb3NroRecibo.TabIndex = 1
        Me.Tb3NroRecibo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Tbd1Monto
        '
        '
        '
        '
        Me.Tbd1Monto.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Tbd1Monto.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Tbd1Monto.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.Tbd1Monto.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tbd1Monto.Increment = 1.0R
        Me.Tbd1Monto.Location = New System.Drawing.Point(159, 4)
        Me.Tbd1Monto.Margin = New System.Windows.Forms.Padding(4)
        Me.Tbd1Monto.Name = "Tbd1Monto"
        Me.Tbd1Monto.Size = New System.Drawing.Size(133, 26)
        Me.Tbd1Monto.TabIndex = 0
        '
        'GroupPanelDatosSocio
        '
        Me.GroupPanelDatosSocio.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanelDatosSocio.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanelDatosSocio.Controls.Add(Me.dgjTelefono)
        Me.GroupPanelDatosSocio.Controls.Add(Me.rlTipoSocio)
        Me.GroupPanelDatosSocio.Controls.Add(Me.TbiNroSocio)
        Me.GroupPanelDatosSocio.Controls.Add(Me.LabelX1)
        Me.GroupPanelDatosSocio.Controls.Add(Me.Bt1Buscar)
        Me.GroupPanelDatosSocio.Controls.Add(Me.LabelX2)
        Me.GroupPanelDatosSocio.Controls.Add(Me.Tb2NombreSocio)
        Me.GroupPanelDatosSocio.Controls.Add(Me.LabelX4)
        Me.GroupPanelDatosSocio.Controls.Add(Me.LabelX3)
        Me.GroupPanelDatosSocio.Controls.Add(Me.Dt1FechaIngreso)
        Me.GroupPanelDatosSocio.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanelDatosSocio.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupPanelDatosSocio.Location = New System.Drawing.Point(0, 64)
        Me.GroupPanelDatosSocio.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupPanelDatosSocio.Name = "GroupPanelDatosSocio"
        Me.GroupPanelDatosSocio.Size = New System.Drawing.Size(579, 346)
        '
        '
        '
        Me.GroupPanelDatosSocio.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GroupPanelDatosSocio.Style.BackColorGradientAngle = 90
        Me.GroupPanelDatosSocio.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.GroupPanelDatosSocio.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanelDatosSocio.Style.BorderBottomWidth = 1
        Me.GroupPanelDatosSocio.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanelDatosSocio.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanelDatosSocio.Style.BorderLeftWidth = 1
        Me.GroupPanelDatosSocio.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanelDatosSocio.Style.BorderRightWidth = 1
        Me.GroupPanelDatosSocio.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanelDatosSocio.Style.BorderTopWidth = 1
        Me.GroupPanelDatosSocio.Style.CornerDiameter = 4
        Me.GroupPanelDatosSocio.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanelDatosSocio.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanelDatosSocio.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanelDatosSocio.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanelDatosSocio.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanelDatosSocio.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanelDatosSocio.TabIndex = 1
        Me.GroupPanelDatosSocio.Text = "DATOS DE SOCIO"
        '
        'dgjTelefono
        '
        Me.dgjTelefono.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgjTelefono.Location = New System.Drawing.Point(159, 111)
        Me.dgjTelefono.Margin = New System.Windows.Forms.Padding(4)
        Me.dgjTelefono.Name = "dgjTelefono"
        Me.dgjTelefono.Size = New System.Drawing.Size(400, 148)
        Me.dgjTelefono.TabIndex = 8
        '
        'rlTipoSocio
        '
        '
        '
        '
        Me.rlTipoSocio.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.rlTipoSocio.Font = New System.Drawing.Font("Microsoft Sans Serif", 22.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rlTipoSocio.ForeColor = System.Drawing.Color.Black
        Me.rlTipoSocio.Location = New System.Drawing.Point(4, 266)
        Me.rlTipoSocio.Margin = New System.Windows.Forms.Padding(4)
        Me.rlTipoSocio.Name = "rlTipoSocio"
        Me.rlTipoSocio.Size = New System.Drawing.Size(555, 49)
        Me.rlTipoSocio.TabIndex = 5
        Me.rlTipoSocio.Text = "<b><font size=""+10""><font color=""#FF0000""></font></font></b>"
        '
        'TbiNroSocio
        '
        '
        '
        '
        Me.TbiNroSocio.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.TbiNroSocio.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TbiNroSocio.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.TbiNroSocio.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TbiNroSocio.Location = New System.Drawing.Point(159, 4)
        Me.TbiNroSocio.Margin = New System.Windows.Forms.Padding(4)
        Me.TbiNroSocio.MinValue = 0
        Me.TbiNroSocio.Name = "TbiNroSocio"
        Me.TbiNroSocio.Size = New System.Drawing.Size(133, 26)
        Me.TbiNroSocio.TabIndex = 0
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX1.Location = New System.Drawing.Point(4, 4)
        Me.LabelX1.Margin = New System.Windows.Forms.Padding(4)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(147, 28)
        Me.LabelX1.TabIndex = 1
        Me.LabelX1.Text = "Número de Socio:"
        '
        'Bt1Buscar
        '
        Me.Bt1Buscar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Bt1Buscar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Bt1Buscar.Image = CType(resources.GetObject("Bt1Buscar.Image"), System.Drawing.Image)
        Me.Bt1Buscar.ImageFixedSize = New System.Drawing.Size(20, 20)
        Me.Bt1Buscar.Location = New System.Drawing.Point(292, 4)
        Me.Bt1Buscar.Margin = New System.Windows.Forms.Padding(4)
        Me.Bt1Buscar.Name = "Bt1Buscar"
        Me.Bt1Buscar.Size = New System.Drawing.Size(31, 28)
        Me.Bt1Buscar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bt1Buscar.TabIndex = 9
        '
        'LabelX2
        '
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX2.Location = New System.Drawing.Point(4, 39)
        Me.LabelX2.Margin = New System.Windows.Forms.Padding(4)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(147, 28)
        Me.LabelX2.TabIndex = 2
        Me.LabelX2.Text = "Nombre:"
        '
        'Tb2NombreSocio
        '
        '
        '
        '
        Me.Tb2NombreSocio.Border.Class = "TextBoxBorder"
        Me.Tb2NombreSocio.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Tb2NombreSocio.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tb2NombreSocio.Location = New System.Drawing.Point(159, 39)
        Me.Tb2NombreSocio.Margin = New System.Windows.Forms.Padding(4)
        Me.Tb2NombreSocio.Name = "Tb2NombreSocio"
        Me.Tb2NombreSocio.PreventEnterBeep = True
        Me.Tb2NombreSocio.Size = New System.Drawing.Size(400, 26)
        Me.Tb2NombreSocio.TabIndex = 6
        '
        'LabelX4
        '
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX4.Location = New System.Drawing.Point(4, 111)
        Me.LabelX4.Margin = New System.Windows.Forms.Padding(4)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(147, 28)
        Me.LabelX4.TabIndex = 4
        Me.LabelX4.Text = "Teléfonos:"
        '
        'LabelX3
        '
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX3.Location = New System.Drawing.Point(4, 75)
        Me.LabelX3.Margin = New System.Windows.Forms.Padding(4)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(147, 28)
        Me.LabelX3.TabIndex = 3
        Me.LabelX3.Text = "Fecha Ingreso:"
        '
        'Dt1FechaIngreso
        '
        '
        '
        '
        Me.Dt1FechaIngreso.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Dt1FechaIngreso.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dt1FechaIngreso.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.Dt1FechaIngreso.ButtonDropDown.Visible = True
        Me.Dt1FechaIngreso.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Dt1FechaIngreso.IsPopupCalendarOpen = False
        Me.Dt1FechaIngreso.Location = New System.Drawing.Point(159, 75)
        Me.Dt1FechaIngreso.Margin = New System.Windows.Forms.Padding(4)
        '
        '
        '
        '
        '
        '
        Me.Dt1FechaIngreso.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dt1FechaIngreso.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.Dt1FechaIngreso.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.Dt1FechaIngreso.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.Dt1FechaIngreso.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.Dt1FechaIngreso.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.Dt1FechaIngreso.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Dt1FechaIngreso.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.Dt1FechaIngreso.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.Dt1FechaIngreso.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dt1FechaIngreso.MonthCalendar.DisplayMonth = New Date(2016, 12, 1, 0, 0, 0, 0)
        Me.Dt1FechaIngreso.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday
        '
        '
        '
        Me.Dt1FechaIngreso.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Dt1FechaIngreso.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.Dt1FechaIngreso.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Dt1FechaIngreso.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dt1FechaIngreso.MonthCalendar.TodayButtonVisible = True
        Me.Dt1FechaIngreso.Name = "Dt1FechaIngreso"
        Me.Dt1FechaIngreso.Size = New System.Drawing.Size(133, 26)
        Me.Dt1FechaIngreso.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Dt1FechaIngreso.TabIndex = 7
        '
        'GroupPanelGestionPago
        '
        Me.GroupPanelGestionPago.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanelGestionPago.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanelGestionPago.Controls.Add(Me.tbiGestion)
        Me.GroupPanelGestionPago.Controls.Add(Me.LabelX9)
        Me.GroupPanelGestionPago.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanelGestionPago.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupPanelGestionPago.Location = New System.Drawing.Point(0, 0)
        Me.GroupPanelGestionPago.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupPanelGestionPago.Name = "GroupPanelGestionPago"
        Me.GroupPanelGestionPago.Size = New System.Drawing.Size(579, 64)
        '
        '
        '
        Me.GroupPanelGestionPago.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GroupPanelGestionPago.Style.BackColorGradientAngle = 90
        Me.GroupPanelGestionPago.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.GroupPanelGestionPago.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanelGestionPago.Style.BorderBottomWidth = 1
        Me.GroupPanelGestionPago.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanelGestionPago.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanelGestionPago.Style.BorderLeftWidth = 1
        Me.GroupPanelGestionPago.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanelGestionPago.Style.BorderRightWidth = 1
        Me.GroupPanelGestionPago.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanelGestionPago.Style.BorderTopWidth = 1
        Me.GroupPanelGestionPago.Style.CornerDiameter = 4
        Me.GroupPanelGestionPago.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanelGestionPago.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanelGestionPago.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanelGestionPago.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanelGestionPago.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanelGestionPago.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanelGestionPago.TabIndex = 0
        Me.GroupPanelGestionPago.Text = "GESTIÓN DE PAGO"
        '
        'tbiGestion
        '
        '
        '
        '
        Me.tbiGestion.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.tbiGestion.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbiGestion.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.tbiGestion.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbiGestion.Location = New System.Drawing.Point(159, 4)
        Me.tbiGestion.Margin = New System.Windows.Forms.Padding(4)
        Me.tbiGestion.MaxValue = 9999
        Me.tbiGestion.MinValue = 2017
        Me.tbiGestion.Name = "tbiGestion"
        Me.tbiGestion.Size = New System.Drawing.Size(133, 26)
        Me.tbiGestion.TabIndex = 0
        Me.tbiGestion.Value = 2017
        '
        'LabelX9
        '
        '
        '
        '
        Me.LabelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX9.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX9.Location = New System.Drawing.Point(4, 4)
        Me.LabelX9.Margin = New System.Windows.Forms.Padding(4)
        Me.LabelX9.Name = "LabelX9"
        Me.LabelX9.Size = New System.Drawing.Size(147, 28)
        Me.LabelX9.TabIndex = 1
        Me.LabelX9.Text = "Gestión:"
        '
        'Pn2Detalle
        '
        Me.Pn2Detalle.CanvasColor = System.Drawing.SystemColors.Control
        Me.Pn2Detalle.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Pn2Detalle.Controls.Add(Me.DgdPagos)
        Me.Pn2Detalle.Controls.Add(Me.DgdMortuoria)
        Me.Pn2Detalle.DisabledBackColor = System.Drawing.Color.Empty
        Me.Pn2Detalle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Pn2Detalle.Location = New System.Drawing.Point(579, 0)
        Me.Pn2Detalle.Margin = New System.Windows.Forms.Padding(4)
        Me.Pn2Detalle.Name = "Pn2Detalle"
        Me.Pn2Detalle.Padding = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.Pn2Detalle.Size = New System.Drawing.Size(733, 653)
        Me.Pn2Detalle.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.Pn2Detalle.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Pn2Detalle.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Pn2Detalle.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.Pn2Detalle.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.Pn2Detalle.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.Pn2Detalle.Style.GradientAngle = 90
        Me.Pn2Detalle.TabIndex = 27
        '
        'DgdPagos
        '
        Me.DgdPagos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgdPagos.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed
        Me.DgdPagos.Location = New System.Drawing.Point(7, 6)
        Me.DgdPagos.Margin = New System.Windows.Forms.Padding(4)
        Me.DgdPagos.Name = "DgdPagos"
        Me.DgdPagos.Size = New System.Drawing.Size(719, 530)
        Me.DgdPagos.TabIndex = 0
        Me.DgdPagos.Text = "SuperGridControl1"
        '
        'DgdMortuoria
        '
        Me.DgdMortuoria.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.DgdMortuoria.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed
        Me.DgdMortuoria.Location = New System.Drawing.Point(7, 536)
        Me.DgdMortuoria.Margin = New System.Windows.Forms.Padding(4)
        Me.DgdMortuoria.Name = "DgdMortuoria"
        Me.DgdMortuoria.Size = New System.Drawing.Size(719, 111)
        Me.DgdMortuoria.TabIndex = 1
        Me.DgdMortuoria.Text = "SuperGridControl1"
        '
        'Dgj1Busqueda
        '
        Me.Dgj1Busqueda.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Dgj1Busqueda.Location = New System.Drawing.Point(5, 5)
        Me.Dgj1Busqueda.Margin = New System.Windows.Forms.Padding(4)
        Me.Dgj1Busqueda.Name = "Dgj1Busqueda"
        Me.Dgj1Busqueda.Size = New System.Drawing.Size(1169, 652)
        Me.Dgj1Busqueda.TabIndex = 0
        '
        'rlAccion
        '
        '
        '
        '
        Me.rlAccion.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.rlAccion.Font = New System.Drawing.Font("Microsoft Sans Serif", 22.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rlAccion.ForeColor = System.Drawing.Color.Black
        Me.rlAccion.Location = New System.Drawing.Point(509, 7)
        Me.rlAccion.Margin = New System.Windows.Forms.Padding(4)
        Me.rlAccion.Name = "rlAccion"
        Me.rlAccion.Size = New System.Drawing.Size(267, 74)
        Me.rlAccion.TabIndex = 10
        Me.rlAccion.Text = "<b><font size=""+10""><font color=""#FF0000""></font></font></b>"
        '
        'F0_PagosSocio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1312, 814)
        Me.Margin = New System.Windows.Forms.Padding(5)
        Me.Name = "F0_PagosSocio"
        Me.Text = "F0_PagosSocio"
        Me.Controls.SetChildIndex(Me.SuperTabPrincipal, 0)
        CType(Me.SuperTabPrincipal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SuperTabPrincipal.ResumeLayout(False)
        Me.SuperTabControlPanelBuscador.ResumeLayout(False)
        Me.SuperTabControlPanelRegistro.ResumeLayout(False)
        Me.PanelSuperior.ResumeLayout(False)
        Me.PanelInferior.ResumeLayout(False)
        CType(Me.BubbleBarUsuario, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelToolBar1.ResumeLayout(False)
        Me.PanelToolBar2.ResumeLayout(False)
        Me.PanelPrincipal.ResumeLayout(False)
        Me.PanelUsuario.ResumeLayout(False)
        Me.PanelUsuario.PerformLayout()
        Me.PanelNavegacion.ResumeLayout(False)
        Me.MPanelUserAct.ResumeLayout(False)
        Me.MPanelUserAct.PerformLayout()
        CType(Me.MEP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Pn1Cabecera.ResumeLayout(False)
        Me.GroupPanelDatosPago.ResumeLayout(False)
        CType(Me.QrFactura, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Dt2FechaPago, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Tbd1Monto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanelDatosSocio.ResumeLayout(False)
        CType(Me.dgjTelefono, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TbiNroSocio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Dt1FechaIngreso, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanelGestionPago.ResumeLayout(False)
        CType(Me.tbiGestion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Pn2Detalle.ResumeLayout(False)
        CType(Me.Dgj1Busqueda, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Pn1Cabecera As DevComponents.DotNetBar.PanelEx
    Friend WithEvents Pn2Detalle As DevComponents.DotNetBar.PanelEx
    Friend WithEvents Dgj1Busqueda As Janus.Windows.GridEX.GridEX
    Friend WithEvents DgdPagos As DevComponents.DotNetBar.SuperGrid.SuperGridControl
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Dt1FechaIngreso As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Tb2NombreSocio As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Bt1Buscar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents rlAccion As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents GroupPanelDatosPago As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Bt2Generar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Tb3NroRecibo As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Tbd1Monto As DevComponents.Editors.DoubleInput
    Friend WithEvents GroupPanelDatosSocio As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents LabelX7 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Tb4Cambio As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX8 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Dt2FechaPago As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents DgdMortuoria As DevComponents.DotNetBar.SuperGrid.SuperGridControl
    Friend WithEvents TbiNroSocio As DevComponents.Editors.IntegerInput
    Friend WithEvents rlMortuoria As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents GroupPanelGestionPago As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents tbiGestion As DevComponents.Editors.IntegerInput
    Friend WithEvents LabelX9 As DevComponents.DotNetBar.LabelX
    Friend WithEvents rlTipoSocio As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents chPagoAnho As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents dgjTelefono As Janus.Windows.GridEX.GridEX
    Friend WithEvents QrFactura As Gma.QrCodeNet.Encoding.Windows.Forms.QrCodeImgControl
End Class
