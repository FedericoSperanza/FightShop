
Partial Class RolPermiso
    Inherits System.Web.UI.Page
    Dim oRolBL As New BLL.Roles

    'todo EN EL DELETE VALIDAR QUE EL PERMISO ESTE ASGINADO A UN ROL Y POR CONSIGUIENTE ESE ROL A UN USUARIO
    'ANTES DE ELIMINARLO
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not (Page.IsPostBack) Then
            ''Carga de Roles en DropDown
            ddRoles.DataSource = oRolBL.ListarRoles
            ddRoles.DataBind()

            If Session("CreaRol") = 1 Then
                ddRoles.Enabled = False
                ddRoles.Text = Session("RolCreado")
            End If


            Cargarpagina()

        End If
    End Sub



    Public Sub Cargarpagina()
        ''Valido si puede acceder al modulo de administracion
        Dim idPermAdm = BLL.usuarios.GetInstance.GetidPermByUrl("RolPermiso.aspx")


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

        Dim oRol As New BE.roles
        Dim listPermisosSistema As New List(Of BE.permisos)
        Dim blRol As New BLL.Roles
        If Session("CreaRol") = 1 Then

            Dim idRol As Integer = blRol.ObtenerIdRolxNombre(Session("RolCreado"))

            oRol = blRol.BuscarRolesConPermisos(idRol)
            listPermisosSistema = blRol.ObtenerPatentesSinAsignarPorRol(idRol)

            For Each permiso As BE.permisos In oRol.permisos
                Me.lstPermisosRol.Items.Add(permiso.nombre)
            Next

            For Each permiso As BE.permisos In listPermisosSistema
                Me.lstPermisosSist.Items.Add(permiso.nombre)
            Next

        Else
            lstPermisosSist.Items.Clear()
            lstPermisosRol.Items.Clear()

            Dim ooRol As New BE.roles
            Dim listtPermisosSistema As New List(Of BE.permisos)
            Dim blllRol As New BLL.Roles

            Dim idRol As Integer = blRol.ObtenerIdRolxNombre(ddRoles.SelectedItem.Text)

            oRol = blRol.BuscarRolesConPermisos(idRol)
            listPermisosSistema = blRol.ObtenerPatentesSinAsignarPorRol(idRol)

            For Each permiso As BE.permisos In oRol.permisos
                Me.lstPermisosRol.Items.Add(permiso.nombre)
            Next

            For Each permiso As BE.permisos In listPermisosSistema
                Me.lstPermisosSist.Items.Add(permiso.nombre)
            Next




        End If





    End Sub
    Protected Sub ddRoles_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddRoles.SelectedIndexChanged
        lstPermisosSist.Items.Clear()
        lstPermisosRol.Items.Clear()

        Dim oRol As New BE.roles
        Dim listPermisosSistema As New List(Of BE.permisos)
        Dim blRol As New BLL.Roles

        Dim idRol As Integer = blRol.ObtenerIdRolxNombre(ddRoles.SelectedItem.Text)

        oRol = blRol.BuscarRolesConPermisos(idRol)
            listPermisosSistema = blRol.ObtenerPatentesSinAsignarPorRol(idRol)

            For Each permiso As BE.permisos In oRol.permisos
                Me.lstPermisosRol.Items.Add(permiso.nombre)
            Next

            For Each permiso As BE.permisos In listPermisosSistema
                Me.lstPermisosSist.Items.Add(permiso.nombre)
            Next


    End Sub

    Protected Sub btnAsign_Click(sender As Object, e As EventArgs) Handles btnAsign.Click


        If Session("CreaRol") = 1 Then
            ''Si esta creandorol por redireccion de la otra web
            'entonces utiliza los valores proporcionados por la variable de sesion
            'recordar de poner en 0 las variables de sesion o nothing
            If Me.lstPermisosSist.SelectedItem Is Nothing Then

                regSuccess.Visible = True
                regSuccess.InnerText = "Debe seleccionar al menos 1 permiso"

            Else
                regSuccess.Visible = False
                Dim bllroles As New BLL.Roles
                Dim oRolPermiso As New BE.RolPermiso
                oRolPermiso.idpermiso = bllroles.ObtenerIdPermisoxNombre(lstPermisosSist.SelectedItem.Text)
                oRolPermiso.idrol = bllroles.ObtenerIdRolxNombre(Session("RolCreado"))



                If bllroles.Insert_Permiso_Rol(oRolPermiso.idrol, oRolPermiso.idpermiso) Then
                    Dim bitacoraBL As New BLL.Bitacora
                    bitacoraBL.GuardarINFOEnBitacora(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), Session("MailUser"), "Asignacion de Permisos")
                    Session("CreaRol") = 0

                    Cargarpagina()

                    ddRoles.Enabled = True

                End If

            End If

        Else
            'por el lado de modificacion de existentes
            If Me.lstPermisosSist.SelectedItem Is Nothing Then

                regSuccess.Visible = True
                regSuccess.InnerText = "Debe seleccionar al menos 1 permiso"

            Else
                regSuccess.Visible = False
                Dim accesoroles As New BLL.Roles
                Dim obRolPermiso As New BE.RolPermiso
                obRolPermiso.idpermiso = accesoroles.ObtenerIdPermisoxNombre(lstPermisosSist.SelectedItem.Text)
                obRolPermiso.idrol = accesoroles.ObtenerIdRolxNombre(ddRoles.SelectedItem.Text)



                If accesoroles.Insert_Permiso_Rol(obRolPermiso.idrol, obRolPermiso.idpermiso) Then
                    Dim bitacoraBL As New BLL.Bitacora
                    bitacoraBL.GuardarINFOEnBitacora(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), Session("MailUser"), "Asignacion de Permisos")
                    Cargarpagina()


                End If



            End If


        End If






    End Sub
    Protected Sub btnDesAsgin_Click(sender As Object, e As EventArgs) Handles btnDesAsgin.Click
        If Me.lstPermisosRol.SelectedItem Is Nothing Then

            regSuccess.Visible = True
            regSuccess.InnerText = "Debe seleccionar al menos 1 permiso"

        Else
            regSuccess.Visible = False
            Dim accesoroles As New BLL.Roles
            Dim obRolPermiso As New BE.RolPermiso
            obRolPermiso.idpermiso = accesoroles.ObtenerIdPermisoxNombre(lstPermisosRol.SelectedItem.Text)
            obRolPermiso.idrol = accesoroles.ObtenerIdRolxNombre(ddRoles.SelectedItem.Text)



            '  If accesoroles.Insert_Permiso_Rol(obRolPermiso.idrol, obRolPermiso.idpermiso) Then
            Dim accesRolPerm As New BLL.Roles

                ''Valido si el permiso esta asignado a algun ROL
                If accesRolPerm.VerificarUsoPermiso(obRolPermiso.idpermiso, obRolPermiso.idrol) = True Then
                    If accesRolPerm.Delete_Permiso_Rol(obRolPermiso) Then
                        Dim bitacoraBL As New BLL.Bitacora
                        bitacoraBL.GuardarINFOEnBitacora(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), Session("MailUser"), "DesAsignacion de Permisos")

                        Cargarpagina()


                    End If

                Else

                    regSuccess.Visible = True
                    regSuccess.InnerText = "No se puede quitar Permiso debido a que quedaria un menu inaccesible"

                End If









            '    End If



        End If
    End Sub
    Protected Sub lstPermisosSist_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstPermisosSist.SelectedIndexChanged
        Dim blARoles As New BLL.Roles
        lblDetallePermiso.Text = blARoles.ObtenerDetalle(lstPermisosSist.SelectedItem.Text)
    End Sub


    Protected Sub lstPermisosRol_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstPermisosRol.SelectedIndexChanged
        Dim blARoles As New BLL.Roles
        lblDetallePermiso.Text = blARoles.ObtenerDetalle(lstPermisosRol.SelectedItem.Text)
    End Sub





End Class
