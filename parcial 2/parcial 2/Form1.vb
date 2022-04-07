Public Class Form1
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        ConectarBD()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        CheckBox1.Checked = False
        CheckBox2.Checked = False
        CheckBox3.Checked = False
        CheckBox4.Checked = False
        RadioButton1.Checked = False
        RadioButton2.Checked = False
        RadioButton3.Checked = False
        Label8.Text = "-"
        Label9.Text = "-"
        Label10.Text = "-"
        MsgBox("Se limpiaron los datos")
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Hide()
        Form2.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim Pregunta As String
        Pregunta = MsgBox("¿salir del programa?", vbYesNo + vbQuestion)
        If Pregunta = vbYes Then
            Application.Exit()
        Else
            MsgBox("Puede seguir utilizando el programa :)")
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim tamaño As String
        If RadioButton1.Checked = True Then
            tamaño = "pequeña"
        ElseIf RadioButton2.Checked = True Then
            tamaño = "mediana"
        ElseIf RadioButton3.Checked = True Then
            tamaño = "grande"
        End If
        Dim p1, p2, p3, p4 As Integer
        p1 = 0
        P2 = 0
        p3 = 0
        p4 = 0
        If CheckBox4.Checked = True Then
            Select Case tamaño
                Case "pequeña"
                    p1 = 35
                Case "mediana"
                    p1 = 65
                Case "grande"
                    p1 = 95
            End Select
        End If
        If CheckBox3.Checked = True Then
            Select Case tamaño
                Case "pequeña"
                    P2 = 15
                Case "mediana"
                    P2 = 40
                Case "grande"
                    P2 = 70
            End Select
        End If
        If CheckBox1.Checked = True Then
            Select Case tamaño
                Case "pequeña"
                    p3 = 30
                Case "mediana"
                    p3 = 60
                Case "grande"
                    p3 = 85
            End Select
        End If
        If CheckBox2.Checked = True Then
            Select Case tamaño
                Case "pequeña"
                    p4 = 25
                Case "mediana"
                    p4 = 50
                Case "grande"
                    p4 = 90
            End Select
        End If
        Dim cantidad As Integer
        Dim cantidad1 As Integer
        Dim cantidad2 As Integer
        Dim cantidad3 As Integer
        Dim cantidad4 As Integer

        cantidad1 = Val(TextBox3.Text)
        cantidad2 = Val(TextBox5.Text)
        cantidad3 = Val(TextBox2.Text)
        cantidad4 = Val(TextBox4.Text)

        cantidad = cantidad1 + cantidad2 + cantidad3 + cantidad4
        Dim subtotal As Integer
        subtotal = (p1 * cantidad1) + (p2 * cantidad2) + (p3 * cantidad3) + (p4 * cantidad4)
        Dim descuento1, descuento2 As Double
        If ((p3 = 60) + (p2 = 40)) Then
            descuento1 = subtotal * 0.05
        End If
        If p1 = 95 And p2 = 70 And p3 = 85 And p4 = 90 Then
            descuento2 = subtotal * 0.25
        End If
        Dim total As Double
        total = subtotal - Math.Round(descuento1 + descuento2, 2)

        Label8.Text = subtotal
        Label9.Text = Math.Round(descuento1 + descuento2, 2)
        Label10.Text = total
        MsgBox("Se calculo exitosamente")

        If conectado = True Then
            Module1.Guardarpedido(tamaño, cantidad, subtotal, descuento1 + descuento2, total)
        Else
            MsgBox("No se guardo en Base de datos por que no esta conectado")
        End If
    End Sub


End Class
