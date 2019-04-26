Imports System.Data.SqlClient
Imports System.Configuration
Public Class BD
    ' Private Str As String = "Data Source=.\SQL_UAI;Initial Catalog=FightShop;Integrated Security=True"
    Private Str As String = "Data Source=(local);Initial Catalog=FightShop;Integrated Security=True"
    'Private Str As String = "Data Source=DESKTOP-2LFLOUU;Initial Catalog=FightShop;Integrated Security=True"
    'Private Str As String = "Data Source= SPERANZA-PC\SQL_FEDE;Initial Catalog=FightShop;Integrated Security=True"


    Private Cnn As New SqlConnection(Str)
    Private Tranx As SqlTransaction
    Private Cmd As SqlCommand


    Public Function Leer(ByVal consulta As String, ByVal hdatos As Hashtable) As DataSet

        Dim Ds As New DataSet
        Cmd = New SqlCommand

        Cmd.Connection = Cnn
        Cmd.CommandText = consulta
        Cmd.CommandType = CommandType.StoredProcedure

        If Not hdatos Is Nothing Then

            'si la hashtable no esta vacia, y tiene el dato q busco 
            For Each dato As String In hdatos.Keys
                'cargo los parametros que le estoy pasando con la Hash
                Cmd.Parameters.AddWithValue(dato, hdatos(dato))
            Next
        End If

        Dim Adaptador As New SqlDataAdapter(Cmd)
        Adaptador.Fill(Ds)
        Return Ds

    End Function

    Public Function Escribir(ByVal consulta As String, ByVal hdatos As Hashtable) As Boolean

        If Cnn.State = ConnectionState.Closed Then
            Cnn.ConnectionString = Str
            Cnn.Open()
        End If

        Try
            Tranx = Cnn.BeginTransaction
            Cmd = New SqlCommand
            Cmd.Connection = Cnn
            Cmd.CommandText = consulta
            Cmd.CommandType = CommandType.StoredProcedure
            Cmd.Transaction = Tranx

            If Not hdatos Is Nothing Then

                For Each dato As String In hdatos.Keys
                    'cargo los parametros que le estoy pasando con la Hash
                    Cmd.Parameters.AddWithValue(dato, hdatos(dato))
                Next
            End If

            Dim respuesta As Integer = Cmd.ExecuteNonQuery
            Tranx.Commit()
            Return True

        Catch ex As Exception
            Tranx.Rollback()
            Return False
        Finally
            Cnn.Close()
        End Try

    End Function


    Public Sub executeCommand(sqltext As String)

        Dim SqlComm As New SqlClient.SqlCommand With {.CommandType = CommandType.Text, .CommandText = sqltext, .Connection = Cnn}

        Cnn.Open()
        SqlComm.ExecuteNonQuery()
        Cnn.Close()
    End Sub


    Public Function ExecuteScalar(sp As String, h As Hashtable) As Object

        Dim cmd = Cnn.CreateCommand()
        cmd = New SqlCommand
        cmd.Connection = Cnn
        cmd.CommandText = sp
        cmd.CommandType = CommandType.StoredProcedure
        If Not h Is Nothing Then
            For Each key In h.Keys
                cmd.Parameters.AddWithValue(key, h(key))
            Next
        End If

        Cnn.Open()
        Dim res = cmd.ExecuteScalar()
        Cnn.Close()

        Return res
    End Function

End Class

