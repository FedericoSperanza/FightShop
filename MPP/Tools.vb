Public Class Tools
    Private Sub New()  ''SINGLETON

    End Sub

    Private Shared _instancia As MPP.Tools

    Public Shared Function GetInstance() As MPP.Tools

        If _instancia Is Nothing Then

            _instancia = New MPP.Tools

        End If

        Return _instancia
    End Function



    Public Sub DeleteBackup(id As Integer)

        Dim oDatos As New DAL.BD
        Dim hdatos As New Hashtable
        Dim DS As New DataSet

        hdatos.Add("@id", id)


        DS = oDatos.Leer("sp_BackDelete", hdatos)






    End Sub


    Public Function getbyid(id As Integer) As BE.Backup

        Dim oDatos As New DAL.BD
        Dim hdatos As New Hashtable
        Dim DS As New DataSet

        hdatos.Add("@id", id)

        Dim obackup As BE.Backup
        DS = oDatos.Leer("sp_GetBakById", hdatos)

        If DS.Tables(0).Rows.Count > 0 Then
            For Each item As DataRow In DS.Tables(0).Rows
                obackup = New BE.Backup
                obackup.fecha = item("fecha")
                obackup.filename = item("filename")
                obackup.usuario = item("usuarioid")
                obackup.id = item("id")


            Next



            Return obackup
        Else
            Return Nothing

        End If
    End Function



    Public Sub RealizarBackup(ByVal archivo As String)
        Dim acceso As New DAL.BD
        Dim query As String = "BACKUP DATABASE [FightShop] TO  DISK = N'" & archivo & "' WITH NOFORMAT, NOINIT, NAME = N'FightShop-Full Database Backup', SKIP, NOREWIND, NOUNLOAD,  STATS = 10"
        acceso.executeCommand(String.Format(query))


        '  acceso.executeCommand(String.Format("ALTER DATABASE {0} SET SINGLE_USER With ROLLBACK IMMEDIATE;BACKUP DATABASE {0} TO DISK='{1}';ALTER DATABASE {0} SET MULTI_USER With ROLLBACK IMMEDIATE", "FightShop", archivo))
    End Sub



    Public Sub RestaurarBackup(ByVal archivo As String)
        Dim acceso As New DAL.BD
        Dim query As String = "USE MASTER ALTER DATABASE FightShop SET SINGLE_USER WITH ROLLBACK IMMEDIATE RESTORE DATABASE FightShop FROM DISK = '" & archivo & "' WITH REPLACE ALTER DATABASE FIGHTSHOP SET MULTI_USER WITH ROLLBACK IMMEDIATE"

        acceso.executeCommand(String.Format(query))


        '  acceso.executeCommand(String.Format("ALTER DATABASE {0} SET SINGLE_USER With ROLLBACK IMMEDIATE;BACKUP DATABASE {0} TO DISK='{1}';ALTER DATABASE {0} SET MULTI_USER With ROLLBACK IMMEDIATE", "FightShop", archivo))
    End Sub


    Public Function AddLogBackup(obj As BE.Backup) As Boolean
        Dim oDatos As New DAL.BD
        Dim hdatos As New Hashtable
        Dim resultado As Integer

        hdatos.Add("@Fecha", obj.fecha)
        hdatos.Add("@file", obj.filename)
        hdatos.Add("@usuarioid", obj.usuario)


        resultado = oDatos.Escribir("sp_InsertBackup", hdatos)



        Return resultado

    End Function




    Public Function getallbaks() As List(Of BE.Backup)

        Dim oDatos As New DAL.BD
        Dim hdatos As New Hashtable
        Dim DS As New DataSet
        Dim lstbaks As New List(Of BE.Backup)
        Dim obackup As BE.Backup
        DS = oDatos.Leer("sp_GetAllBaks", hdatos)

        If DS.Tables(0).Rows.Count > 0 Then
            For Each item As DataRow In DS.Tables(0).Rows
                obackup = New BE.Backup
                obackup.fecha = item("fecha")
                obackup.filename = item("filename")
                obackup.usuario = item("usuario")
                obackup.id = item("id")

                lstbaks.Add(obackup)
            Next



            Return lstbaks
        Else
            Return Nothing

        End If
    End Function


End Class
