Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text

Namespace FSC.Logic
    Public Class FSC2119DAO
        Inherits BaseDAO

        ''' <summary>
        ''' 回傳敍獎申請資料檔-提報單位
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetRewordDepart() As DataTable
            Dim szSQL As New StringBuilder

            szSQL.AppendLine(" SELECT DISTINCT FO.Depart_id AS DepartID,FO.Depart_name AS DepartName  ")
            szSQL.AppendLine(" FROM FSC_Reword_main AS RM ")
            szSQL.AppendLine(" INNER JOIN SYS_Flow F ON F.Flow_id=RM.Flow_id ")
            szSQL.AppendLine(" LEFT JOIN FSC_ORG AS FO ON RM.Depart_id=FO.Depart_id ")
            szSQL.AppendLine(" ORDER BY FO.Depart_id ")

            Return Query(szSQL.ToString())
        End Function

        ''' <summary>
        ''' 回傳敍獎申請資料檔-考績會名稱
        ''' </summary>
        ''' <param name="Dept">提報單位</param>
        ''' <param name="CouncilDateStart">考績會日期起日</param>
        ''' <param name="CouncilDateEnd">考績會日期迄日</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetRewordCouncilName(ByVal Dept As String, ByVal CouncilDateStart As String, ByVal CouncilDateEnd As String) As DataTable
            Dim szSQL As String = String.Empty

            szSQL += " SELECT  DISTINCT RM.Council_name  "
            szSQL += " FROM FSC_Reword_main AS RM  "
            szSQL += " WHERE 1 = 1 "

            If Not String.IsNullOrEmpty(Dept) Then
                szSQL += " AND RM.Depart_id IN ( " + Dept + ")"
            End If

            If Not String.IsNullOrEmpty(CouncilDateStart) Then
                szSQL += " AND RM.Council_date >= " + CouncilDateStart
            End If

            If Not String.IsNullOrEmpty(CouncilDateEnd) Then
                szSQL += " AND RM.Council_date <= " + CouncilDateEnd
            End If

            szSQL += " ORDER BY RM.Council_name "
            Return Query(szSQL.ToString())
        End Function

        ''' <summary>
        ''' 回傳敍獎申請資料檔【敘獎提案統計表】
        ''' </summary>
        ''' <param name="Dept">提報單位</param>
        ''' <param name="CouncilDateStart">考績會日期起日</param>
        ''' <param name="CouncilDateEnd">考績會日期迄日</param>
        ''' <param name="dtTable">考績會名稱</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetReportData01(ByVal Dept As String, ByVal CouncilDateStart As String, ByVal CouncilDateEnd As String, ByVal dtTable As DataTable) As DataTable
            Dim szSQL As String = String.Empty
            Dim szCouncilName As String = String.Empty

            szSQL += " Select DISTINCT "
            szSQL += " RANK() OVER (ORDER BY FO.Depart_name) AS '編號', "
            szSQL += " FO.Depart_name AS '處室' "

            If IsNothing(dtTable) = False And dtTable.Rows.Count > 0 Then
                For index = 0 To dtTable.Rows.Count - 1
                    szCouncilName = dtTable.Rows(index)("Council_name").ToString()
                    szSQL += " ,COUNT(Case RM.Council_name WHEN  '" + szCouncilName + "'  THEN '" + szCouncilName + "' END) AS '" + szCouncilName + "' "
                Next
            End If

            szSQL += " FROM FSC_Reword_main AS RM LEFT JOIN FSC_Reword_det AS RD ON RM.flow_id=RD.flow_id  "
            szSQL += " LEFT JOIN FSC_ORG AS FO ON RM.Depart_id=FO.Depart_id "
            szSQL += " WHERE 1 = 1 "

            If Not String.IsNullOrEmpty(Dept) Then
                szSQL += " AND RM.Depart_id IN ( " + Dept + ")"
            End If

            If Not String.IsNullOrEmpty(CouncilDateStart) Then
                szSQL += " AND RM.Council_date >= " + CouncilDateStart
            End If

            If Not String.IsNullOrEmpty(CouncilDateEnd) Then
                szSQL += " AND RM.Council_date <= " + CouncilDateEnd
            End If

            szSQL += " GROUP BY FO.Depart_name "
            Return Query(szSQL.ToString())
        End Function

        ''' <summary>
        ''' 回傳敍獎申請資料檔【敘獎統計表】
        ''' </summary>
        ''' <param name="Dept">提報單位</param>
        ''' <param name="CouncilDateStart">考績會日期起日</param>
        ''' <param name="CouncilDateEnd">考績會日期迄日</param>
        ''' <param name="dtTable">考績會名稱</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetReportData02(ByVal Dept As String, ByVal CouncilDateStart As String, ByVal CouncilDateEnd As String, ByVal dtTable As DataTable) As DataTable
            Dim szSQL As String = String.Empty
            Dim szCouncilName As String = String.Empty

            szSQL += " Select DISTINCT "
            szSQL += " RANK() OVER (ORDER BY FO.Depart_name,SC2.CODE_DESC1) AS '編號', "
            szSQL += " FO.Depart_name AS '處室', "
            szSQL += " SC2.CODE_DESC1 AS '獎度' "
            If IsNothing(dtTable) = False And dtTable.Rows.Count > 0 Then
                For index = 0 To dtTable.Rows.Count - 1
                    szCouncilName = dtTable.Rows(index)("Council_name").ToString()
                    szSQL += " ,COUNT(Case RM.Council_name WHEN  '" + szCouncilName + "'  THEN SC2.CODE_DESC1 END) AS '" + szCouncilName + "' "
                Next
            End If

            szSQL += " FROM FSC_Reword_det AS RD LEFT JOIN FSC_ORG AS FO ON RD.Reword_departid=FO.Depart_id  "
            szSQL += " LEFT JOIN SYS_CODE AS SC2 ON RD.Reword_type=SC2.CODE_NO "
            szSQL += " LEFT JOIN FSC_Reword_main AS RM ON RM.flow_id=RD.flow_id "
            szSQL += " WHERE 1 = 1 "
            szSQL += " AND (SC2.CODE_SYS='023' AND SC2.CODE_TYPE='028') "

            If Not String.IsNullOrEmpty(Dept) Then
                szSQL += " AND RM.Depart_id IN ( " + Dept + ")"
            End If

            If Not String.IsNullOrEmpty(CouncilDateStart) Then
                szSQL += " AND RM.Council_date >= " + CouncilDateStart
            End If

            If Not String.IsNullOrEmpty(CouncilDateEnd) Then
                szSQL += " AND RM.Council_date <= " + CouncilDateEnd
            End If

            szSQL += " GROUP BY FO.Depart_name,SC2.CODE_DESC1 "
            Return Query(szSQL.ToString())
        End Function

    End Class
End Namespace
