
Imports Janus.Windows.GridEX
Imports Logica.AccesoLogica
Public Class F0_HotelReservaHuespedes


    Public _dtGrid As DataTable
#Region "Metodos privados"

    Public Sub New(numiRes As String)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        _prCargarGridHuespedes(numiRes)
    End Sub
    Public Sub _prIniciarTodo()


    End Sub

    Private Sub _prCargarGridHuespedes(_numiRes As String)
        If IsNothing(_dtGrid) Then
            _dtGrid = L_prHotelReservaGetHuespedes(_numiRes)
            grHuespedes.DataSource = _dtGrid
            grHuespedes.RetrieveStructure()

            'dar formato a las columnas
            With grHuespedes.RootTable.Columns("hfnumi")
                .Visible = False
            End With
            With grHuespedes.RootTable.Columns("hfnumitc3")
                .Visible = False
            End With

            With grHuespedes.RootTable.Columns("hfci")
                .Caption = "ci".ToUpper
                .Visible = True
                .Width = 100
                .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
                .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            End With

            With grHuespedes.RootTable.Columns("hfnombre")
                .Caption = "NOMBRE"
                .Width = 300
                .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            End With

            With grHuespedes.RootTable.Columns("hffnac")
                .Caption = "FECHA NAC.".ToUpper
                .Visible = True
                .Width = 100
                .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
                .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            End With
            With grHuespedes.RootTable.Columns("estado")
                .Visible = False
                .DefaultValue = 0
            End With

            'Habilitar Filtradores
            With grHuespedes
                '.DefaultFilterRowComparison = FilterConditionOperator.Contains
                '.FilterMode = FilterMode.Automatic
                '.FilterRowUpdateMode = FilterRowUpdateMode.WhenValueChanges
                .GroupByBoxVisible = False
                .AllowAddNew = InheritableBoolean.True
                'diseño de la grilla
                .VisualStyle = VisualStyle.Office2007
                .ContextMenuStrip = ContextMenuStrip1
            End With

        End If

    End Sub

    Private Sub _prEliminarFilaDetalle()
        If grHuespedes.Row >= 0 Then

            Dim estado As Integer = grHuespedes.GetValue("estado")
            grHuespedes.GetRow(grHuespedes.Row).BeginEdit()
            grHuespedes.CurrentRow.Cells.Item("estado").Value = -1
           
            grHuespedes.RemoveFilters()
            grHuespedes.RootTable.ApplyFilter(New Janus.Windows.GridEX.GridEXFilterCondition(grHuespedes.RootTable.Columns("estado"), Janus.Windows.GridEX.ConditionOperator.GreaterThan, -1))

          
        End If
    End Sub
#End Region


    Private Sub ButtonX2_Click(sender As Object, e As EventArgs) Handles ButtonX2.Click

        Close()
    End Sub

    Private Sub ModeloHor_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MyBase.KeyPress

        e.KeyChar = e.KeyChar.ToString.ToUpper
        If (e.KeyChar = ChrW(Keys.Enter)) Then
            e.Handled = True
            P_Moverenfoque()
        End If
    End Sub

    Private Sub P_Moverenfoque()
        SendKeys.Send("{TAB}")
    End Sub

    Private Sub F_ClienteNuevoServicio_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _prIniciarTodo()

    End Sub

    Private Sub ButtonX3_Click(sender As Object, e As EventArgs) Handles ButtonX3.Click
        Close()
    End Sub

    Private Sub ELIMINARToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ELIMINARToolStripMenuItem.Click
        _prEliminarFilaDetalle()
    End Sub
End Class