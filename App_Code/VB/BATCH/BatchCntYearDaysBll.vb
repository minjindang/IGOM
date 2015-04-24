Imports Microsoft.VisualBasic
Imports FSCPLM.Logic
Imports System.Data
Imports System.Transactions
Imports NLog

Namespace FSC.Logic

    Public Class BatchCntYearDaysBll

        Private Shared logger As Logger = LogManager.GetLogger("BatchCntYearDaysBll")

        Public Sub RunBatch()
            Dim psn As New Personnel()
            Dim dt As DataTable = New FSCPLM.Logic.SACode().GetData("023", "022")

            Using trans As New TransactionScope
                For Each dr As DataRow In dt.Rows

                    Dim employeeType As String = dr("code_no").ToString()
                    Dim remark1 As String = dr("code_remark1").ToString()
                    If "L" = remark1 Then
                        '勞基法
                        Dim dt1 As DataTable = psn.GetDataByEmployeeType(employeeType)
                        count(psn, dt1, employeeType)
                    End If
                Next
                trans.Complete()
            End Using

        End Sub

        Protected Sub count(ByVal psn As Personnel, dt As DataTable, ByVal employeeType As String)
            Dim bll As New CntLeave()

            For Each dr As DataRow In dt.Rows

                Try
                    Dim PEORG As String = ""
                    Dim PEIDNO As String = dr("id_card").ToString()
                    Dim PECARD As String = dr("PECARD").ToString()
                    Dim PEKIND As String = dr("pekind").ToString()
                    Dim userName As String = dr("User_name").ToString()

                    Dim PEHYEAR As String = ""
                    Dim PEHDAY As String = ""
                    Dim join_sdate As String = New FSC.Logic.Member().GetColumnValue("Act_date", PEIDNO)
                    Dim Elected_officials_flag As String = ""


                    Dim ht As LeaveYearDay = CntLeave.GetCntYearsDays(PEORG, PEIDNO, join_sdate, Elected_officials_flag, PEKIND, employeeType)
                    If ht IsNot Nothing Then
                        PEHYEAR = ht.Year
                        PEHDAY = ht.Day
                    End If

                    psn.UpdateAnnel("", "", "", PEHYEAR, PEHDAY, PEIDNO)

                    logger.Info(userName & "(" & PEIDNO & ")")

                Catch ex As Exception
                    logger.Error(" Exception : " & vbCrLf & ex.StackTrace)
                End Try
            Next
        End Sub
    End Class
End Namespace