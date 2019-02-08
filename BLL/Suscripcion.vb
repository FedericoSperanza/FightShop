Public Class Suscripcion
    Private Sub New()  ''SINGLETON

    End Sub

    Private Shared _instancia As BLL.Suscripcion

    Public Shared Function GetInstance() As BLL.Suscripcion

        If _instancia Is Nothing Then

            _instancia = New BLL.Suscripcion

        End If

        Return _instancia
    End Function

    Sub Add(email As String, categoria As String)
        MPP.Suscripcion.GetInstance.add(email, categoria)
    End Sub


End Class
