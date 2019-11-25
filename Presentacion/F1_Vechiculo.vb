Imports DevComponents.DotNetBar
Imports Logica.AccesoLogica
Imports System.IO

'DESARROLLADO POR: DANNY GUTIERREZ
Public Class F1_Vechiculo

#Region "VARIABLES LOCALES"
    Private listImagenes As New List(Of CImagen)
    Private rutaBase As String = gs_CarpetaRaiz '"C:\Imagenes\DIES"

    Public _nameButton As String
#End Region

#Region "METODOS PRIVADOS"
    Private Sub _prIniciarTodo()

        Me.Text = "v e h i c u l o s".ToUpper

        _prCargarComboLibreria(tbMarca, gi_LibVEHICULO, gi_LibVEHIMarca)
        _prCargarComboLibreria(tbModelo, gi_LibVEHICULO, gi_LibVEHIModelo)
        _prCargarComboLibreria(tbTipo, gi_LibVEHICULO, gi_LibVEHITipo)
        btNuevoModelo.Visible = False
        btNuevaMarca.Visible = False
        btNuevoTipo.Visible = False

        _prCargarComboPersona()
        _prCargarComboSucursal()

        _PMIniciarTodo()

        _prAsignarPermisos()
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

    Private Sub _prCargarComboLibreria(mCombo As Janus.Windows.GridEX.EditControls.MultiColumnCombo, cod1 As String, cod2 As String)
        Dim dt As New DataTable
        dt = L_prLibreriaDetalleGeneral(cod1, cod2)

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
        dt = L_prPersonaAyudaGeneralPorSucursal(gi_userSuc, gi_LibPERSTIPOInstructor)

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
        dt = L_prSucursalAyuda()

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

        If gb_userTodasSuc = False Then
            tbSuc.Enabled = False
        End If
    End Sub


    Private Sub _prCargarImagen()
        OfdVehiculo.InitialDirectory = "C:\Users\" + Environment.UserName + "\Pictures"
        OfdVehiculo.Filter = "Image Files (*.png, *.jpg)|*.png;*.jpg"
        OfdVehiculo.FilterIndex = 1
        If (OfdVehiculo.ShowDialog() = DialogResult.OK) Then
            listImagenes.Add(New CImagen(OfdVehiculo.SafeFileName, OfdVehiculo.FileName, 0))
            _prActualizarImagenes()
        End If
    End Sub

    Private Sub _prActualizarImagenes()
        Dim tam As Integer = listImagenes.Count
        btnImg1.BackgroundImage = Nothing
        'btnImg1.ImageLarge = Nothing
        btnImg2.BackgroundImage = Nothing
        'btnImg2.ImageLarge = Nothing
        btnImg3.BackgroundImage = Nothing
        'btnImg3.ImageLarge = Nothing

        If IsNothing(btnImg1.BackgroundImage) = False Then
            btnImg1.BackgroundImage.Dispose()
        End If
        If IsNothing(btnImg2.BackgroundImage) = False Then
            btnImg2.BackgroundImage.Dispose()
        End If
        If IsNothing(btnImg3.BackgroundImage) = False Then
            btnImg3.BackgroundImage.Dispose()
        End If

        G_LiberarMemoria()

        If tam >= 1 Then
            btnImg1.BackgroundImage = Image.FromFile(listImagenes.Item(tam - 1).getImagen())
            'btnImg1.ImageLarge = Image.FromFile(listImagenes.Item(tam - 1).getImagen())
        End If
        If tam >= 2 Then
            btnImg2.BackgroundImage = Image.FromFile(listImagenes.Item(tam - 2).getImagen())
            'btnImg2.ImageLarge = Image.FromFile(listImagenes.Item(tam - 2).getImagen())
        End If
        If tam >= 3 Then
            btnImg3.BackgroundImage = Image.FromFile(listImagenes.Item(tam - 3).getImagen())
            'btnImg3.ImageLarge = Image.FromFile(listImagenes.Item(tam - 3).getImagen())
        End If

        BubbleBarImagenes.Refresh()
    End Sub

    Private Sub _prGuardarListaImagenes(carpetaFinal As String)
        Dim rutaDestino As String = rutaBase + "\Imagenes\Imagenes Vehiculo\" + carpetaFinal + "\"
        If System.IO.Directory.Exists(rutaBase + "\Imagenes\Imagenes Vehiculo\" + carpetaFinal) = False Then
            If System.IO.Directory.Exists(rutaBase + "\Imagenes") = False Then
                System.IO.Directory.CreateDirectory(rutaBase + "\Imagenes")
                If System.IO.Directory.Exists(rutaBase + "\Imagenes\Imagenes Vehiculo") = False Then
                    System.IO.Directory.CreateDirectory(rutaBase + "\Imagenes\Imagenes Vehiculo")
                End If
            Else
                If System.IO.Directory.Exists(rutaBase + "\Imagenes\Imagenes Vehiculo") = False Then
                    System.IO.Directory.CreateDirectory(rutaBase + "\Imagenes\Imagenes Vehiculo")
                Else
                    If System.IO.Directory.Exists(rutaBase + "\Imagenes\Imagenes Vehiculo\" + carpetaFinal) = False Then
                        System.IO.Directory.CreateDirectory(rutaBase + "\Imagenes\Imagenes Vehiculo\" + carpetaFinal + "\")
                    End If

                End If
            End If
        End If

        Dim rutaOrigen As String

        For i = 0 To listImagenes.Count - 1
            If listImagenes.Item(i).tipo = 0 Then
                rutaOrigen = listImagenes.Item(i).getImagen()
                FileCopy(rutaOrigen, rutaDestino + listImagenes.Item(i).nombre)
            End If
        Next

        'liberar memoria
        G_LiberarMemoria()
    End Sub

    Private Sub _prMoverImgIzquierda()
        If listImagenes.Count >= 4 Then
            Dim imgAxu As CImagen
            imgAxu = listImagenes.Last
            listImagenes.RemoveAt(listImagenes.Count - 1)
            listImagenes.Insert(0, imgAxu)
            _prActualizarImagenes()
        End If
    End Sub

    Private Sub _prMoverImgDerecha()
        If listImagenes.Count >= 4 Then
            Dim imgAxu As CImagen
            imgAxu = listImagenes.First
            listImagenes.RemoveAt(0)
            listImagenes.Add(imgAxu)
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
        tbAnio.ReadOnly = False
        tbMant.ReadOnly = False
        PanelAgrImagen.Enabled = True
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
        tbAnio.ReadOnly = True
        tbMant.ReadOnly = True
        PanelAgrImagen.Enabled = False
    End Sub

    Public Overrides Sub _PMOLimpiar()
        tbId.Text = ""
        tbMarca.Text = ""
        tbModelo.Text = ""
        tbNumi.Text = ""
        tbObs.Text = ""
        tbPersona.Text = ""
        tbTipo.Text = ""
        tbSuc.Value = gi_userSuc
        tbAnio.Text = ""
        tbMant.Text = ""

        tbImagen.Text = ""

        btnImg1.BackgroundImage = Nothing
        'btnImg1.ImageLarge = Nothing
        btnImg2.BackgroundImage = Nothing
        'btnImg2.ImageLarge = Nothing
        btnImg3.BackgroundImage = Nothing
        'btnImg3.ImageLarge = Nothing
        BubbleBarImagenes.Refresh()

        'limpiar lista de imaganes
        listImagenes.Clear()
    End Sub

    Public Overrides Sub _PMOLimpiarErrores()
        MEP.Clear()
        tbId.BackColor = Color.White
        tbMarca.BackColor = Color.White
        tbModelo.BackColor = Color.White
        tbObs.BackColor = Color.White
        tbPersona.BackColor = Color.White
        tbTipo.BackColor = Color.White
        tbSuc.BackColor = Color.White
        tbAnio.BackColor = Color.White
        tbMant.BackColor = Color.White
    End Sub

    Public Overrides Function _PMOGrabarRegistro() As Boolean
        Dim res As Boolean = L_prVehiculoGrabar(tbNumi.Text, tbId.Text, tbMarca.Value, tbModelo.Value, tbPersona.Value, tbObs.Text, tbImagen.Text, tbTipo.Value, tbSuc.Value, tbAnio.Text, tbMant.Text)
        If res Then
            _prGuardarListaImagenes(tbImagen.Text)

            ToastNotification.Show(Me, "Codigo de vehiculo ".ToUpper + tbNumi.Text + " Grabado con Exito.".ToUpper, My.Resources.GRABACION_EXITOSA, 5000, eToastGlowColor.Green, eToastPosition.TopCenter)
        End If
        Return res

    End Function

    Public Overrides Function _PMOModificarRegistro() As Boolean
        Dim res As Boolean = L_prVehiculoModificar(tbNumi.Text, tbId.Text, tbMarca.Value, tbModelo.Value, tbPersona.Value, tbObs.Text, tbImagen.Text, tbTipo.Value, tbSuc.Value, tbAnio.Text, tbMant.Text)
        If res Then
            _prGuardarListaImagenes(tbImagen.Text)
            ToastNotification.Show(Me, "Codigo de vehiculo ".ToUpper + tbNumi.Text + " modificado con Exito.".ToUpper, My.Resources.GRABACION_EXITOSA, 5000, eToastGlowColor.Green, eToastPosition.TopCenter)
        End If
        Return res
    End Function

    Public Overrides Sub _PMOEliminarRegistro()
        Dim info As New TaskDialogInfo("¿esta seguro de eliminar el registro?".ToUpper, eTaskDialogIcon.Delete, "advertencia".ToUpper, "mensaje principal".ToUpper, eTaskDialogButton.Yes Or eTaskDialogButton.Cancel, eTaskDialogBackgroundColor.Blue)
        Dim result As eTaskDialogResult = TaskDialog.Show(info)
        If result = eTaskDialogResult.Yes Then
            Dim res As Boolean = L_prVehiculoBorrar(tbNumi.Text)
            If res Then

                If IsNothing(btnImg1.BackgroundImage) = False Then
                    btnImg1.BackgroundImage.Dispose()
                    'btnImg1.ImageLarge.Dispose()
                    btnImg1.Dispose()
                End If

                If IsNothing(btnImg2.BackgroundImage) = False Then
                    btnImg2.BackgroundImage.Dispose()
                    'btnImg2.ImageLarge.Dispose()
                    btnImg2.Dispose()
                End If

                If IsNothing(btnImg3.BackgroundImage) = False Then
                    btnImg3.BackgroundImage.Dispose()
                    'btnImg3.ImageLarge.Dispose()
                    btnImg3.Dispose()
                End If

                OfdVehiculo.Dispose()

                Dim rutaOrigen As String = rutaBase + "\Imagenes\Imagenes Vehiculo\" + tbImagen.Text
                If System.IO.Directory.Exists(rutaOrigen) Then
                    My.Computer.FileSystem.DeleteDirectory(rutaOrigen, FileIO.DeleteDirectoryOption.DeleteAllContents)
                End If

                ToastNotification.Show(Me, "Codigo de vehiculo ".ToUpper + tbNumi.Text + " eliminado con Exito.".ToUpper, My.Resources.GRABACION_EXITOSA, 5000, eToastGlowColor.Green, eToastPosition.TopCenter)
                _PMFiltrar()
            End If
        End If
    End Sub
    Public Overrides Function _PMOValidarCampos() As Boolean
        Dim _ok As Boolean = True
        MEP.Clear()

        If tbId.Text = String.Empty Then
            tbId.BackColor = Color.Red
            MEP.SetError(tbId, "ingrese id del vehiculo!".ToUpper)
            _ok = False
        Else
            tbId.BackColor = Color.White
            MEP.SetError(tbId, "")
        End If

        If tbMarca.SelectedIndex < 0 Then
            tbMarca.BackColor = Color.Red
            MEP.SetError(tbMarca, "seleccione la marca del vehiculo!".ToUpper)
            _ok = False
        Else
            tbMarca.BackColor = Color.White
            MEP.SetError(tbMarca, "")
        End If

        If tbModelo.SelectedIndex < 0 Then
            tbModelo.BackColor = Color.Red
            MEP.SetError(tbModelo, "seleccione el modelo del vehiculo!".ToUpper)
            _ok = False
        Else
            tbModelo.BackColor = Color.White
            MEP.SetError(tbModelo, "")
        End If

        'If tbObs.Text = String.Empty Then
        '    tbObs.BackColor = Color.Red
        '    MEP.SetError(tbObs, "ingrese la observacion del vehiculo!".ToUpper)
        '    _ok = False
        'Else
        '    tbObs.BackColor = Color.White
        '    MEP.SetError(tbObs, "")
        'End If

        If tbTipo.SelectedIndex < 0 Then
            tbTipo.BackColor = Color.Red
            MEP.SetError(tbTipo, "ingrese la observacion del vehiculo!".ToUpper)
            _ok = False
        Else
            tbTipo.BackColor = Color.White
            MEP.SetError(tbTipo, "")
        End If

        If tbPersona.SelectedIndex < 0 Then
            tbPersona.BackColor = Color.Red
            MEP.SetError(tbPersona, "seleccione la persona encargada del vehiculo!".ToUpper)
            _ok = False
        Else
            tbPersona.BackColor = Color.White
            MEP.SetError(tbPersona, "")
        End If

        If tbSuc.SelectedIndex < 0 Then
            tbSuc.BackColor = Color.Red
            MEP.SetError(tbSuc, "seleccione la sucursal del vehiculo!".ToUpper)
            _ok = False
        Else
            tbSuc.BackColor = Color.White
            MEP.SetError(tbSuc, "")
        End If

        MHighlighterFocus.UpdateHighlights()
        Return _ok
    End Function

    Public Overrides Function _PMOGetTablaBuscador() As DataTable
        Dim numiSuc As String = IIf(gb_userTodasSuc = True, "-1", gi_userSuc)
        Dim dtBuscador As DataTable = L_prVehiculoGeneral(numiSuc)
        Return dtBuscador
    End Function

    Public Overrides Function _PMOGetListEstructuraBuscador() As List(Of Modelos.Celda)

        Dim listEstCeldas As New List(Of Modelos.Celda)
        listEstCeldas.Add(New Modelos.Celda("canumi", True, "COD", 70))
        listEstCeldas.Add(New Modelos.Celda("caid", True, "ID", 150))
        listEstCeldas.Add(New Modelos.Celda("camar", False))
        listEstCeldas.Add(New Modelos.Celda("marcadesc", True, "MARCA", 120))
        listEstCeldas.Add(New Modelos.Celda("camod", False))
        listEstCeldas.Add(New Modelos.Celda("modelodesc", True, "MODELO", 120))
        listEstCeldas.Add(New Modelos.Celda("caper", False))
        listEstCeldas.Add(New Modelos.Celda("panom1", True, "CONDUCTOR", 200))
        listEstCeldas.Add(New Modelos.Celda("caobs", True, "OBS", 200))
        listEstCeldas.Add(New Modelos.Celda("catipo", False))
        listEstCeldas.Add(New Modelos.Celda("tipodesc", True, "TIPO", 100))
        listEstCeldas.Add(New Modelos.Celda("caimg", False))
        listEstCeldas.Add(New Modelos.Celda("casuc", False))
        listEstCeldas.Add(New Modelos.Celda("cadesc", True, "SUCURSAL", 150))
        listEstCeldas.Add(New Modelos.Celda("caanio", True, "AÑO", 120))
        listEstCeldas.Add(New Modelos.Celda("camant", True, "MANTENIMIENTO", 200))
        listEstCeldas.Add(New Modelos.Celda("cafact", False))
        listEstCeldas.Add(New Modelos.Celda("cahact", False))
        listEstCeldas.Add(New Modelos.Celda("cauact", False))
        Return listEstCeldas
    End Function

    Public Overrides Sub _PMOMostrarRegistro(_N As Integer)
        JGrM_Buscador.Row = _MPos

        With JGrM_Buscador
            tbNumi.Text = .GetValue("canumi").ToString
            tbId.Text = .GetValue("caid").ToString
            tbMarca.Text = .GetValue("marcadesc").ToString
            tbModelo.Text = .GetValue("modelodesc").ToString
            tbObs.Text = .GetValue("caobs").ToString
            tbPersona.Text = .GetValue("panom1").ToString
            tbTipo.Text = .GetValue("tipodesc").ToString
            tbImagen.Text = .GetValue("caimg").ToString
            tbSuc.Text = .GetValue("cadesc").ToString
            tbAnio.Text = .GetValue("caanio").ToString
            tbMant.Text = .GetValue("camant").ToString

            lbFecha.Text = CType(.GetValue("cafact"), Date).ToString("dd/MM/yyyy")
            lbHora.Text = .GetValue("cahact").ToString
            lbUsuario.Text = .GetValue("cauact").ToString
        End With

        'cargar imagenes
        listImagenes.Clear()
        Dim rutaOrigen As String = rutaBase + "\Imagenes\Imagenes Vehiculo\" + tbImagen.Text + "\"
        If System.IO.Directory.Exists(rutaBase + "\Imagenes\Imagenes Vehiculo\" + tbImagen.Text) = True Then
            Dim folderBase As New DirectoryInfo(rutaOrigen)
            Dim nombre, rutaCompleta As String
            For Each file As FileInfo In folderBase.GetFiles()
                Dim extension As String = file.Extension
                If extension.ToUpper = ".jpg".ToUpper Or extension.ToUpper = ".png".ToUpper Then
                    nombre = file.Name
                    rutaCompleta = file.DirectoryName + "\" + nombre
                    listImagenes.Add(New CImagen(nombre, rutaCompleta, 1))
                End If

            Next
        End If
        _prActualizarImagenes()

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
            End Select

        End If
    End Sub

    Private Sub btnImgAnt_Click(sender As Object, e As EventArgs) Handles btnImgAnt.Click
        _prMoverImgIzquierda()
    End Sub

    Private Sub btnImgSig_Click(sender As Object, e As EventArgs) Handles btnImgSig.Click
        _prMoverImgDerecha()
    End Sub

    Private Sub btnImg1_Click(sender As Object, e As ClickEventArgs)
        Dim tam As Integer = listImagenes.Count
        If tam >= 1 Then
            Shell("rundll32.exe C:\WINDOWS\system32\shimgvw.dll,ImageView_Fullscreen " + listImagenes.Item(tam - 1).direccion)
        End If
    End Sub

    Private Sub btnImg2_Click(sender As Object, e As ClickEventArgs)
        Dim tam As Integer = listImagenes.Count
        If tam >= 2 Then
            Shell("rundll32.exe C:\WINDOWS\system32\shimgvw.dll,ImageView_Fullscreen " + listImagenes.Item(tam - 2).direccion)
        End If
    End Sub

    Private Sub btnImg3_Click(sender As Object, e As ClickEventArgs)
        Dim tam As Integer = listImagenes.Count
        If tam >= 3 Then
            Shell("rundll32.exe C:\WINDOWS\system32\shimgvw.dll,ImageView_Fullscreen " + listImagenes.Item(tam - 3).direccion)
        End If
    End Sub

    Private Sub btNuevaMarca_Click(sender As Object, e As EventArgs) Handles btNuevaMarca.Click
        Dim numi As String = ""

        If L_prLibreriaGrabar(numi, gi_LibVEHICULO, gi_LibVEHIMarca, tbMarca.Text, "") Then
            _prCargarComboLibreria(tbMarca, gi_LibVEHICULO, gi_LibVEHIMarca)
            tbMarca.SelectedIndex = CType(tbMarca.DataSource, DataTable).Rows.Count - 1
        End If

    End Sub

    Private Sub btNuevoTipo_Click(sender As Object, e As EventArgs) Handles btNuevoTipo.Click
        Dim numi As String = ""

        If L_prLibreriaGrabar(numi, gi_LibVEHICULO, gi_LibVEHITipo, tbTipo.Text, "") Then
            _prCargarComboLibreria(tbTipo, gi_LibVEHICULO, gi_LibVEHITipo)
            tbTipo.SelectedIndex = CType(tbTipo.DataSource, DataTable).Rows.Count - 1
        End If
    End Sub

    Private Sub btNuevoModelo_Click(sender As Object, e As EventArgs) Handles btNuevoModelo.Click
        Dim numi As String = ""

        If L_prLibreriaGrabar(numi, gi_LibVEHICULO, gi_LibVEHIModelo, tbModelo.Text, "") Then
            _prCargarComboLibreria(tbModelo, gi_LibVEHICULO, gi_LibVEHIModelo)
            tbModelo.SelectedIndex = CType(tbModelo.DataSource, DataTable).Rows.Count - 1
        End If
    End Sub

    Private Sub tbMarca_ValueChanged(sender As Object, e As EventArgs) Handles tbMarca.ValueChanged
        If tbMarca.SelectedIndex < 0 And tbMarca.Text <> String.Empty Then
            btNuevaMarca.Visible = True
        Else
            btNuevaMarca.Visible = False
        End If

    End Sub

    Private Sub tbTipo_ValueChanged(sender As Object, e As EventArgs) Handles tbTipo.ValueChanged
        If tbTipo.SelectedIndex < 0 And tbTipo.Text <> String.Empty Then
            btNuevoTipo.Visible = True
        Else
            btNuevoTipo.Visible = False
        End If
    End Sub

    Private Sub tbModelo_ValueChanged(sender As Object, e As EventArgs) Handles tbModelo.ValueChanged
        If tbModelo.SelectedIndex < 0 And tbModelo.Text <> String.Empty Then
            btNuevoModelo.Visible = True
        Else
            btNuevoModelo.Visible = False
        End If
    End Sub

    Private Sub btnImg1_DoubleClick(sender As Object, e As EventArgs) Handles btnImg1.DoubleClick
        Dim tam As Integer = listImagenes.Count
        If tam >= 1 Then
            Shell("rundll32.exe C:\WINDOWS\system32\shimgvw.dll,ImageView_Fullscreen " + listImagenes.Item(tam - 1).direccion)
        End If
    End Sub

    Private Sub btnImg2_DoubleClick(sender As Object, e As EventArgs) Handles btnImg2.DoubleClick
        Dim tam As Integer = listImagenes.Count
        If tam >= 2 Then
            Shell("rundll32.exe C:\WINDOWS\system32\shimgvw.dll,ImageView_Fullscreen " + listImagenes.Item(tam - 2).direccion)
        End If
    End Sub

    Private Sub btnImg3_DoubleClick(sender As Object, e As EventArgs) Handles btnImg3.DoubleClick
        Dim tam As Integer = listImagenes.Count
        If tam >= 3 Then
            Shell("rundll32.exe C:\WINDOWS\system32\shimgvw.dll,ImageView_Fullscreen " + listImagenes.Item(tam - 3).direccion)
        End If
    End Sub
End Class

Public Class CImagen
    Public nombre As String
    Public direccion As String
    Public tipo As Integer

    Public Sub New(nom As String, dir As String, ti As Integer)
        nombre = nom
        direccion = dir
        tipo = ti
    End Sub

    Public Function getImagen()
        Return direccion
    End Function
End Class