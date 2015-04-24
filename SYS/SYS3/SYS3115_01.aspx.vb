Imports System.Data
Imports System.Transactions
Imports FSCPLM.Logic
Imports CommonLib
Imports System.Collections.Generic
Imports SYS.Logic

Partial Class SYS3115_01
    Inherits BaseWebForm

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then
            Return
        End If

        UcDDLDepart.Orgcode = LoginManager.OrgCode
        UcDDLForm.Orgcode = LoginManager.OrgCode
        Bind()
    End Sub

    Protected Sub Bind()
        Dim nextOrgcode As String = LoginManager.OrgCode
        Dim nextIdcard As String = UcDDLMember.SelectedValue
        Dim nextDepartId As String = UcDDLDepart.SelectedValue
        Dim bll As New FSC.Logic.FSC0101()

        Dim formId As String = UcDDLForm.SelectedValue
        Dim dt As New DataTable()
        Dim psn As New FSC.Logic.Personnel()

        dt = bll.GetNextData(formId, "", "", nextOrgcode, nextDepartId, nextIdcard)
        tbQ.Visible = True
        gv.DataSource = dt
        gv.DataBind()
    End Sub

    Protected Sub UcDDLDepart_SelectedIndexChanged(sender As Object, e As EventArgs)
        UcDDLMember.Orgcode = LoginManager.OrgCode
        UcDDLMember.DepartId = UcDDLDepart.SelectedValue
    End Sub

    Protected Sub btnConfirm_Click(sender As Object, e As EventArgs)
        If String.IsNullOrEmpty(UcDDLMember.SelectedValue) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "請選擇簽核人員!")
            Return
        End If
        Bind()
    End Sub

    Protected Sub gv_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles gv.DataBound
        tbQ.Visible = IIf(gv.Rows.Count > 0, True, False)
        UcCustomNext.Visible = IIf(gv.Rows.Count > 0, True, False)
    End Sub

    Protected Sub UcCustomNext_Click(sender As Object, e As EventArgs)
        Dim fn As New FlowNext()

        Using scope As New TransactionScope
            For Each gvr As GridViewRow In gv.Rows
                Dim id As String = CType(gvr.FindControl("gvhfId"), HiddenField).Value

                If Not fn.UpdateNextById(id, UcCustomNext.NextOrgcode, UcCustomNext.NextDepartid, UcCustomNext.NextIdcard, UcCustomNext.NextPosid, UcCustomNext.NextName) Then
                    CommonFun.MsgShow(Me, CommonFun.Msg.UpdateFail)
                    Exit Sub
                End If
            Next
            scope.Complete()
        End Using

        CommonFun.MsgShow(Me, CommonFun.Msg.UpdateOK)
        Bind()
    End Sub

End Class