Public Class F0_TamanoVehiculo
    Public PosicionData As Integer
    Private Sub btnAnadir_Click(sender As Object, e As EventArgs) Handles btnAnadir.Click
        PosicionData = 0
        Me.Close()

    End Sub

    Private Sub ButtonX1_Click(sender As Object, e As EventArgs) Handles ButtonX1.Click
        PosicionData = 1

        Me.Close()
    End Sub

    Private Sub ButtonX2_Click(sender As Object, e As EventArgs) Handles ButtonX2.Click
        PosicionData = 2
        Me.Close()
    End Sub
End Class