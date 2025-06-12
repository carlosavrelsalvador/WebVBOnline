Public Class LoginForm
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim filePath As String = ""
        Dim base64encoded As String = vbNull
        Conexiones.AbrirConexion()
        Conexiones.Cnn.Open()

        'Dim hash = New System.Security.Cryptography.SHA256Managed().ComputeHash(System.Text.Encoding.UTF8.GetBytes("123456"))
        'MsgBox(Convert.ToBase64String(hash))

        Dim has As New OC.Core.Crypto.Hash
        Dim texto As String = txtClave.Text
        Dim TxtEncriptado As String = has.Sha256(texto).ToLower

        Dim da As New SqlClient.SqlDataAdapter("select * from usuarios where usuario='" & txtUsuario.Text & "' and clave='" & TxtEncriptado & "'", Conexiones.Cnn)
        Dim ds As New DataSet
        da.Fill(ds)
        If ds.Tables(0).Rows.Count > 0 Then
            CreateCookies()

            Response.Redirect("~/clientesForm.aspx")

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