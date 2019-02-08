Imports System.IO
Partial Class _Default
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Request.QueryString("q") Is Nothing Then
            Dim q = Request.QueryString("q").ToLower.Trim

            If q = "" Then
                Response.Redirect("Catalogo.aspx")
            End If

            Dim permisos As New List(Of BE.permisos)

            If Not Session("Nombre") Is Nothing Then
                For Each r As BE.roles In BE.GlobalUsuario.usuarioConectado.roles
                    For Each p As BE.permisos In r.permisos
                        If Not permisos.Exists(Function(x) x.nombre = p.nombre) Then
                            permisos.Add(p)
                        End If
                    Next
                Next

                ''SE AGREGAN LOS PUBLICOS


                Dim blRolesPublicos As New BLL.Roles
                Dim lstpermisospublicos As New List(Of BE.permisos)
                lstpermisospublicos = blRolesPublicos.ListarPermisosPublicos()
                ' Dim permisoZ As New List(Of BE.permisos)

                For Each permisopublico As BE.permisos In lstpermisospublicos
                    permisos.Add(permisopublico)

                Next



            Else

                'solo los publicos

                Dim blRolesPublicos As New BLL.Roles
                Dim lstpermisospublicos As New List(Of BE.permisos)
                lstpermisospublicos = blRolesPublicos.ListarPermisosPublicos()
                ' Dim permisoZ As New List(Of BE.permisos)

                For Each permisopublico As BE.permisos In lstpermisospublicos
                    permisos.Add(permisopublico)

                Next


            End If

            Dim filtered = permisos.FindAll(Function(x) x.tags.ToLower.Contains(q))
            If filtered.Count > 0 Then
                ' Dim oPermisos As New BE.permisos
                ' Dim insideobjecturl As String

                'Dim URL As New List(Of String)
                'For Each oPermisos In filtered
                '    'insideobjecturl = ()
                '    URL.Add(oPermisos.url.ToString)

                'Next
                rptResultados.DataSource = filtered
                rptResultados.DataBind()
                'rptResultados.DataSource = filtered
                'rptResultados.DataBind()
                rptResultados.Visible = True
                'divResultados.Visible = False
            Else
                rptResultados.Visible = False
                divResultados.Visible = True
                divResultados.InnerText = "No se encontraron resultados para '" & Request.QueryString("q") & "'"

            End If
        End If
    End Sub

End Class
