Imports Microsoft.VisualBasic

Imports System.Data
Imports System.Transactions
Imports System.IO

Namespace FSCPLM.Logic
    Public Class PRO1103
        Dim srDAO As PRO_SwRegister_main

        Public Sub New()
            srDAO = New PRO_SwRegister_main() 
        End Sub

        Public Function Done(OfficialNumber_id As String, Software_id As String, Software_type As String, _
            Software_name As String, Version As String, KeyNumber_nos As String, SoftwareKind_type As String, NetPLimit_cnt As String, _
            Sofeware_cnt As String, Obtain_type As String, ObtainOt_desc As String, SoftwareUnit_name As String, StorageMedia_type As String, _
            StorageMediaOt_desc As String, StorageMedia_cnt As String, RelatedPapers_name As String, LifeTime As String, Fee_amt As String, _
            MRent_amt As String, Start_date As String, Unit_code As String, User_id As String, Register_date As String, _
            Memo As String, ModUser_id As String, Mod_date As DateTime) As String

            Dim msg As String = String.Empty

            '使用版別 網路版
            'Dim netPlimitCnt As Integer = Integer.MinValue
            Dim netPlimitCnt As Integer = 0
            If SoftwareKind_type = "003" AndAlso String.IsNullOrEmpty(NetPLimit_cnt) Then
                msg = "網路版請輸入使用人數\n"
            ElseIf SoftwareKind_type = "003" Then
                netPlimitCnt = CType(NetPLimit_cnt, Integer)
            End If

            '取得方式-其它
            Dim ObtainOtDesc As String = ""
            If Obtain_type = "007" AndAlso String.IsNullOrEmpty(ObtainOt_desc) Then
                msg = "請輸入其它取得方式\n"
            ElseIf Obtain_type = "007" Then
                ObtainOtDesc = ObtainOt_desc
            End If

            '存放媒體-其它
            Dim StorageMediaOtDesc As String = ""
            If StorageMedia_type = "005" AndAlso String.IsNullOrEmpty(StorageMediaOt_desc) Then
                msg = "請輸入其它存放媒體\n"
            ElseIf StorageMedia_type = "005" Then
                StorageMediaOtDesc = StorageMediaOt_desc
            End If

            If String.IsNullOrEmpty(msg) Then

                Dim flowID As String = String.Empty
                Using trans As New TransactionScope
                    Dim f As New SYS.Logic.Flow()
                    f.Orgcode = LoginManager.OrgCode
                    f.DepartId = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id)
                    f.ApplyPosid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Title_no)
                    f.ApplyIdcard = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card)
                    f.ApplyName = LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name)
                    f.ApplyStype = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Service_type)
                    f.FormId = "004092"
                    f.FlowId = New SYS.Logic.FlowId().GetFlowId(LoginManager.OrgCode, f.FormId)
                    f.Reason = "申請公文文號：" + OfficialNumber_id + "，軟體編號：" + Software_id
                    SYS.Logic.CommonFlow.AddFlow(f)

                    flowID = f.FlowId
                    srDAO.Add(LoginManager.OrgCode, flowID, OfficialNumber_id, Software_id, Software_type, _
                       Software_name, Version, KeyNumber_nos, SoftwareKind_type, netPlimitCnt, _
                       CType(Sofeware_cnt, Integer), Obtain_type, ObtainOtDesc, SoftwareUnit_name, StorageMedia_type, _
                       StorageMediaOtDesc, CType(StorageMedia_cnt, Integer), RelatedPapers_name, CType(LifeTime, Double), CType(Fee_amt, Double), _
                       CType(MRent_amt, Double), Start_date, Unit_code, User_id, Register_date, _
                       Memo, ModUser_id, Mod_date)
                    trans.Complete()
                End Using

            End If

            Return msg

        End Function

    End Class
End Namespace
