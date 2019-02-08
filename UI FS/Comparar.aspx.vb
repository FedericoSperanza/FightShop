
Partial Class Comparar
    Inherits System.Web.UI.Page



    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load


        If Not (Page.IsPostBack) Then

            CargarPagina()

        End If



    End Sub


    Public Sub CargarPagina()
        Dim dsprodutos As List(Of BE.Productos)



        dsprodutos = BLL.Productos.GetInstance.ListarProductoById(Session("ProdCompare1"),
                                                                  Session("ProdCompare2"),
                                                                  Session("ProdCompare3"),
                                                                  Session("ProdCompare4"))
        rpt1.DataSource = dsprodutos
        Me.rpt1.DataBind()

    End Sub
End Class
