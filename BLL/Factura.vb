Public Class Factura
    Private Sub New()  ''SINGLETON

    End Sub

    Private Shared _instancia As BLL.Factura

    Public Shared Function GetInstance() As BLL.Factura

        If _instancia Is Nothing Then

            _instancia = New BLL.Factura

        End If

        Return _instancia
    End Function



    Public Function addFactura(obj As BE.Factura) As Integer

        Return MPP.Factura.GetInstance.addfactura(obj)
    End Function



    Public Function GetAllNoAnuladas(desde As DateTime, hasta As DateTime) As List(Of BE.Factura)
        Return MPP.Factura.GetInstance.GetAllNoAnuladas(desde, hasta)
    End Function


    Public Function GetItems(idfactura As Integer) As List(Of BE.FacturaItem)

        Return MPP.Factura.GetInstance.GetItemstoVote(idfactura)
    End Function



End Class
