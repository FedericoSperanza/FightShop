Imports System.Data
Imports System.IO
Imports System.Web.UI.DataVisualization.Charting
Partial Class Reportes_Vtas
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then


            divGanancias.Visible = True
        End If



    End Sub

    Protected Sub btnFiltrarGanancias_Click(sender As Object, e As EventArgs) Handles btnFiltrarGanancias.Click
        'valida que ambas fechas esten indicadas
        If Me.dpDesdeGanancias.Value Is Nothing Or Me.dpHastaGanancias.Value Is Nothing _
        Then
            regSuccess.Visible = True
            regSuccess.Attributes("class") = "alert alert-danger"
            regSuccess.InnerText = "Indicar Ambas Fechas !"

            Return
        End If

        'valida que fecha desde no sea mayor a fecha hasta
        If Not Me.dpDesdeGanancias.Value Is Nothing And Not Me.dpHastaGanancias.Value Is Nothing And
           Me.dpDesdeGanancias.Value > Me.dpHastaGanancias.Value _
        Then
            regSuccess.Visible = True
            regSuccess.Attributes("class") = "alert alert-danger"
            regSuccess.InnerText = "Fecha Desde no puede ser mayor a Fecha Hasta !"

            Return
        End If

        Dim res = BLL.Factura.GetInstance.GetAllNoAnuladas(CDate(dpDesdeGanancias.Value), CDate(dpHastaGanancias.Value))

        If (res.Count = 0) Then
            Me.divPreguntaGanancias.InnerHtml = "No se encontró información"
        Else
            Me.divPreguntaGanancias.InnerHtml = ""
            tblGanancias.Rows.Clear()
            Dim h As New TableHeaderRow
            Dim c1 As New TableCell()
            Dim c2 As New TableCell()
            Dim c3 As New TableCell()
            c1.Text = "<b>Fecha</b>"
            c2.Text = "<b>N° Factura</b>"
            c3.Text = "<b>Monto</b>"
            c3.HorizontalAlign = HorizontalAlign.Right
            h.Cells.Add(c1)
            h.Cells.Add(c2)
            h.Cells.Add(c3)
            tblGanancias.Rows.Add(h)

            Dim totalAnual As Double = 0
            Dim totalMensual As Double = 0
            Dim totalSemanal As Double = 0
            Dim mes As Integer = 0
            Dim año As Integer = 0
            Dim primerDiaDeLaSemana As DateTime
            Dim semanalAdded = False

            For Each f As BE.Factura In res
                If mes = 0 Then mes = f.fecha.Month
                If año = 0 Then año = f.fecha.Year
                If primerDiaDeLaSemana = New DateTime() Then primerDiaDeLaSemana = f.fecha

                If Math.Abs(DateDiff(DateInterval.Day, f.fecha, primerDiaDeLaSemana)) >= 7 Then
                    addTotalSemanal(totalSemanal)
                    primerDiaDeLaSemana = f.fecha
                End If
                If mes <> f.fecha.Month Then addTotalMensual(totalMensual)
                If año <> f.fecha.Year Then addTotalAnual(totalAnual)

                Dim r As New TableRow
                Dim d1 As New TableCell()
                Dim d2 As New TableCell()
                Dim d3 As New TableCell()
                d1.Text = f.fecha.ToString("dd/MM/yyyy")
                'd2.Text = f.items(0).descripcion
                d2.Text = f.id
                d3.HorizontalAlign = HorizontalAlign.Right
                d3.Text = "$" + f.valtot.ToString
                'd3.Text = f.items(0).monto.ToString("C2")
                r.Cells.Add(d1)
                r.Cells.Add(d2)
                r.Cells.Add(d3)
                tblGanancias.Rows.Add(r)

                totalAnual += f.valtot
                totalMensual += f.valtot
                totalSemanal += f.valtot
                'totalAnual += f.items(0).monto
                'totalMensual += f.items(0).monto
                'totalSemanal += f.items(0).monto

                mes = f.fecha.Month
                año = f.fecha.Year
            Next

            addTotalSemanal(totalSemanal)
            addTotalMensual(totalMensual)
            addTotalAnual(totalAnual)





            Dim ds As New DataSet
            Dim dt As New DataTable("Anual")



            Dim dcolum As New DataColumn("id")
            dt.Columns.Add(dcolum)


            dt.Columns.Add("Año")
            dt.Columns.Add("Total")


            ds.Tables.Add(dt)

            ' //LLENAMOS LA TABLA PERSONA
            Dim _with2 = ds.Tables("Anual").Rows

            _with2.Add(1, "Anual", Session("TotalAnual"))


            ' //instancio una vista del DS
            Dim dsvista As System.Data.DataView = New System.Data.DataView(ds.Tables(0))


            ' //paso el origen de datos
            chartGanancias.DataSource = ds.Tables(0)
            ' // Establecer los nombres de los miembros de la serie para los valores X e Y
            chartGanancias.Series(0).XValueMember = "Año"
            chartGanancias.Series(0).YValueMembers = "Total"
            chartGanancias.DataBind()
            ' //digo q tipo de grafico quiero 
            chartGanancias.Series(0).ChartType = SeriesChartType.Column
            '//y si lo quiero en 3D
            chartGanancias.ChartAreas(0).Area3DStyle.Enable3D = True





            'MENSUAL
            Dim dsMensual As New DataSet
            Dim dtMensual As New DataTable("Mensual")



            Dim dcolumMensual As New DataColumn("id")
            dtMensual.Columns.Add(dcolumMensual)


            dtMensual.Columns.Add("Mes")
            dtMensual.Columns.Add("Total")


            dsMensual.Tables.Add(dtMensual)


            Dim _with2Mensual As DataRowCollection
            _with2Mensual = dsMensual.Tables("Mensual").Rows

            _with2Mensual.Add(1, "Mensual", Session("TotalMensual"))


            ' //instancio una vista del DS
            Dim dsvistaMensual As System.Data.DataView = New System.Data.DataView(dsMensual.Tables(0))


            ' //paso el origen de datos
            chartGananciMensual.DataSource = dsMensual.Tables(0)
            ' // Establecer los nombres de los miembros de la serie para los valores X e Y
            chartGananciMensual.Series(0).XValueMember = "Mes"
            chartGananciMensual.Series(0).YValueMembers = "Total"
            chartGananciMensual.DataBind()
            ' //digo q tipo de grafico quiero 
            chartGananciMensual.Series(0).ChartType = SeriesChartType.Column
            '//y si lo quiero en 3D
            chartGananciMensual.ChartAreas(0).Area3DStyle.Enable3D = True





            'Semanal
            Dim dsSemanal As New DataSet
            Dim dtSemanal As New DataTable("Semanal")



            Dim dcolumnSemanal As New DataColumn("id")
            dtSemanal.Columns.Add(dcolumnSemanal)


            dtSemanal.Columns.Add("Semanal")
            dtSemanal.Columns.Add("Total")


            dsSemanal.Tables.Add(dtSemanal)


            Dim _with2Semanal As DataRowCollection
            _with2Semanal = dsSemanal.Tables("Semanal").Rows

            _with2Semanal.Add(1, "Semanal", Session("TotalSemanal"))


            ' //instancio una vista del DS
            Dim dsvistaSemanal As System.Data.DataView = New System.Data.DataView(dsSemanal.Tables(0))


            ' //paso el origen de datos
            chartGananciaSemanal.DataSource = dsSemanal.Tables(0)
            ' // Establecer los nombres de los miembros de la serie para los valores X e Y
            chartGananciaSemanal.Series(0).XValueMember = "Semanal"
            chartGananciaSemanal.Series(0).YValueMembers = "Total"
            chartGananciaSemanal.DataBind()
            ' //digo q tipo de grafico quiero 
            chartGananciaSemanal.Series(0).ChartType = SeriesChartType.Column
            '//y si lo quiero en 3D
            chartGananciaSemanal.ChartAreas(0).Area3DStyle.Enable3D = True















            'Zona de Chart
            'Dim Dvista As New System.Data.DataView(BLL.Tools.GetInstance.ToDataTable(totalAnual))




            'chartGanancias.Series(0).Points.DataBindXY(totalAnual, "Anual", 1, "value")
            'chartGanancias.Series(0).ChartType = SeriesChartType.Column
            'chartGanancias.ChartAreas("ChartArea1").AxisX.Title = "Ganancias Anuales"
            'chartGanancias.ChartAreas("ChartArea1").AxisY.Title = "Años"
            'chartGanancias.Visible = True



        End If

        Me.divGanancias_Content.Visible = True
    End Sub

    Private Sub addTotalAnual(ByRef totalAnual As Double)
        Dim r As New TableRow
        Dim d1 As New TableCell()
        Dim d2 As New TableCell()
        d1.ColumnSpan = 2
        d1.HorizontalAlign = HorizontalAlign.Right
        d1.Text = "<b>Total anual</b>"
        d2.HorizontalAlign = HorizontalAlign.Right
        Session("TotalAnual") = totalAnual
        d2.Text = "$" + totalAnual.ToString
        r.CssClass = "table-active"
        r.Cells.Add(d1)
        r.Cells.Add(d2)
        tblGanancias.Rows.Add(r)
        totalAnual = 0
    End Sub

    Private Sub addTotalMensual(ByRef totalMensual As Double)
        Dim r As New TableRow
        Dim d1 As New TableCell()
        Dim d2 As New TableCell()
        d1.ColumnSpan = 2
        d1.HorizontalAlign = HorizontalAlign.Right
        d1.Text = "<b>Total mensual</b>"
        d2.HorizontalAlign = HorizontalAlign.Right
        Session("TotalMensual") = totalMensual
        d2.Text = "$" + totalMensual.ToString
        r.CssClass = "table-active"
        r.Cells.Add(d1)
        r.Cells.Add(d2)
        tblGanancias.Rows.Add(r)
        totalMensual = 0
    End Sub

    Private Sub addTotalSemanal(ByRef totalSemanal As Double)
        Dim r As New TableRow
        Dim d1 As New TableCell()
        Dim d2 As New TableCell()
        d1.ColumnSpan = 2
        d1.HorizontalAlign = HorizontalAlign.Right
        d1.Text = "<b>Total semanal</b>"
        d2.HorizontalAlign = HorizontalAlign.Right
        d2.Text = "$" + totalSemanal.ToString
        Session("TotalSemanal") = totalSemanal
        r.CssClass = "table-active"
        r.Cells.Add(d1)
        r.Cells.Add(d2)
        tblGanancias.Rows.Add(r)
        totalSemanal = 0
    End Sub
End Class
