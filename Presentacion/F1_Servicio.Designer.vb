<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F1_Servicio
    Inherits Modelos.ModeloF1

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
        Me.components = New System.ComponentModel.Container()
        Dim tbTipo_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim tbTipoPrecio_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cbsucursal_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F1_Servicio))
        Me.tbTipo = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.LabelX16 = New DevComponents.DotNetBar.LabelX()
        Me.tbEstado = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.LabelX15 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.tbDesc = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.tbCodigo = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.tbNumi = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.gpDetalle1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.grDetalle = New Janus.Windows.GridEX.GridEX()
        Me.cmOpciones = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.btnElimFila1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.tbPrecio = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.btTipo = New DevComponents.DotNetBar.ButtonX()
        Me.gpDetalle2 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.grDetalle2 = New Janus.Windows.GridEX.GridEX()
        Me.tbTipoPrecio = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.cmOpciones2 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.btnEliminar2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.cbsucursal = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
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
        CType(Me.tbTipo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpDetalle1.SuspendLayout()
        CType(Me.grDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmOpciones.SuspendLayout()
        Me.gpDetalle2.SuspendLayout()
        CType(Me.grDetalle2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbTipoPrecio, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmOpciones2.SuspendLayout()
        CType(Me.cbsucursal, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.SuperTabPrincipal.Margin = New System.Windows.Forms.Padding(5)
        Me.SuperTabPrincipal.Size = New System.Drawing.Size(1906, 690)
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
        Me.SuperTabControlPanelRegistro.Margin = New System.Windows.Forms.Padding(5)
        Me.SuperTabControlPanelRegistro.Size = New System.Drawing.Size(1906, 662)
        Me.SuperTabControlPanelRegistro.Controls.SetChildIndex(Me.PanelSuperior, 0)
        Me.SuperTabControlPanelRegistro.Controls.SetChildIndex(Me.PanelInferior, 0)
        Me.SuperTabControlPanelRegistro.Controls.SetChildIndex(Me.PanelPrincipal, 0)
        '
        'PanelSuperior
        '
        Me.PanelSuperior.Margin = New System.Windows.Forms.Padding(5)
        Me.PanelSuperior.Size = New System.Drawing.Size(1906, 89)
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
        Me.PanelInferior.Margin = New System.Windows.Forms.Padding(5)
        Me.PanelInferior.Size = New System.Drawing.Size(1906, 44)
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
        'btnEliminar
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
        Me.PanelToolBar2.Location = New System.Drawing.Point(1799, 0)
        Me.PanelToolBar2.Margin = New System.Windows.Forms.Padding(5)
        '
        'MPanelSup
        '
        Me.MPanelSup.Controls.Add(Me.cbsucursal)
        Me.MPanelSup.Controls.Add(Me.LabelX5)
        Me.MPanelSup.Controls.Add(Me.tbTipoPrecio)
        Me.MPanelSup.Controls.Add(Me.gpDetalle2)
        Me.MPanelSup.Controls.Add(Me.btTipo)
        Me.MPanelSup.Controls.Add(Me.tbPrecio)
        Me.MPanelSup.Controls.Add(Me.gpDetalle1)
        Me.MPanelSup.Controls.Add(Me.LabelX4)
        Me.MPanelSup.Controls.Add(Me.tbTipo)
        Me.MPanelSup.Controls.Add(Me.LabelX16)
        Me.MPanelSup.Controls.Add(Me.tbEstado)
        Me.MPanelSup.Controls.Add(Me.LabelX15)
        Me.MPanelSup.Controls.Add(Me.LabelX3)
        Me.MPanelSup.Controls.Add(Me.tbDesc)
        Me.MPanelSup.Controls.Add(Me.LabelX2)
        Me.MPanelSup.Controls.Add(Me.tbCodigo)
        Me.MPanelSup.Controls.Add(Me.LabelX1)
        Me.MPanelSup.Controls.Add(Me.tbNumi)
        Me.MPanelSup.Margin = New System.Windows.Forms.Padding(5)
        Me.MPanelSup.Size = New System.Drawing.Size(1906, 226)
        Me.MPanelSup.Controls.SetChildIndex(Me.PanelUsuario, 0)
        Me.MPanelSup.Controls.SetChildIndex(Me.tbNumi, 0)
        Me.MPanelSup.Controls.SetChildIndex(Me.LabelX1, 0)
        Me.MPanelSup.Controls.SetChildIndex(Me.tbCodigo, 0)
        Me.MPanelSup.Controls.SetChildIndex(Me.LabelX2, 0)
        Me.MPanelSup.Controls.SetChildIndex(Me.tbDesc, 0)
        Me.MPanelSup.Controls.SetChildIndex(Me.LabelX3, 0)
        Me.MPanelSup.Controls.SetChildIndex(Me.LabelX15, 0)
        Me.MPanelSup.Controls.SetChildIndex(Me.tbEstado, 0)
        Me.MPanelSup.Controls.SetChildIndex(Me.LabelX16, 0)
        Me.MPanelSup.Controls.SetChildIndex(Me.tbTipo, 0)
        Me.MPanelSup.Controls.SetChildIndex(Me.LabelX4, 0)
        Me.MPanelSup.Controls.SetChildIndex(Me.gpDetalle1, 0)
        Me.MPanelSup.Controls.SetChildIndex(Me.tbPrecio, 0)
        Me.MPanelSup.Controls.SetChildIndex(Me.btTipo, 0)
        Me.MPanelSup.Controls.SetChildIndex(Me.gpDetalle2, 0)
        Me.MPanelSup.Controls.SetChildIndex(Me.tbTipoPrecio, 0)
        Me.MPanelSup.Controls.SetChildIndex(Me.LabelX5, 0)
        Me.MPanelSup.Controls.SetChildIndex(Me.cbsucursal, 0)
        '
        'PanelPrincipal
        '
        Me.PanelPrincipal.Margin = New System.Windows.Forms.Padding(5)
        Me.PanelPrincipal.Size = New System.Drawing.Size(1906, 529)
        '
        'GroupPanelBuscador
        '
        Me.GroupPanelBuscador.Margin = New System.Windows.Forms.Padding(5)
        Me.GroupPanelBuscador.Size = New System.Drawing.Size(1906, 303)
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
        '
        'JGrM_Buscador
        '
        Me.JGrM_Buscador.Margin = New System.Windows.Forms.Padding(5)
        Me.JGrM_Buscador.Size = New System.Drawing.Size(1900, 276)
        '
        'PanelUsuario
        '
        Me.PanelUsuario.Location = New System.Drawing.Point(680, 22)
        Me.PanelUsuario.Margin = New System.Windows.Forms.Padding(5)
        '
        'btnUltimo
        '
        Me.btnUltimo.Location = New System.Drawing.Point(171, 0)
        '
        'MPanelUserAct
        '
        Me.MPanelUserAct.Location = New System.Drawing.Point(1639, 0)
        Me.MPanelUserAct.Margin = New System.Windows.Forms.Padding(5)
        '
        'tbTipo
        '
        tbTipo_DesignTimeLayout.LayoutString = resources.GetString("tbTipo_DesignTimeLayout.LayoutString")
        Me.tbTipo.DesignTimeLayout = tbTipo_DesignTimeLayout
        Me.tbTipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbTipo.Location = New System.Drawing.Point(164, 130)
        Me.tbTipo.Margin = New System.Windows.Forms.Padding(4)
        Me.tbTipo.Name = "tbTipo"
        Me.tbTipo.SelectedIndex = -1
        Me.tbTipo.SelectedItem = Nothing
        Me.tbTipo.Size = New System.Drawing.Size(208, 26)
        Me.tbTipo.TabIndex = 2
        '
        'LabelX16
        '
        '
        '
        '
        Me.LabelX16.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX16.Location = New System.Drawing.Point(31, 126)
        Me.LabelX16.Margin = New System.Windows.Forms.Padding(4)
        Me.LabelX16.Name = "LabelX16"
        Me.LabelX16.Size = New System.Drawing.Size(116, 28)
        Me.LabelX16.TabIndex = 101
        Me.LabelX16.Text = "TIPO:"
        '
        'tbEstado
        '
        '
        '
        '
        Me.tbEstado.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbEstado.Location = New System.Drawing.Point(463, 58)
        Me.tbEstado.Margin = New System.Windows.Forms.Padding(4)
        Me.tbEstado.Name = "tbEstado"
        Me.tbEstado.OffText = "INACTIVO"
        Me.tbEstado.OnText = "ACTIVO"
        Me.tbEstado.Size = New System.Drawing.Size(181, 27)
        Me.tbEstado.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.tbEstado.TabIndex = 6
        '
        'LabelX15
        '
        '
        '
        '
        Me.LabelX15.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX15.Location = New System.Drawing.Point(349, 54)
        Me.LabelX15.Margin = New System.Windows.Forms.Padding(4)
        Me.LabelX15.Name = "LabelX15"
        Me.LabelX15.Size = New System.Drawing.Size(100, 28)
        Me.LabelX15.TabIndex = 99
        Me.LabelX15.Text = "ESTADO:"
        '
        'LabelX3
        '
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX3.Location = New System.Drawing.Point(31, 90)
        Me.LabelX3.Margin = New System.Windows.Forms.Padding(4)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(128, 28)
        Me.LabelX3.TabIndex = 98
        Me.LabelX3.Text = "DESCRIPCION:"
        '
        'tbDesc
        '
        '
        '
        '
        Me.tbDesc.Border.Class = "TextBoxBorder"
        Me.tbDesc.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbDesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbDesc.Location = New System.Drawing.Point(163, 94)
        Me.tbDesc.Margin = New System.Windows.Forms.Padding(4)
        Me.tbDesc.Name = "tbDesc"
        Me.tbDesc.PreventEnterBeep = True
        Me.tbDesc.Size = New System.Drawing.Size(575, 26)
        Me.tbDesc.TabIndex = 1
        '
        'LabelX2
        '
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX2.Location = New System.Drawing.Point(31, 54)
        Me.LabelX2.Margin = New System.Windows.Forms.Padding(4)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(100, 28)
        Me.LabelX2.TabIndex = 97
        Me.LabelX2.Text = "CODIGO:"
        '
        'tbCodigo
        '
        '
        '
        '
        Me.tbCodigo.Border.Class = "TextBoxBorder"
        Me.tbCodigo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbCodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbCodigo.Location = New System.Drawing.Point(163, 58)
        Me.tbCodigo.Margin = New System.Windows.Forms.Padding(4)
        Me.tbCodigo.Name = "tbCodigo"
        Me.tbCodigo.PreventEnterBeep = True
        Me.tbCodigo.Size = New System.Drawing.Size(133, 26)
        Me.tbCodigo.TabIndex = 0
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX1.Location = New System.Drawing.Point(31, 18)
        Me.LabelX1.Margin = New System.Windows.Forms.Padding(4)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(100, 28)
        Me.LabelX1.TabIndex = 96
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
        Me.tbNumi.Location = New System.Drawing.Point(163, 22)
        Me.tbNumi.Margin = New System.Windows.Forms.Padding(4)
        Me.tbNumi.Name = "tbNumi"
        Me.tbNumi.PreventEnterBeep = True
        Me.tbNumi.Size = New System.Drawing.Size(133, 26)
        Me.tbNumi.TabIndex = 6
        '
        'LabelX4
        '
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX4.Location = New System.Drawing.Point(31, 161)
        Me.LabelX4.Margin = New System.Windows.Forms.Padding(4)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(116, 28)
        Me.LabelX4.TabIndex = 103
        Me.LabelX4.Text = "PRECIO:"
        '
        'gpDetalle1
        '
        Me.gpDetalle1.CanvasColor = System.Drawing.SystemColors.Control
        Me.gpDetalle1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.gpDetalle1.Controls.Add(Me.grDetalle)
        Me.gpDetalle1.DisabledBackColor = System.Drawing.Color.Empty
        Me.gpDetalle1.Dock = System.Windows.Forms.DockStyle.Right
        Me.gpDetalle1.Location = New System.Drawing.Point(1499, 0)
        Me.gpDetalle1.Margin = New System.Windows.Forms.Padding(4)
        Me.gpDetalle1.Name = "gpDetalle1"
        Me.gpDetalle1.Size = New System.Drawing.Size(407, 226)
        '
        '
        '
        Me.gpDetalle1.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.gpDetalle1.Style.BackColorGradientAngle = 90
        Me.gpDetalle1.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.gpDetalle1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpDetalle1.Style.BorderBottomWidth = 1
        Me.gpDetalle1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.gpDetalle1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpDetalle1.Style.BorderLeftWidth = 1
        Me.gpDetalle1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpDetalle1.Style.BorderRightWidth = 1
        Me.gpDetalle1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpDetalle1.Style.BorderTopWidth = 1
        Me.gpDetalle1.Style.CornerDiameter = 4
        Me.gpDetalle1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.gpDetalle1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.gpDetalle1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.gpDetalle1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.gpDetalle1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.gpDetalle1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.gpDetalle1.TabIndex = 4
        Me.gpDetalle1.Text = "H I S T O R I A L    D E    P R E C I O S"
        '
        'grDetalle
        '
        Me.grDetalle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grDetalle.Location = New System.Drawing.Point(0, 0)
        Me.grDetalle.Margin = New System.Windows.Forms.Padding(4)
        Me.grDetalle.Name = "grDetalle"
        Me.grDetalle.Size = New System.Drawing.Size(401, 203)
        Me.grDetalle.TabIndex = 1
        '
        'cmOpciones
        '
        Me.cmOpciones.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.cmOpciones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnElimFila1})
        Me.cmOpciones.Name = "cmOpciones"
        Me.cmOpciones.Size = New System.Drawing.Size(177, 28)
        '
        'btnElimFila1
        '
        Me.btnElimFila1.Name = "btnElimFila1"
        Me.btnElimFila1.Size = New System.Drawing.Size(176, 24)
        Me.btnElimFila1.Text = "ELIMINAR FILA"
        '
        'tbPrecio
        '
        '
        '
        '
        Me.tbPrecio.Border.Class = "TextBoxBorder"
        Me.tbPrecio.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbPrecio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbPrecio.Location = New System.Drawing.Point(163, 165)
        Me.tbPrecio.Margin = New System.Windows.Forms.Padding(4)
        Me.tbPrecio.Name = "tbPrecio"
        Me.tbPrecio.PreventEnterBeep = True
        Me.tbPrecio.Size = New System.Drawing.Size(133, 26)
        Me.tbPrecio.TabIndex = 3
        '
        'btTipo
        '
        Me.btTipo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btTipo.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat
        Me.btTipo.Image = Global.Presentacion.My.Resources.Resources.NUEVO
        Me.btTipo.ImageFixedSize = New System.Drawing.Size(28, 28)
        Me.btTipo.Location = New System.Drawing.Point(380, 123)
        Me.btTipo.Margin = New System.Windows.Forms.Padding(4)
        Me.btTipo.Name = "btTipo"
        Me.btTipo.Size = New System.Drawing.Size(45, 37)
        Me.btTipo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btTipo.TabIndex = 104
        Me.btTipo.Visible = False
        '
        'gpDetalle2
        '
        Me.gpDetalle2.CanvasColor = System.Drawing.SystemColors.Control
        Me.gpDetalle2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.gpDetalle2.Controls.Add(Me.grDetalle2)
        Me.gpDetalle2.DisabledBackColor = System.Drawing.Color.Empty
        Me.gpDetalle2.Dock = System.Windows.Forms.DockStyle.Right
        Me.gpDetalle2.Location = New System.Drawing.Point(984, 0)
        Me.gpDetalle2.Margin = New System.Windows.Forms.Padding(4)
        Me.gpDetalle2.Name = "gpDetalle2"
        Me.gpDetalle2.Size = New System.Drawing.Size(515, 226)
        '
        '
        '
        Me.gpDetalle2.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.gpDetalle2.Style.BackColorGradientAngle = 90
        Me.gpDetalle2.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.gpDetalle2.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpDetalle2.Style.BorderBottomWidth = 1
        Me.gpDetalle2.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.gpDetalle2.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpDetalle2.Style.BorderLeftWidth = 1
        Me.gpDetalle2.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpDetalle2.Style.BorderRightWidth = 1
        Me.gpDetalle2.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpDetalle2.Style.BorderTopWidth = 1
        Me.gpDetalle2.Style.CornerDiameter = 4
        Me.gpDetalle2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.gpDetalle2.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.gpDetalle2.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.gpDetalle2.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.gpDetalle2.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.gpDetalle2.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.gpDetalle2.TabIndex = 105
        Me.gpDetalle2.Text = "H I S T O R I A L    D E    P R E C I O S"
        '
        'grDetalle2
        '
        Me.grDetalle2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grDetalle2.Location = New System.Drawing.Point(0, 0)
        Me.grDetalle2.Margin = New System.Windows.Forms.Padding(4)
        Me.grDetalle2.Name = "grDetalle2"
        Me.grDetalle2.Size = New System.Drawing.Size(509, 203)
        Me.grDetalle2.TabIndex = 0
        '
        'tbTipoPrecio
        '
        tbTipoPrecio_DesignTimeLayout.LayoutString = resources.GetString("tbTipoPrecio_DesignTimeLayout.LayoutString")
        Me.tbTipoPrecio.DesignTimeLayout = tbTipoPrecio_DesignTimeLayout
        Me.tbTipoPrecio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbTipoPrecio.Location = New System.Drawing.Point(304, 167)
        Me.tbTipoPrecio.Margin = New System.Windows.Forms.Padding(4)
        Me.tbTipoPrecio.Name = "tbTipoPrecio"
        Me.tbTipoPrecio.SelectedIndex = -1
        Me.tbTipoPrecio.SelectedItem = Nothing
        Me.tbTipoPrecio.Size = New System.Drawing.Size(208, 26)
        Me.tbTipoPrecio.TabIndex = 106
        Me.tbTipoPrecio.Visible = False
        '
        'cmOpciones2
        '
        Me.cmOpciones2.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.cmOpciones2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnEliminar2})
        Me.cmOpciones2.Name = "cmOpciones"
        Me.cmOpciones2.Size = New System.Drawing.Size(177, 28)
        '
        'btnEliminar2
        '
        Me.btnEliminar2.Name = "btnEliminar2"
        Me.btnEliminar2.Size = New System.Drawing.Size(176, 24)
        Me.btnEliminar2.Text = "ELIMINAR FILA"
        '
        'LabelX5
        '
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX5.Location = New System.Drawing.Point(31, 194)
        Me.LabelX5.Margin = New System.Windows.Forms.Padding(4)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(100, 28)
        Me.LabelX5.TabIndex = 107
        Me.LabelX5.Text = "SUCURSAL:"
        '
        'cbsucursal
        '
        cbsucursal_DesignTimeLayout.LayoutString = resources.GetString("cbsucursal_DesignTimeLayout.LayoutString")
        Me.cbsucursal.DesignTimeLayout = cbsucursal_DesignTimeLayout
        Me.cbsucursal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbsucursal.Location = New System.Drawing.Point(163, 199)
        Me.cbsucursal.Margin = New System.Windows.Forms.Padding(4)
        Me.cbsucursal.Name = "cbsucursal"
        Me.cbsucursal.SelectedIndex = -1
        Me.cbsucursal.SelectedItem = Nothing
        Me.cbsucursal.Size = New System.Drawing.Size(274, 26)
        Me.cbsucursal.TabIndex = 108
        '
        'F1_Servicio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1906, 690)
        Me.Margin = New System.Windows.Forms.Padding(5)
        Me.Name = "F1_Servicio"
        Me.Text = "F1_Servicio"
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
        CType(Me.tbTipo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpDetalle1.ResumeLayout(False)
        CType(Me.grDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmOpciones.ResumeLayout(False)
        Me.gpDetalle2.ResumeLayout(False)
        CType(Me.grDetalle2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbTipoPrecio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmOpciones2.ResumeLayout(False)
        CType(Me.cbsucursal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tbTipo As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents LabelX16 As DevComponents.DotNetBar.LabelX
    Friend WithEvents tbEstado As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents LabelX15 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents tbDesc As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents tbCodigo As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents tbNumi As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents gpDetalle1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents cmOpciones As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents btnElimFila1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tbPrecio As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents btTipo As DevComponents.DotNetBar.ButtonX
    Friend WithEvents gpDetalle2 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents grDetalle2 As Janus.Windows.GridEX.GridEX
    Friend WithEvents tbTipoPrecio As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents cmOpciones2 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents btnEliminar2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents grDetalle As Janus.Windows.GridEX.GridEX
    Friend WithEvents cbsucursal As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
End Class
