<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F1_POLITICA
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
        Dim cbTipo_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cbServicios_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F1_POLITICA))
        Me.cbTipo = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.tbNumi = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.tbObs = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX14 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.tbCuota = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.tbCantidad = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.tbDesc = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.cbServicios = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
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
        CType(Me.cbTipo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbServicios, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.SuperTabPrincipal.Size = New System.Drawing.Size(1140, 647)
        Me.SuperTabPrincipal.Controls.SetChildIndex(Me.SuperTabControlPanelBuscador, 0)
        Me.SuperTabPrincipal.Controls.SetChildIndex(Me.SuperTabControlPanelRegistro, 0)
        '
        'SuperTabControlPanelBuscador
        '
        Me.SuperTabControlPanelBuscador.Size = New System.Drawing.Size(884, 708)
        '
        'SuperTabControlPanelRegistro
        '
        Me.SuperTabControlPanelRegistro.Size = New System.Drawing.Size(1140, 622)
        Me.SuperTabControlPanelRegistro.Controls.SetChildIndex(Me.PanelSuperior, 0)
        Me.SuperTabControlPanelRegistro.Controls.SetChildIndex(Me.PanelInferior, 0)
        Me.SuperTabControlPanelRegistro.Controls.SetChildIndex(Me.PanelPrincipal, 0)
        '
        'PanelSuperior
        '
        Me.PanelSuperior.Size = New System.Drawing.Size(1140, 72)
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
        Me.PanelInferior.Location = New System.Drawing.Point(0, 586)
        Me.PanelInferior.Size = New System.Drawing.Size(1140, 36)
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
        'btnGrabar
        '
        Me.btnGrabar.TabIndex = 0
        '
        'PanelToolBar2
        '
        Me.PanelToolBar2.Location = New System.Drawing.Point(1060, 0)
        '
        'MPanelSup
        '
        Me.MPanelSup.Controls.Add(Me.cbServicios)
        Me.MPanelSup.Controls.Add(Me.LabelX6)
        Me.MPanelSup.Controls.Add(Me.tbDesc)
        Me.MPanelSup.Controls.Add(Me.LabelX5)
        Me.MPanelSup.Controls.Add(Me.LabelX4)
        Me.MPanelSup.Controls.Add(Me.tbCantidad)
        Me.MPanelSup.Controls.Add(Me.LabelX3)
        Me.MPanelSup.Controls.Add(Me.tbCuota)
        Me.MPanelSup.Controls.Add(Me.cbTipo)
        Me.MPanelSup.Controls.Add(Me.LabelX1)
        Me.MPanelSup.Controls.Add(Me.tbNumi)
        Me.MPanelSup.Controls.Add(Me.LabelX2)
        Me.MPanelSup.Controls.Add(Me.tbObs)
        Me.MPanelSup.Controls.Add(Me.LabelX14)
        Me.MPanelSup.Size = New System.Drawing.Size(1140, 308)
        Me.MPanelSup.Controls.SetChildIndex(Me.LabelX14, 0)
        Me.MPanelSup.Controls.SetChildIndex(Me.tbObs, 0)
        Me.MPanelSup.Controls.SetChildIndex(Me.LabelX2, 0)
        Me.MPanelSup.Controls.SetChildIndex(Me.tbNumi, 0)
        Me.MPanelSup.Controls.SetChildIndex(Me.LabelX1, 0)
        Me.MPanelSup.Controls.SetChildIndex(Me.cbTipo, 0)
        Me.MPanelSup.Controls.SetChildIndex(Me.tbCuota, 0)
        Me.MPanelSup.Controls.SetChildIndex(Me.LabelX3, 0)
        Me.MPanelSup.Controls.SetChildIndex(Me.tbCantidad, 0)
        Me.MPanelSup.Controls.SetChildIndex(Me.LabelX4, 0)
        Me.MPanelSup.Controls.SetChildIndex(Me.PanelUsuario, 0)
        Me.MPanelSup.Controls.SetChildIndex(Me.LabelX5, 0)
        Me.MPanelSup.Controls.SetChildIndex(Me.tbDesc, 0)
        Me.MPanelSup.Controls.SetChildIndex(Me.LabelX6, 0)
        Me.MPanelSup.Controls.SetChildIndex(Me.cbServicios, 0)
        '
        'PanelPrincipal
        '
        Me.PanelPrincipal.Size = New System.Drawing.Size(1140, 514)
        '
        'GroupPanelBuscador
        '
        Me.GroupPanelBuscador.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupPanelBuscador.Location = New System.Drawing.Point(0, 308)
        Me.GroupPanelBuscador.Size = New System.Drawing.Size(1140, 206)
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
        Me.JGrM_Buscador.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.JGrM_Buscador.Office2007ColorScheme = Janus.Windows.GridEX.Office2007ColorScheme.Custom
        Me.JGrM_Buscador.Office2007CustomColor = System.Drawing.Color.DodgerBlue
        Me.JGrM_Buscador.Size = New System.Drawing.Size(1134, 181)
        Me.JGrM_Buscador.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'MPanelUserAct
        '
        Me.MPanelUserAct.Location = New System.Drawing.Point(940, 0)
        '
        'cbTipo
        '
        cbTipo_DesignTimeLayout.LayoutString = resources.GetString("cbTipo_DesignTimeLayout.LayoutString")
        Me.cbTipo.DesignTimeLayout = cbTipo_DesignTimeLayout
        Me.cbTipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbTipo.Location = New System.Drawing.Point(165, 53)
        Me.cbTipo.Name = "cbTipo"
        Me.cbTipo.Office2007ColorScheme = Janus.Windows.GridEX.Office2007ColorScheme.Custom
        Me.cbTipo.Office2007CustomColor = System.Drawing.Color.DodgerBlue
        Me.cbTipo.SelectedIndex = -1
        Me.cbTipo.SelectedItem = Nothing
        Me.cbTipo.Size = New System.Drawing.Size(156, 22)
        Me.cbTipo.TabIndex = 1
        Me.cbTipo.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX1.Location = New System.Drawing.Point(32, 19)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(21, 23)
        Me.LabelX1.TabIndex = 200
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
        Me.tbNumi.Location = New System.Drawing.Point(165, 20)
        Me.tbNumi.Name = "tbNumi"
        Me.tbNumi.PreventEnterBeep = True
        Me.tbNumi.Size = New System.Drawing.Size(57, 22)
        Me.tbNumi.TabIndex = 0
        Me.tbNumi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LabelX2
        '
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX2.Location = New System.Drawing.Point(32, 55)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(50, 23)
        Me.LabelX2.TabIndex = 201
        Me.LabelX2.Text = "TIPO:"
        '
        'tbObs
        '
        '
        '
        '
        Me.tbObs.Border.Class = "TextBoxBorder"
        Me.tbObs.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbObs.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbObs.Location = New System.Drawing.Point(165, 218)
        Me.tbObs.Multiline = True
        Me.tbObs.Name = "tbObs"
        Me.tbObs.PreventEnterBeep = True
        Me.tbObs.Size = New System.Drawing.Size(191, 64)
        Me.tbObs.TabIndex = 6
        '
        'LabelX14
        '
        '
        '
        '
        Me.LabelX14.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX14.Location = New System.Drawing.Point(32, 217)
        Me.LabelX14.Name = "LabelX14"
        Me.LabelX14.Size = New System.Drawing.Size(116, 23)
        Me.LabelX14.TabIndex = 202
        Me.LabelX14.Text = "OBSERVACION:"
        '
        'LabelX3
        '
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX3.Location = New System.Drawing.Point(32, 117)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(63, 23)
        Me.LabelX3.TabIndex = 204
        Me.LabelX3.Text = "CUOTA:"
        '
        'tbCuota
        '
        '
        '
        '
        Me.tbCuota.Border.Class = "TextBoxBorder"
        Me.tbCuota.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbCuota.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbCuota.Location = New System.Drawing.Point(165, 118)
        Me.tbCuota.Name = "tbCuota"
        Me.tbCuota.PreventEnterBeep = True
        Me.tbCuota.Size = New System.Drawing.Size(80, 22)
        Me.tbCuota.TabIndex = 3
        Me.tbCuota.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LabelX4
        '
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX4.Location = New System.Drawing.Point(32, 150)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(75, 23)
        Me.LabelX4.TabIndex = 206
        Me.LabelX4.Text = "CANTIDAD:"
        '
        'tbCantidad
        '
        '
        '
        '
        Me.tbCantidad.Border.Class = "TextBoxBorder"
        Me.tbCantidad.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbCantidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbCantidad.Location = New System.Drawing.Point(165, 151)
        Me.tbCantidad.Name = "tbCantidad"
        Me.tbCantidad.PreventEnterBeep = True
        Me.tbCantidad.Size = New System.Drawing.Size(80, 22)
        Me.tbCantidad.TabIndex = 4
        Me.tbCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LabelX5
        '
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX5.Location = New System.Drawing.Point(32, 188)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(127, 23)
        Me.LabelX5.TabIndex = 208
        Me.LabelX5.Text = "DESCUENTO (%) :"
        '
        'tbDesc
        '
        '
        '
        '
        Me.tbDesc.Border.Class = "TextBoxBorder"
        Me.tbDesc.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbDesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbDesc.Location = New System.Drawing.Point(165, 186)
        Me.tbDesc.Name = "tbDesc"
        Me.tbDesc.PreventEnterBeep = True
        Me.tbDesc.Size = New System.Drawing.Size(80, 22)
        Me.tbDesc.TabIndex = 5
        Me.tbDesc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cbServicios
        '
        cbServicios_DesignTimeLayout.LayoutString = resources.GetString("cbServicios_DesignTimeLayout.LayoutString")
        Me.cbServicios.DesignTimeLayout = cbServicios_DesignTimeLayout
        Me.cbServicios.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbServicios.Location = New System.Drawing.Point(165, 84)
        Me.cbServicios.Name = "cbServicios"
        Me.cbServicios.Office2007ColorScheme = Janus.Windows.GridEX.Office2007ColorScheme.Custom
        Me.cbServicios.Office2007CustomColor = System.Drawing.Color.DodgerBlue
        Me.cbServicios.SelectedIndex = -1
        Me.cbServicios.SelectedItem = Nothing
        Me.cbServicios.Size = New System.Drawing.Size(211, 22)
        Me.cbServicios.TabIndex = 2
        Me.cbServicios.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'LabelX6
        '
        '
        '
        '
        Me.LabelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX6.Location = New System.Drawing.Point(32, 85)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(97, 23)
        Me.LabelX6.TabIndex = 210
        Me.LabelX6.Text = "SERVICIOS:"
        '
        'F1_POLITICA
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1140, 647)
        Me.Name = "F1_POLITICA"
        Me.Text = "F1_POLITICA"
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
        CType(Me.cbTipo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbServicios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cbTipo As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents tbNumi As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents tbObs As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX14 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents tbCantidad As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents tbCuota As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents tbDesc As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents cbServicios As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
End Class
