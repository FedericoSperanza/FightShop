<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage2.master" AutoEventWireup="false" CodeFile="AdmNcFac.aspx.vb" Inherits="AdmFacturacion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">



    <asp:GridView ID="grd" runat="server" PageSize="5" AutoGenerateColumns="False" CssClass="table table-striped table-hover table-sm" AllowPaging="True" Height="92px" Font-Size="X-Small">
         <emptydatatemplate>
            'No hay Dayos!'
        </emptydatatemplate>   
        <Columns>
            <asp:ButtonField CommandName="ViewPdf" ShowHeader="True" Text='<i class="far fa-file-pdf"></i>'>
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="35px" />
            </asp:ButtonField>

            <asp:BoundField DataField="fecha" HeaderText="Fecha" ApplyFormatInEditMode="True" DataFormatString="{0:dd/MM/yyyy}">
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="120px" />
            </asp:BoundField>
            <asp:BoundField DataField="descripcion" HeaderText="Detalle">
                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="200px" />
            </asp:BoundField>
           
            <asp:BoundField DataField="nroComprobante" HeaderText="Nº Fac.">
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="75px" />
            </asp:BoundField>
           <asp:BoundField DataField="monto" HeaderText="Total" DataFormatString="${0}">
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="75px"  />
            </asp:BoundField>
          

            <asp:BoundField DataField="estado" HeaderText="Estado">
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
            </asp:BoundField>
            <asp:BoundField DataField="Tracking" HeaderText="Tracking">
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
            </asp:BoundField>

            <asp:BoundField DataField="SolicitudBaja" Visible="false" HeaderText="hdnSolicitudBaja">
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
            </asp:BoundField>

            <asp:BoundField DataField="Conformidad" Visible="false" HeaderText="hdnConformidad">
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
            </asp:BoundField>

             <asp:BoundField DataField="UsuarioId" HeaderText="hdnid" ApplyFormatInEditMode="True" visible="false">
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="120px" />
            </asp:BoundField>


            <%-- BOTON DE ACEPTACION DE CANCELACION DE FACTURA --%>
             <asp:TemplateField>
                <ItemStyle HorizontalAlign="Center" Width="100px" />
                <ItemTemplate>
                 <span id="spnGuion" runat="server">-</span>
                    <asp:LinkButton ID="btnCancelFacOk" runat="server" CommandArgument='<%#Eval("nroComprobante") & "|" & Eval("UsuarioId") & "|" & Eval("Monto") & "|" & Eval("Tracking") & "|" & Eval("Estado")   %>' CommandName="Ok" Text="<i class='fas fa-check-double fa-2x'></i>"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>

            <%-- BOTON DE NO ACEPTACION DE CANCELACION DE FACTURA--%>
             <asp:TemplateField>
                <ItemStyle HorizontalAlign="Center" Width="100px" />
                <ItemTemplate>
                 <span id="spnGuion1" runat="server">-</span>
                    <asp:LinkButton ID="btnCancelFacNoOk" runat="server" CommandName="NoOk" CommandArgument='<%#Eval("nroComprobante") & "|" & Eval("UsuarioId") & "|" & Eval("Monto") & "|" & Eval("Tracking") & "|" & Eval("Estado") & "|" & Eval("descripcion")  %>' Text="<i class='fab fa-creative-commons-nc fa-2x'></i>"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>


              <%-- BOTON DE CAMBIO A RECIBIDO DE PRODUCTOS--%>
             <asp:TemplateField>
                <ItemStyle HorizontalAlign="Center" Width="100px" />
                <ItemTemplate>
                 <span id="spnGuion2" runat="server">-</span>
                    <asp:LinkButton ID="btnLlegaronProd" runat="server" CommandName="Llegaron" CommandArgument='<%#Eval("nroComprobante") & "|" & Eval("Descripcion") %>' Text="<i class='fas fa-parachute-box fa-2x'></i>"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            
          
          
        </Columns>
    </asp:GridView>

</asp:Content>

