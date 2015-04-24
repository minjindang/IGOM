Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient

Namespace FSC.Logic
    Public Class FSC2103
        Private DAO As FSC2103DAO

        Public Sub New()
            DAO = New FSC2103DAO()
        End Sub

        Public Function getQueryData(ByVal orgcode As String, _
                                     ByVal Depart_id As String, _
                                     ByVal Apply_name As String, _
                                     ByVal Apply_idcard As String, _
                                     ByVal Title_no As String, _
                                     ByVal Quit_job_flag As String, _
                                     ByVal PESEX As String, _
                                     ByVal Start_date As String, _
                                     ByVal End_date As String, _
                                     ByVal Leave_type As String, _
                                     ByVal Employee_type As String, _
                                     ByVal Case_status As String, _
                                     ByVal lastpass As String) As DataTable
            Return DAO.getQueryData(orgcode, Depart_id, Apply_name, Apply_idcard, Title_no, Quit_job_flag, PESEX, Start_date, End_date, Leave_type, Employee_type, Case_status, lastpass)
        End Function
        Public Function getQueryData2(ByVal flowid As String) As DataTable
            Return DAO.getQueryData2(flowid)
        End Function
    End Class
End Namespace