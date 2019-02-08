
Partial Class AdmUsuario
    Inherits System.Web.UI.Page
    Dim FlagError As Boolean
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not (Page.IsPostBack) Then

            CargarPagina()

        End If
    End Sub
    Sub BloquearControles()
        txtApellido.ReadOnly = True
        txtEMAIL.ReadOnly = True

        txtNombre.ReadOnly = True
        txtTelefono.ReadOnly = True

        txtApellido.Text = ""
        txtEMAIL.Text = ""

        txtNombre.Text = ""
        txtTelefono.Text = ""
    End Sub


    Sub HabilitarControles()
        txtApellido.ReadOnly = False
        txtEMAIL.ReadOnly = False

        txtNombre.ReadOnly = False
        txtTelefono.ReadOnly = False
        txtApellido.Text = ""
        txtEMAIL.Text = ""

        txtNombre.Text = ""
        txtTelefono.Text = ""
    End Sub

    Sub ValidarControles()


    End Sub
    Sub CargarPagina()
        BloquearControles()
        'Valido si puede acceder al modulo de administracion
        Dim idPermAdm = BLL.usuarios.GetInstance.GetidPermByUrl("AdmUsuarios.aspx")


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



        Me.GV_Usuarios.DataSource = BLL.usuarios.GetInstance.ListAllUsers
        Me.GV_Usuarios.DataBind()

    End Sub
    Protected Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        HabilitarControles()
        txtEMAIL.Focus()
        Session("FlagNew") = 1




    End Sub
    Protected Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        ValidarControles()

        If FlagError = 1 Then
            'No Hago Nada Mostrar Algo

        Else

            If Session("FlagNew") = 1 Then
                ''entonces es Insert
                Dim objUsuario As New BE.usuarios

                objUsuario.user = txtEMAIL.Text
                objUsuario.nombre = txtNombre.Text
                objUsuario.apellido = txtApellido.Text
                objUsuario.telefono = txtTelefono.Text

                If BLL.usuarios.GetInstance.CreateUser(objUsuario) Then
                    Session("FlagNew") = 0
                    Dim bitacorabl As New BLL.Bitacora
                    bitacorabl.GuardarINFOEnBitacora(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), Session("MailUser"), "Creacion de Usuario")
                    regSuccess.Visible = True
                    regSuccess.Attributes("class") = "alert alert-success"
                    regSuccess.InnerText = "Usuario Creado !"

                Else
                    regSuccess.Visible = True
                    regSuccess.Attributes("class") = "alert alert-danger"
                    regSuccess.InnerText = "Hubo un Error / El Usuario ya Existe !"

                End If

            Else
                'es update
                Dim oUsuario As New BE.usuarios

                oUsuario.user = txtEMAIL.Text
                oUsuario.nombre = txtNombre.Text
                oUsuario.apellido = txtApellido.Text
                oUsuario.telefono = txtTelefono.Text


                If BLL.usuarios.GetInstance.UpdateUser(oUsuario, Session("UserModif")) Then

                    Dim bitacorabl As New BLL.Bitacora
                    bitacorabl.GuardarINFOEnBitacora(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), Session("MailUser"), "Actualizacion de Usuario")

                    Session("UserModif") = Nothing

                    regSuccess.Visible = True
                    regSuccess.Attributes("class") = "alert alert-success"
                    regSuccess.InnerText = "Usuario Modificado !"
                    regSuccess.Focus()
                Else
                    regSuccess.Visible = True
                    regSuccess.Attributes("class") = "alert alert-danger"
                    regSuccess.InnerText = "Hubo un Error !"
                    regSuccess.Focus()
                End If





            End If
            CargarPagina()
        End If


    End Sub
    Protected Sub GV_Usuarios_SelectedIndexChanging(sender As Object, e As GridViewSelectEventArgs) Handles GV_Usuarios.SelectedIndexChanging

        HabilitarControles()

        txtEMAIL.Text = Me.GV_Usuarios.Rows(e.NewSelectedIndex).Cells(3).Text
        txtNombre.Text = Me.GV_Usuarios.Rows(e.NewSelectedIndex).Cells(4).Text
        txtApellido.Text = Me.GV_Usuarios.Rows(e.NewSelectedIndex).Cells(5).Text

        txtTelefono.Text = Me.GV_Usuarios.Rows(e.NewSelectedIndex).Cells(7).Text


        Session("UserModif") = txtEMAIL.Text
        txtEMAIL.Focus()
    End Sub
    Protected Sub GV_Usuarios_RowDeleting(sender As Object, e As GridViewDeleteEventArgs) Handles GV_Usuarios.RowDeleting

        Dim blRoles As New BLL.Roles

        Dim idUsuario As Integer
        idUsuario = BLL.usuarios.GetInstance.ObtenerIdPorEmail(Me.GV_Usuarios.Rows(e.RowIndex).Cells(3).Text)



        Dim lstPermisosAsignadosUser As New List(Of BE.permisos)

        ''Cargo los Permisos Asignados al Usuario desde los Roles
        For Each item In BLL.usuarios.GetInstance.CargarRolessDeUsuario(idUsuario)
            If lstPermisosAsignadosUser.Count = 0 Then
                lstPermisosAsignadosUser.AddRange(blRoles.CargarpermisosPorRoles(item.id))
            Else
                lstPermisosAsignadosUser.Union(blRoles.CargarpermisosPorRoles(item.id))
            End If



        Next
        ''Creo lista de Permisos No Asignados para Checkearlos en la tabla de Usu-Rol
        Dim puedebloquear As Boolean = True
        Dim lstPermisoNoAsignadoenUsuario As New List(Of Integer)
        For Each item In lstPermisosAsignadosUser
            'Me fijo si puedo eliminar el usuario buscandolas patentes asignadas en otros usuarios.
            If Not (blRoles.VerificarPatenteEsUsada2(item.id, idUsuario)) Then
                lstPermisoNoAsignadoenUsuario.Add(item.id)
            End If
        Next

        If lstPermisoNoAsignadoenUsuario.Count > 0 Then
            puedebloquear = False
            GoTo sigueAqui
        End If


sigueaqui:

        If puedebloquear Then

            If BLL.usuarios.GetInstance.DeleteUser(idUsuario) Then

                regSuccess.Visible = True
                regSuccess.Attributes("class") = "alert alert-success"
                regSuccess.InnerText = "Usuario Eliminado !"
                regSuccess.Focus()
            Else

                regSuccess.Visible = True
                regSuccess.Attributes("class") = "alert alert-danger"
                regSuccess.InnerText = "Hubo un Error !"
                regSuccess.Focus()
            End If
            CargarPagina()

        Else


            regSuccess.Visible = True
            regSuccess.Attributes("class") = "alert alert-danger"
            regSuccess.InnerText = "No se puede Eliminar Usuario ! (Permisos Huerfanos) !"
            regSuccess.Focus()

            CargarPagina()
        End If



    End Sub

    Protected Sub GV_Usuarios_RowCommand(ByVal sender As Object, ByVal e As GridViewCommandEventArgs)
        If (e.CommandName = "BloquearDesbloquear") Then
            ' Retrieve the row index stored in the CommandArgument property.
            Dim idUsuario As Integer
            Dim mail As String
            mail = GV_Usuarios.Rows(e.CommandArgument).Cells(3).Text
            idUsuario = BLL.usuarios.GetInstance.ObtenerIdPorEmail(mail)


            Dim Estado As Boolean = GV_Usuarios.Rows(e.CommandArgument).Cells(6).Text


            Dim blRoles As New BLL.Roles



            Dim lstPermisosAsignadosUser As New List(Of BE.permisos)

            ''Cargo los Permisos Asignados al Usuario desde los Roles
            For Each item In BLL.usuarios.GetInstance.CargarRolessDeUsuario(idUsuario)
                If lstPermisosAsignadosUser.Count = 0 Then
                    lstPermisosAsignadosUser.AddRange(blRoles.CargarpermisosPorRoles(item.id))
                Else
                    lstPermisosAsignadosUser.Union(blRoles.CargarpermisosPorRoles(item.id))
                End If



            Next
            ''Creo lista de Permisos No Asignados para Checkearlos en la tabla de Usu-Rol
            Dim puedebloquear As Boolean = True
            Dim lstPermisoNoAsignadoenUsuario As New List(Of Integer)
            For Each item In lstPermisosAsignadosUser
                'Me fijo si puedo eliminar el usuario buscandolas patentes asignadas en otros usuarios.
                If Not (blRoles.VerificarPatenteEsUsada2(item.id, idUsuario)) Then
                    lstPermisoNoAsignadoenUsuario.Add(item.id)
                End If
            Next

            If lstPermisoNoAsignadoenUsuario.Count > 0 Then
                puedebloquear = False
                GoTo sigueaqui
            End If


sigueaqui:

            If puedebloquear Then
                If Estado = True Then

                    If BLL.usuarios.GetInstance.Bloquear_Desbloquear(idUsuario, 0) Then
                        regSuccess.Visible = True
                        regSuccess.Attributes("class") = "alert alert-success"
                        regSuccess.InnerText = "Usuario DesBloqueado !"
                        regSuccess.Focus()
                    End If
                Else
                    BLL.usuarios.GetInstance.Bloquear_Desbloquear(idUsuario, 1)
                    regSuccess.Visible = True
                    regSuccess.Attributes("class") = "alert alert-success"
                    regSuccess.InnerText = "Usuario Bloqueado !"
                    regSuccess.Focus()
                End If
                CargarPagina()

            Else
                'aca no se puede bloquear porque quedan permisos huerfanos
                regSuccess.Visible = True
                regSuccess.Attributes("class") = "alert alert-danger"
                regSuccess.InnerText = "No se puede Bloquear Usuario ! (Permisos Huerfanos) !"
                regSuccess.Focus()

            End If



        End If

    End Sub
End Class
