Public Class Bitacora
    Public Shared Sub bitacora(usuarioId, clienteId, accion, valorAnterior, valorNuevo)
        ' Aquí se puede agregar el código para guardar la bitácora en la base de datos
        Dim query As String = "INSERT INTO bitacora (usuarioId,clienteId,accion,valorAnterior,valorNuevo) VALUES (@usuarioId,@clienteId,@accion,@valorAnterior,@valorNuevo)"
        Conexiones.AbrirConexion()
        Using cmd As New SqlClient.SqlCommand(query, Conexiones.Cnn)
            cmd.Parameters.AddWithValue("@usuarioId", usuarioId)
            cmd.Parameters.AddWithValue("@clienteId", clienteId)
            cmd.Parameters.AddWithValue("@accion", accion)
            cmd.Parameters.AddWithValue("@valorAnterior", valorAnterior)
            cmd.Parameters.AddWithValue("@valorNuevo", valorNuevo)
            Conexiones.Cnn.Open()
            cmd.ExecuteNonQuery()
        End Using
        Conexiones.Cnn.Close()
    End Sub
End Class
