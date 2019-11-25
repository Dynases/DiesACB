<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F1_VentaRemolque
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F1_VentaRemolque))
        Me.GpTotales = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.tbTotal = New DevComponents.Editors.DoubleInput()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.GpDetalle = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.grDetalle = New Janus.Windows.GridEX.GridEX()
        Me.cmOpciones = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Eliminarms = New System.Windows.Forms.ToolStripMenuItem()
        Me.tbnumiCliente = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.tbCliente = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Estado = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.LabelX8 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        Me.FechaVenta = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.tbCodigo = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.GpVentasSinCobrar = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.SuperTabControl1 = New DevComponents.DotNetBar.SuperTabControl()
        Me.SuperTabControlPanel1 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.grVentasPendientes = New Janus.Windows.GridEX.GridEX()
        Me.SuperTabItem1 = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabControlPanel2 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.ButtonX4 = New DevComponents.DotNetBar.ButtonX()
        Me.ButtonX3 = New DevComponents.DotNetBar.ButtonX()
        Me.Gmc_Cliente = New GMap.NET.WindowsForms.GMapControl()
        Me.SuperTabItem2 = New DevComponents.DotNetBar.SuperTabItem()
        Me.ButtonX2 = New DevComponents.DotNetBar.ButtonX()
        Me.ButtonX1 = New DevComponents.DotNetBar.ButtonX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.tbnumiVehiculo = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.tbVehiculo = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.btnAnadir = New DevComponents.DotNetBar.ButtonX()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.lbFechaPago = New DevComponents.DotNetBar.LabelX()
        Me.tbFechaPago = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.tbClienteSocio = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.tbobs = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.lbUltimaPago = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.UsImg = New Presentacion.Us_Image()
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
        CType(Me.FechaVenta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GpVentasSinCobrar.SuspendLayout()
        CType(Me.SuperTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuperTabControl1.SuspendLayout()
        Me.SuperTabControlPanel1.SuspendLayout()
        CType(Me.grVentasPendientes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuperTabControlPanel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
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
        Me.SuperTabControlPanelBuscador.Size = New System.Drawing.Size(1302, 536)
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
        Me.MPanelSup.Controls.Add(Me.GpVentasSinCobrar)
        Me.MPanelSup.Controls.Add(Me.Panel1)
        Me.MPanelSup.Controls.Add(Me.GpDetalle)
        Me.MPanelSup.Controls.Add(Me.GpTotales)
        Me.MPanelSup.Size = New System.Drawing.Size(1354, 600)
        Me.MPanelSup.Controls.SetChildIndex(Me.GpTotales, 0)
        Me.MPanelSup.Controls.SetChildIndex(Me.PanelUsuario, 0)
        Me.MPanelSup.Controls.SetChildIndex(Me.GpDetalle, 0)
        Me.MPanelSup.Controls.SetChildIndex(Me.Panel1, 0)
        Me.MPanelSup.Controls.SetChildIndex(Me.GpVentasSinCobrar, 0)
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
        'btnImprimir
        '
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
        Me.GpTotales.Location = New System.Drawing.Point(0, 531)
        Me.GpTotales.Name = "GpTotales"
        Me.GpTotales.Size = New System.Drawing.Size(1354, 69)
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
        Me.tbTotal.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center
        Me.tbTotal.Location = New System.Drawing.Point(1157, 3)
        Me.tbTotal.MinValue = 0R
        Me.tbTotal.Name = "tbTotal"
        Me.tbTotal.Size = New System.Drawing.Size(159, 23)
        Me.tbTotal.TabIndex = 3
        Me.tbTotal.WatermarkAlignment = DevComponents.Editors.eTextAlignment.Right
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
        Me.LabelX4.Location = New System.Drawing.Point(971, 3)
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
        Me.GpDetalle.Location = New System.Drawing.Point(0, 293)
        Me.GpDetalle.Name = "GpDetalle"
        Me.GpDetalle.Padding = New System.Windows.Forms.Padding(5)
        Me.GpDetalle.Size = New System.Drawing.Size(1354, 238)
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
        Me.GpDetalle.TabIndex = 7
        Me.GpDetalle.Text = "D E T A L L E"
        '
        'grDetalle
        '
        Me.grDetalle.ContextMenuStrip = Me.cmOpciones
        Me.grDetalle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grDetalle.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grDetalle.Location = New System.Drawing.Point(5, 5)
        Me.grDetalle.Name = "grDetalle"
        Me.grDetalle.Office2007ColorScheme = Janus.Windows.GridEX.Office2007ColorScheme.Custom
        Me.grDetalle.Office2007CustomColor = System.Drawing.Color.DodgerBlue
        Me.grDetalle.Size = New System.Drawing.Size(1338, 203)
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
        'tbnumiCliente
        '
        '
        '
        '
        Me.tbnumiCliente.Border.Class = "TextBoxBorder"
        Me.tbnumiCliente.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbnumiCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbnumiCliente.Location = New System.Drawing.Point(234, 19)
        Me.tbnumiCliente.Name = "tbnumiCliente"
        Me.tbnumiCliente.PreventEnterBeep = True
        Me.tbnumiCliente.Size = New System.Drawing.Size(51, 23)
        Me.tbnumiCliente.TabIndex = 14
        Me.tbnumiCliente.Visible = False
        '
        'tbCliente
        '
        '
        '
        '
        Me.tbCliente.Border.Class = "TextBoxBorder"
        Me.tbCliente.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbCliente.Location = New System.Drawing.Point(156, 58)
        Me.tbCliente.Name = "tbCliente"
        Me.tbCliente.PreventEnterBeep = True
        Me.tbCliente.Size = New System.Drawing.Size(267, 23)
        Me.tbCliente.TabIndex = 2
        '
        'Estado
        '
        '
        '
        '
        Me.Estado.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Estado.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Estado.Location = New System.Drawing.Point(433, 237)
        Me.Estado.Name = "Estado"
        Me.Estado.OffText = "SIN COBRAR"
        Me.Estado.OnBackColor = System.Drawing.Color.Lime
        Me.Estado.OnText = "COBRADO"
        Me.Estado.Size = New System.Drawing.Size(257, 25)
        Me.Estado.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Estado.TabIndex = 6
        Me.Estado.Value = True
        Me.Estado.ValueObject = "Y"
        '
        'LabelX8
        '
        Me.LabelX8.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX8.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX8.Location = New System.Drawing.Point(40, 189)
        Me.LabelX8.Name = "LabelX8"
        Me.LabelX8.Size = New System.Drawing.Size(103, 23)
        Me.LabelX8.TabIndex = 9
        Me.LabelX8.Text = "Fecha de Venta:"
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
        Me.LabelX6.Location = New System.Drawing.Point(43, 57)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(48, 23)
        Me.LabelX6.TabIndex = 7
        Me.LabelX6.Text = "Cliente:"
        Me.LabelX6.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'FechaVenta
        '
        '
        '
        '
        Me.FechaVenta.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.FechaVenta.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.FechaVenta.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.FechaVenta.ButtonDropDown.Visible = True
        Me.FechaVenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FechaVenta.IsPopupCalendarOpen = False
        Me.FechaVenta.Location = New System.Drawing.Point(156, 190)
        '
        '
        '
        '
        '
        '
        Me.FechaVenta.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.FechaVenta.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.FechaVenta.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.FechaVenta.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.FechaVenta.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.FechaVenta.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.FechaVenta.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.FechaVenta.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.FechaVenta.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.FechaVenta.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.FechaVenta.MonthCalendar.DisplayMonth = New Date(2017, 2, 1, 0, 0, 0, 0)
        Me.FechaVenta.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday
        '
        '
        '
        Me.FechaVenta.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.FechaVenta.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.FechaVenta.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.FechaVenta.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.FechaVenta.MonthCalendar.TodayButtonVisible = True
        Me.FechaVenta.Name = "FechaVenta"
        Me.FechaVenta.Size = New System.Drawing.Size(120, 23)
        Me.FechaVenta.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.FechaVenta.TabIndex = 5
        '
        'tbCodigo
        '
        '
        '
        '
        Me.tbCodigo.Border.Class = "TextBoxBorder"
        Me.tbCodigo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbCodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbCodigo.Location = New System.Drawing.Point(156, 19)
        Me.tbCodigo.Name = "tbCodigo"
        Me.tbCodigo.PreventEnterBeep = True
        Me.tbCodigo.Size = New System.Drawing.Size(50, 23)
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
        Me.LabelX1.Location = New System.Drawing.Point(43, 18)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(48, 23)
        Me.LabelX1.TabIndex = 0
        Me.LabelX1.Text = "Código:"
        Me.LabelX1.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'GpVentasSinCobrar
        '
        Me.GpVentasSinCobrar.CanvasColor = System.Drawing.SystemColors.Control
        Me.GpVentasSinCobrar.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GpVentasSinCobrar.Controls.Add(Me.SuperTabControl1)
        Me.GpVentasSinCobrar.DisabledBackColor = System.Drawing.Color.Empty
        Me.GpVentasSinCobrar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GpVentasSinCobrar.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GpVentasSinCobrar.Location = New System.Drawing.Point(711, 0)
        Me.GpVentasSinCobrar.Name = "GpVentasSinCobrar"
        Me.GpVentasSinCobrar.Padding = New System.Windows.Forms.Padding(3)
        Me.GpVentasSinCobrar.Size = New System.Drawing.Size(643, 293)
        '
        '
        '
        Me.GpVentasSinCobrar.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GpVentasSinCobrar.Style.BackColorGradientAngle = 90
        Me.GpVentasSinCobrar.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.GpVentasSinCobrar.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GpVentasSinCobrar.Style.BorderBottomWidth = 1
        Me.GpVentasSinCobrar.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GpVentasSinCobrar.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GpVentasSinCobrar.Style.BorderLeftWidth = 1
        Me.GpVentasSinCobrar.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GpVentasSinCobrar.Style.BorderRightWidth = 1
        Me.GpVentasSinCobrar.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GpVentasSinCobrar.Style.BorderTopWidth = 1
        Me.GpVentasSinCobrar.Style.CornerDiameter = 4
        Me.GpVentasSinCobrar.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GpVentasSinCobrar.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GpVentasSinCobrar.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GpVentasSinCobrar.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GpVentasSinCobrar.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GpVentasSinCobrar.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GpVentasSinCobrar.TabIndex = 24
        Me.GpVentasSinCobrar.Text = "I N F O R M A C I O N"
        '
        'SuperTabControl1
        '
        '
        '
        '
        '
        '
        '
        Me.SuperTabControl1.ControlBox.CloseBox.Name = ""
        '
        '
        '
        Me.SuperTabControl1.ControlBox.MenuBox.Name = ""
        Me.SuperTabControl1.ControlBox.Name = ""
        Me.SuperTabControl1.ControlBox.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.SuperTabControl1.ControlBox.MenuBox, Me.SuperTabControl1.ControlBox.CloseBox})
        Me.SuperTabControl1.Controls.Add(Me.SuperTabControlPanel1)
        Me.SuperTabControl1.Controls.Add(Me.SuperTabControlPanel2)
        Me.SuperTabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControl1.Location = New System.Drawing.Point(3, 3)
        Me.SuperTabControl1.Name = "SuperTabControl1"
        Me.SuperTabControl1.ReorderTabsEnabled = True
        Me.SuperTabControl1.SelectedTabFont = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.SuperTabControl1.SelectedTabIndex = 0
        Me.SuperTabControl1.Size = New System.Drawing.Size(631, 262)
        Me.SuperTabControl1.TabFont = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SuperTabControl1.TabIndex = 1
        Me.SuperTabControl1.Tabs.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.SuperTabItem1, Me.SuperTabItem2})
        Me.SuperTabControl1.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.Office2010BackstageBlue
        Me.SuperTabControl1.Text = "Descuento"
        '
        'SuperTabControlPanel1
        '
        Me.SuperTabControlPanel1.Controls.Add(Me.grVentasPendientes)
        Me.SuperTabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel1.Location = New System.Drawing.Point(0, 27)
        Me.SuperTabControlPanel1.Name = "SuperTabControlPanel1"
        Me.SuperTabControlPanel1.Size = New System.Drawing.Size(631, 235)
        Me.SuperTabControlPanel1.TabIndex = 1
        Me.SuperTabControlPanel1.TabItem = Me.SuperTabItem1
        '
        'grVentasPendientes
        '
        Me.grVentasPendientes.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.grVentasPendientes.BackColor = System.Drawing.Color.White
        Me.grVentasPendientes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grVentasPendientes.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grVentasPendientes.Location = New System.Drawing.Point(0, 0)
        Me.grVentasPendientes.Name = "grVentasPendientes"
        Me.grVentasPendientes.Office2007ColorScheme = Janus.Windows.GridEX.Office2007ColorScheme.Custom
        Me.grVentasPendientes.Office2007CustomColor = System.Drawing.Color.DodgerBlue
        Me.grVentasPendientes.Size = New System.Drawing.Size(631, 235)
        Me.grVentasPendientes.TabIndex = 0
        Me.grVentasPendientes.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'SuperTabItem1
        '
        Me.SuperTabItem1.AttachedControl = Me.SuperTabControlPanel1
        Me.SuperTabItem1.GlobalItem = False
        Me.SuperTabItem1.Name = "SuperTabItem1"
        Me.SuperTabItem1.Text = "Ventas Sin Cobrar"
        '
        'SuperTabControlPanel2
        '
        Me.SuperTabControlPanel2.Controls.Add(Me.ButtonX4)
        Me.SuperTabControlPanel2.Controls.Add(Me.ButtonX3)
        Me.SuperTabControlPanel2.Controls.Add(Me.Gmc_Cliente)
        Me.SuperTabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel2.Location = New System.Drawing.Point(0, 27)
        Me.SuperTabControlPanel2.Name = "SuperTabControlPanel2"
        Me.SuperTabControlPanel2.Size = New System.Drawing.Size(631, 235)
        Me.SuperTabControlPanel2.TabIndex = 0
        Me.SuperTabControlPanel2.TabItem = Me.SuperTabItem2
        '
        'ButtonX4
        '
        Me.ButtonX4.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX4.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX4.Image = Global.Presentacion.My.Resources.Resources.iconalejar
        Me.ButtonX4.Location = New System.Drawing.Point(60, 179)
        Me.ButtonX4.Name = "ButtonX4"
        Me.ButtonX4.Size = New System.Drawing.Size(39, 39)
        Me.ButtonX4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX4.TabIndex = 3
        '
        'ButtonX3
        '
        Me.ButtonX3.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX3.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.MHighlighterFocus.SetHighlightOnFocus(Me.ButtonX3, True)
        Me.ButtonX3.Image = Global.Presentacion.My.Resources.Resources.iconacercar
        Me.ButtonX3.Location = New System.Drawing.Point(15, 179)
        Me.ButtonX3.Name = "ButtonX3"
        Me.ButtonX3.Size = New System.Drawing.Size(39, 39)
        Me.ButtonX3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX3.TabIndex = 2
        '
        'Gmc_Cliente
        '
        Me.Gmc_Cliente.Bearing = 0!
        Me.Gmc_Cliente.CanDragMap = True
        Me.Gmc_Cliente.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Gmc_Cliente.EmptyTileColor = System.Drawing.Color.Navy
        Me.Gmc_Cliente.GrayScaleMode = False
        Me.Gmc_Cliente.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow
        Me.Gmc_Cliente.LevelsKeepInMemmory = 5
        Me.Gmc_Cliente.Location = New System.Drawing.Point(0, 0)
        Me.Gmc_Cliente.MarkersEnabled = True
        Me.Gmc_Cliente.MaxZoom = 2
        Me.Gmc_Cliente.MinZoom = 2
        Me.Gmc_Cliente.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter
        Me.Gmc_Cliente.Name = "Gmc_Cliente"
        Me.Gmc_Cliente.NegativeMode = False
        Me.Gmc_Cliente.PolygonsEnabled = True
        Me.Gmc_Cliente.RetryLoadTile = 0
        Me.Gmc_Cliente.RoutesEnabled = True
        Me.Gmc_Cliente.ScaleMode = GMap.NET.WindowsForms.ScaleModes.[Integer]
        Me.Gmc_Cliente.SelectedAreaFillColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(105, Byte), Integer), CType(CType(225, Byte), Integer))
        Me.Gmc_Cliente.ShowTileGridLines = False
        Me.Gmc_Cliente.Size = New System.Drawing.Size(631, 235)
        Me.Gmc_Cliente.TabIndex = 1
        Me.Gmc_Cliente.Zoom = 0R
        '
        'SuperTabItem2
        '
        Me.SuperTabItem2.AttachedControl = Me.SuperTabControlPanel2
        Me.SuperTabItem2.GlobalItem = False
        Me.SuperTabItem2.Name = "SuperTabItem2"
        Me.SuperTabItem2.Text = "Ubicacion"
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
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX2.Location = New System.Drawing.Point(43, 91)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(59, 23)
        Me.LabelX2.TabIndex = 26
        Me.LabelX2.Text = "Vehiculo:"
        Me.LabelX2.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'tbnumiVehiculo
        '
        '
        '
        '
        Me.tbnumiVehiculo.Border.Class = "TextBoxBorder"
        Me.tbnumiVehiculo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbnumiVehiculo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbnumiVehiculo.Location = New System.Drawing.Point(309, 19)
        Me.tbnumiVehiculo.Name = "tbnumiVehiculo"
        Me.tbnumiVehiculo.PreventEnterBeep = True
        Me.tbnumiVehiculo.Size = New System.Drawing.Size(51, 23)
        Me.tbnumiVehiculo.TabIndex = 27
        Me.tbnumiVehiculo.Visible = False
        '
        'tbVehiculo
        '
        Me.tbVehiculo.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.tbVehiculo.Border.Class = "TextBoxBorder"
        Me.tbVehiculo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbVehiculo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbVehiculo.Location = New System.Drawing.Point(156, 92)
        Me.tbVehiculo.Name = "tbVehiculo"
        Me.tbVehiculo.PreventEnterBeep = True
        Me.tbVehiculo.Size = New System.Drawing.Size(267, 23)
        Me.tbVehiculo.TabIndex = 3
        '
        'btnAnadir
        '
        Me.btnAnadir.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnAnadir.ColorTable = DevComponents.DotNetBar.eButtonColor.Orange
        Me.btnAnadir.Image = Global.Presentacion.My.Resources.Resources.anadir
        Me.btnAnadir.ImageFixedSize = New System.Drawing.Size(25, 25)
        Me.btnAnadir.Location = New System.Drawing.Point(429, 87)
        Me.btnAnadir.Name = "btnAnadir"
        Me.btnAnadir.Size = New System.Drawing.Size(65, 32)
        Me.btnAnadir.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnAnadir.TabIndex = 29
        Me.btnAnadir.Text = "Añadir"
        '
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
        '
        'lbFechaPago
        '
        Me.lbFechaPago.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.lbFechaPago.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lbFechaPago.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbFechaPago.Location = New System.Drawing.Point(41, 218)
        Me.lbFechaPago.Name = "lbFechaPago"
        Me.lbFechaPago.Size = New System.Drawing.Size(83, 23)
        Me.lbFechaPago.TabIndex = 31
        Me.lbFechaPago.Text = "Ultima Pago:"
        Me.lbFechaPago.TextAlignment = System.Drawing.StringAlignment.Far
        Me.lbFechaPago.Visible = False
        '
        'tbFechaPago
        '
        '
        '
        '
        Me.tbFechaPago.Border.Class = "TextBoxBorder"
        Me.tbFechaPago.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbFechaPago.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbFechaPago.Location = New System.Drawing.Point(156, 219)
        Me.tbFechaPago.Name = "tbFechaPago"
        Me.tbFechaPago.PreventEnterBeep = True
        Me.tbFechaPago.Size = New System.Drawing.Size(156, 23)
        Me.tbFechaPago.TabIndex = 32
        Me.tbFechaPago.Visible = False
        Me.tbFechaPago.WatermarkColor = System.Drawing.Color.White
        '
        'tbClienteSocio
        '
        '
        '
        '
        Me.tbClienteSocio.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbClienteSocio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbClienteSocio.Location = New System.Drawing.Point(284, 191)
        Me.tbClienteSocio.Name = "tbClienteSocio"
        Me.tbClienteSocio.OffBackColor = System.Drawing.Color.DodgerBlue
        Me.tbClienteSocio.OffText = "SOCIO"
        Me.tbClienteSocio.OffTextColor = System.Drawing.Color.White
        Me.tbClienteSocio.OnBackColor = System.Drawing.Color.MidnightBlue
        Me.tbClienteSocio.OnText = "CLIENTE N"
        Me.tbClienteSocio.OnTextColor = System.Drawing.Color.White
        Me.tbClienteSocio.Size = New System.Drawing.Size(136, 22)
        Me.tbClienteSocio.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.tbClienteSocio.TabIndex = 33
        Me.tbClienteSocio.Value = True
        Me.tbClienteSocio.ValueObject = "Y"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.LabelX3)
        Me.Panel1.Controls.Add(Me.tbobs)
        Me.Panel1.Controls.Add(Me.lbUltimaPago)
        Me.Panel1.Controls.Add(Me.FechaVenta)
        Me.Panel1.Controls.Add(Me.LabelX8)
        Me.Panel1.Controls.Add(Me.tbnumiCliente)
        Me.Panel1.Controls.Add(Me.tbCliente)
        Me.Panel1.Controls.Add(Me.Estado)
        Me.Panel1.Controls.Add(Me.LabelX2)
        Me.Panel1.Controls.Add(Me.tbnumiVehiculo)
        Me.Panel1.Controls.Add(Me.tbVehiculo)
        Me.Panel1.Controls.Add(Me.LabelX1)
        Me.Panel1.Controls.Add(Me.UsImg)
        Me.Panel1.Controls.Add(Me.tbFechaPago)
        Me.Panel1.Controls.Add(Me.tbClienteSocio)
        Me.Panel1.Controls.Add(Me.lbFechaPago)
        Me.Panel1.Controls.Add(Me.tbCodigo)
        Me.Panel1.Controls.Add(Me.LabelX6)
        Me.Panel1.Controls.Add(Me.btnAnadir)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(711, 293)
        Me.Panel1.TabIndex = 34
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
        Me.LabelX3.TabIndex = 106
        Me.LabelX3.Text = "Observacion:"
        '
        'tbobs
        '
        Me.tbobs.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.tbobs.Border.Class = "TextBoxBorder"
        Me.tbobs.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbobs.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbobs.Location = New System.Drawing.Point(156, 121)
        Me.tbobs.Multiline = True
        Me.tbobs.Name = "tbobs"
        Me.tbobs.PreventEnterBeep = True
        Me.tbobs.Size = New System.Drawing.Size(254, 61)
        Me.tbobs.TabIndex = 105
        '
        'lbUltimaPago
        '
        '
        '
        '
        Me.lbUltimaPago.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lbUltimaPago.Font = New System.Drawing.Font("Arial", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbUltimaPago.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.lbUltimaPago.Location = New System.Drawing.Point(156, 250)
        Me.lbUltimaPago.Name = "lbUltimaPago"
        Me.lbUltimaPago.Size = New System.Drawing.Size(247, 37)
        Me.lbUltimaPago.TabIndex = 34
        Me.lbUltimaPago.Text = "HABILITADO"
        '
        'UsImg
        '
        Me.UsImg.BackColor = System.Drawing.Color.Transparent
        Me.UsImg.Location = New System.Drawing.Point(500, 15)
        Me.UsImg.Name = "UsImg"
        Me.UsImg.Size = New System.Drawing.Size(194, 170)
        Me.UsImg.TabIndex = 28
        '
        'F1_VentaRemolque
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1354, 733)
        Me.Name = "F1_VentaRemolque"
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
        CType(Me.FechaVenta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GpVentasSinCobrar.ResumeLayout(False)
        CType(Me.SuperTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SuperTabControl1.ResumeLayout(False)
        Me.SuperTabControlPanel1.ResumeLayout(False)
        CType(Me.grVentasPendientes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SuperTabControlPanel2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GpVentasSinCobrar As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents grVentasPendientes As Janus.Windows.GridEX.GridEX
    Friend WithEvents Estado As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents LabelX8 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Friend WithEvents FechaVenta As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents tbCodigo As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents GpDetalle As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents grDetalle As Janus.Windows.GridEX.GridEX
    Friend WithEvents GpTotales As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents tbTotal As DevComponents.Editors.DoubleInput
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents ButtonX2 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ButtonX1 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents tbCliente As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents tbnumiCliente As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents cmOpciones As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents Eliminarms As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents tbnumiVehiculo As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents tbVehiculo As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents UsImg As Presentacion.Us_Image
    Friend WithEvents btnAnadir As DevComponents.DotNetBar.ButtonX
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    Friend WithEvents tbFechaPago As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents lbFechaPago As DevComponents.DotNetBar.LabelX
    Friend WithEvents tbClienteSocio As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents SuperTabControl1 As DevComponents.DotNetBar.SuperTabControl
    Friend WithEvents SuperTabControlPanel1 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents SuperTabItem1 As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents SuperTabControlPanel2 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents SuperTabItem2 As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents lbUltimaPago As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents tbobs As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Gmc_Cliente As GMap.NET.WindowsForms.GMapControl
    Friend WithEvents ButtonX3 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ButtonX4 As DevComponents.DotNetBar.ButtonX
End Class
