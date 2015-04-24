Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration

Namespace SYS.Logic
    Public Class LeaveGroupDAO
        Inherits BaseDAO

        ''' <summary>
        ''' [差假別類型維護設定檔]
        ''' 差假類別
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetLeaveGroupInfo(ByVal Orgcode As String, ByVal DepartID As String) As DataTable
            Dim StrSQL As String = ""
            StrSQL = "select Orgcode, Depart_id as DepartID, Leave_group_name as LeaveGroupName, leave_group_id as LeaveGroupID  from SYS_Leave_group Where 1=1 "

            If Orgcode <> "" Then
                StrSQL &= " And Orgcode = @Orgcode "
            End If
            If DepartID <> "" Then
                StrSQL &= " And Depart_ID = @DepartID "
            End If
            StrSQL += " ORDER BY Leave_group_id "

            Dim params() As SqlParameter = { _
            New SqlParameter("@Orgcode", Orgcode), _
            New SqlParameter("@DepartID", DepartID)}

            Return Query(StrSQL, params)
        End Function

        Public Function GetDataByOrgcode(ByVal Orgcode As String) As DataTable
            Dim StrSQL As String = ""
            StrSQL = "select Orgcode, Depart_id as DepartID, Leave_group_name as LeaveGroupName, leave_group_id as LeaveGroupID from SYS_Leave_group Where 1=1 "

            If Orgcode <> "" Then
                StrSQL &= " and Orgcode = @Orgcode  "
            End If

            Dim params() As SqlParameter = { _
            New SqlParameter("@Orgcode", Orgcode)}

            Return Query(StrSQL, params)
        End Function

        Public Function GetDataByOrgcodelgID(ByVal Orgcode As String, ByVal Leave_group_id As String) As DataTable
            Dim StrSQL As String = ""
            StrSQL = "select id, Orgcode, Leave_group_name, leave_group_id from SYS_Leave_group "
            StrSQL &= " where 1=1 "
            If Orgcode <> "" Then
                StrSQL &= " and Orgcode = @Orgcode "
            End If
            If Leave_group_id <> "" Then
                StrSQL &= " and Leave_group_id = @Leave_group_id "
            End If

            Dim params() As SqlParameter = { _
            New SqlParameter("@Orgcode", Orgcode), _
            New SqlParameter("@Leave_group_id", Leave_group_id)}

            Return Query(StrSQL, params)
        End Function

        Public Function GetLeaveGroup2(ByVal Orgcode As String, ByVal LeaveGroupID As String, ByVal DepartID As String) As DataTable
            Dim StrSQL As String = String.Empty

            StrSQL = "select Orgcode, Depart_id as DepartID, Leave_group_name as LeaveGroupName, leave_group_id as LeaveGroupID  from Leave_group "
            StrSQL &= " where Orgcode=@ "

            StrSQL = String.Format(StrSQL, Orgcode)

            If Not String.IsNullOrEmpty(LeaveGroupID) Then
                StrSQL &= " and Leave_group_id=@Leave_group_id "
            End If

            If Not String.IsNullOrEmpty(DepartID) Then
                StrSQL &= " and Depart_id=@Depart_id "
            End If

            Dim params() As SqlParameter = { _
            New SqlParameter("@Orgcode", Orgcode), _
            New SqlParameter("@Leave_group_id", LeaveGroupID), _
            New SqlParameter("@Depart_id", DepartID)}

            Return Query(StrSQL, params)
        End Function

        Public Function DeleteData(ByVal id As Integer) As String
            Dim StrSQL As String = "delete from Leave_group where id=@id"
            Dim param As SqlParameter = New SqlParameter("@id", SqlDbType.Int)
            param.Value = id
            Return Execute(StrSQL, param)
        End Function

        Public Function InsertData(ByVal Orgcode As String, ByVal GroupId As String, ByVal DepartId As String, ByVal GroupName As String) As Integer
            Dim StrSQL As String = "insert into Leave_group(Orgcode,Leave_group_id,Depart_id,Leave_group_name)"
            StrSQL += " values(@Orgcode,@Leave_group_id,@Depart_id,@Leave_group_name)"

            Dim params() As SqlParameter = { _
            New SqlParameter("@Orgcode", SqlDbType.VarChar), _
            New SqlParameter("@Leave_group_id", SqlDbType.VarChar), _
            New SqlParameter("@Depart_id", SqlDbType.VarChar), _
            New SqlParameter("@Leave_group_name", SqlDbType.VarChar)}
            params(0).Value = Orgcode
            params(1).Value = GroupId
            params(2).Value = DepartId
            params(3).Value = GroupName

            Return Execute(StrSQL, params)
        End Function

        Public Function UpdateData(ByVal Orgcode As String, ByVal GroupId As String, ByVal DepartId As String, ByVal GroupName As String, ByVal id As Integer) As Integer
            Dim StrSQL As String = "update Leave_group set Orgcode=@Orgcode, Leave_group_id=@Leave_group_id, Depart_id=@Depart_id,"
            StrSQL += "Leave_group_name=@Leave_group_name where id=@id"

            Dim params() As SqlParameter = { _
            New SqlParameter("@Orgcode", SqlDbType.VarChar), _
            New SqlParameter("@Leave_group_id", SqlDbType.VarChar), _
            New SqlParameter("@Depart_id", SqlDbType.VarChar), _
            New SqlParameter("@Leave_group_name", SqlDbType.VarChar), _
            New SqlParameter("@id", SqlDbType.Int)}
            params(0).Value = Orgcode
            params(1).Value = GroupId
            params(2).Value = DepartId
            params(3).Value = GroupName
            params(4).Value = id

            Return Execute(StrSQL, params)
        End Function

        Public Function GetDataById(ByVal id As Integer) As DataTable
            Dim StrSQL As String = String.Empty
            StrSQL = "select * from Leave_group where id=@id "
            Dim param As SqlParameter = New SqlParameter("@id", SqlDbType.Int)
            param.Value = id
            Return Query(StrSQL, param)
        End Function

        Public Function GetCustomGroup(ByVal Orgcode As String) As DataTable
            Dim StrSQL As String = String.Empty
            StrSQL = "select * from SYS_Leave_group where Orgcode=@Orgcode "
            StrSQL += " and Leave_group_id not in ('A','B','C','D','E','F','G') "
            Dim param As SqlParameter = New SqlParameter("@Orgcode", SqlDbType.VarChar)
            param.Value = Orgcode
            Return Query(StrSQL, param)
        End Function
    End Class
End Namespace
