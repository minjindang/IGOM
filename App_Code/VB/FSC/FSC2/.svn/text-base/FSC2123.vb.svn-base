Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient

Namespace FSC.Logic
    Public Class FSC2123
        Private DAO As FSC2123DAO

        Public Sub New()
            DAO = New FSC2123DAO()
        End Sub

        Public Function getQueryData(ByVal orgcode As String, _
                                     ByVal Depart_id As String, _
                                     ByVal Start_date As String) As DataTable
            Return DAO.getQueryData(orgcode, Depart_id, Start_date)
        End Function
        Public Function getQueryDataDep(ByVal orgcode As String, _
                                  ByVal Depart_id As String) As DataTable
            Return DAO.getQueryDataDep(orgcode, Depart_id)
        End Function
        Public Function getQueryDataLea(ByVal orgcode As String, _
                                        ByVal Start_date As String) As DataTable
            Return DAO.getQueryDataDLea(orgcode, Start_date)

        End Function
    End Class
End Namespace