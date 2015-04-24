Imports Microsoft.VisualBasic
Imports System.Data

Namespace PAY.Logic
    Public Class PAY2102
        Public DAO As PAY2102DAO

        Public Sub New()
            DAO = New PAY2102DAO()
        End Sub
        Public Function Select_01_01(ByVal PettyCash_nosS As String, _
                                      ByVal PettyCash_nosE As String, _
                                      ByVal Beneficiary_id As String, _
                                      ByVal Year As String) As DataTable
            Dim dt As DataTable
            dt = DAO.Select_01_01(PettyCash_nosS, PettyCash_nosE, Beneficiary_id, Year)
            If dt Is Nothing Then Return Nothing
            Return dt
        End Function
        Public Function Select_02_01(ByVal PettyCash_nosS As String, _
                                      ByVal PettyCash_nosE As String, _
                                      ByVal Beneficiary_id As String, _
                                      ByVal Year As String) As DataTable
            Dim dt As DataTable
            dt = DAO.Select_02_01(PettyCash_nosS, PettyCash_nosE, Beneficiary_id, Year)
            If dt Is Nothing Then Return Nothing
            Return dt
        End Function

        Public Function GetUNIT_TAX(UNIT_NO As String) As String
            Dim dt As DataTable = DAO.GetSAUNIT(UNIT_NO)
            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                Return dt.Rows(0)("UNIT_TAX")
            End If
            Return ""
        End Function
    End Class
End Namespace