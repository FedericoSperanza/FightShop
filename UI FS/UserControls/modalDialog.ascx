<%@ Control Language="VB" AutoEventWireup="false" CodeFile="modalDialog.ascx.vb" Inherits="UserControls_modalDialog" %>
<style>
    .modal-dialog-bg {
        width: 100vw;
        height: 100vh;
        position: fixed;
        background-color: rgba(0,0,0,0.9);
        left: 0;
        top: 0;
        display: flex;
        justify-content: center;
        align-items: center;
        z-index: 999999;
    }

    .modal-dialog-content {
        width: 90%;
        min-height: 250px;
        max-width: 500px;
        background-color: white;
        display: flex;
        align-items: center;
        flex-direction: column;
        border-radius: 20px;
        overflow: hidden;
    }

    .modal-dialog-content-head {
        width: 100%;
        height: 50px;
        background-color: #ac762d;
        display: flex;
        justify-content: center;
        align-items: center;
        flex-direction: column;
        font-weight: bold;
        font-size: 100%;
        color: #ecf0f1;
    }

    .modal-dialog-content-body {
        width: 100%;
        flex-grow: 1;
        justify-content: center;
        align-items: center;
        flex-direction: column;
        justify-content: center;
        align-items: center;
        flex-direction: column;
        display: flex;
        padding-left: 10%;
        padding-right: 10%;
    }

    .modal-dialog-content-buttons {
        min-width: 400px;
        height: 75px;
        display: flex;
        justify-content: space-around;
        align-items: center;
        flex-direction: row;
    }
</style>


<div class="modal-dialog-bg">
    <div class="modal-dialog-content">
        <div class="modal-dialog-content-head">
            <asp:Label ID="lblTitle" runat="server" Text="title"></asp:Label>
        </div>
        <div class="modal-dialog-content-body">
            <asp:TextBox ID="txtValue" runat="server" class="form-control" MaxLength="500"></asp:TextBox>
        </div>
        <div class="modal-dialog-content-buttons">
            <asp:Button class="btn btn-primary" ID="btnAceptar" runat="server" Text="Aceptar" formnovalidate />
            <asp:Button class="btn btn-primary" ID="btnCancelar" runat="server" Text="Cancelar" formnovalidate />
        </div>
    </div>
</div>

