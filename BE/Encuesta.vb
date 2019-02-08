
Option Explicit On
    <Serializable()>
    Public Class Encuesta

        Public Property id As Integer
        Public Property nombre As String
        Public Property opciones As New List(Of BE.EncuestaOpcion)

    Public Property vencimiento As Date

    Public Property fichaOpinion As Boolean

End Class
