Imports System
Imports System.Data
Imports FSC.Logic

Partial Class SYS2102_01
    Inherits BaseWebForm

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load, Me.Load
        If IsPostBack Then
            Return
        End If

        BindInit()
    End Sub

    Protected Sub BindInit()
        Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim roleId As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.RoleId)

        ' 日期設定
        Me.UcDate1.Text = DateTimeInfo.GetRocTodayString("yyyyMM") & "01"
        Me.UcDate2.Text = DateTimeInfo.GetRocTodayString("yyyyMM") & Date.DaysInMonth(Now.Year, Now.Month).ToString.PadLeft(2, "0")

        ' Bind 單位名稱
        Me.UcDDLDepart.Orgcode = Orgcode

        ' Bind 人員姓名
        'Member_Bind()

        Dim r As New SYS.Logic.Role()
        hfFormIds.Value = r.GetRoleForm(Orgcode, roleId)

        BindType()
        BindFormId()

        ddlStatus.DataSource = New FSCPLM.Logic.SACode().GetData2("023", "P", "002")
        ddlStatus.DataBind()
    End Sub

    'Protected Sub Member_Bind()
    '    Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)

    '    Me.ddlUser_name.DataTextField = "User_name"
    '    Me.ddlUser_name.DataValueField = "id_card"
    '    Me.ddlUser_name.DataSource = New FSC.Logic.Personnel().GetDataByOrgDep(Orgcode, UcDDLDepart.SelectedValue)
    '    Me.ddlUser_name.DataBind()
    '    Me.ddlUser_name.Items.Insert(0, New ListItem("請選擇", ""))
    'End Sub

    Protected Sub BindType()
        Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim bll As New SYS.Logic.SYS2101()

        ddlCodeType.DataSource = bll.GetFormKind(Orgcode, hfFormIds.Value)
        ddlCodeType.DataBind()
        ddlCodeType.Items.Insert(0, New ListItem("請選擇", ""))
    End Sub

    Protected Sub BindFormId()
        Dim orgcode As String = LoginManager.OrgCode
        Dim roleId As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.RoleId)
        Dim codeType As String = ddlCodeType.SelectedValue

        Dim bll As New SYS.Logic.SYS2101()

        Dim c As String = ""
        For Each f As String In hfFormIds.Value.Split(",")
            If codeType = f.Substring(0, 3) Then
                If Not String.IsNullOrEmpty(c) Then
                    c &= ","
                End If
                c &= f
            End If
        Next

        Dim saCodedt As DataTable = bll.GetFormType(orgcode, codeType, c)

        Dim dt As New DataTable()
        dt.Columns.Add("formName")
        dt.Columns.Add("formId")

        Dim leaveType As New SYS.Logic.LeaveType()
        For Each saCodedr As DataRow In saCodedt.Rows
            Dim dr As DataRow = dt.NewRow
            dr("formId") = codeType & saCodedr("code_no")       ' formId : code_type + code_no
            dr("formName") = saCodedr("code_desc1")
            dt.Rows.Add(dr)
        Next
        ddlForm.DataSource = dt
        ddlForm.DataBind()
        ddlForm.Items.Insert(0, New ListItem("請選擇", ""))
    End Sub

    Protected Sub ddlCodeType_SelectedIndexChanged(sender As Object, e As EventArgs)
        BindFormId()
    End Sub

    'Protected Sub UcDDLDepart_SelectedIndexChanged(sender As Object, e As EventArgs) Handles UcDDLDepart.SelectedIndexChanged
    '    Member_Bind()
    'End Sub

    Protected Sub btnQuery_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnQuery.Click
        ShowData()
    End Sub

    ''' <summary>
    ''' 依查詢條件顯示查詢結果
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ShowData()
        Dim orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim bll As New SYS.Logic.SYS2102()
        Dim formId As String = ddlCodeType.SelectedValue

        If Not String.IsNullOrEmpty(ddlForm.SelectedValue) Then
            formId = ddlForm.SelectedValue
        End If

        Dim status As String = ddlStatus.SelectedValue

        Dim r As DataRow = New FSCPLM.Logic.SACode().GetRow("023", "002", status)
        Dim caseStatus As String = ""
        Dim lastPass As String = ""
        If r IsNot Nothing Then
            caseStatus = r("code_remark1").ToString()
            lastPass = r("code_remark2").ToString()
        End If
        Dim Start_date As String = UcDate1.Text
        Dim End_date As String = UcDate2.Text

        Try
            Dim dt As DataTable
            dt = bll.GetFormData(orgcode, Start_date, End_date, formId, hfFormIds.Value, caseStatus, lastPass, UcDDLDepart.SelectedValue, "", "")
            ViewState("dt") = dt
            Me.gv.DataSource = dt
            'gv.DataSource = 
            Me.gv.DataBind()
            dt.Dispose()
        Catch ex As Exception
            AppException.WriteErrorLog(ex.StackTrace, ex.Message)
            CommonFun.MsgShow(Me, CommonFun.Msg.SystemError)
        End Try
    End Sub

    Protected Sub gv_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles gv.DataBound
        tbQ.Visible = True
        'IIf(gv.Rows.Count > 0, True, False)
    End Sub
#Region "頁數改變時"
    Protected Sub gv_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gv.PageIndexChanging
        Me.gv.PageIndex = e.NewPageIndex
        Me.gv.DataSource = CType(ViewState("dt"), DataTable)
        Me.gv.DataBind()
    End Sub
#End Region

End Class
