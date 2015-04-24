Imports System
Imports System.Data
Imports System.Xml
Imports System.IO
Imports System.Drawing
Imports System.Net

Partial Class SYS3106_01
    Inherits BaseWebForm

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load, Me.Load
        If Me.IsPostBack Then
            Return
        End If

        ShowGridView()
    End Sub

#Region "建立列表"
    Public Sub ShowGridView()
        Dim orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim r As New SYS.Logic.Role()
        Dim dt As DataTable = r.GetData(orgcode)

        dt.Columns.Add("Boss_RoleName")
        For Each dr As DataRow In dt.Rows
            Dim bdt As DataTable = r.GetDataByOrgRid(orgcode, dr("Boss_roleid").ToString())
            If bdt IsNot Nothing AndAlso bdt.Rows.Count >= 1 Then
                dr("Boss_RoleName") = bdt.Rows(0)("Role_name").ToString()
            End If
        Next

        gvList.DataSource = dt
        gvList.DataBind()
    End Sub
#End Region

#Region "新增角色"
    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Response.Redirect("SYS3106_02.aspx")
    End Sub
#End Region


#Region "成員設定．權限設定"
    Protected Sub gvList_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvList.RowCommand
        If e.CommandName = "UpdateRole" Then
            Response.Redirect("SYS3106_02.aspx?rid=" & e.CommandArgument)
        ElseIf e.CommandName = "SetModule" Then '權限設定
            Response.Redirect("SYS3106_03.aspx?rid=" & e.CommandArgument)
        ElseIf e.CommandName = "SetForm" Then '表單設定
            Response.Redirect("SYS3106_04.aspx?rid=" & e.CommandArgument)
        End If
    End Sub
#End Region


#Region "頁數改變時"
    Protected Sub gvList_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvList.PageIndexChanging
        Me.gvList.PageIndex = e.NewPageIndex
        ShowGridView()
    End Sub
#End Region
End Class
