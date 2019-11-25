Imports Logica.AccesoLogica
Imports Janus.Windows.GridEX
Imports DevComponents.DotNetBar
Imports DevComponents.DotNetBar.SuperGrid
Imports GMap.NET
Imports GMap.NET.WindowsForms
Imports GMap.NET.WindowsForms.Markers
Imports GMap.NET.WindowsForms.ToolTips
Imports GMap.NET.MapProviders
Imports System.IO

Public Class F0_Socio

#Region "Variables Globales"

    Dim Duracion As Integer = 5 'Duracion es segundo de los mensajes tipo (Toast)
    Dim GrDatos As GridEXRow() 'Arreglo que tiene las filas actuales de la grilla de datos
    Dim DsGeneral As DataSet 'Dataset que contendra a todos los datatable
    Dim DtCabecera As DataTable 'Datatable de la cabecera
    Dim DtDetalle1 As DataTable 'Datatable del detalle de la cabecera
    Dim DtDetalle2 As DataTable 'Datatable del detalle de la cabecera
    Dim DtDetalle3 As DataTable 'Datatable del detalle de la cabecera
    Dim Nuevo As Boolean 'Variable en true cuando se presiona el boton nuevo
    Dim Modificar As Boolean 'Variable en true cuando se presiona el boton modificar
    Dim Eliminar As Boolean 'Variable en true cuando se presiona el boton eliminar
    Dim IndexReg As Integer 'Indice de navegación de registro
    Dim CantidadReg As Integer 'Cantidad de registro de la Tabla
    Dim Grabar As Byte 'Variable que ayuda a la secuencia de grabar

    Dim vlImagen As CImagen = Nothing
    Dim vlRutaBase As String = gs_CarpetaRaiz

    Public _nameButton As String

#Region "MApas"
    Dim _Punto As Integer
    Dim _ListPuntos As List(Of PointLatLng)
    Dim _Overlay As GMapOverlay
    Dim _latitud As Double = 0
    Dim _longitud As Double = 0
#End Region

#End Region

#Region "Eventos"

    Private Sub P_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        P_Inicio()
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        P_Nuevo()
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        P_Modificar()
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        P_Eliminar()
    End Sub

    Private Sub btnGrabar_Click(sender As Object, e As EventArgs) Handles btnGrabar.Click
        P_Grabar()
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        P_Cancelar()
    End Sub

    Private Sub btnPrimero_Click(sender As Object, e As EventArgs) Handles btnPrimero.Click
        IndexReg = 0
        P_LlenarDatos(IndexReg)
        P_ActualizarPaginacion(IndexReg)
    End Sub

    Private Sub btnAnterior_Click(sender As Object, e As EventArgs) Handles btnAnterior.Click
        IndexReg -= 1
        P_LlenarDatos(IndexReg)
        P_ActualizarPaginacion(IndexReg)
    End Sub

    Private Sub btnSiguiente_Click(sender As Object, e As EventArgs) Handles btnSiguiente.Click
        IndexReg += 1
        P_LlenarDatos(IndexReg)
        P_ActualizarPaginacion(IndexReg)
    End Sub

    Private Sub btnUltimo_Click(sender As Object, e As EventArgs) Handles btnUltimo.Click
        IndexReg = CantidadReg
        P_LlenarDatos(IndexReg)
        P_ActualizarPaginacion(IndexReg)
    End Sub

    Private Sub Dgj1Busqueda_EditingCell(sender As Object, e As EditingCellEventArgs) Handles Dgj1Busqueda.EditingCell
        e.Cancel = True
    End Sub

#End Region

#Region "Metodos"

    Private Sub P_Inicio()
        'Abrir la conexion de la base de datos
        'L_prAbrirConexion()

        'Poner visible=false, los componente que no se ocuparan
        btnImprimir.Visible = False
        CpExportarExcel.Visible = False

        'Poner titulo al formulario
        Me.Text = "S O C I O"

        'Poner caracteristicas del Formulario
        Me.WindowState = FormWindowState.Maximized
        SuperTabPrincipal.SelectedTabIndex = 0
        SuperTabControlSocio.SelectedTabIndex = 0

        'Inhabilitar el boton de grabar
        btnGrabar.Enabled = False
        Tb1Codigo.ReadOnly = True
        'Tb2NroSocio.ReadOnly = True
        BtAddLibTelefono.Visible = False
        BtAddLibMarca.Visible = False
        BtAddLibModelo.Visible = False

        'Poner texto de salir a boton de cancelar
        btnSalir.Tooltip = "SALIR"

        'Deshabilitar componentes
        'Campo del numi poner readonly
        P_Deshabilitar()

        'Armar combos
        P_ArmarCombos()

        'Armar grillas
        P_ArmarGrillas()

        'Iniciar mapa
        P_prInicarMapa()

        'Navegación de registro
        P_ActualizarPuterosNavegacion()
        IndexReg = 0
        P_LlenarDatos(IndexReg)

        ELIMINARNUMEROToolStripMenuItem.Visible = False
        ELIMINARHIJOToolStripMenuItem.Visible = False
        ELIMINARVEHICULOToolStripMenuItem.Visible = False

        'Nombres Usuario
        TxtNombreUsu.Text = L_Usuario
        TxtNombreUsu.ReadOnly = True

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

    Private Sub P_Nuevo()
        P_Limpiar()
        btnGrabar.Tooltip = "GRABAR NUEVO REGISTRO"
        P_Habilitar()
        Tb2NroSocio.Select()
        rlAccion.Text = "NUEVO"
        P_EstadoNueModEli(1)
    End Sub

    Private Sub P_Modificar()
        btnGrabar.Tooltip = "GRABAR MODIFICACIÓN DE REGISTRO"
        P_Habilitar()
        Cb1TipoSocio.Select()
        rlAccion.Text = "MODIFICAR"
        P_EstadoNueModEli(2)
    End Sub

    Private Sub P_Eliminar()
        Dim info As New TaskDialogInfo("¿esta seguro de eliminar el registro?".ToUpper, eTaskDialogIcon.Delete, "advertencia".ToUpper, "Esta a punto de eliminar el Socio con código -> ".ToUpper + Tb1Codigo.Text + " " + Chr(13) + "Desea continuar?".ToUpper, eTaskDialogButton.Yes Or eTaskDialogButton.Cancel, eTaskDialogBackgroundColor.Blue)
        Dim result As eTaskDialogResult = TaskDialog.Show(info)
        If result = eTaskDialogResult.Yes Then
            Dim mensajeError As String = ""
            Dim res As Boolean = L_fnSocioBorrar(Tb1Codigo.Text, mensajeError)
            If res Then
                ToastNotification.Show(Me, "Codigo de socio: ".ToUpper + Tb1Codigo.Text + " eliminado con Exito.".ToUpper, My.Resources.GRABACION_EXITOSA, 5000, eToastGlowColor.Green, eToastPosition.TopCenter)
                P_GridBusqueda()
                GrDatos = Nothing
                P_ActualizarPuterosNavegacion()
                P_LlenarDatos(IndexReg)
            Else
                ToastNotification.Show(Me, mensajeError, My.Resources.WARNING, 8000, eToastGlowColor.Red, eToastPosition.TopCenter)
            End If
        End If
    End Sub

    Private Sub P_Grabar()
        'Campo de la Tabla
        Dim numi As String
        Dim tsoc As String
        Dim nsoc As String
        Dim fing As String
        Dim fnac As String
        Dim lnac As String
        Dim nom As String
        Dim apat As String
        Dim amat As String
        Dim prof As String
        Dim dir1 As String
        Dim dir2 As String
        Dim sdir As String
        Dim cas As String
        Dim email As String
        Dim ci As String
        Dim ciemi As String
        Dim nome As String
        Dim fnace As String
        Dim lnace As String
        Dim obs As String
        Dim mor As String
        Dim tar As String
        Dim ntar As String
        Dim est As String
        Dim img As String
        Dim hmed As String
        Dim vlati As String
        Dim vlong As String

        'Detalles
        Dim Dt1 As DataTable
        Dim Dt2 As DataTable
        Dim Dt3 As DataTable

        If (Nuevo) Then
            If (P_Validar()) Then
                'Cargar campos
                numi = Tb1Codigo.Text.Trim
                tsoc = Cb1TipoSocio.Value.ToString.Trim
                nsoc = Tb2NroSocio.Text.Trim
                fing = Dt1FechaIngreso.Value.ToString("yyyy/MM/dd")
                fnac = Dt2FechaNac.Value.ToString("yyyy/MM/dd")
                lnac = Tb3LugarNac.Text.Trim
                nom = Tb4Nombre.Text.Trim
                apat = Tb5ApellidoPat.Text.Trim
                amat = Tb6ApellidoMat.Text.Trim
                prof = Tb7Profesion.Text.Trim
                dir1 = Tb8DirOficina.Text.Trim
                dir2 = Tb9DirDomicilio.Text.Trim
                sdir = IIf(Sb1DirEnvio.Value, "1", "0")
                cas = Tb10NroCasilla.Text.Trim
                email = Tb11Email.Text.Trim
                ci = Tb12Ci.Text.Trim
                ciemi = Cb2LugarEmision.Value.ToString
                nome = Tb13NombreEsposa.Text.Trim
                fnace = Dt3FechaNacEsposa.Value.ToString("yyyy/MM/dd")
                lnace = Tb14LugarNacEsposa.Text.Trim
                obs = Tb15Obs.Text.Trim
                mor = IIf(Sb2CajaMortoria.Value, "1", "0")
                tar = IIf(Sb3TarjetaDebCre.Value, "1", "0")
                ntar = Tb16NroTarjeta.Text.Trim
                est = IIf(Sb4Estado.Value, "0", "1")
                If IsNothing(vlImagen) = True Then
                    img = ""
                Else
                    img = vlImagen.nombre
                End If
                hmed = TbDatosEmergencia.Text.Trim
                vlati = _latitud
                vlong = _longitud

                'Detalles
                Dt1 = CType(Dgv1Telefonos.DataSource, DataTable).DefaultView.ToTable(True, "cgnumi", "cgttip", "cgdesc", "cglin", "estado")
                Dt2 = CType(Dgd1Hijos.PrimaryGrid.DataSource, DataTable).DefaultView.ToTable(True, "chnumi", "chdesc", "chci", "chfnac", "chimg", "chlin", "estado")
                Dt3 = CType(Dgd2Vehiculos.PrimaryGrid.DataSource, DataTable).DefaultView.ToTable(True, "cinumi", "cimar", "cimod", "ciplac", "ciros", "ciimg", "cilin", "estado")

                'Grabar
                Dim res As Boolean = L_fnSocioGrabar(numi, tsoc, nsoc, fing, fnac, lnac, nom, apat, amat, prof, dir1, dir2, sdir,
                                                     cas, email, ci, ciemi, nome, fnace, lnace, obs, mor, tar, ntar, est, img,
                                                     hmed, vlati, vlong, Dt1, Dt2, Dt3)

                If (res) Then
                    If IsNothing(vlImagen) = False Then
                        vlImagen.nombre = img
                        _prGuardarImagen()
                    End If
                    P_Limpiar()
                    P_GridBusqueda()
                    btnSalir.PerformClick()
                    ToastNotification.Show(Me, "Codigo de socio ".ToUpper + Tb1Codigo.Text + " Grabado con Exito.".ToUpper,
                                       My.Resources.GRABACION_EXITOSA,
                                       Duracion * 1000,
                                       eToastGlowColor.Green,
                                       eToastPosition.TopCenter)
                Else
                    ToastNotification.Show(Me, "No se pudo grabar el codigo de socio ".ToUpper + Tb1Codigo.Text + ", intente nuevamente.".ToUpper,
                                       My.Resources.WARNING,
                                       Duracion * 1000,
                                       eToastGlowColor.Red,
                                       eToastPosition.TopCenter)
                End If
            End If
        ElseIf (Modificar) Then
            If (P_Validar()) Then
                'Cargar campos
                numi = Tb1Codigo.Text.Trim
                tsoc = Cb1TipoSocio.Value.ToString.Trim
                nsoc = Tb2NroSocio.Text.Trim
                fing = Dt1FechaIngreso.Value.ToString("yyyy/MM/dd")
                fnac = Dt2FechaNac.Value.ToString("yyyy/MM/dd")
                lnac = Tb3LugarNac.Text.Trim
                nom = Tb4Nombre.Text.Trim
                apat = Tb5ApellidoPat.Text.Trim
                amat = Tb6ApellidoMat.Text.Trim
                prof = Tb7Profesion.Text.Trim
                dir1 = Tb8DirOficina.Text.Trim
                dir2 = Tb9DirDomicilio.Text.Trim
                sdir = IIf(Sb1DirEnvio.Value, "1", "0")
                cas = Tb10NroCasilla.Text.Trim
                email = Tb11Email.Text.Trim
                ci = Tb12Ci.Text.Trim
                ciemi = Cb2LugarEmision.Value.ToString
                nome = Tb13NombreEsposa.Text.Trim
                fnace = Dt3FechaNacEsposa.Value.ToString("yyyy/MM/dd")
                lnace = Tb14LugarNacEsposa.Text.Trim
                obs = Tb15Obs.Text.Trim
                mor = IIf(Sb2CajaMortoria.Value, "1", "0")
                tar = IIf(Sb3TarjetaDebCre.Value, "1", "0")
                ntar = Tb16NroTarjeta.Text.Trim
                est = IIf(Sb4Estado.Value, "0", "1")
                If IsNothing(vlImagen) = True Then
                    If (LbImagen.Text = String.Empty) Then
                        img = ""
                    Else
                        img = LbImagen.Text
                    End If
                Else
                    img = vlImagen.nombre
                End If
                hmed = TbDatosEmergencia.Text.Trim
                vlati = _latitud
                vlong = _longitud

                'Detalles
                Dt1 = CType(Dgv1Telefonos.DataSource, DataTable).DefaultView.ToTable(True, "cgnumi", "cgttip", "cgdesc", "cglin", "estado")
                Dt2 = CType(Dgd1Hijos.PrimaryGrid.DataSource, DataTable).DefaultView.ToTable(True, "chnumi", "chdesc", "chci", "chfnac", "chimg", "chlin", "estado")
                Dt3 = CType(Dgd2Vehiculos.PrimaryGrid.DataSource, DataTable).DefaultView.ToTable(True, "cinumi", "cimar", "cimod", "ciplac", "ciros", "ciimg", "cilin", "estado")

                'Modificar
                Dim res As Boolean = L_fnSocioModificar(numi, tsoc, nsoc, fing, fnac, lnac, nom, apat, amat, prof, dir1, dir2, sdir,
                                                        cas, email, ci, ciemi, nome, fnace, lnace, obs, mor, tar, ntar, est, img,
                                                        hmed, vlati, vlong, Dt1, Dt2, Dt3)

                If (res) Then
                    If IsNothing(vlImagen) = False Then
                        vlImagen.nombre = img
                        _prGuardarImagen()
                    End If
                    P_GridBusqueda()
                    btnSalir.PerformClick()
                    ToastNotification.Show(Me, "Codigo de socio ".ToUpper + Tb1Codigo.Text + " Modificado con Exito.".ToUpper,
                                       My.Resources.GRABACION_EXITOSA,
                                       Duracion * 1000,
                                       eToastGlowColor.Green,
                                       eToastPosition.TopCenter)
                Else
                    ToastNotification.Show(Me, "No se pudo modificar el codigo de socio ".ToUpper + Tb1Codigo.Text + ", intente nuevamente.".ToUpper,
                                       My.Resources.WARNING,
                                       Duracion * 1000,
                                       eToastGlowColor.Red,
                                       eToastPosition.TopCenter)
                End If
            End If
        End If
        P_ActualizarPuterosNavegacion()
    End Sub

    Private Sub P_Cancelar()
        If (Not btnGrabar.Enabled) Then
            Me.Close()
        Else
            P_Limpiar()
            P_LimpiarErrores()
            P_Deshabilitar()
            GrDatos = Dgj1Busqueda.GetRows
            P_LlenarDatos(IndexReg)
            Grabar = 0
            rlAccion.Text = ""
            btnGrabar.Tooltip = "GRABAR"
        End If
        P_EstadoNueModEli(4)
    End Sub

    Private Sub P_EstadoNueModEli(val As Integer)
        Nuevo = (val = 1)
        Modificar = (val = 2)
        Eliminar = (val = 3)

        btnNuevo.Enabled = (val = 4)
        btnModificar.Enabled = (val = 4)
        btnEliminar.Enabled = (val = 4)
        btnGrabar.Enabled = Not (val = 4)

        If (val = 4) Then
            btnSalir.Tooltip = "SALIR"
            btnSalir.Text = "SALIR"
        Else
            btnSalir.Tooltip = "CANCELAR"
            btnSalir.Text = "CANCELAR"
        End If
        btnPrimero.Enabled = (val = 4)
        btnAnterior.Enabled = (val = 4)
        btnSiguiente.Enabled = (val = 4)
        btnUltimo.Enabled = (val = 4)
        SupTabItemBusqueda.Visible = (val = 4)

        If (val < 4) Then
            SuperTabControlSocio.SelectedTabIndex = 0
        End If

        ELIMINARNUMEROToolStripMenuItem.Visible = Not (val = 4)
        ELIMINARHIJOToolStripMenuItem.Visible = Not (val = 4)
        ELIMINARVEHICULOToolStripMenuItem.Visible = Not (val = 4)
    End Sub

    Private Sub P_Habilitar()
        'Componentes a habilitar
        'TextBox
        Tb2NroSocio.ReadOnly = False
        Tb3LugarNac.ReadOnly = False
        Tb4Nombre.ReadOnly = False
        Tb5ApellidoPat.ReadOnly = False
        Tb6ApellidoMat.ReadOnly = False
        Tb7Profesion.ReadOnly = False
        Tb8DirOficina.ReadOnly = False
        Tb9DirDomicilio.ReadOnly = False
        Tb10NroCasilla.ReadOnly = False
        Tb11Email.ReadOnly = False
        Tb12Ci.ReadOnly = False
        Tb13NombreEsposa.ReadOnly = False
        Tb14LugarNacEsposa.ReadOnly = False
        Tb15Obs.ReadOnly = False
        Tb16NroTarjeta.ReadOnly = False
        Tb17Numero.ReadOnly = False
        Tb18NombreHijo.ReadOnly = False
        Tb19CiHijo.ReadOnly = False
        Tb21Placa.ReadOnly = False
        Tb22NroRoseta.ReadOnly = False
        TbDatosEmergencia.ReadOnly = False
        'ComboBox
        Cb1TipoSocio.ReadOnly = False
        Cb2LugarEmision.ReadOnly = False
        Cb3TipoTelefono.ReadOnly = False
        Cb4MarcaVehiculo.ReadOnly = False
        Cb5ModeloVehiculo.ReadOnly = False
        'DateTimePicker
        Dt1FechaIngreso.IsInputReadOnly = False
        Dt1FechaIngreso.ButtonDropDown.Enabled = True
        Dt2FechaNac.IsInputReadOnly = False
        Dt2FechaNac.ButtonDropDown.Enabled = True
        Dt3FechaNacEsposa.IsInputReadOnly = False
        Dt3FechaNacEsposa.ButtonDropDown.Enabled = True
        Dt4FechaNacHijo.IsInputReadOnly = False
        Dt4FechaNacHijo.ButtonDropDown.Enabled = True
        'SwitchButton
        Sb1DirEnvio.Enabled = True
        Sb2CajaMortoria.Enabled = True
        Sb3TarjetaDebCre.Enabled = True
        Sb4Estado.Enabled = True
        'Button
        Bt2AddTelefono.Enabled = True
        Bt4AddHijo.Enabled = True
        Bt6AddVehiculo.Enabled = True
        btAddImgVehiculo.Enabled = True
        'Grid
        Dgv1Telefonos.ReadOnly = False
        Dgd1Hijos.PrimaryGrid.ReadOnly = False
        Dgd2Vehiculos.PrimaryGrid.ReadOnly = False
        'Panel
        Pn1AddFotoSocio.Enabled = True
        Pn2AddFotoHijo.Enabled = True
    End Sub

    Private Sub P_Deshabilitar()
        'Componentes a deshabilitar
        Tb2NroSocio.ReadOnly = True
        Tb3LugarNac.ReadOnly = True
        Tb4Nombre.ReadOnly = True
        Tb5ApellidoPat.ReadOnly = True
        Tb6ApellidoMat.ReadOnly = True
        Tb7Profesion.ReadOnly = True
        Tb8DirOficina.ReadOnly = True
        Tb9DirDomicilio.ReadOnly = True
        Tb10NroCasilla.ReadOnly = True
        Tb11Email.ReadOnly = True
        Tb12Ci.ReadOnly = True
        Tb13NombreEsposa.ReadOnly = True
        Tb14LugarNacEsposa.ReadOnly = True
        Tb15Obs.ReadOnly = True
        Tb16NroTarjeta.ReadOnly = True
        Tb17Numero.ReadOnly = True
        Tb18NombreHijo.ReadOnly = True
        Tb19CiHijo.ReadOnly = True
        Tb21Placa.ReadOnly = True
        Tb22NroRoseta.ReadOnly = True
        TbDatosEmergencia.ReadOnly = True
        'ComboBox
        Cb1TipoSocio.ReadOnly = True
        Cb2LugarEmision.ReadOnly = True
        Cb3TipoTelefono.ReadOnly = True
        Cb4MarcaVehiculo.ReadOnly = True
        Cb5ModeloVehiculo.ReadOnly = True
        'DateTimePicker
        Dt1FechaIngreso.IsInputReadOnly = True
        Dt1FechaIngreso.ButtonDropDown.Enabled = False
        Dt2FechaNac.IsInputReadOnly = True
        Dt2FechaNac.ButtonDropDown.Enabled = False
        Dt3FechaNacEsposa.IsInputReadOnly = True
        Dt3FechaNacEsposa.ButtonDropDown.Enabled = False
        Dt4FechaNacHijo.IsInputReadOnly = True
        Dt4FechaNacHijo.ButtonDropDown.Enabled = False
        'SwitchButton
        Sb1DirEnvio.Enabled = False
        Sb2CajaMortoria.Enabled = False
        Sb3TarjetaDebCre.Enabled = False
        Sb4Estado.Enabled = False
        'Button
        Bt2AddTelefono.Enabled = False
        Bt4AddHijo.Enabled = False
        Bt6AddVehiculo.Enabled = False
        btAddImgVehiculo.Enabled = False
        'Grid
        Dgv1Telefonos.ReadOnly = True
        Dgd1Hijos.PrimaryGrid.ReadOnly = True
        Dgd2Vehiculos.PrimaryGrid.ReadOnly = True
        'Panel
        Pn1AddFotoSocio.Enabled = False
        Pn2AddFotoHijo.Enabled = False
    End Sub

    Private Sub P_Limpiar()
        'Componentes a limpiar
        'TextBox
        Tb1Codigo.Clear()
        Tb2NroSocio.Clear()
        Tb3LugarNac.Clear()
        Tb4Nombre.Clear()
        Tb5ApellidoPat.Clear()
        Tb6ApellidoMat.Clear()
        Tb7Profesion.Clear()
        Tb8DirOficina.Clear()
        Tb9DirDomicilio.Clear()
        Tb10NroCasilla.Clear()
        Tb11Email.Clear()
        Tb12Ci.Clear()
        Tb13NombreEsposa.Clear()
        Tb14LugarNacEsposa.Clear()
        Tb15Obs.Clear()
        Tb16NroTarjeta.Clear()
        Tb17Numero.Clear()
        Tb18NombreHijo.Clear()
        Tb19CiHijo.Clear()
        Tb21Placa.Clear()
        Tb22NroRoseta.Clear()
        TbDatosEmergencia.Clear()
        'ComboBox
        Cb1TipoSocio.SelectedIndex = 0
        Cb2LugarEmision.SelectedIndex = 0
        Cb3TipoTelefono.SelectedIndex = 0
        Cb4MarcaVehiculo.SelectedIndex = 0
        Cb5ModeloVehiculo.SelectedIndex = 0
        'DateTimePicker
        Dt1FechaIngreso.Value = Now.Date
        Dt2FechaNac.Value = Now.Date.AddYears(-18)
        Dt3FechaNacEsposa.Value = Now.Date.AddYears(-18)
        Dt4FechaNacHijo.Value = Now.Date
        'SwitchButton
        Sb1DirEnvio.Value = False
        Sb2CajaMortoria.Value = False
        Sb3TarjetaDebCre.Value = False
        Sb4Estado.Value = False
        'Grid
        'Llamar a los metodos iniciales
        P_GridTelefonos("-1")
        P_GridHijos("-1")
        P_GridVehiculos("-1")

        'PictureBox
        _prEliminarImagen(Pb1FotoSocio)
        _prEliminarImagen(Pb2FotoHijo)

        'Componente Label
        LbImagen.Text = ""

        'Mapa
        _Overlay.Markers.Clear()
        _latitud = 0
        _longitud = 0
    End Sub

    Private Sub P_LimpiarErrores()
        MEP.Clear()
        'Componentes a limpiar errores
        'TextBox
        Tb1Codigo.BackColor = Color.White
        Tb2NroSocio.BackColor = Color.White
        Tb3LugarNac.BackColor = Color.White
        Tb4Nombre.BackColor = Color.White
        Tb5ApellidoPat.BackColor = Color.White
        Tb6ApellidoMat.BackColor = Color.White
        Tb7Profesion.BackColor = Color.White
        Tb8DirOficina.BackColor = Color.White
        Tb9DirDomicilio.BackColor = Color.White
        Tb10NroCasilla.BackColor = Color.White
        Tb11Email.BackColor = Color.White
        Tb12Ci.BackColor = Color.White
        Tb13NombreEsposa.BackColor = Color.White
        Tb14LugarNacEsposa.BackColor = Color.White
        Tb15Obs.BackColor = Color.White
        Tb16NroTarjeta.BackColor = Color.White
        Tb17Numero.BackColor = Color.White
        Tb18NombreHijo.BackColor = Color.White
        Tb19CiHijo.BackColor = Color.White
        Tb21Placa.BackColor = Color.White
        Tb22NroRoseta.BackColor = Color.White
        TbDatosEmergencia.BackColor = Color.White
        'ComboBox
        Cb1TipoSocio.BackColor = Color.White
        Cb2LugarEmision.BackColor = Color.White
        Cb3TipoTelefono.BackColor = Color.White
        Cb4MarcaVehiculo.BackColor = Color.White
        Cb5ModeloVehiculo.BackColor = Color.White
        'DateTimePicker
        Dt1FechaIngreso.BackColor = Color.White
        Dt2FechaNac.BackColor = Color.White
        Dt3FechaNacEsposa.BackColor = Color.White
        Dt4FechaNacHijo.BackColor = Color.White

    End Sub

    Private Sub P_ActualizarPuterosNavegacion()
        If (GrDatos Is Nothing) Then
            GrDatos = Dgj1Busqueda.GetRows
        End If
        CantidadReg = Dgj1Busqueda.GetRows.Count - 1
        If (IndexReg > CantidadReg) Then
            IndexReg = CantidadReg
        End If
        P_ActualizarPaginacion(IndexReg)
    End Sub

    Private Sub P_LlenarDatos(index As Integer)
        If (index <= CantidadReg And index >= 0 And GrDatos.Count > 0) Then
            'Llenar los datos a los componentes
            With GrDatos(index)
                'Campos
                Tb1Codigo.Text = .Cells("cfnumi").Value.ToString
                Cb1TipoSocio.SelectedIndex = CInt(.Cells("cftsoc").Value) - 1
                Tb2NroSocio.Text = .Cells("cfnsoc").Value.ToString
                Dt1FechaIngreso.Value = .Cells("cffing").Value.ToString
                Dt2FechaNac.Value = .Cells("cffnac").Value.ToString
                Tb3LugarNac.Text = .Cells("cflnac").Value.ToString
                Tb4Nombre.Text = .Cells("cfnom").Value.ToString
                Tb5ApellidoPat.Text = .Cells("cfapat").Value.ToString
                Tb6ApellidoMat.Text = .Cells("cfamat").Value.ToString
                Tb7Profesion.Text = .Cells("cfprof").Value.ToString
                Tb8DirOficina.Text = .Cells("cfdir1").Value.ToString
                Tb9DirDomicilio.Text = .Cells("cfdir2").Value.ToString
                If (.Cells("cfsdir").Value.ToString.Equals("0")) Then
                    Sb1DirEnvio.Value = False
                Else
                    Sb1DirEnvio.Value = True
                End If
                Tb10NroCasilla.Text = .Cells("cfcas").Value.ToString
                Tb11Email.Text = .Cells("cfemail").Value.ToString
                Tb12Ci.Text = .Cells("cfci").Value.ToString
                Cb2LugarEmision.SelectedIndex = CInt(.Cells("cfciemi").Value) - 1
                Tb13NombreEsposa.Text = .Cells("cfnome").Value.ToString
                Dt3FechaNacEsposa.Value = .Cells("cffnace").Value.ToString
                Tb14LugarNacEsposa.Text = .Cells("cflnace").Value.ToString
                Tb15Obs.Text = .Cells("cfobs").Value.ToString
                If (.Cells("cfmor").Value.ToString.Equals("0")) Then
                    Sb2CajaMortoria.Value = False
                Else
                    Sb2CajaMortoria.Value = True
                End If
                If (.Cells("cftar").Value.ToString.Equals("0")) Then
                    Sb3TarjetaDebCre.Value = False
                Else
                    Sb3TarjetaDebCre.Value = True
                End If
                Tb16NroTarjeta.Text = .Cells("cfntar").Value.ToString
                If (.Cells("cfest").Value.ToString.Equals("0")) Then
                    Sb4Estado.Value = True
                Else
                    Sb4Estado.Value = False
                End If

                Dim Img = .Cells("cfimg").Value.ToString
                If Img = String.Empty Then
                    Pb1FotoSocio.Image = Nothing
                    LbImagen.Text = ""
                Else
                    Dim rutaOrigen As String = vlRutaBase + "\Imagenes\Imagenes Socios\"
                    Pb1FotoSocio.SizeMode = PictureBoxSizeMode.StretchImage
                    Try
                        Pb1FotoSocio.Load(rutaOrigen + Img)
                        LbImagen.Text = Img
                    Catch ex As Exception
                        Pb1FotoSocio.Image = Nothing
                    End Try
                End If
                TbDatosEmergencia.Text = .Cells("cfhmed").Value.ToString
                _latitud = IIf(IsDBNull(.Cells("cflati").Value), 0, .Cells("cflati").Value)
                _longitud = IIf(IsDBNull(.Cells("cflong").Value), 0, .Cells("cflong").Value)

                Dim s As String = CType(.Cells("cffact").Value.ToString, Date).ToString("dd/MM/yyyy")
                s = .Cells("cfhact").Value.ToString
                s = .Cells("cfuact").Value.ToString
                lbFecha.Text = CType(.Cells("cffact").Value.ToString, Date).ToString("dd/MM/yyyy")
                lbHora.Text = .Cells("cfhact").Value.ToString
                lbUsuario.Text = .Cells("cfuact").Value.ToString
            End With
            'Cargar Detalle 1
            P_GridHijos(Tb1Codigo.Text)

            'Cargar Detalle 2
            P_GridTelefonos(Tb1Codigo.Text)

            'Cargar Detalle 3
            P_GridVehiculos(Tb1Codigo.Text)

            'Poner Ubicación
            P_prPonerUbicacion()
        Else
            If (IndexReg < 0) Then
                IndexReg = 0
            Else
                IndexReg = CantidadReg
            End If
        End If
    End Sub

    Private Sub P_ActualizarPaginacion(index As Integer)
        LblPaginacion.Text = "Reg. " & index + 1 & " de " & CantidadReg + 1
    End Sub

#End Region

    Private Function P_Validar() As Boolean
        Dim res As Boolean = True
        MEP.Clear()

        If (Not IsNumeric(Cb1TipoSocio.Value)) Then
            Cb1TipoSocio.BackColor = Color.Red
            MEP.SetError(Cb1TipoSocio, "Seleccione un tipo de socio!".ToUpper)
            res = False
        Else
            Cb1TipoSocio.BackColor = Color.White
            MEP.SetError(Cb1TipoSocio, "")
        End If

        If (Tb2NroSocio.Text = String.Empty Or Tb2NroSocio.Text.Trim.Equals("0")) Then
            Tb2NroSocio.BackColor = Color.Red
            MEP.SetError(Tb2NroSocio, "ingrese el nro del socio!".ToUpper)
            res = False
        Else
            Tb2NroSocio.BackColor = Color.White
            MEP.SetError(Tb2NroSocio, "")
        End If

        If (Tb3LugarNac.Text = String.Empty) Then
            Tb3LugarNac.BackColor = Color.Red
            MEP.SetError(Tb3LugarNac, "ingrese lugar de nacimiento del socio!".ToUpper)
            res = False
        Else
            Tb3LugarNac.BackColor = Color.White
            MEP.SetError(Tb3LugarNac, "")
        End If

        If (Tb4Nombre.Text = String.Empty) Then
            Tb4Nombre.BackColor = Color.Red
            MEP.SetError(Tb4Nombre, "ingrese nombre del socio!".ToUpper)
            res = False
        Else
            Tb4Nombre.BackColor = Color.White
            MEP.SetError(Tb4Nombre, "")
        End If

        If (Tb5ApellidoPat.Text = String.Empty) Then
            Tb5ApellidoPat.BackColor = Color.Red
            MEP.SetError(Tb5ApellidoPat, "ingrese apellido paterno del socio!".ToUpper)
            res = False
        Else
            Tb5ApellidoPat.BackColor = Color.White
            MEP.SetError(Tb5ApellidoPat, "")
        End If

        If (Tb7Profesion.Text = String.Empty) Then
            Tb7Profesion.BackColor = Color.Red
            MEP.SetError(Tb7Profesion, "ingrese profesion del socio!".ToUpper)
            res = False
        Else
            Tb7Profesion.BackColor = Color.White
            MEP.SetError(Tb7Profesion, "")
        End If

        'If (Tb8DirOficina.Text = String.Empty) Then
        '    Tb8DirOficina.BackColor = Color.Red
        '    MEP.SetError(Tb8DirOficina, "ingrese direccion de oficina del socio!".ToUpper)
        '    res = False
        'Else
        '    Tb8DirOficina.BackColor = Color.White
        '    MEP.SetError(Tb8DirOficina, "")
        'End If

        'If (Tb9DirDomicilio.Text = String.Empty) Then
        '    Tb9DirDomicilio.BackColor = Color.Red
        '    MEP.SetError(Tb9DirDomicilio, "ingrese direccion de domicilio del socio!".ToUpper)
        '    res = False
        'Else
        '    Tb9DirDomicilio.BackColor = Color.White
        '    MEP.SetError(Tb9DirDomicilio, "")
        'End If

        'If (Tb11Email.Text = String.Empty) Then
        '    Tb11Email.BackColor = Color.Red
        '    MEP.SetError(Tb11Email, "ingrese e-mail del socio!".ToUpper)
        '    res = False
        'Else
        '    Tb11Email.BackColor = Color.White
        '    MEP.SetError(Tb11Email, "")
        'End If

        'If (Tb12Ci.Text = String.Empty) Then
        '    Tb12Ci.BackColor = Color.Red
        '    MEP.SetError(Tb12Ci, "ingrese carnet de identidad del socio!".ToUpper)
        '    res = False
        'Else
        '    Tb12Ci.BackColor = Color.White
        '    MEP.SetError(Tb12Ci, "")
        'End If

        If (Not IsNumeric(Cb2LugarEmision.Value)) Then
            Cb2LugarEmision.BackColor = Color.Red
            MEP.SetError(Cb2LugarEmision, "Seleccione lugar de emision del ci!".ToUpper)
            res = False
        Else
            Cb2LugarEmision.BackColor = Color.White
            MEP.SetError(Cb2LugarEmision, "")
        End If

        MHighlighterFocus.UpdateHighlights()
        Return res
    End Function

    Private Sub P_ArmarCombos()
        P_ComboTipoSocio()
        P_ComboTipoTelefono()
        P_ComboLugarEmision()
        P_ComboMarcaVehiculo()
        P_ComboModeloVehiculo()
    End Sub

    Private Sub P_ArmarGrillas()
        P_GridBusqueda()
        P_GridTelefonos("-1")
        P_GridHijos("-1")
        P_GridVehiculos("-1")
    End Sub

    Private Sub P_ComboTipoSocio()
        _prCargarComboLibreria(Cb1TipoSocio, gi_LibSOCIO, gi_LibSOCTipo)
    End Sub

    Private Sub P_ComboTipoTelefono()
        _prCargarComboLibreria(Cb3TipoTelefono, gi_LibTELEFONO, gi_LibTELTipo)
    End Sub

    Private Sub P_ComboLugarEmision()
        _prCargarComboLibreria(Cb2LugarEmision, gi_LibDEPARTAMENTO, gi_LibDEPCuidad)
    End Sub

    Private Sub P_ComboMarcaVehiculo()
        _prCargarComboLibreria(Cb4MarcaVehiculo, gi_LibVEHICULO, gi_LibVEHIMarca)
    End Sub

    Private Sub P_ComboModeloVehiculo()
        _prCargarComboLibreria(Cb5ModeloVehiculo, gi_LibVEHICULO, gi_LibVEHIModelo)
    End Sub

    Private Sub P_GridBusqueda()
        DtCabecera = New DataTable
        DtCabecera = L_fnSocioGeneral()

        Dgj1Busqueda.BoundMode = Janus.Data.BoundMode.Bound
        Dgj1Busqueda.DataSource = DtCabecera
        Dgj1Busqueda.RetrieveStructure()

        'a.cfnumi, a.cftsoc, b.cedesc1 as tsocio, a.cffing, a.cffnac, a.cflnac, a.cfnom, a.cfapat, a.cfamat, a.cfprof, a.cfdir1,
        'a.cfdir2, a.cfsdir, a.cfcas, a.cfemail, cfci, a.cfciemi, c.cedesc1 as lemision, a.cfnome, a.cffnace, a.cflnace, a.cfobs, a.cfmor,
        'a.cftar, a.cfntar, a.cfest, a.cfimg, a.cffact, a.cfhact, a.cfuact

        'dar formato a las columnas
        With Dgj1Busqueda.RootTable.Columns(0)
            .Caption = "Código"
            .Key = "cfnumi"
            .Width = 60
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = 8
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = True
        End With
        With Dgj1Busqueda.RootTable.Columns(1)
            .Caption = ""
            .Key = "cftsoc"
            .Width = 0
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = 8
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = False
        End With
        With Dgj1Busqueda.RootTable.Columns(2)
            .Caption = "Tipo Socio"
            .Key = "tsocio"
            .Width = 100
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = 8
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = True
        End With
        With Dgj1Busqueda.RootTable.Columns(3)
            .Caption = "Nro Socio"
            .Key = "cfnsoc"
            .Width = 100
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = 8
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = True
        End With
        With Dgj1Busqueda.RootTable.Columns(4)
            .Caption = "Fecha Ingreso"
            .Key = "cffing"
            .Width = 100
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = 8
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = True
        End With
        With Dgj1Busqueda.RootTable.Columns(5)
            .Caption = "Fecha Nacimiento"
            .Key = "cffnac"
            .Width = 100
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = 8
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = True
        End With
        With Dgj1Busqueda.RootTable.Columns(6)
            .Caption = "Lugar Nacimiento"
            .Key = "cflnac"
            .Width = 150
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = 8
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = True
        End With
        With Dgj1Busqueda.RootTable.Columns(7)
            .Caption = "Nombre"
            .Key = "cfnom"
            .Width = 150
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = 8
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = True
        End With
        With Dgj1Busqueda.RootTable.Columns(8)
            .Caption = "Apellido Paterno"
            .Key = "cfapat"
            .Width = 120
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = 8
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = True
        End With
        With Dgj1Busqueda.RootTable.Columns(9)
            .Caption = "Apellido Materno"
            .Key = "cfamat"
            .Width = 120
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = 8
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = True
        End With
        With Dgj1Busqueda.RootTable.Columns(10)
            .Caption = "Profesión"
            .Key = "cfprof"
            .Width = 120
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = 8
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = True
        End With
        With Dgj1Busqueda.RootTable.Columns(11)
            .Caption = "Dir Oficina"
            .Key = "cfdir1"
            .Width = 150
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = 8
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = True
        End With
        With Dgj1Busqueda.RootTable.Columns(12)
            .Caption = "Dir Domicilio"
            .Key = "cfdir2"
            .Width = 150
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = 8
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = True
        End With
        With Dgj1Busqueda.RootTable.Columns(13)
            .Caption = "Dir Envio"
            .Key = "cfsdir"
            .Width = 80
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = 8
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .Visible = True
        End With
        With Dgj1Busqueda.RootTable.Columns(14)
            .Caption = "Nro Casilla"
            .Key = "cfcas"
            .Width = 120
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = 8
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = True
        End With
        With Dgj1Busqueda.RootTable.Columns(15)
            .Caption = "E-Mail"
            .Key = "cfemail"
            .Width = 120
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = 8
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = True
        End With
        With Dgj1Busqueda.RootTable.Columns(16)
            .Caption = "Carnet de Identidad"
            .Key = "cfci"
            .Width = 120
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = 8
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = True
        End With
        With Dgj1Busqueda.RootTable.Columns(17)
            .Caption = ""
            .Key = "cfciemi"
            .Width = 0
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = 8
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = False
        End With
        With Dgj1Busqueda.RootTable.Columns(18)
            .Caption = "Lugar Emisión"
            .Key = "lemision"
            .Width = 150
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = 8
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = True
        End With
        With Dgj1Busqueda.RootTable.Columns(19)
            .Caption = "Nombre Esposa"
            .Key = "cfnome"
            .Width = 200
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = 8
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = True
        End With
        With Dgj1Busqueda.RootTable.Columns(20)
            .Caption = "Fecha Nac Esposa"
            .Key = "cffnace"
            .Width = 100
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = 8
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = True
        End With
        With Dgj1Busqueda.RootTable.Columns(21)
            .Caption = "Lugar Nac Esposa"
            .Key = "cflnace"
            .Width = 150
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = 8
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = True
        End With
        With Dgj1Busqueda.RootTable.Columns(22)
            .Caption = "Observaciones"
            .Key = "cfobs"
            .Width = 200
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = 8
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = True
        End With
        With Dgj1Busqueda.RootTable.Columns(23)
            .Caption = "Caja Mortoria"
            .Key = "cfmor"
            .Width = 80
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = 8
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .Visible = True
        End With
        With Dgj1Busqueda.RootTable.Columns(24)
            .Caption = "Tarjeta Deb/Cre"
            .Key = "cftar"
            .Width = 80
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = 8
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .Visible = True
        End With
        With Dgj1Busqueda.RootTable.Columns(25)
            .Caption = "Nro Tarjeta"
            .Key = "cfntar"
            .Width = 100
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = 8
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = True
        End With
        With Dgj1Busqueda.RootTable.Columns(26)
            .Caption = "Estado"
            .Key = "cfest"
            .Width = 80
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = 8
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .Visible = True
        End With
        With Dgj1Busqueda.RootTable.Columns(27)
            .Caption = "Foto"
            .Key = "cfimg"
            .Width = 150
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = 8
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = True
        End With
        With Dgj1Busqueda.RootTable.Columns(28)
            .Caption = "Historial médico"
            .Key = "cfhmed"
            .Width = 200
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = 8
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = True
        End With
        With Dgj1Busqueda.RootTable.Columns(29)
            .Caption = "Latitud"
            .Key = "cflati"
            .Width = 100
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = 8
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = False
        End With
        With Dgj1Busqueda.RootTable.Columns(30)
            .Caption = "Longitud"
            .Key = "cflong"
            .Width = 100
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = 8
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = False
        End With
        With Dgj1Busqueda.RootTable.Columns(31)
            .Caption = ""
            .Key = "cffact"
            .Width = 0
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = 8
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = False
        End With
        With Dgj1Busqueda.RootTable.Columns(32)
            .Caption = ""
            .Key = "cfhact"
            .Width = 0
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = 8
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = False
        End With
        With Dgj1Busqueda.RootTable.Columns(33)
            .Caption = ""
            .Key = "cfuact"
            .Width = 0
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = 8
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = False
        End With

        'Habilitar Filtradores
        With Dgj1Busqueda
            .GroupByBoxVisible = False
            '.FilterRowFormatStyle.BackColor = Color.Blue
            .DefaultFilterRowComparison = FilterConditionOperator.Contains
            .FilterMode = FilterMode.Automatic
            .FilterRowUpdateMode = FilterRowUpdateMode.WhenValueChanges
            'Diseño de la tabla
            .VisualStyle = VisualStyle.Office2007
            .SelectionMode = SelectionMode.SingleSelection
            .AlternatingColors = True
            .RecordNavigator = True
        End With

    End Sub

    Private Sub P_GridTelefonos(numi As String)
        DtDetalle1 = New DataTable
        DtDetalle1 = L_fnSocioDetalle1(numi)

        Dgv1Telefonos.DataSource = DtDetalle1

        With Dgv1Telefonos.Columns(0)
            .HeaderText = ""
            .Name = "cgnumi"
            .Width = 0
            .DefaultCellStyle.Font = New Font("Arial", 8)
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .ReadOnly = True
            .Visible = False
        End With
        With Dgv1Telefonos.Columns(1)
            .HeaderText = ""
            .Name = "cgttip"
            .Width = 0
            .DefaultCellStyle.Font = New Font("Arial", 8)
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .ReadOnly = True
            .Visible = False
        End With
        With Dgv1Telefonos.Columns(2)
            .HeaderText = "Tipo"
            .Name = "cedesc1"
            .Width = 150
            .DefaultCellStyle.Font = New Font("Arial", 8)
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .ReadOnly = True
            .Visible = True
        End With
        With Dgv1Telefonos.Columns(3)
            .HeaderText = "Número"
            .Name = "cgdesc"
            .Width = 200
            .DefaultCellStyle.Font = New Font("Arial", 8)
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .ReadOnly = True
            .Visible = True
        End With
        With Dgv1Telefonos.Columns(4)
            .HeaderText = ""
            .Name = "cglin"
            .Width = 0
            .DefaultCellStyle.Font = New Font("Arial", 8)
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .ReadOnly = True
            .Visible = False
        End With
        With Dgv1Telefonos.Columns(5)
            .HeaderText = ""
            .Name = "estado"
            .Width = 0
            .DefaultCellStyle.Font = New Font("Arial", 8)
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .ReadOnly = True
            .Visible = False
        End With

        With Dgv1Telefonos
            .RowHeadersVisible = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .AllowUserToOrderColumns = False
            .AllowUserToResizeColumns = False
            .AllowUserToAddRows = False
            .AllowUserToResizeRows = False
            .ReadOnly = True
            .RowsDefaultCellStyle.BackColor = Color.Bisque
            .AlternatingRowsDefaultCellStyle.BackColor = Color.Beige
        End With

    End Sub

    Private Sub P_GridHijos(numi As String)
        DtDetalle2 = New DataTable
        DtDetalle2 = L_fnSocioDetalle2(numi)

        Dgd1Hijos.PrimaryGrid.Columns.Clear()
        Dgd1Hijos.PrimaryGrid.DataSource = DtDetalle2

        Dim col As GridColumn

        With Dgd1Hijos.PrimaryGrid.Columns
            col = New GridColumn("chnumi")
            col.HeaderText = ""
            col.HeaderStyles.Default.Font = New Font("Arial", 8)
            col.Width = 0
            col.CellStyles.Default.Font = New Font("Arial", 8)
            col.HeaderStyles.Default.Alignment = Style.Alignment.MiddleCenter
            col.CellStyles.Default.Alignment = Style.Alignment.MiddleRight
            col.Visible = False
            col.ReadOnly = True
            .Add(col)
        End With
        With Dgd1Hijos.PrimaryGrid.Columns
            col = New GridColumn("chdesc")
            col.HeaderText = "Nombres y Apellidos"
            col.HeaderStyles.Default.Font = New Font("Arial", 8)
            col.Width = 200
            col.CellStyles.Default.Font = New Font("Arial", 8)
            col.HeaderStyles.Default.Alignment = Style.Alignment.MiddleCenter
            col.CellStyles.Default.Alignment = Style.Alignment.MiddleLeft
            col.Visible = True
            col.ReadOnly = True
            .Add(col)
        End With
        With Dgd1Hijos.PrimaryGrid.Columns
            col = New GridColumn("chci")
            col.HeaderText = "Carnet Identidad"
            col.HeaderStyles.Default.Font = New Font("Arial", 8)
            col.Width = 100
            col.CellStyles.Default.Font = New Font("Arial", 8)
            col.HeaderStyles.Default.Alignment = Style.Alignment.MiddleCenter
            col.CellStyles.Default.Alignment = Style.Alignment.MiddleRight
            col.Visible = True
            col.ReadOnly = True
            .Add(col)
        End With
        With Dgd1Hijos.PrimaryGrid.Columns
            col = New GridColumn("chfnac")
            col.HeaderText = "Fecha Nacimiento"
            col.HeaderStyles.Default.Font = New Font("Arial", 8)
            col.Width = 100
            col.CellStyles.Default.Font = New Font("Arial", 8)
            col.HeaderStyles.Default.Alignment = Style.Alignment.MiddleCenter
            col.CellStyles.Default.Alignment = Style.Alignment.MiddleRight
            col.Visible = True
            col.ReadOnly = True
            col.EditorType = GetType(GridDateTimePickerEditControl)
            .Add(col)
        End With
        With Dgd1Hijos.PrimaryGrid.Columns
            col = New GridColumn("chimg")
            col.HeaderText = "Foto"
            col.HeaderStyles.Default.Font = New Font("Arial", 8)
            col.Width = 40
            col.CellStyles.Default.Font = New Font("Arial", 8)
            col.HeaderStyles.Default.Alignment = Style.Alignment.MiddleCenter
            col.CellStyles.Default.Alignment = Style.Alignment.MiddleCenter
            col.Visible = False
            col.ReadOnly = True
            .Add(col)
        End With
        With Dgd1Hijos.PrimaryGrid.Columns
            col = New GridColumn("chlin")
            col.HeaderText = ""
            col.HeaderStyles.Default.Font = New Font("Arial", 8)
            col.Width = 0
            col.CellStyles.Default.Font = New Font("Arial", 8)
            col.HeaderStyles.Default.Alignment = Style.Alignment.MiddleCenter
            col.CellStyles.Default.Alignment = Style.Alignment.MiddleRight
            col.Visible = False
            col.ReadOnly = True
            .Add(col)
        End With
        With Dgd1Hijos.PrimaryGrid.Columns
            col = New GridColumn("estado")
            col.HeaderText = ""
            col.HeaderStyles.Default.Font = New Font("Arial", 8)
            col.Width = 0
            col.CellStyles.Default.Font = New Font("Arial", 8)
            col.HeaderStyles.Default.Alignment = Style.Alignment.MiddleCenter
            col.CellStyles.Default.Alignment = Style.Alignment.MiddleRight
            col.Visible = False
            col.ReadOnly = True
            .Add(col)
        End With

        With Dgd1Hijos.PrimaryGrid
            .ColumnHeader.RowHeight = 25
            .ShowRowHeaders = False
            .UseAlternateRowStyle = True
            .AllowRowHeaderResize = False
            .AllowRowResize = False
            .DefaultRowHeight = 40
            .SelectionGranularity = SelectionGranularity.Row
        End With

    End Sub

    Private Sub P_GridVehiculos(numi As String)
        DtDetalle3 = New DataTable
        DtDetalle3 = L_fnSocioDetalle3(numi)

        Dgd2Vehiculos.PrimaryGrid.Columns.Clear()
        Dgd2Vehiculos.PrimaryGrid.DataSource = DtDetalle3

        Dim col As GridColumn

        With Dgd2Vehiculos.PrimaryGrid.Columns
            col = New GridColumn("cinumi")
            col.HeaderText = ""
            col.HeaderStyles.Default.Font = New Font("Arial", 8)
            col.Width = 0
            col.CellStyles.Default.Font = New Font("Arial", 8)
            col.HeaderStyles.Default.Alignment = Style.Alignment.MiddleCenter
            col.CellStyles.Default.Alignment = Style.Alignment.MiddleRight
            col.Visible = False
            col.ReadOnly = True
            .Add(col)
        End With
        With Dgd2Vehiculos.PrimaryGrid.Columns
            col = New GridColumn("cimar")
            col.HeaderText = ""
            col.HeaderStyles.Default.Font = New Font("Arial", 8)
            col.Width = 0
            col.CellStyles.Default.Font = New Font("Arial", 8)
            col.HeaderStyles.Default.Alignment = Style.Alignment.MiddleCenter
            col.CellStyles.Default.Alignment = Style.Alignment.MiddleLeft
            col.Visible = False
            col.ReadOnly = True
            .Add(col)
        End With
        With Dgd2Vehiculos.PrimaryGrid.Columns
            col = New GridColumn("marca")
            col.HeaderText = "Marca"
            col.HeaderStyles.Default.Font = New Font("Arial", 8)
            col.Width = 120
            col.CellStyles.Default.Font = New Font("Arial", 8)
            col.HeaderStyles.Default.Alignment = Style.Alignment.MiddleCenter
            col.CellStyles.Default.Alignment = Style.Alignment.MiddleLeft
            col.Visible = True
            col.ReadOnly = True
            .Add(col)
        End With
        With Dgd2Vehiculos.PrimaryGrid.Columns
            col = New GridColumn("cimod")
            col.HeaderText = ""
            col.HeaderStyles.Default.Font = New Font("Arial", 8)
            col.Width = 0
            col.CellStyles.Default.Font = New Font("Arial", 8)
            col.HeaderStyles.Default.Alignment = Style.Alignment.MiddleCenter
            col.CellStyles.Default.Alignment = Style.Alignment.MiddleLeft
            col.Visible = False
            col.ReadOnly = True
            .Add(col)
        End With
        With Dgd2Vehiculos.PrimaryGrid.Columns
            col = New GridColumn("modelo")
            col.HeaderText = "Modelo"
            col.HeaderStyles.Default.Font = New Font("Arial", 8)
            col.Width = 120
            col.CellStyles.Default.Font = New Font("Arial", 8)
            col.HeaderStyles.Default.Alignment = Style.Alignment.MiddleCenter
            col.CellStyles.Default.Alignment = Style.Alignment.MiddleLeft
            col.Visible = True
            col.ReadOnly = True
            .Add(col)
        End With
        With Dgd2Vehiculos.PrimaryGrid.Columns
            col = New GridColumn("ciplac")
            col.HeaderText = "Placa"
            col.HeaderStyles.Default.Font = New Font("Arial", 8)
            col.Width = 80
            col.CellStyles.Default.Font = New Font("Arial", 8)
            col.HeaderStyles.Default.Alignment = Style.Alignment.MiddleCenter
            col.CellStyles.Default.Alignment = Style.Alignment.MiddleRight
            col.Visible = True
            col.ReadOnly = True
            .Add(col)
        End With
        With Dgd2Vehiculos.PrimaryGrid.Columns
            col = New GridColumn("ciros")
            col.HeaderText = "Roseta"
            col.HeaderStyles.Default.Font = New Font("Arial", 8)
            col.Width = 80
            col.CellStyles.Default.Font = New Font("Arial", 8)
            col.HeaderStyles.Default.Alignment = Style.Alignment.MiddleCenter
            col.CellStyles.Default.Alignment = Style.Alignment.MiddleRight
            col.Visible = True
            col.ReadOnly = True
            .Add(col)
        End With
        With Dgd2Vehiculos.PrimaryGrid.Columns
            col = New GridColumn("ciimg")
            col.HeaderText = "Foto"
            col.HeaderStyles.Default.Font = New Font("Arial", 8)
            col.Width = 40
            col.CellStyles.Default.Font = New Font("Arial", 8)
            col.HeaderStyles.Default.Alignment = Style.Alignment.MiddleCenter
            col.CellStyles.Default.Alignment = Style.Alignment.MiddleCenter
            col.Visible = False
            col.ReadOnly = True
            .Add(col)
        End With
        With Dgd2Vehiculos.PrimaryGrid.Columns
            col = New GridColumn("cilin")
            col.HeaderText = ""
            col.HeaderStyles.Default.Font = New Font("Arial", 8)
            col.Width = 0
            col.CellStyles.Default.Font = New Font("Arial", 8)
            col.HeaderStyles.Default.Alignment = Style.Alignment.MiddleCenter
            col.CellStyles.Default.Alignment = Style.Alignment.MiddleRight
            col.Visible = False
            col.ReadOnly = True
            .Add(col)
        End With
        With Dgd2Vehiculos.PrimaryGrid.Columns
            col = New GridColumn("estado")
            col.HeaderText = ""
            col.HeaderStyles.Default.Font = New Font("Arial", 8)
            col.Width = 0
            col.CellStyles.Default.Font = New Font("Arial", 8)
            col.HeaderStyles.Default.Alignment = Style.Alignment.MiddleCenter
            col.CellStyles.Default.Alignment = Style.Alignment.MiddleRight
            col.Visible = False
            col.ReadOnly = True
            .Add(col)
        End With

        With Dgd2Vehiculos.PrimaryGrid
            .ColumnHeader.RowHeight = 25
            .ShowRowHeaders = False
            .UseAlternateRowStyle = True
            .AllowRowHeaderResize = False
            .AllowRowResize = False
            .DefaultRowHeight = 40
            .SelectionGranularity = SelectionGranularity.Row
        End With
    End Sub

    Private Sub Bt2AddTelefono_Click(sender As Object, e As EventArgs) Handles Bt2AddTelefono.Click
        If (P_ValidarTelefonos()) Then
            DtDetalle1.Rows.Add({0, Cb3TipoTelefono.Value, Cb3TipoTelefono.Text, Tb17Numero.Text, 0, 0})
            Tb17Numero.Clear()
            Cb3TipoTelefono.SelectedIndex = 0
            Tb17Numero.Select()
        End If
    End Sub

    Private Sub Bt4AddHijo_Click(sender As Object, e As EventArgs) Handles Bt4AddHijo.Click
        If (P_ValidarHijos()) Then
            DtDetalle2.Rows.Add({0, Tb18NombreHijo.Text, Tb19CiHijo.Text, Dt4FechaNacHijo.Value.ToShortDateString, "", 0, 0})
            Tb18NombreHijo.Clear()
            Tb19CiHijo.Clear()
            Dt4FechaNacHijo.Value = Now.Date
            _prEliminarImagen(Pb2FotoHijo)

            Tb18NombreHijo.Select()
        End If
    End Sub

    Private Sub Bt6AddVehiculo_Click(sender As Object, e As EventArgs) Handles Bt6AddVehiculo.Click
        If (P_ValidarVehiculos()) Then
            DtDetalle3.Rows.Add({0, Cb4MarcaVehiculo.Value, Cb4MarcaVehiculo.Text, Cb5ModeloVehiculo.Value, Cb5ModeloVehiculo.Text, Tb21Placa.Text, CInt(Tb22NroRoseta.Text), "", 0, 0})
            Cb4MarcaVehiculo.SelectedIndex = 0
            Cb5ModeloVehiculo.SelectedIndex = 0
            Tb21Placa.Clear()
            Tb22NroRoseta.Clear()

            Cb4MarcaVehiculo.Select()
        End If
    End Sub

    Private Sub Rm1FotoSocio_ItemClick(sender As Object, e As EventArgs) Handles Rm1FotoSocio.ItemClick
        Dim item As RadialMenuItem = TryCast(sender, RadialMenuItem)
        If item IsNot Nothing AndAlso (Not String.IsNullOrEmpty(item.Text)) Then
            Select Case item.Name
                Case "btnAddImgSocio"
                    _prCargarImagen(Pb1FotoSocio)
                Case "btnEliImgSocio"
                    _prEliminarImagen(Pb1FotoSocio)
            End Select

        End If
    End Sub

    Private Sub Rm2FotoHijo_ItemClick(sender As Object, e As EventArgs) Handles Rm2FotoHijo.ItemClick
        Dim item As RadialMenuItem = TryCast(sender, RadialMenuItem)
        If item IsNot Nothing AndAlso (Not String.IsNullOrEmpty(item.Text)) Then
            Select Case item.Name
                Case "btnAddImgHijo"
                    _prCargarImagen(Pb2FotoHijo)
                Case "btnEliImgHijo"
                    _prEliminarImagen(Pb2FotoHijo)
            End Select

        End If
    End Sub

    Private Sub _prCargarImagen(pbimg As PictureBox)
        OfdFoto.InitialDirectory = "C:\Users\" + Environment.UserName + "\Pictures"
        OfdFoto.Filter = "Imagen|*.jpg;*.jpeg;*.png;*.bmp"
        OfdFoto.FilterIndex = 1
        If (OfdFoto.ShowDialog() = DialogResult.OK) Then
            vlImagen = New CImagen(OfdFoto.SafeFileName, OfdFoto.FileName, 0)
            pbimg.SizeMode = PictureBoxSizeMode.StretchImage
            pbimg.Load(vlImagen.getImagen())
        End If
    End Sub

    Private Sub _prEliminarImagen(pbimg As PictureBox)
        vlImagen = Nothing
        pbimg.Image = Nothing
        LbImagen.Text = ""
    End Sub

    Private Sub _prGuardarImagen()
        Dim rutaDestino As String = vlRutaBase + "\Imagenes\Imagenes Socios\"
        If (System.IO.Directory.Exists(rutaDestino) = False) Then
            If (System.IO.Directory.Exists(vlRutaBase + "\Imagenes\") = False) Then
                System.IO.Directory.CreateDirectory(vlRutaBase + "\Imagenes")
                If (System.IO.Directory.Exists(vlRutaBase + "\Imagenes\Imagenes Socios\") = False) Then
                    System.IO.Directory.CreateDirectory(vlRutaBase + "\Imagenes\Imagenes Socios")
                End If
            Else
                If System.IO.Directory.Exists(vlRutaBase + "\Imagenes\Imagenes Socios") = False Then
                    System.IO.Directory.CreateDirectory(vlRutaBase + "\Imagenes\Imagenes Socios")
                End If
            End If
        End If

        Dim rutaOrigen As String
        rutaOrigen = vlImagen.getImagen()
        'Pb1FotoSocio.Image = Nothing
        FileCopy(rutaOrigen, rutaDestino + vlImagen.nombre + ".jpg")
    End Sub

    Private Sub Dgj1Busqueda_KeyDown(sender As Object, e As KeyEventArgs) Handles Dgj1Busqueda.KeyDown
        If (e.KeyData = Keys.Enter) Then
            SuperTabPrincipal.SelectedTabIndex = 0
        End If
    End Sub

    Private Sub Dgj1Busqueda_DoubleClick(sender As Object, e As EventArgs) Handles Dgj1Busqueda.DoubleClick
        SuperTabPrincipal.SelectedTabIndex = 0
    End Sub

    Private Sub SuperTabPrincipal_SelectedTabChanged(sender As Object, e As SuperTabStripSelectedTabChangedEventArgs) Handles SuperTabPrincipal.SelectedTabChanged
        If (SuperTabPrincipal.SelectedTabIndex = 0 And Not DtCabecera Is Nothing) Then
            GrDatos = Dgj1Busqueda.GetRows
            P_ActualizarPuterosNavegacion()
            IndexReg = P_ObtenerIndexFila()
            P_LlenarDatos(IndexReg)
            P_ActualizarPaginacion(IndexReg)
        End If
    End Sub

    Private Function P_ObtenerIndexFila() As Integer
        Dim res As Integer
        If (Dgj1Busqueda.CurrentRow.RowIndex = -1) Then
            res = 0
        Else
            For Each fil As GridEXRow In Dgj1Busqueda.GetRows
                If (fil.Selected) Then
                    Exit For
                Else
                    res += 1
                End If
            Next
        End If
        Return res
    End Function

    Private Function P_ValidarTelefonos() As Boolean
        Dim res As Boolean = True
        If (Tb17Numero.Text = String.Empty) Then
            Tb17Numero.BackColor = Color.Red
            MEP.SetError(Tb17Numero, "ingrese un numero de telefono!".ToUpper)
            res = False
        Else
            Tb17Numero.BackColor = Color.White
            MEP.SetError(Tb17Numero, "")
        End If

        If (Not IsNumeric(Cb3TipoTelefono.Value)) Then
            Cb3TipoTelefono.BackColor = Color.Red
            MEP.SetError(Cb3TipoTelefono, "Seleccione un tipo de telefono!".ToUpper)
            res = False
        Else
            Cb3TipoTelefono.BackColor = Color.White
            MEP.SetError(Cb3TipoTelefono, "")
        End If

        Return res
    End Function

    Private Function P_ValidarHijos() As Boolean
        Dim res As Boolean = True
        If (Tb18NombreHijo.Text = String.Empty) Then
            Tb18NombreHijo.BackColor = Color.Red
            MEP.SetError(Tb18NombreHijo, "ingrese nombres y apellidos del hijo(a) del socio!".ToUpper)
            res = False
        Else
            Tb18NombreHijo.BackColor = Color.White
            MEP.SetError(Tb18NombreHijo, "")
        End If

        If (Tb19CiHijo.Text = String.Empty) Then
            Tb19CiHijo.Text = "0"
            'Tb19CiHijo.BackColor = Color.Red
            'MEP.SetError(Tb19CiHijo, "ingrese carnet de identidad del hijo(a) del socio!".ToUpper)
            'res = False
            'Else
            '    Tb19CiHijo.BackColor = Color.White
            '    MEP.SetError(Tb19CiHijo, "")
        End If
        Return res
    End Function

    Private Function P_ValidarVehiculos() As Boolean
        Dim res As Boolean = True
        If (Not IsNumeric(Cb4MarcaVehiculo.Value)) Then
            Cb4MarcaVehiculo.BackColor = Color.Red
            MEP.SetError(Cb4MarcaVehiculo, "Seleccione una marca de vehiculo del socio!".ToUpper)
            res = False
        Else
            Cb4MarcaVehiculo.BackColor = Color.White
            MEP.SetError(Cb4MarcaVehiculo, "")
        End If

        If (Not IsNumeric(Cb5ModeloVehiculo.Value)) Then
            Cb5ModeloVehiculo.BackColor = Color.Red
            MEP.SetError(Cb5ModeloVehiculo, "Seleccione un modelo de vehiculo del socio!".ToUpper)
            res = False
        Else
            Cb5ModeloVehiculo.BackColor = Color.White
            MEP.SetError(Cb5ModeloVehiculo, "")
        End If

        If (Tb21Placa.Text = String.Empty) Then
            Tb21Placa.BackColor = Color.Red
            MEP.SetError(Tb21Placa, "ingrese placa de vehiculo del socio!".ToUpper)
            res = False
        Else
            Tb21Placa.BackColor = Color.White
            MEP.SetError(Tb21Placa, "")
        End If

        If (Dgd2Vehiculos.PrimaryGrid.Rows.Count >= 4) Then 'Extraer de una tabla de politicas de negocio
            ToastNotification.Show(Me,
                                   "solo se permite ingresar 4 vehiculos por socio.".ToUpper,
                                   My.Resources.WARNING, Duracion * 1000,
                                   eToastGlowColor.Red,
                                   eToastPosition.TopCenter)
            res = False
        End If

        If (Tb22NroRoseta.Text = String.Empty) Then
            Tb22NroRoseta.Text = "0"
        End If
        Return res
    End Function

    Private Sub MODIFICARNUMEROToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MODIFICARNUMEROToolStripMenuItem.Click
        'Dim pos As Integer = Dgv1Telefonos.CurrentRow.Index
        'If (pos >= 0 And pos <= Dgv1Telefonos.RowCount - 1) Then
        '    Dim estado As Integer
        '    estado = Dgv1Telefonos.Rows(pos).Cells("estado").Value
        '    If (estado = 1 Or estado = 2) Then ' si estoy eliminando una fila ya guardada le cambio el estado y lo oculto de la grilla
        '        Dgv1Telefonos.Rows(pos).Cells("estado").Value = 2
        '        Dgv1Telefonos.CurrentCell = Nothing
        '        Dgv1Telefonos.Rows(pos).Visible = False
        '    Else 'si estoy eliminando una fila nueva, simplemente la elimino del grid
        '        Dgv1Telefonos.Rows.RemoveAt(pos)
        '    End If
        'End If
    End Sub

    Private Sub ELIMINARNUMEROToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ELIMINARNUMEROToolStripMenuItem.Click
        Dim pos As Integer = Dgv1Telefonos.CurrentRow.Index
        If (pos >= 0 And pos <= Dgv1Telefonos.RowCount - 1) Then
            Dim estado As Integer
            estado = Dgv1Telefonos.Rows(pos).Cells("estado").Value
            If (estado = 1 Or estado = 2) Then ' si estoy eliminando una fila ya guardada le cambio el estado y lo oculto de la grilla
                Dgv1Telefonos.Rows(pos).Cells("estado").Value = -1
                Dgv1Telefonos.CurrentCell = Nothing
                Dgv1Telefonos.Rows(pos).Visible = False
            Else 'si estoy eliminando una fila nueva, simplemente la elimino del grid
                Dgv1Telefonos.Rows.RemoveAt(pos)
            End If
        End If
    End Sub

    Private Sub MODIFICARHIJOToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MODIFICARHIJOToolStripMenuItem.Click
        'Dim pos As Integer = Dgv1Telefonos.CurrentRow.Index
        'If (pos >= 0 And pos <= Dgv1Telefonos.RowCount - 1) Then
        '    Dim estado As Integer
        '    estado = Dgv1Telefonos.Rows(pos).Cells("estado").Value
        '    If (estado = 1 Or estado = 2) Then ' si estoy eliminando una fila ya guardada le cambio el estado y lo oculto de la grilla
        '        Dgv1Telefonos.Rows(pos).Cells("estado").Value = 2
        '        Dgv1Telefonos.CurrentCell = Nothing
        '        Dgv1Telefonos.Rows(pos).Visible = False
        '    Else 'si estoy eliminando una fila nueva, simplemente la elimino del grid
        '        Dgv1Telefonos.Rows.RemoveAt(pos)
        '    End If
        'End If
    End Sub

    Private Sub ELIMINARHIJOToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ELIMINARHIJOToolStripMenuItem.Click
        Dim pos As Integer = Dgd1Hijos.PrimaryGrid.ActiveRow.Index
        If (pos >= 0 And pos <= Dgd1Hijos.PrimaryGrid.Rows.Count - 1) Then
            Dim estado As Integer
            estado = Dgd1Hijos.PrimaryGrid.GetCell(pos, Dgd1Hijos.PrimaryGrid.Columns("estado").ColumnIndex).Value
            If (estado = 1 Or estado = 2) Then ' si estoy eliminando una fila ya guardada le cambio el estado y lo oculto de la grilla
                Dgd1Hijos.PrimaryGrid.GetCell(pos, Dgd1Hijos.PrimaryGrid.Columns("estado").ColumnIndex).Value = -1
                Dgd1Hijos.PrimaryGrid.Rows(pos).Visible = False
            Else 'si estoy eliminando una fila nueva, simplemente la elimino del grid
                Dgd1Hijos.PrimaryGrid.Rows.RemoveAt(pos)
            End If
        End If
    End Sub

    Private Sub MODIFICARVEHICULOToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MODIFICARVEHICULOToolStripMenuItem.Click
        'Dim pos As Integer = Dgv1Telefonos.CurrentRow.Index
        'If (pos >= 0 And pos <= Dgv1Telefonos.RowCount - 1) Then
        '    Dim estado As Integer
        '    estado = Dgv1Telefonos.Rows(pos).Cells("estado").Value
        '    If (estado = 1 Or estado = 2) Then ' si estoy eliminando una fila ya guardada le cambio el estado y lo oculto de la grilla
        '        Dgv1Telefonos.Rows(pos).Cells("estado").Value = 2
        '        Dgv1Telefonos.CurrentCell = Nothing
        '        Dgv1Telefonos.Rows(pos).Visible = False
        '    Else 'si estoy eliminando una fila nueva, simplemente la elimino del grid
        '        Dgv1Telefonos.Rows.RemoveAt(pos)
        '    End If
        'End If
    End Sub

    Private Sub ELIMINARVEHICULOToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ELIMINARVEHICULOToolStripMenuItem.Click
        Dim pos As Integer = Dgd2Vehiculos.PrimaryGrid.ActiveRow.Index
        If (pos >= 0 And pos <= Dgd2Vehiculos.PrimaryGrid.Rows.Count - 1) Then
            Dim estado As Integer
            estado = Dgd2Vehiculos.PrimaryGrid.GetCell(pos, Dgd2Vehiculos.PrimaryGrid.Columns("estado").ColumnIndex).Value
            If (estado = 1 Or estado = 2) Then ' si estoy eliminando una fila ya guardada le cambio el estado y lo oculto de la grilla
                Dgd2Vehiculos.PrimaryGrid.GetCell(pos, Dgd2Vehiculos.PrimaryGrid.Columns("estado").ColumnIndex).Value = -1
                Dgd2Vehiculos.PrimaryGrid.Rows(pos).Visible = False
            Else 'si estoy eliminando una fila nueva, simplemente la elimino del grid
                Dgd2Vehiculos.PrimaryGrid.Rows.RemoveAt(pos)
            End If
        End If
    End Sub

    Private Sub Cb3TipoTelefono_ValueChanged(sender As Object, e As EventArgs) Handles Cb3TipoTelefono.ValueChanged
        Dim array As DataRow() = CType(Cb3TipoTelefono.DataSource, DataTable).Select("cedesc1='" + Cb3TipoTelefono.Text + "'")
        If (array.Count = 0) Then
            BtAddLibTelefono.Visible = True
        Else
            BtAddLibTelefono.Visible = False
        End If
        'If (Not IsNumeric(Cb3TipoTelefono.Value)) Then
        '    BtAddLibTelefono.Visible = True
        'Else
        '    BtAddLibTelefono.Visible = False
        'End If
    End Sub

    Private Sub BtAddLibTelefono_Click(sender As Object, e As EventArgs) Handles BtAddLibTelefono.Click
        Dim numi As Integer = 0
        Dim desc As String = Cb3TipoTelefono.Text
        Dim res As Boolean = L_prLibreriaGrabar(numi, gi_LibTELEFONO, gi_LibTELTipo, desc, "")
        If (res) Then
            P_ComboTipoTelefono()
            Cb3TipoTelefono.Clear()
            Cb3TipoTelefono.SelectedText = desc
            Cb3TipoTelefono.Focus()
            ToastNotification.Show(Me, "Libreria de teléfono: ".ToUpper + desc + " Grabado con Exito.".ToUpper,
                                       My.Resources.GRABACION_EXITOSA,
                                       Duracion * 500,
                                       eToastGlowColor.Green,
                                       eToastPosition.TopCenter)
            BtAddLibTelefono.Visible = False
        Else
            ToastNotification.Show(Me, "No se pudo grabar la libreria de teléfono: ".ToUpper + desc + ", intente nuevamente.".ToUpper,
                               My.Resources.WARNING,
                               Duracion * 500,
                               eToastGlowColor.Red,
                               eToastPosition.TopCenter)
            BtAddLibTelefono.Visible = True
        End If
    End Sub

    Private Sub Cb4MarcaVehiculo_ValueChanged(sender As Object, e As EventArgs) Handles Cb4MarcaVehiculo.ValueChanged
        Dim array As DataRow() = CType(Cb4MarcaVehiculo.DataSource, DataTable).Select("cedesc1='" + Cb4MarcaVehiculo.Text + "'")
        If (array.Count = 0) Then
            BtAddLibMarca.Visible = True
        Else
            BtAddLibMarca.Visible = False
        End If
        'If (Not IsNumeric(Cb4MarcaVehiculo.Value)) Then
        '    BtAddLibMarca.Visible = True
        'Else
        '    BtAddLibMarca.Visible = False
        'End If
    End Sub

    Private Sub BtAddLibMarca_Click(sender As Object, e As EventArgs) Handles BtAddLibMarca.Click
        Dim numi As Integer = 0
        Dim desc As String = Cb4MarcaVehiculo.Text
        Dim res As Boolean = L_prLibreriaGrabar(numi, gi_LibVEHICULO, gi_LibVEHIMarca, desc, "")
        If (res) Then
            P_ComboMarcaVehiculo()
            Cb4MarcaVehiculo.Clear()
            Cb4MarcaVehiculo.SelectedText = desc
            Cb4MarcaVehiculo.Focus()
            ToastNotification.Show(Me, "Libreria de marca de vehiculo: ".ToUpper + desc + " Grabado con Exito.".ToUpper,
                                       My.Resources.GRABACION_EXITOSA,
                                       Duracion * 500,
                                       eToastGlowColor.Green,
                                       eToastPosition.TopCenter)
            BtAddLibMarca.Visible = False
        Else
            ToastNotification.Show(Me, "No se pudo grabar la libreria de marca de vehiculo: ".ToUpper + desc + ", intente nuevamente.".ToUpper,
                               My.Resources.WARNING,
                               Duracion * 500,
                               eToastGlowColor.Red,
                               eToastPosition.TopCenter)
            BtAddLibMarca.Visible = True
        End If
    End Sub

    Private Sub Cb5ModeloVehiculo_ValueChanged(sender As Object, e As EventArgs) Handles Cb5ModeloVehiculo.ValueChanged
        Dim array As DataRow() = CType(Cb5ModeloVehiculo.DataSource, DataTable).Select("cedesc1='" + Cb5ModeloVehiculo.Text + "'")
        If (array.Count = 0) Then
            BtAddLibModelo.Visible = True
        Else
            BtAddLibModelo.Visible = False
        End If
        'If (Not IsNumeric(Cb5ModeloVehiculo.Value)) Then
        '    BtAddLibModelo.Visible = True
        'Else
        '    BtAddLibModelo.Visible = False
        'End If
    End Sub

    Private Sub BtAddLibModelo_Click(sender As Object, e As EventArgs) Handles BtAddLibModelo.Click
        Dim numi As Integer = 0
        Dim desc As String = Cb5ModeloVehiculo.Text
        Dim res As Boolean = L_prLibreriaGrabar(numi, gi_LibVEHICULO, gi_LibVEHIModelo, desc, "")
        If (res) Then
            P_ComboModeloVehiculo()
            Cb5ModeloVehiculo.Clear()
            Cb5ModeloVehiculo.SelectedText = desc
            Cb5ModeloVehiculo.Focus()
            ToastNotification.Show(Me, "Libreria de módelo de vehiculo: ".ToUpper + desc + " Grabado con Exito.".ToUpper,
                                       My.Resources.GRABACION_EXITOSA,
                                       Duracion * 500,
                                       eToastGlowColor.Green,
                                       eToastPosition.TopCenter)
            BtAddLibModelo.Visible = False
        Else
            ToastNotification.Show(Me, "No se pudo grabar la libreria de módelo de vehiculo: ".ToUpper + desc + ", intente nuevamente.".ToUpper,
                               My.Resources.WARNING,
                               Duracion * 500,
                               eToastGlowColor.Red,
                               eToastPosition.TopCenter)
            BtAddLibModelo.Visible = True
        End If
    End Sub

    Private Sub Tb11Email_Enter(sender As Object, e As EventArgs) Handles Tb11Email.Enter
        Modelos.ModeloF0.BoIsMayuscula = False
    End Sub

    Private Sub Tb11Email_Leave(sender As Object, e As EventArgs) Handles Tb11Email.Leave
        Modelos.ModeloF0.BoIsMayuscula = True
    End Sub

    Private Sub Tb2NroSocio_Validated(sender As Object, e As EventArgs) Handles Tb2NroSocio.Validated
        If (Nuevo) Then
            If (L_fnSocioValidarNroSocio(Tb2NroSocio.Text.Trim).Rows(0).Item(0).ToString.Equals("1")) Then 'El nro de socio ya existe
                ToastNotification.Show(Me, "El nro de socio: ".ToUpper + Tb2NroSocio.Text.Trim + " ya existe en la base de datos.".ToUpper + ChrW(13) + "Verifique sus datos porfavor.".ToUpper,
                                       My.Resources.WARNING,
                                       Duracion * 1000,
                                       eToastGlowColor.Red,
                                       eToastPosition.TopCenter)

                Tb2NroSocio.Select()
            End If
        End If
    End Sub

    Public Sub P_prInicarMapa()
        _Punto = 0
        '_ListPuntos = New List(Of PointLatLng)
        _Overlay = New GMapOverlay("points")
        GmUbicacion.Overlays.Add(_Overlay)
        P_prIniciarMap()
    End Sub

    Private Sub P_prIniciarMap()
        GmUbicacion.DragButton = MouseButtons.Left
        GmUbicacion.CanDragMap = True
        GmUbicacion.MapProvider = GMapProviders.GoogleMap
        If (_latitud <> 0 And _longitud <> 0) Then
            GmUbicacion.Position = New PointLatLng(_latitud, _longitud)
        Else
            _Overlay.Markers.Clear()
            GmUbicacion.Position = New PointLatLng(-17.393482, -66.15701)
        End If

        GmUbicacion.MinZoom = 0
        GmUbicacion.MaxZoom = 24
        GmUbicacion.Zoom = 15.5
        GmUbicacion.AutoScroll = True

        GMapProvider.Language = LanguageType.Spanish
    End Sub

    Private Sub GmUbicacion_DoubleClick(sender As Object, e As EventArgs) Handles GmUbicacion.DoubleClick
        If (btnGrabar.Enabled = True) Then
            _Overlay.Markers.Clear()

            Dim gm As GMapControl = CType(sender, GMapControl)
            Dim hj As MouseEventArgs = CType(e, MouseEventArgs)
            Dim plg As PointLatLng = gm.FromLocalToLatLng(hj.X, hj.Y)
            _latitud = plg.Lat
            _longitud = plg.Lng
            ''  MsgBox("latitud:" + Str(plg.Lat) + "   Logitud:" + Str(plg.Lng))

            P_AgregarPunto(plg)

            '' _ListPuntos.Add(plg)
            'Btnx_ChekGetPoint.Visible = False
        End If
    End Sub

    Private Sub P_AgregarPunto(plg As PointLatLng)
        If (Not IsNothing(_Overlay)) Then
            'añadir puntos
            'Dim markersOverlay As New GMapOverlay("markers")
            Dim marker As New GMarkerGoogle(plg, My.Resources.markerIcono)
            'añadir tooltip
            Dim mode As MarkerTooltipMode = MarkerTooltipMode.OnMouseOver
            marker.ToolTip = New GMapBaloonToolTip(marker)
            marker.ToolTipMode = mode
            Dim ToolTipBackColor As New SolidBrush(Color.Blue)
            marker.ToolTip.Fill = ToolTipBackColor
            marker.ToolTip.Foreground = Brushes.White
            'If (Not _nombre.ToString = String.Empty) Then
            '    marker.ToolTipText = "CLIENTE: " + _nombre & vbNewLine & " CI:" + _ci
            'End If
            _Overlay.Markers.Add(marker)
            'mapa.Overlays.Add(markersOverlay)
            GmUbicacion.Position = plg
        End If
    End Sub

    Public Sub P_prPonerUbicacion()
        If (_latitud <> 0 And _longitud <> 0) Then
            Dim plg As PointLatLng = New PointLatLng(_latitud, _longitud)
            _Overlay.Markers.Clear()
            P_AgregarPunto(plg)
        Else
            _Overlay.Markers.Clear()
            GmUbicacion.Position = New PointLatLng(-17.393482, -66.15701)
        End If
    End Sub

    Private Sub btZoomAcercar_Click(sender As Object, e As EventArgs) Handles btZoomAcercar.Click
        If (GmUbicacion.Zoom <= GmUbicacion.MaxZoom) Then
            GmUbicacion.Zoom = GmUbicacion.Zoom + 1
        End If
    End Sub

    Private Sub btZoomAlejar_Click(sender As Object, e As EventArgs) Handles btZoomAlejar.Click
        If (GmUbicacion.Zoom >= GmUbicacion.MinZoom) Then
            GmUbicacion.Zoom = GmUbicacion.Zoom - 1
        End If
    End Sub

    Private Sub btExportarExcel_Click(sender As Object, e As EventArgs) Handles btExportarExcel.Click
        If (P_ExportarExcel()) Then
            ToastNotification.Show(Me, "EXPORTACIÓN DE LISTA DE SOCIO EXITOSA.",
                                       My.Resources.OK, Duracion * 1000,
                                       eToastGlowColor.Green,
                                       eToastPosition.TopCenter)
        Else
            ToastNotification.Show(Me, "FALLO AL EXPORTACIÓN DE LISTA DE SOCIO.",
                                       My.Resources.WARNING, Duracion * 1000,
                                       eToastGlowColor.Red,
                                       eToastPosition.TopCenter)
        End If
    End Sub

    Private Function P_ExportarExcel() As Boolean
        Dim rutaArchivo As String
        'Dim _directorio As New FolderBrowserDialog

        If (1 = 1) Then 'If(_directorio.ShowDialog = Windows.Forms.DialogResult.OK) Then
            '_ubicacion = _directorio.SelectedPath
            rutaArchivo = gs_RutaArchivos + "\Socio\Lista Socios"
            If (Not Directory.Exists(gs_RutaArchivos + "\Socio\Lista Socios")) Then
                Directory.CreateDirectory(gs_RutaArchivos + "\Socio\Lista Socios")
            End If
            Try
                Dim _stream As Stream
                Dim _escritor As StreamWriter
                Dim _fila As Integer = Dgj1Busqueda.RowCount
                Dim _columna As Integer = Dgj1Busqueda.RootTable.Columns.Count
                Dim _archivo As String = rutaArchivo & "\Lista_Socios_" & "_" & Now.Date.Day & _
                    "." & Now.Date.Month & "." & Now.Date.Year & "_" & Now.Hour & "." & Now.Minute & "." & Now.Second & ".csv"
                Dim _linea As String = ""
                Dim _filadata = 0, columndata As Int32 = 0
                File.Delete(_archivo)
                _stream = File.OpenWrite(_archivo)
                _escritor = New StreamWriter(_stream, System.Text.Encoding.UTF8)

                For Each _col As GridEXColumn In Dgj1Busqueda.RootTable.Columns
                    If (_col.Visible) Then
                        _linea = _linea & _col.Caption & ";"
                    End If
                Next
                _linea = Mid(CStr(_linea), 1, _linea.Length - 1)
                _escritor.WriteLine(_linea)
                _linea = Nothing

                CpExportarExcel.Visible = True
                CpExportarExcel.Minimum = 1
                CpExportarExcel.Maximum = Dgj1Busqueda.RowCount
                CpExportarExcel.Value = 1

                For Each _fil As GridEXRow In Dgj1Busqueda.GetRows
                    For Each _col As GridEXColumn In Dgj1Busqueda.RootTable.Columns
                        If (_col.Visible) Then
                            _linea = _linea & CStr(_fil.Cells(_col.Key).Value) & ";"
                        End If
                    Next
                    _linea = Mid(CStr(_linea), 1, _linea.Length - 1)
                    _escritor.WriteLine(_linea)
                    _linea = Nothing
                    CpExportarExcel.Value += 1
                Next
                _escritor.Close()
                CpExportarExcel.Visible = False
                Try
                    Dim info As New TaskDialogInfo("¿desea abrir el archivo?".ToUpper, eTaskDialogIcon.Exclamation, "pregunta".ToUpper, "Desea continuar?".ToUpper, eTaskDialogButton.Yes Or eTaskDialogButton.Cancel, eTaskDialogBackgroundColor.Blue)
                    Dim result As eTaskDialogResult = TaskDialog.Show(info)
                    If result = eTaskDialogResult.Yes Then
                        Process.Start(_archivo)
                    End If
                    Return True
                Catch ex As Exception
                    MsgBox(ex.Message)
                    Return False
                End Try
            Catch ex As Exception
                MsgBox(ex.Message)
                Return False
            End Try
        End If
        Return False
    End Function

    Private Sub btAddImgVehiculo_Click(sender As Object, e As EventArgs) Handles btAddImgVehiculo.Click
        If (Dgd2Vehiculos.PrimaryGrid.Rows.Count > 0) Then
            If (Tb1Codigo.Text = String.Empty) Then
                ToastNotification.Show(Me,
                                   "Para ingresar las fotos de los vehiculos del socio".ToUpper + vbCrLf _
                                   + "primero debe guardar sus datos.".ToUpper,
                                   My.Resources.INFORMATION,
                                   Duracion * 1000,
                                   eToastGlowColor.Red,
                                   eToastPosition.TopCenter)
            Else
                Dim frm As New EfectoAyuda
                frm.codigo = CInt(Tb1Codigo.Text)
                frm.nombre = Tb4Nombre.Text.Trim + " " + Tb5ApellidoPat.Text.Trim + " " + Tb6ApellidoMat.Text.Trim
                frm.tipo = 4
                frm.ShowDialog()
            End If
        Else
            ToastNotification.Show(Me,
                                   "Este socio no tiene vehiculos registrados".ToUpper,
                                   My.Resources.INFORMATION,
                                   Duracion * 1000,
                                   eToastGlowColor.Red,
                                   eToastPosition.TopCenter)

        End If
    End Sub
End Class

