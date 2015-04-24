Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient

Public Class SAL2214DAO
    Inherits BaseDAO

    Public Function getData(ByVal ENGF_YY As String, ByVal BASE_ORGID As String, ByVal BASE_SEQNO As String) As DataTable
        Dim sb As StringBuilder = New StringBuilder
        sb.AppendLine(" SELECT A.*, B.base_name  ")
        sb.AppendLine(" FROM  SAL_SAENGF A, SAL_SABASE B ")
        sb.AppendLine(" WHERE ENGF_YY=@ENGF_YY ")
        sb.AppendLine(" AND A.ENGF_SEQNO=B.BASE_SEQNO ")
        sb.AppendLine(" AND A.engf_orgid=B.base_orgid ")
        sb.AppendLine(" AND B.BASE_ORGID=@BASE_ORGID ")
        sb.AppendLine(" and B.BASE_SEQNO=@BASE_SEQNO ")
        sb.AppendLine(" order by isNull(base_prts,99999) ")
        Dim params() As SqlParameter = {New SqlParameter("@ENGF_YY", ENGF_YY), _
                                        New SqlParameter("@BASE_ORGID", BASE_ORGID), _
                                        New SqlParameter("@BASE_SEQNO", BASE_SEQNO)}
        Return Query(sb.ToString(), params)
    End Function

End Class
