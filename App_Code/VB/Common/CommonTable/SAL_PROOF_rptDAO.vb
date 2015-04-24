Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Namespace FSCPLM.Logic
    Public Class SAL_PROOF_rptDAO
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


            StrSQL.Append(" INSERT INTO SAL_PROOF_rpt ( ")
            StrSQL.Append(" Flow_id,User_id,Unit_code,Apply_yy,Apply_date, ")
            StrSQL.Append(" Org_code,ModUser_id,Mod_date ")
            StrSQL.Append(") VALUES ( ")
            StrSQL.Append(" @Flow_id,@User_id,@Unit_code,@Apply_yy,@Apply_date, ")
            StrSQL.Append(" @Org_code,@ModUser_id,@Mod_date ")
            StrSQL.Append(" ) ")

            Execute(StrSQL.ToString(), ps)
        End Sub

        'Update
        Public Sub Update(ps() As SqlParameter)
            Dim StrSQL As New System.Text.StringBuilder


            StrSQL.Append(" UPDATE SAL_PROOF_rpt SET  ")
            StrSQL.Append(" Flow_id=@Flow_id,User_id=@User_id,Unit_code=@Unit_code,Apply_yy=@Apply_yy,Apply_date=@Apply_date, ")
            StrSQL.Append(" Org_code=@Org_code,ModUser_id=@ModUser_id,Mod_date=@Mod_date ")
            StrSQL.Append("  WHERE 1=1  ")
            StrSQL.Append("  AND Id=@Id  ")

            Execute(StrSQL.ToString(), ps)
        End Sub

        'SELECT ALL
        Public Function SelectAll(ByVal Org_code As String, ByVal User_id As String, ByVal Apply_yy As String) As DataTable
            Dim StrSQL As New System.Text.StringBuilder


            StrSQL.Append(" SELECT  ")
            StrSQL.Append(" Flow_id,User_id,Unit_code,Apply_yy,Apply_date ")
            StrSQL.Append(" ,Org_code,ModUser_id,Mod_date ")
            StrSQL.Append("  FROM SAL_PROOF_rpt  ")
            StrSQL.Append("  WHERE Org_code=@Org_code  ")

            If Not String.IsNullOrEmpty(User_id) Then
                StrSQL.Append("  AND User_id=@User_id  ")
            End If

            If Not String.IsNullOrEmpty(Apply_yy) Then
                StrSQL.Append("  AND Apply_yy=@Apply_yy  ")
            End If


            Dim ps() As SqlParameter = { _
         New SqlParameter("@Org_code", Org_code), _
          New SqlParameter("@User_id", User_id), _
          New SqlParameter("@Apply_yy", Apply_yy)}

            Return Query(StrSQL.ToString(), ps)
        End Function

        'SELECT ALL
        Public Function SelectAll(Org_code As String, Flow_id As String) As DataTable
            Dim StrSQL As New System.Text.StringBuilder

            StrSQL.Append(" SELECT * ")
            StrSQL.Append("  FROM SAL_PROOF_rpt  ")
            StrSQL.Append("  WHERE Org_code=@Org_code  ")


            If Not String.IsNullOrEmpty(Flow_id) Then
                StrSQL.Append("  AND Flow_id=@Flow_id  ")
            End If


            StrSQL.Append("  ORDER BY  Apply_yy DESC ")

            Dim ps() As SqlParameter = { _
         New SqlParameter("@Flow_id", Flow_id), _
          New SqlParameter("@Org_code", Org_code)}

            Return Query(StrSQL.ToString(), ps)
        End Function


        'SELECT ONE
        Public Function SelectOne(Id As Integer) As DataTable
            Dim StrSQL As New System.Text.StringBuilder


            StrSQL.Append(" SELECT  ")
            StrSQL.Append(" Flow_id,User_id,Unit_code,Apply_yy,Apply_date ")
            StrSQL.Append(" ,Org_code,ModUser_id,Mod_date ")
            StrSQL.Append("  FROM SAL_PROOF_rpt  ")
            StrSQL.Append("  WHERE 1=1  ")
            StrSQL.Append("  AND Id=@Id  ")

            Dim ps() As SqlParameter = { _
         New SqlParameter("@Id", Id)}

            Return Query(StrSQL.ToString(), ps)
        End Function

        'DELETE
        Public Sub Delete(Id As Integer)
            Dim StrSQL As New System.Text.StringBuilder
            StrSQL.Append(" DELETE FROM SAL_PROOF_rpt WHERE  Id=@Id  ")
            Dim ps() As SqlParameter = {New SqlParameter("@Id", Id)}

            Execute(StrSQL.ToString(), ps)
        End Sub


        Public Function Update(Apply_yy As String, orgcode As String, flow_id As String)
            Dim StrSQL As New System.Text.StringBuilder

            StrSQL.Append(" UPDATE SAL_PROOF_rpt SET  ")
            StrSQL.Append("     Apply_yy=@Apply_yy ")
            StrSQL.Append("  WHERE Org_code=@orgcode ")
            StrSQL.Append("  AND Flow_Id=@Flow_Id  ")

            Dim ps() As SqlParameter = { _
                New SqlParameter("@orgcode", orgcode), _
                New SqlParameter("@flow_id", flow_id), _
                New SqlParameter("@Apply_yy", Apply_yy)}

            Return Execute(StrSQL.ToString(), ps)
        End Function
    End Class
End Namespace