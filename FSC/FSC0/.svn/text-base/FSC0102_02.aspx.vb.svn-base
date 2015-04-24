Imports System.Data
Imports System.Transactions
Imports FSCPLM.Logic
Imports CommonLib
Imports System.Collections.Generic

Partial Class FSC0102_02
    Inherits BaseWebForm

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then
            Return
        End If

        Bind()
    End Sub

    Protected Sub Bind()
        Dim orgcode As String = Request.QueryString("org")
        Dim flowId As String = Request.QueryString("fid")
        Dim bll As New FSC.Logic.FSC0101()

        Dim dt As DataTable = bll.GetMergedData(orgcode, flowId)
        ViewState("DataTable") = dt
        gv.DataSource = dt
        gv.DataBind()
    End Sub

    Protected Sub cbBack_Click(sender As Object, e As EventArgs)
        Response.Redirect("FSC0102_01.aspx")
    End Sub

    Protected Sub gvcbUpdate_Click(sender As Object, e As EventArgs)
        Dim gvr As GridViewRow = CType(sender, Button).NamingContainer
        Dim orgcode As String = CType(gvr.FindControl("gvhfOrgcode"), HiddenField).Value
        Dim flowId As String = CType(gvr.FindControl("gvlbFlowId"), Label).Text
        Dim formId As String = CType(gvr.FindControl("gvhfFormId"), HiddenField).Value

        Dim k As String = formId.Substring(0, 3)
        Dim t As String = formId.Substring(3)
        Dim code As New FSCPLM.Logic.SACode()
        Dim r As DataRow = code.GetRow("024", k, t)
        Dim url As String = r("CODE_REMARK2").ToString()

        If Not String.IsNullOrEmpty(url) Then
            Response.Redirect(url & "?org=" & orgcode & "&fid=" & flowId)
        End If
    End Sub

    Protected Sub gvUcAttachUploadButton_FileUploaded(sender As Object, e As EventArgs)
        Bind()
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