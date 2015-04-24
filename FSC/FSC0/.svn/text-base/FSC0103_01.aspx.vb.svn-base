Imports System.Data
Imports System.Transactions
Imports FSCPLM.Logic
Imports CommonLib
Imports System.Collections.Generic

Partial Class FSC0103_01
    Inherits BaseWebForm

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then
            Return
        End If

        InitBind()
    End Sub


    Protected Sub InitBind()
        Dim code As New SACode()
        UcDDLForm.Orgcode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)

        Try
            If Session("FSC0103_01_Q") IsNot Nothing Then
                Dim q() As String = Session("FSC0103_01_Q").ToString().Split(",")
                UcDateS.Text = q(0)
                UcDateE.Text = q(1)
                UcDDLForm.SelectedValue = q(2)
                Session("FSC0103_01_Q") = Nothing
                Bind()
            End If
        Catch ex As Exception

        End Try

        UcDateS.Text = DateTimeInfo.GetRocDate(Now.AddDays(-6))
        UcDateE.Text = DateTimeInfo.GetRocTodayString("yyyyMMdd")
    End Sub

    Protected Sub cbBack_Click(sender As Object, e As EventArgs)
        Session("FSC0103_01_Q") = Nothing
        Response.Redirect("FSC0101_01.aspx")
    End Sub

    Protected Sub cbQuery_Click(sender As Object, e As EventArgs)
        Bind()
    End Sub

    Protected Sub Bind()
        Dim orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim departId As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id)
        Dim idCard As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card)
        Dim bll As New FSC.Logic.FSC0101()
        Dim code As New SACode()

        Dim dates As String = UcDateS.Text
        Dim datee As String = UcDateE.Text
        Dim formId As String = UcDDLForm.SelectedValue

        Session("FSC0102_01_Q") = String.Join(",", New String() {dates, datee, formId})

        Dim dt As DataTable = bll.GetHasFlowDetailData(orgcode, departId, idCard, dates, datee, formId)
        ViewState("DataTable") = dt
        gv.DataSource = dt
        gv.DataBind()
    End Sub

    Protected Sub gv_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gv.PageIndexChanging
        gv.PageIndex = e.NewPageIndex
        Dim dt As DataTable = ViewState("DataTable")
        gv.DataSource = dt
        gv.DataBind()
    End Sub

    Protected Sub gv_Sorting(sender As Object, e As GridViewSortEventArgs)
        Dim SortExpression As String = e.SortExpression
        Dim SortDirection As String = e.SortDirection.ToString.ToUpper()

        If ViewState("SortDirection") Is Nothing OrElse ViewState("SortDirection") Is Nothing Then
            initSort(SortExpression)
        Else
            If ViewState("SortExpression").ToString() = SortExpression Then
                If ViewState("SortDirection").ToString() = "ASCENDING" Then
                    ViewState("SortDirection") = "DESCENDING"
                    Bind(SortExpression + " DESC")
                Else
                    initSort(SortExpression)
                End If
            Else
                initSort(SortExpression)
            End If
        End If
    End Sub

    Protected Sub initSort(ByVal SortExpression As String)
        ViewState("SortDirection") = "ASCENDING"
        ViewState("SortExpression") = SortExpression
        Bind(SortExpression + " ASC")
    End Sub

    Protected Sub Bind(ByVal sort As String)
        Dim dv As DataView = CType(ViewState("DataTable"), DataTable).DefaultView
        dv.Sort = sort
        ViewState("DataTable") = dv.ToTable()
        gv.DataSource = CType(ViewState("DataTable"), DataTable)
        gv.DataBind()
    End Sub
End Class