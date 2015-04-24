Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text

Namespace FSC.Logic
    Public Class FSC2117DAO
        Inherits BaseDAO

        Public Function getQueryData(ByVal yyymm As String, _
                                     ByVal orgcode As String, _
                                     ByVal Depart_id As String, _
                                     ByVal Apply_name As String, _
                                     ByVal Apply_idcard As String, _
                                     ByVal Start_date As String, _
                                     ByVal End_date As String, _
                                     ByVal Quit_job_flag As String, _
                                     ByVal Employee_type As String, _
                                     ByVal Title_no As String) As DataTable
            Dim sql As New StringBuilder()
            sql.AppendLine(" SELECT ")
            sql.AppendLine(" e.Depart_name,")
            sql.AppendLine(" a.PKCARD,")
            sql.AppendLine(" a.PKNAME,")
            sql.AppendLine(" (select CODE_DESC1 from SYS_CODE AS f where f.code_sys = '023' and f.CODE_TYPE ='020' AND f.CODE_NO = c.Shift_type) as Shift_type,")
            sql.AppendLine(" a.PKWDATE,")
            sql.AppendLine(" a.PKSTIME,")
            sql.AppendLine(" a.PKNTIME,")
            sql.AppendLine(" a.PKWKTPE,")
            sql.AppendLine(" a.PKETIME,")
            sql.AppendLine(" (select case a.PKWKTPE when 3 then 'V' end) as Absense")
            sql.AppendLine(" FROM FSC_CPAPK" + yyymm + " AS a ")
            sql.AppendLine(" INNER JOIN FSC_Personnel AS c ON  c.Id_card = a.PKCARD")
            sql.AppendLine(" INNER JOIN FSC_Depart_EMP AS b ON a.PKCARD = b.Id_card")
            sql.AppendLine(" LEFT JOIN FSC_ORG AS e ON e.Orgcode = b.Orgcode AND e.Depart_id=b.Depart_id")
            'sql.AppendLine(" LEFT JOIN FSC_Forgot_clock_apply AS f ON f.id = b.id")
            sql.AppendLine(" WHERE 1=1")
            'sql.AppendLine(" AND c.Yoyo_card = '1'")

            If Not String.IsNullOrEmpty(Depart_id) Then
                sql.AppendLine(" AND (b.Depart_id = @Depart_id or b.Depart_id in (select depart_id from fsc_org where parent_depart_id=@Depart_id)) ")
            End If
            If Not String.IsNullOrEmpty(Apply_name) Then
                sql.AppendLine(" AND a.PKCARD = @Apply_name ")
            End If
            If Not String.IsNullOrEmpty(Apply_idcard) Then
                sql.AppendLine(" AND a.PKCARD = @Apply_idcard ")
            End If
            If Not String.IsNullOrEmpty(Start_date) Then
                sql.AppendLine(" AND a.PKWDATE >= @Start_date ")
            End If
            If Not String.IsNullOrEmpty(End_date) Then
                sql.AppendLine(" AND a.PKWDATE <= @End_date ")
            End If
            If Not String.IsNullOrEmpty(Quit_job_flag) Then
                sql.AppendLine(" AND c.Quit_job_flag = @Quit_job_flag ")
            End If

            If Not String.IsNullOrEmpty(Employee_type) Then
                sql.AppendLine(" AND c.Employee_type = @Employee_type ")
            End If
            If Not String.IsNullOrEmpty(Title_no) Then
                sql.AppendLine(" AND c.Title_no = @Title_no ")
            End If

            sql.AppendLine(" ORDER BY b.Orgcode,a.PKCARD")

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
            aryParms(6) = New SqlParameter("@Employee_type", SqlDbType.VarChar)
            aryParms(6).Value = Employee_type
            aryParms(7) = New SqlParameter("@Title_no", SqlDbType.VarChar)
            aryParms(7).Value = Title_no


            Return Query(sql.ToString(), aryParms)
        End Function


    End Class
End Namespace
