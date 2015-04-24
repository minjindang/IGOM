Imports FSCPLM.Logic
Imports System.Data
Imports System.Collections.Generic
Imports System.Transactions

Partial Class FSC3112_01
    Inherits BaseWebForm

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack() Then
            InitData()
        End If
    End Sub

#Region "顯示下拉選單"
    Protected Sub InitData()
        BindYearMonth()
        BindSchedule()
        BindDep()
        BindName()
        BindJobStatus()
        BindEmployeeType()
    End Sub

    Protected Sub BindSchedule()
        Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim sche As New FSC.Logic.Schedule()
        ddlSchedule.DataSource = sche.GetData(Orgcode)
        ddlSchedule.DataBind()
        ddlSchedule.Items.Insert(0, New ListItem("請選擇", ""))
    End Sub

    Protected Sub BindJobStatus()
        Dim code As New FSCPLM.Logic.SACode()
        ddlJobStatus.DataSource = code.GetData("023", "025")
        ddlJobStatus.DataBind()
        ddlJobStatus.Items.Insert(0, New ListItem("請選擇", ""))
    End Sub

    Protected Sub BindEmployeeType()
        Dim code As New FSCPLM.Logic.SACode()
        ddlEmployeeType.DataSource = code.GetData("023", "022")
        ddlEmployeeType.DataBind()
        ddlEmployeeType.Items.Insert(0, New ListItem("請選擇", ""))
    End Sub

    Protected Sub BindDep()
        UcDDLDepart.Orgcode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
    End Sub

    Protected Sub BindName()
        Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        UcDDLMember.Orgcode = Orgcode
        UcDDLMember.DepartId = UcDDLDepart.SelectedValue
    End Sub

    Protected Sub ddlDepart_name_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        BindName()
    End Sub

    Protected Sub BindYearMonth()
        Dim Year As String = Now.Year - 2 - 1911
        For i As Integer = 0 To 3
            DD_Year.Items.Add(Year + i)
        Next
        For i As Integer = 1 To 12
            DD_Month.Items.Add(i.ToString().PadLeft(2, "0"))
        Next
        DD_Year.SelectedValue = Now.Year - 1911
        DD_Month.SelectedValue = Now.AddMonths(1).Month.ToString().PadLeft(2, "0")
    End Sub
#End Region

    Protected Sub btnPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrint.Click

        Dim orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim departid As String = UcDDLDepart.SelectedValue
        Dim idcard As String = UcDDLMember.SelectedValue
        Dim yyymm As String = DD_Year.SelectedValue() & DD_Month.SelectedValue()
        Dim scheduleId As String = ddlSchedule.SelectedValue
        Dim quitJobFlag As String = ddlJobStatus.SelectedValue
        Dim employeeType As String = ddlEmployeeType.SelectedValue
        Dim target As String = rblTarget.SelectedValue
        Dim bll As New FSC.Logic.FSC3112()

        Response.Redirect("FSC3112_04.aspx?did=" & departid & "&id=" & idcard & "&ym=" & yyymm & "&sid=" & scheduleId & "&qjflag=" & quitJobFlag & "&et=" & employeeType & "&t=" & target)
    End Sub

    Protected Sub bind()
        If String.IsNullOrEmpty(DD_Year.SelectedValue) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "年不可空白，請重新輸入!")
            Return
        End If
        If String.IsNullOrEmpty(DD_Month.SelectedValue) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "月不可空白，請重新輸入!")
            Return
        End If

        Dim orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim departid As String = UcDDLDepart.SelectedValue
        Dim idcard As String = UcDDLMember.SelectedValue
        Dim yyymm As String = DD_Year.SelectedValue() & DD_Month.SelectedValue()
        Dim scheduleId As String = ddlSchedule.SelectedValue
        Dim quitJobFlag As String = ddlJobStatus.SelectedValue
        Dim employeeType As String = ddlEmployeeType.SelectedValue
        Dim target As String = rblTarget.SelectedValue
        Dim bll As New FSC.Logic.FSC3112()

        If Not String.IsNullOrEmpty(UcPersonal_id.PersonnelId) Then
            idcard = UcPersonal_id.PersonnelId
        End If

        Dim dt As DataTable = bll.GetData(orgcode, departid, idcard, yyymm, scheduleId, quitJobFlag, employeeType, target)
        ViewState("dt") = dt

        gvList.DataSource = dt
        gvList.DataBind()
        tbQ.Visible = True
        btnNotice.Enabled = (dt IsNot Nothing AndAlso dt.Rows.Count > 0 And target <> "0")
    End Sub

    Protected Sub btnQuery_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnQuery.Click
        bind()
    End Sub


#Region "頁數改變時"

    Protected Sub gvList_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvList.PageIndexChanging
        Me.gvList.PageIndex = e.NewPageIndex
        gvList.DataSource = CType(ViewState("dt"), DataTable)
        gvList.DataBind()
    End Sub
#End Region

    Protected Sub cbAuto_Click(sender As Object, e As EventArgs)
        Response.Redirect("FSC3112_03.aspx")
    End Sub

    Protected Sub cbUpdate_Click(sender As Object, e As EventArgs)
        Dim gvr As GridViewRow = CType(sender, Button).NamingContainer
        Dim id As String = CType(gvr.FindControl("lbid"), Label).Text
        Response.Redirect("FSC3112_02.aspx?id=" & id)
    End Sub

    Protected Sub gvList_DataBound(sender As Object, e As EventArgs) Handles gvList.DataBound
        If rblTarget.SelectedValue = "0" Then
            gvList.Columns(6).Visible = False
        Else
            gvList.Columns(6).Visible = True
        End If
    End Sub

    Protected Sub btnNotice_Click(sender As Object, e As EventArgs) Handles btnNotice.Click
        Dim dt As DataTable = CType(ViewState("dt"), DataTable)

        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            Dim errorMsg = New FSC.Logic.FSC3112().sendNotice(dt, "", "")
            
            If (errorMsg = "") Then
                CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "通知成功!")
            Else
                CommonFun.MsgShow(Me, CommonFun.Msg.Custom, errorMsg)
            End If
        Else
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "請先執行查詢!")
        End If
    End Sub
End Class
