Imports Microsoft.VisualBasic
Imports System.Data

Namespace SAL.Logic
    Public Class SAL2214

        Private DAO As SAL2214DAO

        Public Sub New()
            DAO = New SAL2214DAO()
        End Sub

        Public Function getData(ByVal ENGF_YY As String, ByVal BASE_ORGID As String, ByVal BASE_SEQNO As String) As DataTable
            Return DAO.getData(ENGF_YY, BASE_ORGID, BASE_SEQNO)
        End Function

    End Class
End Namespace
