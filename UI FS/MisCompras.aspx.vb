
Partial Class MisCompras
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not (Page.IsPostBack) Then
            Actualizar()
        End If
    End Sub


    Private Sub Actualizar()
        Dim dsCuentaCorriente = BLL.CuentaCorriente.GetInstance.GetByUsuarioId(Session("UserId"), Nothing, Nothing)
        Me.grd.DataSource = dsCuentaCorriente
        Me.grd.DataBind()
        Session("ListNC") = Nothing
    End Sub

    Protected Sub GV_Compras_Paginado(sender As Object, e As GridViewPageEventArgs) Handles grd.PageIndexChanging

        grd.PageIndex = e.NewPageIndex
        Actualizar()

        'verificar si tiene filtrado de fecha



    End Sub
    Protected Sub lbMisCompras_Click(sender As Object, e As EventArgs) Handles lbCompras.Click
        Response.Redirect("MisCompras.Aspx")
    End Sub
    Protected Sub lbHelpDesk_Click(sender As Object, e As EventArgs) Handles lbMensajeria.Click
        Response.Redirect("HelpDesk.Aspx")
    End Sub

    Protected Sub grd_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grd.RowCommand
        Select Case e.CommandName
            Case "ViewPdf"
                Dim i As Integer = CType(e.CommandArgument, Integer)
                Dim tipo = grd.Rows(i).Cells(2).Text
                Dim numero = grd.Rows(i).Cells(3).Text
                'Dim prefix = "Nota_de_Credito"
                If tipo = "NC" Then
                    tipo = "Nota_de_Credito"
                End If
                Dim filename = "facturas/" & tipo & "_" & numero & ".pdf"
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "OpenWindow", "window.open('" & filename & "','_newtab');", True)

            Case "CancelFac"

                Dim str As String()
                str = e.CommandArgument.ToString().Split("|")
                Dim numerocomp = str(0)
                Dim estado = str(1)
                Dim descripcion = str(2)
                Dim tracking = str(3)
                Dim conformidad = str(4)


                Dim oCC As New BE.CuentaCorriente


                oCC.id = 1
                'se pone 1 porqe es update segu nro comp
                oCC.nroComprobante = numerocomp
                oCC.estado = estado
                oCC.descripcion = descripcion
                oCC.tracking = tracking
                oCC.Conformidad = 0

                oCC.SolicitudBaja = 1
                oCC.fecha = Date.Today

                BLL.CuentaCorriente.GetInstance.addCC(oCC)

                ''llamar metodo de update y meter un 1 en el pedido de baja en tabla CC

                'enviarlo a qe detalle la situacion al helpdesk
                Actualizar()
            Case "Conforme"
                Dim str As String()
                str = e.CommandArgument.ToString().Split("|")
                Dim numerocomp = str(0)
                Dim descripcion = str(1)



                Dim oCCC As New BE.CuentaCorriente
                oCCC.id = 1
                'se pone 1 porqe es update segu nro comp
                oCCC.nroComprobante = numerocomp
                oCCC.descripcion = descripcion
                oCCC.tracking = "Entregado"
                oCCC.estado = "Pagado"
                oCCC.fecha = Date.Today
                oCCC.Conformidad = 1
                oCCC.SolicitudBaja = 0
                BLL.CuentaCorriente.GetInstance.addCC(oCCC)
                'LO COMENTO PARA PROBAR EL RATING


                ''llamar metodo de update y meter un 1 en flag conformidad tabla CC

                'con eso ya no se puede pedir baja de fac por parte del cliente


                ''Tomar los productos del detalle de la Factura para Votar 
                Session("ListProdVote") = BLL.Factura.GetInstance.GetItems(oCCC.nroComprobante)

                Response.Redirect("VotarProductos.Aspx")


        End Select
        Actualizar()
    End Sub

    Protected Sub grd_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles grd.RowCreated

        ''AL GENERAR LAS FILAS VALIDA EL TRACKING PARA ASIGNARLE O NO LA POSIBILIDAD DEL REEMBOLSO DE PRODUCTO
        If Not e.Row.DataItem Is Nothing Then
            Dim descripcion = DataBinder.Eval(e.Row.DataItem, "descripcion")
            Dim tracking = DataBinder.Eval(e.Row.DataItem, "tracking")
            Dim solicitudDeBaja = DataBinder.Eval(e.Row.DataItem, "SolicitudBaja")
            Dim Conformidad = DataBinder.Eval(e.Row.DataItem, "Conformidad")
            Dim ctrlRembolso = e.Row.FindControl("btnCancelFac")
            Dim ctrlConformidad = e.Row.FindControl("btnConformidad")
            If tracking = "En Camino" And solicitudDeBaja = False And Conformidad = False Then

                ctrlRembolso.Visible = True
                ctrlConformidad.Visible = False


            End If
            If tracking = "En Camino" And solicitudDeBaja = True Then

                ctrlRembolso.Visible = False
                ctrlConformidad.Visible = False

            End If

            If tracking = "Entregado" Then

                ctrlRembolso.Visible = True

                ctrlConformidad.Visible = True

            End If

            If Conformidad = True Then
                ctrlConformidad.Visible = False
                ctrlRembolso.Visible = False


            End If


            If descripcion = "NC" Then
                ctrlConformidad.Visible = False
                ctrlRembolso.Visible = False


            End If

            If Conformidad = True Then
                ctrlConformidad.Visible = False
                ctrlRembolso.Visible = False

            End If
        End If




    End Sub



End Class
