Imports System.Data
Imports FSCPLM.Logic
Partial Class MAT2104_01
    Inherits BaseWebForm
#Region " 初始化"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then
            Return
        End If
        UcMaterialClassB.Orgcode = LoginManager.OrgCode
        UcMaterialClassE.Orgcode = LoginManager.OrgCode
    End Sub
#End Region
#Region " 查詢"
    Protected Sub SelectBtn_Click(sender As Object, e As EventArgs) Handles SelectBtn.Click
        Dim db As New DataTable
        Dim mc As MAT2104 = New MAT2104()
        If Not CommonFun.IsNum(Material_idS.Text) Or Not CommonFun.IsNum(Material_idE.Text) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "「物料編號」為數字。")
            Return
        End If
        db = mc.MAT2104SelectData(Server.HtmlEncode(In_dateS.Text), Server.HtmlEncode(In_dateE.Text), Server.HtmlEncode(Material_idS.Text), Server.HtmlEncode(Material_idE.Text))
        Me.GridViewA.DataSource = db
        Me.GridViewA.DataBind()
        Me.div1.Visible = True
    End Sub
#End Region
#Region " 重置"
    Protected Sub ResetBtn_Click(sender As Object, e As EventArgs)
        In_dateS.Text = ""
        In_dateE.Text = ""
        Material_idS.Text = ""
        Material_idE.Text = ""
        Me.div1.Visible = False
    End Sub
#End Region
#Region "列印"
    Protected Sub PrintBtn_Click(sender As Object, e As EventArgs) Handles PrintBtn.Click
        Dim url As String = "MAT2104_02.aspx"
        url &= "?pagerowcnt=" & Server.HtmlEncode(DirectCast(Ucpager1.FindControl("tbRowOfPage"), TextBox).Text)
        If Not String.IsNullOrEmpty(Server.HtmlEncode(In_dateS.Text)) Then
            url &= "&In_dateS=" & Server.HtmlEncode(In_dateS.Text)
        End If
        If Not String.IsNullOrEmpty(Server.HtmlEncode(In_dateE.Text)) Then
            url &= "&In_dateE=" & Server.HtmlEncode(In_dateE.Text)
        End If
        If Not String.IsNullOrEmpty(Server.HtmlEncode(Material_idS.Text)) Then
            url &= "&Material_idS=" & Server.HtmlEncode(Material_idS.Text)
        End If
        If Not String.IsNullOrEmpty(Server.HtmlEncode(Material_idE.Text)) Then
            url &= "&Material_idE=" & Server.HtmlEncode(Material_idE.Text)
        End If
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


