Public Class Cart

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

    Private _preciounitario As Double
    Public Property precio() As Double
        Get
            Return _preciounitario
        End Get
        Set(ByVal value As Double)
            _preciounitario = value
        End Set
    End Property

    Private _subtotal As Double
    Public Property subtotal() As Double
        Get
            Return _subtotal
        End Get
        Set(ByVal value As Double)
            _subtotal = value
        End Set
    End Property

    Private _cantidad As Integer
    Public Property cantidad() As Integer
        Get
            Return _cantidad
        End Get
        Set(ByVal value As Integer)
            _cantidad = value
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
