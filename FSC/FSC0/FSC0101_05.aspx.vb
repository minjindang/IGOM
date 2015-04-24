Imports FSCPLM.Logic
Imports System.Data
Imports System.Data.SqlClient

Partial Class FSC0101_05
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
        Dim pm As New PurchaseMain()
        Dim pd As New MAT.Logic.PurchaseDet()
        Dim code As New SACode()

        rbxPurchaseType.DataSource = code.GetData2("014", "P", "002")
        rbxPurchaseType.DataBind()

        Dim dt As DataTable = pm.GetDataByFlowId(Orgcode, flowId)
        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            Dim r As DataRow = dt.Rows(0)
            lbUseDesc.Text = r("Use_desc").ToString()
            rbxPurchaseType.SelectedValue = r("Purchase_type").ToString()
        End If

        gv.DataSource = pd.GetDataByFlowId(Orgcode, flowId)
        gv.DataBind()

        UcFlowDetail.Orgcode = Orgcode
        UcFlowDetail.FlowId = flowId

    End Sub

    Protected Sub cbBack_Click(sender As Object, e As EventArgs)
        Response.Redirect(ViewState("BackUrl"))
    End Sub
End Class
