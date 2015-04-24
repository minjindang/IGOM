Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text

Namespace SAL.Logic
    Public Class SAL2103DAO
        Inherits BaseDAO

        ''' <summary>
        ''' 回傳資料
        ''' </summary>
        ''' <param name="orgcode">機關代碼</param>
        ''' <param name="YYMM">發放年月</param>
        ''' <param name="CODENO">代碼</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetFormData(ByVal orgcode As String, ByVal YYMM As String, ByVal CODENO As String) As DataTable
            Dim sbSQL As New StringBuilder()

            sbSQL.AppendLine(" SELECT ")
            sbSQL.AppendLine(" ISNULL( ")
            sbSQL.AppendLine(" 			( ")
            sbSQL.AppendLine(" 				SELECT TOP 1 BANK_BANK_NO  ")
            sbSQL.AppendLine(" 				FROM SAL_SABANK  ")
            sbSQL.AppendLine(" 				INNER JOIN SAL_SATDPM ON TDPM_ORGID = BANK_ORGID  ")
            sbSQL.AppendLine(" 					AND TDPM_KIND = PAYO_KIND  ")
            sbSQL.AppendLine(" 					AND TDPM_CODE_SYS = PAYO_KIND ")
            sbSQL.AppendLine(" 					AND TDPM_CODE_TYPE = PAYO_KIND_CODE_TYPE ")
            sbSQL.AppendLine(" 					AND TDPM_CODE_NO = PAYO_KIND_CODE_NO ")
            sbSQL.AppendLine(" 				WHERE BANK_ORGID = PAYO_ORGID AND BANK_SEQNO = PAYO_SEQNO   ")
            sbSQL.AppendLine(" 			),'') AS '帳號' ")
            sbSQL.AppendLine(" , PAYO_NAME AS '姓名' ")
            sbSQL.AppendLine(" , ISNULL( ")
            sbSQL.AppendLine(" 				( ")
            sbSQL.AppendLine(" 					SELECT sum(PAYOD_AMT)  ")
            sbSQL.AppendLine(" 					FROM SAL_SAPAYOD  ")
            sbSQL.AppendLine(" 					WHERE PAYOD_ORGID = PAYO_ORGID  ")
            sbSQL.AppendLine(" 						AND PAYOD_SEQNO = PAYO_SEQNO  ")
            sbSQL.AppendLine(" 						AND PAYOD_YM = PAYO_YYMM  ")
            sbSQL.AppendLine(" 						AND PAYOD_DATE = PAYO_DATE  ")
            sbSQL.AppendLine(" 						AND PAYOD_KIND = PAYO_KIND  ")
            sbSQL.AppendLine(" 						AND PAYOD_KIND_CODE_TYPE = PAYO_KIND_CODE_TYPE  ")
            sbSQL.AppendLine(" 						AND PAYOD_KIND_CODE_NO = PAYO_KIND_CODE_NO  ")
            sbSQL.AppendLine(" 						AND PAYOD_CODE_SYS = '003'  ")
            sbSQL.AppendLine(" 						AND PAYOD_CODE_TYPE = '003'  ")
            sbSQL.AppendLine(" 						AND PAYOD_CODE_NO = '003' ")
            sbSQL.AppendLine(" 				),0) AS '入帳金額' ")
            sbSQL.AppendLine(" , ISNULL( ")
            sbSQL.AppendLine(" 				( ")
            sbSQL.AppendLine(" 					SELECT TOP 1 Memo_Description ")
            sbSQL.AppendLine(" 					FROM SAL_SAMEMO ")
            sbSQL.AppendLine(" 					WHERE Memo_Orgid = PAYO_ORGID  ")
            sbSQL.AppendLine(" 						AND Memo_Seqno = PAYO_SEQNO 	 ")
            sbSQL.AppendLine(" 						AND Memo_Ym = PAYO_YYMM  ")
            sbSQL.AppendLine(" 						AND Memo_Date = PAYO_DATE  ")
            sbSQL.AppendLine(" 						AND Memo_Kind = PAYO_KIND  ")
            sbSQL.AppendLine(" 						AND Memo_Code_Type = PAYO_KIND_CODE_TYPE ")
            sbSQL.AppendLine(" 						AND memo_code_no = PAYO_KIND_CODE_NO  ")
            sbSQL.AppendLine(" 				),'') AS '備註' ")
            sbSQL.AppendLine(" FROM SAL_SAPAYO ")
            sbSQL.AppendLine(" WHERE 1=1 ")
            sbSQL.AppendLine(" AND PAYO_ORGID = @Orgcode ")
            sbSQL.AppendLine(" AND PAYO_YYMM = @YYMM ")
            sbSQL.AppendLine(" AND PAYO_KIND = '005' ")
            sbSQL.AppendLine(" AND PAYO_KIND_CODE_TYPE = '001' ")
            sbSQL.AppendLine(" AND PAYO_KIND_CODE_NO = @CODENO ")
            sbSQL.AppendLine(" ORDER BY PAYO_PRONO ")

            Dim params() As SqlParameter = { _
                New SqlParameter("@Orgcode", SqlDbType.VarChar), _
                New SqlParameter("@YYMM", SqlDbType.VarChar), _
                New SqlParameter("@CODENO", SqlDbType.VarChar)}
            params(0).Value = orgcode
            params(1).Value = YYMM
            params(2).Value = CODENO

            Return Query(sbSQL.ToString(), params)
        End Function
    End Class
End Namespace
