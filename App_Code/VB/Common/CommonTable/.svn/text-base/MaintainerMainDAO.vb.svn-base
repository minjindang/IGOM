Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration

Namespace FSCPLM.Logic
    Public Class MaintainerMainDAO

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


            StrSQL.Append(" INSERT INTO MAI_Maintainer_main ( ")
            StrSQL.Append(" OrgCode,MaintainerPhone_nos,Maintainer_name,Maintain_type,MtItem_type, ")
            StrSQL.Append(" ModUser_id,Mod_date,MtUnit_code,MtUser_id ")
            StrSQL.Append(") VALUES ( ")
            StrSQL.Append(" @OrgCode,@MaintainerPhone_nos,@Maintainer_name,@Maintain_type,@MtItem_type, ")
            StrSQL.Append(" @ModUser_id,@Mod_date,@MtUnit_code,@MtUser_id ")
            StrSQL.Append(" ) ")

            Execute(StrSQL.ToString(), ps)
        End Sub

        'Update
        Public Sub Update(ps() As SqlParameter)
            Dim StrSQL As New System.Text.StringBuilder


            StrSQL.Append(" UPDATE MAI_Maintainer_main SET  ")
            StrSQL.Append(" OrgCode=@OrgCode,MaintainerPhone_nos=@MaintainerPhone_nos,Maintainer_name=@Maintainer_name,Maintain_type=@Maintain_type,MtItem_type=@MtItem_type, ")
            StrSQL.Append(" ModUser_id=@ModUser_id,Mod_date=@Mod_date,MtUnit_code=@MtUnit_code,MtUser_id=@MtUser_id ")
            StrSQL.Append("  WHERE 1=1  ")
            StrSQL.Append("  AND MaintainerPhone_nos=@MaintainerPhone_nos  ")
            StrSQL.Append("  AND OrgCode=@OrgCode  ")

            Execute(StrSQL.ToString(), ps)
        End Sub

        'SELECT ALL
        Public Function SelectAll(OrgCode As String, Optional Maintain_type As String = "", Optional MtItem_type As String = "", _
                                  Optional MtUnit_code As String = "", Optional MtUser_id As String = "", Optional MaintainerPhone_nos As String = "") As DataTable
            Dim StrSQL As New System.Text.StringBuilder


            StrSQL.Append(" SELECT  ")
            StrSQL.Append(" OrgCode,MaintainerPhone_nos,Maintainer_name,Maintain_type,MtItem_type ")
            StrSQL.Append(" ,ModUser_id,Mod_date,MtUnit_code,MtUser_id ")
            StrSQL.Append("  FROM MAI_Maintainer_main  ")
            StrSQL.Append("  WHERE OrgCode=@OrgCode  ")

            If Not String.IsNullOrEmpty(MtItem_type) Then
                StrSQL.Append("  AND @MtItem_type like '%' + MtItem_type + '%' ")
            End If

            If Not String.IsNullOrEmpty(Maintain_type) Then
                StrSQL.Append("  AND Maintain_type=@Maintain_type  ")
            End If

            If Not String.IsNullOrEmpty(MtUnit_code) Then
                StrSQL.Append("  AND MtUnit_code=@MtUnit_code  ")
            End If

            If Not String.IsNullOrEmpty(MtUser_id) Then
                StrSQL.Append("  AND MtUser_id=@MtUser_id  ")
            End If

            If Not String.IsNullOrEmpty(MaintainerPhone_nos) Then
                StrSQL.Append("  AND MaintainerPhone_nos=@MaintainerPhone_nos  ")
            End If


            Dim ps() As SqlParameter = { _
              New SqlParameter("@OrgCode", OrgCode), _
              New SqlParameter("@Maintain_type", Maintain_type), _
              New SqlParameter("@MtItem_type", MtItem_type), _
              New SqlParameter("@MtUnit_code", MtUnit_code), _
              New SqlParameter("@MtUser_id", MtUser_id), _
              New SqlParameter("@MaintainerPhone_nos", MaintainerPhone_nos)}

            Return Query(StrSQL.ToString(), ps)
        End Function

        'SELECT ONE
        Public Function SelectOne(MaintainerPhone_nos As String, OrgCode As String) As DataTable
            Dim StrSQL As New System.Text.StringBuilder


            StrSQL.Append(" SELECT  ")
            StrSQL.Append(" OrgCode,MaintainerPhone_nos,Maintainer_name,Maintain_type,MtItem_type ")
            StrSQL.Append(" ,ModUser_id,Mod_date,MtUnit_code,MtUser_id ")
            StrSQL.Append("  FROM MAI_Maintainer_main  ")
            StrSQL.Append("  WHERE 1=1  ")
            StrSQL.Append("  AND MaintainerPhone_nos=@MaintainerPhone_nos  ")
            StrSQL.Append("  AND OrgCode=@OrgCode  ")

            Dim ps() As SqlParameter = { _
         New SqlParameter("@MaintainerPhone_nos", MaintainerPhone_nos), _
         New SqlParameter("@OrgCode", OrgCode)}

            Return Query(StrSQL.ToString(), ps)
        End Function

        'DELETE
        Public Sub Delete(MaintainerPhone_nos As String, OrgCode As String)
            Dim StrSQL As New System.Text.StringBuilder
            StrSQL.Append(" DELETE FROM MAI_Maintainer_main WHERE  MaintainerPhone_nos=@MaintainerPhone_nos AND OrgCode=@OrgCode  ")
            Dim ps() As SqlParameter = {New SqlParameter("@MaintainerPhone_nos", MaintainerPhone_nos), New SqlParameter("@OrgCode", OrgCode)}

            Execute(StrSQL.ToString(), ps)
        End Sub


    End Class
End Namespace
