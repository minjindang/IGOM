Imports System.Data
Imports FSCPLM.Logic

Partial Class MAT_MAT3_MAT3101_01
    Inherits BaseWebForm


#Region " PageLoad"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ''initfunction()
        If Not (IsPostBack) Then
            'BindGV()
            UcDDLDepart02.Orgcode = LoginManager.OrgCode
            UcDDLMember.Orgcode = LoginManager.OrgCode

            If Request("types") = "update" Then
                CommonFun.MsgShow(Page, CommonFun.Msg.Custom, "修改成功")
            End If
        End If
    End Sub
#End Region

    Private Sub BindGV()
        Dim dt As New DataTable
        Dim amm As ApplyOtherMtrMain = New ApplyOtherMtrMain()
        dt = amm.GetData(Me.ucApply_dateS.Text, Me.ucApply_dateE.Text, UcDDLMember.SelectedValue)
        'div1.Visible = Not dt Is Nothing AndAlso dt.Rows.Count > 0
        div1.Visible = True
        Me.GridViewA.DataSource = dt
        Me.GridViewA.DataBind()
        ViewState("DataTable") = dt '將資料暫存起來，做為資料的跳頁等顯示
        dt.Dispose()
    End Sub

    Protected Sub QryBtn_Click(sender As Object, e As System.EventArgs) Handles QryBtn.Click
        BindGV()
    End Sub

    Protected Sub ResetBtn_Click(sender As Object, e As System.EventArgs) Handles ResetBtn.Click
        'BindGV()
        CommonFun.ClearContentPlaceHolder(Me.Master)
    End Sub

    Protected Sub GridViewA_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GridViewA.PageIndexChanging
        GridViewA.PageIndex = e.NewPageIndex
        Me.GridViewA.DataSource = CType(ViewState("DataTable"), DataTable)
        Me.GridViewA.DataBind()
    End Sub

    Protected Sub GridViewA_RowCommand(sender As Object, e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridViewA.RowCommand
        Dim details_id As Integer = CType(e.CommandArgument, Integer)
        If e.CommandName = "Maintain" Then
            Page.Response.Redirect("~/MAT/MAT3/MAT3101_03.aspx?Details_id=" & details_id)
        ElseIf e.CommandName = "GoDelete" Then

            Dim amd As ApplyOtherMtrDet = New ApplyOtherMtrDet()
            amd.Delete(details_id)
            BindGV()
        End If

    End Sub

    Protected Sub UcDDLDepart02_SelectedIndexChanged(sender As Object, e As EventArgs)
        UcDDLMember.DepartId = UcDDLDepart02.SelectedValue
    End Sub
End Class
