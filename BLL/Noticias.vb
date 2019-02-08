Public Class Noticias
    Private Sub New()  ''SINGLETON

    End Sub

    Private Shared _instancia As BLL.Noticias

    Public Shared Function GetInstance() As BLL.Noticias

        If _instancia Is Nothing Then

            _instancia = New BLL.Noticias

        End If

        Return _instancia
    End Function

    Public Function DeleteNoticia(id As Integer) As Boolean


        Return MPP.Noticias.GetInstance.deletenoticia(id)

    End Function



    Public Function getidNotiByName(nombre As String) As Integer
        Return MPP.Noticias.getidNotiByName(nombre)

    End Function


    Public Shared Function ListarNoticias() As List(Of BE.Noticias)

        Return MPP.Noticias.ListarNoticias()

    End Function

    Public Function UpdateNoticia(objNoti As BE.Noticias, notimodif As String) As Boolean

        Return MPP.Noticias.GetInstance.UpdateNoticia(objNoti, notimodif)

    End Function

    Public Function ListarUnaNoticiaById(id As Integer) As BE.Noticias

        Return MPP.Noticias.GetInstance.ListarUnaNoticiaById(id)
    End Function

    Public Function CreateNoticia(objnoti As BE.Noticias) As Boolean

        Return MPP.Noticias.GetInstance.CreateNoticia(objnoti)
    End Function

End Class
