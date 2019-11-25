Imports Logica.AccesoLogica
Imports Janus.Windows.GridEX
Imports System.IO
Imports DevComponents.DotNetBar

Public Class F_SocioVehiculo


#Region "Atributos"

    'Datos del socio
    Private inCodigo As Integer = 1
    Private stNombre As String = "COSME FULANITO"
    Private stFoto As String

    Property codigoSocio
        Get
            Return inCodigo
        End Get
        Set(value)
            inCodigo = value
        End Set
    End Property

    Property nombreSocio
        Get
            Return stNombre
        End Get
        Set(value)
            stNombre = value
        End Set
    End Property

    Property rutaFotoSocio
        Get
            Return stFoto
        End Get
        Set(value)
            stFoto = value
        End Set
    End Property

#End Region

#Region "Variables globales"

    Private dtVehiculos As DataTable

    Dim mstream As MemoryStream

    Private inDuracion As Byte = 5
    Private stRutaRaiz As String = gs_CarpetaRaiz + "\Imagenes\Socio\Vehiculo"
    Private rutaImagenVehiculo As String = ""
    Private vlImagen As CImagen = Nothing
    Private ftTitulo As Font = New Font("Arial", gi_userFuente + 1, FontStyle.Bold)
    Private ftDetalle As Font = New Font("Arial", gi_userFuente, FontStyle.Regular)

    Private boFlat As Boolean = False
#End Region

#Region "Eventos"

    Private Sub F_SocioVehiculo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _prInicio()
    End Sub

#End Region

#Region "Metodos"

    Private Sub _prInicio()
        'Abrir conexion
        If (Not gb_ConexionAbierta) Then
            L_prAbrirConexion("localhost", "sersolinf", "321", "DBDies")
        End If

        _prValidarRequisitos()

        rlTitulo.Text = "VEHICULOS DEL SOCIO : " + nombreSocio
        rlTitulo.Font = New Font("Arial", gi_userFuente + 6)

        boFlat = False
        _armarGrillas()
        boFlat = True

        If (dgjVehiculos.GetRows.Count > 0) Then
            If (dgjVehiculos.GetRows.Count = 1) Then
                rutaImagenVehiculo = stRutaRaiz + "\Socio_" + dgjVehiculos.GetRow(0).Cells("cinumi").Value.ToString + "\Vehiculo_" + dgjVehiculos.GetRow(0).Cells("cilin").Value.ToString
                If (Not Directory.Exists(rutaImagenVehiculo)) Then
                    Directory.CreateDirectory(rutaImagenVehiculo)
                End If
                Dim files As String() = Directory.GetFiles(rutaImagenVehiculo)
                    If (files.Count > 0) Then
                        _prPonerImagen(Nothing, files(0))
                    Else
                        _prPonerImagen(My.Resources.imageDefault)
                    End If
                Else
                    dgjVehiculos.Row = 1
                dgjVehiculos.Row = 0
            End If

        End If

    End Sub

#End Region

    Private Sub _armarGrillas()
        _armarGrillaVehiculos(codigoSocio.ToString)
    End Sub

    Private Sub _armarGrillaVehiculos(p1 As String)
        dtVehiculos = New DataTable
        dtVehiculos = L_fnSocioVehiculosImagen(codigoSocio.ToString)

        _prPonerImagenDataSource(dtVehiculos)

        'cinumi, cimar, marca, cimod, modelo, ciplac, ciros, 
        'quanImg, viewImg, addImg, editImg, delImg, cilin

        dgjVehiculos.BoundMode = Janus.Data.BoundMode.Bound
        dgjVehiculos.DataSource = dtVehiculos
        dgjVehiculos.RetrieveStructure()

        'dar formato a las columnas
        With dgjVehiculos.RootTable.Columns("cinumi") '0
            .Visible = False
        End With

        With dgjVehiculos.RootTable.Columns("cimar") '1
            .Visible = False
        End With

        With dgjVehiculos.RootTable.Columns("marca") '2
            .Caption = "Marca"
            .Width = 80
            .HeaderStyle.Font = ftTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = ftDetalle
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = True
        End With

        With dgjVehiculos.RootTable.Columns("cimod") '3
            .Visible = False
        End With

        With dgjVehiculos.RootTable.Columns("modelo") '4
            .Caption = "Modelo"
            .Width = 80
            .HeaderStyle.Font = ftTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = ftDetalle
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = True
        End With

        With dgjVehiculos.RootTable.Columns("ciplac") '5
            .Caption = "Placa"
            .Width = 60
            .HeaderStyle.Font = ftTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = ftDetalle
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = True
        End With

        With dgjVehiculos.RootTable.Columns("ciros") '6
            .Caption = "Roseta"
            .Width = 50
            .HeaderStyle.Font = ftTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = ftDetalle
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = True
        End With

        With dgjVehiculos.RootTable.Columns("quanImg") '7
            .Caption = "Cantidad"
            .Width = 60
            .HeaderStyle.Font = ftTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = ftDetalle
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = False
        End With

        With dgjVehiculos.RootTable.Columns("viewImg") '8
            .Caption = "Ver"
            .Width = 42
            .HeaderStyle.Font = ftTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = ftDetalle
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .Visible = False
        End With

        With dgjVehiculos.RootTable.Columns("addImg") '9
            .Caption = "Add"
            .Width = 42
            .HeaderStyle.Font = ftTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = ftDetalle
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .Visible = True
        End With

        With dgjVehiculos.RootTable.Columns("editImg") '10
            .Caption = "Edit"
            .Width = 42
            .HeaderStyle.Font = ftTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = ftDetalle
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .Visible = False
        End With

        With dgjVehiculos.RootTable.Columns("delImg") '11
            .Caption = "Del"
            .Width = 42
            .HeaderStyle.Font = ftTitulo
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.Font = ftDetalle
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .Visible = False
        End With

        With dgjVehiculos.RootTable.Columns("cilin") '12
            .Caption = "Lin"
            .Width = 40
            .Visible = False
        End With

        'Habilitar Filtradores
        With dgjVehiculos
            .GroupByBoxVisible = False
            '.FilterRowFormatStyle.BackColor = Color.Blue
            .DefaultFilterRowComparison = FilterConditionOperator.Contains
            '.FilterMode = FilterMode.Automatic
            .FilterRowUpdateMode = FilterRowUpdateMode.WhenValueChanges
            'Diseño de la tabla
            .VisualStyle = VisualStyle.Office2007
            .SelectionMode = SelectionMode.MultipleSelection
            .AlternatingColors = True
            .RecordNavigator = True
            .AllowEdit = InheritableBoolean.False
        End With
    End Sub

    Private Sub _prPonerImagenDataSource(ByRef dt As DataTable)
        Dim msView As System.Byte()
        Dim msAdd As System.Byte()
        Dim msEdit As System.Byte()
        Dim msDel As System.Byte()
        msView = _fnBytesArchivo(My.Resources.I512x512_image_view, 40, 40) '130=Ancho, 80=Alto
        msAdd = _fnBytesArchivo(My.Resources.I512x512_image_add, 40, 40) '130=Ancho, 80=Alto
        msEdit = _fnBytesArchivo(My.Resources.I512x512_image_edit, 40, 40) '130=Ancho, 80=Alto
        msDel = _fnBytesArchivo(My.Resources.I512x512_image_remove, 40, 40) '130=Ancho, 80=Alto

        For Each f As DataRow In dt.Rows
            f.Item("viewImg") = msView
            f.Item("addImg") = msAdd
            f.Item("editImg") = msEdit
            f.Item("delImg") = msDel
        Next

        mstream.Dispose()
    End Sub

    Private Function _fnBytesArchivo(img As Bitmap, ancho As Integer, alto As Integer) As Object
        mstream = New MemoryStream()
        Dim img2 As New Bitmap(img, ancho, alto)
        img2.Save(mstream, System.Drawing.Imaging.ImageFormat.Png)
        Return mstream.ToArray()
    End Function

    Private Sub dgjVehiculos_MouseClick(sender As Object, e As MouseEventArgs) Handles dgjVehiculos.MouseClick
        If (dgjVehiculos.CurrentColumn.Key.Equals("addImg")) Then
            _prValidarRuta(rutaImagenVehiculo)
            Dim files As String() = Directory.GetFiles(rutaImagenVehiculo)
            If (files.Count > 0) Then
                ToastNotification.Show(Me,
                                       "el vehiculo ya tiene foto.".ToUpper,
                                       My.Resources.INFORMATION,
                                       inDuracion * 1000,
                                       eToastGlowColor.Red,
                                       eToastPosition.TopCenter)

            Else
                _prAddImageVehiculo(dgjVehiculos.GetValue("cilin"))
            End If
        End If
    End Sub

    Private Sub _prAddImageVehiculo(lin As Integer)
        OfdFoto.InitialDirectory = "C:\Users\" + Environment.UserName + "\Pictures"
        OfdFoto.Filter = "Imagen|*.jpg;*.jpeg;*.png;*.bmp"
        OfdFoto.FilterIndex = 1
        If (OfdFoto.ShowDialog() = DialogResult.OK) Then
            vlImagen = New CImagen(OfdFoto.SafeFileName, OfdFoto.FileName, 0)
            pbImagen.SizeMode = PictureBoxSizeMode.StretchImage
            pbImagen.Load(vlImagen.getImagen())
            _prGuardarImagen(vlImagen.direccion, lin)
        End If
    End Sub

    Private Sub _prGuardarImagen(direccion As String, lin As Integer)
        File.Copy(direccion, rutaImagenVehiculo + "\" + lin.ToString + "_" + _fnObtenerCodigoUnico() + ".jpg", True)
    End Sub

    Private Sub _prValidarRequisitos()
        'validar ruta de imagenes de vehiculos
        If (Not Directory.Exists(stRutaRaiz)) Then
            Directory.CreateDirectory(stRutaRaiz)
        End If

    End Sub

    Private Function _fnObtenerCodigoUnico() As String
        Return Now.Year.ToString("0000") + Now.Month.ToString("00") + Now.Day.ToString("00") +
            Now.Hour.ToString("00") + Now.Minute.ToString("00") + Now.Second.ToString("00") + Now.Millisecond.ToString("00")
    End Function

    Private Sub dgjVehiculos_SelectionChanged(sender As Object, e As EventArgs) Handles dgjVehiculos.SelectionChanged
        If (boFlat) Then
            rutaImagenVehiculo = stRutaRaiz + "\Socio_" + dgjVehiculos.GetValue("cinumi").ToString + "\Vehiculo_" + dgjVehiculos.GetValue("cilin").ToString
            pbImagen.SizeMode = PictureBoxSizeMode.StretchImage
            If (Directory.Exists(rutaImagenVehiculo)) Then
                Dim files As String() = Directory.GetFiles(rutaImagenVehiculo)
                If (files.Count > 0) Then
                    _prPonerImagen(Nothing, files(0))
                Else
                    _prPonerImagen(My.Resources.imageDefault)
                End If
            Else
                _prPonerImagen(My.Resources.imageDefault)
            End If
        End If
    End Sub

    Private Sub _prPonerImagen(Optional img As Bitmap = Nothing, Optional ruta As String = "")
        If (IsNothing(img)) Then
            pbImagen.Load(ruta)
        Else
            pbImagen.Image = img
        End If
    End Sub

    Private Sub _prValidarRuta(ruta As String)
        If (Not Directory.Exists(ruta)) Then
            Directory.CreateDirectory(ruta)
        End If
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub
End Class