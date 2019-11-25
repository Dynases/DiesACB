Imports Logica.AccesoLogica
Imports Janus.Windows.GridEX
Imports DevComponents.DotNetBar
Imports System.IO
Imports DevComponents.DotNetBar.SuperGrid
Public Class F1_Bancos

#Region "Variable Globales"
    Dim RutaGlobal As String = gs_CarpetaRaiz
    Dim RutaTemporal As String = "C:\Temporal"
    Dim Modificado As Boolean = False
    Dim nameImg As String = "Default.jpg"
    Dim Socio As Boolean = False
    Public _nameButton As String
#End Region

#Region "METODOS PRIVADOS"
    Private Sub _prCrearCarpetaTemporal()

        If System.IO.Directory.Exists(RutaTemporal) = False Then
            System.IO.Directory.CreateDirectory(RutaTemporal)
        Else
            My.Computer.FileSystem.DeleteDirectory(RutaTemporal, FileIO.DeleteDirectoryOption.DeleteAllContents)
            My.Computer.FileSystem.CreateDirectory(RutaTemporal)
            'My.Computer.FileSystem.DeleteDirectory(RutaTemporal, FileIO.UIOption.AllDialogs, FileIO.RecycleOption.SendToRecycleBin)
            'System.IO.Directory.CreateDirectory(RutaTemporal)

        End If

    End Sub
    Private Sub _prCrearCarpetaImagenes()
        Dim rutaDestino As String = RutaGlobal + "\Imagenes\Imagenes Faubrica\"

        If System.IO.Directory.Exists(RutaGlobal + "\Imagenes\Imagenes Faubrica\") = False Then
            If System.IO.Directory.Exists(RutaGlobal + "\Imagenes") = False Then
                System.IO.Directory.CreateDirectory(RutaGlobal + "\Imagenes")
                If System.IO.Directory.Exists(RutaGlobal + "\Imagenes\Imagenes Faubrica") = False Then
                    System.IO.Directory.CreateDirectory(RutaGlobal + "\Imagenes\Imagenes Faubrica")
                End If
            Else
                If System.IO.Directory.Exists(RutaGlobal + "\Imagenes\Imagenes Faubrica") = False Then
                    System.IO.Directory.CreateDirectory(RutaGlobal + "\Imagenes\Imagenes Faubrica")

                End If
            End If
        End If
    End Sub

    Public Sub _prDibujarImagenes()
        Dim length As Integer = CType(JGrM_Buscador.DataSource, DataTable).Rows.Count
        For i As Integer = 0 To length - 1 Step 1
            Dim nameImagen As String = CType(JGrM_Buscador.DataSource, DataTable).Rows(i).Item("caimage")
            If (nameImagen.Equals("Default.jpg")) Then
                Dim Bin As New MemoryStream
                Dim img As New Bitmap(My.Resources.imageDefault, 130, 80)
                img.Save(Bin, Imaging.ImageFormat.Jpeg)
                Bin.Dispose()

                CType(JGrM_Buscador.DataSource, DataTable).Rows(i).Item("img") = Bin.GetBuffer
            Else
                Dim Bin As New MemoryStream
                If (File.Exists(RutaGlobal + "\Imagenes\Imagenes Faubrica" + nameImagen)) Then
                    Dim img As New Bitmap(New Bitmap(RutaGlobal + "\Imagenes\Imagenes Faubrica" + nameImagen), 130, 80)
                    img.Save(Bin, Imaging.ImageFormat.Jpeg)
                    CType(JGrM_Buscador.DataSource, DataTable).Rows(i).Item("img") = Bin.GetBuffer
                    Bin.Dispose()
                Else

                    Dim img As New Bitmap(My.Resources.imageDefault, 130, 80)
                    img.Save(Bin, Imaging.ImageFormat.Jpeg)
                    Bin.Dispose()

                    CType(JGrM_Buscador.DataSource, DataTable).Rows(i).Item("img") = Bin.GetBuffer

                End If
            End If


        Next
    End Sub
    Private Sub _fnMoverImagenRuta(Folder As String, name As String)
        'copio la imagen en la carpeta del sistema
        If (Not name.Equals("Default.jpg") And File.Exists(RutaTemporal + name)) Then

            Dim img As New Bitmap(New Bitmap(RutaTemporal + name), 500, 300)

            UsImg.Image.Dispose()
            UsImg.Image = Nothing
            Try
                My.Computer.FileSystem.CopyFile(RutaTemporal + name,
     Folder + name, overwrite:=True)

            Catch ex As System.IO.IOException


            End Try



        End If
    End Sub
    Private Sub _prIniciarTodo()

        Me.Text = "B A N C O S"
        _PMIniciarTodo()
        _prAsignarPermisos()
        _prCargarLengthTextBox()
        GroupPanelBuscador.Style.BackColor = Color.FromArgb(13, 71, 161)
        GroupPanelBuscador.Style.BackColor2 = Color.FromArgb(13, 71, 161)
        GroupPanelBuscador.Style.TextColor = Color.White
        Dim blah As Bitmap = My.Resources.cliente
        Dim ico As Icon = Icon.FromHandle(blah.GetHicon())
        Me.Icon = ico
        JGrM_Buscador.RootTable.HeaderFormatStyle.FontBold = TriState.True
        JGrM_Buscador.AlternatingColors = True
        btnModificar.Enabled = True
        btnEliminar.Enabled = True
    End Sub

    Public Sub _prCargarLengthTextBox()
        tbnombre.MaxLength = 200
        tbcuenta.MaxLength = 200
        tbobservacion.MaxLength = 200
    End Sub



    Private Function _fnActionNuevo() As Boolean
        'Funcion que me devuelve True si esta en la actividad crear nuevo Tipo de Equipo
        Return tbcodigo.Text.ToString.Equals("") And tbnombre.ReadOnly = False
    End Function

    Private Sub _prAsignarPermisos()

        'Dim dtRolUsu As DataTable = L_prRolDetalleGeneral(gi_userRol, _nameButton)

        'Dim show As Boolean = dtRolUsu.Rows(0).Item("ycshow")
        'Dim add As Boolean = dtRolUsu.Rows(0).Item("ycadd")
        'Dim modif As Boolean = dtRolUsu.Rows(0).Item("ycmod")
        'Dim del As Boolean = dtRolUsu.Rows(0).Item("ycdel")

        'If add = False Then
        '    btnNuevo.Visible = False
        'End If
        'If modif = False Then
        '    btnModificar.Visible = False
        'End If
        'If del = False Then
        '    btnEliminar.Visible = False
        'End If

    End Sub



#End Region

#Region "METODOS SOBREESCRITOS"



    Public Overrides Sub _PMOHabilitar()
        tbnombre.ReadOnly = False
        tbcuenta.ReadOnly = False
        tbobservacion.ReadOnly = False
        _prCrearCarpetaImagenes()
        _prCrearCarpetaTemporal()

        btnImg.Visible = True

    End Sub
    Public Overrides Sub _PMOInhabilitar()
        tbnombre.ReadOnly = True
        tbcuenta.ReadOnly = True
        tbobservacion.ReadOnly = True
        tbcodigo.ReadOnly = True
        btnImg.Visible = False
    End Sub
    Public Overrides Sub _PMOHabilitarFocus()
        With MHighlighterFocus
            .SetHighlightOnFocus(tbnombre, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
            .SetHighlightOnFocus(tbcuenta, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
            .SetHighlightOnFocus(tbobservacion, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
            .SetHighlightOnFocus(tbcodigo, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)

        End With
    End Sub
    Public Overrides Sub _PMOLimpiar()


        tbcodigo.Text = ""
        tbnombre.Text = ""
        tbcuenta.Text = ""
        tbobservacion.Text = ""

        tbnombre.Focus()
        UsImg.Image = My.Resources.imageDefault
    End Sub
    Public Overrides Sub _PMOLimpiarErrores()
        MEP.Clear()
        tbcodigo.BackColor = Color.White
        tbnombre.BackColor = Color.White
        tbcuenta.BackColor = Color.White
        tbobservacion.BackColor = Color.White
    End Sub
    Public Overrides Function _PMOValidarCampos() As Boolean
        Dim _ok As Boolean = True
        MEP.Clear()

        'If tbCi.Text = String.Empty Then
        '    tbCi.BackColor = Color.Red
        '    MEP.SetError(tbCi, "ingrese Cedula de Identidad!".ToUpper)
        '    _ok = False
        'Else
        '    tbCi.BackColor = Color.White
        '    MEP.SetError(tbCi, "")
        'End If

        'If tbFnac.Text = String.Empty Then
        '    tbFnac.BackColor = Color.Red
        '    MEP.SetError(tbFnac, "Seleccione su fecha de nacimiento!".ToUpper)
        '    _ok = False
        'Else
        '    tbFnac.BackColor = Color.White
        '    MEP.SetError(tbFnac, "")
        'End If

        If tbnombre.Text = String.Empty Then
            tbnombre.BackColor = Color.Red
            MEP.SetError(tbnombre, "ingrese Dato en el campo Nombre !".ToUpper)
            _ok = False
        Else
            tbnombre.BackColor = Color.White
            MEP.SetError(tbnombre, "")
        End If

        'If tbDir.Text = String.Empty Then
        '    tbDir.BackColor = Color.Red
        '    MEP.SetError(tbDir, "ingrese su Direccion de domicilio o lugar donde vive!".ToUpper)
        '    _ok = False
        'Else
        '    tbDir.BackColor = Color.White
        '    MEP.SetError(tbDir, "")
        'End If
        'If tbEmail.Text = String.Empty Then
        '    tbEmail.BackColor = Color.Red
        '    MEP.SetError(tbEmail, "ingrese su direccion de correo electronico!".ToUpper)
        '    _ok = False
        'Else
        '    tbEmail.BackColor = Color.White
        '    MEP.SetError(tbEmail, "")
        'End If
        'If tbTel1.Text = String.Empty Then
        '    tbTel1.BackColor = Color.Red
        '    MEP.SetError(tbTel1, "ingrese su numero de Telefono o Celular!".ToUpper)
        '    _ok = False
        'Else
        '    tbTel1.BackColor = Color.White
        '    MEP.SetError(tbTel1, "")
        'End If


        MHighlighterFocus.UpdateHighlights()
        Return _ok
    End Function
    Public Overrides Function _PMOGetListEstructuraBuscador() As List(Of Modelos.Celda)
        Dim listEstCeldas As New List(Of Modelos.Celda)

        't.canumi , t.canombre, t.cacuenta, t.caobs, t.cafact, t.cahact, t.cauact 
        listEstCeldas.Add(New Modelos.Celda("canumi", True, "CODIGO", 150))
        listEstCeldas.Add(New Modelos.Celda("canombre", True, "NOMBRE", 280))
        listEstCeldas.Add(New Modelos.Celda("cacuenta", True, "CUENTA", 220))
        listEstCeldas.Add(New Modelos.Celda("caobs", True, "OBSERVACION", 350))
        listEstCeldas.Add(New Modelos.Celda("img", True, "IMAGEN", 150))
        listEstCeldas.Add(New Modelos.Celda("cafact", False))
        listEstCeldas.Add(New Modelos.Celda("caimage", False))
        listEstCeldas.Add(New Modelos.Celda("cahact", False))
        listEstCeldas.Add(New Modelos.Celda("cauact", False))

        Return listEstCeldas


    End Function
    Public Overrides Function _PMOGetTablaBuscador() As DataTable
        Dim dtBuscador As DataTable = L_prBancoGeneral()
        Return dtBuscador
    End Function



    Public Overrides Sub _PMOMostrarRegistro(_N As Integer)
        JGrM_Buscador.Row = _MPos

        't.canumi , t.canombre, t.cacuenta, t.caobs, t.cafact, t.cahact, t.cauact 
        With JGrM_Buscador
            tbcodigo.Text = .GetValue("canumi").ToString
            tbnombre.Text = .GetValue("canombre").ToString
            tbcuenta.Text = .GetValue("cacuenta").ToString
            tbobservacion.Text = .GetValue("caobs").ToString
            lbFecha.Text = CType(.GetValue("cafact"), Date).ToString("dd/MM/yyyy")
            lbHora.Text = .GetValue("cahact").ToString
            lbUsuario.Text = .GetValue("cauact").ToString

        End With
        Dim name As String = JGrM_Buscador.GetValue("caimage")
        If name.Equals("Default.jpg") Or Not File.Exists(RutaGlobal + "\Imagenes\Imagenes Faubrica" + name) Then

            Dim im As New Bitmap(My.Resources.imageDefault)
            UsImg.Image = im
        Else
            If (File.Exists(RutaGlobal + "\Imagenes\Imagenes Faubrica" + name)) Then
                Dim Bin As New MemoryStream
                Dim im As New Bitmap(New Bitmap(RutaGlobal + "\Imagenes\Imagenes Faubrica" + name), 180, 157)
                im.Save(Bin, System.Drawing.Imaging.ImageFormat.Jpeg)
                UsImg.Image = Image.FromStream(Bin)
                Bin.Dispose()

            End If
        End If
        _prDibujarImagenes()
        LblPaginacion.Text = Str(_MPos + 1) + "/" + JGrM_Buscador.RowCount.ToString




    End Sub
    Public Overrides Function _PMOGrabarRegistro() As Boolean



        Dim res As Boolean = L_prBancoGrabar(tbcodigo.Text, tbnombre.Text, tbcuenta.Text, tbobservacion.Text, nameImg)
        If res Then

            Modificado = False
            _fnMoverImagenRuta(RutaGlobal + "\Imagenes\Imagenes Faubrica", nameImg)
            nameImg = "Default.jpg"

            ToastNotification.Show(Me, "Codigo de BANCO ".ToUpper + tbcodigo.Text + " Grabado con Exito.".ToUpper, My.Resources.GRABACION_EXITOSA, 5000, eToastGlowColor.Green, eToastPosition.TopCenter)
        End If
        Return res

    End Function
    Public Overrides Function _PMOModificarRegistro() As Boolean
        Dim tipo As Integer = 1
        Dim nsoc As Integer = 1
        Dim res As Boolean
        Dim nameImage As String = JGrM_Buscador.GetValue("caimage")
        If (Modificado = False) Then
            res = L_prBancoModificar(tbcodigo.Text, tbnombre.Text, tbcuenta.Text, tbobservacion.Text, nameImage)

        Else
            res = L_prBancoModificar(tbcodigo.Text, tbnombre.Text, tbcuenta.Text, tbobservacion.Text, nameImg)
        End If





        If res Then


            If (Modificado = True) Then
                _fnMoverImagenRuta(RutaGlobal + "\Imagenes\Imagenes Faubrica", nameImg)
                Modificado = False
            End If

            ToastNotification.Show(Me, "Codigo de BANCO ".ToUpper + tbcodigo.Text + " modificado con Exito.".ToUpper, My.Resources.GRABACION_EXITOSA, 5000, eToastGlowColor.Green, eToastPosition.TopCenter)
        End If
        Return res
    End Function
    Public Sub _PrEliminarImage()

        If (Not (_fnActionNuevo()) And (File.Exists(RutaGlobal + "\Imagenes\Imagenes Faubrica\Imagen_" + tbcodigo.Text + ".jpg"))) Then
            UsImg.Image.Dispose()
            UsImg.Image = Nothing
            Try
                My.Computer.FileSystem.DeleteFile(RutaGlobal + "\Imagenes\Imagenes Faubrica\Imagen_" + tbcodigo.Text + ".jpg")
            Catch ex As Exception

            End Try


        End If
    End Sub

    Public Overrides Sub _PMOEliminarRegistro()
        Dim info As New TaskDialogInfo("¿esta seguro de eliminar el registro?".ToUpper, eTaskDialogIcon.Delete, "advertencia".ToUpper, "mensaje principal".ToUpper, eTaskDialogButton.Yes Or eTaskDialogButton.Cancel, eTaskDialogBackgroundColor.Blue)
        Dim result As eTaskDialogResult = TaskDialog.Show(info)
        If result = eTaskDialogResult.Yes Then
            Dim mensajeError As String = ""
            Dim res As Boolean = L_prBancoBorrar(tbcodigo.Text, mensajeError)
            If res Then

                _PrEliminarImage()
                ToastNotification.Show(Me, "Codigo de Banco ".ToUpper + tbcodigo.Text + " eliminado con Exito.".ToUpper, My.Resources.GRABACION_EXITOSA, 5000, eToastGlowColor.Green, eToastPosition.TopCenter)
                _PMFiltrar()
            Else
                ToastNotification.Show(Me, mensajeError, My.Resources.WARNING, 8000, eToastGlowColor.Red, eToastPosition.TopCenter)
            End If
        End If
    End Sub
    Private Function _fnCopiarImagenRutaDefinida() As String
        'copio la imagen en la carpeta del sistema

        Dim file As New OpenFileDialog()
        file.Filter = "Ficheros JPG o JPEG o PNG|*.jpg;*.jpeg;*.png" &
                      "|Ficheros GIF|*.gif" &
                      "|Ficheros BMP|*.bmp" &
                      "|Ficheros PNG|*.png" &
                      "|Ficheros TIFF|*.tif"
        If file.ShowDialog() = DialogResult.OK Then
            Dim ruta As String = file.FileName


            If file.CheckFileExists = True Then
                Dim img As New Bitmap(New Bitmap(ruta), 500, 300)
                Dim imgM As New Bitmap(New Bitmap(ruta), 180, 157)
                Dim Bin As New MemoryStream
                imgM.Save(Bin, System.Drawing.Imaging.ImageFormat.Jpeg)
                Dim a As Object = file.GetType.ToString
                If (_fnActionNuevo()) Then

                    Dim pos, mayor As Integer
                    Dim length As Integer = CType(JGrM_Buscador.DataSource, DataTable).Rows.Count
                    _prFabrica_ObtenerMayorDataSource(mayor, pos, length)
                    nameImg = "\Imagen_" + Str(mayor + 1).Trim + ".jpg"

                    UsImg.Image = Image.FromStream(Bin)

                    img.Save(RutaTemporal + nameImg, System.Drawing.Imaging.ImageFormat.Jpeg)
                    img.Dispose()
                Else

                    nameImg = "\Imagen_" + Str(tbcodigo.Text).Trim + ".jpg"


                    UsImg.Image = Image.FromStream(Bin)
                    img.Save(RutaTemporal + nameImg, System.Drawing.Imaging.ImageFormat.Jpeg)
                    Modificado = True
                    img.Dispose()

                End If
            End If

            Return nameImg
        End If

        Return "default.jpg"
    End Function
    Private Sub _prFabrica_ObtenerMayorDataSource(ByRef _mayor As Integer, ByRef _posicion As Integer, ByVal _lenght As Integer)

        _posicion = -1
        _mayor = 0
        If (_lenght >= 1) Then
            _posicion = 0
            _mayor = CType(JGrM_Buscador.DataSource, DataTable).Rows(_lenght - 1).Item("canumi")
        End If


    End Sub

    Private Sub F1_Bancos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _prIniciarTodo()

    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        tbnombre.Focus()

    End Sub

    Private Sub ButtonX1_Click(sender As Object, e As EventArgs) Handles btnImg.Click
        _fnCopiarImagenRutaDefinida()
    End Sub
#End Region




End Class