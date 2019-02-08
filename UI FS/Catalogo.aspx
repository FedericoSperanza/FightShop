<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Catalogo.aspx.vb" Inherits="KimonosCat" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <script>
         function checkBox(Form){ 
            var total = 0; 
            var boxes = form.querySelectorAll('input[type=checkbox]:checked').length;
            if (boxes < 1 || boxes > 5)
                return true;
            else { 
                alert('Seleccionar al menos 2 checkbox'); 
                return false;
            } 
         }
     

        
    </script>



    <%-- <div style="width:100%;height:1000px;">
      --%>

<%--    <div class="categories">
				  <ul>
				  	<h3>Categorias</h3>
				      <li><a href="#">Kimonos</a></li>
				      <li><a href="#">Lycras</a></li>
				      <li><a href="#">Bermudas</a></li>
				      <li><a href="#">Remeras</a></li>
				      <li><a href="#">Guantes</a></li>
				       <li><a href="#">Protecciones</a></li>
				  </ul>
				</div>--%>
    <div>
          <div runat="server" visible="false" id="regSuccess" class="alert alert-warning" role="alert"/>
               
         
 
        <div id="divBusquedaAvanzada" style="width: 172px; float:left;background-color: Menu; height: 433px; border-style: groove;" runat="server">
            <div style="width: 100%; margin-top: 2vh">
                <asp:Label runat="server" for="lblCategoria" Font-Bold="True" style="margin-top: 2vh">Categoria:</asp:Label>
                <asp:DropDownList ID="ddlCategoria" runat="server" class="form-control" required DataTextField="nombre" DataValueField="id" Width="146px">
                </asp:DropDownList>
            </div>

            <div style="width: 100%; margin-top: 2vh">
                <asp:Label runat="server" for="dllTipoServicio" Font-Bold="True" style="margin-top: 2vh">Precio:</asp:Label>
                <div style="width: 100%; display: flex; justify-content: flex-start">
                   
                    <asp:TextBox ID="txtDesde" runat="server" class="form-control" TextMode="Number" Height="35px" Width="68px"></asp:TextBox>
                    <span style="margin-left: 1vh; margin-right: 1vh;">-</span>
                   
                    <asp:TextBox ID="txtHasta" runat="server" class="form-control" TextMode="Number" Height="35px" Width="68px"></asp:TextBox>
                </div>
            </div>

            <div style="width: 100%; display: flex; justify-content: space-around; margin-top: 2vh">
                <asp:Button class="btn btn-primary mt-1" ID="btnFiltrar" runat="server" Text="Aplicar" formnovalidate />

                <br />
                <asp:Button class="btn btn-primary mt-1" ID="btnComparar" runat="server" Text="Comparar" Visible="true" formnovalidate />


            </div>
            <br />
            <br />

            Buscar por KeyWord
             <asp:TextBox CssClass="form-control mr-sm-2" id="txtsearch" runat="server" aria-label="Search" Width="110px"></asp:TextBox>
         <asp:linkbutton runat="server" ID="btnSearch" class="btn btn-outline-success my-2 my-sm-0" type="submit" Height="26px" Width="28px"><span aria-hidden="true" class="glyphicon glyphicon-search"></span></asp:linkbutton>
 

        </div>

     <div style="width:100%;height:1000px; margin-left: 204px;">
      

        <asp:Repeater ID="rpt1" runat="server">

            <ItemTemplate>

                   <div class="grid_1_of_4 images_1_of_4" runat="server" style="margin:0 auto">
					
                       <asp:Image ID="Image1" runat="server"  style="width:200px;height:200px"   ImageUrl='<%# Eval("img")%>'  />

					 <h2> <p><span class="rupees"><asp:Label ID="lblNombre" runat="server"  Text='<%# Eval("nombre")%>'></asp:Label></span></p></h2>
					<div class="price-details">
				       <div class="price-number">
							<p><span class="rupees">$<asp:Label ID="lblPrecio" runat="server"  Text='<%# Eval("precio")%>'></asp:Label></span></p>
					    </div>
					       		<div class="add-cart" runat="server">		<input id="chkCompare" name="chkCompare" runat="server" type="checkbox"  />						
									<h4>
                                         <asp:Button CssClass="button" ID="btnVer" runat="server" Height="25px" style="font-size:12px;text-align: center;" Text="Ver" OnCommand="ValidarCommand" CommandName="ShowProduct" CommandArgument='<%# Eval("nombre")%>'  />
                                       
                                      <%--  <asp:Button CssClass="button" ID="btnAddCart" runat="server" Height="25px" style="font-size:12px;text-align: center; " Text="Comprar" OnCommand="ValidarCommand" CommandName="AddCart" CommandArgument='<%# Eval("precio") %>'  />
                                    --%>     <%--<a href="#" class="button">Añadir Compra</a>--%></h4>
							     </div>
							 <div class="clear"></div>
					</div>
					 
				</div>

            </ItemTemplate>

        </asp:Repeater>


         
                                      











       </div>
   </div>

</asp:Content>

