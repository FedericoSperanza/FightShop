Public Class usuarios

    Private _id As Integer
    Public Property id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property

    Property newsletter As Boolean

    Private _user As String
    Public Property user() As String
        Get
            Return _user
        End Get
        Set(ByVal value As String)
            _user = value
        End Set
    End Property

    Private _pass As String
    Public Property pass() As String
        Get
            Return _pass
        End Get
        Set(ByVal value As String)
            _pass = value
        End Set
    End Property

    Private _flag As Boolean
    Public Property flag() As Boolean
        Get
            Return _flag
        End Get
        Set(ByVal value As Boolean)
            _flag = value
        End Set
    End Property

    Private _contador As Integer
    Public Property contador() As Integer
        Get
            Return _contador
        End Get
        Set(ByVal value As Integer)
            _contador = value
        End Set
    End Property

    Private _telefono As Integer
    Public Property telefono() As Integer
        Get
            Return _telefono
        End Get
        Set(ByVal value As Integer)
            _telefono = value
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

    Private _apellido As String
    Public Property apellido() As String
        Get
            Return _apellido
        End Get
        Set(ByVal value As String)
            _apellido = value
        End Set
    End Property

    Private _primerlogin As Boolean
    Public Property primerlogin() As Boolean
        Get
            Return _primerlogin
        End Get
        Set(ByVal value As Boolean)
            _primerlogin = value
        End Set
    End Property

    Private _roles As List(Of BE.roles)
    Public Property roles() As List(Of BE.roles)
        Get
            Return _roles
        End Get
        Set(ByVal value As List(Of BE.roles))
            _roles = value
        End Set
    End Property

    Property flagNewsLetter As Boolean

End Class


