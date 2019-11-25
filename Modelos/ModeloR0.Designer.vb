<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ModeloR0
    Inherits System.Windows.Forms.Form

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
        Me.components = New System.ComponentModel.Container()
        Me.SuperTabPrincipal = New DevComponents.DotNetBar.SuperTabControl()
        Me.SuperTabControlPanelRegistro = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.PanelPrincipal = New System.Windows.Forms.Panel()
        Me.MReportViewer = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.PanelUsuario = New System.Windows.Forms.Panel()
        Me.lbHora = New System.Windows.Forms.Label()
        Me.lbFecha = New System.Windows.Forms.Label()
        Me.lbUsuario = New System.Windows.Forms.Label()
        Me.lblHora = New System.Windows.Forms.Label()
        Me.lblFecha = New System.Windows.Forms.Label()
        Me.lblUsuario = New System.Windows.Forms.Label()
        Me.PanelIzq = New System.Windows.Forms.Panel()
        Me.MGPFiltros = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.PanelSuperior = New DevComponents.DotNetBar.PanelEx()
        Me.PanelToolBar1 = New System.Windows.Forms.Panel()
        Me.btnSalir = New DevComponents.DotNetBar.ButtonX()
        Me.btnGenerar = New DevComponents.DotNetBar.ButtonX()
        Me.PanelInferior = New DevComponents.DotNetBar.PanelEx()
        Me.MPanelUserAct = New System.Windows.Forms.Panel()
        Me.BubbleBarUsuario = New DevComponents.DotNetBar.BubbleBar()
        Me.BubbleBarTabUsuario = New DevComponents.DotNetBar.BubbleBarTab(Me.components)
        Me.BBtnUsuario = New DevComponents.DotNetBar.BubbleButton()
        Me.TxtNombreUsu = New System.Windows.Forms.TextBox()
        Me.SupTabItemRegistro = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabControlPanelBuscador = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.SupTabItemBusqueda = New DevComponents.DotNetBar.SuperTabItem()
        Me.MEP = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.MHighlighterFocus = New DevComponents.DotNetBar.Validator.Highlighter()
        Me.MFlyoutUsuario = New DevComponents.DotNetBar.Controls.Flyout(Me.components)
        CType(Me.SuperTabPrincipal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuperTabPrincipal.SuspendLayout()
        Me.SuperTabControlPanelRegistro.SuspendLayout()
        Me.PanelPrincipal.SuspendLayout()
        Me.PanelUsuario.SuspendLayout()
        Me.PanelIzq.SuspendLayout()
        Me.PanelSuperior.SuspendLayout()
        Me.PanelToolBar1.SuspendLayout()
        Me.PanelInferior.SuspendLayout()
        Me.MPanelUserAct.SuspendLayout()
        CType(Me.BubbleBarUsuario, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MEP, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.SuperTabPrincipal.Controls.Add(Me.SuperTabControlPanelRegistro)
        Me.SuperTabPrincipal.Controls.Add(Me.SuperTabControlPanelBuscador)
        Me.SuperTabPrincipal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabPrincipal.Location = New System.Drawing.Point(0, 0)
        Me.SuperTabPrincipal.Name = "SuperTabPrincipal"
        Me.SuperTabPrincipal.ReorderTabsEnabled = True
        Me.SuperTabPrincipal.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.SuperTabPrincipal.SelectedTabIndex = 0
        Me.SuperTabPrincipal.Size = New System.Drawing.Size(884, 561)
        Me.SuperTabPrincipal.TabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SuperTabPrincipal.TabIndex = 0
        Me.SuperTabPrincipal.Tabs.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.SupTabItemRegistro, Me.SupTabItemBusqueda})
        Me.SuperTabPrincipal.Text = "SuperTabControl1"
        '
        'SuperTabControlPanelRegistro
        '
        Me.SuperTabControlPanelRegistro.Controls.Add(Me.PanelPrincipal)
        Me.SuperTabControlPanelRegistro.Controls.Add(Me.PanelIzq)
        Me.SuperTabControlPanelRegistro.Controls.Add(Me.PanelInferior)
        Me.SuperTabControlPanelRegistro.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanelRegistro.Location = New System.Drawing.Point(0, 25)
        Me.SuperTabControlPanelRegistro.Name = "SuperTabControlPanelRegistro"
        Me.SuperTabControlPanelRegistro.Size = New System.Drawing.Size(884, 536)
        Me.SuperTabControlPanelRegistro.TabIndex = 1
        Me.SuperTabControlPanelRegistro.TabItem = Me.SupTabItemRegistro
        '
        'PanelPrincipal
        '
        Me.PanelPrincipal.BackColor = System.Drawing.SystemColors.Control
        Me.PanelPrincipal.Controls.Add(Me.MReportViewer)
        Me.PanelPrincipal.Controls.Add(Me.PanelUsuario)
        Me.PanelPrincipal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelPrincipal.Location = New System.Drawing.Point(363, 0)
        Me.PanelPrincipal.Name = "PanelPrincipal"
        Me.PanelPrincipal.Size = New System.Drawing.Size(521, 500)
        Me.PanelPrincipal.TabIndex = 0
        '
        'MReportViewer
        '
        Me.MReportViewer.ActiveViewIndex = -1
        Me.MReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.MReportViewer.Cursor = System.Windows.Forms.Cursors.Default
        Me.MReportViewer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MReportViewer.Location = New System.Drawing.Point(0, 0)
        Me.MReportViewer.Name = "MReportViewer"
        Me.MReportViewer.Size = New System.Drawing.Size(521, 500)
        Me.MReportViewer.TabIndex = 20
        '
        'PanelUsuario
        '
        Me.PanelUsuario.Controls.Add(Me.lbHora)
        Me.PanelUsuario.Controls.Add(Me.lbFecha)
        Me.PanelUsuario.Controls.Add(Me.lbUsuario)
        Me.PanelUsuario.Controls.Add(Me.lblHora)
        Me.PanelUsuario.Controls.Add(Me.lblFecha)
        Me.PanelUsuario.Controls.Add(Me.lblUsuario)
        Me.PanelUsuario.Location = New System.Drawing.Point(457, 45)
        Me.PanelUsuario.Name = "PanelUsuario"
        Me.PanelUsuario.Size = New System.Drawing.Size(220, 100)
        Me.PanelUsuario.TabIndex = 19
        Me.PanelUsuario.TabStop = True
        Me.PanelUsuario.Visible = False
        '
        'lbHora
        '
        Me.lbHora.AutoSize = True
        Me.lbHora.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbHora.Location = New System.Drawing.Point(115, 65)
        Me.lbHora.Name = "lbHora"
        Me.lbHora.Size = New System.Drawing.Size(79, 18)
        Me.lbHora.TabIndex = 6
        Me.lbHora.Text = "USUARIO:"
        '
        'lbFecha
        '
        Me.lbFecha.AutoSize = True
        Me.lbFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbFecha.Location = New System.Drawing.Point(115, 42)
        Me.lbFecha.Name = "lbFecha"
        Me.lbFecha.Size = New System.Drawing.Size(79, 18)
        Me.lbFecha.TabIndex = 5
        Me.lbFecha.Text = "USUARIO:"
        '
        'lbUsuario
        '
        Me.lbUsuario.AutoSize = True
        Me.lbUsuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbUsuario.Location = New System.Drawing.Point(115, 19)
        Me.lbUsuario.Name = "lbUsuario"
        Me.lbUsuario.Size = New System.Drawing.Size(79, 18)
        Me.lbUsuario.TabIndex = 4
        Me.lbUsuario.Text = "USUARIO:"
        '
        'lblHora
        '
        Me.lblHora.AutoSize = True
        Me.lblHora.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHora.Location = New System.Drawing.Point(31, 65)
        Me.lblHora.Name = "lblHora"
        Me.lblHora.Size = New System.Drawing.Size(60, 18)
        Me.lblHora.TabIndex = 2
        Me.lblHora.Text = "HORA:"
        '
        'lblFecha
        '
        Me.lblFecha.AutoSize = True
        Me.lblFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFecha.Location = New System.Drawing.Point(31, 43)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(68, 18)
        Me.lblFecha.TabIndex = 1
        Me.lblFecha.Text = "FECHA:"
        '
        'lblUsuario
        '
        Me.lblUsuario.AutoSize = True
        Me.lblUsuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUsuario.Location = New System.Drawing.Point(31, 19)
        Me.lblUsuario.Name = "lblUsuario"
        Me.lblUsuario.Size = New System.Drawing.Size(87, 18)
        Me.lblUsuario.TabIndex = 0
        Me.lblUsuario.Text = "USUARIO:"
        '
        'PanelIzq
        '
        Me.PanelIzq.Controls.Add(Me.MGPFiltros)
        Me.PanelIzq.Controls.Add(Me.PanelSuperior)
        Me.PanelIzq.Dock = System.Windows.Forms.DockStyle.Left
        Me.PanelIzq.Location = New System.Drawing.Point(0, 0)
        Me.PanelIzq.Name = "PanelIzq"
        Me.PanelIzq.Size = New System.Drawing.Size(363, 500)
        Me.PanelIzq.TabIndex = 20
        '
        'MGPFiltros
        '
        Me.MGPFiltros.CanvasColor = System.Drawing.SystemColors.Control
        Me.MGPFiltros.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.MGPFiltros.DisabledBackColor = System.Drawing.Color.Empty
        Me.MGPFiltros.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MGPFiltros.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MGPFiltros.Location = New System.Drawing.Point(0, 72)
        Me.MGPFiltros.Name = "MGPFiltros"
        Me.MGPFiltros.Size = New System.Drawing.Size(363, 428)
        '
        '
        '
        Me.MGPFiltros.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.MGPFiltros.Style.BackColorGradientAngle = 90
        Me.MGPFiltros.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.MGPFiltros.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.MGPFiltros.Style.BorderBottomWidth = 1
        Me.MGPFiltros.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.MGPFiltros.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.MGPFiltros.Style.BorderLeftWidth = 1
        Me.MGPFiltros.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.MGPFiltros.Style.BorderRightWidth = 1
        Me.MGPFiltros.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.MGPFiltros.Style.BorderTopWidth = 1
        Me.MGPFiltros.Style.CornerDiameter = 4
        Me.MGPFiltros.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.MGPFiltros.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.MGPFiltros.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.MGPFiltros.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.MGPFiltros.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.MGPFiltros.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.MGPFiltros.TabIndex = 11
        Me.MGPFiltros.Text = "F I L T R O S"
        '
        'PanelSuperior
        '
        Me.PanelSuperior.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelSuperior.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP
        Me.PanelSuperior.Controls.Add(Me.PanelToolBar1)
        Me.PanelSuperior.DisabledBackColor = System.Drawing.Color.Empty
        Me.PanelSuperior.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelSuperior.Location = New System.Drawing.Point(0, 0)
        Me.PanelSuperior.Name = "PanelSuperior"
        Me.PanelSuperior.Size = New System.Drawing.Size(363, 72)
        Me.PanelSuperior.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelSuperior.Style.BackColor1.Color = System.Drawing.Color.Yellow
        Me.PanelSuperior.Style.BackColor2.Color = System.Drawing.Color.Khaki
        Me.PanelSuperior.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelSuperior.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelSuperior.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelSuperior.Style.GradientAngle = 90
        Me.PanelSuperior.TabIndex = 0
        '
        'PanelToolBar1
        '
        Me.PanelToolBar1.Controls.Add(Me.btnSalir)
        Me.PanelToolBar1.Controls.Add(Me.btnGenerar)
        Me.PanelToolBar1.Location = New System.Drawing.Point(99, 0)
        Me.PanelToolBar1.Name = "PanelToolBar1"
        Me.PanelToolBar1.Size = New System.Drawing.Size(143, 72)
        Me.PanelToolBar1.TabIndex = 5
        '
        'btnSalir
        '
        Me.btnSalir.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnSalir.ColorTable = DevComponents.DotNetBar.eButtonColor.Orange
        Me.btnSalir.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Image = Global.Modelos.My.Resources.Resources.SALIR2
        Me.btnSalir.ImageFixedSize = New System.Drawing.Size(48, 48)
        Me.btnSalir.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btnSalir.Location = New System.Drawing.Point(72, 0)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(72, 72)
        Me.btnSalir.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnSalir.TabIndex = 10
        Me.btnSalir.Text = "SALIR"
        Me.btnSalir.TextColor = System.Drawing.Color.Black
        '
        'btnGenerar
        '
        Me.btnGenerar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnGenerar.ColorTable = DevComponents.DotNetBar.eButtonColor.Orange
        Me.btnGenerar.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnGenerar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGenerar.Image = Global.Modelos.My.Resources.Resources.GENERAR_REPORTE
        Me.btnGenerar.ImageFixedSize = New System.Drawing.Size(48, 48)
        Me.btnGenerar.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btnGenerar.Location = New System.Drawing.Point(0, 0)
        Me.btnGenerar.Name = "btnGenerar"
        Me.btnGenerar.Size = New System.Drawing.Size(72, 72)
        Me.btnGenerar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnGenerar.TabIndex = 9
        Me.btnGenerar.Text = "GENERAR"
        Me.btnGenerar.TextColor = System.Drawing.Color.Black
        '
        'PanelInferior
        '
        Me.PanelInferior.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelInferior.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanelInferior.Controls.Add(Me.MPanelUserAct)
        Me.PanelInferior.DisabledBackColor = System.Drawing.Color.Empty
        Me.PanelInferior.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelInferior.Location = New System.Drawing.Point(0, 500)
        Me.PanelInferior.Name = "PanelInferior"
        Me.PanelInferior.Size = New System.Drawing.Size(884, 36)
        Me.PanelInferior.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelInferior.Style.BackColor1.Color = System.Drawing.Color.Gold
        Me.PanelInferior.Style.BackColor2.Color = System.Drawing.Color.Gold
        Me.PanelInferior.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelInferior.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelInferior.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelInferior.Style.GradientAngle = 90
        Me.PanelInferior.TabIndex = 4
        '
        'MPanelUserAct
        '
        Me.MPanelUserAct.Controls.Add(Me.BubbleBarUsuario)
        Me.MPanelUserAct.Controls.Add(Me.TxtNombreUsu)
        Me.MPanelUserAct.Dock = System.Windows.Forms.DockStyle.Right
        Me.MPanelUserAct.Location = New System.Drawing.Point(684, 0)
        Me.MPanelUserAct.Name = "MPanelUserAct"
        Me.MPanelUserAct.Size = New System.Drawing.Size(200, 36)
        Me.MPanelUserAct.TabIndex = 21
        '
        'BubbleBarUsuario
        '
        Me.BubbleBarUsuario.Alignment = DevComponents.DotNetBar.eBubbleButtonAlignment.Bottom
        Me.BubbleBarUsuario.AntiAlias = True
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
        Me.BubbleBarUsuario.Dock = System.Windows.Forms.DockStyle.Left
        Me.BubbleBarUsuario.ImageSizeNormal = New System.Drawing.Size(24, 24)
        Me.BubbleBarUsuario.Location = New System.Drawing.Point(0, 0)
        Me.BubbleBarUsuario.MouseOverTabColors.BorderColor = System.Drawing.SystemColors.Highlight
        Me.BubbleBarUsuario.Name = "BubbleBarUsuario"
        Me.BubbleBarUsuario.SelectedTab = Me.BubbleBarTabUsuario
        Me.BubbleBarUsuario.SelectedTabColors.BorderColor = System.Drawing.Color.Black
        Me.BubbleBarUsuario.Size = New System.Drawing.Size(50, 36)
        Me.BubbleBarUsuario.TabIndex = 13
        Me.BubbleBarUsuario.Tabs.Add(Me.BubbleBarTabUsuario)
        Me.BubbleBarUsuario.TabsVisible = False
        Me.BubbleBarUsuario.Text = "BubbleBar5"
        '
        'BubbleBarTabUsuario
        '
        Me.BubbleBarTabUsuario.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.BubbleBarTabUsuario.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.BubbleBarTabUsuario.Buttons.AddRange(New DevComponents.DotNetBar.BubbleButton() {Me.BBtnUsuario})
        Me.BubbleBarTabUsuario.DarkBorderColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(105, Byte), Integer), CType(CType(105, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.BubbleBarTabUsuario.LightBorderColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.BubbleBarTabUsuario.Name = "BubbleBarTabUsuario"
        Me.BubbleBarTabUsuario.PredefinedColor = DevComponents.DotNetBar.eTabItemColor.Blue
        Me.BubbleBarTabUsuario.Text = "BubbleBarTab3"
        Me.BubbleBarTabUsuario.TextColor = System.Drawing.Color.Black
        '
        'BBtnUsuario
        '
        Me.BBtnUsuario.Image = Global.Modelos.My.Resources.Resources.USUARIO
        Me.BBtnUsuario.ImageLarge = Global.Modelos.My.Resources.Resources.USUARIO
        Me.BBtnUsuario.Name = "BBtnUsuario"
        '
        'TxtNombreUsu
        '
        Me.TxtNombreUsu.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNombreUsu.Location = New System.Drawing.Point(59, 5)
        Me.TxtNombreUsu.Multiline = True
        Me.TxtNombreUsu.Name = "TxtNombreUsu"
        Me.TxtNombreUsu.Size = New System.Drawing.Size(135, 27)
        Me.TxtNombreUsu.TabIndex = 14
        '
        'SupTabItemRegistro
        '
        Me.SupTabItemRegistro.AttachedControl = Me.SuperTabControlPanelRegistro
        Me.SupTabItemRegistro.GlobalItem = False
        Me.SupTabItemRegistro.Name = "SupTabItemRegistro"
        Me.SupTabItemRegistro.Text = "REPORTE"
        '
        'SuperTabControlPanelBuscador
        '
        Me.SuperTabControlPanelBuscador.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanelBuscador.Location = New System.Drawing.Point(0, 25)
        Me.SuperTabControlPanelBuscador.Name = "SuperTabControlPanelBuscador"
        Me.SuperTabControlPanelBuscador.Size = New System.Drawing.Size(884, 536)
        Me.SuperTabControlPanelBuscador.TabIndex = 0
        Me.SuperTabControlPanelBuscador.TabItem = Me.SupTabItemBusqueda
        '
        'SupTabItemBusqueda
        '
        Me.SupTabItemBusqueda.AttachedControl = Me.SuperTabControlPanelBuscador
        Me.SupTabItemBusqueda.GlobalItem = False
        Me.SupTabItemBusqueda.Name = "SupTabItemBusqueda"
        Me.SupTabItemBusqueda.Text = "BUSQUEDA"
        Me.SupTabItemBusqueda.Visible = False
        '
        'MEP
        '
        Me.MEP.ContainerControl = Me
        '
        'MHighlighterFocus
        '
        Me.MHighlighterFocus.ContainerControl = Me
        '
        'MFlyoutUsuario
        '
        Me.MFlyoutUsuario.DropShadow = False
        Me.MFlyoutUsuario.Parent = Me
        Me.MFlyoutUsuario.TargetControl = Me.BubbleBarUsuario
        '
        'ModeloR0
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(884, 561)
        Me.Controls.Add(Me.SuperTabPrincipal)
        Me.KeyPreview = True
        Me.Name = "ModeloR0"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "{...TITULO...}"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.SuperTabPrincipal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SuperTabPrincipal.ResumeLayout(False)
        Me.SuperTabControlPanelRegistro.ResumeLayout(False)
        Me.PanelPrincipal.ResumeLayout(False)
        Me.PanelUsuario.ResumeLayout(False)
        Me.PanelUsuario.PerformLayout()
        Me.PanelIzq.ResumeLayout(False)
        Me.PanelSuperior.ResumeLayout(False)
        Me.PanelToolBar1.ResumeLayout(False)
        Me.PanelInferior.ResumeLayout(False)
        Me.MPanelUserAct.ResumeLayout(False)
        Me.MPanelUserAct.PerformLayout()
        CType(Me.BubbleBarUsuario, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MEP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Protected WithEvents SuperTabPrincipal As DevComponents.DotNetBar.SuperTabControl
    Protected WithEvents SuperTabControlPanelBuscador As DevComponents.DotNetBar.SuperTabControlPanel
    Protected WithEvents SupTabItemBusqueda As DevComponents.DotNetBar.SuperTabItem
    Protected WithEvents SuperTabControlPanelRegistro As DevComponents.DotNetBar.SuperTabControlPanel
    Protected WithEvents SupTabItemRegistro As DevComponents.DotNetBar.SuperTabItem
    Protected WithEvents PanelSuperior As DevComponents.DotNetBar.PanelEx
    Protected WithEvents PanelInferior As DevComponents.DotNetBar.PanelEx
    Protected WithEvents BubbleBarUsuario As DevComponents.DotNetBar.BubbleBar
    Protected WithEvents BubbleBarTabUsuario As DevComponents.DotNetBar.BubbleBarTab
    Protected WithEvents TxtNombreUsu As System.Windows.Forms.TextBox
    Protected WithEvents PanelToolBar1 As System.Windows.Forms.Panel
    Protected WithEvents btnSalir As DevComponents.DotNetBar.ButtonX
    Protected WithEvents btnGenerar As DevComponents.DotNetBar.ButtonX
    Protected WithEvents PanelPrincipal As System.Windows.Forms.Panel
    Protected WithEvents PanelUsuario As System.Windows.Forms.Panel
    Protected WithEvents lbHora As System.Windows.Forms.Label
    Protected WithEvents lbFecha As System.Windows.Forms.Label
    Protected WithEvents lbUsuario As System.Windows.Forms.Label
    Protected WithEvents lblHora As System.Windows.Forms.Label
    Protected WithEvents lblFecha As System.Windows.Forms.Label
    Protected WithEvents lblUsuario As System.Windows.Forms.Label
    Protected WithEvents MPanelUserAct As System.Windows.Forms.Panel
    Protected WithEvents MEP As System.Windows.Forms.ErrorProvider
    Protected WithEvents MHighlighterFocus As DevComponents.DotNetBar.Validator.Highlighter
    Protected WithEvents MFlyoutUsuario As DevComponents.DotNetBar.Controls.Flyout
    Friend WithEvents BBtnUsuario As DevComponents.DotNetBar.BubbleButton
    Protected WithEvents MReportViewer As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Protected WithEvents MGPFiltros As DevComponents.DotNetBar.Controls.GroupPanel
    Protected WithEvents PanelIzq As System.Windows.Forms.Panel
End Class
