Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text

Namespace FSC.Logic
    Public Class FSC2109DAO
        Inherits BaseDAO

        Public Function GetData(ByVal Orgcode As String, ByVal Depart_id As String, ByVal Id_card As String, ByVal Id_card2 As String, _
                                ByVal Q_job As String, ByVal Sex As String, ByVal Sdate As String, ByVal Edate As String) As DataTable
            Dim sql As New StringBuilder
            sql.AppendLine(" select ss.*, ")
            sql.AppendLine(" (select top 1 Depart_Name from FSC_Org f where f.orgcode=ss.orgcode and f.depart_id=ss.depart_id) as Depart_Name, ")
            sql.AppendLine(" (select top 1 CODE_DESC1 from SYS_CODE c where code_sys='023' and code_type = '012' and code_no=p.title_no) as Title_Name, ")
            sql.AppendLine(" (select top 1 Name from FSC_Schedule s where s.Schedule_ID= ss.Schedule_ID ) as Sche_Name")
            sql.AppendLine(" from FSC_Schedule_setting ss ")
            sql.AppendLine(" inner join FSC_Personnel p on ss.Id_card = p.Id_card ")
            sql.AppendLine(" where Sche_type=1 ")

            If Not String.IsNullOrEmpty(Orgcode) Then
                sql.AppendLine(" and ss.Orgcode=@Orgcode ")
            End If
            If Not String.IsNullOrEmpty(Depart_id) Then
                If Depart_id.Length = 2 Then
                    sql.AppendLine(" and substring(ss.depart_id,1,2) like @Depart_id ")
                Else
                    sql.AppendLine(" and (ss.Depart_id = @Depart_id or ss.Depart_id in (select depart_id from fsc_org where parent_depart_id=@Depart_id)) ")

                End If
            End If
            If Not String.IsNullOrEmpty(Id_card) Then
                sql.AppendLine(" and ss.Id_card=@Id_card ")
            End If
            If Not String.IsNullOrEmpty(Id_card2) Then
                sql.AppendLine(" and ss.Id_card=@Id_card2 ")
            End If
            If Not String.IsNullOrEmpty(Q_job) Then
                sql.AppendLine(" and p.Quit_job_flag=@Quit_job_flag ")
            End If
            If Not String.IsNullOrEmpty(Sex) Then
                sql.AppendLine(" and p.PESEX=@PESEX ")
            End If
            If Not String.IsNullOrEmpty(Sdate) Then
                sql.AppendLine(" and ss.Sche_date>=@Sdate ")
            End If
            If Not String.IsNullOrEmpty(Edate) Then
                sql.AppendLine(" and ss.Sche_date<=@Edate ")
            End If

            'sql.AppendLine(" order by ss.Sche_date,ss.Depart_id")
            sql.AppendLine(" ORDER BY (case when p.Boss_level_id=0 then 99 else p.Boss_level_id end), p.id_card, p.User_name")
            Dim params(7) As SqlParameter
            params(0) = New SqlParameter("@Orgcode", SqlDbType.VarChar)
            params(0).Value = Orgcode
            params(1) = New SqlParameter("@Depart_id", SqlDbType.VarChar)
            params(1).Value = Depart_id
            params(2) = New SqlParameter("@Id_card", SqlDbType.VarChar)
            params(2).Value = Id_card
            params(3) = New SqlParameter("@Id_card2", SqlDbType.VarChar)
            params(3).Value = Id_card2
            params(4) = New SqlParameter("@Quit_job_flag", SqlDbType.VarChar)
            params(4).Value = Q_job
            params(5) = New SqlParameter("@PESEX", SqlDbType.VarChar)
            params(5).Value = Sex
            params(6) = New SqlParameter("@Sdate", SqlDbType.VarChar)
            params(6).Value = Sdate
            params(7) = New SqlParameter("@Edate", SqlDbType.VarChar)
            params(7).Value = Edate

            Return Query(sql.ToString(), params)
        End Function

    End Class
End Namespace
