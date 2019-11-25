<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UCItemFoto
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
        Me.pbSombra = New System.Windows.Forms.PictureBox()
        Me.pbJpg = New System.Windows.Forms.PictureBox()
        CType(Me.pbSombra, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbJpg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pbSombra
        '
        Me.pbSombra.BackColor = System.Drawing.Color.SkyBlue
        Me.pbSombra.ErrorImage = Nothing
        Me.pbSombra.Location = New System.Drawing.Point(0, 0)
        Me.pbSombra.Name = "pbSombra"
        Me.pbSombra.Size = New System.Drawing.Size(97, 97)
        Me.pbSombra.TabIndex = 1
        Me.pbSombra.TabStop = False
        Me.pbSombra.Visible = False
        '
        'pbJpg
        '
        Me.pbJpg.BackColor = System.Drawing.Color.Transparent
        Me.pbJpg.ErrorImage = Nothing
        Me.pbJpg.Image = Global.Presentacion.My.Resources.Resources.accesorio
        Me.pbJpg.Location = New System.Drawing.Point(3, 3)
        Me.pbJpg.Name = "pbJpg"
        Me.pbJpg.Size = New System.Drawing.Size(90, 90)
        Me.pbJpg.TabIndex = 2
        Me.pbJpg.TabStop = False
        '
        'UCItemFoto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Transparent
        Me.Controls.Add(Me.pbJpg)
        Me.Controls.Add(Me.pbSombra)
        Me.Name = "UCItemFoto"
        Me.Padding = New System.Windows.Forms.Padding(5)
        Me.Size = New System.Drawing.Size(99, 97)
        CType(Me.pbSombra, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbJpg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pbSombra As System.Windows.Forms.PictureBox
    Friend WithEvents pbJpg As System.Windows.Forms.PictureBox

End Class
