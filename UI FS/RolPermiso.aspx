<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage2.master" AutoEventWireup="false" CodeFile="RolPermiso.aspx.vb" Inherits="RolPermiso" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <h3>Asignacion de Permisos</h3>

    <br />
    <br />

   <b>Rol:</b> <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
       <asp:UpdatePanel ID="UpdatePanel1" runat="server">
           <ContentTemplate>
     <asp:DropDownList ID="ddRoles" DataTextField="nombre" runat="server" AutoPostBack="True">
     </asp:DropDownList>
    <br />
               <br />

               <b>Permisos de Rol&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Permisos de Sistema<br />
                   </b>
 <table style="width: 59px; height: 63px">
        <tr><td>
    <div id="SectorAsignacion">

   
     <asp:ListBox ID="lstPermisosRol"  runat="server" Width="179px" Height="250px" AutoPostBack="true"></asp:ListBox>
    </td>
    
       

    <td>
     <asp:Button ID="btnDesAsgin" runat="server" Text=">>" Width="65px" />

        
    <asp:Button ID="btnAsign" runat="server" Text="<<" Width="64px" /></td>

    <td>
  <asp:ListBox ID="lstPermisosSist"  runat="server" Width="179px" Height="250px" AutoPostBack="True"></asp:ListBox></td></tr>
   </table>
           <b> Descripción Permiso</b>
        <asp:Label ID="lblDetallePermiso" runat="server"   Text=""></asp:Label>
        
            <br />


        </div>



     <div runat="server" visible="false" id="regSuccess" class="alert alert-warning" role="alert">
  
</div>
            </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

