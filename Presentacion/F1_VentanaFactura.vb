Imports Logica.AccesoLogica
Public Class F1_VentanaFactura
    Public nameFactura As String = ""
    Public nit As String = ""
    Public Nombre As String = ""

    Public Sub _prIniciarTodo()

        Me.Text = "DATOS DE LA FACTURA"
        _prHabilitarFocus()
        tbnit.CharacterCasing = CharacterCasing.Upper
        tbnombre.CharacterCasing = CharacterCasing.Upper

        tbnit.MaxLength = 10
        tbnombre.MaxLength = 200
        'tbnombre.Text = Nombre
        tbnit.Focus()
    End Sub
    Public Function _fnValidar() As Boolean
        Dim _ok As Boolean = True
        If (tbnit.Text.Length < 1) Then
            tbnit.BackColor = Color.Red
            MEP.SetError(tbnit, "ingrese su Nit!".ToUpper)
            _ok = False
        Else
            tbnit.BackColor = Color.White
            MEP.SetError(tbnit, "")
        End If
        If (tbnombre.Text.Length < 1) Then
            tbnombre.BackColor = Color.Red
            MEP.SetError(tbnombre, "ingrese su Nombre Completo!".ToUpper)
            _ok = False
        Else
            tbnombre.BackColor = Color.White
            MEP.SetError(tbnombre, "")

        End If
        Return _ok


    End Function

    Public Sub _prHabilitarFocus()
        With Highlighter1
            .SetHighlightOnFocus(tbnit, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
            .SetHighlightOnFocus(tbnombre, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
            .SetHighlightOnFocus(btnVehiculo, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
        End With
    End Sub
    Public Sub _LimpiarErrores()

        MEP.Clear()
        tbnit.BackColor = Color.White
        tbnombre.BackColor = Color.White

    End Sub

    Private Sub ModeloHor_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MyBase.KeyPress

        If (e.KeyChar = ChrW(Keys.Enter)) Then
            e.Handled = True
            P_Moverenfoque()
        End If
    End Sub

    Private Sub P_Moverenfoque()
        SendKeys.Send("{TAB}")
    End Sub

    Private Sub btnVehiculo_Click(sender As Object, e As EventArgs) Handles btnVehiculo.Click
        If (_fnValidar()) Then
            nameFactura = tbnombre.Text
            nit = tbnit.Text
            Me.Close()
        End If
    End Sub

    Private Sub F1_VentanaFactura_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _prIniciarTodo()


    End Sub

    Private Sub tbnit_KeyDown(sender As Object, e As KeyEventArgs) Handles tbnit.KeyDown
        If (e.KeyData = Keys.Enter) Then
            tbnombre.Focus()
        End If
    End Sub

    Private Sub tbnombre_KeyDown(sender As Object, e As KeyEventArgs) Handles tbnombre.KeyDown
        If (e.KeyData = Keys.Enter) Then
            btnVehiculo.Focus()
        End If
    End Sub

    Private Sub tbnit_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles tbnit.Validating
        Dim nom1, nom2 As String
        nom1 = ""
        nom2 = ""
        If (tbnit.Text.Trim = String.Empty) Then
            tbnit.Text = "0"
            tbnombre.Text = "S/N"
        End If
        If (L_Validar_Nit(tbnit.Text.Trim, nom1, nom2)) Then
            tbnombre.Text = nom1

        End If
    End Sub
End Class