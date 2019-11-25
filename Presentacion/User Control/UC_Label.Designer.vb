<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UC_Label
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.lbAbre = New DevComponents.DotNetBar.LabelX()
        Me.lbTitulo = New DevComponents.DotNetBar.LabelX()
        Me.SuspendLayout()
        '
        'lbAbre
        '
        '
        '
        '
        Me.lbAbre.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lbAbre.Dock = System.Windows.Forms.DockStyle.Left
        Me.lbAbre.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbAbre.Location = New System.Drawing.Point(0, 0)
        Me.lbAbre.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.lbAbre.Name = "lbAbre"
        Me.lbAbre.Size = New System.Drawing.Size(42, 27)
        Me.lbAbre.TabIndex = 0
        Me.lbAbre.Text = "UC:"
        '
        'lbTitulo
        '
        '
        '
        '
        Me.lbTitulo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lbTitulo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbTitulo.Location = New System.Drawing.Point(42, 0)
        Me.lbTitulo.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.lbTitulo.Name = "lbTitulo"
        Me.lbTitulo.Size = New System.Drawing.Size(147, 27)
        Me.lbTitulo.TabIndex = 1
        Me.lbTitulo.Text = "LabelX1"
        '
        'UC_Label
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.lbTitulo)
        Me.Controls.Add(Me.lbAbre)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "UC_Label"
        Me.Size = New System.Drawing.Size(189, 27)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lbAbre As DevComponents.DotNetBar.LabelX
    Friend WithEvents lbTitulo As DevComponents.DotNetBar.LabelX

End Class
