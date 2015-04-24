Imports System.Data
Imports System.Transactions
Imports FSCPLM.Logic
Imports CommonLib
Imports System.Collections.Generic

Partial Class FSC0104_01
    Inherits BaseWebForm

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then
            Return
        End If

        InitBind()
    End Sub

    Protected Sub InitBind()
        Dim code As New SACode()
        UcDDLDepart.Orgcode = LoginManager.OrgCode
        UcDDLForm.Orgcode = LoginManager.OrgCode

        Try
            If Session("FSC0104_01_Q") IsNot Nothing Then
                Dim q() As String = Session("FSC0104_01_Q").ToString().Split(",")
                UcDDLDepart.SelectedValue = q(0)
                UcDDLMember.SelectedValue = q(1)
                UcDateS.Text = q(2)
                UcDateE.Text = q(3)
                UcDDLForm.SelectedValue = q(4)
                BindMember()
                Session("FSC0104_01_Q") = Nothing
                Bind()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub UcDDLDepart_SelectedIndexChanged(sender As Object, e As EventArgs)
        BindMember()
    End Sub

    Protected Sub BindMember()
        UcDDLMember.Orgcode = LoginManager.OrgCode
        UcDDLMember.DepartId = UcDDLDepart.SelectedValue
    End Sub

    Protected Sub cbBack_Click(sender As Object, e As EventArgs)
        Session("FSC0104_01_Q") = Nothing
        Response.Redirect("FSC0101_01.aspx")
    End Sub

    Protected Sub cbQuery_Click(sender As Object, e As EventArgs)
        Bind()
    End Sub

    Protected Sub Bind()
        Dim orgcode As String = LoginManager.OrgCode
        Dim departId As String = LoginManager.Depart_id
        Dim idCard As String = LoginManager.UserId
        Dim replaceOrgcode As String = LoginManager.OrgCode
        Dim replaceDepartid As String = UcDDLDepart.SelectedValue
        Dim replaceIdcard As String = UcDDLMember.SelectedValue

        Dim bll As New FSC.Logic.FSC0101()
        Dim code As New SACode()

        Dim dates As String = UcDateS.Text
        Dim datee As String = UcDateE.Text
        Dim formId As String = UcDDLForm.SelectedValue

        Session("FSC0104_01_Q") = String.Join(",", New String() {departId, idCard, dates, datee, formId})

        Dim dt As DataTable = bll.GetHasFlowDetailReplaceData(orgcode, departId, idCard, replaceOrgcode, replaceDepartid, replaceIdcard, dates, datee, formId)
        ViewState("DataTable") = dt

        gv.DataSource = dt
        gv.DataBind()
    End Sub

    Protected Sub gv_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles gv.PageIndexChanging
        gv.PageIndex = e.NewPageIndex
        gv.DataSource = CType(ViewState("DataTable"), DataTable)
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