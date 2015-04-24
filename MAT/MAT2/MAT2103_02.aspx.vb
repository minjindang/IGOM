Imports FSCPLM.Logic
Imports System.Data

Partial Class MAT2103_02
    Inherits System.Web.UI.Page
    Dim id1 As String = ""
    Dim id2 As String = ""
    Dim pagerowcnt As Integer = 0
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not String.IsNullOrEmpty(Request("id1")) Then
            id1 = Request("id1").ToString()
        End If
        If Not String.IsNullOrEmpty(Request("id2")) Then
            id2 = Request("id2").ToString()
        End If
        If Not String.IsNullOrEmpty(Request("pagerowcnt")) Then
            pagerowcnt = Integer.Parse(Request("pagerowcnt"))
        End If

        print(id1, id2, pagerowcnt)
    End Sub

    Protected Sub print(ByVal id1 As String, ByVal id2 As String, ByVal pagerowcnt As Integer)


        Dim dt As DataTable = New DataTable()

        Dim Material As Material_main = New Material_main()
        dt = CType((Material.GetMatData(id1, id2)), DataTable)
        dt.Columns.Add("P4", GetType(System.String))

        Dim theDTReport As CommonLib.DTReport
        Dim strParam(4) As String
        '每頁最大行數
        Dim maxpageRowcnt As Integer = pagerowcnt
        '總頁數
        Dim maxpagecnt As String = ""
        If (dt.Rows.Count Mod maxpageRowcnt) <> 0 Then
            maxpagecnt = (Integer.Parse(dt.Rows.Count \ maxpageRowcnt) + 1).ToString()
        Else
            maxpagecnt = (Integer.Parse(dt.Rows.Count \ maxpageRowcnt)).ToString()
        End If

        For i As Integer = 0 To dt.Rows.Count - 1
            dt.Rows(i).Item("P4") = (i \ maxpageRowcnt) + 1
        Next
        dt.AcceptChanges()
        strParam(0) = Right("000" & Today.Year - 1911, 3) & "/" & Today.ToString("MM/dd")
        strParam(1) = LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name)
        strParam(2) = ""
        strParam(3) = maxpagecnt

        theDTReport = New CommonLib.DTReport(Server.MapPath("~/Report/MAT/MAT2103.mht"), dt)
        theDTReport.Param = strParam  '將參數代入
        theDTReport.ExportFileName = "物品庫存量查詢"
        theDTReport.ExportToWord()

        dt.Dispose()

    End Sub
End Class
