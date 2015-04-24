Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports Pemis2009.SQLAdapter
Imports System.Text

Namespace FSC.Logic

    Public Class FSC2128DAO
        Inherits BaseDAO

        Public Function GetCardData(ByVal orgcode As String, _
                                    ByVal departid As String, _
                                    ByVal titleno As String, _
                                    ByVal idcard As String, _
                                    ByVal quitjobflag As String) As DataTable

            Dim sql As New StringBuilder()

            sql.AppendLine(" select * from FSC_Personnel p ")
            sql.AppendLine(" inner join FSC_Depart_emp d on p.id_card = d.id_card ")
            sql.AppendLine(" where d.orgcode=@orgcode ")

            If Not String.IsNullOrEmpty(departid) Then
                sql.AppendLine(" and (d.depart_id=@departid or d.depart_id in (select depart_id from fsc_org where parent_depart_id=@departid)) ")
            End If
            If Not String.IsNullOrEmpty(titleno) Then
                sql.AppendLine(" and p.title_no=@titleno ")
            End If
            If Not String.IsNullOrEmpty(idcard) Then
                sql.AppendLine(" and p.id_card=@idcard ")
            End If
            If Not String.IsNullOrEmpty(quitjobflag) Then
                sql.AppendLine(" and quit_job_flag=@quitjobflag ")
            End If


            Dim params() As SqlParameter = { _
            New SqlParameter("@orgcode", orgcode), _
            New SqlParameter("@departid", departid), _
            New SqlParameter("@titleno", titleno), _
            New SqlParameter("@idcard", idcard), _
            New SqlParameter("@quitjobflag", quitjobflag)}

            Return Query(sql.ToString, params)
        End Function


        Public Function GetQueryData(ByVal TableName As String, _
                                     ByVal departid As String, _
                                     ByVal titleno As String, _
                                     ByVal idcard As String, _
                                     ByVal quitjobflag As String) As DataTable
            Dim sql As New StringBuilder()

            sql.AppendLine(" select a.pyvtype, a.pymon1, a.pymon2, a.pymon3, a.pymon4, a.pymon5, a.pymon6, a.pymon7, a.pymon8, a.pymon9, a.pymon10, a.pymon11, a.pymon12, a.pytot, a.pyidno ")
            sql.AppendLine(" from " & TableName & " a, fsc_depart_emp b, fsc_personnel c ")
            sql.AppendLine(" where b.id_card=c.id_card and a.pycard=b.id_card ")

            If Not String.IsNullOrEmpty(departid) Then
                sql.AppendLine(" and (b.depart_id=@departid or b.depart_id in (select depart_id from fsc_org where parent_depart_id = @departid)) ")
            End If
            If Not String.IsNullOrEmpty(titleno) Then
                sql.AppendLine(" and c.title_no=@titleno ")
            End If
            If Not String.IsNullOrEmpty(idcard) Then
                sql.AppendLine(" and c.id_card=@idcard ")
            End If
            If Not String.IsNullOrEmpty(quitjobflag) Then
                sql.AppendLine(" and c.quit_job_flag=@quitjobflag ")
            End If

            Dim leave_type As String = String.Empty

            For i As Integer = 1 To 25
                leave_type &= "'" & i.ToString.PadLeft(2, "0") & "',"
            Next

            sql.Append(" and a.pyvtype in (" & leave_type & "'28','30','31','51','52','53','57') ")

            sql.Append(" ORDER BY a.pycard, a.pyvtype ")

            Dim params() As SqlParameter = { _
            New SqlParameter("@departid", departid), _
            New SqlParameter("@titleno", titleno), _
            New SqlParameter("@idcard", idcard), _
            New SqlParameter("@quitjobflag", quitjobflag)}

            Return Query(sql.ToString, params)
        End Function
    End Class
End Namespace
