<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Us_Image
    Inherits System.Windows.Forms.UserControl

    'UserControl reemplaza a Dispose para limpiar la lista de componentes.
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
        Me.pbImage = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        CType(Me.pbImage, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pbImage
        '
        Me.pbImage.Image = Global.Presentacion.My.Resources.Resources.imageDefault
        Me.pbImage.Location = New System.Drawing.Point(5, 6)
        Me.pbImage.Name = "pbImage"
        Me.pbImage.Size = New System.Drawing.Size(180, 159)
        Me.pbImage.TabIndex = 18
        Me.pbImage.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Presentacion.My.Resources.Resources.IconFondo
        Me.PictureBox1.Location = New System.Drawing.Point(1, 2)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(190, 168)
        Me.PictureBox1.TabIndex = 17
        Me.PictureBox1.TabStop = False
        '
        'Us_Image
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Transparent
        Me.Controls.Add(Me.pbImage)
        Me.Controls.Add(Me.PictureBox1)
        Me.Name = "Us_Image"
        Me.Size = New System.Drawing.Size(194, 170)
        CType(Me.pbImage, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pbImage As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox

End Class
