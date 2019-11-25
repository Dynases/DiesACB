Imports DevComponents.DotNetBar
Imports Logica.AccesoLogica
Public Class F0_HotelReserva_Cliente

    Public respuesta As Boolean
    Public numiCli As String
    Public nombre As String

#Region "Metodos privados"
    Public Sub _prIniciarTodo()

        _prHabilitarFocus()
    End Sub

    Public Sub _prHabilitarFocus()
        With MHighlighterFocus
            .SetHighlightOnFocus(tbCi, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
            .SetHighlightOnFocus(tbDir, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
            .SetHighlightOnFocus(tbEmail, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
            .SetHighlightOnFocus(tbNombre, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
            .SetHighlightOnFocus(tbTel1, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
        End With
    End Sub

    Public Function _prValidar() As Boolean
        Dim _ok As Boolean = True
        MEP.Clear()

        If tbCi.Text = String.Empty Then
            tbCi.BackColor = Color.Red
            MEP.SetError(tbCi, "Ingrese ci!".ToUpper)
            _ok = False
        Else
            tbCi.BackColor = Color.White
            MEP.SetError(tbCi, "")
        End If

        If tbNombre.Text = String.Empty Then
            tbNombre.BackColor = Color.Red
            MEP.SetError(tbNombre, "Ingrese nombre!".ToUpper)
            _ok = False
        Else
            tbNombre.BackColor = Color.White
            MEP.SetError(tbNombre, "")
        End If


        MHighlighterFocus.UpdateHighlights()
        Return _ok

    End Function

    Private Sub _prGrabar()
        If _prValidar() Then
            Dim numi As String = ""
            Dim resp As Boolean = L_prClienteHGrabar(numi, 1, 0, Now.Date.ToString("yyyy/MM/dd"), tbFnac.Value.ToString("yyyy/MM/dd"), tbNombre.Text, "", "", tbDir.Text, tbEmail.Text, tbCi.Text, "", "", 1, tbTel1.Text, "")
            If resp Then
                ToastNotification.Show(Me, "cliente nuevo grabado exitosamente".ToUpper, My.Resources.GRABACION_EXITOSA, 8000, eToastGlowColor.Green, eToastPosition.TopCenter)
                numiCli = numi
                nombre = tbNombre.Text
                respuesta = True
                Close()
            End If
        End If
    End Sub
#End Region


    Private Sub ButtonX2_Click(sender As Object, e As EventArgs) Handles ButtonX2.Click
        respuesta = False
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
        _prHabilitarFocus()
    End Sub

    Private Sub ButtonX3_Click(sender As Object, e As EventArgs) Handles ButtonX3.Click
        _prGrabar()
    End Sub
End Class