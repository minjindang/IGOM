Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient

Namespace SAL.Logic
    Public Class SAL4104
        Private DAO As SAL4104DAO

        Public Sub New()
            DAO = New SAL4104DAO()
        End Sub

        Public Function getQueryData(ByVal Jobtype As String, _
                                     ByVal Leveltype As String, _
                                     ByVal orgcode As String, _
                                     ByVal LEVCOM_MDATE As String) As DataTable

            Return DAO.getQueryData(Jobtype, Leveltype, orgcode, LEVCOM_MDATE)
        End Function

        Public Function Insert(ByVal Jobtype As String, _
                             ByVal Leveltype As String, _
                             ByVal L3 As String, _
                             ByVal L1 As String, _
                             ByVal securityid As String, _
                             ByVal date1 As String) As Boolean

            Return DAO.Insert(Jobtype, Leveltype, L3, L1, securityid, date1)
        End Function
        Public Function Update(ByVal Jobtype As String, _
                           ByVal Leveltype As String, _
                           ByVal L3 As String, _
                           ByVal L1 As String, _
                           ByVal securityid As String, _
                           ByVal date1 As String, _
                           ByVal newL3 As String, _
                           ByVal newL1 As String) As Boolean

            Return DAO.Update(Jobtype, Leveltype, L3, L1, securityid, date1, newL3, newL1)
        End Function
        Public Function Delete(ByVal Jobtype As String, _
                   ByVal Leveltype As String, _
                   ByVal L3 As String, _
                   ByVal L1 As String) As Boolean

            Return DAO.Delete(Jobtype, Leveltype, L3, L1)
        End Function

    End Class
End Namespace