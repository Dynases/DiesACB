
Imports Logica.AccesoLogica
Imports Janus.Windows.GridEX
Imports DevComponents.DotNetBar
Imports System.IO
Imports DevComponents.DotNetBar.SuperGrid
Imports Presentacion.F_ClienteNuevoServicio
Public Class F0_RecepcionLavadero

#Region "Variables Globales"

    Public _nameButton As String
    Dim TablaImagenes As DataTable
    Dim TablaInventario As DataTable
    Dim RutaGlobal As String = gs_CarpetaRaiz
    Dim RutaTemporal As String = "C:\Temporal"
    Dim gs_DirPrograma As String = ""
    Dim gs_RutaImg As String = ""
#End Region



#Region "Metodos Privados"
    Private Sub _prCrearCarpetaImagenes(carpetaFinal As String)
        Dim rutaDestino As String = RutaGlobal + "\Imagenes\Imagenes RecepcionVehiculo\" + carpetaFinal + "\"

        If System.IO.Directory.Exists(RutaGlobal + "\Imagenes\Imagenes RecepcionVehiculo\" + carpetaFinal) = False Then
            If System.IO.Directory.Exists(RutaGlobal + "\Imagenes") = False Then
                System.IO.Directory.CreateDirectory(RutaGlobal + "\Imagenes")
                If System.IO.Directory.Exists(RutaGlobal + "\Imagenes\Imagenes RecepcionVehiculo") = False Then
                    System.IO.Directory.CreateDirectory(RutaGlobal + "\Imagenes\Imagenes RecepcionVehiculo")
                    System.IO.Directory.CreateDirectory(RutaGlobal + "\Imagenes\Imagenes RecepcionVehiculo\" + carpetaFinal + "\")
                End If
            Else
                If System.IO.Directory.Exists(RutaGlobal + "\Imagenes\Imagenes RecepcionVehiculo") = False Then
                    System.IO.Directory.CreateDirectory(RutaGlobal + "\Imagenes\Imagenes RecepcionVehiculo")
                    System.IO.Directory.CreateDirectory(RutaGlobal + "\Imagenes\Imagenes RecepcionVehiculo\" + carpetaFinal + "\")
                Else
                    If System.IO.Directory.Exists(RutaGlobal + "\Imagenes\Imagenes RecepcionVehiculo\" + carpetaFinal) = False Then
                        System.IO.Directory.CreateDirectory(RutaGlobal + "\Imagenes\Imagenes RecepcionVehiculo\" + carpetaFinal + "\")
                    End If

                End If
            End If
        End If
    End Sub

    Private Sub _prCrearCarpetaTemporal()

        If System.IO.Directory.Exists(RutaTemporal) = False Then
            System.IO.Directory.CreateDirectory(RutaTemporal)
        Else

            My.Computer.FileSystem.DeleteDirectory(RutaTemporal, FileIO.DeleteDirectoryOption.DeleteAllContents)
            My.Computer.FileSystem.CreateDirectory(RutaTemporal)

        End If

    End Sub
    Private Sub _IniciarTodo()
        _prLeerArchivoConfig()
        L_prAbrirConexion(gs_Ip, gs_UsuarioSql, gs_ClaveSql, gs_NombreBD)
        _prCargarComboLibreria(cbTamano, 1, 4) ''Libreria Vehiculo=1  TamVehiculo=4
        _prCargarComboLibreria(cbTipoVehiculo, 14, 2) ''Libreria Vehiculo=1  TamVehiculo=4
        _prLeerTextCheck()
        Me.WindowState = FormWindowState.Maximized

        _prInhabilitar()

        '_prAsignarPermisos()
        Me.Text = "R E C E PC I O N   D E   V E H I C U L O S"
        _prCargarGridAyudaPlacaCLiente()
        _prCargarGridGeneralControl()

        _prEliminarContenidoImage()
    End Sub
    Private Sub _prLeerArchivoConfig()
        Dim Archivo() As String = IO.File.ReadAllLines(Application.StartupPath + "\CONFIG.TXT")
        gs_Ip = Archivo(0).Split("=")(1).Trim
        gs_UsuarioSql = Archivo(1).Split("=")(1).Trim
        gs_ClaveSql = Archivo(2).Split("=")(1).Trim
        gs_NombreBD = Archivo(3).Split("=")(1).Trim
        gs_CarpetaRaiz = Archivo(4).Split("=")(1).Trim
        'gs_DirPrograma = Archivo(5).Split("=")(1).Trim
        'gs_RutaImg = Archivo(6).Split("=")(1).Trim
        RutaGlobal = gs_CarpetaRaiz
    End Sub
    Sub _prEliminarContenidoImage()
        Try
            My.Computer.FileSystem.DeleteDirectory(gs_RutaImg, FileIO.DeleteDirectoryOption.DeleteAllContents)
        Catch ex As Exception

        End Try

    End Sub


    Private Sub _prCargarGridServicios(numi As String)

        Dim dt As New DataTable
        dt = L_prGeneralServicios(numi)

        'linumi ,litcl6numi ,liserv ,codigo,servicio, estado
        ''''janosssssssss''''''
        grServicios.DataSource = dt
        grServicios.RetrieveStructure()
        grServicios.AlternatingColors = True
        grServicios.RowFormatStyle.Font = New Font("arial", 10)

        With grServicios.RootTable.Columns("linumi")
            .Width = 120
            .Visible = False
            .Caption = "Codigo".ToUpper
        End With
        With grServicios.RootTable.Columns("litcl6numi")
            .Width = 120
            .Visible = False
        End With
        With grServicios.RootTable.Columns("liserv")
            .Width = 120
            .Visible = False
        End With

        With grServicios.RootTable.Columns("codigo")
            .Width = 150
            .TextAlignment = TextAlignment.Center
            .Caption = "CODIGO SERVICIO"
            .Visible = True
        End With
        With grServicios.RootTable.Columns("servicio")
            .Width = 400
            .Visible = True
            .Caption = "SERVICIOS"
        End With


        With grServicios.RootTable.Columns("estado")
            .Width = 150
            .Visible = True
            .CellStyle.BackColor = Color.Azure
            .Caption = "ESTADO"
        End With


        With grServicios
            .GroupByBoxVisible = False
            'diseño de la grilla
            .VisualStyle = VisualStyle.Office2007
            .DefaultFilterRowComparison = FilterConditionOperator.Contains
            .FilterMode = FilterMode.Automatic
            .FilterRowUpdateMode = FilterRowUpdateMode.WhenValueChanges
            '.RootTable.RowHeight = 50
        End With

        grServicios.RootTable.HeaderFormatStyle.FontBold = TriState.True
        _prAplicarCondiccionJanusServicio()
    End Sub
    Public Sub _prAplicarCondiccionJanusServicio()
        Dim fc As GridEXFormatCondition
        fc = New GridEXFormatCondition(grServicios.RootTable.Columns("estado"), ConditionOperator.Equal, 1)
        fc.FormatStyle.BackColor = Color.DodgerBlue
        fc.FormatStyle.FontBold = TriState.True

        grServicios.RootTable.FormatConditions.Add(fc)
    End Sub
    Private Sub _prCargarGridGeneralControl()

        Dim dt As New DataTable
        dt = L_prGeneralRecepcion()


        ''''janosssssssss''''''
        grControl.DataSource = dt
        grControl.RetrieveStructure()
        grControl.AlternatingColors = True
        grControl.RowFormatStyle.Font = New Font("arial", 10)

        With grControl.RootTable.Columns("lansoc")
            .Width = 120
            .Visible = True
            .Caption = "N. Socio".ToUpper
        End With

        With grControl.RootTable.Columns("lfnumi")
            .Width = 80
            .TextAlignment = TextAlignment.Center
            .Caption = "CODIGO"

            .Visible = True
        End With
        With grControl.RootTable.Columns("lftcl1soc")
            .Width = 60
            .Visible = False
        End With
        With grControl.RootTable.Columns("nombre")
            .Width = 300
            .Visible = True
            .Caption = "CLIENTE"
        End With
        With grControl.RootTable.Columns("lffecha")
            .Width = 100
            .Visible = False
        End With

        With grControl.RootTable.Columns("lfcl1veh")
            .Width = 100
            .Visible = False
        End With

        With grControl.RootTable.Columns("placa")
            .Width = 150
            .Visible = True
            .Caption = "PLACA"
        End With

        With grControl.RootTable.Columns("lbtip1_4")
            .Width = 150
            .Visible = False
        End With
        With grControl.RootTable.Columns("cedesc1")
            .Width = 200
            .Visible = True
            .Caption = "MARCA"
        End With


        With grControl.RootTable.Columns("lfcomb")
            .Width = 250
            .Visible = False
        End With
        With grControl.RootTable.Columns("lfobs")
            .Width = 350
            .Visible = True
            .Caption = "OBSERVACION"
        End With

        With grControl.RootTable.Columns("lftipo")
            .Width = 250
            .Visible = False
        End With
        'dar formato a las columnas
        '     a.lfnumi ,a.lftcl1soc,cliente.lanom as nombre ,a.lffecha ,a.lfcl1veh,
        'vehiculo.lbplac as placa,vehiculo .lbtip1_4 ,MarcaCliente .cedesc1 ,a.lfcomb ,a.lfobs ,
        'a.lftipo ,a.lftam ,a.lffact ,a.lfhact ,a.lfuact 

        With grControl.RootTable.Columns("lftam")
            .Width = 250
            .Visible = False
        End With

        With grControl.RootTable.Columns("lffact")
            .Width = 250
            .Visible = False
        End With

        With grControl.RootTable.Columns("lfhact")
            .Width = 250
            .Visible = False
        End With
        With grControl.RootTable.Columns("lfuact")
            .Width = 250
            .Visible = False
        End With
        With grControl
            .GroupByBoxVisible = False
            'diseño de la grilla
            .VisualStyle = VisualStyle.Office2007
            .DefaultFilterRowComparison = FilterConditionOperator.Contains
            .FilterMode = FilterMode.Automatic
            .FilterRowUpdateMode = FilterRowUpdateMode.WhenValueChanges
            '.RootTable.RowHeight = 50
        End With

        grControl.RootTable.HeaderFormatStyle.FontBold = TriState.True
    End Sub



    Public Sub _prInhabilitar()
        tbplaca.ReadOnly = True
        cbTamano.ReadOnly = True
        swestado.IsReadOnly = True
        cbTipoVehiculo.ReadOnly = True
        tbFecha.IsInputReadOnly = True
        tbObservacion.ReadOnly = True
        btnDelete.Visible = False
        btnCamara.Visible = False
        btnImagen.Visible = False
        btnSeleccionar.Visible = False
        btnAnadir.Visible = False
        PanelNavegacion.Enabled = True
        ''''''BUTTON '''''''''''''
        btnModificar.Enabled = True
        btnGrabar.Enabled = False
        btnNuevo.Enabled = True
        btnEliminar.Enabled = True
        grControl.Enabled = True
        btnTamanoVehiculo.Visible = False
        btnTipoVehiculo.Visible = False

        grAyuda.RemoveFilters()

    End Sub
    Public Sub _prHabilitar()
        tbplaca.ReadOnly = False
        cbTamano.ReadOnly = False
        swestado.IsReadOnly = False
        cbTipoVehiculo.ReadOnly = False
        tbFecha.IsInputReadOnly = False
        tbObservacion.ReadOnly = False
        btnSeleccionar.Visible = True
        btnAnadir.Visible = True

        btnDelete.Visible = True
        'btnCamara.Visible = True
        btnImagen.Visible = True
        grControl.Enabled = False
        btnTamanoVehiculo.Visible = True
        btnTipoVehiculo.Visible = True
        _prHabilitarCheck()
        cbTamano.ReadOnly = False
        grAyuda.RemoveFilters()

    End Sub
    Private Sub _prCargarComboLibreria(mCombo As Janus.Windows.GridEX.EditControls.MultiColumnCombo, cod1 As String, cod2 As String)
        Dim dt As New DataTable
        dt = L_prLibreriaClienteLGeneral(cod1, cod2)

        With mCombo
            .DropDownList.Columns.Clear()

            .DropDownList.Columns.Add("cenum").Width = 70
            .DropDownList.Columns("cenum").Caption = "COD"

            .DropDownList.Columns.Add("cedesc1").Width = 200
            .DropDownList.Columns("cedesc1").Caption = "DESCRIPCION"

            .ValueMember = "cenum"
            .DisplayMember = "cedesc1"
            .DataSource = dt
            .Refresh()
        End With
    End Sub

    Private Sub _prCargarGridAyudaPlacaCLiente()
        GpVentasSinCobrar.Text = "V E H I C U L O S    C L I E N T E S"
        Dim dt As New DataTable
        dt = L_prRecepcionAyudaClientes()


        ''''janosssssssss''''''
        grAyuda.DataSource = dt
        grAyuda.RetrieveStructure()
        grAyuda.AlternatingColors = True
        grAyuda.RowFormatStyle.Font = New Font("arial", 10)

        'dar formato a las columnas
        '        a.lblin,b.lanumi ,a.lbplac,marca.cedesc1 as marca,modelo .cedesc1  as modelo
        ',Concat(b.lanom,' ',b.laapat ,' ',b.laamat  )as nombre

        With grAyuda.RootTable.Columns("lblin")
            .Width = 80
            .TextAlignment = TextAlignment.Center
            .Caption = "CODIGO"

            .Visible = False
        End With
        With grAyuda.RootTable.Columns("lanumi")
            .Width = 60
            .Visible = False
        End With
        With grAyuda.RootTable.Columns("lansoc")
            .Width = 60
            .Visible = False
        End With
        With grAyuda.RootTable.Columns("lbplac")
            .Width = 100
            .Visible = True
            .Caption = "PLACA"

        End With
        With grAyuda.RootTable.Columns("marca")
            .Width = 150
            .Visible = True
            .Caption = "MARCA"
        End With
        With grAyuda.RootTable.Columns("modelo")
            .Width = 150
            .Caption = "MODELO"
            .Visible = True
        End With
        With grAyuda.RootTable.Columns("nombre")
            .Width = 250
            .Visible = True
            .Caption = "CLIENTES"
            .AutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
            .AllowSize = True

        End With
        With grAyuda.RootTable.Columns("lafot")
            .Width = 250
            .Visible = False
        End With
        With grAyuda.RootTable.Columns("lbtip1_4")
            .Width = 250
            .Visible = False
        End With
        With grAyuda.RootTable.Columns("VehiculoRegistrado")
            .Width = 250
            .Visible = False
        End With
        With grAyuda
            .GroupByBoxVisible = False
            'diseño de la grilla
            .VisualStyle = VisualStyle.Office2007
            .DefaultFilterRowComparison = FilterConditionOperator.Contains
            .FilterMode = FilterMode.Automatic
            .FilterRowUpdateMode = FilterRowUpdateMode.WhenValueChanges
            '.RootTable.RowHeight = 50
        End With
        'grAyuda.ScrollBarWidth = 100
        grAyuda.RootTable.HeaderFormatStyle.FontBold = TriState.True
    End Sub


    Public Function _fnObtenerNumeroFilasActivas() As Integer
        Dim n As Integer = -1
        For i As Integer = 0 To TablaImagenes.Rows.Count - 1 Step 1
            Dim estado As Integer = TablaImagenes.Rows(i).Item("estado")
            If (estado = 0 Or estado = 1) Then
                n += 1

            End If
        Next
        Return n
    End Function
    Public Sub _prCargarImagen()
        panelA.Controls.Clear()

        pbImgProdu.Image = Nothing

        Dim i As Integer = 0
        For Each fila As DataRow In TablaImagenes.Rows
            Dim elemImg As UCLavadero = New UCLavadero
            Dim rutImg = fila.Item("lhima").ToString
            Dim estado As Integer = fila.Item("estado")

            If (estado = 0) Then
                elemImg.pbImg.SizeMode = PictureBoxSizeMode.StretchImage
                Dim bm As Bitmap = Nothing
                Dim by As Byte() = fila.Item("img")
                Dim ms As New MemoryStream(by)
                bm = New Bitmap(ms)


                elemImg.pbImg.Image = bm

                pbImgProdu.SizeMode = PictureBoxSizeMode.StretchImage
                pbImgProdu.Image = bm
                elemImg.pbImg.Tag = i
                elemImg.Dock = DockStyle.Top
                pbImgProdu.Tag = i
                AddHandler elemImg.pbImg.MouseEnter, AddressOf pbImg_MouseEnter

                panelA.Controls.Add(elemImg)
                ms.Dispose()

            Else
                If (estado = 1) Then
                    If (File.Exists(RutaGlobal + "\Imagenes\Imagenes RecepcionVehiculo\" + "Recepcion_" + tbNumeroOrden.Text.Trim + rutImg)) Then
                        Dim bm As Bitmap = New Bitmap(RutaGlobal + "\Imagenes\Imagenes RecepcionVehiculo\" + "Recepcion_" + tbNumeroOrden.Text + rutImg)
                        elemImg.pbImg.SizeMode = PictureBoxSizeMode.StretchImage
                        elemImg.pbImg.Image = bm
                        pbImgProdu.SizeMode = PictureBoxSizeMode.StretchImage
                        pbImgProdu.Image = bm
                        elemImg.pbImg.Tag = i
                        elemImg.Dock = DockStyle.Top
                        pbImgProdu.Tag = i
                        AddHandler elemImg.pbImg.MouseEnter, AddressOf pbImg_MouseEnter

                        panelA.Controls.Add(elemImg)
                    End If

                End If
            End If




            i += 1
        Next

    End Sub
    Private Sub pbImg_MouseEnter(sender As Object, e As EventArgs)
        Dim pb As PictureBox = CType(sender, PictureBox)
        pbImgProdu.Image = pb.Image
        pbImgProdu.Tag = pb.Tag

    End Sub

    Private Function _fnCopiarImagenRutaDefinida() As String
        'copio la imagen en la carpeta del sistema

        Dim file As New OpenFileDialog()
        'file.InitialDirectory = gs_RutaImg
        file.Filter = "Ficheros JPG o JPEG o PNG|*.jpg;*.jpeg;*.png" & _
                      "|Ficheros GIF|*.gif" & _
                      "|Ficheros BMP|*.bmp" & _
                      "|Ficheros PNG|*.png" & _
                      "|Ficheros TIFF|*.tif"
        If file.ShowDialog() = DialogResult.OK Then
            Dim ruta As String = file.FileName
            Dim nombre As String = ""

            If file.CheckFileExists = True Then
                Dim img As New Bitmap(New Bitmap(ruta), 1000, 800)
                Dim a As Object = file.GetType.ToString

                Dim da As String = Str(Now.Day).Trim + Str(Now.Month).Trim + Str(Now.Year).Trim + Str(Now.Hour) + Str(Now.Minute) + Str(Now.Second)

                nombre = "\Imagen_" + da + ".jpg".Trim


                If (_fnActionNuevo()) Then
                    Dim mstream = New MemoryStream()

                    img.Save(mstream, System.Drawing.Imaging.ImageFormat.Jpeg)

                    TablaImagenes.Rows.Add(0, 0, nombre, mstream.ToArray(), 0)
                    mstream.Dispose()
                    img.Dispose()

                Else
                    Dim mstream = New MemoryStream()

                    img.Save(mstream, System.Drawing.Imaging.ImageFormat.Jpeg)
                    TablaImagenes.Rows.Add(0, tbNumeroOrden.Text, nombre, mstream.ToArray(), 0)
                    mstream.Dispose()

                End If

                'img.Save(RutaTemporal + nombre, System.Drawing.Imaging.ImageFormat.Jpeg)




            End If
            Return nombre
        End If

        Return "default.jpg"
    End Function

    Public Sub _prGuardarImagenes(_ruta As String)
        panelA.Controls.Clear()


        For i As Integer = 0 To TablaImagenes.Rows.Count - 1 Step 1
            Dim estado As Integer = TablaImagenes.Rows(i).Item("estado")
            If (estado = 0) Then

                Dim bm As Bitmap = Nothing
                Dim by As Byte() = TablaImagenes.Rows(i).Item("img")
                Dim ms As New MemoryStream(by)
                bm = New Bitmap(ms)
                Try
                    bm.Save(_ruta + TablaImagenes.Rows(i).Item("lhima"), System.Drawing.Imaging.ImageFormat.Jpeg)
                Catch ex As Exception

                End Try




            End If
            If (estado = -1) Then
                Try
                    Me.pbImgProdu.Image.Dispose()
                    Me.pbImgProdu.Image = Nothing
                    Application.DoEvents()
                    TablaImagenes.Rows(i).Item("img") = Nothing



                    If (File.Exists(_ruta + TablaImagenes.Rows(i).Item("lhima"))) Then
                        My.Computer.FileSystem.DeleteFile(_ruta + TablaImagenes.Rows(i).Item("lhima"))
                    End If

                Catch ex As Exception

                End Try
            End If
        Next
    End Sub
    Private Sub _prSalir()
        If btnGrabar.Enabled = True Then
            _prInhabilitar()
            If grControl.RowCount > 0 Then

                _prMostrarRegistro(0)

            End If
        Else

            Me.Close()
            '_tab.Close()

        End If
    End Sub
    Public Sub _prLimpiar()
        grAyuda.RootTable.RemoveFilter()
        swestado.IsReadOnly = False
        tbNumeroOrden.Clear()
        tbplaca.Clear()
        tbCliente.Clear()
        tbnumiCliente.Text = 0
        tbnumiVehiculo.Text = 0
        tbMarca.Clear()

        If (CType(cbTamano.DataSource, DataTable).Rows.Count > 0) Then
            cbTamano.SelectedIndex = 0
        Else
            cbTamano.SelectedIndex = -1
        End If
        If (CType(cbTipoVehiculo.DataSource, DataTable).Rows.Count > 0) Then
            cbTipoVehiculo.SelectedIndex = 0
        Else
            cbTipoVehiculo.SelectedIndex = -1
        End If


        tbFecha.Value = Now.Date
        tbObservacion.Clear()
        tbClienteSocio.Value = True



        TablaImagenes = L_prCargarImagenesRecepcion(-1)
        TablaInventario = L_prCargarInventarioRecepcion(-1)

        _prMarcarCheck()
        _prCargarImagen()

        tbplaca.Focus()
        _prEliminarContenidoImage()
        _prCargarGridServicios(-1)
    End Sub
    Public Function _fnNuevo()
        Return tbNumeroOrden.Text = String.Empty
    End Function
    Public Sub _prMarcarCheck()
        '        lgnumi, lgnumitc6, lglin, descripcion, estado
        '0	        0	     1	    LLanta de Auxilio	  0
        '0	        0	     2	    Manivela de Gata	  0
        '0        	0	     3	    Sobrepisos	          0
        For i As Integer = 0 To TablaInventario.Rows.Count - 1 Step 1
            Dim estado As Integer = TablaInventario.Rows(i).Item("estado")
            Dim numi As Integer = TablaInventario.Rows(i).Item("lglin")
            Dim cboxName As String
            Dim cbox As DevComponents.DotNetBar.Controls.CheckBoxX
            If (_fnNuevo()) Then
                If (estado = 0) Then
                    cboxName = "cb" + Str(numi).Trim
                    'cbox = CType(cboxName, Object)
                    'cbox.Checked = False
                    Dim ctrl As Control = FindControl(Me, cboxName)
                    If ctrl IsNot Nothing Then
                        cbox = CType(ctrl, DevComponents.DotNetBar.Controls.CheckBoxX)
                        cbox.Checked = True
                    End If

                End If
            Else
                If (estado = 1) Then
                    cboxName = "cb" + Str(numi).Trim
                    'cbox = CType(cboxName, Object)
                    'cbox.Checked = False
                    Dim ctrl As Control = FindControl(Me, cboxName)
                    If ctrl IsNot Nothing Then
                        cbox = CType(ctrl, DevComponents.DotNetBar.Controls.CheckBoxX)
                        cbox.Checked = True
                        cbox.Enabled = False
                    End If
                    cboxName = "cbb" + Str(numi).Trim
                    'cbox = CType(cboxName, Object)
                    'cbox.Checked = False
                    Dim ctrl2 As Control = FindControl(Me, cboxName)
                    If ctrl2 IsNot Nothing Then
                        cbox = CType(ctrl2, DevComponents.DotNetBar.Controls.CheckBoxX)

                        cbox.Enabled = False
                    End If
                End If
                If (estado = 0) Then

                    cboxName = "cbb" + Str(numi).Trim
                    'cbox = CType(cboxName, Object)
                    'cbox.Checked = False
                    Dim ctrl As Control = FindControl(Me, cboxName)
                    If ctrl IsNot Nothing Then
                        cbox = CType(ctrl, DevComponents.DotNetBar.Controls.CheckBoxX)
                        cbox.Checked = True
                        cbox.Enabled = False
                    End If
                    cboxName = "cb" + Str(numi).Trim
                    'cbox = CType(cboxName, Object)
                    'cbox.Checked = False
                    Dim ctrl2 As Control = FindControl(Me, cboxName)
                    If ctrl2 IsNot Nothing Then
                        cbox = CType(ctrl2, DevComponents.DotNetBar.Controls.CheckBoxX)

                        cbox.Enabled = False
                    End If
                    TablaInventario.Rows(i).Item("estado") = -2

                End If
            End If

        Next
    End Sub

    Public Sub _prMostrarRegistro(_N As Integer)
        '         a.lfnumi ,a.lftcl1soc,cliente.lanom as nombre ,a.lffecha ,a.lfcl1veh,
        'vehiculo.lbplac as placa,vehiculo .lbtip1_4 ,MarcaCliente .cedesc1 ,a.lfcomb ,a.lfobs ,
        'a.lftipo ,a.lftam ,a.lffact ,a.lfhact ,a.lfuact 
        If (grControl.RowCount <= 0) Then
            Return
        End If
        Dim dt As DataTable = CType(grControl.DataSource, DataTable)
        With grControl
            tbNumeroOrden.Text = .GetValue("lfnumi")
            tbnumiCliente.Text = .GetValue("lftcl1soc")
            tbFecha.Value = .GetValue("lffecha")
            swestado.Value = .GetValue("lfest")
            tbCliente.Text = .GetValue("nombre")
            tbnumiVehiculo.Text = .GetValue("lfcl1veh")
            tbplaca.Text = .GetValue("placa")
            tbObservacion.Text = .GetValue("lfobs")
            cbTipoVehiculo.Value = .GetValue("lftipo")
            cbTamano.Value = .GetValue("lftam")
            lbFecha.Text = CType(.GetValue("lffact"), Date).ToString("dd/MM/yyyy")
            lbHora.Text = .GetValue("lfhact").ToString
            lbUsuario.Text = .GetValue("lfuact").ToString
            tbMarca.Text = .GetValue("cedesc1").ToString
            Dim nsocio As Integer = IIf(IsDBNull(.GetValue("lansoc")), 0, .GetValue("lansoc"))
            If (nsocio > 0) Then
                tbClienteSocio.Value = False
            Else
                tbClienteSocio.Value = True
            End If
        End With
        TablaImagenes = L_prCargarImagenesRecepcion(tbNumeroOrden.Text)
        TablaInventario = L_prCargarInventarioRecepcion(tbNumeroOrden.Text)
        _prMarcarCheck()
        _prCargarImagen()
        _prCargarGridServicios(tbNumeroOrden.Text)
        LblPaginacion.Text = Str(grControl.Row + 1) + "/" + grControl.RowCount.ToString

    End Sub
    Public Sub _prLeerTextCheck()
        Dim dt As DataTable = L_prObtenerTiposVehiculos()

        For i As Integer = 0 To dt.Rows.Count - 1 Step 1
            Dim cboxName As String
            Dim cbox As DevComponents.DotNetBar.LabelX
            cboxName = "lb" + Str(i + 1).Trim
            'cbox = CType(cboxName, Object)
            'cbox.Checked = False
            Dim ctrl As Control = FindControl(Me, cboxName)
            If ctrl IsNot Nothing Then
                cbox = CType(ctrl, DevComponents.DotNetBar.LabelX)
                cbox.Text = dt.Rows(i).Item("cgdes")

            End If
        Next

    End Sub
    Private Function FindControl(ByVal ContainerControl As Control, ByVal Name As String) As Control
        Dim ReturnValue As Control = Nothing
        Dim FoundControls As Control() = ContainerControl.Controls.Find(Name, True)
        If FoundControls.Length > 0 Then
            ReturnValue = FoundControls(0)
        End If
        Return ReturnValue
    End Function
    Public Sub _prMesajeImprimi(Codigo As Integer)
        Dim info As New TaskDialogInfo("advertencia".ToUpper, eTaskDialogIcon.Delete, "¿desea continuar?".ToUpper, "DESEA IMPRIMIR REPORTE DE ESTA VENTA REGISTRADA".ToUpper, eTaskDialogButton.Yes Or eTaskDialogButton.No, eTaskDialogBackgroundColor.Blue)
        Dim result As eTaskDialogResult = TaskDialog.Show(info)
        If result = eTaskDialogResult.Yes Then
            _prGenerarReporte(Codigo)
        Else



        End If
    End Sub
    Public Sub _GuardarNuevo()

        '      @lfnumi,@lftc1soc ,@lffecha ,@lftcl1veh ,
        '@lfcomb ,@lfobs ,@lftipo ,@lftam ,@newFecha ,@newHora ,@lfuact
        ''_tablaInventario,_tablaImagenes
        Dim numi As String = ""
        Dim res As Boolean = L_prRecepcionVehiculoGrabar02(numi, tbnumiCliente.Text, tbFecha.Value.ToString("yyyy/MM/dd"), tbnumiVehiculo.Text,
                                                         tbObservacion.Text, cbTipoVehiculo.Value, cbTamano.Value, TablaInventario, TablaImagenes, CType(grServicios.DataSource, DataTable), IIf(swestado.Value = True, 1, 0))
        If res Then


            _prCrearCarpetaImagenes("Recepcion_" + numi.Trim)
            _prGuardarImagenes(RutaGlobal + "\Imagenes\Imagenes RecepcionVehiculo\" + "Recepcion_" + numi.Trim + "\")

            Dim img As Bitmap = New Bitmap(My.Resources.checked, 50, 50)
            ToastNotification.Show(Me, "Código de CONTROL DE RECEPCION ".ToUpper + tbNumeroOrden.Text + " Grabado con Exito.".ToUpper,
                                      img, 2000,
                                      eToastGlowColor.Green,
                                      eToastPosition.TopCenter
                                      )
            _prMesajeImprimi(numi)
            _prCargarGridGeneralControl()
            _prLimpiar()


        Else
            Dim img As Bitmap = New Bitmap(My.Resources.cancel, 50, 50)
            ToastNotification.Show(Me, "El Control de recepcion no pudo ser insertado".ToUpper, img, 2000, eToastGlowColor.Red, eToastPosition.BottomCenter)

        End If
        _prEliminarContenidoImage()
    End Sub

    Private Sub _prGuardarModificado()
        Dim res As Boolean = L_prRecepcionVehiculoModificar02(tbNumeroOrden.Text, tbnumiCliente.Text, tbFecha.Value.ToString("yyyy/MM/dd"), tbnumiVehiculo.Text,
                                                        tbObservacion.Text, cbTipoVehiculo.Value, cbTamano.Value, TablaInventario, TablaImagenes, CType(grServicios.DataSource, DataTable), IIf(swestado.Value = True, 1, 0))
        If res Then
            _prCrearCarpetaImagenes("Recepcion_" + tbNumeroOrden.Text.Trim)
            _prGuardarImagenes(RutaGlobal + "\Imagenes\Imagenes RecepcionVehiculo\" + "Recepcion_" + tbNumeroOrden.Text.Trim + "\")
            Dim img As Bitmap = New Bitmap(My.Resources.checked, 50, 50)
            ToastNotification.Show(Me, "Código de Compra ".ToUpper + tbNumeroOrden.Text + " Modificado con Exito.".ToUpper,
                                      img, 2000,
                                      eToastGlowColor.Green,
                                      eToastPosition.TopCenter
                                      )
            _prMesajeImprimi(tbNumeroOrden.Text)
            _prCargarGridGeneralControl()

            _prSalir()


        Else
            Dim img As Bitmap = New Bitmap(My.Resources.cancel, 50, 50)
            ToastNotification.Show(Me, "La Compra no pudo ser Modificada".ToUpper, img, 2000, eToastGlowColor.Red, eToastPosition.BottomCenter)

        End If
        _prEliminarContenidoImage()
    End Sub
#End Region

    Private Sub grAyuda_DoubleClick(sender As Object, e As EventArgs) Handles grAyuda.DoubleClick
        If (grAyuda.RowCount > 0) Then
            tbCliente.Text = grAyuda.GetValue("nombre")
            tbnumiCliente.Text = grAyuda.GetValue("lanumi")
            tbnumiVehiculo.Text = grAyuda.GetValue("lblin")
            tbplaca.Text = grAyuda.GetValue("lbplac")
            tbMarca.Text = grAyuda.GetValue("marca")
            Dim tipo As Object = grAyuda.GetValue("lbtip1_4")

            If (IsDBNull(tipo)) Then
                cbTamano.SelectedIndex = -1

            Else
                If (tipo > 0) Then
                    cbTamano.Value = tipo
                Else
                    cbTamano.SelectedIndex = -1

                End If

            End If

            Dim nsoc As Integer = grAyuda.GetValue("lansoc")
            If (nsoc > 0) Then
                tbClienteSocio.Value = False
            Else
                tbClienteSocio.Value = True
            End If

            Dim TipoRegistrado As Integer = grAyuda.GetValue("VehiculoRegistrado")
            If (TipoRegistrado > 0) Then
                cbTamano.ReadOnly = True
                cbTipoVehiculo.ReadOnly = True
                btnTamanoVehiculo.Visible = False
                btnTipoVehiculo.Visible = False
                cbTipoVehiculo.Value = TipoRegistrado
            Else
                cbTamano.ReadOnly = False
                cbTipoVehiculo.ReadOnly = False
                btnTamanoVehiculo.Visible = True
                btnTipoVehiculo.Visible = True
            End If


        End If

    End Sub
    Public Function _fnActionNuevo() As Boolean
        Return tbNumeroOrden.Text = String.Empty

    End Function

    Private Sub tbplaca_TextChanged(sender As Object, e As EventArgs) Handles tbplaca.TextChanged
        If (_fnActionNuevo() Or tbplaca.ReadOnly = False) Then
            If (tbplaca.Text = String.Empty) Then
                tbCliente.Text = ""
                tbnumiCliente.Text = 0
                tbnumiVehiculo.Text = 0
                cbTamano.SelectedIndex = -1
                tbClienteSocio.Value = True
                tbplaca.Clear()
            Else
                If (Not IsNothing(grAyuda.DataSource)) Then
                    grAyuda.RootTable.ApplyFilter(New Janus.Windows.GridEX.GridEXFilterCondition(grAyuda.RootTable.Columns("lbplac"), Janus.Windows.GridEX.ConditionOperator.Contains, tbplaca.Text))

                End If

            End If
        End If
    End Sub

    Private Sub ButtonX1_Click(sender As Object, e As EventArgs) Handles btnSeleccionar.Click
        If (tbplaca.Text <> String.Empty) Then

            If (grAyuda.RowCount > 0) Then
                grAyuda.Row = 0

                tbCliente.Text = grAyuda.GetValue("nombre")
                tbnumiCliente.Text = grAyuda.GetValue("lanumi")
                tbnumiVehiculo.Text = grAyuda.GetValue("lblin")
                tbplaca.Text = grAyuda.GetValue("lbplac")
                Dim tipo As Object = grAyuda.GetValue("lbtip1_4")
                tbMarca.Text = grAyuda.GetValue("marca")
                Dim TipoRegistrado As Integer = grAyuda.GetValue("VehiculoRegistrado")
                If (TipoRegistrado > 0) Then
                    'cbTamano.ReadOnly = True
                    cbTipoVehiculo.ReadOnly = True
                    'btnTamanoVehiculo.Visible = False
                    btnTipoVehiculo.Visible = False
                    cbTipoVehiculo.Value = TipoRegistrado
                Else
                    cbTamano.ReadOnly = False
                    cbTipoVehiculo.ReadOnly = False
                    btnTamanoVehiculo.Visible = True
                    btnTipoVehiculo.Visible = True
                End If
                If (IsDBNull(tipo)) Then
                    cbTamano.SelectedIndex = -1

                Else
                    If (tipo > 0) Then
                        cbTamano.Value = tipo
                    Else
                        cbTamano.SelectedIndex = -1

                    End If
                End If

                Dim nsoc As Integer = grAyuda.GetValue("lansoc")
                If (nsoc > 0) Then

                    tbClienteSocio.Value = False
                Else 'Si el socio no hizo ningun pago

                    tbClienteSocio.Value = True
                End If
            Else

            End If

            ''Aqui
        End If
    End Sub

    Private Sub F0_NControlLavadero_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _IniciarTodo()
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        _prLimpiar()
        _prHabilitar()
        btnNuevo.Enabled = False
        btnModificar.Enabled = False
        btnEliminar.Enabled = False
        btnGrabar.Enabled = True
        PanelNavegacion.Enabled = False
    End Sub

    Private Sub btnImagen_Click(sender As Object, e As EventArgs) Handles btnImagen.Click
        _fnCopiarImagenRutaDefinida()
        _prCargarImagen()
    End Sub
    Private Sub ButtonX2_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim pos As Integer = CType(pbImgProdu.Tag, Integer)
        If (IsDBNull(TablaImagenes)) Then
            Return

        End If
        If (pos >= 0 And TablaImagenes.Rows.Count > 0) Then
            TablaImagenes.Rows(pos).Item("estado") = -1
            _prCargarImagen()
        End If
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        _prSalir()
    End Sub

    Public Function ObtenerCantidadSelecionadosServicio() As Integer
        Dim cont As Integer = 0

        For i As Integer = 0 To CType(grServicios.DataSource, DataTable).Rows.Count - 1 Step 1
            Dim estado As Integer = CType(grServicios.DataSource, DataTable).Rows(i).Item("estado")
            If (estado = True) Then
                cont += 1

            End If
        Next
        Return cont
    End Function
    Public Function _ValidarCampos() As Boolean
        If (tbnumiCliente.Text <= 0) Then
            Dim img As Bitmap = New Bitmap(My.Resources.Mensaje, 50, 50)
            ToastNotification.Show(Me, "Seleccione un Vehiculo".ToUpper, img, 2000, eToastGlowColor.Red, eToastPosition.BottomCenter)
            tbplaca.Focus()
            Return False

        End If
        If (ObtenerCantidadSelecionadosServicio() <= 0) Then
            Dim img As Bitmap = New Bitmap(My.Resources.Mensaje, 50, 50)
            ToastNotification.Show(Me, "Por Favor Seleccione Al Menos un Servicio".ToUpper, img, 2000, eToastGlowColor.Red, eToastPosition.BottomCenter)
            grServicios.Select()

            Return False
        End If
        If (tbnumiVehiculo.Text <= 0) Then
            Dim img As Bitmap = New Bitmap(My.Resources.Mensaje, 50, 50)
            ToastNotification.Show(Me, "Seleccione un Vehiculo".ToUpper, img, 2000, eToastGlowColor.Red, eToastPosition.BottomCenter)
            tbplaca.Focus()
            Return False

        End If


        If (cbTamano.SelectedIndex < 0) Then


            Dim img As Bitmap = New Bitmap(My.Resources.Mensaje, 50, 50)
            ToastNotification.Show(Me, "Por Favor Seleccione una Tamaño".ToUpper, img, 2000, eToastGlowColor.Red, eToastPosition.BottomCenter)
            cbTamano.Focus()
            Return False


        End If
        Return True
    End Function
    Public Sub _prInterpretarDatos()
        '        lgnumi, lgnumitc6, lglin, descripcion, estado
        '0	        0	     1	    LLanta de Auxilio	  0
        '0	        0	     2	    Manivela de Gata	  0
        '0        	0	     3	    Sobrepisos	          0

        For i As Integer = 0 To TablaInventario.Rows.Count - 1 Step 1
            Dim estado As Integer = TablaInventario.Rows(i).Item("estado")
            Dim numi As Integer = TablaInventario.Rows(i).Item("lglin")
            Dim cboxName As String
            Dim cbox As DevComponents.DotNetBar.Controls.CheckBoxX
            If (_fnNuevo()) Then
                cboxName = "cb" + Str(numi).Trim
                Dim ctrl As Control = FindControl(Me, cboxName)
                If ctrl IsNot Nothing Then
                    cbox = CType(ctrl, DevComponents.DotNetBar.Controls.CheckBoxX)
                    If (cbox.Checked) Then
                        TablaInventario.Rows(i).Item("estado") = 0
                    Else
                        TablaInventario.Rows(i).Item("estado") = -2
                    End If
                End If

            Else

                cboxName = "cb" + Str(numi).Trim
                'cbox = CType(cboxName, Object)
                'cbox.Checked = False
                Dim ctrl As Control = FindControl(Me, cboxName)
                If ctrl IsNot Nothing Then
                    cbox = CType(ctrl, DevComponents.DotNetBar.Controls.CheckBoxX)
                    If (cbox.Checked) Then

                        If (estado < 0) Then
                            TablaInventario.Rows(i).Item("estado") = 0

                        End If
                    Else
                        If (estado = 1) Then
                            TablaInventario.Rows(i).Item("estado") = -1
                        End If
                    End If
                End If


            End If

        Next


    End Sub
    Private Sub btnGrabar_Click(sender As Object, e As EventArgs) Handles btnGrabar.Click
        If _ValidarCampos() = False Then
            Exit Sub
        End If
        _prInterpretarDatos()

        If (tbNumeroOrden.Text = String.Empty) Then
            _GuardarNuevo()
            _prHabilitarCheck()
        Else
            If (tbNumeroOrden.Text <> String.Empty) Then
                _prGuardarModificado()
                _prInhabilitar()

            End If
        End If
        _prCargarGridAyudaPlacaCLiente()

    End Sub
    Public Sub _prEliminarDirectorio(numi As String)

        '_prGuardarImagenes(RutaGlobal + "\Imagenes\Imagenes RecepcionVehiculo\" + "Recepcion_" + tbNumeroOrden.Text.Trim + "\")
        If (File.Exists(RutaGlobal + "\Imagenes\Imagenes RecepcionVehiculo\Recepcion_" + numi)) Then

            Try
                My.Computer.FileSystem.DeleteDirectory(RutaGlobal + "\Imagenes\Imagenes RecepcionVehiculo\Recepcion_" + numi, FileIO.UIOption.AllDialogs, FileIO.RecycleOption.SendToRecycleBin)
            Catch ex As Exception

            End Try


        End If


    End Sub
    Public Sub _EliminarRegistro()
        Dim info As New TaskDialogInfo("¿esta seguro de eliminar el registro?".ToUpper, eTaskDialogIcon.Delete, "advertencia".ToUpper, "mensaje principal".ToUpper, eTaskDialogButton.Yes Or eTaskDialogButton.Cancel, eTaskDialogBackgroundColor.Blue)
        Dim result As eTaskDialogResult = TaskDialog.Show(info)
        If result = eTaskDialogResult.Yes Then
            Dim mensajeError As String = ""
            Dim res As Boolean = L_prRecepcionVehiculoBorrar(tbNumeroOrden.Text, mensajeError)
            If res Then
                ToastNotification.Show(Me, "Codigo de control de inventario ".ToUpper + tbNumeroOrden.Text + " eliminado con Exito.".ToUpper, My.Resources.GRABACION_EXITOSA, 5000, eToastGlowColor.Green, eToastPosition.TopCenter)
                _prEliminarDirectorio(tbNumeroOrden.Text.Trim)
                _prFiltrar()
            Else
                ToastNotification.Show(Me, mensajeError, My.Resources.WARNING, 8000, eToastGlowColor.Red, eToastPosition.TopCenter)
            End If
        End If
    End Sub

    Public Sub _prFiltrar()
        'cargo el buscador
        Dim _Mpos As Integer
        _prCargarGridGeneralControl()
        If grControl.RowCount > 0 Then
            _Mpos = 0
            grControl.Row = _Mpos
        Else
            _prLimpiar()

            LblPaginacion.Text = "0/0"
        End If
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        _EliminarRegistro()
    End Sub

    Private Sub btnUltimo_Click(sender As Object, e As EventArgs) Handles btnUltimo.Click
        Dim _pos As Integer = grControl.Row
        If grControl.RowCount > 0 Then
            _pos = grControl.RowCount - 1
            ''  _prMostrarRegistro(_pos)
            grControl.Row = _pos
        End If
    End Sub

    Private Sub btnSiguiente_Click(sender As Object, e As EventArgs) Handles btnSiguiente.Click
        Dim _pos As Integer = grControl.Row
        If _pos < grControl.RowCount - 1 Then
            _pos = grControl.Row + 1
            '' _prMostrarRegistro(_pos)
            grControl.Row = _pos
        End If
    End Sub

    Private Sub btnAnterior_Click(sender As Object, e As EventArgs) Handles btnAnterior.Click
        Dim _MPos As Integer = grControl.Row
        If _MPos > 0 And grControl.RowCount > 0 Then
            _MPos = _MPos - 1
            ''  _prMostrarRegistro(_MPos)
            grControl.Row = _MPos
        End If
    End Sub
    Public Sub _PrimerRegistro()
        Dim _MPos As Integer
        If grControl.RowCount > 0 Then
            _MPos = 0
            ''   _prMostrarRegistro(_MPos)
            grControl.Row = _MPos
        End If
    End Sub
    Private Sub btnPrimero_Click(sender As Object, e As EventArgs) Handles btnPrimero.Click
        _PrimerRegistro()
    End Sub

    Private Sub grControl_SelectionChanged(sender As Object, e As EventArgs) Handles grControl.SelectionChanged
        If (grControl.RowCount >= 0 And grControl.Row >= 0) Then

            _prMostrarRegistro(grControl.Row)
        End If
    End Sub

    Private Sub grControl_KeyDown(sender As Object, e As KeyEventArgs) Handles grControl.KeyDown

        If (_fnAccesible()) Then
            Return
        End If
        If e.KeyData = Keys.Enter Then


            SuperTabControl1.SelectedTabIndex = 0

        End If

    End Sub

    Public Function _fnAccesible() As Boolean
        Return tbObservacion.ReadOnly = False
    End Function
    Private Sub grControl_DoubleClick(sender As Object, e As EventArgs) Handles grControl.DoubleClick
        If (Not _fnAccesible()) Then
            SuperTabControl1.SelectedTabIndex = 0
        End If

    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        If (grControl.RowCount > 0) Then
            _prHabilitar()
            btnNuevo.Enabled = False
            btnModificar.Enabled = False
            btnEliminar.Enabled = False
            btnGrabar.Enabled = True

            PanelNavegacion.Enabled = False
            btnAnadir.Visible = False
            'btnTamanoVehiculo.Visible = False
            btnTipoVehiculo.Visible = False
            cbTipoVehiculo.ReadOnly = True
            cbTamano.ReadOnly = False

        End If
    End Sub
    Public Sub _prHabilitarCheck()
        '        lgnumi, lgnumitc6, lglin, descripcion, estado
        '0	        0	     1	    LLanta de Auxilio	  0
        '0	        0	     2	    Manivela de Gata	  0
        '0        	0	     3	    Sobrepisos	          0
        For i As Integer = 0 To TablaInventario.Rows.Count - 1 Step 1
            Dim estado As Integer = TablaInventario.Rows(i).Item("estado")
            Dim numi As Integer = TablaInventario.Rows(i).Item("lglin")
            Dim cboxName As String
            Dim cbox As DevComponents.DotNetBar.Controls.CheckBoxX

            cboxName = "cb" + Str(numi).Trim
            'cbox = CType(cboxName, Object)
            'cbox.Checked = False
            Dim ctrl As Control = FindControl(Me, cboxName)
            If ctrl IsNot Nothing Then
                cbox = CType(ctrl, DevComponents.DotNetBar.Controls.CheckBoxX)

                cbox.Enabled = True
            End If
            cboxName = "cbb" + Str(numi).Trim
            'cbox = CType(cboxName, Object)
            'cbox.Checked = False
            Dim ctrl2 As Control = FindControl(Me, cboxName)
            If ctrl2 IsNot Nothing Then
                cbox = CType(ctrl2, DevComponents.DotNetBar.Controls.CheckBoxX)
                cbox.Enabled = True
            End If

        Next
    End Sub

    Private Sub btnTamanoVehiculo_Click(sender As Object, e As EventArgs) Handles btnTamanoVehiculo.Click
        Dim frmAyuda As Efecto = New Efecto
        frmAyuda.tipo = 1

        frmAyuda.ShowDialog()
        Dim posicionData As Integer = -1
        posicionData = frmAyuda.PosicionData
        If (posicionData >= 0) Then
            cbTamano.SelectedIndex = posicionData

        End If
    End Sub

    Private Sub btnTipoVehiculo_Click(sender As Object, e As EventArgs) Handles btnTipoVehiculo.Click
        Dim frmAyuda As Efecto = New Efecto
        frmAyuda.tipo = 2

        frmAyuda.ShowDialog()
        Dim posicionData As Integer = -1
        posicionData = frmAyuda.PosicionData
        If (posicionData >= 0) Then
            cbTipoVehiculo.SelectedIndex = posicionData

        End If
    End Sub

    Private Sub btnAnadir_Click(sender As Object, e As EventArgs) Handles btnAnadir.Click
        Dim frm As New F_ClienteNuevoServicoTablet
        Dim dt As DataTable
        frm.placaV = tbplaca.Text
        frm.ShowDialog()
        Dim placa As String = frm.placaV

        If (frm.Cliente = True) Then ''Aqui Consulto si se inserto un nuevo Cliente cargo sus datos del nuevo cliente insertado

            dt = L_prServicioVentaAyudaVehiculo(placa)
            If (dt.Rows.Count > 0) Then
                tbCliente.Text = dt.Rows(0).Item("nombre")
                tbnumiCliente.Text = dt.Rows(0).Item("lanumi")
                tbnumiVehiculo.Text = dt.Rows(0).Item("lblin")
                tbplaca.Text = placa
                cbTamano.Value = dt.Rows(0).Item("lbtip1_4")
                tbMarca.Text = dt.Rows(0).Item("marca")

                tbClienteSocio.Value = True
                _prCargarGridAyudaPlacaCLiente()




            End If
        End If
    End Sub

    Private Sub btnCamara_Click(sender As Object, e As EventArgs) Handles btnCamara.Click
        'System.Diagnostics.Process.Start(gs_DirPrograma)
    End Sub
    Sub _prGenerarReporte(numi As String)
        Dim dt = L_prObtenerDatosReporteNOrden(numi)
        If (dt.Rows.Count > 0) Then
            Dim inventario As DataTable = L_prObtenerDatosReporteNOrdenInv(numi)
            For i As Integer = 0 To inventario.Rows.Count - 1 Step 1
                dt.Rows(0).Item("re" + Str(i + 1).Trim) = inventario.Rows(i).Item("cgdes")
            Next
            _prImprimir(dt)
        End If
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        _prGenerarReporte(tbNumeroOrden.Text)
    End Sub
    Private Sub _prImprimir(_dt As DataTable)
        Dim objrep As New R_Recepcion
        'imprimir
        If PrintDialog1.ShowDialog = DialogResult.OK Then
            objrep.SetDataSource(_dt)
            objrep.PrintOptions.PrinterName = PrintDialog1.PrinterSettings.PrinterName
            objrep.PrintToPrinter(1, False, 1, 10)
        End If
    End Sub
    Public Function _fnVisualizarRegistros() As Boolean
        Return tbplaca.ReadOnly = True
    End Function

    Private Sub grServicios_EditingCell(sender As Object, e As EditingCellEventArgs) Handles grServicios.EditingCell
        If (Not _fnVisualizarRegistros()) Then
            'Habilitar solo las columnas de Precio, %, Monto y Observación
            If (e.Column.Index = grServicios.RootTable.Columns("estado").Index) Then
                e.Cancel = False
            Else
                e.Cancel = True
            End If
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub SwitchButton1_ValueChanged(sender As Object, e As EventArgs) Handles swestado.ValueChanged
        'If (btnAnadir.Visible = True) Then
        '    Return
        'End If
        'Dim info As New TaskDialogInfo("¿esta seguro de cambiar el estado? ".ToUpper, eTaskDialogIcon.Delete, "advertencia".ToUpper, "mensaje principal".ToUpper, eTaskDialogButton.Yes Or eTaskDialogButton.Cancel, eTaskDialogBackgroundColor.Blue)
        'Dim result As eTaskDialogResult = TaskDialog.Show(info)
        'If result = eTaskDialogResult.Yes Then
        '    Dim res As Boolean = L_prRecepcionVehiculoModificarEstado(tbNumeroOrden.Text, IIf(swestado.Value = True, 1, 0))
        '    If res Then
        '        ToastNotification.Show(Me, "El Estado de Control con nro de orden:  ".ToUpper + tbNumeroOrden.Text + " ha sido modificado con exito.".ToUpper, My.Resources.GRABACION_EXITOSA, 5000, eToastGlowColor.Green, eToastPosition.TopCenter)
        '        _prCargarGridGeneralControl()

        '    Else
        '        ToastNotification.Show(Me, "No Pudo modificarse".ToUpper, My.Resources.WARNING, 8000, eToastGlowColor.Red, eToastPosition.TopCenter)
        '    End If

        'End If
    End Sub
End Class