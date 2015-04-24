Imports System
Imports System.Data
Imports FSC.Logic

Partial Class SYS2_SYS2104_01
    Inherits BaseWebForm

    Dim dtData As DataTable

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load, Me.Load
        If IsPostBack Then
            Return
        End If

        Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim bll As New SYS.Logic.SYS2104()

        ' 日期設定
        Me.UcDate1.Text = DateTimeInfo.GetRocTodayString("yyyyMM") & "01"
        Me.UcDate2.Text = DateTimeInfo.GetRocTodayString("yyyyMM") & Date.DaysInMonth(Now.Year, Now.Month).ToString.PadLeft(2, "0")

        ' Bind 單位名稱
        Me.UcDDLDepart.Orgcode = Orgcode

        ' Bind 人員姓名
        Member_Bind()

        ' Bind 在職狀態
        Me.ddlWorkType.DataTextField = "CODE_DESC1"
        Me.ddlWorkType.DataValueField = "CODE_NO"
        Me.ddlWorkType.DataSource = bll.getEmployeeTypeData("023", "025")
        Me.ddlWorkType.DataBind()
        Me.ddlWorkType.Items.Insert(0, New ListItem("請選擇", ""))

        ' Bind 人員類別

        Me.ddlEmployeeType.DataTextField = "CODE_DESC1"
        Me.ddlEmployeeType.DataValueField = "CODE_NO"
        Me.ddlEmployeeType.DataSource = bll.getEmployeeTypeData("023", "022")
        Me.ddlEmployeeType.DataBind()
        Me.ddlEmployeeType.Items.Insert(0, New ListItem("全部", ""))
    End Sub

    Protected Sub Member_Bind()
        Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)

        Me.ddlUser_name.DataTextField = "User_name"
        Me.ddlUser_name.DataValueField = "User_name"
        Me.ddlUser_name.DataSource = New Member().GetDataByOrgDep(Orgcode, UcDDLDepart.SelectedValue)
        Me.ddlUser_name.DataBind()
        Me.ddlUser_name.Items.Insert(0, New ListItem("請選擇", ""))
    End Sub

    Protected Sub UcDDLDepart_SelectedIndexChanged(sender As Object, e As EventArgs) Handles UcDDLDepart.SelectedIndexChanged
        Member_Bind()
    End Sub

    Protected Sub btnQuery_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnQuery.Click
        ShowData()
    End Sub

    ''' <summary>
    ''' 依查詢條件顯示查詢結果
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ShowData()
        Dim szOrgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim szLoginTimeStart As String = Me.UcDate1.Text
        Dim szLoginTimeEnd As String = Me.UcDate2.Text
        Dim szDepartId As String = UcDDLDepart.SelectedValue
        Dim szUserName As String = Me.ddlUser_name.SelectedValue
        Dim szIdCard As String = Me.UcPersonal_id.PersonnelId
        Dim szEmployeeType As String = Me.ddlEmployeeType.SelectedValue
        Dim szLoginStatus As String = Me.ddlLoginStatus.SelectedValue
        Dim szWorkType As String = Me.ddlWorkType.SelectedValue
        Dim bll As New SYS.Logic.SYS2104()

        Try
            dtData = bll.getData(szOrgcode, szLoginTimeStart, szLoginTimeEnd, szDepartId, szUserName, szIdCard, szEmployeeType, szLoginStatus, szWorkType)

            Me.gvList.DataSource = dtData
            Me.gvList.DataBind()
            tbQ.Visible = True

        Catch ex As Exception
            AppException.WriteErrorLog(ex.StackTrace(), ex.Message())
            CommonFun.MsgShow(Me, CommonFun.Msg.SystemError)
        End Try

    End Sub

    Protected Sub gvList_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvList.PageIndexChanging
        Me.gvList.PageIndex = e.NewPageIndex
        ShowData()
    End Sub

End Class
