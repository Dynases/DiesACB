<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Pr_ServiciosLavadero
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
        Dim cbTipoCliente_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Pr_ServiciosLavadero))
        Dim cbModulo_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.CheckTodosModulo = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.checkUnaModulo = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.checkTodosTipoCliente = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.checkUnaTipoCliente = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.cbTipoCliente = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.cbModulo = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
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
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.cbTipoCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbModulo, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.MGPFiltros.Controls.Add(Me.Panel1)
        Me.MGPFiltros.Controls.Add(Me.Panel2)
        Me.MGPFiltros.Controls.Add(Me.LabelX1)
        Me.MGPFiltros.Controls.Add(Me.cbTipoCliente)
        Me.MGPFiltros.Controls.Add(Me.cbModulo)
        Me.MGPFiltros.Controls.Add(Me.LabelX3)
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
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.CheckTodosModulo)
        Me.Panel1.Controls.Add(Me.checkUnaModulo)
        Me.Panel1.Location = New System.Drawing.Point(302, 28)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(160, 43)
        Me.Panel1.TabIndex = 261
        '
        'CheckTodosModulo
        '
        '
        '
        '
        Me.CheckTodosModulo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CheckTodosModulo.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.CheckTodosModulo.Checked = True
        Me.CheckTodosModulo.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckTodosModulo.CheckValue = "Y"
        Me.CheckTodosModulo.Location = New System.Drawing.Point(83, 9)
        Me.CheckTodosModulo.Margin = New System.Windows.Forms.Padding(4)
        Me.CheckTodosModulo.Name = "CheckTodosModulo"
        Me.CheckTodosModulo.Size = New System.Drawing.Size(73, 28)
        Me.CheckTodosModulo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CheckTodosModulo.TabIndex = 252
        Me.CheckTodosModulo.Text = "Todos"
        '
        'checkUnaModulo
        '
        '
        '
        '
        Me.checkUnaModulo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.checkUnaModulo.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.checkUnaModulo.Location = New System.Drawing.Point(16, 9)
        Me.checkUnaModulo.Margin = New System.Windows.Forms.Padding(4)
        Me.checkUnaModulo.Name = "checkUnaModulo"
        Me.checkUnaModulo.Size = New System.Drawing.Size(59, 28)
        Me.checkUnaModulo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.checkUnaModulo.TabIndex = 251
        Me.checkUnaModulo.Text = "Una"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.Controls.Add(Me.checkTodosTipoCliente)
        Me.Panel2.Controls.Add(Me.checkUnaTipoCliente)
        Me.Panel2.Location = New System.Drawing.Point(308, 92)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(159, 43)
        Me.Panel2.TabIndex = 262
        '
        'checkTodosTipoCliente
        '
        '
        '
        '
        Me.checkTodosTipoCliente.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.checkTodosTipoCliente.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.checkTodosTipoCliente.Checked = True
        Me.checkTodosTipoCliente.CheckState = System.Windows.Forms.CheckState.Checked
        Me.checkTodosTipoCliente.CheckValue = "Y"
        Me.checkTodosTipoCliente.Location = New System.Drawing.Point(80, 9)
        Me.checkTodosTipoCliente.Margin = New System.Windows.Forms.Padding(4)
        Me.checkTodosTipoCliente.Name = "checkTodosTipoCliente"
        Me.checkTodosTipoCliente.Size = New System.Drawing.Size(73, 28)
        Me.checkTodosTipoCliente.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.checkTodosTipoCliente.TabIndex = 252
        Me.checkTodosTipoCliente.Text = "Todos"
        '
        'checkUnaTipoCliente
        '
        '
        '
        '
        Me.checkUnaTipoCliente.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.checkUnaTipoCliente.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.checkUnaTipoCliente.Location = New System.Drawing.Point(13, 9)
        Me.checkUnaTipoCliente.Margin = New System.Windows.Forms.Padding(4)
        Me.checkUnaTipoCliente.Name = "checkUnaTipoCliente"
        Me.checkUnaTipoCliente.Size = New System.Drawing.Size(59, 28)
        Me.checkUnaTipoCliente.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.checkUnaTipoCliente.TabIndex = 251
        Me.checkUnaTipoCliente.Text = "Una"
        '
        'LabelX1
        '
        Me.LabelX1.AutoSize = True
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Georgia", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.LabelX1.Location = New System.Drawing.Point(6, 103)
        Me.LabelX1.Margin = New System.Windows.Forms.Padding(4)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.SingleLineColor = System.Drawing.SystemColors.Control
        Me.LabelX1.Size = New System.Drawing.Size(98, 20)
        Me.LabelX1.TabIndex = 260
        Me.LabelX1.Text = "TipoCliente:"
        '
        'cbTipoCliente
        '
        Me.cbTipoCliente.BackColor = System.Drawing.Color.White
        cbTipoCliente_DesignTimeLayout.LayoutString = resources.GetString("cbTipoCliente_DesignTimeLayout.LayoutString")
        Me.cbTipoCliente.DesignTimeLayout = cbTipoCliente_DesignTimeLayout
        Me.cbTipoCliente.DisabledBackColor = System.Drawing.Color.White
        Me.cbTipoCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbTipoCliente.Location = New System.Drawing.Point(121, 101)
        Me.cbTipoCliente.Margin = New System.Windows.Forms.Padding(4)
        Me.cbTipoCliente.Name = "cbTipoCliente"
        Me.cbTipoCliente.Office2007ColorScheme = Janus.Windows.GridEX.Office2007ColorScheme.Custom
        Me.cbTipoCliente.Office2007CustomColor = System.Drawing.Color.DodgerBlue
        Me.cbTipoCliente.SelectedIndex = -1
        Me.cbTipoCliente.SelectedItem = Nothing
        Me.cbTipoCliente.Size = New System.Drawing.Size(180, 26)
        Me.cbTipoCliente.TabIndex = 259
        Me.cbTipoCliente.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cbModulo
        '
        Me.cbModulo.BackColor = System.Drawing.Color.White
        cbModulo_DesignTimeLayout.LayoutString = resources.GetString("cbModulo_DesignTimeLayout.LayoutString")
        Me.cbModulo.DesignTimeLayout = cbModulo_DesignTimeLayout
        Me.cbModulo.DisabledBackColor = System.Drawing.Color.White
        Me.cbModulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbModulo.Location = New System.Drawing.Point(78, 39)
        Me.cbModulo.Margin = New System.Windows.Forms.Padding(4)
        Me.cbModulo.Name = "cbModulo"
        Me.cbModulo.Office2007ColorScheme = Janus.Windows.GridEX.Office2007ColorScheme.Custom
        Me.cbModulo.Office2007CustomColor = System.Drawing.Color.DodgerBlue
        Me.cbModulo.SelectedIndex = -1
        Me.cbModulo.SelectedItem = Nothing
        Me.cbModulo.Size = New System.Drawing.Size(219, 26)
        Me.cbModulo.TabIndex = 258
        Me.cbModulo.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'LabelX3
        '
        Me.LabelX3.AutoSize = True
        Me.LabelX3.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Font = New System.Drawing.Font("Georgia", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.LabelX3.Location = New System.Drawing.Point(1, 42)
        Me.LabelX3.Margin = New System.Windows.Forms.Padding(4)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.SingleLineColor = System.Drawing.SystemColors.Control
        Me.LabelX3.Size = New System.Drawing.Size(68, 20)
        Me.LabelX3.TabIndex = 257
        Me.LabelX3.Text = "Modulo:"
        '
        'Pr_ServiciosLavadero
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1179, 690)
        Me.Location = New System.Drawing.Point(0, 0)
        Me.Name = "Pr_ServiciosLavadero"
        Me.Text = "Pr_ServiciosLavadero"
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
        Me.MGPFiltros.PerformLayout()
        Me.PanelIzq.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        CType(Me.cbTipoCliente, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbModulo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents CheckTodosModulo As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents checkUnaModulo As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Panel2 As Panel
    Friend WithEvents checkTodosTipoCliente As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents checkUnaTipoCliente As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents cbTipoCliente As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents cbModulo As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
End Class
