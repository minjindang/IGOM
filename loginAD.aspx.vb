Imports System
Imports System.Data
Imports System.Web
Imports IGOM.Logic
Imports EMP.Logic
Imports System.Collections.Generic

Partial Class loginAD
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Login()
    End Sub

    Public Sub Login()
        If Request.LogonUserIdentity.IsAuthenticated Then
            Dim AD_id As String = Request.LogonUserIdentity.Name.Split("\")(1)

            Dim psn As FSC.Logic.Personnel = Nothing
            Dim dt As DataTable = New FSC.Logic.Personnel().GetDataByADid(AD_id)
            Dim list As List(Of FSC.Logic.Personnel) = CommonFun.ConvertToList(Of FSC.Logic.Personnel)(dt)
            If list IsNot Nothing AndAlso list.Count > 0 Then
                psn = list(0)
            End If

            If psn IsNot Nothing Then
                SetAuthen(psn)
            Else
                Response.Write("<script>alert('使用者：" + AD_id + "認證失敗!');window.opener = null; window.open('','_self'); window.close();</script>")
            End If
        Else
            Response.Write("<script>alert('認證失敗!');window.opener = null; window.open('','_self'); window.close();</script>")
        End If

    End Sub

    Public Sub SetAuthen(ByVal psn As FSC.Logic.Personnel)
        Dim Account As String = psn.IdCard  '登入者員工編號
        Dim RoleId As String = ""               '角色代號
        Dim LoginStatus As String = "1"

        Dim UserData As String = LoginInfo.GetUserData(psn, Account)

        If String.IsNullOrEmpty(UserData) Then
            Response.Write("<script>alert('使用者：" + psn.ADId + "認證失敗!');window.opener = null; window.open('','_self'); window.close();</script>")
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
