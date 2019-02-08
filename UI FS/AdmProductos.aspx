<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage2.master" AutoEventWireup="false" CodeFile="AdmProductos.aspx.vb" Inherits="AdmProductos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <h3> Administrar Productos </h3>
       <div runat="server" visible="false" id="regSuccess" class="alert success-success" role="alert">
    </div>
    <div id="divGvProductos" style="width: 707px">
     <asp:GridView  ID="GV_Productos" runat="server" 
        AutoGenerateColumns="False" 
        CssClass="table table-bordered bs-table" 
        DataKeyNames="ID" 
        allowpaging="True" PageSize="5" Width="48px" Height="16px" style="margin-left: 0px" Font-Size="Small" 
         >
        
        <HeaderStyle BackColor="#337ab7" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#ffffcc" />
        <EmptyDataRowStyle forecolor="Red" CssClass="table table-bordered" />
        <emptydatatemplate>
            ¡No hay Productos! 
        </emptydatatemplate>           
 
          <%--Paginador...--%>        
           
       <Columns>
           <asp:CommandField SelectText="--&gt;" ShowSelectButton="True" ItemStyle-Height="50%" ItemStyle-Wrap="false" />
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:Button ID="btnDelete" runat="server" CausesValidation="False" CommandName="Delete" Text="Borrar" OnClientClick="return confirm('Deseas Borrar Producto?'); " />
                    </ItemTemplate>
           </asp:TemplateField>
            <asp:BoundField DataField="Nombre" HeaderText="Nombre" ItemStyle-Width="50%" ItemStyle-Wrap="false"/>
          <asp:BoundField DataField="Descripcion"  HeaderText="Descripcion" Visible="false"  />
           <asp:TemplateField HeaderText="Descripcion">
<ItemTemplate>
<asp:textbox ID="txtDescripcionGV" style="border:none" MaxLength="20" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DESCRIPCION") %>'></asp:textbox>
</ItemTemplate>
</asp:TemplateField>
             <asp:BoundField DataField="Precio" HeaderText="Precio" />
           <asp:BoundField DataField="Categoria" HeaderText="Categoria" />
           <asp:BoundField DataField="Img" HeaderText="Img" />
             <asp:BoundField DataField="Descuento" HeaderText="Descuento" />
           <asp:BoundField DataField="Stock" HeaderText="Stock" />
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
             <asp:TextBox ID="txtNombre" runat="server" class="form-control" placeholder="Nombre de Producto" Width="200px" ></asp:TextBox>
                    </td>
  
             <td style="padding-right: 50px;" >
                <br />
                 <br />
                 <br />
            <label for="txtDescription">Descripción:</label><asp:TextBox ID="txtDescription" runat="server" class="form-control" placeholder="Descripción del Producto" Width="266px" ></asp:TextBox>
                 &nbsp;</td>
                    <td >
                        <br />
                        <br />
                      
                <label for="txtPrecio">Precio:</label>
                        
             <asp:TextBox ID="txtPrecio" runat="server" class="form-control" placeholder="$" Width="156px" ></asp:TextBox>
                     </td>
            <asp:RegularExpressionValidator ID="RegExtxtPrecio"
    ControlToValidate="txtPrecio" runat="server"
    ErrorMessage="Ingresar Numeros Enteros"
    ValidationExpression="\d+" BorderColor="Red">
</asp:RegularExpressionValidator>
        </tr>
              
                <tr>                  
     
                    <td style="padding-right: 50px;">
            <label for="ddCategorias">Categoria:</label><asp:DropDownList ID="ddCategorias" runat="server" class="form-control" ></asp:DropDownList>
                  &nbsp;</td>
                     <td style="margin: 50px; padding-right: 50px;">
            <label for="UrlImagen">Imagen:</label>
            <br />
            <asp:FileUpload ID="UrlImagen" runat="server" Width="274px" /><asp:TextBox ReadOnly="true" ID="txtUrlImagen" runat="server" class="form-control" placeholder="Path" Height="30px" Width="212px" ></asp:TextBox>
            
                        </td>

                </tr>
                          
                <tr>
                   
                    <td>
            <label for="txtDescuento">Descuento:</label>
            <asp:TextBox ID="txtDescuento" runat="server" class="form-control" placeholder="Del 0 al 50 (%)" Width="194px" ></asp:TextBox>
                        </td>
            <asp:RegularExpressionValidator ID="RegexDescuento"
    ControlToValidate="txtDescuento" runat="server"
    ErrorMessage="Ingresar Numeros Enteros Entre 0 y 50"
    ValidationExpression="\d+" BorderColor="Red">
</asp:RegularExpressionValidator>
                    <td>
                        <br />
            <label for="txtStock">Stock:</label>
            <asp:TextBox ID="txtStock" runat="server" class="form-control" placeholder="Existencias" Width="161px" ></asp:TextBox>
              <asp:RegularExpressionValidator ID="RegExStock"
    ControlToValidate="txtStock" runat="server"
    ErrorMessage="Ingresar Numeros Enteros"
    ValidationExpression="\d+" BorderColor="Red">
</asp:RegularExpressionValidator>
                    </td>
                        
                    </tr>
         
                </table>
            <br />
             <asp:Button class="btn btn-primary" ID="btnGuardar" runat="server" Text="Guardar" />
             </div>
        
          

    </div>
     


</asp:Content>

