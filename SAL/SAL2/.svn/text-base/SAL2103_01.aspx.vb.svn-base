Imports System
Imports System.Data
Imports FSC.Logic

Partial Class SAL2103_01
    Inherits BaseWebForm

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load, Me.Load
        If IsPostBack Then
            Return
        End If
    End Sub

    Protected Sub btnQuery_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnQuery.Click

        '查詢需列印之資料
        Me.ShowList()

        If Me.grdExcel.Rows.Count = 0 Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "查無資料。")
            Return
        End If

        Response.Clear()
        Response.AddHeader("content-disposition", "attachment;filename=" & HttpUtility.UrlEncode("國民旅遊補助費用發放清冊", UTF8Encoding.UTF8) & ".xls")

        Response.ContentType = "application/vnd.xls"
        Dim sw As New System.IO.StringWriter
        Dim htw As New System.Web.UI.HtmlTextWriter(sw)

        '顯示列印資料
        grdExcel.Visible = True

        '關閉分頁排序
        grdExcel.AllowPaging = False
        grdExcel.AllowSorting = False

        ''查詢需列印之資料
        'Me.ShowList()

        '交付選擇之資料
        grdExcel.RenderControl(htw)

        '設定編碼為UTF-8
        Response.ContentEncoding = Encoding.GetEncoding("big5")

        '丟出完成之資料
        Response.Write("<style> .text { mso-number-format:\@; } </style> ")
        Response.Write(sw.ToString())
        Response.End()

        '開啟分頁排序
        grdExcel.AllowPaging = True
        grdExcel.AllowSorting = True

        '關閉列印資料
        grdExcel.Visible = False
        grdExcel.DataBind()
    End Sub

    ''' <summary>
    ''' 依查詢條件顯示查詢結果
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub ShowList()
        Dim bll As New SAL.Logic.SAL2103()
        Dim dtData As DataTable

        dtData = bll.GetFormData(LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode), Me.UcDDLDate.DateStr, "502")

        Me.grdExcel.DataSource = dtData
        Me.grdExcel.DataBind()
    End Sub

    Protected Sub grdExcel_RowCreated1(sender As Object, e As GridViewRowEventArgs) Handles grdExcel.RowCreated
        If e.Row.RowType = DataControlRowType.Header Then
            Dim tcc As TableCellCollection = e.Row.Cells
            Dim intcount As Integer = tcc.Count   '前端網頁碼定義Columns裡的欄位數量,此例為4 = CustomerID、CompanyName、Address、City

            tcc.Add(New TableHeaderCell())
            tcc(4).Text = "</th>"
            tcc(4).Attributes.Add("class", "ColumnNameCenter")
            tcc(4).BorderStyle = BorderStyle.None

            tcc.Add(New TableHeaderCell())
            tcc(5).Text = "</th>"
            tcc(5).BorderStyle = BorderStyle.None

            tcc.Add(New TableHeaderCell())
            tcc(6).Text = "</th>"
            tcc(6).BorderStyle = BorderStyle.None

            tcc.Add(New TableHeaderCell())
            tcc(7).Text = "製表日期：製表人：頁次：</th></tr><tr>"   '換列要加</tr><tr>
            tcc(7).Attributes.Add("class", "ColumnNameCenter")
            tcc(7).BorderStyle = BorderStyle.None

            tcc.Add(New TableHeaderCell())
            tcc(8).Attributes.Add("colspan", "4")   '由前端網頁碼定義Columns裡的欄位數量後開始編號，此例為0,1,2,3後，使用tcc(4)
            tcc(8).Attributes.Add("class", "ColumnNameCenter")
            tcc(8).Text = "國民旅遊補助費用發放清冊</th></tr><tr>"   '換列要加</tr><tr>
            tcc(8).BorderStyle = BorderStyle.None

            tcc.Add(New TableHeaderCell())
            tcc(9).Attributes.Add("colspan", "4")
            tcc(9).Attributes.Add("class", "ColumnNameCenter")
            tcc(9).Text = "</th></tr><tr>"
            tcc(9).BorderStyle = BorderStyle.None

            tcc.Add(New TableHeaderCell())
            tcc(10).Text = "單位：</th>"
            tcc(10).Attributes.Add("class", "ColumnNameCenter")
            tcc(10).BorderStyle = BorderStyle.None

            tcc.Add(New TableHeaderCell())
            tcc(11).Text = "</th>"
            tcc(11).BorderStyle = BorderStyle.None

            tcc.Add(New TableHeaderCell())
            tcc(12).Text = "</th>"
            tcc(12).BorderStyle = BorderStyle.None

            tcc.Add(New TableHeaderCell())
            tcc(13).Text = "付款憑單號碼：</th></tr><tr>"   '換列要加</tr><tr>
            tcc(13).Attributes.Add("class", "ColumnNameCenter")
            tcc(13).BorderStyle = BorderStyle.None

            tcc.Add(New TableHeaderCell())
            tcc(14).Attributes.Add("colspan", "4")
            tcc(14).Text = "</th></tr><tr>"
            tcc(14).BorderStyle = BorderStyle.None

            For i As Integer = 0 To intcount - 1
                tcc.Add(tcc(0))   '開始加入CustomerID、CompanyName、Address、City
            Next
        End If
    End Sub

    '防止 runat=server錯誤使用
    Public Overrides Sub VerifyRenderingInServerForm(ByVal control As Control)
        '處理'GridView' 的控制項 'GridView' 必須置於有 runat=server 的表單標記之中
    End Sub

    Protected Sub grdExcel_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles grdExcel.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Cells(0).Attributes.Add("class", "text")
        End If
    End Sub
End Class
