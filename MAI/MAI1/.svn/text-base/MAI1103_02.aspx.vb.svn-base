Imports FSCPLM.Logic
Imports System.IO
Imports System.Data
Imports System.Transactions

Partial Class MAI_MAI1_MAI1103_02
    Inherits BaseWebForm

    Dim dao As New MAI1103
    Dim daoMember As New Member
    Dim swCode As String

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
            'lblUserInfo.Text = LoginManager.GetTicketUserData(LoginManager.LoginUserData.DepartName) & " " & LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name)
            'txtPhone_nos.Text = HttpUtility.UrlDecode(Request.QueryString("Phone_nos"))
            'lblResponseTime.Text = CommonFun.getYYYMMDD() & " " & Now.ToString("hh:mm:ss")
            ucServConfirm_type.DDL.AutoPostBack = True
            swCode = Request.QueryString("code")
            BindOne(swCode)
        End If

    End Sub

    Private Sub BindOne(swCode As String)
        Dim dr As DataRow = dao.GetOne(LoginManager.OrgCode, swCode)
        txtPhone_nos.Text = CommonFun.SetDataRow(dr, "Phone_nos")
        ucMtClass_type.Code_no = CommonFun.SetDataRow(dr, "MtClass_type")
        'ucMtItem_type.SelectedValue = CommonFun.SetDataRow(dr, "MtItem_type")
        ucTask_type.Code_no = CommonFun.SetDataRow(dr, "Task_type")
        ucServApply_type.Code_no = CommonFun.SetDataRow(dr, "ServApply_type")
        uc_SfExpect_date.Text = CommonFun.SetDataRow(dr, "SfExpect_date")
        txtProblem_desc.Text = CommonFun.SetDataRow(dr, "Problem_desc")
        txtSwMaintain_code.Text = swCode
        ddlMaintainer_name.SelectedValue = CommonFun.SetDataRow(dr, "Maintainer_name")
        txtMaintainerPhone_nos.Text = CommonFun.SetDataRow(dr, "MaintainerPhone_nos")
        txtMtStatus_desc.Text = CommonFun.SetDataRow(dr, "MtStatus_desc")
        ucMtStatus_type.Code_no = CommonFun.SetDataRow(dr, "MtStatus_type")
        ucForecast_date.Text = CommonFun.SetDataRow(dr, "Forecast_date")
        ucServConfirm_type.Code_no = CommonFun.SetDataRow(dr, "ServConfirm_type")
        ucManagerCheck_type.Code_no = CommonFun.SetDataRow(dr, "ManagerCheck_type")
        ucChiefCheck_type.Code_no = CommonFun.SetDataRow(dr, "ChiefCheck_type")
        txtProperty_id.Text = CommonFun.SetDataRow(dr, "Property_id")
        lblResponseTime.Text = CommonFun.SetDataRow(dr, "ResponseTime")
        cbExceed3Month_type.Checked = CommonFun.SetDataRow(dr, "Exceed3Month_type") = "Y"

    End Sub

    Public Sub ucMtClass_type_CodeChanged(sender As Object, e As System.EventArgs) Handles ucMtClass_type.CodeChanged
        ucMtItem_type.Code_type = ucMtClass_type.Code_no
        ucMtItem_type.Rebind()
        BindMaintainer()
    End Sub

    Public Sub ucMtItem_type_CodeChanged(sender As Object, e As System.EventArgs) Handles ucMtItem_type.CodeChanged
        BindMaintainer()
    End Sub

    Private Sub BindMaintainer()
        Dim dr As DataRow = dao.GetMaintainer("020" + ucMtClass_type.Code_no + ucMtItem_type.Code_no, LoginManager.OrgCode)
        If Not dr Is Nothing Then
            ddlMaintainer_name.Items.Clear()
            ddlMaintainer_name.Items.Add(New ListItem(CommonFun.SetDataRow(dr, "Maintainer_name"), CommonFun.SetDataRow(dr, "MtItem_type")))
            txtMaintainerPhone_nos.Text = CommonFun.SetDataRow(dr, "MaintainerPhone_nos")
        End If
    End Sub

    Public Sub ucServConfirm_type_CodeChanged(sender As Object, e As System.EventArgs) Handles ucServConfirm_type.CodeChanged
        divConfirm.Visible = ucServConfirm_type.SelectedValue = "004"
    End Sub

    Protected Sub DoneBtn_Click(sender As Object, e As EventArgs) Handles DoneBtn.Click

        Try
            Dim msg As String = CheckRequire()
            If String.IsNullOrEmpty(msg) Then
                Dim file1Name As String = String.Empty
                Dim file2Name As String = String.Empty
                Dim fuReqName As String = String.Empty


                If Me.fuAttachment1.HasFile Then
                    file1Name = String.Format("{0}_{1}.{2}", (Now.Year - 1911), Guid.NewGuid().ToString(), Path.GetExtension(fuAttachment1.PostedFile.FileName))
                    Me.fuAttachment1.PostedFile.SaveAs(Path.Combine(MapPath("~/fileupload/Attachment/56"), file1Name))
                End If
                If Me.fuAttachment2.HasFile Then
                    file2Name = String.Format("{0}_{1}.{2}", (Now.Year - 1911), Guid.NewGuid().ToString(), Path.GetExtension(fuAttachment2.PostedFile.FileName))
                    Me.fuAttachment2.PostedFile.SaveAs(Path.Combine(MapPath("~/fileupload/Attachment/56"), file2Name))
                End If

                If Me.fuReqAttachment.HasFile Then
                    fuReqName = String.Format("{0}_{1}.{2}", (Now.Year - 1911), Guid.NewGuid().ToString(), Path.GetExtension(fuReqAttachment.PostedFile.FileName))
                    Me.fuReqAttachment.PostedFile.SaveAs(Path.Combine(MapPath("~/fileupload/Attachment/56"), fuReqName))
                End If

                'Dim flowID As String = String.Empty
                'Dim f As New Flow()
                'f.Apply_Posid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Title_no)
                'f.Apply_id = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card)
                'f.Apply_Name = LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name)
                'f.Leave_group = "K"
                'f.Leave_ngroup = "K1"
                'f.Leave_type = "56"
                'f.Writer_id = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card)
                'f.Start_Date = CommonFun.getYYYMMDD
                'f.End_Date = CommonFun.getYYYMMDD
                'f.ProcessAddFlow()

                'Using trans As New TransactionScope
                '    flowID = f.GetFlow_id(f.Leave_type)
                '    '新增Flow
                '    f.Flow_id = flowID
                '    If Not f.AddFlow() Then
                '        Throw New FlowException("新增表單失敗!")
                '    End If

                '    trans.Complete()
                'End Using

                'dao.Update02(swCode, flowID, txtPhone_nos.Text, LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id), LoginManager.UserId, ucMtStatus_type.SelectedValue, "", "", _
                '             ucServApply_type.SelectedValue, uc_SfExpect_date.Text, txtProblem_desc.Text, file1Name, file2Name, _
                '        ucMtClass_type.SelectedValue, ucMtItem_type.SelectedValue, ucTask_type.SelectedValue, ddlMaintainer_name.SelectedValue, txtMaintainerPhone_nos.Text, _
                '        txtMtStatus_desc.Text, ucMtStatus_type.SelectedValue, ucForecast_date.Text, ucServConfirm_type.SelectedValue, txtProperty_id.Text, fuReqName, _
                '        CommonFun.getYYYMMDD(lblResponseTime.Text), IIf(cbExceed3Month_type.Checked, "Y", "N"), _
                '        LoginManager.OrgCode, LoginManager.UserId, Now)
            Else
                CommonFun.MsgShow(Page, CommonFun.Msg.Custom, msg)
            End If
        Catch ex As Exception
            CommonFun.MsgShow(Page, CommonFun.Msg.Custom, ex.Message)
        End Try

        
    End Sub

    Protected Sub ReSendBtn_Click(sender As Object, e As EventArgs) Handles ReSendBtn.Click 
        dao.UpdateRepeatApply_type(swCode, "Y")
        ReSendBtn.Enabled = False
    End Sub

    Protected Sub ClrBtnBtn_Click(sender As Object, e As EventArgs) Handles ClrBtn.Click 
        BindOne(swCode)
    End Sub

    Private Function CheckRequire() As String
        Dim msg As String = String.Empty
        If String.IsNullOrEmpty(txtPhone_nos.Text) Then
            msg &= "請輸入報修人聯絡分機\n"
        End If
        If String.IsNullOrEmpty(ucMtItem_type.SelectedValue) OrElse String.IsNullOrEmpty(ucMtItem_type.SelectedValue) Then
            msg &= "請選擇報修類別\n"
        End If
        If String.IsNullOrEmpty(ucTask_type.SelectedValue) Then
            msg &= "請選擇作業類別\n"
        End If
        Return msg
    End Function

End Class
