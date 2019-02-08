
Partial Class Tracking
    Inherits System.Web.UI.Page



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not (Page.IsPostBack) Then
            Actualizar()
        End If
    End Sub


    Private Sub Actualizar()



        Dim dstracking = BLL.CuentaCorriente.GetInstance.GetTrackingByUsuarioId(Session("UserId"))
        Me.grd.DataSource = dstracking
        Me.grd.DataBind()
    End Sub

    Protected Sub GV_Compras_Paginado(sender As Object, e As GridViewPageEventArgs) Handles grd.PageIndexChanging

        grd.PageIndex = e.NewPageIndex
        Actualizar()

        'verificar si tiene filtrado de fecha



    End Sub

    Protected Sub lbTracking_click(sender As Object, e As EventArgs) Handles lbTracking.Click
        Response.Redirect("Tracking.Aspx")
    End Sub

    Protected Sub lbMisCompras_Click(sender As Object, e As EventArgs) Handles lbMisCompras.Click
        Response.Redirect("MisCompras.Aspx")
    End Sub
    Protected Sub lbHelpDesk_Click(sender As Object, e As EventArgs) Handles lbHelpDesk.Click
        Response.Redirect("HelpDesk.Aspx")
    End Sub




End Class
