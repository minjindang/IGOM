Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Collections.Generic

Namespace FSCPLM.Logic
    Public Class SAL_TRAFFIC_FEEDAO
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


            StrSQL.Append(" INSERT INTO SAL_TRAFFIC_FEE ( ")
            StrSQL.Append(" Flow_id,unit_code,User_id,Apply_ymd,Pay_date, ")
            StrSQL.Append(" Fee_source,Org_code,ModUser_id,Mod_date, Cost_date, Apply_amt, Apply_desc ")
            StrSQL.Append(") VALUES ( ")
            StrSQL.Append(" @Flow_id,@unit_code,@User_id,@Apply_ymd,@Pay_date, ")
            StrSQL.Append(" @Fee_source,@Org_code,@ModUser_id,@Mod_date, @Cost_date, @Apply_amt, @Apply_desc ")
            StrSQL.Append(" ) ")

            Return Execute(StrSQL.ToString(), ps)
        End Function

        'Update
        Public Sub Update(ps() As SqlParameter)
            Dim StrSQL As New System.Text.StringBuilder


            StrSQL.Append(" UPDATE SAL_TRAFFIC_FEE SET  ")
            StrSQL.Append(" Flow_id=@Flow_id,unit_code=@unit_code,User_id=@User_id,Apply_ymd=@Apply_ymd,Pay_date=@Pay_date, ")
            StrSQL.Append(" Fee_source=@Fee_source,Org_code=@Org_code,ModUser_id=@ModUser_id,Mod_date=@Mod_date,  ")
            StrSQL.Append(" Cost_date=@Cost_date, Apply_amt=@Apply_amt, Apply_desc=@Apply_desc ")
            StrSQL.Append("  WHERE Id=@Id  ")

            Execute(StrSQL.ToString(), ps)
        End Sub

        Public Function GetDataByNoFlowId(orgcode As String, userId As String) As DataTable
            Dim StrSQL As New System.Text.StringBuilder

            StrSQL.Append(" SELECT * ")
            StrSQL.Append("  FROM SAL_TRAFFIC_FEE  ")
            StrSQL.Append("  WHERE (Flow_id='' or Flow_id is null)  ")

            If Not String.IsNullOrEmpty(userId) Then
                StrSQL.Append("  AND User_id=@User_id  ")
            End If

            If Not String.IsNullOrEmpty(orgcode) Then
                StrSQL.Append("  AND Org_code=@Org_code  ")
            End If
            StrSQL.Append("  ORDER BY  Apply_ymd DESC ")

            Dim ps() As SqlParameter = { _
                New SqlParameter("@User_id", userId), _
                New SqlParameter("@Org_code", orgcode)}

            Return Query(StrSQL.ToString(), ps)
        End Function


        'SELECT ALL
        Public Function SelectAll(Optional Org_code As String = "", Optional User_id As String = "", Optional Flow_id As String = "") As DataTable
            Dim StrSQL As New System.Text.StringBuilder


            StrSQL.Append(" SELECT * ")
            StrSQL.Append("  FROM SAL_TRAFFIC_FEE  ")
            StrSQL.Append("  WHERE 1=1  ")

            If Not String.IsNullOrEmpty(User_id) Then
                StrSQL.Append("  AND User_id=@User_id  ")
            End If

            If Not String.IsNullOrEmpty(Org_code) Then
                StrSQL.Append("  AND Org_code=@Org_code  ")
            End If

            If Not String.IsNullOrEmpty(Flow_id) Then
                StrSQL.Append("  AND Flow_id=@Flow_id  ")
            End If

            StrSQL.Append("  ORDER BY  Apply_ymd DESC ")
            Dim ps() As SqlParameter = { _
         New SqlParameter("@User_id", User_id), _
         New SqlParameter("@Flow_id", Flow_id), _
          New SqlParameter("@Org_code", Org_code)}

            Return Query(StrSQL.ToString(), ps)
        End Function

        'SELECT ONE
        Public Function SelectOne(Id As Integer) As DataTable
            Dim StrSQL As New System.Text.StringBuilder


            StrSQL.Append(" SELECT * ")
            StrSQL.Append("  FROM SAL_TRAFFIC_FEE  ")
            StrSQL.Append("  WHERE Id=@Id  ")

            Dim ps() As SqlParameter = { _
         New SqlParameter("@Id", Id)}

            Return Query(StrSQL.ToString(), ps)
        End Function

        'DELETE
        Public Sub Delete(Id As Integer)
            Dim StrSQL As New System.Text.StringBuilder
            StrSQL.Append(" DELETE FROM SAL_TRAFFIC_FEE WHERE  Id=@Id  ")
            Dim ps() As SqlParameter = {New SqlParameter("@Id", Id)}

            Execute(StrSQL.ToString(), ps)
        End Sub

        Public Function Delete(orgcode As String, flowId As String) As Integer
            Dim d As New Dictionary(Of String, Object)
            d.Add("Org_code", orgcode)
            d.Add("Flow_id", flowId)

            Return DeleteByExample("SAL_TRAFFIC_FEE", d)
        End Function

    End Class
End Namespace