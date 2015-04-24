Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports Pemis2009.SQLAdapter

Namespace FSC.Logic
    Public Class LeaveSettingDAO
        Inherits BaseDAO

        Public Sub New()
            MyBase.New()

        End Sub

        Public Function GetDataByQuery(ByVal Orgcode As String, _
                                       ByVal LeaveKind As String, _
                                       ByVal LeaveType As String, _
                                       ByVal employeeType As String) As DataTable
            Dim sql As New StringBuilder()
            sql.AppendLine(" select a.*, b.* ")
            sql.AppendLine(" from FSC_Leave_setting a ")
            sql.AppendLine(" inner join FSC_Leave_setting_detail b on a.id=b.leave_setting_id ")
            sql.AppendLine(" where orgcode=@orgcode ")
            sql.AppendLine(" and leave_kind=@leaveKind ")
            sql.AppendLine(" and Leave_type=@LeaveType ")
            sql.AppendLine(" and memcod=@employeeType ")

            Dim params() As SqlParameter = { _
                New SqlParameter("@orgcode", Orgcode), _
                New SqlParameter("@leaveKind", LeaveKind), _
                New SqlParameter("@LeaveType", LeaveType), _
                New SqlParameter("@employeeType", employeeType)}

            Return Query(sql.ToString(), params)
        End Function
    End Class
End Namespace
