Public Class UCItemImg



    Private Sub pbSombra_MouseLeave(sender As Object, e As EventArgs) Handles pbSombra.MouseLeave, pbJpg.MouseLeave

        pbSombra.Visible = False
        Me.Refresh()
    End Sub

    Private Sub pbJpg_MouseEnter(sender As Object, e As EventArgs) Handles pbJpg.MouseEnter
        pbSombra.Visible = True
    End Sub
End Class
