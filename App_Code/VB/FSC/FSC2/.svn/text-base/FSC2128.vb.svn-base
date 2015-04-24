Imports Microsoft.VisualBasic
Imports System.Data
Imports System

Namespace FSC.Logic
    Public Class FSC2128
        Private DAO As FSC2128DAO

        Public Sub New()
            DAO = New FSC2128DAO
        End Sub

        Function getData(ByVal Year As String, _
                         ByVal orgcode As String, _
                         ByVal departid As String, _
                         ByVal titleno As String, _
                         ByVal idcard As String, _
                         ByVal quitjobflag As String) As DataSet

            Dim table_name As String = "FSC_CPAP" & Year & "S"
            Dim ds As New DataSet()

            Dim cdt As DataTable = New FSC2128DAO().GetCardData(orgcode, departid, titleno, idcard, quitjobflag)

            For Each dr As DataRow In cdt.Rows

                Dim quitDate As String = String.Empty
                Dim psn As Personnel = New Personnel().GetObject(dr("id_card").ToString)
                If psn Is Nothing Then Continue For

                quitDate = psn.Left_date

                Dim reValue As DataTable = Nothing
                '勤惰資料
                Dim dt As DataTable = DAO.GetQueryData(table_name, departid, dr("title_no").ToString, dr("id_card").ToString, dr("Quit_job_flag").ToString)

                If Not dt Is Nothing Then
                    If reValue Is Nothing Then
                        reValue = dt.Clone()
                    End If
                    For Each row2 As DataRow In dt.Rows
                        Dim tmpRow As DataRow = reValue.NewRow
                        tmpRow.ItemArray = row2.ItemArray
                        reValue.Rows.Add(tmpRow)
                    Next
                End If

                If reValue Is Nothing OrElse reValue.Rows.Count <= 0 Then
                    Continue For
                End If

                Dim ndt As New DataTable
                ndt.Columns.Add("id_card", GetType(String))
                ndt.Columns.Add("month", GetType(String))
                ndt.Columns.Add("workdays", GetType(String))

                For j As Integer = 0 To 11

                    Try
                        ndt.Rows.Add()
                        ndt.Rows(j)(0) = reValue.Rows(j)("pyidno").ToString().Trim()
                        ndt.Rows(j)(1) = j + 1
                        ndt.Rows(j)(2) = New CPAPB02M().getWorkDaysCount(Year & (j + 1).ToString().PadLeft(2, "0"), quitDate)

                        For i As Integer = 0 To reValue.Rows.Count - 2
                            If j = 0 Then
                                '以第一個欄位當新Table的欄位名稱 
                                ndt.Columns.Add(reValue.Rows(i)(j).ToString())
                            End If
                            '第二個欄位當該Row的值 
                            ndt.Rows(j)(i + 3) = reValue.Rows(i)(j + 1).ToString()
                        Next

                    Catch ex As Exception
                        Continue For
                    End Try

                Next

                ds.Tables.Add(ndt.Copy())

            Next

            Return ds

        End Function
    End Class
End Namespace