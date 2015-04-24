Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text

Namespace FSC.Logic
    Public Class FSC2101DAO
        Inherits BaseDAO

        Dim sbSQL As New StringBuilder
        Dim dtTable As DataTable

        ''' <summary>
        ''' 回傳 職務類別/狀況
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetCODE(ByVal CODE_SYS As String, ByVal CODE_TYPE As String) As DataTable
            sbSQL.Length = 0
            sbSQL.AppendLine(" SELECT CODE_NO,CODE_DESC1  FROM SYS_CODE WHERE CODE_SYS=@CODE_SYS AND CODE_TYPE=@CODE_TYPE ")

            Dim param() As SqlParameter = { _
            New SqlParameter("@CODE_SYS", CODE_SYS), _
            New SqlParameter("@CODE_TYPE", CODE_TYPE)}
            Return Query(sbSQL.ToString(), param)
        End Function

        Public Function GetData(ByVal orgcode As String, ByVal departId As String, ByVal id_card As String, ByVal employeeType As String, ByVal idCard As String, ByVal Quit_job_flag As String) As DataTable
            sbSQL.Length = 0

            sbSQL.AppendLine(" SELECT row_number() over(order by p.Id_card) as RowNO ")

            sbSQL.AppendLine(" ,O1.Depart_name AS Depart_name, O1.Depart_ID as Depart_ID ")
            sbSQL.AppendLine(" ,P.Id_number,P.Id_card ,P.User_name ")
            sbSQL.AppendLine(" ,CASE WHEN P.Boss_level_id='0' THEN '非主管' WHEN P.Boss_level_id='1' THEN '一層主管' WHEN P.Boss_level_id='2' THEN '二層主管' WHEN P.Boss_level_id='3' THEN '三層主管' WHEN P.Boss_level_id='4' THEN '四層主管' END AS BossLevelID ")
            sbSQL.AppendLine(" ,P.Yoyo_card AS YoyoCard ")
            sbSQL.AppendLine(" ,''  AS ADID ")
            sbSQL.AppendLine(" ,'' AS User_password ")
            sbSQL.AppendLine(" ,P.Email ")
            sbSQL.AppendLine(" ,C1.CODE_DESC1 AS TitleNo ")
            sbSQL.AppendLine(" ,'' AS LivePhone ")
            sbSQL.AppendLine(" ,'' as Phone ")
            sbSQL.AppendLine(" ,'' as Ext ")
            sbSQL.AppendLine(" ,LK.Kind_name AS KindName ")
            sbSQL.AppendLine(" ,C2.CODE_DESC1 AS PEWKTYPE ")
            sbSQL.AppendLine(" ,CASE WHEN P.PESEX='1' THEN '男' ELSE '女' END AS PESEX ")
            sbSQL.AppendLine(" ,P.Birth_date AS PEBIRTHD ")
            sbSQL.AppendLine(" ,C3.CODE_DESC1 AS PECRKCOD ")
            sbSQL.AppendLine(" ,C4.CODE_DESC1 AS PEMEMCOD,P.Employee_type ")
            sbSQL.AppendLine(" ,P.PEPOINT ")
            sbSQL.AppendLine(" ,P.PEPROFESS ")
            sbSQL.AppendLine(" ,P.PECHIEF ")
            sbSQL.AppendLine(" ,CASE WHEN P.PEYKIND='1' THEN '歷年制' ELSE '學年制' END PEYKIND ")
            sbSQL.AppendLine(" ,P.Act_date AS PEACTDATE ")
            sbSQL.AppendLine(" ,P.Fisrt_gov_date AS JoinDate ")
            sbSQL.AppendLine(" ,P.Left_date AS PELEVDATE ")
            sbSQL.AppendLine(" ,CASE WHEN P.Login_type ='1' THEN '帳號/密碼' ELSE 'AD登入' END AS LoginType ")
            sbSQL.AppendLine(" ,P.Leave_yr_bdate AS YearStartDate ")
            sbSQL.AppendLine(" ,P.PEHDAY AS PEHDAY2 ")
            sbSQL.AppendLine(" ,P.PEHYEAR AS PEHYEAR ")
            sbSQL.AppendLine(" ,P.PEHDAY AS PEHDAY ")
            sbSQL.AppendLine(" ,PS.Leave_yr_add AS ChgYear ")
            sbSQL.AppendLine(" ,P.PERDAY1 ")
            sbSQL.AppendLine(" ,P.PERDAY2 ")
            sbSQL.AppendLine(" ,CASE WHEN P.Syslogin_flag ='1' THEN '是' ELSE '否' END Syslogin ")
            sbSQL.AppendLine(" ,CASE WHEN P.On_Duty='1' THEN '是' ELSE '否' END OnDuty ")
            sbSQL.AppendLine(" ,SM.Intro_desc AS IntroDesc ")
            sbSQL.AppendLine(" ,SM.Skill_desc AS SkillDesc ")
            sbSQL.AppendLine(" ,SM.Specialty_desc AS SpecialtyDesc ")
            sbSQL.AppendLine(" ,SM.Mood_desc AS MoodDesc ")
            sbSQL.AppendLine(" ,SM.PicFile_path ")


            sbSQL.AppendLine(" FROM FSC_Personnel P ")
            sbSQL.AppendLine("  LEFT JOIN FSC_Depart_EMP DE ON P.Id_card=DE.Id_card ")
            sbSQL.AppendLine("  LEFT JOIN FSC_Org O1 ON DE.Depart_id=O1.Depart_id ")
            sbSQL.AppendLine("  LEFT JOIN SYS_CODE C1 ON P.Title_no=C1.CODE_NO AND C1.CODE_SYS='023' AND C1.CODE_TYPE='012' ")
            sbSQL.AppendLine("  LEFT JOIN SYS_LEAVE_KIND LK ON LK.Leave_kind =P.PEYKIND ")
            sbSQL.AppendLine("  LEFT JOIN SYS_CODE C2 ON P.Shift_type=C2.CODE_NO AND C2.CODE_SYS='023' AND C2.CODE_TYPE='020' ")
            sbSQL.AppendLine("  LEFT JOIN SYS_CODE C3 ON P.Level=RIGHT(C3.CODE_NO,2) AND C3.CODE_SYS='023' AND C3.CODE_TYPE='031' ")
            sbSQL.AppendLine("  LEFT JOIN SYS_CODE C4 ON P.Employee_type=C4.CODE_NO AND C4.CODE_SYS='023' AND C4.CODE_TYPE='022' ")
            sbSQL.AppendLine("  LEFT JOIN FSC_PERSONNEL PS ON PS.Id_card =P.Id_card  AND PS.Level =P.Level ")
            sbSQL.AppendLine("  LEFT JOIN EMP_StaffIntro_main SM ON P.Id_card = SM.id_card ")

            sbSQL.AppendLine(" where 1=1 ")
            sbSQL.AppendLine("  AND DE.Orgcode=@orgcode ")

            If departId <> "" Then
                sbSQL.AppendLine(" AND (O1.Depart_id=@departId or O1.Depart_id in (select depart_id from fsc_org where parent_depart_id=@departId)) ")
            End If

            If id_card <> "" Then
                sbSQL.AppendLine(" AND p.id_card=@id_card ")
            End If

            If employeeType <> "" Then
                sbSQL.AppendLine(" AND P.Employee_type=@employeeType ")
            End If

            If idCard <> "" Then
                sbSQL.AppendLine(" AND P.Id_card=@idCard ")
            End If

            If Quit_job_flag <> "" Then
                sbSQL.AppendLine(" AND P.Quit_job_flag =@Quit_job_flag ")
            End If

            sbSQL.AppendLine("  ORDER BY P.Id_card ")

            Dim param() As SqlParameter = { _
            New SqlParameter("@orgcode", orgcode), _
            New SqlParameter("@departId", departId), _
            New SqlParameter("@id_card", id_card), _
            New SqlParameter("employeeType", employeeType), _
            New SqlParameter("idCard", idCard), _
            New SqlParameter("Quit_job_flag", Quit_job_flag)}
            Return Query(sbSQL.ToString(), param)
        End Function


    End Class
End Namespace
