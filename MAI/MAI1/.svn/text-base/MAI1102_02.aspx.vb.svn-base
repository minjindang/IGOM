Imports FSCPLM.Logic
Imports System.IO

Partial Class MAI_MAI1_MAI1102_02
    Inherits BaseWebForm

    Dim dao As New MAI1102

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
            lblUserInfo.Text = LoginManager.GetTicketUserData(LoginManager.LoginUserData.DepartName) & " " & LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name)
            txtPhone_nos.Text = HttpUtility.UrlDecode(Request.QueryString("Phone_nos"))

        End If

    End Sub

    Public Sub CodeChanged(sender As Object, e As System.EventArgs) Handles ucMtClass_type.CodeChanged
        ucMtItem_type.Code_type = ucMtClass_type.Code_no
        ucMtItem_type.Rebind()
    End Sub

    Protected Sub DoneBtn_Click(sender As Object, e As EventArgs) Handles DoneBtn.Click
        Dim msg As String = CheckRequire()


        If String.IsNullOrEmpty(msg) Then
            Dim file1Name As String = String.Empty
            Dim file2Name As String = String.Empty

        
            If Me.fuAttachment1.HasFile Then
                file1Name = String.Format("{0}_{1}.{2}", (Now.Year - 1911), Guid.NewGuid().ToString(), Path.GetExtension(fuAttachment1.PostedFile.FileName))
                Me.fuAttachment1.PostedFile.SaveAs(Path.Combine(MapPath("~/fileupload/Attachment/56"), file1Name))
            End If
            If Me.fuAttachment2.HasFile Then
                file2Name = String.Format("{0}_{1}.{2}", (Now.Year - 1911), Guid.NewGuid().ToString(), Path.GetExtension(fuAttachment2.PostedFile.FileName))
                Me.fuAttachment2.PostedFile.SaveAs(Path.Combine(MapPath("~/fileupload/Attachment/56"), file2Name))
            End If
            Try
                dao.Insert02(txtPhone_nos.Text, LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id), LoginManager.UserId, _
                   ucMtClass_type.SelectedValue, ucMtItem_type.SelectedValue, "", "", ucServApply_type.SelectedValue, uc_SfExpect_date.Text, txtProblem_desc.Text, file1Name, file2Name, Now, _
                   LoginManager.OrgCode, LoginManager.UserId, Now)
            Catch ex As Exception
                CommonFun.MsgShow(Page, CommonFun.Msg.Custom, ex.Message)
            End Try
           
        Else
            CommonFun.MsgShow(Page, CommonFun.Msg.Custom, msg)
        End If
    End Sub

    Protected Sub ClrBtnBtn_Click(sender As Object, e As EventArgs) Handles ClrBtn.Click
        CommonFun.ClearContentPlaceHolder(Me.Master)
    End Sub

    Private Function CheckRequire() As String
        Dim msg As String = String.Empty
        If String.IsNullOrEmpty(txtPhone_nos.Text) Then
            msg &= "請輸入報修人聯絡分機\n"
        End If
        'If String.IsNullOrEmpty(ucServApply_type2.SelectedValue) Then
        '    msg &= "請選擇服務類型"
        'End If
        Return msg
    End Function

End Class
