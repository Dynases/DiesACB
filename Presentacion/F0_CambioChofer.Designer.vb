<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F0_CambioChofer
    Inherits Modelos.ModeloF0

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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.INSTRUCTORES = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.grInstructorA = New Janus.Windows.GridEX.GridEX()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.grInstructorB = New Janus.Windows.GridEX.GridEX()
        Me.btMarcarTodos = New DevComponents.DotNetBar.ButtonX()
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
        Me.TableLayoutPanel1.SuspendLayout()
        Me.INSTRUCTORES.SuspendLayout()
        CType(Me.grInstructorA, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel1.SuspendLayout()
        CType(Me.grInstructorB, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.SuperTabControlPanelRegistro.Controls.SetChildIndex(Me.PanelSuperior, 0)
        Me.SuperTabControlPanelRegistro.Controls.SetChildIndex(Me.PanelInferior, 0)
        Me.SuperTabControlPanelRegistro.Controls.SetChildIndex(Me.PanelPrincipal, 0)
        '
        'PanelSuperior
        '
        Me.PanelSuperior.Controls.Add(Me.btMarcarTodos)
        Me.PanelSuperior.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelSuperior.Style.BackColor1.Color = System.Drawing.Color.Yellow
        Me.PanelSuperior.Style.BackColor2.Color = System.Drawing.Color.Khaki
        Me.PanelSuperior.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelSuperior.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelSuperior.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelSuperior.Style.GradientAngle = 90
        Me.PanelSuperior.Controls.SetChildIndex(Me.PanelToolBar1, 0)
        Me.PanelSuperior.Controls.SetChildIndex(Me.PanelToolBar2, 0)
        Me.PanelSuperior.Controls.SetChildIndex(Me.MRlAccion, 0)
        Me.PanelSuperior.Controls.SetChildIndex(Me.btMarcarTodos, 0)
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
        'PanelToolBar1
        '
        Me.PanelToolBar1.Visible = False
        '
        'btnSalir
        '
        Me.btnSalir.Visible = False
        '
        'PanelPrincipal
        '
        Me.PanelPrincipal.Controls.Add(Me.Panel1)
        Me.PanelPrincipal.Size = New System.Drawing.Size(1179, 529)
        Me.PanelPrincipal.Controls.SetChildIndex(Me.PanelUsuario, 0)
        Me.PanelPrincipal.Controls.SetChildIndex(Me.Panel1, 0)
        '
        'btnUltimo
        '
        Me.btnUltimo.Location = New System.Drawing.Point(171, 0)
        '
        'MRlAccion
        '
        '
        '
        '
        Me.MRlAccion.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.TableLayoutPanel1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1179, 529)
        Me.Panel1.TabIndex = 20
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.INSTRUCTORES, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.GroupPanel1, 1, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 529.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1179, 529)
        Me.TableLayoutPanel1.TabIndex = 11
        '
        'INSTRUCTORES
        '
        Me.INSTRUCTORES.CanvasColor = System.Drawing.SystemColors.Control
        Me.INSTRUCTORES.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.INSTRUCTORES.Controls.Add(Me.grInstructorA)
        Me.INSTRUCTORES.DisabledBackColor = System.Drawing.Color.Empty
        Me.INSTRUCTORES.Dock = System.Windows.Forms.DockStyle.Fill
        Me.INSTRUCTORES.Font = New System.Drawing.Font("Georgia", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.INSTRUCTORES.Location = New System.Drawing.Point(4, 4)
        Me.INSTRUCTORES.Margin = New System.Windows.Forms.Padding(4)
        Me.INSTRUCTORES.Name = "INSTRUCTORES"
        Me.INSTRUCTORES.Padding = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.INSTRUCTORES.Size = New System.Drawing.Size(581, 521)
        '
        '
        '
        Me.INSTRUCTORES.Style.BackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.INSTRUCTORES.Style.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.INSTRUCTORES.Style.BackColorGradientAngle = 90
        Me.INSTRUCTORES.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.INSTRUCTORES.Style.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.INSTRUCTORES.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.INSTRUCTORES.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.INSTRUCTORES.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.INSTRUCTORES.Style.CornerDiameter = 0
        Me.INSTRUCTORES.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.INSTRUCTORES.Style.Font = New System.Drawing.Font("Georgia", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.INSTRUCTORES.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.INSTRUCTORES.Style.TextColor = System.Drawing.Color.White
        Me.INSTRUCTORES.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.INSTRUCTORES.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.INSTRUCTORES.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.INSTRUCTORES.TabIndex = 9
        Me.INSTRUCTORES.Text = "INSTRUCTOR A"
        '
        'grInstructorA
        '
        Me.grInstructorA.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.grInstructorA.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grInstructorA.FocusCellDisplayMode = Janus.Windows.GridEX.FocusCellDisplayMode.UseSelectedFormatStyle
        Me.grInstructorA.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grInstructorA.HeaderFormatStyle.Font = New System.Drawing.Font("Georgia", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grInstructorA.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight
        Me.grInstructorA.Location = New System.Drawing.Point(7, 6)
        Me.grInstructorA.Margin = New System.Windows.Forms.Padding(4)
        Me.grInstructorA.Name = "grInstructorA"
        Me.grInstructorA.Office2007ColorScheme = Janus.Windows.GridEX.Office2007ColorScheme.Custom
        Me.grInstructorA.Office2007CustomColor = System.Drawing.Color.DodgerBlue
        Me.grInstructorA.RowFormatStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grInstructorA.SelectedFormatStyle.BackColor = System.Drawing.Color.DodgerBlue
        Me.grInstructorA.SelectedFormatStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grInstructorA.SelectedFormatStyle.ForeColor = System.Drawing.Color.White
        Me.grInstructorA.Size = New System.Drawing.Size(567, 489)
        Me.grInstructorA.TabIndex = 0
        Me.grInstructorA.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'GroupPanel1
        '
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.grInstructorB)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupPanel1.Font = New System.Drawing.Font("Georgia", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupPanel1.Location = New System.Drawing.Point(593, 4)
        Me.GroupPanel1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Padding = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.GroupPanel1.Size = New System.Drawing.Size(582, 521)
        '
        '
        '
        Me.GroupPanel1.Style.BackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.GroupPanel1.Style.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.GroupPanel1.Style.BackColorGradientAngle = 90
        Me.GroupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.GroupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.CornerDiameter = 0
        Me.GroupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel1.Style.Font = New System.Drawing.Font("Georgia", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupPanel1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel1.Style.TextColor = System.Drawing.Color.White
        Me.GroupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel1.TabIndex = 10
        Me.GroupPanel1.Text = "INSTRUCTOR B"
        '
        'grInstructorB
        '
        Me.grInstructorB.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.grInstructorB.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grInstructorB.FocusCellDisplayMode = Janus.Windows.GridEX.FocusCellDisplayMode.UseSelectedFormatStyle
        Me.grInstructorB.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grInstructorB.HeaderFormatStyle.Font = New System.Drawing.Font("Georgia", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grInstructorB.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight
        Me.grInstructorB.Location = New System.Drawing.Point(7, 6)
        Me.grInstructorB.Margin = New System.Windows.Forms.Padding(4)
        Me.grInstructorB.Name = "grInstructorB"
        Me.grInstructorB.Office2007ColorScheme = Janus.Windows.GridEX.Office2007ColorScheme.Custom
        Me.grInstructorB.Office2007CustomColor = System.Drawing.Color.DodgerBlue
        Me.grInstructorB.RowFormatStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grInstructorB.SelectedFormatStyle.BackColor = System.Drawing.Color.DodgerBlue
        Me.grInstructorB.SelectedFormatStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grInstructorB.SelectedFormatStyle.ForeColor = System.Drawing.Color.White
        Me.grInstructorB.Size = New System.Drawing.Size(568, 489)
        Me.grInstructorB.TabIndex = 0
        Me.grInstructorB.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'btMarcarTodos
        '
        Me.btMarcarTodos.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btMarcarTodos.ColorTable = DevComponents.DotNetBar.eButtonColor.Orange
        Me.btMarcarTodos.Dock = System.Windows.Forms.DockStyle.Left
        Me.btMarcarTodos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btMarcarTodos.Image = Global.Presentacion.My.Resources.Resources.GENERAR_REPORTE
        Me.btMarcarTodos.ImageFixedSize = New System.Drawing.Size(48, 48)
        Me.btMarcarTodos.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btMarcarTodos.Location = New System.Drawing.Point(501, 0)
        Me.btMarcarTodos.Margin = New System.Windows.Forms.Padding(4)
        Me.btMarcarTodos.Name = "btMarcarTodos"
        Me.btMarcarTodos.Size = New System.Drawing.Size(222, 89)
        Me.btMarcarTodos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btMarcarTodos.TabIndex = 12
        Me.btMarcarTodos.Text = "INTERCAMBIAR"
        Me.btMarcarTodos.TextColor = System.Drawing.Color.Black
        '
        'F0_CambioChofer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1179, 690)
        Me.Name = "F0_CambioChofer"
        Me.Text = "F0_CambioChofer"
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
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.INSTRUCTORES.ResumeLayout(False)
        CType(Me.grInstructorA, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel1.ResumeLayout(False)
        CType(Me.grInstructorB, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents INSTRUCTORES As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents grInstructorA As Janus.Windows.GridEX.GridEX
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents grInstructorB As Janus.Windows.GridEX.GridEX
    Protected WithEvents btMarcarTodos As DevComponents.DotNetBar.ButtonX
End Class
