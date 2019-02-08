Public Class Categorias
    Private Sub New()  ''SINGLETON IDEM ABAJO

    End Sub


    Private Shared _instancia As MPP.Categorias   ''singleton

    Public Shared Function GetInstance() As MPP.Categorias

        If _instancia Is Nothing Then

            _instancia = New MPP.Categorias

        End If

        Return _instancia
    End Function





    Public Function DeleteCategoria(nom As String) As Boolean
        Dim oDatos As New DAL.BD
        Dim hdatos As New Hashtable
        Dim resultado As Integer

        hdatos.Add("@NombreCat", nom)



        resultado = oDatos.Escribir("sp_DeleteCategoria", hdatos)



        Return resultado

    End Function



    Public Function UpdateCat(objcat As BE.Categorias, catmodif As String) As Boolean

        Dim oDatos As New DAL.BD
        Dim hdatos As New Hashtable
        Dim resultado As Integer

        hdatos.Add("@Nombre", objcat.nombre)

        hdatos.Add("@NombreCatModif", catmodif)
        resultado = oDatos.Escribir("sp_UpdateCat", hdatos)

        Return resultado






    End Function




    Public Function CreateCat(obj As BE.Categorias) As Boolean
        Dim oDatos As New DAL.BD
        Dim hdatos As New Hashtable
        Dim resultado As Integer

        hdatos.Add("@Nombre", obj.nombre)



        resultado = oDatos.Escribir("sp_CreateCat", hdatos)



        Return resultado

    End Function

    Public Function GetIdByNom(nom As String) As Integer
        Dim oDatos As New DAL.BD
        Dim hdatos As New Hashtable
        Dim DS As New DataSet

        Dim categoria As Integer


        hdatos.Add("@Nombre", nom)

        DS = oDatos.Leer("sp_GetIdCategoria", hdatos)


        If DS.Tables(0).Rows.Count > 0 Then
            For Each item As DataRow In DS.Tables(0).Rows
                categoria = item(0)


            Next
            Return categoria
        Else
            Return Nothing

        End If

    End Function


    Public Function ValidarCatExiste(nombre As String) As Boolean

        Dim oDatos As New DAL.BD
        Dim hdatos As New Hashtable
        Dim DS As New DataSet
        Dim resultado As Boolean

        hdatos.Add("@Nombre", nombre)
        DS = oDatos.Leer("sp_ExisteCat", hdatos)

        If DS.Tables(0).Rows.Count > 0 Then
            resultado = True


            Return resultado
        Else
            resultado = False
            Return resultado

        End If




    End Function





    Public Function ListarCategorias() As List(Of BE.Categorias)

        Dim oDatos As New DAL.BD
        Dim hdatos As New Hashtable
        Dim DS As New DataSet
        Dim nomcat As BE.Categorias
        Dim lstCategorias As New List(Of BE.Categorias)


        DS = oDatos.Leer("sp_Categorias_ListAllNames", hdatos)

        If DS.Tables(0).Rows.Count > 0 Then
            For Each item As DataRow In DS.Tables(0).Rows
                nomcat = New BE.Categorias
                nomcat.id = item("idCategoria")
                nomcat.nombre = item("NombreCategoria")

                lstCategorias.Add(nomcat)

            Next
            Return lstCategorias
        Else
            Return Nothing

        End If




    End Function

    Public Shared Function ListarAllCategorias() As List(Of BE.Categorias)

        Dim oDatos As New DAL.BD
        Dim hdatos As New Hashtable
        Dim DS As New DataSet
        Dim CAT As BE.Categorias
        Dim lstCategorias As New List(Of BE.Categorias)


        DS = oDatos.Leer("sp_Categorias_ListAllNames", hdatos)

        If DS.Tables(0).Rows.Count > 0 Then
            For Each item As DataRow In DS.Tables(0).Rows
                CAT = New BE.Categorias
                CAT.nombre = item("NombreCategoria")

                lstCategorias.Add(CAT)

            Next
            Return lstCategorias
        Else
            Return Nothing

        End If




    End Function






End Class
