Public Class CuentaCorriente
    Private Sub New()  ''SINGLETON

    End Sub

    Private Shared _instancia As BLL.CuentaCorriente

    Public Shared Function GetInstance() As BLL.CuentaCorriente

        If _instancia Is Nothing Then

            _instancia = New BLL.CuentaCorriente

        End If

        Return _instancia
    End Function

    Public Function addCC(obj As BE.CuentaCorriente) As Boolean

        Return MPP.CuentaCorriente.GetInstance.addCC(obj)
    End Function


    Public Function GetByUsuarioId(usuarioId As Integer, desde As DateTime?, hasta As DateTime?) As List(Of BE.CuentaCorriente)

        Return MPP.CuentaCorriente.GetInstance.GetByUsuarioId(usuarioId, Nothing, Nothing)
    End Function

    Public Function GetAdmin() As List(Of BE.CuentaCorriente)

        Return MPP.CuentaCorriente.GetInstance.getadmin()

    End Function


    Public Function GetTrackingByUsuarioId(usuarioId As Integer) As List(Of BE.CuentaCorriente)

        Return MPP.CuentaCorriente.GetInstance.GetTrackingByUsuarioId(usuarioId)
    End Function
End Class
