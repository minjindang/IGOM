Imports FSCPLM.Logic
Imports System.Data

Partial Class MAT2108_02
    Inherits System.Web.UI.Page

    Dim InventoryDet As InventoryDet = New InventoryDet()
    Dim tbMaterial_id1 As String = ""
    Dim tbMaterial_id2 As String = ""
    Dim ddlyear As String = ""
    Dim pagerowcnt As Integer = 0

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not String.IsNullOrEmpty(Request("tb1")) Then
            tbMaterial_id1 = Request("tb1").ToString()
        End If
        If Not String.IsNullOrEmpty(Request("tb2")) Then
            tbMaterial_id2 = Request("tb2").ToString
        End If
        If Not String.IsNullOrEmpty(Request("tb3")) Then
            ddlyear = Request("tb3").ToString()
        End If
        If Not String.IsNullOrEmpty(Request("pagerowcnt")) Then
            pagerowcnt = Integer.Parse(Request("pagerowcnt"))
        End If

        Print(tbMaterial_id1, tbMaterial_id2, ddlyear, pagerowcnt)
    End Sub

    Public Sub Finddate(ByVal tb3 As String, ByVal tb4 As String)

    End Sub

    Public Sub Print(ByVal tbMaterial_id1 As String, ByVal tbMaterial_id2 As String, ByVal ddlyear As String, ByVal pagerowcnt As Integer)

        Dim DT As DataTable = New DataTable()
        Dim MStat As MaterialMStatDet = New MaterialMStatDet()
        DT = MStat.MAT2108_Print(tbMaterial_id1, tbMaterial_id2, ddlyear)
        If DT.Rows.Count = 0 Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "沒有此物料編號", "MAT2108_01.aspx")
            Return
        End If

        DT.Columns.Add("TotalOut_AMT")
        DT.Columns.Add("AMT01")
        DT.Columns.Add("AMT02")
        DT.Columns.Add("AMT03")
        DT.Columns.Add("AMT04")
        DT.Columns.Add("AMT05")
        DT.Columns.Add("AMT06")
        DT.Columns.Add("AMT07")
        DT.Columns.Add("AMT08")
        DT.Columns.Add("AMT09")
        DT.Columns.Add("AMT10")
        DT.Columns.Add("AMT11")
        DT.Columns.Add("AMT12")
        DT.Columns.Add("AMTTotal")

        For Each dr As DataRow In DT.Rows
            Dim sdt As DataTable = MStat.get2108SumData(dr("Material_id"), ddlyear)
            If sdt IsNot Nothing AndAlso sdt.Rows.Count > 0 Then
                dr("AMT01") = sdt.Rows(0)("01MOut_amt").ToString
                dr("AMT02") = sdt.Rows(0)("02MOut_amt").ToString
                dr("AMT03") = sdt.Rows(0)("03MOut_amt").ToString
                dr("AMT04") = sdt.Rows(0)("04MOut_amt").ToString
                dr("AMT05") = sdt.Rows(0)("05MOut_amt").ToString
                dr("AMT06") = sdt.Rows(0)("06MOut_amt").ToString
                dr("AMT07") = sdt.Rows(0)("07MOut_amt").ToString
                dr("AMT08") = sdt.Rows(0)("08MOut_amt").ToString
                dr("AMT09") = sdt.Rows(0)("09MOut_amt").ToString
                dr("AMT10") = sdt.Rows(0)("10MOut_amt").ToString
                dr("AMT11") = sdt.Rows(0)("11MOut_amt").ToString
                dr("AMT12") = sdt.Rows(0)("12MOut_amt").ToString

                dr("AMTTotal") = CommonFun.getInt(sdt.Rows(0)("01MOut_amt")) + CommonFun.getInt(sdt.Rows(0)("02MOut_amt")) + CommonFun.getInt(sdt.Rows(0)("03MOut_amt")) + _
                CommonFun.getInt(sdt.Rows(0)("04MOut_amt")) + CommonFun.getInt(sdt.Rows(0)("05MOut_amt")) + CommonFun.getInt(sdt.Rows(0)("06MOut_amt")) + _
                CommonFun.getInt(sdt.Rows(0)("07MOut_amt")) + CommonFun.getInt(sdt.Rows(0)("08MOut_amt")) + CommonFun.getInt(sdt.Rows(0)("09MOut_amt")) + _
                CommonFun.getInt(sdt.Rows(0)("10MOut_amt")) + CommonFun.getInt(sdt.Rows(0)("11MOut_amt")) + CommonFun.getInt(sdt.Rows(0)("12MOut_amt"))
            End If

            dr("TotalOut_AMT") = CommonFun.getInt(dr("01MOut_amt")) + CommonFun.getInt(dr("02MOut_amt")) + CommonFun.getInt(dr("03MOut_amt")) + _
                CommonFun.getInt(dr("04MOut_amt")) + CommonFun.getInt(dr("05MOut_amt")) + CommonFun.getInt(dr("06MOut_amt")) + _
                CommonFun.getInt(dr("07MOut_amt")) + CommonFun.getInt(dr("08MOut_amt")) + CommonFun.getInt(dr("09MOut_amt")) + _
                CommonFun.getInt(dr("10MOut_amt")) + CommonFun.getInt(dr("11MOut_amt")) + CommonFun.getInt(dr("12MOut_amt"))
        Next

        Dim theDTReport As CommonLib.DTReport
        Dim strParam(1) As String
        strParam(0) = Right("000" & Today.Year - 1911, 3) & "/" & Today.ToString("MM/dd")
        strParam(1) = LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name)
        Dim group() As String = {"Material_id", "Material_name", "AMT01", "AMT02", "AMT03", "AMT04", "AMT05", "AMT06", "AMT07", "AMT08", _
                                 "AMT09", "AMT10", "AMT11", "AMT12", "AMTTotal"}

        theDTReport = New CommonLib.DTReport(Server.MapPath("~/Report/MAT/MAT2108.mht"), DT)
        theDTReport.PageGroupColumns = group
        theDTReport.PageGroupKeyColumns = group
        theDTReport.Param = strParam  '將參數代入
        theDTReport.ExportFileName = "單項物品領用統計年報表"
        theDTReport.ExportToWord()

        DT.Dispose()
    End Sub



End Class
