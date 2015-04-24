Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Collections.Generic

Namespace SALARY.Logic


    <System.ComponentModel.DataObject()> _
    Public Class SAL3105
        Public DAO As SAL3105DAO
        Public Sub New()
            DAO = New SAL3105DAO()
        End Sub

        Public Function GetDataByQuery(ByVal v_Orgcode As String, ByVal v_Edate As String, ByVal v_prono As String, ByVal v_Year As String, ByVal v_Str As String, ByVal v_dept As String, ByVal v_id_card As String) As DataTable
            Dim ds As DataSet = DAO.SQLs1(v_Orgcode, v_Edate, v_prono, v_Year, v_Str, v_dept, v_id_card)
            If ds Is Nothing Then Return Nothing
            Return ds.Tables(0)
        End Function

        Public Function GetBaseData(ByVal v_Orgcode As String, ByVal v_Year As String, ByVal v_prono As String, ByVal v_dept As String, ByVal v_id_card As String) As DataTable
            Dim ds As DataSet = DAO.Query_Base(v_Orgcode, v_Year, v_prono, v_dept, v_id_card)
            If ds Is Nothing Then Return Nothing
            Return ds.Tables(0)
        End Function

    End Class

End Namespace
