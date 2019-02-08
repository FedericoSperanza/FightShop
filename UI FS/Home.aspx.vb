Imports System.Web.UI.DataVisualization.Charting
Partial Class _Default
    Inherits System.Web.UI.Page




    Protected Sub lbKimonos_Click(sender As Object, e As EventArgs) Handles lbKimonos.Click

        Session("ProdFilter") = "Kimonos"
        Response.Redirect("Catalogo.aspx")

    End Sub



    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not (Page.IsPostBack) Then
            setEncuesta()
            Session("ProdFilter") = Nothing
            Session("NotiShow") = Nothing
            Session("ListProdVote") = Nothing
            Session("ListNC") = Nothing


        Else


        End If



    End Sub


    Protected Sub rptEncuestaOpciones_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.RepeaterCommandEventArgs) Handles rptEncuestaOpciones.ItemCommand
        BLL.Encuesta.GetInstance.votar(CInt(e.CommandArgument))

        divEncuesta.Attributes.Add("style", "width: 18rem; height:39rem ; position: fixed; bottom: 200px; right: 20px; border-width: 2px; border-color: black")

        Dim enc = BLL.Encuesta.GetInstance.GetById(Session("encuestaId"))
        Dim Dvista As New System.Data.DataView(BLL.Tools.GetInstance.ToDataTable(Of BE.EncuestaOpcion)(enc.opciones))
        chartEncuesta.Series(0).Points.DataBindXY(Dvista, "nombre", Dvista, "valor")
        chartEncuesta.Series(0).ChartType = SeriesChartType.Pie
        chartEncuesta.ChartAreas(0).Area3DStyle.Enable3D = True

        divEncuestaChart.Visible = True
        divEncuestaPreguntas.Visible = False

        Session("encuestaRespondida") = True
    End Sub


    Protected Sub setEncuesta()
        Me.divEncuesta.Visible = Session("encuestaCerrada") Is Nothing And Session("encuestaRespondida") Is Nothing
        If Me.divEncuesta.Visible Then
            Dim e = BLL.Encuesta.getRandom
            If e Is Nothing Then
                btnCloseEncuesta_Click(Nothing, Nothing)
            Else
                Session("encuestaId") = e.id
                Me.encuestaText.InnerHtml = e.nombre
                rptEncuestaOpciones.DataSource = e.opciones
                rptEncuestaOpciones.DataBind()
            End If
        End If
    End Sub


    Protected Sub btnCloseEncuesta_Click(sender As Object, e As EventArgs) Handles btnCloseEncuesta.Click
        Session("encuestaCerrada") = True
        Me.divEncuesta.Visible = False
    End Sub









    Protected Sub lbLycras_Click(sender As Object, e As EventArgs) Handles lbLycras.Click
        Session("ProdFilter") = "Lycras"
        Response.Redirect("Catalogo.aspx")
    End Sub
    Protected Sub lbBermudas_Click(sender As Object, e As EventArgs) Handles lbBermudas.Click
        Session("ProdFilter") = "Bermudas"
        Response.Redirect("Catalogo.aspx")
    End Sub
    Protected Sub lbRemeras_Click(sender As Object, e As EventArgs) Handles lbRemeras.Click
        Session("ProdFilter") = "Remeras"
        Response.Redirect("Catalogo.aspx")
    End Sub
    Protected Sub lbGuantes_Click(sender As Object, e As EventArgs) Handles lbGuantes.Click
        Session("ProdFilter") = "Guantes"
        Response.Redirect("Catalogo.aspx")
    End Sub
    Protected Sub lbProtecciones_Click(sender As Object, e As EventArgs) Handles lbProtecciones.Click
        Session("ProdFilter") = "Protecciones"
        Response.Redirect("Catalogo.aspx")
    End Sub
End Class
