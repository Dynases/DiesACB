Public Class ModeloF0
    Public Shared BoIsMayuscula As Boolean = True

    Private Sub ModeloHor_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MyBase.KeyPress
        If (BoIsMayuscula) Then
            e.KeyChar = e.KeyChar.ToString.ToUpper
        End If

        If (e.KeyChar = ChrW(Keys.Enter)) Then
            e.Handled = True
            P_Moverenfoque()
        End If
    End Sub

    Private Sub P_Moverenfoque()
        SendKeys.Send("{TAB}")
    End Sub

    Private Sub MFlyoutUsuario_PrepareContent(sender As Object, e As EventArgs) Handles MFlyoutUsuario.PrepareContent
        If sender Is BubbleBarUsuario And btnGrabar.Enabled = False Then
            MFlyoutUsuario.BorderColor = Color.FromArgb(&HC0, 0, 0)
            MFlyoutUsuario.Content = PanelUsuario
        End If
    End Sub

End Class