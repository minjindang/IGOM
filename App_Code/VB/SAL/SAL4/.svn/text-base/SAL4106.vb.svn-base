Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient

Namespace SAL.Logic
    Public Class SAL4106
        Private DAO As SAL4106DAO

        Public Sub New()
            DAO = New SAL4106DAO()
        End Sub

        Public Function getQueryData(ByVal Apply_type As String, _
                                     ByVal AcademicYear As String, _
                                     ByVal Apply_sTime As String, _
                                     ByVal Apply_eTime As String) As DataTable

            Return DAO.getQueryData(Apply_type, AcademicYear, Apply_sTime, Apply_eTime)
        End Function
        Public Function getQueryDataByID(ByVal id As String) As DataTable
            Return DAO.getQueryDataByID(id)
        End Function
        Public Function getInsertData(ByVal Apply_type As String, _
                             ByVal AcademicYear As String, _
                             ByVal Semester As String, _
                             ByVal Apply_sDate As String, _
                             ByVal Apply_sTime As String, _
                             ByVal Apply_eDate As String, _
                             ByVal Apply_eTime As String, _
                             ByVal Status As String, _
                             ByVal ModUser_id As String, _
                             ByVal orgcode As String) As Boolean

            Return DAO.getInsertData(Apply_type, AcademicYear, Semester, Apply_sDate, Apply_sTime, Apply_eDate, Apply_eTime, Status, ModUser_id, orgcode)
        End Function
        Public Function getUpdateData(ByVal AcademicYear As String, _
                             ByVal Semester As String, _
                             ByVal Apply_sDate As String, _
                             ByVal Apply_sTime As String, _
                             ByVal Apply_eDate As String, _
                             ByVal Apply_eTime As String, _
                             ByVal Status As String, _
                             ByVal ModUser_id As String, _
                             ByVal orgcode As String, _
                             ByVal id As String) As Boolean

            Return DAO.getUpdateData(AcademicYear, Semester, Apply_sDate, Apply_sTime, Apply_eDate, Apply_eTime, Status, ModUser_id, orgcode, id)
        End Function
        Public Function getDeleteSelectData(ByVal Apply_type As String, _
                      ByVal id As String) As DataTable

            Return DAO.getDeleteSelectData(Apply_type, id)
        End Function
        Public Function getDeleteData(ByVal id As String) As Boolean
            Return DAO.getDeleteData(id)
        End Function

        Public Function getFlowData(ByVal Form_id As String, ByVal Sdate As String, ByVal Edate As String) As DataTable
            Return DAO.getFlowData(Form_id, Sdate, Edate)
        End Function
    End Class
End Namespace