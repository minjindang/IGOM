Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text

Namespace FSC.Logic
    Public Class FSC2126DAO
        Inherits BaseDAO

        Public Function getQueryData(ByVal orgcode As String, _
                                     ByVal Depart_id As String, _
                                     ByVal idcard As String, _
                                     ByVal idcard2 As String, _
                                     ByVal Start_date As String, _
                                     ByVal end_date As String, _
                                     ByVal yyymm As String) As DataTable

            Dim tablename As String = "FSC_CPAPK" & yyymm
            'Dim diff As Integer
            Dim sql As New StringBuilder()
            sql.AppendLine(" SELECT ")
            sql.AppendLine(" e.Depart_name,")
            sql.AppendLine(" a.PKCARD,")
            sql.AppendLine(" a.PKNAME,")
            sql.AppendLine(" a.PKWDATE,")
            sql.AppendLine(" a.PKSTIME,")
            sql.AppendLine(" a.PKETIME,")
            sql.AppendLine(" (select CODE_DESC1 from SYS_CODE as f where CODE_SYS = '023' and CODE_TYPE ='009' AND f.code_no = a.PKWKTPE) AS PKWKTPE")

            sql.AppendLine(" FROM " & tablename & " AS a")

            sql.AppendLine(" INNER JOIN FSC_Personnel AS c ON  c.Id_card = a.PKCARD")
            sql.AppendLine(" INNER JOIN FSC_Depart_EMP AS b ON a.PKCARD = b.Id_card and b.Service_type=(case when c.Employee_type='9' then '1' else '0' end)")
            sql.AppendLine(" INNER JOIN FSC_ORG AS e ON e.Orgcode = b.Orgcode AND e.Depart_id=b.Depart_id")


            sql.AppendLine(" WHERE a.PKWDATE NOT IN (select PBDDATE FROM FSC_CPAPB02M WHERE PBDTYPE = 2)")


            If Not String.IsNullOrEmpty(Depart_id) Then
                sql.AppendLine(" AND (b.Depart_id = @Depart_id or b.Depart_id in (select depart_id from fsc_org where parent_depart_id=@Depart_id))")
            End If
            If Not String.IsNullOrEmpty(idcard) Then
                sql.AppendLine(" AND a.PKCARD = @idcard ")
            End If
            If Not String.IsNullOrEmpty(idcard2) Then
                sql.AppendLine(" AND a.PKCARD = @idcard2 ")
            End If
            If Not String.IsNullOrEmpty(Start_date) Then
                sql.AppendLine(" AND a.PKWDATE >= @Start_date ")
            End If
            If Not String.IsNullOrEmpty(end_date) Then
                sql.AppendLine(" AND a.PKWDATE <= @end_date ")
            End If


            sql.AppendLine(" ORDER BY a.PKCARD,a.PKWDATE")

            Dim aryParms(5) As SqlParameter
            aryParms(0) = New SqlParameter("@orgcode", SqlDbType.VarChar)
            aryParms(0).Value = orgcode
            aryParms(1) = New SqlParameter("@idcard", SqlDbType.VarChar)
            aryParms(1).Value = idcard
            aryParms(2) = New SqlParameter("@Start_date", SqlDbType.VarChar)
            aryParms(2).Value = Start_date
            aryParms(3) = New SqlParameter("@Depart_id", SqlDbType.VarChar)
            aryParms(3).Value = Depart_id
            aryParms(4) = New SqlParameter("@idcard2", SqlDbType.VarChar)
            aryParms(4).Value = idcard2
            aryParms(5) = New SqlParameter("@end_date", SqlDbType.VarChar)
            aryParms(5).Value = end_date


            Return Query(sql.ToString(), aryParms)
        End Function


    End Class
End Namespace
