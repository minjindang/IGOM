Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports Pemis2009.SQLAdapter
Imports System.Collections.Generic
Imports System.Text

Namespace FSC.Logic
    Public Class CPAPC03MDAO
        Inherits BaseDAO

        Public Sub New()

        End Sub

        Public Sub New(ByVal conn As SqlConnection)
            MyBase.New(conn)
        End Sub

        Public Function GetHashTableData() As Hashtable
            Dim vPckind As New Hashtable()
            Dim sql As String = "select distinct PCKIND from FSC_CPAPC03M order by pckind "

            Dim dt As DataTable = Query(sql)

            If Not dt Is Nothing Then
                For Each dr As DataRow In dt.Rows
                    Dim pckind As String = dr("PCKIND")
                    Dim hash As Hashtable = GetHashTableData(pckind)
                    vPckind.Add(pckind, hash)
                Next
            End If

            Return vPckind
        End Function

        Public Function GetHashTableData(pckind As String) As Hashtable
            Dim hash As New Hashtable()

            '正常班上下班時間
            Dim sql1 As String = " select PCPARM1,PCPARM2 from FSC_CPAPC03M where PCITEM='worktime' and PCCODE='0' and PCKIND=@PCKIND "
            Dim params1() As SqlParameter = {New SqlParameter("@PCKIND", pckind)}
            Dim dt1 As DataTable = Query(sql1, params1)

            If Not dt1 Is Nothing AndAlso dt1.Rows.Count > 0 Then
                Dim row As DataRow = dt1.Rows(0)
                Dim value As New Hashtable()
                value.Add("PCPARM1", row("PCPARM1"))
                value.Add("PCPARM2", row("PCPARM2"))
                hash.Add("normalWorkTime", value)
            End If

            '彈性上班時間
            Dim sql2 As String = " select PCPARM1,PCPARM2 from FSC_CPAPC03M where PCITEM='worktime' and PCCODE='2' and PCKIND=@PCKIND "
            Dim params2() As SqlParameter = {New SqlParameter("@PCKIND", pckind)}
            Dim dt2 As DataTable = Query(sql2, params2)

            If Not dt2 Is Nothing AndAlso dt2.Rows.Count > 0 Then
                Dim row As DataRow = dt2.Rows(0)
                Dim value As New Hashtable()
                value.Add("PCPARM1", row("PCPARM1"))
                value.Add("PCPARM2", row("PCPARM2"))
                hash.Add("flexibleWorkTime", value)
            End If

            '彈性下班時間
            Dim sql3 As String = " select PCPARM1,PCPARM2 from FSC_CPAPC03M where PCITEM='worktime' and PCCODE='3' and PCKIND=@PCKIND "
            Dim params3() As SqlParameter = {New SqlParameter("@PCKIND", pckind)}
            Dim dt3 As DataTable = Query(sql3, params3)

            If Not dt3 Is Nothing AndAlso dt3.Rows.Count > 0 Then
                Dim row As DataRow = dt3.Rows(0)
                Dim value As New Hashtable()
                value.Add("PCPARM1", row("PCPARM1"))
                value.Add("PCPARM2", row("PCPARM2"))
                hash.Add("flexibleOffTime", value)
            End If

            '午休時間
            Dim sql4 As String = " select PCPARM1,PCPARM2 from FSC_CPAPC03M where PCITEM='worktime' and PCCODE='11' and PCKIND=@PCKIND "
            Dim params4() As SqlParameter = {New SqlParameter("@PCKIND", pckind)}
            Dim dt4 As DataTable = Query(sql4, params4)

            If Not dt4 Is Nothing AndAlso dt4.Rows.Count > 0 Then
                Dim row As DataRow = dt4.Rows(0)
                Dim value As New Hashtable()
                value.Add("PCPARM1", row("PCPARM1"))
                value.Add("PCPARM2", row("PCPARM2"))
                hash.Add("noonRestTime", value)
            End If

            '中午刷卡時間
            Dim sql5 As String = " select PCPARM1,PCPARM2 from FSC_CPAPC03M where PCITEM='worktime' and PCCODE='16' and PCKIND=@PCKIND "
            Dim params5() As SqlParameter = {New SqlParameter("@PCKIND", pckind)}
            Dim dt5 As DataTable = Query(sql5, params5)

            If Not dt5 Is Nothing AndAlso dt5.Rows.Count > 0 Then
                Dim row As DataRow = dt5.Rows(0)
                Dim value As New Hashtable()
                value.Add("PCPARM1", row("PCPARM1"))
                value.Add("PCPARM2", row("PCPARM2"))
                hash.Add("noonCardTime", value)
            End If

            '彈性下班時間(半日)
            Dim sql6 As String = " select PCPARM1,PCPARM2 from FSC_CPAPC03M where PCITEM='worktime' and PCCODE='4' and PCKIND=@PCKIND "
            Dim params6() As SqlParameter = {New SqlParameter("@PCKIND", pckind)}
            Dim dt6 As DataTable = Query(sql6, params6)

            If Not dt6 Is Nothing AndAlso dt6.Rows.Count > 0 Then
                Dim row As DataRow = dt6.Rows(0)
                Dim value As New Hashtable()
                value.Add("PCPARM1", row("PCPARM1"))
                value.Add("PCPARM2", row("PCPARM2"))
                hash.Add("flexibleOffTimeHalf", value)
            End If


            '正常班上下班時間(半日)
            Dim sql7 As String = " select PCPARM1,PCPARM2 from FSC_CPAPC03M where PCITEM='worktime' and PCCODE='1' and PCKIND=@PCKIND "
            Dim params7() As SqlParameter = {New SqlParameter("@PCKIND", pckind)}
            Dim dt7 As DataTable = Query(sql7, params7)

            If Not dt7 Is Nothing AndAlso dt7.Rows.Count > 0 Then
                Dim row As DataRow = dt7.Rows(0)
                Dim value As New Hashtable()
                value.Add("PCPARM1", row("PCPARM1"))
                value.Add("PCPARM2", row("PCPARM2"))
                hash.Add("normalWorkTimeHalf", value)
            End If

            '中午要不要刷卡 1:要 2:不要
            Dim sql8 As String = " select PCPARM1,PCPARM2 from FSC_CPAPC03M where PCITEM='regulation' and PCCODE='1' and PCKIND=@PCKIND "
            Dim params8() As SqlParameter = {New SqlParameter("@PCKIND", pckind)}
            Dim dt8 As DataTable = Query(sql8, params8)

            If Not dt8 Is Nothing AndAlso dt8.Rows.Count > 0 Then
                Dim row As DataRow = dt8.Rows(0)
                Dim value As New Hashtable()
                value.Add("PCPARM1", row("PCPARM1"))
                value.Add("PCPARM2", row("PCPARM2"))
                hash.Add("isNoonNeedCard", value)
            End If

            '全天上班至少上班時數
            Dim sql9 As String = " select PCPARM1,PCPARM2 from FSC_CPAPC03M where PCITEM='limit' and PCCODE='7' and PCKIND=@PCKIND "
            Dim params9() As SqlParameter = {New SqlParameter("@PCKIND", pckind)}
            Dim dt9 As DataTable = Query(sql9, params9)

            If Not dt9 Is Nothing AndAlso dt9.Rows.Count > 0 Then
                Dim row As DataRow = dt9.Rows(0)
                Dim value As New Hashtable()
                value.Add("PCPARM1", row("PCPARM1"))
                value.Add("PCPARM2", row("PCPARM2"))
                hash.Add("workHours", value)
            End If

            '半天上班至少上班時數
            Dim sql10 As String = " select PCPARM1,PCPARM2 from FSC_CPAPC03M where PCITEM='limit' and PCCODE='8'  and PCKIND=@PCKIND "
            Dim params10() As SqlParameter = {New SqlParameter("@PCKIND", pckind)}
            Dim dt10 As DataTable = Query(sql10, params10)

            If Not dt10 Is Nothing AndAlso dt10.Rows.Count > 0 Then
                Dim row As DataRow = dt10.Rows(0)
                Dim value As New Hashtable()
                value.Add("PCPARM1", row("PCPARM1"))
                value.Add("PCPARM2", row("PCPARM2"))
                hash.Add("workHoursHalf", value)
            End If

            '上下班緩衝時間
            Dim sql11 As String = " select PCPARM1,PCPARM2 from FSC_CPAPC03M where PCITEM='limit' and PCCODE in ('5','6') and PCKIND=@PCKIND "
            Dim params11() As SqlParameter = {New SqlParameter("@PCKIND", pckind)}
            Dim dt11 As DataTable = Query(sql11, params11)

            If Not dt11 Is Nothing AndAlso dt11.Rows.Count > 0 Then
                Dim row As DataRow = dt11.Rows(0)
                Dim value11 As New Hashtable()
                value11.Add("PCPARM1", row("PCPARM1"))
                value11.Add("PCPARM2", row("PCPARM2"))
                hash.Add("pullOffTime", value11)
            End If


            '輪班日班
            Dim sql12 As String = " select PCPARM1,PCPARM2 from FSC_CPAPC03M where PCITEM='worktime' and PCCODE='5' and PCKIND=@PCKIND "
            Dim params12() As SqlParameter = {New SqlParameter("@PCKIND", pckind)}
            Dim dt12 As DataTable = Query(sql12, params12)

            If Not dt12 Is Nothing AndAlso dt12.Rows.Count > 0 Then
                Dim row As DataRow = dt12.Rows(0)
                Dim value12 As New Hashtable()
                value12.Add("PCPARM1", row("PCPARM1"))
                value12.Add("PCPARM2", row("PCPARM2"))
                hash.Add("shiftTime1", value12)
            End If


            '輪班小夜班
            Dim sql13 As String = " select PCPARM1,PCPARM2 from FSC_CPAPC03M where PCITEM='worktime' and PCCODE='6' and PCKIND=@PCKIND "
            Dim params13() As SqlParameter = {New SqlParameter("@PCKIND", pckind)}
            Dim dt13 As DataTable = Query(sql13, params13)

            If Not dt13 Is Nothing AndAlso dt13.Rows.Count > 0 Then
                Dim row As DataRow = dt13.Rows(0)
                Dim value13 As New Hashtable()
                value13.Add("PCPARM1", row("PCPARM1"))
                value13.Add("PCPARM2", row("PCPARM2"))
                hash.Add("shiftTime2", value13)
            End If


            '輪班大夜班
            Dim sql14 As String = " select PCPARM1,PCPARM2 from FSC_CPAPC03M where PCITEM='worktime' and PCCODE='7' and PCKIND=@PCKIND "
            Dim params14() As SqlParameter = {New SqlParameter("@PCKIND", pckind)}
            Dim dt14 As DataTable = Query(sql14, params14)

            If Not dt14 Is Nothing AndAlso dt14.Rows.Count > 0 Then
                Dim row As DataRow = dt14.Rows(0)
                Dim value14 As New Hashtable()
                value14.Add("PCPARM1", row("PCPARM1"))
                value14.Add("PCPARM2", row("PCPARM2"))
                hash.Add("shiftTime3", value14)
            End If

            Return hash
        End Function

        Public Function GetData(ByVal Orgcode As String, ByVal Depart_id As String, ByVal PCKIND As String, ByVal PCITEM As String) As DataTable
            Dim StrSQL As New StringBuilder()
            StrSQL.Append(" Select * from FSC_CPAPC03M ")
            StrSQL.Append(" where Orgcode=@Orgcode ")
            If Depart_id <> "" Then
                StrSQL.Append(" and Depart_id=@Depart_id")
            End If
            StrSQL.Append(" and PCKIND = @PCKIND ")
            StrSQL.Append(" and PCITEM = @PCITEM order by PCITEM ")

            Dim param() As SqlParameter = { _
            New SqlParameter("@Orgcode", SqlDbType.VarChar), _
            New SqlParameter("@Depart_id", SqlDbType.VarChar), _
            New SqlParameter("@PCKIND", SqlDbType.VarChar), _
            New SqlParameter("@PCITEM", SqlDbType.VarChar)}
            param(0).Value = Orgcode
            param(1).Value = Depart_id
            param(2).Value = PCKIND
            param(3).Value = PCITEM

            Return Query(StrSQL.ToString(), param)
        End Function

        Public Function GetDataByKind(ByVal PCKIND As String) As DataTable
            Dim StrSQL As New StringBuilder()
            StrSQL.Append(" Select PCCODE, PCPARM1 from FSC_CPAPC03M ")
            StrSQL.Append(" where PCKIND = @PCKIND ")
            StrSQL.Append(" and PCITEM = 'limit' and PCCODE >= 15 and PCCODE <= 21 ")

            Dim param As SqlParameter = New SqlParameter("@PCKIND", SqlDbType.VarChar)
            param.Value = PCKIND

            Return Query(StrSQL.ToString(), param)
        End Function


        Public Function GetDataByQuery(ByVal PCKIND As String, ByVal PCITEM As String, ByVal PCCODE As String) As DataTable
            Dim StrSQL As String = "Select PCPARM1, * from FSC_CPAPC03M where PCKIND = @PCKIND and PCITEM = @PCITEM and PCCODE= @PCCODE"
            Dim params() As SqlParameter = {New SqlParameter("@PCKIND", SqlDbType.VarChar), _
                                            New SqlParameter("@PCITEM", SqlDbType.VarChar), _
                                            New SqlParameter("@PCCODE", SqlDbType.VarChar)}
            params(0).Value = PCKIND
            params(1).Value = PCITEM
            params(2).Value = PCCODE
            Return Query(StrSQL, params)
        End Function


        Public Function GetWorktimeDataByPCKIND(ByVal PCKIND As String) As DataTable
            Dim StrSQL As New StringBuilder

            'PCCODE=0 正常班, PCCODE=11 中午午休

            StrSQL.Append("select * from FSC_CPAPC03M where PCITEM='worktime' and PCKIND=@PCKIND order by pccode")

            Dim param As SqlParameter = New SqlParameter("@PCKIND", SqlDbType.VarChar)
            param.Value = PCKIND

            Return Query(StrSQL.ToString(), param)
        End Function


        Public Function insertNewData(ByVal PCKIND As String) As Integer
            Dim sql As StringBuilder = New StringBuilder
            sql.AppendLine("INSERT INTO [FSC_CPAPC03M]")
            sql.AppendLine("([Orgcode]")
            sql.AppendLine(",[Depart_id]")
            sql.AppendLine(",[PCKIND]")
            sql.AppendLine(",[PCITEM]")
            sql.AppendLine(",[PCCODE]")
            sql.AppendLine(",[PCDESC]")
            sql.AppendLine(",[PCPARM1]")
            sql.AppendLine(",[PCPARM2]")
            sql.AppendLine(",[PCUSERID]")
            sql.AppendLine(",[Change_userid]")
            sql.AppendLine(",[Change_date])")
            sql.AppendLine("select ")
            sql.AppendLine("[Orgcode]")
            sql.AppendLine(",[Depart_id]")
            sql.AppendLine(",@PCKIND ")
            sql.AppendLine(",[PCITEM]")
            sql.AppendLine(",[PCCODE]")
            sql.AppendLine(",[PCDESC]")
            sql.AppendLine(",[PCPARM1]")
            sql.AppendLine(",[PCPARM2]")
            sql.AppendLine(",[PCUSERID]")
            sql.AppendLine(",@Change_userid")
            sql.AppendLine(",getDate()")
            sql.AppendLine(" from FSC_CPAPC03M ")
            sql.AppendLine(" where PCKIND = 'A' ")

            Dim para(1) As SqlParameter
            para(0) = New SqlParameter("@PCKIND", SqlDbType.VarChar)
            para(0).Value = PCKIND
            para(1) = New SqlParameter("@Change_userid", SqlDbType.VarChar)
            para(1).Value = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account)

            Return Execute(sql.ToString(), para)
        End Function
    End Class
End Namespace