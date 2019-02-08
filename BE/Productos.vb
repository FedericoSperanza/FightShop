Public Class Productos


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

    Private _precio As Double
    Public Property precio() As Double
        Get
            Return _precio
        End Get
        Set(ByVal value As Double)
            _precio = value
        End Set
    End Property


    Private _descuento As Integer
    Public Property descuento() As Integer
        Get
            Return _descuento
        End Get
        Set(ByVal value As Integer)
            _descuento = value
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
    Private _stock As Integer
    Public Property stock() As Integer
        Get
            Return _stock
        End Get
        Set(ByVal value As Integer)
            _stock = value
        End Set
    End Property

    Private _categoria As String
    Public Property categoria() As String
        Get
            Return _categoria
        End Get
        Set(ByVal value As String)
            _categoria = value
        End Set
    End Property
End Class
