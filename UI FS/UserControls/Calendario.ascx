<%@ Control Language="VB" AutoEventWireup="false" CodeFile="Calendario.ascx.vb" Inherits="UserControls_Calendario" %>



<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">

    
<div style="display: flex; flex-direction:row" class="ml-1 ">
    <asp:TextBox ID="txt" class="form-control" runat="server" ReadOnly="True" style="background-color:white; " Width="62px"></asp:TextBox>
    <button runat="server" id="btnClear" onserverclick="btnClear_Click">
        <i class="fas fa-eraser"></i>
    </button>
    <button runat="server" id="btnPick" onserverclick="btnPick_Click">
        <i class="fas fa-calendar-plus-o"></i>
    </button>
</div>

<asp:Calendar ID="dp" runat="server" Visible="False" Width="145px" Height="193px"></asp:Calendar>


    
    
      <%--<asp:TextBox ID="txt" class="form-control" runat="server" ReadOnly="True" style="background-color:white ;"></asp:TextBox>--%>

      
       <%--     <asp:ImageButton ID="BtnImagen" runat="server" ImageUrl="~/images/calendario.png" Height="29px" Width="41px" />
            <asp:CalendarExtender ID="CalendarExtender2" runat="server"
             TargetControlID="TxtFecha2"
              PopupButtonID="BtnImagen">
            </asp:CalendarExtender>--%>

