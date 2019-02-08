<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Noticia.aspx.vb" Inherits="Noticia" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

     <div style="display: flex; flex-direction: row; padding: 2vw">
        <asp:Image ID="img" runat="server" Width="250px" Height="250px" ImageUrl='<%# Eval("img")%>'/>
        
        <div style="display: flex; flex-direction: column; margin-left: 2vw">
            <div id="dvNombreProducto" class="row" runat="server" style="font-weight: 900; font-size: xx-large;">
                <asp:Label ID="lblNombre" runat="server"  Text='<%# Eval("nombre")%>'></asp:Label>
            </div>
           
            <div id="dvDescripcion" class="row" runat="server" style="margin-top: 2vh; margin-bottom: 2vh;">
                <asp:TextBox ID="lblDetails" runat="server" ReadOnly="true" Text='<%# Eval("descripcion")%>' Height="250px" Width="800px" BorderColor="White" TextMode="MultiLine"></asp:TextBox>
               <%--  <asp:Label ID="lblDetails" runat="server"  Text='<%# Eval("descripcion")%>'></asp:Label>
          --%>  </div>

          
        </div>
    </div>

</asp:Content>

