Public Class reporte
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        GridView1.DataSource = Session("grid")
        GridView1.DataBind()
        lbFecha.Text = Session("fecha")
        lbMateria.Text = Session("materia")
        LbTotal.Text = Session("total")

        Session.Remove("grid")
        Session.Remove("fecha")
        Session.Remove("materia")
        Session.Remove("total")
    End Sub

End Class