Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Collections.Generic

Namespace SALARY.Logic


    <System.ComponentModel.DataObject()> _
    Public Class SAL2104
        Public DAO As SAL2104DAO
        Public Sub New()
            DAO = New SAL2104DAO()
        End Sub

        Public Function GetDataByQuery(ByVal v_UserOrgId As String, ByVal ym As String, Optional ByVal code_no As String = "") As DataTable
            Dim ds As DataSet = DAO.SQLs1(v_UserOrgId, ym, code_no)
            If ds Is Nothing Then Return Nothing
            Return ds.Tables(0)
        End Function

    End Class

End Namespace
