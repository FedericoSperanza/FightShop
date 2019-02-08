
Partial Class MasterPage2
    Inherits System.Web.UI.MasterPage
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        ddUserLog.Text = Session("Nombre")



    End Sub


    Protected Sub Deslogin()
        ddUserLog.Text = ""
        Session("Nombre") = ""
        Session("UserId") = ""
        Session("desLogAdm") = 1







    End Sub


End Class

