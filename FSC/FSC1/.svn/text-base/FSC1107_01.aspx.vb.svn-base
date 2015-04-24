Imports System.Data
Imports System.IO
Imports FSC.Logic
Imports System.Transactions
Imports CommonLib
Imports System.Collections.Generic

Partial Class FSC1_FSC1107_01
    Inherits BaseWebForm
    Dim OrgType As String = System.Configuration.ConfigurationManager.AppSettings("OrgType")

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
 If Me.IsPostBack Then
            Return
        End If

        ' 繫結【申請類別】
        Me.bindApplicationType()

        BindReSend()
    End Sub

    ''' <summary>
    ''' 繫結【申請類別】
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub bindApplicationType()
        Me.rblApplicationType.DataTextField = "CODE_DESC1"
        Me.rblApplicationType.DataValueField = "CODE_NO"
        Me.rblApplicationType.DataSource = New FSCPLM.Logic.SACode().GetData("023", "010")
        Me.rblApplicationType.DataBind()
        Me.rblApplicationType.SelectedIndex = 0
    End Sub


    Protected Sub BindReSend()
        Dim fid As String = Request.QueryString("fid")
        Dim org As String = Request.QueryString("org")

        If Not String.IsNullOrEmpty(fid) And Not String.IsNullOrEmpty(org) Then
            Dim list As List(Of WorkserviceProof) = New FSC.Logic.WorkserviceProof().GetObjects(org, fid)

            For Each wp As WorkserviceProof In list
                rblApplicationType.SelectedValue = wp.ApplyType
                tbApplyCopies.Text = wp.ApplyCopies
                tbPurpose.Text = wp.Purpose
                tbNotes.Text = wp.Notes
            Next
            UcAttachment.BindUploadFile(org, fid)
        End If
    End Sub

    Protected Sub cbSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbSubmit.Click
        If Me.tbApplyCopies.Text.Trim = "" Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "申請份數未輸入!")
            Return
        Else
            Try
                Dim iNum As Integer = CDbl(Me.tbApplyCopies.Text.Trim)
            Catch ex As Exception
                CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "申請份數請輸入數字!")
                Return
            End Try
        End If

        If Me.tbPurpose.Text.Trim = "" Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "用途未輸入!")
            Return
        ElseIf Me.tbPurpose.Text.Trim.Length > 255 Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "用途請勿輸入超過255字!")
            Return
        End If

        If Me.tbNotes.Text.Trim.Length > 255 Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "備註請勿輸入超過255字!")
            Return
        End If

        Dim u_fid As String = Request.QueryString("fid")
        Dim u_org As String = Request.QueryString("org")
        Dim isUpdate As Boolean = False

        If Not String.IsNullOrEmpty(u_fid) AndAlso Not String.IsNullOrEmpty(u_org) Then
            isUpdate = True
        End If

        Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim Depart_id As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id)
        Dim id_card As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card)
        Dim Apply_name As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name)
        Dim Apply_date As String = DateTimeInfo.GetRocDate(Now)
        Dim Apply_type As String = Me.rblApplicationType.SelectedValue
        Dim Apply_copies As String = Me.tbApplyCopies.Text
        Dim Purpose As String = Me.tbPurpose.Text
        Dim Notes As String = Me.tbNotes.Text
        Dim Change_userid As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account)
        Dim Change_date As DateTime = DateTime.Today()
        Dim szFormId As String = "001011"
        Dim bll As New FSC.Logic.FSC1107()
        Dim iCounts As Integer = 0
        Dim fid As String = String.Empty

        Try
            Using trans As New TransactionScope
                fid = IIf(isUpdate, Request.QueryString("fid"), New SYS.Logic.FlowId().GetFlowId(Orgcode, szFormId))

                UcAttachment.FlowId = fid
                UcAttachment.SaveFile()

                If isUpdate Then
                    Dim f As SYS.Logic.Flow = New SYS.Logic.Flow().GetObject(u_org, u_fid)
                    f.Reason = Purpose
                    f.ChangeUserid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account)
                    f.CaseStatus = "2"
                    f.Update()

                    bll.UpdateWorkserviceProof(fid, Orgcode, Apply_type, Apply_copies, Purpose, Notes, Change_userid, Change_date)
                Else
                    iCounts = bll.InsertWorkserviceProof(fid, Orgcode, Depart_id, id_card, Apply_name, Apply_date, Apply_type, Apply_copies, Purpose, Notes, Change_userid, Change_date)

                    Dim f As New SYS.Logic.Flow()
                    f.FlowId = fid
                    f.Orgcode = Orgcode
                    f.DepartId = Depart_id
                    f.ApplyIdcard = id_card
                    f.ApplyName = Apply_name
                    f.ApplyPosid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Title_no)
                    f.ApplyStype = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Service_type)
                    f.WriterOrgcode = Orgcode
                    f.WriterDepartid = Depart_id
                    f.WriterIdcard = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account)
                    f.WriterName = LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name)
                    f.WriterPosid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Title_no)
                    f.WriteTime = Date.Now
                    f.FormId = szFormId
                    f.Reason = Purpose
                    f.ChangeUserid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account)

                    SYS.Logic.CommonFlow.AddFlow(f)

                    If iCounts > 0 Then
                        CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "申請成功!")
                    Else
                        CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "申請失敗!")
                    End If
                End If

                trans.Complete()
            End Using
        Catch fex As FlowException
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, fex.Message())

        Catch ex As Exception
            AppException.WriteErrorLog(ex.StackTrace(), ex.Message())
            CommonFun.MsgShow(Me, CommonFun.Msg.SystemError)
        End Try

    End Sub
End Class
