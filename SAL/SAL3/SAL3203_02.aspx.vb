Imports System.Data
Imports FSCPLM.Logic
Imports SALARY.Logic
Partial Class SAL1_SAL3203_02
    Inherits System.Web.UI.Page

#Region " 初始化"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim Cost_date As String = ""
        Dim User_id As String = ""
        Dim pagerowcnt As Integer = 1
        Dim db As DataTable = Session("SunPrintdb")
        If Not (IsPostBack) Then
            If Not String.IsNullOrEmpty(Server.HtmlEncode(Request("User_id"))) Then
                User_id = Server.HtmlEncode(Request("User_id").ToString())
            End If
            PrintBtn_Click(User_id, pagerowcnt, db)
            Session("SunPrintdb") = New DataTable
        End If
    End Sub
#End Region
#Region " 列印"
    Protected Sub PrintBtn_Click(ByVal User_id As String, ByVal pagerowcnt As Integer, ByVal db As DataTable)
        Dim strParam(4) As String '宣告字串陣列
        Dim test As String = "1" '宣告字串陣列
        Dim maxpageRowcnt As Integer = pagerowcnt
        Dim maxpagecnt As String = ""
        Dim theDTReport As CommonLib.DTReport1
        If Not db Is Nothing Then
            Dim r As DataRow
            db.Columns.Add("Unit", GetType(System.String)) '加入Unit
            db.Columns.Add("Ten", GetType(System.String)) '加入Ten
            db.Columns.Add("Hundred", GetType(System.String)) '加入Hundred
            db.Columns.Add("Thousand", GetType(System.String)) '加入Thousand
            db.Columns.Add("TenThousand", GetType(System.String)) '加入TenThousand
            db.Columns.Add("HundredThousand", GetType(System.String)) '加入HundredThousand
            db.Columns.Add("Million", GetType(System.String)) '加入Million
            db.Columns.Add("TenMillion", GetType(System.String)) '加入TenMillion
            db.Columns.Add("HundredMillion", GetType(System.String)) '加入HundredMillion
            db.Columns.Add("P4", GetType(System.String)) '加入P4
            r = db.NewRow() 'theDTReport會吃掉第一筆資料，故新增一筆空白列。
            r("P4") = "0"
            db.Rows.Add(r)
            For i As Integer = 0 To db.Rows.Count - 1
                db.Rows(i).Item("P4") = i + 1
                If Convert.ToInt32(db.Rows(i).Item("Apply_amt").ToString.Length) = 1 Then '元
                    db.Rows(i).Item("Unit") = db.Rows(i).Item("Apply_amt").ToString.Substring(0, 1)
                    db.Rows(i).Item("Ten") = "$"
                End If
                If Convert.ToInt32(db.Rows(i).Item("Apply_amt").ToString.Length) = 2 Then '十
                    db.Rows(i).Item("Unit") = db.Rows(i).Item("Apply_amt").ToString.Substring(1, 1)
                    db.Rows(i).Item("Ten") = db.Rows(i).Item("Apply_amt").ToString.Substring(0, 1)
                    db.Rows(i).Item("Hundred") = "$"
                End If
                If Convert.ToInt32(db.Rows(i).Item("Apply_amt").ToString.Length) = 3 Then '百
                    db.Rows(i).Item("Unit") = db.Rows(i).Item("Apply_amt").ToString.Substring(2, 1)
                    db.Rows(i).Item("Ten") = db.Rows(i).Item("Apply_amt").ToString.Substring(1, 1)
                    db.Rows(i).Item("Hundred") = db.Rows(i).Item("Apply_amt").ToString.Substring(0, 1)
                    db.Rows(i).Item("Thousand") = "$"
                End If
                If Convert.ToInt32(db.Rows(i).Item("Apply_amt").ToString.Length) = 4 Then '千
                    db.Rows(i).Item("Unit") = db.Rows(i).Item("Apply_amt").ToString.Substring(3, 1)
                    db.Rows(i).Item("Ten") = db.Rows(i).Item("Apply_amt").ToString.Substring(2, 1)
                    db.Rows(i).Item("Hundred") = db.Rows(i).Item("Apply_amt").ToString.Substring(1, 1)
                    db.Rows(i).Item("Thousand") = db.Rows(i).Item("Apply_amt").ToString.Substring(0, 1)
                    db.Rows(i).Item("TenThousand") = "$"
                End If
                If Convert.ToInt32(db.Rows(i).Item("Apply_amt").ToString.Length) = 5 Then '萬
                    db.Rows(i).Item("Unit") = db.Rows(i).Item("Apply_amt").ToString.Substring(4, 1)
                    db.Rows(i).Item("Ten") = db.Rows(i).Item("Apply_amt").ToString.Substring(3, 1)
                    db.Rows(i).Item("Hundred") = db.Rows(i).Item("Apply_amt").ToString.Substring(2, 1)
                    db.Rows(i).Item("Thousand") = db.Rows(i).Item("Apply_amt").ToString.Substring(1, 1)
                    db.Rows(i).Item("TenThousand") = db.Rows(i).Item("Apply_amt").ToString.Substring(0, 1)
                    db.Rows(i).Item("HundredThousand") = "$"
                End If
                If Convert.ToInt32(db.Rows(i).Item("Apply_amt").ToString.Length) = 6 Then '十萬
                    db.Rows(i).Item("Unit") = db.Rows(i).Item("Apply_amt").ToString.Substring(5, 1)
                    db.Rows(i).Item("Ten") = db.Rows(i).Item("Apply_amt").ToString.Substring(4, 1)
                    db.Rows(i).Item("Hundred") = db.Rows(i).Item("Apply_amt").ToString.Substring(3, 1)
                    db.Rows(i).Item("Thousand") = db.Rows(i).Item("Apply_amt").ToString.Substring(2, 1)
                    db.Rows(i).Item("TenThousand") = db.Rows(i).Item("Apply_amt").ToString.Substring(1, 1)
                    db.Rows(i).Item("HundredThousand") = db.Rows(i).Item("Apply_amt").ToString.Substring(0, 1)
                    db.Rows(i).Item("Million") = "$"
                End If
                If Convert.ToInt32(db.Rows(i).Item("Apply_amt").ToString.Length) = 7 Then '百萬
                    db.Rows(i).Item("Unit") = db.Rows(i).Item("Apply_amt").ToString.Substring(6, 1)
                    db.Rows(i).Item("Ten") = db.Rows(i).Item("Apply_amt").ToString.Substring(5, 1)
                    db.Rows(i).Item("Hundred") = db.Rows(i).Item("Apply_amt").ToString.Substring(4, 1)
                    db.Rows(i).Item("Thousand") = db.Rows(i).Item("Apply_amt").ToString.Substring(3, 1)
                    db.Rows(i).Item("TenThousand") = db.Rows(i).Item("Apply_amt").ToString.Substring(2, 1)
                    db.Rows(i).Item("HundredThousand") = db.Rows(i).Item("Apply_amt").ToString.Substring(1, 1)
                    db.Rows(i).Item("Million") = db.Rows(i).Item("Apply_amt").ToString.Substring(0, 1)
                    db.Rows(i).Item("TenMillion") = "$"
                End If
                If Convert.ToInt32(db.Rows(i).Item("Apply_amt").ToString.Length) = 8 Then '千萬
                    db.Rows(i).Item("Unit") = db.Rows(i).Item("Apply_amt").ToString.Substring(7, 1)
                    db.Rows(i).Item("Ten") = db.Rows(i).Item("Apply_amt").ToString.Substring(6, 1)
                    db.Rows(i).Item("Hundred") = db.Rows(i).Item("Apply_amt").ToString.Substring(5, 1)
                    db.Rows(i).Item("Thousand") = db.Rows(i).Item("Apply_amt").ToString.Substring(4, 1)
                    db.Rows(i).Item("TenThousand") = db.Rows(i).Item("Apply_amt").ToString.Substring(3, 1)
                    db.Rows(i).Item("HundredThousand") = db.Rows(i).Item("Apply_amt").ToString.Substring(2, 1)
                    db.Rows(i).Item("Million") = db.Rows(i).Item("Apply_amt").ToString.Substring(1, 1)
                    db.Rows(i).Item("TenMillion") = db.Rows(i).Item("Apply_amt").ToString.Substring(0, 1)
                    db.Rows(i).Item("HundredMillion") = "$"
                End If
                If Convert.ToInt32(db.Rows(i).Item("Apply_amt").ToString.Length) = 9 Then '億
                    db.Rows(i).Item("Unit") = db.Rows(i).Item("Apply_amt").ToString.Substring(8, 1)
                    db.Rows(i).Item("Ten") = db.Rows(i).Item("Apply_amt").ToString.Substring(7, 1)
                    db.Rows(i).Item("Hundred") = db.Rows(i).Item("Apply_amt").ToString.Substring(6, 1)
                    db.Rows(i).Item("Thousand") = db.Rows(i).Item("Apply_amt").ToString.Substring(5, 1)
                    db.Rows(i).Item("TenThousand") = db.Rows(i).Item("Apply_amt").ToString.Substring(4, 1)
                    db.Rows(i).Item("HundredThousand") = db.Rows(i).Item("Apply_amt").ToString.Substring(3, 1)
                    db.Rows(i).Item("Million") = db.Rows(i).Item("Apply_amt").ToString.Substring(2, 1)
                    db.Rows(i).Item("TenMillion") = db.Rows(i).Item("Apply_amt").ToString.Substring(1, 1)
                    db.Rows(i).Item("HundredMillion") = db.Rows(i).Item("Apply_amt").ToString.Substring(0, 1)
                End If
            Next
            If (db.Rows.Count Mod maxpageRowcnt) <> 0 Then
                maxpagecnt = Server.HtmlEncode((Integer.Parse(db.Rows.Count \ maxpageRowcnt) + 1).ToString())
            Else
                maxpagecnt = Server.HtmlEncode((Integer.Parse(db.Rows.Count \ maxpageRowcnt)).ToString())
            End If
            strParam(0) = Server.HtmlEncode(Right("000" & Today.Year - 1911, 3) & "/" & Today.ToString("MM/dd")) '製表日期
            strParam(1) = Server.HtmlEncode(LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name)) '製表人
            strParam(2) = Server.HtmlEncode(LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)) '單位
            strParam(3) = maxpagecnt '目前頁次
            theDTReport = New CommonLib.DTReport1(Server.MapPath("~/Report/SAL/SAL3203.mht"), db)
            theDTReport.breakPage = "P4"
            theDTReport.Param = strParam
            theDTReport.ExportFileName = "物品入庫清單"
            theDTReport.ExportToHTML(Server.MapPath("~/Report/SAL/SAL3203.mht"))
        Else
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "無資料")
        End If
    End Sub
#End Region
End Class


