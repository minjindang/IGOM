Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Namespace FSCPLM.Logic
    Public Class SAL_DUTY_feeDtlDAO
        Inherits BaseDAO

        Dim Connection As SqlConnection
        Dim ConnectionString As String = String.Empty

        Public Sub New()
            ConnectionString = ConnectDB.GetDBString()
        End Sub

        Public Sub New(ByVal conn As SqlConnection)
            Me.Connection = conn
        End Sub

        'Insert
        Public Sub Insert(ps() As SqlParameter)
            Dim StrSQL As New System.Text.StringBuilder


            StrSQL.Append(" INSERT INTO SAL_DUTY_feeDtl ( ")
            StrSQL.Append(" main_id,Duty_date,Duty_sTime,Duty_eTime,Duty_Hours, ")
            StrSQL.Append(" ApplyHour_cnt,Apply_amt,Is_rest,Org_code,MEMO, ")
            StrSQL.Append(" ModUser_id,Mod_date,Duty_userId,Duty_userUnit ")
            StrSQL.Append(") VALUES ( ")
            StrSQL.Append(" @main_id,@Duty_date,@Duty_sTime,@Duty_eTime,@Duty_Hours, ")
            StrSQL.Append(" @ApplyHour_cnt,@Apply_amt,@Is_rest,@Org_code,@MEMO, ")
            StrSQL.Append(" @ModUser_id,@Mod_date,@Duty_userId,@Duty_userUnit ")
            StrSQL.Append(" ) ")

            Execute(StrSQL.ToString(), ps)
        End Sub

        'Update
        Public Sub Update(ps() As SqlParameter)
            Dim StrSQL As New System.Text.StringBuilder


            StrSQL.Append(" UPDATE SAL_DUTY_feeDtl SET  ")
            StrSQL.Append(" main_id=@main_id,Duty_date=@Duty_date,Duty_sTime=@Duty_sTime,Duty_eTime=@Duty_eTime,Duty_Hours=@Duty_Hours, ")
            StrSQL.Append(" ApplyHour_cnt=@ApplyHour_cnt,Apply_amt=@Apply_amt,Is_rest=@Is_rest,Org_code=@Org_code,MEMO=@MEMO, ")
            StrSQL.Append(" ModUser_id=@ModUser_id,Mod_date=@Mod_date,Duty_userId=@Duty_userId,Duty_userUnit=@Duty_userUnit ")
            StrSQL.Append("  WHERE 1=1  ")
            StrSQL.Append("  AND Id=@Id  ")

            Execute(StrSQL.ToString(), ps)
        End Sub

        'SELECT ALL
        Public Function SelectAll(Optional main_id As Integer = Integer.MinValue) As DataTable
            Dim StrSQL As New System.Text.StringBuilder


            StrSQL.Append(" SELECT  ")
            StrSQL.Append(" main_id,Duty_date,Duty_sTime,Duty_eTime,Duty_Hours, ")
            StrSQL.Append(" ApplyHour_cnt,Apply_amt,Is_rest,Org_code,MEMO ")
            StrSQL.Append(" ,ModUser_id,Mod_date,Duty_userId,Duty_userUnit ")
            StrSQL.Append("  FROM SAL_DUTY_feeDtl  ")
            StrSQL.Append("  WHERE 1=1  ")

            If main_id <> Integer.MinValue Then
                StrSQL.Append("  AND main_id=@main_id  ")
            End If


            Dim ps() As SqlParameter = { _
         New SqlParameter("@main_id", main_id), _
          New SqlParameter("@param2", "")}

            Return Query(StrSQL.ToString(), ps)
        End Function

        'SELECT ONE
        Public Function SelectOne(Id As Integer) As DataTable
            Dim StrSQL As New System.Text.StringBuilder


            StrSQL.Append(" SELECT  ")
            StrSQL.Append(" main_id,Duty_date,Duty_sTime,Duty_eTime,Duty_Hours, ")
            StrSQL.Append(" ApplyHour_cnt,Apply_amt,Is_rest,Org_code,MEMO ")
            StrSQL.Append(" ,ModUser_id,Mod_date,Duty_userId,Duty_userUnit ")
            StrSQL.Append("  FROM SAL_DUTY_feeDtl  ")
            StrSQL.Append("  WHERE 1=1  ")
            StrSQL.Append("  AND Id=@Id  ")

            Dim ps() As SqlParameter = { _
         New SqlParameter("@Id", Id)}

            Return Query(StrSQL.ToString(), ps)
        End Function

        'DELETE
        Public Sub Delete(Id As Integer)
            Dim StrSQL As New System.Text.StringBuilder
            StrSQL.Append(" DELETE FROM SAL_DUTY_feeDtl WHERE  Id=@Id  ")
            Dim ps() As SqlParameter = {New SqlParameter("@Id", Id)}

            Execute(StrSQL.ToString(), ps)
        End Sub

        'DELETE
        Public Sub DeleteByMainId(main_id As Integer)
            Dim StrSQL As New System.Text.StringBuilder
            StrSQL.Append(" DELETE FROM SAL_DUTY_feeDtl WHERE  main_id=@main_id  ")
            Dim ps() As SqlParameter = {New SqlParameter("@main_id", main_id)}

            Execute(StrSQL.ToString(), ps)
        End Sub


    End Class
End Namespace