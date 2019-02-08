<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage2.master" AutoEventWireup="false" CodeFile="AdmUsuario.aspx.vb" Inherits="AdmUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

     <asp:Label runat="server" class="page-title"><n><h2>Administrar Usuarios</h2></n></asp:Label>

    <div>
      <%-- MENSAJES--%>
    <div runat="server" visible="false" id="regSuccess" class="alert alert-warning" role="alert"/>
               
         
 
   
     

 


 

     <asp:GridView  ID="GV_Usuarios" runat="server" 
        AutoGenerateColumns="False" 
        CssClass="table table-bordered bs-table" 
        DataKeyNames="ID" 
        allowpaging="true" PageSize="8" Width="737px" Height="124px" style="margin-left: 0px" Font-Size="Small"
        onrowcommand="GV_Usuarios_RowCommand"
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
                <asp:TemplateField ShowHeader="True" HeaderText="Borrar">
                    <ItemTemplate>
                        <asp:Button ID="btnDelete" runat="server" CausesValidation="False" CommandName="Delete" Text="Borrar" OnClientClick="return confirm('Deseas Borrar Usuario?'); " />
                    </ItemTemplate>
           </asp:TemplateField>
           <asp:TemplateField ShowHeader="true" HeaderText="Des/Bloqueo">
                    <ItemTemplate>
                        <asp:Button ID="btnBloquear" runat="server" CommandArgument='<%# Container.DataItemIndex %>'  CausesValidation="False" CommandName="BloquearDesbloquear" Text="X/O" Font-Size="Small" />
                    </ItemTemplate>
           </asp:TemplateField>
            <asp:BoundField DataField="User" HeaderText="User" ApplyFormatInEditMode="True" />

             <asp:BoundField DataField="Nombre" HeaderText="Nombre" />

           <asp:BoundField DataField="Apellido" HeaderText="Apellido" />

          <asp:BoundField DataField="Flag" HeaderText="FlagBaja" />
           <%--<asp:TemplateField HeaderText="FlagBaja" SortExpression="Flag">
    <ItemTemplate><%#IIf(Boolean.Parse(Eval("Flag").ToString()), "Si", "No")%></ItemTemplate>
</asp:TemplateField>--%>
             <asp:BoundField DataField="Telefono" HeaderText="Telefono" />


       </Columns>


    </asp:GridView>
        <div runat="server" visible="false" id="RegSucess" class="alert success-success" role="alert">
    </div>
          
   <div class="form-group row mt-3" style="height: 95px; font-size:small">
        <div class="col-md-4" style="left: -4px; top: 0px; height: 397px;">
          
              <asp:Button class="btn btn-primary" ID="btnNuevo" runat="server" Text="Nuevo"  />

            <br />
            <table>


       
           
           <tr>
               <td style="">
            <label for="lbEmail">Email:</label>
             <asp:TextBox ID="txtEMAIL" runat="server" class="form-control" placeholder="Email Usuario" Width="233px" ></asp:TextBox>
                 </td>
    
                
                     <td style="margin: 10px; padding-right: 50px;padding-left: 50px;">
            <label for="lbNombre">Nombre:</label>
            <asp:TextBox ID="txtNombre" runat="server" class="form-control" placeholder="Nombre Usuario" Width="171px" ></asp:TextBox>
                    </td>
   
        
               <td>
            <label for="lbApellido">Apellido:</label>
            <asp:TextBox ID="txtApellido" runat="server" class="form-control" placeholder="Apellido Usuario" Width="165px" ></asp:TextBox>
                   </td>
               </tr>
       
                <tr>
                    <td>
            <label for="lbTelefono">Telefono:</label>
            <asp:TextBox ID="txtTelefono" runat="server" class="form-control" placeholder="Telefono Usuario" ></asp:TextBox>
      
         
                        </td>
                    <td style="margin: 10px; padding-left: 50px;">
                        &nbsp;</td>
                    </tr>
      </table>
            <br />
           <asp:Button class="btn btn-primary" ID="btnGuardar" runat="server" Text="Guardar"  />
    </div>
       </div>
             

</asp:Content>

