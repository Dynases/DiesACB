Imports Logica.AccesoLogica
Imports Janus.Windows.GridEX
Imports DevComponents.DotNetBar
Imports System.IO
Imports DevComponents.DotNetBar.SuperGrid


Public Class F1_AlumnoInscrip
#Region "Variable Globales"
    Public _nameButton As String

    Public Sucursal As Integer
    Public CodAlumno As Integer
    Public Alumno As String

#End Region

    Private Sub F1_AlumnoInscrip_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _prIniciarTodo()
    End Sub
    Private Sub _prIniciarTodo()
        Me.Text = "I N S C R I P C I Ó N   D E   A L U M N O S"
        Dim blah As Bitmap = My.Resources.cliente
        Dim ico As Icon = Icon.FromHandle(blah.GetHicon())
        Me.Icon = ico
        '_prAsignarPermisos()
        _prCargarComboHorarioSucursal()

        tbAlumno.Text = Alumno

        _prCargarComboServicios(Sucursal)


        'btnModificar.Enabled = False
        'btnEliminar.Enabled = False
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

    Private Sub _prCargarComboServicios(Suc As Integer)
        Dim dt As New DataTable
        dt = L_prListarServicios(Suc)

        With cbServicio
            .DropDownList.Columns.Clear()

            .DropDownList.Columns.Add("ednumi").Width = 70
            .DropDownList.Columns("ednumi").Caption = "COD"

            .DropDownList.Columns.Add("eddesc").Width = 200
            .DropDownList.Columns("eddesc").Caption = "descripcion".ToUpper

            .ValueMember = "ednumi"
            .DisplayMember = "eddesc"
            .DataSource = dt
            .Refresh()
        End With

        cbServicio.SelectedIndex = 0
    End Sub

    Private Sub tbNFactura_KeyDown(sender As Object, e As KeyEventArgs) Handles tbNFactura.KeyDown
        If (_fnAccesible()) Then
            If e.KeyData = Keys.Control + Keys.Enter Then
                Dim dt As DataTable
                dt = L_prListarFacturas()

                Dim listEstCeldas As New List(Of Modelos.Celda)
                listEstCeldas.Add(New Modelos.Celda("vcnumi,", False, "NRO VENTA", 100))
                listEstCeldas.Add(New Modelos.Celda("factura", True, "NRO FACTURA".ToUpper, 100))
                listEstCeldas.Add(New Modelos.Celda("vcobs", True, "OBSERVACIÓN", 300))
                listEstCeldas.Add(New Modelos.Celda("vctotal", True, "TOTAL", 90, 0.00))
                listEstCeldas.Add(New Modelos.Celda("vcalm", False, "", 50))
                listEstCeldas.Add(New Modelos.Celda("sucursal", True, "SUCURSAL", 160))
                listEstCeldas.Add(New Modelos.Celda("vcsector", False, "", 50))
                listEstCeldas.Add(New Modelos.Celda("sector", False, "", 50))
                listEstCeldas.Add(New Modelos.Celda("vcfdoc", True, "FECHA", 120, "dd/MM/yyyy"))
                listEstCeldas.Add(New Modelos.Celda("nit", True, "NIT", 100))
                listEstCeldas.Add(New Modelos.Celda("lanom", True, "RAZÓN SOCIAL", 220))

                Dim ef = New EfectoAyuda
                ef.tipo = 3
                ef.dt = dt
                'Modelos.MGlobal.SeleccionarCol = 5
                ef.SeleclCol = 2
                ef.listEstCeldas = listEstCeldas
                ef.alto = 100
                ef.ancho = 200
                ef.Context = "Seleccione Factura".ToUpper
                ef.ShowDialog()
                Dim bandera As Boolean = False
                bandera = ef.band
                If (bandera = True) Then
                    Dim Row As Janus.Windows.GridEX.GridEXRow = ef.Row
                    '_CodEmpleado = Row.Cells("paven").Value
                    '_CodCliente = Row.Cells("paclpr").Value
                    'tbCliente.Text = Row.Cells("cliente").Value
                    'tbVendedor.Text = Row.Cells("vendedor").Value
                    'tbProforma.Text = Row.Cells("panumi").Value
                    'cbSucursal.Value = Row.Cells("paalm").Value
                    ''Nuevos datos agregados
                    '_CodObra = Row.Cells("paobra").Value
                    'tbObra.Text = Row.Cells("oanomb").Value
                    'tbMdesc.Text = Row.Cells("padesc").Value
                    ''tbTransporte.Text = Row.Cells("patransp").Value

                    '_prCargarProductoDeLaProforma(Row.Cells("panumi").Value)

                End If

            End If


        End If


    End Sub

    Public Function _fnAccesible()
        Return tbObservacion.ReadOnly = False
    End Function

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        _Limpiar()
    End Sub

    Private Sub _Limpiar()
        tbCodigo.Clear()
        dtFecha.Value = Now.Date
        tbAlumno.Clear()
        tbNFactura.Clear()
        tbObservacion.Clear()
        tbSuc.SelectedIndex = 0

    End Sub
End Class