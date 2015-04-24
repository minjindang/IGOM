Imports FSC.Logic
Imports SAL.Logic
Imports System.Data
Imports System.Collections.Generic
Imports Excel = Microsoft.Office.Interop.Excel


Partial Class SAL4106_03
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
        Dim orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode) '機構代碼
        Dim ModUser_id As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card)
        Dim id As String = Request.QueryString("id")
        Dim bll As New SAL4106()
        Dim dt As DataTable
        dt = bll.getQueryDataByID(id)
        Apply_type.Text = dt.Rows(0)("ApplyType").ToString
        ddlAcademicYear.Year = dt.Rows(0)("AcademicYear").ToString
        txtSemeter.Text = dt.Rows(0)("Semester").ToString
        UcDate1.Text = dt.Rows(0)("Apply_sDate").ToString
        UcDateTime1.Text = dt.Rows(0)("Apply_sTime").ToString
        UcDate2.Text = dt.Rows(0)("Apply_eDate").ToString
        UcDateTime2.Text = dt.Rows(0)("Apply_eTime").ToString
        ddlStatus.SelectedValue = dt.Rows(0)("Status").ToString
        tr1.Visible = (dt.Rows(0)("apply_type").ToString() = "001")
    End Sub

    Protected Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Dim orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode) '機構代碼
        Dim AcademicYear As String = ddlAcademicYear.Year
        Dim Semester As String = txtSemeter.Text
        Dim Apply_sDate As String = UcDate1.Text
        Dim Apply_sTime As String = UcDateTime1.Text
        Dim Apply_eDate As String = UcDate2.Text
        Dim Apply_eTime As String = UcDateTime2.Text
        Dim Status As String = ddlStatus.SelectedValue
        Dim ModUser_id As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card)
        Dim id As String = Request.QueryString("id")

        Dim bll As New SAL4106()

        If String.IsNullOrEmpty(AcademicYear) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "「申請年度」欄位為必填。")
            Return
        End If
        If tr1.Visible Then
            If String.IsNullOrEmpty(txtSemeter.Text.Trim) Then
                CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "申請類別為「子女教育補助費」，「申請學期」欄位為必填。")
                Return
            ElseIf Not CommonFun.IsNum(txtSemeter.Text.Trim) Then
                CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "「申請學期」請輸入數字。")
                Return
            End If
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
            If (bll.getUpdateData(AcademicYear, Semester, Apply_sDate, Apply_sTime, Apply_eDate, Apply_eTime, _
                                  Status, ModUser_id, orgcode, id)) = True Then
                CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "「修改成功」", "SAL4106_01.aspx")
            End If
        Catch ex As Exception
            CommonFun.MsgShow(Me.Page, CommonFun.Msg.SystemError)
            AppException.WriteErrorLog(ex.StackTrace, ex.Message)
        End Try

    End Sub

    Protected Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Response.Redirect("SAL4106_01.aspx")
    End Sub
End Class
