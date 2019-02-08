
Partial Class Bitacora
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not (Page.IsPostBack) Then
            Actualizar()
            Session("Filtrado") = Nothing

        Else


        End If
    End Sub


    Private Sub Actualizar()
        Dim dsBitacora = BLL.Bitacora.ListarTodo()
        Me.GV_Bitacora.DataSource = dsBitacora
        Me.GV_Bitacora.DataBind()
    End Sub


    Protected Sub GV_Bitacora_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GV_Bitacora.RowCreated
        If e.Row.RowType = DataControlRowType.Header Then
            e.Row.TableSection = TableRowSection.TableHeader
        End If
    End Sub


    Protected Sub btnFiltrar_Click(sender As Object, e As EventArgs) Handles btnFiltrar.Click

        'valida que ambas fechas esten indicadas
        If Me.dpDesde.Value Is Nothing And Not Me.dpHasta.Value Is Nothing Or
           Not Me.dpDesde.Value Is Nothing And Me.dpHasta.Value Is Nothing _
            Then

            regSuccess.Visible = True
            regSuccess.InnerText = "Error - Indicar ambas fechas"
            Return
        End If

        'valida que fecha desde no sea mayor a fecha hasta
        If Not Me.dpDesde.Value Is Nothing And Not Me.dpHasta.Value Is Nothing And
           Me.dpDesde.Value > Me.dpHasta.Value _
        Then
            regSuccess.Visible = True
            regSuccess.InnerText = "Error - Fecha desde no puede ser mayor a fecha hasta"

            Return
        End If

        regSuccess.Visible = False


        Dim BitacoraBusqueda As New BE.BitacoraDTO
        BitacoraBusqueda.fechaDesde = dpDesde.Value
        BitacoraBusqueda.fechaHasta = dpHasta.Value
        BitacoraBusqueda.Criticidades = ddlCriticidad.Text
        BitacoraBusqueda.Usuario = txtUsuario.Text.Trim

        Dim dsbitacora As List(Of BE.Bitacora)
        If Me.dpHasta.Value Is Nothing Then
            BitacoraBusqueda.fechaDesde = "01/01/2018"
        End If
        If Me.dpDesde.Value Is Nothing Then
            BitacoraBusqueda.fechaHasta = Date.Today
        End If
        dsbitacora = BLL.Bitacora.ListarTodo(BitacoraBusqueda)
        'dsbitacora = BLL.Bitacora.ListarTodo(
        '    Me.txtUsuario.Text.Trim,
        '    Me.dpDesde.Value,
        '    Me.dpHasta.Value,
        '    Me.ddlCriticidad.Text
        ')




        Me.GV_Bitacora.DataSource = dsbitacora
        Me.GV_Bitacora.DataBind()
        Session("Filtrado") = dsbitacora



    End Sub






    Protected Sub GV_Bitacora_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GV_Bitacora.PageIndexChanging
        If Session("Filtrado") Is Nothing Then
            GV_Bitacora.PageIndex = e.NewPageIndex
            Actualizar()

        Else
            GV_Bitacora.PageIndex = e.NewPageIndex
            Me.GV_Bitacora.DataSource = Session("Filtrado")
            Me.GV_Bitacora.DataBind()

        End If



    End Sub
    Protected Sub btnResetFilter_Click(sender As Object, e As EventArgs) Handles btnResetFilter.Click
        Actualizar()

    End Sub
End Class
