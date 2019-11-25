<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PR_SocioEdad
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.LabelX12 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.DtiFechaIni = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.DtiFechaFin = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
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
        Me.Panel1.SuspendLayout()
        CType(Me.DtiFechaIni, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DtiFechaFin, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.SuperTabControlPanelRegistro.Controls.SetChildIndex(Me.PanelIzq, 0)
        Me.SuperTabControlPanelRegistro.Controls.SetChildIndex(Me.PanelInferior, 0)
        Me.SuperTabControlPanelRegistro.Controls.SetChildIndex(Me.PanelPrincipal, 0)
        '
        'PanelSuperior
        '
        Me.PanelSuperior.Size = New System.Drawing.Size(374, 72)
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
        Me.PanelInferior.Location = New System.Drawing.Point(374, 500)
        Me.PanelInferior.Size = New System.Drawing.Size(510, 36)
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
        Me.PanelToolBar1.Location = New System.Drawing.Point(113, 0)
        '
        'btnSalir
        '
        '
        'btnGenerar
        '
        '
        'PanelPrincipal
        '
        Me.PanelPrincipal.Location = New System.Drawing.Point(374, 0)
        Me.PanelPrincipal.Size = New System.Drawing.Size(510, 500)
        '
        'MPanelUserAct
        '
        Me.MPanelUserAct.Location = New System.Drawing.Point(310, 0)
        '
        'MReportViewer
        '
        Me.MReportViewer.Size = New System.Drawing.Size(510, 500)
        Me.MReportViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        '
        'MGPFiltros
        '
        Me.MGPFiltros.Controls.Add(Me.Panel1)
        Me.MGPFiltros.Size = New System.Drawing.Size(374, 464)
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
        Me.PanelIzq.Size = New System.Drawing.Size(374, 536)
        Me.PanelIzq.Controls.SetChildIndex(Me.PanelSuperior, 0)
        Me.PanelIzq.Controls.SetChildIndex(Me.MGPFiltros, 0)
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.DtiFechaFin)
        Me.Panel1.Controls.Add(Me.DtiFechaIni)
        Me.Panel1.Controls.Add(Me.LabelX1)
        Me.Panel1.Controls.Add(Me.LabelX12)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(368, 80)
        Me.Panel1.TabIndex = 45
        '
        'LabelX12
        '
        Me.LabelX12.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX12.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX12.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX12.Location = New System.Drawing.Point(9, 3)
        Me.LabelX12.Name = "LabelX12"
        Me.LabelX12.Size = New System.Drawing.Size(100, 23)
        Me.LabelX12.TabIndex = 40
        Me.LabelX12.Text = "Desde:"
        Me.LabelX12.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX1.Location = New System.Drawing.Point(9, 32)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(100, 23)
        Me.LabelX1.TabIndex = 41
        Me.LabelX1.Text = "Hasta:"
        Me.LabelX1.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'DtiFechaIni
        '
        '
        '
        '
        Me.DtiFechaIni.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.DtiFechaIni.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.DtiFechaIni.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.DtiFechaIni.ButtonDropDown.Visible = True
        Me.DtiFechaIni.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DtiFechaIni.Format = DevComponents.Editors.eDateTimePickerFormat.[Long]
        Me.DtiFechaIni.IsPopupCalendarOpen = False
        Me.DtiFechaIni.Location = New System.Drawing.Point(115, 3)
        '
        '
        '
        '
        '
        '
        Me.DtiFechaIni.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.DtiFechaIni.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.DtiFechaIni.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.DtiFechaIni.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.DtiFechaIni.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.DtiFechaIni.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.DtiFechaIni.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.DtiFechaIni.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.DtiFechaIni.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.DtiFechaIni.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.DtiFechaIni.MonthCalendar.DisplayMonth = New Date(2017, 2, 1, 0, 0, 0, 0)
        Me.DtiFechaIni.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday
        '
        '
        '
        Me.DtiFechaIni.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.DtiFechaIni.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.DtiFechaIni.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.DtiFechaIni.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.DtiFechaIni.MonthCalendar.TodayButtonVisible = True
        Me.DtiFechaIni.Name = "DtiFechaIni"
        Me.DtiFechaIni.Size = New System.Drawing.Size(250, 23)
        Me.DtiFechaIni.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.DtiFechaIni.TabIndex = 42
        '
        'DtiFechaFin
        '
        '
        '
        '
        Me.DtiFechaFin.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.DtiFechaFin.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.DtiFechaFin.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.DtiFechaFin.ButtonDropDown.Visible = True
        Me.DtiFechaFin.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DtiFechaFin.Format = DevComponents.Editors.eDateTimePickerFormat.[Long]
        Me.DtiFechaFin.IsPopupCalendarOpen = False
        Me.DtiFechaFin.Location = New System.Drawing.Point(115, 32)
        '
        '
        '
        '
        '
        '
        Me.DtiFechaFin.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.DtiFechaFin.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.DtiFechaFin.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.DtiFechaFin.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.DtiFechaFin.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.DtiFechaFin.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.DtiFechaFin.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.DtiFechaFin.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.DtiFechaFin.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.DtiFechaFin.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.DtiFechaFin.MonthCalendar.DisplayMonth = New Date(2017, 2, 1, 0, 0, 0, 0)
        Me.DtiFechaFin.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday
        '
        '
        '
        Me.DtiFechaFin.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.DtiFechaFin.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.DtiFechaFin.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.DtiFechaFin.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.DtiFechaFin.MonthCalendar.TodayButtonVisible = True
        Me.DtiFechaFin.Name = "DtiFechaFin"
        Me.DtiFechaFin.Size = New System.Drawing.Size(250, 23)
        Me.DtiFechaFin.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.DtiFechaFin.TabIndex = 43
        '
        'PR_SocioEdad
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(884, 561)
        Me.Location = New System.Drawing.Point(0, 0)
        Me.Name = "PR_SocioEdad"
        Me.Text = "PR_SocioEdad"
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
        Me.Panel1.ResumeLayout(False)
        CType(Me.DtiFechaIni, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DtiFechaFin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents DtiFechaFin As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents DtiFechaIni As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX12 As DevComponents.DotNetBar.LabelX
End Class
