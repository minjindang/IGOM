Imports FSCPLM.Logic
Imports System.Data
Imports System.Data.SqlClient

Partial Class FSC0101_09
    Inherits BaseWebForm

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then
            Return
        End If
        Bind()
    End Sub

    Protected Sub Bind()
        Dim flowId As String = Request.QueryString("fid")
        Dim Orgcode As String = Request.QueryString("org")
        Dim bll As New FSC.Logic.FSC0101()
        Dim code As New SACode()
        Dim dt As DataTable = bll.GetSwRegisterData(Orgcode, flowId)

        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            Dim r As DataRow = dt.Rows(0)
            lbOfficialNumber_id.Text = r("OfficialNumber_id").ToString()
            lbSoftware_id.Text = r("Software_id").ToString()
            ucSoftware_type.SelectedValue = r("Software_type").ToString()
            CType(ucSoftware_type.FindControl("RadioButton_Code_no"), RadioButtonList).Enabled = False
            lbSoftware_name.Text = r("Software_name").ToString()
            lbVersion.Text = r("Version").ToString()
            lbKeyNumber_nos.Text = r("KeyNumber_nos").ToString()
            ucSoftwareKind_type.SelectedValue = r("SoftwareKind_type").ToString()
            CType(ucSoftwareKind_type.FindControl("RadioButton_Code_no"), RadioButtonList).Enabled = False
            lbNetPLimit_cnt.Text = r("NetPLimit_cnt").ToString()
            lbSofeware_cnt.Text = r("Sofeware_cnt").ToString()
            ucObtain_type.SelectedValue = r("Obtain_type").ToString()
            CType(ucObtain_type.FindControl("RadioButton_Code_no"), RadioButtonList).Enabled = False
            lbObtainOt_desc.Text = r("ObtainOt_desc").ToString()
            lbSoftwareCom_name.Text = r("SoftwareUnit_name").ToString()
            ucStorageMedia_type.SelectedValue = r("StorageMedia_type").ToString()
            CType(ucStorageMedia_type.FindControl("RadioButton_Code_no"), RadioButtonList).Enabled = False
            lbStorageMediaOt_desc.Text = r("StorageMediaOt_desc").ToString()
            lbStorageMedia_cnt.Text = r("StorageMedia_cnt").ToString()
            lbRelatedPapers_name.Text = r("RelatedPapers_name").ToString()
            lbLifeTime.Text = r("LifeTime").ToString()
            lbFee_amt.Text = r("Fee_amt").ToString()
            lbMRent_amt.Text = r("MRent_amt").ToString()
            lbStart_date.Text = r("Start_date").ToString()
            lbMemo.Text = r("Memo").ToString()
            lbUnit_code.Text = r("Unit_code").ToString()
            lbUser_id.Text = r("User_id").ToString()
            lbRegister_date.Text = r("Register_date").ToString()
        End If

        UcFlowDetail.Orgcode = Orgcode
        UcFlowDetail.FlowId = flowId

    End Sub

    Protected Sub cbBack_Click(sender As Object, e As EventArgs)
        Response.Redirect(ViewState("BackUrl"))
    End Sub
End Class
