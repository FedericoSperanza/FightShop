
Option Explicit On

Public Class Encuesta

    Private Shared Function dsToLst(ds) As List(Of BE.Encuesta)
        Dim result As New List(Of BE.Encuesta)
        For Each r As DataRow In ds.Tables(0).Rows
            result.Add(drToObj(r))
        Next
        Return result
    End Function

    Private Sub New()  ''SINGLETON IDEM ABAJO

    End Sub


    Private Shared _instancia As MPP.Encuesta   ''singleton

    Public Shared Function GetInstance() As MPP.Encuesta

        If _instancia Is Nothing Then

            _instancia = New MPP.Encuesta

        End If

        Return _instancia
    End Function




    Public Function GetAll(FichaOpinion As Boolean) As List(Of BE.Encuesta)

        Dim oDatos As New DAL.BD
        Dim hdatos As New Hashtable
        Dim DS As New DataSet
        ' Dim oEncuesta As BE.Encuesta
        Dim lstEncuesta As New List(Of BE.Encuesta)

        hdatos.Add("@fichaOpinion", FichaOpinion)

        DS = oDatos.Leer("sp_Encuesta_GetAll", hdatos)

        Return dsToLst(DS)

        'If DS.Tables(0).Rows.Count > 0 Then
        '    For Each item As DataRow In DS.Tables(0).Rows
        '        oEncuesta = New BE.Encuesta
        '        oEncuesta.id = item("id")
        '        oEncuesta.nombre = item("Nombre")
        '        oEncuesta.vencimiento = item("Vencimiento")

        '        lstEncuesta.Add(oEncuesta)

        '    Next
        '    Return lstEncuesta
        'Else
        '    Return Nothing

        'End If




    End Function



    Function Add(ByRef obj As BE.Encuesta, FichaOpinion As Boolean) As Boolean
        Dim h As New Hashtable
        h.Add("@id", 0)
        h.Add("@nombre", obj.nombre)
        h.Add("@fichaOpinion", FichaOpinion)
        h.Add("@vencimiento", obj.vencimiento)
        Dim acceso As New DAL.BD
        Dim id As Integer = acceso.ExecuteScalar("sp_Encuestas_Save", h)
        obj.id = id

        For Each eo As BE.EncuestaOpcion In obj.opciones
            AddOpcion(obj, eo)
        Next

        Return True
    End Function

    Sub AddOpcion(ByRef obj As BE.Encuesta, opcion As BE.EncuestaOpcion)
        Dim h As New Hashtable
        Dim oDatos As New DAL.BD
        h.Add("@encuestaId", obj.id)
        h.Add("@nombre", opcion.nombre)

        oDatos.Escribir("sp_encuestaOpciones_Save", h)

    End Sub





    Public Shared Function GetById(id As Integer) As BE.Encuesta

        Dim oDatos As New DAL.BD
        Dim hdatos As New Hashtable
        Dim DS As New DataSet


        hdatos.Add("@id", id)
        DS = oDatos.Leer("sp_Encuestas_GetById", hdatos)

        If DS.Tables(0).Rows.Count > 0 Then
            Return drToObj(DS.Tables(0).Rows.Item(0))


        Else
            Return Nothing

        End If




    End Function



    Public Function Delete(id As Integer) As Boolean

        Dim oDatos As New DAL.BD
        Dim hdatos As New Hashtable
        Dim DS As New DataSet


        hdatos.Add("@id", id)
        If oDatos.Escribir("sp_Encuesta_Delete", hdatos) Then

            Return True
        Else
            Return False

        End If





    End Function



    Public Function votar(id As Integer) As Boolean

        Dim oDatos As New DAL.BD
        Dim hdatos As New Hashtable
        Dim DS As New DataSet


        hdatos.Add("@id", id)
        If oDatos.Escribir("sp_EncuestaOpc_Votar", hdatos) Then

            Return True
        Else
            Return False

        End If





    End Function

    Private Shared Function drToObj(r As DataRow) As BE.Encuesta
        Dim x As New BE.Encuesta
        x.id = CInt(r.Item("id"))
        x.nombre = r.Item("nombre").ToString
        x.vencimiento = CDate(r.Item("vencimiento"))

        x.opciones = GetOpciones(x.id)
        Return x
    End Function

    Shared Function GetOpciones(ByRef EncuestaId As Integer) As List(Of BE.EncuestaOpcion)
        Dim h As New Hashtable
        Dim oDatos As New DAL.BD
        h.Add("@EncuestaId", EncuestaId)

        Dim ds = oDatos.Leer("sp_encuestaOpciones_GetByEncuestaId", h)

        Dim result As New List(Of BE.EncuestaOpcion)

        For Each r As DataRow In ds.Tables(0).Rows
            Dim x As New BE.EncuestaOpcion
            x.nombre = r.Item("nombre").ToString
            x.valor = CInt(r.Item("valor"))
            x.id = CInt(r.Item("id"))
            result.Add(x)
        Next

        Return result
    End Function





End Class
