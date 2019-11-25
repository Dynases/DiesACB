
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F_ClienteNuevoServicio
    Inherits System.Windows.Forms.Form

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
        Dim cbmarca_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F_ClienteNuevoServicio))
        Dim cbmodelo_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cbtipo_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.tbNombre = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        Me.cbmarca = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.LabelX17 = New DevComponents.DotNetBar.LabelX()
        Me.cbmodelo = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.LabelX18 = New DevComponents.DotNetBar.LabelX()
        Me.tbroseta = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX20 = New DevComponents.DotNetBar.LabelX()
        Me.tbplaca = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX19 = New DevComponents.DotNetBar.LabelX()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.cbtipo = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.btnguardar = New DevComponents.DotNetBar.ButtonX()
        Me.btnsalir = New DevComponents.DotNetBar.ButtonX()
        Me.MEP = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.MHighlighterFocus = New DevComponents.DotNetBar.Validator.Highlighter()
        Me.MFlyoutUsuario = New DevComponents.DotNetBar.Controls.Flyout(Me.components)
        Me.BtnModelo = New DevComponents.DotNetBar.ButtonX()
        Me.BtnMarca = New DevComponents.DotNetBar.ButtonX()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        CType(Me.cbmarca, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbmodelo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.cbtipo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MEP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tbNombre
        '
        Me.tbNombre.AcceptsTab = True
        '
        '
        '
        Me.tbNombre.Border.Class = "TextBoxBorder"
        Me.tbNombre.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbNombre.Location = New System.Drawing.Point(187, 96)
        Me.tbNombre.Name = "tbNombre"
        Me.tbNombre.PreventEnterBeep = True
        Me.tbNombre.Size = New System.Drawing.Size(296, 22)
        Me.tbNombre.TabIndex = 0
        '
        'LabelX6
        '
        Me.LabelX6.BackColor = System.Drawing.SystemColors.Control
        '
        '
        '
        Me.LabelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX6.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX6.Location = New System.Drawing.Point(105, 95)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(76, 23)
        Me.LabelX6.TabIndex = 145
        Me.LabelX6.Text = "NOMBRES:"
        '
        'cbmarca
        '
        cbmarca_DesignTimeLayout.LayoutString = resources.GetString("cbmarca_DesignTimeLayout.LayoutString")
        Me.cbmarca.DesignTimeLayout = cbmarca_DesignTimeLayout
        Me.cbmarca.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbmarca.Location = New System.Drawing.Point(187, 124)
        Me.cbmarca.Name = "cbmarca"
        Me.cbmarca.Office2007ColorScheme = Janus.Windows.GridEX.Office2007ColorScheme.Custom
        Me.cbmarca.Office2007CustomColor = System.Drawing.Color.DodgerBlue
        Me.cbmarca.SelectedIndex = -1
        Me.cbmarca.SelectedItem = Nothing
        Me.cbmarca.Size = New System.Drawing.Size(156, 22)
        Me.cbmarca.TabIndex = 1
        Me.cbmarca.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'LabelX17
        '
        Me.LabelX17.BackColor = System.Drawing.SystemColors.Control
        '
        '
        '
        Me.LabelX17.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX17.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX17.Location = New System.Drawing.Point(105, 123)
        Me.LabelX17.Name = "LabelX17"
        Me.LabelX17.Size = New System.Drawing.Size(69, 23)
        Me.LabelX17.TabIndex = 147
        Me.LabelX17.Text = "MARCA:"
        '
        'cbmodelo
        '
        cbmodelo_DesignTimeLayout.LayoutString = resources.GetString("cbmodelo_DesignTimeLayout.LayoutString")
        Me.cbmodelo.DesignTimeLayout = cbmodelo_DesignTimeLayout
        Me.cbmodelo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbmodelo.Location = New System.Drawing.Point(187, 152)
        Me.cbmodelo.Name = "cbmodelo"
        Me.cbmodelo.Office2007ColorScheme = Janus.Windows.GridEX.Office2007ColorScheme.Custom
        Me.cbmodelo.Office2007CustomColor = System.Drawing.Color.DodgerBlue
        Me.cbmodelo.SelectedIndex = -1
        Me.cbmodelo.SelectedItem = Nothing
        Me.cbmodelo.Size = New System.Drawing.Size(156, 22)
        Me.cbmodelo.TabIndex = 2
        Me.cbmodelo.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'LabelX18
        '
        Me.LabelX18.BackColor = System.Drawing.SystemColors.Control
        '
        '
        '
        Me.LabelX18.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX18.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX18.Location = New System.Drawing.Point(106, 153)
        Me.LabelX18.Name = "LabelX18"
        Me.LabelX18.Size = New System.Drawing.Size(69, 23)
        Me.LabelX18.TabIndex = 149
        Me.LabelX18.Text = "MODELO:"
        '
        'tbroseta
        '
        '
        '
        '
        Me.tbroseta.Border.Class = "TextBoxBorder"
        Me.tbroseta.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbroseta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbroseta.Location = New System.Drawing.Point(187, 232)
        Me.tbroseta.Name = "tbroseta"
        Me.tbroseta.PreventEnterBeep = True
        Me.tbroseta.Size = New System.Drawing.Size(176, 22)
        Me.tbroseta.TabIndex = 5
        '
        'LabelX20
        '
        Me.LabelX20.BackColor = System.Drawing.SystemColors.Control
        '
        '
        '
        Me.LabelX20.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX20.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX20.Location = New System.Drawing.Point(105, 231)
        Me.LabelX20.Name = "LabelX20"
        Me.LabelX20.Size = New System.Drawing.Size(58, 23)
        Me.LabelX20.TabIndex = 153
        Me.LabelX20.Text = "ROSETA:"
        '
        'tbplaca
        '
        '
        '
        '
        Me.tbplaca.Border.Class = "TextBoxBorder"
        Me.tbplaca.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbplaca.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbplaca.Location = New System.Drawing.Point(187, 205)
        Me.tbplaca.Name = "tbplaca"
        Me.tbplaca.PreventEnterBeep = True
        Me.tbplaca.Size = New System.Drawing.Size(176, 22)
        Me.tbplaca.TabIndex = 4
        '
        'LabelX19
        '
        Me.LabelX19.BackColor = System.Drawing.SystemColors.Control
        '
        '
        '
        Me.LabelX19.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX19.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX19.Location = New System.Drawing.Point(105, 204)
        Me.LabelX19.Name = "LabelX19"
        Me.LabelX19.Size = New System.Drawing.Size(58, 23)
        Me.LabelX19.TabIndex = 152
        Me.LabelX19.Text = "PLACA:"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Gold
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.ReflectionLabel1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Padding = New System.Windows.Forms.Padding(20, 5, 0, 5)
        Me.Panel1.Size = New System.Drawing.Size(555, 63)
        Me.Panel1.TabIndex = 157
        '
        'ReflectionLabel1
        '
        '
        '
        '
        Me.ReflectionLabel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionLabel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.ReflectionLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReflectionLabel1.Location = New System.Drawing.Point(20, 5)
        Me.ReflectionLabel1.Name = "ReflectionLabel1"
        Me.ReflectionLabel1.Size = New System.Drawing.Size(242, 53)
        Me.ReflectionLabel1.TabIndex = 0
        Me.ReflectionLabel1.Text = "<b><font size=""12""><font color=""#313b42"">CREAR NUEVO CLIENTE</font></font></b>"
        '
        'cbtipo
        '
        cbtipo_DesignTimeLayout.LayoutString = resources.GetString("cbtipo_DesignTimeLayout.LayoutString")
        Me.cbtipo.DesignTimeLayout = cbtipo_DesignTimeLayout
        Me.cbtipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbtipo.Location = New System.Drawing.Point(187, 179)
        Me.cbtipo.Name = "cbtipo"
        Me.cbtipo.Office2007ColorScheme = Janus.Windows.GridEX.Office2007ColorScheme.Custom
        Me.cbtipo.Office2007CustomColor = System.Drawing.Color.DodgerBlue
        Me.cbtipo.SelectedIndex = -1
        Me.cbtipo.SelectedItem = Nothing
        Me.cbtipo.Size = New System.Drawing.Size(156, 22)
        Me.cbtipo.TabIndex = 3
        Me.cbtipo.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.SystemColors.Control
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX1.Location = New System.Drawing.Point(106, 180)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(69, 23)
        Me.LabelX1.TabIndex = 159
        Me.LabelX1.Text = "TIPO:"
        '
        'btnguardar
        '
        Me.btnguardar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnguardar.BackColor = System.Drawing.Color.Transparent
        Me.btnguardar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnguardar.FadeEffect = False
        Me.btnguardar.FocusCuesEnabled = False
        Me.btnguardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnguardar.Image = Global.Presentacion.My.Resources.Resources.save
        Me.btnguardar.ImageFixedSize = New System.Drawing.Size(20, 20)
        Me.btnguardar.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btnguardar.Location = New System.Drawing.Point(150, 263)
        Me.btnguardar.Name = "btnguardar"
        Me.btnguardar.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btnguardar.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2)
        Me.btnguardar.Size = New System.Drawing.Size(101, 42)
        Me.btnguardar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnguardar.TabIndex = 6
        Me.btnguardar.Text = "AGREGAR"
        Me.btnguardar.TextColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(66, Byte), Integer))
        '
        'btnsalir
        '
        Me.btnsalir.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnsalir.BackColor = System.Drawing.Color.Transparent
        Me.btnsalir.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnsalir.FadeEffect = False
        Me.btnsalir.FocusCuesEnabled = False
        Me.btnsalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnsalir.Image = Global.Presentacion.My.Resources.Resources.atras
        Me.btnsalir.ImageFixedSize = New System.Drawing.Size(20, 20)
        Me.btnsalir.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btnsalir.Location = New System.Drawing.Point(272, 263)
        Me.btnsalir.Name = "btnsalir"
        Me.btnsalir.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btnsalir.Size = New System.Drawing.Size(101, 42)
        Me.btnsalir.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnsalir.TabIndex = 163
        Me.btnsalir.Text = "SALIR"
        Me.btnsalir.TextColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(66, Byte), Integer))
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
        'BtnModelo
        '
        Me.BtnModelo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnModelo.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat
        Me.BtnModelo.Image = Global.Presentacion.My.Resources.Resources.nuevo
        Me.BtnModelo.ImageFixedSize = New System.Drawing.Size(28, 28)
        Me.BtnModelo.Location = New System.Drawing.Point(346, 149)
        Me.BtnModelo.Name = "BtnModelo"
        Me.BtnModelo.Size = New System.Drawing.Size(34, 29)
        Me.BtnModelo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnModelo.TabIndex = 205
        Me.BtnModelo.Visible = False
        '
        'BtnMarca
        '
        Me.BtnMarca.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnMarca.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat
        Me.BtnMarca.Image = Global.Presentacion.My.Resources.Resources.nuevo
        Me.BtnMarca.ImageFixedSize = New System.Drawing.Size(28, 28)
        Me.BtnMarca.Location = New System.Drawing.Point(346, 120)
        Me.BtnMarca.Name = "BtnMarca"
        Me.BtnMarca.Size = New System.Drawing.Size(34, 29)
        Me.BtnMarca.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnMarca.TabIndex = 206
        Me.BtnMarca.Visible = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Image = Global.Presentacion.My.Resources.Resources.man
        Me.PictureBox1.Location = New System.Drawing.Point(491, 5)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Padding = New System.Windows.Forms.Padding(0, 8, 0, 0)
        Me.PictureBox1.Size = New System.Drawing.Size(64, 53)
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'F_ClienteNuevoServicio
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(555, 314)
        Me.Controls.Add(Me.BtnModelo)
        Me.Controls.Add(Me.BtnMarca)
        Me.Controls.Add(Me.btnsalir)
        Me.Controls.Add(Me.btnguardar)
        Me.Controls.Add(Me.cbtipo)
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.tbroseta)
        Me.Controls.Add(Me.LabelX20)
        Me.Controls.Add(Me.tbplaca)
        Me.Controls.Add(Me.LabelX19)
        Me.Controls.Add(Me.cbmodelo)
        Me.Controls.Add(Me.LabelX18)
        Me.Controls.Add(Me.cbmarca)
        Me.Controls.Add(Me.LabelX17)
        Me.Controls.Add(Me.tbNombre)
        Me.Controls.Add(Me.LabelX6)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "F_ClienteNuevoServicio"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CREAR NUEVO CLIENTE"
        CType(Me.cbmarca, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbmodelo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        CType(Me.cbtipo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MEP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tbNombre As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Friend WithEvents cbmarca As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents LabelX17 As DevComponents.DotNetBar.LabelX
    Friend WithEvents cbmodelo As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents LabelX18 As DevComponents.DotNetBar.LabelX
    Friend WithEvents tbroseta As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX20 As DevComponents.DotNetBar.LabelX
    Friend WithEvents tbplaca As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX19 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents cbtipo As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents btnguardar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnsalir As DevComponents.DotNetBar.ButtonX
    Friend WithEvents MEP As System.Windows.Forms.ErrorProvider
    Friend WithEvents MHighlighterFocus As DevComponents.DotNetBar.Validator.Highlighter
    Friend WithEvents MFlyoutUsuario As DevComponents.DotNetBar.Controls.Flyout
    Friend WithEvents BtnModelo As DevComponents.DotNetBar.ButtonX
    Friend WithEvents BtnMarca As DevComponents.DotNetBar.ButtonX
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
End Class
