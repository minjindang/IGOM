Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text

Namespace FSC.Logic
    Public Class FSC2123DAO
        Inherits BaseDAO

        Public Function getQueryData(ByVal orgcode As String, _
                                     ByVal Depart_id As String, _
                                     ByVal Start_date As String) As DataTable
            Dim sql As New StringBuilder()
            sql.AppendLine(" select ")
            sql.AppendLine(" Depart_id,")
            sql.AppendLine(" Depart_name,")
            sql.AppendLine(" (select count(a.Id_card) from FSC_Depart_EMP AS a INNER JOIN FSC_Personnel AS b ON a.Id_card = b.Id_card where a.Depart_id like substring(f.Depart_id,0,3)+'%')as total,")
            sql.AppendLine(" (select count(Id_card) from FSC_Leave_main AS a INNER JOIN SYS_Leave_type AS b ON a.Leave_type = b.Leave_type WHERE b.Leave_table='15' AND a.Depart_id like substring(f.Depart_id,0,3)+'%'")
            sql.AppendLine(" AND a.Start_date = @Start_date )as leave,")
            sql.AppendLine(" (select count(Id_card) from FSC_Leave_main AS a INNER JOIN SYS_Leave_type AS b ON a.Leave_type = b.Leave_type WHERE b.Leave_table='16' AND a.Depart_id like substring(f.Depart_id,0,3)+'%'")
            sql.AppendLine("  AND a.Start_date = @Start_date )as business,")
            sql.AppendLine(" (select count(Id_card) from FSC_Leave_main AS a INNER JOIN SYS_Leave_type AS b ON a.Leave_type = b.Leave_type WHERE b.Leave_table='18' AND a.Depart_id like substring(f.Depart_id,0,3)+'%'")
            sql.AppendLine("  AND a.Start_date = @Start_date )as work,")
            sql.AppendLine(" (select count(Id_card) from FSC_Leave_main AS a INNER JOIN SYS_Leave_type AS b ON a.Leave_type = b.Leave_type WHERE b.Leave_table IN ('04','20','32')")
            sql.AppendLine(" AND a.Depart_id like substring(f.Depart_id,0,3)+'%' AND a.Start_date = @Start_date )as rest")

            sql.AppendLine(" FROM FSC_ORG AS f")
            sql.AppendLine(" WHERE 1=1")
      

            Dim a = 0
            If Not String.IsNullOrEmpty(Depart_id) Then
                sql.AppendLine(" AND ( ")
                For Each s As String In Depart_id.Split(",")
                    If a = "0" Then
                        sql.AppendLine(" f.Depart_id = @s" & a)
                    Else
                        '已決行
                        sql.AppendLine(" OR f.Depart_id = @s" & a)
                    End If
                    a = a + 1
                Next
                sql.AppendLine(" ) ")
            End If

            'sql.AppendLine(" ORDER BY b.Orgcode,a.PKCARD")

            'Dim aryParms(1) As SqlParameter
            Dim aryParms(1 + Depart_id.Split(",").Length - 1) As SqlParameter
            aryParms(0) = New SqlParameter("@Start_date", SqlDbType.VarChar)
            aryParms(0).Value = Start_date

            For i As Integer = 0 To Depart_id.Split(",").Length - 1
                aryParms(1 + i) = New SqlParameter("@s" & i, SqlDbType.VarChar)
                aryParms(1 + i).Value = Depart_id.Split(",")(i)
            Next
            Return Query(sql.ToString(), aryParms)
        End Function

        Public Function getQueryDataDep(ByVal orgcode As String, _
                             ByVal Depart_id As String) As DataTable
            Dim sql As New StringBuilder()
            sql.AppendLine(" SELECT ")
            sql.AppendLine(" e.Depart_name,")
            sql.AppendLine(" d.User_name,")
            sql.AppendLine(" a.Id_card,")
            sql.AppendLine(" (select case d.Shift_type when '3' then 'V' end) as Shift_type,")
            sql.AppendLine(" (select CODE_DESC1 from SYS_CODE AS c where c.CODE_SYS='023' and c.CODE_TYPE='022' and c.CODE_NO = d.Employee_type) as Employee_type,")
            sql.AppendLine(" (select CODE_DESC1 from SYS_CODE AS c where c.CODE_SYS='023' and c.CODE_TYPE='025' and c.CODE_NO = d.Quit_job_flag) as Quit_job_flag")
            sql.AppendLine(" FROM FSC_Depart_EMP AS a")
            sql.AppendLine(" INNER JOIN FSC_Personnel AS d ON d.Id_card = a.Id_card")
            sql.AppendLine(" INNER JOIN FSC_ORG AS e ON e.Orgcode = a.Orgcode AND e.Depart_id = a.Depart_id ")

            sql.AppendLine(" WHERE a.Depart_id like @Depart_id")
            sql.AppendLine(" order by e.Depart_name")

            Dim aryParms(0) As SqlParameter
        
            aryParms(0) = New SqlParameter("@Depart_id", SqlDbType.VarChar)
            aryParms(0).Value = Depart_id
      
            Return Query(sql.ToString(), aryParms)
        End Function

        Public Function getQueryDataDLea(ByVal orgcode As String, _
                     ByVal Start_date As String) As DataTable
            Dim sql As New StringBuilder()
            sql.AppendLine(" SELECT ")
            sql.AppendLine(" b.Id_card,")
            sql.AppendLine(" c.Leave_name,")
            sql.AppendLine(" b.Start_date,")
            sql.AppendLine(" b.Start_time,")
            sql.AppendLine(" b.End_date,")
            sql.AppendLine(" b.End_time")

            sql.AppendLine(" FROM FSC_Personnel AS d")
            sql.AppendLine(" INNER JOIN FSC_Leave_main AS b ON b.Id_card = d.Id_card")
            sql.AppendLine(" INNER JOIN sys_leave_type AS c ON c.Orgcode = b.Orgcode AND c.Leave_type = b.Leave_type")

            sql.AppendLine(" WHERE b.Start_date = @Start_date")
            'AND c.Leave_table <> 18
            Dim aryParms(0) As SqlParameter
            aryParms(0) = New SqlParameter("@Start_date", SqlDbType.VarChar)
            aryParms(0).Value = Start_date

            Return Query(sql.ToString(), aryParms)
        End Function

    End Class
End Namespace
