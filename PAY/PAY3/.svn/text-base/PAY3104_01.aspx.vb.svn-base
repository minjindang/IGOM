Imports FSCPLM.Logic


Partial Class PAY_PAY3_PAY3104_01
    Inherits BaseWebForm

    Dim dao As New PAY3104

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            ddlCC.DataSource = dao.GetCCMember(LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id))
            ddlCC.DataTextField = "User_name"
            ddlCC.DataValueField = "Email"
            ddlCC.DataBind()
            txtSubject.Text = "@機關名稱@[零用金發放]通知單"
        End If

    End Sub

    Protected Sub SendBtn_Click(sender As Object, e As EventArgs) Handles SendBtn.Click
        Dim msg As String = String.Empty
        If String.IsNullOrEmpty(txtPCList_id.Text) Then
            msg += "請輸入零用金清單編號\n"
        End If
        If String.IsNullOrEmpty(txtSubject.Text) Then
            msg += "請輸入主旨\n"
        End If
        If String.IsNullOrEmpty(msg) Then
            msg = dao.SendMail(ucFiscalYear_id.Year, txtPCList_id.Text, txtSubject.Text, ddlCC.SelectedItem.Text, ddlCC.SelectedValue)
            If Not String.IsNullOrEmpty(msg) Then
                CommonFun.MsgShow(Page, CommonFun.Msg.Custom, msg)
            End If
        Else
            CommonFun.MsgShow(Page, CommonFun.Msg.Custom, msg)
        End If
    End Sub

End Class
