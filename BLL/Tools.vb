Option Explicit On
Imports System.ComponentModel
Imports System.IO
Imports System.Net.Mail
Imports System.Security.Cryptography
Imports System.Text
Imports System.Web

Public Class Tools
    Private Sub New()  ''SINGLETON

    End Sub

    Private Shared _instancia As BLL.Tools

    Public Shared Function GetInstance() As BLL.Tools

        If _instancia Is Nothing Then

            _instancia = New BLL.Tools

        End If

        Return _instancia
    End Function


    Public Shared Function DicToDataTable(dic As Dictionary(Of String, Integer), keyName As String) As DataTable
        Dim dt As New DataTable()

        dt.Columns.Add(keyName, GetType(String))
        dt.Columns.Add("value", GetType(Integer))

        For Each kvp As KeyValuePair(Of String, Integer) In dic
            Dim key As String = kvp.Key.ToString
            Dim value As Integer = kvp.Value

            Dim values As Object() = New Object(1) {}
            values(0) = key
            values(1) = value
            dt.Rows.Add(values)
        Next

        Return dt
    End Function

    Public Sub Delete(id As Integer)


        MPP.Tools.GetInstance.DeleteBackup(id)


    End Sub

    Public Sub Realizarbackup(file As String)


        MPP.Tools.GetInstance.RealizarBackup(file)


    End Sub


    Public Sub RestaurarBackup(file As String)


        MPP.Tools.GetInstance.RestaurarBackup(file)


    End Sub

    Public Function GetById(idbak As Integer) As BE.Backup

        Return MPP.Tools.GetInstance.getbyid(idbak)
    End Function

    Public Function GetAllBaks() As List(Of BE.Backup)

        Return MPP.Tools.GetInstance.getallbaks()

    End Function

    Shared Function Add(ByRef obj As BE.Backup) As Boolean
        MPP.Tools.GetInstance.AddLogBackup(obj)

        Return True
    End Function

    Public Function ToDataTable(Of T)(data As IList(Of T)) As DataTable
        Dim properties As PropertyDescriptorCollection = TypeDescriptor.GetProperties(GetType(T))
        Dim dt As New DataTable()
        For i As Integer = 0 To properties.Count - 1
            Dim [property] As PropertyDescriptor = properties(i)
            dt.Columns.Add([property].Name, [property].PropertyType)
        Next
        Dim values As Object() = New Object(properties.Count - 1) {}
        For Each item As T In data
            For i As Integer = 0 To values.Length - 1
                values(i) = properties(i).GetValue(item)
            Next
            dt.Rows.Add(values)
        Next
        Return dt
    End Function

    Public Shared Sub SendMail(receiver As String, subject As String, body As String)
        Dim Smtp_Server As New SmtpClient
        Dim e_mail As New MailMessage()




        Debug.WriteLine(body)

        Try
            Smtp_Server.UseDefaultCredentials = False
            Smtp_Server.Credentials = New Net.NetworkCredential("FightShopTFI@gmail.com", "fechedecba")
            Smtp_Server.Port = 587
            Smtp_Server.EnableSsl = True
            Smtp_Server.Host = "smtp.gmail.com"

            e_mail = New MailMessage()
            e_mail.From = New MailAddress("FightShopTFI@gmail.com")
            e_mail.To.Add(receiver)
            e_mail.Subject = subject
            e_mail.IsBodyHtml = True
            e_mail.Body = body
            Smtp_Server.Send(e_mail)
        Catch ex As Exception

        End Try
    End Sub



    Public Shared Sub generarComprobante(comprobante As String, facturaId As String, usermail As String, fecha As String, detFac As List(Of BE.FacturaItem), total As String, Optional nc As String = "nada")
        Dim Renderer = New IronPdf.HtmlToPdf()
        Dim FilePath As String = HttpContext.Current.Server.MapPath("~") & "FacturTem\factura.html"
        Dim str = New StreamReader(FilePath)
        Dim body = str.ReadToEnd()

        If nc = "nada" Then
            body = body.Replace("{NCs}", "No se utilizaron NC")
        Else
            body = body.Replace("{NCs}", "N.C N°" & nc)

        End If



        body = body.Replace("{comprobante}", comprobante)
        body = body.Replace("{fecha}", fecha)
        body = body.Replace("{cliente}", usermail)

        Dim prodyscants As String
        Dim montos As String
        For Each itemDetfac As BE.FacturaItem In detFac
            prodyscants += itemDetfac.descripcion.ToString + "     Cant: " + itemDetfac.cantidad.ToString + "<br />"
            montos += itemDetfac.monto.ToString + "<br />"
        Next


        body = body.Replace("{producto}", prodyscants)



        body = body.Replace("{subtotal}", montos)


        body = body.Replace("{totalfac}", total)

        Dim name_comprobante = comprobante & "_" & Right("0000" & facturaId, 4)
        Dim name = "facturas\" & name_comprobante & ".pdf"

        Dim PDF = Renderer.RenderHtmlAsPdf(body)
        Dim OutputPath = HttpContext.Current.Server.MapPath("~") & name
        PDF.SaveAs(OutputPath)

        ' SendMail(BLL.Usuario.current.email, name_comprobante, body)

    End Sub

    Public Shared Sub generarNC(comprobante As String, facturaId As String, concepto As String, usermail As String, fecha As String, total As String)
        Dim Renderer = New IronPdf.HtmlToPdf()
        Dim FilePath As String = HttpContext.Current.Server.MapPath("~") & "FacturTem\factura.html"
        Dim str = New StreamReader(FilePath)
        Dim body = str.ReadToEnd()

        body = body.Replace("{comprobante}", comprobante)
        body = body.Replace("{fecha}", fecha)
        body = body.Replace("{cliente}", usermail)
        body = body.Replace("{NCs}", "Disfrute de su Credito")

        'For Each itemDetfac As BE.FacturaItem In detFac
        '    prodyscants += itemDetfac.descripcion.ToString + "     Cant: " + itemDetfac.cantidad.ToString + "<br />"
        '    montos += itemDetfac.monto.ToString + "<br />"
        'Next

        body = body.Replace("{producto}", concepto)
        body = body.Replace("{subtotal}", total)

        body = body.Replace("{totalfac}", total)

        Dim name_comprobante = comprobante & "_" & Right("0000" & facturaId, 4)
        Dim name = "facturas\" & name_comprobante & ".pdf"

        Dim PDF = Renderer.RenderHtmlAsPdf(body)
        Dim OutputPath = HttpContext.Current.Server.MapPath("~") & name
        PDF.SaveAs(OutputPath)

        ' SendMail(BLL.Usuario.current.email, name_comprobante, body)

    End Sub





End Class
