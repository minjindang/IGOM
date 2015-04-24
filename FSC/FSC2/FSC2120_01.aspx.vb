Imports System.Data
Imports System.IO
Imports FSC.Logic

Partial Class FSC2_FSC2120_01
    Inherits BaseWebForm

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Me.IsPostBack Then
            Return
        End If

        ' 繫結【單位名稱】
        Me.bindDeputyDep()

        ' 繫結【人員類別】
        Me.bindEmployeeType()

    End Sub

    ''' <summary>
    ''' 繫結【單位名稱】
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub bindDeputyDep()
        Dim szOrgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim szDdepartID As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id)
        Me.ddlDept.Orgcode = szOrgcode
    End Sub

    ''' <summary>
    ''' 繫結【人員類別】
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub bindEmployeeType()
        Dim bll As New FSC.Logic.FSC2120()

        Me.cbEmployeeType.DataTextField = "CODE_DESC1"
        Me.cbEmployeeType.DataValueField = "CODE_NO"
        Me.cbEmployeeType.DataSource = bll.getEmployeeTypeData("023", "022")
        Me.cbEmployeeType.DataBind()
    End Sub

    Protected Sub btnQuery_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnQuery.Click

        ' 依查詢條件顯示查詢結果
        ShowList(1)
    End Sub

    ''' <summary>
    ''' 依查詢條件顯示查詢結果
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub ShowList(ByVal iBindType As Integer)
        If ddlMonth.SelectedValue = -1 Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "請選擇查詢月份!")
            Exit Sub
        End If

        Dim bll As New FSC.Logic.FSC2120()

        Dim szEmployeeType As String = String.Empty

        For index = 0 To Me.cbEmployeeType.Items.Count - 1
            If cbEmployeeType.Items(index).Selected Then
                If szEmployeeType = "" Then
                    szEmployeeType += cbEmployeeType.Items(index).Value
                Else
                    szEmployeeType += "," + cbEmployeeType.Items(index).Value
                End If
            End If
        Next

        Dim dtData As DataTable = bll.GetReportData("023", "012", Integer.Parse(Me.ddlMonth.SelectedValue), Me.ddlDept.SelectedValue, szEmployeeType)

        If iBindType = 1 Then
            Me.gvList.DataSource = dtData
            Me.gvList.DataBind()
        Else
            Me.gvExcel.DataSource = dtData
            Me.gvExcel.DataBind()
        End If

    End Sub
    Protected Sub gvList_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvList.PageIndexChanging
        Me.gvList.PageIndex = e.NewPageIndex

        ' 依查詢條件顯示查詢結果
        ShowList(1)
    End Sub

    Protected Sub btnPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Response.Clear()
        Response.AddHeader("content-disposition", "attachment;filename=" & HttpUtility.UrlEncode("慶生人員名冊", UTF8Encoding.UTF8) & ".xls")
        Response.ContentType = "application/vnd.xls"
        Dim sw As New System.IO.StringWriter
        Dim htw As New System.Web.UI.HtmlTextWriter(sw)

        '查詢需列印之資料
        Me.ShowList(2)

        Dim szHeader As String = String.Empty
        szHeader += "行政院環保署"

        Dim szMonth As String = Me.ddlMonth.SelectedValue
        If szMonth <> "-1" Then
            If szMonth = "1" Then
                szHeader += "一月份"
            End If
            If szMonth = "2" Then
                szHeader += "二月份"
            End If
            If szMonth = "3" Then
                szHeader += "三月份"
            End If
            If szMonth = "4" Then
                szHeader += "四月份"
            End If
            If szMonth = "5" Then
                szHeader += "五月份"
            End If
            If szMonth = "6" Then
                szHeader += "六月份"
            End If
            If szMonth = "7" Then
                szHeader += "七月份"
            End If
            If szMonth = "8" Then
                szHeader += "八月份"
            End If
            If szMonth = "9" Then
                szHeader += "九月份"
            End If
            If szMonth = "10" Then
                szHeader += "十月份"
            End If
            If szMonth = "11" Then
                szHeader += "十一月份"
            End If
            If szMonth = "12" Then
                szHeader += "十二月份"
            End If
        End If

        szHeader += "慶生人員名冊<br/>"

        szHeader += "列印日期：" + Convert.ToInt16(DateTime.Now.AddYears(-1911).Year).ToString & DateTime.Now.ToString("/MM/dd")
        szHeader += "，共計" + Me.gvExcel.Rows.Count.ToString() + "筆資料"

        szHeader += "<br/>"

        htw.WriteLine(szHeader)

        '顯示列印資料
        gvExcel.Visible = True

        '關閉分頁排序
        gvExcel.AllowPaging = False
        gvExcel.AllowSorting = False

        '交付選擇之資料
        gvExcel.RenderControl(htw)

        '設定編碼為UTF-8
        Response.ContentEncoding = Encoding.GetEncoding("big5")

        '丟出完成之資料
        Response.Write("<style> .text { mso-number-format:\@; } </style> ")
        Response.Write(sw.ToString())
        Response.End()

        '開啟分頁排序
        gvExcel.AllowPaging = True
        gvExcel.AllowSorting = True

        '關閉列印資料
        gvExcel.Visible = False
        gvExcel.DataBind()
    End Sub

    '防止 runat=server錯誤使用
    Public Overrides Sub VerifyRenderingInServerForm(ByVal control As Control)
        '處理'GridView' 的控制項 'GridView' 必須置於有 runat=server 的表單標記之中
    End Sub

    Protected Sub gvExcel_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles gvExcel.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Cells(0).Attributes.Add("class", "text")
            e.Row.Cells(3).Attributes.Add("class", "text")
        End If
    End Sub
End Class
