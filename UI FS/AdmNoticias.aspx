<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage2.master" AutoEventWireup="false" CodeFile="AdmNoticias.aspx.vb" Inherits="AdmNoticias" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
     <script>
       function readURL(input) {
           if (input.files && input.files[0]) {
               var reader = new FileReader();
               reader.onload = function(e) {
                   $('#<%= imgPreview.ClientId %>').attr('src', e.target.result);
               }
               reader.readAsDataURL(input.files[0]);
           }
       }
       $("#fuImagen").change(function() {
           readURL(this);
       });
   </script>

   

     <h3> Administrar Noticias </h3>

    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>


       <div runat="server" visible="false" id="regSuccess" class="alert success-success" role="alert">
    </div>
    <div id="divGvNoticias" style="width: 707px">
     <asp:GridView  ID="GV_Noticias" runat="server" 
        AutoGenerateColumns="False" 
        CssClass="table table-bordered bs-table" 
        DataKeyNames="ID" 
        allowpaging="True" PageSize="5" Width="48px" Height="16px" style="margin-left: 0px" Font-Size="Small" 
         >
        
        <HeaderStyle BackColor="#337ab7" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#ffffcc" />
        <EmptyDataRowStyle forecolor="Red" CssClass="table table-bordered" />
        <emptydatatemplate>
            ¡No hay Noticias! 
        </emptydatatemplate>           
 
          <%--Paginador...--%>        
           
       <Columns>
           <asp:CommandField SelectText="--&gt;" ShowSelectButton="True" ItemStyle-Height="50%" ItemStyle-Wrap="false" />
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:Button ID="btnDelete" runat="server" CausesValidation="False" CommandName="Delete" Text="Borrar" OnClientClick="return confirm('Deseas Borrar Noticia?'); " />
                    </ItemTemplate>
           </asp:TemplateField>
            <asp:BoundField DataField="Nombre" HeaderText="Nombre" ItemStyle-Width="50%" ItemStyle-Wrap="false"/>
          <asp:BoundField DataField="Descripcion"  HeaderText="Descripcion" Visible="false"  />
           <asp:TemplateField HeaderText="Descripcion">
<ItemTemplate>
<asp:textbox ID="txtDescripcionGV" style="border:none" MaxLength="20" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DESCRIPCION") %>'></asp:textbox>
</ItemTemplate>
</asp:TemplateField>
            <asp:BoundField DataField="fechacaduc" HeaderText="Caducidad" DataFormatString="{0:d}"  />
           <asp:BoundField DataField="Img" HeaderText="Img" />
            
       </Columns>
     

    </asp:GridView>
        
     
        </div>
    
               <br />
           <%--  <asp:Button class="btn btn-primary" ID="btnNuevo" runat="server" Text="Nuevo" />--%>
  
  

       <br />
    <br />

    <div class="form-group row mt-3" style="height: 67px">
         

        <div class="col-md-4" style="left: 6px; top: -113px; height: 808px;">
            <br />
            <br />
                 <asp:Button class="btn btn-primary" ID="btnNuevo" runat="server" Text="Nuevo" />
     

            <table >
              

                <tr><td style="padding-right: 50px;">
                     <br />
                    <br>

            <label for="txtNombre">Nombre:</label>
             <asp:TextBox ID="txtNombre" runat="server" class="form-control" placeholder="Nombre de Noticia" Width="200px" ></asp:TextBox>
                    </td>
  
             <td style="padding-right: 50px;" >
                <br />
                 <br />
                 <br />
            <label for="txtDescription">Descripción:</label><asp:TextBox ID="txtDescription" runat="server" class="form-control" placeholder="Descripción del Noticia" Width="266px"  TextMode="MultiLine"></asp:TextBox>
                 &nbsp;</td>
                    <td >
                        <br />
                        <br />
                </td>
        
        </tr>
              
                <tr>                  
     
                   
                     <td style="margin: 50px; padding-right: 50px;">
            <label for="UrlImagen">Imagen:</label>
            <br />
                           <asp:Image ID="imgPreview" runat="server" width="200" accept="image/*"/><br />
            <asp:FileUpload ID="UrlImagen" runat="server" Width="274px" onchange="readURL(this)" /><asp:TextBox ReadOnly="true" ID="txtUrlImagen" runat="server" class="form-control" placeholder="Path" Height="30px" Width="212px" ></asp:TextBox>
            


                        </td>

                  <td style="margin: 50px; padding-right: 50px;">
            <label for="txtFecha">Caducidad:</label>
            <br />
           <asp:TextBox ID="txtfecha" runat="server" ></asp:TextBox>
            <asp:ImageButton ID="BtnImagen" runat="server"  ImageUrl="images/Calendario2.png" />
            <asp:CalendarExtender ID="CalendarExtender2" runat="server"
             TargetControlID="txtfecha"
              PopupButtonID="BtnImagen"
                Format="dd/MM/yyyy">
            </asp:CalendarExtender>
                        </td>

                </tr>
                          
                </table>
            <br />
             <asp:Button class="btn btn-primary" ID="btnGuardar" runat="server" Text="Guardar" />
             </div>
        
          

    </div>
     


</asp:Content>

