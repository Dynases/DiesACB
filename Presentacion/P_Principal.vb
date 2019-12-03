Imports Logica.AccesoLogica
Imports Modelos.MGlobal
Imports DevComponents.DotNetBar.Controls
Imports DevComponents.DotNetBar.Metro
Imports DevComponents.DotNetBar
Imports DevComponents.DotNetBar.Rendering

Public Class P_Principal

#Region "Atributos"
    Private _version As String
#End Region

#Region "Metodos Privados"

    Public Sub New()
        _prCambiarStyle()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Private Sub _prIniciarTodo()
        'poner numiModulos a los modulos
        'poner numiModulos a los modulos y tambien la version
        FP_Configuracion.Tag = New Version(1, "2.9.8")
        FP_RecHumanos.Tag = New Version(2, "2.9.8")
        FP_Escuela.Tag = New Version(3, "2.9.9")
        FP_Socios.Tag = New Version(4, "3.0.9")
        FP_Certificacion.Tag = New Version(5, "2.9.9")
        FP_Lavadero.Tag = New Version(6, "3.0.1")
        FP_Hotel.Tag = New Version(7, "3.0.0")
        FP_Remolque.Tag = New Version(8, "3.0.0")

        'obtenerVersion
        Dim acerca As New P_Acerca
        _version = acerca.lbVersion.Text

        'preguntar por el separador decimal
        tbDecimal.Value = 3.14
        Dim simboloDecimal As String = tbDecimal.Value.ToString

        If simboloDecimal.Contains(".") = False Then 'And s <> "."
            Dim info As New TaskDialogInfo("CONFIGURACION ERRONEA".ToUpper, eTaskDialogIcon.Exclamation, "separador decimal incorrecto, no se puede iniciar el sistema".ToUpper, "cambiar el separador decimal a punto '.'".ToUpper, eTaskDialogButton.Ok, eTaskDialogBackgroundColor.Blue)
            Dim result As eTaskDialogResult = TaskDialog.Show(info)
            Close()
            Return
        End If


        'Leer Archivo de Configuración
        _prLeerArchivoConfig()

        L_prAbrirConexion(gs_Ip, gs_UsuarioSql, gs_ClaveSql, gs_NombreBD)
        L_prAbrirConexionBitacora(gs_Ip, gs_UsuarioSql, gs_ClaveSql, "BDDicon")
        gb_ConexionAbierta = True

        Me.WindowState = FormWindowState.Maximized

        _prCargarLogo()


        'iniciar login de usuario
        _prLogin()

    End Sub

    Private Sub _prCargarLogo()
        'gs_CarpetaRaiz
        Dim exists As Boolean
        'exists = System.IO.File.Exists(gs_CarpetaRaiz + "\imagenlogo.jpg")
        'If exists = True Then
        '    'cargar imagen
        '    PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        '    PictureBox2.SizeMode = PictureBoxSizeMode.StretchImage
        '    PictureBox3.SizeMode = PictureBoxSizeMode.StretchImage
        '    PictureBox4.SizeMode = PictureBoxSizeMode.StretchImage
        '    PictureBox5.SizeMode = PictureBoxSizeMode.StretchImage
        '    PictureBox6.SizeMode = PictureBoxSizeMode.StretchImage
        '    PictureBox7.SizeMode = PictureBoxSizeMode.StretchImage

        '    PictureBox1.Load(gs_CarpetaRaiz + "\imagenlogo.jpg")
        '    PictureBox2.Load(gs_CarpetaRaiz + "\imagenlogo.jpg")
        '    PictureBox3.Load(gs_CarpetaRaiz + "\imagenlogo.jpg")
        '    PictureBox4.Load(gs_CarpetaRaiz + "\imagenlogo.jpg")
        '    PictureBox5.Load(gs_CarpetaRaiz + "\imagenlogo.jpg")
        '    PictureBox6.Load(gs_CarpetaRaiz + "\imagenlogo.jpg")
        '    PictureBox7.Load(gs_CarpetaRaiz + "\imagenlogo.jpg")
        '    Me.Refresh()

        'End If

        'PictureBox1.Visible = True
        'PictureBox2.Visible = True
        'PictureBox3.Visible = True
        'PictureBox4.Visible = True
        'PictureBox5.Visible = True
        'PictureBox6.Visible = True
        'PictureBox7.Visible = True

        'cargar el fondo de pantalla
        Dim ruta As String = gs_CarpetaRaiz + "\imagenfondo.jpg"
        exists = System.IO.File.Exists(ruta)
        If exists = True Then
            'cargar imagen
            'MetroTilePanel1.SizeMode = PictureBoxSizeMode.StretchImage
            'PictureBox2.SizeMode = PictureBoxSizeMode.StretchImage
            'PictureBox3.SizeMode = PictureBoxSizeMode.StretchImage
            'PictureBox4.SizeMode = PictureBoxSizeMode.StretchImage
            'PictureBox5.SizeMode = PictureBoxSizeMode.StretchImage
            'PictureBox6.SizeMode = PictureBoxSizeMode.StretchImage
            'PictureBox7.SizeMode = PictureBoxSizeMode.StretchImage

            MetroTilePanel1.BackgroundImage = Image.FromFile(ruta)
            MetroTilePanel2.BackgroundImage = Image.FromFile(ruta)
            MetroTilePanel3.BackgroundImage = Image.FromFile(ruta)
            MetroTilePanel4.BackgroundImage = Image.FromFile(ruta)
            MetroTilePanel5.BackgroundImage = Image.FromFile(ruta)
            MetroTilePanel6.BackgroundImage = Image.FromFile(ruta)
            MetroTilePanel7.BackgroundImage = Image.FromFile(ruta)
            MetroTilePanel8.BackgroundImage = Image.FromFile(ruta)

            Me.Refresh()

        End If

        Me.Refresh()
    End Sub
    Private Sub _prCambiarStyle()
        'tratar de cambiar estilo
        RibbonPredefinedColorSchemes.ChangeOffice2007ColorTable(Me, DevComponents.DotNetBar.Rendering.eOffice2007ColorScheme.VistaGlass)
        'RibbonPredefinedColorSchemes.ChangeOffice2007ColorTable(Me, eStyle.VisualStudio2012Dark)
        'RibbonPredefinedColorSchemes.ChangeStyle(eStyle.VisualStudio2012Dark)

        'cambio de otros colores
        Dim table As Office2007ColorTable = CType(GlobalManager.Renderer, Office2007Renderer).ColorTable
        Dim ct As SideNavColorTable = table.SideNav
        ct.TitleBackColor = Color.Black
        'ct.SideNavItem.MouseOver.BackColors = New Color() {Color.Red, Color.Yellow}
        ct.SideNavItem.MouseOver.BorderColors = New Color() {Color.Black} ' No border
        ct.SideNavItem.Selected.BackColors = New Color() {Color.Yellow}
        ct.BorderColors = New Color() {Color.Black} ' Control border color

        ct.PanelBackColor = Color.Black
    End Sub

    Private Sub _prLeerArchivoConfig()
        Dim Archivo() As String = IO.File.ReadAllLines(Application.StartupPath + "\CONFIG.TXT")
        gs_Ip = Archivo(0).Split("=")(1).Trim
        gs_UsuarioSql = Archivo(1).Split("=")(1).Trim
        gs_ClaveSql = Archivo(2).Split("=")(1).Trim
        gs_NombreBD = Archivo(3).Split("=")(1).Trim
        gs_CarpetaRaiz = Archivo(4).Split("=")(1).Trim
    End Sub

    Private Sub _prLogin()
        Dim Frm As New P_Login
        Frm.ShowDialog()

        L_Usuario = gs_user
        Modelos.MGlobal.gs_usuario = gs_user

        lbUsuario.Text = gs_user
        lbUsuario.Font = New Font("Tahoma", 12, FontStyle.Bold)

        If gs_user = "DEFAULT" Then
            SideNav1.Enabled = False
        Else
            _PCargarPrivilegios()
            _prCargarConfiguracionSistema()
            SideNav1.Enabled = True
        End If
    End Sub

    Private Sub _prCargarConfiguracionSistema()
        Dim dtConf As DataTable = L_prConGlobalGeneral()
        gd_notaAproTeo = dtConf.Rows(0).Item("gbaproteo")
        gd_notaAproTeoH = IIf(IsDBNull(dtConf.Rows(0).Item("gbaproteoh")) = True, 16, dtConf.Rows(0).Item("gbaproteoh"))
        gd_notaAproPrac = dtConf.Rows(0).Item("gbaproprac")
        gi_nroMaxAlumTeo = dtConf.Rows(0).Item("gbnroinscteo")
        gi_cumpleInstructor = dtConf.Rows(0).Item("gbcumple")
    End Sub

    Private Sub _PCargarPrivilegios()
        Dim listaTabs As New List(Of DevComponents.DotNetBar.Metro.MetroTilePanel)
        listaTabs.Add(MetroTilePanel1)
        listaTabs.Add(MetroTilePanel2)
        listaTabs.Add(MetroTilePanel3)
        listaTabs.Add(MetroTilePanel4)
        listaTabs.Add(MetroTilePanel5)
        listaTabs.Add(MetroTilePanel6)
        listaTabs.Add(MetroTilePanel7)
        listaTabs.Add(MetroTilePanel8)

        Dim idRolUsu As String = gi_userRol

        Dim dtModulos As DataTable = L_prLibreriaDetalleGeneral(gi_libModulos, gi_libMTipoModulo)
        Dim listFormsModulo As New List(Of String)

        For i = 0 To dtModulos.Rows.Count - 1
            Dim dtDetRol As DataTable = L_RolDetalle_General(-1, idRolUsu, dtModulos.Rows(i).Item("cenum"))
            listFormsModulo = New List(Of String)

            If dtDetRol.Rows.Count > 0 Then
                'cargo los nombres de los programas(botones) del modulo
                For Each fila As DataRow In dtDetRol.Rows
                    listFormsModulo.Add(fila.Item("yaprog").ToString.ToUpper)
                Next
                'recorro el modulo(tab) que corresponde
                For Each _item As DevComponents.DotNetBar.BaseItem In listaTabs.Item(i).Items
                    If TypeOf (_item) Is DevComponents.DotNetBar.Metro.MetroTileItem Then 'es un boton del modulo
                        Dim btn As DevComponents.DotNetBar.Metro.MetroTileItem = CType(_item, DevComponents.DotNetBar.Metro.MetroTileItem)
                        If listFormsModulo.Contains(btn.Name.ToUpper) Then 'si el nombre del boton pertenece a la lista de formularios del modulo
                            Dim Texto As String = btn.Text
                            Dim TTexto As String = btn.TitleText
                            Dim f As Integer = listFormsModulo.IndexOf(btn.Name.ToUpper)
                            If Texto = "" Then 'esta usando el Title Text
                                btn.TitleText = dtDetRol.Rows(f).Item("yatit").ToString.ToUpper
                            Else 'esta usando el Text
                                btn.Text = dtDetRol.Rows(f).Item("yatit").ToString.ToUpper
                            End If

                            If dtDetRol.Rows(f).Item("ycshow") = True Or dtDetRol.Rows(f).Item("ycadd") = True Or dtDetRol.Rows(f).Item("ycmod") = True Or dtDetRol.Rows(f).Item("ycdel") = True Then
                                btn.Visible = True
                            Else
                                btn.Visible = False
                            End If
                        Else 'si no pertenece lo oculto
                            btn.Visible = False
                        End If
                    Else 'seria un sub grupo en el modulo
                        'recorro todos los elementos del sub grupo
                        If TypeOf _item Is ItemContainer Then
                            For Each _subItem In _item.SubItems
                                Dim _subBtn As MetroTileItem = CType(_subItem, MetroTileItem)
                                If listFormsModulo.Contains(_subBtn.Name.ToUpper) Then
                                    Dim Texto As String = _subBtn.Text
                                    Dim TTexto As String = _subBtn.TitleText
                                    Dim f As Integer = listFormsModulo.IndexOf(_subBtn.Name.ToUpper)
                                    If Texto = "" Then 'esta usando el Title Text
                                        _subBtn.TitleText = dtDetRol.Rows(f).Item("yatit").ToString.ToUpper
                                    Else 'esta usando el Text
                                        _subBtn.Text = dtDetRol.Rows(f).Item("yatit").ToString.ToUpper
                                    End If

                                    If dtDetRol.Rows(f).Item("ycshow") = True Or dtDetRol.Rows(f).Item("ycadd") = True Or dtDetRol.Rows(f).Item("ycmod") = True Or dtDetRol.Rows(f).Item("ycdel") = True Then
                                        _subBtn.Visible = True
                                    Else
                                        _subBtn.Visible = False
                                    End If
                                Else
                                    _subBtn.Visible = False
                                End If
                            Next
                        End If

                    End If
                Next
            Else ' no exiten formulario registrados en el modulo pero igual hay que ocultar los botones y los subbotones que tenga
                For Each _item As DevComponents.DotNetBar.BaseItem In listaTabs.Item(i).Items
                    If TypeOf (_item) Is DevComponents.DotNetBar.Metro.MetroTileItem Then 'es un boton del modulo
                        Dim btn As DevComponents.DotNetBar.Metro.MetroTileItem = CType(_item, DevComponents.DotNetBar.Metro.MetroTileItem)
                        btn.Visible = False
                    Else 'seria un sub grupo en el modulo
                        'recorro todos los elementos del sub grupo
                        If TypeOf _item Is ItemContainer Then
                            For Each _subItem In _item.SubItems
                                Dim _subBtn As MetroTileItem = CType(_subItem, MetroTileItem)
                                _subBtn.Visible = False
                            Next
                        End If

                    End If
                Next

            End If

        Next

        'refrescar el formulario
        Me.Refresh()
    End Sub
#End Region

    Private Sub P_Principal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _prIniciarTodo()
    End Sub
    Private Sub P_Principal_MouseClick(sender As Object, e As MouseEventArgs) Handles MyBase.MouseClick
        _prLogin()
    End Sub

    Private Sub P_Principal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MyBase.KeyPress
        _prLogin()
    End Sub

    Private Sub rmSesion_ItemClick(sender As Object, e As EventArgs) Handles rmSesion.ItemClick
        Dim item As RadialMenuItem = TryCast(sender, RadialMenuItem)
        If item IsNot Nothing AndAlso (Not String.IsNullOrEmpty(item.Text)) Then
            Select Case item.Name
                Case "btCerrarSesion"
                    _prLogin()
                Case "btSalir"
                    Close()
                Case "btAbout"
                    Dim frm As New P_Acerca
                    frm.ShowDialog()
            End Select

        End If
    End Sub


    Private Sub btConfUsuarios_Click(sender As Object, e As EventArgs) Handles btConfUsuarios.Click
        Dim frm As New F0_Usuarios
        frm._nameButton = btConfUsuarios.Name
        frm.Show()
    End Sub

    Private Sub btConfRoles_Click(sender As Object, e As EventArgs) Handles btConfRoles.Click
        Dim frm As New F1_Rol
        frm._nameButton = btConfRoles.Name
        frm.Show()
    End Sub

    Private Sub btRHFeriados_Click(sender As Object, e As EventArgs) Handles btRHFeriados.Click
        Dim frm As New F1_Feriado
        frm._nameButton = btRHFeriados.Name
        frm.Show()
    End Sub

    Private Sub btRHPersonal_Click(sender As Object, e As EventArgs) Handles btRHPersonal.Click
        Dim frm As New F1_Personal
        frm._nameButton = btRHPersonal.Name
        frm.Show()
    End Sub

    Private Sub btEscVehiculo_Click(sender As Object, e As EventArgs) Handles btEscVehiculo.Click
        Dim frm As New F1_Vechiculo
        frm._nameButton = btEscVehiculo.Name
        frm.Show()
    End Sub

    Private Sub btEscAlumnos_Click(sender As Object, e As EventArgs) Handles btEscAlumnos.Click
        Dim frm As New F1_Alumnos
        frm._nameButton = btEscAlumnos.Name
        frm.Show()
    End Sub

    Private Sub btConfServicios_Click(sender As Object, e As EventArgs) Handles btConfServicios.Click
        Dim frm As New F1_Servicio
        frm._nameButton = btConfServicios.Name
        frm.Show()
    End Sub

    Private Sub btEscEquipos_Click(sender As Object, e As EventArgs) Handles btEscEquipos.Click
        Dim frm As New F1_Equipo
        frm._nameButton = btEscEquipos.Name
        frm.Show()
    End Sub

    Private Sub btConfSucursales_Click(sender As Object, e As EventArgs) Handles btConfSucursales.Click
        Dim frm As New F1_Sucursal
        frm._nameButton = btConfSucursales.Name
        frm.Show()
    End Sub

    Private Sub btSocSocio_Click(sender As Object, e As EventArgs) Handles btSocSocio.Click
        Dim frm As New F0_Socio
        frm._nameButton = btSocSocio.Name
        frm.Show()
    End Sub

    Private Sub btSocPagos_Click(sender As Object, e As EventArgs) Handles btSocPagos.Click
        Dim frm As New F0_PagosSocio
        frm._nameButton = btSocPagos.Name
        frm.Show()
    End Sub

    Private Sub btEscClaPracticas_Click(sender As Object, e As EventArgs) Handles btEscClaPracticas.Click
        'Dim frm As New F0_ClasesPracticas2
        Dim frm As New F0_ClasesPracticas3
        frm.Show()
    End Sub

    Private Sub btEscInscripciones_Click(sender As Object, e As EventArgs) Handles btEscInscripciones.Click
        Dim frm As New F1_Inscripcion
        frm._nameButton = btEscInscripciones.Name
        frm.Show()
    End Sub

    Private Sub btConfHorarios_Click(sender As Object, e As EventArgs) Handles btConfHorarios.Click
        Dim frm As New F1_Horarios
        frm._nameButton = btConfHorarios.Name
        frm.Show()
    End Sub

    Private Sub btEscPreExamen_Click(sender As Object, e As EventArgs) Handles btEscPreExamen.Click
        Dim frm As New F0_PreExamen
        frm.Show()
    End Sub

    Private Sub btEscRepPreExamen_Click(sender As Object, e As EventArgs) Handles btEscRepPreExamen.Click
        Dim frm As New PR_PreExamen
        'Dim frm As New F0_BonosDescuentos
        'Dim frm As New F0_DescuentosFijos
        'Dim frm As New F0_Antigue_Vacacion
        'Dim frm As New F0_PedidoVacacion
        frm.Show()
    End Sub

    Private Sub btEscRepEstadosAlumnos_Click(sender As Object, e As EventArgs) Handles btEscRepEstadosAlumnos.Click
        Dim frm As New PR_EstadosAlumnos
        frm.Show()
    End Sub

    Private Sub btSocRepSocio_Click(sender As Object, e As EventArgs) Handles btSocRepSocio.Click
        Dim frm As New PR_Socio
        frm.Show()
    End Sub

    Private Sub btSocRepSocioEdad_Click(sender As Object, e As EventArgs) Handles btSocRepSocioEdad.Click
        Dim frm As New PR_SocioEdad
        frm.Show()
    End Sub

    Private Sub btEscRepAlumnosSinPreExamen_Click(sender As Object, e As EventArgs) Handles btEscRepAlumnosSinPreExamen.Click
        Dim frm As New PR_EstadoAlumnosSinPreExamen
        frm.Show()
        'Dim frm As New F0_ClasesTeoricas
        'frm.Show()
    End Sub

    Private Sub btSocRepSocioPagos_Click(sender As Object, e As EventArgs) Handles btSocRepSocioPagos.Click
        Dim frm As New PR_Pagos
        frm.Show()
    End Sub

    Private Sub btEscClasesTeoricas_Click(sender As Object, e As EventArgs) Handles btEscClasesTeoricas.Click
        Dim frm As New F0_ClasesTeoricas
        frm.Show()
    End Sub

    Private Sub btRHDescFijos_Click(sender As Object, e As EventArgs) Handles btRHDescFijos.Click
        Dim frm As New F0_DescuentosFijos
        frm.Show()
    End Sub

    Private Sub btRHAntigueVacaciones_Click(sender As Object, e As EventArgs) Handles btRHAntigueVacaciones.Click
        Dim frm As New F0_Antigue_Vacacion
        frm.Show()
    End Sub

    Private Sub btRHBonosDesc_Click(sender As Object, e As EventArgs) Handles btRHBonosDesc.Click
        Dim frm As New F0_BonosDescuentos
        frm.Show()
    End Sub

    Private Sub btRHRepPlanillaSueldos_Click(sender As Object, e As EventArgs) Handles btRHRepPlanillaSueldos.Click
        Dim frm As New PR_PlanillaSueldos
        frm.Show()
    End Sub

    Private Sub btRHPedidoVacacion_Click(sender As Object, e As EventArgs) Handles btRHPedidoVacacion.Click
        Dim frm As New F0_PedidoVacacion
        frm.Show()
    End Sub

    Private Sub btCertiAlumnos_Click(sender As Object, e As EventArgs) Handles btCertiAlumnos.Click
        Dim frm As New F1_AlumnosCerti
        frm._nameButton = btCertiAlumnos.Name
        frm.Show()
    End Sub

    Private Sub btCertiAlumTeorico_Click(sender As Object, e As EventArgs) Handles btCertiAlumTeorico.Click
        Dim frm As New F0_ListaExamenTeoricoCerti
        frm.Show()
    End Sub

    Private Sub btCertiAlumPractico_Click(sender As Object, e As EventArgs) Handles btCertiAlumPractico.Click
        Dim frm As New F0_ListaExamenPracticoCerti2
        frm.Show()
    End Sub

    Private Sub btCertiAlumNotasTeorico_Click(sender As Object, e As EventArgs) Handles btCertiAlumNotasTeorico.Click
        Dim frm As New F0_AlumnosCertiNotasTeorico
        frm.Show()
    End Sub

    Private Sub btCertiRepDatosAlum_Click(sender As Object, e As EventArgs) Handles btCertiRepDatosAlum.Click
        Dim frm As New PR_DatosPerPostu
        frm.Show()
    End Sub

    Private Sub btCertiRepAlumAproRepro_Click(sender As Object, e As EventArgs) Handles btCertiRepAlumAproRepro.Click
        Dim frm As New Pr_ListAlumnAprovb
        frm.Show()
    End Sub

    Private Sub btSocRepSocioPagosGral_Click(sender As Object, e As EventArgs) Handles btSocRepSocioPagosGral.Click
        Dim frm As New PR_PagosMora
        frm.Show()
    End Sub

    Private Sub btSocRepSocioPagosMortuoriaGral_Click(sender As Object, e As EventArgs) Handles btSocRepSocioPagosMortuoriaGral.Click
        Dim frm As New PR_PagosMortuorias
        frm.Show()
    End Sub

    Private Sub btCertiPreguntas_Click(sender As Object, e As EventArgs) Handles btCertiPreguntas.Click
        Dim frm As New F1_Preguntas
        frm._nameButton = btCertiPreguntas.Name
        frm.Show()
    End Sub

    Private Sub btCertiCertificacionAlumnos_Click(sender As Object, e As EventArgs) Handles btCertiCertificacionAlumnos.Click
        Dim frm As New F0_CertificacionAlumnos
        frm.Show()
    End Sub

    Private Sub btCertiRepCertiFormularios_Click(sender As Object, e As EventArgs) Handles btCertiRepCertiFormularios.Click
        Dim frm As New PR_CertificadosYFormularios
        frm.Show()
    End Sub

    Private Sub btSocRepSocioListaSociosActivos_Click(sender As Object, e As EventArgs) Handles btSocRepSocioListaSociosActivos.Click
        Dim frm As New PR_SocioListaSociosActivos
        frm.Show()
    End Sub

    Private Sub btLavCliente_Click(sender As Object, e As EventArgs) Handles btLavCliente.Click
        Dim frm As New F1_Cliente_L
        frm._nameButton = btLavCliente.Name
        frm.Show()
    End Sub

    Private Sub btHotCliente_Click(sender As Object, e As EventArgs) Handles btHotCliente.Click
        Dim frm As New F1_CLIENTE_H
        frm._nameButton = btHotCliente.Name
        frm.Show()
    End Sub

    Private Sub btHotCabana_Click(sender As Object, e As EventArgs) Handles btHotCabana.Click
        Dim frm As New F1_CABAÑA
        frm._nameButton = btHotCabana.Name
        frm.Show()
    End Sub

    Private Sub btRemCliente_Click(sender As Object, e As EventArgs) Handles btRemCliente.Click
        Dim frm As New F1_CLIENTE_R
        frm._nameButton = btRemCliente.Name
        frm.Show()
    End Sub

    Private Sub btHotReserva_Click(sender As Object, e As EventArgs) Handles btHotReserva.Click
        Dim frm As New F0_HotelReserva
        frm.Show()
    End Sub

    Private Sub btConfPolitica_Click(sender As Object, e As EventArgs) Handles btConfPolitica.Click
        Dim frm As New F1_POLITICA
        frm._nameButton = btConfPolitica.Name
        frm.Show()
    End Sub

    Private Sub btLavServVenta_Click(sender As Object, e As EventArgs) Handles btLavServVenta.Click
        Dim frm As New F1_ServicioVenta
        frm._nameButton = btLavServVenta.Name
        frm.Show()
    End Sub

    Private Sub btRemServVenta_Click(sender As Object, e As EventArgs) Handles btRemServVenta.Click
        Dim frm As New F1_HojaRutaRemolque
        frm._nameButton = btRemServVenta.Name
        frm.Show()
    End Sub

    Private Sub btRemVehiRemolque_Click(sender As Object, e As EventArgs) Handles btRemVehiRemolque.Click
        Dim frm As New F1_TCGVehiculo
        frm._nameButton = btRemVehiRemolque.Name
        frm.Show()
    End Sub

    Private Sub btLavProducto_Click(sender As Object, e As EventArgs) Handles btLavProducto.Click
        Dim frm As New F1_Productos_L
        frm._nameButton = btLavProducto.Name
        frm.Show()
    End Sub

    Private Sub btLavRHistorialLav_Click(sender As Object, e As EventArgs) Handles btLavRHistorialLav.Click
        Dim frm As New Pr_HistorialSevLav
        frm.Show()
    End Sub

    Private Sub btLavRGeneralServi_Click(sender As Object, e As EventArgs) Handles btLavRGeneralServi.Click
        Dim frm As New Pr_LavaderoGeneralServicios
        frm.Show()
    End Sub

    Private Sub btLavRServLav_Click(sender As Object, e As EventArgs) Handles btLavRServLav.Click
        Dim frm As New Pr_ServLavaderoGeneral
        frm.Show()
    End Sub

    Private Sub btLavMovimiento_Click(sender As Object, e As EventArgs) Handles btLavMovimiento.Click
        Dim form As New F0_Movimiento
        form.pTitulo = "M O V I M I E N T O   D E   P R O D U C T O S"
        form.pTipo = 2
        form.Show()
    End Sub

    Private Sub btLavKardexInventarioProducto_Click(sender As Object, e As EventArgs) Handles btLavKardexInventarioProducto.Click
        Dim form As New F0_KardexInventario
        form.pTitulo = "K A R D E X   D E   P R O D U C T O S"
        form.pTipo = 2
        form.Show()
    End Sub

    Private Sub btLavRSaldoInventarioProducto_Click(sender As Object, e As EventArgs) Handles btLavRSaldoInventarioProducto.Click
        Dim form As New PR_StockActualEquipoProducto
        form.pTitulo = "S A L D O   A C T U A L   D E   P R O D U C T O S"
        form.pTipo = 2
        form.Show()
    End Sub

    Private Sub btEscRepCronoClasesPrac_Click(sender As Object, e As EventArgs) Handles btEscRepCronoClasesPrac.Click
        Dim frm As New PR_CronoClasesPracticas
        frm.Show()
    End Sub

    Private Sub btCertiCertificacionPerfecc_Click(sender As Object, e As EventArgs) Handles btCertiCertificacionPerfecc.Click
        Dim frm1 As New F0_CertificacionReforzamiento
        frm1.Show()
    End Sub

    Private Sub btRHMarcaciones_Click(sender As Object, e As EventArgs) Handles btRHMarcaciones.Click
        Dim frm1 As New F0_Asistencia
        frm1.Show()
    End Sub

    Private Sub btCertiRepCronoPerfeccion_Click(sender As Object, e As EventArgs) Handles btCertiRepCronoPerfeccion.Click
        Dim frm As New PR_CronoClasesPerfeccionamiento
        frm.Show()
    End Sub

    Private Sub btLavCompraProductos_Click(sender As Object, e As EventArgs) Handles btLavCompraProductos.Click
        Dim frm As New F1_CompraLavadero
        frm._nameButton = btLavCompraProductos.Name
        frm.Show()
    End Sub

    Private Sub MetroTileItem27_Click(sender As Object, e As EventArgs) Handles btRemRpHistorialCliente.Click
        Dim frm As New Pr_HistorialRemolqueCliente

        frm.Show()
    End Sub

    Private Sub btRemRpServGeneral_Click(sender As Object, e As EventArgs) Handles btRemRpServGeneral.Click
        Dim frm As New Pr_RemolqueServiciosGeneral
        frm.Show()
    End Sub

   

    Private Sub btRemRpServDetalle_Click_1(sender As Object, e As EventArgs) Handles btRemRpServDetalle.Click
        Dim frm As New Pr_ServRemolqueDetallado
        frm.Show()
    End Sub

    Private Sub btReportePolitica_Click(sender As Object, e As EventArgs) Handles btReportePolitica.Click
        Dim frm As New Pr_HistorialDeDescuentosLavadero
        frm.Show()
    End Sub
    Private Sub btRHTurnos_Click(sender As Object, e As EventArgs) Handles btRHTurnos.Click
        Dim frm As New F0_Turnos
        'frm._nameButton = btLavCompraProductos.Name
        frm.Show()
    End Sub

    Private Sub btRHPlanillaTurnos_Click(sender As Object, e As EventArgs) Handles btRHPlanillaTurnos.Click
        Dim frm As New F0_PlanillaTurnos
        'frm._nameButton = btLavCompraProductos.Name
        frm.Show()
    End Sub


    Private Sub btRHRepAsistencia_Click(sender As Object, e As EventArgs) Handles btRHRepAsistencia.Click
        Dim frm As New PR_Asistencia
        frm.Show()
    End Sub

    Private Sub btRHMarcacionCorr_Click(sender As Object, e As EventArgs) Handles btRHMarcacionCorr.Click
        Dim frm As New F0_MarcadoCorreccion
        frm.Show()
    End Sub

    Private Sub btRHRepPlanillaMensual_Click(sender As Object, e As EventArgs) Handles btRHRepPlanillaMensual.Click
        Dim frm As New PR_PlanillaMensualMarcacion
        frm.Show()
    End Sub

    Private Sub btCertiRepAlumEscAprob_Click(sender As Object, e As EventArgs) Handles btCertiRepAlumEscAprob.Click
        Dim frm As New PR_CertiAlumnosEscAprobados
        frm.Show()
    End Sub

    Private Sub btEscRepHorasTrabajadas_Click(sender As Object, e As EventArgs) Handles btEscRepHorasTrabajadas.Click
        'Dim frm As New PR_EscuelaHorasTrabajadasInst
        'frm.Show()
        Dim frm As New PR_EscuelaHorasTrabajadasExtrasInst
        frm.Show()
    End Sub

    Private Sub btSocRepSocioListarSocioPaganMortuoria_Click(sender As Object, e As EventArgs) Handles btSocRepSocioListarSocioPaganMortuoria.Click
        Dim frm As New PR_ListarSocioPaganMortuoria
        frm.Show()
    End Sub

    Private Sub btHotResumenRes_Click(sender As Object, e As EventArgs) Handles btHotResumenRes.Click
        Dim frm As New PR_HotelResumenReservas
        frm.Show()
    End Sub

    Private Sub btEscRepEscCertificado_Click(sender As Object, e As EventArgs) Handles btEscRepEscCertificado.Click
        Dim frm As New PR_EscuelaCertificado
        frm.Show()
    End Sub

    Private Sub MetroTileItem1_Click(sender As Object, e As EventArgs) Handles btRecepcionLavadero.Click
        Dim frm As New F0_RecepcionLavadero
        frm.Show()
    End Sub

    Private Sub btsalidaProductoAcb_Click(sender As Object, e As EventArgs) Handles btsalidaProductoAcb.Click
        Dim frm As New PR_AcbSalidaProducto
        frm.Show()
    End Sub

    Private Sub btCertiRepAlumFiltrados_Click(sender As Object, e As EventArgs) Handles btCertiRepAlumFiltrados.Click
        Dim frm As New PR_CertiAlumnosFiltrado
        frm.Show()
    End Sub

    Private Sub MetroTileItem1_Click_1(sender As Object, e As EventArgs) Handles btEscIntercambio.Click
        Dim frm As New F0_CambioChofer
        frm.Show()
    End Sub

    Private Sub SideNav1_SelectedItemChanged(sender As Object, e As EventArgs) Handles SideNav1.SelectedItemChanged

    End Sub

    Private Sub SideNav1_TabIndexChanged(sender As Object, e As EventArgs) Handles SideNav1.TabIndexChanged

    End Sub

    Private Sub FP_Configuracion_Click(sender As Object, e As EventArgs) Handles FP_Configuracion.Click, FP_Certificacion.Click, FP_Escuela.Click, FP_Hotel.Click, FP_Lavadero.Click, FP_RecHumanos.Click, FP_Remolque.Click, FP_Socios.Click
        Dim moduloItem As SideNavItem = CType(sender, SideNavItem)
        Dim myVersion As Version = CType(moduloItem.Tag, Version)

        Dim dtModulo As DataTable = L_prModulosAll(myVersion.numiModulo)
        If dtModulo.Rows.Count > 0 Then
            If dtModulo.Rows(0).Item("yfver").trim.ToString.ToUpper <> myVersion.version.ToUpper Then '_version.Trim.ToUpper
                Dim info As New TaskDialogInfo("advertencia".ToUpper, eTaskDialogIcon.Exclamation, "modulo de sistema desactualizado".ToUpper, "no cuenta con la ultima version del sistema para este modulo.".ToUpper + vbCrLf + "ultima version: ".ToUpper + dtModulo.Rows(0).Item("yfver").trim.ToString.ToUpper + vbCrLf + "Por favor contactar al encargado de sistemas.".ToUpper, eTaskDialogButton.Yes, eTaskDialogBackgroundColor.Blue)
                Dim result As eTaskDialogResult = TaskDialog.Show(info)
            End If
        End If
    End Sub

    Private Sub btconfbanco_Click(sender As Object, e As EventArgs) Handles btconfbanco.Click
        Dim frm As New F1_Bancos
        frm.Show()
    End Sub

    Private Sub btconfReportServicios_Click(sender As Object, e As EventArgs) Handles btconfReportServicios.Click
        Dim frm As New Pr_ServiciosLavadero
        frm.Show()
    End Sub
End Class