Public Class Bitacora
    Private Const NIVELCRITICIDAD_2 As String = "Error"
    Private Const NIVELCRITICIDAD_1 As String = "Informativo"
    Private Const NIVELCRITICIDAD_3 As String = "Grave"


    Public Sub GuardarERROREnBitacora(fecha As DateTime, user As String, evento As String)

        Dim bitacoraMP As New MPP.Bitacora
        Dim logBE As New BE.Bitacora


        'user.NombreUsuario = ServiciosBL.Desencriptar3d(user.NombreUsuario)


        logBE.fecha = fecha.ToString("yyyy-MM-dd HH:mm:ss")
        logBE.usuario = user
        logBE.evento = evento
        logBE.criticidad = NIVELCRITICIDAD_2
        bitacoraMP.GuardarEnBitacora(logBE)

    End Sub

    Public Sub GuardarINFOEnBitacora(fecha As DateTime, user As String, evento As String)

        Dim bitacoraMP As New MPP.Bitacora
        Dim logBE As New BE.Bitacora


        'user.NombreUsuario = ServiciosBL.Desencriptar3d(user.NombreUsuario)


        logBE.fecha = fecha.ToString("yyyy-MM-dd HH:mm:ss")
        logBE.usuario = user
        logBE.evento = evento
        logBE.criticidad = NIVELCRITICIDAD_1
        bitacoraMP.GuardarEnBitacora(logBE)

    End Sub

    Public Sub GuardarWARNINGEnBitacora(fecha As DateTime, user As String, evento As String)

        Dim bitacoraMP As New MPP.Bitacora
        Dim logBE As New BE.Bitacora


        'user.NombreUsuario = ServiciosBL.Desencriptar3d(user.NombreUsuario)


        logBE.fecha = fecha.ToString("yyyy-MM-dd HH:mm:ss")
        logBE.usuario = user
        logBE.evento = evento
        logBE.criticidad = NIVELCRITICIDAD_3
        bitacoraMP.GuardarEnBitacora(logBE)

    End Sub



    Public Function BuscarFiltradoBitacora(bitacoraBusqueda As BE.BitacoraDTO) As List(Of BE.Bitacora)

        Dim listBitacora As New List(Of BE.Bitacora)
        Dim bitacoraMP As New MPP.Bitacora
        ' Dim servicesBL As New BLL.Servicios

        listBitacora = bitacoraMP.ObtenerBusquedaFiltradaBitacora(bitacoraBusqueda)




        Return listBitacora

    End Function


    Public Shared Function ListarTodo() As List(Of BE.Bitacora)
        'Dim ds As DataSet = MPP.Bitacora.ListarTodo()
        Return MPP.Bitacora.ListarTodo
        ' Return dsTolst(ds)
    End Function


    Public Shared Function ListarTodo(bitacorabusqueda As BE.BitacoraDTO) As List(Of BE.Bitacora)
        Dim mpbitacora As New MPP.Bitacora
        Dim lstbitacora As New List(Of BE.Bitacora)
        'Dim ds As DataSet = MPP.Bitacora.ListarTodo(usuario, desde, hasta, criticidad)
        'Return dsTolst(ds)
        lstbitacora = mpbitacora.ListarTodo(bitacorabusqueda)
        Return lstbitacora

    End Function



    Private Shared Function dsTolst(ds) As List(Of BE.Bitacora)
        Dim result As New List(Of BE.Bitacora)

        For Each r As DataRow In ds.Tables(0).Rows
            Dim x As New BE.Bitacora

            x.id = 0
            x.fecha = CDate(r.Item("fecha"))
            x.evento = r.Item("evento").ToString
            x.criticidad = r.Item("criticidad")

            x.usuario = r.Item("usuario")

            result.Add(x)
        Next

        Return result
    End Function




    Public Function ObtenerCriticidades() As List(Of String)

        Dim listCriticidad As New List(Of String)
        listCriticidad.Add(NIVELCRITICIDAD_1)
        listCriticidad.Add(NIVELCRITICIDAD_2)
        listCriticidad.Add(NIVELCRITICIDAD_3)

        Return listCriticidad

    End Function

End Class
