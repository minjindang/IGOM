Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient


Namespace FSC.Logic
    Public Class FSC1101
        Private DAO As FSC1101DAO

        Private sixmonth As Date = Now.AddMonths(-6).AddDays(-1)
        '可申請補休的日期期限：今日至六個月前的日期
        Private limitDate As String = (sixmonth.Year - 1911).ToString().PadLeft(3, "0") & sixmonth.Month.ToString().PadLeft(2, "0") & (sixmonth.Day).ToString().PadLeft(2, "0")

        Public Sub New()
            DAO = New FSC1101DAO()
        End Sub

        Public Function GetOvertimeData(ByVal orgcode As String, ByVal PRIDNO As String) As DataTable
            Dim lmm As New FSC.Logic.LeaveMainMapping()

            Dim dt As DataTable = DAO.GetOvertimeData(PRIDNO, limitDate)

            '已休日期
            dt.Columns.Add("PSBREAKD", GetType(String))

            '抓取已補休日期
            For Each dr As DataRow In dt.Rows
                Dim tdt As DataTable = lmm.GetDataByApplyData(orgcode, PRIDNO, "04", dr("PRADDD").ToString(), dr("PRSTIME").ToString())
                For Each tdr As DataRow In tdt.Rows
                    dr("PSBREAKD") &= tdr("Start_date").ToString() & ","
                    dr("PRPAYH") = CommonFun.getInt(dr("PRPAYH").ToString()) + CommonFun.getInt(tdr("Leave_hours").ToString())
                    dr("NotApplyHours") = CommonFun.getInt(dr("NotApplyHours").ToString) - CommonFun.getInt(tdr("Leave_hours").ToString())
                Next
                dr("PSBREAKD") = dr("PSBREAKD").ToString().TrimEnd(",")
            Next

            Dim odt As DataTable = dt.Clone()
            For Each dr As DataRow In dt.Rows
                If dr("NotApplyHours").ToString <> "0" Then
                    odt.ImportRow(dr)
                End If
            Next

            Return odt
        End Function


        Public Function GetBusinessData(ByVal orgcode As String, ByVal PPIDNO As String) As DataTable
            Dim lmm As New FSC.Logic.LeaveMainMapping()
           
            Dim dt As DataTable = DAO.GetBusinessData(PPIDNO, limitDate)

            '已休日期
            dt.Columns.Add("PXBREAKD", GetType(String))

            '抓取已補休日期
            For Each dr As DataRow In dt.Rows
                Dim tdt As DataTable = lmm.GetDataByApplyData(orgcode, PPIDNO, "20", dr("PPBUSDATEB").ToString(), dr("PPTIMEB").ToString())
                For Each tdr As DataRow In tdt.Rows
                    dr("PXBREAKD") &= tdr("Start_date").ToString() & ","

                    If tdr("Last_pass").ToString() = "0" Then
                        dr("PPPAYH") = CommonFun.getInt(dr("PPPAYH").ToString()) + CommonFun.getInt(tdr("Leave_hours").ToString())
                    End If
                Next
                dr("PXBREAKD") = dr("PXBREAKD").ToString().TrimEnd(",")
            Next

            Return dt
        End Function

        Public Function GetScheduleData(ByVal orgcode As String, ByVal idCard As String) As DataTable
            Dim lmm As New FSC.Logic.LeaveMainMapping()

            Dim dt As DataTable = DAO.GetScheduleData(idCard, limitDate)

            '已休日期
            dt.Columns.Add("break_date", GetType(String))

            '抓取已補休日期
            For Each dr As DataRow In dt.Rows
                Dim tdt As DataTable = lmm.GetDataByApplyData(orgcode, idCard, "32", dr("Sche_date").ToString(), "")
                For Each tdr As DataRow In tdt.Rows
                    dr("break_date") &= tdr("Start_date").ToString() & ","

                    If tdr("Last_pass").ToString() = "0" Then
                        dr("rest_hours") = CommonFun.getInt(dr("rest_hours").ToString()) + CommonFun.getInt(tdr("Leave_hours").ToString())
                        dr("schedule_hours") = CommonFun.getInt(dr("schedule_hours").ToString()) - CommonFun.getInt(tdr("Leave_hours").ToString())
                    End If
                Next
                dr("break_date") = dr("break_date").ToString().TrimEnd(",")
            Next

            Dim odt As DataTable = dt.Clone()
            For Each dr As DataRow In dt.Rows
                If dr("schedule_hours").ToString <> "0" Then
                    odt.ImportRow(dr)
                End If
            Next

            Return odt
        End Function

    End Class
End Namespace
