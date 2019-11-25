<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class F0_HotelReservaHuespedes

    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.PanelInferior = New DevComponents.DotNetBar.PanelEx()
        Me.PanelSuperior = New DevComponents.DotNetBar.PanelEx()
        Me.ButtonX2 = New DevComponents.DotNetBar.ButtonX()
        Me.ButtonX3 = New DevComponents.DotNetBar.ButtonX()
        Me.MRlAccion = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.MHighlighterFocus = New DevComponents.DotNetBar.Validator.Highlighter()
        Me.MEP = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.grHuespedes = New Janus.Windows.GridEX.GridEX()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ELIMINARToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PanelSuperior.SuspendLayout()
        CType(Me.MEP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grHuespedes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
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
        Me.PanelInferior.Size = New System.Drawing.Size(521, 27)
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
        Me.PanelSuperior.Size = New System.Drawing.Size(521, 56)
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
        Me.ButtonX2.Location = New System.Drawing.Point(70, 0)
        Me.ButtonX2.Name = "ButtonX2"
        Me.ButtonX2.Size = New System.Drawing.Size(57, 56)
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
        Me.ButtonX3.Image = Global.Presentacion.My.Resources.Resources.OK
        Me.ButtonX3.ImageFixedSize = New System.Drawing.Size(30, 30)
        Me.ButtonX3.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonX3.Location = New System.Drawing.Point(4, 0)
        Me.ButtonX3.Name = "ButtonX3"
        Me.ButtonX3.Size = New System.Drawing.Size(66, 56)
        Me.ButtonX3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX3.TabIndex = 0
        Me.ButtonX3.Text = "OK"
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
        Me.MRlAccion.Location = New System.Drawing.Point(251, 0)
        Me.MRlAccion.Margin = New System.Windows.Forms.Padding(4)
        Me.MRlAccion.Name = "MRlAccion"
        Me.MRlAccion.Size = New System.Drawing.Size(270, 56)
        Me.MRlAccion.TabIndex = 8
        Me.MRlAccion.Text = "<b><font size=""-8"">REGISTRO DE  HUÉSPEDES<font color=""#FF0000""></font></font></b>" & _
    ""
        '
        'MEP
        '
        Me.MEP.ContainerControl = Me
        '
        'grHuespedes
        '
        Me.grHuespedes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grHuespedes.Location = New System.Drawing.Point(0, 56)
        Me.grHuespedes.Name = "grHuespedes"
        Me.grHuespedes.Size = New System.Drawing.Size(521, 197)
        Me.grHuespedes.TabIndex = 212
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ELIMINARToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(166, 62)
        '
        'ELIMINARToolStripMenuItem
        '
        Me.ELIMINARToolStripMenuItem.Image = Global.Presentacion.My.Resources.Resources.elim_fila2
        Me.ELIMINARToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ELIMINARToolStripMenuItem.Name = "ELIMINARToolStripMenuItem"
        Me.ELIMINARToolStripMenuItem.Size = New System.Drawing.Size(165, 36)
        Me.ELIMINARToolStripMenuItem.Text = "ELIMINAR"
        '
        'F0_HotelReservaHuespedes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(521, 280)
        Me.Controls.Add(Me.grHuespedes)
        Me.Controls.Add(Me.PanelSuperior)
        Me.Controls.Add(Me.PanelInferior)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "F0_HotelReservaHuespedes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "F0_HotelReserva_Cliente"
        Me.PanelSuperior.ResumeLayout(False)
        CType(Me.MEP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grHuespedes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Protected WithEvents PanelInferior As DevComponents.DotNetBar.PanelEx
    Protected WithEvents PanelSuperior As DevComponents.DotNetBar.PanelEx
    Friend WithEvents MRlAccion As DevComponents.DotNetBar.Controls.ReflectionLabel
    Protected WithEvents ButtonX2 As DevComponents.DotNetBar.ButtonX
    Protected WithEvents ButtonX3 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents MHighlighterFocus As DevComponents.DotNetBar.Validator.Highlighter
    Friend WithEvents MEP As ErrorProvider
    Friend WithEvents grHuespedes As Janus.Windows.GridEX.GridEX
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ELIMINARToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
