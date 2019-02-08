Imports System.Globalization
Imports System.Threading

Public Class Bitacora



    Sub GuardarEnBitacora(objBitacora As BE.Bitacora)

        If Thread.CurrentThread.CurrentUICulture.ToString = "en-US" Then

            Dim cultura As String = "es-ES"

            Thread.CurrentThread.CurrentCulture = New CultureInfo(cultura)
            Thread.CurrentThread.CurrentUICulture = New CultureInfo(cultura)


            Dim oDatos As New DAL.BD
            Dim hdatos As New Hashtable

            hdatos.Add("@Fecha", objBitacora.fecha)
            hdatos.Add("@User", objBitacora.usuario)
            hdatos.Add("@evento", objBitacora.evento)
            hdatos.Add("@Criticidad", objBitacora.criticidad)


            oDatos.Escribir("sp_insertbitacora", hdatos)

            Thread.CurrentThread.CurrentUICulture = New CultureInfo("en-US")

        Else
            Dim cultura As String = "es-ES"

            Thread.CurrentThread.CurrentCulture = New CultureInfo(cultura)
            Thread.CurrentThread.CurrentUICulture = New CultureInfo(cultura)


            Dim oDatos As New DAL.BD
            Dim hdatos As New Hashtable

            hdatos.Add("@Fecha", objBitacora.fecha)
            hdatos.Add("@User", objBitacora.usuario)
            hdatos.Add("@evento", objBitacora.evento)
            hdatos.Add("@Criticidad", objBitacora.criticidad)


            oDatos.Escribir("sp_insertbitacora", hdatos)


        End If

    End Sub






    Function ObtenerBusquedaFiltradaBitacora(bitacoraBusqueda As BE.BitacoraDTO) As List(Of BE.Bitacora)
        Dim listBitacora As New List(Of BE.Bitacora)


        'validar si esta null el listado de ids usuarios
        'validar si esta null el listado de criticidades

        'en total son 4 metodos (solofecha *-* fecha+user *-* fecha+criticidades *-* fecha+user+criticidades)


        Return listBitacora


    End Function


    Public Shared Function ListarTodo() As List(Of BE.Bitacora)

        Dim oDatos As New DAL.BD
        Dim hdatos As New Hashtable
        Dim DS As New DataSet
        Dim oBitacora As BE.Bitacora
        Dim lstBitacora As New List(Of BE.Bitacora)


        DS = oDatos.Leer("sp_bitacora_ListAll", hdatos)

        If DS.Tables(0).Rows.Count > 0 Then
            For Each item As DataRow In DS.Tables(0).Rows
                oBitacora = New BE.Bitacora
                oBitacora.fecha = item("Fecha")
                oBitacora.usuario = item("Usuario")
                oBitacora.evento = item("Evento")
                oBitacora.criticidad = item("Criticidad")
                lstBitacora.Add(oBitacora)
            Next
            Return lstBitacora
        Else
            Return Nothing

        End If




    End Function


    Public Function ListarTodo(bitacorabusqueda As BE.BitacoraDTO) As List(Of BE.Bitacora)

        Dim oDatos As New DAL.BD
        Dim hdatos As New Hashtable
        Dim DS As New DataSet
        Dim oBitacora As BE.Bitacora
        Dim lstBitacora As New List(Of BE.Bitacora)



        hdatos.Add("@usuario", bitacorabusqueda.Usuario)
        hdatos.Add("@desde", CDate(bitacorabusqueda.fechaDesde).ToString("yyyyMMdd") & " 00:00")
        hdatos.Add("@hasta", CDate(bitacorabusqueda.fechaHasta).ToString("yyyyMMdd") & " 23:59")
        hdatos.Add("@criticidad", bitacorabusqueda.Criticidades.Trim())
        DS = oDatos.Leer("dbo.sp_FilterListBitacora", hdatos)

        If DS.Tables(0).Rows.Count > 0 Then
            For Each item As DataRow In DS.Tables(0).Rows
                oBitacora = New BE.Bitacora
                oBitacora.fecha = item("Fecha")
                oBitacora.usuario = item("Usuario")
                oBitacora.evento = item("Evento")
                oBitacora.criticidad = item("Criticidad")
                lstBitacora.Add(oBitacora)
            Next
            Return lstBitacora
        Else
            Return Nothing

        End If







    End Function




End Class
