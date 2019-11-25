<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F0_PreExamen
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
        Dim tbEstados_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F0_PreExamen))
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.PanelFecha = New System.Windows.Forms.Panel()
        Me.btMarcarTodos = New DevComponents.DotNetBar.ButtonX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.tbFechaP = New System.Windows.Forms.DateTimePicker()
        Me.tbEstados = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.PanelInfo = New System.Windows.Forms.Panel()
        Me.LabelX12 = New DevComponents.DotNetBar.LabelX()
        Me.tbFecha = New System.Windows.Forms.DateTimePicker()
        Me.GroupPanel2 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.grAsignacion = New Janus.Windows.GridEX.GridEX()
        Me.btnAsignar = New DevComponents.DotNetBar.ButtonX()
        Me.GroupPanel3 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.grPreguntas = New Janus.Windows.GridEX.GridEX()
        Me.GroupPanel4 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.tbNombre = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.tbNumi = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.ButtonX2 = New DevComponents.DotNetBar.ButtonX()
        Me.ButtonX3 = New DevComponents.DotNetBar.ButtonX()
        Me.btnNotas = New DevComponents.DotNetBar.ButtonX()
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
        Me.PanelFecha.SuspendLayout()
        CType(Me.tbEstados, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelInfo.SuspendLayout()
        Me.GroupPanel2.SuspendLayout()
        CType(Me.grAsignacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel3.SuspendLayout()
        CType(Me.grPreguntas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel4.SuspendLayout()
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
        Me.SuperTabPrincipal.Controls.SetChildIndex(Me.SuperTabControlPanelRegistro, 0)
        Me.SuperTabPrincipal.Controls.SetChildIndex(Me.SuperTabControlPanelBuscador, 0)
        '
        'SuperTabControlPanelBuscador
        '
        Me.SuperTabControlPanelBuscador.Controls.Add(Me.GroupPanel3)
        Me.SuperTabControlPanelBuscador.Controls.Add(Me.GroupPanel4)
        Me.SuperTabControlPanelBuscador.Location = New System.Drawing.Point(0, 23)
        Me.SuperTabControlPanelBuscador.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.SuperTabControlPanelBuscador.Size = New System.Drawing.Size(884, 538)
        '
        'SupTabItemBusqueda
        '
        Me.SupTabItemBusqueda.Text = "NOTAS"
        Me.SupTabItemBusqueda.Visible = False
        '
        'SuperTabControlPanelRegistro
        '
        Me.SuperTabControlPanelRegistro.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
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
        Me.PanelInferior.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
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
        Me.PanelToolBar1.Controls.Add(Me.btnNotas)
        Me.PanelToolBar1.Controls.Add(Me.btnAsignar)
        Me.PanelToolBar1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PanelToolBar1.Size = New System.Drawing.Size(520, 72)
        Me.PanelToolBar1.Controls.SetChildIndex(Me.btnAsignar, 0)
        Me.PanelToolBar1.Controls.SetChildIndex(Me.btnNotas, 0)
        Me.PanelToolBar1.Controls.SetChildIndex(Me.btnNuevo, 0)
        Me.PanelToolBar1.Controls.SetChildIndex(Me.btnModificar, 0)
        Me.PanelToolBar1.Controls.SetChildIndex(Me.btnEliminar, 0)
        Me.PanelToolBar1.Controls.SetChildIndex(Me.btnGrabar, 0)
        Me.PanelToolBar1.Controls.SetChildIndex(Me.btnSalir, 0)
        '
        'btnSalir
        '
        Me.btnSalir.Location = New System.Drawing.Point(460, 0)
        Me.btnSalir.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        '
        'btnGrabar
        '
        Me.btnGrabar.Location = New System.Drawing.Point(388, 0)
        Me.btnGrabar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        '
        'btnEliminar
        '
        Me.btnEliminar.Location = New System.Drawing.Point(316, 0)
        Me.btnEliminar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnEliminar.Visible = False
        '
        'btnModificar
        '
        Me.btnModificar.Location = New System.Drawing.Point(244, 0)
        Me.btnModificar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        '
        'btnNuevo
        '
        Me.btnNuevo.Location = New System.Drawing.Point(172, 0)
        Me.btnNuevo.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnNuevo.Visible = False
        '
        'PanelPrincipal
        '
        Me.PanelPrincipal.Controls.Add(Me.GroupPanel2)
        Me.PanelPrincipal.Controls.Add(Me.GroupPanel1)
        Me.PanelPrincipal.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.PanelPrincipal.Controls.SetChildIndex(Me.PanelUsuario, 0)
        Me.PanelPrincipal.Controls.SetChildIndex(Me.GroupPanel1, 0)
        Me.PanelPrincipal.Controls.SetChildIndex(Me.GroupPanel2, 0)
        '
        'PanelUsuario
        '
        Me.PanelUsuario.Location = New System.Drawing.Point(632, 6)
        Me.PanelUsuario.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        '
        'btnUltimo
        '
        Me.btnUltimo.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        '
        'LblPaginacion
        '
        Me.LblPaginacion.Location = New System.Drawing.Point(160, 0)
        Me.LblPaginacion.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblPaginacion.Size = New System.Drawing.Size(128, 36)
        Me.LblPaginacion.Text = ""
        '
        'MRlAccion
        '
        '
        '
        '
        Me.MRlAccion.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.MRlAccion.Location = New System.Drawing.Point(550, 6)
        Me.MRlAccion.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        '
        'GroupPanel1
        '
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.PanelFecha)
        Me.GroupPanel1.Controls.Add(Me.tbEstados)
        Me.GroupPanel1.Controls.Add(Me.PanelInfo)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupPanel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupPanel1.Location = New System.Drawing.Point(0, 0)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(884, 97)
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
        Me.GroupPanel1.Text = "D A T O S"
        '
        'PanelFecha
        '
        Me.PanelFecha.BackColor = System.Drawing.Color.Transparent
        Me.PanelFecha.Controls.Add(Me.btMarcarTodos)
        Me.PanelFecha.Controls.Add(Me.LabelX1)
        Me.PanelFecha.Controls.Add(Me.tbFechaP)
        Me.PanelFecha.Dock = System.Windows.Forms.DockStyle.Left
        Me.PanelFecha.Location = New System.Drawing.Point(266, 0)
        Me.PanelFecha.Name = "PanelFecha"
        Me.PanelFecha.Padding = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.PanelFecha.Size = New System.Drawing.Size(308, 74)
        Me.PanelFecha.TabIndex = 78
        '
        'btMarcarTodos
        '
        Me.btMarcarTodos.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btMarcarTodos.ColorTable = DevComponents.DotNetBar.eButtonColor.Orange
        Me.btMarcarTodos.Dock = System.Windows.Forms.DockStyle.Right
        Me.btMarcarTodos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btMarcarTodos.Image = Global.Presentacion.My.Resources.Resources.GRABACION_EXITOSA
        Me.btMarcarTodos.ImageFixedSize = New System.Drawing.Size(48, 48)
        Me.btMarcarTodos.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btMarcarTodos.Location = New System.Drawing.Point(175, 2)
        Me.btMarcarTodos.Name = "btMarcarTodos"
        Me.btMarcarTodos.Size = New System.Drawing.Size(131, 70)
        Me.btMarcarTodos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btMarcarTodos.TabIndex = 75
        Me.btMarcarTodos.Text = "SELECCIONAR TODOS"
        Me.btMarcarTodos.TextColor = System.Drawing.Color.Black
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX1.Location = New System.Drawing.Point(9, 5)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(160, 23)
        Me.LabelX1.TabIndex = 74
        Me.LabelX1.Text = "FECHA A PROGRAMAR"
        '
        'tbFechaP
        '
        Me.tbFechaP.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbFechaP.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.tbFechaP.Location = New System.Drawing.Point(9, 28)
        Me.tbFechaP.Name = "tbFechaP"
        Me.tbFechaP.Size = New System.Drawing.Size(122, 22)
        Me.tbFechaP.TabIndex = 73
        '
        'tbEstados
        '
        tbEstados_DesignTimeLayout.LayoutString = resources.GetString("tbEstados_DesignTimeLayout.LayoutString")
        Me.tbEstados.DesignTimeLayout = tbEstados_DesignTimeLayout
        Me.tbEstados.Location = New System.Drawing.Point(801, 3)
        Me.tbEstados.Name = "tbEstados"
        Me.tbEstados.SelectedIndex = -1
        Me.tbEstados.SelectedItem = Nothing
        Me.tbEstados.Size = New System.Drawing.Size(100, 22)
        Me.tbEstados.TabIndex = 77
        Me.tbEstados.Visible = False
        '
        'PanelInfo
        '
        Me.PanelInfo.BackColor = System.Drawing.Color.Transparent
        Me.PanelInfo.Controls.Add(Me.LabelX12)
        Me.PanelInfo.Controls.Add(Me.tbFecha)
        Me.PanelInfo.Dock = System.Windows.Forms.DockStyle.Left
        Me.PanelInfo.Location = New System.Drawing.Point(0, 0)
        Me.PanelInfo.Name = "PanelInfo"
        Me.PanelInfo.Size = New System.Drawing.Size(266, 74)
        Me.PanelInfo.TabIndex = 75
        '
        'LabelX12
        '
        '
        '
        '
        Me.LabelX12.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX12.Location = New System.Drawing.Point(9, 5)
        Me.LabelX12.Name = "LabelX12"
        Me.LabelX12.Size = New System.Drawing.Size(228, 23)
        Me.LabelX12.TabIndex = 74
        Me.LabelX12.Text = "ALUMNOS APROBADOS HASTA EL:"
        '
        'tbFecha
        '
        Me.tbFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.tbFecha.Location = New System.Drawing.Point(9, 28)
        Me.tbFecha.Name = "tbFecha"
        Me.tbFecha.Size = New System.Drawing.Size(122, 22)
        Me.tbFecha.TabIndex = 73
        '
        'GroupPanel2
        '
        Me.GroupPanel2.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel2.Controls.Add(Me.grAsignacion)
        Me.GroupPanel2.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupPanel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupPanel2.Location = New System.Drawing.Point(0, 97)
        Me.GroupPanel2.Name = "GroupPanel2"
        Me.GroupPanel2.Size = New System.Drawing.Size(884, 331)
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
        Me.GroupPanel2.TabIndex = 21
        Me.GroupPanel2.Text = "A S I G N A C I O N    D E    A L U M N O S "
        '
        'grAsignacion
        '
        Me.grAsignacion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grAsignacion.Location = New System.Drawing.Point(0, 0)
        Me.grAsignacion.Name = "grAsignacion"
        Me.grAsignacion.Size = New System.Drawing.Size(878, 308)
        Me.grAsignacion.TabIndex = 0
        '
        'btnAsignar
        '
        Me.btnAsignar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnAsignar.BackColor = System.Drawing.Color.Transparent
        Me.btnAsignar.ColorTable = DevComponents.DotNetBar.eButtonColor.Magenta
        Me.btnAsignar.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnAsignar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAsignar.Image = Global.Presentacion.My.Resources.Resources.ALUMNO_APROBADO
        Me.btnAsignar.ImageFixedSize = New System.Drawing.Size(48, 48)
        Me.btnAsignar.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btnAsignar.Location = New System.Drawing.Point(0, 0)
        Me.btnAsignar.Name = "btnAsignar"
        Me.btnAsignar.Size = New System.Drawing.Size(86, 72)
        Me.btnAsignar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnAsignar.TabIndex = 7
        Me.btnAsignar.Text = "ASIGNAR"
        Me.btnAsignar.TextColor = System.Drawing.Color.Black
        '
        'GroupPanel3
        '
        Me.GroupPanel3.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel3.Controls.Add(Me.grPreguntas)
        Me.GroupPanel3.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupPanel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupPanel3.Location = New System.Drawing.Point(0, 83)
        Me.GroupPanel3.Name = "GroupPanel3"
        Me.GroupPanel3.Size = New System.Drawing.Size(884, 455)
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
        Me.GroupPanel3.TabIndex = 22
        Me.GroupPanel3.Text = "A S I G N A C I O N    D E    A L U M N O S "
        '
        'grPreguntas
        '
        Me.grPreguntas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grPreguntas.Location = New System.Drawing.Point(0, 0)
        Me.grPreguntas.Name = "grPreguntas"
        Me.grPreguntas.Size = New System.Drawing.Size(878, 432)
        Me.grPreguntas.TabIndex = 0
        '
        'GroupPanel4
        '
        Me.GroupPanel4.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel4.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel4.Controls.Add(Me.LabelX3)
        Me.GroupPanel4.Controls.Add(Me.tbNombre)
        Me.GroupPanel4.Controls.Add(Me.LabelX2)
        Me.GroupPanel4.Controls.Add(Me.tbNumi)
        Me.GroupPanel4.Controls.Add(Me.ButtonX2)
        Me.GroupPanel4.Controls.Add(Me.ButtonX3)
        Me.GroupPanel4.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupPanel4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupPanel4.Location = New System.Drawing.Point(0, 0)
        Me.GroupPanel4.Name = "GroupPanel4"
        Me.GroupPanel4.Size = New System.Drawing.Size(884, 83)
        '
        '
        '
        Me.GroupPanel4.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GroupPanel4.Style.BackColorGradientAngle = 90
        Me.GroupPanel4.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.GroupPanel4.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel4.Style.BorderBottomWidth = 1
        Me.GroupPanel4.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanel4.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel4.Style.BorderLeftWidth = 1
        Me.GroupPanel4.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel4.Style.BorderRightWidth = 1
        Me.GroupPanel4.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel4.Style.BorderTopWidth = 1
        Me.GroupPanel4.Style.CornerDiameter = 4
        Me.GroupPanel4.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel4.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanel4.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanel4.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel4.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel4.TabIndex = 23
        Me.GroupPanel4.Text = "D A T O S    D E    A L U M N O "
        '
        'LabelX3
        '
        Me.LabelX3.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX3.Location = New System.Drawing.Point(179, 31)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(64, 23)
        Me.LabelX3.TabIndex = 63
        Me.LabelX3.Text = "NOMBRE:"
        '
        'tbNombre
        '
        '
        '
        '
        Me.tbNombre.Border.Class = "TextBoxBorder"
        Me.tbNombre.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbNombre.Location = New System.Drawing.Point(249, 32)
        Me.tbNombre.Name = "tbNombre"
        Me.tbNombre.PreventEnterBeep = True
        Me.tbNombre.Size = New System.Drawing.Size(431, 22)
        Me.tbNombre.TabIndex = 60
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX2.Location = New System.Drawing.Point(179, 3)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(64, 23)
        Me.LabelX2.TabIndex = 62
        Me.LabelX2.Text = "COD:"
        '
        'tbNumi
        '
        '
        '
        '
        Me.tbNumi.Border.Class = "TextBoxBorder"
        Me.tbNumi.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbNumi.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbNumi.Location = New System.Drawing.Point(249, 4)
        Me.tbNumi.Name = "tbNumi"
        Me.tbNumi.PreventEnterBeep = True
        Me.tbNumi.Size = New System.Drawing.Size(100, 22)
        Me.tbNumi.TabIndex = 61
        '
        'ButtonX2
        '
        Me.ButtonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX2.BackColor = System.Drawing.Color.Transparent
        Me.ButtonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.Orange
        Me.ButtonX2.Dock = System.Windows.Forms.DockStyle.Left
        Me.ButtonX2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonX2.Image = Global.Presentacion.My.Resources.Resources.SALIR
        Me.ButtonX2.ImageFixedSize = New System.Drawing.Size(30, 30)
        Me.ButtonX2.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonX2.Location = New System.Drawing.Point(72, 0)
        Me.ButtonX2.Name = "ButtonX2"
        Me.ButtonX2.Size = New System.Drawing.Size(72, 60)
        Me.ButtonX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX2.TabIndex = 3
        Me.ButtonX2.Text = "SALIR"
        Me.ButtonX2.TextColor = System.Drawing.Color.Black
        '
        'ButtonX3
        '
        Me.ButtonX3.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX3.BackColor = System.Drawing.Color.Transparent
        Me.ButtonX3.ColorTable = DevComponents.DotNetBar.eButtonColor.Orange
        Me.ButtonX3.Dock = System.Windows.Forms.DockStyle.Left
        Me.ButtonX3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonX3.Image = Global.Presentacion.My.Resources.Resources.GUARDAR
        Me.ButtonX3.ImageFixedSize = New System.Drawing.Size(30, 30)
        Me.ButtonX3.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonX3.Location = New System.Drawing.Point(0, 0)
        Me.ButtonX3.Name = "ButtonX3"
        Me.ButtonX3.Size = New System.Drawing.Size(72, 60)
        Me.ButtonX3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX3.TabIndex = 2
        Me.ButtonX3.Text = "GRABAR"
        Me.ButtonX3.TextColor = System.Drawing.Color.Black
        '
        'btnNotas
        '
        Me.btnNotas.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnNotas.BackColor = System.Drawing.Color.Transparent
        Me.btnNotas.ColorTable = DevComponents.DotNetBar.eButtonColor.Magenta
        Me.btnNotas.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnNotas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNotas.Image = Global.Presentacion.My.Resources.Resources.PRE_EXAMEN
        Me.btnNotas.ImageFixedSize = New System.Drawing.Size(72, 48)
        Me.btnNotas.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btnNotas.Location = New System.Drawing.Point(86, 0)
        Me.btnNotas.Name = "btnNotas"
        Me.btnNotas.Size = New System.Drawing.Size(86, 72)
        Me.btnNotas.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnNotas.TabIndex = 11
        Me.btnNotas.Text = "NOTAS"
        Me.btnNotas.TextColor = System.Drawing.Color.Black
        '
        'F0_PreExamen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(884, 561)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "F0_PreExamen"
        Me.Text = "F0_PreExamen"
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
        Me.GroupPanel1.PerformLayout()
        Me.PanelFecha.ResumeLayout(False)
        CType(Me.tbEstados, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelInfo.ResumeLayout(False)
        Me.GroupPanel2.ResumeLayout(False)
        CType(Me.grAsignacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel3.ResumeLayout(False)
        CType(Me.grPreguntas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel4.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupPanel2 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents grAsignacion As Janus.Windows.GridEX.GridEX
    Protected WithEvents btnAsignar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents PanelInfo As System.Windows.Forms.Panel
    Friend WithEvents LabelX12 As DevComponents.DotNetBar.LabelX
    Friend WithEvents tbFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents tbEstados As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents PanelFecha As System.Windows.Forms.Panel
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents tbFechaP As System.Windows.Forms.DateTimePicker
    Protected WithEvents btMarcarTodos As DevComponents.DotNetBar.ButtonX
    Friend WithEvents GroupPanel3 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents grPreguntas As Janus.Windows.GridEX.GridEX
    Friend WithEvents GroupPanel4 As DevComponents.DotNetBar.Controls.GroupPanel
    Protected WithEvents ButtonX2 As DevComponents.DotNetBar.ButtonX
    Protected WithEvents ButtonX3 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents tbNombre As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents tbNumi As DevComponents.DotNetBar.Controls.TextBoxX
    Protected WithEvents btnNotas As DevComponents.DotNetBar.ButtonX
End Class
