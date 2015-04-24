Imports Microsoft.VisualBasic
Imports System.Data

Namespace SAL.Logic
    Public Class SAL2117
        Private DAO As SAL2117DAO

        Public Sub New()
            DAO = New SAL2117DAO()
        End Sub

        Public Function GetStartData(v_startYYMM As String, strPayBudgeCode As String) As DataTable
            Return DAO.GetStartData(v_startYYMM, strPayBudgeCode)
        End Function

    End Class
End Namespace