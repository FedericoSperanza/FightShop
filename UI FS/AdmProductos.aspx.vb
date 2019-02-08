
Partial Class AdmProductos
    Inherits System.Web.UI.Page






    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not (Page.IsPostBack) Then

            CargarPagina()

        End If
    End Sub

    Public Sub CargarPagina()
        ''Valido si puede acceder al modulo de administracion
        Dim idPermAdm = BLL.usuarios.GetInstance.GetidPermByUrl("AdmProductos.aspx")


        If Session("Nombre") IsNot Nothing Then



            If BLL.usuarios.GetInstance.PermiteAcceso(idPermAdm) Then
                ''No hago nada TODO OK!
            Else
                Response.Redirect("Home.Aspx")
            End If

        Else
            ''Aca es si no hay si quiera user logueado
            Response.Redirect("Home.Aspx")
        End If

        Me.GV_Productos.DataSource = BLL.Productos.GetInstance.ListarAllProductos
        Me.GV_Productos.DataBind()

        ''Validar aca Permisos


        ''Carga de ddCategorias
        Dim lstCategorias As New List(Of BE.Categorias)
        lstCategorias = BLL.Categorias.GetInstance.ListarAllCategorias

        For Each Cat As BE.Categorias In lstCategorias
            Me.ddCategorias.Items.Add(Cat.nombre)
        Next

        ddCategorias.DataBind()




        BLL.Categorias.GetInstance.ListarAllCategorias()


        txtDescription.ReadOnly = True
        txtNombre.ReadOnly = True
        txtPrecio.ReadOnly = True
        txtDescuento.ReadOnly = True
        txtStock.ReadOnly = True
        UrlImagen.Enabled = False
        ddCategorias.Enabled = True



    End Sub

    Public Sub HabilitarCampos()
        txtDescription.ReadOnly = False
        txtNombre.ReadOnly = False
        txtPrecio.ReadOnly = False
        txtDescuento.ReadOnly = False
        txtStock.ReadOnly = False
        UrlImagen.Enabled = True
        ddCategorias.Enabled = True


    End Sub

    Public Sub InhabilitarCampos()
        txtDescription.ReadOnly = True
        txtNombre.ReadOnly = True
        txtPrecio.ReadOnly = True
        txtDescuento.ReadOnly = True
        txtStock.ReadOnly = True
        UrlImagen.Enabled = False
        ddCategorias.Enabled = False

    End Sub


    Public Sub ReiniciarCampos()
        txtDescription.Text = ""
        txtNombre.Text = ""
        txtPrecio.Text = ""
        txtDescuento.Text = ""
        txtStock.Text = ""
        txtUrlImagen.Text = ""

        UrlImagen.Dispose()


    End Sub

    Public Function ValidarCampos() As Boolean
        Dim resultado As Boolean = 0

        If txtDescription.Text = "" Or
            txtNombre.Text = "" Or
            txtPrecio.Text = "" Or
            txtDescuento.Text = "" Or
            txtStock.Text = "" Then

            regSuccess.Visible = True
            regSuccess.Focus()
            regSuccess.Attributes("class") = "alert alert-danger"
            regSuccess.InnerText = "Completar todos los CAMPOS !"
            resultado = 1
        Else
            resultado = 0
        End If

        Return resultado


    End Function


    Protected Sub GV_Productos_SelectedIndexChanging(sender As Object, e As GridViewSelectEventArgs) Handles GV_Productos.SelectedIndexChanging

        Dim txtDescripcionGV As String = CType(GV_Productos.Rows(e.NewSelectedIndex).FindControl("txtDescripcionGV"), TextBox).Text



        HabilitarCampos()



        txtNombre.Text = Me.GV_Productos.Rows(e.NewSelectedIndex).Cells(2).Text
        txtDescription.Text = txtDescripcionGV.ToString
        txtPrecio.Text = Me.GV_Productos.Rows(e.NewSelectedIndex).Cells(4).Text
        ddCategorias.SelectedItem.Text = Me.GV_Productos.Rows(e.NewSelectedIndex).Cells(5).Text
        txtUrlImagen.Text = Me.GV_Productos.Rows(e.NewSelectedIndex).Cells(6).Text
        txtDescuento.Text = Me.GV_Productos.Rows(e.NewSelectedIndex).Cells(7).Text
        txtStock.Text = Me.GV_Productos.Rows(e.NewSelectedIndex).Cells(8).Text

        Session("ProdModif") = txtNombre.Text
        txtNombre.Focus()
    End Sub


    Protected Sub GV_Productos_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GV_Productos.PageIndexChanging
        Me.GV_Productos.PageIndex = e.NewPageIndex
        With Me.GV_Productos
            .DataSource = BLL.Productos.GetInstance.ListarAllProductos
            .DataBind()
        End With



    End Sub




    Protected Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        HabilitarCampos()
        Session("FlagNew") = 1
        ReiniciarCampos()
        txtNombre.Focus()

    End Sub


    Protected Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click

        If ValidarCampos() = False Then






            ''En caso de Creacion de Producto



            If Session("FlagNew") = 1 Then
                Dim objNewProd As New BE.Productos
                'Obtencion del Id de la Categoria seleccionada

                objNewProd.categoria = BLL.Categorias.GetInstance.GetIdByNom(ddCategorias.SelectedItem.Text)
                objNewProd.nombre = txtNombre.Text
                objNewProd.descripcion = txtDescription.Text
                objNewProd.precio = txtPrecio.Text

                objNewProd.img = "Images/" + ddCategorias.SelectedItem.Text + "/" + UrlImagen.PostedFile.FileName
                objNewProd.descuento = txtDescuento.Text
                objNewProd.stock = txtStock.Text

                If BLL.Productos.GetInstance.CreateProd(objNewProd) Then
                    Session("FlagNew") = 0
                    Dim bitacorabl As New BLL.Bitacora
                    bitacorabl.GuardarINFOEnBitacora(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), Session("MailUser"), "Creacion de Producto")
                    regSuccess.Visible = True
                    regSuccess.Attributes("class") = "alert alert-success"
                    regSuccess.InnerText = "Producto Creado !"
                    CargarPagina()
                Else
                    regSuccess.Visible = True
                    regSuccess.Attributes("class") = "alert alert-danger"
                    regSuccess.InnerText = "Hubo un Error / El producto ya Existe !"

                End If



            Else
                'es modificacion
                Dim objProd As New BE.Productos
                objProd.categoria = BLL.Categorias.GetInstance.GetIdByNom(ddCategorias.SelectedItem.Text)
                objProd.nombre = txtNombre.Text
                objProd.descripcion = txtDescription.Text
                objProd.precio = txtPrecio.Text

                objProd.img = "Images/" + ddCategorias.SelectedItem.Text + "/" + UrlImagen.PostedFile.FileName
                objProd.descuento = txtDescuento.Text
                objProd.stock = txtStock.Text

                If BLL.Productos.GetInstance.UpdateProd(objProd, Session("ProdModif")) Then

                    Dim bitacorabl As New BLL.Bitacora
                    bitacorabl.GuardarINFOEnBitacora(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), Session("MailUser"), "Actualizacion de Producto")

                    Session("ProdModif") = Nothing

                    regSuccess.Visible = True
                    regSuccess.Attributes("class") = "alert alert-success"
                    regSuccess.InnerText = "Producto Modificado !"
                    regSuccess.Focus()
                    CargarPagina()
                Else
                    regSuccess.Visible = True
                    regSuccess.Attributes("class") = "alert alert-danger"
                    regSuccess.InnerText = "Hubo un Error !"
                    regSuccess.Focus()
                End If


                CargarPagina()
            End If
        Else
            regSuccess.Visible = True
            regSuccess.Attributes("class") = "alert alert-danger"
            regSuccess.InnerText = "Completar TODOS LOS CAMPOS !"
            regSuccess.Focus()
        End If



    End Sub


    Protected Sub GV_Productos_RowDeleting(sender As Object, e As GridViewDeleteEventArgs) Handles GV_Productos.RowDeleting

        'Obtengo el ID

        If BLL.Productos.GetInstance.DeleteProducto(Me.GV_Productos.Rows(e.RowIndex).Cells(2).Text) Then
            regSuccess.Visible = True
            regSuccess.Attributes("class") = "alert alert-success"
            regSuccess.InnerText = "Producto Eliminado !"
            regSuccess.Focus()
            CargarPagina()

        Else



        End If

    End Sub
    Protected Sub GV_Productos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GV_Productos.SelectedIndexChanged

    End Sub
End Class
