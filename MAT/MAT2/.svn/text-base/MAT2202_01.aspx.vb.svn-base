Imports FSCPLM.Logic
Imports System.Data
Imports System.Data.SqlClient

Partial Class MAT2202_01
    Inherits BaseWebForm

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Dim url As String = "MAT2202_01.aspx"
        'url &= "?pagerowcnt=25"
        'If Not String.IsNullOrEmpty(tbMaterial_id1.Text) Then
        '    url &= "&tb1=" & Server.HtmlEncode(tbMaterial_id1.Text)
        'End If
        'If Not String.IsNullOrEmpty(tbMaterial_id2.Text) Then
        '    url &= "&tb2=" & Server.HtmlEncode(tbMaterial_id2.Text)
        'End If
        'If Not String.IsNullOrEmpty(UcDate1.Text) Then
        '    url &= "&tb3=" & Server.HtmlEncode(UcDate1.Text)
        'End If
        'If Not String.IsNullOrEmpty(UcDate2.Text) Then
        '    url &= "&tb4=" & Server.HtmlEncode(UcDate2.Text)
        'End If
        If IsPostBack Then
            Return
        End If
        UcMaterialClassB.Orgcode = LoginManager.OrgCode
        UcMaterialClassE.Orgcode = LoginManager.OrgCode
    End Sub

    Public Sub ResetBtn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ResetBtn.Click
        CommonFun.ClearContentPlaceHolder(Me.Master)
    End Sub
    Protected Sub UcMaterialClassB_Checked(sender As Object, e As EventArgs)
        tbMaterial_id1.Text = UcMaterialClassB.MaterialId
    End Sub

    Protected Sub UcMaterialClassE_Checked(sender As Object, e As EventArgs)
        tbMaterial_id2.Text = UcMaterialClassE.MaterialId
    End Sub

    Protected Sub PrintBtn_Click(sender As Object, e As EventArgs)

        If Not CommonFun.IsNum(tbMaterial_id1.Text) Or Not CommonFun.IsNum(tbMaterial_id2.Text) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "物料編號請輸入數字!")
            Return
        End If


        Dim url As String = "MAT2202_02.aspx"
        url &= "?pagerowcnt=25"
        If Not String.IsNullOrEmpty(tbMaterial_id1.Text) Then
            url &= "&tb1=" & Server.HtmlEncode(tbMaterial_id1.Text)
        End If
        If Not String.IsNullOrEmpty(tbMaterial_id2.Text) Then
            url &= "&tb2=" & Server.HtmlEncode(tbMaterial_id2.Text)
        End If
        If Not String.IsNullOrEmpty(UcDate1.Text) Then
            url &= "&tb3=" & Server.HtmlEncode(UcDate1.Text)
        End If
        If Not String.IsNullOrEmpty(UcDate2.Text) Then
            url &= "&tb4=" & Server.HtmlEncode(UcDate2.Text)
        End If
        Response.Redirect(url)
    End Sub

    Protected Sub QueryBtn_Click(sender As Object, e As EventArgs) Handles QueryBtn.Click
        Dim InventoryDet As InventoryDet = New InventoryDet()
        Dim DT As DataTable = CType((InventoryDet.MAT2202select(tbMaterial_id1.Text, tbMaterial_id2.Text, UcDate1.Text, UcDate2.Text)), DataTable)

        gvlist.DataSource = DT
        gvlist.DataBind()

        tbq.Visible = True
        Ucpager.Visible = DT IsNot Nothing AndAlso DT.Rows.Count > 0
    End Sub
End Class
