<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage2.master" AutoEventWireup="false" CodeFile="BackUps.aspx.vb" Inherits="BackUps" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <img src="images/backupimage.png" />


      <asp:Label runat="server" class="page-title"><h3>Backups</h3></asp:Label>
    <br />

      <div runat="server" visible="false" id="regSuccess" class="alert success-success" role="alert">
    </div>

<%--    <asp:GridView ID="grd" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-hover table-sm" DataKeyNames="id" Width="500px" AllowPaging="True" PageSize="10">
        <Columns>
            <asp:ButtonField CommandName="Select" ShowHeader="True" Text='<i class="fas fa-cloud-download-alt"></i>'>
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="35px" />
            </asp:ButtonField>
            <asp:ButtonField CommandName="Delete" ShowHeader="True" Text='<i class="fas fa-eraser"></i>'>
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="35px" />
            </asp:ButtonField>
            <asp:BoundField DataField="fecha" HeaderText="Fecha">
                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="150px" />
            </asp:BoundField>
            <asp:BoundField DataField="usuario" HeaderText="Usuario">
                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="200px" />
            </asp:BoundField>
            <asp:BoundField DataField="id" HeaderText="id" Visible="false">
                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="200px" />
            </asp:BoundField>

        </Columns>
    </asp:GridView>--%>

    <asp:Button class="btn btn-primary mt-1" ID="btnNuevo" runat="server" Text="Generar backup" formnovalidate />
    
    <br />
    <br />

    <h3>Generar Restore
        </h3>
    <asp:FileUpload ID="FURestore" runat="server" />

    <br />

    <asp:Button ID="btnRestore" runat="server" Text="Restaurar" />
</asp:Content>

