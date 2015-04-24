Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Pemis2009.SQLAdapter
Imports System.Collections.Generic
Imports System.Text

Namespace EMP.Logic
    Public Class MemberDAO
        Inherits BaseDAO

        Public Sub New()
            MyBase.New()
        End Sub

        Public Function insert(ByVal mem As Member) As Integer
            Dim d As New Dictionary(Of String, Object)
            d.Add("Id_card", mem.Id_card)
            d.Add("AD_id", mem.AD_id)
            d.Add("User_name", mem.User_name)
            d.Add("Email", mem.Email)
            d.Add("Employee_type", mem.Employee_type)
            d.Add("Boss_level_id", mem.Boss_level_id)
            d.Add("Act_date", mem.Act_date)
            d.Add("First_gov_date", mem.First_gov_date)
            d.Add("Left_date", mem.Left_date)
            d.Add("Live_phone", mem.Live_phone)
            d.Add("Phone", mem.Phone)
            d.Add("Ext", mem.Ext)
            d.Add("Delete_flag", mem.Delete_flag)
            d.Add("Quit_job_flag", mem.Quit_job_flag)
            d.Add("Change_userid", mem.Change_userid)
            d.Add("Change_date", mem.Change_date)
            Return insertByExample("EMP_Member", d)
        End Function


        Public Function update(ByVal mem As Member) As Integer
            Dim d As New Dictionary(Of String, Object)
            d.Add("AD_id", mem.AD_id)
            d.Add("User_name", mem.User_name)
            d.Add("Email", mem.Email)
            d.Add("Employee_type", mem.Employee_type)
            d.Add("Boss_level_id", mem.Boss_level_id)
            d.Add("Act_date", mem.Act_date)
            d.Add("First_gov_date", mem.First_gov_date)
            d.Add("Left_date", mem.Left_date)
            d.Add("Live_phone", mem.Live_phone)
            d.Add("Phone", mem.Phone)
            d.Add("Ext", mem.Ext)
            d.Add("Delete_flag", mem.Delete_flag)
            d.Add("Quit_job_flag", mem.Quit_job_flag)
            d.Add("Change_userid", mem.Change_userid)
            d.Add("Change_date", mem.Change_date)

            Dim cd As New Dictionary(Of String, Object)
            cd.Add("Id_card", mem.Id_card)

            Return updateByExample("EMP_Member", d, cd)
        End Function

        Public Function GetDataByIdCard(ByVal idCard As String) As DataTable
            Dim d As New Dictionary(Of String, Object)
            d.Add("Id_card", idCard)
            Return GetDataByExample("EMP_Member", d)
        End Function
        
        Public Function GetDataByOrgDep(ByVal orgcode As String, ByVal departId As String, ByVal level As Integer) As DataTable
            Dim sql As New StringBuilder()
            sql.AppendLine(" select d.Orgcode, d.Depart_id, m.* from EMP_Member m ")
            sql.AppendLine("    inner join EMP_Depart_Emp d on m.Id_card=d.Id_card ")
            sql.AppendLine(" where d.Orgcode=@Orgcode ")

            If Not "".Equals(departId) Then
                sql.AppendLine("    and d.Depart_id like @Depart_id ")
                If 0 = level Then
                    departId = departId.Substring(0, 2) & "%"
                ElseIf 1 = level Then
                    departId = departId.Substring(0, 4) & "%"
                End If
            End If

            Dim params() As SqlParameter = { _
            New SqlParameter("@Orgcode", orgcode), _
            New SqlParameter("@Depart_id", departId)}

            Return Query(sql.ToString(), params)
        End Function

        Public Sub UpdateExt(ByVal id_card As String, ByVal ext As String)

            Dim params() As SqlParameter = { _
            New SqlParameter("@ext", ext), _
            New SqlParameter("@id_card", id_card)}

            Dim sql As New StringBuilder()
            sql.AppendLine(" update emp_member set ext=@ext where id_card=@id_card ")

            Execute(sql.ToString(), params)

            Dim sql2 As New StringBuilder()
            sql2.AppendLine(" update emp_nonmember set ext=@ext where id_card=@id_card ")

            Execute(sql2.ToString(), params)
        End Sub
    End Class

End Namespace