

Public Class userComments
    Inherits System.Web.UI.UserControl
    Public Event OnRefresh As EventHandler(Of String)

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AddHandler modalDialog.OnAccept, AddressOf PromtAccepted
    End Sub

    Public WriteOnly Property isHelpdeskAdmin As Boolean
        Set(value As Boolean)
            ViewState("isHelpdeskAdmin") = value
        End Set
    End Property



    Protected Sub PromtAccepted(sender As Object, value As String)
        Dim c As New BE.Comentarios

        'If ViewState("isHelpdeskAdmin") = True Then
        '    Dim U As New BE.usuarios
        '    U.id = -1

        'Else
        '    c.usuario = Session("MailUser")
        'End If

        c.usuario = Session("UserId")
        c.body = value
        c.idproducto = Session("idProdComent")





        ' BLL.Comentario.Add(c)
        RaiseEvent OnRefresh(sender, "")

    End Sub

    Public Property comment As BE.Comentarios
        Get
            Return Nothing
        End Get
        Set(value As BE.Comentarios)
            ViewState("comment") = value

            ''obtener mail del que comenta

            Me.divName.InnerText = value.usuario
            Me.divBody.InnerText = value.body
            Me.hdnId.Value = value.idcomentario

            '  ID DEL PRODUCTO
            'Dim comentarios As Integer = 0
            ''usa parentID no se que es..

            'For Each c As BE.Comentarios In comentarios

            '    Dim cc As New userComments
            '    cc = Page.LoadControl("~/UserControls/userComments.ascx")
            '    cc.comment = c

            '    AddHandler cc.OnRefresh, AddressOf PromtRefresh
            '    Me.divContainer.Controls.Add(cc)
            'Next
            Dim stringUsuario As String
            If Session("Nombre") IsNot Nothing And (Session("Apellido")) IsNot Nothing Then

                stringUsuario = Session("Nombre").ToString & " " & (Session("Apellido").ToString)

            Else

                stringUsuario = "Nadie"
            End If

            Me.btnDelete.Visible = (value.usuario = stringUsuario)
            'ver despues como manejar las respuestas..
            Me.btnReply.Visible = False
            'Me.btnReply.Visible = (value.usuario <> stringUsuario)
        End Set
    End Property

    Protected Sub PromtRefresh(sender As Object, value As String)
        RaiseEvent OnRefresh(sender, "")
    End Sub

    Public Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        BLL.Comentarios.GetInstance.Delete(Me.hdnId.Value)

        RaiseEvent OnRefresh(sender, "")
    End Sub

    Protected Sub btnReply_Click(sender As Object, e As EventArgs) Handles btnReply.Click
        modalDialog.Show("Respuesta", "")
    End Sub
End Class
