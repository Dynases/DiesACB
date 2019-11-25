<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UCElemProducto
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
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.UCLabelTitulo = New DevComponents.DotNetBar.LabelX()
        Me.RatingStar1 = New DevComponents.DotNetBar.Controls.RatingStar()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.Line1 = New DevComponents.DotNetBar.Controls.Line()
        Me.CRbtVerProd = New System.Windows.Forms.Button()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Presentacion.My.Resources.Resources.BT_128X128ADICIONAR
        Me.PictureBox1.Location = New System.Drawing.Point(25, 25)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(132, 134)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'UCLabelTitulo
        '
        '
        '
        '
        Me.UCLabelTitulo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.UCLabelTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UCLabelTitulo.Location = New System.Drawing.Point(172, 25)
        Me.UCLabelTitulo.Name = "UCLabelTitulo"
        Me.UCLabelTitulo.Size = New System.Drawing.Size(256, 23)
        Me.UCLabelTitulo.TabIndex = 1
        Me.UCLabelTitulo.Text = "Metodo Completo para el teclado"
        '
        'RatingStar1
        '
        '
        '
        '
        Me.RatingStar1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RatingStar1.Location = New System.Drawing.Point(172, 54)
        Me.RatingStar1.Name = "RatingStar1"
        Me.RatingStar1.Size = New System.Drawing.Size(171, 23)
        Me.RatingStar1.TabIndex = 2
        Me.RatingStar1.Text = "RatingStar1"
        Me.RatingStar1.TextColor = System.Drawing.Color.Empty
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Location = New System.Drawing.Point(169, 80)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(59, 13)
        Me.LinkLabel1.TabIndex = 3
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "LinkLabel1"
        '
        'Line1
        '
        Me.Line1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Line1.Location = New System.Drawing.Point(0, 165)
        Me.Line1.Name = "Line1"
        Me.Line1.Size = New System.Drawing.Size(464, 23)
        Me.Line1.TabIndex = 4
        Me.Line1.Text = "Line1"
        '
        'CRbtVerProd
        '
        Me.CRbtVerProd.Location = New System.Drawing.Point(172, 107)
        Me.CRbtVerProd.Name = "CRbtVerProd"
        Me.CRbtVerProd.Size = New System.Drawing.Size(108, 23)
        Me.CRbtVerProd.TabIndex = 5
        Me.CRbtVerProd.Text = "VER PRODUCTO"
        Me.CRbtVerProd.UseVisualStyleBackColor = True
        '
        'UCElemProducto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Controls.Add(Me.CRbtVerProd)
        Me.Controls.Add(Me.Line1)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.RatingStar1)
        Me.Controls.Add(Me.UCLabelTitulo)
        Me.Controls.Add(Me.PictureBox1)
        Me.Name = "UCElemProducto"
        Me.Size = New System.Drawing.Size(464, 188)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents UCLabelTitulo As DevComponents.DotNetBar.LabelX
    Friend WithEvents RatingStar1 As DevComponents.DotNetBar.Controls.RatingStar
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents Line1 As DevComponents.DotNetBar.Controls.Line
    Friend WithEvents CRbtVerProd As System.Windows.Forms.Button

End Class
