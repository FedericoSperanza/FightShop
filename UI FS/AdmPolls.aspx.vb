Imports System.Web.UI.DataVisualization.Charting
Partial Class AdmPolls
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not (Page.IsPostBack) Then
            Actualizar()
        End If
        AddHandler mdOpcion.OnAccept, AddressOf addOpcion
    End Sub

    Private Sub Actualizar()
        'Valido si puede acceder al modulo de administracion
        Dim idPermAdm = BLL.usuarios.GetInstance.GetidPermByUrl("AdmPolls.aspx")


        If Session("Nombre") IsNot Nothing Then



            If BLL.usuarios.GetInstance.PermiteAcceso(idPermAdm) Then
                ''No hago nada TODO OK!
            Else
                Response.Redirect("Home.Aspx")
            End If

        Else
            'Aca es si no hay si quiera user logueado
            Response.Redirect("Home.Aspx")
        End If


        Dim dsEncuestas = BLL.Encuesta.GetInstance.GetAll()
        Me.grd.DataSource = dsEncuestas
        Me.grd.DataBind()

        btnNuevo.Visible = grd.Rows.Count > 0

        btnNuevo_Click(Nothing, Nothing)
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



    Protected Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Me.txtDescription.Text = ""

        txtfecha.Text = Date.Now.AddDays(15)
        Me.divBtnGuardar.Visible = True
        Me.divChart.Visible = False
        Me.divContOpciones.Visible = True
        Me.divCampos.Visible = True
    End Sub

    Protected Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim obj As New BE.Encuesta

        Dim opcionesList As New List(Of String)
        If Not ViewState("opcionesList") Is Nothing Then
            opcionesList = ViewState("opcionesList")
        End If

        If opcionesList.Count < 2 Then
            regSuccess.Visible = True
            regSuccess.Attributes("class") = "alert alert-danger"
            regSuccess.InnerText = "Completar al menos 2 opciones !"
            regSuccess.Focus()
            GoTo Nada
        End If

        If Me.txtfecha.Text < Date.Today Then
            regSuccess.Visible = True
            regSuccess.Attributes("class") = "alert alert-danger"
            regSuccess.InnerText = "Fecha Invalida !"
            regSuccess.Focus()
            GoTo Nada
        End If

        obj.nombre = txtDescription.Text

        obj.vencimiento = txtfecha.Text

        For Each o In opcionesList
            Dim eo As New BE.EncuestaOpcion
            eo.nombre = o

            obj.opciones.Add(eo)
        Next

        BLL.Encuesta.GetInstance.Add(obj)
        regSuccess.Visible = True
        regSuccess.Attributes("class") = "alert alert-success"
        regSuccess.InnerText = "Encuesta creada !"
        regSuccess.Focus()
        Actualizar()

        Response.Redirect(Request.RawUrl)
Nada:

    End Sub

    Protected Sub grd_RowDeleting(sender As Object, e As GridViewDeleteEventArgs) Handles grd.RowDeleting
        Dim EncuestaId = grd.DataKeys(e.RowIndex).Value
        Try
            BLL.Encuesta.GetInstance.Delete(EncuestaId)


            Actualizar()
        Catch ex As Exception
            regSuccess.Visible = True
            regSuccess.Attributes("class") = "alert alert-danger"
            regSuccess.InnerText = "Error al borrar !"
            regSuccess.Focus()
            GoTo Nada
        End Try
        regSuccess.Visible = True
        regSuccess.Attributes("class") = "alert alert-success"
        regSuccess.InnerText = "Encuesta eliminada!"
        regSuccess.Focus()
        Server.TransferRequest(Request.Url.AbsolutePath, False)
Nada:
    End Sub

    Protected Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Me.mdOpcion.Show("Ingrese texto para la opción", "")
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


End Class
