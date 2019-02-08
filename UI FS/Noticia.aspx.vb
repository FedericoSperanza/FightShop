
Partial Class Noticia
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load


        If Not (Page.IsPostBack) Then

            cargarpagina()

        End If



    End Sub
    Sub cargarpagina()

        If Session("NotiShow") IsNot Nothing Then
            Dim oNoticia As New BE.Noticias
            oNoticia = BLL.Noticias.GetInstance.ListarUnaNoticiaById(Session("NotiShow"))
            Me.img.ImageUrl = oNoticia.img
            Me.lblNombre.Text = oNoticia.nombre
            Me.lblDetails.Text = oNoticia.descripcion





        Else
            Response.Redirect("Home.Aspx")
        End If

    End Sub
End Class
