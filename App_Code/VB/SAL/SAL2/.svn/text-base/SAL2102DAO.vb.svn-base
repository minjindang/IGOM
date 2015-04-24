Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration

Namespace SALARY.Logic
    Public Class SAL2102DAO
        Inherits BaseDAO

        Public Sub New()
            MyBase.New()
        End Sub
        Dim sbSQL As New StringBuilder

        ''' <summary>
        ''' 回傳單位名稱/科別名稱
        ''' </summary>
        ''' <param name="orgcode">機關代號</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetDepart(ByVal orgcode As String) As DataTable
            sbSQL.Length = 0
            sbSQL.AppendLine(" SELECT Depart_id,Depart_name  FROM FSC_Org  ")
            sbSQL.AppendLine(" WHERE Orgcode=@orgcode  ")
            sbSQL.AppendLine(" AND Parent_depart_id IS NULL ")

            Dim param() As SqlParameter = { _
            New SqlParameter("@orgcode", orgcode)}
            Return Query(sbSQL.ToString(), param)
        End Function

        ''' <summary>
        ''' 回傳人員姓名
        ''' </summary>
        ''' <param name="orgcode">機關代硯</param>
        ''' <param name="departId">部門代碼</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetUserName(ByVal orgcode As String, ByVal departId As String) As DataTable
            sbSQL.Length = 0
            sbSQL.AppendLine(" SELECT  P.Id_card AS IDCARD,O.Depart_name +'/'+P.User_name AS USERNAME ")
            sbSQL.AppendLine(" FROM FSC_Org O LEFT JOIN FSC_Depart_emp D ON O.Depart_id =D.Depart_id ")
            sbSQL.AppendLine(" LEFT JOIN FSC_Personnel P ON P.Id_card=D.Id_card ")
            sbSQL.AppendLine(" WHERE 1 = 1 ")
            sbSQL.AppendLine(" AND (O.Depart_id=@departId OR O.Parent_depart_id=@departId) ")
            sbSQL.AppendLine(" AND P.User_name IS NOT NULL ")
            sbSQL.AppendLine(" AND O.Orgcode =@orgcode ")
            sbSQL.AppendLine("  ORDER BY P.Id_card ")

            Dim param() As SqlParameter = { _
            New SqlParameter("@orgcode", orgcode), _
            New SqlParameter("@departId", departId)}
            Return Query(sbSQL.ToString(), param)
        End Function

        ''' <summary>
        ''' 回傳資料
        ''' </summary>
        ''' <param name="Apply_yy"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetData(ByVal Apply_yy As String, ByVal PAYOD_CODE As String, ByVal Id_card As String) As DataTable
            sbSQL.Length = 0
            sbSQL.AppendLine(" SELECT ")
            sbSQL.AppendLine(" P.id_number ")
            sbSQL.AppendLine(" ,P.id_card ")
            sbSQL.AppendLine(" ,P.USER_NAME ")
            sbSQL.AppendLine(" ,(select top 1 Depart_name from FSC_org f where f.orgcode=d.orgcode and f.depart_id=d.depart_id) as Depart_name ")
            sbSQL.AppendLine(" ,isnull(sum(SD.PAYOD_AMT),0) PAYOD_AMT ")
            sbSQL.AppendLine(" FROM SAL_SAPAYOD SD ")
            sbSQL.AppendLine(" INNER JOIN FSC_Personnel P ON SD.PAYOD_SEQNO=P.Id_card ")
            sbSQL.AppendLine(" INNER JOIN FSC_Depart_emp d on p.id_card=d.id_card and service_type = '0' ")
            sbSQL.AppendLine(" WHERE SD.PAYOD_CODE_SYS='003' ")
            sbSQL.AppendLine(" AND SD.PAYOD_CODE_KIND='P' ")
            sbSQL.AppendLine(" AND SD.PAYOD_CODE_TYPE='002' ")
            sbSQL.AppendLine(" AND SD.PAYOD_CODE_NO='003' ")
            sbSQL.AppendLine(" AND SD.PAYOD_KIND='001' ")
            sbSQL.AppendLine(" AND SD.PAYOD_CODE=@PAYOD_CODE ")
            sbSQL.AppendLine(" AND substring(SD.PAYOD_YM,0,5)=@Apply_yy ")
            If Not String.IsNullOrEmpty(Id_card) Then
                sbSQL.AppendLine(" AND SD.PAYOD_SEQNO=@Id_card ")
            End If
            If PAYOD_CODE.Equals("001") Then
                sbSQL.AppendLine(" AND P.employee_type in ('1','3','8','11') ")
            ElseIf PAYOD_CODE.Equals("") Then
                sbSQL.AppendLine(" AND P.employee_type in ('2','4','5','10','12') ")
            End If
            sbSQL.AppendLine(" group by substring(SD.PAYOD_YM,0,5),d.Orgcode,d.depart_id,SD.PAYOD_SEQNO,P.id_number,P.USER_NAME,P.id_card ")

            Dim ps() As SqlParameter = { _
                New SqlParameter("@Apply_yy", Apply_yy), _
                New SqlParameter("@PAYOD_CODE", PAYOD_CODE), _
                New SqlParameter("@Id_card", Id_card)}
            Return Query(sbSQL.ToString(), ps)
        End Function

        ''' <summary>
        ''' 列印用
        ''' </summary>
        ''' <param name="Apply_yy"></param>
        ''' <param name="SpecialInquiry"></param>
        ''' <param name="Type"></param>
        ''' <param name="PAYOD_CODE"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function PrintData(ByVal Apply_yy As String, ByVal SpecialInquiry As String,ByVal Type As String, ByVal PAYOD_CODE As String) As DataTable
            sbSQL.Length = 0
            sbSQL.AppendLine(" SELECT ")
            sbSQL.AppendLine(" (SELECT Depart_name FROM FSC_ORG WHERE Depart_id=O.Parent_depart_id) AS Depart_name ")
            sbSQL.AppendLine(" ,O.Depart_name AS SUB_Depart_name ")
            sbSQL.AppendLine(" ,M.User_name ")
            sbSQL.AppendLine(" ,PR.User_id ")
            sbSQL.AppendLine(" ,SD.PAYOD_CODE ")
            sbSQL.AppendLine(" ,PR.Apply_yy ")
            sbSQL.AppendLine(" ,SD.PAYOD_AMT ")
            sbSQL.AppendLine(" ,'0' AS PAYOD_AMT1 ")
            sbSQL.AppendLine(" ,SY.family_amt ")
            sbSQL.AppendLine(" ,M.Id_card ")
            sbSQL.AppendLine(" FROM SAL_PROOF_rpt PR ")
            sbSQL.AppendLine(" INNER JOIN SYS_Flow F ON F.Flow_id=PR.Flow_id ")
            sbSQL.AppendLine(" INNER JOIN EMP_Member M ON M.ID_CARD=PR.User_id ")
            sbSQL.AppendLine(" INNER JOIN SAL_SAPAYOD SD ON PR.User_id=SD.PAYOD_SEQNO AND PR.Apply_yy=CAST(SUBSTRING(SD.PAYOD_YM,1,4)-1911 AS INT) ")
            sbSQL.AppendLine(" INNER JOIN SAL_SAFAMILY SY ON PR.User_id=SY.family_seqno ")
            sbSQL.AppendLine(" INNER JOIN FSC_ORG O ON and O.Orgcode=F.Orgcode and O.Depart_id =F.Depart_id ")

            sbSQL.AppendLine(" WHERE SD.PAYOD_CODE_SYS='003' ")
            sbSQL.AppendLine(" AND SD.PAYOD_CODE_KIND='P' ")
            sbSQL.AppendLine(" AND SD.PAYOD_CODE_TYPE='002' ")
            sbSQL.AppendLine(" AND SD.PAYOD_CODE_NO='003' ")
            sbSQL.AppendLine(" AND SD.PAYOD_KIND='001' ")
            sbSQL.AppendLine(" AND PR.Apply_yy=@Apply_yy ")


            If Type = "1" Then '依年度列印
                sbSQL.AppendLine(" AND PAYOD_CODE=@PAYOD_CODE ") '公、勞保
                sbSQL.AppendLine(" AND Last_pass='1' ") '申請流程跑完

            ElseIf Type = "2" Then '依資料列列印
                sbSQL.AppendLine(" AND User_id=@SpecialInquiry ") '以資料列的User_id查詢當年度公、勞健保資料
                sbSQL.AppendLine(" AND Last_pass='1' ") '申請流程跑完

            ElseIf Type = "3" Then '依指定人員列印
                sbSQL.AppendLine(" AND User_id=@SpecialInquiry ") '以人員身分證號查詢當年度公、勞健保資料

            End If

            Dim ps() As SqlParameter = {New SqlParameter("@Apply_yy", Apply_yy), _
                                        New SqlParameter("@SpecialInquiry", SpecialInquiry), _
                                        New SqlParameter("@PAYOD_CODE", PAYOD_CODE)}
            Return Query(sbSQL.ToString(), ps)
        End Function

        Public Function getFamily(ByVal id_card As String) As DataTable
            Dim sql As StringBuilder = New StringBuilder
            sql.AppendLine(" select family_relationship ")
            sql.AppendLine(" ,family_id ")
            sql.AppendLine(" ,family_name ")
            sql.AppendLine(" ,family_amt ")
            sql.AppendLine(" from SAL_SAFAMILY ")
            sql.AppendLine(" where family_seqno=@id_card ")

            Dim sp() As SqlParameter = {New SqlParameter("@id_card", id_card)}

            Return Query(sql.ToString(), sp)
        End Function
    End Class
End Namespace