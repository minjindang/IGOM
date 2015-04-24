Imports System.Transactions
Imports System.Data
Imports SYS.Logic

Partial Class SYS3108_04
    Inherits BaseWebForm

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack Then Return

        hfOrgcode.Value = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        ddlDepartname.Enabled = False
        ddlDepartname.Orgcode = hfOrgcode.Value
        initData()
        BindTitle()
        BindMemer()
        BindEmpType()
    End Sub

#Region "下拉式選單"
    Protected Sub BindTitle()
        Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim Depart_Level As String = ""
        If rbl3.Checked Then
            Depart_Level = "1"
        ElseIf rbl4.Checked Then
            Depart_Level = "2"
        ElseIf rbl5.Checked Then
            Depart_Level = "3"
        End If

        Dim personnel As New FSC.Logic.Personnel()
        lbxTitleNo.DataSource = personnel.GetTitleDataByOrgDep(Orgcode, ddlDepartname.SelectedValue, Depart_Level, ddlTitle_Level.SelectedValue)
        lbxTitleNo.DataBind()
    End Sub

    Protected Sub BindMemer()
        Dim Depart_Level As String = ""
        If rbl3.Checked Then
            Depart_Level = "1"
        ElseIf rbl4.Checked Then
            Depart_Level = "2"
        ElseIf rbl5.Checked Then
            Depart_Level = "3"
        End If

        lbxId_card.DataSource = New FSC.Logic.Personnel().GetDataByOrgDep(hfOrgcode.Value, ddlDepartname.SelectedValue(), Depart_Level)
        lbxId_card.DataBind()
    End Sub

    Protected Sub BindEmpType()
        Dim saCode As New FSCPLM.Logic.SACode()
        Dim dt1 As DataTable = saCode.GetData2("023", "P", "022")

        dt1.DefaultView.Sort = " code_no "
        dt1 = dt1.DefaultView.ToTable()

        lbxEmpType.DataSource = dt1
        lbxEmpType.DataBind()
    End Sub

    Protected Sub ddlDepartname_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlDepartname.SelectedIndexChanged
        BindTitle()
        BindMemer()
    End Sub

    Protected Sub rbl1_CheckedChanged(sender As Object, e As EventArgs)
        If rbl1.Checked OrElse rbl3.Checked OrElse rbl4.Checked OrElse rbl5.Checked Then
            ddlDepartname.Enabled = False
            ddlDepartname.Orgcode = LoginManager.OrgCode
            BindTitle()
            BindMemer()
        End If
    End Sub

    Protected Sub rbl2_CheckedChanged(sender As Object, e As EventArgs)
        ddlDepartname.Enabled = True
    End Sub

    Protected Sub ddlTitle_Level_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlTitle_Level.SelectedIndexChanged
        BindTitle()
    End Sub
#End Region

    Protected Sub initData()
        Dim orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim Flow_outpost_id As String = Request.QueryString("fopID")
        Dim fofList As New Generic.List(Of FlowOutpostForm)

        Dim list As Generic.List(Of FlowOutpostMaster) = Session("FlowOutpostMasterList")

        If String.IsNullOrEmpty(Flow_outpost_id) Then
            lbFlowOutpost.Text = SYS.Logic.Outpost.GetDisplayOutpost(orgcode, list)
            fofList = Session("FlowOutpostFormList")
        Else
            'when updating
            If list IsNot Nothing Then
                lbFlowOutpost.Text = SYS.Logic.Outpost.GetDisplayOutpost(orgcode, list)
                fofList = Session("FlowOutpostFormList")
            Else
                lbFlowOutpost.Text = SYS.Logic.Outpost.GetDisplayOutpost(orgcode, "", "", Flow_outpost_id, True)
                Dim dt As DataTable = New SYS.Logic.FlowOutpostForm().GetFlowOutpostForm(Flow_outpost_id)
                For Each dr As DataRow In dt.Rows
                    Dim fom As New FlowOutpostForm()
                    fom.Orgcode = dr("Orgcode").ToString()
                    fom.Flow_outpost_id = dr("Flow_outpost_id").ToString()
                    fom.Form_id = dr("Form_id").ToString()
                    fofList.Add(fom)
                Next
                cbPreStep.Visible = False
            End If

            Dim dt1 As DataTable = New FlowOutpostTarget().GetTargetByFOId(orgcode, Flow_outpost_id)
            gv.DataSource = dt1
            gv.DataBind()
            ViewState("dt") = dt1
        End If


        For Each fof As FlowOutpostForm In fofList
            Dim codeType As String = fof.Form_id.Substring(0, 3)
            Dim codeNo As String = fof.Form_id.Substring(3)

            Dim dr As DataRow = New FSCPLM.Logic.SACode().GetRow("024", codeType, codeNo)
            If dr IsNot Nothing Then
                Dim desc As String = dr("code_desc1").ToString()
                Dim desc2 As String = dr("code_desc2").ToString()

                If Not "".Equals(desc2) Then
                    desc2 = New SYS.Logic.LeaveType().GetCombineLeaveType(orgcode, desc2)
                End If
                lbFormText.Text &= desc & desc2 & "<br/>"
            End If
        Next

        
    End Sub


    Protected Sub cbSelect_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbSelect.Click

        If rbl2.Checked And String.IsNullOrEmpty(ddlDepartname.SelectedValue) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "請選擇單位或全部單位!")
            Return
        End If

        Dim Depart_Level As String = ""
        If rbl3.Checked Then
            Depart_Level = "1"
        ElseIf rbl4.Checked Then
            Depart_Level = "2"
        ElseIf rbl5.Checked Then
            Depart_Level = "3"
        End If

        Dim org As New FSC.Logic.Org()
        Dim dt As DataTable = ViewState("dt")

        If dt Is Nothing Then
            dt = New DataTable
            dt.Columns.Add("Depart_id", GetType(String))
            dt.Columns.Add("Depart_name", GetType(String))
            dt.Columns.Add("Target", GetType(String))
            dt.Columns.Add("Target_name", GetType(String))
        End If

        Dim depdt As DataTable = org.GetDataWithSubDepart(LoginManager.OrgCode, ddlDepartname.SelectedValue, Depart_Level)

        For Each depdr As DataRow In depdt.Rows
            Dim dr As DataRow = dt.NewRow

            dr("Depart_id") = depdr("Depart_id").ToString()
            dr("Depart_name") = depdr("Depart_name").ToString()

            Dim selected As Boolean = False
            For Each item As ListItem In lbxTitleNo.Items
                If item.Selected Then
                    dr("Target") &= item.Value & ",1;"
                    dr("Target_name") &= item.Text & "、"
                    selected = True
                End If
            Next

            For Each item As ListItem In lbxId_card.Items
                If item.Selected Then
                    dr("Target") &= item.Value & ",2;"
                    dr("Target_name") &= item.Text & "、"
                    selected = True
                End If
            Next

            For Each item As ListItem In lbxEmpType.Items
                If item.Selected Then
                    dr("Target") &= item.Value & ",3;"
                    dr("Target_name") &= item.Text & "、"
                    selected = True
                End If
            Next

            If Not selected Then
                CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "請選擇至少一個職稱")
                ViewState("dt") = Nothing
                Exit Sub
            End If

            dr("Target") = dr("Target").ToString.TrimEnd(";")
            dr("Target_name") = dr("Target_name").ToString.TrimEnd("、")

            dt.Rows.Add(dr)
        Next

        lbxTitleNo.SelectedIndex = -1
        lbxId_card.SelectedIndex = -1
        lbxEmpType.SelectedIndex = -1

        ViewState("dt") = dt

        gv.DataSource = dt
        gv.DataBind()
    End Sub

    Protected Sub gv_cbCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim dt As DataTable = ViewState("dt")
        Dim gvr As GridViewRow = CType(sender, Button).NamingContainer
        dt.Rows.Remove(dt.Rows(gvr.RowIndex))
        ViewState("dt") = dt
        gv.DataSource = dt
        gv.DataBind()
    End Sub

    '確認儲存
    Protected Sub cbSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbSave.Click
        Dim orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim changeUserid As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account)
        Dim dt As DataTable = ViewState("dt")
        Dim flowOutpostId As String = Request.QueryString("fopID")
        Dim fot As New FlowOutpostTarget()
        Dim fom As New FlowOutpostMaster()
        Dim fof As New FlowOutpostForm()

        If dt Is Nothing Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "請選擇至少一個職稱!")
            Return
        End If

        Using trans As New TransactionScope

            If Not String.IsNullOrEmpty(flowOutpostId) Then
                fot.DeleteFlowOutpostTarget(flowOutpostId)
            Else
                flowOutpostId = fom.GetFlowOutpostId()
            End If

            For Each dr As DataRow In dt.Rows
                Dim targetList() As String = dr("Target").ToString.Split(";")
                For Each targets As String In targetList
                    Dim target As String = targets.Split(",")(0)
                    Dim targetType As String = targets.Split(",")(1)

                    If Not fot.InsertFlowOutpostTarget(flowOutpostId, orgcode, dr("Depart_id"), target, targetType, changeUserid) Then
                        Throw New Exception("設定失敗")
                    End If
                Next
            Next

            Dim fomList As Generic.List(Of FlowOutpostMaster) = Session("FlowOutpostMasterList")
            If fomList IsNot Nothing Then
                fom.DeleteFlowOutpostMaster(flowOutpostId)
                For i As Integer = 0 To fomList.Count - 1
                    Dim fom1 As FlowOutpostMaster = fomList(i)
                    fom1.Flow_outpost_id = flowOutpostId
                    fom1.Change_userid = changeUserid
                    fom1.Change_date = Now
                    If Not fom1.InsertFlowOutpostMaster() Then
                        Throw New Exception("設定失敗")
                    End If
                Next
            End If

            Dim fofList As Generic.List(Of FlowOutpostForm) = Session("FlowOutpostFormList")
            If fofList IsNot Nothing Then
                fof.DeleteFlowOutpostForm(flowOutpostId)
                For i As Integer = 0 To fofList.Count - 1
                    Dim fof1 As FlowOutpostForm = fofList(i)
                    fof1.Flow_outpost_id = flowOutpostId
                    fof1.Change_userid = changeUserid
                    fof1.Change_date = Now
                    If Not fof1.InsertFlowOutpostForm() Then
                        Throw New Exception("設定失敗")
                    End If
                Next
            End If

            trans.Complete()
        End Using

        If String.IsNullOrEmpty(flowOutpostId) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "設定成功", "SYS3108_01.aspx?fopID=" & flowOutpostId)
        Else
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "設定成功", "SYS3108_01.aspx")
        End If

    End Sub

    '取消
    Protected Sub cbCancel1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbCancel.Click
        Dim flowOutpostId As String = Request.QueryString("fopID")
        Session("FlowOutpostMasterList") = Nothing
        Session("FlowOutpostFormList") = Nothing
        Response.Redirect("SYS3108_01.aspx?fopID=" & flowOutpostId)
    End Sub

    Protected Sub cbPreStep_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbPreStep.Click
        Dim flowOutpostId As String = Request.QueryString("fopID")
        Response.Redirect("SYS3108_03.aspx?fopID=" & flowOutpostId)
    End Sub
End Class