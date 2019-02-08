Imports System.Data
Imports System.IO
Imports System.Web.UI.DataVisualization.Charting
Partial Class Reporte_TR
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then

        End If
    End Sub

    Protected Sub btnFiltrarTiempoDeRespuesta_Click(sender As Object, e As EventArgs) Handles btnFiltrarTiempoDeRespuesta.Click
        'valida que ambas fechas esten indicadas
        If Me.dpDesdeTiempoDeRespuesta.Value Is Nothing Or Me.dpHastaTiempoDeRespuesta.Value Is Nothing _
        Then
            regSuccess.Visible = True
            regSuccess.Attributes("class") = "alert alert-danger"
            regSuccess.InnerText = "Indicar Ambas Fechas !"

            Return
        End If
        'regSuccess.Visible = True
        'regSuccess.Attributes("class") = "alert alert-danger"
        'regSuccess.InnerText = "Fecha Desde no puede ser mayor a Fecha Hasta !"

        If Not Me.dpDesdeTiempoDeRespuesta.Value Is Nothing And Not Me.dpHastaTiempoDeRespuesta.Value Is Nothing And
           Me.dpDesdeTiempoDeRespuesta.Value > Me.dpHastaTiempoDeRespuesta.Value _
        Then
            'error fechadesde-hasta
            Return
        End If

        Dim res = BLL.Comentarios.GetForStatistics(CDate(dpDesdeTiempoDeRespuesta.Value).ToString("yyyyMMdd"), CDate(dpHastaTiempoDeRespuesta.Value).ToString("yyyyMMdd"))
        Dim table = BLL.Tools.DicToDataTable(res, "Minutos")

        If (table.Rows.Count = 0) Then
            Me.divPreguntaTiempoDeRespuesta.InnerHtml = "No se encontró información"
            Me.divTiempoDeRespuesta_Content.Visible = True
        Else
            Dim total As Integer
            Dim count As Integer
            For Each r As DataRow In table.Rows
                total += CInt(r.Item("Minutos")) * CInt(r.Item("value"))
                count += CInt(r.Item("value"))
            Next
            Dim avg = total / count
            Me.divPreguntaTiempoDeRespuesta.InnerHtml = "Tiempo promedio de atencion: " + avg.ToString("N2") + " minutos"

            Dim Dvista As New System.Data.DataView(table)
            chartTiempoDeRespuesta.Series(0).Points.DataBindXY(Dvista, "Minutos", Dvista, "value")
            chartTiempoDeRespuesta.Series(0).ChartType = SeriesChartType.Column
            chartTiempoDeRespuesta.ChartAreas("ChartArea1").AxisX.Title = "Tiempo de respuesta (Minutos)"
            chartTiempoDeRespuesta.ChartAreas("ChartArea1").AxisY.Title = "Consultas"
            chartTiempoDeRespuesta.ChartAreas(0).Area3DStyle.Enable3D = True
        End If

        Me.divTiempoDeRespuesta_Content.Visible = True

    End Sub
End Class
