Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports Pemis2009.SQLAdapter
Imports System.Text

Namespace FSC.Logic

    Public Class FSC2129DAO
        Inherits BaseDAO

        Public Function GetData(ByVal orgcode As String, _
                                ByVal idcard As String, _
                                ByVal yyy As String) As DataTable

            Dim sql As New StringBuilder()

            sql.AppendLine(" select ")
            sql.AppendLine(GetSubSQL("05")).Append(",")
            sql.AppendLine(GetSubSQL("01")).Append(",")
            sql.AppendLine(GetSubSQL("25")).Append(",")
            sql.AppendLine(GetSubSQL("02")).Append(",")
            sql.AppendLine(GetSubSQL("24")).Append(",")
            sql.AppendLine(GetSubSQL("08")).Append(",")
            sql.AppendLine(GetSubSQL("21")).Append(",")
            sql.AppendLine(GetSubSQL("09")).Append(",")
            sql.AppendLine(GetSubSQL("13")).Append(",")
            sql.AppendLine(GetSubSQL("22")).Append(",")
            sql.AppendLine(GetSubSQL("03", "1")).Append(",")
            sql.AppendLine(GetSubSQL("03", "0")).Append(",")
            sql.AppendLine(GetSubSQL("10")).Append(",")
            sql.AppendLine(GetSubSQL("04")).Append(",")
            sql.AppendLine(GetSubSQL("20")).Append(",")
            sql.AppendLine(GetSubSQL("32")).Append(",")
            sql.AppendLine(GetSubSQL("06")).Append(",")
            sql.AppendLine(GetSubSQL("18")).Append(",")
            sql.AppendLine(GetSubSQL("23")).Append(",")
            sql.AppendLine("''")

            Dim params() As SqlParameter = { _
            New SqlParameter("@orgcode", orgcode), _
            New SqlParameter("@id_card", idcard), _
            New SqlParameter("@yyy", yyy)}

            Return Query(sql.ToString, params)
        End Function

        Protected Function GetSubSQL(ByVal leaveType As String) As String
            Return GetSubSQL(leaveType, "")
        End Function

        Protected Function GetSubSQL(ByVal leaveType As String, ByVal retainFlag As String) As String
            Dim sql As New StringBuilder()

            sql.Append(" (select ")
            sql.Append("    isnull(sum(a.leave_hours),0) as hours ")
            sql.Append(" from FSC_Leave_main a ")
            sql.Append("    left outer join SYS_Flow b on a.orgcode=b.orgcode and a.flow_id=b.flow_id ")
            sql.Append(" where a.orgcode=@orgcode ")
            sql.Append("    and substring(a.start_date,1,3)=@yyy ")
            sql.Append("    and a.leave_type='").Append(leaveType).Append("' ")
            sql.Append("    and a.id_card=@id_card ")
            sql.Append("    and (b.case_status is null or b.case_status in (0,1,2)) ")

            If Not String.IsNullOrEmpty(retainFlag) Then
                sql.Append("    and a.retain_flag='").Append(retainFlag).Append("'")
            End If

            sql.Append(" ) ").Append(" as L").Append(leaveType)

            If Not String.IsNullOrEmpty(retainFlag) Then
                sql.Append("_").Append(retainFlag)
            End If

            Return sql.ToString()
        End Function
    End Class
End Namespace
