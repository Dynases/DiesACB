Imports Logica.AccesoLogica
Imports Janus.Windows.GridEX
Imports DevComponents.DotNetBar
Imports System.IO
Imports DevComponents.DotNetBar.SuperGrid
Imports Presentacion.F_ClienteNuevoServicio
Public Class F0_CambioChofer


    Private Sub _prIniciarTodo()

        Me.Text = "I N T E R C A M B I A R    I N S T R U C T O R"


        Dim blah As Bitmap = My.Resources.venta
        Dim ico As Icon = Icon.FromHandle(blah.GetHicon())

        Me.Icon = ico
        _prCargarGridinstructorA()
        _prCargarGridinstructorB()
        Me.WindowState = FormWindowState.Maximized



    End Sub

    Private Sub _prCargarGridinstructorB()
        Dim dt As New DataTable
        dt = L_prPersonaAyudaGeneralInstructor(1)

        ''''janosssssssss''''''
        grInstructorA.DataSource = dt
        grInstructorA.RetrieveStructure()
        grInstructorA.AlternatingColors = True
        grInstructorA.RowFormatStyle.Font = New Font("arial", 10)

        With grInstructorA.RootTable.Columns("nombre")
            .Width = 300


            .Caption = "NOMBRE"
            .Visible = True
        End With

        With grInstructorB.RootTable.Columns("panumi")
            .Visible = False
        End With

        With grInstructorA.RootTable.Columns("sucursal")
            .Width = 300
            .Caption = "SUCURSAL"
            .Visible = True
        End With

        With grInstructorA
            .GroupByBoxVisible = False
            'diseño de la grilla
            .DefaultFilterRowComparison = FilterConditionOperator.Contains
            .FilterMode = FilterMode.Automatic
            .FilterRowUpdateMode = FilterRowUpdateMode.WhenValueChanges
            .VisualStyle = VisualStyle.Office2007
        End With
        grInstructorA.RootTable.HeaderFormatStyle.FontBold = TriState.True

    End Sub

    Private Sub _prCargarGridinstructorA()
        Dim dt As New DataTable
        dt = L_prPersonaAyudaGeneralInstructor(1)

        ''''janosssssssss''''''
        grInstructorB.DataSource = dt
        grInstructorB.RetrieveStructure()
        grInstructorB.AlternatingColors = True
        grInstructorB.RowFormatStyle.Font = New Font("arial", 10)

        With grInstructorB.RootTable.Columns("panumi")
            .Visible = False
        End With
        With grInstructorB.RootTable.Columns("nombre")
            .Width = 300


            .Caption = "NOMBRE"
            .Visible = True
        End With


        With grInstructorB.RootTable.Columns("sucursal")
            .Width = 300
            .Caption = "SUCURSAL"
            .Visible = True
        End With

        With grInstructorB
            .GroupByBoxVisible = False
            'diseño de la grilla
            .DefaultFilterRowComparison = FilterConditionOperator.Contains
            .FilterMode = FilterMode.Automatic
            .FilterRowUpdateMode = FilterRowUpdateMode.WhenValueChanges
            .VisualStyle = VisualStyle.Office2007
        End With
        grInstructorB.RootTable.HeaderFormatStyle.FontBold = TriState.True

    End Sub

    Private Sub _prCambiarInsctructor()
        Dim numiInst1 As String = grInstructorA.GetValue("panumi")
        Dim numiInst2 As String = grInstructorB.GetValue("panumi")

        Dim dtClases2 As DataTable = L_prClasesPracObtenerPorInstructor(numiInst2)
        If dtClases2.Rows.Count > 0 Then
            'Dim img As Bitmap = New Bitmap(My.Resources.Mensaje, 50, 50)
            'ToastNotification.Show(Me, "no se puede hacer el traspaso por que el instructor B ya tiene registrado clases clases practicas".ToUpper, img, 2000, eToastGlowColor.Red, eToastPosition.BottomCenter)
            'grInstructorA.Focus()

            Dim dtClases1 As DataTable = L_prClasesPracObtenerPorInstructor(numiInst1)

            Dim dtHorasLibres1 As DataTable = L_prHoraLibreTCE0062GetPorInstructor(numiInst2)
            Dim dtHorasDiligencia1 As DataTable = L_prHoraDiligenciaTCE0063GetPorInstructor(numiInst2)


            Dim res As Boolean = L_prClasesPracCambioInstructorConDataTable(numiInst1, numiInst2, dtClases2, dtHorasLibres1, dtHorasDiligencia1)
            If res Then
                ToastNotification.Show(Me, "se intercambio correctamente las clases del instructor A y el instrucor B".ToUpper, My.Resources.GRABACION_EXITOSA, 5000, eToastGlowColor.Green, eToastPosition.TopCenter)

            Else
                Dim img As Bitmap = New Bitmap(My.Resources.Mensaje, 50, 50)
                ToastNotification.Show(Me, "no se pudo realizar el cambio de instructor".ToUpper, img, 2000, eToastGlowColor.Red, eToastPosition.BottomCenter)
            End If
        Else
            Dim res As Boolean = L_prClasesPracCambioInstructor(numiInst1, numiInst2)
            If res Then
                ToastNotification.Show(Me, "se paso correctamente las clases del instructor A al instructor B".ToUpper, My.Resources.GRABACION_EXITOSA, 5000, eToastGlowColor.Green, eToastPosition.TopCenter)

            Else
                Dim img As Bitmap = New Bitmap(My.Resources.Mensaje, 50, 50)
                ToastNotification.Show(Me, "no se pudo realizar el cambio de instructor".ToUpper, img, 2000, eToastGlowColor.Red, eToastPosition.BottomCenter)
            End If
        End If


    End Sub

    Private Sub F0_CambioChofer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _prIniciarTodo()
    End Sub

    Private Sub btMarcarTodos_Click(sender As Object, e As EventArgs) Handles btMarcarTodos.Click
        _prCambiarInsctructor
        Return
    End Sub
End Class