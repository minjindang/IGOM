Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections.Generic

Namespace FSCPLM.Logic

    Public Class OTH_InfoNet_Service_main
        Public DAO As OTH_InfoNet_Service_mainDAO

        Public Sub New()
            DAO = New OTH_InfoNet_Service_mainDAO()
        End Sub

        Public Function GetOne(Flow_id As String, OrgCode As String) As DataRow
            Dim dt As DataTable = DAO.SelectOne(Flow_id, OrgCode)
            If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                Return dt.Rows(0)
            Else
                Return Nothing
            End If
        End Function

        Public Function GetAll() As DataTable
            Dim dt As DataTable = DAO.SelectAll()
            If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                Return dt
            Else
                Return Nothing
            End If
        End Function

        Public Sub Add(OrgCode As String, Flow_id As String, User_id As String, User_unit As String, apply_type As String, _
apply_type_desc As String, apply_reason As String, apply_StartDate As String, apply_EndDate As String, apply_acc_req As String, _
newMac_addr As String, chgMac_addr As String, oldMac_addr As String, equipRoom_type As String, equipRoom_Memo As String, _
dns_ip As String, dns_host As String, port_open As String, admin_sys As String, ModUser_id As String, Mod_date As DateTime)
            Dim psList As New List(Of SqlParameter)

            If Not String.IsNullOrEmpty(OrgCode) Then
                psList.Add(New SqlParameter("@OrgCode", OrgCode))
            Else
                psList.Add(New SqlParameter("@OrgCode", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(Flow_id) Then
                psList.Add(New SqlParameter("@Flow_id", Flow_id))
            Else
                psList.Add(New SqlParameter("@Flow_id", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(User_id) Then
                psList.Add(New SqlParameter("@User_id", User_id))
            Else
                psList.Add(New SqlParameter("@User_id", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(User_unit) Then
                psList.Add(New SqlParameter("@User_unit", User_unit))
            Else
                psList.Add(New SqlParameter("@User_unit", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(apply_type) Then
                psList.Add(New SqlParameter("@apply_type", apply_type))
            Else
                psList.Add(New SqlParameter("@apply_type", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(apply_type_desc) Then
                psList.Add(New SqlParameter("@apply_type_desc", apply_type_desc))
            Else
                psList.Add(New SqlParameter("@apply_type_desc", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(apply_reason) Then
                psList.Add(New SqlParameter("@apply_reason", apply_reason))
            Else
                psList.Add(New SqlParameter("@apply_reason", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(apply_StartDate) Then
                psList.Add(New SqlParameter("@apply_StartDate", apply_StartDate))
            Else
                psList.Add(New SqlParameter("@apply_StartDate", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(apply_EndDate) Then
                psList.Add(New SqlParameter("@apply_EndDate", apply_EndDate))
            Else
                psList.Add(New SqlParameter("@apply_EndDate", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(apply_acc_req) Then
                psList.Add(New SqlParameter("@apply_acc_req", apply_acc_req))
            Else
                psList.Add(New SqlParameter("@apply_acc_req", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(newMac_addr) Then
                psList.Add(New SqlParameter("@newMac_addr", newMac_addr))
            Else
                psList.Add(New SqlParameter("@newMac_addr", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(chgMac_addr) Then
                psList.Add(New SqlParameter("@chgMac_addr", chgMac_addr))
            Else
                psList.Add(New SqlParameter("@chgMac_addr", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(oldMac_addr) Then
                psList.Add(New SqlParameter("@oldMac_addr", oldMac_addr))
            Else
                psList.Add(New SqlParameter("@oldMac_addr", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(equipRoom_type) Then
                psList.Add(New SqlParameter("@equipRoom_type", equipRoom_type))
            Else
                psList.Add(New SqlParameter("@equipRoom_type", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(equipRoom_Memo) Then
                psList.Add(New SqlParameter("@equipRoom_Memo", equipRoom_Memo))
            Else
                psList.Add(New SqlParameter("@equipRoom_Memo", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(dns_ip) Then
                psList.Add(New SqlParameter("@dns_ip", dns_ip))
            Else
                psList.Add(New SqlParameter("@dns_ip", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(dns_host) Then
                psList.Add(New SqlParameter("@dns_host", dns_host))
            Else
                psList.Add(New SqlParameter("@dns_host", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(port_open) Then
                psList.Add(New SqlParameter("@port_open", port_open))
            Else
                psList.Add(New SqlParameter("@port_open", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(admin_sys) Then
                psList.Add(New SqlParameter("@admin_sys", admin_sys))
            Else
                psList.Add(New SqlParameter("@admin_sys", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(ModUser_id) Then
                psList.Add(New SqlParameter("@ModUser_id", ModUser_id))
            Else
                psList.Add(New SqlParameter("@ModUser_id", DBNull.Value))
            End If
            If Not Mod_date = DateTime.MinValue Then
                psList.Add(New SqlParameter("@Mod_date", Mod_date))
            Else
                psList.Add(New SqlParameter("@Mod_date", DBNull.Value))
            End If


            DAO.Insert(psList.ToArray())
        End Sub

        Public Sub Modify(Flow_id As String, OrgCode As String, User_id As String, User_unit As String, apply_type As String, _
apply_type_desc As String, apply_reason As String, apply_StartDate As String, apply_EndDate As String, apply_acc_req As String, _
newMac_addr As String, chgMac_addr As String, oldMac_addr As String, equipRoom_type As String, equipRoom_Memo As String, _
dns_ip As String, dns_host As String, port_open As String, admin_sys As String, ModUser_id As String, Mod_date As DateTime)

            Dim dr As DataRow = GetOne(Flow_id, OrgCode)

            Dim psList As New List(Of SqlParameter)

            psList.Add(New SqlParameter("@Flow_id", Flow_id))
            psList.Add(New SqlParameter("@OrgCode", OrgCode))
            If Not String.IsNullOrEmpty(User_id) Then
                psList.Add(New SqlParameter("@User_id", User_id))
            Else
                psList.Add(New SqlParameter("@User_id", dr("User_id")))
            End If
            If Not String.IsNullOrEmpty(User_unit) Then
                psList.Add(New SqlParameter("@User_unit", User_unit))
            Else
                psList.Add(New SqlParameter("@User_unit", dr("User_unit")))
            End If
            If Not String.IsNullOrEmpty(apply_type) Then
                psList.Add(New SqlParameter("@apply_type", apply_type))
            Else
                psList.Add(New SqlParameter("@apply_type", dr("apply_type")))
            End If
            If Not String.IsNullOrEmpty(apply_type_desc) Then
                psList.Add(New SqlParameter("@apply_type_desc", apply_type_desc))
            Else
                psList.Add(New SqlParameter("@apply_type_desc", dr("apply_type_desc")))
            End If
            If Not String.IsNullOrEmpty(apply_reason) Then
                psList.Add(New SqlParameter("@apply_reason", apply_reason))
            Else
                psList.Add(New SqlParameter("@apply_reason", dr("apply_reason")))
            End If
            If Not String.IsNullOrEmpty(apply_StartDate) Then
                psList.Add(New SqlParameter("@apply_StartDate", apply_StartDate))
            Else
                psList.Add(New SqlParameter("@apply_StartDate", dr("apply_StartDate")))
            End If
            If Not String.IsNullOrEmpty(apply_EndDate) Then
                psList.Add(New SqlParameter("@apply_EndDate", apply_EndDate))
            Else
                psList.Add(New SqlParameter("@apply_EndDate", dr("apply_EndDate")))
            End If
            If Not String.IsNullOrEmpty(apply_acc_req) Then
                psList.Add(New SqlParameter("@apply_acc_req", apply_acc_req))
            Else
                psList.Add(New SqlParameter("@apply_acc_req", dr("apply_acc_req")))
            End If
            If Not String.IsNullOrEmpty(newMac_addr) Then
                psList.Add(New SqlParameter("@newMac_addr", newMac_addr))
            Else
                psList.Add(New SqlParameter("@newMac_addr", dr("newMac_addr")))
            End If
            If Not String.IsNullOrEmpty(chgMac_addr) Then
                psList.Add(New SqlParameter("@chgMac_addr", chgMac_addr))
            Else
                psList.Add(New SqlParameter("@chgMac_addr", dr("chgMac_addr")))
            End If
            If Not String.IsNullOrEmpty(oldMac_addr) Then
                psList.Add(New SqlParameter("@oldMac_addr", oldMac_addr))
            Else
                psList.Add(New SqlParameter("@oldMac_addr", dr("oldMac_addr")))
            End If
            If Not String.IsNullOrEmpty(equipRoom_type) Then
                psList.Add(New SqlParameter("@equipRoom_type", equipRoom_type))
            Else
                psList.Add(New SqlParameter("@equipRoom_type", dr("equipRoom_type")))
            End If
            If Not String.IsNullOrEmpty(equipRoom_Memo) Then
                psList.Add(New SqlParameter("@equipRoom_Memo", equipRoom_Memo))
            Else
                psList.Add(New SqlParameter("@equipRoom_Memo", dr("equipRoom_Memo")))
            End If
            If Not String.IsNullOrEmpty(dns_ip) Then
                psList.Add(New SqlParameter("@dns_ip", dns_ip))
            Else
                psList.Add(New SqlParameter("@dns_ip", dr("dns_ip")))
            End If
            If Not String.IsNullOrEmpty(dns_host) Then
                psList.Add(New SqlParameter("@dns_host", dns_host))
            Else
                psList.Add(New SqlParameter("@dns_host", dr("dns_host")))
            End If
            If Not String.IsNullOrEmpty(port_open) Then
                psList.Add(New SqlParameter("@port_open", port_open))
            Else
                psList.Add(New SqlParameter("@port_open", dr("port_open")))
            End If
            If Not String.IsNullOrEmpty(admin_sys) Then
                psList.Add(New SqlParameter("@admin_sys", admin_sys))
            Else
                psList.Add(New SqlParameter("@admin_sys", dr("admin_sys")))
            End If
            If Not String.IsNullOrEmpty(ModUser_id) Then
                psList.Add(New SqlParameter("@ModUser_id", ModUser_id))
            Else
                psList.Add(New SqlParameter("@ModUser_id", dr("ModUser_id")))
            End If
            If Not Mod_date = DateTime.MinValue Then
                psList.Add(New SqlParameter("@Mod_date", Mod_date))
            Else
                psList.Add(New SqlParameter("@Mod_date", dr("Mod_date")))
            End If


            DAO.Update(psList.ToArray())


        End Sub

        Public Sub Remove(Flow_id As String, OrgCode As String)
            DAO.Delete(Flow_id, OrgCode)
        End Sub

    End Class
End Namespace
