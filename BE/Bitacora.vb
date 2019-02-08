Public Class Bitacora
    Private _id As Integer
    Public Property id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property


    Private _fecha As DateTime
    Public Property fecha() As DateTime
        Get
            Return _fecha
        End Get
        Set(ByVal value As DateTime)
            _fecha = value
        End Set
    End Property


    Private _usuario As String
    Public Property usuario() As String
        Get
            Return _usuario
        End Get
        Set(ByVal value As String)
            _usuario = value
        End Set
    End Property

    Private _evento As String
    Public Property evento() As String
        Get
            Return _evento
        End Get
        Set(ByVal value As String)
            _evento = value
        End Set
    End Property

    Private _criticidad As String
    Public Property criticidad() As String
        Get
            Return _criticidad
        End Get
        Set(ByVal value As String)
            _criticidad = value
        End Set
    End Property




End Class
