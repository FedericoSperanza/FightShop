Public Class NotaCredito
    Private Sub New()  ''SINGLETON IDEM ABAJO

    End Sub


    Private Shared _instancia As MPP.NotaCredito   ''singleton

    Public Shared Function GetInstance() As MPP.NotaCredito

        If _instancia Is Nothing Then

            _instancia = New MPP.NotaCredito

        End If

        Return _instancia
    End Function

    Private Shared Function dsToLst(ds) As List(Of BE.NotaCredito)
        Dim result As New List(Of BE.NotaCredito)
        For Each r As DataRow In ds.Tables(0).Rows
            result.Add(drToObj(r))
        Next
        Return result
    End Function

    Private Shared Function drToObj(r As DataRow) As BE.NotaCredito
        Dim x As New BE.NotaCredito
        x.id = CInt(r.Item("id"))
        x.fecha = CDate(r.Item("fecha"))
        x.usuario = CInt(r.Item("usuarioId"))
        x.concepto = r.Item("concepto").ToString
        x.monto = CDbl(r.Item("monto"))
        x.saldo = CDbl(r.Item("saldo"))
        Return x
    End Function

    Sub setSaldo(id As Integer, saldo As Double)
        Dim h As New Hashtable
        Dim odatos As New DAL.BD
        h.Add("@id", id)
        h.Add("@saldo", saldo)
        odatos.Escribir("sp_notaCredito_setSaldo", h)
    End Sub


    Function GetByUsuarioId(id As Integer) As List(Of BE.NotaCredito)
        Dim h As New Hashtable
        Dim o As New DAL.BD
        h.Add("@usuarioId", id)
        Dim ds = o.Leer("sp_notaCredito_GetByUsuarioId", h)
        Return dsToLst(ds)
    End Function

    Function Add(ByRef obj As BE.NotaCredito) As Integer
        Dim h As New Hashtable
        h.Add("@id", 0)
        h.Add("@fecha", obj.fecha)
        h.Add("@usuarioId", obj.usuario)
        h.Add("@concepto", obj.concepto)
        h.Add("@monto", obj.monto)
        Dim odb As New DAL.BD
        Dim id As Integer = odb.ExecuteScalar("sp_notaCredito_Save", h)
        obj.id = id

        Return id
    End Function





End Class
