Public Class Noticias
    Private Sub New()  ''SINGLETON IDEM ABAJO

    End Sub


    Private Shared _instancia As MPP.Noticias   ''singleton

    Public Shared Function GetInstance() As MPP.Noticias

        If _instancia Is Nothing Then

            _instancia = New MPP.Noticias

        End If

        Return _instancia
    End Function


    Public Function deletenoticia(id As Integer) As Boolean
        Dim oDatos As New DAL.BD
        Dim hdatos As New Hashtable
        Dim resultado As Integer

        hdatos.Add("@id", id)



        resultado = oDatos.Escribir("sp_DeleteNoticia", hdatos)



        Return resultado

    End Function

    Public Function UpdateNoticia(objnoti As BE.Noticias, notimodif As String) As Boolean

        Dim oDatos As New DAL.BD
        Dim hdatos As New Hashtable
        Dim resultado As Integer

        hdatos.Add("@Nombre", objnoti.nombre)
        hdatos.Add("@Descripcion", objnoti.descripcion)
        hdatos.Add("@FechaCaduc", objnoti.fechacaduc)
        hdatos.Add("@img", objnoti.img)
        hdatos.Add("@NotiModif", notimodif)


        resultado = oDatos.Escribir("sp_UpdateNoticia", hdatos)

        Return resultado






    End Function



    Public Shared Function getidNotiByName(nombre As String) As Integer

        Dim oDatos As New DAL.BD
        Dim hdatos As New Hashtable
        Dim DS As New DataSet
        Dim idNoticia As Integer

        hdatos.Add("@Nombre", nombre)
        DS = oDatos.Leer("sp_GetIdNoticia", hdatos)

        If DS.Tables(0).Rows.Count > 0 Then
            For Each item As DataRow In DS.Tables(0).Rows
                idNoticia = item("idNoticia")
            Next



            Return idNoticia
        Else
            Return Nothing

        End If

    End Function

    Public Function CreateNoticia(obj As BE.Noticias) As Boolean
        Dim oDatos As New DAL.BD
        Dim hdatos As New Hashtable
        Dim resultado As Integer

        hdatos.Add("@Nombre", obj.nombre)
        hdatos.Add("@Descripcion", obj.descripcion)
        hdatos.Add("@img", obj.img)
        hdatos.Add("@FechaCaduc", obj.fechacaduc)




        resultado = oDatos.Escribir("sp_CreateNoticia", hdatos)



        Return resultado

    End Function



    Function ListarUnaNoticiaById(id As Integer) As BE.Noticias
        Dim oDatos As New DAL.BD
        Dim hdatos As New Hashtable
        Dim DS As New DataSet
        Dim oNoticias As New BE.Noticias


        hdatos.Add("@id", id)



        DS = oDatos.Leer("sp_Noticia_ListById", hdatos)

        If DS.Tables(0).Rows.Count > 0 Then
            For Each item As DataRow In DS.Tables(0).Rows

                oNoticias.nombre = item("Nombre")

                oNoticias.img = item("img")
                oNoticias.descripcion = item("descripcion")

            Next

            Return oNoticias
        Else
            Return Nothing

        End If

    End Function
    Public Shared Function ListarNoticias() As List(Of BE.Noticias)

        Dim oDatos As New DAL.BD
        Dim hdatos As New Hashtable
        Dim DS As New DataSet
        Dim oNoticias As BE.Noticias
        Dim lstNoticias As New List(Of BE.Noticias)


        DS = oDatos.Leer("sp_Noticias_ListAllAdm", hdatos)

        If DS.Tables(0).Rows.Count > 0 Then
            For Each item As DataRow In DS.Tables(0).Rows
                oNoticias = New BE.Noticias
                oNoticias.nombre = item("Nombre")
                oNoticias.id = item("idNoticia")
                oNoticias.descripcion = item("Descripcion")
                oNoticias.img = item("img")
                oNoticias.fechacaduc = item("FechaCaducidad")

                lstNoticias.Add(oNoticias)
            Next
            Return lstNoticias
        Else
            Return Nothing

        End If

    End Function



End Class
