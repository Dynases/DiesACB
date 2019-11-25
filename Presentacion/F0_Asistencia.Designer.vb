<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F0_Asistencia
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F0_Asistencia))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btSalir = New DevComponents.DotNetBar.ButtonX()
        Me.btCargarDatos = New DevComponents.DotNetBar.ButtonX()
        Me.btCargarArchivo = New DevComponents.DotNetBar.ButtonX()
        Me.btConectar = New DevComponents.DotNetBar.ButtonX()
        Me.rlabel = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.grAsistencia = New Janus.Windows.GridEX.GridEX()
        Me.cmOpciones = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Eliminarms = New System.Windows.Forms.ToolStripMenuItem()
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
        Me.GroupPanel1.SuspendLayout()
        CType(Me.grAsistencia, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmOpciones.SuspendLayout()
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
        Me.SuperTabPrincipal.SelectedTabIndex = 1
        Me.SuperTabPrincipal.Size = New System.Drawing.Size(892, 561)
        Me.SuperTabPrincipal.Controls.SetChildIndex(Me.SuperTabControlPanelRegistro, 0)
        Me.SuperTabPrincipal.Controls.SetChildIndex(Me.SuperTabControlPanelBuscador, 0)
        '
        'SuperTabControlPanelBuscador
        '
        Me.SuperTabControlPanelBuscador.Size = New System.Drawing.Size(892, 536)
        '
        'SupTabItemBusqueda
        '
        Me.SupTabItemBusqueda.Visible = False
        '
        'SuperTabControlPanelRegistro
        '
        Me.SuperTabControlPanelRegistro.Size = New System.Drawing.Size(892, 536)
        Me.SuperTabControlPanelRegistro.Controls.SetChildIndex(Me.PanelSuperior, 0)
        Me.SuperTabControlPanelRegistro.Controls.SetChildIndex(Me.PanelInferior, 0)
        Me.SuperTabControlPanelRegistro.Controls.SetChildIndex(Me.PanelPrincipal, 0)
        '
        'PanelSuperior
        '
        Me.PanelSuperior.Controls.Add(Me.rlabel)
        Me.PanelSuperior.Controls.Add(Me.Panel1)
        Me.PanelSuperior.Size = New System.Drawing.Size(892, 73)
        Me.PanelSuperior.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelSuperior.Style.BackColor1.Color = System.Drawing.Color.Yellow
        Me.PanelSuperior.Style.BackColor2.Color = System.Drawing.Color.Khaki
        Me.PanelSuperior.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelSuperior.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelSuperior.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelSuperior.Style.GradientAngle = 90
        Me.PanelSuperior.Controls.SetChildIndex(Me.MRlAccion, 0)
        Me.PanelSuperior.Controls.SetChildIndex(Me.Panel1, 0)
        Me.PanelSuperior.Controls.SetChildIndex(Me.rlabel, 0)
        Me.PanelSuperior.Controls.SetChildIndex(Me.PanelToolBar1, 0)
        Me.PanelSuperior.Controls.SetChildIndex(Me.PanelToolBar2, 0)
        '
        'PanelInferior
        '
        Me.PanelInferior.Size = New System.Drawing.Size(892, 36)
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
        Me.PanelToolBar1.Location = New System.Drawing.Point(793, 0)
        Me.PanelToolBar1.Size = New System.Drawing.Size(10, 73)
        Me.PanelToolBar1.Visible = False
        '
        'btnSalir
        '
        Me.btnSalir.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnSalir.Location = New System.Drawing.Point(-62, 0)
        Me.btnSalir.Size = New System.Drawing.Size(72, 73)
        '
        'btnGrabar
        '
        Me.btnGrabar.Size = New System.Drawing.Size(72, 73)
        '
        'btnEliminar
        '
        Me.btnEliminar.Size = New System.Drawing.Size(72, 73)
        '
        'btnModificar
        '
        Me.btnModificar.Size = New System.Drawing.Size(72, 73)
        '
        'btnNuevo
        '
        Me.btnNuevo.Size = New System.Drawing.Size(72, 73)
        '
        'PanelToolBar2
        '
        Me.PanelToolBar2.Location = New System.Drawing.Point(812, 0)
        Me.PanelToolBar2.Size = New System.Drawing.Size(80, 73)
        '
        'PanelPrincipal
        '
        Me.PanelPrincipal.Controls.Add(Me.GroupPanel1)
        Me.PanelPrincipal.Location = New System.Drawing.Point(0, 73)
        Me.PanelPrincipal.Size = New System.Drawing.Size(892, 427)
        Me.PanelPrincipal.Controls.SetChildIndex(Me.PanelUsuario, 0)
        Me.PanelPrincipal.Controls.SetChildIndex(Me.GroupPanel1, 0)
        '
        'btnImprimir
        '
        Me.btnImprimir.Location = New System.Drawing.Point(0, 0)
        Me.btnImprimir.Size = New System.Drawing.Size(80, 73)
        '
        'MPanelUserAct
        '
        Me.MPanelUserAct.Location = New System.Drawing.Point(692, 0)
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
        Me.Panel1.Controls.Add(Me.btSalir)
        Me.Panel1.Controls.Add(Me.btCargarDatos)
        Me.Panel1.Controls.Add(Me.btCargarArchivo)
        Me.Panel1.Controls.Add(Me.btConectar)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(427, 73)
        Me.Panel1.TabIndex = 7
        '
        'btSalir
        '
        Me.btSalir.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btSalir.ColorTable = DevComponents.DotNetBar.eButtonColor.Orange
        Me.btSalir.Dock = System.Windows.Forms.DockStyle.Left
        Me.btSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btSalir.Image = Global.Presentacion.My.Resources.Resources.atras
        Me.btSalir.ImageFixedSize = New System.Drawing.Size(48, 48)
        Me.btSalir.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btSalir.Location = New System.Drawing.Point(354, 0)
        Me.btSalir.Name = "btSalir"
        Me.btSalir.Size = New System.Drawing.Size(72, 73)
        Me.btSalir.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btSalir.TabIndex = 10
        Me.btSalir.Text = "SALIR"
        Me.btSalir.TextColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(66, Byte), Integer))
        '
        'btCargarDatos
        '
        Me.btCargarDatos.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btCargarDatos.ColorTable = DevComponents.DotNetBar.eButtonColor.Orange
        Me.btCargarDatos.Dock = System.Windows.Forms.DockStyle.Left
        Me.btCargarDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btCargarDatos.Image = Global.Presentacion.My.Resources.Resources.save
        Me.btCargarDatos.ImageFixedSize = New System.Drawing.Size(48, 48)
        Me.btCargarDatos.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btCargarDatos.Location = New System.Drawing.Point(247, 0)
        Me.btCargarDatos.Name = "btCargarDatos"
        Me.btCargarDatos.Size = New System.Drawing.Size(107, 73)
        Me.btCargarDatos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btCargarDatos.TabIndex = 7
        Me.btCargarDatos.Text = "GUARDAR DATOS"
        Me.btCargarDatos.TextColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(66, Byte), Integer))
        '
        'btCargarArchivo
        '
        Me.btCargarArchivo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btCargarArchivo.BackColor = System.Drawing.Color.Transparent
        Me.btCargarArchivo.ColorTable = DevComponents.DotNetBar.eButtonColor.Magenta
        Me.btCargarArchivo.Dock = System.Windows.Forms.DockStyle.Left
        Me.btCargarArchivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btCargarArchivo.Image = Global.Presentacion.My.Resources.Resources.folder
        Me.btCargarArchivo.ImageFixedSize = New System.Drawing.Size(48, 48)
        Me.btCargarArchivo.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btCargarArchivo.Location = New System.Drawing.Point(128, 0)
        Me.btCargarArchivo.Name = "btCargarArchivo"
        Me.btCargarArchivo.Size = New System.Drawing.Size(119, 73)
        Me.btCargarArchivo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btCargarArchivo.TabIndex = 6
        Me.btCargarArchivo.Text = "CARGAR ARCHIVOS"
        Me.btCargarArchivo.TextColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(66, Byte), Integer))
        '
        'btConectar
        '
        Me.btConectar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btConectar.ColorTable = DevComponents.DotNetBar.eButtonColor.Orange
        Me.btConectar.Dock = System.Windows.Forms.DockStyle.Left
        Me.btConectar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btConectar.Image = Global.Presentacion.My.Resources.Resources.switch_2
        Me.btConectar.ImageFixedSize = New System.Drawing.Size(48, 48)
        Me.btConectar.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btConectar.Location = New System.Drawing.Point(0, 0)
        Me.btConectar.Name = "btConectar"
        Me.btConectar.Size = New System.Drawing.Size(128, 73)
        Me.btConectar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btConectar.TabIndex = 11
        Me.btConectar.Text = "CONECTAR"
        Me.btConectar.TextColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(66, Byte), Integer))
        '
        'rlabel
        '
        '
        '
        '
        Me.rlabel.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.rlabel.Dock = System.Windows.Forms.DockStyle.Left
        Me.rlabel.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rlabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.rlabel.Location = New System.Drawing.Point(427, 0)
        Me.rlabel.Name = "rlabel"
        Me.rlabel.Size = New System.Drawing.Size(366, 73)
        Me.rlabel.TabIndex = 8
        Me.rlabel.Text = "DESCONECTADO"
        '
        'GroupPanel1
        '
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.grAsistencia)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupPanel1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupPanel1.Location = New System.Drawing.Point(0, 0)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Padding = New System.Windows.Forms.Padding(3)
        Me.GroupPanel1.Size = New System.Drawing.Size(892, 427)
        '
        '
        '
        Me.GroupPanel1.Style.BackColor = System.Drawing.Color.DodgerBlue
        Me.GroupPanel1.Style.BackColor2 = System.Drawing.Color.DodgerBlue
        Me.GroupPanel1.Style.BackColorGradientAngle = 90
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
        Me.GroupPanel1.TabIndex = 20
        Me.GroupPanel1.Text = "DATOS RECUPERADOS"
        '
        'grAsistencia
        '
        Me.grAsistencia.ContextMenuStrip = Me.cmOpciones
        Me.grAsistencia.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grAsistencia.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grAsistencia.Location = New System.Drawing.Point(3, 3)
        Me.grAsistencia.Name = "grAsistencia"
        Me.grAsistencia.Office2007ColorScheme = Janus.Windows.GridEX.Office2007ColorScheme.Custom
        Me.grAsistencia.Office2007CustomColor = System.Drawing.Color.DodgerBlue
        Me.grAsistencia.Size = New System.Drawing.Size(880, 398)
        Me.grAsistencia.TabIndex = 0
        Me.grAsistencia.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmOpciones
        '
        Me.cmOpciones.Font = New System.Drawing.Font("Bookman Old Style", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmOpciones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Eliminarms})
        Me.cmOpciones.Name = "cmOpciones"
        Me.cmOpciones.Size = New System.Drawing.Size(204, 46)
        '
        'Eliminarms
        '
        Me.Eliminarms.Font = New System.Drawing.Font("Bookman Old Style", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Eliminarms.Image = CType(resources.GetObject("Eliminarms.Image"), System.Drawing.Image)
        Me.Eliminarms.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.Eliminarms.ImageTransparentColor = System.Drawing.Color.Wheat
        Me.Eliminarms.Name = "Eliminarms"
        Me.Eliminarms.Size = New System.Drawing.Size(203, 42)
        Me.Eliminarms.Text = "ELIMINAR FILA"
        '
        'F0_Asistencia
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(892, 561)
        Me.Name = "F0_Asistencia"
        Me.Text = "F0_Asistencia"
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
        Me.GroupPanel1.ResumeLayout(False)
        CType(Me.grAsistencia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmOpciones.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Protected WithEvents Panel1 As System.Windows.Forms.Panel
    Protected WithEvents btSalir As DevComponents.DotNetBar.ButtonX
    Protected WithEvents btCargarDatos As DevComponents.DotNetBar.ButtonX
    Protected WithEvents btCargarArchivo As DevComponents.DotNetBar.ButtonX
    Protected WithEvents btConectar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents rlabel As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents grAsistencia As Janus.Windows.GridEX.GridEX
    Friend WithEvents cmOpciones As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents Eliminarms As System.Windows.Forms.ToolStripMenuItem
End Class
