Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Namespace FSCPLM.Logic
    Public Class PRO_SwRegister_mainDAO
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


            StrSQL.Append(" INSERT INTO PRO_SwRegister_main ( ")
            StrSQL.Append(" OrgCode,Flow_id,OfficialNumber_id,Software_id,Software_type, ")
            StrSQL.Append(" Software_name,Version,KeyNumber_nos,SoftwareKind_type,NetPLimit_cnt, ")
            StrSQL.Append(" Sofeware_cnt,Obtain_type,ObtainOt_desc,SoftwareUnit_name,StorageMedia_type, ")
            StrSQL.Append(" StorageMediaOt_desc,StorageMedia_cnt,RelatedPapers_name,LifeTime,Fee_amt, ")
            StrSQL.Append(" MRent_amt,Start_date,Unit_code,User_id,Register_date, ")
            StrSQL.Append(" Memo,ModUser_id,Mod_date ")
            StrSQL.Append(") VALUES ( ")
            StrSQL.Append(" @OrgCode,@Flow_id,@OfficialNumber_id,@Software_id,@Software_type, ")
            StrSQL.Append(" @Software_name,@Version,@KeyNumber_nos,@SoftwareKind_type,@NetPLimit_cnt, ")
            StrSQL.Append(" @Sofeware_cnt,@Obtain_type,@ObtainOt_desc,@SoftwareUnit_name,@StorageMedia_type, ")
            StrSQL.Append(" @StorageMediaOt_desc,@StorageMedia_cnt,@RelatedPapers_name,@LifeTime,@Fee_amt, ")
            StrSQL.Append(" @MRent_amt,@Start_date,@Unit_code,@User_id,@Register_date, ")
            StrSQL.Append(" @Memo,@ModUser_id,@Mod_date ")
            StrSQL.Append(" ) ")

            Execute(StrSQL.ToString(), ps)
        End Sub

        'Update
        Public Sub Update(ps() As SqlParameter)
            Dim StrSQL As New System.Text.StringBuilder


            StrSQL.Append(" UPDATE PRO_SwRegister_main SET  ")
            StrSQL.Append(" OrgCode=@OrgCode,Flow_id=@Flow_id,OfficialNumber_id=@OfficialNumber_id,Software_id=@Software_id,Software_type=@Software_type, ")
            StrSQL.Append(" Software_name=@Software_name,Version=@Version,KeyNumber_nos=@KeyNumber_nos,SoftwareKind_type=@SoftwareKind_type,NetPLimit_cnt=@NetPLimit_cnt, ")
            StrSQL.Append(" Sofeware_cnt=@Sofeware_cnt,Obtain_type=@Obtain_type,ObtainOt_desc=@ObtainOt_desc,SoftwareUnit_name=@SoftwareUnit_name,StorageMedia_type=@StorageMedia_type, ")
            StrSQL.Append(" StorageMediaOt_desc=@StorageMediaOt_desc,StorageMedia_cnt=@StorageMedia_cnt,RelatedPapers_name=@RelatedPapers_name,LifeTime=@LifeTime,Fee_amt=@Fee_amt, ")
            StrSQL.Append(" MRent_amt=@MRent_amt,Start_date=@Start_date,Unit_code=@Unit_code,User_id=@User_id,Register_date=@Register_date, ")
            StrSQL.Append(" Memo=@Memo,ModUser_id=@ModUser_id,Mod_date=@Mod_date ")
            StrSQL.Append("  WHERE 1=1  ")
            StrSQL.Append("  AND Flow_id=@Flow_id  ")
            StrSQL.Append("  AND OrgCode=@OrgCode  ")

            Execute(StrSQL.ToString(), ps)
        End Sub

        'SELECT ALL
        Public Function SelectAll() As DataTable
            Dim StrSQL As New System.Text.StringBuilder


            StrSQL.Append(" SELECT  ")
            StrSQL.Append(" OrgCode,Flow_id,OfficialNumber_id,Software_id,Software_type, ")
            StrSQL.Append(" Software_name,Version,KeyNumber_nos,SoftwareKind_type,NetPLimit_cnt, ")
            StrSQL.Append(" Sofeware_cnt,Obtain_type,ObtainOt_desc,SoftwareUnit_name,StorageMedia_type, ")
            StrSQL.Append(" StorageMediaOt_desc,StorageMedia_cnt,RelatedPapers_name,LifeTime,Fee_amt, ")
            StrSQL.Append(" MRent_amt,Start_date,Unit_code,User_id,Register_date ")
            StrSQL.Append("  FROM PRO_SwRegister_main  ")
            StrSQL.Append("  WHERE 1=1  ")

            Dim ps() As SqlParameter = { _
         New SqlParameter("@param1", ""), _
          New SqlParameter("@param2", "")}

            Return Query(StrSQL.ToString(), ps)
        End Function

        'SELECT ONE
        Public Function SelectOne(Flow_id As String, OrgCode As String) As DataTable
            Dim StrSQL As New System.Text.StringBuilder


            StrSQL.Append(" SELECT  ")
            StrSQL.Append(" OrgCode,Flow_id,OfficialNumber_id,Software_id,Software_type, ")
            StrSQL.Append(" Software_name,Version,KeyNumber_nos,SoftwareKind_type,NetPLimit_cnt, ")
            StrSQL.Append(" Sofeware_cnt,Obtain_type,ObtainOt_desc,SoftwareUnit_name,StorageMedia_type, ")
            StrSQL.Append(" StorageMediaOt_desc,StorageMedia_cnt,RelatedPapers_name,LifeTime,Fee_amt, ")
            StrSQL.Append(" MRent_amt,Start_date,Unit_code,User_id,Register_date,Memo ")
            StrSQL.Append("  FROM PRO_SwRegister_main  ")
            StrSQL.Append("  WHERE 1=1  ")
            StrSQL.Append("  AND Flow_id=@Flow_id  ")
            StrSQL.Append("  AND OrgCode=@OrgCode  ")

            Dim ps() As SqlParameter = { _
         New SqlParameter("@Flow_id", Flow_id), _
         New SqlParameter("@OrgCode", OrgCode)}

            Return Query(StrSQL.ToString(), ps)
        End Function

        'DELETE
        Public Sub Delete(Flow_id As String, OrgCode As String)
            Dim StrSQL As New System.Text.StringBuilder
            StrSQL.Append(" DELETE FROM PRO_SwRegister_main WHERE  Flow_id=@Flow_id AND OrgCode=@OrgCode  ")
            Dim ps() As SqlParameter = {New SqlParameter("@Flow_id", Flow_id), New SqlParameter("@OrgCode", OrgCode)}

            Execute(StrSQL.ToString(), ps)
        End Sub


    End Class
End Namespace