Imports System.Web.UI.DataVisualization.Charting

Partial Class FichasDeOpinion
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not (Page.IsPostBack) Then
            Actualizar()
        End If
        AddHandler mdOpcion.OnAccept, AddressOf addOpcion
    End Sub

    Protected Sub addOpcion(sender As Object, opcion As String)
        Dim opcionesList As New List(Of String)
        If Not ViewState("opcionesList") Is Nothing Then
            opcionesList = ViewState("opcionesList")
        End If
        opcionesList.Add(opcion)
        ViewState("opcionesList") = opcionesList
        rptOpciones.DataSource = opcionesList
        rptOpciones.DataBind()
    End Sub

    Private Sub Actualizar()
        Dim dsEncuestas = BLL.Encuesta.GetInstance.GetAll(True)
        Me.grd.DataSource = dsEncuestas
        Me.grd.DataBind()

        btnNuevo.Visible = grd.Rows.Count > 0

        btnNuevo_Click(Nothing, Nothing)
    End Sub

    Protected Sub grd_SelectedIndexChanging(sender As Object, e As GridViewSelectEventArgs) Handles grd.SelectedIndexChanging
        Dim r As GridViewRow = Me.grd.Rows(e.NewSelectedIndex)
        Dim EncuestaId = grd.DataKeys(e.NewSelectedIndex).Value

        Dim enc = BLL.Encuesta.GetInstance.GetById(EncuestaId)
        Dim Dvista As New System.Data.DataView(BLL.Tools.GetInstance.ToDataTable(Of BE.EncuestaOpcion)(enc.opciones))
        chartEncuesta.Series(0).Points.DataBindXY(Dvista, "nombre", Dvista, "valor")
        chartEncuesta.Series(0).ChartType = SeriesChartType.Pie
        chartEncuesta.ChartAreas(0).Area3DStyle.Enable3D = True

        Me.divBtnGuardar.Visible = False
        Me.divChart.Visible = True
        Me.divContOpciones.Visible = False
        Me.divCampos.Visible = False

    End Sub

    Protected Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim obj As New BE.Encuesta

        Dim opcionesList As New List(Of String)
        If Not ViewState("opcionesList") Is Nothing Then
            opcionesList = ViewState("opcionesList")
        End If

        If opcionesList.Count < 2 Then
            'regsucess poner 2 opciones
        End If

        If Me.dpVencimiento.Value Is Nothing Then
            'regsuces fecha vto valida
        End If

        obj.nombre = txtDescription.Text

        obj.vencimiento = dpVencimiento.Value

        For Each o In opcionesList
            Dim eo As New BE.EncuestaOpcion
            eo.nombre = o
            eo.valor = 0
            obj.opciones.Add(eo)
        Next

        BLL.Encuesta.GetInstance.Add(obj, True)

        Actualizar()
        Response.Redirect(Request.RawUrl)
    End Sub

    Protected Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Me.txtDescription.Text = ""

        Me.dpVencimiento.Value = DateTime.Now.AddDays(15)
        Me.divBtnGuardar.Visible = True
        Me.divChart.Visible = False
        Me.divContOpciones.Visible = True
        Me.divCampos.Visible = True
    End Sub

    Protected Sub grd_RowDeleting(sender As Object, e As GridViewDeleteEventArgs) Handles grd.RowDeleting
        Dim EncuestaId = grd.DataKeys(e.RowIndex).Value
        Try
            BLL.Encuesta.GetInstance.Delete(EncuestaId)
            '   Dim msg = New Message(Message.MessageType.Success, "Éxito", "Encuesta borrada")
            'regsuces encuesta borrada

            'Session("message") = msg
            Actualizar()
        Catch ex As Exception
            'regu error
            ' Session("message") = New Message(Message.MessageType.Err, "Error", ex.Message)
            'TryCast(Me.Master, homefix).ShowMessage(New Message(Message.MessageType.Err, "Error", ex.Message))
        End Try
        Server.TransferRequest(Request.Url.AbsolutePath, False)
    End Sub

    Protected Sub grd_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles grd.PageIndexChanging
        grd.PageIndex = e.NewPageIndex
        Actualizar()
    End Sub

    Protected Sub rptOpciones_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.RepeaterCommandEventArgs) Handles rptOpciones.ItemCommand
        If e.CommandName = "Remove" Then
            Dim opcionesList As New List(Of String)
            If Not ViewState("opcionesList") Is Nothing Then
                opcionesList = ViewState("opcionesList")
            End If
            opcionesList.RemoveAt(CInt(e.CommandArgument))
            ViewState("opcionesList") = opcionesList
            rptOpciones.DataSource = opcionesList
            rptOpciones.DataBind()
        End If
    End Sub

    Protected Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Me.mdOpcion.Show("Ingrese texto para la opción", "")
    End Sub


End Class
