Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Namespace FSCPLM.Logic
    Public Class PAY_ExaminePayer_mainDAO
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


            StrSQL.Append(" INSERT INTO PAY_ExaminePayer_main ( ")
            StrSQL.Append(" OrgCode,Payer_id,Payer_name,ModUser_id,Mod_date ")
            StrSQL.Append("  ")
            StrSQL.Append(") VALUES ( ")
            StrSQL.Append(" @OrgCode,@Payer_id,@Payer_name,@ModUser_id,@Mod_date ")
            StrSQL.Append("  ")
            StrSQL.Append(" ) ")

            Execute(StrSQL.ToString(), ps)
        End Sub

        'Update
        Public Sub Update(ps() As SqlParameter)
            Dim StrSQL As New System.Text.StringBuilder


            StrSQL.Append(" UPDATE PAY_ExaminePayer_main   ")
            StrSQL.Append(" SET Payer_name=@Payer_name,ModUser_id=@ModUser_id,Mod_date=@Mod_date ")
            StrSQL.Append("  WHERE 1=1  ")
            StrSQL.Append("  AND OrgCode=@OrgCode  ")
            StrSQL.Append("  AND Payer_id=@Payer_id  ")

            Execute(StrSQL.ToString(), ps)
        End Sub

        'SELECT ALL
        Public Function SelectAll(OrgCode As String, Optional Payer_id As String = "", Optional Payer_name As String = "") As DataTable
            Dim StrSQL As New System.Text.StringBuilder

            StrSQL.Append(" SELECT  ")
            StrSQL.Append(" OrgCode,Payer_id,Payer_name,ModUser_id, ")
            StrSQL.Append(" CONVERT(VARCHAR(3),CONVERT(VARCHAR(4),Mod_date,20) - 1911) + '/' + SUBSTRING(CONVERT(VARCHAR(10),Mod_date,20),6,2) + '/' + SUBSTRING(CONVERT(VARCHAR(10),Mod_date,20),9,2) AS Mod_date ")
            StrSQL.Append("  FROM PAY_ExaminePayer_main  ")
            StrSQL.Append("  WHERE OrgCode=@OrgCode  ")

            If Not String.IsNullOrEmpty(Payer_id) Then
                StrSQL.Append("  AND Payer_id=@Payer_id  ")
            End If

            If Not String.IsNullOrEmpty(Payer_name) Then
                StrSQL.Append("  AND Payer_name like '%' + @Payer_name + '%'  ")
            End If

            Dim ps() As SqlParameter = { _
         New SqlParameter("@OrgCode", OrgCode), _
          New SqlParameter("@Payer_id", Payer_id), _
          New SqlParameter("@Payer_name", Payer_name)}

            Return Query(StrSQL.ToString(), ps)
        End Function

        'SELECT ONE
        Public Function SelectOne(OrgCode As String, Payer_id As String) As DataTable
            Dim StrSQL As New System.Text.StringBuilder


            StrSQL.Append(" SELECT  ")
            StrSQL.Append(" OrgCode,Payer_id,Payer_name,ModUser_id,Mod_date ")
            StrSQL.Append("  FROM PAY_ExaminePayer_main  ")
            StrSQL.Append("  WHERE 1=1  ")
            StrSQL.Append("  AND OrgCode=@OrgCode  ")
            StrSQL.Append("  AND Payer_id=@Payer_id  ")

            Dim ps() As SqlParameter = { _
         New SqlParameter("@OrgCode", OrgCode), _
         New SqlParameter("@Payer_id", Payer_id)}

            Return Query(StrSQL.ToString(), ps)
        End Function

        'DELETE
        Public Sub Delete(OrgCode As String, Payer_id As String)
            Dim StrSQL As New System.Text.StringBuilder
            StrSQL.Append(" DELETE FROM PAY_ExaminePayer_main WHERE  OrgCode=@OrgCode AND Payer_id=@Payer_id  ")
            Dim ps() As SqlParameter = {New SqlParameter("@OrgCode", OrgCode), New SqlParameter("@Payer_id", Payer_id)}

            Execute(StrSQL.ToString(), ps)
        End Sub


    End Class
End Namespace