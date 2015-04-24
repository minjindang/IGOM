Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient

Namespace MAI.Logic
    Public Class MAI2101
        Private DAO As MAI2101DAO

        Public Sub New()
            DAO = New MAI2101DAO()
        End Sub

        Public Function getTotalCount(ByVal Orgcode As String, ByVal Apply_dateS As String, ByVal Apply_dateE As String) As Integer
            Return DAO.getTotalCount(Orgcode, Apply_dateS, Apply_dateE)
        End Function

        Public Function getData001(ByVal Orgcode As String, ByVal Apply_dateS As String, ByVal Apply_dateE As String) As DataTable
            Return DAO.getData001(Orgcode, Apply_dateS, Apply_dateE)
        End Function

        Public Function getData002(ByVal Orgcode As String, ByVal Apply_dateS As String, ByVal Apply_dateE As String) As DataTable
            Return DAO.getData002(Orgcode, Apply_dateS, Apply_dateE)
        End Function

        Public Function getData003(ByVal Orgcode As String, ByVal Apply_dateS As String, ByVal Apply_dateE As String) As DataTable
            Return DAO.getData003(Orgcode, Apply_dateS, Apply_dateE)
        End Function

        Public Function getData0045(ByVal Orgcode As String, ByVal Apply_dateS As String, ByVal Apply_dateE As String, ByVal type As String) As DataTable
            Return DAO.getData0045(Orgcode, Apply_dateS, Apply_dateE, type)
        End Function

        Public Function getData006(ByVal Orgcode As String, ByVal Apply_dateS As String, ByVal Apply_dateE As String) As DataTable
            Dim dt As DataTable = DAO.getData006(Orgcode, Apply_dateS, Apply_dateE)
            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                Dim tmp As DataTable = dt.Clone()
                For Each dr As DataRow In dt.Rows
                    Dim Apply_date As Date = FSC.Logic.DateTimeInfo.GetPublicDate(dr("Apply_date").ToString())
                    Dim Handle_edate As Date = FSC.Logic.DateTimeInfo.GetPublicDate(dr("Handle_edate").ToString())
                    If Handle_edate > Apply_date.AddDays(3) Then
                        tmp.ImportRow(dr)
                    End If
                Next

                'If tmp IsNot Nothing AndAlso tmp.Rows.Count > 0 Then
                Dim ddt As DataTable = New DataTable
                ddt.Columns.Add("Num")
                ddt.Columns.Add("Item")
                Dim ddr As DataRow = ddt.NewRow
                ddt.Rows.Add(ddr)
                ddt.Rows(0)("Num") = tmp.Rows.Count
                ddt.Rows(0)("Item") = "超過三天之報修筆數及比率"

                Return ddt
                'End If
            End If

            Return Nothing
        End Function
    End Class
End Namespace