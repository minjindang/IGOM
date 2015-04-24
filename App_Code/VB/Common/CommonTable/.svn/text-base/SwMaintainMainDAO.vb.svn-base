Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration

Namespace FSCPLM.Logic
    Public Class SwMaintainMainDAO
        Inherits BaseDAO

        Dim Connection As SqlConnection
        Dim ConnectionString As String = String.Empty

        Public Sub New()
            ConnectionString = ConnectDB.GetDBString()
        End Sub

        Public Sub New(ByVal conn As SqlConnection)
            Me.Connection = conn
        End Sub

        Public Sub Update(ps() As SqlParameter)
            Dim StrSQL As New System.Text.StringBuilder
            StrSQL.Append("UPDATE [MAI_SwMaintain_main] SET " & vbCrLf)
            StrSQL.Append("             [MtClass_type]=@MtClass_type, " & vbCrLf)
            StrSQL.Append("             [MtItem_type]=@MtItem_type, " & vbCrLf)
            StrSQL.Append("             [Task_type]=@Task_type, " & vbCrLf)
            StrSQL.Append("             [Phone_nos]=@Phone_nos, " & vbCrLf)
            StrSQL.Append("             [Unit_code]=@Unit_code, " & vbCrLf)
            StrSQL.Append("             [User_id]=@User_id, " & vbCrLf)
            StrSQL.Append("             [ClientUnit_code]=@ClientUnit_code, " & vbCrLf)
            StrSQL.Append("             [ClientUser_id]=@ClientUser_id, " & vbCrLf)
            StrSQL.Append("             [ServApply_type]=@ServApply_type, " & vbCrLf)
            StrSQL.Append("             [Problem_desc]=@Problem_desc, " & vbCrLf)
            StrSQL.Append("             [ApplyTime]=@ApplyTime, " & vbCrLf)
            StrSQL.Append("             [SfExpect_date]=@SfExpect_date, " & vbCrLf)
            StrSQL.Append("             [Attachment1]=@Attachment1, " & vbCrLf)
            StrSQL.Append("             [Attachment2]=@Attachment2, " & vbCrLf)
            StrSQL.Append("             [Memo]=@Memo, " & vbCrLf)
            StrSQL.Append("             [MtStartTime]=@MtStartTime, " & vbCrLf)
            StrSQL.Append("             [Forecast_date]=@Forecast_date, " & vbCrLf)
            StrSQL.Append("             [MtEndTime]=@MtEndTime, " & vbCrLf)
            StrSQL.Append("             [ResponseTime]=@ResponseTime, " & vbCrLf)
            StrSQL.Append("             [MaintainerPhone_nos]=@MaintainerPhone_nos, " & vbCrLf)
            StrSQL.Append("             [Maintainer_name]=@Maintainer_name, " & vbCrLf)
            StrSQL.Append("             [MtStatus_type]=@MtStatus_type, " & vbCrLf)
            StrSQL.Append("             [MtStatus_desc]=@MtStatus_desc, " & vbCrLf)
            StrSQL.Append("             [ServConfirm_type]=@ServConfirm_type, " & vbCrLf)
            StrSQL.Append("             [ReqAttachment]=@ReqAttachment, " & vbCrLf)
            StrSQL.Append("             [Exceed3Month_type]=@Exceed3Month_type, " & vbCrLf)
            StrSQL.Append("             [ManagerCheck_type]=@ManagerCheck_type, " & vbCrLf)
            StrSQL.Append("             [ChiefCheck_type]=@ChiefCheck_type, " & vbCrLf)
            StrSQL.Append("             [Property_id]=@Property_id, " & vbCrLf)
            StrSQL.Append("             [RepeatApply_type]=@RepeatApply_type, " & vbCrLf)
            StrSQL.Append("             [ModUser_id]=@ModUser_id, " & vbCrLf)
            StrSQL.Append("             [Mod_date]=@Mod_date, " & vbCrLf)
            StrSQL.Append("             [MtSys_type]=@MtSys_type " & vbCrLf)
            StrSQL.Append("             WHERE OrgCode=@OrgCode " & vbCrLf)
            StrSQL.Append("             AND SwMaintain_code=@SwMaintain_code " & vbCrLf)
         

            Execute(StrSQL.ToString(), ps)
        End Sub

        Public Sub Insert( ps() As SqlParameter)
            Dim StrSQL As New System.Text.StringBuilder
            StrSQL.Append("INSERT INTO [MAI_SwMaintain_main] " & vbCrLf)
            StrSQL.Append("            ([OrgCode], " & vbCrLf)
            StrSQL.Append("             [SwMaintain_code], " & vbCrLf)
            StrSQL.Append("             [Flow_id], " & vbCrLf)
            StrSQL.Append("             [MtClass_type], " & vbCrLf)
            StrSQL.Append("             [MtItem_type], " & vbCrLf)
            StrSQL.Append("             [Task_type], " & vbCrLf)
            StrSQL.Append("             [Phone_nos], " & vbCrLf)
            StrSQL.Append("             [Unit_code], " & vbCrLf)
            StrSQL.Append("             [User_id], " & vbCrLf)
            StrSQL.Append("             [ClientUnit_code], " & vbCrLf)
            StrSQL.Append("             [ClientUser_id], " & vbCrLf)
            StrSQL.Append("             [ServApply_type], " & vbCrLf)
            StrSQL.Append("             [Problem_desc], " & vbCrLf)
            StrSQL.Append("             [ApplyTime], " & vbCrLf)
            StrSQL.Append("             [SfExpect_date], " & vbCrLf)
            StrSQL.Append("             [Attachment1], " & vbCrLf)
            StrSQL.Append("             [Attachment2], " & vbCrLf)
            StrSQL.Append("             [Memo], " & vbCrLf)
            StrSQL.Append("             [MtStartTime], " & vbCrLf)
            StrSQL.Append("             [Forecast_date], " & vbCrLf)
            StrSQL.Append("             [MtEndTime], " & vbCrLf)
            StrSQL.Append("             [ResponseTime], " & vbCrLf)
            StrSQL.Append("             [MaintainerPhone_nos], " & vbCrLf)
            StrSQL.Append("             [Maintainer_name], " & vbCrLf)
            StrSQL.Append("             [MtStatus_type], " & vbCrLf)
            StrSQL.Append("             [MtStatus_desc], " & vbCrLf)
            StrSQL.Append("             [ServConfirm_type], " & vbCrLf)
            StrSQL.Append("             [ReqAttachment], " & vbCrLf)
            StrSQL.Append("             [Exceed3Month_type], " & vbCrLf)
            StrSQL.Append("             [ManagerCheck_type], " & vbCrLf)
            StrSQL.Append("             [ChiefCheck_type], " & vbCrLf)
            StrSQL.Append("             [Property_id], " & vbCrLf)
            StrSQL.Append("             [RepeatApply_type], " & vbCrLf)
            StrSQL.Append("             [ModUser_id], " & vbCrLf)
            StrSQL.Append("             [Mod_date], " & vbCrLf)
            StrSQL.Append("             [MtSys_type]) " & vbCrLf)
            StrSQL.Append("VALUES      (@OrgCode, " & vbCrLf)
            StrSQL.Append("             @SwMaintain_code, " & vbCrLf)
            StrSQL.Append("             @Flow_id, " & vbCrLf)
            StrSQL.Append("             @MtClass_type, " & vbCrLf)
            StrSQL.Append("             @MtItem_type, " & vbCrLf)
            StrSQL.Append("             @Task_type, " & vbCrLf)
            StrSQL.Append("             @Phone_nos, " & vbCrLf)
            StrSQL.Append("             @Unit_code, " & vbCrLf)
            StrSQL.Append("             @User_id, " & vbCrLf)
            StrSQL.Append("             @ClientUnit_code, " & vbCrLf)
            StrSQL.Append("             @ClientUser_id, " & vbCrLf)
            StrSQL.Append("             @ServApply_type, " & vbCrLf)
            StrSQL.Append("             @Problem_desc, " & vbCrLf)
            StrSQL.Append("             @ApplyTime, " & vbCrLf)
            StrSQL.Append("             @SfExpect_date, " & vbCrLf)
            StrSQL.Append("             @Attachment1, " & vbCrLf)
            StrSQL.Append("             @Attachment2, " & vbCrLf)
            StrSQL.Append("             @Memo, " & vbCrLf)
            StrSQL.Append("             @MtStartTime, " & vbCrLf)
            StrSQL.Append("             @Forecast_date, " & vbCrLf)
            StrSQL.Append("             @MtEndTime, " & vbCrLf)
            StrSQL.Append("             @ResponseTime, " & vbCrLf)
            StrSQL.Append("             @MaintainerPhone_nos, " & vbCrLf)
            StrSQL.Append("             @Maintainer_name, " & vbCrLf)
            StrSQL.Append("             @MtStatus_type, " & vbCrLf)
            StrSQL.Append("             @MtStatus_desc, " & vbCrLf)
            StrSQL.Append("             @ServConfirm_type, " & vbCrLf)
            StrSQL.Append("             @ReqAttachment, " & vbCrLf)
            StrSQL.Append("             @Exceed3Month_type, " & vbCrLf)
            StrSQL.Append("             @ManagerCheck_type, " & vbCrLf)
            StrSQL.Append("             @ChiefCheck_type, " & vbCrLf)
            StrSQL.Append("             @Property_id, " & vbCrLf)
            StrSQL.Append("             @RepeatApply_type, " & vbCrLf)
            StrSQL.Append("             @ModUser_id, " & vbCrLf)
            StrSQL.Append("             @Mod_date, " & vbCrLf)
            StrSQL.Append("             @MtSys_type) " & vbCrLf)


      
            Execute(StrSQL.ToString(), ps)
        End Sub

        Public Function GetOne(orgCode As String, SwMaintain_code As String) As DataTable
            Dim StrSQL As String = "SELECT * FROM MAI_SwMaintain_main WHERE 1=1 AND orgCode = @orgCode AND SwMaintain_code = @SwMaintain_code "
            Dim ps() As SqlParameter = { _
               New SqlParameter("@orgCode", orgCode), _
               New SqlParameter("@SwMaintain_code", SwMaintain_code)}

            Return Query(StrSQL, ps)
        End Function

        Public Function GetSwMaintain_code(orgCode As String) As DataTable
            Dim StrSQL As String = "SELECT * FROM MAI_SwMaintain_main WHERE 1=1 AND orgCode = @orgCode AND SwMaintain_code LIKE @SwMaintain_code + '%' "
            Dim ps() As SqlParameter = { _
               New SqlParameter("@orgCode", orgCode), _
               New SqlParameter("@SwMaintain_code", CommonFun.getYYYMMDD)}

            Return Query(StrSQL, ps)
        End Function


        Public Function GetAll(MtClass_type As String, ApplyTimeS As DateTime, ApplyTimeE As DateTime, Phone_nos As String, Unit_code As String, User_id As String, _
                               MtStatus_type As String, ServApply_type As String, orgCode As String) As DataTable
            Dim StrSQL As String = "SELECT * FROM MAI_SwMaintain_main WHERE 1=1 AND orgCode = @orgCode "
            If Not String.IsNullOrEmpty(MtClass_type) Then
                StrSQL &= " AND @MtClass_type like '%;' + MtClass_type + ';%' "
            End If
            If ApplyTimeS <> New DateTime(1911, 1, 1) Then
                StrSQL &= " AND ApplyTime >= @ApplyTimeS "
            End If
            If ApplyTimeE <> New DateTime(1911, 1, 1) Then
                StrSQL &= " AND ApplyTime <= @ApplyTimeE "
            End If
            If Not String.IsNullOrEmpty(Phone_nos) Then
                StrSQL &= " AND Phone_nos = @Phone_nos "
            End If
            If Not String.IsNullOrEmpty(Unit_code) Then
                StrSQL &= " AND Unit_code = @Unit_code "
            End If
            If Not String.IsNullOrEmpty(User_id) Then
                StrSQL &= " AND User_id = @User_id "
            End If
            If Not String.IsNullOrEmpty(MtStatus_type) Then
                StrSQL &= " AND @MtStatus_type like '%;' + MtStatus_type + ';%' "
            End If
            If Not String.IsNullOrEmpty(ServApply_type) Then
                StrSQL &= " AND ServApply_type = @ServApply_type "
            End If

            Dim ps() As SqlParameter = { _
                New SqlParameter("@orgCode", orgCode), _
                New SqlParameter("@MtClass_type", MtClass_type), _
                New SqlParameter("@ApplyTimeS", ApplyTimeS), _
                New SqlParameter("@ApplyTimeE", ApplyTimeE), _
                New SqlParameter("@Phone_nos", Phone_nos), _
                New SqlParameter("@Unit_code", Unit_code), _
                New SqlParameter("@User_id", User_id), _
                New SqlParameter("@MtStatus_type", MtStatus_type), _
                New SqlParameter("@ServApply_type", ServApply_type)}

            Return Query(StrSQL, ps)

        End Function

    End Class
End Namespace
