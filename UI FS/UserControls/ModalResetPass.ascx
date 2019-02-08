<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ModalResetPass.ascx.vb" Inherits="UserControls_ModalResetPass" %>


  <!--modal-->
<div id="pwdModal" class="modal fade" data-backdrop="static" data-keyboard="false" tabindex="-1" role="dialog" aria-hidden="true">
  <div class="modal-dialog">
  <div class="modal-content">
      <div class="modal-header">
          
          
      </div>
      <h1 class="text-center">Nueva Password</h1>
      <div class="modal-body">
          <div class="col-md-12">
                <div class="panel panel-default">
                    <div class="panel-body">
                        <div class="text-center">
                          
                          <p>Ingrese una nueva Clave</p>
                            <div class="panel-body">
                                <fieldset>
                                    <div class="form-group">
                                        <%--<input runat="server" id="newPass" class="form-control input-lg" placeholder="Password" name="Pass" >--%>
                                        <asp:TextBox runat="server" id="txtNewPass" class="form-control input-lg" placeholder="Password" name="Pass" TextMode="Password"></asp:TextBox> 

                                    </div>
                                    <asp:Button ID="btnGrabar" runat="server" Text="Grabar" class="btn btn-lg btn-primary btn-block"  />

                                    <%--<input id="btnGrabar" onserverclick="ValidarNuevaClave" class="btn btn-lg btn-primary btn-block" value="Grabar" type="submit">--%>
                                  <div runat="server" visible="false" id="regSuccess" class="alert alert-success"  role="alert">
  </div>

                                    
                                      </fieldset>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
      </div>
      
  </div>
  </div>
</div>
         <script type="text/javascript">
        function openModal() {
            $('#pwdModal').modal('show');
        }

    </script>     






