<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage2.master" AutoEventWireup="false" CodeFile="FichasDeOpinion.aspx.vb" Inherits="FichasDeOpinion" %>


<%@ Register Src="UserControls/Calendario.ascx" TagName="datePicker" TagPrefix="uc1" %>

<%@ Register Src="UserControls/modalDialog.ascx" TagName="modalDialog" TagPrefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <asp:Label runat="server" class="page-title">Fichas de opinion</asp:Label>

    <asp:GridView ID="grd" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-hover table-sm" DataKeyNames="id" Width="600px" AllowPaging="True" PageSize="10">
        <Columns>
            <asp:ButtonField CommandName="Select" ShowHeader="True" Text='<i class="far fa-eye"></i>'>
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="35px" />
            </asp:ButtonField>
            <asp:ButtonField CommandName="Delete" ShowHeader="True" Text='<i class="fas fa-eraser"></i>'>
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="35px" />
            </asp:ButtonField>
            <asp:BoundField DataField="nombre" HeaderText="Nombre">
                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="250px" />
            </asp:BoundField>
            <asp:BoundField DataField="vencimiento" HeaderText="Vencimiento" DataFormatString="{0:dd/MM/yyyy}">
                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="100px" />
            </asp:BoundField>
            
        </Columns>
    </asp:GridView>

    <asp:Button class="btn btn-primary mt-1" ID="btnNuevo" runat="server" Text="Nuevo" formnovalidate />

    <div class="container">
        <div id="divCampos" runat="server" class="form-group row mt-3">
            <div class="col-3">
                <asp:Label runat="server" for="txtDescription">Pregunta:</asp:Label>
                <asp:TextBox ID="txtDescription" runat="server" class="form-control" placeholder="Pregunta de la encuesta" required MaxLength="50"></asp:TextBox>
            </div>
           
            <div class="col-3">
                <asp:Label runat="server" for="dpVencimiento">Vencimiento:</asp:Label>
                <uc1:datePicker ID="dpVencimiento" runat="server" />
            </div>
        </div>
        <div id="divContOpciones" runat="server" class="form-group row mt-3">
            <div class="col-6">
                <asp:Label runat="server" for="divOpciones">Opciones:</asp:Label>
                <div runat="server" id="divOpciones" class="form-control" style="display: flex; flex-direction: column; height: auto">
                    <asp:Repeater ID="rptOpciones" runat="server">
                        <ItemTemplate>
                            <div style="width: 100%; display: flex;">
                                <div style="flex-grow: 1">
                                    <%# Container.DataItem.ToString() %>
                                </div>
                                <div style="flex-shrink: 0">
                                    <asp:LinkButton
                                        runat="server"
                                        ID="btnQuitar"
                                        CommandName="Remove"
                                        UseSubmitBehavior="false"
                                        CommandArgument='<%# Container.ItemIndex %>'>
                                        <i class="fas fa-eraser"></i>
                                    </asp:LinkButton>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                    <asp:Button class="btn btn-primary btn-sm mt-2" ID="btnAgregar" runat="server" Text="Agregar" formnovalidate />
                </div>
            </div>
        </div>
        <div id="divBtnGuardar" runat="server" class="form-group row mt-5">
            <div class="col-3">
                <asp:Button class="btn btn-primary" ID="btnGuardar" runat="server" Text="Guardar" />
            </div>
        </div>

        <div id="divChart" runat="server" class="form-group row mt-5">
            <div class="col-6">
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

    </div>
    <uc2:modalDialog ID="mdOpcion" runat="server" />
</asp:Content>

