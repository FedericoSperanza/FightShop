Public Class Roles

    Public Function BuscarRolesConPermisos(idRol As Integer) As BE.roles

        Dim rolesBL As New BLL.Roles
        Dim roles As New BE.roles
        Dim lstpermisos As New List(Of BE.permisos)

        Dim mpRol As New MPP.Roles


        roles = mpRol.ObtenerRolPorID(idRol)


        lstpermisos = CompletarPermisosDeRoles(roles.id)

        roles.permisos = lstpermisos

        Return roles

    End Function

    Function Delete_Rol(idRol) As Boolean
        Dim mprol As New MPP.Roles

        Return mprol.delete_rol(idRol)

    End Function


    Function candelete(idrol As Integer) As Boolean
        Dim mprol As New MPP.Roles

        Return mprol.candelete(idrol)


    End Function





    Function VerificarUsoPermiso(idPermiso As Integer, idrol As Integer) As Boolean
        Dim mprol As New MPP.Roles
        Dim listidpermisosreturn As New List(Of Integer)

        ''busco el permiso que se esta quitando, si esta usado por otro Rol
        If Not idrol = Nothing Then
            If Not VerificarPatenteEsUsada(idPermiso, idrol) Then
                listidpermisosreturn.Add(idPermiso)
            Else
                Dim listroles As New List(Of BE.roles)
                ''obtengo los roles que tiene el permiso
                listroles = verificarRolUsaPermiso(idPermiso, idrol)

                'me fijo si esos roles tienen asignados usuarios
                If Not (existeusuarioenRol(listroles)) Then
                    listidpermisosreturn.Add(idPermiso)
                End If

            End If

        End If


        If (listidpermisosreturn.Count > 0) Then
            For Each idPat As Integer In listidpermisosreturn
                Dim lstRoles As New List(Of BE.roles)

                lstRoles = verificarRolUsaPermiso(idPat, idrol)
                'tengo las famlias que tienen esas patentes, ahora verifico si algun otro usuario tiene esa flia asignada
                If (lstRoles IsNot Nothing) Then
                    If lstRoles.Count > 0 Then

                        If Not (existeusuarioenRol(lstRoles)) Then
                            Return False
                        End If
                    Else
                        Return False
                    End If
                Else
                    Return False

                End If
            Next
        End If


        Return True


    End Function

    Function existeusuarioenRol(listRoles As List(Of BE.roles)) As Boolean

        Dim accesosMP As New MPP.Roles
        Dim idRolesConcat As String = Nothing

        For Each item In listRoles
            idRolesConcat += Convert.ToString(item.id) & ", "
        Next

        idRolesConcat = idRolesConcat.Substring(0, idRolesConcat.Length - 2)

        Return accesosMP.ExisteUserActivoEnRol(idRolesConcat)


    End Function

    Function verificarRolUsaPermiso(idPermiso As Integer, Optional idrol As Integer = Nothing) As List(Of BE.roles)

        Dim accesroles As New MPP.Roles
        Dim lstRoles As New List(Of BE.roles)

        lstRoles = accesroles.ObtenerFamiliasConEsePermiso(idPermiso, idrol)

        Return lstRoles
    End Function



    Function VerificarPatenteEsUsada(idPermiso As Integer, idrol As Integer) As Boolean

        Dim accesoroles As New MPP.Roles

        If (accesoroles.ObtenerCountPatenteEnOtrasFamilias(idPermiso, idrol) > 0) Then
            Return True
        Else
            Return False
        End If

    End Function

    Function VerificarPatenteEsUsada2(idPermiso As Integer, idUsuario As Integer) As Boolean

        Dim accesoroles As New MPP.Roles

        If (accesoroles.ObtenerCountPermisoeEnOtrosUsuarios(idPermiso, idUsuario) > 0) Then
            Return True
        Else
            Return False
        End If

    End Function



    Function CargarRolesSinAsignaraUsuario(idUsuario As Integer) As List(Of BE.roles)

        Dim mppRol As New MPP.Roles
        Dim mpp2Rol As New MPP.Roles
        Dim listRolesReturn As New List(Of BE.roles)
        Dim listidRoles As New List(Of Integer)

        listidRoles = mppRol.ObtenerIdRolSinAsignarUsuario(idUsuario)

        If listidRoles IsNot Nothing Then



            For Each id As Integer In listidRoles
                Dim Roles As New BE.roles

                Roles = mpp2Rol.ObtenerRolPorID(Convert.ToString(id))
                listRolesReturn.Add(Roles)
            Next
            Return listRolesReturn
        Else
            Return listRolesReturn

        End If




    End Function


    Function ObtenerPatentesSinAsignarPorRol(idRol As Integer) As List(Of BE.permisos)

        Dim mppRol As New MPP.Roles
        Dim mpp2Rol As New MPP.Roles
        Dim listPatenteReturn As New List(Of BE.permisos)
        Dim listIdsPatente As New List(Of Integer)

        listIdsPatente = mppRol.ObtenerIdPatenteSinAsignarRol(idRol)

        If listIdsPatente IsNot Nothing Then



            For Each id As Integer In listIdsPatente
                Dim patente As New BE.permisos

                patente = mpp2Rol.BuscarPermisoPorID(Convert.ToString(id))
                listPatenteReturn.Add(patente)
            Next
            Return listPatenteReturn
        Else
            Return listPatenteReturn

        End If




    End Function






    Private Function CompletarPermisosDeRoles(idRol As Integer) As List(Of BE.permisos)

        Dim listPatentes As New List(Of BE.permisos)

        listPatentes = CargarpermisosPorRoles(idRol)

        Return listPatentes




    End Function



    Public Function ObtenerDetalle(nombre As String) As String
        Dim mprol As New MPP.Roles

        Return mprol.ObtenerDetalle(nombre)


    End Function

    Public Function ObtenerIdPermisoxNombre(nombre As String) As Integer
        Dim mprol As New MPP.Roles

        Return mprol.ObtenerIdPermisoxNombre(nombre)


    End Function

    Public Function ObtenerIdRolxNombre(nombre As String) As Integer
        Dim mprol As New MPP.Roles

        Return mprol.ObtenerIdRolxNombre(nombre)


    End Function




    Public Function ListarPermisos() As List(Of BE.permisos)
        Dim mpPermisos As New MPP.Roles

        Return mpPermisos.ListarPermisos



    End Function



    Public Function ListarPermisosPublicos() As List(Of BE.permisos)
        Dim mpPermisos As New MPP.Roles

        Return mpPermisos.ListarPermisosPublicos



    End Function


    Public Function CargarpermisosPorRoles(ByVal idRol As Integer) As List(Of BE.permisos)

        Dim mpRoles As New MPP.Roles

        Dim listPatenteReturn As New List(Of BE.permisos)
        Dim listIdsPermisos As List(Of Integer)

        listIdsPermisos = mpRoles.obteneridPermisoPorRol(idRol)

        If listIdsPermisos IsNot Nothing Then


            For Each id As Integer In listIdsPermisos
                Dim permiso As New BE.permisos

                If mpRoles.BuscarPermisoPorID(Convert.ToString(id)) IsNot Nothing Then
                    permiso = mpRoles.BuscarPermisoPorID(Convert.ToString(id))
                    listPatenteReturn.Add(permiso)
                End If



            Next
        End If

        Return listPatenteReturn
    End Function






    Public Function CreateRol(objRol As BE.roles) As Integer
        Dim mpRol As New MPP.Roles

        Return mpRol.CreateRol(objRol)

    End Function



    Public Function UpdateRol(objRol As BE.roles, RolModif As String) As Integer
        Dim mpRol As New MPP.Roles

        Return mpRol.UpdateRol(objRol, RolModif)

    End Function



    Public Function Delete_Permiso_Rol(objRolPermiso As BE.RolPermiso) As Boolean
        Dim mpRol As New MPP.Roles

        Return mpRol.Delete_Permiso_Rol(objRolPermiso)

    End Function

    Public Function Update_Permiso_Rol(idRol As Integer, idPermiso As Integer) As Boolean
        Dim mpRol As New MPP.Roles

        Return mpRol.Update_Permiso_Rol(idRol, idPermiso)

    End Function




    Public Function Insert_Permiso_Rol(idRol As Integer, idPermiso As Integer) As Boolean

        Dim mpRol As New MPP.Roles


        Return mpRol.insert_Permiso_Rol(idRol, idPermiso)


    End Function






    Public Function ListarRoles() As List(Of BE.roles)

        Dim lstRoles As New List(Of BE.roles)
        Dim oMapper As New MPP.Roles

        lstRoles = oMapper.ListarRoles()

        Return lstRoles

    End Function



End Class
