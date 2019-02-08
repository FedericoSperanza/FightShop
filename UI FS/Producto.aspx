<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Producto.aspx.vb" Inherits="Producto" %>




<%@ Register Src="~/UserControls/userComments.ascx" TagPrefix="uc1" TagName="userComments" %>




<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   
    <style type="text/css">
        .Star
        {
            background-image: url(images/Star.gif);
            height: 17px;
            width: 17px;
        }
        .WaitingStar
        {
            background-image: url(images/WaitingStar.gif);
            height: 17px;
            width: 17px;
        }
        .FilledStar
        {
            background-image: url(images/FilledStar.gif);
            height: 17px;
            width: 17px;
        }
    </style>
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></ajaxToolkit:ToolkitScriptManager>
                


    <div style="display: flex; flex-direction: row; padding: 2vw">
        
        <asp:Image ID="img" runat="server" Width="150px" ImageUrl='<%# Eval("img")%>'/>
        <div style="display: flex; flex-direction: column; margin-left: 2vw">
          
            <div id="dvNombreProducto" class="row" runat="server" style="font-weight: 900; font-size: xx-large;">
                <asp:Label ID="lblNombre" runat="server"  Text='<%# Eval("nombre")%>'></asp:Label>
            </div>
            <div id="dvPrecio" class="row" runat="server"  style="font-weight: 900; font-size: -webkit-xxx-large; color: darkslategray;">
            $<asp:Label runat="server" id="lblPrecio"  Text='<%# Eval("Precio")%>'></asp:Label></div>
            <div id="dvDescripcion" class="row" runat="server" style="margin-top: 2vh; margin-bottom: 2vh;">
                 <asp:Label ID="lblDetails" runat="server"  Text='<%# Eval("descripcion")%>'></asp:Label>
            </div>

            <asp:LinkButton ID="lbVolver" runat="server">Volver</asp:LinkButton>
                   
             <%--    <ajaxtoolkit:rating 
                        ID="rating" 
                        runat="server"
                        StarCssClass="Star"
                        WaitingStarCssClass="WaitingStar" 
                        EmptyStarCssClass="Star"
                        FilledStarCssClass="FilledStar"
                       
                        onchanged="OnRatingChanged"
                     
                    AutoPostBack="True">
                    </ajaxtoolkit:rating> --%>

            <div id="dvComprar" class="row" runat="server" style="display: flex; justify-content: center;">
                
                 
                  <asp:Button CssClass="button" ID="btnAddCart" runat="server" Height="34px" style="font-size:12px;text-align: center; " Text="Comprar" Width="109px"  />
                <%-- OnCommand="ValidarCommand" CommandName="AddCart" CommandArgument='<%# Eval("precio") %>'  --%>
                    </div> 
              
            <asp:DropDownList ID="ddlCantidad" Height="50px" Width="50px" runat="server" ></asp:DropDownList>
                           
            </div>
             
                 &nbsp;&nbsp;
    </div>
     <div style="display: flex; flex-direction: column; padding: 2vw">

    &nbsp;<%--    <div style="font-weight: 800; font-size: x-large;">
            Comentarios
        </div>--%>



        <div id="dvComentario" runat="server" style="width: 100%; padding: 15px; display: flex; background-color: lightgray; border-radius: 7px">
            &nbsp;<asp:TextBox ID="txtComentario" runat="server" placeholder="Ingresa tu comentario" class="form-control" Style="margin-right: 1vh"></asp:TextBox>
            &nbsp;<asp:Button class="btn btn-primary mt-1" ID="btnComentar" runat="server" Text="Comentar" formnovalidate />
        &nbsp;</div>

        <div style="font-weight: 800; font-size: x-large; margin-top: 2vh">
            &nbsp;Últimos comentarios
        </div>
        &nbsp;<div id="dvComments" runat="server" style="width: 100%; display: flex; flex-direction: column; align-items: flex-end">

        </div>
    &nbsp;</div>

    <!-- Modal -->
&nbsp;<div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog" role="document">
    &nbsp;<div class="modal-content">
      <div class="modal-header">
        &nbsp;<h5 class="modal-title" id="exampleModalLabel">Login Necesario</h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          &nbsp;<span aria-hidden="true">&times;</span>
        </button>
      &nbsp;</div>
      <div class="modal-body">
        &nbsp;Es necesario que ingreses al sistema para Comentar
      </div>
      &nbsp;<div class="modal-footer">
        <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
        
      </div>
    &nbsp;</div>
  </div>
&nbsp;</div>

     <script type="text/javascript">
    function openModal() {
        $('#exampleModal').modal('show');
    }
</script>
&nbsp;
     
</asp:Content>

