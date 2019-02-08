Imports System.Web.UI.DataVisualization.Charting
Partial Class Payment
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not (Page.IsPostBack) Then


            actualizar()


        End If
    End Sub

    Sub deshabilitarpagoTC()
        PanelpagoTC.Visible = False
        regSuccess.Visible = True
        regSuccess.Attributes("class") = "alert alert-success"
        regSuccess.InnerText = "Proceder al pago con Nota Credito !"


    End Sub
    Sub deshabilitarpagoTC2()
        PanelpagoTC.Visible = False
        regSuccess.Visible = True
        'regSuccess.Attributes("class") = "alert alert-success"
        'regSuccess.InnerText = "Proceder al pago con Nota Credito !"


    End Sub



    Protected Sub grd_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles grd.PageIndexChanging
        grd.PageIndex = e.NewPageIndex
        actualizar()
    End Sub



    Private Function CurrencyToDouble(ByVal CurrencyString As String) As Double
        Dim TempStr As New System.Text.StringBuilder
        For i As Integer = 0 To CurrencyString.Length - 1
            If CurrencyString(i) = "," Or CurrencyString(i) = "." Or (CurrencyString(i) >= "0" And CurrencyString(i) <= "9") Then
                TempStr.Append(CurrencyString(i))
            End If
        Next

        Dim MyDouble As Double
        If Double.TryParse(TempStr.ToString, MyDouble) = False Then
            MyDouble = -1
        End If
        Return MyDouble
    End Function



    Public Sub gr_rowCommand(sender As Object, e As GridViewCommandEventArgs)
        If (e.CommandName = "Add") Then
            If Me.dvPrecio.InnerHtml = "$" & 0 Then
                ''poner regsuccess
                'no se pueden usar mas NC

                Return

            End If
            Dim rowid As Integer
            Dim nc As Double = 0
            Dim preciodescontado As Double
            rowid = (e.CommandArgument)
            nc += CurrencyToDouble(grd.Rows(rowid).Cells(4).Text)
            preciodescontado = Convert.ToDouble(Session("TotalPayment")) - nc

            If preciodescontado < 0 Then
                Session("Diferencia") = preciodescontado
                preciodescontado = 0
            End If

            Session("TotalPayment") = preciodescontado

            Me.dvPrecio.InnerHtml = "$" & Session("TotalPayment") '.ToString("C2")

            Dim lbuttonModif As New LinkButton
            Dim lbuttonToShow As New LinkButton
            lbuttonToShow = grd.Rows(rowid).FindControl("hlbtnDesAdd")

            lbuttonModif = grd.Rows(rowid).FindControl("hlbtnAdd")

            lbuttonModif.Visible = False
            lbuttonToShow.Visible = True

            'Lista de NC
            If Session("ListNC") Is Nothing Then
                Dim lstint As New List(Of Integer)
                lstint.Add(rowid)

                Session("ListNC") = lstint
            Else
                Session("ListNC").add(rowid)

            End If


            ''Verifico si el Total a pagar es $0

            If Session("TotalPayment") = 0 Then

                Dim diferencia As Integer
                diferencia = Convert.ToInt32(Session("TotUsedNC")) - Convert.ToInt32(Session("TotalPaymentStatic"))
                If diferencia > 0 Then

                    regSuccess.Visible = True
                    regSuccess.Attributes("class") = "alert alert-success"
                    regSuccess.InnerText = "Existe una diferencia a su favor, si abona la perderá!"
                    deshabilitarpagoTC2()
                    btnIrAlCatalogo.Visible = True


                    'VER DE COMENTAR ESTO CUANDO SEA NECESARIO


                Else
                    deshabilitarpagoTC()

                End If






                'deshabilitar todos los lbADD


            End If


        Else
            Dim rowid As Integer
            Dim nc As Double = 0
            Dim preciodescontado As Double
            rowid = (e.CommandArgument)
            nc += CurrencyToDouble(grd.Rows(rowid).Cells(4).Text)

            If Session("Diferencia") IsNot Nothing Then
                preciodescontado = Convert.ToDouble(Session("TotalPayment")) - Convert.ToDouble(Session("Diferencia"))


                Session("TotalPayment") = preciodescontado
            Else
                preciodescontado = Convert.ToDouble(Session("TotalPayment")) + nc


                Session("TotalPayment") = preciodescontado
            End If

            'preciodescontado = Convert.ToDouble(Session("TotalPayment")) + nc


            'Session("TotalPayment") = preciodescontado

            Me.dvPrecio.InnerHtml = "$" & Session("TotalPayment") '.ToString("C2")

            Dim lbuttonModif As New LinkButton
            Dim lbuttonToShow As New LinkButton
            lbuttonToShow = grd.Rows(rowid).FindControl("hlbtnAdd")

            lbuttonModif = grd.Rows(rowid).FindControl("hlbtnDesAdd")

            Session("ListNC").remove(rowid)


            lbuttonModif.Visible = False
            lbuttonToShow.Visible = True
            PanelpagoTC.Visible = True
            regSuccess.Visible = False

        End If


    End Sub

    Protected Sub grd_SelectedIndexChanging(sender As Object, e As GridViewSelectEventArgs) Handles grd.SelectedIndexChanging
        Dim r As GridViewRow = Me.grd.Rows(e.NewSelectedIndex)
        Dim idNC = grd.DataKeys(e.NewSelectedIndex).Value



    End Sub


    Public Sub actualizar()
        If Session("UserId") IsNot Nothing Then



            If Session("ClickPay") = True Then

                dvTitle.InnerText = "Total a Pagar"
                dvPrecio.InnerText = "$" & Session("TotalPayment")


                Dim ncs = BLL.NotaCredito.GetInstance.GetByUsuarioId(Session("UserId"))
                grd.DataSource = ncs
                grd.DataBind()
                Me.rowNotasDeCredito.Visible = ncs.Count > 0


            Else
                Response.Redirect("Home.Aspx")

            End If

        Else
            Response.Redirect("Registrarse.Aspx")
        End If

        If Session("abonado") = True Then
            Session("abonado") = False
            'showmodal()

        End If


    End Sub

    Protected Sub btnConfirmarPago_Click(sender As Object, e As EventArgs) Handles btnConfirmarPago.Click
        ''ACA SE CARGA LAS LINEAS DE LA FACTURA
        Dim lstCheckout As New List(Of BE.Cart)

        lstCheckout = Session("aFacturar")

        If PanelpagoTC.Visible = True Then



            If txtNroTarjeta.Text.Length < 19 Then
                regSuccess.Visible = True
                regSuccess.Attributes("class") = "alert alert-danger"
                regSuccess.InnerText = "Número de tarjeta no válido"

                Return
            End If
            If txtNombre.Text.Length < 1 Then
                regSuccess.Visible = True
                regSuccess.Attributes("class") = "alert alert-danger"
                regSuccess.InnerText = "Nombre del titular no válido"

                Return
            End If
            Dim thisDt As DateTime
            Dim expiracion = "01/" & txtExpiracion.Text
            Dim b = DateTime.TryParse(expiracion, thisDt)
            If expiracion.Length < 10 Or Not DateTime.TryParse(expiracion, thisDt) Then
                regSuccess.Visible = True
                regSuccess.Attributes("class") = "alert alert-danger"
                regSuccess.InnerText = "Fecha de expiracion no valida"
                Return
            End If
            If thisDt < DateTime.Now Then
                regSuccess.Visible = True
                regSuccess.Attributes("class") = "alert alert-danger"
                regSuccess.InnerText = "Tarjeta vencida"
                Return
            End If
            If txtCodSeg.Text.Length < 3 Then
                regSuccess.Visible = True
                regSuccess.Attributes("class") = "alert alert-danger"
                regSuccess.InnerText = "Código de seguridad no válido"

                Return
            End If
            If txtDNI.Text.Length < 7 Then
                regSuccess.Visible = True
                regSuccess.Attributes("class") = "alert alert-danger"
                regSuccess.InnerText = "Número de documento no válido !"

                Return
            End If
        End If

        ''Actualizar NC SALDO si las HAY

        Dim Total = Session("TotalPaymentStatic")
        'For Each r As GridViewRow In grd.Rows
        '    If TryCast(r.FindControl("chkSelect"), CheckBox).Checked And Total > 0 Then
        '        Dim ncId = grd.DataKeys(r.RowIndex).Value
        '        Dim nc_saldo = CurrencyToDouble(r.Cells(3).Text)
        '        If nc_saldo < Total Then
        '            BLL.NotaCredito.GetInstance.setSaldo(ncId, 0)
        '        Else


        '            BLL.NotaCredito.GetInstance.setSaldo(ncId, nc_saldo - Total)
        '        End If
        '        Total -= nc_saldo
        '    End If
        'Next
        Dim listNC As List(Of Integer)
        listNC = Session("ListNC")


        If listNC IsNot Nothing Then


            For Each inddex As Integer In listNC
                Dim ncId = grd.DataKeys(inddex).Value
                Dim nc_saldo = CurrencyToDouble(grd.Rows(inddex).Cells(4).Text)
                If nc_saldo < Total Then
                    BLL.NotaCredito.GetInstance.setSaldo(ncId, 0)
                    Total = Total - nc_saldo
                    Session("NCused") = True
                    Session("TotUsedNC") += nc_saldo
                    Session("NumNCused") += ncId & ";"
                Else
                    Total = (Total - nc_saldo)
                    Dim saldoGuardado As Double



                    If Total = 0 Then
                        saldoGuardado = 0

                    ElseIf Total < 0 Then
                        saldoGuardado = -(Total)

                        'PONE EN POSITIVO EL SALDO XQ HAY DIFERENCIA
                    ElseIf Total > 0 Then
                        'no queda diferencia
                        saldoGuardado = 0


                    End If


                    BLL.NotaCredito.GetInstance.setSaldo(ncId, saldoGuardado)
                    Session("NCused") = True

                    If Total = 0 Then

                        Session("TotUsedNC") += nc_saldo
                    ElseIf Total > 0 Then
                        Session("TotUsedNC") += nc_saldo

                    ElseIf Total < 0 Then
                        ''diferencia a favor
                        Session("TotUsedNC") += (nc_saldo) - (-(Total))


                    End If

                    Session("NumNCused") += ncId & ";"

                End If
                ' Total -= nc_saldo

            Next
        End If


        'PROCESAMIENTO DE PAGO

        'Dim oPago As New BE.Pagos
        'oPago.nombreApellido = txtNombre.Text

        'oPago.codigoSeguridad = Me.txtCodSeg.Text
        'oPago.dni = Me.txtDNI.Text
        'oPago.expiracion = CDate(Me.txtExpiracion.Text)
        'oPago.formaPago = ddlFormaPago.SelectedItem.Text
        'oPago.monto = Session("TotalPayment")
        'oPago.numeroTarjeta = txtNroTarjeta.Text
        'BLL.Pago.GetInstance.Add(oPago)




        ' GENERACION


        Dim F As New BE.Factura
        F.fecha = Date.Now
        F.usuario = Session("UserId")

        F.valtot = Session("TotalPaymentStatic")

        Dim lstDetFac As New List(Of BE.FacturaItem)

        For Each itemDetFac As BE.Cart In lstCheckout
            Dim oDetFac As New BE.FacturaItem
            oDetFac.cantidad = itemDetFac.cantidad
            oDetFac.preciounitario = itemDetFac.precio
            oDetFac.monto = Convert.ToInt32(itemDetFac.cantidad) * Convert.ToInt32(itemDetFac.precio)
            oDetFac.descripcion = itemDetFac.nombre
            F.items.Add(oDetFac)




        Next



        Dim facturaID As Integer = BLL.Factura.GetInstance.addFactura(F)

        ''CUENTA CORRIENTE Y LUEGO TRACKING
        Dim oCC As New BE.CuentaCorriente
        If Session("NCused") = True Then


            oCC.id = 0
            'SE PONE 0 PARA QUE SEA CREATE !!
            oCC.descripcion = "Factura-NC"
            oCC.NC = Session("TotUsedNC")
        Else
            oCC.descripcion = "Factura"
        End If

        oCC.estado = "Pagado"
        oCC.fecha = Date.Today
        oCC.monto = Session("TotalPaymentStatic")
        oCC.nroComprobante = facturaID
        oCC.usuarioid = Session("UserId")
        oCC.Conformidad = 0
        oCC.SolicitudBaja = 0

        BLL.CuentaCorriente.GetInstance.addCC(oCC)


        ''generar comprobante
        Dim mailUsuario As String
        mailUsuario = BLL.usuarios.GetInstance.GetMailById(F.usuario)
        Dim tls As New BLL.servicesBL
        mailUsuario = tls.Desencriptar3d(mailUsuario)
        If Session("NCused") Then

            BLL.Tools.generarComprobante(
        "FACTURA-NC",
        facturaID,
       mailUsuario,
        DateTime.Now.ToString("dd/MM/yyyy"),
       F.items,
       Session("TotalPaymentStatic"),
        Session("NumNCused")
    )
        Else
            BLL.Tools.generarComprobante(
           "FACTURA",
           facturaID,
          mailUsuario,
           DateTime.Now.ToString("dd/MM/yyyy"),
          F.items,
          Session("TotalPayment")
       )
        End If







        Session("abonado") = True




        Session("Cart") = Nothing


        contenedorGlobal.Visible = False
        regSuccess.Visible = True
        regSuccess.Attributes("class") = "alert alert-success"
        regSuccess.InnerText = "Pago Acreditado ! "

        ''PONER BOTON DE TRACKING

        Session("TotUsedNC") = Nothing
        Session("TotalPaymentStatic") = Nothing
        Session("TotalPayment") = Nothing

        setEncuesta()




    End Sub

    Protected Sub setEncuesta()
        Dim e = BLL.Encuesta.getRandom(True)
        If Not e Is Nothing Then
            lblPagar.Visible = False
            divEncuesta.Visible = True
            ViewState("encuestaId") = e.id
            Me.encuestaText.InnerHtml = e.nombre
            rptEncuestaOpciones.DataSource = e.opciones
            rptEncuestaOpciones.DataBind()
        End If
    End Sub


    Public Sub btnTracking()

        Response.Redirect("MisCompras.Aspx")
    End Sub

    Protected Sub rptEncuestaOpciones_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.RepeaterCommandEventArgs) Handles rptEncuestaOpciones.ItemCommand
        BLL.Encuesta.GetInstance.votar(CInt(e.CommandArgument))

        Dim enc = BLL.Encuesta.GetInstance.GetById(ViewState("encuestaId"))
        Dim Dvista As New System.Data.DataView(BLL.Tools.GetInstance.ToDataTable(Of BE.EncuestaOpcion)(enc.opciones))
        chartEncuesta.Series(0).Points.DataBindXY(Dvista, "nombre", Dvista, "valor")
        chartEncuesta.Series(0).ChartType = SeriesChartType.Pie
        chartEncuesta.ChartAreas(0).Area3DStyle.Enable3D = True

        divEncuestaChart.Visible = True
        divEncuestaPreguntas.Visible = False

        botonTracking.Visible = True


    End Sub



    Protected Sub btnIrAlCatalogo_Click(sender As Object, e As EventArgs) Handles btnIrAlCatalogo.Click
        Response.Redirect("Catalogo.Aspx")
    End Sub
End Class
