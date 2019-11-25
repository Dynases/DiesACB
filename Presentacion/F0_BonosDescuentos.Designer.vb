<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F0_BonosDescuentos
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
        Dim mcBonoDesc_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F0_BonosDescuentos))
        Dim JMc_Persona_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.JGr_Detalle = New Janus.Windows.GridEX.GridEX()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.mcBonoDesc = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.GroupPanel2 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Tb_SaldoSueldo = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Tb_BonoDesc = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX7 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.Tb_descFijos = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Tb_Sueldo = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX8 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        Me.Tb_Mes = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.Tb_Anio = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Tb_id = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.JMc_Persona = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.GroupPanel3 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.JGr_Buscador = New Janus.Windows.GridEX.GridEX()
        Me.PanelEx6 = New DevComponents.DotNetBar.PanelEx()
        Me.ButtonX1 = New DevComponents.DotNetBar.ButtonX()
        Me.btnMostrarTodos = New DevComponents.DotNetBar.ButtonX()
        CType(Me.SuperTabPrincipal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuperTabPrincipal.SuspendLayout()
        Me.SuperTabControlPanelBuscador.SuspendLayout()
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
        CType(Me.JGr_Detalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.mcBonoDesc, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel2.SuspendLayout()
        CType(Me.JMc_Persona, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel3.SuspendLayout()
        CType(Me.JGr_Buscador, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelEx6.SuspendLayout()
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
        Me.SuperTabControlPanelBuscador.Controls.Add(Me.GroupPanel3)
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
        Me.PanelPrincipal.Controls.Add(Me.GroupPanel1)
        Me.PanelPrincipal.Controls.Add(Me.Panel1)
        Me.PanelPrincipal.Controls.SetChildIndex(Me.PanelUsuario, 0)
        Me.PanelPrincipal.Controls.SetChildIndex(Me.Panel1, 0)
        Me.PanelPrincipal.Controls.SetChildIndex(Me.GroupPanel1, 0)
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
        'GroupPanel1
        '
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.JGr_Detalle)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupPanel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupPanel1.Location = New System.Drawing.Point(0, 165)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(884, 263)
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
        Me.GroupPanel1.Text = "D E T A L L E"
        '
        'JGr_Detalle
        '
        Me.JGr_Detalle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.JGr_Detalle.Location = New System.Drawing.Point(0, 0)
        Me.JGr_Detalle.Name = "JGr_Detalle"
        Me.JGr_Detalle.Size = New System.Drawing.Size(878, 240)
        Me.JGr_Detalle.TabIndex = 1
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.mcBonoDesc)
        Me.Panel1.Controls.Add(Me.GroupPanel2)
        Me.Panel1.Controls.Add(Me.Tb_Mes)
        Me.Panel1.Controls.Add(Me.LabelX4)
        Me.Panel1.Controls.Add(Me.Tb_Anio)
        Me.Panel1.Controls.Add(Me.Tb_id)
        Me.Panel1.Controls.Add(Me.JMc_Persona)
        Me.Panel1.Controls.Add(Me.LabelX3)
        Me.Panel1.Controls.Add(Me.LabelX2)
        Me.Panel1.Controls.Add(Me.LabelX1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(884, 165)
        Me.Panel1.TabIndex = 21
        '
        'mcBonoDesc
        '
        mcBonoDesc_DesignTimeLayout.LayoutString = resources.GetString("mcBonoDesc_DesignTimeLayout.LayoutString")
        Me.mcBonoDesc.DesignTimeLayout = mcBonoDesc_DesignTimeLayout
        Me.mcBonoDesc.Location = New System.Drawing.Point(684, 22)
        Me.mcBonoDesc.Name = "mcBonoDesc"
        Me.mcBonoDesc.SelectedIndex = -1
        Me.mcBonoDesc.SelectedItem = Nothing
        Me.mcBonoDesc.Size = New System.Drawing.Size(100, 22)
        Me.mcBonoDesc.TabIndex = 25
        Me.mcBonoDesc.Visible = False
        '
        'GroupPanel2
        '
        Me.GroupPanel2.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel2.Controls.Add(Me.Tb_SaldoSueldo)
        Me.GroupPanel2.Controls.Add(Me.Tb_BonoDesc)
        Me.GroupPanel2.Controls.Add(Me.LabelX7)
        Me.GroupPanel2.Controls.Add(Me.LabelX5)
        Me.GroupPanel2.Controls.Add(Me.Tb_descFijos)
        Me.GroupPanel2.Controls.Add(Me.Tb_Sueldo)
        Me.GroupPanel2.Controls.Add(Me.LabelX8)
        Me.GroupPanel2.Controls.Add(Me.LabelX6)
        Me.GroupPanel2.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel2.Location = New System.Drawing.Point(405, 1)
        Me.GroupPanel2.Name = "GroupPanel2"
        Me.GroupPanel2.Size = New System.Drawing.Size(250, 154)
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
        Me.GroupPanel2.TabIndex = 24
        Me.GroupPanel2.Text = "DETALLE SALARIO"
        '
        'Tb_SaldoSueldo
        '
        '
        '
        '
        Me.Tb_SaldoSueldo.Border.Class = "TextBoxBorder"
        Me.Tb_SaldoSueldo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Tb_SaldoSueldo.Location = New System.Drawing.Point(129, 90)
        Me.Tb_SaldoSueldo.Name = "Tb_SaldoSueldo"
        Me.Tb_SaldoSueldo.PreventEnterBeep = True
        Me.Tb_SaldoSueldo.Size = New System.Drawing.Size(95, 22)
        Me.Tb_SaldoSueldo.TabIndex = 20
        Me.Tb_SaldoSueldo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Tb_BonoDesc
        '
        '
        '
        '
        Me.Tb_BonoDesc.Border.Class = "TextBoxBorder"
        Me.Tb_BonoDesc.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Tb_BonoDesc.Location = New System.Drawing.Point(129, 38)
        Me.Tb_BonoDesc.Name = "Tb_BonoDesc"
        Me.Tb_BonoDesc.PreventEnterBeep = True
        Me.Tb_BonoDesc.Size = New System.Drawing.Size(95, 22)
        Me.Tb_BonoDesc.TabIndex = 19
        Me.Tb_BonoDesc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LabelX7
        '
        Me.LabelX7.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX7.Location = New System.Drawing.Point(28, 90)
        Me.LabelX7.Name = "LabelX7"
        Me.LabelX7.Size = New System.Drawing.Size(92, 23)
        Me.LabelX7.TabIndex = 19
        Me.LabelX7.Text = "SALDO:........."
        '
        'LabelX5
        '
        Me.LabelX5.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.Location = New System.Drawing.Point(28, 38)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(92, 23)
        Me.LabelX5.TabIndex = 18
        Me.LabelX5.Text = "BON/DESC:..."
        '
        'Tb_descFijos
        '
        '
        '
        '
        Me.Tb_descFijos.Border.Class = "TextBoxBorder"
        Me.Tb_descFijos.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Tb_descFijos.Location = New System.Drawing.Point(129, 64)
        Me.Tb_descFijos.Name = "Tb_descFijos"
        Me.Tb_descFijos.PreventEnterBeep = True
        Me.Tb_descFijos.Size = New System.Drawing.Size(95, 22)
        Me.Tb_descFijos.TabIndex = 18
        Me.Tb_descFijos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Tb_Sueldo
        '
        '
        '
        '
        Me.Tb_Sueldo.Border.Class = "TextBoxBorder"
        Me.Tb_Sueldo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Tb_Sueldo.Location = New System.Drawing.Point(129, 12)
        Me.Tb_Sueldo.Name = "Tb_Sueldo"
        Me.Tb_Sueldo.PreventEnterBeep = True
        Me.Tb_Sueldo.Size = New System.Drawing.Size(95, 22)
        Me.Tb_Sueldo.TabIndex = 17
        Me.Tb_Sueldo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LabelX8
        '
        Me.LabelX8.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX8.Location = New System.Drawing.Point(28, 64)
        Me.LabelX8.Name = "LabelX8"
        Me.LabelX8.Size = New System.Drawing.Size(92, 23)
        Me.LabelX8.TabIndex = 17
        Me.LabelX8.Text = "FIJOS:..........."
        '
        'LabelX6
        '
        Me.LabelX6.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX6.Location = New System.Drawing.Point(28, 12)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(92, 23)
        Me.LabelX6.TabIndex = 16
        Me.LabelX6.Text = "SUELDO:......."
        '
        'Tb_Mes
        '
        '
        '
        '
        Me.Tb_Mes.Border.Class = "TextBoxBorder"
        Me.Tb_Mes.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Tb_Mes.Location = New System.Drawing.Point(106, 112)
        Me.Tb_Mes.Name = "Tb_Mes"
        Me.Tb_Mes.PreventEnterBeep = True
        Me.Tb_Mes.Size = New System.Drawing.Size(84, 22)
        Me.Tb_Mes.TabIndex = 23
        Me.Tb_Mes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LabelX4
        '
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.Location = New System.Drawing.Point(12, 112)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(75, 23)
        Me.LabelX4.TabIndex = 22
        Me.LabelX4.Text = "MES:.........."
        '
        'Tb_Anio
        '
        '
        '
        '
        Me.Tb_Anio.Border.Class = "TextBoxBorder"
        Me.Tb_Anio.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Tb_Anio.Location = New System.Drawing.Point(106, 86)
        Me.Tb_Anio.Name = "Tb_Anio"
        Me.Tb_Anio.PreventEnterBeep = True
        Me.Tb_Anio.Size = New System.Drawing.Size(84, 22)
        Me.Tb_Anio.TabIndex = 21
        Me.Tb_Anio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Tb_id
        '
        '
        '
        '
        Me.Tb_id.Border.Class = "TextBoxBorder"
        Me.Tb_id.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Tb_id.Location = New System.Drawing.Point(106, 20)
        Me.Tb_id.Name = "Tb_id"
        Me.Tb_id.PreventEnterBeep = True
        Me.Tb_id.Size = New System.Drawing.Size(123, 22)
        Me.Tb_id.TabIndex = 20
        '
        'JMc_Persona
        '
        JMc_Persona_DesignTimeLayout.LayoutString = resources.GetString("JMc_Persona_DesignTimeLayout.LayoutString")
        Me.JMc_Persona.DesignTimeLayout = JMc_Persona_DesignTimeLayout
        Me.JMc_Persona.Location = New System.Drawing.Point(106, 57)
        Me.JMc_Persona.Name = "JMc_Persona"
        Me.JMc_Persona.SelectedIndex = -1
        Me.JMc_Persona.SelectedItem = Nothing
        Me.JMc_Persona.Size = New System.Drawing.Size(256, 22)
        Me.JMc_Persona.TabIndex = 19
        '
        'LabelX3
        '
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Location = New System.Drawing.Point(12, 57)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(91, 23)
        Me.LabelX3.TabIndex = 18
        Me.LabelX3.Text = "PERSONA:"
        '
        'LabelX2
        '
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Location = New System.Drawing.Point(12, 86)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(75, 23)
        Me.LabelX2.TabIndex = 17
        Me.LabelX2.Text = "AÑO:.........."
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Location = New System.Drawing.Point(12, 17)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(87, 23)
        Me.LabelX1.TabIndex = 16
        Me.LabelX1.Text = "CODIGO:"
        '
        'GroupPanel3
        '
        Me.GroupPanel3.BackColor = System.Drawing.Color.Transparent
        Me.GroupPanel3.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel3.Controls.Add(Me.JGr_Buscador)
        Me.GroupPanel3.Controls.Add(Me.PanelEx6)
        Me.GroupPanel3.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupPanel3.Location = New System.Drawing.Point(0, 0)
        Me.GroupPanel3.Name = "GroupPanel3"
        Me.GroupPanel3.Size = New System.Drawing.Size(884, 536)
        '
        '
        '
        Me.GroupPanel3.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GroupPanel3.Style.BackColorGradientAngle = 90
        Me.GroupPanel3.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.GroupPanel3.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel3.Style.BorderBottomWidth = 1
        Me.GroupPanel3.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanel3.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel3.Style.BorderLeftWidth = 1
        Me.GroupPanel3.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel3.Style.BorderRightWidth = 1
        Me.GroupPanel3.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel3.Style.BorderTopWidth = 1
        Me.GroupPanel3.Style.CornerDiameter = 4
        Me.GroupPanel3.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel3.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel3.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanel3.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanel3.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel3.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel3.TabIndex = 2
        Me.GroupPanel3.Text = "B U S C A D O R"
        '
        'JGr_Buscador
        '
        Me.JGr_Buscador.Dock = System.Windows.Forms.DockStyle.Fill
        Me.JGr_Buscador.Location = New System.Drawing.Point(0, 56)
        Me.JGr_Buscador.Name = "JGr_Buscador"
        Me.JGr_Buscador.Size = New System.Drawing.Size(878, 459)
        Me.JGr_Buscador.TabIndex = 0
        '
        'PanelEx6
        '
        Me.PanelEx6.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelEx6.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanelEx6.Controls.Add(Me.ButtonX1)
        Me.PanelEx6.Controls.Add(Me.btnMostrarTodos)
        Me.PanelEx6.DisabledBackColor = System.Drawing.Color.Empty
        Me.PanelEx6.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelEx6.Location = New System.Drawing.Point(0, 0)
        Me.PanelEx6.Name = "PanelEx6"
        Me.PanelEx6.Size = New System.Drawing.Size(878, 56)
        Me.PanelEx6.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelEx6.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.PanelEx6.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.PanelEx6.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelEx6.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelEx6.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelEx6.Style.GradientAngle = 90
        Me.PanelEx6.TabIndex = 1
        '
        'ButtonX1
        '
        Me.ButtonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX1.Dock = System.Windows.Forms.DockStyle.Left
        Me.ButtonX1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonX1.ImageFixedSize = New System.Drawing.Size(48, 48)
        Me.ButtonX1.Location = New System.Drawing.Point(133, 0)
        Me.ButtonX1.Margin = New System.Windows.Forms.Padding(10, 3, 3, 3)
        Me.ButtonX1.Name = "ButtonX1"
        Me.ButtonX1.Padding = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.ButtonX1.Size = New System.Drawing.Size(143, 56)
        Me.ButtonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX1.TabIndex = 1
        Me.ButtonX1.Text = "MOSTRAR DE MES Y AÑO ACTUAL"
        Me.ButtonX1.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Right
        '
        'btnMostrarTodos
        '
        Me.btnMostrarTodos.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnMostrarTodos.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnMostrarTodos.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnMostrarTodos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMostrarTodos.ImageFixedSize = New System.Drawing.Size(48, 48)
        Me.btnMostrarTodos.Location = New System.Drawing.Point(0, 0)
        Me.btnMostrarTodos.Name = "btnMostrarTodos"
        Me.btnMostrarTodos.Size = New System.Drawing.Size(133, 56)
        Me.btnMostrarTodos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnMostrarTodos.TabIndex = 0
        Me.btnMostrarTodos.Text = "MOSTRAR TODOS"
        Me.btnMostrarTodos.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Right
        '
        'F0_BonosDescuentos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(884, 561)
        Me.Name = "F0_BonosDescuentos"
        Me.Text = "F0_BonosDescuentos"
        Me.Controls.SetChildIndex(Me.SuperTabPrincipal, 0)
        CType(Me.SuperTabPrincipal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SuperTabPrincipal.ResumeLayout(False)
        Me.SuperTabControlPanelBuscador.ResumeLayout(False)
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
        CType(Me.JGr_Detalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.mcBonoDesc, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel2.ResumeLayout(False)
        CType(Me.JMc_Persona, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel3.ResumeLayout(False)
        CType(Me.JGr_Buscador, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelEx6.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents JGr_Detalle As Janus.Windows.GridEX.GridEX
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Tb_Mes As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Tb_Anio As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Tb_id As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents JMc_Persona As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents mcBonoDesc As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents GroupPanel2 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Tb_SaldoSueldo As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Tb_BonoDesc As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX7 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Tb_descFijos As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Tb_Sueldo As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX8 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Friend WithEvents GroupPanel3 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents JGr_Buscador As Janus.Windows.GridEX.GridEX
    Friend WithEvents PanelEx6 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents ButtonX1 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnMostrarTodos As DevComponents.DotNetBar.ButtonX
End Class
