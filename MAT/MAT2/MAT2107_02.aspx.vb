Imports FSCPLM.Logic
Imports System.Data

Partial Class MAT2107_02
    Inherits BaseWebForm

    Dim MAT2107 As ApplyMaterialDet = New ApplyMaterialDet()
    Dim tbMaterial_id As String = ""
    Dim ddlDepart_id As String = ""
    Dim ddlUser_name As String = ""
    Dim UcDateS As String = ""
    Dim UcDateE As String = ""
    Dim pagerowcnt As Integer = 0

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not String.IsNullOrEmpty(Request("tb1")) Then
            tbMaterial_id = Request("tb1").ToString()
        End If
        If Not String.IsNullOrEmpty(Request("tb2")) Then
            ddlUser_name = Request("tb2").ToString
        End If
        If Not String.IsNullOrEmpty(Request("tb3")) Then
            UcDateS = Request("tb3").ToString()
        End If
        If Not String.IsNullOrEmpty(Request("tb4")) Then
            UcDateE = Request("tb4").ToString()
        End If
        If Not String.IsNullOrEmpty(Request("tb5")) Then
            ddlDepart_id = Request("tb5").ToString()
        End If
        If Not String.IsNullOrEmpty(Request("pagerowcnt")) Then
            pagerowcnt = Integer.Parse(Request("pagerowcnt"))
        End If


        Print(tbMaterial_id, ddlUser_name, UcDateS, UcDateE, ddlDepart_id, pagerowcnt)
    End Sub

    Public Sub Print(ByVal tbMaterial_id As String, ByVal ddlUser_name As String, ByVal UcDateS As String, _
                      ByVal UcDateE As String, ByVal ddlDepart_id As String, ByVal pagerowcnt As Integer)

        Dim DT As DataTable = New DataTable()
        DT = MAT2107.MAT2107_Print(tbMaterial_id, ddlUser_name, UcDateS, UcDateE, ddlDepart_id, LoginManager.OrgCode)
        If Not DT Is Nothing AndAlso DT.Rows.Count > 0 Then

            Dim theDTReport As CommonLib.DTReport
            Dim strParam(1) As String

            DT.AcceptChanges()
            strParam(0) = Server.HtmlEncode(Right("000" & Today.Year - 1911, 3) & "/" & Today.ToString("MM/dd")) '製表日期
            strParam(1) = Server.HtmlEncode(LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name)) '製表人

            Dim test1() As String = {"Material_id", "Material_name", "Unit"}

            theDTReport = New CommonLib.DTReport(Server.MapPath("~/Report/MAT/MAT2107.mht"), DT)
            theDTReport.PageGroupColumns = test1
            theDTReport.PageGroupKeyColumns = test1
            theDTReport.Param = strParam  '將參數代入
            theDTReport.ExportFileName = "單項物品領用明細表"
            theDTReport.ExportToWord()
            DT.Dispose()
        Else
            CommonFun.MsgShow(Me, CommonFun.Msg.QueryNothing, "", "MAT2107_01.aspx")
        End If

       
    End Sub
End Class
