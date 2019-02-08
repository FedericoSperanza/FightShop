Imports BE.GlobalUsuario
Public Class UserControls_ModalResetPass
    Inherits System.Web.UI.UserControl



    Public Sub Show()
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Pop", "openModal();", True)
        Me.Visible = True

    End Sub




    Public Sub Close()
        ScriptManager.RegisterStartupScript(Me.Page, Me.Page.GetType(), "Pop", "$('#pwdModal').modal('hide');", True)

        Me.Visible = False

    End Sub



    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

    End Sub



    Protected Sub btnGrabar_click(sender As Object, e As EventArgs) Handles btnGrabar.Click

        ValidarNuevaClave()


    End Sub

    Public Sub ValidarNuevaClave()
        If txtNewPass.Text = "" Then
            regSuccess.Attributes("class") = "alert alert-danger"
            regSuccess.InnerText = "Debe ingresar una contraseña"
            regSuccess.Visible = True
        ElseIf BLL.usuarios.GetInstance.GrabarNewPass(usuarioconectado.user, txtNewPass.text) Then
            regSuccess.Attributes("class") = "alert alert-success"
            regSuccess.InnerText = "Contraseña Grabada, Redireccionando!"
            regSuccess.Visible = True

            ''ACA HAY QUE ACTUALIZAR EL User (que se usa global, xq sino sigue tomando que es 1er login)

            usuarioConectado.primerlogin = False


            Response.AddHeader("REFRESH", "3;URL=Home.aspx")





        End If

    End Sub






End Class
