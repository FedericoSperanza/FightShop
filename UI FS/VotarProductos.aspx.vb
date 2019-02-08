
Imports AjaxControlToolkit


Partial Class VotarProductos
    Inherits System.Web.UI.Page



    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        If Not (Page.IsPostBack) Then

            If Session("ListProdVote") Is Nothing Then

                Response.Redirect("Home.Aspx")

            End If

            Dim dsProducto = Session("ListProdVote")
            Me.rpt1.DataSource = dsProducto
            Me.rpt1.DataBind()
            Dim lstControlVoto As New List(Of AjaxControlToolkit.Rating)
            Session("CountProductos") = rpt1.Items.Count

            For Each item As RepeaterItem In rpt1.Items
                Session("lstControlVoto") = New List(Of AjaxControlToolkit.Rating)



                Dim controldeVoto As New AjaxControlToolkit.Rating
                controldeVoto = rpt1.Items.Item(item.ItemIndex).FindControl("rating")
                'controldeVoto.FindControl("rating")
                Dim qetiene As String
                qetiene = controldeVoto.Tag


                lstControlVoto.Add(controldeVoto)

                'lstControlVoto.Add(controldeVoto)

                Session("lstControlVoto") = lstControlVoto



            Next


        End If



    End Sub

    Protected Sub OnRatingChanged(sender As Object, e As RatingEventArgs)
        Dim voto As Integer = e.Value

        Dim controlqueNecesito As New AjaxControlToolkit.Rating

        controlqueNecesito.Tag = e.Tag



        Dim lstControlVoto As New List(Of AjaxControlToolkit.Rating)
            For Each item As RepeaterItem In rpt1.Items
                Session("lstControlVoto") = New List(Of AjaxControlToolkit.Rating)
                Dim controldeprpt As New AjaxControlToolkit.Rating

                controldeprpt = rpt1.Items.Item(item.ItemIndex).FindControl("rating")



                If controlqueNecesito.Tag = controldeprpt.Tag Then




                    controldeprpt.ReadOnly = True
                    Session("CountProductos") -= 1

                    lstControlVoto.Add(controldeprpt)

                    Session("lstControlVoto") = lstControlVoto
                Else
                    lstControlVoto.Add(controldeprpt)
                End If











            Next








        BLL.Productos.GetInstance.Votar(voto, e.Tag)
        If Session("CountProductos") > 0 Then
            ''puede seguir votando

        Else

            regSuccess.Visible = True
            regSuccess.Focus()
            regSuccess.Attributes("class") = "alert alert-success"
            regSuccess.InnerText = "Gracias por Votar! (Redireccion en 5 segundos)"

            Response.AddHeader("REFRESH", "3;URL=Home.aspx")


        End If




        ''actualizar lo marcado en la estrellita
        ' y poner variable de session de votado en 1



    End Sub


    Protected Sub grd_RowDataBound(sender As Object, e As RepeaterItemEventArgs) Handles rpt1.ItemCreated

        If Not e.Item.DataItem IsNot Nothing Then




        End If





    End Sub


End Class
