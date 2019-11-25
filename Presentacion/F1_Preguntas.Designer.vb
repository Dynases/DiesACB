<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F1_Preguntas
    Inherits Modelos.ModeloF1

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
        Dim tbCat_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F1_Preguntas))
        Me.tbCat = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.LabelX8 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX16 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.tbDesc = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.tbNumi = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.tbTipo = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.tbPonderacion = New DevComponents.Editors.DoubleInput()
        CType(Me.SuperTabPrincipal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuperTabPrincipal.SuspendLayout()
        Me.SuperTabControlPanelRegistro.SuspendLayout()
        Me.PanelSuperior.SuspendLayout()
        Me.PanelInferior.SuspendLayout()
        CType(Me.BubbleBarUsuario, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelToolBar1.SuspendLayout()
        Me.PanelToolBar2.SuspendLayout()
        Me.MPanelSup.SuspendLayout()
        Me.PanelPrincipal.SuspendLayout()
        Me.GroupPanelBuscador.SuspendLayout()
        CType(Me.JGrM_Buscador, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelUsuario.SuspendLayout()
        Me.PanelNavegacion.SuspendLayout()
        Me.MPanelUserAct.SuspendLayout()
        CType(Me.MEP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbCat, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbPonderacion, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.SuperTabPrincipal.Size = New System.Drawing.Size(1097, 620)
        Me.SuperTabPrincipal.Controls.SetChildIndex(Me.SuperTabControlPanelBuscador, 0)
        Me.SuperTabPrincipal.Controls.SetChildIndex(Me.SuperTabControlPanelRegistro, 0)
        '
        'SuperTabControlPanelBuscador
        '
        Me.SuperTabControlPanelBuscador.Size = New System.Drawing.Size(1097, 595)
        '
        'SuperTabControlPanelRegistro
        '
        Me.SuperTabControlPanelRegistro.Size = New System.Drawing.Size(1097, 595)
        Me.SuperTabControlPanelRegistro.Controls.SetChildIndex(Me.PanelSuperior, 0)
        Me.SuperTabControlPanelRegistro.Controls.SetChildIndex(Me.PanelInferior, 0)
        Me.SuperTabControlPanelRegistro.Controls.SetChildIndex(Me.PanelPrincipal, 0)
        '
        'PanelSuperior
        '
        Me.PanelSuperior.Size = New System.Drawing.Size(1097, 72)
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
        Me.PanelInferior.Location = New System.Drawing.Point(0, 559)
        Me.PanelInferior.Size = New System.Drawing.Size(1097, 36)
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
        'btnModificar
        '
        '
        'btnNuevo
        '
        '
        'PanelToolBar2
        '
        Me.PanelToolBar2.Location = New System.Drawing.Point(1017, 0)
        '
        'MPanelSup
        '
        Me.MPanelSup.Controls.Add(Me.tbPonderacion)
        Me.MPanelSup.Controls.Add(Me.tbTipo)
        Me.MPanelSup.Controls.Add(Me.tbCat)
        Me.MPanelSup.Controls.Add(Me.LabelX8)
        Me.MPanelSup.Controls.Add(Me.LabelX16)
        Me.MPanelSup.Controls.Add(Me.LabelX3)
        Me.MPanelSup.Controls.Add(Me.tbDesc)
        Me.MPanelSup.Controls.Add(Me.LabelX2)
        Me.MPanelSup.Controls.Add(Me.LabelX1)
        Me.MPanelSup.Controls.Add(Me.tbNumi)
        Me.MPanelSup.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MPanelSup.Size = New System.Drawing.Size(1097, 220)
        Me.MPanelSup.Controls.SetChildIndex(Me.tbNumi, 0)
        Me.MPanelSup.Controls.SetChildIndex(Me.LabelX1, 0)
        Me.MPanelSup.Controls.SetChildIndex(Me.LabelX2, 0)
        Me.MPanelSup.Controls.SetChildIndex(Me.tbDesc, 0)
        Me.MPanelSup.Controls.SetChildIndex(Me.LabelX3, 0)
        Me.MPanelSup.Controls.SetChildIndex(Me.LabelX16, 0)
        Me.MPanelSup.Controls.SetChildIndex(Me.LabelX8, 0)
        Me.MPanelSup.Controls.SetChildIndex(Me.tbCat, 0)
        Me.MPanelSup.Controls.SetChildIndex(Me.PanelUsuario, 0)
        Me.MPanelSup.Controls.SetChildIndex(Me.tbTipo, 0)
        Me.MPanelSup.Controls.SetChildIndex(Me.tbPonderacion, 0)
        '
        'PanelPrincipal
        '
        Me.PanelPrincipal.Size = New System.Drawing.Size(1097, 487)
        '
        'GroupPanelBuscador
        '
        Me.GroupPanelBuscador.Location = New System.Drawing.Point(0, 220)
        Me.GroupPanelBuscador.Size = New System.Drawing.Size(1097, 267)
        '
        '
        '
        Me.GroupPanelBuscador.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GroupPanelBuscador.Style.BackColorGradientAngle = 90
        Me.GroupPanelBuscador.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.GroupPanelBuscador.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanelBuscador.Style.BorderBottomWidth = 1
        Me.GroupPanelBuscador.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanelBuscador.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanelBuscador.Style.BorderLeftWidth = 1
        Me.GroupPanelBuscador.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanelBuscador.Style.BorderRightWidth = 1
        Me.GroupPanelBuscador.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanelBuscador.Style.BorderTopWidth = 1
        Me.GroupPanelBuscador.Style.CornerDiameter = 4
        Me.GroupPanelBuscador.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanelBuscador.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanelBuscador.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanelBuscador.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanelBuscador.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanelBuscador.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'JGrM_Buscador
        '
        Me.JGrM_Buscador.Size = New System.Drawing.Size(1091, 244)
        '
        'MPanelUserAct
        '
        Me.MPanelUserAct.Location = New System.Drawing.Point(897, 0)
        '
        'tbCat
        '
        tbCat_DesignTimeLayout.LayoutString = resources.GetString("tbCat_DesignTimeLayout.LayoutString")
        Me.tbCat.DesignTimeLayout = tbCat_DesignTimeLayout
        Me.tbCat.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbCat.Location = New System.Drawing.Point(176, 155)
        Me.tbCat.Name = "tbCat"
        Me.tbCat.SelectedIndex = -1
        Me.tbCat.SelectedItem = Nothing
        Me.tbCat.Size = New System.Drawing.Size(100, 22)
        Me.tbCat.TabIndex = 98
        '
        'LabelX8
        '
        '
        '
        '
        Me.LabelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX8.Location = New System.Drawing.Point(28, 151)
        Me.LabelX8.Name = "LabelX8"
        Me.LabelX8.Size = New System.Drawing.Size(90, 23)
        Me.LabelX8.TabIndex = 105
        Me.LabelX8.Text = "CATEGORIA:"
        '
        'LabelX16
        '
        '
        '
        '
        Me.LabelX16.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX16.Location = New System.Drawing.Point(26, 122)
        Me.LabelX16.Name = "LabelX16"
        Me.LabelX16.Size = New System.Drawing.Size(87, 23)
        Me.LabelX16.TabIndex = 104
        Me.LabelX16.Text = "TIPO:"
        '
        'LabelX3
        '
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX3.Location = New System.Drawing.Point(26, 68)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(96, 23)
        Me.LabelX3.TabIndex = 102
        Me.LabelX3.Text = "DESCRIPCION:"
        '
        'tbDesc
        '
        Me.tbDesc.AllowDrop = True
        '
        '
        '
        Me.tbDesc.Border.Class = "TextBoxBorder"
        Me.tbDesc.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbDesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbDesc.Location = New System.Drawing.Point(176, 68)
        Me.tbDesc.Multiline = True
        Me.tbDesc.Name = "tbDesc"
        Me.tbDesc.PreventEnterBeep = True
        Me.tbDesc.Size = New System.Drawing.Size(567, 50)
        Me.tbDesc.TabIndex = 96
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX1.Location = New System.Drawing.Point(26, 29)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(75, 23)
        Me.LabelX1.TabIndex = 100
        Me.LabelX1.Text = "ID:"
        '
        'tbNumi
        '
        '
        '
        '
        Me.tbNumi.Border.Class = "TextBoxBorder"
        Me.tbNumi.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbNumi.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbNumi.Location = New System.Drawing.Point(176, 32)
        Me.tbNumi.Name = "tbNumi"
        Me.tbNumi.PreventEnterBeep = True
        Me.tbNumi.Size = New System.Drawing.Size(100, 22)
        Me.tbNumi.TabIndex = 94
        '
        'LabelX2
        '
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX2.Location = New System.Drawing.Point(28, 180)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(142, 23)
        Me.LabelX2.TabIndex = 101
        Me.LabelX2.Text = "PONDERACION NOTA:"
        '
        'tbTipo
        '
        Me.tbTipo.DisplayMember = "Text"
        Me.tbTipo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.tbTipo.FormattingEnabled = True
        Me.tbTipo.ItemHeight = 16
        Me.tbTipo.Location = New System.Drawing.Point(176, 124)
        Me.tbTipo.Name = "tbTipo"
        Me.tbTipo.Size = New System.Drawing.Size(258, 22)
        Me.tbTipo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.tbTipo.TabIndex = 106
        '
        'tbPonderacion
        '
        '
        '
        '
        Me.tbPonderacion.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.tbPonderacion.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbPonderacion.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.tbPonderacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbPonderacion.Increment = 1.0R
        Me.tbPonderacion.Location = New System.Drawing.Point(176, 183)
        Me.tbPonderacion.Name = "tbPonderacion"
        Me.tbPonderacion.ShowUpDown = True
        Me.tbPonderacion.Size = New System.Drawing.Size(100, 21)
        Me.tbPonderacion.TabIndex = 107
        '
        'F1_Preguntas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1097, 620)
        Me.Name = "F1_Preguntas"
        Me.Text = "F1_Preguntas"
        Me.Controls.SetChildIndex(Me.SuperTabPrincipal, 0)
        CType(Me.SuperTabPrincipal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SuperTabPrincipal.ResumeLayout(False)
        Me.SuperTabControlPanelRegistro.ResumeLayout(False)
        Me.PanelSuperior.ResumeLayout(False)
        Me.PanelInferior.ResumeLayout(False)
        CType(Me.BubbleBarUsuario, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelToolBar1.ResumeLayout(False)
        Me.PanelToolBar2.ResumeLayout(False)
        Me.MPanelSup.ResumeLayout(False)
        Me.MPanelSup.PerformLayout()
        Me.PanelPrincipal.ResumeLayout(False)
        Me.GroupPanelBuscador.ResumeLayout(False)
        CType(Me.JGrM_Buscador, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelUsuario.ResumeLayout(False)
        Me.PanelUsuario.PerformLayout()
        Me.PanelNavegacion.ResumeLayout(False)
        Me.MPanelUserAct.ResumeLayout(False)
        Me.MPanelUserAct.PerformLayout()
        CType(Me.MEP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbCat, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbPonderacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tbCat As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents LabelX8 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX16 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents tbDesc As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents tbNumi As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents tbTipo As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents tbPonderacion As DevComponents.Editors.DoubleInput
End Class
