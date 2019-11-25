<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_AyudaP
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
        Me.GPPanelP = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.grJBuscador = New Janus.Windows.GridEX.GridEX()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ButtonX1 = New DevComponents.DotNetBar.ButtonX()
        Me.btnAnadir = New DevComponents.DotNetBar.ButtonX()
        Me.GPPanelP.SuspendLayout()
        CType(Me.grJBuscador, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GPPanelP
        '
        Me.GPPanelP.BackColor = System.Drawing.Color.Transparent
        Me.GPPanelP.CanvasColor = System.Drawing.SystemColors.Control
        Me.GPPanelP.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GPPanelP.Controls.Add(Me.grJBuscador)
        Me.GPPanelP.DisabledBackColor = System.Drawing.Color.Empty
        Me.GPPanelP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GPPanelP.Location = New System.Drawing.Point(0, 84)
        Me.GPPanelP.Margin = New System.Windows.Forms.Padding(4)
        Me.GPPanelP.Name = "GPPanelP"
        Me.GPPanelP.Size = New System.Drawing.Size(740, 361)
        '
        '
        '
        Me.GPPanelP.Style.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.GPPanelP.Style.BackColor2 = System.Drawing.Color.Aquamarine
        Me.GPPanelP.Style.BackColorGradientAngle = 90
        Me.GPPanelP.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GPPanelP.Style.BorderBottomWidth = 1
        Me.GPPanelP.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GPPanelP.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GPPanelP.Style.BorderLeftWidth = 1
        Me.GPPanelP.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GPPanelP.Style.BorderRightWidth = 1
        Me.GPPanelP.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GPPanelP.Style.BorderTopWidth = 1
        Me.GPPanelP.Style.CornerDiameter = 4
        Me.GPPanelP.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GPPanelP.Style.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GPPanelP.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GPPanelP.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GPPanelP.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GPPanelP.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GPPanelP.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GPPanelP.TabIndex = 0
        Me.GPPanelP.Text = "GroupPanel1"
        '
        'grJBuscador
        '
        Me.grJBuscador.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grJBuscador.Location = New System.Drawing.Point(0, 0)
        Me.grJBuscador.Margin = New System.Windows.Forms.Padding(4)
        Me.grJBuscador.Name = "grJBuscador"
        Me.grJBuscador.Office2007ColorScheme = Janus.Windows.GridEX.Office2007ColorScheme.Custom
        Me.grJBuscador.Office2007CustomColor = System.Drawing.Color.DodgerBlue
        Me.grJBuscador.Size = New System.Drawing.Size(734, 336)
        Me.grJBuscador.TabIndex = 0
        Me.grJBuscador.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.ButtonX1)
        Me.Panel1.Controls.Add(Me.btnAnadir)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(740, 84)
        Me.Panel1.TabIndex = 1
        '
        'ButtonX1
        '
        Me.ButtonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.ButtonX1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonX1.Image = Global.Presentacion.My.Resources.Resources.elim_fila2
        Me.ButtonX1.ImageFixedSize = New System.Drawing.Size(25, 25)
        Me.ButtonX1.Location = New System.Drawing.Point(563, 19)
        Me.ButtonX1.Margin = New System.Windows.Forms.Padding(4)
        Me.ButtonX1.Name = "ButtonX1"
        Me.ButtonX1.Size = New System.Drawing.Size(136, 57)
        Me.ButtonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX1.TabIndex = 54
        Me.ButtonX1.Text = "Eliminar Fila"
        '
        'btnAnadir
        '
        Me.btnAnadir.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnAnadir.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnAnadir.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAnadir.Image = Global.Presentacion.My.Resources.Resources.checked
        Me.btnAnadir.ImageFixedSize = New System.Drawing.Size(25, 25)
        Me.btnAnadir.Location = New System.Drawing.Point(170, 19)
        Me.btnAnadir.Margin = New System.Windows.Forms.Padding(4)
        Me.btnAnadir.Name = "btnAnadir"
        Me.btnAnadir.Size = New System.Drawing.Size(361, 57)
        Me.btnAnadir.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnAnadir.TabIndex = 53
        Me.btnAnadir.Text = "Marcar Todos"
        '
        'Frm_AyudaP
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(740, 445)
        Me.Controls.Add(Me.GPPanelP)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Frm_AyudaP"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Frm_AyudaP"
        Me.GPPanelP.ResumeLayout(False)
        CType(Me.grJBuscador, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GPPanelP As DevComponents.DotNetBar.Controls.GroupPanel
    Public WithEvents grJBuscador As Janus.Windows.GridEX.GridEX
    Friend WithEvents Panel1 As Panel
    Friend WithEvents ButtonX1 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnAnadir As DevComponents.DotNetBar.ButtonX
End Class
