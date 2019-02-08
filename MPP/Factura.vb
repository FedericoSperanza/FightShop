Public Class Factura
    Private Sub New()  ''SINGLETON IDEM ABAJO

    End Sub


    Private Shared _instancia As MPP.Factura   ''singleton

    Public Shared Function GetInstance() As MPP.Factura

        If _instancia Is Nothing Then

            _instancia = New MPP.Factura

        End If

        Return _instancia
    End Function

    Private Shared Function dsToLst(ds) As List(Of BE.Factura)
        Dim result As New List(Of BE.Factura)
        For Each r As DataRow In ds.Tables(0).Rows
            result.Add(drToObj(r))
        Next
        Return result
    End Function

    Private Shared Function drToObj(r As DataRow) As BE.Factura
        Dim x As New BE.Factura
        x.id = CInt(r.Item("idfactura"))
        x.fecha = CDate(r.Item("fecha"))
        x.usuario = (CInt(r.Item("usuarioId")))
        x.valtot = CDbl(r.Item("valtot"))
        x.items = GetItems(x.id)
        Return x

    End Function

    Shared Function GetItems(ByRef facturaId As Integer) As List(Of BE.FacturaItem)
        Dim h As New Hashtable
        h.Add("@facturaId", facturaId)
        Dim oacceso As New DAL.BD
        Dim ds = oacceso.Leer("sp_facturasItems_GetByFacturaId", h)

        Dim result As New List(Of BE.FacturaItem)

        For Each r As DataRow In ds.Tables(0).Rows
            Dim x As New BE.FacturaItem
            x.id = CInt(r.Item("id"))
            x.descripcion = r.Item("detalleprod").ToString
            x.cantidad = r.Item("cantidad")
            x.preciounitario = r.Item("preciounit")
            x.monto = CDbl(r.Item("montolinea"))
            result.Add(x)
        Next

        Return result
    End Function


    Function GetItemstoVote(ByRef facturaId As Integer) As List(Of BE.FacturaItem)
        Dim h As New Hashtable
        h.Add("@facturaId", facturaId)
        Dim oacceso As New DAL.BD
        Dim ds = oacceso.Leer("sp_facturasItems_GetByFacturaIdtoVote", h)

        Dim result As New List(Of BE.FacturaItem)

        For Each r As DataRow In ds.Tables(0).Rows
            Dim x As New BE.FacturaItem

            x.id = CInt(r.Item("idProducto"))
            x.descripcion = r.Item("detalleprod").ToString
            x.foto = r.Item("imagen").ToString
            result.Add(x)
        Next

        Return result
    End Function

    Function GetAllNoAnuladas(desde As DateTime, hasta As DateTime) As List(Of BE.Factura)
        Dim h As New Hashtable
        Dim oacceso As New DAL.BD
        h.Add("@desde", desde.ToString("yyyyMMdd"))
        h.Add("@hasta", hasta.ToString("yyyyMMdd"))
        Dim ds = oacceso.Leer("sp_Facturas_GetAllNoAnuladas", h)
        Return dsToLst(ds)




    End Function





    Public Function addfactura(obj As BE.Factura) As Integer
        Dim h As New Hashtable
        h.Add("@id", 0)

        h.Add("@usuarioId", obj.usuario)
        h.Add("@valtot", obj.valtot)
        Dim acceso As New DAL.BD
        Dim id As Integer = acceso.ExecuteScalar("sp_Facturas_Save", h)
        obj.id = id

        'Guardado de Detalles
        For Each i As BE.FacturaItem In obj.items
            Dim h2 As New Hashtable
            h2.Add("@id", 0)
            h2.Add("@facturaId", id)
            h2.Add("@descripcion", i.descripcion)
            h2.Add("@cantidad", i.cantidad)
            h2.Add("@preciounit", i.preciounitario)
            h2.Add("@monto", CDbl(i.monto))
            Dim id1 As Integer = acceso.ExecuteScalar("sp_facturasItems_Save", h2)
            i.id = id1
        Next

        Return id
    End Function


End Class
