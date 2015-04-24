Imports FSCPLM.Logic
Imports System.Data

Partial Class MAI_MAI1_MAI1103_01
    Inherits BaseWebForm

    Dim dao As New MAI1103

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

    End Sub

    Protected Sub DoneBtn_Click(sender As Object, e As EventArgs) Handles DoneButton.Click
        BindGV()
    End Sub

    Protected Sub btnCheckAll_Click(sender As Object, e As EventArgs) Handles btnCheckAll.Click
        ucMtClass_type.CheckAll(True)
    End Sub

    Protected Sub btnUnCheckAll_Click(sender As Object, e As EventArgs) Handles btnUnCheckAll.Click
        ucMtClass_type.CheckAll(False)
    End Sub

    Private Sub BindGV()
        Dim dt As DataTable = dao.GetAll(ucMtClass_type.SelectedValue, Me.ucApplyTimeS.Text, ucApplyTimeE.Text, txtPhone_nos.Text, _
                                         ddlUnit_code.SelectedValue, txtUser_id.Text, ucMtStatus_type.SelectedValue, ucServApply_type.SelectedValue, LoginManager.OrgCode)
        div1.Visible = Not dt Is Nothing AndAlso dt.Rows.Count > 0

        Me.GridViewA.DataSource = dt
        Me.GridViewA.DataBind()
        ViewState("DataTable") = dt '將資料暫存起來，做為資料的跳頁等顯示
        dt.Dispose()
    End Sub

    Protected Sub GridViewA_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GridViewA.PageIndexChanging
        Me.GridViewA.PageIndex = e.NewPageIndex
        Me.GridViewA.DataSource = CType(ViewState("DataTable"), DataTable)
        Me.GridViewA.DataBind()
    End Sub

    Protected Sub GridViewA_RowCommand(sender As Object, e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridViewA.RowCommand

        Dim SwMaintain_code As String = e.CommandArgument

        If e.CommandName = "RepeatApply" Then
            dao.UpdateRepeatApply_type(SwMaintain_code, "Y")
        ElseIf e.CommandName = "ServConfirm_type" Then
            dao.UpdateServConfirm_type(SwMaintain_code, "004")
        End If 

    End Sub


    Protected Sub ClrButton_Click(sender As Object, e As EventArgs) Handles ClrButton.Click
        CommonFun.ClearContentPlaceHolder(Master)
    End Sub

    Protected Sub GridViewA_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridViewA.RowDataBound

        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim hfRepeatApply_type As HiddenField = e.Row.FindControl("hfRepeatApply_type")
            Dim hfServConfirm_type As HiddenField = e.Row.FindControl("hfServConfirm_type")
            Dim btn1 As Button = e.Row.FindControl("btn1")
            Dim btn2 As Button = e.Row.FindControl("btn2")
           
            btn1.Enabled = hfRepeatApply_type.Value <> "Y"
            btn2.Enabled = hfServConfirm_type.Value <> "004"
        End If

    End Sub
End Class
