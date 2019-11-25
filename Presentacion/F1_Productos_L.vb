
Imports Logica.AccesoLogica
Imports Janus.Windows.GridEX
Imports DevComponents.DotNetBar
Imports System.IO
Imports DevComponents.DotNetBar.SuperGrid
Public Class F1_Productos_L
    Dim RutaGlobal As String = gs_CarpetaRaiz
    Dim RutaTemporal As String = "C:\Temporal"
    Dim Modificado As Boolean = False
    Dim nameImg As String = "Default.jpg"
    Public _nameButton As String


#Region "METODOS PRIVADOS"
    Private Sub _prIniciarTodo()


        Me.Text = "P R O D U C T O S"
        _prCargarComboLibreria(cbGrupo, 16, 1)
        _prCargarComboLibreria(cbUMedida, 16, 2)
        _PMIniciarTodo()

        _prAsignarPermisos()

        GroupPanelBuscador.Style.BackColor = Color.FromArgb(13, 71, 161)
        GroupPanelBuscador.Style.BackColor2 = Color.FromArgb(13, 71, 161)
        GroupPanelBuscador.Style.TextColor = Color.White
        JGrM_Buscador.RootTable.HeaderFormatStyle.FontBold = TriState.True
        _prMaxLengthTextbox()

        _prEstructuraJanusPrincipal()
        cbGrupo.MaxLength = 30
        cbUMedida.MaxLength = 30

    End Sub
    Public Sub _prEstructuraJanusPrincipal()
        JGrM_Buscador.RootTable.Columns("ldprec").FormatString = "0.00"
        JGrM_Buscador.RootTable.Columns("ldprev").FormatString = "0.00"
    End Sub
    Public Sub _prMaxLengthTextbox()
        tbcdprod1.MaxLength = 50
        tbsmin.MaxLength = 10

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
   
    Public Shared Function imgToByteConverter(ByVal inImg As Image) As Byte()
        Dim imgCon As New ImageConverter()
        Return DirectCast(imgCon.ConvertTo(inImg, GetType(Byte())), Byte())
    End Function
    Private Sub _prCrearCarpetaImagenes()
        Dim rutaDestino As String = RutaGlobal + "\Imagenes\Imagenes Productos\"

        If System.IO.Directory.Exists(RutaGlobal + "\Imagenes\Imagenes Productos\") = False Then
            If System.IO.Directory.Exists(RutaGlobal + "\Imagenes") = False Then
                System.IO.Directory.CreateDirectory(RutaGlobal + "\Imagenes")
                If System.IO.Directory.Exists(RutaGlobal + "\Imagenes\Imagenes Productos") = False Then
                    System.IO.Directory.CreateDirectory(RutaGlobal + "\Imagenes\Imagenes Productos")
                End If
            Else
                If System.IO.Directory.Exists(RutaGlobal + "\Imagenes\Imagenes Productos") = False Then
                    System.IO.Directory.CreateDirectory(RutaGlobal + "\Imagenes\Imagenes Productos")

                End If
            End If
        End If
    End Sub
    Private Sub _prCrearCarpetaTemporal()

        If System.IO.Directory.Exists(RutaTemporal) = False Then
            System.IO.Directory.CreateDirectory(RutaTemporal)
        Else
            '' pbImage.Image.Dispose()
            My.Computer.FileSystem.DeleteDirectory(RutaTemporal, FileIO.DeleteDirectoryOption.DeleteAllContents)
            My.Computer.FileSystem.CreateDirectory(RutaTemporal)

        End If

    End Sub
    Private Sub _prProducto_ObtenerMayorDataSource(ByRef _mayor As Integer, ByRef _posicion As Integer, ByVal _lenght As Integer)

        _posicion = -1
        _mayor = 0
        If (_lenght >= 1) Then
            _posicion = 0
            _mayor = CType(JGrM_Buscador.DataSource, DataTable).Rows(0).Item("ldnumi")
        End If
        For i As Integer = 1 To _lenght - 1 Step 1
            Dim a As Integer
            a = CType(JGrM_Buscador.DataSource, DataTable).Rows(i).Item("ldnumi")
            If ((a >= _mayor)) Then
                _mayor = CType(JGrM_Buscador.DataSource, DataTable).Rows(i).Item("ldnumi")
                _posicion = i

            End If
        Next


    End Sub
    Public Function _fnBytesArchivo(ruta As String) As Byte()

        If Not (ruta.Equals(" ")) Then ' esta sería una función que verifica que realmente existe el archivo, devolviendo true o false...

            Return IO.File.ReadAllBytes(ruta)

        Else

            Throw New Exception("No se encuentra el archivo: " & ruta)

        End If

    End Function
    Private Function _fnActionNuevo() As Boolean
        'Funcion que me devuelve True si esta en la actividad crear nuevo Tipo de Equipo
        Return tbNumi.Text.ToString.Equals("")
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
                Dim img As New Bitmap(New Bitmap(ruta), 400, 300)
                Dim imgpb As New Bitmap(New Bitmap(ruta), 180, 157)
                Dim a As Object = file.GetType.ToString
                If (_fnActionNuevo()) Then
                    '   MsgBox("Accion Nuevo" + Str(_fnGenerarNumiTipoEquipo() + 1))
                    Dim pos, mayor As Integer
                    Dim length As Integer = CType(JGrM_Buscador.DataSource, DataTable).Rows.Count
                    _prProducto_ObtenerMayorDataSource(mayor, pos, length)
                    nameImg = "\Imagen_" + Str(mayor + 1).Trim + ".jpg"
                    pbImage.Image = imgpb.Clone
                    img.Save(RutaTemporal + nameImg, System.Drawing.Imaging.ImageFormat.Jpeg)
                    img.Dispose()
                    imgpb.Dispose()

                Else

                    nameImg = "\Imagen_" + Str(tbNumi.Text).Trim + ".jpg"
                    pbImage.Image = imgpb.Clone
                    img.Save(RutaTemporal + nameImg, System.Drawing.Imaging.ImageFormat.Jpeg)
                    Modificado = True
                    img.Dispose()
                    imgpb.Dispose()
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
    Private Sub _fnMoverImagenRuta(Folder As String, name As String)
        'copio la imagen en la carpeta del sistema
        If (Not name.Equals("Default.jpg")) Then
            pbImage.Image.Dispose()
            Try
                'Dim img As New Bitmap(New Bitmap(RutaTemporal + name))
                'img.Save(Folder + name, System.Drawing.Imaging.ImageFormat.Jpeg)
                'img.Dispose()
                My.Computer.FileSystem.CopyFile(RutaTemporal + name,
           Folder + name, overwrite:=True)
            Catch ex As System.IO.IOException
                MsgBox("error: " + ex.Message)

            End Try


        End If
    End Sub
    Public Sub _PrEliminarImage()
        If (Not (_fnActionNuevo())) Then
            If IsNothing(pbImage.Image) = False Then
                pbImage.Image.Dispose()
            End If
            Dim rutaOrigen As String = RutaGlobal + "\Imagenes\Imagenes Productos\Imagen_" + tbNumi.Text + ".jpg"
            Dim directorio As String = RutaGlobal + "\Imagenes\Imagenes Productos\"
            If System.IO.Directory.Exists(directorio) Then
                pbImage.Image.Dispose()

                My.Computer.FileSystem.DeleteFile(rutaOrigen,
    FileIO.UIOption.AllDialogs,
    FileIO.RecycleOption.SendToRecycleBin,
    FileIO.UICancelOption.ThrowException)
            End If


        End If
    End Sub
#End Region
#Region "METODOS SOBREESCRITOS"



    Public Overrides Sub _PMOHabilitar()

        _prEstructuraJanusPrincipal()
        tbcdprod1.ReadOnly = False
        tbsmin.ReadOnly = False
        cbGrupo.ReadOnly = False
        cbUMedida.ReadOnly = False
        nameImg = "Default.jpg"
        _prCrearCarpetaImagenes()
        _prCrearCarpetaTemporal()
        btnImage.Visible = True
        tbEstado.IsReadOnly = False
    End Sub
    Public Overrides Sub _PMOInhabilitar()
        _prEstructuraJanusPrincipal()
        tbcdprod1.ReadOnly = True
        tbsmin.ReadOnly = True
        cbGrupo.ReadOnly = True
        cbUMedida.ReadOnly = True
        btnImage.Visible = False
        tbEstado.IsReadOnly = True
        JGrM_Buscador.RootTable.HeaderFormatStyle.FontBold = TriState.True

    End Sub
    Public Overrides Sub _PMOHabilitarFocus()
        With MHighlighterFocus
            .SetHighlightOnFocus(tbcdprod1, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
            .SetHighlightOnFocus(tbsmin, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
            .SetHighlightOnFocus(cbGrupo, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
            .SetHighlightOnFocus(cbUMedida, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
            .SetHighlightOnFocus(btnImage, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
            .SetHighlightOnFocus(pbImage, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
        End With
    End Sub
    Public Overrides Sub _PMOLimpiar()
        tbNumi.Text = ""
        tbcdprod1.Text = ""
        tbsmin.Text = ""
        cbGrupo.SelectedIndex = -1
        cbUMedida.SelectedIndex = -1
        pbImage.Image = My.Resources.imageDefault
        _prEstructuraJanusPrincipal()
        tbcdprod1.Focus()
    End Sub
    Public Overrides Sub _PMOLimpiarErrores()

        MEP.Clear()
        tbcdprod1.BackColor = Color.White
        tbsmin.BackColor = Color.White
        cbGrupo.BackColor = Color.White
        cbUMedida.BackColor = Color.White
    End Sub
    Public Overrides Function _PMOValidarCampos() As Boolean
        Dim _ok As Boolean = True
        MEP.Clear()

        If tbcdprod1.Text = String.Empty Then
            tbcdprod1.BackColor = Color.Red
            MEP.SetError(tbcdprod1, "ingrese Descripción del producto!".ToUpper)
            _ok = False
        Else
            tbcdprod1.BackColor = Color.White
            MEP.SetError(tbcdprod1, "")
        End If

        If tbsmin.Text = String.Empty Then
            tbsmin.BackColor = Color.Red
            MEP.SetError(tbsmin, "ingrese Stock minimo!".ToUpper)
            _ok = False
        Else
            tbsmin.BackColor = Color.White
            MEP.SetError(tbsmin, "")
        End If
        If cbGrupo.SelectedIndex < 0 Then
            cbGrupo.BackColor = Color.Red
            MEP.SetError(cbGrupo, "Seleccione un Grupo de Producto!".ToUpper)
            _ok = False
        Else
            cbGrupo.BackColor = Color.White
            MEP.SetError(cbGrupo, "")
        End If
        If cbUMedida.SelectedIndex < 0 Then
            cbUMedida.BackColor = Color.Red
            MEP.SetError(cbUMedida, "Seleccione una Unidad de Medida de Producto!".ToUpper)
            _ok = False
        Else
            cbUMedida.BackColor = Color.White
            MEP.SetError(cbUMedida, "")
        End If


        MHighlighterFocus.UpdateHighlights()
        Return _ok
    End Function
    Public Overrides Function _PMOGetListEstructuraBuscador() As List(Of Modelos.Celda)
        Dim listEstCeldas As New List(Of Modelos.Celda)

        '    ldnumi ,ldcprod ,ldcdprod1,ldprec ,ldprev  ,ldgr1,grupo.cedesc1 as GrupoProducto ,ldumed 
        ',ldsmin ,ldap,CAST(IIF(ldap=1,1,0) as bit) as estado,ldimg , CAST('' as Image) as img,ldfact ,ldhact ,lduact  
        listEstCeldas.Add(New Modelos.Celda("ldnumi", True, "ID", 60))
        listEstCeldas.Add(New Modelos.Celda("ldcprod", False, "CODIGO DE PRODUCTO", 180))
        listEstCeldas.Add(New Modelos.Celda("ldcdprod1", True, "DESCRIPCION DE PRODUCTO", 350))
        listEstCeldas.Add(New Modelos.Celda("ldprec", False, "PRECIO DE COMPRA", 150))
        listEstCeldas.Add(New Modelos.Celda("ldprev", False, "PRECIO DE VENTA", 150))
        listEstCeldas.Add(New Modelos.Celda("ldgr1", False))
        listEstCeldas.Add(New Modelos.Celda("GrupoProducto", True, "GRUPO DE PRODUCTOS", 180))
        listEstCeldas.Add(New Modelos.Celda("ldumed", False, "UNIDAD DE MEDIDA", 150))
        listEstCeldas.Add(New Modelos.Celda("ldsmin", True, "STOCK MINIMO", 130))
        listEstCeldas.Add(New Modelos.Celda("ldap", False))
        listEstCeldas.Add(New Modelos.Celda("estado", True, "ESTADO", 90))
        listEstCeldas.Add(New Modelos.Celda("ldimg", False))
        listEstCeldas.Add(New Modelos.Celda("img", False, "IMAGEN", 160))
        listEstCeldas.Add(New Modelos.Celda("ldfact", False))
        listEstCeldas.Add(New Modelos.Celda("ldhact", False))
        listEstCeldas.Add(New Modelos.Celda("lduact", False))

        Return listEstCeldas

    End Function
    Public Overrides Function _PMOGetTablaBuscador() As DataTable
        Dim dtBuscador As DataTable = L_prProductoG()
        Return dtBuscador
    End Function
    Public Overrides Sub _PMOMostrarRegistro(_N As Integer)
        JGrM_Buscador.Row = _MPos

        With JGrM_Buscador
            '     ldnumi ,ldcprod ,ldcdprod1 ,ldgr1,grupo.cedesc1 as GrupoProducto ,ldumed 
            ',ldsmin ,ldap  ,ldimg , CAST('' as Image) as img,ldfact ,ldhact ,lduact 
            tbNumi.Text = .GetValue("ldnumi").ToString
            tbcdprod1.Text = .GetValue("ldcdprod1").ToString
            cbGrupo.Value = .GetValue("ldgr1")
            cbUMedida.Text = .GetValue("ldumed")
            tbsmin.Text = .GetValue("ldsmin").ToString
            lbFecha.Text = CType(.GetValue("ldfact"), Date).ToString("dd/MM/yyyy")
            lbHora.Text = .GetValue("ldhact").ToString
            lbUsuario.Text = .GetValue("lduact").ToString

        End With
        Dim estado As Integer = JGrM_Buscador.GetValue("ldap")
        If (estado = 1) Then
            tbEstado.Value = True
        Else
            tbEstado.Value = False

        End If

        Dim name As String = JGrM_Buscador.GetValue("ldimg")
        If (name.ToString.Equals("Default.jpg") Or Not File.Exists(RutaGlobal + "\Imagenes\Imagenes Productos" + name)) Then

            pbImage.Image = My.Resources.imageDefault
        Else
            If (File.Exists(RutaGlobal + "\Imagenes\Imagenes Productos" + name)) Then
                Dim im As New Bitmap(New Bitmap(RutaGlobal + "\Imagenes\Imagenes Productos" + name), 180, 157)
                pbImage.Image = im.Clone
                im.Dispose()
            End If

        

        End If

        LblPaginacion.Text = Str(_MPos + 1) + "/" + JGrM_Buscador.RowCount.ToString

    End Sub
    Public Overrides Function _PMOGrabarRegistro() As Boolean
        Dim res As Boolean = L_prProductoGrabar(tbNumi.Text, "0", tbcdprod1.Text, cbGrupo.Value, cbUMedida.Text, tbsmin.Text, IIf(tbEstado.Value = True, 1, 0), nameImg, "0", "0")
        If res Then
            Modificado = False
            _fnMoverImagenRuta(RutaGlobal + "\Imagenes\Imagenes Productos", nameImg)
            ToastNotification.Show(Me, "Codigo de Productos ".ToUpper + tbNumi.Text + " Grabado con Exito.".ToUpper, My.Resources.GRABACION_EXITOSA, 5000, eToastGlowColor.Green, eToastPosition.TopCenter)
        End If
        Return res

    End Function
    Public Overrides Function _PMOModificarRegistro() As Boolean
        Dim nameImage As String = JGrM_Buscador.GetValue("ldimg")
        Dim res As Boolean
        If (Modificado = False) Then
            res = L_prProductoModificar(tbNumi.Text, "0", tbcdprod1.Text, cbGrupo.Value, cbUMedida.Text, tbsmin.Text, IIf(tbEstado.Value = True, 1, 0), nameImage, "0", "0")
        Else
            res = L_prProductoModificar(tbNumi.Text, "0", tbcdprod1.Text, cbGrupo.Value, cbUMedida.Text, tbsmin.Text, IIf(tbEstado.Value = True, 1, 0), nameImg, "0", "0")
        End If

        If res Then
            If (Modificado = True) Then
                _fnMoverImagenRuta(RutaGlobal + "\Imagenes\Imagenes Productos", nameImg)
                Modificado = False
            End If

            ToastNotification.Show(Me, "Codigo de Productos ".ToUpper + tbNumi.Text + " modificado con Exito.".ToUpper, My.Resources.GRABACION_EXITOSA, 5000, eToastGlowColor.Green, eToastPosition.TopCenter)
        End If
        Return res
    End Function
    Public Overrides Sub _PMOEliminarRegistro()
        Dim info As New TaskDialogInfo("¿esta seguro de eliminar el registro?".ToUpper, eTaskDialogIcon.Delete, "advertencia".ToUpper, "mensaje principal".ToUpper, eTaskDialogButton.Yes Or eTaskDialogButton.Cancel, eTaskDialogBackgroundColor.Blue)
        Dim result As eTaskDialogResult = TaskDialog.Show(info)
        If result = eTaskDialogResult.Yes Then
            Dim mensajeError As String = ""
            Dim res As Boolean = L_prProductoBorrar(tbNumi.Text, mensajeError)
            If res Then
                _PrEliminarImage()
                ToastNotification.Show(Me, "Codigo de Productos ".ToUpper + tbNumi.Text + " eliminado con Exito.".ToUpper, My.Resources.GRABACION_EXITOSA, 5000, eToastGlowColor.Green, eToastPosition.TopCenter)
                _PMFiltrar()
            Else
                ToastNotification.Show(Me, mensajeError, My.Resources.WARNING, 8000, eToastGlowColor.Red, eToastPosition.TopCenter)
            End If
        End If
    End Sub
#End Region
    Private Sub F1_Productos_L_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _prIniciarTodo()

    End Sub

    Private Sub btnImage_Click(sender As Object, e As EventArgs) Handles btnImage.Click
        _fnCopiarImagenRutaDefinida()
        btnGrabar.Focus()

    End Sub

    Private Sub tbsmin_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbsmin.KeyPress
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
        tbsmin.Text = Trim(Replace(tbsmin.Text, "  ", " "))
        tbsmin.Select(tbsmin.Text.Length, 0)
    End Sub


    Private Sub LabelX8_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub cbGrupo_ValueChanged(sender As Object, e As EventArgs) Handles cbGrupo.ValueChanged
        If cbGrupo.SelectedIndex < 0 And cbGrupo.Text <> String.Empty Then
            BtnGrupo.Visible = True
        Else
            BtnGrupo.Visible = False
        End If
    End Sub

    Private Sub cbUMedida_ValueChanged(sender As Object, e As EventArgs) Handles cbUMedida.ValueChanged
        If cbUMedida.SelectedIndex < 0 And cbUMedida.Text <> String.Empty Then
            BtnUmed.Visible = True
        Else
            BtnUmed.Visible = False
        End If
    End Sub

    Private Sub BtnGrupo_Click(sender As Object, e As EventArgs) Handles BtnGrupo.Click
        Dim numi As String = ""

        If L_prLibreriaGrabar(numi, "16", "1", cbGrupo.Text, "") Then
            _prCargarComboLibreria(cbGrupo, "16", "1")
            cbGrupo.SelectedIndex = CType(cbGrupo.DataSource, DataTable).Rows.Count - 1
        End If
    End Sub

    Private Sub BtnUmed_Click(sender As Object, e As EventArgs) Handles BtnUmed.Click
        Dim numi As String = ""

        If L_prLibreriaGrabar(numi, "16", "2", cbUMedida.Text, "") Then
            _prCargarComboLibreria(cbUMedida, "16", "2")
            cbUMedida.SelectedIndex = CType(cbUMedida.DataSource, DataTable).Rows.Count - 1
        End If
    End Sub

 
End Class