Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports System

Namespace FSC.Logic
    Public Class CPAPX24MDAO
        Inherits BaseDAO

        Public Function GetQueryData(ByVal idno As String, ByVal YearMonth As String) As DataTable
            Dim StrSQL As New StringBuilder()
            StrSQL.Append(" select * ")
            StrSQL.Append(" from FSC_CPAPX24M ")
            Dim WhereStr = " where "
            If Not idno Is Nothing And "" <> idno Then
                StrSQL.Append(WhereStr & " pXidno=@IdNo ")
                WhereStr = " and "
            End If
            If Not YearMonth Is Nothing And "" <> YearMonth Then
                StrSQL.Append(WhereStr & " substring(PXBREAKD,1,5)=@YearMonth  ")
                WhereStr = " and "
            End If
            StrSQL.Append(" ORDER BY PXBREAKD ")
            Dim params() As SqlParameter = {New SqlParameter("@IdNo", idno), New SqlParameter("@YearMonth", YearMonth)}

            Return Query(StrSQL.ToString, params)
        End Function

        Function GetDataByFlow_Id(ByVal Flow_Id As String) As DataTable
            Dim StrSQL As New StringBuilder
            StrSQL.Append("SELECT * FROM FSC_CPAPX24M WHERE PXUSERID=@Flow_Id order by pxaddd, pxbreakd")
            Dim param As SqlParameter = New SqlParameter("@Flow_Id", SqlDbType.VarChar)
            param.Value = Flow_Id
            Return Query(StrSQL.ToString(), param)
        End Function

        Public Function GetPXBREAKD(ByVal PXADDD As String, ByVal PXIDNO As String) As DataTable
            Dim StrSQL As New StringBuilder
            StrSQL.Append("SELECT PXBREAKD FROM FSC_CPAPX24M ")

            StrSQL.AppendLine(" WHERE PXIDNO=@PXIDNO AND PXADDD=@PXADDD ")


            Dim params(1) As SqlParameter
            params(0) = New SqlParameter("@PXADDD", SqlDbType.VarChar)
            params(0).Value = PXADDD
            params(1) = New SqlParameter("@PXIDNO", SqlDbType.VarChar)
            params(1).Value = PXIDNO
            Return Query(StrSQL.ToString(), params)
        End Function

        Public Function InsertData(ByVal px24m As CPAPX24M) As Integer
            Dim d As New System.Collections.Generic.Dictionary(Of String, Object)
            d.Add("Orgcode", px24m.Orgcode)
            d.Add("PXIDNO", px24m.PXIDNO)
            d.Add("PXCARD", px24m.PXCARD)
            d.Add("PXBREAKD", px24m.PXBREAKD)
            d.Add("PXBREAKDE", px24m.PXBREAKDE)
            d.Add("PXBREAKH", px24m.PXBREAKH)
            d.Add("PXSTIME", px24m.PXSTIME)
            d.Add("PXETIME", px24m.PXETIME)
            d.Add("PXADDD", px24m.PXADDD)
            d.Add("PXADDE", px24m.PXADDE)
            d.Add("PXTIMEB", px24m.PXTIMEB)
            d.Add("PXTIMEE", px24m.PXTIMEE)
            d.Add("PXUSERID", px24m.PXUSERID)
            d.Add("PXUPDATE", px24m.PXUPDATE)

            Return InsertByExample("FSC_CPAPX24M", d)
        End Function

        '人立新增0710 for FSC3104_01
        Function GetDataByPxuserid(ByVal flow_id As String, ByVal Orgcode As String) As DataTable
            Dim sSQL As New StringBuilder()
            sSQL.Append(" SELECT * FROM FSC_CPAPX24M  where pxuserid=@flow_id ")
            If Not String.IsNullOrEmpty(Orgcode) Then
                sSQL.AppendLine(" and Orgcode=@Orgcode ")
            End If
            Dim params() As SqlParameter = { _
            New SqlParameter("@flow_id", flow_id), _
            New SqlParameter("@Orgcode", Orgcode)}

            Return Query(sSQL.ToString(), params)
        End Function

        Function DeleteDataByGUID(ByVal Flow_id As String, ByVal Orgcode As String) As Integer
            Dim sql As New StringBuilder
            sql.Append("DELETE FROM FSC_CPAPX24M WHERE PXUSERID=@Flow_id")
            If Not String.IsNullOrEmpty(Orgcode) Then
                sql.Append(" and Orgcode=@Orgcode ")
            End If
            Dim params() As SqlParameter = { _
            New SqlParameter("@Flow_id", SqlDbType.VarChar), _
            New SqlParameter("@Orgcode", SqlDbType.VarChar)}
            params(0).Value = Flow_id
            params(1).Value = Orgcode

            Return Execute(sql.ToString(), params)
        End Function


        Public Function UpdateFlag(ByVal PXUSER As String, ByVal STATUS As String) As Integer
            Dim sql As New StringBuilder
            sql.AppendLine(" update FSC_CPAPX24M ")
            sql.AppendLine(" set status=@status ")
            sql.AppendLine(" where PXUSER=@PXUSER ")

            Dim params() As SqlParameter = { _
            New SqlParameter("@status", SqlDbType.VarChar), _
            New SqlParameter("@PXUSER", SqlDbType.VarChar)}
            params(0).Value = STATUS
            params(1).Value = PXUSER
            Return Execute(sql.ToString(), params)
        End Function

        Function GetCountByPRSTIME(ByVal PRIDNO As String, ByVal PRADDD As String, ByVal PRSTIME As String, ByVal PRETIME As String, ByVal isP2k As Boolean) As Object
            Dim SQL As New StringBuilder
            SQL.AppendLine("SELECT COUNT(*) FROM FSC_CPAPX24M ")

            If Not isP2k Then SQL.AppendLine("left outer join PLMDBP_NUK.dbo.flow on prguid=flow_id ")

            SQL.AppendLine("where ((PRSTIME < @PRSTIME and PRETIME > @PRSTIME ) ")
            SQL.AppendLine("        or (PRSTIME < @PRETIME and PRETIME > @PRETIME) ")
            SQL.AppendLine("        or (PRSTIME > @PRSTIME and PRETIME < @PRETIME) ")
            SQL.AppendLine("        or (PRSTIME = @PRSTIME and PRETIME = @PRETIME)) ")
            SQL.AppendLine("        and PRIDNO=@PRIDNO AND PRADDD=@PRADDD ")

            If Not isP2k Then SQL.AppendLine("     and Last_pass='0' ") '查plm 時, 需判斷是否已是結束的flow

            Dim params() As SqlParameter = { _
            New SqlParameter("@PRIDNO", SqlDbType.VarChar), _
            New SqlParameter("@PRADDD", SqlDbType.VarChar), _
            New SqlParameter("@PRSTIME", SqlDbType.VarChar), _
            New SqlParameter("@PRETIME", SqlDbType.VarChar)}
            params(0).Value = PRIDNO
            params(1).Value = PRADDD
            params(2).Value = PRSTIME
            params(3).Value = PRETIME
            Return Scalar(SQL.ToString, params)
        End Function


        Public Function GetData(ByVal PXIDNO As String, ByVal PXADDD As String) As DataTable
            Dim sql As New StringBuilder
            sql.Append(" SELECT * FROM FSC_CPAPX24M ")
            sql.Append(" WHERE PXIDNO=@PXIDNO AND PXADDD=@PXADDD ")

            Dim params(1) As SqlParameter
            params(0) = New SqlParameter("@PXIDNO", SqlDbType.VarChar)
            params(0).Value = PXIDNO
            params(1) = New SqlParameter("@PXADDD", SqlDbType.VarChar)
            params(1).Value = PXADDD

            Return Query(sql.ToString(), params)
        End Function


        Public Function GetDataByDate(ByVal pxidno As String, ByVal pxaddd As String, ByVal pxadde As String, ByVal pxtimeb As String, ByVal pxtimee As String) As DataTable
            Dim sql As New StringBuilder
            sql.Append("SELECT * FROM FSC_CPAPX24M where pxidno=@pxidno and pxaddd=@pxaddd ")

            If Not String.IsNullOrEmpty(pxadde) Then
                sql.AppendLine(" and pxadde=@pxadde ")
            End If
            If Not String.IsNullOrEmpty(pxtimeb) Then
                sql.AppendLine(" and pxtimeb=@pxtimeb ")
            End If
            If Not String.IsNullOrEmpty(pxtimee) Then
                sql.AppendLine(" AND pxtimee=@pxtimee ")
            End If

            Dim params(4) As SqlParameter
            params(0) = New SqlParameter("@pxidno", SqlDbType.VarChar)
            params(0).Value = pxidno
            params(1) = New SqlParameter("@pxaddd", SqlDbType.VarChar)
            params(1).Value = pxaddd
            params(2) = New SqlParameter("@pxadde", SqlDbType.VarChar)
            params(2).Value = pxadde
            params(3) = New SqlParameter("@pxtimeb", SqlDbType.VarChar)
            params(3).Value = pxtimeb
            params(4) = New SqlParameter("@psovetime", SqlDbType.VarChar)
            params(4).Value = pxtimee

            Return Query(sql.ToString, params)
        End Function


        Public Function GetCountByPK(ByVal PXIDNO As String, ByVal PXBREAKD As String, ByVal PXADDD As String, ByVal isP2K As Boolean) As Object
            Dim sql As New StringBuilder
            sql.Append("SELECT COUNT(1) FROM FSC_CPAPX24M ")

            If Not isP2K Then sql.AppendLine("left outer join PLMDBP_NUK.dbo.flow on pxuserid=flow_id ")

            sql.AppendLine(" WHERE PXIDNO=@PXIDNO AND PXBREAKD=@PXBREAKD AND PXADDD=@PXADDD ")


            If Not isP2K Then sql.AppendLine("     and Last_pass='0' ") '查plm 時, 需判斷是否已是結束的flow

            Dim params(2) As SqlParameter
            params(0) = New SqlParameter("@PXADDD", SqlDbType.VarChar)
            params(0).Value = PXADDD
            params(1) = New SqlParameter("@PXIDNO", SqlDbType.VarChar)
            params(1).Value = PXIDNO
            params(2) = New SqlParameter("@PXBREAKD", SqlDbType.VarChar)
            params(2).Value = PXBREAKD

            Return Scalar(sql.ToString(), params)
        End Function


        Public Function UpdateData(ByVal px24m As CPAPX24M) As Integer
            Dim StrSQL As New StringBuilder
            StrSQL.Append("UPDATE FSC_CPAPX24M SET ")
            StrSQL.Append("    Orgcode = @Orgcode, PXIDNO=@PXIDNO, PXCARD=@PXCARD, PXBREAKD=@PXBREAKD, PXBREAKH=@PXBREAKH, PXADDD=@PXADDD, PXUPDATE= @PXUPDATE) ")
            StrSQL.Append("WHERE ")
            StrSQL.Append(" PXUSERID　=@PXUSERID  ")

            Dim params(7) As SqlParameter
            params(0) = New SqlParameter("@PXIDNO", SqlDbType.VarChar)
            params(0).Value = px24m.PXIDNO
            params(1) = New SqlParameter("@PXCARD", SqlDbType.VarChar)
            params(1).Value = px24m.PXCARD
            params(2) = New SqlParameter("@PXBREAKD", SqlDbType.VarChar)
            params(2).Value = px24m.PXBREAKD
            params(3) = New SqlParameter("@PXBREAKH", SqlDbType.Float)
            params(3).Value = px24m.PXBREAKH
            params(4) = New SqlParameter("@PXADDD", SqlDbType.VarChar)
            params(4).Value = px24m.PXADDD
            params(5) = New SqlParameter("@PXUSERID", SqlDbType.VarChar)
            params(5).Value = px24m.PXUSERID
            params(6) = New SqlParameter("@PXUPDATE", SqlDbType.VarChar)
            params(6).Value = px24m.PXUPDATE
            params(7) = New SqlParameter("@Orgcode", SqlDbType.VarChar)
            params(7).Value = px24m.Orgcode

            Return Execute(StrSQL.ToString(), params)

        End Function
    End Class
End Namespace