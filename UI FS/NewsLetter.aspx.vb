Imports System.Web.UI.HtmlControls

Partial Class NewsLetter
    Inherits System.Web.UI.Page




    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not (Page.IsPostBack) Then
            chlCategorias.Items.Add("JIU JITSU")
            chlCategorias.Items.Add("BOXEO")
            chlCategorias.Items.Add("MMA")
            chlCategorias.Items.Add("EVENTOS")

            If Session("UserId") Is Nothing Then
                txtEmail.Visible = True
            Else
                txtEmail.Visible = False

            End If

        End If





    End Sub
    Protected Sub lbuttonSuscribirse_Click(sender As Object, e As EventArgs) Handles lbuttonSuscribirse.Click


        If divCategorias.Visible Then
            If Session("UserId") Is Nothing Then
                txtEmail.Visible = True
                For Each i As ListItem In chlCategorias.Items
                    If i.Selected Then
                        BLL.Suscripcion.GetInstance.Add(txtEmail.Text, i.Value)

                        regSuccess.Visible = True
                            regSuccess.Attributes("class") = "alert alert-success"
                        regSuccess.InnerText = "Te has suscripto al NewsLetter!. . ."

                        Response.AddHeader("REFRESH", "3;URL=Home.aspx")



                    End If
                Next
            Else
                txtEmail.Visible = False
                If BLL.usuarios.GetInstance.SetSubscribed(Session("UserId"), 1) Then
                    For Each i As ListItem In chlCategorias.Items
                        If i.Selected Then
                            BLL.Suscripcion.GetInstance.Add(Session("MailUser"), i.Value)


                            regSuccess.Visible = True
                            regSuccess.Attributes("class") = "alert alert-success"
                            regSuccess.InnerText = "Te has suscripto al NewsLetter!. . ."

                            ' Response.AddHeader("REFRESH", "3;URL=Home.aspx")
                        End If
                    Next



                Else



                End If

            End If
        Else
            divCategorias.Visible = True
        End If
    End Sub
End Class
