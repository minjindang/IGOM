Imports System.Data

Imports FSCPLM.Logic

Partial Class MAT4101_01
    Inherits BaseWebForm

    Dim maDAO As New Material_main
    Dim orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Dim materialid As String = Request.QueryString("tb1")
            If Not String.IsNullOrEmpty(materialid) Then
                BindGV(materialid)
            End If
            UcMaterialClassB.Orgcode = LoginManager.OrgCode
        End If

    End Sub
    Protected Sub ResetBtn_Click(sender As Object, e As EventArgs) Handles ResetBtn.Click
        CommonFun.ClearContentPlaceHolder(Me.Master)
    End Sub

    Private Sub BindGV(ByVal materialid As String)
        Dim dt As DataTable = maDAO.GetAll(materialid, Me.txtLocation.Text, orgcode) 'Select Data
        'div1.Visible = Not dt Is Nothing AndAlso dt.Rows.Count > 0
        div1.Visible = True

        Me.GridViewA.DataSource = dt
        Me.GridViewA.DataBind()
        ViewState("DataTable") = dt '將資料暫存起來，做為資料的跳頁等顯示
        'dt.Dispose()
    End Sub

    Protected Sub QryBtn_Click(sender As Object, e As EventArgs) Handles QryBtn.Click
        Dim materialid As String = Me.txtMaterialId.Text
        If Not CommonFun.IsNum(materialid) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "物料編號只能輸入數字")
            Return
        End If
        BindGV(materialid)
    End Sub
#Region "頁數改變時"
    Protected Sub gvList_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridViewA.PageIndexChanging
        Me.GridViewA.PageIndex = e.NewPageIndex
        Me.GridViewA.DataSource = CType(ViewState("dt"), DataTable)
        Me.GridViewA.DataBind()
    End Sub
#End Region

    Protected Sub GridViewA_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GridViewA.PageIndexChanging
        GridViewA.PageIndex = e.NewPageIndex
        Me.GridViewA.DataSource = CType(ViewState("DataTable"), DataTable)
        Me.GridViewA.DataBind()
    End Sub

    Protected Sub GridViewA_RowCommand(sender As Object, e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridViewA.RowCommand
        Dim materialid As String = Me.txtMaterialId.Text
        Dim Material_id As String = e.CommandArgument
        If e.CommandName = "Maintain" Then
            Page.Response.Redirect(String.Format("~/MAT/MAT4/MAT4101_03.aspx?Material_id={0}", Material_id))
        ElseIf e.CommandName = "GoDelete" Then
            Dim mdDAO As MaterialInDet = New MaterialInDet()
            Dim result As String = maDAO.Delete(Material_id)
            If String.IsNullOrEmpty(result) Then
                CommonFun.MsgShow(Me, CommonFun.Msg.DeleteOK)
                BindGV(materialid)
            Else
                CommonFun.MsgShow(Me.Page, CommonFun.Msg.Custom, result)
            End If
        End If
    End Sub
    Protected Sub UcMaterialClassB_Checked(sender As Object, e As EventArgs)
        txtMaterialId.Text = UcMaterialClassB.MaterialId
    End Sub
End Class
