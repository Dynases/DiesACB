Imports Logica.AccesoLogica
Imports Janus.Windows.GridEX
Imports DevComponents.DotNetBar
Imports System.IO
Imports DevComponents.DotNetBar.SuperGrid
Imports zkemkeeper
Public Class F0_Asistencia
#Region "Variable Globales"
    Dim TableMarcacion As DataTable
    Public _nameButton As String
    Dim Ip As String = ""
    Public axCZKEM1 As New zkemkeeper.CZKEM
    Private bIsConnected = False 'the boolean value identifies whether the device is connected
    Private iMachineNumber As Integer 'the serial number of the device.After connecting the device ,this value will be changed.

    'If your device supports the TCP/IP communications, you can refer to this.
    'when you are using the tcp/ip communication,you can distinguish different devices by their IP address.
#End Region

#Region "Metodos Privados"



    Public Sub _prConectar()
        Dim ta As DataTable = L_prObtenerIpReloj(1)
        If (ta.Rows.Count > 0) Then
            Ip = ta.Rows(0).Item("caip")
        Else
            MsgBox("No se Pudo Conectar Error en Obtener Ip Sucursal", MsgBoxStyle.Exclamation, "Error")
            Return

        End If
        Cursor = Cursors.WaitCursor

        Dim idwErrorCode As Integer
        If btConectar.Text = "DESCONECTAR" Then
            axCZKEM1.Disconnect()
            bIsConnected = False
            btConectar.Text = "CONECTAR"
            rlabel.Text = "DESCONECTADO"
            btConectar.Image = My.Resources.switch_2
            Cursor = Cursors.Default
            Return
        End If
        bIsConnected = axCZKEM1.Connect_Net(Ip, Convert.ToInt32("4370"))
        If bIsConnected = True Then
            iMachineNumber = 1 'In fact,when you are using the tcp/ip communication,this parameter will be ignored,that is any integer will all right.Here we use 1.
            axCZKEM1.RegEvent(iMachineNumber, 65535) 'Here you can register the realtime events that you want to be triggered(the parameters 65535 means registering all)
            rlabel.Text = "CONECTADO"
            rlabel.ForeColor = Color.DodgerBlue
            btConectar.Text = "DESCONECTAR"
            btConectar.Image = My.Resources.switch_3

            btConectar.Refresh()
        Else
            axCZKEM1.GetLastError(idwErrorCode)
            MsgBox("No se Pudo Conectar=" & idwErrorCode, MsgBoxStyle.Exclamation, "Error")

        End If
        Cursor = Cursors.Default
    End Sub
    Private Sub _prIniciarTodo()
        L_prAbrirConexion(gs_Ip, gs_UsuarioSql, gs_ClaveSql, gs_NombreBD)
        Me.Text = "A S I S T E N C I A"
        TableMarcacion = L_prAsistenciaGeneral() ''En esta linea de codigo lo que hago es solo agarrar la estrucutura y luego los datos lo elimino con el clear como esta abajo
        TableMarcacion.Rows.Clear()
        _prCargarGridAsistencia()
        Me.WindowState = FormWindowState.Maximized
        LblPaginacion.Text = "0 / 0"


    End Sub
    Public Function _fnObtenerCantidadLogActual()
        If bIsConnected = False Then
            MsgBox("Por Favor conecte primero el dispositivo con el programa".ToUpper, MsgBoxStyle.Exclamation, "Error")
            Return -1
        End If
        Dim idwErrorCode As Integer
        Dim iValue = 0
        axCZKEM1.EnableDevice(iMachineNumber, False) 'disable the device
        If axCZKEM1.GetDeviceStatus(iMachineNumber, 6, iValue) = True Then 'Here we use the function "GetDeviceStatus" to get the record's count.The parameter "Status" is 6.
            'MsgBox("The count of the AttLogs in the device is " + iValue.ToString(), MsgBoxStyle.Information, "Success")
        Else
            axCZKEM1.GetLastError(idwErrorCode)
            MsgBox("Operacion Fallida con Codigo =" & idwErrorCode, MsgBoxStyle.Exclamation, "Error")
        End If

        axCZKEM1.EnableDevice(iMachineNumber, True) 'enable the device
        Return iValue
    End Function
    Public Function _fnFormatNumber(_numero As Integer) As String
        Return IIf(_numero < 10, "0".Trim + Str(_numero).Trim, Str(_numero).Trim)
    End Function
    Public Sub _prObtenerDatosReloj()

        Dim sdwEnrollNumber As String = ""
        Dim idwVerifyMode As Integer
        Dim idwInOutMode As Integer
        Dim idwYear As Integer
        Dim idwMonth As Integer
        Dim idwDay As Integer
        Dim idwHour As Integer
        Dim idwMinute As Integer
        Dim idwSecond As Integer
        Dim idwWorkcode As Integer
        Dim idwErrorCode As Integer
        Dim iGLCount = 0
        Cursor = Cursors.WaitCursor
        TableMarcacion.Rows.Clear()
        axCZKEM1.EnableDevice(iMachineNumber, False) 'disable the device
        If axCZKEM1.ReadGeneralLogData(iMachineNumber) Then 'read all the attendance records to the memory
            'get records from the memory
            While axCZKEM1.SSR_GetGeneralLogData(iMachineNumber, sdwEnrollNumber, idwVerifyMode, idwInOutMode, idwYear, idwMonth, idwDay, idwHour, idwMinute, idwSecond, idwWorkcode)
                iGLCount += 1

                Dim Datanombre As DataTable = L_prObtenerNombreEmpleado(sdwEnrollNumber)
                If (Datanombre.Rows.Count > 0) Then
                    Dim nombre As String = Datanombre.Rows(0).Item("nombre")
                    TableMarcacion.Rows.Add(iGLCount, sdwEnrollNumber, nombre, DateSerial(idwYear, idwMonth, idwDay).ToString("dd/MM/yyyy"), _fnFormatNumber(idwHour) + ":" + _fnFormatNumber(idwMinute) + ":" + _fnFormatNumber(idwSecond), 0, Now.Date(), Str(Now.Hour), "", 0)
                Else
                    TableMarcacion.Rows.Add(iGLCount, sdwEnrollNumber, "USUARIO NO REGISTRADO", DateSerial(idwYear, idwMonth, idwDay).ToString("dd/MM/yyyy"), _fnFormatNumber(idwHour) + ":" + _fnFormatNumber(idwMinute) + ":" + _fnFormatNumber(idwSecond), 0, Now.Date(), Str(Now.Hour), "", 0)

                End If

            End While
            _prCargarGridAsistencia()
            ToastNotification.Show(Me, "Datos de Asistencia Cargados Con Exito ".ToUpper, My.Resources.GRABACION_EXITOSA, 5000, eToastGlowColor.Green, eToastPosition.TopCenter)

        Else
            Cursor = Cursors.Default
            axCZKEM1.GetLastError(idwErrorCode)
            If idwErrorCode <> 0 Then
                MsgBox("No se Pudo Leer Datos del Lector de Huellas : " & idwErrorCode, MsgBoxStyle.Exclamation, "Error")
            Else
                MsgBox("No hay Datos en el Lector de Huellas!", MsgBoxStyle.Exclamation, "Error")
            End If
        End If

        axCZKEM1.EnableDevice(iMachineNumber, True) 'enable the device
        Cursor = Cursors.Default
    End Sub

    Private Sub _prCargarGridAsistencia()
        Dim dt As New DataTable
        dt = TableMarcacion
        ''''janosssssssss''''''
        grAsistencia.DataSource = dt
        grAsistencia.RetrieveStructure()
        grAsistencia.AlternatingColors = True
        grAsistencia.RowFormatStyle.Font = New Font("arial", 10)
        'zaline, zacper, zafecha, zahora, zaest, zafact, zahact, zauact
        With grAsistencia.RootTable.Columns("zaline")
            .Width = 70
            .TextAlignment = TextAlignment.Center
            .Caption = "ID"
            .Visible = True
        End With
        With grAsistencia.RootTable.Columns("zacper")
            .Width = 150
            .Caption = "CODIGO PERSONAL"
            .Visible = True
        End With
        With grAsistencia.RootTable.Columns("nombre")
            .Width = 300
            .Caption = "NOMBRE"
            .Visible = True
        End With
        With grAsistencia.RootTable.Columns("zafecha")
            .Width = 120
            .Visible = True
            .Caption = "FECHA"
        End With
        With grAsistencia.RootTable.Columns("zahora")
            .Width = 100
            .Caption = "HORA"
            .Visible = True
        End With
        With grAsistencia.RootTable.Columns("zaest")
            .Width = 120
            .Caption = "ESTADO"
            .Visible = True
        End With


        With grAsistencia.RootTable.Columns("zafact")
            .Width = 250
            .Visible = False
        End With

        With grAsistencia.RootTable.Columns("zahact")
            .Width = 250
            .Visible = False
        End With

        With grAsistencia.RootTable.Columns("zauact")
            .Width = 250
            .Visible = False
        End With

        With grAsistencia.RootTable.Columns("estado")
            .Width = 100
            .Visible = False
        End With
        With grAsistencia
            .GroupByBoxVisible = False
            'diseño de la grilla
            .VisualStyle = VisualStyle.Office2007
        End With
        grAsistencia.RootTable.HeaderFormatStyle.FontBold = TriState.True
        LblPaginacion.Text = "0 / " + Str(grAsistencia.RowCount)


    End Sub
#End Region

#Region "Eventos del Formulario"
    Private Sub btConectar_Click(sender As Object, e As EventArgs) Handles btConectar.Click
        _prConectar()
    End Sub
    Private Sub btCargarArchivo_Click(sender As Object, e As EventArgs) Handles btCargarArchivo.Click
        If bIsConnected = True Then
            _prObtenerDatosReloj()
        Else
            ToastNotification.Show(Me, "POR FAVOR CONECTE EL SISTEMA CON EL MARCADOR DE HUELLAS", My.Resources.WARNING, 8000, eToastGlowColor.Red, eToastPosition.TopCenter)
        End If


    End Sub
    Public Sub _prEliminarLogs()

        Dim info As New TaskDialogInfo("advertencia".ToUpper, eTaskDialogIcon.Delete, "¿desea continuar?".ToUpper, "DESEA ELIMINAR LOS REGISTROS DE ASISTENCIA DEL RELOJ", eTaskDialogButton.Yes Or eTaskDialogButton.No, eTaskDialogBackgroundColor.Blue)
        Dim result As eTaskDialogResult = TaskDialog.Show(info)
        If result = eTaskDialogResult.Yes Then
            Dim length As Integer = TableMarcacion.Rows.Count
            If (length = _fnObtenerCantidadLogActual()) Then
                Dim idwErrorCode As Integer
                axCZKEM1.EnableDevice(iMachineNumber, False) 'disable the device
                If axCZKEM1.ClearGLog(iMachineNumber) = True Then
                    axCZKEM1.RefreshData(iMachineNumber) 'the data in the device should be refreshed
                    MsgBox("Todos los Datos Fueron Eliminados del Marcador de Asistencia!".ToUpper, MsgBoxStyle.Information, "Exitoso")
                    _prObtenerDatosReloj()
                Else
                    axCZKEM1.GetLastError(idwErrorCode)
                    MsgBox("No se Pudo Borrar los registros del Marcador de asistencia, ErrorCode=" & idwErrorCode, MsgBoxStyle.Exclamation, "Error")
                End If
                axCZKEM1.EnableDevice(iMachineNumber, True) 'enable the device
            Else
                MsgBox("No se Pudo Borrar los registros del Marcador de asistencia Por que existe nuevos registros marcados recientemente, ErrorCode=".ToUpper, MsgBoxStyle.Exclamation, "Error")
                _prObtenerDatosReloj()
            End If
        Else

        End If

    End Sub
    Private Sub btCargarDatos_Click(sender As Object, e As EventArgs) Handles btCargarDatos.Click

        If bIsConnected = True Then
            If (TableMarcacion.Rows.Count > 0) Then
                Dim dt As DataTable = CType(grAsistencia.DataSource, DataTable)
                Dim aux As DataTable = dt.Copy

                Dim res As Boolean
                For i As Integer = 0 To CType(grAsistencia.DataSource, DataTable).Rows.Count - 1

                    aux.Clear()
                    aux.ImportRow(dt.Rows(i))

                    res = L_prMarcacionGrabar("", aux)
                Next

                If res Then
                    ToastNotification.Show(Me, "Datos Guardados exitosamente ..".ToUpper, My.Resources.GRABACION_EXITOSA, 5000, eToastGlowColor.Green, eToastPosition.TopCenter)
                    _prEliminarLogs()
                Else
                    ToastNotification.Show(Me, "NO SE PUDO GRABAR DATOS DE LECTURA DE ASISTENCIA", My.Resources.WARNING, 8000, eToastGlowColor.Red, eToastPosition.TopCenter)

                End If



            Else ''Este else si es que no existe ninguna dato obtenido del reloj
                ToastNotification.Show(Me, "NO EXISTE NINGUN DATO PARA GUARDAR", My.Resources.WARNING, 8000, eToastGlowColor.Red, eToastPosition.TopCenter)
            End If
        Else ''Este else es por si no se pudo conectar con el reloj
            ToastNotification.Show(Me, "POR FAVOR CONECTE EL SISTEMA CON EL MARCADOR DE HUELLAS", My.Resources.WARNING, 8000, eToastGlowColor.Red, eToastPosition.TopCenter)
        End If

    End Sub
    Private Sub btSalir_Click(sender As Object, e As EventArgs) Handles btSalir.Click
        Me.Close()


    End Sub
#End Region

    Private Sub F0_Asistencia_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _prIniciarTodo()

    End Sub

    Private Sub Eliminarms_Click(sender As Object, e As EventArgs) Handles Eliminarms.Click
        Dim pos As Integer = grAsistencia.Row
        Dim ta As DataTable = CType(grAsistencia.DataSource, DataTable)
        If pos >= 0 And pos <= grAsistencia.RowCount - 1 Then
            grAsistencia.GetRow(grAsistencia.Row).BeginEdit()
            grAsistencia.CurrentRow.Cells.Item("estado").Value = -1
        End If
        Dim ta2 As DataTable = CType(grAsistencia.DataSource, DataTable)
        _prAplicarFiltroDelete()

    End Sub
    Public Sub _prAplicarFiltroDelete()
        grAsistencia.RootTable.ApplyFilter(New Janus.Windows.GridEX.GridEXFilterCondition(grAsistencia.RootTable.Columns("estado"), Janus.Windows.GridEX.ConditionOperator.Equal, 0))
    End Sub

 
End Class