<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F1_CLIENTE_H
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F1_CLIENTE_H))
        Me.BtnCargarImage = New System.Windows.Forms.Button()
        Me.LabelX16 = New DevComponents.DotNetBar.LabelX()
        Me.tbEstado = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.LabelX15 = New DevComponents.DotNetBar.LabelX()
        Me.tbObs = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX14 = New DevComponents.DotNetBar.LabelX()
        Me.tbTel2 = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX13 = New DevComponents.DotNetBar.LabelX()
        Me.tbTel1 = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX12 = New DevComponents.DotNetBar.LabelX()
        Me.tbEmail = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX11 = New DevComponents.DotNetBar.LabelX()
        Me.tbDir = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX10 = New DevComponents.DotNetBar.LabelX()
        Me.tbCi = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX9 = New DevComponents.DotNetBar.LabelX()
        Me.tbNombre = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        Me.tbFnac = New System.Windows.Forms.DateTimePicker()
        Me.tbFIngr = New System.Windows.Forms.DateTimePicker()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.tbNSoc = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.tbNumi = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.UsImg = New Presentacion.Us_Image()
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
        Me.SuperTabPrincipal.Size = New System.Drawing.Size(1354, 733)
        Me.SuperTabPrincipal.Controls.SetChildIndex(Me.SuperTabControlPanelBuscador, 0)
        Me.SuperTabPrincipal.Controls.SetChildIndex(Me.SuperTabControlPanelRegistro, 0)
        '
        'SuperTabControlPanelBuscador
        '
        Me.SuperTabControlPanelBuscador.Size = New System.Drawing.Size(1354, 708)
        '
        'SuperTabControlPanelRegistro
        '
        Me.SuperTabControlPanelRegistro.Size = New System.Drawing.Size(1354, 708)
        Me.SuperTabControlPanelRegistro.Controls.SetChildIndex(Me.PanelSuperior, 0)
        Me.SuperTabControlPanelRegistro.Controls.SetChildIndex(Me.PanelInferior, 0)
        Me.SuperTabControlPanelRegistro.Controls.SetChildIndex(Me.PanelPrincipal, 0)
        '
        'PanelSuperior
        '
        Me.PanelSuperior.Size = New System.Drawing.Size(1354, 72)
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
        Me.PanelInferior.Location = New System.Drawing.Point(0, 672)
        Me.PanelInferior.Size = New System.Drawing.Size(1354, 36)
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
        Me.PanelToolBar2.Location = New System.Drawing.Point(1274, 0)
        '
        'MPanelSup
        '
        Me.MPanelSup.Controls.Add(Me.BtnCargarImage)
        Me.MPanelSup.Controls.Add(Me.UsImg)
        Me.MPanelSup.Controls.Add(Me.LabelX1)
        Me.MPanelSup.Controls.Add(Me.tbNumi)
        Me.MPanelSup.Controls.Add(Me.LabelX16)
        Me.MPanelSup.Controls.Add(Me.LabelX3)
        Me.MPanelSup.Controls.Add(Me.tbEstado)
        Me.MPanelSup.Controls.Add(Me.tbNSoc)
        Me.MPanelSup.Controls.Add(Me.LabelX15)
        Me.MPanelSup.Controls.Add(Me.LabelX4)
        Me.MPanelSup.Controls.Add(Me.tbObs)
        Me.MPanelSup.Controls.Add(Me.LabelX5)
        Me.MPanelSup.Controls.Add(Me.LabelX14)
        Me.MPanelSup.Controls.Add(Me.tbFIngr)
        Me.MPanelSup.Controls.Add(Me.tbTel2)
        Me.MPanelSup.Controls.Add(Me.tbFnac)
        Me.MPanelSup.Controls.Add(Me.LabelX13)
        Me.MPanelSup.Controls.Add(Me.LabelX6)
        Me.MPanelSup.Controls.Add(Me.tbTel1)
        Me.MPanelSup.Controls.Add(Me.tbNombre)
        Me.MPanelSup.Controls.Add(Me.LabelX12)
        Me.MPanelSup.Controls.Add(Me.tbEmail)
        Me.MPanelSup.Controls.Add(Me.LabelX11)
        Me.MPanelSup.Controls.Add(Me.tbDir)
        Me.MPanelSup.Controls.Add(Me.LabelX10)
        Me.MPanelSup.Controls.Add(Me.LabelX9)
        Me.MPanelSup.Controls.Add(Me.tbCi)
        Me.MPanelSup.Size = New System.Drawing.Size(1354, 320)
        Me.MPanelSup.Controls.SetChildIndex(Me.tbCi, 0)
        Me.MPanelSup.Controls.SetChildIndex(Me.LabelX9, 0)
        Me.MPanelSup.Controls.SetChildIndex(Me.LabelX10, 0)
        Me.MPanelSup.Controls.SetChildIndex(Me.tbDir, 0)
        Me.MPanelSup.Controls.SetChildIndex(Me.LabelX11, 0)
        Me.MPanelSup.Controls.SetChildIndex(Me.tbEmail, 0)
        Me.MPanelSup.Controls.SetChildIndex(Me.LabelX12, 0)
        Me.MPanelSup.Controls.SetChildIndex(Me.tbNombre, 0)
        Me.MPanelSup.Controls.SetChildIndex(Me.tbTel1, 0)
        Me.MPanelSup.Controls.SetChildIndex(Me.LabelX6, 0)
        Me.MPanelSup.Controls.SetChildIndex(Me.LabelX13, 0)
        Me.MPanelSup.Controls.SetChildIndex(Me.tbFnac, 0)
        Me.MPanelSup.Controls.SetChildIndex(Me.tbTel2, 0)
        Me.MPanelSup.Controls.SetChildIndex(Me.tbFIngr, 0)
        Me.MPanelSup.Controls.SetChildIndex(Me.LabelX14, 0)
        Me.MPanelSup.Controls.SetChildIndex(Me.LabelX5, 0)
        Me.MPanelSup.Controls.SetChildIndex(Me.tbObs, 0)
        Me.MPanelSup.Controls.SetChildIndex(Me.LabelX4, 0)
        Me.MPanelSup.Controls.SetChildIndex(Me.LabelX15, 0)
        Me.MPanelSup.Controls.SetChildIndex(Me.tbNSoc, 0)
        Me.MPanelSup.Controls.SetChildIndex(Me.tbEstado, 0)
        Me.MPanelSup.Controls.SetChildIndex(Me.LabelX3, 0)
        Me.MPanelSup.Controls.SetChildIndex(Me.LabelX16, 0)
        Me.MPanelSup.Controls.SetChildIndex(Me.tbNumi, 0)
        Me.MPanelSup.Controls.SetChildIndex(Me.LabelX1, 0)
        Me.MPanelSup.Controls.SetChildIndex(Me.PanelUsuario, 0)
        Me.MPanelSup.Controls.SetChildIndex(Me.UsImg, 0)
        Me.MPanelSup.Controls.SetChildIndex(Me.BtnCargarImage, 0)
        '
        'PanelPrincipal
        '
        Me.PanelPrincipal.Size = New System.Drawing.Size(1354, 600)
        '
        'GroupPanelBuscador
        '
        Me.GroupPanelBuscador.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupPanelBuscador.Location = New System.Drawing.Point(0, 320)
        Me.GroupPanelBuscador.Size = New System.Drawing.Size(1354, 280)
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
        Me.JGrM_Buscador.Size = New System.Drawing.Size(1348, 255)
        '
        'PanelUsuario
        '
        Me.PanelUsuario.Location = New System.Drawing.Point(1154, 0)
        '
        'MPanelUserAct
        '
        Me.MPanelUserAct.Location = New System.Drawing.Point(1154, 0)
        '
        'BtnCargarImage
        '
        Me.BtnCargarImage.BackColor = System.Drawing.Color.White
        Me.BtnCargarImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnCargarImage.ForeColor = System.Drawing.Color.Transparent
        Me.BtnCargarImage.Image = CType(resources.GetObject("BtnCargarImage.Image"), System.Drawing.Image)
        Me.BtnCargarImage.Location = New System.Drawing.Point(800, 151)
        Me.BtnCargarImage.Name = "BtnCargarImage"
        Me.BtnCargarImage.Size = New System.Drawing.Size(43, 41)
        Me.BtnCargarImage.TabIndex = 12
        Me.BtnCargarImage.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.BtnCargarImage.UseVisualStyleBackColor = False
        '
        'LabelX16
        '
        '
        '
        '
        Me.LabelX16.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX16.Location = New System.Drawing.Point(499, 152)
        Me.LabelX16.Name = "LabelX16"
        Me.LabelX16.Size = New System.Drawing.Size(75, 23)
        Me.LabelX16.TabIndex = 198
        Me.LabelX16.Text = "IMAGEN:"
        '
        'tbEstado
        '
        '
        '
        '
        Me.tbEstado.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbEstado.Location = New System.Drawing.Point(175, 198)
        Me.tbEstado.Name = "tbEstado"
        Me.tbEstado.OffText = "INACTIVO"
        Me.tbEstado.OnText = "ACTIVO"
        Me.tbEstado.Size = New System.Drawing.Size(136, 22)
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
        Me.LabelX15.Location = New System.Drawing.Point(12, 197)
        Me.LabelX15.Name = "LabelX15"
        Me.LabelX15.Size = New System.Drawing.Size(75, 23)
        Me.LabelX15.TabIndex = 197
        Me.LabelX15.Text = "*ESTADO:"
        '
        'tbObs
        '
        '
        '
        '
        Me.tbObs.Border.Class = "TextBoxBorder"
        Me.tbObs.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbObs.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbObs.Location = New System.Drawing.Point(663, 76)
        Me.tbObs.Multiline = True
        Me.tbObs.Name = "tbObs"
        Me.tbObs.PreventEnterBeep = True
        Me.tbObs.Size = New System.Drawing.Size(191, 64)
        Me.tbObs.TabIndex = 11
        '
        'LabelX14
        '
        '
        '
        '
        Me.LabelX14.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX14.Location = New System.Drawing.Point(499, 76)
        Me.LabelX14.Name = "LabelX14"
        Me.LabelX14.Size = New System.Drawing.Size(116, 23)
        Me.LabelX14.TabIndex = 196
        Me.LabelX14.Text = "OBSERVACION:"
        '
        'tbTel2
        '
        '
        '
        '
        Me.tbTel2.Border.Class = "TextBoxBorder"
        Me.tbTel2.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbTel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbTel2.Location = New System.Drawing.Point(663, 46)
        Me.tbTel2.Name = "tbTel2"
        Me.tbTel2.PreventEnterBeep = True
        Me.tbTel2.Size = New System.Drawing.Size(191, 22)
        Me.tbTel2.TabIndex = 10
        '
        'LabelX13
        '
        '
        '
        '
        Me.LabelX13.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX13.Location = New System.Drawing.Point(499, 46)
        Me.LabelX13.Name = "LabelX13"
        Me.LabelX13.Size = New System.Drawing.Size(93, 23)
        Me.LabelX13.TabIndex = 195
        Me.LabelX13.Text = "TELEFONO 2:"
        '
        'tbTel1
        '
        '
        '
        '
        Me.tbTel1.Border.Class = "TextBoxBorder"
        Me.tbTel1.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbTel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbTel1.Location = New System.Drawing.Point(663, 15)
        Me.tbTel1.Name = "tbTel1"
        Me.tbTel1.PreventEnterBeep = True
        Me.tbTel1.Size = New System.Drawing.Size(191, 22)
        Me.tbTel1.TabIndex = 9
        '
        'LabelX12
        '
        '
        '
        '
        Me.LabelX12.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX12.Location = New System.Drawing.Point(499, 14)
        Me.LabelX12.Name = "LabelX12"
        Me.LabelX12.Size = New System.Drawing.Size(93, 23)
        Me.LabelX12.TabIndex = 194
        Me.LabelX12.Text = "TELEFONO 1:"
        '
        'tbEmail
        '
        '
        '
        '
        Me.tbEmail.Border.Class = "TextBoxBorder"
        Me.tbEmail.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbEmail.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbEmail.Location = New System.Drawing.Point(175, 228)
        Me.tbEmail.Name = "tbEmail"
        Me.tbEmail.PreventEnterBeep = True
        Me.tbEmail.Size = New System.Drawing.Size(310, 22)
        Me.tbEmail.TabIndex = 7
        '
        'LabelX11
        '
        '
        '
        '
        Me.LabelX11.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX11.Location = New System.Drawing.Point(12, 227)
        Me.LabelX11.Name = "LabelX11"
        Me.LabelX11.Size = New System.Drawing.Size(93, 23)
        Me.LabelX11.TabIndex = 193
        Me.LabelX11.Text = "EMAIL:"
        '
        'tbDir
        '
        '
        '
        '
        Me.tbDir.Border.Class = "TextBoxBorder"
        Me.tbDir.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbDir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbDir.Location = New System.Drawing.Point(175, 136)
        Me.tbDir.Name = "tbDir"
        Me.tbDir.PreventEnterBeep = True
        Me.tbDir.Size = New System.Drawing.Size(310, 22)
        Me.tbDir.TabIndex = 4
        '
        'LabelX10
        '
        '
        '
        '
        Me.LabelX10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX10.Location = New System.Drawing.Point(12, 135)
        Me.LabelX10.Name = "LabelX10"
        Me.LabelX10.Size = New System.Drawing.Size(93, 23)
        Me.LabelX10.TabIndex = 192
        Me.LabelX10.Text = "DIRECCION:"
        '
        'tbCi
        '
        '
        '
        '
        Me.tbCi.Border.Class = "TextBoxBorder"
        Me.tbCi.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbCi.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbCi.Location = New System.Drawing.Point(175, 76)
        Me.tbCi.Name = "tbCi"
        Me.tbCi.PreventEnterBeep = True
        Me.tbCi.Size = New System.Drawing.Size(127, 22)
        Me.tbCi.TabIndex = 2
        '
        'LabelX9
        '
        '
        '
        '
        Me.LabelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX9.Location = New System.Drawing.Point(12, 75)
        Me.LabelX9.Name = "LabelX9"
        Me.LabelX9.Size = New System.Drawing.Size(150, 23)
        Me.LabelX9.TabIndex = 191
        Me.LabelX9.Text = "CI:"
        '
        'tbNombre
        '
        '
        '
        '
        Me.tbNombre.Border.Class = "TextBoxBorder"
        Me.tbNombre.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbNombre.Location = New System.Drawing.Point(175, 106)
        Me.tbNombre.Name = "tbNombre"
        Me.tbNombre.PreventEnterBeep = True
        Me.tbNombre.Size = New System.Drawing.Size(310, 22)
        Me.tbNombre.TabIndex = 3
        '
        'LabelX6
        '
        '
        '
        '
        Me.LabelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX6.Location = New System.Drawing.Point(12, 106)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(76, 23)
        Me.LabelX6.TabIndex = 188
        Me.LabelX6.Text = "*NOMBRES:"
        '
        'tbFnac
        '
        Me.tbFnac.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbFnac.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.tbFnac.Location = New System.Drawing.Point(175, 168)
        Me.tbFnac.Name = "tbFnac"
        Me.tbFnac.Size = New System.Drawing.Size(122, 22)
        Me.tbFnac.TabIndex = 5
        '
        'tbFIngr
        '
        Me.tbFIngr.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbFIngr.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.tbFIngr.Location = New System.Drawing.Point(175, 259)
        Me.tbFIngr.Name = "tbFIngr"
        Me.tbFIngr.Size = New System.Drawing.Size(122, 22)
        Me.tbFIngr.TabIndex = 8
        '
        'LabelX5
        '
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX5.Location = New System.Drawing.Point(10, 167)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(158, 23)
        Me.LabelX5.TabIndex = 187
        Me.LabelX5.Text = "FECHA DE NACIMIENTO:"
        '
        'LabelX4
        '
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX4.Location = New System.Drawing.Point(12, 258)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(150, 23)
        Me.LabelX4.TabIndex = 186
        Me.LabelX4.Text = "*FECHA DE INGRESO:"
        '
        'tbNSoc
        '
        '
        '
        '
        Me.tbNSoc.Border.Class = "TextBoxBorder"
        Me.tbNSoc.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbNSoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbNSoc.Location = New System.Drawing.Point(175, 46)
        Me.tbNSoc.Name = "tbNSoc"
        Me.tbNSoc.PreventEnterBeep = True
        Me.tbNSoc.Size = New System.Drawing.Size(67, 22)
        Me.tbNSoc.TabIndex = 1
        Me.tbNSoc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LabelX3
        '
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX3.Location = New System.Drawing.Point(12, 46)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(133, 23)
        Me.LabelX3.TabIndex = 185
        Me.LabelX3.Text = "NUMERO DE SOCIO:"
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX1.Location = New System.Drawing.Point(12, 15)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(21, 23)
        Me.LabelX1.TabIndex = 183
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
        Me.tbNumi.Location = New System.Drawing.Point(175, 16)
        Me.tbNumi.Name = "tbNumi"
        Me.tbNumi.PreventEnterBeep = True
        Me.tbNumi.Size = New System.Drawing.Size(67, 22)
        Me.tbNumi.TabIndex = 0
        Me.tbNumi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'UsImg
        '
        Me.UsImg.BackColor = System.Drawing.Color.Transparent
        Me.UsImg.Location = New System.Drawing.Point(660, 145)
        Me.UsImg.Name = "UsImg"
        Me.UsImg.Size = New System.Drawing.Size(194, 170)
        Me.UsImg.TabIndex = 202
        '
        'F1_CLIENTE_H
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1354, 733)
        Me.Name = "F1_CLIENTE_H"
        Me.Text = "F1_CLIENTE_H"
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
        Me.PanelPrincipal.ResumeLayout(False)
        Me.GroupPanelBuscador.ResumeLayout(False)
        CType(Me.JGrM_Buscador, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelUsuario.ResumeLayout(False)
        Me.PanelUsuario.PerformLayout()
        Me.PanelNavegacion.ResumeLayout(False)
        Me.MPanelUserAct.ResumeLayout(False)
        Me.MPanelUserAct.PerformLayout()
        CType(Me.MEP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents BtnCargarImage As System.Windows.Forms.Button
    Friend WithEvents tbNumi As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX16 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents tbEstado As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents tbNSoc As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX15 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents tbObs As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX14 As DevComponents.DotNetBar.LabelX
    Friend WithEvents tbFIngr As System.Windows.Forms.DateTimePicker
    Friend WithEvents tbTel2 As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents tbFnac As System.Windows.Forms.DateTimePicker
    Friend WithEvents LabelX13 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Friend WithEvents tbTel1 As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents tbNombre As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX12 As DevComponents.DotNetBar.LabelX
    Friend WithEvents tbEmail As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX11 As DevComponents.DotNetBar.LabelX
    Friend WithEvents tbDir As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX10 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX9 As DevComponents.DotNetBar.LabelX
    Friend WithEvents tbCi As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents UsImg As Presentacion.Us_Image
End Class
