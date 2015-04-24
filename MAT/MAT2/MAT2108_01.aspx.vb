Imports FSCPLM.Logic
Imports System
Imports System.Data

Partial Class MAT2108_01
    Inherits BaseWebForm

    Dim OrgCode As String = LoginManager.OrgCode


    Public Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then
            Return
        End If
        showddl()
        MATselect1.Orgcode = LoginManager.OrgCode
        MATselect2.Orgcode = LoginManager.OrgCode
    End Sub

    Public Sub showddl()
        ddlyear.Items.Clear()
        Dim i As Integer = Now.Year
        While i > Now.Year - 15
            Me.ddlyear.Items.Add(New ListItem(Right("000" & (i - 1911), 3), Right("000" & (i - 1911), 3)))
            i -= 1
        End While
    End Sub

    Public Sub ResetBtn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ResetBtn.Click
        CommonFun.ClearContentPlaceHolder(Me.Master)
    End Sub
    Protected Sub UcMaterialClassB_Checked(sender As Object, e As EventArgs)
        tbMaterial_id1.Text = MATselect1.MaterialId
    End Sub

    Protected Sub UcMaterialClassE_Checked(sender As Object, e As EventArgs)
        tbMaterial_id2.Text = MATselect2.MaterialId
    End Sub

    Protected Sub PrintBtn_Click(sender As Object, e As EventArgs) Handles PrintBtn.Click
        Dim url As String = "MAT2108_02.aspx"
        If Not CommonFun.IsNum(tbMaterial_id1.Text) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "物料編號只能輸入數字")
            Return
        End If
        If Not CommonFun.IsNum(tbMaterial_id2.Text) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "物料編號只能輸入數字")
            Return
        End If
        url &= "?pagerowcnt=25"
        If Not String.IsNullOrEmpty(tbMaterial_id1.Text) Then
            url &= "&tb1=" & Server.HtmlEncode(tbMaterial_id1.Text)
        End If
        If Not String.IsNullOrEmpty(tbMaterial_id2.Text) Then
            url &= "&tb2=" & Server.HtmlEncode(tbMaterial_id2.Text)
        End If
        If Not String.IsNullOrEmpty(ddlyear.SelectedValue) Then
            url &= "&tb3=" & Server.HtmlEncode(ddlyear.SelectedValue)
        End If
        Response.Redirect(url)
        'PrintBtn.OnClientClick = " window.open('" & url & "','','menubar=no,status=no,scrollbars=yes,top=100,left=200,toolbar=no,width=800,height=600')"
    End Sub
End Class
