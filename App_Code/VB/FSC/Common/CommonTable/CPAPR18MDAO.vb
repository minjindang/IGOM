Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports Pemis2009.SQLAdapter
Imports System.Text

Namespace FSC.Logic
    Public Class CPAPR18MDAO
        Inherits BaseDAO

        Public StartDate As String = ""
        Public EndDate As String = ""
        Public IdNo As String = ""

        Dim Connection As SqlConnection
        Dim ConnectionString As String = String.Empty

        Public Sub New()
            MyBase.New(ConnectDB.GetDBString())
            Me.ConnectionString = ConnectDB.GetDBString()
        End Sub

        Public Sub New(ByVal conn As String)
            MyBase.New(conn)
            Me.ConnectionString = conn
        End Sub

        Public Sub New(ByVal conn As SqlConnection)
            MyBase.New(conn)
            Me.Connection = conn
        End Sub

        Function getData() As DataTable
            Dim sSQL As New StringBuilder()
            sSQL.Append(" select * ")
            sSQL.Append(" FROM FSC_CPAPR18M WITH(NOLOCK) ")
            sSQL.Append(" where 1 = 1 ")

            If Not IdNo Is Nothing And "" <> IdNo Then
                sSQL.Append(" And pridno=@IdNo ")
            End If
            If Not StartDate Is Nothing And "" <> StartDate Then
                sSQL.Append(" and praddd >= @StartDate  ")
            End If
            If Not EndDate Is Nothing And "" <> EndDate Then
                sSQL.Append(" and praddd <=@EndDate ")
            End If
            sSQL.Append(" ORDER BY praddd ")
            Dim params() As SqlParameter = {New SqlParameter("@StartDate", StartDate), New SqlParameter("@EndDate", EndDate), New SqlParameter("@IdNo", IdNo)}
            Return Query(sSQL.ToString, params)
        End Function


        Sub ClearProperty()
            StartDate = ""
            EndDate = ""
            IdNo = ""
        End Sub

        Public Function GetDataByPK(ByVal PRIDNO As String, ByVal PRADDD As String, ByVal PRSTIME As String) As DataSet
            Dim StrSQL As String = String.Empty
            StrSQL = "SELECT * FROM FSC_CPAPR18M WITH(NOLOCK) where PRIDNO=@PRIDNO and PRADDD=@PRADDD and PRSTIME=@PRSTIME"
            Dim params() As SqlParameter = { _
            New SqlParameter("@PRIDNO", SqlDbType.VarChar), _
            New SqlParameter("@PRADDD", SqlDbType.VarChar), _
            New SqlParameter("@PRSTIME", SqlDbType.VarChar)}
            params(0).Value = PRIDNO
            params(1).Value = PRADDD
            params(2).Value = PRSTIME
            Return SqlAccessHelper.ExecuteDataset(ConnectionString, CommandType.Text, StrSQL, params)
        End Function

        Public Function GetSumPrpayfee(ByVal PRIDNO As String, ByVal PRADDD As String) As Object
            Dim StrSQL As String = String.Empty
            StrSQL = "Select Sum(prpayfee) FROM FSC_CPAPR18M WITH(NOLOCK) where PRIDNO=@PRIDNO AND PRADDD like @PRADDD+'%'"
            Dim params() As SqlParameter = { _
            New SqlParameter("@PRIDNO", SqlDbType.VarChar), _
            New SqlParameter("@PRADDD", SqlDbType.VarChar)}
            params(0).Value = PRIDNO
            params(1).Value = PRADDD
            Return SqlAccessHelper.ExecuteScalar(ConnectionString, CommandType.Text, StrSQL, params)
        End Function

        Public Function GetSumData(ByVal PRIDNO As String, ByVal PRADDD As String, ByVal PRATYPE As String) As DataSet
            Dim StrSQL As String = String.Empty
            StrSQL = "  Select Sum(praddh) as praddh, Sum(prpayh) as prpayh, Sum(prmnyh) as prmnyh "
            StrSQL &= " FROM FSC_CPAPR18M WITH(NOLOCK) where PRIDNO=@PRIDNO AND PRADDD like @PRADDD+'%' "

            If Not String.IsNullOrEmpty(PRATYPE) Then
                StrSQL &= " AND PRATYPE=@PRATYPE "
            End If

            Dim params() As SqlParameter = { _
            New SqlParameter("@PRIDNO", SqlDbType.VarChar), _
            New SqlParameter("@PRADDD", SqlDbType.VarChar), _
            New SqlParameter("@PRATYPE", SqlDbType.VarChar)}
            params(0).Value = PRIDNO
            params(1).Value = PRADDD
            params(2).Value = PRATYPE

            DBUtil.SetParamsNull(params)
            Return SqlAccessHelper.ExecuteDataset(ConnectionString, CommandType.Text, StrSQL, params)
        End Function

        Public Function GetSumPrpayfee(ByVal PRIDNO As String, ByVal PRADDD1 As String, ByVal PRADDD2 As String) As Object
            Dim StrSQL As String = String.Empty
            StrSQL = "Select Sum(prpayfee) FROM FSC_CPAPR18M WITH(NOLOCK) where PRIDNO=@PRIDNO AND PRADDD<=@PRADDD1 AND PRADDD>=@PRADDD2"
            Dim params() As SqlParameter = { _
            New SqlParameter("@PRIDNO", SqlDbType.VarChar), _
            New SqlParameter("@PRADDD1", SqlDbType.VarChar), _
            New SqlParameter("@PRADDD2", SqlDbType.VarChar)}
            params(0).Value = PRIDNO
            params(1).Value = PRADDD1
            params(2).Value = PRADDD2
            Return SqlAccessHelper.ExecuteScalar(ConnectionString, CommandType.Text, StrSQL, params)
        End Function

        Public Function GetData(ByVal PRIDNO As String, ByVal ym As String, ByVal ymd As String) As DataSet
            Dim StrSQL As String = String.Empty
            StrSQL = "SELECT * FROM FSC_CPAPR18M WITH(NOLOCK) where PRIDNO = @PRIDNO and PRADDD like @ym+'%' and PRADDH > 0 AND PRADDD < @ymd ORDER BY PRADDD, PRSTIME"

            Dim params() As SqlParameter = {New SqlParameter("@PRIDNO", SqlDbType.VarChar), _
                                            New SqlParameter("@ym", SqlDbType.VarChar), _
                                            New SqlParameter("@ymd", SqlDbType.VarChar)}
            params(0).Value = PRIDNO
            params(1).Value = ym
            params(2).Value = ymd

            Return SqlAccessHelper.ExecuteDataset(ConnectionString, CommandType.Text, StrSQL, params)
        End Function

        Public Function GetSUNPRADDHByYMD(ByVal PRCARD As String, ByVal ymd As String, ByVal PRATYPE As String) As Object
            Dim StrSQL As String = String.Empty
            StrSQL = "SELECT SUM(PRADDH) FROM FSC_CPAPR18M WITH(NOLOCK) where PRCARD = @PRCARD and PRADDD=@ymd and PRADDH > 0 and PRATYPE=@PRATYPE "

            Dim params() As SqlParameter = {New SqlParameter("@PRCARD", SqlDbType.VarChar), _
                                            New SqlParameter("@ymd", SqlDbType.VarChar), New SqlParameter("@PRATYPE", SqlDbType.VarChar)}
            params(0).Value = PRCARD
            params(1).Value = ymd
            params(2).Value = PRATYPE
            Return SqlAccessHelper.ExecuteScalar(ConnectionString, CommandType.Text, StrSQL, params)
        End Function

        Public Function GetDataByYM(ByVal PRCARD As String, ByVal ym As String, ByVal PRATYPE As String, ByVal isP2K As Boolean) As DataTable
            Dim sql As New StringBuilder()

            sql.AppendLine(" SELECT * FROM FSC_CPAPR18M ")
            If Not isP2K Then
                sql.AppendLine(" left outer join flow on prguid=flow_id ")
            End If
            sql.AppendLine(" where PRCARD = @PRCARD and PRADDD like @ym+'%' and PRADDH > 0 and PRATYPE=@PRATYPE")
            If Not isP2K Then
                sql.AppendLine("    and PRUSERID<>'import' ")
                sql.AppendLine("     and (case_status='0' or case_status='1') and (cancel_flag<>'Y' or cancel_flag is null) ") '查plm 時, 除取消及不同意
            End If

            Dim params() As SqlParameter = { _
            New SqlParameter("@PRCARD", SqlDbType.VarChar), _
            New SqlParameter("@ym", SqlDbType.VarChar), _
            New SqlParameter("@PRATYPE", SqlDbType.VarChar)}
            params(0).Value = PRCARD
            params(1).Value = ym
            params(2).Value = PRATYPE

            Return Query(sql.ToString(), params)
        End Function


        Public Function GetDataByYM(ByVal PRCARD As String, ByVal ym As String, ByVal PRATYPE As String, ByVal PRMEMO As String, ByVal isP2K As Boolean) As DataTable
            Dim sql As New StringBuilder()

            sql.AppendLine(" SELECT * FROM FSC_CPAPR18M ")
            If Not isP2K Then
                sql.AppendLine(" left outer join flow on prguid=flow_id ")
            End If
            sql.AppendLine(" where PRCARD = @PRCARD and PRADDD like @ym+'%' and PRADDH > 0 and PRATYPE=@PRATYPE and PRMEMO=@PRMEMO ")
            If Not isP2K Then
                sql.AppendLine("    and PRUSERID<>'import' ")
                sql.AppendLine("     and (case_status='0' or case_status='1') and (cancel_flag<>'Y' or cancel_flag is null) ") '查plm 時, 除取消及不同意
            End If

            Dim params() As SqlParameter = { _
            New SqlParameter("@PRCARD", SqlDbType.VarChar), _
            New SqlParameter("@ym", SqlDbType.VarChar), _
            New SqlParameter("@PRATYPE", SqlDbType.VarChar), _
            New SqlParameter("@PRMEMO", SqlDbType.VarChar)}
            params(0).Value = PRCARD
            params(1).Value = ym
            params(2).Value = PRATYPE
            params(3).Value = PRMEMO

            Return Query(sql.ToString(), params)
        End Function

        Public Function GetSUNPRADDHByYM(ByVal PRCARD As String, ByVal ym As String, ByVal PRATYPE As String, ByVal isP2K As Boolean) As Object

            Dim sql As New StringBuilder()

            sql.AppendLine(" SELECT SUM(PRADDH) FROM FSC_CPAPR18M ")

            If Not isP2K Then
                sql.AppendLine(" left outer join flow on prguid=flow_id ")
            End If

            sql.AppendLine(" where PRCARD = @PRCARD and PRADDD like @ym+'%' and PRADDH > 0 and PRATYPE=@PRATYPE")

            If Not isP2K Then
                sql.AppendLine("    and PRUSERID<>'import' and  PRUSERID<>'error' ")
                sql.AppendLine("     and (case_status='0' or case_status='1') and (cancel_flag<>'Y' or cancel_flag is null) ") '查plm 時, 除取消及不同意
            End If

            Dim params() As SqlParameter = {New SqlParameter("@PRCARD", SqlDbType.VarChar), _
                                            New SqlParameter("@ym", SqlDbType.VarChar), New SqlParameter("@PRATYPE", SqlDbType.VarChar)}
            params(0).Value = PRCARD
            params(1).Value = ym
            params(2).Value = PRATYPE
            Return SqlAccessHelper.ExecuteScalar(ConnectionString, CommandType.Text, sql.ToString(), params)
        End Function

        Public Function GetSUNPRADDHByYM(ByVal PRCARD As String, ByVal ym As String, ByVal PRATYPE As String, ByVal PRMEMO As String, ByVal isP2K As Boolean) As Object
            Dim sql As New StringBuilder()

            sql.AppendLine(" SELECT SUM(PRADDH) FROM FSC_CPAPR18M ")

            If Not isP2K Then
                sql.AppendLine(" left outer join flow on prguid=flow_id ")
            End If

            sql.AppendLine(" where PRCARD = @PRCARD and PRADDD like @ym+'%' and PRADDH > 0 and PRATYPE=@PRATYPE and PRMEMO=@PRMEMO ")

            If Not isP2K Then
                sql.AppendLine("    and PRUSERID<>'import' ")
                sql.AppendLine("     and (case_status='0' or case_status='1') and (cancel_flag<>'Y' or cancel_flag is null) ") '查plm 時, 除取消及不同意
            End If

            Dim params() As SqlParameter = { _
            New SqlParameter("@PRCARD", SqlDbType.VarChar), _
            New SqlParameter("@ym", SqlDbType.VarChar), _
            New SqlParameter("@PRATYPE", SqlDbType.VarChar), _
            New SqlParameter("@PRMEMO", SqlDbType.VarChar)}
            params(0).Value = PRCARD
            params(1).Value = ym
            params(2).Value = PRATYPE
            params(3).Value = PRMEMO
            Return SqlAccessHelper.ExecuteScalar(ConnectionString, CommandType.Text, sql.ToString(), params)
        End Function



        Public Function GetSumPRMNYH(ByVal PRIDNO As String, ByVal PRADDD As String, ByVal PRATYPE As String) As Object
            Dim StrSQL As String = String.Empty
            StrSQL = "Select Sum(PRMNYH) FROM FSC_CPAPR18M WITH(NOLOCK) where PRIDNO = @PRIDNO and PRATYPE = @PRATYPE and PRADDD like @PRADDD+'%'"
            Dim params() As SqlParameter = {New SqlParameter("@PRIDNO", SqlDbType.VarChar), _
                                            New SqlParameter("@PRADDD", SqlDbType.VarChar), _
                                            New SqlParameter("@PRATYPE", SqlDbType.VarChar)}
            params(0).Value = PRIDNO
            params(1).Value = PRADDD
            params(2).Value = PRATYPE

            Return SqlAccessHelper.ExecuteScalar(ConnectionString, CommandType.Text, StrSQL, params)
        End Function

        Public Function InsertData(ByVal pr18m As CPAPR18M) As Integer
            Dim StrSQL As New StringBuilder
            StrSQL.Append("INSERT INTO FSC_CPAPR18M ( ")
            StrSQL.Append("     Orgcode, PRNAME, PRIDNO, PRCARD, PRADDD, PRSTIME, PRETIME, PRADDH, PRATYPE, PRPAYH, PRPAYFEE, PRMNYH, PRGUID, PRUSERID, PRUPDATE, PRREASON, PRADDE, PRMEMO, Depart_id, isOnlyLeave, CheckType) ")
            StrSQL.Append("VALUES ( ")
            StrSQL.Append("     @Orgcode, @PRNAME, @PRIDNO, @PRCARD, @PRADDD, @PRSTIME, @PRETIME, @PRADDH, @PRATYPE, @PRPAYH, @PRPAYFEE, @PRMNYH, @PRGUID, @PRUSERID, @PRUPDATE, @PRREASON, @PRADDE, @PRMEMO, @Depart_id, @isOnlyLeave, @CheckType)")
            Dim params(20) As SqlParameter
            params(0) = New SqlParameter("@PRNAME", SqlDbType.VarChar)
            params(0).Value = pr18m.PRNAME
            params(1) = New SqlParameter("@PRIDNO", SqlDbType.VarChar)
            params(1).Value = pr18m.PRIDNO
            params(2) = New SqlParameter("@PRCARD", SqlDbType.VarChar)
            params(2).Value = pr18m.PRCARD
            params(3) = New SqlParameter("@PRADDD", SqlDbType.VarChar)
            params(3).Value = pr18m.PRADDD
            params(4) = New SqlParameter("@PRSTIME", SqlDbType.VarChar)
            params(4).Value = pr18m.PRSTIME
            params(5) = New SqlParameter("@PRETIME", SqlDbType.VarChar)
            params(5).Value = pr18m.PRETIME
            params(6) = New SqlParameter("@PRADDH", SqlDbType.Float)
            params(6).Value = pr18m.PRADDH
            params(7) = New SqlParameter("@PRATYPE", SqlDbType.VarChar)
            params(7).Value = pr18m.PRATYPE
            params(8) = New SqlParameter("@PRPAYH", SqlDbType.Float)
            params(8).Value = pr18m.PRPAYH
            params(9) = New SqlParameter("@PRPAYFEE", SqlDbType.Float)
            params(9).Value = pr18m.PRPAYFEE
            params(10) = New SqlParameter("@PRMNYH", SqlDbType.Float)
            params(10).Value = pr18m.PRMNYH
            params(11) = New SqlParameter("@PRGUID", SqlDbType.VarChar)
            params(11).Value = pr18m.PRGUID
            params(12) = New SqlParameter("@PRUSERID", SqlDbType.VarChar)
            params(12).Value = pr18m.PRUSERID
            params(13) = New SqlParameter("@PRUPDATE", SqlDbType.VarChar)
            params(13).Value = DateTimeInfo.GetRocDate(Now) & Now.ToString("HHmm")
            params(14) = New SqlParameter("@PRREASON", SqlDbType.VarChar)
            params(14).Value = pr18m.PRREASON
            params(15) = New SqlParameter("@PRADDE", SqlDbType.VarChar)
            params(15).Value = pr18m.PRADDE
            params(16) = New SqlParameter("@Orgcode", SqlDbType.VarChar)
            params(16).Value = pr18m.Orgcode
            params(17) = New SqlParameter("@PRMEMO", SqlDbType.VarChar)
            params(17).Value = pr18m.PRMEMO
            params(18) = New SqlParameter("@Depart_id", SqlDbType.VarChar)
            params(18).Value = pr18m.DepartId
            params(19) = New SqlParameter("@isOnlyLeave", SqlDbType.VarChar)
            params(19).Value = pr18m.isOnlyLeave
            params(20) = New SqlParameter("@CheckType", SqlDbType.VarChar)
            params(20).Value = pr18m.CheckType
            DBUtil.SetParamsNull(params)

            If Me.Connection IsNot Nothing Then
                Return SqlAccessHelper.ExecuteNonQuery(Me.Connection, CommandType.Text, StrSQL.ToString(), params)
            End If
            Return SqlAccessHelper.ExecuteNonQuery(Me.ConnectionString, CommandType.Text, StrSQL.ToString(), params)
        End Function

        Public Function UpdateData(ByVal pr18m As CPAPR18M) As Integer
            Dim StrSQL As New StringBuilder
            StrSQL.Append("UPDATE FSC_CPAPR18M  SET ")
            StrSQL.Append("     PRNAME = @PRNAME    ")
            StrSQL.Append("     , PRIDNO = @PRIDNO  ")
            StrSQL.Append("     , PRCARD = @PRCARD  ")
            StrSQL.Append("     , PRADDD = @PRADDD  ")
            StrSQL.Append("     , PRSTIME = @PRSTIME  ")
            StrSQL.Append("     , PRETIME = @PRETIME  ")
            StrSQL.Append("     , PRADDH  = @PRADDH")
            StrSQL.Append("     , PRATYPE = @PRATYPE ")
            StrSQL.Append("     , PRPAYH  = @PRPAYH")
            StrSQL.Append("     , PRPAYFEE = @PRPAYFEE ")
            StrSQL.Append("     , PRMNYH = @PRMNYH ")
            StrSQL.Append("     , PRUSERID = @PRUSERID ")
            StrSQL.Append("     , PRUPDATE = @PRUPDATE  ")
            StrSQL.Append("     , PRCHANGE_REASON = @PRCHANGE_REASON  ")
            StrSQL.Append("     , PRREASON = @PRREASON  ")
            StrSQL.Append("     , PRADDE = @PRADDE ")
            StrSQL.Append("     , PRMEMO = @PRMEMO ")
            StrSQL.Append("     , Orgcode = @Orgcode ")
            StrSQL.Append("     , Depart_id = @Depart_id ")
            StrSQL.Append("     where PRGUID = @PRGUID ")

            Dim params(19) As SqlParameter
            params(0) = New SqlParameter("@PRNAME", SqlDbType.VarChar)
            params(0).Value = pr18m.PRNAME
            params(1) = New SqlParameter("@PRIDNO", SqlDbType.VarChar)
            params(1).Value = pr18m.PRIDNO
            params(2) = New SqlParameter("@PRCARD", SqlDbType.VarChar)
            params(2).Value = pr18m.PRCARD
            params(3) = New SqlParameter("@PRADDD", SqlDbType.VarChar)
            params(3).Value = pr18m.PRADDD
            params(4) = New SqlParameter("@PRSTIME", SqlDbType.VarChar)
            params(4).Value = pr18m.PRSTIME
            params(5) = New SqlParameter("@PRETIME", SqlDbType.VarChar)
            params(5).Value = pr18m.PRETIME
            params(6) = New SqlParameter("@PRADDH", SqlDbType.Float)
            params(6).Value = pr18m.PRADDH
            params(7) = New SqlParameter("@PRATYPE", SqlDbType.VarChar)
            params(7).Value = pr18m.PRATYPE
            params(8) = New SqlParameter("@PRPAYH", SqlDbType.Float)
            params(8).Value = pr18m.PRPAYH
            params(9) = New SqlParameter("@PRPAYFEE", SqlDbType.Float)
            params(9).Value = pr18m.PRPAYFEE
            params(10) = New SqlParameter("@PRMNYH", SqlDbType.Float)
            params(10).Value = pr18m.PRMNYH
            params(11) = New SqlParameter("@PRGUID", SqlDbType.VarChar)
            params(11).Value = pr18m.PRGUID
            params(12) = New SqlParameter("@PRUSERID", SqlDbType.VarChar)
            params(12).Value = pr18m.PRUSERID
            params(13) = New SqlParameter("@PRUPDATE", SqlDbType.VarChar)
            params(13).Value = DateTimeInfo.GetRocDate(Now) & Now.ToString("HHmm")
            params(14) = New SqlParameter("@PRREASON", SqlDbType.VarChar)
            params(14).Value = pr18m.PRREASON
            params(15) = New SqlParameter("@PRADDE", SqlDbType.VarChar)
            params(15).Value = pr18m.PRADDE
            params(16) = New SqlParameter("@Orgcode", SqlDbType.VarChar)
            params(16).Value = pr18m.Orgcode
            params(17) = New SqlParameter("@PRMEMO", SqlDbType.VarChar)
            params(17).Value = pr18m.PRMEMO
            params(18) = New SqlParameter("@PRCHANGE_REASON", SqlDbType.VarChar)
            params(18).Value = pr18m.PRCHANGE_REASON
            params(19) = New SqlParameter("@Depart_id", SqlDbType.VarChar)
            params(19).Value = pr18m.DepartId
            DBUtil.SetParamsNull(params)

            If Me.Connection IsNot Nothing Then
                Return SqlAccessHelper.ExecuteNonQuery(Me.Connection, CommandType.Text, StrSQL.ToString(), params)
            End If
            Return SqlAccessHelper.ExecuteNonQuery(Me.ConnectionString, CommandType.Text, StrSQL.ToString(), params)

        End Function

        Public Function UpdatePRMNYH(ByVal PRIDNO As String, ByVal PRADDD As String, ByVal PRSTIME As String, ByVal origApplyhour As Integer, ByVal applyHour As Integer, ByVal hourPay As Integer, ByVal PRUPDATE As String) As Integer
            Dim sql As New StringBuilder
            sql.AppendLine(" Update FSC_CPAPR18M ")
            sql.AppendLine("    Set PRMNYH = PRMNYH-@origApplyhour+@applyHour, ")
            sql.AppendLine("        PRPAYFEE = (PRMNYH-@origApplyhour+@applyHour)*@hourPay, ")
            sql.AppendLine("        PRUSERID=@PRIDNO, PRUPDATE=@PRUPDATE ")
            sql.AppendLine(" where PRIDNO=@PRIDNO and PRADDD=@PRADDD and PRSTIME=@PRSTIME ")

            Dim params() As SqlParameter = { _
            New SqlParameter("@PRIDNO", SqlDbType.VarChar), _
            New SqlParameter("@PRADDD", SqlDbType.VarChar), _
            New SqlParameter("@PRSTIME", SqlDbType.VarChar), _
            New SqlParameter("@origApplyhour", SqlDbType.Int), _
            New SqlParameter("@applyHour", SqlDbType.Int), _
            New SqlParameter("@hourPay", SqlDbType.VarChar), _
            New SqlParameter("@PRUPDATE", SqlDbType.VarChar)}
            params(0).Value = PRIDNO
            params(1).Value = PRADDD
            params(2).Value = PRSTIME
            params(3).Value = origApplyhour
            params(4).Value = applyHour
            params(5).Value = hourPay
            params(6).Value = PRUPDATE
            Return SqlAccessHelper.ExecuteNonQuery(ConnectionString, CommandType.Text, sql.ToString, params)
        End Function


        Public Function UpdatePRMNYH(ByVal PRIDNO As String, ByVal PRADDD As String, ByVal PRSTIME As String, ByVal Apply_hour As Integer, ByVal Hour_pay As Integer) As Integer
            Dim sql As New StringBuilder
            sql.AppendLine(" Update CPAPR18M ")
            sql.AppendLine(" Set PRMNYH = PRMNYH-@Apply_hour, ")
            sql.AppendLine("     PRPAYFEE = PRPAYFEE-(@Apply_hour*@Hour_pay), ")
            sql.AppendLine("     PRUSERID=@PRIDNO, PRUPDATE=@PRUPDATE ")
            sql.AppendLine(" where PRIDNO=@PRIDNO and PRADDD=@PRADDD and PRSTIME=@PRSTIME ")

            Dim params() As SqlParameter = { _
            New SqlParameter("@PRIDNO", SqlDbType.VarChar), _
            New SqlParameter("@PRADDD", SqlDbType.VarChar), _
            New SqlParameter("@PRSTIME", SqlDbType.VarChar), _
            New SqlParameter("@Apply_hour", SqlDbType.Int), _
            New SqlParameter("@Hour_pay", SqlDbType.VarChar), _
            New SqlParameter("@PRUPDATE", SqlDbType.VarChar)}
            params(0).Value = PRIDNO
            params(1).Value = PRADDD
            params(2).Value = PRSTIME
            params(3).Value = Apply_hour
            params(4).Value = Hour_pay
            params(5).Value = DateTimeInfo.GetRocDate(Now) & Now.ToString("HHmmss")
            Return SqlAccessHelper.ExecuteNonQuery(ConnectionString, CommandType.Text, sql.ToString, params)
        End Function

        Public Function UpdatePRPAYH(ByVal PRPAYH As Integer, ByVal PRIDNO As String, ByVal PRADDD As String, ByVal PRSTIME As String) As Integer
            Dim sql As New StringBuilder
            sql.AppendLine("UPDATE CPAPR18M SET PRPAYH=PRPAYH+@PRPAYH WHERE PRIDNO=@PRIDNO AND PRADDD=@PRADDD ")

            If Not String.IsNullOrEmpty(PRSTIME) Then
                sql.AppendLine(" AND PRSTIME=@PRSTIME ")
            End If

            Dim params() As SqlParameter = { _
            New SqlParameter("@PRPAYH", SqlDbType.Int), _
            New SqlParameter("@PRIDNO", SqlDbType.VarChar), _
            New SqlParameter("@PRADDD", SqlDbType.VarChar), _
            New SqlParameter("@PRSTIME", SqlDbType.VarChar)}
            params(0).Value = PRPAYH
            params(1).Value = PRIDNO
            params(2).Value = PRADDD
            params(3).Value = PRSTIME

            If Me.Connection IsNot Nothing Then
                Return SqlAccessHelper.ExecuteNonQuery(Me.Connection, CommandType.Text, sql.ToString(), params)
            End If
            Return SqlAccessHelper.ExecuteNonQuery(Me.ConnectionString, CommandType.Text, sql.ToString(), params)
        End Function

        Public Function GetDataByFlow_id(ByVal Flow_id As String, Optional ByVal Orgcode As String = Nothing) As DataSet
            Dim StrSQL As New StringBuilder
            StrSQL.Append("SELECT * FROM FSC_CPAPR18M WITH(NOLOCK) WHERE PRGUID=@Flow_id")
            If Not String.IsNullOrEmpty(Orgcode) Then
                StrSQL.AppendLine(" AND Orgcode=@orgcode ")
            End If
            Dim param() As SqlParameter = { _
            New SqlParameter("@Flow_id", SqlDbType.VarChar), _
            New SqlParameter("@orgcode", SqlDbType.VarChar)}
            param(0).Value = Flow_id
            param(1).Value = Orgcode
            DBUtil.SetParamsNull(param)
            Return SqlAccessHelper.ExecuteDataset(ConnectionString, CommandType.Text, StrSQL.ToString(), param)
        End Function


        Public Function GetStatisticsData(ByVal nowDate As String, ByVal sixMonthBefore As String) As DataSet
            Dim StrSQL As New StringBuilder

            StrSQL.Append(" SELECT  ")
            StrSQL.Append("     TM.PRIDNO, ")
            StrSQL.Append("     TM.PRADDD, ")
            StrSQL.Append("     T1.Normal, ")
            StrSQL.Append("     T1.Normal_Rest, ")
            StrSQL.Append("     T1.Normal_Fee, ")
            StrSQL.Append("     T1.Normal_Paid, ")
            StrSQL.Append("     T2.Project, ")
            StrSQL.Append("     T2.Project_Rest, ")
            StrSQL.Append("     T2.Project_Fee, ")
            StrSQL.Append("     T2.Project_Paid ")
            StrSQL.Append(" FROM  ")
            StrSQL.Append(" (     ")
            StrSQL.Append("     SELECT ")
            StrSQL.Append("          PRIDNO, ")
            StrSQL.Append("          SUBSTRING(PRADDD, 1, 5) PRADDD ")
            StrSQL.Append("     FROM  ")
            StrSQL.Append("          CPAPR18M WITH(NOLOCK) ")
            StrSQL.Append("     WHERE PRATYPE IN ('1','2') ")
            StrSQL.Append("           AND PRADDD < @nowDate AND PRADDD >= @sixMonthBefore ")
            StrSQL.Append("     GROUP BY PRIDNO, SUBSTRING(PRADDD, 1, 5)  ")
            StrSQL.Append("  ) TM LEFT OUTER JOIN  ")
            StrSQL.Append("  (    ")
            StrSQL.Append("    SELECT ")
            StrSQL.Append("          SUM(PRADDH) AS Normal, ")
            StrSQL.Append("          SUM(PRPAYH) AS Normal_Rest, ")
            StrSQL.Append("          SUM(PRPAYFEE) AS Normal_Fee, ")
            StrSQL.Append("          SUM(PRMNYH) AS Normal_Paid, ")
            StrSQL.Append("          PRIDNO, ")
            StrSQL.Append("          SUBSTRING(PRADDD, 1, 5) PRADDD ")
            StrSQL.Append("    FROM ")
            StrSQL.Append("          CPAPR18M WITH(NOLOCK) ")
            StrSQL.Append("    WHERE  PRATYPE = '1' ")
            StrSQL.Append("           AND PRADDD < @nowDate AND PRADDD >= @sixMonthBefore ")
            StrSQL.Append("    GROUP BY PRIDNO, SUBSTRING(PRADDD, 1, 5) ")
            StrSQL.Append("   ) T1 ON TM.PRIDNO = T1.PRIDNO AND TM.PRADDD = T1.PRADDD  ")
            StrSQL.Append("   LEFT OUTER JOIN  ")
            StrSQL.Append("   (    ")
            StrSQL.Append("     SELECT  ")
            StrSQL.Append("          SUM(PRADDH) AS Project,  ")
            StrSQL.Append("          SUM(PRPAYH) AS Project_Rest, ")
            StrSQL.Append("          SUM(PRPAYFEE) AS Project_Fee, ")
            StrSQL.Append("          SUM(PRMNYH) AS Project_Paid, ")
            StrSQL.Append("          PRIDNO, ")
            StrSQL.Append("          SUBSTRING(PRADDD, 1, 5) PRADDD  ")
            StrSQL.Append("     FROM ")
            StrSQL.Append("          CPAPR18M WITH(NOLOCK) ")
            StrSQL.Append("     WHERE PRATYPE = '2' ")
            StrSQL.Append("           AND PRADDD < @nowDate AND PRADDD >= @sixMonthBefore ")
            StrSQL.Append("     GROUP BY PRIDNO, SUBSTRING(PRADDD, 1, 5) ")
            StrSQL.Append("   ) T2 ON TM.PRIDNO = T2.PRIDNO AND TM.PRADDD = T2.PRADDD        ")


            Dim params() As SqlParameter = {New SqlParameter("@nowDate", SqlDbType.VarChar), _
                                            New SqlParameter("@sixMonthBefore", SqlDbType.VarChar)}
            params(0).Value = nowDate
            params(1).Value = sixMonthBefore

            Return SqlAccessHelper.ExecuteDataset(ConnectionString, CommandType.Text, StrSQL.ToString, params)
        End Function

        Public Function UpdateSAL1112(ByVal PRIDNO As String, _
                                      ByVal PRADDD As String, _
                                      ByVal PRUPDATE As String, _
                                      ByVal PRSTIME As String, _
                                      ByVal ApplyHour1 As Integer, _
                                      ByVal ApplyHour2 As Integer, _
                                      ByVal ApplyHour3 As Integer, _
                                      ByVal Overtime_Pay As Integer) As Integer

            Dim StrSQL As String = String.Empty
            StrSQL = "Update FSC_CPAPR18M Set PRMNYH =  @PRMNYH , " & _
                    " PRPAYFEE=@Overtime_Pay , " & _
                    " PRUSERID=@PRIDNO, PRUPDATE=@PRUPDATE " & _
                    " where PRIDNO=@PRIDNO and PRADDD=@PRADDD and PRSTIME=@PRSTIME"

            Dim PRMNYH As Integer = (ApplyHour1 + ApplyHour2)
            'Dim ApplyHourSum As Double = (ApplyHour1 + ApplyHour2 + ApplyHour3)

            If 0 < ApplyHour3 And ApplyHour3 < 9 Then
                PRMNYH += 8
            ElseIf ApplyHour3 > 8 Then
                PRMNYH = ApplyHour3
            End If

            Dim params() As SqlParameter = { _
            New SqlParameter("@PRMNYH", PRMNYH), _
            New SqlParameter("@Overtime_Pay", Overtime_Pay), _
            New SqlParameter("@PRIDNO", PRIDNO), _
            New SqlParameter("@PRUPDATE", PRUPDATE), _
            New SqlParameter("@PRSTIME", PRSTIME), _
            New SqlParameter("@PRADDD", PRADDD)}

            Return SqlAccessHelper.ExecuteNonQuery(ConnectionString, CommandType.Text, StrSQL, params)
        End Function

        Public Function UpdateSAL1112(ByVal PerId() As String, ByVal OrgCode As String, ByVal YearMonth As String) As Integer
            If Not PerId Is Nothing Then
                If PerId.Length > 0 Then
                    Dim sSQL As New StringBuilder()
                    sSQL.Append(" Update FSC_CPAPR18M  ")
                    sSQL.Append(" Set PRPAYFEE = 0,  ")
                    sSQL.Append(" PRMNYH = 0 ")
                    sSQL.Append(" where PRADDD like @YearMonth ")
                    Dim params() As SqlParameter
                    params = New SqlParameter(1 + PerId.Length) {}
                    params(0) = New SqlParameter("@OrgCode", OrgCode)
                    params(1) = New SqlParameter("@YearMonth", YearMonth & "%")
                    Dim i As Integer = 1
                    sSQL.Append("and PRIDNO in (")
                    For Each p As String In PerId
                        sSQL.Append("@PerId" & i)
                        params(i + 1) = New SqlParameter("@PerId" & i, p)
                        If i <> PerId.Length Then
                            sSQL.Append(",")
                            i = i + 1
                        End If
                    Next
                    sSQL.Append(")")
                    Return SqlAccessHelper.ExecuteNonQuery(ConnectionString, CommandType.Text, sSQL.ToString(), params)
                End If
            End If
            Return 0
        End Function

        Function doQueryFSC3206(ByVal PRIDNO As String, ByVal YEARMONTH As String) As DataTable
            Dim sSQL As New StringBuilder()
            sSQL.Append(" Select * FROM FSC_CPAPR18M WITH(NOLOCK) ")
            sSQL.Append(" where PRIDNO = @PRIDNO and ")
            sSQL.Append(" PRADDD like @PRADDD +'%' and ")
            sSQL.Append(" (PRADDH - PRPAYH > 0) and ")
            sSQL.Append(" PRADDD in (select PBDDATE from CPAPB02M where PBDDATE like @PBDDATE +'%' and PBDTYPE = '2' ) ")
            sSQL.Append(" Order by PRADDD ")
            Dim params() As SqlParameter = { _
            New SqlParameter("@PRIDNO", PRIDNO), _
            New SqlParameter("@PRADDD", YEARMONTH), _
            New SqlParameter("@PBDDATE", YEARMONTH)}
            Return Query(sSQL.ToString, params)
        End Function

        Function doQueryFSC3206_02(ByVal PRIDNO As String, ByVal YEARMONTH As String) As DataTable
            Dim sSQL As New StringBuilder()
            sSQL.Append(" Select * FROM FSC_CPAPR18M WITH(NOLOCK) where  ")
            sSQL.Append(" PRIDNO = @PRIDNO and  ")
            sSQL.Append(" PRADDD like @PRADDD and  ")
            sSQL.Append(" PRADDH > 2 and (PRADDH - PRPAYH > 0) and  ")
            sSQL.Append(" PRADDD in (select PBDDATE from CPAPB02M where PBDDATE like @PBDDATE and PBDTYPE = '0' )  ")
            sSQL.Append(" Order by PRADDD ")
            Dim params() As SqlParameter = {New SqlParameter("@PRIDNO", PRIDNO), New SqlParameter("@PRADDD", YEARMONTH & "%"), _
            New SqlParameter("@PBDDATE", YEARMONTH & "%")}
            Return Query(sSQL.ToString, params)
        End Function

        Function doQueryFSC3206_03(ByVal PRIDNO As String, ByVal YEARMONTH As String) As DataTable
            Dim sSQL As New StringBuilder()
            sSQL.Append(" Select * FROM FSC_CPAPR18M WITH(NOLOCK) where  ")
            sSQL.Append(" PRIDNO = @PRIDNO and  ")
            sSQL.Append(" PRADDD like @PRADDD and  ")
            sSQL.Append(" PRADDH <= 2 and (PRADDH - PRPAYH > 0) and  ")
            sSQL.Append(" PRADDD in (select PBDDATE from CPAPB02M where PBDDATE like @PBDDATE and PBDTYPE = '0' )  ")
            sSQL.Append(" Order by PRADDD ")
            Dim params() As SqlParameter = { _
            New SqlParameter("@PRIDNO", PRIDNO), _
            New SqlParameter("@PRADDD", YEARMONTH & "%"), _
            New SqlParameter("@PBDDATE", YEARMONTH & "%")}

            Return Query(sSQL.ToString, params)
        End Function

        '人立新增0710 for FSC3104_01
        Function GetDataByPoguid(ByVal flow_id As String) As DataTable
            Dim sSQL As New StringBuilder()
            sSQL.Append("SELECT prguid,prreason FROM FSC_CPAPR18M WITH(NOLOCK) where poguid=@flow_id ")
            Dim params() As SqlParameter = {New SqlParameter("@flow_id", flow_id)}
            Return Query(sSQL.ToString, params)
        End Function

        Function DeleteDataByGUID(ByVal Flow_id As String, Optional ByVal Orgcode As String = Nothing) As Integer
            Dim sql As New StringBuilder
            sql.Append("DELETE FROM FSC_CPAPR18M WHERE PRGUID=@Flow_id")
            If Not String.IsNullOrEmpty(Orgcode) Then
                sql.AppendLine(" AND Orgcode=@Orgcode ")
            End If

            Dim param() As SqlParameter = { _
            New SqlParameter("@Flow_id", SqlDbType.VarChar), _
            New SqlParameter("@Orgcode", SqlDbType.VarChar)}
            param(0).Value = Flow_id
            param(1).Value = Orgcode
            DBUtil.SetParamsNull(param)
            Return SqlAccessHelper.ExecuteNonQuery(Me.ConnectionString, CommandType.Text, sql.ToString(), param)
        End Function

        Function GetCountByPRSTIME(ByVal PRIDNO As String, ByVal PRADDD As String, ByVal PRSTIME As String, ByVal PRETIME As String) As Object
            Dim SQL As New StringBuilder
            SQL.AppendLine("SELECT COUNT(*) FROM FSC_CPAPR18M WITH(NOLOCK) ")
            SQL.AppendLine("left outer join sys_flow on prguid=flow_id ")
            SQL.AppendLine("where ((PRSTIME >= @PRSTIME and PRETIME <= @PRETIME ) ")
            SQL.AppendLine("        or (PRSTIME < @PRETIME and PRETIME > @PRETIME) ")
            SQL.AppendLine("        or (PRSTIME < @PRSTIME and PRETIME > @PRSTIME)) ")
            SQL.AppendLine("        and PRIDNO=@PRIDNO AND PRADDD=@PRADDD ")
            SQL.AppendLine("     and (case_status='0' or case_status='1') and (cancel_flag<>'Y' or cancel_flag is null) ")

            Dim params() As SqlParameter = { _
            New SqlParameter("@PRIDNO", SqlDbType.VarChar), _
            New SqlParameter("@PRADDD", SqlDbType.VarChar), _
            New SqlParameter("@PRSTIME", SqlDbType.VarChar), _
            New SqlParameter("@PRETIME", SqlDbType.VarChar)}
            params(0).Value = PRIDNO
            params(1).Value = PRADDD
            params(2).Value = PRSTIME
            params(3).Value = PRETIME

            If Me.Connection IsNot Nothing Then
                Return SqlAccessHelper.ExecuteScalar(Me.Connection, CommandType.Text, SQL.ToString, params)
            End If
            Return SqlAccessHelper.ExecuteScalar(Me.ConnectionString, CommandType.Text, SQL.ToString, params)
        End Function

        Function UpatePRATYPEByGUID(ByVal PRATYPE As String, ByVal PRGUID As String) As Integer
            Dim SQL As New StringBuilder
            SQL.AppendLine("UPDATE CPAPR18M SET PRATYPE=@PRATYPE WHERE PRGUID=@PRGUID ")
            Dim params() As SqlParameter = { _
            New SqlParameter("@PRATYPE", SqlDbType.VarChar), _
            New SqlParameter("@PRGUID", SqlDbType.VarChar)}
            params(0).Value = PRATYPE
            params(1).Value = PRGUID
            Return SqlAccessHelper.ExecuteNonQuery(Me.ConnectionString, CommandType.Text, SQL.ToString(), params)
        End Function

        Public Function GetDataFSC2209_02(ByVal PRIDNO As String, ByVal YYYMM As String) As DataSet
            Dim SQL As New StringBuilder
            SQL.AppendLine("SELECT * FROM FSC_CPAPR18M WITH(NOLOCK) WHERE PRIDNO=@PRIDNO AND PRADDD like @YYYMM+'%' ")
            Dim params() As SqlParameter = { _
            New SqlParameter("@PRIDNO", SqlDbType.VarChar), _
            New SqlParameter("@YYYMM", SqlDbType.VarChar)}
            params(0).Value = PRIDNO
            params(1).Value = YYYMM
            Return SqlAccessHelper.ExecuteDataset(Me.ConnectionString, CommandType.Text, SQL.ToString(), params)
        End Function


        Public Function UpdateFlag(ByVal PRGUID As String, ByVal STATUS As String) As Integer
            Dim sql As New StringBuilder
            sql.AppendLine(" update cpapr18m ")
            sql.AppendLine(" set status=@status ")
            sql.AppendLine(" where prguid=@prguid ")

            Dim params() As SqlParameter = { _
            New SqlParameter("@status", SqlDbType.VarChar), _
            New SqlParameter("@prguid", SqlDbType.VarChar)}
            params(0).Value = STATUS
            params(1).Value = PRGUID
            Return SqlAccessHelper.ExecuteNonQuery(Me.ConnectionString, CommandType.Text, sql.ToString(), params)
        End Function


        Public Function GetDataByDate(ByVal cpadb As String, ByVal PRCARD As String, ByVal PRATYPE As String, ByVal SDATE As String, ByVal EDATE As String) As DataTable
            Dim sql As String = String.Empty
            sql = "  SELECT PRADDH "
            sql &= "    FROM " & cpadb & "..CPAPR18M WITH(NOLOCK) "
            sql &= "    where PRCARD=@PRCARD and PRADDD>=@SDATE and PRADDD<=@EDATE and PRADDH>0 and PRATYPE=@PRATYPE and PRATYPE<>'3' and PRATYPE<>'4' "
            sql &= " union "
            sql &= " SELECT a.PRADDH "
            sql &= "    FROM FSC_CPAPR18M a, flow b WITH(NOLOCK) "
            sql &= "    where PRCARD=@PRCARD and PRADDD>=@SDATE and PRADDD<=@EDATE and PRADDH>0 and PRATYPE=@PRATYPE and PRATYPE<>'3' and PRATYPE<>'4' "
            sql &= "    and a.orgcode=b.orgcode and a.prguid=b.flow_id and b.last_pass=0 "

            Dim params() As SqlParameter = { _
            New SqlParameter("@PRCARD", SqlDbType.VarChar), _
            New SqlParameter("@PRATYPE", SqlDbType.VarChar), _
            New SqlParameter("@SDATE", SqlDbType.VarChar), _
            New SqlParameter("@EDATE", SqlDbType.VarChar)}

            params(0).Value = PRCARD
            params(1).Value = PRATYPE
            params(2).Value = SDATE
            params(3).Value = EDATE
            Return Query(sql, params)
        End Function


        Public Function GetQueryData00(ByVal Year As String, ByVal IDNO As String) As DataTable
            '加班時數
            Dim StrSQL As New StringBuilder()
            StrSQL.Append(" SELECT ")
            StrSQL.Append(" '00' pyvtype, ")
            StrSQL.Append(" ISNULL((SELECT SUM(praddh) FROM FSC_CPAPR18M WHERE PRIDNO = @IDNO AND praddd BETWEEN '" & Year & "0101' AND '" & Year & "0131'),0) pymon1, ")
            StrSQL.Append(" ISNULL((SELECT SUM(praddh) FROM FSC_CPAPR18M WHERE PRIDNO = @IDNO AND praddd BETWEEN '" & Year & "0201' AND '" & Year & "0231'),0) pymon2, ")
            StrSQL.Append(" ISNULL((SELECT SUM(praddh) FROM FSC_CPAPR18M WHERE PRIDNO = @IDNO AND praddd BETWEEN '" & Year & "0301' AND '" & Year & "0331'),0) pymon3, ")
            StrSQL.Append(" ISNULL((SELECT SUM(praddh) FROM FSC_CPAPR18M WHERE PRIDNO = @IDNO AND praddd BETWEEN '" & Year & "0401' AND '" & Year & "0431'),0) pymon4, ")
            StrSQL.Append(" ISNULL((SELECT SUM(praddh) FROM FSC_CPAPR18M WHERE PRIDNO = @IDNO AND praddd BETWEEN '" & Year & "0501' AND '" & Year & "0531'),0) pymon5, ")
            StrSQL.Append(" ISNULL((SELECT SUM(praddh) FROM FSC_CPAPR18M WHERE PRIDNO = @IDNO AND praddd BETWEEN '" & Year & "0601' AND '" & Year & "0631'),0) pymon6, ")
            StrSQL.Append(" ISNULL((SELECT SUM(praddh) FROM FSC_CPAPR18M WHERE PRIDNO = @IDNO AND praddd BETWEEN '" & Year & "0701' AND '" & Year & "0731'),0) pymon7, ")
            StrSQL.Append(" ISNULL((SELECT SUM(praddh) FROM FSC_CPAPR18M WHERE PRIDNO = @IDNO AND praddd BETWEEN '" & Year & "0801' AND '" & Year & "0831'),0) pymon8, ")
            StrSQL.Append(" ISNULL((SELECT SUM(praddh) FROM FSC_CPAPR18M WHERE PRIDNO = @IDNO AND praddd BETWEEN '" & Year & "0901' AND '" & Year & "0931'),0) pymon9, ")
            StrSQL.Append(" ISNULL((SELECT SUM(praddh) FROM FSC_CPAPR18M WHERE PRIDNO = @IDNO AND praddd BETWEEN '" & Year & "1001' AND '" & Year & "1031'),0) pymon10,")
            StrSQL.Append(" ISNULL((SELECT SUM(praddh) FROM FSC_CPAPR18M WHERE PRIDNO = @IDNO AND praddd BETWEEN '" & Year & "1101' AND '" & Year & "1131'),0) pymon11,")
            StrSQL.Append(" ISNULL((SELECT SUM(praddh) FROM FSC_CPAPR18M WHERE PRIDNO = @IDNO AND praddd BETWEEN '" & Year & "1201' AND '" & Year & "1231'),0) pymon12,")
            StrSQL.Append(" ISNULL((SELECT SUM(praddh) FROM FSC_CPAPR18M WHERE PRIDNO = @IDNO AND praddd BETWEEN '" & Year & "0101' AND '" & Year & "1231'),0) pytot   ")
            Dim params() As SqlParameter = {New SqlParameter("@IdNo", IDNO)}
            Return Query(StrSQL.ToString, params)
        End Function

        Public Function GetData(ByVal ID_card As String, ByVal ym As String) As DataTable
            Dim sql As String = String.Empty
            sql = "select * FROM FSC_CPAPR18M "
            sql &= "where pridno = @pridno and praddd like @praddd+'%' and PRMEMO='2' and PRMNYH > 0   order by [PRADDD],[PRSTIME] asc"

            Dim params() As SqlParameter = { _
            New SqlParameter("@pridno", SqlDbType.VarChar), _
            New SqlParameter("@praddd", SqlDbType.VarChar)}

            params(0).Value = ID_card
            params(1).Value = ym
            Return Query(sql, params)
        End Function

        Public Function getAllDataByYm(ByVal Id_card As String, ByVal ym As String) As DataTable
            Dim sql As String = String.Empty
            sql = "select * FROM FSC_CPAPR18M "
            sql &= "where pridno = @pridno and praddd like @praddd+'%' order by [PRADDD],[PRSTIME] asc"

            Dim params() As SqlParameter = { _
            New SqlParameter("@pridno", SqlDbType.VarChar), _
            New SqlParameter("@praddd", SqlDbType.VarChar)}

            params(0).Value = Id_card
            params(1).Value = ym
            Return Query(sql, params)
        End Function
    End Class
End Namespace


