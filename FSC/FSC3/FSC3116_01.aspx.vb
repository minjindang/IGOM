Imports FSC.Logic
Imports System
Imports System.Data
Imports System.Xml
Imports System.IO
Imports System.Drawing
Imports System.Net
Imports System.Data.SqlClient
Imports System.Collections.Generic

Partial Class FSC3116_01
    Inherits BaseWebForm

    Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then
            Return
        End If
        Dep_Bind()

        ddlName.Items.Insert(0, New ListItem("請選擇", ""))
    End Sub

    Protected Sub Dep_Bind()
        UcDDLDepart.Orgcode = Orgcode
    End Sub

    Protected Sub Name_Bind()
        ddlName.DataSource = New Member().GetDataByOrgDep(Orgcode, UcDDLDepart.SelectedValue())
        ddlName.DataBind()
        ddlName.Items.Insert(0, New ListItem("請選擇", ""))
    End Sub

    Protected Sub UcDDLDepart_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles UcDDLDepart.SelectedIndexChanged
        Name_Bind()
    End Sub

    Protected Sub btnFind_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFind.Click
        bind()
    End Sub

    Public Sub bind()
        Dim orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode) '機構代碼
        Dim departid As String = UcDDLDepart.SelectedValue()
        Dim idcard As String = ddlName.SelectedValue()
        Dim leave_types As String = ""
        Dim dateb As String = UcDate1.Text
        Dim datee As String = UcDate2.Text
        Dim bll As New FSC.Logic.FSC3109()
        Dim dt As DataTable

        Try
            For Each item As ListItem In cblleave_types.Items
                If item.Selected Then
                    leave_types &= "'" & item.Value & "',"
                End If
            Next
            leave_types = leave_types.TrimEnd(",")

            dt = bll.getQueryData(orgcode, departid, idcard, "", leave_types, dateb, datee, "", False)
            tbQ.Visible = True

            Me.gvList.DataSource = dt
            Me.gvList.DataBind()
            dt.Dispose()

        Catch ex As Exception
            CommonFun.MsgShow(Me.Page, CommonFun.Msg.SystemError)
            AppException.WriteErrorLog(ex.StackTrace, ex.Message)
        End Try
    End Sub


#Region "GridView資料繫結"
    Protected Sub gvList_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvList.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            CType(e.Row.FindControl("lbNo"), Label).Text = e.Row.DataItemIndex + 1
        End If
    End Sub
#End Region

#Region "頁數改變時"
    Protected Sub gvList_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvList.PageIndexChanging
        Me.gvList.PageIndex = e.NewPageIndex
        bind()
    End Sub
#End Region

    Protected Sub cbUpdate_Click(sender As Object, e As System.EventArgs)
        Dim gvr As GridViewRow = CType(sender, Button).NamingContainer
        Dim orgcode As String = CType(gvr.FindControl("lbOrgcode"), Label).Text
        Dim flow_id As String = CType(gvr.FindControl("lbflow_id"), Label).Text

        Response.Redirect("../FSC1/FSC1101_01.aspx?org=" + orgcode + "&fid=" + flow_id + "&url=FSC3116")
    End Sub

    Protected Sub cbAll_CheckedChanged(sender As Object, e As EventArgs)
        For Each i As ListItem In cblleave_types.Items
            i.Selected = cbAll.Checked
        Next
    End Sub
End Class
