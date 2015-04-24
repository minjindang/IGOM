Imports Microsoft.VisualBasic
Imports System.Data

Namespace FSCPLM.Logic
    Public Class CPAPHTR
        Public DAO As CPAPHTRDAO
        Public Sub New()
            DAO = New CPAPHTRDAO()
        End Sub

        Public Function GetCPAPHTRByFlow_id(ByVal Flow_id As String) As DataTable
            Return DAO.GetDataByFlow_id(Flow_id)
        End Function

    End Class
End Namespace