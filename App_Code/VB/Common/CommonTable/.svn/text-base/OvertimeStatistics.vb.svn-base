Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Collections.Generic

Namespace SAL.Logic
    <System.ComponentModel.DataObject()> _
    Public Class OvertimeStatistics
        Public DAO As OvertimeStatisticsDAO

        Public Sub New()
            DAO = New OvertimeStatisticsDAO()
        End Sub

        Public Sub UpdateStatisticsData(ByVal p2kConn As String)

            Dim bll As New FSC.Logic.CPAPR18M()
            Dim ds As DataSet
            Dim nowDate As Date = Date.Now
            Dim sixMonthBefore As Date = Date.Now
            Dim dateUtil As New FSC.Logic.DateTimeInfo

            'Dim PRIDNO As String
            'Dim PRADDD As String
            'Dim Normal As Integer
            'Dim Normal_Rest As Integer
            'Dim Normal_Fee As Integer
            'Dim Normal_Paid As Integer
            'Dim Project As Integer
            'Dim Project_Rest As Integer
            'Dim Project_Fee As Integer
            'Dim Project_Paid As Integer

            'Dim PEORG As String
            'Dim PEUNIT As String

            sixMonthBefore = sixMonthBefore.AddMonths(-6)
            sixMonthBefore = sixMonthBefore.AddDays(-1 * sixMonthBefore.Day + 1)

            Dim nowDateStr As String = (nowDate.Year - 1911).ToString("000") & (nowDate.Month).ToString("00")
            Dim sixMonthBeforeStr As String = (sixMonthBefore.Year - 1911).ToString("000") & (sixMonthBefore.Month).ToString("00")

            ds = bll.GetStatisticsData(nowDateStr, sixMonthBeforeStr)

            If Not IsNothing(ds) And ds.Tables.Count > 0 Then

                Dim dt As DataTable = ds.Tables(0)
                'Dim statDs As DataSet

                'Dim m05 As New CPAPE05M(p2kConn)
                'Dim m05Dt As DataTable

                'If Not IsNothing(dt) And dt.Rows.Count > 0 Then
                '    For Each row As DataRow In dt.Rows
                '        PRIDNO = CastTypeFun.CastObjectToString(row("PRIDNO"))
                '        PRADDD = CastTypeFun.CastObjectToString(row("PRADDD"))
                '        Normal = CastTypeFun.CastObjectToInteger(row("Normal"), 0)
                '        Normal_Rest = CastTypeFun.CastObjectToInteger(row("Normal_Rest"), 0)
                '        Normal_Fee = CastTypeFun.CastObjectToInteger(row("Normal_Fee"), 0)
                '        Normal_Paid = CastTypeFun.CastObjectToInteger(row("Normal_Paid"), 0)
                '        Project = CastTypeFun.CastObjectToInteger(row("Project"), 0)
                '        Project_Rest = CastTypeFun.CastObjectToInteger(row("Project_Rest"), 0)
                '        Project_Fee = CastTypeFun.CastObjectToInteger(row("Project_Fee"), 0)
                '        Project_Paid = CastTypeFun.CastObjectToInteger(row("Project_Paid"), 0)

                '        m05Dt = m05.GetCPAPE05MByPEIDNO(PRIDNO)

                '        If Not IsNothing(m05Dt) And m05Dt.Rows.Count > 0 Then
                '            PEORG = CastTypeFun.CastObjectToString(m05Dt.Rows(0)("PEORG"))
                '            PEUNIT = CastTypeFun.CastObjectToString(m05Dt.Rows(0)("PEUNIT"))

                '            statDs = DAO.GetData(PEORG, PEUNIT, PRIDNO, PRADDD)

                '            If Not IsNothing(statDs) AndAlso statDs.Tables.Count > 0 AndAlso Not IsNothing(statDs.Tables(0)) AndAlso statDs.Tables(0).Rows.Count > 0 Then
                '                DAO.UpdateData(PEORG, PEUNIT, PRIDNO, PRADDD, Normal, Project, Normal_Paid, Project_Paid, Normal_Rest, Project_Rest, _
                '                    Normal_Fee, Project_Fee, Date.Now, "Batch")
                '            Else
                '                DAO.InsertData(PEORG, PEUNIT, PRIDNO, PRADDD, Normal, Project, Normal_Paid, Project_Paid, Normal_Rest, Project_Rest, _
                '                    Normal_Fee, Project_Fee, Date.Now, Date.Now, "Batch", "Batch")
                '            End If
                '        End If
                '    Next
                'End If
            End If

        End Sub
    End Class
End Namespace