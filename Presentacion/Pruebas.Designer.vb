<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Pruebas
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
        Me.CalendarView1 = New DevComponents.DotNetBar.Schedule.CalendarView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.DateNavigator1 = New DevComponents.DotNetBar.Schedule.DateNavigator()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'CalendarView1
        '
        '
        '
        '
        Me.CalendarView1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CalendarView1.ContainerControlProcessDialogKey = True
        Me.CalendarView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CalendarView1.LabelTimeSlots = True
        Me.CalendarView1.Location = New System.Drawing.Point(0, 0)
        Me.CalendarView1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CalendarView1.MultiUserTabHeight = 19
        Me.CalendarView1.Name = "CalendarView1"
        Me.CalendarView1.SelectedView = DevComponents.DotNetBar.Schedule.eCalendarView.Week
        Me.CalendarView1.ShowOnlyWorkDayHours = True
        Me.CalendarView1.Size = New System.Drawing.Size(1004, 451)
        Me.CalendarView1.TabIndex = 0
        Me.CalendarView1.Text = "CalendarView1"
        Me.CalendarView1.TimeIndicator.BorderColor = System.Drawing.Color.Empty
        Me.CalendarView1.TimeIndicator.Tag = Nothing
        Me.CalendarView1.TimeSlotDuration = 30
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.CrystalReportViewer1)
        Me.Panel1.Controls.Add(Me.DateNavigator1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1004, 123)
        Me.Panel1.TabIndex = 1
        '
        'DateNavigator1
        '
        Me.DateNavigator1.CalendarView = Me.CalendarView1
        Me.DateNavigator1.CanvasColor = System.Drawing.SystemColors.Control
        Me.DateNavigator1.DisabledBackColor = System.Drawing.Color.Empty
        Me.DateNavigator1.Location = New System.Drawing.Point(4, 86)
        Me.DateNavigator1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DateNavigator1.Name = "DateNavigator1"
        Me.DateNavigator1.Size = New System.Drawing.Size(464, 37)
        Me.DateNavigator1.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.DateNavigator1.TabIndex = 0
        Me.DateNavigator1.Text = "DateNavigator1"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.CalendarView1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 123)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1004, 451)
        Me.Panel2.TabIndex = 2
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 123)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1004, 451)
        Me.Panel3.TabIndex = 4
        '
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.ActiveViewIndex = -1
        Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(619, 67)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(150, 150)
        Me.CrystalReportViewer1.TabIndex = 4
        '
        'Pruebas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1004, 574)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "Pruebas"
        Me.Text = "Pruebas"
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CalendarView1 As DevComponents.DotNetBar.Schedule.CalendarView
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents DateNavigator1 As DevComponents.DotNetBar.Schedule.DateNavigator
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
