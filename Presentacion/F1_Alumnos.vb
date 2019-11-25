Imports Logica.AccesoLogica
Imports DevComponents.DotNetBar
Imports System.IO
Imports Janus.Windows.GridEX

'DESARROLLADO POR: DANNY GUTIERREZ
Public Class F1_Alumnos

#Region "Variables locales"
    Private vlImagen As CImagen = Nothing
    Private vlRutaBase As String = gs_CarpetaRaiz '"C:\Imagenes\DIES"
    Public _nameButton As String

    Private grDatos As GridEXRow
#End Region

#Region "METODOS PRIVADOS"
    Private Sub _prIniciarTodo()
        Me.Text = "A L U M N O S"
        _prCargarComboLibreria(tbTipo, gi_LibALUMNO, gi_LibALUMTipo)
        _prCargarComboLibreria(tbEstCivil, gi_LibALUMNO, gi_LibALUMEstCivil)
        _prCargarComboLibreria(tbProf, gi_LibALUMNO, gi_LibALUMProfesion)
        _prCargarComboLibreria(tbParent, gi_LibALUMNO, gi_LibALUMParentesco)
        _prCargarComboLibreria(tbLugNac, gi_LibALUMNO, gi_LibALUMNacionalidad)

        _prCargarComboSocios()
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

    Private Sub _prCargarComboSocios()
        Dim dt As New DataTable
        dt = L_prAlumnoAyudaSocios()

        With tbSocio
            .DropDownList.Columns.Clear()

            .DropDownList.Columns.Add("cfnumi").Width = 70
            .DropDownList.Columns("cfnumi").Caption = "COD"

            .DropDownList.Columns.Add("cfci").Width = 70
            .DropDownList.Columns("cfci").Caption = "CI"

            .DropDownList.Columns.Add("nombre").Width = 200
            .DropDownList.Columns("nombre").Caption = "DESCRIPCION"

            .ValueMember = "cfnumi"
            .DisplayMember = "nombre"
            .DataSource = dt
            .Refresh()
        End With
    End Sub

    Private Sub _prCargarImagen()
        OfdFoto.InitialDirectory = "C:\Users\" + Environment.UserName + "\Pictures"
        OfdFoto.Filter = "Imagen|*.jpg;*.jpeg;*.png;*.bmp"
        OfdFoto.FilterIndex = 1
        If (OfdFoto.ShowDialog() = DialogResult.OK) Then
            vlImagen = New CImagen(OfdFoto.SafeFileName, OfdFoto.FileName, 0)
            pbImg.SizeMode = PictureBoxSizeMode.StretchImage
            pbImg.Load(vlImagen.getImagen())
        End If
    End Sub

    Private Sub _prEliminarImagen()
        vlImagen = Nothing
        pbImg.Image = Nothing
    End Sub

    Private Sub _prGuardarImagen()
        Dim rutaDestino As String = vlRutaBase + "\Imagenes\Imagenes Alumnos\"
        If System.IO.Directory.Exists(rutaDestino) = False Then
            If System.IO.Directory.Exists(vlRutaBase + "\Imagenes\") = False Then
                System.IO.Directory.CreateDirectory(vlRutaBase + "\Imagenes")
                If System.IO.Directory.Exists(vlRutaBase + "\Imagenes\Imagenes Alumnos\") = False Then
                    System.IO.Directory.CreateDirectory(vlRutaBase + "\Imagenes\Imagenes Alumnos")
                End If
            Else
                If System.IO.Directory.Exists(vlRutaBase + "\Imagenes\Imagenes Alumnos") = False Then
                    System.IO.Directory.CreateDirectory(vlRutaBase + "\Imagenes\Imagenes Alumnos")
                End If
            End If
        End If

        Dim rutaOrigen As String
        rutaOrigen = vlImagen.getImagen()
        FileCopy(rutaOrigen, rutaDestino + vlImagen.nombre + ".jpg")

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

    Private Sub _prImprimir()
        Dim rutaDestino As String = vlRutaBase + "\Imagenes\Imagenes Alumnos\"
        Dim objrep As New R_FichaEscuela
        Dim dt As New DataTable
        dt = L_prAlumnoFichaInscripcion(tbNumi.Text)
        If dt.Rows.Count = 0 Then
            dt = L_prAlumnoFichaInscripcion2(tbNumi.Text)
        End If

        Dim img As Bitmap
        Dim foto As String = dt.Rows(0).Item("cbfot")
        If (IO.File.Exists(rutaDestino + foto)) Then
            img = New Bitmap(rutaDestino + foto)

            For Each fila1 As DataRow In dt.Rows
                'fila1.Item("cbfot2") = _fnImageToByteArray(img)
                fila1.Item("cbfot2") = _fnImageToByteArray(rutaDestino + foto)
            Next
            '_dt.Rows(0).Item("foto") = _fnImageToByteArray(img)
            '_dt.Rows(0).Item("foto") = _fnBytesArchivo(direccionFoto)
        End If

        'ahora lo mando al visualizador
        P_Global.Visualizador = New Visualizador
        objrep.SetDataSource(dt)
        P_Global.Visualizador.CRV1.ReportSource = objrep 'Comentar
        P_Global.Visualizador.Show() 'Comentar
        P_Global.Visualizador.BringToFront() 'Comentar

        'imprimir
        'If PrintDialog1.ShowDialog = DialogResult.OK Then
        '    objrep.SetDataSource(dt)
        '    objrep.PrintOptions.PrinterName = PrintDialog1.PrinterSettings.PrinterName
        '    objrep.PrintToPrinter(1, False, 1, 10)
        'End If


    End Sub

    'Public Function _fnImageToByteArray(ByVal imageIn As Image) As Byte()
    '    Dim ms As New System.IO.MemoryStream()
    '    imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg)
    '    'Return ms.ToArray()
    '    Return ms.GetBuffer
    'End Function
    Public Function _fnImageToByteArray(ByVal ruta As String) As Byte()

        Dim bitmap As Bitmap = New Bitmap(New MemoryStream(IO.File.ReadAllBytes(ruta)))
        Dim img As Bitmap = New Bitmap(bitmap)
        Dim Bin As New MemoryStream
        img.Save(Bin, Imaging.ImageFormat.Jpeg)

        Return Bin.GetBuffer
    End Function


    Private Sub _prImprimirPlanillaControlClasesPracticas()

        Dim objrep As New R_EscuelaDetallaClasesPracticas
        Dim dt As New DataTable
        dt = L_prAlumnoClasesPracticasDetallado(tbNumi.Text)
        If dt.Rows.Count = 0 Then
            ToastNotification.Show(Me, "el alumno aun no tiene clases practicas programadas".ToUpper, My.Resources.WARNING, 5000, eToastGlowColor.Red, eToastPosition.TopCenter)
            Exit Sub
        End If
        Dim i As Integer = 1
        For Each fila As DataRow In dt.Rows
            fila.Item("nroClase") = i
            i = i + 1
        Next

        'ahora lo mando al visualizador
        P_Global.Visualizador = New Visualizador
        objrep.SetDataSource(dt)
        objrep.SetParameterValue("fechaInicio", CType(dt.Rows(0).Item("ehfec"), Date).ToString("yyyy/MM/dd"))
        objrep.SetParameterValue("fechaFin", CType(dt.Rows(dt.Rows.Count - 1).Item("ehfec"), Date).ToString("yyyy/MM/dd"))

        P_Global.Visualizador.CRV1.ReportSource = objrep 'Comentar
        P_Global.Visualizador.Show() 'Comentar
        P_Global.Visualizador.BringToFront() 'Comentar

        'imprimir
        'If PrintDialog1.ShowDialog = DialogResult.OK Then
        '    objrep.SetDataSource(dt)
        '    objrep.SetParameterValue("fechaInicio", CType(dt.Rows(0).Item("ehfec"), Date).ToString("yyyy/MM/dd"))
        '    objrep.SetParameterValue("fechaFin", CType(dt.Rows(dt.Rows.Count - 1).Item("ehfec"), Date).ToString("yyyy/MM/dd"))


        '    objrep.PrintOptions.PrinterName = PrintDialog1.PrinterSettings.PrinterName
        '    objrep.PrintToPrinter(1, False, 1, 10)
        'End If
    End Sub
#End Region

#Region "METODOS SOBRECARGADOS"
    Public Overrides Sub _PMOHabilitar()
        tbApellido.ReadOnly = False
        tbTelef2.ReadOnly = False
        tbCi.ReadOnly = False
        tbDireccion.ReadOnly = False
        tbEmail.ReadOnly = False
        tbNombre.ReadOnly = False
        tbTelef1.ReadOnly = False
        tbEstado.IsReadOnly = False
        tbFIng.Enabled = True
        tbFNac.Enabled = True
        tbProf.ReadOnly = False
        tbLugNac.ReadOnly = False
        tbObs.ReadOnly = False
        tbTipo.ReadOnly = False
        tbEstCivil.ReadOnly = False
        tbFamiliar.IsReadOnly = False
        tbParent.ReadOnly = False
        tbSocio.ReadOnly = False
        tbMenor.IsReadOnly = False
        tbTutCi.ReadOnly = False
        tbTutNom.ReadOnly = False
        tbSuc.ReadOnly = False
        tbNroGrupo.ReadOnly = False
        tbNroFactura.ReadOnly = False
        PanelAgrImagen.Enabled = True

        ToolStripMenuItemPegar.Visible = True
        ToolStripMenuItemCopiar.Visible = False
    End Sub

    Public Overrides Sub _PMOInhabilitar()
        tbCi.ReadOnly = True
        tbApellido.ReadOnly = True
        tbTelef2.ReadOnly = True
        tbDireccion.ReadOnly = True
        tbEmail.ReadOnly = True
        tbNombre.ReadOnly = True
        tbNumi.ReadOnly = True
        tbTelef1.ReadOnly = True
        tbEstado.IsReadOnly = True
        tbFIng.Enabled = False
        tbFNac.Enabled = False
        tbObs.ReadOnly = True
        tbTipo.ReadOnly = True
        tbProf.ReadOnly = True
        tbLugNac.ReadOnly = True
        tbEstCivil.ReadOnly = True
        tbFamiliar.IsReadOnly = True
        tbParent.ReadOnly = True
        tbSocio.ReadOnly = True
        tbMenor.IsReadOnly = True
        tbTutCi.ReadOnly = True
        tbTutNom.ReadOnly = True
        tbSuc.ReadOnly = True
        tbNroGrupo.ReadOnly = True
        tbNroFactura.ReadOnly = True

        PanelAgrImagen.Enabled = False

        ToolStripMenuItemPegar.Visible = False
        ToolStripMenuItemCopiar.Visible = True
    End Sub

    Public Overrides Sub _PMOLimpiar()
        tbApellido.Text = ""
        tbTelef2.Text = ""
        tbCi.Text = ""
        tbDireccion.Text = ""
        tbEmail.Text = ""
        tbNombre.Text = ""
        tbNumi.Text = ""
        tbTelef1.Text = ""
        tbEstado.Value = True
        tbFIng.Value = Now.Date
        tbFNac.Value = Now.Date
        tbObs.Text = ""
        tbLugNac.Text = ""
        tbProf.Text = ""
        tbTipo.Text = ""
        tbEstCivil.Text = ""
        tbFamiliar.Value = False
        tbParent.Text = ""
        tbSocio.Text = ""
        tbMenor.Value = False
        tbTutCi.Text = ""
        tbTutNom.Text = ""
        tbNroGrupo.Text = ""
        tbNroFactura.Text = ""
        tbSuc.Value = gi_userSuc
        _prEliminarImagen()

        'grDatos = Nothing
    End Sub

    Public Overrides Sub _PMOLimpiarErrores()
        MEP.Clear()
        tbApellido.BackColor = Color.White
        tbCi.BackColor = Color.White
        tbDireccion.BackColor = Color.White
        tbEmail.BackColor = Color.White
        tbNombre.BackColor = Color.White
        tbTelef2.BackColor = Color.White
        tbTelef1.BackColor = Color.White
        tbEstado.BackColor = Color.White
        tbFIng.BackColor = Color.White
        tbFNac.BackColor = Color.White
        tbObs.BackColor = Color.White
        tbLugNac.BackColor = Color.White
        tbProf.BackColor = Color.White
        tbEstCivil.BackColor = Color.White
        tbTipo.BackColor = Color.White
        tbFamiliar.BackColor = Color.White
        tbParent.BackColor = Color.White
        tbSocio.BackColor = Color.White
        tbMenor.BackColor = Color.White
        tbTutCi.BackColor = Color.White
        tbTutNom.BackColor = Color.White
        tbSuc.BackColor = Color.White
        tbNroGrupo.BackColor = Color.White
        tbNroFactura.BackColor = Color.White

    End Sub

    Public Overrides Function _PMOGrabarRegistro() As Boolean
        Dim nomImg As String
        If IsNothing(vlImagen) = True Then
            nomImg = ""
        Else
            nomImg = vlImagen.nombre
        End If
        Dim res As Boolean = L_prAlumnoGrabar(tbNumi.Text, tbCi.Text, tbNombre.Text, tbApellido.Text, tbDireccion.Text, tbTelef1.Text, tbTelef2.Text, tbEmail.Text, tbFNac.Value.ToString("yyyy/MM/dd"), tbFIng.Value.ToString("yyyy/MM/dd"), tbLugNac.Value, tbEstCivil.Value, tbProf.Value, tbTipo.Value, IIf(tbEstado.Value = True, 1, 0), nomImg, tbObs.Text, IIf(tbFamiliar.Value = True, tbSocio.Value, 0), IIf(tbFamiliar.Value = True, tbParent.Value, 0), IIf(tbMenor.Value = True, 1, 0), IIf(tbMenor.Value = True, tbTutCi.Text, ""), IIf(tbMenor.Value = True, tbTutNom.Text, ""), tbSuc.Value, tbNroGrupo.Text.Trim, tbNroFactura.Text, 0) 'tbNroFactura.Tag.ToString.Trim
        If res Then
            If IsNothing(vlImagen) = False Then
                vlImagen.nombre = nomImg
                _prGuardarImagen()
            End If

            ToastNotification.Show(Me, "Codigo de alumno ".ToUpper + tbNumi.Text + " Grabado con Exito.".ToUpper, My.Resources.GRABACION_EXITOSA, 5000, eToastGlowColor.Green, eToastPosition.TopCenter)

            Dim info As New TaskDialogInfo("clases practicas".ToUpper, eTaskDialogIcon.Delete, "clases practicas".ToUpper, "¿Desea programar las clases practicas del alumno registrado?".ToUpper, eTaskDialogButton.Yes Or eTaskDialogButton.Cancel, eTaskDialogBackgroundColor.Blue)
            Dim result As eTaskDialogResult = TaskDialog.Show(info)
            If result = eTaskDialogResult.Yes Then
                'Dim frm As F0_ClasesPracticas2
                'frm = New F0_ClasesPracticas2
                Dim frm As F0_ClasesPracticas3
                frm = New F0_ClasesPracticas3
                frm._numiAlumInscrito = tbNumi.Text
                frm.Show()
            End If


        End If
        Return res

    End Function

    Public Overrides Function _PMOModificarRegistro() As Boolean
        Dim nomImg As String
        If IsNothing(vlImagen) = True Then
            nomImg = ""
        Else
            nomImg = vlImagen.nombre
        End If
        Dim res As Boolean = L_prAlumnoModificar(tbNumi.Text, tbCi.Text, tbNombre.Text, tbApellido.Text, tbDireccion.Text, tbTelef1.Text, tbTelef2.Text, tbEmail.Text, tbFNac.Value.ToString("yyyy/MM/dd"), tbFIng.Value.ToString("yyyy/MM/dd"), tbLugNac.Value, tbEstCivil.Value, tbProf.Value, tbTipo.Value, IIf(tbEstado.Value = True, 1, 0), nomImg, tbObs.Text, IIf(tbFamiliar.Value = True, tbSocio.Value, 0), IIf(tbFamiliar.Value = True, tbParent.Value, 0), IIf(tbMenor.Value = True, 1, 0), tbTutCi.Text, tbTutNom.Text, tbSuc.Value, tbNroGrupo.Text.Trim, tbNroFactura.Text)
        If res Then
            If IsNothing(vlImagen) = False Then
                If vlImagen.tipo = 0 Then
                    vlImagen.nombre = nomImg
                    _prGuardarImagen()
                End If
            End If
            ToastNotification.Show(Me, "Codigo de alumno ".ToUpper + tbNumi.Text + " modificado con Exito.".ToUpper, My.Resources.GRABACION_EXITOSA, 5000, eToastGlowColor.Green, eToastPosition.TopCenter)
        End If
        Return res
    End Function

    Public Overrides Sub _PMOEliminarRegistro()
        Dim info As New TaskDialogInfo("¿esta seguro de eliminar el registro?".ToUpper, eTaskDialogIcon.Delete, "advertencia".ToUpper, "mensaje principal".ToUpper, eTaskDialogButton.Yes Or eTaskDialogButton.Cancel, eTaskDialogBackgroundColor.Blue)
        Dim result As eTaskDialogResult = TaskDialog.Show(info)
        If result = eTaskDialogResult.Yes Then
            Dim mensajeError As String = ""
            Dim res As Boolean = L_prAlumnoBorrar(tbNumi.Text, mensajeError)
            If res Then
                ToastNotification.Show(Me, "Codigo de alumno: ".ToUpper + tbNumi.Text + " eliminado con Exito.".ToUpper, My.Resources.GRABACION_EXITOSA, 5000, eToastGlowColor.Green, eToastPosition.TopCenter)
                _PMFiltrar()
            Else
                ToastNotification.Show(Me, mensajeError, My.Resources.WARNING, 8000, eToastGlowColor.Red, eToastPosition.TopCenter)
            End If
        End If
    End Sub
    Public Overrides Function _PMOValidarCampos() As Boolean
        Dim _ok As Boolean = True
        MEP.Clear()

        If tbApellido.Text = String.Empty Then
            tbApellido.BackColor = Color.Red
            MEP.SetError(tbApellido, "ingrese apellido del alumno!".ToUpper)
            _ok = False
        Else
            tbApellido.BackColor = Color.White
            MEP.SetError(tbApellido, "")
        End If

        If tbCi.Text = String.Empty Then
            tbCi.BackColor = Color.Red
            MEP.SetError(tbCi, "ingrese ci del alumno!".ToUpper)
            _ok = False
        Else
            tbCi.BackColor = Color.White
            MEP.SetError(tbCi, "")
        End If

        If tbDireccion.Text = String.Empty Then
            tbDireccion.BackColor = Color.Red
            MEP.SetError(tbDireccion, "ingrese direccion del alumno!".ToUpper)
            _ok = False
        Else
            tbDireccion.BackColor = Color.White
            MEP.SetError(tbDireccion, "")
        End If

        If tbNroFactura.Text = String.Empty Then
            tbNroFactura.BackColor = Color.Red
            MEP.SetError(tbNroFactura, "ingrese el numero de factura del alumno!".ToUpper)
            _ok = False
        Else
            tbNroFactura.BackColor = Color.White
            MEP.SetError(tbNroFactura, "")
        End If

        'If tbEmail.Text = String.Empty Then
        '    tbEmail.BackColor = Color.Red
        '    MEP.SetError(tbEmail, "ingrese e-mail del alumno!".ToUpper)
        '    _ok = False
        'Else
        '    tbEmail.BackColor = Color.White
        '    MEP.SetError(tbEmail, "")
        'End If

        If tbNombre.Text = String.Empty Then
            tbNombre.BackColor = Color.Red
            MEP.SetError(tbNombre, "ingrese nombre del alumno!".ToUpper)
            _ok = False
        Else
            tbNombre.BackColor = Color.White
            MEP.SetError(tbNombre, "")
        End If

        If tbTelef1.Text = String.Empty Then
            tbTelef1.BackColor = Color.Red
            MEP.SetError(tbTelef1, "ingrese telefono del alumno!".ToUpper)
            _ok = False
        Else
            tbTelef1.BackColor = Color.White
            MEP.SetError(tbTelef1, "")
        End If

        If tbTelef2.Text = String.Empty Then
            tbTelef2.BackColor = Color.Red
            MEP.SetError(tbTelef2, "ingrese celular del alumno!".ToUpper)
            _ok = False
        Else
            tbTelef2.BackColor = Color.White
            MEP.SetError(tbTelef2, "")
        End If

        'If tbObs.Text = String.Empty Then
        '    tbObs.BackColor = Color.Red
        '    MEP.SetError(tbObs, "ingrese la observacion del alumno!".ToUpper)
        '    _ok = False
        'Else
        '    tbObs.BackColor = Color.White
        '    MEP.SetError(tbObs, "")
        'End If

        If tbLugNac.SelectedIndex < 0 Then
            tbLugNac.BackColor = Color.Red
            MEP.SetError(tbLugNac, "seleccione la nacionalidad del alumno!".ToUpper)
            _ok = False
        Else
            tbLugNac.BackColor = Color.White
            MEP.SetError(tbLugNac, "")
        End If

        If tbTipo.SelectedIndex < 0 Then
            tbTipo.BackColor = Color.Red
            MEP.SetError(tbTipo, "seleccione el tipo del alumno!".ToUpper)
            _ok = False
        Else
            tbTipo.BackColor = Color.White
            MEP.SetError(tbTipo, "")
        End If

        If tbProf.SelectedIndex < 0 Then
            tbProf.BackColor = Color.Red
            MEP.SetError(tbProf, "seleccione la profesion del alumno!".ToUpper)
            _ok = False
        Else
            tbProf.BackColor = Color.White
            MEP.SetError(tbProf, "")
        End If

        If tbEstCivil.SelectedIndex < 0 Then
            tbEstCivil.BackColor = Color.Red
            MEP.SetError(tbEstCivil, "seleccione el estado civil del alumno!".ToUpper)
            _ok = False
        Else
            tbEstCivil.BackColor = Color.White
            MEP.SetError(tbEstCivil, "")
        End If

        If tbSuc.SelectedIndex < 0 Then
            tbSuc.BackColor = Color.Red
            MEP.SetError(tbSuc, "seleccione la sucursal a donde pertenece el alumno!".ToUpper)
            _ok = False
        Else
            tbSuc.BackColor = Color.White
            MEP.SetError(tbSuc, "")
        End If

        If tbFamiliar.Value = True Then
            If tbSocio.SelectedIndex < 0 Then
                tbSocio.BackColor = Color.Red
                MEP.SetError(tbSocio, "seleccione el socio con el cual tiene parentesco el alumno!".ToUpper)
                _ok = False
            Else
                tbSocio.BackColor = Color.White
                MEP.SetError(tbSocio, "")
            End If

            If tbParent.SelectedIndex < 0 Then
                tbParent.BackColor = Color.Red
                MEP.SetError(tbParent, "seleccione el parentesco del socio con el alumno!".ToUpper)
                _ok = False
            Else
                tbParent.BackColor = Color.White
                MEP.SetError(tbParent, "")
            End If
        End If

        If tbMenor.Value = True Then
            If tbTutCi.Text = "" Then
                tbTutCi.BackColor = Color.Red
                MEP.SetError(tbTutCi, "ingrese el ci del padre o tutor del alumno!".ToUpper)
                _ok = False
            Else
                tbTutCi.BackColor = Color.White
                MEP.SetError(tbTutCi, "")
            End If

            If tbTutNom.Text = "" Then
                tbTutNom.BackColor = Color.Red
                MEP.SetError(tbTutNom, "ingrese el nombre del padre o tutor del alumno!".ToUpper)
                _ok = False
            Else
                tbTutNom.BackColor = Color.White
                MEP.SetError(tbTutNom, "")
            End If
        End If

        MHighlighterFocus.UpdateHighlights()
        Return _ok
    End Function

    Public Overrides Function _PMOGetTablaBuscador() As DataTable
        Dim numiSuc As String = IIf(gb_userTodasSuc = True, "-1", gi_userSuc)
        Dim dtBuscador As DataTable = L_prAlumnoGeneral(numiSuc)
        Return dtBuscador
    End Function

    Public Overrides Function _PMOGetListEstructuraBuscador() As List(Of Modelos.Celda)
        Dim listEstCeldas As New List(Of Modelos.Celda)
        listEstCeldas.Add(New Modelos.Celda("cbnumi", True, "ID", 60))
        listEstCeldas.Add(New Modelos.Celda("cbci", True, "CI", 70))
        listEstCeldas.Add(New Modelos.Celda("cbnom", True, "NOMBRE", 200))
        listEstCeldas.Add(New Modelos.Celda("cbape", True, "APELLIDO", 200))
        listEstCeldas.Add(New Modelos.Celda("cbdirec", True, "DIRECCION", 200))
        listEstCeldas.Add(New Modelos.Celda("cbtelef1", True, "TELEFONO", 100))
        listEstCeldas.Add(New Modelos.Celda("cbtelef2", True, "CELULAR", 100))
        listEstCeldas.Add(New Modelos.Celda("cbemail", True, "E-MAIL", 100))
        listEstCeldas.Add(New Modelos.Celda("cbfot", False))
        listEstCeldas.Add(New Modelos.Celda("cbtipo", False))
        listEstCeldas.Add(New Modelos.Celda("tipodesc", True, "TIPO", 120))
        listEstCeldas.Add(New Modelos.Celda("cbprof", False))
        listEstCeldas.Add(New Modelos.Celda("profdesc", True, "PROFESION", 150))
        listEstCeldas.Add(New Modelos.Celda("cbfnac", True, "FEC. NACIMIENTO", 100))
        listEstCeldas.Add(New Modelos.Celda("cbfing", True, "FEC. INGRESO", 100))
        listEstCeldas.Add(New Modelos.Celda("cblnac", False))
        listEstCeldas.Add(New Modelos.Celda("cblnac2", True, "NACIONALIDAD", 120))
        listEstCeldas.Add(New Modelos.Celda("cbest", False))
        listEstCeldas.Add(New Modelos.Celda("cbest2", True, "ESTADO", 80))
        listEstCeldas.Add(New Modelos.Celda("cbeciv", False))
        listEstCeldas.Add(New Modelos.Celda("civildesc", True, "EST. CIVIL", 120))
        listEstCeldas.Add(New Modelos.Celda("cbobs", True, "OBSERVACION", 120))
        listEstCeldas.Add(New Modelos.Celda("cbnumiSoc", True, "COD SOCIO", 80))
        listEstCeldas.Add(New Modelos.Celda("sociodesc", True, "SOCIO", 120))
        listEstCeldas.Add(New Modelos.Celda("cbparent", False))
        listEstCeldas.Add(New Modelos.Celda("parentdesc", True, "PARENTESCO", 120))
        listEstCeldas.Add(New Modelos.Celda("cbmen", False))
        listEstCeldas.Add(New Modelos.Celda("cbmen2", True, "MENOR", 80))
        listEstCeldas.Add(New Modelos.Celda("cbtutci", True, "PADRE CI", 80))
        listEstCeldas.Add(New Modelos.Celda("cbtutnom", True, "PADRE NOM", 120))
        listEstCeldas.Add(New Modelos.Celda("cbsuc", False))
        listEstCeldas.Add(New Modelos.Celda("cadesc", True, "SUCURSAL", 120))
        listEstCeldas.Add(New Modelos.Celda("cbnrogr", True, "NRO. GRUPO", 70))
        listEstCeldas.Add(New Modelos.Celda("cbnfact", True, "NRO. FACTURA", 100))
        listEstCeldas.Add(New Modelos.Celda("cbfact", False))
        listEstCeldas.Add(New Modelos.Celda("cbhact", False))
        listEstCeldas.Add(New Modelos.Celda("cbuact", False))
        Return listEstCeldas
    End Function

    Public Overrides Sub _PMOMostrarRegistro(_N As Integer)
        JGrM_Buscador.Row = _MPos

        With JGrM_Buscador
            tbNumi.Text = .GetValue("cbnumi").ToString
            tbCi.Text = .GetValue("cbci").ToString
            tbNombre.Text = .GetValue("cbnom").ToString
            tbApellido.Text = .GetValue("cbape").ToString
            tbDireccion.Text = .GetValue("cbdirec").ToString
            tbTelef1.Text = .GetValue("cbtelef1").ToString
            tbTelef2.Text = .GetValue("cbtelef2").ToString
            tbEmail.Text = .GetValue("cbemail").ToString

            tbEstado.Value = .GetValue("cbest")
            tbEstCivil.Text = .GetValue("civildesc")
            tbTipo.Text = .GetValue("tipodesc")
            tbFIng.Value = .GetValue("cbfing")
            tbFNac.Value = .GetValue("cbfnac")
            tbLugNac.Value = .GetValue("cblnac")
            tbProf.Text = .GetValue("profdesc")
            tbObs.Text = .GetValue("cbobs").ToString
            tbSuc.Text = .GetValue("cadesc")
            tbNroGrupo.Text = .GetValue("cbnrogr").ToString
            tbNroFactura.Text = .GetValue("cbnfact").ToString

            Dim nomImg = .GetValue("cbfot").ToString
            If nomImg = String.Empty Then
                pbImg.Image = Nothing
            Else
                Dim rutaOrigen As String = vlRutaBase + "\Imagenes\Imagenes Alumnos\"
                vlImagen = New CImagen(nomImg, rutaOrigen + nomImg, 1)
                pbImg.SizeMode = PictureBoxSizeMode.StretchImage
                Try
                    pbImg.Load(vlImagen.getImagen())
                Catch ex As Exception
                    pbImg.Image = Nothing
                    vlImagen = Nothing
                End Try

            End If

            Dim parentesco As String = .GetValue("parentdesc").ToString
            If parentesco = "" Then
                tbFamiliar.Value = False
                tbParent.Text = ""
                tbSocio.Text = ""
            Else
                tbFamiliar.Value = True
                tbParent.Text = parentesco
                tbSocio.Text = .GetValue("sociodesc")
            End If

            Dim menorEdad As String = .GetValue("cbmen").ToString
            If menorEdad = "0" Then
                tbMenor.Value = False
                tbTutCi.Text = ""
                tbTutNom.Text = ""
            Else
                tbMenor.Value = True
                tbTutCi.Text = .GetValue("cbtutci").ToString
                tbTutNom.Text = .GetValue("cbtutnom").ToString
            End If

            lbFecha.Text = CType(.GetValue("cbfact"), Date).ToString("dd/MM/yyyy")
            lbHora.Text = .GetValue("cbhact").ToString
            lbUsuario.Text = .GetValue("cbuact").ToString

        End With

        LblPaginacion.Text = Str(_MPos + 1) + "/" + JGrM_Buscador.RowCount.ToString

    End Sub
    Public Overrides Sub _PMOHabilitarFocus()
        With MHighlighterFocus
            .SetHighlightOnFocus(tbApellido, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
            .SetHighlightOnFocus(tbCi, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
            .SetHighlightOnFocus(tbDireccion, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
            .SetHighlightOnFocus(tbEmail, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
            .SetHighlightOnFocus(tbNombre, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
            .SetHighlightOnFocus(tbTelef2, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
            .SetHighlightOnFocus(tbTelef1, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
            .SetHighlightOnFocus(tbEstado, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
            .SetHighlightOnFocus(tbEstCivil, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
            .SetHighlightOnFocus(tbFIng, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
            .SetHighlightOnFocus(tbFNac, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
            .SetHighlightOnFocus(tbLugNac, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
            .SetHighlightOnFocus(tbObs, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
            .SetHighlightOnFocus(tbProf, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
            .SetHighlightOnFocus(tbTipo, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
            .SetHighlightOnFocus(tbParent, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
            .SetHighlightOnFocus(tbFamiliar, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
            .SetHighlightOnFocus(tbSocio, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
            .SetHighlightOnFocus(tbMenor, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
            .SetHighlightOnFocus(tbTutCi, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
            .SetHighlightOnFocus(tbTutNom, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
            .SetHighlightOnFocus(tbSuc, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
            .SetHighlightOnFocus(tbNroGrupo, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
            .SetHighlightOnFocus(tbNroFactura, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
        End With

    End Sub

#End Region

#Region "CLASE AUXILIAR"
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
#End Region

    Private Sub P_Instructores_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _prIniciarTodo()
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        tbCi.Focus()
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        tbCi.Focus()
    End Sub

    Private Sub RadialMenuImgOpc_ItemClick(sender As Object, e As EventArgs) Handles RadialMenuImgOpc.ItemClick
        Dim item As RadialMenuItem = TryCast(sender, RadialMenuItem)
        If item IsNot Nothing AndAlso (Not String.IsNullOrEmpty(item.Text)) Then
            Select Case item.Name
                Case "btnAgregar"
                    _prCargarImagen()
                Case "btnElimImg"
                    _prEliminarImagen()
            End Select

        End If
    End Sub



    Private Sub tbFamiliar_ValueChanged(sender As Object, e As EventArgs) Handles tbFamiliar.ValueChanged
        tbSocio.Enabled = tbFamiliar.Value
        tbParent.Enabled = tbFamiliar.Value
    End Sub

    Private Sub tbMenor_ValueChanged(sender As Object, e As EventArgs) Handles tbMenor.ValueChanged
        tbTutCi.Enabled = tbMenor.Value
        tbTutNom.Enabled = tbMenor.Value
    End Sub

    Private Sub tbEmail_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbEmail.KeyPress
        e.KeyChar = e.KeyChar.ToString.ToLower
    End Sub


    Private Sub btEstadoCivil_Click(sender As Object, e As EventArgs) Handles btEstadoCivil.Click
        Dim numi As String = ""

        If L_prLibreriaGrabar(numi, gi_LibALUMNO, gi_LibALUMEstCivil, tbEstCivil.Text, "") Then
            _prCargarComboLibreria(tbEstCivil, gi_LibALUMNO, gi_LibALUMEstCivil)
            tbEstCivil.SelectedIndex = CType(tbEstCivil.DataSource, DataTable).Rows.Count - 1
        End If

    End Sub

    Private Sub btTipo_Click(sender As Object, e As EventArgs) Handles btTipo.Click
        Dim numi As String = ""

        If L_prLibreriaGrabar(numi, gi_LibALUMNO, gi_LibALUMTipo, tbTipo.Text, "") Then
            _prCargarComboLibreria(tbTipo, gi_LibALUMNO, gi_LibALUMTipo)
            tbTipo.SelectedIndex = CType(tbTipo.DataSource, DataTable).Rows.Count - 1
        End If
    End Sub

    Private Sub btProfesion_Click(sender As Object, e As EventArgs) Handles btProfesion.Click
        Dim numi As String = ""

        If L_prLibreriaGrabar(numi, gi_LibALUMNO, gi_LibALUMProfesion, tbProf.Text, "") Then
            _prCargarComboLibreria(tbProf, gi_LibALUMNO, gi_LibALUMProfesion)
            tbProf.SelectedIndex = CType(tbProf.DataSource, DataTable).Rows.Count - 1
        End If
    End Sub

    Private Sub btParentesco_Click(sender As Object, e As EventArgs) Handles btParentesco.Click
        Dim numi As String = ""

        If L_prLibreriaGrabar(numi, gi_LibALUMNO, gi_LibALUMParentesco, tbParent.Text, "") Then
            _prCargarComboLibreria(tbParent, gi_LibALUMNO, gi_LibALUMParentesco)
            tbParent.SelectedIndex = CType(tbParent.DataSource, DataTable).Rows.Count - 1
        End If
    End Sub

    Private Sub tbEstCivil_ValueChanged(sender As Object, e As EventArgs) Handles tbEstCivil.ValueChanged
        If tbEstCivil.SelectedIndex < 0 And tbEstCivil.Text <> String.Empty Then
            btEstadoCivil.Visible = True
        Else
            btEstadoCivil.Visible = False
        End If
    End Sub

    Private Sub tbTipo_ValueChanged(sender As Object, e As EventArgs) Handles tbTipo.ValueChanged
        If tbTipo.SelectedIndex < 0 And tbTipo.Text <> String.Empty Then
            btTipo.Visible = True
        Else
            btTipo.Visible = False
        End If
    End Sub

    Private Sub tbProf_ValueChanged(sender As Object, e As EventArgs) Handles tbProf.ValueChanged
        If tbProf.SelectedIndex < 0 And tbProf.Text <> String.Empty Then
            btProfesion.Visible = True
        Else
            btProfesion.Visible = False
        End If
    End Sub

    Private Sub tbParent_ValueChanged(sender As Object, e As EventArgs) Handles tbParent.ValueChanged
        If tbParent.SelectedIndex < 0 And tbParent.Text <> String.Empty Then
            btParentesco.Visible = True
        Else
            btParentesco.Visible = False
        End If
    End Sub

    Private Sub tbLugNac_ValueChanged(sender As Object, e As EventArgs) Handles tbLugNac.ValueChanged
        If tbLugNac.SelectedIndex < 0 And tbLugNac.Text <> String.Empty Then
            btLugNac.Visible = True
        Else
            btLugNac.Visible = False
        End If
    End Sub

    Private Sub btLugNac_Click(sender As Object, e As EventArgs) Handles btLugNac.Click
        Dim numi As String = ""

        If L_prLibreriaGrabar(numi, gi_LibALUMNO, gi_LibALUMNacionalidad, tbLugNac.Text, "") Then
            _prCargarComboLibreria(tbLugNac, gi_LibALUMNO, gi_LibALUMNacionalidad)
            tbLugNac.SelectedIndex = CType(tbLugNac.DataSource, DataTable).Rows.Count - 1
        End If
    End Sub

    Private Sub btnGrabar_Click(sender As Object, e As EventArgs) Handles btnGrabar.Click

    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        _prImprimir()
    End Sub

    Private Sub btMarcarTodos_Click(sender As Object, e As EventArgs) Handles btMarcarTodos.Click
        _prImprimirPlanillaControlClasesPracticas()
    End Sub

    Private Sub tbNroFactura_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbNroFactura.KeyPress
        g_prValidarTextBox(1, e)
    End Sub

    Private Sub ToolStripMenuItemCopiar_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemCopiar.Click
        grDatos = JGrM_Buscador.GetRow(JGrM_Buscador.Row)
    End Sub

    Private Sub ToolStripMenuItemPegar_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemPegar.Click
        If (Not grDatos Is Nothing) Then
            With grDatos
                tbNumi.Text = "" '.Cells("cbnumi").Value.ToString
                tbCi.Text = .Cells("cbci").Value.ToString
                tbNombre.Text = .Cells("cbnom").Value.ToString
                tbApellido.Text = .Cells("cbape").Value.ToString
                tbDireccion.Text = .Cells("cbdirec").Value.ToString
                tbTelef1.Text = .Cells("cbtelef1").Value.ToString
                tbTelef2.Text = .Cells("cbtelef2").Value.ToString
                tbEmail.Text = .Cells("cbemail").Value.ToString

                tbEstado.Value = .Cells("cbest").Value
                tbEstCivil.Text = .Cells("civildesc").Value
                tbTipo.Text = .Cells("tipodesc").Value
                tbFIng.Value = .Cells("cbfing").Value
                tbFNac.Value = .Cells("cbfnac").Value
                tbLugNac.Value = .Cells("cblnac").Value
                tbProf.Text = .Cells("profdesc").Value
                tbObs.Text = .Cells("cbobs").Value.ToString
                tbSuc.Text = .Cells("cadesc").Value
                tbNroGrupo.Text = "" '.Cells("cbnrogr").Value.ToString
                tbNroFactura.Text = "" '.Cells("cbnfact").Value.ToString

                Dim nomImg = .Cells("cbfot").Value.ToString
                If nomImg = String.Empty Then
                    pbImg.Image = Nothing
                Else
                    Dim rutaOrigen As String = vlRutaBase + "\Imagenes\Imagenes Alumnos\"
                    vlImagen = New CImagen(nomImg, rutaOrigen + nomImg, 1)
                    pbImg.SizeMode = PictureBoxSizeMode.StretchImage
                    Try
                        pbImg.Load(vlImagen.getImagen())
                    Catch ex As Exception
                        pbImg.Image = Nothing
                        vlImagen = Nothing
                    End Try

                End If

                Dim parentesco As String = .Cells("parentdesc").Value.ToString
                If parentesco = "" Then
                    tbFamiliar.Value = False
                    tbParent.Text = ""
                    tbSocio.Text = ""
                Else
                    tbFamiliar.Value = True
                    tbParent.Text = parentesco
                    tbSocio.Text = .Cells("sociodesc").Value
                End If

                Dim menorEdad As String = .Cells("cbmen").Value.ToString
                If menorEdad = "0" Then
                    tbMenor.Value = False
                    tbTutCi.Text = ""
                    tbTutNom.Text = ""
                Else
                    tbMenor.Value = True
                    tbTutCi.Text = .Cells("cbtutci").Value.ToString
                    tbTutNom.Text = .Cells("cbtutnom").Value.ToString
                End If
            End With
        End If
    End Sub

    Private Sub tbNroFactura_KeyDown(sender As Object, e As KeyEventArgs) Handles tbNroFactura.KeyDown
        'Dim frmAyuda As Modelos.ModeloAyuda
        'Dim dt As DataTable

        'dt = L_prClasesPracObtenerFacturasEscuela()

        'Dim listEstCeldas As New List(Of Modelos.Celda)
        'listEstCeldas.Add(New Modelos.Celda("vcnumi", False))
        'listEstCeldas.Add(New Modelos.Celda("fvanfac", True, "Nro. Factura".ToUpper, 100))
        'listEstCeldas.Add(New Modelos.Celda("fvanitcli", True, "NIT".ToUpper, 100))
        'listEstCeldas.Add(New Modelos.Celda("fvadescli1", True, "CLIENTE".ToUpper, 200))
        'listEstCeldas.Add(New Modelos.Celda("vcfdoc", True, "FECHA".ToUpper, 100))
        'listEstCeldas.Add(New Modelos.Celda("vcobs", True, "OBSERVACION".ToUpper, 200))


        'frmAyuda = New Modelos.ModeloAyuda(200, 200, dt, "seleccione factura".ToUpper, listEstCeldas)
        'frmAyuda.ShowDialog()

        'If frmAyuda.seleccionado = True Then
        '    Dim numero As String = frmAyuda.filaSelect.Cells("fvanfac").Value
        '    Dim numiFact As String = frmAyuda.filaSelect.Cells("vcnumi").Value

        '    tbNroFactura.Text = numero
        '    tbNroFactura.Tag = numiFact

        'End If
    End Sub
End Class