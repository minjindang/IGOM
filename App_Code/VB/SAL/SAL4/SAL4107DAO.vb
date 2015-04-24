Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text

Namespace SAL.Logic
    Public Class SAL4107DAO
        Inherits BaseDAO

        ''' <summary>
        ''' 回傳資料
        ''' </summary>
        ''' <param name="orgcode"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function getQueryData(ByVal orgcode As String, ByVal JOB_ITEM As String, ByVal PAY_DATE As String) As DataTable
            Dim sbSQL As New StringBuilder()
            sbSQL.AppendLine("SELECT JOB_NO,JOB_YM,JOB_ITEM,JOB_STATUS,JOB_PAY_DATE,job_starttime,job_stoptime,job_userid, job_orgid,User_name ")
            sbSQL.AppendLine(",(SELECT code_desc1 FROM SYS_CODE WHERE code_sys='009' AND code_type='**' AND code_no=JOB_ITEM) AS item_name ")
            sbSQL.AppendLine(",CASE JOB_STATUS WHEN '' THEN '' ")
            sbSQL.AppendLine("WHEN 'W' THEN '等待處理' ")
            sbSQL.AppendLine("WHEN 'E' THEN '讀取資料' ")
            sbSQL.AppendLine("WHEN 'C' THEN '計算中' ")
            sbSQL.AppendLine("WHEN 'F' THEN '完成工作' ")
            sbSQL.AppendLine("ELSE '計算失敗' END AS status_name ")
            sbSQL.AppendLine("FROM SAL_SABATJOB WITH(NOLOCK) LEFT JOIN FSC_Personnel ON SAL_SABATJOB.JOB_USERID=FSC_Personnel.ID_CARD ")
            sbSQL.AppendLine("WHERE 1=1 ")
            sbSQL.AppendLine("AND JOB_ORGID=@orgcode ")

            If Not String.IsNullOrEmpty(JOB_ITEM) Then
                sbSQL.AppendLine("AND JOB_ITEM=@JOB_ITEM ")
            End If

            If Not String.IsNullOrEmpty(PAY_DATE) Then
                sbSQL.AppendLine("AND JOB_PAY_DATE=@PAY_DATE ")
            End If

            sbSQL.AppendLine("ORDER BY JOB_BOOKTIME DESC ")

            Dim param() As SqlParameter = { _
            New SqlParameter("@orgcode", orgcode), _
            New SqlParameter("@JOB_ITEM", JOB_ITEM), _
            New SqlParameter("@PAY_DATE", PAY_DATE)}
            Return Query(sbSQL.ToString(), param)
        End Function

       
    End Class
End Namespace
