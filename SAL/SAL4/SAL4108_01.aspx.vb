Imports FSC.Logic
Imports SAL.Logic
Imports System.Data
Imports System.Collections.Generic
Imports Excel = Microsoft.Office.Interop.Excel

Partial Class SAL4108_01
    Inherits BaseWebForm
    Dim orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode) '機構代碼
    Dim dtData As DataTable
    Dim bll As New SAL4108()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack() Then
            Return
        End If

        ' 繫結【種類】
        dtData = New FSCPLM.Logic.SACode().GetData("001", "001")
        ddlApply_type.DataTextField = "code_desc1"
        ddlApply_type.DataValueField = "code_no"
        ddlApply_type.DataSource = dtData
        ddlApply_type.DataBind()

        ' 繫結【實施日期】
        dtData = bll.getQueryData("001", "001")
        ddlYM.DataTextField = "ymstr"
        ddlYM.DataValueField = "stan_ym"
        ddlYM.DataSource = dtData
        ddlYM.DataBind()

    End Sub

    ''' <summary>
    ''' 【查詢】按鈕
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub btnQuery_Click(sender As Object, e As EventArgs) Handles btnQuery.Click
        Dim stan_ym As String = ddlYM.SelectedValue
        Dim stan_type As String = "001"
        Dim stan_no As String = ddlApply_type.SelectedValue

        Try
            dtData = bll.getQueryData(stan_ym, stan_type, stan_no)

            tbq.Visible = True
            ViewState("dt") = dtData
            Me.gvlist.DataSource = dtData
            Me.gvlist.DataBind()
            dtData.Dispose()

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

    Protected Sub gvList_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvlist.PageIndexChanging
        Me.gvlist.PageIndex = e.NewPageIndex
        Me.gvlist.DataSource = CType(ViewState("dt"), DataTable)
        Me.gvlist.DataBind()
    End Sub

    ''' <summary>
    ''' 【新增】按鈕
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        Response.Redirect("SAL4108_02.aspx")
    End Sub

    ''' <summary>
    ''' 【修改】按鈕
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub btnModify_Click(sender As Object, e As EventArgs)
        Dim gvr As GridViewRow = CType(sender, Button).NamingContainer
        Dim STAN_YM As String = CType(gvr.FindControl("STAN_YM"), Label).Text
        Dim STAN_TYPE As String = CType(gvr.FindControl("STAN_TYPE"), Label).Text
        Dim STAN_NO As String = CType(gvr.FindControl("STAN_NO"), Label).Text
        Dim Stan_Sal_Point As String = CType(gvr.FindControl("Stan_Sal_Point"), Label).Text
        Response.Redirect("SAL4108_03.aspx?STAN_YM=" & STAN_YM & "&STAN_TYPE=" & STAN_TYPE & "&STAN_NO=" & STAN_NO & "&Stan_Sal_Point=" & Stan_Sal_Point)
    End Sub

    ''' <summary>
    ''' 【刪除】按鈕
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub btnDelete_Click(sender As Object, e As EventArgs)
        Dim gvr As GridViewRow = CType(sender, Button).NamingContainer
        'Dim gvr As GridViewRow = CType(sender, Button).NamingContainer
        Dim STAN_YM As String = CType(gvr.FindControl("STAN_YM"), Label).Text
        Dim STAN_TYPE As String = CType(gvr.FindControl("STAN_TYPE"), Label).Text
        Dim STAN_NO As String = CType(gvr.FindControl("STAN_NO"), Label).Text
        Dim Stan_Sal_Point As String = CType(gvr.FindControl("Stan_Sal_Point"), Label).Text

        If (bll.Delete(STAN_YM, STAN_TYPE, STAN_NO, Stan_Sal_Point)) = True Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "「刪除成功」", "SAL4108_01.aspx")
        End If
    End Sub

    Protected Sub gvlist_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles gvlist.RowDataBound
        'For Each gvr As GridViewRow In gvlist.Rows
        '    Dim btnDelete As Button = CType(gvr.FindControl("btnDelete"), Button)
        '    Dim id As String = CType(gvr.FindControl("lbid"), Label).Text
        '    Dim Apply_type As String = CType(gvr.FindControl("lbApply_type"), Label).Text
        '    'Select Case Apply_type
        '    '    Case "子女教育補助費"
        '    '        Apply_type = "001"
        '    '    Case "勞 健公 健保繳納證明申請"
        '    '        Apply_type = "002"
        '    '    Case "未休假加班費申請"
        '    '        Apply_type = "003"
        '    'End Select
        '    Dim dt As DataTable = New DataTable
        '    Dim bll As New SAL4106()
        '    dt = bll.getDeleteSelectData(Apply_type, id)
        '    btnDelete.Attributes.Add("onclick", "if(!confirm('" + "刪除後，開放申請時間會變為" + DateTimeInfo.ToDisplay(dt.Rows(0)("Apply_sDate").ToString) + _
        '                              DateTimeInfo.ToDisplayTime(dt.Rows(0)("Apply_sTime").ToString) + " 至 " + _
        '                              DateTimeInfo.ToDisplay(dt.Rows(0)("Apply_eDate").ToString) + DateTimeInfo.ToDisplayTime(dt.Rows(0)("Apply_eTime").ToString) + _
        '                             "\n確定刪除？'))return false;")
        'Next
    End Sub

End Class
