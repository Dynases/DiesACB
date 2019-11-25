<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F0_Movimiento
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
        Me.components = New System.ComponentModel.Container()
        Dim DgjDetalle_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F0_Movimiento))
        Dim JCb_Concepto_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim JCb_Prod_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.GroupPanel2 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.DgjDetalle = New Janus.Windows.GridEX.GridEX()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.Tb_Id = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Rb_Inac = New System.Windows.Forms.RadioButton()
        Me.Rb_Act = New System.Windows.Forms.RadioButton()
        Me.Tb_Observacion = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.Tb_CodConcepto = New System.Windows.Forms.TextBox()
        Me.JCb_Concepto = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Bt_AyudaNuevo = New System.Windows.Forms.Button()
        Me.Tb_Fecha = New System.Windows.Forms.DateTimePicker()
        Me.JCb_Prod = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.CmDetalleMov = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.QuitarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
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
        Me.TableLayoutPanel1.SuspendLayout()
        Me.GroupPanel2.SuspendLayout()
        CType(Me.DgjDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.JCb_Concepto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.JCb_Prod, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CmDetalleMov.SuspendLayout()
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
        Me.SuperTabControlPanelRegistro.Controls.SetChildIndex(Me.PanelSuperior, 0)
        Me.SuperTabControlPanelRegistro.Controls.SetChildIndex(Me.PanelInferior, 0)
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
        'btnGrabar
        '
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
        'PanelPrincipal
        '
        Me.PanelPrincipal.Controls.Add(Me.TableLayoutPanel1)
        Me.PanelPrincipal.Controls.SetChildIndex(Me.PanelUsuario, 0)
        Me.PanelPrincipal.Controls.SetChildIndex(Me.TableLayoutPanel1, 0)
        '
        'btnUltimo
        '
        '
        'btnSiguiente
        '
        '
        'btnAnterior
        '
        '
        'btnPrimero
        '
        '
        'MRlAccion
        '
        '
        '
        '
        Me.MRlAccion.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.GroupPanel2, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.GroupPanel1, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 55.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(884, 428)
        Me.TableLayoutPanel1.TabIndex = 20
        '
        'GroupPanel2
        '
        Me.GroupPanel2.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel2.Controls.Add(Me.DgjDetalle)
        Me.GroupPanel2.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupPanel2.Location = New System.Drawing.Point(3, 195)
        Me.GroupPanel2.Name = "GroupPanel2"
        Me.GroupPanel2.Size = New System.Drawing.Size(878, 230)
        '
        '
        '
        Me.GroupPanel2.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GroupPanel2.Style.BackColorGradientAngle = 90
        Me.GroupPanel2.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.GroupPanel2.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderBottomWidth = 1
        Me.GroupPanel2.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanel2.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderLeftWidth = 1
        Me.GroupPanel2.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderRightWidth = 1
        Me.GroupPanel2.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderTopWidth = 1
        Me.GroupPanel2.Style.CornerDiameter = 4
        Me.GroupPanel2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel2.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel2.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanel2.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanel2.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel2.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel2.TabIndex = 1
        Me.GroupPanel2.Text = "Detalle"
        '
        'DgjDetalle
        '
        Me.DgjDetalle.ContextMenuStrip = Me.CmDetalleMov
        DgjDetalle_DesignTimeLayout.LayoutString = resources.GetString("DgjDetalle_DesignTimeLayout.LayoutString")
        Me.DgjDetalle.DesignTimeLayout = DgjDetalle_DesignTimeLayout
        Me.DgjDetalle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgjDetalle.Enabled = False
        Me.DgjDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DgjDetalle.Location = New System.Drawing.Point(0, 0)
        Me.DgjDetalle.Name = "DgjDetalle"
        Me.DgjDetalle.Size = New System.Drawing.Size(872, 209)
        Me.DgjDetalle.TabIndex = 5
        '
        'GroupPanel1
        '
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.LabelX3)
        Me.GroupPanel1.Controls.Add(Me.LabelX2)
        Me.GroupPanel1.Controls.Add(Me.LabelX1)
        Me.GroupPanel1.Controls.Add(Me.Tb_Id)
        Me.GroupPanel1.Controls.Add(Me.GroupBox2)
        Me.GroupPanel1.Controls.Add(Me.Tb_Observacion)
        Me.GroupPanel1.Controls.Add(Me.GroupBox1)
        Me.GroupPanel1.Controls.Add(Me.Tb_Fecha)
        Me.GroupPanel1.Controls.Add(Me.JCb_Prod)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupPanel1.Location = New System.Drawing.Point(3, 3)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(878, 186)
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
        Me.GroupPanel1.TabIndex = 0
        Me.GroupPanel1.Text = "Datos"
        '
        'LabelX3
        '
        Me.LabelX3.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX3.ForeColor = System.Drawing.SystemColors.WindowText
        Me.LabelX3.Location = New System.Drawing.Point(6, 61)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(100, 23)
        Me.LabelX3.TabIndex = 115
        Me.LabelX3.Text = "Observación:"
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.LabelX2.Location = New System.Drawing.Point(6, 32)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(100, 23)
        Me.LabelX2.TabIndex = 114
        Me.LabelX2.Text = "Fecha:"
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.LabelX1.Location = New System.Drawing.Point(6, 3)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(100, 23)
        Me.LabelX1.TabIndex = 113
        Me.LabelX1.Text = "Código Interno:"
        '
        'Tb_Id
        '
        Me.Tb_Id.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tb_Id.Location = New System.Drawing.Point(111, 3)
        Me.Tb_Id.Margin = New System.Windows.Forms.Padding(2)
        Me.Tb_Id.Name = "Tb_Id"
        Me.Tb_Id.ReadOnly = True
        Me.Tb_Id.Size = New System.Drawing.Size(100, 23)
        Me.Tb_Id.TabIndex = 104
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.Rb_Inac)
        Me.GroupBox2.Controls.Add(Me.Rb_Act)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(219, 90)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox2.Size = New System.Drawing.Size(142, 73)
        Me.GroupBox2.TabIndex = 109
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Estado"
        Me.GroupBox2.Visible = False
        '
        'Rb_Inac
        '
        Me.Rb_Inac.AutoSize = True
        Me.Rb_Inac.Checked = True
        Me.Rb_Inac.Enabled = False
        Me.Rb_Inac.Location = New System.Drawing.Point(4, 41)
        Me.Rb_Inac.Margin = New System.Windows.Forms.Padding(2)
        Me.Rb_Inac.Name = "Rb_Inac"
        Me.Rb_Inac.Size = New System.Drawing.Size(74, 21)
        Me.Rb_Inac.TabIndex = 10
        Me.Rb_Inac.TabStop = True
        Me.Rb_Inac.Text = "Inactivo"
        Me.Rb_Inac.UseVisualStyleBackColor = True
        '
        'Rb_Act
        '
        Me.Rb_Act.AutoSize = True
        Me.Rb_Act.Enabled = False
        Me.Rb_Act.Location = New System.Drawing.Point(4, 16)
        Me.Rb_Act.Margin = New System.Windows.Forms.Padding(2)
        Me.Rb_Act.Name = "Rb_Act"
        Me.Rb_Act.Size = New System.Drawing.Size(64, 21)
        Me.Rb_Act.TabIndex = 2
        Me.Rb_Act.Text = "Activo"
        Me.Rb_Act.UseVisualStyleBackColor = True
        '
        'Tb_Observacion
        '
        Me.Tb_Observacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Tb_Observacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tb_Observacion.Location = New System.Drawing.Point(111, 61)
        Me.Tb_Observacion.Margin = New System.Windows.Forms.Padding(2)
        Me.Tb_Observacion.MaxLength = 40
        Me.Tb_Observacion.Name = "Tb_Observacion"
        Me.Tb_Observacion.ReadOnly = True
        Me.Tb_Observacion.Size = New System.Drawing.Size(450, 23)
        Me.Tb_Observacion.TabIndex = 106
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.LabelX4)
        Me.GroupBox1.Controls.Add(Me.Tb_CodConcepto)
        Me.GroupBox1.Controls.Add(Me.JCb_Concepto)
        Me.GroupBox1.Controls.Add(Me.Bt_AyudaNuevo)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(6, 90)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(208, 73)
        Me.GroupBox1.TabIndex = 108
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Concepto"
        '
        'LabelX4
        '
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX4.ForeColor = System.Drawing.SystemColors.WindowText
        Me.LabelX4.Location = New System.Drawing.Point(6, 18)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(30, 23)
        Me.LabelX4.TabIndex = 116
        Me.LabelX4.Text = "Cod."
        '
        'Tb_CodConcepto
        '
        Me.Tb_CodConcepto.Location = New System.Drawing.Point(42, 18)
        Me.Tb_CodConcepto.Name = "Tb_CodConcepto"
        Me.Tb_CodConcepto.ReadOnly = True
        Me.Tb_CodConcepto.Size = New System.Drawing.Size(100, 23)
        Me.Tb_CodConcepto.TabIndex = 1
        '
        'JCb_Concepto
        '
        JCb_Concepto_DesignTimeLayout.LayoutString = resources.GetString("JCb_Concepto_DesignTimeLayout.LayoutString")
        Me.JCb_Concepto.DesignTimeLayout = JCb_Concepto_DesignTimeLayout
        Me.JCb_Concepto.Enabled = False
        Me.JCb_Concepto.Location = New System.Drawing.Point(6, 44)
        Me.JCb_Concepto.Name = "JCb_Concepto"
        Me.JCb_Concepto.SelectedIndex = -1
        Me.JCb_Concepto.SelectedItem = Nothing
        Me.JCb_Concepto.Size = New System.Drawing.Size(137, 23)
        Me.JCb_Concepto.TabIndex = 0
        '
        'Bt_AyudaNuevo
        '
        Me.Bt_AyudaNuevo.BackgroundImage = CType(resources.GetObject("Bt_AyudaNuevo.BackgroundImage"), System.Drawing.Image)
        Me.Bt_AyudaNuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Bt_AyudaNuevo.Location = New System.Drawing.Point(153, 18)
        Me.Bt_AyudaNuevo.Margin = New System.Windows.Forms.Padding(2)
        Me.Bt_AyudaNuevo.Name = "Bt_AyudaNuevo"
        Me.Bt_AyudaNuevo.Size = New System.Drawing.Size(44, 51)
        Me.Bt_AyudaNuevo.TabIndex = 2
        Me.Bt_AyudaNuevo.UseVisualStyleBackColor = True
        '
        'Tb_Fecha
        '
        Me.Tb_Fecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tb_Fecha.Location = New System.Drawing.Point(111, 32)
        Me.Tb_Fecha.Name = "Tb_Fecha"
        Me.Tb_Fecha.Size = New System.Drawing.Size(250, 23)
        Me.Tb_Fecha.TabIndex = 105
        '
        'JCb_Prod
        '
        JCb_Prod_DesignTimeLayout.LayoutString = resources.GetString("JCb_Prod_DesignTimeLayout.LayoutString")
        Me.JCb_Prod.DesignTimeLayout = JCb_Prod_DesignTimeLayout
        Me.JCb_Prod.Enabled = False
        Me.JCb_Prod.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.JCb_Prod.Location = New System.Drawing.Point(366, 90)
        Me.JCb_Prod.Name = "JCb_Prod"
        Me.JCb_Prod.SelectedIndex = -1
        Me.JCb_Prod.SelectedItem = Nothing
        Me.JCb_Prod.Size = New System.Drawing.Size(121, 23)
        Me.JCb_Prod.TabIndex = 107
        Me.JCb_Prod.Visible = False
        '
        'CmDetalleMov
        '
        Me.CmDetalleMov.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.QuitarToolStripMenuItem})
        Me.CmDetalleMov.Name = "CmDetalleMov"
        Me.CmDetalleMov.Size = New System.Drawing.Size(122, 40)
        '
        'QuitarToolStripMenuItem
        '
        Me.QuitarToolStripMenuItem.Image = Global.Presentacion.My.Resources.Resources.MENU_QUITAR
        Me.QuitarToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.QuitarToolStripMenuItem.Name = "QuitarToolStripMenuItem"
        Me.QuitarToolStripMenuItem.Size = New System.Drawing.Size(121, 36)
        Me.QuitarToolStripMenuItem.Text = "Quitar"
        '
        'F0_Movimiento
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(884, 561)
        Me.Name = "F0_Movimiento"
        Me.Text = "F0_Movimiento"
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
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.GroupPanel2.ResumeLayout(False)
        CType(Me.DgjDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel1.ResumeLayout(False)
        Me.GroupPanel1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.JCb_Concepto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.JCb_Prod, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CmDetalleMov.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents GroupPanel2 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Tb_Id As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Rb_Inac As System.Windows.Forms.RadioButton
    Friend WithEvents Rb_Act As System.Windows.Forms.RadioButton
    Friend WithEvents Tb_Observacion As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Tb_CodConcepto As System.Windows.Forms.TextBox
    Friend WithEvents JCb_Concepto As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Bt_AyudaNuevo As System.Windows.Forms.Button
    Friend WithEvents Tb_Fecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents JCb_Prod As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents DgjDetalle As Janus.Windows.GridEX.GridEX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents CmDetalleMov As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents QuitarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
