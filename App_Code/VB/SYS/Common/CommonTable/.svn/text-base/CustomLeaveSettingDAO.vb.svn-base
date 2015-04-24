Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports Pemis2009.SQLAdapter

Namespace SYS.Logic
    Public Class CustomLeaveSettingDAO
        Inherits BaseDAO
        Dim ConnectionString As String = ""
        Public Sub New()
            ConnectionString = ConnectDB.GetDBString()
        End Sub

        Public Function GetData(ByVal Orgcode As String, ByVal leaveGroup As String, ByVal leaveType As String) As DataSet
            Dim StrSQL As StringBuilder = New StringBuilder
            StrSQL.AppendLine(" select cl.*, lg.Leave_group_name, lt.Leave_name ")
            StrSQL.AppendLine(" from SYS_Custom_leave_setting cl ")
            StrSQL.AppendLine(" inner join SYS_Leave_group lg on lg.Leave_group_id = cl.Leave_group_id ")
            StrSQL.AppendLine(" and lg.Orgcode = cl.Orgcode ")
            StrSQL.AppendLine(" inner join SYS_Leave_type lt on lt.leave_type = cl.leave_type ")
            StrSQL.AppendLine(" where 1=1 ")

            If Not String.IsNullOrEmpty(Orgcode) Then
                StrSQL.AppendLine(" and cl.Orgcode=@Orgcode ")
            End If
            If Not String.IsNullOrEmpty(leaveGroup) Then
                StrSQL.AppendLine(" and cl.Leave_group_id=@Leave_group_id ")
            End If
            If Not String.IsNullOrEmpty(leaveType) Then
                StrSQL.AppendLine(" and cl.leave_type=@leave_type ")
            End If

            Dim params() As SqlParameter = { _
            New SqlParameter("@Orgcode", SqlDbType.VarChar), _
            New SqlParameter("@Leave_group_id", SqlDbType.VarChar), _
            New SqlParameter("@Leave_type", SqlDbType.VarChar)}
            params(0).Value = Orgcode
            params(1).Value = leaveGroup
            params(2).Value = leaveType

            Return SqlAccessHelper.ExecuteDataset(Me.ConnectionString, CommandType.Text, StrSQL.ToString(), params)
        End Function

        Public Function GetData(ByVal Orgcode As String, ByVal leaveGroup As String, ByVal leaveType As String, ByVal role_id As String) As DataSet
            Dim StrSQL As StringBuilder = New StringBuilder
            StrSQL.AppendLine(" select distinct cl.*, lg.Leave_group_name, lt.Leave_name ")
            StrSQL.AppendLine(" from SYS_Custom_leave_setting cl ")
            StrSQL.AppendLine(" inner join SYS_Leave_group lg on lg.Leave_group_id = cl.Leave_group_id ")
            StrSQL.AppendLine(" inner join SYS_Role_custom_leave rc on rc.Custom_leave_setting_id = cl.id")
            StrSQL.AppendLine(" and lg.Orgcode = cl.Orgcode ")
            StrSQL.AppendLine(" inner join SYS_Leave_type lt on lt.leave_type = cl.leave_type ")
            StrSQL.AppendLine(" where 1=1 ")

            Dim params(role_id.Split(",").Length + 2) As SqlParameter

            If Not String.IsNullOrEmpty(Orgcode) Then
                StrSQL.AppendLine(" and cl.Orgcode=@Orgcode ")
            End If
            If Not String.IsNullOrEmpty(leaveGroup) Then
                StrSQL.AppendLine(" and cl.Leave_group_id=@Leave_group_id ")
            End If
            If Not String.IsNullOrEmpty(leaveType) Then
                StrSQL.AppendLine(" and cl.leave_type=@leave_type ")
            End If
            If Not String.IsNullOrEmpty(role_id) Then
                Dim sql As String = ""
                StrSQL.AppendLine(" and rc.Role_id in (")
                For i As Integer = 0 To role_id.Split(",").Length - 1
                    sql &= "@Role_id" + i.ToString() + ","
                    params(i + 3) = New SqlParameter("@Role_id" + i.ToString(), SqlDbType.VarChar)
                    params(i + 3).Value = role_id.Split(",")(i)
                Next
                sql = sql.TrimEnd(",")
                sql &= ")"
                StrSQL.AppendLine(sql)
            End If
            params(0) = New SqlParameter("@Orgcode", SqlDbType.VarChar)
            params(0).Value = Orgcode
            params(1) = New SqlParameter("@Leave_group_id", SqlDbType.VarChar)
            params(1).Value = leaveGroup
            params(2) = New SqlParameter("@leave_type", SqlDbType.VarChar)
            params(2).Value = leaveType

            Return SqlAccessHelper.ExecuteDataset(Me.ConnectionString, CommandType.Text, StrSQL.ToString(), params)
        End Function

        Public Function DeleteData(ByVal id As Integer) As String
            Dim StrSQL As String = "delete from SYS_Custom_leave_setting where id=@id"
            Dim param As SqlParameter = New SqlParameter("@id", SqlDbType.Int)
            param.Value = id
            Return SqlAccessHelper.ExecuteNonQuery(Me.ConnectionString, CommandType.Text, StrSQL, param)
        End Function

        Public Function GetDataById(ByVal id As Integer) As DataSet
            Dim StrSQL As String = String.Empty
            StrSQL = "select * from SYS_Custom_leave_setting where id=@id "
            Dim param As SqlParameter = New SqlParameter("@id", SqlDbType.Int)
            param.Value = id
            Return SqlAccessHelper.ExecuteDataset(Me.ConnectionString, CommandType.Text, StrSQL, param)
        End Function
    End Class
End Namespace
