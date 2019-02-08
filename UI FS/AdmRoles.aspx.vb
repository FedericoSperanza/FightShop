
Partial Class AdmRoles
    Inherits System.Web.UI.Page
    Dim oRolBL As New BLL.Roles



    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not (Page.IsPostBack) Then

            CargarPagina()

        End If
    End Sub



    Public Sub CargarPagina()
        ''Valido si puede acceder al modulo de administracion
        Dim idPermAdm = BLL.usuarios.GetInstance.GetidPermByUrl("AdmRoles.aspx")


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

        'REINICIA EL CHECKBOX
        'For Each item In lstPermissions.Items
        '    If item.Selected = True Then

        '        item.selected = False



        '    End If

        'Next

        Me.GV_Roles.DataSource = oRolBL.ListarRoles
        Me.GV_Roles.DataBind()

        Dim dsPermisos = New BLL.Roles
        'Me.lstPermissions.DataSource = dsPermisos.ListarPermisos
        'Me.lstPermissions.DataBind()
        txtDescription.ReadOnly = True
        txtNombre.ReadOnly = True



    End Sub







    Protected Sub GV_Roles_SelectedIndexChanging(sender As Object, e As GridViewSelectEventArgs) Handles GV_Roles.SelectedIndexChanging

        'REINICIA EL CHECKBOX
        'For Each item In lstPermissions.Items
        '    If item.Selected = True Then

        '        item.selected = False



        '    End If

        'Next

        txtDescription.ReadOnly = False
        txtNombre.ReadOnly = False

        txtNombre.Text = Me.GV_Roles.Rows(e.NewSelectedIndex).Cells(2).Text
        txtDescription.Text = Me.GV_Roles.Rows(e.NewSelectedIndex).Cells(3).Text

        Session("RolModif") = Me.GV_Roles.Rows(e.NewSelectedIndex).Cells(2).Text






        Dim idRol As Integer
        Dim blRol As New BLL.Roles
        Dim oRol As New BE.roles
        idRol = blRol.ObtenerIdRolxNombre(txtNombre.Text)


        oRol = blRol.BuscarRolesConPermisos(idRol)

        If oRol IsNot Nothing Then


            For Each permiso As BE.permisos In oRol.permisos
                Dim stringValue As String = permiso.nombre
                'Me.lstPermissions.Items.FindByText(Convert.ToString(stringValue)).Selected = True


            Next

        End If





    End Sub
    Protected Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        txtNombre.Text = ""
        txtDescription.Text = ""
        Session("FlagNew") = 1
        txtDescription.ReadOnly = False
        txtNombre.ReadOnly = False

        'REINICIA EL CHECKBOX
        'For Each item In lstPermissions.Items
        '    If item.Selected = True Then

        '        item.selected = False



        '    End If

        'Next

    End Sub

    Protected Sub GV_Roles_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GV_Roles.PageIndexChanging
        Me.GV_Roles.PageIndex = e.NewPageIndex
        With Me.GV_Roles
            .DataSource = oRolBL.ListarRoles()
            .DataBind()
        End With
    End Sub
    Protected Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        'Dim item As ListItem
        Dim blRol As New BLL.Roles
        Dim lstRolesChecked As New List(Of Integer)
        '  Dim flagCheckbox As Boolean




        'For Each item In lstPermissions.Items
        '    If item.Selected = True Then
        '        flagCheckbox = 1

        '        ''Se llena una lista con los ID de los Permisos
        '        lstRolesChecked.Add(blRol.ObtenerIdPermisoxNombre(item.Text))



        '    End If

        'Next
        ''Aca estaria ya la lista de ID de permisos ya cargada en su totalidad


        '  If flagCheckbox = True Then



        If Session("FlagNew") = 1 Then
            ''Si el flag de creacion de rol esta en 1 entonces se ejecuta la creacion

            Dim objRol As New BE.roles



            objRol.nombre = txtNombre.Text
            objRol.descripcion = txtDescription.Text

            ''Primero se crea el ROL
            'Un parametro que es CreateRol, crea el Rol y ademas devuelve el ID del rol Creado
            Dim idRol As Integer
            idRol = blRol.CreateRol(objRol)

            'For Each idPermiso As Integer In lstRolesChecked

            '    'Se inserta uno por uno en tabla ROL-PERMISO

            '    blRol.Insert_Permiso_Rol(idRol, idPermiso)

            'Next



            txtNombre.Text = ""
            txtDescription.Text = ""


            Session("FlagNew") = 0

            'Redireccion a asignacion de roles

            Session("CreaRol") = 1
            Dim bitacoraBL As New BLL.Bitacora
            bitacoraBL.GuardarINFOEnBitacora(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), Session("MailUser"), "Creacion de Rol")

            Session("RolCreado") = objRol.nombre
            Response.AddHeader("REFRESH", "1;URL=RolPermiso.aspx")





        Else
            'ACA SERIA UN UPDATE DE ALGUN ROL EN PARTICULAR



            Dim objRol As New BE.roles




            objRol.nombre = txtNombre.Text
            objRol.descripcion = txtDescription.Text

            ''Primero se crea el ROL

            ''Borra los actuales
            ' blRol.Delete_Permiso_Rol(objRol)

            blRol.UpdateRol(objRol, Session("RolModif"))
            'For Each idPermiso As Integer In lstRolesChecked

            'Se UPDATEA uno por uno en tabla ROL-PERMISO
            'Un parametro que es UpdateRol, updatea el Rol y ademas devuelve el ID del updateado Creado
            ' blRol.Update_Permiso_Rol(idRolupd, idPermiso)

            ' Next



            txtNombre.Text = ""
            txtDescription.Text = ""
            Dim bitacoraBL As New BLL.Bitacora
            bitacoraBL.GuardarINFOEnBitacora(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), Session("MailUser"), "Modificacion de Rol")

            Session("RolModif") = Nothing



        End If
        CargarPagina()

        '  End If



    End Sub














    Protected Sub GV_Roles_RowDeleting(sender As Object, e As GridViewDeleteEventArgs) Handles GV_Roles.RowDeleting
        Dim blRol As New BLL.Roles
        'Obtengo el ID

        If blRol.candelete(blRol.ObtenerIdRolxNombre(Me.GV_Roles.Rows(e.RowIndex).Cells(2).Text)) = True Then
            blRol.Delete_Rol(blRol.ObtenerIdRolxNombre(Me.GV_Roles.Rows(e.RowIndex).Cells(2).Text))
            regSuccess.Visible = True
                regSuccess.Attributes("class") = "alert alert-success"
                regSuccess.InnerText = "Rol Borrado!"



                CargarPagina()


        Else
            'no se puede, usuarios activos
            regSuccess.Visible = True
            regSuccess.Attributes("class") = "alert alert-danger"
            regSuccess.InnerText = "No se puede Borrar Rol!"

            Return


        End If



    End Sub
End Class
