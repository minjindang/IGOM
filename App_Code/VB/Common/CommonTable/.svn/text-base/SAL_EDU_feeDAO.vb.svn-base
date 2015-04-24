Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Namespace FSCPLM.Logic
    Public Class SAL_EDU_feeDAO
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
        Public Function Insert(ps() As SqlParameter) As Integer 
            Dim StrSQL As New System.Text.StringBuilder


            StrSQL.Append(" INSERT INTO SAL_EDU_fee ( ")
            StrSQL.Append(" Flow_id,User_id,Unit_code,Apply_date,Fee_source, ")
            StrSQL.Append(" Apply_yy,Period_type,Pay_date,Org_code,ModUser_id, ")
            StrSQL.Append(" Mod_date, Login_user, Login_departid ")
            StrSQL.Append(") VALUES ( ")
            StrSQL.Append(" @Flow_id,@User_id,@Unit_code,@Apply_date,@Fee_source, ")
            StrSQL.Append(" @Apply_yy,@Period_type,@Pay_date,@Org_code,@ModUser_id, ")
            StrSQL.Append(" @Mod_date, @Login_user, @Login_departid ")
            StrSQL.Append(" ) ")

            StrSQL.Append("; SELECT SCOPE_IDENTITY(); ")
            'Execute(sql.ToString(), ps)
            Return Scalar(StrSQL.ToString(), ps)
        End Function

        'Update
        Public Sub Update(ps() As SqlParameter)
            Dim StrSQL As New System.Text.StringBuilder


            StrSQL.Append(" UPDATE SAL_EDU_fee SET  ")
            StrSQL.Append(" Flow_id=@Flow_id,User_id=@User_id,Unit_code=@Unit_code,Apply_date=@Apply_date,Fee_source=@Fee_source, ")
            StrSQL.Append(" Apply_yy=@Apply_yy,Period_type=@Period_type,Pay_date=@Pay_date,Org_code=@Org_code,ModUser_id=@ModUser_id, ")
            StrSQL.Append(" Mod_date=@Mod_date ")
            StrSQL.Append("  WHERE 1=1  ")
            StrSQL.Append("  AND Id=@Id  ")

            Execute(StrSQL.ToString(), ps)
        End Sub

        'SELECT ALL
        Public Function SelectAll(Org_code As String, Optional User_id As String = "", Optional Flow_id As String = "") As DataTable
            Dim StrSQL As New System.Text.StringBuilder


            StrSQL.Append(" SELECT id, ")
            StrSQL.Append(" Flow_id,User_id,Unit_code,Apply_date,Fee_source, ")
            StrSQL.Append(" Apply_yy,Period_type,Pay_date,Org_code,ModUser_id ")
            StrSQL.Append(" ,Mod_date ")
            StrSQL.Append("  FROM SAL_EDU_fee  ")
            StrSQL.Append("  WHERE Org_code=@Org_code  ")

            If Not String.IsNullOrEmpty(User_id) Then
                StrSQL.Append("  AND User_id=@User_id  ")
            End If

            If Not String.IsNullOrEmpty(Flow_id) Then
                StrSQL.Append("  AND Flow_id=@Flow_id  ")
            End If


            StrSQL.Append("  ORDER BY  Apply_yy,Period_type DESC ")

            Dim ps() As SqlParameter = { _
         New SqlParameter("@User_id", User_id), _
         New SqlParameter("@Flow_id", Flow_id), _
          New SqlParameter("@Org_code", Org_code)}

            Return Query(StrSQL.ToString(), ps)
        End Function

        'SELECT ONE
        Public Function SelectOne(Id As Integer) As DataTable
            Dim StrSQL As New System.Text.StringBuilder


            StrSQL.Append(" SELECT  ")
            StrSQL.Append(" Flow_id,User_id,Unit_code,Apply_date,Fee_source, ")
            StrSQL.Append(" Apply_yy,Period_type,Pay_date,Org_code,ModUser_id ")
            StrSQL.Append(" ,Mod_date ")
            StrSQL.Append("  FROM SAL_EDU_fee  ")
            StrSQL.Append("  WHERE 1=1  ")
            StrSQL.Append("  AND Id=@Id  ")

            Dim ps() As SqlParameter = { _
         New SqlParameter("@Id", Id)}

            Return Query(StrSQL.ToString(), ps)
        End Function

        'DELETE
        Public Sub Delete(Id As Integer)
            Dim StrSQL As New System.Text.StringBuilder
            StrSQL.Append(" DELETE FROM SAL_EDU_fee WHERE  Id=@Id  ")
            Dim ps() As SqlParameter = {New SqlParameter("@Id", Id)}

            Execute(StrSQL.ToString(), ps)
        End Sub

        Public Function update(ByVal Orgcode As String, ByVal flow_id As String) As Integer
            Dim sql As StringBuilder = New StringBuilder
            sql.AppendLine(" update SAL_EDU_fee set ModUser_id=@ModUser_id , Mod_date=getDate() ")
            sql.AppendLine(" where Org_code=@Orgcode and flow_id=@flow_id ")

            Dim ps() As SqlParameter = {New SqlParameter("@flow_id", flow_id), _
                                        New SqlParameter("@Orgcode", Orgcode), _
                                        New SqlParameter("@ModUser_id", LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account))}

            Execute(sql.ToString(), ps)

            sql = New StringBuilder
            sql.AppendLine(" select id from SAL_EDU_fee where Org_code=@Orgcode and flow_id=@flow_id ")

            Return Scalar(sql.ToString(), ps)
        End Function
    End Class
End Namespace