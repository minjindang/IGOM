Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Namespace FSCPLM.Logic
    Public Class OTH_InfoNet_Service_mainDAO
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


            StrSQL.Append(" INSERT INTO OTH_InfoNet_Service_main ( ")
            StrSQL.Append(" OrgCode,Flow_id,User_id,User_unit,apply_type, ")
            StrSQL.Append(" apply_type_desc,apply_reason,apply_StartDate,apply_EndDate,apply_acc_req, ")
            StrSQL.Append(" newMac_addr,chgMac_addr,oldMac_addr,equipRoom_type,equipRoom_Memo, ")
            StrSQL.Append(" dns_ip,dns_host,port_open,admin_sys,ModUser_id, ")
            StrSQL.Append(" Mod_date ")
            StrSQL.Append(") VALUES ( ")
            StrSQL.Append(" @OrgCode,@Flow_id,@User_id,@User_unit,@apply_type, ")
            StrSQL.Append(" @apply_type_desc,@apply_reason,@apply_StartDate,@apply_EndDate,@apply_acc_req, ")
            StrSQL.Append(" @newMac_addr,@chgMac_addr,@oldMac_addr,@equipRoom_type,@equipRoom_Memo, ")
            StrSQL.Append(" @dns_ip,@dns_host,@port_open,@admin_sys,@ModUser_id, ")
            StrSQL.Append(" @Mod_date ")
            StrSQL.Append(" ) ")

            Execute(StrSQL.ToString(), ps)
        End Sub

        'Update
        Public Sub Update(ps() As SqlParameter)
            Dim StrSQL As New System.Text.StringBuilder


            StrSQL.Append(" UPDATE OTH_InfoNet_Service_main SET  ")
            StrSQL.Append(" OrgCode=@OrgCode,Flow_id=@Flow_id,User_id=@User_id,User_unit=@User_unit,apply_type=@apply_type, ")
            StrSQL.Append(" apply_type_desc=@apply_type_desc,apply_reason=@apply_reason,apply_StartDate=@apply_StartDate,apply_EndDate=@apply_EndDate,apply_acc_req=@apply_acc_req, ")
            StrSQL.Append(" newMac_addr=@newMac_addr,chgMac_addr=@chgMac_addr,oldMac_addr=@oldMac_addr,equipRoom_type=@equipRoom_type,equipRoom_Memo=@equipRoom_Memo, ")
            StrSQL.Append(" dns_ip=@dns_ip,dns_host=@dns_host,port_open=@port_open,admin_sys=@admin_sys,ModUser_id=@ModUser_id, ")
            StrSQL.Append(" Mod_date=@Mod_date ")
            StrSQL.Append("  WHERE 1=1  ")
            StrSQL.Append("  AND Flow_id=@Flow_id  ")
            StrSQL.Append("  AND OrgCode=@OrgCode  ")

            Execute(StrSQL.ToString(), ps)
        End Sub

        'SELECT ALL
        Public Function SelectAll() As DataTable
            Dim StrSQL As New System.Text.StringBuilder


            StrSQL.Append(" SELECT  ")
            StrSQL.Append(" OrgCode,Flow_id,User_id,User_unit,apply_type, ")
            StrSQL.Append(" apply_type_desc,apply_reason,apply_StartDate,apply_EndDate,apply_acc_req, ")
            StrSQL.Append(" newMac_addr,chgMac_addr,oldMac_addr,equipRoom_type,equipRoom_Memo, ")
            StrSQL.Append(" dns_ip,dns_host,port_open,admin_sys,ModUser_id ")
            StrSQL.Append(" ,Mod_date ")
            StrSQL.Append("  FROM OTH_InfoNet_Service_main  ")
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
            StrSQL.Append(" OrgCode,Flow_id,User_id,User_unit,apply_type, ")
            StrSQL.Append(" apply_type_desc,apply_reason,apply_StartDate,apply_EndDate,apply_acc_req, ")
            StrSQL.Append(" newMac_addr,chgMac_addr,oldMac_addr,equipRoom_type,equipRoom_Memo, ")
            StrSQL.Append(" dns_ip,dns_host,port_open,admin_sys,ModUser_id ")
            StrSQL.Append(" ,Mod_date ")
            StrSQL.Append("  FROM OTH_InfoNet_Service_main  ")
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
            StrSQL.Append(" DELETE FROM OTH_InfoNet_Service_main WHERE  Flow_id=@Flow_id AND OrgCode=@OrgCode  ")
            Dim ps() As SqlParameter = {New SqlParameter("@Flow_id", Flow_id), New SqlParameter("@OrgCode", OrgCode)}

            Execute(StrSQL.ToString(), ps)
        End Sub


    End Class
End Namespace