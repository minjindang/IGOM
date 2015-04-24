Imports FSCPLM.Logic
Imports System.Data

Partial Class MAT1_MAT1107_02
    Inherits BaseWebForm

    Dim id1 As String = ""
    Dim id2 As String = ""
    Dim pagerowcnt As Integer = 0

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not String.IsNullOrEmpty(Request("pagerowcnt")) Then
            pagerowcnt = Integer.Parse(Request("pagerowcnt"))
        End If
        If Not String.IsNullOrEmpty(Request("id1")) Then
            id1 = Request("id1").ToString()
        End If
        If Not String.IsNullOrEmpty(Request("id2")) Then
            id2 = Request("id2").ToString()
        End If
        print(id1, id2, pagerowcnt)

    End Sub

    Protected Sub print(ByVal id1 As String, ByVal id2 As String, ByVal pagerowcnt As Integer)

        Dim dt As DataTable = New DataTable()
        Dim mat As Material_main = New Material_main

        dt = mat.GetMaterial(id1, id2)
        dt.Columns.Add("P3", GetType(System.String))

        Dim theDTReport As CommonLib.DTReport1
        Dim strParam(4) As String
        Dim maxpageRowcnt As Integer = pagerowcnt
        Dim maxpagecnt As String = ""

        '取得總頁數
        If (dt.Rows.Count Mod maxpageRowcnt) <> 0 Then
            maxpagecnt = (Integer.Parse(dt.Rows.Count \ maxpageRowcnt) + 1).ToString()
        Else
            maxpagecnt = (Integer.Parse(dt.Rows.Count \ maxpageRowcnt)).ToString()
        End If

        '取得分頁數P4
        For i As Integer = 0 To dt.Rows.Count - 1
            dt.Rows(i).Item("P3") = (i \ maxpageRowcnt) + 1
        Next

        dt.AcceptChanges()
        strParam(0) = Right("000" & Today.Year - 1911, 3) & "/" & Today.ToString("MM/dd")
        strParam(1) = LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name)
        strParam(2) = ""
        strParam(3) = maxpagecnt


        theDTReport = New CommonLib.DTReport1(Server.MapPath("~/Report/MAT/MAT1107.mht"), dt)
        theDTReport.breakPage = "P3"
        theDTReport.Param = strParam
        theDTReport.ExportFileName = "物品代碼、名稱對照表列印"
        theDTReport.ExportToHTML(Server.MapPath("~/Report/MAT/MAT1107.mht"))

        dt.Dispose()

    End Sub


End Class
