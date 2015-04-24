Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient

Namespace FSC.Logic
    Public Class FSC2117
        Private DAO As FSC2117DAO

        Public Sub New()
            DAO = New FSC2117DAO()
        End Sub

        Public Function getQueryData(ByVal orgcode As String, _
                                     ByVal Depart_id As String, _
                                     ByVal Apply_name As String, _
                                     ByVal Apply_idcard As String, _
                                     ByVal Start_date As String, _
                                     ByVal End_date As String, _
                                     ByVal Quit_job_flag As String, _
                                     ByVal Employee_type As String, _
                                     ByVal Title_no As String) As DataTable

            Dim s As Integer = Start_date.Substring(3, 2)
            Dim e As Integer = End_date.Substring(3, 2)
            Dim rdt As New DataTable()

            While s <= e
                Dim yyymm As String = Start_date.Substring(0, 3) + s.ToString().PadLeft(2, "0")
                Dim dt As DataTable = DAO.getQueryData(yyymm, orgcode, Depart_id, Apply_name, Apply_idcard, Start_date, End_date, Quit_job_flag, Employee_type, Title_no)
                rdt.Merge(dt)
                s += 1
            End While

            Return rdt
        End Function
    End Class
End Namespace