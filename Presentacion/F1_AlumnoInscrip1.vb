Imports Logica.AccesoLogica
Imports Janus.Windows.GridEX
Imports DevComponents.DotNetBar
Imports System.IO
Imports DevComponents.DotNetBar.SuperGrid
Public Class F1_AlumnoInscrip1


#Region "Variable Globales"

    Dim RutaGlobal As String = gs_CarpetaRaiz
    Dim RutaTemporal As String = "C:\Temporal"
    Dim Modificado As Boolean = False
    Dim nameImg As String = "Default.jpg"
    Dim Socio As Boolean = False
    Public _nameButton As String

    Public Sucursal As Integer
    Public Alumno As String

#End Region

    '#Region "METODOS PRIVADOS"

    Private Sub _prIniciarTodo()

        Me.Text = "I N S C R I P C I Ó N   D E   A L U M N O S"
        '_PMIniciarTodo()
        '_prAsignarPermisos()

        _prCargarComboHorarioSucursal()

        Dim blah As Bitmap = My.Resources.cliente
        Dim ico As Icon = Icon.FromHandle(blah.GetHicon())
        Me.Icon = ico
        'btnModificar.Enabled = False
        'btnEliminar.Enabled = False
    End Sub

    Private Sub F1_AlumnoInscrip_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _prIniciarTodo()

    End Sub

    Private Sub _prCargarComboHorarioSucursal()
        Dim dt As New DataTable
        dt = L_prHorarioSucursal()

        With tbSuc
            .DropDownList.Columns.Clear()

            .DropDownList.Columns.Add("cbsuc").Width = 70
            .DropDownList.Columns("cbsuc").Caption = "COD"

            .DropDownList.Columns.Add("cadesc").Width = 200
            .DropDownList.Columns("cadesc").Caption = "descripcion".ToUpper

            .ValueMember = "cbsuc"
            .DisplayMember = "cadesc"
            .DataSource = dt
            .Refresh()
        End With

        'If gb_userTodasSuc = False Then
        '    tbSuc.Enabled = False
        'End If

        'tbSuc.Value = 11
        tbSuc.SelectedIndex = 0
    End Sub




    '    Public Sub _prEjecutarFiltroVehiculo()
    '        Dim CondicionEstado As Janus.Windows.GridEX.GridEXFilterCondition
    '        Dim compositeCondition As Janus.Windows.GridEX.GridEXFilterCondition
    '        CondicionEstado = New Janus.Windows.GridEX.GridEXFilterCondition(grVehiculo.RootTable.Columns("estado"), Janus.Windows.GridEX.ConditionOperator.GreaterThanOrEqualTo, 0)
    '        compositeCondition = New Janus.Windows.GridEX.GridEXFilterCondition()
    '        compositeCondition.AddCondition(CondicionEstado)
    '        grVehiculo.RootTable.FilterCondition = compositeCondition
    '    End Sub
    '    Public Sub _prCargarLengthTextBox()
    '        tbNSoc.MaxLength = 10

    '        tbNSoc.MaxLength = 10

    '        tbNombre.MaxLength = 30

    '        tbroseta.MaxLength = 10
    '        tbplaca.MaxLength = 10

    '    End Sub
    '    Private Sub _prCargarGridVehiculo(idCabecera As String)
    '        Dim dt As New DataTable
    '        dt = L_prClienteLVehiculo(idCabecera)
    '        grVehiculo.DataSource = dt
    '        grVehiculo.RetrieveStructure()
    '        grVehiculo.AlternatingColors = True
    '        grVehiculo.RowFormatStyle.Font = New Font("arial", 10)
    '        With grVehiculo.RootTable.Columns("lbnumi")
    '            .Width = 60
    '            .Caption = "CODIGO"

    '            .Visible = False

    '        End With

    '        With grVehiculo.RootTable.Columns("lbtip1_4")
    '            .Width = 60
    '            .Caption = "CODIGO"

    '            .Visible = False

    '        End With
    '        With grVehiculo.RootTable.Columns("lbmar")
    '            .Width = 90

    '            .Visible = False
    '        End With
    '        With grVehiculo.RootTable.Columns("lbmod")
    '            .Width = 90

    '            .Visible = False
    '        End With
    '        With grVehiculo.RootTable.Columns("lbplac")
    '            .Caption = "PLACA"

    '            .Width = 100
    '            .Visible = True


    '        End With
    '        With grVehiculo.RootTable.Columns("lbros")
    '            .Caption = "ROSETA"

    '            .Width = 100
    '            .Visible = True


    '        End With

    '        With grVehiculo.RootTable.Columns("lbimg")
    '            .Width = 90

    '            .Visible = False
    '        End With

    '        With grVehiculo.RootTable.Columns("lblin")
    '            .Width = 100
    '            .Caption = "LINCODIGO"

    '            .Visible = False

    '        End With

    '        With grVehiculo.RootTable.Columns("estado")

    '            .Width = 100
    '            .Visible = False



    '        End With
    '        With grVehiculo.RootTable.Columns("desmarc")
    '            .Caption = "MARCA"

    '            .Width = 200
    '            .Visible = True


    '        End With

    '        With grVehiculo.RootTable.Columns("descmod")
    '            .Caption = "MODELO"

    '            .Width = 200
    '            .Visible = True


    '        End With

    '        With grVehiculo
    '            .GroupByBoxVisible = False

    '            .VisualStyle = VisualStyle.Office2007

    '        End With
    '        grVehiculo.RootTable.HeaderFormatStyle.FontBold = TriState.True
    '    End Sub
    '    Private Sub _prCargarComboLibreria(mCombo As Janus.Windows.GridEX.EditControls.MultiColumnCombo, cod1 As String, cod2 As String)
    '        Dim dt As New DataTable
    '        dt = L_prLibreriaClienteLGeneral(cod1, cod2)
    '        With mCombo
    '            .DropDownList.Columns.Clear()
    '            .DropDownList.Columns.Add("cenum").Width = 70
    '            .DropDownList.Columns("cenum").Caption = "COD"
    '            .DropDownList.Columns.Add("cedesc1").Width = 200
    '            .DropDownList.Columns("cedesc1").Caption = "DESCRIPCION"
    '            .ValueMember = "cenum"
    '            .DisplayMember = "cedesc1"
    '            .DataSource = dt
    '            .Refresh()
    '        End With
    '    End Sub



    '    Public Shared Function imgToByteConverter(ByVal inImg As Image) As Byte()
    '        Dim imgCon As New ImageConverter()
    '        Return DirectCast(imgCon.ConvertTo(inImg, GetType(Byte())), Byte())
    '    End Function
    '    Private Sub _prCrearCarpetaImagenes()
    '        Dim rutaDestino As String = RutaGlobal + "\Imagenes\Imagenes ClienteL\"
    '        If System.IO.Directory.Exists(RutaGlobal + "\Imagenes\Imagenes ClienteL\") = False Then
    '            If System.IO.Directory.Exists(RutaGlobal + "\Imagenes") = False Then
    '                System.IO.Directory.CreateDirectory(RutaGlobal + "\Imagenes")
    '                If System.IO.Directory.Exists(RutaGlobal + "\Imagenes\Imagenes ClienteL") = False Then
    '                    System.IO.Directory.CreateDirectory(RutaGlobal + "\Imagenes\Imagenes ClienteL")
    '                End If
    '            Else
    '                If System.IO.Directory.Exists(RutaGlobal + "\Imagenes\Imagenes ClienteL") = False Then
    '                    System.IO.Directory.CreateDirectory(RutaGlobal + "\Imagenes\Imagenes ClienteL")
    '                End If
    '            End If
    '        End If
    '    End Sub
    '    Private Sub _prCrearCarpetaTemporal()
    '        If System.IO.Directory.Exists(RutaTemporal) = False Then
    '            System.IO.Directory.CreateDirectory(RutaTemporal)
    '        Else
    '            Try
    '                My.Computer.FileSystem.DeleteDirectory(RutaTemporal, FileIO.DeleteDirectoryOption.DeleteAllContents)
    '                My.Computer.FileSystem.CreateDirectory(RutaTemporal)
    '            Catch ex As Exception

    '            End Try
    '        End If

    '    End Sub
    '    Private Sub _prInsumos_ObtenerMayorDataSource(ByRef _mayor As Integer, ByRef _posicion As Integer, ByVal _lenght As Integer)

    '        _posicion = -1
    '        _mayor = 0
    '        If (_lenght >= 1) Then
    '            _posicion = 0
    '            _mayor = CType(JGrM_Buscador.DataSource, DataTable).Rows(0).Item("lanumi")
    '        End If
    '        For i As Integer = 1 To _lenght - 1 Step 1
    '            Dim a As Integer
    '            a = CType(JGrM_Buscador.DataSource, DataTable).Rows(i).Item("lanumi")
    '            If ((a >= _mayor)) Then
    '                _mayor = CType(JGrM_Buscador.DataSource, DataTable).Rows(i).Item("lanumi")
    '                _posicion = i

    '            End If
    '        Next


    '    End Sub

    '    Private Function _fnActionNuevo() As Boolean
    '        'Funcion que me devuelve True si esta en la actividad crear nuevo Tipo de Equipo
    '        Return tbNumi.Text.ToString.Equals("")
    '    End Function
    '    Private Function _fnCopiarImagenRutaDefinida() As String
    '        'copio la imagen en la carpeta del sistema
    '        Dim file As New OpenFileDialog()
    '        file.Filter = "Ficheros JPG o JPEG o PNG|*.jpg;*.jpeg;*.png" &
    '                      "|Ficheros GIF|*.gif" &
    '                      "|Ficheros BMP|*.bmp" &
    '                      "|Ficheros PNG|*.png" &
    '                      "|Ficheros TIFF|*.tif"
    '        If file.ShowDialog() = DialogResult.OK Then
    '            Dim ruta As String = file.FileName
    '            If file.CheckFileExists = True Then
    '                Dim img As New Bitmap(New Bitmap(ruta), 500, 300)
    '                Dim imgM As New Bitmap(New Bitmap(ruta), 180, 157)
    '                Dim Bin As New MemoryStream
    '                imgM.Save(Bin, System.Drawing.Imaging.ImageFormat.Jpeg)
    '                Dim a As Object = file.GetType.ToString
    '                If (_fnActionNuevo()) Then
    '                    Dim pos, mayor As Integer
    '                    Dim length As Integer = CType(JGrM_Buscador.DataSource, DataTable).Rows.Count
    '                    _prInsumos_ObtenerMayorDataSource(mayor, pos, length)
    '                    nameImg = "\Imagen_" + Str(mayor + 1) + ".jpg"

    '                    img.Save(RutaTemporal + nameImg, System.Drawing.Imaging.ImageFormat.Jpeg)
    '                    img.Dispose()
    '                Else
    '                    nameImg = "\Imagen_" + Str(tbNumi.Text) + ".jpg"

    '                    img.Save(RutaTemporal + nameImg, System.Drawing.Imaging.ImageFormat.Jpeg)
    '                    Modificado = True
    '                    img.Dispose()
    '                End If
    '            End If

    '            Return nameImg
    '        End If

    '        Return "default.jpg"
    '    End Function

    '    Private Sub _prAsignarPermisos()

    '        'Dim dtRolUsu As DataTable = L_prRolDetalleGeneral(gi_userRol, _nameButton)

    '        'Dim show As Boolean = dtRolUsu.Rows(0).Item("ycshow")
    '        'Dim add As Boolean = dtRolUsu.Rows(0).Item("ycadd")
    '        'Dim modif As Boolean = dtRolUsu.Rows(0).Item("ycmod")
    '        'Dim del As Boolean = dtRolUsu.Rows(0).Item("ycdel")

    '        'If add = False Then
    '        '    btnNuevo.Visible = False
    '        'End If
    '        'If modif = False Then
    '        '    btnModificar.Visible = False
    '        'End If
    '        'If del = False Then
    '        '    btnEliminar.Visible = False
    '        'End If

    '    End Sub

    '    Private Sub _fnMoverImagenRuta(Folder As String, name As String)
    '        'copio la imagen en la carpeta del sistema
    '        If (Not name.Equals("Default.jpg") And File.Exists(RutaTemporal + name)) Then


    '            Try
    '                My.Computer.FileSystem.CopyFile(RutaTemporal + name,
    '     Folder + name, overwrite:=True)
    '            Catch ex As Exception

    '            End Try
    '        End If

    '    End Sub


    '    Public Function _fnExisteClienteCI(_ci As String, ByRef _pos As Integer) As Boolean
    '        Dim length As Integer = CType(JGrM_Buscador.DataSource, DataTable).Rows.Count
    '        For i As Integer = 0 To length - 1
    '            Dim dataci As String = CType(JGrM_Buscador.DataSource, DataTable).Rows(i).Item("laci")
    '            If (_ci.Equals(dataci)) Then
    '                _pos = i
    '                Return True
    '            End If
    '        Next
    '        Return False
    '    End Function
    '    Private Sub _prClienteL_ObtenerMayorDataSource(ByRef _mayor As Integer, ByRef _posicion As Integer, ByVal _lenght As Integer)
    '        _posicion = -1
    '        _mayor = 0
    '        If (_lenght >= 1) Then
    '            _posicion = 0
    '            _mayor = CType(grVehiculo.DataSource, DataTable).Rows(0).Item("lblin")
    '        End If
    '        For i As Integer = 1 To _lenght - 1 Step 1
    '            Dim a As Integer
    '            a = CType(grVehiculo.DataSource, DataTable).Rows(i).Item("lblin")
    '            If ((a >= _mayor)) Then
    '                _mayor = CType(grVehiculo.DataSource, DataTable).Rows(i).Item("lblin")
    '                _posicion = i

    '            End If
    '        Next


    '    End Sub
    '   

    '    Public Function _prValidarCamposVehiculo() As Boolean
    '        Dim _ok As Boolean = True
    '        MEP.Clear()

    '        If tbplaca.Text = String.Empty Then
    '            tbplaca.BackColor = Color.Red
    '            MEP.SetError(tbplaca, "ingrese una placa de vehiculo!".ToUpper)
    '            _ok = False
    '        Else
    '            tbplaca.BackColor = Color.White
    '            MEP.SetError(tbplaca, "")
    '        End If


    '        If cbmarca.SelectedIndex < 0 Then
    '            cbmarca.BackColor = Color.Red
    '            MEP.SetError(cbmarca, "Seleccione una marca de vehiculo!".ToUpper)
    '            _ok = False
    '        Else
    '            cbmarca.BackColor = Color.White
    '            MEP.SetError(cbmarca, "")
    '        End If
    '        If cbmodelo.SelectedIndex < 0 Then
    '            cbmodelo.BackColor = Color.Red
    '            MEP.SetError(cbmodelo, "Seleccione un modelo de vehiculo!".ToUpper)
    '            _ok = False
    '        Else
    '            cbmodelo.BackColor = Color.White
    '            MEP.SetError(cbmodelo, "")
    '        End If
    '        MHighlighterFocus.UpdateHighlights()
    '        Return _ok
    '    End Function
    '    Public Function _fnOnbtenerMayorClienteLDataSource() As Integer
    '        Dim length As Integer = CType(JGrM_Buscador.DataSource, DataTable).Rows.Count
    '        If (length >= 1) Then
    '            Return CType(JGrM_Buscador.DataSource, DataTable).Rows(length - 1).Item("lanumi")
    '        Else
    '            Return 0
    '        End If
    '    End Function

    '    Public Function _fnModificar() As Boolean
    '        Return btnVehiculo.Text.ToString.Equals("MODIFICAR")
    '    End Function
    '    Public Function _prObtenerPosicionNumiVehiculo(ByVal _lblin As Integer) As Integer
    '        Dim length As Integer = CType(grVehiculo.DataSource, DataTable).Rows.Count
    '        For i As Integer = 0 To length - 1 Step 1
    '            Dim cqnumi As Integer = CType(grVehiculo.DataSource, DataTable).Rows(i).Item("lblin")
    '            If (cqnumi = _lblin) Then
    '                Return i
    '            End If
    '        Next
    '        Return -1

    '    End Function

    '    Public Sub _prVolverAtras()
    '        MPanelSup.Visible = True
    '        JGrM_Buscador.Visible = False
    '        GroupPanelBuscador.Visible = False
    '        MPanelSup.Dock = DockStyle.Top
    '        PanelSuperior.Visible = True
    '        ButtonX2.Visible = False
    '        ButtonX1.Visible = True
    '    End Sub



    '#End Region

    '#Region "METODOS SOBREESCRITOS"



    '    Public Overrides Sub _PMOHabilitar()
    '        tbNSoc.ReadOnly = False

    '        tbNombre.ReadOnly = False

    '        'cbTipo.ReadOnly = False

    '        tbFIngr.Enabled = True
    '        tbEstado.IsReadOnly = False

    '        nameImg = "Default.jpg"
    '        _prCrearCarpetaImagenes()
    '        _prCrearCarpetaTemporal()

    '        tbplaca.ReadOnly = False
    '        tbroseta.ReadOnly = False
    '        cbmarca.ReadOnly = False
    '        cbmodelo.ReadOnly = False
    '        btnVehiculo.Enabled = True

    '        grVehiculo.ContextMenuStrip.Enabled = True
    '        grVehiculo.ContextMenuStrip.ResumeLayout()
    '        ButtonX1.Visible = False



    '    End Sub
    '    Public Overrides Sub _PMOInhabilitar()
    '        tbNumi.ReadOnly = True
    '        tbNSoc.ReadOnly = True

    '        tbNombre.ReadOnly = True

    '        tbFIngr.Enabled = False
    '        tbEstado.IsReadOnly = True

    '        tbplaca.ReadOnly = True
    '        tbroseta.ReadOnly = True
    '        cbmarca.ReadOnly = True
    '        cbmodelo.ReadOnly = True
    '        btnVehiculo.Enabled = False
    '        grVehiculo.AllowEdit = InheritableBoolean.False
    '        grVehiculo.ContextMenuStrip.Enabled = False
    '        ButtonX1.Visible = True

    '        lbTipoCliente.Visible = True

    '    End Sub
    '    Public Overrides Sub _PMOHabilitarFocus()
    '        With MHighlighterFocus
    '            .SetHighlightOnFocus(tbNSoc, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)

    '            .SetHighlightOnFocus(tbNombre, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)



    '            '.SetHighlightOnFocus(cbTipo, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)

    '            .SetHighlightOnFocus(tbFIngr, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
    '            .SetHighlightOnFocus(tbEstado, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
    '            .SetHighlightOnFocus(tbplaca, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
    '            .SetHighlightOnFocus(tbroseta, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
    '            .SetHighlightOnFocus(cbmodelo, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
    '            .SetHighlightOnFocus(cbmarca, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)

    '        End With
    '    End Sub

    '    Public Overrides Sub _PMOLimpiarErrores()

    '        MEP.Clear()
    '        tbNSoc.BackColor = Color.White

    '        tbNombre.BackColor = Color.White

    '        'cbTipo.BackColor = Color.White

    '        tbplaca.BackColor = Color.White
    '        tbroseta.BackColor = Color.White
    '        cbmodelo.BackColor = Color.White
    '        cbmarca.BackColor = Color.White

    '    End Sub
    '    Public Overrides Function _PMOValidarCampos() As Boolean
    '        Dim _ok As Boolean = True
    '        MEP.Clear()

    '        'If tbCi.Text = String.Empty Then
    '        '    tbCi.BackColor = Color.Red
    '        '    MEP.SetError(tbCi, "ingrese Cedula de Identidad!".ToUpper)
    '        '    _ok = False
    '        'Else
    '        '    tbCi.BackColor = Color.White
    '        '    MEP.SetError(tbCi, "")
    '        'End If

    '        'If tbFnac.Text = String.Empty Then
    '        '    tbFnac.BackColor = Color.Red
    '        '    MEP.SetError(tbFnac, "Seleccione su fecha de nacimiento!".ToUpper)
    '        '    _ok = False
    '        'Else
    '        '    tbFnac.BackColor = Color.White
    '        '    MEP.SetError(tbFnac, "")
    '        'End If

    '        If tbNombre.Text = String.Empty Then
    '            tbNombre.BackColor = Color.Red
    '            MEP.SetError(tbNombre, "ingrese su Nombre Completo!".ToUpper)
    '            _ok = False
    '        Else
    '            tbNombre.BackColor = Color.White
    '            MEP.SetError(tbNombre, "")
    '        End If


    '        'If tbDir.Text = String.Empty Then
    '        '    tbDir.BackColor = Color.Red
    '        '    MEP.SetError(tbDir, "ingrese su Direccion de domicilio o lugar donde vive!".ToUpper)
    '        '    _ok = False
    '        'Else
    '        '    tbDir.BackColor = Color.White
    '        '    MEP.SetError(tbDir, "")
    '        'End If
    '        'If tbEmail.Text = String.Empty Then
    '        '    tbEmail.BackColor = Color.Red
    '        '    MEP.SetError(tbEmail, "ingrese su direccion de correo electronico!".ToUpper)
    '        '    _ok = False
    '        'Else
    '        '    tbEmail.BackColor = Color.White
    '        '    MEP.SetError(tbEmail, "")
    '        'End If
    '        'If tbTel1.Text = String.Empty Then
    '        '    tbTel1.BackColor = Color.Red
    '        '    MEP.SetError(tbTel1, "ingrese su numero de Telefono o Celular!".ToUpper)
    '        '    _ok = False
    '        'Else
    '        '    tbTel1.BackColor = Color.White
    '        '    MEP.SetError(tbTel1, "")
    '        'End If


    '        MHighlighterFocus.UpdateHighlights()
    '        Return _ok
    '    End Function
    '    Public Overrides Function _PMOGetListEstructuraBuscador() As List(Of Modelos.Celda)
    '        Dim listEstCeldas As New List(Of Modelos.Celda)
    '        listEstCeldas.Add(New Modelos.Celda("lanumi", True, "ID", 50))
    '        listEstCeldas.Add(New Modelos.Celda("latipo", False))
    '        listEstCeldas.Add(New Modelos.Celda("cedesc1", True, "TIPO CLIENTE", 130))
    '        listEstCeldas.Add(New Modelos.Celda("lansoc", True, "NRO SOCIO", 90))
    '        listEstCeldas.Add(New Modelos.Celda("lafing", False, "FECHA DE INGRESO", 200))
    '        listEstCeldas.Add(New Modelos.Celda("lafnac", True, "F. NACIMIENTO", 120))
    '        listEstCeldas.Add(New Modelos.Celda("lanom", True, "NOMBRES", 250))
    '        listEstCeldas.Add(New Modelos.Celda("laapat", False, "APELLIDO PATERNO", 150))
    '        listEstCeldas.Add(New Modelos.Celda("laamat", False, "APELLIDO MATERNO", 150))

    '        listEstCeldas.Add(New Modelos.Celda("ladir", True, "DIRECCION", 300))
    '        listEstCeldas.Add(New Modelos.Celda("laemail", False, "CORREO ELECTRONICO", 150))
    '        listEstCeldas.Add(New Modelos.Celda("laci", True, "CI", 90))
    '        listEstCeldas.Add(New Modelos.Celda("lafot", False))
    '        listEstCeldas.Add(New Modelos.Celda("img", False, "IMAGEN", 150))

    '        listEstCeldas.Add(New Modelos.Celda("laobs", False, "OBSERVACION", 100))
    '        listEstCeldas.Add(New Modelos.Celda("laest", False))
    '        listEstCeldas.Add(New Modelos.Celda("estado", True, "ESTADO", 80))
    '        listEstCeldas.Add(New Modelos.Celda("latelf1", True, "TELEFONO 1", 117))
    '        listEstCeldas.Add(New Modelos.Celda("latelf2", False, "TELEFONO 2", 100))

    '        listEstCeldas.Add(New Modelos.Celda("lafact", False))
    '        listEstCeldas.Add(New Modelos.Celda("lahact", False))
    '        listEstCeldas.Add(New Modelos.Celda("lauact", False))

    '        Return listEstCeldas


    '    End Function
    '    Public Overrides Function _PMOGetTablaBuscador() As DataTable

    '        Dim dtBuscador As DataTable = L_prClienteLGeneral(gi_LibLAVADERO, gi_LibLAVADEROClie)


    '        Return dtBuscador
    '    End Function



    '    Public Overrides Sub _PMOMostrarRegistro(_N As Integer)
    '        JGrM_Buscador.Row = _MPos


    '        With JGrM_Buscador
    '            tbNSoc.Text = .GetValue("lansoc").ToString

    '            tbNombre.Text = .GetValue("lanom").ToString

    '            tbNumi.Text = .GetValue("lanumi").ToString
    '            lbFecha.Text = CType(.GetValue("lafact"), Date).ToString("dd/MM/yyyy")
    '            lbHora.Text = .GetValue("lahact").ToString
    '            lbUsuario.Text = .GetValue("lauact").ToString



    '            'cbTipo.Value = .GetValue("latipo")

    '            tbFIngr.Text = .GetValue("lafing")
    '        End With
    '        Dim est As Integer = JGrM_Buscador.GetValue("laest")
    '        If (est = 1) Then
    '            tbEstado.Value = True
    '        Else
    '            tbEstado.Value = False

    '        End If
    '        Dim name As String = JGrM_Buscador.GetValue("lafot")

    '        If (tbNSoc.Text <> String.Empty And tbNSoc.Text > 0) Then
    '            btnModificar.Enabled = False
    '            btnEliminar.Enabled = False

    '        Else
    '            btnModificar.Enabled = True
    '            btnEliminar.Enabled = True

    '        End If

    '        LblPaginacion.Text = Str(_MPos + 1) + "/" + JGrM_Buscador.RowCount.ToString

    '        _prCargarGridVehiculo(tbNumi.Text)
    '        ButtonX1.Visible = True


    '    End Sub
    '    Public Overrides Function _PMOGrabarRegistro() As Boolean


    '        'Dim tipo As Integer = 1
    '        'Dim nsoc As Integer = 1


    '        'Dim res As Boolean = L_prClienteLGrabar(tbNumi.Text, cbTipoCliente.Value, tbNSoc.Text, tbFIngr.Value.ToString("yyyy/MM/dd"), tbFnac.Value.ToString("yyyy/MM/dd"), tbNombre.Text, "", "", tbDir.Text, tbEmail.Text, tbCi.Text, nameImg, tbObs.Text, IIf(tbEstado.Value = True, 1, 0), tbTel1.Text, tbTel2.Text, CType(grVehiculo.DataSource, DataTable))
    '        'If res Then

    '        '    Modificado = False

    '        '    _fnMoverImagenRuta(RutaGlobal + "\Imagenes\Imagenes ClienteL", nameImg)
    '        '    ToastNotification.Show(Me, "Codigo de Cliente ".ToUpper + tbNumi.Text + " Grabado con Exito.".ToUpper, My.Resources.GRABACION_EXITOSA, 5000, eToastGlowColor.Green, eToastPosition.TopCenter)
    '        'End If
    '        'Return res

    '    End Function
    '    Public Overrides Function _PMOModificarRegistro() As Boolean
    '        'Dim tipo As Integer = 1
    '        'Dim nsoc As Integer = 1
    '        'Dim res As Boolean
    '        'Dim b As Boolean = Modificado
    '        'Dim nameImage As String = JGrM_Buscador.GetValue("lafot")
    '        'If (Modificado = False) Then

    '        '    res = L_prClienteLModificar(tbNumi.Text, cbTipoCliente.Value, tbNSoc.Text, tbFIngr.Value.ToString("yyyy/MM/dd"), tbFnac.Value.ToString("yyyy/MM/dd"), tbNombre.Text, "", "", tbDir.Text, tbEmail.Text, tbCi.Text, nameImage, tbObs.Text, IIf(tbEstado.Value = True, 1, 0), tbTel1.Text, tbTel2.Text, CType(grVehiculo.DataSource, DataTable))
    '        'Else
    '        '    res = L_prClienteLModificar(tbNumi.Text, tipo, tbNSoc.Text, tbFIngr.Value.ToString("yyyy/MM/dd"), tbFnac.Value.ToString("yyyy/MM/dd"), tbNombre.Text, "", "", tbDir.Text, tbEmail.Text, tbCi.Text, nameImg, tbObs.Text, IIf(tbEstado.Value = True, 1, 0), tbTel1.Text, tbTel2.Text,
    '        '                                CType(grVehiculo.DataSource, DataTable))

    '        'End If
    '        'If res Then


    '        '    If (Modificado = True) Then
    '        '        _fnMoverImagenRuta(RutaGlobal + "\Imagenes\Imagenes ClienteL", nameImg)
    '        '        Modificado = False
    '        '    End If

    '        '    ToastNotification.Show(Me, "Codigo de Cliente ".ToUpper + tbNumi.Text + " modificado con Exito.".ToUpper, My.Resources.GRABACION_EXITOSA, 5000, eToastGlowColor.Green, eToastPosition.TopCenter)
    '        'End If
    '        'Return res
    '    End Function
    '    Public Sub _PrEliminarImage()
    '        If (Not (_fnActionNuevo()) And (File.Exists(RutaGlobal + "\Imagenes\Imagenes ClienteL\Imagen_ " + tbNumi.Text + ".jpg"))) Then



    '            Try
    '                My.Computer.FileSystem.DeleteFile(RutaGlobal + "\Imagenes\Imagenes ClienteL\Imagen_ " + tbNumi.Text + ".jpg")

    '            Catch ex As Exception

    '            End Try

    '        End If
    '    End Sub
    '    Public Overrides Sub _PMOEliminarRegistro()
    '        Dim info As New TaskDialogInfo("¿esta seguro de eliminar el registro?".ToUpper, eTaskDialogIcon.Delete, "advertencia".ToUpper, "mensaje principal".ToUpper, eTaskDialogButton.Yes Or eTaskDialogButton.Cancel, eTaskDialogBackgroundColor.Blue)
    '        Dim result As eTaskDialogResult = TaskDialog.Show(info)
    '        If result = eTaskDialogResult.Yes Then
    '            Dim mensajeError As String = ""
    '            Dim res As Boolean = L_prClienteLBorrar(tbNumi.Text, mensajeError)
    '            If res Then
    '                _PrEliminarImage()

    '                ToastNotification.Show(Me, "Codigo de Cliente ".ToUpper + tbNumi.Text + " eliminado con Exito.".ToUpper, My.Resources.GRABACION_EXITOSA, 5000, eToastGlowColor.Green, eToastPosition.TopCenter)
    '                _PMFiltrar()
    '            Else
    '                ToastNotification.Show(Me, mensajeError, My.Resources.WARNING, 8000, eToastGlowColor.Red, eToastPosition.TopCenter)
    '            End If
    '        End If
    '    End Sub
    '#End Region


    '#Region "Eventos del Formulario"





    '    Private Sub Button2_Click(sender As Object, e As EventArgs)
    '        _fnCopiarImagenRutaDefinida()
    '        cbmarca.Focus()
    '    End Sub

    '    Private Sub tbNSoc_KeyPress(sender As Object, e As KeyPressEventArgs)
    '        If Char.IsDigit(e.KeyChar) Then
    '            e.Handled = False
    '        ElseIf Char.IsControl(e.KeyChar) Then
    '            e.Handled = False
    '        ElseIf Char.IsSymbol(e.KeyChar) Then
    '            e.Handled = False
    '        ElseIf Char.IsSeparator(e.KeyChar) Then
    '            e.Handled = False
    '        ElseIf Char.IsWhiteSpace(e.KeyChar) Then
    '            e.Handled = False
    '        Else
    '            e.Handled = True
    '        End If
    '        tbNSoc.Text = Trim(Replace(tbNSoc.Text, "  ", " "))
    '        tbNSoc.Select(tbNSoc.Text.Length, 0)
    '    End Sub


    '    Private Sub tbTel1_KeyPress(sender As Object, e As KeyPressEventArgs)
    '        If Char.IsDigit(e.KeyChar) Then
    '            e.Handled = False
    '        ElseIf Char.IsControl(e.KeyChar) Then
    '            e.Handled = False
    '        ElseIf Char.IsSymbol(e.KeyChar) Then
    '            e.Handled = False
    '        ElseIf Char.IsSeparator(e.KeyChar) Then
    '            e.Handled = False
    '        ElseIf Char.IsWhiteSpace(e.KeyChar) Then
    '            e.Handled = False
    '        Else
    '            e.Handled = True
    '        End If



    '    End Sub

    '    Private Sub tbTel2_KeyPress(sender As Object, e As KeyPressEventArgs)
    '        If Char.IsDigit(e.KeyChar) Then
    '            e.Handled = False
    '        ElseIf Char.IsControl(e.KeyChar) Then
    '            e.Handled = False
    '        ElseIf Char.IsSymbol(e.KeyChar) Then
    '            e.Handled = False
    '        ElseIf Char.IsSeparator(e.KeyChar) Then
    '            e.Handled = False
    '        ElseIf Char.IsWhiteSpace(e.KeyChar) Then
    '            e.Handled = False
    '        Else
    '            e.Handled = True
    '        End If

    '    End Sub




    '    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
    '        Dim pos As Integer = grVehiculo.Row
    '        If pos >= 0 And pos <= grVehiculo.RowCount - 1 Then

    '            Dim PosicionDato As Integer
    '            PosicionDato = _prObtenerPosicionNumiVehiculo(grVehiculo.GetValue("lblin"))


    '            tbplaca.Text = CType(grVehiculo.DataSource, DataTable).Rows(PosicionDato).Item("lbplac")
    '            tbroseta.Text = CType(grVehiculo.DataSource, DataTable).Rows(PosicionDato).Item("lbros")
    '            cbmarca.Value = CType(grVehiculo.DataSource, DataTable).Rows(PosicionDato).Item("lbmar")
    '            cbmodelo.Value = CType(grVehiculo.DataSource, DataTable).Rows(PosicionDato).Item("lbmod")


    '        End If
    '        btnVehiculo.Text = "MODIFICAR"
    '        Dim img As New Bitmap(New Bitmap(My.Resources.edit))
    '        btnVehiculo.Image = img
    '        btnCancelar.Visible = True

    '    End Sub

    '    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
    '        Dim pos As Integer = grVehiculo.Row
    '        If pos >= 0 And pos <= grVehiculo.RowCount - 1 Then
    '            Dim estado As Integer
    '            Dim PosicionDato As Integer
    '            PosicionDato = _prObtenerPosicionNumiVehiculo(grVehiculo.GetValue("lblin"))
    '            estado = CType(grVehiculo.DataSource, DataTable).Rows(PosicionDato).Item("estado")
    '            If estado = 1 Or estado = 2 Then ' si estoy eliminando una fila ya guardada le cambio el estado y lo oculto de la grilla
    '                CType(grVehiculo.DataSource, DataTable).Rows(PosicionDato).Item("estado") = -1


    '            Else 'si estoy eliminando una fila nueva, cambio el estado a -2


    '                CType(grVehiculo.DataSource, DataTable).Rows(PosicionDato).Item("estado") = -2

    '            End If

    '        End If
    '        _prEjecutarFiltroVehiculo()

    '    End Sub


    '    Private Sub btnCancelar_Click(sender As Object, e As EventArgs)
    '        _prLimpiarVehiculo()
    '        btnCancelar.Visible = False
    '        btnVehiculo.Text = "AGREGAR"
    '        Dim img As New Bitmap(My.Resources.success)
    '        btnVehiculo.Image = img
    '    End Sub

    '    Private Sub tbroseta_KeyPress(sender As Object, e As KeyPressEventArgs)
    '        If Char.IsDigit(e.KeyChar) Then
    '            e.Handled = False
    '        ElseIf Char.IsControl(e.KeyChar) Then
    '            e.Handled = False
    '        ElseIf Char.IsSymbol(e.KeyChar) Then
    '            e.Handled = False
    '        ElseIf Char.IsSeparator(e.KeyChar) Then
    '            e.Handled = False
    '        ElseIf Char.IsWhiteSpace(e.KeyChar) Then
    '            e.Handled = False
    '        Else
    '            e.Handled = True
    '        End If

    '        tbroseta.Text = Trim(Replace(tbroseta.Text, "  ", " "))
    '        tbroseta.Select(tbroseta.Text.Length, 0)
    '    End Sub

    '    Private Sub ButtonX1_Click_1(sender As Object, e As EventArgs) Handles ButtonX1.Click
    '        GroupPanelBuscador.Visible = True
    '        GroupPanelBuscador.Enabled = True
    '        JGrM_Buscador.Enabled = True
    '        JGrM_Buscador.Visible = True
    '        JGrM_Buscador.RemoveFilters()
    '        JGrM_Buscador.Refresh()


    '        JGrM_Buscador.Focus()
    '        JGrM_Buscador.MoveTo(JGrM_Buscador.FilterRow)
    '        JGrM_Buscador.Col = 6




    '        MPanelSup.Visible = False
    '        PanelSuperior.Visible = False
    '        ButtonX2.Visible = True
    '        ButtonX1.Visible = False


    '    End Sub

    '    Private Sub ButtonX2_Click(sender As Object, e As EventArgs) Handles ButtonX2.Click
    '        _prVolverAtras()

    '    End Sub




    '    Private Sub JGrM_Buscador_DoubleClick(sender As Object, e As EventArgs) Handles JGrM_Buscador.DoubleClick
    '        _prVolverAtras()

    '    End Sub

    '    Private Sub cbmarca_ValueChanged(sender As Object, e As EventArgs)
    '        If cbmarca.SelectedIndex < 0 And cbmarca.Text <> String.Empty Then
    '            BtnMarca.Visible = True
    '        Else
    '            BtnMarca.Visible = False
    '        End If
    '    End Sub

    '    Private Sub BtnMarca_Click(sender As Object, e As EventArgs)
    '        Dim numi As String = ""

    '        If L_prLibreriaGrabar(numi, gi_LibVEHICULO, gi_LibVEHIMarca, cbmarca.Text, "") Then
    '            _prCargarComboLibreria(cbmarca, gi_LibVEHICULO, gi_LibVEHIMarca)
    '            cbmarca.SelectedIndex = CType(cbmarca.DataSource, DataTable).Rows.Count - 1
    '        End If
    '    End Sub

    '    Private Sub cbmodelo_ValueChanged(sender As Object, e As EventArgs)
    '        If cbmodelo.SelectedIndex < 0 And cbmodelo.Text <> String.Empty Then
    '            BtnModelo.Visible = True
    '        Else
    '            BtnModelo.Visible = False
    '        End If
    '    End Sub

    '    Private Sub BtnModelo_Click(sender As Object, e As EventArgs)
    '        Dim numi As String = ""

    '        If L_prLibreriaGrabar(numi, gi_LibVEHICULO, gi_LibVEHIModelo, cbmodelo.Text, "") Then
    '            _prCargarComboLibreria(cbmodelo, gi_LibVEHICULO, gi_LibVEHIModelo)
    '            cbmodelo.SelectedIndex = CType(cbmodelo.DataSource, DataTable).Rows.Count - 1
    '        End If
    '    End Sub

    '    Private Sub VehiculoGr_Click(sender As Object, e As EventArgs)

    '    End Sub

    '#End Region

End Class