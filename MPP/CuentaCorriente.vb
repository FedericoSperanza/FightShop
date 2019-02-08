Public Class CuentaCorriente
    Private Sub New()  ''SINGLETON IDEM ABAJO

    End Sub


    Private Shared _instancia As MPP.CuentaCorriente   ''singleton

    Public Shared Function GetInstance() As MPP.CuentaCorriente

        If _instancia Is Nothing Then

            _instancia = New MPP.CuentaCorriente

        End If

        Return _instancia
    End Function

    Private Shared Function dsToLst(ds) As List(Of BE.CuentaCorriente)
        Dim result As New List(Of BE.CuentaCorriente)
        For Each r As DataRow In ds.Tables(0).Rows
            result.Add(drToObj(r))
        Next
        Return result
    End Function

    Private Shared Function drToObj(r As DataRow) As BE.CuentaCorriente
        Dim x As New BE.CuentaCorriente
        x.id = CInt(r.Item("id"))
        x.fecha = CDate(r.Item("fecha"))
        x.descripcion = r.Item("descripcion").ToString

        ' x.monto = r.Item("monto").ToString


        x.nroComprobante = r.Item("nroComprobante").ToString



        x.estado = r.Item("estado").ToString


        x.debe = CDbl(r.Item("debe"))

            x.haber = CDbl(r.Item("haber"))



        If IsDBNull(r.Item("Conformidad")) Then
            x.Conformidad = 0
        Else
            x.Conformidad = CBool(r.Item("conformidad"))

        End If

        If IsDBNull(r.Item("SolicitudBaja")) Then
            x.SolicitudBaja = 0

        Else

            x.SolicitudBaja = CBool(r.Item("SolicitudBaja"))
        End If




        If Not IsDBNull(r.Item("tracking")) Then

            x.tracking = r.Item("tracking")

        End If


        Return x
    End Function







    Public Function addcc(obj As BE.CuentaCorriente) As Boolean
        Dim h As New Hashtable
        Dim oDatos As New DAL.BD



        h.Add("@id", obj.id) ''es create
        h.Add("@usuarioId", obj.usuarioid)
        h.Add("@monto", obj.monto)
        h.Add("@fecha", obj.fecha)
        h.Add("@nroComprobante", obj.nroComprobante)
        h.Add("@estado", obj.estado)
        h.Add("@descripcion", obj.descripcion)
        h.Add("@NC", obj.NC)
        h.Add("@SolicitudBaja", obj.SolicitudBaja)
        h.Add("@Conformidad", obj.Conformidad)
        h.Add("@tracking", obj.tracking)

        oDatos.Escribir("sp_CuentaCorriente_Save", h)



        Return True
    End Function




    Function GetByUsuarioId(usuarioId As Integer, desde As DateTime?, hasta As DateTime?) As List(Of BE.CuentaCorriente)
        Dim h As New Hashtable
        Dim odatos As New DAL.BD
        h.Add("@usuarioId", usuarioId)

        If Not desde Is Nothing Then
            h.Add("@desde", CDate(desde).ToString("yyyyMMdd") & " 00:00")
        End If

        If Not hasta Is Nothing Then
            h.Add("@hasta", CDate(hasta).ToString("yyyyMMdd") & " 23:59")
        End If

        Dim ds = odatos.Leer("sp_CuentaCorriente_GetByUsuarioId", h)

        Return dsToLst(ds)
    End Function

    Function getadmin() As List(Of BE.CuentaCorriente)
        Dim h As New Hashtable
        Dim odatos As New DAL.BD
        Dim ds = odatos.Leer("sp_CuentaCorriente_GetAdmin", h)
        Dim lstCC As New List(Of BE.CuentaCorriente)
        Dim oCC As BE.CuentaCorriente

        If ds.Tables(0).Rows.Count > 0 Then
            For Each item As DataRow In ds.Tables(0).Rows
                oCC = New BE.CuentaCorriente
                oCC.nroComprobante = item("nroComprobante")
                oCC.monto = item("monto")
                oCC.fecha = item("fecha")
                oCC.estado = item("estado")
                oCC.descripcion = item("descripcion")
                oCC.tracking = item("tracking")
                oCC.SolicitudBaja = item("SolicitudBaja")
                oCC.Conformidad = item("conformidad")
                oCC.usuarioid = item("usuarioId")

                lstCC.Add(oCC)
            Next
            Return lstCC
        Else
            Return Nothing

        End If




    End Function












    Function GetTrackingByUsuarioId(usuarioId As Integer) As List(Of BE.CuentaCorriente)
        Dim h As New Hashtable
        Dim odatos As New DAL.BD
        Dim lstcctrack As New List(Of BE.CuentaCorriente)
        Dim olsttrack As BE.CuentaCorriente
        h.Add("@usuarioId", usuarioId)



        Dim ds = odatos.Leer("sp_Tracking_GetByUsuarioId", h)

        If ds.Tables(0).Rows.Count > 0 Then
            For Each item As DataRow In ds.Tables(0).Rows
                olsttrack = New BE.CuentaCorriente
                olsttrack.fecha = item("fecha")
                olsttrack.descripcion = item("fecha")
                olsttrack.nroComprobante = item("nroComprobante")
                olsttrack.tracking = item("tracking")
                lstcctrack.Add(olsttrack)
            Next



            Return lstcctrack
        Else
            Return Nothing

        End If


    End Function

End Class






