<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Tracking.aspx.vb" Inherits="Tracking" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

      <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

   


           <div class="header_slide">
			<div class="header_bottom_left">				
				<div class="categories">
				  <ul>
				  	<h3>FightShop</h3>
				      <li><asp:LinkButton ID="lbHelpDesk" runat="server">Mesa de Ayuda</asp:LinkButton></li>
				      <li><asp:LinkButton ID="lbMisCompras" runat="server">Mi CuentaCorriente</asp:LinkButton></li>
				      <li><asp:LinkButton ID="lbTracking" runat="server">Tracking Compras</asp:LinkButton></li>
                      <li><asp:LinkButton ID="lbMisDatos" runat="server">Mis Datos</asp:LinkButton></li>
				       </ul>
				</div>					
	  	     </div>
             


               <div id="contenido" style="height: 250px; margin-left: 334px; width: 754px;">
                    <asp:Label runat="server" class="page-title">Seguimiento de Compras</asp:Label>

                     <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>

   

        <!-- boton filtrar -->
        <%--<div class="form-group row">
            <div class="col-sm-3">
                <asp:Button class="btn btn-primary mt-1" ID="btnFiltrar" runat="server" Text="Filtrar" formnovalidate />
            </div>
        </div>
    </div>--%>

    <!-- grilla -->
    <asp:GridView ID="grd" runat="server" PageSize="5" AutoGenerateColumns="False" CssClass="table table-striped table-hover table-sm" AllowPaging="True" Height="92px">
         <emptydatatemplate>
            'No hay Compras!
        </emptydatatemplate>   
        <Columns>
            <asp:ButtonField CommandName="ViewPdf" ShowHeader="True" Text='<i class="far fa-file-pdf"></i>'>
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="35px" />
            </asp:ButtonField>
            <asp:BoundField DataField="fecha" HeaderText="Fecha" ApplyFormatInEditMode="True" DataFormatString="{0:dd/MM/yyyy hh:mm}">
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="120px" />
            </asp:BoundField>
            <asp:BoundField DataField="descripcion" HeaderText="Detalle">
                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="200px" />
            </asp:BoundField>
           
            <asp:BoundField DataField="nroComprobante" HeaderText="Nº Comp.">
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="75px" />
            </asp:BoundField>
          
            <asp:BoundField DataField="tracking" HeaderText="tracking">
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
            </asp:BoundField>
          
        </Columns>
    </asp:GridView>


               </div>
		


					 </div>

		   <div class="clear"></div>
  
            
</asp:Content>

