Imports FSCPLM.Logic
Imports System.Data
Imports System.Collections.Generic
Imports System.Transactions

Partial Class FSC3107_01
    Inherits BaseWebForm

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack() Then
            Return
        End If

        BindYear()
    End Sub


#Region "顯示下拉選單"
    Protected Sub BindYear()
        For i As Integer = Now.Year - 1 - 1911 To Now.Year - 1911
            Dim y As String = i.ToString().PadLeft(3, "0")
            ddlYear.Items.Add(New ListItem(y, y))
        Next
        ddlYear.SelectedValue = (Now.Year - 1911).ToString().PadLeft(3, "0")

        BindEmpType()
    End Sub
#End Region

    Protected Sub BindEmpType()
        ddlEmpType.Items.Add(New ListItem("請選擇", ""))

        If LoginManager.RoleId.IndexOf("Personnel") >= 0 Then
            ddlEmpType.Items.Add(New ListItem("正式人員", "1"))
        ElseIf LoginManager.RoleId.IndexOf("Sec_PerManager") >= 0 Then
            ddlEmpType.Items.Add(New ListItem("技工工友", "3"))
            ddlEmpType.Items.Add(New ListItem("司機", "8"))
        Else
            ddlEmpType.Items.Add(New ListItem("正式人員", "1"))
            ddlEmpType.Items.Add(New ListItem("技工工友", "3"))
            ddlEmpType.Items.Add(New ListItem("司機", "8"))
        End If
    End Sub

    Protected Sub btnTrans_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTrans.Click
        If ddlitem.SelectedValue = "1" Then
            apply()
        ElseIf ddlitem.SelectedValue = "2" Then
            trans()
        End If
    End Sub

    Protected Sub apply()
        Dim orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim year As String = ddlYear.SelectedValue()
        Dim employeeType As String = ddlEmpType.SelectedValue
        Dim bll As New FSC.Logic.FSC3107()

        Dim dt As DataTable = bll.GetData(orgcode, "", employeeType, year)
        gvList.DataSource = dt
        gvList.DataBind()

        TABLE2.Visible = True
    End Sub

    Protected Sub trans()
        Dim orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim year As String = ddlYear.SelectedValue()
        Dim employeeType As String = ddlEmpType.SelectedValue
        Dim msg As New StringBuilder()
        Dim bll As New FSC.Logic.FSC3107()
        Dim sa As New FSC.Logic.SettlementAnnual()

        Dim mustHours As Integer = bll.GetMustHours()
        Dim sdt As DataTable = bll.GetSettlementAnnual(orgcode, "", employeeType, year)
        Dim i As Integer = 0

        For Each dr As DataRow In sdt.Rows
            Dim idCard As String = dr("Id_card").ToString()
            Dim userName As String = dr("User_name").ToString()
            Dim Annual_days As String = dr("Annual_days").ToString()    '本年可休假天數
            Dim PEKIND As String = dr("PEKIND").ToString()
            Dim PEMEMCOD As String = dr("Employee_type").ToString()
            Dim firstGovDate As String = dr("Fisrt_gov_date").ToString()
            Dim leaveHours As Integer = dr("Leave_hours").ToString()
            Dim payHours As Integer = FSC.Logic.Content.ConvertToHours(dr("Pay_days").ToString())
            Dim retain_leave_hours As Integer = dr("retain_leave_hours").ToString()

            Dim PERDAY1Hours As String = dr("PERDAY1").ToString()
            Dim PERDAY2Hours As Integer = dr("PERDAY2").ToString()

            Dim usablePayHours As Integer = 0
            Dim annualHours As Integer = FSC.Logic.Content.ConvertToHours(Annual_days)
            If leaveHours > mustHours Then
                usablePayHours = annualHours - leaveHours
            Else
                usablePayHours = annualHours - mustHours
            End If
            usablePayHours = IIf(usablePayHours < 0, 0, usablePayHours)

            '可請領的天數 - 請領天數  
            Dim PERDAY1 As String = FSC.Logic.Content.ConvertDayHours(usablePayHours - payHours)
            PERDAY1 = IIf(PERDAY1 < 0, 0, PERDAY1)
            'Reserve_Days1 + Reserve_Days2 - 今年請的保留假   
            Dim PERDAY2 As String = FSC.Logic.Content.ConvertDayHours(PERDAY1Hours + PERDAY2Hours - retain_leave_hours)
            PERDAY2 = IIf(PERDAY2 < 0, 0, PERDAY2)

            Using scope As New TransactionScope
                Try
                    sa.updateTransFlag(orgcode, "", year, idCard, "Y")

                    Dim p As FSC.Logic.Personnel = New FSC.Logic.Personnel()
                    p.Perday = 0            '本年擬保留
                    p.Perday1 = PERDAY1    '擬保留至明年日數 -> 前一年保留
                    p.Perday2 = PERDAY2     '前一年保留 -> 前二年保留

                    '取 PEHYEAR, PEDAY
                    Dim l As FSC.Logic.LeaveYearDay = FSC.Logic.CntLeave.GetCntYearsDays(orgcode, idCard, firstGovDate, "", PEKIND, PEMEMCOD)
                    If l IsNot Nothing Then
                        p.Pehyear = l.Year
                        p.Pehday = l.Day
                    End If

                    p.UpdateAnnel(p.Perday, p.Perday1, p.Perday2, p.Pehyear, p.Pehday, idCard)

                    scope.Complete()
                    i += 1
                Catch ex As Exception
                    msg.Append(userName).Append("(").Append(idCard).Append(")").Append("結轉時發生錯誤!\n")
                End Try

            End Using
        Next

        CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "已成功更新" & i.ToString() & "筆資料")

        If Not String.IsNullOrEmpty(msg.ToString()) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, msg.ToString())
        End If
    End Sub

    Protected Sub cbConfirm_Click(sender As Object, e As EventArgs)
        Dim annual As New FSC_Settlement_Annual()
        Dim orgcode As String = LoginManager.OrgCode
        Dim year As String = ddlYear.SelectedValue()

        Try
            Using scope As New TransactionScope
                For Each gvr As GridViewRow In gvList.Rows
                    If Not CType(gvr.FindControl("cbx"), CheckBox).Checked Then
                        Continue For
                    End If

                    Dim depart_id As String = CType(gvr.FindControl("hfDepart_id"), HiddenField).Value
                    Dim id_card As String = CType(gvr.FindControl("hfId_card"), HiddenField).Value
                    Dim user_name As String = CType(gvr.FindControl("hfUser_name"), HiddenField).Value
                    Dim Holidays As String = CType(gvr.FindControl("hfHolidays"), HiddenField).Value
                    Dim Leave_days As String = CType(gvr.FindControl("hfLeave_days"), HiddenField).Value
                    Dim pay_days As String = CType(gvr.FindControl("tbApplyDays"), TextBox).Text

                    annual.Add("", orgcode, depart_id, id_card, user_name, "", year, DateTimeInfo.GetRocDate(Now), LoginManager.UserId, LoginManager.Depart_id, _
                               "001", Holidays, Leave_days, 0, 0, 0, 0, pay_days, 0, 0, 0, 0, 0, 0, "", "", "", LoginManager.Account, Now)
                Next

                scope.Complete()
            End Using

            CommonFun.MsgShow(Me, CommonFun.Msg.UpdateOK)
            apply()

        Catch ex As Exception
            CommonFun.MsgShow(Me, CommonFun.Msg.SystemError)
        End Try
    End Sub

    Protected Sub cbxAll_CheckedChanged(sender As Object, e As EventArgs)
        Dim cbxAll As CheckBox = CType(sender, CheckBox)
        For Each gvr As GridViewRow In gvList.Rows
            CType(gvr.FindControl("cbx"), CheckBox).Checked = cbxAll.Checked
        Next
    End Sub

    Protected Sub ddlitem_SelectedIndexChanged(sender As Object, e As EventArgs)
        TABLE2.Visible = False
    End Sub

    Protected Sub cbSendNotice_Click(sender As Object, e As EventArgs)
        Dim yyy As String = ddlYear.SelectedValue
        Dim msg As New StringBuilder()

        For Each gvr As GridViewRow In gvList.Rows
            If Not CType(gvr.FindControl("cbx"), CheckBox).Checked Then
                Continue For
            End If

            Dim id_card As String = CType(gvr.FindControl("hfId_card"), HiddenField).Value
            Dim isSend As Boolean = False
            Dim content As New StringBuilder()
            Dim p As FSC.Logic.Personnel = New FSC.Logic.Personnel().GetObject(id_card)

            If p IsNot Nothing Then
                Dim ToMail As String = p.Email
                Dim ToName As String = p.UserName

                content.AppendLine(ToName & " 您好：<br />")
                content.AppendLine("您尚未申請" & yyy & "年度未休假加班費，請至系統內進行申請。")

                Dim SendMail As String = ConfigurationManager.AppSettings("SysMail").ToString()
                Dim SendName As String = ConfigurationManager.AppSettings("SysName").ToString()

                isSend = CommonFun.SendMail(SendMail, ToMail, SendName, ToName, "您尚未申請" & yyy & "年度未休假加班費", content.ToString())

                If Not isSend Then
                    msg.AppendLine(ToName & "發送郵件失敗\n")
                End If
            End If
        Next

        If Not String.IsNullOrEmpty(msg.ToString()) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, msg.ToString())
        Else
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "寄送成功")
        End If

    End Sub
End Class
