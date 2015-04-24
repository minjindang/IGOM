Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Collections.Generic

Namespace SALARY.Logic
    <System.ComponentModel.DataObject()> _
    Public Class SAL1102
        Public DAO As SAL1102DAO
        Public Sub New()
            DAO = New SAL1102DAO()
        End Sub

        Public Function GetApplyDataByDate(ByVal Apply_ym As String) As DataTable
            Dim ds As DataSet = DAO.GetApplyDataByDate(Apply_ym)
            If ds Is Nothing Then Return Nothing
            Return ds.Tables(0)
        End Function



    End Class
End Namespace