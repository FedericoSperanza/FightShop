<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Noticias.aspx.vb" Inherits="Noticias" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   <div style="width:100%;height:670px; margin-left: 204px;">
      

        <asp:Repeater ID="rpt1" runat="server">

            <ItemTemplate>

                   <div class="grid_1_of_4 images_1_of_4" runat="server" style="margin:0 auto;width:230px;height:310px ">
					
                       <asp:Image ID="Image1" runat="server"  style="width:150px;height:150px"   ImageUrl='<%# Eval("img")%>'  />

					 <h2> <p><span class="rupees"><asp:Label ID="lblNombre" runat="server"  Text='<%# Eval("nombre")%>'></asp:Label>
                         <asp:Label ID="hdlblID" runat="server" visible="false" Text='<%# Eval("id")%>'></asp:Label>
					         </span></p></h2>
					<div class="price-details">
				       <div class="price-number">
							<p><span class="rupees"><asp:label ID="lbldescripcion" runat="server"  Text='<%#LimitCharacter(Eval("descripcion").ToString())%>' MaxLength="5" Font-Size="X-Small"></asp:label>
					 
                                         <asp:Button CssClass="button" ID="btnVer" runat="server" Height="25px" style="font-size:12px;text-align: center;" Text="Saber Mas" OnCommand="ValidarCommand" CommandName="ShowNoticia" CommandArgument='<%# Eval("id")%>'  /></span></p>
                                       <%----%> 
                                       
                             </div>
					       			
                                     
							  
							 <div class="clear"></div>
					</div>
					 
				</div>

            </ItemTemplate>

        </asp:Repeater>


         
                                      











       </div>
   </div>

</asp:Content>

