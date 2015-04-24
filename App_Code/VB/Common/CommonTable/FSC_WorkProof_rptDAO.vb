Imports System.Data
Imports System.Data.SqlClient
Imports Pemis2009.SQLAdapter
Imports System.Text
Imports System

Namespace FSCPLM.Logic
    Public Class FSC_WorkProof_rptDAO
        Inherits BaseDAO
        Dim ConnectionString As String = String.Empty

        Public Sub New()
            MyBase.New()
            ConnectionString = ConnectDB.GetDBString()
        End Sub

        ' ''' <summary>
        ' ''' [取得]值班費資料
        ' ''' </summary>
        ' ''' <returns></returns>
        ' ''' <remarks></remarks>
        'Public Function GetDataByUserId(ByVal Orgcode As String, ByVal UserId As String, ByVal Apply_ym As String) As DataSet
        '    Dim StrSQL As String = String.Empty

        '    StrSQL = "SELECT m.User_name, ss.Sche_date, s.Start_time, s.End_time, " + _
        '            "case when DATEPART(dw,CONVERT(int,ss.Sche_date)) >5 then 800 else 600 END as amt, " + _
        '            "((CONVERT(int,CASE WHEN s.End_time='2359' THEN 2400 ELSE s.End_time  end)-CONVERT(int,s.Start_time) - (CONVERT(int,s.Noon_etime) - CONVERT(int,s.Noon_stime)) )/100) AS hours, " + _
        '            "ISNULL(df.memo,'') AS memo " + _
        '            "FROM Member m " + _
        '            "LEFT JOIN Schedule_setting ss ON m.Personnel_id = ss.Personnel_id " + _
        '            "LEFT JOIN Schedule s ON ss.Schedule_id = s.Schedule_ID " + _
        '            "LEFT JOIN SAL_DUTY_fee df ON m.Personnel_id=df.User_id AND df.Duty_date=ss.Sche_date " + _
        '            "Where 1 = 1 "

        '    If Not String.IsNullOrEmpty(Orgcode) Then
        '        StrSQL &= "AND m.Orgcode = @Orgcode "
        '    End If
        '    If Not String.IsNullOrEmpty(UserId) Then
        '        StrSQL &= "AND m.Personnel_id = @UserId "
        '    End If
        '    If Not String.IsNullOrEmpty(Apply_ym) Then
        '        StrSQL &= "AND SUBSTRING(ss.Sche_date,1,5) = @Apply_ym "
        '    End If

        '    Dim params() As SqlParameter = { _
        '    New SqlParameter("@Orgcode", SqlDbType.VarChar), _
        '    New SqlParameter("@UserId", SqlDbType.VarChar), _
        '    New SqlParameter("@Apply_ym", SqlDbType.VarChar)}
        '    params(0).Value = Orgcode
        '    params(1).Value = UserId
        '    params(2).Value = Apply_ym
        '    DBUtil.SetParamsNull(params)
        '    Return SqlAccessHelper.ExecuteDataset(ConnectionString, CommandType.Text, StrSQL, params)

        'End Function


        ' ''' <summary>
        ' ''' [檢核重複]值班費申請
        ' ''' </summary>
        ' ''' <returns></returns>
        ' ''' <remarks></remarks>
        'Public Function CheckInsert(ByVal Orgcode As String, ByVal UserId As String, ByVal Apply_ym As String) As DataSet
        '    Dim StrSQL As String = String.Empty

        '    StrSQL = "SELECT * FROM SAL_DUTY_fee df  Where 1=1 "

        '    If Not String.IsNullOrEmpty(Orgcode) Then
        '        StrSQL &= "AND Org_code = @Orgcode "
        '    End If

        '    If Not String.IsNullOrEmpty(Orgcode) Then
        '        StrSQL &= "AND User_Id = @UserId "
        '    End If

        '    If Not String.IsNullOrEmpty(Apply_ym) Then
        '        StrSQL &= "AND Apply_ym = @Apply_ym "
        '    End If

        '    Dim params() As SqlParameter = { _
        '    New SqlParameter("@Orgcode", SqlDbType.VarChar), _
        '    New SqlParameter("@UserId", SqlDbType.VarChar), _
        '    New SqlParameter("@Apply_ym", SqlDbType.VarChar)}
        '    params(0).Value = Orgcode
        '    params(1).Value = UserId
        '    params(2).Value = Apply_ym
        '    DBUtil.SetParamsNull(params)
        '    Return SqlAccessHelper.ExecuteDataset(ConnectionString, CommandType.Text, StrSQL, params)

        'End Function

    End Class
End Namespace