Imports FSCPLM.Logic
Imports SALARY.Logic
Imports System.Data

Partial Class SAL1105_02a
    Inherits BaseWebForm


    Dim Apply_yy As String = ""

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not String.IsNullOrEmpty(Request("Apply_yy")) Then
            Apply_yy = Integer.Parse(Request("Apply_yy"))
        End If
        printing(Apply_yy, 25)

    End Sub

#Region "列印"

    Protected Sub printing(ByVal Apply_yy As String, ByVal pagerowcnt As Integer)
        Dim Username As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name) 
        Dim SAL1105 As New SAL1105()
        Dim dt As DataTable = SAL1105.GetDataByUserId(LoginManager.OrgCode, LoginManager.UserId, Apply_yy)

        If (dt.Rows.Count) > 0 Then

            Dim memo As String = "" & Username & "(員編:" & LoginManager.UserId & ")先行代墊"
            Dim amt As String = dt.Rows(0)("Apply_amt").ToString
            Dim len As Integer = amt.Length
            Dim ReportAmtLen As Integer = 9
 
            dt.Columns.Add("a1", GetType(System.String)) '加入Unit
            dt.Columns.Add("a2", GetType(System.String)) '加入Ten
            dt.Columns.Add("a3", GetType(System.String)) '加入Hundred
            dt.Columns.Add("a4", GetType(System.String)) '加入Thousand
            dt.Columns.Add("a5", GetType(System.String)) '加入TenThousand
            dt.Columns.Add("a6", GetType(System.String)) '加入HundredThousand
            dt.Columns.Add("a7", GetType(System.String)) '加入Million
            dt.Columns.Add("a8", GetType(System.String)) '加入TenMillion
            dt.Columns.Add("a9", GetType(System.String)) '加入HundredMillion
            dt.Columns.Add("memo", GetType(System.String))
           

            dt.Rows(0).Item("memo") = memo
            '寫入金額
            dt.Rows(0).Item("a" & (ReportAmtLen - len)) = "$"

            For i As Integer = (len - 1) To 0 Step -1
                dt.Rows(0).Item("a" & (ReportAmtLen - i)) = amt.Substring(len - (i + 1), 1)

            Next

            dt.AcceptChanges()

            Dim theDTReport As CommonLib.DTReport
            Dim strParam(3) As String

            Dim reportUtil As New CommonLib.ReportUtil(dt)
            reportUtil.SetCurrentPage(pagerowcnt)

            Dim totalPage As Integer = reportUtil.GetTotalPage(pagerowcnt)

            strParam(0) = Right("000" & Today.Year - 1911, 3) & "/" & Today.ToString("MM/dd")
            strParam(1) = LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name)
            strParam(2) = totalPage
             
            theDTReport = New CommonLib.DTReport(Server.MapPath("~/Report/SAL/SAL1105.mht"), dt) 
            theDTReport.Param = strParam
            theDTReport.ExportFileName = "支出憑證黏存單"
            theDTReport.PageGroupColumns = reportUtil.Group
            theDTReport.PageGroupKeyColumns = reportUtil.Group 
            theDTReport.ExportToWord()
            dt.Dispose()
        Else 
            'ScriptManager.RegisterClientScriptBlock(Me.Page, GetType(Page), "window_close", "alert('查無資料');window.close();void(0);", True)
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "「查無資料」", "SAL1105_01.aspx")
        End If
    End Sub
#End Region



End Class
