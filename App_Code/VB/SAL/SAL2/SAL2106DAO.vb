Imports System.Data
Imports System.Data.SqlClient
Imports Pemis2009.SQLAdapter
Imports System.Text
Imports System

Namespace SALARY.Logic
    Public Class SAL2106DAO
        Inherits BaseDAO
        Dim ConnectionString As String = String.Empty

        Public Sub New()
            MyBase.New()
            ConnectionString = ConnectDB.GetDBString()
        End Sub

        ''' <summary>
        ''' [取得]評審委員出席審查費、講師鐘點費申請
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetDataByUserId(ByVal Orgcode As String, ByVal UserId As String, ByVal Apply_yy As String) As DataSet
            Dim StrSQL As String = String.Empty

            StrSQL = "SELECT hsf.*, m.User_name, sa.BASE_ORG_L1 " + _
                    "FROM SAL_HealthSubsidy_fee hsf " + _
                    "LEFT JOIN member m on hsf.user_id=m.personnel_id " + _
                    "LEFT JOIN SAL_SABASE sa ON m.Id_card = sa.BASE_IDNO " + _
                    "Where 1=1  "

            If Not String.IsNullOrEmpty(Orgcode) Then
                StrSQL &= "AND hsf.Org_code = @Orgcode "
            End If

            If Not String.IsNullOrEmpty(UserId) Then
                StrSQL &= "AND hsf.User_Id = @UserId "
            End If
            If Not String.IsNullOrEmpty(Apply_yy) Then
                StrSQL &= "AND hsf.Apply_yy = @Apply_yy "
            End If

            Dim params() As SqlParameter = { _
            New SqlParameter("@Orgcode", SqlDbType.VarChar), _
            New SqlParameter("@UserId", SqlDbType.VarChar), _
            New SqlParameter("@Apply_yy", SqlDbType.VarChar)}
            params(0).Value = Orgcode
            params(1).Value = UserId
            params(2).Value = Apply_yy
            DBUtil.SetParamsNull(params)
            Return SqlAccessHelper.ExecuteDataset(ConnectionString, CommandType.Text, StrSQL, params)

        End Function

        ''' <summary>
        ''' [取得] 生日(年紀), 到職日期(年資), 職等, 主管加給(判斷是否為主管)
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetValiDataByUserId(ByVal Orgcode As String, ByVal UserId As String) As DataSet
            Dim StrSQL As String = String.Empty

            StrSQL = "SELECT m.personnel_id, m.birth_date, m.join_sdate, sa.BASE_ORG_L1, sa.BASE_KDC " + _
                    "FROM member m " + _
                    "LEFT JOIN SAL_SABASE sa ON m.Id_card = sa.BASE_IDNO " + _
                    "Where 1=1  "

            If Not String.IsNullOrEmpty(Orgcode) Then
                StrSQL &= "AND m.Orgcode = @Orgcode "
            End If

            If Not String.IsNullOrEmpty(UserId) Then
                StrSQL &= "AND m.personnel_id = @UserId "
            End If

            Dim params() As SqlParameter = { _
            New SqlParameter("@Orgcode", SqlDbType.VarChar), _
            New SqlParameter("@UserId", SqlDbType.VarChar)}
            params(0).Value = Orgcode
            params(1).Value = UserId
            DBUtil.SetParamsNull(params)
            Return SqlAccessHelper.ExecuteDataset(ConnectionString, CommandType.Text, StrSQL, params)

        End Function


        ''' <summary>
        ''' [檢核重複]勞/健、公/健保繳納證明申請
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function CheckInsert(ByVal Orgcode As String, ByVal UserId As String, ByVal Apply_yy As String) As DataSet
            Dim StrSQL As String = String.Empty

            StrSQL = "SELECT * FROM SAL_HealthSubsidy_fee hsf  Where 1=1 "

            If Not String.IsNullOrEmpty(Orgcode) Then
                StrSQL &= "AND Org_code = @Orgcode "
            End If

            If Not String.IsNullOrEmpty(Orgcode) Then
                StrSQL &= "AND User_Id = @UserId "
            End If

            If Not String.IsNullOrEmpty(Apply_yy) Then
                StrSQL &= "AND Apply_yy = @Apply_yy "
            End If

            Dim params() As SqlParameter = { _
            New SqlParameter("@Orgcode", SqlDbType.VarChar), _
            New SqlParameter("@UserId", SqlDbType.VarChar), _
            New SqlParameter("@Apply_yy", SqlDbType.VarChar)}
            params(0).Value = Orgcode
            params(1).Value = UserId
            params(2).Value = Apply_yy
            DBUtil.SetParamsNull(params)
            Return SqlAccessHelper.ExecuteDataset(ConnectionString, CommandType.Text, StrSQL, params)

        End Function

    End Class
End Namespace