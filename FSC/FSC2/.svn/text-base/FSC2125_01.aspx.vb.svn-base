Imports FSC.Logic
Imports System.Data
Imports System.Collections.Generic
Imports System.Transactions

Partial Class FSC2125_01
    Inherits BaseWebForm

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack() Then
            Return
        End If
        InitControl()
    End Sub

#Region "下拉式選單"
    Protected Sub InitControl()
        Depart_Bind()
        UserName_Bind()
        Year_Bind()
        Month_Bind()
    End Sub

    Protected Sub Depart_Bind()
        UcDDLDepart.Orgcode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
    End Sub

    Protected Sub UcDDLDepart_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles UcDDLDepart.SelectedIndexChanged
        UserName_Bind()
    End Sub

    Private Sub UserName_Bind()
        UcDDLMember.Orgcode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        UcDDLMember.Depart_id = UcDDLDepart.SelectedValue
    End Sub

    Private Sub Year_Bind()
        For i As Integer = 103 To Now.Year - 1911
            ddlYear.Items.Add(i)
        Next
    End Sub

    Protected Sub ddlYear_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlYear.SelectedIndexChanged
        Month_Bind()
    End Sub

    Private Sub Month_Bind()
        If ddlYear.SelectedValue = Now.Year - 1911 Then
            For i As Integer = 1 To Now.Month - 1
                ddlMonth.Items.Add(New ListItem(i.ToString().PadLeft(2, "0"), i.ToString().PadLeft(2, "0")))
            Next
            ddlMonth.SelectedValue = (Now.Month - 1).ToString().PadLeft(2, "0")
        Else
            For i As Integer = 1 To 12
                ddlMonth.Items.Add(New ListItem(i.ToString().PadLeft(2, "0"), i.ToString().PadLeft(2, "0")))
            Next
        End If
    End Sub
#End Region

    Protected Sub btnQuery_Click(sender As Object, e As EventArgs) Handles btnQuery.Click
        Bind()
    End Sub

    Protected Sub Bind()
        Dim orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim depart_id As String = UcDDLDepart.SelectedValue
        Dim id_card As String = UcDDLMember.SelectedValue
        Dim yyymm As String = ddlYear.SelectedValue & ddlMonth.SelectedValue
        Dim bll As New FSC2125()
        Dim dt As DataTable = New DataTable

        Try
            dt = bll.GetData(orgcode, depart_id, id_card, yyymm)

            ViewState("dt") = dt
            Me.gvlist.DataSource = dt
            Me.gvlist.DataBind()

            If gvlist.Rows.Count > 0 Then
                Ucpager.Visible = True
                btnExcel.Enabled = True
            Else
                Ucpager.Visible = False
                btnExcel.Enabled = False
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

    Protected Sub gvlist_RowCreated(sender As Object, e As GridViewRowEventArgs) Handles gvlist.RowCreated
        If e.Row.RowType = DataControlRowType.Footer Then
            Dim footer As TableCellCollection = e.Row.Cells
            footer.Clear()

            Dim tc1 As New TableCell()
            tc1.Text = "合計"
            tc1.ColumnSpan = 5
            tc1.HorizontalAlign = HorizontalAlign.Right
            tc1.CssClass = "Row"
            footer.Add(tc1)

            Dim tc2 As New TableCell()
            tc2.CssClass = "Row"
            footer.Add(tc2)
            Dim tc3 As New TableCell()
            tc3.CssClass = "Row"
            footer.Add(tc3)
            Dim tc4 As New TableCell()
            tc4.CssClass = "Row"
            footer.Add(tc4)
            Dim tc5 As New TableCell()
            tc5.CssClass = "Row"
            footer.Add(tc5)
            Dim tc6 As New TableCell()
            tc6.CssClass = "Row"
            footer.Add(tc6)
        End If
    End Sub

    Protected Sub gvlist_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles gvlist.RowDataBound
        If gvlist.Rows.Count <= 0 Then
            Exit Sub
        End If

        Dim total_Leave_hours As Integer = 0
        Dim total_PRADDH As Integer = 0
        Dim total_PRPAYH As Integer = 0
        Dim total_PRMNYH As Integer = 0
        Dim total_PRPAYFEE As Integer = 0

        For Each gvr As GridViewRow In gvlist.Rows
            total_Leave_hours += IIf(String.IsNullOrEmpty(CType(gvr.FindControl("lbLeave_hours"), Label).Text), 0, CommonFun.getDouble(CType(gvr.FindControl("lbLeave_hours"), Label).Text))
            total_PRADDH += IIf(String.IsNullOrEmpty(CType(gvr.FindControl("lbPRADDH"), Label).Text), 0, CommonFun.getDouble(CType(gvr.FindControl("lbPRADDH"), Label).Text))
            total_PRPAYH += IIf(String.IsNullOrEmpty(CType(gvr.FindControl("lbPRPAYH"), Label).Text), 0, CommonFun.getDouble(CType(gvr.FindControl("lbPRPAYH"), Label).Text))
            total_PRMNYH += IIf(String.IsNullOrEmpty(CType(gvr.FindControl("lbPRMNYH"), Label).Text), 0, CommonFun.getDouble(CType(gvr.FindControl("lbPRMNYH"), Label).Text))
            total_PRPAYFEE += IIf(String.IsNullOrEmpty(CType(gvr.FindControl("lbPRPAYFEE"), Label).Text), 0, CommonFun.getDouble(CType(gvr.FindControl("lbPRPAYFEE"), Label).Text))
        Next

        If Not Me.gvlist.FooterRow Is Nothing Then
            gvlist.FooterRow.Cells(1).Text = total_Leave_hours
            gvlist.FooterRow.Cells(2).Text = total_PRADDH
            gvlist.FooterRow.Cells(3).Text = total_PRPAYH
            gvlist.FooterRow.Cells(4).Text = total_PRMNYH
            gvlist.FooterRow.Cells(5).Text = total_PRPAYFEE
        End If
    End Sub

    Protected Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click
        If ViewState("dt") Is Nothing Then
            Bind()
        End If
        Dim dt As DataTable = CType(ViewState("dt"), DataTable)

        If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
            CommonFun.MsgShow(Me, CommonFun.Msg.QueryNothing)
        Else
            Dim theDTReport As CommonLib.DTReport
            Dim total_Leave_hours As Integer = 0
            Dim total_PRADDH As Integer = 0
            Dim total_PRPAYH As Integer = 0
            Dim total_PRMNYH As Integer = 0
            Dim total_PRPAYFEE As Integer = 0

            For Each dr As DataRow In dt.Rows
                total_Leave_hours += IIf(String.IsNullOrEmpty(dr("Leave_hours").ToString), 0, CommonFun.getDouble(dr("Leave_hours").ToString))
                total_PRADDH += IIf(String.IsNullOrEmpty(dr("PRADDH").ToString), 0, CommonFun.getDouble(dr("PRADDH").ToString))
                total_PRPAYH += IIf(String.IsNullOrEmpty(dr("PRPAYH").ToString), 0, CommonFun.getDouble(dr("PRPAYH").ToString))
                total_PRMNYH += IIf(String.IsNullOrEmpty(dr("PRMNYH").ToString), 0, CommonFun.getDouble(dr("PRMNYH").ToString))
                total_PRPAYFEE += IIf(String.IsNullOrEmpty(dr("PRPAYFEE").ToString), 0, CommonFun.getDouble(dr("PRPAYFEE").ToString))
            Next

            Dim param(4) As String
            param(0) = total_Leave_hours
            param(1) = total_PRADDH
            param(2) = total_PRPAYH
            param(3) = total_PRMNYH
            param(4) = total_PRPAYFEE

            theDTReport = New CommonLib.DTReport(Server.MapPath("../../Report/FSC/FSC2125_01.mht"), dt)
            theDTReport.Param = param
            theDTReport.ExportFileName = "每月加班費請領統計"
            theDTReport.ExportToExcel()

            dt.Dispose()
        End If
    End Sub
End Class
