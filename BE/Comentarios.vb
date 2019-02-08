Option Explicit On

<Serializable()>
Public Class Comentarios
    Private _idcomentario As Integer
    Public Property idcomentario() As Integer
        Get
            Return _idcomentario
        End Get
        Set(ByVal value As Integer)
            _idcomentario = value
        End Set
    End Property

    Private _idproducto As Integer
    Public Property idproducto() As Integer
        Get
            Return _idproducto
        End Get
        Set(ByVal value As Integer)
            _idproducto = value
        End Set
    End Property

    Dim _body As String

    Public Property body As String
        Get

            Return _body

        End Get
        Set(value As String)
            _body = value
        End Set
    End Property


    Public Property parent As BE.Comentarios

    Private _calificacion As Integer
    Public Property calificacion() As Integer
        Get
            Return _calificacion
        End Get
        Set(ByVal value As Integer)
            _calificacion = value
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

    Property fecha As DateTime


    Property state As String

End Class
