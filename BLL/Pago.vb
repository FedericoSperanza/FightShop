Public Class Pago
    Private Sub New()  ''SINGLETON

    End Sub

    Private Shared _instancia As BLL.Pago

    Public Shared Function GetInstance() As BLL.Pago

        If _instancia Is Nothing Then

            _instancia = New BLL.Pago

        End If

        Return _instancia
    End Function

    Public Function Add(objpago As BE.Pagos) As Boolean

        Return MPP.Pago.GetInstance.Add(objpago)
    End Function








End Class
