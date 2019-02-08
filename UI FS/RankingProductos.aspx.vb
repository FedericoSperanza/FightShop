
Partial Class RankingProductos
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        If Not (Page.IsPostBack) Then


            Dim dsProducto = BLL.Productos.GetInstance.GetRanking()
            Me.rpt1.DataSource = dsProducto
            Me.rpt1.DataBind()


        End If




    End Sub

    Public Sub ValidarCommand(sender As Object, e As CommandEventArgs)




        If (e.CommandName = "ShowProduct") Then

            Session("ProductShow") = BLL.Productos.GetInstance.getidproductobyname(e.CommandArgument.ToString)
            Response.Redirect("Producto.Aspx")


        End If



        ' AñadirCheck()


    End Sub
    Protected Sub rpt1_ItemDataBound(sender As Object, e As RepeaterItemEventArgs) Handles rpt1.ItemDataBound
        Dim indexItem As Integer = e.Item.ItemIndex

        If indexItem = 0 Then

        End If

        If indexItem = 1 Then

        End If

        If indexItem = 2 Then

        End If

        If indexItem = 3 Then

        End If



    End Sub
End Class
