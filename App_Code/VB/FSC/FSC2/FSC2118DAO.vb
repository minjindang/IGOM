Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text

Namespace FSC.Logic
    Public Class FSC2118DAO
        Inherits BaseDAO

        ''' <summary>
        ''' 回傳敍獎申請資料檔
        ''' </summary>
        ''' <param name="CODE_SYS">子系統別</param>
        ''' <param name="CODE_TYPE">代碼類別</param>
        ''' <param name="Dept">提報單位</param>
        ''' <param name="CouncilDateStart">考績會日期起日</param>
        ''' <param name="CouncilDateEnd">考績會日期迄日</param>
        ''' <param name="ApplyDateStart">提報日期起日</param>
        ''' <param name="ApplyDateEnd">提報日期迄日</param>
        ''' <param name="RewordDateStart">獎勵令日期起日</param>
        ''' <param name="RewordDateEnd">獎勵令日期迄日</param>
        ''' <param name="RewordDoc">獎勵令文號</param>
        ''' <param name="RewordDepartID">獎懲人員單位代碼</param>
        ''' <param name="RewordLevel">官職等</param>
        ''' <returns>項次,提報單位,提報日期,獎勵令日期,獎勵令文號,獎懲人員單位,獎懲人員姓名,獎懲人員官職等</returns>
        ''' <remarks></remarks>
        Public Function GetData(ByVal CODE_SYS As String, ByVal CODE_TYPE As String, ByVal Dept As String, ByVal CouncilDateStart As String, ByVal CouncilDateEnd As String, _
                                ByVal ApplyDateStart As String, ByVal ApplyDateEnd As String, ByVal RewordDateStart As String, ByVal RewordDateEnd As String, ByVal RewordDoc As String, _
                                ByVal RewordDepartID As String, ByVal RewordLevel As String) As DataTable

            Dim szSQL As New StringBuilder

            szSQL.AppendLine(" SELECT  ")
            szSQL.AppendLine(" RANK() OVER (ORDER BY RD.Reword_departid, RD.Reword_Level DESC) AS Num, ")
            szSQL.AppendLine(" (select top 1 Depart_name from FSC_ORG AS FO where RM.Depart_id=FO.Depart_id) AS DepartName,  ")
            szSQL.AppendLine(" (SUBSTRING (RM.Apply_date, 1, 3) + '/'+ SUBSTRING (RM.Apply_date, 4, 2) +'/'+ SUBSTRING (RM.Apply_date, 6, 2))  AS ApplyDate, ")
            szSQL.AppendLine(" (SUBSTRING (RM.Reword_date, 1, 3) + '/'+ SUBSTRING (RM.Reword_date, 4, 2) +'/'+ SUBSTRING (RM.Reword_date, 6, 2)) AS RewordDate, ")
            szSQL.AppendLine(" RM.Reword_Doc AS RewordDoc, ")
            szSQL.AppendLine(" (select top 1 FO2.Depart_name from FSC_ORG AS FO2 where RD.Reword_departid=FO2.Depart_id) AS RewordDepartName, ")
            szSQL.AppendLine(" RD.Reword_username AS RewordUserName, ")
            szSQL.AppendLine(" (select top 1 SC.CODE_DESC1 from SYS_CODE AS SC where SC.CODE_NO=RD.Reword_Level AND SC.CODE_SYS=@CODE_SYS AND SC.CODE_TYPE=@CODE_TYPE) AS RewordLevel ")
            szSQL.AppendLine(" FROM FSC_Reword_main AS RM ")
            szSQL.AppendLine(" INNER JOIN SYS_Flow sf on sf.flow_id = RM.flow_id and sf.case_status not in (2, 3, 4) ")
            szSQL.AppendLine(" LEFT JOIN FSC_Reword_det AS RD ON RM.flow_id=RD.flow_id")
            szSQL.AppendLine(" WHERE 1 = 1 ")

            If Not String.IsNullOrEmpty(Dept) Then
                szSQL.AppendLine(" AND (RM.Depart_id = @Dept or RM.Depart_id in (select depart_id from fsc_org where parent_depart_id=@Dept))")
            End If

            If Not String.IsNullOrEmpty(CouncilDateStart) Then
                szSQL.AppendLine(" AND RM.Council_date >= @CouncilDateStart  ")
            End If

            If Not String.IsNullOrEmpty(CouncilDateEnd) Then
                szSQL.AppendLine(" AND RM.Council_date <= @CouncilDateEnd  ")
            End If

            If Not String.IsNullOrEmpty(ApplyDateStart) Then
                szSQL.AppendLine(" AND RM.Apply_date >= @ApplyDateStart  ")
            End If

            If Not String.IsNullOrEmpty(ApplyDateEnd) Then
                szSQL.AppendLine(" AND RM.Apply_date <= @ApplyDateEnd  ")
            End If

            If Not String.IsNullOrEmpty(RewordDateStart) Then
                szSQL.AppendLine(" AND RM.Reword_date >= @RewordDateStart  ")
            End If

            If Not String.IsNullOrEmpty(RewordDateEnd) Then
                szSQL.AppendLine(" AND RM.Reword_date <= @RewordDateEnd  ")
            End If

            If Not String.IsNullOrEmpty(RewordDoc) Then
                szSQL.AppendLine(" AND RM.Reword_Doc=@RewordDoc  ")
            End If

            If Not String.IsNullOrEmpty(RewordDepartID) Then
                szSQL.AppendLine(" AND RD.Reword_departid=@RewordDepartID  ")
            End If

            If Not String.IsNullOrEmpty(RewordLevel) Then
                szSQL.AppendLine(" AND RD.Reword_Level=@RewordLevel  ")
            End If

            szSQL.AppendLine(" order by RD.Reword_departid, RD.Reword_Level desc ")

            Dim params(11) As SqlParameter
            params(0) = New SqlParameter("@CODE_SYS", SqlDbType.VarChar)
            params(0).Value = CODE_SYS
            params(1) = New SqlParameter("@CODE_TYPE", SqlDbType.VarChar)
            params(1).Value = CODE_TYPE
            params(2) = New SqlParameter("@Dept", SqlDbType.VarChar)
            params(2).Value = Dept
            params(3) = New SqlParameter("@CouncilDateStart", SqlDbType.VarChar)
            params(3).Value = CouncilDateStart
            params(4) = New SqlParameter("@CouncilDateEnd", SqlDbType.VarChar)
            params(4).Value = CouncilDateEnd
            params(5) = New SqlParameter("@ApplyDateStart", SqlDbType.VarChar)
            params(5).Value = ApplyDateStart
            params(6) = New SqlParameter("@ApplyDateEnd", SqlDbType.VarChar)
            params(6).Value = ApplyDateEnd
            params(7) = New SqlParameter("@RewordDateStart", SqlDbType.VarChar)
            params(7).Value = RewordDateStart
            params(8) = New SqlParameter("@RewordDateEnd", SqlDbType.VarChar)
            params(8).Value = RewordDateEnd
            params(9) = New SqlParameter("@RewordDoc", SqlDbType.VarChar)
            params(9).Value = RewordDoc
            params(10) = New SqlParameter("@RewordDepartID", SqlDbType.VarChar)
            params(10).Value = RewordDepartID
            params(11) = New SqlParameter("@RewordLevel", SqlDbType.VarChar)
            params(11).Value = RewordLevel

            Return Query(szSQL.ToString(), params)
        End Function

        ''' <summary>
        ''' 回傳敍獎申請資料檔
        ''' </summary>
        ''' <param name="strCheckBox">子系統別</param>
        ''' <param name="Dept">提報單位</param>
        ''' <param name="CouncilDateStart">考績會日期起日</param>
        ''' <param name="CouncilDateEnd">考績會日期迄日</param>
        ''' <param name="ApplyDateStart">提報日期起日</param>
        ''' <param name="ApplyDateEnd">提報日期迄日</param>
        ''' <param name="RewordDateStart">獎勵令日期起日</param>
        ''' <param name="RewordDateEnd">獎勵令日期迄日</param>
        ''' <param name="RewordDoc">獎勵令文號</param>
        ''' <param name="RewordDepartID">獎懲人員單位代碼</param>
        ''' <param name="RewordLevel">官職等</param>
        ''' <returns>項次,提報單位,提報日期,獎勵令日期,獎勵令文號,獎懲人員單位,獎懲人員姓名,獎懲人員官職等</returns>
        ''' <remarks></remarks>
        Public Function GetReportData(ByVal strCheckBox() As String, ByVal Dept As String, ByVal CouncilDateStart As String, ByVal CouncilDateEnd As String, _
                                ByVal ApplyDateStart As String, ByVal ApplyDateEnd As String, ByVal RewordDateStart As String, ByVal RewordDateEnd As String, ByVal RewordDoc As String, _
                                ByVal RewordDepartID As String, ByVal RewordLevel As String) As DataTable

            Dim szSQL As New StringBuilder

            szSQL.AppendLine(" SELECT  ")
            szSQL.AppendLine(" RANK() OVER (ORDER BY RD.ID DESC) AS '項次' ")

            If strCheckBox(0).ToUpper = "TRUE" Then
                szSQL.AppendLine(" ,FO.Depart_name AS '提報單位'  ")
            End If
            If strCheckBox(1).ToUpper = "TRUE" Then
                szSQL.AppendLine(" ,SC4.CODE_DESC1 AS '人員類別' ")
            End If
            If strCheckBox(2).ToUpper = "TRUE" Then
                szSQL.AppendLine(" ,RM.Reword_Doc AS '獎懲令文號' ")
            End If
            If strCheckBox(3).ToUpper = "TRUE" Then
                szSQL.AppendLine(" ,RM.Reason_type AS '適用事由類別' ")
            End If
            If strCheckBox(4).ToUpper = "TRUE" Then
                szSQL.AppendLine(" ,RM.Innovative_desc AS '創新性' ")
            End If
            If strCheckBox(5).ToUpper = "TRUE" Then
                szSQL.AppendLine(" ,FO2.Depart_name AS '敘獎人員單位' ")
            End If
            If strCheckBox(6).ToUpper = "TRUE" Then
                szSQL.AppendLine(" ,SC1.CODE_DESC1 AS '官職等' ")
            End If
            If strCheckBox(7).ToUpper = "TRUE" Then
                szSQL.AppendLine(" ,(SUBSTRING (RM.Apply_date, 1, 3) + '/'+ SUBSTRING (RM.Apply_date, 4, 2) +'/'+ SUBSTRING (RM.Apply_date, 6, 2))  AS '提報日期' ")
            End If
            If strCheckBox(8).ToUpper = "TRUE" Then
                szSQL.AppendLine(" ,RM.Self_ssessment_point AS '自評點數' ")
            End If
            If strCheckBox(9).ToUpper = "TRUE" Then
                szSQL.AppendLine(" ,RM.Difficulty_desc AS '困難度' ")
            End If
            If strCheckBox(10).ToUpper = "TRUE" Then
                szSQL.AppendLine(" ,RD.Reword_username AS '敘獎人姓名' ")
            End If
            If strCheckBox(11).ToUpper = "TRUE" Then
                szSQL.AppendLine(" ,SC2.CODE_DESC1 AS '獎懲種類' ")
            End If
            If strCheckBox(12).ToUpper = "TRUE" Then
                szSQL.AppendLine(" ,RD.Specific_facts AS '敘獎事由' ")
            End If
            If strCheckBox(13).ToUpper = "TRUE" Then
                szSQL.AppendLine(" ,RM.Last_point AS '最近一次相關案例敘獎點數' ")
            End If
            If strCheckBox(14).ToUpper = "TRUE" Then
                szSQL.AppendLine(" ,RM.Contribution_desc AS '貢獻度(成效)' ")
            End If
            If strCheckBox(15).ToUpper = "TRUE" Then
                szSQL.AppendLine(" ,SC3.CODE_DESC1 AS '職稱' ")
            End If
            If strCheckBox(16).ToUpper = "TRUE" Then
                szSQL.AppendLine(" ,(SUBSTRING (RM.Reword_date, 1, 3) + '/'+ SUBSTRING (RM.Reword_date, 4, 2) +'/'+ SUBSTRING (RM.Reword_date, 6, 2)) AS '獎懲令日期' ")
            End If

            szSQL.AppendLine(" FROM FSC_Reword_main AS RM LEFT JOIN FSC_Reword_det AS RD ON RM.flow_id=RD.flow_id  ")
            szSQL.AppendLine(" LEFT JOIN FSC_ORG AS FO ON RM.Depart_id=FO.Depart_id ")
            szSQL.AppendLine(" LEFT JOIN FSC_ORG AS FO2 ON RD.Reword_departid=FO2.Depart_id ")
            szSQL.AppendLine(" LEFT JOIN SYS_CODE AS SC1 ON SC1.CODE_NO=RD.Reword_Level AND (SC1.CODE_SYS='002' AND SC1.CODE_TYPE='006') ") ' 官職等
            szSQL.AppendLine(" LEFT JOIN SYS_CODE AS SC2 ON SC2.CODE_NO=RD.Reword_type AND (SC2.CODE_SYS='023' AND SC2.CODE_TYPE='028') ") ' 獎懲種類
            szSQL.AppendLine(" LEFT JOIN SYS_CODE AS SC3 ON SC3.CODE_NO=RD.Reword_Title_no AND (SC3.CODE_SYS='023' AND SC3.CODE_TYPE='012') ") ' 職稱
            szSQL.AppendLine(" LEFT JOIN SYS_CODE AS SC4 ON SC4.CODE_NO=RD.Reword_Employee_type AND (SC4.CODE_SYS='002' AND SC4.CODE_TYPE='002') ") ' 人員類別
            szSQL.AppendLine(" WHERE 1 = 1 ")


            If Not String.IsNullOrEmpty(Dept) Then
                szSQL.AppendLine(" AND RM.Depart_id=@Dept  ")
            End If

            If Not String.IsNullOrEmpty(CouncilDateStart) Then
                szSQL.AppendLine(" AND RM.Council_date >= @CouncilDateStart  ")
            End If

            If Not String.IsNullOrEmpty(CouncilDateEnd) Then
                szSQL.AppendLine(" AND RM.Council_date <= @CouncilDateEnd  ")
            End If

            If Not String.IsNullOrEmpty(ApplyDateStart) Then
                szSQL.AppendLine(" AND RM.Apply_date >= @ApplyDateStart  ")
            End If

            If Not String.IsNullOrEmpty(ApplyDateEnd) Then
                szSQL.AppendLine(" AND RM.Apply_date <= @ApplyDateEnd  ")
            End If

            If Not String.IsNullOrEmpty(RewordDateStart) Then
                szSQL.AppendLine(" AND RM.Reword_date >= @RewordDateStart  ")
            End If

            If Not String.IsNullOrEmpty(RewordDateEnd) Then
                szSQL.AppendLine(" AND RM.Reword_date <= @RewordDateEnd  ")
            End If

            If Not String.IsNullOrEmpty(RewordDoc) Then
                szSQL.AppendLine(" AND RM.Reword_Doc=@RewordDoc  ")
            End If

            If Not String.IsNullOrEmpty(RewordDepartID) Then
                szSQL.AppendLine(" AND RD.Reword_departid=@RewordDepartID  ")
            End If

            If Not String.IsNullOrEmpty(RewordLevel) Then
                szSQL.AppendLine(" AND RM.Reword_Level=@RewordLevel  ")
            End If

            Dim params(9) As SqlParameter
            params(1) = New SqlParameter("@Dept", SqlDbType.VarChar)
            params(1).Value = Dept
            params(2) = New SqlParameter("@CouncilDateStart", SqlDbType.VarChar)
            params(2).Value = CouncilDateStart
            params(3) = New SqlParameter("@CouncilDateEnd", SqlDbType.VarChar)
            params(3).Value = CouncilDateEnd
            params(4) = New SqlParameter("@ApplyDateStart", SqlDbType.VarChar)
            params(4).Value = ApplyDateStart
            params(5) = New SqlParameter("@ApplyDateEnd", SqlDbType.VarChar)
            params(5).Value = ApplyDateEnd
            params(6) = New SqlParameter("@RewordDateStart", SqlDbType.VarChar)
            params(6).Value = RewordDateStart
            params(7) = New SqlParameter("@RewordDateEnd", SqlDbType.VarChar)
            params(7).Value = RewordDateEnd
            params(8) = New SqlParameter("@RewordDoc", SqlDbType.VarChar)
            params(8).Value = RewordDoc
            params(9) = New SqlParameter("@RewordDepartID", SqlDbType.VarChar)
            params(9).Value = RewordDepartID
            params(0) = New SqlParameter("@RewordLevel", SqlDbType.VarChar)
            params(0).Value = RewordLevel

            Return Query(szSQL.ToString(), params)
        End Function

    End Class
End Namespace
