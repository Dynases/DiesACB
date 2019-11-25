<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F1_VentanaFactura
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F1_VentanaFactura))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.tbnit = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.tbnombre = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Highlighter1 = New DevComponents.DotNetBar.Validator.Highlighter()
        Me.MEP = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.btnVehiculo = New DevComponents.DotNetBar.ButtonX()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MEP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Gold
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.ReflectionLabel1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Padding = New System.Windows.Forms.Padding(20, 10, 0, 5)
        Me.Panel1.Size = New System.Drawing.Size(594, 63)
        Me.Panel1.TabIndex = 158
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Image = Global.Presentacion.My.Resources.Resources.man
        Me.PictureBox1.Location = New System.Drawing.Point(530, 10)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Padding = New System.Windows.Forms.Padding(0, 8, 0, 0)
        Me.PictureBox1.Size = New System.Drawing.Size(64, 48)
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'ReflectionLabel1
        '
        '
        '
        '
        Me.ReflectionLabel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionLabel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.ReflectionLabel1.Font = New System.Drawing.Font("Georgia", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReflectionLabel1.ForeColor = System.Drawing.Color.Black
        Me.ReflectionLabel1.Location = New System.Drawing.Point(20, 10)
        Me.ReflectionLabel1.Name = "ReflectionLabel1"
        Me.ReflectionLabel1.Size = New System.Drawing.Size(375, 48)
        Me.ReflectionLabel1.TabIndex = 0
        Me.ReflectionLabel1.Text = "DATOS DE LA FACTURA"
        '
        'tbnit
        '
        '
        '
        '
        Me.tbnit.Border.Class = "TextBoxBorder"
        Me.tbnit.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbnit.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbnit.Location = New System.Drawing.Point(177, 96)
        Me.tbnit.Name = "tbnit"
        Me.tbnit.PreventEnterBeep = True
        Me.tbnit.Size = New System.Drawing.Size(193, 26)
        Me.tbnit.TabIndex = 0
        '
        'LabelX1
        '
        Me.LabelX1.AutoSize = True
        Me.LabelX1.BackColor = System.Drawing.SystemColors.Control
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX1.Location = New System.Drawing.Point(75, 97)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(36, 21)
        Me.LabelX1.TabIndex = 209
        Me.LabelX1.Text = "NIT:"
        '
        'LabelX2
        '
        Me.LabelX2.AutoSize = True
        Me.LabelX2.BackColor = System.Drawing.SystemColors.Control
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX2.Location = New System.Drawing.Point(75, 142)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(84, 21)
        Me.LabelX2.TabIndex = 211
        Me.LabelX2.Text = "NOMBRE:"
        '
        'tbnombre
        '
        '
        '
        '
        Me.tbnombre.Border.Class = "TextBoxBorder"
        Me.tbnombre.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbnombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbnombre.Location = New System.Drawing.Point(177, 141)
        Me.tbnombre.Name = "tbnombre"
        Me.tbnombre.PreventEnterBeep = True
        Me.tbnombre.Size = New System.Drawing.Size(329, 26)
        Me.tbnombre.TabIndex = 1
        '
        'Highlighter1
        '
        Me.Highlighter1.ContainerControl = Me
        '
        'MEP
        '
        Me.MEP.ContainerControl = Me
        '
        'btnVehiculo
        '
        Me.btnVehiculo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnVehiculo.BackColor = System.Drawing.Color.Transparent
        Me.btnVehiculo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnVehiculo.FadeEffect = False
        Me.btnVehiculo.FocusCuesEnabled = False
        Me.btnVehiculo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVehiculo.Image = CType(resources.GetObject("btnVehiculo.Image"), System.Drawing.Image)
        Me.btnVehiculo.ImageFixedSize = New System.Drawing.Size(20, 20)
        Me.btnVehiculo.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btnVehiculo.Location = New System.Drawing.Point(201, 181)
        Me.btnVehiculo.Margin = New System.Windows.Forms.Padding(4)
        Me.btnVehiculo.Name = "btnVehiculo"
        Me.btnVehiculo.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btnVehiculo.Size = New System.Drawing.Size(135, 52)
        Me.btnVehiculo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnVehiculo.TabIndex = 2
        Me.btnVehiculo.Text = "CONTINUAR"
        '
        'F1_VentanaFactura
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(594, 293)
        Me.Controls.Add(Me.btnVehiculo)
        Me.Controls.Add(Me.tbnombre)
        Me.Controls.Add(Me.LabelX2)
        Me.Controls.Add(Me.tbnit)
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "F1_VentanaFactura"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "F1_VentanaFactura"
        Me.Panel1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MEP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents tbnit As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents tbnombre As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Highlighter1 As DevComponents.DotNetBar.Validator.Highlighter
    Friend WithEvents MEP As ErrorProvider
    Friend WithEvents btnVehiculo As DevComponents.DotNetBar.ButtonX
End Class
