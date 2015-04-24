Imports System.Data
Imports FSCPLM.Logic

Partial Class MAT2110_02
    Inherits System.Web.UI.Page



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim year As String = ""
        Dim month As String = ""
        If Not String.IsNullOrEmpty(Request("year")) Then
            year = Request("year").ToString()
        End If
        If Not String.IsNullOrEmpty(Request("month")) Then
            month = Request("month").ToString()
        End If
        print(year, month)

    End Sub

    Protected Sub print(year As String, month As String)
        Dim dao As New MAT2110DAO
        Dim yearmonth As String = year & month
        Dim dt As DataTable = dao.getPrintData(LoginManager.OrgCode, yearmonth)


        If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
            dt.Columns.Add("P3", GetType(System.String))

            Dim theDTReport As CommonLib.DTReport
            Dim strParam(3) As String
            Dim maxpageRowcnt As Integer = 25
            Dim maxpagecnt As String = ""

            'Dim reportUtil As New CommonLib.ReportUtil(dt)
            'reportUtil.SetCurrentPage(maxpageRowcnt)
 

            dt.AcceptChanges()
            strParam(0) = Right("000" & Today.Year - 1911, 3) & "/" & Today.ToString("MM/dd")
            strParam(1) = LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name)
            strParam(2) = year & "年" & month & "月"
            'strParam(3) = reportUtil.GetTotalPage(maxpageRowcnt) '總頁次
            theDTReport = New CommonLib.DTReport(Server.MapPath("~/Report/MAT/MAT2110.mht"), dt)
            theDTReport.Param = strParam
            theDTReport.ExportFileName = "各項物品收支月報表"
            'theDTReport.PageGroupColumns = reportUtil.Group
            'stheDTReport.PageGroupKeyColumns = reportUtil.Group
            theDTReport.ExportToWord()

            dt.Dispose()
        Else
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "查無資料。", "MAT2110_01.aspx")
            'ScriptManager.RegisterClientScriptBlock(Me.Page, GetType(Page), "window_close", "alert('查無資料');window.close();void(0);", True)
        End If


      

    End Sub
End Class
