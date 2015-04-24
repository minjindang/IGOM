Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text

Namespace SYS.Logic
    Public Class SYS3113DAO
        Inherits BaseDAO

        ''' <summary>
        ''' 回傳功能名稱-父選單
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetFuncFlag() As DataTable
            Dim szSQL As String = String.Empty
            szSQL &= " SELECT DISTINCT (select top 1 Func_name from SYS_Func f2 where f2.Func_id =f.parent_func_id ) + '-' + Func_name Func_name, "
            szSQL &= " Func_id FROM SYS_Func f WHERE Visable_type = 'Y' "
            szSQL &= " and parent_func_id <> '0' and parent_func_id in (select Func_id from SYS_Func where parent_func_id = 'IGSS0000') Order by Func_id "

            Return Query(szSQL.ToString())
        End Function

        Public Function GetFuncName(ByVal Func_id As String) As DataTable
            Dim szSQL As String = String.Empty
            szSQL &= " SELECT Func_id,Func_name FROM SYS_Func WHERE Func_type = 'I' and Parent_func_id=@Func_id "

            Dim params(0) As SqlParameter
            params(0) = New SqlParameter("@Func_id", SqlDbType.VarChar)
            params(0).Value = Func_id

            Return Query(szSQL.ToString(), params)
        End Function

        ''' <summary>
        ''' 回傳單位名稱與功能選單狀態
        ''' </summary>
        ''' <param name="Func_Flag">申請作業名稱</param>
        ''' <param name="Func_id">申請作業名稱</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetDepartName(ByVal Func_Flag As String, ByVal Func_id As String) As DataTable
            Dim szSQL As String = String.Empty
            szSQL &= " SELECT distinct FO.Depart_id,FO.Depart_name,SF.Func_name,SF.Func_id,ISNULL(SOFF.isFreeze,0) isFreeze "
            szSQL &= " FROM SYS_Func SF,FSC_ORG FO "
            szSQL &= " LEFT JOIN "
            szSQL &= " ("
            szSQL &= " SELECT Depart_id,Func_id,isFreeze FROM SYS_Freeze_Func FF WHERE FF.Func_id=@Func_id "
            szSQL &= " ) SOFF "
            szSQL &= " ON FO.Depart_id=SOFF.Depart_id or SOFF.Depart_id in (select f.Depart_id from FSC_org f where f.parent_depart_id=FO.Depart_id) "
            szSQL &= " WHERE 1 = 1 "
            szSQL &= " AND FO.Parent_depart_id IS NULL "
            szSQL &= " AND SF.Func_id=@Func_id "
            szSQL &= " ORDER BY FO.Depart_id "

            Dim params(0) As SqlParameter
            params(0) = New SqlParameter("@Func_id", SqlDbType.VarChar)
            params(0).Value = Func_id

            Return Query(szSQL.ToString(), params)
        End Function

        ''' <summary>
        ''' 新增功能選單狀態(新增前，如資料存在，則先刪除)
        ''' </summary>
        ''' <param name="Orgcode">機關代碼</param>
        ''' <param name="Depart_id">單位代碼</param>
        ''' <param name="Func_id">功能代碼</param>
        ''' <param name="isFreeze">是否鎖定</param>
        ''' <param name="Change_userid">異動人員</param>
        ''' <param name="Change_date">異動日期</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function InsertData(ByVal Orgcode As String, ByVal Depart_id As String, ByVal Func_id As String, ByVal isFreeze As String, ByVal Change_userid As String, ByVal Change_date As DateTime) As Integer
            Dim szSQL As New StringBuilder()

            szSQL.AppendLine(" DELETE SYS_Freeze_Func WHERE Orgcode=@Orgcode AND Func_id=@Func_id ")
            szSQL.AppendLine(" AND ( Depart_id=@Depart_id or Depart_id in (select Depart_id from FSC_Org where parent_depart_id=@Depart_id )) ")

            szSQL.AppendLine(" INSERT INTO SYS_Freeze_Func (Orgcode,Depart_id,Func_id,isFreeze,Change_userid,Change_date) ")
            szSQL.AppendLine(" select @Orgcode, Depart_id, @Func_id, @isFreeze, @Change_userid, @Change_date ")
            szSQL.AppendLine(" from FSC_Org where (Depart_id=@Depart_id or Depart_id in (select Depart_id from FSC_Org where parent_depart_id=@Depart_id ))")
            szSQL.AppendLine(" and len(Depart_id) <> 2 and Orgcode=@Orgcode ")

            Dim params() As SqlParameter = { _
              New SqlParameter("@Orgcode", Orgcode), _
              New SqlParameter("@Depart_id", Depart_id), _
              New SqlParameter("@Func_id", Func_id), _
              New SqlParameter("@isFreeze", isFreeze), _
              New SqlParameter("@Change_userid", Change_userid), _
              New SqlParameter("@Change_date", Change_date)}

            Return Execute(szSQL.ToString(), params)
        End Function

    End Class
End Namespace
