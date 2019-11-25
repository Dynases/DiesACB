<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PR_PreExamen
    Inherits Modelos.ModeloR0

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
        Me.tbFecha = New System.Windows.Forms.DateTimePicker()
        Me.LabelX12 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.tbInst = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.tbNumiInst = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.tbFiltrarInst = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.tbConNota = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.GroupPanel2 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.tbFiltrarSuc = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.tbSucursal = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.tbNumiSuc = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.tbModo = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        CType(Me.SuperTabPrincipal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuperTabPrincipal.SuspendLayout()
        Me.SuperTabControlPanelRegistro.SuspendLayout()
        Me.PanelSuperior.SuspendLayout()
        Me.PanelInferior.SuspendLayout()
        CType(Me.BubbleBarUsuario, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelToolBar1.SuspendLayout()
        Me.PanelPrincipal.SuspendLayout()
        Me.PanelUsuario.SuspendLayout()
        Me.MPanelUserAct.SuspendLayout()
        CType(Me.MEP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MGPFiltros.SuspendLayout()
        Me.PanelIzq.SuspendLayout()
        Me.GroupPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupPanel2.SuspendLayout()
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
        '
        'SuperTabControlPanelBuscador
        '
        Me.SuperTabControlPanelBuscador.Location = New System.Drawing.Point(0, 28)
        Me.SuperTabControlPanelBuscador.Size = New System.Drawing.Size(1179, 662)
        '
        'SuperTabControlPanelRegistro
        '
        Me.SuperTabControlPanelRegistro.Location = New System.Drawing.Point(0, 28)
        Me.SuperTabControlPanelRegistro.Size = New System.Drawing.Size(1179, 662)
        Me.SuperTabControlPanelRegistro.Controls.SetChildIndex(Me.PanelIzq, 0)
        Me.SuperTabControlPanelRegistro.Controls.SetChildIndex(Me.PanelInferior, 0)
        Me.SuperTabControlPanelRegistro.Controls.SetChildIndex(Me.PanelPrincipal, 0)
        '
        'PanelSuperior
        '
        Me.PanelSuperior.Margin = New System.Windows.Forms.Padding(5)
        Me.PanelSuperior.Size = New System.Drawing.Size(499, 89)
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
        Me.PanelInferior.Location = New System.Drawing.Point(499, 618)
        Me.PanelInferior.Margin = New System.Windows.Forms.Padding(5)
        Me.PanelInferior.Size = New System.Drawing.Size(680, 44)
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
        'PanelToolBar1
        '
        Me.PanelToolBar1.Location = New System.Drawing.Point(151, 0)
        Me.PanelToolBar1.Margin = New System.Windows.Forms.Padding(5)
        '
        'btnSalir
        '
        '
        'btnGenerar
        '
        '
        'PanelPrincipal
        '
        Me.PanelPrincipal.Location = New System.Drawing.Point(499, 0)
        Me.PanelPrincipal.Margin = New System.Windows.Forms.Padding(5)
        Me.PanelPrincipal.Size = New System.Drawing.Size(680, 618)
        '
        'MPanelUserAct
        '
        Me.MPanelUserAct.Location = New System.Drawing.Point(413, 0)
        Me.MPanelUserAct.Margin = New System.Windows.Forms.Padding(5)
        '
        'MReportViewer
        '
        Me.MReportViewer.Margin = New System.Windows.Forms.Padding(5)
        Me.MReportViewer.Size = New System.Drawing.Size(680, 618)
        Me.MReportViewer.ToolPanelWidth = 267
        '
        'MGPFiltros
        '
        Me.MGPFiltros.Controls.Add(Me.LabelX3)
        Me.MGPFiltros.Controls.Add(Me.tbModo)
        Me.MGPFiltros.Controls.Add(Me.GroupPanel1)
        Me.MGPFiltros.Controls.Add(Me.GroupPanel2)
        Me.MGPFiltros.Controls.Add(Me.Panel1)
        Me.MGPFiltros.Margin = New System.Windows.Forms.Padding(5)
        Me.MGPFiltros.Size = New System.Drawing.Size(499, 573)
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
        '
        'PanelIzq
        '
        Me.PanelIzq.Margin = New System.Windows.Forms.Padding(5)
        Me.PanelIzq.Size = New System.Drawing.Size(499, 662)
        Me.PanelIzq.Controls.SetChildIndex(Me.PanelSuperior, 0)
        Me.PanelIzq.Controls.SetChildIndex(Me.MGPFiltros, 0)
        '
        'tbFecha
        '
        Me.tbFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.tbFecha.Location = New System.Drawing.Point(87, 23)
        Me.tbFecha.Margin = New System.Windows.Forms.Padding(4)
        Me.tbFecha.Name = "tbFecha"
        Me.tbFecha.Size = New System.Drawing.Size(161, 26)
        Me.tbFecha.TabIndex = 39
        '
        'LabelX12
        '
        Me.LabelX12.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX12.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX12.Location = New System.Drawing.Point(11, 22)
        Me.LabelX12.Margin = New System.Windows.Forms.Padding(4)
        Me.LabelX12.Name = "LabelX12"
        Me.LabelX12.Size = New System.Drawing.Size(68, 28)
        Me.LabelX12.TabIndex = 40
        Me.LabelX12.Text = "FECHA:"
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX1.Location = New System.Drawing.Point(8, 14)
        Me.LabelX1.Margin = New System.Windows.Forms.Padding(4)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(85, 28)
        Me.LabelX1.TabIndex = 41
        Me.LabelX1.Text = "FILTRAR:"
        '
        'tbInst
        '
        '
        '
        '
        Me.tbInst.Border.Class = "TextBoxBorder"
        Me.tbInst.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbInst.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbInst.Location = New System.Drawing.Point(8, 49)
        Me.tbInst.Margin = New System.Windows.Forms.Padding(4)
        Me.tbInst.Name = "tbInst"
        Me.tbInst.PreventEnterBeep = True
        Me.tbInst.ReadOnly = True
        Me.tbInst.Size = New System.Drawing.Size(463, 26)
        Me.tbInst.TabIndex = 42
        '
        'tbNumiInst
        '
        '
        '
        '
        Me.tbNumiInst.Border.Class = "TextBoxBorder"
        Me.tbNumiInst.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbNumiInst.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbNumiInst.Location = New System.Drawing.Point(319, 4)
        Me.tbNumiInst.Margin = New System.Windows.Forms.Padding(4)
        Me.tbNumiInst.Name = "tbNumiInst"
        Me.tbNumiInst.PreventEnterBeep = True
        Me.tbNumiInst.Size = New System.Drawing.Size(160, 26)
        Me.tbNumiInst.TabIndex = 43
        Me.tbNumiInst.Visible = False
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.Transparent
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.tbFiltrarInst)
        Me.GroupPanel1.Controls.Add(Me.tbInst)
        Me.GroupPanel1.Controls.Add(Me.LabelX1)
        Me.GroupPanel1.Controls.Add(Me.tbNumiInst)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupPanel1.Location = New System.Drawing.Point(0, 196)
        Me.GroupPanel1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(493, 123)
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
        Me.GroupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        '
        '
        '
        Me.GroupPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel1.TabIndex = 44
        Me.GroupPanel1.Text = "INSTRUCTOR"
        '
        'tbFiltrarInst
        '
        '
        '
        '
        Me.tbFiltrarInst.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbFiltrarInst.Location = New System.Drawing.Point(101, 15)
        Me.tbFiltrarInst.Margin = New System.Windows.Forms.Padding(4)
        Me.tbFiltrarInst.Name = "tbFiltrarInst"
        Me.tbFiltrarInst.Size = New System.Drawing.Size(105, 27)
        Me.tbFiltrarInst.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.tbFiltrarInst.TabIndex = 44
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.tbConNota)
        Me.Panel1.Controls.Add(Me.LabelX12)
        Me.Panel1.Controls.Add(Me.tbFecha)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(493, 73)
        Me.Panel1.TabIndex = 45
        '
        'tbConNota
        '
        '
        '
        '
        Me.tbConNota.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbConNota.Location = New System.Drawing.Point(297, 23)
        Me.tbConNota.Margin = New System.Windows.Forms.Padding(4)
        Me.tbConNota.Name = "tbConNota"
        Me.tbConNota.OffText = "SIN NOTA"
        Me.tbConNota.OnText = "CON NOTA"
        Me.tbConNota.Size = New System.Drawing.Size(144, 27)
        Me.tbConNota.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.tbConNota.TabIndex = 45
        '
        'GroupPanel2
        '
        Me.GroupPanel2.BackColor = System.Drawing.Color.Transparent
        Me.GroupPanel2.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel2.Controls.Add(Me.tbFiltrarSuc)
        Me.GroupPanel2.Controls.Add(Me.tbSucursal)
        Me.GroupPanel2.Controls.Add(Me.LabelX2)
        Me.GroupPanel2.Controls.Add(Me.tbNumiSuc)
        Me.GroupPanel2.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupPanel2.Location = New System.Drawing.Point(0, 73)
        Me.GroupPanel2.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupPanel2.Name = "GroupPanel2"
        Me.GroupPanel2.Size = New System.Drawing.Size(493, 123)
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
        Me.GroupPanel2.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        '
        '
        '
        Me.GroupPanel2.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel2.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel2.TabIndex = 46
        Me.GroupPanel2.Text = "SUCURSAL"
        '
        'tbFiltrarSuc
        '
        '
        '
        '
        Me.tbFiltrarSuc.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbFiltrarSuc.Location = New System.Drawing.Point(101, 15)
        Me.tbFiltrarSuc.Margin = New System.Windows.Forms.Padding(4)
        Me.tbFiltrarSuc.Name = "tbFiltrarSuc"
        Me.tbFiltrarSuc.Size = New System.Drawing.Size(105, 27)
        Me.tbFiltrarSuc.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.tbFiltrarSuc.TabIndex = 44
        '
        'tbSucursal
        '
        '
        '
        '
        Me.tbSucursal.Border.Class = "TextBoxBorder"
        Me.tbSucursal.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbSucursal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbSucursal.Location = New System.Drawing.Point(8, 49)
        Me.tbSucursal.Margin = New System.Windows.Forms.Padding(4)
        Me.tbSucursal.Name = "tbSucursal"
        Me.tbSucursal.PreventEnterBeep = True
        Me.tbSucursal.ReadOnly = True
        Me.tbSucursal.Size = New System.Drawing.Size(463, 26)
        Me.tbSucursal.TabIndex = 42
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX2.Location = New System.Drawing.Point(8, 14)
        Me.LabelX2.Margin = New System.Windows.Forms.Padding(4)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(85, 28)
        Me.LabelX2.TabIndex = 41
        Me.LabelX2.Text = "FILTRAR:"
        '
        'tbNumiSuc
        '
        '
        '
        '
        Me.tbNumiSuc.Border.Class = "TextBoxBorder"
        Me.tbNumiSuc.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbNumiSuc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbNumiSuc.Location = New System.Drawing.Point(319, 4)
        Me.tbNumiSuc.Margin = New System.Windows.Forms.Padding(4)
        Me.tbNumiSuc.Name = "tbNumiSuc"
        Me.tbNumiSuc.PreventEnterBeep = True
        Me.tbNumiSuc.Size = New System.Drawing.Size(160, 26)
        Me.tbNumiSuc.TabIndex = 43
        Me.tbNumiSuc.Visible = False
        '
        'tbModo
        '
        '
        '
        '
        Me.tbModo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbModo.Location = New System.Drawing.Point(160, 328)
        Me.tbModo.Margin = New System.Windows.Forms.Padding(4)
        Me.tbModo.Name = "tbModo"
        Me.tbModo.OffText = "MODO 2"
        Me.tbModo.OnText = "MODO 1"
        Me.tbModo.Size = New System.Drawing.Size(144, 27)
        Me.tbModo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.tbModo.TabIndex = 47
        Me.tbModo.Value = True
        Me.tbModo.ValueObject = "Y"
        '
        'LabelX3
        '
        Me.LabelX3.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX3.Location = New System.Drawing.Point(11, 327)
        Me.LabelX3.Margin = New System.Windows.Forms.Padding(4)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(141, 28)
        Me.LabelX3.TabIndex = 45
        Me.LabelX3.Text = "MODO REPORTE:"
        '
        'PR_PreExamen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1179, 690)
        Me.Location = New System.Drawing.Point(0, 0)
        Me.Margin = New System.Windows.Forms.Padding(5)
        Me.Name = "PR_PreExamen"
        Me.Text = "PR_PreExamen"
        Me.Controls.SetChildIndex(Me.SuperTabPrincipal, 0)
        CType(Me.SuperTabPrincipal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SuperTabPrincipal.ResumeLayout(False)
        Me.SuperTabControlPanelRegistro.ResumeLayout(False)
        Me.PanelSuperior.ResumeLayout(False)
        Me.PanelInferior.ResumeLayout(False)
        CType(Me.BubbleBarUsuario, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelToolBar1.ResumeLayout(False)
        Me.PanelPrincipal.ResumeLayout(False)
        Me.PanelUsuario.ResumeLayout(False)
        Me.PanelUsuario.PerformLayout()
        Me.MPanelUserAct.ResumeLayout(False)
        Me.MPanelUserAct.PerformLayout()
        CType(Me.MEP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MGPFiltros.ResumeLayout(False)
        Me.PanelIzq.ResumeLayout(False)
        Me.GroupPanel1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.GroupPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tbFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents LabelX12 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents tbInst As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents tbNumiInst As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents tbFiltrarInst As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents GroupPanel2 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents tbFiltrarSuc As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents tbSucursal As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents tbNumiSuc As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents tbConNota As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents tbModo As DevComponents.DotNetBar.Controls.SwitchButton
End Class
