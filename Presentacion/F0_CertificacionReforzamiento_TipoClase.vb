
Public Class F0_CertificacionReforzamiento_TipoClase
    Public numiOpcion As String
    Public respuesta As Boolean
    Public Sub New()
        numiOpcion = "0"
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub


    Public Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) 'Handles RadioButton1.CheckedChanged
        Dim elem As RadioButton = CType(sender, RadioButton)
        numiOpcion = elem.Name
    End Sub

    Private Sub ButtonX1_Click(sender As Object, e As EventArgs) Handles ButtonX1.Click
        respuesta = True
        Close()
    End Sub

    Private Sub ButtonX2_Click(sender As Object, e As EventArgs) Handles ButtonX2.Click
        respuesta = False
        Close()
    End Sub
End Class