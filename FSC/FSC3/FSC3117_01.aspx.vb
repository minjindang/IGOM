Imports FSC.Logic
Imports System.Data
Imports System.Collections.Generic

Partial Class FSC3117_01
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

    Private Sub PKWKTPE_Bind(ByVal ddl As DropDownList)
        Dim dt As DataTable = New FSCPLM.Logic.SACode().GetData("023", "009")
        ddl.DataTextField = "code_desc1"
        ddl.DataValueField = "code_no"
        ddl.DataSource = dt
        ddl.DataBind()
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
        Dim bll As New FSC3117()
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
                btnQuery.Visible = True
                Reset.Visible = True
                btnUpdate.Visible = True
                btnConfirm.Visible = False
                btnCancel.Visible = False
                Ucpager.Visible = True
            Else
                btnQuery.Visible = True
                Reset.Visible = True
                btnUpdate.Visible = False
                btnConfirm.Visible = False
                btnCancel.Visible = False
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

    Protected Sub gvlist_DataBound(sender As Object, e As EventArgs) Handles gvlist.DataBound
        gvControlEnabled(False)
    End Sub

    Protected Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        btnQuery.Visible = False
        Reset.Visible = False
        btnUpdate.Visible = False
        btnConfirm.Visible = True
        btnCancel.Visible = True
        gvControlEnabled(True)
    End Sub

    Protected Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        btnQuery.Visible = True
        Reset.Visible = True
        btnUpdate.Visible = True
        btnConfirm.Visible = False
        btnCancel.Visible = False
        gvControlEnabled(False)
    End Sub

    Protected Sub gvControlEnabled(ByVal enabled As Boolean)
        For Each gvr As GridViewRow In gvlist.Rows
            Dim lbPKWKTPE As Label = CType(gvr.FindControl("lbPKWKTPE"), Label)
            Dim gvTbPKSTIME As TextBox = CType(gvr.FindControl("gvTbPKSTIME"), TextBox)
            Dim gvTbPKETIME As TextBox = CType(gvr.FindControl("gvTbPKETIME"), TextBox)
            Dim gvDdlPKWKTPE As DropDownList = CType(gvr.FindControl("gvDdlPKWKTPE"), DropDownList)

            PKWKTPE_Bind(gvDdlPKWKTPE)
            gvDdlPKWKTPE.SelectedValue = lbPKWKTPE.Text

            gvTbPKSTIME.Enabled = enabled
            gvTbPKETIME.Enabled = enabled
            gvDdlPKWKTPE.Enabled = enabled
        Next
    End Sub

    Protected Sub btnConfirm_Click(sender As Object, e As EventArgs) Handles btnConfirm.Click
        Try
            For Each gvr As GridViewRow In gvlist.Rows
                Dim PKCARD As String = CType(gvr.FindControl("lbPKCARD"), Label).Text
                Dim PKWDATE As String = CType(gvr.FindControl("UcShowDate"), UControl_UcShowDate).Text
                Dim gvTbPKSTIME As TextBox = CType(gvr.FindControl("gvTbPKSTIME"), TextBox)
                Dim gvTbPKETIME As TextBox = CType(gvr.FindControl("gvTbPKETIME"), TextBox)
                Dim gvDdlPKWKTPE As DropDownList = CType(gvr.FindControl("gvDdlPKWKTPE"), DropDownList)

                Dim bll As FSC3117 = New FSC3117
                bll.updatePK(Left(PKWDATE, 5), PKCARD, PKWDATE, gvTbPKSTIME.Text, gvTbPKETIME.Text, gvDdlPKWKTPE.SelectedValue)
            Next

            CommonFun.MsgShow(Me, CommonFun.Msg.UpdateOK)
            Bind()
        Catch ex As Exception
            CommonFun.MsgShow(Me.Page, CommonFun.Msg.SystemError)
            AppException.WriteErrorLog(ex.StackTrace, ex.Message)
        End Try
    End Sub
End Class
