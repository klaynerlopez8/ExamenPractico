Module conexion
    Public conexionBD As New OleDb.OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0;Data Source=prueba_Leo.accdb")

    Public Sub conectar()
        Try
            conexionBD.Open()
            ' MsgBox("conexion exitosa")
        Catch ex As Exception
            MsgBox("Error al conectar")
        End Try
    End Sub
    Public Sub desconectar()
        Try
            conexionBD.Close()
            'MsgBox("conexion finalizado")
        Catch ex As Exception
            MsgBox("Error al Cerrar la conexion")
        End Try
    End Sub
End Module
