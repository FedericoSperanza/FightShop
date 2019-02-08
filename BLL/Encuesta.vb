Public Class Encuesta
    Private Sub New()  ''SINGLETON

    End Sub

    Private Shared _instancia As BLL.Encuesta

    Public Shared Function GetInstance() As BLL.Encuesta

        If _instancia Is Nothing Then

            _instancia = New BLL.Encuesta

        End If

        Return _instancia
    End Function

    Public Function GetAll(Optional FichaOpinion As Boolean = False) As List(Of BE.Encuesta)

        Return MPP.Encuesta.GetInstance.GetAll(FichaOpinion)
    End Function

    Public Function Add(ByRef obj As BE.Encuesta, Optional FichaOpinion As Boolean = False) As Boolean

        Return MPP.Encuesta.GetInstance.Add(obj, FichaOpinion)
    End Function

    Function GetById(id As Integer) As BE.Encuesta
        Return MPP.Encuesta.GetById(id)
    End Function


    Function Delete(id As Integer) As Boolean
        Return MPP.Encuesta.GetInstance.Delete(id)
    End Function

    Shared Function getRandom(Optional FichaOpinion As Boolean = False) As BE.Encuesta
        Dim encuestas = BLL.Encuesta.GetInstance.GetAll(FichaOpinion)
        Dim activas = encuestas.FindAll(Function(x) x.vencimiento > DateTime.Now)
        If activas.Count > 0 Then
            Dim i = CInt(Math.Floor(Rnd() * activas.Count))
            Return activas(i)
        Else
            Return Nothing
        End If
    End Function

    Function votar(id As Integer) As Boolean
        Return MPP.Encuesta.GetInstance.votar(id)
    End Function



End Class
