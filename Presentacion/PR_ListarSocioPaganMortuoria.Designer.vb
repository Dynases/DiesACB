<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PR_ListarSocioPaganMortuoria
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
        Me.GroupPanelTipoSocio = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.RbHonorario = New System.Windows.Forms.RadioButton()
        Me.RbActivo = New System.Windows.Forms.RadioButton()
        Me.RbMeritorio = New System.Windows.Forms.RadioButton()
        Me.GroupPanelCriterio = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.RbNoMor = New System.Windows.Forms.RadioButton()
        Me.RbSiMor = New System.Windows.Forms.RadioButton()
        Me.RbTodos = New System.Windows.Forms.RadioButton()
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
        Me.GroupPanelTipoSocio.SuspendLayout()
        Me.GroupPanelCriterio.SuspendLayout()
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
        'MGPFiltros
        '
        Me.MGPFiltros.Controls.Add(Me.GroupPanelCriterio)
        Me.MGPFiltros.Controls.Add(Me.GroupPanelTipoSocio)
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
        Me.PanelIzq.Controls.SetChildIndex(Me.PanelSuperior, 0)
        Me.PanelIzq.Controls.SetChildIndex(Me.MGPFiltros, 0)
        '
        'GroupPanelTipoSocio
        '
        Me.GroupPanelTipoSocio.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanelTipoSocio.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanelTipoSocio.Controls.Add(Me.RbMeritorio)
        Me.GroupPanelTipoSocio.Controls.Add(Me.RbActivo)
        Me.GroupPanelTipoSocio.Controls.Add(Me.RbHonorario)
        Me.GroupPanelTipoSocio.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanelTipoSocio.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupPanelTipoSocio.Location = New System.Drawing.Point(0, 0)
        Me.GroupPanelTipoSocio.Name = "GroupPanelTipoSocio"
        Me.GroupPanelTipoSocio.Size = New System.Drawing.Size(357, 103)
        '
        '
        '
        Me.GroupPanelTipoSocio.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GroupPanelTipoSocio.Style.BackColorGradientAngle = 90
        Me.GroupPanelTipoSocio.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.GroupPanelTipoSocio.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanelTipoSocio.Style.BorderBottomWidth = 1
        Me.GroupPanelTipoSocio.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanelTipoSocio.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanelTipoSocio.Style.BorderLeftWidth = 1
        Me.GroupPanelTipoSocio.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanelTipoSocio.Style.BorderRightWidth = 1
        Me.GroupPanelTipoSocio.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanelTipoSocio.Style.BorderTopWidth = 1
        Me.GroupPanelTipoSocio.Style.CornerDiameter = 4
        Me.GroupPanelTipoSocio.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanelTipoSocio.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanelTipoSocio.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanelTipoSocio.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanelTipoSocio.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanelTipoSocio.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanelTipoSocio.TabIndex = 0
        Me.GroupPanelTipoSocio.Text = "TIPO DE SOCIO"
        '
        'RbHonorario
        '
        Me.RbHonorario.AutoSize = True
        Me.RbHonorario.BackColor = System.Drawing.Color.Transparent
        Me.RbHonorario.Location = New System.Drawing.Point(58, 3)
        Me.RbHonorario.Name = "RbHonorario"
        Me.RbHonorario.Size = New System.Drawing.Size(138, 20)
        Me.RbHonorario.TabIndex = 0
        Me.RbHonorario.TabStop = True
        Me.RbHonorario.Text = "Socios Honorarios"
        Me.RbHonorario.UseVisualStyleBackColor = False
        '
        'RbActivo
        '
        Me.RbActivo.AutoSize = True
        Me.RbActivo.BackColor = System.Drawing.Color.Transparent
        Me.RbActivo.Location = New System.Drawing.Point(58, 29)
        Me.RbActivo.Name = "RbActivo"
        Me.RbActivo.Size = New System.Drawing.Size(115, 20)
        Me.RbActivo.TabIndex = 1
        Me.RbActivo.TabStop = True
        Me.RbActivo.Text = "Socios Activos"
        Me.RbActivo.UseVisualStyleBackColor = False
        '
        'RbMeritorio
        '
        Me.RbMeritorio.AutoSize = True
        Me.RbMeritorio.BackColor = System.Drawing.Color.Transparent
        Me.RbMeritorio.Location = New System.Drawing.Point(58, 55)
        Me.RbMeritorio.Name = "RbMeritorio"
        Me.RbMeritorio.Size = New System.Drawing.Size(130, 20)
        Me.RbMeritorio.TabIndex = 2
        Me.RbMeritorio.TabStop = True
        Me.RbMeritorio.Text = "Socios Meritorios"
        Me.RbMeritorio.UseVisualStyleBackColor = False
        '
        'GroupPanelCriterio
        '
        Me.GroupPanelCriterio.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanelCriterio.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanelCriterio.Controls.Add(Me.RbNoMor)
        Me.GroupPanelCriterio.Controls.Add(Me.RbSiMor)
        Me.GroupPanelCriterio.Controls.Add(Me.RbTodos)
        Me.GroupPanelCriterio.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanelCriterio.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupPanelCriterio.Location = New System.Drawing.Point(0, 103)
        Me.GroupPanelCriterio.Name = "GroupPanelCriterio"
        Me.GroupPanelCriterio.Size = New System.Drawing.Size(357, 103)
        '
        '
        '
        Me.GroupPanelCriterio.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GroupPanelCriterio.Style.BackColorGradientAngle = 90
        Me.GroupPanelCriterio.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.GroupPanelCriterio.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanelCriterio.Style.BorderBottomWidth = 1
        Me.GroupPanelCriterio.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanelCriterio.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanelCriterio.Style.BorderLeftWidth = 1
        Me.GroupPanelCriterio.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanelCriterio.Style.BorderRightWidth = 1
        Me.GroupPanelCriterio.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanelCriterio.Style.BorderTopWidth = 1
        Me.GroupPanelCriterio.Style.CornerDiameter = 4
        Me.GroupPanelCriterio.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanelCriterio.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanelCriterio.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanelCriterio.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanelCriterio.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanelCriterio.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanelCriterio.TabIndex = 1
        Me.GroupPanelCriterio.Text = "CRITERIO"
        '
        'RbNoMor
        '
        Me.RbNoMor.AutoSize = True
        Me.RbNoMor.BackColor = System.Drawing.Color.Transparent
        Me.RbNoMor.Location = New System.Drawing.Point(58, 55)
        Me.RbNoMor.Name = "RbNoMor"
        Me.RbNoMor.Size = New System.Drawing.Size(166, 20)
        Me.RbNoMor.TabIndex = 2
        Me.RbNoMor.TabStop = True
        Me.RbNoMor.Text = "Solo los que NO pagan"
        Me.RbNoMor.UseVisualStyleBackColor = False
        '
        'RbSiMor
        '
        Me.RbSiMor.AutoSize = True
        Me.RbSiMor.BackColor = System.Drawing.Color.Transparent
        Me.RbSiMor.Location = New System.Drawing.Point(58, 29)
        Me.RbSiMor.Name = "RbSiMor"
        Me.RbSiMor.Size = New System.Drawing.Size(158, 20)
        Me.RbSiMor.TabIndex = 1
        Me.RbSiMor.TabStop = True
        Me.RbSiMor.Text = "Solo los que SI pagan"
        Me.RbSiMor.UseVisualStyleBackColor = False
        '
        'RbTodos
        '
        Me.RbTodos.AutoSize = True
        Me.RbTodos.BackColor = System.Drawing.Color.Transparent
        Me.RbTodos.Location = New System.Drawing.Point(58, 3)
        Me.RbTodos.Name = "RbTodos"
        Me.RbTodos.Size = New System.Drawing.Size(236, 20)
        Me.RbTodos.TabIndex = 0
        Me.RbTodos.TabStop = True
        Me.RbTodos.Text = "Todos (Socios que SI o NO pagan)"
        Me.RbTodos.UseVisualStyleBackColor = False
        '
        'PR_ListarSocioPaganMortuoria
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(884, 561)
        Me.Location = New System.Drawing.Point(0, 0)
        Me.Name = "PR_ListarSocioPaganMortuoria"
        Me.Text = "PR_ListarSocioPaganMortuoria"
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
        Me.GroupPanelTipoSocio.ResumeLayout(False)
        Me.GroupPanelTipoSocio.PerformLayout()
        Me.GroupPanelCriterio.ResumeLayout(False)
        Me.GroupPanelCriterio.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupPanelTipoSocio As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents RbHonorario As System.Windows.Forms.RadioButton
    Friend WithEvents GroupPanelCriterio As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents RbNoMor As System.Windows.Forms.RadioButton
    Friend WithEvents RbSiMor As System.Windows.Forms.RadioButton
    Friend WithEvents RbTodos As System.Windows.Forms.RadioButton
    Friend WithEvents RbMeritorio As System.Windows.Forms.RadioButton
    Friend WithEvents RbActivo As System.Windows.Forms.RadioButton
End Class
