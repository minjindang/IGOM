Imports FSCPLM.Logic
Imports System.Data
Imports UControl_Pager

Partial Class MAT2103_01
    Inherits BaseWebForm
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then
            Return
        End If
        UcMaterialClassB.Orgcode = LoginManager.OrgCode
        UcMaterialClassE.Orgcode = LoginManager.OrgCode
        'btnPrint.OnClientClick = " window.open('" & url & "','','menubar=no,status=no,scrollbars=yes,top=100,left=200,toolbar=no,width=800,height=600')"
    End Sub

    Protected Sub Btn_Reset(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReset.Click
        material_id1.Text = ""
        material_id2.Text = ""
        'div1.Visible = False
    End Sub

#Region "GirdView"
    Protected Sub btnSelect_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSelect.Click

        Dim db As DataTable = New DataTable
        Dim mat As Material_main = New Material_main
        Dim id1 As String = ""
        Dim id2 As String = ""

        If Not CommonFun.IsNum(material_id1.Text) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "「物料編號(起)」請輸入數字。")
        End If
        If Not CommonFun.IsNum(material_id2.Text) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "「物料編號(迄)」請輸入數字。")
        End If
        If Not String.IsNullOrEmpty(material_id1.Text) Then
            id1 = Server.HtmlEncode(material_id1.Text)
        End If
        If Not String.IsNullOrEmpty(material_id2.Text) Then
            id2 = Server.HtmlEncode(material_id2.Text)
        End If
        db = mat.GetMatData(id1, id2)
        Me.GridView_Uporg.DataSource = db
        Me.GridView_Uporg.DataBind()
        Me.div1.Visible = True
    End Sub
    Protected Sub UcMaterialClassB_Checked(sender As Object, e As EventArgs)
        material_id1.Text = UcMaterialClassB.MaterialId
    End Sub

    Protected Sub UcMaterialClassE_Checked(sender As Object, e As EventArgs)
        material_id2.Text = UcMaterialClassE.MaterialId
    End Sub
#End Region

    Protected Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Dim url As String = "MAT2103_02.aspx"
        url &= "?pagerowcnt=" & Server.HtmlEncode(DirectCast(Ucpager1.FindControl("tbRowOfPage"), TextBox).Text)
        If Not String.IsNullOrEmpty(material_id1.Text) Then
            url &= "&id1=" & Server.HtmlEncode(material_id1.Text)
        End If
        If Not String.IsNullOrEmpty(material_id2.Text) Then
            url &= "&id2=" & Server.HtmlEncode(material_id2.Text)
        End If
        Response.Redirect(url)
    End Sub
End Class
