Imports Microsoft.VisualBasic
Imports System.Data

Namespace FSC.Logic
    Public Class FSC2111
        Private DAO As FSC2111DAO

        Public Sub New()
            DAO = New FSC2111DAO()
        End Sub

        Public Function GetData(ByVal Orgcode As String, ByVal Depart_id As String, ByVal BossLevel As String, ByVal Sdate As String, _
                                ByVal Edate As String, ByVal status As String, ByVal lastPass As String) As DataTable
            Dim dt As DataTable = DAO.GetData(Orgcode, Depart_id, BossLevel, Sdate, Edate, status, lastPass)
            If dt Is Nothing Then Return Nothing
            Return dt
        End Function

    End Class
End Namespace
