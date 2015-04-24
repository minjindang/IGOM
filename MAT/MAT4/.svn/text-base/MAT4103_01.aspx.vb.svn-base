Imports System.Data
Imports FSCPLM.Logic

Partial Class MAT4103_01
    Inherits BaseWebForm

    Dim dao As New MAT4103

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        checkConfirm()

        If Not Page.IsPostBack Then
            Me.ddlMaterialClass_id.DataSource = dao.GetDataByOrgCode(LoginManager.OrgCode)
            Me.ddlMaterialClass_id.DataTextField = "MaterialClass_name"
            Me.ddlMaterialClass_id.DataValueField = "MaterialClass_id"
            Me.ddlMaterialClass_id.DataBind()

            UcMaterialId.Orgcode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        End If

    End Sub

    Protected Sub ddlMaterialClass_id_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlMaterialClass_id.SelectedIndexChanged

        Me.txtNewMaterial_id.Text = ddlMaterialClass_id.SelectedValue

    End Sub

    Protected Sub SaveBtn_Click(sender As Object, e As EventArgs) Handles SaveBtn.Click
        Dim msg As String = String.Empty

        If String.IsNullOrEmpty(Me.txtMaterial_id.Text) OrElse Me.txtMaterial_id.Text.Length <> 9 Then
            msg += "物料編號長度需為9碼\n"
        End If

        If String.IsNullOrEmpty(Me.txtNewMaterial_id.Text) OrElse Me.txtNewMaterial_id.Text.Length <> 9 Then
            msg += "新的物料編號長度需為9碼\n"
        End If

        If Not CommonFun.IsNum(Me.txtNewMaterial_id.Text) Then
            msg += "新的物料編號請輸入數字\n"
        End If

        Dim dr As DataRow = dao.GetMatData(Me.txtNewMaterial_id.Text)
        If Not dr Is Nothing Then
            msg += "新的物料編號不可重覆存在\n"
        End If


        If Not String.IsNullOrEmpty(msg) Then
            CommonFun.MsgShow(Me.Page, CommonFun.Msg.Custom, msg)
        Else
            Dim matCount As Integer = dao.GetMatCount(Me.txtMaterial_id.Text)


            'Me.lblMsg.Text = String.Format("分類號已調整，預計修改筆數共{0}筆，是否確認修改?", matCount)
            CommonFun.MsgConfirm2(Me.Page, String.Format("分類號已調整，預計修改筆數共{0}筆，是否確認修改?", matCount), "__doPostBack('ApplyAgain','Y')", "__doPostBack('ApplyAgain','N')")

            If txtMaterial_id.Text.Substring(0, 5) <> txtNewMaterial_id.Text.Substring(0, 5) Then
                CommonFun.MsgConfirm2(Me.Page, String.Format("分類號已調整，預計修改筆數共{0}筆，是否確認修改?", matCount), "__doPostBack('ApplyAgain','Y')", "__doPostBack('ApplyAgain','N')")
                'Me.lblMsg.Text = String.Format("分類號已調整，預計修改筆數共{0}筆，是否確認修改?", matCount)
            End If
            Me.Panel1.Visible = True
        End If

    End Sub

    Public Sub confirm(ByVal Message As String, ByVal TrueScript As String, ByVal FalseScript As String)
        Dim sScript As String
        sScript = String.Format("if (confirm('{0}')){{ {1} }} else {{ {2} }};", Message, TrueScript, FalseScript)
        Me.ClientScript.RegisterStartupScript(GetType(String), "confirm", sScript, True)
    End Sub

    Protected Sub checkConfirm()
        Dim target As String = Me.Request.Form("__EVENTTARGET")
        Dim argument As String = Me.Request.Form("__EVENTARGUMENT")

        '按了確定要執行的程式碼
        If target = "ApplyAgain" Then
            If argument = "Y" Then
                Try
                    dao.Update(txtMaterial_id.Text, txtNewMaterial_id.Text, LoginManager.UserId, LoginManager.OrgCode, Now)
                    CommonFun.MsgShow(Me.Page, CommonFun.Msg.Custom, "修改完成")
                    Me.Panel1.Visible = False
                    CommonFun.ClearContentPlaceHolder(Me.Master)
                Catch ex As Exception
                    CommonFun.MsgShow(Page, CommonFun.Msg.Custom, ex.Message)
                End Try
            End If
        End If

        
    End Sub

    Protected Sub btnY_Click(sender As Object, e As EventArgs) Handles btnY.Click
        Try
            dao.Update(txtMaterial_id.Text, txtNewMaterial_id.Text, LoginManager.UserId, LoginManager.OrgCode, Now)
            CommonFun.MsgShow(Me.Page, CommonFun.Msg.Custom, "修改完成")
            Me.Panel1.Visible = False
            CommonFun.ClearContentPlaceHolder(Me.Master)
        Catch ex As Exception
            CommonFun.MsgShow(Page, CommonFun.Msg.Custom, ex.Message)
        End Try
    End Sub

    Protected Sub btnN_Click(sender As Object, e As EventArgs) Handles btnN.Click
        Me.Panel1.Visible = False
    End Sub

    Protected Sub RestoreBtn_Click(sender As Object, e As EventArgs) Handles RestoreBtn.Click

        CommonFun.ClearContentPlaceHolder(Me.Master)
    End Sub

    Protected Sub txtMaterial_id_TextChanged(sender As Object, e As EventArgs) Handles txtMaterial_id.TextChanged
        If Not CommonFun.IsNum(Me.txtMaterial_id.Text) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "原物料編號請輸入數字!")
            Me.txtUnit.Text = ""
            Me.txtMaterial_name.Text = ""
            Return
        End If
        gettMaterial()
    End Sub

    Protected Sub UcMaterialId_Checked(sender As Object, e As EventArgs)
        txtMaterial_id.Text = UcMaterialId.MaterialId
        gettMaterial()
    End Sub

    Protected Sub gettMaterial()
        Dim dr As DataRow = dao.GetMatData(Me.txtMaterial_id.Text)
        If Not dr Is Nothing Then
            Me.txtUnit.Text = CommonFun.SetDataRow(dr, "Unit")
            Me.txtMaterial_name.Text = CommonFun.SetDataRow(dr, "Material_name")
        Else
            Me.txtUnit.Text = ""
            Me.txtMaterial_name.Text = ""
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "此物料編號不存在!")
        End If
    End Sub
End Class
