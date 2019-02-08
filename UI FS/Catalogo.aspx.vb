
Partial Class KimonosCat
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Session("ClickPay") = False
        If Not (Page.IsPostBack) Then

            If Session("ProdFilter") = Nothing Then

                Session("ProdFilter") = 0

                Dim dsProducto = BLL.Productos.ListarProductos(Session("ProdFilter"))
                Me.rpt1.DataSource = dsProducto
                Me.rpt1.DataBind()

            Else



                Dim idCategoria = BLL.Productos.GetInstance.GetIdCategoria(Session("ProdFilter").ToString)
                Dim dsProducto = BLL.Productos.ListarProductos(idCategoria)
                Me.rpt1.DataSource = dsProducto
                Me.rpt1.DataBind()


            End If

            CargarPagina()

        Else


        End If






    End Sub


    Public Sub CargarPagina()
        If Session("SearchQ") IsNot Nothing Then
            Server.TransferRequest(Session("SearchQ"), False)
        End If

        Session("ProdCompare1") = Nothing
        Session("ProdCompare2") = Nothing
        Session("ProdCompare3") = Nothing
        Session("ProdCompare4") = Nothing
        Dim lstCategorias As New List(Of BE.Categorias)
        Dim dsproductos As New List(Of BE.Productos)
        dsproductos = BLL.Productos.FiltrarCatalogo()
        lstCategorias = BLL.Categorias.GetInstance.ListarAllCategorias()
        For Each item As BE.Categorias In lstCategorias
            Me.ddlCategoria.Items.Add(item.nombre)
        Next

        If Request.QueryString("q") IsNot Nothing Then
            'And ViewState("q") IsNot Nothing 
            Dim q As String = Request.QueryString("q").ToLower
            ViewState("q") = q

            Me.rpt1.DataSource = dsproductos.FindAll(Function(x) x.nombre.ToLower.Contains(q))

        ElseIf Session("ProdFilter") Is Nothing Then

            rpt1.DataSource = dsproductos

        End If

        rpt1.DataBind()



    End Sub

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        '  Session("SearchQ") = Request.Url.AbsolutePath + "?q=" + txtsearch.Text
        Dim url = Request.Url.AbsolutePath + "?q=" + txtsearch.Text
        Server.TransferRequest(url, False)


    End Sub




    ''Metodo para tomar el precio de cada producto que se puso como Añadir Compra
    Public Sub ValidarCommand(sender As Object, e As CommandEventArgs)

        If (e.CommandName = "AddCart") Then
            'e.CommandArgument
            MsgBox("Precio" + e.CommandArgument.ToString)


        End If

        If (e.CommandName = "CheckProduct") Then
            btnComparar.Visible = True



        End If
        If (e.CommandName = "ShowProduct") Then

            Session("ProductShow") = BLL.Productos.GetInstance.getidproductobyname(e.CommandArgument.ToString)
            Response.Redirect("Producto.Aspx")


        End If



        ' AñadirCheck()


    End Sub


    ''Metodo para tomar los checkeados para comparar
    ''Llenar en una lista los nombres y consultar en BD para obtener comparaciones (obtener su ID a partir del nombre)
    Public Function AñadirCheck() As Integer
        Dim cantCheck As Integer = 0
        Dim lstprodcompare As New List(Of Integer)
        For Each item As RepeaterItem In rpt1.Items
            Dim chkdisplaytitle As HtmlInputCheckBox = CType(item.FindControl("chkCompare"), HtmlInputCheckBox)
            If chkdisplaytitle.Checked Then
                Dim nombreprod As Label


                nombreprod = item.FindControl("lblNombre")
                If Session("ProdCompare1") = Nothing And cantCheck = 0 Then
                    Session("ProdCompare1") = (BLL.Productos.GetInstance.getidproductobyname(nombreprod.Text))

                End If
                If Session("ProdCompare2") = Nothing And cantCheck = 1 Then
                    Session("ProdCompare2") = (BLL.Productos.GetInstance.getidproductobyname(nombreprod.Text))

                End If
                If Session("ProdCompare3") = Nothing And cantCheck = 2 Then
                    Session("ProdCompare3") = (BLL.Productos.GetInstance.getidproductobyname(nombreprod.Text))

                End If
                If Session("ProdCompare4") = Nothing And cantCheck = 3 Then
                    Session("ProdCompare4") = (BLL.Productos.GetInstance.getidproductobyname(nombreprod.Text))

                End If

                cantCheck = cantCheck + 1

            End If




        Next


        If cantCheck >= 5 Then
            Session("maxCheck") = 1


            Return 0
        Else
            Return cantCheck
        End If




    End Function

    'checkBox Function JAVASCRIPT
    Protected Sub btnCompare(sender As Object, e As EventArgs) Handles btnComparar.Click

        If AñadirCheck() > 1 Then
            Response.Redirect("Comparar.Aspx")
        ElseIf Session("maxCheck") = 1 Then
            regSuccess.Visible = True
            regSuccess.Attributes("class") = "alert alert-danger"
            regSuccess.InnerText = "Seleccionar un maximo de 4 Productos  !"
            Session("maxCheck") = Nothing
        Else
            regSuccess.Visible = True
            regSuccess.Attributes("class") = "alert alert-danger"
            regSuccess.InnerText = "Seleccionar mas Productos  !"

        End If



    End Sub



    Protected Sub btnFiltrar_Click(sender As Object, e As EventArgs) Handles btnFiltrar.Click
        Dim q As String = ViewState("q")
        Dim CategoriaId As Integer? = Nothing
        Dim precioMin As Double? = Nothing
        Dim precioMax As Double? = Nothing

        'If Me.ddlCategoria.SelectedValue > -1 Then
        '    CategoriaId = CInt(Me.ddlCategoria.SelectedValue)
        'End If

        CategoriaId = BLL.Categorias.GetInstance.GetIdByNom(ddlCategoria.SelectedItem.Text)

        If IsNumeric(Me.txtDesde.Text) Then
            precioMin = CDbl(Me.txtDesde.Text)
        End If

        If IsNumeric(Me.txtDesde.Text) Then
            precioMax = CDbl(Me.txtHasta.Text)
        End If

        Dim dsCatalogo As List(Of BE.Productos) = BLL.Productos.FiltrarCatalogo(q, CategoriaId, precioMin, precioMax)
        Me.rpt1.DataSource = dsCatalogo
        Me.rpt1.DataBind()
    End Sub
End Class
