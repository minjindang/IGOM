Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports System

Namespace FSC.Logic
    Public Class CPAPS19MDAO
        Inherits BaseDAO

        Public Function GetQueryData(ByVal idno As String, ByVal YearMonth As String) As DataTable
            Dim StrSQL As New StringBuilder()
            StrSQL.Append(" select * ")
            StrSQL.Append(" FROM FSC_CPAPS19M WITH(NOLOCK) ")
            Dim WhereStr = " where "
            If Not IDNO Is Nothing And "" <> IDNO Then
                StrSQL.Append(WhereStr & " psidno=@PPIDNO ")
                WhereStr = " and "
            End If
            If Not YearMonth Is Nothing And "" <> YearMonth Then
                StrSQL.Append(WhereStr & " substring(PSBREAKD,1,5)=@YearMonth  ")
                WhereStr = " and "
            End If
            StrSQL.Append(" ORDER BY PSBREAKD ")
            Dim params() As SqlParameter = {New SqlParameter("@PPIDNO", IDNO), New SqlParameter("@YearMonth", YearMonth)}

            Return Query(StrSQL.ToString, params)
        End Function

        Public Function GetDataByFlow_id(ByVal Flow_id As String) As DataTable
            Dim StrSQL As New StringBuilder
            StrSQL.Append("SELECT * FROM FSC_CPAPS19M WITH(NOLOCK) WHERE PSUSERID=@Flow_Id order by psaddd, psbreakd")
            Dim param As SqlParameter = New SqlParameter("@Flow_Id", SqlDbType.VarChar)
            param.Value = Flow_id
            Return Query(StrSQL.ToString(), param)
        End Function

        Public Function GetDataByDate(ByVal psidno As String, ByVal psaddd As String, ByVal psadde As String, psovstime As String, psovetime As String) As DataTable
            Dim sql As New StringBuilder()
            sql.Append("SELECT * FROM FSC_CPAPS19M WITH(NOLOCK) WHERE PSIDNO=@PSIDNO AND PSADDD=@psaddd ")

            If Not String.IsNullOrEmpty(psadde) Then
                sql.AppendLine(" and psadde=@psaddd ")
            End If
            If Not String.IsNullOrEmpty(psovstime) Then
                sql.AppendLine(" and psovstime=@psovstime ")
            End If
            If Not String.IsNullOrEmpty(psovetime) Then
                sql.AppendLine(" AND psovetime=@psovetime ")
            End If

            Dim params(4) As SqlParameter
            params(0) = New SqlParameter("@psidno", SqlDbType.VarChar)
            params(0).Value = psidno
            params(1) = New SqlParameter("@psaddd", SqlDbType.VarChar)
            params(1).Value = psaddd
            params(2) = New SqlParameter("@psadde", SqlDbType.VarChar)
            params(2).Value = psadde
            params(3) = New SqlParameter("@psovstime", SqlDbType.VarChar)
            params(3).Value = psovstime
            params(4) = New SqlParameter("@psovetime", SqlDbType.VarChar)
            params(4).Value = psovetime

            Return Query(sql.ToString(), params)
        End Function

        Public Function GetCountByPSBREAKD(ByVal PSIDNO As String, ByVal PSBREAKD As String, ByVal PSADDD As String) As Object
            Dim StrSQL As New StringBuilder
            StrSQL.Append("SELECT COUNT(*) FROM FSC_CPAPS19M WITH(NOLOCK) WHERE PSIDNO=@PSIDNO AND PSBREAKD=@PSBREAKD AND PSADDD=@PSADDD ")
            Dim params(2) As SqlParameter
            params(0) = New SqlParameter("@PSIDNO", SqlDbType.VarChar)
            params(0).Value = PSIDNO
            params(1) = New SqlParameter("@PSBREAKD", SqlDbType.VarChar)
            params(1).Value = PSBREAKD
            params(2) = New SqlParameter("@PSADDD", SqlDbType.VarChar)
            params(2).Value = PSADDD
            Return Scalar(StrSQL.ToString(), params)
        End Function

        Public Function InsertData(ByVal ps19m As CPAPS19M) As Integer
            Dim d As New System.Collections.Generic.Dictionary(Of String, Object)
            d.Add("Orgcode", ps19m.Orgcode)
            d.Add("PSIDNO", ps19m.PSIDNO)
            d.Add("PSCARD", ps19m.PSCARD)
            d.Add("PSBREAKD", ps19m.PSBREAKD)
            d.Add("PSBREAKDE", ps19m.PSBREAKDE)
            d.Add("PSBREAKH", ps19m.PSBREAKH)
            d.Add("PSSTIME", ps19m.PSSTIME)
            d.Add("PSETIME", ps19m.PSETIME)
            d.Add("PSADDD", ps19m.PSADDD)
            d.Add("PSADDE", ps19m.PSADDE)
            d.Add("PSOVSTIME", ps19m.PSOVSTIME)
            d.Add("PSOVETIME", ps19m.PSOVETIME)
            d.Add("PSUSERID", ps19m.PSUSERID)
            d.Add("PSUPDATE", ps19m.PSUPDATE)

            Return InsertByExample("FSC_CPAPS19M", d)
        End Function

        '人立新增0710 for FSC3104_01
        Function GetDataByPsuserid(ByVal flow_id As String, ByVal Orgcode As String) As DataTable
            Dim sSQL As New StringBuilder()
            sSQL.Append(" SELECT  *  FROM FSC_CPAPS19M WITH(NOLOCK) where psuserid=@flow_id ")
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
            sql.Append("DELETE FROM FSC_CPAPS19M WHERE PSUSERID=@Flow_id")
            If Not String.IsNullOrEmpty(Orgcode) Then
                sql.Append(" and Orgcode=@Orgcode ")
            End If
            Dim params() As SqlParameter = { _
            New SqlParameter("@Flow_id", SqlDbType.VarChar), _
            New SqlParameter("@Orgcode", SqlDbType.VarChar)}
            params(0).Value = Flow_id
            params(1).Value = Orgcode
            DBUtil.SetParamsNull(params)
            Return Execute(sql.ToString(), params)
        End Function


        Public Function UpdateFlag(ByVal PSUSERID As String, ByVal STATUS As String) As Integer
            Dim sql As New StringBuilder
            sql.AppendLine(" update FSC_CPAPS19M ")
            sql.AppendLine(" set status=@status ")
            sql.AppendLine(" where PSUSERID=@PSUSERID ")

            Dim params() As SqlParameter = { _
            New SqlParameter("@status", SqlDbType.VarChar), _
            New SqlParameter("@PSUSERID", SqlDbType.VarChar)}
            params(0).Value = STATUS
            params(1).Value = PSUSERID
            Return Execute(sql.ToString(), params)
        End Function

        Public Function UpdateData(ByVal ps19m As CPAPS19M) As Integer
            Dim StrSQL As New StringBuilder
            StrSQL.Append("UPDATE FSC_CPAPS19M SET")
            StrSQL.Append("     Orgcode = @Orgcode, PSIDNO = @PSIDNO, PSCARD = @PSCARD, PSBREAKD= @PSBREAKD, PSBREAKH=@PSBREAKH, PSADDD=@PSADDD")
            StrSQL.Append("     , PSUSERID=@PSUSERID, PSUPDATE = @PSUPDATE, PSOVSTIME = @PSOVETIME, PSOVETIME= @PSOVETIME ")
            StrSQL.Append("     , PSSTIME = @PSSTIME, PSETIME = @PSETIME, PSADDE=@PSADDE ")
            StrSQL.Append("WHERE ")
            StrSQL.Append("  PSUSERID = @PSUSERID")

            Dim params(12) As SqlParameter
            params(0) = New SqlParameter("@PSIDNO", SqlDbType.VarChar)
            params(0).Value = ps19m.PSIDNO
            params(1) = New SqlParameter("@PSCARD", SqlDbType.VarChar)
            params(1).Value = ps19m.PSCARD
            params(2) = New SqlParameter("@PSBREAKD", SqlDbType.VarChar)
            params(2).Value = ps19m.PSBREAKD
            params(3) = New SqlParameter("@PSBREAKH", SqlDbType.VarChar)
            params(3).Value = ps19m.PSBREAKH
            params(4) = New SqlParameter("@PSADDD", SqlDbType.VarChar)
            params(4).Value = ps19m.PSADDD
            params(5) = New SqlParameter("@PSUSERID", SqlDbType.VarChar)
            params(5).Value = ps19m.PSUSERID
            params(6) = New SqlParameter("@PSUPDATE", SqlDbType.VarChar)
            params(6).Value = DateTimeInfo.GetRocDate(Now) & Now.ToString("HHmm")
            params(7) = New SqlParameter("@PSOVSTIME", SqlDbType.VarChar)
            params(7).Value = ps19m.PSOVSTIME
            params(8) = New SqlParameter("@PSOVETIME", SqlDbType.VarChar)
            params(8).Value = ps19m.PSOVETIME
            params(9) = New SqlParameter("@PSSTIME", SqlDbType.VarChar)
            params(9).Value = ps19m.PSSTIME
            params(10) = New SqlParameter("@PSETIME", SqlDbType.VarChar)
            params(10).Value = ps19m.PSETIME
            params(11) = New SqlParameter("@PSADDE", SqlDbType.VarChar)
            params(11).Value = ps19m.PSADDE
            params(12) = New SqlParameter("@Orgcode", SqlDbType.VarChar)
            params(12).Value = ps19m.Orgcode

            Return Execute(StrSQL.ToString(), params)
        End Function
    End Class
End Namespace
