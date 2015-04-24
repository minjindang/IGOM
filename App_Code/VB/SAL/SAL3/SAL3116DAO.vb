Imports System.Data
Imports System.Data.SqlClient
Imports Pemis2009.SQLAdapter
Imports System.Text
Imports System
Namespace SALARY.Logic
    Public Class SAL3116DAO
        Inherits BaseDAO

        Dim sbSQL As New StringBuilder
        Dim ConnectionString As String = String.Empty
        Dim dtData As DataTable

        Public Sub New()
            MyBase.New()
            ConnectionString = ConnectDB.GetDBString()
        End Sub

        ''' <summary>
        ''' 取得銀行列表
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetBankData(ByVal Orgcode As String) As DataTable
            sbSQL.Length = 0
            sbSQL.AppendLine(" SELECT TDPF_BANK_NO,code_desc1 + '[' + tdpf_bank_no + ']' as text")
            sbSQL.AppendLine("   ,TDPF_SEQNO")
            sbSQL.AppendLine("  from sal_satdpf")
            sbSQL.AppendLine("    left join sys_code")
            sbSQL.AppendLine("     on code_sys='004'")
            sbSQL.AppendLine("     and code_kind='P'")
            sbSQL.AppendLine("    and code_type='002'")
            sbSQL.AppendLine("    and code_no=tdpf_bank")
            sbSQL.AppendLine(" where tdpf_orgid= @Orgcode")
            sbSQL.AppendLine("  order by TDPF_BANK_NO")
            Dim param() As SqlParameter = { _
             New SqlParameter("@orgcode", Orgcode)}

            Return Query(sbSQL.ToString(), param)
        End Function

        ''' <summary>
        ''' 依銀行資料取得銀行帳號
        ''' </summary>
        ''' <param name="BANK_CODE"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetBankNOData(ByVal BANK_CODE As String) As DataTable
            sbSQL.Length = 0
            sbSQL.AppendLine(" SELECT TDPF_BANK_NO,tdpf_memo FROM SAL_SATDPF WHERE TDPF_SEQNO=@BANK_CODE ")

            Dim param() As SqlParameter = { _
           New SqlParameter("@BANK_CODE", BANK_CODE)}

            Return Query(sbSQL.ToString(), param)
        End Function

        ''' <summary>
        ''' 回傳各銀行與費用項目名稱
        ''' </summary>
        ''' <param name="Orgcode"></param>
        ''' <param name="v_kind"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetData(ByVal Orgcode As String, ByVal v_kind As String) As DataSet
            sbSQL.Length = 0
            sbSQL.AppendLine(" select SDF.TDPF_BANK_NO BANK_BANK_NO,TDPF_MEMO ,payod_orgid,payod_code_sys,payod_code_kind,payod_code_type,payod_code_no,payod_code, payod_kind ")
            sbSQL.AppendLine(" ,( ")
            sbSQL.AppendLine(" case payod_code_type ")
            sbSQL.AppendLine(" when '001' then '應發款'")
            sbSQL.AppendLine(" when '002' then '應扣款'")
            sbSQL.AppendLine(" when '003' then '應發款' end ")
            sbSQL.AppendLine(" ) as code_type_name")
            sbSQL.AppendLine(" ,(")
            sbSQL.AppendLine("   select code_desc1 from sys_code ")
            sbSQL.AppendLine("  where code_sys='003' ")
            sbSQL.AppendLine(" and code_type='005' ")
            sbSQL.AppendLine(" and code_kind='P' ")
            sbSQL.AppendLine(" and code_no=payod_kind ")

            sbSQL.AppendLine(" ) as kind_name ")
            sbSQL.AppendLine(" ,( ")
            sbSQL.AppendLine("  case payod_code_sys ")
            sbSQL.AppendLine("   when '003' then '實發數' ")
            sbSQL.AppendLine("  else ")
            sbSQL.AppendLine("   (")
            sbSQL.AppendLine("  select item_name ")
            sbSQL.AppendLine("    from sal_saitem ")
            sbSQL.AppendLine("    where item_orgid=payod_orgid ")
            sbSQL.AppendLine("  and item_code_sys=payod_code_sys ")
            sbSQL.AppendLine("  and item_code_kind=payod_code_kind ")
            sbSQL.AppendLine("  and item_code_type=payod_code_type ")
            sbSQL.AppendLine(" and item_code_no=payod_code_no ")
            sbSQL.AppendLine(" and item_code=payod_code ")
            sbSQL.AppendLine("  ) end ")
            sbSQL.AppendLine(") as code_sys_name ")
            sbSQL.AppendLine(",( ")
            sbSQL.AppendLine(" select tdpm_tdpf_seqno ")
            sbSQL.AppendLine(" from sal_satdpm ")
            sbSQL.AppendLine("  where tdpm_orgid=payod_orgid  ")
            sbSQL.AppendLine("   and tdpm_kind=payod_kind ")
            sbSQL.AppendLine("   and tdpm_code_sys=payod_code_sys ")
            sbSQL.AppendLine("  and tdpm_code_kind=payod_code_kind ")
            sbSQL.AppendLine("  and tdpm_code_type=payod_code_type ")
            sbSQL.AppendLine("  and tdpm_code_no=payod_code_no  ")
            sbSQL.AppendLine("  and tdpm_code=payod_code  ")
            sbSQL.AppendLine(") as tdpm_tdpf_seqno ")
            'sbSQL.AppendLine("  from sal_sapayod  LEFT JOIN SAL_SATDPM SDP ON SDP.tdpm_orgid=SD.payod_orgid AND SDP.tdpm_kind=SD.payod_kind AND SDP.tdpm_code_sys=SD.payod_code_sys AND SDP.tdpm_code_kind=SD.payod_code_kind AND SDP.tdpm_code_type=SD.payod_code_type AND SDP.tdpm_code_no=SD.payod_code_no AND SDP.tdpm_code=SD.payod_code LEFT JOIN SAL_SATDPF SDF   ON SDP.TDPM_TDPF_SEQNO =SDF.TDPF_SEQNO ")
            sbSQL.AppendLine(" FROM SAL_SAPAYOD SD ")
            sbSQL.AppendLine(" LEFT JOIN SAL_SAITEM SI ")
            sbSQL.AppendLine(" ON payod_orgid = item_orgid AND payod_code_sys = item_code_sys AND payod_code_kind = item_code_kind AND payod_code_type = item_code_type AND payod_code_no = item_code_no AND payod_code = item_code ")
            sbSQL.AppendLine(" LEFT JOIN SAL_SATDPM SDP ")
            sbSQL.AppendLine(" ON SDP.tdpm_orgid=SD.payod_orgid AND SDP.tdpm_kind=SD.payod_kind AND SDP.tdpm_code_sys=SD.payod_code_sys AND SDP.tdpm_code_kind=SD.payod_code_kind AND SDP.tdpm_code_type=SD.payod_code_type AND SDP.tdpm_code_no=SD.payod_code_no AND SDP.tdpm_code=SD.payod_code")

            sbSQL.AppendLine(" LEFT JOIN SAL_SATDPF SDF ")
            sbSQL.AppendLine("      ON SDP.TDPM_TDPF_SEQNO =SDF.TDPF_SEQNO ")

            sbSQL.AppendLine(" where payod_orgid=@orgcode  ")
            sbSQL.AppendLine(" AND SD.payod_code_sys <>''")
            sbSQL.AppendLine("AND SD.payod_code_kind <>''")
            sbSQL.AppendLine("AND SD.payod_code_type <>''")
            sbSQL.AppendLine("AND SD.payod_code_no <>''")
            sbSQL.AppendLine("AND SD.payod_code <>''")
            sbSQL.AppendLine("AND SD.payod_kind <>''")
            sbSQL.AppendLine("AND SD.payod_code_type <>''")
            sbSQL.AppendLine(" AND")
            sbSQL.AppendLine(" ( ( ")
            sbSQL.AppendLine("  payod_code_sys = '003' AND payod_code_kind = 'P'   AND payod_code_type = '003'  AND payod_code_no='003' ) ")
            sbSQL.AppendLine("  OR ( payod_code_sys='005'   and payod_code_kind='D'  and payod_code_type in ('001','002')   ")
            sbSQL.AppendLine(" and exists ( select 1 from sal_saitem  where(item_orgid = payod_orgid)  and item_code_sys=payod_code_sys  and item_code_type=payod_code_type")
            sbSQL.AppendLine("  and item_code_no=payod_code_no   and item_code=payod_code   )  ")
            sbSQL.AppendLine(") )")

            Select Case v_kind
                Case "1" '一般類別(非其他薪津)
                    sbSQL.AppendLine(" AND payod_kind<>'005' ")

                Case "2"
                    '其他薪津(應發)
                    sbSQL.AppendLine(" AND payod_kind='005' ")
                    sbSQL.AppendLine(" AND payod_kind_code_type='001' ")

                Case "3" '其他薪津(應扣)
                    sbSQL.AppendLine("  AND payod_kind='005' ")
                    sbSQL.AppendLine(" AND payod_kind_code_type='002' ")
                    sbSQL.AppendLine(" AND payod_code_sys='005' ")

            End Select

            'sbSQL.AppendLine(" group by payod_orgid, payod_code_sys, payod_code_kind, payod_code_type, payod_code_no, payod_code, payod_kind ,SAL_SATDPF.TDPF_BANK_NO ")
            'sbSQL.AppendLine(" order by payod_orgid, payod_code_sys, payod_code_kind, payod_code_type, payod_code_no, payod_code, payod_kind SAL_SATDPF.TDPF_BANK_NO")
            sbSQL.AppendLine(" GROUP BY payod_orgid, payod_code_sys, payod_code_kind, payod_code_type, payod_code_no, payod_code, payod_kind,SDP.tdpm_tdpf_seqno,SDF.TDPF_BANK_NO,TDPF_MEMO ")
            sbSQL.AppendLine(" ORDER BY payod_orgid, payod_code_sys, payod_code_kind, payod_code_type, payod_code_no, payod_code, payod_kind,SDP.tdpm_tdpf_seqno,SDF.TDPF_BANK_NO,TDPF_MEMO ")

            Dim param() As SqlParameter = { _
              New SqlParameter("@orgcode", Orgcode)}

            Return SqlAccessHelper.ExecuteDataset(ConnectionString, CommandType.Text, sbSQL.ToString(), param)
        End Function

        Public Function InsertOrUpdate(ByVal TDPM_ORGID As String, ByVal TDPM_KIND As String, ByVal TDPM_CODE_SYS As String, ByVal TDPM_CODE_KIND As String, ByVal TDPM_CODE_TYPE As String, _
                               ByVal TDPM_CODE_NO As String, ByVal TDPM_CODE As String, ByVal TDPM_TDPF_SEQNO As String, ByVal TDPM_MUSER As String, ByVal TDPM_MDATE As String) As Integer
            ' 先查詢資料是否存在
            sbSQL.Length = 0
            sbSQL.AppendLine(" Select TDPM_ORGID ")
            sbSQL.AppendLine(" FROM SAL_SATDPM ")
            sbSQL.AppendLine(" WHERE 1 = 1 ")
            sbSQL.AppendLine(" AND TDPM_ORGID=@TDPM_ORGID ")
            sbSQL.AppendLine(" AND TDPM_KIND=@TDPM_KIND ")
            sbSQL.AppendLine(" AND TDPM_CODE_SYS=@TDPM_CODE_SYS ")
            sbSQL.AppendLine(" AND TDPM_CODE_KIND=@TDPM_CODE_KIND ")
            sbSQL.AppendLine(" AND TDPM_CODE_TYPE=@TDPM_CODE_TYPE ")
            sbSQL.AppendLine(" AND TDPM_CODE_NO=@TDPM_CODE_NO ")
            sbSQL.AppendLine(" AND TDPM_CODE=@TDPM_CODE ")

            Dim paramQuery() As SqlParameter = { _
            New SqlParameter("@TDPM_ORGID", TDPM_ORGID), _
            New SqlParameter("@TDPM_KIND", TDPM_KIND), _
            New SqlParameter("@TDPM_CODE_SYS", TDPM_CODE_SYS), _
            New SqlParameter("@TDPM_CODE_KIND", TDPM_CODE_KIND), _
            New SqlParameter("@TDPM_CODE_TYPE", TDPM_CODE_TYPE), _
            New SqlParameter("@TDPM_CODE_NO", TDPM_CODE_NO), _
            New SqlParameter("@TDPM_CODE", TDPM_CODE)}

            dtData = SqlAccessHelper.ExecuteDataset(ConnectionString, CommandType.Text, sbSQL.ToString(), paramQuery).Tables(0)
            If dtData.Rows.Count = 0 Then
                ' 新增
                sbSQL.Length = 0
                sbSQL.AppendLine(" INSERT INTO SAL_SATDPM  ")
                sbSQL.AppendLine(" (TDPM_ORGID,TDPM_KIND,TDPM_CODE_SYS,TDPM_CODE_KIND,TDPM_CODE_TYPE,TDPM_CODE_NO,TDPM_CODE,TDPM_TDPF_SEQNO,TDPM_MUSER,TDPM_MDATE) ")
                sbSQL.AppendLine(" VALUES ")
                sbSQL.AppendLine(" (@TDPM_ORGID,@TDPM_KIND,@TDPM_CODE_SYS,@TDPM_CODE_KIND,@TDPM_CODE_TYPE,@TDPM_CODE_NO,@TDPM_CODE,@TDPM_TDPF_SEQNO,@TDPM_MUSER,@TDPM_MDATE) ")
            Else
                ' 修改
                sbSQL.Length = 0
                sbSQL.AppendLine(" UPDATE SAL_SATDPM ")
                sbSQL.AppendLine(" SET  ")
                sbSQL.AppendLine(" TDPM_TDPF_SEQNO=@TDPM_TDPF_SEQNO,TDPM_MUSER=@TDPM_MUSER,TDPM_MDATE=@TDPM_MDATE ")
                sbSQL.AppendLine(" WHERE 1 = 1 ")
                sbSQL.AppendLine(" AND TDPM_ORGID=@TDPM_ORGID ")
                sbSQL.AppendLine(" AND TDPM_KIND=@TDPM_KIND ")
                sbSQL.AppendLine(" AND TDPM_CODE_SYS=@TDPM_CODE_SYS ")
                sbSQL.AppendLine(" AND TDPM_CODE_KIND=@TDPM_CODE_KIND ")
                sbSQL.AppendLine(" AND TDPM_CODE_TYPE=@TDPM_CODE_TYPE ")
                sbSQL.AppendLine(" AND TDPM_CODE_NO=@TDPM_CODE_NO ")
                sbSQL.AppendLine(" AND TDPM_CODE=@TDPM_CODE ")
            End If

            Dim param() As SqlParameter = { _
           New SqlParameter("@TDPM_ORGID", TDPM_ORGID), _
            New SqlParameter("@TDPM_KIND", TDPM_KIND), _
            New SqlParameter("@TDPM_CODE_SYS", TDPM_CODE_SYS), _
            New SqlParameter("@TDPM_CODE_KIND", TDPM_CODE_KIND), _
            New SqlParameter("@TDPM_CODE_TYPE", TDPM_CODE_TYPE), _
            New SqlParameter("@TDPM_CODE_NO", TDPM_CODE_NO), _
            New SqlParameter("@TDPM_CODE", TDPM_CODE), _
            New SqlParameter("@TDPM_TDPF_SEQNO", TDPM_TDPF_SEQNO), _
            New SqlParameter("@TDPM_MUSER", TDPM_MUSER), _
            New SqlParameter("@TDPM_MDATE", TDPM_MDATE)}

            Try
                Return Execute(sbSQL.ToString(), param)
            Catch ex As Exception
                Dim a As String
                Return ""
            End Try

        End Function
    End Class
End Namespace