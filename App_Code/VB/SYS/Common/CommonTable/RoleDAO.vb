Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections.Generic
Imports System

Namespace SYS.Logic
    Public Class RoleDAO
        Inherits BaseDAO


        Public Function InsertData(ByVal role As Role) As Integer
            Dim d As New Dictionary(Of String, Object)
            d.Add("Orgcode", role.Orgcode)
            d.Add("Role_id", role.RoleId)
            d.Add("Role_name", role.RoleName)
            d.Add("Role_status", role.RoleStatus)
            d.Add("Manager_flag", role.ManagerFlag)
            d.Add("Boss_roleid", role.BossRoleid)
            d.Add("Change_userid", role.ChangeUserid)
            d.Add("Change_date", role.ChangeDate)
            Return InsertByExample("SYS_Role", d)
        End Function

        Public Function UpdateData(ByVal role As Role) As Integer
            Dim d As New Dictionary(Of String, Object)
            d.Add("Orgcode", role.Orgcode)
            d.Add("Role_name", role.RoleName)
            d.Add("Role_status", role.RoleStatus)
            d.Add("Manager_flag", role.ManagerFlag)
            d.Add("Boss_roleid", role.BossRoleid)
            d.Add("Change_userid", role.ChangeUserid)
            d.Add("Change_date", role.ChangeDate)

            Dim cd As New Dictionary(Of String, Object)
            cd.Add("Role_id", role.RoleId)
            Return UpdateByExample("SYS_Role", d, cd)
        End Function

        Public Function GetData(ByVal Orgcode As String) As DataTable
            Dim d As New Dictionary(Of String, Object)
            d.Add("Orgcode", Orgcode)
            Return GetDataByExample("SYS_Role", d)
        End Function

        Public Function GetDataByOrgRid(ByVal Orgcode As String, ByVal roleId As String) As DataTable
            Dim d As New Dictionary(Of String, Object)
            d.Add("Orgcode", Orgcode)
            d.Add("Role_id", roleId)
            Return GetDataByExample("SYS_Role", d)
        End Function

#Region "取得角色資料"
        Public Function GetDataByOrgDep(ByVal Orgcode As String) As DataTable
            Dim sql As New StringBuilder()
            sql.AppendLine(" SELECT Role_id, Role_name, Orgcode ")
            sql.AppendLine(" ,rtrim(isnull(Role_status,'1')) Role_status ")
            sql.AppendLine(" ,rtrim(isnull(Manager_flag,'N')) Manager_flag ")
            sql.AppendLine(" FROM SYS_Role WHERE Orgcode = @Orgcode")

            Dim aryParms(0) As SqlParameter
            aryParms(0) = New SqlParameter("@Orgcode", SqlDbType.VarChar)
            aryParms(0).Value = Orgcode
            Return Query(sql.ToString(), aryParms)
        End Function

        Public Function GetRoleByBossRole(ByVal Orgcode As String, ByVal Boss_Role_id As String) As DataTable
            Dim SQL As String = "SELECT Role_id, Role_name, Orgcode "
            SQL &= " ,rtrim(isnull(Role_status,'1')) Role_status "
            SQL &= " ,rtrim(isnull(Manager_flag,'N')) Manager_flag "
            SQL &= " ,isnull(Boss_Role_id,'') Boss_Role_id "
            SQL &= " ,(select top(1) Role_name from Role where Orgcode=@Orgcode and Role_id=rl.Boss_Role_id) Boss_Role_Name "
            SQL &= " FROM SYS_Role rl WHERE Orgcode = @Orgcode"
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

            Return Query(SQL, aryParms)
        End Function
#End Region

        Public Function GetRole(ByVal Orgcode As String, ByVal Role_id As String) As DataTable
            If String.IsNullOrEmpty(Role_id) Then
                Return Nothing
            End If

            Dim SQL As String = "SELECT Role_id, Role_name, Orgcode "
            SQL &= " ,rtrim(isnull(Role_status,'1')) Role_status "
            SQL &= " ,rtrim(isnull(Manager_flag,'N')) Manager_flag "
            SQL &= " FROM SYS_Role WHERE Orgcode = @Orgcode "
           

            Dim aryParms(Role_id.Split(",").Length) As SqlParameter
            aryParms(0) = New SqlParameter("@Orgcode", SqlDbType.VarChar)
            aryParms(0).Value = Orgcode
            If Not String.IsNullOrEmpty(Role_id) Then
                SQL &= " and Role_id in ( "

                For i As Integer = 0 To Role_id.Split(",").Length - 1
                    SQL &= "@Role_id" + i.ToString() + ","
                    aryParms(i + 1) = New SqlParameter("@Role_id" + i.ToString(), SqlDbType.VarChar)
                    aryParms(i + 1).Value = Role_id.Split(",")(i).Trim()
                Next
                SQL = SQL.TrimEnd(",")
                SQL &= ")"
            End If
            Return Query(SQL, aryParms)
        End Function


#Region "取得該角色的功能列"
        Public Function GetRolefunction(ByVal Orgcode As String, ByVal Role_id As String) As String
            Dim SQL As String = "SELECT     Role_id, Func_id, Orgcode"
            SQL &= " FROM SYS_Role_function "
            SQL &= " where Orgcode= @Orgcode "



            Dim rs() As String = Role_id.Split(",")
            SQL &= " and role_id in ( "
            For i As Integer = 0 To rs.Length - 1
                If i <> 0 Then
                    SQL &= ", "
                End If
                SQL &= " @role" & i
            Next
            SQL &= ")"

            Dim aryParms(1 + rs.Length) As SqlParameter
            aryParms(0) = New SqlParameter("@Orgcode", SqlDbType.VarChar)
            aryParms(0).Value = Orgcode
            aryParms(1) = New SqlParameter("@Role_id", SqlDbType.VarChar)
            aryParms(1).Value = Role_id

            For i As Integer = 0 To rs.Length - 1
                aryParms(2 + i) = New SqlParameter("@role" & i, SqlDbType.VarChar)
                aryParms(2 + i).Value = rs(i)
            Next

            Dim dt As DataTable = Query(SQL, aryParms)

            Dim strModule As String = ""
            For Each row As DataRow In dt.Rows
                strModule &= Convert.ToString(row.Item("Func_id")) & ","
            Next
            If strModule <> "" Then strModule = Left(strModule, strModule.Length - 1)
            Return strModule
        End Function
#End Region

#Region "刪除該角色的所有功能"
        Public Function DeleteRoleModules(ByVal Orgcode As String, ByVal Role_id As String) As Integer
            Dim SQL As String = "DELETE FROM SYS_Role_function where Role_id = @Role_id and Orgcode= @Orgcode"
            Dim aryParms(1) As SqlParameter
            aryParms(0) = New SqlParameter("@Role_id", SqlDbType.VarChar)
            aryParms(0).Value = Role_id
            aryParms(1) = New SqlParameter("@Orgcode", SqlDbType.VarChar)
            aryParms(1).Value = Orgcode

            Return Execute(SQL, aryParms)
        End Function
#End Region

#Region "新增該角色的功能"
        Public Function AddRoleModule(ByVal Orgcode As String, ByVal Role_id As String, ByVal Func_id As String, ByVal Change_userid As String) As Integer
            Dim SQL As String = ""
            SQL &= " INSERT INTO SYS_Role_function                                             "
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

            Return Execute(SQL, aryParms)
        End Function
#End Region

#Region "刪除該角色的所有表單"
        Public Function DeleteRoleForms(ByVal Orgcode As String, ByVal Role_id As String) As Integer
            Dim SQL As String = "DELETE FROM SYS_Role_form where Role_id = @Role_id and Orgcode= @Orgcode"
            Dim aryParms(1) As SqlParameter
            aryParms(0) = New SqlParameter("@Role_id", SqlDbType.VarChar)
            aryParms(0).Value = Role_id
            aryParms(1) = New SqlParameter("@Orgcode", SqlDbType.VarChar)
            aryParms(1).Value = Orgcode

            Return Execute(SQL, aryParms)
        End Function
#End Region

#Region "新增該角色的功能"
        Public Function AddRoleForm(ByVal Orgcode As String, ByVal Role_id As String, ByVal Form_id As String, ByVal Change_userid As String) As Integer
            Dim SQL As String = ""
            SQL &= " INSERT INTO SYS_Role_form                                             "
            SQL &= "           (Role_id, Form_id, Orgcode, Change_userid, Change_date)     "
            SQL &= " VALUES    (@Role_id, @Form_id, @Orgcode, @Change_userid, GETDATE())"

            Dim aryParms(3) As SqlParameter
            aryParms(0) = New SqlParameter("@Role_id", SqlDbType.VarChar)
            aryParms(0).Value = Role_id
            aryParms(1) = New SqlParameter("@Orgcode", SqlDbType.VarChar)
            aryParms(1).Value = Orgcode
            aryParms(2) = New SqlParameter("@Form_id", SqlDbType.VarChar)
            aryParms(2).Value = Form_id
            aryParms(3) = New SqlParameter("@Change_userid", SqlDbType.VarChar)
            aryParms(3).Value = Change_userid

            Return Execute(SQL, aryParms)
        End Function
#End Region

#Region "取得該角色的功能列"
        Public Function GetRoleForm(ByVal Orgcode As String, ByVal Role_id As String) As String
            Dim SQL As String = "SELECT distinct Form_id, Orgcode"
            SQL &= " FROM SYS_Role_form "
            SQL &= " where Orgcode= @Orgcode "

            Dim rs() As String = Role_id.Split(",")
            SQL &= " and role_id in ( "
            For i As Integer = 0 To rs.Length - 1
                If i <> 0 Then
                    SQL &= ", "
                End If
                SQL &= " @role" & i
            Next
            SQL &= ")"

            Dim aryParms(0 + rs.Length) As SqlParameter
            aryParms(0) = New SqlParameter("@Orgcode", SqlDbType.VarChar)
            aryParms(0).Value = Orgcode

            For i As Integer = 0 To rs.Length - 1
                aryParms(1 + i) = New SqlParameter("@role" & i, SqlDbType.VarChar)
                aryParms(1 + i).Value = rs(i)
            Next

            Dim dt As DataTable = Query(SQL, aryParms)
            Dim strModule As String = ""
            For Each row As DataRow In dt.Rows
                strModule &= Convert.ToString(row.Item("Form_id")) & ","
            Next
            If strModule <> "" Then strModule = Left(strModule, strModule.Length - 1)
            Return strModule
        End Function
#End Region

#Region "取得該角色的button"
        Public Function GetRoleButton(ByVal Orgcode As String, ByVal Role_id As String) As String
            Dim SQL As String = "SELECT distinct Button_id, Orgcode"
            SQL &= " FROM SYS_Role_button "
            SQL &= " where Orgcode= @Orgcode "

            Dim rs() As String = Role_id.Split(",")
            SQL &= " and role_id in ( "
            For i As Integer = 0 To rs.Length - 1
                If i <> 0 Then
                    SQL &= ", "
                End If
                SQL &= " @role" & i
            Next
            SQL &= ")"

            Dim aryParms(0 + rs.Length) As SqlParameter
            aryParms(0) = New SqlParameter("@Orgcode", SqlDbType.VarChar)
            aryParms(0).Value = Orgcode

            For i As Integer = 0 To rs.Length - 1
                aryParms(1 + i) = New SqlParameter("@role" & i, SqlDbType.VarChar)
                aryParms(1 + i).Value = rs(i)
            Next

            Dim dt As DataTable = Query(SQL, aryParms)
            Dim strModule As String = ""
            For Each row As DataRow In dt.Rows
                strModule &= Convert.ToString(row.Item("Button_id")) & ","
            Next
            If strModule <> "" Then strModule = Left(strModule, strModule.Length - 1)
            Return strModule
        End Function
#End Region


        Public Function GetFormButton(ByVal Orgcode As String, ByVal Role_id As String, ByVal Button_id As String) As String
            Dim SQL As String = "SELECT distinct Form_id, Orgcode"
            SQL &= " FROM SYS_Role_button "
            SQL &= " where Orgcode= @Orgcode "
            SQL &= " and Button_id=@Button_id "

            Dim rs() As String = Role_id.Split(",")
            SQL &= " and role_id in ( "
            For i As Integer = 0 To rs.Length - 1
                If i <> 0 Then
                    SQL &= ", "
                End If
                SQL &= " @role" & i
            Next
            SQL &= ")"

            Dim aryParms(1 + rs.Length) As SqlParameter
            aryParms(0) = New SqlParameter("@Orgcode", SqlDbType.VarChar)
            aryParms(0).Value = Orgcode
            aryParms(1) = New SqlParameter("@Button_id", SqlDbType.VarChar)
            aryParms(1).Value = Button_id

            For i As Integer = 0 To rs.Length - 1
                aryParms(2 + i) = New SqlParameter("@role" & i, SqlDbType.VarChar)
                aryParms(2 + i).Value = rs(i)
            Next

            Dim dt As DataTable = Query(SQL, aryParms)
            Dim strModule As String = ""
            For Each row As DataRow In dt.Rows
                strModule &= Convert.ToString(row.Item("Form_id")) & ","
            Next
            If strModule <> "" Then strModule = Left(strModule, strModule.Length - 1)
            Return strModule
        End Function


    End Class
End Namespace