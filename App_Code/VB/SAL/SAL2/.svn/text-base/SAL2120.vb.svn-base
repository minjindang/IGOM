Imports Microsoft.VisualBasic
Imports System.Data

Namespace SAL.Logic
    Public Class SAL2120
        Private DAO As SAL2120DAO

        Public Sub New()
            DAO = New SAL2120DAO()
        End Sub

        Public Function getProj(ByVal v_orgid As String) As DataTable
            Return DAO.getProj(v_orgid)
        End Function

        Public Function getJob(ByVal v_orgid As String, ByVal code_sys As String, ByVal code_type As String) As DataTable
            Return DAO.getJob(v_orgid, code_sys, code_type)
        End Function

        Public Function getData(ByVal v_UserOrgId As String, ByVal s_date As String, ByVal s_name As String, ByVal s_proj As String, _
                        ByVal s_job As String, ByVal s_bdate As String) As DataTable
            Return DAO.getData(v_UserOrgId, s_date, s_name, s_proj, s_job, s_bdate)
        End Function

        Public Function getData2(ByVal v_UserOrgId As String, ByVal s_year As String, ByVal s_name As String, ByVal s_proj As String, _
                        ByVal s_job As String, ByVal s_bdate As String) As DataTable
            Return DAO.getData2(v_UserOrgId, s_year, s_name, s_proj, s_job, s_bdate)
        End Function
    End Class
End Namespace