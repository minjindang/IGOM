Imports System.Data
'Imports FSCPLM.Logic
Imports FSCPLM.Logic
Partial Class MAT2201_02
    Inherits BaseWebForm
    Dim dbA As DataTable
    Dim In_dateS As String = ""
    Dim In_dateE As String = ""
    Dim Material_idS As String = ""
    Dim Material_idE As String = ""
    Dim pagerowcnt As Integer = 0
#Region " 初始化"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not (IsPostBack) Then
            If Not String.IsNullOrEmpty(Server.HtmlEncode(Request("Material_idS"))) Then
                Material_idS = Server.HtmlEncode(Request("Material_idS").ToString())
            End If
            If Not String.IsNullOrEmpty(Server.HtmlEncode(Request("Material_idE"))) Then
                Material_idE = Server.HtmlEncode(Request("Material_idE").ToString())
            End If
            If Not String.IsNullOrEmpty(Server.HtmlEncode(Request("pagerowcnt"))) Then
                pagerowcnt = Integer.Parse(Server.HtmlEncode(Request("pagerowcnt")))
            End If
            PrintBtn_Click(Material_idS, Material_idE, pagerowcnt)
        End If

    End Sub
#End Region
#Region " 列印"
    Protected Sub PrintBtn_Click(ByVal Material_idS As String, ByVal Material_idE As String, ByVal pagerowcnt As Integer)
        Dim db As New DataTable
        Dim mc As Material_main = New Material_main()
        db = mc.MAT2201SelectData(Material_idS, Material_idE)
        db.Columns.Add("P4", GetType(System.String)) '加入P4欄位總頁數
        Dim theDTReport As CommonLib.DTReport
        Dim strParam(3) As String '宣告字串陣列
        Dim maxpageRowcnt As Integer = pagerowcnt
        Dim maxpagecnt As String = ""
        If (db.Rows.Count Mod maxpageRowcnt) <> 0 Then
            maxpagecnt = Server.HtmlEncode((Integer.Parse(db.Rows.Count \ maxpageRowcnt) + 1).ToString())
        Else
            maxpagecnt = Server.HtmlEncode((Integer.Parse(db.Rows.Count \ maxpageRowcnt)).ToString())
        End If
        For i As Integer = 0 To db.Rows.Count - 1
            db.Rows(i).Item("P4") = (i \ maxpageRowcnt) + 1
        Next
        Dim reportUtil As New CommonLib.ReportUtil(db)
        reportUtil.SetCurrentPage(34)

        strParam(0) = Server.HtmlEncode(Right("000" & Today.Year - 1911, 3) & "/" & Today.ToString("MM/dd")) '製表日期
        strParam(1) = Server.HtmlEncode(LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name)) '製表人
        strParam(2) = Server.HtmlEncode(LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)) '單位
        strParam(3) = reportUtil.GetTotalPage(pagerowcnt) '總頁次
        theDTReport = New CommonLib.DTReport(Server.MapPath("~/Report/MAT/MAT2201.mht"), db)
        'theDTReport.breakPage = "P4"
        theDTReport.Param = strParam
        theDTReport.ExportFileName = "物品盤點報表"
        theDTReport.PageGroupColumns = reportUtil.Group
        theDTReport.PageGroupKeyColumns = reportUtil.Group

        theDTReport.ExportToWord()
        db.Dispose()
    End Sub
#End Region
End Class


