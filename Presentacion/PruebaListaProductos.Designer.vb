<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PruebaListaProductos
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
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel2.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.AutoScroll = True
        Me.Panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(358, 408)
        Me.Panel1.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.ReflectionLabel1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(729, 58)
        Me.Panel2.TabIndex = 0
        '
        'ReflectionLabel1
        '
        Me.ReflectionLabel1.BackColor = System.Drawing.SystemColors.ActiveCaption
        '
        '
        '
        Me.ReflectionLabel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionLabel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ReflectionLabel1.Location = New System.Drawing.Point(0, 0)
        Me.ReflectionLabel1.Name = "ReflectionLabel1"
        Me.ReflectionLabel1.Size = New System.Drawing.Size(729, 58)
        Me.ReflectionLabel1.TabIndex = 0
        Me.ReflectionLabel1.Text = "<b><font size=""+6""><i>LISTA  DE  </i><font color=""#B02B2C""> PRODUCTOS</font></fon" & _
    "t></b>"
        '
        'Panel3
        '
        Me.Panel3.AutoScroll = True
        Me.Panel3.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(367, 3)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(359, 408)
        Me.Panel3.TabIndex = 1
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel3, 1, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 58)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(729, 414)
        Me.TableLayoutPanel1.TabIndex = 2
        '
        'PruebaListaProductos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(729, 472)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.Panel2)
        Me.Name = "PruebaListaProductos"
        Me.Text = "PruebaListaProductos"
        Me.Panel2.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
End Class
