Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text

Namespace FSC.Logic
    Public Class FSC2102DAO
        Inherits BaseDAO

        Public Function getQueryData(ByVal orgcode As String, _
                                     ByVal Depart_id As String, _
                                     ByVal Apply_name As String, _
                                     ByVal Apply_idcard As String, _
                                     ByVal Start_date As String, _
                                     ByVal End_date As String, _
                                     ByVal Quit_job_flag As String, _
                                     ByVal PESEX As String, _
                                     ByVal Employee_type As String, _
                                     ByVal yyymm As String, _
                                     ByVal type As String) As DataTable

            Dim tablename As String = "FSC_CPAPK" & yyymm
            'Dim diff As Integer
            Dim sql As New StringBuilder()
            sql.AppendLine(" SELECT ")

            If Not String.IsNullOrEmpty(Depart_id) Then
                sql.AppendLine(" e.Depart_name,")
            Else
                sql.AppendLine(" (select top 1 depart_name from FSC_ORG , FSC_Depart_EMP where FSC_ORG.Orgcode=FSC_Depart_EMP.Orgcode and FSC_ORG.Depart_id=FSC_Depart_EMP.Depart_id and FSC_Depart_EMP.Id_card=a.PKCARD) Depart_name, ")
            End If

            sql.AppendLine(" a.PKCARD,")
            sql.AppendLine(" a.PKNAME,")
            sql.AppendLine(" a.PKWDATE,")
            sql.AppendLine(" a.PKSTIME,")
            sql.AppendLine(" a.PKETIME,")
            sql.AppendLine(" a.PKWORKH,")
            sql.AppendLine(" (select CODE_DESC1 from SYS_CODE as f where CODE_SYS = '023' and CODE_TYPE ='009' AND f.code_no = a.PKWKTPE) AS PKWKTPE")

            sql.AppendLine(" FROM " & tablename & " AS a")

            sql.AppendLine(" INNER JOIN FSC_Personnel AS c ON  c.Id_card = a.PKCARD")

            If Not String.IsNullOrEmpty(Depart_id) Then
                sql.AppendLine(" INNER JOIN FSC_Depart_EMP AS b ON a.PKCARD = b.Id_card")
                sql.AppendLine(" INNER JOIN FSC_ORG AS e ON e.Orgcode = b.Orgcode AND e.Depart_id=b.Depart_id")
            End If

            sql.AppendLine(" WHERE 1=1")

            If Not String.IsNullOrEmpty(Depart_id) Then
                sql.AppendLine(" and (b.Depart_id = @Depart_id or b.Depart_id in (select depart_id from fsc_org where parent_depart_id=@Depart_id)) ")
            End If
            If Not String.IsNullOrEmpty(Apply_name) Then
                sql.AppendLine(" and c.Id_number = (select Id_number from FSC_Personnel where Id_card=@Apply_name) ")
            End If
            If Not String.IsNullOrEmpty(Apply_idcard) Then
                sql.AppendLine(" and c.Id_number = (select Id_number from FSC_Personnel where Id_card=@Apply_name) ")
            End If
            If Not String.IsNullOrEmpty(Start_date) Then
                sql.AppendLine(" and a.PKWDATE >= @Start_date ")
            End If
            If Not String.IsNullOrEmpty(End_date) Then
                sql.AppendLine(" and a.PKWDATE <= @End_date ")
            End If
            If Not String.IsNullOrEmpty(Quit_job_flag) Then
                sql.AppendLine(" and c.Quit_job_flag = @Quit_job_flag ")
            End If
            If Not String.IsNullOrEmpty(PESEX) Then
                sql.AppendLine(" and c.PESEX = @PESEX ")
            End If
            If Not String.IsNullOrEmpty(Employee_type) Then
                sql.AppendLine(" and c.Employee_type = @Employee_type ")
            End If
            If type = "1" Then
                sql.AppendLine(" and a.PKWKTPE not in (5, 6) ")
            End If

            sql.AppendLine(" ORDER BY (case when c.Boss_level_id='0' then 99 else c.Boss_level_id end), c.id_card, a.PKWDATE ")

            Dim aryParms(7) As SqlParameter
            aryParms(0) = New SqlParameter("@Depart_id", SqlDbType.VarChar)
            aryParms(0).Value = Depart_id
            aryParms(1) = New SqlParameter("@Apply_name", SqlDbType.VarChar)
            aryParms(1).Value = Apply_name
            aryParms(2) = New SqlParameter("@Apply_idcard", SqlDbType.VarChar)
            aryParms(2).Value = Apply_idcard
            aryParms(3) = New SqlParameter("@Start_date", SqlDbType.VarChar)
            aryParms(3).Value = Start_date
            aryParms(4) = New SqlParameter("@End_date", SqlDbType.VarChar)
            aryParms(4).Value = End_date
            aryParms(5) = New SqlParameter("@Quit_job_flag", SqlDbType.VarChar)
            aryParms(5).Value = Quit_job_flag
            aryParms(6) = New SqlParameter("@PESEX", SqlDbType.VarChar)
            aryParms(6).Value = PESEX
            aryParms(7) = New SqlParameter("@Employee_type", SqlDbType.VarChar)
            aryParms(7).Value = Employee_type


            Return Query(sql.ToString(), aryParms)
        End Function


        Public Function getQueryData2(ByVal Orgcode As String, _
                                      ByVal Apply_idcard As String, _
                                      ByVal PKWDATE As String) As DataTable
            Dim sql As New StringBuilder()

            sql.AppendLine(" SELECT *,g.leave_name FROM FSC_Leave_main AS d")
            sql.AppendLine(" INNER JOIN SYS_Leave_type AS g ON g.Leave_type = d.Leave_type")
            sql.AppendLine(" LEFT JOIN SYS_Flow AS b ON b.orgcode = d.orgcode AND b.flow_id = d.flow_id")
            sql.AppendLine(" WHERE g.Leave_table <> '18' ")

            If Not String.IsNullOrEmpty(Apply_idcard) Then
                sql.AppendLine(" and d.Id_card = @Apply_idcard")
            End If

            sql.AppendLine(" AND d.Orgcode=@Orgcode ")
            sql.AppendLine(" AND d.Start_date <= @PKWDATE ")
            sql.AppendLine(" AND d.End_date >= @PKWDATE ")
            sql.AppendLine(" AND b.case_status NOT IN('3','4')")

            Dim aryParms(2) As SqlParameter
            aryParms(0) = New SqlParameter("@Apply_idcard", SqlDbType.VarChar)
            aryParms(0).Value = Apply_idcard
            aryParms(1) = New SqlParameter("@PKWDATE", SqlDbType.VarChar)
            aryParms(1).Value = PKWDATE
            aryParms(2) = New SqlParameter("@Orgcode", SqlDbType.VarChar)
            aryParms(2).Value = Orgcode


            Return Query(sql.ToString(), aryParms)
        End Function
    End Class
End Namespace
