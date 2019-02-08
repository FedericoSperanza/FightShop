
Option Explicit On


Public Class Factura
    Public id As Integer
    Public fecha As Date
    Public usuario As Integer
    Public valtot As Integer
    Public items As New List(Of FacturaItem)
End Class
