<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage2.master" AutoEventWireup="false" CodeFile="HelpDeskAdmin.aspx.vb" Inherits="HelpDeskAdmin" %>


<%@ Register Src="~/UserControls/userComments.ascx" TagPrefix="uc1" TagName="comment" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

      <div style="display: flex; flex-direction: column; height: 100%; padding: 2vw">

        <asp:Label runat="server" class="page-title">Admin - Mesa de Ayuda</asp:Label>

        <asp:GridView ID="grd" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-hover table-sm" DataKeyNames="idComentario" AllowPaging="True" Width="450">
            <Columns>
                <asp:ButtonField CommandName="Select" ShowHeader="True" Text='<i class="far fa-eye"></i>'>
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="35px" />
                </asp:ButtonField>
                <asp:ButtonField CommandName="Delete" ShowHeader="True" Text='<i class="fas fa-check-double"></i>'>
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="35px" />
                </asp:ButtonField>
                <asp:BoundField DataField="fecha" HeaderText="Fecha" DataFormatString="{0:dd/M/yyyy}">
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="100px" />
                </asp:BoundField>
                <asp:BoundField DataField="Usuario" HeaderText="Usuario">
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="250px" />
                </asp:BoundField>
                <asp:BoundField DataField="state" HeaderText="Estado">
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="250px" />
                </asp:BoundField>
            </Columns>
        </asp:GridView>

        <div id="divMensajesContainer" runat="server" class="form-control" style="display: flex; flex-direction: column; flex-grow: 1; overflow-y: scroll; height: 213px;">
            <div id="divMensajes" runat="server" style="flex-direction: column; height: 111px;">
            </div>
        </div>

    </div>



</asp:Content>

