Imports System.Data

Imports FSCPLM.Logic

Partial Class MAI_MAI3_MAI3201_02
    Inherits BaseWebForm

    Dim dao As New MAI3201
     
    Protected Sub Page_Load1(sender As Object, e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then

            Me.lblFlow_id.Text = Page.Request.QueryString("flow_id")
            Me.hfMtClass_type.Value = Page.Request.QueryString("MtClass_type")


            BindOne()

        End If

    End Sub

    Private Sub BindOne()

        ddlMaintainer.Items.Clear()
        ddlMaintainer.DataSource = dao.GetByMaintain_type(LoginManager.OrgCode)
        ddlMaintainer.DataTextField = "Maintainer_name"
        ddlMaintainer.DataValueField = "MaintainerPhone_nos"
        ddlMaintainer.DataBind()
        ddlMaintainer.Items.Insert(0, "")

        Dim detDR As DataRow = Nothing
        Dim mainDR As DataRow = Nothing

        dao.GetOne(lblFlow_id.Text, hfMtClass_type.Value, detDR, mainDR)

        If Not mainDR Is Nothing Then
            lblUser_Name.Text = CommonFun.SetDataRow(mainDR, "User_Name")
            lblPhone_nos.Text = CommonFun.SetDataRow(mainDR, "Phone_nos")
            lblUnit_code.Text = CommonFun.SetDataRow(mainDR, "Unit_code")
            lblApplyTime.Text = CommonFun.getYYYMMDD(CommonFun.SetDataRow(mainDR, "ApplyTime"))
            lblPhone_nos.Text = CommonFun.SetDataRow(mainDR, "Phone_nos")
        End If

        If Not detDR Is Nothing Then
            lblMtClass_typeName.Text = CommonFun.SetDataRow(detDR, "MtClass_type")
            lblMtStartTime.Text = CommonFun.SetDataRow(detDR, "MtStartTime")
            lblMtEndTime.Text = CommonFun.SetDataRow(detDR, "MtEndTime")
            txtProblem_desc.Text = CommonFun.SetDataRow(detDR, "Problem_desc")
            lblElecExpect_type.Text = CommonFun.SetDataRow(detDR, "ElecExpect_type")
            'ddlMaintainer.SelectedValue = CommonFun.SetDataRow(detDR, "MaintainerPhone_nos")
            'ucMtStatus_type.Code_no = CommonFun.SetDataRow(detDR, "MtStatus_type")
            lblMtTime.Text = CommonFun.SetDataRow(detDR, "MtTime") & "小時"
        End If

    End Sub

    Protected Sub DoneBtn_Click(sender As Object, e As EventArgs) Handles DoneBtn.Click
        Dim msg As String = String.Empty
        If "001" <> ucMtStatus_type.Code_no AndAlso String.IsNullOrEmpty(ddlMaintainer.SelectedValue) Then
            msg += "請選擇維修人員\n"
        End If

        If String.IsNullOrEmpty(msg) Then
            msg = dao.Done(LoginManager.OrgCode, lblFlow_id.Text, hfMtClass_type.Value, ddlMaintainer.SelectedItem.Text, ddlMaintainer.SelectedValue, _
                 ucMtStatus_type.Code_no, txtMtStatus_desc.Text, rblCaseClose_type.SelectedValue)
            If String.IsNullOrEmpty(msg) Then
                BindOne()
            Else
                CommonFun.MsgShow(Page, CommonFun.Msg.Custom, msg)
            End If 
        Else
            CommonFun.MsgShow(Page, CommonFun.Msg.Custom, msg)
        End If


        

    End Sub

    Protected Sub CancelBtn_Click(sender As Object, e As EventArgs) Handles CancelBtn.Click
        BindOne()
    End Sub


End Class

