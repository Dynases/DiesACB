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
        Me.SuperTabPrincipal.Size = New System.Drawing.Size(1119, 632)
        Me.SuperTabPrincipal.Controls.SetChildIndex(Me.SuperTabControlPanelBuscador, 0)
        Me.SuperTabPrincipal.Controls.SetChildIndex(Me.SuperTabControlPanelRegistro, 0)
        '
        'SuperTabControlPanelBuscador
        '
        Me.SuperTabControlPanelBuscador.Size = New System.Drawing.Size(884, 607)
        '
        'SuperTabControlPanelRegistro
        '
        Me.SuperTabControlPanelRegistro.Size = New System.Drawing.Size(1119, 607)
        Me.SuperTabControlPanelRegistro.Controls.SetChildIndex(Me.PanelSuperior, 0)
        Me.SuperTabControlPanelRegistro.Controls.SetChildIndex(Me.PanelInferior, 0)
        Me.SuperTabControlPanelRegistro.Controls.SetChildIndex(Me.PanelPrincipal, 0)
        '
        'PanelSuperior
        '
        Me.PanelSuperior.Size = New System.Drawing.Size(1119, 72)
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
        Me.PanelInferior.Location = New System.Drawing.Point(0, 571)
        Me.PanelInferior.Size = New System.Drawing.Size(1119, 36)
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
        Me.PanelToolBar2.Location = New System.Drawing.Point(1039, 0)
        '
        'MPanelSup
        '
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
        Me.MPanelSup.Size = New System.Drawing.Size(1119, 270)
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
        '
        'PanelPrincipal
        '
        Me.PanelPrincipal.Size = New System.Drawing.Size(1119, 499)
        '
        'GroupPanelBuscador
        '
        Me.GroupPanelBuscador.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupPanelBuscador.Location = New System.Drawing.Point(0, 270)
        Me.GroupPanelBuscador.Size = New System.Drawing.Size(1119, 229)
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
        Me.JGrM_Buscador.Office2007ColorScheme = Janus.Windows.GridEX.Office2007ColorScheme.Custom
        Me.JGrM_Buscador.Office2007CustomColor = System.Drawing.Color.DodgerBlue
        Me.JGrM_Buscador.Size = New System.Drawing.Size(1113, 204)
        Me.JGrM_Buscador.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'PanelUsuario
        '
        Me.PanelUsuario.Location = New System.Drawing.Point(844, 6)
        '
        'MPanelUserAct
        '
        Me.MPanelUserAct.Location = New System.Drawing.Point(919, 0)
        '
        'btnImage
        '
        Me.btnImage.BackColor = System.Drawing.Color.White
        Me.btnImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnImage.ForeColor = System.Drawing.Color.Transparent
        Me.btnImage.Image = CType(resources.GetObject("btnImage.Image"), System.Drawing.Image)
        Me.btnImage.Location = New System.Drawing.Point(760, 43)
        Me.btnImage.Name = "btnImage"
        Me.btnImage.Size = New System.Drawing.Size(43, 41)
        Me.btnImage.TabIndex = 9
        Me.btnImage.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.btnImage.UseVisualStyleBackColor = False
        '
        'pbImage
        '
        Me.pbImage.Image = CType(resources.GetObject("pbImage.Image"), System.Drawing.Image)
        Me.pbImage.Location = New System.Drawing.Point(623, 44)
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
        Me.LabelX6.Location = New System.Drawing.Point(545, 43)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(75, 23)
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
        Me.LabelX3.Location = New System.Drawing.Point(31, 79)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(195, 23)
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
        Me.tbcdprod1.Location = New System.Drawing.Point(232, 81)
        Me.tbcdprod1.Name = "tbcdprod1"
        Me.tbcdprod1.PreventEnterBeep = True
        Me.tbcdprod1.Size = New System.Drawing.Size(243, 22)
        Me.tbcdprod1.TabIndex = 2
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX1.Location = New System.Drawing.Point(33, 48)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(57, 23)
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
        Me.tbNumi.Location = New System.Drawing.Point(232, 50)
        Me.tbNumi.Name = "tbNumi"
        Me.tbNumi.PreventEnterBeep = True
        Me.tbNumi.Size = New System.Drawing.Size(57, 22)
        Me.tbNumi.TabIndex = 0
        Me.tbNumi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cbGrupo
        '
        cbGrupo_DesignTimeLayout.LayoutString = resources.GetString("cbGrupo_DesignTimeLayout.LayoutString")
        Me.cbGrupo.DesignTimeLayout = cbGrupo_DesignTimeLayout
        Me.cbGrupo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbGrupo.Location = New System.Drawing.Point(232, 109)
        Me.cbGrupo.Name = "cbGrupo"
        Me.cbGrupo.Office2007ColorScheme = Janus.Windows.GridEX.Office2007ColorScheme.Custom
        Me.cbGrupo.Office2007CustomColor = System.Drawing.Color.DodgerBlue
        Me.cbGrupo.SelectedIndex = -1
        Me.cbGrupo.SelectedItem = Nothing
        Me.cbGrupo.Size = New System.Drawing.Size(156, 22)
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
        Me.LabelX4.Location = New System.Drawing.Point(31, 106)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(59, 23)
        Me.LabelX4.TabIndex = 126
        Me.LabelX4.Text = "GRUPO:"
        '
        'cbUMedida
        '
        cbUMedida_DesignTimeLayout.LayoutString = resources.GetString("cbUMedida_DesignTimeLayout.LayoutString")
        Me.cbUMedida.DesignTimeLayout = cbUMedida_DesignTimeLayout
        Me.cbUMedida.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbUMedida.Location = New System.Drawing.Point(232, 141)
        Me.cbUMedida.Name = "cbUMedida"
        Me.cbUMedida.Office2007ColorScheme = Janus.Windows.GridEX.Office2007ColorScheme.Custom
        Me.cbUMedida.Office2007CustomColor = System.Drawing.Color.DodgerBlue
        Me.cbUMedida.SelectedIndex = -1
        Me.cbUMedida.SelectedItem = Nothing
        Me.cbUMedida.Size = New System.Drawing.Size(156, 22)
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
        Me.LabelX5.Location = New System.Drawing.Point(31, 141)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(133, 23)
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
        Me.LabelX7.Location = New System.Drawing.Point(32, 171)
        Me.LabelX7.Name = "LabelX7"
        Me.LabelX7.Size = New System.Drawing.Size(105, 23)
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
        Me.tbsmin.Location = New System.Drawing.Point(232, 171)
        Me.tbsmin.Name = "tbsmin"
        Me.tbsmin.PreventEnterBeep = True
        Me.tbsmin.Size = New System.Drawing.Size(70, 22)
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
        Me.tbEstado.Location = New System.Drawing.Point(232, 200)
        Me.tbEstado.Name = "tbEstado"
        Me.tbEstado.OffText = "PASIVO"
        Me.tbEstado.OnText = "ACTIVO"
        Me.tbEstado.Size = New System.Drawing.Size(136, 22)
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
        Me.LabelX15.Location = New System.Drawing.Point(32, 199)
        Me.LabelX15.Name = "LabelX15"
        Me.LabelX15.Size = New System.Drawing.Size(62, 23)
        Me.LabelX15.TabIndex = 199
        Me.LabelX15.Text = "ESTADO:"
        '
        'BtnUmed
        '
        Me.BtnUmed.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnUmed.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat
        Me.BtnUmed.Image = Global.Presentacion.My.Resources.Resources.clase_practica
        Me.BtnUmed.ImageFixedSize = New System.Drawing.Size(28, 28)
        Me.BtnUmed.Location = New System.Drawing.Point(392, 138)
        Me.BtnUmed.Name = "BtnUmed"
        Me.BtnUmed.Size = New System.Drawing.Size(34, 29)
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
        Me.BtnGrupo.Location = New System.Drawing.Point(392, 106)
        Me.BtnGrupo.Name = "BtnGrupo"
        Me.BtnGrupo.Size = New System.Drawing.Size(34, 29)
        Me.BtnGrupo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnGrupo.TabIndex = 207
        Me.BtnGrupo.Visible = False
        '
        'F1_Productos_L
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1119, 632)
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
End Class
