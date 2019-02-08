
Partial Class UserControls_helpUserComAdm
    Inherits System.Web.UI.UserControl


    Public Event OnRefresh As EventHandler(Of String)

    Public WriteOnly Property isHelpdeskAdmin As Boolean
        Set(value As Boolean)
            ViewState("isHelpdeskAdmin") = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AddHandler modalDialog.OnAccept, AddressOf PromtAccepted
        'ViewState("isHelpdeskAdmin") = False
    End Sub
    Protected Sub PromtAccepted(sender As Object, value As String)
        Dim c As New BE.Comentarios

        If ViewState("isHelpdeskAdmin") = True Then
            Dim U As New BE.usuarios
            U.user = "none"
            c.usuario = "none"
        Else
            c.usuario = Session("MailUser")
        End If

        c.parent = BLL.Comentarios.GetInstance.GetById(Me.hdnId.Value)
        'c.publicacion = c.parent.publicacion
        c.body = value
        c.state = "ACEPTADO"
        BLL.Comentarios.GetInstance.AddHelpDesk(c)
        RaiseEvent OnRefresh(sender, "")
    End Sub

    Public Property comment As BE.Comentarios
        Get
            Return Nothing
        End Get
        Set(value As BE.Comentarios)
            ViewState("comment") = value
            Me.divName.InnerText = value.usuario
            Me.divBody.InnerText = value.body
            Me.hdnId.Value = value.idcomentario
            Dim comentarios = BLL.Comentarios.GetInstance.GetByParent(value.idcomentario)
            For Each c As BE.Comentarios In comentarios
                Dim cc As UserControls_helpUserComAdm = Page.LoadControl("~/UserControls/helpUserComAdm.ascx")
                cc.isHelpdeskAdmin = ViewState("isHelpdeskAdmin")
                cc.comment = c
                AddHandler cc.OnRefresh, AddressOf PromtRefresh
                Me.divContainer.Controls.Add(cc)
            Next
            Dim currentUserId = IIf(ViewState("isHelpdeskAdmin"), "none", Session("MailUser"))
            Me.btnDelete.Visible = False '(value.owner.id = currentUserId And value.state <> "DELETED")
            Me.btnReply.Visible = (value.usuario <> currentUserId And value.state <> "DELETED")
        End Set
    End Property

    Protected Sub PromtRefresh(sender As Object, value As String)
        RaiseEvent OnRefresh(sender, "")
    End Sub

    Protected Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        BLL.Comentarios.GetInstance.Delete(Me.hdnId.Value)
        RaiseEvent OnRefresh(sender, "")
    End Sub

    Protected Sub btnReply_Click(sender As Object, e As EventArgs) Handles btnReply.Click
        modalDialog.Show("Respuesta", "")
    End Sub


End Class
