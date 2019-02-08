<%@ Control Language="VB" AutoEventWireup="false" CodeFile="userComments.ascx.vb" Inherits="userComments" %>
<%@ Register Src="~/UserControls/modalDialog.ascx" TagPrefix="uc1" TagName="modalDialog" %>

<uc1:modalDialog runat="server" ID="modalDialog" />

<div style="width: 98%; margin-top: 1vh; display: flex; flex-direction: column; align-items: flex-end;" id="divContainer" runat="server">
    <div style="width: 100%; padding: 1vh; background-color: bisque; border-radius: 7px">
        <div style="width: 100%; display: flex; flex-direction: row; justify-content: space-between">
            <div id="divName" runat="server" style="font-weight: bold">
                Nombre Usuario
            </div>
            <asp:HiddenField ID="hdnId" runat="server" />
            <div id="buttons">
                <asp:LinkButton runat="server" ID="btnReply" Style="margin-left: 1vh; margin-right: 1vh;">
                    <i class="fas fa-reply"></i>
                </asp:LinkButton>
                <asp:LinkButton runat="server" ID="btnDelete" Style="margin-left: 1vh; margin-right: 1vh;">
                    <i class="fas fa-times"></i>
                </asp:LinkButton>
            </div>
        </div>
        <div id="divBody" runat="server">
           BODY
        </div>
    </div>
</div>






