Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Namespace FSCPLM.Logic
    Public Class PRO_PropertyScrap_mainDAO
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


            StrSQL.Append(" INSERT INTO PRO_PropertyScrap_main ( ")
            StrSQL.Append(" OrgCode,Flow_id,Property_id,Property_clsno,Scrap_unit, ")
            StrSQL.Append(" Scrap_id,Property_name,Property_type,Location,LifeTime, ")
            StrSQL.Append(" Buy_date,AllowScrap_date,Scrap_date,ScrapReason_type,ModUser_id, ")
            StrSQL.Append(" Mod_date ")
            StrSQL.Append(") VALUES ( ")
            StrSQL.Append(" @OrgCode,@Flow_id,@Property_id,@Property_clsno,@Scrap_unit, ")
            StrSQL.Append(" @Scrap_id,@Property_name,@Property_type,@Location,@LifeTime, ")
            StrSQL.Append(" @Buy_date,@AllowScrap_date,@Scrap_date,@ScrapReason_type,@ModUser_id, ")
            StrSQL.Append(" @Mod_date ")
            StrSQL.Append(" ) ")

            Execute(StrSQL.ToString(), ps)
        End Sub

        'Update
        Public Sub Update(ps() As SqlParameter)
            Dim StrSQL As New System.Text.StringBuilder


            StrSQL.Append(" UPDATE PRO_PropertyScrap_main SET  ")
            StrSQL.Append(" OrgCode=@OrgCode,Flow_id=@Flow_id,Property_id=@Property_id,Property_clsno=@Property_clsno,Scrap_unit=@Scrap_unit, ")
            StrSQL.Append(" Scrap_id=@Scrap_id,Property_name=@Property_name,Property_type=@Property_type,Location=@Location,LifeTime=@LifeTime, ")
            StrSQL.Append(" Buy_date=@Buy_date,AllowScrap_date=@AllowScrap_date,Scrap_date=@Scrap_date,ScrapReason_type=@ScrapReason_type,ModUser_id=@ModUser_id, ")
            StrSQL.Append(" Mod_date=@Mod_date ")
            StrSQL.Append("  WHERE 1=1  ")
            StrSQL.Append("  AND Flow_id=@Flow_id  ")
            StrSQL.Append("  AND OrgCode=@OrgCode  ")
            StrSQL.Append("  AND Property_id=@Property_id  ")

            Execute(StrSQL.ToString(), ps)
        End Sub

        'SELECT ALL
        Public Function SelectAll() As DataTable
            Dim StrSQL As New System.Text.StringBuilder


            StrSQL.Append(" SELECT  ")
            StrSQL.Append(" OrgCode,Flow_id,Property_id,Property_clsno,Scrap_unit, ")
            StrSQL.Append(" Scrap_id,Property_name,Property_type,Location,LifeTime, ")
            StrSQL.Append(" Buy_date,AllowScrap_date,Scrap_date,ScrapReason_type,ModUser_id ")
            StrSQL.Append(" ,Mod_date ")
            StrSQL.Append("  FROM PRO_PropertyScrap_main  ")
            StrSQL.Append("  WHERE 1=1  ")

            Dim ps() As SqlParameter = { _
         New SqlParameter("@param1", ""), _
          New SqlParameter("@param2", "")}

            Return Query(StrSQL.ToString(), ps)
        End Function

        'SELECT ONE
        Public Function SelectOne(Flow_id As String, OrgCode As String, Property_id As String) As DataTable
            Dim StrSQL As New System.Text.StringBuilder


            StrSQL.Append(" SELECT  ")
            StrSQL.Append(" OrgCode,Flow_id,Property_id,Property_clsno,Scrap_unit, ")
            StrSQL.Append(" Scrap_id,Property_name,Property_type,Location,LifeTime, ")
            StrSQL.Append(" Buy_date,AllowScrap_date,Scrap_date,ScrapReason_type,ModUser_id ")
            StrSQL.Append(" ,Mod_date ")
            StrSQL.Append("  FROM PRO_PropertyScrap_main  ")
            StrSQL.Append("  WHERE 1=1  ")
            StrSQL.Append("  AND Flow_id=@Flow_id  ")
            StrSQL.Append("  AND OrgCode=@OrgCode  ")
            StrSQL.Append("  AND Property_id=@Property_id  ")

            Dim ps() As SqlParameter = { _
         New SqlParameter("@Flow_id", Flow_id), _
         New SqlParameter("@OrgCode", OrgCode), _
         New SqlParameter("@Property_id", Property_id)}

            Return Query(StrSQL.ToString(), ps)
        End Function
         
        'DELETE
        Public Sub Delete(Flow_id As String, OrgCode As String, Property_id As String)
            Dim StrSQL As New System.Text.StringBuilder
            StrSQL.Append(" DELETE FROM PRO_PropertyScrap_main WHERE  Flow_id=@Flow_id AND OrgCode=@OrgCode AND Property_id=@Property_id  ")
            Dim ps() As SqlParameter = {New SqlParameter("@Flow_id", Flow_id), New SqlParameter("@OrgCode", OrgCode), New SqlParameter("@Property_id", Property_id)}

            Execute(StrSQL.ToString(), ps)
        End Sub

        Public Sub DeleteByFid(ByVal flow_id As String)
            Dim StrSQL As New System.Text.StringBuilder
            StrSQL.Append(" DELETE FROM PRO_PropertyScrap_main WHERE  flow_id=@flow_id  ")

            Dim ps() As SqlParameter = { _
                New SqlParameter("@flow_id", flow_id)}

            Execute(StrSQL.ToString(), ps)
        End Sub


        Public Function GetApplyPropertyId() As DataTable
            Dim sql As String = " select distinct Property_id from PRO_PropertyScrap_main a left join SYS_Flow b on a.Flow_id = b.Flow_id where b.Case_status in ('0','1','2') "
            Return Query(sql)
        End Function


        Public Function getMaxWsStatus(Flow_id As String, OrgCode As String) As String
            Dim StrSQL As New System.Text.StringBuilder


            StrSQL.Append(" SELECT  ")
            StrSQL.Append(" max(WS_Status) ")
            StrSQL.Append("  FROM PRO_PropertyScrap_main  ")
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