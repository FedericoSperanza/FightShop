Public Class usuarios



    Private Sub New()  ''SINGLETON IDEM ABAJO

    End Sub


    Private Shared _instancia As MPP.usuarios   ''singleton

    Public Shared Function GetInstance() As MPP.usuarios

        If _instancia Is Nothing Then

            _instancia = New MPP.usuarios

        End If

        Return _instancia
    End Function


    Public Function getAllForNewsletterNotUsers() As List(Of String)
        Dim h As New Hashtable
        Dim odatos As New DAL.BD
        Dim ds = odatos.Leer("sp_Notusuarios_GetAllForNewsletter", h)
        Dim lstuser As New List(Of String)
        Dim mail As String

        If ds.Tables(0).Rows.Count > 0 Then
            For Each item As DataRow In ds.Tables(0).Rows

                mail = item("email")
                lstuser.Add(mail)
            Next
            Return lstuser
        Else
            Return Nothing

        End If
    End Function


    Public Function getAllForNewsletter() As List(Of BE.usuarios)
        Dim h As New Hashtable
        Dim odatos As New DAL.BD
        Dim ds = odatos.Leer("sp_usuarios_GetAllForNewsletter", h)
        Dim lstuser As New List(Of BE.usuarios)
        Dim ouser As BE.usuarios

        If ds.Tables(0).Rows.Count > 0 Then
            For Each item As DataRow In ds.Tables(0).Rows
                ouser = New BE.usuarios
                ouser.user = item("usuario")
                lstuser.Add(ouser)
            Next
            Return lstuser
        Else
            Return Nothing

        End If
    End Function




    Function HabilitaPermiso(idPerm As Integer) As Boolean

        Dim oDatos As New DAL.BD
        Dim hdatos As New Hashtable
        Dim DS As New DataSet
        Dim wasTrue As Boolean = False
        Dim resultado As Boolean

        For Each item As BE.roles In BE.GlobalUsuario.usuarioConectado.roles
            'RolID += item.id & ","
            hdatos.Add("@idPermiso", idPerm)
            hdatos.Add("@idRol", item.id)

            DS = oDatos.Leer("sp_CheckPermisos", hdatos)


            If DS.Tables(0).Rows.Count > 0 Then

                wasTrue = True

                resultado = True
                hdatos.Clear()
            Else
                If wasTrue = False Then
                    resultado = False
                    hdatos.Clear()
                End If

            End If
        Next

        Return resultado




    End Function




    Public Function SetSubscribed(iduser As Integer, suscribed As Integer) As Boolean

        Dim oDatos As New DAL.BD
        Dim hdatos As New Hashtable
        Dim resultado As Integer

        hdatos.Add("@iduser", iduser)
        hdatos.Add("@suscribed", suscribed)


        resultado = oDatos.Escribir("sp_User_Suscribe", hdatos)

        Return resultado






    End Function

    Public Function UpdateUser(objuser As BE.usuarios, usermodif As String) As Boolean

        Dim oDatos As New DAL.BD
        Dim hdatos As New Hashtable
        Dim resultado As Integer

        hdatos.Add("@Email", objuser.user)
        hdatos.Add("@Nombre", objuser.nombre)
        hdatos.Add("@Apellido", objuser.apellido)
        hdatos.Add("@Telefono", objuser.telefono)


        resultado = oDatos.Escribir("sp_UpdateUser", hdatos)

        Return resultado






    End Function



    Public Function Bloquear_Desbloquear(user As Integer, estado As Boolean) As Boolean

        Dim oDatos As New DAL.BD
        Dim hdatos As New Hashtable
        Dim resultado As Integer

        hdatos.Add("@id", user)
        hdatos.Add("@Estado", estado)



        resultado = oDatos.Escribir("sp_EnableDisableUser", hdatos)

        Return resultado






    End Function
    Public Function DeleteUser(iduser As Integer) As Boolean

        Dim oDatos As New DAL.BD
        Dim hdatos As New Hashtable
        Dim resultado As Integer

        hdatos.Add("@idUser", iduser)


        resultado = oDatos.Escribir("sp_DeleteUser", hdatos)

        Return resultado





    End Function

    Public Function QuitarRol(iduser As Integer, idrol As Integer) As Boolean

        Dim oDatos As New DAL.BD
        Dim hdatos As New Hashtable
        Dim resultado As Integer

        hdatos.Add("@idUser", iduser)
        hdatos.Add("@idRol", iduser)

        resultado = oDatos.Escribir("sp_DeleteUsuRol", hdatos)

        Return resultado





    End Function




    Public Function AsignarRol(iduser As Integer, idrol As Integer) As Boolean

        Dim oDatos As New DAL.BD
        Dim hdatos As New Hashtable
        Dim resultado As Integer

        hdatos.Add("@idUser", iduser)
        hdatos.Add("@idRol", iduser)

        resultado = oDatos.Escribir("sp_AddUsuRol", hdatos)

        Return resultado




    End Function


    Public Function GetidPermByUrl(url As String) As Integer
        Dim oDatos As New DAL.BD
        Dim hdatos As New Hashtable
        Dim DS As New DataSet

        Dim Permiso As Integer


        hdatos.Add("@Url", url)

        DS = oDatos.Leer("sp_GetidPermByUrl", hdatos)


        If DS.Tables(0).Rows.Count > 0 Then
            For Each item As DataRow In DS.Tables(0).Rows
                Permiso = item(0)


            Next
            Return Permiso
        Else
            Return Nothing

        End If


    End Function





    Public Function GetMailById(id As Integer) As String
        Dim oDatos As New DAL.BD
        Dim hdatos As New Hashtable
        Dim DS As New DataSet

        Dim mail As String


        hdatos.Add("@idUsuario", id)

        DS = oDatos.Leer("sp_Usuarios_GetMailById", hdatos)


        If DS.Tables(0).Rows.Count > 0 Then
            For Each item As DataRow In DS.Tables(0).Rows
                mail = item(0)


            Next
            Return mail
        Else
            Return Nothing

        End If


    End Function







    Function ObtenerIdsRolessDeUsuario(idUsuario As Integer) As List(Of Integer)

        Dim oDatos As New DAL.BD
        Dim hdatos As New Hashtable
        Dim DS As New DataSet
        Dim lstRoles As New List(Of Integer)



        hdatos.Add("@idUsuario", idUsuario)

        DS = oDatos.Leer("sp_obtRolesUsuario", hdatos)


        If DS.Tables(0).Rows.Count > 0 Then
            For Each item As DataRow In DS.Tables(0).Rows
                lstRoles.Add(item(0))




            Next


            Return lstRoles
        Else
            Return Nothing

        End If

    End Function






    Public Function ListAllUsers() As List(Of BE.usuarios)


        Dim oDatos As New DAL.BD
        Dim hdatos As New Hashtable
        Dim DS As New DataSet
        Dim oUsuarios As BE.usuarios
        Dim lstusuarios As New List(Of BE.usuarios)


        DS = oDatos.Leer("sp_Usuarios_ListAll", hdatos)

        If DS.Tables(0).Rows.Count > 0 Then
            For Each item As DataRow In DS.Tables(0).Rows
                oUsuarios = New BE.usuarios
                oUsuarios.user = item("Usuario")
                oUsuarios.nombre = item("Nombre")
                oUsuarios.apellido = item("Apellido")
                oUsuarios.telefono = item("Telefono")
                oUsuarios.flag = item("Flag")

                lstusuarios.Add(oUsuarios)

            Next
            Return lstusuarios
        Else
            Return Nothing

        End If

    End Function




    Public Function ResetPass(ByVal mail As String)

        Dim oDatos As New DAL.BD
        Dim hdatos As New Hashtable
        Dim DS As New DataSet
        Dim oUsu As New BE.usuarios

        hdatos.Add("@uname", mail)

        DS = oDatos.Leer("sp_resetpass1", hdatos)



        If DS.Tables(0).Rows.Count > 0 Then

            Return True
        Else
            Return False

        End If

    End Function


    Public Function LogIn(ByVal mail As String, ByVal pw As String) As BE.usuarios

        Dim oDatos As New DAL.BD
        Dim hdatos As New Hashtable
        Dim DS As New DataSet
        Dim oUsu As New BE.usuarios

        hdatos.Add("@uname", mail)
        hdatos.Add("@pass", pw)
        DS = oDatos.Leer("sp_login", hdatos)

        ''Validacion de Lectura de Filas
        ' Y posterior asignacion a un objeto de esas filas obtenidas
        'En caso de necesitar solo validar y no traer resultados
        'Se usa if DS.Tables(0).Rows.Count > 0

        If DS.Tables(0).Rows.Count > 0 Then
            For Each item As DataRow In DS.Tables(0).Rows
                oUsu = New BE.usuarios
                oUsu.id = item("ID")
                oUsu.user = item("USUARIO")
                oUsu.pass = item("PASSWORD")
                oUsu.contador = item("CONTADOR")
                oUsu.flag = item("FLAG")
                oUsu.telefono = item("TELEFONO")
                oUsu.nombre = item("NOMBRE")
                oUsu.apellido = item("APELLIDO")
                oUsu.primerlogin = item("PRIMERLOGIN")
                oUsu.flagNewsLetter = item("NEWSLETTER")

            Next
            Return oUsu
        Else
            Return Nothing

        End If

    End Function






    Public Function GuardarNuevaContraseña(ByVal userencrypt As String, ByVal pw As String) As Boolean
        Dim oDatos As New DAL.BD
        Dim hdatos As New Hashtable
        Dim resultado As Integer

        hdatos.Add("@User", userencrypt)
        hdatos.Add("@Pass", pw)


        resultado = oDatos.Escribir("sp_ResetPass2", hdatos)


        Return resultado

    End Function




    Public Function CrearNuevo(ByVal obj As BE.usuarios) As Boolean
        Dim oDatos As New DAL.BD
        Dim hdatos As New Hashtable
        Dim resultado As Integer

        hdatos.Add("@UserName", obj.user)
        hdatos.Add("@Password", obj.pass)
        hdatos.Add("@Telefono", obj.telefono)
        hdatos.Add("@Nombre", obj.nombre)
        hdatos.Add("@Apellido", obj.apellido)




        resultado = oDatos.Escribir("sp_CreateUser", hdatos)



        Return resultado

    End Function

    Public Function ObtenerIdPorEmail(email As String) As Integer

        Dim oDatos As New DAL.BD
        Dim hdatos As New Hashtable
        Dim DS As New DataSet
        Dim idUsuario As Integer

        hdatos.Add("@Email", email)
        DS = oDatos.Leer("sp_GetIdUser", hdatos)

        If DS.Tables(0).Rows.Count > 0 Then
            For Each item As DataRow In DS.Tables(0).Rows
                idUsuario = item("id")
            Next



            Return idUsuario
        Else
            Return Nothing

        End If




    End Function








    Public Function grabarnewpass(ByVal userencrypt As String, ByVal pw As String) As Boolean
        Dim oDatos As New DAL.BD
        Dim hdatos As New Hashtable
        Dim resultado As Integer

        hdatos.Add("@User", userencrypt)
        hdatos.Add("@Pass", pw)


        resultado = oDatos.Escribir("sp_ResetPass3", hdatos)


        Return resultado

    End Function




    Public Function Registrarse(ByVal usuario As BE.usuarios) As Boolean
        Dim oDatos As New DAL.BD
        Dim hdatos As New Hashtable
        Dim resultado As Integer

        hdatos.Add("@Nombre", usuario.nombre)
        hdatos.Add("@Apellido", usuario.apellido)
        hdatos.Add("@Email", usuario.user)
        hdatos.Add("@Pass", usuario.pass)
        hdatos.Add("@Telefono", usuario.telefono)
        hdatos.Add("@PrimerLogin", "False")
        hdatos.Add("@Contador", 0)
        hdatos.Add("@Flag", 0)
        hdatos.Add("@Puntos", 0)

        resultado = oDatos.Escribir("sp_Usuario_Crear", hdatos)


        Return resultado

    End Function

End Class
