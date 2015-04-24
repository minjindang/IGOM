Imports FSCPLM.Logic
Imports System
Imports System.Data

Partial Class MAT2107_01
    Inherits BaseWebForm

    Dim OrgCode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
    Dim MAT2107 As ApplyMaterialDet = New ApplyMaterialDet()

    Public Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            showddl()
            UcMaterialClass.Orgcode = LoginManager.OrgCode
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

        Dim url As String = "MAT2107_02.aspx"
        url &= "?pagerowcnt=25"
        If Not String.IsNullOrEmpty(tbMaterial_id.Text) Then
            url &= "&tb1=" & Server.HtmlEncode(tbMaterial_id.Text)
        End If
        If Not String.IsNullOrEmpty(ddlUser_name.SelectedValue) Then
            url &= "&tb2=" & Server.HtmlEncode(ddlUser_name.SelectedValue)
        End If
        If Not String.IsNullOrEmpty(UcDateS.Text) Then
            url &= "&tb3=" & Server.HtmlEncode(UcDateS.Text)
        End If
        If Not String.IsNullOrEmpty(UcDateE.Text) Then
            url &= "&tb4=" & Server.HtmlEncode(UcDateE.Text)
        End If
        If Not String.IsNullOrEmpty(ddlDepart_id.SelectedValue) Then
            url &= "&tb5=" & Server.HtmlEncode(ddlDepart_id.SelectedValue)
        End If
        'Response.Write("<script>window.open('" & url & "','','menubar=no,status=no,scrollbars=yes,top=100,left=200,toolbar=no,width=800,height=600')</script>")
        Response.Redirect(url)
    End Sub

    Protected Sub UcMaterialClass_Checked(sender As Object, e As EventArgs)
        tbMaterial_id.Text = UcMaterialClass.MaterialId
        Dim dr As DataRow = MAT2107.GetMaterialName(tbMaterial_id.Text)
        If Not dr Is Nothing Then
            tbMaterial_name.Text = CommonFun.SetDataRow(dr, "Material_name")
        End If
    End Sub
End Class
