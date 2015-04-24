Imports System.Data
Imports FSC.Logic
Imports System.Transactions
Imports System.Collections.Generic

Partial Class FSC1109_01
    Inherits BaseWebForm

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then
            Return
        End If
    End Sub

    Public Sub doCheckIn()
        Try
            Dim Orgcode As String = Request.QueryString("org")
            Dim Depart_id As String = Request.QueryString("did")
            Dim Id_card As String = Request.QueryString("id")
            Dim User_name As String = Request.QueryString("name")
            Dim Title_no As String = Request.QueryString("tno")
            Dim Service_type As String = Request.QueryString("st")

            Dim f As SYS.Logic.Flow = New SYS.Logic.Flow
            Dim sr As StaffRegister = New StaffRegister
            Dim p As Personnel = New Personnel
            sr.Apply_Orgcode = Orgcode
            sr.Apply_Depart_id = Depart_id
            sr.Apply_Idcard = Id_card
            sr.Apply_Username = User_name
            sr.Write_Orgcode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
            sr.Write_Depart_id = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id)
            sr.Write_Idcard = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card)
            sr.Write_Username = LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name)
            sr.Change_userid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account)

            f.Orgcode = sr.Apply_Orgcode
            f.DepartId = sr.Apply_Depart_id
            f.ApplyIdcard = sr.Apply_Idcard
            f.ApplyName = sr.Apply_Username
            f.ApplyPosid = Title_no
            f.ApplyStype = Service_type
            f.WriterOrgcode = sr.Write_Orgcode
            f.WriterDepartid = sr.Write_Depart_id
            f.WriterIdcard = sr.Write_Idcard
            f.WriterName = sr.Write_Username
            f.WriterPosid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Title_no)
            f.WriteTime = Date.Now
            f.FormId = "001012"
            f.Reason = ""
            f.ChangeUserid = sr.Change_userid
            Using trans As New TransactionScope
                Dim flow_id As String = New SYS.Logic.FlowId().GetFlowId(sr.Apply_Orgcode, "001012", Nothing)
                sr.flow_id = flow_id
                f.FlowId = flow_id

                UcAttachment.FlowId = flow_id
                UcAttachment.SaveFile()

                sr.insert()
                SYS.Logic.CommonFlow.AddFlow(f)

                p.UpdateInitFlag(Id_card)
                trans.Complete()
            End Using

            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "啟動報到流程成功!", "../../EMP/EMP3/EMP3105_01.aspx")
        Catch fex As FlowException
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, fex.Message())
        Catch ex As Exception
            CommonFun.MsgShow(Me, CommonFun.Msg.SystemError)
            AppException.WriteErrorLog(ex.StackTrace, ex.Message)
        End Try
    End Sub

    Protected Sub cbSubmit_Click(sender As Object, e As EventArgs) Handles cbSubmit.Click
        doCheckIn()
    End Sub

    Protected Sub cbBack_Click(sender As Object, e As EventArgs) Handles cbBack.Click
        Response.Redirect("../../EMP/EMP3/EMP3105_01.aspx")
    End Sub
End Class


