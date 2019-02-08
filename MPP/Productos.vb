Public Class Productos
    Private Sub New()  ''SINGLETON IDEM ABAJO

    End Sub


    Private Shared _instancia As MPP.Productos   ''singleton

    Public Shared Function GetInstance() As MPP.Productos

        If _instancia Is Nothing Then

            _instancia = New MPP.Productos

        End If

        Return _instancia
    End Function




    Public Shared Function ProductosGetIdCategoria(nombre As String) As Integer

        Dim oDatos As New DAL.BD
        Dim hdatos As New Hashtable
        Dim DS As New DataSet
        Dim idCategoria As Integer

        hdatos.Add("@Nombre", nombre)
        DS = oDatos.Leer("sp_GetIdCategoria", hdatos)

        If DS.Tables(0).Rows.Count > 0 Then
            For Each item As DataRow In DS.Tables(0).Rows
                idCategoria = item("idCategoria")
            Next



            Return idCategoria
        Else
            Return Nothing

        End If




    End Function



    Public Function GetRanking() As List(Of BE.Ranking)

        Dim oDatos As New DAL.BD
        Dim hdatos As New Hashtable
        Dim DS As New DataSet
        Dim oRanking As BE.Ranking
        Dim lstRanking As New List(Of BE.Ranking)


        DS = oDatos.Leer("sp_Productos_GetRanking", hdatos)

        If DS.Tables(0).Rows.Count > 0 Then
            For Each item As DataRow In DS.Tables(0).Rows
                oRanking = New BE.Ranking

                oRanking.rank = item("Ranking")
                oRanking.idproducto = item("idProducto")
                oRanking.nombre = item("nombre")
                oRanking.Detalle = item("detalle")
                oRanking.img = item("imagen")
                oRanking.precio = item("precio")

                lstRanking.Add(oRanking)
            Next



            Return lstRanking
        Else
            Return Nothing

        End If




    End Function





    Public Function CurrentRatingProd(idproducto As Integer) As Integer

        Dim oDatos As New DAL.BD
        Dim hdatos As New Hashtable
        Dim DS As New DataSet
        Dim Rating As Integer

        hdatos.Add("@idProd", idproducto)
        DS = oDatos.Leer("sp_Producto_GetValoracion", hdatos)

        If DS.Tables(0).Rows.Count > 0 Then
            For Each item As DataRow In DS.Tables(0).Rows
                Rating = item("Rank")
            Next



            Return Rating
        Else
            Return Nothing

        End If




    End Function


    Public Shared Function getidproductobyname(nombre As String) As Integer

        Dim oDatos As New DAL.BD
        Dim hdatos As New Hashtable
        Dim DS As New DataSet
        Dim idCategoria As Integer

        hdatos.Add("@Nombre", nombre)
        DS = oDatos.Leer("sp_GetIdProducto", hdatos)

        If DS.Tables(0).Rows.Count > 0 Then
            For Each item As DataRow In DS.Tables(0).Rows
                idCategoria = item("idProducto")
            Next



            Return idCategoria
        Else
            Return Nothing

        End If




    End Function
    Public Function ValidarProdExiste(nombre As String) As Boolean

        Dim oDatos As New DAL.BD
        Dim hdatos As New Hashtable
        Dim DS As New DataSet
        Dim resultado As Boolean

        hdatos.Add("@Nombre", nombre)
        DS = oDatos.Leer("sp_ExisteProd", hdatos)

        If DS.Tables(0).Rows.Count > 0 Then
            resultado = True


            Return resultado
        Else
            resultado = False
            Return resultado

        End If




    End Function



    Public Function Votar(voto As Integer, idprod As Integer) As Boolean

        Dim oDatos As New DAL.BD
        Dim hdatos As New Hashtable

        Dim resultado As Boolean

        hdatos.Add("@voto", voto)
        hdatos.Add("@idprod", idprod)

        Return resultado = oDatos.Escribir("sp_ProductosVotar", hdatos)







    End Function



    Public Function UpdateProd(objprod As BE.Productos, prodmodif As String) As Boolean

        Dim oDatos As New DAL.BD
        Dim hdatos As New Hashtable
        Dim resultado As Integer

        hdatos.Add("@Nombre", objprod.nombre)
        hdatos.Add("@Detalle", objprod.descripcion)
        hdatos.Add("@Precio", objprod.precio)
        hdatos.Add("@Descuento", objprod.descuento)
        hdatos.Add("@Imagen", objprod.img)
        hdatos.Add("@Stock", objprod.stock)
        hdatos.Add("@idCategoria", objprod.categoria)
        hdatos.Add("@ProdModif", prodmodif)

        resultado = oDatos.Escribir("sp_UpdateProd", hdatos)

        Return resultado






    End Function

    Public Function CreateProd(obj As BE.Productos) As Boolean
        Dim oDatos As New DAL.BD
        Dim hdatos As New Hashtable
        Dim resultado As Integer

        hdatos.Add("@Nombre", obj.nombre)
        hdatos.Add("@Detalle", obj.descripcion)
        hdatos.Add("@Precio", obj.precio)
        hdatos.Add("@Descuento", obj.descuento)
        hdatos.Add("@Imagen", obj.img)
        hdatos.Add("@Stock", obj.stock)
        hdatos.Add("@idCategoria", obj.categoria)



        resultado = oDatos.Escribir("sp_CreateProd", hdatos)



        Return resultado

    End Function



    Public Function DeleteProducto(nom As String) As Boolean
        Dim oDatos As New DAL.BD
        Dim hdatos As New Hashtable
        Dim resultado As Integer

        hdatos.Add("@NomProd", nom)



        resultado = oDatos.Escribir("sp_DeleteProducto", hdatos)



        Return resultado

    End Function

    Public Shared Function ListarAllProductos() As List(Of BE.Productos)

        Dim oDatos As New DAL.BD
        Dim hdatos As New Hashtable
        Dim DS As New DataSet
        Dim oProducto As BE.Productos
        Dim lstProducto As New List(Of BE.Productos)


        DS = oDatos.Leer("sp_Productos_ListAll", hdatos)

        If DS.Tables(0).Rows.Count > 0 Then
            For Each item As DataRow In DS.Tables(0).Rows
                oProducto = New BE.Productos
                oProducto.nombre = item("Nombre")
                oProducto.descripcion = item("Detalle")
                oProducto.precio = item("Precio")
                oProducto.descuento = item("Descuento")
                oProducto.img = item("Imagen")
                oProducto.stock = item("Stock")
                oProducto.categoria = item("NombreCategoria")
                lstProducto.Add(oProducto)

            Next
            Return lstProducto
        Else
            Return Nothing

        End If




    End Function




    Public Shared Function ProductosFiltrarCatalogo(Optional q As String = "",
                                                   Optional idCategoria As Integer? = Nothing,
                               Optional precioMin As Double? = Nothing,
                               Optional precioMax As Double? = Nothing) As List(Of BE.Productos)

        Dim oDatos As New DAL.BD
        Dim hdatos As New Hashtable
        Dim DS As New DataSet
        Dim oProducto As BE.Productos
        Dim lstProducto As New List(Of BE.Productos)

        hdatos.Add("@idCategoria", idCategoria)
        hdatos.Add("@PrecioMin", precioMin)
        hdatos.Add("@PrecioMax", precioMax)


        DS = oDatos.Leer("sp_Filter_Productos", hdatos)

        If DS.Tables(0).Rows.Count > 0 Then
            For Each item As DataRow In DS.Tables(0).Rows
                oProducto = New BE.Productos
                ''BORRAR IDPRODUCTO DSPS
                oProducto.id = item("idProducto")
                oProducto.nombre = item("Nombre")
                oProducto.precio = item("Precio")
                oProducto.img = item("Imagen")

                lstProducto.Add(oProducto)
            Next
            Return lstProducto
        Else
            Return Nothing

        End If




    End Function


    Public Shared Function ListarProductos(idcategoria As String) As List(Of BE.Productos)

        Dim oDatos As New DAL.BD
        Dim hdatos As New Hashtable
        Dim DS As New DataSet
        Dim oProducto As BE.Productos
        Dim lstProducto As New List(Of BE.Productos)

        hdatos.Add("@idCategoria", idcategoria)
        DS = oDatos.Leer("sp_Productos_ListByCat", hdatos)

        If DS.Tables(0).Rows.Count > 0 Then
            For Each item As DataRow In DS.Tables(0).Rows
                oProducto = New BE.Productos
                oProducto.nombre = item("Nombre")
                oProducto.precio = item("Precio")
                oProducto.img = item("Imagen")

                lstProducto.Add(oProducto)
            Next
            Return lstProducto
        Else
            Return Nothing

        End If

    End Function



    Function ListarUnProductoById(id1 As Integer) As BE.Productos
        Dim oDatos As New DAL.BD
        Dim hdatos As New Hashtable
        Dim DS As New DataSet
        Dim oProducto As New BE.Productos


        hdatos.Add("@id1", id1)



        DS = oDatos.Leer("sp_Producto_ListById", hdatos)

        If DS.Tables(0).Rows.Count > 0 Then
            For Each item As DataRow In DS.Tables(0).Rows

                oProducto.nombre = item("Nombre")
                oProducto.precio = item("Precio")
                oProducto.img = item("Imagen")
                oProducto.descripcion = item("Detalle")

            Next

            Return oProducto
        Else
            Return Nothing

        End If

    End Function
    Function ListarProductoById(id1 As Integer, id2 As Integer, Optional id3 As Integer? = Nothing, Optional id4 As Integer? = Nothing) As List(Of BE.Productos)
        Dim oDatos As New DAL.BD
        Dim hdatos As New Hashtable
        Dim DS As New DataSet
        Dim oProducto As BE.Productos
        Dim lstProducto As New List(Of BE.Productos)

        hdatos.Add("@id1", id1)
        hdatos.Add("@id2", id2)
        hdatos.Add("@id3", id3)
        hdatos.Add("@id4", id4)


        DS = oDatos.Leer("sp_Productos_ListById", hdatos)

        If DS.Tables(0).Rows.Count > 0 Then
            For Each item As DataRow In DS.Tables(0).Rows
                oProducto = New BE.Productos
                oProducto.nombre = item("Nombre")
                oProducto.precio = item("Precio")
                oProducto.img = item("Imagen")
                oProducto.descripcion = item("Detalle")

                lstProducto.Add(oProducto)
            Next
            Return lstProducto
        Else
            Return Nothing

        End If

    End Function

End Class
