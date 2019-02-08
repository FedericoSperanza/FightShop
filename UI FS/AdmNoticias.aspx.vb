Imports System.IO
Partial Class AdmNoticias
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not (Page.IsPostBack) Then

            CargarPagina()

        End If
    End Sub

    Public Sub HabilitarCampos()
        txtDescription.ReadOnly = False
        txtNombre.ReadOnly = False
        'txtUrlImagen.ReadOnly = False
        UrlImagen.Enabled = True


    End Sub

    Public Sub ReiniciarCampos()
        txtDescription.Text = ""
        txtNombre.Text = ""

        txtUrlImagen.Text = ""
        txtfecha.Text = ""
        UrlImagen.Dispose()


    End Sub

    Public Function ValidarCampos() As Boolean
        Dim resultado As Boolean = 0

        If txtDescription.Text = "" Or txtDescription.Text.Length < 40 Or
            txtNombre.Text = "" Or txtfecha.Text = "" Then



            regSuccess.Visible = True

            regSuccess.Attributes("class") = "alert alert-danger"
            regSuccess.InnerText = "Completar todos los CAMPOS !"
            resultado = 1
        Else
            If txtDescription.Text.Length > 50 Then
                resultado = 0
            Else

                regSuccess.Visible = True

                regSuccess.Attributes("class") = "alert alert-danger"
                regSuccess.InnerText = "Minimo 30 palabras en descripcion!"
                resultado = 0
            End If

        End If

        Return resultado


    End Function
    Public Sub InhabilitarCampos()
        txtDescription.ReadOnly = True
        txtNombre.ReadOnly = True

        ' UrlImagen.Enabled = False

    End Sub

    Public Sub CargarPagina()
        ''Valido si puede acceder al modulo de administracion
        Dim idPermAdm = BLL.usuarios.GetInstance.GetidPermByUrl("AdmNoticias.aspx")


        If Session("Nombre") IsNot Nothing Then



            If BLL.usuarios.GetInstance.PermiteAcceso(idPermAdm) Then
                ''No hago nada TODO OK!
            Else
                Response.Redirect("Home.Aspx")
            End If

        Else
            ''Aca es si no hay si quiera user logueado
            Response.Redirect("Home.Aspx")
        End If

        Me.GV_Noticias.DataSource = BLL.Noticias.ListarNoticias
        Me.GV_Noticias.DataBind()



        txtDescription.ReadOnly = True
        txtNombre.ReadOnly = True

        '   UrlImagen.Enabled = False



    End Sub


    Protected Sub GV_Noticias_SelectedIndexChanging(sender As Object, e As GridViewSelectEventArgs) Handles GV_Noticias.SelectedIndexChanging

        Dim txtDescripcionGV As String = CType(GV_Noticias.Rows(e.NewSelectedIndex).FindControl("txtDescripcionGV"), TextBox).Text



        HabilitarCampos()



        txtNombre.Text = Me.GV_Noticias.Rows(e.NewSelectedIndex).Cells(2).Text
        txtDescription.Text = txtDescripcionGV.ToString
        '  txtUrlImagen.Text = Me.GV_Noticias.Rows(e.NewSelectedIndex).Cells(6).Text
        txtfecha.Text = Me.GV_Noticias.Rows(e.NewSelectedIndex).Cells(5).Text
        Session("NotiModif") = txtNombre.Text
        txtNombre.Focus()
        imgPreview.ImageUrl = Me.GV_Noticias.Rows(e.NewSelectedIndex).Cells(6).Text


    End Sub


    Protected Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        HabilitarCampos()
        Session("FlagNew") = 1
        ReiniciarCampos()
        txtNombre.Focus()

    End Sub

    '' ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Pop", "openModal();", True)


    Protected Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click




        Dim txt As String = UrlImagen.FileName
        Dim Avalext(3) As String
        Dim ext As String
        Dim flagok As Boolean
        ''No usar script, validar en servidor si es jpg o no..
        ext = txt.Substring(txt.LastIndexOf(".") + 1).ToLower()

        Avalext(0) = "jpg"
        Avalext(1) = "png"


        For i = 0 To 2
            If ext = Avalext(i) Then

                flagok = True


            End If

        Next

        If flagok = True Then
            ''aca te deja guardar
            If ValidarCampos() = False Then
                ''sigue ok

                If Session("FlagNew") = 1 Then
                    'Creacion
                    Dim objNoticia As New BE.Noticias

                    objNoticia.nombre = txtNombre.Text
                    objNoticia.descripcion = txtDescription.Text
                    objNoticia.fechacaduc = txtfecha.Text


                    objNoticia.img = "Images/Noticias" + "/" + UrlImagen.PostedFile.FileName




                    If BLL.Noticias.GetInstance.CreateNoticia(objNoticia) Then

                        regSuccess.Visible = True

                        regSuccess.Attributes("class") = "alert alert-success"
                        regSuccess.InnerText = "Noticia Creada!"
                        regSuccess.Focus()
                        ReiniciarCampos()

                        'enviar mail

                        Dim u = BLL.usuarios.GetInstance.getAllForNewsletter
                        Dim notu = BLL.usuarios.GetInstance.getAllForNewsletterNotUsers

                        Dim urlimageformail As String
                        urlimageformail = Request.Url.GetLeftPart(UriPartial.Authority) + Request.ApplicationPath + objNoticia.img





                        If u IsNot Nothing Then


                            Dim mails = u.Select(Function(x) x.user).ToArray()

                            Dim FilePath As String = HttpContext.Current.Server.MapPath("~") & "MailTemplate\novedad.html"
                            Dim str = New StreamReader(FilePath)
                            Dim MailText As String = str.ReadToEnd()
                            str.Close()
                            Dim body = MailText.Replace("{title}", objNoticia.nombre) _
                .Replace("{body}", objNoticia.descripcion) _
                .Replace("{imageUrl}", urlimageformail)

                            BLL.Tools.SendMail(String.Join(",", mails), "[Novedad] " + objNoticia.nombre, body)


                            CargarPagina()
                            Session("FlagNew") = 0

                        End If


                        If notu IsNot Nothing Then
                            Dim xi As String


                            Dim mails = notu.Select(Function(x) xi).ToArray()

                            Dim FilePath As String = HttpContext.Current.Server.MapPath("~") & "MailTemplate\novedad.html"
                            Dim str = New StreamReader(FilePath)
                            Dim MailText As String = str.ReadToEnd()
                            str.Close()
                            Dim body = MailText.Replace("{title}", objNoticia.nombre) _
                .Replace("{body}", objNoticia.descripcion) _
                .Replace("{imageUrl}", urlimageformail)

                            BLL.Tools.SendMail(String.Join(",", mails), "[Novedad] " + objNoticia.nombre, body)


                            CargarPagina()
                            Session("FlagNew") = 0

                        End If
                    End If

                Else

                    'modificacion 
                    Dim idnoti As Integer

                    idnoti = BLL.Noticias.GetInstance.getidNotiByName(Session("NotiModif"))
                    Dim objnotimodif As New BE.Noticias

                    objnotimodif.nombre = txtNombre.Text
                    objnotimodif.descripcion = txtDescription.Text
                    objnotimodif.fechacaduc = txtfecha.Text
                    objnotimodif.img = "Images/Noticias" + "/" + UrlImagen.PostedFile.FileName


                    If BLL.Noticias.GetInstance.UpdateNoticia(objnotimodif, Session("NotiModif")) Then

                        regSuccess.Visible = True

                        regSuccess.Attributes("class") = "alert alert-success"
                        regSuccess.InnerText = "Noticia Modificada!"
                        regSuccess.Focus()
                        ReiniciarCampos()
                        CargarPagina()
                        Session("FlagNew") = 0

                    End If





                End If



            End If


        Else

            regSuccess.Visible = True

            regSuccess.Attributes("class") = "alert alert-danger"
            regSuccess.InnerText = "Solo se permiten archivos JPG/PNG !"
            regSuccess.Focus()


        End If





    End Sub

    Protected Sub GV_Productos_RowDeleting(sender As Object, e As GridViewDeleteEventArgs) Handles GV_Noticias.RowDeleting

        'Obtengo el ID

        If BLL.Noticias.GetInstance.DeleteNoticia(BLL.Noticias.GetInstance.getidNotiByName(Me.GV_Noticias.Rows(e.RowIndex).Cells(2).Text)) Then
            regSuccess.Visible = True
            regSuccess.Attributes("class") = "alert alert-success"
            regSuccess.InnerText = "Noticia Eliminada !"
            regSuccess.Focus()
            CargarPagina()

        Else



        End If

    End Sub



End Class
