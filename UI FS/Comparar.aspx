<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Comparar.aspx.vb" Inherits="Comparar" %>




<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   
     <style type="text/css">

           .item-body {
        width: 100%;
        height: 150px;
        overflow-y: scroll;
        flex-grow: 1;
    }




  </style>
    <script lang="javascript">
// function checkBox(form){ 
//    var total = 0; 
//    var boxes = form.querySelectorAll('input[type=checkbox]:checked').length;
//    if (boxes < 1 || boxes > 5)
//        return true;
//    else { 
//        alert('Seleccionar al menos 2 checkbox'); 
//        return false;
//    } 
        //}

</script>


     <div style="width:100%;height:1000px; margin-left: 73px;">
      

        <asp:Repeater ID="rpt1" runat="server">

            <ItemTemplate>

                   <div class="grid_1_of_4 images_1_of_4" runat="server" style="margin:0 auto">
					
                       <asp:Image ID="Image1" runat="server"  style="width:150px;height:150px"   ImageUrl='<%# Eval("img")%>'  />

					 <h2> <p><span class="rupees"><asp:Label ID="lblNombre" runat="server" Text='<%# Eval("nombre")%>' Font-Bold="True"></asp:Label></span></p></h2>
					<div class="price-details">
				       <div class="price-number">
							<b>Precio:</b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp $<asp:Label ID="lblPrecio" runat="server"  Text='<%# Eval("precio")%>'></asp:Label>
					    </div>
                       
                        <br />
                          <div class="price-number">
                            <b>Descripcion:</b>   <asp:Label ID="lblDetails" runat="server"  Text='<%# Eval("descripcion")%>'></asp:Label>
                               <%-- <div class="item-body"><%# Eval("descripcion") %></div>--%>
                        </div>
                      
					       		<div class="add-cart" runat="server">						
									<h4>
                                           <asp:Button CssClass="button" ID="btnAddCart" runat="server" Height="25px" style="font-size:12px;text-align: center; " Text="Comprar" />
                                         <%--<a href="#" class="button">Añadir Compra</a>--%></h4>
							     </div>
							 <div class="clear"></div>
					</div>
					 
				</div>

            </ItemTemplate>

        </asp:Repeater>


         
                                      











       </div>
   
</asp:Content>

