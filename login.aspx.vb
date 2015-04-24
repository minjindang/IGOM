Imports System
Imports System.Data
Imports System.Web
Imports IGOM.Logic
Imports EMP.Logic

Partial Class login
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnLogin_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnLogin.Click
        'Dim code As String = Session("CheckCode")
        'If code <> tbcode.Text.Trim().ToUpper() Then
        '    CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "驗證碼錯誤")
        '    tbcode.Text = ""
        '    Return
        'End If

        Login()
    End Sub

    Public Sub Login()
        Dim messageInfo As String = LoginInfo.CheckAccPass(txtAcc.Text.Trim())

        If Not String.IsNullOrEmpty(txtAcc.Text.Trim()) AndAlso Not "".Equals(messageInfo) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, messageInfo)
            Return
        End If

        Dim psn As FSC.Logic.Personnel = New FSC.Logic.Personnel().GetObject(txtAcc.Text.Trim())
        If psn IsNot Nothing Then
            SetAuthen(psn)
        Else
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "帳號密碼錯誤!")
        End If

    End Sub

    Public Sub SetAuthen(ByVal psn As FSC.Logic.Personnel)
        Dim Account As String = psn.IdCard  '登入者員工編號
        Dim RoleId As String = ""               '角色代號
        Dim LoginStatus As String = "1"

        Dim UserData As String = LoginInfo.GetUserData(psn, Account)

        If String.IsNullOrEmpty(UserData) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "登入失敗!")
        Else
            '設定驗證票
            LoginManager.SetAuthenTicket(UserData, Account)

            If "0".Equals(LoginStatus) Then
                CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "第一次登入，請先修改密碼", "FSC1/FSC15/FSC1503_01.aspx")
            ElseIf RoleId.IndexOf("SysAdmin") >= 0 Then
                Response.Redirect("FSC4/FSC42/FSC4201_01.aspx")
            Else
                Response.Redirect("FSC/FSC0/FSC0101_01.aspx")
            End If
        End If

    End Sub
End Class
