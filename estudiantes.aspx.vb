Public Class estudiantes
    Inherits System.Web.UI.Page
    Public dst As DataSet

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        VerificaCookie()

    End Sub

    Protected Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        VerificaCookie()

        Limpiar()
    End Sub

    Private Sub Limpiar()
        txtID.Text = "0"
        txtNombre.Text = ""
        txtTelefono.Text = ""
        txtNombre.Focus()
    End Sub

    Private Sub VerificaCookie()
        If Request.Cookies("EmpleadoASP") Is Nothing Then
            Response.Redirect("~/Login.aspx")
        Else
            Dim cookie As HttpCookie = HttpContext.Current.Request.Cookies("EmpleadoASP")
            cookie.Value = "Activa"
            cookie.Expires = Now.AddMinutes(3)
            Response.Cookies.Add(cookie)

        End If
    End Sub

    Protected Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        VerificaCookie()

        Conexiones.AbrirConexion()
        Conexiones.Cnn.Open()

        If txtID.Text = "0" Then
            Dim cmd As New SqlClient.SqlCommand("insert into estudiante(nombre,telefono) values('" & txtNombre.Text & "','" & txtTelefono.Text & "')", Conexiones.Cnn)
            cmd.ExecuteNonQuery()

            Poblar()
            Limpiar()
        Else
            Dim cmd As New SqlClient.SqlCommand("update estudiante set nombre='" & txtNombre.Text & "',telefono='" & txtTelefono.Text & "' where id=" & txtID.Text, Conexiones.Cnn)
            cmd.ExecuteNonQuery()

            Poblar()
            Limpiar()

        End If

        Conexiones.Cnn.Close()
    End Sub

    Private Sub Poblar()
        Conexiones.AbrirConexion()
        Conexiones.Cnn.Open()

        Dim da As New SqlClient.SqlDataAdapter("select * from estudiante where NOMBRE LIKE '%" & txtBuscar.Text & "%'", Conexiones.Cnn)
        ' Dim ds As New DataSet
        dst = New DataSet
        da.Fill(dst)
        If dst.Tables(0).Rows.Count > 0 Then
            GridView1.DataSource = dst.Tables(0)
            GridView1.DataBind()

        Else
            GridView1.DataSource = Nothing
            GridView1.DataBind()
        End If


        Conexiones.Cnn.Close()
    End Sub

    Protected Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        VerificaCookie()

        Conexiones.AbrirConexion()
        Conexiones.Cnn.Open()

        If MsgBox("¿Seguro que desea eliminar este registro ?", vbYesNo + vbCritical + vbDefaultButton2, "Atención") = vbYes Then
            Dim cmd As New SqlClient.SqlCommand("delete from estudiante where id=" & txtID.Text, Conexiones.Cnn)
            cmd.ExecuteNonQuery()

            Poblar()
        End If

        Conexiones.Cnn.Close()
    End Sub

    Protected Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Poblar()

    End Sub

    Protected Sub btnID_Click(sender As Object, e As EventArgs) Handles btnID.Click
        VerificaCookie()

        Conexiones.AbrirConexion()
        Conexiones.Cnn.Open()

        Dim da As New SqlClient.SqlDataAdapter("select * from estudiante where ID =" & txtID.Text, Conexiones.Cnn)
        Dim ds As New DataSet
        da.Fill(ds)
        If ds.Tables(0).Rows.Count > 0 Then
            txtNombre.Text = ds.Tables(0).Rows(0).Item("NOMBRE")
            txtTelefono.Text = ds.Tables(0).Rows(0).Item("TELEFONO")
        Else
            txtNombre.Text = ""
            txtTelefono.Text = ""
        End If


        Conexiones.Cnn.Close()
    End Sub

    Protected Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        Conexiones.AbrirConexion()
        Conexiones.Cnn.Open()

        Dim da As New SqlClient.SqlDataAdapter("select * from estudiante where NOMBRE LIKE '%" & txtBuscar.Text & "%'", Conexiones.Cnn)
        dst = New DataSet
        da.Fill(dst)
        If dst.Tables(0).Rows.Count > 0 Then
            'Para enviar los valores al formulario de reporte
            Session("grid") = dst.Tables(0)
            Session("fecha") = Now
            Session("materia") = "Literatura"
            Session("total") = dst.Tables(0).Rows.Count

            Server.Transfer("reporte.aspx")
        End If


        Conexiones.Cnn.Close()
    End Sub

    Protected Sub btnSesion_Click(sender As Object, e As EventArgs) Handles btnSesion.Click
        Dim cookie As HttpCookie = HttpContext.Current.Request.Cookies("EmpleadoASP")
        cookie.Value = "Activa"
        cookie.Expires = Now
        Response.Cookies.Add(cookie)

        Response.Redirect("~/LoginForm.aspx")
    End Sub
End Class