Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Namespace FSCPLM.Logic
    Public Class SAL_VOL_feeDAO
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


            StrSQL.Append(" INSERT INTO SAL_VOL_fee ( ")
            StrSQL.Append(" Flow_id,User_id,Unit_code,Apply_ym,Apply_date, ")
            StrSQL.Append(" Fee_source,Pay_date,Org_code,ModUser_id,Mod_date ")
            StrSQL.Append("  ")
            StrSQL.Append(") VALUES ( ")
            StrSQL.Append(" @Flow_id,@User_id,@Unit_code,@Apply_ym,@Apply_date, ")
            StrSQL.Append(" @Fee_source,@Pay_date,@Org_code,@ModUser_id,@Mod_date ")
            StrSQL.Append("  ")
            StrSQL.Append(" ) ")

            StrSQL.Append("; SELECT SCOPE_IDENTITY(); ")
            'Execute(sql.ToString(), ps)
            Return Scalar(StrSQL.ToString(), ps)
        End Function

        'Update
        Public Sub Update(ps() As SqlParameter)
            Dim StrSQL As New System.Text.StringBuilder


            StrSQL.Append(" UPDATE SAL_VOL_fee SET  ")
            StrSQL.Append(" Flow_id=@Flow_id,User_id=@User_id,Unit_code=@Unit_code,Apply_ym=@Apply_ym,Apply_date=@Apply_date, ")
            StrSQL.Append(" Fee_source=@Fee_source,Pay_date=@Pay_date,Org_code=@Org_code,ModUser_id=@ModUser_id,Mod_date=@Mod_date ")
            StrSQL.Append("  ")
            StrSQL.Append("  WHERE 1=1  ")
            StrSQL.Append("  AND Id=@Id  ")

            Execute(StrSQL.ToString(), ps)
        End Sub

        'SELECT ALL
        Public Function SelectAll(Org_code As String, Optional User_id As String = "", Optional Flow_id As String = "") As DataTable
            Dim StrSQL As New System.Text.StringBuilder


            StrSQL.Append(" SELECT  id, ")
            StrSQL.Append(" Flow_id,User_id,Unit_code,Apply_ym,Apply_date, ")
            StrSQL.Append(" Fee_source,Pay_date,Org_code,ModUser_id,Mod_date ")
            StrSQL.Append("  FROM SAL_VOL_fee  ")
            StrSQL.Append("  WHERE Org_code=@Org_code ")

            If Not String.IsNullOrEmpty(User_id) Then
                StrSQL.Append("  AND User_id=@User_id  ")
            End If

            If Not String.IsNullOrEmpty(Flow_id) Then
                StrSQL.Append("  AND Flow_id=@Flow_id  ")
            End If


            StrSQL.Append("  ORDER BY  Apply_ym  DESC ")

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
            StrSQL.Append(" Flow_id,User_id,Unit_code,Apply_ym,Apply_date, ")
            StrSQL.Append(" Fee_source,Pay_date,Org_code,ModUser_id,Mod_date ")
            StrSQL.Append("  FROM SAL_VOL_fee  ")
            StrSQL.Append("  WHERE 1=1  ")
            StrSQL.Append("  AND Id=@Id  ")

            Dim ps() As SqlParameter = { _
         New SqlParameter("@Id", Id)}

            Return Query(StrSQL.ToString(), ps)
        End Function

        'DELETE
        Public Sub Delete(Id As Integer)
            Dim StrSQL As New System.Text.StringBuilder
            StrSQL.Append(" DELETE FROM SAL_VOL_fee WHERE  Id=@Id  ")
            Dim ps() As SqlParameter = {New SqlParameter("@Id", Id)}

            Execute(StrSQL.ToString(), ps)
        End Sub

        Public Function SelectGetNewFlowid(OrgCode As String) As DataTable
            Dim StrSQL As New System.Text.StringBuilder
            StrSQL.Append(" SELECT TOP 1 * FROM SAL_VOL_fee ORDER BY Flow_id DESC ")
            Dim ps() As SqlParameter = { _
            New SqlParameter("@Org_code", OrgCode)}
            Return Query(StrSQL.ToString(), ps)
        End Function
    End Class
End Namespace