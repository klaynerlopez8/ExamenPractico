Public Class Form1
    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        conectar()
        Dim usuario As String
        usuario = txtUser.Text
        Dim consulta As String
        Dim Pass As String
        Pass = txtPassword.Text

        consulta = "select * from Usuario where User='" & usuario & "'"

        Dim ejecutar As New OleDb.OleDbCommand
        Dim tabla As OleDb.OleDbDataReader
        ejecutar.CommandType = CommandType.Text
        ejecutar.Connection = conexionBD
        ejecutar.CommandText = consulta
        tabla = ejecutar.ExecuteReader
        tabla.Read()
        If (tabla.HasRows) Then
            Try
                If tabla!Password = Pass Then
                    MsgBox("Bienvenido " & tabla!User, vbInformation, "Usuario")
                    frmIsesion.Show()
                Else
                    MsgBox("Error en el usuario o en la contraseña", vbExclamation, "Error")
                End If
            Catch ex As Exception
                MsgBox("No se encuentra el usuario")
            End Try
        Else
            MsgBox("No se encuentra el usuario")
        End If
        desconectar()
    End Sub
End Class
