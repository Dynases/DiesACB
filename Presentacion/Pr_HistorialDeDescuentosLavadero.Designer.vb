<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Pr_HistorialDeDescuentosLavadero
    Inherits Modelos.ModeloR0

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.tbFiltrarCliente = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.tbcliente = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.Highlighter1 = New DevComponents.DotNetBar.Validator.Highlighter()
        Me.tbano = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.LabelX19 = New DevComponents.DotNetBar.LabelX()
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
        CType(Me.tbano, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.SuperTabControlPanelRegistro.Controls.SetChildIndex(Me.PanelInferior, 0)
        Me.SuperTabControlPanelRegistro.Controls.SetChildIndex(Me.PanelIzq, 0)
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
        Me.PanelInferior.Location = New System.Drawing.Point(0, 618)
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
        'btnGenerar
        '
        '
        'PanelPrincipal
        '
        Me.PanelPrincipal.Size = New System.Drawing.Size(695, 618)
        '
        'MReportViewer
        '
        Me.MReportViewer.Size = New System.Drawing.Size(695, 618)
        Me.MReportViewer.ToolPanelWidth = 267
        '
        'MGPFiltros
        '
        Me.MGPFiltros.Controls.Add(Me.GroupPanel1)
        Me.MGPFiltros.Size = New System.Drawing.Size(484, 529)
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
        Me.PanelIzq.Size = New System.Drawing.Size(484, 618)
        Me.PanelIzq.Controls.SetChildIndex(Me.PanelSuperior, 0)
        Me.PanelIzq.Controls.SetChildIndex(Me.MGPFiltros, 0)
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.Transparent
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.tbano)
        Me.GroupPanel1.Controls.Add(Me.LabelX19)
        Me.GroupPanel1.Controls.Add(Me.LabelX4)
        Me.GroupPanel1.Controls.Add(Me.tbFiltrarCliente)
        Me.GroupPanel1.Controls.Add(Me.tbcliente)
        Me.GroupPanel1.Controls.Add(Me.LabelX1)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupPanel1.Location = New System.Drawing.Point(0, 0)
        Me.GroupPanel1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(478, 196)
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
        Me.GroupPanel1.TabIndex = 48
        Me.GroupPanel1.Text = "CLIENTE"
        '
        'LabelX4
        '
        Me.LabelX4.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX4.Location = New System.Drawing.Point(8, 98)
        Me.LabelX4.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(120, 28)
        Me.LabelX4.TabIndex = 48
        Me.LabelX4.Text = "CLIENTE:"
        '
        'tbFiltrarCliente
        '
        '
        '
        '
        Me.tbFiltrarCliente.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbFiltrarCliente.Location = New System.Drawing.Point(143, 14)
        Me.tbFiltrarCliente.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.tbFiltrarCliente.Name = "tbFiltrarCliente"
        Me.tbFiltrarCliente.OffBackColor = System.Drawing.Color.DodgerBlue
        Me.tbFiltrarCliente.OffText = "CLIENTE"
        Me.tbFiltrarCliente.OffTextColor = System.Drawing.Color.White
        Me.tbFiltrarCliente.OnBackColor = System.Drawing.Color.Blue
        Me.tbFiltrarCliente.OnText = "TODOS"
        Me.tbFiltrarCliente.OnTextColor = System.Drawing.Color.White
        Me.tbFiltrarCliente.Size = New System.Drawing.Size(136, 27)
        Me.tbFiltrarCliente.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.tbFiltrarCliente.TabIndex = 45
        '
        'tbcliente
        '
        '
        '
        '
        Me.tbcliente.Border.Class = "TextBoxBorder"
        Me.tbcliente.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbcliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbcliente.Location = New System.Drawing.Point(8, 129)
        Me.tbcliente.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.tbcliente.Name = "tbcliente"
        Me.tbcliente.PreventEnterBeep = True
        Me.tbcliente.ReadOnly = True
        Me.tbcliente.Size = New System.Drawing.Size(451, 26)
        Me.tbcliente.TabIndex = 42
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
        Me.LabelX1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(120, 28)
        Me.LabelX1.TabIndex = 41
        Me.LabelX1.Text = "FILTRAR POR:"
        '
        'Highlighter1
        '
        Me.Highlighter1.ContainerControl = Me
        '
        'tbano
        '
        '
        '
        '
        Me.tbano.BackgroundStyle.BackColor = System.Drawing.Color.Gold
        Me.tbano.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.tbano.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.tbano.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.tbano.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.tbano.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.tbano.BackgroundStyle.CornerDiameter = 4
        Me.tbano.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.tbano.BackgroundStyle.CornerTypeBottomLeft = DevComponents.DotNetBar.eCornerType.Rounded
        Me.tbano.BackgroundStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbano.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.tbano.ButtonDropDown.Symbol = "57745"
        Me.tbano.ButtonDropDown.SymbolColor = System.Drawing.Color.DarkBlue
        Me.tbano.ButtonDropDown.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.tbano.Colors.Highlight = System.Drawing.Color.White
        Me.tbano.Colors.HighlightText = System.Drawing.Color.Black
        Me.tbano.Cursor = System.Windows.Forms.Cursors.Default
        Me.tbano.CustomFormat = "yyyy"
        Me.tbano.DisabledBackColor = System.Drawing.Color.Gold
        Me.tbano.DisabledForeColor = System.Drawing.Color.Black
        Me.tbano.Font = New System.Drawing.Font("Imprint MT Shadow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbano.ForeColor = System.Drawing.Color.Black
        Me.tbano.Format = DevComponents.Editors.eDateTimePickerFormat.Custom
        Me.tbano.IsPopupCalendarOpen = False
        Me.tbano.Location = New System.Drawing.Point(143, 48)
        '
        '
        '
        '
        '
        '
        Me.tbano.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbano.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.tbano.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.tbano.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.tbano.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.tbano.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.tbano.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.tbano.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.tbano.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.tbano.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbano.MonthCalendar.DisplayMonth = New Date(2017, 10, 1, 0, 0, 0, 0)
        Me.tbano.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday
        '
        '
        '
        Me.tbano.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.tbano.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.tbano.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.tbano.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbano.MonthCalendar.TodayButtonVisible = True
        Me.tbano.Name = "tbano"
        Me.tbano.ShowUpDown = True
        Me.tbano.Size = New System.Drawing.Size(139, 35)
        Me.tbano.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.tbano.TabIndex = 147
        Me.tbano.TimeSelectorTimeFormat = DevComponents.Editors.DateTimeAdv.eTimeSelectorFormat.Time24H
        Me.tbano.Value = New Date(2018, 1, 1, 0, 0, 0, 0)
        Me.tbano.WatermarkColor = System.Drawing.Color.Gold
        '
        'LabelX19
        '
        Me.LabelX19.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX19.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX19.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX19.Location = New System.Drawing.Point(7, 48)
        Me.LabelX19.Margin = New System.Windows.Forms.Padding(4)
        Me.LabelX19.Name = "LabelX19"
        Me.LabelX19.Size = New System.Drawing.Size(111, 28)
        Me.LabelX19.TabIndex = 146
        Me.LabelX19.Text = "GESTION:"
        Me.LabelX19.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'Pr_HistorialDeDescuentosLavadero
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1179, 690)
        Me.Location = New System.Drawing.Point(0, 0)
        Me.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.Name = "Pr_HistorialDeDescuentosLavadero"
        Me.Text = "Pr_HistorialRemolque"
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
        CType(Me.tbano, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tbcliente As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Public WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents tbFiltrarCliente As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Highlighter1 As DevComponents.DotNetBar.Validator.Highlighter
    Protected WithEvents tbano As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents LabelX19 As DevComponents.DotNetBar.LabelX
End Class
