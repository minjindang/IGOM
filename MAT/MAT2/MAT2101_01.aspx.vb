Imports FSCPLM.Logic
Imports System.Data
Imports UControl_Pager

Partial Class MAT2101_01
    Inherits BaseWebForm

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then 
            showddl()
            UcMaterialClassB.Orgcode = LoginManager.OrgCode
            UcMaterialClassE.Orgcode = LoginManager.OrgCode
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

    Public Sub btnPrint_click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click

        Dim url As String = "MAT2101_02.aspx"
        url &= "?pagerowcnt=" & Server.HtmlEncode(DirectCast(Ucpager1.FindControl("tbRowOfPage"), TextBox).Text)
        If Not String.IsNullOrEmpty(ucType.Code_no) Then
            url &= "&RadioSelect=" & Server.HtmlEncode(ucType.Code_no)
        End If
        If Not String.IsNullOrEmpty(material_id1.Text) Then
            url &= "&id1=" & Server.HtmlEncode(material_id1.Text)
        End If
        If Not String.IsNullOrEmpty(material_id2.Text) Then
            url &= "&id2=" & Server.HtmlEncode(material_id2.Text)
        End If
        If Not String.IsNullOrEmpty(Out_date1.Text) Then
            url &= "&outDate1=" & Server.HtmlEncode(Out_date1.Text)
        End If
        If Not String.IsNullOrEmpty(Out_date2.Text) Then
            url &= "&outDate2=" & Server.HtmlEncode(Out_date2.Text)
        End If
        If Not String.IsNullOrEmpty(ddlDepart_id.SelectedValue ) Then
            url &= "&ddlSelect=" & Server.HtmlEncode(ddlDepart_id.SelectedValue)
        End If
        If Not String.IsNullOrEmpty(ddlUser_name.SelectedValue) Then
            url &= "&ddlUser_name=" & Server.HtmlEncode(ddlUser_name.SelectedValue)
        End If
        Response.Redirect(url)
        'Response.Write("<script>window.open('" & url & "','','menubar=no,status=no,scrollbars=yes,top=100,left=200,toolbar=no,width=800,height=600')</script>;")

    End Sub

    

    Protected Sub btnSelect_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSelect.Click

        Dim db As DataTable = New DataTable
        Dim mat As MAT0317 = New MAT0317
        Dim RadioSelect As String = ""
        Dim id1 As String = ""
        Dim id2 As String = ""
        Dim outDate1 As String = ""
        Dim outDate2 As String = ""
        Dim ddlSelect As String = ""
        Dim txtUid As String = ""
        If Not CommonFun.IsNum(material_id1.Text) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "物料編號只能輸入數字")
            Return
        End If
        If Not CommonFun.IsNum(material_id2.Text) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "物料編號只能輸入數字")
            Return
        End If
        If Not String.IsNullOrEmpty(ucType.Code_no) Then
            RadioSelect = Server.HtmlEncode(ucType.Code_no)
        End If
        If Not String.IsNullOrEmpty(material_id1.Text) Then
            id1 = Server.HtmlEncode(material_id1.Text)
        End If
        If Not String.IsNullOrEmpty(material_id2.Text) Then
            id2 = Server.HtmlEncode(material_id2.Text)
        End If
        If Not String.IsNullOrEmpty(Out_date1.Text) Then
            outDate1 = Server.HtmlEncode(Out_date1.Text)
        End If
        If Not String.IsNullOrEmpty(Out_date2.Text) Then
            outDate2 = Server.HtmlEncode(Out_date2.Text)
        End If
        If Not String.IsNullOrEmpty(ddlDepart_id.SelectedValue) Then
            ddlSelect = Server.HtmlEncode(ddlDepart_id.SelectedValue)
        End If
        If Not String.IsNullOrEmpty(ddlUser_name.SelectedValue) Then
            txtUid = Server.HtmlEncode(ddlUser_name.SelectedValue)
        End If

        db = mat.getApplyMAT(RadioSelect, id1, id2, outDate1, outDate2, _
                             ddlSelect, txtUid)

        Me.GridView_Uporg.DataSource = db
        Me.GridView_Uporg.DataBind()

        Me.div1.Visible = True
    End Sub

    Protected Sub Btn_Reset(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReset.Click
        CommonFun.ClearContentPlaceHolder(Me.Master)
        showddl()
        'div1.Visible = False
    End Sub

#Region "輸出excel檔"
    'Protected Sub btnPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrint.Click

    '    Dim dt As DataTable = New DataTable()

    '    Dim mat As MAT0317 = New MAT0317()
    '    dt = CType((mat.getApplyPrintMAT(Radio_Apply.SelectedValue, ddlLeave_type.SelectedValue, txtUserId.Text, _
    '                                     material_id1.Text, material_id2.Text, Out_date1.Text, Out_date2.Text)), DataTable)
    '    dt.Columns.Add("num", GetType(System.String))

    '    Dim theDTReport As CommonLib.DTReport1
    '    Dim strParam(4) As String

    '    For i As Integer = 0 To dt.Rows.Count - 1
    '        dt.Rows(i).Item("num") = i \ 25 + 1
    '    Next
    '    strParam(0) = Right("000" & Today.Year - 1911, 3) & "/" & Today.ToString("MM/dd")
    '    strParam(1) = LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name)
    '    'Dim f As New FSCPLM.Logic.FSCorg
    '    'strParam(2) = f.GetOrgcodeName(LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode))
    '    strParam(2) = ""
    '    strParam(3) = ""

    '    theDTReport = New CommonLib.DTReport1(Server.MapPath("~/Report/MAT_Material_main/MAT0317.mht"), dt)
    '    'Dim _GroupPageArys As String() = {"Material_name", "Material_name"}
    '    'theDTReport._GroupPageArys = _GroupPageArys
    '    theDTReport.breakPage = "num"
    '    theDTReport.Param = strParam  '將參數代入
    '    theDTReport.ExportFileName = "領用物品查詢"
    '    theDTReport.ExportToExcel()

    '    dt.Dispose()

    'End Sub
#End Region



    Protected Sub UcMaterialClassB_Checked(sender As Object, e As EventArgs)
        material_id1.Text = UcMaterialClassB.MaterialId
    End Sub

    Protected Sub UcMaterialClassE_Checked(sender As Object, e As EventArgs)
        material_id2.Text = UcMaterialClassE.MaterialId


    End Sub
End Class
