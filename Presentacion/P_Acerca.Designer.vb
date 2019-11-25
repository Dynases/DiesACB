<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class P_Acerca
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

    Friend WithEvents LogoPictureBox As System.Windows.Forms.PictureBox

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(P_Acerca))
        Me.TextBoxDescription = New System.Windows.Forms.TextBox()
        Me.OKButton = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lbVersion = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LogoPictureBox = New System.Windows.Forms.PictureBox()
        Me.Panel1.SuspendLayout()
        CType(Me.LogoPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TextBoxDescription
        '
        Me.TextBoxDescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxDescription.Location = New System.Drawing.Point(8, 154)
        Me.TextBoxDescription.Margin = New System.Windows.Forms.Padding(8, 4, 4, 4)
        Me.TextBoxDescription.Multiline = True
        Me.TextBoxDescription.Name = "TextBoxDescription"
        Me.TextBoxDescription.ReadOnly = True
        Me.TextBoxDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TextBoxDescription.Size = New System.Drawing.Size(328, 270)
        Me.TextBoxDescription.TabIndex = 0
        Me.TextBoxDescription.TabStop = False
        Me.TextBoxDescription.Text = resources.GetString("TextBoxDescription.Text")
        '
        'OKButton
        '
        Me.OKButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OKButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.OKButton.Location = New System.Drawing.Point(571, 390)
        Me.OKButton.Margin = New System.Windows.Forms.Padding(4)
        Me.OKButton.Name = "OKButton"
        Me.OKButton.Size = New System.Drawing.Size(100, 34)
        Me.OKButton.TabIndex = 0
        Me.OKButton.Text = "&OK"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lbVersion)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.OKButton)
        Me.Panel1.Controls.Add(Me.TextBoxDescription)
        Me.Panel1.Controls.Add(Me.LogoPictureBox)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(12, 11)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(675, 433)
        Me.Panel1.TabIndex = 1
        '
        'lbVersion
        '
        Me.lbVersion.AutoSize = True
        Me.lbVersion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbVersion.Location = New System.Drawing.Point(420, 190)
        Me.lbVersion.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbVersion.Name = "lbVersion"
        Me.lbVersion.Size = New System.Drawing.Size(44, 20)
        Me.lbVersion.TabIndex = 6
        Me.lbVersion.Text = "3.1.4"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(351, 220)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(129, 20)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Fecha: 18/05/18"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(351, 284)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(296, 20)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Nombre de Empresa: DINASES S.R.L."
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(349, 252)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(279, 20)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Derechos de Autor: DINASES S.R.L"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(349, 190)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 20)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Versión:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(349, 158)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(185, 20)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Nombre Producto: Dies"
        '
        'LogoPictureBox
        '
        Me.LogoPictureBox.Dock = System.Windows.Forms.DockStyle.Top
        Me.LogoPictureBox.ErrorImage = Nothing
        Me.LogoPictureBox.Image = Global.Presentacion.My.Resources.Resources.LOGO2
        Me.LogoPictureBox.Location = New System.Drawing.Point(0, 0)
        Me.LogoPictureBox.Margin = New System.Windows.Forms.Padding(4)
        Me.LogoPictureBox.Name = "LogoPictureBox"
        Me.LogoPictureBox.Size = New System.Drawing.Size(675, 146)
        Me.LogoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.LogoPictureBox.TabIndex = 0
        Me.LogoPictureBox.TabStop = False
        '
        'P_Acerca
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.OKButton
        Me.ClientSize = New System.Drawing.Size(699, 455)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "P_Acerca"
        Me.Padding = New System.Windows.Forms.Padding(12, 11, 12, 11)
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "P_Acerca"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.LogoPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TextBoxDescription As System.Windows.Forms.TextBox
    Friend WithEvents OKButton As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lbVersion As Label
    Friend WithEvents Label5 As Label
End Class
