Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text

Namespace FSC.Logic
    Public Class FSC2116DAO
        Inherits BaseDAO

        Public Function getQueryData(ByVal orgcode As String, _
                                     ByVal Depart_id As String, _
                                     ByVal Id_card As String, _
                                     ByVal Start_date As String, _
                                     ByVal End_date As String) As DataTable


            Dim sql As New StringBuilder()
            sql.AppendLine(" SELECT ")
            sql.AppendLine(" c.Id_number,")
            sql.AppendLine(" a.Orgcode,")
            If Not String.IsNullOrEmpty(Depart_id) Then
                sql.AppendLine(" e.Depart_name, e.ChangeCode, ")
            Else
                sql.AppendLine(" (select top 1 depart_name from FSC_ORG , FSC_Depart_EMP where FSC_ORG.Orgcode=FSC_Depart_EMP.Orgcode and FSC_ORG.Depart_id=FSC_Depart_EMP.Depart_id and FSC_Depart_EMP.Id_card=a.Id_card) Depart_name, ")
                sql.AppendLine(" (select top 1 ChangeCode from FSC_ORG , FSC_Depart_EMP where FSC_ORG.Orgcode=FSC_Depart_EMP.Orgcode and FSC_ORG.Depart_id=FSC_Depart_EMP.Depart_id and FSC_Depart_EMP.Id_card=a.Id_card) ChangeCode, ")
            End If
            sql.AppendLine(" c.Id_card,")
            sql.AppendLine(" c.User_name,")
            sql.AppendLine(" a.Start_date,")
            sql.AppendLine(" a.End_date,")
            sql.AppendLine(" a.Leave_hours,")
            sql.AppendLine(" a.Change_userid,")
            sql.AppendLine(" g.leave_type,")
            sql.AppendLine(" a.Inter_travel_flag")

            sql.AppendLine(" FROM FSC_Leave_main AS a")
            sql.AppendLine(" INNER JOIN FSC_Personnel AS c ON a.Id_card = c.Id_card")
            sql.AppendLine(" INNER JOIN SYS_Leave_type AS g ON g.Leave_type = a.Leave_type")
            If Not String.IsNullOrEmpty(Depart_id) Then
                sql.AppendLine(" INNER JOIN FSC_ORG AS e ON e.Orgcode=a.Orgcode and e.Depart_id= a.Depart_id")
            End If
            sql.AppendLine(" LEFT JOIN SYS_Flow AS b ON a.Flow_id = b.Flow_id")
            sql.AppendLine(" WHERE a.Inter_travel_flag='1' AND g.Leave_type='03'")
            sql.AppendLine(" AND b.Case_status='1' and b.Last_pass='1'")


            If Not String.IsNullOrEmpty(Depart_id) Then
                sql.AppendLine("  and (b.Depart_id = @Depart_id or b.Depart_id in (select depart_id from fsc_org where parent_depart_id=@Depart_id))")
            End If

            If Not String.IsNullOrEmpty(Start_date) Then
                sql.AppendLine(" and a.Start_date >= @Start_date ")
            End If
            If Not String.IsNullOrEmpty(End_date) Then
                sql.AppendLine(" and a.End_date <= @End_date ")
            End If

            sql.AppendLine(" ORDER BY (case when c.Boss_level_id = 0 then 99 else c.Boss_level_id end ), c.Id_card")

            Dim aryParms(2) As SqlParameter
            aryParms(0) = New SqlParameter("@Depart_id", SqlDbType.VarChar)
            aryParms(0).Value = Depart_id
            aryParms(1) = New SqlParameter("@Start_date", SqlDbType.VarChar)
            aryParms(1).Value = Start_date
            aryParms(2) = New SqlParameter("@End_date", SqlDbType.VarChar)
            aryParms(2).Value = End_date

            Return Query(sql.ToString(), aryParms)
        End Function
    End Class
End Namespace
