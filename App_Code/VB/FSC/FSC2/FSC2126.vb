Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient

Namespace FSC.Logic
    Public Class FSC2126
        Private DAO As FSC2126DAO

        Public Sub New()
            DAO = New FSC2126DAO()
        End Sub

        Public Function getQueryData(ByVal orgcode As String, _
                                     ByVal Depart_id As String, _
                                     ByVal idcard As String, _
                                     ByVal idcard2 As String, _
                                     ByVal Start_date As String, _
                                     ByVal end_date As String) As DataTable

            Dim y As String = Start_date.Substring(0, 3)
            Dim s As Integer = Start_date.Substring(3, 2)
            Dim e As Integer = end_date.Substring(3, 2)
            Dim rdt As New DataTable

            While s < e
                Dim yyymm As String = y.ToString() & s.ToString().PadLeft(2, "0")
                Dim dt As DataTable = DAO.getQueryData(orgcode, Depart_id, idcard, idcard2, Start_date, end_date, yyymm)
                rdt.Merge(dt)
                s += 1
            End While

            Return rdt
        End Function

    End Class
End Namespace