Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text

Namespace SYS.Logic
    Public Class SYS2104DAO
        Inherits BaseDAO

        ''' <summary>
        ''' 回傳人員類別
        ''' </summary>
        ''' <param name="CODE_SYS">子系統別</param>
        ''' <param name="CODE_TYPE">代碼類別</param>
        ''' <returns>CODE_DESC1,CODE_NO</returns>
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

        ''' <summary>
        ''' 取 員工基本資料檔 資料
        ''' </summary>
        ''' <returns>User_name</returns>
        ''' <remarks></remarks>
        Public Function getMemberName() As DataTable
            Dim szSQL As New StringBuilder

            szSQL.AppendLine(" SELECT User_name FROM EMP_Member ")

            Return Query(szSQL.ToString())
        End Function

        ''' <summary>
        ''' 回傳單位資料
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetDepart() As DataTable
            Dim szSQL As New StringBuilder
            szSQL.AppendLine(" SELECT DISTINCT FO2.Depart_id AS DepartID,FO2.Depart_name AS DepartName   ")
            szSQL.AppendLine(" FROM SYS_LoginAudit LA LEFT JOIN FSC_ORG AS FO1 ON LA.Depart_id=FO1.Depart_id   ")
            szSQL.AppendLine(" LEFT JOIN FSC_ORG AS FO2 ON FO1.Parent_depart_id=FO2.Depart_id   ")
            szSQL.AppendLine(" ORDER BY FO2.Depart_id   ")
            Return Query(szSQL.ToString())
        End Function

        ''' <summary>
        ''' 查詢資料
        ''' </summary>
        ''' <param name="Orgcode">機關代碼</param>
        ''' <param name="LoginTimeStart">登入時間(起)</param>
        ''' <param name="LoginTimeEnd">登入時間(迄)</param>
        ''' <param name="DepartId">單位代碼</param>
        ''' <param name="UserName">員工姓名</param>
        ''' <param name="IdCard">員工編號</param>
        ''' <param name="EmployeeType">人員類別</param>
        ''' <param name="LoginStatus">登入狀態</param>
        ''' <param name="WorkType">在職狀態</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function getData(ByVal Orgcode As String, ByVal LoginTimeStart As String, ByVal LoginTimeEnd As String, _
                                   ByVal DepartId As String, ByVal UserName As String, ByVal IdCard As String, ByVal EmployeeType As String, ByVal LoginStatus As String, ByVal WorkType As String) As DataTable
            Dim sql As New StringBuilder()

            sql.AppendLine(" SELECT ROW_NUMBER() OVER(ORDER BY P.Id_card,LA.LoginTime) AS NOS, ")
            sql.AppendLine(" O2.Depart_name AS Departname01,O1.Depart_name AS Departname02,SC.CODE_DESC1 AS CodeName,P.User_name AS UserName,P.Id_card AS IdCard, ")
            sql.AppendLine(" CASE  ")
            sql.AppendLine(" WHEN LA.LoginStatus='1' THEN '登入' ")
            sql.AppendLine(" WHEN LA.LoginStatus='2' THEN '登出' ")
            sql.AppendLine(" WHEN LA.LoginStatus='3' THEN '登入失敗-其它' ")
            sql.AppendLine(" WHEN LA.LoginStatus='4' THEN '登入失敗-密碼錯誤' ")
            sql.AppendLine(" WHEN LA.LoginStatus='5' THEN '登入失敗-帳號停用' ")
            sql.AppendLine(" END LoginStatus, ")
            sql.AppendLine(" LA.LoginTime ")
            sql.AppendLine(" FROM SYS_LoginAudit LA LEFT JOIN FSC_Personnel P ON LA.Id_card = P.Id_card ")
            sql.AppendLine(" LEFT JOIN FSC_ORG O1 ON O1.Depart_id=LA.Depart_id ")
            sql.AppendLine(" LEFT JOIN FSC_ORG O2 ON O1.Parent_depart_id=O2.Depart_id ")
            sql.AppendLine(" LEFT JOIN SYS_CODE AS SC ON P.Title_no=SC.CODE_NO ")
            sql.AppendLine(" WHERE 1 = 1 ")

            If Not String.IsNullOrEmpty(Orgcode) Then
                sql.AppendLine(" AND LA.Orgcode=@Orgcode ")
            End If
            If Not String.IsNullOrEmpty(LoginTimeStart) Then
                sql.AppendLine(" AND SUBSTRING(LA.LoginTime,1,7) >= @LoginTimeStart ")
            End If
            If Not String.IsNullOrEmpty(LoginTimeEnd) Then
                sql.AppendLine(" AND SUBSTRING(LA.LoginTime,1,7) <= @LoginTimeEnd ")
            End If
            If Not String.IsNullOrEmpty(DepartId) Then
                sql.AppendLine(" AND O1.Parent_depart_id= @DepartId")
            End If
            If Not String.IsNullOrEmpty(IdCard) Then
                sql.AppendLine(" AND P.id_card= @IdCard")
            End If
            If Not String.IsNullOrEmpty(UserName) Then
                sql.AppendLine(" AND P.User_name= @UserName")
            End If
            If Not String.IsNullOrEmpty(EmployeeType) Then
                sql.AppendLine(" AND SC.CODE_NO= @EmployeeType")
            End If
            If Not String.IsNullOrEmpty(LoginStatus) Then
                sql.AppendLine(" AND LA.LoginStatus =@LoginStatus ")
            End If
            If Not String.IsNullOrEmpty(WorkType) Then
                sql.AppendLine(" AND P.Quit_job_flag =@WorkType ")
            End If

            sql.AppendLine(" ORDER BY P.Id_card,LA.LoginTime ")

            Dim aryParms(8) As SqlParameter
            aryParms(0) = New SqlParameter("@Orgcode", SqlDbType.VarChar)
            aryParms(0).Value = Orgcode
            aryParms(1) = New SqlParameter("@DepartId", SqlDbType.VarChar)
            aryParms(1).Value = DepartId
            aryParms(2) = New SqlParameter("@EmployeeType", SqlDbType.VarChar)
            aryParms(2).Value = EmployeeType
            aryParms(3) = New SqlParameter("@IdCard", SqlDbType.VarChar)
            aryParms(3).Value = IdCard
            aryParms(4) = New SqlParameter("@UserName", SqlDbType.VarChar)
            aryParms(4).Value = UserName
            aryParms(5) = New SqlParameter("@LoginStatus", SqlDbType.VarChar)
            aryParms(5).Value = LoginStatus
            aryParms(6) = New SqlParameter("@LoginTimeStart", SqlDbType.VarChar)
            aryParms(6).Value = LoginTimeStart
            aryParms(7) = New SqlParameter("@LoginTimeEnd", SqlDbType.VarChar)
            aryParms(7).Value = LoginTimeEnd
            aryParms(8) = New SqlParameter("@WorkType", SqlDbType.VarChar)
            aryParms(8).Value = WorkType

            Return Query(sql.ToString(), aryParms)
        End Function

    End Class
End Namespace
