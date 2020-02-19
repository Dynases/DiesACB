<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F1_Productos_L
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
        Dim cbGrupo_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cbUMedida_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F1_Productos_L))
        Me.btnImage = New System.Windows.Forms.Button()
        Me.pbImage = New System.Windows.Forms.PictureBox()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.tbcdprod1 = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.tbNumi = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.cbGrupo = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.cbUMedida = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX7 = New DevComponents.DotNetBar.LabelX()
        Me.tbsmin = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.tbEstado = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.LabelX15 = New DevComponents.DotNetBar.LabelX()
        Me.BtnUmed = New DevComponents.DotNetBar.ButtonX()
        Me.BtnGrupo = New DevComponents.DotNetBar.ButtonX()
        Me.tbprecioCompra = New DevComponents.Editors.DoubleInput()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX8 = New DevComponents.DotNetBar.LabelX()
        Me.tbprecioVenta = New DevComponents.Editors.DoubleInput()
        Me.LabelX9 = New DevComponents.DotNetBar.LabelX()
        Me.tbPrecioSocios = New DevComponents.Editors.DoubleInput()
        Me.LabelX10 = New DevComponents.DotNetBar.LabelX()
        Me.tbPrecioInternos = New DevComponents.Editors.DoubleInput()
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
        CType(Me.pbImage, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbGrupo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbUMedida, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbprecioCompra, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbprecioVenta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbPrecioSocios, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbPrecioInternos, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.SuperTabPrincipal.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.SuperTabPrincipal.Size = New System.Drawing.Size(1492, 778)
        Me.SuperTabPrincipal.Controls.SetChildIndex(Me.SuperTabControlPanelBuscador, 0)
        Me.SuperTabPrincipal.Controls.SetChildIndex(Me.SuperTabControlPanelRegistro, 0)
        '
        'SuperTabControlPanelBuscador
        '
        Me.SuperTabControlPanelBuscador.Location = New System.Drawing.Point(0, 28)
        Me.SuperTabControlPanelBuscador.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.SuperTabControlPanelBuscador.Size = New System.Drawing.Size(1179, 747)
        '
        'SuperTabControlPanelRegistro
        '
        Me.SuperTabControlPanelRegistro.Location = New System.Drawing.Point(0, 28)
        Me.SuperTabControlPanelRegistro.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.SuperTabControlPanelRegistro.Size = New System.Drawing.Size(1492, 750)
        Me.SuperTabControlPanelRegistro.Controls.SetChildIndex(Me.PanelSuperior, 0)
        Me.SuperTabControlPanelRegistro.Controls.SetChildIndex(Me.PanelInferior, 0)
        Me.SuperTabControlPanelRegistro.Controls.SetChildIndex(Me.PanelPrincipal, 0)
        '
        'PanelSuperior
        '
        Me.PanelSuperior.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.PanelSuperior.Size = New System.Drawing.Size(1492, 89)
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
        Me.PanelInferior.Location = New System.Drawing.Point(0, 706)
        Me.PanelInferior.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.PanelInferior.Size = New System.Drawing.Size(1492, 44)
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
        'PanelToolBar2
        '
        Me.PanelToolBar2.Location = New System.Drawing.Point(1385, 0)
        Me.PanelToolBar2.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        '
        'MPanelSup
        '
        Me.MPanelSup.Controls.Add(Me.LabelX10)
        Me.MPanelSup.Controls.Add(Me.tbPrecioInternos)
        Me.MPanelSup.Controls.Add(Me.LabelX9)
        Me.MPanelSup.Controls.Add(Me.tbPrecioSocios)
        Me.MPanelSup.Controls.Add(Me.LabelX8)
        Me.MPanelSup.Controls.Add(Me.tbprecioVenta)
        Me.MPanelSup.Controls.Add(Me.LabelX2)
        Me.MPanelSup.Controls.Add(Me.tbprecioCompra)
        Me.MPanelSup.Controls.Add(Me.BtnUmed)
        Me.MPanelSup.Controls.Add(Me.BtnGrupo)
        Me.MPanelSup.Controls.Add(Me.tbEstado)
        Me.MPanelSup.Controls.Add(Me.LabelX15)
        Me.MPanelSup.Controls.Add(Me.LabelX7)
        Me.MPanelSup.Controls.Add(Me.tbsmin)
        Me.MPanelSup.Controls.Add(Me.cbUMedida)
        Me.MPanelSup.Controls.Add(Me.LabelX5)
        Me.MPanelSup.Controls.Add(Me.cbGrupo)
        Me.MPanelSup.Controls.Add(Me.LabelX4)
        Me.MPanelSup.Controls.Add(Me.btnImage)
        Me.MPanelSup.Controls.Add(Me.pbImage)
        Me.MPanelSup.Controls.Add(Me.LabelX6)
        Me.MPanelSup.Controls.Add(Me.LabelX3)
        Me.MPanelSup.Controls.Add(Me.tbcdprod1)
        Me.MPanelSup.Controls.Add(Me.LabelX1)
        Me.MPanelSup.Controls.Add(Me.tbNumi)
        Me.MPanelSup.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.MPanelSup.Size = New System.Drawing.Size(1492, 332)
        Me.MPanelSup.Controls.SetChildIndex(Me.tbNumi, 0)
        Me.MPanelSup.Controls.SetChildIndex(Me.LabelX1, 0)
        Me.MPanelSup.Controls.SetChildIndex(Me.tbcdprod1, 0)
        Me.MPanelSup.Controls.SetChildIndex(Me.LabelX3, 0)
        Me.MPanelSup.Controls.SetChildIndex(Me.LabelX6, 0)
        Me.MPanelSup.Controls.SetChildIndex(Me.pbImage, 0)
        Me.MPanelSup.Controls.SetChildIndex(Me.btnImage, 0)
        Me.MPanelSup.Controls.SetChildIndex(Me.LabelX4, 0)
        Me.MPanelSup.Controls.SetChildIndex(Me.cbGrupo, 0)
        Me.MPanelSup.Controls.SetChildIndex(Me.LabelX5, 0)
        Me.MPanelSup.Controls.SetChildIndex(Me.cbUMedida, 0)
        Me.MPanelSup.Controls.SetChildIndex(Me.tbsmin, 0)
        Me.MPanelSup.Controls.SetChildIndex(Me.LabelX7, 0)
        Me.MPanelSup.Controls.SetChildIndex(Me.LabelX15, 0)
        Me.MPanelSup.Controls.SetChildIndex(Me.tbEstado, 0)
        Me.MPanelSup.Controls.SetChildIndex(Me.PanelUsuario, 0)
        Me.MPanelSup.Controls.SetChildIndex(Me.BtnGrupo, 0)
        Me.MPanelSup.Controls.SetChildIndex(Me.BtnUmed, 0)
        Me.MPanelSup.Controls.SetChildIndex(Me.tbprecioCompra, 0)
        Me.MPanelSup.Controls.SetChildIndex(Me.LabelX2, 0)
        Me.MPanelSup.Controls.SetChildIndex(Me.tbprecioVenta, 0)
        Me.MPanelSup.Controls.SetChildIndex(Me.LabelX8, 0)
        Me.MPanelSup.Controls.SetChildIndex(Me.tbPrecioSocios, 0)
        Me.MPanelSup.Controls.SetChildIndex(Me.LabelX9, 0)
        Me.MPanelSup.Controls.SetChildIndex(Me.tbPrecioInternos, 0)
        Me.MPanelSup.Controls.SetChildIndex(Me.LabelX10, 0)
        '
        'PanelPrincipal
        '
        Me.PanelPrincipal.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.PanelPrincipal.Size = New System.Drawing.Size(1492, 617)
        '
        'GroupPanelBuscador
        '
        Me.GroupPanelBuscador.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupPanelBuscador.Location = New System.Drawing.Point(0, 332)
        Me.GroupPanelBuscador.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.GroupPanelBuscador.Size = New System.Drawing.Size(1492, 285)
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
        Me.JGrM_Buscador.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.JGrM_Buscador.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.JGrM_Buscador.Office2007ColorScheme = Janus.Windows.GridEX.Office2007ColorScheme.Custom
        Me.JGrM_Buscador.Office2007CustomColor = System.Drawing.Color.DodgerBlue
        Me.JGrM_Buscador.Size = New System.Drawing.Size(1486, 256)
        Me.JGrM_Buscador.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'PanelUsuario
        '
        Me.PanelUsuario.Location = New System.Drawing.Point(1125, 7)
        Me.PanelUsuario.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        '
        'btnUltimo
        '
        Me.btnUltimo.Location = New System.Drawing.Point(171, 0)
        '
        'MPanelUserAct
        '
        Me.MPanelUserAct.Location = New System.Drawing.Point(1225, 0)
        Me.MPanelUserAct.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        '
        'btnImage
        '
        Me.btnImage.BackColor = System.Drawing.Color.White
        Me.btnImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnImage.ForeColor = System.Drawing.Color.Transparent
        Me.btnImage.Image = CType(resources.GetObject("btnImage.Image"), System.Drawing.Image)
        Me.btnImage.Location = New System.Drawing.Point(1013, 53)
        Me.btnImage.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnImage.Name = "btnImage"
        Me.btnImage.Size = New System.Drawing.Size(57, 50)
        Me.btnImage.TabIndex = 9
        Me.btnImage.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.btnImage.UseVisualStyleBackColor = False
        '
        'pbImage
        '
        Me.pbImage.Image = CType(resources.GetObject("pbImage.Image"), System.Drawing.Image)
        Me.pbImage.Location = New System.Drawing.Point(831, 54)
        Me.pbImage.Margin = New System.Windows.Forms.Padding(0)
        Me.pbImage.Name = "pbImage"
        Me.pbImage.Size = New System.Drawing.Size(180, 157)
        Me.pbImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.pbImage.TabIndex = 123
        Me.pbImage.TabStop = False
        '
        'LabelX6
        '
        '
        '
        '
        Me.LabelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX6.Location = New System.Drawing.Point(727, 53)
        Me.LabelX6.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(100, 28)
        Me.LabelX6.TabIndex = 122
        Me.LabelX6.Text = "IMAGEN:"
        '
        'LabelX3
        '
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX3.Location = New System.Drawing.Point(35, 48)
        Me.LabelX3.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(260, 28)
        Me.LabelX3.TabIndex = 121
        Me.LabelX3.Text = "DESCRIPCION DE PRODUCTO:"
        '
        'tbcdprod1
        '
        '
        '
        '
        Me.tbcdprod1.Border.Class = "TextBoxBorder"
        Me.tbcdprod1.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbcdprod1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbcdprod1.Location = New System.Drawing.Point(303, 51)
        Me.tbcdprod1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.tbcdprod1.Name = "tbcdprod1"
        Me.tbcdprod1.PreventEnterBeep = True
        Me.tbcdprod1.Size = New System.Drawing.Size(324, 26)
        Me.tbcdprod1.TabIndex = 2
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX1.Location = New System.Drawing.Point(38, 10)
        Me.LabelX1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(76, 28)
        Me.LabelX1.TabIndex = 119
        Me.LabelX1.Text = "CODIGO:"
        '
        'tbNumi
        '
        '
        '
        '
        Me.tbNumi.Border.Class = "TextBoxBorder"
        Me.tbNumi.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbNumi.Enabled = False
        Me.tbNumi.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbNumi.Location = New System.Drawing.Point(303, 13)
        Me.tbNumi.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.tbNumi.Name = "tbNumi"
        Me.tbNumi.PreventEnterBeep = True
        Me.tbNumi.Size = New System.Drawing.Size(76, 26)
        Me.tbNumi.TabIndex = 0
        Me.tbNumi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cbGrupo
        '
        cbGrupo_DesignTimeLayout.LayoutString = resources.GetString("cbGrupo_DesignTimeLayout.LayoutString")
        Me.cbGrupo.DesignTimeLayout = cbGrupo_DesignTimeLayout
        Me.cbGrupo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbGrupo.Location = New System.Drawing.Point(303, 85)
        Me.cbGrupo.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cbGrupo.Name = "cbGrupo"
        Me.cbGrupo.Office2007ColorScheme = Janus.Windows.GridEX.Office2007ColorScheme.Custom
        Me.cbGrupo.Office2007CustomColor = System.Drawing.Color.DodgerBlue
        Me.cbGrupo.SelectedIndex = -1
        Me.cbGrupo.SelectedItem = Nothing
        Me.cbGrupo.Size = New System.Drawing.Size(208, 26)
        Me.cbGrupo.TabIndex = 5
        Me.cbGrupo.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.cbGrupo.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'LabelX4
        '
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX4.Location = New System.Drawing.Point(35, 81)
        Me.LabelX4.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(79, 28)
        Me.LabelX4.TabIndex = 126
        Me.LabelX4.Text = "GRUPO:"
        '
        'cbUMedida
        '
        cbUMedida_DesignTimeLayout.LayoutString = resources.GetString("cbUMedida_DesignTimeLayout.LayoutString")
        Me.cbUMedida.DesignTimeLayout = cbUMedida_DesignTimeLayout
        Me.cbUMedida.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbUMedida.Location = New System.Drawing.Point(303, 125)
        Me.cbUMedida.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cbUMedida.Name = "cbUMedida"
        Me.cbUMedida.Office2007ColorScheme = Janus.Windows.GridEX.Office2007ColorScheme.Custom
        Me.cbUMedida.Office2007CustomColor = System.Drawing.Color.DodgerBlue
        Me.cbUMedida.SelectedIndex = -1
        Me.cbUMedida.SelectedItem = Nothing
        Me.cbUMedida.Size = New System.Drawing.Size(208, 26)
        Me.cbUMedida.TabIndex = 6
        Me.cbUMedida.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.cbUMedida.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'LabelX5
        '
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX5.Location = New System.Drawing.Point(35, 125)
        Me.LabelX5.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(177, 28)
        Me.LabelX5.TabIndex = 128
        Me.LabelX5.Text = "UNIDAD DE MEDIDA:"
        '
        'LabelX7
        '
        '
        '
        '
        Me.LabelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX7.Location = New System.Drawing.Point(37, 161)
        Me.LabelX7.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.LabelX7.Name = "LabelX7"
        Me.LabelX7.Size = New System.Drawing.Size(140, 28)
        Me.LabelX7.TabIndex = 130
        Me.LabelX7.Text = "STOCK MINIMO:"
        '
        'tbsmin
        '
        '
        '
        '
        Me.tbsmin.Border.Class = "TextBoxBorder"
        Me.tbsmin.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbsmin.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbsmin.Location = New System.Drawing.Point(303, 161)
        Me.tbsmin.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.tbsmin.Name = "tbsmin"
        Me.tbsmin.PreventEnterBeep = True
        Me.tbsmin.Size = New System.Drawing.Size(93, 26)
        Me.tbsmin.TabIndex = 7
        Me.tbsmin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbEstado
        '
        '
        '
        '
        Me.tbEstado.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbEstado.Location = New System.Drawing.Point(303, 197)
        Me.tbEstado.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.tbEstado.Name = "tbEstado"
        Me.tbEstado.OffText = "PASIVO"
        Me.tbEstado.OnText = "ACTIVO"
        Me.tbEstado.Size = New System.Drawing.Size(181, 27)
        Me.tbEstado.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.tbEstado.TabIndex = 8
        Me.tbEstado.Value = True
        Me.tbEstado.ValueObject = "Y"
        '
        'LabelX15
        '
        '
        '
        '
        Me.LabelX15.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX15.Location = New System.Drawing.Point(37, 196)
        Me.LabelX15.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.LabelX15.Name = "LabelX15"
        Me.LabelX15.Size = New System.Drawing.Size(83, 28)
        Me.LabelX15.TabIndex = 199
        Me.LabelX15.Text = "ESTADO:"
        '
        'BtnUmed
        '
        Me.BtnUmed.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnUmed.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat
        Me.BtnUmed.Image = Global.Presentacion.My.Resources.Resources.clase_practica
        Me.BtnUmed.ImageFixedSize = New System.Drawing.Size(28, 28)
        Me.BtnUmed.Location = New System.Drawing.Point(523, 170)
        Me.BtnUmed.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BtnUmed.Name = "BtnUmed"
        Me.BtnUmed.Size = New System.Drawing.Size(45, 36)
        Me.BtnUmed.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnUmed.TabIndex = 206
        Me.BtnUmed.Visible = False
        '
        'BtnGrupo
        '
        Me.BtnGrupo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnGrupo.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat
        Me.BtnGrupo.Image = Global.Presentacion.My.Resources.Resources.clase_practica
        Me.BtnGrupo.ImageFixedSize = New System.Drawing.Size(28, 28)
        Me.BtnGrupo.Location = New System.Drawing.Point(523, 130)
        Me.BtnGrupo.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BtnGrupo.Name = "BtnGrupo"
        Me.BtnGrupo.Size = New System.Drawing.Size(45, 36)
        Me.BtnGrupo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnGrupo.TabIndex = 207
        Me.BtnGrupo.Visible = False
        '
        'tbprecioCompra
        '
        '
        '
        '
        Me.tbprecioCompra.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.tbprecioCompra.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbprecioCompra.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.tbprecioCompra.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbprecioCompra.ForeColor = System.Drawing.Color.Black
        Me.tbprecioCompra.Increment = 1.0R
        Me.tbprecioCompra.Location = New System.Drawing.Point(303, 232)
        Me.tbprecioCompra.Margin = New System.Windows.Forms.Padding(4)
        Me.tbprecioCompra.MinValue = 0R
        Me.tbprecioCompra.Name = "tbprecioCompra"
        Me.tbprecioCompra.Size = New System.Drawing.Size(147, 30)
        Me.tbprecioCompra.TabIndex = 208
        Me.tbprecioCompra.WatermarkAlignment = DevComponents.Editors.eTextAlignment.Right
        '
        'LabelX2
        '
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX2.Location = New System.Drawing.Point(38, 232)
        Me.LabelX2.Margin = New System.Windows.Forms.Padding(4)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(174, 28)
        Me.LabelX2.TabIndex = 209
        Me.LabelX2.Text = "PRECIO COMPRA:"
        '
        'LabelX8
        '
        '
        '
        '
        Me.LabelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX8.Location = New System.Drawing.Point(38, 270)
        Me.LabelX8.Margin = New System.Windows.Forms.Padding(4)
        Me.LabelX8.Name = "LabelX8"
        Me.LabelX8.Size = New System.Drawing.Size(219, 28)
        Me.LabelX8.TabIndex = 211
        Me.LabelX8.Text = "PRECIO VENTA CLIENTES:"
        '
        'tbprecioVenta
        '
        '
        '
        '
        Me.tbprecioVenta.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.tbprecioVenta.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbprecioVenta.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.tbprecioVenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbprecioVenta.ForeColor = System.Drawing.Color.Black
        Me.tbprecioVenta.Increment = 1.0R
        Me.tbprecioVenta.Location = New System.Drawing.Point(303, 270)
        Me.tbprecioVenta.Margin = New System.Windows.Forms.Padding(4)
        Me.tbprecioVenta.MinValue = 0R
        Me.tbprecioVenta.Name = "tbprecioVenta"
        Me.tbprecioVenta.Size = New System.Drawing.Size(147, 30)
        Me.tbprecioVenta.TabIndex = 210
        Me.tbprecioVenta.WatermarkAlignment = DevComponents.Editors.eTextAlignment.Right
        '
        'LabelX9
        '
        '
        '
        '
        Me.LabelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX9.Location = New System.Drawing.Point(475, 232)
        Me.LabelX9.Margin = New System.Windows.Forms.Padding(4)
        Me.LabelX9.Name = "LabelX9"
        Me.LabelX9.Size = New System.Drawing.Size(219, 28)
        Me.LabelX9.TabIndex = 213
        Me.LabelX9.Text = "PRECIO VENTA SOCIOS:"
        '
        'tbPrecioSocios
        '
        '
        '
        '
        Me.tbPrecioSocios.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.tbPrecioSocios.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbPrecioSocios.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.tbPrecioSocios.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbPrecioSocios.ForeColor = System.Drawing.Color.Black
        Me.tbPrecioSocios.Increment = 1.0R
        Me.tbPrecioSocios.Location = New System.Drawing.Point(740, 232)
        Me.tbPrecioSocios.Margin = New System.Windows.Forms.Padding(4)
        Me.tbPrecioSocios.MinValue = 0R
        Me.tbPrecioSocios.Name = "tbPrecioSocios"
        Me.tbPrecioSocios.Size = New System.Drawing.Size(147, 30)
        Me.tbPrecioSocios.TabIndex = 212
        Me.tbPrecioSocios.WatermarkAlignment = DevComponents.Editors.eTextAlignment.Right
        '
        'LabelX10
        '
        '
        '
        '
        Me.LabelX10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX10.Location = New System.Drawing.Point(475, 268)
        Me.LabelX10.Margin = New System.Windows.Forms.Padding(4)
        Me.LabelX10.Name = "LabelX10"
        Me.LabelX10.Size = New System.Drawing.Size(219, 28)
        Me.LabelX10.TabIndex = 215
        Me.LabelX10.Text = "PRECIO VENTA INTERNOS:"
        '
        'tbPrecioInternos
        '
        '
        '
        '
        Me.tbPrecioInternos.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.tbPrecioInternos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbPrecioInternos.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.tbPrecioInternos.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbPrecioInternos.ForeColor = System.Drawing.Color.Black
        Me.tbPrecioInternos.Increment = 1.0R
        Me.tbPrecioInternos.Location = New System.Drawing.Point(740, 268)
        Me.tbPrecioInternos.Margin = New System.Windows.Forms.Padding(4)
        Me.tbPrecioInternos.MinValue = 0R
        Me.tbPrecioInternos.Name = "tbPrecioInternos"
        Me.tbPrecioInternos.Size = New System.Drawing.Size(147, 30)
        Me.tbPrecioInternos.TabIndex = 214
        Me.tbPrecioInternos.WatermarkAlignment = DevComponents.Editors.eTextAlignment.Right
        '
        'F1_Productos_L
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1492, 778)
        Me.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.Name = "F1_Productos_L"
        Me.Text = "F1_Productos_L"
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
        CType(Me.pbImage, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbGrupo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbUMedida, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbprecioCompra, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbprecioVenta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbPrecioSocios, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbPrecioInternos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnImage As System.Windows.Forms.Button
    Protected Friend WithEvents pbImage As System.Windows.Forms.PictureBox
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents tbcdprod1 As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents tbNumi As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX7 As DevComponents.DotNetBar.LabelX
    Friend WithEvents tbsmin As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents cbUMedida As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents cbGrupo As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents tbEstado As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents LabelX15 As DevComponents.DotNetBar.LabelX
    Friend WithEvents BtnUmed As DevComponents.DotNetBar.ButtonX
    Friend WithEvents BtnGrupo As DevComponents.DotNetBar.ButtonX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents tbprecioCompra As DevComponents.Editors.DoubleInput
    Friend WithEvents LabelX8 As DevComponents.DotNetBar.LabelX
    Friend WithEvents tbprecioVenta As DevComponents.Editors.DoubleInput
    Friend WithEvents LabelX10 As DevComponents.DotNetBar.LabelX
    Friend WithEvents tbPrecioInternos As DevComponents.Editors.DoubleInput
    Friend WithEvents LabelX9 As DevComponents.DotNetBar.LabelX
    Friend WithEvents tbPrecioSocios As DevComponents.Editors.DoubleInput
End Class
