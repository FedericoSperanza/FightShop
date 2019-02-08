Imports System.Security.Cryptography
Imports System.Text
Public Class usuarios


    Private Sub New()  ''SINGLETON

    End Sub

    Private Shared _instancia As BLL.usuarios

    Public Shared Function GetInstance() As BLL.usuarios

        If _instancia Is Nothing Then

            _instancia = New BLL.usuarios

        End If

        Return _instancia
    End Function


    Function SetSubscribed(iduser As Integer, suscribed As Integer) As Boolean

        Return MPP.usuarios.GetInstance.SetSubscribed(iduser, suscribed)
    End Function

    Function getAllForNewsletter() As List(Of BE.usuarios)
        Dim listamailsencript As List(Of BE.usuarios)
        listamailsencript = MPP.usuarios.GetInstance.getAllForNewsletter()
        Dim servicebla As New BLL.servicesBL

        Dim lstuser As New List(Of BE.usuarios)
        If listamailsencript IsNot Nothing Then


            For Each user As BE.usuarios In listamailsencript
                user.user = servicebla.Desencriptar3d(user.user)
                lstuser.Add(user)
            Next
        End If
        Return lstuser
    End Function



    Function getAllForNewsletterNotUsers() As List(Of String)


        Return MPP.usuarios.GetInstance.getAllForNewsletterNotUsers()
    End Function




    Public Function Registrarse(usuario As BE.usuarios) As Boolean
        Dim servBL As New BLL.servicesBL
        usuario.user = servBL.Encriptar3d(usuario.user)
        usuario.pass = servBL.Encriptar3d(usuario.pass)

        If MPP.usuarios.GetInstance.Registrarse(usuario) Then

            Return True

        Else

            Return False

        End If




    End Function

    Public Function GetMailById(iduser As Integer) As String

        Return MPP.usuarios.GetInstance.GetMailById(iduser)
    End Function


    Public Function QuitarRol(iduser As Integer, idrol As Integer) As Boolean

        Return MPP.usuarios.GetInstance.QuitarRol(iduser, idrol)
    End Function


    Public Function AsignarRol(iduser As Integer, idrol As Integer) As Boolean

        Return MPP.usuarios.GetInstance.AsignarRol(iduser, idrol)
    End Function

    Public Function Bloquear_Desbloquear(iduser As Integer, estado As Boolean) As Boolean

        Return MPP.usuarios.GetInstance.Bloquear_Desbloquear(iduser, estado)
    End Function

    Public Function DeleteUser(idUser As Integer) As Boolean

        Return MPP.usuarios.GetInstance.deleteUser(idUser)
    End Function

    Public Function UpdateUser(objuser As BE.usuarios, usermodif As String) As Boolean

        Return MPP.usuarios.GetInstance.UpdateUser(objuser, usermodif)

    End Function

    Public Function GrabarNewPass(user As String, pw As String) As Boolean
        Dim acceso As New BLL.servicesBL

        pw = acceso.Encriptar3d(pw)
        user = acceso.Encriptar3d(user)


        Return MPP.usuarios.GetInstance.grabarnewpass(user, pw)
    End Function



    Public Function CreateUser(objusuario As BE.usuarios) As Boolean
        Dim servicesbl As New BLL.servicesBL
        Dim passNoCrypt As String = CrearContraseñaAleatoria()
        objusuario.pass = servicesbl.Encriptar3d(passNoCrypt)
        objusuario.user = servicesbl.Encriptar3d(objusuario.user)

        If MPP.usuarios.GetInstance.CrearNuevo(objusuario) Then

            Dim ruta As String = My.Application.Info.DirectoryPath
            Dim archivo As System.IO.FileStream
            Dim UsuarioLoginDescrypt As String
            Dim IdUsuario As Integer = BLL.usuarios.GetInstance.ObtenerIdPorEmail(servicesbl.Desencriptar3d(objusuario.user))
            UsuarioLoginDescrypt = servicesbl.Desencriptar3d(objusuario.user)



            archivo = System.IO.File.Create(ruta & "/User-" & UsuarioLoginDescrypt & ".txt")
            Dim info As Byte() = New System.Text.UTF8Encoding(True).GetBytes("Usuario: " & UsuarioLoginDescrypt & " Password: " & passNoCrypt)
            archivo.Write(info, 0, info.Length)
            archivo.Close()

            Return True

        Else

            Return False
        End If

    End Function

    Public Function ObtenerIdPorEmail(ByVal mail As String) As Integer
        Dim servicesBL As New BLL.servicesBL
        Dim mailencript As String
        mailencript = servicesBL.Encriptar3d(mail)

        Return MPP.usuarios.GetInstance.ObtenerIdPorEmail(mailencript)
    End Function



    Public Function Login(ByVal mail As String, ByVal pw As String) As BE.usuarios

        Dim resultado As BE.usuarios

        Dim servBL As New BLL.servicesBL
        mail = servBL.Encriptar3d(mail)
        pw = servBL.Encriptar3d(pw)





        resultado = MPP.usuarios.GetInstance.LogIn(mail, pw)

        If resultado IsNot Nothing Then
            resultado.user = servBL.Desencriptar3d(resultado.user)
            resultado.pass = servBL.Desencriptar3d(resultado.pass)

            ''Carga de Roles
            resultado.roles = CargarRolessDeUsuario(resultado.id)


        End If

        Return resultado

    End Function



    Public Function ResetPass(txtUsuario As String)

        Dim ACCESO As New BLL.servicesBL

        Dim userEncriptCompare As String


        userEncriptCompare = ACCESO.Encriptar3d(txtUsuario)


        If MPP.usuarios.GetInstance.ResetPass(userEncriptCompare) Then


            Dim ruta As String = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) 'My.Application.Info.DirectoryPath
            Dim archivo As System.IO.FileStream
            Dim PassDesencrypt As String
            Dim Acceso2 As New BLL.servicesBL

            PassDesencrypt = usuarios.GetInstance.CrearContraseñaAleatoria()




            archivo = System.IO.File.Create(ruta & "/User-" & txtUsuario & "RecuPass.txt")
            Dim info As Byte() = New System.Text.UTF8Encoding(True).GetBytes("Usuario: " & txtUsuario & " Password: " & PassDesencrypt)
            archivo.Write(info, 0, info.Length)
            archivo.Close()

            Dim passEncrypt As String

            passEncrypt = Acceso2.Encriptar3d(PassDesencrypt)


            MPP.usuarios.GetInstance.GuardarNuevaContraseña(userEncriptCompare, passEncrypt)


            Return True
        Else
            Return False


        End If
    End Function

    Private Function CrearContraseñaAleatoria() As String

        Dim passwordAleatorio As String

        Dim s As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789"
        Dim r As New Random
        Dim sb As New StringBuilder
        For i As Integer = 1 To 8
            Dim idx As Integer = r.Next(0, 35)
            sb.Append(s.Substring(idx, 1))
        Next

        passwordAleatorio = sb.ToString()

        Return passwordAleatorio

    End Function











    Function CargarRolessDeUsuario(idUsuario As Integer) As List(Of BE.roles)


        Dim rolBL As New BLL.Roles
        Dim RolesMPP As New MPP.Roles
        Dim listIdsRolesReturn As New List(Of Integer)
        Dim listRolesReturn As New List(Of BE.roles)

        listIdsRolesReturn = MPP.usuarios.GetInstance.ObtenerIdsRolessDeUsuario(idUsuario)


        If listIdsRolesReturn IsNot Nothing Then



            For Each idRoles As Integer In listIdsRolesReturn
                Dim roles As New BE.roles

                roles = rolBL.BuscarRolesConPermisos(Convert.ToString(idRoles))
                listRolesReturn.Add(roles)
            Next


        End If
        Return listRolesReturn

    End Function


    Function PermiteAcceso(ByVal idPermiso As Integer) As Boolean
        If MPP.usuarios.GetInstance.HabilitaPermiso(idPermiso) = True Then
            Return True
        Else
            Return False
        End If

    End Function

    Public Function GetidPermByUrl(ByVal url As String) As Integer

        Return MPP.usuarios.GetInstance.GetidPermByUrl(url)
    End Function



    Public Function ListAllUsers() As List(Of BE.usuarios)
        Dim lstUsuarios As New List(Of BE.usuarios)
        Dim accesoServ As New BLL.servicesBL

        For Each objUsuario As BE.USUARIOS In MPP.usuarios.GetInstance.ListAllUsers
            objUsuario.user = accesoServ.Desencriptar3d(objUsuario.user)
            lstUsuarios.Add(objUsuario)

        Next
        Return lstUsuarios

    End Function


End Class
