Imports FSC.Logic
Imports System
Imports System.Data
Imports System.Xml
Imports System.IO
Imports System.Drawing
Imports System.Net
Imports System.Data.SqlClient
Imports System.Transactions

Partial Class FSC3102_02
    Inherits BaseWebForm

#Region "Page_Load"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        If Not String.IsNullOrEmpty(Request.QueryString("idno")) Then

            ShowGridView(p_orgcode, p_idcard)

        End If

    End Sub
#End Region

#Region "建立列表"
    Public Sub ShowGridView(ByVal orgcode As String, ByVal id_card As String)

        Dim DAOFSC3102 As New FSC3102
        Dim dt As DataTable
        Try
            dt = DAOFSC3102.Get_Deputy(orgcode, id_card)

            DataList.Visible = True
            gvList.DataSource = dt
            gvList.DataBind()
            ViewState("DataTable") = dt '將資料暫存起來，做為資料的跳頁等顯示
            dt.Dispose()

        Catch ex As Exception
            CommonFun.MsgShow(Me, CommonFun.Msg.SystemError)
        End Try

    End Sub

#End Region

    Protected Sub gvList_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvList.PageIndexChanging
        Me.gvList.PageIndex = e.NewPageIndex

        Me.gvList.DataSource = CType(ViewState("DataTable"), DataTable)
        Me.gvList.DataBind()
    End Sub

    Protected Sub gvList_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvList.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            If CType(e.Row.FindControl("gv_lbDeputy_flag"), Label).Text.Trim = "1" Then
                CType(e.Row.FindControl("gv_lbDeputy_flag"), Label).Text = "●"
            Else
                CType(e.Row.FindControl("gv_lbDeputy_flag"), Label).Text = ""
            End If
        End If
    End Sub


#Region " Button "

    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Response.Redirect("FSC3102_01.aspx")
    End Sub

    Protected Sub gv_cbEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim id As String = CType(sender, Button).CommandArgument.ToString

        Response.Redirect("FSC3102_04.aspx?org=" & p_orgcode & "&idno=" & p_idcard & "&id=" & id)
    End Sub

    Protected Sub gv_cbDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim id As String = CType(sender, Button).CommandArgument.ToString
        Dim gvr As GridViewRow = CType(sender, Button).NamingContainer
        Dim deputy As New FSC.Logic.DeputyDet
        Dim rv As Boolean = False
        Try
            Using trans As New TransactionScope
                deputy.DeleteDeputyDet(id)
                rv = True
                trans.Complete()
            End Using

            ShowGridView(Me.p_orgcode, Me.p_idcard)
        Catch ex As Exception
            AppException.WriteErrorLog(ex.StackTrace(), ex.Message())
            CommonFun.MsgShow(Me, CommonFun.Msg.SystemError)
        End Try

        If rv Then
            CommonFun.MsgShow(Me, CommonFun.Msg.DeleteOK)
            ShowGridView(p_orgcode, p_idcard)
        Else
            CommonFun.MsgShow(Me, CommonFun.Msg.DeleteFail)
        End If
    End Sub

#End Region

#Region " Property "

    Protected ReadOnly Property p_orgcode() As String
        Get
            Dim rv As String = ""

            If Not String.IsNullOrEmpty(Request.QueryString("org")) Then
                rv = Request.QueryString("org")
            End If

            Return rv
        End Get
    End Property

    Protected ReadOnly Property p_idcard() As String
        Get
            Dim rv As String = ""

            If Not String.IsNullOrEmpty(Request.QueryString("idno")) Then
                rv = Request.QueryString("idno")
            End If

            Return rv
        End Get
    End Property

#End Region

End Class
