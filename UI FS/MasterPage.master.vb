Imports BE.GlobalUsuario
Imports System.Web.UI.DataVisualization.Charting


Partial Class MasterPage
    Inherits System.Web.UI.MasterPage
    Public Shared user As New BE.usuarios



    Public Sub DesLogin()
        txtEmail.Visible = True
        txtPass.Visible = True
        ddUserLog.Visible = False
        btnLogin.Visible = True
        aRegistrarse.Visible = True
        user.user = Nothing
        usuarioConectado.user = Nothing
        aOlvidoPass.Visible = True
        'aPuntos.Visible = False
        aAdministracion.Visible = False
        Session("UserId") = Nothing
        Session("Nombre") = Nothing
        Session("MailUser") = Nothing
        Session("Apellido") = Nothing
        Session("ListNC") = Nothing
        Session("Diferencia") = Nothing
        Session("Cart") = Nothing
        Session("TotUsedNC") = Nothing
        Session("encuestaCerrada") = Nothing

        SectorLogeo.Attributes.Add("style", "height:62px")

        Response.Redirect("Home.Aspx")

    End Sub

    Public Sub ValidarUsuarioConectado()
        If user.user Is Nothing Then
            ddUserLog.Visible = False
            txtEmail.Visible = True
            txtPass.Visible = True
            aOlvidoPass.Visible = True
            ' aPuntos.Visible = False
            aAdministracion.Visible = False
            linkAddNewsletter.Visible = True
            linkDesAddNewsLetter.Visible = False



        Else

            ddUserLog.Visible = True
            ddUserLog.InnerText = user.nombre
            txtEmail.Visible = False
            txtPass.Visible = False
            btnLogin.Visible = False
            aRegistrarse.Visible = False
            aOlvidoPass.Visible = False
            'aPuntos.Visible = True


            If user.flagNewsLetter = True Then
                linkDesAddNewsLetter.Visible = True
                linkAddNewsletter.Visible = False
            Else
                linkDesAddNewsLetter.Visible = False
                linkAddNewsletter.Visible = True
            End If


            If user.primerlogin = True Then
                ModalResetPass.Show()

                'ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Pop", "openModal();", True)

            Else
                ModalResetPass.close()


                'ScriptManager.RegisterStartupScript(Me.Page, Me.Page.GetType(), "Pop", "$('#pwdModal').modal('hide');", True)

            End If
            'SectorLogeo.Style("height") = "70px"

            ''Valido si puede acceder al modulo de administracion
            Dim idPermAdm = BLL.usuarios.GetInstance.GetidPermByUrl("Default_Admin.aspx")


            If Session("Nombre") IsNot Nothing Then



                If BLL.usuarios.GetInstance.PermiteAcceso(idPermAdm) Then
                    aAdministracion.Visible = True
                Else
                    aAdministracion.Visible = False
                End If

            End If

        End If










    End Sub









    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load




        If Session("TotalPayment") = 0 Or Session("TotalPayment") Is Nothing Then
            dditemMiCompra.Visible = False

        End If




        If Session("desLogAdm") = 1 Then
            Session("UserId") = Nothing
            Session("Nombre") = Nothing
            Session("MailUser") = Nothing
            user = Nothing
            usuarioConectado = Nothing
            Session("desLogAdm") = 0
        End If
        If Not IsPostBack Then
            ' Session("encuestaCerrada") = Nothing
            'setEncuesta()

        End If

        ValidarUsuarioConectado()



        ''Valido si puede acceder al modulo de administracion
        Dim idPermAdm = BLL.usuarios.GetInstance.GetidPermByUrl("Default_Admin.aspx")


        If Session("Nombre") IsNot Nothing Then



            If BLL.usuarios.GetInstance.PermiteAcceso(idPermAdm) Then
                aAdministracion.Visible = True
            Else
                aAdministracion.Visible = False
            End If

        End If


    End Sub










    'Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
    '    '  Session("SearchQ") = Request.Url.AbsolutePath + "?q=" + txtsearch.Text
    '    Dim url = Request.Url.AbsolutePath + "?q=" + txtsearch.Text
    '    Server.TransferRequest(url, False)


    'End Sub

    Protected Sub btnBuscar_Click(sender As Object, e As ImageClickEventArgs) Handles btnBuscar.Click
        Response.Redirect("busqueda.aspx?q=" & txtBusqueda.Text)
    End Sub

    Protected Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click

        usuarioConectado = BLL.usuarios.GetInstance.Login(txtEmail.Value.ToString, txtPass.Value.ToString)
        If usuarioConectado IsNot Nothing Then
            'Session("Username") = usuarioConectado
            user = usuarioConectado
            Session("UserId") = user.id
            Session("Nombre") = user.nombre
            Session("Apellido") = user.apellido
            Session("MailUser") = user.user
            Dim bitacoraBL As New BLL.Bitacora
            bitacoraBL.GuardarINFOEnBitacora(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), txtEmail.Value.ToString, "Logeo de Usuario")

            SectorLogeo.Attributes.Add("style", "height:40px")



            ValidarUsuarioConectado()

        Else
            '   bitacoraBL.GuardarINFOEnBitacora(Date.Now, txtEmail.Text, "Intento de Login Invalido :" + txtEmail.text)
            Dim bitacoraBL As New BLL.Bitacora
            bitacoraBL.GuardarWARNINGEnBitacora(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), txtEmail.Value.ToString, "Logeo Fallido")


        End If



    End Sub


    Public Sub bajaNewsLetter()
        BLL.usuarios.GetInstance.SetSubscribed(Session("UserId"), 0)
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Pop", "openModal();", True)
        Response.Redirect("Home.Aspx")



    End Sub

    Shared Sub DesloginAdmin()
        user = Nothing
        usuarioConectado = Nothing



    End Sub



    Protected Sub lbCatalogo_Click(sender As Object, e As EventArgs) Handles lbCatalogo.Click
        Session("ProdFilter") = ""
        Response.Redirect("Catalogo.aspx")
    End Sub
    Protected Sub linkDesAddNewsLetter_Click(sender As Object, e As EventArgs) Handles linkDesAddNewsLetter.Click
        bajaNewsLetter()
    End Sub
End Class

