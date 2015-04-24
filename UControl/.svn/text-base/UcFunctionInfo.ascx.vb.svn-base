Imports System.Text
Imports System.data
Imports FSC.Logic

Partial Class FunctionInfo
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load 
        'GetImg()
        checkLogout()

        Dim orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim depart_id As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id)
        'Dim sub_depart_id As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Subdepartment)

        Dim orgcode_name As String = New FSC.Logic.Org().GetOrgcodeName(orgcode)
        'Dim sub_depart_name As String = New FSCorg().GetSubDepartName(orgcode, depart_id, sub_depart_id)

        lbOrgcode_Depart.Text = String.Format(lbOrgcode_Depart.Text, _
                                              orgcode_name, _
                                              LoginManager.GetTicketUserData(LoginManager.LoginUserData.DepartName))

        lblUserName.Text = LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name)
        'lbDeputy_name.Text = New DeputyDet().GetDefalutDeputy("User_name", LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card))

        'Dim con As SqlClient.SqlConnection = New SqlClient.SqlConnection(ConnectDB.GetDBString())
        'Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        'Dim Id_card As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card)

        'Dim Role_id As String = New Member().GetColumnValue("Role_id", Id_card)
        'If String.IsNullOrEmpty(Role_id) Then Return

        'Dim dt As DataTable = New RoleDAO(con).Get_Role(Orgcode, Role_id)

        'If dt Is Nothing OrElse dt.Rows.Count <= 0 Then Return

        'lbRole.Text = "(" & dt.Rows(0)("Role_name").ToString() & ")"
    End Sub

    'Protected Sub GetImg()
    '    Dim path As String() = Split(HttpContext.Current.Request.PhysicalPath, "\")
    '    Dim Func_program_name As String = path(path.Length - 1).Replace(".aspx", "")    '取得目前的頁面 
    '    Dim Func_id As String = Split(Func_program_name, "_")(0)

    '    Dim im As ImgMapping = New ImgMapping()
    '    Dim dt As DataTable = im.GetImgMappingByQuery(Func_id, Func_program_name)

    '    If dt.Rows.Count <= 0 Then Return

    '    img.ImageUrl = dt.Rows(0)("Img_path").ToString() & "/" & dt.Rows(0)("Img_file_name").ToString()
    'End Sub

    Protected Sub ImgLogout_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgLogout.Click
        '記錄登出時間
        Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim Depart_id As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id)
        Dim Id_card As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card)
        IGOM.Logic.LoginInfo.RecordLogin(Orgcode, Depart_id, Id_card, "2")

        FormsAuthentication.SignOut()
        Session.RemoveAll()
        Session.Clear()
        Session.Abandon()

        If LoginManager.GetTicketUserData(LoginManager.LoginUserData.FromAD) = "1" Then
            Response.Write("<script>window.opener = null; window.open('','_self'); window.close();</script>")
        Else
            Response.Redirect("~/Login.aspx")
        End If
    End Sub

    Private Sub checkLogout()
        Dim target As String = Me.Request.Form("__EVENTTARGET")
        Dim argument As String = Me.Request.Form("__EVENTARGUMENT")
        If target = ImgLogout.ClientID Then
            If argument = "True" Then
                doLogout()
            End If
        End If
    End Sub

    Private Sub doLogout()
        Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim Depart_id As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id)
        Dim Id_card As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card)
        IGOM.Logic.LoginInfo.RecordLogin(Orgcode, Depart_id, Id_card, "2")

        FormsAuthentication.SignOut()
        Session.RemoveAll()
        Session.Clear()
        Session.Abandon()

        If LoginManager.GetTicketUserData(LoginManager.LoginUserData.FromAD) = "1" Then
            Response.Write("<script>window.opener = null; window.open('','_self'); window.close();</script>")
        Else
            Response.Redirect("~/Login.aspx")
        End If
    End Sub

End Class
