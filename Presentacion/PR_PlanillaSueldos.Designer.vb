<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PR_PlanillaSueldos
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
        Dim JMc_Persona_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PR_PlanillaSueldos))
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.tbMes = New DevComponents.Editors.IntegerInput()
        Me.tbAnio = New DevComponents.Editors.IntegerInput()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.GroupPanel2 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.JMc_Persona = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Sw_Filtrar = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.ButtonX1 = New DevComponents.DotNetBar.ButtonX()
        Me.BubbleBar1 = New DevComponents.DotNetBar.BubbleBar()
        Me.BubbleBarTab1 = New DevComponents.DotNetBar.BubbleBarTab(Me.components)
        Me.BubbleButton7 = New DevComponents.DotNetBar.BubbleButton()
        Me.BubbleButton5 = New DevComponents.DotNetBar.BubbleButton()
        Me.PanelEx1 = New DevComponents.DotNetBar.PanelEx()
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.GroupPanel3 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.tbPlanilla = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.GroupPanel1.SuspendLayout()
        CType(Me.tbMes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbAnio, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel2.SuspendLayout()
        CType(Me.JMc_Persona, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BubbleBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelEx1.SuspendLayout()
        Me.GroupPanel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupPanel1
        '
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.tbMes)
        Me.GroupPanel1.Controls.Add(Me.tbAnio)
        Me.GroupPanel1.Controls.Add(Me.LabelX3)
        Me.GroupPanel1.Controls.Add(Me.LabelX2)
        Me.GroupPanel1.Controls.Add(Me.GroupPanel2)
        Me.GroupPanel1.Controls.Add(Me.GroupPanel3)
        Me.GroupPanel1.Controls.Add(Me.ButtonX1)
        Me.GroupPanel1.Controls.Add(Me.BubbleBar1)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.GroupPanel1.Location = New System.Drawing.Point(0, 0)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(276, 496)
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
        Me.GroupPanel1.TabIndex = 0
        Me.GroupPanel1.Text = "FILTROS"
        '
        'tbMes
        '
        '
        '
        '
        Me.tbMes.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.tbMes.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbMes.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.tbMes.Location = New System.Drawing.Point(56, 284)
        Me.tbMes.MaxValue = 12
        Me.tbMes.MinValue = 1
        Me.tbMes.Name = "tbMes"
        Me.tbMes.ShowUpDown = True
        Me.tbMes.Size = New System.Drawing.Size(81, 20)
        Me.tbMes.TabIndex = 19
        Me.tbMes.Value = 1
        '
        'tbAnio
        '
        '
        '
        '
        Me.tbAnio.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.tbAnio.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbAnio.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.tbAnio.Location = New System.Drawing.Point(55, 251)
        Me.tbAnio.MaxValue = 3000
        Me.tbAnio.MinValue = 1980
        Me.tbAnio.Name = "tbAnio"
        Me.tbAnio.ShowUpDown = True
        Me.tbAnio.Size = New System.Drawing.Size(81, 20)
        Me.tbAnio.TabIndex = 18
        Me.tbAnio.Value = 2016
        '
        'LabelX3
        '
        Me.LabelX3.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Location = New System.Drawing.Point(14, 281)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(37, 23)
        Me.LabelX3.TabIndex = 17
        Me.LabelX3.Text = "MES:"
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Location = New System.Drawing.Point(13, 251)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(36, 23)
        Me.LabelX2.TabIndex = 16
        Me.LabelX2.Text = "AÑO:"
        '
        'GroupPanel2
        '
        Me.GroupPanel2.BackColor = System.Drawing.Color.Transparent
        Me.GroupPanel2.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel2.Controls.Add(Me.LabelX1)
        Me.GroupPanel2.Controls.Add(Me.JMc_Persona)
        Me.GroupPanel2.Controls.Add(Me.Sw_Filtrar)
        Me.GroupPanel2.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupPanel2.Location = New System.Drawing.Point(0, 133)
        Me.GroupPanel2.Margin = New System.Windows.Forms.Padding(15)
        Me.GroupPanel2.Name = "GroupPanel2"
        Me.GroupPanel2.Padding = New System.Windows.Forms.Padding(15)
        Me.GroupPanel2.Size = New System.Drawing.Size(270, 100)
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
        Me.GroupPanel2.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanel2.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel2.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel2.TabIndex = 14
        Me.GroupPanel2.Text = "PERSONA"
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Location = New System.Drawing.Point(10, 18)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(51, 23)
        Me.LabelX1.TabIndex = 14
        Me.LabelX1.Text = "FILTRAR:"
        '
        'JMc_Persona
        '
        JMc_Persona_DesignTimeLayout.LayoutString = resources.GetString("JMc_Persona_DesignTimeLayout.LayoutString")
        Me.JMc_Persona.DesignTimeLayout = JMc_Persona_DesignTimeLayout
        Me.JMc_Persona.Location = New System.Drawing.Point(9, 45)
        Me.JMc_Persona.Name = "JMc_Persona"
        Me.JMc_Persona.SelectedIndex = -1
        Me.JMc_Persona.SelectedItem = Nothing
        Me.JMc_Persona.Size = New System.Drawing.Size(255, 20)
        Me.JMc_Persona.TabIndex = 12
        '
        'Sw_Filtrar
        '
        '
        '
        '
        Me.Sw_Filtrar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Sw_Filtrar.Location = New System.Drawing.Point(67, 17)
        Me.Sw_Filtrar.Name = "Sw_Filtrar"
        Me.Sw_Filtrar.OffText = "NO"
        Me.Sw_Filtrar.OnText = "SI"
        Me.Sw_Filtrar.Size = New System.Drawing.Size(66, 22)
        Me.Sw_Filtrar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Sw_Filtrar.TabIndex = 13
        '
        'ButtonX1
        '
        Me.ButtonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX1.Dock = System.Windows.Forms.DockStyle.Top
        Me.ButtonX1.Image = Global.Presentacion.My.Resources.Resources.ResumenSueldos
        Me.ButtonX1.ImageFixedSize = New System.Drawing.Size(80, 80)
        Me.ButtonX1.Location = New System.Drawing.Point(0, 0)
        Me.ButtonX1.Name = "ButtonX1"
        Me.ButtonX1.Size = New System.Drawing.Size(270, 70)
        Me.ButtonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX1.TabIndex = 20
        Me.ButtonX1.Text = "RESUMEN DE SUELDOS"
        '
        'BubbleBar1
        '
        Me.BubbleBar1.Alignment = DevComponents.DotNetBar.eBubbleButtonAlignment.Bottom
        Me.BubbleBar1.AntiAlias = True
        Me.BubbleBar1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.BubbleBar1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        '
        '
        '
        Me.BubbleBar1.ButtonBackAreaStyle.BackColor = System.Drawing.Color.Transparent
        Me.BubbleBar1.ButtonBackAreaStyle.BorderBottomWidth = 1
        Me.BubbleBar1.ButtonBackAreaStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.BubbleBar1.ButtonBackAreaStyle.BorderLeftWidth = 1
        Me.BubbleBar1.ButtonBackAreaStyle.BorderRightWidth = 1
        Me.BubbleBar1.ButtonBackAreaStyle.BorderTopWidth = 1
        Me.BubbleBar1.ButtonBackAreaStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.BubbleBar1.ButtonBackAreaStyle.PaddingBottom = 3
        Me.BubbleBar1.ButtonBackAreaStyle.PaddingLeft = 3
        Me.BubbleBar1.ButtonBackAreaStyle.PaddingRight = 3
        Me.BubbleBar1.ButtonBackAreaStyle.PaddingTop = 3
        Me.BubbleBar1.ImageSizeLarge = New System.Drawing.Size(72, 72)
        Me.BubbleBar1.ImageSizeNormal = New System.Drawing.Size(64, 64)
        Me.BubbleBar1.Location = New System.Drawing.Point(55, 323)
        Me.BubbleBar1.MouseOverTabColors.BorderColor = System.Drawing.SystemColors.Highlight
        Me.BubbleBar1.Name = "BubbleBar1"
        Me.BubbleBar1.SelectedTab = Me.BubbleBarTab1
        Me.BubbleBar1.SelectedTabColors.BorderColor = System.Drawing.Color.Black
        Me.BubbleBar1.Size = New System.Drawing.Size(161, 74)
        Me.BubbleBar1.TabIndex = 15
        Me.BubbleBar1.Tabs.Add(Me.BubbleBarTab1)
        Me.BubbleBar1.TabsVisible = False
        Me.BubbleBar1.Text = "BubbleBar1"
        '
        'BubbleBarTab1
        '
        Me.BubbleBarTab1.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.BubbleBarTab1.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.BubbleBarTab1.Buttons.AddRange(New DevComponents.DotNetBar.BubbleButton() {Me.BubbleButton7, Me.BubbleButton5})
        Me.BubbleBarTab1.DarkBorderColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(105, Byte), Integer), CType(CType(105, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.BubbleBarTab1.LightBorderColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.BubbleBarTab1.Name = "BubbleBarTab1"
        Me.BubbleBarTab1.PredefinedColor = DevComponents.DotNetBar.eTabItemColor.Blue
        Me.BubbleBarTab1.Text = "BubbleBarTab1"
        Me.BubbleBarTab1.TextColor = System.Drawing.Color.Black
        '
        'BubbleButton7
        '
        Me.BubbleButton7.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BubbleButton7.Image = Global.Presentacion.My.Resources.Resources.GENERAR_REPORTE
        Me.BubbleButton7.ImageLarge = Global.Presentacion.My.Resources.Resources.GENERAR_REPORTE
        Me.BubbleButton7.Name = "BubbleButton7"
        Me.BubbleButton7.TooltipText = "Generar"
        '
        'BubbleButton5
        '
        Me.BubbleButton5.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BubbleButton5.Image = Global.Presentacion.My.Resources.Resources.CANCELAR
        Me.BubbleButton5.ImageLarge = Global.Presentacion.My.Resources.Resources.CANCELAR
        Me.BubbleButton5.Name = "BubbleButton5"
        Me.BubbleButton5.TooltipText = "Salir"
        '
        'PanelEx1
        '
        Me.PanelEx1.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanelEx1.Controls.Add(Me.CrystalReportViewer1)
        Me.PanelEx1.DisabledBackColor = System.Drawing.Color.Empty
        Me.PanelEx1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelEx1.Location = New System.Drawing.Point(276, 0)
        Me.PanelEx1.Name = "PanelEx1"
        Me.PanelEx1.Size = New System.Drawing.Size(384, 496)
        Me.PanelEx1.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.PanelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.PanelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelEx1.Style.GradientAngle = 90
        Me.PanelEx1.TabIndex = 1
        Me.PanelEx1.Text = "PanelEx1"
        '
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.ActiveViewIndex = -1
        Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default
        Me.CrystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(384, 496)
        Me.CrystalReportViewer1.TabIndex = 0
        '
        'GroupPanel3
        '
        Me.GroupPanel3.BackColor = System.Drawing.Color.Transparent
        Me.GroupPanel3.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel3.Controls.Add(Me.tbPlanilla)
        Me.GroupPanel3.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupPanel3.Location = New System.Drawing.Point(0, 70)
        Me.GroupPanel3.Margin = New System.Windows.Forms.Padding(15)
        Me.GroupPanel3.Name = "GroupPanel3"
        Me.GroupPanel3.Padding = New System.Windows.Forms.Padding(15)
        Me.GroupPanel3.Size = New System.Drawing.Size(270, 63)
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
        Me.GroupPanel3.TabIndex = 21
        Me.GroupPanel3.Text = "PLANILLA"
        '
        'tbPlanilla
        '
        '
        '
        '
        Me.tbPlanilla.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbPlanilla.Location = New System.Drawing.Point(11, 9)
        Me.tbPlanilla.Name = "tbPlanilla"
        Me.tbPlanilla.OffText = "NO"
        Me.tbPlanilla.OnText = "SI"
        Me.tbPlanilla.Size = New System.Drawing.Size(80, 22)
        Me.tbPlanilla.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.tbPlanilla.TabIndex = 13
        '
        'PR_PlanillaSueldos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(660, 496)
        Me.Controls.Add(Me.PanelEx1)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Name = "PR_PlanillaSueldos"
        Me.Text = "PR_PlanillaSueldos"
        Me.GroupPanel1.ResumeLayout(False)
        CType(Me.tbMes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbAnio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel2.ResumeLayout(False)
        Me.GroupPanel2.PerformLayout()
        CType(Me.JMc_Persona, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BubbleBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelEx1.ResumeLayout(False)
        Me.GroupPanel3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents PanelEx1 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents GroupPanel2 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents JMc_Persona As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Sw_Filtrar As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents BubbleBar1 As DevComponents.DotNetBar.BubbleBar
    Friend WithEvents BubbleBarTab1 As DevComponents.DotNetBar.BubbleBarTab
    Friend WithEvents BubbleButton7 As DevComponents.DotNetBar.BubbleButton
    Friend WithEvents BubbleButton5 As DevComponents.DotNetBar.BubbleButton
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents tbMes As DevComponents.Editors.IntegerInput
    Friend WithEvents tbAnio As DevComponents.Editors.IntegerInput
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents ButtonX1 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents GroupPanel3 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents tbPlanilla As DevComponents.DotNetBar.Controls.SwitchButton
End Class
