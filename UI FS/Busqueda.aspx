<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Busqueda.aspx.vb" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

        <asp:label runat="server" class="page-title">Busqueda</asp:label>

    <div class="form-row mr-3 mt-3">
        <div class="col-sm-4">
            <asp:Repeater ID="rptResultados" runat="server">
                   <ItemTemplate>

                    <asp:HyperLink id="hyperlink1"
                  NavigateUrl='<%# Eval("URL")%>'
                  Text='<%# Eval("Nombre")%>'
                  runat="server"/>
                       <asp:Label ID="lblDescripcion" runat="server" Text='<%# Eval("Descripcion")%>' Font-Italic="True" Font-Size="Small"></asp:Label>
                    <br />


                </ItemTemplate>

            </asp:Repeater>
            <div id="divResultados" runat="server">
                
            </div>
        </div>
    </div>


</asp:Content>

