<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F0_TamanoVehiculo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F0_TamanoVehiculo))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.PanelEx1 = New DevComponents.DotNetBar.PanelEx()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btnAnadir = New DevComponents.DotNetBar.ButtonX()
        Me.ButtonX1 = New DevComponents.DotNetBar.ButtonX()
        Me.ButtonX2 = New DevComponents.DotNetBar.ButtonX()
        Me.Panel1.SuspendLayout()
        Me.PanelEx1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Gold
        Me.Panel1.Controls.Add(Me.ReflectionLabel1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(664, 61)
        Me.Panel1.TabIndex = 54
        '
        'ReflectionLabel1
        '
        '
        '
        '
        Me.ReflectionLabel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionLabel1.Font = New System.Drawing.Font("Georgia", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReflectionLabel1.ForeColor = System.Drawing.Color.Navy
        Me.ReflectionLabel1.Location = New System.Drawing.Point(98, 12)
        Me.ReflectionLabel1.Name = "ReflectionLabel1"
        Me.ReflectionLabel1.Size = New System.Drawing.Size(490, 46)
        Me.ReflectionLabel1.TabIndex = 0
        Me.ReflectionLabel1.Text = "SELECCIONE UN TAMAÑO DE VEHICULO"
        '
        'PanelEx1
        '
        Me.PanelEx1.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanelEx1.Controls.Add(Me.PictureBox1)
        Me.PanelEx1.Controls.Add(Me.btnAnadir)
        Me.PanelEx1.Controls.Add(Me.ButtonX1)
        Me.PanelEx1.Controls.Add(Me.ButtonX2)
        Me.PanelEx1.DisabledBackColor = System.Drawing.Color.Empty
        Me.PanelEx1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelEx1.Location = New System.Drawing.Point(0, 61)
        Me.PanelEx1.Name = "PanelEx1"
        Me.PanelEx1.Size = New System.Drawing.Size(664, 228)
        Me.PanelEx1.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelEx1.Style.BackColor1.Color = System.Drawing.Color.Azure
        Me.PanelEx1.Style.BackColor2.Color = System.Drawing.Color.White
        Me.PanelEx1.Style.BackgroundImage = CType(resources.GetObject("resource.BackgroundImage"), System.Drawing.Image)
        Me.PanelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelEx1.Style.GradientAngle = 90
        Me.PanelEx1.TabIndex = 57
        Me.PanelEx1.Text = "PanelEx1"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Presentacion.My.Resources.Resources.dinases
        Me.PictureBox1.Location = New System.Drawing.Point(0, 189)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(196, 39)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 57
        Me.PictureBox1.TabStop = False
        '
        'btnAnadir
        '
        Me.btnAnadir.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnAnadir.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnAnadir.Font = New System.Drawing.Font("Georgia", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAnadir.Image = Global.Presentacion.My.Resources.Resources.coche
        Me.btnAnadir.ImageFixedSize = New System.Drawing.Size(60, 60)
        Me.btnAnadir.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btnAnadir.Location = New System.Drawing.Point(62, 66)
        Me.btnAnadir.Name = "btnAnadir"
        Me.btnAnadir.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor(8)
        Me.btnAnadir.Size = New System.Drawing.Size(119, 93)
        Me.btnAnadir.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnAnadir.TabIndex = 53
        Me.btnAnadir.Text = "PEQUEÑO"
        Me.btnAnadir.TextColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(139, Byte), Integer))
        '
        'ButtonX1
        '
        Me.ButtonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.ButtonX1.Font = New System.Drawing.Font("Georgia", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonX1.Image = Global.Presentacion.My.Resources.Resources.mediano
        Me.ButtonX1.ImageFixedSize = New System.Drawing.Size(80, 55)
        Me.ButtonX1.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonX1.Location = New System.Drawing.Point(265, 66)
        Me.ButtonX1.Name = "ButtonX1"
        Me.ButtonX1.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor(8)
        Me.ButtonX1.Size = New System.Drawing.Size(119, 93)
        Me.ButtonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX1.TabIndex = 55
        Me.ButtonX1.Text = "MEDIANO"
        Me.ButtonX1.TextColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(139, Byte), Integer))
        '
        'ButtonX2
        '
        Me.ButtonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.ButtonX2.Font = New System.Drawing.Font("Georgia", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonX2.Image = Global.Presentacion.My.Resources.Resources.Grande
        Me.ButtonX2.ImageFixedSize = New System.Drawing.Size(80, 60)
        Me.ButtonX2.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonX2.Location = New System.Drawing.Point(469, 66)
        Me.ButtonX2.Name = "ButtonX2"
        Me.ButtonX2.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor(8)
        Me.ButtonX2.Size = New System.Drawing.Size(119, 93)
        Me.ButtonX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX2.TabIndex = 56
        Me.ButtonX2.Text = "GRANDE"
        Me.ButtonX2.TextColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(139, Byte), Integer))
        '
        'F0_TamanoVehiculo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(664, 289)
        Me.Controls.Add(Me.PanelEx1)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "F0_TamanoVehiculo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "F0_TamanoVehiculo"
        Me.Panel1.ResumeLayout(False)
        Me.PanelEx1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnAnadir As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents ButtonX1 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ButtonX2 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents PanelEx1 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
End Class
