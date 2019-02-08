<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="NewsLetter.aspx.vb" Inherits="NewsLetter" %>

<%@ Register Src="~/UserControls/modalDialog.ascx" TagPrefix="uc1" TagName="modalDialog" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <uc1:modalDialog runat="server" ID="modalDialog" />



      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;


      <div runat="server" visible="false" id="regSuccess" class="alert alert-warning" role="alert"/>
               
       


      <asp:Image ID="Image1" ImageUrl="~/images/NewsEvents.JPG" runat="server"  Height="125px" Width="538px" ImageAlign="Middle" />

     

    <div style="height: 152px; position:center;display: flex;" >

         <br />

       <div id="divCategorias" runat="server" style="margin-left: 394px; height: 154px;">
            <div style="width: 300px; padding-bottom: 2vh">
               <h3> Selecciona categorias</h3>
            </div>
            <asp:CheckBoxList ID="chlCategorias" runat="server" DataTextField="nombre" DataValueField="id"></asp:CheckBoxList>
       
           <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
              <asp:LinkButton ID="lbuttonSuscribirse" runat="server">Suscribirse</asp:LinkButton>
              
               </div>


    </div>





</asp:Content>

