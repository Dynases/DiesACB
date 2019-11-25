
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class F0_HotelReservaFicha
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim tbTipo_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F0_HotelReservaFicha))
        Me.tbEncargadoRes = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnSalir = New DevComponents.DotNetBar.ButtonX()
        Me.btnGrabar = New DevComponents.DotNetBar.ButtonX()
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.MEP = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.MHighlighterFocus = New DevComponents.DotNetBar.Validator.Highlighter()
        Me.MFlyoutUsuario = New DevComponents.DotNetBar.Controls.Flyout(Me.components)
        Me.tbFechaOut = New System.Windows.Forms.DateTimePicker()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.tbUsuarioEncargado = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX7 = New DevComponents.DotNetBar.LabelX()
        Me.tbObs = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.tbLugRes = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.gpSocioRef = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.tbSocioRefAlDia = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.tbSocioRef = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.tbClienteAlDia = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.tbEsSocio = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.btnVerReclamos = New DevComponents.DotNetBar.ButtonX()
        Me.btnAddClientes = New DevComponents.DotNetBar.ButtonX()
        Me.btnAddNuevoCliente = New DevComponents.DotNetBar.ButtonX()
        Me.gpDisponibilidad = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.grCabañas = New Janus.Windows.GridEX.GridEX()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.panelCabaña = New System.Windows.Forms.Panel()
        Me.tbTipo = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.tbTotal = New DevComponents.Editors.DoubleInput()
        Me.LabelX10 = New DevComponents.DotNetBar.LabelX()
        Me.tbPrecio = New DevComponents.Editors.DoubleInput()
        Me.LabelX9 = New DevComponents.DotNetBar.LabelX()
        Me.tbCabaña = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.lbCabaña = New DevComponents.DotNetBar.LabelX()
        Me.btnVerDisponibilidad = New DevComponents.DotNetBar.ButtonX()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.tbNoches = New DevComponents.Editors.IntegerInput()
        Me.LabelX8 = New DevComponents.DotNetBar.LabelX()
        Me.tbCantPers = New DevComponents.Editors.IntegerInput()
        Me.tbFechaIn = New System.Windows.Forms.DateTimePicker()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.Panel1.SuspendLayout()
        CType(Me.MEP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.GroupPanel1.SuspendLayout()
        Me.gpSocioRef.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.gpDisponibilidad.SuspendLayout()
        CType(Me.grCabañas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.panelCabaña.SuspendLayout()
        CType(Me.tbTipo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbPrecio, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        CType(Me.tbNoches, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbCantPers, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tbEncargadoRes
        '
        Me.tbEncargadoRes.AcceptsTab = True
        '
        '
        '
        Me.tbEncargadoRes.Border.Class = "TextBoxBorder"
        Me.tbEncargadoRes.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbEncargadoRes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbEncargadoRes.Location = New System.Drawing.Point(12, 29)
        Me.tbEncargadoRes.Name = "tbEncargadoRes"
        Me.tbEncargadoRes.PreventEnterBeep = True
        Me.tbEncargadoRes.Size = New System.Drawing.Size(323, 22)
        Me.tbEncargadoRes.TabIndex = 0
        '
        'LabelX6
        '
        Me.LabelX6.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX6.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX6.Location = New System.Drawing.Point(12, 6)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(252, 23)
        Me.LabelX6.TabIndex = 145
        Me.LabelX6.Text = "TITULAR DE RESERVA"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Gold
        Me.Panel1.Controls.Add(Me.btnSalir)
        Me.Panel1.Controls.Add(Me.btnGrabar)
        Me.Panel1.Controls.Add(Me.ReflectionLabel1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(5, 5)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Padding = New System.Windows.Forms.Padding(10, 5, 0, 5)
        Me.Panel1.Size = New System.Drawing.Size(545, 61)
        Me.Panel1.TabIndex = 157
        '
        'btnSalir
        '
        Me.btnSalir.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnSalir.ColorTable = DevComponents.DotNetBar.eButtonColor.Orange
        Me.btnSalir.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Image = Global.Presentacion.My.Resources.Resources.SALIR
        Me.btnSalir.ImageFixedSize = New System.Drawing.Size(30, 30)
        Me.btnSalir.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btnSalir.Location = New System.Drawing.Point(82, 5)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(72, 51)
        Me.btnSalir.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnSalir.TabIndex = 12
        Me.btnSalir.Text = "SALIR"
        Me.btnSalir.TextColor = System.Drawing.Color.Black
        '
        'btnGrabar
        '
        Me.btnGrabar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnGrabar.ColorTable = DevComponents.DotNetBar.eButtonColor.Orange
        Me.btnGrabar.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnGrabar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGrabar.Image = Global.Presentacion.My.Resources.Resources.GUARDAR
        Me.btnGrabar.ImageFixedSize = New System.Drawing.Size(30, 30)
        Me.btnGrabar.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btnGrabar.Location = New System.Drawing.Point(10, 5)
        Me.btnGrabar.Name = "btnGrabar"
        Me.btnGrabar.Size = New System.Drawing.Size(72, 51)
        Me.btnGrabar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnGrabar.TabIndex = 11
        Me.btnGrabar.Text = "GRABAR"
        Me.btnGrabar.TextColor = System.Drawing.Color.Black
        '
        'ReflectionLabel1
        '
        '
        '
        '
        Me.ReflectionLabel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionLabel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.ReflectionLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReflectionLabel1.Location = New System.Drawing.Point(306, 5)
        Me.ReflectionLabel1.Name = "ReflectionLabel1"
        Me.ReflectionLabel1.Size = New System.Drawing.Size(239, 51)
        Me.ReflectionLabel1.TabIndex = 0
        Me.ReflectionLabel1.Text = "<b><font size=""16""><font color=""#313b42"">FICHA DE RESERVA</font></font></b>"
        '
        'MEP
        '
        Me.MEP.ContainerControl = Me
        '
        'MHighlighterFocus
        '
        Me.MHighlighterFocus.ContainerControl = Me
        '
        'MFlyoutUsuario
        '
        Me.MFlyoutUsuario.DropShadow = False
        Me.MFlyoutUsuario.Parent = Me
        '
        'tbFechaOut
        '
        Me.tbFechaOut.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbFechaOut.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.tbFechaOut.Location = New System.Drawing.Point(240, 28)
        Me.tbFechaOut.Name = "tbFechaOut"
        Me.tbFechaOut.Size = New System.Drawing.Size(122, 22)
        Me.tbFechaOut.TabIndex = 207
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.SteelBlue
        Me.Panel2.Controls.Add(Me.GroupPanel1)
        Me.Panel2.Controls.Add(Me.gpSocioRef)
        Me.Panel2.Controls.Add(Me.Panel5)
        Me.Panel2.Controls.Add(Me.gpDisponibilidad)
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(5, 66)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(545, 582)
        Me.Panel2.TabIndex = 208
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.Transparent
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.tbUsuarioEncargado)
        Me.GroupPanel1.Controls.Add(Me.LabelX7)
        Me.GroupPanel1.Controls.Add(Me.tbObs)
        Me.GroupPanel1.Controls.Add(Me.tbLugRes)
        Me.GroupPanel1.Controls.Add(Me.LabelX4)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupPanel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupPanel1.Location = New System.Drawing.Point(0, 454)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(545, 126)
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
        Me.GroupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        '
        '
        '
        Me.GroupPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel1.TabIndex = 219
        Me.GroupPanel1.Text = "OBSERVACION DE RESERVA"
        '
        'tbUsuarioEncargado
        '
        Me.tbUsuarioEncargado.AcceptsTab = True
        '
        '
        '
        Me.tbUsuarioEncargado.Border.Class = "TextBoxBorder"
        Me.tbUsuarioEncargado.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbUsuarioEncargado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbUsuarioEncargado.Location = New System.Drawing.Point(7, 24)
        Me.tbUsuarioEncargado.Name = "tbUsuarioEncargado"
        Me.tbUsuarioEncargado.PreventEnterBeep = True
        Me.tbUsuarioEncargado.ReadOnly = True
        Me.tbUsuarioEncargado.Size = New System.Drawing.Size(142, 22)
        Me.tbUsuarioEncargado.TabIndex = 220
        '
        'LabelX7
        '
        Me.LabelX7.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX7.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX7.Location = New System.Drawing.Point(7, 3)
        Me.LabelX7.Name = "LabelX7"
        Me.LabelX7.Size = New System.Drawing.Size(148, 23)
        Me.LabelX7.TabIndex = 219
        Me.LabelX7.Text = "ENCARGADO RESERVA"
        '
        'tbObs
        '
        Me.tbObs.BackColor = System.Drawing.SystemColors.HighlightText
        '
        '
        '
        Me.tbObs.Border.Class = "TextBoxBorder"
        Me.tbObs.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbObs.Dock = System.Windows.Forms.DockStyle.Right
        Me.tbObs.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbObs.Location = New System.Drawing.Point(161, 0)
        Me.tbObs.Multiline = True
        Me.tbObs.Name = "tbObs"
        Me.tbObs.PreventEnterBeep = True
        Me.tbObs.Size = New System.Drawing.Size(378, 101)
        Me.tbObs.TabIndex = 33
        '
        'tbLugRes
        '
        '
        '
        '
        Me.tbLugRes.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbLugRes.Location = New System.Drawing.Point(7, 75)
        Me.tbLugRes.Name = "tbLugRes"
        Me.tbLugRes.OffText = "VILLA TUNÁRI"
        Me.tbLugRes.OnText = "COCHABAMBA"
        Me.tbLugRes.Size = New System.Drawing.Size(142, 22)
        Me.tbLugRes.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.tbLugRes.TabIndex = 38
        Me.tbLugRes.Value = True
        Me.tbLugRes.ValueObject = "Y"
        '
        'LabelX4
        '
        Me.LabelX4.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX4.Location = New System.Drawing.Point(7, 51)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(128, 23)
        Me.LabelX4.TabIndex = 218
        Me.LabelX4.Text = "LUGAR DE RESERVA"
        '
        'gpSocioRef
        '
        Me.gpSocioRef.BackColor = System.Drawing.Color.Transparent
        Me.gpSocioRef.CanvasColor = System.Drawing.SystemColors.Control
        Me.gpSocioRef.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.OfficeMobile2014
        Me.gpSocioRef.Controls.Add(Me.tbSocioRefAlDia)
        Me.gpSocioRef.Controls.Add(Me.tbSocioRef)
        Me.gpSocioRef.DisabledBackColor = System.Drawing.Color.Empty
        Me.gpSocioRef.Dock = System.Windows.Forms.DockStyle.Top
        Me.gpSocioRef.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpSocioRef.Location = New System.Drawing.Point(0, 398)
        Me.gpSocioRef.Name = "gpSocioRef"
        Me.gpSocioRef.Size = New System.Drawing.Size(545, 56)
        '
        '
        '
        Me.gpSocioRef.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.gpSocioRef.Style.BackColorGradientAngle = 90
        Me.gpSocioRef.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.gpSocioRef.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpSocioRef.Style.BorderBottomWidth = 1
        Me.gpSocioRef.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.gpSocioRef.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpSocioRef.Style.BorderLeftWidth = 1
        Me.gpSocioRef.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpSocioRef.Style.BorderRightWidth = 1
        Me.gpSocioRef.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpSocioRef.Style.BorderTopWidth = 1
        Me.gpSocioRef.Style.CornerDiameter = 4
        Me.gpSocioRef.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.gpSocioRef.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        '
        '
        '
        Me.gpSocioRef.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.gpSocioRef.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.gpSocioRef.TabIndex = 220
        Me.gpSocioRef.Text = "SOCIO DE REFERENCIA"
        '
        'tbSocioRefAlDia
        '
        '
        '
        '
        Me.tbSocioRefAlDia.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbSocioRefAlDia.IsReadOnly = True
        Me.tbSocioRefAlDia.Location = New System.Drawing.Point(338, 3)
        Me.tbSocioRefAlDia.Name = "tbSocioRefAlDia"
        Me.tbSocioRefAlDia.OffText = "SOCIO EN MORA"
        Me.tbSocioRefAlDia.OnText = "SOCIO AL DIA"
        Me.tbSocioRefAlDia.Size = New System.Drawing.Size(170, 22)
        Me.tbSocioRefAlDia.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.tbSocioRefAlDia.TabIndex = 220
        '
        'tbSocioRef
        '
        Me.tbSocioRef.AcceptsTab = True
        '
        '
        '
        Me.tbSocioRef.Border.Class = "TextBoxBorder"
        Me.tbSocioRef.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbSocioRef.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbSocioRef.Location = New System.Drawing.Point(7, 3)
        Me.tbSocioRef.Name = "tbSocioRef"
        Me.tbSocioRef.PreventEnterBeep = True
        Me.tbSocioRef.Size = New System.Drawing.Size(325, 22)
        Me.tbSocioRef.TabIndex = 219
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.tbClienteAlDia)
        Me.Panel5.Controls.Add(Me.LabelX5)
        Me.Panel5.Controls.Add(Me.tbEsSocio)
        Me.Panel5.Controls.Add(Me.btnVerReclamos)
        Me.Panel5.Controls.Add(Me.LabelX6)
        Me.Panel5.Controls.Add(Me.tbEncargadoRes)
        Me.Panel5.Controls.Add(Me.btnAddClientes)
        Me.Panel5.Controls.Add(Me.btnAddNuevoCliente)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel5.Location = New System.Drawing.Point(0, 307)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(545, 91)
        Me.Panel5.TabIndex = 216
        '
        'tbClienteAlDia
        '
        '
        '
        '
        Me.tbClienteAlDia.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbClienteAlDia.IsReadOnly = True
        Me.tbClienteAlDia.Location = New System.Drawing.Point(178, 56)
        Me.tbClienteAlDia.Name = "tbClienteAlDia"
        Me.tbClienteAlDia.OffText = "SOCIO EN MORA"
        Me.tbClienteAlDia.OnText = "SOCIO AL DIA"
        Me.tbClienteAlDia.Size = New System.Drawing.Size(157, 22)
        Me.tbClienteAlDia.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.tbClienteAlDia.TabIndex = 210
        Me.tbClienteAlDia.Visible = False
        '
        'LabelX5
        '
        Me.LabelX5.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX5.Location = New System.Drawing.Point(12, 56)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(46, 23)
        Me.LabelX5.TabIndex = 209
        Me.LabelX5.Text = "SOCIO:"
        '
        'tbEsSocio
        '
        '
        '
        '
        Me.tbEsSocio.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbEsSocio.IsReadOnly = True
        Me.tbEsSocio.Location = New System.Drawing.Point(64, 56)
        Me.tbEsSocio.Name = "tbEsSocio"
        Me.tbEsSocio.OffText = "NO"
        Me.tbEsSocio.OnText = "SI"
        Me.tbEsSocio.Size = New System.Drawing.Size(80, 22)
        Me.tbEsSocio.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.tbEsSocio.TabIndex = 148
        '
        'btnVerReclamos
        '
        Me.btnVerReclamos.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnVerReclamos.BackColor = System.Drawing.Color.Transparent
        Me.btnVerReclamos.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnVerReclamos.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnVerReclamos.FadeEffect = False
        Me.btnVerReclamos.FocusCuesEnabled = False
        Me.btnVerReclamos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVerReclamos.Image = Global.Presentacion.My.Resources.Resources.ver_todo
        Me.btnVerReclamos.ImageFixedSize = New System.Drawing.Size(45, 45)
        Me.btnVerReclamos.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btnVerReclamos.Location = New System.Drawing.Point(378, 0)
        Me.btnVerReclamos.Name = "btnVerReclamos"
        Me.btnVerReclamos.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btnVerReclamos.Size = New System.Drawing.Size(72, 91)
        Me.btnVerReclamos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnVerReclamos.TabIndex = 146
        Me.btnVerReclamos.Text = "VER RECLAMOS"
        '
        'btnAddClientes
        '
        Me.btnAddClientes.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnAddClientes.BackColor = System.Drawing.Color.Transparent
        Me.btnAddClientes.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnAddClientes.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnAddClientes.FadeEffect = False
        Me.btnAddClientes.FocusCuesEnabled = False
        Me.btnAddClientes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddClientes.Image = Global.Presentacion.My.Resources.Resources.HOT_CLIENTE
        Me.btnAddClientes.ImageFixedSize = New System.Drawing.Size(45, 45)
        Me.btnAddClientes.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btnAddClientes.Location = New System.Drawing.Point(450, 0)
        Me.btnAddClientes.Name = "btnAddClientes"
        Me.btnAddClientes.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btnAddClientes.Size = New System.Drawing.Size(95, 91)
        Me.btnAddClientes.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnAddClientes.TabIndex = 4
        Me.btnAddClientes.Text = "ADICIONAR HUÉSPEDES"
        '
        'btnAddNuevoCliente
        '
        Me.btnAddNuevoCliente.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnAddNuevoCliente.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat
        Me.btnAddNuevoCliente.Image = Global.Presentacion.My.Resources.Resources.NUEVO
        Me.btnAddNuevoCliente.ImageFixedSize = New System.Drawing.Size(28, 28)
        Me.btnAddNuevoCliente.Location = New System.Drawing.Point(334, 25)
        Me.btnAddNuevoCliente.Name = "btnAddNuevoCliente"
        Me.btnAddNuevoCliente.Size = New System.Drawing.Size(34, 29)
        Me.btnAddNuevoCliente.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnAddNuevoCliente.TabIndex = 147
        '
        'gpDisponibilidad
        '
        Me.gpDisponibilidad.BackColor = System.Drawing.Color.Transparent
        Me.gpDisponibilidad.CanvasColor = System.Drawing.SystemColors.Control
        Me.gpDisponibilidad.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.gpDisponibilidad.Controls.Add(Me.grCabañas)
        Me.gpDisponibilidad.Controls.Add(Me.Panel4)
        Me.gpDisponibilidad.DisabledBackColor = System.Drawing.Color.Empty
        Me.gpDisponibilidad.Dock = System.Windows.Forms.DockStyle.Top
        Me.gpDisponibilidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpDisponibilidad.Location = New System.Drawing.Point(0, 65)
        Me.gpDisponibilidad.Name = "gpDisponibilidad"
        Me.gpDisponibilidad.Size = New System.Drawing.Size(545, 242)
        '
        '
        '
        Me.gpDisponibilidad.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.gpDisponibilidad.Style.BackColorGradientAngle = 90
        Me.gpDisponibilidad.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.gpDisponibilidad.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpDisponibilidad.Style.BorderBottomWidth = 1
        Me.gpDisponibilidad.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.gpDisponibilidad.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpDisponibilidad.Style.BorderLeftWidth = 1
        Me.gpDisponibilidad.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpDisponibilidad.Style.BorderRightWidth = 1
        Me.gpDisponibilidad.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpDisponibilidad.Style.BorderTopWidth = 1
        Me.gpDisponibilidad.Style.CornerDiameter = 4
        Me.gpDisponibilidad.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.gpDisponibilidad.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        '
        '
        '
        Me.gpDisponibilidad.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.gpDisponibilidad.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.gpDisponibilidad.TabIndex = 214
        Me.gpDisponibilidad.Text = "DISPONIBILIDAD DE CABAÑAS"
        '
        'grCabañas
        '
        Me.grCabañas.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.grCabañas.BackColor = System.Drawing.Color.WhiteSmoke
        Me.grCabañas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grCabañas.FlatBorderColor = System.Drawing.Color.DodgerBlue
        Me.grCabañas.FocusCellDisplayMode = Janus.Windows.GridEX.FocusCellDisplayMode.UseSelectedFormatStyle
        Me.grCabañas.FocusCellFormatStyle.ForeColor = System.Drawing.Color.White
        Me.grCabañas.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grCabañas.GridLineColor = System.Drawing.Color.DodgerBlue
        Me.grCabañas.HeaderFormatStyle.Font = New System.Drawing.Font("Georgia", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grCabañas.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight
        Me.grCabañas.Hierarchical = True
        Me.grCabañas.Location = New System.Drawing.Point(0, 85)
        Me.grCabañas.Name = "grCabañas"
        Me.grCabañas.Office2007ColorScheme = Janus.Windows.GridEX.Office2007ColorScheme.Custom
        Me.grCabañas.Office2007CustomColor = System.Drawing.Color.DodgerBlue
        Me.grCabañas.RowFormatStyle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.grCabañas.SelectedFormatStyle.BackColor = System.Drawing.Color.DodgerBlue
        Me.grCabañas.SelectedFormatStyle.ForeColor = System.Drawing.Color.White
        Me.grCabañas.SelectedInactiveFormatStyle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.grCabañas.Size = New System.Drawing.Size(539, 132)
        Me.grCabañas.TabIndex = 216
        Me.grCabañas.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.panelCabaña)
        Me.Panel4.Controls.Add(Me.btnVerDisponibilidad)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(539, 85)
        Me.Panel4.TabIndex = 214
        '
        'panelCabaña
        '
        Me.panelCabaña.Controls.Add(Me.tbTipo)
        Me.panelCabaña.Controls.Add(Me.tbTotal)
        Me.panelCabaña.Controls.Add(Me.LabelX10)
        Me.panelCabaña.Controls.Add(Me.tbPrecio)
        Me.panelCabaña.Controls.Add(Me.LabelX9)
        Me.panelCabaña.Controls.Add(Me.tbCabaña)
        Me.panelCabaña.Controls.Add(Me.lbCabaña)
        Me.panelCabaña.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panelCabaña.Location = New System.Drawing.Point(145, 0)
        Me.panelCabaña.Name = "panelCabaña"
        Me.panelCabaña.Size = New System.Drawing.Size(394, 85)
        Me.panelCabaña.TabIndex = 216
        '
        'tbTipo
        '
        tbTipo_DesignTimeLayout.LayoutString = resources.GetString("tbTipo_DesignTimeLayout.LayoutString")
        Me.tbTipo.DesignTimeLayout = tbTipo_DesignTimeLayout
        Me.tbTipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbTipo.Location = New System.Drawing.Point(144, 29)
        Me.tbTipo.Name = "tbTipo"
        Me.tbTipo.SelectedIndex = -1
        Me.tbTipo.SelectedItem = Nothing
        Me.tbTipo.Size = New System.Drawing.Size(141, 22)
        Me.tbTipo.TabIndex = 222
        '
        'tbTotal
        '
        '
        '
        '
        Me.tbTotal.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.tbTotal.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbTotal.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.tbTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbTotal.Increment = 1.0R
        Me.tbTotal.Location = New System.Drawing.Point(296, 55)
        Me.tbTotal.MinValue = 0R
        Me.tbTotal.Name = "tbTotal"
        Me.tbTotal.Size = New System.Drawing.Size(95, 22)
        Me.tbTotal.TabIndex = 220
        '
        'LabelX10
        '
        Me.LabelX10.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX10.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX10.Location = New System.Drawing.Point(197, 55)
        Me.LabelX10.Name = "LabelX10"
        Me.LabelX10.Size = New System.Drawing.Size(93, 23)
        Me.LabelX10.TabIndex = 219
        Me.LabelX10.Text = "PRECIO TOTAL:"
        '
        'tbPrecio
        '
        '
        '
        '
        Me.tbPrecio.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.tbPrecio.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbPrecio.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.tbPrecio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbPrecio.Increment = 1.0R
        Me.tbPrecio.IsInputReadOnly = True
        Me.tbPrecio.Location = New System.Drawing.Point(296, 29)
        Me.tbPrecio.MinValue = 0R
        Me.tbPrecio.Name = "tbPrecio"
        Me.tbPrecio.Size = New System.Drawing.Size(95, 22)
        Me.tbPrecio.TabIndex = 218
        '
        'LabelX9
        '
        Me.LabelX9.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX9.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX9.Location = New System.Drawing.Point(7, 28)
        Me.LabelX9.Name = "LabelX9"
        Me.LabelX9.Size = New System.Drawing.Size(138, 23)
        Me.LabelX9.TabIndex = 216
        Me.LabelX9.Text = "TIPO TARIFA:"
        '
        'tbCabaña
        '
        Me.tbCabaña.AcceptsTab = True
        '
        '
        '
        Me.tbCabaña.Border.Class = "TextBoxBorder"
        Me.tbCabaña.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbCabaña.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbCabaña.Location = New System.Drawing.Point(144, 4)
        Me.tbCabaña.Name = "tbCabaña"
        Me.tbCabaña.PreventEnterBeep = True
        Me.tbCabaña.Size = New System.Drawing.Size(247, 22)
        Me.tbCabaña.TabIndex = 214
        '
        'lbCabaña
        '
        Me.lbCabaña.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.lbCabaña.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lbCabaña.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbCabaña.Location = New System.Drawing.Point(7, 3)
        Me.lbCabaña.Name = "lbCabaña"
        Me.lbCabaña.Size = New System.Drawing.Size(138, 23)
        Me.lbCabaña.TabIndex = 215
        Me.lbCabaña.Text = "CABAÑA RESERVADA:"
        '
        'btnVerDisponibilidad
        '
        Me.btnVerDisponibilidad.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnVerDisponibilidad.BackColor = System.Drawing.Color.Transparent
        Me.btnVerDisponibilidad.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnVerDisponibilidad.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnVerDisponibilidad.FadeEffect = False
        Me.btnVerDisponibilidad.FocusCuesEnabled = False
        Me.btnVerDisponibilidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVerDisponibilidad.Image = Global.Presentacion.My.Resources.Resources.search
        Me.btnVerDisponibilidad.ImageFixedSize = New System.Drawing.Size(35, 35)
        Me.btnVerDisponibilidad.ImagePosition = DevComponents.DotNetBar.eImagePosition.Right
        Me.btnVerDisponibilidad.Location = New System.Drawing.Point(0, 0)
        Me.btnVerDisponibilidad.Name = "btnVerDisponibilidad"
        Me.btnVerDisponibilidad.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btnVerDisponibilidad.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2)
        Me.btnVerDisponibilidad.Size = New System.Drawing.Size(145, 85)
        Me.btnVerDisponibilidad.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnVerDisponibilidad.TabIndex = 213
        Me.btnVerDisponibilidad.Text = "BUSCAR DISPONIBILIDAD"
        Me.btnVerDisponibilidad.TextColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(66, Byte), Integer))
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.tbNoches)
        Me.Panel3.Controls.Add(Me.LabelX8)
        Me.Panel3.Controls.Add(Me.tbCantPers)
        Me.Panel3.Controls.Add(Me.tbFechaOut)
        Me.Panel3.Controls.Add(Me.tbFechaIn)
        Me.Panel3.Controls.Add(Me.LabelX3)
        Me.Panel3.Controls.Add(Me.LabelX1)
        Me.Panel3.Controls.Add(Me.LabelX2)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(545, 65)
        Me.Panel3.TabIndex = 215
        '
        'tbNoches
        '
        '
        '
        '
        Me.tbNoches.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.tbNoches.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbNoches.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.tbNoches.Location = New System.Drawing.Point(3, 28)
        Me.tbNoches.MinValue = 1
        Me.tbNoches.Name = "tbNoches"
        Me.tbNoches.ShowUpDown = True
        Me.tbNoches.Size = New System.Drawing.Size(54, 22)
        Me.tbNoches.TabIndex = 214
        Me.tbNoches.Value = 1
        Me.tbNoches.Visible = False
        '
        'LabelX8
        '
        Me.LabelX8.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX8.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX8.Location = New System.Drawing.Point(3, 6)
        Me.LabelX8.Name = "LabelX8"
        Me.LabelX8.Size = New System.Drawing.Size(80, 23)
        Me.LabelX8.TabIndex = 213
        Me.LabelX8.Text = "NOCHES"
        Me.LabelX8.Visible = False
        '
        'tbCantPers
        '
        '
        '
        '
        Me.tbCantPers.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.tbCantPers.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbCantPers.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.tbCantPers.Location = New System.Drawing.Point(411, 28)
        Me.tbCantPers.MinValue = 1
        Me.tbCantPers.Name = "tbCantPers"
        Me.tbCantPers.ShowUpDown = True
        Me.tbCantPers.Size = New System.Drawing.Size(80, 22)
        Me.tbCantPers.TabIndex = 212
        Me.tbCantPers.Value = 1
        '
        'tbFechaIn
        '
        Me.tbFechaIn.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbFechaIn.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.tbFechaIn.Location = New System.Drawing.Point(88, 28)
        Me.tbFechaIn.Name = "tbFechaIn"
        Me.tbFechaIn.Size = New System.Drawing.Size(122, 22)
        Me.tbFechaIn.TabIndex = 210
        '
        'LabelX3
        '
        Me.LabelX3.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX3.Location = New System.Drawing.Point(411, 6)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(80, 23)
        Me.LabelX3.TabIndex = 211
        Me.LabelX3.Text = "PERSONAS"
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX1.Location = New System.Drawing.Point(88, 6)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(118, 23)
        Me.LabelX1.TabIndex = 208
        Me.LabelX1.Text = "FECHA INGRESO"
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX2.Location = New System.Drawing.Point(240, 6)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(118, 23)
        Me.LabelX2.TabIndex = 209
        Me.LabelX2.Text = "FECHA SALIDA"
        '
        'F0_HotelReservaFicha
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.ClientSize = New System.Drawing.Size(555, 653)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "F0_HotelReservaFicha"
        Me.Padding = New System.Windows.Forms.Padding(5)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CREAR NUEVO CLIENTE"
        Me.Panel1.ResumeLayout(False)
        CType(Me.MEP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.GroupPanel1.ResumeLayout(False)
        Me.gpSocioRef.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.gpDisponibilidad.ResumeLayout(False)
        CType(Me.grCabañas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.panelCabaña.ResumeLayout(False)
        Me.panelCabaña.PerformLayout()
        CType(Me.tbTipo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbTotal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbPrecio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        CType(Me.tbNoches, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbCantPers, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tbEncargadoRes As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents MEP As System.Windows.Forms.ErrorProvider
    Friend WithEvents MHighlighterFocus As DevComponents.DotNetBar.Validator.Highlighter
    Friend WithEvents MFlyoutUsuario As DevComponents.DotNetBar.Controls.Flyout
    Friend WithEvents Panel2 As Panel
    Friend WithEvents btnVerDisponibilidad As DevComponents.DotNetBar.ButtonX
    Friend WithEvents tbCantPers As DevComponents.Editors.IntegerInput
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents tbFechaIn As DateTimePicker
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents tbFechaOut As DateTimePicker
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents gpDisponibilidad As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents btnAddClientes As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Panel5 As Panel
    Friend WithEvents btnVerReclamos As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnAddNuevoCliente As DevComponents.DotNetBar.ButtonX
    Protected WithEvents btnSalir As DevComponents.DotNetBar.ButtonX
    Protected WithEvents btnGrabar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents tbObs As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents tbLugRes As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents gpSocioRef As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents tbSocioRef As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents tbEsSocio As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents grCabañas As Janus.Windows.GridEX.GridEX
    Friend WithEvents tbCabaña As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents panelCabaña As System.Windows.Forms.Panel
    Friend WithEvents lbCabaña As DevComponents.DotNetBar.LabelX
    Friend WithEvents tbSocioRefAlDia As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents tbClienteAlDia As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents tbUsuarioEncargado As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX7 As DevComponents.DotNetBar.LabelX
    Friend WithEvents tbNoches As DevComponents.Editors.IntegerInput
    Friend WithEvents LabelX8 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX9 As DevComponents.DotNetBar.LabelX
    Friend WithEvents tbPrecio As DevComponents.Editors.DoubleInput
    Friend WithEvents tbTotal As DevComponents.Editors.DoubleInput
    Friend WithEvents LabelX10 As DevComponents.DotNetBar.LabelX
    Friend WithEvents tbTipo As Janus.Windows.GridEX.EditControls.MultiColumnCombo
End Class
