
Partial Class Common_Report
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim FileType As String = Me.Request.QueryString("FileType")
        Select Case FileType
            Case "doc"
                ExportDoc()
            Case "xls"
                ExportXls()
        End Select
    End Sub

    Public Sub ExportDoc()
        Dim GridViewName As String = Me.Request.QueryString("GridView")
        Dim FileName As String = Me.Request.QueryString("FileName")
        Dim myGridView As GridView = CType(Session(GridViewName), GridView)
        If Not myGridView Is Nothing Then
            Dim name As String = "attachment;filename=" + FileName
            HttpContext.Current.Response.Clear()
            HttpContext.Current.Response.AddHeader("content-disposition", name)
            HttpContext.Current.Response.HeaderEncoding = System.Text.Encoding.GetEncoding("Big5")
            HttpContext.Current.Response.ContentType = "application/vnd.ms-word"
            Dim stringWrite As System.IO.StringWriter = New System.IO.StringWriter
            Dim htmlWrite As System.Web.UI.HtmlTextWriter = New HtmlTextWriter(stringWrite)
            Me.EnableViewState = False
            Me.Page.Form.Controls.Add(myGridView)
            myGridView.TopPagerRow.Visible = False
            myGridView.BottomPagerRow.Visible = False
            myGridView.RenderControl(htmlWrite)
            Session.Remove(GridViewName)

            HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("UTF-8")
            Dim CssStyle As New StringBuilder()

            '=====================CSS===================================
            CssStyle.Append("<head><style>")
            CssStyle.Append(CommonFun.ReadFile(Server.MapPath("~/CSS/css.css")))
            CssStyle.Append(CommonFun.ReadFile(Server.MapPath("~/CSS/syntegra3.css")))
            CssStyle.Append("</style></head>")
            '=====================CSS===================================

            '=====================CAPTION===============================
            Dim content As String = stringWrite.ToString()
            If -1 <> content.IndexOf("<caption>") Then
                content = content.Replace("<caption>", "<tr><td colspan='" + myGridView.Columns.Count.ToString() + "'>").Replace("</caption>", "</td></tr>")
            End If

            HttpContext.Current.Response.Write(CssStyle.ToString)
            HttpContext.Current.Response.Write(content)
            HttpContext.Current.Response.End()
        End If
    End Sub

    Public Sub ExportXls()
        Dim GridViewName As String = Me.Request.QueryString("GridView")
        Dim FileName As String = Me.Request.QueryString("FileName")
        Dim myGridView As GridView = CType(Session(GridViewName), GridView)
        If Not myGridView Is Nothing Then
            Dim name As String = "attachment;filename=" + FileName
            HttpContext.Current.Response.Clear()
            HttpContext.Current.Response.AddHeader("content-disposition", name)
            HttpContext.Current.Response.HeaderEncoding = System.Text.Encoding.GetEncoding("Big5")
            HttpContext.Current.Response.ContentType = "application/vnd.ms-excel"
            Dim stringWrite As System.IO.StringWriter = New System.IO.StringWriter
            Dim htmlWrite As System.Web.UI.HtmlTextWriter = New HtmlTextWriter(stringWrite)
            Me.Page.Form.Controls.Add(myGridView)
            myGridView.TopPagerRow.Visible = False
            myGridView.BottomPagerRow.Visible = False
            myGridView.RenderControl(htmlWrite)
            Session.Remove(GridViewName)

            HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("UTF-8")
            Dim CssStyle As New StringBuilder()

            '=====================CSS===================================
            CssStyle.Append("<head><style>")
            CssStyle.Append(CommonFun.ReadFile(Server.MapPath("~/CSS/css.css")))
            CssStyle.Append(CommonFun.ReadFile(Server.MapPath("~/CSS/syntegra3.css")))
            CssStyle.Append("</style></head>")
            '=====================CSS===================================

            HttpContext.Current.Response.Write(CssStyle.ToString)
            HttpContext.Current.Response.Write(stringWrite.ToString)
            HttpContext.Current.Response.End()
        End If
    End Sub

    Public Overloads Overrides Sub VerifyRenderingInServerForm(ByVal control As System.Web.UI.Control)
        '必須有此方法，否則RenderControl()方法會出錯
    End Sub

End Class
