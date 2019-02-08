<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage2.master" AutoEventWireup="false" CodeFile="AdmRolUsuario.aspx.vb" Inherits="AdmRolUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     
  
     <asp:Label runat="server" class="page-title"><n><h3>Administracion de Roles a Usuarios</h3></n></asp:Label>

   
               
         
 
     <asp:GridView  ID="GV_RolUsuario" runat="server" 
        AutoGenerateColumns="False" 
        CssClass="table table-bordered bs-table" 
        DataKeyNames="ID" 
        allowpaging="true" PageSize="8" Width="737px" Height="124px" style="margin-left: 0px" Font-Size="Small"
        
         >
        
        <HeaderStyle BackColor="#337ab7" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#ffffcc" />
        <EmptyDataRowStyle forecolor="Red" CssClass="table table-bordered" />
        <emptydatatemplate>
            ¡No hay Usuarios!
        </emptydatatemplate>           
 
          <%--Paginador...--%>        
           
       <Columns>
         <%--  <asp:CommandField SelectText="--&gt;" ShowSelectButton="True" />--%>
                  <asp:CommandField SelectText="--&gt;" ShowSelectButton="True" ItemStyle-Height="50%" ItemStyle-Wrap="false" />
                
          
            <asp:BoundField DataField="User" HeaderText="User" ApplyFormatInEditMode="True" />
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />

           <asp:BoundField DataField="Apellido" HeaderText="Apellido" />

          
           <%--<asp:TemplateField HeaderText="FlagBaja" SortExpression="Flag">
    <ItemTemplate><%#IIf(Boolean.Parse(Eval("Flag").ToString()), "Si", "No")%></ItemTemplate>
</asp:TemplateField>--%>
             


       </Columns>


    </asp:GridView>
   
   
   <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
       <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            
           <ContentTemplate>
                <div runat="server" visible="false" id="regSuccess" class="alert alert-warning" role="alert">
    </div>
                <b>Usuario:</b> 
     <asp:label ID="lblUsuario" DataTextField="nombre" runat="server" AutoPostBack="True">
     </asp:label>
    <br />
               <br />

               <b>Roles de Usuario&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Roles de Sistema<br />
                   </b>
 <table style="width: 59px; height: 63px">
        <tr><td>
    <div id="SectorAsignacion">

   
     <asp:ListBox ID="lstRolesDelUsuario"  runat="server" Width="179px" Height="250px" AutoPostBack="true"></asp:ListBox>
    </td>
    
       

    <td>
     <asp:Button ID="btnDesAsgin" runat="server" Text=">>" Width="65px" />

        
    <asp:Button ID="btnAsign" runat="server" Text="<<" Width="64px" /></td>

    <td>
  <asp:ListBox ID="lstRolesSist"  runat="server" Width="179px" Height="250px" AutoPostBack="True"></asp:ListBox></td></tr>
   </table>
           <b> Descripción Rol</b>
        <asp:Label ID="lblDetalleRol" runat="server" BackColor="#3366CC" BorderColor="#0033CC" BorderStyle="Dotted" Text=""></asp:Label>
        
            <br />


        </div>



   
    
            </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

