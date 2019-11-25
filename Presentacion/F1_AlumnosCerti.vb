Option Strict Off
Imports Logica.AccesoLogica
Imports DevComponents.DotNetBar
Imports Janus.Windows.GridEX
Imports System.IO

'DESARROLLADO POR: DANNY GUTIERREZ
Public Class F1_AlumnosCerti

#Region "Variables locales"
    Private vlImagen As CImagen = Nothing
    Private vlRutaBase As String = gs_CarpetaRaiz '"C:\Imagenes\DIES"
    Public _nameButton As String
    Dim RutaGlobal As String = gs_CarpetaRaiz + "\Imagenes\Imagenes Alumnos Certificacion\"
#End Region


#Region "METODOS PRIVADOS"
    Private Sub _prIniciarTodo()
        Me.Text = "A L U M N O S"
        _prCargarComboInstructores()
        _prCargarComboLibreria(tbCatLicencia, gi_LibALUMCERTI, gi_LibALUMCERTICategLic)
        _prCargarComboLibreria(TbNac, gi_LibALUMNO, gi_LibALUMNacionalidad)
        _prCargarComboLibreria(cbempresa, 21, 1)
        _prCargarGridSugerencia()
        _prCargarComboSucursal()

        _PMIniciarTodo()
        _prSetCondicionesGrilla()
        _prAsignarPermisos()

        btnInscribir.Tag = 0
        btnReinscribir.Tag = 0
        btnImprimir.Visible = True
        'gpInscripcion.Visible = False

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

        'If gb_userTodasSuc = False Then
        '    tbSuc.Enabled = False
        'End If
    End Sub

    Public Sub _prCargarComboInstructores()
        Dim dt As New DataTable
        dt = L_prPersonaAyudaGeneral(gi_LibPERSTIPOInstructor) 'gi_userSuc

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
    Private Sub _prSetCondicionesGrilla()
        Dim fc, fc1 As GridEXFormatCondition
        fc = New GridEXFormatCondition(JGrM_Buscador.RootTable.Columns("emtipo"), ConditionOperator.Equal, 1)
        fc.FormatStyle.BackColor = Color.LightSeaGreen

        fc1 = New GridEXFormatCondition(JGrM_Buscador.RootTable.Columns("emtipo"), ConditionOperator.Equal, 2)
        fc1.FormatStyle.BackColor = Color.LightSkyBlue

        JGrM_Buscador.RootTable.FormatConditions.Add(fc)
        JGrM_Buscador.RootTable.FormatConditions.Add(fc1)

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
        Dim rutaDestino As String = vlRutaBase + "\Imagenes\Imagenes Alumnos Certificacion\"
        If System.IO.Directory.Exists(rutaDestino) = False Then
            If System.IO.Directory.Exists(vlRutaBase + "\Imagenes\") = False Then
                System.IO.Directory.CreateDirectory(vlRutaBase + "\Imagenes")
                If System.IO.Directory.Exists(vlRutaBase + "\Imagenes\Imagenes Alumnos Certificacion\") = False Then
                    System.IO.Directory.CreateDirectory(vlRutaBase + "\Imagenes\Imagenes Alumnos Certificacion")
                End If
            Else
                If System.IO.Directory.Exists(vlRutaBase + "\Imagenes\Imagenes Alumnos Certificacion") = False Then
                    System.IO.Directory.CreateDirectory(vlRutaBase + "\Imagenes\Imagenes Alumnos Certificacion")
                End If
            End If
        End If

        Dim rutaOrigen As String
        rutaOrigen = vlImagen.getImagen()
        FileCopy(rutaOrigen, rutaDestino + vlImagen.nombre + ".jpg")

    End Sub

    Private Sub _prCargarGridSugerencia()
        Dim dt As New DataTable
        'dt = L_prAlumnoCertiGetAprobadosTC007General()
        dt = L_prAlumnoCertiAlumnosDeEscuela()

        grSugerencia.DataSource = dt
        grSugerencia.RetrieveStructure()

        'dar formato a las columnas
        With grSugerencia.RootTable.Columns("ejalum")
            .Caption = "Cod.".ToUpper
            .Width = 50
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        End With

        With grSugerencia.RootTable.Columns("cbci")
            .Caption = "ci".ToUpper
            .Width = 70
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        End With

        With grSugerencia.RootTable.Columns("cbape")
            .Caption = "apellido".ToUpper
            .Width = 200
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
        End With

        With grSugerencia.RootTable.Columns("cbnom")
            .Caption = "Nombre".ToUpper
            .Width = 200
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
        End With


        With grSugerencia.RootTable.Columns("cbfnac")
            .Caption = "Fecha Nac.".ToUpper
            .Width = 70
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        End With

        With grSugerencia.RootTable.Columns("cbfot")
            .Caption = "Foto".ToUpper
            .Width = 100
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        End With

        With grSugerencia.RootTable.Columns("cbtelef1")
            .Visible = False
        End With

        With grSugerencia.RootTable.Columns("cbtelef2")
            .Visible = False
        End With

        With grSugerencia.RootTable.Columns("numiInst")
            .Visible = False
        End With

        'Habilitar Filtradores
        With grSugerencia
            '.DefaultFilterRowComparison = FilterConditionOperator.Contains
            '.FilterMode = FilterMode.Automatic
            '.FilterRowUpdateMode = FilterRowUpdateMode.WhenValueChanges
            .GroupByBoxVisible = False
            'diseño de la grilla
            .VisualStyle = VisualStyle.Office2007
        End With


    End Sub

    Private Sub _prCargarAlumnoSeleccionado()
        With grSugerencia
            tbCi.Text = .GetValue("cbci")
            tbNombre.Text = .GetValue("cbnom")
            Dim apellido As String = .GetValue("cbape") + " "
            tbApellidoP.Text = apellido.Split(" ")(0).Trim
            tbApellidoM.Text = IIf(apellido.Split(" ").Count >= 2, apellido.Split(" ")(1).Trim, "")

            tbFNac.Text = .GetValue("cbfnac")
            tbEscNumiAlum.Text = .GetValue("ejalum")

            tbTelf.Text = .GetValue("cbtelef1")
            tbCel.Text = .GetValue("cbtelef2")

            tbPersona.Value = .GetValue("numiInst")
            TbNac.Text = "BOLIVIANA"
            TbNac.Value = 2

            'cargar imagen del alumno
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
        End With
        tbEscuela.Value = True
    End Sub

    Private Sub _prInscribirAlumnoExistente()


        If btnGrabar.Enabled = True Then
            Exit Sub
        End If
        cbempresa.ReadOnly = False
        swtipo.IsReadOnly = False

        If btnInscribir.Tag = 0 Then
            btnReinscribir.Visible = False
            tbTipoExamen.Value = False

            btnNuevo.Visible = False
            btnModificar.Visible = False
            btnEliminar.Visible = False
            btnEliminarInscripcion.Visible = False
            btnInscribir.Image = My.Resources.OK
            btnInscribir.Text = "confirmar inscripcion".ToUpper
            btnInscribir.Tag = 1

            'gpInscripcion.Visible = True


            tbCatLicencia.ReadOnly = False
            TbNac.ReadOnly = False
            tbObs.ReadOnly = False
            tbNroFact.ReadOnly = False
            tbFechaTeo.Enabled = True

            tbCatLicencia.SelectedIndex = -1
            TbNac.SelectedIndex = -1
            tbObs.Text = ""
            tbNroFact.Text = ""

            tbFechaTeo.Value = Now.Date
            Dim dtInscTeo As DataTable = L_prExamenAlumnoCertiGeneralInscritos(tbFechaTeo.Value.ToString("yyyy/MM/dd"), IIf(tbTipoExamen.Value = False, 1, 2))
            tbNroInscr.Text = dtInscTeo.Rows.Count.ToString

            ToastNotification.Show(Me, "ingrese los datos de la inscripcion".ToUpper, My.Resources.INFORMATION, 5000, eToastGlowColor.Blue, eToastPosition.TopCenter)

            tbCatLicencia.Focus()

        Else

            If _PMOValidarCamposInscripcion() Then
                Dim dtRegistrosNroFact As DataTable = L_prExamenAlumnoCertiBuscarRegistroPorNroFactura(tbNroFact.Text)
                If dtRegistrosNroFact.Rows.Count > 0 Then
                    ToastNotification.Show(Me, "ya existe registrado el nro de factura ".ToUpper + tbNroFact.Text + " con el alumno ".ToUpper + dtRegistrosNroFact.Rows(0).Item("elnom2"), My.Resources.WARNING, 5000, eToastGlowColor.Blue, eToastPosition.TopCenter)
                    Exit Sub
                End If

                If Int(tbNroInscr.Text) >= gi_nroMaxAlumTeo Then
                    ToastNotification.Show(Me, "no se puede inscribir al alumno por que ya no hay cupos para esta fecha.".ToUpper, My.Resources.WARNING, 5000, eToastGlowColor.Blue, eToastPosition.TopCenter)
                    Exit Sub
                End If
                Dim numi As String = ""
                'grabar la inscripcion para el examen teorico en la tabla TCE010
                L_prExamenAlumnoCertiGrabar(numi, tbNumi.Text, tbFechaTeo.Value.ToString("yyyy/MM/dd"), 0, 0, 0, 1, tbNroFact.Text, tbObs.Text, tbCatLicencia.Value, "1", IIf(swtipo.Value = True, 0, cbempresa.Value), 0) 'tbNroFact.Tag.ToString().Trim

                If tbCatLicencia.Value <> 6 Then
                    'grabar la inscripcion para el examen practico en la tabla TCE010
                    L_prExamenAlumnoCertiGrabar(numi, tbNumi.Text, tbFechaTeo.Value.ToString("yyyy/MM/dd"), 0, 0, 0, 2, tbNroFact.Text, tbObs.Text, tbCatLicencia.Value, "1", IIf(swtipo.Value = True, 0, cbempresa.Value), -1)
                End If

                ToastNotification.Show(Me, "inscripcion de alumno ".ToUpper + tbNumi.Text + " Grabado con Exito.".ToUpper, My.Resources.GRABACION_EXITOSA, 5000, eToastGlowColor.Green, eToastPosition.TopCenter)

                btnNuevo.Visible = True
                btnModificar.Visible = True
                btnEliminar.Visible = True
                btnEliminarInscripcion.Visible = True

                btnInscribir.Image = My.Resources.INSCRIPCION
                btnInscribir.Tag = 0
                btnInscribir.Text = "inscribir".ToUpper

                tbCatLicencia.ReadOnly = True
                TbNac.ReadOnly = True
                tbObs.ReadOnly = True
                tbNroFact.ReadOnly = True

                'gpInscripcion.Visible = False

                tbCatLicencia.Text = ""
                TbNac.Text = ""
                tbObs.Text = ""
                tbNroFact.Text = ""

                btnReinscribir.Visible = True

                _PMIniciarTodo()
                _prSetCondicionesGrilla()
            End If


        End If


    End Sub

    Private Sub _prInscribirAlumnoPerfeccionamiento()


        If btnGrabar.Enabled = True Then
            Exit Sub
        End If

        If btnInscribirPerfeccionamiento.Tag = 0 Then
            btnReinscribir.Visible = False
            btnInscribir.Visible = False


            btnNuevo.Visible = False
            btnModificar.Visible = False
            btnEliminar.Visible = False
            btnEliminarInscripcion.Visible = False
            btnInscribirPerfeccionamiento.Image = My.Resources.OK
            btnInscribirPerfeccionamiento.Text = "confirmar inscripcion".ToUpper
            btnInscribirPerfeccionamiento.Tag = 1

            gpInscripcion.Visible = False
            gpPerfeccionamiento.Visible = True
            'gpInscripcion.Visible = True



            tbObsPer.ReadOnly = False
            tbNroFactPer.ReadOnly = False
            tbCantClasesPerfec.IsInputReadOnly = False

            tbObsPer.Text = ""
            tbNroFactPer.Text = ""
            tbCantClasesPerfec.Value = 0


            ToastNotification.Show(Me, "ingrese los datos de la inscripcion".ToUpper, My.Resources.INFORMATION, 5000, eToastGlowColor.Blue, eToastPosition.TopCenter)

            tbNroFactPer.Focus()
        Else
            If _PMOValidarCamposInscripcionPerfeccionamiento() Then


                btnNuevo.Visible = True
                btnModificar.Visible = True
                btnEliminar.Visible = True
                btnEliminarInscripcion.Visible = True

                btnInscribirPerfeccionamiento.Image = My.Resources.INSCRIPCION
                btnInscribirPerfeccionamiento.Tag = 0
                btnInscribirPerfeccionamiento.Text = "inscribir perfeccionamiento".ToUpper


                tbObs.ReadOnly = True
                tbNroFact.ReadOnly = True
                tbCantClasesPerfec.IsInputReadOnly = True

                gpInscripcion.Visible = True
                gpPerfeccionamiento.Visible = False

                btnReinscribir.Visible = True
                btnInscribirPerfeccionamiento.Visible = True
                btnInscribir.Visible = True

                'llamo al programa para programar el horario
                Dim frm As F0_CertificacionReforzamiento
                frm = New F0_CertificacionReforzamiento
                frm.tbCantClasesPerfec.Text = tbCantClasesPerfec.Text
                frm.tbNroFactPer.Text = tbNroFactPer.Text
                frm.tbObsPer.Text = tbObsPer.Text
                frm._numiAlumInscrito = tbNumi.Text
                frm._cantClasesPracticas = tbCantClasesPerfec.Value
                frm.ShowDialog()

                tbObs.Text = ""
                tbNroFact.Text = ""
                tbCantClasesPerfec.Text = ""

                _PMIniciarTodo()
                _prSetCondicionesGrilla()
            End If


        End If


    End Sub

    Private Sub _prReInscribirAlumnoExistente()
        Dim nroOpcion As Integer = tbNroOpcion.Text
        Dim dtReg As DataTable = L_prExamenAlumnoCertiGeneralRegistrosPorNroFactura(tbNroFact.Text, tbNumi.Text, IIf(tbTipoExamen.Value = False, 1, 2))



        If btnGrabar.Enabled = True Or nroOpcion = 0 Then
            Exit Sub
        End If

        If dtReg.Rows.Count = 2 Or nroOpcion = 2 Then
            ToastNotification.Show(Me, "el alumno ya tiene inscrito su segunda opcion.".ToUpper, My.Resources.WARNING, 5000, eToastGlowColor.Blue, eToastPosition.TopCenter)
            Exit Sub
        End If


        If btnReinscribir.Tag = 0 Then
            btnInscribir.Visible = False

            btnNuevo.Visible = False
            btnModificar.Visible = False
            btnEliminar.Visible = False
            btnEliminarInscripcion.Visible = False
            btnReinscribir.Image = My.Resources.OK
            btnReinscribir.Text = "confirmar inscripcion".ToUpper
            btnReinscribir.Tag = 1

            'gpInscripcion.Visible = True


            'tbCatLicencia.ReadOnly = False
            tbObs.ReadOnly = False
            'tbNroFact.ReadOnly = False
            tbFechaTeo.Enabled = True 'ESTO LO DEJO BLOQUEADO PARA QUE SOLO SE PUEDA REPROGRAMAR ESE MISMO DIA

            'tbCatLicencia.SelectedIndex = -1
            'tbObs.Text = ""
            'tbNroFact.Text = ""

            ''tbFechaTeo.Value = Now.Date
            Dim dtInscTeo As DataTable = L_prExamenAlumnoCertiGeneralInscritos(tbFechaTeo.Value.ToString("yyyy/MM/dd"), IIf(tbTipoExamen.Value = False, 1, 2))
            tbNroInscr.Text = dtInscTeo.Rows.Count.ToString

            ToastNotification.Show(Me, "ingrese los datos de la inscripcion".ToUpper, My.Resources.INFORMATION, 5000, eToastGlowColor.Blue, eToastPosition.TopCenter)

            tbCatLicencia.Focus()

        Else
            If _PMOValidarCamposInscripcion() Then
                If Int(tbNroInscr.Text) >= gi_nroMaxAlumTeo Then
                    ToastNotification.Show(Me, "no se puede inscribir al alumno por que ya no hay cupos para esta fecha.".ToUpper, My.Resources.WARNING, 5000, eToastGlowColor.Blue, eToastPosition.TopCenter)
                    Exit Sub
                End If

                'grabar la inscripcion para el examen en la tabla TCE010
                L_prExamenAlumnoCertiGrabar("", tbNumi.Text, tbFechaTeo.Value.ToString("yyyy/MM/dd"), 0, 0, 0, IIf(tbTipoExamen.Value = False, 1, 2), tbNroFact.Text, tbObs.Text, tbCatLicencia.Value, "2", IIf(swtipo.Value = True, 0, cbempresa.Value), -1)   '''''MARCOOOOO

                ToastNotification.Show(Me, "re-inscripcion de alumno ".ToUpper + tbNumi.Text + " Grabado con Exito.".ToUpper, My.Resources.GRABACION_EXITOSA, 5000, eToastGlowColor.Green, eToastPosition.TopCenter)

                btnNuevo.Visible = True
                btnModificar.Visible = True
                btnEliminar.Visible = True
                btnEliminarInscripcion.Visible = True

                btnReinscribir.Image = My.Resources.REINSCRIPCION
                btnReinscribir.Tag = 0
                btnReinscribir.Text = "reinscribir".ToUpper

                tbCatLicencia.ReadOnly = True
                TbNac.ReadOnly = True
                tbObs.ReadOnly = True
                tbNroFact.ReadOnly = True

                'gpInscripcion.Visible = False

                tbCatLicencia.Text = ""
                TbNac.Text = ""
                tbObs.Text = ""
                tbNroFact.Text = ""

                btnInscribir.Visible = True

                _PMIniciarTodo()
                _prSetCondicionesGrilla()
            End If


        End If


    End Sub

    Private Sub _prImprimir()
        Dim objrep As New R_DatosPersoPostu
        Dim _dt As New DataTable
        _dt = L_prDatosPersonalesPost(tbNumi.Text, tbNroFact.Text)
        While _dt.Rows.Count > 1
            _dt.Rows.RemoveAt(_dt.Rows.Count - 1)
        End While



        Dim fechaTeo1, fechaTeo2, fechaPrac1, fechaPrac2 As String
        fechaTeo1 = ""
        fechaTeo2 = ""
        fechaPrac1 = ""
        fechaPrac2 = ""

        Dim dtRegTeo As DataTable = L_prExamenAlumnoCertiGeneralRegistrosPorNroFactura(tbNroFact.Text, tbNumi.Text, 1)
        Dim dtRegPrac As DataTable = L_prExamenAlumnoCertiGeneralRegistrosPorNroFactura(tbNroFact.Text, tbNumi.Text, 2)

        Dim diaLiteralTeo As String = ""
        Dim diaLiteralPrac As String = ""
        If dtRegTeo.Rows.Count > 0 Then
            If dtRegTeo.Rows.Count = 1 Then
                fechaTeo1 = dtRegTeo.Rows(0).Item("emfecha")
                diaLiteralTeo = Format(dtRegTeo.Rows(0).Item("emfecha"), "dddd").ToUpper 'WeekdayName(Weekday(dtRegTeo.Rows(0).Item("emfecha")), True, FirstDayOfWeek.Monday)
            Else
                fechaTeo1 = dtRegTeo.Rows(0).Item("emfecha")
                fechaTeo2 = dtRegTeo.Rows(1).Item("emfecha")
                diaLiteralTeo = Format(dtRegTeo.Rows(1).Item("emfecha"), "dddd").ToUpper 'WeekdayName(Weekday(dtRegTeo.Rows(1).Item("emfecha")), True, FirstDayOfWeek.Monday)
            End If
        End If

        If dtRegPrac.Rows.Count > 0 Then
            If dtRegPrac.Rows.Count = 1 Then
                fechaPrac1 = dtRegPrac.Rows(0).Item("emfecha")
                diaLiteralPrac = Format(dtRegPrac.Rows(0).Item("emfecha"), "dddd").ToUpper ' WeekdayName(Weekday(dtRegPrac.Rows(0).Item("emfecha")), True, FirstDayOfWeek.Monday)
            Else
                fechaPrac1 = dtRegPrac.Rows(0).Item("emfecha")
                fechaPrac2 = dtRegPrac.Rows(1).Item("emfecha")
                diaLiteralPrac = Format(dtRegPrac.Rows(1).Item("emfecha"), "dddd").ToUpper 'WeekdayName(Weekday(dtRegPrac.Rows(1).Item("emfecha")), True, FirstDayOfWeek.Monday)
            End If
        End If

        Dim diaExamenTeo As String = diaLiteralTeo + ": 08:00am".ToUpper
        Dim diaExamenPrac As String = diaLiteralPrac + ": 09:30am".ToUpper
        If tbCatLicencia.Text = "M" Then
            diaExamenPrac = diaLiteralPrac + ": 12:30pm".ToUpper
        End If



        'imprimir
        'If PrintDialog1.ShowDialog = DialogResult.OK Then
        '    ''_prDibujarDataSourceImagen(_dt)
        '    _prDibujarDataSourceImagen2(_dt)

        '    objrep.SetDataSource(_dt)

        '    objrep.SetParameterValue("nombres", tbNombre.Text + " " + tbApellidoP.Text + " " + tbApellidoM.Text)
        '    objrep.SetParameterValue("FechaTeo1", fechaTeo1)
        '    objrep.SetParameterValue("FechaTeo2", fechaTeo2)
        '    objrep.SetParameterValue("FechaPrac1", fechaPrac1)
        '    objrep.SetParameterValue("FechaPrac2", fechaPrac2)
        '    objrep.SetParameterValue("DiaTeo", diaExamenTeo)
        '    objrep.SetParameterValue("DiaPrac", diaExamenPrac)



        '    objrep.PrintOptions.PrinterName = PrintDialog1.PrinterSettings.PrinterName
        '    objrep.PrintToPrinter(1, False, 1, 10)
        'End If

        _prDibujarDataSourceImagen2(_dt)

        'ahora lo mando al visualizador
        P_Global.Visualizador = New Visualizador
        objrep.SetDataSource(_dt)
        objrep.SetParameterValue("nombres", tbNombre.Text + " " + tbApellidoP.Text + " " + tbApellidoM.Text)
        objrep.SetParameterValue("FechaTeo1", fechaTeo1)
        objrep.SetParameterValue("FechaTeo2", fechaTeo2)
        objrep.SetParameterValue("FechaPrac1", fechaPrac1)
        objrep.SetParameterValue("FechaPrac2", fechaPrac2)
        objrep.SetParameterValue("DiaTeo", diaExamenTeo)
        objrep.SetParameterValue("DiaPrac", diaExamenPrac)
        P_Global.Visualizador.CRV1.ReportSource = objrep 'Comentar
        P_Global.Visualizador.Show() 'Comentar
        P_Global.Visualizador.BringToFront() 'Comentar
    End Sub

    Private Sub _prDibujarDataSourceImagen(_datatable As DataTable)
        Dim length As Integer
        length = _datatable.Rows.Count

        For i As Integer = 0 To length - 1 Step 1

            Dim name As String
            name = _datatable.Rows(i).Item("elfot")
            'Aqui Inserto la imagen la que esta el nombre en la base de datos y la ruta predefinida
            'conforme a su carpeta correspondiente
            If (name.Equals("")) Then
                ''  _datatable.Rows(i).Item("elimg") = null
            Else
                _datatable.Rows(i).Item("elimg") = _fnBytesArchivo(RutaGlobal + name)

            End If

        Next
    End Sub
    Private Sub _prDibujarDataSourceImagen2(_datatable As DataTable)
        Dim length As Integer
        length = _datatable.Rows.Count

        For i As Integer = 0 To length - 1 Step 1

            Dim name As String
            name = _datatable.Rows(i).Item("elfot")
            'Aqui Inserto la imagen la que esta el nombre en la base de datos y la ruta predefinida
            'conforme a su carpeta correspondiente
            If name <> String.Empty Then
                If (File.Exists(RutaGlobal + name)) Then
                    Dim bitmap As Bitmap = New Bitmap(New MemoryStream(IO.File.ReadAllBytes(RutaGlobal + name)))
                    Dim img As Bitmap = New Bitmap(bitmap)
                    Dim Bin As New MemoryStream
                    img.Save(Bin, Imaging.ImageFormat.Jpeg)

                    _datatable.Rows(i).Item("elimg") = Bin.GetBuffer
                End If
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

    Private Sub _prEliminarRegistroInscripcion()
        If btnGrabar.Enabled = False And btnGrabar.Visible = True And JGrM_Buscador.Row >= 0 Then
            'Dim nroOpcion As Integer = JGrM_Buscador.GetValue("emnopc")
            'If nroOpcion = 2 Then

            'Else
            '    ToastNotification.Show(Me, "no se puede eliminar la primera opcion de una inscripcion".ToUpper, My.Resources.WARNING, 5000, eToastGlowColor.Red, eToastPosition.TopCenter)

            'End If
            
            Dim nroOpcion As Integer = JGrM_Buscador.GetValue("emnopc")
            If nroOpcion = 1 Then
                Dim nroFact As String = JGrM_Buscador.GetValue("emznfact")
                Dim numiAlum As String = JGrM_Buscador.GetValue("elnumi")

                Dim dtRegTeo As DataTable = L_prExamenAlumnoCertiGeneralRegistrosPorNroFactura(nroFact, numiAlum, 1)
                Dim dtRegPrac As DataTable = L_prExamenAlumnoCertiGeneralRegistrosPorNroFactura(nroFact, numiAlum, 2)
                If dtRegPrac.Rows.Count >= 2 Or dtRegTeo.Rows.Count >= 2 Then
                    ToastNotification.Show(Me, "no se puede realizar la eliminacion de la primera opcion por la existencia de la segunda opcion de esta inscripción".ToUpper, My.Resources.WARNING, 8000, eToastGlowColor.Red, eToastPosition.TopCenter)
                    Exit Sub
                End If
            End If



            Dim info As New TaskDialogInfo("eliminacion".ToUpper, eTaskDialogIcon.Delete, "advertencia".ToUpper, "¿esta seguro de eliminar el registro de inscripcion?".ToUpper, eTaskDialogButton.Yes Or eTaskDialogButton.Cancel, eTaskDialogBackgroundColor.Blue)
            Dim result As eTaskDialogResult = TaskDialog.Show(info)
            If result = eTaskDialogResult.Yes Then
                Dim mensajeError As String = ""
                Dim res As Boolean = L_prExamenAlumnoCertiBorrar(JGrM_Buscador.GetValue("emnumi"), mensajeError)
                If res Then
                    ToastNotification.Show(Me, "Codigo de inscripcion: ".ToUpper + JGrM_Buscador.GetValue("emnumi").ToString + " eliminado con Exito.".ToUpper, My.Resources.GRABACION_EXITOSA, 5000, eToastGlowColor.Green, eToastPosition.TopCenter)
                    _prCargarGridSugerencia()
                    _PMFiltrar()
                    _prSetCondicionesGrilla()

                Else
                    ToastNotification.Show(Me, mensajeError, My.Resources.WARNING, 8000, eToastGlowColor.Red, eToastPosition.TopCenter)
                End If
            End If

        End If

    End Sub
#End Region

#Region "METODOS SOBRECARGADOS"
    Public Overrides Sub _PMOHabilitar()
        tbNroFact.ReadOnly = False
        tbObs.ReadOnly = False
        tbApellidoP.ReadOnly = False
        tbCi.ReadOnly = False
        tbTelf.ReadOnly = False
        tbCel.ReadOnly = False
        tbApellidoM.ReadOnly = False
        tbNombre.ReadOnly = False
        tbEstado.IsReadOnly = False
        tbFNac.Enabled = True
        tbCatLicencia.ReadOnly = False
        TbNac.ReadOnly = False
        tbEscuela.IsReadOnly = False
        PanelAgrImagen.Enabled = True

        tbFechaTeo.Enabled = True

        cbempresa.ReadOnly = False
        swtipo.IsReadOnly = False

        tbSuc.ReadOnly = False
    End Sub

    Public Overrides Sub _PMOInhabilitar()
        tbNroFact.ReadOnly = True
        tbObs.ReadOnly = True
        tbCi.ReadOnly = True
        tbTelf.ReadOnly = True
        tbCel.ReadOnly = True
        tbApellidoP.ReadOnly = True
        tbApellidoM.ReadOnly = True
        tbNombre.ReadOnly = True
        tbNumi.ReadOnly = True
        tbEstado.IsReadOnly = True
        TbNac.ReadOnly = True
        tbFNac.Enabled = False
        tbCatLicencia.ReadOnly = True
        tbEscuela.IsReadOnly = True
        gpSugerencia.Visible = False

        PanelAgrImagen.Enabled = False
        tbFechaTeo.Enabled = False
        tbNroInscr.ReadOnly = True
        tbEscNumiAlum.ReadOnly = True

        tbTipoExamen.IsReadOnly = True

        gpPerfeccionamiento.Visible = False

        cbempresa.ReadOnly = True
        swtipo.IsReadOnly = True

        tbSuc.ReadOnly = True

    End Sub

    Public Overrides Sub _PMOLimpiar()
        tbNroFact.Text = ""
        tbObs.Text = ""
        tbApellidoP.Text = ""
        tbCi.Text = ""
        tbTelf.Text = ""
        tbCel.Text = ""
        tbApellidoM.Text = ""
        tbNombre.Text = ""
        TbNac.Text = ""
        tbNumi.Text = ""
        tbEstado.Value = True
        tbFNac.Value = Now.Date
        tbCatLicencia.Text = ""
        tbEscuela.Value = False
        tbEscNumiAlum.Text = "0"
        tbPersona.SelectedIndex = -1
        tbFechaTeo.Value = Now.Date
        tbNroInscr.Text = ""

        tbSuc.Value = gi_userSuc

        _prEliminarImagen()

        swtipo.Value = True
        cbempresa.SelectedIndex = -1
    End Sub

    Public Overrides Sub _PMOLimpiarErrores()
        MEP.Clear()
        tbNroFact.BackColor = Color.White
        tbObs.BackColor = Color.White
        tbApellidoP.BackColor = Color.White
        tbCi.BackColor = Color.White
        tbTelf.BackColor = Color.White
        tbCel.BackColor = Color.White
        tbApellidoM.BackColor = Color.White
        tbNombre.BackColor = Color.White
        tbEstado.BackColor = Color.White
        tbFNac.BackColor = Color.White
        tbCatLicencia.BackColor = Color.White
        tbEscuela.BackColor = Color.White

    End Sub

    Public Overrides Function _PMOGrabarRegistro() As Boolean
        Dim nomImg As String
        If IsNothing(vlImagen) = True Then
            nomImg = ""
        Else
            nomImg = vlImagen.nombre
        End If
        Dim numiInst As String
        If tbPersona.SelectedIndex >= 0 Then
            numiInst = tbPersona.Value
        Else
            numiInst = 0
        End If

        Dim res As Boolean = L_prAlumnoCertiGrabar(tbNumi.Text, tbCi.Text, tbNombre.Text, tbApellidoP.Text, tbApellidoM.Text, tbFNac.Value.ToString("yyyy/MM/dd"), nomImg, IIf(tbEscuela.Value = True, 1, 0), IIf(tbEstado.Value = True, 1, 0), tbEscNumiAlum.Text, tbTelf.Text, tbCel.Text, numiInst, tbSuc.Value, TbNac.Value)
        If res Then
            If IsNothing(vlImagen) = False Then
                vlImagen.nombre = nomImg
                _prGuardarImagen()
            End If
            'grabar la inscripcion para el examen en la tabla TCE010
            ''L_prExamenAlumnoCertiGrabar("", tbNumi.Text, Now.Date.ToString("yyyy/MM/dd"), 0, 0, 0, 1, tbNroFact.Text, tbObs.Text, tbCatLicencia.Value)

            ToastNotification.Show(Me, "Codigo de alumno ".ToUpper + tbNumi.Text + " Grabado con Exito.".ToUpper, My.Resources.GRABACION_EXITOSA, 5000, eToastGlowColor.Green, eToastPosition.TopCenter)
            _prCargarGridSugerencia()
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
        Dim numiInst As String
        If tbPersona.SelectedIndex >= 0 Then
            numiInst = tbPersona.Value
        Else
            numiInst = 0
        End If
        Dim res As Boolean = L_prAlumnoCertiModificar(tbNumi.Text, tbCi.Text, tbNombre.Text, tbApellidoP.Text, tbApellidoM.Text, tbFNac.Value.ToString("yyyy/MM/dd"), nomImg, IIf(tbEscuela.Value = True, 1, 0), IIf(tbEstado.Value = True, 1, 0), tbEscNumiAlum.Text, tbTelf.Text, tbCel.Text, numiInst, tbSuc.Value, TbNac.Value)
        If res Then
            If IsNothing(vlImagen) = False Then
                If vlImagen.tipo = 0 Then
                    vlImagen.nombre = nomImg
                    _prGuardarImagen()
                End If
            End If
            L_prExamenAlumnoCertiModificar(tbNumiPregun.Text, tbNumi.Text, tbFechaTeo.Value.ToString("yyyy/MM/dd"), 0, 0, 0, IIf(tbTipoExamen.Value = False, 1, 2), tbNroFact.Text, tbObs.Text, tbCatLicencia.Value, tbNroOpcion.Text)

            'preguntar si es examen practico y si es final para cambiar la nota en el certificado si lo tuviera
            Dim dtCerti As DataTable = L_prCertificadosAlumnosObtenerPorNumiAlumYNroFact(tbNumi.Text, tbNroFact.Text)
            If dtCerti.Rows.Count > 0 And tbTipoExamen.Value = True Then
                Dim dtUltimoExamenPractico As DataTable = L_prCertificadosAlumnosGetUltimaClasePractica(tbNumi.Text, tbNroFact.Text)
                If dtUltimoExamenPractico.Rows.Count > 0 Then
                    Dim numiUltExamenPractico As String = dtUltimoExamenPractico.Rows(0).Item("emnumi")
                    If numiUltExamenPractico = tbNumiPregun.Text Then
                        L_prCertificadosAlumnosModificarFecha(dtCerti.Rows(0).Item("epnumi"), tbFechaTeo.Value.ToString("yyyy/MM/dd"))
                    End If
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
            Dim res As Boolean = L_prAlumnoCertiBorrar(tbNumi.Text, mensajeError)
            If res Then
                ToastNotification.Show(Me, "Codigo de alumno: ".ToUpper + tbNumi.Text + " eliminado con Exito.".ToUpper, My.Resources.GRABACION_EXITOSA, 5000, eToastGlowColor.Green, eToastPosition.TopCenter)
                _prCargarGridSugerencia()
                _PMFiltrar()
                _prSetCondicionesGrilla()

            Else
                ToastNotification.Show(Me, mensajeError, My.Resources.WARNING, 8000, eToastGlowColor.Red, eToastPosition.TopCenter)
            End If
        End If
    End Sub
    Public Overrides Function _PMOValidarCampos() As Boolean
        Dim _ok As Boolean = True
        MEP.Clear()

        If tbApellidoP.Text = String.Empty Then
            tbApellidoP.BackColor = Color.Red
            MEP.SetError(tbApellidoP, "ingrese apellido paterno del alumno!".ToUpper)
            _ok = False
        Else
            tbApellidoP.BackColor = Color.White
            MEP.SetError(tbApellidoP, "")
        End If

        If tbApellidoM.Text = String.Empty Then
            tbApellidoM.BackColor = Color.Red
            MEP.SetError(tbApellidoM, "ingrese apellido materno del alumno!".ToUpper)
            _ok = False
        Else
            tbApellidoM.BackColor = Color.White
            MEP.SetError(tbApellidoM, "")
        End If

        If tbCi.Text = String.Empty Then
            tbCi.BackColor = Color.Red
            MEP.SetError(tbCi, "ingrese ci del alumno!".ToUpper)
            _ok = False
        Else
            tbCi.BackColor = Color.White
            MEP.SetError(tbCi, "")
        End If



        If tbNombre.Text = String.Empty Then
            tbNombre.BackColor = Color.Red
            MEP.SetError(tbNombre, "ingrese nombre del alumno!".ToUpper)
            _ok = False
        Else
            tbNombre.BackColor = Color.White
            MEP.SetError(tbNombre, "")
        End If

        If tbSuc.SelectedIndex < 0 Then
            tbSuc.BackColor = Color.Red
            MEP.SetError(tbSuc, "seleccione la sucursal!".ToUpper)
            _ok = False
        Else
            tbSuc.BackColor = Color.White
            MEP.SetError(tbSuc, "")
        End If

        'If tbCatLicencia.SelectedIndex < 0 Then
        '    tbCatLicencia.BackColor = Color.Red
        '    MEP.SetError(tbCatLicencia, "seleccione la categoria de la licencia!".ToUpper)
        '    _ok = False
        'Else
        '    tbCatLicencia.BackColor = Color.White
        '    MEP.SetError(tbCatLicencia, "")
        'End If

        MHighlighterFocus.UpdateHighlights()
        Return _ok
    End Function

    Private Function _PMOValidarCamposInscripcion() As Boolean
        Dim _ok As Boolean = True
        MEP.Clear()

        If (swtipo.Value = True) Then
            If tbNroFact.Text = String.Empty Then
                tbNroFact.BackColor = Color.Red
                MEP.SetError(tbNroFact, "ingrese nro de factura!".ToUpper)
                _ok = False
            Else
                tbNroFact.BackColor = Color.White
                MEP.SetError(tbNroFact, "")
            End If
        End If
        If (swtipo.Value = False) Then
            If cbempresa.SelectedIndex < 0 Then
                cbempresa.BackColor = Color.Red
                MEP.SetError(cbempresa, "Seleccione una Empresa o Registre una con el simbolo +".ToUpper)
                _ok = False
            Else
                cbempresa.BackColor = Color.White
                MEP.SetError(cbempresa, "")
            End If
        End If

        If tbCatLicencia.SelectedIndex < 0 Then
            tbCatLicencia.BackColor = Color.Red
            MEP.SetError(tbCatLicencia, "seleccione la categoria de la licencia!".ToUpper)
            _ok = False
        Else
            tbCatLicencia.BackColor = Color.White
            MEP.SetError(tbCatLicencia, "")
        End If



        MHighlighterFocus.UpdateHighlights()
        Return _ok
    End Function

    Private Function _PMOValidarCamposInscripcionPerfeccionamiento() As Boolean
        Dim _ok As Boolean = True
        MEP.Clear()


        If tbNroFactPer.Text = String.Empty Then
            tbNroFactPer.BackColor = Color.Red
            MEP.SetError(tbNroFactPer, "ingrese nro de factura!".ToUpper)
            _ok = False
        Else
            tbNroFactPer.BackColor = Color.White
            MEP.SetError(tbNroFactPer, "")
        End If

        MHighlighterFocus.UpdateHighlights()
        Return _ok
    End Function


    Public Overrides Function _PMOGetTablaBuscador() As DataTable
        Dim dtBuscador As DataTable = L_prAlumnoCertiGeneral()
        Return dtBuscador
    End Function

    Public Overrides Function _PMOGetListEstructuraBuscador() As List(Of Modelos.Celda)
        Dim listEstCeldas As New List(Of Modelos.Celda)
        listEstCeldas.Add(New Modelos.Celda("emznfact", True, "NRO. FACT.", 100))
        listEstCeldas.Add(New Modelos.Celda("emnopc", True, "Nº OPCION", 70))
        listEstCeldas.Add(New Modelos.Celda("emcatlic", False))
        listEstCeldas.Add(New Modelos.Celda("emnumi", False))
        listEstCeldas.Add(New Modelos.Celda("cedesc1", True, "CAT. LIC", 70))
        listEstCeldas.Add(New Modelos.Celda("emobs", False))
        listEstCeldas.Add(New Modelos.Celda("emtipo", False))
        listEstCeldas.Add(New Modelos.Celda("emtipo2", True, "TIPO", 80))
        listEstCeldas.Add(New Modelos.Celda("emfecha", True, "FEC.TEO.", 80))
        listEstCeldas.Add(New Modelos.Celda("elnumi", True, "ID", 60))
        listEstCeldas.Add(New Modelos.Celda("elci", True, "CI", 70))
        listEstCeldas.Add(New Modelos.Celda("elfot", False))
        listEstCeldas.Add(New Modelos.Celda("elalumnumi", False))
        listEstCeldas.Add(New Modelos.Celda("elnom", True, "NOMBRE", 200))
        listEstCeldas.Add(New Modelos.Celda("elapep", True, "APELLIDO PATERNO", 200))
        listEstCeldas.Add(New Modelos.Celda("elapem", True, "APELLIDO MATERNO", 200))
        listEstCeldas.Add(New Modelos.Celda("elfnac", True, "FEC. NACIMIENTO", 100))
        listEstCeldas.Add(New Modelos.Celda("elesc", False))
        listEstCeldas.Add(New Modelos.Celda("elesc2", True, "ESCUELA", 80))
        listEstCeldas.Add(New Modelos.Celda("ememp", False))
        listEstCeldas.Add(New Modelos.Celda("empresa", True, "EMPRESA", 80))
        listEstCeldas.Add(New Modelos.Celda("elest", False))
        listEstCeldas.Add(New Modelos.Celda("elest2", True, "ESTADO", 120))
        listEstCeldas.Add(New Modelos.Celda("eltelf1", True, "TELEFONO", 100))
        listEstCeldas.Add(New Modelos.Celda("eltelf2", True, "CELULAR", 100))
        listEstCeldas.Add(New Modelos.Celda("elnumiInst", False))
        listEstCeldas.Add(New Modelos.Celda("elsuc", False))
        listEstCeldas.Add(New Modelos.Celda("elnac", True, "NAC", 80))
        listEstCeldas.Add(New Modelos.Celda("elfact", False))
        listEstCeldas.Add(New Modelos.Celda("elhact", False))
        listEstCeldas.Add(New Modelos.Celda("eluact", False))
        Return listEstCeldas
    End Function

    Public Overrides Sub _PMOMostrarRegistro(_N As Integer)
        JGrM_Buscador.Row = _MPos

        With JGrM_Buscador
            tbNumi.Text = .GetValue("elnumi").ToString
            tbCi.Text = .GetValue("elci").ToString
            tbNombre.Text = .GetValue("elnom").ToString
            tbApellidoP.Text = .GetValue("elapep").ToString
            tbApellidoM.Text = .GetValue("elapem").ToString


            tbEstado.Value = .GetValue("elest2")
            tbEscuela.Value = .GetValue("elesc2")
            tbFNac.Value = .GetValue("elfnac")
            tbEscNumiAlum.Text = .GetValue("elalumnumi")

            tbTelf.Text = .GetValue("eltelf1").ToString
            tbCel.Text = .GetValue("eltelf2").ToString

            tbPersona.Value = .GetValue("elnumiInst")

            tbCatLicencia.Value = .GetValue("emcatlic")
            TbNac.Value = .GetValue("elnac")
            tbObs.Text = .GetValue("emobs")
            tbNroFact.Text = .GetValue("emznfact")
            tbFechaTeo.Value = .GetValue("emfecha")
            tbNumiPregun.Text = .GetValue("emnumi")
            tbNroOpcion.Text = .GetValue("emnopc")
            tbTipoExamen.Value = IIf(.GetValue("emtipo") = 1, False, True)

            tbSuc.Value = IIf(IsDBNull(.GetValue("elsuc")) = True, -1, .GetValue("elsuc"))

            If (IsNumeric(tbNroFact.Text)) Then
                If (tbNroFact.Text > 0) Then
                    swtipo.Value = True
                    lbempresa.Visible = False
                    cbempresa.Visible = False
                    tbNroFact.Visible = True
                    lbfactura.Visible = True
                Else
                    tbNroFact.Visible = False
                    lbfactura.Visible = False

                    swtipo.Value = False
                    lbempresa.Visible = True
                    cbempresa.Visible = True
                    cbempresa.Value = .GetValue("ememp")
                End If
            Else
                swtipo.Value = True
                lbempresa.Visible = False
                cbempresa.Visible = False
                tbNroFact.Visible = True
                lbfactura.Visible = True
            End If


            Dim nomImg = .GetValue("elfot").ToString
            If nomImg = String.Empty Then
                pbImg.Image = Nothing
            Else
                Dim rutaOrigen As String = vlRutaBase + "\Imagenes\Imagenes Alumnos Certificacion\"
                vlImagen = New CImagen(nomImg, rutaOrigen + nomImg, 1)
                pbImg.SizeMode = PictureBoxSizeMode.StretchImage
                Try
                    pbImg.Load(vlImagen.getImagen())
                Catch ex As Exception
                    pbImg.Image = Nothing
                    vlImagen = Nothing
                End Try

            End If


            lbFecha.Text = CType(.GetValue("elfact"), Date).ToString("dd/MM/yyyy")
            lbHora.Text = .GetValue("elhact").ToString
            lbUsuario.Text = .GetValue("eluact").ToString

        End With

        LblPaginacion.Text = Str(_MPos + 1) + "/" + JGrM_Buscador.RowCount.ToString

    End Sub
    Public Overrides Sub _PMOHabilitarFocus()
        With MHighlighterFocus
            .SetHighlightOnFocus(tbApellidoP, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
            .SetHighlightOnFocus(tbCi, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
            .SetHighlightOnFocus(tbTelf, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
            .SetHighlightOnFocus(tbCel, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
            .SetHighlightOnFocus(tbApellidoM, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
            .SetHighlightOnFocus(tbEscuela, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
            .SetHighlightOnFocus(tbNombre, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
            .SetHighlightOnFocus(tbEstado, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
            .SetHighlightOnFocus(tbCatLicencia, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
            .SetHighlightOnFocus(tbFNac, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)

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
        gpSugerencia.Visible = True

        gpInscripcion.Visible = False

        '_prCargarGridSugerencia()
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        tbCi.Focus()

        tbCatLicencia.ReadOnly = False
        tbObs.ReadOnly = False
        tbNroFact.ReadOnly = False
        tbFechaTeo.Enabled = True


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

    Private Sub tbCi_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbCi.KeyPress
        'If (Not e.KeyChar = ChrW(Keys.Enter) And _MNuevo) Then
        '    grSugerencia.RemoveFilters()
        '    grSugerencia.RootTable.ApplyFilter(New Janus.Windows.GridEX.GridEXFilterCondition(grSugerencia.RootTable.Columns("cbci"), Janus.Windows.GridEX.ConditionOperator.Contains, tbCi.Text))
        'End If
    End Sub

    Private Sub tbCi_KeyDown(sender As Object, e As KeyEventArgs) Handles tbCi.KeyDown, tbNombre.KeyDown, tbApellidoM.KeyDown, tbApellidoP.KeyDown
        If (e.KeyData = Keys.Control + Keys.Enter And _MNuevo) Then
            If grSugerencia.RowCount > 0 Then
                grSugerencia.Row = 0
                _prCargarAlumnoSeleccionado()
            End If
        End If
    End Sub

    Private Sub tbCi_TextChanged(sender As Object, e As EventArgs) Handles tbCi.TextChanged
        If (_MNuevo) Then
            grSugerencia.RemoveFilters()
            grSugerencia.RootTable.ApplyFilter(New Janus.Windows.GridEX.GridEXFilterCondition(grSugerencia.RootTable.Columns("cbci"), Janus.Windows.GridEX.ConditionOperator.Contains, tbCi.Text))
        End If
    End Sub

    Private Sub tbNombre_TextChanged(sender As Object, e As EventArgs) Handles tbNombre.TextChanged
        If (_MNuevo) Then
            grSugerencia.RemoveFilters()
            grSugerencia.RootTable.ApplyFilter(New Janus.Windows.GridEX.GridEXFilterCondition(grSugerencia.RootTable.Columns("cbnom"), Janus.Windows.GridEX.ConditionOperator.Contains, tbNombre.Text))
        End If
    End Sub

    Private Sub tbApellidoP_TextChanged(sender As Object, e As EventArgs) Handles tbApellidoP.TextChanged
        If (_MNuevo) Then
            grSugerencia.RemoveFilters()
            grSugerencia.RootTable.ApplyFilter(New Janus.Windows.GridEX.GridEXFilterCondition(grSugerencia.RootTable.Columns("cbape"), Janus.Windows.GridEX.ConditionOperator.Contains, tbApellidoP.Text))
        End If
    End Sub

    Private Sub tbApellidoM_TextChanged(sender As Object, e As EventArgs) Handles tbApellidoM.TextChanged
        If (_MNuevo) Then
            grSugerencia.RemoveFilters()
            grSugerencia.RootTable.ApplyFilter(New Janus.Windows.GridEX.GridEXFilterCondition(grSugerencia.RootTable.Columns("cbape"), Janus.Windows.GridEX.ConditionOperator.Contains, tbApellidoM.Text))
        End If
    End Sub

    Private Sub grSugerencia_KeyDown(sender As Object, e As KeyEventArgs) Handles grSugerencia.KeyDown
        If (e.KeyData = Keys.Control + Keys.Enter And _MNuevo) Then
            If grSugerencia.Row >= 0 Then
                _prCargarAlumnoSeleccionado()
            End If
        End If
    End Sub

    Private Sub grSugerencia_EditingCell(sender As Object, e As EditingCellEventArgs) Handles grSugerencia.EditingCell
        e.Cancel = True
    End Sub

    Private Sub btnGrabar_Click(sender As Object, e As EventArgs) Handles btnGrabar.Click
        _prSetCondicionesGrilla()

    End Sub


    Private Sub btnInscribir_Click_1(sender As Object, e As EventArgs) Handles btnInscribir.Click
        _prInscribirAlumnoExistente()
    End Sub

    Private Sub tbCi_Leave(sender As Object, e As EventArgs) Handles tbCi.Leave
        If btnGrabar.Enabled = False Or _MNuevo = False Then
            Exit Sub
        End If

        Dim dtAlumnos As DataTable = L_prExamenAlumnoCertiBuscarAlumno(tbCi.Text)
        If dtAlumnos.Rows.Count > 0 Then
            Dim mensaje As String = "el 'ci' que ingreso ya esta registrado con los siguientes datos: ".ToUpper + vbCrLf + _
                                    "nombre          : ".ToUpper + dtAlumnos.Rows(0).Item("elnom").ToString + vbCrLf + _
                                    "apellido paterno: ".ToUpper + dtAlumnos.Rows(0).Item("elapep").ToString + vbCrLf + _
                                    "apellido materno: ".ToUpper + dtAlumnos.Rows(0).Item("elapem").ToString + vbCrLf + _
                                    "fecha nacimiento: ".ToUpper + CType(dtAlumnos.Rows(0).Item("elfnac"), Date).ToString("dd/MM/yyyy")

            'ToastNotification.Show(Me, mensaje.ToUpper, My.Resources.WARNING, 10000, eToastGlowColor.Red, eToastPosition.TopCenter)


            Dim info As New TaskDialogInfo("advertencia".ToUpper, eTaskDialogIcon.Delete, "¿desea continuar?".ToUpper, mensaje.ToUpper, eTaskDialogButton.Yes Or eTaskDialogButton.No, eTaskDialogBackgroundColor.Blue)
            Dim result As eTaskDialogResult = TaskDialog.Show(info)
            If result = eTaskDialogResult.Yes Then

            Else
                tbCi.Text = ""
                tbCi.Focus()
            End If
        End If


    End Sub

    Private Sub tbFechaTeo_ValueChanged(sender As Object, e As EventArgs) Handles tbFechaTeo.ValueChanged
        If btnInscribir.Tag = 1 Or btnReinscribir.Tag = 1 Then
            Dim dtInscTeo As DataTable = L_prExamenAlumnoCertiGeneralInscritos(tbFechaTeo.Value.ToString("yyyy/MM/dd"), IIf(tbTipoExamen.Value = False, 1, 2))
            tbNroInscr.Text = dtInscTeo.Rows.Count.ToString

        End If

    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        gpInscripcion.Visible = True
    End Sub

    Private Sub btnReinscribir_Click(sender As Object, e As EventArgs) Handles btnReinscribir.Click
        _prReInscribirAlumnoExistente()
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        _prImprimir()
    End Sub

    Private Sub btnInscribirPerfeccionamiento_Click(sender As Object, e As EventArgs) Handles btnInscribirPerfeccionamiento.Click
        _prInscribirAlumnoPerfeccionamiento()
    End Sub


    Private Sub btnEliminarInscripcion_Click(sender As Object, e As EventArgs) Handles btnEliminarInscripcion.Click
        _prEliminarRegistroInscripcion()
    End Sub

    Private Sub tbTipoExamen_ValueChanged(sender As Object, e As EventArgs) Handles tbTipoExamen.ValueChanged

    End Sub

    Private Sub BtnMarca_Click(sender As Object, e As EventArgs) Handles BtnEmpresa.Click
        Dim numi As String = ""

        If L_prLibreriaGrabar(numi, 21, 1, cbempresa.Text, "") Then
            _prCargarComboLibreria(cbempresa, 21, 1)
            cbempresa.SelectedIndex = CType(cbempresa.DataSource, DataTable).Rows.Count - 1
        End If
    End Sub

    Private Sub cbempresa_ValueChanged(sender As Object, e As EventArgs) Handles cbempresa.ValueChanged
        If cbempresa.SelectedIndex < 0 And cbempresa.Text <> String.Empty Then
            BtnEmpresa.Visible = True
        Else
            BtnEmpresa.Visible = False
        End If
    End Sub

    Private Sub swtipo_ValueChanged(sender As Object, e As EventArgs) Handles swtipo.ValueChanged
        If (swtipo.Value = True) Then
            lbempresa.Visible = False
            cbempresa.Visible = False
            lbfactura.Visible = True
            tbNroFact.Visible = True

        Else
            lbempresa.Visible = True
            cbempresa.Visible = True
            lbfactura.Visible = False
            tbNroFact.Visible = False
        End If
    End Sub

    Private Sub tbEscuela_ValueChanged(sender As Object, e As EventArgs) Handles tbEscuela.ValueChanged
        If tbEscuela.Value = False Then
            tbEscNumiAlum.Text = "0"
            tbPersona.SelectedIndex = -1
        End If

    End Sub

    Private Sub tbNroFact_KeyDown(sender As Object, e As KeyEventArgs) Handles tbNroFact.KeyDown
        'Dim frmAyuda As Modelos.ModeloAyuda
        'Dim dt As DataTable

        'dt = L_prClasesPracObtenerFacturasCertificacion()

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
        '    tbNroFact.Text = numero
        '    tbNroFact.Tag = numiFact
        'End If
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click

    End Sub
End Class