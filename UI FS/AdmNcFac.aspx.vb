
Partial Class AdmFacturacion
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not (Page.IsPostBack) Then
            Actualizar()
        End If
    End Sub


    Private Sub Actualizar()
        'Valido si puede acceder al modulo de administracion
        Dim idPermAdm = BLL.usuarios.GetInstance.GetidPermByUrl("AdmNcFac.aspx")


        If Session("Nombre") IsNot Nothing Then



            If BLL.usuarios.GetInstance.PermiteAcceso(idPermAdm) Then
                ''No hago nada TODO OK!
            Else
                Response.Redirect("Home.Aspx")
            End If

        Else
            'Aca es si no hay si quiera user logueado
            Response.Redirect("Home.Aspx")
        End If


        Dim dsCuentaCorriente = BLL.CuentaCorriente.GetInstance.GetAdmin()
        Me.grd.DataSource = dsCuentaCorriente
        Me.grd.DataBind()
    End Sub


    Protected Sub GV_AdmFacNC_Paginado(sender As Object, e As GridViewPageEventArgs) Handles grd.PageIndexChanging

        grd.PageIndex = e.NewPageIndex
        Actualizar()



    End Sub

    Protected Sub grd_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grd.RowCommand
        Select Case e.CommandName
            Case "ViewPdf"
                Dim i As Integer = CType(e.CommandArgument, Integer)
                Dim tipo = grd.Rows(i).Cells(2).Text
                Dim numero = grd.Rows(i).Cells(3).Text
                Dim prefix = tipo
                Dim filename = "facturas/" & prefix & "_" & numero & ".pdf"
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "OpenWindow", "window.open('" & filename & "','_newtab');", True)

            Case "Ok"
                ' Dim nroComp As Integer = CType(e.CommandArgument, Integer)
                Dim str As String()
                str = e.CommandArgument.ToString().Split("|")
                Dim numerocomp = str(0)
                Dim iduser = str(1)
                Dim total = str(2)
                Dim tracking = str(3)
                Dim estado = str(4)
                Dim oCC As New BE.CuentaCorriente
                oCC.id = 1
                'altera la existente
                oCC.Conformidad = True
                oCC.descripcion = "Factura-Cancelada"
                oCC.fecha = Date.Now
                oCC.tracking = "Cancelado"
                oCC.estado = estado
                oCC.nroComprobante = numerocomp

                ''SE MODIFICA PARA QE NO PIDA DE NUEVO CANCELACION
                BLL.CuentaCorriente.GetInstance.addCC(oCC)



                'SE GENERA LA NC
                Dim servicesbl As New BLL.servicesBL

                Dim nc As New BE.NotaCredito
                nc.concepto = "Cancelación de factura Nº " & numeroComp
                nc.monto = Total
                nc.fecha = DateTime.Now
                nc.usuario = iduser
                Dim idNC As Integer = BLL.NotaCredito.GetInstance.Add(nc)

                BLL.Tools.generarNC(
                "Nota_de_Credito",
                idNC,
                    nc.concepto,
                servicesbl.Desencriptar3d(BLL.usuarios.GetInstance.GetMailById(nc.usuario)),
                DateTime.Now.ToString("dd/MM/yyyy"),
                nc.monto
            )


                Actualizar()
            Case "NoOk"
                'Dim nroComp As Integer = CType(e.CommandArgument, Integer)
                Dim str As String()
                str = e.CommandArgument.ToString().Split("|")
                Dim numerocomp = Str(0)
                Dim iduser = Str(1)
                Dim total = Str(2)
                Dim tracking = Str(3)
                Dim estado = str(4)
                Dim descripcion = str(5)




                Dim oCCC As New BE.CuentaCorriente
                oCCC.id = 1
                oCCC.usuarioid = iduser
                oCCC.monto = total
                oCCC.tracking = tracking
                oCCC.estado = estado
                oCCC.descripcion = descripcion
                oCCC.nroComprobante = numerocomp
                oCCC.fecha = Date.Now
                oCCC.SolicitudBaja = 0

                BLL.CuentaCorriente.GetInstance.addCC(oCCC)


                Actualizar()


            Case "Llegaron"

                Dim str As String()
                str = e.CommandArgument.ToString().Split("|")
                Dim numerocomp = str(0)
                Dim descripcion = str(1)
                Dim oCCC As New BE.CuentaCorriente
                oCCC.id = 1
                oCCC.estado = "Pagado"
                oCCC.descripcion = descripcion
                oCCC.nroComprobante = numerocomp
                oCCC.fecha = Date.Today
                oCCC.tracking = "Entregado"
                BLL.CuentaCorriente.GetInstance.addCC(oCCC)


                Actualizar()


        End Select

    End Sub


    Protected Sub grd_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles grd.RowCreated

        ''AL GENERAR LAS FILAS VALIDA EL TRACKING PARA ASIGNARLE O NO LA POSIBILIDAD DEL REEMBOLSO DE PRODUCTO
        If Not e.Row.DataItem Is Nothing Then

            Dim solicitudDeBaja = DataBinder.Eval(e.Row.DataItem, "SolicitudBaja")
            Dim trackingok = DataBinder.Eval(e.Row.DataItem, ("Tracking"))
            Dim ctrlNCok = e.Row.FindControl("btnCancelFacOk")
            Dim ctrlNCNOOK = e.Row.FindControl("btnCancelFacNoOk")
            Dim ctrlLlegaron = e.Row.FindControl("btnLlegaronProd")

            If solicitudDeBaja = True Then
                ctrlNCok.Visible = True
                ctrlNCNOOK.Visible = True


            End If

            If solicitudDeBaja = False Then
                ctrlLlegaron.Visible = True
                ctrlNCok.Visible = False
                ctrlNCNOOK.Visible = False


            End If

            If trackingok = "Entregado" Then
                ctrlLlegaron.Visible = False

            End If



        End If




    End Sub


End Class
