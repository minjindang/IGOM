Imports FSCPLM.Logic
Imports System.Data

Partial Class MAT2202_02
    Inherits System.Web.UI.Page

    Dim InventoryDet As InventoryDet = New InventoryDet()
    Dim tbMaterial_id1 As String = ""
    Dim tbMaterial_id2 As String = ""
    Dim UcDate1 As String = ""
    Dim UcDate2 As String = ""
    Dim pagerowcnt As Integer = 0
    Dim Sdate As String = ""
    Dim Edate As String = ""
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not String.IsNullOrEmpty(Request("tb1")) Then
            tbMaterial_id1 = Request("tb1").ToString()
        End If
        If Not String.IsNullOrEmpty(Request("tb2")) Then
            tbMaterial_id2 = Request("tb2").ToString
        End If
        If Not String.IsNullOrEmpty(Request("tb3")) Then
            UcDate1 = Request("tb3").ToString()
        End If
        If Not String.IsNullOrEmpty(Request("tb4")) Then
            UcDate2 = Request("tb4").ToString()
        End If
        If Not String.IsNullOrEmpty(Request("pagerowcnt")) Then
            pagerowcnt = Integer.Parse(Request("pagerowcnt"))
        End If
        PrintBtn_Click(tbMaterial_id1, tbMaterial_id2, UcDate1, UcDate2, pagerowcnt)
    End Sub

    Public Sub Finddate(ByVal tb3 As String, ByVal tb4 As String)

    End Sub

    Public Sub PrintBtn_Click(ByVal tbMaterial_id1 As String, ByVal tbMaterial_id2 As String, ByVal UcDate1 As String, _
                     ByVal UcDate2 As String, ByVal pagerowcnt As Integer)

        Dim DT As DataTable = New DataTable()
        DT = CType((InventoryDet.MAT2202select(tbMaterial_id1, tbMaterial_id2, UcDate1, UcDate2)), DataTable)

        If DT Is Nothing OrElse DT.Rows.Count <= 0 Then
            CommonFun.MsgShow(Me, CommonFun.Msg.QueryNothing, "", "MAT2202_01.aspx")
            Return
        End If

        If Not String.IsNullOrEmpty(Request("tb3")) Then
            Sdate = Request("tb3").ToString()
        Else
            Sdate = DT.Rows(0)("mindate").ToString()
        End If
        If Not String.IsNullOrEmpty(Request("tb4")) Then
            Edate = Request("tb4")
        Else
            Edate = DT.Rows(0)("maxdate").ToString()
        End If
        DT.Columns.Add("P4", GetType(System.String))
        Dim theDTReport As CommonLib.DTReport
        Dim strParam(5) As String
        Dim maxpageRowcnt As Integer = pagerowcnt
        Dim maxpagecnt As String = ""
        If (DT.Rows.Count Mod maxpageRowcnt) <> 0 Then
            maxpagecnt = (Integer.Parse(DT.Rows.Count \ maxpageRowcnt) + 1).ToString()
        Else
            maxpagecnt = (Integer.Parse(DT.Rows.Count \ maxpageRowcnt)).ToString()
        End If

        For i As Integer = 0 To DT.Rows.Count - 1
            DT.Rows(i).Item("P4") = (i \ maxpageRowcnt) + 1
        Next
        Dim reportUtil As New CommonLib.ReportUtil(DT)
        reportUtil.SetCurrentPage(pagerowcnt)

        DT.AcceptChanges()
        strParam(0) = Right("000" & Today.Year - 1911, 3) & "/" & Today.ToString("MM/dd")
        strParam(1) = LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name)
        strParam(2) = ""
        strParam(3) = maxpagecnt
        strParam(4) = Sdate
        strParam(5) = Edate

        theDTReport = New CommonLib.DTReport(Server.MapPath("~/Report/MAT/MAT2202.mht"), DT)
        'theDTReport.breakPage = "P4"
        theDTReport.Param = strParam  '將參數代入
        theDTReport.ExportFileName = "物品盤點後調整報表"
        theDTReport.PageGroupColumns = reportUtil.Group
        theDTReport.PageGroupKeyColumns = reportUtil.Group
        theDTReport.ExportToWord()
        DT.Dispose()
    End Sub

End Class
