Imports System.Data
Imports FSCPLM.Logic
Partial Class MAT2201_01
    Inherits BaseWebForm

#Region " 初始化"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then
            Return
        End If
        Material_detS.Orgcode = LoginManager.OrgCode
        Material_detE.Orgcode = LoginManager.OrgCode
    End Sub
#End Region
#Region " 查詢" '測試資料用
    Protected Sub SelectBtn_Click(sender As Object, e As EventArgs)
        If Not CommonFun.IsNum(Material_idS.Text) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "請輸入物料編號(起)")
        End If
        If Not CommonFun.IsNum(Material_idE.Text) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "請輸入物料編號(迄)")
        End If
    End Sub
#End Region
#Region " 重置"
    Protected Sub ResetBtn_Click(sender As Object, e As EventArgs)
        Material_idS.Text = ""
        Material_idE.Text = ""
        Me.div1.Visible = False
    End Sub
#End Region
#Region " 列印"
    Protected Sub PrintBtn_Click(sender As Object, e As EventArgs)
        Dim url As String = ""
        If Not CommonFun.IsNum(Material_idS.Text) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "物料編號只能輸入數字")
            Return
        End If
        If Not CommonFun.IsNum(Material_idE.Text) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "物料編號只能輸入數字")
            Return
        End If
        url = "MAT2201_02.aspx"
        url &= "?pagerowcnt=" & Server.HtmlEncode(DirectCast(Ucpager1.FindControl("tbRowOfPage"), TextBox).Text)
        If Not String.IsNullOrEmpty(Server.HtmlEncode(Material_idS.Text)) Then
            url &= "&Material_idS=" & Server.HtmlEncode(Material_idS.Text)
        End If
        If Not String.IsNullOrEmpty(Server.HtmlEncode(Material_idE.Text)) Then
            url &= "&Material_idE=" & Server.HtmlEncode(Material_idE.Text)
        End If
        Response.Redirect(url)
    End Sub
#End Region
#Region "資料表控制" '測試資料用
    Protected Sub EnterBtn(sender As Object, e As EventArgs)

    End Sub
#End Region
    Protected Sub UcMaterialClassB_Checked(sender As Object, e As EventArgs)
        Material_idS.Text = Material_detS.MaterialId
    End Sub

    Protected Sub UcMaterialClassE_Checked(sender As Object, e As EventArgs)
        Material_idE.Text = Material_detE.MaterialId
    End Sub
End Class


