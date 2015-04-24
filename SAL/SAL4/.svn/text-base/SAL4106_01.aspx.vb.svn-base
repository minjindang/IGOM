Imports FSC.Logic
Imports SAL.Logic
Imports System.Data
Imports System.Collections.Generic
Imports Excel = Microsoft.Office.Interop.Excel


Partial Class SAL4106_01
    Inherits BaseWebForm
    Dim OrgType As String = System.Configuration.ConfigurationManager.AppSettings("OrgType")
    Dim Case_status As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack() Then
            Return
        End If
        InitControl()
    End Sub

    Protected Sub InitControl()
        Dim Role_id As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.RoleId)
        'UcDDLDepart.Orgcode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode) '有這行才會load進UcDDLDepart

        '日期欄位預設有填寫這月的日期
        UcDate1.Text = DateTimeInfo.GetRocTodayString("yyyyMM") & "01"
        UcDate2.Text = DateTimeInfo.GetRocTodayString("yyyyMM") & Date.DaysInMonth(Now.Year, Now.Month).ToString.PadLeft(2, "0")

        'UserName_Bind()

        Dim dt As DataTable = New FSCPLM.Logic.SACode().GetData("006", "019")
        ddlApply_type.DataTextField = "code_desc1"   '顯示的中文名稱
        ddlApply_type.DataValueField = "code_no"     '所代表的value
        ddlApply_type.DataSource = dt                '指定datatable給ddl
        ddlApply_type.DataBind()                     'ddl進行Databind
        ddlApply_type.Items.Insert(0, New ListItem("請選擇", "")) 'Index=0，插入"請選擇"
        'ddlQuit_Job.Items.Insert(0, New ListItem("請選擇", ""))

    End Sub

    Protected Sub btnQuery_Click(sender As Object, e As EventArgs) Handles btnQuery.Click
        Dim orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode) '機構代碼
        Dim Apply_type As String = ddlApply_type.SelectedValue
        Dim AcademicYear As String = ddlAcademicYear.Year
        Dim Apply_sTime As String = UcDate1.Text
        Dim Apply_eTime As String = UcDate2.Text


        Dim bll As New SAL4106()
        Dim dt As DataTable

        If String.IsNullOrEmpty(Apply_sTime) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "「起日」欄位為必填。")
            Return
        End If
        If String.IsNullOrEmpty(Apply_eTime) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "「迄日」欄位為必填。")
            Return
        End If
        Try
            dt = bll.getQueryData(Apply_type, AcademicYear, Apply_sTime, Apply_eTime)
          
            tbq.Visible = True
            ViewState("dt") = dt
            Me.gvlist.DataSource = dt
            Me.gvlist.DataBind()
            dt.Dispose()

            'btnPrint.Enabled = True
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
    Protected Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        Response.Redirect("SAL4106_02.aspx")
    End Sub

    Protected Sub btnModify_Click(sender As Object, e As EventArgs)
        Dim gvr As GridViewRow = CType(sender, Button).NamingContainer
        Dim id As String = CType(gvr.FindControl("lbid"), Label).Text
        Response.Redirect("SAL4106_03.aspx?id=" + id)
    End Sub
    Protected Sub btnDelete_Click(sender As Object, e As EventArgs)
        Dim bll As New SAL4106()
        Dim gvr As GridViewRow = CType(sender, Button).NamingContainer
        Dim Apply_type As String = CType(gvr.FindControl("lbApply_type"), Label).Text
        Dim Apply_sDate As String = CType(gvr.FindControl("Apply_sDate"), UControl_UcShowDate).Text
        Dim Apply_eDate As String = CType(gvr.FindControl("Apply_eDate"), UControl_UcShowDate).Text

        Dim dr As DataRow = New FSCPLM.Logic.SACode().GetRow("006", "019", Apply_type)
        If dr IsNot Nothing Then
            For Each Form_id As String In dr("CODE_REMARK1").ToString.Split("，")
                Dim dt As DataTable = bll.getFlowData(Form_id, Apply_sDate, Apply_eDate)
                If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                    CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "已有" + dr("CODE_DESC1").ToString + "的表單申請，不可刪除!")
                    Return
                End If
            Next
        End If

        Dim id As String = CType(gvr.FindControl("lbid"), Label).Text
        If (bll.getDeleteData(id)) = True Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "「刪除成功」", "SAL4106_01.aspx")
        End If
    End Sub

    Protected Sub gvlist_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles gvlist.RowDataBound
        For Each gvr As GridViewRow In gvlist.Rows
            Dim btnDelete As Button = CType(gvr.FindControl("btnDelete"), Button)
            Dim id As String = CType(gvr.FindControl("lbid"), Label).Text
            Dim Apply_type As String = CType(gvr.FindControl("lbApply_type"), Label).Text
            'Select Case Apply_type
            '    Case "子女教育補助費"
            '        Apply_type = "001"
            '    Case "勞 健公 健保繳納證明申請"
            '        Apply_type = "002"
            '    Case "未休假加班費申請"
            '        Apply_type = "003"
            'End Select
            Dim dt As DataTable = New DataTable
            Dim bll As New SAL4106()
            dt = bll.getDeleteSelectData(Apply_type, id)
            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                btnDelete.Attributes.Add("onclick", "if(!confirm('" + "刪除後，開放申請時間會變為" + DateTimeInfo.ToDisplay(dt.Rows(0)("Apply_sDate").ToString) + _
                          DateTimeInfo.ToDisplayTime(dt.Rows(0)("Apply_sTime").ToString) + " 至 " + _
                          DateTimeInfo.ToDisplay(dt.Rows(0)("Apply_eDate").ToString) + DateTimeInfo.ToDisplayTime(dt.Rows(0)("Apply_eTime").ToString) + _
                         "\n確定刪除？'))return false;")
            End If
        Next
    End Sub
End Class
