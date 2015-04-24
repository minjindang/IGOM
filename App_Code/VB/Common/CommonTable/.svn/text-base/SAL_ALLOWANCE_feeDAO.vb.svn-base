Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Namespace FSCPLM.Logic
    Public Class SAL_ALLOWANCE_feeDAO
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


            StrSQL.Append(" INSERT INTO SAL_ALLOWANCE_fee ( ")
            StrSQL.Append(" Flow_id,User_id,Unit_code,Apply_date,Fee_source, ")
            StrSQL.Append(" Apply_type,Relation_type,Apply_amt,Pay_date,Org_code, ")
            StrSQL.Append(" ModUser_id,Mod_date,Event_date ")
            StrSQL.Append(") VALUES ( ")
            StrSQL.Append(" @Flow_id,@User_id,@Unit_code,@Apply_date,@Fee_source, ")
            StrSQL.Append(" @Apply_type,@Relation_type,@Apply_amt,@Pay_date,@Org_code, ")
            StrSQL.Append(" @ModUser_id,@Mod_date,@Event_date ")
            StrSQL.Append(" ) ")

            Execute(StrSQL.ToString(), ps)
        End Sub

        'Update
        Public Sub Update(ps() As SqlParameter)
            Dim StrSQL As New System.Text.StringBuilder


            StrSQL.Append(" UPDATE SAL_ALLOWANCE_fee SET  ")
            StrSQL.Append(" Flow_id=@Flow_id,User_id=@User_id,Unit_code=@Unit_code,Apply_date=@Apply_date,Fee_source=@Fee_source, ")
            StrSQL.Append(" Apply_type=@Apply_type,Relation_type=@Relation_type,Apply_amt=@Apply_amt,Pay_date=@Pay_date,Org_code=@Org_code, ")
            StrSQL.Append(" ModUser_id=@ModUser_id,Mod_date=@Mod_date ")
            StrSQL.Append("  WHERE 1=1  ")
            StrSQL.Append("  AND Id=@Id  ")

            Execute(StrSQL.ToString(), ps)
        End Sub

        'SELECT ALL
        Public Function SelectAll(Org_code As String, Optional User_id As String = "", Optional Flow_id As String = "") As DataTable
            Dim StrSQL As New System.Text.StringBuilder


            StrSQL.Append(" SELECT  ")
            StrSQL.Append(" Flow_id,User_id,Unit_code,Apply_date,Fee_source, ")
            StrSQL.Append(" Apply_type,Relation_type,Apply_amt,Pay_date,Org_code ")
            StrSQL.Append(" ,ModUser_id,Mod_date ")
            StrSQL.Append("  FROM SAL_ALLOWANCE_fee  ")
            StrSQL.Append("  WHERE Org_code=@Org_code  ")

            If Not String.IsNullOrEmpty(User_id) Then
                StrSQL.Append("  AND User_id=@User_id  ")
            End If

            If Not String.IsNullOrEmpty(Flow_id) Then
                StrSQL.Append("  AND Flow_id=@Flow_id  ")
            End If

            StrSQL.Append("  ORDER BY  Apply_date DESC ")

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
            StrSQL.Append(" Apply_type,Relation_type,Apply_amt,Pay_date,Org_code ")
            StrSQL.Append(" ,ModUser_id,Mod_date ")
            StrSQL.Append("  FROM SAL_ALLOWANCE_fee  ")
            StrSQL.Append("  WHERE 1=1  ")
            StrSQL.Append("  AND Id=@Id  ")

            Dim ps() As SqlParameter = { _
         New SqlParameter("@Id", Id)}

            Return Query(StrSQL.ToString(), ps)
        End Function

        'DELETE
        Public Sub Delete(Id As Integer)
            Dim StrSQL As New System.Text.StringBuilder
            StrSQL.Append(" DELETE FROM SAL_ALLOWANCE_fee WHERE  Id=@Id  ")
            Dim ps() As SqlParameter = {New SqlParameter("@Id", Id)}

            Execute(StrSQL.ToString(), ps)
        End Sub


        Public Function Update(Apply_type As String, Relation_type As String, Apply_amt As Integer, Event_date As String, orgcode As String, flow_id As String) As Integer

            Dim StrSQL As New System.Text.StringBuilder
            StrSQL.Append(" UPDATE SAL_ALLOWANCE_fee  SET Apply_type=@Apply_type, Relation_type=@Relation_type, Apply_amt=@Apply_amt ")
            StrSQL.Append(" ,Event_date=@Event_date")
            StrSQL.Append(" WHERE  org_code=@orgcode and flow_id=@flow_id ")

            Dim ps() As SqlParameter = { _
                New SqlParameter("@orgcode", orgcode), _
                New SqlParameter("@flow_id", flow_id), _
                New SqlParameter("@Apply_type", Apply_type), _
                New SqlParameter("@Event_date", Event_date), _
                New SqlParameter("@Relation_type", Relation_type), _
                New SqlParameter("@Apply_amt", Apply_amt)}

            Return Execute(StrSQL.ToString(), ps)
        End Function


    End Class
End Namespace