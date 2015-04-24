Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text

Namespace SAL.Logic
    Public Class SAL1112DAO
        Inherits BaseDAO

        Public Sub New()
            MyBase.New(ConnectDB.GetDBString())
        End Sub

        Public Function GetTotalSA(idCard As String, yyymm As String) As Object

            Dim sql As New StringBuilder()

            sql.AppendLine(" select PAYOD_AMT  ")
            sql.AppendLine(" from SAL_SAPAYOD")
            sql.AppendLine(" where PAYOD_KIND = '001' --001=ды┴~")
            sql.AppendLine(" and PAYOD_YM <= @PAYOD_YM  --ж~ды=201412")
            sql.AppendLine(" and PAYOD_CODE_SYS = '003'")
            sql.AppendLine(" and PAYOD_CODE_TYPE = '003'")
            sql.AppendLine(" and PAYOD_CODE_NO = '001' ")
            sql.AppendLine(" and PAYOD_SEQNO=@PAYOD_SEQNO ")
            sql.AppendLine(" ORDER BY PAYOD_YM DESC ")

            Dim params() As SqlParameter = { _
            New SqlParameter("@PAYOD_SEQNO", idCard), _
            New SqlParameter("@PAYOD_YM", yyymm)}

            Return Scalar(sql.ToString(), params)

        End Function

        Public Function doQuerySAL1112(ByVal OrgCode As String, ByVal Unit As String, ByVal YearMonth As String, ByVal PRIDNO As String) As DataTable
            Dim sSQL As New StringBuilder()

            sSQL.AppendLine(" Select * from FSC_CPAPR18M WITH(NOLOCK) where (PRADDH - PRPAYH) > 0 ")

            If Not String.IsNullOrEmpty(PRIDNO) Then
                sSQL.AppendLine(" and PRIDNO = @PRIDNO ")
            End If
            If Not String.IsNullOrEmpty(YearMonth) Then
                sSQL.AppendLine(" and PRADDD LIKE @YEARMONTH ")
            End If

            If Not String.IsNullOrEmpty(Unit) Then
                sSQL.AppendLine(" and Depart_id=@Unit ")
            End If

            sSQL.AppendLine(" and PRADDD < @PRADDD ")
            sSQL.AppendLine(" and (isOnlyLeave is null or isOnlyLeave <> '1') ")
            sSQL.AppendLine(" ORDER BY PRADDD ASC ")

            Dim params() As SqlParameter = { _
            New SqlParameter("@YEARMONTH", YearMonth & "%"), _
            New SqlParameter("@PRIDNO", PRIDNO), _
            New SqlParameter("@PRADDD", FSC.Logic.DateTimeInfo.GetRocTodayString("yyyyMMdd")), _
            New SqlParameter("@Unit", Unit)}
            Dim dt As DataTable = Query(sSQL.ToString, params)
            Return dt
        End Function

        Public Function doQueryDetail(ByVal OrgCode As String, ByVal YearMonth As String, ByVal Id_Card As String, ByVal Depart_id As String, ByVal Overtime_Date As String, ByVal Overtime_Start As String) As DataTable
            Dim sSQL As New StringBuilder()
            sSQL.AppendLine(" Select * ")
            sSQL.AppendLine(" from SAL_Lab_Overtime_Fee_Detail ")
            sSQL.AppendLine(" where Orgcode = @OrgCode ")
            sSQL.AppendLine(" and Depart_id = @Depart_id ")
            sSQL.AppendLine(" and Fee_YM = @YearMonth ")

            If Not Overtime_Date Is Nothing And "" <> Overtime_Date Then
                sSQL.AppendLine(" and Overtime_Date = @Overtime_Date ")
            End If
            If Not Overtime_Start Is Nothing And "" <> Overtime_Start Then
                sSQL.AppendLine(" and Overtime_Start = @Overtime_Start ")
            End If

            sSQL.AppendLine(" and Id_card = @Id_Card")

            Dim params() As SqlParameter = { _
            New SqlParameter("@OrgCode", OrgCode), _
            New SqlParameter("@Depart_id", Depart_id), _
            New SqlParameter("@Overtime_Date", Overtime_Date), _
            New SqlParameter("@Overtime_Start", Overtime_Start), _
            New SqlParameter("@Id_Card", Id_Card), _
            New SqlParameter("@YearMonth", YearMonth)}
            Dim dt As DataTable = Query(sSQL.ToString, params)
            Return dt
        End Function

        Public Function GetLastBudget(ByVal id_card As String) As String
            Dim sql As New StringBuilder
            sql.AppendLine(" select top 1 * from SAL_Lab_Overtime_Fee_Master where Id_card=@Id_card order by Fee_Ym desc ")

            Dim params() As SqlParameter = { _
            New SqlParameter("@Id_card", SqlDbType.VarChar)}
            params(0).Value = id_card

            Dim dt As DataTable = Query(sql.ToString(), params)
            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                Return dt.Rows(0)("Budget_type").ToString()
            Else
                Return "001"
            End If
        End Function

    End Class
End Namespace
