Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Transactions

Namespace FSCPLM.Logic
    Public Class MAI1102
        Public SMDAO As SwMaintainMain
        Public MTDAO As MaintainerMain

        Public Sub New()
            SMDAO = New SwMaintainMain()
            MTDAO = New MaintainerMain()
        End Sub

        Public Sub Insert01(Phone_nos As String, Unit_code As String, User_id As String, MtSys_type As String, ApplyTime As DateTime, _
                            OrgCode As String, ModUser_id As String, Mod_date As DateTime)
            Dim maintainerDR As DataRow = GetMaintainer("019" & MtSys_type, LoginManager.OrgCode)
            Dim Maintainer_name As String = String.Empty, MaintainerPhone_nos As String = String.Empty
            If Not maintainerDR Is Nothing Then
                Maintainer_name = CommonFun.SetDataRow(maintainerDR, "Maintainer_name")
                MaintainerPhone_nos = CommonFun.SetDataRow(maintainerDR, "MaintainerPhone_nos")
            End If
            'Dim flowID As String = New Random().Next(1, 1000).ToString().PadLeft(10, "0")
            Dim flowID As String = String.Empty
            Using trans As New TransactionScope
                Dim f As New SYS.Logic.Flow()
                f.Orgcode = OrgCode
                f.DepartId = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id)
                f.ApplyPosid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Title_no)
                f.ApplyIdcard = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card)
                f.ApplyName = LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name)
                f.ApplyStype = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Service_type)
                f.FormId = "003008"
                f.FlowId = New SYS.Logic.FlowId().GetFlowId(OrgCode, f.FormId)
                SYS.Logic.CommonFlow.AddFlow(f)

                flowID = f.FlowId
                SMDAO.Insert(OrgCode, SMDAO.GetSwMaintain_code(OrgCode), flowID, "", "", "", Phone_nos, Unit_code, User_id, "", "", "", "", ApplyTime, _
                         "", "", "", "", DateTime.MinValue, "", DateTime.MinValue, DateTime.MinValue, MaintainerPhone_nos, Maintainer_name, _
                        "", "", "", "", "", "", "", "", "", LoginManager.UserId, Now, MtSys_type)

                trans.Complete()
            End Using
           

        End Sub

        Public Sub Insert02(Phone_nos As String, Unit_code As String, User_id As String, MtClass_type As String, MtItem_type As String, _
                            ClientUnit_code As String, ClientUser_id As String, ServApply_type As String, SfExpect_date As String, _
                            Problem_desc As String, Attachment1 As String, Attachment2 As String, ApplyTime As DateTime, _
                            OrgCode As String, ModUser_id As String, Mod_date As DateTime)
            Dim maintainerDR As DataRow = GetMaintainer("020" & MtClass_type & MtItem_type, LoginManager.OrgCode)
            Dim Maintainer_name As String = String.Empty, MaintainerPhone_nos As String = String.Empty
            If Not maintainerDR Is Nothing Then
                Maintainer_name = CommonFun.SetDataRow(maintainerDR, "Maintainer_name")
                MaintainerPhone_nos = CommonFun.SetDataRow(maintainerDR, "MaintainerPhone_nos")
            End If
            'Dim flowID As String = New Random().Next(1, 1000).ToString().PadLeft(10, "0")
            Dim flowID As String = String.Empty
            Using trans As New TransactionScope
                Dim f As New SYS.Logic.Flow()
                f.Orgcode = OrgCode
                f.DepartId = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id)
                f.ApplyPosid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Title_no)
                f.ApplyIdcard = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card)
                f.ApplyName = LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name)
                f.ApplyStype = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Service_type)
                f.FormId = "003008"
                f.FlowId = New SYS.Logic.FlowId().GetFlowId(OrgCode, f.FormId)
                SYS.Logic.CommonFlow.AddFlow(f)

                flowID = f.FlowId
                SMDAO.Insert(OrgCode, SMDAO.GetSwMaintain_code(OrgCode), flowID, MtClass_type, MtItem_type, "", Phone_nos, Unit_code, User_id, ClientUnit_code, ClientUser_id, ServApply_type, Problem_desc, ApplyTime, _
                         SfExpect_date, Attachment1, Attachment2, "", DateTime.MinValue, "", DateTime.MinValue, DateTime.MinValue, MaintainerPhone_nos, Maintainer_name, _
                        "", "", "", "", "", "", "", "", "", LoginManager.UserId, Now, "")

                trans.Complete()
            End Using
            

        End Sub

        Public Function GetMaintainer(MtItem_type As String, orgCode As String) As DataRow
            Return MTDAO.GetByItem_type(MtItem_type, orgCode)
        End Function

    End Class
End Namespace
