<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F0_ListaExamenPracticoCerti2
    Inherits Modelos.ModeloF0

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
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.grAlumnos = New DevComponents.DotNetBar.SuperGrid.SuperGridControl()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
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
        Me.GroupPanel1.SuspendLayout()
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
        'SupTabItemBusqueda
        '
        Me.SupTabItemBusqueda.Visible = False
        Me.SuperTabControlPanelRegistro.Controls.SetChildIndex(Me.PanelSuperior, 0)
        Me.SuperTabControlPanelRegistro.Controls.SetChildIndex(Me.PanelInferior, 0)
        Me.SuperTabControlPanelRegistro.Controls.SetChildIndex(Me.PanelPrincipal, 0)
        '
        'PanelSuperior
        '
        Me.PanelSuperior.Size = New System.Drawing.Size(884, 86)
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
        'PanelToolBar1
        '
        Me.PanelToolBar1.Controls.Add(Me.btMarcarTodos)
        Me.PanelToolBar1.Size = New System.Drawing.Size(445, 86)
        Me.PanelToolBar1.Controls.SetChildIndex(Me.btnNuevo, 0)
        Me.PanelToolBar1.Controls.SetChildIndex(Me.btnModificar, 0)
        Me.PanelToolBar1.Controls.SetChildIndex(Me.btnEliminar, 0)
        Me.PanelToolBar1.Controls.SetChildIndex(Me.btMarcarTodos, 0)
        Me.PanelToolBar1.Controls.SetChildIndex(Me.btnGrabar, 0)
        Me.PanelToolBar1.Controls.SetChildIndex(Me.btnSalir, 0)
        '
        'btnSalir
        '
        Me.btnSalir.Location = New System.Drawing.Point(373, 0)
        Me.btnSalir.Size = New System.Drawing.Size(72, 86)
        '
        'btnGrabar
        '
        Me.btnGrabar.Location = New System.Drawing.Point(301, 0)
        Me.btnGrabar.Size = New System.Drawing.Size(72, 86)
        '
        'btnEliminar
        '
        Me.btnEliminar.Size = New System.Drawing.Size(72, 86)
        Me.btnEliminar.Visible = False
        '
        'btnModificar
        '
        Me.btnModificar.Size = New System.Drawing.Size(72, 86)
        Me.btnModificar.Visible = False
        '
        'btnNuevo
        '
        Me.btnNuevo.Image = Global.Presentacion.My.Resources.Resources.GENERAR_REPORTE
        Me.btnNuevo.Size = New System.Drawing.Size(72, 86)
        Me.btnNuevo.Text = "GENERAR"
        '
        'PanelToolBar2
        '
        Me.PanelToolBar2.Size = New System.Drawing.Size(80, 86)
        Me.PanelToolBar2.Visible = False
        '
        'PanelPrincipal
        '
        Me.PanelPrincipal.Controls.Add(Me.GroupPanel1)
        Me.PanelPrincipal.Location = New System.Drawing.Point(0, 86)
        Me.PanelPrincipal.Size = New System.Drawing.Size(884, 414)
        Me.PanelPrincipal.Controls.SetChildIndex(Me.PanelUsuario, 0)
        Me.PanelPrincipal.Controls.SetChildIndex(Me.GroupPanel1, 0)
        '
        'PanelUsuario
        '
        Me.PanelUsuario.Location = New System.Drawing.Point(626, 29)
        '
        'btnImprimir
        '
        Me.btnImprimir.Size = New System.Drawing.Size(72, 86)
        '
        'PanelNavegacion
        '
        Me.PanelNavegacion.Visible = False
        '
        'GroupPanel1
        '
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.grAlumnos)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupPanel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupPanel1.Location = New System.Drawing.Point(0, 0)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(884, 414)
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
        Me.GroupPanel1.TabIndex = 20
        Me.GroupPanel1.Text = " L I S T A    D E    A L U M N O S"
        '
        'grAlumnos
        '
        Me.grAlumnos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grAlumnos.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed
        Me.grAlumnos.Location = New System.Drawing.Point(0, 0)
        Me.grAlumnos.Name = "grAlumnos"
        '
        '
        '
        Me.grAlumnos.PrimaryGrid.UseAlternateRowStyle = True
        Me.grAlumnos.Size = New System.Drawing.Size(878, 391)
        Me.grAlumnos.TabIndex = 0
        Me.grAlumnos.Text = "SuperGridControl1"
        '
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
        '
        'btMarcarTodos
        '
        Me.btMarcarTodos.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btMarcarTodos.ColorTable = DevComponents.DotNetBar.eButtonColor.Orange
        Me.btMarcarTodos.Dock = System.Windows.Forms.DockStyle.Left
        Me.btMarcarTodos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btMarcarTodos.Image = Global.Presentacion.My.Resources.Resources.GRABACION_EXITOSA
        Me.btMarcarTodos.ImageFixedSize = New System.Drawing.Size(48, 48)
        Me.btMarcarTodos.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btMarcarTodos.Location = New System.Drawing.Point(216, 0)
        Me.btMarcarTodos.Name = "btMarcarTodos"
        Me.btMarcarTodos.Size = New System.Drawing.Size(85, 86)
        Me.btMarcarTodos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btMarcarTodos.TabIndex = 11
        Me.btMarcarTodos.Text = "SELECCIONAR TODOS"
        Me.btMarcarTodos.TextColor = System.Drawing.Color.Black
        '
        'F0_ListaExamenTeoricoCerti
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(884, 561)
        Me.Name = "F0_ListaExamenTeoricoCerti"
        Me.Text = "F0_ListaExamenCerti"
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
        Me.GroupPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents grAlumnos As DevComponents.DotNetBar.SuperGrid.SuperGridControl
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    Protected WithEvents btMarcarTodos As DevComponents.DotNetBar.ButtonX
End Class
