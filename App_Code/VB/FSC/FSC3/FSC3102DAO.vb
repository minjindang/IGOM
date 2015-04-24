Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient 

Namespace FSC.Logic
    Public Class FSC3102DAO
        Inherits BaseDAO

        Dim SQL As String = ""

        ''' <summary>
        ''' 取得人員資料
        ''' </summary>
        ''' <param name="Orgcode">機關代碼</param>
        ''' <param name="DepartID">單位代碼</param>
        ''' <param name="IDCard">人員編號</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function Get_Member(ByVal Orgcode As String, ByVal DepartID As String, ByVal IDCard As String) As DataTable
            SQL = " SELECT Orgcode, d.id_card, USER_NAME"
            SQL &= " ,isnull((select TOP 1 depart_name from FSC_org f1 where f1.Orgcode = d.Orgcode and f1.Depart_id = d.Depart_id),'') as depart_name"
            SQL &= " ,(select CODE_DESC1 from SYS_CODE sc where sc.CODE_NO = p.Title_no and sc.CODE_SYS='023' and sc.CODE_TYPE='012') as title_name"
            SQL &= " FROM FSC_deputy_det d "
            SQL &= " inner join FSC_personnel p on d.id_card = p.id_card "
            SQL &= " where 1= 1 "

            If Orgcode <> Nothing And Orgcode <> "" Then SQL &= " AND d.Orgcode=@Orgcode "
            If DepartID <> Nothing And DepartID <> "" Then
                SQL &= " AND (d.Depart_id=@DepartID or d.Depart_id in (select depart_id from fsc_org where parent_depart_id=@DepartID)) "
            End If
            If IDCard <> Nothing And IDCard <> "" Then SQL &= " AND d.Id_card=@IDCard "

            SQL &= " Group by d.Orgcode, d.Depart_id, p.Title_no ,d.id_card, USER_NAME "
            SQL &= " ORDER BY d.Orgcode, d.Depart_id, p.Title_no "

            Dim aryParms(2) As SqlParameter
            aryParms(0) = New SqlParameter("@Orgcode", SqlDbType.VarChar)
            aryParms(0).Value = Orgcode
            aryParms(1) = New SqlParameter("@DepartID", SqlDbType.VarChar)
            aryParms(1).Value = DepartID
            aryParms(2) = New SqlParameter("@IDCard", SqlDbType.VarChar)
            aryParms(2).Value = IDCard
            DBUtil.SetParamsNull(aryParms)
            Return Query(SQL, aryParms)
        End Function

        ''' <summary>
        ''' 取得 代理人資料
        ''' </summary>
        ''' <param name="Orgcode">機關代碼</param>
        ''' <param name="ID_Card">人員編號</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function Get_Deputy(ByVal Orgcode As String, ByVal ID_Card As String) As DataTable
            SQL = " SELECT * "
            SQL &= " ,(select top 1 title_no from FSC_personnel mm where mm.ID_Card = @IDCard) as user_title_no "
            SQL &= " ,(select top 1 sc.CODE_DESC1 from FSC_personnel mm INNER JOIN SYS_CODE sc ON sc.CODE_NO=mm.title_no and sc.CODE_SYS='023' and sc.CODE_TYPE='012' where mm.ID_Card = @IDCard) as user_title "
            SQL &= " ,sc.CODE_DESC1 as title_name "
            SQL &= " FROM FSC_Deputy_det d "
            SQL &= " INNER JOIN FSC_personnel m "
            SQL &= " ON d.Deputy_idcard = m.ID_card"
            SQL &= " and d.Orgcode = @Orgcode"
            SQL &= " INNER JOIN SYS_CODE sc ON sc.CODE_NO = m.title_no and sc.CODE_SYS='023' and sc.CODE_TYPE='012' "
            SQL &= " WHERE d.ID_Card = @IDCard "
            SQL &= " Order by Deputy_seq, d.Deputy_IDCard "

            Dim aryParms(1) As SqlParameter
            aryParms(0) = New SqlParameter("@OrgCode", SqlDbType.VarChar)
            aryParms(0).Value = Orgcode
            aryParms(1) = New SqlParameter("@IDCard", SqlDbType.VarChar)
            aryParms(1).Value = ID_Card
            DBUtil.SetParamsNull(aryParms)
            Return Query(SQL, aryParms)
        End Function

        ''' <summary>
        ''' 回傳 順序最大值
        ''' </summary>
        ''' <param name="Orgcode">機關代碼</param>
        ''' <param name="ID_Card">人員編號</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetMaxDeputySeq(ByVal Orgcode As String, ByVal ID_Card As String) As DataTable
            SQL = " SELECT CONVERT(INT,ISNULL(MAX(Deputy_seq),0))+1 AS MAXSEQ "
            SQL &= " FROM FSC_Deputy_det"
            SQL &= " WHERE 1 = 1"
            SQL &= " AND Orgcode=@OrgCode "
            SQL &= " AND Id_card=@IDCard  "

            Dim aryParms(1) As SqlParameter
            aryParms(0) = New SqlParameter("@OrgCode", SqlDbType.VarChar)
            aryParms(0).Value = Orgcode
            aryParms(1) = New SqlParameter("@IDCard", SqlDbType.VarChar)
            aryParms(1).Value = ID_Card
            DBUtil.SetParamsNull(aryParms)
            Return Query(SQL, aryParms)
        End Function

        ''' <summary>
        ''' 回傳 輸入的順序是否存在
        ''' </summary>
        ''' <param name="Orgcode">機關代碼</param>
        ''' <param name="ID_Card">人員編號</param>
        ''' <param name="Deputy_seq">順序</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetDataExist(ByVal Orgcode As String, ByVal ID_Card As String, ByVal Deputy_seq As String) As DataTable
            SQL = " SELECT TOP 1 id "
            SQL &= " FROM FSC_Deputy_det "
            SQL &= " WHERE 1 = 1"
            SQL &= " AND Orgcode=@OrgCode "
            SQL &= " AND Id_card=@IDCard  "
            SQL &= " AND Deputy_seq=@Deputy_seq  "

            Dim aryParms(2) As SqlParameter
            aryParms(0) = New SqlParameter("@OrgCode", SqlDbType.VarChar)
            aryParms(0).Value = Orgcode
            aryParms(1) = New SqlParameter("@IDCard", SqlDbType.VarChar)
            aryParms(1).Value = ID_Card
            aryParms(2) = New SqlParameter("@Deputy_seq", SqlDbType.VarChar)
            aryParms(2).Value = Deputy_seq
            DBUtil.SetParamsNull(aryParms)
            Return Query(SQL, aryParms)
        End Function

        Public Function updateDefaultToMax(ByVal id As String, ByVal Deputy_seq As String) As Integer
            Dim sql As StringBuilder = New StringBuilder
            sql.AppendLine(" update FSC_Deputy_det set ")
            sql.AppendLine(" Deputy_seq=@Deputy_seq, ")
            sql.AppendLine(" Deputy_flag = '0' ")
            sql.AppendLine(" where id=@id ")

            Dim aryParms(1) As SqlParameter
            aryParms(0) = New SqlParameter("@Deputy_seq", SqlDbType.VarChar)
            aryParms(0).Value = Deputy_seq
            aryParms(1) = New SqlParameter("@id", SqlDbType.VarChar)
            aryParms(1).Value = id

            Return Execute(sql.ToString(), aryParms)
        End Function
    End Class
End Namespace