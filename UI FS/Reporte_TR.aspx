<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage2.master" AutoEventWireup="false" CodeFile="Reporte_TR.aspx.vb" Inherits="Reporte_TR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    
    <%@ Register Src="UserControls/Calendario.ascx" TagName="datePicker" TagPrefix="uc2" %>



     <!--Tiempo De Respuesta-->

      <div runat="server" visible="false" id="regSuccess" class="alert alert-warning" role="alert"/>
               
         

    <div id="divTiempoDeRespuesta" runat="server" class="container mt-2">
        <div class="row">
            <div class="col-sm-3">
                <asp:Label runat="server" for="dpDesdeTiempoDeRespuesta">Desde:</asp:Label>
                <uc2:datePicker ID="dpDesdeTiempoDeRespuesta" runat="server" />
            </div>
            <div class="col-sm-3">
                <asp:Label runat="server" for="dpHastaTiempoDeRespuesta">Hasta:</asp:Label>
                <uc2:datePicker ID="dpHastaTiempoDeRespuesta" runat="server" />
            </div>
            <div class="col-sm-3">
                <br />
                <asp:Button class="btn btn-primary mt-1" ID="btnFiltrarTiempoDeRespuesta" runat="server" Text="Filtrar" formnovalidate />
            </div>
        </div>
        <div id="divTiempoDeRespuesta_Content" class="row" runat="server">
            <div id="divPreguntaTiempoDeRespuesta" runat="server" style="width: 100%; font-size: 4vh; font-weight: bold" />
            <div id="divChartTiempoDeRespuesta" runat="server" style="width: 800px; height: 600px">
                <asp:Chart EnableViewState="true" ID="chartTiempoDeRespuesta" runat="server" Style="max-width: 100%">
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
</asp:Content>

