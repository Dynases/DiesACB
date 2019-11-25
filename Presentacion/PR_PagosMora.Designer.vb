<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PR_PagosMora
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
        Dim CbFiltro_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PR_PagosMora))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.RbSinMora = New System.Windows.Forms.RadioButton()
        Me.TbiCantidadMeses = New DevComponents.Editors.IntegerInput()
        Me.RbCantMeses = New System.Windows.Forms.RadioButton()
        Me.RbInactivos = New System.Windows.Forms.RadioButton()
        Me.RbMora = New System.Windows.Forms.RadioButton()
        Me.RbGeneral = New System.Windows.Forms.RadioButton()
        Me.CbFiltro = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.LabelX12 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.SbUnoTodos = New DevComponents.DotNetBar.Controls.SwitchButton()
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
        CType(Me.TbiCantidadMeses, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CbFiltro, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.Panel1.Controls.Add(Me.LabelX1)
        Me.Panel1.Controls.Add(Me.SbUnoTodos)
        Me.Panel1.Controls.Add(Me.CbFiltro)
        Me.Panel1.Controls.Add(Me.LabelX12)
        Me.Panel1.Controls.Add(Me.RbSinMora)
        Me.Panel1.Controls.Add(Me.TbiCantidadMeses)
        Me.Panel1.Controls.Add(Me.RbCantMeses)
        Me.Panel1.Controls.Add(Me.RbInactivos)
        Me.Panel1.Controls.Add(Me.RbMora)
        Me.Panel1.Controls.Add(Me.RbGeneral)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(368, 220)
        Me.Panel1.TabIndex = 45
        '
        'RbSinMora
        '
        Me.RbSinMora.AutoSize = True
        Me.RbSinMora.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RbSinMora.Location = New System.Drawing.Point(31, 45)
        Me.RbSinMora.Name = "RbSinMora"
        Me.RbSinMora.Size = New System.Drawing.Size(94, 21)
        Me.RbSinMora.TabIndex = 5
        Me.RbSinMora.TabStop = True
        Me.RbSinMora.Text = "Solo al Dia"
        Me.RbSinMora.UseVisualStyleBackColor = True
        '
        'TbiCantidadMeses
        '
        '
        '
        '
        Me.TbiCantidadMeses.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.TbiCantidadMeses.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TbiCantidadMeses.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.TbiCantidadMeses.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TbiCantidadMeses.Location = New System.Drawing.Point(174, 124)
        Me.TbiCantidadMeses.MinValue = 1
        Me.TbiCantidadMeses.Name = "TbiCantidadMeses"
        Me.TbiCantidadMeses.Size = New System.Drawing.Size(80, 23)
        Me.TbiCantidadMeses.TabIndex = 4
        Me.TbiCantidadMeses.Value = 1
        '
        'RbCantMeses
        '
        Me.RbCantMeses.AutoSize = True
        Me.RbCantMeses.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RbCantMeses.Location = New System.Drawing.Point(31, 126)
        Me.RbCantMeses.Name = "RbCantMeses"
        Me.RbCantMeses.Size = New System.Drawing.Size(147, 21)
        Me.RbCantMeses.TabIndex = 3
        Me.RbCantMeses.TabStop = True
        Me.RbCantMeses.Text = "Cantidad Meses >="
        Me.RbCantMeses.UseVisualStyleBackColor = True
        '
        'RbInactivos
        '
        Me.RbInactivos.AutoSize = True
        Me.RbInactivos.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RbInactivos.Location = New System.Drawing.Point(31, 99)
        Me.RbInactivos.Name = "RbInactivos"
        Me.RbInactivos.Size = New System.Drawing.Size(113, 21)
        Me.RbInactivos.TabIndex = 2
        Me.RbInactivos.TabStop = True
        Me.RbInactivos.Text = "Solo Inactivos"
        Me.RbInactivos.UseVisualStyleBackColor = True
        '
        'RbMora
        '
        Me.RbMora.AutoSize = True
        Me.RbMora.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RbMora.Location = New System.Drawing.Point(31, 72)
        Me.RbMora.Name = "RbMora"
        Me.RbMora.Size = New System.Drawing.Size(142, 21)
        Me.RbMora.TabIndex = 1
        Me.RbMora.TabStop = True
        Me.RbMora.Text = "Solo en Pendiente"
        Me.RbMora.UseVisualStyleBackColor = True
        '
        'RbGeneral
        '
        Me.RbGeneral.AutoSize = True
        Me.RbGeneral.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RbGeneral.Location = New System.Drawing.Point(31, 18)
        Me.RbGeneral.Name = "RbGeneral"
        Me.RbGeneral.Size = New System.Drawing.Size(77, 21)
        Me.RbGeneral.TabIndex = 0
        Me.RbGeneral.TabStop = True
        Me.RbGeneral.Text = "General"
        Me.RbGeneral.UseVisualStyleBackColor = True
        '
        'CbFiltro
        '
        CbFiltro_DesignTimeLayout.LayoutString = resources.GetString("CbFiltro_DesignTimeLayout.LayoutString")
        Me.CbFiltro.DesignTimeLayout = CbFiltro_DesignTimeLayout
        Me.CbFiltro.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CbFiltro.Location = New System.Drawing.Point(109, 181)
        Me.CbFiltro.Name = "CbFiltro"
        Me.CbFiltro.SelectedIndex = -1
        Me.CbFiltro.SelectedItem = Nothing
        Me.CbFiltro.Size = New System.Drawing.Size(250, 23)
        Me.CbFiltro.TabIndex = 43
        '
        'LabelX12
        '
        Me.LabelX12.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX12.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX12.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX12.Location = New System.Drawing.Point(3, 181)
        Me.LabelX12.Name = "LabelX12"
        Me.LabelX12.Size = New System.Drawing.Size(100, 23)
        Me.LabelX12.TabIndex = 42
        Me.LabelX12.Text = "Tipo de Socio:"
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
        Me.LabelX1.Location = New System.Drawing.Point(3, 152)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(100, 23)
        Me.LabelX1.TabIndex = 45
        Me.LabelX1.Text = "Filtrar:"
        Me.LabelX1.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'SbUnoTodos
        '
        '
        '
        '
        Me.SbUnoTodos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.SbUnoTodos.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SbUnoTodos.Location = New System.Drawing.Point(109, 153)
        Me.SbUnoTodos.Name = "SbUnoTodos"
        Me.SbUnoTodos.OffText = "TODOS"
        Me.SbUnoTodos.OnText = "UNO"
        Me.SbUnoTodos.Size = New System.Drawing.Size(100, 22)
        Me.SbUnoTodos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.SbUnoTodos.TabIndex = 44
        '
        'PR_PagosMora
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(884, 561)
        Me.Location = New System.Drawing.Point(0, 0)
        Me.Name = "PR_PagosMora"
        Me.Text = "PR_PagosMora"
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
        Me.Panel1.PerformLayout()
        CType(Me.TbiCantidadMeses, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CbFiltro, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents RbCantMeses As System.Windows.Forms.RadioButton
    Friend WithEvents RbInactivos As System.Windows.Forms.RadioButton
    Friend WithEvents RbMora As System.Windows.Forms.RadioButton
    Friend WithEvents RbGeneral As System.Windows.Forms.RadioButton
    Friend WithEvents TbiCantidadMeses As DevComponents.Editors.IntegerInput
    Friend WithEvents RbSinMora As System.Windows.Forms.RadioButton
    Friend WithEvents CbFiltro As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents LabelX12 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents SbUnoTodos As DevComponents.DotNetBar.Controls.SwitchButton
End Class
