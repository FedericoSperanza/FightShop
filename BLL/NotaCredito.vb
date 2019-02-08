Public Class NotaCredito
    Private Sub New()  ''SINGLETON

    End Sub

    Private Shared _instancia As BLL.NotaCredito

    Public Shared Function GetInstance() As BLL.NotaCredito

        If _instancia Is Nothing Then

            _instancia = New BLL.NotaCredito

        End If

        Return _instancia
    End Function

    Function GetByUsuarioId(id As Integer) As List(Of BE.NotaCredito)
        Return MPP.NotaCredito.GetInstance.GetByUsuarioId(id)
    End Function


    Sub setSaldo(id As Integer, saldo As Double)
        MPP.NotaCredito.GetInstance.setSaldo(id, saldo)
    End Sub

    Function Add(ByRef obj As BE.NotaCredito) As Integer
        Return MPP.NotaCredito.GetInstance.Add(obj)
    End Function

End Class
