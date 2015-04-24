Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Collections.Generic

Namespace SALARY.Logic


    <System.ComponentModel.DataObject()> _
    Public Class SAL2105
        Public DAO As SAL2105DAO
        Public Sub New()
            DAO = New SAL2105DAO()
        End Sub

        Public Function GetDataByQuery(ByVal v_startYYMM As String, ByVal v_base_prono As String) As DataTable
            Dim dt As DataTable = DAO.GetDataByQuery(v_startYYMM, v_base_prono)
            If dt Is Nothing Then Return Nothing
            Return dt
        End Function

    End Class

End Namespace
