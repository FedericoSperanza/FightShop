<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="RankingProductos.aspx.vb" Inherits="RankingProductos" %>

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

            <h1> LOS PRODUCTOS MAS VOTADOS </h1>



       <asp:Repeater ID="rpt1" runat="server">

            <ItemTemplate>

                   <div class="grid_1_of_4 images_1_of_4" runat="server" style="margin:0 auto">
					  
                       <asp:Image ID="Image1" runat="server"  style="width:150px;height:150px"   ImageUrl='<%# Eval("img")%>'  />

					 <h2> <p><span class="rupees"><asp:Label ID="lblNombre" runat="server"  Text='<%# Eval("nombre")%>'></asp:Label></span></p></h2>
					<div class="price-details">
				       <div class="price-number">
							<p><span class="rupees">$<asp:Label ID="lblPrecio" runat="server"  Text='<%# Eval("precio")%>'></asp:Label></span></p>
					    </div>
					       		<div class="add-cart" runat="server">
                                       <ajaxtoolkit:rating 
                        ID="rating" 
                        runat="server"
                        StarCssClass="Star"
                        WaitingStarCssClass="WaitingStar" 
                        EmptyStarCssClass="Star"
                        FilledStarCssClass="FilledStar"
                        readonly="true"
                                           
                       
                       
                     
                    AutoPostBack="True" CurrentRating='<%#Eval("rank")%>'>
                    </ajaxtoolkit:rating> 
									<h4>
                                          

                                         <asp:Button CssClass="button" ID="btnVer" runat="server" Height="25px" style="font-size:12px;text-align: center;" Text="Ver" OnCommand="ValidarCommand" CommandName="ShowProduct" CommandArgument='<%# Eval("nombre")%>'  />
                                       
                                    </h4>
							     </div>
							 <div class="clear"></div>
					</div>
					 
				</div>

            </ItemTemplate>

        </asp:Repeater>

        </div>







</asp:Content>

