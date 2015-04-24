Imports FSCPLM.Logic
Imports System
Imports System.Data

Partial Class MAT2106_01
    Inherits BaseWebForm

    Dim OrgCode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
    Dim MAT2106 As ApplyMaterialDet = New ApplyMaterialDet()

    Public Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            showddl()
            Dim Role_id As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.RoleId)
            If (Not Role_id.Contains("TackleAdmin") AndAlso Not Role_id.Contains("DeptHead") AndAlso Not Role_id.Contains("MAT_UnitWindow")) Then
                ucType.SelectedValue = "001"
                tdType.Attributes.Add("disabled", "disabled")
            Else
                ucType.SelectedValue = "001"
            End If
        End If

    End Sub
    Protected Sub Depart_Bind()
        ddlDepart_id.Orgcode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
    End Sub

    Protected Sub UcDDLDepart_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlDepart_id.SelectedIndexChanged
        UserName_Bind()
    End Sub

    Private Sub UserName_Bind()
        ddlUser_name.Orgcode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        ddlUser_name.DepartId = ddlDepart_id.SelectedValue
    End Sub

    Public Sub showddl()
        Depart_Bind()
        UserName_Bind()
    End Sub

    Public Sub ResetBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ResetBtn.Click
        CommonFun.ClearContentPlaceHolder(Me.Master)
        showddl()
    End Sub

    Public Sub PrintBtn_click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintBtn.Click
        PrintBtnClick()
    End Sub

    Public Sub PrintBtnClick()

        Dim url As String = "MAT2106_02.aspx"
        url &= "?pagerowcnt=25"
        If Not String.IsNullOrEmpty(ucType.SelectedValue) Then
            url &= "&tb1=" & Server.HtmlEncode(ucType.SelectedValue)
        End If
        If Not String.IsNullOrEmpty(ddlDepart_id.SelectedValue) Then
            url &= "&tb2=" & Server.HtmlEncode(ddlDepart_id.SelectedValue)
        End If
        If Not String.IsNullOrEmpty(ddlUser_name.SelectedValue) Then
            url &= "&tb3=" & Server.HtmlEncode(ddlUser_name.SelectedValue)
        End If
        'Response.Write(ucType.SelectedValue & ddlDepart_id.SelectedValue & ddlUser_name.SelectedValue)
        ' PrintBtn.OnClientClick = " window.open('" & url & "','','menubar=no,status=no,scrollbars=yes,top=100,left=200,toolbar=no,width=800,height=600')"
        'Me.ClientScript.RegisterStartupScript(Me.GetType(), "Open", "window.open('" & url & ");", True)
        'Response.Write("<script>window.open('" & url & "','','menubar=no,status=no,scrollbars=yes,top=100,left=200,toolbar=no,width=800,height=600')</script>")
        Response.Redirect(url)
    End Sub

End Class
