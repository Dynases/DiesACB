
Imports Logica.AccesoLogica
Imports DevComponents.DotNetBar
Imports System.IO
Imports System.Drawing.Imaging
Public Class F1_TCGVehiculo


#Region "VARIABLES LOCALES"
    Dim Imagenes As DataTable = New DataTable
    Dim TablaImagenes As DataTable = New DataTable
    Dim RutaGlobal As String = gs_CarpetaRaiz
    Dim RutaTemporal As String = "C:\Temporal"
    Dim PosicionImagen As Integer = 0
    Public _nameButton As String
#End Region


#Region "METODOS PRIVADOS"

#Region "Carpeta Imagenes"

    Private Sub _prCrearCarpetaImagenes(carpetaFinal As String)
        Dim rutaDestino As String = RutaGlobal + "\Imagenes\Imagenes TCGVehiculo\" + carpetaFinal + "\"

        If System.IO.Directory.Exists(RutaGlobal + "\Imagenes\Imagenes TCGVehiculo\" + carpetaFinal) = False Then
            If System.IO.Directory.Exists(RutaGlobal + "\Imagenes") = False Then
                System.IO.Directory.CreateDirectory(RutaGlobal + "\Imagenes")
                If System.IO.Directory.Exists(RutaGlobal + "\Imagenes\Imagenes TCGVehiculo") = False Then
                    System.IO.Directory.CreateDirectory(RutaGlobal + "\Imagenes\Imagenes TCGVehiculo")
                    System.IO.Directory.CreateDirectory(RutaGlobal + "\Imagenes\Imagenes TCGVehiculo\" + carpetaFinal + "\")
                End If
            Else
                If System.IO.Directory.Exists(RutaGlobal + "\Imagenes\Imagenes TCGVehiculo") = False Then
                    System.IO.Directory.CreateDirectory(RutaGlobal + "\Imagenes\Imagenes TCGVehiculo")
                    System.IO.Directory.CreateDirectory(RutaGlobal + "\Imagenes\Imagenes TCGVehiculo\" + carpetaFinal + "\")
                Else
                    If System.IO.Directory.Exists(RutaGlobal + "\Imagenes\Imagenes Imagenes TCGVehiculo\" + carpetaFinal) = False Then
                        System.IO.Directory.CreateDirectory(RutaGlobal + "\Imagenes\Imagenes TCGVehiculo\" + carpetaFinal + "\")
                    End If

                End If
            End If
        End If
    End Sub
    Public Function _fnObtenerNumiVehiculo() As Integer
        Dim length As Integer = CType(JGrM_Buscador.DataSource, DataTable).Rows.Count
        If (length > 0) Then
            Return CType(JGrM_Buscador.DataSource, DataTable).Rows(length - 1).Item("gcnumi")
        Else
            Return 0

        End If

    End Function
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
    Public Sub GrabarImagenesDeRegistroModificados()
        Dim length As Integer = TablaImagenes.Rows.Count
        Dim _hbnumi As Integer
        If (length > 0) Then
            _prEliminarImageMemory()
        End If
        For i As Integer = 0 To length - 1 Step 1
            Dim estado As Integer = TablaImagenes.Rows(i).Item("estado")
            Dim nameImg As String = TablaImagenes.Rows(i).Item("gdima")
            Dim Descripcion As String = TablaImagenes.Rows(i).Item("gdima")
            Dim canumi As Integer = tbNumi.Text
            If (Not _fnActionNuevo()) Then
                _hbnumi = tbNumi.Text
            Else
                _hbnumi = _fnObtenerNumiVehiculo()

            End If
            If (estado = 0 Or estado = 2) Then

                If (File.Exists(RutaTemporal + nameImg)) Then
                    Dim img As New Bitmap(New Bitmap(RutaTemporal + nameImg))
                    Dim RutaGeneral As String = RutaGlobal + "\Imagenes\Imagenes TCGVehiculo\" + "Registro_" + Str(_hbnumi) + nameImg
                    Try
                        img.Save(RutaGeneral, System.Drawing.Imaging.ImageFormat.Jpeg)
                        img.Dispose()

                    Catch ex As Exception

                    End Try
                End If


            End If
            If (estado = -1) Then

                If File.Exists(RutaGlobal + "\Imagenes\Imagenes TCGVehiculo\" + "Registro_" + Str(_hbnumi) + nameImg) Then
                    Try
                        My.Computer.FileSystem.DeleteFile(
        RutaGlobal + "\Imagenes\Imagenes TCGVehiculo\" + "Registro_" + Str(_hbnumi) + nameImg)
                    Catch ex As Exception

                    End Try
                End If

            End If
        Next


    End Sub

    Private Sub _prCrearCarpetaTemporal()

        If System.IO.Directory.Exists(RutaTemporal) = False Then
            System.IO.Directory.CreateDirectory(RutaTemporal)
        Else
            Try

            Catch ex As Exception
                My.Computer.FileSystem.DeleteDirectory(RutaTemporal, FileIO.DeleteDirectoryOption.DeleteAllContents)
                My.Computer.FileSystem.CreateDirectory(RutaTemporal)
            End Try


        End If

    End Sub
    Private Sub _prEliminarCarpetaTemporal()

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
        If System.IO.Directory.Exists(RutaTemporal) = True Then
            My.Computer.FileSystem.DeleteDirectory(RutaTemporal, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.SendToRecycleBin)

        End If

    End Sub
#End Region
    Private Sub _prIniciarTodo()

        Me.Text = "V E H I C U L O S     R E M O L Q U E".ToUpper
        _prCargarComboLibreria(tbMarca, gi_LibVEHICULO, gi_LibVEHIMarca)
        _prCargarComboLibreria(tbModelo, gi_LibVEHICULO, gi_LibVEHIModelo)
        _prCargarComboLibreria(tbTipo, gi_LibVEHICULO, gi_LibVEHITipo)
        _prCargarComboPersona()
        _prCargarComboSucursal()
        _PMIniciarTodo()
        _prAsignarPermisos()
        groudpanel.Style.BackColor = Color.FromArgb(13, 71, 161)
        groudpanel.Style.BackColor2 = Color.FromArgb(13, 71, 161)
        groudpanel.Style.TextColor = Color.White
        btnImgAnt.BackColor = Color.FromArgb(66, 133, 244)
        btnImgAnt.Style = eDotNetBarStyle.Office2013
        PanelImagenes.BackColor = Color.White
        GroupPanelBuscador.Style.BackColor = Color.FromArgb(13, 71, 161)
        GroupPanelBuscador.Style.BackColor2 = Color.FromArgb(13, 71, 161)
        GroupPanelBuscador.Style.TextColor = Color.White
        _prMaxLengthTextBox()
        JGrM_Buscador.RootTable.HeaderFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True
        Dim blah As Bitmap = My.Resources.car
        Dim ico As Icon = Icon.FromHandle(blah.GetHicon())
        Me.Icon = ico

    End Sub
    Public Sub _prMaxLengthTextBox()
        tbId.MaxLength = 15
        tbObs.MaxLength = 150
    End Sub

    Public Function _fnActionNuevo() As Boolean
        Return tbNumi.Text.Equals("") And tbObs.ReadOnly = False
    End Function

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

    Private Sub _prCargarComboLibreria(mCombo As Janus.Windows.GridEX.EditControls.MultiColumnCombo, cod1 As String, cod2 As String)
        Dim dt As New DataTable
        dt = L_prLibreriaVehiculoGeneral(cod1, cod2)

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

    Private Sub _prCargarComboPersona()
        Dim dt As New DataTable
        dt = L_prPersonaAyudaGeneralPorSucursal(gi_userSucTGVehiculo, 3)

        With tbPersona
            .DropDownList.Columns.Clear()

            .DropDownList.Columns.Add("panumi").Width = 70
            .DropDownList.Columns("panumi").Caption = "COD"

            .DropDownList.Columns.Add("panom1").Width = 200
            .DropDownList.Columns("panom1").Caption = "NOMBRE COMPLETO"

            .ValueMember = "panumi"
            .DisplayMember = "panom1"
            .DataSource = dt
            .Refresh()
        End With
    End Sub

    Private Sub _prCargarComboSucursal()
        Dim dt As New DataTable
        dt = L_prVehiculoSucursalAyuda()

        With tbSuc
            .DropDownList.Columns.Clear()

            .DropDownList.Columns.Add("canumi").Width = 70
            .DropDownList.Columns("canumi").Caption = "COD"

            .DropDownList.Columns.Add("cadesc").Width = 200
            .DropDownList.Columns("cadesc").Caption = "descripcion".ToUpper

            .ValueMember = "canumi"
            .DisplayMember = "cadesc"
            .DataSource = dt
            .Refresh()
        End With
    End Sub
    Public Function _fnBytesArchivo(ruta As String) As Byte()

        If Not (ruta.Equals(" ")) Then ' esta sería una función que verifica que realmente existe el archivo, devolviendo true o false...
            Try
                Return IO.File.ReadAllBytes(ruta)
            Catch ex As Exception
                Throw New Exception("No se encuentra el archivo: " & ruta)
            End Try


        Else
            Throw New Exception("No se encuentra el archivo: " & ruta)
        End If

    End Function
    Public Sub _prCargarImagenesDataTable()
        Dim length As Integer = Imagenes.Rows.Count
        For i As Integer = 0 To length - 1 Step 1
            Dim nameimg As String = Imagenes.Rows(i).Item("gdima")
            Dim hctc2 As String = Str(Imagenes.Rows(i).Item("gdtcg2"))
            If (File.Exists(RutaGlobal + "\Imagenes\Imagenes TCGVehiculo\" + "Registro_" + hctc2 + nameimg)) Then
                Imagenes.Rows(i).Item("img") = _fnBytesArchivo(RutaGlobal + "\Imagenes\Imagenes TCGVehiculo\" + "Registro_" + hctc2 + nameimg)
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
    Public Function _fnObtenerNumiImagenes() As Integer
        Dim Length As Integer = TablaImagenes.Rows.Count
        If (Length > 0) Then
            Return TablaImagenes.Rows(Length - 1).Item("gdnumi")
        Else
            Return 0
        End If

    End Function



    Private Sub _prCargarImagen()
        Try
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
                Imagenes.Rows(pos - 1).Item("gdnumi") = hcnumi
                Imagenes.Rows(pos - 1).Item("gdima") = NameImgTabla
                Imagenes.Rows(pos - 1).Item("img") = _fnBytesArchivo(OfdVehiculo.FileName)
                Imagenes.Rows(pos - 1).Item("estado") = 0

                TablaImagenes.Rows(postabla - 1).Item("gdnumi") = hcnumi
                TablaImagenes.Rows(postabla - 1).Item("gdima") = NameImgTabla
                TablaImagenes.Rows(postabla - 1).Item("img") = _fnBytesArchivo(OfdVehiculo.FileName)
                TablaImagenes.Rows(postabla - 1).Item("estado") = 0


                Dim img As New Bitmap(New Bitmap(OfdVehiculo.FileName))
                img.Save(RutaTemporal + NameImgTabla, System.Drawing.Imaging.ImageFormat.Jpeg)
                PosicionImagen = Imagenes.Rows.Count
                _prActualizarImagenes()


            Else



            End If
        Catch ex As Exception

        End Try

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

    Private Sub _prMoverImgDerecha()
        If (PosicionImagen > 3) Then
            PosicionImagen = PosicionImagen - 1
            _prActualizarImagenes()
        End If
    End Sub


#End Region

#Region "METODOS SOBRECARGADOS"
    Public Overrides Sub _PMOHabilitar()
        tbId.ReadOnly = False
        tbMarca.ReadOnly = False
        tbModelo.ReadOnly = False
        tbObs.ReadOnly = False
        tbPersona.ReadOnly = False
        tbTipo.ReadOnly = False
        tbSuc.ReadOnly = False
        PanelAgrImagen.Enabled = True
        _prCambiarCursosCancelar()
        _prCrearCarpetaTemporal()

    End Sub

    Public Overrides Sub _PMOInhabilitar()
        tbId.ReadOnly = True
        tbMarca.ReadOnly = True
        tbModelo.ReadOnly = True
        tbNumi.ReadOnly = True
        tbObs.ReadOnly = True
        tbPersona.ReadOnly = True
        tbTipo.ReadOnly = True
        tbSuc.ReadOnly = True
        PanelAgrImagen.Enabled = False
        _prCambiarCursosCancelar()
        If (JGrM_Buscador.RowCount = 0) Then
            _PMOLimpiar()

        End If

    End Sub

    Public Overrides Sub _PMOLimpiar()
        tbId.Text = ""
        tbMarca.Text = ""
        tbModelo.Text = ""
        tbNumi.Text = ""
        tbObs.Text = ""
        tbPersona.Text = ""
        tbTipo.Text = ""
        tbSuc.Text = ""
        Imagenes = L_prTCGVehiculoImagenes(-1)
        TablaImagenes = Imagenes.Copy
        btnImg1.Image = Nothing
        btnImg1.ImageLarge = Nothing
        btnImg2.Image = Nothing
        btnImg2.ImageLarge = Nothing
        btnImg3.Image = Nothing
        btnImg3.ImageLarge = Nothing

        BubbleBarImagenes.Refresh()
        _prCambiarCursosCancelar()


        _prCrearCarpetaTemporal()
    End Sub

    Public Overrides Sub _PMOLimpiarErrores()
        MEP.Clear()
        tbId.BackColor = Color.White
        tbMarca.BackColor = Color.White
        tbModelo.BackColor = Color.White
        tbPersona.BackColor = Color.White
        tbTipo.BackColor = Color.White
        tbSuc.BackColor = Color.White
    End Sub

    Public Overrides Function _PMOGrabarRegistro() As Boolean
        Dim res As Boolean = L_prTCGVehiculoGrabar(tbNumi.Text, tbId.Text, tbMarca.Value, tbModelo.Value, tbPersona.Value, tbObs.Text, tbTipo.Value, tbSuc.Value, TablaImagenes)
        If res Then
            _prCrearCarpetaImagenes("Registro_" + Str(_fnObtenerNumiVehiculo() + 1))
            GrabarImagenesDeRegistroModificados()

            ToastNotification.Show(Me, "Codigo de vehiculo ".ToUpper + tbNumi.Text + " Grabado con Exito.".ToUpper, My.Resources.GRABACION_EXITOSA, 5000, eToastGlowColor.Green, eToastPosition.TopCenter)
        End If
        Return res

    End Function

    Public Overrides Function _PMOModificarRegistro() As Boolean
        Dim res As Boolean = L_prTCGVehiculoModificar(tbNumi.Text, tbId.Text, tbMarca.Value, tbModelo.Value, tbPersona.Value, tbObs.Text, tbTipo.Value, tbSuc.Value, TablaImagenes)

        If res Then
            GrabarImagenesDeRegistroModificados()

            ToastNotification.Show(Me, "Codigo de vehiculo ".ToUpper + tbNumi.Text + " modificado con Exito.".ToUpper, My.Resources.GRABACION_EXITOSA, 5000, eToastGlowColor.Green, eToastPosition.TopCenter)
        End If
        Return res
    End Function

    Public Overrides Sub _PMOEliminarRegistro()
        Dim info As New TaskDialogInfo("¿esta seguro de eliminar el registro?".ToUpper, eTaskDialogIcon.Delete, "advertencia".ToUpper, "mensaje principal".ToUpper, eTaskDialogButton.Yes Or eTaskDialogButton.Cancel, eTaskDialogBackgroundColor.Blue)
        Dim result As eTaskDialogResult = TaskDialog.Show(info)
        If result = eTaskDialogResult.Yes Then
            Dim mensajeError As String = ""
            Dim res As Boolean = L_prTCGVehiculoBorrar(tbNumi.Text, mensajeError)
            If res Then
                _prEliminarImageMemory()
                Try
                    If System.IO.Directory.Exists(RutaGlobal + "\Imagenes\Imagenes TCGVehiculo\" + "Registro_ " + tbNumi.Text.Trim) = True Then
                        My.Computer.FileSystem.DeleteDirectory(RutaGlobal + "\Imagenes\Imagenes TCGVehiculo\" + "Registro_ " + tbNumi.Text.Trim, FileIO.UIOption.AllDialogs, FileIO.RecycleOption.SendToRecycleBin)
                    End If


                Catch ex As Exception

                End Try

                ToastNotification.Show(Me, "Codigo de Vehiculo ".ToUpper + tbNumi.Text + " eliminado con Exito.".ToUpper, My.Resources.GRABACION_EXITOSA, 5000, eToastGlowColor.Green, eToastPosition.TopCenter)
                _PMFiltrar()


            Else
                ToastNotification.Show(Me, mensajeError, My.Resources.WARNING, 8000, eToastGlowColor.Red, eToastPosition.TopCenter)
            End If
        End If
    End Sub
    Public Overrides Function _PMOValidarCampos() As Boolean
        Dim _ok As Boolean = True
        MEP.Clear()

        If tbId.Text = String.Empty Then
            tbId.BackColor = Color.Red
            MEP.SetError(tbId, "Ingrese Placa Del Vehiculo!".ToUpper)
            _ok = False
        Else
            tbId.BackColor = Color.White
            MEP.SetError(tbId, "")
        End If

        If tbMarca.SelectedIndex < 0 Then
            tbMarca.BackColor = Color.Red
            MEP.SetError(tbMarca, "Seleccione La Marca Del Vehiculo!".ToUpper)
            _ok = False
        Else
            tbMarca.BackColor = Color.White
            MEP.SetError(tbMarca, "")
        End If

        If tbModelo.SelectedIndex < 0 Then
            tbModelo.BackColor = Color.Red
            MEP.SetError(tbModelo, "Seleccione El Modelo Del Vehiculo!".ToUpper)
            _ok = False
        Else
            tbModelo.BackColor = Color.White
            MEP.SetError(tbModelo, "")
        End If


        If tbTipo.SelectedIndex < 0 Then
            tbTipo.BackColor = Color.Red
            MEP.SetError(tbTipo, "Ingrese La Observacion Del Vehiculo!".ToUpper)
            _ok = False
        Else
            tbTipo.BackColor = Color.White
            MEP.SetError(tbTipo, "")
        End If

        If tbPersona.SelectedIndex < 0 Then
            tbPersona.BackColor = Color.Red
            MEP.SetError(tbPersona, "Seleccione La Persona Encargada Del Vehiculo!".ToUpper)
            _ok = False
        Else
            tbPersona.BackColor = Color.White
            MEP.SetError(tbPersona, "")
        End If

        If tbSuc.SelectedIndex < 0 Then
            tbSuc.BackColor = Color.Red
            MEP.SetError(tbSuc, "Seleccione La Sucursal Del Vehiculo!".ToUpper)
            _ok = False
        Else
            tbSuc.BackColor = Color.White
            MEP.SetError(tbSuc, "")
        End If

        MHighlighterFocus.UpdateHighlights()
        Return _ok
    End Function

    Public Overrides Function _PMOGetTablaBuscador() As DataTable
        Dim dtBuscador As DataTable = L_prTCGVehiculoGeneral(gi_userSucTGVehiculo)

        Return dtBuscador
    End Function

    Public Overrides Function _PMOGetListEstructuraBuscador() As List(Of Modelos.Celda)

        Dim listEstCeldas As New List(Of Modelos.Celda)
        listEstCeldas.Add(New Modelos.Celda("gcnumi", True, "COD", 70))
        listEstCeldas.Add(New Modelos.Celda("gcid", True, "PLACA", 150))
        listEstCeldas.Add(New Modelos.Celda("gctipo", False))
        listEstCeldas.Add(New Modelos.Celda("tipodesc", True, "TIPO", 100))

        listEstCeldas.Add(New Modelos.Celda("gcmar", False))
        listEstCeldas.Add(New Modelos.Celda("margcdesc", True, "MARCA", 120))
        listEstCeldas.Add(New Modelos.Celda("gcmod", False))
        listEstCeldas.Add(New Modelos.Celda("modelodesc", True, "MODELO", 120))
        listEstCeldas.Add(New Modelos.Celda("gcper", False))
        listEstCeldas.Add(New Modelos.Celda("panom1", True, "CONDUCTOR", 200))
        listEstCeldas.Add(New Modelos.Celda("gcobs", True, "OBSERVACION", 350))
        listEstCeldas.Add(New Modelos.Celda("gcsuc", False))
        listEstCeldas.Add(New Modelos.Celda("cadesc", True, "SUCURSAL", 240))
        listEstCeldas.Add(New Modelos.Celda("gcfact", False))
        listEstCeldas.Add(New Modelos.Celda("gchact", False))
        listEstCeldas.Add(New Modelos.Celda("gcuact", False))
        Return listEstCeldas
    End Function

    Public Overrides Sub _PMOMostrarRegistro(_N As Integer)
        JGrM_Buscador.Row = _MPos

        With JGrM_Buscador
            tbNumi.Text = .GetValue("gcnumi").ToString
            tbId.Text = .GetValue("gcid").ToString
            tbMarca.Value = .GetValue("gcmar")
            tbModelo.Value = .GetValue("gcmod")
            tbObs.Text = .GetValue("gcobs").ToString

            tbPersona.Value = .GetValue("gcper")
            tbTipo.Value = .GetValue("gctipo")
            tbSuc.Value = .GetValue("gcsuc")

            lbFecha.Text = CType(.GetValue("gcfact"), Date).ToString("dd/MM/yyyy")
            lbHora.Text = .GetValue("gchact").ToString
            lbUsuario.Text = .GetValue("gcuact").ToString
        End With
        Imagenes = L_prTCGVehiculoImagenes(JGrM_Buscador.GetValue("gcnumi"))
        TablaImagenes = Imagenes.Copy

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



        LblPaginacion.Text = Str(_MPos + 1) + "/" + JGrM_Buscador.RowCount.ToString

    End Sub
    Public Overrides Sub _PMOHabilitarFocus()
        With MHighlighterFocus
            .SetHighlightOnFocus(tbId, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
            .SetHighlightOnFocus(tbMarca, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
            .SetHighlightOnFocus(tbModelo, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
            .SetHighlightOnFocus(tbObs, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
            .SetHighlightOnFocus(tbNumi, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
            .SetHighlightOnFocus(tbPersona, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
            .SetHighlightOnFocus(tbTipo, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
            .SetHighlightOnFocus(tbSuc, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
        End With
    End Sub

#End Region

#Region "Eventos Del Formulario"

    Private Sub P_Instructores_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _prIniciarTodo()
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click

        tbId.Focus()
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
        _prMoverImgDerecha()
    End Sub

    Private Sub btnImg3_Click(sender As Object, e As ClickEventArgs) Handles btnImg3.Click
        Dim tam As Integer = Imagenes.Rows.Count

        If tam >= 3 Then

            If (btnImg1.Cursor = Cursors.No) Then
                Dim numi As Integer = Imagenes.Rows(PosicionImagen - 3).Item("gdnumi")
                _EliminarImagenDatasource(numi)
                Dim l As Integer = Imagenes.Rows.Count

                Imagenes.Rows.RemoveAt(PosicionImagen - 3)

                Dim d As Integer = Imagenes.Rows.Count
                If (PosicionImagen > d) Then
                    PosicionImagen = PosicionImagen - 1
                End If

                _prActualizarImagenes()

            Else
                Dim nameimg As String = Imagenes.Rows(PosicionImagen - 3).Item("gdima")
                Dim hctc2 As String = tbNumi.Text
                Dim estado As Integer = Imagenes.Rows(PosicionImagen - 3).Item("estado")
                Dim ruta As String
                If (estado > 0) Then
                    ruta = RutaGlobal + "\Imagenes\Imagenes TCGVehiculo\" + "Registro_ " + hctc2 + nameimg
                Else
                    ruta = RutaTemporal + nameimg
                End If
                If (File.Exists(ruta)) Then
                    Shell("rundll32.exe C:\WINDOWS\system32\shimgvw.dll,ImageView_Fullscreen " + ruta)
                End If
            End If

        End If
    End Sub

    Public Sub _EliminarImagenDatasource(_numi As Integer)
        Dim length As Integer = TablaImagenes.Rows.Count
        For i As Integer = 0 To length - 1 Step 1
            Dim numi As Integer = TablaImagenes.Rows(i).Item("gdnumi")
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

    Private Sub btnImg2_Click(sender As Object, e As ClickEventArgs) Handles btnImg2.Click
        Dim tam As Integer = Imagenes.Rows.Count

        If tam >= 2 Then



            If (btnImg1.Cursor = Cursors.No) Then
                Dim numi As Integer = Imagenes.Rows(PosicionImagen - 2).Item("gdnumi")
                _EliminarImagenDatasource(numi)
                Dim l As Integer = Imagenes.Rows.Count

                Imagenes.Rows.RemoveAt(PosicionImagen - 2)

                Dim d As Integer = Imagenes.Rows.Count
                If (PosicionImagen > d) Then
                    PosicionImagen = PosicionImagen - 1
                End If


                _prActualizarImagenes()

            Else
                Dim nameimg As String = Imagenes.Rows(PosicionImagen - 2).Item("gdima")
                Dim hctc2 As String = tbNumi.Text


                Dim estado As Integer = Imagenes.Rows(PosicionImagen - 2).Item("estado")
                Dim ruta As String
                If (estado > 0) Then
                    ruta = RutaGlobal + "\Imagenes\Imagenes TCGVehiculo\" + "Registro_ " + hctc2 + nameimg
                Else
                    ruta = RutaTemporal + nameimg
                End If

                If (File.Exists(ruta)) Then
                    Shell("rundll32.exe C:\WINDOWS\system32\shimgvw.dll,ImageView_Fullscreen " + ruta)
                End If
            End If

        End If
    End Sub

    Private Sub btnImg1_Click(sender As Object, e As ClickEventArgs) Handles btnImg1.Click
        Dim tam As Integer = Imagenes.Rows.Count

        If tam >= 1 Then
            If (btnImg1.Cursor = Cursors.No) Then
                Imagenes.Rows(PosicionImagen - 1).Item("estado") = -1
                Dim numi As Integer = Imagenes.Rows(PosicionImagen - 1).Item("gdnumi")
                _EliminarImagenDatasource(numi)
                Dim l As Integer = Imagenes.Rows.Count

                Imagenes.Rows.RemoveAt(PosicionImagen - 1)

                Dim d As Integer = Imagenes.Rows.Count
                If (PosicionImagen > d) Then
                    PosicionImagen = PosicionImagen - 1

                End If

                _prActualizarImagenes()

            Else
                Dim nameimg As String = Imagenes.Rows(PosicionImagen - 1).Item("gdima")
                Dim hctc2 As String = tbNumi.Text

                Dim estado As Integer = Imagenes.Rows(PosicionImagen - 1).Item("estado")
                Dim ruta As String
                If (estado > 0) Then
                    ruta = RutaGlobal + "\Imagenes\Imagenes TCGVehiculo\" + "Registro_ " + hctc2 + nameimg
                Else
                    ruta = RutaTemporal + nameimg
                End If
                If (File.Exists(ruta)) Then
                    Shell("rundll32.exe C:\WINDOWS\system32\shimgvw.dll,ImageView_Fullscreen " + ruta)
                End If


            End If

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

    Private Sub tbMarca_ValueChanged(sender As Object, e As EventArgs) Handles tbMarca.ValueChanged
        If tbMarca.SelectedIndex < 0 And tbMarca.Text <> String.Empty Then
            btMarca.Visible = True
        Else
            btMarca.Visible = False
        End If
    End Sub

    Private Sub btMarca_Click(sender As Object, e As EventArgs) Handles btMarca.Click
        Dim numi As String = ""

        If L_prLibreriaGrabar(numi, gi_LibVEHICULO, gi_LibVEHIMarca, tbMarca.Text, "") Then
            _prCargarComboLibreria(tbMarca, gi_LibVEHICULO, gi_LibVEHIMarca)
            tbMarca.SelectedIndex = CType(tbMarca.DataSource, DataTable).Rows.Count - 1
        End If
    End Sub

    Private Sub tbTipo_ValueChanged(sender As Object, e As EventArgs) Handles tbTipo.ValueChanged
        If tbTipo.SelectedIndex < 0 And tbTipo.Text <> String.Empty Then
            btTipo.Visible = True
        Else
            btTipo.Visible = False
        End If
    End Sub

    Private Sub btTipo_Click(sender As Object, e As EventArgs) Handles btTipo.Click
        Dim numi As String = ""

        If L_prLibreriaGrabar(numi, gi_LibVEHICULO, gi_LibVEHITipo, tbTipo.Text, "") Then
            _prCargarComboLibreria(tbTipo, gi_LibVEHICULO, gi_LibVEHITipo)
            tbTipo.SelectedIndex = CType(tbTipo.DataSource, DataTable).Rows.Count - 1
        End If
    End Sub

    Private Sub tbModelo_ValueChanged(sender As Object, e As EventArgs) Handles tbModelo.ValueChanged
        If tbModelo.SelectedIndex < 0 And tbModelo.Text <> String.Empty Then
            btModelo.Visible = True
        Else
            btModelo.Visible = False
        End If
    End Sub

    Private Sub btModelo_Click(sender As Object, e As EventArgs) Handles btModelo.Click
        Dim numi As String = ""

        If L_prLibreriaGrabar(numi, gi_LibVEHICULO, gi_LibVEHIModelo, tbModelo.Text, "") Then
            _prCargarComboLibreria(tbModelo, gi_LibVEHICULO, gi_LibVEHIModelo)
            tbModelo.SelectedIndex = CType(tbModelo.DataSource, DataTable).Rows.Count - 1
        End If
    End Sub
#End Region

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click

        tbId.Focus()

    End Sub
End Class

