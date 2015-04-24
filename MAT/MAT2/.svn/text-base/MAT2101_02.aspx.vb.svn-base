Imports FSCPLM.Logic
Imports System.Data

Partial Class MAT2101_02
    Inherits BaseWebForm

    Dim pagerowcnt As Integer = 0
    Dim RadioSelect As String = ""
    Dim id1 As String = ""
    Dim id2 As String = ""
    Dim outDate1 As String = ""
    Dim outDate2 As String = ""
    Dim ddlSelect As String = ""
    Dim ddlUser_name As String = ""

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not String.IsNullOrEmpty(Request("pagerowcnt")) Then
            pagerowcnt = Integer.Parse(Request("pagerowcnt"))
        End If
        If Not String.IsNullOrEmpty(Request("RadioSelect")) Then
            RadioSelect = Request("RadioSelect").ToString
        End If
        If Not String.IsNullOrEmpty(Request("id1")) Then
            id1 = Request("id1").ToString
        End If
        If Not String.IsNullOrEmpty(Request("id2")) Then
            id2 = Request("id2").ToString
        End If
        If Not String.IsNullOrEmpty(Request("outDate1")) Then
            outDate1 = Request("outDate1").ToString
        End If
        If Not String.IsNullOrEmpty(Request("outDate2")) Then
            outDate2 = Request("outDate2").ToString
        End If
        If Not String.IsNullOrEmpty(Request("ddlSelect")) Then
            ddlSelect = Request("ddlSelect").ToString
        End If
        If Not String.IsNullOrEmpty(Request("ddlUser_name")) Then
            ddlUser_name = Request("ddlUser_name").ToString
        End If

        print(pagerowcnt, RadioSelect, id1, id2, outDate1, outDate2, ddlSelect, ddlUser_name)

    End Sub

    Protected Sub print(ByVal pagerowcnt As Integer, ByVal radioselect As String, ByVal id1 As String, ByVal id2 As String, _
                        ByVal outdate1 As String, ByVal outdate2 As String, ByVal ddlselect As String, ByVal txtuid As String)

        Dim dt As DataTable = New DataTable
        Dim mat As MAT0317 = New MAT0317

        dt = mat.getApplyPrintMAT(radioselect, ddlselect, txtuid, id1, id2, outdate1, outdate2)
        dt.Columns.Add("P3", GetType(System.String))

        Dim theDTReport As CommonLib.DTReport
        Dim strParam(4) As String
        Dim maxpageRowcnt As Integer = pagerowcnt
        Dim maxpagecnt As String = ""

        If (dt.Rows.Count Mod maxpageRowcnt) <> 0 Then
            maxpagecnt = (Integer.Parse(dt.Rows.Count \ maxpageRowcnt) + 1).ToString
        Else
            maxpagecnt = (Integer.Parse(dt.Rows.Count \ maxpageRowcnt)).ToString
        End If

        For i As Integer = 0 To dt.Rows.Count - 1
            dt.Rows(i).Item("P3") = (i \ maxpageRowcnt) + 1
        Next

        dt.AcceptChanges()
        strParam(0) = Right("000" & Today.Year - 1911, 3) & " /" & Today.ToString("MM/dd")
        strParam(1) = LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name)
        strParam(2) = ""
        strParam(3) = maxpagecnt

        theDTReport = New CommonLib.DTReport(Server.MapPath("~/Report/MAT/MAT2101.mht"), dt)
        theDTReport.Param = strParam
        theDTReport.ExportFileName = "領用物品查詢"
        theDTReport.ExportToWord()

    End Sub


End Class
