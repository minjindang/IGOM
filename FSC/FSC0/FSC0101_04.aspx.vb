Imports FSCPLM.Logic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections.Generic
Imports CommonLib

Partial Class FSC0101_04
    Inherits BaseWebForm

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then
            Return
        End If
        Bind()

        Dim imDAO As New InventoryMain()
        Dim msg As String = imDAO.GetMemoMsg(LoginManager.OrgCode)
        If Not String.IsNullOrEmpty(msg) Then
            CommonFun.MsgShow(Page, CommonFun.Msg.Custom, msg)
            gv.Enabled = False
            cbConfirm.Enabled = False
            cbRest.Enabled = False
        End If
    End Sub

    Protected Sub Bind()
        Dim flowId As String = Request.QueryString("fid")
        Dim Orgcode As String = Request.QueryString("org")
        Dim bll As New FSC.Logic.FSC0101()

        gv.DataSource = bll.GetApplyMaterialData(Orgcode, flowId)
        gv.DataBind()


        If LoginManager.RoleId.IndexOf("TackleAdmin") < 0 Then
            gv.Enabled = False
            cbConfirm.Visible = False
            cbRest.Visible = False
        End If

        UcFlowDetail.Orgcode = Orgcode
        UcFlowDetail.FlowId = flowId

    End Sub

    Protected Sub cbBack_Click(sender As Object, e As EventArgs)
        If ViewState("BackUrl") IsNot Nothing Then
            Response.Redirect(ViewState("BackUrl"))
        End If
    End Sub

    Protected Sub cbConfirm_Click(sender As Object, e As EventArgs)
        Dim flowId As String = Request.QueryString("fid")
        Dim Orgcode As String = Request.QueryString("org")
        Dim bll As New FSC.Logic.FSC0101()
        Dim detList As New List(Of String())
        Dim err As New StringBuilder()

        For Each gvr As GridViewRow In gv.Rows
            Dim Material_name As String = CType(gvr.FindControl("gvlbMaterial_name"), Label).Text
            Dim gvlbMaterial_id As String = CType(gvr.FindControl("gvlbMaterial_id"), Label).Text
            Dim detOrgcode As String = CType(gvr.FindControl("gvlbOrgcode"), Label).Text
            Dim detFlowId As String = CType(gvr.FindControl("gvlbFlow_id"), Label).Text
            Dim applyCnt As String = CType(gvr.FindControl("gvlbApply_cnt"), Label).Text
            Dim outCnt As String = CType(gvr.FindControl("gvtbOut_cnt"), TextBox).Text.Trim()
            If Convert.ToInt16(applyCnt) < Convert.ToInt16(outCnt) Then
                err.Append(String.Format("{0} 領用數量需小於等於申請數量 。\n", Material_name))
            End If

            detList.Add(New String() {detOrgcode, detFlowId, outCnt, gvlbMaterial_id, applyCnt})
        Next

        If Not String.IsNullOrEmpty(err.ToString()) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, err.ToString())
            Return
        End If

        Try
            bll.ConfirmApplyMaterialData(Orgcode, flowId, detList)

            SendNotice.sendAll(Orgcode, flowId)
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "確認成功!", "FSC0101_02.aspx")
        Catch ex As Exception
            CommonFun.MsgShow(Me, CommonFun.Msg.SystemError)
        End Try
    End Sub
End Class
