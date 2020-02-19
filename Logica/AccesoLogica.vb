Option Strict Off
Imports System.Data
Imports System.Data.SqlClient

Imports Datos.AccesoDatos


Public Class AccesoLogica

    Public Shared L_Usuario As String = "DEFAULT"
    Public Shared L_nroErrorLlaveForanea As Integer = 547

#Region "METODOS PRIVADOS"
    Public Shared Sub L_prAbrirConexion(Optional Ip As String = "", Optional UsuarioSql As String = "", Optional ClaveSql As String = "", Optional NombreBD As String = "")
        D_abrirConexion(Ip, UsuarioSql, ClaveSql, NombreBD)
    End Sub
    Public Shared Sub L_prAbrirConexionBitacora(Optional Ip As String = "", Optional UsuarioSql As String = "", Optional ClaveSql As String = "", Optional NombreBD As String = "")
        D_abrirConexionHistorial(Ip, UsuarioSql, ClaveSql, NombreBD)
    End Sub

    Public Shared Function _fnsAuditoria() As String
        Return "'" + Date.Now.Date.ToString("yyyy/MM/dd") + "', '" + Now.Hour.ToString("00") + ":" + Now.Minute.ToString("00") + "' ,'" + L_Usuario + "'"
    End Function

#End Region

#Region "METODOS Y FUNCIONES AYUDAS"

    Public Shared Function L_fnObtenerDato(nombreCampo As String, nombreTabla As String, where As String) As String
        Dim _Tabla As DataTable
        _Tabla = D_Datos_Tabla(nombreCampo, nombreTabla, where)
        If (_Tabla.Rows.Count = 0) Then
            Return "0"
        Else
            Return _Tabla(0).Item(nombreCampo).ToString
        End If
    End Function

    Public Shared Function L_fnObtenerTabla(nombreCampos As String, nombreTabla As String, where As String) As DataTable
        Dim Tabla As DataTable
        Tabla = D_Datos_Tabla(nombreCampos, nombreTabla, where)
        Return Tabla
    End Function

#End Region

#Region "LIBRERIAS"
    Public Shared gi_libMaquinaria As Integer = 1
    Public Shared gi_maqGrupo As Integer = 1
    Public Shared gi_maqSubGrupo As Integer = 2
    Public Shared gi_maqSubSubGrupo As Integer = 3
    Public Shared gi_maqTipoControlMedicion As Integer = 4

    Public Shared gi_libChofer As Integer = 2
    Public Shared gi_chTipoChofer As Integer = 1

    Public Shared gi_libArticulo As Integer = 3
    Public Shared gi_artTipoArticulo1 As Integer = 1
    Public Shared gi_artTipoArticulo2 As Integer = 2
    Public Shared gi_artTipoArticulo3 As Integer = 3

    Public Shared gi_libModulos As Integer = 4
    Public Shared gi_libMTipoModulo As Integer = 1

    Public Shared Function L_General_LibreriaDetalle1(_Modo As Integer, Optional _Cadena As String = "") As DataSet
        Dim _Tabla As DataTable
        Dim _Ds As New DataSet
        Dim _Where As String
        If _Modo = 0 Then
            _Where = " TC0051.cecon = TC0051.cecon"
        Else
            _Where = "TC0051.cecon = " + _Cadena + " AND " + _
                     "TC005.cdcon=TC0051.cecon"
        End If
        _Tabla = D_Datos_Tabla("TC0051.ceid,TC0051.cecon,TC0051.cenum,TC0051.cedesc", "TC005,TC0051", _Where + " order by TC0051.cenum")
        _Ds.Tables.Add(_Tabla)
        Return _Ds
    End Function

    Public Shared Function L_LibreriaGeneral(_cod1 As String, _cod2 As String) As DataTable
        Dim _Tabla As DataTable
        Dim _Where As String
        _Where = "cecod1=" + _cod1 + " and cecod2=" + _cod2
        _Tabla = D_Datos_Tabla("cenum, cedesc1", "TC0051", _Where + " order by cenum")
        Return _Tabla
    End Function


    Public Shared Function L_prLibreriaDetalleGeneral(_cod1 As String, _cod2 As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 3))
        _listParam.Add(New Datos.DParametro("@cecod1", _cod1))
        _listParam.Add(New Datos.DParametro("@cecod2", _cod2))
        _listParam.Add(New Datos.DParametro("@ceuact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("pa_TC0051", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prLibreriaDetalleGetNum(_cod1 As String, _cod2 As String, _desc1 As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 4))
        _listParam.Add(New Datos.DParametro("@cecod1", _cod1))
        _listParam.Add(New Datos.DParametro("@cecod2", _cod2))
        _listParam.Add(New Datos.DParametro("@cedesc1", _desc1))
        _listParam.Add(New Datos.DParametro("@ceuact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("pa_TC0051", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prLibreriaGrabar(ByRef _numi As String, _cod1 As String, _cod2 As String, _desc1 As String, _desc2 As String) As Boolean
        Dim _Error As Boolean

        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 1))
        _listParam.Add(New Datos.DParametro("@cecod1", _cod1))
        _listParam.Add(New Datos.DParametro("@cecod2", _cod2))
        _listParam.Add(New Datos.DParametro("@cedesc1", _desc1))
        _listParam.Add(New Datos.DParametro("@cedesc2", _desc2))
        _listParam.Add(New Datos.DParametro("@ceuact", 1))

        _Tabla = D_ProcedimientoConParam("pa_TC0051", _listParam)

        If _Tabla.Rows.Count > 0 Then
            _numi = _Tabla.Rows(0).Item(0)
            _Error = False
        Else
            _Error = True
        End If
        Return Not _Error
    End Function
#End Region

#Region "VALIDAR ELIMINACION"
    Public Shared Function L_fnbValidarEliminacion(_numi As String, _tablaOri As String, _campoOri As String, ByRef _respuesta As String) As Boolean
        Dim _Tabla As DataTable
        Dim _Where, _campos As String
        _Where = "bbtori='" + _tablaOri + "' and bbtran=1"
        _campos = "bbnumi,bbtran,bbtori,bbcori,bbtdes,bbcdes,bbprog"
        _Tabla = D_Datos_Tabla(_campos, "TB002", _Where)
        _respuesta = "no se puede eliminar el registro: ".ToUpper + _numi + " por que esta siendo usado en los siguientes programas: ".ToUpper + vbCrLf

        Dim result As Boolean = True
        For Each fila As DataRow In _Tabla.Rows
            If L_fnbExisteRegEnTabla(_numi, fila.Item("bbtdes").ToString, fila.Item("bbcdes").ToString) = True Then
                _respuesta = _respuesta + fila.Item("bbprog").ToString + vbCrLf
                result = False
            End If
        Next
        Return result
    End Function

    Private Shared Function L_fnbExisteRegEnTabla(_numiOri As String, _tablaDest As String, _campoDest As String) As Boolean
        Dim _Tabla As DataTable
        Dim _Where, _campos As String
        _Where = _campoDest + "=" + _numiOri
        _campos = _campoDest
        _Tabla = D_Datos_Tabla(_campos, _tablaDest, _Where)
        If _Tabla.Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
#End Region

#Region "METODOS PARA EL CONTROL DE USUARIOS Y PRIVILEGIOS"

#Region "Formularios"
    Public Shared Function L_Formulario_General(_Modo As Integer, Optional _Cadena As String = "") As DataSet
        Dim _Tabla As DataTable
        Dim _Ds As New DataSet
        Dim _Where As String
        If _Modo = 0 Then
            _Where = "ZY001.yanumi=ZY001.yanumi and ZY001.yamod=TC0051.cenum and cecod1=4 AND cecod2=1 "
        Else
            _Where = "ZY001.yanumi=ZY001.yanumi and ZY001.yamod=TC0051.cenum and cecod1=4 AND cecod2=1 " + _Cadena
        End If
        _Tabla = D_Datos_Tabla("ZY001.yanumi,ZY001.yaprog,ZY001.yatit,ZY001.yamod,TC0051.cedesc1", "ZY001,TC0051", _Where + " order by yanumi")
        _Ds.Tables.Add(_Tabla)
        Return _Ds
    End Function

    Public Shared Sub L_Formulario_Grabar(ByRef _numi As String, _desc As String, _direc As String, _categ As String)
        Dim _Err As Boolean
        Dim _Tabla As DataTable
        _Tabla = D_Maximo("ZY001", "yanumi", "yanumi=yanumi")
        If Not IsDBNull(_Tabla.Rows(0).Item(0)) Then
            _numi = _Tabla.Rows(0).Item(0) + 1
        Else
            _numi = "1"
        End If

        Dim Sql As String
        Sql = _numi + ",'" + _desc + "','" + _direc + "'," + _categ
        _Err = D_Insertar_Datos("ZY001", Sql)
    End Sub

    Public Shared Sub L_Formulario_Modificar(_numi As String, _desc As String, _direc As String, _categ As String)
        Dim _Err As Boolean
        Dim Sql, _where As String

        Sql = "yaprog = '" + _desc + "' , " + _
        "yatit = '" + _direc + "' , " + _
        "yamod = " + _categ

        _where = "yanumi = " + _numi
        _Err = D_Modificar_Datos("ZY001", Sql, _where)
    End Sub

    Public Shared Sub L_Formulario_Borrar(_Id As String)
        Dim _Where As String
        Dim _Err As Boolean
        _Where = "yanumi = " + _Id
        _Err = D_Eliminar_Datos("ZY001", _Where)
    End Sub
#End Region

#Region "Roles"
    Public Shared Function L_Rol_General(_Modo As Integer, Optional _Cadena As String = "") As DataSet
        Dim _Tabla As DataTable
        Dim _Ds As New DataSet
        Dim _Where As String
        If _Modo = 0 Then
            _Where = "ZY002.ybnumi=ZY002.ybnumi "
        Else
            _Where = "ZY002.ybnumi=ZY002.ybnumi " + _Cadena
        End If
        _Tabla = D_Datos_Tabla("ZY002.ybnumi,ZY002.ybrol", "ZY002", _Where + " order by ybnumi")
        _Ds.Tables.Add(_Tabla)
        Return _Ds
    End Function
    Public Shared Function L_RolDetalle_General(_Modo As Integer, Optional _idCabecera As String = "", Optional _idModulo As String = "") As DataTable
        Dim _Tabla As DataTable
        Dim _Where As String
        If _Modo = 0 Then
            _Where = " ycnumi = ycnumi"
        Else
            _Where = " ycnumi=" + _idCabecera + " and ZY001.yamod=" + _idModulo + " and ZY0021.ycyanumi=ZY001.yanumi"
        End If
        _Tabla = D_Datos_Tabla("ZY0021.ycnumi,ZY0021.ycyanumi,ZY0021.ycshow,ZY0021.ycadd,ZY0021.ycmod,ZY0021.ycdel,ZY001.yaprog,ZY001.yatit", "ZY0021,ZY001", _Where)
        Return _Tabla
    End Function

    Public Shared Function L_RolDetalle_General2(_Modo As Integer, Optional _idCabecera As String = "", Optional _where1 As String = "") As DataTable
        Dim _Tabla As DataTable
        Dim _Where As String
        If _Modo = 0 Then
            _Where = " ycnumi = ycnumi"
        Else
            _Where = " ycnumi=" + _idCabecera + " and " + _where1
        End If
        _Tabla = D_Datos_Tabla("ycnumi,ycyanumi,ycshow,ycadd,ycmod,ycdel", "ZY0021", _Where)
        Return _Tabla
    End Function

    Public Shared Function L_prRolDetalleGeneral(_numiRol As String, _idNombreButton As String) As DataTable
        Dim _Tabla As DataTable
        Dim _Where As String

        _Where = "ZY0021.ycnumi=" + _numiRol + " and ZY0021.ycyanumi=ZY001.yanumi and ZY001.yaprog='" + _idNombreButton + "'"

        _Tabla = D_Datos_Tabla("ycnumi,ycyanumi,ycshow,ycadd,ycmod,ycdel", "ZY0021,ZY001", _Where)
        Return _Tabla
    End Function
    Public Shared Sub L_GrabarSociosPrueba(ByRef Nsoc As Integer, nombre As String)
       
        Dim _Err As Boolean
        Dim Sql As String
        Sql = Str(Nsoc).Trim + ",'" + nombre + "'"
        _Err = D_Insertar_Datos("TCL008", Sql)
    End Sub
    Public Shared Sub L_Rol_Grabar(ByRef _numi As String, _rol As String)
        Dim _Actualizacion As String
        Dim _Err As Boolean
        Dim _Tabla As DataTable
        _Tabla = D_Maximo("ZY002", "ybnumi", "ybnumi=ybnumi")
        If Not IsDBNull(_Tabla.Rows(0).Item(0)) Then
            _numi = _Tabla.Rows(0).Item(0) + 1
        Else
            _numi = "1"
        End If

        _Actualizacion = "'" + Date.Now.Date.ToString("yyyy/MM/dd") + "', '" + Now.Hour.ToString + ":" + Now.Minute.ToString + "' ,'" + L_Usuario + "'"

        Dim Sql As String
        Sql = _numi + ",'" + _rol + "'," + _Actualizacion
        _Err = D_Insertar_Datos("ZY002", Sql)
    End Sub
    Public Shared Sub L_RolDetalle_Grabar(_idCabecera As String, _numi1 As Integer, _show As Boolean, _add As Boolean, _mod As Boolean, _del As Boolean)
        Dim _Err As Boolean
        Dim Sql As String
        Sql = _idCabecera & "," & _numi1 & ",'" & _show & "','" & _add & "','" & _mod & "','" & _del & "'"
        _Err = D_Insertar_Datos("ZY0021", Sql)
    End Sub
    Public Shared Sub L_Rol_Modificar(_numi As String, _desc As String)
        Dim _Err As Boolean
        Dim Sql, _where As String

        Sql = "ybrol = '" + _desc + "' "

        _where = "ybnumi = " + _numi
        _Err = D_Modificar_Datos("ZY002", Sql, _where)
    End Sub
    Public Shared Sub L_Rol_Borrar(_Id As String)
        Dim _Where As String
        Dim _Err As Boolean
        _Where = "ybnumi = " + _Id
        _Err = D_Eliminar_Datos("ZY002", _Where)
    End Sub
    Public Shared Sub L_RolDetalle_Modificar(_idCabecera As String, _numi1 As Integer, _show As Boolean, _add As Boolean, _mod As Boolean, _del As Boolean)
        Dim _Err As Boolean
        Dim Sql, _where As String

        Sql = "ycshow = '" & _show & "' , " & "ycadd = '" & _add & "' , " & "ycmod = '" & _mod & "' , " & "ycdel = '" & _del & "' "

        _where = "ycnumi = " & _idCabecera & " and ycyanumi = " & _numi1
        _Err = D_Modificar_Datos("ZY0021", Sql, _where)
    End Sub
    Public Shared Sub L_RolDetalle_Borrar(_Id As String, _Id1 As String)
        Dim _Where As String
        Dim _Err As Boolean

        _Where = "ycnumi = " + _Id + " and ycyanumi = " + _Id1
        _Err = D_Eliminar_Datos("ZY0021", _Where)
    End Sub
    Public Shared Sub L_RolDetalle_Borrar(_Id As String)
        Dim _Where As String
        Dim _Err As Boolean

        _Where = "ycnumi = " + _Id
        _Err = D_Eliminar_Datos("ZY0021", _Where)
    End Sub
#End Region

#Region "Usuarios"
    Public Shared Function L_Usuario_General(_Modo As Integer, Optional _Cadena As String = "") As DataSet
        Dim _Tabla As DataTable
        Dim _Ds As New DataSet
        Dim _Where As String
        If _Modo = 0 Then
            _Where = "ZY003.ydnumi=ZY003.ydnumi and ZY002.ybnumi=ZY003.ydrol "
        Else
            _Where = "ZY003.ydnumi=ZY003.ydnumi and ZY002.ybnumi=ZY003.ydrol " + _Cadena
        End If
        _Tabla = D_Datos_Tabla("ZY003.ydnumi,ZY003.yduser,ZY003.ydpass,ZY003.ydest,ZY003.ydcant,ZY002.ybnumi,ZY002.ybrol", "ZY003,ZY002", _Where + " order by ydnumi")
        _Ds.Tables.Add(_Tabla)
        Return _Ds
    End Function


    Public Shared Function L_Usuario_General2(_Modo As Integer, Optional _Cadena As String = "") As DataSet
        Dim _Tabla As DataTable
        Dim _Ds As New DataSet
        Dim _Where As String
        If _Modo = 0 Then
            _Where = "ZY003.ydnumi=ZY003.ydnumi and ZY002.ybnumi=ZY003.ydrol and TC001.canumi=ZY003.ydsuc "
        Else
            _Where = "ZY003.ydnumi=ZY003.ydnumi and ZY002.ybnumi=ZY003.ydrol and TC001.canumi=ZY003.ydsuc " + _Cadena
        End If
        _Tabla = D_Datos_Tabla("ZY003.ydnumi,ZY003.yduser,ZY003.ydpass,ZY003.ydest,ZY003.ydcant,ZY003.ydfontsize,ZY002.ybnumi,ZY002.ybrol,ZY003.ydsuc,ZY003.ydall,TC001.cadesc", "ZY003,ZY002,TC001", _Where + " order by ydnumi")
        _Ds.Tables.Add(_Tabla)
        Return _Ds
    End Function

    Public Shared Function L_Usuario_General3(_Modo As Integer, Optional _Cadena As String = "") As DataSet
        Dim _Tabla As DataTable
        Dim _Ds As New DataSet
        Dim _Where As String
        If _Modo = 0 Then
            _Where = "1=1"
        Else
            _Where = _Cadena
        End If
        _Tabla = D_Datos_Tabla("ZY003.ydnumi,ZY003.yduser", "ZY003", _Where + " order by yduser")
        _Ds.Tables.Add(_Tabla)
        Return _Ds
    End Function
    Public Shared Sub L_Usuario_Grabar(ByRef _numi As String, _user As String, _pass As String, _rol As String, _estado As String, _cantDias As String, _tamFuente As String, _suc As String, _allSuc As String)
        Dim _Actualizacion As String
        Dim _Err As Boolean
        Dim _Tabla As DataTable
        _Tabla = D_Maximo("ZY003", "ydnumi", "ydnumi=ydnumi")
        If Not IsDBNull(_Tabla.Rows(0).Item(0)) Then
            _numi = _Tabla.Rows(0).Item(0) + 1
        Else
            _numi = "1"
        End If

        _Actualizacion = "'" + Date.Now.Date.ToString("yyyy/MM/dd") + "', '" + Now.Hour.ToString + ":" + Now.Minute.ToString + "' ,'" + L_Usuario + "'"

        Dim Sql As String
        Sql = _numi + ",'" + _user + "'," + _rol + ",'" + _pass + "','" + _estado + "'," + _cantDias + "," + _tamFuente + "," + _suc + "," + _allSuc + "," + _Actualizacion
        _Err = D_Insertar_Datos("ZY003", Sql)
    End Sub
    Public Shared Sub L_Usuario_Modificar(_numi As String, _user As String, _pass As String, _rol As String, _estado As String, _cantDias As String, _tamFuente As String, _suc As String, _allSuc As String)
        Dim _Err As Boolean
        Dim Sql, _where As String

        Sql = "yduser = '" + _user + "' , " + _
        "ydpass = '" + _pass + "' , " + _
        "ydrol = " + _rol + " , " + _
        "ydest = '" + _estado + "' , " + _
        "ydcant = " + _cantDias + " , " + _
        "ydfontsize = " + _tamFuente + " , " + _
        "ydsuc = " + _suc + " , " + _
        "ydall = " + _allSuc

        _where = "ydnumi = " + _numi
        _Err = D_Modificar_Datos("ZY003", Sql, _where)
    End Sub
    Public Shared Sub L_Usuario_Borrar(_Id As String)
        Dim _Where As String
        Dim _Err As Boolean
        _Where = "ydnumi = " + _Id
        _Err = D_Eliminar_Datos("ZY003", _Where)
    End Sub

    Public Shared Function L_Validar_Usuario2(_Nom As String, _Pass As String) As Boolean
        Dim _Tabla As DataTable
        _Tabla = D_Datos_Tabla("*", "ZY003", "yduser = '" + _Nom + "' AND ydpass = '" + _Pass + "'")
        If _Tabla.Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Shared Function L_Validar_Usuario(_Nom As String, _Pass As String) As DataTable
        Dim _Tabla As DataTable
        _Tabla = D_Datos_Tabla("ydnumi,yduser,ydrol,ydpass,ydest,ydcant,ydfontsize,ydsuc,ydall", "ZY003", "yduser = '" + _Nom + "' AND ydpass = '" + _Pass + "'")
        Return _Tabla
    End Function
#End Region

#End Region

#Region "EJEMPLO BASE"

    Public Shared Function L_prTablaEjemploGrabar(ByRef _numi As String, _fApertura As String, _fCierre As String, _turno As String, _obs As String, _user As String, _estado As String, _efectivo As String) As Boolean
        Dim _Error As Boolean

        Dim _Tabla As DataTable
        _Tabla = D_Maximo("TO003", "odnumi", "1 = 1")
        If Not IsDBNull(_Tabla.Rows(0).Item(0)) Then
            _numi = _Tabla.Rows(0).Item(0) + 1
        Else
            _numi = "1"
        End If
        Dim _valores As String
        _valores = _numi + ",'" + _fApertura + "','" + _fCierre + "'," + _turno + ",'" + _obs + "'," + _user + "," + _estado + "," + _efectivo + "," + _fnsAuditoria()

        _Error = D_Insertar_Datos("TO003", _valores)
        Return Not _Error
    End Function
    Public Shared Function L_prTablaEjemploGeneral1(Optional _Cadena As String = "", Optional _order As String = "") As DataTable 'modelo 1 con condificion
        Dim _Tabla As DataTable
        Dim _Where, _campos As String
        If _Cadena = "" Then
            _Where = "odturno=cenum and cecon=7 and oduser=ydnumi"
        Else
            _Where = "odturno=cenum and cecon=7 and oduser=ydnumi and " + _Cadena
        End If
        _order = IIf(_order = "", " order by odnumi", " order by " + _order)
        _campos = "odnumi,odfaper,odfcierre,odturno,cedesc,odobs,oduser,yduser,odest,odefec"
        _Tabla = D_Datos_Tabla(_campos, "TO003,TC005,ZY003", _Where + _order)
        Return _Tabla
    End Function

    Public Shared Function L_prTablaEjemploGeneral2(Optional _Cadena As String = "", Optional _order As String = "") As DataTable 'modelo 1 sin condificion
        Dim _Tabla As DataTable
        Dim _Where, _campos As String
        If _Cadena = "" Then
            _Where = "1=1"
        Else
            _Where = _Cadena
        End If
        _order = IIf(_order = "", " order by odnumi", " order by " + _order)
        _campos = "odnumi,odfaper,odfcierre,odturno,cedesc,odobs,oduser,yduser,odest,odefec"
        _Tabla = D_Datos_Tabla(_campos, "TO003,TC005,ZY003", _Where + _order)
        Return _Tabla
    End Function

    Public Shared Function L_prTablaEjemploModificar(ByRef _numi As String, _fApertura As String, _fCierre As String, _turno As String, _obs As String, _user As String, _estado As String, _efectivo As String) As Boolean
        Dim _Error As Boolean
        Dim Sql, _where As String

        Sql = "odfaper ='" + _fApertura + "', " + _
        "odfcierre ='" + _fCierre + "', " + _
        "odturno = " + _turno + ", " + _
        "odobs = '" + _obs + "', " + _
        "oduser = " + _user + ", " + _
        "odest = " + _estado + ", " + _
        "odefec = " + _efectivo + ", " + _
        "odfact = '" + Date.Now.Date.ToString("yyyy/MM/dd") + "', " + _
        "odhact = '" + Now.Hour.ToString("00") + ":" + Now.Minute.ToString(0) + "', " +
        "oduact = '" + L_Usuario + "'"

        _where = "odnumi = " + _numi
        _Error = D_Modificar_Datos("TO003", Sql, _where)
        Return Not _Error
    End Function

    Public Shared Function L_prTablaEjemploBorrar(_Id As String) As Boolean

        Dim _Where As String
        Dim _Error As Boolean

        _Where = "odnumi = " + _Id
        _Error = D_Eliminar_Datos("TO003", _Where)
        Return Not _Error
    End Function


#End Region

#Region "PERSONAL"
    Public Shared Function L_prPersonaAyudaGeneralPorSucursal(_suc As String, _tipo As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 4))
        _listParam.Add(New Datos.DParametro("@pasuc", _suc))
        _listParam.Add(New Datos.DParametro("@patipo", _tipo))
        _listParam.Add(New Datos.DParametro("@pauact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TP001", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prPersonaAyudaGeneral(_tipo As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 41))
        _listParam.Add(New Datos.DParametro("@patipo", _tipo))
        _listParam.Add(New Datos.DParametro("@pauact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TP001", _listParam)

        Return _Tabla
    End Function
    Public Shared Function L_prPersonaAyudaGeneralInstructor(_tipo As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 50))
        _listParam.Add(New Datos.DParametro("@patipo", _tipo))
        _listParam.Add(New Datos.DParametro("@pauact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TP001", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prPersonaAyudaGeneral2(_tipo As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 43))
        _listParam.Add(New Datos.DParametro("@patipo", _tipo))
        _listParam.Add(New Datos.DParametro("@pauact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TP001", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prPersonaAyudaTodosGeneral() As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 42))
        _listParam.Add(New Datos.DParametro("@pauact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TP001", _listParam)

        Return _Tabla
    End Function
    Public Shared Function L_prPersonaAyudaTodosGeneralCorrMarcado() As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 8))
        _listParam.Add(New Datos.DParametro("@pauact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TP001", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prPersonaAyudaInstructoresHorasTrabajadas() As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 9))
        _listParam.Add(New Datos.DParametro("@pauact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TP001", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prPersonaAyudaObtenerConGrabacionesEnMesAnio(_mes As String, _anio As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 10))
        _listParam.Add(New Datos.DParametro("@mes", _mes))
        _listParam.Add(New Datos.DParametro("@anio", _anio))
        _listParam.Add(New Datos.DParametro("@pauact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TP001", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prPersonaGeneral(_suc As String, Optional _Cadena As String = "", Optional _order As String = "") As DataTable 'modelo 1 con condificion
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 3))
        _listParam.Add(New Datos.DParametro("@pasuc", _suc))
        _listParam.Add(New Datos.DParametro("@pauact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TP001", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prPersonaBuscarNumiGeneral(_numi As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 6))
        _listParam.Add(New Datos.DParametro("@panumi", _numi))
        _listParam.Add(New Datos.DParametro("@pauact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TP001", _listParam)

        Return _Tabla
    End Function
    Public Shared Function L_prPersonaBuscarNumiGeneral2(_numi As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 7))
        _listParam.Add(New Datos.DParametro("@panumi", _numi))
        _listParam.Add(New Datos.DParametro("@pauact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TP001", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prPersonaGrabar(ByRef _numi As String, _ci As String, _nom As String, _apellido As String, _direc As String, _telef1 As String, _telef2 As String, _email As String, _tipo As String, _salario As String, _obs As String, _fNac As String, _fIng As String, _fRet As String, ByRef _foto As String, _estado As String, _estCivil As String, _suc As String, _fijo As String, _fecSalida As String, _reloj As String, _empresa As String, _lat As String, _longi As String, _pareja As String, _hijos As String, _matriSegu As String, _tipoSangre As String, _problemSalud As String, _TP0011 As DataTable) As Boolean
        Dim _res As Boolean

        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 1))
        _listParam.Add(New Datos.DParametro("@panumi", _numi))
        _listParam.Add(New Datos.DParametro("@paci", _ci))
        _listParam.Add(New Datos.DParametro("@panom", _nom))
        _listParam.Add(New Datos.DParametro("@paape", _apellido))
        _listParam.Add(New Datos.DParametro("@padirec", _direc))
        _listParam.Add(New Datos.DParametro("@patelef1", _telef1))
        _listParam.Add(New Datos.DParametro("@patelef2", _telef2))
        _listParam.Add(New Datos.DParametro("@paemail", _email))
        _listParam.Add(New Datos.DParametro("@patipo", _tipo))
        _listParam.Add(New Datos.DParametro("@pasal", _salario))
        _listParam.Add(New Datos.DParametro("@paobs", _obs))
        _listParam.Add(New Datos.DParametro("@pafnac", _fNac))
        _listParam.Add(New Datos.DParametro("@pafing", _fIng))
        _listParam.Add(New Datos.DParametro("@pafret", _fRet))
        _listParam.Add(New Datos.DParametro("@pafot", _foto))
        _listParam.Add(New Datos.DParametro("@paest", _estado))
        _listParam.Add(New Datos.DParametro("@paeciv", _estCivil))
        _listParam.Add(New Datos.DParametro("@pasuc", _suc))
        _listParam.Add(New Datos.DParametro("@pafijo", _fijo))
        _listParam.Add(New Datos.DParametro("@pafsal", _fecSalida))
        _listParam.Add(New Datos.DParametro("@pareloj", _reloj))
        _listParam.Add(New Datos.DParametro("@paemp", _empresa))
        _listParam.Add(New Datos.DParametro("@palat", _lat))
        _listParam.Add(New Datos.DParametro("@palon", _longi))
        _listParam.Add(New Datos.DParametro("@paesp", _pareja))
        _listParam.Add(New Datos.DParametro("@pahijos", _hijos))
        _listParam.Add(New Datos.DParametro("@pamseg", _matriSegu))
        _listParam.Add(New Datos.DParametro("@patsan", _tipoSangre))
        _listParam.Add(New Datos.DParametro("@papsalud", _problemSalud))
        _listParam.Add(New Datos.DParametro("@pauact", L_Usuario))
        _listParam.Add(New Datos.DParametro("@TP0011", "", _TP0011))



        _Tabla = D_ProcedimientoConParam("sp_dg_TP001", _listParam)

        If _Tabla.Rows.Count > 0 Then
            _numi = _Tabla.Rows(0).Item(0)
            If _foto <> "" Then
                _foto = "personal_" + _numi
            End If
            _res = True
        Else
            _res = False
        End If

        Return _res
    End Function

    Public Shared Function L_prPersonaModificar(_numi As String, _ci As String, _nom As String, _apellido As String, _direc As String, _telef1 As String, _telef2 As String, _email As String, _tipo As String, _salario As String, _obs As String, _fNac As String, _fIng As String, _fRet As String, ByRef _foto As String, _estado As String, _estCivil As String, _suc As String, _fijo As String, _fecSalida As String, _reloj As String, _empresa As String, _lat As String, _longi As String, _pareja As String, _hijos As String, _matriSegu As String, _tipoSangre As String, _problemSalud As String, _TP0011 As DataTable) As Boolean
        Dim _res As Boolean

        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 2))
        _listParam.Add(New Datos.DParametro("@panumi", _numi))
        _listParam.Add(New Datos.DParametro("@paci", _ci))
        _listParam.Add(New Datos.DParametro("@panom", _nom))
        _listParam.Add(New Datos.DParametro("@paape", _apellido))
        _listParam.Add(New Datos.DParametro("@padirec", _direc))
        _listParam.Add(New Datos.DParametro("@patelef1", _telef1))
        _listParam.Add(New Datos.DParametro("@patelef2", _telef2))
        _listParam.Add(New Datos.DParametro("@paemail", _email))
        _listParam.Add(New Datos.DParametro("@patipo", _tipo))
        _listParam.Add(New Datos.DParametro("@pasal", _salario))
        _listParam.Add(New Datos.DParametro("@paobs", _obs))
        _listParam.Add(New Datos.DParametro("@pafnac", _fNac))
        _listParam.Add(New Datos.DParametro("@pafing", _fIng))
        _listParam.Add(New Datos.DParametro("@pafret", _fRet))
        _listParam.Add(New Datos.DParametro("@pafot", _foto))
        _listParam.Add(New Datos.DParametro("@paest", _estado))
        _listParam.Add(New Datos.DParametro("@paeciv", _estCivil))
        _listParam.Add(New Datos.DParametro("@pasuc", _suc))
        _listParam.Add(New Datos.DParametro("@pafijo", _fijo))
        _listParam.Add(New Datos.DParametro("@pafsal", _fecSalida))
        _listParam.Add(New Datos.DParametro("@pareloj", _reloj))
        _listParam.Add(New Datos.DParametro("@paemp", _empresa))
        _listParam.Add(New Datos.DParametro("@palat", _lat))
        _listParam.Add(New Datos.DParametro("@palon", _longi))
        _listParam.Add(New Datos.DParametro("@paesp", _pareja))
        _listParam.Add(New Datos.DParametro("@pahijos", _hijos))
        _listParam.Add(New Datos.DParametro("@pamseg", _matriSegu))
        _listParam.Add(New Datos.DParametro("@patsan", _tipoSangre))
        _listParam.Add(New Datos.DParametro("@papsalud", _problemSalud))
        _listParam.Add(New Datos.DParametro("@pauact", L_Usuario))
        _listParam.Add(New Datos.DParametro("@TP0011", "", _TP0011))

        _Tabla = D_ProcedimientoConParam("sp_dg_TP001", _listParam)

        If _Tabla.Rows.Count > 0 Then
            _numi = _Tabla.Rows(0).Item(0)
            If _foto <> "" Then
                _foto = "personal_" + _numi
            End If
            _res = True
        Else
            _res = False
        End If

        Return _res
    End Function

    Public Shared Function L_prPersonaBorrar(_numi As String, ByRef _mensaje As String) As Boolean

        Dim _resultado As Boolean

        If L_fnbValidarEliminacion(_numi, "TP001", "panumi", _mensaje) = True Then
            Dim _Tabla As DataTable

            Dim _listParam As New List(Of Datos.DParametro)

            _listParam.Add(New Datos.DParametro("@tipo", -1))
            _listParam.Add(New Datos.DParametro("@panumi", _numi))
            _listParam.Add(New Datos.DParametro("@pauact", L_Usuario))

            _Tabla = D_ProcedimientoConParam("sp_dg_TP001", _listParam)

            If _Tabla.Rows.Count > 0 Then
                _numi = _Tabla.Rows(0).Item(0)
                _resultado = True
            Else
                _resultado = False
            End If
        Else
            _resultado = False
        End If

        Return _resultado
    End Function

    '-------------------------------- DETALLE PERSONAL TP0011-----------------------------------------
    Public Shared Function L_prPersonaDetalleGeneral(_numiCab As String, Optional _Cadena As String = "", Optional _order As String = "") As DataTable 'modelo 1 con condificion
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 5))
        _listParam.Add(New Datos.DParametro("@panumi", _numiCab))
        _listParam.Add(New Datos.DParametro("@pauact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TP001", _listParam)

        Return _Tabla
    End Function

#End Region

#Region "VEHICULOS"

    Public Shared Function L_prVehiculoGeneral(_suc As String, Optional _Cadena As String = "", Optional _order As String = "") As DataTable 'modelo 1 con condificion
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 3))
        _listParam.Add(New Datos.DParametro("@casuc", _suc))
        _listParam.Add(New Datos.DParametro("@cauact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE001", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prVehiculoGrabar(ByRef _numi As String, _id As String, _marca As String, _modelo As String, _persona As String, _obs As String, ByRef _img As String, _tipo As String, _suc As String, _anio As String, _mant As String) As Boolean
        Dim _resultado As Boolean

        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 1))
        _listParam.Add(New Datos.DParametro("@canumi", _numi))
        _listParam.Add(New Datos.DParametro("@caid", _id))
        _listParam.Add(New Datos.DParametro("@camar", _marca))
        _listParam.Add(New Datos.DParametro("@camod", _modelo))
        _listParam.Add(New Datos.DParametro("@caper", _persona))
        _listParam.Add(New Datos.DParametro("@caobs", _obs))
        _listParam.Add(New Datos.DParametro("@caimg", _img))
        _listParam.Add(New Datos.DParametro("@catipo", _tipo))
        _listParam.Add(New Datos.DParametro("@casuc", _suc))
        _listParam.Add(New Datos.DParametro("@caanio", _anio))
        _listParam.Add(New Datos.DParametro("@camant", _mant))
        _listParam.Add(New Datos.DParametro("@cauact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE001", _listParam)

        If _Tabla.Rows.Count > 0 Then
            _numi = _Tabla.Rows(0).Item(0)
            _img = "vehiculo_" + _numi
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function

    Public Shared Function L_prVehiculoModificar(_numi As String, _id As String, _marca As String, _modelo As String, _persona As String, _obs As String, _img As String, _tipo As String, _suc As String, _anio As String, _mant As String) As Boolean
        Dim _resultado As Boolean

        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 2))
        _listParam.Add(New Datos.DParametro("@canumi", _numi))
        _listParam.Add(New Datos.DParametro("@caid", _id))
        _listParam.Add(New Datos.DParametro("@camar", _marca))
        _listParam.Add(New Datos.DParametro("@camod", _modelo))
        _listParam.Add(New Datos.DParametro("@caper", _persona))
        _listParam.Add(New Datos.DParametro("@caobs", _obs))
        _listParam.Add(New Datos.DParametro("@caimg", _img))
        _listParam.Add(New Datos.DParametro("@catipo", _tipo))
        _listParam.Add(New Datos.DParametro("@casuc", _suc))
        _listParam.Add(New Datos.DParametro("@caanio", _anio))
        _listParam.Add(New Datos.DParametro("@camant", _mant))
        _listParam.Add(New Datos.DParametro("@cauact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE001", _listParam)

        If _Tabla.Rows.Count > 0 Then
            _numi = _Tabla.Rows(0).Item(0)
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function

    Public Shared Function L_prVehiculoBorrar(_numi As String) As Boolean
        Dim _resultado As Boolean
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", -1))
        _listParam.Add(New Datos.DParametro("@canumi", _numi))
        _listParam.Add(New Datos.DParametro("@cauact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE001", _listParam)

        If _Tabla.Rows.Count > 0 Then
            _numi = _Tabla.Rows(0).Item(0)
            _resultado = True
        Else
            _resultado = False
        End If
        Return _resultado
    End Function


#End Region

#Region "ALUMNNO"
    Public Shared Function L_prAlumnoFichaInscripcion(_numi As String) As DataTable 'modelo 1 con condificion
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 9))
        _listParam.Add(New Datos.DParametro("@cbnumi", _numi))
        _listParam.Add(New Datos.DParametro("@cbuact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE002", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prAlumnoFichaInscripcion2(_numi As String) As DataTable 'modelo 1 con condificion
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 91))
        _listParam.Add(New Datos.DParametro("@cbnumi", _numi))
        _listParam.Add(New Datos.DParametro("@cbuact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE002", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prAlumnoClasesPracticasDetallado(_numi As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 10))
        _listParam.Add(New Datos.DParametro("@cbnumi", _numi))
        _listParam.Add(New Datos.DParametro("@cbuact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE002", _listParam)

        Return _Tabla
    End Function

    'alumnos que no estan asignado al instructor
    Public Shared Function L_prAlumnoLibresInstructorAyuda(_suc As String, _numiInst As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 7))
        _listParam.Add(New Datos.DParametro("@cbnumi", _numiInst))
        _listParam.Add(New Datos.DParametro("@cbsuc", _suc))
        _listParam.Add(New Datos.DParametro("@cbuact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE002", _listParam)

        Return _Tabla
    End Function
    Public Shared Function L_prAlumnoLibresInstructorAyudaR(_suc As String, _numiInst As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 7))
        _listParam.Add(New Datos.DParametro("@cbnumi", _numiInst))
        _listParam.Add(New Datos.DParametro("@cbsuc", _suc))
        _listParam.Add(New Datos.DParametro("@cbuact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE002", _listParam)

        Return _Tabla
    End Function
    Public Shared Function L_prAlumnoLibresInstructorFaltanClasesAyuda(_suc As String, _numiInst As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 8))
        _listParam.Add(New Datos.DParametro("@cbnumi", _numiInst))
        _listParam.Add(New Datos.DParametro("@cbsuc", _suc))
        _listParam.Add(New Datos.DParametro("@cbuact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE002", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prAlumnoLibresInstructorFaltanClasesAyudaR(_suc As String, _numiInst As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 81))
        _listParam.Add(New Datos.DParametro("@cbnumi", _numiInst))
        _listParam.Add(New Datos.DParametro("@cbsuc", _suc))
        _listParam.Add(New Datos.DParametro("@cbuact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE002", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prAlumnoAyuda(_suc As String, Optional _Cadena As String = "", Optional _order As String = "") As DataTable 'modelo 1 con condificion
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 5))
        _listParam.Add(New Datos.DParametro("@cbsuc", _suc))
        _listParam.Add(New Datos.DParametro("@cbuact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE002", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prAlumnoAyudaColor(_suc As String, _numiInst As String, _fecha As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 6))
        _listParam.Add(New Datos.DParametro("@cbnumi", _numiInst))
        _listParam.Add(New Datos.DParametro("@cbsuc", _suc))
        _listParam.Add(New Datos.DParametro("@auxFecha", _fecha))
        _listParam.Add(New Datos.DParametro("@cbuact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE002", _listParam)

        Return _Tabla
    End Function
    Public Shared Function L_prAlumnoAyudaColorR(_suc As String, _numiInst As String, _fecha As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 61))
        _listParam.Add(New Datos.DParametro("@cbnumi", _numiInst))
        _listParam.Add(New Datos.DParametro("@cbsuc", _suc))
        _listParam.Add(New Datos.DParametro("@auxFecha", _fecha))
        _listParam.Add(New Datos.DParametro("@cbuact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE002", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prAlumnoGeneral(_suc As String, Optional _Cadena As String = "", Optional _order As String = "") As DataTable 'modelo 1 con condificion
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 3))
        _listParam.Add(New Datos.DParametro("@cbsuc", _suc))
        _listParam.Add(New Datos.DParametro("@cbuact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE002", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prAlumnoAyudaSocios(Optional _Cadena As String = "", Optional _order As String = "") As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 4))
        _listParam.Add(New Datos.DParametro("@cbuact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE002", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prAlumnoGrabar(ByRef _numi As String, _ci As String, _nom As String, _apellido As String, _direc As String, _telef1 As String, _telef2 As String, _email As String, _fNac As String, _fIng As String, _lugNac As String, _estCivil As String, _profesion As String, _tipo As String, _estado As String, ByRef _foto As String, _obs As String, _numiSocio As String, _parentesco As String, _menor As String, _tutCi As String, _tutNom As String, _suc As String, _nroGrupo As String, _nroFactura As String, numiFactura As String) As Boolean
        Dim _res As Boolean

        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 1))
        _listParam.Add(New Datos.DParametro("@cbnumi", _numi))
        _listParam.Add(New Datos.DParametro("@cbci", _ci))
        _listParam.Add(New Datos.DParametro("@cbnom", _nom))
        _listParam.Add(New Datos.DParametro("@cbape", _apellido))
        _listParam.Add(New Datos.DParametro("@cbdirec", _direc))
        _listParam.Add(New Datos.DParametro("@cbtelef1", _telef1))
        _listParam.Add(New Datos.DParametro("@cbtelef2", _telef2))
        _listParam.Add(New Datos.DParametro("@cbemail", _email))
        _listParam.Add(New Datos.DParametro("@cbtipo", _tipo))
        _listParam.Add(New Datos.DParametro("@cblnac", _lugNac))
        _listParam.Add(New Datos.DParametro("@cbprof", _profesion))
        _listParam.Add(New Datos.DParametro("@cbfnac", _fNac))
        _listParam.Add(New Datos.DParametro("@cbfing", _fIng))
        _listParam.Add(New Datos.DParametro("@cbfot", _foto))
        _listParam.Add(New Datos.DParametro("@cbest", _estado))
        _listParam.Add(New Datos.DParametro("@cbeciv", _estCivil))
        _listParam.Add(New Datos.DParametro("@cbobs", _obs))
        _listParam.Add(New Datos.DParametro("@cbnumiSoc", _numiSocio))
        _listParam.Add(New Datos.DParametro("@cbparent", _parentesco))
        _listParam.Add(New Datos.DParametro("@cbmen", _menor))
        _listParam.Add(New Datos.DParametro("@cbtutci", _tutCi))
        _listParam.Add(New Datos.DParametro("@cbtutnom", _tutNom))
        _listParam.Add(New Datos.DParametro("@cbsuc", _suc))
        _listParam.Add(New Datos.DParametro("@cbnrogr", _nroGrupo))
        _listParam.Add(New Datos.DParametro("@cbnfact", _nroFactura))
        '_listParam.Add(New Datos.DParametro("@vcnumi", numiFactura))
        _listParam.Add(New Datos.DParametro("@cbuact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE002", _listParam)

        If _Tabla.Rows.Count > 0 Then
            _numi = _Tabla.Rows(0).Item(0)
            If _foto <> "" Then
                _foto = "alumno_" + _numi
            End If
            _res = True
        Else
            _res = False
        End If

        Return _res
    End Function

    Public Shared Function L_prAlumnoModificar(ByRef _numi As String, _ci As String, _nom As String, _apellido As String, _direc As String, _telef1 As String, _telef2 As String, _email As String, _fNac As String, _fIng As String, _lugNac As String, _estCivil As String, _profesion As String, _tipo As String, _estado As String, ByRef _foto As String, _obs As String, _numiSocio As String, _parentesco As String, _menor As String, _tutCi As String, _tutNom As String, _suc As String, _nroGrupo As String, _nroFactura As String) As Boolean
        Dim _res As Boolean

        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 2))
        _listParam.Add(New Datos.DParametro("@cbnumi", _numi))
        _listParam.Add(New Datos.DParametro("@cbci", _ci))
        _listParam.Add(New Datos.DParametro("@cbnom", _nom))
        _listParam.Add(New Datos.DParametro("@cbape", _apellido))
        _listParam.Add(New Datos.DParametro("@cbdirec", _direc))
        _listParam.Add(New Datos.DParametro("@cbtelef1", _telef1))
        _listParam.Add(New Datos.DParametro("@cbtelef2", _telef2))
        _listParam.Add(New Datos.DParametro("@cbemail", _email))
        _listParam.Add(New Datos.DParametro("@cbtipo", _tipo))
        _listParam.Add(New Datos.DParametro("@cblnac", _lugNac))
        _listParam.Add(New Datos.DParametro("@cbprof", _profesion))
        _listParam.Add(New Datos.DParametro("@cbfnac", _fNac))
        _listParam.Add(New Datos.DParametro("@cbfing", _fIng))
        _listParam.Add(New Datos.DParametro("@cbfot", _foto))
        _listParam.Add(New Datos.DParametro("@cbest", _estado))
        _listParam.Add(New Datos.DParametro("@cbeciv", _estCivil))
        _listParam.Add(New Datos.DParametro("@cbobs", _obs))
        _listParam.Add(New Datos.DParametro("@cbnumiSoc", _numiSocio))
        _listParam.Add(New Datos.DParametro("@cbparent", _parentesco))
        _listParam.Add(New Datos.DParametro("@cbmen", _menor))
        _listParam.Add(New Datos.DParametro("@cbtutci", _tutCi))
        _listParam.Add(New Datos.DParametro("@cbtutnom", _tutNom))
        _listParam.Add(New Datos.DParametro("@cbsuc", _suc))
        _listParam.Add(New Datos.DParametro("@cbnrogr", _nroGrupo))
        _listParam.Add(New Datos.DParametro("@cbnfact", _nroFactura))
        _listParam.Add(New Datos.DParametro("@cbuact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE002", _listParam)

        If _Tabla.Rows.Count > 0 Then
            _numi = _Tabla.Rows(0).Item(0)
            If _foto <> "" Then
                _foto = "alumno_" + _numi
            End If
            _res = True
        Else
            _res = False
        End If

        Return _res
    End Function

    Public Shared Function L_prAlumnoBorrar(_numi As String, ByRef _mensaje As String) As Boolean

        Dim _resultado As Boolean

        If L_fnbValidarEliminacion(_numi, "TCE002", "cbnumi", _mensaje) = True Then
            Dim _Tabla As DataTable

            Dim _listParam As New List(Of Datos.DParametro)

            _listParam.Add(New Datos.DParametro("@tipo", -1))
            _listParam.Add(New Datos.DParametro("@cbnumi", _numi))
            _listParam.Add(New Datos.DParametro("@cbuact", L_Usuario))

            _Tabla = D_ProcedimientoConParam("sp_dg_TCE002", _listParam)

            If _Tabla.Rows.Count > 0 Then
                _numi = _Tabla.Rows(0).Item(0)
                _resultado = True
            Else
                _resultado = False
            End If
        Else
            _resultado = False
        End If

        Return _resultado
    End Function

#End Region

#Region "FERIADOS"

    Public Shared Function L_prFeriadoGeneral(Optional _Cadena As String = "", Optional _order As String = "") As DataTable 'modelo 1 con condificion
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 3))
        _listParam.Add(New Datos.DParametro("@pfuact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TP005", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prFeriadoGeneralPorFecha(_fecha As String) As DataTable 'modelo 1 con condificion
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 4))
        _listParam.Add(New Datos.DParametro("@pfflib", _fecha))
        _listParam.Add(New Datos.DParametro("@pfuact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TP005", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prFeriadoGeneralPorRangoFecha(_fechaDel As String, _fechaAl As String) As DataTable 'modelo 1 con condificion
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 5))
        _listParam.Add(New Datos.DParametro("@fecha1", _fechaDel))
        _listParam.Add(New Datos.DParametro("@fecha2", _fechaAl))
        _listParam.Add(New Datos.DParametro("@pfuact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TP005", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prFeriadoGrabar(ByRef _numi As String, _fecha As String, _desc As String) As Boolean
        Dim _resultado As Boolean

        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 1))
        _listParam.Add(New Datos.DParametro("@pfflib", _fecha))
        _listParam.Add(New Datos.DParametro("@pfdes", _desc))
        _listParam.Add(New Datos.DParametro("@pfuact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TP005", _listParam)

        If _Tabla.Rows.Count > 0 Then
            _numi = _Tabla.Rows(0).Item(0)
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function

    Public Shared Function L_prFeriadoModificar(ByRef _numi As String, _fecha As String, _desc As String) As Boolean
        Dim _resultado As Boolean

        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 2))
        _listParam.Add(New Datos.DParametro("@pfnumi", _numi))
        _listParam.Add(New Datos.DParametro("@pfflib", _fecha))
        _listParam.Add(New Datos.DParametro("@pfdes", _desc))
        _listParam.Add(New Datos.DParametro("@pfuact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TP005", _listParam)

        If _Tabla.Rows.Count > 0 Then
            _numi = _Tabla.Rows(0).Item(0)
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function

    Public Shared Function L_prFeriadoBorrar(_numi As String, ByRef _mensaje As String) As Boolean

        Dim _resultado As Boolean

        If L_fnbValidarEliminacion(_numi, "TP005", "pfnumi", _mensaje) = True Then
            Dim _Tabla As DataTable

            Dim _listParam As New List(Of Datos.DParametro)

            _listParam.Add(New Datos.DParametro("@tipo", -1))
            _listParam.Add(New Datos.DParametro("@pfnumi", _numi))
            _listParam.Add(New Datos.DParametro("@pfuact", L_Usuario))

            _Tabla = D_ProcedimientoConParam("sp_dg_TP005", _listParam)

            If _Tabla.Rows.Count > 0 Then
                _numi = _Tabla.Rows(0).Item(0)
                _resultado = True
            Else
                _resultado = False
            End If
        Else
            _resultado = False
        End If

        Return _resultado
    End Function

#End Region

#Region "EQUIPOS"

    Public Shared Function L_prEquipoGeneral(_suc As String, Optional _Cadena As String = "", Optional _order As String = "") As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 3))
        _listParam.Add(New Datos.DParametro("@ecsuc", _suc))
        _listParam.Add(New Datos.DParametro("@ecuact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE003", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prEquipoGrabar(ByRef _numi As String, _codigo As String, _desc As String, _tipo As String, _estado As String, _suc As String, _numiPer As String) As Boolean
        Dim _resultado As Boolean

        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 1))
        _listParam.Add(New Datos.DParametro("@ecnumi", _numi))
        _listParam.Add(New Datos.DParametro("@eccod", _codigo))
        _listParam.Add(New Datos.DParametro("@ecdesc", _desc))
        _listParam.Add(New Datos.DParametro("@ectipo", _tipo))
        _listParam.Add(New Datos.DParametro("@ecest", _estado))
        _listParam.Add(New Datos.DParametro("@ecsuc", _suc))
        _listParam.Add(New Datos.DParametro("@ecper", _numiPer))
        _listParam.Add(New Datos.DParametro("@ecuact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE003", _listParam)

        If _Tabla.Rows.Count > 0 Then
            _numi = _Tabla.Rows(0).Item(0)
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function

    Public Shared Function L_prEquipoModificar(ByRef _numi As String, _codigo As String, _desc As String, _tipo As String, _estado As String, _suc As String, _numiPer As String) As Boolean
        Dim _resultado As Boolean

        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 2))
        _listParam.Add(New Datos.DParametro("@ecnumi", _numi))
        _listParam.Add(New Datos.DParametro("@eccod", _codigo))
        _listParam.Add(New Datos.DParametro("@ecdesc", _desc))
        _listParam.Add(New Datos.DParametro("@ectipo", _tipo))
        _listParam.Add(New Datos.DParametro("@ecest", _estado))
        _listParam.Add(New Datos.DParametro("@ecsuc", _suc))
        _listParam.Add(New Datos.DParametro("@ecper", _numiPer))
        _listParam.Add(New Datos.DParametro("@ecuact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE003", _listParam)

        If _Tabla.Rows.Count > 0 Then
            _numi = _Tabla.Rows(0).Item(0)
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function

    Public Shared Function L_prEquipoBorrar(_numi As String, ByRef _mensaje As String) As Boolean

        Dim _resultado As Boolean

        If L_fnbValidarEliminacion(_numi, "TCE003", "ecnumi", _mensaje) = True Then
            Dim _Tabla As DataTable

            Dim _listParam As New List(Of Datos.DParametro)

            _listParam.Add(New Datos.DParametro("@tipo", -1))
            _listParam.Add(New Datos.DParametro("@ecnumi", _numi))
            _listParam.Add(New Datos.DParametro("@ecuact", L_Usuario))

            _Tabla = D_ProcedimientoConParam("sp_dg_TCE003", _listParam)

            If _Tabla.Rows.Count > 0 Then
                _numi = _Tabla.Rows(0).Item(0)
                _resultado = True
            Else
                _resultado = False
            End If
        Else
            _resultado = False
        End If

        Return _resultado
    End Function

#End Region

#Region "SERVICIO"

    Public Shared Function L_prServicioAyuda(Optional _Cadena As String = "", Optional _order As String = "") As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 6))
        _listParam.Add(New Datos.DParametro("@eduact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE004", _listParam)

        Return _Tabla
    End Function
    Public Shared Function L_prServicioEscuelaAyuda(Optional _Cadena As String = "", Optional _order As String = "") As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 7))
        _listParam.Add(New Datos.DParametro("@eduact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE004", _listParam)

        Return _Tabla
    End Function
    Public Shared Function L_prServicioGeneral(Optional _Cadena As String = "", Optional _order As String = "") As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 3))
        _listParam.Add(New Datos.DParametro("@eduact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE004", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prServicioDetalleGeneral(_numiCab As String, Optional _Cadena As String = "", Optional _order As String = "") As DataTable 'modelo 1 con condificion
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 4))
        _listParam.Add(New Datos.DParametro("@ednumi", _numiCab))
        _listParam.Add(New Datos.DParametro("@eduact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE004", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prListarSucursales() As DataTable 'modelo 1 con condificion
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 9))
        _listParam.Add(New Datos.DParametro("@eduact", L_Usuario))
        _Tabla = D_ProcedimientoConParam("sp_dg_TCE004", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prServicioDetallePrecio(_numiCab As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 8))
        _listParam.Add(New Datos.DParametro("@ednumi", _numiCab))
        _listParam.Add(New Datos.DParametro("@eduact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE004", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prServicioDetallePrecioCuotaSocio(tipo As String, tipoc As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 12))
        _listParam.Add(New Datos.DParametro("@numi", tipo))
        _listParam.Add(New Datos.DParametro("@est", tipoc))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_go_TCS014", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prServicioGrabar(ByRef _numi As String, _codigo As String, _desc As String, _precio As String, _tipo As String, _estado As String, _TCE0041 As DataTable, _TCE0042 As DataTable, _suc As Integer,
                                              _TipoCliente As Integer) As Boolean
        Dim _resultado As Boolean

        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 1))
        _listParam.Add(New Datos.DParametro("@ednumi", _numi))
        _listParam.Add(New Datos.DParametro("@edcod", _codigo))
        _listParam.Add(New Datos.DParametro("@eddesc", _desc))
        _listParam.Add(New Datos.DParametro("@edtipo", _tipo))
        _listParam.Add(New Datos.DParametro("@edest", _estado))
        _listParam.Add(New Datos.DParametro("@edprec", _precio))
        _listParam.Add(New Datos.DParametro("@eduact", L_Usuario))
        _listParam.Add(New Datos.DParametro("@TCE0041", "", _TCE0041))
        _listParam.Add(New Datos.DParametro("@TCE0042", "", _TCE0042))
        _listParam.Add(New Datos.DParametro("@edsuc", _suc))
        _listParam.Add(New Datos.DParametro("@tipoCliente", _TipoCliente))
        _Tabla = D_ProcedimientoConParam("sp_dg_TCE004", _listParam)

        If _Tabla.Rows.Count > 0 Then
            _numi = _Tabla.Rows(0).Item(0)
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function
    Public Shared Function L_prServicioModificar(ByRef _numi As String, _codigo As String, _desc As String, _precio As String, _tipo As String, _estado As String, _TCE0041 As DataTable, _TCE0042 As DataTable, ByRef _mensaje As String, _suc As Integer,
                                                   _TipoCliente As Integer) As Boolean
        Dim _resultado As Boolean

        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 2))
        _listParam.Add(New Datos.DParametro("@ednumi", _numi))
        _listParam.Add(New Datos.DParametro("@edcod", _codigo))
        _listParam.Add(New Datos.DParametro("@eddesc", _desc))
        _listParam.Add(New Datos.DParametro("@edprec", _precio))
        _listParam.Add(New Datos.DParametro("@edtipo", _tipo))
        _listParam.Add(New Datos.DParametro("@edest", _estado))
        _listParam.Add(New Datos.DParametro("@eduact", L_Usuario))
        _listParam.Add(New Datos.DParametro("@TCE0041", "", _TCE0041))
        _listParam.Add(New Datos.DParametro("@TCE0042", "", _TCE0042))
        _listParam.Add(New Datos.DParametro("@edsuc", _suc))
        _listParam.Add(New Datos.DParametro("@tipoCliente", _TipoCliente))
        _Tabla = D_ProcedimientoConParam("sp_dg_TCE004", _listParam)

        If _Tabla.Rows.Count > 0 Then
            Dim respuesta As Integer = _Tabla.Rows(0).Item("respuesta")
            If respuesta = 1 Then
                _resultado = True
            Else
                _resultado = False
                Dim nroError As Integer = _Tabla.Rows(0).Item("nroError")
                If nroError = L_nroErrorLlaveForanea Then
                    _mensaje = "no se puede eliminar registro del detalle de precios por error de llave foranea".ToUpper
                End If

            End If
        Else
            _resultado = False
        End If

        Return _resultado
    End Function
    Public Shared Function L_prServicioBorrar(_numi As String, ByRef _mensaje As String) As Boolean

        Dim _resultado As Boolean

        If L_fnbValidarEliminacion(_numi, "TCE004", "ednumi", _mensaje) = True Then
            Dim _Tabla As DataTable

            Dim _listParam As New List(Of Datos.DParametro)

            _listParam.Add(New Datos.DParametro("@tipo", -1))
            _listParam.Add(New Datos.DParametro("@ednumi", _numi))
            _listParam.Add(New Datos.DParametro("@eduact", L_Usuario))

            _Tabla = D_ProcedimientoConParam("sp_dg_TCE004", _listParam)

            If _Tabla.Rows.Count > 0 Then
                Dim respuesta As Integer = _Tabla.Rows(0).Item("respuesta")
                If respuesta = 1 Then
                    _resultado = True
                Else
                    _resultado = False
                    Dim nroError As Integer = _Tabla.Rows(0).Item("nroError")
                    If nroError = L_nroErrorLlaveForanea Then
                        _mensaje = "no se puede eliminar registro por error de llave foranea".ToUpper
                    End If

                End If
            Else
                _resultado = False
                _mensaje = "error al ejecutar procedimiento de almacenado".ToUpper
            End If
        Else
            _resultado = False
        End If

        Return _resultado
    End Function

#End Region

#Region "SOCIO"

    Public Shared Function L_fnSocioGeneral() As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 3))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_go_TCS01", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_fnSocioDetalle1(numi As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 4))
        _listParam.Add(New Datos.DParametro("@numi", numi))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_go_TCS01", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_fnSocioDetalle2(numi As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 5))
        _listParam.Add(New Datos.DParametro("@numi", numi))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_go_TCS01", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_fnSocioDetalle3(numi As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 6))
        _listParam.Add(New Datos.DParametro("@numi", numi))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_go_TCS01", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_fnSocioDetalleVehiculoSocio(numi As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 15))
        _listParam.Add(New Datos.DParametro("@numi", numi))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_go_TCS01", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_fnSocioReporteSocio(numi As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 7))
        _listParam.Add(New Datos.DParametro("@numi", numi))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_go_TCS01", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_fnSocioReporteSocioEdad(fechaIni As String, fechaFin As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 8))
        _listParam.Add(New Datos.DParametro("@fnac", fechaIni))
        _listParam.Add(New Datos.DParametro("@fing", fechaFin))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_go_TCS01", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_fnSocioValidarNroSocio(nsoc As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 13))
        _listParam.Add(New Datos.DParametro("@nsoc", nsoc))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_go_TCS01", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_fnSocioVehiculosImagen(numi As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 14))
        _listParam.Add(New Datos.DParametro("@numi", numi))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_go_TCS01", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_fnSocioGrabar(ByRef numi As String, tsoc As String, nsoc As String, fing As String,
                                           fnac As String, lnac As String, nom As String, apat As String,
                                           amat As String, prof As String, dir1 As String, dir2 As String,
                                           sdir As String, cas As String, email As String, ci As String,
                                           ciemi As String, nome As String, fnace As String, lnace As String,
                                           obs As String, mor As String, tar As String, ntar As String, est As String,
                                           ByRef img As String, hmed As String, vlati As String, vlong As String,
                                           dt1 As DataTable, dt2 As DataTable, dt3 As DataTable) As Boolean
        Dim _resultado As Boolean

        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 1))
        _listParam.Add(New Datos.DParametro("@numi", numi))
        _listParam.Add(New Datos.DParametro("@tsoc", tsoc))
        _listParam.Add(New Datos.DParametro("@nsoc", nsoc))
        _listParam.Add(New Datos.DParametro("@fing", fing))
        _listParam.Add(New Datos.DParametro("@fnac", fnac))
        _listParam.Add(New Datos.DParametro("@lnac", lnac))
        _listParam.Add(New Datos.DParametro("@nom", nom))
        _listParam.Add(New Datos.DParametro("@apat", apat))
        _listParam.Add(New Datos.DParametro("@amat", amat))
        _listParam.Add(New Datos.DParametro("@prof", prof))
        _listParam.Add(New Datos.DParametro("@dir1", dir1))
        _listParam.Add(New Datos.DParametro("@dir2", dir2))
        _listParam.Add(New Datos.DParametro("@sdir", sdir))
        _listParam.Add(New Datos.DParametro("@cas", cas))
        _listParam.Add(New Datos.DParametro("@email", email))
        _listParam.Add(New Datos.DParametro("@ci", ci))
        _listParam.Add(New Datos.DParametro("@ciemi", ciemi))
        _listParam.Add(New Datos.DParametro("@nome", nome))
        _listParam.Add(New Datos.DParametro("@fnace", fnace))
        _listParam.Add(New Datos.DParametro("@lnace", lnace))
        _listParam.Add(New Datos.DParametro("@obs", obs))
        _listParam.Add(New Datos.DParametro("@mor", mor))
        _listParam.Add(New Datos.DParametro("@tar", tar))
        _listParam.Add(New Datos.DParametro("@ntar", ntar))
        _listParam.Add(New Datos.DParametro("@est", est))
        _listParam.Add(New Datos.DParametro("@img", img))
        _listParam.Add(New Datos.DParametro("@hmed", hmed))
        _listParam.Add(New Datos.DParametro("@lati", vlati))
        _listParam.Add(New Datos.DParametro("@long", vlong))
        _listParam.Add(New Datos.DParametro("@TCS011", "", dt1))
        _listParam.Add(New Datos.DParametro("@TCS012", "", dt2))
        _listParam.Add(New Datos.DParametro("@TCS013", "", dt3))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_go_TCS01", _listParam)

        If _Tabla.Rows.Count > 0 Then
            numi = _Tabla.Rows(0).Item(0)
            img = "socio_" + numi
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function

    Public Shared Function L_fnSocioModificar(ByRef numi As String, tsoc As String, nsoc As String, fing As String,
                                           fnac As String, lnac As String, nom As String, apat As String,
                                           amat As String, prof As String, dir1 As String, dir2 As String,
                                           sdir As String, cas As String, email As String, ci As String,
                                           ciemi As String, nome As String, fnace As String, lnace As String,
                                           obs As String, mor As String, tar As String, ntar As String, est As String,
                                           ByRef img As String, hmed As String, vlati As String, vlong As String,
                                           dt1 As DataTable, dt2 As DataTable, dt3 As DataTable) As Boolean
        Dim _resultado As Boolean

        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 2))
        _listParam.Add(New Datos.DParametro("@numi", numi))
        _listParam.Add(New Datos.DParametro("@tsoc", tsoc))
        _listParam.Add(New Datos.DParametro("@nsoc", nsoc))
        _listParam.Add(New Datos.DParametro("@fing", fing))
        _listParam.Add(New Datos.DParametro("@fnac", fnac))
        _listParam.Add(New Datos.DParametro("@lnac", lnac))
        _listParam.Add(New Datos.DParametro("@nom", nom))
        _listParam.Add(New Datos.DParametro("@apat", apat))
        _listParam.Add(New Datos.DParametro("@amat", amat))
        _listParam.Add(New Datos.DParametro("@prof", prof))
        _listParam.Add(New Datos.DParametro("@dir1", dir1))
        _listParam.Add(New Datos.DParametro("@dir2", dir2))
        _listParam.Add(New Datos.DParametro("@sdir", sdir))
        _listParam.Add(New Datos.DParametro("@cas", cas))
        _listParam.Add(New Datos.DParametro("@email", email))
        _listParam.Add(New Datos.DParametro("@ci", ci))
        _listParam.Add(New Datos.DParametro("@ciemi", ciemi))
        _listParam.Add(New Datos.DParametro("@nome", nome))
        _listParam.Add(New Datos.DParametro("@fnace", fnace))
        _listParam.Add(New Datos.DParametro("@lnace", lnace))
        _listParam.Add(New Datos.DParametro("@obs", obs))
        _listParam.Add(New Datos.DParametro("@mor", mor))
        _listParam.Add(New Datos.DParametro("@tar", tar))
        _listParam.Add(New Datos.DParametro("@ntar", ntar))
        _listParam.Add(New Datos.DParametro("@est", est))
        _listParam.Add(New Datos.DParametro("@img", img))
        _listParam.Add(New Datos.DParametro("@hmed", hmed))
        _listParam.Add(New Datos.DParametro("@lati", vlati))
        _listParam.Add(New Datos.DParametro("@long", vlong))
        _listParam.Add(New Datos.DParametro("@TCS011", "", dt1))
        _listParam.Add(New Datos.DParametro("@TCS012", "", dt2))
        _listParam.Add(New Datos.DParametro("@TCS013", "", dt3))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_go_TCS01", _listParam)

        If _Tabla.Rows.Count > 0 Then
            numi = _Tabla.Rows(0).Item(0)
            img = "socio_" + numi
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function

    Public Shared Function L_fnSocioBorrar(_numi As String, ByRef _mensaje As String) As Boolean

        Dim _resultado As Boolean

        If L_fnbValidarEliminacion(_numi, "TCS01", "cfnumi", _mensaje) = True Then
            Dim _Tabla As DataTable

            Dim _listParam As New List(Of Datos.DParametro)

            _listParam.Add(New Datos.DParametro("@tipo", -1))
            _listParam.Add(New Datos.DParametro("@numi", _numi))
            _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

            _Tabla = D_ProcedimientoConParam("sp_go_TCS01", _listParam)

            If _Tabla.Rows.Count > 0 Then
                _numi = _Tabla.Rows(0).Item(0)
                _resultado = True
            Else
                _resultado = False
            End If
        Else
            _resultado = False
        End If

        Return _resultado
    End Function

#End Region

#Region "SUCURSAL"

    Public Shared Function L_prSucursalGeneral(Optional _Cadena As String = "", Optional _order As String = "") As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 3))
        _listParam.Add(New Datos.DParametro("@cauact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TC001", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prSucursalAyuda(Optional _Cadena As String = "", Optional _order As String = "") As DataTable

        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)
        _listParam.Add(New Datos.DParametro("@tipo", 4))
        _listParam.Add(New Datos.DParametro("@cauact", L_Usuario))
        _Tabla = D_ProcedimientoConParam("sp_dg_TC001", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prSucursalAyudaPorNumi(numi As String) As DataTable

        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)
        _listParam.Add(New Datos.DParametro("@tipo", 5))
        _listParam.Add(New Datos.DParametro("@canumi", numi))
        _listParam.Add(New Datos.DParametro("@cauact", L_Usuario))
        _Tabla = D_ProcedimientoConParam("sp_dg_TC001", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prSucursalGrabar(ByRef _numi As String, _desc As String, _concep1 As String, _concep2 As String, _concep3 As String, _concep4 As String, _ip As String, _cprac As String, _nrefor As String) As Boolean
        Dim _resultado As Boolean

        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 1))
        _listParam.Add(New Datos.DParametro("@canumi", _numi))
        _listParam.Add(New Datos.DParametro("@cadesc", _desc))
        _listParam.Add(New Datos.DParametro("@caconcep1", _concep1))
        _listParam.Add(New Datos.DParametro("@caconcep2", _concep2))
        _listParam.Add(New Datos.DParametro("@caconcep3", _concep3))
        _listParam.Add(New Datos.DParametro("@caconcep4", _concep4))
        _listParam.Add(New Datos.DParametro("@canprac", _cprac))
        _listParam.Add(New Datos.DParametro("@canrefor", _nrefor))
        _listParam.Add(New Datos.DParametro("@caip", _ip))
        _listParam.Add(New Datos.DParametro("@cauact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TC001", _listParam)

        If _Tabla.Rows.Count > 0 Then
            _numi = _Tabla.Rows(0).Item(0)
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function

    Public Shared Function L_prSucursalModificar(_numi As String, _desc As String, _concep1 As String, _concep2 As String, _concep3 As String, _concep4 As String, _ip As String, _cprac As String, _nrefor As String) As Boolean
        Dim _resultado As Boolean

        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 2))
        _listParam.Add(New Datos.DParametro("@canumi", _numi))
        _listParam.Add(New Datos.DParametro("@cadesc", _desc))
        _listParam.Add(New Datos.DParametro("@caconcep1", _concep1))
        _listParam.Add(New Datos.DParametro("@caconcep2", _concep2))
        _listParam.Add(New Datos.DParametro("@caconcep3", _concep3))
        _listParam.Add(New Datos.DParametro("@caconcep4", _concep4))
        _listParam.Add(New Datos.DParametro("@caip", _ip))
        _listParam.Add(New Datos.DParametro("@canprac", _cprac))
        _listParam.Add(New Datos.DParametro("@canrefor", _nrefor))
        _listParam.Add(New Datos.DParametro("@cauact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TC001", _listParam)

        If _Tabla.Rows.Count > 0 Then
            _numi = _Tabla.Rows(0).Item(0)
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function

    Public Shared Function L_prSucursalBorrar(_numi As String, ByRef _mensaje As String) As Boolean
        Dim _resultado As Boolean

        If L_fnbValidarEliminacion(_numi, "TC001", "numi", _mensaje) = True Then
            Dim _Tabla As DataTable

            Dim _listParam As New List(Of Datos.DParametro)

            _listParam.Add(New Datos.DParametro("@tipo", -1))
            _listParam.Add(New Datos.DParametro("@canumi", _numi))
            _listParam.Add(New Datos.DParametro("@cauact", L_Usuario))

            _Tabla = D_ProcedimientoConParam("sp_dg_TC001", _listParam)

            If _Tabla.Rows.Count > 0 Then
                _numi = _Tabla.Rows(0).Item(0)
                _resultado = True
            Else
                _resultado = False
            End If
        Else
            _resultado = False
        End If

        Return _resultado

    End Function


#End Region

#Region "SOCIO PAGOS"

    Public Shared Function L_fnSocioDetallePagos(numi As String, Optional ano As String = "") As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 3))
        _listParam.Add(New Datos.DParametro("@numi", numi))
        If (Not ano.Equals("")) Then
            _listParam.Add(New Datos.DParametro("@ano", ano))
        End If
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_go_TCS014", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_fnSocioDetallePagosUltimoDosAnho(numi As String, Optional ano As String = "") As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 4))
        _listParam.Add(New Datos.DParametro("@numi", numi))
        _listParam.Add(New Datos.DParametro("@ano", ano))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_go_TCS014", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_fnSocioDetallePagosMortuoriaUltimoDosAnho(numi As String, Optional ano As String = "") As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 9))
        _listParam.Add(New Datos.DParametro("@numi", numi))
        _listParam.Add(New Datos.DParametro("@ano", ano))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_go_TCS014", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_fnSocioDetallePagosMortuoria(numi As String, Optional ano As String = "") As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 10))
        _listParam.Add(New Datos.DParametro("@numi", numi))
        If (Not ano.Equals("")) Then
            _listParam.Add(New Datos.DParametro("@ano", ano))
        End If
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_go_TCS014", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_fnSocioPagosMortuoriaGrabarAnho(ByRef numi As String, ano As String) As Boolean
        Dim _resultado As Boolean

        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 11))
        _listParam.Add(New Datos.DParametro("@numi", numi))
        _listParam.Add(New Datos.DParametro("@ano", ano))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_go_TCS014", _listParam)

        If _Tabla.Rows.Count > 0 Then
            numi = _Tabla.Rows(0).Item(0)
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function

    Public Shared Function L_fnSocioObtenerPagosNoCorresponde(numi As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 13))
        _listParam.Add(New Datos.DParametro("@numi", numi))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_go_TCS014", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_fnSocioObtenerPagosMortuoriaNoCorresponde(numi As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 14))
        _listParam.Add(New Datos.DParametro("@numi", numi))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_go_TCS014", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_fnSocioObtenerDetallePagoFactura(numi As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 21))
        _listParam.Add(New Datos.DParametro("@vcnumi", numi))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_go_TCS014", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_fnSocioObtenerEstadoFactura() As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 24))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_go_TCS014", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_fnSocioPagosGrabarAnho(ByRef numi As String, ano As String) As Boolean
        Dim _resultado As Boolean

        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 2))
        _listParam.Add(New Datos.DParametro("@numi", numi))
        _listParam.Add(New Datos.DParametro("@ano", ano))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_go_TCS014", _listParam)

        If _Tabla.Rows.Count > 0 Then
            numi = _Tabla.Rows(0).Item(0)
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function

    Public Shared Function L_fnSocioPagosGrabar(ByRef numi As String, dt As DataTable, dt2 As DataTable,
                                                _vcnumi As Integer) As Boolean
        Dim _resultado As Boolean

        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 1))
        _listParam.Add(New Datos.DParametro("@numi", numi))
        _listParam.Add(New Datos.DParametro("@TCS014", "", dt))
        _listParam.Add(New Datos.DParametro("@TCS015", "", dt2))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))
        _listParam.Add(New Datos.DParametro("@vcnumi", _vcnumi))

        _Tabla = D_ProcedimientoConParam("sp_go_TCS014", _listParam)

        If _Tabla.Rows.Count > 0 Then
            numi = _Tabla.Rows(0).Item(0)
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function
    Public Shared Function L_fnTieneDosificacionAutomatica(sucursal As Integer, fecha As String, modulo As Integer) As DataTable
        Dim _resultado As Boolean

        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 26))
        _listParam.Add(New Datos.DParametro("@sucursal", sucursal))
        _listParam.Add(New Datos.DParametro("@vcfdoc", fecha))
        _listParam.Add(New Datos.DParametro("@modulo", modulo))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_go_TCS014", _listParam)



        Return _Tabla
    End Function

    Public Shared Function L_fnSocioVentaDicontaPagosGrabar(ByRef numiventa As String, numiSocio As Integer, total As Double, fecha As String, obs As String) As Boolean
        Dim _resultado As Boolean

        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 20))
        _listParam.Add(New Datos.DParametro("@vcnumi", numiventa))
        _listParam.Add(New Datos.DParametro("@numi", numiSocio))
        _listParam.Add(New Datos.DParametro("@total", total))
        _listParam.Add(New Datos.DParametro("@fec", fecha))
        _listParam.Add(New Datos.DParametro("@obs", obs))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_go_TCS014", _listParam)

        If _Tabla.Rows.Count > 0 Then
            numiventa = _Tabla.Rows(0).Item(0)
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function



#Region "PR_Pagos"

    Public Shared Function L_fnSocioPagosReporteComboSocio() As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 9))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_go_TCS01", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_fnSocioPagosReporteComboAbho() As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 10))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_go_TCS01", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_fnSocioPagosReportePagos(numi As String, anho As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 5))
        _listParam.Add(New Datos.DParametro("@numi", numi))
        _listParam.Add(New Datos.DParametro("@ano", anho))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_go_TCS014", _listParam)

        Return _Tabla
    End Function

#End Region

#Region "PR_PagosMora"

    Public Shared Function L_fnSocioPagosMoraReporteGeneral(num As String, numi As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 6))
        _listParam.Add(New Datos.DParametro("@est", num))
        _listParam.Add(New Datos.DParametro("@numi", numi))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_go_TCS014", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_fnSocioPagosMoraReporteSoloSinMora(num As String, numi As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 6))
        _listParam.Add(New Datos.DParametro("@est", num))
        _listParam.Add(New Datos.DParametro("@numi", numi))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_go_TCS014", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_fnSocioPagosMoraReporteSoloMora(num As String, numi As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 6))
        _listParam.Add(New Datos.DParametro("@est", num))
        _listParam.Add(New Datos.DParametro("@numi", numi))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_go_TCS014", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_fnSocioPagosMoraReporteSoloInactivos(num As String, numi As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 6))
        _listParam.Add(New Datos.DParametro("@est", num))
        _listParam.Add(New Datos.DParametro("@numi", numi))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_go_TCS014", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_fnSocioPagosMoraReporteCantidadMeses(num As String, cant As String, numi As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 6))
        _listParam.Add(New Datos.DParametro("@est", num))
        _listParam.Add(New Datos.DParametro("@lin", cant))
        _listParam.Add(New Datos.DParametro("@numi", numi))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_go_TCS014", _listParam)

        Return _Tabla
    End Function


#End Region

#Region "PR_PagosMortuoria"

    Public Shared Function L_fnSocioPagosMortuoriaReporteGeneral(num As String, numi As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 7))
        _listParam.Add(New Datos.DParametro("@est", num))
        _listParam.Add(New Datos.DParametro("@numi", numi))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_go_TCS014", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_fnSocioPagosMortuoriaReporteSoloSinMora(num As String, numi As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 7))
        _listParam.Add(New Datos.DParametro("@est", num))
        _listParam.Add(New Datos.DParametro("@numi", numi))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_go_TCS014", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_fnSocioPagosMortuoriaReporteSoloMora(num As String, numi As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 7))
        _listParam.Add(New Datos.DParametro("@est", num))
        _listParam.Add(New Datos.DParametro("@numi", numi))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_go_TCS014", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_fnSocioPagosMortuoriaReporteSoloInactivos(num As String, numi As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 7))
        _listParam.Add(New Datos.DParametro("@est", num))
        _listParam.Add(New Datos.DParametro("@numi", numi))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_go_TCS014", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_fnSocioPagosMortuoriaReporteCantidadMeses(num As String, cant As String, numi As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 7))
        _listParam.Add(New Datos.DParametro("@est", num))
        _listParam.Add(New Datos.DParametro("@lin", cant))
        _listParam.Add(New Datos.DParametro("@numi", numi))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_go_TCS014", _listParam)

        Return _Tabla
    End Function


#End Region

#Region "PR_PagosMortuoriaGestionesPagadas"

    Public Shared Function L_fnSocioPagosMortuoriaGestionesPagadasReporteGeneral() As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 8))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_go_TCS014", _listParam)

        Return _Tabla
    End Function

#End Region

#End Region

#Region "PR_SocioListaSociosActivos"

    Public Shared Function L_fnSocioReporteSocioListaSociosActivos(tsoc As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 11))
        _listParam.Add(New Datos.DParametro("@numi", tsoc))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_go_TCS01", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_fnSocioReporteSocioListaSociosActivosDetalle(numi As String, filtro As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 12))
        _listParam.Add(New Datos.DParametro("@numi", numi))
        _listParam.Add(New Datos.DParametro("@filtro", filtro))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_go_TCS01", _listParam)

        Return _Tabla
    End Function

#End Region

#Region "INSCRIPCION"

    Public Shared Function L_prInscripcionGeneral(Optional _Cadena As String = "", Optional _order As String = "") As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 3))
        _listParam.Add(New Datos.DParametro("@efuact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE005", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prInscripcionGrabar(ByRef _numi As String, _alum As String, _fecha As String, _servicio As String, _nroIng As String, _obs As String) As Boolean
        Dim _resultado As Boolean

        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 1))
        _listParam.Add(New Datos.DParametro("@efnumi", _numi))
        _listParam.Add(New Datos.DParametro("@efalum", _alum))
        _listParam.Add(New Datos.DParametro("@effech", _fecha))
        _listParam.Add(New Datos.DParametro("@efserv", _servicio))
        _listParam.Add(New Datos.DParametro("@efning", _nroIng))
        _listParam.Add(New Datos.DParametro("@efobs", _obs))
        _listParam.Add(New Datos.DParametro("@efuact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE005", _listParam)

        If _Tabla.Rows.Count > 0 Then
            _numi = _Tabla.Rows(0).Item(0)
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function

    Public Shared Function L_prInscripcionModificar(ByRef _numi As String, _alum As String, _fecha As String, _servicio As String, _nroIng As String, _obs As String) As Boolean
        Dim _resultado As Boolean

        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 1))
        _listParam.Add(New Datos.DParametro("@efnumi", _numi))
        _listParam.Add(New Datos.DParametro("@efalum", _alum))
        _listParam.Add(New Datos.DParametro("@effech", _fecha))
        _listParam.Add(New Datos.DParametro("@efserv", _servicio))
        _listParam.Add(New Datos.DParametro("@efning", _nroIng))
        _listParam.Add(New Datos.DParametro("@efobs", _obs))
        _listParam.Add(New Datos.DParametro("@efuact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE005", _listParam)

        If _Tabla.Rows.Count > 0 Then
            _numi = _Tabla.Rows(0).Item(0)
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function

    Public Shared Function L_prInscripcionBorrar(_numi As String, ByRef _mensaje As String) As Boolean

        Dim _resultado As Boolean

        If L_fnbValidarEliminacion(_numi, "TCE005", "efnumi", _mensaje) = True Then
            Dim _Tabla As DataTable

            Dim _listParam As New List(Of Datos.DParametro)

            _listParam.Add(New Datos.DParametro("@tipo", -1))
            _listParam.Add(New Datos.DParametro("@efnumi", _numi))
            _listParam.Add(New Datos.DParametro("@efuact", L_Usuario))

            _Tabla = D_ProcedimientoConParam("sp_dg_TCE005", _listParam)

            If _Tabla.Rows.Count > 0 Then
                _numi = _Tabla.Rows(0).Item(0)
                _resultado = True
            Else
                _resultado = False
            End If
        Else
            _resultado = False
        End If

        Return _resultado
    End Function

#End Region

#Region "CLASES PRACTICAS"

    Public Shared Function L_prHoraLibreTCE0062GetPorInstructor(_numiInstr As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 34))
        _listParam.Add(New Datos.DParametro("@egchof", _numiInstr))
        _listParam.Add(New Datos.DParametro("@eguact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE006", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prHoraDiligenciaTCE0063GetPorInstructor(_numiInstr As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 35))
        _listParam.Add(New Datos.DParametro("@egchof", _numiInstr))
        _listParam.Add(New Datos.DParametro("@eguact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE006", _listParam)

        Return _Tabla
    End Function
    Public Shared Function L_prClasesPracCambioInstructorConDataTable(numiInstr1 As String, numiInstr2 As String, dt2 As DataTable, dtLiberadas2 As DataTable, dtDiligencia2 As DataTable) As Boolean
        Dim _resultado As Boolean

        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 33))
        _listParam.Add(New Datos.DParametro("@numiChof1", numiInstr1))
        _listParam.Add(New Datos.DParametro("@numiChof2", numiInstr2))
        _listParam.Add(New Datos.DParametro("@TCE006", "", dt2))
        _listParam.Add(New Datos.DParametro("@TCE0062", "", dtLiberadas2))
        _listParam.Add(New Datos.DParametro("@TCE0063", "", dtDiligencia2))

        _listParam.Add(New Datos.DParametro("@eguact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE006", _listParam)

        If _Tabla.Rows.Count > 0 Then
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function


    Public Shared Function L_prClasesPracCambioInstructor(numiInstr1 As String, numiInstr2 As String) As Boolean
        Dim _resultado As Boolean

        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 31))
        _listParam.Add(New Datos.DParametro("@numiChof1", numiInstr1))
        _listParam.Add(New Datos.DParametro("@numiChof2", numiInstr2))
        _listParam.Add(New Datos.DParametro("@eguact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE006", _listParam)

        If _Tabla.Rows.Count > 0 Then
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function


    Public Shared Function L_prClasesPracObtenerPorInstructor(numiInstr As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 32))
        _listParam.Add(New Datos.DParametro("@numiChof1", numiInstr))
        _listParam.Add(New Datos.DParametro("@eguact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE006", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prClasesPracDetFechasEsctructuraGeneral() As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 6))
        _listParam.Add(New Datos.DParametro("@eguact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE006", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prClasesPracDetFechasPorAlumnoGeneral(_numiInst As String, _numiAlum As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 5))
        _listParam.Add(New Datos.DParametro("@egchof", _numiInst))
        _listParam.Add(New Datos.DParametro("@egalum", _numiAlum))
        _listParam.Add(New Datos.DParametro("@eguact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE006", _listParam)

        Return _Tabla
    End Function
    Public Shared Function L_prClasesPracDetPorInstructor(_numiInst As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 18))
        _listParam.Add(New Datos.DParametro("@egchof", _numiInst))
        _listParam.Add(New Datos.DParametro("@eguact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE006", _listParam)

        Return _Tabla
    End Function
    Public Shared Function L_prClasesPracDetFechasPorAlumnoYFechaGeneral(_numiInst As String, _numiAlum As String, _fecha As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 51))
        _listParam.Add(New Datos.DParametro("@egchof", _numiInst))
        _listParam.Add(New Datos.DParametro("@egalum", _numiAlum))
        _listParam.Add(New Datos.DParametro("@fecha", _fecha))
        _listParam.Add(New Datos.DParametro("@eguact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE006", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prClasesPracDetFechasPorAlumnoYFechaGeneral_FiltradoPorSoloChofer(_numiInst As String, _fecha As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 513))
        _listParam.Add(New Datos.DParametro("@egchof", _numiInst))
        _listParam.Add(New Datos.DParametro("@fecha", _fecha))
        _listParam.Add(New Datos.DParametro("@eguact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE006", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prClasesPracDetFechasPorAlumnoYFechaGeneralContables(_numiInst As String, _numiAlum As String, _fecha As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 511))
        _listParam.Add(New Datos.DParametro("@egchof", _numiInst))
        _listParam.Add(New Datos.DParametro("@egalum", _numiAlum))
        _listParam.Add(New Datos.DParametro("@fecha", _fecha))
        _listParam.Add(New Datos.DParametro("@eguact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE006", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prClasesPracDetFechasPorAlumnoYFechaGeneralContables_FiltradoPorSoloChofer(_numiInst As String, _fecha As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 514))
        _listParam.Add(New Datos.DParametro("@egchof", _numiInst))
        _listParam.Add(New Datos.DParametro("@fecha", _fecha))
        _listParam.Add(New Datos.DParametro("@eguact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE006", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prClasesPracDetFechasPorAlumnoYFechaGeneralContablesMenorAUnaFechaYHoraX(_numiInst As String, _numiAlum As String, _fecha As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 512))
        _listParam.Add(New Datos.DParametro("@egchof", _numiInst))
        _listParam.Add(New Datos.DParametro("@egalum", _numiAlum))
        _listParam.Add(New Datos.DParametro("@ehhfec", _fecha))
        '_listParam.Add(New Datos.DParametro("@ehhhor", _hora))
        _listParam.Add(New Datos.DParametro("@eguact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE006", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prClasesPracGrabar(ByRef _numi As String, _alum As String, _fecha As String, _servicio As String, _nroIng As String, _obs As String) As Boolean
        Dim _resultado As Boolean

        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 1))
        _listParam.Add(New Datos.DParametro("@efnumi", _numi))
        _listParam.Add(New Datos.DParametro("@efalum", _alum))
        _listParam.Add(New Datos.DParametro("@effech", _fecha))
        _listParam.Add(New Datos.DParametro("@efserv", _servicio))
        _listParam.Add(New Datos.DParametro("@efning", _nroIng))
        _listParam.Add(New Datos.DParametro("@efobs", _obs))
        _listParam.Add(New Datos.DParametro("@efuact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE005", _listParam)

        If _Tabla.Rows.Count > 0 Then
            _numi = _Tabla.Rows(0).Item(0)
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function

    Public Shared Function L_prClasesPracCabeceraDetalleGrabar(ByRef _numi As String, _numiChof As String, _numiAlum As String, _estado As String, _TCE0061 As DataTable) As Boolean
        Dim _resultado As Boolean

        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 4))
        _listParam.Add(New Datos.DParametro("@egnumi", _numi))
        _listParam.Add(New Datos.DParametro("@egchof", _numiChof))
        _listParam.Add(New Datos.DParametro("@egalum", _numiAlum))
        _listParam.Add(New Datos.DParametro("@egest", _estado))
        _listParam.Add(New Datos.DParametro("@TCE0061", "", _TCE0061))
        _listParam.Add(New Datos.DParametro("@eguact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE006", _listParam)

        If _Tabla.Rows.Count > 0 Then
            _numi = _Tabla.Rows(0).Item(0)
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function

    Public Shared Function L_prClasesPracCabeceraDetalleGrabar2(ByRef _numi As String, _numiChof As String, _numiAlum As String, _estado As String, numClasPrac As String, numClasRef As String, _TCE0061 As DataTable) As Boolean
        Dim _resultado As Boolean

        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 4))
        _listParam.Add(New Datos.DParametro("@egnumi", _numi))
        _listParam.Add(New Datos.DParametro("@egchof", _numiChof))
        _listParam.Add(New Datos.DParametro("@egalum", _numiAlum))
        _listParam.Add(New Datos.DParametro("@egest", _estado))
        _listParam.Add(New Datos.DParametro("@egnclsprac", numClasPrac))
        _listParam.Add(New Datos.DParametro("@egnclsref", numClasRef))
        _listParam.Add(New Datos.DParametro("@TCE0061", "", _TCE0061))
        _listParam.Add(New Datos.DParametro("@eguact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE006", _listParam)

        If _Tabla.Rows.Count > 0 Then
            _numi = _Tabla.Rows(0).Item(0)
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function

    Public Shared Function L_prClasesPracDetalleGrabar(ByRef _numi As String, _numiChof As String, _numiAlum As String, _estadoTipoClase As String, _TCE0061 As DataTable) As Boolean
        Dim _resultado As Boolean

        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 42))
        _listParam.Add(New Datos.DParametro("@egnumi", _numi))
        _listParam.Add(New Datos.DParametro("@egchof", _numiChof))
        _listParam.Add(New Datos.DParametro("@egalum", _numiAlum))
        _listParam.Add(New Datos.DParametro("@egest", _estadoTipoClase))
        _listParam.Add(New Datos.DParametro("@TCE0061", "", _TCE0061))
        _listParam.Add(New Datos.DParametro("@eguact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE006", _listParam)

        If _Tabla.Rows.Count > 0 Then
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function

    Public Shared Function L_prClasesPracDetalleGrabar2(ByRef _numi As String, _numiChof As String, _numiAlum As String, _estadoTipoClase As String, numClasPrac As String, numClasRef As String, _TCE0061 As DataTable) As Boolean
        Dim _resultado As Boolean

        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 42))
        _listParam.Add(New Datos.DParametro("@egnumi", _numi))
        _listParam.Add(New Datos.DParametro("@egchof", _numiChof))
        _listParam.Add(New Datos.DParametro("@egalum", _numiAlum))
        _listParam.Add(New Datos.DParametro("@egest", _estadoTipoClase))
        _listParam.Add(New Datos.DParametro("@egnclsprac", numClasPrac))
        _listParam.Add(New Datos.DParametro("@egnclsref", numClasRef))
        _listParam.Add(New Datos.DParametro("@TCE0061", "", _TCE0061))
        _listParam.Add(New Datos.DParametro("@eguact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE006", _listParam)

        If _Tabla.Rows.Count > 0 Then
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function


    Public Shared Function L_prClasesPracDetalleModificarEstado(_TCE0061 As DataTable) As Boolean
        Dim _resultado As Boolean

        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 7))
        _listParam.Add(New Datos.DParametro("@TCE0061", "", _TCE0061))
        _listParam.Add(New Datos.DParametro("@eguact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE006", _listParam)

        If _Tabla.Rows.Count > 0 Then
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function

    Public Shared Function L_prClasesPracDetalleModificarEstado2(_numiInst As String, _numiAlum As String, _estadoClase As String) As Boolean
        Dim _resultado As Boolean

        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 21))
        _listParam.Add(New Datos.DParametro("@egchof", _numiInst))
        _listParam.Add(New Datos.DParametro("@egalum", _numiAlum))
        _listParam.Add(New Datos.DParametro("@ehest", _estadoClase))
        _listParam.Add(New Datos.DParametro("@eguact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE006", _listParam)

        If _Tabla.Rows.Count > 0 Then
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function

    Public Shared Function L_prClasesPracModificarEstadoCabecera(_numiCab As String, _estado As String) As Boolean
        Dim _resultado As Boolean

        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 211))
        _listParam.Add(New Datos.DParametro("@egest", _estado))
        _listParam.Add(New Datos.DParametro("@egnumi", _numiCab))
        _listParam.Add(New Datos.DParametro("@eguact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE006", _listParam)

        If _Tabla.Rows.Count > 0 Then
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function

    Public Shared Function L_prClasesPracCabeceraDetalleGrabarModificando(ByRef _numi As String, _numiChof As String, _numiAlum As String, _estado As String, _TCE0061 As DataTable) As Boolean
        Dim _resultado As Boolean

        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 41))
        _listParam.Add(New Datos.DParametro("@egnumi", _numi))
        _listParam.Add(New Datos.DParametro("@egchof", _numiChof))
        _listParam.Add(New Datos.DParametro("@egalum", _numiAlum))
        _listParam.Add(New Datos.DParametro("@egest", _estado))
        _listParam.Add(New Datos.DParametro("@TCE0061", "", _TCE0061))
        _listParam.Add(New Datos.DParametro("@eguact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE006", _listParam)

        If _Tabla.Rows.Count > 0 Then
            _numi = _Tabla.Rows(0).Item(0)
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function

    Public Shared Function L_prClasesPracModificar(ByRef _numi As String, _alum As String, _fecha As String, _servicio As String, _nroIng As String, _obs As String) As Boolean
        Dim _resultado As Boolean

        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 1))
        _listParam.Add(New Datos.DParametro("@efnumi", _numi))
        _listParam.Add(New Datos.DParametro("@efalum", _alum))
        _listParam.Add(New Datos.DParametro("@effech", _fecha))
        _listParam.Add(New Datos.DParametro("@efserv", _servicio))
        _listParam.Add(New Datos.DParametro("@efning", _nroIng))
        _listParam.Add(New Datos.DParametro("@efobs", _obs))
        _listParam.Add(New Datos.DParametro("@efuact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE005", _listParam)

        If _Tabla.Rows.Count > 0 Then
            _numi = _Tabla.Rows(0).Item(0)
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function

    Public Shared Function L_prClasesPracBorrar(_numi As String, ByRef _mensaje As String) As Boolean

        Dim _resultado As Boolean

        If L_fnbValidarEliminacion(_numi, "TCE005", "efnumi", _mensaje) = True Then
            Dim _Tabla As DataTable

            Dim _listParam As New List(Of Datos.DParametro)

            _listParam.Add(New Datos.DParametro("@tipo", -1))
            _listParam.Add(New Datos.DParametro("@efnumi", _numi))
            _listParam.Add(New Datos.DParametro("@efuact", L_Usuario))

            _Tabla = D_ProcedimientoConParam("sp_dg_TCE005", _listParam)

            If _Tabla.Rows.Count > 0 Then
                _numi = _Tabla.Rows(0).Item(0)
                _resultado = True
            Else
                _resultado = False
            End If
        Else
            _resultado = False
        End If

        Return _resultado
    End Function

    Public Shared Function L_prClasesPracDetFechasGetPorFechaHora(_fechas As String, _hora As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 8))
        _listParam.Add(New Datos.DParametro("@ehhfec", _fechas))
        _listParam.Add(New Datos.DParametro("@ehhhor", _hora))
        _listParam.Add(New Datos.DParametro("@eguact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE006", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prClasesPracDetFechasGetPorFechaHoraCompleto(_fechas As String, _hora As String, _numiInts As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 82))
        _listParam.Add(New Datos.DParametro("@ehhfec", _fechas))
        _listParam.Add(New Datos.DParametro("@ehhhor", _hora))
        _listParam.Add(New Datos.DParametro("@egchof", _numiInts))
        _listParam.Add(New Datos.DParametro("@eguact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE006", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prClasesPracDetFechasGetPorFechaHoraInstructor(_fechas As String, _hora As String, _numiInstr As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 81))
        _listParam.Add(New Datos.DParametro("@ehhfec", _fechas))
        _listParam.Add(New Datos.DParametro("@ehhhor", _hora))
        _listParam.Add(New Datos.DParametro("@egchof", _numiInstr))
        _listParam.Add(New Datos.DParametro("@eguact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE006", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prClasesPracDetFechasGetClasesConPermiso(_line As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 12))
        _listParam.Add(New Datos.DParametro("@egnumi", _line))
        _listParam.Add(New Datos.DParametro("@eguact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE006", _listParam)

        Return _Tabla
    End Function
    Public Shared Function L_prClasesPracGetEstructuraHorarios(_fecha As String, _numiSuc As String, _tipoHorario As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 13))
        _listParam.Add(New Datos.DParametro("@fecha", _fecha))
        _listParam.Add(New Datos.DParametro("@numiSuc", _numiSuc))
        _listParam.Add(New Datos.DParametro("@tipoHorario", _tipoHorario))
        _listParam.Add(New Datos.DParametro("@eguact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE006", _listParam)

        Return _Tabla
    End Function
    Public Shared Function L_prClasesPracGetEstructuraHorariosPorInstructor(_fecha As String, _numiSuc As String, _numiInst As String, _tipoHorario As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 15))
        _listParam.Add(New Datos.DParametro("@fecha", _fecha))
        _listParam.Add(New Datos.DParametro("@numiSuc", _numiSuc))
        _listParam.Add(New Datos.DParametro("@egchof", _numiInst))
        _listParam.Add(New Datos.DParametro("@tipoHorario", _tipoHorario))
        _listParam.Add(New Datos.DParametro("@eguact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE006", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prClasesPracDetGetHorasPorInst(_fecha As String, _numiInst As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 14))
        _listParam.Add(New Datos.DParametro("@ehhfec", _fecha))
        _listParam.Add(New Datos.DParametro("@egchof", _numiInst))
        _listParam.Add(New Datos.DParametro("@eguact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE006", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prClasesPracDetGetHorasPorInstConFaltasMas(_fecha As String, _numiInst As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 141))
        _listParam.Add(New Datos.DParametro("@ehhfec", _fecha))
        _listParam.Add(New Datos.DParametro("@egchof", _numiInst))
        _listParam.Add(New Datos.DParametro("@eguact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE006", _listParam)

        Return _Tabla
    End Function
    Public Shared Function L_prClasesGetInstructoresParaReporteHorasTrabajadas() As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 16))
        _listParam.Add(New Datos.DParametro("@eguact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE006", _listParam)

        Return _Tabla
    End Function
    Public Shared Function L_prClasesGetInstructoresParaReporteHorasTrabajadasSucursales() As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 17))
        _listParam.Add(New Datos.DParametro("@eguact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE006", _listParam)

        Return _Tabla
    End Function

#Region "TCE0062"

    Public Shared Function L_prHoraLibreTCE0062Eliminar(_numiHoraLib As String) As Boolean
        Dim _resultado As Boolean

        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 20))
        _listParam.Add(New Datos.DParametro("@egnumi", _numiHoraLib))
        _listParam.Add(New Datos.DParametro("@eguact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE006", _listParam)

        If _Tabla.Rows.Count > 0 Then
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function

    Public Shared Function L_prHoraDiligenciaTCE0063Eliminar(_numiHoraLDilig As String) As Boolean
        Dim _resultado As Boolean

        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 2001))
        _listParam.Add(New Datos.DParametro("@egnumi", _numiHoraLDilig))
        _listParam.Add(New Datos.DParametro("@eguact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE006", _listParam)

        If _Tabla.Rows.Count > 0 Then
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function


    Public Shared Function L_prHoraLibreTCE0062GrabarPorInstructor(_TCE0062 As DataTable, _obs As String) As Boolean
        Dim _resultado As Boolean

        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 9))
        _listParam.Add(New Datos.DParametro("@ehhobs", _obs))
        _listParam.Add(New Datos.DParametro("@TCE0062", "", _TCE0062))
        _listParam.Add(New Datos.DParametro("@eguact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE006", _listParam)

        If _Tabla.Rows.Count > 0 Then
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function

    Public Shared Function L_prHoraDiligenciaTCE0063GrabarPorInstructor(_TCE0063 As DataTable, _obs As String) As Boolean
        Dim _resultado As Boolean

        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 901))
        _listParam.Add(New Datos.DParametro("@ehhobs", _obs))
        _listParam.Add(New Datos.DParametro("@TCE0063", "", _TCE0063))
        _listParam.Add(New Datos.DParametro("@eguact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE006", _listParam)

        If _Tabla.Rows.Count > 0 Then
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function

    Public Shared Function L_prHoraLibreTCE0062GrabarTodosInstructoresPorSucursal(_TCE0062 As DataTable, _numiSuc As String, _obs As String) As Boolean
        Dim _resultado As Boolean
        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 91))
        _listParam.Add(New Datos.DParametro("@numiSuc", _numiSuc))
        _listParam.Add(New Datos.DParametro("@ehhobs", _obs))
        _listParam.Add(New Datos.DParametro("@TCE0062", "", _TCE0062))
        _listParam.Add(New Datos.DParametro("@eguact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE006", _listParam)

        If _Tabla.Rows.Count > 0 Then
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function

    Public Shared Function L_prHoraLibreTCE0062GetPorFechaInstructor(_fecha As String, _numiInstr As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 10))
        _listParam.Add(New Datos.DParametro("@fecha", _fecha))
        _listParam.Add(New Datos.DParametro("@egchof", _numiInstr))
        _listParam.Add(New Datos.DParametro("@eguact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE006", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prHoraDiligenciaTCE0063GetPorFechaInstructor(_fecha As String, _numiInstr As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 1001))
        _listParam.Add(New Datos.DParametro("@fecha", _fecha))
        _listParam.Add(New Datos.DParametro("@egchof", _numiInstr))
        _listParam.Add(New Datos.DParametro("@eguact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE006", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prHoraLibreTCE0062GetPorRangoFechaInstructor(_fechaDel As String, _fechaAl As String, _numiInstr As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 101))
        _listParam.Add(New Datos.DParametro("@fecha1", _fechaDel))
        _listParam.Add(New Datos.DParametro("@fecha2", _fechaAl))
        _listParam.Add(New Datos.DParametro("@egchof", _numiInstr))
        _listParam.Add(New Datos.DParametro("@eguact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE006", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prHoraDiligenciaTCE0063GetPorRangoFechaInstructor(_fechaDel As String, _fechaAl As String, _numiInstr As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 10101))
        _listParam.Add(New Datos.DParametro("@fecha1", _fechaDel))
        _listParam.Add(New Datos.DParametro("@fecha2", _fechaAl))
        _listParam.Add(New Datos.DParametro("@egchof", _numiInstr))
        _listParam.Add(New Datos.DParametro("@eguact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE006", _listParam)

        Return _Tabla
    End Function
#End Region

#End Region

#Region "CLASES PERFECCIONAMIENTO"

    Public Shared Function L_prClasesPracDetFechasEsctructuraGeneralR() As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 6))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE014", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prClasesPracDetFechasPorAlumnoGeneralR(_numiInst As String, _numiAlum As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 5))
        _listParam.Add(New Datos.DParametro("@egchof", _numiInst))
        _listParam.Add(New Datos.DParametro("@egalum", _numiAlum))
        _listParam.Add(New Datos.DParametro("@eguact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE006", _listParam)

        Return _Tabla
    End Function
    Public Shared Function L_prClasesPracDetFechasPorAlumnoYFechaGeneralR(_numiInst As String, _numiAlum As String, _fecha As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 51))
        _listParam.Add(New Datos.DParametro("@eqchof", _numiInst))
        _listParam.Add(New Datos.DParametro("@eqalum", _numiAlum))
        _listParam.Add(New Datos.DParametro("@fecha", _fecha))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE014", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prClasesPracDetFechasPorAlumnoYFechaGeneralContablesR(_numiInst As String, _numiAlum As String, _fecha As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 511))
        _listParam.Add(New Datos.DParametro("@eqchof", _numiInst))
        _listParam.Add(New Datos.DParametro("@eqalum", _numiAlum))
        _listParam.Add(New Datos.DParametro("@fecha", _fecha))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE014", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prClasesPracGrabarR(ByRef _numi As String, _alum As String, _fecha As String, _servicio As String, _nroIng As String, _obs As String) As Boolean
        Dim _resultado As Boolean

        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 1))
        _listParam.Add(New Datos.DParametro("@efnumi", _numi))
        _listParam.Add(New Datos.DParametro("@efalum", _alum))
        _listParam.Add(New Datos.DParametro("@effech", _fecha))
        _listParam.Add(New Datos.DParametro("@efserv", _servicio))
        _listParam.Add(New Datos.DParametro("@efning", _nroIng))
        _listParam.Add(New Datos.DParametro("@efobs", _obs))
        _listParam.Add(New Datos.DParametro("@efuact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE005", _listParam)

        If _Tabla.Rows.Count > 0 Then
            _numi = _Tabla.Rows(0).Item(0)
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function

    Public Shared Function L_prClasesPracCabeceraDetalleGrabarR(ByRef _numi As String, _numiChof As String, _numiAlum As String, _estado As String, _nroFact As String, _obs As String, _cant As String, _TCE0141 As DataTable) As Boolean
        Dim _resultado As Boolean

        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 4))
        _listParam.Add(New Datos.DParametro("@eqnumi", _numi))
        _listParam.Add(New Datos.DParametro("@eqchof", _numiChof))
        _listParam.Add(New Datos.DParametro("@eqalum", _numiAlum))
        _listParam.Add(New Datos.DParametro("@eqest", _estado))
        _listParam.Add(New Datos.DParametro("@eqznfact", _nroFact))
        _listParam.Add(New Datos.DParametro("@eqobs", _obs))
        _listParam.Add(New Datos.DParametro("@eqcant", _cant))
        _listParam.Add(New Datos.DParametro("@TCE0141", "", _TCE0141))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE014", _listParam)

        If _Tabla.Rows.Count > 0 Then
            _numi = _Tabla.Rows(0).Item(0)
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function

    Public Shared Function L_prClasesPracDetalleGrabarR(ByRef _numi As String, _numiChof As String, _numiAlum As String, _TCE0141 As DataTable) As Boolean
        Dim _resultado As Boolean

        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 42))
        _listParam.Add(New Datos.DParametro("@eqnumi", _numi))
        _listParam.Add(New Datos.DParametro("@eqchof", _numiChof))
        _listParam.Add(New Datos.DParametro("@eqalum", _numiAlum))
        _listParam.Add(New Datos.DParametro("@TCE0141", "", _TCE0141))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE014", _listParam)

        If _Tabla.Rows.Count > 0 Then
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function

    Public Shared Function L_prClasesPracDetalleModificarEstadoR(_TCE0141 As DataTable) As Boolean
        Dim _resultado As Boolean

        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 7))
        _listParam.Add(New Datos.DParametro("@TCE0141", "", _TCE0141))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE014", _listParam)

        If _Tabla.Rows.Count > 0 Then
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function

    Public Shared Function L_prClasesPracDetalleModificarEstado2R(_numiInst As String, _numiAlum As String, _estadoClase As String) As Boolean
        Dim _resultado As Boolean

        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 21))
        _listParam.Add(New Datos.DParametro("@eqchof", _numiInst))
        _listParam.Add(New Datos.DParametro("@eqalum", _numiAlum))
        _listParam.Add(New Datos.DParametro("@erest", _estadoClase))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE014", _listParam)

        If _Tabla.Rows.Count > 0 Then
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function

    Public Shared Function L_prClasesPracModificarEstadoCabeceraR(_numiCab As String, _estado As String) As Boolean
        Dim _resultado As Boolean

        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 211))
        _listParam.Add(New Datos.DParametro("@eqest", _estado))
        _listParam.Add(New Datos.DParametro("@eqnumi", _numiCab))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE014", _listParam)

        If _Tabla.Rows.Count > 0 Then
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function

    Public Shared Function L_prClasesPracCabeceraDetalleGrabarModificandoR(ByRef _numi As String, _numiChof As String, _numiAlum As String, _estado As String, _TCE0061 As DataTable) As Boolean
        Dim _resultado As Boolean

        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 41))
        _listParam.Add(New Datos.DParametro("@egnumi", _numi))
        _listParam.Add(New Datos.DParametro("@egchof", _numiChof))
        _listParam.Add(New Datos.DParametro("@egalum", _numiAlum))
        _listParam.Add(New Datos.DParametro("@egest", _estado))
        _listParam.Add(New Datos.DParametro("@TCE0061", "", _TCE0061))
        _listParam.Add(New Datos.DParametro("@eguact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE006", _listParam)

        If _Tabla.Rows.Count > 0 Then
            _numi = _Tabla.Rows(0).Item(0)
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function

    Public Shared Function L_prClasesPracModificarR(ByRef _numi As String, _alum As String, _fecha As String, _servicio As String, _nroIng As String, _obs As String) As Boolean
        Dim _resultado As Boolean

        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 1))
        _listParam.Add(New Datos.DParametro("@efnumi", _numi))
        _listParam.Add(New Datos.DParametro("@efalum", _alum))
        _listParam.Add(New Datos.DParametro("@effech", _fecha))
        _listParam.Add(New Datos.DParametro("@efserv", _servicio))
        _listParam.Add(New Datos.DParametro("@efning", _nroIng))
        _listParam.Add(New Datos.DParametro("@efobs", _obs))
        _listParam.Add(New Datos.DParametro("@efuact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE005", _listParam)

        If _Tabla.Rows.Count > 0 Then
            _numi = _Tabla.Rows(0).Item(0)
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function

    Public Shared Function L_prClasesPracBorrarR(_numi As String, ByRef _mensaje As String) As Boolean

        Dim _resultado As Boolean

        If L_fnbValidarEliminacion(_numi, "TCE014", "eqnumi", _mensaje) = True Then
            Dim _Tabla As DataTable

            Dim _listParam As New List(Of Datos.DParametro)

            _listParam.Add(New Datos.DParametro("@tipo", -1))
            _listParam.Add(New Datos.DParametro("@eqnumi", _numi))
            _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

            _Tabla = D_ProcedimientoConParam("sp_dg_TCE014", _listParam)

            If _Tabla.Rows.Count > 0 Then
                _numi = _Tabla.Rows(0).Item(0)
                _resultado = True
            Else
                _resultado = False
            End If
        Else
            _resultado = False
        End If

        Return _resultado
    End Function

    Public Shared Function L_prClasesPracDetFechasGetPorFechaHoraR(_fechas As String, _hora As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 8))
        _listParam.Add(New Datos.DParametro("@errfec", _fechas))
        _listParam.Add(New Datos.DParametro("@errhor", _hora))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE014", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prClasesPracDetFechasGetPorFechaHoraCompletoR(_fechas As String, _hora As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 82))
        _listParam.Add(New Datos.DParametro("@ehhfec", _fechas))
        _listParam.Add(New Datos.DParametro("@ehhhor", _hora))
        _listParam.Add(New Datos.DParametro("@eguact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE006", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prClasesPracDetFechasGetPorFechaHoraInstructorR(_fechas As String, _hora As String, _numiInstr As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 81))
        _listParam.Add(New Datos.DParametro("@errfec", _fechas))
        _listParam.Add(New Datos.DParametro("@errhor", _hora))
        _listParam.Add(New Datos.DParametro("@eqchof", _numiInstr))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE014", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prClasesPracDetFechasGetClasesConPermisoR(_line As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 12))
        _listParam.Add(New Datos.DParametro("@eqnumi", _line))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE014", _listParam)

        Return _Tabla
    End Function
    Public Shared Function L_prClasesPracGetEstructuraHorariosR(_fecha As String, _numiSuc As String, _tipoHorario As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 13))
        _listParam.Add(New Datos.DParametro("@fecha", _fecha))
        _listParam.Add(New Datos.DParametro("@numiSuc", _numiSuc))
        _listParam.Add(New Datos.DParametro("@tipoHorario", _tipoHorario))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE014", _listParam)

        Return _Tabla
    End Function
    Public Shared Function L_prClasesPracGetEstructuraHorariosPorInstructorR(_fecha As String, _numiSuc As String, _numiInst As String, _tipoHorario As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 15))
        _listParam.Add(New Datos.DParametro("@fecha", _fecha))
        _listParam.Add(New Datos.DParametro("@numiSuc", _numiSuc))
        _listParam.Add(New Datos.DParametro("@eqchof", _numiInst))
        _listParam.Add(New Datos.DParametro("@tipoHorario", _tipoHorario))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE014", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prClasesPracDetGetHorasPorInstR(_fecha As String, _numiInst As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 14))
        _listParam.Add(New Datos.DParametro("@errfec", _fecha))
        _listParam.Add(New Datos.DParametro("@eqchof", _numiInst))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE014", _listParam)

        Return _Tabla
    End Function

#Region "TCE0062"
    Public Shared Function L_prHoraLibreTCE0062GrabarPorInstructorR(_TCE0062 As DataTable, _obs As String) As Boolean
        Dim _resultado As Boolean

        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 9))
        _listParam.Add(New Datos.DParametro("@errobs", _obs))
        _listParam.Add(New Datos.DParametro("@TCE0142", "", _TCE0062))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE014", _listParam)

        If _Tabla.Rows.Count > 0 Then
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function

    Public Shared Function L_prHoraLibreTCE0062GrabarTodosInstructoresPorSucursalR(_TCE0142 As DataTable, _numiSuc As String, _obs As String) As Boolean
        Dim _resultado As Boolean
        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 91))
        _listParam.Add(New Datos.DParametro("@numiSuc", _numiSuc))
        _listParam.Add(New Datos.DParametro("@errobs", _obs))
        _listParam.Add(New Datos.DParametro("@TCE0142", "", _TCE0142))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE014", _listParam)

        If _Tabla.Rows.Count > 0 Then
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function

    Public Shared Function L_prHoraLibreTCE0062GetPorFechaInstructorR(_fecha As String, _numiInstr As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 10))
        _listParam.Add(New Datos.DParametro("@fecha", _fecha))
        _listParam.Add(New Datos.DParametro("@eqchof", _numiInstr))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE014", _listParam)

        Return _Tabla
    End Function
#End Region

#End Region

#Region "HORAS"

    Public Shared Function L_prHoraGeneral(Optional _Cadena As String = "", Optional _order As String = "") As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 3))
        _listParam.Add(New Datos.DParametro("@cbuact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TC002", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prHoraDetGeneral(_numi As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 4))
        _listParam.Add(New Datos.DParametro("@cbnumi", _numi))
        _listParam.Add(New Datos.DParametro("@cbuact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TC002", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prHoraDetDelMesGeneral(_fecha As String, _numiSuc As String, _tipo As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 5))
        _listParam.Add(New Datos.DParametro("@cbsuc", _numiSuc))
        _listParam.Add(New Datos.DParametro("@cbfecha", _fecha))
        _listParam.Add(New Datos.DParametro("@cbtipo", _tipo))
        _listParam.Add(New Datos.DParametro("@cbuact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TC002", _listParam)

        Return _Tabla
    End Function


    Public Shared Function L_prHoraGrabar(ByRef _numi As String, _fecha As String, _obs As String, _suc As String, _tipo As String, _TC0021 As DataTable) As Boolean
        Dim _resultado As Boolean

        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 1))
        _listParam.Add(New Datos.DParametro("@cbnumi", _numi))
        _listParam.Add(New Datos.DParametro("@cbfecha", _fecha))
        _listParam.Add(New Datos.DParametro("@cbobs", _obs))
        _listParam.Add(New Datos.DParametro("@cbsuc", _suc))
        _listParam.Add(New Datos.DParametro("@cbtipo", _tipo))
        _listParam.Add(New Datos.DParametro("@TC0021", "", _TC0021))
        _listParam.Add(New Datos.DParametro("@cbuact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TC002", _listParam)

        If _Tabla.Rows.Count > 0 Then
            _numi = _Tabla.Rows(0).Item(0)
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function

    Public Shared Function L_prHoraModificar(ByRef _numi As String, _fecha As String, _obs As String, _suc As String, _tipo As String, _TC0021 As DataTable) As Boolean
        Dim _resultado As Boolean

        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 2))
        _listParam.Add(New Datos.DParametro("@cbnumi", _numi))
        _listParam.Add(New Datos.DParametro("@cbfecha", _fecha))
        _listParam.Add(New Datos.DParametro("@cbobs", _obs))
        _listParam.Add(New Datos.DParametro("@cbsuc", _suc))
        _listParam.Add(New Datos.DParametro("@cbtipo", _tipo))
        _listParam.Add(New Datos.DParametro("@TC0021", "", _TC0021))
        _listParam.Add(New Datos.DParametro("@cbuact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TC002", _listParam)

        If _Tabla.Rows.Count > 0 Then
            _numi = _Tabla.Rows(0).Item(0)
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function

    Public Shared Function L_prHoraBorrar(_numi As String, ByRef _mensaje As String) As Boolean
        Dim _resultado As Boolean

        If L_fnbValidarEliminacion(_numi, "TC002", "cbnumi", _mensaje) = True Then
            Dim _Tabla As DataTable

            Dim _listParam As New List(Of Datos.DParametro)

            _listParam.Add(New Datos.DParametro("@tipo", -1))
            _listParam.Add(New Datos.DParametro("@cbnumi", _numi))
            _listParam.Add(New Datos.DParametro("@cbuact", L_Usuario))

            _Tabla = D_ProcedimientoConParam("sp_dg_TC002", _listParam)

            If _Tabla.Rows.Count > 0 Then
                _numi = _Tabla.Rows(0).Item(0)
                _resultado = True
            Else
                _resultado = False
            End If
        Else
            _resultado = False
        End If

        Return _resultado

    End Function


#End Region

#Region "PRE EXAMEN TCE007"
    Public Shared Function L_prPreExamenNotasGrabar(_numi As String, _TCE0071 As DataTable) As Boolean
        Dim _resultado As Boolean

        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 12))
        _listParam.Add(New Datos.DParametro("@ejnumi", _numi))
        _listParam.Add(New Datos.DParametro("@TCE0071", "", _TCE0071))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE007", _listParam)

        If _Tabla.Rows.Count > 0 Then
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function
    Public Shared Function L_prPreExamenDetalleGeneral(_numi As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 13))
        _listParam.Add(New Datos.DParametro("@ejnumi", _numi))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE007", _listParam)

        Return _Tabla
    End Function
    Public Shared Function L_prPreExamenAprobadosCertificadoPorNumiAlumno(_numiAlum As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 11))
        _listParam.Add(New Datos.DParametro("@ejalum", _numiAlum))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE007", _listParam)

        Return _Tabla
    End Function
    Public Shared Function L_prPreExamenObtenerTodosAlumnosAprobados() As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 10))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE007", _listParam)

        Return _Tabla
    End Function
    Public Shared Function L_prPreExamenAprobadosCertificadoPorNroGrupo(_nroGrupo As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 9))
        _listParam.Add(New Datos.DParametro("@nroGrupo", _nroGrupo))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE007", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prPreExamenAprovadosHastaFechaGeneral(_fecha As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 3))
        _listParam.Add(New Datos.DParametro("@ejfecha", _fecha))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE007", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prPreExamenGeneral() As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 4))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE007", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prPreExamenResportePreExamen(_fecha As String, _estado As String, _numiSuc As String, _conNota As String, Optional _numiInst As String = "") As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        If _numiInst = String.Empty Then
            _listParam.Add(New Datos.DParametro("@tipo", 5))
        Else
            _listParam.Add(New Datos.DParametro("@tipo", 6))
        End If

        _listParam.Add(New Datos.DParametro("@ejchof", _numiInst))
        _listParam.Add(New Datos.DParametro("@ejfecha", _fecha))
        _listParam.Add(New Datos.DParametro("@suc", _numiSuc))
        _listParam.Add(New Datos.DParametro("@ejestado", _estado))
        _listParam.Add(New Datos.DParametro("@conNota", _conNota))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE007", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prPreExamenResportePreExamenAntiguo(_fecha As String, _estado As String, _numiSuc As String, Optional _numiInst As String = "") As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        If _numiInst = String.Empty Then
            _listParam.Add(New Datos.DParametro("@tipo", 551))
        Else
            _listParam.Add(New Datos.DParametro("@tipo", 661))
        End If

        _listParam.Add(New Datos.DParametro("@ejchof", _numiInst))
        _listParam.Add(New Datos.DParametro("@ejfecha", _fecha))
        _listParam.Add(New Datos.DParametro("@suc", _numiSuc))
        _listParam.Add(New Datos.DParametro("@ejestado", _estado))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE007", _listParam)

        Return _Tabla
    End Function


    Public Shared Function L_prPreExamenResporteEstadoExamenes(_fecha As String, _estado As String, _numiInst As String, _numiSuc As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 7))
        _listParam.Add(New Datos.DParametro("@ejchof", _numiInst))
        _listParam.Add(New Datos.DParametro("@ejfecha", _fecha))
        _listParam.Add(New Datos.DParametro("@suc", _numiSuc))
        _listParam.Add(New Datos.DParametro("@ejestado", _estado))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE007", _listParam)

        Return _Tabla
    End Function


    Public Shared Function L_prPreExamenAlumnosSinPreExamen(_numiInst As String, _numiSuc As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 8))
        _listParam.Add(New Datos.DParametro("@ejchof", _numiInst))
        _listParam.Add(New Datos.DParametro("@suc", _numiSuc))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE007", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prPreExamenGrabarAsignados(_TCE007 As DataTable) As Boolean
        Dim _resultado As Boolean

        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 1))
        _listParam.Add(New Datos.DParametro("@TCE007", 0, _TCE007))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE007", _listParam)

        If _Tabla.Rows.Count > 0 Then
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function

    Public Shared Function L_prPreExamenModificar(_TCE007 As DataTable) As Boolean
        Dim _resultado As Boolean

        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 2))
        _listParam.Add(New Datos.DParametro("@TCE007", 0, _TCE007))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE007", _listParam)

        If _Tabla.Rows.Count > 0 Then
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function


#End Region

#Region "TCE000"

    Public Shared Function L_prTCE000General() As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 3))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE000", _listParam)

        Return _Tabla
    End Function

#End Region

#Region "CONTROL DE EXAMEN TEORICO TCE008"

    Public Shared Function L_prClasesTeoricoAlumnosFiltradosGeneral(_nroGrupo As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 3))
        _listParam.Add(New Datos.DParametro("@nroGrupo", _nroGrupo))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE008", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prClasesTeoricoReporte(_nroGrupo As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 7))
        _listParam.Add(New Datos.DParametro("@nroGrupo", _nroGrupo))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE008", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prClasesTeoricoModificar(_TCE008 As DataTable) As Boolean
        Dim _Tabla As DataTable
        Dim _resultado As Boolean

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 2))
        _listParam.Add(New Datos.DParametro("@TCE008", "", _TCE008))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE008", _listParam)

        If _Tabla.Rows.Count > 0 Then

            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function

    Public Shared Function L_prClasesTeoricoAlumnosGeneral(numiAlum As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 4))
        _listParam.Add(New Datos.DParametro("@ekalum", numiAlum))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE008", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prClasesSimuladorAlumnosGeneral(numiAlum As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 5))
        _listParam.Add(New Datos.DParametro("@ekalum", numiAlum))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE008", _listParam)

        Return _Tabla
    End Function
#End Region

#Region "TRAIDO CHACALTAYA"
#Region "Bonos Descuentos"

    Public Shared Function L_BonosDescuentosCabecera_General(_Modo As Integer, Optional _Cadena As String = "") As DataSet
        Dim _Tabla As DataTable
        Dim _Ds As New DataSet
        Dim _Where As String
        If _Modo = 0 Then
            _Where = "TP001.panumi=TP002.pbcper"
        Else
            _Where = "TP001.panumi=TP002.pbcper " + _Cadena
        End If
        _Tabla = D_Datos_Tabla("TP002.pbnumi,TP002.pbcper,CONCAT(TP001.panom,' ',TP001.paape) as cbdesc,TP002.pbano,TP002.pbmes", "TP002,TP001", _Where + " order by TP002.pbnumi")
        _Ds.Tables.Add(_Tabla)
        Return _Ds
    End Function

    Public Shared Sub L_BonosDescuentosCabecera_Grabar(ByRef _numi As String, _codPersona As String, _año As String, _mes As String)
        Dim _Actualizacion As String
        Dim _Err As Boolean
        Dim _Tabla As DataTable
        _Tabla = D_Maximo("TP002", "pbnumi", "pbnumi=pbnumi")
        If Not IsDBNull(_Tabla.Rows(0).Item(0)) Then
            _numi = _Tabla.Rows(0).Item(0) + 1
        Else
            _numi = "1"
        End If

        _Actualizacion = "'" + Date.Now.Date.ToString("yyyy/MM/dd") + "', '" + Now.Hour.ToString + ":" + Now.Minute.ToString + "' ,'" + L_Usuario + "'"

        Dim Sql As String
        Sql = _numi + "," + _codPersona + "," + _año + "," + _mes + "," + _Actualizacion
        _Err = D_Insertar_Datos("TP002", Sql)
    End Sub

    Public Shared Sub L_BonosDescuentosCabecera_Modificar(ByRef _numi As String, _codPersona As String, _año As String, _mes As String)
        Dim _Err As Boolean
        Dim Sql, _where As String

        Sql = "pbcper = " + _codPersona + ", " +
        "pbano = " + _año + " , " +
        "pbmes = " + _mes + " , " +
        "pbfact = '" + Date.Now.Date.ToString("yyyy/MM/dd") + "', " +
        "pbhact = '" + Now.Hour.ToString + ":" + Now.Minute.ToString + "', " +
        "pbuact = '" + "DANNY" + "'"

        _where = "pbnumi = " + _numi
        _Err = D_Modificar_Datos("TP002", Sql, _where)
    End Sub

    Public Shared Sub L_BonosDescuentosCabecera_Borrar(_Id As String)
        Dim _Where As String
        Dim _Err As Boolean
        _Where = "pbnumi = " + _Id
        _Err = D_Eliminar_Datos("TP002", _Where)
    End Sub

    'DETALLE DE BONOS DESCUENTOS
    Public Shared Function L_BonosDescuentosDetalle_General(_Modo As Integer, Optional _idCabecera As String = "") As DataTable
        Dim _Tabla As DataTable
        Dim _Where As String
        If _Modo = 0 Then
            _Where = " pcnumi = pcnumi"
        Else
            _Where = "pcnumi=" + _idCabecera
        End If
        _Tabla = D_Datos_Tabla("pcnumi,pcdias,pcmonto,pcobs,pcmul,pcbode", "TP0021", _Where)
        Return _Tabla
    End Function
    Public Shared Function L_BonosDescuentosDetalle_General2(_Modo As Integer, Optional _idCabecera As String = "") As DataTable
        Dim _Tabla As DataTable
        Dim _Where As String
        If _Modo = 0 Then
            _Where = " pcnumi = pcnumi"
        Else
            _Where = "pcnumi=" + _idCabecera
        End If
        _Tabla = D_Datos_Tabla("pcnumi,pcdias,pcmonto,pcobs,pcmul,pcbode,IIF(pcmul=1,'MULTA',IIF(pcbode=1,'BONO','DESCUENTO')) as tipo,pcfecha", "TP0021", _Where)
        Return _Tabla
    End Function

    Public Shared Sub L_BonosDescuentosDetalle_Grabar(_idCabecera As String, _dias As String, _monto As String, _obs As String, _multa As String, _bode As String, _fecha As String)
        Dim _Err As Boolean
        Dim Sql As String
        Sql = _idCabecera + "," + _dias + "," + _monto + ",'" + _obs + "'," + _multa + "," + _bode + ",'" + _fecha + "'"
        _Err = D_Insertar_Datos("TP0021", Sql)
    End Sub

    Public Shared Sub L_BonosDescuentosDetalle_Modificar(_idCabecera As String, _dias As String, _monto As String, _obs As String, _multa As String, _bode As String)
        Dim _Err As Boolean
        Dim Sql, _where As String

        Sql = "pcdias =" + _dias + ", " +
        "pcmonto =" + _monto + ", " +
        "pcobs =" + _obs + ", " +
        "pcmul =" + _multa + ", " +
        "pcbode =" + _bode

        _where = "pcnumi = " + _idCabecera
        _Err = D_Modificar_Datos("TP0021", Sql, _where)
    End Sub

    Public Shared Sub L_BonosDescuentosDetalle_Borrar(_Id As String)
        Dim _Where As String
        Dim _Err As Boolean

        _Where = "pcnumi = " + _Id
        _Err = D_Eliminar_Datos("TP0021", _Where)
    End Sub

#End Region

#Region "Descuentos Fijos"

    Public Shared Function L_DescuentoFijo_General(_Modo As Integer, Optional _Cadena As String = "") As DataSet
        Dim _Tabla As DataTable
        Dim _Ds As New DataSet
        Dim _Where As String
        If _Modo = 0 Then
            _Where = "TP001.panumi=TP008.pacper"
        Else
            _Where = "TP001.panumi=TP008.pacper " + _Cadena
        End If
        _Tabla = D_Datos_Tabla("TP008.panumi,TP008.patipo,TP008.pavalor,TP008.pacper,CONCAT(panom,' ',paape) as cbdesc,TP008.paobs,TP008.pavenc,TP008.pafvenc", "TP008,TP001", _Where + " order by TP008.panumi")
        _Ds.Tables.Add(_Tabla)
        Return _Ds
    End Function

    Public Shared Sub L_DescuentoFijo_Grabar(ByRef _numi As String, _tipo As String, _valor As String, _codPersona As String, _obs As String, _vencimiento As String, _fechaVenci As String)
        Dim _Actualizacion As String
        Dim _Err As Boolean
        Dim _Tabla As DataTable
        _Tabla = D_Maximo("TP008", "panumi", "panumi=panumi")
        If Not IsDBNull(_Tabla.Rows(0).Item(0)) Then
            _numi = _Tabla.Rows(0).Item(0) + 1
        Else
            _numi = "1"
        End If

        _Actualizacion = "'" + Date.Now.Date.ToString("yyyy/MM/dd") + "', '" + Now.Hour.ToString + ":" + Now.Minute.ToString + "' ,'" + L_Usuario + "'"

        Dim Sql As String
        Sql = _numi + "," + _tipo + "," + _valor + "," + _codPersona + ",'" + _obs + "'," + _vencimiento + ",'" + _fechaVenci + "'," + _Actualizacion
        _Err = D_Insertar_Datos("TP008", Sql)
    End Sub

    Public Shared Sub L_DescuentoFijo_Modificar(_numi As String, _tipo As String, _valor As String, _codPersona As String, _obs As String, _vencimiento As String, _fechaVenci As String)
        Dim _Err As Boolean
        Dim Sql, _where As String

        Sql = "patipo = " + _tipo + ", " +
        "pavalor = " + _valor + " , " +
        "pacper = " + _codPersona + " , " +
        "paobs = '" + _obs + "', " +
        "pavenc = " + _vencimiento + ", " +
        "pafvenc = '" + _fechaVenci + "', " +
        "pafact = '" + Date.Now.Date.ToString("yyyy/MM/dd") + "', " +
        "pahact = '" + Now.Hour.ToString + ":" + Now.Minute.ToString + "', " +
        "pauact = '" + "DANNY" + "'"

        _where = "panumi = " + _numi
        _Err = D_Modificar_Datos("TP008", Sql, _where)
    End Sub

    Public Shared Sub L_DescuentoFijo_Borrar(_Id As String)

        Dim _Where As String
        Dim _Err As Boolean

        _Where = "panumi = " + _Id
        _Err = D_Eliminar_Datos("TP008", _Where)

    End Sub

#End Region


#Region "Vacacion"

    Public Shared Function L_Vacacion_General(_Modo As Integer, Optional _Cadena As String = "") As DataSet
        Dim _Tabla As DataTable
        Dim _Ds As New DataSet
        Dim _Where As String
        If _Modo = 0 Then
            _Where = "penumi=penumi"
        Else
            _Where = "penumi=penumi " + _Cadena
        End If
        _Tabla = D_Datos_Tabla("penumi,pemeses,pedias,pefvig,petipo", "TP004", _Where + " order by penumi")
        _Ds.Tables.Add(_Tabla)
        Return _Ds
    End Function

    Public Shared Sub L_Vacacion_Grabar(ByRef _numi As String, _meses As String, _dias As String, _fechaVigencia As String, _tipo As String)
        Dim _Actualizacion As String
        Dim _Err As Boolean
        Dim _Tabla As DataTable
        _Tabla = D_Maximo("TP004", "penumi", "penumi=penumi")
        If Not IsDBNull(_Tabla.Rows(0).Item(0)) Then
            _numi = _Tabla.Rows(0).Item(0) + 1
        Else
            _numi = "1"
        End If

        _Actualizacion = "'" + Date.Now.Date.ToString("yyyy/MM/dd") + "', '" + Now.Hour.ToString + ":" + Now.Minute.ToString + "' ,'" + L_Usuario + "'"

        Dim Sql As String
        Sql = _numi + "," + _meses + "," + _dias + ",'" + _fechaVigencia + "'," + _tipo + "," + _Actualizacion
        _Err = D_Insertar_Datos("TP004", Sql)
    End Sub

    Public Shared Sub L_Vacacion_Modificar(_numi As String, _meses As String, _dias As String, _fechaVigencia As String, _tipo As String)
        Dim _Err As Boolean
        Dim Sql, _where As String

        Sql = "pemeses = " + _meses + ", " +
        "pedias = " + _dias + " , " +
        "pefvig = '" + _fechaVigencia + "', " +
        "petipo = " + _tipo + " , " +
        "pefact = '" + Date.Now.Date.ToString("yyyy/MM/dd") + "', " +
        "pehact = '" + Now.Hour.ToString + ":" + Now.Minute.ToString + "', " +
        "peuact = '" + "DANNY" + "'"

        _where = "penumi = " + _numi
        _Err = D_Modificar_Datos("TP004", Sql, _where)
    End Sub

    Public Shared Sub L_Vacacion_Borrar(_Id As String)
        Dim _Where As String
        Dim _Err As Boolean
        _Where = "penumi = " + _Id
        _Err = D_Eliminar_Datos("TP004", _Where)
    End Sub

#End Region

#Region "Bono Antiguedad"

    Public Shared Function L_BonosAntiguedad_General(_Modo As Integer, Optional _Cadena As String = "") As DataSet
        Dim _Tabla As DataTable
        Dim _Ds As New DataSet
        Dim _Where As String
        If _Modo = 0 Then
            _Where = "pdnumi=pdnumi"
        Else
            _Where = "pbnumi=pbnumi " + _Cadena
        End If
        _Tabla = D_Datos_Tabla("pdnumi,pdmeses,pdmonto", "TP003", _Where + " order by pdnumi")
        _Ds.Tables.Add(_Tabla)
        Return _Ds
    End Function

    Public Shared Sub L_BonosAntiguedad_Grabar(ByRef _numi As String, _meses As String, _monto As String)
        Dim _Actualizacion As String
        Dim _Err As Boolean
        Dim _Tabla As DataTable
        _Tabla = D_Maximo("TP003", "pdnumi", "pdnumi=pdnumi")
        If Not IsDBNull(_Tabla.Rows(0).Item(0)) Then
            _numi = _Tabla.Rows(0).Item(0) + 1
        Else
            _numi = "1"
        End If

        _Actualizacion = "'" + Date.Now.Date.ToString("yyyy/MM/dd") + "', '" + Now.Hour.ToString + ":" + Now.Minute.ToString + "' ,'" + L_Usuario + "'"

        Dim Sql As String
        Sql = _numi + "," + _meses + "," + _monto + "," + _Actualizacion
        _Err = D_Insertar_Datos("TP003", Sql)
    End Sub

    Public Shared Sub L_BonosAntiguedad_Modificar(_numi As String, _meses As String, _monto As String)
        Dim _Err As Boolean
        Dim Sql, _where As String

        Sql = "pdmeses = " + _meses + ", " +
        "pdmonto = " + _monto + " , " +
        "pdfact = '" + Date.Now.Date.ToString("yyyy/MM/dd") + "', " +
        "pdhact = '" + Now.Hour.ToString + ":" + Now.Minute.ToString + "', " +
        "pduact = '" + "DANNY" + "'"

        _where = "pdnumi = " + _numi
        _Err = D_Modificar_Datos("TP003", Sql, _where)
    End Sub

    Public Shared Sub L_BonosAntiguedad_Borrar(_Id As String)
        Dim _Where As String
        Dim _Err As Boolean
        _Where = "pdnumi = " + _Id
        _Err = D_Eliminar_Datos("TP003", _Where)
    End Sub

#End Region

#Region "Pedido Vacacion"

    Public Shared Function L_PedidoVacacionCabecera_General(_Modo As Integer, Optional _Cadena As String = "") As DataSet
        Dim _Tabla As DataTable
        Dim _Ds As New DataSet
        Dim _Where As String
        If _Modo = 0 Then
            _Where = "pgnumi=pgnumi AND pgcper=panumi"
        Else
            _Where = "pgcper=panumi " + _Cadena
        End If
        _Tabla = D_Datos_Tabla("pgnumi,pgcper,CONCAT(TP001.panom,' ',TP001.paape) as cbdesc,pgfdoc,pgest,pgobs,pgfsal,pgfing,pgdias", "TP006,TP001", _Where + " order by pgnumi")
        _Ds.Tables.Add(_Tabla)
        Return _Ds
    End Function

    Public Shared Sub L_PedidoVacacionCabecera_Grabar(ByRef _numi As String, _codPersona As String, _fechaDoc As String, _estado As String, _obs As String, _fSal As String, _fIng As String, _dias As String)
        Dim _Actualizacion As String
        Dim _Err As Boolean
        Dim _Tabla As DataTable
        _Tabla = D_Maximo("TP006", "pgnumi", "pgnumi=pgnumi")
        If Not IsDBNull(_Tabla.Rows(0).Item(0)) Then
            _numi = _Tabla.Rows(0).Item(0) + 1
        Else
            _numi = "1"
        End If

        _Actualizacion = "'" + Date.Now.Date.ToString("yyyy/MM/dd") + "', '" + Now.Hour.ToString + ":" + Now.Minute.ToString + "' ,'" + L_Usuario + "'"

        Dim Sql As String
        Sql = _numi + "," + _codPersona + ",'" + _fechaDoc + "'," + _estado + ",'" + _obs + "','" + _fSal + "','" + _fIng + "'," + _dias + "," + _Actualizacion
        _Err = D_Insertar_Datos("TP006", Sql)
    End Sub

    Public Shared Sub L_PedidoVacacionCabecera_Modificar(_numi As String, _codPersona As String, _fechaDoc As String, _estado As String, _obs As String, _fIng As String, _fSal As String, _dias As String)
        Dim _Err As Boolean
        Dim Sql, _where As String

        Sql = "pgcper = " + _codPersona + ", " +
        "pgfdoc = '" + _fechaDoc + "', " +
        "pgest = " + _estado + " , " +
        "pgobs = '" + _obs + "', " +
        "pgfsal = '" + _fSal + "', " +
        "pgfing = '" + _fIng + "', " +
        "pgdias = " + _dias + " , " +
        "pgfact = '" + Date.Now.Date.ToString("yyyy/MM/dd") + "', " +
        "pghact = '" + Now.Hour.ToString + ":" + Now.Minute.ToString + "', " +
        "pguact = '" + L_Usuario + "'"

        _where = "pgnumi = " + _numi
        _Err = D_Modificar_Datos("TP006", Sql, _where)
    End Sub

    Public Shared Sub L_PedidoVacacionCabecera_Borrar(_Id As String)
        Dim _Where As String
        Dim _Err As Boolean
        _Where = "pgnumi = " + _Id
        _Err = D_Eliminar_Datos("TP006", _Where)
    End Sub

    'DETALLE DE PEDIDO VACACIONES
    Public Shared Function L_PedidoVacacionDetalle_General(_Modo As Integer, Optional _idCabecera As String = "") As DataTable
        Dim _Tabla As DataTable
        Dim _Where As String
        If _Modo = 0 Then
            _Where = " phnumi = phnumi"
        Else
            _Where = "phnumi=" + _idCabecera
        End If
        _Tabla = D_Datos_Tabla("phnumi,phfsal,phfing,phdias", "TP0061", _Where)
        Return _Tabla
    End Function

    Public Shared Sub L_PedidoVacacionDetalle_Grabar(_idCabecera As String, _fechaSalida As String, _fechaIngreso As String, _dias As String)
        Dim _Err As Boolean
        Dim Sql As String
        Sql = _idCabecera + ",'" + _fechaSalida + "','" + _fechaIngreso + "'," + _dias
        _Err = D_Insertar_Datos("TP0061", Sql)
    End Sub

    Public Shared Sub L_PedidoVacacionDetalle_Modificar(_idCabecera As String, _fechaSalida As String, _fechaIngreso As String, _dias As String)
        Dim _Err As Boolean
        Dim Sql, _where As String

        Sql = "phfsal ='" + _fechaSalida + "', " +
        "phfing ='" + _fechaIngreso + "', " +
        "phdias =" + _dias

        _where = "phnumi = " + _idCabecera
        _Err = D_Modificar_Datos("TP0061", Sql, _where)
    End Sub

    Public Shared Sub L_PedidoVacacionDetalle_Borrar(_Id As String)
        Dim _Where As String
        Dim _Err As Boolean

        _Where = "phnumi = " + _Id
        _Err = D_Eliminar_Datos("TP0061", _Where)
    End Sub

    'METODOS EXTRAS
    Public Shared Function L_PedidoVacacionDetalleFechas(_codEmpl As String) As DataTable
        Dim _Tabla As DataTable
        Dim _Where, _select As String
        _Where = "panumi=" + _codEmpl
        _select = "pafing as cbfing, DATEADD(YEAR, 1, pafing) AS fechaFin,0 as diasLibres, 0 as diasUsados,0 as saldo "
        _Tabla = D_Datos_Tabla(_select, "TP001", _Where)
        Return _Tabla
    End Function

    Public Shared Function L_PedidoVacacion_ObtenerDiasVacacion(_meses As String) As Integer
        Dim _Tabla As DataTable
        Dim _Where, _select As String
        _Where = _meses + ">=pemeses order by pemeses desc"
        _select = "top 1 pedias "
        _Tabla = D_Datos_Tabla(_select, "TP004", _Where)
        If _Tabla.Rows.Count = 0 Then
            Return 0
        Else
            Return _Tabla.Rows(0).Item(0)
        End If

    End Function

    Public Shared Function L_PedidoVacacion_ObtenerDiasUsados(_codEmpleado As String) As Integer
        Dim _Tabla As DataTable
        Dim _Where, _select As String
        _Where = "pgcper=" + _codEmpleado
        _select = "sum(pgdias) as totalDias "
        _Tabla = D_Datos_Tabla(_select, "TP006", _Where)
        If IsDBNull(_Tabla.Rows(0).Item(0)) Then
            Return 0
        Else
            Return _Tabla.Rows(0).Item(0)
        End If

    End Function

#End Region



#End Region

#Region "ALUMNNO CERTIFICACION"


    Public Shared Function L_prAlumnoCertiGeneral() As DataTable 'modelo 1 con condificion
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 3))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE009", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prAlumnoCertiGeneralReporteExamenTeorico() As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 5))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE009", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prAlumnoCertiGetAprobadosTC007General() As DataTable 'modelo 1 con condificion
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 4))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE009", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prAlumnoCertiAlumnosDeEscuela() As DataTable 'modelo 1 con condificion
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 411))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE009", _listParam)

        Return _Tabla
    End Function


    Public Shared Function L_prAlumnoCertiGetAprobadosEscuelaConSuInstructor() As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 7))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE009", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prAlumnoCertiGetFiltrados(_aprobRepro As String, _escuelaExterno As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 8))
        _listParam.Add(New Datos.DParametro("@elesc", _escuelaExterno))
        _listParam.Add(New Datos.DParametro("@elest", _aprobRepro))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE009", _listParam)

        Return _Tabla
    End Function


    'Public Shared Function L_prAlumnoCertiAyuda() As DataTable
    '    Dim _Tabla As DataTable

    '    Dim _listParam As New List(Of Datos.DParametro)

    '    _listParam.Add(New Datos.DParametro("@tipo", 4))
    '    _listParam.Add(New Datos.DParametro("@cbuact", L_Usuario))

    '    _Tabla = D_ProcedimientoConParam("sp_dg_TCE002", _listParam)

    '    Return _Tabla
    'End Function

    Public Shared Function L_prAlumnoCertiGrabar(ByRef _numi As String, _ci As String, _nom As String, _apellPat As String, _apellMat As String, _fNac As String, ByRef _foto As String, _escuela As String, _estado As String, _alumNumiEscuela As String, _telf As String, _cel As String, _numiInst As String, _numiSuc As String, _nac As Integer) As Boolean
        Dim _res As Boolean

        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 1))
        _listParam.Add(New Datos.DParametro("@elnumi", _numi))
        _listParam.Add(New Datos.DParametro("@elci", _ci))
        _listParam.Add(New Datos.DParametro("@elnom", _nom))
        _listParam.Add(New Datos.DParametro("@elapep", _apellPat))
        _listParam.Add(New Datos.DParametro("@elapem", _apellMat))
        _listParam.Add(New Datos.DParametro("@elfnac", _fNac))
        _listParam.Add(New Datos.DParametro("@elfot", _foto))
        _listParam.Add(New Datos.DParametro("@elesc", _escuela))
        _listParam.Add(New Datos.DParametro("@elest", _estado))
        _listParam.Add(New Datos.DParametro("@elalumnumi", _alumNumiEscuela))
        _listParam.Add(New Datos.DParametro("@eltelf1", _telf))
        _listParam.Add(New Datos.DParametro("@eltelf2", _cel))
        _listParam.Add(New Datos.DParametro("@elnumiInst", _numiInst))
        _listParam.Add(New Datos.DParametro("@elsuc", _numiSuc))
        _listParam.Add(New Datos.DParametro("@elnac", _nac))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE009", _listParam)

        If _Tabla.Rows.Count > 0 Then
            _numi = _Tabla.Rows(0).Item(0)
            If _foto <> "" Then
                _foto = "alum_cert_" + _numi
            End If
            _res = True
        Else
            _res = False
        End If

        Return _res
    End Function

    Public Shared Function L_prAlumnoCertiModificar(ByRef _numi As String, _ci As String, _nom As String, _apellPat As String, _apellMat As String, _fNac As String, ByRef _foto As String, _escuela As String, _estado As String, _alumNumiEscuela As String, _telf As String, _cel As String, _numiInst As String, _numiSuc As String, _nac As Integer) As Boolean
        Dim _res As Boolean

        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 2))
        _listParam.Add(New Datos.DParametro("@elnumi", _numi))
        _listParam.Add(New Datos.DParametro("@elci", _ci))
        _listParam.Add(New Datos.DParametro("@elnom", _nom))
        _listParam.Add(New Datos.DParametro("@elapep", _apellPat))
        _listParam.Add(New Datos.DParametro("@elapem", _apellMat))
        _listParam.Add(New Datos.DParametro("@elfnac", _fNac))
        _listParam.Add(New Datos.DParametro("@elfot", _foto))
        _listParam.Add(New Datos.DParametro("@elesc", _escuela))
        _listParam.Add(New Datos.DParametro("@elest", _estado))
        _listParam.Add(New Datos.DParametro("@elalumnumi", _alumNumiEscuela))
        _listParam.Add(New Datos.DParametro("@eltelf1", _telf))
        _listParam.Add(New Datos.DParametro("@eltelf2", _cel))
        _listParam.Add(New Datos.DParametro("@elnumiInst", _numiInst))
        _listParam.Add(New Datos.DParametro("@elsuc", _numiSuc))
        _listParam.Add(New Datos.DParametro("@elnac", _nac))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE009", _listParam)

        If _Tabla.Rows.Count > 0 Then
            _numi = _Tabla.Rows(0).Item(0)
            If _foto <> "" Then
                _foto = "alum_cert_" + _numi
            End If
            _res = True
        Else
            _res = False
        End If

        Return _res
    End Function

    Public Shared Function L_prAlumnoCertiBorrar(_numi As String, ByRef _mensaje As String) As Boolean

        Dim _resultado As Boolean

        If L_fnbValidarEliminacion(_numi, "TCE009", "elnumi", _mensaje) = True Then
            Dim _Tabla As DataTable

            Dim _listParam As New List(Of Datos.DParametro)

            _listParam.Add(New Datos.DParametro("@tipo", -1))
            _listParam.Add(New Datos.DParametro("@elnumi", _numi))
            _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

            _Tabla = D_ProcedimientoConParam("sp_dg_TCE009", _listParam)

            If _Tabla.Rows.Count > 0 Then
                _numi = _Tabla.Rows(0).Item(0)
                _resultado = True
            Else
                _resultado = False
            End If
        Else
            _resultado = False
        End If

        Return _resultado
    End Function

#End Region

#Region "TCE010 EXAMEN ALUMNOS CERTIFICACION"
    Public Shared Function L_prExamenAlumnoCertiGeneralProgramadosParaPonerNotasTeorico() As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 3))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE010", _listParam)

        Return _Tabla
    End Function
    Public Shared Function L_prExamenAlumnoCertiGeneralProgramadosParaPonerNotasTeoricoTODOS() As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 331))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE010", _listParam)

        Return _Tabla
    End Function
    Public Shared Function L_prExamenAlumnoCertiGeneralAyudaParaReporteFormularios() As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 31))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE010", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prExamenAlumnoCertiGeneralInscritos(_fecha As String, _tipo As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 8))
        _listParam.Add(New Datos.DParametro("@emfecha", _fecha))
        _listParam.Add(New Datos.DParametro("@emtipo", _tipo))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE010", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prExamenAlumnoCertiGeneralRegistrosPorNroFactura(_nroFactura As String, _numiAlum As String, _tipo As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 9))
        _listParam.Add(New Datos.DParametro("@emznfact", _nroFactura))
        _listParam.Add(New Datos.DParametro("@emalum", _numiAlum))
        _listParam.Add(New Datos.DParametro("@emtipo", _tipo))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE010", _listParam)

        Return _Tabla
    End Function


    Public Shared Function L_prExamenAlumnoCertiGeneralReporteExamenTeorico(_fecha As String, _numiSuc As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 5))
        _listParam.Add(New Datos.DParametro("@emfecha", _fecha))
        _listParam.Add(New Datos.DParametro("@numiSuc", _numiSuc))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE010", _listParam)

        Return _Tabla
    End Function
    Public Shared Function L_prExamenAlumnoCertiGeneralReporteExamenPractico() As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 6))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE010", _listParam)

        Return _Tabla
    End Function
    Public Shared Function L_prExamenAlumnoCertiGeneralReporteExamenTeoricoEstructura() As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 51))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE010", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prExamenAlumnoCertiGeneral() As DataTable 'modelo 1 con condificion
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 3))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE009", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prExamenAlumnoCertiBuscarAlumno(_ciAlum As String) As DataTable 'busca por el numi del alumno
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 7))
        _listParam.Add(New Datos.DParametro("@ci", _ciAlum))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE010", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prExamenAlumnoCertiBuscarRegistroPorNroFactura(_nroFactura As String) As DataTable 'busca por el numi del alumno
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 10))
        _listParam.Add(New Datos.DParametro("@emznfact", _nroFactura))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE010", _listParam)

        Return _Tabla
    End Function


    Public Shared Function L_prExamenAlumnoCertiGrabar(ByRef _numi As String, _numiAlum As String, _fecha As String, _estado As String, _numiInst As String, _nota As String, _tipoTP As String, _nroFactura As String, _obs As String, _catLicencia As String, _nroOpcion As String, _empresa As Integer, numiFactura As String) As Boolean
        Dim _res As Boolean

        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 1))
        _listParam.Add(New Datos.DParametro("@emnumi", _numi))
        _listParam.Add(New Datos.DParametro("@emalum", _numiAlum))
        _listParam.Add(New Datos.DParametro("@emfecha", _fecha))
        _listParam.Add(New Datos.DParametro("@emestado", _estado))
        _listParam.Add(New Datos.DParametro("@emchof", _numiInst))
        _listParam.Add(New Datos.DParametro("@emnota", _nota))
        _listParam.Add(New Datos.DParametro("@emtipo", _tipoTP))
        _listParam.Add(New Datos.DParametro("@emznfact", _nroFactura))
        _listParam.Add(New Datos.DParametro("@emobs", _obs))
        _listParam.Add(New Datos.DParametro("@emcatlic", _catLicencia))
        _listParam.Add(New Datos.DParametro("@emnopc", _nroOpcion))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))
        _listParam.Add(New Datos.DParametro("@ememp", _empresa))
        '_listParam.Add(New Datos.DParametro("@vcnumi", numiFactura))
        _Tabla = D_ProcedimientoConParam("sp_dg_TCE010", _listParam)

        If _Tabla.Rows.Count > 0 Then
            _numi = _Tabla.Rows(0).Item(0)
            _res = True
        Else
            _res = False
        End If

        Return _res
    End Function
    Public Shared Function L_prExamenAlumnoCertiModificar(ByRef _numi As String, _numiAlum As String, _fecha As String, _estado As String, _numiInst As String, _nota As String, _tipoTP As String, _nroFactura As String, _obs As String, _catLicencia As String, _nroOpcion As String) As Boolean
        Dim _res As Boolean

        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 2))
        _listParam.Add(New Datos.DParametro("@emnumi", _numi))
        _listParam.Add(New Datos.DParametro("@emalum", _numiAlum))
        _listParam.Add(New Datos.DParametro("@emfecha", _fecha))
        _listParam.Add(New Datos.DParametro("@emestado", _estado))
        _listParam.Add(New Datos.DParametro("@emchof", _numiInst))
        _listParam.Add(New Datos.DParametro("@emnota", _nota))
        _listParam.Add(New Datos.DParametro("@emtipo", _tipoTP))
        _listParam.Add(New Datos.DParametro("@emznfact", _nroFactura))
        _listParam.Add(New Datos.DParametro("@emobs", _obs))
        _listParam.Add(New Datos.DParametro("@emcatlic", _catLicencia))
        _listParam.Add(New Datos.DParametro("@emnopc", _nroOpcion))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE010", _listParam)

        If _Tabla.Rows.Count > 0 Then
            '_numi = _Tabla.Rows(0).Item(0)
            _res = True
        Else
            _res = False
        End If

        Return _res
    End Function

    Public Shared Function L_prExamenAlumnoCertiModificarEstado(_numi As String, _estado As String) As Boolean
        Dim _res As Boolean

        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 21))
        _listParam.Add(New Datos.DParametro("@emnumi", _numi))
        _listParam.Add(New Datos.DParametro("@emestado", _estado))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE010", _listParam)


        If _Tabla.Rows.Count > 0 Then

            _res = True
        Else
            _res = False
        End If

        Return _res
    End Function

    Public Shared Function L_prExamenAlumnoCertiModificarNota(_numi As String, _nota As String) As Boolean
        Dim _res As Boolean

        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 22))
        _listParam.Add(New Datos.DParametro("@emnumi", _numi))
        _listParam.Add(New Datos.DParametro("@emnota", _nota))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE010", _listParam)


        If _Tabla.Rows.Count > 0 Then
            _numi = _Tabla.Rows(0).Item(0)
            _res = True
        Else
            _res = False
        End If

        Return _res
    End Function


    Public Shared Function L_prExamenAlumnoCertiBorrar(_numi As String, ByRef _mensaje As String) As Boolean

        Dim _resultado As Boolean

        If L_fnbValidarEliminacion(_numi, "TCE010", "emnumi", _mensaje) = True Then
            Dim _Tabla As DataTable

            Dim _listParam As New List(Of Datos.DParametro)

            _listParam.Add(New Datos.DParametro("@tipo", -1))
            _listParam.Add(New Datos.DParametro("@emnumi", _numi))
            _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

            _Tabla = D_ProcedimientoConParam("sp_dg_TCE010", _listParam)

            If _Tabla.Rows.Count > 0 Then
                _numi = _Tabla.Rows(0).Item(0)
                _resultado = True
            Else
                _resultado = False
            End If
        Else
            _resultado = False
        End If

        Return _resultado
    End Function

#End Region

#Region "PREGUNTAS TCE011"

    Public Shared Function L_prPreguntaGeneral2(_tipo As String, _lic As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 4))
        _listParam.Add(New Datos.DParametro("@entipo", _tipo))
        _listParam.Add(New Datos.DParametro("@enlic", _lic))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE011", _listParam)

        Return _Tabla
    End Function


#End Region

#Region " NOTAS PREGUNTAS TCE012"

    Public Shared Function L_prNotasPreguntasPorRegistro(_numiReg As String, _direccion As String, _direccionBase As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 5))
        _listParam.Add(New Datos.DParametro("@emnumi", _numiReg))
        _listParam.Add(New Datos.DParametro("@direccion", _direccion))
        _listParam.Add(New Datos.DParametro("@direccionBase", _direccionBase))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE012", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prNotasPreguntasPorRegInscripcion(_numiReg As String, _tipoPreg As String, _catLiecencia As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 3))
        _listParam.Add(New Datos.DParametro("@emnumi", _numiReg))
        _listParam.Add(New Datos.DParametro("@entipo", _tipoPreg))
        _listParam.Add(New Datos.DParametro("@enlic", _catLiecencia))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE012", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prNotasPreguntasPorPorCategoriaYTipo(_numiCatLic As String, _tipoPreg As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 4))
        _listParam.Add(New Datos.DParametro("@entipo", _tipoPreg))
        _listParam.Add(New Datos.DParametro("@enlic", _numiCatLic))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE012", _listParam)

        Return _Tabla
    End Function
    Public Shared Function L_prNotasPreguntasPorPorCategoria(_numiCatLic As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 41))
        _listParam.Add(New Datos.DParametro("@enlic", _numiCatLic))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE012", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prNotasPreguntaGrabar(_numiPregunta As String, _nota As String, _numiAlum As String) As Boolean
        Dim _res As Boolean

        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 1))
        _listParam.Add(New Datos.DParametro("@eonumitce11", _numiPregunta))
        _listParam.Add(New Datos.DParametro("@eonota", _nota))
        _listParam.Add(New Datos.DParametro("@eoalum", _numiAlum))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE012", _listParam)

        If _Tabla.Rows.Count > 0 Then
            _res = True
        Else
            _res = False
        End If

        Return _res
    End Function

    Public Shared Function L_prNotasPreguntaEliminarNotasDeExamen(_numiExamen As String) As Boolean
        Dim _res As Boolean

        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", -2))
        _listParam.Add(New Datos.DParametro("@eoalum", _numiExamen))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE012", _listParam)

        If _Tabla.Rows.Count > 0 Then
            _res = True
        Else
            _res = False
        End If

        Return _res
    End Function


#End Region

#Region " Certificados Alumnos TCE013"
    Public Shared Function L_prCertificadosAlumnosLista() As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 3))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE013", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prCertificadosAlumnosListaReimpresion() As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 9))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE013", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prCertificadosAlumnosGetUltimaClaseTeorica(_numiAlum As String, _nroFact As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 4))
        _listParam.Add(New Datos.DParametro("@epalum", _numiAlum))
        _listParam.Add(New Datos.DParametro("@epznfact", _nroFact))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE013", _listParam)

        Return _Tabla
    End Function
    Public Shared Function L_prCertificadosAlumnosGetUltimaClasePractica(_numiAlum As String, _nroFact As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 5))
        _listParam.Add(New Datos.DParametro("@epalum", _numiAlum))
        _listParam.Add(New Datos.DParametro("@epznfact", _nroFact))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE013", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prCertificadosAlumnosGetNotaEvaluacionTeorica(_numiTCE010 As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 6))
        _listParam.Add(New Datos.DParametro("@epnumi", _numiTCE010))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE013", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prCertificadosAlumnosGetNotaEvaluacionConocMecanica(_numiTCE010 As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 7))
        _listParam.Add(New Datos.DParametro("@epnumi", _numiTCE010))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE013", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prCertificadosAlumnosReporteCerti(_numi As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 8))
        _listParam.Add(New Datos.DParametro("@epnumi", _numi))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE013", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prCertificadosAlumnosObtenerPorNumiAlumYNroFact(_numiAlum As String, _nroFactura As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 10))
        _listParam.Add(New Datos.DParametro("@epalum", _numiAlum))
        _listParam.Add(New Datos.DParametro("@epznfact", _nroFactura))

        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE013", _listParam)

        Return _Tabla
    End Function
    Public Shared Function L_prCertificadosAlumnosGrabar(ByRef _numi As String, _numiAlum As String, _nroFact As String, _fecha As String, _catLic As String, _notaTeo As String, _notaMec As String, _notaPrac As String, _notaFin As String) As Boolean
        Dim _res As Boolean

        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 1))
        _listParam.Add(New Datos.DParametro("@epalum", _numiAlum))
        _listParam.Add(New Datos.DParametro("@epznfact", _nroFact))
        _listParam.Add(New Datos.DParametro("@epfecha", _fecha))
        _listParam.Add(New Datos.DParametro("@epcatlic", _catLic))
        _listParam.Add(New Datos.DParametro("@epnotteo", _notaTeo))
        _listParam.Add(New Datos.DParametro("@epnotmec", _notaMec))
        _listParam.Add(New Datos.DParametro("@epnotprac", _notaPrac))
        _listParam.Add(New Datos.DParametro("@epnotfin", _notaFin))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE013", _listParam)

        If _Tabla.Rows.Count > 0 Then
            _numi = _Tabla.Rows(0).Item(0)
            _res = True
        Else
            _res = False
        End If

        Return _res
    End Function

    Public Shared Function L_prCertificadosAlumnosModificar(_numi As String, _notaTeo As String, _notaMec As String, _notaPrac As String, _notaFin As String) As Boolean
        Dim _res As Boolean

        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 2))
        _listParam.Add(New Datos.DParametro("@epnumi", _numi))
        _listParam.Add(New Datos.DParametro("@epnotteo", _notaTeo))
        _listParam.Add(New Datos.DParametro("@epnotmec", _notaMec))
        _listParam.Add(New Datos.DParametro("@epnotprac", _notaPrac))
        _listParam.Add(New Datos.DParametro("@epnotfin", _notaFin))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE013", _listParam)

        If _Tabla.Rows.Count > 0 Then
            _numi = _Tabla.Rows(0).Item(0)
            _res = True
        Else
            _res = False
        End If

        Return _res
    End Function

    Public Shared Function L_prCertificadosAlumnosModificarFecha(_numi As String, _fecha As String) As Boolean
        Dim _res As Boolean

        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 21))
        _listParam.Add(New Datos.DParametro("@epnumi", _numi))
        _listParam.Add(New Datos.DParametro("@epfecha", _fecha))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE013", _listParam)

        If _Tabla.Rows.Count > 0 Then
            _numi = _Tabla.Rows(0).Item(0)
            _res = True
        Else
            _res = False
        End If

        Return _res
    End Function


#End Region

#Region "CONFIGURACION SISTEMA TCG01"

    Public Shared Function L_prConGlobalGeneral() As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 3))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCG01", _listParam)

        Return _Tabla
    End Function


#End Region

#Region "METODOS MARCO ANTONIO"

#Region "DBDies Marco"

#Region "DBDies Productos"

    Public Shared Function L_prProductoGeneral() As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 5))
        _listParam.Add(New Datos.DParametro("@lfuact", L_Usuario))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TCL005", _listParam)

        Return _Tabla
    End Function
    Public Shared Function L_prProductoG() As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 3))
        _listParam.Add(New Datos.DParametro("@lduact", L_Usuario))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TCL003", _listParam)

        Return _Tabla
    End Function


    Public Shared Function L_prProductoKardexGeneralAcb(_fechaI As String, _fechaF As String, _concepto As Integer) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 5))
        _listParam.Add(New Datos.DParametro("@fechaI", _fechaI))
        _listParam.Add(New Datos.DParametro("@fechaF", _fechaF))
        _listParam.Add(New Datos.DParametro("@concepto", _concepto))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TCL003", _listParam)

        Return _Tabla
    End Function
    Public Shared Function L_prProductoKardexDetalladoAcb(_fechaI As String, _fechaF As String, _concepto As Integer) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 6))
        _listParam.Add(New Datos.DParametro("@fechaI", _fechaI))
        _listParam.Add(New Datos.DParametro("@fechaF", _fechaF))
        _listParam.Add(New Datos.DParametro("@concepto", _concepto))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TCL003", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prProductoInventarioGeneral() As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 4))
        _listParam.Add(New Datos.DParametro("@lduact", L_Usuario))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TCL003", _listParam)

        Return _Tabla
    End Function
    Public Shared Function L_prProductoGrabar(ByRef _ldnumi As String, _ldcprod As String, _ldcdprod1 As String, _ldgr As Integer, _ldumed As String, _ldsmin As Integer, _ldap As Integer, _Nameimg As String,
                                              _prec As Double, _prev As Double, _prevSocio As Double, _prevInterno As Double) As Boolean
        Dim _resultado As Boolean
        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)
        _listParam.Add(New Datos.DParametro("@tipo", 1))
        _listParam.Add(New Datos.DParametro("@ldnumi", _ldnumi))
        _listParam.Add(New Datos.DParametro("@ldcprod", _ldcprod))
        _listParam.Add(New Datos.DParametro("@ldcdprod1", _ldcdprod1))
        _listParam.Add(New Datos.DParametro("@ldgr1", _ldgr))
        _listParam.Add(New Datos.DParametro("@ldumed", _ldumed))
        _listParam.Add(New Datos.DParametro("@ldsmin", _ldsmin))
        _listParam.Add(New Datos.DParametro("@ldap", _ldap))
        _listParam.Add(New Datos.DParametro("@ldimg", _Nameimg))
        _listParam.Add(New Datos.DParametro("@ldprec", _prec))
        _listParam.Add(New Datos.DParametro("@ldprev", _prev))
        _listParam.Add(New Datos.DParametro("@ldpreSocio", _prevSocio))
        _listParam.Add(New Datos.DParametro("@ldpreInterno", _prevInterno))
        _listParam.Add(New Datos.DParametro("@lduact", L_Usuario))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TCL003", _listParam)

        If _Tabla.Rows.Count > 0 Then
            _ldnumi = _Tabla.Rows(0).Item(0)
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function
    Public Shared Function L_prProductoModificar(ByRef _ldnumi As String, _ldcprod As String, _ldcdprod1 As String,
                                                 _ldgr As Integer, _ldumed As String, _ldsmin As Integer,
                                                 _ldap As Integer, _Nameimg As String, _prec As Double, _prev As Double, _prevSocio As Double, _prevInterno As Double) As Boolean
        Dim _resultado As Boolean
        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 2))
        _listParam.Add(New Datos.DParametro("@ldnumi", _ldnumi))
        _listParam.Add(New Datos.DParametro("@ldcprod", _ldcprod))
        _listParam.Add(New Datos.DParametro("@ldcdprod1", _ldcdprod1))
        _listParam.Add(New Datos.DParametro("@ldgr1", _ldgr))
        _listParam.Add(New Datos.DParametro("@ldumed", _ldumed))
        _listParam.Add(New Datos.DParametro("@ldsmin", _ldsmin))
        _listParam.Add(New Datos.DParametro("@ldap", _ldap))
        _listParam.Add(New Datos.DParametro("@ldimg", _Nameimg))
        _listParam.Add(New Datos.DParametro("@ldprec", _prec))
        _listParam.Add(New Datos.DParametro("@ldprev", _prev))
        _listParam.Add(New Datos.DParametro("@ldpreSocio", _prevSocio))
        _listParam.Add(New Datos.DParametro("@ldpreInterno", _prevInterno))
        _listParam.Add(New Datos.DParametro("@lduact", L_Usuario))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TCL003", _listParam)


        If _Tabla.Rows.Count > 0 Then
            _ldnumi = _Tabla.Rows(0).Item(0)
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function
    Public Shared Function L_prProductoBorrar(_numi As String, ByRef _mensaje As String) As Boolean

        Dim _resultado As Boolean

        If L_fnbValidarEliminacion(_numi, "TCL003", "ldnumi", _mensaje) = True Then
            Dim _Tabla As DataTable

            Dim _listParam As New List(Of Datos.DParametro)

            _listParam.Add(New Datos.DParametro("@tipo", -1))
            _listParam.Add(New Datos.DParametro("@ldnumi", _numi))
            _listParam.Add(New Datos.DParametro("@lduact", L_Usuario))
            _Tabla = D_ProcedimientoConParam("sp_Mam_TCL003", _listParam)

            If _Tabla.Rows.Count > 0 Then
                _numi = _Tabla.Rows(0).Item(0)
                _resultado = True
            Else
                _resultado = False
            End If
        Else
            _resultado = False
        End If

        Return _resultado
    End Function
#End Region
#Region "SERVICIO VENTA GRUA / REMOLQUE"
    Public Shared Function L_prReporteServiciosGeneralRemolque(_dateI As String, _dateF As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)
        _listParam.Add(New Datos.DParametro("@tipo", 9))
        _listParam.Add(New Datos.DParametro("@refechaI", _dateI))
        _listParam.Add(New Datos.DParametro("@refechaF", _dateF))
        _listParam.Add(New Datos.DParametro("@reuact", L_Usuario))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TCR003", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prReporteServiciosDetalleGeneralRemolque(_dateI As String, _dateF As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)
        _listParam.Add(New Datos.DParametro("@tipo", 16))
        _listParam.Add(New Datos.DParametro("@refechaI", _dateI))
        _listParam.Add(New Datos.DParametro("@refechaF", _dateF))
        _listParam.Add(New Datos.DParametro("@reuact", L_Usuario))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TCR003", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prReporteServiciosGeneralRemolque(_dateI As String, _dateF As String, _panumi As Integer) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)
        _listParam.Add(New Datos.DParametro("@tipo", 1))
        _listParam.Add(New Datos.DParametro("@refechaI", _dateI))
        _listParam.Add(New Datos.DParametro("@refechaF", _dateF))
        _listParam.Add(New Datos.DParametro("@panumi", _panumi))
        _listParam.Add(New Datos.DParametro("@reuact", L_Usuario))
        _Tabla = D_ProcedimientoConParam("sp_da_TCR003", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prReporteServiciosDetalleGeneralRemolque(_dateI As String, _dateF As String, _panumi As Integer) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)
        _listParam.Add(New Datos.DParametro("@tipo", 2))
        _listParam.Add(New Datos.DParametro("@refechaI", _dateI))
        _listParam.Add(New Datos.DParametro("@refechaF", _dateF))
        _listParam.Add(New Datos.DParametro("@panumi", _panumi))
        _listParam.Add(New Datos.DParametro("@reuact", L_Usuario))
        _Tabla = D_ProcedimientoConParam("sp_da_TCR003", _listParam)

        Return _Tabla
    End Function
    Public Shared Function L_prServicioVentaGruaGeneral() As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 3))
        _listParam.Add(New Datos.DParametro("@reuact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_Mam_TCR003", _listParam)

        Return _Tabla
    End Function
    Public Shared Function L_prReporteServicioVentaClienteRemolque(_NumiVenta As Integer) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 12))
        _listParam.Add(New Datos.DParametro("@rcnumi", _NumiVenta))
        _listParam.Add(New Datos.DParametro("@rcuact", L_Usuario))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TCR002", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prServicioVentaGruaAYUdaCLiente() As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 10))
        _listParam.Add(New Datos.DParametro("@rcuact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_Mam_TCR002", _listParam)

        Return _Tabla
    End Function
    Public Shared Function L_prServicioVentaGruaPoliticaDescuento(_numicliente As Integer,
                                                              _numiServicio As Integer) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 8))
        _listParam.Add(New Datos.DParametro("@rcuact", L_Usuario))
        _listParam.Add(New Datos.DParametro("@rctcl1cli", _numicliente))
        _listParam.Add(New Datos.DParametro("@serv", _numiServicio))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TCR002", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prServicioVentaGruaDetalle(_ldnumi As Integer) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 4))
        _listParam.Add(New Datos.DParametro("@renumi", _ldnumi))
        _listParam.Add(New Datos.DParametro("@reuact", L_Usuario))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TCR003", _listParam)
        Return _Tabla
    End Function

    Public Shared Function L_prCargarImagenes(_renumi As Integer) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 11))
        _listParam.Add(New Datos.DParametro("@renumi", _renumi))
        _listParam.Add(New Datos.DParametro("@reuact", L_Usuario))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TCR003", _listParam)
        Return _Tabla
    End Function
    Public Shared Function L_prServicioVentaAyudaVehiculoRemolque(_Placa As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 9))
        _listParam.Add(New Datos.DParametro("@rauact", L_Usuario))
        _listParam.Add(New Datos.DParametro("@placa", _Placa))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TCR001", _listParam)

        Return _Tabla
    End Function
    Public Shared Function L_prServicioVehiculoClienteRemolque() As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 6))
        _listParam.Add(New Datos.DParametro("@reuact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_Mam_TCR003", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prServicioVentaGruaAyudaServicio(_libTipoGrua As Integer) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 6))
        _listParam.Add(New Datos.DParametro("@rcuact", L_Usuario))
        _listParam.Add(New Datos.DParametro("@edtipo", _libTipoGrua))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TCR002", _listParam)

        Return _Tabla
    End Function
    Public Shared Function L_prServicioVehiculoClienteCliente() As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 11))
        _listParam.Add(New Datos.DParametro("@rcuact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_Mam_TCR002", _listParam)

        Return _Tabla
    End Function
    Public Shared Function L_prServicioVentaGruaAyudaVehiculo(_NumiCliente As Integer) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 9))
        _listParam.Add(New Datos.DParametro("@rcuact", L_Usuario))
        _listParam.Add(New Datos.DParametro("@rctcl1cli", _NumiCliente))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TCR002", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prReporteHistorialServiciosRemolque(_dateI As String, _dateF As String, _numiCli As Integer) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 14))
        _listParam.Add(New Datos.DParametro("@rcfechaI", _dateI))
        _listParam.Add(New Datos.DParametro("@rcfechaF", _dateF))
        _listParam.Add(New Datos.DParametro("@rctcl1cli", _numiCli))
        _listParam.Add(New Datos.DParametro("@rcuact", L_Usuario))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TCR002", _listParam)

        Return _Tabla
    End Function
    Public Shared Function L_prReporteDetalladoServRemolque(_dateI As String, _dateF As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)
        _listParam.Add(New Datos.DParametro("@tipo", 10))
        _listParam.Add(New Datos.DParametro("@refechaI", _dateI))
        _listParam.Add(New Datos.DParametro("@refechaF", _dateF))
        _listParam.Add(New Datos.DParametro("@reuact", L_Usuario))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TCR003", _listParam)

        Return _Tabla
    End Function
    Public Shared Function L_prReporteHistorialServiciosPorPlacarRemolque(_dateI As String, _dateF As String,
                                                        _numiVehiculo As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)
        _listParam.Add(New Datos.DParametro("@tipo", 15))
        _listParam.Add(New Datos.DParametro("@rcfechaI", _dateI))
        _listParam.Add(New Datos.DParametro("@rcfechaF", _dateF))
        _listParam.Add(New Datos.DParametro("@rctcl11veh", _numiVehiculo))
        _listParam.Add(New Datos.DParametro("@rcuact", L_Usuario))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TCR002", _listParam)

        Return _Tabla
    End Function
    Public Shared Function L_prServicioVentaGruaAyudaPersonal() As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 7))
        _listParam.Add(New Datos.DParametro("@rcuact", L_Usuario))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TCR002", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prServicioVentaGruaGrabar(ByRef _renumi As String, _retcr1cli As Integer, _retcr11vehcli As Integer, _retcg2veh As Integer, _retp1empl As Integer,
    _rencont As String, _refdoc As String, _rekmsa As Double, _rekmen As Double, _rehorsa As String, _rehoren As String, _retpago As Integer, _relat As Double, _relong As Double, _remefec As Double, _relugo As String, _relugd As String, _reobs As String, _TCR0031 As DataTable, _horfin As String, _TCR004 As DataTable, _remol As remolque) As Boolean

        Dim _resultado As Boolean
        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 1))
        _listParam.Add(New Datos.DParametro("@renumi", _renumi))
        _listParam.Add(New Datos.DParametro("@refdoc", _refdoc))
        _listParam.Add(New Datos.DParametro("@retcr1cli", _retcr1cli))
        _listParam.Add(New Datos.DParametro("@retcr11vehcli", _retcr11vehcli))
        _listParam.Add(New Datos.DParametro("@retcg2veh", _retcg2veh))
        _listParam.Add(New Datos.DParametro("@retp1empl", _retp1empl))
        _listParam.Add(New Datos.DParametro("@rencont", _rencont))
        _listParam.Add(New Datos.DParametro("@rekmsa", _rekmsa))
        _listParam.Add(New Datos.DParametro("@rekmen", _rekmen))
        _listParam.Add(New Datos.DParametro("@rehorsa", _rehorsa))
        _listParam.Add(New Datos.DParametro("@rehoren", _rehoren))
        _listParam.Add(New Datos.DParametro("@retpago", _retpago))
        _listParam.Add(New Datos.DParametro("@relat", _relat))
        _listParam.Add(New Datos.DParametro("@relong", _relong))
        _listParam.Add(New Datos.DParametro("@remefec", _remefec))
        _listParam.Add(New Datos.DParametro("@relugo", _relugo))
        _listParam.Add(New Datos.DParametro("@relugd", _relugd))
        _listParam.Add(New Datos.DParametro("@reobs", _reobs))
        _listParam.Add(New Datos.DParametro("@reuact", L_Usuario))
        _listParam.Add(New Datos.DParametro("@TCR0031", "", _TCR0031))
        '_listParam.Add(New Datos.DParametro("@TCR0032", "", _TCR0032))
        _listParam.Add(New Datos.DParametro("@nombreFactura", _remol.getfactura))
        _listParam.Add(New Datos.DParametro("@nit", _remol.getnit))
        _listParam.Add(New Datos.DParametro("@rehorfin", _horfin))
        _listParam.Add(New Datos.DParametro("@TCR004", "", _TCR004))
        _listParam.Add(New Datos.DParametro("@direccion", _remol.getdireccion))
        _listParam.Add(New Datos.DParametro("@telefono", _remol.gettelefono))

        _Tabla = D_ProcedimientoConParam("sp_Mam_TCR003", _listParam)

        If _Tabla.Rows.Count > 0 Then
            _renumi = _Tabla.Rows(0).Item(0)
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function
    Public Shared Function L_prServicioVentaGruaModificar(ByRef _renumi As String, _retcr1cli As Integer, _retcr11vehcli As Integer, _retcg2veh As Integer, _retp1empl As Integer,
    _rencont As String, _refdoc As String, _rekmsa As Double, _rekmen As Double, _rehorsa As String, _rehoren As String, _retpago As Integer, _relat As Double, _relong As Double, _remefec As Double, _relugo As String, _relugd As String, _reobs As String, _TCR0031 As DataTable, _horfin As String, _TCR004 As DataTable, _remolque As remolque) As Boolean

        '@hbnumi ,@hbnom  ,@hbdor ,@hbper   
        '	,@hbtipo   ,@hbsuc ,@hbobs,@newFecha,@newHora,@hbuact
        Dim _resultado As Boolean
        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)
        _listParam.Add(New Datos.DParametro("@tipo", 2))
        _listParam.Add(New Datos.DParametro("@renumi", _renumi))
        _listParam.Add(New Datos.DParametro("@retcr1cli", _retcr1cli))
        _listParam.Add(New Datos.DParametro("@retcr11vehcli", _retcr11vehcli))
        _listParam.Add(New Datos.DParametro("@retcg2veh", _retcg2veh))
        _listParam.Add(New Datos.DParametro("@refdoc", _refdoc))
        _listParam.Add(New Datos.DParametro("@retp1empl", _retp1empl))
        _listParam.Add(New Datos.DParametro("@rencont", _rencont))
        _listParam.Add(New Datos.DParametro("@rekmsa", _rekmsa))
        _listParam.Add(New Datos.DParametro("@rekmen", _rekmen))
        _listParam.Add(New Datos.DParametro("@rehorsa", _rehorsa))
        _listParam.Add(New Datos.DParametro("@rehoren", _rehoren))
        _listParam.Add(New Datos.DParametro("@retpago", _retpago))
        _listParam.Add(New Datos.DParametro("@relat", _relat))
        _listParam.Add(New Datos.DParametro("@relong", _relong))
        _listParam.Add(New Datos.DParametro("@remefec", _remefec))
        _listParam.Add(New Datos.DParametro("@relugo", _relugo))
        _listParam.Add(New Datos.DParametro("@relugd", _relugd))
        _listParam.Add(New Datos.DParametro("@reobs", _reobs))
        _listParam.Add(New Datos.DParametro("@reuact", L_Usuario))
        _listParam.Add(New Datos.DParametro("@TCR0031", "", _TCR0031))
        '_listParam.Add(New Datos.DParametro("@TCR0032", "", _TCR0032))  IMAGENES
        _listParam.Add(New Datos.DParametro("@nombreFactura", _remolque.getfactura))
        _listParam.Add(New Datos.DParametro("@nit", _remolque.getnit))
        _listParam.Add(New Datos.DParametro("@rehorfin", _horfin))
        _listParam.Add(New Datos.DParametro("@TCR004", "", _TCR004))
        _listParam.Add(New Datos.DParametro("@direccion", _remolque.getdireccion))
        _listParam.Add(New Datos.DParametro("@telefono", _remolque.gettelefono))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TCR003", _listParam)

        If _Tabla.Rows.Count > 0 Then
            _renumi = _Tabla.Rows(0).Item(0)
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function
    Public Shared Function L_prServicioVentaGruaBorrar(_numi As String, ByRef _mensaje As String) As Boolean

        Dim _resultado As Boolean

        If L_fnbValidarEliminacion(_numi, "TCR003", "renumi", _mensaje) = True Then
            Dim _Tabla As DataTable

            Dim _listParam As New List(Of Datos.DParametro)

            _listParam.Add(New Datos.DParametro("@tipo", -1))
            _listParam.Add(New Datos.DParametro("@renumi", _numi))
            _listParam.Add(New Datos.DParametro("@reuact", L_Usuario))

            _Tabla = D_ProcedimientoConParam("sp_Mam_TCR003", _listParam)

            If _Tabla.Rows.Count > 0 Then
                _numi = _Tabla.Rows(0).Item(0)
                _resultado = True
            Else
                _resultado = False
            End If
        Else
            _resultado = False
        End If

        Return _resultado
    End Function

    Public Shared Function L_prServicioVentaAYUdaCLienteRemolque() As DataTable
        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)
        _listParam.Add(New Datos.DParametro("@tipo", 5))
        _listParam.Add(New Datos.DParametro("@reuact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_Mam_TCR003", _listParam)

        Return _Tabla
    End Function
    Public Shared Function L_prExistePoliticaDescuentoServicioRemolque(_numicliente As Integer,
                                                                  _numiServicio As Integer) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 12))
        _listParam.Add(New Datos.DParametro("@reuact", L_Usuario))
        _listParam.Add(New Datos.DParametro("@retcr1cli", _numicliente))
        _listParam.Add(New Datos.DParametro("@serv", _numiServicio))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TCR003", _listParam)

        Return _Tabla
    End Function
    Public Shared Function L_prObtenerNumeroControlRemolque(_NumiVenta As Integer) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 14))
        _listParam.Add(New Datos.DParametro("@reuact", L_Usuario))
        _listParam.Add(New Datos.DParametro("@renumi", _NumiVenta))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TCR003", _listParam)

        Return _Tabla
    End Function
    Public Shared Function L_prObtenerHistorialdeServiciosPoliticaRemolque(_numicliente As Integer, _serv As Integer) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 13))
        _listParam.Add(New Datos.DParametro("@reuact", L_Usuario))
        _listParam.Add(New Datos.DParametro("@retcr1cli", _numicliente))
        _listParam.Add(New Datos.DParametro("@serv", _serv))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TCR003", _listParam)

        Return _Tabla
    End Function
    Public Shared Function L_prRemolqueVehiculo() As DataTable
        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)
        _listParam.Add(New Datos.DParametro("@tipo", 7))
        _listParam.Add(New Datos.DParametro("@reuact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_Mam_TCR003", _listParam)

        Return _Tabla
    End Function
    Public Shared Function L_prRemolqueObtenerPersonal() As DataTable
        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)
        _listParam.Add(New Datos.DParametro("@tipo", 8))
        _listParam.Add(New Datos.DParametro("@reuact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_Mam_TCR003", _listParam)

        Return _Tabla
    End Function
    Public Shared Function L_prObtenerServicioPoliticaRemolque() As DataTable
        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)
        _listParam.Add(New Datos.DParametro("@tipo", 15))
        _listParam.Add(New Datos.DParametro("@reuact", L_Usuario))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TCR003", _listParam)
        Return _Tabla
    End Function
#End Region



#Region "COMPRA DE PRODUCTOS LAVADERO"

    Public Shared Function L_prCompraLavaderoGeneral() As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 3))
        _listParam.Add(New Datos.DParametro("@lfuact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_Mam_TCL005", _listParam)

        Return _Tabla
    End Function




    Public Shared Function L_prCompraLavaderoDetalle(_lfnumi As Integer) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 4))
        _listParam.Add(New Datos.DParametro("@lfnumi", _lfnumi))
        _listParam.Add(New Datos.DParametro("@lfuact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_Mam_TCL005", _listParam)

        Return _Tabla
    End Function



    Public Shared Function L_prCompraLavaderoGrabar(ByRef _lfnumi As String, _lffecha As Date, _lfprov As Integer, _lfobs As String, _TCL0051 As DataTable, fechRecepcion As String) As Boolean

        ' @lfnumi ,@lffecha ,@lfprov ,@lfobs ,@newFecha,@newHora,@lfuact
        Dim _resultado As Boolean
        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 1))
        _listParam.Add(New Datos.DParametro("@lfnumi", _lfnumi))
        _listParam.Add(New Datos.DParametro("@lffecha", _lffecha))
        _listParam.Add(New Datos.DParametro("@lffechaRecepcion", fechRecepcion))
        _listParam.Add(New Datos.DParametro("@lfprov", _lfprov))
        _listParam.Add(New Datos.DParametro("@lfobs", _lfobs))
        _listParam.Add(New Datos.DParametro("@lfuact", L_Usuario))
        _listParam.Add(New Datos.DParametro("@TCL0051", "", _TCL0051))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TCL005", _listParam)

        If _Tabla.Rows.Count > 0 Then
            _lfnumi = _Tabla.Rows(0).Item(0)
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function
    Public Shared Function L_prCompraLavaderoModificar(ByRef _lfnumi As String, _lffecha As Date, _lfprov As Integer, _lfobs As String, _TCL0051 As DataTable, fechRecepcion As String) As Boolean

        '@hbnumi ,@hbnom  ,@hbdor ,@hbper   
        '	,@hbtipo   ,@hbsuc ,@hbobs,@newFecha,@newHora,@hbuact
        Dim _resultado As Boolean
        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 2))
        _listParam.Add(New Datos.DParametro("@lfnumi", _lfnumi))
        _listParam.Add(New Datos.DParametro("@lffecha", _lffecha))
        _listParam.Add(New Datos.DParametro("@lfprov", _lfprov))
        _listParam.Add(New Datos.DParametro("@lfobs", _lfobs))
        _listParam.Add(New Datos.DParametro("@lffechaRecepcion", fechRecepcion))
        _listParam.Add(New Datos.DParametro("@lfuact", L_Usuario))
        _listParam.Add(New Datos.DParametro("@TCL0051", "", _TCL0051))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TCL005", _listParam)

        If _Tabla.Rows.Count > 0 Then
            _lfnumi = _Tabla.Rows(0).Item(0)
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function
    Public Shared Function L_prCompraLavaderoBorrar(_numi As String, ByRef _mensaje As String) As Boolean

        Dim _resultado As Boolean

        If L_fnbValidarEliminacion(_numi, "TCL005", "rcnumi", _mensaje) = True Then
            Dim _Tabla As DataTable

            Dim _listParam As New List(Of Datos.DParametro)

            _listParam.Add(New Datos.DParametro("@tipo", -1))
            _listParam.Add(New Datos.DParametro("@lfnumi", _numi))
            _listParam.Add(New Datos.DParametro("@lfuact", L_Usuario))

            _Tabla = D_ProcedimientoConParam("sp_Mam_TCL005", _listParam)

            If _Tabla.Rows.Count > 0 Then
                _numi = _Tabla.Rows(0).Item(0)
                _resultado = True
            Else
                _resultado = False
            End If
        Else
            _resultado = False
        End If

        Return _resultado
    End Function


#End Region

#Region "SERVICIO VENTA"
    Public Shared Function L_prServicioVentaGeneral() As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 3))
        _listParam.Add(New Datos.DParametro("@lduact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_Mam_TCL002", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prServicioVehiculoCliente() As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 16))
        _listParam.Add(New Datos.DParametro("@lduact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_Mam_TCL002", _listParam)

        Return _Tabla
    End Function
    Public Shared Function L_prObtenerUltimoPagoSocio(_lansoc As Integer) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 17))
        _listParam.Add(New Datos.DParametro("@ldnsoc", _lansoc))
        _listParam.Add(New Datos.DParametro("@lduact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_Mam_TCL002", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prServicioVentaAYUdaCLiente() As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 10))
        _listParam.Add(New Datos.DParametro("@lduact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_Mam_TCL002", _listParam)

        Return _Tabla
    End Function
    Public Shared Function L_prExistePoliticaDescuentoServicio(_numicliente As Integer,
                                                              _numiServicio As Integer) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 8))
        _listParam.Add(New Datos.DParametro("@lduact", L_Usuario))
        _listParam.Add(New Datos.DParametro("@ldtcl1cli", _numicliente))
        _listParam.Add(New Datos.DParametro("@serv", _numiServicio))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TCL002", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prObtenerHistorialdeServiciosPolitica(_numicliente As Integer,
                                                            _numiServicio As Integer) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 15))
        _listParam.Add(New Datos.DParametro("@lduact", L_Usuario))
        _listParam.Add(New Datos.DParametro("@ldtcl1cli", _numicliente))
        _listParam.Add(New Datos.DParametro("@serv", _numiServicio))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TCL002", _listParam)

        Return _Tabla
    End Function
    Public Shared Function L_prObtenerNumeroOrden(_NumiVenta As Integer) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 19))
        _listParam.Add(New Datos.DParametro("@lduact", L_Usuario))
        _listParam.Add(New Datos.DParametro("@ldnumi", _NumiVenta))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TCL002", _listParam)

        Return _Tabla
    End Function
    Public Shared Function L_prObtenerServicioPolitica() As DataTable
        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)
        _listParam.Add(New Datos.DParametro("@tipo", 20))
        _listParam.Add(New Datos.DParametro("@lduact", L_Usuario))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TCL002", _listParam)
        Return _Tabla
    End Function

    Public Shared Function L_prServicioVentaDetalle(_ldnumi As Integer) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 4))
        _listParam.Add(New Datos.DParametro("@ldnumi", _ldnumi))
        _listParam.Add(New Datos.DParametro("@lduact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_Mam_TCL002", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prServicioVentaAyudaServicio(_libTipoLavado As Integer, _Lib1_4 As Integer, _detalle As DataTable, _tipoCliente As Integer) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 6))
        _listParam.Add(New Datos.DParametro("@lduact", L_Usuario))
        _listParam.Add(New Datos.DParametro("@edtipo", _libTipoLavado))
        _listParam.Add(New Datos.DParametro("@lbtip1_4", _Lib1_4))
        _listParam.Add(New Datos.DParametro("@tipoCliente", _tipoCliente))
        _listParam.Add(New Datos.DParametro("@TCL0021", "", _detalle))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TCL002", _listParam)

        Return _Tabla
    End Function
    Public Shared Function L_prServicioCargarRecepcion(_libTipoLavado As Integer, _Lib1_4 As Integer, _lfnumi As Integer, _latipo As Integer) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 27))
        _listParam.Add(New Datos.DParametro("@lduact", L_Usuario))
        _listParam.Add(New Datos.DParametro("@edtipo", _libTipoLavado))
        _listParam.Add(New Datos.DParametro("@lbtip1_4", _Lib1_4))
        _listParam.Add(New Datos.DParametro("@lfnumi", _lfnumi))
        _listParam.Add(New Datos.DParametro("@tipoCliente", _latipo))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TCL002", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prProductoGeneralLavadero(_dt As DataTable, TipoCliente As Integer) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 25))
        _listParam.Add(New Datos.DParametro("@lduact", L_Usuario))
        _listParam.Add(New Datos.DParametro("@tipoCliente", TipoCliente))
        _listParam.Add(New Datos.DParametro("@TCL0021", "", _dt))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TCL002", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prServiciostodosModulostodosClientes() As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 29))
        _listParam.Add(New Datos.DParametro("@lduact", L_Usuario))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TCL002", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prServiciosUnModulostodosClientes(Modulo As Integer) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 30))
        _listParam.Add(New Datos.DParametro("@lduact", L_Usuario))
        _listParam.Add(New Datos.DParametro("@modulo", Modulo))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TCL002", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prServiciosTodosModuloUnClientes(cliente As Integer) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 31))
        _listParam.Add(New Datos.DParametro("@lduact", L_Usuario))
        _listParam.Add(New Datos.DParametro("@tipoCliente", cliente))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TCL002", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prServiciosUnModuloUnClientes(modulo As Integer, cliente As Integer) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 32))
        _listParam.Add(New Datos.DParametro("@lduact", L_Usuario))
        _listParam.Add(New Datos.DParametro("@tipoCliente", cliente))
        _listParam.Add(New Datos.DParametro("@modulo", modulo))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TCL002", _listParam)

        Return _Tabla
    End Function
    Public Shared Function L_prServicioVentaAyudaVehiculo(_Placa As String) As DataTable
        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)
        _listParam.Add(New Datos.DParametro("@tipo", 9))
        _listParam.Add(New Datos.DParametro("@lduact", L_Usuario))
        _listParam.Add(New Datos.DParametro("@placa", _Placa))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TCL002", _listParam)
        Return _Tabla
    End Function
    Public Shared Function L_prObtenerDatosReporteNOrden(_numiOrden As String) As DataTable
        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)
        _listParam.Add(New Datos.DParametro("@tipo", 8))
        _listParam.Add(New Datos.DParametro("@lfuact", L_Usuario))
        _listParam.Add(New Datos.DParametro("@lfnumi", _numiOrden))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TCL006", _listParam)
        Return _Tabla
    End Function
    Public Shared Function L_prObtenerDatosReporteNOrdenInv(_numiOrden As String) As DataTable
        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)
        _listParam.Add(New Datos.DParametro("@tipo", 9))
        _listParam.Add(New Datos.DParametro("@lfuact", L_Usuario))
        _listParam.Add(New Datos.DParametro("@lfnumi", _numiOrden))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TCL006", _listParam)
        Return _Tabla
    End Function

    Public Shared Function L_prServicioVentaAyudaPersonal() As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 7))
        _listParam.Add(New Datos.DParametro("@lduact", L_Usuario))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TCL002", _listParam)

        Return _Tabla
    End Function
    Public Shared Function L_prServicioVentaNumeroOrdenGeneral() As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 26))
        _listParam.Add(New Datos.DParametro("@lduact", L_Usuario))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TCL002", _listParam)

        Return _Tabla
    End Function


    Public Shared Function L_prServicioVentaGrabar(ByRef _ldnumi As String, _ldtcl1cli As Integer, _ldnord As String,
                                                   _ldtcl11veh As Integer,
    _ldfdoc As String, _estado As Integer, _ldmefec As String, _lbtipo As Integer, _TCL0021 As DataTable, _TCL004 As DataTable, _ldtablet As Integer, _ldTipoPago As Integer, _ldMoneda As Integer, _ldFechaCredito As String, _ldbanco As Integer, _ldobs As String, _ldtipo As Integer) As Boolean

        Dim _resultado As Boolean
        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 1))
        _listParam.Add(New Datos.DParametro("@ldnumi", _ldnumi))
        _listParam.Add(New Datos.DParametro("@ldsuc", 1))
        _listParam.Add(New Datos.DParametro("@ldtcl1cli", _ldtcl1cli))
        _listParam.Add(New Datos.DParametro("@ldtcl11veh", _ldtcl11veh))
        _listParam.Add(New Datos.DParametro("@ldtven", _ldTipoPago)) '''Tipo de Pago
        _listParam.Add(New Datos.DParametro("@ldfdoc", _ldfdoc))
        _listParam.Add(New Datos.DParametro("@ldtmon", _ldMoneda)) '''Moneda
        _listParam.Add(New Datos.DParametro("@ldest", _estado))
        _listParam.Add(New Datos.DParametro("@ldtpago", 1))
        _listParam.Add(New Datos.DParametro("@ldmefec", _ldmefec))
        _listParam.Add(New Datos.DParametro("@lbtip1_4", _lbtipo))
        _listParam.Add(New Datos.DParametro("@ldnord", _ldnord))
        _listParam.Add(New Datos.DParametro("@lduact", L_Usuario))
        _listParam.Add(New Datos.DParametro("@ldfvcr", _ldFechaCredito)) ''Credito
        _listParam.Add(New Datos.DParametro("@ldtablet", _ldtablet))
        _listParam.Add(New Datos.DParametro("@TCL0021", "", _TCL0021))
        _listParam.Add(New Datos.DParametro("@TCL004", "", _TCL004)) ''@ldfvcr
        _listParam.Add(New Datos.DParametro("@ldbanco", _ldbanco))
        _listParam.Add(New Datos.DParametro("@ldobs", _ldobs))
        _listParam.Add(New Datos.DParametro("@ldtipo", _ldtipo))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TCL002", _listParam)

        If _Tabla.Rows.Count > 0 Then
            _ldnumi = _Tabla.Rows(0).Item(0)
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function
    Public Shared Function L_prServicioVentaModificar(ByRef _ldnumi As String, _ldtcl1cli As Integer, _ldtcl11veh As Integer, _ldnord As String,
    _ldfdoc As String, _estado As Integer, _ldmefec As String, _lbtipo As Integer, _TCL0021 As DataTable, _tcl004 As DataTable, _ldtablet As Integer, _ldTipoPago As Integer, _ldMoneda As Integer, _ldFechaCredito As String, _ldbanco As Integer, _ldobs As String, _ldtipo As Integer) As Boolean

        '@hbnumi ,@hbnom  ,@hbdor ,@hbper   
        '	,@hbtipo   ,@hbsuc ,@hbobs,@newFecha,@newHora,@hbuact
        Dim _resultado As Boolean
        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 2))
        _listParam.Add(New Datos.DParametro("@ldnumi", _ldnumi))
        _listParam.Add(New Datos.DParametro("@ldsuc", 1))
        _listParam.Add(New Datos.DParametro("@ldtcl1cli", _ldtcl1cli))
        _listParam.Add(New Datos.DParametro("@ldtcl11veh", _ldtcl11veh))
        _listParam.Add(New Datos.DParametro("@ldtpago", 1))
        _listParam.Add(New Datos.DParametro("@ldfdoc", _ldfdoc))
        _listParam.Add(New Datos.DParametro("@ldtmon", _ldMoneda))
        _listParam.Add(New Datos.DParametro("@ldest", _estado))
        _listParam.Add(New Datos.DParametro("@ldtven", _ldTipoPago))
        _listParam.Add(New Datos.DParametro("@ldmefec", _ldmefec))
        _listParam.Add(New Datos.DParametro("@lbtip1_4", _lbtipo))
        _listParam.Add(New Datos.DParametro("@ldnord", _ldnord))
        _listParam.Add(New Datos.DParametro("@lduact", L_Usuario))
        _listParam.Add(New Datos.DParametro("@ldfvcr", _ldFechaCredito)) ''Credito
        _listParam.Add(New Datos.DParametro("@ldtablet", _ldtablet))
        _listParam.Add(New Datos.DParametro("@TCL0021", "", _TCL0021))
        _listParam.Add(New Datos.DParametro("@TCL004", "", _tcl004))
        _listParam.Add(New Datos.DParametro("@ldbanco", _ldbanco))
        _listParam.Add(New Datos.DParametro("@ldobs", _ldobs))
        _listParam.Add(New Datos.DParametro("@ldtipo", _ldtipo))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TCL002", _listParam)

        If _Tabla.Rows.Count > 0 Then
            _ldnumi = _Tabla.Rows(0).Item(0)
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function
    Public Shared Function L_prServicioVentaBorrar(_numi As String, ByRef _mensaje As String) As Boolean

        Dim _resultado As Boolean

        If L_fnbValidarEliminacion(_numi, "TCL002", "ldnumi", _mensaje) = True Then
            Dim _Tabla As DataTable

            Dim _listParam As New List(Of Datos.DParametro)

            _listParam.Add(New Datos.DParametro("@tipo", -1))
            _listParam.Add(New Datos.DParametro("@ldnumi", _numi))
            _listParam.Add(New Datos.DParametro("@lduact", L_Usuario))

            _Tabla = D_ProcedimientoConParam("sp_Mam_TCL002", _listParam)

            If _Tabla.Rows.Count > 0 Then
                _numi = _Tabla.Rows(0).Item(0)
                _resultado = True
            Else
                _resultado = False
            End If
        Else
            _resultado = False
        End If

        Return _resultado
    End Function
    Public Shared Function L_prReporteServiciosLavaderoPorPlaca(_dateI As Date, _dateF As Date) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)
        _listParam.Add(New Datos.DParametro("@tipo", 11))
        _listParam.Add(New Datos.DParametro("@ldfechaI", _dateI))
        _listParam.Add(New Datos.DParametro("@ldfechaF", _dateF))
        _listParam.Add(New Datos.DParametro("@lduact", L_Usuario))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TCL002", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prReporteServiciosGeneral(_dateI As Date, _dateF As Date) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 13))
        _listParam.Add(New Datos.DParametro("@ldfechaI", _dateI))
        _listParam.Add(New Datos.DParametro("@ldfechaF", _dateF))
        _listParam.Add(New Datos.DParametro("@lduact", L_Usuario))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TCL002", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prReporteServiciosGeneralTipoVenta(_dateI As Date, _dateF As Date) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 28))
        _listParam.Add(New Datos.DParametro("@ldfechaI", _dateI))
        _listParam.Add(New Datos.DParametro("@ldfechaF", _dateF))
        _listParam.Add(New Datos.DParametro("@lduact", L_Usuario))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TCL002", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prReporteHistorialDescuentos() As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 21))
        _listParam.Add(New Datos.DParametro("@lduact", L_Usuario))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TCL002", _listParam)

        Return _Tabla
    End Function
    Public Shared Function L_prReporteHistorialDescuentosCliente(_nsoc) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 24))
        _listParam.Add(New Datos.DParametro("@ldnsoc", _nsoc))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TCL002", _listParam)

        Return _Tabla
    End Function
    Public Shared Function L_prAyudaHistorialDescuentos(ano As Integer) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 22))
        _listParam.Add(New Datos.DParametro("@ano", ano))
        _listParam.Add(New Datos.DParametro("@lduact", L_Usuario))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TCL002", _listParam)

        Return _Tabla
    End Function
    Public Shared Function L_prAyudaHistorialDescuentosPorCliente(_nsoc, ano) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 23))
        _listParam.Add(New Datos.DParametro("@ldnsoc", _nsoc))
        _listParam.Add(New Datos.DParametro("@ano", ano))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TCL002", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prReporteServicioVentaCliente(_NumiVenta As Integer) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 12))
        _listParam.Add(New Datos.DParametro("@ldnumi", _NumiVenta))
        _listParam.Add(New Datos.DParametro("@lduact", L_Usuario))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TCL002", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prReporteHistorialServicios(_dateI As Date, _dateF As Date,
                                                         _numiCli As Integer) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 14))
        _listParam.Add(New Datos.DParametro("@ldfechaI", _dateI))
        _listParam.Add(New Datos.DParametro("@ldfechaF", _dateF))
        _listParam.Add(New Datos.DParametro("@ldtcl1cli", _numiCli))
        _listParam.Add(New Datos.DParametro("@lduact", L_Usuario))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TCL002", _listParam)

        Return _Tabla
    End Function
    Public Shared Function L_prReporteHistorialServiciosPorPlaca(_dateI As Date, _dateF As Date,
                                                        _numiVehiculo As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)
        _listParam.Add(New Datos.DParametro("@tipo", 18))
        _listParam.Add(New Datos.DParametro("@ldfechaI", _dateI))
        _listParam.Add(New Datos.DParametro("@ldfechaF", _dateF))
        _listParam.Add(New Datos.DParametro("@ldtcl11veh", _numiVehiculo))
        _listParam.Add(New Datos.DParametro("@lduact", L_Usuario))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TCL002", _listParam)

        Return _Tabla
    End Function


    Public Shared Function L_prObtenerTiposVehiculos() As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)
        _listParam.Add(New Datos.DParametro("@tipo", 6))
        _listParam.Add(New Datos.DParametro("@lfuact", L_Usuario))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TCL006", _listParam)

        Return _Tabla
    End Function
#End Region
#Region "POLITICA"
    Public Shared Function L_prLibreriaPoliticaGeneral(_cod1 As Integer, _cod2 As Integer) As DataTable
        Dim _Tabla As DataTable

        Dim _listPalam As New List(Of Datos.DParametro)

        _listPalam.Add(New Datos.DParametro("@tipo", 3))
        _listPalam.Add(New Datos.DParametro("@cfuact", L_Usuario))
        _listPalam.Add(New Datos.DParametro("@cdcod1", _cod1))
        _listPalam.Add(New Datos.DParametro("@cdcod2", _cod2))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TC006", _listPalam)

        Return _Tabla
    End Function

    Public Shared Function L_prLibreriaPoliticaComboGeneral(_cod1 As Integer, _cod2 As Integer) As DataTable
        Dim _Tabla As DataTable

        Dim _listPalam As New List(Of Datos.DParametro)

        _listPalam.Add(New Datos.DParametro("@tipo", 4))
        _listPalam.Add(New Datos.DParametro("@cfuact", L_Usuario))
        _listPalam.Add(New Datos.DParametro("@cdcod1", _cod1))
        _listPalam.Add(New Datos.DParametro("@cdcod2", _cod2))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TC006", _listPalam)

        Return _Tabla
    End Function
    Public Shared Function L_prServiciosTabla(_value As Integer) As DataTable
        Dim _Tabla As DataTable

        Dim _listPalam As New List(Of Datos.DParametro)

        _listPalam.Add(New Datos.DParametro("@tipo", 5))
        _listPalam.Add(New Datos.DParametro("@cfuact", L_Usuario))
        _listPalam.Add(New Datos.DParametro("@CodTipo", _value))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TC006", _listPalam)

        Return _Tabla
    End Function


    Public Shared Function L_prServiciosTablaRemolqueLibreria() As DataTable
        Dim _Tabla As DataTable

        Dim _listPalam As New List(Of Datos.DParametro)

        _listPalam.Add(New Datos.DParametro("@tipo", 15))
        _listPalam.Add(New Datos.DParametro("@reuact", L_Usuario))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TCR003", _listPalam)

        Return _Tabla
    End Function


    Public Shared Function L_prPoliticaGrabar(ByRef _numi As String, _tipo As Integer, _cuota As Integer, _cant As Integer, _desc As Integer, _obs As String, _serv As Integer) As Boolean
        Dim _resultado As Boolean

        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 1))
        _listParam.Add(New Datos.DParametro("@cfnumi", _numi))
        _listParam.Add(New Datos.DParametro("@cftipo", _tipo))
        _listParam.Add(New Datos.DParametro("@cfcuota", _cuota))
        _listParam.Add(New Datos.DParametro("@cfcant", _cant))
        _listParam.Add(New Datos.DParametro("@cfdesc", _desc))
        _listParam.Add(New Datos.DParametro("@cfobs", _obs))
        _listParam.Add(New Datos.DParametro("@cftce4ser", _serv))
        _listParam.Add(New Datos.DParametro("@cfuact", L_Usuario))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TC006", _listParam)

        If _Tabla.Rows.Count > 0 Then
            _numi = _Tabla.Rows(0).Item(0)

            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function

    Public Shared Function L_prPoliticaModificar(ByRef _numi As String, _tipo As Integer, _cuota As Integer, _cant As Integer, _desc As Integer, _obs As String, _serv As Integer) As Boolean
        Dim _resultado As Boolean


        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 2))
        _listParam.Add(New Datos.DParametro("@cfnumi", _numi))
        _listParam.Add(New Datos.DParametro("@cftipo", _tipo))
        _listParam.Add(New Datos.DParametro("@cfcuota", _cuota))
        _listParam.Add(New Datos.DParametro("@cfcant", _cant))
        _listParam.Add(New Datos.DParametro("@cfdesc", _desc))
        _listParam.Add(New Datos.DParametro("@cfobs", _obs))
        _listParam.Add(New Datos.DParametro("@cftce4ser", _serv))
        _listParam.Add(New Datos.DParametro("@cfuact", L_Usuario))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TC006", _listParam)

        If _Tabla.Rows.Count > 0 Then
            _numi = _Tabla.Rows(0).Item(0)
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function

    Public Shared Function L_prPoliticaBorrar(_numi As String, ByRef _mensaje As String) As Boolean

        Dim _resultado As Boolean

        If L_fnbValidarEliminacion(_numi, "TC006", "cfnumi", _mensaje) = True Then
            Dim _Tabla As DataTable

            Dim _listParam As New List(Of Datos.DParametro)

            _listParam.Add(New Datos.DParametro("@tipo", -1))
            _listParam.Add(New Datos.DParametro("@cfnumi", _numi))
            _listParam.Add(New Datos.DParametro("@cfuact", L_Usuario))

            _Tabla = D_ProcedimientoConParam("sp_Mam_TC006", _listParam)

            If _Tabla.Rows.Count > 0 Then
                _numi = _Tabla.Rows(0).Item(0)
                _resultado = True
            Else
                _resultado = False
            End If
        Else
            _resultado = False
        End If

        Return _resultado
    End Function
#End Region
#Region "CABAñA"
    Public Shared Function L_prCabañaTipoCombo(Optional _Cadena As String = "", Optional _order As String = "") As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 5))
        _listParam.Add(New Datos.DParametro("@cdcod1", 12))
        _listParam.Add(New Datos.DParametro("@cdcod2", 1))
        _listParam.Add(New Datos.DParametro("@hbuact", L_Usuario))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TCH002", _listParam)

        Return _Tabla
    End Function
    Public Shared Function L_prCabañaGeneral(_cod1 As String, _cod2 As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 3))
        _listParam.Add(New Datos.DParametro("@hbuact", L_Usuario))
        _listParam.Add(New Datos.DParametro("@cdcod1", _cod1))
        _listParam.Add(New Datos.DParametro("@cdcod2", _cod2))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TCH002", _listParam)

        Return _Tabla
    End Function
    Public Shared Function L_prCabañaGeneraldgr(_cod1 As String, _cod2 As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 3))
        _listParam.Add(New Datos.DParametro("@hbuact", L_Usuario))
        _listParam.Add(New Datos.DParametro("@cdcod1", _cod1))
        _listParam.Add(New Datos.DParametro("@cdcod2", _cod2))
        _Tabla = D_ProcedimientoConParam("sp_dg_TCH002", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prCabañaDetalleGeneraldgr(_numi As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 7))
        _listParam.Add(New Datos.DParametro("@hbnumi", _numi))
        _listParam.Add(New Datos.DParametro("@hbuact", L_Usuario))
        _Tabla = D_ProcedimientoConParam("sp_dg_TCH002", _listParam)

        Return _Tabla
    End Function
    Public Shared Function L_prCabañaDetalleBasicodgr(_numi As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 8))
        _listParam.Add(New Datos.DParametro("@hbnumi", _numi))
        _listParam.Add(New Datos.DParametro("@hbuact", L_Usuario))
        _Tabla = D_ProcedimientoConParam("sp_dg_TCH002", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prCabañaImagenes(_hbnumi As Integer) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 6))
        _listParam.Add(New Datos.DParametro("@hbnumi", _hbnumi))
        _listParam.Add(New Datos.DParametro("@hbuact", L_Usuario))
        _Tabla = D_ProcedimientoConParam("sp_dg_TCH002", _listParam)

        Return _Tabla
    End Function
    Public Shared Function L_prCabañaGrabar(ByRef _numi As String, _nom As String, _dor As Integer, _per As Integer, _tipo As Integer,
                                               _obs As String, _TCH0021 As DataTable) As Boolean

        '@hbnumi ,@hbnom  ,@hbdor ,@hbper   
        '	,@hbtipo   ,@hbsuc ,@hbobs,@newFecha,@newHora,@hbuact
        Dim _resultado As Boolean
        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 1))
        _listParam.Add(New Datos.DParametro("@hbnumi", _numi))
        _listParam.Add(New Datos.DParametro("@hbnom", _nom))
        _listParam.Add(New Datos.DParametro("@hbdor", _dor))
        _listParam.Add(New Datos.DParametro("@hbper", _per))
        _listParam.Add(New Datos.DParametro("@hbtipo", _tipo))
        _listParam.Add(New Datos.DParametro("@hbsuc", 1))
        _listParam.Add(New Datos.DParametro("@hbobs", _obs))
        _listParam.Add(New Datos.DParametro("@hbuact", L_Usuario))
        _listParam.Add(New Datos.DParametro("@TCH0021", "", _TCH0021))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TCH002", _listParam)

        If _Tabla.Rows.Count > 0 Then
            _numi = _Tabla.Rows(0).Item(0)
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function

    Public Shared Function L_prCabañaGrabardgr(ByRef _numi As String, _nom As String, _dor As Integer, _per As Integer, _tipo As Integer,
                                               _obs As String, _cantPerMen As String, _TCH0021 As DataTable, _TCH0022 As DataTable) As Boolean

        '@hbnumi ,@hbnom  ,@hbdor ,@hbper   
        '	,@hbtipo   ,@hbsuc ,@hbobs,@newFecha,@newHora,@hbuact
        Dim _resultado As Boolean
        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 1))
        _listParam.Add(New Datos.DParametro("@hbnumi", _numi))
        _listParam.Add(New Datos.DParametro("@hbnom", _nom))
        _listParam.Add(New Datos.DParametro("@hbdor", _dor))
        _listParam.Add(New Datos.DParametro("@hbper", _per))
        _listParam.Add(New Datos.DParametro("@hbtipo", _tipo))
        _listParam.Add(New Datos.DParametro("@hbsuc", 1))
        _listParam.Add(New Datos.DParametro("@hbobs", _obs))
        _listParam.Add(New Datos.DParametro("@hbpermen", _cantPerMen))
        _listParam.Add(New Datos.DParametro("@hbuact", L_Usuario))
        _listParam.Add(New Datos.DParametro("@TCH0021", "", _TCH0021))
        _listParam.Add(New Datos.DParametro("@TCH0022", "", _TCH0022))
        _Tabla = D_ProcedimientoConParam("sp_dg_TCH002", _listParam)

        If _Tabla.Rows.Count > 0 Then
            _numi = _Tabla.Rows(0).Item(0)
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function
    Public Shared Function L_prCabañaModificar(ByRef _numi As String, _nom As String, _dor As Integer, _per As Integer, _tipo As Integer,
                                               _obs As String, _TCH0021 As DataTable) As Boolean

        '@hbnumi ,@hbnom  ,@hbdor ,@hbper   
        '	,@hbtipo   ,@hbsuc ,@hbobs,@newFecha,@newHora,@hbuact
        Dim _resultado As Boolean
        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 2))
        _listParam.Add(New Datos.DParametro("@hbnumi", _numi))
        _listParam.Add(New Datos.DParametro("@hbnom", _nom))
        _listParam.Add(New Datos.DParametro("@hbdor", _dor))
        _listParam.Add(New Datos.DParametro("@hbper", _per))
        _listParam.Add(New Datos.DParametro("@hbtipo", _tipo))
        _listParam.Add(New Datos.DParametro("@hbsuc", 1))
        _listParam.Add(New Datos.DParametro("@hbobs", _obs))
        _listParam.Add(New Datos.DParametro("@hbuact", L_Usuario))
        _listParam.Add(New Datos.DParametro("@TCH0021", "", _TCH0021))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TCH002", _listParam)

        If _Tabla.Rows.Count > 0 Then
            _numi = _Tabla.Rows(0).Item(0)
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function

    Public Shared Function L_prCabañaModificardgr(ByRef _numi As String, _nom As String, _dor As Integer, _per As Integer, _tipo As Integer,
                                               _obs As String, _cantPerMen As String, _TCH0021 As DataTable, _TCH0022 As DataTable) As Boolean

        '@hbnumi ,@hbnom  ,@hbdor ,@hbper   
        '	,@hbtipo   ,@hbsuc ,@hbobs,@newFecha,@newHora,@hbuact
        Dim _resultado As Boolean
        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 2))
        _listParam.Add(New Datos.DParametro("@hbnumi", _numi))
        _listParam.Add(New Datos.DParametro("@hbnom", _nom))
        _listParam.Add(New Datos.DParametro("@hbdor", _dor))
        _listParam.Add(New Datos.DParametro("@hbper", _per))
        _listParam.Add(New Datos.DParametro("@hbtipo", _tipo))
        _listParam.Add(New Datos.DParametro("@hbsuc", 1))
        _listParam.Add(New Datos.DParametro("@hbobs", _obs))
        _listParam.Add(New Datos.DParametro("@hbpermen", _cantPerMen))
        _listParam.Add(New Datos.DParametro("@hbuact", L_Usuario))
        _listParam.Add(New Datos.DParametro("@TCH0021", "", _TCH0021))
        _listParam.Add(New Datos.DParametro("@TCH0022", "", _TCH0022))
        _Tabla = D_ProcedimientoConParam("sp_dg_TCH002", _listParam)

        If _Tabla.Rows.Count > 0 Then
            _numi = _Tabla.Rows(0).Item(0)
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function
    Public Shared Function L_prCabañaBorrar(_numi As String, ByRef _mensaje As String) As Boolean

        Dim _resultado As Boolean

        If L_fnbValidarEliminacion(_numi, "TCH002", "hbnumi", _mensaje) = True Then
            Dim _Tabla As DataTable

            Dim _listParam As New List(Of Datos.DParametro)

            _listParam.Add(New Datos.DParametro("@tipo", -1))
            _listParam.Add(New Datos.DParametro("@hbnumi", _numi))
            _listParam.Add(New Datos.DParametro("@hbuact", L_Usuario))

            _Tabla = D_ProcedimientoConParam("sp_dg_TCH002", _listParam)

            If _Tabla.Rows.Count > 0 Then
                _numi = _Tabla.Rows(0).Item(0)
                _resultado = True
            Else
                _resultado = False
            End If
        Else
            _resultado = False
        End If

        Return _resultado
    End Function


#End Region
#Region "TCG VEHICULO"
    Public Shared Function L_prLibreriaVehiculoGeneral(_cod1 As Integer, _cod2 As Integer) As DataTable
        Dim _Tabla As DataTable

        Dim _listPalam As New List(Of Datos.DParametro)

        _listPalam.Add(New Datos.DParametro("@tipo", 4))
        _listPalam.Add(New Datos.DParametro("@gcuact", L_Usuario))
        _listPalam.Add(New Datos.DParametro("@cdcod1", _cod1))
        _listPalam.Add(New Datos.DParametro("@cdcod2", _cod2))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TCG002", _listPalam)

        Return _Tabla
    End Function
    Public Shared Function L_prLibreriaTipoCliente(_cod1 As Integer, _cod2 As Integer) As DataTable
        Dim _Tabla As DataTable

        Dim _listPalam As New List(Of Datos.DParametro)

        _listPalam.Add(New Datos.DParametro("@tipo", 7))
        _listPalam.Add(New Datos.DParametro("@gcuact", L_Usuario))
        _listPalam.Add(New Datos.DParametro("@cdcod1", _cod1))
        _listPalam.Add(New Datos.DParametro("@cdcod2", _cod2))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TCG002", _listPalam)

        Return _Tabla
    End Function


    Public Shared Function L_prVehiculoSucursalAyuda(Optional _Cadena As String = "", Optional _order As String = "") As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 6))
        _listParam.Add(New Datos.DParametro("@gcuact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_Mam_TCG002", _listParam)

        Return _Tabla
    End Function


    Public Shared Function L_prTCGVehiculoGrabar(ByRef _numi As String, _id As String, _marca As String, _modelo As String, _persona As String, _obs As String, _tipo As String, _suc As String, _TCG0021 As DataTable) As Boolean
        Dim _resultado As Boolean

        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 1))
        _listParam.Add(New Datos.DParametro("@gcnumi", _numi))
        _listParam.Add(New Datos.DParametro("@gcid", _id))
        _listParam.Add(New Datos.DParametro("@gcmar", _marca))
        _listParam.Add(New Datos.DParametro("@gcmod", _modelo))
        _listParam.Add(New Datos.DParametro("@gcper", _persona))
        _listParam.Add(New Datos.DParametro("@gcobs", _obs))
        _listParam.Add(New Datos.DParametro("@gctipo", _tipo))
        _listParam.Add(New Datos.DParametro("@gcsuc", _suc))
        _listParam.Add(New Datos.DParametro("@gcuact", L_Usuario))
        _listParam.Add(New Datos.DParametro("@TCG0021", "", _TCG0021))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TCG002", _listParam)

        If _Tabla.Rows.Count > 0 Then
            _numi = _Tabla.Rows(0).Item(0)

            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function

    Public Shared Function L_prTCGVehiculoModificar(_numi As String, _id As String, _marca As String, _modelo As String, _persona As String, _obs As String, _tipo As String, _suc As String, _TCG0021 As DataTable) As Boolean
        Dim _resultado As Boolean
        Dim l As Integer = _TCG0021.Rows.Count

        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 2))
        _listParam.Add(New Datos.DParametro("@gcnumi", _numi))
        _listParam.Add(New Datos.DParametro("@gcid", _id))
        _listParam.Add(New Datos.DParametro("@gcmar", _marca))
        _listParam.Add(New Datos.DParametro("@gcmod", _modelo))
        _listParam.Add(New Datos.DParametro("@gcper", _persona))
        _listParam.Add(New Datos.DParametro("@gcobs", _obs))
        _listParam.Add(New Datos.DParametro("@gctipo", _tipo))
        _listParam.Add(New Datos.DParametro("@gcsuc", _suc))
        _listParam.Add(New Datos.DParametro("@gcuact", L_Usuario))
        _listParam.Add(New Datos.DParametro("@TCG0021", "", _TCG0021))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TCG002", _listParam)

        If _Tabla.Rows.Count > 0 Then
            _numi = _Tabla.Rows(0).Item(0)
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function

    Public Shared Function L_prTCGVehiculoBorrar(_numi As String, ByRef _mensaje As String) As Boolean

        Dim _resultado As Boolean

        If L_fnbValidarEliminacion(_numi, "TCG002", "gcnumi", _mensaje) = True Then
            Dim _Tabla As DataTable

            Dim _listParam As New List(Of Datos.DParametro)

            _listParam.Add(New Datos.DParametro("@tipo", -1))
            _listParam.Add(New Datos.DParametro("@gcnumi", _numi))
            _listParam.Add(New Datos.DParametro("@gcuact", L_Usuario))

            _Tabla = D_ProcedimientoConParam("sp_Mam_TCG002", _listParam)

            If _Tabla.Rows.Count > 0 Then
                _numi = _Tabla.Rows(0).Item(0)
                _resultado = True
            Else
                _resultado = False
            End If
        Else
            _resultado = False
        End If

        Return _resultado
    End Function

    Public Shared Function L_prTCGVehiculoGeneral(_suc As String, Optional _Cadena As String = "", Optional _order As String = "") As DataTable 'modelo 1 con condificion
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 3))
        _listParam.Add(New Datos.DParametro("@gcsuc", _suc))
        _listParam.Add(New Datos.DParametro("@gcuact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_Mam_TCG002", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prTCGVehiculoImagenes(_hbnumi As Integer) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 5))
        _listParam.Add(New Datos.DParametro("@gcnumi", _hbnumi))
        _listParam.Add(New Datos.DParametro("@gcuact", L_Usuario))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TCG002", _listParam)

        Return _Tabla
    End Function
#End Region
#Region "DBDies CLIENTE REMOLQUE"

    Public Shared Function L_prClienteRGeneral(_racod1 As Integer, _racod2 As Integer) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 3))
        _listParam.Add(New Datos.DParametro("@rauact", L_Usuario))
        _listParam.Add(New Datos.DParametro("@racod1", _racod1))
        _listParam.Add(New Datos.DParametro("@racod2", _racod2))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TCR001", _listParam)

        Return _Tabla
    End Function
    Public Shared Function L_prClienteVehiculoRemolque(_numi As Integer) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 6))
        _listParam.Add(New Datos.DParametro("@rauact", L_Usuario))
        _listParam.Add(New Datos.DParametro("@ranumi", _numi))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TCR001", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prClienteRGeneralSocios() As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 4))
        _listParam.Add(New Datos.DParametro("@rauact", L_Usuario))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TCR001", _listParam)

        Return _Tabla
    End Function
    Public Shared Function L_prClienteRVehiculoSocios(_cfnumi As Integer) As DataTable
        Dim _Tabla As DataTable

        Dim _listPalam As New List(Of Datos.DParametro)

        _listPalam.Add(New Datos.DParametro("@tipo", 7))
        _listPalam.Add(New Datos.DParametro("@cfnumi", _cfnumi))
        _listPalam.Add(New Datos.DParametro("@rauact", L_Usuario))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TCR001", _listPalam)

        Return _Tabla
    End Function

    Public Shared Function L_prLibreriaClienteRGeneral(_cod1 As String, _cod2 As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 5))
        _listParam.Add(New Datos.DParametro("@racod1", _cod1))
        _listParam.Add(New Datos.DParametro("@racod2", _cod2))
        _listParam.Add(New Datos.DParametro("@rauact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_Mam_TCR001", _listParam)

        Return _Tabla
    End Function
    Public Shared Function L_prClienteRGrabar(ByRef _ranumi As String, _ratipo As Integer, _ransoc As String, _rafing As String, _rafnac As String, _ranom As String, _raapat As String, _raamat As String, _radir As String, _raemail As String, _raci As String, _rafot As String, _raobs As String, _raest As Integer,
                                            _ratel1 As String, _ratel2 As String, _TCR0011 As DataTable) As Boolean
        Dim _resultado As Boolean
        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)
        _listParam.Add(New Datos.DParametro("@tipo", 1))
        _listParam.Add(New Datos.DParametro("@ranumi", _ranumi))
        _listParam.Add(New Datos.DParametro("@ratipo", _ratipo))
        _listParam.Add(New Datos.DParametro("@ransoc", _ransoc))
        _listParam.Add(New Datos.DParametro("@rafing", _rafing))
        _listParam.Add(New Datos.DParametro("@rafnac", _rafnac))
        _listParam.Add(New Datos.DParametro("@ranom", _ranom))
        _listParam.Add(New Datos.DParametro("@raapat", _raapat))
        _listParam.Add(New Datos.DParametro("@raamat", _raamat))
        _listParam.Add(New Datos.DParametro("@radir", _radir))
        _listParam.Add(New Datos.DParametro("@raemail", _raemail))
        _listParam.Add(New Datos.DParametro("@raci", _raci))
        _listParam.Add(New Datos.DParametro("@rafot", _rafot))
        _listParam.Add(New Datos.DParametro("@raobs", _raobs))
        _listParam.Add(New Datos.DParametro("@raest", _raest))
        _listParam.Add(New Datos.DParametro("@ratelf1", _ratel1))
        _listParam.Add(New Datos.DParametro("@ratelf2", _ratel2))
        _listParam.Add(New Datos.DParametro("@rauact", L_Usuario))
        _listParam.Add(New Datos.DParametro("@TCR0011", "", _TCR0011))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TCR001", _listParam)

        If _Tabla.Rows.Count > 0 Then
            _ranumi = _Tabla.Rows(0).Item(0)
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function
    Public Shared Function L_prClienteRGrabarRemolque(ByRef _ranumi As String, _ratipo As Integer, _ransoc As String, _rafing As String, _rafnac As String, _ranom As String, _raapat As String, _raamat As String, _radir As String, _raemail As String, _raci As String, _rafot As String, _raobs As String, _raest As Integer,
                                         _ratel1 As String, _ratel2 As String, _TCR0011 As DataTable) As Boolean
        Dim _resultado As Boolean
        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)
        _listParam.Add(New Datos.DParametro("@tipo", 8))
        _listParam.Add(New Datos.DParametro("@ranumi", _ranumi))
        _listParam.Add(New Datos.DParametro("@ratipo", _ratipo))
        _listParam.Add(New Datos.DParametro("@ransoc", _ransoc))
        _listParam.Add(New Datos.DParametro("@rafing", _rafing))
        _listParam.Add(New Datos.DParametro("@rafnac", _rafnac))
        _listParam.Add(New Datos.DParametro("@ranom", _ranom))
        _listParam.Add(New Datos.DParametro("@raapat", _raapat))
        _listParam.Add(New Datos.DParametro("@raamat", _raamat))
        _listParam.Add(New Datos.DParametro("@radir", _radir))
        _listParam.Add(New Datos.DParametro("@raemail", _raemail))
        _listParam.Add(New Datos.DParametro("@raci", _raci))
        _listParam.Add(New Datos.DParametro("@rafot", _rafot))
        _listParam.Add(New Datos.DParametro("@raobs", _raobs))
        _listParam.Add(New Datos.DParametro("@raest", _raest))
        _listParam.Add(New Datos.DParametro("@ratelf1", _ratel1))
        _listParam.Add(New Datos.DParametro("@ratelf2", _ratel2))
        _listParam.Add(New Datos.DParametro("@rauact", L_Usuario))
        _listParam.Add(New Datos.DParametro("@TCR0011", "", _TCR0011))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TCR001", _listParam)

        If _Tabla.Rows.Count > 0 Then
            _ranumi = _Tabla.Rows(0).Item(0)
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function
    Public Shared Function L_prClienteRModificar(ByRef _ranumi As String, _ratipo As Integer, _ransoc As String, _rafing As String, _rafnac As String, _ranom As String, _raapat As String, _raamat As String, _radir As String, _raemail As String, _raci As String, _rafot As String, _raobs As String, _raest As Integer,
                                            _ratel1 As String, _ratel2 As String, _TCR0011 As DataTable) As Boolean
        Dim _resultado As Boolean
        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)
        _listParam.Add(New Datos.DParametro("@tipo", 2))
        _listParam.Add(New Datos.DParametro("@ranumi", _ranumi))
        _listParam.Add(New Datos.DParametro("@ratipo", _ratipo))
        _listParam.Add(New Datos.DParametro("@ransoc", _ransoc))
        _listParam.Add(New Datos.DParametro("@rafing", _rafing))
        _listParam.Add(New Datos.DParametro("@rafnac", _rafnac))
        _listParam.Add(New Datos.DParametro("@ranom", _ranom))
        _listParam.Add(New Datos.DParametro("@raapat", _raapat))
        _listParam.Add(New Datos.DParametro("@raamat", _raamat))
        _listParam.Add(New Datos.DParametro("@radir", _radir))
        _listParam.Add(New Datos.DParametro("@raemail", _raemail))
        _listParam.Add(New Datos.DParametro("@raci", _raci))
        _listParam.Add(New Datos.DParametro("@rafot", _rafot))
        _listParam.Add(New Datos.DParametro("@raobs", _raobs))
        _listParam.Add(New Datos.DParametro("@raest", _raest))
        _listParam.Add(New Datos.DParametro("@ratelf1", _ratel1))
        _listParam.Add(New Datos.DParametro("@ratelf2", _ratel2))
        _listParam.Add(New Datos.DParametro("@TCR0011", "", _TCR0011))
        _listParam.Add(New Datos.DParametro("@rauact", L_Usuario))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TCR001", _listParam)


        If _Tabla.Rows.Count > 0 Then
            _ranumi = _Tabla.Rows(0).Item(0)
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function
    Public Shared Function L_prClienteRBorrar(_numi As String, ByRef _mensaje As String) As Boolean

        Dim _resultado As Boolean

        If L_fnbValidarEliminacion(_numi, "TCR001", "ranumi", _mensaje) = True Then
            Dim _Tabla As DataTable

            Dim _listParam As New List(Of Datos.DParametro)

            _listParam.Add(New Datos.DParametro("@tipo", -1))
            _listParam.Add(New Datos.DParametro("@ranumi", _numi))
            _listParam.Add(New Datos.DParametro("@rauact", L_Usuario))
            _Tabla = D_ProcedimientoConParam("sp_Mam_TCR001", _listParam)

            If _Tabla.Rows.Count > 0 Then
                _numi = _Tabla.Rows(0).Item(0)
                _resultado = True
            Else
                _resultado = False
            End If
        Else
            _resultado = False
        End If

        Return _resultado
    End Function

    Public Shared Function L_prClienteRVehiculo(_numi As Integer) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 6))
        _listParam.Add(New Datos.DParametro("@rauact", L_Usuario))
        _listParam.Add(New Datos.DParametro("@ranumi", _numi))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TCR001", _listParam)

        Return _Tabla
    End Function
#End Region

#Region "Bancos"
    Public Shared Function L_prBancoGeneral() As DataTable
        Dim _Tabla As DataTable
        't.canumi , t.canombre, t.cacuenta, t.caobs, t.cafact, t.cahact, t.cauact 
        Dim _listPalam As New List(Of Datos.DParametro)

        _listPalam.Add(New Datos.DParametro("@tipo", 3))
        _listPalam.Add(New Datos.DParametro("@cauact", L_Usuario))
        _Tabla = D_ProcedimientoConParam("sp_Mam_BA001", _listPalam)

        Return _Tabla
    End Function
    Public Shared Function L_prBancoGrabar(ByRef _canumi As String, _canombre As String, _cacuenta As String, _caobs As String, _img As String) As Boolean
        Dim _resultado As Boolean
        Dim _Tabla As DataTable
        Dim _listPalam As New List(Of Datos.DParametro)
        't.canumi , t.canombre, t.cacuenta, t.caobs, t.cafact, t.cahact, t.cauact 
        _listPalam.Add(New Datos.DParametro("@tipo", 1))
        _listPalam.Add(New Datos.DParametro("@canumi", _canumi))
        _listPalam.Add(New Datos.DParametro("@canombre", _canombre))
        _listPalam.Add(New Datos.DParametro("@cacuenta", _cacuenta))
        _listPalam.Add(New Datos.DParametro("@caobs", _caobs))
        _listPalam.Add(New Datos.DParametro("@caimg", _img))
        _listPalam.Add(New Datos.DParametro("@cauact", L_Usuario))
        _Tabla = D_ProcedimientoConParam("sp_Mam_BA001", _listPalam)

        If _Tabla.Rows.Count > 0 Then
            _canumi = _Tabla.Rows(0).Item(0)
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function

    Public Shared Function L_prBancoModificar(ByRef _canumi As String, _canombre As String, _cacuenta As String, _caobs As String, _img As String) As Boolean
        Dim _resultado As Boolean
        Dim _Tabla As DataTable
        Dim _listPalam As New List(Of Datos.DParametro)
        't.canumi , t.canombre, t.cacuenta, t.caobs, t.cafact, t.cahact, t.cauact 
        _listPalam.Add(New Datos.DParametro("@tipo", 2))
        _listPalam.Add(New Datos.DParametro("@canumi", _canumi))
        _listPalam.Add(New Datos.DParametro("@canombre", _canombre))
        _listPalam.Add(New Datos.DParametro("@cacuenta", _cacuenta))
        _listPalam.Add(New Datos.DParametro("@caobs", _caobs))
        _listPalam.Add(New Datos.DParametro("@caimg", _img))
        _listPalam.Add(New Datos.DParametro("@cauact", L_Usuario))
        _Tabla = D_ProcedimientoConParam("sp_Mam_BA001", _listPalam)

        If _Tabla.Rows.Count > 0 Then
            _canumi = _Tabla.Rows(0).Item(0)
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function
    Public Shared Function L_prBancoBorrar(_numi As String, ByRef _mensaje As String) As Boolean

        Dim _resultado As Boolean

        If L_fnbValidarEliminacion(_numi, "BA001", "canumi", _mensaje) = True Then
            Dim _Tabla As DataTable

            Dim _listPalam As New List(Of Datos.DParametro)

            _listPalam.Add(New Datos.DParametro("@tipo", -1))
            _listPalam.Add(New Datos.DParametro("@canumi", _numi))
            _listPalam.Add(New Datos.DParametro("@cauact", L_Usuario))
            _Tabla = D_ProcedimientoConParam("sp_Mam_BA001", _listPalam)

            If _Tabla.Rows.Count > 0 Then
                _numi = _Tabla.Rows(0).Item(0)
                _resultado = True
            Else
                _resultado = False
            End If
        Else
            _resultado = False
        End If

        Return _resultado
    End Function
#End Region

#Region "DBDies CLIENTE TCL001"

    Public Shared Function L_prClienteLGeneral(_cd1 As Integer, _cd2 As Integer) As DataTable
        Dim _Tabla As DataTable

        Dim _listPalam As New List(Of Datos.DParametro)

        _listPalam.Add(New Datos.DParametro("@tipo", 3))
        _listPalam.Add(New Datos.DParametro("@lauact", L_Usuario))
        _listPalam.Add(New Datos.DParametro("@lacod1", _cd1))
        _listPalam.Add(New Datos.DParametro("@lacod2", _cd2))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TCL001", _listPalam)

        Return _Tabla
    End Function



    Public Shared Function L_prClienteLGeneralSocios() As DataTable
        Dim _Tabla As DataTable

        Dim _listPalam As New List(Of Datos.DParametro)

        _listPalam.Add(New Datos.DParametro("@tipo", 4))
        _listPalam.Add(New Datos.DParametro("@lauact", L_Usuario))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TCL001", _listPalam)

        Return _Tabla
    End Function

    Public Shared Function L_prClienteLVehiculoSocios(_cfnumi As Integer) As DataTable
        Dim _Tabla As DataTable

        Dim _listPalam As New List(Of Datos.DParametro)

        _listPalam.Add(New Datos.DParametro("@tipo", 7))
        _listPalam.Add(New Datos.DParametro("@cfnumi", _cfnumi))
        _listPalam.Add(New Datos.DParametro("@lauact", L_Usuario))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TCL001", _listPalam)

        Return _Tabla
    End Function

    Public Shared Function L_prLibreriaClienteLGeneral(_cod1 As String, _cod2 As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listPalam As New List(Of Datos.DParametro)

        _listPalam.Add(New Datos.DParametro("@tipo", 5))
        _listPalam.Add(New Datos.DParametro("@lacod1", _cod1))
        _listPalam.Add(New Datos.DParametro("@lacod2", _cod2))
        _listPalam.Add(New Datos.DParametro("@lauact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_Mam_TCL001", _listPalam)

        Return _Tabla
    End Function


    Public Shared Function L_prClienteLVentaGrabar(ByRef _lanumi As String, _latipo As Integer, _lansoc As String, _lafing As String, _lafnac As String, _lanom As String, _laapat As String, _laamat As String, _ladir As String, _laemail As String, _laci As String, _lafot As String, _laobs As String, _laest As Integer, _latel1 As String, _latel2 As String, _TCL0011 As DataTable) As Boolean
        Dim _resultado As Boolean
        Dim _Tabla As DataTable
        Dim _listPalam As New List(Of Datos.DParametro)
        _listPalam.Add(New Datos.DParametro("@tipo", 8))
        _listPalam.Add(New Datos.DParametro("@lanumi", _lanumi))
        _listPalam.Add(New Datos.DParametro("@latipo", _latipo))
        _listPalam.Add(New Datos.DParametro("@lansoc", _lansoc))
        _listPalam.Add(New Datos.DParametro("@lafing", _lafing))
        _listPalam.Add(New Datos.DParametro("@lanom", _lanom))
        _listPalam.Add(New Datos.DParametro("@laest", _laest))
        _listPalam.Add(New Datos.DParametro("@latelf1", _latel1))
        _listPalam.Add(New Datos.DParametro("@latelf2", _latel2))
        _listPalam.Add(New Datos.DParametro("@lauact", L_Usuario))
        _listPalam.Add(New Datos.DParametro("@TCL0011", "", _TCL0011))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TCL001", _listPalam)

        If _Tabla.Rows.Count > 0 Then
            _lanumi = _Tabla.Rows(0).Item(0)
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function
    Public Shared Function L_prClienteLGrabar(ByRef _lanumi As String, _latipo As Integer, _lansoc As String, _lafing As String, _lafnac As String, _lanom As String, _laapat As String, _laamat As String, _ladir As String, _laemail As String, _laci As String, _lafot As String, _laobs As String, _laest As Integer, _latel1 As String, _latel2 As String, _TCL0011 As DataTable) As Boolean
        Dim _resultado As Boolean
        Dim _Tabla As DataTable
        Dim _listPalam As New List(Of Datos.DParametro)
        _listPalam.Add(New Datos.DParametro("@tipo", 1))
        _listPalam.Add(New Datos.DParametro("@lanumi", _lanumi))
        _listPalam.Add(New Datos.DParametro("@latipo", _latipo))
        _listPalam.Add(New Datos.DParametro("@lansoc", _lansoc))
        _listPalam.Add(New Datos.DParametro("@lafing", _lafing))
        _listPalam.Add(New Datos.DParametro("@lafnac", _lafnac))
        _listPalam.Add(New Datos.DParametro("@lanom", _lanom))
        _listPalam.Add(New Datos.DParametro("@laapat", _laapat))
        _listPalam.Add(New Datos.DParametro("@laamat", _laamat))
        _listPalam.Add(New Datos.DParametro("@ladir", _ladir))
        _listPalam.Add(New Datos.DParametro("@laemail", _laemail))
        _listPalam.Add(New Datos.DParametro("@laci", _laci))
        _listPalam.Add(New Datos.DParametro("@lafot", _lafot))
        _listPalam.Add(New Datos.DParametro("@laobs", _laobs))
        _listPalam.Add(New Datos.DParametro("@laest", _laest))
        _listPalam.Add(New Datos.DParametro("@latelf1", _latel1))
        _listPalam.Add(New Datos.DParametro("@latelf2", _latel2))
        _listPalam.Add(New Datos.DParametro("@lauact", L_Usuario))
        _listPalam.Add(New Datos.DParametro("@TCL0011", "", _TCL0011))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TCL001", _listPalam)

        If _Tabla.Rows.Count > 0 Then
            _lanumi = _Tabla.Rows(0).Item(0)
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function
    Public Shared Function L_prClienteLModificar(ByRef _lanumi As String, _latipo As Integer, _lansoc As String, _lafing As String, _lafnac As String, _lanom As String, _laapat As String, _laamat As String, _ladir As String, _laemail As String, _laci As String, _lafot As String, _laobs As String, _laest As Integer, _latel1 As String, _latel2 As String, _TCL0011 As DataTable) As Boolean
        Dim _resultado As Boolean
        Dim _Tabla As DataTable
        Dim _listPalam As New List(Of Datos.DParametro)
        _listPalam.Add(New Datos.DParametro("@tipo", 2))
        _listPalam.Add(New Datos.DParametro("@lanumi", _lanumi))
        _listPalam.Add(New Datos.DParametro("@latipo", _latipo))
        _listPalam.Add(New Datos.DParametro("@lansoc", _lansoc))
        _listPalam.Add(New Datos.DParametro("@lafing", _lafing))
        _listPalam.Add(New Datos.DParametro("@lafnac", _lafnac))
        _listPalam.Add(New Datos.DParametro("@lanom", _lanom))
        _listPalam.Add(New Datos.DParametro("@laapat", _laapat))
        _listPalam.Add(New Datos.DParametro("@laamat", _laamat))
        _listPalam.Add(New Datos.DParametro("@ladir", _ladir))
        _listPalam.Add(New Datos.DParametro("@laemail", _laemail))
        _listPalam.Add(New Datos.DParametro("@laci", _laci))
        _listPalam.Add(New Datos.DParametro("@lafot", _lafot))
        _listPalam.Add(New Datos.DParametro("@laobs", _laobs))
        _listPalam.Add(New Datos.DParametro("@laest", _laest))
        _listPalam.Add(New Datos.DParametro("@latelf1", _latel1))
        _listPalam.Add(New Datos.DParametro("@latelf2", _latel2))
        _listPalam.Add(New Datos.DParametro("@lauact", L_Usuario))
        _listPalam.Add(New Datos.DParametro("@lacod1", "1"))
        _listPalam.Add(New Datos.DParametro("@lacod2", "2"))
        _listPalam.Add(New Datos.DParametro("@TCL0011", "", _TCL0011))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TCL001", _listPalam)


        If _Tabla.Rows.Count > 0 Then
            _lanumi = _Tabla.Rows(0).Item(0)
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function
    Public Shared Function L_prClienteLBorrar(_numi As String, ByRef _mensaje As String) As Boolean

        Dim _resultado As Boolean

        If L_fnbValidarEliminacion(_numi, "TCL001", "lanumi", _mensaje) = True Then
            Dim _Tabla As DataTable

            Dim _listPalam As New List(Of Datos.DParametro)

            _listPalam.Add(New Datos.DParametro("@tipo", -1))
            _listPalam.Add(New Datos.DParametro("@lanumi", _numi))
            _listPalam.Add(New Datos.DParametro("@lauact", L_Usuario))
            _Tabla = D_ProcedimientoConParam("sp_Mam_TCL001", _listPalam)

            If _Tabla.Rows.Count > 0 Then
                _numi = _Tabla.Rows(0).Item(0)
                _resultado = True
            Else
                _resultado = False
            End If
        Else
            _resultado = False
        End If

        Return _resultado
    End Function
    Public Shared Function L_prClienteLVehiculo(_numi As Integer) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 6))
        _listParam.Add(New Datos.DParametro("@lauact", L_Usuario))
        _listParam.Add(New Datos.DParametro("@lanumi", _numi))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TCL001", _listParam)

        Return _Tabla
    End Function

#End Region
#Region "DBDies CLIENTE TCH001"

    Public Shared Function L_prClienteHGeneral(_cod1 As String, _cod2 As String) As DataTable
        Dim _Tabha As DataTable

        Dim _listPaham As New List(Of Datos.DParametro)

        _listPaham.Add(New Datos.DParametro("@tipo", 3))
        _listPaham.Add(New Datos.DParametro("@hauact", L_Usuario))
        _listPaham.Add(New Datos.DParametro("@hacod1", _cod1))
        _listPaham.Add(New Datos.DParametro("@hacod2", _cod2))
        _Tabha = D_ProcedimientoConParam("sp_Mam_TCH001", _listPaham)

        Return _Tabha
    End Function

    Public Shared Function L_prClienteHGeneralSocios() As DataTable
        Dim _Tabha As DataTable

        Dim _listPaham As New List(Of Datos.DParametro)

        _listPaham.Add(New Datos.DParametro("@tipo", 4))
        _listPaham.Add(New Datos.DParametro("@hauact", L_Usuario))
        _Tabha = D_ProcedimientoConParam("sp_Mam_TCH001", _listPaham)

        Return _Tabha
    End Function

    Public Shared Function L_prLibreriaClienteHGeneral(_cod1 As String, _cod2 As String) As DataTable
        Dim _Tabha As DataTable

        Dim _listPaham As New List(Of Datos.DParametro)

        _listPaham.Add(New Datos.DParametro("@tipo", 5))
        _listPaham.Add(New Datos.DParametro("@hacod1", _cod1))
        _listPaham.Add(New Datos.DParametro("@hacod2", _cod2))
        _listPaham.Add(New Datos.DParametro("@hauact", L_Usuario))

        _Tabha = D_ProcedimientoConParam("sp_Mam_TCH001", _listPaham)

        Return _Tabha
    End Function
    Public Shared Function L_prClienteHGrabar(ByRef _hanumi As String, _hatipo As Integer, _hansoc As String, _hafing As String, _hafnac As String, _hanom As String, _haapat As String, _haamat As String, _hadir As String, _haemail As String, _haci As String, _hafot As String, _haobs As String, _haest As Integer,
                                            _hatel1 As String, _hatel2 As String) As Boolean
        Dim _resultado As Boolean
        Dim _Tabha As DataTable
        Dim _listPaham As New List(Of Datos.DParametro)
        _listPaham.Add(New Datos.DParametro("@tipo", 1))
        _listPaham.Add(New Datos.DParametro("@hanumi", _hanumi))
        _listPaham.Add(New Datos.DParametro("@hatipo", _hatipo))
        _listPaham.Add(New Datos.DParametro("@hansoc", _hansoc))
        _listPaham.Add(New Datos.DParametro("@hafing", _hafing))
        _listPaham.Add(New Datos.DParametro("@hafnac", _hafnac))
        _listPaham.Add(New Datos.DParametro("@hanom", _hanom))
        _listPaham.Add(New Datos.DParametro("@haapat", _haapat))
        _listPaham.Add(New Datos.DParametro("@haamat", _haamat))
        _listPaham.Add(New Datos.DParametro("@hadir", _hadir))
        _listPaham.Add(New Datos.DParametro("@haemail", _haemail))
        _listPaham.Add(New Datos.DParametro("@haci", _haci))
        _listPaham.Add(New Datos.DParametro("@hafot", _hafot))
        _listPaham.Add(New Datos.DParametro("@haobs", _haobs))
        _listPaham.Add(New Datos.DParametro("@haest", _haest))
        _listPaham.Add(New Datos.DParametro("@hatelf1", _hatel1))
        _listPaham.Add(New Datos.DParametro("@hatelf2", _hatel2))
        _listPaham.Add(New Datos.DParametro("@hauact", L_Usuario))
        _Tabha = D_ProcedimientoConParam("sp_Mam_TCH001", _listPaham)

        If _Tabha.Rows.Count > 0 Then
            _hanumi = _Tabha.Rows(0).Item(0)
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function
    Public Shared Function L_prClienteHModificar(ByRef _hanumi As String, _hatipo As Integer, _hansoc As String, _hafing As String, _hafnac As String, _hanom As String, _haapat As String, _haamat As String, _hadir As String, _haemail As String, _haci As String, _hafot As String, _haobs As String, _haest As Integer,
                                            _hatel1 As String, _hatel2 As String) As Boolean
        Dim _resultado As Boolean
        Dim _Tabha As DataTable
        Dim _listPaham As New List(Of Datos.DParametro)
        _listPaham.Add(New Datos.DParametro("@tipo", 2))
        _listPaham.Add(New Datos.DParametro("@hanumi", _hanumi))
        _listPaham.Add(New Datos.DParametro("@hatipo", _hatipo))
        _listPaham.Add(New Datos.DParametro("@hansoc", _hansoc))
        _listPaham.Add(New Datos.DParametro("@hafing", _hafing))
        _listPaham.Add(New Datos.DParametro("@hafnac", _hafnac))
        _listPaham.Add(New Datos.DParametro("@hanom", _hanom))
        _listPaham.Add(New Datos.DParametro("@haapat", _haapat))
        _listPaham.Add(New Datos.DParametro("@haamat", _haamat))
        _listPaham.Add(New Datos.DParametro("@hadir", _hadir))
        _listPaham.Add(New Datos.DParametro("@haemail", _haemail))
        _listPaham.Add(New Datos.DParametro("@haci", _haci))
        _listPaham.Add(New Datos.DParametro("@hafot", _hafot))
        _listPaham.Add(New Datos.DParametro("@haobs", _haobs))
        _listPaham.Add(New Datos.DParametro("@haest", _haest))
        _listPaham.Add(New Datos.DParametro("@hatelf1", _hatel1))
        _listPaham.Add(New Datos.DParametro("@hatelf2", _hatel2))
        _listPaham.Add(New Datos.DParametro("@hauact", L_Usuario))
        _Tabha = D_ProcedimientoConParam("sp_Mam_TCH001", _listPaham)


        If _Tabha.Rows.Count > 0 Then
            _hanumi = _Tabha.Rows(0).Item(0)
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function
    Public Shared Function L_prClienteHBorrar(_numi As String, ByRef _mensaje As String) As Boolean

        Dim _resultado As Boolean

        If L_fnbValidarEliminacion(_numi, "TCL001", "hanumi", _mensaje) = True Then
            Dim _Tabha As DataTable

            Dim _listPaham As New List(Of Datos.DParametro)

            _listPaham.Add(New Datos.DParametro("@tipo", -1))
            _listPaham.Add(New Datos.DParametro("@hanumi", _numi))
            _listPaham.Add(New Datos.DParametro("@hauact", L_Usuario))
            _Tabha = D_ProcedimientoConParam("sp_Mam_TCH001", _listPaham)

            If _Tabha.Rows.Count > 0 Then
                _numi = _Tabha.Rows(0).Item(0)
                _resultado = True
            Else
                _resultado = False
            End If
        Else
            _resultado = False
        End If

        Return _resultado
    End Function
#End Region
#Region "PREGUNTAS"
    Public Shared Function L_prCategoriaCombo(Optional _Cadena As String = "", Optional _order As String = "") As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 5))
        _listParam.Add(New Datos.DParametro("@enuact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_Mam_TCE011", _listParam)

        Return _Tabla
    End Function
    Public Shared Function L_prPreguntasGeneral() As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 3))
        _listParam.Add(New Datos.DParametro("@enuact", L_Usuario))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TCE011", _listParam)

        Return _Tabla
    End Function
    Public Shared Function L_prPreguntasGrabar(ByRef _numi As String, _desc As String, _tipo As Integer, _lic As Integer, _val As String) As Boolean
        Dim _resultado As Boolean
        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 1))
        _listParam.Add(New Datos.DParametro("@ennumi", _numi))
        _listParam.Add(New Datos.DParametro("@endesc", _desc))
        _listParam.Add(New Datos.DParametro("@entipo", _tipo))
        _listParam.Add(New Datos.DParametro("@enlic", _lic))
        _listParam.Add(New Datos.DParametro("@enval", _val))

        _listParam.Add(New Datos.DParametro("@enuact", L_Usuario))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TCE011", _listParam)

        If _Tabla.Rows.Count > 0 Then
            _numi = _Tabla.Rows(0).Item(0)
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function
    Public Shared Function L_prPreguntasModificar(ByRef _numi As String, _desc As String, _tipo As Integer, _lic As Integer, _val As String) As Boolean
        Dim _resultado As Boolean
        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 2))
        _listParam.Add(New Datos.DParametro("@ennumi", _numi))
        _listParam.Add(New Datos.DParametro("@endesc", _desc))
        _listParam.Add(New Datos.DParametro("@entipo", _tipo))
        _listParam.Add(New Datos.DParametro("@enlic", _lic))
        _listParam.Add(New Datos.DParametro("@enval", _val))

        _listParam.Add(New Datos.DParametro("@enuact", L_Usuario))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TCE011", _listParam)

        If _Tabla.Rows.Count > 0 Then
            _numi = _Tabla.Rows(0).Item(0)
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function
    Public Shared Function L_prPreguntasBorrar(_numi As String, ByRef _mensaje As String) As Boolean

        Dim _resultado As Boolean

        If L_fnbValidarEliminacion(_numi, "TCE011", "ennumi", _mensaje) = True Then
            Dim _Tabla As DataTable

            Dim _listParam As New List(Of Datos.DParametro)

            _listParam.Add(New Datos.DParametro("@tipo", -1))
            _listParam.Add(New Datos.DParametro("@ennumi", _numi))
            _listParam.Add(New Datos.DParametro("@enuact", L_Usuario))

            _Tabla = D_ProcedimientoConParam("sp_Mam_TCE011", _listParam)

            If _Tabla.Rows.Count > 0 Then
                _numi = _Tabla.Rows(0).Item(0)
                _resultado = True
            Else
                _resultado = False
            End If
        Else
            _resultado = False
        End If

        Return _resultado
    End Function
#End Region
#Region "Reloj"

    Public Shared Function L_prObtenerIpReloj(_idSucursal As Integer) As DataTable
        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)
        _listParam.Add(New Datos.DParametro("@tipo", 7))
        _listParam.Add(New Datos.DParametro("@sucursal", _idSucursal))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TZ001", _listParam)
        Return _Tabla

    End Function
    Public Shared Function L_prObtenerNombreEmpleado(_panumi As Integer) As DataTable
        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)
        _listParam.Add(New Datos.DParametro("@tipo", 6))
        _listParam.Add(New Datos.DParametro("@panumi", _panumi))
        _listParam.Add(New Datos.DParametro("@zauact", L_Usuario))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TZ001", _listParam)
        Return _Tabla
    End Function

    Public Shared Function L_prAsistenciaGeneral() As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 3))
        _listParam.Add(New Datos.DParametro("@zauact", L_Usuario))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TZ001", _listParam)

        Return _Tabla
    End Function
    Public Shared Function L_prEmpleadoNoRegistradoGeneral() As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 4))
        _listParam.Add(New Datos.DParametro("@zauact", L_Usuario))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TZ001", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prMarcacionGrabarEstadoEmpleadosReloj(ByRef _ldnumi As String, _TP001 As DataTable) As Boolean
        Dim _resultado As Boolean
        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)
        _listParam.Add(New Datos.DParametro("@tipo", 5))
        _listParam.Add(New Datos.DParametro("@zanumi", _ldnumi))
        _listParam.Add(New Datos.DParametro("@zauact", L_Usuario))
        _listParam.Add(New Datos.DParametro("@TP001", "", _TP001))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TZ001", _listParam)

        If _Tabla.Rows.Count > 0 Then
            _ldnumi = _Tabla.Rows(0).Item(0)
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function
    Public Shared Function L_prMarcacionGrabar(ByRef _ldnumi As String, _TZ001 As DataTable) As Boolean
        Dim _resultado As Boolean
        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)
        _listParam.Add(New Datos.DParametro("@tipo", 1))
        _listParam.Add(New Datos.DParametro("@zanumi", _ldnumi))
        _listParam.Add(New Datos.DParametro("@zauact", L_Usuario))
        _listParam.Add(New Datos.DParametro("@TZ001", "", _TZ001))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TZ001", _listParam)

        If _Tabla.Rows.Count > 0 Then
            _ldnumi = _Tabla.Rows(0).Item(0)
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function
#End Region
#Region "Metodos"
    Public Shared Function L_prPreAlumnosResporteAprobados(_date As String, _estado As Integer, _escuela As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        If _estado = 2 Then
            _listParam.Add(New Datos.DParametro("@tipo", 51))
        Else
            _listParam.Add(New Datos.DParametro("@tipo", 52))
        End If
        _listParam.Add(New Datos.DParametro("@emfecha", _date))
        '_listParam.Add(New Datos.DParametro("@emestado", _estado))
        _listParam.Add(New Datos.DParametro("@elesc", _escuela))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))
        _Tabla = D_ProcedimientoConParam("sp_dg_TCE0911", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prPreAlumnosReporteAprobReprob(_date As String, _escuela As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 5))
        _listParam.Add(New Datos.DParametro("@emfecha", _date))
        _listParam.Add(New Datos.DParametro("@elesc", _escuela))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))
        _Tabla = D_ProcedimientoConParam("sp_dg_TCE0911", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prDatosPersonalesPost(_numi As String, _numFact As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 5))
        _listParam.Add(New Datos.DParametro("@elnumi", _numi))
        _listParam.Add(New Datos.DParametro("@numFact", _numFact))

        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCE092", _listParam)

        Return _Tabla
    End Function

#End Region

#Region "Recepcion de Vehiculos"

    Public Shared Function L_prRecepcionAyudaClientes() As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 7))
        _listParam.Add(New Datos.DParametro("@lfuact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_Mam_TCL006", _listParam)

        Return _Tabla
    End Function
    Public Shared Function L_prCargarImagenesRecepcion(_lfnumi As Integer) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 5))
        _listParam.Add(New Datos.DParametro("@lfnumi", _lfnumi))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TCL006", _listParam)
        Return _Tabla
    End Function
    Public Shared Function L_prCargarInventarioRecepcion(_lfnumi As Integer) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 4))
        _listParam.Add(New Datos.DParametro("@lfnumi", _lfnumi))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TCL006", _listParam)
        Return _Tabla
    End Function



    Public Shared Function L_prGeneralRecepcion() As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 3))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TCL006", _listParam)
        Return _Tabla
    End Function
    Public Shared Function L_prGeneralServicios(numi As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 11))
        _listParam.Add(New Datos.DParametro("@lfnumi", numi))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TCL006", _listParam)
        Return _Tabla
    End Function
    Public Shared Function L_prGeneralRecepcionNumi(numi As Integer) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 10))
        _listParam.Add(New Datos.DParametro("@lfnumi", numi))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TCL006", _listParam)
        Return _Tabla
    End Function


    Public Shared Function L_prRecepcionVehiculoGrabar(ByRef _lfnumi As String,
                                                       _lftc1soc As Integer,
                    _lffecha As String, _lftcl1veh As Integer, _lfobs As String,
                    _lftipo As Integer, _lftam As Integer,
                    _tablaInventario As DataTable, _tablaImagenes As DataTable, _tablaServicio As DataTable) As Boolean
        '      @lfnumi,@lftc1soc ,@lffecha ,@lftcl1veh ,
        '@lfcomb ,@lfobs ,@lftipo ,@lftam ,@newFecha ,@newHora ,@lfuact
        ''_tablaInventario,_tablaImagenes
        Dim _resultado As Boolean
        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)
        _listParam.Add(New Datos.DParametro("@tipo", 1))
        _listParam.Add(New Datos.DParametro("@lfnumi", _lfnumi))
        _listParam.Add(New Datos.DParametro("@lftc1soc", _lftc1soc))
        _listParam.Add(New Datos.DParametro("@lffecha", _lffecha))
        _listParam.Add(New Datos.DParametro("@lftcl1veh", _lftcl1veh))
        _listParam.Add(New Datos.DParametro("@lfcomb", 0))
        _listParam.Add(New Datos.DParametro("@lfobs", _lfobs))
        _listParam.Add(New Datos.DParametro("@lftipo", _lftipo))
        _listParam.Add(New Datos.DParametro("@lftam", _lftam))
        _listParam.Add(New Datos.DParametro("@lfuact", L_Usuario))
        _listParam.Add(New Datos.DParametro("@TCL0062", "", _tablaInventario))
        _listParam.Add(New Datos.DParametro("@TCL0063", "", _tablaImagenes))
        _listParam.Add(New Datos.DParametro("@TCL0064", "", _tablaServicio))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TCL006", _listParam)

        If _Tabla.Rows.Count > 0 Then
            _lfnumi = _Tabla.Rows(0).Item(0)
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function

    Public Shared Function L_prRecepcionVehiculoGrabar02(ByRef _lfnumi As String,
                                                       _lftc1soc As Integer,
                    _lffecha As String, _lftcl1veh As Integer, _lfobs As String,
                    _lftipo As Integer, _lftam As Integer,
                    _tablaInventario As DataTable, _tablaImagenes As DataTable, _tablaServicio As DataTable, _lfest As Integer) As Boolean
        '      @lfnumi,@lftc1soc ,@lffecha ,@lftcl1veh ,
        '@lfcomb ,@lfobs ,@lftipo ,@lftam ,@newFecha ,@newHora ,@lfuact
        ''_tablaInventario,_tablaImagenes
        Dim _resultado As Boolean
        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)
        _listParam.Add(New Datos.DParametro("@tipo", 1))
        _listParam.Add(New Datos.DParametro("@lfnumi", _lfnumi))
        _listParam.Add(New Datos.DParametro("@lftc1soc", _lftc1soc))
        _listParam.Add(New Datos.DParametro("@lffecha", _lffecha))
        _listParam.Add(New Datos.DParametro("@lftcl1veh", _lftcl1veh))
        _listParam.Add(New Datos.DParametro("@lfcomb", 0))
        _listParam.Add(New Datos.DParametro("@lfobs", _lfobs))
        _listParam.Add(New Datos.DParametro("@lftipo", _lftipo))
        _listParam.Add(New Datos.DParametro("@lftam", _lftam))
        _listParam.Add(New Datos.DParametro("@lfuact", L_Usuario))
        _listParam.Add(New Datos.DParametro("@lfest", _lfest))
        _listParam.Add(New Datos.DParametro("@TCL0062", "", _tablaInventario))
        _listParam.Add(New Datos.DParametro("@TCL0063", "", _tablaImagenes))
        _listParam.Add(New Datos.DParametro("@TCL0064", "", _tablaServicio))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TCL006", _listParam)

        If _Tabla.Rows.Count > 0 Then
            _lfnumi = _Tabla.Rows(0).Item(0)
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function

    Public Shared Function L_prRecepcionVehiculoBorrar(_numi As String, ByRef _mensaje As String) As Boolean

        Dim _resultado As Boolean

        If L_fnbValidarEliminacion(_numi, "TCL006", "lfnumi", _mensaje) = True Then
            Dim _Tabla As DataTable

            Dim _listPalam As New List(Of Datos.DParametro)

            _listPalam.Add(New Datos.DParametro("@tipo", -1))
            _listPalam.Add(New Datos.DParametro("@lfnumi", _numi))
            _listPalam.Add(New Datos.DParametro("@lfuact", L_Usuario))
            _Tabla = D_ProcedimientoConParam("sp_Mam_TCL006", _listPalam)

            If _Tabla.Rows.Count > 0 Then
                _numi = _Tabla.Rows(0).Item(0)
                _resultado = True
            Else
                _resultado = False
            End If
        Else
            _resultado = False
        End If

        Return _resultado
    End Function

    Public Shared Function L_prRecepcionVehiculoModificar(ByRef _lfnumi As String,
                                                     _lftc1soc As Integer,
                  _lffecha As String, _lftcl1veh As Integer, _lfobs As String,
                  _lftipo As Integer, _lftam As Integer,
                  _tablaInventario As DataTable, _tablaImagenes As DataTable, _tablaServicio As DataTable) As Boolean
        '      @lfnumi,@lftc1soc ,@lffecha ,@lftcl1veh ,
        '@lfcomb ,@lfobs ,@lftipo ,@lftam ,@newFecha ,@newHora ,@lfuact
        ''_tablaInventario,_tablaImagenes
        Dim _resultado As Boolean
        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)
        _listParam.Add(New Datos.DParametro("@tipo", 2))
        _listParam.Add(New Datos.DParametro("@lfnumi", _lfnumi))
        _listParam.Add(New Datos.DParametro("@lftc1soc", _lftc1soc))
        _listParam.Add(New Datos.DParametro("@lffecha", _lffecha))
        _listParam.Add(New Datos.DParametro("@lftcl1veh", _lftcl1veh))
        _listParam.Add(New Datos.DParametro("@lfcomb", 0))
        _listParam.Add(New Datos.DParametro("@lfobs", _lfobs))
        _listParam.Add(New Datos.DParametro("@lftipo", _lftipo))
        _listParam.Add(New Datos.DParametro("@lftam", _lftam))
        _listParam.Add(New Datos.DParametro("@lfuact", L_Usuario))
        _listParam.Add(New Datos.DParametro("@TCL0062", "", _tablaInventario))
        _listParam.Add(New Datos.DParametro("@TCL0063", "", _tablaImagenes))
        _listParam.Add(New Datos.DParametro("@TCL0064", "", _tablaServicio))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TCL006", _listParam)

        If _Tabla.Rows.Count > 0 Then
            _lfnumi = _Tabla.Rows(0).Item(0)
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function

    Public Shared Function L_prRecepcionVehiculoModificar02(ByRef _lfnumi As String,
                                                     _lftc1soc As Integer,
                  _lffecha As String, _lftcl1veh As Integer, _lfobs As String,
                  _lftipo As Integer, _lftam As Integer,
                  _tablaInventario As DataTable, _tablaImagenes As DataTable, _tablaServicio As DataTable, _lfest As Integer) As Boolean
        '      @lfnumi,@lftc1soc ,@lffecha ,@lftcl1veh ,
        '@lfcomb ,@lfobs ,@lftipo ,@lftam ,@newFecha ,@newHora ,@lfuact
        ''_tablaInventario,_tablaImagenes
        Dim _resultado As Boolean
        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)
        _listParam.Add(New Datos.DParametro("@tipo", 2))
        _listParam.Add(New Datos.DParametro("@lfnumi", _lfnumi))
        _listParam.Add(New Datos.DParametro("@lftc1soc", _lftc1soc))
        _listParam.Add(New Datos.DParametro("@lffecha", _lffecha))
        _listParam.Add(New Datos.DParametro("@lftcl1veh", _lftcl1veh))
        _listParam.Add(New Datos.DParametro("@lfcomb", 0))
        _listParam.Add(New Datos.DParametro("@lfobs", _lfobs))
        _listParam.Add(New Datos.DParametro("@lftipo", _lftipo))
        _listParam.Add(New Datos.DParametro("@lftam", _lftam))
        _listParam.Add(New Datos.DParametro("@lfuact", L_Usuario))
        _listParam.Add(New Datos.DParametro("@lfest", _lfest))
        _listParam.Add(New Datos.DParametro("@TCL0062", "", _tablaInventario))
        _listParam.Add(New Datos.DParametro("@TCL0063", "", _tablaImagenes))
        _listParam.Add(New Datos.DParametro("@TCL0064", "", _tablaServicio))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TCL006", _listParam)

        If _Tabla.Rows.Count > 0 Then
            _lfnumi = _Tabla.Rows(0).Item(0)
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function


    Public Shared Function L_prRecepcionVehiculoModificarEstado(ByRef _lfnumi As String, _lfest As Integer) As Boolean
        '      @lfnumi,@lftc1soc ,@lffecha ,@lftcl1veh ,
        '@lfcomb ,@lfobs ,@lftipo ,@lftam ,@newFecha ,@newHora ,@lfuact
        ''_tablaInventario,_tablaImagenes
        Dim _resultado As Boolean
        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)
        _listParam.Add(New Datos.DParametro("@tipo", 12))
        _listParam.Add(New Datos.DParametro("@lfnumi", _lfnumi))
        _listParam.Add(New Datos.DParametro("@lfuact", L_Usuario))
        _listParam.Add(New Datos.DParametro("@lfest", _lfest))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TCL006", _listParam)

        If _Tabla.Rows.Count > 0 Then
            _lfnumi = _Tabla.Rows(0).Item(0)
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function
    Public Shared Function L_prRecepcionVehiculoModificarEstadoAll(_dt As DataTable) As Boolean
        '      @lfnumi,@lftc1soc ,@lffecha ,@lftcl1veh ,
        '@lfcomb ,@lfobs ,@lftipo ,@lftam ,@newFecha ,@newHora ,@lfuact
        ''_tablaInventario,_tablaImagenes
        Dim _resultado As Boolean
        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)
        _listParam.Add(New Datos.DParametro("@tipo", 13))
        _listParam.Add(New Datos.DParametro("@TCL006", "", _dt))
        _listParam.Add(New Datos.DParametro("@lfuact", L_Usuario))
        _Tabla = D_ProcedimientoConParam("sp_Mam_TCL006", _listParam)

        If _Tabla.Rows.Count > 0 Then

            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function




#End Region
#End Region

    '#Region "Metodos"
    '    Public Shared Function L_prPreAlumnosResporteAprobados(_date As String, _estado As Integer) As DataTable
    '        Dim _Tabla As DataTable

    '        Dim _listParam As New List(Of Datos.DParametro)

    '        _listParam.Add(New Datos.DParametro("@tipo", 5))
    '        _listParam.Add(New Datos.DParametro("@emfecha", _date))
    '        _listParam.Add(New Datos.DParametro("@emestado", _estado))
    '        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))
    '        _Tabla = D_ProcedimientoConParam("sp_dg_TCE091", _listParam)

    '        Return _Tabla
    '    End Function

    '    Public Shared Function L_prPreAlumnosReporteAprobReprob(_date As String) As DataTable
    '        Dim _Tabla As DataTable

    '        Dim _listParam As New List(Of Datos.DParametro)

    '        _listParam.Add(New Datos.DParametro("@tipo", 5))
    '        _listParam.Add(New Datos.DParametro("@emfecha", _date))
    '        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))
    '        _Tabla = D_ProcedimientoConParam("sp_dg_TCE0911", _listParam)

    '        Return _Tabla
    '    End Function

    '    Public Shared Function L_prDatosPersonalesPost(_numi As String) As DataTable
    '        Dim _Tabla As DataTable

    '        Dim _listParam As New List(Of Datos.DParametro)

    '        _listParam.Add(New Datos.DParametro("@tipo", 5))
    '        _listParam.Add(New Datos.DParametro("@elnumi", _numi))
    '        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

    '        _Tabla = D_ProcedimientoConParam("sp_dg_TCE092", _listParam)

    '        Return _Tabla
    '    End Function

    '#End Region

    '#Region "DatosPesonalesReporte"
    '    Public Shared Function L_prDatosPersonales() As DataTable
    '        Dim _Tabla As DataTable

    '        Dim _listParam As New List(Of Datos.DParametro)

    '        _listParam.Add(New Datos.DParametro("@tipo", 6))
    '        _listParam.Add(New Datos.DParametro("@emfecha", ""))
    '        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

    '        _Tabla = D_ProcedimientoConParam("sp_dg_TCE0911", _listParam)

    '        Return _Tabla
    '    End Function
    '#End Region

    '#Region "PREGUNTAS"
    '    Public Shared Function L_prCategoriaCombo(Optional _Cadena As String = "", Optional _order As String = "") As DataTable
    '        Dim _Tabla As DataTable

    '        Dim _listParam As New List(Of Datos.DParametro)

    '        _listParam.Add(New Datos.DParametro("@tipo", 5))
    '        _listParam.Add(New Datos.DParametro("@enuact", L_Usuario))

    '        _Tabla = D_ProcedimientoConParam("sp_Mam_TCE011", _listParam)

    '        Return _Tabla
    '    End Function
    '    Public Shared Function L_prPreguntasGeneral() As DataTable
    '        Dim _Tabla As DataTable

    '        Dim _listParam As New List(Of Datos.DParametro)

    '        _listParam.Add(New Datos.DParametro("@tipo", 3))
    '        _listParam.Add(New Datos.DParametro("@enuact", L_Usuario))
    '        _Tabla = D_ProcedimientoConParam("sp_Mam_TCE011", _listParam)

    '        Return _Tabla
    '    End Function
    '    Public Shared Function L_prPreguntasGrabar(ByRef _numi As String, _desc As String, _tipo As Integer, _lic As Integer, _val As String) As Boolean
    '        Dim _resultado As Boolean
    '        Dim _Tabla As DataTable
    '        Dim _listParam As New List(Of Datos.DParametro)

    '        _listParam.Add(New Datos.DParametro("@tipo", 1))
    '        _listParam.Add(New Datos.DParametro("@ennumi", _numi))
    '        _listParam.Add(New Datos.DParametro("@endesc", _desc))
    '        _listParam.Add(New Datos.DParametro("@entipo", _tipo))
    '        _listParam.Add(New Datos.DParametro("@enlic", _lic))
    '        _listParam.Add(New Datos.DParametro("@enval", _val))

    '        _listParam.Add(New Datos.DParametro("@enuact", L_Usuario))
    '        _Tabla = D_ProcedimientoConParam("sp_Mam_TCE011", _listParam)

    '        If _Tabla.Rows.Count > 0 Then
    '            _numi = _Tabla.Rows(0).Item(0)
    '            _resultado = True
    '        Else
    '            _resultado = False
    '        End If

    '        Return _resultado
    '    End Function
    '    Public Shared Function L_prPreguntasModificar(ByRef _numi As String, _desc As String, _tipo As Integer, _lic As Integer, _val As String) As Boolean
    '        Dim _resultado As Boolean
    '        Dim _Tabla As DataTable
    '        Dim _listParam As New List(Of Datos.DParametro)

    '        _listParam.Add(New Datos.DParametro("@tipo", 2))
    '        _listParam.Add(New Datos.DParametro("@ennumi", _numi))
    '        _listParam.Add(New Datos.DParametro("@endesc", _desc))
    '        _listParam.Add(New Datos.DParametro("@entipo", _tipo))
    '        _listParam.Add(New Datos.DParametro("@enlic", _lic))
    '        _listParam.Add(New Datos.DParametro("@enval", _val))

    '        _listParam.Add(New Datos.DParametro("@enuact", L_Usuario))
    '        _Tabla = D_ProcedimientoConParam("sp_Mam_TCE011", _listParam)

    '        If _Tabla.Rows.Count > 0 Then
    '            _numi = _Tabla.Rows(0).Item(0)
    '            _resultado = True
    '        Else
    '            _resultado = False
    '        End If

    '        Return _resultado
    '    End Function
    '    Public Shared Function L_prPreguntasBorrar(_numi As String, ByRef _mensaje As String) As Boolean

    '        Dim _resultado As Boolean

    '        If L_fnbValidarEliminacion(_numi, "TCE011", "ennumi", _mensaje) = True Then
    '            Dim _Tabla As DataTable

    '            Dim _listParam As New List(Of Datos.DParametro)

    '            _listParam.Add(New Datos.DParametro("@tipo", -1))
    '            _listParam.Add(New Datos.DParametro("@ennumi", _numi))
    '            _listParam.Add(New Datos.DParametro("@enuact", L_Usuario))

    '            _Tabla = D_ProcedimientoConParam("sp_Mam_TCE011", _listParam)

    '            If _Tabla.Rows.Count > 0 Then
    '                _numi = _Tabla.Rows(0).Item(0)
    '                _resultado = True
    '            Else
    '                _resultado = False
    '            End If
    '        Else
    '            _resultado = False
    '        End If

    '        Return _resultado
    '    End Function
    '#End Region

    '#Region "DBDies CLIENTE REMOLQUE"

    '    Public Shared Function L_prClienteRGeneral(_racod1 As Integer, _racod2 As Integer) As DataTable
    '        Dim _Tabla As DataTable

    '        Dim _listParam As New List(Of Datos.DParametro)

    '        _listParam.Add(New Datos.DParametro("@tipo", 3))
    '        _listParam.Add(New Datos.DParametro("@rauact", L_Usuario))
    '        _listParam.Add(New Datos.DParametro("@racod1", _racod1))
    '        _listParam.Add(New Datos.DParametro("@racod2", _racod2))
    '        _Tabla = D_ProcedimientoConParam("sp_Mam_TCR001", _listParam)

    '        Return _Tabla
    '    End Function

    '    Public Shared Function L_prClienteRGeneralSocios() As DataTable
    '        Dim _Tabla As DataTable

    '        Dim _listParam As New List(Of Datos.DParametro)

    '        _listParam.Add(New Datos.DParametro("@tipo", 4))
    '        _listParam.Add(New Datos.DParametro("@rauact", L_Usuario))
    '        _Tabla = D_ProcedimientoConParam("sp_Mam_TCR001", _listParam)

    '        Return _Tabla
    '    End Function
    '    Public Shared Function L_prClienteRVehiculoSocios(_cfnumi As Integer) As DataTable
    '        Dim _Tabla As DataTable

    '        Dim _listPalam As New List(Of Datos.DParametro)

    '        _listPalam.Add(New Datos.DParametro("@tipo", 7))
    '        _listPalam.Add(New Datos.DParametro("@cfnumi", _cfnumi))
    '        _listPalam.Add(New Datos.DParametro("@rauact", L_Usuario))
    '        _Tabla = D_ProcedimientoConParam("sp_Mam_TCR001", _listPalam)

    '        Return _Tabla
    '    End Function

    '    Public Shared Function L_prLibreriaClienteRGeneral(_cod1 As String, _cod2 As String) As DataTable
    '        Dim _Tabla As DataTable

    '        Dim _listParam As New List(Of Datos.DParametro)

    '        _listParam.Add(New Datos.DParametro("@tipo", 5))
    '        _listParam.Add(New Datos.DParametro("@racod1", _cod1))
    '        _listParam.Add(New Datos.DParametro("@racod2", _cod2))
    '        _listParam.Add(New Datos.DParametro("@rauact", L_Usuario))

    '        _Tabla = D_ProcedimientoConParam("sp_Mam_TCR001", _listParam)

    '        Return _Tabla
    '    End Function
    '    Public Shared Function L_prClienteRGrabar(ByRef _ranumi As String, _ratipo As Integer, _ransoc As String, _rafing As String, _rafnac As String, _ranom As String, _raapat As String, _raamat As String, _radir As String, _raemail As String, _raci As String, _rafot As String, _raobs As String, _raest As Integer,
    '                                            _ratel1 As String, _ratel2 As String, _TCR0011 As DataTable) As Boolean
    '        Dim _resultado As Boolean
    '        Dim _Tabla As DataTable
    '        Dim _listParam As New List(Of Datos.DParametro)
    '        _listParam.Add(New Datos.DParametro("@tipo", 1))
    '        _listParam.Add(New Datos.DParametro("@ranumi", _ranumi))
    '        _listParam.Add(New Datos.DParametro("@ratipo", _ratipo))
    '        _listParam.Add(New Datos.DParametro("@ransoc", _ransoc))
    '        _listParam.Add(New Datos.DParametro("@rafing", _rafing))
    '        _listParam.Add(New Datos.DParametro("@rafnac", _rafnac))
    '        _listParam.Add(New Datos.DParametro("@ranom", _ranom))
    '        _listParam.Add(New Datos.DParametro("@raapat", _raapat))
    '        _listParam.Add(New Datos.DParametro("@raamat", _raamat))
    '        _listParam.Add(New Datos.DParametro("@radir", _radir))
    '        _listParam.Add(New Datos.DParametro("@raemail", _raemail))
    '        _listParam.Add(New Datos.DParametro("@raci", _raci))
    '        _listParam.Add(New Datos.DParametro("@rafot", _rafot))
    '        _listParam.Add(New Datos.DParametro("@raobs", _raobs))
    '        _listParam.Add(New Datos.DParametro("@raest", _raest))
    '        _listParam.Add(New Datos.DParametro("@ratelf1", _ratel1))
    '        _listParam.Add(New Datos.DParametro("@ratelf2", _ratel2))
    '        _listParam.Add(New Datos.DParametro("@rauact", L_Usuario))
    '        _listParam.Add(New Datos.DParametro("@TCR0011", "", _TCR0011))
    '        _Tabla = D_ProcedimientoConParam("sp_Mam_TCR001", _listParam)

    '        If _Tabla.Rows.Count > 0 Then
    '            _ranumi = _Tabla.Rows(0).Item(0)
    '            _resultado = True
    '        Else
    '            _resultado = False
    '        End If

    '        Return _resultado
    '    End Function
    '    Public Shared Function L_prClienteRModificar(ByRef _ranumi As String, _ratipo As Integer, _ransoc As String, _rafing As String, _rafnac As String, _ranom As String, _raapat As String, _raamat As String, _radir As String, _raemail As String, _raci As String, _rafot As String, _raobs As String, _raest As Integer,
    '                                            _ratel1 As String, _ratel2 As String, _TCR0011 As DataTable) As Boolean
    '        Dim _resultado As Boolean
    '        Dim _Tabla As DataTable
    '        Dim _listParam As New List(Of Datos.DParametro)
    '        _listParam.Add(New Datos.DParametro("@tipo", 2))
    '        _listParam.Add(New Datos.DParametro("@ranumi", _ranumi))
    '        _listParam.Add(New Datos.DParametro("@ratipo", _ratipo))
    '        _listParam.Add(New Datos.DParametro("@ransoc", _ransoc))
    '        _listParam.Add(New Datos.DParametro("@rafing", _rafing))
    '        _listParam.Add(New Datos.DParametro("@rafnac", _rafnac))
    '        _listParam.Add(New Datos.DParametro("@ranom", _ranom))
    '        _listParam.Add(New Datos.DParametro("@raapat", _raapat))
    '        _listParam.Add(New Datos.DParametro("@raamat", _raamat))
    '        _listParam.Add(New Datos.DParametro("@radir", _radir))
    '        _listParam.Add(New Datos.DParametro("@raemail", _raemail))
    '        _listParam.Add(New Datos.DParametro("@raci", _raci))
    '        _listParam.Add(New Datos.DParametro("@rafot", _rafot))
    '        _listParam.Add(New Datos.DParametro("@raobs", _raobs))
    '        _listParam.Add(New Datos.DParametro("@raest", _raest))
    '        _listParam.Add(New Datos.DParametro("@ratelf1", _ratel1))
    '        _listParam.Add(New Datos.DParametro("@ratelf2", _ratel2))
    '        _listParam.Add(New Datos.DParametro("@TCR0011", "", _TCR0011))
    '        _listParam.Add(New Datos.DParametro("@rauact", L_Usuario))
    '        _Tabla = D_ProcedimientoConParam("sp_Mam_TCR001", _listParam)


    '        If _Tabla.Rows.Count > 0 Then
    '            _ranumi = _Tabla.Rows(0).Item(0)
    '            _resultado = True
    '        Else
    '            _resultado = False
    '        End If

    '        Return _resultado
    '    End Function
    '    Public Shared Function L_prClienteRBorrar(_numi As String, ByRef _mensaje As String) As Boolean

    '        Dim _resultado As Boolean

    '        If L_fnbValidarEliminacion(_numi, "TCR001", "ranumi", _mensaje) = True Then
    '            Dim _Tabla As DataTable

    '            Dim _listParam As New List(Of Datos.DParametro)

    '            _listParam.Add(New Datos.DParametro("@tipo", -1))
    '            _listParam.Add(New Datos.DParametro("@ranumi", _numi))
    '            _listParam.Add(New Datos.DParametro("@rauact", L_Usuario))
    '            _Tabla = D_ProcedimientoConParam("sp_Mam_TCR001", _listParam)

    '            If _Tabla.Rows.Count > 0 Then
    '                _numi = _Tabla.Rows(0).Item(0)
    '                _resultado = True
    '            Else
    '                _resultado = False
    '            End If
    '        Else
    '            _resultado = False
    '        End If

    '        Return _resultado
    '    End Function

    '    Public Shared Function L_prClienteRVehiculo(_numi As Integer) As DataTable
    '        Dim _Tabla As DataTable

    '        Dim _listParam As New List(Of Datos.DParametro)

    '        _listParam.Add(New Datos.DParametro("@tipo", 6))
    '        _listParam.Add(New Datos.DParametro("@rauact", L_Usuario))
    '        _listParam.Add(New Datos.DParametro("@ranumi", _numi))
    '        _Tabla = D_ProcedimientoConParam("sp_Mam_TCR001", _listParam)

    '        Return _Tabla
    '    End Function
    '#End Region

    '#Region "DBDies CLIENTE TCL001"

    '    Public Shared Function L_prClienteLGeneral(_cd1 As Integer, _cd2 As Integer) As DataTable
    '        Dim _Tabla As DataTable

    '        Dim _listPalam As New List(Of Datos.DParametro)

    '        _listPalam.Add(New Datos.DParametro("@tipo", 3))
    '        _listPalam.Add(New Datos.DParametro("@lauact", L_Usuario))
    '        _listPalam.Add(New Datos.DParametro("@lacod1", _cd1))
    '        _listPalam.Add(New Datos.DParametro("@lacod2", _cd2))
    '        _Tabla = D_ProcedimientoConParam("sp_Mam_TCL001", _listPalam)

    '        Return _Tabla
    '    End Function

    '    Public Shared Function L_prClienteLGeneralSocios() As DataTable
    '        Dim _Tabla As DataTable

    '        Dim _listPalam As New List(Of Datos.DParametro)

    '        _listPalam.Add(New Datos.DParametro("@tipo", 4))
    '        _listPalam.Add(New Datos.DParametro("@lauact", L_Usuario))
    '        _Tabla = D_ProcedimientoConParam("sp_Mam_TCL001", _listPalam)

    '        Return _Tabla
    '    End Function

    '    Public Shared Function L_prClienteLVehiculoSocios(_cfnumi As Integer) As DataTable
    '        Dim _Tabla As DataTable

    '        Dim _listPalam As New List(Of Datos.DParametro)

    '        _listPalam.Add(New Datos.DParametro("@tipo", 7))
    '        _listPalam.Add(New Datos.DParametro("@cfnumi", _cfnumi))
    '        _listPalam.Add(New Datos.DParametro("@lauact", L_Usuario))
    '        _Tabla = D_ProcedimientoConParam("sp_Mam_TCL001", _listPalam)

    '        Return _Tabla
    '    End Function

    '    Public Shared Function L_prLibreriaClienteLGeneral(_cod1 As String, _cod2 As String) As DataTable
    '        Dim _Tabla As DataTable

    '        Dim _listPalam As New List(Of Datos.DParametro)

    '        _listPalam.Add(New Datos.DParametro("@tipo", 5))
    '        _listPalam.Add(New Datos.DParametro("@lacod1", _cod1))
    '        _listPalam.Add(New Datos.DParametro("@lacod2", _cod2))
    '        _listPalam.Add(New Datos.DParametro("@lauact", L_Usuario))

    '        _Tabla = D_ProcedimientoConParam("sp_Mam_TCL001", _listPalam)

    '        Return _Tabla
    '    End Function
    '    Public Shared Function L_prClienteLGrabar(ByRef _lanumi As String, _latipo As Integer, _lansoc As String, _lafing As String, _lafnac As String, _lanom As String, _laapat As String, _laamat As String, _ladir As String, _laemail As String, _laci As String, _lafot As String, _laobs As String, _laest As Integer, _latel1 As String, _latel2 As String, _TCL0011 As DataTable) As Boolean
    '        Dim _resultado As Boolean
    '        Dim _Tabla As DataTable
    '        Dim _listPalam As New List(Of Datos.DParametro)
    '        _listPalam.Add(New Datos.DParametro("@tipo", 1))
    '        _listPalam.Add(New Datos.DParametro("@lanumi", _lanumi))
    '        _listPalam.Add(New Datos.DParametro("@latipo", _latipo))
    '        _listPalam.Add(New Datos.DParametro("@lansoc", _lansoc))
    '        _listPalam.Add(New Datos.DParametro("@lafing", _lafing))
    '        _listPalam.Add(New Datos.DParametro("@lafnac", _lafnac))
    '        _listPalam.Add(New Datos.DParametro("@lanom", _lanom))
    '        _listPalam.Add(New Datos.DParametro("@laapat", _laapat))
    '        _listPalam.Add(New Datos.DParametro("@laamat", _laamat))
    '        _listPalam.Add(New Datos.DParametro("@ladir", _ladir))
    '        _listPalam.Add(New Datos.DParametro("@laemail", _laemail))
    '        _listPalam.Add(New Datos.DParametro("@laci", _laci))
    '        _listPalam.Add(New Datos.DParametro("@lafot", _lafot))
    '        _listPalam.Add(New Datos.DParametro("@laobs", _laobs))
    '        _listPalam.Add(New Datos.DParametro("@laest", _laest))
    '        _listPalam.Add(New Datos.DParametro("@latelf1", _latel1))
    '        _listPalam.Add(New Datos.DParametro("@latelf2", _latel2))
    '        _listPalam.Add(New Datos.DParametro("@lauact", L_Usuario))
    '        _listPalam.Add(New Datos.DParametro("@lacod1", "1"))
    '        _listPalam.Add(New Datos.DParametro("@lacod2", "2"))
    '        _listPalam.Add(New Datos.DParametro("@TCL0011", "", _TCL0011))
    '        _Tabla = D_ProcedimientoConParam("sp_Mam_TCL001", _listPalam)

    '        If _Tabla.Rows.Count > 0 Then
    '            _lanumi = _Tabla.Rows(0).Item(0)
    '            _resultado = True
    '        Else
    '            _resultado = False
    '        End If

    '        Return _resultado
    '    End Function
    '    Public Shared Function L_prClienteLModificar(ByRef _lanumi As String, _latipo As Integer, _lansoc As String, _lafing As String, _lafnac As String, _lanom As String, _laapat As String, _laamat As String, _ladir As String, _laemail As String, _laci As String, _lafot As String, _laobs As String, _laest As Integer, _latel1 As String, _latel2 As String, _TCL0011 As DataTable) As Boolean
    '        Dim _resultado As Boolean
    '        Dim _Tabla As DataTable
    '        Dim _listPalam As New List(Of Datos.DParametro)
    '        _listPalam.Add(New Datos.DParametro("@tipo", 2))
    '        _listPalam.Add(New Datos.DParametro("@lanumi", _lanumi))
    '        _listPalam.Add(New Datos.DParametro("@latipo", _latipo))
    '        _listPalam.Add(New Datos.DParametro("@lansoc", _lansoc))
    '        _listPalam.Add(New Datos.DParametro("@lafing", _lafing))
    '        _listPalam.Add(New Datos.DParametro("@lafnac", _lafnac))
    '        _listPalam.Add(New Datos.DParametro("@lanom", _lanom))
    '        _listPalam.Add(New Datos.DParametro("@laapat", _laapat))
    '        _listPalam.Add(New Datos.DParametro("@laamat", _laamat))
    '        _listPalam.Add(New Datos.DParametro("@ladir", _ladir))
    '        _listPalam.Add(New Datos.DParametro("@laemail", _laemail))
    '        _listPalam.Add(New Datos.DParametro("@laci", _laci))
    '        _listPalam.Add(New Datos.DParametro("@lafot", _lafot))
    '        _listPalam.Add(New Datos.DParametro("@laobs", _laobs))
    '        _listPalam.Add(New Datos.DParametro("@laest", _laest))
    '        _listPalam.Add(New Datos.DParametro("@latelf1", _latel1))
    '        _listPalam.Add(New Datos.DParametro("@latelf2", _latel2))
    '        _listPalam.Add(New Datos.DParametro("@lauact", L_Usuario))
    '        _listPalam.Add(New Datos.DParametro("@lacod1", "1"))
    '        _listPalam.Add(New Datos.DParametro("@lacod2", "2"))
    '        _listPalam.Add(New Datos.DParametro("@TCL0011", "", _TCL0011))
    '        _Tabla = D_ProcedimientoConParam("sp_Mam_TCL001", _listPalam)


    '        If _Tabla.Rows.Count > 0 Then
    '            _lanumi = _Tabla.Rows(0).Item(0)
    '            _resultado = True
    '        Else
    '            _resultado = False
    '        End If

    '        Return _resultado
    '    End Function
    '    Public Shared Function L_prClienteLBorrar(_numi As String, ByRef _mensaje As String) As Boolean

    '        Dim _resultado As Boolean

    '        If L_fnbValidarEliminacion(_numi, "TCL001", "lanumi", _mensaje) = True Then
    '            Dim _Tabla As DataTable

    '            Dim _listPalam As New List(Of Datos.DParametro)

    '            _listPalam.Add(New Datos.DParametro("@tipo", -1))
    '            _listPalam.Add(New Datos.DParametro("@lanumi", _numi))
    '            _listPalam.Add(New Datos.DParametro("@lauact", L_Usuario))
    '            _Tabla = D_ProcedimientoConParam("sp_Mam_TCL001", _listPalam)

    '            If _Tabla.Rows.Count > 0 Then
    '                _numi = _Tabla.Rows(0).Item(0)
    '                _resultado = True
    '            Else
    '                _resultado = False
    '            End If
    '        Else
    '            _resultado = False
    '        End If

    '        Return _resultado
    '    End Function
    '    Public Shared Function L_prClienteLVehiculo(_numi As Integer) As DataTable
    '        Dim _Tabla As DataTable

    '        Dim _listParam As New List(Of Datos.DParametro)

    '        _listParam.Add(New Datos.DParametro("@tipo", 6))
    '        _listParam.Add(New Datos.DParametro("@lauact", L_Usuario))
    '        _listParam.Add(New Datos.DParametro("@lanumi", _numi))
    '        _Tabla = D_ProcedimientoConParam("sp_Mam_TCL001", _listParam)

    '        Return _Tabla
    '    End Function

    '#End Region

    '#Region "DBDies CLIENTE TCH001"

    '    Public Shared Function L_prClienteHGeneral(_cod1 As String, _cod2 As String) As DataTable
    '        Dim _Tabha As DataTable

    '        Dim _listPaham As New List(Of Datos.DParametro)

    '        _listPaham.Add(New Datos.DParametro("@tipo", 3))
    '        _listPaham.Add(New Datos.DParametro("@hauact", L_Usuario))
    '        _listPaham.Add(New Datos.DParametro("@hacod1", _cod1))
    '        _listPaham.Add(New Datos.DParametro("@hacod2", _cod2))
    '        _Tabha = D_ProcedimientoConParam("sp_Mam_TCH001", _listPaham)

    '        Return _Tabha
    '    End Function

    '    Public Shared Function L_prClienteHGeneralSocios() As DataTable
    '        Dim _Tabha As DataTable

    '        Dim _listPaham As New List(Of Datos.DParametro)

    '        _listPaham.Add(New Datos.DParametro("@tipo", 4))
    '        _listPaham.Add(New Datos.DParametro("@hauact", L_Usuario))
    '        _Tabha = D_ProcedimientoConParam("sp_Mam_TCH001", _listPaham)

    '        Return _Tabha
    '    End Function

    '    Public Shared Function L_prLibreriaClienteHGeneral(_cod1 As String, _cod2 As String) As DataTable
    '        Dim _Tabha As DataTable

    '        Dim _listPaham As New List(Of Datos.DParametro)

    '        _listPaham.Add(New Datos.DParametro("@tipo", 5))
    '        _listPaham.Add(New Datos.DParametro("@hacod1", _cod1))
    '        _listPaham.Add(New Datos.DParametro("@hacod2", _cod2))
    '        _listPaham.Add(New Datos.DParametro("@hauact", L_Usuario))

    '        _Tabha = D_ProcedimientoConParam("sp_Mam_TCH001", _listPaham)

    '        Return _Tabha
    '    End Function
    '    Public Shared Function L_prClienteHGrabar(ByRef _hanumi As String, _hatipo As Integer, _hansoc As String, _hafing As String, _hafnac As String, _hanom As String, _haapat As String, _haamat As String, _hadir As String, _haemail As String, _haci As String, _hafot As String, _haobs As String, _haest As Integer,
    '                                            _hatel1 As String, _hatel2 As String) As Boolean
    '        Dim _resultado As Boolean
    '        Dim _Tabha As DataTable
    '        Dim _listPaham As New List(Of Datos.DParametro)
    '        _listPaham.Add(New Datos.DParametro("@tipo", 1))
    '        _listPaham.Add(New Datos.DParametro("@hanumi", _hanumi))
    '        _listPaham.Add(New Datos.DParametro("@hatipo", _hatipo))
    '        _listPaham.Add(New Datos.DParametro("@hansoc", _hansoc))
    '        _listPaham.Add(New Datos.DParametro("@hafing", _hafing))
    '        _listPaham.Add(New Datos.DParametro("@hafnac", _hafnac))
    '        _listPaham.Add(New Datos.DParametro("@hanom", _hanom))
    '        _listPaham.Add(New Datos.DParametro("@haapat", _haapat))
    '        _listPaham.Add(New Datos.DParametro("@haamat", _haamat))
    '        _listPaham.Add(New Datos.DParametro("@hadir", _hadir))
    '        _listPaham.Add(New Datos.DParametro("@haemail", _haemail))
    '        _listPaham.Add(New Datos.DParametro("@haci", _haci))
    '        _listPaham.Add(New Datos.DParametro("@hafot", _hafot))
    '        _listPaham.Add(New Datos.DParametro("@haobs", _haobs))
    '        _listPaham.Add(New Datos.DParametro("@haest", _haest))
    '        _listPaham.Add(New Datos.DParametro("@hatelf1", _hatel1))
    '        _listPaham.Add(New Datos.DParametro("@hatelf2", _hatel2))
    '        _listPaham.Add(New Datos.DParametro("@hauact", L_Usuario))
    '        _Tabha = D_ProcedimientoConParam("sp_Mam_TCH001", _listPaham)

    '        If _Tabha.Rows.Count > 0 Then
    '            _hanumi = _Tabha.Rows(0).Item(0)
    '            _resultado = True
    '        Else
    '            _resultado = False
    '        End If

    '        Return _resultado
    '    End Function
    '    Public Shared Function L_prClienteHModificar(ByRef _hanumi As String, _hatipo As Integer, _hansoc As String, _hafing As String, _hafnac As String, _hanom As String, _haapat As String, _haamat As String, _hadir As String, _haemail As String, _haci As String, _hafot As String, _haobs As String, _haest As Integer,
    '                                            _hatel1 As String, _hatel2 As String) As Boolean
    '        Dim _resultado As Boolean
    '        Dim _Tabha As DataTable
    '        Dim _listPaham As New List(Of Datos.DParametro)
    '        _listPaham.Add(New Datos.DParametro("@tipo", 2))
    '        _listPaham.Add(New Datos.DParametro("@hanumi", _hanumi))
    '        _listPaham.Add(New Datos.DParametro("@hatipo", _hatipo))
    '        _listPaham.Add(New Datos.DParametro("@hansoc", _hansoc))
    '        _listPaham.Add(New Datos.DParametro("@hafing", _hafing))
    '        _listPaham.Add(New Datos.DParametro("@hafnac", _hafnac))
    '        _listPaham.Add(New Datos.DParametro("@hanom", _hanom))
    '        _listPaham.Add(New Datos.DParametro("@haapat", _haapat))
    '        _listPaham.Add(New Datos.DParametro("@haamat", _haamat))
    '        _listPaham.Add(New Datos.DParametro("@hadir", _hadir))
    '        _listPaham.Add(New Datos.DParametro("@haemail", _haemail))
    '        _listPaham.Add(New Datos.DParametro("@haci", _haci))
    '        _listPaham.Add(New Datos.DParametro("@hafot", _hafot))
    '        _listPaham.Add(New Datos.DParametro("@haobs", _haobs))
    '        _listPaham.Add(New Datos.DParametro("@haest", _haest))
    '        _listPaham.Add(New Datos.DParametro("@hatelf1", _hatel1))
    '        _listPaham.Add(New Datos.DParametro("@hatelf2", _hatel2))
    '        _listPaham.Add(New Datos.DParametro("@hauact", L_Usuario))
    '        _Tabha = D_ProcedimientoConParam("sp_Mam_TCH001", _listPaham)


    '        If _Tabha.Rows.Count > 0 Then
    '            _hanumi = _Tabha.Rows(0).Item(0)
    '            _resultado = True
    '        Else
    '            _resultado = False
    '        End If

    '        Return _resultado
    '    End Function
    '    Public Shared Function L_prClienteHBorrar(_numi As String, ByRef _mensaje As String) As Boolean

    '        Dim _resultado As Boolean

    '        If L_fnbValidarEliminacion(_numi, "TCL001", "hanumi", _mensaje) = True Then
    '            Dim _Tabha As DataTable

    '            Dim _listPaham As New List(Of Datos.DParametro)

    '            _listPaham.Add(New Datos.DParametro("@tipo", -1))
    '            _listPaham.Add(New Datos.DParametro("@hanumi", _numi))
    '            _listPaham.Add(New Datos.DParametro("@hauact", L_Usuario))
    '            _Tabha = D_ProcedimientoConParam("sp_Mam_TCH001", _listPaham)

    '            If _Tabha.Rows.Count > 0 Then
    '                _numi = _Tabha.Rows(0).Item(0)
    '                _resultado = True
    '            Else
    '                _resultado = False
    '            End If
    '        Else
    '            _resultado = False
    '        End If

    '        Return _resultado
    '    End Function
    '#End Region

    '#Region "CABAñA"
    '    Public Shared Function L_prCabañaTipoCombo(Optional _Cadena As String = "", Optional _order As String = "") As DataTable
    '        Dim _Tabla As DataTable

    '        Dim _listParam As New List(Of Datos.DParametro)

    '        _listParam.Add(New Datos.DParametro("@tipo", 5))
    '        _listParam.Add(New Datos.DParametro("@cdcod1", 12))
    '        _listParam.Add(New Datos.DParametro("@cdcod2", 1))
    '        _listParam.Add(New Datos.DParametro("@hbuact", L_Usuario))

    '        _Tabla = D_ProcedimientoConParam("sp_Mam_TCH002", _listParam)

    '        Return _Tabla
    '    End Function
    '    Public Shared Function L_prCabañaGeneral(libCod1 As String, libCod2 As String) As DataTable
    '        Dim _Tabla As DataTable

    '        Dim _listParam As New List(Of Datos.DParametro)

    '        _listParam.Add(New Datos.DParametro("@tipo", 3))
    '        _listParam.Add(New Datos.DParametro("@cdcod1", libCod1))
    '        _listParam.Add(New Datos.DParametro("@cdcod2", libCod2))
    '        _listParam.Add(New Datos.DParametro("@hbuact", L_Usuario))
    '        _Tabla = D_ProcedimientoConParam("sp_Mam_TCH002", _listParam)

    '        Return _Tabla
    '    End Function

    '    Public Shared Function L_prCabañaImagenes(_hbnumi As Integer) As DataTable
    '        Dim _Tabla As DataTable

    '        Dim _listParam As New List(Of Datos.DParametro)

    '        _listParam.Add(New Datos.DParametro("@tipo", 6))
    '        _listParam.Add(New Datos.DParametro("@hbnumi", _hbnumi))
    '        _listParam.Add(New Datos.DParametro("@hbuact", L_Usuario))
    '        _Tabla = D_ProcedimientoConParam("sp_Mam_TCH002", _listParam)

    '        Return _Tabla
    '    End Function
    '    Public Shared Function L_prCabañaGrabar(ByRef _numi As String, _nom As String, _dor As Integer, _per As Integer, _tipo As Integer,
    '                                               _obs As String, _TCH0021 As DataTable) As Boolean

    '        '@hbnumi ,@hbnom  ,@hbdor ,@hbper   
    '        '	,@hbtipo   ,@hbsuc ,@hbobs,@newFecha,@newHora,@hbuact
    '        Dim _resultado As Boolean
    '        Dim _Tabla As DataTable
    '        Dim _listParam As New List(Of Datos.DParametro)

    '        _listParam.Add(New Datos.DParametro("@tipo", 1))
    '        _listParam.Add(New Datos.DParametro("@hbnumi", _numi))
    '        _listParam.Add(New Datos.DParametro("@hbnom", _nom))
    '        _listParam.Add(New Datos.DParametro("@hbdor", _dor))
    '        _listParam.Add(New Datos.DParametro("@hbper", _per))
    '        _listParam.Add(New Datos.DParametro("@hbtipo", _tipo))
    '        _listParam.Add(New Datos.DParametro("@hbsuc", 1))
    '        _listParam.Add(New Datos.DParametro("@hbobs", _obs))
    '        _listParam.Add(New Datos.DParametro("@hbuact", L_Usuario))
    '        _listParam.Add(New Datos.DParametro("@TCH0021", "", _TCH0021))
    '        _Tabla = D_ProcedimientoConParam("sp_Mam_TCH002", _listParam)

    '        If _Tabla.Rows.Count > 0 Then
    '            _numi = _Tabla.Rows(0).Item(0)
    '            _resultado = True
    '        Else
    '            _resultado = False
    '        End If

    '        Return _resultado
    '    End Function
    '    Public Shared Function L_prCabañaModificar(ByRef _numi As String, _nom As String, _dor As Integer, _per As Integer, _tipo As Integer,
    '                                               _obs As String, _TCH0021 As DataTable) As Boolean

    '        '@hbnumi ,@hbnom  ,@hbdor ,@hbper   
    '        '	,@hbtipo   ,@hbsuc ,@hbobs,@newFecha,@newHora,@hbuact
    '        Dim _resultado As Boolean
    '        Dim _Tabla As DataTable
    '        Dim _listParam As New List(Of Datos.DParametro)

    '        _listParam.Add(New Datos.DParametro("@tipo", 2))
    '        _listParam.Add(New Datos.DParametro("@hbnumi", _numi))
    '        _listParam.Add(New Datos.DParametro("@hbnom", _nom))
    '        _listParam.Add(New Datos.DParametro("@hbdor", _dor))
    '        _listParam.Add(New Datos.DParametro("@hbper", _per))
    '        _listParam.Add(New Datos.DParametro("@hbtipo", _tipo))
    '        _listParam.Add(New Datos.DParametro("@hbsuc", 1))
    '        _listParam.Add(New Datos.DParametro("@hbobs", _obs))
    '        _listParam.Add(New Datos.DParametro("@hbuact", L_Usuario))
    '        _listParam.Add(New Datos.DParametro("@TCH0021", "", _TCH0021))
    '        _Tabla = D_ProcedimientoConParam("sp_Mam_TCH002", _listParam)

    '        If _Tabla.Rows.Count > 0 Then
    '            _numi = _Tabla.Rows(0).Item(0)
    '            _resultado = True
    '        Else
    '            _resultado = False
    '        End If

    '        Return _resultado
    '    End Function
    '    Public Shared Function L_prCabañaBorrar(_numi As String, ByRef _mensaje As String) As Boolean

    '        Dim _resultado As Boolean

    '        If L_fnbValidarEliminacion(_numi, "TCH002", "hbnumi", _mensaje) = True Then
    '            Dim _Tabla As DataTable

    '            Dim _listParam As New List(Of Datos.DParametro)

    '            _listParam.Add(New Datos.DParametro("@tipo", -1))
    '            _listParam.Add(New Datos.DParametro("@hbnumi", _numi))
    '            _listParam.Add(New Datos.DParametro("@hbuact", L_Usuario))

    '            _Tabla = D_ProcedimientoConParam("sp_Mam_TCH002", _listParam)

    '            If _Tabla.Rows.Count > 0 Then
    '                _numi = _Tabla.Rows(0).Item(0)
    '                _resultado = True
    '            Else
    '                _resultado = False
    '            End If
    '        Else
    '            _resultado = False
    '        End If

    '        Return _resultado
    '    End Function


    '#End Region

    '#Region "POLITICA"
    '    Public Shared Function L_prLibreriaPoliticaGeneral(_cod1 As Integer, _cod2 As Integer) As DataTable
    '        Dim _Tabla As DataTable

    '        Dim _listPalam As New List(Of Datos.DParametro)

    '        _listPalam.Add(New Datos.DParametro("@tipo", 3))
    '        _listPalam.Add(New Datos.DParametro("@cfuact", L_Usuario))
    '        _listPalam.Add(New Datos.DParametro("@cdcod1", _cod1))
    '        _listPalam.Add(New Datos.DParametro("@cdcod2", _cod2))
    '        _Tabla = D_ProcedimientoConParam("sp_Mam_TC006", _listPalam)

    '        Return _Tabla
    '    End Function

    '    Public Shared Function L_prLibreriaPoliticaComboGeneral(_cod1 As Integer, _cod2 As Integer) As DataTable
    '        Dim _Tabla As DataTable

    '        Dim _listPalam As New List(Of Datos.DParametro)

    '        _listPalam.Add(New Datos.DParametro("@tipo", 4))
    '        _listPalam.Add(New Datos.DParametro("@cfuact", L_Usuario))
    '        _listPalam.Add(New Datos.DParametro("@cdcod1", _cod1))
    '        _listPalam.Add(New Datos.DParametro("@cdcod2", _cod2))
    '        _Tabla = D_ProcedimientoConParam("sp_Mam_TC006", _listPalam)

    '        Return _Tabla
    '    End Function
    '    Public Shared Function L_prServiciosTabla(_value As Integer) As DataTable
    '        Dim _Tabla As DataTable

    '        Dim _listPalam As New List(Of Datos.DParametro)

    '        _listPalam.Add(New Datos.DParametro("@tipo", 5))
    '        _listPalam.Add(New Datos.DParametro("@cfuact", L_Usuario))
    '        _listPalam.Add(New Datos.DParametro("@CodTipo", _value))
    '        _Tabla = D_ProcedimientoConParam("sp_Mam_TC006", _listPalam)

    '        Return _Tabla
    '    End Function


    '    Public Shared Function L_prPoliticaGrabar(ByRef _numi As String, _tipo As Integer, _cuota As Integer, _cant As Integer, _desc As Integer, _obs As String, _serv As Integer) As Boolean
    '        Dim _resultado As Boolean

    '        Dim _Tabla As DataTable
    '        Dim _listParam As New List(Of Datos.DParametro)

    '        _listParam.Add(New Datos.DParametro("@tipo", 1))
    '        _listParam.Add(New Datos.DParametro("@cfnumi", _numi))
    '        _listParam.Add(New Datos.DParametro("@cftipo", _tipo))
    '        _listParam.Add(New Datos.DParametro("@cfcuota", _cuota))
    '        _listParam.Add(New Datos.DParametro("@cfcant", _cant))
    '        _listParam.Add(New Datos.DParametro("@cfdesc", _desc))
    '        _listParam.Add(New Datos.DParametro("@cfobs", _obs))
    '        _listParam.Add(New Datos.DParametro("@cftce4ser", _serv))
    '        _listParam.Add(New Datos.DParametro("@cfuact", L_Usuario))
    '        _Tabla = D_ProcedimientoConParam("sp_Mam_TC006", _listParam)

    '        If _Tabla.Rows.Count > 0 Then
    '            _numi = _Tabla.Rows(0).Item(0)

    '            _resultado = True
    '        Else
    '            _resultado = False
    '        End If

    '        Return _resultado
    '    End Function

    '    Public Shared Function L_prPoliticaModificar(ByRef _numi As String, _tipo As Integer, _cuota As Integer, _cant As Integer, _desc As Integer, _obs As String, _serv As Integer) As Boolean
    '        Dim _resultado As Boolean


    '        Dim _Tabla As DataTable
    '        Dim _listParam As New List(Of Datos.DParametro)

    '        _listParam.Add(New Datos.DParametro("@tipo", 2))
    '        _listParam.Add(New Datos.DParametro("@cfnumi", _numi))
    '        _listParam.Add(New Datos.DParametro("@cftipo", _tipo))
    '        _listParam.Add(New Datos.DParametro("@cfcuota", _cuota))
    '        _listParam.Add(New Datos.DParametro("@cfcant", _cant))
    '        _listParam.Add(New Datos.DParametro("@cfdesc", _desc))
    '        _listParam.Add(New Datos.DParametro("@cfobs", _obs))
    '        _listParam.Add(New Datos.DParametro("@cftce4ser", _serv))
    '        _listParam.Add(New Datos.DParametro("@cfuact", L_Usuario))
    '        _Tabla = D_ProcedimientoConParam("sp_Mam_TC006", _listParam)

    '        If _Tabla.Rows.Count > 0 Then
    '            _numi = _Tabla.Rows(0).Item(0)
    '            _resultado = True
    '        Else
    '            _resultado = False
    '        End If

    '        Return _resultado
    '    End Function

    '    Public Shared Function L_prPoliticaBorrar(_numi As String, ByRef _mensaje As String) As Boolean

    '        Dim _resultado As Boolean

    '        If L_fnbValidarEliminacion(_numi, "TC006", "cfnumi", _mensaje) = True Then
    '            Dim _Tabla As DataTable

    '            Dim _listParam As New List(Of Datos.DParametro)

    '            _listParam.Add(New Datos.DParametro("@tipo", -1))
    '            _listParam.Add(New Datos.DParametro("@cfnumi", _numi))
    '            _listParam.Add(New Datos.DParametro("@cfuact", L_Usuario))

    '            _Tabla = D_ProcedimientoConParam("sp_Mam_TC006", _listParam)

    '            If _Tabla.Rows.Count > 0 Then
    '                _numi = _Tabla.Rows(0).Item(0)
    '                _resultado = True
    '            Else
    '                _resultado = False
    '            End If
    '        Else
    '            _resultado = False
    '        End If

    '        Return _resultado
    '    End Function
    '#End Region

    '#Region "DBDies Productos"

    '    Public Shared Function L_prProductoGeneral() As DataTable
    '        Dim _Tabla As DataTable

    '        Dim _listParam As New List(Of Datos.DParametro)

    '        _listParam.Add(New Datos.DParametro("@tipo", 3))
    '        _listParam.Add(New Datos.DParametro("@lduact", L_Usuario))
    '        _Tabla = D_ProcedimientoConParam("sp_Mam_TCL003", _listParam)

    '        Return _Tabla
    '    End Function

    '    Public Shared Function L_prProductoInventarioGeneral() As DataTable
    '        Dim _Tabla As DataTable

    '        Dim _listParam As New List(Of Datos.DParametro)

    '        _listParam.Add(New Datos.DParametro("@tipo", 4))
    '        _listParam.Add(New Datos.DParametro("@lduact", L_Usuario))
    '        _Tabla = D_ProcedimientoConParam("sp_Mam_TCL003", _listParam)

    '        Return _Tabla
    '    End Function
    '    Public Shared Function L_prProductoGrabar(ByRef _ldnumi As String, _ldcprod As String, _ldcdprod1 As String, _ldgr As Integer, _ldumed As String, _ldsmin As Integer, _ldap As Integer, _Nameimg As String,
    '                                              _prec As Double, _prev As Double) As Boolean
    '        Dim _resultado As Boolean
    '        Dim _Tabla As DataTable
    '        Dim _listParam As New List(Of Datos.DParametro)
    '        _listParam.Add(New Datos.DParametro("@tipo", 1))
    '        _listParam.Add(New Datos.DParametro("@ldnumi", _ldnumi))
    '        _listParam.Add(New Datos.DParametro("@ldcprod", _ldcprod))
    '        _listParam.Add(New Datos.DParametro("@ldcdprod1", _ldcdprod1))
    '        _listParam.Add(New Datos.DParametro("@ldgr1", _ldgr))
    '        _listParam.Add(New Datos.DParametro("@ldumed", _ldumed))
    '        _listParam.Add(New Datos.DParametro("@ldsmin", _ldsmin))
    '        _listParam.Add(New Datos.DParametro("@ldap", _ldap))
    '        _listParam.Add(New Datos.DParametro("@ldimg", _Nameimg))
    '        _listParam.Add(New Datos.DParametro("@ldprec", _prec))
    '        _listParam.Add(New Datos.DParametro("@ldprev", _prev))
    '        _listParam.Add(New Datos.DParametro("@lduact", L_Usuario))
    '        _Tabla = D_ProcedimientoConParam("sp_Mam_TCL003", _listParam)

    '        If _Tabla.Rows.Count > 0 Then
    '            _ldnumi = _Tabla.Rows(0).Item(0)
    '            _resultado = True
    '        Else
    '            _resultado = False
    '        End If

    '        Return _resultado
    '    End Function
    '    Public Shared Function L_prProductoModificar(ByRef _ldnumi As String, _ldcprod As String, _ldcdprod1 As String, _ldgr As Integer, _ldumed As String, _ldsmin As Integer, _ldap As Integer, _Nameimg As String, _prec As Double, _prev As Double) As Boolean
    '        Dim _resultado As Boolean
    '        Dim _Tabla As DataTable
    '        Dim _listParam As New List(Of Datos.DParametro)

    '        _listParam.Add(New Datos.DParametro("@tipo", 2))
    '        _listParam.Add(New Datos.DParametro("@ldnumi", _ldnumi))
    '        _listParam.Add(New Datos.DParametro("@ldcprod", _ldcprod))
    '        _listParam.Add(New Datos.DParametro("@ldcdprod1", _ldcdprod1))
    '        _listParam.Add(New Datos.DParametro("@ldgr1", _ldgr))
    '        _listParam.Add(New Datos.DParametro("@ldumed", _ldumed))
    '        _listParam.Add(New Datos.DParametro("@ldsmin", _ldsmin))
    '        _listParam.Add(New Datos.DParametro("@ldap", _ldap))
    '        _listParam.Add(New Datos.DParametro("@ldimg", _Nameimg))
    '        _listParam.Add(New Datos.DParametro("@ldprec", _prec))
    '        _listParam.Add(New Datos.DParametro("@ldprev", _prev))
    '        _listParam.Add(New Datos.DParametro("@lduact", L_Usuario))
    '        _Tabla = D_ProcedimientoConParam("sp_Mam_TCL003", _listParam)


    '        If _Tabla.Rows.Count > 0 Then
    '            _ldnumi = _Tabla.Rows(0).Item(0)
    '            _resultado = True
    '        Else
    '            _resultado = False
    '        End If

    '        Return _resultado
    '    End Function
    '    Public Shared Function L_prProductoBorrar(_numi As String, ByRef _mensaje As String) As Boolean

    '        Dim _resultado As Boolean

    '        If L_fnbValidarEliminacion(_numi, "TCL003", "ldnumi", _mensaje) = True Then
    '            Dim _Tabla As DataTable

    '            Dim _listParam As New List(Of Datos.DParametro)

    '            _listParam.Add(New Datos.DParametro("@tipo", -1))
    '            _listParam.Add(New Datos.DParametro("@ldnumi", _numi))
    '            _listParam.Add(New Datos.DParametro("@lduact", L_Usuario))
    '            _Tabla = D_ProcedimientoConParam("sp_Mam_TCL003", _listParam)

    '            If _Tabla.Rows.Count > 0 Then
    '                _numi = _Tabla.Rows(0).Item(0)
    '                _resultado = True
    '            Else
    '                _resultado = False
    '            End If
    '        Else
    '            _resultado = False
    '        End If

    '        Return _resultado
    '    End Function
    '#End Region


    '#Region "SERVICIO VENTA"

    '    Public Shared Function L_prServicioVentaGeneral() As DataTable
    '        Dim _Tabla As DataTable

    '        Dim _listParam As New List(Of Datos.DParametro)

    '        _listParam.Add(New Datos.DParametro("@tipo", 3))
    '        _listParam.Add(New Datos.DParametro("@lduact", L_Usuario))

    '        _Tabla = D_ProcedimientoConParam("sp_Mam_TCL002", _listParam)

    '        Return _Tabla
    '    End Function

    '    Public Shared Function L_prServicioVentaAYUdaCLiente() As DataTable
    '        Dim _Tabla As DataTable

    '        Dim _listParam As New List(Of Datos.DParametro)

    '        _listParam.Add(New Datos.DParametro("@tipo", 10))
    '        _listParam.Add(New Datos.DParametro("@lduact", L_Usuario))

    '        _Tabla = D_ProcedimientoConParam("sp_Mam_TCL002", _listParam)

    '        Return _Tabla
    '    End Function
    '    Public Shared Function L_prServicioVentaPoliticaDescuento(_numicliente As Integer,
    '                                                              _numiServicio As Integer) As DataTable
    '        Dim _Tabla As DataTable

    '        Dim _listParam As New List(Of Datos.DParametro)

    '        _listParam.Add(New Datos.DParametro("@tipo", 8))
    '        _listParam.Add(New Datos.DParametro("@lduact", L_Usuario))
    '        _listParam.Add(New Datos.DParametro("@ldtcl1cli", _numicliente))
    '        _listParam.Add(New Datos.DParametro("@serv", _numiServicio))
    '        _Tabla = D_ProcedimientoConParam("sp_Mam_TCL002", _listParam)

    '        Return _Tabla
    '    End Function

    '    Public Shared Function L_prServicioVentaDetalle(_ldnumi As Integer) As DataTable
    '        Dim _Tabla As DataTable

    '        Dim _listParam As New List(Of Datos.DParametro)

    '        _listParam.Add(New Datos.DParametro("@tipo", 4))
    '        _listParam.Add(New Datos.DParametro("@ldnumi", _ldnumi))
    '        _listParam.Add(New Datos.DParametro("@lduact", L_Usuario))

    '        _Tabla = D_ProcedimientoConParam("sp_Mam_TCL002", _listParam)

    '        Return _Tabla
    '    End Function

    '    Public Shared Function L_prServicioVentaAyudaServicio(_libTipoLavado As Integer, _Lib1_4 As Integer) As DataTable
    '        Dim _Tabla As DataTable

    '        Dim _listParam As New List(Of Datos.DParametro)

    '        _listParam.Add(New Datos.DParametro("@tipo", 6))
    '        _listParam.Add(New Datos.DParametro("@lduact", L_Usuario))
    '        _listParam.Add(New Datos.DParametro("@edtipo", _libTipoLavado))
    '        _listParam.Add(New Datos.DParametro("@lbtip1_4", _Lib1_4))
    '        _Tabla = D_ProcedimientoConParam("sp_Mam_TCL002", _listParam)

    '        Return _Tabla
    '    End Function

    '    Public Shared Function L_prServicioVentaAyudaVehiculo(_Placa As String) As DataTable
    '        Dim _Tabla As DataTable

    '        Dim _listParam As New List(Of Datos.DParametro)

    '        _listParam.Add(New Datos.DParametro("@tipo", 9))
    '        _listParam.Add(New Datos.DParametro("@lduact", L_Usuario))
    '        _listParam.Add(New Datos.DParametro("@placa", _Placa))
    '        _Tabla = D_ProcedimientoConParam("sp_Mam_TCL002", _listParam)

    '        Return _Tabla
    '    End Function

    '    Public Shared Function L_prServicioVentaAyudaPersonal() As DataTable
    '        Dim _Tabla As DataTable

    '        Dim _listParam As New List(Of Datos.DParametro)

    '        _listParam.Add(New Datos.DParametro("@tipo", 7))
    '        _listParam.Add(New Datos.DParametro("@lduact", L_Usuario))
    '        _Tabla = D_ProcedimientoConParam("sp_Mam_TCL002", _listParam)

    '        Return _Tabla
    '    End Function



    '    Public Shared Function L_prServicioVentaGrabar(ByRef _ldnumi As String, _ldtcl1cli As Integer,
    '                                                   _ldtcl11veh As Integer,
    '    _ldfdoc As Date, _estado As Integer, _ldmefec As String, _lbtipo As Integer, _TCL0021 As DataTable) As Boolean

    '        Dim _resultado As Boolean
    '        Dim _Tabla As DataTable
    '        Dim _listParam As New List(Of Datos.DParametro)

    '        _listParam.Add(New Datos.DParametro("@tipo", 1))
    '        _listParam.Add(New Datos.DParametro("@ldnumi", _ldnumi))
    '        _listParam.Add(New Datos.DParametro("@ldsuc", 1))
    '        _listParam.Add(New Datos.DParametro("@ldtcl1cli", _ldtcl1cli))
    '        _listParam.Add(New Datos.DParametro("@ldtcl11veh", _ldtcl11veh))
    '        _listParam.Add(New Datos.DParametro("@ldtven", 1))
    '        _listParam.Add(New Datos.DParametro("@ldfdoc", _ldfdoc))
    '        _listParam.Add(New Datos.DParametro("@ldtmon", 1))
    '        _listParam.Add(New Datos.DParametro("@ldest", _estado))
    '        _listParam.Add(New Datos.DParametro("@ldtpago", 1))
    '        _listParam.Add(New Datos.DParametro("@ldmefec", _ldmefec))
    '        _listParam.Add(New Datos.DParametro("@lbtip1_4", _lbtipo))
    '        _listParam.Add(New Datos.DParametro("@lduact", L_Usuario))
    '        _listParam.Add(New Datos.DParametro("@TCL0021", "", _TCL0021))
    '        _Tabla = D_ProcedimientoConParam("sp_Mam_TCL002", _listParam)

    '        If _Tabla.Rows.Count > 0 Then
    '            _ldnumi = _Tabla.Rows(0).Item(0)
    '            _resultado = True
    '        Else
    '            _resultado = False
    '        End If

    '        Return _resultado
    '    End Function
    '    Public Shared Function L_prServicioVentaModificar(ByRef _ldnumi As String, _ldtcl1cli As Integer, _ldtcl11veh As Integer,
    '    _ldfdoc As Date, _estado As Integer, _ldmefec As String, _lbtipo As Integer, _TCL0021 As DataTable) As Boolean

    '        '@hbnumi ,@hbnom  ,@hbdor ,@hbper   
    '        '	,@hbtipo   ,@hbsuc ,@hbobs,@newFecha,@newHora,@hbuact
    '        Dim _resultado As Boolean
    '        Dim _Tabla As DataTable
    '        Dim _listParam As New List(Of Datos.DParametro)

    '        _listParam.Add(New Datos.DParametro("@tipo", 2))
    '        _listParam.Add(New Datos.DParametro("@ldnumi", _ldnumi))
    '        _listParam.Add(New Datos.DParametro("@ldsuc", 1))
    '        _listParam.Add(New Datos.DParametro("@ldtcl1cli", _ldtcl1cli))
    '        _listParam.Add(New Datos.DParametro("@ldtcl11veh", _ldtcl11veh))
    '        _listParam.Add(New Datos.DParametro("@ldtven", 1))
    '        _listParam.Add(New Datos.DParametro("@ldfdoc", _ldfdoc))
    '        _listParam.Add(New Datos.DParametro("@ldtmon", 1))
    '        _listParam.Add(New Datos.DParametro("@ldest", _estado))
    '        _listParam.Add(New Datos.DParametro("@ldtpago", 1))
    '        _listParam.Add(New Datos.DParametro("@ldmefec", _ldmefec))
    '        _listParam.Add(New Datos.DParametro("@lbtip1_4", _lbtipo))
    '        _listParam.Add(New Datos.DParametro("@lduact", L_Usuario))
    '        _listParam.Add(New Datos.DParametro("@TCL0021", "", _TCL0021))
    '        _Tabla = D_ProcedimientoConParam("sp_Mam_TCL002", _listParam)

    '        If _Tabla.Rows.Count > 0 Then
    '            _ldnumi = _Tabla.Rows(0).Item(0)
    '            _resultado = True
    '        Else
    '            _resultado = False
    '        End If

    '        Return _resultado
    '    End Function
    '    Public Shared Function L_prServicioVentaBorrar(_numi As String, ByRef _mensaje As String) As Boolean

    '        Dim _resultado As Boolean

    '        If L_fnbValidarEliminacion(_numi, "TCL002", "ldnumi", _mensaje) = True Then
    '            Dim _Tabla As DataTable

    '            Dim _listParam As New List(Of Datos.DParametro)

    '            _listParam.Add(New Datos.DParametro("@tipo", -1))
    '            _listParam.Add(New Datos.DParametro("@ldnumi", _numi))
    '            _listParam.Add(New Datos.DParametro("@lduact", L_Usuario))

    '            _Tabla = D_ProcedimientoConParam("sp_Mam_TCL002", _listParam)

    '            If _Tabla.Rows.Count > 0 Then
    '                _numi = _Tabla.Rows(0).Item(0)
    '                _resultado = True
    '            Else
    '                _resultado = False
    '            End If
    '        Else
    '            _resultado = False
    '        End If

    '        Return _resultado
    '    End Function
    '    Public Shared Function L_prReporteServiciosLavaderoPorPlaca(_date As Date) As DataTable
    '        Dim _Tabla As DataTable

    '        Dim _listParam As New List(Of Datos.DParametro)

    '        _listParam.Add(New Datos.DParametro("@tipo", 11))
    '        _listParam.Add(New Datos.DParametro("@ldfdoc", _date))
    '        _listParam.Add(New Datos.DParametro("@lduact", L_Usuario))
    '        _Tabla = D_ProcedimientoConParam("sp_Mam_TCL002", _listParam)

    '        Return _Tabla
    '    End Function

    '    Public Shared Function L_prReporteServiciosGeneral(_date As Date) As DataTable
    '        Dim _Tabla As DataTable

    '        Dim _listParam As New List(Of Datos.DParametro)

    '        _listParam.Add(New Datos.DParametro("@tipo", 13))
    '        _listParam.Add(New Datos.DParametro("@ldfdoc", _date))
    '        _listParam.Add(New Datos.DParametro("@lduact", L_Usuario))
    '        _Tabla = D_ProcedimientoConParam("sp_Mam_TCL002", _listParam)

    '        Return _Tabla
    '    End Function

    '    Public Shared Function L_prReporteServicioVentaCliente(_NumiVenta As Integer) As DataTable
    '        Dim _Tabla As DataTable

    '        Dim _listParam As New List(Of Datos.DParametro)

    '        _listParam.Add(New Datos.DParametro("@tipo", 12))
    '        _listParam.Add(New Datos.DParametro("@ldnumi", _NumiVenta))
    '        _listParam.Add(New Datos.DParametro("@lduact", L_Usuario))
    '        _Tabla = D_ProcedimientoConParam("sp_Mam_TCL002", _listParam)

    '        Return _Tabla
    '    End Function


    '#End Region

    '#Region "SERVICIO VENTA GRUA / REMOLQUE"

    '    Public Shared Function L_prServicioVentaGruaGeneral() As DataTable
    '        Dim _Tabla As DataTable

    '        Dim _listParam As New List(Of Datos.DParametro)

    '        _listParam.Add(New Datos.DParametro("@tipo", 3))
    '        _listParam.Add(New Datos.DParametro("@rcuact", L_Usuario))

    '        _Tabla = D_ProcedimientoConParam("sp_Mam_TCR002", _listParam)

    '        Return _Tabla
    '    End Function

    '    Public Shared Function L_prServicioVentaGruaAYUdaCLiente() As DataTable
    '        Dim _Tabla As DataTable

    '        Dim _listParam As New List(Of Datos.DParametro)

    '        _listParam.Add(New Datos.DParametro("@tipo", 10))
    '        _listParam.Add(New Datos.DParametro("@rcuact", L_Usuario))

    '        _Tabla = D_ProcedimientoConParam("sp_Mam_TCR002", _listParam)

    '        Return _Tabla
    '    End Function
    '    Public Shared Function L_prServicioVentaGruaPoliticaDescuento(_numicliente As Integer,
    '                                                              _numiServicio As Integer) As DataTable
    '        Dim _Tabla As DataTable

    '        Dim _listParam As New List(Of Datos.DParametro)

    '        _listParam.Add(New Datos.DParametro("@tipo", 8))
    '        _listParam.Add(New Datos.DParametro("@rcuact", L_Usuario))
    '        _listParam.Add(New Datos.DParametro("@rctcl1cli", _numicliente))
    '        _listParam.Add(New Datos.DParametro("@serv", _numiServicio))
    '        _Tabla = D_ProcedimientoConParam("sp_Mam_TCR002", _listParam)

    '        Return _Tabla
    '    End Function

    '    Public Shared Function L_prServicioVentaGruaDetalle(_ldnumi As Integer) As DataTable
    '        Dim _Tabla As DataTable

    '        Dim _listParam As New List(Of Datos.DParametro)

    '        _listParam.Add(New Datos.DParametro("@tipo", 4))
    '        _listParam.Add(New Datos.DParametro("@rcnumi", _ldnumi))
    '        _listParam.Add(New Datos.DParametro("@rcuact", L_Usuario))

    '        _Tabla = D_ProcedimientoConParam("sp_Mam_TCR002", _listParam)

    '        Return _Tabla
    '    End Function

    '    Public Shared Function L_prServicioVentaGruaAyudaServicio(_libTipoGrua As Integer) As DataTable
    '        Dim _Tabla As DataTable

    '        Dim _listParam As New List(Of Datos.DParametro)

    '        _listParam.Add(New Datos.DParametro("@tipo", 6))
    '        _listParam.Add(New Datos.DParametro("@rcuact", L_Usuario))
    '        _listParam.Add(New Datos.DParametro("@edtipo", _libTipoGrua))
    '        _Tabla = D_ProcedimientoConParam("sp_Mam_TCR002", _listParam)

    '        Return _Tabla
    '    End Function

    '    Public Shared Function L_prServicioVentaGruaAyudaVehiculo(_NumiCliente As Integer) As DataTable
    '        Dim _Tabla As DataTable

    '        Dim _listParam As New List(Of Datos.DParametro)

    '        _listParam.Add(New Datos.DParametro("@tipo", 9))
    '        _listParam.Add(New Datos.DParametro("@rcuact", L_Usuario))
    '        _listParam.Add(New Datos.DParametro("@rctcl1cli", _NumiCliente))
    '        _Tabla = D_ProcedimientoConParam("sp_Mam_TCR002", _listParam)

    '        Return _Tabla
    '    End Function

    '    Public Shared Function L_prServicioVentaGruaAyudaPersonal() As DataTable
    '        Dim _Tabla As DataTable

    '        Dim _listParam As New List(Of Datos.DParametro)

    '        _listParam.Add(New Datos.DParametro("@tipo", 7))
    '        _listParam.Add(New Datos.DParametro("@rcuact", L_Usuario))
    '        _Tabla = D_ProcedimientoConParam("sp_Mam_TCR002", _listParam)

    '        Return _Tabla
    '    End Function

    '    Public Shared Function L_prServicioVentaGruaGrabar(ByRef _rcnumi As String, _rctcl1cli As Integer,
    '                                                   _rctcl11veh As Integer,
    '    _rcfdoc As Date, _estado As Integer, _rcmefec As String, _rclat As Double, _rclong As Double, _rcobs As String, _TCR0021 As DataTable) As Boolean

    '        '     @rcnumi ,@rcsuc,@rctcl1cli ,@rctven    
    '        ',@rcfdoc ,@rcfvcr ,@rctmon ,@rcpdes  ,@rcmdes ,@rcest ,@rctpago ,@rcmefec  ,
    '        '@rcmtar  ,@newFecha,@newHora,@rcuact
    '        Dim _resultado As Boolean
    '        Dim _Tabla As DataTable
    '        Dim _listParam As New List(Of Datos.DParametro)

    '        _listParam.Add(New Datos.DParametro("@tipo", 1))
    '        _listParam.Add(New Datos.DParametro("@rcnumi", _rcnumi))
    '        _listParam.Add(New Datos.DParametro("@rcsuc", 1))
    '        _listParam.Add(New Datos.DParametro("@rctcl1cli", _rctcl1cli))
    '        _listParam.Add(New Datos.DParametro("@rctcl11veh", _rctcl11veh))
    '        _listParam.Add(New Datos.DParametro("@rctven", 1))
    '        _listParam.Add(New Datos.DParametro("@rcfdoc", _rcfdoc))
    '        _listParam.Add(New Datos.DParametro("@rctmon", 1))
    '        _listParam.Add(New Datos.DParametro("@rcest", _estado))
    '        _listParam.Add(New Datos.DParametro("@rctpago", 1))
    '        _listParam.Add(New Datos.DParametro("@rcmefec", _rcmefec))
    '        _listParam.Add(New Datos.DParametro("@rclat", _rclat))
    '        _listParam.Add(New Datos.DParametro("@rclong", _rclong))
    '        _listParam.Add(New Datos.DParametro("@rcobs", _rcobs))
    '        _listParam.Add(New Datos.DParametro("@rcuact", L_Usuario))
    '        _listParam.Add(New Datos.DParametro("@TCR0021", "", _TCR0021))
    '        _Tabla = D_ProcedimientoConParam("sp_Mam_TCR002", _listParam)

    '        If _Tabla.Rows.Count > 0 Then
    '            _rcnumi = _Tabla.Rows(0).Item(0)
    '            _resultado = True
    '        Else
    '            _resultado = False
    '        End If

    '        Return _resultado
    '    End Function
    '    Public Shared Function L_prServicioVentaGruaModificar(ByRef _rcnumi As String, _rctcl1cli As Integer, _rctcl11veh As Integer,
    '    _rcfdoc As Date, _estado As Integer, _rcmefec As String, _rclat As Double, _rclong As Double,
    '    _rcobs As String, _TCR0021 As DataTable) As Boolean

    '        '@hbnumi ,@hbnom  ,@hbdor ,@hbper   
    '        '	,@hbtipo   ,@hbsuc ,@hbobs,@newFecha,@newHora,@hbuact
    '        Dim _resultado As Boolean
    '        Dim _Tabla As DataTable
    '        Dim _listParam As New List(Of Datos.DParametro)

    '        _listParam.Add(New Datos.DParametro("@tipo", 2))
    '        _listParam.Add(New Datos.DParametro("@rcnumi", _rcnumi))
    '        _listParam.Add(New Datos.DParametro("@rcsuc", 1))
    '        _listParam.Add(New Datos.DParametro("@rctcl1cli", _rctcl1cli))
    '        _listParam.Add(New Datos.DParametro("@rctcl11veh", _rctcl11veh))
    '        _listParam.Add(New Datos.DParametro("@rctven", 1))
    '        _listParam.Add(New Datos.DParametro("@rcfdoc", _rcfdoc))
    '        _listParam.Add(New Datos.DParametro("@rctmon", 1))
    '        _listParam.Add(New Datos.DParametro("@rcest", _estado))
    '        _listParam.Add(New Datos.DParametro("@rctpago", 1))
    '        _listParam.Add(New Datos.DParametro("@rcmefec", _rcmefec))
    '        _listParam.Add(New Datos.DParametro("@rclat", _rclat))
    '        _listParam.Add(New Datos.DParametro("@rclong", _rclong))
    '        _listParam.Add(New Datos.DParametro("@rcobs", _rcobs))
    '        _listParam.Add(New Datos.DParametro("@rcuact", L_Usuario))
    '        _listParam.Add(New Datos.DParametro("@TCR0021", "", _TCR0021))
    '        _Tabla = D_ProcedimientoConParam("sp_Mam_TCR002", _listParam)

    '        If _Tabla.Rows.Count > 0 Then
    '            _rcnumi = _Tabla.Rows(0).Item(0)
    '            _resultado = True
    '        Else
    '            _resultado = False
    '        End If

    '        Return _resultado
    '    End Function
    '    Public Shared Function L_prServicioVentaGruaBorrar(_numi As String, ByRef _mensaje As String) As Boolean

    '        Dim _resultado As Boolean

    '        If L_fnbValidarEliminacion(_numi, "TCR002", "rcnumi", _mensaje) = True Then
    '            Dim _Tabla As DataTable

    '            Dim _listParam As New List(Of Datos.DParametro)

    '            _listParam.Add(New Datos.DParametro("@tipo", -1))
    '            _listParam.Add(New Datos.DParametro("@rcnumi", _numi))
    '            _listParam.Add(New Datos.DParametro("@rcuact", L_Usuario))

    '            _Tabla = D_ProcedimientoConParam("sp_Mam_TCR002", _listParam)

    '            If _Tabla.Rows.Count > 0 Then
    '                _numi = _Tabla.Rows(0).Item(0)
    '                _resultado = True
    '            Else
    '                _resultado = False
    '            End If
    '        Else
    '            _resultado = False
    '        End If

    '        Return _resultado
    '    End Function


    '#End Region

    '#Region "TCG VEHICULO"
    '    Public Shared Function L_prLibreriaVehiculoGeneral(_cod1 As Integer, _cod2 As Integer) As DataTable
    '        Dim _Tabla As DataTable

    '        Dim _listPalam As New List(Of Datos.DParametro)

    '        _listPalam.Add(New Datos.DParametro("@tipo", 4))
    '        _listPalam.Add(New Datos.DParametro("@gcuact", L_Usuario))
    '        _listPalam.Add(New Datos.DParametro("@cdcod1", _cod1))
    '        _listPalam.Add(New Datos.DParametro("@cdcod2", _cod2))
    '        _Tabla = D_ProcedimientoConParam("sp_Mam_TCG002", _listPalam)

    '        Return _Tabla
    '    End Function



    '    Public Shared Function L_prVehiculoSucursalAyuda(Optional _Cadena As String = "", Optional _order As String = "") As DataTable
    '        Dim _Tabla As DataTable

    '        Dim _listParam As New List(Of Datos.DParametro)

    '        _listParam.Add(New Datos.DParametro("@tipo", 6))
    '        _listParam.Add(New Datos.DParametro("@gcuact", L_Usuario))

    '        _Tabla = D_ProcedimientoConParam("sp_Mam_TCG002", _listParam)

    '        Return _Tabla
    '    End Function


    '    Public Shared Function L_prTCGVehiculoGrabar(ByRef _numi As String, _id As String, _marca As String, _modelo As String, _persona As String, _obs As String, _tipo As String, _suc As String, _TCG0021 As DataTable) As Boolean
    '        Dim _resultado As Boolean

    '        Dim _Tabla As DataTable
    '        Dim _listParam As New List(Of Datos.DParametro)

    '        _listParam.Add(New Datos.DParametro("@tipo", 1))
    '        _listParam.Add(New Datos.DParametro("@gcnumi", _numi))
    '        _listParam.Add(New Datos.DParametro("@gcid", _id))
    '        _listParam.Add(New Datos.DParametro("@gcmar", _marca))
    '        _listParam.Add(New Datos.DParametro("@gcmod", _modelo))
    '        _listParam.Add(New Datos.DParametro("@gcper", _persona))
    '        _listParam.Add(New Datos.DParametro("@gcobs", _obs))
    '        _listParam.Add(New Datos.DParametro("@gctipo", _tipo))
    '        _listParam.Add(New Datos.DParametro("@gcsuc", _suc))
    '        _listParam.Add(New Datos.DParametro("@gcuact", L_Usuario))
    '        _listParam.Add(New Datos.DParametro("@TCG0021", "", _TCG0021))
    '        _Tabla = D_ProcedimientoConParam("sp_Mam_TCG002", _listParam)

    '        If _Tabla.Rows.Count > 0 Then
    '            _numi = _Tabla.Rows(0).Item(0)

    '            _resultado = True
    '        Else
    '            _resultado = False
    '        End If

    '        Return _resultado
    '    End Function

    '    Public Shared Function L_prTCGVehiculoModificar(_numi As String, _id As String, _marca As String, _modelo As String, _persona As String, _obs As String, _tipo As String, _suc As String, _TCG0021 As DataTable) As Boolean
    '        Dim _resultado As Boolean
    '        Dim l As Integer = _TCG0021.Rows.Count

    '        Dim _Tabla As DataTable
    '        Dim _listParam As New List(Of Datos.DParametro)

    '        _listParam.Add(New Datos.DParametro("@tipo", 2))
    '        _listParam.Add(New Datos.DParametro("@gcnumi", _numi))
    '        _listParam.Add(New Datos.DParametro("@gcid", _id))
    '        _listParam.Add(New Datos.DParametro("@gcmar", _marca))
    '        _listParam.Add(New Datos.DParametro("@gcmod", _modelo))
    '        _listParam.Add(New Datos.DParametro("@gcper", _persona))
    '        _listParam.Add(New Datos.DParametro("@gcobs", _obs))
    '        _listParam.Add(New Datos.DParametro("@gctipo", _tipo))
    '        _listParam.Add(New Datos.DParametro("@gcsuc", _suc))
    '        _listParam.Add(New Datos.DParametro("@gcuact", L_Usuario))
    '        _listParam.Add(New Datos.DParametro("@TCG0021", "", _TCG0021))
    '        _Tabla = D_ProcedimientoConParam("sp_Mam_TCG002", _listParam)

    '        If _Tabla.Rows.Count > 0 Then
    '            _numi = _Tabla.Rows(0).Item(0)
    '            _resultado = True
    '        Else
    '            _resultado = False
    '        End If

    '        Return _resultado
    '    End Function

    '    Public Shared Function L_prTCGVehiculoBorrar(_numi As String, ByRef _mensaje As String) As Boolean

    '        Dim _resultado As Boolean

    '        If L_fnbValidarEliminacion(_numi, "TCG002", "gcnumi", _mensaje) = True Then
    '            Dim _Tabla As DataTable

    '            Dim _listParam As New List(Of Datos.DParametro)

    '            _listParam.Add(New Datos.DParametro("@tipo", -1))
    '            _listParam.Add(New Datos.DParametro("@gcnumi", _numi))
    '            _listParam.Add(New Datos.DParametro("@gcuact", L_Usuario))

    '            _Tabla = D_ProcedimientoConParam("sp_Mam_TCG002", _listParam)

    '            If _Tabla.Rows.Count > 0 Then
    '                _numi = _Tabla.Rows(0).Item(0)
    '                _resultado = True
    '            Else
    '                _resultado = False
    '            End If
    '        Else
    '            _resultado = False
    '        End If

    '        Return _resultado
    '    End Function

    '    Public Shared Function L_prTCGVehiculoGeneral(_suc As String, Optional _Cadena As String = "", Optional _order As String = "") As DataTable 'modelo 1 con condificion
    '        Dim _Tabla As DataTable

    '        Dim _listParam As New List(Of Datos.DParametro)

    '        _listParam.Add(New Datos.DParametro("@tipo", 3))
    '        _listParam.Add(New Datos.DParametro("@gcsuc", _suc))
    '        _listParam.Add(New Datos.DParametro("@gcuact", L_Usuario))

    '        _Tabla = D_ProcedimientoConParam("sp_Mam_TCG002", _listParam)

    '        Return _Tabla
    '    End Function

    '    Public Shared Function L_prTCGVehiculoImagenes(_hbnumi As Integer) As DataTable
    '        Dim _Tabla As DataTable

    '        Dim _listParam As New List(Of Datos.DParametro)

    '        _listParam.Add(New Datos.DParametro("@tipo", 5))
    '        _listParam.Add(New Datos.DParametro("@gcnumi", _hbnumi))
    '        _listParam.Add(New Datos.DParametro("@gcuact", L_Usuario))
    '        _Tabla = D_ProcedimientoConParam("sp_Mam_TCG002", _listParam)

    '        Return _Tabla
    '    End Function
    '#End Region


#End Region

#Region "RESERVAS TCH003"
    Public Shared Function L_prHotelReservaObtenerSocioConFechaIngresoYMora(nSoc As String) As DataTable

        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 27))
        _listParam.Add(New Datos.DParametro("@hdnumi", nSoc))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCH003", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prHotelReservaObtenerVentasPorNumiReserva(numi As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 26))
        _listParam.Add(New Datos.DParametro("@hdnumi", numi))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCH003", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prHotelReservaGetReservasCanceladas() As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 25))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCH003", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prHotelReservaGetHuespedes(_numi As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 15))
        _listParam.Add(New Datos.DParametro("@hdnumi", _numi))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCH003", _listParam)

        Return _Tabla
    End Function
    Public Shared Function L_prHotelReservaGetCabañasRangoFecha(_fechaIn As String, _fechaOut As String, _cantPer As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 14))
        _listParam.Add(New Datos.DParametro("@hdfcin", _fechaIn))
        _listParam.Add(New Datos.DParametro("@hdfcou", _fechaOut))
        _listParam.Add(New Datos.DParametro("@cantPer", _cantPer))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCH003", _listParam)

        Return _Tabla
    End Function
    Public Shared Function L_prHotelReservaGetCabañasPorCantPersonas(_cantPer As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 16))
        _listParam.Add(New Datos.DParametro("@cantPer", _cantPer))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCH003", _listParam)

        Return _Tabla
    End Function
    Public Shared Function L_prHotelReservaGetReservasEnFechaYCabaña(_fecha As String, _numiCaba As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 17))
        _listParam.Add(New Datos.DParametro("@hdfcin", _fecha))
        _listParam.Add(New Datos.DParametro("@hdtc2cab", _numiCaba))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCH003", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prHotelReservaGetLiberadosPorFechaYCabaña(_fecha As String, _numiCaba As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 18))
        _listParam.Add(New Datos.DParametro("@hdfcin", _fecha))
        _listParam.Add(New Datos.DParametro("@hdtc2cab", _numiCaba))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCH003", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prHotelReservaGetUltimoPagoPorNroSocio(_nroSocio As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 19))
        _listParam.Add(New Datos.DParametro("@nroSocio", _nroSocio))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCH003", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prHotelReservaReporteResumenReservas(_fechaDel As String, _fechaAl As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 24))
        _listParam.Add(New Datos.DParametro("@hdfcin", _fechaDel))
        _listParam.Add(New Datos.DParametro("@hdfcou", _fechaAl))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCH003", _listParam)

        Return _Tabla
    End Function
    Public Shared Function L_prHotelReservaGetReservaReporte(_numiReg As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 11))
        _listParam.Add(New Datos.DParametro("@hdnumi", _numiReg))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCH003", _listParam)

        Return _Tabla
    End Function
    Public Shared Function L_prHotelReservaGetReservaCompleta(_numiReg As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 111))
        _listParam.Add(New Datos.DParametro("@hdnumi", _numiReg))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCH003", _listParam)

        Return _Tabla
    End Function
    Public Shared Function L_prHotelReservaGetReserva(_numiReg As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 4))
        _listParam.Add(New Datos.DParametro("@hdnumi", _numiReg))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCH003", _listParam)

        Return _Tabla
    End Function
    Public Shared Function L_prHotelReservaGetCabanas() As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 5))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCH003", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prHotelReservaGetReservasDeLaFecha(_fecha As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 7))
        _listParam.Add(New Datos.DParametro("@hdfcin", _fecha))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCH003", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prHotelReservaGetClientes() As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 8))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCH003", _listParam)

        Return _Tabla
    End Function
    Public Shared Function L_prHotelReservaGetClientesSoloSocios() As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 81))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCH003", _listParam)

        Return _Tabla
    End Function
    Public Shared Function L_prHotelReservaDetalleClientes(_numiReserva) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 9))
        _listParam.Add(New Datos.DParametro("@hdnumi", _numiReserva))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCH003", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prHotelReservaGetCliente(_numiClie) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 10))
        _listParam.Add(New Datos.DParametro("@hdtc1cli", _numiClie))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCH003", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prHotelReservaGetEstructuraDeDias() As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 6))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCH003", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prHotelReservaGrabar(ByRef _numi As String, _fecha As String, _numiCli As String, _fIng As String, _fSal As String, _numiCaba As String, _obs As String, _est As String, _tipo As String, _refSocio As String, _lugarReservaHecha As String, _usuarioEncReserva As String, _precio As String, _total As String, _dtOcupantes As DataTable) As Boolean
        Dim _res As Boolean

        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 1))
        _listParam.Add(New Datos.DParametro("@hdfing", _fecha))
        _listParam.Add(New Datos.DParametro("@hdtc1cli", _numiCli))
        _listParam.Add(New Datos.DParametro("@hdfcin", _fIng))
        _listParam.Add(New Datos.DParametro("@hdfcou", _fSal))
        _listParam.Add(New Datos.DParametro("@hdtc2cab", _numiCaba))
        _listParam.Add(New Datos.DParametro("@hdobs", _obs))
        _listParam.Add(New Datos.DParametro("@hdest", _est))
        _listParam.Add(New Datos.DParametro("@hdtip", _tipo))
        _listParam.Add(New Datos.DParametro("@hdtc1soc", _refSocio))
        _listParam.Add(New Datos.DParametro("@hdlugres", _lugarReservaHecha))
        _listParam.Add(New Datos.DParametro("@hdencres", _usuarioEncReserva))
        _listParam.Add(New Datos.DParametro("@hdprecio", _precio))
        _listParam.Add(New Datos.DParametro("@hdtotal", _total))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))
        _listParam.Add(New Datos.DParametro("@TCEH00311", "", _dtOcupantes))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCH003", _listParam)

        If _Tabla.Rows.Count > 0 Then
            _res = True
            _numi = _Tabla.Rows(0).Item(0)
        Else
            _res = False
        End If

        Return _res
    End Function

    Public Shared Function L_prHotelReservaModificarFecha(_numi As String, _fIng As String, _fSal As String, _numiCaba As String) As Boolean
        Dim _res As Boolean

        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 2))
        _listParam.Add(New Datos.DParametro("@hdnumi", _numi))
        _listParam.Add(New Datos.DParametro("@hdfcin", _fIng))
        _listParam.Add(New Datos.DParametro("@hdfcou", _fSal))
        _listParam.Add(New Datos.DParametro("@hdtc2cab", _numiCaba))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCH003", _listParam)

        If _Tabla.Rows.Count > 0 Then
            _res = True
            _numi = _Tabla.Rows(0).Item(0)
        Else
            _res = False
        End If

        Return _res
    End Function
    Public Shared Function L_prHotelReservaModificarEstado(_numi As String, _estado As String) As Boolean
        Dim _res As Boolean

        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 22))
        _listParam.Add(New Datos.DParametro("@hdnumi", _numi))
        _listParam.Add(New Datos.DParametro("@hdest", _estado))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCH003", _listParam)

        If _Tabla.Rows.Count > 0 Then
            _res = True
            _numi = _Tabla.Rows(0).Item(0)
        Else
            _res = False
        End If

        Return _res
    End Function

    Public Shared Function L_prHotelReservaModificarDatos(_numi As String, _numiCliEncargado As String, _obs As String, _tipo As String, _refSocio As String, _lugarReservaHecha As String, _precio As String, _dtOcupantes As DataTable) As Boolean
        Dim _res As Boolean

        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 21))
        _listParam.Add(New Datos.DParametro("@hdnumi", _numi))
        _listParam.Add(New Datos.DParametro("@hdtc1cli", _numiCliEncargado))
        _listParam.Add(New Datos.DParametro("@hdobs", _obs))
        _listParam.Add(New Datos.DParametro("@hdtip", _tipo))
        _listParam.Add(New Datos.DParametro("@hdtc1soc", _refSocio))
        _listParam.Add(New Datos.DParametro("@hdlugres", _lugarReservaHecha))
        _listParam.Add(New Datos.DParametro("@hdprecio", _precio))
        _listParam.Add(New Datos.DParametro("@TCEH00311", "", _dtOcupantes))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCH003", _listParam)

        If _Tabla.Rows.Count > 0 Then
            _res = True
            _numi = _Tabla.Rows(0).Item(0)
        Else
            _res = False
        End If

        Return _res
    End Function


    Public Shared Function L_prHotelReservaBorrar(_numi As String, ByRef _mensaje As String) As Boolean

        Dim _resultado As Boolean

        If L_fnbValidarEliminacion(_numi, "TCH003", "hdnumi", _mensaje) = True Then
            Dim _Tabla As DataTable

            Dim _listParam As New List(Of Datos.DParametro)

            _listParam.Add(New Datos.DParametro("@tipo", -1))
            _listParam.Add(New Datos.DParametro("@hdnumi", _numi))
            _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

            _Tabla = D_ProcedimientoConParam("sp_dg_TCH003", _listParam)

            If _Tabla.Rows.Count > 0 Then
                _numi = _Tabla.Rows(0).Item(0)
                _resultado = True
            Else
                _resultado = False
            End If
        Else
            _resultado = False
        End If

        Return _resultado
    End Function

#Region "TCH0033 HORAS LIBRES"
    Public Shared Function L_prHoraLibreTCH0033Grabar(_TCH0033 As DataTable, _obs As String) As Boolean
        Dim _resultado As Boolean

        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 12))
        _listParam.Add(New Datos.DParametro("@eggobs", _obs))
        _listParam.Add(New Datos.DParametro("@TCH0033", "", _TCH0033))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCH003", _listParam)

        If _Tabla.Rows.Count > 0 Then
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function

    Public Shared Function L_prHoraLibreTCH0033GetPorFecha(_fecha As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 13))
        _listParam.Add(New Datos.DParametro("@fecha", _fecha))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCH003", _listParam)

        Return _Tabla
    End Function
#End Region
#End Region

#Region "INCIDENCIAS TCH0032"
    Public Shared Function L_prHotelIncidenciaDetalleClientes(_numiClie) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)


        _listParam.Add(New Datos.DParametro("@tipo", 3))
        _listParam.Add(New Datos.DParametro("@eftc1cli", _numiClie))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCH0032", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prHotelIncidenciaGrabar(_numiRes As String, _numiCli As String, _obs As String) As Boolean
        Dim _res As Boolean

        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 1))
        _listParam.Add(New Datos.DParametro("@eftc3res", _numiRes))
        _listParam.Add(New Datos.DParametro("@eftc1cli", _numiCli))
        _listParam.Add(New Datos.DParametro("@efobs", _obs))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TCH0032", _listParam)

        If _Tabla.Rows.Count > 0 Then
            _res = True
        Else
            _res = False
        End If

        Return _res
    End Function
#End Region

#Region "Planilla de sueldos"
    Public Shared Function L_PAPlanillaSueldos(fecha As String, planilla As String) As DataTable
        Dim _Tabla As DataTable
        '_Tabla = D_Procedimiento("PlanillaSueldo")
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@fecha", fecha))
        _listParam.Add(New Datos.DParametro("@cbplan", planilla))
        _Tabla = D_ProcedimientoConParam("PlanillaSueldo", _listParam)
        Return _Tabla
    End Function

#End Region

#Region "Conceptos Inventario - TCI001"
    Public Shared Function L_ObtenerDatosTCI001(tipo As String) As DataTable
        'OBTENCION_DETALLE_GRID
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 3))
        _listParam.Add(New Datos.DParametro("@tipo1", tipo))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_go_TCI001", _listParam)

        Return _Tabla
    End Function
    Public Shared Function L_AgregarDatosTCI001(ByRef numi As String, desc As String, mov As String, movcli As String,
                                                tipo1 As String, est As String) As Boolean
        'OBTENCION_DETALLE_GRID
        Dim _resultado As Boolean
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 1))
        _listParam.Add(New Datos.DParametro("@numi", numi))
        _listParam.Add(New Datos.DParametro("@desc", desc))
        _listParam.Add(New Datos.DParametro("@mov", mov))
        _listParam.Add(New Datos.DParametro("@movcli", movcli))
        _listParam.Add(New Datos.DParametro("@tipo1", tipo1))
        _listParam.Add(New Datos.DParametro("@est", est))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_go_TCI001", _listParam)

        If _Tabla.Rows.Count > 0 Then
            numi = _Tabla.Rows(0).Item(0)
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function
    Public Shared Function L_ModificarDatosTCI001(ByRef numi As String, desc As String, mov As String, movcli As String,
                                                  tipo1 As String, est As String) As Boolean
        'OBTENCION_DETALLE_GRID
        Dim _resultado As Boolean
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 2))
        _listParam.Add(New Datos.DParametro("@numi", numi))
        _listParam.Add(New Datos.DParametro("@desc", desc))
        _listParam.Add(New Datos.DParametro("@mov", mov))
        _listParam.Add(New Datos.DParametro("@movcli", movcli))
        _listParam.Add(New Datos.DParametro("@tipo1", tipo1))
        _listParam.Add(New Datos.DParametro("@est", est))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_go_TCI001", _listParam)

        If _Tabla.Rows.Count > 0 Then
            numi = _Tabla.Rows(0).Item(0)
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function
    Public Shared Function L_EliminarDatosTCI001(numi As Integer) As Boolean
        Dim _resultado As Boolean
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", -1))
        _listParam.Add(New Datos.DParametro("@numi", numi))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_go_TCI001", _listParam)

        If _Tabla.Rows.Count > 0 Then
            numi = _Tabla.Rows(0).Item(0)
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function
#End Region

#Region "Movimiento"

    Public Shared Function L_Validar_Producto(_codigo As String) As String
        Dim _Tabla As DataTable
        _Tabla = D_Datos_Tabla("ldcdprod1", "TCL003", "ldcprod= '" + _codigo + "'")
        If _Tabla.Rows.Count > 0 Then
            Return _Tabla.Rows(0).Item(0)
        Else
            Return ""
        End If
    End Function

    Public Shared Function L_ProductosGeneral(_Modo As Integer, Optional _Cadena As String = "") As DataSet
        Dim _Tabla As DataTable
        Dim _Ds As New DataSet
        Dim _Where As String
        If _Modo = 0 Then
            _Where = " TCL003.ldnumi = TCL003.ldnumi"
        Else
            _Where = _Cadena
        End If
        _Tabla = D_Datos_Tabla("ldnumi, ldcdprod1, ldumed", "TCL003", _Where + " order by ldnumi")
        _Ds.Tables.Add(_Tabla)
        Return _Ds
    End Function


    Public Shared Function L_MovimientosGeneral(_Modo As Integer, Optional _Cadena As String = "") As DataSet
        Dim _Tabla As DataTable
        Dim _Ds As New DataSet
        Dim _Where As String
        If _Modo = 0 Then
            _Where = " 1 = 1"
        Else
            _Where = _Cadena
        End If
        _Tabla = D_Datos_Tabla("*", "TI002", _Where + " order by ibid")
        _Ds.Tables.Add(_Tabla)
        Return _Ds
    End Function

    Public Shared Function L_MovimientosDetalleGeneral(_Modo As Integer, Optional _Cadena As String = "") As DataSet
        Dim _Tabla As DataTable
        Dim _Ds As New DataSet
        Dim _Where As String
        If _Modo = 0 Then
            _Where = " TI0021.icId = TI0021.icId"
        Else
            'consulto con el cod del producto(cadena)
            _Where = "TI002.ibid = " + _Cadena + " AND " + _
                     "TI002.ibid = TI0021.icibid AND " + _
                     "TI0021.iccprod = TCL003.ldnumi"
        End If
        _Tabla = D_Datos_Tabla("TI0021.iccprod, TCL003.ldcdprod1, ABS(TI0021.iccant) AS iccant", "TI0021, TI002, TCL003", _Where + " order by icid")
        _Ds.Tables.Add(_Tabla)
        Return _Ds
        'SELECT TI0021.iccprod, TCL003.ldcdprod1, ABS(TI0021.iccant) AS iccant 
        'FROM TI0021, TI002, TCL003 
        'WHERE TI002.ibid = -1 AND TI002.ibid = TI0021.icibid AND TI0021.iccprod = TCL003.ldnumi order by icid
    End Function

    Public Shared Sub L_Grabar_Movimientos(ByRef _id As String, _fechaDoc As String, _idConcepto As String, _observaciones As String, _estado As String, _alm As String, numiEqui As String)
        Dim _Actualizacion As String
        Dim _Err As Boolean

        Dim _Tabla As DataTable
        _Tabla = D_Maximo("TI002", "ibid", "ibid = ibid")
        If Not IsDBNull(_Tabla.Rows(0).Item(0)) Then
            _id = _Tabla.Rows(0).Item(0) + 1
        Else
            _id = "1"
        End If

        _Actualizacion = "'" + Date.Now.Date.ToString("yyyy/MM/dd") + "', '" + Now.Hour.ToString + ":" + Now.Minute.ToString + "' ,'" + L_Usuario + "'"
        Dim Sql As String
        Sql = _id + ", '" + _fechaDoc + "'," + _idConcepto + ",'" + _observaciones + "'," + _estado + "," + _alm + "," + numiEqui + "," + _Actualizacion
        _Err = D_Insertar_Datos("TI002", Sql)
    End Sub

    Public Shared Sub L_Modificar_Movimientos(_id As String, _fechaDoc As String, _idConcepto As String, _observaciones As String, _estado As String)
        Dim _Err As Boolean
        Dim Sql, _where As String

        Sql = "ibfdoc ='" + _fechaDoc + "', " + _
        "ibconcep =" + _idConcepto + ", " + _
        "ibobs = '" + _observaciones + "', " + _
        "ibest = " + _estado + ", " + _
        "ibfact = '" + Date.Now.Date.ToString("yyyy/MM/dd") + "', " + _
        "ibhact = '" + Now.Hour.ToString + ":" + Now.Minute.ToString + "', " +
        "ibuact = '" + L_Usuario + "'"

        _where = "ibid = " + _id
        _Err = D_Modificar_Datos("TI002", Sql, _where)
    End Sub

    Public Shared Sub L_Grabar_MovimientosDetalle(_id As String, _codProd As String, _cant As String)
        Dim _Err As Boolean
        Dim Sql As String
        Dim _numi As String
        Dim _Tabla As DataTable
        _Tabla = D_Maximo("TI0021", "icid", "1 = 1")
        If Not IsDBNull(_Tabla.Rows(0).Item(0)) Then
            _numi = _Tabla.Rows(0).Item(0) + 1
        Else
            _numi = "1"
        End If

        Sql = _numi + ", " + _id + "," + _codProd + "," + _cant
        _Err = D_Insertar_Datos("TI0021", Sql)
    End Sub

    Public Shared Function L_LibreriaGeneral(_codConcepto As String) As DataSet
        Dim _Tabla As DataTable
        Dim _Ds As New DataSet
        Dim _Where As String
        _Where = "cecon=" + _codConcepto
        _Tabla = D_Datos_Tabla("cenum, cedesc", "TC0051", _Where + " order by cenum")
        _Ds.Tables.Add(_Tabla)
        Return _Ds
    End Function

    Public Shared Sub L_Grabar_Libreria(_codConcepto As Integer, ByRef _numeracion As Integer, _descr As String, _usu As String)
        Dim _Err As Boolean
        'Dim _numi As String
        Dim _Tabla As DataTable

        '_Tabla = D_Maximo("TC005", "ceid", "1 = 1")
        'If Not IsDBNull(_Tabla.Rows(0).Item(0)) Then
        '    _numi = _Tabla.Rows(0).Item(0) + 1
        'Else
        '    _numi = "1"
        'End If

        _Tabla = D_Maximo("TC0051", "cenum", "cecon=" + Str(_codConcepto))
        If Not IsDBNull(_Tabla.Rows(0).Item(0)) Then
            _numeracion = _Tabla.Rows(0).Item(0) + 1
        Else
            _numeracion = "1"
        End If

        Dim _Actualizacion As String = "'" + Date.Now.Date.ToString("yyyy/MM/dd") + "', '" + Now.Hour.ToString + ":" + Now.Minute.ToString + "' ,'" + L_Usuario + "'"
        Dim Sql As String
        'Sql = _numi + ", " + Str(_codConcepto) + "," + Str(_numeracion) + ",'" + _descr + "'," + "0" + "," + _Actualizacion
        Sql = Str(_codConcepto) + "," + Str(_numeracion) + ",'" + _descr + "'," + _Actualizacion
        _Err = D_Insertar_Datos("TC0051 (cecon, cenum, cedesc, cefact, cehact, ceuact)", Sql)
    End Sub

    Public Shared Sub L_Borrar_Movimientos(_Id As String)

        Dim _Where As String
        Dim _Err As Boolean

        _Where = "ibid = " + _Id
        _Err = D_Eliminar_Datos("TI002", _Where)

    End Sub
    Public Shared Sub L_Borrar_MovimientosDetalle(_id As String)
        Dim _Where As String
        Dim _Err As Boolean

        _Where = "icibid = " + _id
        _Err = D_Eliminar_Datos("TI0021", _Where)
    End Sub

    Public Shared Sub L_Actualizar_StockMovimiento(_codProd As String, _cant As String)
        'verificamos si es que ya existe el codigo del producto en la tabla TI001
        Dim _Err As Boolean
        Dim Sql, _where As String


        Dim _Tabla As DataTable
        Dim cantOriginal
        _Tabla = D_Datos_Tabla("TI001.iacant", "TI001", "iacprod ='" + _codProd + "'")
        If _Tabla.Rows.Count > 0 Then 'ya existe el cod del producto en la tabla TI001,se suma la cantidad a lo que hay
            cantOriginal = _Tabla.Rows(0).Item(0)
            _cant = cantOriginal + _cant
            Sql = "iacant =" + _cant

            _where = "iacprod ='" + _codProd + "'"
            _Err = D_Modificar_Datos("TI001", Sql, _where)
        Else ' no existe el cod de producto en la tabla TI001, se crea un nuevo registro con ese codigo y la cantidad
            Sql = "'" + _codProd + "'," + _cant
            _Err = D_Insertar_Datos("TI001", Sql)
        End If
    End Sub

    Public Shared Sub L_Actualizar_StockMovimiento(_codProd As String, _cant As String, _alm As String)
        'verificamos si es que ya existe el codigo del producto en la tabla TI001
        Dim _Err As Boolean
        Dim Sql, _where As String


        Dim _Tabla As DataTable
        Dim cantOriginal
        _Tabla = D_Datos_Tabla("TI001.iccven", "TI001", "iccprod =" + _codProd + " and icalm=" + _alm)
        If _Tabla.Rows.Count > 0 Then 'ya existe el cod del producto en la tabla TI001,se suma la cantidad a lo que hay
            cantOriginal = _Tabla.Rows(0).Item(0)
            _cant = cantOriginal + _cant
            Sql = "iccven =" + _cant

            _where = "iccprod =" + _codProd + " and icalm=" + _alm
            _Err = D_Modificar_Datos("TI001", Sql, _where)
        Else ' no existe el cod de producto en la tabla TI001, se crea un nuevo registro con ese codigo y la cantidad
            Sql = _alm + ", " + "'" + _codProd + "'," + _cant + ", 'MV'"
            _Err = D_Insertar_Datos("TI001", Sql)
        End If

    End Sub

    Public Shared Function L_ConceptoInventario(tipo As String) As DataTable
        Dim Tabla As DataTable
        Dim Where As String
        Where = "cptipo=" + tipo + " and cpest=1"
        Tabla = D_Datos_Tabla("cpnumi, cpdesc, cpmov", "TCI001", Where + " order by cpnumi")
        Return Tabla
    End Function

#End Region

#Region "Saldo Inventario"

    Public Shared Function L_ObtenerStockInventario(_modo As Integer, Optional cod As String = "") As DataSet
        Dim _Tabla As DataTable
        Dim _Ds As New DataSet
        Dim _where As String = IIf(cod.Equals(""), " a.iccprod =b.cacod ", " a.iccprod = " + cod)

        Select Case _modo
            Case 1 'Todos
                _where = _where + " and 1 = 1"
            Case 2 'Diferente de Cero
                _where = _where + " and a.iccven <> 0"
            Case 3 'Positivo
                _where = _where + " and a.iccven > 0"
            Case 4 'Negativo 
                _where = _where + " and a.iccven < 0"
        End Select
        _where = _where + " order by a.iccven desc"
        _Tabla = D_Datos_Tabla("a.iccprod as Codigo, b.ldcdprod1 as Producto, a.iccven as Cantidad", "TI001 a, TCL003 b", _where)
        _Ds.Tables.Add(_Tabla)
        Return _Ds
    End Function

    Public Shared Function L_KardexInventario() As DataTable
        Dim _Tabla As DataTable
        Dim _where As String = " 1 = 1 "

        _Tabla = D_Datos_Tabla("*", "VR_KardexInventario", _where)
        Return _Tabla

    End Function

    Public Shared Sub L_Actualizar_SaldoInventario(cod As String, cant As String, alm As String)
        'verificamos si es que ya existe el codigo del producto en la tabla TI001
        Dim _Err As Boolean
        Dim _where As String = "iccprod =" + cod + " and icalm = " + alm
        _Err = D_Modificar_Datos("TI001", "iccven = " + cant, _where)
    End Sub

#End Region

#Region "Kardex de Inventario"

    Public Shared Function L_GetProductos(_Where As String) As DataSet
        Dim _Tabla As DataTable
        Dim _Ds As New DataSet
        _Where = " a.ldgr1 = b.cenum " _
            + "and b.cecod1=16  " _
            + "and b.cecod2=1 and ldap=1" _
            + IIf(_Where.Equals(""), "", " and " + _Where) _
            + " order by ldnumi"
        _Tabla = D_Datos_Tabla("a.ldnumi as numi, a.ldcprod as cod, a.ldcdprod1 as [desc], " _
                               + "a.ldgr1 as gr, b.cedesc1 as ngr, a.ldumed as umed, " _
                               + "a.ldsmin as smin, a.ldap as ap, a.ldimg as img, " _
                               + "a.ldprec as prec, a.ldfact as fact, a.ldhact as hact, " _
                               + "a.lduact as uact",
                               "TCL003 a, TC0051 b", _Where)
        _Ds.Tables.Add(_Tabla)
        Return _Ds
        'SELECT 
        '	a.ldnumi as numi, a.ldcprod as cod, a.ldcdprod1 as [desc], a.ldgr1 as gr, b.cedesc1 as ngr, a.ldumed as umed, 
        '	a.ldsmin as smin, a.ldap as ap, a.ldimg as img, a.ldprec as prec, a.ldfact as fact, a.ldhact as hact, a.lduact as uact
        'FROM TCL003 a, TC0051 b 
        'WHERE  a.ldgr1 = b.cenum and b.cecod1=16  and b.cecod2=1 and ldap=1 
        'order by a.ldnumi
    End Function

    Shared Function L_VistaKardexInventario(cod As String, fIni As String, fFin As String) As DataSet
        Dim _Tabla As DataTable
        Dim _Ds As New DataSet
        Dim _Where As String

        If (cod.Equals("-1")) Then
            _Where = "cprod = " + cod + " And fdoc >= '" + fIni + "' And fdoc <= '" + fFin + "'"
        Else
            _Where = "cprod = " + cod + " And fdoc >= '" + fIni + "' And fdoc <= '" + fFin + "'"
        End If

        Dim campos As String = "*"
        _Tabla = D_Datos_Tabla(campos, "VR_KardexInventario", _Where + " order by fdoc")
        _Tabla.Columns("fdoc").DataType = GetType(Date)
        _Ds.Tables.Add(_Tabla)
        Return _Ds
    End Function

    Shared Function L_VistaKardexInventarioTodo(cod As String, Optional fFin As String = "") As DataSet
        Dim _Tabla As DataTable
        Dim _Ds As New DataSet
        Dim _Where As String = "cprod = " + cod + IIf(fFin.Equals(""), "", " And fdoc < '" + fFin + "'")
        Dim campos As String = "*"
        _Tabla = D_Datos_Tabla(campos, "VR_KardexInventario", _Where + " order by fdoc")
        _Ds.Tables.Add(_Tabla)
        Return _Ds
    End Function

    Shared Function L_VistaStockActual(Optional _where1 As String = "") As DataTable
        Dim _Tabla As DataTable
        Dim _Where As String
        If _where1 = String.Empty Then
            _Where = "1=1"
        Else
            _Where = _where1
        End If

        Dim campos As String = "*"
        _Tabla = D_Datos_Tabla(campos, "VR_stockActual", _Where + " order by ldcdprod1")
        Return _Tabla
    End Function

#End Region

#Region "TC011 TURNOS"

    Public Shared Function L_prTurnoGeneral() As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 3))
        _listParam.Add(New Datos.DParametro("@cnuact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TC011", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prTurnoDetalle(numi As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 4))
        _listParam.Add(New Datos.DParametro("@cnnumi", numi))
        _listParam.Add(New Datos.DParametro("@cnuact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TC011", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prTurnoGrabar(ByRef numi As String, fecha As String, obs As String, est As String,
                                            _sabado As String, _minTolerancia As String, _minRetraso As String, detalle As DataTable) As Boolean
        Dim _resultado As Boolean

        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 1))
        _listParam.Add(New Datos.DParametro("@cnnumi", numi))
        _listParam.Add(New Datos.DParametro("@cnfdoc", fecha))
        _listParam.Add(New Datos.DParametro("@cnobs", obs))
        _listParam.Add(New Datos.DParametro("@cnest", est))
        _listParam.Add(New Datos.DParametro("@cnsab", _sabado))
        _listParam.Add(New Datos.DParametro("@cntoler", _minTolerancia))
        _listParam.Add(New Datos.DParametro("@cnretraso", _minRetraso))
        _listParam.Add(New Datos.DParametro("@cnuact", L_Usuario))
        _listParam.Add(New Datos.DParametro("@TC0111", "", detalle))

        _Tabla = D_ProcedimientoConParam("sp_dg_TC011", _listParam)

        If _Tabla.Rows.Count > 0 Then
            numi = _Tabla.Rows(0).Item(0)
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function

    Public Shared Function L_prTurnoModificar(numi As String, fecha As String, obs As String, est As String,
                                             _sabado As String, _minTolerancia As String, _minRetraso As String, detalle As DataTable) As Boolean
        Dim _resultado As Boolean

        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 2))
        _listParam.Add(New Datos.DParametro("@cnnumi", numi))
        _listParam.Add(New Datos.DParametro("@cnfdoc", fecha))
        _listParam.Add(New Datos.DParametro("@cnobs", obs))
        _listParam.Add(New Datos.DParametro("@cnest", est))
        _listParam.Add(New Datos.DParametro("@cnsab", _sabado))
        _listParam.Add(New Datos.DParametro("@cntoler", _minTolerancia))
        _listParam.Add(New Datos.DParametro("@cnretraso", _minRetraso))
        _listParam.Add(New Datos.DParametro("@cnuact", L_Usuario))
        _listParam.Add(New Datos.DParametro("@TC0111", "", detalle))

        _Tabla = D_ProcedimientoConParam("sp_dg_TC011", _listParam)

        If _Tabla.Rows.Count > 0 Then
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function

    Public Shared Function L_prTurnoEliminar(numi As String) As Boolean
        Dim _resultado As Boolean

        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", -1))
        _listParam.Add(New Datos.DParametro("@cnnumi", numi))
        _listParam.Add(New Datos.DParametro("@cnuact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TC011", _listParam)

        If _Tabla.Rows.Count > 0 Then
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function

#End Region

#Region "TP007"
    Public Shared Function L_prAsistenciaReportePlanilla(_fechaDel As String, _fechaAl As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 9))
        _listParam.Add(New Datos.DParametro("@fecha1", _fechaDel))
        _listParam.Add(New Datos.DParametro("@fecha2", _fechaAl))
        _listParam.Add(New Datos.DParametro("@piuact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TP007", _listParam)

        Return _Tabla
    End Function
    Public Shared Function L_prAsistenciaDatosPorPersonalGeneral(numiPer As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 6))
        _listParam.Add(New Datos.DParametro("@picper", numiPer))
        _listParam.Add(New Datos.DParametro("@piuact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TP007", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prAsistenciaEstructuraGeneral() As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 5))
        _listParam.Add(New Datos.DParametro("@piuact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TP007", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prAsistenciaCorreccionEstructura() As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 10))
        _listParam.Add(New Datos.DParametro("@piuact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TP007", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prAsistenciaCorreccionGetTZ001(_fecha As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 11))
        _listParam.Add(New Datos.DParametro("@fecha1", _fecha))
        _listParam.Add(New Datos.DParametro("@piuact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TP007", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prAsistenciaCorreccionGetTurnoPorPersona(_fecha As String, _numiPer As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 12))
        _listParam.Add(New Datos.DParametro("@fecha1", _fecha))
        _listParam.Add(New Datos.DParametro("@picper", _numiPer))
        _listParam.Add(New Datos.DParametro("@piuact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TP007", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prAsistenciaCorreccionGetTurnoPorPersonaAnteriorMeses(_fecha As String, _numiPer As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 121))
        _listParam.Add(New Datos.DParametro("@fecha1", _fecha))
        _listParam.Add(New Datos.DParametro("@picper", _numiPer))
        _listParam.Add(New Datos.DParametro("@piuact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TP007", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prAsistenciaGrabarTabla(tabla As DataTable) As Boolean
        Dim _resultado As Boolean

        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 7))
        _listParam.Add(New Datos.DParametro("@piuact", L_Usuario))
        _listParam.Add(New Datos.DParametro("@TP007", "", tabla))

        _Tabla = D_ProcedimientoConParam("sp_dg_TP007", _listParam)

        If _Tabla.Rows.Count > 0 Then
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function

    Public Shared Function L_prAsistenciaGrabarTablaMarcaciones(tabla As DataTable, tablaTZ001 As DataTable) As Boolean
        Dim _resultado As Boolean

        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 8))
        _listParam.Add(New Datos.DParametro("@piuact", L_Usuario))
        _listParam.Add(New Datos.DParametro("@TP0071", "", tabla))
        _listParam.Add(New Datos.DParametro("@TZ001", "", tablaTZ001))

        _Tabla = D_ProcedimientoConParam("sp_dg_TP007", _listParam)

        If _Tabla.Rows.Count > 0 Then
            _resultado = True
        Else
            _resultado = False
        End If

        Return _resultado
    End Function


    Public Shared Function L_prAsistenciaGetEstructuraReporteMensual() As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 13))
        _listParam.Add(New Datos.DParametro("@piuact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TP007", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prAsistenciaGetRegistrosTP0071PorMes(_fecha As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 14))
        _listParam.Add(New Datos.DParametro("@fecha1", _fecha))
        _listParam.Add(New Datos.DParametro("@piuact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_TP007", _listParam)

        Return _Tabla
    End Function
#End Region

#Region "ROLES CORRECTO"

    Public Shared Function L_prRolGeneral() As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 3))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_ZY002", _listParam)

        Return _Tabla
    End Function

    Public Shared Function L_prRolDetalleGeneral(_numi As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 4))
        _listParam.Add(New Datos.DParametro("@ybnumi", _numi))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_ZY002", _listParam)

        Return _Tabla
    End Function


    Public Shared Function L_prRolGrabar(ByRef _numi As String, _rol As String, _detalle As DataTable) As Boolean
        Dim _resultado As Boolean

        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 1))
        _listParam.Add(New Datos.DParametro("@ybnumi", _numi))
        _listParam.Add(New Datos.DParametro("@ybrol", _rol))
        _listParam.Add(New Datos.DParametro("@ZY0021", "", _detalle))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_ZY002", _listParam)

        If _Tabla.Rows.Count > 0 Then
            _numi = _Tabla.Rows(0).Item(0)
            _resultado = True
            'L_prTipoCambioGrabarHistorial(_numi, _fecha, _dolar, _ufv, "TIPO DE CAMBIO", 1)
        Else
            _resultado = False
        End If

        Return _resultado
    End Function

    Public Shared Function L_prRolModificar(_numi As String, _rol As String, _detalle As DataTable) As Boolean
        Dim _resultado As Boolean

        Dim _Tabla As DataTable
        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 2))
        _listParam.Add(New Datos.DParametro("@ybnumi", _numi))
        _listParam.Add(New Datos.DParametro("@ybrol", _rol))
        _listParam.Add(New Datos.DParametro("@ZY0021", "", _detalle))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_ZY002", _listParam)

        If _Tabla.Rows.Count > 0 Then
            _resultado = True
            'L_prTipoCambioGrabarHistorial(_numi, _fecha, _dolar, _ufv, "TIPO DE CAMBIO", 2)
        Else
            _resultado = False
        End If

        Return _resultado
    End Function



    Public Shared Function L_prRolBorrar(_numi As String, ByRef _mensaje As String) As Boolean

        Dim _resultado As Boolean

        If L_fnbValidarEliminacion(_numi, "ZY002", "ybnumi", _mensaje) = True Then
            Dim _Tabla As DataTable

            Dim _listParam As New List(Of Datos.DParametro)

            _listParam.Add(New Datos.DParametro("@tipo", -1))
            _listParam.Add(New Datos.DParametro("@ybnumi", _numi))
            _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

            _Tabla = D_ProcedimientoConParam("sp_dg_ZY002", _listParam)

            If _Tabla.Rows.Count > 0 Then
                _resultado = True
                'L_prTipoCambioGrabarHistorial(_numi, _fecha, _dolar, _ufv, "TIPO DE CAMBIO", 3)
            Else
                _resultado = False
            End If
        Else
            _resultado = False
        End If

        Return _resultado
    End Function



#End Region


#Region "VR_GO_ListarSocioPaganMortuoria Listar socios que SI y NO pagan caja mortuoria"

    Public Shared Function L_fnListarSocioPaganMortuoria(tsoc As String, Optional criterio As String = "") As DataTable
        Dim Tabla As DataTable
        Dim where As String = "a.tsoc=" + tsoc

        If (Not criterio = String.Empty) Then
            where = where + criterio
        End If

        Tabla = D_Datos_Tabla("ROW_NUMBER() OVER(ORDER BY a.nsoc ASC) AS [numi], a.nsoc, a.tsoc, a.ntsoc, a.nom, a.apat, a.amat, a.mor, a.nmor, a.fing",
                              "VR_GO_ListarSocioPaganMortuoria a",
                              where)
        Return Tabla
    End Function

#End Region

#Region "ZY004"
    Public Shared Function L_prTitulosAll(_cod As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 3))
        _listParam.Add(New Datos.DParametro("@yecod", _cod))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_ZY004", _listParam)

        Return _Tabla
    End Function

#End Region

#Region "FACTURA"
    Public Shared Sub L_Grabar_Factura(_Numi As String, _Fecha As String, _Nfac As String, _NAutoriz As String, _Est As String,
                                       _NitCli As String, _CodCli As String, _DesCli1 As String, _DesCli2 As String,
                                       _A As String, _B As String, _C As String, _D As String, _E As String, _F As String,
                                       _G As String, _H As String, _CodCon As String, _FecLim As String,
                                       _Imgqr As String, _Alm As String, _Numi2 As String)
        Dim Sql As String
        Try
            Sql = "" + _Numi + ", " _
                + "'" + _Fecha + "', " _
                + "" + _Nfac + ", " _
                + "" + _NAutoriz + ", " _
                + "" + _Est + ", " _
                + "'" + _NitCli + "', " _
                + "" + _CodCli + ", " _
                + "'" + _DesCli1 + "', " _
                + "'" + _DesCli2 + "', " _
                + "" + _A + ", " _
                + "" + _B + ", " _
                + "" + _C + ", " _
                + "" + _D + ", " _
                + "" + _E + ", " _
                + "" + _F + ", " _
                + "" + _G + ", " _
                + "" + _H + ", " _
                + "'" + _CodCon + "', " _
                + "'" + _FecLim + "', " _
                + "" + _Imgqr + ", " _
                + "" + _Alm + ", " _
                + "" + _Numi2 + ""

            D_Insertar_DatosDiconta("TFV001", Sql)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Shared Function L_fnFacturaLavadero(numi As Integer) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 22))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))
        _listParam.Add(New Datos.DParametro("@vcnumi", numi))
        _Tabla = D_ProcedimientoConParam("sp_go_TCS014", _listParam)

        Return _Tabla
    End Function
    Public Shared Function L_fnFacturaAyudaPagoSocios(numi As Integer) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 25))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))
        _listParam.Add(New Datos.DParametro("@vcnumi", numi))
        _Tabla = D_ProcedimientoConParam("sp_go_TCS014", _listParam)

        Return _Tabla
    End Function


    Public Shared Function L_fnActualizarNroFactura(numiVenta As Integer, nroFactura As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 23))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))
        _listParam.Add(New Datos.DParametro("@nroFactura", nroFactura))

        _listParam.Add(New Datos.DParametro("@vcnumi", numiVenta))
        _Tabla = D_ProcedimientoConParam("sp_go_TCS014", _listParam)

        Return _Tabla
    End Function
    Public Shared Function L_fnReciboMortuoria(numi As Integer) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 27))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))
        _listParam.Add(New Datos.DParametro("@numi", numi))
        _Tabla = D_ProcedimientoConParam("sp_go_TCS014", _listParam)

        Return _Tabla
    End Function
    Public Shared Function L_fnActualizarNroRecibo(numi As Integer, nroFactura As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 28))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))
        _listParam.Add(New Datos.DParametro("@nroFactura", nroFactura))

        _listParam.Add(New Datos.DParametro("@numi", numi))
        _Tabla = D_ProcedimientoConParam("sp_go_TCS014", _listParam)

        Return _Tabla
    End Function
    Public Shared Sub L_Modificar_Factura(Where As String, Optional _Fecha As String = "",
                                         Optional _Nfact As String = "", Optional _NAutoriz As String = "",
                                         Optional _Est As String = "", Optional _NitCli As String = "",
                                         Optional _CodCli As String = "", Optional _DesCli1 As String = "",
                                         Optional _DesCli2 As String = "", Optional _A As String = "",
                                         Optional _B As String = "", Optional _C As String = "",
                                         Optional _D As String = "", Optional _E As String = "",
                                         Optional _F As String = "", Optional _G As String = "",
                                         Optional _H As String = "", Optional _CodCon As String = "",
                                         Optional _FecLim As String = "", Optional _Imgqr As String = "",
                                         Optional _Alm As String = "", Optional _Numi2 As String = "")
        Dim Sql As String
        Try
            Sql = IIf(_Fecha.Equals(""), "", "fvafec = '" + _Fecha + "', ") +
              IIf(_Nfact.Equals(""), "", "fvanfac = " + _Nfact + ", ") +
              IIf(_NAutoriz.Equals(""), "", "fvaautoriz = " + _NAutoriz + ", ") +
              IIf(_Est.Equals(""), "", "fvaest = " + _Est) +
              IIf(_NitCli.Equals(""), "", "fvanitcli = '" + _NitCli + "', ") +
              IIf(_CodCli.Equals(""), "", "fvacodcli = " + _CodCli + ", ") +
              IIf(_DesCli1.Equals(""), "", "fvadescli1 = '" + _DesCli1 + "', ") +
              IIf(_DesCli2.Equals(""), "", "fvadescli2 = '" + _DesCli2 + "', ") +
              IIf(_A.Equals(""), "", "fvastot = " + _A + ", ") +
              IIf(_B.Equals(""), "", "fvaimpsi = " + _B + ", ") +
              IIf(_C.Equals(""), "", "fvaimpeo = " + _C + ", ") +
              IIf(_D.Equals(""), "", "fvaimptc = " + _D + ", ") +
              IIf(_E.Equals(""), "", "fvasubtotal = " + _E + ", ") +
              IIf(_F.Equals(""), "", "fvadesc = " + _F + ", ") +
              IIf(_G.Equals(""), "", "fvatotal = " + _G + ", ") +
              IIf(_H.Equals(""), "", "fvadebfis = " + _H + ", ") +
              IIf(_CodCon.Equals(""), "", "fvaccont = '" + _CodCon + "', ") +
              IIf(_FecLim.Equals(""), "", "fvaflim = '" + _FecLim + "', ") +
              IIf(_Imgqr.Equals(""), "", "fvaimgqr = '" + _Imgqr + "', ") +
              IIf(_Alm.Equals(""), "", "fvaalm = " + _Alm + ", ") +
              IIf(_Numi2.Equals(""), "", "fvanumi2 = " + _Numi2 + ", ")
            Sql = Sql.Trim
            If (Sql.Substring(Sql.Length - 1, 1).Equals(",")) Then
                Sql = Sql.Substring(0, Sql.Length - 1)
            End If

            D_Modificar_DatosDiconta("TFV001", Sql, Where)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Public Shared Sub L_Grabar_Factura_Detalle(_Numi As String, _CodProd As String, _DescProd As String, _Cant As String, _Precio As String, _Numi2 As String)
        Dim Sql As String
        Try
            Sql = _Numi + ", '" + _CodProd + "', '" + _DescProd + "', " + _Cant + ", " + _Precio + ", " + _Numi2

            D_Insertar_DatosDiconta("TFV0011", Sql)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Shared Function L_Reporte_Factura(_Numi As String, _Numi2 As String) As DataSet
        Dim _Tabla As DataTable
        Dim _Ds As New DataSet
        Dim _Where As String
        _Where = " fvanumi = " + _Numi + " and fvanumi2 = " + _Numi2

        _Tabla = D_Datos_TablaDiconta("*", "VR_GO_Factura", _Where)
        _Ds.Tables.Add(_Tabla)
        Return _Ds
    End Function
    Public Shared Function L_Reporte_Recibo(_Numi As String) As DataSet
        Dim _Tabla As DataTable
        Dim _Ds As New DataSet
        Dim _Where As String
        '_Where = "sflin in (select max(a.sflin)
        'From TCS015 as a where a.sfnumi = " + _Numi + " and sfrec = " + "0" + " and sfest = " + "2" + ")"
        _Where = "sflin in (select a.sflin 	from TCS015 as a where a.sfnumi = " + _Numi + " and sfrec = " + "0" + " and sfest = " + "2" + ")"

        _Tabla = D_Datos_Tabla("*", "VR_GO_ReciboMortuoria", _Where)
        _Ds.Tables.Add(_Tabla)
        Return _Ds
    End Function

    Public Shared Function L_Reporte_Factura_Cia(_Cia As String) As DataSet
        Dim _Tabla As DataTable
        Dim _Ds As New DataSet
        Dim _Where As String
        _Where = " scnumi = " + _Cia

        _Tabla = D_Datos_TablaDiconta("*", "TS003", _Where)
        _Ds.Tables.Add(_Tabla)
        Return _Ds
    End Function

    Public Shared Function L_fnGetIVA() As DataTable
        Dim _Tabla As DataTable
        Dim _Where As String
        _Where = "1 = 1"
        _Tabla = D_Datos_TablaDiconta("scdebfis", "TS003", _Where)
        Return _Tabla
    End Function

    Public Shared Function L_fnGetICE() As DataTable
        Dim _Tabla As DataTable
        Dim _Where As String
        _Where = "1 = 1"
        _Tabla = D_Datos_TablaDiconta("scice", "TS003", _Where)
        Return _Tabla
    End Function

    Public Shared Sub L_Grabar_Nit(_Nit As String, _Nom1 As String, _Nom2 As String)
        Dim _Err As Boolean
        Dim _Nom01, _Nom02 As String
        Dim Sql As String
        _Nom01 = ""
        _Nom02 = ""
        L_Validar_Nit(_Nit, _Nom01, _Nom02)

        If _Nom01 = "" Then
            Sql = _Nit + ", '" + _Nom1 + "', '" + _Nom2 + "'"
            _Err = D_Insertar_DatosDiconta("TS001", Sql)
        Else
            If (_Nom1 <> _Nom01) Or (_Nom2 <> _Nom02) Then
                Sql = "sanom1 = '" + _Nom1 + "' " +
                      IIf(_Nom02.ToString.Trim.Equals(""), "", ", sanom2 = '" + _Nom2 + "', ")
                _Err = D_Modificar_DatosDiconta("TS001", Sql, "sanit = '" + _Nit + "'")
            End If
        End If

    End Sub


    Public Shared Function L_Validar_Nit(_Nit As String, ByRef _Nom1 As String, ByRef _Nom2 As String) As Boolean
        Dim _Tabla As DataTable

        _Tabla = D_Datos_TablaDiconta("*", "TS001", "sanit = '" + _Nit + "'")

        If _Tabla.Rows.Count > 0 Then
            _Nom1 = _Tabla.Rows(0).Item(2)
            _Nom2 = IIf(_Tabla.Rows(0).Item(3).ToString.Trim.Equals(""), "", _Tabla.Rows(0).Item(3))
            Return True
        End If
        Return False
    End Function
 

    Public Shared Function L_Eliminar_Nit(_Nit As String) As Boolean
        Dim res As Boolean = False
        Try
            res = D_Eliminar_DatosDiconta("TS001", "sanit = " + _Nit)
        Catch ex As Exception
            res = False
        End Try
        Return res
    End Function

    Public Shared Function L_Dosificacion(_cia As String, _alm As String, _fecha As String) As DataSet
        Dim _Tabla As DataTable
        Dim _Ds As New DataSet
        Dim _Where As String
        _fecha = Now.Date.ToString("yyyy/MM/dd")
        _Where = "sbcia = " + _cia + " AND sbalm = " + _alm + " AND sbfdel <= '" + _fecha + "' AND sbfal >= '" + _fecha + "' AND sbest = 1 and sbtipo=1"

        _Tabla = D_Datos_TablaDiconta("*", "TS002", _Where)
        _Ds.Tables.Add(_Tabla)
        Return _Ds
    End Function

    Public Shared Sub L_Actualiza_Dosificacion(_Numi As String, _NumFac As String, _Numi2 As String)
        Dim _Err As Boolean
        Dim Sql, _where As String
        Sql = "sbnfac = " + _NumFac
        _where = "sbnumi = " + _Numi

        _Err = D_Modificar_DatosDiconta("TS002", Sql, _where)
    End Sub


    Public Shared Function L_fnObtenerMaxIdTabla(tabla As String, campo As String, where As String) As Long
        Dim Dt As DataTable = New DataTable
        Dt = D_MaximoDiconta(tabla, campo, where)

        If (Dt.Rows.Count > 0) Then
            If (Dt.Rows(0).Item(0).ToString.Equals("")) Then
                Return 0
            Else
                Return CLng(Dt.Rows(0).Item(0).ToString)
            End If
        Else
            Return 0
        End If
    End Function

#End Region

#Region "ZY005"
    Public Shared Function L_prModulosAll(_numi As String) As DataTable
        Dim _Tabla As DataTable

        Dim _listParam As New List(Of Datos.DParametro)

        _listParam.Add(New Datos.DParametro("@tipo", 3))
        _listParam.Add(New Datos.DParametro("@yfnumi", _numi))
        _listParam.Add(New Datos.DParametro("@uact", L_Usuario))

        _Tabla = D_ProcedimientoConParam("sp_dg_ZY005", _listParam)

        Return _Tabla
    End Function

#End Region

End Class
