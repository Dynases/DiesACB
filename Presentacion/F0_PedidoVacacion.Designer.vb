<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F0_PedidoVacacion
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
        Dim JMc_Persona_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F0_PedidoVacacion))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupPanel2 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.JGr_DetalleFechas = New Janus.Windows.GridEX.GridEX()
        Me.GroupPanelCalen = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Calendario = New DevComponents.Editors.DateTimeAdv.MonthCalendarAdv()
        Me.GroupPanel3 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Tb_DiasPedidos = New DevComponents.Editors.IntegerInput()
        Me.Tb_DiasPermitidos = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX9 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX8 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX7 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        Me.Tb_FechaIngreso = New System.Windows.Forms.DateTimePicker()
        Me.Tb_FechaSalida = New System.Windows.Forms.DateTimePicker()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.Tb_Id = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.JMc_Persona = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.Tb_Fecha = New System.Windows.Forms.DateTimePicker()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.Tb_Estado = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.Tb_Obs = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.JGr_Buscador = New Janus.Windows.GridEX.GridEX()
        CType(Me.SuperTabPrincipal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuperTabPrincipal.SuspendLayout()
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
        Me.Panel1.SuspendLayout()
        Me.GroupPanel2.SuspendLayout()
        CType(Me.JGr_DetalleFechas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanelCalen.SuspendLayout()
        Me.GroupPanel3.SuspendLayout()
        CType(Me.Tb_DiasPedidos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.JMc_Persona, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel1.SuspendLayout()
        CType(Me.JGr_Buscador, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.SuperTabPrincipal.Controls.SetChildIndex(Me.SuperTabControlPanelBuscador, 0)
        Me.SuperTabPrincipal.Controls.SetChildIndex(Me.SuperTabControlPanelRegistro, 0)
        Me.SuperTabControlPanelRegistro.Controls.SetChildIndex(Me.PanelSuperior, 0)
        Me.SuperTabControlPanelRegistro.Controls.SetChildIndex(Me.PanelInferior, 0)
        Me.SuperTabControlPanelRegistro.Controls.SetChildIndex(Me.PanelPrincipal, 0)
        '
        'PanelSuperior
        '
        Me.PanelSuperior.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelSuperior.Style.BackColor1.Color = System.Drawing.Color.Yellow
        Me.PanelSuperior.Style.BackColor2.Color = System.Drawing.Color.Khaki
        Me.PanelSuperior.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelSuperior.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelSuperior.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelSuperior.Style.GradientAngle = 90
        '
        'PanelInferior
        '
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
        'PanelPrincipal
        '
        Me.PanelPrincipal.Controls.Add(Me.GroupPanel1)
        Me.PanelPrincipal.Controls.Add(Me.Panel1)
        Me.PanelPrincipal.Controls.SetChildIndex(Me.PanelUsuario, 0)
        Me.PanelPrincipal.Controls.SetChildIndex(Me.Panel1, 0)
        Me.PanelPrincipal.Controls.SetChildIndex(Me.GroupPanel1, 0)
        '
        'PanelUsuario
        '
        Me.PanelUsuario.Location = New System.Drawing.Point(652, 3)
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.GroupPanel2)
        Me.Panel1.Controls.Add(Me.GroupPanelCalen)
        Me.Panel1.Controls.Add(Me.GroupPanel3)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(884, 202)
        Me.Panel1.TabIndex = 20
        '
        'GroupPanel2
        '
        Me.GroupPanel2.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel2.Controls.Add(Me.JGr_DetalleFechas)
        Me.GroupPanel2.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupPanel2.Location = New System.Drawing.Point(823, 0)
        Me.GroupPanel2.Name = "GroupPanel2"
        Me.GroupPanel2.Size = New System.Drawing.Size(61, 202)
        '
        '
        '
        Me.GroupPanel2.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GroupPanel2.Style.BackColorGradientAngle = 90
        Me.GroupPanel2.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.GroupPanel2.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderBottomWidth = 1
        Me.GroupPanel2.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanel2.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderLeftWidth = 1
        Me.GroupPanel2.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderRightWidth = 1
        Me.GroupPanel2.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderTopWidth = 1
        Me.GroupPanel2.Style.CornerDiameter = 4
        Me.GroupPanel2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel2.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel2.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanel2.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanel2.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel2.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel2.TabIndex = 29
        Me.GroupPanel2.Text = "DETALLE DE FECHAS"
        '
        'JGr_DetalleFechas
        '
        Me.JGr_DetalleFechas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.JGr_DetalleFechas.Location = New System.Drawing.Point(0, 0)
        Me.JGr_DetalleFechas.Name = "JGr_DetalleFechas"
        Me.JGr_DetalleFechas.Size = New System.Drawing.Size(55, 179)
        Me.JGr_DetalleFechas.TabIndex = 0
        '
        'GroupPanelCalen
        '
        Me.GroupPanelCalen.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanelCalen.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanelCalen.Controls.Add(Me.Calendario)
        Me.GroupPanelCalen.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanelCalen.Dock = System.Windows.Forms.DockStyle.Left
        Me.GroupPanelCalen.Location = New System.Drawing.Point(646, 0)
        Me.GroupPanelCalen.Name = "GroupPanelCalen"
        Me.GroupPanelCalen.Size = New System.Drawing.Size(177, 202)
        '
        '
        '
        Me.GroupPanelCalen.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GroupPanelCalen.Style.BackColorGradientAngle = 90
        Me.GroupPanelCalen.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.GroupPanelCalen.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanelCalen.Style.BorderBottomWidth = 1
        Me.GroupPanelCalen.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanelCalen.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanelCalen.Style.BorderLeftWidth = 1
        Me.GroupPanelCalen.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanelCalen.Style.BorderRightWidth = 1
        Me.GroupPanelCalen.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanelCalen.Style.BorderTopWidth = 1
        Me.GroupPanelCalen.Style.CornerDiameter = 4
        Me.GroupPanelCalen.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanelCalen.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanelCalen.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanelCalen.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanelCalen.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanelCalen.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanelCalen.TabIndex = 32
        Me.GroupPanelCalen.Text = "CALENDARIO"
        '
        'Calendario
        '
        Me.Calendario.AutoSize = True
        '
        '
        '
        Me.Calendario.BackgroundStyle.Class = "MonthCalendarAdv"
        Me.Calendario.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.Calendario.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Calendario.ContainerControlProcessDialogKey = True
        Me.Calendario.DisplayMonth = New Date(2016, 7, 1, 0, 0, 0, 0)
        Me.Calendario.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Calendario.FirstDayOfWeek = System.DayOfWeek.Monday
        Me.Calendario.Location = New System.Drawing.Point(0, 0)
        Me.Calendario.Name = "Calendario"
        '
        '
        '
        Me.Calendario.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.Calendario.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.Calendario.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.Calendario.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Calendario.Size = New System.Drawing.Size(170, 131)
        Me.Calendario.TabIndex = 0
        Me.Calendario.Text = "MonthCalendarAdv1"
        '
        'GroupPanel3
        '
        Me.GroupPanel3.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel3.Controls.Add(Me.Tb_DiasPedidos)
        Me.GroupPanel3.Controls.Add(Me.Tb_DiasPermitidos)
        Me.GroupPanel3.Controls.Add(Me.LabelX9)
        Me.GroupPanel3.Controls.Add(Me.LabelX8)
        Me.GroupPanel3.Controls.Add(Me.LabelX7)
        Me.GroupPanel3.Controls.Add(Me.LabelX6)
        Me.GroupPanel3.Controls.Add(Me.Tb_FechaIngreso)
        Me.GroupPanel3.Controls.Add(Me.Tb_FechaSalida)
        Me.GroupPanel3.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel3.Dock = System.Windows.Forms.DockStyle.Left
        Me.GroupPanel3.Location = New System.Drawing.Point(333, 0)
        Me.GroupPanel3.Name = "GroupPanel3"
        Me.GroupPanel3.Size = New System.Drawing.Size(313, 202)
        '
        '
        '
        Me.GroupPanel3.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GroupPanel3.Style.BackColorGradientAngle = 90
        Me.GroupPanel3.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.GroupPanel3.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel3.Style.BorderBottomWidth = 1
        Me.GroupPanel3.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanel3.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel3.Style.BorderLeftWidth = 1
        Me.GroupPanel3.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel3.Style.BorderRightWidth = 1
        Me.GroupPanel3.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel3.Style.BorderTopWidth = 1
        Me.GroupPanel3.Style.CornerDiameter = 4
        Me.GroupPanel3.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel3.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel3.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanel3.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanel3.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel3.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel3.TabIndex = 31
        Me.GroupPanel3.Text = "INGRESAR DATOS DE LA VACACION"
        '
        'Tb_DiasPedidos
        '
        '
        '
        '
        Me.Tb_DiasPedidos.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Tb_DiasPedidos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Tb_DiasPedidos.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.Tb_DiasPedidos.Location = New System.Drawing.Point(127, 32)
        Me.Tb_DiasPedidos.Name = "Tb_DiasPedidos"
        Me.Tb_DiasPedidos.ShowUpDown = True
        Me.Tb_DiasPedidos.Size = New System.Drawing.Size(80, 22)
        Me.Tb_DiasPedidos.TabIndex = 8
        '
        'Tb_DiasPermitidos
        '
        '
        '
        '
        Me.Tb_DiasPermitidos.Border.Class = "TextBoxBorder"
        Me.Tb_DiasPermitidos.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Tb_DiasPermitidos.Location = New System.Drawing.Point(126, 4)
        Me.Tb_DiasPermitidos.Name = "Tb_DiasPermitidos"
        Me.Tb_DiasPermitidos.PreventEnterBeep = True
        Me.Tb_DiasPermitidos.Size = New System.Drawing.Size(52, 22)
        Me.Tb_DiasPermitidos.TabIndex = 6
        '
        'LabelX9
        '
        Me.LabelX9.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX9.Location = New System.Drawing.Point(3, 3)
        Me.LabelX9.Name = "LabelX9"
        Me.LabelX9.Size = New System.Drawing.Size(121, 23)
        Me.LabelX9.TabIndex = 7
        Me.LabelX9.Text = "DIAS PERMITIDOS:"
        '
        'LabelX8
        '
        Me.LabelX8.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX8.Location = New System.Drawing.Point(3, 121)
        Me.LabelX8.Name = "LabelX8"
        Me.LabelX8.Size = New System.Drawing.Size(115, 23)
        Me.LabelX8.TabIndex = 5
        Me.LabelX8.Text = "FECHA INGRESO:"
        '
        'LabelX7
        '
        Me.LabelX7.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX7.Location = New System.Drawing.Point(3, 32)
        Me.LabelX7.Name = "LabelX7"
        Me.LabelX7.Size = New System.Drawing.Size(97, 23)
        Me.LabelX7.TabIndex = 4
        Me.LabelX7.Text = "CANT. DIAS:"
        '
        'LabelX6
        '
        Me.LabelX6.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX6.Location = New System.Drawing.Point(4, 67)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(106, 23)
        Me.LabelX6.TabIndex = 3
        Me.LabelX6.Text = "FECHA SALIDA:"
        '
        'Tb_FechaIngreso
        '
        Me.Tb_FechaIngreso.Location = New System.Drawing.Point(4, 144)
        Me.Tb_FechaIngreso.Name = "Tb_FechaIngreso"
        Me.Tb_FechaIngreso.Size = New System.Drawing.Size(295, 22)
        Me.Tb_FechaIngreso.TabIndex = 1
        '
        'Tb_FechaSalida
        '
        Me.Tb_FechaSalida.Location = New System.Drawing.Point(4, 92)
        Me.Tb_FechaSalida.Name = "Tb_FechaSalida"
        Me.Tb_FechaSalida.Size = New System.Drawing.Size(295, 22)
        Me.Tb_FechaSalida.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.LabelX1)
        Me.Panel2.Controls.Add(Me.Tb_Id)
        Me.Panel2.Controls.Add(Me.LabelX5)
        Me.Panel2.Controls.Add(Me.JMc_Persona)
        Me.Panel2.Controls.Add(Me.LabelX4)
        Me.Panel2.Controls.Add(Me.Tb_Fecha)
        Me.Panel2.Controls.Add(Me.LabelX3)
        Me.Panel2.Controls.Add(Me.Tb_Estado)
        Me.Panel2.Controls.Add(Me.LabelX2)
        Me.Panel2.Controls.Add(Me.Tb_Obs)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(333, 202)
        Me.Panel2.TabIndex = 30
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Location = New System.Drawing.Point(12, 17)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(75, 23)
        Me.LabelX1.TabIndex = 24
        Me.LabelX1.Text = "ID:"
        '
        'Tb_Id
        '
        '
        '
        '
        Me.Tb_Id.Border.Class = "TextBoxBorder"
        Me.Tb_Id.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Tb_Id.Location = New System.Drawing.Point(106, 20)
        Me.Tb_Id.Name = "Tb_Id"
        Me.Tb_Id.PreventEnterBeep = True
        Me.Tb_Id.Size = New System.Drawing.Size(100, 22)
        Me.Tb_Id.TabIndex = 19
        '
        'LabelX5
        '
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.Location = New System.Drawing.Point(12, 163)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(88, 23)
        Me.LabelX5.TabIndex = 28
        Me.LabelX5.Text = "OBSERVACION:"
        '
        'JMc_Persona
        '
        JMc_Persona_DesignTimeLayout.LayoutString = resources.GetString("JMc_Persona_DesignTimeLayout.LayoutString")
        Me.JMc_Persona.DesignTimeLayout = JMc_Persona_DesignTimeLayout
        Me.JMc_Persona.Location = New System.Drawing.Point(106, 79)
        Me.JMc_Persona.Name = "JMc_Persona"
        Me.JMc_Persona.SelectedIndex = -1
        Me.JMc_Persona.SelectedItem = Nothing
        Me.JMc_Persona.Size = New System.Drawing.Size(215, 22)
        Me.JMc_Persona.TabIndex = 20
        '
        'LabelX4
        '
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.Location = New System.Drawing.Point(12, 106)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(75, 23)
        Me.LabelX4.TabIndex = 27
        Me.LabelX4.Text = "FECHA:"
        '
        'Tb_Fecha
        '
        Me.Tb_Fecha.Location = New System.Drawing.Point(12, 130)
        Me.Tb_Fecha.Name = "Tb_Fecha"
        Me.Tb_Fecha.Size = New System.Drawing.Size(288, 22)
        Me.Tb_Fecha.TabIndex = 21
        '
        'LabelX3
        '
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Location = New System.Drawing.Point(12, 77)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(75, 23)
        Me.LabelX3.TabIndex = 26
        Me.LabelX3.Text = "PERSONA:"
        '
        'Tb_Estado
        '
        '
        '
        '
        Me.Tb_Estado.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Tb_Estado.Location = New System.Drawing.Point(106, 51)
        Me.Tb_Estado.Name = "Tb_Estado"
        Me.Tb_Estado.Size = New System.Drawing.Size(66, 22)
        Me.Tb_Estado.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Tb_Estado.TabIndex = 22
        '
        'LabelX2
        '
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Location = New System.Drawing.Point(12, 50)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(75, 23)
        Me.LabelX2.TabIndex = 25
        Me.LabelX2.Text = "ESTADO:"
        '
        'Tb_Obs
        '
        '
        '
        '
        Me.Tb_Obs.Border.Class = "TextBoxBorder"
        Me.Tb_Obs.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Tb_Obs.Location = New System.Drawing.Point(106, 163)
        Me.Tb_Obs.Name = "Tb_Obs"
        Me.Tb_Obs.PreventEnterBeep = True
        Me.Tb_Obs.Size = New System.Drawing.Size(221, 22)
        Me.Tb_Obs.TabIndex = 23
        '
        'GroupPanel1
        '
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.JGr_Buscador)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupPanel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupPanel1.Location = New System.Drawing.Point(0, 202)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(884, 226)
        '
        '
        '
        Me.GroupPanel1.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GroupPanel1.Style.BackColorGradientAngle = 90
        Me.GroupPanel1.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.GroupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderBottomWidth = 1
        Me.GroupPanel1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderLeftWidth = 1
        Me.GroupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderRightWidth = 1
        Me.GroupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderTopWidth = 1
        Me.GroupPanel1.Style.CornerDiameter = 4
        Me.GroupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel1.TabIndex = 21
        Me.GroupPanel1.Text = "B U S C A D O R"
        '
        'JGr_Buscador
        '
        Me.JGr_Buscador.Dock = System.Windows.Forms.DockStyle.Fill
        Me.JGr_Buscador.Location = New System.Drawing.Point(0, 0)
        Me.JGr_Buscador.Name = "JGr_Buscador"
        Me.JGr_Buscador.Size = New System.Drawing.Size(878, 203)
        Me.JGr_Buscador.TabIndex = 1
        '
        'F0_PedidoVacacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(884, 561)
        Me.Name = "F0_PedidoVacacion"
        Me.Text = "F0_PedidoVacacion"
        Me.Controls.SetChildIndex(Me.SuperTabPrincipal, 0)
        CType(Me.SuperTabPrincipal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SuperTabPrincipal.ResumeLayout(False)
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
        Me.Panel1.ResumeLayout(False)
        Me.GroupPanel2.ResumeLayout(False)
        CType(Me.JGr_DetalleFechas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanelCalen.ResumeLayout(False)
        Me.GroupPanelCalen.PerformLayout()
        Me.GroupPanel3.ResumeLayout(False)
        CType(Me.Tb_DiasPedidos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.JMc_Persona, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel1.ResumeLayout(False)
        CType(Me.JGr_Buscador, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Tb_Id As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents JMc_Persona As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Tb_Fecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Tb_Estado As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Tb_Obs As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents GroupPanel2 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents JGr_DetalleFechas As Janus.Windows.GridEX.GridEX
    Friend WithEvents GroupPanelCalen As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Calendario As DevComponents.Editors.DateTimeAdv.MonthCalendarAdv
    Friend WithEvents GroupPanel3 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Tb_DiasPedidos As DevComponents.Editors.IntegerInput
    Friend WithEvents Tb_DiasPermitidos As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX9 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX8 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX7 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Tb_FechaIngreso As System.Windows.Forms.DateTimePicker
    Friend WithEvents Tb_FechaSalida As System.Windows.Forms.DateTimePicker
    Friend WithEvents JGr_Buscador As Janus.Windows.GridEX.GridEX
End Class
