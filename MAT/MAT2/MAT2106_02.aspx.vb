Imports FSCPLM.Logic
Imports System.Data

Partial Class MAT2106_02
    Inherits BaseWebForm

    Dim MAT2106 As ApplyMaterialDet = New ApplyMaterialDet() 
    Dim ucType As String = ""
    Dim ddlDepart_id As String = ""
    Dim ddlUser_name As String = ""
    Dim pagerowcnt As Integer = 0

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not String.IsNullOrEmpty(Request("tb1")) Then
            ucType = Request("tb1").ToString()
        End If
        If Not String.IsNullOrEmpty(Request("tb2")) Then
            ddlDepart_id = Request("tb2").ToString
        End If
        If Not String.IsNullOrEmpty(Request("tb3")) Then
            ddlUser_name = Request("tb3").ToString()
        End If
        If Not String.IsNullOrEmpty(Request("pagerowcnt")) Then
            pagerowcnt = Integer.Parse(Request("pagerowcnt"))
        End If


        Print(ucType, ddlDepart_id, ddlUser_name, pagerowcnt)
    End Sub

    Public Sub Print(ByVal ucType As String, ByVal ddlDepart_id As String, ByVal ddlUser_name As String, ByVal pagerowcnt As Integer)

        Dim DT As DataTable = New DataTable()
        DT = MAT2106.MAT2106_Print(ucType, ddlDepart_id, ddlUser_name, LoginManager.OrgCode)

        Dim theDTReport As CommonLib.DTReport
        Dim strParam(3) As String
        Dim maxpagecnt As String = ""
        Dim Mindate As String = ""
        Dim Maxdate As String = ""
        Dim TitleName As String = IIf(ucType.Equals("001"), "個人領用物品明細表", "單位領用物品明細表")

        If DT Is Nothing OrElse DT.Rows.Count < 1 Then
            CommonFun.MsgShow(Me, CommonFun.Msg.QueryNothing, "", "MAT2106_01.aspx")
        Else

            Mindate = DT.Select("Mindate <> ''").CopyToDataTable().Compute("Min(Mindate)", "") 'DT.Rows(0)("Mindate").ToString()
            Maxdate = DT.Select("Maxdate <> ''").CopyToDataTable().Compute("Max(Maxdate)", "") 'DT.Rows(0)("Maxdate").ToString()

            DT.AcceptChanges()
            strParam(0) = Server.HtmlEncode(Right("000" & Today.Year - 1911, 3) & "/" & Today.ToString("MM/dd")) '製表日期
            strParam(1) = Server.HtmlEncode(LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name)) '製表人
            strParam(2) = Mindate + "至" + Maxdate '領用日期起~迄
            strParam(3) = TitleName

            Dim test1() As String = {"User_id", "User_name"}
            Dim test2() As String = {"Depart_name"}

            If DT.Rows(0).Item("Code_desc1") = "個人領物" Then

                theDTReport = New CommonLib.DTReport(Server.MapPath("~/Report/MAT/MAT2106.mht"), DT)
                theDTReport.PageGroupColumns = test1
                theDTReport.PageGroupKeyColumns = test1
                theDTReport.Param = strParam  '將參數代入
                theDTReport.ExportFileName = "個人領用物品明細表"
                theDTReport.ExportToWord()
                DT.Dispose()

            Else

                theDTReport = New CommonLib.DTReport(Server.MapPath("~/Report/MAT/MAT2106_1.mht"), DT)
                theDTReport.PageGroupColumns = test2
                theDTReport.PageGroupKeyColumns = test2
                theDTReport.Param = strParam  '將參數代入
                theDTReport.ExportFileName = "單位領用物品明細表"
                theDTReport.ExportToWord()
                DT.Dispose()
            End If
        End If

    End Sub

End Class
