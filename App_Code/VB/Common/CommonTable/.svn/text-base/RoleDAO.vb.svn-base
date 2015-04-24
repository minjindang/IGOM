Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System

Namespace FSCPLM.Logic
    Public Class RoleDAO

#Region "Field"
        Private _CARD As String = String.Empty          ' 1.工作號碼
        Private _PASS As String = String.Empty          ' 2.密碼
        Dim conn As SqlClient.SqlConnection
        Dim train As SqlClient.SqlTransaction
#End Region

#Region "Property"

        'BLL被建立時即傳入SqlConnection物件
        Public Sub New(ByVal cn As SqlClient.SqlConnection)
            conn = cn
        End Sub
        'DAO被建立時傳入SqlTransaction，表示執行DAO時，要以交易的方式執行
        Public Sub New(ByVal trn As SqlClient.SqlTransaction)
            train = trn
        End Sub

        ''' <summary>
        ''' 工作號碼
        ''' </summary>
        ''' <remarks></remarks>
        Public Property CARD() As String
            Get
                Return _CARD
            End Get
            Set(ByVal value As String)
                _CARD = value
            End Set
        End Property
        ''' <summary>
        ''' 密碼
        ''' </summary>
        ''' <remarks></remarks>
        Public Property PASS() As String
            Get
                Return _PASS
            End Get
            Set(ByVal value As String)
                _PASS = value
            End Set
        End Property
#End Region

        Public Function CheckEqualPwd(ByVal NewPwd As String, ByVal ConfirmPwd As String) As String
            Dim CheckMessage As String = ""
            If Not NewPwd.Trim() = ConfirmPwd.Trim() Then
                CheckMessage = "新密碼與舊密碼不同，請重新輸入!"
            End If
            Return CheckMessage
        End Function

#Region "取得角色資料"
        Public Function Get_Role(ByVal Orgcode As String) As DataTable
            Dim SQL As String = "SELECT Role_id, Role_name, Orgcode "
            SQL &= " ,rtrim(isnull(Manager_flag,'N')) Manager_flag"
            SQL &= " ,rtrim(isnull(Role_status,'1')) Role_status "
            SQL &= " ,Delete_flag "
            SQL &= " FROM Role WHERE Orgcode = @Orgcode"
            Dim aryParms(0) As SqlParameter
            aryParms(0) = New SqlParameter("@Orgcode", SqlDbType.VarChar)
            aryParms(0).Value = Orgcode
            Return Pemis2009.SQLAdapter.SqlAccessHelper.ExecuteDataset(conn, CommandType.Text, SQL, aryParms).Tables(0)
        End Function

        Public Function Get_RoleByBossRole(ByVal Orgcode As String, ByVal Boss_Role_id As String) As DataTable
            Dim SQL As String = "SELECT Role_id, Role_name, Orgcode "
            SQL &= " ,rtrim(isnull(Manager_flag,'N')) Manager_flag"
            SQL &= " ,rtrim(isnull(Role_status,'1')) Role_status "
            SQL &= " ,Delete_flag, isnull(Boss_Role_id,'') Boss_Role_id "
            SQL &= " ,(select top(1) Role_name from Role where Orgcode=@Orgcode and Role_id=rl.Boss_Role_id) Boss_Role_Name "
            SQL &= " FROM Role rl WHERE Orgcode = @Orgcode"
            SQL &= " and (Boss_Role_id is null or Boss_Role_id = '' or Boss_Role_id in ("

            Dim aryParms(Boss_Role_id.Split("、").Length) As SqlParameter
            aryParms(0) = New SqlParameter("@Orgcode", SqlDbType.VarChar)
            aryParms(0).Value = Orgcode

            For i As Integer = 0 To Boss_Role_id.Split("、").Length - 1
                SQL &= "@Role_id" + i.ToString() + ","
                aryParms(i + 1) = New SqlParameter("@Role_id" + i.ToString(), SqlDbType.VarChar)
                aryParms(i + 1).Value = Boss_Role_id.Split("、")(i)
            Next

            SQL = SQL.TrimEnd(",")
            SQL &= "))"

            Return Pemis2009.SQLAdapter.SqlAccessHelper.ExecuteDataset(conn, CommandType.Text, SQL, aryParms).Tables(0)
        End Function
#End Region

        Public Function Get_Role(ByVal Orgcode As String, ByVal Role_id As String) As DataTable
            Dim SQL As String = "SELECT Role_id, Role_name, Orgcode "
            SQL &= " ,rtrim(isnull(Manager_flag,'N')) Manager_flag"
            SQL &= " ,rtrim(isnull(Role_status,'1')) Role_status "
            SQL &= " ,Delete_flag "
            'SQL &= " FROM Role WHERE Orgcode = @Orgcode AND Role_id = @Role_id"
            SQL &= " FROM Role WHERE Orgcode = @Orgcode"
            SQL &= " and Role.Role_id in ("
            Dim aryParms(Role_id.Split("、").Length) As SqlParameter
            'aryParms(0) = New SqlParameter("@Role_id", SqlDbType.VarChar)
            'aryParms(0).Value = Role_id
            aryParms(0) = New SqlParameter("@Orgcode", SqlDbType.VarChar)
            aryParms(0).Value = Orgcode
            For i As Integer = 0 To Role_id.Split("、").Length - 1
                SQL &= "@Role_id" + i.ToString() + ","
                aryParms(i + 1) = New SqlParameter("@Role_id" + i.ToString(), SqlDbType.VarChar)
                aryParms(i + 1).Value = Role_id.Split("、")(i)
            Next
            SQL = SQL.TrimEnd(",")
            SQL &= ")"
            Return Pemis2009.SQLAdapter.SqlAccessHelper.ExecuteDataset(conn, CommandType.Text, SQL, aryParms).Tables(0)
        End Function

#Region "更新角色資料"
        Public Function Update_Role(ByVal Role_name As String, ByVal Manager_flag As String, ByVal Role_status As String, ByVal Orgcode As String, ByVal Role_id As String, ByVal Boss_Role_id As String) As Boolean
            Dim SQL As String = "UPDATE   Role"
            SQL &= " SET      Role_name = @Role_name, Manager_flag = @Manager_flag, Role_status = @Role_status, Boss_Role_id=@Boss_Role_id "
            SQL &= " WHERE   (Orgcode = @Orgcode) AND (Role_id = @Role_id)"

            Dim aryParms(5) As SqlParameter
            aryParms(0) = New SqlParameter("@Role_name", SqlDbType.VarChar)
            aryParms(0).Value = Role_name
            aryParms(1) = New SqlParameter("@Manager_flag", SqlDbType.VarChar)
            aryParms(1).Value = Manager_flag
            aryParms(2) = New SqlParameter("@Role_status", SqlDbType.VarChar)
            aryParms(2).Value = Role_status
            aryParms(3) = New SqlParameter("@Orgcode", SqlDbType.VarChar)
            aryParms(3).Value = Orgcode
            aryParms(4) = New SqlParameter("@Role_id", SqlDbType.VarChar)
            aryParms(4).Value = Role_id
            aryParms(5) = New SqlParameter("@Boss_Role_id", SqlDbType.VarChar)
            aryParms(5).Value = Boss_Role_id

            If Not (train Is Nothing) Then
                Return Pemis2009.SQLAdapter.SqlAccessHelper.ExecuteNonQuery(train, CommandType.Text, SQL, aryParms)
            Else
                Return Pemis2009.SQLAdapter.SqlAccessHelper.ExecuteNonQuery(conn, CommandType.Text, SQL, aryParms)
            End If
        End Function
#End Region

#Region "新增該角色資料"
        Public Function AddRole(ByVal Role_id As String, ByVal Role_name As String, ByVal Orgcode As String, ByVal Manager_flag As String, ByVal Role_status As String, ByVal Change_userid As String, ByVal Boss_Role_id As String) As Boolean
            Dim SQL As String = ""
            SQL &= " INSERT INTO Role "
            SQL &= "           (Role_id, Role_name, Orgcode, Manager_flag, Role_status, Delete_flag, Change_userid, Change_date, Boss_Role_id) "
            SQL &= " VALUES    (@Role_id, @Role_name, @Orgcode, 'N', @Role_status, 'N', @Change_userid, GETDATE(), @Boss_Role_id) "

            Dim aryParms(6) As SqlParameter
            aryParms(0) = New SqlParameter("@Role_id", SqlDbType.VarChar)
            aryParms(0).Value = Role_id
            aryParms(1) = New SqlParameter("@Orgcode", SqlDbType.VarChar)
            aryParms(1).Value = Orgcode
            aryParms(2) = New SqlParameter("@Role_status", SqlDbType.VarChar)
            aryParms(2).Value = Role_status
            aryParms(3) = New SqlParameter("@Change_userid", SqlDbType.VarChar)
            aryParms(3).Value = Change_userid
            aryParms(4) = New SqlParameter("@Role_name", SqlDbType.VarChar)
            aryParms(4).Value = Role_name
            aryParms(5) = New SqlParameter("@Manager_flag", SqlDbType.VarChar)
            aryParms(5).Value = Manager_flag
            aryParms(6) = New SqlParameter("@Boss_Role_id", SqlDbType.VarChar)
            aryParms(6).Value = Boss_Role_id

            Return Pemis2009.SQLAdapter.SqlAccessHelper.ExecuteNonQuery(conn, CommandType.Text, SQL, aryParms) = 1

        End Function
#End Region

#Region "取得所有功能列"
        Public Function Get_Func() As DataTable
            Dim SQL As String = " select * from func order by func_id,parent_func_id,func_sort "
            Return Pemis2009.SQLAdapter.SqlAccessHelper.ExecuteDataset(conn, CommandType.Text, SQL).Tables(0)
        End Function
#End Region

#Region "取得該角色的功能列"
        Public Function Get_Role_function(ByVal Role_id As String, ByVal Orgcode As String) As String
            Dim SQL As String = "SELECT     Role_id, Func_id, Orgcode"
            SQL &= " FROM Role_function "
            SQL &= " where Role_id = @Role_id and Orgcode= @Orgcode "
            Dim aryParms(1) As SqlParameter
            aryParms(0) = New SqlParameter("@Role_id", SqlDbType.VarChar)
            aryParms(0).Value = Role_id
            aryParms(1) = New SqlParameter("@Orgcode", SqlDbType.VarChar)
            aryParms(1).Value = Orgcode
            Dim dt As DataTable = Pemis2009.SQLAdapter.SqlAccessHelper.ExecuteDataset(conn, CommandType.Text, SQL, aryParms).Tables(0)
            Dim strModule As String = ""
            For Each row As DataRow In dt.Rows
                strModule &= Convert.ToString(row.Item("Func_id")) & ","
            Next
            If strModule <> "" Then strModule = Left(strModule, strModule.Length - 1)
            Return strModule
        End Function
#End Region

#Region "刪除該角色的所有功能"
        Public Function DeleteRoleModules(ByVal Role_id As String, ByVal Orgcode As String) As Boolean
            Dim SQL As String = "DELETE FROM Role_function where Role_id = @Role_id and Orgcode= @Orgcode"
            Dim aryParms(1) As SqlParameter
            aryParms(0) = New SqlParameter("@Role_id", SqlDbType.VarChar)
            aryParms(0).Value = Role_id
            aryParms(1) = New SqlParameter("@Orgcode", SqlDbType.VarChar)
            aryParms(1).Value = Orgcode

            If train Is Nothing Then
                Return Pemis2009.SQLAdapter.SqlAccessHelper.ExecuteNonQuery(conn, CommandType.Text, SQL, aryParms)
            Else
                Return Pemis2009.SQLAdapter.SqlAccessHelper.ExecuteNonQuery(train, CommandType.Text, SQL, aryParms)
            End If
        End Function
#End Region

#Region "新增該角色的功能"
        Public Function AddRoleModule(ByVal Role_id As String, ByVal Orgcode As String, ByVal Func_id As String, ByVal Change_userid As String) As Boolean
            Dim SQL As String = ""
            SQL &= " INSERT INTO Role_function                                             "
            SQL &= "           (Role_id, Func_id, Orgcode, Change_userid, Change_date)     "
            SQL &= " VALUES    (@Role_id, @Func_id, @Orgcode, @Change_userid, GETDATE())"

            Dim aryParms(3) As SqlParameter
            aryParms(0) = New SqlParameter("@Role_id", SqlDbType.VarChar)
            aryParms(0).Value = Role_id
            aryParms(1) = New SqlParameter("@Orgcode", SqlDbType.VarChar)
            aryParms(1).Value = Orgcode
            aryParms(2) = New SqlParameter("@Func_id", SqlDbType.VarChar)
            aryParms(2).Value = Func_id
            aryParms(3) = New SqlParameter("@Change_userid", SqlDbType.VarChar)
            aryParms(3).Value = Change_userid

            If train Is Nothing Then
                Return Pemis2009.SQLAdapter.SqlAccessHelper.ExecuteNonQuery(conn, CommandType.Text, SQL, aryParms)
            Else
                Return Pemis2009.SQLAdapter.SqlAccessHelper.ExecuteNonQuery(train, CommandType.Text, SQL, aryParms)
            End If

        End Function
#End Region

    End Class
End Namespace