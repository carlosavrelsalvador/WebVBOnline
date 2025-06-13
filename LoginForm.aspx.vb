Imports System.Data.SqlClient
Imports System.Security.Cryptography

Public Class LoginForm
    Inherits System.Web.UI.Page
    Public Shared idShared As Int32 = "0"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim filePath As String = ""
        Dim base64encoded As String = vbNull
        Conexiones.AbrirConexion()
        Conexiones.Cnn.Open()

        Dim has As New OC.Core.Crypto.Hash
        Dim texto As String = txtClave.Text
        Dim TxtEncriptado As String = has.Sha256(texto).ToLower

        Dim query As String = "select * from usuarios where usuario = @usuario and clave=@clave"
        Using cmd As New SqlClient.SqlCommand(query, Conexiones.Cnn)
            cmd.Parameters.AddWithValue("@usuario", txtUsuario.Text)
            cmd.Parameters.AddWithValue("@clave", TxtEncriptado)
            Dim da = New SqlDataAdapter(cmd)

            'Dim da As New SqlClient.SqlDataAdapter("select * from usuarios where usuario='" & txtUsuario.Text & "' and clave='" & TxtEncriptado & "'", Conexiones.Cnn)
            Dim ds As New DataSet
            da.Fill(ds)
            If ds.Tables(0).Rows.Count > 0 Then
                idShared = ds.Tables(0).Rows(0).Item("id")
                Bitacora.bitacora(ds.Tables(0).Rows(0).Item("id"), 0, "login", "valor", "valor") ' Log successful login
                CreateCookies()
                Response.Redirect("~/clientesForm.aspx")

            Else
                Bitacora.bitacora(0, 0, "fail login", "valor", "usuario=" & txtUsuario.Text) ' Log successful login
                MsgBox("usuario incorrecto! ", vbCritical, "Login Error")
                'Console.WriteLine("usuario incorrecto!")

            End If
        End Using

        Conexiones.Cnn.Close()
    End Sub

    Private Sub CreateCookies()
        Dim FechaHora As String = Now.AddMinutes(30)

        If Request.Cookies("EmpleadoASP") Is Nothing Then

            Dim aCookie As New HttpCookie("EmpleadoASP")
            aCookie.Value = "Activa"
            aCookie.Expires = FechaHora
            Response.Cookies.Add(aCookie)
            'nombre de usuario actual
            Dim nCookie As New HttpCookie("nombreASP")
            nCookie.Value = txtUsuario.Text
            nCookie.Expires = FechaHora
            Response.Cookies.Add(nCookie)
            'ID de usuario actual
            Dim idCookie As New HttpCookie("idASP")
            idCookie.Value = idShared
            idCookie.Expires = FechaHora
            Response.Cookies.Add(idCookie)

        Else

            Dim cookie As HttpCookie = HttpContext.Current.Request.Cookies("EmpleadoASP")
            cookie.Value = "Activa"
            cookie.Expires = FechaHora
            Response.Cookies.Add(cookie)
            'nombre de usuario actual
            Dim nCookie As HttpCookie = HttpContext.Current.Request.Cookies("nombreASP")
            nCookie.Value = txtUsuario.Text
            nCookie.Expires = FechaHora
            Response.Cookies.Add(nCookie)

        End If



    End Sub

End Class