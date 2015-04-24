Imports FSCPLM.Logic
Imports System.Data
Imports System.Collections.Generic

Partial Class FSC3112_03
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
        BindName()
        BindSex()
    End Sub

    Protected Sub BindSex()
        cbxlsex.DataSource = New FSCPLM.Logic.SACode().GetData("023", "026")
        cbxlsex.DataBind()
    End Sub

    Protected Sub BindSchedule()
        Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim sche As New FSC.Logic.Schedule()
        rblSchedule.DataSource = sche.GetData(Orgcode)
        rblSchedule.DataBind()
    End Sub

    Protected Sub BindName()
        Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim onDuty As String = "1"   '值班
        Dim sex As String = ""
        For Each item As ListItem In cbxlsex.Items
            If item.Selected Then
                sex &= item.Value & ","
            End If
        Next
        sex = sex.TrimEnd(",")
        lbxMember.DataSource = New FSC.Logic.FSC3112().GetDataByOnDutySex(onDuty, sex)
        lbxMember.DataBind()
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

    Protected Sub cbCancel_Click(sender As Object, e As EventArgs)
        Response.Redirect("FSC3112_01.aspx")
    End Sub

    Protected Sub cbConfirm_Click(sender As Object, e As EventArgs)
        Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim yymm As String = DD_Year.SelectedValue & DD_Month.SelectedValue
        Dim list As New ArrayList()

        If lbxMember.SelectedIndex < 0 Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "請先選擇上次值班最後一位人員!")
            Return
        End If
        If rblSchedule.SelectedIndex < 0 Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "請先選擇班別!")
            Return
        End If

        For i As Integer = lbxMember.SelectedIndex + 1 To lbxMember.Items.Count - 1
            list.Add(lbxMember.Items(i).Value)
        Next
        For i As Integer = 0 To lbxMember.SelectedIndex
            list.Add(lbxMember.Items(i).Value)
        Next

        Dim bll As New FSC.Logic.FSC3112()
        Dim msg As String = bll.RunAutoSchedule(Orgcode, yymm, rblSchedule.SelectedValue, list)
        If String.IsNullOrEmpty(msg) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "排班成功!")
        Else
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, msg)
        End If
        
    End Sub

    Protected Sub rblSchedule_SelectedIndexChanged(sender As Object, e As EventArgs)
        BindMemList()
    End Sub

    Protected Sub DD_Year_SelectedIndexChanged(sender As Object, e As EventArgs)
        BindMemList()
    End Sub

    Protected Sub DD_Month_SelectedIndexChanged(sender As Object, e As EventArgs)
        BindMemList()
    End Sub

    Protected Sub cbxlsex_SelectedIndexChanged(sender As Object, e As EventArgs)
        BindName()
        BindMemList()
    End Sub

    Protected Sub BindMemList()
        Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim scheSetting As New FSC.Logic.ScheduleSetting()
        Dim scheduleId As String = rblSchedule.SelectedValue
        Dim yymm As String = DD_Year.SelectedValue & DD_Month.SelectedValue
        Dim dt As DataTable

        '上個月
        yymm = DateTimeInfo.GetRocDate(DateTimeInfo.GetPublicDate(yymm & "01").AddMonths(-1).Date).Substring(0, 5)

        If scheduleId = "A00004" Or scheduleId = "A00005" Then
            '1.農曆過年, 先找上個月
            dt = scheSetting.GetMaxDataByScheId(Orgcode, yymm, scheduleId)

            If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
                '2.無資料, 找去年
                yymm = (DateTimeInfo.GetPublicDate(DD_Year.SelectedValue & "0101").AddYears(-1).Year - 1911).ToString().PadLeft(3, "0")
                dt = scheSetting.GetMaxDataByScheId(Orgcode, yymm, scheduleId)
            End If

        End If

        dt = scheSetting.GetMaxDataByScheId(Orgcode, yymm, scheduleId)

        For Each dr As DataRow In dt.Rows
            Dim b As Boolean = False
            For Each item As ListItem In lbxMember.Items
                If item.Value = dr("id_card").ToString() Then
                    item.Selected = True
                    b = True
                Else
                    item.Selected = False
                End If
            Next
            If b Then
                Exit For
            End If
        Next
    End Sub

End Class
