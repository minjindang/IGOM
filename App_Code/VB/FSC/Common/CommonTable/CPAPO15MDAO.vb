Imports Microsoft.VisualBasic
Imports System.Data
Imports Pemis2009.SQLAdapter
Imports System.Data.SqlClient
Imports System.Text
Imports System

Namespace FSC.Logic
    Public Class CPAPO15MDAO
        Inherits BaseDAO

        Public Function GetAllYearData(ByVal POIDNO As String, ByVal YYY As String) As DataTable
            Dim sql As New StringBuilder()

            sql.AppendLine(" select *  ")
            sql.AppendLine(" FROM FSC_CPAPO15M a ")
            sql.AppendLine(" where POIDNO=@POIDNO and substring(POVDATEB,1,3)=@YYY ")

            Dim params() As SqlParameter = { _
            New SqlParameter("@POIDNO", POIDNO), _
            New SqlParameter("@YYY", YYY)}
            Return Query(sql.ToString, params)
        End Function

        Public Function GetData(ByVal GUID As String) As DataTable
            Dim StrSQL As New StringBuilder()
            StrSQL.Append(" select * ")
            StrSQL.Append(" FROM FSC_CPAPO15M WITH(NOLOCK) where ")
            If Not GUID Is Nothing And "" <> GUID Then
                StrSQL.Append(" POGUID=@GUID and ")
            End If
            StrSQL.Append(" 1=1 ORDER BY POVDATEB ")
            Dim params() As SqlParameter = { _
            New SqlParameter("@GUID", GUID)}
            Return Query(StrSQL.ToString, params)
        End Function

        Function getData(ByVal idno As String, ByVal Startdate As String, ByVal Enddate As String) As DataTable
            Dim sSQL As New StringBuilder()
            sSQL.Append(" select * ")
            sSQL.Append(" FROM FSC_CPAPO15M WITH(NOLOCK) ")
            sSQL.Append(" where 1 = 1 ")

            If Not idno Is Nothing And "" <> idno Then
                sSQL.Append(" And poidno=@IdNo ")
            End If
            If Not Startdate Is Nothing And "" <> Startdate Then
                sSQL.Append(" and povdateb >= @StartDate  ")
            End If
            If Not Enddate Is Nothing And "" <> Enddate Then
                sSQL.Append(" and povdateb<=@EndDate ")
            End If
            sSQL.Append(" ORDER BY poname,povdateb ")

            Dim params() As SqlParameter = { _
            New SqlParameter("@StartDate", Startdate), _
            New SqlParameter("@EndDate", Enddate), _
            New SqlParameter("@IdNo", idno)}
            Return Query(sSQL.ToString, params)
        End Function


        Public Function GetDataByFlow_id(ByVal Flow_id As String, ByVal Orgcode As String) As DataTable
            Dim StrSQL As New StringBuilder
            StrSQL.Append("SELECT * FROM FSC_CPAPO15M WITH(NOLOCK) WHERE POGUID=@Flow_id ")
            If Not String.IsNullOrEmpty(Orgcode) Then
                StrSQL.AppendLine(" and Orgcode=@Orgcode ")
            End If

            Dim params() As SqlParameter = { _
            New SqlParameter("@Flow_id", SqlDbType.VarChar), _
            New SqlParameter("@Orgcode", SqlDbType.VarChar)}
            params(0).Value = Flow_id
            params(1).Value = Orgcode
            DBUtil.SetParamsNull(params)

            Return Query(StrSQL.ToString(), params)
        End Function

        Public Function GetDataByYM(ByVal POIDNO As String, ByVal POVTYPE As String, ByVal YEARMONTH As String, Optional ByVal isP2k As Boolean = False) As DataTable
            Dim StrSQL As New StringBuilder
            StrSQL.Append("SELECT * FROM FSC_CPAPO15M WITH(NOLOCK) ")

            If Not isP2k Then StrSQL.AppendLine(" left outer join PLMDBP_NUK.dbo.flow on poguid=flow_id ")

            StrSQL.Append("     WHERE POIDNO=@POIDNO AND POVTYPE=@POVTYPE AND POVDATEB like @YEARMONTH+'%' ")

            If Not isP2k Then StrSQL.AppendLine(" and Last_pass='0' ") '查plm時, 需判斷是否已是結束的flow

            Dim params(2) As SqlParameter
            params(0) = New SqlParameter("@POIDNO", SqlDbType.VarChar)
            params(0).Value = POIDNO
            params(1) = New SqlParameter("@POVTYPE", SqlDbType.VarChar)
            params(1).Value = POVTYPE
            params(2) = New SqlParameter("@YEARMONTH", SqlDbType.VarChar)
            params(2).Value = YEARMONTH


            Return Query(StrSQL.ToString(), params)
        End Function


        Public Function GetDataByPOTDATE(ByVal POIDNO As String, ByVal POVTYPE As String, _
                                        Optional ByVal POTDATE As String = Nothing, Optional ByVal YEARMONTH As String = Nothing, _
                                        Optional ByVal isP2k As Boolean = False) As DataTable
            Dim StrSQL As New StringBuilder
            StrSQL.Append("SELECT * FROM FSC_CPAPO15M WITH(NOLOCK) ")

            If Not isP2k Then
                StrSQL.AppendLine(" left outer join PLMDBP_NUK.dbo.flow on poguid=flow_id ")
            End If

            StrSQL.Append("     WHERE POIDNO=@POIDNO AND POVTYPE=@POVTYPE ")

            If Not String.IsNullOrEmpty(POTDATE) Then
                StrSQL.Append(" AND POTDATE=@POTDATE ")
            End If
            If Not String.IsNullOrEmpty(YEARMONTH) Then
                StrSQL.Append(" AND POTDATE like @YEARMONTH+'%' ")
            End If

            If Not isP2k Then
                StrSQL.AppendLine(" and Last_pass='0' ") '查plm時, 需判斷是否已是結束的flow
            End If

            Dim params(3) As SqlParameter
            params(0) = New SqlParameter("@POIDNO", SqlDbType.VarChar)
            params(0).Value = POIDNO
            params(1) = New SqlParameter("@POVTYPE", SqlDbType.VarChar)
            params(1).Value = POVTYPE
            params(2) = New SqlParameter("@POTDATE", SqlDbType.VarChar)
            params(2).Value = POTDATE
            params(3) = New SqlParameter("@YEARMONTH", SqlDbType.VarChar)
            params(3).Value = YEARMONTH

            Return Query(StrSQL.ToString(), params)
        End Function

        Public Function GetDataByDateTime(ByVal Start_datetime As String, ByVal End_datetime As String, ByVal Apply_id As String, ByVal isP2K As Boolean) As DataTable
            Dim sql As New StringBuilder

            sql.AppendLine(" select poidno as idno, povdateb as dateb, povtimeb as timeb, povdatee as datee, povtimee as timee ")
            sql.AppendLine(" FROM FSC_CPAPO15M WITH(NOLOCK) ")

            If Not isP2K Then sql.AppendLine("left outer join PLMDBP_NUK.dbo.flow on poguid=flow_id ")

            sql.AppendLine("     where ((@Start_datetime > povdateb+povtimeb and @Start_datetime < povdatee+povtimee) ")
            sql.AppendLine("             or (@End_datetime > povdateb+povtimeb and @End_datetime < povdatee+povtimee) ")
            sql.AppendLine("             or (SUBSTRING(@Start_datetime,1,7)=povdateb and SUBSTRING(@End_datetime,1,7)=povdatee and SUBSTRING(@Start_datetime,8,4) < povtimeb and SUBSTRING(@End_datetime,8,4) > povtimee) ")
            sql.AppendLine("             or @Start_datetime = povdateb+povtimeb or @End_datetime = povdatee+povtimee ")
            sql.AppendLine("             ) and poidno=@Apply_id ")

            If Not isP2K Then sql.AppendLine("     and Last_pass='0' ") '查plm 時, 需判斷是否已是結束的flow

            sql.AppendLine(" union ")

            sql.AppendLine(" select ppidno as idno, ppbusdateb as dateb, pptimeb as timeb, ppbusdatee as datee, pptimee as timee ")
            sql.AppendLine(" from cpapp16m WITH(NOLOCK) ")

            If Not isP2K Then sql.AppendLine("left outer join PLMDBP_NUK.dbo.flow on ppguid=flow_id ")

            sql.AppendLine("     where ((@Start_datetime > PPBUSDATEB+PPTIMEB and @Start_datetime < PPBUSDATEE+PPTIMEE) ")
            sql.AppendLine("             or (@End_datetime > PPBUSDATEB+PPTIMEB and @End_datetime < PPBUSDATEE+PPTIMEE) ")
            sql.AppendLine("             or (SUBSTRING(@Start_datetime,1,7)=PPBUSDATEB and SUBSTRING(@End_datetime,1,7)=PPBUSDATEE and  SUBSTRING(@Start_datetime,8,4) < PPTIMEB and SUBSTRING(@End_datetime,8,4) > PPTIMEE) ")
            sql.AppendLine("             or @Start_datetime = PPBUSDATEB+PPTIMEB or @End_datetime = PPBUSDATEE+PPTIMEE ")
            sql.AppendLine("             ) and ppidno=@Apply_id ")

            If Not isP2K Then sql.AppendLine("     and Last_pass='0' ") '查plm 時, 需判斷是否已是結束的flow

            Dim params(2) As SqlParameter
            params(0) = New SqlParameter("@Start_datetime", SqlDbType.VarChar)
            params(0).Value = Start_datetime
            params(1) = New SqlParameter("@End_datetime", SqlDbType.VarChar)
            params(1).Value = End_datetime
            params(2) = New SqlParameter("@Apply_id", SqlDbType.VarChar)
            params(2).Value = Apply_id

            Return Query(sql.ToString(), params)
        End Function

        Public Function GetDataByDate(ByVal sdate As String, ByVal Apply_id As String, ByVal isP2K As Boolean) As DataTable
            Dim sql As New StringBuilder

            sql.AppendLine(" select poidno as idno, povdateb as dateb, povtimeb as timeb, povdatee as datee, povtimee as timee ")
            sql.AppendLine(" FROM FSC_CPAPO15M WITH(NOLOCK) ")

            If Not isP2K Then sql.AppendLine("left outer join PLMDBP_NUK.dbo.flow on poguid=flow_id ")

            sql.AppendLine("     where ((povdateb=@sdate and povdatee>=@sdate) or (povdateb<=@sdate and povdatee=@sdate)) ")
            sql.AppendLine("            and poidno=@Apply_id ")

            If Not isP2K Then sql.AppendLine("     and Last_pass='0' ") '查plm 時, 需判斷是否已是結束的flow

            sql.AppendLine(" union ")

            sql.AppendLine(" select ppidno as idno, ppbusdateb as dateb, pptimeb as timeb, ppbusdatee as datee, pptimee as timee ")
            sql.AppendLine(" from cpapp16m WITH(NOLOCK) ")

            If Not isP2K Then sql.AppendLine("left outer join PLMDBP_NUK.dbo.flow on ppguid=flow_id ")

            sql.AppendLine("     where ((PPBUSDATEB=@sdate and PPBUSDATEE>=@sdate) or (PPBUSDATEB<=@sdate and PPBUSDATEE=@sdate)) ")
            sql.AppendLine("            and ppidno=@Apply_id ")

            If Not isP2K Then sql.AppendLine("     and Last_pass='0' ") '查plm 時, 需判斷是否已是結束的flow

            Dim params(1) As SqlParameter
            params(0) = New SqlParameter("@sdate", SqlDbType.VarChar)
            params(0).Value = sdate
            params(1) = New SqlParameter("@Apply_id", SqlDbType.VarChar)
            params(1).Value = Apply_id

            Return Query(sql.ToString(), params)
        End Function

        Public Function InsertData(ByVal po15m As CPAPO15M) As Integer
            Dim StrSQL As New StringBuilder
            StrSQL.Append("INSERT INTO FSC_CPAPO15M ( ")
            StrSQL.Append("     POIDNO, PONAME, POCARD, POVTYPE, POVDATEB, POVDATEE, POVTIMEB, POVTIMEE, ")
            StrSQL.Append("     POVDAYS, POHOLIDAY, POTDATE, POREMARK, POGUID, POUSERID, POUPDATE, Orgcode, Depart_id) ")
            StrSQL.Append("VALUES ( ")
            StrSQL.Append("     @POIDNO, @PONAME, @POCARD, @POVTYPE, @POVDATEB, @POVDATEE, @POVTIMEB, @POVTIMEE, ")
            StrSQL.Append("     @POVDAYS, @POHOLIDAY, @POTDATE, @POREMARK, @POGUID, @POUSERID, @POUPDATE, @Orgcode, @Depart_id)")

            Dim params(16) As SqlParameter
            params(0) = New SqlParameter("@POIDNO", SqlDbType.VarChar)
            params(0).Value = po15m.POIDNO
            params(1) = New SqlParameter("@PONAME", SqlDbType.VarChar)
            params(1).Value = po15m.PONAME
            params(2) = New SqlParameter("@POCARD", SqlDbType.VarChar)
            params(2).Value = po15m.POCARD
            params(3) = New SqlParameter("@POVTYPE", SqlDbType.VarChar)
            params(3).Value = po15m.POVTYPE
            params(4) = New SqlParameter("@POVDATEB", SqlDbType.VarChar)
            params(4).Value = po15m.POVDATEB
            params(5) = New SqlParameter("@POVDATEE", SqlDbType.VarChar)
            params(5).Value = po15m.POVDATEE
            params(6) = New SqlParameter("@POVTIMEB", SqlDbType.VarChar)
            params(6).Value = po15m.POVTIMEB
            params(7) = New SqlParameter("@POVTIMEE", SqlDbType.VarChar)
            params(7).Value = po15m.POVTIMEE
            params(8) = New SqlParameter("@POVDAYS", SqlDbType.Float)
            params(8).Value = po15m.POVDAYS
            params(9) = New SqlParameter("@POHOLIDAY", SqlDbType.VarChar)
            params(9).Value = po15m.POHOLIDAY
            params(10) = New SqlParameter("@POTDATE", SqlDbType.VarChar)
            params(10).Value = po15m.POTDATE
            params(11) = New SqlParameter("@POREMARK", SqlDbType.VarChar)
            params(11).Value = po15m.POREMARK
            params(12) = New SqlParameter("@POGUID", SqlDbType.VarChar)
            params(12).Value = po15m.POGUID
            params(13) = New SqlParameter("@POUSERID", SqlDbType.VarChar)
            params(13).Value = po15m.POUSERID
            params(14) = New SqlParameter("@POUPDATE", SqlDbType.VarChar)
            params(14).Value = po15m.POUPDATE
            params(15) = New SqlParameter("@Orgcode", SqlDbType.VarChar)
            params(15).Value = po15m.Orgcode
            params(16) = New SqlParameter("@Depart_id", SqlDbType.VarChar)
            params(16).Value = po15m.DepartId

            Return Execute(StrSQL.ToString(), params)
        End Function

        ''' <summary>
        ''' for修改重送 jessica add
        ''' </summary>
        ''' <param name="isP2K"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function UpdateCPAPO15M(ByVal po15m As CPAPO15M, Optional ByVal isP2K As Boolean = False) As Boolean
            Dim StrSQL As New StringBuilder
            StrSQL.Append("UPDATE CPAPO15M set")
            If Not isP2K Then
                StrSQL.Append(" Orgcode = @Orgcode, ")
            End If
            StrSQL.Append("     POIDNO = @POIDNO, PONAME = @PONAME, POCARD = @POCARD, POVTYPE = @POVTYPE, POVDATEB = @POVDATEB, ")
            StrSQL.Append("     POVDATEE = @POVDATEE, POVTIMEB = @POVTIMEB, POVTIMEE = @POVTIMEE, POVDAYS = @POVDAYS, POHOLIDAY = @POHOLIDAY, ")
            StrSQL.Append("     POTDATE = @POTDATE, POREMARK = @POREMARK, Change_Userid =@Change_Userid, Change_date =  @Change_date ")
            StrSQL.Append("WHERE  ")
            StrSQL.Append("     POGUID= @POGUID")

            Dim params(15) As SqlParameter
            params(0) = New SqlParameter("@POIDNO", SqlDbType.VarChar)
            params(0).Value = po15m.POIDNO
            params(1) = New SqlParameter("@PONAME", SqlDbType.VarChar)
            params(1).Value = po15m.PONAME
            params(2) = New SqlParameter("@POCARD", SqlDbType.VarChar)
            params(2).Value = po15m.POCARD
            params(3) = New SqlParameter("@POVTYPE", SqlDbType.VarChar)
            params(3).Value = po15m.POVTYPE
            params(4) = New SqlParameter("@POVDATEB", SqlDbType.VarChar)
            params(4).Value = po15m.POVDATEB
            params(5) = New SqlParameter("@POVDATEE", SqlDbType.VarChar)
            params(5).Value = po15m.POVDATEE
            params(6) = New SqlParameter("@POVTIMEB", SqlDbType.VarChar)
            params(6).Value = po15m.POVTIMEB
            params(7) = New SqlParameter("@POVTIMEE", SqlDbType.VarChar)
            params(7).Value = po15m.POVTIMEE
            params(8) = New SqlParameter("@POVDAYS", SqlDbType.Float)
            params(8).Value = po15m.POVDAYS
            params(9) = New SqlParameter("@POHOLIDAY", SqlDbType.VarChar)
            params(9).Value = po15m.POHOLIDAY
            params(10) = New SqlParameter("@POTDATE", SqlDbType.VarChar)
            params(10).Value = po15m.POTDATE
            params(11) = New SqlParameter("@POREMARK", SqlDbType.VarChar)
            params(11).Value = po15m.POREMARK
            params(12) = New SqlParameter("@POGUID", SqlDbType.VarChar)
            params(12).Value = po15m.POGUID
            params(13) = New SqlParameter("@Change_Userid", SqlDbType.VarChar)
            params(13).Value = po15m.POUSERID
            params(14) = New SqlParameter("@Change_date", SqlDbType.DateTime)
            params(14).Value = Now
            params(15) = New SqlParameter("@Orgcode", SqlDbType.VarChar)
            params(15).Value = po15m.Orgcode

            Return Execute(StrSQL.ToString, params)
        End Function

        '人立新增0710 for FSC3104_01
        Public Function GetDataByPoguid(ByVal flow_id As String) As DataTable
            Dim StrSQL As New StringBuilder
            StrSQL.Append("SELECT poguid,poremark FROM FSC_CPAPO15M WITH(NOLOCK) where poguid=@flow_id ")
            Dim params() As SqlParameter = {New SqlParameter("@flow_id", flow_id)}
            Return Query(StrSQL.ToString, params)
        End Function

        Public Function DeleteDataByGUID(ByVal flow_id As String, ByVal Orgcode As String) As Integer
            Dim sql As New StringBuilder
            sql.Append("DELETE FROM FSC_CPAPO15M WHERE POGUID=@POGUID ")
            If Not String.IsNullOrEmpty(Orgcode) Then
                sql.Append(" and Orgcode=@Orgcode ")
            End If
            Dim params() As SqlParameter = { _
            New SqlParameter("@POGUID", SqlDbType.VarChar), _
            New SqlParameter("@Orgcode", SqlDbType.VarChar)}
            params(0).Value = flow_id
            params(1).Value = Orgcode
            DBUtil.SetParamsNull(params)
            Return Execute(sql.ToString(), params)
        End Function

        Public Function UpdateFlag(ByVal POGUID As String, ByVal STATUS As String) As Integer
            Dim sql As New StringBuilder
            sql.AppendLine(" update cpapo15m ")
            sql.AppendLine(" set status=@status ")
            sql.AppendLine(" where poguid=@poguid ")

            Dim params() As SqlParameter = { _
            New SqlParameter("@status", SqlDbType.VarChar), _
            New SqlParameter("@poguid", SqlDbType.VarChar)}
            params(0).Value = STATUS
            params(1).Value = POGUID
            Return Execute(sql.ToString(), params)
        End Function

        Public Function GetLeaveData(ByVal POIDNO As String, ByVal VDATE As String) As DataTable
            Dim sql As New StringBuilder
            sql.AppendLine("select po.*, co.descr FROM FSC_CPAPO15M po WITH(NOLOCK) ")
            sql.AppendLine("    inner join code5 co on po.povtype=co.code and co.item='LEA' ")
            sql.AppendLine("where poidno=@poidno and povdateb<=@date and povdatee>=@date ")
            Dim params() As SqlParameter = { _
            New SqlParameter("@poidno", SqlDbType.VarChar), _
            New SqlParameter("@date", SqlDbType.VarChar)}
            params(0).Value = POIDNO
            params(1).Value = VDATE

            Return Query(sql.ToString(), params)
        End Function

        Public Function GetDataByPK(ByVal POIDNO As String, ByVal POVTYPE As String, ByVal POVDATEB As String, ByVal POVTIMEB As String) As DataTable
            Dim sql As New StringBuilder
            sql.AppendLine(" select cpapo15m.*, cpape05m.peorg, cpape05m.peunit, cpape05m.petit ")
            sql.AppendLine("    FROM FSC_CPAPO15M WITH(NOLOCK) ")
            sql.AppendLine("    inner join cpape05m WITH(NOLOCK) on poidno=peidno ")
            sql.AppendLine(" where ")
            sql.AppendLine(" poidno=@poidno ")
            sql.AppendLine(" and povtype=@povtype ")
            sql.AppendLine(" and povdateb=@povdateb ")
            sql.AppendLine(" and povtimeb=@povtimeb ")

            Dim params() As SqlParameter = { _
            New SqlParameter("@poidno", SqlDbType.VarChar), _
            New SqlParameter("@povtype", SqlDbType.VarChar), _
            New SqlParameter("@povdateb", SqlDbType.VarChar), _
            New SqlParameter("@povtimeb", SqlDbType.VarChar)}
            params(0).Value = POIDNO
            params(1).Value = POVTYPE
            params(2).Value = POVDATEB
            params(3).Value = POVTIMEB
            Return Query(sql.ToString(), params)
        End Function

    End Class
End Namespace
