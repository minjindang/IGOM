Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Pemis2009.SQLAdapter
Imports System.Collections.Generic
Imports System.Text

Namespace FSC.Logic
    Public Class PersonnelDAO
        Inherits BaseDAO

        Public Sub New()
            MyBase.New()
        End Sub

        Public Function GetData() As DataTable
            Dim sql As String = "select * from FSC_Personnel order by id_card "
            Return Query(sql)
        End Function


        Public Function GetOnJobData() As DataTable
            Dim sql As String = "select * from FSC_Personnel where quit_job_flag='N' or quit_job_flag is null or quit_job_flag='' order by id_card "
            Return Query(sql)
        End Function

        Public Function GetDataByIdcard(ByVal idcard As String) As DataTable
            Dim sql As String = "SELECT c.code_desc1+'/'+a.user_name as full_name, a.* FROM FSC_Personnel a "
            sql &= " inner join SYS_Code c on c.code_sys='023' and c.code_type='012' and c.code_no=a.title_no "
            sql &= " WHERE a.Id_card=@Id_card"
            Dim param As SqlParameter = New SqlParameter("@Id_card", SqlDbType.VarChar)
            param.Value = idcard
            Return Query(sql, param)
        End Function

        Public Function GetDataByADid(ByVal AD_id As String) As DataTable
            Dim sql As String = "SELECT * FROM FSC_Personnel WHERE AD_id=@AD_id"
            Dim param As SqlParameter = New SqlParameter("@AD_id", SqlDbType.VarChar)
            param.Value = AD_id
            Return Query(sql, param)
        End Function

        Public Function GetDataByEmployeeType(ByVal employeeType As String) As DataTable
            Dim sql As String = "SELECT * FROM FSC_Personnel WHERE employee_type=@employeeType"
            Dim param As SqlParameter = New SqlParameter("@employeeType", SqlDbType.VarChar)
            param.Value = employeeType
            Return Query(sql, param)
        End Function


        Public Function GetDataByRoleId(ByVal orgcode As String, ByVal departId As String, ByVal roleId As String) As DataTable
            Dim sql As New StringBuilder()
            sql.AppendLine(" select d.orgcode, d.depart_id, p.* from fsc_personnel p ")
            sql.AppendLine(" inner join fsc_depart_emp d on p.id_card=d.id_card ")
            sql.AppendLine(" where ")
            sql.AppendLine("    p.role_id like @roleId ")

            If Not String.IsNullOrEmpty(orgcode) Then
                sql.AppendLine(" and d.orgcode=@orgcode ")
            End If

            If Not String.IsNullOrEmpty(departId) Then
                sql.AppendLine(" and (d.depart_id=@departId or depart_id in (select depart_id from fsc_org where parent_depart_id=@departId)) ")
            End If

            Dim params() As SqlParameter = { _
            New SqlParameter("@orgcode", orgcode), _
            New SqlParameter("@departId", departId), _
            New SqlParameter("@roleId", "%" + roleId + "%")}

            Return Query(sql.ToString(), params)
        End Function


        Public Function UpdateAnnel(perday As Double, perday1 As Double, perday2 As Double, pehyear As Double, pehday As Double, idCard As String) As Integer
            Dim d As New Dictionary(Of String, Object)
            Dim v As New Dictionary(Of String, Object)

            d.Add("id_card", idCard)

            If Not String.IsNullOrEmpty(perday) Then
                v.Add("perday", perday)
            End If

            v.Add("perday1", perday1)
            v.Add("perday2", perday2)
            v.Add("pehyear", pehyear)
            v.Add("pehday", pehday)

            Return UpdateByExample("FSC_Personnel", v, d)
        End Function


        Public Function GetDataByOnDuty(ByVal onDuty As String) As DataTable
            Dim sql As New StringBuilder()
            sql.AppendLine(" select * from fsc_personnel where on_duty=@onDuty order by id_number ")

            Dim param As SqlParameter = New SqlParameter("@onDuty", onDuty)
            Return Query(sql.ToString(), param)
        End Function


        Public Function GetDataByBossLevelId(orgcode As String, departId As String, bossLevelId As String) As DataTable
            Dim sql As New StringBuilder()
            sql.AppendLine(" select distinct b.orgcode, b.depart_id, a.* ")
            sql.AppendLine("    from FSC_Personnel a ")
            sql.AppendLine("    inner join FSC_Depart_emp b on a.id_card=b.id_card ")
            sql.AppendLine(" where ")
            sql.AppendLine(" b.orgcode=@orgcode ")

            If Not String.IsNullOrEmpty(departId) Then
                sql.AppendLine(" and (b.depart_id=@departId or b.depart_id in (select depart_id from fsc_org where parent_depart_id=@departId)) ")
            End If

            sql.AppendLine(" and a.boss_Level_Id=@bossLevelId ")

            Dim params() As SqlParameter = { _
                New SqlParameter("@orgcode", orgcode), _
                New SqlParameter("@departId", departId), _
                New SqlParameter("@bossLevelId", bossLevelId)}

            Return Query(sql.ToString(), params)
        End Function


        Public Function GetTitleDataByOrgDep(ByVal orgcode As String, ByVal departId As String) As DataTable
            Dim sql As New StringBuilder()
            sql.AppendLine(" select distinct a.title_no, c.code_desc1 as title_name, c.code_sort ")
            sql.AppendLine("    from FSC_Personnel a ")
            sql.AppendLine("    inner join FSC_Depart_emp b on a.id_card=b.id_card ")
            sql.AppendLine("    inner join SYS_Code c on c.code_sys='023' and c.code_type='012' and c.code_no=a.title_no ")
            sql.AppendLine(" where ")
            sql.AppendLine(" b.orgcode=@orgcode ")
            sql.AppendLine(" and a.quit_job_flag<>'Y' ")

            If Not String.IsNullOrEmpty(departId) Then
                sql.AppendLine(" and (b.depart_id=@departId or b.Depart_id in (select depart_id from FSC_Org where parent_depart_id=@departId)) ")
            End If

            sql.AppendLine(" order by c.code_sort ")

            Dim params() As SqlParameter = { _
                New SqlParameter("@orgcode", orgcode), _
                New SqlParameter("@departId", departId)}

            Return Query(sql.ToString(), params)
        End Function

        Public Function GetTitleDataByOrgDep(ByVal orgcode As String, ByVal departId As String, ByVal Depart_Level As String, ByVal Title_level As String) As DataTable
            Dim sql As New StringBuilder()
            sql.AppendLine(" select distinct a.title_no, c.code_desc1 as title_name, c.code_sort ")
            sql.AppendLine("    from FSC_Personnel a ")
            sql.AppendLine("    inner join FSC_Depart_emp b on a.id_card=b.id_card ")
            sql.AppendLine("    inner join SYS_Code c on c.code_sys='023' and c.code_type='012' and c.code_no=a.title_no ")
            sql.AppendLine(" where ")
            sql.AppendLine(" b.orgcode=@orgcode ")
            sql.AppendLine(" and a.quit_job_flag<>'Y' ")

            If Not String.IsNullOrEmpty(departId) Then
                sql.AppendLine(" and (b.depart_id=@departId or b.Depart_id in (select depart_id from FSC_Org where parent_depart_id=@departId)) ")
            End If
            If Not String.IsNullOrEmpty(Depart_Level) Then
                sql.AppendLine(" and b.depart_id in (select depart_id from FSC_Org where Depart_Level=@Depart_Level ) ")
            End If
            If Not String.IsNullOrEmpty(Title_level) Then
                sql.AppendLine(" and c.CODE_DESC2=@Title_level ")
            End If

            sql.AppendLine(" order by c.code_sort ")

            Dim params() As SqlParameter = { _
                New SqlParameter("@orgcode", orgcode), _
                New SqlParameter("@departId", departId), _
                New SqlParameter("@Depart_Level", Depart_Level), _
                New SqlParameter("@Title_level", Title_level)}

            Return Query(sql.ToString(), params)
        End Function

        Public Function GetDataByQuery(ByVal orgcode As String, ByVal departId As String, ByVal titleNo As String, ByVal idCard As String) As DataTable
            Dim sql As New StringBuilder()
            sql.AppendLine(" select distinct a.*, c.code_desc1 as title_name, c.code_sort, b.orgcode, b.Depart_id,  ")
            sql.AppendLine("    c.code_desc1+'/'+a.user_name as full_name, d.depart_name ")
            sql.AppendLine("    from FSC_Personnel a ")
            sql.AppendLine("    inner join FSC_Depart_emp b on a.id_card=b.id_card ")
            sql.AppendLine("    inner join SYS_Code c on c.code_sys='023' and c.code_type='012' and c.code_no=a.title_no ")
            sql.AppendLine("    left join FSC_org d on b.orgcode=d.orgcode and b.depart_id=d.depart_id ")
            sql.AppendLine(" where ")
            sql.AppendLine(" b.orgcode=@orgcode ")

            If LoginManager.RoleId.IndexOf("Personnel") < 0 Then
                sql.AppendLine(" and a.quit_job_flag<>'Y' ")
            End If

            If Not String.IsNullOrEmpty(departId) Then
                sql.AppendLine(" and (b.depart_id=@departId or b.depart_id in (select Depart_id from FSC_ORG where parent_Depart_id=@departId)) ")
            End If

            If Not String.IsNullOrEmpty(titleNo) Then
                sql.AppendLine(" and a.title_No=@titleNo ")
            End If

            If Not String.IsNullOrEmpty(idCard) Then
                sql.AppendLine(" and a.id_card=@idCard")
            End If

            sql.AppendLine(" order by c.code_sort ")

            Dim params() As SqlParameter = { _
                New SqlParameter("@orgcode", orgcode), _
                New SqlParameter("@departId", departId), _
                New SqlParameter("@titleNo", titleNo), _
                New SqlParameter("@idCard", idCard)}

            Return Query(sql.ToString(), params)
        End Function

        Public Function GetDataByOrgDep(ByVal orgcode As String, ByVal departId As String, ByVal Depart_Level As String) As DataTable
            Dim sql As New StringBuilder()
            sql.AppendLine(" select distinct a.*, c.code_desc1 as title_name, c.code_sort, b.orgcode, b.Depart_id,  ")
            sql.AppendLine("    c.code_desc1+'/'+a.user_name as full_name, d.depart_name ")
            sql.AppendLine("    from FSC_Personnel a ")
            sql.AppendLine("    inner join FSC_Depart_emp b on a.id_card=b.id_card ")
            sql.AppendLine("    inner join SYS_Code c on c.code_sys='023' and c.code_type='012' and c.code_no=a.title_no ")
            sql.AppendLine("    left join FSC_org d on b.orgcode=d.orgcode and b.depart_id=d.depart_id ")
            sql.AppendLine(" where ")
            sql.AppendLine(" b.orgcode=@orgcode ")
            sql.AppendLine(" and a.quit_job_flag<>'Y' ")

            If Not String.IsNullOrEmpty(departId) Then
                sql.AppendLine(" and (b.depart_id=@departId or b.depart_id in (select Depart_id from FSC_ORG where parent_Depart_id=@departId)) ")
            End If
            If Not String.IsNullOrEmpty(Depart_Level) Then
                sql.AppendLine(" and b.depart_id in (select Depart_id from FSC_Org where Depart_Level=@Depart_Level ) ")
            End If

            sql.AppendLine(" order by c.code_sort ")

            Dim params() As SqlParameter = { _
                New SqlParameter("@orgcode", orgcode), _
                New SqlParameter("@departId", departId), _
                New SqlParameter("@Depart_Level", Depart_Level)}

            Return Query(sql.ToString(), params)
        End Function

        Public Function GetDataByOnDuty(ByVal orgcode As String, ByVal departId As String, ByVal onDuty As String) As DataTable
            Dim sql As New StringBuilder()
            sql.AppendLine(" select distinct a.*, c.code_desc1 as title_name, c.code_sort, ")
            sql.AppendLine("    c.code_desc1+'/'+a.user_name as full_name ")
            sql.AppendLine("    from FSC_Personnel a ")
            sql.AppendLine("    inner join FSC_Depart_emp b on a.id_card=b.id_card ")
            sql.AppendLine("    inner join SYS_Code c on c.code_sys='023' and c.code_type='012' and c.code_no=a.title_no ")
            sql.AppendLine(" where ")
            sql.AppendLine(" b.orgcode=@orgcode ")
            sql.AppendLine(" and (a.quit_job_flag<>'Y' or a.left_date <> '') ")

            If Not String.IsNullOrEmpty(departId) Then
                If departId.Length = 2 Then
                    departId = departId & "%"
                    sql.AppendLine(" and substring(b.depart_id,1,2) like @departId ")
                Else
                    sql.AppendLine(" and b.depart_id=@departId ")
                End If
            End If

            If Not String.IsNullOrEmpty(onDuty) Then
                sql.AppendLine(" and a.on_duty=@onDuty ")
            End If

            sql.AppendLine(" order by c.code_sort ")

            Dim params() As SqlParameter = { _
                New SqlParameter("@orgcode", orgcode), _
                New SqlParameter("@departId", departId), _
                New SqlParameter("@onDuty", onDuty)}

            Return Query(sql.ToString(), params)
        End Function

        Public Function UpdateInitFlag(ByVal Id_card As String) As Integer
            Dim sql As String = " update FSC_Personnel set Init_flag = '1' where id_card=@id_card "

            Dim params(0) As SqlParameter
            params(0) = New SqlParameter("@Id_card", SqlDbType.VarChar)
            params(0).Value = Id_card

            Return Execute(sql, params)
        End Function

        Public Function UpdateRole(ByVal Id_card As String, ByVal Role_id As String) As Integer
            Dim sql As String = " update FSC_Personnel set Role_id = @Role_id where id_card=@id_card "

            Dim params(1) As SqlParameter
            params(0) = New SqlParameter("@Id_card", SqlDbType.VarChar)
            params(0).Value = Id_card
            params(1) = New SqlParameter("@Role_id", SqlDbType.VarChar)
            params(1).Value = Role_id

            Return Execute(sql, params)
        End Function

        Public Function getDeputyActive(ByVal Id_card As String) As DataTable
            Dim sql As StringBuilder = New StringBuilder
            sql.AppendLine(" select * from FSC_Personnel p ")
            sql.AppendLine(" inner join FSC_Depart_emp de on de.id_card = p.id_card ")
            sql.AppendLine(" where p.Deputy_active_idcard =@Id_card ")
            sql.AppendLine(" AND p.Deputy_active_sdate<=@nowdate ")
            sql.AppendLine(" AND p.Deputy_active_edate>=@nowdate ")
            sql.AppendLine(" AND p.Deputy_active_stime<=@nowtime ")

            Dim nowdate As String = DateTimeInfo.GetRocDateTime(Now)
            Dim d As String = nowdate.Substring(0, 7)
            Dim t As String = nowdate.Substring(7, 4)

            Dim params(2) As SqlParameter
            params(0) = New SqlParameter("@Id_card", SqlDbType.VarChar)
            params(0).Value = Id_card
            params(1) = New SqlParameter("@nowdate", SqlDbType.VarChar)
            params(1).Value = d
            params(2) = New SqlParameter("@nowtime", SqlDbType.VarChar)
            params(2).Value = t

            Return Query(sql.ToString(), params)
        End Function

        Public Function UpdateYoyoCard_Change_flag(ByVal Id_card As String, ByVal YoyoCard_Change_flag As String) As Integer
            Dim sql As String = " update FSC_Personnel set YoyoCard_Change_flag = @YoyoCard_Change_flag where id_card=@id_card "

            Dim params(1) As SqlParameter
            params(0) = New SqlParameter("@Id_card", SqlDbType.VarChar)
            params(0).Value = Id_card
            params(1) = New SqlParameter("@YoyoCard_Change_flag", SqlDbType.VarChar)
            params(1).Value = YoyoCard_Change_flag

            Return Execute(sql, params)
        End Function

        Public Function UpdateDepart_Change_flag(ByVal Id_card As String, ByVal Depart_Change_flag As String) As Integer
            Dim sql As String = " update FSC_Personnel set Depart_Change_flag = @Depart_Change_flag where id_card=@id_card "

            Dim params(1) As SqlParameter
            params(0) = New SqlParameter("@Id_card", SqlDbType.VarChar)
            params(0).Value = Id_card
            params(1) = New SqlParameter("@Depart_Change_flag", SqlDbType.VarChar)
            params(1).Value = Depart_Change_flag

            Return Execute(sql, params)
        End Function
    End Class

End Namespace