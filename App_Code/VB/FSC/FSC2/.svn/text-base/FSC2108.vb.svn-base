Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient

Namespace FSC.Logic
    Public Class FSC2108
        Private DAO As FSC2108DAO

        Public Sub New()
            DAO = New FSC2108DAO()
        End Sub

        Public Function getQueryData(ByVal orgcode As String, _
                                     ByVal Depart_id As String, _
                                     ByVal User_name As String, _
                                     ByVal Id_card As String, _
                                     ByVal Quit_job_flag As String, _
                                     ByVal PESEX As String, _
                                     ByVal Start_date As String, _
                                     ByVal End_date As String, _
                                     ByVal order As String) As DataTable
            Return DAO.getQueryData(orgcode, Depart_id, User_name, Id_card, Quit_job_flag, PESEX, Start_date, End_date, order)
        End Function
    End Class
End Namespace