<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F1_CABAÑA
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
        Dim cbTipo_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F1_CABAÑA))
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.tbNumi = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.tbnombre = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.tbdormi = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.tbper = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.cbTipo = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.tbobs = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX14 = New DevComponents.DotNetBar.LabelX()
        Me.PanelImagenes = New System.Windows.Forms.Panel()
        Me.BubbleBarImagenes = New DevComponents.DotNetBar.BubbleBar()
        Me.BubbleBarTabimagenes = New DevComponents.DotNetBar.BubbleBarTab(Me.components)
        Me.btnImg1 = New DevComponents.DotNetBar.BubbleButton()
        Me.btnImg2 = New DevComponents.DotNetBar.BubbleButton()
        Me.btnImg3 = New DevComponents.DotNetBar.BubbleButton()
        Me.btnImgSig = New DevComponents.DotNetBar.ButtonX()
        Me.btnImgAnt = New DevComponents.DotNetBar.ButtonX()
        Me.PanelAgrImagen = New System.Windows.Forms.Panel()
        Me.RadialMenuImgOpc = New DevComponents.DotNetBar.RadialMenu()
        Me.btnAgregar = New DevComponents.DotNetBar.RadialMenuItem()
        Me.btnEliminarIma = New DevComponents.DotNetBar.RadialMenuItem()
        Me.btnCancelarIma = New DevComponents.DotNetBar.RadialMenuItem()
        Me.OfdVehiculo = New System.Windows.Forms.OpenFileDialog()
        Me.btTipo = New DevComponents.DotNetBar.ButtonX()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        Me.tbPerMenores = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.SuperTabControl1 = New DevComponents.DotNetBar.SuperTabControl()
        Me.SuperTabControlPanel2 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.grDetalle = New Janus.Windows.GridEX.GridEX()
        Me.SuperTabItem2 = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabControlPanel1 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.SuperTabItem1 = New DevComponents.DotNetBar.SuperTabItem()
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
        CType(Me.cbTipo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelImagenes.SuspendLayout()
        CType(Me.BubbleBarImagenes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.btnImgAnt.SuspendLayout()
        Me.PanelAgrImagen.SuspendLayout()
        CType(Me.SuperTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuperTabControl1.SuspendLayout()
        Me.SuperTabControlPanel2.SuspendLayout()
        CType(Me.grDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuperTabControlPanel1.SuspendLayout()
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
        Me.SuperTabControlPanelBuscador.Size = New System.Drawing.Size(1300, 536)
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
        Me.PanelInferior.Location = New System.Drawing.Point(0, 672)
        Me.PanelInferior.Size = New System.Drawing.Size(1354, 36)
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
        'btnGrabar
        '
        Me.btnGrabar.TabIndex = 0
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
        Me.MPanelSup.Controls.Add(Me.SuperTabControl1)
        Me.MPanelSup.Controls.Add(Me.LabelX6)
        Me.MPanelSup.Controls.Add(Me.tbPerMenores)
        Me.MPanelSup.Controls.Add(Me.btTipo)
        Me.MPanelSup.Controls.Add(Me.tbobs)
        Me.MPanelSup.Controls.Add(Me.LabelX14)
        Me.MPanelSup.Controls.Add(Me.cbTipo)
        Me.MPanelSup.Controls.Add(Me.LabelX5)
        Me.MPanelSup.Controls.Add(Me.LabelX4)
        Me.MPanelSup.Controls.Add(Me.tbper)
        Me.MPanelSup.Controls.Add(Me.LabelX2)
        Me.MPanelSup.Controls.Add(Me.tbdormi)
        Me.MPanelSup.Controls.Add(Me.LabelX1)
        Me.MPanelSup.Controls.Add(Me.tbNumi)
        Me.MPanelSup.Controls.Add(Me.LabelX3)
        Me.MPanelSup.Controls.Add(Me.tbnombre)
        Me.MPanelSup.Size = New System.Drawing.Size(1354, 243)
        Me.MPanelSup.Controls.SetChildIndex(Me.PanelUsuario, 0)
        Me.MPanelSup.Controls.SetChildIndex(Me.tbnombre, 0)
        Me.MPanelSup.Controls.SetChildIndex(Me.LabelX3, 0)
        Me.MPanelSup.Controls.SetChildIndex(Me.tbNumi, 0)
        Me.MPanelSup.Controls.SetChildIndex(Me.LabelX1, 0)
        Me.MPanelSup.Controls.SetChildIndex(Me.tbdormi, 0)
        Me.MPanelSup.Controls.SetChildIndex(Me.LabelX2, 0)
        Me.MPanelSup.Controls.SetChildIndex(Me.tbper, 0)
        Me.MPanelSup.Controls.SetChildIndex(Me.LabelX4, 0)
        Me.MPanelSup.Controls.SetChildIndex(Me.LabelX5, 0)
        Me.MPanelSup.Controls.SetChildIndex(Me.cbTipo, 0)
        Me.MPanelSup.Controls.SetChildIndex(Me.LabelX14, 0)
        Me.MPanelSup.Controls.SetChildIndex(Me.tbobs, 0)
        Me.MPanelSup.Controls.SetChildIndex(Me.btTipo, 0)
        Me.MPanelSup.Controls.SetChildIndex(Me.tbPerMenores, 0)
        Me.MPanelSup.Controls.SetChildIndex(Me.LabelX6, 0)
        Me.MPanelSup.Controls.SetChildIndex(Me.SuperTabControl1, 0)
        '
        'PanelPrincipal
        '
        Me.PanelPrincipal.Size = New System.Drawing.Size(1354, 600)
        '
        'GroupPanelBuscador
        '
        Me.GroupPanelBuscador.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MEP.SetIconAlignment(Me.GroupPanelBuscador, System.Windows.Forms.ErrorIconAlignment.BottomLeft)
        Me.GroupPanelBuscador.Location = New System.Drawing.Point(0, 243)
        Me.GroupPanelBuscador.Size = New System.Drawing.Size(1354, 357)
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
        Me.GroupPanelBuscador.TitleImagePosition = DevComponents.DotNetBar.eTitleImagePosition.Center
        '
        'JGrM_Buscador
        '
        Me.JGrM_Buscador.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.JGrM_Buscador.Office2007ColorScheme = Janus.Windows.GridEX.Office2007ColorScheme.Custom
        Me.JGrM_Buscador.Office2007CustomColor = System.Drawing.Color.DodgerBlue
        Me.JGrM_Buscador.Size = New System.Drawing.Size(1348, 332)
        Me.JGrM_Buscador.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'PanelUsuario
        '
        Me.PanelUsuario.Location = New System.Drawing.Point(924, 28)
        '
        'MPanelUserAct
        '
        Me.MPanelUserAct.Location = New System.Drawing.Point(1154, 0)
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX1.Location = New System.Drawing.Point(17, 5)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(21, 23)
        Me.LabelX1.TabIndex = 188
        Me.LabelX1.Text = "ID:"
        '
        'tbNumi
        '
        '
        '
        '
        Me.tbNumi.Border.Class = "TextBoxBorder"
        Me.tbNumi.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbNumi.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbNumi.Location = New System.Drawing.Point(180, 6)
        Me.tbNumi.Name = "tbNumi"
        Me.tbNumi.PreventEnterBeep = True
        Me.tbNumi.Size = New System.Drawing.Size(57, 22)
        Me.tbNumi.TabIndex = 0
        Me.tbNumi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LabelX3
        '
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX3.Location = New System.Drawing.Point(17, 36)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(74, 23)
        Me.LabelX3.TabIndex = 189
        Me.LabelX3.Text = "*NOMBRE:"
        '
        'tbnombre
        '
        '
        '
        '
        Me.tbnombre.Border.Class = "TextBoxBorder"
        Me.tbnombre.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbnombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbnombre.Location = New System.Drawing.Point(180, 36)
        Me.tbnombre.Name = "tbnombre"
        Me.tbnombre.PreventEnterBeep = True
        Me.tbnombre.Size = New System.Drawing.Size(192, 22)
        Me.tbnombre.TabIndex = 1
        '
        'LabelX2
        '
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX2.Location = New System.Drawing.Point(17, 65)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(157, 23)
        Me.LabelX2.TabIndex = 191
        Me.LabelX2.Text = "*CANT. DORMITORIOS:"
        '
        'tbdormi
        '
        '
        '
        '
        Me.tbdormi.Border.Class = "TextBoxBorder"
        Me.tbdormi.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbdormi.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbdormi.Location = New System.Drawing.Point(180, 65)
        Me.tbdormi.Name = "tbdormi"
        Me.tbdormi.PreventEnterBeep = True
        Me.tbdormi.Size = New System.Drawing.Size(57, 22)
        Me.tbdormi.TabIndex = 2
        Me.tbdormi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LabelX4
        '
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX4.Location = New System.Drawing.Point(17, 94)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(140, 23)
        Me.LabelX4.TabIndex = 193
        Me.LabelX4.Text = "*CANT. MAYORES:"
        '
        'tbper
        '
        '
        '
        '
        Me.tbper.Border.Class = "TextBoxBorder"
        Me.tbper.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbper.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbper.Location = New System.Drawing.Point(180, 94)
        Me.tbper.Name = "tbper"
        Me.tbper.PreventEnterBeep = True
        Me.tbper.Size = New System.Drawing.Size(57, 22)
        Me.tbper.TabIndex = 3
        Me.tbper.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cbTipo
        '
        cbTipo_DesignTimeLayout.LayoutString = resources.GetString("cbTipo_DesignTimeLayout.LayoutString")
        Me.cbTipo.DesignTimeLayout = cbTipo_DesignTimeLayout
        Me.cbTipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbTipo.Location = New System.Drawing.Point(180, 150)
        Me.cbTipo.Name = "cbTipo"
        Me.cbTipo.Office2007ColorScheme = Janus.Windows.GridEX.Office2007ColorScheme.Custom
        Me.cbTipo.Office2007CustomColor = System.Drawing.Color.DodgerBlue
        Me.cbTipo.SelectedIndex = -1
        Me.cbTipo.SelectedItem = Nothing
        Me.cbTipo.Size = New System.Drawing.Size(156, 22)
        Me.cbTipo.TabIndex = 4
        Me.cbTipo.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'LabelX5
        '
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX5.Location = New System.Drawing.Point(17, 148)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(50, 23)
        Me.LabelX5.TabIndex = 195
        Me.LabelX5.Text = "*TIPO:"
        '
        'tbobs
        '
        '
        '
        '
        Me.tbobs.Border.Class = "TextBoxBorder"
        Me.tbobs.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbobs.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbobs.Location = New System.Drawing.Point(180, 178)
        Me.tbobs.Multiline = True
        Me.tbobs.Name = "tbobs"
        Me.tbobs.PreventEnterBeep = True
        Me.tbobs.Size = New System.Drawing.Size(264, 53)
        Me.tbobs.TabIndex = 5
        '
        'LabelX14
        '
        '
        '
        '
        Me.LabelX14.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX14.Location = New System.Drawing.Point(16, 178)
        Me.LabelX14.Name = "LabelX14"
        Me.LabelX14.Size = New System.Drawing.Size(116, 23)
        Me.LabelX14.TabIndex = 198
        Me.LabelX14.Text = "OBSERVACION:"
        '
        'PanelImagenes
        '
        Me.PanelImagenes.Controls.Add(Me.BubbleBarImagenes)
        Me.PanelImagenes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelImagenes.Location = New System.Drawing.Point(48, 0)
        Me.PanelImagenes.Name = "PanelImagenes"
        Me.PanelImagenes.Size = New System.Drawing.Size(639, 216)
        Me.PanelImagenes.TabIndex = 0
        '
        'BubbleBarImagenes
        '
        Me.BubbleBarImagenes.Alignment = DevComponents.DotNetBar.eBubbleButtonAlignment.Bottom
        Me.BubbleBarImagenes.AntiAlias = True
        '
        '
        '
        Me.BubbleBarImagenes.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.BubbleBarImagenes.ButtonBackAreaStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(105, Byte), Integer), CType(CType(105, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.BubbleBarImagenes.ButtonBackAreaStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.BubbleBarImagenes.ButtonBackAreaStyle.BorderBottomWidth = 1
        Me.BubbleBarImagenes.ButtonBackAreaStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.BubbleBarImagenes.ButtonBackAreaStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.BubbleBarImagenes.ButtonBackAreaStyle.BorderLeftWidth = 1
        Me.BubbleBarImagenes.ButtonBackAreaStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.BubbleBarImagenes.ButtonBackAreaStyle.BorderRightWidth = 1
        Me.BubbleBarImagenes.ButtonBackAreaStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.BubbleBarImagenes.ButtonBackAreaStyle.BorderTopWidth = 1
        Me.BubbleBarImagenes.ButtonBackAreaStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.BubbleBarImagenes.ButtonBackAreaStyle.PaddingBottom = 3
        Me.BubbleBarImagenes.ButtonBackAreaStyle.PaddingLeft = 3
        Me.BubbleBarImagenes.ButtonBackAreaStyle.PaddingRight = 3
        Me.BubbleBarImagenes.ButtonBackAreaStyle.PaddingTop = 3
        Me.BubbleBarImagenes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BubbleBarImagenes.ImageSizeLarge = New System.Drawing.Size(240, 240)
        Me.BubbleBarImagenes.ImageSizeNormal = New System.Drawing.Size(200, 200)
        Me.BubbleBarImagenes.Location = New System.Drawing.Point(0, 0)
        Me.BubbleBarImagenes.MouseOverTabColors.BorderColor = System.Drawing.SystemColors.Highlight
        Me.BubbleBarImagenes.Name = "BubbleBarImagenes"
        Me.BubbleBarImagenes.SelectedTab = Me.BubbleBarTabimagenes
        Me.BubbleBarImagenes.SelectedTabColors.BorderColor = System.Drawing.Color.Black
        Me.BubbleBarImagenes.Size = New System.Drawing.Size(639, 216)
        Me.BubbleBarImagenes.TabIndex = 4
        Me.BubbleBarImagenes.Tabs.Add(Me.BubbleBarTabimagenes)
        Me.BubbleBarImagenes.TabsVisible = False
        Me.BubbleBarImagenes.Text = "BubbleBar1"
        '
        'BubbleBarTabimagenes
        '
        Me.BubbleBarTabimagenes.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.BubbleBarTabimagenes.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.BubbleBarTabimagenes.Buttons.AddRange(New DevComponents.DotNetBar.BubbleButton() {Me.btnImg1, Me.btnImg2, Me.btnImg3})
        Me.BubbleBarTabimagenes.DarkBorderColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(105, Byte), Integer), CType(CType(105, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.BubbleBarTabimagenes.LightBorderColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.BubbleBarTabimagenes.Name = "BubbleBarTabimagenes"
        Me.BubbleBarTabimagenes.PredefinedColor = DevComponents.DotNetBar.eTabItemColor.Blue
        Me.BubbleBarTabimagenes.Text = "BubbleBarTab1"
        Me.BubbleBarTabimagenes.TextColor = System.Drawing.Color.Black
        '
        'btnImg1
        '
        Me.btnImg1.Name = "btnImg1"
        '
        'btnImg2
        '
        Me.btnImg2.Name = "btnImg2"
        '
        'btnImg3
        '
        Me.btnImg3.Name = "btnImg3"
        '
        'btnImgSig
        '
        Me.btnImgSig.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnImgSig.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb
        Me.btnImgSig.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnImgSig.Image = CType(resources.GetObject("btnImgSig.Image"), System.Drawing.Image)
        Me.btnImgSig.ImageFixedSize = New System.Drawing.Size(64, 64)
        Me.btnImgSig.Location = New System.Drawing.Point(687, 0)
        Me.btnImgSig.Name = "btnImgSig"
        Me.btnImgSig.Size = New System.Drawing.Size(54, 216)
        Me.btnImgSig.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnImgSig.TabIndex = 2
        '
        'btnImgAnt
        '
        Me.btnImgAnt.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnImgAnt.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.btnImgAnt.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb
        Me.btnImgAnt.Controls.Add(Me.PanelAgrImagen)
        Me.btnImgAnt.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnImgAnt.Image = CType(resources.GetObject("btnImgAnt.Image"), System.Drawing.Image)
        Me.btnImgAnt.ImageFixedSize = New System.Drawing.Size(64, 64)
        Me.btnImgAnt.Location = New System.Drawing.Point(0, 0)
        Me.btnImgAnt.Name = "btnImgAnt"
        Me.btnImgAnt.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2)
        Me.btnImgAnt.Size = New System.Drawing.Size(48, 216)
        Me.btnImgAnt.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013
        Me.btnImgAnt.TabIndex = 1
        '
        'PanelAgrImagen
        '
        Me.PanelAgrImagen.BackColor = System.Drawing.Color.Transparent
        Me.PanelAgrImagen.Controls.Add(Me.RadialMenuImgOpc)
        Me.PanelAgrImagen.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelAgrImagen.Location = New System.Drawing.Point(0, 0)
        Me.PanelAgrImagen.Name = "PanelAgrImagen"
        Me.PanelAgrImagen.Size = New System.Drawing.Size(48, 35)
        Me.PanelAgrImagen.TabIndex = 0
        '
        'RadialMenuImgOpc
        '
        Me.RadialMenuImgOpc.BackButtonSymbol = "."
        Me.RadialMenuImgOpc.BackButtonSymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.RadialMenuImgOpc.BackColor = System.Drawing.Color.Transparent
        Me.RadialMenuImgOpc.CenterButtonDiameter = 40
        Me.RadialMenuImgOpc.Diameter = 200
        Me.RadialMenuImgOpc.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadialMenuImgOpc.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnAgregar, Me.btnEliminarIma, Me.btnCancelarIma})
        Me.RadialMenuImgOpc.Location = New System.Drawing.Point(5, 4)
        Me.RadialMenuImgOpc.Name = "RadialMenuImgOpc"
        Me.RadialMenuImgOpc.Size = New System.Drawing.Size(28, 28)
        Me.RadialMenuImgOpc.Symbol = ""
        Me.RadialMenuImgOpc.SymbolSize = 23.0!
        Me.RadialMenuImgOpc.TabIndex = 0
        Me.RadialMenuImgOpc.Text = "RadialMenu1"
        '
        'btnAgregar
        '
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Symbol = "57937"
        Me.btnAgregar.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.btnAgregar.Text = "ADD IMAGEN"
        '
        'btnEliminarIma
        '
        Me.btnEliminarIma.Name = "btnEliminarIma"
        Me.btnEliminarIma.Symbol = ""
        Me.btnEliminarIma.Text = "DELETE"
        '
        'btnCancelarIma
        '
        Me.btnCancelarIma.Name = "btnCancelarIma"
        Me.btnCancelarIma.Symbol = ""
        Me.btnCancelarIma.Text = "CANCELAR"
        '
        'OfdVehiculo
        '
        Me.OfdVehiculo.FileName = "OpenFileDialog1"
        '
        'btTipo
        '
        Me.btTipo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btTipo.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat
        Me.btTipo.Image = Global.Presentacion.My.Resources.Resources.anadir
        Me.btTipo.ImageFixedSize = New System.Drawing.Size(28, 28)
        Me.btTipo.Location = New System.Drawing.Point(340, 145)
        Me.btTipo.Name = "btTipo"
        Me.btTipo.Size = New System.Drawing.Size(34, 29)
        Me.btTipo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btTipo.TabIndex = 200
        Me.btTipo.Visible = False
        '
        'LabelX6
        '
        '
        '
        '
        Me.LabelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX6.Location = New System.Drawing.Point(17, 122)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(140, 23)
        Me.LabelX6.TabIndex = 202
        Me.LabelX6.Text = "*CANT. MENORES:"
        '
        'tbPerMenores
        '
        '
        '
        '
        Me.tbPerMenores.Border.Class = "TextBoxBorder"
        Me.tbPerMenores.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbPerMenores.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbPerMenores.Location = New System.Drawing.Point(180, 122)
        Me.tbPerMenores.Name = "tbPerMenores"
        Me.tbPerMenores.PreventEnterBeep = True
        Me.tbPerMenores.Size = New System.Drawing.Size(57, 22)
        Me.tbPerMenores.TabIndex = 201
        Me.tbPerMenores.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
        Me.SuperTabControl1.Controls.Add(Me.SuperTabControlPanel2)
        Me.SuperTabControl1.Controls.Add(Me.SuperTabControlPanel1)
        Me.SuperTabControl1.Dock = System.Windows.Forms.DockStyle.Right
        Me.SuperTabControl1.Location = New System.Drawing.Point(613, 0)
        Me.SuperTabControl1.Name = "SuperTabControl1"
        Me.SuperTabControl1.ReorderTabsEnabled = True
        Me.SuperTabControl1.SelectedTabFont = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.SuperTabControl1.SelectedTabIndex = 0
        Me.SuperTabControl1.Size = New System.Drawing.Size(741, 243)
        Me.SuperTabControl1.TabFont = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SuperTabControl1.TabIndex = 203
        Me.SuperTabControl1.Tabs.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.SuperTabItem1, Me.SuperTabItem2})
        Me.SuperTabControl1.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.Office2010BackstageBlue
        Me.SuperTabControl1.Text = "Descuento"
        '
        'SuperTabControlPanel2
        '
        Me.SuperTabControlPanel2.Controls.Add(Me.grDetalle)
        Me.SuperTabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel2.Location = New System.Drawing.Point(0, 27)
        Me.SuperTabControlPanel2.Name = "SuperTabControlPanel2"
        Me.SuperTabControlPanel2.Size = New System.Drawing.Size(741, 216)
        Me.SuperTabControlPanel2.TabIndex = 0
        Me.SuperTabControlPanel2.TabItem = Me.SuperTabItem2
        '
        'grDetalle
        '
        Me.grDetalle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grDetalle.Location = New System.Drawing.Point(0, 0)
        Me.grDetalle.Name = "grDetalle"
        Me.grDetalle.Size = New System.Drawing.Size(741, 216)
        Me.grDetalle.TabIndex = 0
        '
        'SuperTabItem2
        '
        Me.SuperTabItem2.AttachedControl = Me.SuperTabControlPanel2
        Me.SuperTabItem2.GlobalItem = False
        Me.SuperTabItem2.Name = "SuperTabItem2"
        Me.SuperTabItem2.Text = "PRECIOS"
        '
        'SuperTabControlPanel1
        '
        Me.SuperTabControlPanel1.Controls.Add(Me.Panel1)
        Me.SuperTabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel1.Location = New System.Drawing.Point(0, 27)
        Me.SuperTabControlPanel1.Name = "SuperTabControlPanel1"
        Me.SuperTabControlPanel1.Size = New System.Drawing.Size(741, 216)
        Me.SuperTabControlPanel1.TabIndex = 1
        Me.SuperTabControlPanel1.TabItem = Me.SuperTabItem1
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.PanelImagenes)
        Me.Panel1.Controls.Add(Me.btnImgSig)
        Me.Panel1.Controls.Add(Me.btnImgAnt)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(741, 216)
        Me.Panel1.TabIndex = 5
        '
        'SuperTabItem1
        '
        Me.SuperTabItem1.AttachedControl = Me.SuperTabControlPanel1
        Me.SuperTabItem1.GlobalItem = False
        Me.SuperTabItem1.Name = "SuperTabItem1"
        Me.SuperTabItem1.Text = "GALERIA DE IMAGENES"
        '
        'F1_CABAÑA
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1354, 733)
        Me.Name = "F1_CABAÑA"
        Me.Text = "F1_CABAÑA"
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
        Me.MPanelSup.PerformLayout()
        Me.PanelPrincipal.ResumeLayout(False)
        Me.GroupPanelBuscador.ResumeLayout(False)
        CType(Me.JGrM_Buscador, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelUsuario.ResumeLayout(False)
        Me.PanelUsuario.PerformLayout()
        Me.PanelNavegacion.ResumeLayout(False)
        Me.MPanelUserAct.ResumeLayout(False)
        Me.MPanelUserAct.PerformLayout()
        CType(Me.MEP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbTipo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelImagenes.ResumeLayout(False)
        CType(Me.BubbleBarImagenes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.btnImgAnt.ResumeLayout(False)
        Me.PanelAgrImagen.ResumeLayout(False)
        CType(Me.SuperTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SuperTabControl1.ResumeLayout(False)
        Me.SuperTabControlPanel2.ResumeLayout(False)
        CType(Me.grDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SuperTabControlPanel1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents tbper As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents tbdormi As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents tbNumi As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents tbnombre As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents cbTipo As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents tbobs As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX14 As DevComponents.DotNetBar.LabelX
    Friend WithEvents PanelImagenes As System.Windows.Forms.Panel
    Friend WithEvents BubbleBarImagenes As DevComponents.DotNetBar.BubbleBar
    Friend WithEvents BubbleBarTabimagenes As DevComponents.DotNetBar.BubbleBarTab
    Friend WithEvents btnImg1 As DevComponents.DotNetBar.BubbleButton
    Friend WithEvents btnImg2 As DevComponents.DotNetBar.BubbleButton
    Friend WithEvents btnImg3 As DevComponents.DotNetBar.BubbleButton
    Friend WithEvents btnImgSig As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnImgAnt As DevComponents.DotNetBar.ButtonX
    Friend WithEvents PanelAgrImagen As System.Windows.Forms.Panel
    Friend WithEvents RadialMenuImgOpc As DevComponents.DotNetBar.RadialMenu
    Friend WithEvents OfdVehiculo As System.Windows.Forms.OpenFileDialog
    Friend WithEvents btnAgregar As DevComponents.DotNetBar.RadialMenuItem
    Friend WithEvents btTipo As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnEliminarIma As DevComponents.DotNetBar.RadialMenuItem
    Friend WithEvents btnCancelarIma As DevComponents.DotNetBar.RadialMenuItem
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Friend WithEvents tbPerMenores As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents SuperTabControl1 As DevComponents.DotNetBar.SuperTabControl
    Friend WithEvents SuperTabControlPanel1 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents SuperTabItem1 As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents SuperTabControlPanel2 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents SuperTabItem2 As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents grDetalle As Janus.Windows.GridEX.GridEX
End Class
