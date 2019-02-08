<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage2.master" AutoEventWireup="false" CodeFile="Bitacora.aspx.vb" Inherits="Bitacora" %>

<%@ Register Src="~/UserControls/Calendario.ascx" TagPrefix="uc1" TagName="Calendario" %>





<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

   
    <asp:Label runat="server" class="page-title"><n><h2>Bitácora</h2></n></asp:Label>

    <div>
      <%-- MENSAJES--%>
    <div runat="server" visible="false" id="regSuccess" class="alert alert-warning" role="alert"/>

        
          <!-- fecha y criticidad -->
        <div class="form-group row">
            <div class="col-sm-2">
                <asp:Label runat="server" for="dpDesde">Desde:</asp:Label>
                <uc1:Calendario runat="server" id="dpDesde" />
               
            </div>
            <div class="col-sm-2">
                <asp:Label runat="server" for="dpHasta">Hasta:</asp:Label>
                <uc1:Calendario runat="server" id="dpHasta" />
            </div>

            <!-- usuario y detalle -->
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp
            <div class="col-sm-2">
                <asp:Label runat="server" for="txtUsuario">Usuario:</asp:Label>
                <asp:TextBox ID="txtUsuario" runat="server" class="form-control"></asp:TextBox>
            </div>
            <div class="col-sm-2">
                <asp:Label runat="server" for="dllCriticidad">Criticidad:</asp:Label>
                <asp:DropDownList ID="ddlCriticidad" runat="server" class="form-control">
                   
                    <asp:ListItem>Informativo</asp:ListItem>
                    <asp:ListItem>Error</asp:ListItem>
                    <asp:ListItem>Grave</asp:ListItem>
                   
                </asp:DropDownList>
            </div>
        </div>

        <!-- boton filtrar -->
        <div class="form-group row">
            <div class="col-sm-3">
                <asp:Button class="btn btn-primary mt-1" ID="btnFiltrar" runat="server" Text="Filtrar" formnovalidate />

            </div>

            <div class="col-sm-3">
                <asp:Button class="btn btn-primary mt-1" ID="btnResetFilter" runat="server" Text="Reiniciar" formnovalidate />

            </div>
        </div>
    </div>
   
     

    <!-- test>


    <!-- grilla -->

     <asp:GridView  ID="GV_Bitacora" runat="server" 
        AutoGenerateColumns="False" 
        CssClass="table table-bordered bs-table" 
        DataKeyNames="ID" 
        allowpaging="true" PageSize="8" Width="737px" Height="124px" 
         >
        
        <HeaderStyle BackColor="#337ab7" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#ffffcc" />
        <EmptyDataRowStyle forecolor="Red" CssClass="table table-bordered" />
        <emptydatatemplate>
            ¡No hay Eventos!
        </emptydatatemplate>           
 
          <%--Paginador...--%>        
           
       <Columns>
         <%--  <asp:CommandField SelectText="--&gt;" ShowSelectButton="True" />--%>
                
            <asp:BoundField DataField="Fecha" HeaderText="Fecha" ApplyFormatInEditMode="True" />

             <asp:BoundField DataField="Evento" HeaderText="Evento" />

           <asp:BoundField DataField="Usuario" HeaderText="Usuario" />

           <asp:BoundField DataField="Criticidad" HeaderText="Criticidad" />


       </Columns>


    </asp:GridView>

   
        
</asp:Content>

