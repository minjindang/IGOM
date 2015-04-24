Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Namespace FSCPLM.Logic
    Public Class PRO_PropertyTran_detDAO
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


            StrSQL.Append(" INSERT INTO PRO_PropertyTran_det ( ")
            StrSQL.Append(" OrgCode,Flow_id,Property_id,Property_class,Property_name, ")
            StrSQL.Append(" OldUnit_code,OldKeeper_id,OldKeeper_name,OldLocation,OldBoss, ")
            StrSQL.Append(" OldProManager,NewUnit_code,NewKeeper_id,NewKeeper_name,NewLocation, ")
            StrSQL.Append(" NewBoss,NewProManager,Buy_date,Property_type,Fund, ")
            StrSQL.Append(" PropertyTran_date,Scrap_date,ModUser_id,Mod_date ")
            StrSQL.Append(") VALUES ( ")
            StrSQL.Append(" @OrgCode,@Flow_id,@Property_id,@Property_class,@Property_name, ")
            StrSQL.Append(" @OldUnit_code,@OldKeeper_id,@OldKeeper_name,@OldLocation,@OldBoss, ")
            StrSQL.Append(" @OldProManager,@NewUnit_code,@NewKeeper_id,@NewKeeper_name,@NewLocation, ")
            StrSQL.Append(" @NewBoss,@NewProManager,@Buy_date,@Property_type,@Fund, ")
            StrSQL.Append(" @PropertyTran_date,@Scrap_date,@ModUser_id,@Mod_date ")
            StrSQL.Append(" ) ")

            Execute(StrSQL.ToString(), ps)
        End Sub

        'Update
        Public Sub Update(ps() As SqlParameter)
            Dim StrSQL As New System.Text.StringBuilder


            StrSQL.Append(" UPDATE PRO_PropertyTran_det SET  ")
            StrSQL.Append(" OrgCode=@OrgCode,Flow_id=@Flow_id,Property_id=@Property_id,Property_class=@Property_class,Property_name=@Property_name, ")
            StrSQL.Append(" OldUnit_code=@OldUnit_code,OldKeeper_id=@OldKeeper_id,OldKeeper_name=@OldKeeper_name,OldLocation=@OldLocation,OldBoss=@OldBoss, ")
            StrSQL.Append(" OldProManager=@OldProManager,NewUnit_code=@NewUnit_code,NewKeeper_id=@NewKeeper_id,NewKeeper_name=@NewKeeper_name,NewLocation=@NewLocation, ")
            StrSQL.Append(" NewBoss=@NewBoss,NewProManager=@NewProManager,Buy_date=@Buy_date,Property_type=@Property_type,Fund=@Fund, ")
            StrSQL.Append(" PropertyTran_date=@PropertyTran_date,Scrap_date=@Scrap_date,ModUser_id=@ModUser_id,Mod_date=@Mod_date ")
            StrSQL.Append("  WHERE 1=1  ")
            StrSQL.Append("  AND Flow_id=@Flow_id  ")
            StrSQL.Append("  AND OrgCode=@OrgCode  ")
            StrSQL.Append("  AND Property_id=@Property_id  ")

            Execute(StrSQL.ToString(), ps)
        End Sub

        'SELECT ALL
        Public Function SelectAll(OrgCode As String, Optional Property_id As String = "", Optional Property_class As String = "") As DataTable
            Dim StrSQL As New System.Text.StringBuilder


            StrSQL.Append(" SELECT  ")
            StrSQL.Append(" OrgCode,Flow_id,Property_id,Property_class,Property_name, ")
            StrSQL.Append(" OldUnit_code,OldKeeper_id,OldKeeper_name,OldLocation,OldBoss, ")
            StrSQL.Append(" OldProManager,NewUnit_code,NewKeeper_id,NewKeeper_name,NewLocation, ")
            StrSQL.Append(" NewBoss,NewProManager,Buy_date,Property_type,Fund ")
            StrSQL.Append(" ,PropertyTran_date,Scrap_date,ModUser_id,Mod_date ")
            StrSQL.Append("  FROM PRO_PropertyTran_det  ")
            StrSQL.Append("  WHERE OrgCode=@OrgCode  ")

            If Not String.IsNullOrEmpty(Property_id) Then
                StrSQL.Append("  AND Property_id=@Property_id  ")
            End If

            If Not String.IsNullOrEmpty(Property_class) Then
                StrSQL.Append("  AND Property_class=@Property_class  ")
            End If


            Dim ps() As SqlParameter = { _
         New SqlParameter("@OrgCode", OrgCode), _
          New SqlParameter("@Property_id", Property_id), _
          New SqlParameter("@Property_class", Property_class)}

            Return Query(StrSQL.ToString(), ps)
        End Function

        'SELECT ONE
        Public Function SelectOne(Flow_id As String, OrgCode As String, Property_id As String) As DataTable
            Dim StrSQL As New System.Text.StringBuilder


            StrSQL.Append(" SELECT  ")
            StrSQL.Append(" OrgCode,Flow_id,Property_id,Property_class,Property_name, ")
            StrSQL.Append(" OldUnit_code,OldKeeper_id,OldKeeper_name,OldLocation,OldBoss, ")
            StrSQL.Append(" OldProManager,NewUnit_code,NewKeeper_id,NewKeeper_name,NewLocation, ")
            StrSQL.Append(" NewBoss,NewProManager,Buy_date,Property_type,Fund ")
            StrSQL.Append(" ,PropertyTran_date,Scrap_date,ModUser_id,Mod_date ")
            StrSQL.Append("  FROM PRO_PropertyTran_det  ")
            StrSQL.Append("  WHERE 1=1  ")
            StrSQL.Append("  AND Flow_id=@Flow_id  ")
            StrSQL.Append("  AND OrgCode=@OrgCode  ")

            If Not String.IsNullOrEmpty(Property_id) Then
                StrSQL.Append("  AND Property_id=@Property_id  ")
            End If

            Dim ps() As SqlParameter = { _
         New SqlParameter("@Flow_id", Flow_id), _
         New SqlParameter("@OrgCode", OrgCode), _
         New SqlParameter("@Property_id", Property_id)}

            Return Query(StrSQL.ToString(), ps)
        End Function

        'DELETE
        Public Sub Delete(Flow_id As String, OrgCode As String, Property_id As String)
            Dim StrSQL As New System.Text.StringBuilder
            StrSQL.Append(" DELETE FROM PRO_PropertyTran_det WHERE  Flow_id=@Flow_id AND OrgCode=@OrgCode AND Property_id=@Property_id  ")
            Dim ps() As SqlParameter = {New SqlParameter("@Flow_id", Flow_id), New SqlParameter("@OrgCode", OrgCode), New SqlParameter("@Property_id", Property_id)}

            Execute(StrSQL.ToString(), ps)
        End Sub

        Public Function GetApplyPropertyId() As DataTable

            Return Query("select distinct Property_id from PRO_PropertyTran_det a left join SYS_Flow b on a.Flow_id = b.Flow_id where b.Case_status in ('0','1','2')")
        End Function
    End Class
End Namespace