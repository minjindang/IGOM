Imports FSCPLM.Logic
Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient

Namespace IGOM.Logic

    Public Class LoginInfo
        Shared DAO As BaseDAO

        Shared Sub New()
            DAO = New BaseDAO()
        End Sub


        Public Shared Function GetUserData(ByVal psn As FSC.Logic.Personnel, ByVal account As String) As String

            Dim name As String = psn.UserName       '姓名
            Dim idCard As String = psn.IdCard       '當下使用者員工編號"

            Dim titleNo As String = psn.TitleNo     '職稱代碼
            Dim orgcode As String = ""              '機關代碼
            Dim departId As String = ""             '單位代碼
            Dim departName As String = ""           '單位名稱
            Dim email As String = ""                'email
            Dim roleId As String = psn.RoleId       '角色代號
            Dim employeeType As String = psn.EmployeeType
            Dim serviceType As String = "0"

            Dim personnelId As String = psn.IdCard
            Dim ADId As String = psn.ADId
            Dim isAdmin As Byte = 0        '是否為最高管理者 
            Dim fromAD As String = ConfigurationManager.AppSettings("fromAD")
            Dim BossLevelId As String = psn.Boss_level_id
            Dim Id_Number As String = psn.Id_number
            Dim isGeneral As Byte = 0 '是否為一般人員

            Dim departEmp As New FSC.Logic.DepartEmp()

            '借調人員
            If "9" = employeeType Then
                serviceType = "1"
            End If

            Dim dt As DataTable = departEmp.GetDataByServiceType(idCard, serviceType)
            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                orgcode = dt.Rows(0)("Orgcode").ToString()
                departId = dt.Rows(0)("Depart_id").ToString()
                departName = dt.Rows(0)("Depart_name").ToString()
            Else
                Return ""
            End If

            '判斷此管理者是否為最高管理群組，若是則所有功能都可以使用，不必再查詢模組權限
            If GetMemberIsAdimistrator(roleId, orgcode, departId) Then '此管理者為最高管理群組
                isAdmin = 1   '設定為最高管理者 
            End If

            If getIsGeneral(roleId, BossLevelId) Then
                isGeneral = 1
            End If

            '組成放入驗證票的使用者資訊
            Dim userData As String = ""
            userData &= account & ";"         '帳號(身份証字號)
            userData &= name & ";"            '姓名
            userData &= idCard & ";"          '身份証字號
            userData &= titleNo & ";"         '職稱代碼
            userData &= orgcode & ";"         '機關代碼
            userData &= departId & ";"        '單位代號
            userData &= departName & ";"      '單位名稱
            userData &= email & ";"           'email
            userData &= roleId & ";"          '角色代號
            userData &= isAdmin & ";"         '是否為最高管理者 
            userData &= personnelId & ";"
            userData &= serviceType & ";"
            userData &= ADId & ";"
            userData &= fromAD & ";"          '是否為最高管理者
            userData &= BossLevelId & ";"
            userData &= Id_Number & ";"
            userData &= isGeneral & ";"
            userData &= employeeType & ";"

            Return userData
        End Function



        Public Shared Function GetUserData(orgcode As String, departId As String, psn As FSC.Logic.Personnel, account As String) As String

            Dim name As String = psn.UserName       '姓名
            Dim idCard As String = psn.IdCard       '當下使用者員工編號"
            Dim titleNo As String = psn.TitleNo     '職稱代碼
            Dim email As String = ""                'email
            Dim roleId As String = psn.RoleId       '角色代號
            Dim employeeType As String = psn.EmployeeType
            Dim serviceType As String = "0"

            If String.IsNullOrEmpty(departId) Then
                departId = New FSC.Logic.DepartEmp().GetDepartId(psn.IdCard)
            End If

            Dim dt As DataTable = New FSC.Logic.DepartEmp().GetDataByDepartId(orgcode, departId)
            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                serviceType = dt.Rows(0)("Service_type").ToString()
            End If

            Dim personnelId As String = psn.IdCard
            Dim ADId As String = psn.ADId
            Dim isAdmin As Byte = 0        '是否為最高管理者 
            Dim fromAD As String = ConfigurationManager.AppSettings("fromAD")
            Dim BossLevelId As String = psn.Boss_level_id
            Dim Id_Number As String = psn.Id_number
            Dim isGeneral As Byte = 0 '是否為一般人員
            Dim departName As String = New FSC.Logic.Org().GetDepartName(orgcode, departId)


            '判斷此管理者是否為最高管理群組，若是則所有功能都可以使用，不必再查詢模組權限
            If GetMemberIsAdimistrator(roleId, orgcode, departId) Then '此管理者為最高管理群組
                isAdmin = 1   '設定為最高管理者 
            End If

            If getIsGeneral(roleId, BossLevelId) Then
                isGeneral = 1
            End If

            '組成放入驗證票的使用者資訊
            Dim userData As String = ""
            userData &= account & ";"         '帳號(身份証字號)
            userData &= name & ";"            '姓名
            userData &= idCard & ";"          '身份証字號
            userData &= titleNo & ";"         '職稱代碼
            userData &= orgcode & ";"         '機關代碼
            userData &= departId & ";"        '單位代號
            userData &= departName & ";"      '單位名稱
            userData &= email & ";"           'email
            userData &= roleId & ";"          '角色代號
            userData &= isAdmin & ";"         '是否為最高管理者 
            userData &= personnelId & ";"
            userData &= serviceType & ";"
            userData &= ADId & ";"
            userData &= fromAD & ";"          '是否為最高管理者
            userData &= BossLevelId & ";"
            userData &= Id_Number & ";"
            userData &= isGeneral & ";"
            userData &= employeeType & ";"

            Return userData
        End Function


        ''' <summary>
        ''' 驗證帳號
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function CheckAccPass(ByVal id_card As String) As String
            Dim MessageInfo As String = ""
            Dim SqlDA As SqlDataAdapter = New SqlDataAdapter()
            Dim sql As String = ""
            sql = "  select e.id_card, e.delete_flag, d.Orgcode, d.Depart_id from EMP_Member e "
            sql &= " inner join EMP_Depart_emp d on e.id_card=d.id_card "
            sql &= " where e.quit_job_flag<>'Y' and e.id_card=@id_card"
            sql &= " union "
            sql &= " select e.id_card, e.delete_flag, d.Orgcode, d.Depart_id from EMP_NonMember e "
            sql &= " inner join EMP_Depart_emp d on e.id_card=d.id_card "
            sql &= " where e.quit_job_flag<>'Y' and e.id_card=@id_card"

            Dim aryParms(0) As SqlParameter
            aryParms(0) = New SqlParameter("@Id_card", SqlDbType.VarChar)
            aryParms(0).Value = id_card

            Dim dt As DataTable = DAO.Query(sql, aryParms)

            Try
                '1:              登入()
                '2:              登出()
                '3:              登入失敗(-其它)
                '4:              登入失敗(-密碼錯誤)
                '5:              登入失敗(-帳號停用)

                If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then

                    If dt.Rows(0).Item("id_card").ToString() = "" Then
                        MessageInfo = "登入帳號有誤，請重新輸入!"

                    ElseIf dt.Rows(0).Item("delete_flag").ToString.ToLower = "y" Then
                        RecordLogin(dt.Rows(0)("Orgcode").ToString(), dt.Rows(0)("Depart_id").ToString(), id_card, "5")
                        MessageInfo = "此人員之帳號，已停用!"
                    End If
                End If

            Catch ex As Exception
            End Try

            Return MessageInfo
        End Function

        ''' 取得登入者是否為系統管理者
        Public Shared Function GetMemberIsAdimistrator(ByVal Role_id As String, ByVal Orgcode As String, ByVal Depart_id As String) As Boolean
            Dim StrSQL As String = ""
            StrSQL &= " SELECT count(*) FROM SYS_Role"
            StrSQL &= " where Manager_flag = 'Y' and Orgcode=@Orgcode "
            StrSQL &= " and Role_id in ("


            Dim roles() As String = Role_id.Split(",")

            Dim aryParms(roles.Length) As SqlParameter
            aryParms(0) = New SqlParameter("@Orgcode", SqlDbType.VarChar)
            aryParms(0).Value = Orgcode

            For i As Integer = 0 To roles.Length - 1
                StrSQL &= "@Role_id" + i.ToString() + ","
                aryParms(i + 1) = New SqlParameter("@Role_id" + i.ToString(), SqlDbType.VarChar)
                aryParms(i + 1).Value = roles(i)
            Next

            StrSQL = StrSQL.TrimEnd(",")
            StrSQL &= ")"

            Dim obj As Object = DAO.Scalar(StrSQL, aryParms)
            Return CommonFun.getInt(obj) > 0
        End Function

        Public Shared Function getIsGeneral(ByVal Role_id As String, ByVal BossLevelId As String) As Boolean
            If Role_id.IndexOf("Personnel") < 0 AndAlso Role_id.IndexOf("Secretariat") < 0 AndAlso _
            Role_id.IndexOf("OrgHead") < 0 AndAlso Role_id.IndexOf("DeptHead") < 0 AndAlso _
            Role_id.IndexOf("Master") < 0 AndAlso BossLevelId = "0" Then
                Return True
            End If

            Return False
        End Function

        ''' 取得登入者可使用的程式代碼
        Public Shared Function GetMemberModules(ByVal Orgcode As String, ByVal Role_id As String) As String
            Dim StrSQL As New StringBuilder()
            StrSQL.Append(" SELECT distinct C.Func_id, C.Func_url ")
            StrSQL.Append(" FROM      SYS_Role A INNER JOIN ")
            StrSQL.Append("           SYS_Role_function B ON A.Role_id = B.Role_id AND A.Orgcode = B.Orgcode INNER JOIN ")
            StrSQL.Append("           SYS_Func C ON B.Func_id = C.Func_id ")
            StrSQL.Append(" where A.Orgcode=@Orgcode and A.Role_status='1' and lower(A.Delete_flag)='n'  ")


            Dim roles() As String = Role_id.Split(",")
            Dim aryParms(roles.Length) As SqlParameter
            aryParms(0) = New SqlParameter("@Orgcode", SqlDbType.VarChar)
            aryParms(0).Value = Orgcode

            If Not String.IsNullOrEmpty(Role_id) Then
                StrSQL.Append(" and A.Role_id in ( ")

                For i As Integer = 0 To roles.Length - 1

                    If i <> 0 Then
                        StrSQL.Append(",")
                    End If
                    StrSQL.Append("@Role_id").Append(i.ToString())

                    aryParms(i + 1) = New SqlParameter("@Role_id" + i.ToString(), SqlDbType.VarChar)
                    aryParms(i + 1).Value = roles(i)
                Next
                StrSQL.Append(")")
            End If

            Dim dt As DataTable = DAO.Query(StrSQL.ToString(), aryParms)

            Dim strModules As New StringBuilder()
            For Each row As DataRow In dt.Rows
                If String.IsNullOrEmpty(row("Func_url").ToString()) Then
                    Continue For
                End If
                If Not String.IsNullOrEmpty(strModules.ToString()) Then
                    strModules.Append(",")
                End If

                Dim aryPageName As String() = Split(row("Func_url").ToString(), "/")
                Dim aryProgramName As String() = Split(aryPageName(aryPageName.Length - 1).Replace(".aspx", ""), "_")
                Dim strProgramName As String = aryProgramName(0)

                strModules.Append(strProgramName)
            Next

            Return strModules.ToString()
        End Function

        '記錄人員登入/登出時間
        Public Shared Function RecordLogin(ByVal Orgcode As String, ByVal Depart_id As String, ByVal idCard As String, ByVal loginStatus As String) As String
            Dim StrSQL As String = ""
            StrSQL &= " INSERT INTO SYS_LoginAudit"
            StrSQL &= "            (Id_card, Orgcode, Depart_id, LoginTime, LoginStatus)"
            StrSQL &= " VALUES     (@Id_card, @Orgcode, @Depart_id, @LoginTime, @LoginStatus)"

            Dim aryParms(4) As SqlParameter
            aryParms(0) = New SqlParameter("@Id_card", SqlDbType.VarChar)
            aryParms(0).Value = idCard
            aryParms(1) = New SqlParameter("@Orgcode", SqlDbType.VarChar)
            aryParms(1).Value = Orgcode
            aryParms(2) = New SqlParameter("@Depart_id", SqlDbType.VarChar)
            aryParms(2).Value = Depart_id
            aryParms(3) = New SqlParameter("@LoginTime", SqlDbType.VarChar)
            aryParms(3).Value = Right("000" & Now.Year - 1911, 3) & Now.ToString("MMddHHmmss")
            aryParms(4) = New SqlParameter("@LoginStatus", SqlDbType.VarChar)
            aryParms(4).Value = loginStatus

            Return DAO.Execute(StrSQL, aryParms)
        End Function



    End Class
End Namespace