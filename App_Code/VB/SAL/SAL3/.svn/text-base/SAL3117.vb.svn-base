Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Collections.Generic

Namespace SALARY.Logic


    <System.ComponentModel.DataObject()> _
    Public Class SAL3117
        Public DAO As SAL3117DAO
        Public Sub New()
            DAO = New SAL3117DAO()
        End Sub

        Public Function SQLs1(ByVal v_freeze_time As String, ByVal v_UserId As String, ByVal v_orgid As String, ByVal code_no As String, ByVal yy As String, ByVal ym As String) As Boolean
            Dim ds As DataSet = DAO.SQLs1(v_freeze_time, v_UserId, v_orgid, code_no, yy, ym)
            If ds Is Nothing Then Return Nothing
            Return True
        End Function

    End Class

End Namespace
