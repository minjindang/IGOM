Imports System.Data
Imports System.Data.SqlClient
Imports SYS.Logic
Imports System.Transactions

Partial Class SYS3116_02
    Inherits BaseWebForm

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then
            Return
        End If

        UcDDLForm.Orgcode = LoginManager.OrgCode
        ' 依傳入值顯示相關資料
        Bind()
    End Sub

    ''' <summary>
    ''' 「取消」按鈕
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub cbCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbCancel.Click
        Response.Redirect("SYS3116_01.aspx?fid=" & Request.QueryString("fid"))
    End Sub

    ''' <summary>
    ''' 「確認」按鈕
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub cbConfirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbConfirm.Click
        Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim formId As String = Request.QueryString("fid")
        Dim fs As New FormSetting()

        If String.IsNullOrEmpty(UcDDLForm.SelectedValue) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "請輸入表單類型!")
            Return
        End If

        fs.Orgcode = Orgcode
        fs.Form_id = UcDDLForm.selectedvalue
        fs.Describe = tbDesc.Text.Trim()
        fs.Ifattach_flag = rblReAttachYN.SelectedValue
        fs.Change_userid = LoginManager.UserId

        If Not String.IsNullOrEmpty(formId) Then
            fs.Update()
            CommonFun.MsgShow(Me, CommonFun.Msg.UpdateOK)
        Else
            Dim dt As DataTable = fs.GetDataByFormId(Orgcode, UcDDLForm.SelectedValue)
            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "已有該表單規則!")
                Return
            End If
            fs.Insert()
            CommonFun.MsgShow(Me, CommonFun.Msg.InsertOK)
        End If

    End Sub

    Protected Sub Bind()
        Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim formId As String = Request.QueryString("fid")
        Dim fs As New FormSetting()

        If Not String.IsNullOrEmpty(formId) Then
            Dim dt As DataTable = fs.GetDataByFormId(Orgcode, formId)

            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                UcDDLForm.Enabled = False
                UcDDLForm.SelectedValue = dt.Rows(0)("Form_id").ToString()
                tbDesc.Text = dt.Rows(0)("Describe").ToString()
                rblReAttachYN.SelectedValue = dt.Rows(0)("Ifattach_flag").ToString()
            End If
        End If
    End Sub

End Class
