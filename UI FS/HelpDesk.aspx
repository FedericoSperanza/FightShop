<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="HelpDesk.aspx.vb" Inherits="HelpDesk" %>


<%@ Register Src="~/UserControls/userComments.ascx" TagPrefix="uc1" TagName="comment" %>





<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    
           <div class="header_slide">
			<div class="header_bottom_left">				
				<div class="categories">
				  <ul>
				  	<h3>FightShop</h3>
				           <li><asp:LinkButton ID="lbMensajeria" runat="server">Mensajeria</asp:LinkButton></li>
				      <li><asp:LinkButton ID="lbCC" runat="server">Cuenta Corriente</asp:LinkButton></li>
				        </ul>
				</div>					
	  	     </div>
             


               <div id="contenido" style="height: 250px; margin-left: 334px; width: 754px;">
               <div style="display: flex; flex-direction: column; height: 100%; padding: 2vw">

        <asp:Label runat="server" class="page-title">Mesa de ayuda</asp:Label>
        <div class="form-control" style="display: flex; flex-direction: column; padding: 1vw; flex-grow: 1; overflow-y: scroll;">
            <div id="divMensajes" runat="server" style="flex-direction: column;">
            </div>
        </div>
        <div id="divInput" runat="server" style="display: flex; flex-direction: row; margin-top: 10px;">
            <asp:TextBox ID="txtInput" runat="server" class="form-control" MaxLength="50" Style="margin-right: 10px" placeholder="Escriba aquí su mensaje"></asp:TextBox>
            <asp:Button class="btn btn-primary" ID="btnEnviar" runat="server" Text="Enviar" />
        </div>
    </div>

                   </div>

</asp:Content>

