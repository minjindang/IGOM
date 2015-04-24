Imports FSC.Logic
Imports SAL.Logic
Imports System.Data
Imports System.Collections.Generic
Imports Excel = Microsoft.Office.Interop.Excel


Partial Class SAL4106_02
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
        Dim orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode) '有這行才會load進UcDDLDepart
        Dim dt As DataTable = New FSCPLM.Logic.SACode().GetData("006", "019")
        ddlApply_type.DataTextField = "code_desc1"   '顯示的中文名稱
        ddlApply_type.DataValueField = "code_no"     '所代表的value
        ddlApply_type.DataSource = dt                '指定datatable給ddl
        ddlApply_type.DataBind()                     'ddl進行Databind
        ddlApply_type.Items.Insert(0, New ListItem("請選擇", "")) 'Index=0，插入"請選擇"
    End Sub

    Protected Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Dim orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode) '機構代碼
        Dim Apply_type As String = ddlApply_type.SelectedValue
        Dim AcademicYear As String = ddlAcademicYear.Year
        Dim Semester As String = txtSemeter.Text
        Dim Apply_sDate As String = UcDate1.Text
        Dim Apply_sTime As String = UcDateTime1.Text
        Dim Apply_eDate As String = UcDate2.Text
        Dim Apply_eTime As String = UcDateTime2.Text
        Dim Status As String = ddlStatus.SelectedValue
        Dim ModUser_id As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card)
        Dim S As String = DateTime.Now ' Add New Time
        'Dim S As String = DateTimeInfo.GetTodayString
        Dim bll As New SAL4106()
        If String.IsNullOrEmpty(Apply_type) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "「申請類別」欄位為必填。")
            Return
        End If
        If Apply_type = "001" Then
            If String.IsNullOrEmpty(txtSemeter.Text.Trim) Then
                CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "申請類別為「子女教育補助費」，「申請學期」欄位為必填。")
                Return
            ElseIf Not CommonFun.IsNum(txtSemeter.Text.Trim) Then
                CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "「申請學期」請輸入數字。")
                Return
            End If
        End If
        If String.IsNullOrEmpty(AcademicYear) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "「申請年度」欄位為必填。")
            Return
        End If
        If String.IsNullOrEmpty(Status) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "「開放狀態」欄位為必填。")
            Return
        End If
        If String.IsNullOrEmpty(Apply_sDate) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "「申請日期(起)」欄位為必填。")
            Return
        End If
        If String.IsNullOrEmpty(Apply_sTime) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "「申請時間(起)」欄位為必填。")
            Return
        ElseIf Not CommonFun.IsNum(Apply_sTime) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "「申請時間(起)」格式不正確。")
            Return
        End If
        If String.IsNullOrEmpty(Apply_eDate) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "「申請日期(迄)」欄位為必填。")
            Return
        End If
        If String.IsNullOrEmpty(Apply_eTime) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "「申請時間(迄)」欄位為必填。")
            Return
        ElseIf Not CommonFun.IsNum(Apply_eTime) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "「申請時間(迄)」格式不正確。")
            Return
        End If

        Try
            If (bll.getInsertData(Apply_type, AcademicYear, Semester, Apply_sDate, Apply_sTime, Apply_eDate, Apply_eTime, _
                                  Status, ModUser_id, orgcode)) = True Then
                CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "「新增成功」", "SAL4106_01.aspx")
            End If
        Catch ex As Exception
            CommonFun.MsgShow(Me.Page, CommonFun.Msg.SystemError)
            AppException.WriteErrorLog(ex.StackTrace, ex.Message)
        End Try
        'Response.Redirect("SAL4106_01.aspx")
    End Sub

    Protected Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Response.Redirect("SAL4106_01.aspx")
    End Sub

    Protected Sub ddlApply_type_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlApply_type.SelectedIndexChanged
        If ddlApply_type.SelectedValue = "001" Then
            tr1.Visible = True
        Else
            tr1.Visible = False
        End If
    End Sub
End Class
