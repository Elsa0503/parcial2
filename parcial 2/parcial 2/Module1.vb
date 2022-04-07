
Imports System.Data.SqlClient

Module Module1

    Public Conexion As New SqlConnection
    Public conectado As Boolean
    Public Cadena As String = "Data Source=DESKTOP-V5IBECV\SQLEXPRESS;Initial Catalog=pizzeria;Integrated Security=True"


    Sub ConectarBD()
        If conectado = False Then
            Try
                conexion.ConnectionString = Cadena
                conexion.Open()
                conectado = True
                MsgBox("Se conecto la base de datos exitosamente")
            Catch ex As Exception
                MsgBox("No se pudo conectar a la base de datos" & vbCrLf & ex.ToString())
            End Try
        Else
            MsgBox("La base de datos ya fue conectada previamente")
        End If
    End Sub

    Friend Sub Guardarpedido(Tamaño As String, cantidad As Integer, subtotal As Integer, v As Double, total As Double)
        Try
            Dim sql = "INSERT INTO datoPizzeria (tamaño, cantidad, Subtotal, Descuento, Total) VALUES ('" & Tamaño & "','" & cantidad & "'," & subtotal & ", " & v & ", " & total & ");"
            Dim Comando As New SqlCommand(sql, Conexion)
            Comando.ExecuteNonQuery()
            MsgBox("El dato se guardo exitosamente")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub verpizzas()
        If conectado = True Then
            Try
                Dim sql = "SELECT * FROM datoPizzeria"
                Dim Comando As New SqlDataAdapter(sql, Conexion)
                Dim TablaDatos As New DataSet
                Comando.Fill(TablaDatos, "Datos")
                Form2.DataGridView1.DataSource = TablaDatos.Tables("Datos")
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Friend Sub modificarpizza(codigo As String, subtotal As Double, descuento As Double)
        If conectado = True Then
            Try
                Dim total = subtotal - descuento
                Dim sql = "UPDATE datoPizzeria SET Subtotal = " & subtotal & ", Descuento= " & descuento & ", Total = " & total & " WHERE Codigo = " & codigo & ";"
                Dim Comando As New SqlCommand(sql, Conexion)
                Comando.ExecuteNonQuery()
                MsgBox("Se modifico el dato exitosamente")
                verpizzas()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Else
            MsgBox("No esta conectado a la base de datos.")
        End If
    End Sub

    Friend Sub eliminarpizza(codigo As String)
        If conectado = True Then
            Try
                Dim sql = "DELETE datoPizzeria WHERE Codigo = " & codigo & ";"
                Dim Comando As New SqlCommand(sql, Conexion)
                Comando.ExecuteNonQuery()
                MsgBox("Se elimino el dato exitosamente")
                verpizzas()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Else
            MsgBox("No esta conectado a la base de datos.")
        End If
    End Sub

End Module
