



Imports Logica.AccesoLogica
Imports Janus.Windows.GridEX
Imports DevComponents.DotNetBar
Imports System.IO
Imports DevComponents.DotNetBar.SuperGrid

Public Class F1_CLIENTE_H


#Region "Variables Globales"


    Dim RutaGlobal As String = gs_CarpetaRaiz
    Dim RutaTemporal As String = "C:\Temporal"
    Dim Modificado As Boolean = False ''Esta Variable me creo para saber si una imagen ya insertada de la base de datos fue modificada estado=1
    Dim nameImg As String = "Default.jpg" ''Variable Global para tener los nombres de las imagenes
    Dim Socio As Boolean = False
    Public _nameButton As String
#End Region


#Region "METODOS PRIVADOS"
    Private Sub _prIniciarTodo()

        Me.Text = "C L I E N T E S"
        _PMIniciarTodo()
        _prAsignarPermisos()
        GroupPanelBuscador.Style.BackColor = Color.FromArgb(13, 71, 161)
        GroupPanelBuscador.Style.BackColor2 = Color.FromArgb(13, 71, 161)
        GroupPanelBuscador.Style.TextColor = Color.White
        Dim blah As Bitmap = My.Resources.cliente
        Dim ico As Icon = Icon.FromHandle(blah.GetHicon())
        Me.Icon = ico
        JGrM_Buscador.RootTable.HeaderFormatStyle.FontBold = TriState.True
        _prCargarLengthTextbox()
    
        If (tbNSoc.Text <> String.Empty) Then
            If (tbNSoc.Text > 0) Then
                btnModificar.Enabled = False
                btnEliminar.Enabled = False
            End If
        End If
    End Sub
    Public Function _fnExisteClienteCI(_ci As String, ByRef _pos As Integer) As Boolean
        Dim length As Integer = CType(JGrM_Buscador.DataSource, DataTable).Rows.Count
        For i As Integer = 0 To length - 1
            Dim dataci As String = CType(JGrM_Buscador.DataSource, DataTable).Rows(i).Item("haci")
            If (_ci.Equals(dataci)) Then
                _pos = i
                Return True
            End If

        Next
        Return False
    End Function
    Public Sub _PrEliminarImage()
        If (Not (_fnActionNuevo()) And (File.Exists(RutaGlobal + "\Imagenes\Imagenes ClienteH\Imagen_ " + tbNumi.Text + ".jpg"))) Then
            UsImg.pbImage.Image.Dispose()
            UsImg.pbImage.Image = Nothing
            Try
                My.Computer.FileSystem.DeleteFile(RutaGlobal + "\Imagenes\Imagenes ClienteH\Imagen_ " + tbNumi.Text + ".jpg")
            Catch ex As Exception

            End Try
        End If
    End Sub
    Public Sub _prCargarLengthTextbox()
        tbNSoc.MaxLength = 10
        tbTel1.MaxLength = 10
        tbTel2.MaxLength = 10
        tbNombre.MaxLength = 30
        tbDir.MaxLength = 35
        tbEmail.MaxLength = 50
        tbCi.MaxLength = 20

    End Sub
    Private Sub _fnMoverImagenRuta(Folder As String, name As String)
        'copio la imagen en la carpeta del sistema
        If (Not name.Equals("Default.jpg") And File.Exists(RutaTemporal + name)) Then
            UsImg.pbImage.Image.Dispose()
            UsImg.pbImage.Image = Nothing
            Try
                My.Computer.FileSystem.CopyFile(RutaTemporal + name,
     Folder + name, overwrite:=True)
            Catch ex As Exception

            End Try


        End If
    End Sub


    Private Sub _prCargarComboLibreria(mCombo As Janus.Windows.GridEX.EditControls.MultiColumnCombo, cod1 As String, cod2 As String)
        Dim dt As New DataTable
        dt = L_prLibreriaClienteHGeneral(cod1, cod2)

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
    'Public Sub _prDibujarImagenes()
    '    Dim length As Integer = CType(JGrM_Buscador.DataSource, DataTable).Rows.Count
    '    For i As Integer = 0 To length - 1 Step 1
    '        Dim nameImagen As String = CType(JGrM_Buscador.DataSource, DataTable).Rows(i).Item("hafot")
    '        If (nameImagen.Equals("Default.jpg")) Then
    '            Dim Bin As New MemoryStream
    '            Dim img As New Bitmap(My.Resources.imageDefault, 130, 80)
    '            img.Save(Bin, Imaging.ImageFormat.Jpeg)
    '            Bin.Dispose()

    '            CType(JGrM_Buscador.DataSource, DataTable).Rows(i).Item("img") = Bin.GetBuffer
    '        Else
    '            Dim Bin As New MemoryStream
    '            If (File.Exists(RutaGlobal + "\Imagenes\Imagenes ClienteH" + nameImagen)) Then
    '                Dim img As New Bitmap(New Bitmap(RutaGlobal + "\Imagenes\Imagenes ClienteH" + nameImagen), 130, 80)
    '                img.Save(Bin, Imaging.ImageFormat.Jpeg)
    '                CType(JGrM_Buscador.DataSource, DataTable).Rows(i).Item("img") = Bin.GetBuffer
    '                Bin.Dispose()
    '            Else

    '                Dim img As New Bitmap(My.Resources.imageDefault, 130, 80)
    '                img.Save(Bin, Imaging.ImageFormat.Jpeg)
    '                Bin.Dispose()

    '                CType(JGrM_Buscador.DataSource, DataTable).Rows(i).Item("img") = Bin.GetBuffer

    '            End If



    '        End If
    '    Next
    'End Sub
    Public Shared Function imgToByteConverter(ByVal inImg As Image) As Byte()
        Dim imgCon As New ImageConverter()
        Return DirectCast(imgCon.ConvertTo(inImg, GetType(Byte())), Byte())
    End Function
    Private Sub _prCrearCarpetaImagenes()
        Dim rutaDestino As String = RutaGlobal + "\Imagenes\Imagenes ClienteH\"

        If System.IO.Directory.Exists(RutaGlobal + "\Imagenes\Imagenes ClienteH\") = False Then
            If System.IO.Directory.Exists(RutaGlobal + "\Imagenes") = False Then
                System.IO.Directory.CreateDirectory(RutaGlobal + "\Imagenes")
                If System.IO.Directory.Exists(RutaGlobal + "\Imagenes\Imagenes ClienteH") = False Then
                    System.IO.Directory.CreateDirectory(RutaGlobal + "\Imagenes\Imagenes ClienteH")
                End If
            Else
                If System.IO.Directory.Exists(RutaGlobal + "\Imagenes\Imagenes ClienteH") = False Then
                    System.IO.Directory.CreateDirectory(RutaGlobal + "\Imagenes\Imagenes ClienteH")

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
    Private Sub _prInsumos_ObtenerMayorDataSource(ByRef _mayor As Integer, ByRef _posicion As Integer, ByVal _lenght As Integer)

        _posicion = -1
        _mayor = 0
        If (_lenght >= 1) Then
            _posicion = 0
            _mayor = CType(JGrM_Buscador.DataSource, DataTable).Rows(0).Item("hanumi")
        End If
        For i As Integer = 1 To _lenght - 1 Step 1
            Dim a As Integer
            a = CType(JGrM_Buscador.DataSource, DataTable).Rows(i).Item("hanumi")
            If ((a >= _mayor)) Then
                _mayor = CType(JGrM_Buscador.DataSource, DataTable).Rows(i).Item("hanumi")
                _posicion = i

            End If
        Next


    End Sub
    
    Private Function _fnActionNuevo() As Boolean
        'Funcion que me devuelve True si esta en la actividad crear nuevo Tipo de Equipo
        Return tbNumi.Text.ToString.Equals("") And tbCi.ReadOnly = False

    End Function
    Private Function _fnCopiarImagenRutaDefinida() As String
        'copio la imagen en la carpeta del sistema

        Dim file As New OpenFileDialog()
        file.Filter = "Ficheros JPG o JPEG o PNG|*.jpg;*.jpeg;*.png" & _
                      "|Ficheros GIF|*.gif" & _
                      "|Ficheros BMP|*.bmp" & _
                      "|Ficheros PNG|*.png" & _
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
                    _prInsumos_ObtenerMayorDataSource(mayor, pos, length)
                    nameImg = "\Imagen_" + Str(mayor + 1) + ".jpg"
                   
                    UsImg.pbImage.Image = Image.FromStream(Bin)

                    img.Save(RutaTemporal + nameImg, System.Drawing.Imaging.ImageFormat.Jpeg)
                    img.Dispose()
                Else

                    nameImg = "\Imagen_" + Str(tbNumi.Text) + ".jpg"
                 

                    UsImg.pbImage.Image = Image.FromStream(Bin)
                    img.Save(RutaTemporal + nameImg, System.Drawing.Imaging.ImageFormat.Jpeg)
                    Modificado = True
                    img.Dispose()
                End If


            End If
            Return nameImg
        End If

        Return "default.jpg"
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
#End Region





#Region "METODOS SOBREESCRITOS"



    Public Overrides Sub _PMOHabilitar()
        tbNSoc.ReadOnly = False
        tbCi.ReadOnly = False
        tbNombre.ReadOnly = False
        tbDir.ReadOnly = False
        tbEmail.ReadOnly = False
        tbFnac.Enabled = True
        tbTel1.ReadOnly = False
        tbTel2.ReadOnly = False
        tbObs.ReadOnly = False
        tbFIngr.Enabled = True
        tbEstado.IsReadOnly = False
        tbEstado.Value = True
        BtnCargarImage.Visible = True
        nameImg = "Default.jpg"
        _prCrearCarpetaImagenes()
        _prCrearCarpetaTemporal()
    End Sub
    Public Overrides Sub _PMOInhabilitar()
        tbNumi.ReadOnly = True
        tbNSoc.ReadOnly = True
        tbCi.ReadOnly = True
        tbNombre.ReadOnly = True
        tbDir.ReadOnly = True
        tbEmail.ReadOnly = True
        tbFnac.Enabled = False
        tbTel1.ReadOnly = True
        tbTel2.ReadOnly = True
        tbObs.ReadOnly = True
        tbFIngr.Enabled = False
        tbEstado.IsReadOnly = True
        BtnCargarImage.Visible = False

    End Sub
    Public Overrides Sub _PMOHabilitarFocus()
        With MHighlighterFocus
            .SetHighlightOnFocus(tbNSoc, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
            .SetHighlightOnFocus(tbCi, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
            .SetHighlightOnFocus(tbNombre, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
            .SetHighlightOnFocus(tbDir, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
            .SetHighlightOnFocus(tbEmail, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
            .SetHighlightOnFocus(tbFnac, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
            .SetHighlightOnFocus(tbTel1, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
            .SetHighlightOnFocus(tbTel2, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
            .SetHighlightOnFocus(tbObs, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
            .SetHighlightOnFocus(tbFIngr, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
            .SetHighlightOnFocus(tbEstado, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
            .SetHighlightOnFocus(BtnCargarImage, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
        End With
    End Sub
    Public Overrides Sub _PMOLimpiar()


        tbNumi.Text = ""
        tbNSoc.Text = ""
        tbCi.Text = ""
        tbNombre.Text = ""
        tbDir.Text = ""
        tbEmail.Text = ""
        tbTel1.Text = ""
        tbTel2.Text = ""
        tbObs.Text = ""
        tbEstado.Value = True
        Dim img As New Bitmap(New Bitmap(My.Resources.imageDefault), 180, 157)
        UsImg.pbImage.Image = img

    End Sub
    Public Overrides Sub _PMOLimpiarErrores()

        MEP.Clear()
        tbNSoc.BackColor = Color.White
        tbCi.BackColor = Color.White
        tbNombre.BackColor = Color.White
        tbDir.BackColor = Color.White
        tbEmail.BackColor = Color.White
        tbTel1.BackColor = Color.White
        tbTel2.BackColor = Color.White
        tbObs.BackColor = Color.White
        tbFnac.BackColor = Color.White

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
      
        If tbNombre.Text = String.Empty Then
            tbNombre.BackColor = Color.Red
            MEP.SetError(tbNombre, "ingrese su Nombre Completo!".ToUpper)
            _ok = False
        Else
            tbNombre.BackColor = Color.White
            MEP.SetError(tbNombre, "")
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
        listEstCeldas.Add(New Modelos.Celda("hanumi", False, "ID", 50))
        listEstCeldas.Add(New Modelos.Celda("hatipo", False))
        listEstCeldas.Add(New Modelos.Celda("cedesc1", False, "TIPO", 120))
        listEstCeldas.Add(New Modelos.Celda("hansoc", True, "NRO SOCIO", 100))
        listEstCeldas.Add(New Modelos.Celda("hafing", False, "FECHA DE INGRESO", 200))
        listEstCeldas.Add(New Modelos.Celda("hafnac", False, "FECHA DE NACIMIENTO", 170))
        listEstCeldas.Add(New Modelos.Celda("hanom", True, "NOMBRES", 300))
        listEstCeldas.Add(New Modelos.Celda("haapat", False, "APELLIDO PATERNO", 150))
        listEstCeldas.Add(New Modelos.Celda("haamat", False, "APELLIDO MATERNO", 150))

        listEstCeldas.Add(New Modelos.Celda("hadir", True, "DIRECCION", 350))
        listEstCeldas.Add(New Modelos.Celda("haemail", True, "CORREO ELECTRONICO", 300))
        listEstCeldas.Add(New Modelos.Celda("haci", True, "CI", 120))
        listEstCeldas.Add(New Modelos.Celda("hafot", False))
        listEstCeldas.Add(New Modelos.Celda("img", False, "IMAGEN", 150))

        listEstCeldas.Add(New Modelos.Celda("haobs", False, "OBSERVACION", 100))
        listEstCeldas.Add(New Modelos.Celda("haest", False))
        listEstCeldas.Add(New Modelos.Celda("estado", True, "ESTADO", 80))
        listEstCeldas.Add(New Modelos.Celda("hatelf1", True, "TELEFONO 1", 100))
        listEstCeldas.Add(New Modelos.Celda("hatelf2", False, "TELEFONO 2", 100))

        listEstCeldas.Add(New Modelos.Celda("hafact", False))
        listEstCeldas.Add(New Modelos.Celda("hahact", False))
        listEstCeldas.Add(New Modelos.Celda("hauact", False))

        Return listEstCeldas


    End Function
    Public Overrides Function _PMOGetTablaBuscador() As DataTable
        Dim dtBuscador As DataTable = L_prClienteHGeneral("13", "1")
        Return dtBuscador
    End Function

   
    Public Overrides Sub _PMOMostrarRegistro(_N As Integer)
        JGrM_Buscador.Row = _MPos

        With JGrM_Buscador
            tbNSoc.Text = .GetValue("hansoc").ToString
            tbCi.Text = .GetValue("haci").ToString
            tbNombre.Text = .GetValue("hanom").ToString
            tbDir.Text = .GetValue("hadir").ToString
            tbEmail.Text = .GetValue("haemail").ToString
            tbTel1.Text = .GetValue("hatelf1").ToString
            tbTel2.Text = .GetValue("hatelf2").ToString
            tbObs.Text = .GetValue("haobs").ToString
            tbNumi.Text = .GetValue("hanumi").ToString
            lbFecha.Text = CType(.GetValue("hafact"), Date).ToString("dd/MM/yyyy")
            lbHora.Text = .GetValue("hahact").ToString
            lbUsuario.Text = .GetValue("hauact").ToString
            tbFnac.Text = .GetValue("hafnac")
            tbFIngr.Text = .GetValue("hafing")
        End With
        Dim est As Integer = JGrM_Buscador.GetValue("haest")
        If (est = 1) Then
            tbEstado.Value = True
        Else
            tbEstado.Value = False

        End If
        Dim name As String = JGrM_Buscador.GetValue("hafot")
        If name.Equals("Default.jpg") Or Not File.Exists(RutaGlobal + "\Imagenes\Imagenes ClienteH" + name) Then
            Dim im As New Bitmap(My.Resources.imageDefault)


            UsImg.pbImage.Image = im
        Else
            If (File.Exists(RutaGlobal + "\Imagenes\Imagenes ClienteH" + name)) Then
                Dim Bin As New MemoryStream
                Dim im As New Bitmap(New Bitmap(RutaGlobal + "\Imagenes\Imagenes ClienteH" + name), 180, 157)
                im.Save(Bin, System.Drawing.Imaging.ImageFormat.Jpeg)
                UsImg.pbImage.Image = Image.FromStream(Bin)
                Bin.Dispose()

            End If


        End If

        If (tbNSoc.Text <> String.Empty And tbNSoc.Text > 0) Then
            btnModificar.Enabled = False
            btnEliminar.Enabled = False

        Else
            btnModificar.Enabled = True
            btnEliminar.Enabled = True

        End If

        LblPaginacion.Text = Str(_MPos + 1) + "/" + JGrM_Buscador.RowCount.ToString

    End Sub
    Public Overrides Function _PMOGrabarRegistro() As Boolean
        Dim res As Boolean = L_prClienteHGrabar(tbNumi.Text, 0, tbNSoc.Text, tbFIngr.Value.ToString("yyyy/MM/dd"), tbFnac.Value.ToString("yyyy/MM/dd"), tbNombre.Text, "", "", tbDir.Text, tbEmail.Text, tbCi.Text, nameImg, tbObs.Text, IIf(tbEstado.Value = True, 1, 0), tbTel1.Text, tbTel2.Text)
        If res Then
            Modificado = False
            _fnMoverImagenRuta(RutaGlobal + "\Imagenes\Imagenes ClienteH", nameImg)
            ToastNotification.Show(Me, "Codigo de Cliente ".ToUpper + tbNumi.Text + " Grabado con Exito.".ToUpper, My.Resources.GRABACION_EXITOSA, 5000, eToastGlowColor.Green, eToastPosition.TopCenter)
        End If
        Return res

    End Function
    Public Overrides Function _PMOModificarRegistro() As Boolean
    
        Dim res As Boolean
        Dim b As Boolean = Modificado
        Dim nameImage As String = JGrM_Buscador.GetValue("hafot")
        If (Modificado = False) Then
            res = L_prClienteHModificar(tbNumi.Text, 0, tbNSoc.Text, tbFIngr.Value.ToString("yyyy/MM/dd"), tbFnac.Value.ToString("yyyy/MM/dd"), tbNombre.Text, "", "", tbDir.Text, tbEmail.Text, tbCi.Text, nameImage, tbObs.Text, IIf(tbEstado.Value = True, 1, 0), tbTel1.Text, tbTel2.Text)
        Else
            res = L_prClienteHModificar(tbNumi.Text, 0, tbNSoc.Text, tbFIngr.Value.ToString("yyyy/MM/dd"), tbFnac.Value.ToString("yyyy/MM/dd"), tbNombre.Text, "", "", tbDir.Text, tbEmail.Text, tbCi.Text, nameImg, tbObs.Text, IIf(tbEstado.Value = True, 1, 0), tbTel1.Text, tbTel2.Text)

        End If
        If res Then


            If (Modificado = True) Then
                _fnMoverImagenRuta(RutaGlobal + "\Imagenes\Imagenes ClienteH", nameImg)
                Modificado = False
            End If

            ToastNotification.Show(Me, "Codigo de Cliente ".ToUpper + tbNumi.Text + " modificado con Exito.".ToUpper, My.Resources.GRABACION_EXITOSA, 5000, eToastGlowColor.Green, eToastPosition.TopCenter)
        End If
        Return res
    End Function


    Public Overrides Sub _PMOEliminarRegistro()
        Dim info As New TaskDialogInfo("¿esta seguro de eliminar el registro?".ToUpper, eTaskDialogIcon.Delete, "advertencia".ToUpper, "mensaje principal".ToUpper, eTaskDialogButton.Yes Or eTaskDialogButton.Cancel, eTaskDialogBackgroundColor.Blue)
        Dim result As eTaskDialogResult = TaskDialog.Show(info)
        If result = eTaskDialogResult.Yes Then
            Dim mensajeError As String = ""
            Dim res As Boolean = L_prClienteHBorrar(tbNumi.Text, mensajeError)
            If res Then
                _PrEliminarImage()
                ToastNotification.Show(Me, "Codigo de Cliente ".ToUpper + tbNumi.Text + " eliminado con Exito.".ToUpper, My.Resources.GRABACION_EXITOSA, 5000, eToastGlowColor.Green, eToastPosition.TopCenter)
                _PMFiltrar()

            Else
                ToastNotification.Show(Me, mensajeError, My.Resources.WARNING, 8000, eToastGlowColor.Red, eToastPosition.TopCenter)
            End If
        End If

    End Sub
#End Region
#Region "Eventos Formulario"
    Private Sub F1_Insumos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _prIniciarTodo()

    End Sub



    Private Sub LabelX7_MouseHover(sender As Object, e As EventArgs)
        MHighlighterFocus.SetHighlightOnFocus(UsImg, DevComponents.DotNetBar.Validator.eHighlightColor.Custom)

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles BtnCargarImage.Click
        _fnCopiarImagenRutaDefinida()
        btnGrabar.Focus()


    End Sub

    Private Sub tbNSoc_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbNSoc.KeyPress


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

        tbNSoc.Text = Trim(Replace(tbNSoc.Text, "  ", " "))
        tbNSoc.Select(tbNSoc.Text.Length, 0)


    End Sub


    Private Sub tbCi_Leave(sender As Object, e As EventArgs) Handles tbCi.Leave

        Dim pos As Integer = -1
        If btnGrabar.Enabled = False Or _MNuevo = False Then
            Exit Sub
        End If

        If (Not tbCi.Text.Equals("")) Then

            If (_fnExisteClienteCI(tbCi.Text, pos)) Then
                Dim mensaje As String = "el 'ci' que ingreso ya esta registrado con los siguientes datos: ".ToUpper + vbCrLf + _
                                        "nombre          : ".ToUpper + CType(JGrM_Buscador.DataSource, DataTable).Rows(pos).Item("hanom").ToString + vbCrLf + _
                                        "apellido paterno: ".ToUpper + CType(JGrM_Buscador.DataSource, DataTable).Rows(pos).Item("haapat").ToString + vbCrLf + _
                                        "apellido materno: ".ToUpper + CType(JGrM_Buscador.DataSource, DataTable).Rows(pos).Item("haamat").ToString + vbCrLf + _
                                        "fecha nacimiento: ".ToUpper + CType(JGrM_Buscador.DataSource, DataTable).Rows(pos).Item("hafnac").ToString

                'ToastNotification.Show(Me, mensaje.ToUpper, My.Resources.WARNING, 10000, eToastGlowColor.Red, eToastPosition.TopCenter)


                Dim info As New TaskDialogInfo("advertencia".ToUpper, eTaskDialogIcon.Delete, "¿desea continuar?".ToUpper, mensaje.ToUpper, eTaskDialogButton.Yes Or eTaskDialogButton.No, eTaskDialogBackgroundColor.Blue)
                Dim result As eTaskDialogResult = TaskDialog.Show(info)
                If result = eTaskDialogResult.Yes Then

                Else
                    tbCi.Text = ""
                    tbCi.Focus()
                End If
            End If

        End If

    End Sub

    Private Sub tbTel1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbTel1.KeyPress
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

        tbTel1.Text = Trim(Replace(tbTel1.Text, "  ", " "))
        tbTel1.Select(tbTel1.Text.Length, 0)

    End Sub

    Private Sub tbTel2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbTel2.KeyPress
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

        tbTel2.Text = Trim(Replace(tbTel2.Text, "  ", " "))
        tbTel2.Select(tbTel2.Text.Length, 0)
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click

        tbCi.Focus()

    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click

        tbCi.Focus()
    End Sub

#End Region
 
    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click

    End Sub
End Class