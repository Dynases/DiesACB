<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F0_HotelReserva_Cliente
    Inherits System.Windows.Forms.Form

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
        Me.components = New System.ComponentModel.Container()
        Me.PanelInferior = New DevComponents.DotNetBar.PanelEx()
        Me.PanelSuperior = New DevComponents.DotNetBar.PanelEx()
        Me.ButtonX2 = New DevComponents.DotNetBar.ButtonX()
        Me.ButtonX3 = New DevComponents.DotNetBar.ButtonX()
        Me.MRlAccion = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.tbFnac = New System.Windows.Forms.DateTimePicker()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        Me.tbNombre = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.tbEmail = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX11 = New DevComponents.DotNetBar.LabelX()
        Me.tbDir = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX10 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX9 = New DevComponents.DotNetBar.LabelX()
        Me.tbCi = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.tbTel1 = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX12 = New DevComponents.DotNetBar.LabelX()
        Me.MHighlighterFocus = New DevComponents.DotNetBar.Validator.Highlighter()
        Me.MEP = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.PanelSuperior.SuspendLayout()
        CType(Me.MEP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelInferior
        '
        Me.PanelInferior.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelInferior.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanelInferior.DisabledBackColor = System.Drawing.Color.Empty
        Me.PanelInferior.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelInferior.Location = New System.Drawing.Point(0, 253)
        Me.PanelInferior.Margin = New System.Windows.Forms.Padding(4)
        Me.PanelInferior.Name = "PanelInferior"
        Me.PanelInferior.Size = New System.Drawing.Size(465, 27)
        Me.PanelInferior.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelInferior.Style.BackColor1.Color = System.Drawing.Color.Gold
        Me.PanelInferior.Style.BackColor2.Color = System.Drawing.Color.Gold
        Me.PanelInferior.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelInferior.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelInferior.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelInferior.Style.GradientAngle = 90
        Me.PanelInferior.TabIndex = 12
        '
        'PanelSuperior
        '
        Me.PanelSuperior.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelSuperior.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP
        Me.PanelSuperior.Controls.Add(Me.ButtonX2)
        Me.PanelSuperior.Controls.Add(Me.ButtonX3)
        Me.PanelSuperior.Controls.Add(Me.MRlAccion)
        Me.PanelSuperior.DisabledBackColor = System.Drawing.Color.Empty
        Me.PanelSuperior.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelSuperior.Location = New System.Drawing.Point(0, 0)
        Me.PanelSuperior.Margin = New System.Windows.Forms.Padding(4)
        Me.PanelSuperior.Name = "PanelSuperior"
        Me.PanelSuperior.Padding = New System.Windows.Forms.Padding(4, 0, 0, 0)
        Me.PanelSuperior.Size = New System.Drawing.Size(465, 56)
        Me.PanelSuperior.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelSuperior.Style.BackColor1.Color = System.Drawing.Color.Yellow
        Me.PanelSuperior.Style.BackColor2.Color = System.Drawing.Color.Khaki
        Me.PanelSuperior.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelSuperior.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelSuperior.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelSuperior.Style.GradientAngle = 90
        Me.PanelSuperior.TabIndex = 8
        '
        'ButtonX2
        '
        Me.ButtonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.Orange
        Me.ButtonX2.Dock = System.Windows.Forms.DockStyle.Left
        Me.ButtonX2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonX2.Image = Global.Presentacion.My.Resources.Resources.SALIR
        Me.ButtonX2.ImageFixedSize = New System.Drawing.Size(30, 30)
        Me.ButtonX2.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonX2.Location = New System.Drawing.Point(76, 0)
        Me.ButtonX2.Name = "ButtonX2"
        Me.ButtonX2.Size = New System.Drawing.Size(72, 56)
        Me.ButtonX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX2.TabIndex = 1
        Me.ButtonX2.Text = "SALIR"
        Me.ButtonX2.TextColor = System.Drawing.Color.Black
        '
        'ButtonX3
        '
        Me.ButtonX3.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX3.ColorTable = DevComponents.DotNetBar.eButtonColor.Orange
        Me.ButtonX3.Dock = System.Windows.Forms.DockStyle.Left
        Me.ButtonX3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonX3.Image = Global.Presentacion.My.Resources.Resources.GUARDAR
        Me.ButtonX3.ImageFixedSize = New System.Drawing.Size(30, 30)
        Me.ButtonX3.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonX3.Location = New System.Drawing.Point(4, 0)
        Me.ButtonX3.Name = "ButtonX3"
        Me.ButtonX3.Size = New System.Drawing.Size(72, 56)
        Me.ButtonX3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX3.TabIndex = 0
        Me.ButtonX3.Text = "GRABAR"
        Me.ButtonX3.TextColor = System.Drawing.Color.Black
        '
        'MRlAccion
        '
        '
        '
        '
        Me.MRlAccion.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.MRlAccion.Dock = System.Windows.Forms.DockStyle.Right
        Me.MRlAccion.Font = New System.Drawing.Font("Microsoft Sans Serif", 22.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MRlAccion.ForeColor = System.Drawing.Color.Black
        Me.MRlAccion.Location = New System.Drawing.Point(224, 0)
        Me.MRlAccion.Margin = New System.Windows.Forms.Padding(4)
        Me.MRlAccion.Name = "MRlAccion"
        Me.MRlAccion.Size = New System.Drawing.Size(241, 56)
        Me.MRlAccion.TabIndex = 8
        Me.MRlAccion.Text = "<b><font size=""-8"">REGISTRO DE CLIENTE<font color=""#FF0000""></font></font></b>"
        '
        'LabelX5
        '
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX5.Location = New System.Drawing.Point(14, 131)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(113, 23)
        Me.LabelX5.TabIndex = 199
        Me.LabelX5.Text = "FECHA DE NAC.:"
        '
        'tbFnac
        '
        Me.tbFnac.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbFnac.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.tbFnac.Location = New System.Drawing.Point(133, 132)
        Me.tbFnac.Name = "tbFnac"
        Me.tbFnac.Size = New System.Drawing.Size(122, 22)
        Me.tbFnac.TabIndex = 2
        '
        'LabelX6
        '
        '
        '
        '
        Me.LabelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX6.Location = New System.Drawing.Point(14, 104)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(76, 23)
        Me.LabelX6.TabIndex = 200
        Me.LabelX6.Text = "NOMBRES:"
        '
        'tbNombre
        '
        '
        '
        '
        Me.tbNombre.Border.Class = "TextBoxBorder"
        Me.tbNombre.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbNombre.Location = New System.Drawing.Point(133, 104)
        Me.tbNombre.Name = "tbNombre"
        Me.tbNombre.PreventEnterBeep = True
        Me.tbNombre.Size = New System.Drawing.Size(310, 22)
        Me.tbNombre.TabIndex = 1
        '
        'tbEmail
        '
        '
        '
        '
        Me.tbEmail.Border.Class = "TextBoxBorder"
        Me.tbEmail.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbEmail.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbEmail.Location = New System.Drawing.Point(133, 188)
        Me.tbEmail.Name = "tbEmail"
        Me.tbEmail.PreventEnterBeep = True
        Me.tbEmail.Size = New System.Drawing.Size(310, 22)
        Me.tbEmail.TabIndex = 4
        '
        'LabelX11
        '
        '
        '
        '
        Me.LabelX11.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX11.Location = New System.Drawing.Point(16, 188)
        Me.LabelX11.Name = "LabelX11"
        Me.LabelX11.Size = New System.Drawing.Size(93, 23)
        Me.LabelX11.TabIndex = 203
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
        Me.tbDir.Location = New System.Drawing.Point(133, 216)
        Me.tbDir.Name = "tbDir"
        Me.tbDir.PreventEnterBeep = True
        Me.tbDir.Size = New System.Drawing.Size(310, 22)
        Me.tbDir.TabIndex = 5
        '
        'LabelX10
        '
        '
        '
        '
        Me.LabelX10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX10.Location = New System.Drawing.Point(16, 216)
        Me.LabelX10.Name = "LabelX10"
        Me.LabelX10.Size = New System.Drawing.Size(93, 23)
        Me.LabelX10.TabIndex = 202
        Me.LabelX10.Text = "DIRECCION:"
        '
        'LabelX9
        '
        '
        '
        '
        Me.LabelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX9.Location = New System.Drawing.Point(14, 74)
        Me.LabelX9.Name = "LabelX9"
        Me.LabelX9.Size = New System.Drawing.Size(111, 23)
        Me.LabelX9.TabIndex = 201
        Me.LabelX9.Text = "CI:"
        '
        'tbCi
        '
        '
        '
        '
        Me.tbCi.Border.Class = "TextBoxBorder"
        Me.tbCi.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbCi.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbCi.Location = New System.Drawing.Point(133, 74)
        Me.tbCi.Name = "tbCi"
        Me.tbCi.PreventEnterBeep = True
        Me.tbCi.Size = New System.Drawing.Size(122, 22)
        Me.tbCi.TabIndex = 0
        '
        'tbTel1
        '
        '
        '
        '
        Me.tbTel1.Border.Class = "TextBoxBorder"
        Me.tbTel1.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbTel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbTel1.Location = New System.Drawing.Point(133, 160)
        Me.tbTel1.Name = "tbTel1"
        Me.tbTel1.PreventEnterBeep = True
        Me.tbTel1.Size = New System.Drawing.Size(122, 22)
        Me.tbTel1.TabIndex = 3
        '
        'LabelX12
        '
        '
        '
        '
        Me.LabelX12.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX12.Location = New System.Drawing.Point(14, 163)
        Me.LabelX12.Name = "LabelX12"
        Me.LabelX12.Size = New System.Drawing.Size(93, 23)
        Me.LabelX12.TabIndex = 205
        Me.LabelX12.Text = "TELEFONO:"
        '
        'MEP
        '
        Me.MEP.ContainerControl = Me
        '
        'F0_HotelReserva_Cliente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(465, 280)
        Me.Controls.Add(Me.tbTel1)
        Me.Controls.Add(Me.LabelX12)
        Me.Controls.Add(Me.LabelX5)
        Me.Controls.Add(Me.tbFnac)
        Me.Controls.Add(Me.LabelX6)
        Me.Controls.Add(Me.tbNombre)
        Me.Controls.Add(Me.tbEmail)
        Me.Controls.Add(Me.LabelX11)
        Me.Controls.Add(Me.tbDir)
        Me.Controls.Add(Me.LabelX10)
        Me.Controls.Add(Me.LabelX9)
        Me.Controls.Add(Me.tbCi)
        Me.Controls.Add(Me.PanelSuperior)
        Me.Controls.Add(Me.PanelInferior)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "F0_HotelReserva_Cliente"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "F0_HotelReserva_Cliente"
        Me.PanelSuperior.ResumeLayout(False)
        CType(Me.MEP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Protected WithEvents PanelInferior As DevComponents.DotNetBar.PanelEx
    Protected WithEvents PanelSuperior As DevComponents.DotNetBar.PanelEx
    Friend WithEvents MRlAccion As DevComponents.DotNetBar.Controls.ReflectionLabel
    Protected WithEvents ButtonX2 As DevComponents.DotNetBar.ButtonX
    Protected WithEvents ButtonX3 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents tbFnac As DateTimePicker
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Friend WithEvents tbNombre As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents tbEmail As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX11 As DevComponents.DotNetBar.LabelX
    Friend WithEvents tbDir As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX10 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX9 As DevComponents.DotNetBar.LabelX
    Friend WithEvents tbCi As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents tbTel1 As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX12 As DevComponents.DotNetBar.LabelX
    Friend WithEvents MHighlighterFocus As DevComponents.DotNetBar.Validator.Highlighter
    Friend WithEvents MEP As ErrorProvider
End Class
