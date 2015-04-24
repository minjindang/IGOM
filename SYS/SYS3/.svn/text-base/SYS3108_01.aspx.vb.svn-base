Imports System.Data
Imports System.Collections.Generic
Imports FSCPLM.Logic
Imports SYS.Logic
Imports System.Transactions

Partial Class SYS3108_01
    Inherits BaseWebForm

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack Then
            Return
        End If

        UcDDLDepart.Orgcode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        UcDDLForm.Orgcode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        BindTitle()
        BindMember()
        BindEmpType()

        Session.Remove("FlowOutpostMasterList")
        Session.Remove("FlowOutpostFormList")

        Try
            If Session("QueryCondition") IsNot Nothing Then
                Dim q() As String = Session("QueryCondition").ToString().Split(",")
                UcDDLDepart.SelectedValue = q(0)
                ddlTitleName.SelectedValue = q(1)
                UcDDLMember.SelectedValue = q(2)
                ddlEmpType.SelectedValue = q(3)
                UcDDLForm.SelectedValue = q(4)
                QueryBind()
            End If
        Catch ex As Exception

        End Try
        Session.Remove("QueryCondition")
    End Sub

#Region "下拉式選單"

    Protected Sub BindTitle()
        Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim personnel As New FSC.Logic.Personnel()
        ddlTitleName.DataSource = personnel.GetTitleDataByOrgDep(Orgcode, UcDDLDepart.SelectedValue)
        ddlTitleName.DataBind()
        ddlTitleName.Items.Insert(0, New ListItem("請選擇", ""))
    End Sub

    Protected Sub BindMember()
        UcDDLMember.Orgcode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        UcDDLMember.DepartId = UcDDLDepart.SelectedValue
    End Sub

    Protected Sub BindEmpType()
        Dim saCode As New FSCPLM.Logic.SACode()
        Dim dt As DataTable = saCode.GetData2("023", "P", "022")
        ddlEmpType.DataSource = dt
        ddlEmpType.DataBind()
        ddlEmpType.Items.Insert(0, New ListItem("請選擇", ""))
    End Sub

    Protected Sub UcDDLDepart_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles UcDDLDepart.SelectedIndexChanged
        BindTitle()
        BindMember()
    End Sub


#End Region

    Protected Sub btnConfirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConfirm.Click
        QueryBind()
    End Sub

    Protected Sub QueryBind()
        Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim targetType As New ArrayList
        Dim target As New ArrayList

        If Not "".Equals(ddlTitleName.SelectedValue) Then
            targetType.Add("1")
            target.Add(ddlTitleName.SelectedValue)
        End If
        If Not "".Equals(UcDDLMember.SelectedValue) Then
            targetType.Add("2")
            target.Add(UcDDLMember.SelectedValue)
        End If
        If Not "".Equals(ddlEmpType.SelectedValue) Then
            targetType.Add("3")
            target.Add(ddlEmpType.SelectedValue)
        End If

        Dim formId As String = UcDDLForm.SelectedValue

        Dim dt As DataTable = New SYS.Logic.SYS3108().GetDataByQuery(Orgcode, UcDDLDepart.SelectedValue, target.ToArray(Type.GetType("System.String")), targetType.ToArray(Type.GetType("System.String")), formId)
        gv.DataSource = dt
        gv.DataBind()
    End Sub

    Protected Sub gv_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles gv.DataBound
        tbQ.Visible = IIf(gv.Rows.Count > 0, True, False)
    End Sub

    Protected Sub gv_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gv.PageIndexChanging
        gv.PageIndex = e.NewPageIndex
        QueryBind()
    End Sub

    Protected Sub gv_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gv.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            CType(e.Row.FindControl("gv_lbno"), Label).Text = e.Row.DataItemIndex + 1

            Dim Orgcode As String = LoginManager.OrgCode
            Dim departId As String = UcDDLDepart.SelectedValue
            Dim fot As New FlowOutpostTarget()
            Dim fom As New FlowOutpostForm()
            Dim code As New SACode()

            Dim flowOutpostId As String = CType(e.Row.FindControl("gv_lbfopID"), Label).Text
            Dim formName As String = ""
            Dim targetName As String = ""

            Dim ffdt As DataTable = fom.GetFormIdByQuery(flowOutpostId, Orgcode, departId)
            For Each ffdr As DataRow In ffdt.Rows
                Dim codeType As String = ffdr("Form_id").Substring(0, 3)
                Dim codeNo As String = ffdr("Form_id").Substring(3)
                Dim desc As String = code.GetCodeDesc("024", codeType, codeNo)

                If Not "".Equals(formName) Then
                    formName &= "<br/>"
                End If
                formName &= desc
            Next

            CType(e.Row.FindControl("gv_lbLeaveGroup"), Label).Text = formName
            CType(e.Row.FindControl("gv_lbOutpostId"), Label).Text = Outpost.GetDisplayOutpost(Orgcode, "", "", flowOutpostId, True)

            '適用對像
            Dim fodt As DataTable = fot.GetTargetByQuery(flowOutpostId, Orgcode, departId)
            For Each fodr As DataRow In fodt.Rows

                '單位
                Dim depName As String = New FSC.Logic.Org().GetDepartName(fodr("Orgcode").ToString(), fodr("Depart_id").ToString())

                '適用人員
                If Not "".Equals(targetName) Then
                    targetName &= "<br/>"
                End If
                targetName &= depName & "/" & Outpost.GetTargetName(fodr("Target").ToString(), fodr("Target_type").ToString())
            Next

            CType(e.Row.FindControl("gv_lbTitleno"), Label).Text = targetName
        End If
    End Sub

    '刪除
    Protected Sub gv_cbDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim gvr As GridViewRow = CType(sender, Button).NamingContainer
        Dim flowOutpostId As String = CType(gvr.FindControl("gv_lbfopID"), Label).Text.Trim()
        'Dim departId As String = CType(gvr.FindControl("gv_lbDepart_id"), Label).Text.Trim()
        Dim orgcode As String = LoginManager.OrgCode

        Dim fot As New SYS.Logic.FlowOutpostTarget()
        Dim fom As New SYS.Logic.FlowOutpostMaster()
        Dim fof As New SYS.Logic.FlowOutpostForm()

        Using scope As New TransactionScope
            fot.DeleteFlowOutpostTarget(orgcode, "", flowOutpostId)
            Dim dt As DataTable = fot.GetDataByFlowOutpostID(flowOutpostId)
            If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
                fom.DeleteFlowOutpostMaster(flowOutpostId)
                fof.DeleteFlowOutpostForm(flowOutpostId)
            End If
            scope.Complete()
        End Using

        QueryBind()
    End Sub

    'step1 修改
    Protected Sub gv_cbStep1_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim gvr As GridViewRow = CType(sender, Button).NamingContainer
        Dim FlowOutpostID As String = CType(gvr.FindControl("gv_lbfopID"), Label).Text.Trim()
        Dim Depart_id As String = UcDDLDepart.SelectedValue
        SetQueryCondition()
        Response.Redirect("SYS3108_02.aspx?fopID=" & FlowOutpostID)
    End Sub

    'step2 設定時數條件
    Protected Sub gv_cbStep2_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim gvr As GridViewRow = CType(sender, Button).NamingContainer
        Dim FlowOutpostID As String = CType(gvr.FindControl("gv_lbfopID"), Label).Text.Trim()
        SetQueryCondition()
        Response.Redirect("SYS3108_03.aspx?fopID=" & FlowOutpostID)
    End Sub

    'step3 
    Protected Sub gv_cbStep3_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim gvr As GridViewRow = CType(sender, Button).NamingContainer
        Dim FlowOutpostID As String = CType(gvr.FindControl("gv_lbfopID"), Label).Text.Trim()
        Dim Depart_id As String = UcDDLDepart.SelectedValue
        SetQueryCondition()
        Response.Redirect("SYS3108_04.aspx?fopID=" & FlowOutpostID)
    End Sub

    Protected Sub SetQueryCondition()
        Dim departId As String = UcDDLDepart.SelectedValue
        Dim titleNo As String = ddlTitleName.SelectedValue
        Dim idCard As String = UcDDLMember.SelectedValue
        Dim employeeType As String = ddlEmpType.SelectedValue
        Dim formId As String = UcDDLForm.SelectedValue
        Session("QueryCondition") = CommonFun.CombineString(New String() {departId, titleNo, idCard, employeeType, formId}, ",")
    End Sub

    Protected Sub cbToAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbToAdd.Click
        Response.Redirect("SYS3108_02.aspx")
    End Sub

    Protected Sub cbQuery_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbQuery.Click
        Response.Redirect("SYS3108_05.aspx")
    End Sub


    Protected Sub gv_cbCopy_Click(sender As Object, e As EventArgs)
        Dim orgcode As String = LoginManager.OrgCode
        Dim gvr As GridViewRow = CType(sender, Button).NamingContainer
        Dim flowOutpostId As String = CType(gvr.FindControl("gv_lbfopID"), Label).Text.Trim()
        Dim changeUserid As String = LoginManager.UserId

        Dim fom As New FlowOutpostMaster()
        Dim fof As New FlowOutpostForm()
        Dim fot As New FlowOutpostTarget()

        Using trans As New Transactions.TransactionScope
            Dim fomdt As DataTable = fom.GetDataByFlowOutpostID(orgcode, flowOutpostId)
            Dim fofdt As DataTable = fof.GetFlowOutpostForm(flowOutpostId)
            Dim fotdt As DataTable = fot.GetDataByFlowOutpostID(flowOutpostId)

            Dim newFlowOutpostId As String = fom.GetFlowOutpostId()

            Dim fomList As List(Of FlowOutpostMaster) = CommonFun.ConvertToList(Of FlowOutpostMaster)(fomdt)
            For Each m As FlowOutpostMaster In fomList
                m.Flow_outpost_id = newFlowOutpostId
                m.Change_date = Now
                m.Change_userid = changeUserid
                m.InsertFlowOutpostMaster()
            Next

            Dim fofList As List(Of FlowOutpostForm) = CommonFun.ConvertToList(Of FlowOutpostForm)(fofdt)
            For Each f As FlowOutpostForm In fofList
                f.Flow_outpost_id = newFlowOutpostId
                f.Change_date = Now
                f.Change_userid = changeUserid
                f.InsertFlowOutpostForm()
            Next

            Dim fotList As List(Of FlowOutpostTarget) = CommonFun.ConvertToList(Of FlowOutpostTarget)(fotdt)
            For Each t As FlowOutpostTarget In fotList
                t.InsertFlowOutpostTarget(newFlowOutpostId, t.Orgcode, t.Depart_id, t.Target, t.Target_type, changeUserid)
            Next

            trans.Complete()
        End Using

        CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "複製成功!")

        QueryBind()
    End Sub
End Class
