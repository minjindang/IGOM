Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text

Namespace PRO.Logic
    Public Class PRO2102DAO
        Inherits BaseDAO

        ''' <summary>
        ''' 回傳人員類別
        ''' </summary>
        ''' <param name="CODE_SYS">子系統別</param>
        ''' <param name="CODE_TYPE">代碼類別</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function getEmployeeTypeData(ByVal CODE_SYS As String, ByVal CODE_TYPE As String) As DataTable
            Dim szSQL As New StringBuilder

            szSQL.AppendLine(" SELECT CODE_DESC1,CODE_NO FROM SYS_CODE AS SC ")
            szSQL.AppendLine(" WHERE 1 = 1 ")
            szSQL.AppendLine(" AND SC.CODE_SYS=@CODE_SYS  ")
            szSQL.AppendLine(" AND SC.CODE_TYPE=@CODE_TYPE")

            Dim params(1) As SqlParameter
            params(0) = New SqlParameter("@CODE_SYS", SqlDbType.VarChar)
            params(0).Value = CODE_SYS
            params(1) = New SqlParameter("@CODE_TYPE", SqlDbType.VarChar)
            params(1).Value = CODE_TYPE

            Return Query(szSQL.ToString(), params)
        End Function
     
        Public Function GetReportData(ByVal CODE_SYS As String, ByVal CODE_TYPE As String, ByVal Scrap_unit As String, ByVal Property_type As String, ByVal last_dateS As String, ByVal last_dateE As String) As DataTable
            Dim szSQL As String = String.Empty

            szSQL += " SELECT "
            szSQL += " PSM.Property_clsno + PSM.Property_id AS '財產編號', "
            szSQL += " FO.Depart_name AS '申請人單位', "
            szSQL += " FP.User_name AS '申請人姓名', "
            szSQL += " PSM.Property_name AS '財產名稱', "
            szSQL += " (SELECT CODE_DESC1 FROM SYS_CODE WHERE CODE_SYS='016' AND CODE_TYPE='006' AND CODE_NO=PSM.Property_type) AS '財產別', "
            szSQL += " PSM.Location AS '放置地點', "
            szSQL += " PSM.LifeTime AS '年限', "
            szSQL += " PSM.Buy_date AS '購置日期', "
            szSQL += " PSM.AllowScrap_date AS '可報廢日期', "
            szSQL += " PSM.Scrap_date AS '報廢日期', "
            szSQL += " (SELECT CODE_DESC1 FROM SYS_CODE WHERE CODE_SYS='016' AND CODE_TYPE='005' AND CODE_NO=PSM.ScrapReason_type) AS '報廢原因', "
            szSQL += " (CONVERT(VARCHAR(12), F.last_date, 111)) AS '核準報廢日期' "
            szSQL += " FROM PRO_PropertyScrap_main PSM "
            szSQL += " INNER JOIN SYS_Flow F ON PSM.Flow_id=F.Flow_id "
            szSQL += " LEFT JOIN SYS_CODE AS SC ON PSM.Property_type=SC.CODE_NO "
            szSQL += " LEFT JOIN FSC_Org AS FO ON PSM.Scrap_unit=FO.Depart_id "
            szSQL += " LEFT JOIN FSC_Personnel AS FP ON PSM.Scrap_id=FP.Id_card "
            szSQL += " WHERE 1 = 1 "

            szSQL += " AND SC.CODE_SYS=@CODE_SYS "
            szSQL += " AND SC.CODE_TYPE=@CODE_TYPE "

            If Scrap_unit <> "" Then
                szSQL += " AND PSM.Scrap_unit=@Scrap_unit "
            End If
            If Property_type <> "" Then
                szSQL += " AND PSM.Property_type=@Property_type "
            End If
            If last_dateS <> "" Then
                szSQL += " AND F.last_date>=@last_dateS "
            End If
            If last_dateS <> "" Then
                szSQL += " AND F.last_date<=@last_dateE "
            End If

            Dim params(5) As SqlParameter
            params(0) = New SqlParameter("@Scrap_unit", SqlDbType.VarChar)
            params(0).Value = Scrap_unit
            params(1) = New SqlParameter("@Property_type", SqlDbType.VarChar)
            params(1).Value = Property_type
            params(2) = New SqlParameter("@last_dateS", SqlDbType.VarChar)
            params(2).Value = last_dateS
            params(3) = New SqlParameter("@last_dateE", SqlDbType.VarChar)
            params(3).Value = last_dateE
            params(4) = New SqlParameter("@CODE_SYS", SqlDbType.VarChar)
            params(4).Value = CODE_SYS
            params(5) = New SqlParameter("@CODE_TYPE", SqlDbType.VarChar)
            params(5).Value = CODE_TYPE

            Return Query(szSQL.ToString(), params)
        End Function

    End Class
End Namespace
