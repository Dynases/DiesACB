<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PR_PlanillaMensualMarcacion
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
        Me.tbMes = New DevComponents.Editors.IntegerInput()
        Me.tbAnio = New DevComponents.Editors.IntegerInput()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupPanel2 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.tbPersonal = New System.Windows.Forms.TextBox()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.tbFiltrar = New DevComponents.DotNetBar.Controls.SwitchButton()
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
        CType(Me.tbMes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbAnio, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.SuperTabPrincipal.Size = New System.Drawing.Size(1204, 690)
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
        Me.SuperTabControlPanelRegistro.Size = New System.Drawing.Size(1204, 662)
        Me.SuperTabControlPanelRegistro.Controls.SetChildIndex(Me.PanelInferior, 0)
        Me.SuperTabControlPanelRegistro.Controls.SetChildIndex(Me.PanelIzq, 0)
        Me.SuperTabControlPanelRegistro.Controls.SetChildIndex(Me.PanelPrincipal, 0)
        '
        'PanelSuperior
        '
        Me.PanelSuperior.Margin = New System.Windows.Forms.Padding(5)
        Me.PanelSuperior.Size = New System.Drawing.Size(343, 89)
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
        Me.PanelInferior.Location = New System.Drawing.Point(0, 618)
        Me.PanelInferior.Size = New System.Drawing.Size(1204, 44)
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
        Me.PanelToolBar1.Location = New System.Drawing.Point(55, 0)
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
        Me.PanelPrincipal.Location = New System.Drawing.Point(343, 0)
        Me.PanelPrincipal.Margin = New System.Windows.Forms.Padding(5)
        Me.PanelPrincipal.Size = New System.Drawing.Size(861, 618)
        '
        'MPanelUserAct
        '
        Me.MPanelUserAct.Location = New System.Drawing.Point(937, 0)
        '
        'MReportViewer
        '
        Me.MReportViewer.Margin = New System.Windows.Forms.Padding(5)
        Me.MReportViewer.Size = New System.Drawing.Size(861, 618)
        Me.MReportViewer.ToolPanelWidth = 267
        '
        'MGPFiltros
        '
        Me.MGPFiltros.Controls.Add(Me.GroupPanel2)
        Me.MGPFiltros.Controls.Add(Me.Panel1)
        Me.MGPFiltros.Margin = New System.Windows.Forms.Padding(5)
        Me.MGPFiltros.Size = New System.Drawing.Size(343, 529)
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
        Me.PanelIzq.Size = New System.Drawing.Size(343, 618)
        Me.PanelIzq.Controls.SetChildIndex(Me.PanelSuperior, 0)
        Me.PanelIzq.Controls.SetChildIndex(Me.MGPFiltros, 0)
        '
        'tbMes
        '
        '
        '
        '
        Me.tbMes.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.tbMes.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbMes.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.tbMes.Location = New System.Drawing.Point(78, 58)
        Me.tbMes.Margin = New System.Windows.Forms.Padding(4)
        Me.tbMes.MaxValue = 12
        Me.tbMes.MinValue = 1
        Me.tbMes.Name = "tbMes"
        Me.tbMes.ShowUpDown = True
        Me.tbMes.Size = New System.Drawing.Size(108, 26)
        Me.tbMes.TabIndex = 27
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
        Me.tbAnio.Location = New System.Drawing.Point(76, 17)
        Me.tbAnio.Margin = New System.Windows.Forms.Padding(4)
        Me.tbAnio.MaxValue = 3000
        Me.tbAnio.MinValue = 1980
        Me.tbAnio.Name = "tbAnio"
        Me.tbAnio.ShowUpDown = True
        Me.tbAnio.Size = New System.Drawing.Size(108, 26)
        Me.tbAnio.TabIndex = 26
        Me.tbAnio.Value = 2016
        '
        'LabelX3
        '
        Me.LabelX3.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Location = New System.Drawing.Point(22, 54)
        Me.LabelX3.Margin = New System.Windows.Forms.Padding(4)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(49, 28)
        Me.LabelX3.TabIndex = 25
        Me.LabelX3.Text = "MES:"
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Location = New System.Drawing.Point(20, 17)
        Me.LabelX2.Margin = New System.Windows.Forms.Padding(4)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(48, 28)
        Me.LabelX2.TabIndex = 24
        Me.LabelX2.Text = "AÑO:"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.LabelX2)
        Me.Panel1.Controls.Add(Me.tbMes)
        Me.Panel1.Controls.Add(Me.LabelX3)
        Me.Panel1.Controls.Add(Me.tbAnio)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(337, 100)
        Me.Panel1.TabIndex = 28
        '
        'GroupPanel2
        '
        Me.GroupPanel2.BackColor = System.Drawing.Color.Transparent
        Me.GroupPanel2.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel2.Controls.Add(Me.tbPersonal)
        Me.GroupPanel2.Controls.Add(Me.LabelX1)
        Me.GroupPanel2.Controls.Add(Me.tbFiltrar)
        Me.GroupPanel2.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupPanel2.Location = New System.Drawing.Point(0, 100)
        Me.GroupPanel2.Margin = New System.Windows.Forms.Padding(20, 18, 20, 18)
        Me.GroupPanel2.Name = "GroupPanel2"
        Me.GroupPanel2.Padding = New System.Windows.Forms.Padding(20, 18, 20, 18)
        Me.GroupPanel2.Size = New System.Drawing.Size(337, 134)
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
        Me.GroupPanel2.TabIndex = 29
        Me.GroupPanel2.Text = "PERSONAL"
        '
        'tbPersonal
        '
        Me.tbPersonal.Location = New System.Drawing.Point(6, 55)
        Me.tbPersonal.Name = "tbPersonal"
        Me.tbPersonal.Size = New System.Drawing.Size(320, 26)
        Me.tbPersonal.TabIndex = 15
        Me.tbPersonal.Tag = "0"
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Location = New System.Drawing.Point(8, 20)
        Me.LabelX1.Margin = New System.Windows.Forms.Padding(4)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(75, 28)
        Me.LabelX1.TabIndex = 14
        Me.LabelX1.Text = "FILTRAR:"
        '
        'tbFiltrar
        '
        '
        '
        '
        Me.tbFiltrar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbFiltrar.Location = New System.Drawing.Point(89, 21)
        Me.tbFiltrar.Margin = New System.Windows.Forms.Padding(4)
        Me.tbFiltrar.Name = "tbFiltrar"
        Me.tbFiltrar.OffText = "NO"
        Me.tbFiltrar.OnText = "SI"
        Me.tbFiltrar.Size = New System.Drawing.Size(88, 27)
        Me.tbFiltrar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.tbFiltrar.TabIndex = 13
        '
        'PR_PlanillaMensualMarcacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1204, 690)
        Me.Location = New System.Drawing.Point(0, 0)
        Me.Margin = New System.Windows.Forms.Padding(5)
        Me.Name = "PR_PlanillaMensualMarcacion"
        Me.Text = "PR_PlanillaMensualMarcacion"
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
        CType(Me.tbMes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbAnio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.GroupPanel2.ResumeLayout(False)
        Me.GroupPanel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tbMes As DevComponents.Editors.IntegerInput
    Friend WithEvents tbAnio As DevComponents.Editors.IntegerInput
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents GroupPanel2 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents tbFiltrar As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents Panel1 As Panel
    Friend WithEvents tbPersonal As TextBox
End Class
