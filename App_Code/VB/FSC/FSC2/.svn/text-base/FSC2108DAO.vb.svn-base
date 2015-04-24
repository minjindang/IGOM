Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text

Namespace FSC.Logic
    Public Class FSC2108DAO
        Inherits BaseDAO

        Public Function getQueryData(ByVal orgcode As String, _
                                     ByVal Depart_id As String, _
                                     ByVal User_name As String, _
                                     ByVal Id_card As String, _
                                     ByVal Quit_job_flag As String, _
                                     ByVal PESEX As String, _
                                     ByVal Start_date As String, _
                                     ByVal End_date As String, _
                                     ByVal order As String) As DataTable
            Dim sql As New StringBuilder()
            sql.AppendLine(" SELECT")
            sql.AppendLine(" a.Id_card,")
            sql.AppendLine(" a.User_name,")
            sql.AppendLine(" a.Depart_id,")
            'sql.AppendLine(" e.Depart_name,")
            sql.AppendLine(" (select CODE_DESC1 from SYS_CODE AS c where c.CODE_SYS='023' and c.CODE_TYPE='012' and c.CODE_NO = b.Title_no) as title_name,")
            sql.AppendLine(" a.Sche_date,")
            sql.AppendLine(" c.Name AS Sche_type")
            sql.AppendLine(" FROM FSC_Schedule_setting AS a")
            sql.AppendLine(" INNER JOIN FSC_Personnel AS b ON b.Id_card = a.Id_card")
            sql.AppendLine(" LEFT JOIN FSC_Schedule AS c ON c.schedule_id=a.schedule_id ")
            'sql.AppendLine(" LEFT JOIN FSC_ORG AS e ON e.Orgcode = a.Orgcode AND e.Depart_id= a.Depart_id")

            sql.AppendLine(" WHERE 1=1")


            If Not String.IsNullOrEmpty(Depart_id) Then
                sql.AppendLine(" and (a.Depart_id = @Depart_id or a.Depart_id in (select depart_id from fsc_org where parent_depart_id=@Depart_id)) ")
            End If
            If Not String.IsNullOrEmpty(User_name) Then
                sql.AppendLine(" and b.Id_number in (select id_number from FSC_Personnel where @id_card=@User_name) ")
            End If
            If Not String.IsNullOrEmpty(Id_card) Then
                sql.AppendLine(" and b.Id_number in (select id_number from FSC_Personnel where @id_card=@Id_card) ")
            End If
            If Not String.IsNullOrEmpty(Start_date) Then
                sql.AppendLine(" and a.Sche_date >= @Start_date ")
            End If
            If Not String.IsNullOrEmpty(End_date) Then
                sql.AppendLine(" and a.Sche_date <= @End_date ")
            End If
            If Not String.IsNullOrEmpty(Quit_job_flag) Then
                sql.AppendLine(" and b.Quit_job_flag = @Quit_job_flag ")
            End If
            If Not String.IsNullOrEmpty(PESEX) Then
                sql.AppendLine(" and b.PESEX = @PESEX ")
            End If
            'If Not String.IsNullOrEmpty(order) Then
            '    If order = 0 Then
            '    Else
            '        sql.AppendLine(" ORDER BY a.Depart_id")
            '    End If
            'End If
            'End If
            'sql.AppendLine(" ORDER BY a.Sche_date,a.Depart_id")
            sql.AppendLine(" ORDER BY (case when b.Boss_level_id=0 then 99 else b.Boss_level_id end), b.id_card, b.User_name")

            Dim aryParms(7) As SqlParameter
            aryParms(0) = New SqlParameter("@Depart_id", SqlDbType.VarChar)
            aryParms(0).Value = Depart_id
            aryParms(1) = New SqlParameter("@User_name", SqlDbType.VarChar)
            aryParms(1).Value = User_name
            aryParms(2) = New SqlParameter("@Id_card", SqlDbType.VarChar)
            aryParms(2).Value = Id_card
            aryParms(3) = New SqlParameter("@Quit_job_flag", SqlDbType.VarChar)
            aryParms(3).Value = Quit_job_flag
            aryParms(4) = New SqlParameter("@PESEX", SqlDbType.VarChar)
            aryParms(4).Value = PESEX
            aryParms(5) = New SqlParameter("@Start_date", SqlDbType.VarChar)
            aryParms(5).Value = Start_date
            aryParms(6) = New SqlParameter("@End_date", SqlDbType.VarChar)
            aryParms(6).Value = End_date
            aryParms(7) = New SqlParameter("@order", SqlDbType.VarChar)
            aryParms(7).Value = order

            Return Query(sql.ToString(), aryParms)
        End Function


    End Class
End Namespace
