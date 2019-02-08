
Partial Class Noticias
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        If Not (Page.IsPostBack) Then


            CargarPagina()

        Else


        End If






    End Sub
    Public Sub CargarPagina()


        Dim dsnoticias As New List(Of BE.Noticias)
        dsnoticias = BLL.Noticias.ListarNoticias()





        rpt1.DataSource = dsnoticias

        rpt1.DataBind()



    End Sub




    Public Function LimitCharacter(ByVal labelText As String) As String
        Return (labelText.Substring(0, 40) + "...")
    End Function

    Public Sub ValidarCommand(sender As Object, e As CommandEventArgs)


        If (e.CommandName = "ShowNoticia") Then

            Session("NotiShow") = (e.CommandArgument.ToString)
            Response.Redirect("Noticia.Aspx")


        End If



        ' AñadirCheck()


    End Sub
End Class


