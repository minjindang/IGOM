Imports FSC.Logic
Imports System.Data
Imports System.Collections.Generic
Imports Excel = Microsoft.Office.Interop.Excel


Partial Class FSC3120_01
    Inherits BaseWebForm

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack() Then
            Return

        End If
        InitControl()
    End Sub

#Region "下拉式選單"
    Protected Sub InitControl()
        UcDDLDepart.Orgcode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)

        ddlBossTitle.DataSource = New FSC3120().getTitle()
        ddlBossTitle.DataBind()
        ddlBossTitle.Items.Insert(0, New ListItem("請選擇", ""))
    End Sub
#End Region

#Region "頁數改變時"
    Protected Sub gvList_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvlist.PageIndexChanging
        Me.gvlist.PageIndex = e.NewPageIndex
        Me.gvlist.DataSource = CType(ViewState("dt"), DataTable)
        Me.gvlist.DataBind()
    End Sub
#End Region

    Protected Sub btnQuery_Click(sender As Object, e As EventArgs) Handles btnQuery.Click
        Bind()
    End Sub

    Protected Sub Bind()
        Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim Depart_id As String = UcDDLDepart.SelectedValue
        Dim Title_no As String = ddlBossTitle.SelectedValue
        Dim bll As New FSC3120

        Try
            Dim dt As DataTable = bll.getData(Orgcode, Depart_id, Title_no)
            ViewState("dt") = dt
            gvlist.DataSource = dt
            gvlist.DataBind()

            tbq.Visible = True
            Ucpager.Visible = (dt IsNot Nothing AndAlso dt.Rows.Count > 0)
        Catch ex As Exception
            CommonFun.MsgShow(Me, CommonFun.Msg.SystemError)
            AppException.WriteErrorLog(ex.StackTrace, ex.ToString)
        End Try
    End Sub

    Protected Sub btnInsert_Click(sender As Object, e As EventArgs) Handles btnInsert.Click
        Response.Redirect("FSC3120_02.aspx")
    End Sub

    Protected Sub btnDel_Click(sender As Object, e As EventArgs)
        Dim gvr As GridViewRow = CType(sender, Button).NamingContainer
        Dim id As String = CType(gvr.FindControl("lbid"), Label).Text

        Dim bll As New DeputyVacancy

        Try
            bll.id = id
            bll.delete()
            Bind()

            CommonFun.MsgShow(Me, CommonFun.Msg.DeleteOK)
        Catch ex As Exception
            CommonFun.MsgShow(Me, CommonFun.Msg.DeleteFail)
            AppException.WriteErrorLog(ex.StackTrace, ex.ToString)
        End Try
    End Sub

    Protected Sub btnUpd_Click(sender As Object, e As EventArgs)
        Dim gvr As GridViewRow = CType(sender, Button).NamingContainer
        Dim id As String = CType(gvr.FindControl("lbid"), Label).Text

        Response.Redirect("FSC3120_02.aspx?id=" + id)
    End Sub
End Class
