Imports Microsoft.VisualBasic
Imports System.Data
Imports FSCPLM.Logic

Namespace FSC.Logic
    Public Class FSC2127
        Private DAO As FSC2127DAO

        Sub New()
            DAO = New FSC2127DAO()
        End Sub

        Function GetData(ByVal orgcode As String, departId As String, idCard As String, startDate As String, endDate As String) As DataTable
            Dim sy As Integer = DateTimeInfo.GetPublicDate(startDate).Year
            Dim ey As Integer = DateTimeInfo.GetPublicDate(endDate).Year

            Dim sm As Integer = DateTimeInfo.GetPublicDate(startDate).Month
            Dim em As Integer = DateTimeInfo.GetPublicDate(endDate).Month

            Dim rdt As New DataTable

            For i = sy To ey
                Dim s As Integer = 0
                Dim e As Integer = 0

                If i = sy Then
                    s = sm
                Else
                    s = 1
                End If

                If i = ey Then
                    e = em
                Else
                    e = 12
                End If

                While s <= e
                    Dim yyymm As String = (i - 1911).ToString().PadLeft(3, "0") & s.ToString().PadLeft(2, "0")

                    Dim dt As DataTable = DAO.GetData(orgcode, departId, idCard, startDate, endDate, yyymm)

                    rdt.Merge(dt)

                    s += 1
                End While

            Next

            Return rdt

        End Function

    End Class
End Namespace