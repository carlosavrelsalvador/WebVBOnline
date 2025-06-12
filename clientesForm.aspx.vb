Imports System.Security.Cryptography

Public Class clientesForm
    Inherits System.Web.UI.Page
    Public dst As DataSet
    Dim txtBuscar As String = String.Empty
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        VerificaCookie()
        ControlesIniciales()
        Poblar()

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
    Public Sub ControlesIniciales()
        field1.Enabled = False
        field2.Enabled = False
        field3.Enabled = False
        field4.Enabled = False
        field5.Enabled = False
        btnBuscar.Enabled = False
        btnBuscar.Visible = False
        'boton aceptar/guardar
        Button5.Enabled = False
        Button5.Visible = False
        'id configuracion inicial de ejecucion
        txtID.Text = "0"
        txtID.Enabled = False
        txtID.Visible = True

    End Sub
    Private Sub Poblar()
        Conexiones.AbrirConexion()
        Conexiones.Cnn.Open()

        Dim da As New SqlClient.SqlDataAdapter("select * from clientes where NOMBRE LIKE '%" & txtBuscar & "%'", Conexiones.Cnn)
        ' Dim ds As New DataSet
        dst = New DataSet
        da.Fill(dst)
        If dst.Tables(0).Rows.Count > 0 Then
            GridView1.DataSource = dst.Tables(0)
            GridView1.DataBind()
            'ocultando el boton de eliminar
            GridView1.Columns.Item(6).Visible = False
        Else
            GridView1.DataSource = Nothing
            GridView1.DataBind()
        End If


        Conexiones.Cnn.Close()
    End Sub
    Protected Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Poblar()

    End Sub
    Protected Sub OnRowDeleting(sender As Object, e As GridViewDeleteEventArgs)
        Dim item As String = Convert.ToInt32(e.Values.Keys(ID))

        Dim cmd As New SqlClient.SqlCommand("delete from estudiante where id=" & item, Conexiones.Cnn)
        cmd.ExecuteNonQuery()
    End Sub

    Protected Sub OnRowDataBound(sender As Object, e As GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim item As String = e.Row.Cells(0).Text
            For Each button As Button In e.Row.Cells(6).Controls.OfType(Of Button)()
                If button.CommandName = "Delete" Then
                    button.Attributes("onclick") = "if(!confirm('Do you want to delete " + item + "?')){ return false; };"


                End If
            Next
        End If
    End Sub

    Public Sub limpiarcajas()

    End Sub

    'boton cancelar
    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ControlesIniciales()
    End Sub

    'boton agregar nuevo
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        field1.Enabled = True
        field2.Enabled = True
        field3.Enabled = True
        field4.Enabled = True
        field5.Enabled = True
        Button5.Enabled = True
        Button5.Visible = True
        txtID.Text = "0"
        txtID.Enabled = False
        txtID.Visible = True
    End Sub
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        VerificaCookie()
        Dim condicion As Boolean = field1.Text <> "" And field2.Text <> "" And field3.Text <> "" And field4.Text <> "" And field5.Text <> ""
        If condicion Then
            Try
                Conexiones.AbrirConexion()
                Conexiones.Cnn.Open()

                If txtID.Text = "0" Then
                    Dim cmd As New SqlClient.SqlCommand("insert into clientes(nombre,correo,telefono,documento,direccion) values('" & field1.Text & "','" & field2.Text & "','" & field3.Text & "','" & field4.Text & "', '" & field5.Text & "')", Conexiones.Cnn)
                    cmd.ExecuteNonQuery()

                    Poblar()
                    Limpiar()
                Else
                    Dim cmd As New SqlClient.SqlCommand("update estudiante Set nombre='" & field1.Text & "',correo='" & field2.Text & "'telefono='" & field3.Text & "'documento='" & field4.Text & "'direccion='" & field5.Text & "' where id=" & txtID.Text, Conexiones.Cnn)
                    cmd.ExecuteNonQuery()

                    Poblar()
                    Limpiar()

                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        Else
            MsgBox("Rellene todos los Datos", vbCritical, "Login Error")
            Button5.Enabled = True
            Button5.Visible = True
        End If
    End Sub
    Private Sub Limpiar()
        txtID.Text = "0"
        field1.Text = ""
        field2.Text = ""
        field3.Text = ""
        field4.Text = ""
        field5.Text = ""
        field1.Focus()
    End Sub
End Class