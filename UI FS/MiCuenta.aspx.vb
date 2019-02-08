
Partial Class MiCuenta
    Inherits System.Web.UI.Page

    Protected Sub lbMisCompras_Click(sender As Object, e As EventArgs) Handles lbMisCompras.Click
        Response.Redirect("MisCompras.Aspx")
    End Sub
    Protected Sub lbHelpDesk_Click(sender As Object, e As EventArgs) Handles lbHelpDesk.Click
        Response.Redirect("HelpDesk.Aspx")
    End Sub


End Class
