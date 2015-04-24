Imports System.Data
Imports FSCPLM.Logic
Partial Class MAT2102_01
    Inherits BaseWebForm
#Region " 初始化"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then
            Return
        End If
         
        UcMaterialClassB.Orgcode = LoginManager.OrgCode
        UcMaterialClassE.Orgcode = LoginManager.OrgCode

        showddl()
        Dim Role_id As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.RoleId)
        If (Not Role_id.Contains("TackleAdmin") AndAlso Not Role_id.Contains("DeptHead") AndAlso Not Role_id.Contains("MAT_UnitWindow")) Then
            ucType.SelectedValue = "001"
            tdType.Attributes.Add("disabled", "disabled")
        Else
            ucType.SelectedValue = "001"
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

#End Region
#Region " 查詢"
    Protected Sub SelectBtn_Click(sender As Object, e As EventArgs) Handles SelectBtn.Click
        If Not CommonFun.IsNum(Material_idS.Text) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "物料編號只能輸入數字")
            Return
        End If
        If Not CommonFun.IsNum(Material_idE.Text) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "物料編號只能輸入數字")
            Return
        End If
        Dim db As New DataTable
        Dim mc As MAT2102 = New MAT2102()
        db = mc.MAT2102SelectData(ucType.Code_no, SortRadioButtonList.SelectedValue, Material_idS.Text, Material_idE.Text, ReceiveS.Text, ReceiveE.Text, ddlDepart_id.SelectedValue, ddlUser_name.SelectedValue)
        Me.GridViewA.DataSource = db
        Me.GridViewA.DataBind()
        Me.div1.Visible = True
    End Sub
#End Region
#Region " 重置"
    Protected Sub ResetBtn_Click(sender As Object, e As EventArgs)
        ReceiveS.Text = ""
        ReceiveE.Text = ""
        Material_idS.Text = ""
        Material_idE.Text = ""
        'User_name.Text = ""
        'ApplyRadioButton.Items(0).Selected = True
        'ApplyRadioButton.Items(1).Selected = False
        ''ApplyRadioButton.Items(2).Selected = False
        'UcDDLDepart.SelectedValue = ""
        SortRadioButtonList.Items(0).Selected = True
        SortRadioButtonList.Items(1).Selected = False
        SortRadioButtonList.Items(2).Selected = False
        PagingRadioButtonList.Items(0).Selected = True
        PagingRadioButtonList.Items(1).Selected = False
        PagingRadioButtonList.Items(2).Selected = False
        Me.div1.Visible = False
        CommonFun.ClearContentPlaceHolder(Me.Master)
        showddl()
    End Sub
#End Region
#Region "列印"
    Protected Sub PrintBtn_Click(sender As Object, e As EventArgs) Handles PrintBtn.Click
        Dim url As String = "MAT2102_02.aspx"
        url &= "?pagerowcnt=" & Server.HtmlEncode(DirectCast(Ucpager1.FindControl("tbRowOfPage"), TextBox).Text)
        If Not String.IsNullOrEmpty(Server.HtmlEncode(ReceiveS.Text)) Then
            url &= "&ReceiveS=" & Server.HtmlEncode(ReceiveS.Text)
        End If
        If Not String.IsNullOrEmpty(Server.HtmlEncode(ReceiveE.Text)) Then
            url &= "&ReceiveE=" & Server.HtmlEncode(ReceiveE.Text)
        End If
        If Not String.IsNullOrEmpty(Server.HtmlEncode(Material_idS.Text)) Then
            url &= "&Material_idS=" & Server.HtmlEncode(Material_idS.Text)
        End If
        If Not String.IsNullOrEmpty(Server.HtmlEncode(Material_idE.Text)) Then
            url &= "&Material_idE=" & Server.HtmlEncode(Material_idE.Text)
        End If
        If Not String.IsNullOrEmpty(Server.HtmlEncode(ddlUser_name.SelectedValue)) Then
            url &= "&User_name=" & Server.HtmlEncode(ddlUser_name.SelectedValue)
        End If
        If Not String.IsNullOrEmpty(Server.HtmlEncode(ucType.Code_no)) Then
            url &= "&ApplyRadioButton=" & Server.HtmlEncode(ucType.Code_no)
        End If
        If Not String.IsNullOrEmpty(Server.HtmlEncode(ddlDepart_id.SelectedValue)) Then
            url &= "&OrgCodeDropDownList=" & Server.HtmlEncode(ddlDepart_id.SelectedValue)
        End If
        If Not String.IsNullOrEmpty(Server.HtmlEncode(SortRadioButtonList.SelectedValue)) Then
            url &= "&SortRadioButtonList=" & Server.HtmlEncode(SortRadioButtonList.SelectedValue)
        End If
        If Not String.IsNullOrEmpty(Server.HtmlEncode(PagingRadioButtonList.SelectedValue)) Then
            url &= "&PagingRadioButtonList=" & Server.HtmlEncode(PagingRadioButtonList.SelectedValue)
        End If
        '觸發列印按鈕
        'Response.Write("<script>window.open('" & url & "','','menubar=no,status=no,scrollbars=yes,top=100,left=200,toolbar=no,width=800,height=600')</script>;")

        Response.Redirect(url)
    End Sub
#End Region

    Protected Sub UcMaterialClassB_Checked(sender As Object, e As EventArgs)
        Material_idS.Text = UcMaterialClassB.MaterialId
    End Sub

    Protected Sub UcMaterialClassE_Checked(sender As Object, e As EventArgs)
        Material_idE.Text = UcMaterialClassE.MaterialId


    End Sub
End Class


