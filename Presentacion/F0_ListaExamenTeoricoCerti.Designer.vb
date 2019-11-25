<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F0_ListaExamenTeoricoCerti
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
        Dim tbSuc_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F0_ListaExamenTeoricoCerti))
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.grAlumnos = New Janus.Windows.GridEX.GridEX()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.btMarcarTodos = New DevComponents.DotNetBar.ButtonX()
        Me.GroupPanel2 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.tbTipoRep = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.tbForm = New System.Windows.Forms.CheckBox()
        Me.tbPrac = New System.Windows.Forms.CheckBox()
        Me.tbTeo = New System.Windows.Forms.CheckBox()
        Me.GroupPanel3 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.tbFecha = New System.Windows.Forms.DateTimePicker()
        Me.ButtonX1 = New DevComponents.DotNetBar.ButtonX()
        Me.tbSuc = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.LabelX23 = New DevComponents.DotNetBar.LabelX()
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
        Me.GroupPanel1.SuspendLayout()
        CType(Me.grAlumnos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel2.SuspendLayout()
        Me.GroupPanel3.SuspendLayout()
        CType(Me.tbSuc, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.SuperTabPrincipal.Size = New System.Drawing.Size(1167, 561)
        Me.SuperTabPrincipal.Controls.SetChildIndex(Me.SuperTabControlPanelBuscador, 0)
        Me.SuperTabPrincipal.Controls.SetChildIndex(Me.SuperTabControlPanelRegistro, 0)
        '
        'SupTabItemBusqueda
        '
        Me.SupTabItemBusqueda.Visible = False
        '
        'SuperTabControlPanelRegistro
        '
        Me.SuperTabControlPanelRegistro.Size = New System.Drawing.Size(1167, 536)
        Me.SuperTabControlPanelRegistro.Controls.SetChildIndex(Me.PanelSuperior, 0)
        Me.SuperTabControlPanelRegistro.Controls.SetChildIndex(Me.PanelInferior, 0)
        Me.SuperTabControlPanelRegistro.Controls.SetChildIndex(Me.PanelPrincipal, 0)
        '
        'PanelSuperior
        '
        Me.PanelSuperior.Size = New System.Drawing.Size(1167, 86)
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
        Me.PanelInferior.Size = New System.Drawing.Size(1167, 36)
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
        Me.PanelToolBar1.Controls.Add(Me.ButtonX1)
        Me.PanelToolBar1.Controls.Add(Me.btMarcarTodos)
        Me.PanelToolBar1.Controls.Add(Me.GroupPanel3)
        Me.PanelToolBar1.Controls.Add(Me.GroupPanel2)
        Me.PanelToolBar1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelToolBar1.Size = New System.Drawing.Size(1167, 86)
        Me.PanelToolBar1.Controls.SetChildIndex(Me.GroupPanel2, 0)
        Me.PanelToolBar1.Controls.SetChildIndex(Me.GroupPanel3, 0)
        Me.PanelToolBar1.Controls.SetChildIndex(Me.btnNuevo, 0)
        Me.PanelToolBar1.Controls.SetChildIndex(Me.btMarcarTodos, 0)
        Me.PanelToolBar1.Controls.SetChildIndex(Me.btnGrabar, 0)
        Me.PanelToolBar1.Controls.SetChildIndex(Me.ButtonX1, 0)
        Me.PanelToolBar1.Controls.SetChildIndex(Me.btnSalir, 0)
        Me.PanelToolBar1.Controls.SetChildIndex(Me.btnEliminar, 0)
        Me.PanelToolBar1.Controls.SetChildIndex(Me.btnModificar, 0)
        '
        'btnSalir
        '
        Me.btnSalir.Location = New System.Drawing.Point(1054, 0)
        Me.btnSalir.Size = New System.Drawing.Size(72, 86)
        '
        'btnGrabar
        '
        Me.btnGrabar.Image = Global.Presentacion.My.Resources.Resources.reforzamiento
        Me.btnGrabar.Location = New System.Drawing.Point(847, 0)
        Me.btnGrabar.Size = New System.Drawing.Size(86, 86)
        Me.btnGrabar.Text = "ACTUALIZAR"
        '
        'btnEliminar
        '
        Me.btnEliminar.Location = New System.Drawing.Point(1126, 0)
        Me.btnEliminar.Size = New System.Drawing.Size(72, 86)
        Me.btnEliminar.Visible = False
        '
        'btnModificar
        '
        Me.btnModificar.Location = New System.Drawing.Point(1198, 0)
        Me.btnModificar.Size = New System.Drawing.Size(72, 86)
        Me.btnModificar.Visible = False
        '
        'btnNuevo
        '
        Me.btnNuevo.Image = Global.Presentacion.My.Resources.Resources.GENERAR_REPORTE
        Me.btnNuevo.Location = New System.Drawing.Point(690, 0)
        Me.btnNuevo.Size = New System.Drawing.Size(72, 86)
        Me.btnNuevo.Text = "GENERAR"
        '
        'PanelToolBar2
        '
        Me.PanelToolBar2.Location = New System.Drawing.Point(1088, 0)
        Me.PanelToolBar2.Size = New System.Drawing.Size(79, 86)
        Me.PanelToolBar2.Visible = False
        '
        'PanelPrincipal
        '
        Me.PanelPrincipal.Controls.Add(Me.GroupPanel1)
        Me.PanelPrincipal.Location = New System.Drawing.Point(0, 86)
        Me.PanelPrincipal.Size = New System.Drawing.Size(1167, 414)
        Me.PanelPrincipal.Controls.SetChildIndex(Me.PanelUsuario, 0)
        Me.PanelPrincipal.Controls.SetChildIndex(Me.GroupPanel1, 0)
        '
        'PanelUsuario
        '
        Me.PanelUsuario.Location = New System.Drawing.Point(626, 29)
        '
        'btnImprimir
        '
        Me.btnImprimir.Location = New System.Drawing.Point(7, 0)
        Me.btnImprimir.Size = New System.Drawing.Size(72, 86)
        '
        'PanelNavegacion
        '
        Me.PanelNavegacion.Visible = False
        '
        'MPanelUserAct
        '
        Me.MPanelUserAct.Location = New System.Drawing.Point(967, 0)
        '
        'MRlAccion
        '
        '
        '
        '
        Me.MRlAccion.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.MRlAccion.Location = New System.Drawing.Point(1037, 20)
        Me.MRlAccion.Size = New System.Drawing.Size(41, 60)
        Me.MRlAccion.Visible = False
        '
        'GroupPanel1
        '
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.grAlumnos)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupPanel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupPanel1.Location = New System.Drawing.Point(0, 0)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(1167, 414)
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
        Me.GroupPanel1.Text = " L I S T A    D E    A L U M N O S"
        '
        'grAlumnos
        '
        Me.grAlumnos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grAlumnos.Location = New System.Drawing.Point(0, 0)
        Me.grAlumnos.Name = "grAlumnos"
        Me.grAlumnos.Size = New System.Drawing.Size(1161, 391)
        Me.grAlumnos.TabIndex = 1
        '
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
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
        Me.btMarcarTodos.Location = New System.Drawing.Point(762, 0)
        Me.btMarcarTodos.Name = "btMarcarTodos"
        Me.btMarcarTodos.Size = New System.Drawing.Size(85, 86)
        Me.btMarcarTodos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btMarcarTodos.TabIndex = 11
        Me.btMarcarTodos.Text = "SELECCIONAR TODOS"
        Me.btMarcarTodos.TextColor = System.Drawing.Color.Black
        '
        'GroupPanel2
        '
        Me.GroupPanel2.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel2.Controls.Add(Me.tbTipoRep)
        Me.GroupPanel2.Controls.Add(Me.tbForm)
        Me.GroupPanel2.Controls.Add(Me.tbPrac)
        Me.GroupPanel2.Controls.Add(Me.tbTeo)
        Me.GroupPanel2.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.GroupPanel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupPanel2.Location = New System.Drawing.Point(0, 0)
        Me.GroupPanel2.Name = "GroupPanel2"
        Me.GroupPanel2.Size = New System.Drawing.Size(435, 86)
        '
        '
        '
        Me.GroupPanel2.Style.BackColor = System.Drawing.Color.Transparent
        Me.GroupPanel2.Style.BackColor2 = System.Drawing.Color.Transparent
        Me.GroupPanel2.Style.BackColorGradientAngle = 90
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
        Me.GroupPanel2.TabIndex = 0
        Me.GroupPanel2.Text = "G E N E R A R"
        '
        'tbTipoRep
        '
        '
        '
        '
        Me.tbTipoRep.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbTipoRep.Location = New System.Drawing.Point(3, 8)
        Me.tbTipoRep.Name = "tbTipoRep"
        Me.tbTipoRep.OffText = "SOLO LISTA"
        Me.tbTipoRep.OnText = "CON RESULTADOS"
        Me.tbTipoRep.Size = New System.Drawing.Size(149, 22)
        Me.tbTipoRep.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.tbTipoRep.TabIndex = 3
        '
        'tbForm
        '
        Me.tbForm.AutoSize = True
        Me.tbForm.Checked = True
        Me.tbForm.CheckState = System.Windows.Forms.CheckState.Checked
        Me.tbForm.Location = New System.Drawing.Point(300, 8)
        Me.tbForm.Name = "tbForm"
        Me.tbForm.Size = New System.Drawing.Size(124, 20)
        Me.tbForm.TabIndex = 2
        Me.tbForm.Text = "FORMULARIOS"
        Me.tbForm.UseVisualStyleBackColor = True
        '
        'tbPrac
        '
        Me.tbPrac.AutoSize = True
        Me.tbPrac.Checked = True
        Me.tbPrac.CheckState = System.Windows.Forms.CheckState.Checked
        Me.tbPrac.Location = New System.Drawing.Point(158, 34)
        Me.tbPrac.Name = "tbPrac"
        Me.tbPrac.Size = New System.Drawing.Size(135, 20)
        Me.tbPrac.TabIndex = 1
        Me.tbPrac.Text = "LISTA PRACTICO"
        Me.tbPrac.UseVisualStyleBackColor = True
        '
        'tbTeo
        '
        Me.tbTeo.AutoSize = True
        Me.tbTeo.Checked = True
        Me.tbTeo.CheckState = System.Windows.Forms.CheckState.Checked
        Me.tbTeo.Location = New System.Drawing.Point(158, 8)
        Me.tbTeo.Name = "tbTeo"
        Me.tbTeo.Size = New System.Drawing.Size(127, 20)
        Me.tbTeo.TabIndex = 0
        Me.tbTeo.Text = "LISTA TEORICO"
        Me.tbTeo.UseVisualStyleBackColor = True
        '
        'GroupPanel3
        '
        Me.GroupPanel3.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel3.Controls.Add(Me.tbSuc)
        Me.GroupPanel3.Controls.Add(Me.LabelX23)
        Me.GroupPanel3.Controls.Add(Me.tbFecha)
        Me.GroupPanel3.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel3.Dock = System.Windows.Forms.DockStyle.Left
        Me.GroupPanel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupPanel3.Location = New System.Drawing.Point(435, 0)
        Me.GroupPanel3.Name = "GroupPanel3"
        Me.GroupPanel3.Size = New System.Drawing.Size(255, 86)
        '
        '
        '
        Me.GroupPanel3.Style.BackColor = System.Drawing.Color.Transparent
        Me.GroupPanel3.Style.BackColor2 = System.Drawing.Color.Transparent
        Me.GroupPanel3.Style.BackColorGradientAngle = 90
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
        Me.GroupPanel3.TabIndex = 12
        Me.GroupPanel3.Text = "F I L T R A R     P O R    F E C H A "
        '
        'tbFecha
        '
        Me.tbFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.tbFecha.Location = New System.Drawing.Point(122, 8)
        Me.tbFecha.Name = "tbFecha"
        Me.tbFecha.Size = New System.Drawing.Size(115, 22)
        Me.tbFecha.TabIndex = 5
        '
        'ButtonX1
        '
        Me.ButtonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.Orange
        Me.ButtonX1.Dock = System.Windows.Forms.DockStyle.Left
        Me.ButtonX1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonX1.Image = Global.Presentacion.My.Resources.Resources.folder
        Me.ButtonX1.ImageFixedSize = New System.Drawing.Size(48, 48)
        Me.ButtonX1.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonX1.Location = New System.Drawing.Point(933, 0)
        Me.ButtonX1.Name = "ButtonX1"
        Me.ButtonX1.Size = New System.Drawing.Size(121, 86)
        Me.ButtonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX1.TabIndex = 13
        Me.ButtonX1.Text = "ABRIR CARPETA DE PDF'S"
        Me.ButtonX1.TextColor = System.Drawing.Color.Black
        '
        'tbSuc
        '
        Me.tbSuc.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        tbSuc_DesignTimeLayout.LayoutString = resources.GetString("tbSuc_DesignTimeLayout.LayoutString")
        Me.tbSuc.DesignTimeLayout = tbSuc_DesignTimeLayout
        Me.tbSuc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbSuc.Location = New System.Drawing.Point(3, 37)
        Me.tbSuc.Name = "tbSuc"
        Me.tbSuc.SelectedIndex = -1
        Me.tbSuc.SelectedItem = Nothing
        Me.tbSuc.Size = New System.Drawing.Size(234, 22)
        Me.tbSuc.TabIndex = 101
        '
        'LabelX23
        '
        '
        '
        '
        Me.LabelX23.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX23.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX23.Location = New System.Drawing.Point(4, 17)
        Me.LabelX23.Name = "LabelX23"
        Me.LabelX23.Size = New System.Drawing.Size(84, 23)
        Me.LabelX23.TabIndex = 102
        Me.LabelX23.Text = "SUCURSAL:"
        '
        'F0_ListaExamenTeoricoCerti
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1167, 561)
        Me.Name = "F0_ListaExamenTeoricoCerti"
        Me.Text = "F0_ListaExamenCerti"
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
        Me.GroupPanel1.ResumeLayout(False)
        CType(Me.grAlumnos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel2.ResumeLayout(False)
        Me.GroupPanel2.PerformLayout()
        Me.GroupPanel3.ResumeLayout(False)
        Me.GroupPanel3.PerformLayout()
        CType(Me.tbSuc, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    Protected WithEvents btMarcarTodos As DevComponents.DotNetBar.ButtonX
    Friend WithEvents grAlumnos As Janus.Windows.GridEX.GridEX
    Friend WithEvents GroupPanel2 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents tbForm As System.Windows.Forms.CheckBox
    Friend WithEvents tbPrac As System.Windows.Forms.CheckBox
    Friend WithEvents tbTeo As System.Windows.Forms.CheckBox
    Friend WithEvents GroupPanel3 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents tbFecha As System.Windows.Forms.DateTimePicker
    Protected WithEvents ButtonX1 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents tbTipoRep As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents tbSuc As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents LabelX23 As DevComponents.DotNetBar.LabelX
End Class
