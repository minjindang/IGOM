Imports System
Imports System.Data
Imports System.Xml
Imports System.IO
Imports System.Drawing
Imports System.Collections.Generic
Imports FSCPLM.Logic
Imports NLog

Partial Class FSC0101_01
    Inherits BaseWebForm

    Dim orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
    Dim departId As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id)
    Dim idCard As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card)
    Dim roleid As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.RoleId)
    Dim bll As New FSC.Logic.FSC0101()
    Private logger As Logger = LogManager.GetLogger("FSC0101")

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then
            Return
        End If

        Bind()
        Bind_CPAPK_ERROR()
        Bind_ScheduleData()
        Bind_Inventory()
        Bind_BackData()

        Dim psn As FSC.Logic.Personnel = New FSC.Logic.Personnel().GetObject(idCard)
        If psn IsNot Nothing AndAlso psn.On_Duty = "1" Then
            tbDuty.Visible = True
        End If
        If roleid.IndexOf("TackleAdmin") >= 0 Then
            TackleArea.Visible = True
        End If
    End Sub

    ''' <summary>
    ''' 待批/辦件數
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub Bind()
        '件數
        Dim nextCount As Integer = bll.GetNextCount(orgcode, departId, idCard)
        hlNextCount.Text = nextCount
        hlNextCount.NavigateUrl = IIf(nextCount = 0, "", "FSC0101_02.aspx")

        'Dim level As Integer = 0
        'Dim levelCount As Integer = 0
        'Dim psn As New FSC.Logic.Personnel()

        'Dim bossLevelId As String = psn.GetColumnValue("Boss_level_id", idCard)
        'If "2" = bossLevelId Then
        '    'levelTr.Visible = True
        '    level = CommonFun.getInt(bossLevelId) + 1

        '    Dim parentDepartId As String = ""
        '    Dim dr As DataRow = New FSC.Logic.Org().GetDataByDepartid(orgcode, departId)
        '    If dr IsNot Nothing Then
        '        parentDepartId = dr("parent_depart_id").ToString()

        '        Dim pdt As DataTable = psn.GetDataByBossLevelId(orgcode, parentDepartId, level)
        '        If pdt IsNot Nothing AndAlso pdt.Rows.Count > 0 Then
        '            For Each pdr As DataRow In pdt.Rows
        '                levelCount += bll.GetNextCount(pdr("orgcode").ToString(), pdr("depart_id").ToString(), pdr("Id_card").ToString())
        '            Next
        '        End If
        '    End If

        '    hlLevelCount.Text = levelCount
        '    hlLevelCount.NavigateUrl = IIf(levelCount = 0, "", "FSC0101_02.aspx?level=" & level)
        'End If
    End Sub

    ''' <summary>
    ''' 取得當月份刷卡異常資料
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub Bind_CPAPK_ERROR()
        Dim yyymm As String = DateTimeInfo.GetRocDate(Now.AddMonths(-1)).Substring(0, 5)
        Dim yyymm1 As String = DateTimeInfo.GetRocTodayString("yyyyMM")
        Dim dt As DataTable = bll.GetCPAPK_ERROR(idCard, yyymm, "'0','1','2','3','4'")
        Dim dt1 As DataTable = bll.GetCPAPK_ERROR(idCard, yyymm1, "'0','1','2','3','4'")
        dt.Merge(dt1)
        gvCPAPK_ERROR.DataSource = dt
        gvCPAPK_ERROR.DataBind()
    End Sub

    ''' <summary>
    ''' 取得當月份排班資料
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub Bind_ScheduleData()
        Dim sDate As String = DateTimeInfo.GetRocTodayString("yyyyMM") & Date.Today.Day.ToString.PadLeft(2, "0")
        Dim eDate As String = DateTimeInfo.GetRocTodayString("yyyyMM") & Date.DaysInMonth(Now.Year, Now.Month).ToString.PadLeft(2, "0")

        gvSchedule.DataSource = bll.GetScheduleData(orgcode, departId, idCard, sDate, eDate)
        gvSchedule.DataBind()
    End Sub

    Protected Sub Bind_Inventory()
        Dim dt, dt2, dt3 As DataTable
        dt = bll.GetInventoryData(orgcode)
        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 AndAlso dt.Rows(0).Item("InvMemo").ToString() = "*" Then
            If roleid.IndexOf("TackleAdmin") < 0 Then
                TackleArea.Visible = True
                TackleAreatr2.Visible = False
                TackleAreatr3.Visible = False
            End If

            lbInventory.Visible = True
            lbInventory.Text = String.Format(lbInventory.Text, dt.Rows(0)("InvStart_date"), dt.Rows(0)("Expected_date"))
        End If
        dt2 = bll.GetIneAdminData(orgcode, departId, idCard, roleid)
        hylsafe.NavigateUrl = IIf(dt2 Is Nothing, "", "~/MAT/MAT2/MAT2105_01.aspx")
        If dt2 IsNot Nothing AndAlso dt2.Rows.Count > 0 Then 'LevAdministrator
            dt3 = bll.GetAvailableSafeData(orgcode, departId, idCard)
            If dt3.Rows(0)("Column1") > 0 Then
                lbwarn.Text = String.Format(lbwarn.Text, dt3.Rows(0)("Column1"))
                lbwarn.Visible = True
            End If
        End If
    End Sub

    Protected Sub Bind_BackData()
        Dim bll As New FSC.Logic.FSC0101()
        Dim dt As DataTable = bll.GetApplyData(orgcode, departId, idCard, "", "", "", "2", "")

        gv_Back.DataSource = dt
        gv_Back.DataBind()
        tb_Back.Visible = (dt IsNot Nothing AndAlso dt.Rows.Count > 0)
    End Sub

    Protected Sub gvCPAPK_ERROR_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles gvCPAPK_ERROR.PageIndexChanging
        gvCPAPK_ERROR.PageIndex = e.NewPageIndex
        Bind_CPAPK_ERROR()
    End Sub

    Protected Sub gvSchedule_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles gvSchedule.PageIndexChanging
        gvSchedule.PageIndex = e.NewPageIndex
        Bind_ScheduleData()
    End Sub

    Protected Sub gv_Back_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles gv_Back.PageIndexChanging
        gv_Back.PageIndex = e.NewPageIndex
        Bind_BackData()
    End Sub
End Class
