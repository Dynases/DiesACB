Public Class UCLavadero

    Private Sub pbImage_MouseEnter(sender As Object, e As EventArgs) Handles pbImg.MouseEnter

        pbSombra.BackColor = Color.SkyBlue
    End Sub

    Private Sub pbImg_MouseLeave(sender As Object, e As EventArgs) Handles pbImg.MouseLeave,pbSombra.MouseLeave, pbImg.MouseLeave

        pbSombra.BackColor = Color.White
        Me.Refresh()
    End Sub
End Class
