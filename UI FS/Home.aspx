<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Home.aspx.vb" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   
     



 

           <div class="header_slide">
			<div class="header_bottom_left">				
				<div class="categories">
				  <ul>
                      

				  	<h3>Categorias</h3>
				      <li><%--<a href="KimonosCat.Aspx" >Kimonos</a>--%>
                         <asp:LinkButton ID="lbKimonos" runat="server">Kimonos</asp:LinkButton>
				      </li>
				      <li><asp:LinkButton ID="lbLycras" runat="server">Lycras</asp:LinkButton></li>
				      <li><asp:LinkButton ID="lbBermudas" runat="server">Bermudas</asp:LinkButton></li>
				      <li><asp:LinkButton ID="lbRemeras" runat="server">Remeras</asp:LinkButton></li>
				      <li><asp:LinkButton ID="lbGuantes" runat="server">Guantes</asp:LinkButton></li>
				       <li><asp:LinkButton ID="lbProtecciones" runat="server">Protecciones</asp:LinkButton></li>
				  </ul>
				</div>					
	  	     </div>

                <div style="width: 63%; display: flex; justify-content: center; flex-direction: row; ">
        <asp:AdRotator ID="AdRotator1" runat="server" height="130px" Width="600px"   AdvertisementFile="~/publicidades/XMLFile.xml"/>
    </div>



            <%--   
                
                
                <div id="carouselExampleIndicators"  class="carousel slide" data-ride="carousel" style="left: 0px; top: 0px; width: 63%">
  <ol class="carousel-indicators">
    <li data-target="#carouselExampleIndicators" data-slide-to="0" class="active"></li>
    <li data-target="#carouselExampleIndicators" data-slide-to="1"></li>
    <li data-target="#carouselExampleIndicators" data-slide-to="2"></li>
  </ol>
  <div class="carousel-inner">
    <div class="carousel-item active">
      <img class="d-block w-100" src="images/slide1_test.jpg" alt="First slide">
    </div>
    <div class="carousel-item">
      <img class="d-block w-100" src="images/slide2_test.jpg" alt="Second slide">
    </div>
    <div class="carousel-item">
      <img class="d-block w-100" src="images/slide3.png" alt="Third slide">
    </div>
  </div>
  <a class="carousel-control-prev" href="#carouselExampleIndicators" role="button" data-slide="prev">
    <span class="carousel-control-prev-icon" aria-hidden="true"></span>
    <span class="sr-only">Previous</span>
  </a>
  <a class="carousel-control-next" href="#carouselExampleIndicators" role="button" data-slide="next">
    <span class="carousel-control-next-icon" aria-hidden="true"></span>
    <span class="sr-only">Next</span>
  </a>
</div>--%>
					 

		   <div class="clear"></div>

               

		</div>

     <%-- ENCUESTA --%>
    <%--class="card"--%>
          <div runat="server" id="divEncuesta" class="card" style="width: 18rem; position: fixed; bottom: 200px; right: 20px; border-width: 2px; border-color: black">
            <div id="divEncuestaPreguntas" runat="server" class="card-body" visible="true">
                <h5 class="card-title">Encuesta</h5>
                <p class="card-text" runat="server" id="encuestaText"></p>
                <asp:Repeater ID="rptEncuestaOpciones" runat="server">
                    <ItemTemplate>
                        <asp:LinkButton
                            class="btn btn-primary"
                            runat="server"
                            UseSubmitBehavior="false"
                            CommandArgument='<%# Eval("id") %>'>
                                <%# Eval("nombre") %>
                        </asp:LinkButton>
                         </ItemTemplate>
                </asp:Repeater>
            </div>
            
            <div ID="divEncuestaChart" runat="server"  class="card-body" visible="false" style="width: 160px;  margin-left: 0px">
                <h5 class="card-title">Resultados</h5>
                <asp:Chart ID="chartEncuesta" runat="server" width="160px">
                    <Series>
                        <asp:Series Name="Series1" ></asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                    </ChartAreas>
                </asp:Chart>
            </div>

                <asp:LinkButton class="nav-link" ID="btnCloseEncuesta" runat="server" Style="position: absolute; right: 0; top: 0">
                <i class="fas fa-times"></i>
            </asp:LinkButton>
              
    
               </div>
 
       

</asp:Content>

