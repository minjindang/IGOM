Imports System.Data
Imports System.Collections.Generic
Imports FSCPLM.Logic
Imports SYS.Logic
Imports System.Transactions

Partial Class SYS3108_07
    Inherits BaseWebForm

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack Then
            Return
        End If

        UcDDLDepart.Orgcode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        UcDDLForm.Orgcode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        BindMember()

        Session.Remove("FlowOutpostMasterList")
        Session.Remove("FlowOutpostFormList")

        Try
            If Session("QueryCondition") IsNot Nothing Then
                Dim q() As String = Session("QueryCondition").ToString().Split(",")
                UcDDLDepart.SelectedValue = q(0)
                UcDDLMember.SelectedValue = q(1)
                UcDDLForm.SelectedValue = q(2)
                QueryBind()
            End If
        Catch ex As Exception

        End Try
        Session.Remove("QueryCondition")
    End Sub

#Region "下拉式選單"
    Protected Sub BindMember()
        UcDDLMember.Orgcode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        UcDDLMember.DepartId = UcDDLDepart.SelectedValue
    End Sub

    Protected Sub UcDDLDepart_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles UcDDLDepart.SelectedIndexChanged
        BindMember()
    End Sub
#End Region

    Protected Sub btnConfirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConfirm.Click
        If String.IsNullOrEmpty(UcDDLMember.SelectedValue) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "請選擇簽核人員!")
            Return
        End If
        QueryBind()
    End Sub

    Protected Sub QueryBind()
        Dim orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim departId As String = UcDDLDepart.SelectedValue
        Dim idCard As String = UcDDLMember.SelectedValue
        Dim formId As String = UcDDLForm.SelectedValue

        Dim dt As DataTable = New SYS.Logic.SYS3108().GetData3(Orgcode, departId, idCard, formId)
        gv.DataSource = dt
        gv.DataBind()

    End Sub

    Protected Sub gv_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles gv.DataBound
        tbQ.Visible = IIf(gv.Rows.Count > 0, True, False)
        UcCustomNext.Visible = IIf(gv.Rows.Count > 0, True, False)
    End Sub

    Protected Sub gv_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gv.PageIndexChanging
        gv.PageIndex = e.NewPageIndex
        QueryBind()
    End Sub

    Protected Sub gv_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gv.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            CType(e.Row.FindControl("gv_lbno"), Label).Text = e.Row.DataItemIndex + 1
        End If
    End Sub


    Protected Sub SetQueryCondition()
        Dim departId As String = UcDDLDepart.SelectedValue
        Dim idCard As String = UcDDLMember.SelectedValue
        Dim formId As String = UcDDLForm.SelectedValue
        Session("QueryCondition") = CommonFun.CombineString(New String() {departId, idCard, formId}, ",")
    End Sub

    Protected Sub UcCustomNext_Click(sender As Object, e As EventArgs)
        Dim fom As New FlowOutpostMaster()

        Using scope As New TransactionScope
            For Each gvr As GridViewRow In gv.Rows
                Dim id As String = CType(gvr.FindControl("gv_hfMasterId"), HiddenField).Value

                If Not fom.UpdateDataById(id, UcCustomNext.NextIdcard, UcCustomNext.NextOrgcode, UcCustomNext.NextDepartid, UcCustomNext.NextPosid) Then
                    CommonFun.MsgShow(Me, CommonFun.Msg.UpdateFail)
                    Exit Sub
                End If
            Next
            scope.Complete()
        End Using

        CommonFun.MsgShow(Me, CommonFun.Msg.UpdateOK)
        QueryBind()
    End Sub
End Class
