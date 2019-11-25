<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F_SocioVehiculo
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.rlTitulo = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.TableLayoutPanelPrincipal = New System.Windows.Forms.TableLayoutPanel()
        Me.GroupPanelVehiculos = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.dgjVehiculos = New Janus.Windows.GridEX.GridEX()
        Me.GroupPanelVisualizador = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.OfdFoto = New System.Windows.Forms.OpenFileDialog()
        Me.btnSalir = New DevComponents.DotNetBar.ButtonX()
        Me.pbImagen = New System.Windows.Forms.PictureBox()
        Me.pbLogo = New System.Windows.Forms.PictureBox()
        Me.Panel1.SuspendLayout()
        Me.TableLayoutPanelPrincipal.SuspendLayout()
        Me.GroupPanelVehiculos.SuspendLayout()
        CType(Me.dgjVehiculos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanelVisualizador.SuspendLayout()
        CType(Me.pbImagen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Gold
        Me.Panel1.Controls.Add(Me.pbLogo)
        Me.Panel1.Controls.Add(Me.rlTitulo)
        Me.Panel1.Controls.Add(Me.btnSalir)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Padding = New System.Windows.Forms.Padding(20, 5, 0, 5)
        Me.Panel1.Size = New System.Drawing.Size(884, 63)
        Me.Panel1.TabIndex = 158
        '
        'rlTitulo
        '
        '
        '
        '
        Me.rlTitulo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.rlTitulo.Dock = System.Windows.Forms.DockStyle.Left
        Me.rlTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rlTitulo.Location = New System.Drawing.Point(20, 5)
        Me.rlTitulo.Name = "rlTitulo"
        Me.rlTitulo.Size = New System.Drawing.Size(721, 53)
        Me.rlTitulo.TabIndex = 0
        Me.rlTitulo.Text = "<b><font size=""16""><font color=""#313b42"">VEHICULOS DEL SOCIO : </font></font></b>" & _
    ""
        '
        'TableLayoutPanelPrincipal
        '
        Me.TableLayoutPanelPrincipal.ColumnCount = 2
        Me.TableLayoutPanelPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 37.5!))
        Me.TableLayoutPanelPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 62.5!))
        Me.TableLayoutPanelPrincipal.Controls.Add(Me.GroupPanelVehiculos, 0, 0)
        Me.TableLayoutPanelPrincipal.Controls.Add(Me.GroupPanelVisualizador, 1, 0)
        Me.TableLayoutPanelPrincipal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanelPrincipal.Location = New System.Drawing.Point(0, 63)
        Me.TableLayoutPanelPrincipal.Name = "TableLayoutPanelPrincipal"
        Me.TableLayoutPanelPrincipal.RowCount = 1
        Me.TableLayoutPanelPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanelPrincipal.Size = New System.Drawing.Size(884, 498)
        Me.TableLayoutPanelPrincipal.TabIndex = 163
        '
        'GroupPanelVehiculos
        '
        Me.GroupPanelVehiculos.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanelVehiculos.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanelVehiculos.Controls.Add(Me.dgjVehiculos)
        Me.GroupPanelVehiculos.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanelVehiculos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupPanelVehiculos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupPanelVehiculos.Location = New System.Drawing.Point(3, 3)
        Me.GroupPanelVehiculos.Name = "GroupPanelVehiculos"
        Me.GroupPanelVehiculos.Size = New System.Drawing.Size(325, 492)
        '
        '
        '
        Me.GroupPanelVehiculos.Style.BackColor = System.Drawing.SystemColors.Control
        Me.GroupPanelVehiculos.Style.BackColor2 = System.Drawing.SystemColors.Control
        Me.GroupPanelVehiculos.Style.BackColorGradientAngle = 90
        Me.GroupPanelVehiculos.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanelVehiculos.Style.BorderBottomWidth = 1
        Me.GroupPanelVehiculos.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanelVehiculos.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanelVehiculos.Style.BorderLeftWidth = 1
        Me.GroupPanelVehiculos.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanelVehiculos.Style.BorderRightWidth = 1
        Me.GroupPanelVehiculos.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanelVehiculos.Style.BorderTopWidth = 1
        Me.GroupPanelVehiculos.Style.CornerDiameter = 4
        Me.GroupPanelVehiculos.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanelVehiculos.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanelVehiculos.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanelVehiculos.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanelVehiculos.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanelVehiculos.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanelVehiculos.TabIndex = 0
        Me.GroupPanelVehiculos.Text = "VEHICULOS DEL SOCIO"
        '
        'dgjVehiculos
        '
        Me.dgjVehiculos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgjVehiculos.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight
        Me.dgjVehiculos.Location = New System.Drawing.Point(0, 0)
        Me.dgjVehiculos.Name = "dgjVehiculos"
        Me.dgjVehiculos.SelectedFormatStyle.Appearance = Janus.Windows.GridEX.Appearance.RaisedLight
        Me.dgjVehiculos.SelectedFormatStyle.BackColor = System.Drawing.Color.Turquoise
        Me.dgjVehiculos.SelectedFormatStyle.BackColorAlphaMode = Janus.Windows.GridEX.AlphaMode.UseAlpha
        Me.dgjVehiculos.SelectedFormatStyle.BackgroundGradientMode = Janus.Windows.GridEX.BackgroundGradientMode.Solid
        Me.dgjVehiculos.SelectedFormatStyle.FontBold = Janus.Windows.GridEX.TriState.[True]
        Me.dgjVehiculos.Size = New System.Drawing.Size(319, 470)
        Me.dgjVehiculos.TabIndex = 4
        '
        'GroupPanelVisualizador
        '
        Me.GroupPanelVisualizador.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanelVisualizador.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanelVisualizador.Controls.Add(Me.pbImagen)
        Me.GroupPanelVisualizador.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanelVisualizador.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupPanelVisualizador.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupPanelVisualizador.Location = New System.Drawing.Point(334, 3)
        Me.GroupPanelVisualizador.Name = "GroupPanelVisualizador"
        Me.GroupPanelVisualizador.Size = New System.Drawing.Size(547, 492)
        '
        '
        '
        Me.GroupPanelVisualizador.Style.BackColor = System.Drawing.SystemColors.Control
        Me.GroupPanelVisualizador.Style.BackColor2 = System.Drawing.SystemColors.Control
        Me.GroupPanelVisualizador.Style.BackColorGradientAngle = 90
        Me.GroupPanelVisualizador.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanelVisualizador.Style.BorderBottomWidth = 1
        Me.GroupPanelVisualizador.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanelVisualizador.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanelVisualizador.Style.BorderLeftWidth = 1
        Me.GroupPanelVisualizador.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanelVisualizador.Style.BorderRightWidth = 1
        Me.GroupPanelVisualizador.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanelVisualizador.Style.BorderTopWidth = 1
        Me.GroupPanelVisualizador.Style.CornerDiameter = 4
        Me.GroupPanelVisualizador.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanelVisualizador.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanelVisualizador.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanelVisualizador.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanelVisualizador.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanelVisualizador.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanelVisualizador.TabIndex = 1
        Me.GroupPanelVisualizador.Text = "VISUALIZADOR"
        '
        'OfdFoto
        '
        Me.OfdFoto.FileName = "OpenFileDialog1"
        '
        'btnSalir
        '
        Me.btnSalir.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnSalir.ColorTable = DevComponents.DotNetBar.eButtonColor.Orange
        Me.btnSalir.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Image = Global.Presentacion.My.Resources.Resources.SALIR2
        Me.btnSalir.ImageFixedSize = New System.Drawing.Size(38, 38)
        Me.btnSalir.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btnSalir.Location = New System.Drawing.Point(812, 5)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(72, 53)
        Me.btnSalir.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnSalir.TabIndex = 11
        Me.btnSalir.Text = "SALIR"
        Me.btnSalir.TextColor = System.Drawing.Color.Black
        '
        'pbImagen
        '
        Me.pbImagen.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pbImagen.Location = New System.Drawing.Point(0, 0)
        Me.pbImagen.Name = "pbImagen"
        Me.pbImagen.Size = New System.Drawing.Size(541, 470)
        Me.pbImagen.TabIndex = 4
        Me.pbImagen.TabStop = False
        '
        'pbLogo
        '
        Me.pbLogo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pbLogo.Image = Global.Presentacion.My.Resources.Resources.man
        Me.pbLogo.Location = New System.Drawing.Point(748, 5)
        Me.pbLogo.Name = "pbLogo"
        Me.pbLogo.Padding = New System.Windows.Forms.Padding(0, 8, 0, 0)
        Me.pbLogo.Size = New System.Drawing.Size(64, 53)
        Me.pbLogo.TabIndex = 1
        Me.pbLogo.TabStop = False
        Me.pbLogo.Visible = False
        '
        'F_SocioVehiculo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(884, 561)
        Me.Controls.Add(Me.TableLayoutPanelPrincipal)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "F_SocioVehiculo"
        Me.Text = "F_SocioVehiculo"
        Me.Panel1.ResumeLayout(False)
        Me.TableLayoutPanelPrincipal.ResumeLayout(False)
        Me.GroupPanelVehiculos.ResumeLayout(False)
        CType(Me.dgjVehiculos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanelVisualizador.ResumeLayout(False)
        CType(Me.pbImagen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents pbLogo As System.Windows.Forms.PictureBox
    Friend WithEvents rlTitulo As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents TableLayoutPanelPrincipal As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents GroupPanelVehiculos As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents GroupPanelVisualizador As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents dgjVehiculos As Janus.Windows.GridEX.GridEX
    Friend WithEvents pbImagen As System.Windows.Forms.PictureBox
    Friend WithEvents OfdFoto As System.Windows.Forms.OpenFileDialog
    Protected WithEvents btnSalir As DevComponents.DotNetBar.ButtonX
End Class
