Imports Janus.Windows.GridEX
Imports Logica.AccesoLogica

Imports DevComponents.DotNetBar
Imports System.IO
Imports DevComponents.DotNetBar.SuperGrid
Public Class Frm_AyudaP

#Region "ATRIBUTOS"
    Public dtBuscador As DataTable
    Public nombreVista As String
    Public posX As Integer
    Public posY As Integer
    Public seleccionado As Boolean

    Public filaSelect As Janus.Windows.GridEX.GridEXRow

    Public listEstrucGrilla As List(Of Modelos.Celda)
#End Region

#Region "METODOS PRIVADOS"
    Public Sub New(ByVal x As Integer, y As Integer, dt1 As DataTable, titulo As String, listEst As List(Of Modelos.Celda), Optional ByVal alto As Integer = 0)
        dtBuscador = dt1
        posX = x
        posY = y
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        'Me.StartPosition = FormStartPosition.Manual
        'Me.Location = New Point(posX, posY)
        Me.StartPosition = FormStartPosition.Manual
        If posX = 0 And posY = 0 Then
            Me.StartPosition = FormStartPosition.CenterScreen
        Else
            Me.Location = New Point(posX, posY)
        End If

        GPPanelP.Text = titulo

        listEstrucGrilla = listEst

        seleccionado = False

        _PMCargarBuscador()
        'grJBuscador.Row = grJBuscador.FilterRow.RowIndex
        'grJBuscador.Col = 1
        If alto > 0 Then
            Me.Height = alto
        End If

        grJBuscador.Focus()
    End Sub

    Private Sub _PMCargarBuscador()

        Dim anchoVentana As Integer = 0

        grJBuscador.DataSource = dtBuscador
        grJBuscador.RetrieveStructure()
        For i = 0 To dtBuscador.Columns.Count - 1
            With grJBuscador.RootTable.Columns(i)
                If listEstrucGrilla.Item(i).visible = True Then
                    .Caption = listEstrucGrilla.Item(i).titulo
                    .Width = listEstrucGrilla.Item(i).tamano
                    .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
                    .CellStyle.FontSize = 9

                    Dim col As DataColumn = dtBuscador.Columns(i)
                    Dim tipo As Type = col.DataType
                    If tipo.ToString = "System.Int32" Or tipo.ToString = "System.Decimal" Then
                        .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
                    End If
                    If listEstrucGrilla.Item(i).formato <> String.Empty Then
                        .FormatString = listEstrucGrilla.Item(i).formato
                    End If

                    anchoVentana = anchoVentana + listEstrucGrilla.Item(i).tamano
                Else
                    .Visible = False
                End If
            End With
        Next

        'Habilitar Filtradores
        With grJBuscador
            .DefaultFilterRowComparison = FilterConditionOperator.Contains
            .FilterMode = FilterMode.Automatic
            .FilterRowUpdateMode = FilterRowUpdateMode.WhenValueChanges
            'diseño de la grilla
            .GroupByBoxVisible = False
            .VisualStyle = VisualStyle.Office2007
        End With

        'adaptar el tamaño de la ventana
        Me.Width = anchoVentana + 50
        grJBuscador.Focus()
    End Sub
#End Region

    Private Sub ModeloAyuda_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MyBase.KeyPress


        e.KeyChar = e.KeyChar.ToString.ToUpper
        If (e.KeyChar = ChrW(Keys.Escape)) Then
            e.Handled = True
            Me.Close()
        End If
    End Sub

    Private Sub grJBuscador_KeyDown(sender As Object, e As KeyEventArgs) Handles grJBuscador.KeyDown

        If e.KeyData = Keys.Escape Then
            Me.Close()
        End If

        If e.KeyData = Keys.Enter And grJBuscador.Row >= 0 Then
            filaSelect = grJBuscador.GetRow()
            seleccionado = True
            Me.Close()
        End If
    End Sub

    Private Sub grJBuscador_EditingCell(sender As Object, e As EditingCellEventArgs) Handles grJBuscador.EditingCell

        'Habilitar solo las columnas de Precio, %, Monto y Observación
        If (e.Column.Index = grJBuscador.RootTable.Columns("estado").Index) Then
            e.Cancel = False
        Else
            e.Cancel = True
            End If



    End Sub

    Private Sub btnAnadir_Click(sender As Object, e As EventArgs) Handles btnAnadir.Click
        Dim dt As DataTable = CType(grJBuscador.DataSource, DataTable)
        Dim lenght As Integer = dt.Rows.Count - 1

        For i As Integer = 0 To lenght Step 1
            CType(grJBuscador.DataSource, DataTable).Rows(i).Item("estado") = Not (dt.Rows(i).Item("estado"))
        Next
    End Sub

    Public Function _fnVerificar(ByRef dt1 As DataTable) As Boolean
        Dim dt As DataTable = CType(grJBuscador.DataSource, DataTable)
        Dim rows As DataRow()
        rows = dt.Select("estado=true", sort:="lfnumi")
        Dim table As DataTable = New DataTable()
        table.Columns.Add("numi", GetType(Integer))
        table.Columns.Add("estado", GetType(Integer))

        If (rows.Count > 0) Then
            For i As Integer = 0 To rows.Count - 1 Step 1
                table.Rows.Add(rows(i)("lfnumi"), rows(i)("estado"))
            Next
            dt1 = table
            Return True
        End If
        Return False
    End Function

    Private Sub ButtonX1_Click(sender As Object, e As EventArgs) Handles ButtonX1.Click
        Dim dt As DataTable = New DataTable

        If (_fnVerificar(dt)) Then

            Dim res As Boolean = L_prRecepcionVehiculoModificarEstadoAll(dt)
            If res Then
                ToastNotification.Show(Me, "Los Estados han sido modificado con exito.".ToUpper, My.Resources.GRABACION_EXITOSA, 5000, eToastGlowColor.Green, eToastPosition.TopCenter)
                dtBuscador = L_prServicioVentaNumeroOrdenGeneral()
                _PMCargarBuscador()

                '_prCargarGridGeneralControl()
            Else
                ToastNotification.Show(Me, "Error No Existe ninguna fila seleccionada".ToUpper, My.Resources.GRABACION_EXITOSA, 5000, eToastGlowColor.Red, eToastPosition.TopCenter)
            End If
        End If

    End Sub
End Class