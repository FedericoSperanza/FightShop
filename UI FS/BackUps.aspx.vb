
Imports System.IO

Partial Class BackUps
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not (Page.IsPostBack) Then
            Actualizar()
        End If
    End Sub

    Private Sub Actualizar()
        'Valido si puede acceder al modulo de administracion
        Dim idPermAdm = BLL.usuarios.GetInstance.GetidPermByUrl("Backups.aspx")


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


        Dim dsBackups = BLL.Tools.GetInstance.GetAllBaks()
        Dim accesosbl As New BLL.servicesBL

        If dsBackups IsNot Nothing Then


            For Each usuario In dsBackups
                usuario.usuario = accesosbl.Desencriptar3d(usuario.usuario)
            Next
        End If
        'Me.grd.DataSource = dsBackups
        'Me.grd.DataBind()

        ' Dim dir As String = HttpContext.Current.Server.MapPath("~")
        Dim dir As String = "C:\"

        If Not dir.EndsWith("\") Then dir = dir & "\"
        dir = dir & "bkps\"
        If IO.Directory.Exists(dir) Then
            Dim files() As String = IO.Directory.GetFiles(dir)
            For Each file As String In files
                ' Do work, example
                Dim text As String = IO.File.ReadAllText(file)
            Next
        End If

    End Sub


    Protected Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        '  Dim dir As String = HttpContext.Current.Server.MapPath("~")
        Dim dir As String = "C:\"
        Try
            If Not Directory.Exists(dir) Then Directory.CreateDirectory(dir)
        Catch ex As Exception
            ' messages.getInstance.showError(ex.Message)
        End Try

        If Not dir.EndsWith("\") Then dir = dir & "\"
        dir = dir & "bkps\"
        If Not IO.Directory.Exists(dir) Then
            IO.Directory.CreateDirectory(dir)
        End If
        Dim fileName = String.Format("{0}{1}_Backup_{2}.bak", dir, "FightShop", DateTime.Now.ToString("yyyyMMddhhmmss"))

        BLL.Tools.GetInstance.Realizarbackup(fileName)
        Dim b As New BE.Backup
        b.fecha = Now
        b.usuario = Session("UserId")
        b.filename = fileName
        BLL.Tools.Add(b)
        regSuccess.Visible = True
        regSuccess.Focus()
        regSuccess.Attributes("class") = "alert alert-success"
        regSuccess.InnerText = "Backup Exitoso!"
        Dim BitacoraBL As New BLL.Bitacora
        BitacoraBL.GuardarINFOEnBitacora(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), Session("MailUser"), "Backup")

        Actualizar()

    End Sub

    'Protected Sub grd_SelectedIndexChanging(sender As Object, e As GridViewSelectEventArgs) Handles grd.SelectedIndexChanging
    '    ''RESTORE
    '    Dim BackupId = grd.DataKeys(e.NewSelectedIndex).Value

    '    Try
    '        Dim filename = BLL.Tools.GetInstance.GetById(BackupId).filename
    '        BLL.Tools.GetInstance.RestaurarBackup(filename)
    '        regSuccess.Visible = True
    '        regSuccess.Focus()
    '        regSuccess.Attributes("class") = "alert alert-success"
    '        regSuccess.InnerText = "Restore Exitoso!"
    '        ''poner mensaje de exito
    '        Actualizar()
    '    Catch ex As Exception
    '        ''poner mensaje de error
    '    End Try
    '    Dim BitacoraBL As New BLL.Bitacora
    '    BitacoraBL.GuardarINFOEnBitacora(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), Session("MailUser"), "Restore")

    '    Server.TransferRequest(Request.Url.AbsolutePath, False)
    'End Sub

    'Protected Sub grd_RowDeleting(sender As Object, e As GridViewDeleteEventArgs) Handles grd.RowDeleting
    '    Dim BackupeId = grd.DataKeys(e.RowIndex).Value
    '    Try
    '        BLL.Tools.GetInstance.Delete(BackupeId)

    '        regSuccess.Visible = True
    '        regSuccess.Focus()
    '        regSuccess.Attributes("class") = "alert alert-success"
    '        regSuccess.InnerText = "Backup Exitoso!"

    '        Actualizar()
    '    Catch ex As Exception
    '        'Message.MessageType.Err, "Error", ex.Message

    '    End Try
    '    Server.TransferRequest(Request.Url.AbsolutePath, False)
    'End Sub





    Protected Sub btnRestore_Click(sender As Object, e As EventArgs) Handles btnRestore.Click

        Dim extension = System.IO.Path.GetExtension(Me.FURestore.FileName)

        If extension <> ".bak" And extension <> ".BAK" And extension <> ".baK" Then
            ''MSG DE ERROR DE FORMATO
            regSuccess.Visible = True
            regSuccess.Focus()
            regSuccess.Attributes("class") = "alert alert-danger"
            regSuccess.InnerText = "Restore Fallido(Formato Archivo Invalido)!"
            Me.FURestore.Focus()
            Return
        End If
        Try
            Dim file = "C:\bkps\" + FURestore.FileName

            BLL.Tools.GetInstance.RestaurarBackup(file)
            regSuccess.Visible = True
            regSuccess.Focus()
            regSuccess.Attributes("class") = "alert alert-success"
            regSuccess.InnerText = "Restore Exitoso!"
        Catch ex As Exception
            regSuccess.Focus()
            regSuccess.Attributes("class") = "alert alert-danger"
            regSuccess.InnerText = "Error:" + ex.Message

        End Try

    End Sub
End Class
