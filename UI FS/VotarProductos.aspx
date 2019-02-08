<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="VotarProductos.aspx.vb" Inherits="VotarProductos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
       <style type="text/css">
        .Star
        {
            background-image: url(images/Star.gif);
            height: 17px;
            width: 17px;
        }
        .WaitingStar
        {
            background-image: url(images/WaitingStar.gif);
            height: 17px;
            width: 17px;
        }
        .FilledStar
        {
            background-image: url(images/FilledStar.gif);
            height: 17px;
            width: 17px;
        }
    </style>
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></ajaxToolkit:ToolkitScriptManager>
                


      <div style="width:100%;height:500px; margin-left: 50px;">

            <h2> Valoracion de Productos </h2>

              <div runat="server" visible="false" id="regSuccess" class="alert success-success" role="alert">
    </div>

       <asp:Repeater ID="rpt1" runat="server" >

            <ItemTemplate>

                   <div class="grid_1_of_4 images_1_of_4" runat="server" style="margin:0 auto">
					  
                       <asp:Image ID="Image1" runat="server"  style="width:150px;height:150px"   ImageUrl='<%# Eval("foto")%>'  />

					 <h2> <p><span class="rupees"><asp:Label ID="lblNombre" runat="server"  Text='<%# Eval("descripcion")%>'></asp:Label></span></p></h2>
					<div class="price-details">
				     
					       		<div class="add-cart" runat="server">
                                       <ajaxtoolkit:rating 
                        ID="rating" 
                        runat="server"
                                           clientid='<%# Eval("id")%>'
                                           tag='<%# Eval("id")%>'
                        StarCssClass="Star"
                        WaitingStarCssClass="WaitingStar" 
                        EmptyStarCssClass="Star"
                        FilledStarCssClass="FilledStar"
                          onchanged="OnRatingChanged"
                                           
                                           
                       
                       
                     
                    AutoPostBack="True" >
                    </ajaxtoolkit:rating> 
									<h4>
                                          

                                       
                                    </h4>
							     </div>
							 <div class="clear"></div>
					</div>
					 
				</div>

            </ItemTemplate>

        </asp:Repeater>

        </div>



</asp:Content>

