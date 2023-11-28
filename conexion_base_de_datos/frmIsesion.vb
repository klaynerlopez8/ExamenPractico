Public Class frmIsesion
    Private Sub modificar()
        conectar()
        Dim consulta, usuario, contraseña, modificar As String
        modificar = InputBox("Ingrese el usuario a modificar: ")
        usuario = InputBox("Ingrese el nuevo nombre del usuario")
        contraseña = InputBox("Ingrese la nueva contraseña")

        consulta = "UPDATE usuario SET correo='" & usuario & "',contra='" & contraseña & "' WHERE usuario='" & modificar & "';"

        Dim ejecutar As New OleDb.OleDbCommand
        ejecutar.CommandType = CommandType.Text
        ejecutar.Connection = conexionBD
        ejecutar.CommandText = consulta

        Try
            ejecutar.ExecuteNonQuery()
            MsgBox("datos modificados")

        Catch ex As Exception
            MsgBox("datos no modificados", vbCritical, "Error")
        End Try
        desconectar()
    End Sub
    Private Sub eliminar()
        conectar()
        Dim consulta, eliminar As String
        eliminar = InputBox("Ingrese el usuario a eliminar: ")
        consulta = "delete  From usuario Where correo='" & eliminar & "';"
        Dim ejecutar As New OleDb.OleDbCommand
        ejecutar.CommandType = CommandType.Text
        ejecutar.Connection = conexionBD
        ejecutar.CommandText = consulta

        Try
            ejecutar.ExecuteNonQuery()
            MsgBox("datos eliminados exitosamente")
            lstUsuarios.Items.Clear()
        Catch ex As Exception
            MsgBox("datos no eliminados", vbCritical, "Error")
        End Try
        desconectar()
    End Sub
    Private Sub mostrar()
        conectar()

        Dim consulta As String

        consulta = "select correo from usuario"

        Dim ejecutar As New OleDb.OleDbCommand
        Dim tabla As OleDb.OleDbDataReader
        ejecutar.CommandType = CommandType.Text
        ejecutar.Connection = conexionBD
        ejecutar.CommandText = consulta


        Try
            tabla = ejecutar.ExecuteReader
            'agregar datos sin duplicadosA
            While tabla.Read()
                'verificar si los datos ya existen en el listbox
                If Not lstUsuarios.Items.Contains(tabla!correo) Then
                    lstUsuarios.Items.Add(tabla!correo)
                End If
            End While

        Catch ex As Exception
            MsgBox("Error en la consulta", vbExclamation, "Error")
        End Try

        desconectar()
    End Sub
    Private Sub btnShow_Click(sender As Object, e As EventArgs) Handles btnShow.Click
        mostrar()
    End Sub
    Private Sub agregar()
        conectar()
        Dim consulta, correo, contraseña As String
        correo = InputBox("Ingrese Correo de usuario")
        contraseña = InputBox("Ingrese contraseña de usuario")
        consulta = "insert into usuario values('" & correo & "','" & contraseña & "')"
        Dim ejecutar As New OleDb.OleDbCommand
        ejecutar.CommandType = CommandType.Text
        ejecutar.Connection = conexionBD
        ejecutar.CommandText = consulta
        Try
            ejecutar.ExecuteNonQuery()
            MsgBox("datos agregados exitosamente")
            lstUsuarios.Items.Add(correo)
        Catch ex As Exception
            MsgBox("Error en la consulta")
        End Try

        desconectar()
    End Sub
    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        agregar()
        mostrar()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        modificar()
        mostrar()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        eliminar()
        mostrar()
    End Sub
End Class