Imports System.IO
Imports System.Xml.Linq

Partial Class AdmPublicidad
    Inherits System.Web.UI.Page



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        If Not (Page.IsPostBack) Then
            Actualizar()
        End If
    End Sub

    Private Function getDoc() As XDocument
        Dim xmlDoc = XDocument.Load(getDocPath)
        Return xmlDoc
    End Function

    Private Function getDocPath()
        Dim dir As String = HttpContext.Current.Server.MapPath("~")
        If Not dir.EndsWith("\") Then dir = dir & "\"
        dir = dir & "publicidades\"
        Return dir + "XMLFile.xml"
    End Function

    Private Sub Actualizar()


        Dim idPermAdm = BLL.usuarios.GetInstance.GetidPermByUrl("AdmPublicidad.aspx")


        If Session("Nombre") IsNot Nothing Then



            If BLL.usuarios.GetInstance.PermiteAcceso(idPermAdm) Then
                ''No hago nada TODO OK!
            Else
                Response.Redirect("Home.Aspx")
            End If

        Else
            'Aca es si no hay si quiera user logueado
            Response.Redirect("Home.Aspx")
        End If









        Dim xmlDoc = getDoc()
        Dim Consulta = From Ad In xmlDoc.Descendants("Ad")
                       Select New With
                           {
                               .AlternateText = Ad.Element("AlternateText").Value,
                               .NavigateUrl = Ad.Element("NavigateUrl").Value,
                               .ImageUrl = Ad.Element("ImageUrl").Value
                           }

        Me.grd.DataSource = Consulta.ToList
        Me.grd.DataBind()

        btnNuevo.Visible = grd.Rows.Count > 0

        btnNuevo_Click(Nothing, Nothing)
    End Sub

    Protected Sub grd_SelectedIndexChanging(sender As Object, e As GridViewSelectEventArgs) Handles grd.SelectedIndexChanging

        ViewState("i") = e.NewSelectedIndex

        Dim xmlDoc = getDoc()
        Dim Consulta = From Ad In xmlDoc.Descendants("Ad")
                       Select New With
                           {
                               .AlternateText = Ad.Element("AlternateText").Value,
                               .NavigateUrl = Ad.Element("NavigateUrl").Value,
                               .ImageUrl = Ad.Element("ImageUrl").Value
                           }

        Dim lst = Consulta.ToList
        Dim o = lst(e.NewSelectedIndex)

        ViewState("ImageUrl") = o.ImageUrl

        Me.txtTitle.Text = o.AlternateText
        Me.txtURL.Text = o.NavigateUrl
        Me.imgPreview.ImageUrl = o.ImageUrl

    End Sub

    Protected Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim alternateText = txtTitle.Text
        Dim navigateUrl = txtURL.Text
        Dim ImageUrl = Me.imgPreview.ImageUrl


        If ViewState("i") > -1 Then
            If Not Me.fuImagen.HasFile Then
                ImageUrl = ViewState("ImageUrl")
            Else
                Dim extension = System.IO.Path.GetExtension(Me.fuImagen.FileName)
                If extension <> ".jpg" And extension <> ".jpeg" And extension <> ".gif" And extension <> ".png" Then
                    ''MSG DE ERROR DE FORMATO
                    Me.fuImagen.Focus()
                    Return
                End If

                Dim file = "images/publicidades/" + fuImagen.FileName
                fuImagen.SaveAs(HttpContext.Current.Server.MapPath("~") & file)
                ImageUrl = Request.Url.GetLeftPart(UriPartial.Authority) + Request.ApplicationPath + file
            End If

            Dim xmlDoc = getDoc()
            Dim el = xmlDoc.Descendants("Ad").ElementAt(ViewState("i"))
            el.SetElementValue("AlternateText", alternateText)
            el.SetElementValue("NavigateUrl", navigateUrl)
            el.SetElementValue("ImageUrl", ImageUrl)
            xmlDoc.Save(getDocPath())
        Else
            If Not Me.fuImagen.HasFile Then
                'msg de selecccion error
                Me.fuImagen.Focus()
                Return
            Else
                Dim extension = System.IO.Path.GetExtension(Me.fuImagen.FileName)
                If extension <> ".jpg" And extension <> ".jpeg" And extension <> ".gif" And extension <> ".png" Then
                    'Error seleccione imgn para publicidad
                    Me.fuImagen.Focus()
                    Return
                End If
            End If

            Dim file = "images/publicidades" + fuImagen.FileName
            fuImagen.SaveAs(HttpContext.Current.Server.MapPath("~") & file)
            ImageUrl = Request.Url.GetLeftPart(UriPartial.Authority) + Request.ApplicationPath + file

            Dim xmlDoc = getDoc()

            xmlDoc.Element("Advertisements").Add(New XElement("Ad",
                                         New XElement("ImageUrl", ImageUrl),
                                         New XElement("NavigateUrl", navigateUrl),
                                         New XElement("AlternateText", alternateText),
                                         New XElement("Impressions", "40"),
                                         New XElement("Keyword", alternateText)
                                         ))
            xmlDoc.Save(getDocPath())
        End If

        Actualizar()
    End Sub

    Protected Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        ViewState("i") = -1

        Me.txtURL.Text = ""
        Me.txtTitle.Text = ""
        Me.imgPreview.ImageUrl = "Content/No_Image_Available.gif"
    End Sub

    Protected Sub grd_RowDeleting(sender As Object, e As GridViewDeleteEventArgs) Handles grd.RowDeleting

        Try
            Dim xmlDoc = getDoc()
            xmlDoc.Descendants("Ad").ElementAt(e.RowIndex).Remove()
            xmlDoc.Save(getDocPath())
            'MSG NOVEDAD BORRADA

            Actualizar()
        Catch ex As Exception
            ''REGSUCES ERROR
        End Try
        Server.TransferRequest(Request.Url.AbsolutePath, False)
    End Sub

    Protected Sub grd_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles grd.PageIndexChanging
        grd.PageIndex = e.NewPageIndex
        Actualizar()
    End Sub



End Class
