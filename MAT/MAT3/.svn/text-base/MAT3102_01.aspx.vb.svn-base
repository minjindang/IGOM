Imports System.Data

Imports FSCPLM.Logic

Partial Class MAT3_MAT3102_01
    Inherits BaseWebForm

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            UcMaterialId.Orgcode = LoginManager.OrgCode
            'Check InvMemo
            Dim imDAO As New InventoryMain()
            Dim msg As String = imDAO.GetMemoMsg(LoginManager.OrgCode)
            If Not String.IsNullOrEmpty(msg) Then
                CommonFun.MsgShow(Page, CommonFun.Msg.Custom, msg)
                AddBtn.Enabled = False
                QryBtn.Enabled = False
                ResetBtn.Enabled = False
            End If

        End If

    End Sub

    Protected Sub ResetBtn_Click(sender As Object, e As EventArgs) Handles ResetBtn.Click
        CommonFun.ClearContentPlaceHolder(Me.Master)
    End Sub

    Private Sub BindGV()
        Dim mdDAO As New MaterialInDet
        Dim dt As DataTable = mdDAO.GetAll(txtMaterialId.Text, txtCompanyName.Text, UcDateS.Text, UcDateE.Text)
        'div1.Visible = Not dt Is Nothing AndAlso dt.Rows.Count > 0
        div1.Visible = True
        Me.GridViewA.DataSource = dt
        Me.GridViewA.DataBind()
        ViewState("DataTable") = dt '將資料暫存起來，做為資料的跳頁等顯示
        'dt.Dispose()
    End Sub

    Protected Sub QryBtn_Click(sender As Object, e As EventArgs) Handles QryBtn.Click
        BindGV()
    End Sub

    Protected Sub GridViewA_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GridViewA.PageIndexChanging
        GridViewA.PageIndex = e.NewPageIndex
        Me.GridViewA.DataSource = CType(ViewState("DataTable"), DataTable)
        Me.GridViewA.DataBind()
    End Sub

    Protected Sub GridViewA_RowCommand(sender As Object, e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridViewA.RowCommand
        Dim primaryKeys() As String = e.CommandArgument.ToString().Split(";")
        Dim OrgCode As String = primaryKeys(0)
        Dim Material_id As String = primaryKeys(1)
        Dim In_date As String = primaryKeys(2)

        If e.CommandName = "Maintain" Then
            Page.Response.Redirect(String.Format("~/MAT/MAT3/MAT3102_03.aspx?OrgCode={0}&Material_id={1}&In_date={2}", OrgCode, Material_id, In_date))
        ElseIf e.CommandName = "GoDelete" Then
            Dim mdDAO As MaterialInDet = New MaterialInDet()
            mdDAO.Delete(OrgCode, Material_id, In_date)
            BindGV()
        End If

    End Sub


    Protected Sub UcMaterialId_Checked(sender As Object, e As EventArgs)
        txtMaterialId.Text = UcMaterialId.MaterialId
    End Sub
End Class
