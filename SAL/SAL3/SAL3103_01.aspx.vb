Imports System.Data
Imports SAL.Logic
Imports System.Transactions
Imports System.IO

Partial Class SAL3103_01
    Inherits BaseWebForm

    Protected Sub Page_Load1(sender As Object, e As EventArgs) Handles Me.Load
        If IsPostBack Then Return

        ddl_Bind()
    End Sub

    Protected Sub ddl_Bind()
        Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        DropDownList_Code.DataSource = New SAL3103().getList_Code(Orgcode, DropDownList_Operation.SelectedValue)
        DropDownList_Code.DataBind()

        DropDownList_Code.Items.Insert(0, New ListItem("---全部---", ""))
    End Sub

    Protected Sub DropDownList_Operation_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownList_Operation.SelectedIndexChanged
        ddl_Bind()
    End Sub

    Protected Sub btnQuery_Click(sender As Object, e As EventArgs) Handles btnQuery.Click
        Bind()
    End Sub

    Protected Sub Bind()
        Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)

        Dim dt As DataTable = New SAL3103().getData(Orgcode, DropDownList_Operation.SelectedValue, DropDownList_Code.SelectedValue, IIf(cbSuspend.Checked, "Y", "N"))
        gvList.DataSource = dt
        gvList.DataBind()

        dataList.Visible = True
        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            Ucpager1.Visible = True
        Else
            Ucpager1.Visible = False
        End If
    End Sub

    Protected Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        Response.Redirect("SAL3103_02.aspx?act=2")
    End Sub

    Protected Sub btnDeleteBatch_Click(sender As Object, e As EventArgs)
        Dim gvr As GridViewRow = CType(sender, Button).NamingContainer
        Dim v_orgid As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim item_code As String = CType(gvr.FindControl("Label_item_code"), Label).Text
        Dim item_codeName As String = CType(gvr.FindControl("Label_item_name"), Label).Text

        Try
            Dim SAL3103 As SAL3103 = New SAL3103
            SAL3103.delete(v_orgid, item_code)

            CommonFun.MsgShow(Me, CommonFun.Msg.DeleteOK)
            Bind()
        Catch ex As Exception
            CommonFun.MsgShow(Me, CommonFun.Msg.SystemError)
            AppException.WriteErrorLog(ex.StackTrace, ex.Message)
        End Try
    End Sub

    Protected Sub btnUpdate_Click(sender As Object, e As EventArgs)
        Dim gvr As GridViewRow = CType(sender, Button).NamingContainer
        Dim Label_item_code As Label = CType(gvr.FindControl("Label_item_code"), Label)

        Response.Redirect("SAL3103_02.aspx?act=1&code=" & Label_item_code.Text)
    End Sub

    Protected Sub gvList_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvList.PageIndexChanging
        Me.gvList.PageIndex = e.NewPageIndex
        Bind()
    End Sub

    Protected Sub btnDel_Click(sender As Object, e As EventArgs)
        Dim gvr As GridViewRow = CType(sender, Button).NamingContainer
        Dim Label_item_code As Label = CType(gvr.FindControl("Label_item_code"), Label)

        Dim SAL3103 As New SAL3103
        Try
            SAL3103.deleteSuspend(LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode), Label_item_code.Text)
            CommonFun.MsgShow(Me, CommonFun.Msg.DeleteOK)
            Bind()
        Catch ex As Exception
            CommonFun.MsgShow(Me, CommonFun.Msg.SystemError)
            AppException.WriteErrorLog(ex.StackTrace, ex.Message)
        End Try
    End Sub
End Class
