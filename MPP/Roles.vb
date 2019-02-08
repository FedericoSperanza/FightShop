Public Class Roles





    Public Function ObtenerDetalle(nombre As String) As String
        Dim oDatos As New DAL.BD
        Dim hdatos As New Hashtable
        Dim DS As New DataSet




        hdatos.Add("@Nombre", nombre)

        DS = oDatos.Leer("sp_SelectDetallePerm", hdatos)


        If DS.Tables(0).Rows.Count > 0 Then
            Dim detalle As String
            For Each item As DataRow In DS.Tables(0).Rows

                detalle = item(0)


            Next
            Return detalle
        Else
            Return Nothing

        End If


    End Function

    Public Function candelete(idrol As Integer) As Boolean
        Dim oDatos As New DAL.BD
        Dim hdatos As New Hashtable
        Dim DS As New DataSet




        hdatos.Add("@idrol", idrol)

        DS = oDatos.Leer("sp_Roles_CanDelete", hdatos)


        If DS.Tables(0).Rows.Count > 0 Then



            Return False
        Else
            Return True

        End If


    End Function





    Public Function ExisteUserActivoEnRol(idrolesconcat As String) As Boolean
        Dim oDatos As New DAL.BD
        Dim hdatos As New Hashtable
        Dim DS As New DataSet

        Dim lstroles As New List(Of BE.roles)



        hdatos.Add("@idRoles", idrolesconcat)

        DS = oDatos.Leer("sp_GetActiveUserRol", hdatos)


        If DS.Tables(0).Rows.Count > 0 Then
            Return True
        Else
            Return False


        End If


    End Function



    Public Function ObtenerFamiliasConEsePermiso(idPermiso As Integer, idrol As Integer) As List(Of BE.roles)
        Dim oDatos As New DAL.BD
        Dim hdatos As New Hashtable
        Dim DS As New DataSet

        Dim lstroles As New List(Of BE.roles)

        If Not idrol = Nothing Then
            hdatos.Add("@idRol", idrol)
            hdatos.Add("@idPermiso", idPermiso)


            DS = oDatos.Leer("sp_GetRolesWithPerm", hdatos)


            If DS.Tables(0).Rows.Count > 0 Then
                For Each item As DataRow In DS.Tables(0).Rows
                    lstroles.Add(ObtenerRolPorID(item(0)))


                Next
                Return lstroles


            End If


        Else
            hdatos.Add("@idPermiso", idPermiso)


            DS = oDatos.Leer("sp_GetRolesWithPerm2", hdatos)


            If DS.Tables(0).Rows.Count > 0 Then
                For Each item As DataRow In DS.Tables(0).Rows
                    lstroles.Add(ObtenerRolPorID(item(0)))


                Next
                Return lstroles

            End If
        End If


    End Function

    Public Function ObtenerCountPatenteEnOtrasFamilias(idPermiso As Integer, idrol As Integer) As Integer
        Dim oDatos As New DAL.BD
        Dim hdatos As New Hashtable
        Dim DS As New DataSet

        Dim count As Integer


        hdatos.Add("@idPermiso", idPermiso)
        hdatos.Add("@idRol", idrol)

        DS = oDatos.Leer("sp_GetCountRolPerm", hdatos)


        If DS.Tables(0).Rows.Count > 0 Then
            For Each item As DataRow In DS.Tables(0).Rows
                count = item(0)


            Next
            Return count
        Else
            Return Nothing

        End If


    End Function



    Public Function ObtenerCountPermisoeEnOtrosUsuarios(idPermiso As Integer, idusuario As Integer) As Integer
        Dim oDatos As New DAL.BD
        Dim hdatos As New Hashtable
        Dim DS As New DataSet

        Dim count As Integer


        hdatos.Add("@idPermiso", idPermiso)
        hdatos.Add("@idUsuario", idusuario)

        DS = oDatos.Leer("sp_GetCountUsuconPerm", hdatos)


        If DS.Tables(0).Rows.Count > 0 Then
            For Each item As DataRow In DS.Tables(0).Rows
                count = item(0)


            Next
            Return count
        Else
            Return Nothing

        End If


    End Function
    Public Function ObtenerIdPermisoxNombre(nombre As String) As Integer
        Dim oDatos As New DAL.BD
        Dim hdatos As New Hashtable
        Dim DS As New DataSet

        Dim Permiso As Integer


        hdatos.Add("@Nombre", nombre)

        DS = oDatos.Leer("sp_ObtenerIdPermisoxNombre", hdatos)


        If DS.Tables(0).Rows.Count > 0 Then
            For Each item As DataRow In DS.Tables(0).Rows
                Permiso = item(0)


            Next
            Return Permiso
        Else
            Return Nothing

        End If


    End Function







    Public Function ObtenerIdRolSinAsignarUsuario(idUsuario As Integer) As List(Of Integer)
        Dim oDatos As New DAL.BD
        Dim hdatos As New Hashtable
        Dim DS As New DataSet

        Dim listIds As New List(Of Integer)


        hdatos.Add("@ID", idUsuario)

        DS = oDatos.Leer("sp_RolSinAsignUsu", hdatos)


        If DS.Tables(0).Rows.Count > 0 Then
            For Each item As DataRow In DS.Tables(0).Rows
                listIds.Add(item("IDROL"))


            Next
            Return listIds
        Else
            Return Nothing

        End If


    End Function


    Public Function ObtenerIdPatenteSinAsignarRol(idRol As String) As List(Of Integer)
        Dim oDatos As New DAL.BD
        Dim hdatos As New Hashtable
        Dim DS As New DataSet

        Dim listIds As New List(Of Integer)


        hdatos.Add("@ID", idRol)

        DS = oDatos.Leer("sp_PateSinAsignRol", hdatos)


        If DS.Tables(0).Rows.Count > 0 Then
            For Each item As DataRow In DS.Tables(0).Rows
                listIds.Add(item("ID_PERMISO"))


            Next
            Return listIds
        Else
            Return Nothing

        End If


    End Function




    Public Function ObtenerIdRolxNombre(nombre As String) As Integer
        Dim oDatos As New DAL.BD
        Dim hdatos As New Hashtable
        Dim DS As New DataSet

        Dim Rol As Integer


        hdatos.Add("@Nombre", nombre)

        DS = oDatos.Leer("sp_ObtenerIdRolxNombre", hdatos)


        If DS.Tables(0).Rows.Count > 0 Then
            For Each item As DataRow In DS.Tables(0).Rows
                Rol = item(0)


            Next
            Return Rol
        Else
            Return Nothing

        End If


    End Function

    Function ObtenerRolPorID(idRol As Integer) As BE.roles
        Dim oDatos As New DAL.BD
        Dim hdatos As New Hashtable
        Dim DS As New DataSet

        Dim rol As New BE.roles


        hdatos.Add("@idRol", idRol)

        DS = oDatos.Leer("sp_SelecteRolesxID", hdatos)


        If DS.Tables(0).Rows.Count > 0 Then
            For Each item As DataRow In DS.Tables(0).Rows
                rol.id = item(0)
                rol.nombre = item(1)
                rol.descripcion = item(2)

            Next
            Return rol
        Else
            Return Nothing

        End If


    End Function






    Function obteneridPermisoPorRol(idRol As Integer) As List(Of Integer)

        Dim oDatos As New DAL.BD
        Dim hdatos As New Hashtable
        Dim DS As New DataSet
        Dim lstIds As New List(Of Integer)



        hdatos.Add("@idRol", idRol)

        DS = oDatos.Leer("sp_selectIdPermxRol", hdatos)


        If DS.Tables(0).Rows.Count > 0 Then
            For Each item As DataRow In DS.Tables(0).Rows
                lstIds.Add(item("IDPERMISO"))

            Next
            Return lstIds
        Else
            Return Nothing

        End If

    End Function



    Function insert_Permiso_Rol(idrol As Integer, idperm As Integer) As Boolean
        Dim oDatos As New DAL.BD
        Dim hdatos As New Hashtable
        Dim resultado As Integer

        hdatos.Add("@idrol", idrol)
        hdatos.Add("@idpermiso", idperm)

        resultado = oDatos.Escribir("sp_Create_RolPermiso", hdatos)

        Return resultado




    End Function


    ''aca
    Function Delete_Permiso_Rol(objRolPermiso As BE.RolPermiso) As Boolean
        Dim oDatos As New DAL.BD
        Dim hdatos As New Hashtable
        Dim resultado As Integer

        hdatos.Add("@IdRol", objRolPermiso.idrol)
        hdatos.Add("@IdPermiso", objRolPermiso.idpermiso)


        resultado = oDatos.Escribir("sp_DeletePermisoRol", hdatos)

        Return resultado




    End Function

    Function delete_rol(idrol As Integer) As Boolean
        Dim oDatos As New DAL.BD
        Dim hdatos As New Hashtable
        Dim resultado As Integer

        hdatos.Add("@IdRol", idrol)



        resultado = oDatos.Escribir("sp_DeleteRol", hdatos)

        Return resultado

    End Function





    Function Update_Permiso_Rol(idrol As Integer, idperm As Integer) As Boolean
        Dim oDatos As New DAL.BD
        Dim hdatos As New Hashtable
        Dim resultado As Integer

        hdatos.Add("@idrol", idrol)
        hdatos.Add("@idpermiso", idperm)



        resultado = oDatos.Escribir("sp_Update_RolPermiso", hdatos)

        Return resultado




    End Function

    Function CreateRol(objRol As BE.roles) As Integer
        Dim oDatos As New DAL.BD
        Dim hdatos As New Hashtable
        Dim resultado As Integer

        hdatos.Add("@Nombre", objRol.nombre)
        hdatos.Add("@Descripcion", objRol.descripcion)


        If oDatos.Escribir("sp_CreateRol", hdatos) Then
            Dim ds As New DataSet
            Dim hdatos2 As New Hashtable
            hdatos2.Add("@Nombre", objRol.nombre)
            ds = oDatos.Leer("sp_SelectIdRolxNombre", hdatos2)

            If ds.Tables(0).Rows.Count > 0 Then
                For Each item As DataRow In ds.Tables(0).Rows
                    resultado = item(0)
                Next



            End If


        End If

        Return resultado

    End Function






    Function UpdateRol(objRol As BE.roles, RolModif As String) As Integer
        Dim oDatos As New DAL.BD
        Dim hdatos As New Hashtable
        Dim resultado As Integer

        hdatos.Add("@Nombre", objRol.nombre)
        hdatos.Add("@Descripcion", objRol.descripcion)
        hdatos.Add("@NombreRolModif", RolModif.ToString)

        If oDatos.Escribir("sp_UpdateRol", hdatos) Then
            Dim ds As New DataSet
            Dim hdatos2 As New Hashtable
            hdatos2.Add("@Nombre", objRol.nombre)
            ds = oDatos.Leer("sp_SelectIdRolxNombre", hdatos2)

            If ds.Tables(0).Rows.Count > 0 Then
                For Each item As DataRow In ds.Tables(0).Rows
                    resultado = item(0)
                Next



            End If


        End If

        Return resultado

    End Function









    Function BuscarPermisoPorID(idPermiso As String) As BE.permisos

        Dim oDatos As New DAL.BD
        Dim hdatos As New Hashtable
        Dim DS As New DataSet

        Dim permiso As New BE.permisos


        hdatos.Add("@idPermiso", idPermiso)

        DS = oDatos.Leer("sp_SelectePermisosxID", hdatos)


        If DS.Tables(0).Rows.Count > 0 Then
            For Each item As DataRow In DS.Tables(0).Rows
                permiso.id = item(0)
                permiso.nombre = item(1)
                permiso.descripcion = item(2)
                permiso.url = item(3)
                permiso.tags = item(4)

            Next
            Return permiso
        Else
            Return Nothing

        End If


    End Function


    'Function ValidarRolPermiso(idPermiso As Integer) As Boolean

    '    Dim oDatos As New DAL.BD
    '    Dim hdatos As New Hashtable
    '    Dim DS As New DataSet

    '    Dim permiso As New BE.permisos


    '    hdatos.Add("@idPermiso", idPermiso)

    '    DS = oDatos.Leer("sp_SelectePermisosxID", hdatos)


    '    If DS.Tables(0).Rows.Count > 0 Then
    '        For Each item As DataRow In DS.Tables(0).Rows
    '            permiso.id = item(0)
    '            permiso.nombre = item(1)
    '            permiso.descripcion = item(2)
    '            permiso.url = item(3)
    '        Next
    '        Return permiso
    '    Else
    '        Return Nothing

    '    End If


    'End Function




    Function ListarPermisos() As List(Of BE.permisos)

        Dim oDatos As New DAL.BD
        Dim hdatos As New Hashtable
        Dim DS As New DataSet
        Dim oPermiso As BE.permisos
        Dim lstPermisos As New List(Of BE.permisos)




        DS = oDatos.Leer("sp_ListPermisos", hdatos)


        If DS.Tables(0).Rows.Count > 0 Then
            For Each item As DataRow In DS.Tables(0).Rows
                oPermiso = New BE.permisos
                oPermiso.id = item("ID_PERMISO")
                oPermiso.nombre = item("NOMBRE")
                oPermiso.descripcion = item("DESCRIPCION")
                oPermiso.url = item("URL")
                oPermiso.tags = item("tags")
                lstPermisos.Add(oPermiso)
            Next
            Return lstPermisos
        Else
            Return Nothing

        End If




    End Function


    Function ListarPermisosPublicos() As List(Of BE.permisos)

        Dim oDatos As New DAL.BD
        Dim hdatos As New Hashtable
        Dim DS As New DataSet
        Dim oPermiso As BE.permisos
        Dim lstPermisos As New List(Of BE.permisos)




        DS = oDatos.Leer("sp_ListPermisosPublicos", hdatos)


        If DS.Tables(0).Rows.Count > 0 Then
            For Each item As DataRow In DS.Tables(0).Rows
                oPermiso = New BE.permisos
                oPermiso.id = item("ID_PERMISO")
                oPermiso.nombre = item("NOMBRE")
                oPermiso.descripcion = item("DESCRIPCION")
                oPermiso.url = item("URL")
                oPermiso.tags = item("tags")
                lstPermisos.Add(oPermiso)
            Next
            Return lstPermisos
        Else
            Return Nothing

        End If




    End Function


    Function ListarRoles() As List(Of BE.roles)

        Dim oDatos As New DAL.BD
        Dim hdatos As New Hashtable
        Dim DS As New DataSet
        Dim oRol As BE.roles
        Dim lstRoles As New List(Of BE.roles)




        DS = oDatos.Leer("sp_ListarRoles", hdatos)


        If DS.Tables(0).Rows.Count > 0 Then
            For Each item As DataRow In DS.Tables(0).Rows
                oRol = New BE.roles
                oRol.id = item("IDROL")
                oRol.nombre = item("NOMBRE")
                oRol.descripcion = item("DESCRIPCION")
                lstRoles.Add(oRol)
            Next
            Return lstRoles
        Else
            Return Nothing

        End If




    End Function







End Class
