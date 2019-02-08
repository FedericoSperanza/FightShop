Public Class RolPermiso
    Private _idrol As Integer
    Public Property idrol() As Integer
        Get
            Return _idrol
        End Get
        Set(ByVal value As Integer)
            _idrol = value
        End Set
    End Property

    Private _idpermiso As Integer
    Public Property idpermiso() As Integer
        Get
            Return _idpermiso
        End Get
        Set(ByVal value As Integer)
            _idpermiso = value
        End Set
    End Property
End Class
