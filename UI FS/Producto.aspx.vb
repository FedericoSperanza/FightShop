Imports BE.GlobalUsuario
Imports AjaxControlToolkit
Public Class Producto
    Inherits System.Web.UI.Page



    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load


        If Not (Page.IsPostBack) Then

            cargarpagina()

        End If



    End Sub

    'Protected Sub OnRatingChanged(sender As Object, e As RatingEventArgs)
    '    Dim voto As Integer = e.Value

    '    BLL.Productos.GetInstance.Votar(voto, Session("ProductShow"))


    '    cargarpagina()


    '    ''actualizar lo marcado en la estrellita
    '    ' y poner variable de session de votado en 1



    'End Sub





    Sub cargarpagina()

        If Session("ProductShow") IsNot Nothing Then
            Dim oProducto As New BE.Productos
            oProducto = BLL.Productos.GetInstance.ListarUnProductoById(Session("ProductShow"))
            Me.img.ImageUrl = oProducto.img
            Me.lblNombre.Text = oProducto.nombre
            Me.lblDetails.Text = oProducto.descripcion
            Me.lblPrecio.Text = oProducto.precio




        Else
            Response.Redirect("Home.Aspx")
        End If

        If Session("Nombre") Is Nothing Then

            Me.dvComentario.Visible = False

        Else
            Me.dvComentario.Visible = True
        End If

        If Session("UserId") = Nothing Then

            dvComentario.Visible = False
        End If

        ddlCantidad.Items.Add("1")
        ddlCantidad.Items.Add("2")
        ddlCantidad.Items.Add("3")
        ddlCantidad.Items.Add("4")

        ' rating.CurrentRating = BLL.Productos.GetInstance.CurrentRatingProd(Session("ProductShow"))


    End Sub
    Private Sub ActualizarComments()
        Me.dvComments.Controls.Clear()

        'If Not Session("ProductShow") Is Nothing Then
        '    Dim id = CInt(Session("ProductShow"))
        '    Dim comentarios = BLL.Comentarios.GetInstance.GetByIdProducto(id)

        '    For Each c As BE.Comentarios In comentarios
        '        Dim cc As userComments = Page.LoadControl("~/UserControls/userComments.ascx")
        '        cc.comment = c
        '        AddHandler cc.OnRefresh, AddressOf PromtRefresh
        '        Me.dvComments.Controls.Add(cc)
        '    Next
        'End If



        If Not Session("ProductShow") Is Nothing Then
            Dim id = CInt(Session("ProductShow"))
            Dim comentarios = BLL.Comentarios.GetInstance.GetByIdProducto(id)

            If comentarios IsNot Nothing Then


                For Each c As BE.Comentarios In comentarios
                    Dim cc As userComments = Page.LoadControl("~/UserControls/userComments.ascx")

                    cc.comment = c
                    AddHandler cc.OnRefresh, AddressOf PromtRefresh
                    Me.dvComments.Controls.Add(cc)
                Next
            End If
        End If
    End Sub

    Protected Sub PromtRefresh(sender As Object, value As String)
        ActualizarComments()
    End Sub

    Private Sub Producto_Init(sender As Object, e As EventArgs) Handles Me.Init
        ActualizarComments()
    End Sub





    ''AL COMENTAR CARGAR LA VARIABLE DE SESION Session("idProdComent") QUE SE USA EN USERCONTROL COMENTAR
    Protected Sub btnComentar_Click(sender As Object, e As EventArgs) Handles btnComentar.Click
        If Session("UserID") IsNot Nothing Then


            Dim c As New BE.Comentarios
            Dim id = CInt(Session("ProductShow"))
            c.body = Me.txtComentario.Text

            c.usuario = Session("Nombre").ToString & " " & Session("Apellido").ToString
            c.idproducto = id

            BLL.Comentarios.GetInstance.Add(c)

            txtComentario.Text = ""
            Me.ActualizarComments()
        Else

            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Pop", "openModal();", True)
            Dim txtLogin As New HtmlInputGenericControl
            txtLogin = Master.FindControl("txtEmail")

            txtLogin.Focus()
        End If

    End Sub
    Protected Sub btnAddCart_Click(sender As Object, e As EventArgs) Handles btnAddCart.Click
        Dim oProducto As New BE.Cart

        oProducto.cantidad = ddlCantidad.SelectedValue
        oProducto.nombre = lblNombre.Text
        oProducto.descripcion = lblDetails.Text
        oProducto.img = img.ImageUrl
        oProducto.precio = lblPrecio.Text



        If Session("Cart") Is Nothing Then
            GlobalCart = New List(Of BE.Cart)
            Dim lstcart As New List(Of BE.Cart)
            lstcart.Add(oProducto)
            Session("Cart") = lstcart


        Else
            Session("CartNewProd") = lblNombre.Text
            Session("oNewProd") = oProducto
            Session("Cart").add(oProducto)
            'GlobalCart.Add(oProducto)
            '  Session("Cart") = GlobalCart
            ' Session("list").Add("record #1")
        End If





        Response.Redirect("Cart.Aspx")

    End Sub
    Protected Sub lbVolver_Click(sender As Object, e As EventArgs) Handles lbVolver.Click
        Response.Redirect("Catalogo.Aspx")
    End Sub
End Class
