<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F0_CertificacionReforzamiento_TipoClase
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
        Me.PanelSuperior = New DevComponents.DotNetBar.PanelEx()
        Me.MRlAccion = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.PanelInferior = New DevComponents.DotNetBar.PanelEx()
        Me.ButtonX2 = New DevComponents.DotNetBar.ButtonX()
        Me.ButtonX1 = New DevComponents.DotNetBar.ButtonX()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PanelSuperior.SuspendLayout()
        Me.PanelInferior.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelSuperior
        '
        Me.PanelSuperior.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelSuperior.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP
        Me.PanelSuperior.Controls.Add(Me.MRlAccion)
        Me.PanelSuperior.DisabledBackColor = System.Drawing.Color.Empty
        Me.PanelSuperior.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelSuperior.Location = New System.Drawing.Point(0, 0)
        Me.PanelSuperior.Margin = New System.Windows.Forms.Padding(4)
        Me.PanelSuperior.Name = "PanelSuperior"
        Me.PanelSuperior.Size = New System.Drawing.Size(268, 66)
        Me.PanelSuperior.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelSuperior.Style.BackColor1.Color = System.Drawing.Color.Yellow
        Me.PanelSuperior.Style.BackColor2.Color = System.Drawing.Color.Khaki
        Me.PanelSuperior.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelSuperior.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelSuperior.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelSuperior.Style.GradientAngle = 90
        Me.PanelSuperior.TabIndex = 12
        '
        'MRlAccion
        '
        '
        '
        '
        Me.MRlAccion.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.MRlAccion.Font = New System.Drawing.Font("Microsoft Sans Serif", 22.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MRlAccion.ForeColor = System.Drawing.Color.Black
        Me.MRlAccion.Location = New System.Drawing.Point(13, 4)
        Me.MRlAccion.Margin = New System.Windows.Forms.Padding(4)
        Me.MRlAccion.Name = "MRlAccion"
        Me.MRlAccion.Size = New System.Drawing.Size(242, 55)
        Me.MRlAccion.TabIndex = 8
        Me.MRlAccion.Text = "<b><font size=""-8"">SELECCIONE EL TIPO DE CLASE A PROGRAMAR<font color=""#FF0000""><" & _
    "/font></font></b>"
        '
        'PanelInferior
        '
        Me.PanelInferior.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelInferior.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanelInferior.Controls.Add(Me.ButtonX2)
        Me.PanelInferior.Controls.Add(Me.ButtonX1)
        Me.PanelInferior.DisabledBackColor = System.Drawing.Color.Empty
        Me.PanelInferior.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelInferior.Location = New System.Drawing.Point(0, 234)
        Me.PanelInferior.Margin = New System.Windows.Forms.Padding(4)
        Me.PanelInferior.Name = "PanelInferior"
        Me.PanelInferior.Padding = New System.Windows.Forms.Padding(1)
        Me.PanelInferior.Size = New System.Drawing.Size(268, 27)
        Me.PanelInferior.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelInferior.Style.BackColor1.Color = System.Drawing.Color.Gold
        Me.PanelInferior.Style.BackColor2.Color = System.Drawing.Color.Gold
        Me.PanelInferior.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelInferior.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelInferior.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelInferior.Style.GradientAngle = 90
        Me.PanelInferior.TabIndex = 16
        '
        'ButtonX2
        '
        Me.ButtonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.ButtonX2.Dock = System.Windows.Forms.DockStyle.Left
        Me.ButtonX2.Image = Global.Presentacion.My.Resources.Resources.cancel
        Me.ButtonX2.ImageFixedSize = New System.Drawing.Size(24, 24)
        Me.ButtonX2.Location = New System.Drawing.Point(94, 1)
        Me.ButtonX2.Name = "ButtonX2"
        Me.ButtonX2.Size = New System.Drawing.Size(98, 25)
        Me.ButtonX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX2.TabIndex = 1
        Me.ButtonX2.Text = "CANCELAR"
        '
        'ButtonX1
        '
        Me.ButtonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.ButtonX1.Dock = System.Windows.Forms.DockStyle.Left
        Me.ButtonX1.Image = Global.Presentacion.My.Resources.Resources.OK
        Me.ButtonX1.ImageFixedSize = New System.Drawing.Size(24, 24)
        Me.ButtonX1.Location = New System.Drawing.Point(1, 1)
        Me.ButtonX1.Name = "ButtonX1"
        Me.ButtonX1.Size = New System.Drawing.Size(93, 25)
        Me.ButtonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX1.TabIndex = 0
        Me.ButtonX1.Text = "ACEPTAR"
        '
        'Panel1
        '
        Me.Panel1.AutoScroll = True
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.Location = New System.Drawing.Point(0, 66)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Padding = New System.Windows.Forms.Padding(15)
        Me.Panel1.Size = New System.Drawing.Size(268, 168)
        Me.Panel1.TabIndex = 17
        '
        'F0_CertificacionReforzamiento_TipoClase
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(268, 261)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.PanelInferior)
        Me.Controls.Add(Me.PanelSuperior)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "F0_CertificacionReforzamiento_TipoClase"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "F0_CertificacionReforzamiento_TipoClase"
        Me.PanelSuperior.ResumeLayout(False)
        Me.PanelInferior.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Protected WithEvents PanelSuperior As DevComponents.DotNetBar.PanelEx
    Friend WithEvents MRlAccion As DevComponents.DotNetBar.Controls.ReflectionLabel
    Protected WithEvents PanelInferior As DevComponents.DotNetBar.PanelEx
    Friend WithEvents ButtonX1 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ButtonX2 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
End Class
