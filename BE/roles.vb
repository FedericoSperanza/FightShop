Public Class roles
    Private _id As Integer
    Public Property id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property


    Private _nombre As String
    Public Property nombre() As String
        Get
            Return _nombre
        End Get
        Set(ByVal value As String)
            _nombre = value
        End Set
    End Property

    Private _descripcion As String
    Public Property descripcion() As String
        Get
            Return _descripcion
        End Get
        Set(ByVal value As String)
            _descripcion = value
        End Set
    End Property

    Private _permisos As List(Of BE.permisos)
    Public Property permisos() As List(Of BE.permisos)
        Get
            Return _permisos
        End Get
        Set(ByVal value As List(Of BE.permisos))
            _permisos = value
        End Set
    End Property



End Class
