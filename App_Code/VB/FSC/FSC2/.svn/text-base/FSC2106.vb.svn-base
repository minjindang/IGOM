Imports Microsoft.VisualBasic
Imports System.Data

Namespace FSC.Logic
    Public Class FSC2106
        Private DAO As FSC2106DAO

        Public Sub New()
            DAO = New FSC2106DAO()
        End Sub

        Public Function getData(ByVal Orgcode As String, ByVal Depart_id As String, ByVal Sdate As String, ByVal Edate As String, _
                                ByVal leave_table As String, ByVal Case_status As String, ByVal lastpass As String) As DataTable
            Dim dt As DataTable = DAO.GetData(Orgcode, Depart_id, Sdate, Edate, leave_table, Case_status, lastpass)
            If dt Is Nothing Then Return Nothing
            Return dt
        End Function

    End Class
End Namespace
