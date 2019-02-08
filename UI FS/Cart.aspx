<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Cart.aspx.vb" Inherits="Cart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link href="//netdna.bootstrapcdn.com/bootstrap/3.2.0/css/bootstrap.min.css" rel="stylesheet" id="bootstrap-css">
<script src="//netdna.bootstrapcdn.com/bootstrap/3.2.0/js/bootstrap.min.js"></script>
<script src="//code.jquery.com/jquery-1.11.1.min.js"></script>
<!------ Include the above in your HEAD tag ---------->

    <%--<script type="text/javascript">
        function myFunction() {
            var rpt1 = document.getElementById('<%=rpt1.ID %>');
            var iCant = rpt1.gete
            alert("hola");
    //var x = document.getElementById("Icantidad").value;
    //var y = document.getElementById("lblPrecio").value;
    //document.getElementById("lblSubtotal").innerHTML = "" + x * y;
    //alert("Valor:" + x*y);
        }
        function f2()
        {
            alert ("hola");
        }
</script>--%>






<link href="//maxcdn.bootstrapcdn.com/font-awesome/4.1.0/css/font-awesome.min.css" rel="stylesheet">

    <asp:Repeater runat="server" ID="rpt1">
        <ItemTemplate>
            <table id="cart" class="table table-hover table-condensed">
                <thead>
						<tr>
							<th style="width:50%">Producto</th>
							<th style="width:10%">Precio</th>
							<th style="width:8%">Cantidad</th>
							<th style="width:22%" class="text-center">Subtotal</th>
							<th style="width:10%"></th>
						</tr>
					</thead>

                <tbody>
						<tr>
							<td data-th="Product">
								<div class="row">
									<div class="col-sm-2 hidden-xs"><asp:image runat="server" imageurl='<%# Eval("img")%>'  alt="..." class="img-responsive" /></div>
									<div class="col-sm-10">
										<h4 class="nomargin"><asp:Label ID="lblNombre" runat="server"  Text='<%# Eval("nombre")%>'></asp:Label></h4>
										<p><asp:Label ID="lblDesc" runat="server"  Text='<%# Eval("descripcion")%>'></asp:Label></p>
								
                                        	</div>
								</div>
							</td>
							<td data-th="Price">$<asp:Label ID="lblPrecio" runat="server"  Text='<%# Eval("precio")%>'></asp:Label></td>
							<td data-th="Quantity"><asp:Label ID="lblCantidad" runat="server" Text='<%# Eval("cantidad")%>' ></asp:Label>

								<%--<input id="Icantidad" runat="server"  class="form-control text-center" />--%>
							</td>
							<td data-th="Subtotal" class="text-center">$<asp:Label ID="lblSubtotal" runat="server" Text='<%# GetSubTotal(Eval("precio"), Eval("cantidad"))%>'></asp:Label></td>
							<td class="actions" data-th="">
                              	<%--<button  class="btn btn-info btn-sm" runat="server" onserverclick='<%# ReCalcular(Eval("precio"), Eval("ICantidad") %>'><i class="fa fa-refresh"></i></button>--%>
                               <%-- <asp:LinkButton ID="hlBtnRecalcular"  UseSubmitBehavior="false" CssClass="btn btn-info btn-sm" runat="server" CommandName="Rec" CommandArgument='<%# Eval("precio") %>'  ><i class="fa fa-refresh"></i></asp:LinkButton>
                             --%>   	<button  class="btn btn-danger btn-sm"><i class="fa fa-trash-o"></i></button>								
							</td>
                           
						</tr>
					</tbody>

                	
					
              
                	


                </table>

     </ItemTemplate>

    </asp:Repeater>
  <table>
       <tr class="visible-xs">
							<%--<td class="text-center"><strong>$<asp:Label ID="lblTotalLinea" runat="server"></asp:Label></strong></td>--%>
						</tr>
						<tr>

							<td><a href="Catalogo.Aspx" class="btn btn-warning" style="padding-right:50px"><i class="fa fa-angle-left"></i> Continuar Pedido</a></td>
							<td colspan="2" class="hidden-xs"></td>
                           
							
                            <td><a href="#" class="btn btn-success btn-block" runat="server" onserverclick="GoPayment">Checkout <i class="fa fa-angle-right" style="padding-right:50px"></i></a></td>
                           </tr>
                            <tr >
                             <asp:Label ID="lblTotalCompra" runat="server" Font-Bold="True" Font-Size="Medium"></asp:Label>
							</tr>
						
    </table>
</asp:Content>

