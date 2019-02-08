
Partial Class HelpDeskAdmin
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not (Page.IsPostBack) Then
            Actualizar()
            divMensajesContainer.Visible = False
        End If
        showComentario()
    End Sub



    Private Sub Actualizar()
        'Valido si puede acceder al modulo de administracion
        Dim idPermAdm = BLL.usuarios.GetInstance.GetidPermByUrl("HelpDeskAdmin.aspx")


        If Session("Nombre") IsNot Nothing Then



            If BLL.usuarios.GetInstance.PermiteAcceso(idPermAdm) Then
                ''No hago nada TODO OK!
            Else
                Response.Redirect("Home.Aspx")
            End If

        Else
            'Aca es si no hay si quiera user logueado
            Response.Redirect("Home.Aspx")
        End If


        'Me.divMensajes.Controls.Clear()
        Dim comentarios = BLL.Comentarios.GetInstance.GetForMesaDeAyudaAdmin()
        grd.DataSource = comentarios
        grd.DataBind()
        showComentario()

        'For Each c As BE.Comentario In comentarios
        '    Dim cc As userComment = Page.LoadControl("~/UserControls/userComment.ascx")
        '    cc.comment = c
        '    AddHandler cc.OnRefresh, AddressOf Actualizar
        '    Me.divMensajes.Controls.Add(cc)
        'Next
    End Sub
    Protected Sub grd_SelectedIndexChanging(sender As Object, e As GridViewSelectEventArgs) Handles grd.SelectedIndexChanging
        Dim r As GridViewRow = Me.grd.Rows(e.NewSelectedIndex)
        Dim ComentarioId = grd.DataKeys(e.NewSelectedIndex).Value

        ViewState("ComentarioId") = ComentarioId

        showComentario()
    End Sub

    Protected Sub grd_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles grd.PageIndexChanging
        grd.PageIndex = e.NewPageIndex
        Actualizar()
    End Sub

    Protected Sub grd_RowDeleting(sender As Object, e As GridViewDeleteEventArgs) Handles grd.RowDeleting
        Dim r As GridViewRow = Me.grd.Rows(e.RowIndex)
        Dim ComentarioId = grd.DataKeys(e.RowIndex).Value

        Try
            BLL.Comentarios.GetInstance.SetState(ComentarioId, "CERRADO")
            Actualizar()
        Catch ex As Exception
            ' Session("message") = New Message(Message.MessageType.Err, "Error", ex.Message)
            'TryCast(Me.Master, homefix).ShowMessage(New Message(Message.MessageType.Err, "Error", ex.Message))
        End Try
        Server.TransferRequest(Request.Url.AbsolutePath, False)
    End Sub

    Protected Sub showComentario()
        If ViewState("ComentarioId") Is Nothing Then
            Return
        End If

        Me.divMensajesContainer.Visible = True
        Dim comentario = BLL.Comentarios.GetInstance.GetById(ViewState("ComentarioId"))
        Dim cc As UserControls_helpUserComAdm = Page.LoadControl("~/UserControls/helpUserComAdm.ascx")
        cc.ID = "userComment_" + comentario.idcomentario.ToString
        cc.isHelpdeskAdmin = True
        AddHandler cc.OnRefresh, AddressOf Actualizar
        cc.comment = comentario
        Me.divMensajes.Controls.Clear()
        Me.divMensajes.Controls.Add(cc)
    End Sub




End Class
