Imports System.Data
Imports FSC.Logic
Partial Class FSC3108_01
    Inherits BaseWebForm

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then Return

        ShowDLL()
        If Not String.IsNullOrEmpty(Request.QueryString("card")) Or Not String.IsNullOrEmpty(Request.QueryString("date")) Or _
            Not String.IsNullOrEmpty(Request.QueryString("time")) Or Not String.IsNullOrEmpty(Request.QueryString("type")) Then

            Me.ddlName.SelectedValue = Request.QueryString("card")
            'Me.tbPHIDATE.Text = Request.QueryString("date")
            Me.tbPHITIME.Text = Request.QueryString("time")
            Me.ddlPHITYPE.SelectedValue = Request.QueryString("type")

            ShowList()
        End If
    End Sub

    Protected Sub ShowDLL()
        
        Dim orgCode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        UcDDLDepart.Orgcode = orgCode

        UcDate1.Text = DateTimeInfo.GetRocTodayString("yyyyMM") & "01"
        UcDate2.Text = DateTimeInfo.GetRocTodayString("yyyyMM") & Date.DaysInMonth(Now.Year, Now.Month).ToString.PadLeft(2, "0")

    End Sub

    Protected Sub UcDDLDepart_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles UcDDLDepart.SelectedIndexChanged
        BindMember()
    End Sub

    Protected Sub BindMember()
        ddlName.Orgcode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        ddlName.DepartId = UcDDLDepart.SelectedValue
    End Sub

    Protected Sub btnQry_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles toSelect.Click
        Dim msg As String = ""
        'If String.IsNullOrEmpty(ddlName.SelectedValue()) Then
        '    msg += "請選擇人員!!\n"
        'End If
        If Me.UcDate1.Text = "" Then
            msg += "請輸入刷卡日期!\n"
        End If
        If Me.UcDate1.Text > Me.UcDate2.Text Then
            msg += "刷卡起日不可大於迄日!\n"
        End If

        If Not String.IsNullOrEmpty(msg) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, msg)
            Return
        End If

        ShowList()
    End Sub

    Protected Sub ShowList()
        Dim fsc3108 As New FSC3108()

        Dim dt As DataTable = fsc3108.getData(Me.ddlName.SelectedValue, Me.UcDate1.Text.Replace("/", ""), Me.UcDate2.Text.Replace("/", ""), Me.ddlPHITYPE.SelectedValue, Me.tbPHITIME.Text)
        Me.gvList.DataSource = dt
        Me.gvList.DataBind()
        Me.table1.Visible = True
    End Sub


    Protected Sub gvList_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvList.PageIndexChanging
        Me.gvList.PageIndex = e.NewPageIndex
        ShowList()
    End Sub

    Protected Sub toReset_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles toReset.Click
        ShowDLL()

        UcDate1.Text = DateTimeInfo.GetRocTodayString("yyyyMM") & "01"
        UcDate2.Text = DateTimeInfo.GetRocTodayString("yyyyMM") & Date.DaysInMonth(Now.Year, Now.Month).ToString.PadLeft(2, "0")

        Me.ddlPHITYPE.SelectedValue = ""
        Me.tbPHITIME.Text = ""
    End Sub

    Protected Sub gvList_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvList.RowDataBound
        If 0 > e.Row.RowIndex Then
            Exit Sub
        End If

        Dim PHCARD As String = e.Row.Cells(0).Text.Trim()
        Dim PHIDATE As String = e.Row.Cells(1).Text.Trim()
        Dim PHITYPE As String = e.Row.Cells(2).Text.Trim()
        Dim PHITIME As String = e.Row.Cells(3).Text.Trim()

        Dim show As String = PHITYPE
        Select Case PHITYPE
            Case "A"
                show = "A:上班進"
            Case "D"
                show = "D:下班出"
            Case "E"
                show = "E:加班進"
            Case "F"
                show = "F:加班出"
        End Select
        e.Row.Cells(2).Text = show
        e.Row.Cells(4).Text = New Personnel().GetColumnValue("User_name", e.Row.Cells(4).Text)

        Dim btn As Button = e.Row.FindControl("toUpdate")
        If Not btn Is Nothing Then
            Dim arg As New StringBuilder()
            arg.Append("PHCARD=").Append(PHCARD)
            arg.Append("&PHIDATE=").Append(PHIDATE)
            arg.Append("&PHITYPE=").Append(PHITYPE)
            arg.Append("&PHITIME=").Append(PHITIME)
            arg.Append("&card=").Append(ddlName.SelectedValue)
            arg.Append("&date=").Append(UcDate1.Text)
            arg.Append("&type=").Append(ddlPHITYPE.SelectedValue)
            arg.Append("&time=").Append(tbPHITIME.Text)
            btn.CommandArgument = arg.ToString()
        End If

    End Sub

    Protected Sub gvList_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvList.RowCommand
        If "toUpdate" = e.CommandName Then
            Dim url As String = "FSC3108_02.aspx"
            Dim arg As String = e.CommandArgument
            Me.Response.Redirect(url + "?" + arg)
        End If
    End Sub

    Protected Sub toBatch_Click(sender As Object, e As EventArgs) Handles toBatch.Click
        Response.Redirect("FSC3108_03.aspx")
    End Sub
End Class