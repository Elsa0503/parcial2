Public Class Form2
    Private Sub Form2_VisibleChanged(sender As Object, e As EventArgs) Handles MyBase.VisibleChanged
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        verpizzas()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Hide()
        Form1.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim codigo, subtotal, descuento As String
        codigo = TextBox1.Text
        subtotal = TextBox2.Text
        descuento = TextBox3.Text
        modificarpizza(codigo, subtotal, descuento)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim codigo As String
        codigo = TextBox1.Text
        eliminarpizza(codigo)
    End Sub


End Class