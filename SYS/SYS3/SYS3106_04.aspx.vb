Imports System
Imports System.Data
Imports System.Xml
Imports System.IO
Imports System.Drawing
Imports System.Net
Imports System.Data.SqlClient
Imports System.Transactions

Partial Class SYS3106_04
    Inherits BaseWebForm


#Region "Page_Load"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Me.IsPostBack Then
            Return
        End If

        Bind()
    End Sub
#End Region


    Protected Sub Bind()
        Dim roleId As String = Request.QueryString("rid")
        Dim r As New SYS.Logic.Role()

        Dim dt As DataTable = r.GetRole(LoginManager.OrgCode, roleId)
        If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
            lblRoleName.Text = dt.Rows(0)("Role_name").ToString()
        End If  

        Dim bll As New SYS.Logic.SYS3106()

        gvList.DataSource = bll.GetFormData(LoginManager.OrgCode)
        gvList.DataBind()

        Dim fs As String = r.GetRoleForm(LoginManager.OrgCode, roleId)
        For Each gvr As GridViewRow In gvList.Rows
            Dim formId As String = CType(gvr.FindControl("gvhfFormId"), HiddenField).Value
            For Each s As String In fs.Split(",")
                If s = formId Then
                    CType(gvr.FindControl("gvcbx"), CheckBox).Checked = True
                    Exit For
                End If
            Next
        Next

    End Sub

#Region "關閉"
    Protected Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Response.Redirect("SYS3106_01.aspx")
    End Sub
#End Region

#Region "確認"
    Protected Sub btnOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOK.Click, btnOK2.Click
        Dim orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim roleId As String = Request.QueryString("rid")
        Dim r As New SYS.Logic.Role()

        Try
            Using trans As New TransactionScope

                '先刪除該角色所有的模組權限
                r.DeleteRoleForms(orgcode, roleId)

                For Each gvr As GridViewRow In gvList.Rows
                    Dim formId As String = CType(gvr.FindControl("gvhfFormId"), HiddenField).Value

                    If CType(gvr.FindControl("gvcbx"), CheckBox).Checked Then
                        r.AddRoleForm(orgcode, roleId, formId, LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account))
                    End If
                Next

                trans.Complete()
            End Using

            CommonFun.MsgShow(Me.Page, CommonFun.Msg.Custom, "表單設定成功", "SYS3106_01.aspx")
        Catch ex As Exception
            CommonFun.MsgShow(Me.Page, CommonFun.Msg.SystemError)
        End Try

    End Sub
#End Region

    Protected Sub gvList_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        gvList.PageIndex = e.NewPageIndex
        Bind()
    End Sub
End Class
