Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text

Namespace FSC.Logic
    Public Class FSC2124DAO
        Inherits BaseDAO

        Public Function GetData(ByVal Orgcode As String, ByVal Depart_id As String, ByVal Sdate As String, ByVal Edate As String, _
                                ByVal id_card As String, ByVal id_card2 As String, ByVal Quit_job_flag As String, _
                                ByVal Employee_type As String) As DataTable
            Dim sql As New StringBuilder
            sql.AppendLine(" select uc.*, sc.CODE_DESC1 as CHPKWKTPE, ")
            sql.AppendLine(" (select top 1 User_name from FSC_Personnel where id_card=uc.id_card ) as User_name,")
            sql.AppendLine(" (select top 1 User_name from FSC_Personnel where id_card=uc.change_userid ) as Change_username,")
            sql.AppendLine(" (select top 1 Depart_name from FSC_Org o where o.orgcode=d.orgcode and o.depart_id=d.depart_id ) as Depart_name")
            sql.AppendLine(" from FSC_Unusual_correct uc ")
            sql.AppendLine(" inner join fsc_personnel p on uc.id_card=p.id_card ")
            sql.AppendLine(" inner join fsc_depart_emp d on p.id_card=d.id_card ")
            sql.AppendLine(" inner join sys_code sc on sc.CODE_NO=uc.PKWKTPE and sc.CODE_SYS='023' and sc.CODE_TYPE='009' ")
            sql.AppendLine(" where 1=1 ")

            If Not String.IsNullOrEmpty(Orgcode) Then
                sql.AppendLine(" and d.Orgcode=@Orgcode ")
            End If
            If Not String.IsNullOrEmpty(Depart_id) Then
                sql.AppendLine(" and (d.Depart_id = @Depart_id or d.Depart_id in (select depart_id from fsc_org where parent_depart_id=@Depart_id))")
            End If
            If Not String.IsNullOrEmpty(Sdate) Then
                sql.AppendLine(" and uc.PKWDATE>=@Sdate ")
            End If
            If Not String.IsNullOrEmpty(Edate) Then
                sql.AppendLine(" and uc.PKWDATE<=@Edate ")
            End If
            If Not String.IsNullOrEmpty(id_card) Then
                sql.AppendLine(" and uc.id_card=@id_card ")
            End If
            If Not String.IsNullOrEmpty(id_card2) Then
                sql.AppendLine(" and uc.id_card=@id_card2 ")
            End If
            If Not String.IsNullOrEmpty(Quit_job_flag) Then
                sql.AppendLine(" and p.Quit_job_flag=@Quit_job_flag ")
            End If
            If Not String.IsNullOrEmpty(Employee_type) Then
                sql.AppendLine(" and p.Employee_type=@Employee_type ")
            End If

            Dim params(7) As SqlParameter
            params(0) = New SqlParameter("@Orgcode", SqlDbType.VarChar)
            params(0).Value = Orgcode
            params(1) = New SqlParameter("@Depart_id", SqlDbType.VarChar)
            params(1).Value = Depart_id
            params(2) = New SqlParameter("@Sdate", SqlDbType.VarChar)
            params(2).Value = Sdate
            params(3) = New SqlParameter("@Edate", SqlDbType.VarChar)
            params(3).Value = Edate
            params(4) = New SqlParameter("@id_card", SqlDbType.VarChar)
            params(4).Value = id_card
            params(5) = New SqlParameter("@id_card2", SqlDbType.VarChar)
            params(5).Value = id_card2
            params(6) = New SqlParameter("@Quit_job_flag", SqlDbType.VarChar)
            params(6).Value = Quit_job_flag
            params(7) = New SqlParameter("@Employee_type", SqlDbType.VarChar)
            params(7).Value = Employee_type

            Return Query(sql.ToString(), params)
        End Function

    End Class
End Namespace
