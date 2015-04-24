Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Namespace FSCPLM.Logic
    Public Class SAL_HealthSubsidy_feeDAO
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


            StrSQL.Append(" INSERT INTO SAL_HealthSubsidy_fee ( ")
            StrSQL.Append(" Flow_id,User_id,Unit_code,Apply_date,Apply_yy, ")
            StrSQL.Append(" Check_date,Apply_amt,Fee_source,Pay_date,Org_code, ")
            StrSQL.Append(" ModUser_id,Mod_date ")
            StrSQL.Append(") VALUES ( ")
            StrSQL.Append(" @Flow_id,@User_id,@Unit_code,@Apply_date,@Apply_yy, ")
            StrSQL.Append(" @Check_date,@Apply_amt,@Fee_source,@Pay_date,@Org_code, ")
            StrSQL.Append(" @ModUser_id,@Mod_date ")
            StrSQL.Append(" ) ")

            Execute(StrSQL.ToString(), ps)
        End Sub

        'Update
        Public Sub Update(ps() As SqlParameter)
            Dim StrSQL As New System.Text.StringBuilder


            StrSQL.Append(" UPDATE SAL_HealthSubsidy_fee SET  ")
            StrSQL.Append(" Flow_id=@Flow_id,User_id=@User_id,Unit_code=@Unit_code,Apply_date=@Apply_date,Apply_yy=@Apply_yy, ")
            StrSQL.Append(" Check_date=@Check_date,Apply_amt=@Apply_amt,Fee_source=@Fee_source,Pay_date=@Pay_date,Org_code=@Org_code, ")
            StrSQL.Append(" ModUser_id=@ModUser_id,Mod_date=@Mod_date ")
            StrSQL.Append("  WHERE 1=1  ")
            StrSQL.Append("  AND Id=@Id  ")

            Execute(StrSQL.ToString(), ps)
        End Sub

        'SELECT ALL
        Public Function SelectAll(Org_code As String, Optional User_id As String = "", Optional Flow_id As String = "") As DataTable
            Dim StrSQL As New System.Text.StringBuilder

            StrSQL.Append(" SELECT  ")
            StrSQL.Append(" HS.* ")
            StrSQL.Append("  FROM SAL_HealthSubsidy_fee HS INNER JOIN SYS_Flow F ON HS.Flow_id=F.Flow_id  ")
            StrSQL.Append("  WHERE HS.Org_code=@Org_code  AND F.CASE_STATUS IN ('0','1','2')")

            If Not String.IsNullOrEmpty(User_id) Then
                StrSQL.Append("  AND HS.User_id=@User_id  ")
            End If

            If Not String.IsNullOrEmpty(Flow_id) Then
                StrSQL.Append("  AND HS.Flow_id=@Flow_id  ")
            End If

            Dim ps() As SqlParameter = { _
         New SqlParameter("@Org_code", Org_code), _
         New SqlParameter("@Flow_id", Flow_id), _
          New SqlParameter("@User_id", User_id)}

            Return Query(StrSQL.ToString(), ps)
        End Function

        'SELECT ONE
        Public Function SelectOne(Id As Integer) As DataTable
            Dim StrSQL As New System.Text.StringBuilder


            StrSQL.Append(" SELECT  ")
            StrSQL.Append(" Flow_id,User_id,Unit_code,Apply_date,Apply_yy, ")
            StrSQL.Append(" Check_date,Apply_amt,Fee_source,Pay_date,Org_code ")
            StrSQL.Append(" ,ModUser_id,Mod_date ")
            StrSQL.Append("  FROM SAL_HealthSubsidy_fee  ")
            StrSQL.Append("  WHERE 1=1  ")
            StrSQL.Append("  AND Id=@Id  ")

            Dim ps() As SqlParameter = { _
         New SqlParameter("@Id", Id)}

            Return Query(StrSQL.ToString(), ps)
        End Function

        'DELETE
        Public Sub Delete(Id As Integer)
            Dim StrSQL As New System.Text.StringBuilder
            StrSQL.Append(" DELETE FROM SAL_HealthSubsidy_fee WHERE  Id=@Id  ")
            Dim ps() As SqlParameter = {New SqlParameter("@Id", Id)}

            Execute(StrSQL.ToString(), ps)
        End Sub

        Public Function getDateByOrgFid(ByVal Orgcode As String, ByVal Flow_id As String) As DataTable
            Dim sql As StringBuilder = New StringBuilder
            sql.AppendLine(" select * from SAL_HealthSubsidy_fee where org_code=@Orgcode and Flow_id=@Flow_id ")

            Dim params(1) As SqlParameter
            params(0) = New SqlParameter("@Orgcode", SqlDbType.VarChar)
            params(0).Value = Orgcode
            params(1) = New SqlParameter("@Flow_id", SqlDbType.VarChar)
            params(1).Value = Flow_id

            Return Query(sql.ToString(), params)
        End Function

        Public Sub UpdateByOrgFid(ByVal Orgcode As String, ByVal Flow_id As String, ByVal Apply_yy As String, ByVal Check_date As String, ByVal Apply_amt As Integer)
            Dim sql As StringBuilder = New StringBuilder
            sql.AppendLine(" update SAL_HealthSubsidy_fee set ")
            sql.AppendLine(" Apply_yy=@Apply_yy, Check_date=@Check_date, Apply_amt=@Apply_amt, ")
            sql.AppendLine(" ModUser_id=@ModUser_id, Mod_date=getDate() ")
            sql.AppendLine(" where org_code=@Orgcode and Flow_id=@Flow_id ")

            Dim params(5) As SqlParameter
            params(0) = New SqlParameter("@Orgcode", SqlDbType.VarChar)
            params(0).Value = Orgcode
            params(1) = New SqlParameter("@Flow_id", SqlDbType.VarChar)
            params(1).Value = Flow_id
            params(2) = New SqlParameter("@Apply_yy", SqlDbType.VarChar)
            params(2).Value = Apply_yy
            params(3) = New SqlParameter("@Check_date", SqlDbType.VarChar)
            params(3).Value = Check_date
            params(4) = New SqlParameter("@Apply_amt", SqlDbType.Int)
            params(4).Value = Apply_amt
            params(5) = New SqlParameter("@ModUser_id", SqlDbType.VarChar)
            params(5).Value = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account)

            Execute(sql.ToString(), params)
        End Sub
    End Class
End Namespace