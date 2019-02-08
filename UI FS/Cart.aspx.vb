Imports BE.GlobalUsuario
Partial Class Cart
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        If Not (Page.IsPostBack) Then


            Dim dsproductos As New List(Of BE.Cart)
            Dim rSearch As New BE.Cart
            Dim nombresearch As String



            dsproductos = Session("Cart")

            rpt1.DataSource = dsproductos
            rpt1.DataBind()

            'valido que el producto ya este ingresado

            For Each rItem As RepeaterItem In rpt1.Items
                Dim lbl As Label = DirectCast(rItem.FindControl("lblNombre"), Label)
                If Not IsNothing(lbl) Then
                    'Dim value As String = (lbl.Text)
                    Dim lista As New List(Of BE.Cart)
                    lista = Session("Cart")
                    For Each oproductoscart As BE.Cart In lista
                        If Session("CartNewProd") IsNot Nothing Then



                            If lbl.Text = Session("CartNewProd").ToString Then
                                rSearch = lista.Find(Function(c) c.nombre = lbl.Text)
                                nombresearch = rSearch.nombre.ToString

                            End If
                        End If




                    Next



                End If
            Next

            If nombresearch Is Nothing Then
                dsproductos = Session("Cart")
                Session("aFacturar") = Session("Cart")
                rpt1.DataSource = Session("Cart")
                rpt1.DataBind()
            Else
                Dim lstchange As New List(Of BE.Cart)
                lstchange = Session("cart")
                lstchange.RemoveAll(Function(producto) producto.nombre = rSearch.nombre.ToString)
                lstchange.Add(Session("oNewProd"))

                Session("aFacturar") = lstchange
                rpt1.DataSource = lstchange
                rpt1.DataBind()


            End If


            'Dim dsproductos As New List(Of BE.Productos)
            'dsproductos = BLL.Productos.FiltrarCatalogo()


            'rpt1.DataSource = dsproductos

            'rpt1.DataBind()

        End If


        CalcularTotal()











    End Sub

    Sub CalcularTotal()
        Dim total As Double
        Dim subtotal As Double
        For Each rItem As RepeaterItem In rpt1.Items
            Dim lbl As Label = DirectCast(rItem.FindControl("lblSubtotal"), Label)
            If Not IsNothing(lbl) Then
                subtotal = Convert.ToInt32(lbl.Text)
                total = total + subtotal




            End If
        Next

        lblTotalCompra.Text = "Total Compra : $" & total
        Session("TotalPayment") = total
        Session("TotalPaymentStatic") = total
        ''validar si es $0 entonces mostrar qe no hay items
    End Sub

    Function GetSubTotal(precio As Double, cantidad As Integer) As Double

        Return precio * cantidad

    End Function

    Sub GoPayment()

        'Session("aFacturar") = rpt1.DataSource
        Session("ClickPay") = True
        Response.Redirect("Payment.Aspx")


    End Sub

    Function ReCalcular(precio As Double, cantidad As Integer) As Double
        Return precio * cantidad

    End Function

    Protected Sub rpt1_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.RepeaterCommandEventArgs) Handles rpt1.ItemCommand
        'ACA HACER EL BORRADO
        If (e.CommandName = "Delete") Then
            Dim cantidad As HtmlInputControl
            Dim cantint As Integer
            cantidad = e.Item.FindControl("Icantidad")

            cantint = cantidad.Value



        End If


    End Sub

End Class
