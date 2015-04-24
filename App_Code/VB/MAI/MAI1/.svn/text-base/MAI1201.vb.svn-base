Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Transactions
Imports System.IO

Namespace FSCPLM.Logic

    Public Class MAI1201

        Dim emdDAO As ElecMaintain_det
        Dim emmDAO As ElecMaintain_main

        Public Sub New()
            emdDAO = New ElecMaintain_det()
            emmDAO = New ElecMaintain_main()
        End Sub

        Public Sub Add(Phone_nos As String, attachment As String, dtDetail As DataTable)
            Dim flowID As String = String.Empty 
            Using trans As New TransactionScope
                Dim f As New SYS.Logic.Flow()
                f.Orgcode = LoginManager.OrgCode
                f.DepartId = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id)
                f.ApplyPosid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Title_no)
                f.ApplyIdcard = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card)
                f.ApplyName = LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name)
                f.ApplyStype = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Service_type)
                f.FormId = "003008"
                f.FlowId = New SYS.Logic.FlowId().GetFlowId(LoginManager.OrgCode, f.FormId)
                SYS.Logic.CommonFlow.AddFlow(f)

                flowID = f.FlowId

                '新增主檔
                emmDAO.Add(LoginManager.OrgCode, flowID, Phone_nos, LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id), LoginManager.UserId, _
                           LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name), Now, attachment, "", "N", LoginManager.UserId, Now)

                For Each dr As DataRow In dtDetail.Rows
                    Dim MtItemOther_desc As String = String.Empty
                    Dim MtClass_type As String = CommonFun.SetDataRow(dr, "MtClass_type")
                    If MtClass_type = "010" Then ' 其它
                        MtItemOther_desc = CommonFun.SetDataRow(dr, "MtClass_typeName")
                    End If

                    emdDAO.Add(LoginManager.OrgCode, flowID, "", MtClass_type, CommonFun.SetDataRow(dr, "ElecExpect_type"), MtItemOther_desc, _
                               CommonFun.SetDataRow(dr, "Problem_desc"), DateTime.MinValue, DateTime.MinValue, 0, "", "", "", "", "", LoginManager.UserId, Now)
                Next
                trans.Complete()
            End Using
          

        End Sub

    End Class
End Namespace
