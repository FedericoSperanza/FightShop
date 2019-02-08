<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="MisCompras.aspx.vb" Inherits="MisCompras" %>

<%@ Register Src="UserControls/Calendario.ascx" TagName="datePicker" TagPrefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   
      <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

   


           <div class="header_slide">
			<div class="header_bottom_left">				
				<div class="categories">
				  <ul>
				  	<h3>FightShop</h3>
				      <li><%--<a href="KimonosCat.Aspx" >Kimonos</a>--%>
                         <asp:LinkButton ID="lbCompras" runat="server">Cuenta Corriente</asp:LinkButton>
				      </li>
				         <li><asp:LinkButton ID="lbMensajeria" runat="server">Mensajeria</asp:LinkButton></li>
				   	        </ul>
				</div>					
	  	     </div>
             


               <div id="contenido" style="height: 250px; margin-left: 334px; width: 754px;">
                    <asp:Label runat="server" class="page-title">Mi Cuenta Corriente</asp:Label>

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
    <asp:GridView ID="grd" runat="server" PageSize="5" AutoGenerateColumns="False" CssClass="table table-striped table-hover table-sm" AllowPaging="True" Height="92px" Font-Size="X-Small">
         <emptydatatemplate>
            'No hay Compras!
        </emptydatatemplate>   
        <Columns>
            <asp:ButtonField CommandName="ViewPdf" ShowHeader="True" Text='<i class="far fa-file-pdf"></i>'>
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="35px" />
            </asp:ButtonField>
            <asp:BoundField DataField="fecha" HeaderText="Fecha" ApplyFormatInEditMode="True" DataFormatString="{0:dd/MM/yyyy}">
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="120px" />
            </asp:BoundField>
            <asp:BoundField DataField="descripcion" HeaderText="Detalle">
                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="200px" />
            </asp:BoundField>
           
            <asp:BoundField DataField="nroComprobante" HeaderText="Nº Fac.">
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="75px" />
            </asp:BoundField>
           <asp:BoundField DataField="debe" HeaderText="Debe" DataFormatString="${0}">
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
            </asp:BoundField>
             <asp:BoundField DataField="haber" HeaderText="Haber" DataFormatString="${0}" >
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
            </asp:BoundField>
            

            <asp:BoundField DataField="estado" HeaderText="Estado">
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
            </asp:BoundField>
            <asp:BoundField DataField="Tracking" HeaderText="Tracking">
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
            </asp:BoundField>

            <asp:BoundField DataField="SolicitudBaja" Visible="false" HeaderText="hdnSolicitudBaja">
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
            </asp:BoundField>

            <asp:BoundField DataField="Conformidad" Visible="false" HeaderText="hdnConformidad">
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
            </asp:BoundField>


            <%-- BOTON DE SOLICITUD DE CANCELACION DE FACTURA --%>
             <asp:TemplateField>
                <ItemStyle HorizontalAlign="Center" Width="100px" />
                <ItemTemplate>
                 <span id="spnGuion" runat="server">-</span>
                    <asp:LinkButton ID="btnCancelFac" runat="server" CommandName="CancelFac" CommandArgument='<%#Eval("nroComprobante") & "|" & Eval("estado") & "|" & Eval("descripcion") & "|" & Eval("tracking") & "|" & Eval("conformidad")    %>' Text="<i class='fas fa-hand-holding-usd fa-2x'></i>"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>

            <%-- BOTON DE CONFORMIDAD DE RECEPCION DE PRODUCTOS --%>
             <asp:TemplateField>
                <ItemStyle HorizontalAlign="Center" Width="100px" />
                <ItemTemplate>
                 <span id="spnGuion2" runat="server">-</span>
                    <asp:LinkButton ID="btnConformidad" runat="server" CommandName="Conforme" CommandArgument='<%#Eval("nroComprobante") & "|" & Eval("descripcion") %>' Text="<i class='far fa-thumbs-up fa-2x'></i>"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            
             <%--<asp:ButtonField  CommandName="CancelFac" ShowHeader="True" Text='<i class="fas fa-hand-holding-usd"></i>'>
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="35px" />
            </asp:ButtonField>--%>
          
        </Columns>
    </asp:GridView>


               </div>
		


					 </div>

		   <div class="clear"></div>
   <%--  <div style="margin-top: 90px">
        <!-- fecha y criticidad -->
         <br />
         <br />
        <div class="form-group row" style="width: 790px; padding-left:600px; height: 150px;">
            <div class="col-sm-2" style="left: -299px; top: -102px; width: 119%; height: 404px; margin-top: 27px;">
                <asp:Label runat="server" for="dpDesde">Desde:</asp:Label>
                <uc2:datePicker ID="dpDesde" runat="server" />
            </div>
            <div class="col-sm-2" style="left: -147px; top: -446px; width: 99%; margin-top: 370px; height: 254px;">
                <asp:Label runat="server" for="dpHasta">Hasta:</asp:Label>
                <uc2:datePicker ID="dpHasta" runat="server" />
            </div>
            <br />
            <br />
             <div class="col-sm-2" style="left: -2px; top: -56px" >
                 
                <asp:Button class="btn btn-primary mt-1" ID="btnFiltrar" runat="server" Text="Filtrar" formnovalidate />
        
            </div>
        </div>
        
        </div>
            --%>

               
</asp:Content>

