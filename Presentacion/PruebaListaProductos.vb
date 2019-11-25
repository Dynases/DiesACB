Public Class PruebaListaProductos


    Private Sub PruebaListaProductos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Dim elem1 As UCElemProducto = New UCElemProducto()
        'Dim elem2 As UCElemProducto = New UCElemProducto()
        'Dim elem3 As UCElemProducto = New UCElemProducto()
        'elem1.Dock = DockStyle.Top
        'elem1.Dock = DockStyle.Top
        'elem2.Dock = DockStyle.Top
        'Panel1.Controls.Add(elem1)
        'Panel1.Controls.Add(elem2)
        'Panel1.Controls.Add(elem2)
        'Panel1.Controls.Add(elem2)
        For i = 1 To 15
            Dim elem1 As UCElemProducto = New UCElemProducto()
            elem1.Dock = DockStyle.Top
            elem1.UCLabelTitulo.Text = "producto" + Str(i)
            elem1.CRbtVerProd.Tag = "producto" + Str(i)
            AddHandler elem1.CRbtVerProd.Click, AddressOf Button1_Click

            Panel1.Controls.Add(elem1)

        Next

        For i = 1 To 15
            Dim elem1 As UCElemProducto = New UCElemProducto()
            elem1.Dock = DockStyle.Top
            elem1.UCLabelTitulo.Text = "producto" + Str(i)
            elem1.CRbtVerProd.Tag = "producto" + Str(i)
            AddHandler elem1.CRbtVerProd.Click, AddressOf Button1_Click

            Panel3.Controls.Add(elem1)

        Next

    End Sub

    Private Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim bt As Button = CType(sender, Button)
        MessageBox.Show(bt.Tag)
    End Sub

End Class