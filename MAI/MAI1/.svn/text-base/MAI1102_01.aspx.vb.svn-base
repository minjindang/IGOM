Imports FSCPLM.Logic
Partial Class MAT_MAT1_MAI1102_01
    Inherits BaseWebForm

    Dim dao As New MAI1102


    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
            lblUserInfo.Text = LoginManager.GetTicketUserData(LoginManager.LoginUserData.DepartName) & " " & LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name)
        End If

    End Sub

    Protected Sub DoneBtn_Click(sender As Object, e As EventArgs) Handles DoneBtn.Click
        Dim msg As String = CheckRequire()
       

        If String.IsNullOrEmpty(msg) Then
            Try

                dao.Insert01(txtPhone_nos.Text, LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id), LoginManager.UserId, _
                       ucMtSys_type.SelectedValue, Now, LoginManager.OrgCode, LoginManager.UserId, Now)
            Catch ex As Exception
                CommonFun.MsgShow(Page, CommonFun.Msg.Custom, ex.Message)
            End Try
        Else
            CommonFun.MsgShow(Page, CommonFun.Msg.Custom, msg)
        End If
    End Sub

    Protected Sub lbMaintain_Click(sender As Object, e As EventArgs) Handles lbMaintain.Click
    
        If String.IsNullOrEmpty(txtPhone_nos.Text) Then
            Page.Response.Redirect("~/MAI/MAI1/MAI1102_02.aspx")
        Else
            Page.Response.Redirect("~/MAI/MAI1/MAI1102_02.aspx?Phone_nos=" & HttpUtility.UrlEncode(txtPhone_nos.Text))
        End If
    End Sub

    Private Function CheckRequire() As String
        Dim msg As String = String.Empty
        If String.IsNullOrEmpty(txtPhone_nos.Text) Then
            msg &= "請輸入報修人聯絡分機"
        End If
        If String.IsNullOrEmpty(ucMtSys_type.SelectedValue) Then
            msg &= "請選擇報修系統"
        End If
        Return msg
    End Function

End Class
