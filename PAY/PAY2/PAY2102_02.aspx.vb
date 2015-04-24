Imports System.Data
Imports FSCPLM.Logic
Imports PAY.Logic
Partial Class PAY2_PAY2102_02
    Inherits BaseWebForm

#Region " 初始化"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not (IsPostBack) Then
            Dim PettyCash_nosS As String = ""
            Dim PettyCash_nosE As String = ""
            Dim Beneficiary_id As String = ""
            Dim Year As String = ""
            Dim Type As String = ""
            Dim pagerowcnt As Integer = 25
            If Not String.IsNullOrEmpty(Server.HtmlEncode(Request("PettyCash_nosS"))) Then
                PettyCash_nosS = Server.HtmlEncode(Request("PettyCash_nosS").ToString())
            End If
            If Not String.IsNullOrEmpty(Server.HtmlEncode(Request("PettyCash_nosE"))) Then
                PettyCash_nosE = Server.HtmlEncode(Request("PettyCash_nosE").ToString())
            End If
            If Not String.IsNullOrEmpty(Server.HtmlEncode(Request("Beneficiary_id"))) Then
                Beneficiary_id = Server.HtmlEncode(Request("Beneficiary_id").ToString())
            End If
            If Not String.IsNullOrEmpty(Server.HtmlEncode(Request("pagerowcnt"))) Then
                pagerowcnt = Integer.Parse(Server.HtmlEncode(Request("pagerowcnt")))
            End If
            If Not String.IsNullOrEmpty(Server.HtmlEncode(Request("Year"))) Then
                Year = Server.HtmlEncode(Request("Year"))
            End If
            If Not String.IsNullOrEmpty(Server.HtmlEncode(Request("Type"))) Then
                Type = Server.HtmlEncode(Request("Type"))
            End If
            PrintBtn_Click(PettyCash_nosS, PettyCash_nosE, Beneficiary_id, pagerowcnt, Year, Type)
        End If
    End Sub
#End Region
#Region " 列印"
    Protected Sub PrintBtn_Click(ByVal PettyCash_nosS As String, _
                                 ByVal PettyCash_nosE As String, _
                                 ByVal Beneficiary_id As String, _
                                 ByVal pagerowcnt As Integer, _
                                 ByVal Year As String, _
                                 ByVal Type As String)

        '____________________________________________________________________________________________________________________________

        Dim db As New DataTable '主資料
        Dim dc As New DataTable '機關
        Dim mc As PAY2102 = New PAY2102()
        Dim theDTReport As CommonLib.DTReport
        Dim strParam(7) As String '宣告字串陣列
        Dim maxpageRowcnt As Integer = pagerowcnt
        Dim maxpagecnt As String = ""
        Dim P5 As String = ""
        If Type = "1" Then '受款人支用清單(員工及台灣銀行廠商)
            db = mc.Select_01_01(PettyCash_nosS, PettyCash_nosE, Beneficiary_id, Year)
            If db.Rows.Count > 0 Then
                db.Columns.Add("P4", GetType(System.String))
                db.Rows.Add.Item("P4") = ""
                For i As Integer = 0 To db.Rows.Count - 1
                    db.Rows(i).Item("P4") = (i \ maxpageRowcnt) + 1
                Next
                If (db.Rows.Count Mod maxpageRowcnt) <> 0 Then
                    maxpagecnt = Server.HtmlEncode((Integer.Parse(db.Rows.Count \ maxpageRowcnt) + 1).ToString())
                Else
                    maxpagecnt = Server.HtmlEncode((Integer.Parse(db.Rows.Count \ maxpageRowcnt)).ToString())
                End If
                strParam(0) = Server.HtmlEncode(Right("000" & Today.Year - 1911, 3) & "/" & Today.ToString("MM/dd")) '製表日期
                strParam(1) = Server.HtmlEncode(LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name)) '製表人
                strParam(3) = maxpagecnt
                strParam(4) = PettyCash_nosS
                strParam(5) = PettyCash_nosE
                theDTReport = New CommonLib.DTReport(Server.MapPath("~/Report/PAY/PAY2102_01.mht"), db)
                'theDTReport.breakPage = "P4" '依P4分頁
                theDTReport.ExportFileName = "零用金列印-受款人支用清單"
                theDTReport.Param = strParam
                theDTReport.ExportToWord()
                'theDTReport.ExportToHTML(Server.MapPath("~/Report/PAY/PAY2102_01.mht"))
                db.Dispose()
            Else
                CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "查無零用金列印資料", "PAY2102_01.aspx")
            End If
        ElseIf Type = "2" Then '大批匯款明細表(非台灣銀行廠商)
            db = mc.Select_02_01(PettyCash_nosS, PettyCash_nosE, Beneficiary_id, Year)
            If db.Rows.Count > 0 Then

                'db.Columns.Add("P4", GetType(System.String))
                db.Columns.Add("SenderName", GetType(System.String))
                db.Columns.Add("ROWID", GetType(System.String))
                For i As Integer = 0 To db.Rows.Count - 1
                    db.Rows(i).Item("ROWID") = i + 1
                    ' db.Rows(i).Item("P4") = (i \ maxpageRowcnt) + 1
                    
                    db.Rows(i).Item("SenderName") = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode) & "零用金專戶"

                Next
                If (db.Rows.Count Mod maxpageRowcnt) <> 0 Then
                    maxpagecnt = Server.HtmlEncode((Integer.Parse(db.Rows.Count \ maxpageRowcnt) + 1).ToString())
                Else
                    maxpagecnt = Server.HtmlEncode((Integer.Parse(db.Rows.Count \ maxpageRowcnt)).ToString())
                End If
                P5 &= "零用金序號：" & Year & "年度"
                If Not String.IsNullOrEmpty(PettyCash_nosS) Then
                    P5 &= PettyCash_nosS & "至"
                End If
                If Not String.IsNullOrEmpty(PettyCash_nosE) Then
                    P5 &= PettyCash_nosE
                End If
                'db.Rows.Add.Item("P4") = "1"
                strParam(0) = Server.HtmlEncode(Right("000" & Today.Year - 1911, 3) & "/" & Today.ToString("MM/dd")) '製表日期
                strParam(1) = Server.HtmlEncode(LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name)) '製表人
                strParam(3) = maxpagecnt
                strParam(4) = P5
                theDTReport = New CommonLib.DTReport(Server.MapPath("~/Report/PAY/PAY2102_02.mht"), db)
                theDTReport.ExportFileName = "零用金列印-大批匯款明細表"
                theDTReport.Param = strParam
                theDTReport.ExportToWord()
                db.Dispose()
            Else
                CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "查無大批匯款明細資料", "PAY2102_01.aspx")
            End If
        End If
        '____________________________________________________________________________________________________________________________
    End Sub
#End Region
End Class


