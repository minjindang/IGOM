Imports System.Data
Imports System.IO
Imports FSC.Logic
Imports System.Transactions
Imports CommonLib

Partial Class FSC3110_03
    Inherits BaseWebForm

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then

            Return
        Else
            If Not String.IsNullOrEmpty(Request.QueryString("flow_id")) Then
                Dim flow_id As String = Request.QueryString("flow_id")
                Dim orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode) '機構代碼
                Dim dt As DataTable

                Dim f As New SYS.Logic.Flow()
                dt = f.GetDataByOrgFid(orgcode, flow_id)
                Dim id_card As String = dt.Rows(0)("Apply_idcard").ToString

                Dim mem As New Member
                Dim dt2 As DataTable = mem.GetDataByIdCard(id_card)
                Dim username As String = String.Empty
                If dt2.Rows.Count > 0 Then
                    username = dt2.Rows(0)("User_name").ToString
                End If

                Dim prmemo As String = String.Empty
                Dim reason As String = String.Empty
                Dim Change_reason As String = String.Empty

                Dim cpa18m As New CPAPR18M
                Dim dt3 As DataTable = cpa18m.GetCPAPR18MByFlow_id(flow_id)

                If dt3.Rows.Count > 0 Then
                    prmemo = dt3.Rows(0)("PRMEMO").ToString
                    reason = dt3.Rows(0)("PRREASON").ToString
                    If Not IsDBNull(dt3.Rows(0)("PRCHANGE_REASON")) Then
                        Change_reason = dt3.Rows(0)("PRCHANGE_REASON").ToString
                    End If
                End If

                Dim depart_id As String = String.Empty
                Dim rbltype As String = String.Empty
                Dim fdate As String = String.Empty
                Dim stime As String = String.Empty
                Dim etime As String = String.Empty

                Dim lmain As New LeaveMain()
                Dim dt4 As DataTable = lmain.GetDataByOrgFid(orgcode, flow_id)
                If dt4.Rows.Count > 0 Then
                    depart_id = dt4.Rows(0)("Depart_id").ToString
                    rbltype = dt4.Rows(0)("Leave_ngroup").ToString.Substring(1, 1)
                    fdate = dt4.Rows(0)("Start_Date").ToString.Substring(0, 3) + "/" + dt4.Rows(0)("Start_Date").ToString.Substring(3, 2) + dt4.Rows(0)("Start_Date").ToString.Substring(5, 2)
                    stime = dt4.Rows(0)("Start_time").ToString
                    etime = dt4.Rows(0)("End_time").ToString
                End If

                Dim org As New Org
                Dim depart_name As String = org.GetDepartName(orgcode, depart_id)

                Me.rblmemo.SelectedValue = prmemo
                Me.lbDept_id.Text = depart_id
                Me.lbDept.Text = depart_name
                Me.lbPrguid.Text = flow_id
                Me.rblType.SelectedValue = rbltype
                Me.lbname.Text = username
                Me.tbReason.Text = reason
                Me.tbChangeReason.Text = Change_reason
                Me.UcDate.Text = fdate
                Me.tbTimeb.Text = stime
                Me.tbTimee.Text = etime
                Me.lbidcard.Text = id_card

                If rbltype = 2 Then
                    rblmemo.Items(1).Enabled = True
                End If

            End If

        End If
        bindDDL()
        Memo_Bind()
    End Sub

#Region "下拉式選單"
    Protected Sub bindDDL()

        UcDate.Text = DateTimeInfo.GetRocDate(Now)
    End Sub

    Protected Sub Memo_Bind()
        If HttpContext.Current.User.Identity.IsAuthenticated Then
            Dim aryPageName As String() = Split(HttpContext.Current.Request.PhysicalPath, "\")
            Dim bll As New SYS.Logic.Func
            Dim dt As DataTable = bll.getDataByUrl(Split(aryPageName(aryPageName.Length - 1).Replace(".aspx", ""), "_")(0))
            For Each dr As DataRow In dt.Rows
                lbMemo.Text = dr("Func_Memo").ToString()
            Next
        End If
    End Sub
#End Region


    Protected Sub cbSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbSubmit.Click

        If String.IsNullOrEmpty(UcDate.Text) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "加班日期不可空白，請重新輸入!")
            Return
        End If
        If String.IsNullOrEmpty(tbTimeb.Text) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "加班起時不可空白，請重新輸入!")
            Return
        End If
        If String.IsNullOrEmpty(tbTimee.Text) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "加班迄時不可空白，請重新輸入!")
            Return
        End If
        If tbTimeb.Text > tbTimee.Text Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "加班起時不可大於迄時，請重新輸入!")
            Return
        End If
        If rblmemo.SelectedIndex < 0 Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "申請類型不可空白，請重新輸入!")
            Return
        End If

        Submit()
    End Sub

    Protected Sub Submit()
        '檢核訊息
        Dim orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim issus As Boolean = False
        Dim hasClass As Boolean = False

        Dim f As New SYS.Logic.Flow
        Dim lmain As LeaveMain = New LeaveMain()

        Try
            Dim user_name As String = lbname.Text
            Dim depart_id As String = lbDept_id.Text
            Dim last_id As String = lbnext_id.Text

            Dim id_card As String = lbidcard.Text
            Dim title_no As String = New Personnel().GetDataByIdCard(id_card).Rows(0)("Title_no").ToString()

            Dim hours As Integer
            'Dim hours As Integer = Content.computeHourForOvertime(UcDate.Text & tbTimeb.Text.Trim(), _
            '                                                          UcDate.Text & tbTimee.Text.Trim(), _
            '                                                          id_card)

            If Not String.IsNullOrEmpty(Me.tbHours.Text) Then
                hours = Convert.ToDouble(Me.tbHours.Text)
            End If

            f.Orgcode = orgcode
            f.DepartId = depart_id
            f.ApplyPosid = title_no
            f.ApplyIdcard = id_card
            f.ApplyName = user_name
            f.Reason = tbReason.Text.Trim()
            f.CaseStatus = "1"
            f.LastPass = "1"
            f.LastDate = Now.ToString("yyy/MM/dd HH:mm:ss")
            f.WriterIdcard = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card)
            f.WriterName = LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name)
            f.WriteTime = Now.ToString("yyy/MM/dd HH:mm:ss")

            lmain.Orgcode = orgcode
            lmain.DepartId = depart_id
            lmain.LeaveGroup = "E"
            lmain.LeaveNgroup = "E" + rblType.SelectedValue
            lmain.LeaveType = "80"
            lmain.StartDate = UcDate.Text
            lmain.EndDate = UcDate.Text
            lmain.StartTime = tbTimeb.Text.Trim()
            lmain.EndTime = tbTimee.Text.Trim()
            lmain.LeaveHours = hours
            lmain.Reason = tbReason.Text.Trim()
            lmain.Change_date = Now.ToString("yyy/MM/dd HH:mm:ss")
            lmain.Change_userid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account)

            'FSC_CPAPR18M
            Dim pr18m As New CPAPR18M()
            pr18m.Orgcode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
            pr18m.PRNAME = user_name
            pr18m.PRIDNO = id_card
            pr18m.PRCARD = id_card
            pr18m.DepartId = depart_id
            pr18m.PRADDD = UcDate.Text
            pr18m.PRADDE = UcDate.Text
            pr18m.PRSTIME = tbTimeb.Text.Trim()
            pr18m.PRETIME = tbTimee.Text.Trim()
            pr18m.PRREASON = tbReason.Text.Trim()
            pr18m.PRATYPE = rblType.SelectedValue
            pr18m.PRUSERID = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card)
            pr18m.PRMEMO = rblmemo.SelectedValue
            pr18m.PRADDH = hours
            pr18m.PRCHANGE_REASON = tbChangeReason.Text

            Dim dao As New CPAPR18MDAO()

            If CType(dao.GetCountByPRSTIME(pr18m.PRIDNO, pr18m.PRADDD, pr18m.PRSTIME, pr18m.PRETIME), Integer) > 0 Then
                Throw New FlowException(user_name & "已有該時段的加班記錄!")
            End If

            '開始 transaction
            Using trans As New TransactionScope()

                '更新Flow
                f.FlowId = Me.lbPrguid.Text
                If Not f.Update() Then
                    Throw New FlowException("更新表單失敗!")
                End If

                '更新FSC_leave_main
                lmain.FlowId = f.FlowId
                If Not lmain.UpdateLeaveMain() Then
                    Throw New FlowException("更新失敗!")
                End If

                '更新FSC_CPAPR18M
                pr18m.PRGUID = f.FlowId
                If Not pr18m.UpdateCPAPR18M() Then
                    Throw New FlowException("更新失敗!")
                End If

                trans.Complete()
            End Using

            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "送出成功", "FSC3110_01.aspx")

        Catch fex As FlowException
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, fex.Message())
        Catch ex As Exception
            AppException.WriteErrorLog(ex.StackTrace(), ex.Message())
            CommonFun.MsgShow(Me, CommonFun.Msg.SystemError)
        End Try
    End Sub



End Class
