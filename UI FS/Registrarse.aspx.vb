
Partial Class Registrarse
    Inherits System.Web.UI.Page

    Protected Sub btnCrearCuenta_Click(sender As Object, e As EventArgs) Handles btnCrearCuenta.Click

        If Not ctrlGoogleReCaptcha.Validate Then
            regSuccess.Visible = True
            regSuccess.Attributes("class") = "alert alert-danger"
            regSuccess.InnerText = "Error de Captcha"
            Return


        End If

        Dim NewUser As New BE.usuarios

        NewUser.nombre = txtName.Text
        NewUser.apellido = txtSurname.Text
        NewUser.user = txtEmail.Text
        NewUser.pass = txtPass.Text
        NewUser.telefono = txtTelf.Text
        NewUser.primerlogin = Convert.ToInt32(1)


        If BLL.usuarios.GetInstance.Registrarse(NewUser) Then
            regSuccess.Visible = True
            Response.AddHeader("REFRESH", "3;URL=Home.aspx")
            regSuccess.Attributes("class") = "alert alert-success"
            regSuccess.InnerText = "Usuario Creado Satisfactoriamente ! - Hemos enviado un mail a tu casilla.Seras redireccionado al Home en 3 segundos."

            'Acordarse de agregar el Permiso por defecto de usuario registrado en ECommerce que seria el de idPermiso 1


            'SendActivationEmail()
        End If



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


End Class
