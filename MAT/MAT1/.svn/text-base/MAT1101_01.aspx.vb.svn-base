Imports System.Data

Imports FSCPLM.Logic

Partial Class MAT_MAT1_MAT1101_01
    Inherits BaseWebForm

    Dim materialAry As New ArrayList

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Dim materialStr As String = Request.QueryString("Materials")
            If Not String.IsNullOrEmpty(materialStr) Then
                For Each s As String In materialStr.Split(",")
                    materialAry.Add(s)
                Next
            End If
            Dim imDAO As New InventoryMain()
            Dim msg As String = imDAO.GetMemoMsg(LoginManager.OrgCode)
            If Not String.IsNullOrEmpty(msg) Then
                CommonFun.MsgShow(Page, CommonFun.Msg.Custom, msg)
                'Dim OkBtn As Button = lvMatClass.FindControl("OkBtn")
                'Dim ResetBtn As Button = lvMatClass.FindControl("ResetBtn")
                'OkBtn.Enabled = False
                'ResetBtn.Enabled = False
            Else
                BindList()
            End If

        End If

    End Sub

    Private Sub BindList()
        Dim matClass As New MaterialClass_data
        Dim dt As DataTable = matClass.GetData("", "")
        Dim dr As DataRow = dt.NewRow
        dr("MaterialClass_name") = "其他"
        dt.Rows.Add(dr)
        Me.lvMatClass.DataSource = dt
        Me.lvMatClass.DataBind()
    End Sub

    Protected Sub lvMatClass_ItemDataBound(sender As Object, e As ListViewItemEventArgs) Handles lvMatClass.ItemDataBound
        If e.Item.ItemType = ListViewItemType.DataItem Then
            Dim hfMatClassId As HiddenField = e.Item.FindControl("hfMatClassId")
            Dim dlMaterial As DataList = e.Item.FindControl("dlMaterial")
            AddHandler dlMaterial.ItemDataBound, AddressOf dlMaterial_ItemDataBound

            Dim mat As New Material_main
            If Not String.IsNullOrEmpty(hfMatClassId.Value) Then
                dlMaterial.DataSource = mat.GetDataByClassId(hfMatClassId.Value, True)
                dlMaterial.DataBind()
            Else
                dlMaterial.DataSource = mat.GetOtherData(True)
                dlMaterial.DataBind()
            End If
        End If
    End Sub


    Protected Sub dlMaterial_ItemDataBound(sender As Object, e As DataListItemEventArgs)
        If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
             
            Dim hfAvailable_cnt As HiddenField = e.Item.FindControl("hfAvailable_cnt")
            Dim hfMaterialIcon As HiddenField = e.Item.FindControl("hfMaterialIcon")
            Dim hfMaterial_id As HiddenField = e.Item.FindControl("hfMaterial_id")
            Dim imgMaterial As Image = e.Item.FindControl("imgMaterial")
            Dim cbMaterial_name As CheckBox = e.Item.FindControl("cbMaterial_name")
            If Not hfMaterialIcon Is Nothing AndAlso Not String.IsNullOrEmpty(hfMaterialIcon.Value) Then
                imgMaterial.ImageUrl = "~/fileupload/Image/" & hfMaterialIcon.Value
            Else
                imgMaterial.Visible = False
            End If
            cbMaterial_name.Checked = materialAry.Contains(hfMaterial_id.Value.ToString())
            If hfAvailable_cnt.Value = "0" Then
                cbMaterial_name.Enabled = False
                cbMaterial_name.Text = cbMaterial_name.Text & "(無庫存)"
                cbMaterial_name.ForeColor = Drawing.Color.Red
            End If

        End If
    End Sub

    Protected Sub lvMatClass_LayoutCreated(sender As Object, e As EventArgs) Handles lvMatClass.DataBound
        'Dim OkBtn As Button = lvMatClass.FindControl("OkBtn")
        'Dim ResetBtn As Button = lvMatClass.FindControl("ResetBtn")
        'AddHandler OkBtn.Click, AddressOf OkBtn_Click
        'AddHandler ResetBtn.Click, AddressOf ResetBtn_Click
    End Sub

    Protected Sub OkBtn_Click(sender As Object, e As EventArgs)
        'Dim checkMaterialIdAry As New ArrayList
        Dim isChecked As Boolean = False
        Dim materialIDs As String = String.Empty
        For Each item As ListViewItem In lvMatClass.Items
            Dim dlMaterial As DataList = item.FindControl("dlMaterial")
            For Each dataListItem As DataListItem In dlMaterial.Items
                Dim cbMaterial_name As CheckBox = dataListItem.FindControl("cbMaterial_name")
                Dim hfMaterial_id As HiddenField = dataListItem.FindControl("hfMaterial_id")
                If cbMaterial_name.Checked Then
                    isChecked = True
                    'checkMaterialIdAry.Add(hfMaterial_id.Value)
                    materialIDs &= hfMaterial_id.Value & ","
                End If

            Next
        Next

        If Not isChecked Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "請選取任一物料!")
            Return
        End If

        'CommonFun.MsgShow(Page, CommonFun.Msg.Custom, checkMaterialIdAry.Count)
        Response.Redirect("~/MAT/MAT1/MAT1101_02.aspx?Materials=" & IIf(materialIDs.Length > 0, materialIDs.Substring(0, materialIDs.Length - 1), ""))

    End Sub

    Protected Sub ResetBtn_Click(sender As Object, e As EventArgs)
        CommonFun.ClearContentPlaceHolder(Me.Master)
    End Sub


End Class
