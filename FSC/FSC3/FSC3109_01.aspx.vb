Imports FSC.Logic
Imports System
Imports System.Data
Imports System.Xml
Imports System.IO
Imports System.Drawing
Imports System.Net
Imports System.Data.SqlClient
Imports System.Collections.Generic

Partial Class FSC3109_01
    Inherits BaseWebForm

    Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then
            Return
        End If
        Dep_Bind()
        Employee_type_Bind()
        bindLeaveData()
        ddlName.Items.Insert(0, New ListItem("請選擇", ""))

        Dim qdep As String = Request.QueryString("qdep")
        Dim qsdep As String = Request.QueryString("qsdep")
        Dim qname As String = Request.QueryString("qname")
        Dim qid As String = Request.QueryString("qid")
        Dim qpid As String = Request.QueryString("qpid")

        If qdep <> "" Or qname <> "" Or qid <> "" Then
            UcDDLDepart.SelectedValue = qdep
            Name_Bind()
            ddlName.SelectedValue = qname
            bind()
        End If
    End Sub

    Protected Sub Dep_Bind()
        UcDDLDepart.Orgcode = Orgcode
    End Sub

    Protected Sub Name_Bind()
        ddlName.DataSource = New FSC.Logic.Personnel().GetDataByOrgDep(Orgcode, UcDDLDepart.SelectedValue())
        ddlName.DataBind()
        ddlName.Items.Insert(0, New ListItem("請選擇", ""))
    End Sub

    Protected Sub UcDDLDepart_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles UcDDLDepart.SelectedIndexChanged
        Name_Bind()
    End Sub

    Protected Sub btnFind_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFind.Click
        bind()
    End Sub

    Protected Sub Employee_type_Bind()
        ddlEmployee_type.DataSource = New SYS.Logic.CODE().GetData("023", "022")
        ddlEmployee_type.DataBind()
        ddlEmployee_type.Items.Insert(0, New ListItem("請選擇", ""))
    End Sub

    Public Sub bind()
        Dim orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode) '機構代碼
        Dim departid As String = UcDDLDepart.SelectedValue()
        Dim idcard As String = ddlName.SelectedValue()
        Dim employee_type As String = ddlEmployee_type.SelectedValue
        Dim leave_types As String = ""
        Dim dateb As String = UcDate1.Text
        Dim datee As String = UcDate2.Text
        Dim case_status As String = IIf(cbxCancel.Checked, "3", "1")
        Dim bll As New FSC.Logic.FSC3109()
        Dim dt As DataTable

        Try
            For Each item As ListItem In cblleave_types.Items
                If item.Selected Then
                    leave_types &= "'" & item.Value.PadLeft(2, "0") & "',"
                End If
            Next
            leave_types = leave_types.TrimEnd(",")

            dt = bll.getQueryData(orgcode, departid, idcard, employee_type, leave_types, dateb, datee, case_status)
            tbQ.Visible = True

            Me.gvList.DataSource = dt
            Me.gvList.DataBind()
            dt.Dispose()

        Catch ex As Exception
            CommonFun.MsgShow(Me.Page, CommonFun.Msg.SystemError)
            AppException.WriteErrorLog(ex.StackTrace, ex.Message)
        End Try

        ' 查詢條件勾選撤單，則撤單按鈕隱藏
        If Me.cbxCancel.Checked Then
            cbBatchCancel.Visible = False
        Else
            cbBatchCancel.Visible = True
        End If
    End Sub


#Region "GridView資料繫結"
    Protected Sub gvList_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvList.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            CType(e.Row.FindControl("lbNo"), Label).Text = e.Row.DataItemIndex + 1

            If CType(e.Row.FindControl("lbCase_status"), Label).Text = "4" Then
                CType(e.Row.FindControl("cbx"), CheckBox).Enabled = False
                CType(e.Row.FindControl("cbCancel"), Button).Enabled = False
            End If

            If Me.cbxCancel.Checked Then
                CType(e.Row.FindControl("cbCancel"), Button).Visible = False
            Else
                CType(e.Row.FindControl("cbCancel"), Button).Visible = True
            End If
        End If
    End Sub
#End Region

#Region "頁數改變時"
    Protected Sub gvList_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvList.PageIndexChanging
        Me.gvList.PageIndex = e.NewPageIndex
        bind()
    End Sub
#End Region

    Protected Sub cbBatchCancel_Click(sender As Object, e As System.EventArgs) Handles cbBatchCancel.Click
        Dim chk As Boolean = False
        Try
            For Each gvr As GridViewRow In gvList.Rows
                Dim orgcode As String = CType(gvr.FindControl("lbOrgcode"), Label).Text
                Dim flow_id As String = CType(gvr.FindControl("lbflow_id"), Label).Text
                Dim cbx As CheckBox = CType(gvr.FindControl("cbx"), CheckBox)

                If cbx.Checked Then
                    cancelFlow(orgcode, flow_id)
                    chk = True
                End If
            Next
            If chk Then
                CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "撤單成功")
                bind()
            End If
        Catch ex As Exception
            AppException.WriteErrorLog(ex.StackTrace, ex.Message)
            CommonFun.MsgShow(Me, CommonFun.Msg.SystemError)
        End Try
    End Sub

    Protected Sub cbCancel_Click(sender As Object, e As System.EventArgs)
        Dim gvr As GridViewRow = CType(sender, Button).NamingContainer
        Dim orgcode As String = CType(gvr.FindControl("lbOrgcode"), Label).Text
        Dim flow_id As String = CType(gvr.FindControl("lbflow_id"), Label).Text
        Try
            cancelFlow(orgcode, flow_id)
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "撤單成功")
            bind()
        Catch ex As Exception
            AppException.WriteErrorLog(ex.StackTrace, ex.Message)
            CommonFun.MsgShow(Me, CommonFun.Msg.SystemError)
        End Try

    End Sub

    Protected Sub cancelFlow(ByVal orgcode As String, ByVal flow_id As String)
        '撤單
        'Dim fd As SYS.Logic.FlowDetail = New FSC3109().getFDObjectByFlowId(orgcode, flow_id)
        Dim fd As New SYS.Logic.FlowDetail()
        fd.FlowId = flow_id
        fd.Orgcode = orgcode
        fd.LastOrgcode = orgcode
        fd.LastDepartid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id)
        fd.LastPosid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Title_no)
        fd.LastIdcard = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card)
        fd.LastName = LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name)
        fd.AgreeFlag = "1"
        fd.AgreeTime = Now.ToString("yyy/MM/dd HH:mm:ss")
        fd.Comment = ""
        fd.LastDate = Now.ToString("yyy/MM/dd HH:mm:ss")
        fd.LastPass = "1"

        SYS.Logic.CommonFlow.RunSelfCancel(fd)
    End Sub

    Protected Sub cbAdd_Click(sender As Object, e As System.EventArgs) Handles cbAdd.Click
        Response.Redirect("FSC3109_02.aspx")
    End Sub

    Protected Sub bindLeaveData()
        Dim lt As New SYS.Logic.LeaveType()
        cblleave_types.DataTextField = "Leave_name"
        cblleave_types.DataValueField = "Leave_type"
        cblleave_types.DataSource = lt.GetLeaveType(LoginManager.OrgCode, "Z")
        cblleave_types.DataBind()
    End Sub

End Class
