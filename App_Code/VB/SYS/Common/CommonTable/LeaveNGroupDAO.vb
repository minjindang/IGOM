Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports Pemis2009.SQLAdapter

Namespace SYS.Logic
    Public Class LeaveNGroupDAO
        Inherits BaseDAO

        Public Sub New()
            MyBase.New()
        End Sub

        Public Function GetLeaveNGroup(ByVal Leave_type As String, Optional ByVal isLevelOne As Boolean = False) As DataTable
            Dim sql As String = String.Empty

            sql = " select b.leave_ngroup as value, b.leave_ngroup_name as text from SYS_leave_ngroup_mapping a, SYS_leave_ngroup b "
            sql += " where a.leave_ngroup_id=b.id and leave_type=@Leave_type "
            'Elbert20130522 如果登入者是一級機關首長則群組請假、群組公差不要出現
            If isLevelOne Then
                sql += " and b.Leave_ngroup not in('A3','C3') "
            End If
            Dim params() As SqlParameter = {New SqlParameter("@Leave_type", SqlDbType.VarChar)}
            params(0).Value = Leave_type

            DBUtil.SetParamsNull(params)
            Return Query(sql, params)

        End Function

    End Class
End Namespace
