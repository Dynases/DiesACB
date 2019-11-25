
Public Class remolque

    Private nit As String
    Private factura As String
    Private direccion As String
    Private telefono As String

    Public Sub New(text1 As String, text2 As String, text3 As String, text4 As String)
        Me.nit = text1
        Me.factura = text2
        Me.direccion = text3
        Me.telefono = text4
    End Sub


    Public Function getnit() As String
        Return nit
    End Function
    Public Function getfactura() As String
        Return factura
    End Function
    Public Function getdireccion() As String
        Return direccion
    End Function
    Public Function gettelefono() As String
        Return telefono
    End Function
    Public Sub setnit(nits As String)
        nit = nits
    End Sub
    Public Sub setfactura(facturas As String)
        factura = facturas
    End Sub
    Public Sub setdireccion(direccions As String)
        direccion = direccions
    End Sub
    Public Sub settelefono(telefonos As String)
        telefono = telefonos
    End Sub

End Class
