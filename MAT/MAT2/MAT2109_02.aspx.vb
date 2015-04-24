Imports System.Data
Imports FSCPLM.Logic
Imports MAT.Logic
Partial Class MAT2_MAT2109_02
    Inherits BaseWebForm

#Region " 初始化"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not (IsPostBack) Then
            Dim ReceiveDayS As String = ""
            Dim ReceiveDayE As String = ""
            Dim Approved_idS As String = ""
            Dim Approved_idE As String = ""
            Dim pagerowcnt As Integer = 25
            If Not String.IsNullOrEmpty(Server.HtmlEncode(Request("ReceiveDayS"))) Then
                ReceiveDayS = Server.HtmlEncode(Request("ReceiveDayS").ToString())
            End If
            If Not String.IsNullOrEmpty(Server.HtmlEncode(Request("ReceiveDayE"))) Then
                ReceiveDayE = Server.HtmlEncode(Request("ReceiveDayE").ToString())
            End If
            If Not String.IsNullOrEmpty(Server.HtmlEncode(Request("Approved_idS"))) Then
                Approved_idS = Server.HtmlEncode(Request("Approved_idS").ToString())
            End If
            If Not String.IsNullOrEmpty(Server.HtmlEncode(Request("Approved_idE"))) Then
                Approved_idE = Server.HtmlEncode(Request("Approved_idE").ToString())
            End If
            If Not String.IsNullOrEmpty(Server.HtmlEncode(Request("pagerowcnt"))) Then
                pagerowcnt = Integer.Parse(Server.HtmlEncode(Request("pagerowcnt")))
            End If
            PrintBtn_Click(ReceiveDayS, _
                           ReceiveDayE, _
                           Approved_idS, _
                           Approved_idE, _
                           pagerowcnt)
        End If
    End Sub
#End Region
#Region " 列印"
    Protected Sub PrintBtn_Click(ByVal ReceiveDayS As String, _
                                 ByVal ReceiveDayE As String, _
                                 ByVal Approved_idS As String, _
                                 ByVal Approved_idE As String, _
                                 ByVal pagerowcnt As Integer)

        '____________________________________________________________________________________________________________________________

        Dim db As New DataTable '主資料
        Dim dc As New DataTable '分頁用
        Dim mc As MAT2109 = New MAT2109()
        Dim theDTReport As CommonLib.DTReport
        Dim strParam(1) As String '宣告字串陣列

        db = mc.MAT2109Select(Approved_idS, _
                              Approved_idE, _
                              ReceiveDayS, _
                              ReceiveDayE)

        If db.Rows.Count > 0 Then
            For i As Integer = 0 To db.Rows.Count - 1
                db.Rows(i)("Unit_code") = New FSC.Logic.Org().GetDepartName(db.Rows(i)("OrgCode").ToString(), db.Rows(i)("Unit_code").ToString())
                If Not String.IsNullOrEmpty(db.Rows(i).Item("Merge_Flowid").ToString) Then
                    For j As Integer = 0 To db.Rows.Count - 1 '把有Merge_Flow_id的那筆資料的P4改為符合同樣Flow_id的P4欄位
                        If db.Rows(i).Item("Merge_Flowid") = db.Rows(j).Item("Flow_id") Then
                            db.Rows(i).Item("Flow_id") = db.Rows(i).Item("Merge_Flowid")
                        End If
                    Next
                End If
            Next

            Dim group(2) As String
            group(0) = "Unit_code"
            group(1) = "Flow_id"
            group(2) = "Out_date"

            Dim reportUtil As New CommonLib.ReportUtil(db)
            reportUtil.SetCurrentPage(pagerowcnt)

            strParam(0) = Server.HtmlEncode(Right("000" & Today.Year - 1911, 3) & "/" & Today.ToString("MM/dd")) '製表日期
            strParam(1) = Server.HtmlEncode(LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name)) '製表人

            theDTReport = New CommonLib.DTReport(Server.MapPath("~/Report/MAT/MAT2109.mht"), db)
            theDTReport.Param = strParam
            theDTReport.ExportFileName = "領物核准清單表"
            theDTReport.PageGroupColumns = group
            theDTReport.PageGroupKeyColumns = group
            theDTReport.ExportToWord()
            db.Dispose()
        Else
            CommonFun.MsgShow(Me, CommonFun.Msg.QueryNothing, "", "MAT2109_01.aspx")
        End If


     

        '____________________________________________________________________________________________________________________________
    End Sub
#End Region
End Class


