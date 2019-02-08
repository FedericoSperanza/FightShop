
Partial Class AdmRolUsuario
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not (Page.IsPostBack) Then

            CargarPagina()

        End If
    End Sub


    Sub CargarPagina()

        ''Valido si puede acceder al modulo de administracion
        ' Dim idPermAdm = BLL.usuarios.GetInstance.GetidPermByUrl("AdmUsuarios.aspx")


        'If Session("Nombre") IsNot Nothing Then



        '    If BLL.usuarios.GetInstance.PermiteAcceso(idPermAdm) Then
        '        ''No hago nada TODO OK!
        '    Else
        '        Response.Redirect("Home.Aspx")
        '    End If

        'Else
        ''Aca es si no hay si quiera user logueado
        'Response.Redirect("Home.Aspx")
        'End If



        Me.GV_RolUsuario.DataSource = BLL.usuarios.GetInstance.ListAllUsers
        Me.GV_RolUsuario.DataBind()

    End Sub
    Protected Sub GV_RolUsuario_SelectedIndexChanging(sender As Object, e As GridViewSelectEventArgs) Handles GV_RolUsuario.SelectedIndexChanging
        lstRolesDelUsuario.Items.Clear()
        lstRolesSist.Items.Clear()

        Dim idusuario As Integer
        Dim lstRolesUsuario As List(Of BE.roles)
        Dim lstRolesSinAsignar As List(Of BE.roles)
        Dim blRoles As New BLL.Roles

        lblUsuario.Text = Me.GV_RolUsuario.Rows(e.NewSelectedIndex).Cells(1).Text
        idusuario = BLL.usuarios.GetInstance.ObtenerIdPorEmail(lblUsuario.Text)
        lstRolesUsuario = BLL.usuarios.GetInstance.CargarRolessDeUsuario(idusuario)

        For Each Rol As BE.roles In lstRolesUsuario
            Me.lstRolesDelUsuario.Items.Add(Rol.nombre)
        Next

        lstRolesSinAsignar = blRoles.CargarRolesSinAsignaraUsuario(idusuario)

        For Each item As BE.roles In lstRolesSinAsignar
            Me.lstRolesSist.Items.Add(item.nombre)
        Next

        regSuccess.Visible = False



    End Sub

    Protected Sub btnDesAsgin_Click(sender As Object, e As EventArgs) Handles btnDesAsgin.Click
        If Me.lstRolesDelUsuario.SelectedItem Is Nothing Then
            regSuccess.Visible = True
            regSuccess.InnerText = "Debe seleccionar al menos 1 Rol"

        Else
            regSuccess.Visible = False
            Dim accesoRoles As New BLL.Roles
            Dim oRolUsuario As New BE.RolUsuario

            oRolUsuario.idRol = accesoRoles.ObtenerIdRolxNombre(lstRolesDelUsuario.SelectedItem.Text)
            oRolUsuario.idUsuario = BLL.usuarios.GetInstance.ObtenerIdPorEmail(lblUsuario.Text)

            Dim blRoles As New BLL.Roles





            If BLL.usuarios.GetInstance.QuitarRol(oRolUsuario.idUsuario, oRolUsuario.idRol) Then
                    'ok
                    regSuccess.Visible = True
                    regSuccess.Attributes("class") = "alert alert-success"
                    regSuccess.InnerText = "Rol Quitado !"
                regSuccess.Focus()
                lstRolesDelUsuario.Items.Clear()
                lstRolesSist.Items.Clear()

                Dim idusuario As Integer
                Dim lstRolesUsuario As List(Of BE.roles)
                Dim lstRolesSinAsignar As List(Of BE.roles)
                Dim bllRoles As New BLL.Roles


                idusuario = BLL.usuarios.GetInstance.ObtenerIdPorEmail(lblUsuario.Text)
                lstRolesUsuario = BLL.usuarios.GetInstance.CargarRolessDeUsuario(idusuario)

                For Each Rol As BE.roles In lstRolesUsuario
                    Me.lstRolesDelUsuario.Items.Add(Rol.nombre)
                Next

                lstRolesSinAsignar = bllRoles.CargarRolesSinAsignaraUsuario(idusuario)

                For Each item As BE.roles In lstRolesSinAsignar
                    Me.lstRolesSist.Items.Add(item.nombre)
                Next


            Else
                    regSuccess.Visible = True
                    regSuccess.Attributes("class") = "alert alert-danger"
                    regSuccess.InnerText = "Error al Quitar Roles !"
                    regSuccess.Focus()
                    'error
                End If




        End If

    End Sub
    Protected Sub btnAsign_Click(sender As Object, e As EventArgs) Handles btnAsign.Click
        If Me.lstRolesSist.SelectedItem Is Nothing Then
            regSuccess.Visible = True
            regSuccess.InnerText = "Debe seleccionar al menos 1 Rol"

        Else
            regSuccess.Visible = False
            Dim accesoRoles As New BLL.Roles
            Dim oRolUsuario As New BE.RolUsuario

            oRolUsuario.idRol = accesoRoles.ObtenerIdRolxNombre(lstRolesSist.SelectedItem.Text)
            oRolUsuario.idUsuario = BLL.usuarios.GetInstance.ObtenerIdPorEmail(lblUsuario.Text)

            Dim blRoles As New BLL.Roles

            If BLL.usuarios.GetInstance.AsignarRol(oRolUsuario.idUsuario, oRolUsuario.idRol) Then
                'ok
                regSuccess.Visible = True
                regSuccess.Attributes("class") = "alert alert-success"
                regSuccess.InnerText = "Rol Agregado !"
                regSuccess.Focus()
                lstRolesDelUsuario.Items.Clear()
                lstRolesSist.Items.Clear()

                Dim idusuario As Integer
                Dim lstRolesUsuario As List(Of BE.roles)
                Dim lstRolesSinAsignar As List(Of BE.roles)
                Dim bllRoles As New BLL.Roles


                idusuario = BLL.usuarios.GetInstance.ObtenerIdPorEmail(lblUsuario.Text)
                lstRolesUsuario = BLL.usuarios.GetInstance.CargarRolessDeUsuario(idusuario)

                For Each Rol As BE.roles In lstRolesUsuario
                    Me.lstRolesDelUsuario.Items.Add(Rol.nombre)
                Next

                lstRolesSinAsignar = bllRoles.CargarRolesSinAsignaraUsuario(idusuario)

                For Each item As BE.roles In lstRolesSinAsignar
                    Me.lstRolesSist.Items.Add(item.nombre)
                Next


            Else
                regSuccess.Visible = True
                regSuccess.Attributes("class") = "alert alert-danger"
                regSuccess.InnerText = "Error al Agregar Roles !"
                regSuccess.Focus()
                'error
            End If



        End If


    End Sub
End Class
