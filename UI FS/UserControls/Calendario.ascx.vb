
Partial Class UserControls_Calendario
    Inherits System.Web.UI.UserControl
    Private _value As Date?

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Me.dp.SelectedDate = Date.Now
            ViewState("value") = Nothing
        End If
    End Sub

    Protected Sub btnPick_Click()
        Me.dp.Visible = Not Me.dp.Visible
    End Sub

    Protected Sub btnClear_Click()
        Me.dp.Visible = False
        ViewState("value") = Nothing
        Me.txt.Text = ""

    End Sub

    Protected Sub dp_SelectionChanged(sender As Object, e As EventArgs) Handles dp.SelectionChanged
        ViewState("value") = dp.SelectedDate
        Me.txt.Text = dp.SelectedDate.ToShortDateString
        Me.dp.Visible = False

    End Sub

    'Public ReadOnly Property Value As Date?
    '    Get
    '        Return ViewState("value")
    '    End Get
    'End Property
    Public Property Value As Date?
        Get
            Return ViewState("value")
        End Get
        Set(value As Date?)
            ViewState("value") = value
            Me.txt.Text = CDate(value).ToShortDateString()
        End Set
    End Property
End Class
