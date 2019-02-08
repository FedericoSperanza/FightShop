Public Class Comentarios
    Private Sub New()  ''SINGLETON IDEM ABAJO

    End Sub


    Private Shared _instancia As MPP.Comentarios   ''singleton

    Public Shared Function GetInstance() As MPP.Comentarios

        If _instancia Is Nothing Then

            _instancia = New MPP.Comentarios

        End If

        Return _instancia
    End Function






    Private Shared Function dsToLst(ds) As List(Of BE.Comentarios)
        Dim result As New List(Of BE.Comentarios)
        For Each r As DataRow In ds.Tables(0).Rows
            result.Add(drToObj(r))
        Next
        Return result
    End Function




    Private Shared Function drToObj(r As DataRow) As BE.Comentarios
        Dim x As New BE.Comentarios
        x.idcomentario = CInt(r.Item("idComentario"))
        x.fecha = CDate(r.Item("fecha"))
        x.state = r.Item("state").ToString
        x.body = r.Item("comentario").ToString
        x.usuario = r.Item("Usuario").ToString
        If x.usuario = "none" Then
            Dim u As New BE.usuarios
            'u.id = "none"
            u.nombre = "MESA DE AYUDA"
            x.usuario = "Mesa de Ayuda"

        Else
            x.usuario = x.usuario
        End If

        If Not IsDBNull(r.Item("parentId")) Then
            Dim p As New BE.Comentarios
            p.idcomentario = CInt(r.Item("parentId"))
            x.parent = p
        End If

        If Not IsDBNull(r.Item("idProducto")) Then

            x.idproducto = r.Item("idProducto")

        End If

        Return x
    End Function

    Function GetByParent(parentId As Integer) As List(Of BE.Comentarios)
        Dim h As New Hashtable
        Dim o As New DAL.BD
        h.Add("@parentId", parentId)
        Dim ds = o.Leer("sp_Comentarios_GetByParentId", h)
        Return dsToLst(ds)
    End Function



    Function GetById(id As Integer) As BE.Comentarios
        Dim h As New Hashtable
        Dim odatos As New DAL.BD
        h.Add("@id", id)
        Dim ds = odatos.Leer("sp_Comentarios_GetById", h)

        If (ds.Tables(0).Rows.Count > 0) Then
            Return drToObj(ds.Tables(0).Rows.Item(0))
        Else
            Return Nothing
        End If
    End Function


    Function GetForMesaDeAyudaAdmin() As List(Of BE.Comentarios)
        Dim h As New Hashtable
        Dim odatos As New DAL.BD
        Dim ds = odatos.Leer("sp_Comentarios_GetForMesaDeAyudaAdmin", h)
        Return dsToLst(ds)
    End Function

    Shared Function GetForStatistics(desde As String, hasta As String) As Dictionary(Of String, Integer)
        Dim h As New Hashtable
        h.Add("@desde", desde)
        h.Add("@hasta", hasta)
        Dim oacceso As New DAL.BD
        Dim ds = oacceso.Leer("sp_Comentarios_GetForStatistics", h)

        Dim d As New Dictionary(Of String, Integer)
        For Each r As DataRow In ds.Tables(0).Rows
            d.Add(r("diff").ToString, CInt(r("count")))
        Next
        Return d
    End Function


    Sub SetState(id As Integer, estado As String)
        Dim h As New Hashtable
        Dim odatos As New DAL.BD
        h.Add("@id", id)
        h.Add("@estado", estado)

        odatos.Escribir("sp_comentarios_SetState", h)
    End Sub

    Public Function GetByIdProducto(id As Integer) As List(Of BE.Comentarios)

        Dim oDatos As New DAL.BD
        Dim hdatos As New Hashtable
        Dim DS As New DataSet
        Dim ocomentario As BE.Comentarios
        Dim lstcomentarios As New List(Of BE.Comentarios)

        hdatos.Add("@idProducto", id)
        DS = oDatos.Leer("sp_Comentarios_SelectByIdProducto", hdatos)

        If DS.Tables(0).Rows.Count > 0 Then
            For Each item As DataRow In DS.Tables(0).Rows
                ocomentario = New BE.Comentarios
                ocomentario.idcomentario = item("idComentario")
                ocomentario.body = item("Comentario")
                ocomentario.idproducto = item("idProducto")
                ocomentario.usuario = item("usuario")
                lstcomentarios.Add(ocomentario)

            Next



            Return lstcomentarios
        Else
            Return Nothing

        End If




    End Function


    Function GetForMesaDeAyuda(mail As String) As List(Of BE.Comentarios)
        Dim h As New Hashtable
        Dim odatos As New DAL.BD
        h.Add("@usuarioId", mail)
        Dim ds = odatos.Leer("sp_Comentarios_GetForMesaDeAyuda", h)
        Return dsToLst(ds)
    End Function






    Function Delete(id As Integer) As Integer
        Dim oDatos As New DAL.BD
        Dim hdatos As New Hashtable
        Dim resultado As Integer



        hdatos.Add("@idComentario", id)





        resultado = oDatos.Escribir("sp_Comentarios_Delete", hdatos)



        Return resultado


    End Function




    Function add(c As BE.Comentarios) As Integer
        Dim oDatos As New DAL.BD
        Dim hdatos As New Hashtable
        Dim resultado As Integer



        hdatos.Add("@Mensaje", c.body)
        hdatos.Add("@idUsuario", c.usuario)
        hdatos.Add("@idProducto", c.idproducto)




        resultado = oDatos.Escribir("sp_Comentarios_Add", hdatos)



        Return resultado


    End Function
    Function addhelpdesk(c As BE.Comentarios) As Integer

        Dim oDatos As New DAL.BD
        Dim hdatos As New Hashtable
        Dim resultado As Integer

        If Not c.parent Is Nothing Then
            hdatos.Add("@parentId", c.parent.idcomentario)
        End If

        hdatos.Add("@Mensaje", c.body)
        hdatos.Add("@idUsuario", c.usuario)
        hdatos.Add("@state", c.state)




        resultado = oDatos.Escribir("sp_Comentarios_Add_HelpDesk", hdatos)



        Return resultado


    End Function




End Class
