Imports System.Data
Imports System.Transactions
Imports System.Collections.Generic
Imports SYS.Logic
Imports FSCPLM.Logic

Partial Class SYS3108_03
    Inherits BaseWebForm

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then Return

        Bind()
        ChgGV()
    End Sub

    Protected Sub Bind()
        Dim orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim flowOutpostId As String = Request.QueryString("fopID")
        If Not String.IsNullOrEmpty(flowOutpostId) Then
            cbConfirm.Visible = True
        End If

        Dim sdt As DataTable
        Dim list As List(Of SYS.Logic.FlowOutpostMaster) = Session("FlowOutpostMasterList")

        If String.IsNullOrEmpty(flowOutpostId) Then
            sdt = New SYS.Logic.SYS3108().GetSettingData(orgcode, list)
        Else
            If list IsNot Nothing Then
                sdt = New SYS.Logic.SYS3108().GetSettingData(orgcode, list)
            Else
                sdt = New SYS.Logic.SYS3108().GetSettingData(orgcode, flowOutpostId)
                cbPreStep.Visible = False
            End If
        End If
        gv.DataSource = sdt
        gv.DataBind()

        BindCodeType()
        BindFormId()

        Dim list2 As List(Of SYS.Logic.FlowOutpostForm) = Session("FlowOutpostFormList")
        If list2 IsNot Nothing Then
            For i As Integer = 0 To list2.Count - 1
                Dim fof As FlowOutpostForm = list2(i)
                ddlCodeType.SelectedValue = fof.Form_id.Substring(0, 3)
                BindFormId()
                For j As Integer = 0 To cbxlForm.Items.Count - 1
                    If cbxlForm.Items(j).Value = fof.Form_id Then
                        cbxlForm.Items(j).Selected = True
                    End If
                Next
            Next
        End If
    End Sub

    Protected Sub BindCodeType()
        Dim flowOutpostId As String = Request.QueryString("fopID")
        Dim saCode As New SACode()
        Dim saCodedt As DataTable = saCode.GetData2("024", "P", "**")
        saCodedt.DefaultView.Sort = "code_no"
        saCodedt = saCodedt.DefaultView.ToTable
        ddlCodeType.DataSource = saCodedt
        ddlCodeType.DataBind()

        If Not String.IsNullOrEmpty(flowOutpostId) Then
            'when updating
            Dim fof As New FlowOutpostForm()
            Dim dt As DataTable = fof.GetFlowOutpostForm(flowOutpostId)
            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                ddlCodeType.SelectedValue = dt.Rows(0)("Form_id").ToString().Substring(0, 3)
            End If
        End If
    End Sub

    Protected Sub BindFormId()
        Dim flowOutpostId As String = Request.QueryString("fopID")
        Dim orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim codeType As String = ddlCodeType.SelectedValue

        Dim saCode As New SACode()
        Dim saCodedt As DataTable = saCode.GetData2("024", "P", codeType)

        Dim dt As New DataTable()
        dt.Columns.Add("formName")
        dt.Columns.Add("formId")

        Dim leaveType As New SYS.Logic.LeaveType()
        For Each saCodedr As DataRow In saCodedt.Rows
            Dim dr As DataRow = dt.NewRow
            dr("formId") = codeType & saCodedr("code_no")       ' formId : code_type + code_no
            If "001" = codeType And Not String.IsNullOrEmpty(saCodedr("code_desc2").ToString()) Then
                dr("formName") = saCodedr("code_desc1") & leaveType.GetCombineLeaveType(orgcode, saCodedr("code_desc2").ToString())
            Else
                dr("formName") = saCodedr("code_desc1")
            End If
            dt.Rows.Add(dr)
        Next
        cbxlForm.DataSource = dt
        cbxlForm.DataBind()

        If Not String.IsNullOrEmpty(flowOutpostId) Then
            'when updating
            Dim fof As New FlowOutpostForm()
            Dim dt1 As DataTable = fof.GetFlowOutpostForm(flowOutpostId)
            If dt1 IsNot Nothing AndAlso dt1.Rows.Count > 0 Then
                For Each dr As DataRow In dt1.Rows
                    For Each item As ListItem In cbxlForm.Items
                        If dr("form_id").ToString() = item.Value Then
                            item.Selected = True
                        End If
                    Next
                Next
            End If
        End If
    End Sub

    '下一步
    Protected Sub cbNextStep_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbNextStep.Click
        Dim flowOutpostId As String = Request.QueryString("fopID")
        SetSessionData()
        Response.Redirect("SYS3108_04.aspx?fopID=" & flowOutpostId)
    End Sub

    Protected Sub SetSessionData()
        Dim orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim Id_card As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card)
        Dim flowOutpostId As String = Request.QueryString("fopID")

        Dim list As New List(Of SYS.Logic.FlowOutpostForm)
        For i As Integer = 0 To cbxlForm.Items.Count - 1
            If cbxlForm.Items(i).Selected Then
                Dim fof As New SYS.Logic.FlowOutpostForm()
                fof.Orgcode = orgcode
                fof.Form_id = cbxlForm.Items(i).Value
                list.Add(fof)
            End If
        Next
        Session("FlowOutpostFormList") = list

        Dim list1 As New List(Of SYS.Logic.FlowOutpostMaster)
        For Each gr As GridViewRow In gv.Rows
            Dim fom As New SYS.Logic.FlowOutpostMaster()
            fom.Orgcode = orgcode
            fom.Outpost_id = CType(gr.FindControl("gv_lbOutpost_id"), Label).Text
            fom.Outpost_orgcode = CType(gr.FindControl("gv_lbOutpost_orgcode"), Label).Text
            fom.Outpost_departid = CType(gr.FindControl("gv_lbOutpost_departid"), Label).Text
            fom.Outpost_posid = CType(gr.FindControl("gv_lbOutpost_posid"), Label).Text
            fom.Relate_flag = CType(gr.FindControl("gv_lbRelate_flag"), Label).Text
            fom.Outpost_seq = CType(gr.FindControl("gv_lbOutpost_seq"), Label).Text
            fom.Hoursetting_id = CType(gr.FindControl("gv_ddlHoursettingId"), DropDownList).SelectedValue
            fom.Group_id = CType(gr.FindControl("gv_lbGroup_id"), Label).Text
            fom.Group_seq = CType(gr.FindControl("gv_lbGroup_seq"), Label).Text
            fom.Group_type = CType(gr.FindControl("gv_lbGroup_type"), Label).Text
            fom.Mail_flag = CType(gr.FindControl("gv_rbxlMailFlag"), RadioButtonList).SelectedValue
            fom.Unit_flag = CType(gr.FindControl("gv_lbUnit_flag"), Label).Text
            list1.Add(fom)
        Next
        Session("FlowOutpostMasterList") = list1
    End Sub

    '上一步
    Protected Sub cbPreStep_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbPreStep.Click
        Dim flowOutpostId As String = Request.QueryString("fopID")
        Response.Redirect("SYS3108_02.aspx?fopID=" & flowOutpostId)
    End Sub

    '取消
    Protected Sub cbCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbCancel.Click
        Session("FlowOutpostMasterList") = Nothing
        Session("FlowOutpostFormList") = Nothing

        Dim flowOutpostId As String = Request.QueryString("fopID")
        Response.Redirect("SYS3108_01.aspx?fopID=" & flowOutpostId)
    End Sub

    Protected Sub ddlCodeType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlCodeType.SelectedIndexChanged
        BindFormId()
        ChgGV()
    End Sub

    Protected Sub gv_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gv.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then

            Dim ddl As DropDownList = CType(e.Row.FindControl("gv_ddlHoursettingId"), DropDownList)
            Dim dt As DataTable = New SACode().GetData("023", "006")
            Dim dr As DataRow = dt.NewRow
            dr("code_desc1") = "請選擇"
            dr("code_no") = ""
            dt.Rows.InsertAt(dr, 0)
            ddl.DataSource = dt
            ddl.DataBind()

            ddl.SelectedValue = CType(e.Row.FindControl("gv_hfHoursettingId"), HiddenField).Value

            Dim rbl As RadioButtonList = CType(e.Row.FindControl("gv_rbxlMailFlag"), RadioButtonList)
            rbl.SelectedValue = IIf(String.IsNullOrEmpty(CType(e.Row.FindControl("gv_hfMailFlag"), HiddenField).Value), "0", CType(e.Row.FindControl("gv_hfMailFlag"), HiddenField).Value)
        End If
    End Sub

    Protected Sub ChgGV()
        If ddlCodeType.SelectedValue = "001" Then
            gv.Columns(2).Visible = True
        Else
            gv.Columns(2).Visible = False
        End If
    End Sub


    Protected Sub cbConfirm_Click(sender As Object, e As EventArgs)
        Dim flowOutpostId As String = Request.QueryString("fopID")
        Dim changeUserid As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card)
        Dim fof As New FlowOutpostForm()
        Dim fom As New FlowOutpostMaster()

        SetSessionData()

        Using trans As New TransactionScope
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

        CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "設定成功", "SYS3108_01.aspx")
    End Sub
End Class
