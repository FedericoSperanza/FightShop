<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage2.master"  AutoEventWireup="false" CodeFile="AdmRoles.aspx.vb"  Inherits="AdmRoles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <h3>Administracion de Roles&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
 
               

     

    </h3>
       
 <%--   <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>--%>
    
     <asp:GridView  ID="GV_Roles" runat="server" 
        AutoGenerateColumns="False" 
        CssClass="table table-bordered bs-table" 
        DataKeyNames="ID" 
        allowpaging="True" PageSize="5" Width="523px" Height="144px"  Font-Size="Small"
         >
        
        <HeaderStyle BackColor="#337ab7" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#ffffcc" />
        <EmptyDataRowStyle forecolor="Red" CssClass="table table-bordered" />
        <emptydatatemplate>
            ¡No hay Roles! 
        </emptydatatemplate>           
 
          <%--Paginador...--%>        
           
       <Columns>
           <asp:CommandField SelectText="--&gt;" ShowSelectButton="True" />
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:Button ID="Button1" runat="server" CausesValidation="False" CommandName="Delete" Text="Delete" OnClientClick="return confirm('Deseas Borrar el Rol?'); " />
                    </ItemTemplate>
           </asp:TemplateField>
            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
             <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" />

       </Columns>


    </asp:GridView>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Button class="btn btn-primary" ID="btnNuevo" runat="server" Text="Nuevo" />
 
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
 
            <asp:Button class="btn btn-primary" ID="btnGuardar" runat="server" Text="Guardar" />
        <%--    </ContentTemplate>
    </asp:UpdatePanel--%>
  
 <div class="form-group row mt-3" style="height: 39px">
        <div class="col-md-4" style="left: 560px; top: -258px">
            
            <label for="txtNombre">Nombre:</label>
             <asp:TextBox ID="txtNombre" runat="server" class="form-control" placeholder="Nombre del rol" ></asp:TextBox>
        <br />
            <label for="txtDescription">Descripción:</label>
            <asp:TextBox ID="txtDescription" runat="server" class="form-control" placeholder="Descripción del rol" ></asp:TextBox>
        </div>
    </div>
    
   <%-- <div class="form-group row">
        <div class="col">
            <label for="txtDescription">Permisos:</label>
            <asp:CheckBoxList ID="lstPermissions" runat="server" DataTextField="nombre" DataValueField="id" BorderStyle="Solid" Height="100%" CssClass="custom-checkbox" RepeatColumns="4" repeatdirection="Horizontal">
             


            </asp:CheckBoxList>
        </div>
    </div>--%>

    <div class="form-group row mt-5">
        <div class="col-md-4" style="left: 0px; top: 19px; height: 10px">
        </div>
    </div>
    <div runat="server" visible="false" id="regSuccess" class="alert alert-warning" role="alert"/>
        

   

</asp:Content>

