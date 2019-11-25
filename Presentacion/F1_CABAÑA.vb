Imports Logica.AccesoLogica
Imports DevComponents.DotNetBar
Imports System.IO
Imports System.Drawing.Imaging
Imports Janus.Windows.GridEX

Public Class F1_CABAÑA

#Region "Variables Locales"
    Dim Imagenes As DataTable = New DataTable
    Dim TablaImagenes As DataTable = New DataTable
    Dim RutaGlobal As String = gs_CarpetaRaiz
    Dim RutaTemporal As String = "C:\Temporal"
    Dim PosicionImagen As Integer = 0
    Public _nameButton As String

#End Region
#Region "Metodos Privados"
#Region "Carpeta Imagenes"

    Private Sub _prCrearCarpetaImagenes(carpetaFinal As String)
        Dim rutaDestino As String = RutaGlobal + "\Imagenes\Imagenes Cabaña\" + carpetaFinal + "\"

        If System.IO.Directory.Exists(RutaGlobal + "\Imagenes\Imagenes Cabaña\" + carpetaFinal) = False Then
            If System.IO.Directory.Exists(RutaGlobal + "\Imagenes") = False Then
                System.IO.Directory.CreateDirectory(RutaGlobal + "\Imagenes")
                If System.IO.Directory.Exists(RutaGlobal + "\Imagenes\Imagenes Cabaña") = False Then
                    System.IO.Directory.CreateDirectory(RutaGlobal + "\Imagenes\Imagenes Cabaña")
                    System.IO.Directory.CreateDirectory(RutaGlobal + "\Imagenes\Imagenes Cabaña\" + carpetaFinal + "\")
                End If
            Else
                If System.IO.Directory.Exists(RutaGlobal + "\Imagenes\Imagenes Cabaña") = False Then
                    System.IO.Directory.CreateDirectory(RutaGlobal + "\Imagenes\Imagenes Cabaña")
                    System.IO.Directory.CreateDirectory(RutaGlobal + "\Imagenes\Imagenes Cabaña\" + carpetaFinal + "\")
                Else
                    If System.IO.Directory.Exists(RutaGlobal + "\Imagenes\Imagenes Imagenes Cabaña\" + carpetaFinal) = False Then
                        System.IO.Directory.CreateDirectory(RutaGlobal + "\Imagenes\Imagenes Cabaña\" + carpetaFinal + "\")
                    End If

                End If
            End If
        End If
    End Sub

    Private Sub _prCrearCarpetaTemporal()

        If System.IO.Directory.Exists(RutaTemporal) = False Then
            System.IO.Directory.CreateDirectory(RutaTemporal)
        Else
            Try
                My.Computer.FileSystem.DeleteDirectory(RutaTemporal, FileIO.DeleteDirectoryOption.DeleteAllContents)
                My.Computer.FileSystem.CreateDirectory(RutaTemporal)
            Catch ex As Exception

            End Try


        End If

    End Sub
#End Region

    Private Sub _prIniciarTodo()


        Me.Text = "C A B A Ñ A S"
        '_prCargarComboTipo()
        _prCargarComboLibreria(cbTipo, gi_LibCABANA, gi_LibCABANAHotel)
        _PMIniciarTodo()

        _prAsignarPermisos()

        'groudpanel.Style.BackColor = Color.FromArgb(13, 71, 161)
        'groudpanel.Style.BackColor2 = Color.FromArgb(13, 71, 161)
        'groudpanel.Style.TextColor = Color.White
        btnImgAnt.BackColor = Color.FromArgb(66, 133, 244)
        btnImgAnt.Style = eDotNetBarStyle.Office2013
        PanelImagenes.BackColor = Color.White
        GroupPanelBuscador.Style.BackColor = Color.FromArgb(13, 71, 161)
        GroupPanelBuscador.Style.BackColor2 = Color.FromArgb(13, 71, 161)
        GroupPanelBuscador.Style.TextColor = Color.White
        _prCargarLengthTextBox()

        JGrM_Buscador.RootTable.HeaderFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True


    End Sub
    Public Sub _prEliminarImageMemory()
        If IsNothing(btnImg1.Image) = False Then
            btnImg1.Image.Dispose()
            btnImg1.ImageLarge.Dispose()
            btnImg1.Dispose()
        End If

        If IsNothing(btnImg2.Image) = False Then
            btnImg2.Image.Dispose()
            btnImg2.ImageLarge.Dispose()
            btnImg2.Dispose()
        End If

        If IsNothing(btnImg3.Image) = False Then
            btnImg3.Image.Dispose()
            btnImg3.ImageLarge.Dispose()
            btnImg3.Dispose()
        End If

        OfdVehiculo.Dispose()
    End Sub

    Public Sub _prCargarLengthTextBox()
        tbnombre.MaxLength = 30
        tbobs.MaxLength = 50


    End Sub


    Private Sub _prCargarComboLibreria(mCombo As Janus.Windows.GridEX.EditControls.MultiColumnCombo, cod1 As String, cod2 As String)
        Dim dt As New DataTable
        dt = L_prLibreriaClienteRGeneral(cod1, cod2)

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
    Private Sub _prAsignarPermisos()

        Dim dtRolUsu As DataTable = L_prRolDetalleGeneral(gi_userRol, _nameButton)

        Dim show As Boolean = dtRolUsu.Rows(0).Item("ycshow")
        Dim add As Boolean = dtRolUsu.Rows(0).Item("ycadd")
        Dim modif As Boolean = dtRolUsu.Rows(0).Item("ycmod")
        Dim del As Boolean = dtRolUsu.Rows(0).Item("ycdel")

        If add = False Then
            btnNuevo.Visible = False
        End If
        If modif = False Then
            btnModificar.Visible = False
        End If
        If del = False Then
            btnEliminar.Visible = False
        End If

    End Sub
    Public Sub _prCambiarCursosEliminar()
        btnImg1.Cursor = Cursors.No
        btnImg2.Cursor = Cursors.No
        btnImg3.Cursor = Cursors.No

    End Sub
    Public Sub _prCambiarCursosCancelar()
        btnImg1.Cursor = Cursors.Default
        btnImg2.Cursor = Cursors.Default
        btnImg3.Cursor = Cursors.Default

    End Sub

    Public Sub _prCargarImagenesDataTable()
        Dim length As Integer = Imagenes.Rows.Count
        For i As Integer = 0 To length - 1 Step 1
            Dim nameimg As String = Imagenes.Rows(i).Item("hcima")
            Dim hctc2 As String = Str(Imagenes.Rows(i).Item("hctch2"))


            If (File.Exists(RutaGlobal + "\Imagenes\Imagenes Cabaña\" + "Registro_" + hctc2 + nameimg)) Then
                Imagenes.Rows(i).Item("img") = _fnBytesArchivo(RutaGlobal + "\Imagenes\Imagenes Cabaña\" + "Registro_" + hctc2 + nameimg)
            Else
                Dim Bin As New MemoryStream
                Dim img As New Bitmap(My.Resources.image_not_found)
                img.Save(Bin, Imaging.ImageFormat.Jpeg)
                Bin.Dispose()
                Imagenes.Rows(i).Item("img") = Bin.GetBuffer
            End If




        Next
        _prActualizarImagenes()

    End Sub
    Public Function _fnObtenerNumiCabaña() As Integer
        Dim length As Integer = CType(JGrM_Buscador.DataSource, DataTable).Rows.Count
        If (length > 0) Then
            Return CType(JGrM_Buscador.DataSource, DataTable).Rows(length - 1).Item("hbnumi")
        Else
            Return 0

        End If

    End Function

    Public Function _fnActionNuevo() As Boolean
        Return tbNumi.Text.Equals("")
    End Function

    Public Sub GrabarImagenesDeRegistroModificados()


        Dim length As Integer = TablaImagenes.Rows.Count
        Dim _hbnumi As Integer
        If (length > 0) Then
            _prEliminarImageMemory()
        End If


        For i As Integer = 0 To length - 1 Step 1
            Dim estado As Integer = TablaImagenes.Rows(i).Item("estado")
            Dim nameImg As String = TablaImagenes.Rows(i).Item("hcima")
            Dim Descripcion As String = TablaImagenes.Rows(i).Item("hcima")
            Dim canumi As Integer = tbNumi.Text
            If (Not _fnActionNuevo()) Then
                _hbnumi = tbNumi.Text
            Else
                _hbnumi = _fnObtenerNumiCabaña()

            End If
            If (estado = 0 Or estado = 2) Then

                If (File.Exists(RutaTemporal + nameImg)) Then
                    Dim img As New Bitmap(New Bitmap(RutaTemporal + nameImg))
                    Dim RutaGeneral As String = RutaGlobal + "\Imagenes\Imagenes Cabaña\" + "Registro_" + Str(_hbnumi) + nameImg

                    Try
                        img.Save(RutaGeneral, System.Drawing.Imaging.ImageFormat.Jpeg)
                    Catch ex As Exception

                    End Try
                End If


            End If
            If (estado = -1) Then

                If (File.Exists(
RutaGlobal + "\Imagenes\Imagenes Cabaña\" + "Registro_" + Str(_hbnumi) + nameImg)) Then
                    Try

                        My.Computer.FileSystem.DeleteFile(
    RutaGlobal + "\Imagenes\Imagenes Cabaña\" + "Registro_" + Str(_hbnumi) + nameImg)
                    Catch ex As Exception

                    End Try
                End If

            End If
        Next
    End Sub

    Public Function _fnObtenerNumiImagenes() As Integer
        Dim Length As Integer = Imagenes.Rows.Count
        If (Length > 0) Then
            Return Imagenes.Rows(Length - 1).Item("hcnumi")
        Else
            Return 0
        End If

    End Function
    Public Function _fnBytesArchivo(ruta As String) As Byte()

        If Not (ruta.Equals(" ")) Then ' esta sería una función que verifica que realmente existe el archivo, devolviendo true o false...
            Try
                Return IO.File.ReadAllBytes(ruta)
            Catch ex As Exception

            End Try

        Else

            Throw New Exception("No se encuentra el archivo: " & ruta)

        End If
        Return Nothing
    End Function
    Private Sub _prCargarImagen()
        OfdVehiculo.InitialDirectory = "C:\Users\" + Environment.UserName + "\Pictures"
        OfdVehiculo.Filter = "Image Files (*.png, *.jpg)|*.png;*.jpg"
        OfdVehiculo.FilterIndex = 1
        If (OfdVehiculo.ShowDialog() = DialogResult.OK) Then
            Dim hcnumi As Integer = _fnObtenerNumiImagenes() + 1
            Imagenes.Rows.Add()
            TablaImagenes.Rows.Add()

            Dim pos As Integer = Imagenes.Rows.Count

            Dim postabla As Integer = TablaImagenes.Rows.Count
            Dim NameImg As String = "\Imagen_" + Str(pos) + ".jpg"
            Dim NameImgTabla As String = "\Imagen_" + Str(hcnumi) + ".jpg"
            'hcnumi ,hctch2 ,hcima ,Cast('' as image ) as img,1 as estado
            Imagenes.Rows(pos - 1).Item("hcnumi") = hcnumi
            Imagenes.Rows(pos - 1).Item("hcima") = NameImgTabla
            Imagenes.Rows(pos - 1).Item("img") = _fnBytesArchivo(OfdVehiculo.FileName)
            Imagenes.Rows(pos - 1).Item("estado") = 0

            TablaImagenes.Rows(postabla - 1).Item("hcnumi") = hcnumi
            TablaImagenes.Rows(postabla - 1).Item("hcima") = NameImgTabla
            TablaImagenes.Rows(postabla - 1).Item("img") = _fnBytesArchivo(OfdVehiculo.FileName)
            TablaImagenes.Rows(postabla - 1).Item("estado") = 0


            Dim img As New Bitmap(New Bitmap(OfdVehiculo.FileName))
            img.Save(RutaTemporal + NameImgTabla, System.Drawing.Imaging.ImageFormat.Jpeg)
            PosicionImagen = Imagenes.Rows.Count
            _prActualizarImagenes()


        Else



        End If
        _prCambiarCursosCancelar()
    End Sub

    Private Sub _prActualizarImagenes()
        Dim tam As Integer = Imagenes.Rows.Count
        btnImg1.Image = Nothing
        btnImg1.ImageLarge = Nothing
        btnImg2.Image = Nothing
        btnImg2.ImageLarge = Nothing
        btnImg3.Image = Nothing
        btnImg3.ImageLarge = Nothing

        If tam >= 1 Then

            Dim bm As Bitmap = Nothing
            Dim by As Byte() = Imagenes.Rows(PosicionImagen - 1).Item("img")
            Dim ms As New MemoryStream(by)
            bm = New Bitmap(ms)
            btnImg1.Image = bm
            btnImg1.ImageLarge = bm
        End If
        If tam >= 2 Then

            Dim bm As Bitmap = Nothing
            Dim by As Byte() = Imagenes.Rows(PosicionImagen - 2).Item("img")
            Dim ms As New MemoryStream(by)
            bm = New Bitmap(ms)
            btnImg2.Image = bm
            btnImg2.ImageLarge = bm



        End If
        If tam >= 3 Then
            Dim bm As Bitmap = Nothing
            Dim by As Byte() = Imagenes.Rows(PosicionImagen - 3).Item("img")
            Dim ms As New MemoryStream(by)
            bm = New Bitmap(ms)
            btnImg3.Image = bm
            btnImg3.ImageLarge = bm

        End If

        BubbleBarImagenes.Refresh()
    End Sub
    Private Sub _prMoverImgIzquierda()
        Dim length As Integer = Imagenes.Rows.Count
        If PosicionImagen < length Then
            PosicionImagen = PosicionImagen + 1
            _prActualizarImagenes()
        End If
    End Sub
    Public Sub _EliminarImagenDatasource(_numi As Integer)
        Dim length As Integer = TablaImagenes.Rows.Count
        For i As Integer = 0 To length - 1 Step 1
            Dim numi As Integer = TablaImagenes.Rows(i).Item("hcnumi")
            Dim estado As Integer = TablaImagenes.Rows(i).Item("estado")
            If (numi = _numi And estado > 0) Then
                TablaImagenes.Rows(i).Item("estado") = -1
                Return
            Else
                If (numi = _numi And estado = 0) Then
                    TablaImagenes.Rows(i).Item("estado") = -2
                End If
            End If
        Next
    End Sub

    Private Sub _prCargarGridDetalle(numi As String)
        Dim dt As New DataTable
        dt = L_prCabañaDetalleGeneraldgr(numi)

        grDetalle.DataSource = dt
        grDetalle.RetrieveStructure()

        'dar formato a las columnas
        With grDetalle.RootTable.Columns("hgnumi")
            .Width = 50
            .Visible = False
        End With
        With grDetalle.RootTable.Columns("hgnumith2")
            .Width = 50
            .Visible = False
        End With

        With grDetalle.RootTable.Columns("hgtipo")
            .Caption = "COD"
            .Width = 100
            .EditType = EditType.NoEdit
        End With
        With grDetalle.RootTable.Columns("cedesc1")
            .Caption = "TIPO TARIFA"
            .EditType = EditType.NoEdit
            .Width = 200
        End With
        With grDetalle.RootTable.Columns("hgprecio")
            .Caption = "PRECIO"
            .Width = 100
            .CellStyle.TextAlignment = TextAlignment.Far
            .FormatString = "0.00"
        End With

        With grDetalle.RootTable.Columns("estado")
            .Visible = False
            .DefaultValue = 0
        End With

        With grDetalle
            .GroupByBoxVisible = False
            'diseño de la grilla
            .VisualStyle = VisualStyle.Office2007
            grDetalle.AllowAddNew = InheritableBoolean.False
        End With

        'Dim fc As GridEXFormatCondition
        'fc = New GridEXFormatCondition(grDetalle.RootTable.Columns("estado"), ConditionOperator.Equal, 0)
        'fc.FormatStyle.BackColor = Color.LightGreen
        'grDetalle.RootTable.FormatConditions.Add(fc)

    End Sub
#End Region

#Region "METODOS SOBREESCRITOS"
    Public Overrides Sub _PMOHabilitar()


        tbnombre.ReadOnly = False
        tbdormi.ReadOnly = False
        tbobs.ReadOnly = False
        tbper.ReadOnly = False
        tbPerMenores.ReadOnly = False
        cbTipo.ReadOnly = False
        PanelAgrImagen.Enabled = True
        _prCambiarCursosCancelar()
        _prCrearCarpetaTemporal()
        JGrM_Buscador.RootTable.HeaderFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True

        grDetalle.AllowEdit = InheritableBoolean.True

    End Sub
    Public Overrides Sub _PMOInhabilitar()
        tbNumi.ReadOnly = True
        tbnombre.ReadOnly = True
        tbdormi.ReadOnly = True
        tbobs.ReadOnly = True
        tbper.ReadOnly = True
        tbPerMenores.ReadOnly = True
        cbTipo.ReadOnly = True
        PanelAgrImagen.Enabled = False
        _prCambiarCursosCancelar()
        JGrM_Buscador.RootTable.HeaderFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True

        grDetalle.AllowEdit = InheritableBoolean.False
    End Sub
    Public Overrides Sub _PMOHabilitarFocus()
        With MHighlighterFocus
            .SetHighlightOnFocus(tbNumi, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
            .SetHighlightOnFocus(tbnombre, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
            .SetHighlightOnFocus(tbdormi, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
            .SetHighlightOnFocus(tbobs, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
            .SetHighlightOnFocus(tbper, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
            .SetHighlightOnFocus(tbPerMenores, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
            .SetHighlightOnFocus(cbTipo, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
        End With
    End Sub
    Public Overrides Sub _PMOLimpiar()
        tbNumi.Text = ""
        tbnombre.Text = ""
        tbdormi.Text = ""
        tbobs.Text = ""
        tbper.Text = ""
        tbPerMenores.Text = ""
        cbTipo.Text = ""
        Imagenes = L_prCabañaImagenes(-1)
        TablaImagenes = Imagenes.Copy
        btnImg1.Image = Nothing
        btnImg1.ImageLarge = Nothing
        btnImg2.Image = Nothing
        btnImg2.ImageLarge = Nothing
        btnImg3.Image = Nothing
        btnImg3.ImageLarge = Nothing

        BubbleBarImagenes.Refresh()
        _prCambiarCursosCancelar()

        'VACIO EL DETALLE
        _prCargarGridDetalle(-1)
    End Sub
    Public Overrides Sub _PMOLimpiarErrores()
        MEP.Clear()
        tbNumi.BackColor = Color.White
        tbnombre.BackColor = Color.White
        tbdormi.BackColor = Color.White
        tbobs.BackColor = Color.White
        tbper.BackColor = Color.White
        tbPerMenores.BackColor = Color.White
        cbTipo.BackColor = Color.White
    End Sub
    Public Overrides Function _PMOValidarCampos() As Boolean
        Dim _ok As Boolean = True
        MEP.Clear()
        If tbnombre.Text = String.Empty Then
            tbnombre.BackColor = Color.Red
            MEP.SetError(tbnombre, "ingrese el nombre de la cabaña!".ToUpper)
            _ok = False
        Else
            tbnombre.BackColor = Color.White
            MEP.SetError(tbnombre, "")
        End If
        If tbdormi.Text = String.Empty Then
            tbdormi.BackColor = Color.Red
            MEP.SetError(tbdormi, "ingrese la cantidad de dormitorios!".ToUpper)
            _ok = False
        Else
            tbdormi.BackColor = Color.White
            MEP.SetError(tbdormi, "")
        End If


        If tbper.Text = String.Empty Then
            tbper.BackColor = Color.Red
            MEP.SetError(tbper, "Ingrese la cantidad de personas mayores!".ToUpper)
            _ok = False
        Else
            tbper.BackColor = Color.White
            MEP.SetError(tbper, "")
        End If

        If tbPerMenores.Text = String.Empty Then
            tbPerMenores.BackColor = Color.Red
            MEP.SetError(tbPerMenores, "Ingrese la cantidad de personas menores!".ToUpper)
            _ok = False
        Else
            tbPerMenores.BackColor = Color.White
            MEP.SetError(tbPerMenores, "")
        End If

        If cbTipo.SelectedIndex < 0 Then
            cbTipo.BackColor = Color.Red
            MEP.SetError(cbTipo, "seleccione un Tipo de cabaña!".ToUpper)
            _ok = False
        Else
            cbTipo.BackColor = Color.White
            MEP.SetError(cbTipo, "")
        End If

        MHighlighterFocus.UpdateHighlights()
        Return _ok
    End Function
    Public Overrides Function _PMOGetListEstructuraBuscador() As List(Of Modelos.Celda)
        Dim listEstCeldas As New List(Of Modelos.Celda)


        listEstCeldas.Add(New Modelos.Celda("hbnumi", True, "ID", 70))
        listEstCeldas.Add(New Modelos.Celda("hbnom", True, "NOMBRE", 350))
        listEstCeldas.Add(New Modelos.Celda("hbdor", True, "CANTIDAD DE DORMITORIOS", 230))
        listEstCeldas.Add(New Modelos.Celda("hbper", True, "CANTIDAD DE PERSONAS MAYORES", 200))
        listEstCeldas.Add(New Modelos.Celda("hbtipo", False))
        listEstCeldas.Add(New Modelos.Celda("cedesc1", True, "TIPO", 100))
        listEstCeldas.Add(New Modelos.Celda("hbsuc", False))
        listEstCeldas.Add(New Modelos.Celda("hbobs", True, "OBSERVACION", 400))
        listEstCeldas.Add(New Modelos.Celda("hbpermen", True, "CANT. PERSONAS MENORES", 200))
        listEstCeldas.Add(New Modelos.Celda("hbfact", False))
        listEstCeldas.Add(New Modelos.Celda("hbhact", False))
        listEstCeldas.Add(New Modelos.Celda("hbuact", False))
        Return listEstCeldas

    End Function
    Public Overrides Function _PMOGetTablaBuscador() As DataTable
        Dim dtBuscador As DataTable = L_prCabañaGeneraldgr(gi_LibCABANA, gi_LibCABANAHotel)

        Return dtBuscador
    End Function
    Public Overrides Sub _PMOMostrarRegistro(_N As Integer)
        JGrM_Buscador.Row = _MPos
        'hbnumi ,hbnom ,hbdor ,hbper ,hbtipo ,b.cedesc1 ,hbsuc ,hbobs ,hbfact ,hbhact ,hbuact 
        With JGrM_Buscador
            tbNumi.Text = .GetValue("hbnumi").ToString
            tbnombre.Text = .GetValue("hbnom")
            tbdormi.Text = .GetValue("hbdor").ToString
            tbper.Text = .GetValue("hbper").ToString
            tbPerMenores.Text = .GetValue("hbpermen").ToString

            tbobs.Text = .GetValue("hbobs").ToString
            cbTipo.Value = .GetValue("hbtipo")

            lbFecha.Text = CType(.GetValue("hbfact"), Date).ToString("dd/MM/yyyy")
            lbHora.Text = .GetValue("hbhact").ToString
            lbUsuario.Text = .GetValue("hbuact").ToString
            _prCrearCarpetaImagenes("Registro_ " + .GetValue("hbnumi").ToString)
            'CARGAR DETALLE
            _prCargarGridDetalle(tbNumi.Text)
        End With
        Imagenes = L_prCabañaImagenes(JGrM_Buscador.GetValue("hbnumi"))
        TablaImagenes = Imagenes.Copy
        LblPaginacion.Text = Str(_MPos + 1) + "/" + JGrM_Buscador.RowCount.ToString
        If (Imagenes.Rows.Count > 0) Then
            PosicionImagen = Imagenes.Rows.Count
            _prCargarImagenesDataTable()
        Else

            btnImg1.Image = Nothing
            btnImg1.ImageLarge = Nothing
            btnImg2.Image = Nothing
            btnImg2.ImageLarge = Nothing
            btnImg3.Image = Nothing
            btnImg3.ImageLarge = Nothing

            BubbleBarImagenes.Refresh()
        End If
        _prCambiarCursosCancelar()
        'cargar imagenes

    End Sub



    Public Overrides Function _PMOGrabarRegistro() As Boolean

        Dim dtDetalle As DataTable = CType(grDetalle.DataSource, DataTable).DefaultView.ToTable(True, "hgnumi", "hgnumith2", "hgtipo", "hgprecio", "estado")

        Dim res As Boolean = L_prCabañaGrabardgr(tbNumi.Text, tbnombre.Text, tbdormi.Text, tbper.Text, cbTipo.Value, tbobs.Text, tbPerMenores.Text, TablaImagenes, dtDetalle)
        If res Then
            ' .trim
            _prCrearCarpetaImagenes("Registro_" + Str(_fnObtenerNumiCabaña() + 1))
            GrabarImagenesDeRegistroModificados()
            ToastNotification.Show(Me, "Codigo de Cabaña ".ToUpper + tbNumi.Text + " Grabado con Exito.".ToUpper, My.Resources.GRABACION_EXITOSA, 5000, eToastGlowColor.Green, eToastPosition.TopCenter)
            tbnombre.Focus()
        End If
        Return res

    End Function


    Public Overrides Function _PMOModificarRegistro() As Boolean
        Dim dtDetalle As DataTable = CType(grDetalle.DataSource, DataTable).DefaultView.ToTable(True, "hgnumi", "hgnumith2", "hgtipo", "hgprecio", "estado")

        Dim res As Boolean = L_prCabañaModificardgr(tbNumi.Text, tbnombre.Text, tbdormi.Text, tbper.Text, cbTipo.Value, tbobs.Text, tbPerMenores.Text, TablaImagenes, dtDetalle)
        If res Then
            GrabarImagenesDeRegistroModificados()
            ToastNotification.Show(Me, "Codigo de Preguntas ".ToUpper + tbNumi.Text + " Modificado con Exito.".ToUpper, My.Resources.GRABACION_EXITOSA, 5000, eToastGlowColor.Green, eToastPosition.TopCenter)
            tbnombre.Focus()
        End If
        Return res
    End Function
    Public Overrides Sub _PMOEliminarRegistro()
        Dim info As New TaskDialogInfo("¿esta seguro de eliminar el registro?".ToUpper, eTaskDialogIcon.Delete, "advertencia".ToUpper, "mensaje principal".ToUpper, eTaskDialogButton.Yes Or eTaskDialogButton.Cancel, eTaskDialogBackgroundColor.Blue)
        Dim result As eTaskDialogResult = TaskDialog.Show(info)
        If result = eTaskDialogResult.Yes Then
            Dim mensajeError As String = ""
            Dim res As Boolean = L_prCabañaBorrar(tbNumi.Text, mensajeError)
            If res Then
                _prEliminarImageMemory()
                Try

                    My.Computer.FileSystem.DeleteDirectory(RutaGlobal + "\Imagenes\Imagenes Cabaña\" + "Registro_ " + tbNumi.Text.Trim, FileIO.UIOption.AllDialogs, FileIO.RecycleOption.SendToRecycleBin)

                Catch ex As Exception

                End Try
                ToastNotification.Show(Me, "Codigo de Cabaña ".ToUpper + tbNumi.Text + " eliminado con Exito.".ToUpper, My.Resources.GRABACION_EXITOSA, 5000, eToastGlowColor.Green, eToastPosition.TopCenter)
                _PMFiltrar()
            Else
                ToastNotification.Show(Me, mensajeError, My.Resources.WARNING, 8000, eToastGlowColor.Red, eToastPosition.TopCenter)
            End If
        End If
    End Sub
#End Region
#Region "Eventos del Formulario"
    Private Sub F1_CABAÑA_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _prIniciarTodo()

    End Sub

    Private Sub RadialMenuImgOpc_ItemClick(sender As Object, e As EventArgs) Handles RadialMenuImgOpc.ItemClick
        Dim item As RadialMenuItem = TryCast(sender, RadialMenuItem)
        If item IsNot Nothing AndAlso (Not String.IsNullOrEmpty(item.Text)) Then

            Select Case item.Name
                Case "btnAgregar"
                    _prCargarImagen()
                Case "btnEliminarIma"
                    _prCambiarCursosEliminar()

                Case "btnCancelarIma"
                    _prCambiarCursosCancelar()
            End Select

        End If
    End Sub

    Private Sub btnImgAnt_Click(sender As Object, e As EventArgs) Handles btnImgAnt.Click
        _prMoverImgIzquierda()

    End Sub



    Private Sub btnImgSig_Click(sender As Object, e As EventArgs) Handles btnImgSig.Click
        If (PosicionImagen > 3) Then
            PosicionImagen = PosicionImagen - 1
            _prActualizarImagenes()
        End If
    End Sub


    Private Sub btnImg1_MouseEnter(sender As Object, e As EventArgs) Handles btnImg1.MouseEnter


    End Sub

    Private Sub SuperTabPrincipal_SelectedTabChanged(sender As Object, e As SuperTabStripSelectedTabChangedEventArgs) Handles SuperTabPrincipal.SelectedTabChanged

    End Sub

    Private Sub btnImg1_Click(sender As Object, e As ClickEventArgs) Handles btnImg1.Click

        Dim tam As Integer = Imagenes.Rows.Count

        If tam >= 1 Then
            If (btnImg1.Cursor = Cursors.No) Then
                Imagenes.Rows(PosicionImagen - 1).Item("estado") = -1
                Dim numi As Integer = Imagenes.Rows(PosicionImagen - 1).Item("hcnumi")
                _EliminarImagenDatasource(numi)
                Dim l As Integer = Imagenes.Rows.Count

                Imagenes.Rows.RemoveAt(PosicionImagen - 1)

                Dim d As Integer = Imagenes.Rows.Count
                If (PosicionImagen > d) Then
                    PosicionImagen = PosicionImagen - 1

                End If

                _prActualizarImagenes()

            Else
                Dim nameimg As String = Imagenes.Rows(PosicionImagen - 1).Item("hcima")
                Dim hctc2 As String = tbNumi.Text

                Dim estado As Integer = Imagenes.Rows(PosicionImagen - 1).Item("estado")
                Dim ruta As String
                If (estado > 0) Then
                    ruta = RutaGlobal + "\Imagenes\Imagenes Cabaña\" + "Registro_ " + hctc2 + nameimg
                Else
                    ruta = RutaTemporal + nameimg
                End If
                If (File.Exists(ruta)) Then
                    Shell("rundll32.exe C:\WINDOWS\system32\shimgvw.dll,ImageView_Fullscreen " + ruta)
                End If


            End If

        End If

    End Sub



    Private Sub btnImg2_Click(sender As Object, e As ClickEventArgs) Handles btnImg2.Click
        Dim tam As Integer = Imagenes.Rows.Count

        If tam >= 2 Then



            If (btnImg1.Cursor = Cursors.No) Then
                Dim numi As Integer = Imagenes.Rows(PosicionImagen - 2).Item("hcnumi")
                _EliminarImagenDatasource(numi)
                Dim l As Integer = Imagenes.Rows.Count

                Imagenes.Rows.RemoveAt(PosicionImagen - 2)

                Dim d As Integer = Imagenes.Rows.Count
                If (PosicionImagen > d) Then
                    PosicionImagen = PosicionImagen - 1
                End If


                _prActualizarImagenes()

            Else
                Dim nameimg As String = Imagenes.Rows(PosicionImagen - 2).Item("hcima")
                Dim hctc2 As String = tbNumi.Text


                Dim estado As Integer = Imagenes.Rows(PosicionImagen - 2).Item("estado")
                Dim ruta As String
                If (estado > 0) Then
                    ruta = RutaGlobal + "\Imagenes\Imagenes Cabaña\" + "Registro_ " + hctc2 + nameimg
                Else
                    ruta = RutaTemporal + nameimg
                End If

                If (File.Exists(ruta)) Then
                    Shell("rundll32.exe C:\WINDOWS\system32\shimgvw.dll,ImageView_Fullscreen " + ruta)
                End If
            End If

        End If
    End Sub

    Private Sub btnImg3_Click(sender As Object, e As ClickEventArgs) Handles btnImg3.Click
        Dim tam As Integer = Imagenes.Rows.Count

        If tam >= 3 Then

            If (btnImg1.Cursor = Cursors.No) Then
                Dim numi As Integer = Imagenes.Rows(PosicionImagen - 3).Item("hcnumi")
                _EliminarImagenDatasource(numi)
                Dim l As Integer = Imagenes.Rows.Count

                Imagenes.Rows.RemoveAt(PosicionImagen - 3)

                Dim d As Integer = Imagenes.Rows.Count
                If (PosicionImagen > d) Then
                    PosicionImagen = PosicionImagen - 1
                End If

                _prActualizarImagenes()

            Else
                Dim nameimg As String = Imagenes.Rows(PosicionImagen - 3).Item("hcima")
                Dim hctc2 As String = tbNumi.Text
                Dim estado As Integer = Imagenes.Rows(PosicionImagen - 3).Item("estado")
                Dim ruta As String
                If (estado > 0) Then
                    ruta = RutaGlobal + "\Imagenes\Imagenes Cabaña\" + "Registro_ " + hctc2 + nameimg
                Else
                    ruta = RutaTemporal + nameimg
                End If
                If (File.Exists(ruta)) Then
                    Shell("rundll32.exe C:\WINDOWS\system32\shimgvw.dll,ImageView_Fullscreen " + ruta)
                End If
            End If

        End If
    End Sub

    Private Sub tbdormi_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbdormi.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSymbol(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsWhiteSpace(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If

        tbdormi.Text = Trim(Replace(tbdormi.Text, "  ", " "))
        tbdormi.Select(tbdormi.Text.Length, 0)

    End Sub

    Private Sub tbper_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbper.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSymbol(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsWhiteSpace(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If

        tbper.Text = Trim(Replace(tbper.Text, "  ", " "))
        tbper.Select(tbper.Text.Length, 0)

    End Sub

    Private Sub tbperMenores_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbPerMenores.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSymbol(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsWhiteSpace(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If

        tbPerMenores.Text = Trim(Replace(tbPerMenores.Text, "  ", " "))
        tbPerMenores.Select(tbPerMenores.Text.Length, 0)

    End Sub

    Private Sub btTipo_Click(sender As Object, e As EventArgs) Handles btTipo.Click
        Dim numi As String = ""

        If L_prLibreriaGrabar(numi, gi_LibCABANA, gi_LibCABANAHotel, cbTipo.Text, "") Then
            _prCargarComboLibreria(cbTipo, gi_LibCABANA, gi_LibCABANAHotel)
            cbTipo.SelectedIndex = CType(cbTipo.DataSource, DataTable).Rows.Count - 1
        End If
    End Sub

    Private Sub cbTipo_ValueChanged(sender As Object, e As EventArgs) Handles cbTipo.ValueChanged
        If cbTipo.SelectedIndex < 0 And cbTipo.Text <> String.Empty Then
            btTipo.Visible = True
        Else
            btTipo.Visible = False
        End If
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        tbnombre.Focus()
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        tbnombre.Focus()
    End Sub

    Private Sub grDetalle_CellEdited(sender As Object, e As ColumnActionEventArgs) Handles grDetalle.CellEdited
        Dim estado As Integer = grDetalle.GetValue("estado")
        If estado = 1 Then
            grDetalle.SetValue("estado", 2)

        End If


    End Sub
#End Region


End Class