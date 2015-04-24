Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Pemis2009.SQLAdapter
Imports System.Text

Namespace SYS.Logic
    Public Class LeaveTypeDAO
        Inherits BaseDAO

        Public Function GetData(ByVal Orgcode As String, ByVal LeaveGroup As String) As DataTable
            Dim StrSQL As String = String.Empty

            StrSQL = "select lt.leave_type, lt.leave_type as LeaveType, lt.leave_name, lt.leave_name as LeaveName " & _
                    "from SYS_Leave_mapping lm, SYS_Leave_type lt " & _
                    "Where lm.Leave_group_id=@Leave_group_id and lm.leave_type=lt.leave_type and lm.Orgcode=@Orgcode " & _
                    "order by lt.leave_type "

            Dim params() As SqlParameter = {New SqlParameter("@Leave_group_id", SqlDbType.VarChar), New SqlParameter("@Orgcode", SqlDbType.VarChar)}
            params(0).Value = LeaveGroup
            params(1).Value = Orgcode

            Return Query(StrSQL, params)
        End Function

        Public Function GetData2(ByVal Orgcode As String, ByVal LeaveGroupList As String) As DataTable
            Dim sql As New StringBuilder

            sql.AppendLine(" select lt.leave_type, lt.leave_type as LeaveType, lt.leave_name, lt.leave_name as LeaveName ")
            sql.AppendLine(" from SYS_Leave_mapping lm, SYS_Leave_type lt ")
            sql.AppendLine(" Where lm.leave_type=lt.leave_type and lm.Orgcode=@Orgcode ")
            sql.AppendLine("        and lm.Leave_group_id in (" & LeaveGroupList & ") ")
            sql.AppendLine(" order by lt.leave_type ")

            Dim params() As SqlParameter = {New SqlParameter("@Orgcode", SqlDbType.VarChar)}
            params(0).Value = Orgcode

            Return Query(sql.ToString, params)
        End Function

        Public Function GetData(ByVal Orgcode As String) As DataTable
            Dim StrSQL As String = String.Empty

            StrSQL = "SELECT DISTINCT lt.leave_type, lt.leave_type as LeaveType, lt.leave_name, lt.leave_name as LeaveName " & _
                    "from SYS_Leave_mapping lm, SYS_Leave_type lt Where lm.leave_type=lt.leave_type and lm.Orgcode=@Orgcode " & _
                    "order by lt.leave_type "

            Dim param As SqlParameter = New SqlParameter("@Orgcode", SqlDbType.VarChar)
            param.Value = Orgcode
            Return Query(StrSQL, param)
        End Function
        '=============================20140422=============================================
        Public Function GetData1(ByVal Leavetable As String) As DataTable
            Dim StrSQL As String = String.Empty

            StrSQL = "SELECT * from SYS_Leave_type WHERE Leave_table = @Leavetable "

            Dim param As SqlParameter = New SqlParameter("@Leavetable", SqlDbType.VarChar)
            param.Value = Leavetable
            Return Query(StrSQL, param)
        End Function

        Public Function GetData() As DataTable
            Dim StrSQL As String = String.Empty
            StrSQL = "SELECT lt.leave_type, lt.leave_name from SYS_Leave_type lt order by lt.leave_type "
            Return Query(StrSQL)
        End Function

        Public Function GetDataByLeave_type(ByVal Leave_type As String) As DataTable
            Dim StrSQL As New StringBuilder
            StrSQL.Append("SELECT * FROM SYS_Leave_type ")
            If Leave_type <> "" Then
                StrSQL.Append(" WHERE Leave_type=@Leave_type")
                Dim param As SqlParameter = New SqlParameter("@Leave_type", SqlDbType.VarChar)
                param.Value = Leave_type
                Return Query(StrSQL.ToString(), param)
            Else
                Return Query(StrSQL.ToString())
            End If
        End Function

        Public Function DeleteData(ByVal id As Integer) As Integer
            Dim StrSQL As String = "delete from SYS_Leave_type where id=@id"
            Dim param As SqlParameter = New SqlParameter("@id", SqlDbType.Int)
            param.Value = id
            Return Execute(StrSQL, param)
        End Function

        Public Function InsertData(ByVal LeaveType As String, ByVal LeaveName As String) As Integer
            Dim StrSQL As String = "insert into SYS_Leave_type(Leave_type,Leave_name)"
            StrSQL += " values(@Leave_type,@Leave_name)"

            Dim params() As SqlParameter = { _
            New SqlParameter("@Leave_type", SqlDbType.VarChar), _
            New SqlParameter("@Leave_name", SqlDbType.VarChar)}
            params(0).Value = LeaveType
            params(1).Value = LeaveName

            Return Execute(StrSQL, params)
        End Function

        Public Function UpdateData(ByVal LeaveType As String, ByVal LeaveName As String, ByVal id As Integer) As Integer
            Dim StrSQL As String = "update SYS_Leave_type set Leave_type=@Leave_type, Leave_name=@Leave_name where id=@id"

            Dim params() As SqlParameter = { _
            New SqlParameter("@Leave_type", SqlDbType.VarChar), _
            New SqlParameter("@Leave_name", SqlDbType.VarChar), _
            New SqlParameter("@id", SqlDbType.Int)}
            params(0).Value = LeaveType
            params(1).Value = LeaveName
            params(2).Value = id

            Return Execute(StrSQL, params)
        End Function

        Public Function GetDataById(ByVal id As Integer) As DataTable
            Dim StrSQL As String = String.Empty
            StrSQL = "select * from SYS_Leave_type where id=@id "
            Dim param As SqlParameter = New SqlParameter("@id", SqlDbType.Int)
            param.Value = id
            Return Query(StrSQL, param)
        End Function

        Public Function GetDataBySexFlag(orgcode As String, sexFlag As String) As DataTable
            Dim StrSQL As String = "select * from  SYS_Leave_type where orgcode=@orgcode and sex_flag=@sexFlag "

            Dim params() As SqlParameter = { _
            New SqlParameter("@orgcode", SqlDbType.VarChar), _
            New SqlParameter("@sexFlag", SqlDbType.VarChar)}
            params(0).Value = orgcode
            params(1).Value = sexFlag

            Return Query(StrSQL, params)
        End Function
    End Class
End Namespace
