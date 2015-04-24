Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Namespace FSCPLM.Logic
    Public Class PRO_PropertyTran_mainDAO
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


            StrSQL.Append(" INSERT INTO PRO_PropertyTran_main ( ")
            StrSQL.Append(" OrgCode,Flow_id,Property_type,NewUnit_name,NewKeeper_id, ")
            StrSQL.Append(" NewLocation,ApplyTran_unit,ApplyTran_id,ModUser_id,Mod_date, ")
            StrSQL.Append(" Fund ")
            StrSQL.Append(") VALUES ( ")
            StrSQL.Append(" @OrgCode,@Flow_id,@Property_type,@NewUnit_name,@NewKeeper_id, ")
            StrSQL.Append(" @NewLocation,@ApplyTran_unit,@ApplyTran_id,@ModUser_id,@Mod_date, ")
            StrSQL.Append(" @Fund ")
            StrSQL.Append(" ) ")

            Execute(StrSQL.ToString(), ps)
        End Sub

        'Update
        Public Sub Update(ps() As SqlParameter)
            Dim StrSQL As New System.Text.StringBuilder


            StrSQL.Append(" UPDATE PRO_PropertyTran_main SET  ")
            StrSQL.Append(" OrgCode=@OrgCode,Flow_id=@Flow_id,Property_type=@Property_type,NewUnit_name=@NewUnit_name,NewKeeper_id=@NewKeeper_id, ")
            StrSQL.Append(" NewLocation=@NewLocation,ApplyTran_unit=@ApplyTran_unit,ApplyTran_id=@ApplyTran_id,ModUser_id=@ModUser_id,Mod_date=@Mod_date, ")
            StrSQL.Append(" Fund=@Fund ")
            StrSQL.Append("  WHERE 1=1  ")
            StrSQL.Append("  AND Flow_id=@Flow_id  ")
            StrSQL.Append("  AND OrgCode=@OrgCode  ")

            Execute(StrSQL.ToString(), ps)
        End Sub

        'SELECT ALL
        Public Function SelectAll() As DataTable
            Dim StrSQL As New System.Text.StringBuilder


            StrSQL.Append(" SELECT  ")
            StrSQL.Append(" OrgCode,Flow_id,Property_type,NewUnit_name,NewKeeper_id, ")
            StrSQL.Append(" NewLocation,ApplyTran_unit,ApplyTran_id,ModUser_id,Mod_date ")
            StrSQL.Append(" ,Fund ")
            StrSQL.Append("  FROM PRO_PropertyTran_main  ")
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
            StrSQL.Append(" OrgCode,Flow_id,Property_type,NewUnit_name,NewKeeper_id, ")
            StrSQL.Append(" NewLocation,ApplyTran_unit,ApplyTran_id,ModUser_id,Mod_date ")
            StrSQL.Append(" ,Fund ")
            StrSQL.Append("  FROM PRO_PropertyTran_main  ")
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
            StrSQL.Append(" DELETE FROM PRO_PropertyTran_main WHERE  Flow_id=@Flow_id AND OrgCode=@OrgCode  ")
            Dim ps() As SqlParameter = {New SqlParameter("@Flow_id", Flow_id), New SqlParameter("@OrgCode", OrgCode)}

            Execute(StrSQL.ToString(), ps)
        End Sub

        Public Function getMaxWsStatus(Flow_id As String, OrgCode As String) As String
            Dim StrSQL As New System.Text.StringBuilder


            StrSQL.Append(" SELECT  ")
            StrSQL.Append(" max(WS_Status) ")
            StrSQL.Append("  FROM PRO_PropertyTran_main  ")
            StrSQL.Append("  WHERE 1=1  ")
            StrSQL.Append("  AND Flow_id=@Flow_id  ")
            StrSQL.Append("  AND OrgCode=@OrgCode  ")

            Dim ps() As SqlParameter = { _
             New SqlParameter("@Flow_id", Flow_id), _
             New SqlParameter("@OrgCode", OrgCode)}

            Dim obj As Object = Scalar(StrSQL.ToString(), ps)
            If Convert.IsDBNull(obj) Then
                obj = ""
            End If
            Return obj
        End Function

    End Class
End Namespace