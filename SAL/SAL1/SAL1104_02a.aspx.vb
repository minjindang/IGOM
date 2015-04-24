Imports FSCPLM.Logic
Imports SALARY.Logic
Imports System.Data

Partial Class SAL1104_02a
    Inherits BaseWebForm

    Dim Type As String = ""
    Dim printType As String = ""

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not String.IsNullOrEmpty(Request.QueryString("Type")) Then
            Type = Request.QueryString("Type")
        End If
        If Not String.IsNullOrEmpty(Request.QueryString("printType")) Then
            printType = Request.QueryString("printType")
        End If

        printing(Type, printType)

    End Sub

#Region "列印"

    Protected Sub printing(ByVal Type As String, ByVal printType As String)
        '沒資料 印空白表單
        If (Type = "0") Then
            Dim dt As DataTable = New DataTable
            dt.Columns.Add(New DataColumn("A"))
            Dim tmpDR As DataRow = dt.NewRow()
            tmpDR("A") = "A"
            dt.Rows.Add(tmpDR )

            Dim strParam(1) As String
            strParam(0) = Right("000" & Today.Year - 1911, 3) & "/" & Today.ToString("MM/dd")
            strParam(1) = LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name)

            Dim theDTReport2 As CommonLib.DTReport
            theDTReport2 = New CommonLib.DTReport(Server.MapPath("~/Report/SAL/SAL1104bn.mht"), dt)
            theDTReport2.ExportFileName = "評審委員出席審查費、講師鐘點費"
            theDTReport2.Param = strParam
            theDTReport2.ExportToWord()

        ElseIf (Type = "1") Then
            '有資料 印資料
            Dim dt As DataTable = Session("dt")
            Dim sum As Decimal = 0
            Dim flowId As String = ""

            dt.Columns.Add(New DataColumn("Index", GetType(String)))

            For i As Integer = 0 To dt.Rows.Count - 1
                dt.Rows(i).Item("Index") = i + 1
                flowId = dt.Rows(i)("Flow_id").ToString()
            Next

            Dim strParam(3) As String
            strParam(0) = Right("000" & Today.Year - 1911, 3) & "/" & Today.ToString("MM/dd")
            strParam(1) = LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name)
            strParam(2) = flowId
            strParam(3) = New EMP.Logic.Member().GetColumnValue("Ext", LoginManager.UserId)

            Dim theDTReport As New CommonLib.DTReport(Server.MapPath("~/Report/SAL/SAL1104a.mht"), dt)
            If printType = "0" Then
                Dim group(0) As String
                group(0) = "BASE_NAME"

                theDTReport.PageGroupColumns = group
                theDTReport.PageGroupKeyColumns = group
            End If

            theDTReport.Param = strParam
            theDTReport.ExportFileName = "評審委員出席審查費、講師鐘點費"
            theDTReport.ExportToWord()
            dt.Dispose()

        End If
    End Sub
#End Region
End Class
