Public Class RolUsuario
    Private _idRol As Integer
    Public Property idRol() As Integer
        Get
            Return _idRol
        End Get
        Set(ByVal value As Integer)
            _idRol = value
        End Set
    End Property

    Private _idUsuario As Integer
    Public Property idUsuario() As Integer
        Get
            Return _idUsuario
        End Get
        Set(ByVal value As Integer)
            _idUsuario = value
        End Set
    End Property


End Class
