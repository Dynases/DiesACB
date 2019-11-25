Imports Logica.AccesoLogica
Imports Janus.Windows.GridEX.EditControls

Module P_Global
    Public gs_RutaImagenes As String = "C:\Imagenes"
    Public gs_RutaArchivos As String = "C:\Doc"
    'Variables del archivo de configuración
    Public gs_Ip As String = "localhost" ''192.168.0.28
    Public gs_UsuarioSql As String = "sa"
    Public gs_ClaveSql As String = "123"
    Public gs_NombreBD As String = "DBDies"
    Public gs_CarpetaRaiz As String = "C:\BD"  ''''\\192.168.0.28\BD
    Private Declare Auto Function SetProcessWorkingSetSize Lib "kernel32.dll" (ByVal procHandle As IntPtr, ByVal min As Int32, ByVal max As Int32) As Boolean


#Region "Variables"

    Public gc_SeparadorDecimal As Char = Application.CurrentCulture.NumberFormat.NumberDecimalSeparator
    Public Visualizador As Visualizador
    Public gi_IVA As Decimal = 13 'Valor por defecto 13 = IVA actual Bolivia 2016
#End Region

#Region "Librerias"

    'LIBRERIAS MARCO
    Public gi_LibServLav As Integer = 3
    Public gi_LibServRem As Integer = 4
    ''''Sucursal 
    Public gi_userSucTGVehiculo As Integer = 1


    Public gi_LibVEHICULO As Integer = 1
    Public gi_LibVEHIMarca As Integer = 1
    Public gi_LibVEHIModelo As Integer = 2
    Public gi_LibVEHITipo As Integer = 3
    Public gi_LibVEHITam As Integer = 4
    'Public gi_LibVEHITIPOEnsenansa As Integer = 1 'vehiculo de enseñanza

    Public gi_LibPERSONAL As Integer = 2
    Public gi_LibPERSTipo As Integer = 1
    Public gi_LibPERSEstCivil As Integer = 2
    Public gi_LibPERSTIPOInstructor As Integer = 1
    Public gi_LibPERSTIPOInstPerfeccionamiento As Integer = 4

    Public gi_LibALUMNO As Integer = 3
    Public gi_LibALUMTipo As Integer = 1
    Public gi_LibALUMEstCivil As Integer = 2
    Public gi_LibALUMProfesion As Integer = 3
    Public gi_LibALUMParentesco As Integer = 4
    Public gi_LibALUMNacionalidad As Integer = 5

    Public gi_LibSistema As Integer = 4
    Public gi_LibSISModulo As Integer = 1

    'Form Socio
    Public gi_LibSOCIO As Integer = 7
    Public gi_LibSOCTipo As Integer = 1

    Public gi_LibTELEFONO As Integer = 8
    Public gi_LibTELTipo As Integer = 1

    Public gi_LibDEPARTAMENTO As Integer = 9
    Public gi_LibDEPCuidad As Integer = 1


    Public gi_LibEquipo As Integer = 5
    Public gi_LibEQUITipo As Integer = 1

    Public gi_LibServicio As Integer = 6
    Public gi_LibSERVTipo As Integer = 1

    Public gi_LibSERVTipoCuotaSocio As Integer = 2

    'alumnos certificacion
    Public gi_LibALUMCERTI As Integer = 10
    Public gi_LibALUMCERTICategLic As Integer = 1

    'remolque cliente
    Public gi_LibREMOLQUE As Integer = 11
    Public gi_LibREMOLQUECliente As Integer = 1

    'hotel cabaña
    Public gi_LibCABANA As Integer = 12
    Public gi_LibCABANAHotel As Integer = 1
    Public gi_LibCABANAPrecio As Integer = 2

    'hotel cabaña
    Public gi_LibHOTEL As Integer = 13
    Public gi_LibHOTELCliente As Integer = 1

    'hotel cabaña
    Public gi_LibLAVADERO As Integer = 14
    Public gi_LibLAVADEROClie As Integer = 1

    'lib HORARIO
    Public gi_LibHORARIO As Integer = 17
    Public gi_LibHORARIOTipo As Integer = 1
    Public gi_LibHORARIOTipoPractEscuela As Integer = 1
    Public gi_LibHORARIOTipoReforCertificacion As Integer = 2

    'lib Tipo PERFECCIONAMIENTO
    Public gi_LibPERFECC As Integer = 18
    Public gi_LibPERFECCTipoClase As Integer = 1
    

#End Region

#Region "Metodos"

    'Tipos de Modos
    '1 Valida que sea solo Numeros
    '2 Valida que sea solo Letras
    '3 Valida que sea Numeros y el Separador de Decimales
    '4 Valida que sea Numeros y el guion (-)
    Public Sub g_prValidarTextBox(ByVal _Modo As Byte, ByRef ee As KeyPressEventArgs)
        Select Case _Modo
            Case 1
                If (Char.IsNumber(ee.KeyChar)) Then
                    ee.Handled = False
                    'ElseIf (Char.IsControl(ee.KeyChar)) Then
                    '    ee.Handled = False
                    'ElseIf (Char.IsPunctuation(ee.KeyChar)) Then
                    '    ee.Handled = False
                ElseIf (ChrW(Keys.Back) = (ee.KeyChar)) Then
                    ee.Handled = False
                ElseIf (ChrW(Keys.Delete) = (ee.KeyChar)) Then
                    ee.Handled = False
                Else
                    ee.Handled = True
                End If
            Case 2
                If (Char.IsLetter(ee.KeyChar)) Then
                    ee.Handled = False
                ElseIf (Char.IsControl(ee.KeyChar)) Then
                    ee.Handled = False
                Else
                    ee.Handled = True
                End If
            Case 3
                If (Char.IsNumber(ee.KeyChar)) Then
                    ee.Handled = False
                ElseIf (ee.KeyChar.Equals(gc_SeparadorDecimal)) Then
                    ee.Handled = False
                ElseIf (ChrW(Keys.Back) = (ee.KeyChar)) Then
                    ee.Handled = False
                ElseIf (ChrW(Keys.Delete) = (ee.KeyChar)) Then
                    ee.Handled = False
                Else
                    ee.Handled = True
                End If
            Case 4
                If (Char.IsNumber(ee.KeyChar)) Then
                    ee.Handled = False
                ElseIf (ee.KeyChar.Equals(Convert.ToChar("-"))) Then
                    ee.Handled = False
                ElseIf (Char.IsControl(ee.KeyChar)) Then
                    ee.Handled = False
                Else
                    ee.Handled = True
                End If
            Case 5
                If (Char.IsNumber(ee.KeyChar)) Then
                    ee.Handled = False
                ElseIf (ee.KeyChar.Equals(gc_SeparadorDecimal)) Then
                    ee.Handled = False
                ElseIf (ee.KeyChar.Equals(Convert.ToChar("-"))) Then
                    ee.Handled = False
                ElseIf (Char.IsControl(ee.KeyChar)) Then
                    ee.Handled = False
                Else
                    ee.Handled = True
                End If
        End Select
    End Sub

    Public Sub _prCargarComboLibreria(mCombo As Janus.Windows.GridEX.EditControls.MultiColumnCombo, cod1 As String, cod2 As String)
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

    Public Sub g_prArmarCombo(cbj As MultiColumnCombo, dtCombo As DataTable,
                              Optional anchoCodigo As Integer = 60, Optional anchoDesc As Integer = 200,
                              Optional nombreCodigo As String = "Código", Optional nombreDescripción As String = "Nombre")
        With cbj.DropDownList
            .Columns.Clear()

            .Columns.Add(dtCombo.Columns("cod").ToString).Width = anchoCodigo
            .Columns(0).Caption = nombreCodigo
            .Columns(0).Visible = True

            .Columns.Add(dtCombo.Columns("desc").ToString).Width = anchoDesc
            .Columns(1).Caption = nombreDescripción
            .Columns(1).Visible = True

            .ValueMember = dtCombo.Columns("cod").ToString
            .DisplayMember = dtCombo.Columns("desc").ToString
            .DataSource = dtCombo
            .Refresh()
        End With
    End Sub

    'Public Sub G_ActStock(_Tabla As DataTable, _Signo As Boolean) 'True=Signo (+), False=Signo(-)
    '    For Each _fila As DataRow In _Tabla.Rows
    '        Dim codC As String = _fila.Item("codC").ToString
    '        Dim mon As String = IIf(_Signo, "", "-") + _fila.Item("mon").ToString
    '        L_Actualizar_Saldo(codC, mon)
    '    Next
    'End Sub

    Public Sub g_prActualizarStock(_Tabla As DataTable, _Signo As Boolean, _almacen As String) 'True=Signo (+), False=Signo(-)
        For Each _fila As DataRow In _Tabla.Rows
            Dim codP As String = _fila.Item("codP").ToString
            Dim cant As String = IIf(_Signo, "", "-") + _fila.Item("can").ToString
            L_Actualizar_StockMovimiento(codP, cant, _almacen)
        Next
    End Sub

#End Region

#Region "Configuracion del sistema"
    Public gs_llaveDinases As String = "carlosdinases123"
    Public gb_mostrarMapa As Boolean = True
    Public gi_userFuente As Integer = 8
    Public gs_user As String = "DEFAULT"
    Public gi_userNumi As Integer = 0
    Public gi_userRol As Integer = 0
    Public gi_userSuc As Integer = 0
    Public gb_userTodasSuc As Boolean = False

    'configuracion del sistema tabla TCG011
    Public gd_notaAproTeo As Double = 0
    Public gd_notaAproTeoH As Double = 0
    Public gd_notaAproPrac As Double = 0
    Public gi_nroMaxAlumTeo As Integer = 0
    Public gi_cumpleInstructor As Integer = 0

    'variables para desarrollo/puesta en marcha
    Public gb_ConexionAbierta As Boolean = False

#End Region

#Region "Imagenes Reportes Categorias"
    
    Public Function G_getImgCategoria(cat As String) As String
        Select Case cat
            Case "A" : Return gs_CarpetaRaiz + "\Imagenes Categorias\" + "categoria_A.png"
            Case "B" : Return gs_CarpetaRaiz + "\Imagenes Categorias\" + "categoria_B.png"
            Case "C" : Return gs_CarpetaRaiz + "\Imagenes Categorias\" + "categoria_C.png"
            Case "P" : Return gs_CarpetaRaiz + "\Imagenes Categorias\" + "categoria_P.png"
            Case "M" : Return gs_CarpetaRaiz + "\Imagenes Categorias\" + "categoria_M.png"
            Case "H" : Return gs_CarpetaRaiz + "\Imagenes Categorias\" + "categoria_H.png"
        End Select
        Return ""
    End Function
#End Region

#Region "TOAST"
    Public Function getMensaje(mensaje As String, Optional tam As String = "6") As String
        Dim menFinal As String = "<b><font size=" + Chr(34) + "+" + tam + Chr(34) + "><font color=" + Chr(34) + "#FF0000" + Chr(34) + "></font>" + mensaje + "</font></b>"
        Return menFinal
    End Function
#End Region

#Region "MEMORIA"
    Public Sub G_LiberarMemoria()
        Try
            Dim memoria As Process
            memoria = Process.GetCurrentProcess()
            SetProcessWorkingSetSize(memoria.Handle, -1, -1)
        Catch ex As Exception

        End Try
    End Sub
#End Region

End Module
