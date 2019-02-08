
Public Class UserControls_modalDialog
    Inherits System.Web.UI.UserControl


    Public Event OnAccept As EventHandler(Of String)

    Public Sub Show(title As String, value As String)
        Me.lblTitle.Text = title
        Me.txtValue.Text = value
        Me.Visible = True
        Me.txtValue.Focus()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Visible = False
    End Sub

    Protected Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Visible = False
    End Sub

    Protected Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        RaiseEvent OnAccept(sender, Me.txtValue.Text)
        Me.Visible = False
    End Sub
End Class
