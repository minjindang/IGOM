Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections.Generic

Namespace FSCPLM.Logic

    Public Class SwMaintainMain
        Public DAO As SwMaintainMainDAO

        Public Sub New()
            DAO = New SwMaintainMainDAO()
        End Sub

        Public Function GetOne(orgCode As String, SwMaintain_code As String) As DataRow
            Dim dt As DataTable = DAO.GetOne(orgCode, SwMaintain_code)
            If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                Return dt.Rows(0)
            End If
            Return Nothing
        End Function

        Public Function GetSwMaintain_code(OrgCode As String) As String
            Dim code As String = CommonFun.getYYYMMDD & "001"
            Dim dt As DataTable = DAO.GetSwMaintain_code(OrgCode)
            If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                code = CommonFun.getYYYMMDD & (dt.Rows.Count + 1).ToString().PadLeft(3, "0")
            End If 
            Return code
        End Function

        Public Sub Insert(OrgCode As String, SwMaintain_code As String, Flow_id As String, MtClass_type As String, MtItem_type As String, Task_type As String, _
                         Phone_nos As String, Unit_code As String, User_id As String, ClientUnit_code As String, ClientUser_id As String, _
                         ServApply_type As String, Problem_desc As String, ApplyTime As DateTime, SfExpect_date As String, Attachment1 As String, _
                         Attachment2 As String, Memo As String, MtStartTime As DateTime, Forecast_date As String, MtEndTime As DateTime, _
                         ResponseTime As DateTime, MaintainerPhone_nos As String, Maintainer_name As String, MtStatus_type As String, MtStatus_desc As String, _
                         ServConfirm_type As String, ReqAttachment As String, Exceed3Month_type As String, ManagerCheck_type As String, ChiefCheck_type As String, _
                         Property_id As String, RepeatApply_type As String, ModUser_id As String, Mod_date As DateTime, MtSys_type As String)
            Dim psList As New List(Of SqlParameter)
            psList.Add(New SqlParameter("@OrgCode", OrgCode))
            psList.Add(New SqlParameter("@SwMaintain_code", SwMaintain_code))
            psList.Add(New SqlParameter("@Flow_id", Flow_id))
            If Not String.IsNullOrEmpty(MtClass_type) Then
                psList.Add(New SqlParameter("@MtClass_type", MtClass_type))
            Else
                psList.Add(New SqlParameter("@MtClass_type", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(MtItem_type) Then
                psList.Add(New SqlParameter("@MtItem_type", MtItem_type))
            Else
                psList.Add(New SqlParameter("@MtItem_type", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(Task_type) Then
                psList.Add(New SqlParameter("@Task_type", Task_type))
            Else
                psList.Add(New SqlParameter("@Task_type", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(Phone_nos) Then
                psList.Add(New SqlParameter("@Phone_nos", Phone_nos))
            Else
                psList.Add(New SqlParameter("@Phone_nos", DBNull.Value))
            End If
            psList.Add(New SqlParameter("@Unit_code", Unit_code))
            psList.Add(New SqlParameter("@User_id", User_id))
            If Not String.IsNullOrEmpty(ClientUnit_code) Then
                psList.Add(New SqlParameter("@ClientUnit_code", ClientUnit_code))
            Else
                psList.Add(New SqlParameter("@ClientUnit_code", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(ClientUser_id) Then
                psList.Add(New SqlParameter("@ClientUser_id", ClientUser_id))
            Else
                psList.Add(New SqlParameter("@ClientUser_id", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(ServApply_type) Then
                psList.Add(New SqlParameter("@ServApply_type", ServApply_type))
            Else
                psList.Add(New SqlParameter("@ServApply_type", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(Problem_desc) Then
                psList.Add(New SqlParameter("@Problem_desc", Problem_desc))
            Else
                psList.Add(New SqlParameter("@Problem_desc", DBNull.Value))
            End If
            If Not ApplyTime = DateTime.MinValue Then
                psList.Add(New SqlParameter("@ApplyTime", ApplyTime))
            Else
                psList.Add(New SqlParameter("@ApplyTime", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(SfExpect_date) Then
                psList.Add(New SqlParameter("@SfExpect_date", SfExpect_date))
            Else
                psList.Add(New SqlParameter("@SfExpect_date", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(Attachment1) Then
                psList.Add(New SqlParameter("@Attachment1", Attachment1))
            Else
                psList.Add(New SqlParameter("@Attachment1", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(Attachment2) Then
                psList.Add(New SqlParameter("@Attachment2", Attachment2))
            Else
                psList.Add(New SqlParameter("@Attachment2", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(Memo) Then
                psList.Add(New SqlParameter("@Memo", Memo))
            Else
                psList.Add(New SqlParameter("@Memo", DBNull.Value))
            End If
            If Not MtStartTime = DateTime.MinValue Then
                psList.Add(New SqlParameter("@MtStartTime", MtStartTime))
            Else
                psList.Add(New SqlParameter("@MtStartTime", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(Forecast_date) Then
                psList.Add(New SqlParameter("@Forecast_date", Forecast_date))
            Else
                psList.Add(New SqlParameter("@Forecast_date", DBNull.Value))
            End If
            If Not MtEndTime = DateTime.MinValue Then
                psList.Add(New SqlParameter("@MtEndTime", MtEndTime))
            Else
                psList.Add(New SqlParameter("@MtEndTime", DBNull.Value))
            End If
            If Not ResponseTime = DateTime.MinValue Then
                psList.Add(New SqlParameter("@ResponseTime", ResponseTime))
            Else
                psList.Add(New SqlParameter("@ResponseTime", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(MaintainerPhone_nos) Then
                psList.Add(New SqlParameter("@MaintainerPhone_nos", MaintainerPhone_nos))
            Else
                psList.Add(New SqlParameter("@MaintainerPhone_nos", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(Maintainer_name) Then
                psList.Add(New SqlParameter("@Maintainer_name", Maintainer_name))
            Else
                psList.Add(New SqlParameter("@Maintainer_name", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(MtStatus_type) Then
                psList.Add(New SqlParameter("@MtStatus_type", MtStatus_type))
            Else
                psList.Add(New SqlParameter("@MtStatus_type", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(MtStatus_desc) Then
                psList.Add(New SqlParameter("@MtStatus_desc", MtStatus_desc))
            Else
                psList.Add(New SqlParameter("@MtStatus_desc", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(ServConfirm_type) Then
                psList.Add(New SqlParameter("@ServConfirm_type", ServConfirm_type))
            Else
                psList.Add(New SqlParameter("@ServConfirm_type", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(ReqAttachment) Then
                psList.Add(New SqlParameter("@ReqAttachment", ReqAttachment))
            Else
                psList.Add(New SqlParameter("@ReqAttachment", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(Exceed3Month_type) Then
                psList.Add(New SqlParameter("@Exceed3Month_type", Exceed3Month_type))
            Else
                psList.Add(New SqlParameter("@Exceed3Month_type", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(ManagerCheck_type) Then
                psList.Add(New SqlParameter("@ManagerCheck_type", ManagerCheck_type))
            Else
                psList.Add(New SqlParameter("@ManagerCheck_type", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(ChiefCheck_type) Then
                psList.Add(New SqlParameter("@ChiefCheck_type", ChiefCheck_type))
            Else
                psList.Add(New SqlParameter("@ChiefCheck_type", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(Property_id) Then
                psList.Add(New SqlParameter("@Property_id", Property_id))
            Else
                psList.Add(New SqlParameter("@Property_id", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(RepeatApply_type) Then
                psList.Add(New SqlParameter("@RepeatApply_type", RepeatApply_type))
            Else
                psList.Add(New SqlParameter("@RepeatApply_type", DBNull.Value))
            End If
            psList.Add(New SqlParameter("@ModUser_id", ModUser_id))
            psList.Add(New SqlParameter("@Mod_date", Mod_date))

            If Not String.IsNullOrEmpty(MtSys_type) Then
                psList.Add(New SqlParameter("@MtSys_type", MtSys_type))
            Else
                psList.Add(New SqlParameter("@MtSys_type", DBNull.Value))
            End If

            DAO.Insert(psList.ToArray())


        End Sub

        Public Sub Update(OrgCode As String, SwMaintain_code As String, Flow_id As String, MtClass_type As String, MtItem_type As String, Task_type As String, _
                       Phone_nos As String, Unit_code As String, User_id As String, ClientUnit_code As String, ClientUser_id As String, _
                       ServApply_type As String, Problem_desc As String, ApplyTime As DateTime, SfExpect_date As String, Attachment1 As String, _
                       Attachment2 As String, Memo As String, MtStartTime As DateTime, Forecast_date As String, MtEndTime As DateTime, _
                       ResponseTime As DateTime, MaintainerPhone_nos As String, Maintainer_name As String, MtStatus_type As String, MtStatus_desc As String, _
                       ServConfirm_type As String, ReqAttachment As String, Exceed3Month_type As String, ManagerCheck_type As String, ChiefCheck_type As String, _
                       Property_id As String, RepeatApply_type As String, ModUser_id As String, Mod_date As DateTime, MtSys_type As String)

            Dim dr As DataRow = GetOne(OrgCode, SwMaintain_code)

            Dim psList As New List(Of SqlParameter)
            psList.Add(New SqlParameter("@OrgCode", OrgCode))
            psList.Add(New SqlParameter("@SwMaintain_code", SwMaintain_code))

            psList.Add(New SqlParameter("@Flow_id", Flow_id))
            If Not String.IsNullOrEmpty(MtClass_type) Then
                psList.Add(New SqlParameter("@MtClass_type", MtClass_type))
            Else
                psList.Add(New SqlParameter("@MtClass_type", dr("MtClass_type")))
            End If
            If Not String.IsNullOrEmpty(MtItem_type) Then
                psList.Add(New SqlParameter("@MtItem_type", MtItem_type))
            Else
                psList.Add(New SqlParameter("@MtItem_type", dr("MtItem_type")))
            End If
            If Not String.IsNullOrEmpty(Task_type) Then
                psList.Add(New SqlParameter("@Task_type", Task_type))
            Else
                psList.Add(New SqlParameter("@Task_type", dr("Task_type")))
            End If
            If Not String.IsNullOrEmpty(Phone_nos) Then
                psList.Add(New SqlParameter("@Phone_nos", Phone_nos))
            Else
                psList.Add(New SqlParameter("@Phone_nos", dr("Phone_nos")))
            End If
            psList.Add(New SqlParameter("@Unit_code", Unit_code))
            psList.Add(New SqlParameter("@User_id", User_id))
            If Not String.IsNullOrEmpty(ClientUnit_code) Then
                psList.Add(New SqlParameter("@ClientUnit_code", ClientUnit_code))
            Else
                psList.Add(New SqlParameter("@ClientUnit_code", dr("ClientUnit_code")))
            End If
            If Not String.IsNullOrEmpty(ClientUser_id) Then
                psList.Add(New SqlParameter("@ClientUser_id", ClientUser_id))
            Else
                psList.Add(New SqlParameter("@ClientUser_id", dr("ClientUser_id")))
            End If
            If Not String.IsNullOrEmpty(ServApply_type) Then
                psList.Add(New SqlParameter("@ServApply_type", ServApply_type))
            Else
                psList.Add(New SqlParameter("@ServApply_type", dr("ServApply_type")))
            End If
            If Not String.IsNullOrEmpty(Problem_desc) Then
                psList.Add(New SqlParameter("@Problem_desc", Problem_desc))
            Else
                psList.Add(New SqlParameter("@Problem_desc", dr("Problem_desc")))
            End If
            If Not ApplyTime = DateTime.MinValue Then
                psList.Add(New SqlParameter("@ApplyTime", ApplyTime))
            Else
                psList.Add(New SqlParameter("@ApplyTime", dr("ApplyTime")))
            End If
            If Not String.IsNullOrEmpty(SfExpect_date) Then
                psList.Add(New SqlParameter("@SfExpect_date", SfExpect_date))
            Else
                psList.Add(New SqlParameter("@SfExpect_date", dr("SfExpect_date")))
            End If
            If Not String.IsNullOrEmpty(Attachment1) Then
                psList.Add(New SqlParameter("@Attachment1", Attachment1))
            Else
                psList.Add(New SqlParameter("@Attachment1", dr("Attachment1")))
            End If
            If Not String.IsNullOrEmpty(Attachment2) Then
                psList.Add(New SqlParameter("@Attachment2", Attachment2))
            Else
                psList.Add(New SqlParameter("@Attachment2", dr("Attachment2")))
            End If
            If Not String.IsNullOrEmpty(Memo) Then
                psList.Add(New SqlParameter("@Memo", Memo))
            Else
                psList.Add(New SqlParameter("@Memo", dr("Memo")))
            End If
            If Not MtStartTime = DateTime.MinValue Then
                psList.Add(New SqlParameter("@MtStartTime", MtStartTime))
            Else
                psList.Add(New SqlParameter("@MtStartTime", dr("MtStartTime")))
            End If
            If Not String.IsNullOrEmpty(Forecast_date) Then
                psList.Add(New SqlParameter("@Forecast_date", Forecast_date))
            Else
                psList.Add(New SqlParameter("@Forecast_date", dr("Forecast_date")))
            End If
            If Not MtEndTime = DateTime.MinValue Then
                psList.Add(New SqlParameter("@MtEndTime", MtEndTime))
            Else
                psList.Add(New SqlParameter("@MtEndTime", dr("MtEndTime")))
            End If
            If Not ResponseTime = DateTime.MinValue Then
                psList.Add(New SqlParameter("@ResponseTime", ResponseTime))
            Else
                psList.Add(New SqlParameter("@ResponseTime", dr("ResponseTime")))
            End If
            If Not String.IsNullOrEmpty(MaintainerPhone_nos) Then
                psList.Add(New SqlParameter("@MaintainerPhone_nos", MaintainerPhone_nos))
            Else
                psList.Add(New SqlParameter("@MaintainerPhone_nos", dr("MaintainerPhone_nos")))
            End If
            If Not String.IsNullOrEmpty(Maintainer_name) Then
                psList.Add(New SqlParameter("@Maintainer_name", Maintainer_name))
            Else
                psList.Add(New SqlParameter("@Maintainer_name", dr("Maintainer_name")))
            End If
            If Not String.IsNullOrEmpty(MtStatus_type) Then
                psList.Add(New SqlParameter("@MtStatus_type", MtStatus_type))
            Else
                psList.Add(New SqlParameter("@MtStatus_type", dr("MtStatus_type")))
            End If
            If Not String.IsNullOrEmpty(MtStatus_desc) Then
                psList.Add(New SqlParameter("@MtStatus_desc", MtStatus_desc))
            Else
                psList.Add(New SqlParameter("@MtStatus_desc", dr("MtStatus_desc")))
            End If
            If Not String.IsNullOrEmpty(ServConfirm_type) Then
                psList.Add(New SqlParameter("@ServConfirm_type", ServConfirm_type))
            Else
                psList.Add(New SqlParameter("@ServConfirm_type", dr("ServConfirm_type")))
            End If
            If Not String.IsNullOrEmpty(ReqAttachment) Then
                psList.Add(New SqlParameter("@ReqAttachment", ReqAttachment))
            Else
                psList.Add(New SqlParameter("@ReqAttachment", dr("ReqAttachment")))
            End If
            If Not String.IsNullOrEmpty(Exceed3Month_type) Then
                psList.Add(New SqlParameter("@Exceed3Month_type", Exceed3Month_type))
            Else
                psList.Add(New SqlParameter("@Exceed3Month_type", dr("Exceed3Month_type")))
            End If
            If Not String.IsNullOrEmpty(ManagerCheck_type) Then
                psList.Add(New SqlParameter("@ManagerCheck_type", ManagerCheck_type))
            Else
                psList.Add(New SqlParameter("@ManagerCheck_type", dr("ManagerCheck_type")))
            End If
            If Not String.IsNullOrEmpty(ChiefCheck_type) Then
                psList.Add(New SqlParameter("@ChiefCheck_type", ChiefCheck_type))
            Else
                psList.Add(New SqlParameter("@ChiefCheck_type", dr("ChiefCheck_type")))
            End If
            If Not String.IsNullOrEmpty(Property_id) Then
                psList.Add(New SqlParameter("@Property_id", Property_id))
            Else
                psList.Add(New SqlParameter("@Property_id", dr("Property_id")))
            End If
            If Not String.IsNullOrEmpty(RepeatApply_type) Then
                psList.Add(New SqlParameter("@RepeatApply_type", RepeatApply_type))
            Else
                psList.Add(New SqlParameter("@RepeatApply_type", dr("RepeatApply_type")))
            End If
            psList.Add(New SqlParameter("@ModUser_id", ModUser_id))
            psList.Add(New SqlParameter("@Mod_date", Mod_date))

            If Not String.IsNullOrEmpty(MtSys_type) Then
                psList.Add(New SqlParameter("@MtSys_type", MtSys_type))
            Else
                psList.Add(New SqlParameter("@MtSys_type", dr("MtSys_type")))
            End If

            DAO.Update(psList.ToArray())


        End Sub

        Public Function GetAll(MtClass_type As String, ApplyTimeS As DateTime, ApplyTimeE As DateTime, Phone_nos As String, Unit_code As String, User_id As String, _
                              MtStatus_type As String, ServApply_type As String, orgCode As String) As DataTable
            Return DAO.GetAll(MtClass_type, ApplyTimeS, ApplyTimeE, Phone_nos, Unit_code, User_id, MtStatus_type, ServApply_type, orgCode)
        End Function

    End Class
End Namespace
