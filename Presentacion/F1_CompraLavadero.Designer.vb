<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F1_CompraLavadero
    Inherits Modelos.ModeloF1

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F1_CompraLavadero))
        Me.GpTotales = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.tbTotal = New DevComponents.Editors.DoubleInput()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.GpDetalle = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.grDetalle = New Janus.Windows.GridEX.GridEX()
        Me.cmOpciones = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Eliminarms = New System.Windows.Forms.ToolStripMenuItem()
        Me.tbnumiProveedor = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.tbProveedor = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX8 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        Me.tbFechaCompra = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.tbCodigo = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.ButtonX2 = New DevComponents.DotNetBar.ButtonX()
        Me.ButtonX1 = New DevComponents.DotNetBar.ButtonX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.tbObs = New DevComponents.DotNetBar.Controls.TextBoxX()
        CType(Me.SuperTabPrincipal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuperTabPrincipal.SuspendLayout()
        Me.SuperTabControlPanelRegistro.SuspendLayout()
        Me.PanelSuperior.SuspendLayout()
        Me.PanelInferior.SuspendLayout()
        CType(Me.BubbleBarUsuario, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelToolBar1.SuspendLayout()
        Me.PanelToolBar2.SuspendLayout()
        Me.MPanelSup.SuspendLayout()
        Me.PanelPrincipal.SuspendLayout()
        Me.GroupPanelBuscador.SuspendLayout()
        CType(Me.JGrM_Buscador, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelUsuario.SuspendLayout()
        Me.PanelNavegacion.SuspendLayout()
        Me.MPanelUserAct.SuspendLayout()
        CType(Me.MEP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GpTotales.SuspendLayout()
        CType(Me.tbTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GpDetalle.SuspendLayout()
        CType(Me.grDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmOpciones.SuspendLayout()
        CType(Me.tbFechaCompra, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.SuperTabPrincipal.Size = New System.Drawing.Size(1354, 733)
        Me.SuperTabPrincipal.Controls.SetChildIndex(Me.SuperTabControlPanelBuscador, 0)
        Me.SuperTabPrincipal.Controls.SetChildIndex(Me.SuperTabControlPanelRegistro, 0)
        '
        'SuperTabControlPanelBuscador
        '
        Me.SuperTabControlPanelBuscador.Size = New System.Drawing.Size(1354, 708)
        '
        'SuperTabControlPanelRegistro
        '
        Me.SuperTabControlPanelRegistro.Size = New System.Drawing.Size(1354, 708)
        Me.SuperTabControlPanelRegistro.Controls.SetChildIndex(Me.PanelSuperior, 0)
        Me.SuperTabControlPanelRegistro.Controls.SetChildIndex(Me.PanelInferior, 0)
        Me.SuperTabControlPanelRegistro.Controls.SetChildIndex(Me.PanelPrincipal, 0)
        '
        'PanelSuperior
        '
        Me.PanelSuperior.Size = New System.Drawing.Size(1354, 72)
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
        Me.PanelInferior.Controls.Add(Me.ButtonX2)
        Me.PanelInferior.Controls.Add(Me.ButtonX1)
        Me.PanelInferior.Location = New System.Drawing.Point(0, 672)
        Me.PanelInferior.Size = New System.Drawing.Size(1354, 36)
        Me.PanelInferior.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelInferior.Style.BackColor1.Color = System.Drawing.Color.Gold
        Me.PanelInferior.Style.BackColor2.Color = System.Drawing.Color.Gold
        Me.PanelInferior.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelInferior.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelInferior.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelInferior.Style.GradientAngle = 90
        Me.PanelInferior.Controls.SetChildIndex(Me.PanelNavegacion, 0)
        Me.PanelInferior.Controls.SetChildIndex(Me.MPanelUserAct, 0)
        Me.PanelInferior.Controls.SetChildIndex(Me.ButtonX1, 0)
        Me.PanelInferior.Controls.SetChildIndex(Me.ButtonX2, 0)
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
        'btnGrabar
        '
        '
        'btnModificar
        '
        '
        'btnNuevo
        '
        '
        'PanelToolBar2
        '
        Me.PanelToolBar2.Location = New System.Drawing.Point(1274, 0)
        '
        'MPanelSup
        '
        Me.MPanelSup.Controls.Add(Me.LabelX3)
        Me.MPanelSup.Controls.Add(Me.tbObs)
        Me.MPanelSup.Controls.Add(Me.tbProveedor)
        Me.MPanelSup.Controls.Add(Me.tbnumiProveedor)
        Me.MPanelSup.Controls.Add(Me.LabelX8)
        Me.MPanelSup.Controls.Add(Me.tbFechaCompra)
        Me.MPanelSup.Controls.Add(Me.LabelX6)
        Me.MPanelSup.Controls.Add(Me.GpDetalle)
        Me.MPanelSup.Controls.Add(Me.GpTotales)
        Me.MPanelSup.Controls.Add(Me.tbCodigo)
        Me.MPanelSup.Controls.Add(Me.LabelX1)
        Me.MPanelSup.Size = New System.Drawing.Size(1354, 600)
        Me.MPanelSup.Controls.SetChildIndex(Me.LabelX1, 0)
        Me.MPanelSup.Controls.SetChildIndex(Me.tbCodigo, 0)
        Me.MPanelSup.Controls.SetChildIndex(Me.GpTotales, 0)
        Me.MPanelSup.Controls.SetChildIndex(Me.PanelUsuario, 0)
        Me.MPanelSup.Controls.SetChildIndex(Me.GpDetalle, 0)
        Me.MPanelSup.Controls.SetChildIndex(Me.LabelX6, 0)
        Me.MPanelSup.Controls.SetChildIndex(Me.tbFechaCompra, 0)
        Me.MPanelSup.Controls.SetChildIndex(Me.LabelX8, 0)
        Me.MPanelSup.Controls.SetChildIndex(Me.tbnumiProveedor, 0)
        Me.MPanelSup.Controls.SetChildIndex(Me.tbProveedor, 0)
        Me.MPanelSup.Controls.SetChildIndex(Me.tbObs, 0)
        Me.MPanelSup.Controls.SetChildIndex(Me.LabelX3, 0)
        '
        'PanelPrincipal
        '
        Me.PanelPrincipal.Size = New System.Drawing.Size(1354, 600)
        '
        'GroupPanelBuscador
        '
        Me.GroupPanelBuscador.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupPanelBuscador.Location = New System.Drawing.Point(0, 600)
        Me.GroupPanelBuscador.Size = New System.Drawing.Size(1354, 0)
        '
        '
        '
        Me.GroupPanelBuscador.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GroupPanelBuscador.Style.BackColorGradientAngle = 90
        Me.GroupPanelBuscador.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.GroupPanelBuscador.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanelBuscador.Style.BorderBottomWidth = 1
        Me.GroupPanelBuscador.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanelBuscador.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanelBuscador.Style.BorderLeftWidth = 1
        Me.GroupPanelBuscador.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanelBuscador.Style.BorderRightWidth = 1
        Me.GroupPanelBuscador.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanelBuscador.Style.BorderTopWidth = 1
        Me.GroupPanelBuscador.Style.CornerDiameter = 4
        Me.GroupPanelBuscador.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanelBuscador.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanelBuscador.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanelBuscador.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanelBuscador.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanelBuscador.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanelBuscador.Visible = False
        '
        'JGrM_Buscador
        '
        Me.JGrM_Buscador.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.JGrM_Buscador.Office2007ColorScheme = Janus.Windows.GridEX.Office2007ColorScheme.Custom
        Me.JGrM_Buscador.Office2007CustomColor = System.Drawing.Color.DodgerBlue
        Me.JGrM_Buscador.Size = New System.Drawing.Size(1348, 8)
        Me.JGrM_Buscador.Visible = False
        Me.JGrM_Buscador.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'PanelUsuario
        '
        Me.PanelUsuario.Location = New System.Drawing.Point(1128, 23)
        '
        'MPanelUserAct
        '
        Me.MPanelUserAct.Location = New System.Drawing.Point(1154, 0)
        '
        'GpTotales
        '
        Me.GpTotales.CanvasColor = System.Drawing.SystemColors.Control
        Me.GpTotales.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GpTotales.Controls.Add(Me.tbTotal)
        Me.GpTotales.Controls.Add(Me.LabelX4)
        Me.GpTotales.DisabledBackColor = System.Drawing.Color.Empty
        Me.GpTotales.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GpTotales.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GpTotales.Location = New System.Drawing.Point(0, 532)
        Me.GpTotales.Name = "GpTotales"
        Me.GpTotales.Size = New System.Drawing.Size(1354, 68)
        '
        '
        '
        Me.GpTotales.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GpTotales.Style.BackColorGradientAngle = 90
        Me.GpTotales.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.GpTotales.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GpTotales.Style.BorderBottomWidth = 1
        Me.GpTotales.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GpTotales.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GpTotales.Style.BorderLeftWidth = 1
        Me.GpTotales.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GpTotales.Style.BorderRightWidth = 1
        Me.GpTotales.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GpTotales.Style.BorderTopWidth = 1
        Me.GpTotales.Style.CornerDiameter = 4
        Me.GpTotales.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GpTotales.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GpTotales.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GpTotales.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GpTotales.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GpTotales.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GpTotales.TabIndex = 21
        Me.GpTotales.Text = "T o t a l e s"
        '
        'tbTotal
        '
        Me.tbTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        '
        '
        '
        Me.tbTotal.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.tbTotal.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbTotal.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.tbTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbTotal.Increment = 1.0R
        Me.tbTotal.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left
        Me.tbTotal.Location = New System.Drawing.Point(912, 0)
        Me.tbTotal.MinValue = 0.0R
        Me.tbTotal.Name = "tbTotal"
        Me.tbTotal.Size = New System.Drawing.Size(159, 23)
        Me.tbTotal.TabIndex = 3
        '
        'LabelX4
        '
        Me.LabelX4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelX4.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX4.Location = New System.Drawing.Point(726, 0)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(180, 23)
        Me.LabelX4.TabIndex = 13
        Me.LabelX4.Text = "Total:"
        Me.LabelX4.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'GpDetalle
        '
        Me.GpDetalle.CanvasColor = System.Drawing.SystemColors.Control
        Me.GpDetalle.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GpDetalle.Controls.Add(Me.grDetalle)
        Me.GpDetalle.DisabledBackColor = System.Drawing.Color.Empty
        Me.GpDetalle.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GpDetalle.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GpDetalle.Location = New System.Drawing.Point(0, 200)
        Me.GpDetalle.Name = "GpDetalle"
        Me.GpDetalle.Padding = New System.Windows.Forms.Padding(5)
        Me.GpDetalle.Size = New System.Drawing.Size(1354, 332)
        '
        '
        '
        Me.GpDetalle.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GpDetalle.Style.BackColorGradientAngle = 90
        Me.GpDetalle.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.GpDetalle.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GpDetalle.Style.BorderBottomWidth = 1
        Me.GpDetalle.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GpDetalle.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GpDetalle.Style.BorderLeftWidth = 1
        Me.GpDetalle.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GpDetalle.Style.BorderRightWidth = 1
        Me.GpDetalle.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GpDetalle.Style.BorderTopWidth = 1
        Me.GpDetalle.Style.CornerDiameter = 4
        Me.GpDetalle.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GpDetalle.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GpDetalle.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GpDetalle.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GpDetalle.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GpDetalle.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GpDetalle.TabIndex = 6
        Me.GpDetalle.Text = "D E T A L L E"
        '
        'grDetalle
        '
        Me.grDetalle.ContextMenuStrip = Me.cmOpciones
        Me.grDetalle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grDetalle.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grDetalle.Location = New System.Drawing.Point(5, 5)
        Me.grDetalle.Name = "grDetalle"
        Me.grDetalle.Office2007ColorScheme = Janus.Windows.GridEX.Office2007ColorScheme.Custom
        Me.grDetalle.Office2007CustomColor = System.Drawing.Color.DodgerBlue
        Me.grDetalle.Size = New System.Drawing.Size(1338, 297)
        Me.grDetalle.TabIndex = 0
        Me.grDetalle.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
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
        'tbnumiProveedor
        '
        '
        '
        '
        Me.tbnumiProveedor.Border.Class = "TextBoxBorder"
        Me.tbnumiProveedor.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbnumiProveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbnumiProveedor.Location = New System.Drawing.Point(237, 42)
        Me.tbnumiProveedor.Name = "tbnumiProveedor"
        Me.tbnumiProveedor.PreventEnterBeep = True
        Me.tbnumiProveedor.Size = New System.Drawing.Size(51, 23)
        Me.tbnumiProveedor.TabIndex = 14
        Me.tbnumiProveedor.Visible = False
        '
        'tbProveedor
        '
        '
        '
        '
        Me.tbProveedor.Border.Class = "TextBoxBorder"
        Me.tbProveedor.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbProveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbProveedor.Location = New System.Drawing.Point(562, 37)
        Me.tbProveedor.Name = "tbProveedor"
        Me.tbProveedor.PreventEnterBeep = True
        Me.tbProveedor.Size = New System.Drawing.Size(267, 23)
        Me.tbProveedor.TabIndex = 1
        Me.tbProveedor.Visible = False
        '
        'LabelX8
        '
        Me.LabelX8.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX8.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX8.Location = New System.Drawing.Point(30, 84)
        Me.LabelX8.Name = "LabelX8"
        Me.LabelX8.Size = New System.Drawing.Size(106, 23)
        Me.LabelX8.TabIndex = 9
        Me.LabelX8.Text = "*Fecha Compra:"
        Me.LabelX8.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'LabelX6
        '
        Me.LabelX6.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX6.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX6.Location = New System.Drawing.Point(436, 37)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(78, 22)
        Me.LabelX6.TabIndex = 7
        Me.LabelX6.Text = "*Proveedor:"
        Me.LabelX6.TextAlignment = System.Drawing.StringAlignment.Far
        Me.LabelX6.Visible = False
        '
        'tbFechaCompra
        '
        '
        '
        '
        Me.tbFechaCompra.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.tbFechaCompra.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbFechaCompra.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.tbFechaCompra.ButtonDropDown.Visible = True
        Me.tbFechaCompra.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbFechaCompra.IsPopupCalendarOpen = False
        Me.tbFechaCompra.Location = New System.Drawing.Point(156, 84)
        '
        '
        '
        '
        '
        '
        Me.tbFechaCompra.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbFechaCompra.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.tbFechaCompra.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.tbFechaCompra.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.tbFechaCompra.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.tbFechaCompra.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.tbFechaCompra.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.tbFechaCompra.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.tbFechaCompra.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.tbFechaCompra.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbFechaCompra.MonthCalendar.DisplayMonth = New Date(2017, 2, 1, 0, 0, 0, 0)
        Me.tbFechaCompra.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday
        '
        '
        '
        Me.tbFechaCompra.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.tbFechaCompra.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.tbFechaCompra.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.tbFechaCompra.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbFechaCompra.MonthCalendar.TodayButtonVisible = True
        Me.tbFechaCompra.Name = "tbFechaCompra"
        Me.tbFechaCompra.Size = New System.Drawing.Size(120, 23)
        Me.tbFechaCompra.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.tbFechaCompra.TabIndex = 3
        '
        'tbCodigo
        '
        '
        '
        '
        Me.tbCodigo.Border.Class = "TextBoxBorder"
        Me.tbCodigo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbCodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbCodigo.Location = New System.Drawing.Point(156, 42)
        Me.tbCodigo.Name = "tbCodigo"
        Me.tbCodigo.PreventEnterBeep = True
        Me.tbCodigo.Size = New System.Drawing.Size(75, 23)
        Me.tbCodigo.TabIndex = 0
        Me.tbCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX1.Location = New System.Drawing.Point(38, 41)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(48, 23)
        Me.LabelX1.TabIndex = 0
        Me.LabelX1.Text = "Código:"
        Me.LabelX1.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'ButtonX2
        '
        Me.ButtonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.Orange
        Me.ButtonX2.Image = Global.Presentacion.My.Resources.Resources.atras
        Me.ButtonX2.ImageFixedSize = New System.Drawing.Size(30, 30)
        Me.ButtonX2.Location = New System.Drawing.Point(510, 2)
        Me.ButtonX2.Name = "ButtonX2"
        Me.ButtonX2.Size = New System.Drawing.Size(127, 32)
        Me.ButtonX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX2.TabIndex = 27
        Me.ButtonX2.Text = "VOLVER ATRAS .."
        Me.ButtonX2.Visible = False
        '
        'ButtonX1
        '
        Me.ButtonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.Orange
        Me.ButtonX1.Image = Global.Presentacion.My.Resources.Resources.search
        Me.ButtonX1.ImageFixedSize = New System.Drawing.Size(30, 30)
        Me.ButtonX1.Location = New System.Drawing.Point(382, 2)
        Me.ButtonX1.Name = "ButtonX1"
        Me.ButtonX1.Size = New System.Drawing.Size(112, 32)
        Me.ButtonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX1.TabIndex = 26
        Me.ButtonX1.Text = "BUSCAR .."
        '
        'LabelX3
        '
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX3.Location = New System.Drawing.Point(44, 116)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(91, 23)
        Me.LabelX3.TabIndex = 104
        Me.LabelX3.Text = "Observacion:"
        '
        'tbObs
        '
        Me.tbObs.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.tbObs.Border.Class = "TextBoxBorder"
        Me.tbObs.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbObs.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbObs.Location = New System.Drawing.Point(156, 120)
        Me.tbObs.Multiline = True
        Me.tbObs.Name = "tbObs"
        Me.tbObs.PreventEnterBeep = True
        Me.tbObs.Size = New System.Drawing.Size(254, 61)
        Me.tbObs.TabIndex = 4
        '
        'F1_CompraLavadero
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1354, 733)
        Me.Name = "F1_CompraLavadero"
        Me.Text = "F1_ServicioVenta"
        Me.Controls.SetChildIndex(Me.SuperTabPrincipal, 0)
        CType(Me.SuperTabPrincipal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SuperTabPrincipal.ResumeLayout(False)
        Me.SuperTabControlPanelRegistro.ResumeLayout(False)
        Me.PanelSuperior.ResumeLayout(False)
        Me.PanelInferior.ResumeLayout(False)
        CType(Me.BubbleBarUsuario, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelToolBar1.ResumeLayout(False)
        Me.PanelToolBar2.ResumeLayout(False)
        Me.MPanelSup.ResumeLayout(False)
        Me.PanelPrincipal.ResumeLayout(False)
        Me.GroupPanelBuscador.ResumeLayout(False)
        CType(Me.JGrM_Buscador, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelUsuario.ResumeLayout(False)
        Me.PanelUsuario.PerformLayout()
        Me.PanelNavegacion.ResumeLayout(False)
        Me.MPanelUserAct.ResumeLayout(False)
        Me.MPanelUserAct.PerformLayout()
        CType(Me.MEP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GpTotales.ResumeLayout(False)
        CType(Me.tbTotal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GpDetalle.ResumeLayout(False)
        CType(Me.grDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmOpciones.ResumeLayout(False)
        CType(Me.tbFechaCompra, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LabelX8 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Friend WithEvents tbFechaCompra As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents tbCodigo As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents GpDetalle As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents grDetalle As Janus.Windows.GridEX.GridEX
    Friend WithEvents GpTotales As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents tbTotal As DevComponents.Editors.DoubleInput
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents ButtonX2 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ButtonX1 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents tbProveedor As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents tbnumiProveedor As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents cmOpciones As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents Eliminarms As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents tbObs As DevComponents.DotNetBar.Controls.TextBoxX
End Class
