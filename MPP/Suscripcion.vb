Public Class Suscripcion
    Private Sub New()  ''SINGLETON IDEM ABAJO

    End Sub


    Private Shared _instancia As MPP.Suscripcion   ''singleton

    Public Shared Function GetInstance() As MPP.Suscripcion

        If _instancia Is Nothing Then

            _instancia = New MPP.Suscripcion

        End If

        Return _instancia
    End Function

    Public Sub add(email As String, categoria As String)

        Dim oDatos As New DAL.BD
        Dim hdatos As New Hashtable
        Dim resultado As Integer

        hdatos.Add("@email", email)
        hdatos.Add("@categoria", categoria)


        resultado = oDatos.Escribir("sp_Suscripcion_Add", hdatos)






    End Sub


End Class
