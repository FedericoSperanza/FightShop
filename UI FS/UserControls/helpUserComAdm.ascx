<%@ Control Language="VB" AutoEventWireup="false" CodeFile="helpUserComAdm.ascx.vb" Inherits="UserControls_helpUserComAdm" %>

<%@ Register Src="modalDialog.ascx" TagName="modalDialog" TagPrefix="uc1" %>

<div style="width: 98%; margin-top: 1vh; display: flex; flex-direction: column; align-items: flex-end;" id="divContainer" runat="server">
    <div style="width: 100%; padding: 1vh; background-color: white; border-radius: 7px;border-style: solid; border-width: thin; border-color:lightgray">
        <div style="width: 100%; display: flex; flex-direction: row; justify-content: space-between">
            <div id="divName" runat="server" style="font-weight: bold">
                nombre del usuario
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
            aca va el body
        </div>
    </div>
</div>

<uc1:modalDialog ID="modalDialog" runat="server"/>