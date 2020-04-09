<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F0_AlumnoInscrip
    Inherits Modelos.ModeloF0

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F0_AlumnoInscrip))
        Dim cbHoraSuc_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cbServicio_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.GroupPanel4 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.JGDetalle = New Janus.Windows.GridEX.GridEX()
        Me.GroupPanel3 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.LabelX10 = New DevComponents.DotNetBar.LabelX()
        Me.tbNGrupo = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX15 = New DevComponents.DotNetBar.LabelX()
        Me.btnAgregar = New DevComponents.DotNetBar.ButtonX()
        Me.cbHoraSuc = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.LabelX11 = New DevComponents.DotNetBar.LabelX()
        Me.cbServicio = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.tbAlumno = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX7 = New DevComponents.DotNetBar.LabelX()
        Me.tbNFactura = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX8 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX9 = New DevComponents.DotNetBar.LabelX()
        Me.tbObservacion = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX25 = New DevComponents.DotNetBar.LabelX()
        Me.dtFecha = New System.Windows.Forms.DateTimePicker()
        Me.tbCodigo = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ELIMINARToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PanelInscripcion = New System.Windows.Forms.Panel()
        Me.GPInscripcion = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.JGInscripcion = New Janus.Windows.GridEX.GridEX()
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
        Me.TableLayoutPanel2.SuspendLayout()
        Me.GroupPanel4.SuspendLayout()
        CType(Me.JGDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.cbHoraSuc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbServicio, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.PanelInscripcion.SuspendLayout()
        Me.GPInscripcion.SuspendLayout()
        Me.Panel6.SuspendLayout()
        CType(Me.JGInscripcion, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.SuperTabPrincipal.Size = New System.Drawing.Size(1144, 608)
        Me.SuperTabPrincipal.Controls.SetChildIndex(Me.SuperTabControlPanelBuscador, 0)
        Me.SuperTabPrincipal.Controls.SetChildIndex(Me.SuperTabControlPanelRegistro, 0)
        '
        'SuperTabControlPanelBuscador
        '
        Me.SuperTabControlPanelBuscador.Controls.Add(Me.PanelInscripcion)
        Me.SuperTabControlPanelBuscador.Size = New System.Drawing.Size(1144, 583)
        '
        'SuperTabControlPanelRegistro
        '
        Me.SuperTabControlPanelRegistro.Size = New System.Drawing.Size(1144, 583)
        Me.SuperTabControlPanelRegistro.Controls.SetChildIndex(Me.PanelSuperior, 0)
        Me.SuperTabControlPanelRegistro.Controls.SetChildIndex(Me.PanelInferior, 0)
        Me.SuperTabControlPanelRegistro.Controls.SetChildIndex(Me.PanelPrincipal, 0)
        '
        'PanelSuperior
        '
        Me.PanelSuperior.Size = New System.Drawing.Size(1144, 72)
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
        Me.PanelInferior.Location = New System.Drawing.Point(0, 547)
        Me.PanelInferior.Size = New System.Drawing.Size(1144, 36)
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
        'PanelToolBar2
        '
        Me.PanelToolBar2.Location = New System.Drawing.Point(1064, 0)
        '
        'PanelPrincipal
        '
        Me.PanelPrincipal.Controls.Add(Me.TableLayoutPanel2)
        Me.PanelPrincipal.Size = New System.Drawing.Size(1144, 475)
        Me.PanelPrincipal.Controls.SetChildIndex(Me.PanelUsuario, 0)
        Me.PanelPrincipal.Controls.SetChildIndex(Me.TableLayoutPanel2, 0)
        '
        'btnImprimir
        '
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
        'MPanelUserAct
        '
        Me.MPanelUserAct.Location = New System.Drawing.Point(944, 0)
        '
        'MRlAccion
        '
        '
        '
        '
        Me.MRlAccion.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 1
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.GroupPanel4, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.GroupPanel3, 0, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 2
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(1144, 475)
        Me.TableLayoutPanel2.TabIndex = 237
        '
        'GroupPanel4
        '
        Me.GroupPanel4.AccessibleName = "Identificacion"
        Me.GroupPanel4.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel4.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel4.Controls.Add(Me.JGDetalle)
        Me.GroupPanel4.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupPanel4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupPanel4.Location = New System.Drawing.Point(3, 240)
        Me.GroupPanel4.Name = "GroupPanel4"
        Me.GroupPanel4.Size = New System.Drawing.Size(1138, 232)
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
        Me.GroupPanel4.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
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
        Me.GroupPanel4.TabIndex = 247
        Me.GroupPanel4.Text = "DETALLE"
        '
        'JGDetalle
        '
        Me.JGDetalle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.JGDetalle.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.JGDetalle.Location = New System.Drawing.Point(0, 0)
        Me.JGDetalle.Name = "JGDetalle"
        Me.JGDetalle.Office2007ColorScheme = Janus.Windows.GridEX.Office2007ColorScheme.Custom
        Me.JGDetalle.Office2007CustomColor = System.Drawing.Color.DodgerBlue
        Me.JGDetalle.Size = New System.Drawing.Size(1132, 207)
        Me.JGDetalle.TabIndex = 0
        '
        'GroupPanel3
        '
        Me.GroupPanel3.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel3.Controls.Add(Me.Panel4)
        Me.GroupPanel3.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupPanel3.Font = New System.Drawing.Font("Georgia", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupPanel3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.GroupPanel3.Location = New System.Drawing.Point(3, 3)
        Me.GroupPanel3.Name = "GroupPanel3"
        Me.GroupPanel3.Size = New System.Drawing.Size(1138, 231)
        '
        '
        '
        Me.GroupPanel3.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.MenuBackground
        Me.GroupPanel3.Style.BackColorGradientAngle = 90
        Me.GroupPanel3.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarCaptionText
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
        Me.GroupPanel3.TabIndex = 227
        Me.GroupPanel3.Text = "DATOS INSCRIPCIÓN"
        '
        'Panel4
        '
        Me.Panel4.AutoScroll = True
        Me.Panel4.Controls.Add(Me.Panel1)
        Me.Panel4.Controls.Add(Me.tbAlumno)
        Me.Panel4.Controls.Add(Me.LabelX1)
        Me.Panel4.Controls.Add(Me.LabelX2)
        Me.Panel4.Controls.Add(Me.LabelX7)
        Me.Panel4.Controls.Add(Me.tbNFactura)
        Me.Panel4.Controls.Add(Me.LabelX8)
        Me.Panel4.Controls.Add(Me.LabelX9)
        Me.Panel4.Controls.Add(Me.tbObservacion)
        Me.Panel4.Controls.Add(Me.LabelX25)
        Me.Panel4.Controls.Add(Me.dtFecha)
        Me.Panel4.Controls.Add(Me.tbCodigo)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1132, 208)
        Me.Panel4.TabIndex = 234
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.LabelX10)
        Me.Panel1.Controls.Add(Me.tbNGrupo)
        Me.Panel1.Controls.Add(Me.LabelX15)
        Me.Panel1.Controls.Add(Me.btnAgregar)
        Me.Panel1.Controls.Add(Me.cbHoraSuc)
        Me.Panel1.Controls.Add(Me.LabelX11)
        Me.Panel1.Controls.Add(Me.cbServicio)
        Me.Panel1.Location = New System.Drawing.Point(519, 8)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(573, 192)
        Me.Panel1.TabIndex = 259
        '
        'LabelX10
        '
        Me.LabelX10.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX10.Font = New System.Drawing.Font("Georgia", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.LabelX10.Location = New System.Drawing.Point(35, 19)
        Me.LabelX10.Name = "LabelX10"
        Me.LabelX10.SingleLineColor = System.Drawing.SystemColors.Control
        Me.LabelX10.Size = New System.Drawing.Size(116, 23)
        Me.LabelX10.TabIndex = 251
        Me.LabelX10.Text = "Horario-Sucursal:"
        '
        'tbNGrupo
        '
        '
        '
        '
        Me.tbNGrupo.Border.Class = "TextBoxBorder"
        Me.tbNGrupo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbNGrupo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbNGrupo.Location = New System.Drawing.Point(180, 101)
        Me.tbNGrupo.Name = "tbNGrupo"
        Me.tbNGrupo.PreventEnterBeep = True
        Me.tbNGrupo.Size = New System.Drawing.Size(338, 22)
        Me.tbNGrupo.TabIndex = 258
        '
        'LabelX15
        '
        Me.LabelX15.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX15.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX15.Font = New System.Drawing.Font("Georgia", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX15.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.LabelX15.Location = New System.Drawing.Point(35, 98)
        Me.LabelX15.Name = "LabelX15"
        Me.LabelX15.SingleLineColor = System.Drawing.SystemColors.Control
        Me.LabelX15.Size = New System.Drawing.Size(104, 23)
        Me.LabelX15.TabIndex = 225
        Me.LabelX15.Text = "Nro. Grupo:"
        '
        'btnAgregar
        '
        Me.btnAgregar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnAgregar.BackColor = System.Drawing.Color.Transparent
        Me.btnAgregar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnAgregar.FadeEffect = False
        Me.btnAgregar.FocusCuesEnabled = False
        Me.btnAgregar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregar.Image = CType(resources.GetObject("btnAgregar.Image"), System.Drawing.Image)
        Me.btnAgregar.ImageFixedSize = New System.Drawing.Size(20, 20)
        Me.btnAgregar.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btnAgregar.Location = New System.Drawing.Point(180, 141)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btnAgregar.Size = New System.Drawing.Size(158, 41)
        Me.btnAgregar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnAgregar.TabIndex = 247
        Me.btnAgregar.Text = "AGREGAR"
        '
        'cbHoraSuc
        '
        cbHoraSuc_DesignTimeLayout.LayoutString = resources.GetString("cbHoraSuc_DesignTimeLayout.LayoutString")
        Me.cbHoraSuc.DesignTimeLayout = cbHoraSuc_DesignTimeLayout
        Me.cbHoraSuc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbHoraSuc.Location = New System.Drawing.Point(180, 21)
        Me.cbHoraSuc.Name = "cbHoraSuc"
        Me.cbHoraSuc.SelectedIndex = -1
        Me.cbHoraSuc.SelectedItem = Nothing
        Me.cbHoraSuc.Size = New System.Drawing.Size(338, 22)
        Me.cbHoraSuc.TabIndex = 249
        '
        'LabelX11
        '
        Me.LabelX11.AutoSize = True
        Me.LabelX11.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX11.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX11.Font = New System.Drawing.Font("Georgia", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.LabelX11.Location = New System.Drawing.Point(35, 65)
        Me.LabelX11.Name = "LabelX11"
        Me.LabelX11.SingleLineColor = System.Drawing.SystemColors.Control
        Me.LabelX11.Size = New System.Drawing.Size(57, 16)
        Me.LabelX11.TabIndex = 255
        Me.LabelX11.Text = "Servicio:"
        '
        'cbServicio
        '
        cbServicio_DesignTimeLayout.LayoutString = resources.GetString("cbServicio_DesignTimeLayout.LayoutString")
        Me.cbServicio.DesignTimeLayout = cbServicio_DesignTimeLayout
        Me.cbServicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbServicio.Location = New System.Drawing.Point(180, 61)
        Me.cbServicio.Name = "cbServicio"
        Me.cbServicio.SelectedIndex = -1
        Me.cbServicio.SelectedItem = Nothing
        Me.cbServicio.Size = New System.Drawing.Size(338, 22)
        Me.cbServicio.TabIndex = 252
        '
        'tbAlumno
        '
        '
        '
        '
        Me.tbAlumno.Border.Class = "TextBoxBorder"
        Me.tbAlumno.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbAlumno.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbAlumno.Location = New System.Drawing.Point(158, 64)
        Me.tbAlumno.Name = "tbAlumno"
        Me.tbAlumno.PreventEnterBeep = True
        Me.tbAlumno.Size = New System.Drawing.Size(300, 22)
        Me.tbAlumno.TabIndex = 257
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Georgia", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.LabelX1.Location = New System.Drawing.Point(313, 94)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.SingleLineColor = System.Drawing.SystemColors.Control
        Me.LabelX1.Size = New System.Drawing.Size(57, 23)
        Me.LabelX1.TabIndex = 256
        Me.LabelX1.Text = "Ctrl+Enter:"
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Font = New System.Drawing.Font("Georgia", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.LabelX2.Location = New System.Drawing.Point(13, 65)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.SingleLineColor = System.Drawing.SystemColors.Control
        Me.LabelX2.Size = New System.Drawing.Size(116, 23)
        Me.LabelX2.TabIndex = 240
        Me.LabelX2.Text = "Alumno:"
        '
        'LabelX7
        '
        Me.LabelX7.AutoSize = True
        Me.LabelX7.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX7.Font = New System.Drawing.Font("Georgia", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.LabelX7.Location = New System.Drawing.Point(13, 98)
        Me.LabelX7.Name = "LabelX7"
        Me.LabelX7.SingleLineColor = System.Drawing.SystemColors.Control
        Me.LabelX7.Size = New System.Drawing.Size(86, 16)
        Me.LabelX7.TabIndex = 235
        Me.LabelX7.Text = "Nro. Factura:"
        '
        'tbNFactura
        '
        Me.tbNFactura.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.tbNFactura.Border.Class = "TextBoxBorder"
        Me.tbNFactura.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbNFactura.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbNFactura.ForeColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.tbNFactura.Location = New System.Drawing.Point(158, 95)
        Me.tbNFactura.Name = "tbNFactura"
        Me.tbNFactura.PreventEnterBeep = True
        Me.tbNFactura.ReadOnly = True
        Me.tbNFactura.Size = New System.Drawing.Size(149, 22)
        Me.tbNFactura.TabIndex = 4
        '
        'LabelX8
        '
        Me.LabelX8.AutoSize = True
        Me.LabelX8.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX8.Font = New System.Drawing.Font("Georgia", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.LabelX8.Location = New System.Drawing.Point(13, 13)
        Me.LabelX8.Name = "LabelX8"
        Me.LabelX8.SingleLineColor = System.Drawing.SystemColors.Control
        Me.LabelX8.Size = New System.Drawing.Size(50, 16)
        Me.LabelX8.TabIndex = 224
        Me.LabelX8.Text = "Código:"
        '
        'LabelX9
        '
        Me.LabelX9.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX9.Font = New System.Drawing.Font("Georgia", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.LabelX9.Location = New System.Drawing.Point(13, 125)
        Me.LabelX9.Name = "LabelX9"
        Me.LabelX9.SingleLineColor = System.Drawing.SystemColors.Control
        Me.LabelX9.Size = New System.Drawing.Size(110, 23)
        Me.LabelX9.TabIndex = 233
        Me.LabelX9.Text = "Observación:"
        '
        'tbObservacion
        '
        '
        '
        '
        Me.tbObservacion.Border.Class = "TextBoxBorder"
        Me.tbObservacion.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbObservacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbObservacion.ForeColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.tbObservacion.Location = New System.Drawing.Point(158, 126)
        Me.tbObservacion.Multiline = True
        Me.tbObservacion.Name = "tbObservacion"
        Me.tbObservacion.PreventEnterBeep = True
        Me.tbObservacion.Size = New System.Drawing.Size(300, 57)
        Me.tbObservacion.TabIndex = 8
        '
        'LabelX25
        '
        Me.LabelX25.AutoSize = True
        Me.LabelX25.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX25.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX25.Font = New System.Drawing.Font("Georgia", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX25.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.LabelX25.Location = New System.Drawing.Point(13, 40)
        Me.LabelX25.Name = "LabelX25"
        Me.LabelX25.SingleLineColor = System.Drawing.SystemColors.Control
        Me.LabelX25.Size = New System.Drawing.Size(44, 16)
        Me.LabelX25.TabIndex = 245
        Me.LabelX25.Text = "Fecha:"
        '
        'dtFecha
        '
        Me.dtFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtFecha.Location = New System.Drawing.Point(158, 36)
        Me.dtFecha.Name = "dtFecha"
        Me.dtFecha.Size = New System.Drawing.Size(85, 22)
        Me.dtFecha.TabIndex = 8
        Me.dtFecha.TabStop = False
        '
        'tbCodigo
        '
        '
        '
        '
        Me.tbCodigo.Border.Class = "TextBoxBorder"
        Me.tbCodigo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbCodigo.Enabled = False
        Me.tbCodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbCodigo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.tbCodigo.Location = New System.Drawing.Point(158, 8)
        Me.tbCodigo.Name = "tbCodigo"
        Me.tbCodigo.PreventEnterBeep = True
        Me.tbCodigo.Size = New System.Drawing.Size(77, 22)
        Me.tbCodigo.TabIndex = 0
        Me.tbCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ELIMINARToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(141, 40)
        '
        'ELIMINARToolStripMenuItem
        '
        Me.ELIMINARToolStripMenuItem.Image = Global.Presentacion.My.Resources.Resources.elim_fila2
        Me.ELIMINARToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ELIMINARToolStripMenuItem.Name = "ELIMINARToolStripMenuItem"
        Me.ELIMINARToolStripMenuItem.Size = New System.Drawing.Size(140, 36)
        Me.ELIMINARToolStripMenuItem.Text = "ELIMINAR"
        '
        'PanelInscripcion
        '
        Me.PanelInscripcion.AutoScroll = True
        Me.PanelInscripcion.BackColor = System.Drawing.Color.White
        Me.PanelInscripcion.Controls.Add(Me.GPInscripcion)
        Me.PanelInscripcion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelInscripcion.Location = New System.Drawing.Point(0, 0)
        Me.PanelInscripcion.Name = "PanelInscripcion"
        Me.PanelInscripcion.Size = New System.Drawing.Size(1144, 583)
        Me.PanelInscripcion.TabIndex = 1
        '
        'GPInscripcion
        '
        Me.GPInscripcion.CanvasColor = System.Drawing.SystemColors.Control
        Me.GPInscripcion.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GPInscripcion.Controls.Add(Me.Panel6)
        Me.GPInscripcion.DisabledBackColor = System.Drawing.Color.Empty
        Me.GPInscripcion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GPInscripcion.Font = New System.Drawing.Font("Georgia", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GPInscripcion.Location = New System.Drawing.Point(0, 0)
        Me.GPInscripcion.Name = "GPInscripcion"
        Me.GPInscripcion.Size = New System.Drawing.Size(1144, 583)
        '
        '
        '
        Me.GPInscripcion.Style.BackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.GPInscripcion.Style.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.GPInscripcion.Style.BackColorGradientAngle = 90
        Me.GPInscripcion.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GPInscripcion.Style.BorderBottomWidth = 1
        Me.GPInscripcion.Style.BorderColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.GPInscripcion.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GPInscripcion.Style.BorderLeftWidth = 1
        Me.GPInscripcion.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GPInscripcion.Style.BorderRightWidth = 1
        Me.GPInscripcion.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GPInscripcion.Style.BorderTopWidth = 1
        Me.GPInscripcion.Style.CornerDiameter = 4
        Me.GPInscripcion.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GPInscripcion.Style.Font = New System.Drawing.Font("Georgia", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GPInscripcion.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GPInscripcion.Style.TextColor = System.Drawing.Color.White
        Me.GPInscripcion.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GPInscripcion.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GPInscripcion.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GPInscripcion.TabIndex = 3
        Me.GPInscripcion.Text = "BUSCADOR  INSCRIPCIÓN"
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.White
        Me.Panel6.Controls.Add(Me.JGInscripcion)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel6.Location = New System.Drawing.Point(0, 0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(1138, 560)
        Me.Panel6.TabIndex = 0
        '
        'JGInscripcion
        '
        Me.JGInscripcion.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.JGInscripcion.BackColor = System.Drawing.Color.GhostWhite
        Me.JGInscripcion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.JGInscripcion.EnterKeyBehavior = Janus.Windows.GridEX.EnterKeyBehavior.None
        Me.JGInscripcion.FocusStyle = Janus.Windows.GridEX.FocusStyle.Solid
        Me.JGInscripcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.JGInscripcion.GroupRowVisualStyle = Janus.Windows.GridEX.GroupRowVisualStyle.UseRowStyle
        Me.JGInscripcion.HeaderFormatStyle.Font = New System.Drawing.Font("Georgia", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.JGInscripcion.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight
        Me.JGInscripcion.Location = New System.Drawing.Point(0, 0)
        Me.JGInscripcion.Name = "JGInscripcion"
        Me.JGInscripcion.Office2007ColorScheme = Janus.Windows.GridEX.Office2007ColorScheme.Custom
        Me.JGInscripcion.Office2007CustomColor = System.Drawing.Color.DodgerBlue
        Me.JGInscripcion.SelectedFormatStyle.BackColor = System.Drawing.Color.DodgerBlue
        Me.JGInscripcion.SelectedFormatStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.JGInscripcion.SelectedFormatStyle.ForeColor = System.Drawing.Color.White
        Me.JGInscripcion.SelectOnExpand = False
        Me.JGInscripcion.Size = New System.Drawing.Size(1138, 560)
        Me.JGInscripcion.TabIndex = 0
        Me.JGInscripcion.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'F0_AlumnoInscrip
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1144, 608)
        Me.Name = "F0_AlumnoInscrip"
        Me.Text = "F1_AlumnoInscrip"
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
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.GroupPanel4.ResumeLayout(False)
        CType(Me.JGDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel3.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.cbHoraSuc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbServicio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.PanelInscripcion.ResumeLayout(False)
        Me.GPInscripcion.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        CType(Me.JGInscripcion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents GroupPanel3 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents LabelX11 As DevComponents.DotNetBar.LabelX
    Friend WithEvents cbServicio As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents LabelX10 As DevComponents.DotNetBar.LabelX
    Friend WithEvents cbHoraSuc As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents btnAgregar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX7 As DevComponents.DotNetBar.LabelX
    Friend WithEvents tbNFactura As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX8 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX9 As DevComponents.DotNetBar.LabelX
    Friend WithEvents tbObservacion As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX25 As DevComponents.DotNetBar.LabelX
    Friend WithEvents dtFecha As DateTimePicker
    Friend WithEvents LabelX15 As DevComponents.DotNetBar.LabelX
    Friend WithEvents tbCodigo As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents tbAlumno As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents tbNGrupo As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents ELIMINARToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PanelInscripcion As Panel
    Friend WithEvents GPInscripcion As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Panel6 As Panel
    Friend WithEvents JGInscripcion As Janus.Windows.GridEX.GridEX
    Friend WithEvents GroupPanel4 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents JGDetalle As Janus.Windows.GridEX.GridEX
    Friend WithEvents Panel1 As Panel
End Class
