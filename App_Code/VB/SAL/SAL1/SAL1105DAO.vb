Imports System.Data
Imports System.Data.SqlClient
Imports Pemis2009.SQLAdapter
Imports System.Text
Imports System

Namespace SALARY.Logic
    Public Class SAL1105DAO
        Inherits BaseDAO
        Dim ConnectionString As String = String.Empty

        Public Sub New()
            MyBase.New()
            ConnectionString = ConnectDB.GetDBString()
        End Sub

        ''' <summary>
        ''' [取得]健檢補助費申請
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetDataByUserId(ByVal Orgcode As String, ByVal UserId As String, ByVal Apply_yy As String) As DataSet
            Dim StrSQL As String = String.Empty

            StrSQL = "SELECT hsf.*, sa.BASE_NAME, sa.BASE_ORG_L1 " + _
                    "FROM SAL_HealthSubsidy_fee hsf " + _
                    "LEFT JOIN SAL_SABASE sa ON hsf.user_id = sa.BASE_SEQNO " + _
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

            StrSQL = "select sa.BASE_SEQNO,sa.BASE_NAME, sae.BASE_BirthDay, sa.BASE_ORG_L1, sa.BASE_KDC  " + _
                    "from SAL_SABASE sa " + _
                    "left join SAL_SABASEEXT sae on sa.BASE_IDNO=sae.BASE_IDNO " + _
                    "Where 1=1  "

            If Not String.IsNullOrEmpty(Orgcode) Then
                StrSQL &= "and sa.BASE_ORGID = @Orgcode "
            End If

            If Not String.IsNullOrEmpty(UserId) Then
                StrSQL &= "and sa.BASE_SEQNO =  @UserId "
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