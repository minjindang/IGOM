
Partial Class UControl_SYS_UcComment
    Inherits System.Web.UI.UserControl


    Public Property FormId() As String
        Get
            Return hfFormId.Value
        End Get
        Set(ByVal value As String)
            hfFormId.Value = value
            Bind()
        End Set
    End Property

    Public Property Text() As String
        Get
            Return tbComment.Text
        End Get
        Set(value As String)
            tbComment.Text = value
        End Set
    End Property

    Protected Sub Bind()
        If String.IsNullOrEmpty(hfFormId.Value) Then
            Return
        End If

        Dim orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim k As String = hfFormId.Value.Substring(0, 3)
        Dim t As String = hfFormId.Value.Substring(3)
        Dim p As New SYS.Logic.CommonPhrases()
        ddlPhases.DataSource = p.getData(orgcode, k, t, "", "1")
        ddlPhases.DataBind()
    End Sub

    Protected Sub cbConfirm_Click(sender As Object, e As EventArgs)
        btnQuery_ModalPopupExtender.Hide()
        If ddlPhases.SelectedIndex >= 0 Then
            tbComment.Text = ddlPhases.SelectedItem.Text
        End If
    End Sub

    Protected Sub cbCancel_Click(sender As Object, e As EventArgs)
        btnQuery_ModalPopupExtender.Hide()
    End Sub
End Class
