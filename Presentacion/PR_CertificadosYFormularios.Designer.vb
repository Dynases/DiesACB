<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PR_CertificadosYFormularios
    Inherits Modelos.ModeloR0

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
        Me.GroupPanel2 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.tbTipoReporte = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.tbAlumno = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.tbFoto = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.tbNumiTCE013 = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.tbNumiAlum = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.tbNumiCatLic = New DevComponents.DotNetBar.Controls.TextBoxX()
        CType(Me.SuperTabPrincipal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuperTabPrincipal.SuspendLayout()
        Me.SuperTabControlPanelRegistro.SuspendLayout()
        Me.PanelSuperior.SuspendLayout()
        Me.PanelInferior.SuspendLayout()
        CType(Me.BubbleBarUsuario, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelToolBar1.SuspendLayout()
        Me.PanelPrincipal.SuspendLayout()
        Me.PanelUsuario.SuspendLayout()
        Me.MPanelUserAct.SuspendLayout()
        CType(Me.MEP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MGPFiltros.SuspendLayout()
        Me.PanelIzq.SuspendLayout()
        Me.GroupPanel2.SuspendLayout()
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
        Me.SuperTabPrincipal.Controls.SetChildIndex(Me.SuperTabControlPanelBuscador, 0)
        Me.SuperTabPrincipal.Controls.SetChildIndex(Me.SuperTabControlPanelRegistro, 0)
        Me.SuperTabControlPanelRegistro.Controls.SetChildIndex(Me.PanelInferior, 0)
        Me.SuperTabControlPanelRegistro.Controls.SetChildIndex(Me.PanelIzq, 0)
        Me.SuperTabControlPanelRegistro.Controls.SetChildIndex(Me.PanelPrincipal, 0)
        '
        'PanelSuperior
        '
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
        'btnGenerar
        '
        '
        'MGPFiltros
        '
        Me.MGPFiltros.Controls.Add(Me.tbNumiCatLic)
        Me.MGPFiltros.Controls.Add(Me.tbFoto)
        Me.MGPFiltros.Controls.Add(Me.GroupPanel2)
        Me.MGPFiltros.Controls.Add(Me.tbNumiAlum)
        Me.MGPFiltros.Controls.Add(Me.tbNumiTCE013)
        '
        '
        '
        Me.MGPFiltros.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.MGPFiltros.Style.BackColorGradientAngle = 90
        Me.MGPFiltros.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.MGPFiltros.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.MGPFiltros.Style.BorderBottomWidth = 1
        Me.MGPFiltros.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.MGPFiltros.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.MGPFiltros.Style.BorderLeftWidth = 1
        Me.MGPFiltros.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.MGPFiltros.Style.BorderRightWidth = 1
        Me.MGPFiltros.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.MGPFiltros.Style.BorderTopWidth = 1
        Me.MGPFiltros.Style.CornerDiameter = 4
        Me.MGPFiltros.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.MGPFiltros.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.MGPFiltros.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.MGPFiltros.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.MGPFiltros.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.MGPFiltros.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.PanelIzq.Controls.SetChildIndex(Me.PanelSuperior, 0)
        Me.PanelIzq.Controls.SetChildIndex(Me.MGPFiltros, 0)
        '
        'GroupPanel2
        '
        Me.GroupPanel2.BackColor = System.Drawing.Color.Transparent
        Me.GroupPanel2.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel2.Controls.Add(Me.tbTipoReporte)
        Me.GroupPanel2.Controls.Add(Me.LabelX1)
        Me.GroupPanel2.Controls.Add(Me.tbAlumno)
        Me.GroupPanel2.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupPanel2.Location = New System.Drawing.Point(0, 0)
        Me.GroupPanel2.Name = "GroupPanel2"
        Me.GroupPanel2.Size = New System.Drawing.Size(357, 87)
        '
        '
        '
        Me.GroupPanel2.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GroupPanel2.Style.BackColorGradientAngle = 90
        Me.GroupPanel2.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.GroupPanel2.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderBottomWidth = 1
        Me.GroupPanel2.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanel2.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderLeftWidth = 1
        Me.GroupPanel2.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderRightWidth = 1
        Me.GroupPanel2.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderTopWidth = 1
        Me.GroupPanel2.Style.CornerDiameter = 4
        Me.GroupPanel2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel2.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        '
        '
        '
        Me.GroupPanel2.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel2.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel2.TabIndex = 48
        Me.GroupPanel2.Text = "ALUMNO"
        '
        'tbTipoReporte
        '
        '
        '
        '
        Me.tbTipoReporte.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbTipoReporte.Location = New System.Drawing.Point(87, 2)
        Me.tbTipoReporte.Name = "tbTipoReporte"
        Me.tbTipoReporte.OffText = "FORMULARIO"
        Me.tbTipoReporte.OnText = "CERTIFICADO"
        Me.tbTipoReporte.Size = New System.Drawing.Size(137, 22)
        Me.tbTipoReporte.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.tbTipoReporte.TabIndex = 45
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Location = New System.Drawing.Point(6, 2)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(75, 23)
        Me.LabelX1.TabIndex = 44
        Me.LabelX1.Text = "REPORTE:"
        '
        'tbAlumno
        '
        '
        '
        '
        Me.tbAlumno.Border.Class = "TextBoxBorder"
        Me.tbAlumno.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbAlumno.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbAlumno.Location = New System.Drawing.Point(0, 31)
        Me.tbAlumno.Name = "tbAlumno"
        Me.tbAlumno.PreventEnterBeep = True
        Me.tbAlumno.ReadOnly = True
        Me.tbAlumno.Size = New System.Drawing.Size(347, 22)
        Me.tbAlumno.TabIndex = 42
        '
        'tbFoto
        '
        '
        '
        '
        Me.tbFoto.Border.Class = "TextBoxBorder"
        Me.tbFoto.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbFoto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbFoto.Location = New System.Drawing.Point(180, 130)
        Me.tbFoto.Name = "tbFoto"
        Me.tbFoto.PreventEnterBeep = True
        Me.tbFoto.Size = New System.Drawing.Size(120, 22)
        Me.tbFoto.TabIndex = 47
        Me.tbFoto.Visible = False
        '
        'tbNumiTCE013
        '
        '
        '
        '
        Me.tbNumiTCE013.Border.Class = "TextBoxBorder"
        Me.tbNumiTCE013.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbNumiTCE013.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbNumiTCE013.Location = New System.Drawing.Point(180, 186)
        Me.tbNumiTCE013.Name = "tbNumiTCE013"
        Me.tbNumiTCE013.PreventEnterBeep = True
        Me.tbNumiTCE013.Size = New System.Drawing.Size(120, 22)
        Me.tbNumiTCE013.TabIndex = 46
        Me.tbNumiTCE013.Visible = False
        '
        'tbNumiAlum
        '
        '
        '
        '
        Me.tbNumiAlum.Border.Class = "TextBoxBorder"
        Me.tbNumiAlum.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbNumiAlum.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbNumiAlum.Location = New System.Drawing.Point(180, 158)
        Me.tbNumiAlum.Name = "tbNumiAlum"
        Me.tbNumiAlum.PreventEnterBeep = True
        Me.tbNumiAlum.Size = New System.Drawing.Size(120, 22)
        Me.tbNumiAlum.TabIndex = 43
        Me.tbNumiAlum.Visible = False
        '
        'tbNumiCatLic
        '
        '
        '
        '
        Me.tbNumiCatLic.Border.Class = "TextBoxBorder"
        Me.tbNumiCatLic.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbNumiCatLic.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbNumiCatLic.Location = New System.Drawing.Point(180, 102)
        Me.tbNumiCatLic.Name = "tbNumiCatLic"
        Me.tbNumiCatLic.PreventEnterBeep = True
        Me.tbNumiCatLic.Size = New System.Drawing.Size(120, 22)
        Me.tbNumiCatLic.TabIndex = 48
        Me.tbNumiCatLic.Visible = False
        '
        'PR_CertificadosYFormularios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(884, 561)
        Me.Location = New System.Drawing.Point(0, 0)
        Me.Name = "PR_CertificadosYFormularios"
        Me.Text = "PR_CertificadosYFormularios"
        Me.Controls.SetChildIndex(Me.SuperTabPrincipal, 0)
        CType(Me.SuperTabPrincipal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SuperTabPrincipal.ResumeLayout(False)
        Me.SuperTabControlPanelRegistro.ResumeLayout(False)
        Me.PanelSuperior.ResumeLayout(False)
        Me.PanelInferior.ResumeLayout(False)
        CType(Me.BubbleBarUsuario, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelToolBar1.ResumeLayout(False)
        Me.PanelPrincipal.ResumeLayout(False)
        Me.PanelUsuario.ResumeLayout(False)
        Me.PanelUsuario.PerformLayout()
        Me.MPanelUserAct.ResumeLayout(False)
        Me.MPanelUserAct.PerformLayout()
        CType(Me.MEP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MGPFiltros.ResumeLayout(False)
        Me.PanelIzq.ResumeLayout(False)
        Me.GroupPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupPanel2 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents tbAlumno As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents tbNumiAlum As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents tbTipoReporte As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents tbNumiTCE013 As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents tbFoto As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents tbNumiCatLic As DevComponents.DotNetBar.Controls.TextBoxX
End Class
