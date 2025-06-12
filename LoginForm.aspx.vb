Public Class LoginForm
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Conexiones.AbrirConexion()
        Conexiones.Cnn.Open()

        Dim da As New SqlClient.SqlDataAdapter("select * from usuarios where usuario='" & txtUsuario.Text & "' and clave='" & txtClave.Text & "'", Conexiones.Cnn)
        Dim ds As New DataSet
        da.Fill(ds)
        If ds.Tables(0).Rows.Count > 0 Then
            CreateCookies()

            Response.Redirect("~/estudiantes.aspx")

        Else
            MsgBox("usuario incorrecto! ", vbCritical, "Login Error")
            'Console.WriteLine("usuario incorrecto!")

        End If

        Conexiones.Cnn.Close()
    End Sub

    Private Sub CreateCookies()
        Dim FechaHora As String = Now.AddMinutes(3)

        If Request.Cookies("EmpleadoASP") Is Nothing Then

            Dim aCookie As New HttpCookie("EmpleadoASP")

            aCookie.Value = "Activa"

            aCookie.Expires = FechaHora

            Response.Cookies.Add(aCookie)

        Else

            Dim cookie As HttpCookie = HttpContext.Current.Request.Cookies("EmpleadoASP")

            cookie.Value = "Activa"

            cookie.Expires = FechaHora

            Response.Cookies.Add(cookie)

        End If



    End Sub
End Class