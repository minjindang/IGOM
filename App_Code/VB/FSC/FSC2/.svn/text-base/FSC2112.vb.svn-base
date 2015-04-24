Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient

Namespace FSC.Logic
    Public Class FSC2112
        Private DAO As FSC2112DAO

        Public Sub New()
            DAO = New FSC2112DAO()
        End Sub

        Public Function getQueryData(ByVal orgcode As String, _
                                     ByVal Depart_id As String, _
                                     ByVal Apply_name As String, _
                                     ByVal Apply_idcard As String, _
                                     ByVal Start_date As String, _
                                     ByVal End_date As String, _
                                     ByVal Quit_job_flag As String, _
                                     ByVal PESEX As String, _
                                     ByVal Employee_type As String, _
                                     ByVal yyymm As String, _
                                     ByVal type As String) As DataTable
            Return DAO.getQueryData(orgcode, Depart_id, Apply_name, Apply_idcard, Start_date, End_date, Quit_job_flag, PESEX, Employee_type, yyymm, type)
        End Function
        Public Function getQueryData2(ByVal Apply_idcard As String, _
                     ByVal PKWDATE As String) As DataTable
            Return DAO.getQueryData2(Apply_idcard, PKWDATE)
        End Function
    End Class
End Namespace