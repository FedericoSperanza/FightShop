<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Payment.aspx.vb" Inherits="Payment" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <script type="text/javascript">
        $(function ($) {
            $("#<%= txtNroTarjeta.ClientId %>").mask("9999-9999-9999-9999");
            $('#<%= txtExpiracion.ClientId %>').mask('99/9999', { placeholder: "MM/yyyy" })
            $("#<%= txtCodSeg.ClientId %>").mask("999");
            $("#<%= txtDNI.ClientId %>").mask("99999999");
        });


        $(document).ready(function () {
            var validaTarj = function (e) {
                var val = $(this).val().toString();

                var esTarjeta = false;
                /* VALIDACION DE TIPO */

                console.log(2);

                if (val.substring(0, 1) == "4") {
                    $("#imgCard").attr("src", "images/visa.png");
                    esTarjeta = true;
                    console.log(1);
                } else {
                    var num = val.substring(0, 2)
                    if (num == "34" || num == "37") {
                        $("#imgCard").attr("src", "images/amex.jpg");
                        esTarjeta = true;
                        console.log(2);
                    } else if (num == "51" || num == "55" || num == "53") {
                        $("#imgCard").attr("src", "images/master.png");
                        esTarjeta = true;
                    }
                }
                if (esTarjeta) {
                    $("#imgCard").css("display", "block");
                } else {
                    $("#imgCard").css("display", "none");
                }
            }
            $("#txtNroTarjeta").change(validaTarj);
            $("#txtNroTarjeta").keyup(validaTarj);
        });
    </script>

     <div runat="server" visible="false" id="regSuccess" class="alert alert-warning" role="alert"/>
               
         

    <asp:Label runat="server" class="page-title" ID="lblPagar" Font-Bold="True" Font-Size="Larger">Pagar Operacion</asp:Label>
    <div class="container" id="contenedorGlobal" runat="server" style="width: 80%">
        <div class="row">
            <div class="col-6">

                   <div class="row" id="rowNotasDeCredito" runat="server">
                    <div class="col-12">
                        <asp:Label runat="server" for="grd" Font-Bold="True">Notas de Crédito</asp:Label>
                        <asp:GridView ID="grd" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-hover table-sm" DataKeyNames="id" AllowPaging="False" Width="450px" OnRowCommand="gr_rowCommand">
                            <Columns>
                                
                                <asp:TemplateField>
                                    <ItemStyle HorizontalAlign="Center" Width="40px" />
                                    <ItemTemplate>
                                       
                                      <asp:LinkButton ID="hlbtnAdd"   UseSubmitBehavior="false" class="btn btn-info btn-sm" runat="server" CommandName="Add" CommandArgument='<%# Container.DataItemIndex %>'  ><i class="fas fa-plus"></i></asp:LinkButton>
                                   <asp:LinkButton ID="hlbtnDesAdd"   UseSubmitBehavior="false" class="btn btn-info btn-sm" runat="server" Visible="false" CommandName="DesAdd" CommandArgument='<%# Container.DataItemIndex %>'  ><i class="fas fa-minus"></i></asp:LinkButton>
                              
                                         <%-- <asp:CheckBox id="chkSelect" runat="server"  AutoPostBack="true"
         CommandName="row_Checked" ></asp:CheckBox>--%>
                                        
                                         </ItemTemplate>
                                </asp:TemplateField>
                                    <asp:BoundField DataField="id" HeaderText="id" visible="false">
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="80px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="fecha" HeaderText="Fecha" DataFormatString="{0:dd/M/yyyy}">
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="80px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="concepto" HeaderText="Concepto">
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="200px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="saldo" HeaderText="Saldo" DataFormatString="${0:0.00}" >
                                    <ItemStyle HorizontalAlign="right" VerticalAlign="Middle" Width="80px" />
                                </asp:BoundField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>






                <asp:Panel runat="server" ID="PanelpagoTC">
                <div class="row">
                    <div class="col-12">
                        <asp:Label runat="server" for="ddlFormaPago" Font-Bold="True">Tarjeta</asp:Label>
                        <asp:DropDownList ID="ddlFormaPago" runat="server" class="form-control">
                            <asp:ListItem>VISA</asp:ListItem>
                            <asp:ListItem>MASTER CARD</asp:ListItem>
                            <asp:ListItem>AMERICAN EXPRESS</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="row">
                    <div class="col-12">
                        <asp:Label runat="server" for="txtNroTarjeta">Número de tarjeta</asp:Label>
                        <asp:TextBox ID="txtNroTarjeta" ClientIDMode="static" runat="server" class="form-control" required></asp:TextBox>
               <%--         <asp:RegularExpressionValidator ForeColor="Red" Font-Bold="true" ID="RegExNroTarjeta" runat="server" ErrorMessage="Numero de Tarjeta Invalido" ControlToValidate="txtNroTarjeta"></asp:RegularExpressionValidator>  </div>
            --%>  
                             <div class="col-3">
                        <asp:Label runat="server" for="imgCard">&nbsp</asp:Label>
                        <img id="imgCard" style="height: 5vh; display: block; margin-top: 0.5vh; border: thin solid; display:none"/>
                    </div>

                    </div>  </div>
                <div class="row">
                    <div class="col-12">
                        <asp:Label runat="server" for="txtNombre">Nombre y apellido</asp:Label>
                        <asp:TextBox ID="txtNombre"  ClientIDMode="static" runat="server" class="form-control" required MaxLength="50"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-6">
                        <asp:Label runat="server" for="txtExpiracion">F. Expiración</asp:Label>
                        <asp:TextBox ID="txtExpiracion" ClientIDMode="static" runat="server" class="form-control" required></asp:TextBox>
                    </div>
                    <div class="col-6">
                        <asp:Label runat="server" for="txtCodSeg">Cód. Seguridad</asp:Label>
                        <asp:TextBox ID="txtCodSeg" ClientIDMode="static" runat="server" class="form-control" required></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-12">
                        <asp:Label runat="server" for="txtDNI">DNI del titular</asp:Label>
                        <asp:TextBox ID="txtDNI" ClientIDMode="static" runat="server" class="form-control" required></asp:TextBox>
                    </div>
                </div>
                    </asp:Panel>
                <div class="row">
                    <div class="col-12">
                              <asp:Button class="btn btn-primary mt-4" ID="btnConfirmarPago" runat="server" Text="Confirmar pago" formnovalidate="true" />
                    <asp:Button visible="false" class="btn btn-primary mt-4" ID="btnIrAlCatalogo" runat="server" Text="Ir Al Catalogo" formnovalidate="true" />
                   
                        
                         </div>
                </div>
            </div>
         
          
               <div class="panel panel-default" style="height:200px; width:200px">
  <div class="panel-body">  <div class="col-6" style="left: 0px; top: 20px; width: 180%" >
                <%--<asp:Image ID="img" runat="server" Width="50%" />--%>
                <div class="row" id="dvTitle" runat="server" style="font-weight: 900; font-size: x-large;">
                </div>
                <div class="row" id="dvPrecio" runat="server"  style="font-weight: 900; font-size: x-large; color:lightsalmon">
                </div>
                <%--<div class="row" id="dvBody" runat="server" style="margin-top: 2vh; margin-bottom: 2vh;">--%>
                </div></div>
</div>


            </div>
        </div>
   <!--ENCUESTA-->
            <div runat="server" visible="false" id="divEncuesta" class="card" style="border-width: 2px; border-color: black; left: 0px; top: 0px; width: 433px;">
                <div id="divEncuestaPreguntas" runat="server" class="card-body" visible="true">
                    <h5 class="card-title">Por favor, responde esta breve ficha de opinion</h5>
                    <p class="card-text" runat="server" id="encuestaText"></p>
                    <asp:Repeater ID="rptEncuestaOpciones" runat="server">
                        <ItemTemplate>
                            <asp:LinkButton
                                class="btn btn-primary"
                                runat="server"
                                UseSubmitBehavior="false"
                                CommandArgument='<%# Eval("id") %>'>
                                <%# Eval("nombre") %>
                            </asp:LinkButton>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
                <div id="divEncuestaChart" runat="server" class="card-body" visible="false">
                    <h5 class="card-title">Resultados</h5>
                    <asp:Chart ID="chartEncuesta" runat="server" Style="max-width: 100%">
                        <Series>
                            <asp:Series Name="Series1"></asp:Series>
                        </Series>
                        <ChartAreas>
                            <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                        </ChartAreas>
                    </asp:Chart>
                </div>
            </div>
      <asp:button runat="server" type="button" ID="botonTracking" Visible="false" class="btn btn-secondary" OnClick="btnTracking" UseSubmitBehavior="false"  Text="Tracking"></asp:button>
    





    </div>
    





</asp:Content>

