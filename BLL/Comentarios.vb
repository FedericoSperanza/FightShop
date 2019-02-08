Public Class Comentarios
    Private Sub New()  ''SINGLETON

    End Sub

    Private Shared _instancia As BLL.Comentarios

    Public Shared Function GetInstance() As BLL.Comentarios

        If _instancia Is Nothing Then

            _instancia = New BLL.Comentarios

        End If

        Return _instancia
    End Function

    Function GetForMesaDeAyudaAdmin() As List(Of BE.Comentarios)
        Return MPP.Comentarios.GetInstance.GetForMesaDeAyudaAdmin()
    End Function

    Sub SetState(id As Integer, estado As String)
        MPP.Comentarios.GetInstance.SetState(id, estado)
    End Sub

    Function GetById(id As Integer) As BE.Comentarios
        Return MPP.Comentarios.GetInstance.GetById(id)
    End Function

    Function GetByParent(parentId As Integer) As List(Of BE.Comentarios)
        Return MPP.Comentarios.GetInstance.GetByParent(parentId)
    End Function

    Shared Function GetForStatistics(desde As String, hasta As String) As Dictionary(Of String, Integer)
        Return MPP.Comentarios.GetForStatistics(desde + " 00:00", hasta + " 23:59")
    End Function




    Public Function GetByIdProducto(idProducto As Integer) As List(Of BE.Comentarios)

        Return MPP.Comentarios.GetInstance.GetByIdProducto(idProducto)
    End Function

    Public Function Add(c As BE.Comentarios) As Integer

        Return MPP.Comentarios.GetInstance.add(c)
    End Function

    Public Function AddHelpDesk(c As BE.Comentarios) As Integer

        Return MPP.Comentarios.GetInstance.addhelpdesk(c)
    End Function

    Function GetForMesaDeAyuda(mail As String) As List(Of BE.Comentarios)
        Return MPP.Comentarios.GetInstance.GetForMesaDeAyuda(mail)
    End Function



    Public Function Delete(id As Integer) As Integer

        Return MPP.Comentarios.GetInstance.Delete(id)
    End Function






End Class
