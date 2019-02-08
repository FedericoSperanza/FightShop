
Imports System.Net.Mail
Imports System.Net
Imports System.Collections.Generic
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Configuration
Imports System.IO
Partial Class ResetPass

    Inherits System.Web.UI.Page
    Dim activationCode As String = Guid.NewGuid().ToString()

    Protected Sub btnResetPass_Click(sender As Object, e As EventArgs) Handles btnResetPass.Click

        If BLL.usuarios.GetInstance.ResetPass(txtEmail.Text) = True Then
            regSuccess.Visible = True
            regSuccess.Attributes("class") = "alert alert-success"
            regSuccess.InnerText = "Clave aleatoria Generada ! Redireccion en 3 segundos"
            Response.AddHeader("REFRESH", "3;URL=Home.aspx")
        Else
            regSuccess.Visible = True
            regSuccess.Attributes("class") = "alert alert-danger"
            regSuccess.InnerText = "Mail invalido !"

        End If


        ''DESCOMENTAR EN CLASE SI SE PRUEBA MAIL ESTO
        'Dim body As String = CreateBody()

        'SendActivationEmail(body)
    End Sub


    'Public Sub SendActivationEmail()
    '    Using mm As New MailMessage("FightShopTFI@gmail.com", txtEmail.Text)
    '        mm.Subject = "Account Activation"
    '        Dim body As String = "Hola " + txtEmail.Text.Trim() + ","
    '        body += "<br /><br />Por favor ingresa en este link para activar tu cuenta"
    '        body += "<br /><a href = '" + Request.Url.AbsoluteUri.Replace("VB.aspx", Convert.ToString("VB_Activation.aspx?ActivationCode=") & activationCode) + "'>Click aqui.</a>"
    '        body += "<br /><br />Gracias"
    '        mm.Body = body
    '        mm.IsBodyHtml = True
    '        Dim smtp As New SmtpClient()
    '        smtp.Host = "smtp.gmail.com"
    '        smtp.EnableSsl = True
    '        Dim NetworkCred As New NetworkCredential("FightShopTFI@gmail.com", "fechedecba")
    '        smtp.UseDefaultCredentials = True
    '        smtp.Credentials = NetworkCred
    '        smtp.Port = 587

    '        Try
    '            smtp.Send(mm)
    '            txtEmail.Text = "mensaje enviado"
    '        Catch ex As Exception
    '            txtEmail.Text = "ERROR" & ex.Message
    '        End Try
    '    End Using
    'End Sub

    Public Function CreateBody() As String
        Dim body As String = String.Empty

        Using reader As New StreamReader(Server.MapPath("MailTemplate/MailTemplate.html"))


            body = reader.ReadToEnd

            body = body.Replace("{UserName}", txtEmail.Text.Trim) ' //replacing the required things  

            body = body.Replace("{Title}", "Reinicio de Cuenta")

            body = body.Replace("{message}", "Por favor ingresa a este link para restablecer contraseña" & " " + "<br /><a href = '" + Request.Url.AbsoluteUri.Replace("VB.aspx", Convert.ToString("VB_Activation.aspx?ActivationCode=") & activationCode) + "'>Click aqui.</a>")


            Return body

        End Using
    End Function

    Public Sub SendActivationEmail(body As String)
        Using mm As New MailMessage("FightShopTFI@gmail.com", txtEmail.Text)
            mm.Subject = "Olvido de Contraseña"
            '        Dim body As String = "Hola " + txtEmail.Text.Trim() + ","
            '        body += "<br /><br />Por favor ingresa en este link para activar tu cuenta"
            '        body += "<br /><a href = '" + Request.Url.AbsoluteUri.Replace("VB.aspx", Convert.ToString("VB_Activation.aspx?ActivationCode=") & activationCode) + "'>Click aqui.</a>"
            '        body += "<br /><br />Gracias"
            mm.Body = body
            mm.IsBodyHtml = True
            Dim smtp As New SmtpClient()
            smtp.Host = "smtp.gmail.com"
            smtp.EnableSsl = True
            Dim NetworkCred As New NetworkCredential("FightShopTFI@gmail.com", "fechedecba")
            smtp.UseDefaultCredentials = True
            smtp.Credentials = NetworkCred
            smtp.Port = 587

            Try
                smtp.Send(mm)
                txtEmail.Text = "mensaje enviado"
            Catch ex As Exception
                txtEmail.Text = "ERROR" & ex.Message
            End Try
        End Using
    End Sub

End Class
