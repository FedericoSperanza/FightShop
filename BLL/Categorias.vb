Public Class Categorias
    Private Sub New()  ''SINGLETON

    End Sub

    Private Shared _instancia As BLL.Categorias

    Public Shared Function GetInstance() As BLL.Categorias

        If _instancia Is Nothing Then

            _instancia = New BLL.Categorias

        End If

        Return _instancia
    End Function

    Public Function ListarAllCategorias() As List(Of BE.Categorias)

        Return MPP.Categorias.ListarAllCategorias()

    End Function

    Public Function ListarCategorias() As List(Of BE.Categorias)

        Return MPP.Categorias.GetInstance.ListarCategorias()

    End Function

    Public Function GetIdByNom(nom As String) As Integer

        Return MPP.Categorias.GetInstance.GetIdByNom(nom)
    End Function


    Public Function CreateCat(objCat As BE.Categorias) As Boolean
        Dim resultado As Boolean

        If MPP.Categorias.GetInstance.ValidarCatExiste(objCat.nombre) = True Then
            resultado = False
        Else
            MPP.Categorias.GetInstance.CreateCat(objCat)
            resultado = True
        End If

        Return resultado

    End Function



    Public Function UpdateCat(objcat As BE.Categorias, catmodif As String) As Boolean

        Return MPP.Categorias.GetInstance.UpdateCat(objcat, catmodif)

    End Function




    Public Function DeleteCategoria(NOM As String) As Boolean


        Return MPP.Categorias.GetInstance.DeleteCategoria(NOM)
    End Function



End Class
