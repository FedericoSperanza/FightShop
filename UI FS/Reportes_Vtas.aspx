<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage2.master" AutoEventWireup="false" CodeFile="Reportes_Vtas.aspx.vb" Inherits="Reportes_Vtas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <%@ Register Src="UserControls/Calendario.ascx" TagName="datePicker" TagPrefix="uc2" %>

     <asp:Label runat="server" class="page-title">Reportes de Ventas</asp:Label>

      <div runat="server" visible="false" id="regSuccess" class="alert alert-warning" role="alert"/>
               
         
     <!--Ganancias Anual-->
    <div id="divGanancias" runat="server" class="container mt-2">
        <div class="row">
            <div class="col-sm-3">
                <asp:Label runat="server" for="dpDesdeGanancias">Desde:</asp:Label>
                <uc2:datePicker ID="dpDesdeGanancias" runat="server" />
            </div>
            <div class="col-sm-3">
                <asp:Label runat="server" for="dpHastaGanancias">Hasta:</asp:Label>
                <uc2:datePicker ID="dpHastaGanancias" runat="server" />
            </div>
            <div class="col-sm-3">
                <br />
                <asp:Button class="btn btn-primary mt-1" ID="btnFiltrarGanancias" runat="server" Text="Filtrar" />
            </div>
        </div>




        <div id="divGanancias_Content" class="row" runat="server">
            <div id="divPreguntaGanancias" runat="server" style="width: 100%; font-size: 4vh; font-weight: bold" />
            <div class="table-responsive">
                <asp:Table ID="tblGanancias" runat="server" CssClass="table">
                </asp:Table>
            </div>
        </div>
        <%-- CHARTs Anual--%>

         <asp:Chart EnableViewState="true" ID="chartGanancias" runat="server" Visible="true" Style="max-width: 100%">
                    <Series>
                        <asp:Series Name="Series1"></asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                    </ChartAreas>
                </asp:Chart>

        <%-- CHART Mensual --%>

          <asp:Chart EnableViewState="true" ID="chartGananciMensual" runat="server" Visible="true" Style="max-width: 100%">
                    <Series>
                        <asp:Series Name="Series1"></asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                    </ChartAreas>
                </asp:Chart>

           <%-- CHART Semanal --%>

          <asp:Chart EnableViewState="true" ID="chartGananciaSemanal" runat="server" Visible="true" Style="max-width: 100%">
                    <Series>
                        <asp:Series Name="Series1"></asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                    </ChartAreas>
                </asp:Chart>



    </div>

  

</asp:Content>

