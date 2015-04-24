Imports System.Data
Imports System.IO
Imports PRO.Logic

Partial Class PRO2_PRO2102_01
    Inherits BaseWebForm

    Dim bll As New PRO.Logic.PRO2102()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Me.IsPostBack Then
            Return
        End If

        ' 繫結【單位名稱】
        Me.bindDeputyDep()

        ' 繫結【財產別】
        Me.bindPropertyType()

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
    ''' 繫結【財產別】
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub bindPropertyType()
        Me.ddlProperty_type.DataTextField = "CODE_DESC1"
        Me.ddlProperty_type.DataValueField = "CODE_NO"
        Me.ddlProperty_type.DataSource = bll.getEmployeeTypeData("016", "006")
        Me.ddlProperty_type.DataBind()
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
        'If ddlMonth.SelectedValue = -1 Then
        '    CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "請選擇查詢月份!")
        '    Exit Sub
        'End If

        Dim szEmployeeType As String = String.Empty

        Dim dtData As DataTable = bll.GetReportData("016", "006", ddlDept.SelectedValue, Me.ddlProperty_type.SelectedValue, Me.ucLast_dateS.Text, Me.ucLast_dateE.Text)

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
        Response.AddHeader("content-disposition", "attachment;filename=" & HttpUtility.UrlEncode("財產報廢名單", UTF8Encoding.UTF8) & ".xls")
        Response.ContentType = "application/vnd.xls"
        Dim sw As New System.IO.StringWriter
        Dim htw As New System.Web.UI.HtmlTextWriter(sw)

        '查詢需列印之資料
        Me.ShowList(2)

        Dim szHeader As String = String.Empty

        szHeader += "<table width='100%'><tr>"
        szHeader += "<td colspan='3'></td>"
        szHeader += "<td colspan='7' style='text-align:center'>財產報廢</td>"
        szHeader += "<td colspan='2' style='text-align:right'>印表日期：" + FSC.Logic.DateTimeInfo.ToDisplay(FSC.Logic.DateTimeInfo.GetRocDate(Now))
        szHeader += "<br/>"
        szHeader += "承辦人：" + LoginManager.UserName + "</td>"
        szHeader += "</tr></table>"

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
