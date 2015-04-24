Imports System.Data
Imports SALARY.Logic
Imports System.IO

Partial Class SAL_SAL2102_02
    Inherits BaseWebForm

    Dim bll As SAL2102 = New SAL2102()
    Dim dtTable As DataTable = New DataTable

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not (IsPostBack) Then
            If Me.Judge() Then
                Dim SelectedValue As String = ""
                Dim PAYOD_CODE As String = ""

                If Not String.IsNullOrEmpty(Server.HtmlEncode(Request("SelectedValue"))) Then
                    SelectedValue = Server.HtmlEncode(Request("SelectedValue").ToString())
                End If
                If Not String.IsNullOrEmpty(Server.HtmlEncode(Request("PAYOD_CODE"))) Then
                    PAYOD_CODE = Server.HtmlEncode(Request("PAYOD_CODE").ToString())
                End If
                Dim Year As String = Server.HtmlEncode(Request("Year").ToString())
                Dim Type As String = Server.HtmlEncode(Request("Type").ToString())
                Dim pagerowcnt As Integer = Server.HtmlEncode(Request("sPageSize").ToString())
                Dim id_card As String = Request.QueryString("id_card")

                Me.PrintBtn_Click(Year, SelectedValue, Type, pagerowcnt, PAYOD_CODE, id_card)
            Else
                CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "資料出錯")
            End If
        End If
    End Sub

    ''' <summary>
    ''' 列印
    ''' </summary>
    ''' <param name="Year"></param>
    ''' <param name="SelectedValue"></param>
    ''' <param name="Type"></param>
    ''' <param name="pagerowcnt"></param>
    ''' <param name="PAYOD_CODE"></param>
    ''' <remarks></remarks>
    Protected Sub PrintBtn_Click(ByVal Year As String, ByVal SelectedValue As String, ByVal Type As Integer, ByVal pagerowcnt As Integer, ByVal PAYOD_CODE As String, ByVal id_card As String)
        Dim LaborProtection As Integer = 0 '勞保總價
        Dim PublicLaborProtection As Integer = 0 '公、勞保總價
        Dim HealthInsurance As Integer = 0 '健保總價
        Dim theDTReport As CommonLib.DTReport
        Dim strParam(10) As String '宣告字串陣列

        'If Type = "1" Then '依年度列印
        '    dtTable = bll.PrintData(Year, "", Type, PAYOD_CODE) '公保列印資料表
        'ElseIf Type = "2" Then '依資料列列印
        '    dtTable = bll.PrintData(Year, SelectedValue, Type, PAYOD_CODE) '公保列印資料表
        'ElseIf Type = "3" Then '依指定人員
        '    dtTable = bll.PrintData(Year, SelectedValue, Type, "") '公保列印資料表
        'End If

        dtTable = bll.GetData(Year, PAYOD_CODE, id_card)

        If dtTable.Rows.Count > 0 Then '有資料
            dtTable.Columns.Add("family_relationship")
            dtTable.Columns.Add("family_id")
            dtTable.Columns.Add("family_name")
            dtTable.Columns.Add("family_amt")
            dtTable.Columns.Add("family_amt_sum")
            dtTable.Columns.Add("PAYOD_AMT2")
            dtTable.Columns.Add("PAYOD_AMT_sum")
            dtTable.Columns.Add("Total_sum")

            Dim FinalDt As DataTable = dtTable.Clone()

            For i As Integer = 0 To dtTable.Rows.Count - 1
                Dim dt As DataTable = bll.getFamily(dtTable.Rows(i)("id_card").ToString())
                If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                    For j As Integer = 0 To dt.Rows.Count - 1
                        Dim dr As DataRow = FinalDt.NewRow
                        If j = 0 Then
                            dr("id_number") = dtTable.Rows(i)("id_number").ToString()
                            dr("USER_NAME") = dtTable.Rows(i)("USER_NAME").ToString()
                            dr("PAYOD_AMT2") = dtTable.Rows(i)("PAYOD_AMT").ToString()
                        Else
                            dr("id_number") = ""
                            dr("USER_NAME") = ""
                            dr("PAYOD_AMT2") = ""
                        End If

                        dr("id_card") = dtTable.Rows(i)("id_card").ToString()
                        dr("family_relationship") = IIf(dt.Rows(j)("family_id").ToString() = dtTable.Rows(i)("id_number").ToString(), "本人", "眷屬")
                        dr("family_id") = dt.Rows(j)("family_id").ToString()
                        dr("family_name") = dt.Rows(j)("family_name").ToString()
                        dr("family_amt") = dt.Rows(j)("family_amt").ToString()

                        FinalDt.Rows.Add(dr)
                    Next
                Else
                    FinalDt.ImportRow(dtTable.Rows(i))
                End If
            Next


            For i As Integer = 0 To FinalDt.Rows.Count - 1
                Dim dt As DataTable = bll.getFamily(FinalDt.Rows(i)("id_card").ToString())
                Dim family_amt As Double = 0
                For Each dr As DataRow In dt.Rows
                    family_amt += CommonFun.getDouble(dr("family_amt"))
                Next
                FinalDt.Rows(i)("family_amt_sum") = family_amt

                Dim PAYOD_AMT_sum As Double = 0
                Dim rows() As DataRow = FinalDt.Select(String.Format(" id_card= '{0}'", FinalDt.Rows(i)("id_card").ToString()))
                For Each dr As DataRow In rows
                    PAYOD_AMT_sum += CommonFun.getDouble(dr("PAYOD_AMT"))
                Next
                FinalDt.Rows(i)("PAYOD_AMT_sum") = PAYOD_AMT_sum

                FinalDt.Rows(i)("Total_sum") = family_amt + PAYOD_AMT_sum
            Next

            'For i As Integer = 0 To dtTable.Rows.Count - 1
            '    PublicLaborProtection = PublicLaborProtection + Convert.ToInt32(dtTable.Rows(i).Item("PAYOD_AMT")) '加總公、勞保金額
            '    HealthInsurance = HealthInsurance + CommonFun.getInt(dtTable.Rows(i).Item("family_amt")) '加總健保金額
            'Next

            strParam(0) = Server.HtmlEncode(Right("000" & Today.Year - 1911, 3) & "/" & Today.ToString("MM/dd")) '製表日期
            strParam(1) = Server.HtmlEncode(LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name)) '製表人
            strParam(2) = Year '繳費期間
            strParam(3) = PublicLaborProtection '公、勞保合計金額
            strParam(4) = HealthInsurance '健保合計金額
            strParam(5) = Convert.ToInt32(PublicLaborProtection + HealthInsurance).ToString '公健或勞健總價

            If PAYOD_CODE = "001" Then '公
                strParam(6) = "公保"
                strParam(7) = "公保合計金額"
            ElseIf PAYOD_CODE = "002" Then '勞
                strParam(6) = "勞保"
                strParam(7) = "勞保合計金額"
            End If

            Dim group(3) As String
            group(0) = "id_card"
            group(1) = "PAYOD_AMT_sum"
            group(2) = "family_amt_sum"
            group(3) = "Total_sum"

            theDTReport = New CommonLib.DTReport(Server.MapPath("~/Report/SAL/SAL2102.mht"), FinalDt)
            theDTReport.Param = strParam
            theDTReport.ExportFileName = "勞//健、公//健保繳納證明列印"
            theDTReport.PageGroupColumns = group
            theDTReport.PageGroupKeyColumns = group
            theDTReport.ExportToWord()
            dtTable.Dispose()
        Else
            CommonFun.MsgShow(Me, CommonFun.Msg.QueryNothing, "", "SAL2102_01.aspx")
        End If
    End Sub

    ''' <summary>
    ''' 資料檢核
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected Function Judge() As Boolean
        Try
            Dim pagerowcnt As Integer = Server.HtmlEncode(Request("sPageSize").ToString())
            Dim Year As String = Server.HtmlEncode(Request("Year").ToString())
            Dim Type As String = Server.HtmlEncode(Request("Type").ToString())

            If (Not String.IsNullOrEmpty(pagerowcnt) And _
              Not String.IsNullOrEmpty(Year) And _
              Not String.IsNullOrEmpty(Type)) Then
                Return True
            Else
                Return False
            End If
            Return True
        Catch
            Return False
        End Try
    End Function
End Class