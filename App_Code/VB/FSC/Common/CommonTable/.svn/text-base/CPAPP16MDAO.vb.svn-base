Imports Microsoft.VisualBasic
Imports System.Data
Imports Pemis2009.SQLAdapter
Imports System.Data.SqlClient
Imports System.Text
Imports System
Imports FSCPLM.Logic

Namespace FSC.Logic

    Public Class CPAPP16MDAO
        Inherits BaseDAO


        Public Function GetAllYearData(ByVal PPIDNO As String, ByVal YYY As String) As DataTable
            Dim sql As New StringBuilder()

            sql.AppendLine(" select *  ")
            sql.AppendLine(" from FSC_CPAPP16M a ")
            sql.AppendLine(" where PPIDNO=@PPIDNO and substring(PPBUSDATEB,1,3)=@YYY ")

            Dim params() As SqlParameter = { _
            New SqlParameter("@PPIDNO", PPIDNO), _
            New SqlParameter("@YYY", YYY)}
            Return Query(sql.ToString, params)
        End Function

        Function getData(PPBUSTYPE As String, PPIDNO As String, PPBUSDATEB_S As String, PPBUSDATEB_E As String) As DataTable
            Dim sSQL As New StringBuilder()
            sSQL.Append(" select * ")
            sSQL.Append(" from FSC_CPAPP16M WITH(NOLOCK) ")
            sSQL.Append(" where 1 = 1 ")

            If Not PPBUSTYPE Is Nothing And "" <> PPBUSTYPE Then
                sSQL.Append(" And PPBUSTYPE=@PPBUSTYPE ")
            End If
            If Not PPIDNO Is Nothing And "" <> PPIDNO Then
                sSQL.Append(" And ppidno=@PPIDNO ")
            End If

            If Not String.IsNullOrEmpty(PPBUSDATEB_S) And Not String.IsNullOrEmpty(PPBUSDATEB_E) Then
                sSQL.Append(" and (@PPBUSDATEB_S between ppbusdateb and ppbusdatee ")
                sSQL.AppendLine(" or @PPBUSDATEB_E between ppbusdateb and ppbusdatee ")
                sSQL.AppendLine(" or (@PPBUSDATEB_S <= ppbusdateb and @PPBUSDATEB_E >= ppbusdatee)) ")
            End If
            sSQL.Append(" ORDER BY ppname , ppbusdateb ")
            Dim params() As SqlParameter = {New SqlParameter("@PPBUSTYPE", PPBUSTYPE), New SqlParameter("@PPBUSDATEB_S", PPBUSDATEB_S), New SqlParameter("@PPBUSDATEB_E", PPBUSDATEB_E), New SqlParameter("@PPIDNO", PPIDNO)}
            Return Query(sSQL.ToString, params)
        End Function

        Public Function GetQueryData(PPIDNO As String, PPBUSTYPE As String, ByVal YearMonth As String) As DataTable
            Dim StrSQL As New StringBuilder()
            StrSQL.Append(" select * ")
            StrSQL.Append(" from FSC_CPAPP16M WITH(NOLOCK) ")
            Dim WhereStr = " where "
            If Not PPIDNO Is Nothing And "" <> PPIDNO Then
                StrSQL.Append(WhereStr & " ppidno=@PPIDNO ")
                WhereStr = " and "
            End If
            If Not YearMonth Is Nothing And "" <> YearMonth Then
                StrSQL.Append(WhereStr & " (substring(PPBUSDATEB,1,5)=@YearMonth or substring(PPBUSDATEE,1,5)=@YearMonth) ")
                WhereStr = " and "
            End If
            If Not PPBUSTYPE Is Nothing And "" <> PPBUSTYPE Then
                StrSQL.Append(WhereStr & " PPBUSTYPE=@PPBUSTYPE ")
                WhereStr = " and "
            End If
            StrSQL.Append(" ORDER BY PPBUSDATEB ")
            Dim params() As SqlParameter = {New SqlParameter("@PPIDNO", PPIDNO), New SqlParameter("@YearMonth", YearMonth), New SqlParameter("@PPBUSTYPE", PPBUSTYPE)}
            'Return StrSQL.ToString & ";YearMonth=" & YearMonth & ";IdNo=" & IdNo
            Return Query(StrSQL.ToString, params)
        End Function
        Public Function GetDetailData(ByVal PPIDNO As String, ByVal GUID As String) As DataTable
            Dim StrSQL As New StringBuilder()
            StrSQL.Append(" select * ")
            StrSQL.Append(" from FSC_CPAPP16M WITH(NOLOCK) ")
            Dim WhereStr = " where "
            If Not Guid Is Nothing And "" <> Guid Then
                StrSQL.Append(WhereStr & " PPGUID=@GUID ")
                WhereStr = " and "
            End If
            StrSQL.Append(" ORDER BY PPBUSDATEB ")
            Dim params() As SqlParameter = {New SqlParameter("@PPIDNO", PPIDNO), New SqlParameter("@GUID", Guid)}

            Return Query(StrSQL.ToString, params)
        End Function
       

        Public Function GetDataByFlow_id(ByVal Flow_id As String, ByVal Orgcode As String) As DataTable
            Dim StrSQL As New StringBuilder
            StrSQL.Append("SELECT * FROM FSC_CPAPP16M WITH(NOLOCK) WHERE PPGUID=@Flow_Id ")
            If Not String.IsNullOrEmpty(Orgcode) Then
                StrSQL.AppendLine(" and Orgcode=@Orgcode ")
            End If
            StrSQL.AppendLine(" order by PPBUSDATEB ")

            Dim params() As SqlParameter = { _
            New SqlParameter("@Flow_Id", SqlDbType.VarChar), _
            New SqlParameter("@Orgcode", SqlDbType.VarChar)}
            params(0).Value = Flow_id
            params(1).Value = Orgcode
            DBUtil.SetParamsNull(params)
            Return Query(StrSQL.ToString(), params)
        End Function

        Public Function GetTimeIntervalByPPGUID(ByVal PPGUID As String) As DataTable
            Dim sql As New StringBuilder
            sql.Append(" SELECT ")
            sql.Append("       MIN(PPBUSDATEB) AS StartDate, MAX(PPBUSDATEE) AS EndDate ")
            sql.Append(" FROM  ")
            sql.Append("       FSC_CPAPP16M WITH(NOLOCK) ")
            sql.Append(" WHERE  ")
            sql.Append("       PPGUID = @PPGUID ")
            sql.Append("        ")
            Dim params() As SqlParameter = {New SqlParameter("@PPGUID", PPGUID)}
            Return Query(sql.ToString, params)
        End Function

        'Public Function GetDataByCondition(ByVal PPGUID As String, ByVal PPBUSDATEB As String)
        '    Dim sql As New StringBuilder
        '    sql.Append(" SELECT ")
        '    sql.Append("       * ")
        '    sql.Append(" FROM  ")
        '    sql.Append("       CPAPP16M ")
        '    sql.Append(" WHERE  ")
        '    sql.Append("       PPGUID = @PPGUID ")
        '    sql.Append("       AND PPBUSDATEB = @PPBUSDATEB ")
        '    Dim params() As SqlParameter = {New SqlParameter("@PPGUID", PPGUID), New SqlParameter("@PPBUSDATEB", PPBUSDATEB)}
        '    Return Query(sql.ToString, params)
        'End Function

        Public Function UpdateReMarkByCondition(ByVal PPBEFOREM As Integer, ByVal PPREMARK As String, ByVal PPIDNO As String, ByVal PPBUSTYPE As String, ByVal PPBUSDATEB As String, ByVal PPTIMEB As String) As Integer
            Dim sql As New StringBuilder

            sql.AppendLine(" UPDATE ")
            sql.AppendLine("        FSC_CPAPP16M ")
            sql.AppendLine(" SET ")
            sql.AppendLine("        PPBEFOREM=@PPBEFOREM ")
            sql.AppendLine("        ,PPREMARK=@PPREMARK ")
            sql.AppendLine("        ,PPUSERID=@PPUSERID ")
            sql.AppendLine("        ,PPUPDATE=@PPUPDATE ")

            'If PPREMARK = "1" Then
            '    sql.AppendLine(", PPREMARK_DATE=@PPREMARK_DATE ")
            'Else
            '    sql.AppendLine(", PPREMARK_DATE=NULL ")
            'End If

            sql.AppendLine(" WHERE ")
            sql.AppendLine("        PPIDNO = @PPIDNO ")
            sql.AppendLine("        AND PPBUSTYPE = @PPBUSTYPE ")
            sql.AppendLine("        AND PPBUSDATEB = @PPBUSDATEB ")
            sql.AppendLine("        AND PPTIMEB = @PPTIMEB ")

            Dim params() As SqlParameter = { _
            New SqlParameter("@PPBEFOREM", PPBEFOREM), _
            New SqlParameter("@PPREMARK", PPREMARK), _
            New SqlParameter("@PPIDNO", PPIDNO), _
            New SqlParameter("@PPBUSTYPE", PPBUSTYPE), _
            New SqlParameter("@PPBUSDATEB", PPBUSDATEB), _
            New SqlParameter("@PPTIMEB", PPTIMEB), _
            New SqlParameter("@PPUSERID", LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account)), _
            New SqlParameter("@PPUPDATE", DateTimeInfo.GetRocDateTime(Now)), _
            New SqlParameter("@PPREMARK_DATE", DateTimeInfo.GetRocDateTime(Now))}

            Return Execute(sql.ToString, params)
        End Function

        Public Function UpdateReMarkByGUID(ByVal PPGUID As String, ByVal PPREMARK As String) As Integer
            Dim sql As String = " Update FSC_CPAPP16M set PPREMARK=@PPREMARK where PPGUID=@PPGUID "

            Dim params(1) As SqlParameter
            params(0) = New SqlParameter("@PPGUID", SqlDbType.VarChar)
            params(0).Value = PPGUID
            params(1) = New SqlParameter("@PPREMARK", SqlDbType.VarChar)
            params(1).Value = PPREMARK

            Return Execute(sql, params)
        End Function

        Public Function InsertData(ByVal pp16m As CPAPP16M) As Integer
            Dim StrSQL As New StringBuilder
            StrSQL.Append("INSERT INTO FSC_CPAPP16M ")
            StrSQL.Append("     ( ")
            StrSQL.Append("     Orgcode, PPNAME, PPIDNO, PPCARD, PPBUSTYPE, PPBUSDATEB, PPTIMEB, PPBUSDATEE, PPTIMEE, PPBUSDH, PPHOLIDAY, PPBUSPLACE, ")
            StrSQL.Append("     PPREASON, PPHDAY, PPBEFOREM, PPREMARK, PPPAYH, PPGUID, PPUSERID, PPUPDATE, Depart_id) ")
            StrSQL.Append("VALUES ")
            StrSQL.Append("     ( ")
            StrSQL.Append("     @Orgcode, @PPNAME, @PPIDNO, @PPCARD, @PPBUSTYPE, @PPBUSDATEB, @PPTIMEB, @PPBUSDATEE, @PPTIMEE, @PPBUSDH, @PPHOLIDAY, @PPBUSPLACE, ")
            StrSQL.Append("     @PPREASON, @PPHDAY, @PPBEFOREM, @PPREMARK, @PPPAYH, @PPGUID, @PPUSERID, @PPUPDATE, @Depart_id) ")

            Dim params(20) As SqlParameter
            params(0) = New SqlParameter("@PPIDNO", SqlDbType.VarChar)
            params(0).Value = pp16m.PPIDNO
            params(1) = New SqlParameter("@PPNAME", SqlDbType.VarChar)
            params(1).Value = pp16m.PPNAME
            params(2) = New SqlParameter("@PPCARD", SqlDbType.VarChar)
            params(2).Value = pp16m.PPCARD
            params(3) = New SqlParameter("@PPBUSTYPE", SqlDbType.VarChar)
            params(3).Value = pp16m.PPBUSTYPE
            params(4) = New SqlParameter("@PPBUSDATEB", SqlDbType.VarChar)
            params(4).Value = pp16m.PPBUSDATEB
            params(5) = New SqlParameter("@PPBUSDATEE", SqlDbType.VarChar)
            params(5).Value = pp16m.PPBUSDATEE
            params(6) = New SqlParameter("@PPTIMEB", SqlDbType.VarChar)
            params(6).Value = pp16m.PPTIMEB
            params(7) = New SqlParameter("@PPTIMEE", SqlDbType.VarChar)
            params(7).Value = pp16m.PPTIMEE
            params(8) = New SqlParameter("@PPBUSDH", SqlDbType.Float)
            params(8).Value = pp16m.PPBUSDH
            params(9) = New SqlParameter("@PPHOLIDAY", SqlDbType.VarChar)
            params(9).Value = pp16m.PPHOLIDAY
            params(10) = New SqlParameter("@PPBUSPLACE", SqlDbType.VarChar)

            If (pp16m.PPBUSPLACE.Length > 15) Then
                params(10).Value = pp16m.PPBUSPLACE.Substring(0, 15)
            Else
                params(10).Value = pp16m.PPBUSPLACE
            End If

            params(11) = New SqlParameter("@PPREMARK", SqlDbType.VarChar)
            params(11).Value = pp16m.PPREMARK
            params(12) = New SqlParameter("@PPGUID", SqlDbType.VarChar)
            params(12).Value = pp16m.PPGUID
            params(13) = New SqlParameter("@PPUSERID", SqlDbType.VarChar)
            params(13).Value = pp16m.PPUSERID
            params(14) = New SqlParameter("@PPUPDATE", SqlDbType.VarChar)
            params(14).Value = pp16m.PPUPDATE
            params(15) = New SqlParameter("@PPREASON", SqlDbType.VarChar)
            params(15).Value = pp16m.PPREASON
            params(16) = New SqlParameter("@PPHDAY", SqlDbType.Float)
            params(16).Value = pp16m.PPHDAY
            params(17) = New SqlParameter("@PPBEFOREM", SqlDbType.VarChar)
            params(17).Value = pp16m.PPBEFOREM
            params(18) = New SqlParameter("@PPPAYH", SqlDbType.Float)
            params(18).Value = pp16m.PPPAYH
            params(19) = New SqlParameter("@Orgcode", SqlDbType.VarChar)
            params(19).Value = pp16m.Orgcode
            params(20) = New SqlParameter("@Depart_id", SqlDbType.VarChar)
            params(20).Value = pp16m.DepartId

            DBUtil.SetParamsNull(params)
            Return Execute(StrSQL.ToString(), params)
        End Function

        ''' <summary>
        ''' for修改重送使用 jessica add 20131220
        ''' </summary>
        ''' <param name="isP2K"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function UpdateCPAPP16M(ByVal pp16m As CPAPP16M, Optional ByVal isP2K As Boolean = False) As Integer
            Dim StrSQL As New StringBuilder
            StrSQL.Append("UPDATE FSC_CPAPP16M ")
            StrSQL.Append("     SET ")
            If Not isP2K Then
                StrSQL.Append(" Orgcode = @Orgcode, ")
            End If
            StrSQL.Append("     PPNAME = @PPNAME, PPIDNO=@PPIDNO, PPCARD=@PPCARD, PPBUSTYPE=@PPBUSTYPE, PPBUSDATEB = @PPBUSDATEB, ")
            StrSQL.Append("     PPTIMEB = @PPTIMEB, PPBUSDATEE = @PPBUSDATEE, PPTIMEE = @PPTIMEE, PPBUSDH = @PPBUSDH, PPHOLIDAY = @PPHOLIDAY, PPBUSPLACE = @PPBUSPLACE, ")
            StrSQL.Append("     PPREASON = @PPREASON, PPHDAY = @PPHDAY, PPBEFOREM = @PPBEFOREM, PPREMARK = @PPREMARK, PPPAYH = @PPPAYH , PPUSERID = @PPUSERID, PPUPDATE = @PPUPDATE ")
            StrSQL.Append("WHERE ")
            StrSQL.Append("     PPGUID = @PPGUID ")

            Dim params(19) As SqlParameter
            params(0) = New SqlParameter("@PPIDNO", SqlDbType.VarChar)
            params(0).Value = pp16m.PPIDNO
            params(1) = New SqlParameter("@PPNAME", SqlDbType.VarChar)
            params(1).Value = pp16m.PPNAME
            params(2) = New SqlParameter("@PPCARD", SqlDbType.VarChar)
            params(2).Value = pp16m.PPCARD
            params(3) = New SqlParameter("@PPBUSTYPE", SqlDbType.VarChar)
            params(3).Value = pp16m.PPBUSTYPE
            params(4) = New SqlParameter("@PPBUSDATEB", SqlDbType.VarChar)
            params(4).Value = pp16m.PPBUSDATEB
            params(5) = New SqlParameter("@PPBUSDATEE", SqlDbType.VarChar)
            params(5).Value = pp16m.PPBUSDATEE
            params(6) = New SqlParameter("@PPTIMEB", SqlDbType.VarChar)
            params(6).Value = pp16m.PPTIMEB
            params(7) = New SqlParameter("@PPTIMEE", SqlDbType.VarChar)
            params(7).Value = pp16m.PPTIMEE
            params(8) = New SqlParameter("@PPBUSDH", SqlDbType.Float)
            params(8).Value = pp16m.PPBUSDH
            params(9) = New SqlParameter("@PPHOLIDAY", SqlDbType.VarChar)
            params(9).Value = pp16m.PPHOLIDAY
            params(10) = New SqlParameter("@PPBUSPLACE", SqlDbType.VarChar)

            If (pp16m.PPBUSPLACE.Length > 15) Then
                params(10).Value = pp16m.PPBUSPLACE.Substring(0, 15)
            Else
                params(10).Value = pp16m.PPBUSPLACE
            End If

            params(11) = New SqlParameter("@PPREMARK", SqlDbType.VarChar)
            params(11).Value = pp16m.PPREMARK
            params(12) = New SqlParameter("@PPGUID", SqlDbType.VarChar)
            params(12).Value = pp16m.PPGUID
            params(13) = New SqlParameter("@PPUSERID", SqlDbType.VarChar)
            params(13).Value = pp16m.PPUSERID
            params(14) = New SqlParameter("@PPUPDATE", SqlDbType.VarChar)
            params(14).Value = (Now.Year - 1911).ToString.PadLeft(3, "0") & Now.ToString("MMddHHmmss")
            params(15) = New SqlParameter("@PPREASON", SqlDbType.VarChar)
            params(15).Value = pp16m.PPREASON
            params(16) = New SqlParameter("@PPHDAY", SqlDbType.Float)
            params(16).Value = pp16m.PPHDAY
            params(17) = New SqlParameter("@PPBEFOREM", SqlDbType.VarChar)
            params(17).Value = pp16m.PPBEFOREM
            params(18) = New SqlParameter("@PPPAYH", SqlDbType.Float)
            params(18).Value = pp16m.PPPAYH
            params(19) = New SqlParameter("@Orgcode", SqlDbType.VarChar)
            params(19).Value = pp16m.Orgcode

            DBUtil.SetParamsNull(params)
            Return Execute(StrSQL.ToString(), params)
        End Function


        Public Function GetDataByPpguid(ByVal flow_id As String) As DataTable
            Dim StrSQL As New StringBuilder

            StrSQL.Append(" SELECT *  FROM FSC_CPAPP16M WITH(NOLOCK) where ppguid=@flow_id ")

            Dim params() As SqlParameter = {New SqlParameter("@flow_id", flow_id)}

            Return Query(StrSQL.ToString, params)
        End Function

        Public Function DeleteDataByGUID(ByVal Flow_id As String, ByVal Orgcode As String) As Integer
            Dim sql As New StringBuilder
            sql.Append("DELETE FROM FSC_CPAPP16M WHERE PPGUID=@Flow_id")
            If Not String.IsNullOrEmpty(Orgcode) Then
                sql.Append(" and Orgcode=@Orgcode ")
            End If
            Dim params() As SqlParameter = { _
            New SqlParameter("@Flow_id", SqlDbType.VarChar), _
            New SqlParameter("@Orgcode", SqlDbType.VarChar)}
            params(0).Value = Flow_id
            params(1).Value = Orgcode
            DBUtil.SetParamsNull(params)
            Return Scalar(sql.ToString(), params)
        End Function


        Public Function GetDataByPK(ByVal PPIDNO As String, ByVal PPBUSTYPE As String, ByVal PPBUSDATEB As String, ByVal PPTIMEB As String, ByVal PPREMARK As String) As DataTable
            Dim sql As New StringBuilder
            sql.AppendLine(" select * from FSC_CPAPP16M WITH(NOLOCK) ")
            sql.AppendLine(" where ")
            sql.AppendLine(" ppidno=@ppidno ")
            sql.AppendLine(" and ppbustype=@ppbustype ")
            sql.AppendLine(" and ppbusdateb=@ppbusdateb ")
            If Not String.IsNullOrEmpty(PPTIMEB) Then
                sql.AppendLine(" and pptimeb=@pptimeb ")
            End If

            If PPREMARK.ToString.Equals("1") Then
                sql.AppendLine(" and ppremark='1' ")
                'Else
                '    sql.AppendLine(" and ppremark<>'1' ")
            End If

            Dim params() As SqlParameter = { _
            New SqlParameter("@ppidno", SqlDbType.VarChar), _
            New SqlParameter("@ppbustype", SqlDbType.VarChar), _
            New SqlParameter("@ppbusdateb", SqlDbType.VarChar), _
            New SqlParameter("@pptimeb", SqlDbType.VarChar)}
            params(0).Value = PPIDNO
            params(1).Value = PPBUSTYPE
            params(2).Value = PPBUSDATEB
            params(3).Value = PPTIMEB
            Return Query(sql.ToString(), params)
        End Function

        Public Function UpdatePPPAYH(ByVal PPPAYH As Integer, ByVal PPIDNO As String, ByVal PPBUSTYPE As String, ByVal PPBUSDATEB As String, ByVal PPTIMEB As String) As Integer
            Dim sql As New StringBuilder
            sql.AppendLine(" update FSC_CPAPP16M ")
            sql.AppendLine(" set ")
            sql.AppendLine(" pppayh=ISNULL(pppayh,0)+@pppayh ")
            sql.AppendLine(" ,ppuserid=@ppuserid ")
            sql.AppendLine(" ,ppupdate=@ppupdate ")
            sql.AppendLine(" where ")
            sql.AppendLine(" ppidno=@ppidno and ppbustype=@ppbustype and ppbusdateb=@ppbusdateb and pptimeb=@pptimeb ")

            Dim params() As SqlParameter = { _
            New SqlParameter("@pppayh", SqlDbType.Int), _
            New SqlParameter("@ppidno", SqlDbType.VarChar), _
            New SqlParameter("@ppbustype", SqlDbType.VarChar), _
            New SqlParameter("@ppbusdateb", SqlDbType.VarChar), _
            New SqlParameter("@pptimeb", SqlDbType.VarChar), _
            New SqlParameter("@ppuserid", SqlDbType.VarChar), _
            New SqlParameter("@ppupdate", SqlDbType.VarChar)}
            params(0).Value = PPPAYH
            params(1).Value = PPIDNO
            params(2).Value = PPBUSTYPE
            params(3).Value = PPBUSDATEB
            params(4).Value = PPTIMEB
            params(5).Value = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account)
            params(6).Value = DateTimeInfo.GetRocDateTime(Now)

            Return Execute(sql.ToString(), params)
        End Function

        Public Function UpdateFlag(ByVal PPGUID As String, ByVal STATUS As String) As Integer
            Dim sql As New StringBuilder
            sql.AppendLine(" update FSC_CPAPP16M ")
            sql.AppendLine(" set ")
            sql.AppendLine(" status=@status ")
            sql.AppendLine(" ,ppuserid=@ppuserid ")
            sql.AppendLine(" ,ppupdate=@ppupdate ")
            sql.AppendLine(" where ppguid=@ppguid ")

            Dim params() As SqlParameter = { _
            New SqlParameter("@status", SqlDbType.VarChar), _
            New SqlParameter("@ppguid", SqlDbType.VarChar), _
            New SqlParameter("@ppuserid", SqlDbType.VarChar), _
            New SqlParameter("@ppupdate", SqlDbType.VarChar)}
            params(0).Value = STATUS
            params(1).Value = PPGUID
            params(2).Value = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account)
            params(3).Value = DateTimeInfo.GetRocDateTime(Now)
            Return Execute(sql.ToString(), params)
        End Function

        Public Function GetDataByOfficialFee(ByVal PPIDNO As String, ByVal PPBUSTYPE As String, ByVal PPGUID As String) As DataTable
            Dim sql As New StringBuilder
            sql.AppendLine(" select FSC_CPAPP16M.*, '' as peorg, '' as peunit, p.title_no as petit")
            sql.AppendLine("    from FSC_CPAPP16M WITH(NOLOCK) ")
            sql.AppendLine("    inner join FSC_Personnel p WITH(NOLOCK) on ppidno=p.id_card ")
            sql.AppendLine(" where ")
            sql.AppendLine(" ppidno=@ppidno ")
            sql.AppendLine(" and ppbustype=@ppbustype ")
            sql.AppendLine(" and ppguid=@ppguid")

            Dim params() As SqlParameter = { _
            New SqlParameter("@ppidno", SqlDbType.VarChar), _
            New SqlParameter("@ppbustype", SqlDbType.VarChar), _
            New SqlParameter("@ppguid", SqlDbType.VarChar)}
            params(0).Value = PPIDNO
            params(1).Value = PPBUSTYPE
            params(2).Value = PPGUID
            DBUtil.SetParamsNull(params)
            Return Query(sql.ToString(), params)
        End Function
    End Class
End Namespace
