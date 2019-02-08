Public Class Productos

    Private Sub New()  ''SINGLETON

    End Sub

    Private Shared _instancia As BLL.Productos

    Public Shared Function GetInstance() As BLL.Productos

        If _instancia Is Nothing Then

            _instancia = New BLL.Productos

        End If

        Return _instancia
    End Function




    Shared Function FiltrarCatalogo(Optional q As String = "",
                               Optional idCategoria As Integer? = Nothing,
                               Optional precioMin As Double? = Nothing,
                               Optional precioMax As Double? = Nothing
                               ) As List(Of BE.Productos)
        Return MPP.Productos.ProductosFiltrarCatalogo(q, idCategoria, precioMin, precioMax)
    End Function

    Public Function Votar(voto As Integer, idprod As Integer) As Boolean

        Return MPP.Productos.GetInstance.Votar(voto, idprod)

    End Function

    Public Shared Function ListarProductos(idCategoria As String) As List(Of BE.Productos)

        Return MPP.Productos.ListarProductos(idCategoria)

    End Function


    Public Function CurrentRatingProd(idProducto As Integer) As Integer

        Return MPP.Productos.GetInstance.CurrentRatingProd(idProducto)
    End Function

    Public Function GetRanking() As List(Of BE.Ranking)

        Return MPP.Productos.GetInstance.GetRanking()
    End Function


    Public Function ListarProductoById(id1 As Integer, id2 As Integer, Optional id3 As Integer? = Nothing, Optional id4 As Integer? = Nothing) As List(Of BE.Productos)

        Return MPP.Productos.GetInstance.ListarProductoById(id1, id2, id3, id4)
    End Function

    Public Function ListarUnProductoById(id1 As Integer) As BE.Productos

        Return MPP.Productos.GetInstance.ListarUnProductoById(id1)
    End Function

    Public Function getidproductobyname(nom As String) As Integer

        Return MPP.Productos.getidproductobyname(nom)
    End Function
    Public Function ListarAllProductos() As List(Of BE.Productos)

        Return MPP.Productos.ListarAllProductos()

    End Function

    Public Function GetIdCategoria(nombre As String) As Integer

        Return MPP.Productos.ProductosGetIdCategoria(nombre)

    End Function

    Public Function CreateProd(obj As BE.Productos) As Boolean
        Dim resultado As Boolean

        If MPP.Productos.GetInstance.ValidarProdExiste(obj.nombre) = True Then
            resultado = False
        Else
            MPP.Productos.GetInstance.CreateProd(obj)
            resultado = True
        End If

        Return resultado


    End Function

    Public Function UpdateProd(objprod As BE.Productos, prodmodif As String) As Boolean

        Return MPP.Productos.GetInstance.UpdateProd(objprod, prodmodif)

    End Function

    Public Function DeleteProducto(NOM As String) As Boolean


        Return MPP.Productos.GetInstance.DeleteProducto(NOM)
    End Function


End Class
