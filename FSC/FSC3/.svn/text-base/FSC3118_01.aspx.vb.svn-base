Imports FSC.Logic
Imports System.Data
Imports System.Collections.Generic
Imports System.Transactions

Partial Class FSC3118_01
    Inherits BaseWebForm

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack() Then
            Return
        End If
        InitControl()
    End Sub

#Region "下拉式選單"
    Protected Sub InitControl()
        UcDate1.Text = DateTimeInfo.GetRocTodayString("yyyyMM") & "01"
        UcDate2.Text = DateTimeInfo.GetRocTodayString("yyyyMM") & Date.DaysInMonth(Now.Year, Now.Month).ToString.PadLeft(2, "0")

        Depart_Bind()
        UserName_Bind()
        Employee_type_Bind()
        Quit_job_Bind()

    End Sub

    Protected Sub Depart_Bind()
        UcDDLDepart.Orgcode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
    End Sub

    Protected Sub UcDDLDepart_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles UcDDLDepart.SelectedIndexChanged
        UserName_Bind()
    End Sub

    Private Sub UserName_Bind()
        UcDDLMember.Orgcode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        UcDDLMember.DepartId = UcDDLDepart.SelectedValue
    End Sub

    Private Sub Quit_job_Bind()
        Dim dt As DataTable = New FSCPLM.Logic.SACode().GetData("023", "025")
        ddlQuit_Job.DataTextField = "code_desc1"
        ddlQuit_Job.DataValueField = "code_no"
        ddlQuit_Job.DataSource = dt
        ddlQuit_Job.DataBind()
        ddlQuit_Job.Items.Insert(0, New ListItem("請選擇", ""))
    End Sub

    Private Sub Employee_type_Bind()
        Dim dt As DataTable = New FSCPLM.Logic.SACode().GetData("023", "022")
        ddlEmployeetype.DataTextField = "code_desc1"
        ddlEmployeetype.DataValueField = "code_no"
        ddlEmployeetype.DataSource = dt
        ddlEmployeetype.DataBind()
        ddlEmployeetype.Items.Insert(0, New ListItem("請選擇", ""))
    End Sub
#End Region

    Protected Sub btnQuery_Click(sender As Object, e As EventArgs) Handles btnQuery.Click
        Bind()
    End Sub

    Protected Sub Bind()
        Dim orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim depart_id As String = UcDDLDepart.SelectedValue
        Dim id_card As String = UcDDLMember.SelectedValue
        Dim id_card2 As String = UcMember.PersonnelId
        Dim Start_date As String = UcDate1.Text
        Dim End_date As String = UcDate2.Text
        Dim Quit_job_flag As String = ddlQuit_Job.SelectedValue
        Dim Employee_type As String = ddlEmployeetype.SelectedValue
        Dim yyymm As String
        Dim bll As New FSC3118()
        Dim dt As DataTable = New DataTable
        Dim tmpdt As DataTable = New DataTable

        If String.IsNullOrEmpty(UcDate1.Text) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "「起日」欄位為必填。")
            Return
        End If
        If String.IsNullOrEmpty(UcDate2.Text) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "「迄日」欄位為必填。")
            Return
        End If

        Try

            If Mid(Start_date, 1, 5) = Mid(End_date, 1, 5) Then
                dt = bll.GetData(orgcode, depart_id, UcDate1.Text, UcDate2.Text, id_card, id_card2, Quit_job_flag, Employee_type, Left(UcDate1.Text, 5))
            Else
                Dim S As Date = Date.Parse(Start_date.Substring(0, 3) + "/" + Start_date.Substring(3, 2) + "/" + "01")
                Dim E As Date = Date.Parse(End_date.Substring(0, 3) + "/" + End_date.Substring(3, 2) + "/" + "01")

                dt = bll.GetData(orgcode, depart_id, UcDate1.Text, UcDate2.Text, id_card, id_card2, Quit_job_flag, Employee_type, Left(UcDate1.Text, 5))
                While S < E
                    S = S.AddMonths(1)
                    yyymm = S.Year.ToString() + S.Month.ToString().PadLeft(2, "0")
                    tmpdt = bll.GetData(orgcode, depart_id, UcDate1.Text, UcDate2.Text, id_card, id_card2, Quit_job_flag, Employee_type, yyymm)
                    dt.Merge(tmpdt)
                End While
            End If

            ViewState("dt") = dt
            Me.gvlist.DataSource = dt
            Me.gvlist.DataBind()

            If gvlist.Rows.Count > 0 Then
                Ucpager.Visible = True
            Else
                Ucpager.Visible = False
            End If
            tbq.Visible = True
        Catch ex As Exception
            CommonFun.MsgShow(Me.Page, CommonFun.Msg.SystemError)
            AppException.WriteErrorLog(ex.StackTrace, ex.Message)
        End Try
    End Sub

#Region "頁數改變時"
    Protected Sub gvList_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvlist.PageIndexChanging
        Me.gvlist.PageIndex = e.NewPageIndex
        Me.gvlist.DataSource = CType(ViewState("dt"), DataTable)
        Me.gvlist.DataBind()
    End Sub
#End Region

    Protected Sub btnUpdate_Click(sender As Object, e As EventArgs)
        Dim gvr As GridViewRow = CType(sender, Button).NamingContainer
        Dim bll As New FSC3118()
        Dim uc As New UnusualCorrect()

        Dim Reason As String = CType(gvr.FindControl("tbReason"), TextBox).Text.Trim()
        If String.IsNullOrEmpty(Reason) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "請輸入註銷原因!")
            Return
        End If

        Dim PKCARD As String = CType(gvr.FindControl("lbPKCARD"), Label).Text
        Dim PKWDATE As String = CType(gvr.FindControl("UcShowDate"), UControl_UcShowDate).Text
        Dim PKWKTPE As String = CType(gvr.FindControl("lbPKWKTPE"), Label).Text
        Dim yyymm As String = Left(PKWDATE, 5)
        Try
            Using trans As New TransactionScope
                bll.updatePK(yyymm, PKCARD, PKWDATE, "5")

                uc.orgcode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
                uc.id_card = PKCARD
                uc.pkwdate = PKWDATE
                uc.pkwktpe = PKWKTPE
                uc.reason = Reason
                uc.change_userid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account)
                uc.insert()

                trans.Complete()
            End Using

            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "註銷成功!")
            Bind()
        Catch ex As Exception
            AppException.WriteErrorLog(ex.StackTrace, ex.Message)
            CommonFun.MsgShow(Me, CommonFun.Msg.SystemError)
        End Try
    End Sub
End Class
