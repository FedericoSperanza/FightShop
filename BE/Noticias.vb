Public Class Noticias

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

    Private _fechacaduc As Date
    Public Property fechacaduc() As Date
        Get
            Return _fechacaduc
        End Get
        Set(ByVal value As Date)
            _fechacaduc = value
        End Set
    End Property

    Private _img As String
    Public Property img() As String
        Get
            Return _img
        End Get
        Set(ByVal value As String)
            _img = value
        End Set
    End Property
End Class
