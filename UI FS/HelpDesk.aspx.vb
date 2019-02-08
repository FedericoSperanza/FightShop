
Partial Class HelpDesk
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'If Not (Page.IsPostBack) Then
        Actualizar()
        'End If
    End Sub

    Private Sub Actualizar()
        Me.divMensajes.Controls.Clear()
        Dim comentarios = BLL.Comentarios.GetInstance.GetForMesaDeAyuda(Session("MailUser"))
        For Each c As BE.Comentarios In comentarios
            Dim cc As userComments = Page.LoadControl("~/UserControls/userComments.ascx")
            cc.comment = c
            AddHandler cc.OnRefresh, AddressOf Actualizar
            Me.divMensajes.Controls.Add(cc)
        Next
    End Sub

    Protected Sub lbMisCompras_Click(sender As Object, e As EventArgs) Handles lbCC.Click
        Response.Redirect("MisCompras.Aspx")
    End Sub
    Protected Sub lbHelpDesk_Click(sender As Object, e As EventArgs) Handles lbMensajeria.Click
        Response.Redirect("HelpDesk.Aspx")
    End Sub

    Protected Sub btnEnviar_Click(sender As Object, e As EventArgs) Handles btnEnviar.Click
        Dim c As New BE.Comentarios

        c.body = Me.txtInput.Text
        c.usuario = Session("MailUser")
        c.fecha = DateTime.Today
        c.state = "PENDIENTE"


        BLL.Comentarios.GetInstance.AddHelpDesk(c)

        Me.txtInput.Text = ""
        Me.Actualizar()
    End Sub
End Class
