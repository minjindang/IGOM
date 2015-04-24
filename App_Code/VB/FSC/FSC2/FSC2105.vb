Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient

Namespace FSC.Logic
    Public Class FSC2105
        Private DAO As FSC2105DAO

        Public Sub New()
            DAO = New FSC2105DAO()
        End Sub

        Public Function getQueryData(ByVal orgcode As String, _
                                     ByVal Depart_id As String, _
                                     ByVal PRCARD As String, _
                                     ByVal PRNAME As String, _
                                     ByVal PESEX As String, _
                                     ByVal PRADDD As String, _
                                     ByVal PRADDE As String, _
                                     ByVal Case_status As String, _
                                     ByVal lastpass As String) As DataTable

            Return DAO.getQueryData(orgcode, Depart_id, PRCARD, PRNAME, PESEX, PRADDD, PRADDE, Case_status, lastpass)
        End Function

    End Class
End Namespace