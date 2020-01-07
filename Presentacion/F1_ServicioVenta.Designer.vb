<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F1_ServicioVenta
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
        Dim cbTipoCliente_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cbventa_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim SuperTabColorTable1 As DevComponents.DotNetBar.Rendering.SuperTabColorTable = New DevComponents.DotNetBar.Rendering.SuperTabColorTable()
        Dim SuperTabLinearGradientColorTable1 As DevComponents.DotNetBar.Rendering.SuperTabLinearGradientColorTable = New DevComponents.DotNetBar.Rendering.SuperTabLinearGradientColorTable()
        Dim cbTipoVehiculoR_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F1_ServicioVenta))
        Dim cbTamanoR_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.GpDetalle = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.grDetalle = New Janus.Windows.GridEX.GridEX()
        Me.cmOpciones = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Eliminarms = New System.Windows.Forms.ToolStripMenuItem()
        Me.tbnumiCliente = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.tbCliente = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Estado = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.LabelX10 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX8 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        Me.FechaVenta = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.tbCodigo = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.GpVentasSinCobrar = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.SuperTabControl1 = New DevComponents.DotNetBar.SuperTabControl()
        Me.SuperTabControlPanel1 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.grVentasPendientes = New Janus.Windows.GridEX.GridEX()
        Me.SuperTabItem1 = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabControlPanel2 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.grPolitica = New Janus.Windows.GridEX.GridEX()
        Me.SuperTabItem2 = New DevComponents.DotNetBar.SuperTabItem()
        Me.ButtonX2 = New DevComponents.DotNetBar.ButtonX()
        Me.ButtonX1 = New DevComponents.DotNetBar.ButtonX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.tbnumiVehiculo = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.tbVehiculo = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.cbTipo = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.btnAnadir = New DevComponents.DotNetBar.ButtonX()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.tbNumeroOrden = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.lbFechaPago = New DevComponents.DotNetBar.LabelX()
        Me.tbFechaPago = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.PanelDatos = New System.Windows.Forms.Panel()
        Me.swServicios = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.LabelX16 = New DevComponents.DotNetBar.LabelX()
        Me.cbTipoCliente = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.tbObservacion = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.lboservacion = New DevComponents.DotNetBar.LabelX()
        Me.tbbanco = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.lbbanco = New DevComponents.DotNetBar.LabelX()
        Me.lbcredito = New DevComponents.DotNetBar.LabelX()
        Me.tbcredito = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.LabelX15 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX14 = New DevComponents.DotNetBar.LabelX()
        Me.cbmoneda = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.cbventa = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.tbTablet = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.lbUltimaPago = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.UsImg = New Presentacion.Us_Image()
        Me.PanelDatosTop = New System.Windows.Forms.Panel()
        Me.PanelButton = New System.Windows.Forms.Panel()
        Me.GpPanelServicio = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.grProducto = New Janus.Windows.GridEX.GridEX()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.PanelCombos = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel24 = New System.Windows.Forms.Panel()
        Me.Panel21 = New System.Windows.Forms.Panel()
        Me.cbb13 = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.cb13 = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.lb13 = New DevComponents.DotNetBar.LabelX()
        Me.lb14 = New DevComponents.DotNetBar.LabelX()
        Me.Panel16 = New System.Windows.Forms.Panel()
        Me.cbb18 = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.cb18 = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.lb15 = New DevComponents.DotNetBar.LabelX()
        Me.Panel17 = New System.Windows.Forms.Panel()
        Me.cbb17 = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.cb17 = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.lb16 = New DevComponents.DotNetBar.LabelX()
        Me.Panel18 = New System.Windows.Forms.Panel()
        Me.cbb16 = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.cb16 = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.lb17 = New DevComponents.DotNetBar.LabelX()
        Me.Panel19 = New System.Windows.Forms.Panel()
        Me.cbb15 = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.cb15 = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.lb18 = New DevComponents.DotNetBar.LabelX()
        Me.Panel20 = New System.Windows.Forms.Panel()
        Me.cbb14 = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.cb14 = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Panel22 = New System.Windows.Forms.Panel()
        Me.lb1 = New DevComponents.DotNetBar.LabelX()
        Me.lb2 = New DevComponents.DotNetBar.LabelX()
        Me.lb3 = New DevComponents.DotNetBar.LabelX()
        Me.lb4 = New DevComponents.DotNetBar.LabelX()
        Me.lb5 = New DevComponents.DotNetBar.LabelX()
        Me.lb6 = New DevComponents.DotNetBar.LabelX()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.cbb1 = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.cb1 = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.cbb2 = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.cb2 = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.cbb3 = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.cb3 = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.cbb4 = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.cb4 = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.cbb5 = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.cb5 = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.cbb6 = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.cb6 = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Panel23 = New System.Windows.Forms.Panel()
        Me.lb7 = New DevComponents.DotNetBar.LabelX()
        Me.lb8 = New DevComponents.DotNetBar.LabelX()
        Me.lb9 = New DevComponents.DotNetBar.LabelX()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.cbb12 = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.cb12 = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.lb10 = New DevComponents.DotNetBar.LabelX()
        Me.lb11 = New DevComponents.DotNetBar.LabelX()
        Me.Panel11 = New System.Windows.Forms.Panel()
        Me.cbb11 = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.cb11 = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.lb12 = New DevComponents.DotNetBar.LabelX()
        Me.Panel15 = New System.Windows.Forms.Panel()
        Me.cbb7 = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.cb7 = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Panel12 = New System.Windows.Forms.Panel()
        Me.cbb10 = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.cb10 = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Panel14 = New System.Windows.Forms.Panel()
        Me.cbb8 = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.cb8 = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Panel13 = New System.Windows.Forms.Panel()
        Me.cbb9 = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.cb9 = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.GroupPanel2 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.SuperTabControl2 = New DevComponents.DotNetBar.SuperTabControl()
        Me.SuperTabControlPanel3 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.Panel26 = New System.Windows.Forms.Panel()
        Me.pbImgProdu = New System.Windows.Forms.PictureBox()
        Me.panelA = New System.Windows.Forms.Panel()
        Me.SuperTabItem3 = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabControlPanel4 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.GridEX1 = New Janus.Windows.GridEX.GridEX()
        Me.SuperTabItem4 = New DevComponents.DotNetBar.SuperTabItem()
        Me.GroupPanel3 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Panel25 = New System.Windows.Forms.Panel()
        Me.tbObservacionR = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX26 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.cbTipoVehiculoR = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.tbPlacaR = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.tbFechaR = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX7 = New DevComponents.DotNetBar.LabelX()
        Me.cbTamanoR = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.SwClienteR = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.tbMarcaR = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX9 = New DevComponents.DotNetBar.LabelX()
        Me.TextBoxX1 = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.TextBoxX2 = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.tbClienteR = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX11 = New DevComponents.DotNetBar.LabelX()
        Me.tbNroOrdenR = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX12 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX13 = New DevComponents.DotNetBar.LabelX()
        CType(Me.SuperTabPrincipal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuperTabPrincipal.SuspendLayout()
        Me.SuperTabControlPanelBuscador.SuspendLayout()
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
        Me.GpDetalle.SuspendLayout()
        CType(Me.grDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmOpciones.SuspendLayout()
        CType(Me.FechaVenta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GpVentasSinCobrar.SuspendLayout()
        CType(Me.SuperTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuperTabControl1.SuspendLayout()
        Me.SuperTabControlPanel1.SuspendLayout()
        CType(Me.grVentasPendientes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuperTabControlPanel2.SuspendLayout()
        CType(Me.grPolitica, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbTipo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelDatos.SuspendLayout()
        CType(Me.cbTipoCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbcredito, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbventa, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelDatosTop.SuspendLayout()
        Me.PanelButton.SuspendLayout()
        Me.GpPanelServicio.SuspendLayout()
        CType(Me.grProducto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.GroupPanel1.SuspendLayout()
        Me.PanelCombos.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel24.SuspendLayout()
        Me.Panel21.SuspendLayout()
        Me.Panel16.SuspendLayout()
        Me.Panel17.SuspendLayout()
        Me.Panel18.SuspendLayout()
        Me.Panel19.SuspendLayout()
        Me.Panel20.SuspendLayout()
        Me.Panel22.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.Panel8.SuspendLayout()
        Me.Panel9.SuspendLayout()
        Me.Panel23.SuspendLayout()
        Me.Panel10.SuspendLayout()
        Me.Panel11.SuspendLayout()
        Me.Panel15.SuspendLayout()
        Me.Panel12.SuspendLayout()
        Me.Panel14.SuspendLayout()
        Me.Panel13.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.GroupPanel2.SuspendLayout()
        CType(Me.SuperTabControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuperTabControl2.SuspendLayout()
        Me.SuperTabControlPanel3.SuspendLayout()
        Me.Panel26.SuspendLayout()
        CType(Me.pbImgProdu, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuperTabControlPanel4.SuspendLayout()
        CType(Me.GridEX1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel3.SuspendLayout()
        Me.Panel25.SuspendLayout()
        CType(Me.cbTipoVehiculoR, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbFechaR, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbTamanoR, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.SuperTabPrincipal.Margin = New System.Windows.Forms.Padding(4)
        Me.SuperTabPrincipal.SelectedTabIndex = 1
        Me.SuperTabPrincipal.Size = New System.Drawing.Size(1028, 609)
        Me.SuperTabPrincipal.Controls.SetChildIndex(Me.SuperTabControlPanelBuscador, 0)
        Me.SuperTabPrincipal.Controls.SetChildIndex(Me.SuperTabControlPanelRegistro, 0)
        '
        'SuperTabControlPanelBuscador
        '
        Me.SuperTabControlPanelBuscador.Controls.Add(Me.Panel1)
        Me.SuperTabControlPanelBuscador.Location = New System.Drawing.Point(0, 23)
        Me.SuperTabControlPanelBuscador.Margin = New System.Windows.Forms.Padding(4)
        Me.SuperTabControlPanelBuscador.Size = New System.Drawing.Size(1028, 587)
        '
        'SupTabItemBusqueda
        '
        Me.SupTabItemBusqueda.Text = "RECEPCION"
        '
        'SuperTabControlPanelRegistro
        '
        Me.SuperTabControlPanelRegistro.Margin = New System.Windows.Forms.Padding(4)
        Me.SuperTabControlPanelRegistro.Size = New System.Drawing.Size(1028, 584)
        Me.SuperTabControlPanelRegistro.Controls.SetChildIndex(Me.PanelSuperior, 0)
        Me.SuperTabControlPanelRegistro.Controls.SetChildIndex(Me.PanelInferior, 0)
        Me.SuperTabControlPanelRegistro.Controls.SetChildIndex(Me.PanelPrincipal, 0)
        '
        'PanelSuperior
        '
        Me.PanelSuperior.Margin = New System.Windows.Forms.Padding(4)
        Me.PanelSuperior.Size = New System.Drawing.Size(1028, 72)
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
        Me.PanelInferior.Controls.Add(Me.ButtonX2)
        Me.PanelInferior.Controls.Add(Me.ButtonX1)
        Me.PanelInferior.Location = New System.Drawing.Point(0, 548)
        Me.PanelInferior.Margin = New System.Windows.Forms.Padding(4)
        Me.PanelInferior.Size = New System.Drawing.Size(1028, 36)
        Me.PanelInferior.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelInferior.Style.BackColor1.Color = System.Drawing.Color.Gold
        Me.PanelInferior.Style.BackColor2.Color = System.Drawing.Color.Gold
        Me.PanelInferior.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelInferior.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelInferior.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelInferior.Style.GradientAngle = 90
        Me.PanelInferior.Controls.SetChildIndex(Me.PanelNavegacion, 0)
        Me.PanelInferior.Controls.SetChildIndex(Me.MPanelUserAct, 0)
        Me.PanelInferior.Controls.SetChildIndex(Me.ButtonX1, 0)
        Me.PanelInferior.Controls.SetChildIndex(Me.ButtonX2, 0)
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
        'btnModificar
        '
        '
        'btnNuevo
        '
        '
        'PanelToolBar2
        '
        Me.PanelToolBar2.Location = New System.Drawing.Point(948, 0)
        Me.PanelToolBar2.Margin = New System.Windows.Forms.Padding(4)
        '
        'MPanelSup
        '
        Me.MPanelSup.Controls.Add(Me.PanelButton)
        Me.MPanelSup.Controls.Add(Me.PanelDatosTop)
        Me.MPanelSup.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MPanelSup.Margin = New System.Windows.Forms.Padding(4)
        Me.MPanelSup.Size = New System.Drawing.Size(1028, 476)
        Me.MPanelSup.Controls.SetChildIndex(Me.PanelUsuario, 0)
        Me.MPanelSup.Controls.SetChildIndex(Me.PanelDatosTop, 0)
        Me.MPanelSup.Controls.SetChildIndex(Me.PanelButton, 0)
        '
        'PanelPrincipal
        '
        Me.PanelPrincipal.Margin = New System.Windows.Forms.Padding(4)
        Me.PanelPrincipal.Size = New System.Drawing.Size(1028, 476)
        '
        'GroupPanelBuscador
        '
        Me.GroupPanelBuscador.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupPanelBuscador.Location = New System.Drawing.Point(0, 0)
        Me.GroupPanelBuscador.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupPanelBuscador.Size = New System.Drawing.Size(1028, 476)
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
        Me.GroupPanelBuscador.Visible = False
        '
        'JGrM_Buscador
        '
        Me.JGrM_Buscador.FocusStyle = Janus.Windows.GridEX.FocusStyle.Solid
        Me.JGrM_Buscador.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.JGrM_Buscador.HeaderFormatStyle.Font = New System.Drawing.Font("Georgia", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.JGrM_Buscador.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight
        Me.JGrM_Buscador.Margin = New System.Windows.Forms.Padding(4)
        Me.JGrM_Buscador.Office2007ColorScheme = Janus.Windows.GridEX.Office2007ColorScheme.Custom
        Me.JGrM_Buscador.Office2007CustomColor = System.Drawing.Color.DodgerBlue
        Me.JGrM_Buscador.SelectedFormatStyle.BackColor = System.Drawing.Color.DodgerBlue
        Me.JGrM_Buscador.SelectedFormatStyle.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.JGrM_Buscador.SelectedFormatStyle.ForeColor = System.Drawing.Color.White
        Me.JGrM_Buscador.Size = New System.Drawing.Size(1022, 450)
        Me.JGrM_Buscador.Visible = False
        Me.JGrM_Buscador.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'PanelUsuario
        '
        Me.PanelUsuario.Location = New System.Drawing.Point(1128, 23)
        Me.PanelUsuario.Margin = New System.Windows.Forms.Padding(4)
        '
        'btnImprimir
        '
        '
        'btnUltimo
        '
        Me.btnUltimo.Margin = New System.Windows.Forms.Padding(2)
        '
        'MPanelUserAct
        '
        Me.MPanelUserAct.Location = New System.Drawing.Point(828, 0)
        Me.MPanelUserAct.Margin = New System.Windows.Forms.Padding(4)
        '
        'GpDetalle
        '
        Me.GpDetalle.CanvasColor = System.Drawing.SystemColors.Control
        Me.GpDetalle.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GpDetalle.Controls.Add(Me.grDetalle)
        Me.GpDetalle.DisabledBackColor = System.Drawing.Color.Empty
        Me.GpDetalle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GpDetalle.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GpDetalle.Location = New System.Drawing.Point(0, 0)
        Me.GpDetalle.Name = "GpDetalle"
        Me.GpDetalle.Padding = New System.Windows.Forms.Padding(5)
        Me.GpDetalle.Size = New System.Drawing.Size(1028, 12)
        '
        '
        '
        Me.GpDetalle.Style.BackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.GpDetalle.Style.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.GpDetalle.Style.BackColorGradientAngle = 90
        Me.GpDetalle.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GpDetalle.Style.BorderBottomWidth = 1
        Me.GpDetalle.Style.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.GpDetalle.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GpDetalle.Style.BorderLeftWidth = 1
        Me.GpDetalle.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GpDetalle.Style.BorderRightWidth = 1
        Me.GpDetalle.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GpDetalle.Style.BorderTopWidth = 1
        Me.GpDetalle.Style.CornerDiameter = 0
        Me.GpDetalle.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GpDetalle.Style.Font = New System.Drawing.Font("Georgia", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GpDetalle.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GpDetalle.Style.TextColor = System.Drawing.Color.White
        Me.GpDetalle.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GpDetalle.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GpDetalle.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GpDetalle.TabIndex = 7
        Me.GpDetalle.Text = "D E T A L L E"
        '
        'grDetalle
        '
        Me.grDetalle.ContextMenuStrip = Me.cmOpciones
        Me.grDetalle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grDetalle.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grDetalle.HeaderFormatStyle.Font = New System.Drawing.Font("Georgia", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grDetalle.Location = New System.Drawing.Point(5, 5)
        Me.grDetalle.Name = "grDetalle"
        Me.grDetalle.Office2007ColorScheme = Janus.Windows.GridEX.Office2007ColorScheme.Custom
        Me.grDetalle.Office2007CustomColor = System.Drawing.Color.DodgerBlue
        Me.grDetalle.Size = New System.Drawing.Size(1016, 0)
        Me.grDetalle.TabIndex = 0
        Me.grDetalle.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmOpciones
        '
        Me.cmOpciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmOpciones.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.cmOpciones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Eliminarms})
        Me.cmOpciones.Name = "cmOpciones"
        Me.cmOpciones.Size = New System.Drawing.Size(201, 46)
        '
        'Eliminarms
        '
        Me.Eliminarms.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Eliminarms.Image = CType(resources.GetObject("Eliminarms.Image"), System.Drawing.Image)
        Me.Eliminarms.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.Eliminarms.ImageTransparentColor = System.Drawing.Color.Wheat
        Me.Eliminarms.Name = "Eliminarms"
        Me.Eliminarms.Size = New System.Drawing.Size(200, 42)
        Me.Eliminarms.Text = "ELIMINAR FILA"
        '
        'tbnumiCliente
        '
        '
        '
        '
        Me.tbnumiCliente.Border.Class = "TextBoxBorder"
        Me.tbnumiCliente.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbnumiCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbnumiCliente.Location = New System.Drawing.Point(234, 18)
        Me.tbnumiCliente.Name = "tbnumiCliente"
        Me.tbnumiCliente.PreventEnterBeep = True
        Me.tbnumiCliente.Size = New System.Drawing.Size(51, 23)
        Me.tbnumiCliente.TabIndex = 14
        Me.tbnumiCliente.Visible = False
        '
        'tbCliente
        '
        '
        '
        '
        Me.tbCliente.Border.Class = "TextBoxBorder"
        Me.tbCliente.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbCliente.Location = New System.Drawing.Point(156, 77)
        Me.tbCliente.Name = "tbCliente"
        Me.tbCliente.PreventEnterBeep = True
        Me.tbCliente.Size = New System.Drawing.Size(267, 23)
        Me.tbCliente.TabIndex = 2
        '
        'Estado
        '
        '
        '
        '
        Me.Estado.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Estado.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Estado.Location = New System.Drawing.Point(574, 262)
        Me.Estado.Name = "Estado"
        Me.Estado.OffText = "SIN COBRAR"
        Me.Estado.OnBackColor = System.Drawing.Color.Lime
        Me.Estado.OnText = "COBRADO"
        Me.Estado.Size = New System.Drawing.Size(257, 22)
        Me.Estado.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Estado.TabIndex = 13
        Me.Estado.Value = True
        Me.Estado.ValueObject = "Y"
        '
        'LabelX10
        '
        Me.LabelX10.AutoSize = True
        Me.LabelX10.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX10.Font = New System.Drawing.Font("Georgia", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.LabelX10.Location = New System.Drawing.Point(36, 150)
        Me.LabelX10.Name = "LabelX10"
        Me.LabelX10.Size = New System.Drawing.Size(93, 16)
        Me.LabelX10.TabIndex = 11
        Me.LabelX10.Text = "Tipo Vehiculo:"
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
        Me.LabelX8.Location = New System.Drawing.Point(36, 179)
        Me.LabelX8.Name = "LabelX8"
        Me.LabelX8.Size = New System.Drawing.Size(101, 16)
        Me.LabelX8.TabIndex = 9
        Me.LabelX8.Text = "Fecha de Venta:"
        '
        'LabelX6
        '
        Me.LabelX6.AutoSize = True
        Me.LabelX6.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX6.Font = New System.Drawing.Font("Georgia", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.LabelX6.Location = New System.Drawing.Point(36, 79)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(51, 16)
        Me.LabelX6.TabIndex = 7
        Me.LabelX6.Text = "Cliente:"
        '
        'FechaVenta
        '
        '
        '
        '
        Me.FechaVenta.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.FechaVenta.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.FechaVenta.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.FechaVenta.ButtonDropDown.Visible = True
        Me.FechaVenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FechaVenta.IsPopupCalendarOpen = False
        Me.FechaVenta.Location = New System.Drawing.Point(156, 178)
        '
        '
        '
        '
        '
        '
        Me.FechaVenta.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.FechaVenta.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.FechaVenta.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.FechaVenta.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.FechaVenta.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.FechaVenta.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.FechaVenta.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.FechaVenta.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.FechaVenta.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.FechaVenta.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.FechaVenta.MonthCalendar.DisplayMonth = New Date(2017, 2, 1, 0, 0, 0, 0)
        Me.FechaVenta.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday
        '
        '
        '
        Me.FechaVenta.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.FechaVenta.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.FechaVenta.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.FechaVenta.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.FechaVenta.MonthCalendar.TodayButtonVisible = True
        Me.FechaVenta.Name = "FechaVenta"
        Me.FechaVenta.Size = New System.Drawing.Size(120, 23)
        Me.FechaVenta.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.FechaVenta.TabIndex = 5
        '
        'tbCodigo
        '
        '
        '
        '
        Me.tbCodigo.Border.Class = "TextBoxBorder"
        Me.tbCodigo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbCodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbCodigo.Location = New System.Drawing.Point(156, 18)
        Me.tbCodigo.Name = "tbCodigo"
        Me.tbCodigo.PreventEnterBeep = True
        Me.tbCodigo.Size = New System.Drawing.Size(50, 23)
        Me.tbCodigo.TabIndex = 0
        Me.tbCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LabelX1
        '
        Me.LabelX1.AutoSize = True
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Georgia", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.LabelX1.Location = New System.Drawing.Point(36, 20)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(50, 16)
        Me.LabelX1.TabIndex = 0
        Me.LabelX1.Text = "Código:"
        '
        'GpVentasSinCobrar
        '
        Me.GpVentasSinCobrar.CanvasColor = System.Drawing.SystemColors.Control
        Me.GpVentasSinCobrar.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GpVentasSinCobrar.Controls.Add(Me.SuperTabControl1)
        Me.GpVentasSinCobrar.DisabledBackColor = System.Drawing.Color.Empty
        Me.GpVentasSinCobrar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GpVentasSinCobrar.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GpVentasSinCobrar.Location = New System.Drawing.Point(867, 0)
        Me.GpVentasSinCobrar.Name = "GpVentasSinCobrar"
        Me.GpVentasSinCobrar.Padding = New System.Windows.Forms.Padding(3)
        Me.GpVentasSinCobrar.Size = New System.Drawing.Size(161, 290)
        '
        '
        '
        Me.GpVentasSinCobrar.Style.BackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.GpVentasSinCobrar.Style.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.GpVentasSinCobrar.Style.BackColorGradientAngle = 90
        Me.GpVentasSinCobrar.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GpVentasSinCobrar.Style.BorderBottomWidth = 1
        Me.GpVentasSinCobrar.Style.BorderColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.GpVentasSinCobrar.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GpVentasSinCobrar.Style.BorderLeftWidth = 1
        Me.GpVentasSinCobrar.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GpVentasSinCobrar.Style.BorderRightWidth = 1
        Me.GpVentasSinCobrar.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GpVentasSinCobrar.Style.BorderTopWidth = 1
        Me.GpVentasSinCobrar.Style.CornerDiameter = 4
        Me.GpVentasSinCobrar.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GpVentasSinCobrar.Style.Font = New System.Drawing.Font("Georgia", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GpVentasSinCobrar.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GpVentasSinCobrar.Style.TextColor = System.Drawing.Color.White
        Me.GpVentasSinCobrar.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GpVentasSinCobrar.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GpVentasSinCobrar.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GpVentasSinCobrar.TabIndex = 24
        Me.GpVentasSinCobrar.Text = "I N F O R M A C I O N"
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
        Me.SuperTabControl1.Controls.Add(Me.SuperTabControlPanel1)
        Me.SuperTabControl1.Controls.Add(Me.SuperTabControlPanel2)
        Me.SuperTabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControl1.Location = New System.Drawing.Point(3, 3)
        Me.SuperTabControl1.Name = "SuperTabControl1"
        Me.SuperTabControl1.ReorderTabsEnabled = True
        Me.SuperTabControl1.SelectedTabFont = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.SuperTabControl1.SelectedTabIndex = 0
        Me.SuperTabControl1.Size = New System.Drawing.Size(149, 258)
        Me.SuperTabControl1.TabFont = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SuperTabControl1.TabIndex = 1
        Me.SuperTabControl1.Tabs.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.SuperTabItem1, Me.SuperTabItem2})
        Me.SuperTabControl1.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.Office2010BackstageBlue
        Me.SuperTabControl1.Text = "Descuento"
        '
        'SuperTabControlPanel1
        '
        Me.SuperTabControlPanel1.Controls.Add(Me.grVentasPendientes)
        Me.SuperTabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel1.Location = New System.Drawing.Point(0, 27)
        Me.SuperTabControlPanel1.Name = "SuperTabControlPanel1"
        Me.SuperTabControlPanel1.Size = New System.Drawing.Size(149, 231)
        Me.SuperTabControlPanel1.TabIndex = 1
        Me.SuperTabControlPanel1.TabItem = Me.SuperTabItem1
        '
        'grVentasPendientes
        '
        Me.grVentasPendientes.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.grVentasPendientes.BackColor = System.Drawing.Color.White
        Me.grVentasPendientes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grVentasPendientes.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grVentasPendientes.HeaderFormatStyle.Font = New System.Drawing.Font("Georgia", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grVentasPendientes.Location = New System.Drawing.Point(0, 0)
        Me.grVentasPendientes.Name = "grVentasPendientes"
        Me.grVentasPendientes.Office2007ColorScheme = Janus.Windows.GridEX.Office2007ColorScheme.Custom
        Me.grVentasPendientes.Office2007CustomColor = System.Drawing.Color.DodgerBlue
        Me.grVentasPendientes.Size = New System.Drawing.Size(149, 231)
        Me.grVentasPendientes.TabIndex = 0
        Me.grVentasPendientes.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'SuperTabItem1
        '
        Me.SuperTabItem1.AttachedControl = Me.SuperTabControlPanel1
        Me.SuperTabItem1.GlobalItem = False
        Me.SuperTabItem1.Name = "SuperTabItem1"
        Me.SuperTabItem1.Text = "Ventas Sin Cobrar"
        '
        'SuperTabControlPanel2
        '
        Me.SuperTabControlPanel2.Controls.Add(Me.grPolitica)
        Me.SuperTabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel2.Location = New System.Drawing.Point(0, 27)
        Me.SuperTabControlPanel2.Name = "SuperTabControlPanel2"
        Me.SuperTabControlPanel2.Size = New System.Drawing.Size(631, 219)
        Me.SuperTabControlPanel2.TabIndex = 0
        Me.SuperTabControlPanel2.TabItem = Me.SuperTabItem2
        '
        'grPolitica
        '
        Me.grPolitica.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grPolitica.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grPolitica.Location = New System.Drawing.Point(0, 0)
        Me.grPolitica.Name = "grPolitica"
        Me.grPolitica.Size = New System.Drawing.Size(631, 219)
        Me.grPolitica.TabIndex = 0
        '
        'SuperTabItem2
        '
        Me.SuperTabItem2.AttachedControl = Me.SuperTabControlPanel2
        Me.SuperTabItem2.GlobalItem = False
        Me.SuperTabItem2.Name = "SuperTabItem2"
        Me.SuperTabItem2.Text = "Descuento"
        '
        'ButtonX2
        '
        Me.ButtonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.Orange
        Me.ButtonX2.Image = Global.Presentacion.My.Resources.Resources.atras
        Me.ButtonX2.ImageFixedSize = New System.Drawing.Size(30, 30)
        Me.ButtonX2.Location = New System.Drawing.Point(510, 2)
        Me.ButtonX2.Name = "ButtonX2"
        Me.ButtonX2.Size = New System.Drawing.Size(127, 32)
        Me.ButtonX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX2.TabIndex = 27
        Me.ButtonX2.Text = "VOLVER ATRAS .."
        '
        'ButtonX1
        '
        Me.ButtonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.Orange
        Me.ButtonX1.Image = Global.Presentacion.My.Resources.Resources.search
        Me.ButtonX1.ImageFixedSize = New System.Drawing.Size(30, 30)
        Me.ButtonX1.Location = New System.Drawing.Point(382, 2)
        Me.ButtonX1.Name = "ButtonX1"
        Me.ButtonX1.Size = New System.Drawing.Size(112, 32)
        Me.ButtonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX1.TabIndex = 26
        Me.ButtonX1.Text = "BUSCAR .."
        '
        'LabelX2
        '
        Me.LabelX2.AutoSize = True
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Font = New System.Drawing.Font("Georgia", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.LabelX2.Location = New System.Drawing.Point(36, 113)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(62, 16)
        Me.LabelX2.TabIndex = 26
        Me.LabelX2.Text = "Vehiculo:"
        '
        'tbnumiVehiculo
        '
        '
        '
        '
        Me.tbnumiVehiculo.Border.Class = "TextBoxBorder"
        Me.tbnumiVehiculo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbnumiVehiculo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbnumiVehiculo.Location = New System.Drawing.Point(309, 18)
        Me.tbnumiVehiculo.Name = "tbnumiVehiculo"
        Me.tbnumiVehiculo.PreventEnterBeep = True
        Me.tbnumiVehiculo.Size = New System.Drawing.Size(51, 23)
        Me.tbnumiVehiculo.TabIndex = 27
        Me.tbnumiVehiculo.Visible = False
        '
        'tbVehiculo
        '
        Me.tbVehiculo.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.tbVehiculo.Border.Class = "TextBoxBorder"
        Me.tbVehiculo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbVehiculo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbVehiculo.Location = New System.Drawing.Point(156, 111)
        Me.tbVehiculo.Name = "tbVehiculo"
        Me.tbVehiculo.PreventEnterBeep = True
        Me.tbVehiculo.Size = New System.Drawing.Size(267, 23)
        Me.tbVehiculo.TabIndex = 3
        '
        'cbTipo
        '
        cbTipo_DesignTimeLayout.LayoutString = resources.GetString("cbTipo_DesignTimeLayout.LayoutString")
        Me.cbTipo.DesignTimeLayout = cbTipo_DesignTimeLayout
        Me.cbTipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbTipo.Location = New System.Drawing.Point(156, 145)
        Me.cbTipo.Name = "cbTipo"
        Me.cbTipo.Office2007ColorScheme = Janus.Windows.GridEX.Office2007ColorScheme.Custom
        Me.cbTipo.Office2007CustomColor = System.Drawing.Color.DodgerBlue
        Me.cbTipo.SelectedIndex = -1
        Me.cbTipo.SelectedItem = Nothing
        Me.cbTipo.Size = New System.Drawing.Size(156, 22)
        Me.cbTipo.TabIndex = 4
        Me.cbTipo.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'btnAnadir
        '
        Me.btnAnadir.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnAnadir.ColorTable = DevComponents.DotNetBar.eButtonColor.Orange
        Me.btnAnadir.Font = New System.Drawing.Font("Georgia", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAnadir.Image = Global.Presentacion.My.Resources.Resources.anadir
        Me.btnAnadir.ImageFixedSize = New System.Drawing.Size(25, 25)
        Me.btnAnadir.Location = New System.Drawing.Point(423, 106)
        Me.btnAnadir.Name = "btnAnadir"
        Me.btnAnadir.Size = New System.Drawing.Size(77, 32)
        Me.btnAnadir.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnAnadir.TabIndex = 29
        Me.btnAnadir.Text = "Añadir"
        Me.btnAnadir.TextColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(139, Byte), Integer))
        '
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
        '
        'LabelX3
        '
        Me.LabelX3.AutoSize = True
        Me.LabelX3.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Font = New System.Drawing.Font("Georgia", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.LabelX3.Location = New System.Drawing.Point(36, 50)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(118, 16)
        Me.LabelX3.TabIndex = 30
        Me.LabelX3.Text = "Numero de Orden:"
        '
        'tbNumeroOrden
        '
        '
        '
        '
        Me.tbNumeroOrden.Border.Class = "TextBoxBorder"
        Me.tbNumeroOrden.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbNumeroOrden.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbNumeroOrden.Location = New System.Drawing.Point(288, 48)
        Me.tbNumeroOrden.Name = "tbNumeroOrden"
        Me.tbNumeroOrden.PreventEnterBeep = True
        Me.tbNumeroOrden.Size = New System.Drawing.Size(87, 23)
        Me.tbNumeroOrden.TabIndex = 1
        Me.tbNumeroOrden.WatermarkColor = System.Drawing.Color.White
        '
        'lbFechaPago
        '
        Me.lbFechaPago.AutoSize = True
        Me.lbFechaPago.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.lbFechaPago.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lbFechaPago.Font = New System.Drawing.Font("Georgia", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbFechaPago.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.lbFechaPago.Location = New System.Drawing.Point(488, 23)
        Me.lbFechaPago.Name = "lbFechaPago"
        Me.lbFechaPago.Size = New System.Drawing.Size(83, 16)
        Me.lbFechaPago.TabIndex = 31
        Me.lbFechaPago.Text = "Ultima Pago:"
        Me.lbFechaPago.Visible = False
        '
        'tbFechaPago
        '
        '
        '
        '
        Me.tbFechaPago.Border.Class = "TextBoxBorder"
        Me.tbFechaPago.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbFechaPago.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbFechaPago.Location = New System.Drawing.Point(574, 20)
        Me.tbFechaPago.Name = "tbFechaPago"
        Me.tbFechaPago.PreventEnterBeep = True
        Me.tbFechaPago.Size = New System.Drawing.Size(156, 23)
        Me.tbFechaPago.TabIndex = 7
        Me.tbFechaPago.Visible = False
        Me.tbFechaPago.WatermarkColor = System.Drawing.Color.White
        '
        'PanelDatos
        '
        Me.PanelDatos.Controls.Add(Me.swServicios)
        Me.PanelDatos.Controls.Add(Me.LabelX16)
        Me.PanelDatos.Controls.Add(Me.cbTipoCliente)
        Me.PanelDatos.Controls.Add(Me.tbObservacion)
        Me.PanelDatos.Controls.Add(Me.lboservacion)
        Me.PanelDatos.Controls.Add(Me.tbbanco)
        Me.PanelDatos.Controls.Add(Me.lbbanco)
        Me.PanelDatos.Controls.Add(Me.lbcredito)
        Me.PanelDatos.Controls.Add(Me.tbcredito)
        Me.PanelDatos.Controls.Add(Me.LabelX15)
        Me.PanelDatos.Controls.Add(Me.LabelX14)
        Me.PanelDatos.Controls.Add(Me.cbmoneda)
        Me.PanelDatos.Controls.Add(Me.cbventa)
        Me.PanelDatos.Controls.Add(Me.tbTablet)
        Me.PanelDatos.Controls.Add(Me.lbUltimaPago)
        Me.PanelDatos.Controls.Add(Me.FechaVenta)
        Me.PanelDatos.Controls.Add(Me.LabelX8)
        Me.PanelDatos.Controls.Add(Me.tbnumiCliente)
        Me.PanelDatos.Controls.Add(Me.LabelX10)
        Me.PanelDatos.Controls.Add(Me.tbCliente)
        Me.PanelDatos.Controls.Add(Me.Estado)
        Me.PanelDatos.Controls.Add(Me.LabelX2)
        Me.PanelDatos.Controls.Add(Me.tbnumiVehiculo)
        Me.PanelDatos.Controls.Add(Me.tbVehiculo)
        Me.PanelDatos.Controls.Add(Me.LabelX1)
        Me.PanelDatos.Controls.Add(Me.cbTipo)
        Me.PanelDatos.Controls.Add(Me.UsImg)
        Me.PanelDatos.Controls.Add(Me.tbFechaPago)
        Me.PanelDatos.Controls.Add(Me.lbFechaPago)
        Me.PanelDatos.Controls.Add(Me.tbNumeroOrden)
        Me.PanelDatos.Controls.Add(Me.tbCodigo)
        Me.PanelDatos.Controls.Add(Me.LabelX3)
        Me.PanelDatos.Controls.Add(Me.LabelX6)
        Me.PanelDatos.Controls.Add(Me.btnAnadir)
        Me.PanelDatos.Dock = System.Windows.Forms.DockStyle.Left
        Me.PanelDatos.Location = New System.Drawing.Point(0, 0)
        Me.PanelDatos.Name = "PanelDatos"
        Me.PanelDatos.Size = New System.Drawing.Size(867, 290)
        Me.PanelDatos.TabIndex = 34
        '
        'swServicios
        '
        '
        '
        '
        Me.swServicios.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.swServicios.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.swServicios.Location = New System.Drawing.Point(574, 237)
        Me.swServicios.Name = "swServicios"
        Me.swServicios.OffBackColor = System.Drawing.Color.DodgerBlue
        Me.swServicios.OffText = "PRODUCTO"
        Me.swServicios.OffTextColor = System.Drawing.Color.White
        Me.swServicios.OnBackColor = System.Drawing.Color.Gold
        Me.swServicios.OnText = "SERVICIOS"
        Me.swServicios.OnTextColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.swServicios.Size = New System.Drawing.Size(142, 22)
        Me.swServicios.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.swServicios.TabIndex = 48
        Me.swServicios.Value = True
        Me.swServicios.ValueObject = "Y"
        '
        'LabelX16
        '
        Me.LabelX16.AutoSize = True
        Me.LabelX16.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX16.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX16.Font = New System.Drawing.Font("Georgia", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX16.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.LabelX16.Location = New System.Drawing.Point(36, 206)
        Me.LabelX16.Name = "LabelX16"
        Me.LabelX16.Size = New System.Drawing.Size(82, 16)
        Me.LabelX16.TabIndex = 47
        Me.LabelX16.Text = "Tipo Cliente:"
        '
        'cbTipoCliente
        '
        cbTipoCliente_DesignTimeLayout.LayoutString = resources.GetString("cbTipoCliente_DesignTimeLayout.LayoutString")
        Me.cbTipoCliente.DesignTimeLayout = cbTipoCliente_DesignTimeLayout
        Me.cbTipoCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbTipoCliente.Location = New System.Drawing.Point(156, 206)
        Me.cbTipoCliente.Name = "cbTipoCliente"
        Me.cbTipoCliente.Office2007ColorScheme = Janus.Windows.GridEX.Office2007ColorScheme.Custom
        Me.cbTipoCliente.Office2007CustomColor = System.Drawing.Color.DodgerBlue
        Me.cbTipoCliente.SelectedIndex = -1
        Me.cbTipoCliente.SelectedItem = Nothing
        Me.cbTipoCliente.Size = New System.Drawing.Size(156, 22)
        Me.cbTipoCliente.TabIndex = 46
        Me.cbTipoCliente.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'tbObservacion
        '
        Me.tbObservacion.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.tbObservacion.Border.Class = "TextBoxBorder"
        Me.tbObservacion.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbObservacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbObservacion.Location = New System.Drawing.Point(574, 174)
        Me.tbObservacion.Multiline = True
        Me.tbObservacion.Name = "tbObservacion"
        Me.tbObservacion.PreventEnterBeep = True
        Me.tbObservacion.Size = New System.Drawing.Size(263, 57)
        Me.tbObservacion.TabIndex = 12
        Me.tbObservacion.Visible = False
        '
        'lboservacion
        '
        Me.lboservacion.AutoSize = True
        Me.lboservacion.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.lboservacion.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lboservacion.Font = New System.Drawing.Font("Georgia", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lboservacion.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.lboservacion.Location = New System.Drawing.Point(488, 178)
        Me.lboservacion.Name = "lboservacion"
        Me.lboservacion.Size = New System.Drawing.Size(84, 16)
        Me.lboservacion.TabIndex = 45
        Me.lboservacion.Text = "Observacion:"
        Me.lboservacion.Visible = False
        '
        'tbbanco
        '
        Me.tbbanco.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.tbbanco.Border.Class = "TextBoxBorder"
        Me.tbbanco.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbbanco.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbbanco.Location = New System.Drawing.Point(574, 143)
        Me.tbbanco.Name = "tbbanco"
        Me.tbbanco.PreventEnterBeep = True
        Me.tbbanco.Size = New System.Drawing.Size(263, 23)
        Me.tbbanco.TabIndex = 11
        Me.tbbanco.Visible = False
        '
        'lbbanco
        '
        Me.lbbanco.AutoSize = True
        Me.lbbanco.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.lbbanco.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lbbanco.Font = New System.Drawing.Font("Georgia", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbbanco.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.lbbanco.Location = New System.Drawing.Point(525, 145)
        Me.lbbanco.Name = "lbbanco"
        Me.lbbanco.Size = New System.Drawing.Size(45, 16)
        Me.lbbanco.TabIndex = 43
        Me.lbbanco.Text = "Banco:"
        Me.lbbanco.Visible = False
        '
        'lbcredito
        '
        Me.lbcredito.AutoSize = True
        Me.lbcredito.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.lbcredito.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lbcredito.Font = New System.Drawing.Font("Georgia", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbcredito.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.lbcredito.Location = New System.Drawing.Point(495, 74)
        Me.lbcredito.Name = "lbcredito"
        Me.lbcredito.Size = New System.Drawing.Size(77, 16)
        Me.lbcredito.TabIndex = 41
        Me.lbcredito.Text = "Fecha Venc:"
        Me.lbcredito.Visible = False
        '
        'tbcredito
        '
        '
        '
        '
        Me.tbcredito.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.tbcredito.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbcredito.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.tbcredito.ButtonDropDown.Visible = True
        Me.tbcredito.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbcredito.IsPopupCalendarOpen = False
        Me.tbcredito.Location = New System.Drawing.Point(574, 75)
        '
        '
        '
        '
        '
        '
        Me.tbcredito.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbcredito.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.tbcredito.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.tbcredito.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.tbcredito.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.tbcredito.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.tbcredito.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.tbcredito.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.tbcredito.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.tbcredito.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbcredito.MonthCalendar.DisplayMonth = New Date(2017, 2, 1, 0, 0, 0, 0)
        Me.tbcredito.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday
        '
        '
        '
        Me.tbcredito.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.tbcredito.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.tbcredito.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.tbcredito.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbcredito.MonthCalendar.TodayButtonVisible = True
        Me.tbcredito.Name = "tbcredito"
        Me.tbcredito.Size = New System.Drawing.Size(120, 23)
        Me.tbcredito.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.tbcredito.TabIndex = 9
        Me.tbcredito.Visible = False
        '
        'LabelX15
        '
        Me.LabelX15.AutoSize = True
        Me.LabelX15.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX15.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX15.Font = New System.Drawing.Font("Georgia", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX15.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.LabelX15.Location = New System.Drawing.Point(498, 50)
        Me.LabelX15.Name = "LabelX15"
        Me.LabelX15.Size = New System.Drawing.Size(74, 16)
        Me.LabelX15.TabIndex = 39
        Me.LabelX15.Text = "Tipo Venta:"
        '
        'LabelX14
        '
        Me.LabelX14.AutoSize = True
        Me.LabelX14.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX14.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX14.Font = New System.Drawing.Font("Georgia", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX14.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.LabelX14.Location = New System.Drawing.Point(514, 113)
        Me.LabelX14.Name = "LabelX14"
        Me.LabelX14.Size = New System.Drawing.Size(57, 16)
        Me.LabelX14.TabIndex = 38
        Me.LabelX14.Text = "Moneda:"
        '
        'cbmoneda
        '
        '
        '
        '
        Me.cbmoneda.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cbmoneda.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbmoneda.Location = New System.Drawing.Point(574, 113)
        Me.cbmoneda.Name = "cbmoneda"
        Me.cbmoneda.OffBackColor = System.Drawing.Color.DodgerBlue
        Me.cbmoneda.OffText = "US"
        Me.cbmoneda.OffTextColor = System.Drawing.Color.White
        Me.cbmoneda.OnBackColor = System.Drawing.Color.Gold
        Me.cbmoneda.OnText = "BS"
        Me.cbmoneda.OnTextColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.cbmoneda.Size = New System.Drawing.Size(142, 22)
        Me.cbmoneda.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cbmoneda.TabIndex = 10
        Me.cbmoneda.Value = True
        Me.cbmoneda.ValueObject = "Y"
        '
        'cbventa
        '
        cbventa_DesignTimeLayout.LayoutString = resources.GetString("cbventa_DesignTimeLayout.LayoutString")
        Me.cbventa.DesignTimeLayout = cbventa_DesignTimeLayout
        Me.cbventa.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbventa.Location = New System.Drawing.Point(574, 46)
        Me.cbventa.Name = "cbventa"
        Me.cbventa.Office2007ColorScheme = Janus.Windows.GridEX.Office2007ColorScheme.Custom
        Me.cbventa.Office2007CustomColor = System.Drawing.Color.DodgerBlue
        Me.cbventa.SelectedIndex = -1
        Me.cbventa.SelectedItem = Nothing
        Me.cbventa.Size = New System.Drawing.Size(156, 22)
        Me.cbventa.TabIndex = 8
        Me.cbventa.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'tbTablet
        '
        '
        '
        '
        Me.tbTablet.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbTablet.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbTablet.Location = New System.Drawing.Point(157, 48)
        Me.tbTablet.Name = "tbTablet"
        Me.tbTablet.OffBackColor = System.Drawing.Color.DodgerBlue
        Me.tbTablet.OffText = "MANUAL"
        Me.tbTablet.OffTextColor = System.Drawing.Color.White
        Me.tbTablet.OnBackColor = System.Drawing.Color.Gold
        Me.tbTablet.OnText = "TABLET"
        Me.tbTablet.OnTextColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.tbTablet.Size = New System.Drawing.Size(119, 22)
        Me.tbTablet.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.tbTablet.TabIndex = 1
        Me.tbTablet.Value = True
        Me.tbTablet.ValueObject = "Y"
        '
        'lbUltimaPago
        '
        '
        '
        '
        Me.lbUltimaPago.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lbUltimaPago.Font = New System.Drawing.Font("Arial", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbUltimaPago.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.lbUltimaPago.Location = New System.Drawing.Point(156, 237)
        Me.lbUltimaPago.Name = "lbUltimaPago"
        Me.lbUltimaPago.Size = New System.Drawing.Size(247, 37)
        Me.lbUltimaPago.TabIndex = 34
        Me.lbUltimaPago.Text = "HABILITADO"
        '
        'UsImg
        '
        Me.UsImg.BackColor = System.Drawing.Color.Transparent
        Me.UsImg.Location = New System.Drawing.Point(757, 8)
        Me.UsImg.Margin = New System.Windows.Forms.Padding(4)
        Me.UsImg.Name = "UsImg"
        Me.UsImg.Size = New System.Drawing.Size(38, 24)
        Me.UsImg.TabIndex = 28
        '
        'PanelDatosTop
        '
        Me.PanelDatosTop.Controls.Add(Me.GpVentasSinCobrar)
        Me.PanelDatosTop.Controls.Add(Me.PanelDatos)
        Me.PanelDatosTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelDatosTop.Location = New System.Drawing.Point(0, 0)
        Me.PanelDatosTop.Name = "PanelDatosTop"
        Me.PanelDatosTop.Size = New System.Drawing.Size(1028, 290)
        Me.PanelDatosTop.TabIndex = 36
        '
        'PanelButton
        '
        Me.PanelButton.Controls.Add(Me.GpDetalle)
        Me.PanelButton.Controls.Add(Me.GpPanelServicio)
        Me.PanelButton.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelButton.Location = New System.Drawing.Point(0, 290)
        Me.PanelButton.Name = "PanelButton"
        Me.PanelButton.Size = New System.Drawing.Size(1028, 186)
        Me.PanelButton.TabIndex = 20
        '
        'GpPanelServicio
        '
        Me.GpPanelServicio.CanvasColor = System.Drawing.SystemColors.Control
        Me.GpPanelServicio.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GpPanelServicio.Controls.Add(Me.grProducto)
        Me.GpPanelServicio.DisabledBackColor = System.Drawing.Color.Empty
        Me.GpPanelServicio.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GpPanelServicio.Font = New System.Drawing.Font("Georgia", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GpPanelServicio.Location = New System.Drawing.Point(0, 12)
        Me.GpPanelServicio.Name = "GpPanelServicio"
        Me.GpPanelServicio.Padding = New System.Windows.Forms.Padding(5)
        Me.GpPanelServicio.Size = New System.Drawing.Size(1028, 174)
        '
        '
        '
        Me.GpPanelServicio.Style.BackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.GpPanelServicio.Style.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.GpPanelServicio.Style.BackColorGradientAngle = 90
        Me.GpPanelServicio.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GpPanelServicio.Style.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.GpPanelServicio.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GpPanelServicio.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GpPanelServicio.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GpPanelServicio.Style.CornerDiameter = 0
        Me.GpPanelServicio.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GpPanelServicio.Style.Font = New System.Drawing.Font("Georgia", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GpPanelServicio.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GpPanelServicio.Style.TextColor = System.Drawing.Color.White
        Me.GpPanelServicio.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GpPanelServicio.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GpPanelServicio.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GpPanelServicio.TabIndex = 0
        Me.GpPanelServicio.Text = "S E R V I C I O"
        Me.GpPanelServicio.Visible = False
        '
        'grProducto
        '
        Me.grProducto.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.grProducto.ContextMenuStrip = Me.cmOpciones
        Me.grProducto.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grProducto.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grProducto.HeaderFormatStyle.Font = New System.Drawing.Font("Georgia", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grProducto.Location = New System.Drawing.Point(5, 5)
        Me.grProducto.Name = "grProducto"
        Me.grProducto.Office2007ColorScheme = Janus.Windows.GridEX.Office2007ColorScheme.Custom
        Me.grProducto.Office2007CustomColor = System.Drawing.Color.DodgerBlue
        Me.grProducto.Size = New System.Drawing.Size(1018, 148)
        Me.grProducto.TabIndex = 0
        Me.grProducto.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.Panel4)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1028, 587)
        Me.Panel1.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.Controls.Add(Me.GroupPanel1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 406)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1028, 181)
        Me.Panel2.TabIndex = 1
        '
        'GroupPanel1
        '
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.PanelCombos)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupPanel1.Location = New System.Drawing.Point(0, 0)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(1028, 181)
        '
        '
        '
        Me.GroupPanel1.Style.BackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.GroupPanel1.Style.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.GroupPanel1.Style.BackColorGradientAngle = 90
        Me.GroupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderBottomWidth = 1
        Me.GroupPanel1.Style.BorderColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.GroupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderLeftWidth = 1
        Me.GroupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderRightWidth = 1
        Me.GroupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderTopWidth = 1
        Me.GroupPanel1.Style.CornerDiameter = 4
        Me.GroupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel1.Style.Font = New System.Drawing.Font("Georgia", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupPanel1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel1.Style.TextColor = System.Drawing.Color.White
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
        Me.GroupPanel1.Text = "INVENTARIO DE ACCESORIOS Y HERRAMIENTAS"
        '
        'PanelCombos
        '
        Me.PanelCombos.BackColor = System.Drawing.Color.White
        Me.PanelCombos.Controls.Add(Me.TableLayoutPanel1)
        Me.PanelCombos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelCombos.Location = New System.Drawing.Point(0, 0)
        Me.PanelCombos.Name = "PanelCombos"
        Me.PanelCombos.Size = New System.Drawing.Size(1022, 159)
        Me.PanelCombos.TabIndex = 0
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.Controls.Add(Me.Panel24, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel22, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel23, 1, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1022, 159)
        Me.TableLayoutPanel1.TabIndex = 135
        '
        'Panel24
        '
        Me.Panel24.AutoScroll = True
        Me.Panel24.Controls.Add(Me.Panel21)
        Me.Panel24.Controls.Add(Me.lb13)
        Me.Panel24.Controls.Add(Me.lb14)
        Me.Panel24.Controls.Add(Me.Panel16)
        Me.Panel24.Controls.Add(Me.lb15)
        Me.Panel24.Controls.Add(Me.Panel17)
        Me.Panel24.Controls.Add(Me.lb16)
        Me.Panel24.Controls.Add(Me.Panel18)
        Me.Panel24.Controls.Add(Me.lb17)
        Me.Panel24.Controls.Add(Me.Panel19)
        Me.Panel24.Controls.Add(Me.lb18)
        Me.Panel24.Controls.Add(Me.Panel20)
        Me.Panel24.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel24.Location = New System.Drawing.Point(683, 3)
        Me.Panel24.Name = "Panel24"
        Me.Panel24.Size = New System.Drawing.Size(336, 153)
        Me.Panel24.TabIndex = 134
        '
        'Panel21
        '
        Me.Panel21.BackColor = System.Drawing.Color.Transparent
        Me.Panel21.Controls.Add(Me.cbb13)
        Me.Panel21.Controls.Add(Me.cb13)
        Me.Panel21.Location = New System.Drawing.Point(154, 8)
        Me.Panel21.Name = "Panel21"
        Me.Panel21.Size = New System.Drawing.Size(123, 31)
        Me.Panel21.TabIndex = 126
        '
        'cbb13
        '
        '
        '
        '
        Me.cbb13.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cbb13.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.cbb13.CheckSignSize = New System.Drawing.Size(17, 17)
        Me.cbb13.FocusCuesEnabled = False
        Me.cbb13.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbb13.Location = New System.Drawing.Point(64, 4)
        Me.cbb13.Name = "cbb13"
        Me.cbb13.Size = New System.Drawing.Size(50, 23)
        Me.cbb13.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cbb13.TabIndex = 68
        Me.cbb13.Text = "NO"
        '
        'cb13
        '
        Me.cb13.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.cb13.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cb13.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.cb13.CheckSignSize = New System.Drawing.Size(17, 17)
        Me.cb13.FocusCuesEnabled = False
        Me.cb13.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb13.Location = New System.Drawing.Point(3, 4)
        Me.cb13.Name = "cb13"
        Me.cb13.Size = New System.Drawing.Size(43, 23)
        Me.cb13.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cb13.TabIndex = 0
        Me.cb13.Text = "SI"
        Me.cb13.TextColor = System.Drawing.Color.Navy
        '
        'lb13
        '
        Me.lb13.AutoSize = True
        Me.lb13.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.lb13.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lb13.Font = New System.Drawing.Font("Georgia", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb13.Location = New System.Drawing.Point(7, 14)
        Me.lb13.Name = "lb13"
        Me.lb13.Size = New System.Drawing.Size(44, 20)
        Me.lb13.TabIndex = 103
        Me.lb13.Text = "Gata:"
        Me.lb13.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'lb14
        '
        Me.lb14.AutoSize = True
        Me.lb14.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.lb14.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lb14.Font = New System.Drawing.Font("Georgia", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb14.Location = New System.Drawing.Point(7, 47)
        Me.lb14.Name = "lb14"
        Me.lb14.Size = New System.Drawing.Size(108, 20)
        Me.lb14.TabIndex = 106
        Me.lb14.Text = "Tapa Tanque:"
        Me.lb14.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'Panel16
        '
        Me.Panel16.BackColor = System.Drawing.Color.Transparent
        Me.Panel16.Controls.Add(Me.cbb18)
        Me.Panel16.Controls.Add(Me.cb18)
        Me.Panel16.Location = New System.Drawing.Point(154, 163)
        Me.Panel16.Name = "Panel16"
        Me.Panel16.Size = New System.Drawing.Size(123, 31)
        Me.Panel16.TabIndex = 131
        '
        'cbb18
        '
        '
        '
        '
        Me.cbb18.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cbb18.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.cbb18.CheckSignSize = New System.Drawing.Size(17, 17)
        Me.cbb18.FocusCuesEnabled = False
        Me.cbb18.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbb18.Location = New System.Drawing.Point(64, 4)
        Me.cbb18.Name = "cbb18"
        Me.cbb18.Size = New System.Drawing.Size(50, 23)
        Me.cbb18.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cbb18.TabIndex = 68
        Me.cbb18.Text = "NO"
        '
        'cb18
        '
        '
        '
        '
        Me.cb18.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cb18.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.cb18.CheckSignSize = New System.Drawing.Size(17, 17)
        Me.cb18.FocusCuesEnabled = False
        Me.cb18.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb18.Location = New System.Drawing.Point(3, 4)
        Me.cb18.Name = "cb18"
        Me.cb18.Size = New System.Drawing.Size(43, 23)
        Me.cb18.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cb18.TabIndex = 0
        Me.cb18.Text = "SI"
        Me.cb18.TextColor = System.Drawing.Color.Navy
        '
        'lb15
        '
        Me.lb15.AutoSize = True
        Me.lb15.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.lb15.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lb15.Font = New System.Drawing.Font("Georgia", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb15.Location = New System.Drawing.Point(7, 78)
        Me.lb15.Name = "lb15"
        Me.lb15.Size = New System.Drawing.Size(61, 20)
        Me.lb15.TabIndex = 109
        Me.lb15.Text = "Varilla:"
        Me.lb15.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'Panel17
        '
        Me.Panel17.BackColor = System.Drawing.Color.Transparent
        Me.Panel17.Controls.Add(Me.cbb17)
        Me.Panel17.Controls.Add(Me.cb17)
        Me.Panel17.Location = New System.Drawing.Point(154, 133)
        Me.Panel17.Name = "Panel17"
        Me.Panel17.Size = New System.Drawing.Size(123, 31)
        Me.Panel17.TabIndex = 130
        '
        'cbb17
        '
        '
        '
        '
        Me.cbb17.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cbb17.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.cbb17.CheckSignSize = New System.Drawing.Size(17, 17)
        Me.cbb17.FocusCuesEnabled = False
        Me.cbb17.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbb17.Location = New System.Drawing.Point(64, 4)
        Me.cbb17.Name = "cbb17"
        Me.cbb17.Size = New System.Drawing.Size(50, 23)
        Me.cbb17.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cbb17.TabIndex = 68
        Me.cbb17.Text = "NO"
        '
        'cb17
        '
        '
        '
        '
        Me.cb17.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cb17.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.cb17.CheckSignSize = New System.Drawing.Size(17, 17)
        Me.cb17.FocusCuesEnabled = False
        Me.cb17.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb17.Location = New System.Drawing.Point(3, 4)
        Me.cb17.Name = "cb17"
        Me.cb17.Size = New System.Drawing.Size(43, 23)
        Me.cb17.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cb17.TabIndex = 0
        Me.cb17.Text = "SI"
        Me.cb17.TextColor = System.Drawing.Color.Navy
        '
        'lb16
        '
        Me.lb16.AutoSize = True
        Me.lb16.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.lb16.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lb16.Font = New System.Drawing.Font("Georgia", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb16.Location = New System.Drawing.Point(7, 110)
        Me.lb16.Name = "lb16"
        Me.lb16.Size = New System.Drawing.Size(101, 20)
        Me.lb16.TabIndex = 112
        Me.lb16.Text = "Extinguidor:"
        Me.lb16.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'Panel18
        '
        Me.Panel18.BackColor = System.Drawing.Color.Transparent
        Me.Panel18.Controls.Add(Me.cbb16)
        Me.Panel18.Controls.Add(Me.cb16)
        Me.Panel18.Location = New System.Drawing.Point(154, 102)
        Me.Panel18.Name = "Panel18"
        Me.Panel18.Size = New System.Drawing.Size(123, 31)
        Me.Panel18.TabIndex = 129
        '
        'cbb16
        '
        '
        '
        '
        Me.cbb16.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cbb16.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.cbb16.CheckSignSize = New System.Drawing.Size(17, 17)
        Me.cbb16.FocusCuesEnabled = False
        Me.cbb16.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbb16.Location = New System.Drawing.Point(64, 4)
        Me.cbb16.Name = "cbb16"
        Me.cbb16.Size = New System.Drawing.Size(50, 23)
        Me.cbb16.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cbb16.TabIndex = 68
        Me.cbb16.Text = "NO"
        '
        'cb16
        '
        '
        '
        '
        Me.cb16.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cb16.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.cb16.CheckSignSize = New System.Drawing.Size(17, 17)
        Me.cb16.FocusCuesEnabled = False
        Me.cb16.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb16.Location = New System.Drawing.Point(3, 4)
        Me.cb16.Name = "cb16"
        Me.cb16.Size = New System.Drawing.Size(43, 23)
        Me.cb16.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cb16.TabIndex = 0
        Me.cb16.Text = "SI"
        Me.cb16.TextColor = System.Drawing.Color.Navy
        '
        'lb17
        '
        Me.lb17.AutoSize = True
        Me.lb17.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.lb17.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lb17.Font = New System.Drawing.Font("Georgia", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb17.Location = New System.Drawing.Point(8, 141)
        Me.lb17.Name = "lb17"
        Me.lb17.Size = New System.Drawing.Size(76, 20)
        Me.lb17.TabIndex = 115
        Me.lb17.Text = "Botiquin:"
        Me.lb17.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'Panel19
        '
        Me.Panel19.BackColor = System.Drawing.Color.Transparent
        Me.Panel19.Controls.Add(Me.cbb15)
        Me.Panel19.Controls.Add(Me.cb15)
        Me.Panel19.Location = New System.Drawing.Point(154, 71)
        Me.Panel19.Name = "Panel19"
        Me.Panel19.Size = New System.Drawing.Size(123, 31)
        Me.Panel19.TabIndex = 128
        '
        'cbb15
        '
        '
        '
        '
        Me.cbb15.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cbb15.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.cbb15.CheckSignSize = New System.Drawing.Size(17, 17)
        Me.cbb15.FocusCuesEnabled = False
        Me.cbb15.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbb15.Location = New System.Drawing.Point(64, 4)
        Me.cbb15.Name = "cbb15"
        Me.cbb15.Size = New System.Drawing.Size(50, 23)
        Me.cbb15.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cbb15.TabIndex = 68
        Me.cbb15.Text = "NO"
        '
        'cb15
        '
        '
        '
        '
        Me.cb15.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cb15.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.cb15.CheckSignSize = New System.Drawing.Size(17, 17)
        Me.cb15.FocusCuesEnabled = False
        Me.cb15.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb15.Location = New System.Drawing.Point(3, 4)
        Me.cb15.Name = "cb15"
        Me.cb15.Size = New System.Drawing.Size(43, 23)
        Me.cb15.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cb15.TabIndex = 0
        Me.cb15.Text = "SI"
        Me.cb15.TextColor = System.Drawing.Color.Navy
        '
        'lb18
        '
        Me.lb18.AutoSize = True
        Me.lb18.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.lb18.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lb18.Font = New System.Drawing.Font("Georgia", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb18.Location = New System.Drawing.Point(7, 170)
        Me.lb18.Name = "lb18"
        Me.lb18.Size = New System.Drawing.Size(107, 20)
        Me.lb18.TabIndex = 118
        Me.lb18.Text = "Retrovisores:"
        Me.lb18.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'Panel20
        '
        Me.Panel20.BackColor = System.Drawing.Color.Transparent
        Me.Panel20.Controls.Add(Me.cbb14)
        Me.Panel20.Controls.Add(Me.cb14)
        Me.Panel20.Location = New System.Drawing.Point(154, 40)
        Me.Panel20.Name = "Panel20"
        Me.Panel20.Size = New System.Drawing.Size(123, 31)
        Me.Panel20.TabIndex = 127
        '
        'cbb14
        '
        '
        '
        '
        Me.cbb14.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cbb14.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.cbb14.CheckSignSize = New System.Drawing.Size(17, 17)
        Me.cbb14.FocusCuesEnabled = False
        Me.cbb14.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbb14.Location = New System.Drawing.Point(64, 4)
        Me.cbb14.Name = "cbb14"
        Me.cbb14.Size = New System.Drawing.Size(50, 23)
        Me.cbb14.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cbb14.TabIndex = 68
        Me.cbb14.Text = "NO"
        '
        'cb14
        '
        '
        '
        '
        Me.cb14.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cb14.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.cb14.CheckSignSize = New System.Drawing.Size(17, 17)
        Me.cb14.FocusCuesEnabled = False
        Me.cb14.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb14.Location = New System.Drawing.Point(3, 4)
        Me.cb14.Name = "cb14"
        Me.cb14.Size = New System.Drawing.Size(43, 23)
        Me.cb14.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cb14.TabIndex = 0
        Me.cb14.Text = "SI"
        Me.cb14.TextColor = System.Drawing.Color.Navy
        '
        'Panel22
        '
        Me.Panel22.AutoScroll = True
        Me.Panel22.Controls.Add(Me.lb1)
        Me.Panel22.Controls.Add(Me.lb2)
        Me.Panel22.Controls.Add(Me.lb3)
        Me.Panel22.Controls.Add(Me.lb4)
        Me.Panel22.Controls.Add(Me.lb5)
        Me.Panel22.Controls.Add(Me.lb6)
        Me.Panel22.Controls.Add(Me.Panel3)
        Me.Panel22.Controls.Add(Me.Panel5)
        Me.Panel22.Controls.Add(Me.Panel6)
        Me.Panel22.Controls.Add(Me.Panel7)
        Me.Panel22.Controls.Add(Me.Panel8)
        Me.Panel22.Controls.Add(Me.Panel9)
        Me.Panel22.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel22.Location = New System.Drawing.Point(3, 3)
        Me.Panel22.Name = "Panel22"
        Me.Panel22.Size = New System.Drawing.Size(334, 153)
        Me.Panel22.TabIndex = 132
        '
        'lb1
        '
        Me.lb1.AutoSize = True
        Me.lb1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.lb1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lb1.Font = New System.Drawing.Font("Georgia", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb1.Location = New System.Drawing.Point(20, 18)
        Me.lb1.Name = "lb1"
        Me.lb1.Size = New System.Drawing.Size(139, 20)
        Me.lb1.TabIndex = 67
        Me.lb1.Text = "Llanta de Auxilio:"
        Me.lb1.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'lb2
        '
        Me.lb2.AutoSize = True
        Me.lb2.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.lb2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lb2.Font = New System.Drawing.Font("Georgia", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb2.Location = New System.Drawing.Point(20, 51)
        Me.lb2.Name = "lb2"
        Me.lb2.Size = New System.Drawing.Size(141, 20)
        Me.lb2.TabIndex = 70
        Me.lb2.Text = "Manivela de Gata:"
        Me.lb2.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'lb3
        '
        Me.lb3.AutoSize = True
        Me.lb3.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.lb3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lb3.Font = New System.Drawing.Font("Georgia", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb3.Location = New System.Drawing.Point(20, 82)
        Me.lb3.Name = "lb3"
        Me.lb3.Size = New System.Drawing.Size(93, 20)
        Me.lb3.TabIndex = 73
        Me.lb3.Text = "Sobrepisos:"
        Me.lb3.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'lb4
        '
        Me.lb4.AutoSize = True
        Me.lb4.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.lb4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lb4.Font = New System.Drawing.Font("Georgia", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb4.Location = New System.Drawing.Point(20, 114)
        Me.lb4.Name = "lb4"
        Me.lb4.Size = New System.Drawing.Size(73, 20)
        Me.lb4.TabIndex = 76
        Me.lb4.Text = "Quitasol:"
        Me.lb4.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'lb5
        '
        Me.lb5.AutoSize = True
        Me.lb5.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.lb5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lb5.Font = New System.Drawing.Font("Georgia", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb5.Location = New System.Drawing.Point(21, 145)
        Me.lb5.Name = "lb5"
        Me.lb5.Size = New System.Drawing.Size(54, 20)
        Me.lb5.TabIndex = 79
        Me.lb5.Text = "Radio:"
        Me.lb5.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'lb6
        '
        Me.lb6.AutoSize = True
        Me.lb6.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.lb6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lb6.Font = New System.Drawing.Font("Georgia", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb6.Location = New System.Drawing.Point(20, 174)
        Me.lb6.Name = "lb6"
        Me.lb6.Size = New System.Drawing.Size(84, 20)
        Me.lb6.TabIndex = 82
        Me.lb6.Text = "Cabezales:"
        Me.lb6.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Transparent
        Me.Panel3.Controls.Add(Me.cbb1)
        Me.Panel3.Controls.Add(Me.cb1)
        Me.Panel3.Location = New System.Drawing.Point(165, 12)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(123, 31)
        Me.Panel3.TabIndex = 120
        '
        'cbb1
        '
        '
        '
        '
        Me.cbb1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cbb1.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.cbb1.CheckSignSize = New System.Drawing.Size(17, 17)
        Me.cbb1.FocusCuesEnabled = False
        Me.cbb1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbb1.Location = New System.Drawing.Point(64, 4)
        Me.cbb1.Name = "cbb1"
        Me.cbb1.Size = New System.Drawing.Size(50, 23)
        Me.cbb1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cbb1.TabIndex = 68
        Me.cbb1.Text = "NO"
        '
        'cb1
        '
        Me.cb1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.cb1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cb1.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.cb1.CheckSignSize = New System.Drawing.Size(17, 17)
        Me.cb1.FocusCuesEnabled = False
        Me.cb1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb1.Location = New System.Drawing.Point(3, 4)
        Me.cb1.Name = "cb1"
        Me.cb1.Size = New System.Drawing.Size(43, 23)
        Me.cb1.TabIndex = 0
        Me.cb1.Text = "SI"
        Me.cb1.TextColor = System.Drawing.Color.Navy
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.Transparent
        Me.Panel5.Controls.Add(Me.cbb2)
        Me.Panel5.Controls.Add(Me.cb2)
        Me.Panel5.Location = New System.Drawing.Point(165, 44)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(123, 31)
        Me.Panel5.TabIndex = 121
        '
        'cbb2
        '
        '
        '
        '
        Me.cbb2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cbb2.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.cbb2.CheckSignSize = New System.Drawing.Size(17, 17)
        Me.cbb2.FocusCuesEnabled = False
        Me.cbb2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbb2.Location = New System.Drawing.Point(64, 4)
        Me.cbb2.Name = "cbb2"
        Me.cbb2.Size = New System.Drawing.Size(50, 23)
        Me.cbb2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cbb2.TabIndex = 68
        Me.cbb2.Text = "NO"
        '
        'cb2
        '
        '
        '
        '
        Me.cb2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cb2.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.cb2.CheckSignSize = New System.Drawing.Size(17, 17)
        Me.cb2.FocusCuesEnabled = False
        Me.cb2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb2.Location = New System.Drawing.Point(3, 4)
        Me.cb2.Name = "cb2"
        Me.cb2.Size = New System.Drawing.Size(43, 23)
        Me.cb2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cb2.TabIndex = 0
        Me.cb2.Text = "SI"
        Me.cb2.TextColor = System.Drawing.Color.Navy
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.Transparent
        Me.Panel6.Controls.Add(Me.cbb3)
        Me.Panel6.Controls.Add(Me.cb3)
        Me.Panel6.Location = New System.Drawing.Point(165, 75)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(123, 31)
        Me.Panel6.TabIndex = 122
        '
        'cbb3
        '
        '
        '
        '
        Me.cbb3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cbb3.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.cbb3.CheckSignSize = New System.Drawing.Size(17, 17)
        Me.cbb3.FocusCuesEnabled = False
        Me.cbb3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbb3.Location = New System.Drawing.Point(64, 4)
        Me.cbb3.Name = "cbb3"
        Me.cbb3.Size = New System.Drawing.Size(50, 23)
        Me.cbb3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cbb3.TabIndex = 68
        Me.cbb3.Text = "NO"
        '
        'cb3
        '
        '
        '
        '
        Me.cb3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cb3.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.cb3.CheckSignSize = New System.Drawing.Size(17, 17)
        Me.cb3.FocusCuesEnabled = False
        Me.cb3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb3.Location = New System.Drawing.Point(3, 4)
        Me.cb3.Name = "cb3"
        Me.cb3.Size = New System.Drawing.Size(43, 23)
        Me.cb3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cb3.TabIndex = 0
        Me.cb3.Text = "SI"
        Me.cb3.TextColor = System.Drawing.Color.Navy
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.Transparent
        Me.Panel7.Controls.Add(Me.cbb4)
        Me.Panel7.Controls.Add(Me.cb4)
        Me.Panel7.Location = New System.Drawing.Point(165, 106)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(123, 31)
        Me.Panel7.TabIndex = 123
        '
        'cbb4
        '
        '
        '
        '
        Me.cbb4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cbb4.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.cbb4.CheckSignSize = New System.Drawing.Size(17, 17)
        Me.cbb4.FocusCuesEnabled = False
        Me.cbb4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbb4.Location = New System.Drawing.Point(64, 4)
        Me.cbb4.Name = "cbb4"
        Me.cbb4.Size = New System.Drawing.Size(50, 23)
        Me.cbb4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cbb4.TabIndex = 68
        Me.cbb4.Text = "NO"
        '
        'cb4
        '
        '
        '
        '
        Me.cb4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cb4.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.cb4.CheckSignSize = New System.Drawing.Size(17, 17)
        Me.cb4.FocusCuesEnabled = False
        Me.cb4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb4.Location = New System.Drawing.Point(3, 4)
        Me.cb4.Name = "cb4"
        Me.cb4.Size = New System.Drawing.Size(43, 23)
        Me.cb4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cb4.TabIndex = 0
        Me.cb4.Text = "SI"
        Me.cb4.TextColor = System.Drawing.Color.Navy
        '
        'Panel8
        '
        Me.Panel8.BackColor = System.Drawing.Color.Transparent
        Me.Panel8.Controls.Add(Me.cbb5)
        Me.Panel8.Controls.Add(Me.cb5)
        Me.Panel8.Location = New System.Drawing.Point(165, 137)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(123, 31)
        Me.Panel8.TabIndex = 124
        '
        'cbb5
        '
        '
        '
        '
        Me.cbb5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cbb5.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.cbb5.CheckSignSize = New System.Drawing.Size(17, 17)
        Me.cbb5.FocusCuesEnabled = False
        Me.cbb5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbb5.Location = New System.Drawing.Point(64, 4)
        Me.cbb5.Name = "cbb5"
        Me.cbb5.Size = New System.Drawing.Size(50, 23)
        Me.cbb5.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cbb5.TabIndex = 68
        Me.cbb5.Text = "NO"
        '
        'cb5
        '
        '
        '
        '
        Me.cb5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cb5.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.cb5.CheckSignSize = New System.Drawing.Size(17, 17)
        Me.cb5.FocusCuesEnabled = False
        Me.cb5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb5.Location = New System.Drawing.Point(3, 4)
        Me.cb5.Name = "cb5"
        Me.cb5.Size = New System.Drawing.Size(43, 23)
        Me.cb5.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cb5.TabIndex = 0
        Me.cb5.Text = "SI"
        Me.cb5.TextColor = System.Drawing.Color.Navy
        '
        'Panel9
        '
        Me.Panel9.BackColor = System.Drawing.Color.Transparent
        Me.Panel9.Controls.Add(Me.cbb6)
        Me.Panel9.Controls.Add(Me.cb6)
        Me.Panel9.Location = New System.Drawing.Point(165, 167)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(123, 31)
        Me.Panel9.TabIndex = 125
        '
        'cbb6
        '
        '
        '
        '
        Me.cbb6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cbb6.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.cbb6.CheckSignSize = New System.Drawing.Size(17, 17)
        Me.cbb6.FocusCuesEnabled = False
        Me.cbb6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbb6.Location = New System.Drawing.Point(64, 4)
        Me.cbb6.Name = "cbb6"
        Me.cbb6.Size = New System.Drawing.Size(50, 23)
        Me.cbb6.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cbb6.TabIndex = 68
        Me.cbb6.Text = "NO"
        '
        'cb6
        '
        '
        '
        '
        Me.cb6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cb6.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.cb6.CheckSignSize = New System.Drawing.Size(17, 17)
        Me.cb6.FocusCuesEnabled = False
        Me.cb6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb6.Location = New System.Drawing.Point(3, 4)
        Me.cb6.Name = "cb6"
        Me.cb6.Size = New System.Drawing.Size(43, 23)
        Me.cb6.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cb6.TabIndex = 0
        Me.cb6.Text = "SI"
        Me.cb6.TextColor = System.Drawing.Color.Navy
        '
        'Panel23
        '
        Me.Panel23.AutoScroll = True
        Me.Panel23.Controls.Add(Me.lb7)
        Me.Panel23.Controls.Add(Me.lb8)
        Me.Panel23.Controls.Add(Me.lb9)
        Me.Panel23.Controls.Add(Me.Panel10)
        Me.Panel23.Controls.Add(Me.lb10)
        Me.Panel23.Controls.Add(Me.lb11)
        Me.Panel23.Controls.Add(Me.Panel11)
        Me.Panel23.Controls.Add(Me.lb12)
        Me.Panel23.Controls.Add(Me.Panel15)
        Me.Panel23.Controls.Add(Me.Panel12)
        Me.Panel23.Controls.Add(Me.Panel14)
        Me.Panel23.Controls.Add(Me.Panel13)
        Me.Panel23.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel23.Location = New System.Drawing.Point(343, 3)
        Me.Panel23.Name = "Panel23"
        Me.Panel23.Size = New System.Drawing.Size(334, 153)
        Me.Panel23.TabIndex = 133
        '
        'lb7
        '
        Me.lb7.AutoSize = True
        Me.lb7.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.lb7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lb7.Font = New System.Drawing.Font("Georgia", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb7.Location = New System.Drawing.Point(16, 12)
        Me.lb7.Name = "lb7"
        Me.lb7.Size = New System.Drawing.Size(133, 20)
        Me.lb7.TabIndex = 85
        Me.lb7.Text = "Llave de Ruedas:"
        Me.lb7.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'lb8
        '
        Me.lb8.AutoSize = True
        Me.lb8.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.lb8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lb8.Font = New System.Drawing.Font("Georgia", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb8.Location = New System.Drawing.Point(16, 45)
        Me.lb8.Name = "lb8"
        Me.lb8.Size = New System.Drawing.Size(204, 20)
        Me.lb8.TabIndex = 88
        Me.lb8.Text = "Estuche de Herramientas:"
        Me.lb8.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'lb9
        '
        Me.lb9.AutoSize = True
        Me.lb9.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.lb9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lb9.Font = New System.Drawing.Font("Georgia", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb9.Location = New System.Drawing.Point(16, 76)
        Me.lb9.Name = "lb9"
        Me.lb9.Size = New System.Drawing.Size(145, 20)
        Me.lb9.TabIndex = 91
        Me.lb9.Text = "Baston Seguridad:"
        Me.lb9.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'Panel10
        '
        Me.Panel10.BackColor = System.Drawing.Color.Transparent
        Me.Panel10.Controls.Add(Me.cbb12)
        Me.Panel10.Controls.Add(Me.cb12)
        Me.Panel10.Location = New System.Drawing.Point(223, 161)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(123, 31)
        Me.Panel10.TabIndex = 131
        '
        'cbb12
        '
        '
        '
        '
        Me.cbb12.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cbb12.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.cbb12.CheckSignSize = New System.Drawing.Size(17, 17)
        Me.cbb12.FocusCuesEnabled = False
        Me.cbb12.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbb12.Location = New System.Drawing.Point(64, 4)
        Me.cbb12.Name = "cbb12"
        Me.cbb12.Size = New System.Drawing.Size(50, 23)
        Me.cbb12.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cbb12.TabIndex = 68
        Me.cbb12.Text = "NO"
        '
        'cb12
        '
        '
        '
        '
        Me.cb12.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cb12.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.cb12.CheckSignSize = New System.Drawing.Size(17, 17)
        Me.cb12.FocusCuesEnabled = False
        Me.cb12.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb12.Location = New System.Drawing.Point(3, 4)
        Me.cb12.Name = "cb12"
        Me.cb12.Size = New System.Drawing.Size(43, 23)
        Me.cb12.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cb12.TabIndex = 0
        Me.cb12.Text = "SI"
        Me.cb12.TextColor = System.Drawing.Color.Navy
        '
        'lb10
        '
        Me.lb10.AutoSize = True
        Me.lb10.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.lb10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lb10.Font = New System.Drawing.Font("Georgia", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb10.Location = New System.Drawing.Point(16, 108)
        Me.lb10.Name = "lb10"
        Me.lb10.Size = New System.Drawing.Size(92, 20)
        Me.lb10.TabIndex = 94
        Me.lb10.Text = "Triangulos:"
        Me.lb10.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'lb11
        '
        Me.lb11.AutoSize = True
        Me.lb11.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.lb11.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lb11.Font = New System.Drawing.Font("Georgia", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb11.Location = New System.Drawing.Point(17, 139)
        Me.lb11.Name = "lb11"
        Me.lb11.Size = New System.Drawing.Size(102, 20)
        Me.lb11.TabIndex = 97
        Me.lb11.Text = "Encendedor:"
        Me.lb11.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'Panel11
        '
        Me.Panel11.BackColor = System.Drawing.Color.Transparent
        Me.Panel11.Controls.Add(Me.cbb11)
        Me.Panel11.Controls.Add(Me.cb11)
        Me.Panel11.Location = New System.Drawing.Point(223, 131)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(123, 31)
        Me.Panel11.TabIndex = 130
        '
        'cbb11
        '
        '
        '
        '
        Me.cbb11.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cbb11.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.cbb11.CheckSignSize = New System.Drawing.Size(17, 17)
        Me.cbb11.FocusCuesEnabled = False
        Me.cbb11.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbb11.Location = New System.Drawing.Point(64, 4)
        Me.cbb11.Name = "cbb11"
        Me.cbb11.Size = New System.Drawing.Size(50, 23)
        Me.cbb11.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cbb11.TabIndex = 68
        Me.cbb11.Text = "NO"
        '
        'cb11
        '
        '
        '
        '
        Me.cb11.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cb11.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.cb11.CheckSignSize = New System.Drawing.Size(17, 17)
        Me.cb11.FocusCuesEnabled = False
        Me.cb11.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb11.Location = New System.Drawing.Point(3, 4)
        Me.cb11.Name = "cb11"
        Me.cb11.Size = New System.Drawing.Size(43, 23)
        Me.cb11.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cb11.TabIndex = 0
        Me.cb11.Text = "SI"
        Me.cb11.TextColor = System.Drawing.Color.Navy
        '
        'lb12
        '
        Me.lb12.AutoSize = True
        Me.lb12.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.lb12.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lb12.Font = New System.Drawing.Font("Georgia", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb12.Location = New System.Drawing.Point(16, 168)
        Me.lb12.Name = "lb12"
        Me.lb12.Size = New System.Drawing.Size(98, 20)
        Me.lb12.TabIndex = 100
        Me.lb12.Text = "Tapa Cubos:"
        Me.lb12.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'Panel15
        '
        Me.Panel15.BackColor = System.Drawing.Color.Transparent
        Me.Panel15.Controls.Add(Me.cbb7)
        Me.Panel15.Controls.Add(Me.cb7)
        Me.Panel15.Location = New System.Drawing.Point(223, 10)
        Me.Panel15.Name = "Panel15"
        Me.Panel15.Size = New System.Drawing.Size(123, 27)
        Me.Panel15.TabIndex = 126
        '
        'cbb7
        '
        '
        '
        '
        Me.cbb7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cbb7.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.cbb7.CheckSignSize = New System.Drawing.Size(17, 17)
        Me.cbb7.FocusCuesEnabled = False
        Me.cbb7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbb7.Location = New System.Drawing.Point(64, 4)
        Me.cbb7.Name = "cbb7"
        Me.cbb7.Size = New System.Drawing.Size(50, 23)
        Me.cbb7.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cbb7.TabIndex = 68
        Me.cbb7.Text = "NO"
        '
        'cb7
        '
        Me.cb7.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.cb7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cb7.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.cb7.CheckSignSize = New System.Drawing.Size(17, 17)
        Me.cb7.FocusCuesEnabled = False
        Me.cb7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb7.Location = New System.Drawing.Point(3, 4)
        Me.cb7.Name = "cb7"
        Me.cb7.Size = New System.Drawing.Size(43, 23)
        Me.cb7.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cb7.TabIndex = 0
        Me.cb7.Text = "SI"
        Me.cb7.TextColor = System.Drawing.Color.Navy
        '
        'Panel12
        '
        Me.Panel12.BackColor = System.Drawing.Color.Transparent
        Me.Panel12.Controls.Add(Me.cbb10)
        Me.Panel12.Controls.Add(Me.cb10)
        Me.Panel12.Location = New System.Drawing.Point(223, 100)
        Me.Panel12.Name = "Panel12"
        Me.Panel12.Size = New System.Drawing.Size(123, 31)
        Me.Panel12.TabIndex = 129
        '
        'cbb10
        '
        '
        '
        '
        Me.cbb10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cbb10.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.cbb10.CheckSignSize = New System.Drawing.Size(17, 17)
        Me.cbb10.FocusCuesEnabled = False
        Me.cbb10.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbb10.Location = New System.Drawing.Point(64, 4)
        Me.cbb10.Name = "cbb10"
        Me.cbb10.Size = New System.Drawing.Size(50, 23)
        Me.cbb10.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cbb10.TabIndex = 68
        Me.cbb10.Text = "NO"
        '
        'cb10
        '
        '
        '
        '
        Me.cb10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cb10.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.cb10.CheckSignSize = New System.Drawing.Size(17, 17)
        Me.cb10.FocusCuesEnabled = False
        Me.cb10.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb10.Location = New System.Drawing.Point(3, 4)
        Me.cb10.Name = "cb10"
        Me.cb10.Size = New System.Drawing.Size(43, 23)
        Me.cb10.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cb10.TabIndex = 0
        Me.cb10.Text = "SI"
        Me.cb10.TextColor = System.Drawing.Color.Navy
        '
        'Panel14
        '
        Me.Panel14.BackColor = System.Drawing.Color.Transparent
        Me.Panel14.Controls.Add(Me.cbb8)
        Me.Panel14.Controls.Add(Me.cb8)
        Me.Panel14.Location = New System.Drawing.Point(223, 38)
        Me.Panel14.Name = "Panel14"
        Me.Panel14.Size = New System.Drawing.Size(123, 31)
        Me.Panel14.TabIndex = 127
        '
        'cbb8
        '
        '
        '
        '
        Me.cbb8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cbb8.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.cbb8.CheckSignSize = New System.Drawing.Size(17, 17)
        Me.cbb8.FocusCuesEnabled = False
        Me.cbb8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbb8.Location = New System.Drawing.Point(64, 4)
        Me.cbb8.Name = "cbb8"
        Me.cbb8.Size = New System.Drawing.Size(50, 23)
        Me.cbb8.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cbb8.TabIndex = 68
        Me.cbb8.Text = "NO"
        '
        'cb8
        '
        '
        '
        '
        Me.cb8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cb8.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.cb8.CheckSignSize = New System.Drawing.Size(17, 17)
        Me.cb8.FocusCuesEnabled = False
        Me.cb8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb8.Location = New System.Drawing.Point(3, 4)
        Me.cb8.Name = "cb8"
        Me.cb8.Size = New System.Drawing.Size(43, 23)
        Me.cb8.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cb8.TabIndex = 0
        Me.cb8.Text = "SI"
        Me.cb8.TextColor = System.Drawing.Color.Navy
        '
        'Panel13
        '
        Me.Panel13.BackColor = System.Drawing.Color.Transparent
        Me.Panel13.Controls.Add(Me.cbb9)
        Me.Panel13.Controls.Add(Me.cb9)
        Me.Panel13.Location = New System.Drawing.Point(223, 69)
        Me.Panel13.Name = "Panel13"
        Me.Panel13.Size = New System.Drawing.Size(123, 31)
        Me.Panel13.TabIndex = 128
        '
        'cbb9
        '
        '
        '
        '
        Me.cbb9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cbb9.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.cbb9.CheckSignSize = New System.Drawing.Size(17, 17)
        Me.cbb9.FocusCuesEnabled = False
        Me.cbb9.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbb9.Location = New System.Drawing.Point(64, 4)
        Me.cbb9.Name = "cbb9"
        Me.cbb9.Size = New System.Drawing.Size(50, 23)
        Me.cbb9.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cbb9.TabIndex = 68
        Me.cbb9.Text = "NO"
        '
        'cb9
        '
        '
        '
        '
        Me.cb9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cb9.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.cb9.CheckSignSize = New System.Drawing.Size(17, 17)
        Me.cb9.FocusCuesEnabled = False
        Me.cb9.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb9.Location = New System.Drawing.Point(3, 4)
        Me.cb9.Name = "cb9"
        Me.cb9.Size = New System.Drawing.Size(43, 23)
        Me.cb9.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cb9.TabIndex = 0
        Me.cb9.Text = "SI"
        Me.cb9.TextColor = System.Drawing.Color.Navy
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.GroupPanel2)
        Me.Panel4.Controls.Add(Me.GroupPanel3)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1028, 406)
        Me.Panel4.TabIndex = 3
        '
        'GroupPanel2
        '
        Me.GroupPanel2.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel2.Controls.Add(Me.SuperTabControl2)
        Me.GroupPanel2.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupPanel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupPanel2.Location = New System.Drawing.Point(561, 0)
        Me.GroupPanel2.Name = "GroupPanel2"
        Me.GroupPanel2.Padding = New System.Windows.Forms.Padding(3)
        Me.GroupPanel2.Size = New System.Drawing.Size(467, 406)
        '
        '
        '
        Me.GroupPanel2.Style.BackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.GroupPanel2.Style.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.GroupPanel2.Style.BackColorGradientAngle = 90
        Me.GroupPanel2.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderBottomWidth = 1
        Me.GroupPanel2.Style.BorderColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.GroupPanel2.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderLeftWidth = 1
        Me.GroupPanel2.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderRightWidth = 1
        Me.GroupPanel2.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderTopWidth = 1
        Me.GroupPanel2.Style.CornerDiameter = 4
        Me.GroupPanel2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel2.Style.Font = New System.Drawing.Font("Georgia", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupPanel2.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel2.Style.TextColor = System.Drawing.Color.White
        Me.GroupPanel2.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanel2.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel2.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel2.TabIndex = 25
        Me.GroupPanel2.Text = "I N F O R M A C I O N"
        '
        'SuperTabControl2
        '
        '
        '
        '
        '
        '
        '
        Me.SuperTabControl2.ControlBox.CloseBox.Name = ""
        '
        '
        '
        Me.SuperTabControl2.ControlBox.MenuBox.Name = ""
        Me.SuperTabControl2.ControlBox.Name = ""
        Me.SuperTabControl2.ControlBox.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.SuperTabControl2.ControlBox.MenuBox, Me.SuperTabControl2.ControlBox.CloseBox})
        Me.SuperTabControl2.Controls.Add(Me.SuperTabControlPanel3)
        Me.SuperTabControl2.Controls.Add(Me.SuperTabControlPanel4)
        Me.SuperTabControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControl2.ForeColor = System.Drawing.Color.White
        Me.SuperTabControl2.Location = New System.Drawing.Point(3, 3)
        Me.SuperTabControl2.Name = "SuperTabControl2"
        Me.SuperTabControl2.ReorderTabsEnabled = True
        Me.SuperTabControl2.SelectedTabFont = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.SuperTabControl2.SelectedTabIndex = 0
        Me.SuperTabControl2.Size = New System.Drawing.Size(455, 378)
        Me.SuperTabControl2.TabFont = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SuperTabControl2.TabIndex = 1
        Me.SuperTabControl2.Tabs.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.SuperTabItem3, Me.SuperTabItem4})
        SuperTabLinearGradientColorTable1.Colors = New System.Drawing.Color() {System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(66, Byte), Integer))}
        SuperTabColorTable1.Background = SuperTabLinearGradientColorTable1
        Me.SuperTabControl2.TabStripColor = SuperTabColorTable1
        Me.SuperTabControl2.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.Office2010BackstageBlue
        Me.SuperTabControl2.Text = "Descuento"
        '
        'SuperTabControlPanel3
        '
        Me.SuperTabControlPanel3.Controls.Add(Me.Panel26)
        Me.SuperTabControlPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel3.Location = New System.Drawing.Point(0, 25)
        Me.SuperTabControlPanel3.Name = "SuperTabControlPanel3"
        Me.SuperTabControlPanel3.Size = New System.Drawing.Size(455, 353)
        Me.SuperTabControlPanel3.TabIndex = 1
        Me.SuperTabControlPanel3.TabItem = Me.SuperTabItem3
        '
        'Panel26
        '
        Me.Panel26.Controls.Add(Me.pbImgProdu)
        Me.Panel26.Controls.Add(Me.panelA)
        Me.Panel26.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel26.Location = New System.Drawing.Point(0, 0)
        Me.Panel26.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel26.Name = "Panel26"
        Me.Panel26.Size = New System.Drawing.Size(455, 353)
        Me.Panel26.TabIndex = 0
        '
        'pbImgProdu
        '
        Me.pbImgProdu.BackColor = System.Drawing.Color.White
        Me.pbImgProdu.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pbImgProdu.Location = New System.Drawing.Point(200, 0)
        Me.pbImgProdu.Name = "pbImgProdu"
        Me.pbImgProdu.Size = New System.Drawing.Size(255, 353)
        Me.pbImgProdu.TabIndex = 2
        Me.pbImgProdu.TabStop = False
        '
        'panelA
        '
        Me.panelA.AutoScroll = True
        Me.panelA.BackColor = System.Drawing.Color.WhiteSmoke
        Me.panelA.Dock = System.Windows.Forms.DockStyle.Left
        Me.panelA.Location = New System.Drawing.Point(0, 0)
        Me.panelA.Name = "panelA"
        Me.panelA.Size = New System.Drawing.Size(200, 353)
        Me.panelA.TabIndex = 1
        '
        'SuperTabItem3
        '
        Me.SuperTabItem3.AttachedControl = Me.SuperTabControlPanel3
        Me.SuperTabItem3.GlobalItem = False
        Me.SuperTabItem3.Name = "SuperTabItem3"
        Me.SuperTabItem3.Text = "Imagenes"
        '
        'SuperTabControlPanel4
        '
        Me.SuperTabControlPanel4.Controls.Add(Me.GridEX1)
        Me.SuperTabControlPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel4.Location = New System.Drawing.Point(0, 27)
        Me.SuperTabControlPanel4.Name = "SuperTabControlPanel4"
        Me.SuperTabControlPanel4.Size = New System.Drawing.Size(483, 290)
        Me.SuperTabControlPanel4.TabIndex = 0
        Me.SuperTabControlPanel4.TabItem = Me.SuperTabItem4
        '
        'GridEX1
        '
        Me.GridEX1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridEX1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridEX1.Location = New System.Drawing.Point(0, 0)
        Me.GridEX1.Name = "GridEX1"
        Me.GridEX1.Size = New System.Drawing.Size(483, 290)
        Me.GridEX1.TabIndex = 0
        '
        'SuperTabItem4
        '
        Me.SuperTabItem4.AttachedControl = Me.SuperTabControlPanel4
        Me.SuperTabItem4.GlobalItem = False
        Me.SuperTabItem4.Name = "SuperTabItem4"
        Me.SuperTabItem4.Text = "Descuento"
        Me.SuperTabItem4.Visible = False
        '
        'GroupPanel3
        '
        Me.GroupPanel3.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel3.Controls.Add(Me.Panel25)
        Me.GroupPanel3.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel3.Dock = System.Windows.Forms.DockStyle.Left
        Me.GroupPanel3.Location = New System.Drawing.Point(0, 0)
        Me.GroupPanel3.Name = "GroupPanel3"
        Me.GroupPanel3.Size = New System.Drawing.Size(561, 406)
        '
        '
        '
        Me.GroupPanel3.Style.BackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.GroupPanel3.Style.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(127, Byte), Integer))
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
        Me.GroupPanel3.Style.Font = New System.Drawing.Font("Georgia", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupPanel3.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel3.Style.TextColor = System.Drawing.Color.White
        Me.GroupPanel3.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanel3.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel3.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel3.TabIndex = 1
        Me.GroupPanel3.Text = "DATOS GENERALES"
        '
        'Panel25
        '
        Me.Panel25.Controls.Add(Me.tbObservacionR)
        Me.Panel25.Controls.Add(Me.LabelX26)
        Me.Panel25.Controls.Add(Me.LabelX4)
        Me.Panel25.Controls.Add(Me.cbTipoVehiculoR)
        Me.Panel25.Controls.Add(Me.tbPlacaR)
        Me.Panel25.Controls.Add(Me.tbFechaR)
        Me.Panel25.Controls.Add(Me.LabelX5)
        Me.Panel25.Controls.Add(Me.LabelX7)
        Me.Panel25.Controls.Add(Me.cbTamanoR)
        Me.Panel25.Controls.Add(Me.SwClienteR)
        Me.Panel25.Controls.Add(Me.tbMarcaR)
        Me.Panel25.Controls.Add(Me.LabelX9)
        Me.Panel25.Controls.Add(Me.TextBoxX1)
        Me.Panel25.Controls.Add(Me.TextBoxX2)
        Me.Panel25.Controls.Add(Me.tbClienteR)
        Me.Panel25.Controls.Add(Me.LabelX11)
        Me.Panel25.Controls.Add(Me.tbNroOrdenR)
        Me.Panel25.Controls.Add(Me.LabelX12)
        Me.Panel25.Controls.Add(Me.LabelX13)
        Me.Panel25.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel25.Font = New System.Drawing.Font("Georgia", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel25.Location = New System.Drawing.Point(0, 0)
        Me.Panel25.Name = "Panel25"
        Me.Panel25.Size = New System.Drawing.Size(555, 384)
        Me.Panel25.TabIndex = 0
        '
        'tbObservacionR
        '
        Me.tbObservacionR.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.tbObservacionR.Border.Class = "TextBoxBorder"
        Me.tbObservacionR.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbObservacionR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbObservacionR.Location = New System.Drawing.Point(189, 234)
        Me.tbObservacionR.Multiline = True
        Me.tbObservacionR.Name = "tbObservacionR"
        Me.tbObservacionR.PreventEnterBeep = True
        Me.tbObservacionR.ReadOnly = True
        Me.tbObservacionR.Size = New System.Drawing.Size(350, 88)
        Me.tbObservacionR.TabIndex = 68
        '
        'LabelX26
        '
        Me.LabelX26.AutoSize = True
        Me.LabelX26.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX26.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX26.Font = New System.Drawing.Font("Georgia", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX26.Location = New System.Drawing.Point(57, 234)
        Me.LabelX26.Name = "LabelX26"
        Me.LabelX26.Size = New System.Drawing.Size(84, 16)
        Me.LabelX26.TabIndex = 67
        Me.LabelX26.Text = "Observacion:"
        '
        'LabelX4
        '
        Me.LabelX4.AutoSize = True
        Me.LabelX4.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.Font = New System.Drawing.Font("Georgia", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX4.Location = New System.Drawing.Point(57, 177)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(93, 16)
        Me.LabelX4.TabIndex = 66
        Me.LabelX4.Text = "Tipo Vehiculo:"
        '
        'cbTipoVehiculoR
        '
        cbTipoVehiculoR_DesignTimeLayout.LayoutString = resources.GetString("cbTipoVehiculoR_DesignTimeLayout.LayoutString")
        Me.cbTipoVehiculoR.DesignTimeLayout = cbTipoVehiculoR_DesignTimeLayout
        Me.cbTipoVehiculoR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbTipoVehiculoR.Location = New System.Drawing.Point(189, 172)
        Me.cbTipoVehiculoR.Name = "cbTipoVehiculoR"
        Me.cbTipoVehiculoR.Office2007ColorScheme = Janus.Windows.GridEX.Office2007ColorScheme.Custom
        Me.cbTipoVehiculoR.Office2007CustomColor = System.Drawing.Color.DodgerBlue
        Me.cbTipoVehiculoR.ReadOnly = True
        Me.cbTipoVehiculoR.SelectedIndex = -1
        Me.cbTipoVehiculoR.SelectedItem = Nothing
        Me.cbTipoVehiculoR.Size = New System.Drawing.Size(216, 20)
        Me.cbTipoVehiculoR.TabIndex = 65
        Me.cbTipoVehiculoR.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'tbPlacaR
        '
        Me.tbPlacaR.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.tbPlacaR.Border.Class = "TextBoxBorder"
        Me.tbPlacaR.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbPlacaR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbPlacaR.Location = New System.Drawing.Point(189, 76)
        Me.tbPlacaR.Name = "tbPlacaR"
        Me.tbPlacaR.PreventEnterBeep = True
        Me.tbPlacaR.ReadOnly = True
        Me.tbPlacaR.Size = New System.Drawing.Size(168, 21)
        Me.tbPlacaR.TabIndex = 64
        '
        'tbFechaR
        '
        '
        '
        '
        Me.tbFechaR.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.tbFechaR.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbFechaR.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.tbFechaR.ButtonDropDown.Visible = True
        Me.tbFechaR.DateTimeSelectorVisibility = DevComponents.Editors.DateTimeAdv.eDateTimeSelectorVisibility.DateSelector
        Me.tbFechaR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbFechaR.IsInputReadOnly = True
        Me.tbFechaR.IsPopupCalendarOpen = False
        Me.tbFechaR.Location = New System.Drawing.Point(189, 203)
        '
        '
        '
        '
        '
        '
        Me.tbFechaR.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbFechaR.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.tbFechaR.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.tbFechaR.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.tbFechaR.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.tbFechaR.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.tbFechaR.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.tbFechaR.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.tbFechaR.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.tbFechaR.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbFechaR.MonthCalendar.DisplayMonth = New Date(2017, 2, 1, 0, 0, 0, 0)
        Me.tbFechaR.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday
        '
        '
        '
        Me.tbFechaR.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.tbFechaR.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.tbFechaR.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.tbFechaR.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbFechaR.MonthCalendar.TodayButtonVisible = True
        Me.tbFechaR.Name = "tbFechaR"
        Me.tbFechaR.Size = New System.Drawing.Size(120, 21)
        Me.tbFechaR.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.tbFechaR.TabIndex = 60
        '
        'LabelX5
        '
        Me.LabelX5.AutoSize = True
        Me.LabelX5.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.Font = New System.Drawing.Font("Georgia", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX5.Location = New System.Drawing.Point(60, 208)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(44, 16)
        Me.LabelX5.TabIndex = 61
        Me.LabelX5.Text = "Fecha:"
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
        Me.LabelX7.Location = New System.Drawing.Point(57, 145)
        Me.LabelX7.Name = "LabelX7"
        Me.LabelX7.Size = New System.Drawing.Size(115, 16)
        Me.LabelX7.TabIndex = 62
        Me.LabelX7.Text = "Tamaño Vehiculo:"
        '
        'cbTamanoR
        '
        cbTamanoR_DesignTimeLayout.LayoutString = resources.GetString("cbTamanoR_DesignTimeLayout.LayoutString")
        Me.cbTamanoR.DesignTimeLayout = cbTamanoR_DesignTimeLayout
        Me.cbTamanoR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbTamanoR.Location = New System.Drawing.Point(189, 140)
        Me.cbTamanoR.Name = "cbTamanoR"
        Me.cbTamanoR.Office2007ColorScheme = Janus.Windows.GridEX.Office2007ColorScheme.Custom
        Me.cbTamanoR.Office2007CustomColor = System.Drawing.Color.DodgerBlue
        Me.cbTamanoR.ReadOnly = True
        Me.cbTamanoR.SelectedIndex = -1
        Me.cbTamanoR.SelectedItem = Nothing
        Me.cbTamanoR.Size = New System.Drawing.Size(168, 20)
        Me.cbTamanoR.TabIndex = 59
        Me.cbTamanoR.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'SwClienteR
        '
        '
        '
        '
        Me.SwClienteR.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.SwClienteR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SwClienteR.IsReadOnly = True
        Me.SwClienteR.Location = New System.Drawing.Point(333, 203)
        Me.SwClienteR.Name = "SwClienteR"
        Me.SwClienteR.OffBackColor = System.Drawing.Color.DodgerBlue
        Me.SwClienteR.OffText = "SOCIO"
        Me.SwClienteR.OffTextColor = System.Drawing.Color.White
        Me.SwClienteR.OnBackColor = System.Drawing.Color.MidnightBlue
        Me.SwClienteR.OnText = "CLIENTE N"
        Me.SwClienteR.OnTextColor = System.Drawing.Color.White
        Me.SwClienteR.Size = New System.Drawing.Size(136, 22)
        Me.SwClienteR.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.SwClienteR.TabIndex = 63
        Me.SwClienteR.Value = True
        Me.SwClienteR.ValueObject = "Y"
        '
        'tbMarcaR
        '
        Me.tbMarcaR.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.tbMarcaR.Border.Class = "TextBoxBorder"
        Me.tbMarcaR.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbMarcaR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbMarcaR.Location = New System.Drawing.Point(189, 108)
        Me.tbMarcaR.Name = "tbMarcaR"
        Me.tbMarcaR.PreventEnterBeep = True
        Me.tbMarcaR.ReadOnly = True
        Me.tbMarcaR.Size = New System.Drawing.Size(267, 21)
        Me.tbMarcaR.TabIndex = 58
        '
        'LabelX9
        '
        Me.LabelX9.AutoSize = True
        Me.LabelX9.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX9.Font = New System.Drawing.Font("Georgia", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX9.Location = New System.Drawing.Point(57, 113)
        Me.LabelX9.Name = "LabelX9"
        Me.LabelX9.Size = New System.Drawing.Size(46, 16)
        Me.LabelX9.TabIndex = 57
        Me.LabelX9.Text = "Marca:"
        '
        'TextBoxX1
        '
        '
        '
        '
        Me.TextBoxX1.Border.Class = "TextBoxBorder"
        Me.TextBoxX1.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TextBoxX1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxX1.Location = New System.Drawing.Point(295, 12)
        Me.TextBoxX1.Name = "TextBoxX1"
        Me.TextBoxX1.PreventEnterBeep = True
        Me.TextBoxX1.Size = New System.Drawing.Size(51, 21)
        Me.TextBoxX1.TabIndex = 55
        Me.TextBoxX1.Visible = False
        '
        'TextBoxX2
        '
        '
        '
        '
        Me.TextBoxX2.Border.Class = "TextBoxBorder"
        Me.TextBoxX2.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TextBoxX2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxX2.Location = New System.Drawing.Point(370, 12)
        Me.TextBoxX2.Name = "TextBoxX2"
        Me.TextBoxX2.PreventEnterBeep = True
        Me.TextBoxX2.Size = New System.Drawing.Size(51, 23)
        Me.TextBoxX2.TabIndex = 56
        Me.TextBoxX2.Visible = False
        '
        'tbClienteR
        '
        Me.tbClienteR.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.tbClienteR.Border.Class = "TextBoxBorder"
        Me.tbClienteR.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbClienteR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbClienteR.Location = New System.Drawing.Point(189, 44)
        Me.tbClienteR.Name = "tbClienteR"
        Me.tbClienteR.PreventEnterBeep = True
        Me.tbClienteR.ReadOnly = True
        Me.tbClienteR.Size = New System.Drawing.Size(350, 21)
        Me.tbClienteR.TabIndex = 49
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
        Me.LabelX11.Location = New System.Drawing.Point(57, 77)
        Me.LabelX11.Name = "LabelX11"
        Me.LabelX11.Size = New System.Drawing.Size(40, 16)
        Me.LabelX11.TabIndex = 51
        Me.LabelX11.Text = "Placa:"
        '
        'tbNroOrdenR
        '
        '
        '
        '
        Me.tbNroOrdenR.Border.Class = "TextBoxBorder"
        Me.tbNroOrdenR.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbNroOrdenR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbNroOrdenR.Location = New System.Drawing.Point(189, 12)
        Me.tbNroOrdenR.Name = "tbNroOrdenR"
        Me.tbNroOrdenR.PreventEnterBeep = True
        Me.tbNroOrdenR.ReadOnly = True
        Me.tbNroOrdenR.Size = New System.Drawing.Size(87, 21)
        Me.tbNroOrdenR.TabIndex = 48
        Me.tbNroOrdenR.WatermarkColor = System.Drawing.Color.White
        '
        'LabelX12
        '
        Me.LabelX12.AutoSize = True
        Me.LabelX12.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX12.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX12.Font = New System.Drawing.Font("Georgia", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX12.Location = New System.Drawing.Point(57, 14)
        Me.LabelX12.Name = "LabelX12"
        Me.LabelX12.Size = New System.Drawing.Size(118, 16)
        Me.LabelX12.TabIndex = 53
        Me.LabelX12.Text = "Numero de Orden:"
        '
        'LabelX13
        '
        Me.LabelX13.AutoSize = True
        Me.LabelX13.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX13.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX13.Font = New System.Drawing.Font("Georgia", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX13.Location = New System.Drawing.Point(57, 49)
        Me.LabelX13.Name = "LabelX13"
        Me.LabelX13.Size = New System.Drawing.Size(51, 16)
        Me.LabelX13.TabIndex = 50
        Me.LabelX13.Text = "Cliente:"
        '
        'F1_ServicioVenta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1028, 609)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "F1_ServicioVenta"
        Me.Text = "     "
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
        Me.MPanelSup.ResumeLayout(False)
        Me.PanelPrincipal.ResumeLayout(False)
        Me.GroupPanelBuscador.ResumeLayout(False)
        CType(Me.JGrM_Buscador, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelUsuario.ResumeLayout(False)
        Me.PanelUsuario.PerformLayout()
        Me.PanelNavegacion.ResumeLayout(False)
        Me.MPanelUserAct.ResumeLayout(False)
        Me.MPanelUserAct.PerformLayout()
        CType(Me.MEP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GpDetalle.ResumeLayout(False)
        CType(Me.grDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmOpciones.ResumeLayout(False)
        CType(Me.FechaVenta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GpVentasSinCobrar.ResumeLayout(False)
        CType(Me.SuperTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SuperTabControl1.ResumeLayout(False)
        Me.SuperTabControlPanel1.ResumeLayout(False)
        CType(Me.grVentasPendientes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SuperTabControlPanel2.ResumeLayout(False)
        CType(Me.grPolitica, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbTipo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelDatos.ResumeLayout(False)
        Me.PanelDatos.PerformLayout()
        CType(Me.cbTipoCliente, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbcredito, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbventa, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelDatosTop.ResumeLayout(False)
        Me.PanelButton.ResumeLayout(False)
        Me.GpPanelServicio.ResumeLayout(False)
        CType(Me.grProducto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.GroupPanel1.ResumeLayout(False)
        Me.PanelCombos.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel24.ResumeLayout(False)
        Me.Panel24.PerformLayout()
        Me.Panel21.ResumeLayout(False)
        Me.Panel16.ResumeLayout(False)
        Me.Panel17.ResumeLayout(False)
        Me.Panel18.ResumeLayout(False)
        Me.Panel19.ResumeLayout(False)
        Me.Panel20.ResumeLayout(False)
        Me.Panel22.ResumeLayout(False)
        Me.Panel22.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        Me.Panel7.ResumeLayout(False)
        Me.Panel8.ResumeLayout(False)
        Me.Panel9.ResumeLayout(False)
        Me.Panel23.ResumeLayout(False)
        Me.Panel23.PerformLayout()
        Me.Panel10.ResumeLayout(False)
        Me.Panel11.ResumeLayout(False)
        Me.Panel15.ResumeLayout(False)
        Me.Panel12.ResumeLayout(False)
        Me.Panel14.ResumeLayout(False)
        Me.Panel13.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.GroupPanel2.ResumeLayout(False)
        CType(Me.SuperTabControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SuperTabControl2.ResumeLayout(False)
        Me.SuperTabControlPanel3.ResumeLayout(False)
        Me.Panel26.ResumeLayout(False)
        CType(Me.pbImgProdu, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SuperTabControlPanel4.ResumeLayout(False)
        CType(Me.GridEX1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel3.ResumeLayout(False)
        Me.Panel25.ResumeLayout(False)
        Me.Panel25.PerformLayout()
        CType(Me.cbTipoVehiculoR, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbFechaR, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbTamanoR, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GpVentasSinCobrar As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents grVentasPendientes As Janus.Windows.GridEX.GridEX
    Friend WithEvents Estado As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents LabelX10 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX8 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Friend WithEvents FechaVenta As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents tbCodigo As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents GpDetalle As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents grDetalle As Janus.Windows.GridEX.GridEX
    Friend WithEvents ButtonX2 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ButtonX1 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents tbCliente As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents tbnumiCliente As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents cmOpciones As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents Eliminarms As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents tbnumiVehiculo As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents tbVehiculo As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents cbTipo As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents UsImg As Presentacion.Us_Image
    Friend WithEvents btnAnadir As DevComponents.DotNetBar.ButtonX
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents tbNumeroOrden As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents tbFechaPago As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents lbFechaPago As DevComponents.DotNetBar.LabelX
    Friend WithEvents PanelDatos As System.Windows.Forms.Panel
    Friend WithEvents SuperTabControl1 As DevComponents.DotNetBar.SuperTabControl
    Friend WithEvents SuperTabControlPanel1 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents SuperTabItem1 As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents SuperTabControlPanel2 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents SuperTabItem2 As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents grPolitica As Janus.Windows.GridEX.GridEX
    Friend WithEvents lbUltimaPago As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents tbTablet As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents PanelButton As System.Windows.Forms.Panel
    Friend WithEvents PanelDatosTop As System.Windows.Forms.Panel
    Friend WithEvents GpPanelServicio As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents grProducto As Janus.Windows.GridEX.GridEX
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents PanelCombos As System.Windows.Forms.Panel
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel24 As System.Windows.Forms.Panel
    Friend WithEvents Panel21 As System.Windows.Forms.Panel
    Friend WithEvents cbb13 As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents cb13 As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents lb13 As DevComponents.DotNetBar.LabelX
    Friend WithEvents lb14 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Panel16 As System.Windows.Forms.Panel
    Friend WithEvents cbb18 As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents cb18 As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents lb15 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Panel17 As System.Windows.Forms.Panel
    Friend WithEvents cbb17 As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents cb17 As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents lb16 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Panel18 As System.Windows.Forms.Panel
    Friend WithEvents cbb16 As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents cb16 As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents lb17 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Panel19 As System.Windows.Forms.Panel
    Friend WithEvents cbb15 As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents cb15 As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents lb18 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Panel20 As System.Windows.Forms.Panel
    Friend WithEvents cbb14 As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents cb14 As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Panel22 As System.Windows.Forms.Panel
    Friend WithEvents lb1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents lb2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents lb3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents lb4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents lb5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents lb6 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents cbb1 As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents cb1 As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents cbb2 As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents cb2 As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents cbb3 As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents cb3 As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents cbb4 As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents cb4 As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Panel8 As System.Windows.Forms.Panel
    Friend WithEvents cbb5 As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents cb5 As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Panel9 As System.Windows.Forms.Panel
    Friend WithEvents cbb6 As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents cb6 As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Panel23 As System.Windows.Forms.Panel
    Friend WithEvents lb7 As DevComponents.DotNetBar.LabelX
    Friend WithEvents lb8 As DevComponents.DotNetBar.LabelX
    Friend WithEvents lb9 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Panel10 As System.Windows.Forms.Panel
    Friend WithEvents cbb12 As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents cb12 As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents lb10 As DevComponents.DotNetBar.LabelX
    Friend WithEvents lb11 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Panel11 As System.Windows.Forms.Panel
    Friend WithEvents cbb11 As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents cb11 As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents lb12 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Panel15 As System.Windows.Forms.Panel
    Friend WithEvents cbb7 As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents cb7 As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Panel12 As System.Windows.Forms.Panel
    Friend WithEvents cbb10 As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents cb10 As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Panel14 As System.Windows.Forms.Panel
    Friend WithEvents cbb8 As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents cb8 As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Panel13 As System.Windows.Forms.Panel
    Friend WithEvents cbb9 As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents cb9 As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents GroupPanel2 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents SuperTabControl2 As DevComponents.DotNetBar.SuperTabControl
    Friend WithEvents SuperTabControlPanel3 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents SuperTabItem3 As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents SuperTabControlPanel4 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents GridEX1 As Janus.Windows.GridEX.GridEX
    Friend WithEvents SuperTabItem4 As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents GroupPanel3 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Panel25 As System.Windows.Forms.Panel
    Friend WithEvents tbObservacionR As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX26 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents cbTipoVehiculoR As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents tbPlacaR As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents tbFechaR As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX7 As DevComponents.DotNetBar.LabelX
    Friend WithEvents cbTamanoR As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents SwClienteR As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents tbMarcaR As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX9 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TextBoxX1 As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents TextBoxX2 As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents tbClienteR As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX11 As DevComponents.DotNetBar.LabelX
    Friend WithEvents tbNroOrdenR As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX12 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX13 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Panel26 As System.Windows.Forms.Panel
    Friend WithEvents panelA As System.Windows.Forms.Panel
    Friend WithEvents pbImgProdu As System.Windows.Forms.PictureBox
    Friend WithEvents cbventa As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents cbmoneda As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents LabelX14 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX15 As DevComponents.DotNetBar.LabelX
    Friend WithEvents tbcredito As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents lbcredito As DevComponents.DotNetBar.LabelX
    Friend WithEvents tbObservacion As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents lboservacion As DevComponents.DotNetBar.LabelX
    Friend WithEvents tbbanco As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents lbbanco As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX16 As DevComponents.DotNetBar.LabelX
    Friend WithEvents cbTipoCliente As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents swServicios As DevComponents.DotNetBar.Controls.SwitchButton
End Class
