Imports System
Imports System.Data
Imports FSCPLM.Logic
Imports FSC.Logic

Partial Class EMP3109_01
    Inherits BaseWebForm

    Dim dtData As DataTable

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack() Then
            Return
        End If
        InitControl()
    End Sub

#Region "下拉式選單"
    Protected Sub InitControl()
        Dim Role_id As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.RoleId)
        UcDDLDepart.Orgcode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        UserName_Bind()
    End Sub

#End Region
    Protected Sub UcDDLDepart_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles UcDDLDepart.SelectedIndexChanged
        UserName_Bind()
    End Sub

    Private Sub UserName_Bind()
        UcDDLMember.Orgcode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        UcDDLMember.DepartId = UcDDLDepart.SelectedValue
    End Sub

    Protected Sub btnQuery_Click(sender As Object, e As EventArgs)
        Dim orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode) '機構代碼
        Dim depart_id As String = UcDDLDepart.SelectedValue
        Dim idcard As String = UcDDLMember.SelectedValue
        Dim id_card2 As String = UcMember.PersonnelId

        Dim isdisable As String = ddlisdisable.SelectedValue
        'Dim End_date As String = CommonFun.getInt(UcDate2.Text)

        Dim bll As New EMP3109
        Dim dt As DataTable

        Try
            dt = bll.getQueryData(depart_id, idcard, id_card2, isdisable)
            For Each dr As DataRow In dt.Rows
                Select Case dr("Mob_type")
                    Case "I"
                        dr("Mob_type") = "IOS"
                    Case "A"
                        dr("Mob_type") = "Android"
                    Case "W"
                        dr("Mob_type") = "Windows"
                End Select
            Next

            tbq.Visible = True 'feedback query result 
            ViewState("dt") = dt
            Me.gvlist.DataSource = dt
            Me.gvlist.DataBind()
            dt.Dispose()
        Catch ex As Exception
            CommonFun.MsgShow(Me.Page, CommonFun.Msg.SystemError)
            AppException.WriteErrorLog(ex.StackTrace, ex.Message)
        End Try

    End Sub
#Region "頁數改變時"
    Protected Sub gvList_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvList.PageIndexChanging
        Me.gvlist.PageIndex = e.NewPageIndex
        Me.gvlist.DataSource = CType(ViewState("dt"), DataTable)
        Me.gvlist.DataBind()
    End Sub
#End Region

    Protected Sub gvlist_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles gvlist.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then 'Filter Header and Footer 
            Dim lbisDisable As Label = CType(e.Row.FindControl("lbisDisable"), Label)
            Dim btnEnable As Button = CType(e.Row.FindControl("btnEnable"), Button)
            Dim btnDisable As Button = CType(e.Row.FindControl("btnDisable"), Button)
            If lbisDisable.Text = "使用中" Then
                btnDisable.Visible = True
            ElseIf lbisDisable.Text = "停用" Then
                btnEnable.Visible = True
            End If
        End If
    End Sub

    Protected Sub btnEnable_Click(sender As Object, e As EventArgs) 'Original Disable
        Dim gvr As GridViewRow = CType(sender, Button).NamingContainer
        Dim lbNotes As Label = CType(gvr.FindControl("lbNotes"), Label)
        Dim btnETextBox As TextBox = CType(gvr.FindControl("btnETextBox"), TextBox)
        Dim btnEnable As Button = CType(gvr.FindControl("btnEnable"), Button)
        Dim btnOK As Button = CType(gvr.FindControl("btnOK"), Button)
        Dim btnCancel As Button = CType(gvr.FindControl("btnCancel"), Button)
        lbNotes.Visible = False
        btnETextBox.Visible = True 'Enable Reason
        btnEnable.Visible = False
        btnOK.Visible = True
        btnCancel.Visible = True
    End Sub
    Protected Sub btnDisable_Click(sender As Object, e As EventArgs) 'Original Enable
        Dim gvr As GridViewRow = CType(sender, Button).NamingContainer
        Dim lbNotes As Label = CType(gvr.FindControl("lbNotes"), Label)
        Dim btnDTextBox As TextBox = CType(gvr.FindControl("btnDTextBox"), TextBox)
        Dim btnDisable As Button = CType(gvr.FindControl("btnDisable"), Button)
        Dim btnOK As Button = CType(gvr.FindControl("btnOK"), Button)
        Dim btnCancel As Button = CType(gvr.FindControl("btnCancel"), Button)
        lbNotes.Visible = False
        btnDTextBox.Visible = True 'Disable Reason
        btnDisable.Visible = False
        btnOK.Visible = True
        btnCancel.Visible = True
    End Sub
    Protected Sub btnOK_Click(sender As Object, e As EventArgs) 'Confirm Selected
        Dim gvr As GridViewRow = CType(sender, Button).NamingContainer
        Dim lbId_card As Label = CType(gvr.FindControl("lbId_card"), Label)
        Dim lbUser_name As Label = CType(gvr.FindControl("lbUser_name"), Label)
        Dim lbisDisable As Label = CType(gvr.FindControl("lbisDisable"), Label)
        Dim btnETextBox As TextBox = CType(gvr.FindControl("btnETextBox"), TextBox)
        Dim btnDTextBox As TextBox = CType(gvr.FindControl("btnDTextBox"), TextBox)
        Dim lbUnique_id As Label = CType(gvr.FindControl("lbUnique_id"), Label)
        Dim btnOK As Button = CType(gvr.FindControl("btnOK"), Button)
        Dim btnCancel As Button = CType(gvr.FindControl("btnCancel"), Button)
        Dim dt As DataTable = New DataTable
        Dim bll As New EMP3109

        If btnETextBox.Visible = True Then 'Original Disable
            lbisDisable.Text = "0"
            bll.getUpdateData(lbId_card.Text.ToString, lbisDisable.Text.ToString, lbUnique_id.Text, btnETextBox.Text)
            btnQuery_Click(sender, e)
        End If

        If btnDTextBox.Visible = True Then 'Original Enable
            lbisDisable.Text = "1"
            bll.getUpdateData(lbId_card.Text, lbisDisable.Text, lbUnique_id.Text, btnDTextBox.Text)
            btnQuery_Click(sender, e)
        End If

        btnOK.Enabled = False
        btnCancel.Enabled = False
    End Sub
    Protected Sub btnCancel_Click(sender As Object, e As EventArgs)
        Dim gvr As GridViewRow = CType(sender, Button).NamingContainer
        btnQuery_Click(sender, e)
    End Sub
End Class
