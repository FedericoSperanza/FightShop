Public Class Pago
    Private Sub New()  ''SINGLETON IDEM ABAJO

    End Sub


    Private Shared _instancia As MPP.Pago   ''singleton

    Public Shared Function GetInstance() As MPP.Pago

        If _instancia Is Nothing Then

            _instancia = New MPP.Pago

        End If

        Return _instancia
    End Function


    Public Function Add(obj As BE.Pagos) As Boolean
        Dim oDatos As New DAL.BD

        Dim resultado As Integer

        Dim h As New Hashtable

        h.Add("@id", 0)

        h.Add("@formaPago", obj.formaPago)
        h.Add("@numeroTarjeta", obj.numeroTarjeta)
        h.Add("@nombreApellido", obj.nombreApellido)
        h.Add("@expiracion", obj.expiracion)
        h.Add("@codigoSeguridad", obj.codigoSeguridad)
        h.Add("@dni", obj.dni)
        h.Add("@monto", obj.monto)
        h.Add("@anulado", obj.anulado)



        resultado = oDatos.Escribir("sp_Pago_Add", h)




        Return resultado

    End Function





End Class
