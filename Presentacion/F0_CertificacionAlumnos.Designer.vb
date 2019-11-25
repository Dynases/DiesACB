<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class F0_CertificacionAlumnos
    Inherits Modelos.ModeloF0

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.gpListaAlumnos = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.grAlumnos = New Janus.Windows.GridEX.GridEX()
        Me.btMarcarTodos = New DevComponents.DotNetBar.ButtonX()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
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
        Me.gpListaAlumnos.SuspendLayout()
        CType(Me.grAlumnos, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'SupTabItemBusqueda
        '
        Me.SupTabItemBusqueda.Visible = False
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
        Me.PanelSuperior.Margin = New System.Windows.Forms.Padding(5)
        Me.PanelSuperior.Size = New System.Drawing.Size(1179, 106)
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
        'PanelToolBar1
        '
        Me.PanelToolBar1.Controls.Add(Me.btMarcarTodos)
        Me.PanelToolBar1.Margin = New System.Windows.Forms.Padding(5)
        Me.PanelToolBar1.Size = New System.Drawing.Size(613, 106)
        Me.PanelToolBar1.Controls.SetChildIndex(Me.btnNuevo, 0)
        Me.PanelToolBar1.Controls.SetChildIndex(Me.btnModificar, 0)
        Me.PanelToolBar1.Controls.SetChildIndex(Me.btnEliminar, 0)
        Me.PanelToolBar1.Controls.SetChildIndex(Me.btMarcarTodos, 0)
        Me.PanelToolBar1.Controls.SetChildIndex(Me.btnGrabar, 0)
        Me.PanelToolBar1.Controls.SetChildIndex(Me.btnSalir, 0)
        '
        'btnSalir
        '
        Me.btnSalir.Location = New System.Drawing.Point(515, 0)
        Me.btnSalir.Margin = New System.Windows.Forms.Padding(5)
        Me.btnSalir.Size = New System.Drawing.Size(96, 106)
        '
        'btnGrabar
        '
        Me.btnGrabar.Location = New System.Drawing.Point(419, 0)
        Me.btnGrabar.Margin = New System.Windows.Forms.Padding(5)
        Me.btnGrabar.Size = New System.Drawing.Size(96, 106)
        '
        'btnEliminar
        '
        Me.btnEliminar.Location = New System.Drawing.Point(210, 0)
        Me.btnEliminar.Margin = New System.Windows.Forms.Padding(5)
        Me.btnEliminar.Size = New System.Drawing.Size(96, 106)
        Me.btnEliminar.Visible = False
        '
        'btnModificar
        '
        Me.btnModificar.Location = New System.Drawing.Point(114, 0)
        Me.btnModificar.Margin = New System.Windows.Forms.Padding(5)
        Me.btnModificar.Size = New System.Drawing.Size(96, 106)
        Me.btnModificar.Visible = False
        '
        'btnNuevo
        '
        Me.btnNuevo.Image = Global.Presentacion.My.Resources.Resources.reforzamiento
        Me.btnNuevo.Margin = New System.Windows.Forms.Padding(5)
        Me.btnNuevo.Size = New System.Drawing.Size(114, 106)
        Me.btnNuevo.Text = "ACTUALIZAR"
        '
        'PanelToolBar2
        '
        Me.PanelToolBar2.Margin = New System.Windows.Forms.Padding(5)
        Me.PanelToolBar2.Size = New System.Drawing.Size(107, 106)
        '
        'PanelPrincipal
        '
        Me.PanelPrincipal.Controls.Add(Me.gpListaAlumnos)
        Me.PanelPrincipal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PanelPrincipal.Location = New System.Drawing.Point(0, 106)
        Me.PanelPrincipal.Margin = New System.Windows.Forms.Padding(5)
        Me.PanelPrincipal.Size = New System.Drawing.Size(1179, 512)
        Me.PanelPrincipal.Controls.SetChildIndex(Me.PanelUsuario, 0)
        Me.PanelPrincipal.Controls.SetChildIndex(Me.gpListaAlumnos, 0)
        '
        'btnImprimir
        '
        Me.btnImprimir.Margin = New System.Windows.Forms.Padding(5)
        Me.btnImprimir.Size = New System.Drawing.Size(96, 106)
        '
        'PanelNavegacion
        '
        Me.PanelNavegacion.Visible = False
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
        Me.MRlAccion.Location = New System.Drawing.Point(806, 5)
        Me.MRlAccion.Margin = New System.Windows.Forms.Padding(5)
        '
        'gpListaAlumnos
        '
        Me.gpListaAlumnos.CanvasColor = System.Drawing.SystemColors.Control
        Me.gpListaAlumnos.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.gpListaAlumnos.Controls.Add(Me.grAlumnos)
        Me.gpListaAlumnos.DisabledBackColor = System.Drawing.Color.Empty
        Me.gpListaAlumnos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gpListaAlumnos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpListaAlumnos.Location = New System.Drawing.Point(0, 0)
        Me.gpListaAlumnos.Margin = New System.Windows.Forms.Padding(4)
        Me.gpListaAlumnos.Name = "gpListaAlumnos"
        Me.gpListaAlumnos.Size = New System.Drawing.Size(1179, 512)
        '
        '
        '
        Me.gpListaAlumnos.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.gpListaAlumnos.Style.BackColorGradientAngle = 90
        Me.gpListaAlumnos.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.gpListaAlumnos.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpListaAlumnos.Style.BorderBottomWidth = 1
        Me.gpListaAlumnos.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.gpListaAlumnos.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpListaAlumnos.Style.BorderLeftWidth = 1
        Me.gpListaAlumnos.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpListaAlumnos.Style.BorderRightWidth = 1
        Me.gpListaAlumnos.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpListaAlumnos.Style.BorderTopWidth = 1
        Me.gpListaAlumnos.Style.CornerDiameter = 4
        Me.gpListaAlumnos.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.gpListaAlumnos.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.gpListaAlumnos.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.gpListaAlumnos.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.gpListaAlumnos.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.gpListaAlumnos.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.gpListaAlumnos.TabIndex = 22
        Me.gpListaAlumnos.Text = "L I S T A     D E    A L U M N O S    P A R A     C E R T I F I C A C I O N"
        '
        'grAlumnos
        '
        Me.grAlumnos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grAlumnos.Location = New System.Drawing.Point(0, 0)
        Me.grAlumnos.Margin = New System.Windows.Forms.Padding(4)
        Me.grAlumnos.Name = "grAlumnos"
        Me.grAlumnos.Size = New System.Drawing.Size(1173, 485)
        Me.grAlumnos.TabIndex = 0
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
        Me.btMarcarTodos.Location = New System.Drawing.Point(306, 0)
        Me.btMarcarTodos.Margin = New System.Windows.Forms.Padding(4)
        Me.btMarcarTodos.Name = "btMarcarTodos"
        Me.btMarcarTodos.Size = New System.Drawing.Size(113, 106)
        Me.btMarcarTodos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btMarcarTodos.TabIndex = 12
        Me.btMarcarTodos.Text = "SELECCIONAR TODOS"
        Me.btMarcarTodos.TextColor = System.Drawing.Color.Black
        '
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
        '
        'F0_CertificacionAlumnos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1179, 690)
        Me.Margin = New System.Windows.Forms.Padding(5)
        Me.Name = "F0_CertificacionAlumnos"
        Me.Text = "F0_ListaCertificados"
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
        Me.gpListaAlumnos.ResumeLayout(False)
        CType(Me.grAlumnos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gpListaAlumnos As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents grAlumnos As Janus.Windows.GridEX.GridEX
    Protected WithEvents btMarcarTodos As DevComponents.DotNetBar.ButtonX
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
End Class
